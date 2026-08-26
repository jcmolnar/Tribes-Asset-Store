// - BW Admin Mod -
$PlayerAnim::Crouching = 25;
$PlayerAnim::DieChest = 26;
$PlayerAnim::DieHead = 27;
$PlayerAnim::DieGrabBack = 28;
$PlayerAnim::DieRightSide = 29;
$PlayerAnim::DieLeftSide = 30;
$PlayerAnim::DieLegLeft = 31;
$PlayerAnim::DieLegRight = 32;
$PlayerAnim::DieBlownBack = 33;
$PlayerAnim::DieSpin = 34;
$PlayerAnim::DieForward = 35;
$PlayerAnim::DieForwardKneel = 36;
$PlayerAnim::DieBack = 37;

//----------------------------------------------------------------------------
$CorpseTimeoutValue = 22;
//----------------------------------------------------------------------------

// Player & Armor data block callbacks

function Player::onAdd(%this)
{
	GameBase::setRechargeRate(%this,8);
	schedule("TACTimerCheck(" @ %this @ ");",2.0,%this);
}

function Player::onRemove(%this)
{
	// Drop anything left at the players pos
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			// Note: Player::dropItem ius not called here.
			%item = newObject("","Item",%type,1,false);
         schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);

         addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));
		}
	}
}

function Player::onNoAmmo(%player,%imageSlot,%itemType)
{
	//echo("No ammo for weapon ",%itemType.description," slot(",%imageSlot,")");
}

function Player::onKilled(%this)
{
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	if(%this.outArea==1)
//		leaveMissionAreaDamage(%cl);
	Player::setDamageFlash(%this,0.75);
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.2")
				Player::dropItem(%this,%type);
		}
	}

   if(%cl != -1)
   {
		if(%this.vehicle != "")
		{
			if(%this.driver != "")
			{
				%this.driver = "";
				%vehicleId = %this.vehicle;
				%vehicleId.hasPilot = false;
        	 	Client::setControlObject(Player::getClient(%this), %this);
        	 	Player::setMountObject(%this, -1, 0);
			}
			else
			{
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";
		}
      schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
      Client::setOwnedObject(%cl, -1);
      Client::setControlObject(%cl, Client::getObserverCamera(%cl));
      Observer::setOrbitObject(%cl, %this, 5, 5, 5);

		UpdateHUDPlayerData(%this,%this.vehicle,"passenger dismount");

      schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
      %cl.observerMode = "dead";
      %cl.dieTime = getSimTime();
   }
}


//----------------------------------------------------------------------------
// GROUND KILL EXPLOSION DATA

MineData GKExplosion
{
	className = "Mine";
    shapeFile = "breath";
    shadowDetailMask = 1;
    explosionId = mineExp;
	explosionRadius = 0;
	damageValue = 0;
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 0;
	maxDamage = 0.0001;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
	mass = 0;
	drag = 100.0;
};

ExplosionData GKmineExp
{
   shapeName = "bluex.dts";
//   soundId   = shockExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;
   timeScale = 1.5;
   timeZero = 0.0;
   timeOne  = 0.250;
   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

GrenadeData GKEffect
{
	explosionTag       = GKmineExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 0.0;
	elasticity         = 0.0;
	damageClass        = 1;
	damageValue        = 0;
	damageType         = $MineDamageType;
	explosionRadius    = 0;
	kickBackStrength   = 0;
	maxLevelFlightDist = 375;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.01;
	inheritedVelocityScale = 0.0;
};

function GKExplosion::Detonate(%this)
{
	%cl = %this.deployer;
	%player = client::getownedobject(%cl);
	%vel = "0 0 0";
	if (!%player)
		return;
	%pos1 = gamebase::getposition(%this);
	%rot = (gamebase::getrotation(%this));
	%dir = (Vector::getfromrot(%rot));
	%trans1 = (%rot @ " " @ %dir @ " " @ %rot);
	%padd = "0 0 2.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(GKEffect, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
}


//----------------------------------------------------------------------------

function TACTimerCheck(%this)
{
	GroundKillCheck(%this,true);
	%playerId = Player::getClient(%this);
	TAC_CheckPenaltyStatus(%playerId);
	schedule("TACTimerCheck(" @ %this @ ");",2.0,%this);
}



function GroundKillCheck(%this,%timer, %shieldcheck, %bumpplayer)
{
	if(%shieldcheck == "")
		%shieldcheck = 0;
	if(%this.shieldcheck == "")
		%this.shieldcheck = 0;

	%shieldcheck++;

	%playerId = Player::getClient(%this);

	$LandDamagePlayer[%this] = true;
	%GroundKillPlayer = false;

	%clientId = Player::getClient(%this);
	%playerposition = GameBase::getPosition(%this);
	%armor = Player::getArmor(%playerId);
	%xcoord = getWord(%playerposition,0);
	%ycoord = getWord(%playerposition,1);
	%zcoord = getWord(%playerposition,2) + 1;
	if(%armor == "larmor" || %armor == "lfemale")
		%diff = 0.50;
	else if(%armor == "marmor" || %armor == "mfemale")
		%diff = 0.70;
	else if(%armor == "harmor")
		%diff = 0.80;

	%GKExplosionPosition = sprintf("%1 %2 %3",%xcoord, %ycoord + %diff, %zcoord);
	%spriteobj[%this] = newObject("","Mine","GKExplosion");
	addToSet("MissionCleanup", %spriteobj[%this]);
	GameBase::setPosition(%spriteobj[%this],%GKExplosionPosition);
	GameBase::setRotation(%spriteobj[%this], "0 0 0");
	if(GameBase::getLOSInfo(%spriteobj[%this],2,"-1.57 0 0"))
	{
		%terrain = getObjectType($los::object);
		if(%terrain == "SimTerrain")
			%GroundKillPlayer = true;
	}
	else
	{
		%GKExplosionPosition = sprintf("%1 %2 %3",%xcoord, %ycoord, %zcoord + %diff);
		GameBase::setPosition(%spriteobj[%this],%GKExplosionPosition);
		if(GameBase::getLOSInfo(%spriteobj[%this],2,"-1.57 0 0"))
		{
			%terrain = getObjectType($los::object);
			if(%terrain == "SimTerrain")
				%GroundKillPlayer = true;
		}
	}
	if((!%timer) && (!%GroundKillPlayer))
	{
		//Run second style ground check
		%playerposition = GameBase::getPosition(%this);
		%gkset[%this] = newObject("gkset",SimSet);
		%num = containerBoxFillSet(%gkset[%this],$SimInteriorObjectType | $SimPlayerObjectType | $MoveableObjectType | $VehicleObjectType | $StaticObjectType,%playerposition,3,3,4,0);
		%finalnum = %num;
		for(%i = 0; %i < %num; %i++)
		{
			if(Group::getObject(%gkset[%this],%i) == %this)
			{
				removeFromSet(%gkset[%this],%i);
				%finalnum = %finalnum-1;
			}
		}
		deleteObject(%gkset[%this]);
		if(%finalnum == 0)
			%GroundKillPlayer = true;
	}

	//Kill player if on ground
	if(%GroundKillPlayer)
	{
		if(%this.shieldStrength == "")
			%this.shieldStrength = 0;
		%energy = GameBase::getEnergy(%this);
		%shieldpower = %energy / %armor.maxEnergy;
		if (%shieldpower < 0.1 || %this.shieldStrength == 0)
		{
			if(!$GKCurrentExplosion[%this])
			{
				%xcoord = getWord(%playerposition,0);
				%ycoord = getWord(%playerposition,1);
				%zcoord = getWord(%playerposition,2) + 0.1;
				%GKExplosionPosition = sprintf("%1 %2 %3",%xcoord, %ycoord, %zcoord);
				GameBase::setPosition(%spriteobj[%this],%GKExplosionPosition);
				GKExplosion::Detonate(%spriteobj[%this]);
				$GKCurrentExplosion[%this] = true;
				Schedule("$GKCurrentExplosion[" @ %this @ "] = false;",25.0);
			}
			%victimName = Client::getName(%clientId);
			GameBase::setEnergy(%this,0);
			%this.shieldcheck = 0;
			Player::kill(%this);
			Player::blowUp(%this);
			%clientId.scoreDeaths++;
			%clientId.score--;
			Game::refreshClientScore(%clientId);
			if (%victimName != "")
				Client::onKilled(%clientId, %clientId, -3);
			deleteObject(%spriteobj[%this]);
			$LandDamagePlayer[%this] = false;
		}
		else
		{
			//reduce shield pack energy after ground save.
			if(%this.shieldcheck == 0 || %shieldcheck > 1)
			{
				%energyloss = 0.025 * %armor.maxEnergy;
				%thisPos = getBoxCenter(%this);
				%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
				GameBase::activateShield(%this,%vec,%offsetZ);
				%flashpower = 1/%shieldpower * 0.25;
				Player::setDamageFlash(%this,%flashpower);
				schedule("Player::setDamageFlash("@%this@","@%flashpower@");",0.25,%this);
				schedule("Player::setDamageFlash("@%this@","@%flashpower@");",0.125,%this);
				schedule("Player::setDamageFlash("@%this@","@%flashpower@");",0.375,%this);
				if(%energy > %energyloss)
					GameBase::setEnergy(%this,%energy - %energyloss);
				else
					GameBase::setEnergy(%this,0);
				%this.shieldcheck = %shieldcheck;
				schedule("GroundKillCheck("@%this@",true,"@%shieldcheck@");",0.5,%this);
			}
		}
	}
	else
	{
		deleteObject(%spriteobj[%this]);
		$LandDamagePlayer[%this] = true;
		%this.shieldcheck = 0;
	}

	if(%bumpplayer)
		schedule("Player::applyImpulse("@%this@",\"0 0 60\");",0.05,%this);
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if (%type == $LandingDamageType)
	{
		GroundKillCheck(%this,false);
	}
    if (((%type == $LandingDamageType) && ($LandDamagePlayer[%this] != false)) || (%type != $LandingDamageType))
    {
		if (Player::isExposed(%this))
		{
		  %damagedClient = Player::getClient(%this);
		  %shooterClient = %object;
			Player::applyImpulse(%this,%mom);

			if(!%this.vehicle)
				TAC::KnockedToGround(%shooterClient, %damagedClient, %type);

			if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) {
				if (%shooterClient != -1)
				{
					%curTime = getSimTime();
				   if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) {

	// - BW Admin Mod - ELF Spam fix, props to LabRat
	// - BW Admin Mod - Reverse damage code - Wizard_TPG
						if(%type == $MineDamageType)
						{
							Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
							Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
						}
						else if(%type == $ElectricityDamageType && !%shooterClient.ELFhit)
						{
							%shooterClient.ELFhit = true;
							schedule(%shooterClient @ ".ELFhit = false;",10);
							Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
							TAC::TeamHurtDisplay(%shooterClient,%damagedClient,%type);
							if(%shooterClient.rd)
							{
								Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " and took " @ $TAC::ReverseFactor @ " the damage you caused.!");
								Admin::ReverseDamage(%object,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant);
							}
							else
								Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
						}
						else if(%type != $MineDamageType && %type != $ElectricityDamageType)
						{
							Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
							TAC::TeamHurtDisplay(%shooterClient,%damagedClient,%type);
							if(%shooterClient.rd)
							{
								Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " and took " @ $TAC::ReverseFactor @ " the damage you caused.!");
								Admin::ReverseDamage(%object,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant);
							}
							else
								Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
						}
	// - BW Admin Mod - Reverse damage code - Wizard_TPG - End
	// - BW Admin Mod - ELF Spam fix, props to LabRat - End

						%this.LastHarm = %shooterClient;
						%this.DamageStamp = %curTime;
					}
				}
				%friendFire = $Server::TeamDamageScale;
			}
			else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient))
				%friendFire = $Server::TeamDamageScale;
			else
				%friendFire = 1.0;



			if (!Player::isDead(%this)) {
				%armor = Player::getArmor(%this);
				//More damage applyed to head shots
				if(%vertPos == "head" && %type == $LaserDamageType) {
					if(%armor == "harmor") {
						if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
							%value += (%value * 0.3);
						}
					}
					else {
						%value += (%value * 0.3);
					}
				}
				//If Shield Pack is on
				if (%type != -1 && %this.shieldStrength) {
					%energy = GameBase::getEnergy(%this);
					%strength = %this.shieldStrength;
					if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
						%strength *= 0.75;
					%absorb = %energy * %strength;
					if (%value < %absorb) {
						GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
						%thisPos = getBoxCenter(%this);
						%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
						GameBase::activateShield(%this,%vec,%offsetZ);
						%value = 0;
					}
					else {
						GameBase::setEnergy(%this,0);
						%value = %value - %absorb;
					}
				}
				if (%value) {
					%value = $DamageScale[%armor, %type] * %value * %friendFire;

				//==========TAC - Reduce Landing Damage=============
					if (%type == $LandingDamageType)
					{
						%value = %value - 0.13;
						if (%value < 0)
							%value = 0;
					}
				//==================================================

				%dlevel = GameBase::getDamageLevel(%this) + %value;
				%spillOver = %dlevel - %armor.maxDamage;

	// - TAC Mod - Long Walk Home - Protect carrier & ensure queued/enstationed flags get dropped.
			if($TAC::walk)
			{
				if(%this.carryflag != "" && TAC::walk::checkForBuddy(%this))
				   return;
				if(%spillover >= 0 && (Player::getNextMountedItem(%this,$WeaponSlot) == "flag" || %this.station != ""))
				   Player::dropItem(%this,flag);
					}
	// - TAC Mod - Long Walk Home - End
					GameBase::setDamageLevel(%this,%dlevel);
					%flash = Player::getDamageFlash(%this) + %value * 2;
					if (%flash > 0.75)
						%flash = 0.75;
					Player::setDamageFlash(%this,%flash);
					//If player not dead then play a random hurt sound
					if(!Player::isDead(%this)) {
						if(%damagedClient.lastDamage < getSimTime()) {
							%sound = radnomItems(3,injure1,injure2,injure3);
							playVoice(%damagedClient,%sound);
							%damagedClient.lastdamage = getSimTime() + 1.5;
						}
					}
					else
					{
						if(%type == $ImpactDamageType && %object.clLastMount != "")
							%shooterClient = %object.clLastMount;
					   	if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType))
					   	{
							Player::trigger(%this, $WeaponSlot, false);
							%weaponType = Player::getMountedItem(%this,$WeaponSlot);
							if(%weaponType != -1)
								Player::dropItem(%this,%weaponType);
							Player::blowUp(%this);
						}
						else
						{
							if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) {
								if(%quadrant == "front_left" || %quadrant == "front_right")
									%curDie = $PlayerAnim::DieBlownBack;
								else
									%curDie = $PlayerAnim::DieForward;
							}
							else if( Player::isCrouching(%this) )
								%curDie = $PlayerAnim::Crouching;
							else if(%vertPos=="head") {
								if(%quadrant == "front_left" ||	%quadrant == "front_right"	)
									%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
								else
									%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
							}
							else if (%vertPos == "torso") {
								if(%quadrant == "front_left" )
									%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
								else if(%quadrant == "front_right")
									%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
								else if(%quadrant == "back_left" )
									%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
								else if(%quadrant == "back_right")
									%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							}
							else if (%vertPos == "legs") {
								if(%quadrant == "front_left" ||	%quadrant == "back_left")
									%curDie = $PlayerAnim::DieLegLeft;
								if(%quadrant == "front_right" ||	%quadrant == "back_right")
									%curDie = $PlayerAnim::DieLegRight;
							}
							Player::setAnimation(%this, %curDie);
						}


						Client::onKilled(%damagedClient,%shooterClient, %type);
					}
				}
			}
		}
	}
}

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Player::onCollision(%this,%object)
{
	if (Player::isDead(%this)) {
		if (getObjectType(%object) == "Player") {
			// Transfer all our items to the player
			%sound = false;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1) {
				%count = Player::getItemCount(%this,%i);
				if (%count) {
					%delta = Item::giveItem(%object,getItemData(%i),%count);
					if (%delta > 0) {
						Player::decItemCount(%this,%i,%delta);
						%sound = true;
					}
				}
			}
			if (%sound) {
				// Play pickup if we gave him anything
				playSound(SoundPickupItem,GameBase::getPosition(%this));
			}
		}
	}
}

function Player::getHeatFactor(%this)
{
	// Hack to avoid turret turret not tracking vehicles.
	// Assumes that if we are not in the player we are
	// controlling a vechicle, which is not always correct
	// but should be OK for now.
	%client = Player::getClient(%this);
	if (Client::getControlObject(%client) != %this)
		return 1.0;

   %time = getIntegerTime(true) >> 5;
   %lastTime = Player::lastJetTime(%this) >> 10;

   if ((%lastTime + 1.5) < %time) {
      return 0.0;
   } else {
      %diff = %time - %lastTime;
      %heat = 1.0 - (%diff / 1.5);
      return %heat;
   }
}

function Player::jump(%this,%mom)
{
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
      %vehicle = Player::getMountObject (%this);
		%this.lastMount = %vehicle;
		%this.newMountTime = getSimTime() + 3.0;
		Player::setMountObject(%this, %vehicle, 0);
		Player::setMountObject(%this, -1, 0);
		Player::applyImpulse(%pl,%mom);
		playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
   }
}


//----------------------------------------------------------------------------

function remoteKill(%client)
{
   if(!$matchStarted)
      return;

   %player = Client::getOwnedObject(%client);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   {
		playNextAnim(%client);
	   Player::kill(%client);
	   Client::onKilled(%client,%client);
   }
}

$animNumber = 25;
function playNextAnim(%client)
{
	if($animNumber > 36)
		$animNumber = 25;
	Player::setAnimation(%client,$animNumber++);
}
function Client::takeControl(%clientId, %objectId)
{
   // remote control
   if(%objectId == -1)
   {
      //echo("objectId = " @ %objectId);
      return;
   }

	%pl = Client::getOwnedObject(%clientId);
	// If mounted to a vehicle then can't mount any other objects
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;

   if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
   {
      //echo(GameBase::getTeam(%objectId) @ " " @ Client::getTeam(%clientId));
      return;
   }
   if(GameBase::getControlClient(%objectId) != -1)
   {
      echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
      return;
   }
	%name = GameBase::getDataName(%objectId);
	if(%name != CameraTurret && %name != DeployableTurret)
   {
	   if(!GameBase::isPowered(%objectId))
		{
	      // echo("Turret " @ %objectId @ " not powered.");
	      return;
		}
   }
   if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret &&
      !$TestCheats) {
		Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
   		return;
   }
   if(GameBase::getDamageState(%objectId) == "Enabled") {
   	Client::setControlObject(%clientId, %objectId);
   	Client::setGuiMode(%clientId, $GuiModePlay);
	}
}

function remoteCmdrMountObject(%clientId, %objectIdx)
{
   Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx));
}

function checkControlUnmount(%clientId)
{
   %ownedObject = Client::getOwnedObject(%clientId);
   %ctrlObject = Client::getControlObject(%clientId);
   if(%ownedObject != %ctrlObject)
   {
      if(%ownedObject == -1 || %ctrlObject == -1)
         return;
      if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject)
         return;
      Client::setControlObject(%clientId, %ownedObject);
   }
}

function TAC::KnockedToGround(%shootercl, %damagedcl, %type)
{
	if(%shootercl <= 1)
		return;

	if(%type != $ExplosionDamageType && %type != $ShrapnelDamageType && %type != $MortarDamageType)
		return;

	%damagedcl.lastknockerattacker = %shootercl;
	%damagedcl.lastknockerattack = %type;
//	schedule("TAC::ClearKnockToGround("@%shootercl@", "@%damagedcl@", "@%type@");",10,%damagedcl);
	schedule::cancel(%damagedcl);
	schedule::add(%damagedcl@".lastknockerattacker = 0;",10,%damagedcl,%damagedcl);

}

//function TAC::ClearKnockToGround(%shootercl, %damagedcl, %type)
//{
//	if((%damagedcl.lastknockerattacker == %shootercl) && (%damagedcl.lastknockerattack == %type))
//		%damagedcl.lastknockerattacker = 0;
//}

//=======================================
//	Schedule.cs   thanks Presto

function Schedule::Add(%eval, %time, %tag, %itemcheck)
{
	if (%tag == "")
		%tag = %eval;	// Use function as tag if none provided.
	$Schedule::ID[%tag]++;
	$Schedule::eval[%tag] = %eval;
	schedule("Schedule::Exec(\""@escapestring(%tag)@"\", "@$Schedule::ID[%tag]@");", %time, %itemcheck);
}

function Schedule::Exec(%tag, %id)
{
	if ($Schedule::ID[%tag] != %id)
		return;
	%eval = $Schedule::eval[%tag];
	Schedule::Cancel(%tag);
	eval(%eval);
}

function Schedule::Cancel(%tag)
{
	$Schedule::ID[%tag]++;
	$Schedule::eval[%tag] = "";
}
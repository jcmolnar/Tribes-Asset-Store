
// Player & Armor data block callbacks

function Player::onAdd(%this)
{
	GameBase::setRechargeRate(%this,8);
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
	if(%player != -1 && $Eradication::noAmmoNextWeapon && Player::isDead(%player) == false)
		nextWeapon();
}

function Player::rechargeShield(%player)
{
	if(%player.shieldRecharging && %player.shieldStrength < %player.shieldMax )  {
		%player.shieldStrength = %player.shieldStrength + %player.shieldMax * 0.1;
		if(%player.shieldStrength > %player.shieldMax) {
			GameBase::setEnergy(%player, (GameBase::getEnergy(%player) - (%player.shieldStrength - %player.shieldMax) * 100));
			%player.shieldStrength = %player.shieldMax;
			%player.shieldRecharging = false;
			Player::trigger(%player,$BackpackSlot,false);
			Bottomprint(Player::getClient(%player), "Shield At Max");
		}
		else {
			GameBase::setEnergy(%player, (GameBase::getEnergy(%player) - (%player.shieldMax * 0.1) * 100));
			Bottomprint(Player::getClient(%player), "Shields at "@ (%player.shieldStrength/%player.shieldMax)*100 @" percent.");
		}
		schedule("Player::rechargeShield("@ %player @");", 0.5, %player);
	}
}

function Player::capacitorFade(%player)
{
	if(%player.shieldMax > 0) {
		if(!%player.shieldHit && %player.shieldStrength > (%player.shieldMax * 0.25)) 
			%player.shieldStrength -= (%player.shieldMax * 0.1);
//		Bottomprint(Player::getClient(%player), "Shields at "@ (%player.shieldStrength/%player.shieldMax)*100 @" percent.");
		%player.shieldHit = false;
		schedule("Player::capacitorFade("@ %player @");", 10, %player);
	}
}

function Player::onKilled(%this)
{
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
//	if(%this.outArea==1)	
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
		if(%this.vehicle != "")	{
			if(%this.driver != "") {
				%this.driver = "";
        	 	Client::setControlObject(Player::getClient(%this), %this);
        	 	Player::setMountObject(%this, -1, 0);
			}
			else {
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";		
		}
      schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
      Client::setOwnedObject(%cl, -1);
      Client::setControlObject(%cl, Client::getObserverCamera(%cl));
      Observer::setOrbitObject(%cl, %this, 5, 5, 5);
      schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
      %cl.observerMode = "dead";
      %cl.dieTime = getSimTime();
   }
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if (Player::isExposed(%this)) {
      %damagedClient = Player::getClient(%this);
      %shooterClient = %object;

		Player::applyImpulse(%this,%mom);
		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) {
			if (%shooterClient != -1) {
				%curTime = getSimTime();
			   if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) {
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
			if(%this.vehicle != "" && %type > 0) {
				%vehicle = %this.vehicle;
				if(%vehicle.shieldStrength) {
					if (%value <= %strength) {
						%thisPos = getBoxCenter(%vehicle);
						%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
						GameBase::activateShield(%vehicle,%vec,%offsetZ);
						%vehicle.shieldStrength = %vehicle.shieldStrength - %value;
						%value = 0;
					}
					else {
						%thisPos = getBoxCenter(%vehicle);
						%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
						GameBase::activateShield(%vehicle,%vec,%offsetZ);
						%vehicle.shieldStrength = 0;
						%value = %value - %strength;
					}
				}
			}
			else if (%type > 0 && %this.shieldStrength) {
				%strength = %this.shieldStrength;
				if (Player::getMountedItem(%this,$BackpackSlot) == "AssaultPack") {
					if(getObjectType(%object) == "SimManager" || %type == $ExplosionDamageType || %type == $BulletDamageType)
						%value *= 0.75;
					else if(getObjectType(%object) != "SimManager" && (%type == $BlasterDamageType || %type == $ElectricityDamageType || %type == $PlasmaDamageType || %type == $EnergyDamageType))
						%value *= 1.5;
				}
				if (Player::getMountedItem(%this,$BackpackSlot) == "DefenderPack") {
					if(getObjectType(%object) == "SimManager")
						%value *= 1.5;
					else if(getObjectType(%object) != "SimManager" && (%type == $MortarDamageType || %type == $ShrapnelDamageType || %type == $BulletDamageType))
						%value *= 0.75;
				}
				if (%value <= %strength) {
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%this.shieldStrength = %this.shieldStrength - %value;
					%value = 0;
					%percentage = (%this.shieldStrength/%this.shieldMax)*100;
					Bottomprint(Player::getClient(%this), "Shields: "@ %percentage @"%");
				}
				else {
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%this.shieldStrength = 0;
					%value = %value - %strength;
					Bottomprint(Player::getClient(%this), "Shields: Depleted");
				}
				%this.shieldHit = true;
			}

  			if (%value) {
				%value = $DamageScale[%armor, %type] * %value * %friendFire;

				if(%vertPos == "head" && %type == $LaserDamageType) {
					if(%armor == "harmor" || %armor == "sarmor") { 
						if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
							%value += (%value * 0.3);
						}
					}
					else {
						%value += (%value * 0.3);
					}
					%object.headShots++;
					Client::sendMessage(Player::getClient(%object),0,"Good HeadShot!");
					Client::sendMessage(Player::getClient(%this),0,"Ouch! You just got shot in the head!!");
					%object.score++;
					Game::refreshClientScore(%object);
					if(%object.headShots > $MaxHeadShots && GameBase::getTeam(%object) != GameBase::getTeam(%this)) {
						$MaxHeadShotsName = Client::getName(%object);
						$MaxHeadShots = %object.headShots;
						ObjectiveMission::getOutstandingAchievements();
					}
				}
		            %dlevel = GameBase::getDamageLevel(%this) + %value;
          		%spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if (%flash > 0.75) 
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);

				if(!Player::isDead(%this)) { 
					if(%damagedClient.lastDamage < getSimTime()) {
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				else {
					%armorName = $ArmorName[Player::getArmor(%this)];
					$TeamItemCount[GameBase::getTeam(%damagedClient) @ %armorName]--;
					if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType)) {
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
			                	Player::blowUp(%this);
						%object.chunkShots++;
						Client::sendMessage(Player::getClient(%object),0,"Gratifying Chunks!");
						%object.score++;
						if(%object.chunkShots > $MaxChunkShots && GameBase::getTeam(%object) != GameBase::getTeam(%this)) {
							$MaxChunkShotsName = Client::getName(%object);
							$MaxChunkShots = %object.chunkShots;
							ObjectiveMission::getOutstandingAchievements();
						}
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
					if(%type == $ImpactDamageType && %object.clLastMount != "")  
						%shooterClient = %object.clLastMount;
					// MA
					if(Player::getLastContactCount(%this) > 50 && %object != -1 && GameBase::getTeam(%object) != GameBase::getTeam(%this) && (%type != $ExplosionDamageType || %type != $ShrapnelDamageType || %type != $MortarDamageType || %type != $MissileDamageType)) {
						%cl = Player::getClient(%object);
						%cl.score += 2;
						%cl.maks++;
						Game::refreshClientScore(%cl);
						Client::sendMessage(%cl,0,"MA!");
						if(%cl.maks > $MaxMAKs) {
							$MaxMAKsName = Client::getName(%cl);
							$MaxMAKs = %cl.maks;
							ObjectiveMission::getOutstandingAchievements();
							}
					}
					Client::onKilled(%damagedClient,%shooterClient, %type);
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
//------------------------------------
	else {
		%playerClient=Player::getClient(%this);
		%targetClient=Player::getClient(%object);
		if(Player::getArmor(%this) == "carmor" && getObjectType(%object) == "Player" && Client::getTeam(%targetClient) == Client::getTeam(%playerClient))
			{
			if(GameBase::getDamageLevel(%object) != 0)
				{
				GameBase::repairDamage(%object, 0.3);
				}			
			}
		if(Player::getArmor(%object) == "carmor" && Client::getTeam(%targetClient) == Client::getTeam(%playerClient))
			{
			if(GameBase::getDamageLevel(%object) != 0)
				{
				GameBase::repairDamage(%object, 0.3);
				}			
			}
		if(Player::getArmor(%this) == "sarmor" &&  (Client::getTeam(%targetClient) == Client::getTeam(%playerClient) || Client::getTeam(%targetClient) == -1) && (getObjectType(%object) == "Turret" || getObjectType(%object) == "StaticShape"))
			{
			if(GameBase::getDamageLevel(%object) != 0)
				{
				GameBase::repairDamage(%object, 0.5);
				}			
			}
		if($Eradication::deflagDisarm) {
			if(GameBase::getLOSInfo(%this,3)) {
				if(getObjectType(%object) == "Player" && Client::getTeam(%targetClient) != Client::getTeam(%playerClient) && getObjectType($los::object) == "Player") {
					if(Player::getMountedItem(%targetClient,$FlagSlot) != -1) {
						Player::dropItem(%targetClient, Player::getMountedItem(%targetClient,$FlagSlot));
						playSound(SoundPickupItem,GameBase::getPosition(%object));
					}
					else if(Player::getMountedItem(%targetClient,$WeaponSlot) != -1) {
						Player::dropItem(%targetClient, Player::getMountedItem(%targetClient,$WeaponSlot));
						playSound(SoundPickupItem,GameBase::getPosition(%object));
					}
				}
			}
		}
	}
}

function Player::onLeave(%this, %object)
{
	%playerClient=Player::getClient(%this);
	%targetClient=Player::getClient(%object);
	if(Player::getArmor(%this) == "carmor" && getObjectType(%object) == "Player" && Client::getTeam(%targetClient) == Client::getTeam(%playerClient))
			GameBase::repairDamage(%object, 0);
	if(Player::getArmor(%object) == "carmor" && Client::getTeam(%targetClient) == Client::getTeam(%playerClient))
			GameBase::repairDamage(%object, 0);
	if(Player::getArmor(%this) == "sarmor" &&  (Client::getTeam(%targetClient) == Client::getTeam(%playerClient) || Client::getTeam(%targetClient) == -1) && (getObjectType(%object) == "StaticShape" || getObjectType(%object) =="Turret"))
			GameBase::repairDamage(%object, 0);
}
//------------------------------------

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
//
//---------------------------------------
		Player::blowUp(%player);
//---------------------------------------
//
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
      return;
   }

	%pl = Client::getOwnedObject(%clientId);
	// If mounted to a vehicle then can't mount any other objects
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;

   if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
   {
      return;
   }
   if(GameBase::getControlClient(%objectId) != -1)
   {
      echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
      return;
   }
	%name = GameBase::getDataName(%objectId);
	if(%name != CameraTurret && %name != AutoPlasmaTurret && %name != BlasterTurret && %name != ChaingunTurret && %name != DiscTurret && %name != FusionTurret && %name != GrenadeTurret && %name != LaserTurret)
	   {
	   if(!GameBase::isPowered(%objectId)) 
		{
	      return;
		}
   }

   if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret &&
      !$TestCheats && Player::getMountedItem(%clientId,$BackpackSlot)!="DefenderPack" && Player::getArmor(%clientId)!="carmor") {
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


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
$CorpseTimeoutValue = 100;
//----------------------------------------------------------------------------
// Player & Armor data block callbacks

function Player::onAdd(%this)
{
	GameBase::setRechargeRate(%this,8);
	%this.PStep = 0;
	%this.Overload = 0;
	%this.BRStep = 0;
	%this.overloading = 0;
	schedule("AssignSpec("@ %this @");",2);
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
	GameBase::setAutoRepairRate(%this,0);
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
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
		if(%this.NukeDeployMode == true)
		{
			%this.NukeDeployMode = false;
			deleteObject(%this.markerA);
			deleteObject(%this.markerB);
			deleteObject(%this.markerC);
			deleteObject(%this.markerD);
			%plat = %this.AttachedPad;
			%plat.THHDMounter = "";
		}
      	schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
	      Client::setOwnedObject(%cl, -1);
		if(%this.kamikazied == 0)
		{
		      Client::setControlObject(%cl, Client::getObserverCamera(%cl));
      		Observer::setOrbitObject(%cl, %this, 5, 5, 5);
		}
      	schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
	      %cl.observerMode = "dead";
      	%cl.dieTime = getSimTime();
	}
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if (Player::isExposed(%this))
	{
//		%thisPos = getBoxCenter(%this);
//		%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
//
//		%px = getWord(%pos,0);
//		%py = getWord(%pos,1);
//		%pz = getWord(%pos,2) + %offsetZ;
//
//		%trans = "0 0 0 0 0 0 0 0 0 "@ %px @" "@ %py @" "@ %pz;
//		%vel = %vec * -2;
//		Projectile::spawnProjectile("sniperLaser",%trans,%this,%vel,%this);
//		GameBase::activateShield(%this,%vel,%offsetZ);
//
//		echo(%offsetZ);
//		echo(%trans);
//		echo(%vec);
//		%value = 0;

		%damagedClient = Player::getClient(%this);
		%shooterClient = %object;

		//EARLY ON CONDITIONAL DAMAGE/KICKBACK IGNORES
		if (%type == $NukeDamageType && %this.NukeShieldStrength)
			return;
		if(%type == $ExhaustDamageType && %damagedClient == %shooterClient)
			return;
		if(%this.NukeDeployMode != true)
			Player::applyImpulse(%this,%mom);

		// TK STUFF
		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient))
		{
			if (%shooterClient != -1)
			{
				%curTime = getSimTime();
				if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0)
				{
					if(%type != $MineDamageType)
					{
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
						Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
					}
					else
					{
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
						Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
					}
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

		if (!Player::isDead(%this))
		{
			%armor = Player::getArmor(%this);
			//DAMAGE OFFSETS
			if(Player::getItemCount(%this,"ArmorBuff") > 0)
				%value -= (%value * 0.25);
			if(%damagedClient.isSuperAdmin)
				%value -= (%value * 0.25);
			if(%damagedClient.isAdmin)
				%value -= (%value * 0.125);
			if(%shooterClient.isSuperAdmin)
				%value += (%value * 0.25);
			if(%shooterClient.isAdmin)
				%value += (%value * 0.125);
			if(Player::getItemCount(%this,"NanoBasePack") > 0)
				%value += (%value * 0.5);
			// HEADSHOTS
			if(%vertPos == "head")
			{
				if(%type == $LaserDamageType || %type == $GaussDamageType || %type == $SniperDamageType)
				{
					if(%armor == "harmor")
					{ 
						if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")
						{
							if(%type == $SniperDamageType)
								%value += (%value * 0.65);
							else
								%value += (%value * 0.3);
							%headshot = true;
						}
					}
					else
					{
						if(%type == $SniperDamageType)
							%value += (%value * 0.65);
						else
							%value += (%value * 0.3);
							%headshot = true;
					}
				}
			}
			// EFFECTS
			//If Shield Pack is on
			if (%type != -1 && %this.shieldStrength && %type != $PoisonDamageType)
			{
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				%absorb = %energy * %strength;
				if (%value < %absorb)
				{
					GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
				}
				else
				{
					GameBase::setEnergy(%this,0);
					%value = %value - %absorb;
				}
			}
			// CHECK FOR OTHER FX!
			CheckDamageEffects(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object);

  			if (%value)
			{
				//FINAL DAMAGE AMOUNT CALCULATIONS
				if(!$DamageScale[%armor,%type])
					%damagescale = 1;
				else
					%damagescale = $DamageScale[%armor,%type];
				%value = %damagescale * %value * %friendFire;
				%dlevel = GameBase::getDamageLevel(%this) + %value;
				%spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if(%value == 0)
					%flash = (%mom * 0.01);
				if (%flash > 1.0)
					%flash = 1.0;
				Player::setDamageFlash(%this,%flash);

				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this))
				{
					if(%damagedClient.lastDamage < getSimTime())
					{
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				// The player is dead
				else
				{
					if(%headshot == true)
					{
						%damagedClient.HeadShot = True;
						Client::sendMessage(%shooterClient,2,"Headshot!");
					}
					if(%type == $NukeDamageType)
					{
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
						Player::blowUp(%this);
						%player.BlowdUp = true;
					}
					if(%type == $APShellDamageType || %type == $NukeDamageType)
					{
						%obja = newObject("","Mine","FlameFX");
						addToSet("MissionCleanup", %obja);
						%upPosa = Vector::Add(GameBase::getPosition(%this),"0 0 2.5");
						GameBase::setPosition(%obja,%upPosa);
						%objb = newObject("","Mine","FlameFX");
						addToSet("MissionCleanup", %objb);
						%upPosb = Vector::Add(GameBase::getPosition(%this),"1 0 1.5");
						GameBase::setPosition(%objb,%upPosb);
						%objc = newObject("","Mine","FlameFX");
						addToSet("MissionCleanup", %objc);
						%upPosc = Vector::Add(GameBase::getPosition(%this),"0 1 1.5");
						GameBase::setPosition(%objc,%upPosc);
						%objd = newObject("","Mine","FlameFX");
						addToSet("MissionCleanup", %objd);
						%upPosd = Vector::Add(GameBase::getPosition(%this),"0 -1 1.5");
						GameBase::setPosition(%objd,%upPosd);
						%obje = newObject("","Mine","FlameFX");
						addToSet("MissionCleanup", %obje);
						%upPose = Vector::Add(GameBase::getPosition(%this),"-1 0 1.5");
						GameBase::setPosition(%obje,%upPose);
					}
					if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType || %type == $PMissileDamageType || %type == $IonDamageType || %type == $SmiteDamageType || %type == $KamikazeDamageType || %type == $KamKillDamageType || %type == $FusionDamageType))
					{
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
						Player::blowUp(%this);
						%player.BlowdUp = true;
					}

					if(%player.BlowdUp != true)
					{
						if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType || %type == $PMissileDamageType || %type == $IonDamageType || %type == $SmiteDamageType || %type == $KamikazeDamageType || %type == $KamKillDamageType || %type == $FusionDamageType)) || (Player::getLastContactCount(%this) > 6))
						{
					  		if(%quadrant == "front_left" || %quadrant == "front_right")
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if( Player::isCrouching(%this))
							%curDie = $PlayerAnim::Crouching;							
						else if(%vertPos=="head")
						{
							if(%quadrant == "front_left" || %quadrant == "front_right")
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
						  	else 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if(%vertPos == "torso")
						{
							if(%quadrant == "front_left") 
								%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "front_right") 
								%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
							else if(%quadrant == "back_left" ) 
								%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "back_right") 
								%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						}
						else if (%vertPos == "legs")
						{
							if(%quadrant == "front_left" ||	%quadrant == "back_left") 
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" ||	%quadrant == "back_right") 
								%curDie = $PlayerAnim::DieLegRight;
						}
						Player::setAnimation(%this, %curDie);
					}
					if(%type == $ImpactDamageType && %object.clLastMount != "")  
						%shooterClient = %object.clLastMount;
					Client::onKilled(%damagedClient,%shooterClient, %type);
				}
			}
		}
	}
}
echo("TALON:ONDAMAGE IS OK");

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Player::onCollision(%this,%object)
{
	if (Player::isDead(%this))
	{
		if (getObjectType(%object) == "Player")
		{
			// Transfer all our items to the player
			%sound = false;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1)
			{
				%count = Player::getItemCount(%this,%i);
				if(%count)
				{
					%delta = Item::giveItem(%object,getItemData(%i),%count);
					if (%delta > 0)
					{
						Player::decItemCount(%this,%i,%delta);
						%sound = true;
					}
				}
			}
			if (%sound)
			{
				playSound(SoundPickupItem,GameBase::getPosition(%this));
			}
		}
	}
	else if(GameBase::getTeam(%this) != GameBase::getTeam(%object) && getObjectType(%object) == "Player")
	{
		%armor = Player::getArmor(%object);
		if(%armor == "tarmor")
		{
			playSound(SoundTeleportOpen,GameBase::getPosition(%this));
			%vel = -100;
			%vec = 60;
			%rotation = GameBase::getRotation(%object);
			%fly = Vector::getFromRot(GameBase::getRotation(%object),%vel,%vec);
			Player::applyImpulse(%this,%fly);
		}
	}
	if(getObjectType(%this) == "Player")
		%client = Player::getClient(%this);
	else if(!Player::isDead(%object) && getObjectType(%object) == "Player" && %client.Smiter != 0)
	{
		if(GameBase::getTeam(%this) != GameBase::getTeam(%object) || %client.Smiter == 2)
			GameBase::applyDamage(%object,$SmiteDamageType,999,GameBase::getPosition(%object),"0 0 0","0 0 0",%client);
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
	if(%objectId == -1)
	{
		return;
	}
	%pl = Client::getOwnedObject(%clientId);
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
	if(%name != CameraTurret && %name != DeployableTurret && %name != PlasticExplosive && %name != ACameraTurret && %name != ALaserTurret && %name != ATLaser)
	{
		if(!GameBase::isPowered(%objectId)) 
		{
			echo("Turret " @ %objectId @ " not powered.");
			Client::SendMessage(%clientId,1,"Turret has no power");
			return;
		}
	}
	if(%name == LaserTurret)
	{
		Client::SendMessage(%clientId,1,"You can't control that type of turret manually~Error_Message.wav");
		return;
	}
	%player = Client::getOwnedObject(%clientId);
	if((Client::getOwnedObject(%clientId)).CommandTag || GameBase::getDataName(%objectId) == CameraTurret || GameBase::getDataName(%objectId) == PlasticExplosive || GameBase::getDataName(%objectId) == ACameraTurret || $TestCheats || Player::getMountedItem(%player,$BackpackSlot) == Laptop)
	{
   		Client::setControlObject(%clientId, %objectId);
   		Client::setGuiMode(%clientId, $GuiModePlay);
	}
	else
		Client::SendMessage(%clientId,1,"Must be at a Command Station to control turrets.");
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

//----------------------------------------------------------------------------
//Used JUST for the AdminGun - ripped from *IX*Savage1's awesome Insomnaix Mod - Not really used right now (Wrath not finished)
function ixDotProd(%vec, %scalar)
{
	%return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %return;
}

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//
//DAMAGE EFFECTS
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
echo("safe up to the check");
function CheckDamageEffects(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	%damagedClient = Player::getClient(%this);
	%shooterClient = %object;
	// Energy Overload ^
	if (Player::getArmor(%this) == tarmor && %type == $IonDamageType && ((Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient) || $Server::TeamDamageScale > 0) || %damagedClient == %shooterClient))
	{
		%attackername = Client::getName(%shooterclient);
		Client::sendMessage(%damagedClient,1,"ALERT: Energy overload caused by "@ %attackername @"'s Ion Burst!");
		%flash = 0.95;
		Player::setDamageFlash(%this,%flash);
		playSound(SoundPackFail,GameBase::getPosition(%this));
		EnergyOverload(%damagedClient, %this);
	}
	// EMP effect
	if (%type == $EMPDamageType && ((Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient) || $Server::TeamDamageScale > 0) || %damagedClient == %shooterClient))
	{
		%attackername = Client::getName(%shooterclient);
		Client::sendMessage(%damagedClient,1,"ALERT: Energy overload caused by "@ %attackername @"'s EMP!");
		%flash = 0.20;
		Player::setDamageFlash(%this,%flash);
		playSound(SoundPackFail,GameBase::getPosition(%this));
		EnergyOverload(%damagedClient, %this);
	}
	// Distortion effect
	if (%type == $DisruptionDamageType && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient))
	{
		Client::sendMessage(%damagedClient,1,"ALERT: Disruption detected!");
		GameBase::startFadeOut(%this);
		%cr = Player::getSensorSupression(%this);
		%rn = %cr + 20;
		Player::setSensorSupression(%this,%rn);
		schedule("GameBase::startFadeIn(" @ %this @ ");",10,%this);
		schedule("Player::setSensorSupression(" @ %this @ ","@ %cr @");",10,%this);

	}
	// Bore effect
	if (%type == $BoreDamageType && ((Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient) || $Server::TeamDamageScale > 0) || %damagedClient == %shooterClient) && (!%this.shieldStrength || Player::getArmor(%this) == "tarmor"))
	{
		if(!%this.shieldStrength || Player::getArmor(%this) == "tarmor")
		{
			if(%value > 0.001)
				%wasbored = 1;
			else
				%wasbored = 0;
			%flash = 0.99;
			Player::setDamageFlash(%this,%flash);
			playSound(SoundPackFail,GameBase::getPosition(%this));
			%this.LastBore = %shooterClient;
			BoreStart(%damagedClient, %this, %wasbored);
		}
	}
	// Poison effect
	if (%type == $ChemDamageType && ((Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient) || $Server::TeamDamageScale > 0) || %damagedClient == %shooterClient) && (!%this.shieldStrength || GameBase::getEnergy(%this) == 0))
	{
		%flash = 0.45;
		Player::setDamageFlash(%this,%flash);
		playSound(SoundPackFail,GameBase::getPosition(%this));
		%this.Poisoner = %shooterClient;
		PoisonStart(%damagedClient, %this);
	}
	// Red glow from radiation
	if(%type == $RadiationDamageType)
		DoRadiationFX(%damagedClient,%this,0);
	// Self-Destruct
	if(%type == $SetDestructDamageType)
		THDestruct(%damagedClient,%this);
	// Disarming effect
	if (%type == $DisarmDamageType && ((Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient) || $Server::TeamDamageScale > 0) || %damagedClient == %shooterClient))
	{
		%weapon = Player::getMountedItem(%damagedClient,$WeaponSlot);
		if(%weapon != RepairGun && %weapon != Detonator && %weapon != JumpGun && %weapon != Lathe && %weapon != "")
		{
			%ridx = floor(getRandom() * (10 - 0.01));
			if(%ridx < 3)
			{
				%flash = 0.10;
				Player::setDamageFlash(%damagedClient,%flash);
				playSound(SoundPackFail,GameBase::getPosition(%damagedClient));
				Player::dropItem(%this, %weapon);
				%obj = newObject("","Mine","EMPBurst");
				addToSet("MissionCleanup", %obj);
				%upPos = Vector::Add(GameBase::getPosition(%player),"0 0 3");
				GameBase::setPosition(%obj,%upPos);
			}
		}
	}
	// Target locking
	if (%type == $PaintDamageType)
	{
		if(%this.PaintCount == "")
			%this.PaintCount = 0;

		%this.PaintCount++;
		echo(%this.PaintCount);

		if(%this.PaintCount == 5)
		{
			%this.PaintCount = 0;
			%shooterClient.target = %this;
			Client::sendMessage(%shooterClient,3,"Lock acquired!");
			FireLockOn(%shooterclient,%this);
			Client::sendMessage(%damagedClient,1,"Lock detected!");
		}
	}
}
echo("check function ok");

// Overloading Energons/EMP blast
function EnergyOverload(%clientId, %player)
{
	if(%player.overload == 0 || %player.overload == "")
	{
		GameBase::setEnergy(%player,0);
		GameBase::setRechargeRate(%player,0);
		%player.overload = 5;
		CheckOverload(%clientId, %player);
	}
	else
		%clientId.overload += 1;
}

// Checkup on the Overload's status.
function CheckOverload(%clientId, %player)
{
	if(%player.overload > 0)
	{
		%player.overload--;
		schedule("CheckOverload(" @ %clientId @ ", " @ %player @ ");",2,%player);
		%obj = newObject("","Mine","EMPBurst");
		addToSet("MissionCleanup", %obj);
		%upPos = Vector::Add(GameBase::getPosition(%player),"0 0 2.5");
		GameBase::setPosition(%obj,%upPos);
	}
	else
	{
		Client::sendMessage(%clientId,3,"Energy systems have returned to normal.");
		if(%clientId.cloacked == 0)
			GameBase::setRechargeRate(%player,8);
	}			
}

//----------------------------------------------------------------------------
// Poisoning
function PoisonStart(%clientId,%player)
{
	if(%player.PStep == 0)
	{
		%attackername = Client::getName(%player.Poisoner);
		%player.PStep = 30;
		PDamStep(%clientId, %player);
		Client::sendMessage(%clientId,1,"You've been attacked by "@ %attackername @"'s deadly neurotoxins!~wAccess_Denied.wav");
	}
	else
		%player.PStep += 20;
}

function PDamStep(%clientId,%player)
{
	if(%player.PStep > 0)
	{
		%player.PStep--;
		GameBase::applyDamage(%player,$PoisonDamageType,0.1,GameBase::getPosition(%player),"0 0 0","0 0 0",%player.Poisoner);
		schedule("PDamStep(" @ %clientId @ ", " @ %player @ ");",1,%player);
	}
	else
		Client::sendMessage(%clientId,3,"The toxins have been neutralized.");
}

//-------------------------------------
//|***********************************|
//|* In all it's glory - THDESTRUCT! *|
//|***********************************|
//-------------------------------------
echo("TALON:GETTING UP TO THDESTRUCT");

function THDestruct(%client,%player)
{
	// Start it off
	Client::sendMessage(%clientId,1,"!!!!*****REACTOR SELF-DESTRUCT SEQUENCE INITIATED*****!!!!~wAccess_Denied.wav");
	GameBase::setEnergy(%player,0);
	GameBase::setRechargeRate(%player,0);

	// Make the little blue "pops"
	for(%i = 0; %i < 30; %i++)
	{
		%b = TFunc::Rand(6);
		%oa = TFunc::Rand(9);
		%oa *= 0.1;
		%ob = TFunc::Rand(9);
		%ob *= 0.01;
		%fo = %oa + %ob;
		%b -= %fo;
		echo(%b);
		schedule("THDestructPop(" @ %player @ ");",%b,%player);
	}

	// Create the big shockwaves
	%btime = 2.1;
	%step = 0;
	for(%i = 0; %i < 30; %i++)
	{
		%step++;
		if(%btime <= 4.5)
			%btime += 0.4;
		echo(%btime);
		schedule("THDestructShock(" @ %player @ ","@ %step @");",%btime,%player);
	}
//	schedule("THDestructShock(" @ %player @ ",8);",4.5,%player);

	// Final explosion/damaging part
	schedule("THDestructMort(" @ %player @ ","@%client@");",4.5,%player);
}

function THDestructShock(%player,%dist)
{
	if(%dist == 1)
		%rdist = "0 0 5";
	if(%dist == 2)
		%rdist = "0 0 15";
	if(%dist == 3)
		%rdist = "0 0 25";
	if(%dist == 4)
		%rdist = "0 0 35";
	if(%dist == 5)
		%rdist = "5 0 10";
	if(%dist == 6)
		%rdist = "0 5 10";
	if(%dist == 7)
		%rdist = "-5 0 10";
	if(%dist == 8)
		%rdist = "0 -5 10";
	%upPos = Vector::Add(GameBase::getPosition(%player),%rdist);
	TFunc::SpawnFX(%upPos,GameBase::getTeam(%player),"FsnShk");
}

function THDestructPop(%player)
{
	%rdist = TFunc::GetRandomOffset(GameBase::getPosition(%player),6,6,false);
	%upPos = Vector::Add(GameBase::getPosition(%player),%rdist);
	TFunc::SpawnFX(%upPos,GameBase::getTeam(%player),"FsnPop");
}

function THDestructMort(%player,%client)
{
	%obj = newObject("","Mine","FsnMort");
	addToSet("MissionCleanup", %obj);
	%Pos = GameBase::getPosition(%player);
	GameBase::setPosition(%obj,%Pos);
	calcOwnedRadiusDamage(%player,$FusionDamageType,20,2,5,300,5,999,3,100,1,%client);
}

//----------------------------------------------------------------------------
// Cerebral Bore effects
function BoreStart(%clientId,%player,%wasbored)
{
	%armor = Player::getArmor(%player);
	%sdchance = floor(getRandom() * (2 - 0.01));
	echo("BORE on "@ Client::getName(%clientId) @" rolled a "@ %sdchance);
	if((%sdchance == 0 && (%player.overloading == 0 && %armor == "tarmor")) || %wasbored == 0)
	{
		echo("BORE roll succeeded &  "@ Client::getName(%clientId) @" was in energon... self d'ing");
		%player.overloading = 1;
		if(%wasbored == 1)
			Client::sendMessage(%clientId,1,"WARNING! THE CEREBRAL BORE HAS ACTIVATED THE SELF-DESTRUCT SEQUENCE!!!~wAccess_Denied.wav");
		else if(%wasbored == 0)
			Client::sendMessage(%clientId,1,"WARNING! YOU HAVE ACTIVATED THE SELF-DESTRUCT SEQUENCE!!!~wAccess_Denied.wav");
		THDestruct(%clientId,%player);
		return;
	}
	if(%player.BrStep == 0)
	{
		echo("BORE roll failed or  "@ Client::getName(%clientId) @" was in correct armor");
		%attackername = Client::getName(%player.LastBore);
		%player.BrStep = 30;
		BorAtkStep(%clientId, %player);
		Client::sendMessage(%clientId,1,"You're bieng attacked by "@ %attackername @"'s cerebral bore!!!~wAccess_Denied.wav");
		GameBase::setEnergy(%player,0);
	}
	else
		%player.BrStep += 30;
}

echo("TALON:BORE ATTACK STARTING WORKS");

function BorAtkStep(%clientId,%player)
{
	if(%player.BrStep > 0)
	{
		%flash = 0.99;
		Player::setDamageFlash(%player,%flash);

		%player.BrStep --;
		GameBase::applyDamage(%player,$BoreDmgDamageType,0.025,GameBase::getPosition(%player),"0 0 0","0 0 0",%player.LastBore);

		schedule("BorAtkStep(" @ %clientId @ ", " @ %player @ ");",0.5,%player);

		%upPos = Vector::Add(GameBase::getPosition(%player),"0 0 2.5");
		TFunc::SpawnFX(%upPos,GameBase::getTeam(%player),"EMPBurst");

		%rot = GameBase::getRotation(%player);
		%rand = floor(getRandom() * (1.25 + 0.01));
		echo(%rand);
		%negrand = floor(getRandom() * (2 - 0.01));
		if(%negrand == 0)
			%finalrand = (%rand * -1);
		else
			%finalrand = %rand;
		%newvec = "0 0 "@ %finalrand;
		%newrot = Vector::add(%rot, %newvec);
		GameBase::setRotation(%player,%newrot);

		%soundrand = floor(getRandom() * (2 - 0.01));
		if(%soundrand == 0)
			playSound(SoundBoreShock,GameBase::getPosition(%player));
		else
			playSound(SoundFirePlasma,GameBase::getPosition(%player));

	}
	else
		Client::sendMessage(%clientId,3,"The bore's attack has ended.");
}

//----------------------------------------------------------------------------
// red glowing from radiation
echo("Z");
function DoRadiationFX(%clientId,%player,%step)
{
	if(%step == 0)
	{
		%flash = 0.01;
		Player::setDamageFlash(%player,%flash);
		schedule("DoRadiationFX(" @ %clientId @ ", " @ %player @ ",1);",0.5,%player);
	}
	else if(%step < 60)
	{
		%flash = 0.01 + (%step / 100);
		Player::setDamageFlash(%player,%flash);
		%step++;
		schedule("DoRadiationFX(" @ %clientId @ ", " @ %player @ ","@ %step @");",0.5,%player);
	}
}

function BuildUpFlash(%player,%length,%step,%max)
{
	if(%step == "")
	{
		%flash = 0.01;
		Player::setDamageFlash(%player,%flash);
		schedule("BuildUpFlash(" @ %player @ ", " @ %length @ ",1,"@ %max @");",0.5,%player);
	}
	else if(%step < %length && %step > 0)
	{
		%flash = (%step * (%max / %length));
		Player::setDamageFlash(%player,%flash);
		%step++;
		schedule("BuildUpFlash(" @ %player @ ", " @ %length @ ","@ %step @","@ %max @");",0.5,%player);
	}
}


function AssignSpec(%this)
{
	%client = Player::getClient(%this);
	echo("TALON:"@ %client @" now having spec changed from "@ $ArmorSpec[%client] @" to be "@ $SpecPending[%client]);
	$ArmorSpec[%client] = $SpecPending[%client];
	$RealSpec[%client] = $SpecPending[%client];
	if($ArmorSpec[%client] == Energy)
		GameBase::setRechargeRate(%this,14);
	if($ArmorSpec[%client] == Autoheal)
	{
		%rate = 0.01;
		GameBase::setAutoRepairRate(%this,%rate);
	}
	if($SpecPending[%client] == Jamming)
	{
		%rate = Player::getSensorSupression(%this) + 20;
		Player::setSensorSupression(%this,%rate);
	}
}

//heh you know what I mean
echo("Loading Screaming Fist Version");
//----------------------------------------------------------------------------
// TURRET DYNAMIC DATA

TurretData RocketTurret
{
	maxDamage = 8.0;
	maxEnergy = 50;
	minGunEnergy = 10;
	maxGunEnergy = 10;
	range = 250;
	gunRange = 350;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "missileturret";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = TurretMissile;
	reloadDelay = 0.5;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "Rocket Turret";
};

function RocketTurret::onAdd(%this)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,2);
}

function RocketTurret::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,2);
	}
	else {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
	}
	GameBase::setActive(%this,%power);
}

function RocketTurret::verifyTarget(%this,%target)
{
	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
		return "True";
	else
		return "False";
}

function RocketTurret::onPower(%this,%power,%generator)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,2);
}

function RocketTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,2);
	GameBase::setActive(%this,true);
}

//***********************************************************************************
// SF ADDITION - 8/11/99 - 10:00PM
//***********************************************************************************

TurretData HowitzerTurret
{
	maxDamage = 10.0;
	maxEnergy = 14;
	minGunEnergy = 1;
	maxGunEnergy = 1;
	reloadDelay = 2.0;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "howitzer";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = NoProjectile;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Howitzer";
};

function HowitzerTurret::onAdd(%this)
{
	$HowitzerReload[%this] = FALSE;
	GameBase::setRechargeRate(%this,0);
}

function HowitzerTurret::onFire(%this)
{
	%totEnergy = GameBase::getEnergy(%this);
	
	if( $HowitzerReload[%this] != TRUE && %totEnergy > 1)
	{
		%trans = GameBase::getMuzzleTransform(%this);
		%vel = Item::getVelocity(%this);
		%client = GameBase::getControlClient(%this);
		
		if( $HowitzerShell[%client] == "Mine" )
		{
			%value = 2;
			$HowitzerId = %this;
			Projectile::spawnProjectile("MineMortarShell",%trans,%this,%vel);
		}
		else
		{
			%value = 1;
			Projectile::spawnProjectile("MortarTurretShell",%trans,%this,%vel);
		}
		
		GameBase::playSound(%this , SoundMortarTurretFire, 0);
		$HowitzerReload[%this] = TRUE;
		schedule("$HowitzerReload["@%this@"] = FALSE;", 4.0);
		
		//energy stuff
		%newEnergy = %totEnergy - %value;
		if( %newEnergy < 0)
			%newEnergy = 0;
		GameBase::setEnergy(%this, %newEnergy);
	}
}

function HowitzerTurret::onPower(%this,%power,%generator)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
}

function HowitzerTurret::onPower(%this,%power,%generator) {}
function HowitzerTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,0);
	GameBase::setActive(%this,true);
}
//--------------------------------------------

TurretData BigCannonTurret
{
	maxDamage = 10.0;
	maxEnergy = 140;
	minGunEnergy = 1;
	maxGunEnergy = 1;
	reloadDelay = 0.25;
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	range = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "30mm";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = BigCannonShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "30mm Cannon";
};

function BigCannonTurret::onAdd(%this)
{
	GameBase::setRechargeRate(%this,0);
	%this.shieldStrength = 0;
}

function BigCannonTurret::onPower(%this,%power,%generator)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
}

function BigCannonTurret::onPower(%this,%power,%generator) {}
function BigCannonTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,0);
	GameBase::setActive(%this,true);
}
//--------------------------------------------

TurretData IndoorTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = MachinegunBullet;
	maxDamage = 2.5;
	maxEnergy = 240;
	minGunEnergy = 2;
	maxGunEnergy = 1;
	reloadDelay = 0.08;
	speed = 3.0;
	speedModifier = 0.8;
	range = 25;
	visibleToSensor = true;
	dopplerVelocity = 0.5;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	fireSound = SoundFireMachinegun;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "Indoor Turret";
	
};

function IndoorTurret::onAdd(%this)
{
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0;
}

function IndoorTurret::onPower(%this,%power,%generator)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,10);
}

//--------------------------------------------

TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "Lsentry";
	projectileType = MachinegunBullet;
	maxDamage = 0.8;
	maxEnergy = 120;
	minGunEnergy = 2;
	maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.10;
	speed = 2.0;
	speedModifier = 1.0;
	range = 30;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 1.5;
   	castLOS = true;
   	supression = false;
	supressable = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	fireSound = SoundFireMachinegun;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Sentry Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableTurret::onAdd(%this)
{
	$AmmoTossAnim[%this] = FALSE;
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,0);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Sentry Turret");
	}
}

function DeployableTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--;
}

// Override base class just in case.
function DeployableTurret::onPower(%this,%power,%generator) {}
function DeployableTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,0);
	GameBase::setActive(%this,true);
}	

//--------------------------------------------

TurretData GRoCTurret
{
	className = "Turret";
	shapeFile = "flak";
	projectileType = NoProjectile;
	maxDamage = 0.8;
	maxEnergy = 120;
	minGunEnergy = 2;
	maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.10;
	speed = 2.0;
	speedModifier = 1.0;
	range = 200;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 1.5;
   	castLOS = true;
   	supression = false;
	supressable = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	fireSound = SoundDryFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "GRoC Cannon";
	damageSkinData = "objectDamageSkins";
};

function GRoCTurret::onAdd(%this)
{
	$AmmoTossAnim[%this] = FALSE;
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,2);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "GRoC Cannon");
	}
}

function GRoCTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function GRoCTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function GRoCTurret::onDestroyed(%this)
{
	$GRoCCannonEnabled[%this] = false;
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "GRoCCannon"]--;
}

// Override base class just in case.
function GRoCTurret::onPower(%this,%power,%generator) {}
function GRoCTurret::onEnabled(%this) 
{
	$GRoCCannonEnabled[%this] = true;
	schedule("GRoCTurret::ShootFlare("@%this@");", 2, %this);
	GameBase::setRechargeRate(%this,2);
	GameBase::setActive(%this,true);
}

function GRoCTurret::onDisabled(%this) 
{
	$GRoCCannonEnabled[%this] = false;
	GameBase::setRechargeRate(%this,0);
	GameBase::setActive(%this,true);
}

function GRoCTurret::ShootFlare(%this)
{
	if( $GRoCCannonEnabled[%this] == true )
	{
		%set = newObject("set",SimSet);
		%number = containerBoxFillSet(%set, $VehicleObjectType, GameBase::getPosition(%this), 400, 400, 400, 0);
		
		if( %number > 0 )
		{
			%trans = GameBase::getMuzzleTransform(%this);
			%vel = Item::getVelocity(%this);
			
			//The function to get the Missile from Set
			for( %i = 0; %i < %number; %i++ )
			{
				%object = Group::getObject(%set, %i);
				//echo("%object ",%object);
				%name = GameBase::getDataName(%object);
				//echo("%name ",%name);
				if( %name == "FBWRocket" && GameBase::getTeam(%this) != GameBase::getTeam(%object) )
				{
					%target = %object;
					break;
				}
				else
					%target = 0;
			}
			//echo("%target ",%target);
			if( %target != 0 )
			{
				GameBase::playSound(%player , SoundFireFlierRocket, 0);
				Projectile::spawnProjectile("HomingFlare",%trans,%this,%vel,%target);
			}
		}
		
		deleteObject(%set);
		schedule("GRoCTurret::ShootFlare("@%this@");", 2, %this);
	}
}	
//***********************************************************************************
// SF Additions - End
//***********************************************************************************

//--------------------------------------------

TurretData CameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 0.25;
	maxEnergy = 10;
	speed = 20;
	speedModifier = 1.0;
	range = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = defaultDebrisSmall;
	FOV = 0.707;
	pinger = false;
	explosionId = debrisExpMedium;
	description = "Camera";
};

function CameraTurret::onAdd(%this)
{
	schedule("CameraTurret::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Camera");
	}
}

function CameraTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function CameraTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function CameraTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "CameraPack"]--;
}	


//---------------------------------------------------

function Turret::onAdd(%this)
{
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Turret");
	}
}

function Turret::onActivate(%this)
{
	GameBase::playSequence(%this,0,power);
}

function Turret::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
	Turret::checkOperator(%this);
}

function Turret::onSetTeam(%this,%oldTeam)
{
	if(GameBase::getTeam(%this) != Client::getTeam(GameBase::getControlClient(%this))) 
		Turret::checkOperator(%this);
	
}

function Turret::checkOperator(%this)
{
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1)
		if(GameBase::getDataName(%this) == "HowitzerTurret" || GameBase::getDataName(%this) == "BigCannonTurret")
			Turret::dismount(%this, 10);
		else
			Turret::changeControl(%this);
}

function Turret::changeControl(%this)
{
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1)
	{
		%pl = Client::getOwnedObject(%cl);
		Player::setMountObject(%pl, -1,0);
		Client::setControlObject(%cl, %pl);
	}
}

function Turret::onPower(%this,%power,%generator)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	GameBase::setActive(%this,%power);
}

function Turret::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) {
		%this.shieldStrength = 0.0;
		GameBase::setRechargeRate(%this,0);
		GameBase::setActive(%this,true);
	}
}

function Turret::onDisabled(%this)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
}

function Turret::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	Turret::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 
		0.1, 200, 100); 
}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%team = GameBase::getTeam(%this);
	
	if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS = 1;
	//*************************************************************************************************************
	// SF Addition - Begin - 7/19/99 - 3:30AM
	//*************************************************************************************************************
	if(%type == $MAWIncendiaryRifleDamageType)
	{
		//echo("$IncenDamageClient - Turret onDamage ",$IncenDamageClient);
		%object = $IncenDamageClient;
		//echo("%object - Turret onDamage ",%object);
	}
	else if(%type == $FBWMissleDamageType)
	{
		%object = $FBWClientIDonRemove;
		//echo("%object - Turret onDamage ",%object);
		%value = 2.0;
	}
	else
	{
		%currentDamage = GameBase::getDamageLevel(%this);
		%name = GameBase::getDataName(%this);
		%maxDam = %name.maxDamage * 0.15;
		//echo("%maxDam ",%maxDam);
		if( %currentDamage <= %maxDam)
		{
			if(%type == $ShotgunDamageType || %type == $MAWIncendiaryRifleDamageType
				|| %type == $MAWAssRifleDamageType || %type == $SilencedGlockDamageType
				|| %type == $SilencedAssRifleDamageType || %type == $SilencedAssRifleDamageType
				|| %type == $GlockDamageType || %type == $OspreyTurretDamageType 
				|| %type == $SniperRifleDamageType || %type == $AssRifleDamageType
				|| %type == $MinigunDamageType || %type == $ComancheBulletDamageType
				|| %type == $FlashDamageType)
			{
				%value = %value * 0.05;
			}
			else
				if(%type == $MineDamageType || %type == $MissileDamageType 
					|| %type == $ExplosionDamageType)
				{
					%value = %value * 0.35;
				}
		}
	}
	//*************************************************************************************************************
	// SF Addition - End
	//*************************************************************************************************************
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		if(%name != DeployableTurret && %name != CameraTurret )	
			%TDS = $Server::TeamDamageScale;
	}
	StaticShape::onDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
}

function Turret::onControl (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
}

//***********************************************************************************
//       OLD TURRET DISMOUNT CODE :)
//***********************************************************************************
//function Turret::onDismount (%this, %object)
//{
//	%client = Player::getClient(%object);
//	Client::sendMessage(%client,0,"Leaving turret " @ %this);
//	unFocus(%object, %this);
//}
//***********************************************************************************
//    NEW turret dismount code
//***********************************************************************************
function Turret::jump(%this,%mom)
{
	if(GameBase::getDataName(%this) == "HowitzerTurret" || GameBase::getDataName(%this) == "BigCannonTurret")
		Turret::dismount(%this, %mom);
	else
		Turret::changeControl(%this);
}

function Turret::dismount(%this,%mom)
{
	//echo("Dismount called");
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1)
	{
		%pl = Client::getOwnedObject(%cl);
		%armor = Player::getArmor(%pl);
		if(%armor == "somale" || %armor == "sofemale") {
			%height = 1;
			%velocity = 1;
			%zVec = 1;
		}
		else if(%armor == "cmmale" || %armor == "cmfemale") {
			%height = 1;
			%velocity = 1;
			%zVec = 1;
		}
		else if(%armor == "imale" || %armor == "ifemale") {
			%height = 1;
			%velocity = 1;
			%zVec = 1;
		}
		else if(%armor == "himale" || %armor == "hifemale") {
			%height = 1;
			%velocity = 1;
			%zVec = 1;
		}
		%pos = GameBase::getPosition(%pl);
		%posX = getWord(%pos,0);
		%posY	= getWord(%pos,1);
		%posZ	= getWord(%pos,2);
		
		if(GameBase::testPosition(%pl,%posX @ " " @ %posY @ " " @ (%posZ + %height)))
		{	
			%pl.lastMount = %this;
			%pl.newMountTime = getSimTime() + 3.0;
			//Player::setMountObject(%pl, -1,0);
			%rotZ = getWord(GameBase::getRotation(%pl),2);
			GameBase::setRotation(%pl, "0 0 " @ %rotZ);
			GameBase::setPosition(%pl,%posX @ " " @ %posY @ " " @ (%posZ + %height));
			
			Client::setControlObject(%cl, %pl);
			$turretControlled[%this] = FALSE;
			playSound(soundFlyerDismount, GameBase::getPosition(%pl));
			if(%pl.lastWeapon != "") 
			{
				Player::useItem(%pl,%pl.lastWeapon);		 	
				%pl.lastWeapon = "";
				//unfocus(%object, %this);
			}
			%pl.driver = "";
			%pl.turret = "";
			
			%jumpDir = Vector::getFromRot(GameBase::getRotation(%pl),%velocity,%zVec);
			Player::applyImpulse(%pl,%jumpDir);
		}
		else
			Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
	}
}

//***********************************************************************************
//              SF Addition - Mountable Turrets
//              Started Monday May, 10, 1999 - 8:49 am EST
//              I think ive indented ok so its easy enuf to follow....
//              YAHOO it works, just gotta do the unmount code...being stuff is no good
//			
//			Just redid the commenting.  Strange stuff going on here.
//			5/23/99 - 2:00 AM
//			-Hosed
//***********************************************************************************
function Turret::onCollision (%this, %object)
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage)
	{
		if(GameBase::getDataName(%this) == "HowitzerTurret" || GameBase::getDataName(%this) == "BigCannonTurret")
		{
			%client = Player::getClient(%object);
			if( GameBase::getDamageState(%this) == "Enabled" )
			{
				if(GameBase::getTeam(%this) == GameBase::getTeam(%object) || $NoneTeamAccess[%this] == TRUE)
				{
					if( !$turretControlled[%this] == TRUE)
					{
						if(getObjectType (%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
						{
							if( Player::isAiControlled(%object))
								return;
							
							%armor = Player::getArmor(%object);
							
							%weapon = Player::getMountedItem(%object,$WeaponSlot);
							if(%weapon != -1)
							{
								%object.lastWeapon = %weapon;
								Player::unMountItem(%object,$WeaponSlot);
							}
							//Player::setMountObject(%object, %this, 0);
							%pos = GameBase::getPosition(%this);
							%rot = GameBase::getRotation(%this);
							if( GameBase::getDataName(%this) == "HowitzerTurret" )
							{
								%playerpos = Vector::getFromRot(%rot, -8);
							}
							else if( GameBase::getDataName(%this) == "BigCannonTurret" )
							{
								%playerpos = Vector::getFromRot(%rot, -7.5);
							}
							%playerpos = Vector::add(%playerpos , %pos);
							GameBase::setPosition(%object, %playerpos);
							GameBase::setRotation(%object, %rot);
							
							Client::setControlObject(%client, %this);	
							$turretControlled[%this] = TRUE;
							playSound(soundFlyerMount, GameBase::getPosition(%this));
							%object.driver= 1;
							%object.vehicle = %this;
							%this.clLastMount = %client;

							//Recursive check for when people leave by not jumping
							schedule("Turret::AmIControlled("@%this@");", 6.0, %this);
						}
					}
				}
				else
					Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
			}
			else
				Client::sendMessage(%client,0,"Unit is disabled");
		}
	}
}

function Turret::AmIControlled(%this)
{
	if( $turretControlled[%this] == TRUE )
	{
		if( GameBase::getControlClient(%this) == -1 )
			$turretControlled[%this] = FALSE;
		else
			schedule("Turret::AmIControlled("@%this@");", 6.0, %this);
	}
}
//***********************************************************************************************
//          SF Addition END
//***********************************************************************************************

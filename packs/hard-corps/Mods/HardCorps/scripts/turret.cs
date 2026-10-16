//----------------------------------------------------------------------------
// TURRET DYNAMIC DATA

TurretData PlasmaTurret
{
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	reloadDelay = 0.8;
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 50;
	gunRange = 100;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "hellfiregun";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = FusionBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Plasma Turret";
};
																						 
TurretData ELFTurret	   
{			 
	maxDamage = 1.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 40;
	gunRange = 50;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "ELF Turret";
	shapeFile = "chainturret";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = turretCharge;
	reloadDelay = 0.3;
	explosionId = LargeShockwave;
	description = "ELF Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;
};

TurretData RocketTurret
{
	maxDamage = 0.75;
	maxEnergy = 100;
	minGunEnergy = 60;
	maxGunEnergy = 60;
	range = 150;
	gunRange = 300;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "missileturret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = TurretMissile;
//	reloadDelay = 3.5;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
//	whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
   targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "Rocket Turret";
};

function RocketTurret::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,14);
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
	{
		if(%this.empeffect == 0 && %target.jamdetect != "true") return "True";
	} else
	{
	      return "False";
	}
}

//--------------------------------------------

TurretData MortarTurret
{
	maxDamage = 1.0;
	maxEnergy = 45;
	minGunEnergy = 45;
	maxGunEnergy = 100;
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
	shapeFile = "mortar_turret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = MortarTurretShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Mortar Turret";
};
																						 
//--------------------------------------------

TurretData IndoorTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = MiniFusionBolt;
	maxDamage = 2.5;
	maxEnergy = 60;
	minGunEnergy = 20;
	maxGunEnergy = 6;
	reloadDelay = 0.4;
	speed = 5.0;
	speedModifier = 1.0;
	range = 25;
	gunRange = 50;
	visibleToSensor = true;
	dopplerVelocity = 2;
	castLOS = true;
	supression = false;
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundEnergyTurretFire;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "Indoor Turret";

};


//--------------------------------------------

TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = MiniFusionBolt;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 20;
	gunRange = 40;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Remote Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	%this.empeffect = 0;
	//if (GameBase::getMapName(%this) == "") {
	//	GameBase::setMapName (%this, "Remote Turret");
	//}
}

function DeployableTurret::verifyTarget(%this,%target)
{
	if(%this.empeffect == 0 && %target.jamdetect != "true") return "True"; else return "False";
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
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//--------------------------------------------

TurretData DeployableHeavyTurret
{
	className = "Turret";
	shapeFile = "chainturret";
	projectileType = HeavyTurretAttack;
	maxDamage = 1.0;
	maxEnergy = 100;
	minGunEnergy = 3;
	maxGunEnergy = 4;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.2;
	speed = 4.0;
	speedModifier = 1.5;
	range = 30;
	gunRange = 60;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Heavy Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableHeavyTurret::onAdd(%this)
{
	schedule("DeployableHeavyTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.016;
	%this.empeffect = 0;
	//if (GameBase::getMapName(%this) == "") {
	//	GameBase::setMapName (%this, "Remote Heavy Turret");
	//}
}

function DeployableHeavyTurret::verifyTarget(%this,%target)
{
	if(%this.empeffect == 0 && %target.jamdetect != "true") return "True"; else return "False";
}

function DeployableHeavyTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableHeavyTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableHeavyTurret::onDestroyed(%this)
{
	GameBase::setDamageLevel(%this.linkedobject,20.0);
	Turret::onDestroyed(%this.linkedobject);
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "HeavyTurretPack"]--;
}

// Override base class just in case.
function DeployableHeavyTurret::onPower(%this,%power,%generator) {}
function DeployableHeavyTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


//--------------------------------------------

TurretData CameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = targetLaser;
	minGunEnergy = 1;
	maxGunEnergy = 1;
	maxDamage = 0.65;
	maxEnergy = 30;
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
	FOV = 0.909; //707
	pinger = false;
	explosionId = debrisExpMedium;
	description = "Remote Camera";
      isSustained     = true;
      firingTimeMS    = 750;
      energyRate      = 30.0;
};

function CameraTurret::onAdd(%this)
{
	%this.empeffect = 0;
	schedule("CameraTurret::deploy(" @ %this @ ");",1,%this);
	//if (GameBase::getMapName(%this) == "") {
	//	GameBase::setMapName (%this, "Remote Camera");
	//}
}

function CameraTurret::verifyTarget(%this,%target)
{
	if(%this.empeffect == 0 && %target.jamdetect != "true") return "True"; else return "False";
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

//--------------------------------------------

TurretData ImpulseTurret
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = ImpulseTurretAttack;
	maxDamage = 0.65;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.5;
	speed = 5.0;
	speedModifier = 5.0;
	range = 25;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Impulse Turret";
	damageSkinData = "objectDamageSkins";
      sfxAmbient = SoundGeneratorPower;
      isSustained     = true;
      firingTimeMS    = 750;
      energyRate      = 30.0;
};

function ImpulseTurret::onAdd(%this)
{
	%this.empeffect = 0;
	schedule("ImpulseTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0;
	//if (GameBase::getMapName(%this) == "") {
	//	GameBase::setMapName (%this, "Impulse Turret");
	//}
}

function ImpulseTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ImpulseTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function ImpulseTurret::verifyTarget(%this,%target)
{
	if(%this.empeffect == 0 && %target.jamdetect != "true") return "True"; else return "False";
}

function ImpulseTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	GameBase::setDamageLevel(%this.linkedobject,20.0);
	Turret::onDestroyed(%this.linkedobject);
	$TeamItemCount[GameBase::getTeam(%this) @ "ImpulseTurretPack"]--;
}	

// Override base class just in case.
function ImpulseTurret::onPower(%this,%power,%generator) {}
function ImpulseTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//---------------------------------------------------

TurretData PointDefence
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = PointDefenceBullet;
	maxDamage = 0.35;
	maxEnergy = 50;
	minGunEnergy = 1;
	maxGunEnergy = 6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.2;
	speed = 5.0;
	speedModifier = 1.5;
	range = 15;
	gunRange = 30;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundChainTurretOn;
	deactivateSound = SoundChainTurretOff;
	explosionId = flashExpMedium;
	description = "Point Defence Turret";
	damageSkinData = "objectDamageSkins";
};

function PointDefence::onAdd(%this)
{
	%this.empeffect = 0;
	schedule("PointDefence::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,50);
	%this.shieldStrength = 0;
	//if (GameBase::getMapName(%this) == "") {
	//	GameBase::setMapName (%this, "Point Defence Turret");
	//}
}

function PointDefence::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function PointDefence::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function PointDefence::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	GameBase::setDamageLevel(%this.linkedobject,20.0);
	Turret::onDestroyed(%this.linkedobject);
  	$TeamItemCount[GameBase::getTeam(%this) @ "PointDefencePack"]--;
}	

// Override base class just in case.
function PointDefence::onPower(%this,%power,%generator) {}
function PointDefence::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

function PointDefence::verifyTarget(%this,%target)
{
   if (Item::getVelocity(%target) != 0)
	{
		if(%this.empeffect == 0 && %target.jamdetect != "true") return "True"; else return "False";
	} else
	{
	      return "False";
	}
}

//---------------------------------------------------

TurretData DeployableMotionSensor
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = MotionLaser;
	maxDamage = 0.35;
	maxEnergy = 60;
	minGunEnergy = 1;
	maxGunEnergy = 2;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
	speed = 4.0;
	speedModifier = 1.5;
	range = 75;
	gunRange = 150;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_motionSensor";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Laser Motion Sensor";
	damageSkinData = "objectDamageSkins";
};

function DeployableMotionSensor::onAdd(%this)
{
	%this.empeffect = 0;
	schedule("DeployableMotionSensor::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,25);
	%this.shieldStrength = 0;
	//if (GameBase::getMapName(%this) == "") {
	//	GameBase::setMapName (%this, "Laser Motion Sensor");
	//}
}

function DeployableMotionSensor::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableMotionSensor::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableMotionSensor::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MotionSensorPack"]--;
}	

// Override base class just in case.
function DeployableMotionSensor::onPower(%this,%power,%generator) {}
function DeployableMotionSensor::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

function DeployableMotionSensor::verifyTarget(%this,%target)
{
   if (Item::getVelocity(%target) != 0)
	{
		if(%this.empeffect == 0) 
			{
				%target.jamdetect = "false";
				return "True"; 
			} else 
			{
				return "False";
			}
	} else
	{
	      return "False";
	}
}

// Override base class just in case.
function DeployableMotionSensor::onPower(%this,%power,%generator) {}
function DeployableMotionSensor::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

TurretData DeployableWeaponLockOut
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = WeaponLockOutAttack;
	maxDamage = 0.35;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.3;
	speed = 5.0;
	speedModifier = 5.0;
	range = 15;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundChainTurretOn;
	deactivateSound = SoundChainTurretOff;
	explosionId = flashExpMedium;
	description = "Weapon Lock Out";
	damageSkinData = "objectDamageSkins";
      sfxAmbient = SoundGeneratorPower;
      isSustained     = true;
      firingTimeMS    = 750;
      energyRate      = 30.0;
};

function DeployableWeaponLockOut::onAdd(%this)
{
	%this.empeffect = 0;
	schedule("DeployableWeaponLockOut::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
}

function DeployableWeaponLockOut::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableWeaponLockOut::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableWeaponLockOut::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	GameBase::setDamageLevel(%this.linkedobject,20.0);
	Turret::onDestroyed(%this.linkedobject);
  	$TeamItemCount[GameBase::getTeam(%this) @ "WeaponLockOutPack"]--;
}

function DeployableWeaponLockOut::onPower(%this,%power,%generator) {}
function DeployableWeaponLockOut::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

function DeployableWeaponLockOut::verifyTarget(%this,%target)
{
	%typeoftarget = getObjectType(%target);
	if (%typeoftarget == "Player")
		{
			%wpn = Player::getMountedItem(%target,$WeaponSlot);
			if (%wpn != -1 && %wpn != RepairGun && %wpn != PowerPackGun)
				{
					if(%this.empeffect == 0 && %target.jamdetect != "true") return "True"; else return "False";
				}
		}
	return "False";
}


//---------------------------------------------------
TurretData ProximityAlarm
{
	className = "Turret";
	shapeFile = "sensor_small"; //"remoteturret";
	projectileType = MotionLaser;
	maxDamage = 0.45;
	maxEnergy = 300;
	minGunEnergy = 90;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 5.0;
	speed = 0.5;//0.5
	speedModifier = 1.0;//1.0
	range = 15;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 1;//0;
	castLOS = true;
	supression = false;
	pinger = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Proximity Alarm";
	damageSkinData = "objectDamageSkins";
};

function ProximityAlarm::verifyTarget(%this,%target)
{
	if (getSimTime() - $AlarmTime[%this] > 3)
	{
		%dist = Vector::getDistance(Gamebase::getPosition(%this), Gamebase::getPosition(%target));
		if (%dist <= 15 && %this.empeffect == 0 && %target.jamdetect != "true")
		{
			$AlarmTime[%this] = getSimTime();
			%team =gamebase::getteam(%this);
			%client = Player::getClient(%target);
			TeamMessages(0, %team, GameBase::GetMapName(%this) @ " has detected " @ Client::getName(%client));
		}
	}
	return false;
}

function ProximityAlarm::onAdd(%this)
{
	%this.empeffect = 0;
	schedule("ProximityAlarm::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.005;//0.0
	//if (GameBase::getMapName(%this) == "") {
	//	GameBase::setMapName (%this, "Proximity Alarm");
	//}
}

function ProximityAlarm::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ProximityAlarm::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function ProximityAlarm::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ProximityAlarmPack"]--;
}

function ProximityAlarm::onPower(%this,%power,%generator) {}
function ProximityAlarm::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


//---------------------------------------------------

function Turret::onAdd(%this)
{
	%this.empeffect = 0;
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
   if(%cl != -1) {
   	%pl = Client::getOwnedObject(%cl);
		Player::setMountObject(%pl, -1,0);
	   Client::setControlObject(%cl, %pl);
   }
	Client::setGuiMode(%cl,2);
}

function Turret::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,10);
	}
	else {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
	}
	GameBase::setActive(%this,%power);
}

function Turret::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) {
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,10);
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
	if ($UseAdjustedScoring == "true") DoDestroyScoring(%this,%this.lastDamageObject,"Destroy");
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	//Turret::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 
		0.1, 200, 100); 
}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if ($UseAdjustedDamageScale == "true") %value = (%value * $AdjustedDamageScale);
   if (%type == $LaserDamageType) %value = ScaleLaserDamage(%this,%object,%value);
   if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		if(%name == PlasmaTurret || %name == ELFTurret || %name == RocketTurret || %name == MortarTurret || %name == IndoorTurret)
			%TDS = $Server::TeamDamageScale;
	}
	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
	
}

function Turret::onControl (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
}

function Turret::onDismount (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Leaving turret " @ %this);
}

function Turret::verifyTarget(%this,%target)
{
	if(%this.empeffect == 0 && %target.jamdetect != "true") return "True"; else return "False";
}

//function Turret::onCollision (%this, %object)
//{
//	if (getObjectType (%object) == "Player")
//		{
//			Player::mountObject (%object, %this);
//		}
//}

//--------------------------------------------

//--------------------------------------------

TurretData AmmoTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = RearmingSystem;
	maxDamage = 1000;
	maxEnergy = 3000;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.5;
	speed = 5.0;
	speedModifier = 5.0;
	range = 10;
	visibleToSensor = false;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Vehicle Pad Re-arming System";
	damageSkinData = "objectDamageSkins";
      sfxAmbient = SoundGeneratorPower;
      isSustained     = true;
      firingTimeMS    = 750;
      energyRate      = 30.0;
};

function AmmoTurret::onAdd(%this)
{
	%this.empeffect = 0;
	schedule("AmmoTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Vehicle Pad Re-arming System");
	}
}

function AmmoTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function AmmoTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function AmmoTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
}

// Override base class just in case.
function AmmoTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

function AmmoTurret::verifyTarget(%this,%target)
{
	%typeoftarget = getObjectType(%target);
	%ammo = GameBase::getEnergy(%target.vehicle);
	%dam = GameBase::getDamageLevel(%target.vehicle);
	if (%typeoftarget == "Player" && %target.driver == 1 && GameBase::getDamageState(%this.vehiclepad) == "Enabled" && (%ammo < 100 || %dam > 0))
		{
			return "True";
		} else return "False";
}

//--------------------------------------------

TurretData DeployableAATurret
{
	className = "Turret";
	shapeFile = "chainturret";
	projectileType = AATurretAttack;
	maxDamage = 0.65;
	maxEnergy = 50;
	minGunEnergy = 3;
	maxGunEnergy = 4;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 75;
	gunRange = 150;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundAATurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Anti-Air Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableAATurret::onAdd(%this)
{
	%this.empeffect = 0;
	schedule("DeployableAATurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.016;
}

function DeployableAATurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableAATurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableAATurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "AATurretPack"]--;
}

function DeployableAATurret::verifyTarget(%this,%target)
{
	%typeoftarget = getObjectType(%target);
	%ammo = GameBase::getEnergy(%target.vehicle);
	%dam = GameBase::getDamageLevel(%target.vehicle);
	if (%typeoftarget == "Player" && (%target.driver == 1 || Player::isJetting(%target)))
		{
			if(%this.empeffect == 0 && %target.jamdetect != "true") return "True"; else return "False";
		} else return "False";
}

// Override base class just in case.
function DeployableAATurret::onPower(%this,%power,%generator) {}
function DeployableAATurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


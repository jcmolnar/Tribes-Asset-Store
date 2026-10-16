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
	range = 100;
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
      return "True";
   else
      return "False";
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
	visibleToSensor = true;
	dopplerVelocity = 2;
	castLOS = true;
	supression = false;
	supressable = false;
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
	projectileType = HangingBolt;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 30;
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
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Turret");
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
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


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

//----------------------------------------------------------------------------------------
// My turrets - Plastic Explosive, Shell Turret, Remote Plasma, Remote Rocket, and Chaingun
//----------------------------------------------------------------------------------------
TurretData ACameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 0.05;
	maxEnergy = 10;
	speed = 30;
	speedModifier = 2.0;
	range = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = defaultDebrisLarge;
	FOV = 0.707;
	pinger = false;
	explosionId = debrisExpLarge;
	description = "Spy Cam";
};

function ACameraTurret::onAdd(%this)
{
	schedule("ACameraTurret::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Aerial Camera");
	}
}

function ACameraTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ACameraTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function ACameraTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
}

//Plastic Explosive Turret
TurretData PlasticExplosive
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = PlasticBoom;
	maxDamage = 0.65;
	maxEnergy = 10;
	minGunEnergy = 10;
	maxGunEnergy = 10;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 40.0;
	speedModifier = 1.5;
	range = 0;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_generator";
	debrisId = defaultDebrisLarge;
	shieldShapeName = "shield";
	fireSound = ShockExplosion;
	explosionId = LargeShockwave;
	description = "Plastic Explosive";
};

function PlasticExplosive::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	playSound(SoundPlasticDialUp,GameBase::getPosition(%this));
	GameBase::setRechargeRate(%this,1);
	%this.shieldStrength = 0.0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Plastic Explosive");
	}
}

function PlasticExplosive::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function PlasticExplosive::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function PlasticExplosive::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
}

function PlasticExplosive::onPower(%this,%power,%generator) {}

function PlasticExplosive::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,1);
	GameBase::setActive(%this,true);
}

//--------------------------------------------
//Shell Turret
TurretData TankGun
{
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 25;
	maxGunEnergy = 50;
	reloadDelay = 0.8;
	fireSound = shockExplosion;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 30;
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
	projectileType = TankShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "RPG Turret";
};

function TankGun::onAdd(%this)
{
	GameBase::setRechargeRate(%this,12);
	%this.shieldStrength = 0.03;
	GameBase::generatePower(%this, true);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "RPG Turret");
	}
}

function TankGun::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	GameBase::generatePower(%this, false);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ShellTurretPack"]--;
}

function TankGun::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,12);
	GameBase::setActive(%this,true);
}

function TankGun::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.018;
		GameBase::setRechargeRate(%this,12);
	}
	else {
		%this.shieldStrength = 0.018;
		GameBase::setRechargeRate(%this,12);

	}
	GameBase::setActive(%this,%power);
}

//--------------------------------------------
//Remote Plasma Turret
TurretData RemotePlasma
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
	range = 100;
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
	description = "Remote Plasma Turret";
};

function RemotePlasma::onAdd(%this)
{
	if(getObjectType(%this) != "Turret") return; // PORT: the name starts with "remote", so a client can call it with its client id here
	GameBase::setRechargeRate(%this,6);
	%this.shieldStrength = 0.022;
	GameBase::generatePower(%this, true);
	if (GameBase::getMapName(%this) == "")
	   {
	   GameBase::setMapName (%this, "Remote Plasma Turret");
	   }
}

function RemotePlasma::onDestroyed(%this)
{
	if(getObjectType(%this) != "Turret") return; // PORT: the name starts with "remote", so a client can call it with its client id here
	Turret::onDestroyed(%this);
	GameBase::generatePower(%this, false);
  	$TeamItemCount[GameBase::getTeam(%this) @ "PlasmaTurretPack"]--;
}

function RemotePlasma::onEnabled(%this) 
{
	if(getObjectType(%this) != "Turret") return; // PORT: the name starts with "remote", so a client can call it with its client id here
	GameBase::setRechargeRate(%this,6);
	GameBase::setActive(%this,true);
}

function RemotePlasma::onPower(%this,%power,%generator)
{
	if(getObjectType(%this) != "Turret") return; // PORT: the name starts with "remote", so a client can call it with its client id here
	if (%power) {
		%this.shieldStrength = 0.022;
		GameBase::setRechargeRate(%this,5);
	}
	else {
		%this.shieldStrength = 0.022;
		GameBase::setRechargeRate(%this,5);

	}
	GameBase::setActive(%this,%power);
}

//--------------------------------------------
//Chaingun Turret
TurretData RemoteChain
{
	maxDamage = 0.32;
	maxEnergy = 200;
	minGunEnergy = 2;
	maxGunEnergy = 1;
	reloadDelay = 0.1;
	fireSound = SoundTFireChaingun;
	activationSound = SoundChainTurretOn;
	deactivateSound = SoundChainTurretOff;
	whirSound = SoundChainTurretTurn;
	range = 32;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "chainturret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = GatlingBullet;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = rocketExp;
	description = "Remote Chain Turret";
};

function RemoteChain::onAdd(%this)
{
	if(getObjectType(%this) != "Turret") return; // PORT: the name starts with "remote", so a client can call it with its client id here
	GameBase::setRechargeRate(%this,8);
	%this.shieldStrength = 0.006;
	GameBase::generatePower(%this, true);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Chaingun Turret");
	}
}

function RemoteChain::onDestroyed(%this)
{
	if(getObjectType(%this) != "Turret") return; // PORT: the name starts with "remote", so a client can call it with its client id here
	Turret::onDestroyed(%this);
	GameBase::generatePower(%this, false);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ChainTurretPack"]--;
}

function RemoteChain::onEnabled(%this) 
{
	if(getObjectType(%this) != "Turret") return; // PORT: the name starts with "remote", so a client can call it with its client id here
	GameBase::setRechargeRate(%this,8);
	GameBase::setActive(%this,true);
}	

function RemoteChain::onPower(%this,%power,%generator)
{
	if(getObjectType(%this) != "Turret") return; // PORT: the name starts with "remote", so a client can call it with its client id here
	if (%power) {
		%this.shieldStrength = 0.006;
		GameBase::setRechargeRate(%this,5);
	}
	else
	{
		%this.shieldStrength = 0.006;
		GameBase::setRechargeRate(%this,5);

	}
	GameBase::setActive(%this,%power);
}

//--------------------------------------------
//Stinger Rocket Turret
TurretData Stinger
{
	maxDamage = 2.65;
	maxEnergy = 150;
	minGunEnergy = 100;
	maxGunEnergy = 100;
	range = 500;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "mortar_turret";
	shieldShapeName = "shield_medium";
	speed = 5.5;
	speedModifier = 2.0;
	projectileType = StingerMissile;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
//	targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "Stinger Battery";
};

function Stinger::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

function Stinger::onAdd(%this)
{
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.015;
	GameBase::generatePower(%this, true);
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Stinger AAA");
	}
}

function Stinger::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	%team = GameBase::getTeam(%this);
  	$TeamItemCount[%team @ "StingerPack"]--;
	$StingerTime[%team] = 1;
	schedule("Stinger::ClearDelay(" @ %team @ ");",300);
}

function Stinger::ClearDelay(%team)
{
      TeamMessages(3, %team, "Your team can now deploy another Stinger turret!");
	$StingerTime[%team] = 0;
}

function Stinger::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

function Stinger::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.015;
		GameBase::setRechargeRate(%this,5);
	}
	else {
		%this.shieldStrength = 0.015;
		GameBase::setRechargeRate(%this,5);

	}
	GameBase::setActive(%this,%power);
}

//--------------------------------------------
//LaserTurret

TurretData LaserTurret
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = TurretLaser;
	maxDamage = 0.75;
	maxEnergy = 100;
	minGunEnergy = 10;
	maxGunEnergy = 33;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.8;
	speed = 8.0;
	speedModifier = 8.0;
	range = 25;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpLarge;
	description = "Proximity Laser Turret";
	damageSkinData = "objectDamageSkins";
};

function LaserTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 1.0)
      return "False";
   else
      return "True";
}

function LaserTurret::onAdd(%this)
{
	schedule("LaserTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,2);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Prox. Laser Turret");
	}
}

function LaserTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function LaserTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function LaserTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LaserTurretPack"]--;
}

function LaserTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,2);
	GameBase::setActive(%this,true);
}

//Aerial LaserTurret
TurretData ALaserTurret
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = TurretLaser;
	maxDamage = 0.04;
	maxEnergy = 100;
	minGunEnergy = 10;
	maxGunEnergy = 33;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.8;
	speed = 8.0;
	speedModifier = 8.0;
	range = 25;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpLarge;
	description = "Sky Laser";
	damageSkinData = "objectDamageSkins";
};

function ALaserTurret::onAdd(%this)
{
	schedule("LaserTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,2);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Sky Laser Turret");
	}
}

function ALaserTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ALaserTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function ALaserTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
}

function ALaserTurret::onPower(%this,%power,%generator) {}
function ALaserTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//Aerial LaserTurret
TurretData ATLaser
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = miniLaser;
	maxDamage = 0.04;
	maxEnergy = 100;
	minGunEnergy = 1;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.2;
	speed = 8.0;
	speedModifier = 8.0;
	range = 25;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
//	fireSound = SoundFireTargetingLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpLarge;
	description = "Sky Scraper";
	damageSkinData = "objectDamageSkins";
};

function ATLaser::onAdd(%this)
{
	schedule("LaserTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,4);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Sky Scraper Turret");
	}
}

function ATLaser::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ATLaser::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function ATLaser::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
}

function ATLaser::onPower(%this,%power,%generator) {}
function ATLaser::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//---------------------------------------------------

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
   if(%cl != -1) {
   	%pl = Client::getOwnedObject(%cl);
		Player::setMountObject(%pl, -1,0);
	   Client::setControlObject(%cl, %pl);
   }
	Client::setGuiMode(%cl,2);
}

function Turret::onPower(%this,%power,%generator)
{
	if (%power)
	{
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,10);
	}
	else
	{
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
	if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%name = GameBase::getDataName(%this);
		if(%name == PlasmaTurret || %name == ELFTurret || %name == RocketTurret || %name == MortarTurret || %name == IndoorTurret)
			%TDS = $Server::TeamDamageScale;
	}
	if(%value > 0)
		StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);

	if (%type == $PaintDamageType)
	{
		if(%this.PaintCount == "")
			%this.PaintCount = 0;

		%this.PaintCount++;

		if(%this.PaintCount == 5)
		{
			%this.PaintCount = 0;
			%object.target = %this;
			Client::sendMessage(%object,3,"Lock acquired!");
			FireLockOn(%object,%this);
		}
	}

//	if(%type == $PheonixDamageType && GameBase::getTeam(%this) != GameBase::getTeam(%object))
//		GameBase::applyDamage(%this,$DebrisDamageType,90,GameBase::getPosition(%this),"0 0 0","0 0 0",%object);
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

//function Turret::onCollision (%this, %object)
//{
//	if (getObjectType (%object) == "Player")
//		{
//			Player::mountObject (%object, %this);
//		}
//}

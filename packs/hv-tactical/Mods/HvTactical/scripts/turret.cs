//----------------------------------------------------------------------------
// TURRET DYNAMIC DATA
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
TurretData DeployableBreathOfRa //TurretData name, used in item.cs 3 times
{
	className = "Turret";//type classification
	shapeFile = "remoteturret";//shape, texture used
	projectileType = FlameBurst;
	maxDamage = 0.65;//stamina of unshielded turret
	maxEnergy = 300;//300; amount of turret energy
	minGunEnergy = 30;//?
	maxGunEnergy = 2;//?
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };//sound made when deployed
	reloadDelay = 0.3;//0.01,delay between shots (sec)
	speed = 2.0;//4.0; traverse speed?
	speedModifier = 1.5;//?
	range = 35;//sensor range of turret
	visibleToSensor = true;//shows up on command screen (y,n)
	shadowDetailMask = 4;//?
	dopplerVelocity = 1;//+++++++++++++++++++++++++++++++++++++++++++++
	castLOS = true;//tracks when target not visible?
	supression = false;//acts as sensor jammer, true=yes
	suppressable = false;//can be jammed, true=yes?
	pinger = false;//?
	mapFilter = 2;//?
	mapIcon = "M_turret";//icon as appears on command screen
	debrisId = flashDebrisMedium;//debris graphic
	shieldShapeName = "shield";//shield type?
	fireSound = SoundWindGust; //explosion4;
//	activationSound = SoundChainTurretOn;//sound when on
//	deactivateSound = SoundChainTurretOff;//sound when off
	explosionId = debrisexplarge;//explosion graphic
	description = "Remote Turret";//description pertaining to ? file
	damageSkinData = "objectDamageSkins";//damage graphic
};

function DeployableBreathOfRa::onAdd(%this)
{
	schedule("DeployableBreathOfRa::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Turret");
	}
}

function DeployableBreathOfRa::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableBreathOfRa::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableBreathOfRa::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableBreathOfRaPack"]--;
}

// Override base class just in case.
function DeployableTurret::onPower(%this,%power,%generator) {}
function DeployableTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
TurretData DeployableVulcanTurret //TurretData name, used in item.cs 3 times
{
	className = "Turret";//type classification
	shapeFile = "remoteturret";//shape, texture used
	projectileType = VulcanBullet;//projectile fired
	maxDamage = 0.65;//stamina of unshielded turret
	maxEnergy = 300;//amount of turret energy
	minGunEnergy = 75;//?
	maxGunEnergy = 5;//energy consumtion
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };//sound made when deployed
	reloadDelay = 0.0005;//0.005,delay between shots (sec)
	speed = 2.0;//4.0; traverse speed?
	speedModifier = 1.5;//?
	range = 50;//sensor range of turret
	visibleToSensor = true;//shows up on command screen (y,n)
	shadowDetailMask = 4;//?
	dopplerVelocity = 0;//?
	castLOS = true;//tracks when target not visible?
	supression = false;//acts as sensor jammer, true=yes
	suppressable = false;//can be jammed, true=yes?
	pinger = false;//?
	mapFilter = 2;//?
	mapIcon = "M_turret";//icon as appears on command screen
	debrisId = flashDebrisMedium;//debris graphic
	shieldShapeName = "shield";//shield type?
	fireSound = SoundFireMortar;//sound when firing
	activationSound = SoundChainTurretOn;//sound when on
	deactivateSound = SoundChainTurretOff;//sound when off
	explosionId = debrisexplarge;//explosion graphic
	description = "Remote Turret";//description pertaining to ? file
	damageSkinData = "objectDamageSkins";//damage graphic
};

function DeployableVulcanTurret::onAdd(%this)
{
	schedule("DeployableVulcanTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Turret");
	}
}

function DeployableVulcanTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableVulcanTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableVulcanTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "VulcanPack"]--;
}

// Override base class just in case.
function DeployableTurret::onPower(%this,%power,%generator) {}
function DeployableTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//--------------------------------------------
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
	range = 200;//100
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
																//---------------------------------------------------------------------------	 
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

//-------------------------------------------------------------------------------------------
TurretData RocketTurret
{
	maxDamage = 0.75;
	maxEnergy = 120;//100;++++++++++
	minGunEnergy = 60;//30;+++++++
	maxGunEnergy = 30;//60;++++++++
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
	reloadDelay = 0.4;//com out, 3.5+++++++++++++++++++++++++
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

//below, makes rocket launcher track air targets only, now turned on
function RocketTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
TurretData DeployableFlak
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = FlakShell;
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 50;
	maxGunEnergy = 6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.8;
	speed = 4.0;
	speedModifier = 1.5;
	range = 300;//100
	visibleToSensor = true;
	shadowDetailMask = 8; //4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;

	explosionId = flashExpMedium;
	description = "Remote Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableFlak::onAdd(%this)
{
	schedule("DeployableFlak::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Flak Turret");
	}
}

function DeployableFlak::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableFlak::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableFlak::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "FlakPack"]--;
}

// Override base class just in case.
function DeployableFlak::onPower(%this,%power,%generator) {}
function DeployableFlak::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//below, makes Flak Turret track air targets only, now turned on
function DeployableFlak::verifyTarget(%this,%target)
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
	reloadDelay = 3.0;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 40;
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
	projectileType = FusionBolt;
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
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 TurretData DeployableSentry { className = "Turret"; shapeFile = "remoteturret"; projectileType = MiniFusionBolt; maxDamage = 0.65; maxEnergy = 60; minGunEnergy = 25; maxGunEnergy = 5; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 0.25; speed = 4.0; speedModifier = 1.5; range = 70; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; fireSound = SoundRemoteTurretFire; activationSound = SoundRemoteTurretOn; deactivateSound = SoundRemoteTurretOff; explosionId = flashExpMedium; description = "Remote Sentry"; damageSkinData = "objectDamageSkins"; }; function DeployableSentry::onAdd(%this) { schedule("DeployableSentry::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,5); %this.shieldStrength = 0.015; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Remote Sentry"); } } function DeployableSentry::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployableSentry::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployableSentry::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "SentryPack"]--; } function DeployableSentry::onPower(%this,%power,%generator) {} function DeployableSentry::onEnabled(%this) { GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); } 

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

TurretData DeployableWatchdog
{
	className = "Turret";
	shapeFile = "camera"; //"remoteturret";
	projectileType = WatchdogLaser;
	maxDamage = 0.65;
	maxEnergy = 300;
	minGunEnergy = 75;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
	speed = 4.0;//4.0
	speedModifier = 1.5;//1.5
	range = 200;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 1;//0;
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
	description = "Watchdog";
	damageSkinData = "objectDamageSkins";
};

function DeployableWatchdog::onAdd(%this)
{
	schedule("DeployableWatchdog::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Watchdog");
	}
}

function DeployableWatchdog::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableWatchdog::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableWatchdog::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "WatchdogPack"]--;
}

// Override base class just in case.
function DeployableWatchdog::onPower(%this,%power,%generator) {}
function DeployableWatchdog::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//--------------------------------------------
TurretData DeployablePlasma
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = FusionBolt;
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.8;
	speed = 4.0;
	speedModifier = 1.5;
	range = 200;//100
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;

	explosionId = flashExpMedium;
	description = "Remote Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployablePlasma::onAdd(%this)
{
	schedule("DeployablePlasma::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Plasma Turret");
	}
}

function DeployablePlasma::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployablePlasma::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployablePlasma::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LaserTurret"]--;
}

// Override base class just in case.
function DeployablePlasma::onPower(%this,%power,%generator) {}
function DeployablePlasma::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


//--------------------------------------------

TurretData DeployableLaser
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = SniperLaser;
	maxDamage = 0.75;
	maxEnergy = 75;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 10.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 125;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Remote Laser Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableLaser::onAdd(%this)
{
	schedule("DeployableLaser::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Laser Turret");
	}
}

function DeployableLaser::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableLaser::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableLaser::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LaserPack"]--;
}

// Override base class just in case.
function DeployableLaser::onPower(%this,%power,%generator) {}
function DeployableLaser::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//=------------------------------------
TurretData DeployableShock
{
	maxDamage = 2.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 30;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "ELF Turret";
	shapeFile = "camera";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = lightningCharge;
	reloadDelay = 0.3;
	explosionId = flashExpMedium;
	description = "Deployable ELF Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;

};

function DeployableShock::onAdd(%this)
{
	schedule("DeployableShock::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	//%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote ELF Turret");
	}
}

function DeployableShock::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableShock::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

// Override base class just in case.
function DeployableShock::onPower(%this,%power,%generator) {}
function DeployableShock::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

function DeployableShock::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ShockPack"]--;
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
TurretData DeployableMAG
{
	maxDamage = 2.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 30;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "MAG Turret";
	shapeFile = "camera";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = MagnetCharge; 
	reloadDelay = 0.3;
	explosionId = flashExpMedium;
	description = "Deployable MAG Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;

};

function DeployableMAG::onAdd(%this)
{
	schedule("DeployableMAG::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	//%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote MAG Turret");
	}
}

function DeployableMAG::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableMAG::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableMAG::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MAGPack"]--;
}

// Override base class just in case.
function DeployableMAG::onPower(%this,%power,%generator) {}
function DeployableMAG::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//--------------------------------------------
//=-=-=-=- Deployable Rocket Turret =-=-=-=-
//--------------------------------------------

TurretData DeployableRocket
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = TurretMissile;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 25;
	maxGunEnergy = 30;//25;++++++++++++++++++++++++++++
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 1.0;//2.5;+++++++++++++++++++++++++++++++++++++
	speed = 4.0;
	speedModifier = 1.5;
	range = 125;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundMissileTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Remote Rocket";
	damageSkinData = "objectDamageSkins";
};

//tracks air targets only
function DeployableRocket::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

function DeployableRocket::onAdd(%this)
{
	schedule("DeployableRocket::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.015;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Rocket");
	}
}

function DeployableRocket::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableRocket::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableRocket::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "RocketPack"]--;
}

// Override base class just in case.
function DeployableRocket::onPower(%this,%power,%generator) {}
function DeployableRocket::onEnabled(%this) 
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
	maxEnergy = 200;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	speed = 20;
	speedModifier = 1.0;
	range = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	shieldShapeName = "shield";
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
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.015;//0.0
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

//+++++++++++++++++++++++++++++++++++++++++++++++++++++
TurretData DeployableConTurret //TurretData name, used in item.cs 3 times
{
	className = "Turret";//type classification
	shapeFile = "chainturret"; //"remoteturret";  shape, texture used
	projectileType = Watch;//projectile fired
	maxDamage = 1.5;//stamina of unshielded turret
	maxEnergy = 300;//amount of turret energy
	minGunEnergy = 75;//?
	maxGunEnergy = 10;//?
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };//sound made when deployed
	reloadDelay = 1.5;//0.05,delay between shots (sec)
	speed = 2.0;//4.0; traverse speed?
	speedModifier = 1.5;//?
	range = 150;//sensor range of turret
	visibleToSensor = true;//shows up on command screen (y,n)
	shadowDetailMask = 4;//?
	dopplerVelocity = 1; //2; 0=free attack, 2=motion sensitive?
	castLOS = true;//tracks when target not visible?
	supression = false;//acts as sensor jammer, true=yes
	suppressable = false;//can be jammed, true=yes?
	pinger = false;//?
	mapFilter = 2;//?
	mapIcon = "M_turret";//icon as appears on command screen
	debrisId = flashDebrisLarge;//debris graphic
	shieldShapeName = "shield";//shield type?
	fireSound = SoundPlasmaTurretFire;//sound when firing
	activationSound = SoundChainTurretOn;//sound when on
	deactivateSound = SoundChainTurretOff;//sound when off
	explosionId = debrisexplarge;//explosion graphic
	description = "Guard Dog";//description pertaining to ? file
	damageSkinData = "objectDamageSkins";//damage graphic
};

function DeployableConTurret::onAdd(%this)
{
	schedule("DeployableConTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Guard Dog");
	}
}

function DeployableConTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableConTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableConTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ConPack"]--;
}

// Override base class just in case.
function DeployableConTurret::onPower(%this,%power,%generator) {}
function DeployableConTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
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
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 
		0.1, 200, 100); 
}

//function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
//{
//   if(%this.objectiveLine)
//		%this.lastDamageTeam = GameBase::getTeam(%object);
//	%TDS= 1;
//	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
//		%TDS = $Server::TeamDamageScale;
//	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
//
//}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
 {
	 if(%this.objectiveLine)
		 %this.lastDamageTeam = GameBase::getTeam(%object);
		 %TDS= 1;
	 if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
	 {
		 %name = GameBase::getDataName(%this);
		 if((%name != DeployableTurret && %name != CameraTurret) && (%name != DeployableSentry && %name != DeployableRocket)) %TDS = $Server::TeamDamageScale;
	 } 
	 StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
	 if(%type == $EMPDamageType) GameBase::setEnergy(%this,0);
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

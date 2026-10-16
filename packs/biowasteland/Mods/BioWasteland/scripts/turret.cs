//=======================================================
TurretData AirFuser
{
	className = "Turret";
	shapeFile = "mortar_turret";
	projectileType = DiscShell;
	maxDamage = 0.5;
	maxEnergy = 200;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 1.6;
	speed = 2.0;
	speedModifier = 2;
	range = 250;
	visibleToSensor = true;
	shadowDetailMask = 8; //4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireDisc;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	explosionId = flashExpMedium;
	description = "Air Fuser Turret";
	damageSkinData = "objectDamageSkins";
};

function AirFuser::onAdd(%this)
{
	schedule("AirFuser::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "AirFuser Turret");
	}
}

function AirFuser::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function AirFuser::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function AirFuser::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "AirAmmoPad"]--;
}

function AirFuser::onPower(%this,%power,%generator) {
}
function AirFuser::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}


//======================================================================== Hyper-Grav Turret
TurretData DeployableHGravTurret
{
	className = "Turret";
	shapeFile = "camera";
        projectileType = HGravCharge;
	maxDamage = 0.65;
        maxEnergy = 30;
        minGunEnergy = 5;
        maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.0;
	speed = 4.0;
	speedModifier = 1.5;
        range = 50;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
        fireSound = SoundPickupAmmo;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
        description = "Hyper-Grav Turret";
	damageSkinData = "objectDamageSkins";

   isSustained     = true;
   firingTimeMS    = 5000;
   energyRate      = 1.0;
};

function DeployableHGravTurret::onAdd(%this)
{
        schedule("DeployableHGravTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,10);
        %this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Hyper-Grav Turret");
	}
}

function DeployableHGravTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableHGravTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableHGravTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "HGravTurretPack"]--;
}

// Override base class just in case.
function DeployableHGravTurret::onPower(%this,%power,%generator) {}
function DeployableHGravTurret::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}

//======================================================================== Anti-Grav Turret

TurretData DeployableSnare
{
	className = "Turret";
	shapeFile = "camera";
        projectileType = snareCharge;
	maxDamage = 0.65;
        maxEnergy = 30;
        minGunEnergy = 5;
        maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.0;
	speed = 4.0;
	speedModifier = 1.5;
        range = 50;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
        fireSound = SoundPickupAmmo;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
        description = "Anti-Grav Turret";
	damageSkinData = "objectDamageSkins";

   isSustained     = true;
   firingTimeMS    = 5000;
   energyRate      = 1.0;
};

function DeployableSnare::onAdd(%this)
{
        schedule("DeployableSnare::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,10);
        %this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Anti-Grav Turret");
	}
}

function DeployableSnare::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableSnare::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableSnare::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "AGravPack"]--;
}

// Override base class just in case.
function DeployableSnare::onPower(%this,%power,%generator) {}
function DeployableSnare::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}

//=======================================================
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
   targetableFovRatio = 0.5;

	explosionId = flashExpMedium;
	description = "Flak Turret";
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
//====================================================================================
TurretData FlameTurret
{
	maxDamage = 1.0;
	maxEnergy = 40;
	minGunEnergy = 6;
	maxGunEnergy = 6;
	reloadDelay = 0.1;
	fireSound = FlameTurretSound;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	explosionId = flashExpMedium;
	range = 22;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "indoorgun";
	shieldShapeName = "shield";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = FlamerBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	description = "Flame Turret";
};

function FlameTurret::onAdd(%this)
{

	schedule("FlameTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Flame Turret");
	}
}

function FlameTurret::deploy(%this)
{

	GameBase::playSequence(%this,1,"deploy");
}

function FlameTurret::onEndSequence(%this,%thread)
{

	GameBase::setActive(%this,true);
}

function FlameTurret::onDestroyed(%this)
{

	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "FlameTurretPack"]--;
}

// Override base class just in case.
function FlameTurret::onPower(%this,%power,%generator) {
}
function FlameTurret::onEnabled(%this)
{

	GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}
//====================================================================================
TurretData DeployableConTurret
{
	className = "Turret";
	shapeFile = "chainturret";
	projectileType = Shock;
	maxDamage = 1.5;
	maxEnergy = 300;
	minGunEnergy = 75;
	maxGunEnergy = 10;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 1.5;
	speed = 2.0;
	speedModifier = 1.5;
	range = 150;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 1;
	castLOS = true;
	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisLarge;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundChainTurretOn;
	deactivateSound = SoundChainTurretOff;
	explosionId = debrisexplarge;
	description = "Concussion Turret";
	damageSkinData = "objectDamageSkins";
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
//====================================================================================
TurretData DeployableChaingun
{
	className = "Turret";
	shapeFile = "camera"; //"remoteturret";
	projectileType = targetturrLaser;
	maxDamage = 0.75;
	maxEnergy = 300;
	minGunEnergy = 75;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
	speed = 4.0;
	speedModifier = 1.5;
	range = 400;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 1;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundTAT;
	activationSound = SoundChainTurretTurn;
	deactivateSound = SoundChainTurretOff;
	explosionId = flashExpMedium;
	description = "Target Acquisition Turr";
	damageSkinData = "objectDamageSkins";
};

function DeployableChaingun::onAdd(%this)
{
	schedule("DeployableChaingun::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Target Acquisition Turret");
	}
}

function DeployableChaingun::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableChaingun::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableChaingun::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ChaingunTurretPack"]--;
}

// Override base class just in case.
function DeployableChaingun::onPower(%this,%power,%generator) {}
function DeployableChaingun::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}
//====================================================================================
TurretData DeployableVulcan
{
	className = "Turret";
	shapeFile = "chainturret";
	projectileType = VulcanTurretBullet;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 5;
	maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.03;
	speed = 4.0;
	speedModifier = 1.5;
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
	fireSound = SoundFireMortar;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	explosionId = flashExpMedium;
	description = "Vulcan Turret";
	damageSkinData = "objectDamageSkins";
};
function DeployableVulcan::onAdd(%this)
{
	schedule("DeployableVulcan::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
	  GameBase::setMapName (%this, "Vulcan Turret");
	}
}
function DeployableVulcan::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}
function DeployableVulcan::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}
function DeployableVulcan::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "VulcanTurretPack"]--;
}
function DeployableVulcan::onPower(%this,%power,%generator) {}
function DeployableVulcan::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}
//====================================================================================
TurretData RailTurret
{
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 180;
	maxGunEnergy = 180;
	reloadDelay = 2.0;
	fireSound = SoundMissileTurretFire;
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
	projectileType = BigPulseLaser;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Rail Turret";
};

function RailTurret::onAdd(%this)
{

	schedule("RailTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Rail Turret");
	}
}

function RailTurret::deploy(%this)
{

	GameBase::playSequence(%this,1,"deploy");
}

function RailTurret::onEndSequence(%this,%thread)
{

	GameBase::setActive(%this,true);
}

function RailTurret::onDestroyed(%this)
{

	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "RailTurretPack"]--;
}

// Override base class just in case.
function RailTurret::onPower(%this,%power,%generator) {
}
function RailTurret::onEnabled(%this)
{

	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//============================================
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

//============================
TurretData ELFTurret
{
	maxDamage = 1.0;
	maxEnergy = 60;
	minGunEnergy = 5;
	maxGunEnergy = 1;
	range = 25;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "chainturret";
	projectileType = VulcanTurretBullet;
	shieldShapeName = "shield";
	reloadDelay = 0.03;
	speed = 4.0;
	speedModifier = 1.5;
	explosionId = LargeShockwave;
	description = "Vulcan Turret";

	fireSound        = SoundFireMortar;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;
};

//=============================
TurretData RocketTurret
{
	maxDamage = 0.75;
	maxEnergy = 100;
	minGunEnergy = 60;
	maxGunEnergy = 60;
	range = 300;
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
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	targetableFovRatio = 1.5;
	explosionId = LargeShockwave;
	description = "Rocket Turret";
};

function RocketTurret::onPower(%this,%power,%generator)
{

	if (%power)
	{
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,14);
	}
	else
	{
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

//======================================
TurretData MortarTurret
{
	maxDamage = 1.25;
	maxEnergy = 75;
	minGunEnergy = 25;
	maxGunEnergy = 100;
	reloadDelay = 1.6;
	fireSound = SoundFireDisc;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 250;
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
	projectileType = DiscShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Fuser Turret";
};

//========================
TurretData DeployableMortar
{
	className = "Turret";
	shapeFile = "mortar_turret";
	projectileType = "MortarShell";
	maxDamage = 1.0;
	maxEnergy = 45;
	minGunEnergy = 10;
	maxGunEnergy = 100;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 1.8;
	speed = 3.0;
	speedModifier = 1.5;
	range = 90;
	visibleToSensor = true;
	shadowDetailMask = 8;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	explosionId = flashExpMedium;
	description = "Remote Mortar Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableMortar::onAdd(%this)
{
	schedule("DeployableMortar::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Mortar Turret");
	}
}

function DeployableMortar::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableMortar::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableMortar::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TargetPack"]--;
}


function DeployableMortar::onFire(%a, %b, %c, %d)
{
	echo ("Mortar Turret");
}

function DeployableMortar::onPower(%this,%power,%generator) {}
function DeployableMortar::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}


function Sin(%theta)
{
 	 return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}

function Cos(%theta)
{
	 return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}

//==================================
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


//======================================== Ion Turret
TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = IonBolt;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 55; // 30
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
	description = "Remote Ion Turret";
	damageSkinData = "objectDamageSkins";
	validateShape = true;
	validateMaterials = true;
};

function DeployableTurret::onAdd(%this)
{

	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.005;
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
function DeployableTurret::onPower(%this,%power,%generator) {
}
function DeployableTurret::onEnabled(%this)
{

	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//==================================================================================================== Plasma

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
	range = 100;
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
	description = "Remote Plasma Turret";
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
  	$TeamItemCount[GameBase::getTeam(%this) @ "PlasmaTurretPack"]--;
}

// Override base class just in case.
function DeployablePlasma::onPower(%this,%power,%generator) {}
function DeployablePlasma::onEnabled(%this)
{

	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}


//====================================================================================================== Laser Turret
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
	range = 75;
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
function DeployableLaser::onPower(%this,%power,%generator) {
}
function DeployableLaser::onEnabled(%this)
{

	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}


//============================ Laser Mine
TurretData DeployableLaserM
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = SniperLaser;
	maxDamage = 0.75;
	maxEnergy = 55;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 150.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 35;
	visibleToSensor = false;
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
	description = "Point Defense Laser Mine";
	damageSkinData = "objectDamageSkins";
};
function DeployableLaserM::onAdd(%this)
{
	schedule("DeployableLaserM::deploy(" @ %this @ ");",$Wasteland::LaserMineLive,%this);
	GameBase::setRechargeRate(%this,0);
	%this.shieldStrength = 0;
}
function DeployableLaserM::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ( (%type == "Player" || %type == "Moveable") && GameBase::isActive(%this) && GameBase::getTeam(%this)!=GameBase::getTeam(%object) )
	Grenade::Plastic_Detonate(%this);
}
function DeployableLaserM::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}
function DeployableLaserM::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}
function DeployableLaserM::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LaserMine"]--;
}
function DeployableLaserM::onPower(%this,%power,%generator) {}

function DeployableLaserM::onEnabled(%this) {}

//============================== EMP Turret
TurretData DeployableShock
{
	maxDamage = 1.5;
	maxEnergy = 110;
	minGunEnergy = 15;
	maxGunEnergy = 20;
	reloadDelay = 2.0;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 30;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "indoorgun";
	shieldShapeName = "shield_medium";
	speed = 5.0;
	speedModifier = 1.50;
	projectileType = EMPShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "EMP Turret";

};

function DeployableShock::onAdd(%this)
{

	schedule("DeployableShock::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,6);
	//%this.shieldStrength = 0;
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote EMP Turret");
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

function DeployableShock::onDestroyed(%this)
{

	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ShockPack"]--;
}

// Override base class just in case.
function DeployableShock::onPower(%this,%power,%generator) {
}
function DeployableShock::onEnabled(%this)
{

	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//================= Satchel
TurretData DeployableSatchel
{
	className = "Turret";
	shapeFile = "camera";
	//projectileType = "Undefined";
	maxDamage = 0.01;
	maxEnergy = 75;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 10.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 0;
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
	explosionId = rocketExp;
	description = "Satchel Charge";
	damageSkinData = "objectDamageSkins";
};

function DeployableSatchel::onFire(%this)
{
	%client = GameBase::getControlClient(%this);
	if (!%client || %client == "") %client = %this.tc;
	GameBase::applyRadiusDamage($DebrisDamageType, getBoxCenter(%this), 20, 0.75, 305, %client);
}

function DeployableSatchel::onAdd(%this)
{

	schedule("DeployableSatchel::deploy(" @ %this @ ");",1,%this);
}

function DeployableSatchel::deploy(%this)
{

	GameBase::playSequence(%this,1,"deploy");
}

function DeployableSatchel::onEndSequence(%this,%thread)
{

	GameBase::setActive(%this,true);
	GameBase::setRechargeRate(%this,0);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Satchel Charge");
	}
}

function DeployableSatchel::onControl(%this)
{
	GameBase::applyRadiusDamage($MineDamageType, getBoxCenter(%this), 20, 0.75, 305, %this);
}

function DeployableSatchel::onDestroyed(%this)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	CalcRadiusDamage(%this,$DebrisDamageType,30,0.2,25,20,20,1.5,0.5,200,100);
  	$TeamItemCount[GameBase::getTeam(%this) @ "SatchelPack"]--;
}

function DeployableSatchel::onPower(%this,%power,%generator) {
}

function DeployableSatchel::onEnabled(%this)
{

	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//====================== Deployable Elf Turret
TurretData DeployableELFTurret
{
	className = "ELF Turret";
	shapeFile = "chainturret";
	projectileType = turretCharge;
	maxDamage = 1.35;
	maxEnergy = 90;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 80;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	speed = 15.0;
	speedModifier = 1.5;
	reloadDelay = 0;
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

function DeployableELFTurret::onAdd(%this)
{

	schedule("DeployableELFTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.008;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "ELF Turret");
}

function DeployableELFTurret::deploy(%this)
{

	GameBase::playSequence(%this,1,"deploy");
}

function DeployableELFTurret::onEndSequence(%this,%thread)
{

	GameBase::setActive(%this,true);
}

function DeployableELFTurret::onDestroyed(%this)
{

    	Gamebase::setActive(%this,false);
	GameBase::setRechargeRate(%this,0);
  	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableELF"]--;
	schedule("Turret::onDestroyed("@%this@");",0.8,%this);
}

function DeployableELFTurret::onPower(%this,%power,%generator) {
}

function DeployableELFTurret::onEnabled(%this)
{

	GameBase::setRechargeRate(%this,20);
	GameBase::setActive(%this,true);
}

// ========================    AintiAircraft Turret

TurretData BarrageTurret
{
	className = "Turret";
	shapeFile = "missileturret";
	projectileType = TurretMissile;
	maxDamage = 2;
	maxEnergy = 350;
	minGunEnergy = 20;
	maxGunEnergy = 250;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.5;
	speed = 5;
	speedModifier = 4.1;
	range = 350;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 1.5;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield_medium";
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	whirSound = SoundMissileTurretTurn;
	explosionId = flashExpMedium;
	description = "Anti-Aircraft Turret";
};

function BarrageTurret::onAdd(%this)
{

	schedule("BarrageTurret::deploy(" @ %this @ ");",now,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.01;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Anti-Aircraft Battery");
	}
}

function BarrageTurret::deploy(%this)
{

	GameBase::playSequence(%this,1,"deploy");
}

function BarrageTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	schedule("DeployableRocket::missilecheck(" @ %this @ ");", 1.5, %this);
}

function BarrageTurret::onDestroyed(%this)
{

	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "BarragePack"]--;
}

function BarrageTurret::onPower(%this,%power,%generator) {
}

function BarrageTurret::onEnabled(%this)
{

	GameBase::setRechargeRate(%this,20);
	GameBase::setActive(%this,true);
	%this.shieldStrength = 0.01;
}

function BarrageTurret::verifyTarget(%this,%target)
{
	if (GameBase::virtual(%target, "getMountObject") >= 1)
	{
		return "True";
	}
	else
	{
		return "False";
	}
}

//=================================== Rocket

TurretData DeployableRocket
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = TurretMissile;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 25;
	maxGunEnergy = 25;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.5;
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
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "RMT Rocket Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableRocket::verifyTarget(%this,%target)
{
	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5 && GameBase::virtual(%target, "getMountObject") < 1)//==only fire at players not vehicles
		return "True";
	else
		return "False";
}


function DeployableRocket::onAdd(%this)
{
	schedule("DeployableRocket::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.015;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "RMT Rocket Turret");
	}
}

function DeployableRocket::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableRocket::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	//schedule("DeployableRocket::missilecheck(" @ %this @ ");", 1.5, %this);
}

function DeployableRocket::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "RocketPack"]--;
}

function DeployableRocket::onPower(%this,%power,%generator){}
function DeployableRocket::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

function DeployableRocket::missilecheck(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
	{
		schedule("DeployableRocket::missilecheck(" @ %this @ ");", 20, %this);
		return;
	}
	%Set = newObject("misslecheckset",SimSet);
	%Pos = GameBase::getPosition(%this);
	%Mask = $StaticObjectType|$VehicleObjectType;
	containerBoxFillSet(%Set, %Mask, %Pos, 175, 175, 175,0);
	%num = Group::objectCount(%Set);
	if (%num > 0)
	{
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		%data = GameBase::getDataName(%obj);

		if (%data == "CoolProj" || %data == "NapProj" || %data == "BooProj" || %data == "EmpProj" || %data == "GasProj" || %data == "BallProj")
		{
			if (gamebase::getteam(%this) != gamebase::getteam(%obj))
			{
				%rot = gamebase::getrotation(%this);
				%dir = (Vector::getfromrot(%rot));
				%pos = Vector::add(GameBase::getPosition(%this), "0 0 3");
				%trans =  %rot @ " " @ %dir @ " 0 0 0 " @ %pos;
				Projectile::spawnProjectile("TurretMissile",%trans,%this,"0 0 0",%obj);
			}
		}
	}
	}
	deleteObject(%set);
	schedule("DeployableRocket::missilecheck(" @ %this @ ");", 1.5, %this);
}



//===============================
TurretData CameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = TranqDart;
	maxDamage = 0.75;
	maxEnergy = 75;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	speed = 20;
	reloadDelay = 10.0;
	speedModifier = 1.0;
	range = 75;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	dopplerVelocity = 0;
	debrisId = defaultDebrisSmall;
	FOV = 0.707;
	pinger = false;
	explosionId = debrisExpMedium;
	description = "Dart Blower";
	fireSound = SoundThrowItem;
	damageSkinData = "objectDamageSkins";
	shieldShapeName = "shield";
};

function CameraTurret::onAdd(%this)
{
	schedule("CameraTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
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

//========================================================================================== Arbitor Beacon
TurretData ArbitorBeacon
{
	className = "Turret";
	shapeFile = "plasammo";
	maxDamage = 2;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Arbitor Beacon";
	damageSkinData = "objectDamageSkins";
};

function ArbitorBeacon::onAdd(%this)
{
	schedule("ArbitorBeacon::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Arbitor Box");
	}
}

function ArbitorBeacon::deploy(%this) {GameBase::playSequence(%this,1,"deploy"); }
function ArbitorBeacon::onEndSequence(%this,%thread) {GameBase::setActive(%this,true); }
function ArbitorBeacon::onDisabled(%this){}
function ArbitorBeacon::onDestroyed(%this)
{
	%num = Group::objectCount(%this.set);
	if (%num > 0)
	{
	for(%i=%num-1; %i >= 0; %i--)
	{
		if (%this != %i)
		{
			%obj = Group::getObject(%this.set, %i);
			GameBase::startFadeIn(%obj);
			%obj.cloaked = 0;
		}
	}
	}
	deleteObject(%this.set);

	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ArbitorBeaconPack"]--;
}

function ArbitorBeacon::onPower(%this,%power,%generator) {}
function ArbitorBeacon::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);

	%Set = newObject("arbaset",SimSet);
	%Pos = GameBase::getPosition(%this);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType;
	containerBoxFillSet(%Set, %Mask, %Pos, 25, 25, 25,0);
	%num = Group::objectCount(%Set);
	if (%num > 0)
	{
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
		{
		}
		else
		{
			GameBase::startFadeOut(%obj);
			%obj.cloaked = 1;
		}
	}
	}
	%this.set = %Set;
	schedule("ArbitorBeacon::checkArbitorBeacon(" @ %this @ ");", 0.1, %this);
}

function ArbitorBeacon::checkArbitorBeacon(%this)
{
	%Set = newObject("arbbset",SimSet);
	%Pos = GameBase::getPosition(%this);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType;
	containerBoxFillSet(%Set, %Mask, %Pos, 25, 25, 25,0);

	//======================================== Check Items In Box
	%num = Group::objectCount(%Set);
	if (%num > 0)
	{
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		%datab = GameBase::getDataName(%obj);
		%objn = (getObjectType(%obj));

		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this || %datab == "ArbitorBeacon"){}
		else if (%this.cloaked == "0" || !%this.cloaked)
		{
			GameBase::startFadeOut(%obj);
			schedule ("GameBase::startFadeIn(" @ %obj @ ");",6);
			schedule (%obj @ ".cloaked = 0;",6);
			%obj.cloaked = 1;
		}
	}
	}
	//======================================== De-Cloak Items If Beacon Is Disabled
	if(GameBase::getDamageState(%this) != "Enabled" || !%this)
	{
		%num = Group::objectCount(%this.set);
		if (%num > 0)
		{
		for(%j; %j < %num; %j++)
		{
			%obj = Group::getObject(%this.set, %j);
			%datab = GameBase::getDataName(%obj);
			%objn = (getObjectType(%obj));

			if(%obj == %this || GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %datab == "ArbitorBeacon"){}
			else
			if(%obj.cloaked != "0")
			{
				%obj.cloaked = 0;
				GameBase::startFadeIn(%obj);
			}
		}
		}
		deleteObject(%this.set);
		deleteObject(%Set);
		return;
	}
	deleteObject(%this.set);
	%this.set = %Set;

	if(GameBase::getDamageState(%this) != "Enabled" || !%this)
	{
		deleteObject(%this.set);
		return;
	}

	schedule("ArbitorBeacon::checkArbitorBeacon(" @ %this @ ");", 6.0, %this); //then recheck in 10 seconds
}

//============================================================================================= EMP Beacon

TurretData EMPBeacon
{

	className = "Turret";
	shapeFile = "bridge";
	maxDamage = 2;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "EMP Beacon";
	damageSkinData = "objectDamageSkins";
};

function EMPBeacon::onAdd(%this)
{

	schedule("EMPBeacon::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "EMP Box");
	}
}

function EMPBeacon::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }
function EMPBeacon::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }
function EMPBeacon::onDisabled(%this) {Turret::onDisabled(%this); }
function EMPBeacon::onDestroyed(%this) {Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "EMPBeaconPack"]--; }
function EMPBeacon::onPower(%this,%power,%generator) {}
function EMPBeacon::onEnabled(%this) { schedule("EMPBeacon::checkEMPBeacon(" @ %this @ ");", 0.1, %this); }

function EMPBeacon::checkEMPBeacon(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	%Set = newObject("empset",SimSet);
	%Pos = GameBase::getPosition(%this);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself

	containerBoxFillSet(%Set, %Mask, %Pos, 35, 35, 35,0);

	%num = Group::objectCount(%Set);
	if (%num > 0)
	{
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);

		if (getObjectType(%obj) == "Player")
		{
			%armor = Player::getArmor(%obj);
		}

		if (%obj != %this && (%armor != "harmor" || %armor != "jarmor" || %armor != "barmor" || %armor != "bfemale" || %armor != "spyarmor" || %armor != "spyfemale" || %armor != "stimarmor" || %armor != "stimfemale"))
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				GameBase::applyDamage(%obj,$FlashDamageType, 0.01,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this);
				schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %obj @ "));",0.1);
			}
			else
			{
			}
		}
	}
	}
	deleteObject(%set);
	schedule("EMPBeacon::checkEMPBeacon(" @ %this @ ");", 10.0, %this); //then recheck in 10 seconds
}

//============================================================================================= Shield Beacon
TurretData ShieldBeacon
{
	className = "Turret";
	shapeFile = "bridge";
	maxDamage = 2;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Shield Beacon";
	damageSkinData = "objectDamageSkins";
};

function ShieldBeacon::onAdd(%this) { schedule("ShieldBeacon::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,5); if (GameBase::getMapName(%this) == "")  { GameBase::setMapName (%this, "Shield Box"); } }
function ShieldBeacon::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }
function ShieldBeacon::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }
function ShieldBeacon::onDisabled(%this) {Turret::onDisabled(%this); }
function ShieldBeacon::onDestroyed(%this) {Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "ShieldBeaconPack"]--; }
function ShieldBeacon::onPower(%this,%power,%generator) {}
function ShieldBeacon::onEnabled(%this) { schedule("ShieldBeacon::checkShieldBeacon(" @ %this @ ");", 0.1, %this); }
function ShieldBeacon::checkShieldBeacon(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	%Set = newObject("shieldset",SimSet);
	%Pos = GameBase::getPosition(%this);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself

	containerBoxFillSet(%Set, %Mask, %Pos, 35, 35, 35,0);

	%num = Group::objectCount(%Set);
	if (%num > 0)
	{
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		if (getObjectType(%obj) == "Player") { %armor = Player::getArmor(%obj); }
		if (%obj != %this)
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
			}
			else
			{
				%obj.shieldStrength = 0.024;
				schedule ("" @ %obj @ ".shieldStrength = 0.0 ;",15);
			}
		}
	}
	}
	deleteObject(%set);
	schedule("ShieldBeacon::checkShieldBeacon(" @ %this @ ");", 15.0, %this);
}
//=============================================== Jammer Beacon
TurretData JammerBeacon
{
	className = "Turret";
	shapeFile = "bridge";
	maxDamage = 2;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Jammer Beacon";
	damageSkinData = "objectDamageSkins";
};

function JammerBeacon::onAdd(%this) {schedule("JammerBeacon::deploy(" @ %this @ ");",1,%this);GameBase::setRechargeRate(%this,5); if (GameBase::getMapName(%this) == "")  { GameBase::setMapName (%this, "Jammer Box"); } }
function JammerBeacon::deploy(%this){GameBase::playSequence(%this,1,"deploy");}
function JammerBeacon::onEndSequence(%this,%thread){GameBase::setActive(%this,true);}
function JammerBeacon::onDisabled(%this) {Turret::onDisabled(%this); }
function JammerBeacon::onDestroyed(%this) {Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "JammerBeaconPack"]--; }
function JammerBeacon::onPower(%this,%power,%generator) {}
function JammerBeacon::onEnabled(%this) { schedule("JammerBeacon::checkJammerBeacon(" @ %this @ ");", 0.1, %this); }
function JammerBeacon::checkJammerBeacon(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled") return;

	%Set = newObject("jammerset",SimSet);
	%Pos = GameBase::getPosition(%this);
	%Mask = $StaticObjectType|$VehicleObjectType;
	containerBoxFillSet(%Set, %Mask, %Pos, 100, 100, 100,0);
	%num = Group::objectCount(%Set);
	if (%num > 0)
	{
		for(%i; %i < %num; %i++)
		{
			%obj = Group::getObject(%Set, %i);
			%data = GameBase::getDataName(%obj);
			if (gamebase::getteam(%obj) != gamebase::getteam(%this))
			{
				if (%data == "DeployableSensorJammer")
				{
					GameBase::applyDamage(%this, $ImpactDamageType, 0.15,GameBase::getPosition(%obj),"0 0 0","0 0 0",%obj);
					return;
				}
				else if (%data == "CoolProj" || %data == "NapProj" || %data == "BooProj" || %data == "EmpProj" || %data == "GasProj" || %data == "BallProj")
				{
					%obj.popped = "1";
					%passanger = %obj.tc;
					if (%passanger) GameBase::applyDamage(%passanger,$FlashDamageType, 5.0,GameBase::getPosition(%this),"0 0 0","0 0 0",%passanger);
					GameBase::setDamageLevel(%obj, 10);
				}
			}
		}
	}
	deleteObject(%set);
	schedule("JammerBeacon::checkJammerBeacon(" @ %this @ ");", 1.0, %this);
}


//=============================================
// 	Standard Turret Functions For Wasteland.
//=============================================

function Turret::onAdd(%this)
{
	if (GameBase::getMapName(%this) == "")
	{
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
   {
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

	if (GameBase::isPowered(%this))
	{
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

	if ($debug) echo ("Turret::objectiveDestroyed = Start");
		StaticShape::objectiveDestroyed(%this);
	if ($debug) echo ("Turret::objectiveDestroyed = Finish");

	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	//calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 0.1, 200, 100);
}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{

	if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%name = GameBase::getDataName(%this);

		if(%name != DeployableTurret && %name != CameraTurret && %name != DeployableSatchel && %name != DeployableMortar && %name != DeployableHolo && %name != DeployableHolo2 && %name != DeployableHolo3 && %name != DeployablePlasma && %name != DeployableLaser && %name != DeployableRocket && %name != DeployableShock)
			%TDS = $Server::TeamDamageScale;
	}
	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
}

function Turret::onControl (%this, %object)
{

	%client = Player::getClient(%object);
	systemMessage(%client,0,"Controlling turret " @ %this);
	if (GameBase::getMapName == "Satchel Charge")
	{
		GameBase::applyDamage(%this,$DebrisDamageType,20,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
	}
}

function Turret::onDismount (%this, %object)
{

	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Leaving turret " @ %this);
}

function Turret::onCollision (%this, %object)
{

	%c = Player::getClient(%object);
	%client = Player::getClient(%object);
	%playerTeam = GameBase::getTeam(%object);
	%teleTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%client);
	%player.repairTarget = %this;
	%name = GameBase::getMapName(%this);
	%team = GameBase::getTeam(%this);
	%pTeam = GameBase::getTeam(%object); //added
	%pName = Client::getName(%client); //added
	%tName = getTeamName(%team); //added

	if(%team == %pTeam)
	{
		return;
	}

	if($origTeam[%this] == "")
	{
		$origTeam[%this] = %team;
	}

	if (%client.Laptop == "True" && (%armor == "spyarmor" || %armor == "spyfemale" || %armor == "earmor" || %armor == "efemale"))
	{
		if (%client.HackPack == True)
		{
			if ($debug) echo ("Controlling");
			if(getObjectType(%object) != "Player")
			{
				return;
			}
			if(Player::isDead(%object))
			{
				return;
			}
			if(%this.disabled == true)
			{
				Client::SendMessage(%c,0,"Turret is recharging");
				return;
			}
			if(%teleTeam != %playerTeam)
			{
				if( ((Player::getArmor(%object) == "spyarmor") || (Player::getArmor(%object) == "spyfemale")) && (Player::getMountedItem(%object,$BackpackSlot) == Laptop) )
				{
					%name = GameBase::getDataName(%this);

					if(%name == "RocketTurret" || %name == "PlasmaTurret" || %name == "IndoorTurret" || %name == "ELFTurret" || %name == DeployableMortar || %name == DeployablePlasma || %name == DeployableRocket || %name == DeployableVulcan || %name ==DeployableRail || %name == MortarTurret)
					{
						if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object))
						{
							Client::getOwnedObject(%client).CommandTag = 1;
							Client::sendMessage(%client,0,"Re-programming turret.");
							GameBase::setTeam (%this,GameBase::getTeam (%client));
							schedule("GameBase::setTeam('" @ %this @ "','" @ $origTeam[%this] @ "');", $Wasteland::HackedTime);
							schedule("" @ %this @ ".disabled = false;", $Wasteland::HackedTime);
							Client::takeControl(%client, %this);
							%this.Disabled = true;
							Client::getOwnedObject(%client).CommandTag = "";
							if(%name == DeployablePlasma || %name ==  DeployableRail ) GameBase::SetPosition(%object,GameBase::GetPosition(%this));

							TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
							TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");

							return;
						}
					}
				}
				return;
			}
			if((Player::getArmor(%obj) == "efemale") || (Player::getArmor(%obj) == "earmor"))
			{
				%name = GameBase::getDataName(%this);
				if(%name == DeployableRail)
				{
					if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object))
					{
						Client::getOwnedObject(%client).CommandTag = 1;
						Client::sendMessage(%client,0,"Manually controlling turret.");
						schedule("GameBase::setTeam('" @ %this @ "','" @ $origTeam[%this] @ "');", $Wasteland::HackedTime);
						schedule("" @ %this @ ".disabled = false;", $Wasteland::HackedTime);
						Client::takeControl(%client, %this);
						GameBase::SetPosition(%object,GameBase::GetPosition(%this));
						%this.Disabled = true;
						Client::getOwnedObject(%client).CommandTag = "";
						return;
					}
				}
			}
		}
		else	//== Hack Pack Allows You To Hack Enemy Stuff! Not Just take control of turrets
		{
			if (%client.hacking == "True")
			{
				return;
			}

			if($Wasteland::AllowHacking)
			{
				%target = %this;
				if (%target != %player)
				{
					if(%name == "")
					{
						%name = (GameBase::getDataName(%player.repairTarget)).description;
					}

					%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;

					%client.hacking = "true";
					if(!$origTeam[%target])
					{
						$origTeam[%target] = %team;
					}

					hackingturret(%target, %pTeam, %pName, %tName, %name, %team, $Wasteland::HackTime, %client);
				}
			}
			else
			{
				systemMessage(%client,0,"Hacking/Infecting disabled on this server");
			}
		}
	}
	return;
}

function Turret::Reenable(%this)
{

        %this.disabled = false;
}

function hackingturret(%target, %pTeam, %pName, %tName, %name, %team, %time, %client)
{
	%pName = Client::getName(%client); // PORT (2026-10-12): the name is no longer carried through the schedule() string

	%shape = (GameBase::getDataName(%target)).shapeFile;

	if(%time > 0)
	{
		systemMessage(%client,0,"Hacking In Progress - Time Remaining " @ %time);
		if(%client.hacking)
		{
			schedule("hackingturret('" @ %target @ "','" @ %pTeam @ "','" @ %client @ "','" @ %tName @ "','" @ %name @ "','" @ %team @ "','" @ %time - 1 @ "','" @ %client @ "');", 1);
		}
	}
	else
	{
		systemMessage(Player::getClient(%client),0,("Finished In " @ %time @ "."));

		if (%client.Laptop == "True")
		{
			if(%client.hacking)
			{

				if (%target.infected == "true")
				{
					%rnd = floor(getRandom() * 100);

					if (%rnd > 50)
					{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						systemMessage(%client,1,"You disarm the protection virus in the " @ %name @ ", but it costs you!!!");
						%player = Client::getOwnedObject(%client);
						if ($debug) echo (%player);
						GameBase::applyDamage(%player,$FlashDamageType,0.90,GameBase::getPosition(%player),"0 0 0","0 0 0",%target);
						%target.infected = "false";
						return;
					}
					else
					{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						systemMessage(%client,1,"You safely disarm the protection virus in the " @ %name @ ".");
						%target.infected = "false";
						return;
					}
				}
				else
				{

					TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
					TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");
					GameBase::setTeam(%target,%pTeam);

					if($Wasteland::HackedTime > 0)
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", $Wasteland::HackedTime);
						schedule("" @ %target @ ".disabled = false;", $Wasteland::HackedTime);
					}
					else
					{
						schedule("" @ %target @ ".disabled = false;", $Wasteland::HackLock);
					}

					if(%target < $minHacked || $minHacked == -1)
					{
						$minHacked = %target;
					}
					if(%target > $maxHacked || $maxHacked == -1)
					{
						$maxHacked = %target;
					}

				}
				if ($debug) echo ("Client Hacking Off");
				%client.hacking = "false";
			}
		}
	}
}

function Turret::Jump (%this, %object)
{

	%client = GameBase::getControlClient(%this);
	%name = GameBase::getDataName(%this);

	if(%name == DeployableCoolMortar)
	{
		if(%this.load != "")
		{
			Player::unMountItem(%client,$WeaponSlot);

			%trans = GameBase::getMuzzleTransform(%this);
			$Faky = %this;
			$Faky2 = GameBase::getPosition(%this);
			Projectile::spawnProjectile("Faker",%trans,%this,"0 0 0");
		}
		else
		{
			systemMessage(%client,0,"Missile Turret is not loaded.");
		}
	}
	else
	{
		remoteCommandMode(%client);
		remotePlayMode(%client);
	}
}
//====== ElectricWeb PlasmaDoorTurr

TurretData PlasmaDoorTurr
{
	className = "Turret";
	shapeFile = "plasmawall";
	disableCollision = true;
	maxDamage = 8;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = false;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Electric Web";
	damageSkinData = "objectDamageSkins";
};

function PlasmaDoorTurr::onAdd(%this)
{

	schedule("PlasmaDoorTurr::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "EMP Box");
	}
}

function PlasmaDoorTurr::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }
function PlasmaDoorTurr::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }
function PlasmaDoorTurr::onDisabled(%this) { Turret::onDisabled(%this); }
function PlasmaDoorTurr::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "ElectricFloor"]--; $TeamItemCount[GameBase::getTeam(%this) @ "ElectricWeb"]--; }
function PlasmaDoorTurr::onPower(%this,%power,%generator) {}
function PlasmaDoorTurr::onEnabled(%this) { schedule("PlasmaDoorTurr::checkPlasmaDoorTurr(" @ %this @ ");", 0.1, %this); }

function PlasmaDoorTurr::checkPlasmaDoorTurr(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
		return;
	%client = %this.tc;
	%Set = newObject("empset",SimSet);
	%Pos = GameBase::getPosition(%this);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself

	containerBoxFillSet(%Set, %Mask, %Pos, 4, 4, 3,0);

	%num = Group::objectCount(%Set);
	if (%num > 0)
	{
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);

		if (getObjectType(%obj) == "Player")
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				GameBase::applyDamage(%obj,$PlasmaWallDam, 0.01,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this);
				GameBase::applyDamage(%obj,$FlashDamageType, 0.1,GameBase::getPosition(%obj),"0 0 0","0 0 0",%client);
				schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %obj @ "));",0.1);
			}
			else
			{
			}
		}
	}
	}
	deleteObject(%set);
	schedule("PlasmaDoorTurr::checkPlasmaDoorTurr(" @ %this @ ");", 0.1, %this); //then recheck in 0.1 seconds
}

//====== Booby Trap1 is a punji spike mine, see mines

//====== Booby Trap2 is a lasso trap, see mines

//====== Booby Trap3 Scary trap

TurretData TrapPad3
{
	className = "Turret";
	shapeFile = "force";
	maxDamage = 3;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundPackFail };
	visibleToSensor = false;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Booby Trap Trigger";
	damageSkinData = "objectDamageSkins";
};

function TrapPad3::onAdd(%this)
{

	schedule("TrapPad3::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "EMP Box");
	}
}

function TrapPad3::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }
function TrapPad3::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }
function TrapPad3::onDisabled(%this) { Turret::onDisabled(%this); }
function TrapPad3::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "TrapPack3"]--; }
function TrapPad3::onPower(%this,%power,%generator) {}
function TrapPad3::onEnabled(%this) { schedule("TrapPad3::checkTrapPad3(" @ %this @ ");", 0.1, %this); }

function TrapPad3::checkTrapPad3(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
		return;
	%client = %this.tc;
	%Set = newObject("empset",SimSet);
	%Pos = GameBase::getPosition(%this);
	%Mask = $SimPlayerObjectType;

	containerBoxFillSet(%Set, %Mask, %Pos, 12, 12, 6,0);

	%num = Group::objectCount(%Set);
	if (%num > 0)
	{
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		if (getObjectType(%obj) == "Player")
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				GameBase::applyDamage(%obj,$TrapDam3, 0.01,GameBase::getPosition(%obj),"0 0 0","0 0 0",%client);
			}
			else
			{
			}
		}
	}
	}
	deleteObject(%set);
	schedule("TrapPad3::checkTrapPad3(" @ %this @ ");", 3, %this); //then recheck in 0.1 seconds
}
//====== Booby Trap4  Sand Trap

TurretData TrapPad4
{
	className = "Turret";
	shapeFile = "force";
	maxDamage = 3;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundPackFail };
	visibleToSensor = false;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Booby Trap Trigger";
	damageSkinData = "objectDamageSkins";
};

function TrapPad4::onAdd(%this)
{

	schedule("TrapPad4::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "EMP Box");
	}
}

function TrapPad4::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }
function TrapPad4::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }
function TrapPad4::onDisabled(%this) { Turret::onDisabled(%this); }
function TrapPad4::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "TrapPack4"]--; }
function TrapPad4::onPower(%this,%power,%generator) {}
function TrapPad4::onEnabled(%this) { schedule("TrapPad4::checkTrapPad4(" @ %this @ ");", 0.1, %this); }

function TrapPad4::checkTrapPad4(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
		return;
	%client = %this.tc;
	%Set = newObject("empset",SimSet);
	%Pos = GameBase::getPosition(%this);
	%Mask = $SimPlayerObjectType;

	containerBoxFillSet(%Set, %Mask, %Pos, 7, 7, 6,0);

	%num = Group::objectCount(%Set);
	if (%num > 0)
	{
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);

		if (getObjectType(%obj) == "Player")
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				GameBase::applyDamage(%obj,$TrapDam4, 0.01,GameBase::getPosition(%obj),"0 0 0","0 0 0",%client);
			}
			else
			{
			}
		}
	}
	}
	deleteObject(%set);
	schedule("TrapPad4::checkTrapPad4(" @ %this @ ");", 0.1, %this); //then recheck in 0.1 seconds
}
//====== Booby Trap5 - Stun Trap

TurretData TrapPad5
{
	className = "Turret";
	shapeFile = "force";
	maxDamage = 3;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundPackFail };
	visibleToSensor = false;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Booby Trap Trigger";
	damageSkinData = "objectDamageSkins";
};

function TrapPad5::onAdd(%this)
{

	schedule("TrapPad5::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "EMP Box");
	}
}

function TrapPad5::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }
function TrapPad5::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }
function TrapPad5::onDisabled(%this) { Turret::onDisabled(%this); }
function TrapPad5::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "TrapPack5"]--; }
function TrapPad5::onPower(%this,%power,%generator) {}
function TrapPad5::onEnabled(%this) { schedule("TrapPad5::checkTrapPad5(" @ %this @ ");", 0.1, %this); }

function TrapPad5::checkTrapPad5(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
		return;
	%client = %this.tc;
	%Set = newObject("empset",SimSet);
	%Pos = GameBase::getPosition(%this);
	%Mask = $SimPlayerObjectType;

	containerBoxFillSet(%Set, %Mask, %Pos, 13, 13, 6,0);

	%num = Group::objectCount(%Set);
	if (%num > 0)
	{
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);

		if (getObjectType(%obj) == "Player")
		{
			%damagedClient = Player::getClient(%obj);
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) )
			{
				if (%obj.tc != tied) MessageAll( 0, Client::getName(%damagedClient) @" is stunned by "@Client::getName(%client)@"'s Stun Trap!~wgenerator.wav"); 
				%obj.tc = tied;
				Client::setControlObject(%damagedClient, Client::getObserverCamera(%damagedClient));
				Observer::setOrbitObject(%damagedClient, %obj, 3, 3, 3);
				$Admin = Client::getName(%client)@" stunned "@Client::getName(%damagedClient);
				echo($admin);
				centerprint(%damagedClient, "<jc><f1>You are stunned by "@Client::getName(%client)@"'s StunTrap!", 5);
				Client::sendMessage(%damagedClient,0,"~wgenerator.wav");
				%client.score = %client.score +1;
  				Bottomprint(%client, "<jc>Stun Trap Success! Score +2 = " @ %client.score ,3);
			}
			else
			{
			}
		}
	}
	}
	deleteObject(%set);
	schedule("TrapPad5::checkTrapPad5(" @ %this @ ");", 3, %this); //then recheck in 3 seconds
}

//gaschamber turr
TurretData GasTurr
{
	className = "Turret";
	shapeFile = "breath";
	disableCollision = true;
	maxDamage = 10000;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = false;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Gas Nozzle";
	damageSkinData = "objectDamageSkins";
};

function GasTurr::onAdd(%this)
{

	schedule("GasTurr::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "EMP Box");
	}
}

function GasTurr::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }
function GasTurr::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }
function GasTurr::onDisabled(%this) { Turret::onDisabled(%this); }
function GasTurr::onPower(%this,%power,%generator) {}
function GasTurr::onEnabled(%this) { schedule("GasTurr::checkGasTurr(" @ %this @ ");", 0.1, %this); }

function GasTurr::checkGasTurr(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
		return;
	%client = %this.tc;
	%Set = newObject("empset",SimSet);
	%Pos = GameBase::getPosition(%this);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$MineObjectType;

	containerBoxFillSet(%Set, %Mask, %Pos, 4, 4, 4.5,0);

	%num = Group::objectCount(%Set);
	if (%num > 0)
	{
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		if (getObjectType(%obj) == "Player" || getObjectType(%obj) == "StaticShape") GameBase::applyDamage(%obj,$CrushDamageType, 0.1,GameBase::getPosition(%obj),"0 0 0","0 0 0",%client);
		if (getObjectType(%obj) == "Player")
		{
			%client.score = (%client.score +2);
  			Bottomprint(%client, "<jc><f2>Energy Trap Success: crushing your prey now!  Score +2 = " @ %client.score ,3);
		}
	}
	}
	deleteObject(%set);
	schedule("GasTurr::checkGasTurr(" @ %this @ ");", 5, %this); //then recheck in 5 seconds
}

//Acid Turret
TurretData AcidTurret
{
	className = "Turret";
	shapeFile = "tumult_small";
	disableCollision = true;
	maxDamage = 100;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = false;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisSmall;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = blasterExp;
	description = "Acid";
	damageSkinData = "objectDamageSkins";
};

function AcidTurret::onAdd(%this)
{

	schedule("AcidTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Acid");
	}
}

function AcidTurret::deploy(%this)
	{
		GameBase::playSequence(%this,1,"deploy");
		schedule("Grenade::Plastic_Detonate( " @ %this @ " );", 8);
	}
function AcidTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }
function AcidTurret::onDisabled(%this) { Turret::onDisabled(%this); }
function AcidTurret::onPower(%this,%power,%generator) {}
function AcidTurret::onEnabled(%this) { schedule("AcidTurret::checkAcid(" @ %this @ ");", 0.1, %this); }

function AcidTurret::checkAcid(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
		return;
	%client = %this.tc;
	%Set = newObject("acidset",SimSet);
	%Pos = GameBase::getPosition(%this);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$MineObjectType|$VehicleObjectType;

	containerBoxFillSet(%Set, %Mask, %Pos, 1, 1, 1,0);

	%num = Group::objectCount(%Set);
	if (%num > 0)
	{
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		GameBase::applyDamage(%obj,$PlasmaDamageType, 0.1,GameBase::getPosition(%obj),"0 0 0","0 0 0",%client);
	}
	}
	deleteObject(%set);
	schedule("AcidTurret::checkAcid(" @ %this @ ");", 1, %this); //then recheck in 1 seconds
}

//============================================Sentry
TurretData SentryTurret
{
	maxDamage = 1.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 25;
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
	projectileType = jailbolt;
	reloadDelay = 2.0;
	explosionId = LargeShockwave;
	description = "Sentry";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;
};

function SentryTurret::onAdd(%this)
{

	schedule("SentryTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.008;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Sentry");
}

function SentryTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function SentryTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function SentryTurret::onDestroyed(%this)
{

    	Gamebase::setActive(%this,false);
	GameBase::setRechargeRate(%this,0);
  	$TeamItemCount[GameBase::getTeam(%this) @ "Sentry"]--;
	schedule("Turret::onDestroyed("@%this@");",0.8,%this);
}

function SentryTurret::onPower(%this,%power,%generator) {
}

function SentryTurret::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,20);
	GameBase::setActive(%this,true);
}

//========================Malice Cannon

TurretData MaliceTurret 
{	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = IrradiationBlast;
	accuFire = false;
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 1;
	maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.05;
	aimDeflection = 0.0004;
	speed = 4.0;
	speedModifier = 1.5;
	range = 0;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireMortar2;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	explosionId = flashExpMedium;
	description = "Hellacious Cannon";
	damageSkinData = "objectDamageSkins";
};

function MaliceTurret::onAdd(%this) 
{	schedule("MaliceTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Hellacious Cannon");
}

function MaliceTurret::deploy(%this) 
{	GameBase::playSequence(%this,1,"deploy");
}

function MaliceTurret::onEndSequence(%this,%thread) 
{	GameBase::setActive(%this,true);
}

function MaliceTurret::onDestroyed(%this)
{
	%cltur = GameBase::getControlClient(%this); 	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	Turret::objectiveDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "MalicePack"]--;
	Player::setMountObject(%cltur, -1, 0);
	Client::setControlObject(%cltur, %cltur);
}

function MaliceTurret::onPower(%this,%power,%generator) 
{
}

function MaliceTurret::onEnabled(%this) 
{	GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}
function MaliceTurret::onCollision(%this, %player)
{			
	%prot = GameBase::getRotation(%player);
	%basevec = "0 -0.5 0";
	%npos = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( %basevec, %prot ) );
	GameBase::setPosition(%player,%npos);
	%cltur = GameBase::getControlClient(%this);
	%client = Player::getClient(%player);
	if (%cltur != %client)
	{
		Player::setMountObject(%cltur, -1, 0);
		Client::setControlObject(%cltur, %cltur);
		Client::setControlObject(%client, %this);
 		centerprint(%cltur, "             <Btower_enemycontrol.bmp> You lose control of the Hellacious Turret! <Btower_enemycontrol.bmp> ");
		systemMessage(%cltur,1,"~wError_Message.wav");
	}
	else {}
}

//==================  Repair Post

TurretData RepairPost
{
	className = "ELF Turret";
	shapeFile = "camera";
	projectileType = RepPostBolt;
	maxDamage = 10000;
	maxEnergy = 30;
	minGunEnergy = 5;
	maxGunEnergy = 1;
	range = 40;
	visibleToSensor = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	//mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	speed = 15.0;
	speedModifier = 1.5;
	reloadDelay = 0;
	explosionId = LargeShockwave;
	description = "AvPinoy Repair Post";
	fireSound        = SoundRepairItem;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;
	isSustained     = true;
	firingTimeMS    = 5000;
 	energyRate      = 1.0;
};
function RepairPost::onAdd(%this)
{
	schedule("RepairPost::targetcheck(" @ %this @ ");", 1.5, %this);
}

function RepairPost::verifyTarget(%this,%target)
{
	%client = %this.beam;
	if (getObjectType(%target) == "Player" && GameBase::getDamageLevel(%target) > 0 && gamebase::getteam(%target) == gamebase::getteam(%client))
		return "True";
	else
		return "False";
}

function RepairPost::targetcheck(%this)
{
	%client = %this.beam;
	if(GameBase::getDamageState(%this) == "Enabled")
	{
		%Set = newObject("taregtcheckset",SimSet);
		%Pos = GameBase::getPosition(%this);
		%Mask = $StaticObjectType|$SimPlayerObjectType;
		containerBoxFillSet(%Set, %Mask, %Pos, 60, 60, 60,0);
		%num = Group::objectCount(%Set);
		if (%num > 0 )
		{
		   for(%i; %i < %num; %i++)
		   {
			%obj = Group::getObject(%Set, %i);
			if (gamebase::getteam(%obj) == gamebase::getteam(%client) || %obj == %this)
			{
				if (getObjectType(%obj) == "Player")
				{
					if (%obj.swim>120)//== needs oxygen badly
					{
						%obj.swim = 1;
						%cl = gamebase::getClient(%obj);
						if (Client::getGender(%cl) == "Female") systemMessage(%cl,0,"~wfemale4.wcolor3.wav");
						else systemMessage(%cl,0,"~wmale2.wcolor3.wav");
  						Bottomprint(%cl, "<jc>Oxygenated by Repair Prism");
					}
					deleteObject(%set);
					schedule("RepairPost::targetcheck(" @ %this @ ");", 1.5, %this);
					return;
				}
				else if (GameBase::getDamageLevel(%obj) > 0)
				{
					GameBase::repairDamage(%obj,0.02);
					schedule ("playSound(ForceFieldOpen,GameBase::getPosition(" @ %obj @ "));",0.1);
					%i=%num;
				}
			}
	  	   }
		}
		deleteObject(%set);
	}
	schedule("RepairPost::targetcheck(" @ %this @ ");", 1.5, %this);
}

function RepairPost::onDestroyed(%this)
{
	TeamMessages(1, GameBase::getTeam(%this.beam), "Repair Pyramid Lost.~wfloat_explode.wav");
	Turret::onDestroyed(%this);
	Grenade::Plastic_Detonate(%this.beam);
}

//==================  Disrupting/Disturbing Pyramid

TurretData Prism
{
	className = "ELF Turret";
	shapeFile = "camera";
	projectileType = PrismBolt;
	maxDamage = 10000;
	maxEnergy = 30;
	minGunEnergy = 5;
	maxGunEnergy = 1;
	range = 200;
	visibleToSensor = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	speed = 15.0;
	speedModifier = 1.5;
	reloadDelay = 0;
	explosionId = LargeShockwave;
	description = "Disrupting Prism";
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;
	isSustained     = true;
	firingTimeMS    = 5000;
 	energyRate      = 1.0;
};

function Prism::onDestroyed(%this)
{
  	$TeamItemCount[GameBase::getTeam(%this.beam) @ "PrismPack"]--;
	Turret::onDestroyed(%this);
	Grenade::Plastic_Detonate(%this.beam);
}

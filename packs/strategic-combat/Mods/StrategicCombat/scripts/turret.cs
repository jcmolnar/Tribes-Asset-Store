//*********************
exec(combatTurrets);

TurretData PlasmaTurret
{
	maxDamage = 4.0;
	maxEnergy = 150;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	reloadDelay = 0.8;
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 110;
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

//*******************************
TurretData DeployablePlasmaTurret
{
	maxDamage = 2.5;
	maxEnergy = 100;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	reloadDelay = 0.8;
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 110;
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

function DeployablePlasmaTurret::onAdd(%this)
{
	schedule("DeployablePlasmaTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.025;	// 0.01;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "RemotePlasmaCannon");
}

function DeployablePlasmaTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployablePlasmaTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployablePlasmaTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "RemotePlasmaTurret"]--;
}

// Override base class just in case.
function DeployablePlasmaTurret::onPower(%this,%power,%generator) {}
function DeployablePlasmaTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.025;	// 0.01;
	GameBase::setActive(%this,true);
}	

//******************
TurretData ELFTurret	   
{			 
	maxDamage = 2.0;
	maxEnergy = 175;
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
	className = "ELF Turret";
	shapeFile = "chainturret";
	shieldShapeName = "shield";
	speed = 20.0;
	speedModifier = 1.5;
	projectileType = turretCharge;
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

function ELFTurret::onPower(%this,%power,%generator)
{
	if(%power) 
	{
		%this.shieldStrength = 0.015;
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

function ELFTurret::onEnabled(%this)
{
	if(GameBase::isPowered(%this)) 
	{
		%this.shieldStrength = 0.015;
		GameBase::setRechargeRate(%this,10);
		GameBase::setActive(%this,true);
	}
}

//****************************
TurretData DeployableELFTurret
{			 
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
	className = "ELF Turret";
	shapeFile = "chainturret";
	shieldShapeName = "shield";
	speed = 15.0;
	speedModifier = 1.5;
	projectileType = turretCharge;
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
  	$TeamItemCount[GameBase::getTeam(%this) @ "RemoteELF"]--;    
	schedule("Turret::onDestroyed("@%this@");",0.8,%this);
}

// Override base class just in case.
function DeployableELFTurret::onPower(%this,%power,%generator) {}
function DeployableELFTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.008;
	GameBase::setActive(%this,true);
}	

//*********************
TurretData RocketTurret
{
	maxDamage = 1.75;
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
	if(%power) 
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
   if(GameBase::virtual(%target, "getHeatFactor") >= 0.5) return "True";
   else return "False";
}

//********************************
TurretData DeployableMissileTurret
{
	maxDamage = 1.75;
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

function DeployableMissileTurret::verifyTarget(%this,%target)
{
   if(GameBase::virtual(%target, "getHeatFactor") >= 0.5) return "True";
   else return "False";
}

function DeployableMissileTurret::onAdd(%this)
{
	schedule("DeployableMissileTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,14);
	%this.shieldStrength = 0.03;	// 0.02;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Missile Turret");
}

function DeployableMissileTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableMissileTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableMissileTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MissileTurret"]--;
}

// Override base class just in case.
function DeployableMissileTurret::onPower(%this,%power,%generator) {}
function DeployableMissileTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,14);
	%this.shieldStrength = 0.03;	// 0.02;
	GameBase::setActive(%this,true);
}	

//*****************
TurretData AACannon
{
	maxDamage = 2.5;
	maxEnergy = 100;
	minGunEnergy = 0;
	maxGunEnergy = 0;
	range = 325;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "hellfiregun";
	shieldShapeName = "shield_medium";
	speed = 15.0;
	speedModifier = 1.5;
	projectileType = ChaingunBullet;
	reloadDelay = 0.45;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Anti Aircraft Cannon";
};

function AACannon::verifyTarget(%this,%target)
{
   if(GameBase::virtual(%target, "getHeatFactor") >= 0.5) return "True";
   else return "False";
}
function AACannon::onAdd(%this)
{
	schedule("AACannon::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.04;	// 0.02;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "RemoteAACannon");
}

function AACannon::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function AACannon::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function AACannon::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "RemoteAACannon"]--;
}

// Override base class just in case.
function AACannon::onPower(%this,%power,%generator) {}
function AACannon::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.04;	// 0.02;
	GameBase::setActive(%this,true);
}	

//---------------------
TurretData MortarTurret
{
	maxDamage = 2.0;
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
																						 
//---------------------
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
	speed = 15.0;
	speedModifier = 1.0;
	range = 35;
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

//***************************
TurretData DeployableChaingun
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = VRPBullet;
	maxDamage = 0.85;
	maxEnergy = 100;
	minGunEnergy = 0;
	maxGunEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.15;
	speed = 4.0;
	speedModifier = 1.5;
	range = 50;
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
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpSmall;
	description = "Chaingun Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableChaingun::onAdd(%this)
{
	schedule("DeployableChaingun::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,50);
	%this.shieldStrength = 0;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "ChaingunTurret");
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
  	$TeamItemCount[GameBase::getTeam(%this) @ "ChaingunTurret"]--;
}

// Override base class just in case.
function DeployableChaingun::onPower(%this,%power,%generator) {}
function DeployableChaingun::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,50);
	GameBase::setActive(%this,true);
}	

//*****************************
TurretData DeployableAutoCannon
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = HEAPShell;
	maxDamage = 2.5;
	maxEnergy = 90;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 1.4;
	speed = 4.0;
	speedModifier = 2.0;
	range = 130;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield_medium";
	fireSound = shockExplosion;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = LargeShockwave;
	description = "Remote AutoCannon";
	damageSkinData = "objectDamageSkins";
};

function DeployableAutoCannon::onAdd(%this)
{
	schedule("DeployableAutoCannon::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.04;	// 0.03;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "RemoteAutoCannon");
}

function DeployableAutoCannon::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableAutoCannon::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableAutoCannon::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "RemoteAutoCannon"]--;
}

// Override base class just in case.
function DeployableAutoCannon::onPower(%this,%power,%generator) {}
function DeployableAutoCannon::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.04;	// 0.03;
	GameBase::setActive(%this,true);
}	

//*************************
TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = MiniFusionBolt;
	maxDamage = 1.8;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 35;
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
	GameBase::setRechargeRate(%this,8);
	%this.shieldStrength = 0;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Remote Turret");
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
	GameBase::setRechargeRate(%this,8);
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
	range = 100;
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
	if (GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Camera");
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

//********************
TurretData LaserTurret
{
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 0.45;
	maxEnergy = 90;
	minGunEnergy = 90;
	maxGunEnergy = 90;

	projectileType = turretLaser;
	reloadDelay = 5.0;
	fireSound = SoundFireLaser;

	speed = 4.0;
	speedModifier = 1.0;
	range = 75;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = defaultDebrisSmall;
	pinger = false;
	explosionId = debrisExpMedium;
	description = "Laser Turret";
};

function LaserTurret::onAdd(%this)
{
	schedule("LaserTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "LaserTurret");
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

// Override base class just in case.
function LaserTurret::onPower(%this,%power,%generator) {}
function LaserTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}	


//---------------------------
function Turret::onAdd(%this)
{
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Turret");
}

function Turret::onActivate(%this)
{
	GameBase::playSequence(%this,0,power);
}

function Turret::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
	Turret::checkOperator(%this);
	Turret::checkPower(%this);
}

function Turret::onSetTeam(%this,%oldTeam)
{
	if(GameBase::getTeam(%this) != Client::getTeam(GameBase::getControlClient(%this))) Turret::checkOperator(%this);

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
	if(%power) 
	{
		%this.shieldStrength = 0.025;
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
	if(GameBase::isPowered(%this)) 
	{
		%this.shieldStrength = 0.025;
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
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 0.1, 200, 100,%this);
}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	//DAMAGE MODE
	if($Combat::DamageMode == "custom") %value = CustomDamageMode(%value,%type);
	else %value *= $Combat::DamageScale;

	if(%this.objectiveLine) %this.lastDamageTeam = GameBase::getTeam(%object);

	%TDS = 1;
	if (GameBase::getTeam(%object) == GameBase::getTeam(%this))		%TDS = $server::TeamDamageScale;

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

// function Turret::onCollision (%this, %object)
// {
// 	if(getObjectType (%object) == "Player")	Player::mountObject (%object, %this);
// }

function Turret::objectiveDestroyed(%this)
{
}

function Turret::checkPower(%this)
{
	if(!$Combat::NoAutoRepair) {
		if(GameBase::isPowered(%this)) schedule("Turret::autoRepair("@%this@");",40,%this);
		else schedule("Turret::checkPower("@%this@");",20,%this);
	}
}

function Turret::autoRepair(%this)
{
  if(GameBase::isPowered(%this) && GameBase::getDamageState(%this) != "Enabled")
   {
    %damage = GameBase::getDamageLevel(%this);
    GameBase::setDamageLevel(%this,%damage * 0.95);
    schedule("Turret::autoRepair("@%this@");",40,%this);
   }
}
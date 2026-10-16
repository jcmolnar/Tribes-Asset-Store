// TURRET DYNAMIC DATA
//=============================================================================================================================
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
																						 
//=============================================================================================================================
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

//=============================================================================================================================
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

//====================================================================================================
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
//===================================================================================================
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
	range = 150;
	visibleToSensor = true;
	shadowDetailMask = 4;
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
	if (GameBase::getMapName(%this) == "") {
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

// Override base class just in case.
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
 
																						 
//========================================================================================================
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


//====================================================================================================== Ion Turret
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
function DeployableTurret::onPower(%this,%power,%generator) {}
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


//========================================================================================================= Laser Mine
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
	reloadDelay = 7.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 75;
	visibleToSensor = flase;
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
	schedule("DeployableLaserM::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,15);
	%this.shieldStrength = 0;
	
	if (GameBase::getMapName(%this) == "") 
	{
		GameBase::setMapName (%this, "Point Defense Laser Mine");
	}
}

function DeployableLaserM::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function DeployableLaserM::deploy(%this)
{
	schedule("DeployableLaserM::deploy(" @ %this @ ");",1,%this);
    schedule("RemoveDLM(" @ %this @ ", " @ data.maxDamage @ ");",25,%this); // Live For 90 Seconds

	GameBase::playSequence(%this,1,"deploy");
}

function RemoveDLM(%this, %damage)
{
	echo("Removing Laser Mine");
		GameBase::setDamageLevel(%this, 5.0);
		//Turret::onDestroyed(%this);

}



function DeployableLaserM::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableLaserM::onDestroyed(%this)
{
	GameBase::setDamageLevel(%this, %data.maxDamage);
	Turret::onDestroyed(%this);

}

function DeployableLaserM::onPower(%this,%power,%generator) {}
function DeployableLaserM::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,3);
	GameBase::setActive(%this,true);
}	


//===================================================================================================== EMP Turret
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
function DeployableShock::onPower(%this,%power,%generator) {}
function DeployableShock::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//================================================================================================== Satchel
TurretData DeployableSatchel
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = SatchelShell;
	maxDamage = 0.1;
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

function DeployableSatchel::onAdd(%this)
{
	schedule("DeployableSatchel::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Satchel Charge");
	}
}

function DeployableSatchel::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableSatchel::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}
function DeployableSatchel::onControl(%this)
{
	DeployableSatchel::onDestroyed(%this);
}

function DeployableSatchel::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	//Turret::objectiveDestroyed(%this);
	CalcRadiusDamage(%this,$DebrisDamageType,30,0.2,25,20,20,1.5,0.5,200,100);

  	$TeamItemCount[GameBase::getTeam(%this) @ "SatchelPack"]--;
}

// Override base class just in case.
function DeployableSatchel::onPower(%this,%power,%generator) {}
function DeployableSatchel::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//================================================================================================ Deployable Elf Turret
TurretData DeployableElfTurret
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = lightningCharge2;

	maxDamage = 0.35;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	range = 30;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	reloadDelay = 0.3;
	explosionId = flashExpMedium;
	description = "ELF Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 4;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;

};

function DeployableElfTurret::onAdd(%this)
{
	schedule("DeployableElfTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Deployable Elf Turret");
	}
}

function DeployableElfTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableElfTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableElfTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableElf"]--;
}
function DeployableElfTurret::onPower(%this,%power,%generator) {}
function DeployableElfTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//======================================================================================================= Rocket 

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
	description = "Remote Rocket";
	damageSkinData = "objectDamageSkins";
};

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

//=============================================================================================================
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
	$TeamItemCount[GameBase::getTeam(%player) @ "EngBeacons"]--;  	
}	

//=========================================================================================================
// 					Standard Turret Functions For Shifter.
//=========================================================================================================

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
	if ($Shifter::BotVersion)	BotFuncs::AddRepairTask(%this);            //Werewolf

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
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
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


function Turret::onDismount (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Leaving turret " @ %this);
}

function Turret::onCollision (%this, %object)
{
	$Shifer::HackTime = 190;
	$Shifter::HackedTime = 30;
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
	
	if(!$origTeam[%this])
	{
		$origTeam[%this] = %team;
	}		
	
	if (%client.Laptop == "True" && (%armor == "spyarmor" || %armor == "spyfemale" || %armor == "earmor" || %armor == "efemale"))
	{
		if (%client.HackPack == True)
		{
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
							Client::sendMessage(%client,0,"Re-programming turret");
							GameBase::setTeam (%this,GameBase::getTeam (%client));
							schedule("GameBase::setTeam('" @ %this @ "','" @ $origTeam[%this] @ "');", $Shifter::HackedTime);
							schedule("" @ %this @ ".disabled = false;", $Shifter::HackedTime);
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
						Client::sendMessage(%client,0,"Manually controlling turret");
						schedule("GameBase::setTeam('" @ %this @ "','" @ $origTeam[%this] @ "');", $Shifter::HackedTime);
						schedule("" @ %this @ ".disabled = false;", $Shifter::HackedTime);
						Client::takeControl(%client, %this);
						GameBase::SetPosition(%object,GameBase::GetPosition(%this));
						%this.Disabled = true;
						Client::getOwnedObject(%client).CommandTag = "";
						return;
					}
				}
			}
		}
		else			//== Hack Pack Allows You To Hack Enemy Stuff! Not Just take control of turrets
		{
			if (%client.hacking == "True")
			{
				return;
			}
			
			$Shifter::AllowHacking = "True";
			
			if($Shifter::AllowHacking)
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
				
					hackingturret(%target, %pTeam, %pName, %tName, %name, %team, $Shifer::HackTime, %client);
				}	
			}
			else
			{
				Client::sendMessage(%client,0,"Hacking/Infecting disabled on this server");
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
	%shape = (GameBase::getDataName(%target)).shapeFile;
	if(%time > 0)
	{
		if(%client.hacking)
		{		
			schedule("hackingturret('" @ %target @ "','" @ %pTeam @ "',\"" @ escapeString(%pName) @ "\",\"" @ escapeString(%tName) @ "\",\"" @ escapeString(%name) @ "\",'" @ %team @ "','" @ %time - 1 @ "','" @ %client @ "');", 1);
		}
	}
	else
	{
		Client::sendMessage(Player::getClient(%client),0,("Finished In " @ %time @ "."));

		if (%client.Laptop == "True")
		{		
			if(%client.hacking)
			{				
				if($isInfected[%target]) 
				{
					showDeathAnim(%client);	Player::Kill(%client);
					messageallexcept(%client,0,%pName @ " thought it would be safe to hack the infected " @ %name @ ".");
					%randNum = getRandom() * 100;
					if(%randNum >= 50)
					{
						$isInfected[%target] = "false";
						Client::sendMessage(%client,0,"The viral infection was destroyed for the price of your life.");
					}
					else
					{
						Client::sendMessage(%client,0,"Your hacking attempt wasn't able to destroy the virus. What a pitiful waste of life.");
					}
					return 1;
				}
				else
				{

					TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
					TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");
					GameBase::setTeam(%target,%pTeam);

					if($Shifter::HackedTime)
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", $Shifter::HackedTime);
						schedule("" @ %target @ ".disabled = false;", $Shifter::HackedTime);
					}
					else
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", "120");
						schedule("" @ %target @ ".disabled = false;", $Shifter::HackedTime);
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
				echo ("Client Hacking Off");
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
			%trans = GameBase::getMuzzleTransform(%this);
			$Faky = %this;
			$Faky2 = GameBase::getPosition(%this);
			Projectile::spawnProjectile("Faker",%trans,%this,"0 0 0");
		}
		else
		{
			Client::sendMessage(%client,0,"Missile Turret is not loaded.");
		}
	}
	else
	{
		remoteCommandMode(%client);
		remotePlayMode(%client);
	}
}
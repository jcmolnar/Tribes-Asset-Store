// TURRET DYNAMIC DATA
//=============================================================================================================================
TurretData PlasmaTurret
{
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	reloadDelay = 0.8;  //was 0.8
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
	projectileType = PlasmaCannonBolt;  //was FusionBolt
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
	minGunEnergy = 30;  //was 60
	maxGunEnergy = 30;  //was 60
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
	speed = 3.0;  //was 2
	speedModifier = 1.5;  //was 2
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

//====================================================================================================
TurretData MortarTurret
{
	maxDamage = 1.25;
	maxEnergy = 75;
	minGunEnergy = 25;
	maxGunEnergy = 100;
	reloadDelay = 1.0;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 150;				//0, modified as a test
	gunrange = 200;				//added as a test
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
	projectileType = FgcShell;  //MortarTurretShell
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Nuke Turret";  //was Mortar Turret
};
//===================================================================================================
TurretData DeployableMortar
{
	className = "Turret";
	shapeFile = "mortar_turret";
	projectileType = "MortarShell";
	maxDamage = 1.0;
	maxEnergy = 100;
	minGunEnergy = 1;
	maxGunEnergy = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay =0.7;
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
	%this.shieldStrength = 0.02;
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
 
																						 
//===================================================================================================
TurretData DeployableFrag
{
	className = "Turret";
	shapeFile = "mortar_turret";
	projectileType = "BomberShell1";
	maxDamage = 1.0;
	maxEnergy = 100;
	minGunEnergy = 1;
	maxGunEnergy = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.7;
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
	description = "Remote Frag Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableFrag::onAdd(%this)
{
	schedule("DeployableFrag::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Frag Turret");
	}
}

function DeployableFrag::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableFrag::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableFrag::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "FragPack"]--;
}


function DeployableFrag::onFire(%a, %b, %c, %d)
{
	echo ("Frag Turret");
}

// Override base class just in case.
function DeployableFrag::onPower(%this,%power,%generator) {}
function DeployableFrag::onEnabled(%this) 
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
 
																						 
//===================================================================================================
TurretData DeployableFrag1
{
	className = "Turret";
	shapeFile = "mortar_turret";
	projectileType = "BomberShell2";
	maxDamage = 1.0;
	maxEnergy = 100;
	minGunEnergy = 1;
	maxGunEnergy = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.7;
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
	description = "Super Frag Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableFrag1::onAdd(%this)
{
	schedule("DeployableFrag1::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Super Frag Turret");
	}
}

function DeployableFrag1::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableFrag1::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableFrag1::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "Frag1Pack"]--;
}


function DeployableFrag1::onFire(%a, %b, %c, %d)
{
	echo ("Frag Turret");
}

// Override base class just in case.
function DeployableFrag1::onPower(%this,%power,%generator) {}
function DeployableFrag1::onEnabled(%this) 
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
 
																						 
//===================================================================================================
TurretData DeployableFrag2
{
	className = "Turret";
	shapeFile = "mortar_turret";
	projectileType = "BomberShell3";
	maxDamage = 1.0;
	maxEnergy = 100;
	minGunEnergy = 1;
	maxGunEnergy = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.7;
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
	description = "EMP Frag Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableFrag2::onAdd(%this)
{
	schedule("DeployableFrag2::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "EMP Frag Turret");
	}
}

function DeployableFrag2::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableFrag2::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableFrag2::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "Frag2Pack"]--;
}


function DeployableFrag2::onFire(%a, %b, %c, %d)
{
	echo ("EMP Frag Turret");
}

// Override base class just in case.
function DeployableFrag2::onPower(%this,%power,%generator) {}
function DeployableFrag2::onEnabled(%this) 
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
 
																						 
//===================================================================================================
TurretData DeployableFragX
{
	className = "Turret";
	shapeFile = "mortar_turret";
	projectileType = "BomberShellX";
	maxDamage = 1.0;
	maxEnergy = 100;
	minGunEnergy = 1;
	maxGunEnergy = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.7;
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
	description = "Ultra Frag Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableFragX::onAdd(%this)
{
	schedule("DeployableFragX::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Ultra Frag Turret");
	}
}

function DeployableFragX::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableFragX::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableFragX::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "FragXPack"]--;
}


function DeployableFragX::onFire(%a, %b, %c, %d)
{
	echo ("Frag Turret");
}

// Override base class just in case.
function DeployableFragX::onPower(%this,%power,%generator) {}
function DeployableFragX::onEnabled(%this) 
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
 
																						 
//===================================================================================================
TurretData DeployableNuke
{
	className = "Turret";
	shapeFile = "mortar_turret";
	projectileType = "FgcShell";
	maxDamage = 1.0;
	maxEnergy = 45;
	minGunEnergy = 10;
	maxGunEnergy = 100;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 1.8;
	speed = 3.0;
	speedModifier = 1.5;
	range = 300;  //was 150
	visibleToSensor = false;  //was true
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
	description = "Remote Nuke Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableNuke::onAdd(%this)
{
	schedule("DeployableNuke::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.019;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Nuke Turret");
	}
}

function DeployableNuke::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableNuke::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableNuke::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "NukePack"]--;
}


function DeployableNuke::onFire(%a, %b, %c, %d)
{
	echo ("Nuke Turret");
}

// Override base class just in case.
function DeployableNuke::onPower(%this,%power,%generator) {}
function DeployableNuke::onEnabled(%this) 
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
	projectileType = GatlingLaser;  //MiniFusionBolt
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
	shapeFile = "remoteturret";  //remoteturret
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
	//validateShape = true;
	//validateMaterials = true;
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

//====================================================================================================== GH Turret
TurretData DeployableGHTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = Godhammer;
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
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Remote Godhammer Turret";
	damageSkinData = "objectDamageSkins";
	//validateShape = true;
	//validateMaterials = true;
};

function DeployableGHTurret::onAdd(%this)
{
	schedule("DeployableGHTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "RMT GH Turret");
	}
}

function DeployableGHTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableGHTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableGHTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "GHPack"]--;
}

// Override base class just in case.
function DeployableGHTurret::onPower(%this,%power,%generator) {}
function DeployableGHTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//==================================================================================================== Fusion

TurretData DeployableFusion
{
	className = "Turret";
	shapeFile = "hellfiregun";  //hellfiregun
	projectileType = FusionBolt;
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 45;  //was 75
	maxGunEnergy = 6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.3;  //was .8
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
	description = "Remote Fusion Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableFusion::onAdd(%this)
{
	schedule("DeployableFusion::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Fusion Turret");
	}
}

function DeployableFusion::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableFusion::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableFusion::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "FusionTurretPack"]--;
}

// Override base class just in case.
function DeployableFusion::onPower(%this,%power,%generator) {}
function DeployableFusion::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


//==================================================================================================== Plasma

TurretData DeployablePlasma
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = PlasmaCannonBolt;
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
//	gunrange = 999; //added
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


//====================================================================================================== Dart Turret
TurretData DeployableDart
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = TranqDart;
	maxDamage = 0.75;
	maxEnergy = 75;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 6.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 75;
//	gunrange = 999; //added
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
	description = "Remote Dart Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableDart::onAdd(%this)
{
	schedule("DeployableDart::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Dart Turret");
	}
}

function DeployableDart::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableDart::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableDart::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TranqPack"]--;
}

// Override base class just in case.
function DeployableDart::onPower(%this,%power,%generator) {}
function DeployableDart::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


//====================================================================================================== Vulcan Turret
TurretData DeployableBoom
{
	className = "Turret";
	shapeFile = "camera";  //was camera
	projectileType = VulcanBullet;
	maxDamage = 0.75;
	maxEnergy = 150;
	minGunEnergy = 0;
	maxGunEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.0;
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
//	fireSound = ;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Mini-Vulcan Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableBoom::onAdd(%this)
{
	schedule("DeployableBoom::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,500);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Mini-Vulcan Turret");
	}
}

function DeployableBoom::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableBoom::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableBoom::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "BoomPack"]--;
}

// Override base class just in case.
function DeployableBoom::onPower(%this,%power,%generator) {}
function DeployableBoom::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


//================================================================================================ Deployable HyperBlaster Turret
TurretData HyperBTurret
{			 
	className = "Turret";
	shapeFile = "camera";
	projectileType = HyperBolt;
	maxDamage = 1.35;
	maxEnergy = 500;
	minGunEnergy = 0.1;
	maxGunEnergy = 0.2;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.13;
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
//	fireSound = ;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "HyperBlaster Turret";
	damageSkinData = "objectDamageSkins";
};

function HyperBTurret::onAdd(%this)
{
	schedule("HyperBTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.001;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "HyperBlaster Turret");
}

function HyperBTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function HyperBTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function HyperBTurret::onDestroyed(%this)
{
    	Gamebase::setActive(%this,false);
	GameBase::setRechargeRate(%this,0);
  	$TeamItemCount[GameBase::getTeam(%this) @ "HyperBPack"]--;    
	schedule("Turret::onDestroyed("@%this@");",0.8,%this);
}

function HyperBTurret::onPower(%this,%power,%generator) {}

function HyperBTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,20);
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
	reloadDelay = 150.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 35;
	visibleToSensor = false;  //flase
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
	GameBase::setRechargeRate(%this,0.0);
	%this.shieldStrength = 0;
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
	schedule("RemoveDLM(" @ %this @ ", " @ data.maxDamage @ ");",$Shifter::LaserMineLive,%this);

	GameBase::playSequence(%this,1,"deploy");
}

function RemoveDLM(%this, %damage)
{
	if ($Debug) echo("Removing Laser Mine");
		GameBase::setDamageLevel(%this, 5.0);

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
	projectileType = EMPShell;  //was EMPShell
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

//===================================================================================================== EMP Turret
TurretData DeployableFlamer
{
	maxDamage = 1.5;
	maxEnergy = 110;
	minGunEnergy = 1;
	maxGunEnergy = 4;
	reloadDelay = 0.1;
	fireSound = SoundPlasmaTurretFire;
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
	projectileType = FlamerTBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Flamer Turret";

};

function DeployableFlamer::onAdd(%this)
{
	schedule("DeployableFlamer::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,6);
	//%this.shieldStrength = 0;
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Flamer Turret");
	}
}

function DeployableFlamer::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableFlamer::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableFlamer::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "FlamerPack"]--;
}

// Override base class just in case.
function DeployableFlamer::onPower(%this,%power,%generator) {}
function DeployableFlamer::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//================================================================================================== Satchel
TurretData DeployableSatchel
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = "Undefined";
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
	GameBase::applyRadiusDamage($MineDamageType, getBoxCenter(%this), 20, 0.75, 305, %this);
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
	echo ("StaticShape::objectiveDestroyed = Turret.cs 1");

	StaticShape::objectiveDestroyed(%this);

	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	CalcRadiusDamage(%this,$DebrisDamageType,30,0.2,25,20,20,1.5,0.5,200,100);
  	$TeamItemCount[GameBase::getTeam(%this) @ "SatchelPack"]--;
}

function DeployableSatchel::onPower(%this,%power,%generator) {}

function DeployableSatchel::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//================================================================================================ Deployable Elf Turret
TurretData DeployableELFTurret
{			 
	className = "ELF Turret";
	shapeFile = "chainturret";  //chainturret
	projectileType = turretCharge;  //turretCharge
	maxDamage = 1.35;
	maxEnergy = 90;
	minGunEnergy = 2;  //was 50
	maxGunEnergy = 2;  //was 5
	range = 120;  //was 80
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

function DeployableELFTurret::onAdd(%this)
{
	schedule("DeployableELFTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.008;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Deployable ELF Turret");
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

function DeployableELFTurret::onPower(%this,%power,%generator) {}

function DeployableELFTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,20);
	GameBase::setActive(%this,true);
}	

//================================================================================================ Deployable Grav Turret
TurretData DeployableGravTurret
{			 
	className = "Grav Turret";
	shapeFile = "remoteturret";
	projectileType = GravCharge;
	maxDamage = 1.35;
	maxEnergy = 90;
	minGunEnergy = 20;
	maxGunEnergy = 0.3;
	range = 50;
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
	description = "Deployable Grav Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

	    isSustained     = true;
	    firingTimeMS    = 750;
 	    energyRate      = 30.0;
};

function DeployableGravTurret::onAdd(%this)
{
	schedule("DeployableGravTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.008;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Deployable Grav Turret");
}

function DeployableGravTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableGravTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableGravTurret::onDestroyed(%this)
{
    	Gamebase::setActive(%this,false);
	GameBase::setRechargeRate(%this,0);
  	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableGrav"]--;    
	schedule("Turret::onDestroyed("@%this@");",0.8,%this);
}

function DeployableGravTurret::onPower(%this,%power,%generator) {}

function DeployableGravTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,20);
	GameBase::setActive(%this,true);
}	

// =====================================================================================    End new Elf Turret Code

TurretData BarrageTurret
{
	className = "Turret";
	shapeFile = "missileturret";
	projectileType = BarrageBolt;
	maxDamage = 2.5;  //was 1.5
	maxEnergy = 350;
	minGunEnergy = 20;
	maxGunEnergy = 250;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.2;
	speed = 5;
	speedModifier = 4.1;
	range = 325;
	gunrange = 500;  //added
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
	%this.shieldStrength = 0.5;  //was 0.03
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
}

function BarrageTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "BarragePack"]--;
}

function BarrageTurret::onPower(%this,%power,%generator) { }

function BarrageTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,20);
	GameBase::setActive(%this,true);
	%this.shieldStrength = 0.02;
}	

function BarrageTurret::verifyTarget(%this,%target) // Don't shoot if they're not in a vehicle. :) Dewy.
{
	if (GameBase::virtual(%target, "getMountObject") >= 1)
	{
		%this.shieldStrength = 0.09;
		return "True";
	}
	else
	{
		%this.shieldStrength = 0.02;
		return "False";
	}
}



//======================================================================================================= Rocket 

TurretData DeployableRocket
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = TurretMissile;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 2;  //was 25
	maxGunEnergy = 2;  //was 25
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 1.0;
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
}

function DeployableRocket::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "RocketPack"]--;
}

function DeployableRocket::onPower(%this,%power,%generator) {}
function DeployableRocket::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//================================================================================================ Regen
TurretData DeployableSwat
{			 
	className = "turret";
	shapeFile = "indoorgun";
	projectileType = lightningCharge2;  
	maxDamage = 1.35;
	maxEnergy = 90;
	minGunEnergy = 10;
	maxGunEnergy = 10;
	range = 120;  //was 80
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
	description = "Regen Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

	    isSustained     = true;
	    firingTimeMS    = 750;
 	    energyRate      = 30.0;
};

function DeployableSwat::onAdd(%this)
{
	schedule("DeployableSwat::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.006;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Regen Turret");
}

function DeployableSwat::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableSwat::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableSwat::onDestroyed(%this)
{
    	Gamebase::setActive(%this,false);
	GameBase::setRechargeRate(%this,0);
  	$TeamItemCount[GameBase::getTeam(%this) @ "SwatPack"]--;    
	schedule("Turret::onDestroyed("@%this@");",0.8,%this);
}

function DeployableSwat::onPower(%this,%power,%generator) {}

function DeployableSwat::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,20);
	GameBase::setActive(%this,true);
}	

//=============================================================================================================
TurretData CameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 0.25;
	maxEnergy = 50;  //was 10
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
	shieldShapeName = "shield";  //added
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
	GameBase::setRechargeRate(%this,0);  //added
	%this.shieldStrength = 0;  //added

}

function CameraTurret::onDestroyed(%this)
{
	%this.shieldStrength = 0;  //added
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "CameraPack"]--;
	$TeamItemCount[GameBase::getTeam(%player) @ "EngBeacons"]--;  	
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
//PORT-OFF: 	explosionId = defaultDebrisSmall;
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

function ArbitorBeacon::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }
function ArbitorBeacon::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }
function ArbitorBeacon::onDisabled(%this){}
function ArbitorBeacon::onDestroyed(%this)
{
	%num = Group::objectCount(%this.set);
	for(%i=%num-1; %i >= 0; %i--)
	{
		if (%this != %i)
		{
			%obj = Group::getObject(%this.set, %i);
			GameBase::startFadeIn(%obj);
			%obj.cloaked = 0;
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
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 25, 25, 25,0);
	%num = Group::objectCount(%Set);
	
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
		{
			//don't cloak enemies or the box itself		
		}
		else
		{

			GameBase::startFadeOut(%obj);
			%obj.cloaked = 1;
		}
	}

	%this.set = %Set;

	schedule("ArbitorBeacon::checkArbitorBeacon(" @ %this @ ");", 0.1, %this);

}	

function ArbitorBeacon::checkArbitorBeacon(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled" || !%this)
		return;

	%this.evenodd = !%this.evenodd;

	%Set = newObject("arbbset",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 25, 25, 25,0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		
		%datab = GameBase::getDataName(%obj);
		%objn = (getObjectType(%obj));		

		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this || %datab == "ArbitorBeacon")
		{
		}
		else
		{
			GameBase::startFadeOut(%obj);
			schedule("GameBase::startFadeIn( " @ %obj @ ");",6);
			%obj.cloaked = 1 + %this.evenodd;
		}
	}

	%num = Group::objectCount(%this.set);

	for(%j; %j < %num; %j++)
	{
		%obj = Group::getObject(%this.set, %j);
		if(%obj == %this || GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %datab == "ArbitorBeacon")
		{
		}
		else if(%obj.cloaked != (%this.evenodd + 1)) //if different then new set
		{
			%obj.cloaked = 0;
			GameBase::startFadeIn(%obj); //then decloak it
		}
	}

	deleteObject(%this.set); //delete the old set
	%this.set = %Set; //and replace with new set

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

function EMPBeacon::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function EMPBeacon::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function EMPBeacon::onDisabled(%this)
{
	Turret::onDisabled(%this);
}
function EMPBeacon::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "EMPBeaconPack"]--;
}


function EMPBeacon::onPower(%this,%power,%generator) {}

function EMPBeacon::onEnabled(%this) 
{
	schedule("EMPBeacon::checkEMPBeacon(" @ %this @ ");", 0.1, %this);
}	

function EMPBeacon::checkEMPBeacon(%this)
{

	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	
	containerBoxFillSet(%Set, %Mask, %Pos, 35, 35, 35,0);
	
	%num = Group::objectCount(%Set);
	
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
	
		if (getObjectType(%obj) == "Player")
		{
			%armor = Player::getArmor(%obj);
		}

		if (%obj != %this && (%armor != "parmor" || %armor != "darmor" || %armor != "jarmor" || %armor != "barmor" || %armor != "bfemale" || %armor != "spyarmor" || %armor != "spyfemale" || %armor != "stimarmor" || %armor != "stimfemale")) 
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				%owner = Gamebase::getOwnerClient(%this);
				GameBase::applyDamage(%obj,$FlashDamageType, 0.01,GameBase::getPosition(%obj),"0 0 0","0 0 0",%owner);		
				schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %obj @ "));",0.1);
			}
			else
			{
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

function ShieldBeacon::onAdd(%this)
{
	schedule("ShieldBeacon::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") 
	{
		GameBase::setMapName (%this, "Shield Box");
	}
}

function ShieldBeacon::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ShieldBeacon::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function ShieldBeacon::onDisabled(%this)
{
	Turret::onDisabled(%this);
}
function ShieldBeacon::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ShieldBeaconPack"]--;
}

function ShieldBeacon::onPower(%this,%power,%generator) {}

function ShieldBeacon::onEnabled(%this) 
{
	schedule("ShieldBeacon::checkShieldBeacon(" @ %this @ ");", 0.1, %this);
}	

function ShieldBeacon::checkShieldBeacon(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	
	containerBoxFillSet(%Set, %Mask, %Pos, 35, 35, 35,0);
	
	%num = Group::objectCount(%Set);
	
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);

		if (%obj != %this) 
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				%p = Client::GetOwnedObject(%obj);
				%armor = Player::getArmor(%p);

				if(%armor == "spyarmor" || %armor == "spyfemale")
				{
					%obj.shieldStrength = 0.006;
					bottomprint(%obj, "<jc><f2>Receiving minimal shielding from enemy beacon", 5);
					schedule ("" @ %obj @ ".shieldStrength = 0.0 ;",15);
				}
				else
				{
				}
			}
			else
			{
				if (getObjectType(%obj) == "Player")
				{
					%obj.shieldStrength = 0.022;
					schedule ("" @ %obj @ ".shieldStrength = 0.0 ;",15);
				}
				else
				{
					%obj.shieldStrength += 0.022;
					schedule ("" @ %obj @ ".shieldStrength -= 0.022 ;",15);
				}
			}
		}
	}
	deleteObject(%set);
	schedule("ShieldBeacon::checkShieldBeacon(" @ %this @ ");", 14.0, %this);
}


//============================================================================================= Healing Beacon

TurretData HealingPlant
{
	className = "Turret";
	shapeFile = "cactus2";
	maxDamage = 1;
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
	description = "Healing Plant";
//	damageSkinData = "objectDamageSkins";
};

function HealingPlant::onAdd(%this)
{
	schedule("HealingPlant::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") 
	{
		GameBase::setMapName (%this, "Healing Box");
	}
}

function HealingPlant::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function HealingPlant::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function HealingPlant::onDisabled(%this)
{
	Turret::onDisabled(%this);
}
function HealingPlant::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "PlantPack"]--;
}

function HealingPlant::onPower(%this,%power,%generator) {}

function HealingPlant::onEnabled(%this) 
{
	schedule("HealingPlant::checkHealingPlant(" @ %this @ ");", 0.1, %this);
}	

function HealingPlant::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player")
	{
		return;
	}

	if(Player::isDead(%obj))
	{
		return;
	}

	%c = Player::getClient(%obj);


	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	if(GameBase::getDamageLevel(%obj)) 
	{
		GameBase::repairDamage(%obj,0.3);
		GameBase::playSound(%this,ForceFieldOpen,0);
	}
}

function HealingPlant::checkHealingPlant(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	
	containerBoxFillSet(%Set, %Mask, %Pos, 35, 35, 35,0);
	
	%num = Group::objectCount(%Set);
	
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);

		if (%obj != %this) 
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				%armor = Player::getArmor(%obj);

				if(%armor == "spyarmor" || %armor == "spyfemale")
				{
					Gamebase::repairDamage(%obj,0.09);
					schedule ("playSound(ForceFieldOpen,GameBase::getPosition(" @ %obj @ "));",0.1);
				}
			}
			else
			{
				Gamebase::repairDamage(%obj,0.3);
				schedule ("playSound(ForceFieldOpen,GameBase::getPosition(" @ %obj @ "));",0.1);

			}
		}
	}
	deleteObject(%set);
	schedule("HealingPlant::checkHealingPlant(" @ %this @ ");", 5.0, %this);
}

//========================================================================================================================
// 					Standard Turret Functions For Shifter.
//========================================================================================================================

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
	echo ("StaticShape::objectiveDestroyed = Turret.cs 2");

	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 0.1, 200, 100); 
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
	
	if ((%client.Laptop == "True" && (%armor == "spyarmor" || %armor == "spyfemale")) || ((%armor == "earmor" || %armor == "efemale") && %client.HackBob == "True"))
	{
		if (%client.HackPack == True)
		{
			echo ("Controlling");
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
		else	//== Hack Pack Allows You To Hack Enemy Stuff! Not Just take control of turrets
		{
			if (%client.hacking == "True")
			{
				return;
			}
			
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
				
					hackingturret(%target, %pTeam, %pName, %tName, %name, %team, $Shifter::HackTime, %client);
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
		Client::sendMessage(%client,0,"Hacking In Progress - Time Remaining " @ %time);
		if(%client.hacking)
		{		
			schedule("hackingturret('" @ %target @ "','" @ %pTeam @ "','" @ %pName @ "','" @ %tName @ "','" @ %name @ "','" @ %team @ "','" @ %time - 1 @ "','" @ %client @ "');", 1);
		}
	}
	else
	{
		Client::sendMessage(Player::getClient(%client),0,("Finished In " @ %time @ "."));

		if (%client.Laptop == "True" || %client.HackBob == "True")
		{		
			if(%client.hacking)
			{				
			
				if (%target.infected == "true")
				{
					%rnd = floor(getRandom() * 100);	

					if (%rnd > 50)
					{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						Client::sendMessage(%client,1,"You disarm the protection virus in the " @ %name @ ", but it costs you!!!");
						%player = Client::getOwnedObject(%client);
						echo (%player);
						Player::blowUp(%this);
						GameBase::applyDamage(%player,$FlashDamageType,0.90,GameBase::getPosition(%player),"0 0 0","0 0 0",%target);
						%target.infected = "false";
						return;
					}
					else
					{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						Client::sendMessage(%client,1,"You safely disarm the protection virus in the " @ %name @ ".");					
						%target.infected = "false";
						return;
					}
				}
				else
				{

					TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
					TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");
					GameBase::setTeam(%target,%pTeam);

					if($Shifter::HackedTime > 0)
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", $Shifter::HackedTime);
						schedule("" @ %target @ ".disabled = false;", $Shifter::HackedTime);
					}
					else
					{
						schedule("" @ %target @ ".disabled = false;", $Shifter::HackLock);					
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
			}
		}
		echo ("Client Hacking Off");
		%client.hacking = "false";
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
			Client::sendMessage(%client,0,"Missile Turret is not loaded.");
		}
	}
	else
	{
		remoteCommandMode(%client);
		remotePlayMode(%client);
	}
}
//Mega-Renegades
//----------------------------------------------------------------------------
// TURRET DYNAMIC DATA

TurretData PlasmaTurret
{
	maxDamage = 1.0;
	maxEnergy = 700;
	minGunEnergy = 1;
	maxGunEnergy = 2;
	reloadDelay = 0.5;
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 180;
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
	maxEnergy = 700;
	minGunEnergy = 5;
	maxGunEnergy = 5;
	range = 180;
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
	reloadDelay = 0.5;
	explosionId = LargeShockwave;
	description = "ELF Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 1.0;
};

TurretData RocketTurret 
{ 
	maxDamage = 1.75; 
	maxEnergy = 500;  // reduced to  limit lag
	minGunEnergy = 200; // increased to limit lag
	maxGunEnergy = 200; // should reduce the number of missiles
	range = 600; 
	gunRange = 6000; 
	visibleToSensor = true; 
	reloadDelay = 0.05;
	dopplerVelocity = 0; 
	castLOS = true; 
	supression = false; 
	mapFilter = 2; 
	mapIcon = "M_turret"; 
	debrisId = defaultDebrisLarge; 
	className = "Turret"; 
	shapeFile = "missileturret"; 
	shieldShapeName = "shield_medium"; 
	speed = 8.0; 
	speedModifier = 3.0; 
	projectileType = TurretMissile; 
	fireSound = SoundMissileTurretFire; 
	activationSound = SoundMissileTurretOn; 
	deactivateSound = SoundMissileTurretOff; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	targetableFovRatio = 0.5; 
	explosionId = LargeShockwave; 
	description = "Rocket Turret"; 
}; 
function RocketTurret::onPower(%this,%power,%generator) 
{ 
	if (%power) 
	{ 
		%this.shieldStrength = 0.10; 
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
	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) return "True"; 
	else return "False"; 
} 

//--------------------------------------------

TurretData MortarTurret
{
	maxDamage = 1.0;
	maxEnergy = 400;
	minGunEnergy = 1;
	maxGunEnergy = 400;
	reloadDelay = 1.0;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 800;
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
	projectileType = Mortarshell;
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
	maxEnergy = 700;
	minGunEnergy = 2;
	maxGunEnergy = 6;
	reloadDelay = 0.05;

	speed = 5.0;
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


//--------------------------------------------

TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = MiniFusionBolt;
	maxDamage = 1.65;
	maxEnergy = 300;
	minGunEnergy = 1;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.05;
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
		%TDS = $Server::TeamDamageScale;
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

//function Turret::onCollision (%this, %object)
//{
//	if (getObjectType (%object) == "Player")
//		{
//			Player::mountObject (%object, %this);
//		}
//}



TurretData AssassinTurret
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = AssassinBullet;
	maxDamage = 0.95;
	maxEnergy = 500;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.25;
	speed = 5.0;
	speedModifier = 1.9;
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
	description = "Assasin Turret";
	damageSkinData = "objectDamageSkins";
};

function AssassinTurret::onAdd(%this)
{
	schedule("AssassinTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Assassin Turret");
	}
}

function AssassinTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function AssassinTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function AssassinTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LaserPack"]--;
}

// Override base class just in case.
function AssassinTurret::onPower(%this,%power,%generator) {}
function AssassinTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}


//-------------------------------------------------------

TurretData DeployableRail 
{ 
	className = "Turret"; 
	shapeFile = "hellfiregun"; 
	projectileType = railLaser; 
	maxDamage = 40.0; 
	maxEnergy = 555; 
	minGunEnergy = 100; 
	maxGunEnergy = 150; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 5.0; 
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
	activationSound = SoundPlasmaTurretOn; 
	deactivateSound = SoundPlasmaTurretOff; 
	whirSound = SoundPlasmaTurretTurn; 
	explosionId = flashExpMedium; 
	description = "Rail Turret"; 
	damageSkinData = "objectDamageSkins"; 
}; 

function DeployableRail::onAdd(%this) 
{ 
	schedule("DeployableRail::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,20); 
	%this.shieldStrength = 0.01; 
	if (GameBase::getMapName(%this) == "") 
	{ 
		GameBase::setMapName (%this, "Rail Turret"); 
	} 
} 

function DeployableRail::deploy(%this) 
{ 
	GameBase::playSequence(%this,1,"deploy"); 
} 

function DeployableRail::onEndSequence(%this,%thread) 
{ 
	GameBase::setActive(%this,true); 
} 

function DeployableRail::onDestroyed(%this) 
{ 
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this); 
	Turret::objectiveDestroyed(%this); 
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "RailTurret"]--; 
} 

function DeployableRail::onPower(%this,%power,%generator) 
{
} 

function DeployableRail::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this,20); 
	GameBase::setActive(%this,true); 
}

//----------------------------------------------------------------------------
// TURRET DYNAMIC DATA

TurretData PlasmaTurret
{
	maxDamage = 1.0;
	maxEnergy = 300;
	minGunEnergy = 1;
	maxGunEnergy = 1;
	reloadDelay = 0.4;
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 125;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;
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
	maxEnergy = 250;
	minGunEnergy = 5;
	maxGunEnergy = 50;
	range = 155;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "ELF Turret";
	shapeFile = "chainturret";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = turretCharge;
	reloadDelay = 0.1;
	explosionId = LargeShockwave;
	description = "ELF Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 1.5;
};

TurretData RocketTurret
{
	maxDamage = 2;
	maxEnergy = 300;
	minGunEnergy = 180;
	maxGunEnergy = 180;
	range = 150;
	gunRange = 225;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "missileturret";
	shieldShapeName = "shield_medium";
	speed = 5.0;
	speedModifier = 2.0;
	projectileType = TurretMissile;
//	reloadDelay = 1.0;
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

function RocketTurret::onCollision(%this,%object)
{
// by request :)
	if(getObjectType(%object)!="Player")
		return;
	if(%this.heysoundplayed)
		return;
	else
	{
		GameBase::PlaySound(%this, SoundHeyDunTouch, 3);
		%this.heysoundplayed=true;
		schedule(%this@".heysoundplayed=false;", 5);
	}
}

function RocketTurret::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.08;
		GameBase::setRechargeRate(%this,42);
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
	maxEnergy = 400;
	minGunEnergy = 1;
	maxGunEnergy = 400;
	reloadDelay = 0.5;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 200;
	dopplerVelocity = 0;
	castLOS = false;
	supression = false;
	supressable = true;
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
	maxDamage = 1.0;
	maxEnergy = 100;
	minGunEnergy = 2;
	maxGunEnergy = 6;
	reloadDelay = 0.3;
	speed = 3.0;
	speedModifier = 1.0;
	range = 35;
	visibleToSensor = true;
	dopplerVelocity = 2;
	castLOS = true;
	supression = false;
	supressable = true;
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
//--------------------------------------------

TurretData LilDeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = MiniFusionBolt;
	maxDamage = 1;
	maxEnergy = 500;
	minGunEnergy = 10;
	maxGunEnergy = 10;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.08;
	speed = 1;
	speedModifier = 1;
	range = 40;
	visibleToSensor = true;
	shadowDetailMask = 0;
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
	description = "LiL Turret";
	damageSkinData = "objectDamageSkins";
};

function LilDeployableTurret::onAdd(%this)
{
	schedule("LilDeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "LiL Turret");
	}
}

function LilDeployableTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function LilDeployableTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function LilDeployableTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LilTurretPack"]--;
}

// Override base class just in case.
function LilDeployableTurret::onPower(%this,%power,%generator) {}
function LilDeployableTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = MiniTurretBolt;
	maxDamage = 2.5;
	maxEnergy = 100;
	minGunEnergy = 1;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.35;
	speed = 4.0;
	speedModifier = 1.5;
	range = 60;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;
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
	%this.shieldStrength = 0.015;
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
   validateShape = true;
   validateMaterials = true;
	projectileType = DTurretMissile;
	maxDamage = 2.25;
	maxEnergy = 60;
	minGunEnergy = 25;
	maxGunEnergy = 25;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.5;
	speed = 4.0;
	speedModifier = 1.5;
	range = 100;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = false;
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
	GameBase::setRechargeRate(%this,6);
	%this.shieldStrength = 0.015;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Rocket Turret");
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
   validateShape = true;
   validateMaterials = true;
	maxDamage = 3.0;
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
		GameBase::setRechargeRate(%this,30);
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
		GameBase::setRechargeRate(%this,30);
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
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		if(%name != DeployableTurret && %name != CameraTurret )	
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

//function Turret::onCollision (%this, %object)
//{
//	if (getObjectType (%object) == "Player")
//		{
//			Player::mountObject (%object, %this);
//		}
//}




TurretData DeployableTaserTrtB
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = TaserTrtBLaser;
	maxDamage = 1;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2;
	speed = 2;
	speedModifier = 2;
	range = 60;
	visibleToSensor = true;
	shadowDetailMask = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisSmall;
	shieldShapeName = "shield";
	fireSound = SoundTaserFire;
	activationSound = SoundTaserActivate;
	deactivateSound = SoundTaserDeactivate;
	explosionId = flashExpMedium;
	description = "Taser Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableTaserTrtB::onAdd(%this)
{
	schedule("DeployableTaserTrtB::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Taser Turret");
	}
}

function DeployableTaserTrtB::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableTaserTrtB::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableTaserTrtB::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TaserTrtBPack"]--;
}

// Override base class just in case.
function DeployableTaserTrtB::onPower(%this,%power,%generator) {}
function DeployableTaserTrtB::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//-------------------------------------------------------------
//--------------------------------------------

TurretData LaserTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = LaserTrtLaser;
	maxDamage = 1;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 20;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.08;
	speed = 2;
	speedModifier = 2;
	range = 40;
	visibleToSensor = true;
	shadowDetailMask = 0;
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
	description = "Laser Turret";
	damageSkinData = "objectDamageSkins";
};

function LaserTurret::onAdd(%this)
{
	schedule("LaserTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Laser Turret");
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

// Override base class just in case.
function LaserTurret::onPower(%this,%power,%generator) {}
function LaserTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//-------------------------------------------------------------------

TurretData LaserTurretB
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = PlasmaBolt;
	maxDamage = 1;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.08;
	speed = 2;
	speedModifier = 2;
	range = 40;
	visibleToSensor = true;
	shadowDetailMask = 0;
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
	description = "Mini-Plasma Turret";
	damageSkinData = "objectDamageSkins";
};

function LaserTurretB::onAdd(%this)
{
	schedule("LaserTurretB::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Mini-Plasma Turret");
	}
}

function LaserTurretB::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function LaserTurretB::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function LaserTurretB::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LaserTurretBPack"]--;
}

// Override base class just in case.
function LaserTurretB::onPower(%this,%power,%generator) {}
function LaserTurretB::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//--------------------------------------------
//--------------------------------------------

TurretData DeployableTaserTrtC
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = TaserTrtCLaser;
	maxDamage = 15;
	maxEnergy = 500;
	minGunEnergy = 10;
	maxGunEnergy = 20;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
	speed = 2;
	speedModifier = 2;
	range = 999;
	visibleToSensor = true;
	shadowDetailMask = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisSmall;
	shieldShapeName = "shield";
	fireSound = SoundTaserFire;
	activationSound = SoundTaserActivate;
	deactivateSound = SoundTaserdeActivate;
	explosionId = flashExpMedium;
	description = "Taser Tracker";
	damageSkinData = "objectDamageSkins";
};

function DeployableTaserTrtC::onAdd(%this)
{
	schedule("DeployableTaserTrtC::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Taser Tracker");
	}
}

function DeployableTaserTrtC::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableTaserTrtC::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableTaserTrtC::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TaserTrtCPack"]--;
}

// Override base class just in case.
function DeployableTaserTrtC::onPower(%this,%power,%generator) {}
function DeployableTaserTrtC::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//-------------------------------------------------------------
TurretData MiniELFTurret
{
	maxDamage = 1.0;
		maxEnergy = 500;
		minGunEnergy = 50;
		maxGunEnergy = 5;
		range = 60;
		visibleToSensor = true;
		dopplerVelocity = 0;
		castLOS = true;
		supression = false;
		mapFilter = 2;
		mapIcon = "M_turret";
		debrisId = defaultDebrisSmall;
		className = "Turret";
		shapeFile = "camera";
		shieldShapeName = "shield";
		speed = 5.0;
		speedModifier = 1.5;
		projectileType = MiniELFTurretproj;
		reloadDelay = 0.78;
		explosionId = debrisExpMedium;
		description = "Mini-ELF Turret";
	
		fireSound        = SoundELFIdle;
		activationSound  = Soundspecialdeploy;
		deactivateSound  = SoundTaserdeActivate;
		damageSkinData   = "objectDamageSkins";
		shadowDetailMask = 8;
	
	   isSustained     = true;
	   firingTimeMS    = 750;
   energyRate      = 30.0;

};

function MiniELFTurret::onAdd(%this)
{
	schedule("MiniELFTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Mini-ELF Turret");
	}
}

function MiniELFTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function MiniELFTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function MiniELFTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MiniELFTurretPack"]--;
}

//// Override base class just in case.
function MiniELFTurret::onPower(%this,%power,%generator) {}
function MiniELFTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//-------------------------------------------------------------
TurretData MiniSmokeTurret
{
	maxDamage = 1.0;
	maxEnergy = 500;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 40;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisSmall;
	className = "Turret";
	shapeFile = "camera";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = MiniSmokeTurretproj;
	reloadDelay = 2.1;
	explosionId = debrisExpMedium;
	description = "Mini-Beam Of Pain";

	fireSound        = SoundELFIdle;
	activationSound  = SoundTaserActivate;
	deactivateSound  = SoundTaserdeActivate;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 2000;
   energyRate      = 30.0;

};

function MiniSmokeTurret::onAdd(%this)
{
	schedule("MiniSmokeTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Mini-Beam Of Pain");
	}
}

function MiniSmokeTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function MiniSmokeTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function MiniSmokeTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MiniSmokeTurretPack"]--;
}

// Override base class just in case.
function MiniSmokeTurret::onPower(%this,%power,%generator) {}
function MiniSmokeTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

TurretData MiniFlakTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
  // validateShape = true;
  // validateMaterials = true;
	projectileType = MiniFlakproj;
	maxDamage = 1;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 20;
        range = 75;
        //gunRange = 300;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2;
	speed = 2;
	speedModifier = 2;
	visibleToSensor = true;
	shadowDetailMask = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = shockexplosion;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Mini-Flak Turret";
	damageSkinData = "objectDamageSkins";
};

//-------------------------------------------------------------------------------

function MiniFlakTurret::onAdd(%this)
{
	schedule("MiniFlakTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Mini-Flak Turret");
	}
}

function MiniFlakTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function MiniFlakTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function MiniFlakTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MiniFlakTurretPack"]--;
}

// Override base class just in case.
function MiniFlakTurret::onPower(%this,%power,%generator) {}
function MiniFlakTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//-----------------------------------------------------------------------------------

TurretData MiniSAMTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = MiniSAMproj;
	maxDamage = 1;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 20;
        range = 100;
        //gunRange = 300;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 4;
	speed = 2;
	speedModifier = 2;
	visibleToSensor = true;
	shadowDetailMask = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = shockexplosion;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Mini-S.A.M Turret";
	damageSkinData = "objectDamageSkins";
};

function MiniSAMTurret::onAdd(%this)
{
	schedule("MiniSAMTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Mini-S.A.M Turret");
	}
}

function MiniSAMTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function MiniSAMTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function MiniSAMTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MiniSAMTurretPack"]--;
}

// Override base class just in case.
function MiniSAMTurret::onPower(%this,%power,%generator) {}
function MiniSAMTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

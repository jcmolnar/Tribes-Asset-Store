//----------------------------------------------------------------------------
// TURRET DYNAMIC DATA

TurretData PlasmaTurret
{
	maxDamage = 2.0;
	maxEnergy = 200; //150;
	minGunEnergy = 50;
	maxGunEnergy = 10;
	reloadDelay = 2.25;
	fireSound = SoundFireFlierRocket;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 150;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "hellfiregun";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = PPCBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "PPC Turret";
};

//-------------------------------------------------------------------------------		 
TurretData ELFTurret	   
{			 
	maxDamage = 1.0;
	maxEnergy = 100;
	minGunEnergy = 25;
	maxGunEnergy = 0.5;
	reloadDelay = 0.15;
	range = 40;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "indoorgun";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = FlamerShell;
	explosionId = LargeShockwave;
	description = "Flamer Turret";

//	fireSound        = SoundFireFlierRocket;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

};

//----------------------------------------------------
TurretData RocketTurret
{
	maxDamage = 1.0;//+++++++++
	maxEnergy = 100;
	minGunEnergy = 10;
	maxGunEnergy = 15;
	range = 150;
//	gunRange = 150;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "missileturret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = STR2MissileT;
	reloadDelay = 0.3;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
   targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "Streak Turret";
};

function RocketTurret::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,15); //14+++++++
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
	maxDamage = 2.0;//++++++++++++
	maxEnergy = 50;
	minGunEnergy = 48;
	maxGunEnergy = 40;
	reloadDelay = 4.0;
	fireSound = bigExplosion1;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
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
	description = "Long Tom";
};
																			 
//--------------------------------------------
TurretData IndoorTurret
{
	className = "Turret";
	shapeFile = "chainturret"; //"indoorgun";++++++++
	projectileType = Ultra20Bullet;
	maxDamage = 1.5;
	maxEnergy = 100;
	minGunEnergy = 20;
	maxGunEnergy = 3;
	reloadDelay = 0.08;
	speed = 4.0;
	speedModifier = 1.5;
	range = 75;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = debrisMediumExplosion;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "Ultra-AC20 Turret";
};

//--------------------------------------------
TurretData CameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 0.5;//+++++++++
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
		%this.shieldStrength = 0.02; //0.03;+++++++++
		GameBase::setRechargeRate(%this,8); //10+++++++++++++++
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
		%this.shieldStrength = 0.02; //0.03;+++++++
		GameBase::setRechargeRate(%this,8); //10++++++++++++++
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
//	StaticShape::objectiveDestroyed(%this);//+++++++++++ removed: unknown command +++++++++++
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
//	Turret::objectiveDestroyed(%this);//++++++++++ same reason +++++++++++
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

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
TurretData MedLasTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = MedLaserTurretShell;
	maxDamage = 1.0;
	maxEnergy = 60;
	minGunEnergy = 40; //20
	maxGunEnergy = 5;
	reloadDelay = 2.0; //1.5
	speed = 5.0;
	speedModifier = 1.0;
	range = 135;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireLaser;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "ER Laser Turret";
};
function MedLasTurret::onAdd(%this)
{
	schedule("MedLasTurret::deploy(" @ %this @ ");",1,%this);
	%this.shieldStrength = 0.01;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "ER Laser Turret");
	}
}
function MedLasTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MedLasPack"]--;
}
function MedLasTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}
function MedLasTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function MedLasTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

// Override base class just in case.
function MedLasTurret::onPower(%this,%power,%generator) {}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "chainturret";
	projectileType = Ultra20Bullet;
	accuFire = false;
	maxDamage = 1.5;
	maxEnergy = 100;
	minGunEnergy = 20;
	maxGunEnergy = 3; //6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.08; //0.12;
	speed = 4.0;
	speedModifier = 1.5;
	range = 75;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = debrisMediumExplosion;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Ultra AC-20 Turret";
	damageSkinData = "objectDamageSkins";
};
function DeployableTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Ultra-AC20 Turret");
	}
}
function DeployableTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--;
}
function DeployableTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}
function DeployableTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

// Override base class just in case.
function DeployableTurret::onPower(%this,%power,%generator) {}

//++++++++++++++++++++++++++++++++++++++++++++
TurretData LRM5Turret
{
	maxDamage = 1.0;
	maxEnergy = 100;
	minGunEnergy = 10;
	maxGunEnergy = 15;
	range = 150;
//	gunRange = 150;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++++++++
	mapFilter = 2;
	pinger = false; //+++++++
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "missileturret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = STR2MissileT;
	reloadDelay = 0.3;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	deactivateSound = SoundMissileTurretOff;
	whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
   targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "Streak Turret";
};

function LRM5Turret::onAdd(%this)
{
	schedule("LRM5Turret::deploy(" @ %this @ ");",1,%this);
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Streak Turret");
	}
}
function LRM5Turret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LRM5Pack"]--;
}
function LRM5Turret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,6); //5+++++
	GameBase::setActive(%this,true);
}
function LRM5Turret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function LRM5Turret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

// Override base class just in case.
function LRM5Turret::onPower(%this,%power,%generator) {}
function LRM5Turret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++
TurretData FlamerTurret	   
{			 
	maxDamage = 1.0;
	maxEnergy = 100;
	minGunEnergy = 25;
	maxGunEnergy = 0.5;
	reloadDelay = 0.15;
	range = 40;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "indoorgun";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = FlamerShell;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	explosionId = LargeShockwave;
	description = "Flamer Turret";

//	fireSound        = SoundFireFlierRocket;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

};
function FlamerTurret::onAdd(%this)
{
	schedule("FlamerTurret::deploy(" @ %this @ ");",1,%this);
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Flamer Turret");
	}
}
function FlamerTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "FlamerPack"]--;
}
function FlamerTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,6);
	GameBase::setActive(%this,true);
}
function FlamerTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function FlamerTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

// Override base class just in case.
function FlamerTurret::onPower(%this,%power,%generator) {}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
TurretData PPCTurret
{
	maxDamage = 2.0;
	maxEnergy = 200; //150;
	minGunEnergy = 50;
	maxGunEnergy = 10;
	reloadDelay = 2.25;
	fireSound = SoundFireFlierRocket;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	whirSound = SoundPlasmaTurretTurn;
	range = 150;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;//++++
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "hellfiregun";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = PPCBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "PPC Turret";
};

function PPCTurret::onAdd(%this)
{
	schedule("PPCTurret::deploy(" @ %this @ ");",1,%this);
	%this.shieldStrength = 0.020; //0.010;+++++++
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "PPC Turret");
	}
}
function PPCTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}
function PPCTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function PPCTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "PPCPack"]--;
}

// Override base class just in case.
function PPCTurret::onPower(%this,%power,%generator) {}
function PPCTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,6); //5++++++++++++++
	GameBase::setActive(%this,true);
}

//++++++++++++++++++++++++++++++++++++++++++++
TurretData LongTom
{
	maxDamage = 2.0;//++++++++++++
	maxEnergy = 50;
	minGunEnergy = 48;
	maxGunEnergy = 40;
	reloadDelay = 4;
	fireSound = bigExplosion1;
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
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	projectileType = MortarTurretShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Long Tom";
};

function LongTom::onAdd(%this)
{
	schedule("LongTom::deploy(" @ %this @ ");",1,%this);
	%this.shieldStrength = 0.020;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Long Tom");
	}
}
function LongTom::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function LongTom::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function LongTom::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LongTomPack"]--;
}

// Override base class just in case.
function LongTom::onPower(%this,%power,%generator) {}
function LongTom::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,6);
	GameBase::setActive(%this,true);
}
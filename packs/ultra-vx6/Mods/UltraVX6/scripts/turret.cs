// =================================================================
//  U L T R A   R E N E G A D E S   V X 6   I N F I N I T E    +]-[+  
// =================================================================
// Copyright © 2005 +]-[+Armageddon+. List of credits in credits.txt

TurretData PlasmaTurret
{
	maxDamage = 1.0;
	maxEnergy = 500;
	minGunEnergy = 10;
	maxGunEnergy = 10;
	reloadDelay = 0.08;
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
	speed = 2;
	speedModifier = 2;
	projectileType = FusionBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 0;
	explosionId = LargeShockwave;
	description = "Fusion Turret";
};

function PlasmaTurret::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("PTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("FusionBolt",%trans,%this,0);
		%client = Player::getClient(%this);
		GameBase::applyDamage(%client,$Debrisdamagetype,10.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);
}
																						 
TurretData ELFTurret	   
{			 
	maxDamage = 1.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 100;
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
	speed = 2;
	speedModifier = 2;
	projectileType = turretCharge;
	reloadDelay = 0.3;
	explosionId = LargeShockwave;
	description = "ELF Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 0;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;
};

function ELFTurret::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		%client = Player::getClient(%this);
		GameBase::applyDamage(%client,$Debrisdamagetype,10.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);
}

TurretData RocketTurret
{
	maxDamage = 0.75;
	maxEnergy = 100;
	minGunEnergy = 60;
	maxGunEnergy = 500;
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
	speed = 1;
	speedModifier = 1;
	projectileType = TurretMissile;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 0;
   targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "Missile Turret";
};

function RocketTurret::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("TurretMissile",%trans,%this,0);
		%client = Player::getClient(%this);
		GameBase::applyDamage(%client,$Debrisdamagetype,10.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);
}

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
	reloadDelay = 0.2;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 100;
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
	speed = 2;
	speedModifier = 2;
	projectileType = MortarTurretShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 0;
	explosionId = LargeShockwave;
	description = "Mortar Turret";
};

function MortarTurret::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);
		 Projectile::spawnProjectile("MortarTurretShell",%trans,%this,0);
		 Projectile::spawnProjectile("MortarTurretShell",%trans,%this,0);
		%client = Player::getClient(%this);
		GameBase::applyDamage(%client,$Debrisdamagetype,10.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);
}
																						 
//--------------------------------------------

TurretData IndoorTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = MiniFusionBolt;
	maxDamage = 1;
	maxEnergy = 500;
	minGunEnergy = 20;
	maxGunEnergy = 6;
	reloadDelay = 0.08;
	speed = 1;
	speedModifier = 1;
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
	shadowDetailMask = 0;
	explosionId = debrisExpMedium;
	description = "Indoor Turret";

};

function IndoorTurret::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		%client = Player::getClient(%this);
		GameBase::applyDamage(%client,$Debrisdamagetype,10.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);
}

//--------------------------------------------

TurretData DeployableTurret
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
	description = "Sentry Turret System";
	damageSkinData = "objectDamageSkins";
};

function DeployableTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Sentry Turret System");
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
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		%client = Player::getClient(%this);
		GameBase::applyDamage(%client,$Debrisdamagetype,10.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);
}

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
	shadowDetailMask = 0;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = defaultDebrisSmall;
	FOV = 0.707;
	pinger = false;
	explosionId = debrisExpMedium;
	description = "Syp Camera Network";
};

function CameraTurret::onAdd(%this)
{
	schedule("CameraTurret::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Spy Camera Network");
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
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		%client = Player::getClient(%this);
		GameBase::applyDamage(%client,$Debrisdamagetype,10.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);
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
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		if(%name != CameraTurret)	
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

//--------------------------------------------

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
	description = "Taser Turret System";
	damageSkinData = "objectDamageSkins";
};

function DeployableTaserTrtB::onAdd(%this)
{
	schedule("DeployableTaserTrtB::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Taser Turret System");
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
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		%client = Player::getClient(%this);
		GameBase::applyDamage(%client,$Debrisdamagetype,10.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);
}

function DeployableTaserTrtB::onPower(%this,%power,%generator) {}
function DeployableTaserTrtB::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//-------------------------------------------------------------
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
	description = "Laser Turret System";
	damageSkinData = "objectDamageSkins";
};

function LaserTurret::onAdd(%this)
{
	schedule("LaserTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Laser Turret System");
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
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		%client = Player::getClient(%this);
		GameBase::applyDamage(%client,$Debrisdamagetype,10.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);
}

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
	description = "Plasma Turret System";
	damageSkinData = "objectDamageSkins";
};

function LaserTurretB::onAdd(%this)
{
	schedule("LaserTurretB::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Plasma Turret System");
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
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		%client = Player::getClient(%this);
		GameBase::applyDamage(%client,$Debrisdamagetype,10.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);
}

function LaserTurretB::onPower(%this,%power,%generator) {}
function LaserTurretB::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

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
	range = 500;
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
	description = "Scan Tracker Network";
	damageSkinData = "objectDamageSkins";
};

function DeployableTaserTrtC::onAdd(%this)
{
	schedule("DeployableTaserTrtC::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Scan Tracker Network");
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
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiscDeb",%trans,%this,0);
		%client = Player::getClient(%this);
		GameBase::applyDamage(%client,$Debrisdamagetype,10.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);
}

function DeployableTaserTrtC::onPower(%this,%power,%generator) {}
function DeployableTaserTrtC::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,20);
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
		description = "ELF Turret System";
	
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
		GameBase::setMapName (%this, "ELF Turret System");
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
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		%client = Player::getClient(%this);
		GameBase::applyDamage(%client,$Debrisdamagetype,10.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);
}

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
	description = "B.o.P Turret System";

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
		GameBase::setMapName (%this, "B.o.P Turret System");
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
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		%client = Player::getClient(%this);
		GameBase::applyDamage(%client,$Debrisdamagetype,10.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);
}

function MiniSmokeTurret::onPower(%this,%power,%generator) {}
function MiniSmokeTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//----------

TurretData MiniFlakTurret
{
	className = "Turret";
	shapeFile = "mortar_turret";
	projectileType = MiniFlakproj;
	maxDamage = 1;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 20;
        range = 75;
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
	description = "Flak Turret System";
	damageSkinData = "objectDamageSkins";
};

//-------------------------------------------------------------------------------

function MiniFlakTurret::onAdd(%this)
{
	schedule("MiniFlakTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Flak Turret System");
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
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("MiniFlakproj",%trans,%this,0);
		%client = Player::getClient(%this);
		GameBase::applyDamage(%client,$Debrisdamagetype,10.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);
}

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
	description = "S.A.M Turret System";
	damageSkinData = "objectDamageSkins";
};

function MiniSAMTurret::onAdd(%this)
{
	schedule("MiniSAMTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "S.A.M Turret System");
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
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		 Projectile::spawnProjectile("RTDeb",%trans,%this,0);
		%client = Player::getClient(%this);
		GameBase::applyDamage(%client,$Debrisdamagetype,10.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);
}

function MiniSAMTurret::onPower(%this,%power,%generator) {}
function MiniSAMTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}


//-------------------------------------------------------------
TurretData MiniGripTurret
{	className = "Turret";
	shapeFile = "remoteturret";//camera,
	projectileType = IonEEBolt;
	maxDamage = 0.65;
	maxEnergy = 100;
	minGunEnergy = 1.0;
	maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.2;
	speed = 3.0;
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
	description = "Grip Turret System";
	damageSkinData = "objectDamageSkins";
};	

function MiniGripTurret::onAdd(%this)
{	schedule("MiniGripTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.05;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "GRIP Turret System");
}

function MiniGripTurret::deploy(%this) 
{	GameBase::playSequence(%this,1,"deploy");
}

function MiniGripTurret::onEndSequence(%this,%thread) 
{	GameBase::setActive(%this,true);
}

function MiniGripTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MiniGripTurretPack"]--;
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this,-100);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		 Projectile::spawnProjectile("ELECDeb",%trans,%this,0);
		%client = Player::getClient(%this);
		GameBase::applyDamage(%client,$Debrisdamagetype,10.05,GameBase::getPosition(%client),"0 0 0","0 0 0",%client);
}

function MiniGripTurret::onPower(%this,%power,%generator) 
{
}

function MiniGripTurret::onEnabled(%this) 
{	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}
// =====================================
// New VX6 Devices
// =====================================

//========================================================================================== Arbitor Beacon
TurretData ArbitorBeacon
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
	description = "Cloak Device";
	damageSkinData = "objectDamageSkins";
};

function ArbitorBeacon::onAdd(%this)
{
	schedule("ArbitorBeacon::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Cloak Device");
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
	description = "Flux Device";
	damageSkinData = "objectDamageSkins";
};

function EMPBeacon::onAdd(%this)
{

	schedule("EMPBeacon::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Flux Device");
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

		if (%obj != %this && (%armor != "harmor" || %armor != "larmor" || %armor != "marmor" || %armor != "lfemale" || %armor != "mfemale"))
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
	schedule("EMPBeacon::checkEMPBeacon(" @ %this @ ");", 5.0, %this); //then recheck in 10 seconds
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

//====== ElectricWeb PlasmaDoorTurr
// By: BioHazard
// Modified By: *SlipKnot*

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
function PlasmaDoorTurr::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "ElectricWeb"]--; }
function PlasmaDoorTurr::onPower(%this,%power,%generator) {}
function PlasmaDoorTurr::onEnabled(%this) { schedule("PlasmaDoorTurr::checkPlasmaDoorTurr(" @ %this @ ");", 0.1, %this); }

function PlasmaDoorTurr::checkPlasmaDoorTurr(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	%Set = newObject("empset",SimSet);
	%Pos = GameBase::getPosition(%this);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself

	containerBoxFillSet(%Set, %Mask, %Pos, 4, 4, 3,0);

	%num = Group::objectCount(%Set);

	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);

		if (getObjectType(%obj) == "Player")
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				GameBase::applyDamage(%obj,$WebDamageType, 1.0,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this);
				GameBase::applyDamage(%obj,$WebDamageType, 10.0,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this);
				schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %obj @ "));",0.1);
			}
			else
			{
			}
		}
	}
	deleteObject(%set);
	schedule("PlasmaDoorTurr::checkPlasmaDoorTurr(" @ %this @ ");", 0.1, %this); //then recheck in 0.1 seconds
}
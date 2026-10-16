
//--------------------------------------------

TurretData AutoPlasmaTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = MiniFusionBolt;
	maxDamage = 1.0;
	maxEnergy = 60;
	minGunEnergy = 5;
	maxGunEnergy = 6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
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
	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "AutoPlasma Turret";
	damageSkinData = "objectDamageSkins";
};

function AutoPlasmaTurret::onAdd(%this)
{
	schedule("AutoPlasmaTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "AutoPlasma Turret");
	}
}

function AutoPlasmaTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function AutoPlasmaTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function AutoPlasmaTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "AutoPlasmaTurretPack"]--;
	if($Eradication::showDestructionMessages)
	  	MessageAll(0, "A "@ $Server::teamName[GameBase::getTeam(%this)] @" autoplasma turret was destroyed.");
}

// Override base class just in case.
function AutoPlasmaTurret::onPower(%this,%power,%generator) {}
function AutoPlasmaTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


function AutoPlasmaTurret::onControl (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
}

function AutoPlasmaTurret::onDismount (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Leaving turret " @ %this);
}

TurretData BlasterTurret
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = BlasterTurretBolt;
	maxDamage = 0.7;
	maxEnergy = 50;
	minGunEnergy = 5;
	maxGunEnergy = 6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.3;
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
	fireSound = SoundFireBlaster;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Blaster Turret";
	damageSkinData = "objectDamageSkins";
};

function BlasterTurret::onAdd(%this)
{
	schedule("BlasterTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Blaster Turret");
	}
}

function BlasterTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function BlasterTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function BlasterTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "BlasterTurretPack"]--;
	if($Eradication::showDestructionMessages)
 	  	MessageAll(0, "A "@ $Server::teamName[GameBase::getTeam(%this)] @" blaster turret was destroyed.");
}

// Override base class just in case.
function BlasterTurret::onPower(%this,%power,%generator) {}
function BlasterTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


function BlasterTurret::onControl (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
}

function BlasterTurret::onDismount (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Leaving turret " @ %this);
}

TurretData CameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 0.7;
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
  	if($Eradication::showDestructionMessages)
		MessageAll(0, "A "@ $Server::teamName[GameBase::getTeam(%this)] @" camera was destroyed.");
}	


function CameraTurret::onControl (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
}

function CameraTurret::onDismount (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Leaving turret " @ %this);
}


TurretData ChaingunTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = ChaingunTurretBullet;
	maxDamage = 1.0;
	maxEnergy = 50;
	minGunEnergy = 6;
	maxGunEnergy = 8;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.25;
	speed = 4.0;
	speedModifier = 1.5;
	range = 45;
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
	explosionId = flashExpMedium;
	description = "Chaingun Turret";
	damageSkinData = "objectDamageSkins";
};

function ChaingunTurret::onAdd(%this)
{
	schedule("ChaingunTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Chaingun Turret");
	}
}

function ChaingunTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ChaingunTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function ChaingunTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ChaingunTurretPack"]--;
  	if($Eradication::showDestructionMessages)
		MessageAll(0, "A "@ $Server::teamName[GameBase::getTeam(%this)] @" chaingun turret was destroyed.");
}

// Override base class just in case.
function ChaingunTurret::onPower(%this,%power,%generator) {}
function ChaingunTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


function ChaingunTurret::onControl (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
}

function ChaingunTurret::onDismount (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Leaving turret " @ %this);
}

TurretData DiscTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = DiscTurretShell;
	maxDamage = 1.5;
	maxEnergy = 40;
	minGunEnergy = 20;
	maxGunEnergy = 20;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.0;
	speed = 2.0;
	speedModifier = 2.0;
	range = 125;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireDisc;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	explosionId = debrisExpMedium;
	description = "Remote Turret";
	damageSkinData = "objectDamageSkins";
};

function DiscTurret::onAdd(%this)
{
	schedule("DiscTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Disc Turret");
	}
}

function DiscTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DiscTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DiscTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "DiscTurretPack"]--;
  	if($Eradication::showDestructionMessages)
	  	MessageAll(0, "A "@ $Server::teamName[GameBase::getTeam(%this)] @" disc turret was destroyed.");
}

// Override base class just in case.
function DiscTurret::onPower(%this,%power,%generator) {}
function DiscTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


function DiscTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

function DiscTurret::onControl (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
}

function DiscTurret::onDismount (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Leaving turret " @ %this);
}

function DiscTurret::checkOperator(%this)
{
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1) {
   	%pl = Client::getOwnedObject(%cl);
		Player::setMountObject(%pl, -1,0);
	   Client::setControlObject(%cl, %pl);
   }
	Client::setGuiMode(%cl,2);
}

TurretData ELFTurret	   
{			 
	maxDamage = 1.5;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 75;
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

function ELFTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	if($Eradication::showDestructionMessages)
	  	MessageAll(0, "A "@ $Server::teamName[GameBase::getTeam(%this)] @" ELF turret was destroyed.");
}

TurretData FusionTurret
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = PlasmaBolt;
	maxDamage = 1.5;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 8;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.75;
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
	debrisId = flashDebrisLarge;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	explosionId = flashExpMedium;
	description = "Fusion Turret";
	damageSkinData = "objectDamageSkins";
};

function FusionTurret::onAdd(%this)
{
	schedule("FusionTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Fusion Turret");
	}
}

function FusionTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function FusionTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function FusionTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "FusionTurretPack"]--;
  	if($Eradication::showDestructionMessages)
	  	MessageAll(0, "A "@ $Server::teamName[GameBase::getTeam(%this)] @" fusion turret was destroyed.");
}

// Override base class just in case.
function FusionTurret::onPower(%this,%power,%generator) {}
function FusionTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

function FusionTurret::onControl (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
}

function FusionTurret::onDismount (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Leaving turret " @ %this);
}


TurretData GrenadeTurret
{
	className = "Turret";
	shapeFile = "mortar_turret";
	projectileType = GrenadeTurretShell;
	maxDamage = 2.0;
	maxEnergy = 100;
	minGunEnergy = 10;
	maxGunEnergy = 10;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.5;
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
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireGrenade;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	explosionId = LargeShockwave;
	description = "Grenade Turret";
	damageSkinData = "objectDamageSkins";
};

function GrenadeTurret::onAdd(%this)
{
	schedule("GrenadeTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Grenade Turret");
	}
}

function GrenadeTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function GrenadeTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function GrenadeTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "GrenadeTurretPack"]--;
  	if($Eradication::showDestructionMessages)
	  	MessageAll(0, "A "@ $Server::teamName[GameBase::getTeam(%this)] @" grenade turret was destroyed.");
}

// Override base class just in case.
function GrenadeTurret::onPower(%this,%power,%generator) {}
function GrenadeTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	



function GrenadeTurret::onControl (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
}

function GrenadeTurret::onDismount (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Leaving turret " @ %this);
}

TurretData IndoorTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = MiniFusionBolt;
	maxDamage = 2.5;
	maxEnergy = 75;
	minGunEnergy = 20;
	maxGunEnergy = 6;
	reloadDelay = 0.4;
	speed = 5.0;
	speedModifier = 1.0;
	range = 50;
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

function IndoorTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	if($Eradication::showDestructionMessages)
	  	MessageAll(0, "A "@ $Server::teamName[GameBase::getTeam(%this)] @" indoor turret was destroyed.");
}

TurretData LaserTurret
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = TurretLaser;
	maxDamage = 1.5;
	maxEnergy = 100;
	minGunEnergy = 40;
	maxGunEnergy = 40;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 7;
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
	debrisId = defaultDebrisLarge;
	shieldShapeName = "shield_medium";
	fireSound = SoundFireLaser;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	explosionId = LargeShockwave;
	description = "Laser Turret";
	damageSkinData = "objectDamageSkins";
};

function LaserTurret::onAdd(%this)
{
	schedule("LaserTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,8);
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
  	if($Eradication::showDestructionMessages)
	  	MessageAll(0, "A "@ $Server::teamName[GameBase::getTeam(%this)] @" laser turret was destroyed.");
}

// Override base class just in case.
function LaserTurret::onPower(%this,%power,%generator) {}
function LaserTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


function LaserTurret::onControl (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
}

function LaserTurret::onDismount (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Leaving turret " @ %this);
}

TurretData MortarTurret
{
	maxDamage = 1.5;
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

function MortarTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	if($Eradication::showDestructionMessages)
	  	MessageAll(0, "A "@ $Server::teamName[GameBase::getTeam(%this)] @" mortar turret was destroyed.");
}

TurretData PlasmaTurret
{
	maxDamage = 1.25;
	maxEnergy = 75;
	minGunEnergy = 6;
	maxGunEnergy = 8;
	reloadDelay = 0.6;
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

function PlasmaTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	if($Eradication::showDestructionMessages)
	  	MessageAll(0, "A "@ $Server::teamName[GameBase::getTeam(%this)] @" plasma turret was destroyed.");
}

TurretData RocketTurret
{
	maxDamage = 1.0;
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

function RocketTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	if($Eradication::showDestructionMessages)
	  	MessageAll(0, "A "@ $Server::teamName[GameBase::getTeam(%this)] @" rocket turret was destroyed.");
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

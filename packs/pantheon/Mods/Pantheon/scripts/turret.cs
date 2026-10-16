//----------------------------------------------------------------------------
// TURRET DYNAMIC DATA

function PlasmaEject(%player)
{
  %rot = GameBase::getRotation(%player);
  %rad = getWord(%rot, 2);
  %x = (-1) * (ixSin(%rad));
  %y = ixCos(%rad);
  %dir = %x @ " " @ %y @ " 0";
  %force = ixDotProd(Vector::neg(%dir), 6);
  %x = getWord(%force, 0);
  %y = getWord(%force, 1);
  %vel = %x @ " " @ %y @ " " @ 3;
  Item::setVelocity(%player, %vel);
}

TurretData PlasmaTurret
{
	maxDamage = 1.0;
	maxEnergy = 100;
	minGunEnergy = 1;
	maxGunEnergy = 6;
	reloadDelay = 0.3;
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
	speed = 3.0;
	speedModifier = 2.0;
	projectileType = FusionBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Plasma Turret";
	triggerRadius = 1.0;
};

function PlasmaTurret::onCollision(%this, %object)
{
	PlasmaEject(%object);
}

TurretData ProximityAlarm
{
	className = "Turret";
	shapeFile = "sensor_small";
	projectileType = DissectionLaser;
	maxDamage = 0.45;
	maxEnergy = 300;
	minGunEnergy = 90;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 50.0;
	speed = 0.5;
	speedModifier = 1.0;
	range = 15;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = false;
	pinger = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Base Alarm";
	damageSkinData = "objectDamageSkins";
};

function ProximityAlarm::verifyTarget(%this,%target)
{
	if (getSimTime() - $AlarmTime[%this] > 5)
	{
		%dist = Vector::getDistance(%this, %target);
		if (Vector::getDistance(%this, %target) <= 15)
		{
			$AlarmTime[%this] = getSimTime();
			%team = GameBase::getteam(%this);
			%client = Player::getClient(%target);
			TeamMessages(1, %team, GameBase::GetMapName(%this) @ " has been tripped by " @ Client::getName(%client) @ " Dist:" @ %dist @ "~wLeftMissionArea.wav");
			echo("Trip: " @ Vector::getDistance(%this, %target));
		}
	}
	return false;
}

function ProximityAlarm::onAdd(%this)
{
	schedule("ProximityAlarm::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Proximity Alarm");
	}
}

function ProximityAlarm::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ProximityAlarm::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function ProximityAlarm::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	TeamMessages(1, GameBase::getTeam(%this),GameBase::GetMapName(%this) @  " has been destroyed! ~wLeftMissionArea.wav");
  	$TeamItemCount[GameBase::getTeam(%this) @ "ProximityAlarmPack"]--;
}

function ProximityAlarm::onPower(%this,%power,%generator) {}
function ProximityAlarm::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


TurretData PlasmaTurretDecoy
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = FusionBolt;
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 500;
	maxGunEnergy = 500;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 50.0;
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
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;

	explosionId = flashExpMedium;
	description = "Plasma Turret";
	damageSkinData = "objectDamageSkins";
};

function PlasmaTurretDecoy::onAdd(%this)
{
	schedule("PlasmaTurretDecoy::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.030;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Plasma Turret");
	}
}

function PlasmaTurretDecoy::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function PlasmaTurretDecoy::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function PlasmaTurretDecoy::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "PlasmaTurretDecoy"]--;
}

// Override base class just in case.
function PlasmaTurretDecoy::onPower(%this,%power,%generator) {}
function PlasmaTurretDecoy::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


TurretData VulcanTurret
{
	className = "Turret";
	shapeFile = "chainturret";
	projectileType = VulcanBullet;
	maxDamage = 0.5;
	maxEnergy = 200;
	minGunEnergy = 1;
	maxGunEnergy = 2;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.015;
	speed = 3.0;
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
	activationSound = SoundChainTurretOn;
	deactivateSound = SoundChainTurretOff;
	whirSound = SoundChainTurretTurn;

	explosionId = flashExpMedium;
	description = "Vulcan Turret";
	damageSkinData = "objectDamageSkins";
};

function VulcanTurret::onDestroyed(%this)
{
	%client = GameBase::getControlClient(%this.lastDamageObject);	
	%objectTeam = GameBase::getTeam(%this);
	%playerTeam = GameBase::getTeam(%client);
	if (%objectTeam == %playerTeam)
	{
		if ($Pantheon::KillFriendlyVulcanPoints)
		{
			bottomprint(%client, "You lose 1 point for destroying your own turret!");
			%client.Score -= 1;
			%client.Turrets -= 1;
			Game::refreshClientScore(%client);
		}
	}
	else if (%objectTeam != %playerTeam)
	{
		if ($Pantheon::KillEnemyVulcanPoints)
		{
			bottomprint(%client, "You get 1 point for destroying the enemy's turret.");
			%client.Score += 1;
			%client.Turrets += 1;
			Game::refreshClientScore(%client);
		}
	}
	Turret::onDestroyed(%this);
}

//function VulcanTurret::onEnabled(%this) 
//{
//	GameBase::setRechargeRate(%this,5);
//	GameBase::setActive(%this,true);
//}

TurretData ELFTurret	   
{			 
	maxDamage = 1.0;
	maxEnergy = 100;
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

TurretData RocketTurret
{
	maxDamage = 0.75;
	maxEnergy = 200;
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
	speed = 2.5;
	speedModifier = 2.1;
	projectileType = TurretMissile;
	reloadDelay = 2.5;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
//	whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
   targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "Missile Turret";
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

//--------------------------------------------
TurretData DumbRocketTurret
{
	maxDamage = 0.3;
	maxEnergy = 5;
	minGunEnergy = 1;
	maxGunEnergy = 400;
	range = 125;
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
	speed = 2.5;
	speedModifier = 2.1;
	projectileType = ScoutRocket;
	reloadDelay = 0.45;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Rocket Battery";
};

function DumbRocketTurret::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,20);
	}
	else {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
	}
	GameBase::setActive(%this,%power);
}

//--------------------------------------------

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
																						 
//--------------------------------------------

TurretData IndoorTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = MiniFusionBolt;
	maxDamage = 1.5;
	maxEnergy = 60;
	minGunEnergy = 20;
	maxGunEnergy = 6;
	reloadDelay = 0.4;
	speed = 5.0;
	speedModifier = 1.0;
	range = 45;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
//	supressable = false;
//	pinger = false;
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

function IndoorTurret::onPower(%this,%power,%generator) {}
function IndoorTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


//--------------------------------------------

TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = MiniFusionBolt;
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

TurretData DeployableDissection
{
	className = "Turret";
	shapeFile = "camera"; //"remoteturret";
	projectileType = DissectionLaser;
	maxDamage = 0.65;
	maxEnergy = 200;
	minGunEnergy = 75;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
	speed = 4.0;
	speedModifier = 1.5;
	range = 40;
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
	description = "Dissection Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableDissection::onAdd(%this)
{
	schedule("DeployableDissection::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.005;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Dissection Turret");
	}
}

function DeployableDissection::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableDissection::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableDissection::onDestroyed(%this)
{
	%client = GameBase::getControlClient(%this.lastDamageObject);	
	%objectTeam = GameBase::getTeam(%this);
	%playerTeam = GameBase::getTeam(%client);
	if (%objectTeam == %playerTeam)
	{
		bottomprint(%client, "You lose 1 point for destroying your own turret!");
		%client.Score -= 1;
		%client.Turrets -= 1;
		Game::refreshClientScore(%client);
	}
//	else if (%objectTeam != %playerTeam)
//	{
//		bottomprint(%client, "You get 1 point for destroying the enemy's turret.");
//		%client.Score += 1;
//		Game::refreshClientScore(%client);
//	}
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "DissectionPack"]--;
}

// Override base class just in case.
function DeployableDissection::onPower(%this,%power,%generator) {}
function DeployableDissection::onEnabled(%this) 
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
	maxEnergy = 150;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.3;
	speed = 3.0;
	speedModifier = 2.0;
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
	description = "Plasma Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployablePlasma::onCollision(%this, %object)
{
	PlasmaEject(%object);
}

function DeployablePlasma::onAdd(%this)
{
	schedule("DeployablePlasma::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.05;
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
  	$TeamItemCount[GameBase::getTeam(%this) @ "PlasmaPack"]--;
}

// Override base class just in case.
function DeployablePlasma::onPower(%this,%power,%generator) {}
function DeployablePlasma::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


//--------------------------------------------

TurretData DeployableVulcan
{
	className = "Turret";
	shapeFile = "chainturret";
	projectileType = VulcanBullet;
	maxDamage = 0.5;
	maxEnergy = 300;
	minGunEnergy = 1;
	maxGunEnergy = 2;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.015;
	speed = 3.0;
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
	activationSound = SoundChainTurretOn;
	deactivateSound = SoundChainTurretOff;
	whirSound = SoundChainTurretTurn;

	explosionId = flashExpMedium;
	description = "Vulcan Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableVulcan::onAdd(%this)
{
	schedule("DeployableVulcan::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,7);
	%this.shieldStrength = 0.01;
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
	%client = GameBase::getControlClient(%this.lastDamageObject);	
	%objectTeam = GameBase::getTeam(%this);
	%playerTeam = GameBase::getTeam(%client);
	if (%objectTeam == %playerTeam)
	{
		bottomprint(%client, "You lose 1 point for destroying your own turret!");
		%client.Score -= 1;
		%client.Turrets -= 1;
		Game::refreshClientScore(%client);
	}
	else if (%objectTeam != %playerTeam)
	{
		bottomprint(%client, "You get 1 point for destroying the enemy's turret.");
		%client.Score += 1;
		%client.Turrets += 1;
		Game::refreshClientScore(%client);

	}
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "VulcanPack"]--;
}

// Override base class just in case.
function DeployableVulcan::onPower(%this,%power,%generator) {}
function DeployableVulcan::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,7);
	GameBase::setActive(%this,true);
}	


//--------------------------------------------

TurretData DeployableLaser
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = SniperLaser;
	maxDamage = 1.0;
	maxEnergy = 75;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 9.0;
	speed = 1.0;
	speedModifier = 1.5;
	range = 40;
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
	description = "Laser Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableLaser::onAdd(%this)
{
	schedule("DeployableLaser::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Laser Turret");
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
	%client = GameBase::getControlClient(%this.lastDamageObject);	
	%objectTeam = GameBase::getTeam(%this);
	%playerTeam = GameBase::getTeam(%client);
	if (%objectTeam == %playerTeam)
	{
		if ($Pantheon::KillFriendlyLaserPoints)
		{
			bottomprint(%client, "You lose 1 point for destroying your own turret!");
			%client.Score -= 1;
			%client.Turrets -= 1;
			Game::refreshClientScore(%client);
		}
	}
	else if (%objectTeam != %playerTeam)
	{
		if ($Pantheon::KillEnemyLaserPoints)
		{
			bottomprint(%client, "You get 1 point for destroying the enemy's turret.");
			%client.Score += 1;
			Game::refreshClientScore(%client);
		}
	}
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LaserPack"]--;
}

// Override base class just in case.
function DeployableLaser::onPower(%this,%power,%generator) {}
function DeployableLaser::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,8);
	GameBase::setActive(%this,true);
}	

//=------------------------------------
TurretData DeployableShock
{
	maxDamage = 2.0;
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
	//%this.shieldStrength = 0;
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Shock Turret");
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


//--------------------------------------------
//=-=-=-=- Deployable Rocket Turret =-=-=-=-
//--------------------------------------------

TurretData DeployableRocket
{
	className = "Turret";
	shapeFile = "missileturret";
	projectileType = TurretMissile;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 25;
	maxGunEnergy = 25;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.5;
	speed = 4.0;
	speedModifier = 1.5;
	range = 250;
	visibleToSensor = true;
	shadowDetailMask = 8;
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
	description = "Missile Turret";
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
	%this.shieldStrength = 0.025;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Missile Turret");
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
	StaticShape::objectiveDestroyed (%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate (%this, 0);
	Turret::onDeactivate (%this);
	Turret::objectiveDestroyed (%this);
	CalcRadiusDamage (%this, $DebrisDamageType, 20, 0.2, 25, 20, 20, 2.5, 1.1, 200, 100);
	$TeamItemCount[GameBase::getTeam (%this) @ "RocketPack"]--;

//	Turret::onDestroyed(%this);
//  	$TeamItemCount[GameBase::getTeam(%this) @ "RocketPack"]--;
}

// Override base class just in case.
function DeployableRocket::onPower(%this,%power,%generator) {}
function DeployableRocket::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//--------------------------------------------

//--------------------------------------------
//=-=-=-=- Deployable Unguided Rocket Turret =-=-=-=-
//--------------------------------------------

TurretData DeployableDumbRocket
{
	className = "Turret";
	shapeFile = "missileturret";
	projectileType = ScoutRocket;
	maxDamage = 0.65;
	maxEnergy = 100;
	minGunEnergy = 9;
	maxGunEnergy = 10;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.3;
	speed = 3.0;
	speedModifier = 1.5;
	range = 125;
	visibleToSensor = true;
	shadowDetailMask = 8;
	dopplerVelocity = 2;
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
	description = "Rocket Battery";
	damageSkinData = "objectDamageSkins";
};

//function DeployableDumbRocket::verifyTarget(%target)
//{
//   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
//      return "True";
//   else
//      return "False";
//}


function DeployableDumbRocket::onAdd(%this)
{
	schedule("DeployableRocket::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,3);
	%this.shieldStrength = 0.025;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Rocket Turret");
	}
}

function DeployableDumbRocket::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableDumbRocket::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableDumbRocket::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed (%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate (%this, 0);
	Turret::onDeactivate (%this);
	Turret::objectiveDestroyed (%this);
	CalcRadiusDamage (%this, $DebrisDamageType, 20, 0.2, 25, 20, 20, 2.5, 1.1, 200, 100);
	$TeamItemCount[GameBase::getTeam (%this) @ "DumbRocketPack"]--;

//	Turret::onDestroyed(%this);
//  	$TeamItemCount[GameBase::getTeam(%this) @ "DumbRocketPack"]--;
}

// Override base class just in case.
function DeployableDumbRocket::onPower(%this,%power,%generator) {}
function DeployableDumbRocket::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//--------------------------------------------

TurretData DeployableMortar 
{
  className = "Turret";
  shapeFile = "mortar_turret";
  projectileType = MortarTurretShell;
  maxDamage = 1.0;
  maxEnergy = 45;
  minGunEnergy = 45;
  maxGunEnergy = 100;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 2.0;
  speed = 2.0;
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
  fireSound = SoundMortarTurretFire;
  activationSound = SoundMortarTurretOn;
  deactivateSound = SoundMortarTurretOff;
  whirSound = SoundMortarTurretTurn;
  explosionId = LargeShockwave;
  description = "Mortar Turret";
  damageSkinData = "objectDamageSkins";
};

function DeployableMortar::onAdd(%this) 
{
  schedule("DeployableMortar::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,7);
  %this.shieldStrength = 0.005;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Mortar Turret");
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
  $TeamItemCount[GameBase::getTeam(%this) @ "MortarTurretPack"]--;
}

function DeployableMortar::onPower(%this,%power,%generator) 
{
}

function DeployableMortar::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,7);
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
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 0.1, 200, 100); 
}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS=1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = $Server::TeamDamageScale;
	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
	if (%type == $EMPDamageType)
	GameBase::setEnergy (%this, 0);

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

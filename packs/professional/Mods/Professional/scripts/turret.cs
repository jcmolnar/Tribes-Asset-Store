//----------------------------------------------------------------------------
// TURRET DYNAMIC DATA

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
	className = "Turret";
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


//--------------------------------------------

TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = MiniFusionBolt;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 1;
	maxGunEnergy = 0;
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
	description = "Sentry Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.0125;
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
	shapeFile = "missileturret";
	projectileType = TurretMissile;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 25;
	maxGunEnergy = 25;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 3.5;
	speed = 2.0;
	speedModifier = 1.0;
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
	%this.shieldStrength = 0.0125;
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
//=-=-=-=- Deployable ELF Turret =-=-=-=-
//--------------------------------------------

TurretData DeployableElfTurret
{
	maxDamage = 0.6;
	maxEnergy = 50;
	minGunEnergy = 1;
	maxGunEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	range = 40;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "chainturret";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = turretShock;
	reloadDelay = 0.15;
	explosionId = flashExpMedium;
	description = "Shock Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 4;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 5.0;
};

function DeployableElfTurret::onAdd(%this)
{
	schedule("DeployableElfTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.0125;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Shock Turret");
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
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableELFTurretPack"]--;
}
// Override base class just in case.
function DeployableElfTurret::onPower(%this,%power,%generator) {}

function DeployableElfTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//--------------------------------------------

TurretData CameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 1.0;
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
//			//Player::mountObject (%object, %this);
//			Client::getOwnedObject(%client).CommandTag = 1;
//			Client::sendMessage(%client,0,"Manually controlling turret");
//			Client::takeControl(%client, %this);
//			GameBase::SetPosition(%object,GameBase::GetPosition(%this));
// 			return;
//		}
//}

// Minimod Stuff

// This is a MiniMod Plugin.
// This plugin is the Chaingun Turret from the Bitchin mod. Ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    ChainTurret.ArmorData.cs
//    ChainTurret.baseProjData.cs
//    ChainTurret.item.cs
//    ChainTurret.reinitData.cs
//    ChainTurret.station.cs
//    ChainTurret.turret.cs
//
// to your MiniMod/plugins directory.

TurretData DeployableChaingun
{
	className = "Turret";
	shapeFile = "remoteturret";
        projectileType = ChaingunTurretBullet;
	maxDamage = 0.65;
        maxEnergy = 30;
        minGunEnergy = 5;
        maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.2;
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
        fireSound = SoundPickupAmmo;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
        description = "Remote Chaingun";
	damageSkinData = "objectDamageSkins";
};

function DeployableChaingun::onAdd(%this)
{
        schedule("DeployableChaingun::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,10);
        %this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Remote Chaingun");
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


// This is a MiniMod Plugin.
// This plugin is the Death of Bots.
// Note: Code is based off of PeterT's Watchdog Turret plugin.
// Ported by Dewy then modified further by PeterT.

TurretData DeployableDoB
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = DoBLaser;
	maxDamage = 0.65;
	maxEnergy = 300;
	minGunEnergy = 75;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
	speed = 4.0;//4.0
	speedModifier = 1.5;//1.5
	range = 150;
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
	description = "Pulse Laser";
	damageSkinData = "objectDamageSkins";
};

function DeployableDoB::onAdd(%this)
{
	schedule("DeployableDissection::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "DoB");
	}
}

function DeployableDoB::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableDoB::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableDoB::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "DoBPack"]--;
}

// Override base class just in case.
function DeployableDoB::onPower(%this,%power,%generator) {}
function DeployableDoB::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

// This is a MiniMod Plugin.
// This plugin is the Flak Turret from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    FlakTurret.ArmorData.cs
//    FlakTurret.baseProjData.cs
//    FlakTurret.item.cs
//    FlakTurret.reinitData.cs
//    FlakTurret.station.cs
//    FlakTurret.turret.cs
//
// to your MiniMod/plugins directory.

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
	description = "Remote Turret";
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

// This is a MiniMod Plugin.
// This plugin is the Flame Turret from the Ideal mod.
// Ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    Flame Turret.ArmorData.cs
//    Flame Turret.baseExpData.cs
//    Flame Turret.baseProjData.cs
//    Flame Turret.item.cs
//    Flame Turret.Nsound.cs
//    Flame Turret.reinitData.cs
//    Flame Turret.staticshape.cs
//    Flame Turret.station.cs
//    Flame Turret.turret.cs
//
// to your MiniMod/plugins directory.

TurretData FlameTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = FlameLarge;
	maxDamage = 0.55;
	maxEnergy = 30;
	minGunEnergy = 3;
	maxGunEnergy = 2;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.02;
	speed = 4.0;
	speedModifier = 1.5;
	range = 10;
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = false;
	pinger = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_Radar";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFlameTurret;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Flame Turret";
	damageSkinData = "objectDamageSkins";
};

function FlameTurret::onAdd(%this)
{
	schedule("FlameTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
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
	GameBase::setDamageLevel(%this.cyl, 0.6);
}

// Override base class just in case.
function FlameTurret::onPower(%this,%power,%generator) {}
function FlameTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}


// This is a MiniMod Plugin.
// This plugin is the GuardDog (Shockwave) Turret from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    GuardDogTurret.ArmorData.cs
//    GuardDogTurret.baseProjData.cs
//    GuardDogTurret.item.cs
//    GuardDogTurret.reinitData.cs
//    GuardDogTurret.station.cs
//    GuardDogTurret.turret.cs
//
// to your MiniMod/plugins directory.

TurretData DeployableConTurret //TurretData name, used in item.cs 3 times
{
	className = "Turret";//type classification
	shapeFile = "chainturret"; //"remoteturret";  shape, texture used
	projectileType = Watch;//projectile fired
	maxDamage = 1.5;//stamina of unshielded turret
	maxEnergy = 300;//amount of turret energy
	minGunEnergy = 75;//?
	maxGunEnergy = 10;//?
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };//sound made when deployed
	reloadDelay = 1.5;//0.05,delay between shots (sec)
	speed = 2.0;//4.0; traverse speed?
	speedModifier = 1.5;//?
	range = 150;//sensor range of turret
	visibleToSensor = true;//shows up on command screen (y,n)
	shadowDetailMask = 4;//?
	dopplerVelocity = 1; //2; 0=free attack, 2=motion sensitive?
	castLOS = true;//tracks when target not visible?
	supression = false;//acts as sensor jammer, true=yes
	suppressable = false;//can be jammed, true=yes?
	pinger = false;//?
	mapFilter = 2;//?
	mapIcon = "M_turret";//icon as appears on command screen
	debrisId = flashDebrisLarge;//debris graphic
	shieldShapeName = "shield";//shield type?
	fireSound = SoundPlasmaTurretFire;//sound when firing
	activationSound = SoundChainTurretOn;//sound when on
	deactivateSound = SoundChainTurretOff;//sound when off
	explosionId = debrisexplarge;//explosion graphic
	description = "Guard Dog";//description pertaining to ? file
	damageSkinData = "objectDamageSkins";//damage graphic
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

//This is a MiniMod plugin...
//This is a modified Laser Turret from the ol' Renegades 1.2 mod. Ported and reworked by Dewy

TurretData DeployableLaser
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = SniperLaser;
	maxDamage = 0.68;
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

//This is a MiniMod Plugin...
//This is the ELF turret from the ol' Renegades1.2 mod. Ported&Modified by Dewy.

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
	description = "Deployable Mini-ELF Turret";

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
	%this.shieldStrength = 0;
	//%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Mini-ELF Turret");
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

// This is a MiniMod Plugin.
// This is the Mini-Plasma turret created/ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    Mini-PlasmaTurret.ArmorData.cs
//    Mini-PlasmaTurret.baseProjData.cs
//    Mini-PlasmaTurret.item.cs
//    Mini-PlasmaTurret.reinitData.cs
//    Mini-PlasmaTurret.station.cs
//    Mini-PlasmaTurret.turret.cs
//
// to your MiniMod/plugins directory.

TurretData DeployableMiniPlasma
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = PlasmaBolt;
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
	description = "Mini-Plasma Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableMiniPlasma::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Turret");
	}
}

function DeployableMiniPlasma::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableMiniPlasma::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableMiniPlasma::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "PlasmaPack"]--;
}

// Override base class just in case.
function DeployableMiniPlasma::onPower(%this,%power,%generator) {}
function DeployableMiniPlasma::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

// This is a MiniMod plugin
// This is the Rail Turret From Ultra-Renegades.
// Code donated by URG_thrash, decompressed/ported by Dewy.

TurretData DeployableRail
{
className = "Turret";
shapeFile = "hellfiregun";
projectileType = railLaser;
maxDamage = 4.0;
maxEnergy = 155;
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
GameBase::setRechargeRate(%this,5);
GameBase::setActive(%this,true);
} 

// This is a MiniMod Plugin.
// This plugin is based on the Watchdog (Spotter) Turret from
// the hvTactical mod. It was initially ported by PeterT and
// then adapted by Epsilon into something quite different.
//
// To install this plugin just...
// Add:
//
//    SeekerTurret.ArmorData.cs
//    SeekerTurret.baseProjData.cs
//    SeekerTurret.item.cs
//    SeekerTurret.reinitData.cs
//    SeekerTurret.station.cs
//    SeekerTurret.turret.cs
//
// to your MiniMod/plugins directory.

TurretData DeployableSeeker
{
	className = "Turret";
	shapeFile = "camera"; //"remoteturret";
	projectileType = SeekerLaser;
	maxDamage = 2.50;
	maxEnergy = 300;
	minGunEnergy = 90;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.5;
	speed = 0.5;//0.5
	speedModifier = 1.0;//1.0
	range = 300;
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
	description = "Seeker";
	damageSkinData = "objectDamageSkins";
};

function DeployableSeeker::onAdd(%this)
{
	schedule("DeployableSeeker::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Seeker");
	}
}

function DeployableSeeker::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableSeeker::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableSeeker::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "SeekerPack"]--;
}


//new base alarm
TurretData DeployableAlarm
{
	className = "Turret";
	shapeFile = "sensor_small"; //"remoteturret";
	projectileType = SeekerLaser;
	maxDamage = 2.50;
	maxEnergy = 300;
	minGunEnergy = 90;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.5;
	speed = 0.5;//0.5
	speedModifier = 1.0;//1.0
	range = 15;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 1;//0;
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

function DeployableAlarm::verifyTarget(%this,%target)
{
	if (getSimTime() - $AlarmTime[%this] > 5)
	{
		%thispos = GameBase::getPosition(%this);
		%targetpos = GameBase::getPosition(%target);
		%dist = Vector::getDistance(%thispos, %targetpos);
		//echo("Distance to target is " @ %dist);
		if (%dist < 15)
		{
			$AlarmTime[%this] = getSimTime();
			%team =gamebase::getteam(%this);
			%client = Player::getClient(%target);
			TeamMessages(0, %team, GameBase::GetMapName(%this) @ " has detected " @ Client::getName(%client));
			//bottomprintall("Detected intruder",1);
		}
	}
	return false;
}

function DeployableAlarm::onAdd(%this)
{
	schedule("DeployableAlarm::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Base Alarm");
	}
}

function DeployableAlarm::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableAlarm::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableAlarm::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "BaseAlarm"]--;
}




// Override base class just in case.
function DeployablePussycat::onPower(%this,%power,%generator) {}
function DeployablePussycat::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


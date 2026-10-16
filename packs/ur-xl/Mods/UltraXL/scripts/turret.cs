//----------------------------------------------------------------------------
// TURRET DYNAMIC DATA

TurretData BAlarm 
{ 
className = "SensorTurret"; 
shapeFile = "camera"; 
projectileType = Laker; 
maxDamage = 0.5; 
maxEnergy = 50; 
minGunEnergy = 45; 
maxGunEnergy = 45; 
sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
reloadDelay = 10.0; 
speed = 5.0; 
speedModifier = 5.0; 
range = 19; 
visibleToSensor = true; 
shadowDetailMask = 4; 
dopplerVelocity = 2; 
castLOS = true; 
supression = false; 
pinger = false; 
supressable = false; 
mapFilter = 2; 
mapIcon = "M_turret"; 
debrisId = flashDebrisMedium; 
shieldShapeName = "shield"; 
fireSound = SoundMineActivate; 
explosionId = flashExpMedium; 
description = "Base Alarm"; 
damageSkinData = "objectDamageSkins"; 
}; 

function BAlarm::onAdd(%this) 
{ 
schedule("BAlarm::deploy(" @ %this @ ");",1,%this); 
GameBase::setRechargeRate(%this,6); 
%this.shieldStrength = 0.008; 
if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Base Alarm"); }
} 

function BAlarm::deploy(%this) 
{ 
GameBase::playSequence(%this,1,"deploy"); }

function BAlarm::onEndSequence(%this,%thread) 
{ 
GameBase::setActive(%this,true); 
} 

function BAlarm::onDestroyed(%this) 
{ 
teamMessages(0, GameBase::getTeam(%this), "Base Alarm has been destroyed.~wmine_act.wav", "", "", ""); 
%this.shieldStrength = 0; 
GameBase::setRechargeRate(%this,0); 
Turret::onDeactivate(%this); 
$TeamItemCount[GameBase::getTeam(%this) @ "BA"]--; 
} 

function BAlarm::onPower(%this,%power,%generator) {} 

function BAlarm::onEnabled(%this) 
{ 
GameBase::setRechargeRate(%this,6); 
GameBase::setActive(%this,true); 
} 

TurretData PlasmaTurret
{
	maxDamage = 1.0;
	maxEnergy = 500;
	minGunEnergy = 1;
	maxGunEnergy = 2;
	reloadDelay = 0.5;
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 150;
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
	projectileType = DiscShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Plasma Turret";
};
																						 
TurretData ELFTurret	   
{			 
	maxDamage = 1.0;
	maxEnergy = 350;
	minGunEnergy = 5;
	maxGunEnergy = 5;
	range = 150;
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
   energyRate      = 1.0;
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
//	reloadDelay = 1.5;
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
		%this.shieldStrength = 0.06;
		GameBase::setRechargeRate(%this,28);
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
	reloadDelay = 0.05;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 400;
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
	maxDamage = 2.5;
	maxEnergy = 100;
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
	maxDamage = 0.65;
	maxEnergy = 100;
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

TurretData DeployableMiniPlasma
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = PlasmaBolt;
	maxDamage = 0.65;
	maxEnergy = 100;
	minGunEnergy = 3;
	maxGunEnergy = 6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.15;
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
function turret::objectiveDestroyed(%this)
{
    
  dbecho(2,"turret destroyed");
  $numCompleted++;
  for(%i = 0; %i < $numTargets; %i++)
  {
    if(%this == $targets[%i])
	{
	  $completed[%i] = true;
	  %cl = Client::getFirst(); 
	  %this.destroyed = true;
	  bottomprint(%cl, "<f1><jc>You have destroyed " @ %this.objective, 5);
      Ai::soundHelper( 2050, 2049, cheer2 );
	  
	}
  }
//  checkTargetsDestroyed(%this);
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

// --------------watch dog turret addon

TurretData DeployableWatchdog
{
	className = "Turret";
	shapeFile = "camera"; //"remoteturret";
	projectileType = WatchdogLaser;
	maxDamage = 0.65;
	maxEnergy = 300;
	minGunEnergy = 75;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.6;
	speed = 4.0;//4.0
	speedModifier = 1.5;//1.5
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
	description = "Watchdog";
	damageSkinData = "objectDamageSkins";
};

function DeployableWatchdog::onAdd(%this)
{
	schedule("DeployableWatchdog::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Watchdog");
	}
}

function DeployableWatchdog::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableWatchdog::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableWatchdog::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "WatchdogPack"]--;
}

// Override base class just in case.
function DeployableWatchdog::onPower(%this,%power,%generator) {}
function DeployableWatchdog::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//-----------Arbitor Box------------------------------------------------

TurretData ArbitorBox
{
	className = "Turret";
	shapeFile = "magcargo";
//	projectileType = none;
	maxDamage = 2;
	maxEnergy = 0;
//	minGunEnergy = 6;
//	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
//	reloadDelay = 0.4;
//	speed = 4.0;
//	speedModifier = 1.5;
//	range = 10;
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
//	fireSound = SoundFireMortar;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Arbitor Box";
	damageSkinData = "objectDamageSkins";
};

function ArbitorBox::onAdd(%this)
{
	schedule("ArbitorBox::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Arbitor Box");
	}
}

function ArbitorBox::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ArbitorBox::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function ArbitorBox::onDisabled(%this)
{
	Turret::onDisabled(%this);

	%num = Group::objectCount(%this.set);
	for(%i=%num-1; %i >= 0; %i--)
	{
		%obj = Group::getObject(%this.set, %i);
		GameBase::startFadeIn(%obj);
		%obj.cloaked = 0;
	}
	deleteObject(%this.set);
}
function ArbitorBox::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ArbitorBoxPack"]--;
}

// Override base class just in case.
function ArbitorBox::onPower(%this,%power,%generator) {}
function ArbitorBox::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);

	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 50,0);
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

	schedule("ArbitorBox::checkArbitorBox(" @ %this @ ");", 0.1, %this);

}	

function ArbitorBox::checkArbitorBox(%this)
{

	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	%this.evenodd = !%this.evenodd; //switches from 1 to 0... tells every other check... used to check if in both new & old sets

	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 50,0);
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
			%obj.cloaked = 1 + %this.evenodd; //1 half the time & 2 other half... used to check if in this set while searching the old set
		}
	}


	%num = Group::objectCount(%this.set);

	for(%j; %j < %num; %j++)
	{
		%obj = Group::getObject(%this.set, %j);
		if(%obj == %this || GameBase::getTeam(%obj) != GameBase::getTeam(%this))
		{
			//don't bother checking the other team or the box itself; they're not cloaked
		}
		else if(%obj.cloaked != (%this.evenodd + 1)) //if different then new set
		{
			%obj.cloaked = 0;
			if(%obj.cloakPack == 0 && %obj.cloakGun == 0) GameBase::startFadeIn(%obj); //then decloak it
		}
	}

	deleteObject(%this.set); //delete the old set
	%this.set = %Set; //and replace with new set

	schedule("ArbitorBox::checkArbitorBox(" @ %this @ ");", 6.0, %this); //then recheck in 10 seconds
}

//-------------Obelisk of Death------------------------------------

TurretData DeployableAntiMatterTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = AntiMatterShot;
	maxDamage = 4.0;
	maxEnergy = 150;
	minGunEnergy = 0;
	maxGunEnergy = 10;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 1.5;
	speed = 4.0;
	speedModifier = 1.5;
	range = 200;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundEnergyTurretFire;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	explosionId = flashExpMedium;
	description = "Anti Matter Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableAntiMatterTurret::onAdd(%this)
{
	schedule("DeployableAntiMatterTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Chain Turret");
	}
}

function DeployableAntiMatterTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableAntiMatterTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableAntiMatterTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AntiMatterTurretPack"]--;
	$RSP::AntiMatterTurretID[$RSP::AntiMatterPoleID[%this]] = 0;
}
// Override base class just in case.
function DeployableAntiMatterTurret::onPower(%this,%power,%generator) {}

function DeployableAntiMatterTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}

//--------------------------------------------------------------

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



//-------------------------------------------------------



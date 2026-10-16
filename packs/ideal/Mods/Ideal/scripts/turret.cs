//begin mod

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

TurretData SuperSensor
{
	className = "DeployableSensor";
	shapeFile = "sat_big";
	projectileType = Decloak;
	maxDamage = 5;
	maxEnergy = 40;
	minGunEnergy = 40;
	maxGunEnergy = 40;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 35;
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = false;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_Radar";
	debrisId = flashDebrisLarge;
	shieldShapeName = "shield";
	//fireSound = SoundLaserHit;
	//activationSound = SoundRemoteTurretOn;
	//deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpLarge;
	description = "Super Sensor";
	damageSkinData = "objectDamageSkins";
};

function SuperSensor::onAdd(%this)
{
	schedule("SuperSensor::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.012;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Super Sensor");
	}
}

function SuperSensor::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function SuperSensor::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function SuperSensor::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "SuperSensorPack"]--;
}

// Override base class just in case.
function SuperSensor::onPower(%this,%power,%generator) {}
function SuperSensor::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}






TurretData RealObeliskOfLight
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = ObeliskBeam;
	maxDamage = 5;
	maxEnergy = 80;
	minGunEnergy = 80;
	maxGunEnergy = 80;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 100;
	visibleToSensor = false;
	shadowDetailMask = 4;
	supressable = true;
	dopplerVelocity = 0;
	castLOS = false;
	supression = false;
	mapFilter = 2;
//	mapIcon = "M_turret";
	debrisId = flashDebrisLarge;
	shieldShapeName = "shield";
	fireSound = SoundLaserHit;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpLarge;
	description = "";
	damageSkinData = "objectDamageSkins";
};

function RealObeliskOfLight::onAdd(%this)
{
	schedule("RealObeliskOfLight::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.012;
	playSound(SoundBuzz,GameBase::getPosition(%this));
}

function RealObeliskOfLight::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function RealObeliskOfLight::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function RealObeliskOfLight::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
}

// Override base class just in case.
function RealObeliskOfLight::onPower(%this,%power,%generator) {}
function RealObeliskOfLight::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}


TurretData NuclearDeployableTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = NukeTurret;
	maxDamage = 5;
	maxEnergy = 40;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 10;
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = false;
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
	description = "Nuclear Turret";
	damageSkinData = "objectDamageSkins";
};

function NuclearDeployableTurret::onAdd(%this)
{
	schedule("NuclearDeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.012;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Nuclear Turret");
	}
}

function NuclearDeployableTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function NuclearDeployableTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function NuclearDeployableTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "NuclearTurretPack"]--;
}

// Override base class just in case.
function NuclearDeployableTurret::onPower(%this,%power,%generator) {}
function NuclearDeployableTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	



// end mod


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
	maxEnergy = 100;
	minGunEnergy = 10;
	maxGunEnergy = 10;
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

function Turret::wearOffEMP(%this)
{
	%this.hitByEMP--;
	if(%this.hitByEMP <= 0)
	{
		GameBase::setRechargeRate(%this, %this.recharge);
		%this.hitByEMP = 0; //just in case... =)
	}
}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type == $EMPDamageType)
	{
		GameBase::setEnergy(%this, 0);
		%temp = GameBase::getRechargeRate(%this);
		if(%temp > 0) //else hitting with 2 EMP in a row would kill energy forever
			%this.recharge = %temp;
		GameBase::setRechargeRate(%this, 0);
		%this.hitByEMP++;
		schedule("Turret::wearOffEMP(" @ %this @ ");", 3.0);
	}
	else if(%type == $DecloakDamageType)
	{
		if(%this.cloaked)
		{
			%this.cloaked = 0;
			GameBase::startFadeIn(%this);
		}
	}

	if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
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

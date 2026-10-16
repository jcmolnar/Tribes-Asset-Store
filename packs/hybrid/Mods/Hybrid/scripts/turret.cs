//=================================================================================================================
//================================================================================= Geno Plasma Turret ============
//=================================================================================================================

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
	range = 75; 
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
	projectileType = NewPlasmaBoltX; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	explosionId = LargeShockwave; 
	description = "Fuzion Turret"; 
	}; 
 
//=================================================================================================================
//===================================================================================== Geno Elf Turret ===========
//=================================================================================================================

TurretData ELFTurret 
	{ 
	maxDamage = 1.0; 
	maxEnergy = 350; 
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
	projectileType = TerretBeam; 
	reloadDelay = 0.3; 
	explosionId = LargeShockwave; 
	description = "ELF Turret"; 
	fireSound = SoundGeneratorPower; 
	activationSound = SoundChainTurretOn; 
	deactivateSound = SoundChainTurretOff; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	isSustained = true; 
	firingTimeMS = 750; 
	energyRate = 30.0; 
	};

//=================================================================================================================
//=================================================================================== Geno Missile Turret =========
//=================================================================================================================

TurretData RocketTurret 
	{ 
	maxDamage = 1.1; 
	maxEnergy = 100; 
	minGunEnergy = 60; 
	maxGunEnergy = 60; 
	range = 270; 
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
	speed = 3.0; 
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

//=================================================================================================================
//================================================================================== Geno Mortar Turret ===========
//=================================================================================================================

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
	description = "Bio Turret"; 
	};
																						 
//=================================================================================================================
//================================================================================== Geno Indoor Turret ===========
//=================================================================================================================

TurretData IndoorTurret 
	{ 
	className = "Turret"; 
	shapeFile = "indoorgun"; 
	projectileType = MiniFusionBolt; 
	maxDamage = 1.0; 
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
	description = "Mini-Fuzion Turret"; 
	};

//=================================================================================================================
//============================================================================= Dep. Fuzion Turret ================
//=================================================================================================================


TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = false;
   validateMaterials = true;
	projectileType = MiniFusionBolt;
	maxDamage = 2;
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
	description = "Fusion Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Fusion Turret");
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

//=================================================================================================================
//============================================================================= Dep. Spy Camera ===================
//=================================================================================================================


TurretData CameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 90000;
	maxEnergy = 0.0001;
	speed = 20;
	speedModifier = 1.0;
	range = 100;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = ElectricDebris;
	FOV = 0.707;
	pinger = false;
	explosionId = debrisExpMedium;
	description = "Spy Camera";
};

function CameraTurret::onAdd(%this)
{
	schedule("CameraTurret::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Spy Camera");
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


//=================================================================================================================
//============================================================================ Turret Functions ===================
//=================================================================================================================


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
//			Player::mountObject (%object, %this);
//		}
//}

//=================================================================================================================
//============================================================================ End Turret Functions ===============
//=================================================================================================================
//#################################################################################################################
//=================================================================================================================
//============================================================================= Dep. Laser Turret =================
//=================================================================================================================

TurretData LaserTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = false;
   validateMaterials = true;
	projectileType = LaserTrtLaser;
	maxDamage = 2;
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

//=================================================================================================================
//============================================================================= Dep. Plasma Turret ================
//=================================================================================================================


TurretData LaserTurretB
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = false;
   validateMaterials = true;
	projectileType = PlasmaBoltTurrt;
	maxDamage = 2;
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
	description = "Plasma Turret";
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

//=================================================================================================================
//============================================================================= Dep. Chain Turret =================
//=================================================================================================================


TurretData MaliceTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = false;
   validateMaterials = true;
	projectileType = MinigunBullet;
	maxDamage = 2;
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
	description = "Chain Turret";
	damageSkinData = "objectDamageSkins";
};

function MaliceTurret::onAdd(%this)
{
	schedule("MaliceTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Chain Turret");
	}
}

function MaliceTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function MaliceTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function MaliceTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MaliceTurretPack"]--;
}

// Override base class just in case.
function MaliceTurret::onPower(%this,%power,%generator) {}
function MaliceTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//=================================================================================================================
//============================================================================= Dep. Electric Web =================
//=================================================================================================================

TurretData PlasmaDoorTurr
{
	className = "Turret";
	shapeFile = "plasmawall";
	disableCollision = true;
	maxDamage = 2;
	maxEnergy = 500;
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
				GameBase::applyDamage(%obj,$EWebDamageType, 0.01,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this);
				GameBase::applyDamage(%obj,$EWebDamageType, 0.1,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this);
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

//=================================================================================================================
//============================================================================== Dep. ARPG Turret =================
//=================================================================================================================


TurretData ARPGTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = false;
   validateMaterials = true;
	projectileType = ARPGShell;
	maxDamage = 2;
	maxEnergy = 500;
	minGunEnergy = -15;
	maxGunEnergy = -20;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.2;
	speed = 2;
	speedModifier = 2;
	range = 50;
	visibleToSensor = true;
	shadowDetailMask = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = ElectricDebris;
	shieldShapeName = "shield";
	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "ARPG Turret";
	damageSkinData = "objectDamageSkins";
};

function ARPGTurret::onAdd(%this)
{
	schedule("ARPGTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "ARPG Turret");
	}
}

function ARPGTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ARPGTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function ARPGTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ARPGTurretPack"]--;
}

// Override base class just in case.
function LaserTurretB::onPower(%this,%power,%generator) {}
function LaserTurretB::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//=================================================================================================================
//============================================================================= Dep. Flak Turret ==================
//=================================================================================================================


TurretData MiniFlakTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
  // validateShape = false;
  // validateMaterials = true;
	projectileType = MiniFlakproj;
	maxDamage = 2;
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
	description = "Flak Turret";
	damageSkinData = "objectDamageSkins";
};



function MiniFlakTurret::onAdd(%this)
{
	schedule("MiniFlakTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Flak Turret");
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

//=================================================================================================================
//============================================================================= Dep. Missile Turret ===============
//=================================================================================================================

TurretData MiniSAMTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = false;
   validateMaterials = true;
	projectileType = MiniSAMproj;
	maxDamage = 2;
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
	description = "Missile Turret";
	damageSkinData = "objectDamageSkins";
};

function MiniSAMTurret::onAdd(%this)
{
	schedule("MiniSAMTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Missile Turret");
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

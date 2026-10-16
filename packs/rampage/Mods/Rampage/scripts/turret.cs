//=================================================================================================================
//===================================================================================== Base Elf Turret ===========
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
	className = "ELF Turret"; 
	shapeFile = "chainturret"; 
	shieldShapeName = "shield"; 
	speed = 5.0; 
	speedModifier = 1.5; 
	projectileType = turretCharge; 
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
//================================================================================== Base Indoor Turret ===========
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
	description = "Indoor Turret"; 
	}; 

//=================================================================================================================
//=================================================================================== Base Missile Turret =========
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
//================================================================================== Base Mortar Turret ===========
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
	description = "Mortar Turret"; 
	}; 

//=================================================================================================================
//================================================================================= Base Plasma Turret ============
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
	projectileType = plasmaBolt; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	explosionId = LargeShockwave; 
	description = "Plasma Turret"; 
	}; 

//=================================================================================================================
//===================================================================================== Base Target Turret ========
//=================================================================================================================

TurretData TargetTurret 
	{ 
	maxDamage = 1.5; 
	maxEnergy = 300; 
	minGunEnergy = 5; 
	maxGunEnergy = 5; 
	range = 100; 
	visibleToSensor = true; 
	dopplerVelocity = 0; 
	castLOS = true; 
	supression = false; 
	mapFilter = 2; 
	mapIcon = "M_turret"; 
	debrisId = defaultDebrisMedium; 
	className = "Targeting Turret"; 
	shapeFile = "camera"; 
	shieldShapeName = "shield"; 
	speed = 5.0; 
	speedModifier = 1.5; 
	projectileType = targetLaser; 
	reloadDelay = 0.3; 
	explosionId = flashExpMedium; 
	description = "Deployable Targeting Turret"; 
	fireSound = SoundFireTargetingLaser; 
	activationSound = SoundChainTurretOn; 
	deactivateSound = SoundChainTurretOff; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	isSustained = true; 
	firingTimeMS = 750; 
	energyRate = 30.0; 
	}; 

function TargetTurret::onAdd(%this) 
	{ 
	schedule("TargetTurret::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,15); 
	%this.shieldStrength = 0; 
	if (GameBase::getMapName(%this) == "")  
	GameBase::setMapName (%this, "Remote Targeting Turret");  
	} 

function TargetTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function TargetTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function TargetTurret::onDestroyed(%this) 
	{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "TargetPack"]--; 
	} 

function TargetTurret::onPower(%this,%power,%generator) {} 

function TargetTurret::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
	} 

//=================================================================================================================
//===================================================================================== Anti-Air Turret ===========
//=================================================================================================================

TurretData AntiAirTurret 
	{ 
	className = "Turret"; 
	shapeFile = "missileturret"; 
	projectileType = AntiAirMissile; 
	maxDamage = 1.0; 
	maxEnergy = 500; 
	minGunEnergy = 1; 
	maxGunEnergy = 2; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 3; 
	speed = 12.0; 
	speedModifier = 1.5; 
	range = 340; 
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
	targetableFovRatio = 0.5; 
	explosionId = LargeShockwave; 
	description = "Anti Air Turret"; 
	damageSkinData = "objectDamageSkins"; 
	}; 
//=================================================================================================================
//===================================================================================== Elf Turret ================
//=================================================================================================================

TurretData DeployableElf 
	{ 
	maxDamage = 1.0; 
	maxEnergy = 350; 
	minGunEnergy = 50; 
	maxGunEnergy = 5; 
	range = 110; 
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
	reloadDelay = 0.0; 
	explosionId = LargeShockwave; 
	description = "ELF Turret"; 
	fireSound = SoundGeneratorPower; 
	activationSound = SoundChainTurretOn; 
	deactivateSound = SoundChainTurretOff; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	isSustained = true; 
	firingTimeMS = 750; 
	energyRate = 40.0; 
	};  
//=================================================================================================================
//===================================================================================== Indoor Turret =============
//=================================================================================================================

TurretData DeployableIndoor 
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
	description = "Indoor Turret"; 
	}; 
//=================================================================================================================
//===================================================================================== Ion Turret ================
//=================================================================================================================

TurretData DeployableTurret 
	{ 
	className = "Turret"; 
	shapeFile = "remoteturret"; 
	projectileType = IonBolt; 
	maxDamage = 1.0; 
	maxEnergy = 60; 
	minGunEnergy = 6; 
	maxGunEnergy = 5; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 0.3; 
	speed = 4.0; 
	speedModifier = 1.5; 
	range = 55; 
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
	description = "Remote Ion Turret"; 
	damageSkinData = "objectDamageSkins"; 
	}; 
//=================================================================================================================
//===================================================================================== Laser Turret ==============
//=================================================================================================================

TurretData DeployableLaser
	{
	className = "Turret";
	shapeFile = "camera";
	projectileType = railLaser2;
	maxDamage = 0.75;
	maxEnergy = 35;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 3.0;
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
//=================================================================================================================
//======================================================================================= Missile Turret ==========
//=================================================================================================================

TurretData DeployableRocket 
	{ 
	className = "Turret"; 
	shapeFile = "missileturret"; 
	projectileType = TurretMissile; 
	maxDamage = 1.1; 
	maxEnergy = 90; 
	minGunEnergy = 50; 
	maxGunEnergy = 50; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 2.0; 
	speed = 6.0; 
	speedModifier = 4.5; 
	range = 175; 
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
//=================================================================================================================
//===================================================================================== Mortar Turret =============
//=================================================================================================================

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
	description = "Remote Mortar Turret"; 
	damageSkinData = "objectDamageSkins"; 
	}; 
//=================================================================================================================
//===================================================================================== Plasma Turret =============
//=================================================================================================================

TurretData DeployablePlasma 
	{ 
	className = "Turret"; 
	shapeFile = "hellfiregun"; 
	projectileType = plasmaBolt; 
	maxDamage = 1.0; 
	maxEnergy = 200; 
	minGunEnergy = 75; 
	maxGunEnergy = 6; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 0.8; 
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
	debrisId = flashDebrisMedium; 
	shieldShapeName = "shield"; 
	fireSound = SoundPlasmaTurretFire; 
	activationSound = SoundPlasmaTurretOn; 
	deactivateSound = SoundPlasmaTurretOff; 
	whirSound = SoundPlasmaTurretTurn; 
	explosionId = flashExpMedium; 
	description = "Remote Plasma Turret"; 
	damageSkinData = "objectDamageSkins"; 
	}; 
//=================================================================================================================
//==================================================================================== Rail Turret ================
//=================================================================================================================

TurretData DeployableRail 
	{ 
	className = "Turret"; 
	shapeFile = "hellfiregun"; 
	projectileType = railLaser; 
	maxDamage = 1.0; 
	maxEnergy = 155; 
	minGunEnergy = 100; 
	maxGunEnergy = 150; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 8.0; 
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
//=================================================================================================================
//===================================================================================== Satchel Turret ============
//=================================================================================================================

TurretData DeployableSatchel 
	{ 
	className = "Turret"; 
	shapeFile = "camera"; 
	projectileType = SatchelShell; 
	maxDamage = 0.4; 
	maxEnergy = 60; 
	minGunEnergy = 10; 
	maxGunEnergy = 60; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 10.0; 
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
	debrisId = flashDebrisMedium; 
	shieldShapeName = "shield"; 
	fireSound = SoundFireLaser; 
	activationSound = SoundRemoteTurretOn; 
	deactivateSound = SoundRemoteTurretOff; 
	explosionId = rocketExp; 
	description = "Satchel Charge"; 
	damageSkinData = "objectDamageSkins"; 
	}; 

function DeployableSatchel::onAdd(%this) 
	{ 
	schedule("DeployableSatchel::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,0); 
	%this.shieldStrength = 0; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Satchel Charge"); 
	} 

function DeployableSatchel::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableSatchel::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableSatchel::onDestroyed(%this) 
	{ 
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this);  
	calcRadiusDamage(%this, $DebrisDamageType, 20.0, 1.5, 25, 9, 3, 0.20,0.1, 200, 100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "SatchelPack"]--; 
	} 

function DeployableSatchel::onPower(%this,%power,%generator) {} 

function DeployableSatchel::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,0); 
	GameBase::setActive(%this,true); 
	} 

//=================================================================================================================
//======================================================================================== Shock Turret ===========
//=================================================================================================================

TurretData DeployableShock 
	{ 
	maxDamage = 1.5; 
	maxEnergy = 110; 
	minGunEnergy = 15; 
	maxGunEnergy = 20; 
	reloadDelay = 2.0; 
	fireSound = SoundMortarTurretFire; 
	activationSound = SoundMortarTurretOn; 
	deactivateSound = SoundMortarTurretOff; 
	whirSound = SoundMortarTurretTurn; 
	range = 30; 
	dopplerVelocity = 0; 
	castLOS = true; 
	supression = false; 
	mapFilter = 2; 
	mapIcon = "M_turret"; 
	visibleToSensor = true; 
	debrisId = defaultDebrisMedium; 
	className = "Turret"; 
	shapeFile = "indoorgun"; 
	shieldShapeName = "shield_medium"; 
	speed = 5.0; 
	speedModifier = 1.50; 
	projectileType = ShockShell; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	explosionId = LargeShockwave; 
	description = "Shock Turret"; 
	}; 
//=================================================================================================================
//=================================================================================== Vulcan Turret ===============
//=================================================================================================================

TurretData DeployableVulcan 
	{ 
	className = "Turret"; 
	shapeFile = "hellfiregun"; 
	projectileType = TurretBullet; 
	accuFire = false; 
	maxDamage = 4.0; 
	maxEnergy = 300; 
	minGunEnergy = 3; 
	maxGunEnergy = 3.975; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 0.00001; 
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
	debrisId = flashDebrisMedium; 
	shieldShapeName = "shield"; 
	fireSound = SoundFireMortar; 
	activationSound = SoundPlasmaTurretOn; 
	deactivateSound = SoundPlasmaTurretOff; 
	whirSound = SoundPlasmaTurretTurn; 
	explosionId = flashExpMedium; 
	description = "Vulcan Turret"; 
	damageSkinData = "objectDamageSkins"; 
	}; 
//=================================================================================================================
//===================================================================================== Basic Functions ===========
//=================================================================================================================

function Turret::onActivate(%this) { GameBase::playSequence(%this,0,power); }
 
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

function Turret::onAdd(%this) 
	{ 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Turret"); 
	} 

function Turret::checkOperator(%this) 
	{ 
	%cl = GameBase::getControlClient(%this); 
	if(%cl != -1) 
	{ 
	%pl = Client::getOwnedObject(%cl); 
	Player::setMountObject(%pl, -1,0); 
	Client::setControlObject(%cl, %pl); 
	} 
	Client::setGuiMode(%cl,2); 
	} 

function Turret::onPower(%this,%power,%generator) 
	{ 
	if (%power) 
	{ 
	%this.shieldStrength = 0.03; 
	GameBase::setRechargeRate(%this,10); 
	} 
	else 
	{ 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::checkOperator(%this); 
	} 
	GameBase::setActive(%this,%power); 
	} 

function Turret::onEnabled(%this) 
	{ 
	if (GameBase::isPowered(%this)) 
	{ 
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
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this); 
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 0.1, 200, 100); 
	} 

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
	{ 
	if(%this.objectiveLine) 
	%this.lastDamageTeam = GameBase::getTeam(%object); 
	%TDS= 1; 
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) 
	{ 
	%name = GameBase::getDataName(%this); 
	if(%name != DeployableTurret && %name != CameraTurret && %name != DeployableSatchel && %name != DeployableMortar && %name != DeployableHolo && %name != DeployableHolo2 && %name != DeployableHolo3 && %name != DeployablePlasma && %name != DeployableLaser && %name != DeployableRocket && %name != DeployableVulcan && %name != DeployableRail && %name != DeployableShock && %name != DeployableIndoor && %name != AntiAirTurret && %name != DeployableElf && %name != ArbitorBox) 
	%TDS = $Server::TeamDamageScale; 
	} 
	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object); 
	} 

function Turret::onControl (%this, %object) 
	{ 
	%client = Player::getClient(%object); 
	Client::sendMessage(%client,0,"Controlling turret " @ %this); 
	$turretTime[%this] = 1; 
	} 

function Turret::onDismount (%this, %object) 
	{ 
	%client = Player::getClient(%object); 
	Client::sendMessage(%client,0,"Leaving turret " @ %this); 
	$turretTime[%this] = 0; 
	LaptopDrain(%client, %object); 
	} 

function Turret::onCollision (%this, %object) 
	{ 
	if(getObjectType (%object) == "Player") 
	{ 
	%armor = Player::getArmor(%object); 
	if ((Player::getMountedItem(%object,$BackpackSlot) == Laptop)) 
	{ 
	%name = GameBase::getDataName(%this); 
	if(%name == DeployableMortar || %name == DeployablePlasma || %name == DeployableRocket || %name == DeployableVulcan || %name == DeployableRail || %name == MortarTurret) 
	{ 
	%client = Player::getClient(%object); 
	if($lapTime[%client] == 0) 
	{ 
	if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object)) 
	{ 
	Client::getOwnedObject(%client).CommandTag = 1; 
	Client::sendMessage(%client,0,"Re-programming turret"); 
	GameBase::setTeam (%this,GameBase::getTeam (%client)); 
	Client::takeControl(%client, %this); 
	if(%name == DeployablePlasma || %name == DeployableVulcan || %name == DeployableRail ) 
	GameBase::SetPosition(%object,GameBase::GetPosition(%this)); 
	return; 
	} 
	} 
	else 
	Client::sendMessage(%client,0,"Turret is recharging."); 
	} 
	} 
	} 
	if(getObjectType (%object) == "Player") 
	{ 
	%armor = Player::getArmor(%object); 
	if (%armor != "darmor") 
	{ 
	if(GameBase::getTeam(%object) == GameBase::getTeam(%this)) 
	{ 
	%client = Player::getClient(%object); 
	if($lapTime[%client] == 0) 
	{ 
	%name = GameBase::getDataName(%this); 
	if(%name == DeployableVulcan || %name == DeployableRail) 
	{ 
	if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object)) 
	{ 
	Client::getOwnedObject(%client).CommandTag = 1; 
	Client::sendMessage(%client,0,"Manually controlling turret"); 
	Client::takeControl(%client, %this); 
	GameBase::SetPosition(%object,GameBase::GetPosition(%this)); 
	return; 
	} 
	} 
	} 
	else 
	Client::sendMessage(%client,0,"Turret is recharging."); 
	} 
	else 
	Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can not manually command turrets in this class."); 
	} 
	} 

function LaptopDrain(%clientId, %player) 
	{ 
	Player::unmountItem(%player,$WeaponSlot); 
	if($lapTime[%clientId] == 0) 
	{ 
	Client::getOwnedObject(%clientId).CommandTag = ""; 
	$lapTime[%clientId] = 14; 
	checkPlayerLaptop(%clientId, %player); 
	} 
	else 
	$lapTime[%clientId] = 14; 
	} 

function checkPlayerLaptop(%clientId, %player) 
	{ 
	if($lapTime[%clientId] > 0) 
	{ 
	$lapTime[%clientId] -= 2; 
	schedule("checkPlayerLaptop(" @ %clientId @ ", " @ %player @ ");",2,%player); 
	} 
	}

function CountObjects(%set,%name,%num) 
	{ 
	%count = 0; 
	for(%i=0;%i<%num;%i++) 
	{ 
	%obj=Group::getObject(%set,%i); 
	if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++; 
	} 
	return %count; 
	} 


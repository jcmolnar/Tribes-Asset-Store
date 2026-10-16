
TurretData PlasmaTurret { maxDamage = 2.2; maxEnergy = 265; minGunEnergy = 75; maxGunEnergy = 6; reloadDelay = 1.0; fireSound = SoundPlasmaTurretFire; activationSound = SoundPlasmaTurretOn; deactivateSound = SoundPlasmaTurretOff; whirSound = SoundPlasmaTurretTurn; range = 75; gunrange = 125; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; visibleToSensor = true; debrisId = defaultDebrisMedium; className = "Turret"; shapeFile = "hellfiregun"; shieldShapeName = "shield_medium"; speed = 2.75; speedModifier = 2.0; projectileType = FusionBolt; damageSkinData = "objectDamageSkins"; shadowDetailMask = 8; explosionId = LargeShockwave; description = "Plasma Turret"; }; 

TurretData ELFTurret { maxDamage = 2.0; maxEnergy = 150; minGunEnergy = 50; maxGunEnergy = 5; range = 40; visibleToSensor = true; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = defaultDebrisMedium; className = "Turret"; shapeFile = "chainturret"; shieldShapeName = "shield"; speed = 5.0; speedModifier = 1.5; projectileType = turretCharge; reloadDelay = 0.27; explosionId = LargeShockwave; description = "ELF Turret"; fireSound = SoundGeneratorPower; activationSound = SoundChainTurretOn; deactivateSound = SoundChainTurretOff; damageSkinData = "objectDamageSkins"; shadowDetailMask = 8; isSustained = true; firingTimeMS = 850; energyRate = 30.0; }; 

TurretData LELFTurret { maxDamage = 0.8; maxEnergy = 150; minGunEnergy = 50; maxGunEnergy = 5; range = 40; visibleToSensor = true; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = defaultDebrisMedium; className = "Turret"; shapeFile = "chainturret"; shieldShapeName = "shield"; speed = 5.0; speedModifier = 1.5; projectileType = turretECharge; reloadDelay = 0.3; explosionId = LargeShockwave; description = "Large ELF Turret"; fireSound = SoundGeneratorPower; activationSound = SoundChainTurretOn; deactivateSound = SoundChainTurretOff; damageSkinData = "objectDamageSkins"; shadowDetailMask = 8; isSustained = true; firingTimeMS = 750; energyRate = 30.0; }; 

function LELFTurret::onAdd(%this)
{

	schedule("LELFTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	
	%this.shieldStrength = 0.0315;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Large ELF Turret");
	}
}

function LELFTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function LELFTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function LELFTurret::onDestroyed(%this)
{
	%this.shieldStrength = 0;
	GameBase::stopSequence(%this,0);
	GameBase::setRechargeRate(%this,0);
	GameBase::setEnergy(%this, 0);
	GameBase::setActive(%this,false);
	StaticShape::objectiveDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LELFPack"]--;
}

function LELFTurret::onPower(%this,%power,%generator) {}
function LELFTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

TurretData DeployableWatchdog
{
	className = "SensorTurret";
	shapeFile = "camera"; 
	projectileType = WatchdogLaser;
	maxDamage = 0.68;
	maxEnergy = 300;
	minGunEnergy = 75;
	maxGunEnergy = 1.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.9;
	speed = 5.0;
	speedModifier = 2.0;
	range = 150;
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
	fireSound = SoundFireBlaster;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Watchdogg";
	damageSkinData = "objectDamageSkins";
};

$vm[PhoenixM] = CoolProj;

function DeployableWatchdog::onAdd(%this)
{
	schedule("DeployableWatchdog::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.0085;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Watchdogg");
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


function DeployableWatchdog::onPower(%this,%power,%generator) {}
function DeployableWatchdog::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


TurretData DeployableElf
{
	maxDamage = 1.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 20;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "camera";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = lightningECharge;
	reloadDelay = 0.3;
	explosionId = flashExpMedium;
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

function DeployableElf::onAdd(%this)
{
	schedule("DeployableElf::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "ELF Turret");
	}
}

function DeployableElf::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableElf::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableElf::onDestroyed(%this)
{
	%this.shieldStrength = 0;
	GameBase::stopSequence(%this,0);
	GameBase::setRechargeRate(%this,0);
	GameBase::setEnergy(%this, 0);
	GameBase::setActive(%this,false);
	StaticShape::objectiveDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ElfPack"]--;
}


function DeployableElf::onPower(%this,%power,%generator) {}
function DeployableElf::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


TurretData SmallElf
{
	maxDamage = 1.3;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 22;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "camera";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = turretCharge;
	reloadDelay = 0.4;
	explosionId = flashExpMedium;
	description = "Small ELF Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;

};

function SmallElf::onAdd(%this)
{
	schedule("SmallElf::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "ELF Turret");
	}
}

function SmallElf::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function SmallElf::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function SmallElf::onDestroyed(%this)
{
	%this.shieldStrength = 0;
	GameBase::stopSequence(%this,0);
	GameBase::setRechargeRate(%this,0);
	GameBase::setEnergy(%this, 0);
	GameBase::setActive(%this,false);
	StaticShape::objectiveDestroyed(%this);
}


function SmallElf::onPower(%this,%power,%generator) {}
function SmallElf::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	



TurretData DeployableAoe
{
	maxDamage = 100.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 13;
	visibleToSensor = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	className = "SensorTurret";
	shapeFile = "breath";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	reloadDelay = 0.3;
	description = "";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;

};

function DeployableAoe::onAdd(%this)
{
	schedule("DeployableAoe::deploy(" @ %this @ ");",1,%this);
	GameBase::startFadeout(%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
}

function DeployableAoe::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
	GameBase::setActive(%this,true);
}

function DeployableAoe::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableAoe::onDestroyed(%this)
{
	GameBase::setActive(%this,false);
	Turret::onDestroyed(%this);
	deleteobject(%this);
}


function DeployableAoe::onPower(%this,%power,%generator) {}
function DeployableAoe::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	




TurretData DeployableMiniPlasma
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = FlameTurretProj;
	maxDamage = 0.45;
	maxEnergy = 60;
	minGunEnergy = 20;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.1;
	speed = 4.0;
	speedModifier = 1.0;
	range = 10; 
	gunrange = 37;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFirePlasma;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Flame Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableMiniPlasma::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Flame Turret");
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
	GameBase::applyRadiusDamage($BurnDamageType, getBoxCenter(%this), 25, 0.2, 100, %this);
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "PlasmaPack"]--;
}


function DeployableMiniPlasma::onPower(%this,%power,%generator) {}
function DeployableMiniPlasma::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

TurretData Strike0 { maxDamage = 1.0; maxEnergy = 200; minGunEnergy = 5; maxGunEnergy = 10; range = 330; visibleToSensor = false; dopplerVelocity = 0; castLOS = true; supression = false; supressable = false; className = "Turret"; shapeFile = "camera"; shieldShapeName = "shield"; speed = 5.0; speedModifier = 1.5; projectileType = HavocStrike0; reloadDelay = 0.3; explosionId = scssssbo; description = " "; damageSkinData = "objectDamageSkins"; shadowDetailMask = 8; isSustained = true; firingTimeMS = 2000; energyRate = 30.0; }; 

function Strike0::onAdd(%this)
{

	schedule("Strike0::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,15);
	%this.shieldStrength = 0.0315;
}

function Strike0::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function Strike0::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function Strike0::onDestroyed(%this)
{
	%this.shieldStrength = 0;
	GameBase::stopSequence(%this,0);
	GameBase::setRechargeRate(%this,0);
	GameBase::setEnergy(%this, 0);
	GameBase::setActive(%this,false);
	StaticShape::objectiveDestroyed(%this);
}

function Strike0::onPower(%this,%power,%generator) {}
function Strike0::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,15);
	GameBase::setActive(%this,true);
}	

TurretData Strike1 { maxDamage = 1.0; maxEnergy = 200; minGunEnergy = 5; maxGunEnergy = 10; range = 320; visibleToSensor = false; dopplerVelocity = 0; castLOS = true; supression = false; supressable = false; className = "Turret"; shapeFile = "camera"; shieldShapeName = "shield"; speed = 5.0; speedModifier = 1.5; projectileType = HavocStrike1; reloadDelay = 0.3; explosionId = scssssbo; description = " "; damageSkinData = "objectDamageSkins"; shadowDetailMask = 8; isSustained = true; firingTimeMS = 2000; energyRate = 30.0; }; 

function Strike1::onAdd(%this)
{

	schedule("Strike1::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,15);
	%this.shieldStrength = 0.0315;
}

function Strike1::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function Strike1::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function Strike1::onDestroyed(%this)
{
	%this.shieldStrength = 0;
	GameBase::stopSequence(%this,0);
	GameBase::setRechargeRate(%this,0);
	GameBase::setEnergy(%this, 0);
	GameBase::setActive(%this,false);
	StaticShape::objectiveDestroyed(%this);
}

function Strike1::onPower(%this,%power,%generator) {}
function Strike1::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,15);
	GameBase::setActive(%this,true);
}	

TurretData Strike { maxDamage = 1.0; maxEnergy = 200; minGunEnergy = 5; maxGunEnergy = 10; range = 320; visibleToSensor = false; dopplerVelocity = 0; castLOS = true; supression = false; supressable = false; className = "Turret"; shapeFile = "camera"; shieldShapeName = "shield"; speed = 5.0; speedModifier = 1.5; projectileType = HavocStrike; reloadDelay = 0.3; explosionId = scssssbo; description = " "; fireSound = SoundGeneratorPower; activationSound = SoundChainTurretOn; deactivateSound = SoundChainTurretOff; damageSkinData = "objectDamageSkins"; shadowDetailMask = 8; isSustained = true; firingTimeMS = 2600; energyRate = 30.0; }; 

function Strike::onAdd(%this)
{

	schedule("Strike::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,15);
	%this.shieldStrength = 0.0315;
}

function Strike::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function Strike::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function Strike::onDestroyed(%this)
{
	%this.shieldStrength = 0;
	GameBase::stopSequence(%this,0);
	GameBase::setRechargeRate(%this,0);
	GameBase::setEnergy(%this, 0);
	GameBase::setActive(%this,false);
	StaticShape::objectiveDestroyed(%this);
}

function Strike::onPower(%this,%power,%generator) {}
function Strike::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,15);
	GameBase::setActive(%this,true);
}	


TurretData Strike2 { maxDamage = 1.0; maxEnergy = 200; minGunEnergy = 5; maxGunEnergy = 10; range = 300; visibleToSensor = false; dopplerVelocity = 0; castLOS = true; supression = false; supressable = false; className = "Turret"; shapeFile = "camera"; shieldShapeName = "shield"; speed = 5.0; speedModifier = 1.5; projectileType = HavocStrike2; reloadDelay = 0.3; explosionId = scssssbo; description = " "; fireSound = SoundGeneratorPower; activationSound = SoundChainTurretOn; deactivateSound = SoundChainTurretOff; damageSkinData = "objectDamageSkins"; shadowDetailMask = 8; isSustained = true; firingTimeMS = 3600; energyRate = 30.0; }; 

function Strike2::onAdd(%this)
{

	schedule("Strike2::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,15);
	%this.shieldStrength = 0.0315;
}

function Strike2::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function Strike2::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function Strike2::onDestroyed(%this)
{
	%this.shieldStrength = 0;
	GameBase::stopSequence(%this,0);
	GameBase::setRechargeRate(%this,0);
	GameBase::setEnergy(%this, 0);
	GameBase::setActive(%this,false);
	StaticShape::objectiveDestroyed(%this);
}

function Strike2::onPower(%this,%power,%generator) {}
function Strike2::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,15);
	GameBase::setActive(%this,true);
}	

TurretData RockT { maxDamage = 1; maxEnergy = 120; minGunEnergy = 74; maxGunEnergy = 74; range = 300; visibleToSensor = true; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = defaultDebrisLarge; className = "Turret"; shapeFile = "missileturret"; shieldShapeName = "shield_medium"; speed = 4.0; speedModifier = 2.0; projectileType = TurretMissile; fireSound = SoundMissileTurretFire; activationSound = SoundMissileTurretOn; deactivateSound = SoundMissileTurretOff; damageSkinData = "objectDamageSkins"; shadowDetailMask = 8; targetableFovRatio = 0.5; explosionId = LargeShockwave; description = "Rocket Turret"; }; function RockT::onPower(%this,%power,%generator) { if (%power) { %this.shieldStrength = 0.03; GameBase::setRechargeRate(%this,14); } else { %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::checkOperator(%this); } GameBase::setActive(%this,%power); } 

function RockT::verifyTarget(%this,%target) {
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) {
      %this.lockedTarget = %target;
      return "True";
   } else
      return "False";
} 


TurretData RocketTurret { maxDamage = 0.9; maxEnergy = 130; minGunEnergy = 54; maxGunEnergy = 54; range = 185; gunRange = 230; visibleToSensor = true; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = defaultDebrisLarge; className = "Turret"; shapeFile = "missileturret"; shieldShapeName = "shield_medium"; speed = 2.5; speedModifier = 2.5; projectileType = TurretMissile; reloadDelay = 2.0; fireSound = SoundMissileTurretFire; activationSound = SoundMissileTurretOn; deactivateSound = SoundMissileTurretOff; damageSkinData = "objectDamageSkins"; shadowDetailMask = 8; targetableFovRatio = 0.54; explosionId = LargeShockwave; description = "Rocket Turret"; }; function RocketTurret::onPower(%this,%power,%generator) { if (%power) { %this.shieldStrength = 0.03; GameBase::setRechargeRate(%this,16); } else { %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::checkOperator(%this); } GameBase::setActive(%this,%power); }

function RocketTurret::verifyTarget(%this,%target) { 
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.43) {
      %this.lockedTarget = %target;
      return "True";
   } else
      return "False";
}

TurretData MortarTurret { maxDamage = 1.65; maxEnergy = 50; minGunEnergy = 45; maxGunEnergy = 100; reloadDelay = 2.0; fireSound = SoundMortarTurretFire; activationSound = SoundMortarTurretOn; deactivateSound = SoundMortarTurretOff; whirSound = SoundMortarTurretTurn; range = 0; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; visibleToSensor = true; debrisId = defaultDebrisMedium; className = "Turret"; shapeFile = "mortar_turret"; shieldShapeName = "shield_medium"; speed = 2.0; speedModifier = 2.0; projectileType = MortarTurretShell; damageSkinData = "objectDamageSkins"; shadowDetailMask = 8; explosionId = LargeShockwave; description = "Mortar Turret"; }; 


TurretData DeployableCoolMortar { projectileType = SpawnMCSMissile; reloadDelay = 200.0; className = "Turret"; shapeFile = "missileturret"; maxDamage = 2.8; maxEnergy = 100; minGunEnergy = 1; maxGunEnergy = 1; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; speed = 2.0; speedModifier = 1.5; range = 0; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; activationSound = SoundMortarTurretOn; deactivateSound = SoundMortarTurretOff; whirSound = SoundMortarTurretTurn; explosionId = LargeShockwave; description = "Missile Control Station"; damageSkinData = "objectDamageSkins"; }; 

function DeployableCoolMortar::onAdd(%this) { schedule("DeployableCoolMortar::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,7); %this.shieldStrength = 0.015; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Missile Control Station"); } 
} 

function DeployableCoolMortar::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableCoolMortar::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableCoolMortar::onDestroyed(%this) { Turret::onDestroyed(%this); 
%inv = %this.comstation;
%data = GameBase::getDataName(%inv);
GameBase::setDamageLevel(%inv, %data.maxDamage);
$TeamItemCount[GameBase::getTeam(%this) @ "CoolLauncher"]--; } 

function DeployableCoolMortar::onPower(%this,%power,%generator) {} 
function DeployableCoolMortar::onEnabled(%this) { GameBase::setRechargeRate(%this,7); GameBase::setActive(%this,true); } 


TurretData Dep1oyableCoolMortar { projectileType = SpawnMCSMissile; className = "Turret"; shapeFile = "missileturret"; maxDamage = 4.0; maxEnergy = 100; minGunEnergy = 1; maxGunEnergy = 1; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 200.0; speed = 2.0; speedModifier = 1.5; range = 0; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; activationSound = SoundMortarTurretOn; deactivateSound = SoundMortarTurretOff; whirSound = SoundMortarTurretTurn; explosionId = LargeShockwave; description = "Missile Control Station"; damageSkinData = "objectDamageSkins"; }; 

function Dep1oyableCoolMortar::onAdd(%this) { schedule("Dep1oyableCoolMortar::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,7); %this.shieldStrength = 0.005; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Missile Control Station"); } 
} 

function Dep1oyableCoolMortar::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function Dep1oyableCoolMortar::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function Dep1oyableCoolMortar::onDestroyed(%this) { Turret::onDestroyed(%this); 
%inv = %this.comstation;
%data = GameBase::getDataName(%inv);
GameBase::setDamageLevel(%inv, %data.maxDamage);
 } 

function Dep1oyableCoolMortar::onPower(%this,%power,%generator) {} 
function Dep1oyableCoolMortar::onEnabled(%this) { GameBase::setRechargeRate(%this,7); GameBase::setActive(%this,true); } 


TurretData DeployableMortar { className = "Turret"; shapeFile = "mortar_turret"; projectileType = MortarTurretShell; maxDamage = 2.0; maxEnergy = 45; minGunEnergy = 45; maxGunEnergy = 100; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 2.0; speed = 2.0; speedModifier = 1.5; range = 0; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; fireSound = SoundMortarTurretFire; activationSound = SoundMortarTurretOn; deactivateSound = SoundMortarTurretOff; whirSound = SoundMortarTurretTurn; explosionId = LargeShockwave; description = "Mortar Turret"; damageSkinData = "objectDamageSkins"; }; function DeployableMortar::onAdd(%this) { schedule("DeployableMortar::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,7); %this.shieldStrength = 0.006; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Mortar Turret"); } } function DeployableMortar::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployableMortar::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployableMortar::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "TargetPack"]--; } function DeployableMortar::onPower(%this,%power,%generator) {} function DeployableMortar::onEnabled(%this) { GameBase::setRechargeRate(%this,7); GameBase::setActive(%this,true); } 

TurretData IndoorTurret { className = "Turret"; shapeFile = "indoorgun"; projectileType = MiniFusionBolt; maxDamage = 2.65; maxEnergy = 70; minGunEnergy = 20; maxGunEnergy = 6; reloadDelay = 0.4; speed = 5.0; speedModifier = 1.0; range = 30; visibleToSensor = true; dopplerVelocity = 2; castLOS = true; supression = false; supressable = false; pinger = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = defaultDebrisMedium; shieldShapeName = "shield"; fireSound = SoundEnergyTurretFire; activationSound = SoundEnergyTurretOn; deactivateSound = SoundEnergyTurretOff; damageSkinData = "objectDamageSkins"; shadowDetailMask = 8; explosionId = debrisExpMedium; description = "Indoor Turret"; }; 

TurretData DeployableTurret { className = "Turret"; shapeFile = "remoteturret"; projectileType = IonEBolt; maxDamage = 0.65; maxEnergy = 60; minGunEnergy = 6; maxGunEnergy = 5; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 0.7; speed = 3.0; speedModifier = 1.5; range = 35; gunrange = 65; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; fireSound = SoundEnergyTurretFire; activationSound = SoundRemoteTurretOn; deactivateSound = SoundRemoteTurretOff; explosionId = flashExpMedium; description = "Ion Turret"; damageSkinData = "objectDamageSkins"; }; function DeployableTurret::onAdd(%this) { schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,5); %this.shieldStrength = 0.008; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Ion Turret"); } } 

function DeployableTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployableTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployableTurret::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--; } function DeployableTurret::onPower(%this,%power,%generator) {} function DeployableTurret::onEnabled(%this) { GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); } 

TurretData DeployablePlasma { className = "Turret"; shapeFile = "hellfiregun"; projectileType = FusionBo1t; maxDamage = 1.75; maxEnergy = 245; minGunEnergy = 85; maxGunEnergy = 6; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 1.0; speed = 4.0; speedModifier = 1.6; range = 60; gunRange = 100; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; fireSound = SoundPlasmaTurretFire; activationSound = SoundPlasmaTurretOn; deactivateSound = SoundPlasmaTurretOff; whirSound = SoundPlasmaTurretTurn; explosionId = flashExpMedium; description = "Plasma Turret"; damageSkinData = "objectDamageSkins"; }; function DeployablePlasma::onAdd(%this) { 
	%this.reddd = true;
	schedule(%this @ ".reddd = false;", 1, %this);
schedule("DeployablePlasma::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,6); %this.shieldStrength = 0.02; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Plasma Turret"); } } function DeployablePlasma::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployablePlasma::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployablePlasma::onDestroyed(%this) { 
Turret::onDestroyed(%this);
 %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this); 
$TeamItemCount[GameBase::getTeam(%this) @ "LaserTurret"]--; } function DeployablePlasma::onPower(%this,%power,%generator) {} function DeployablePlasma::onEnabled(%this) { GameBase::setRechargeRate(%this,6); GameBase::setActive(%this,true); } 

TurretData DeployableTTurret { className = "Turret"; shapeFile = "remoteturret"; projectileType = IonEEBolt; maxDamage = 0.5; maxEnergy = 75; minGunEnergy = 6; maxGunEnergy = 5; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 0.9; speed = 2.5; speedModifier = 1.5; range = 45; gunrange = 65; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; activationSound = SoundRemoteTurretOn; deactivateSound = SoundRemoteTurretOff; explosionId = flashExpMedium; description = "Tractor Turret"; damageSkinData = "objectDamageSkins"; }; function DeployableTTurret::onAdd(%this) { schedule("DeployableTTurret::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,5); %this.shieldStrength = 0.001; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Tractor Turret"); } } 

function DeployableTTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployableTTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployableTTurret::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "TTurretPack"]--; } function DeployableTTurret::onPower(%this,%power,%generator) {} function DeployableTTurret::onEnabled(%this) { GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); } 


TurretData DeployableLaser { className = "Turret"; shapeFile = "indoorgun"; projectileType = turretElaser; maxDamage = 0.55; maxEnergy = 150; minGunEnergy = 15; maxGunEnergy = 60; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 9.5; speed = 1.5; speedModifier = 1.0; range = 25; gunrange = 65; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 2; castLOS = true; supression = false; supressable = true; pinger = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; fireSound = SoundFireLaser; activationSound = SoundEnergyTurretOn; deactivateSound = SoundEnergyTurretOff; whirSound = SoundPlasmaTurretTurn; explosionId = debrisExpMedium; description = "Laser Turret"; damageSkinData = "objectDamageSkins"; }; 

function DeployableLaser::onAdd(%this) { schedule("DeployableLaser::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,5); %this.shieldStrength = 0.005; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Laser Turret"); } } 

function DeployableLaser::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableLaser::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployableLaser::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "LaserPack"]--; } 

function DeployableLaser::onPower(%this,%power,%generator) {} function DeployableLaser::onEnabled(%this) { GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); } 


TurretData VulcanT { className = "Turret"; shapeFile = "hellfiregun"; projectileType = TurretBullet; accuFire = false; maxDamage = 1.0; maxEnergy = 200; minGunEnergy = 4; maxGunEnergy = 5; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 0.001; speed = 4.0; speedModifier = 1.5; range = 0; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; fireSound = SoundFireMortar; activationSound = SoundPlasmaTurretOn; deactivateSound = SoundPlasmaTurretOff; whirSound = SoundPlasmaTurretTurn; explosionId = flashExpMedium; description = "Vulcan Turret"; damageSkinData = "objectDamageSkins"; }; 

function VulcanT::onAdd(%this) { 
schedule("VulcanT::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,10); if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Vulcan Turret"); } } function VulcanT::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function VulcanT::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function VulcanT::onDestroyed(%this) { 

Turret::onDestroyed(%this); 
%this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this); 

} function VulcanT::onPower(%this,%power,%generator) {} function VulcanT::onEnabled(%this) { GameBase::setRechargeRate(%this,10); GameBase::setActive(%this,true); } 

TurretData RailT { maxDamage = 3; maxEnergy = 265; minGunEnergy = 75; maxGunEnergy = 6; reloadDelay = 0.86; fireSound = SoundPlasmaTurretFire; activationSound = SoundPlasmaTurretOn; deactivateSound = SoundPlasmaTurretOff; whirSound = SoundPlasmaTurretTurn; range = 75; gunrange = 125; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; visibleToSensor = true; debrisId = defaultDebrisMedium; className = "Turret"; shapeFile = "hellfiregun"; shieldShapeName = "shield_medium"; speed = 2.75; speedModifier = 2.0; projectileType = FusionBolt55; damageSkinData = "objectDamageSkins"; shadowDetailMask = 8; explosionId = LargeShockwave; description = "Plasma Turret"; };

function RailT::onAdd(%this) { schedule("RailT::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,10); %this.shieldStrength = 0.0; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Plasma Turret"); } }

function RailT::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function RailT::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }

function RailT::onDestroyed(%this) { 
Turret::onDestroyed(%this); 
%this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this); 


} 

function RailT::onPower(%this,%power,%generator) {} function RailT::onEnabled(%this) { GameBase::setRechargeRate(%this,20); GameBase::setActive(%this,true); } 

TurretData DeployableAA { className = "Turret"; shapeFile = "indoorgun"; projectileType = LilTurretMissi1e; maxDamage = 1.67; maxEnergy = 90; minGunEnergy = 24; maxGunEnergy = 24; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 0.3; speed = 5.0; speedModifier = 5.0; range = 120; gunRange = 170; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; fireSound = SoundMissileTurretFire; activationSound = SoundRemoteTurretOn; deactivateSound = SoundRemoteTurretOff; explosionId = flashExpMedium; description = "AA Turret"; damageSkinData = "objectDamageSkins"; }; 

function DeployableAA::onAdd(%this) { schedule("DeployableAA::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,5); %this.shieldStrength = 0.005; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "AA Turret"); } } function DeployableAA::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployableAA::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployableAA::onDestroyed(%this) { 
StaticShape::objectiveDestroyed(%this); %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this); 
$TeamItemCount[GameBase::getTeam(%this) @ "AAPack"]--; } function DeployableAA::onPower(%this,%power,%generator) {} function DeployableAA::onEnabled(%this) { GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); } 

function DeployableAA::verifyTarget(%this,%target) { return GameBase::virtual(%target, "getHeat"); } 


TurretData DeployableShock { maxDamage = 1.5; maxEnergy = 120; minGunEnergy = 15; maxGunEnergy = 20; reloadDelay = 2.0; fireSound = SoundMortarTurretFire; activationSound = SoundMortarTurretOn; deactivateSound = SoundMortarTurretOff; whirSound = SoundMortarTurretTurn; range = 40; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; visibleToSensor = true; debrisId = defaultDebrisMedium; className = "Turret"; shapeFile = "indoorgun"; shieldShapeName = "shield"; speed = 5.0; speedModifier = 1.50; projectileType = EMPTurretShell; damageSkinData = "objectDamageSkins"; shadowDetailMask = 8; explosionId = LargeShockwave; description = "EMP Turret"; }; 

function DeployableShock::onAdd(%this) { schedule("DeployableShock::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,6); %this.shieldStrength = 0.010; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "EMP Turret"); } } 

function DeployableShock::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableShock::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function Vehicle::reloadWeapon(%this){	
	if(%this.isFiring)		
		%this.isFiring = false;
	else
		%this.isFiring = true;
}

function Vehicle::fireWeapon(%this, %reload) {
	if(%this.isFiring) return false;
	Vehicle::reloadWeapon(%this);
	schedule("Vehicle::reloadWeapon(" @ %this @ ");", %reload, %this);
	return true;
}

function DeployableShock::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "ShockPack"]--; } 

function DeployableShock::onPower(%this,%power,%generator) {} 

function DeployableShock::onEnabled(%this) { GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); } 

TurretData DeployableSatchel { className = "SensorTurret"; shapeFile = "camera"; maxDamage = 0.4; maxEnergy = 75; minGunEnergy = 10; maxGunEnergy = 60; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 10.0; speed = 4.0; speedModifier = 1.5; range = 0; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; shieldShapeName = "shield"; fireSound = explosion3; activationSound = SoundRemoteTurretOn; deactivateSound = SoundRemoteTurretOff; explosionId = SockExp; description = "Satchel Charge"; damageSkinData = "objectDamageSkins"; }; 

function DeployableSatchel::onAdd(%this) { schedule("DeployableSatchel::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,5); %this.shieldStrength = 0; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Satchel Charge"); } } 

function DeployableSatchel::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableSatchel::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableSatchel::onDestroyed(%this) { %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this); $TeamItemCount[GameBase::getTeam(%this) @ "SatchelPack"]--; } 

function DeployableSatchel::onPower(%this,%power,%generator) {} 

function DeployableSatchel::onEnabled(%this) { GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); } 


TurretData BAlarm { className = "SensorTurret"; shapeFile = "camera"; projectileType = BaseAlarmProj; maxDamage = 0.5; maxEnergy = 50; minGunEnergy = 45; maxGunEnergy = 45; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 10.0; speed = 5.0; speedModifier = 5.0; range = 19; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 2; castLOS = true; supression = false; pinger = false; supressable = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; explosionId = flashExpMedium; description = "Base Alarm"; damageSkinData = "objectDamageSkins"; }; function BAlarm::onAdd(%this) { schedule("BAlarm::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,6); %this.shieldStrength = 0.008; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Base Alarm"); } } function BAlarm::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function BAlarm::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function BAlarm::onDestroyed(%this) { teamMessages(0, GameBase::getTeam(%this), "Base Alarm has been destroyed.~wmine_act.wav", "", "", ""); %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this); $TeamItemCount[GameBase::getTeam(%this) @ "BA"]--; } function BAlarm::onPower(%this,%power,%generator) {} function BAlarm::onEnabled(%this) { GameBase::setRechargeRate(%this,6); GameBase::setActive(%this,true); } 


TurretData DeployableRocket { className = "Turret"; shapeFile = "missileturret"; projectileType = TurretMissi1e; maxDamage = 0.9; maxEnergy = 100; minGunEnergy = 37; maxGunEnergy = 37; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 2.65; speed = 4.0; speedModifier = 1.5; range = 110; gunRange = 165; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; fireSound = SoundMissileTurretFire; activationSound = SoundRemoteTurretOn; deactivateSound = SoundRemoteTurretOff; explosionId = flashExpLarge; description = "Rocket Turret"; damageSkinData = "objectDamageSkins"; }; 

function DeployableRocket::verifyTarget(%this, %target) { 
	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) {
      %this.lockedTarget = %target;
      return "True";
   } else
      return "False"; 
} 

function DeployableRocket::onAdd(%this) { schedule("DeployableRocket::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,5); %this.shieldStrength = 0.015; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Rocket Turret"); } } function DeployableRocket::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployableRocket::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployableRocket::onDestroyed(%this) { 
CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,15,15,2.5,1.1,200,100);
StaticShape::objectiveDestroyed(%this); %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this); 

$TeamItemCount[GameBase::getTeam(%this) @ "RocketPack"]--; } function DeployableRocket::onPower(%this,%power,%generator) {} function DeployableRocket::onEnabled(%this) { GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); } 


TurretData CameraTurret
{
	className = "SensorTurret";
	shapeFile = "camera";
	maxDamage = 0.25;
	maxEnergy = 10;
	speed = 20;
	speedModifier = 1.0;
	range = 40;
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

function CameraTurret::onAdd(%this) { schedule("CameraTurret::deploy(" @ %this @ ");",1,%this); if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Camera"); } } function CameraTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function CameraTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function CameraTurret::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "CameraPack"]--; } 

function Turret::onAdd(%this) { if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Turret"); }

 } 

function Turret::onActivate(%this) { GameBase::playSequence(%this,0,power); } 

function Turret::onDeactivate(%this) { GameBase::stopSequence(%this,0); Turret::checkOperator(%this); } 

function Turret::onSetTeam(%this,%oldTeam) { if(GameBase::getTeam(%this) != Client::getTeam(GameBase::getControlClient(%this))) Turret::checkOperator(%this); } 

function Turret::checkOperator(%this) { %cl = GameBase::getControlClient(%this); if(%cl != -1) { %pl = Client::getOwnedObject(%cl); Player::setMountObject(%pl, -1,0); doneposs(%cl); Client::setControlObject(%cl, %pl); %cl.safet = false; %pl.CommandTag = ""; } Client::setGuiMode(%cl,2); } 

function Turret::onPower(%this,%power,%generator) { if (%power) { %this.shieldStrength = 0.03; GameBase::setRechargeRate(%this,10); } else { %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::checkOperator(%this); } GameBase::setActive(%this,%power); } 

function Turret::onEnabled(%this) { if (GameBase::isPowered(%this)) { %this.shieldStrength = 0.03; GameBase::setRechargeRate(%this,10); GameBase::setActive(%this,true); } } 

function Turret::onDisabled(%this) { %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this); } 

function Turret::onDestroyed(%this) { StaticShape::objectiveDestroyed(%this); %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this); 

%data = GameBase::getDataName(%this);
if(%data == "DeployablePlasma" || %data == "PlasmaTurret" || %data == "DeployableRocket" || %data == "RocketTurret" || %data == "RockT")
	GameBase::applyRadiusDamage($DDamageType, getBoxCenter(%this), 25, 2, 260, %this);
else if(%data == "VulcanT")
	GameBase::applyRadiusDamage($DebrisDamageType, getBoxCenter(%this), 10, 1.0, 320, %this);
else if(%data == "RailT")
	GameBase::applyRadiusDamage($DebrisDamageType, getBoxCenter(%this), 10, 2.2, 320, %this);
else if(%data != "DeployableAoe" && %data != "CameraTurret")
	GameBase::applyRadiusDamage($DDamageType, getBoxCenter(%this), 13, 0.65, 115, %this);

} 

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { 
	if(%this.objectiveLine) 
		%this.lastDamageTeam = GameBase::getTeam(%object); 
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) { 
		%name = GameBase::getDataName(%this); 
		if(%name != DeployableTurret && %name != CameraTurret && %name != DeployableSatchel && %name != DeployableMortar && %name != DeployableHolo && %name != DeployableHolo2 && %name != DeployableHolo3 && %name != DeployablePlasma && %name != DeployableLaser && %name != DeployableRocket && %name != DeployableShock && %type != 999) 
			%TDS = $Server::TeamDamageScale; 
	} 
	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object); 
} 

function Turret::onControl (%this, %object) { 
	%client = Player::getClient(%object); 
	Client::sendMessage(%client,0,"Controlling turret " @ %this); 
} 

function Turret::Jump (%this, %object) {
	%client = GameBase::getControlClient(%this);
	%name = GameBase::getDataName(%this);
	if(%name == Dep1oyableCoolMortar || %name == DeployableCoolMortar) {
		if(%this.load != "") {
			if(GameBase::getLOSinfo(%this,3)) { 
				Client::sendMessage(%client,0,"Cannot fire - Object in way~waccess_denied.wav");
				return;
			}
			%trans = GameBase::getMuzzleTransform(%this); 
			$Faky = %this;
			$Faky2 = GameBase::getPosition(%this);
			Projectile::spawnProjectile("SpawnMCSMissile",%trans,%this,"0 0 0");
		} else {
			Client::sendMessage(%client,0,"Turret is not loaded.");
		}
	} else if(%name == DeployableSatchel) {
		schedule("GameBase::playSound("@%this@",debrisLargeExplosion,0);", 0.4);
		GameBase::setDamageLevel(%this, 9);
		GameBase::applyRadiusDamage($MortarDamageType, getBoxCenter(%this), 30, 0.75, 250, %client);
		GameBase::applyRadiusDamage($MortarDamageType, getBoxCenter(%this), 10, 1.25, 100, %client);
		remotePlayMode(%client);
		%camera = newObject("Camera","Turret",DeployableAoe,true);
		addToSet("MissionCleanup", %camera);
		%pos = GameBase::getPosition(%this);
		%pos = getWord(%pos, 0) @ " " @ getWord(%pos, 1) @ " " @ (getWord(%pos, 2) + 1);
		GameBase::setPosition(%camera, %pos);
		Gamebase::setMapName(%camera, "");
        Client::setControlObject(%client, Client::getObserverCamera(%client));
        Observer::setOrbitObject(%client, %camera, 0, 0, 0);
		%client.booyah = true; %client.safeout = true;
		schedule(%client @ ".safeout = \"\";", 0.5);
		schedule("GameBase::setDamageLevel("@%camera@", 9999);", 2, %camera);
		%pl = Client::getOwnedObject(%client);
		schedule("checkEm(" @ %client @ ", " @ %pl @ ", " @ Client::getControlObject(%client) @ ");", 2, %pl);
	} else {
		remoteCommandMode(%client);
		if(!%client.atcom)
			remotePlayMode(%client);
	}
}


function checkReProgTurret(%client, %turret, %oldT, %ds) {
	if(isObject(%turret)) {
		if(%ds == %client.ScoreDeaths) {
			%data = GameBase::getDataName(%turret);
			Client::sendMessage(%client,0,%data.description @ " has been re-programmed!"); 
			%curT = Client::getTeam(%client);
			GameBase::setTeam(%turret,%curT); 							
			%player = Client::getOwnedObject(%client);
			Client::setOwnedObject(%client, %turret); 
			Client::setOwnedObject(%client, %player); 
			if(%data == DeployableMortar) %item = "TargetPack";
			else if(%data == DeployablePlasma) %item = "LaserTurret";
			else if(%data == DeployableRocket) %item = "RocketPack";
			else if(%data == DeployableLaser) %item = "LaserPack";
			else if(%data == DeployableWatchdog) %item = "WatchdogPack";
			else if(%data == DeployableElf) %item = "ElfPack";
			else if(%data == DeployableMiniPlasma) %item = "PlasmaPack";
			else if(%data == DeployableShock) %item = "ShockPack";
			else if(%data == LELFTurret) %item = "LELFPack";
			else if(%data == DeployableTTurret) %item = "TTurretPack";
			else if(%data == DeployableTurret) %item = "TurretPack";
			else if(%data == DeployableAA) %item = "AAPack";
			$TeamItemCount[GameBase::getTeam(%oldT) @ %item]--;
			$TeamItemCount[GameBase::getTeam(%curTeam) @ %item]++;
		} else {
			Client::sendMessage(%client,0,"Re-programming failed - You have died.~wC_BuySell.wav"); 
			GameBase::setTeam(%turret,%oldT); 							
		}
	} else {
		Client::sendMessage(%client,0,"Re-programming failed - Turret has been destroyed.~wC_BuySell.wav"); 
	}
}

function Turret::onDismount (%this, %object) { 
	%client = Player::getClient(%object); 
	Client::sendMessage(%client,0,"Leaving turret " @ %this); 
	LaptopDrain(%client, %object); 
} 

function Turret::onCollision (%this, %object) { 

	if(%this.reddd) return;

	%client = Player::getClient(%object); 

	if(%client.possessing || %client.possessed) return;

	%name = GameBase::getDataName(%this);

	if(getObjectType(%object) == "Player") {

		%lllll = (Player::getMountedItem(%object,$BackpackSlot) == Laptop);	

		if ((Player::getLastContactCount(%object) > 0) || (%this.pushedTurret == 1) || %lllll) { 

		%armor = Player::getArmor(%object); 
		if (%lllll) { 
			if(%name == DeployableMortar || %name == DeployablePlasma || %name == DeployableRocket || %name == DeployableLaser || %name == DeployableWatchdog || %name == DeployableElf || DeployableMiniPlasma || %name == DeployableShock || %name == LELFTurret || %name == DeployableTTurret || %name == DeployableTurret || %name == DeployableAA) {  
				if(GameBase::getTeam(%object) != GameBase::getTeam(%this)) { 
					if(GameBase::getDamageState(%this) == "Enabled") {
						if(%client.lapTime == 0) { 
							if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object)) { 
								Client::sendMessage(%client,0,"Re-programming turret...~wDryfire1.wav"); 
								if(%armor == "spyarmor" || %armor == "spyfemale") {
schedule("checkReProgTurret("@%client@","@%this@","@GameBase::getTeam(%this)@","@%client.ScoreDeaths@");", 16);
								} else {
schedule("checkReProgTurret("@%client@","@%this@","@GameBase::getTeam(%this)@","@%client.ScoreDeaths@");", 8);
								}
								GameBase::setTeam(%this,-1); 			
								Player::unmountItem(%object,$BackpackSlot);
								Player::decItemCount(%object,Laptop);
							}
						} else Client::sendMessage(%client,0,"Internal command systems recharging..."); 
					} else { Client::sendMessage(%client,0,"Turret is disabled."); return; }
				}
			}
		}
	
		%armor = Player::getArmor(%object); 
		if(%name == DeployablePlasma || %name == PlasmaTurret || %name == VulcanT || %name == RailT) {
			
				if(GameBase::getTeam(%object) == GameBase::getTeam(%this)) { 
					if(GameBase::getDamageState(%this) == "Enabled") {
						if (%armor != "darmor" && %armor != "harmor") { 
						if(%client.lapTime == 0) { 
							if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object)) {
								%pl = Client::getOwnedObject(%client);
								%pl.CommandTag = 1;
								if(Client::takeControl(%client, %this)) {
									Player::trigger(%pl, $WeaponSlot, false);
									Client::sendMessage(%client,0,"Manually controlling turret"); 
									Item::setVelocity(%object, "0 0 0");
									GameBase::SetPosition(%object,GameBase::GetPosition(%this)); 
								}
								return; 
							} 					
						} else Client::sendMessage(%client,0,"Internal command systems recharging..."); 
						} else Client::sendMessage(%client,0,"Can not manually command turrets in this class."); 
					} else { Client::sendMessage(%client,0,"Turret is disabled."); } 
				} else Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav"); 
			
		}


	} else {
		%this.pushedTurret = 1;
		schedule(%this @ ".pushedTurret = 0;",1.5,%this);
	}
	}
}

function LaptopDrain(%clientId, %player) {
	if(%clientId.lapTime == 0) {
		%pl = Client::getOwnedObject(%clientId);
		schedule((%pl)@".CommandTag = \"\";", 5);
		%pl.noCom = true;
		schedule((%pl)@".noCom = \"\";", 7);
		%clientId.lapTime = 8;
		checkPlayerLaptop(%clientId, %player); 
	} else 
		%clientId.lapTime = 8;
} 

function checkPlayerLaptop(%clientId, %player) { 
	if(%clientId.lapTime > 0) { 
		%clientId.lapTime -= 4; 
		schedule("checkPlayerLaptop(" @ %clientId @ ", " @ %player @ ");",4,%player); 
	}
}
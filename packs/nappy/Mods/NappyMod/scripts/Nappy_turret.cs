

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              ION TURRET
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================


TurretData IonTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = $Nappy::validate;
   validateMaterials = $Nappy::validate;
	projectileType = IonBolt;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.3;
	speed = 4.0;
	speedModifier = 1.5;
	range = 155;
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
	description = "Ion Turret";
	damageSkinData = "objectDamageSkins";
};

function IonTurret::onAdd(%this)
{
	schedule("IonTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Turret");
	}
}

function IonTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function IonTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function IonTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "IonTurretPack"]--;
}

// Override base class just in case.
function IonTurret::onPower(%this,%power,%generator) {}
function IonTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              ArbitorBox
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

TurretData ArbitorBox
{
   className = "Turret";
   shapeFile = "magcargo";
   //projectileType = none;
   maxDamage = 2 * $Nappy::TurretStrength;
   maxEnergy = 0;
   //minGunEnergy = 6;
   //maxGunEnergy = 5;
   sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
   //reloadDelay = 0.4;
   //speed = 4.0;
   //speedModifier = 1.5;
   //range = 10;
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
   //fireSound = SoundFireMortar;
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
	$ArbitorId = %this;
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
	for(%i=%num-1; %i >= 0; %i--){
		%obj = Group::getObject(%this.set, %i);
		GameBase::startFadeIn(%obj);
		%obj.cloaked = 0;
	}
	deleteObject(%this.set);
}

function ArbitorBox::UnCloak(%this)
{
	%num = Group::objectCount(%this.set);
	for(%i=%num-1; %i >= 0; %i--){
		%obj = Group::getObject(%this.set, %i);
		GameBase::startFadeIn(%obj);
		%obj.cloaked = 0;
	}
	deleteObject(%this.set);
}

function ArbitorBox::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	ArbitorBox::UnCloak(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ArbitorPack"]--;
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
	for(%i; %i < %num; %i++){
		%obj = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this){
			//don't cloak enemies or the box itself
		}
		else{
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
	for(%i; %i < %num; %i++){
		%obj = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this){
			//don't cloak enemies or the box itself
		}
		else{
			GameBase::startFadeOut(%obj);
			%obj.cloaked = 1 + %this.evenodd; //1 half the time & 2 other half... used to check if in this set while searching the old set
		}
	}
	%num = Group::objectCount(%this.set);
	for(%j; %j < %num; %j++){
		%obj = Group::getObject(%this.set, %j);
		if(%obj == %this || GameBase::getTeam(%obj) != GameBase::getTeam(%this)){
			//don't bother checking the other team or the box itself; they're not cloaked
		}
		else 
			if(%obj.cloaked != (%this.evenodd + 1)){ //if different then new set
				%obj.cloaked = 0;
				if(%obj.cloakPack == 0 && %obj.cloakGun == 0) 
					GameBase::startFadeIn(%obj); //then decloak it
			}
	}
	deleteObject(%this.set); //delete the old set
	%this.set = %Set; //and replace with new set
	schedule("ArbitorBox::checkArbitorBox(" @ %this @ ");", 6.0, %this); //then recheck in 10 seconds
}




//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              SATCHEL CHARGE
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================



TurretData DeployableSatchel 
{ 
   className = "Turret"; 
   shapeFile = "camera"; 
   projectileType = SatchelShell; 
   maxDamage = 0.4 * $Nappy::TurretStrength; 
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
	if (GameBase::getMapName(%this) == "") { 
		GameBase::setMapName (%this, "Satchel Charge"); 
	} 
} 

function DeployableSatchel::deploy(%this) 
{ 
	GameBase::playSequence(%this,1,"deploy"); 
} 

function DeployableSatchel::onEndSequence(%this,%thread) 
{ 
	GameBase::setActive(%this,true); 
} 

function DeployableSatchel::onDestroyed(%this) 
{ 
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this);  
	calcRadiusDamage(%this, $DebrisDamageType, 20.0, 1.5, 25, 9, 3, 0.20,0.1, 200, 100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "SatchelPack"]--; 
} 

function DeployableSatchel::onPower(%this,%power,%generator) 
{} 

function DeployableSatchel::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this,10); 
	GameBase::setActive(%this,true); 
} 




//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              DeployableLaser
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

TurretData DeployableLaser
{
   className = "Turret";
   shapeFile = "camera";
   projectileType = SniperLaser;
   maxDamage = 0.75 * $Nappy::TurretStrength;
   maxEnergy = 35;
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
   description = "Deployable Laser Turret";
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
	$TeamItemCount[GameBase::getTeam(%this) @ "LaserTurretPack"]--;
}

// Override base class just in case.
function DeployableLaser::onPower(%this,%power,%generator) {}

function DeployableLaser::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              DeployableIndoor
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

TurretData DeployableIndoor 
{ 
   className = "Turret"; 
   shapeFile = "indoorgun"; 
   projectileType = MiniFusionBolt; 
   maxDamage = 2.5 * $Nappy::TurretStrength; 
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
   description = "Deployable Indoor Turret"; 
}; 
 

function DeployableIndoor::onAdd(%this) 
{ 
	schedule("DeployableIndoor::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,6); 
	%this.shieldStrength = 0.030; 
	if (GameBase::getMapName(%this) == "") { 
		GameBase::setMapName (%this, "Remote Indoor Turret"); 
	} 
} 

function DeployableIndoor::deploy(%this) 
{ 
	GameBase::playSequence(%this,1,"deploy"); 
} 

function DeployableIndoor::onEndSequence(%this,%thread) 
{ 
	GameBase::setActive(%this,true); 
} 

function DeployableIndoor::onDestroyed(%this) 
{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "IndoorTurretPack"]--; 
} 

function DeployableIndoor::onPower(%this,%power,%generator) {} 

function DeployableIndoor::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
} 



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              DeployableShock
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

TurretData DeployableShock 
{ 
   maxDamage = 1.5 * $Nappy::TurretStrength; 
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
   description = "Deployable Shock Turret"; 
}; 

function DeployableShock::onAdd(%this) 
{ 
	schedule("DeployableShock::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,6); 
	%this.shieldStrength = 0.010; 
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
	$TeamItemCount[GameBase::getTeam(%this) @ "ShockTurretPack"]--; 
} 

function DeployableShock::onPower(%this,%power,%generator) {} 

function DeployableShock::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
} 







//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              AntiAirTurret
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

TurretData AntiAirTurret 
{ 
   className = "Turret"; 
   shapeFile = "missileturret"; 
   projectileType = AntiAirMissile;
   maxDamage = 1.0 * $Nappy::TurretStrength; 
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

function AntiAirTurret::verifyTarget(%this,%target) 
{ 
	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) 
		return "True"; 
	else 
		return "False"; 
} 


function AntiAirTurret::onAdd(%this) 
{ 
	schedule("AntiAirTurret::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,7); 
	%this.shieldStrength = 0.005; 
	if (GameBase::getMapName(%this) == "") { 
		GameBase::setMapName (%this, "Mortar Turret"); 
	} 
} 

function AntiAirTurret::deploy(%this) 
{ 
	GameBase::playSequence(%this,1,"deploy"); 
} 

function AntiAirTurret::onEndSequence(%this,%thread) 
{ 
	GameBase::setActive(%this,true); 
} 

function AntiAirTurret::onDestroyed(%this) 
{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "AntiAirTurretPack"]--; 
} 

function AntiAirTurret::onPower(%this,%power,%generator) {} 

function AntiAirTurret::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this,7); 
	GameBase::setActive(%this,true); 
} 




//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              DeployableElf
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

TurretData DeployableElf 
{ 
   maxDamage = 1.0 * $Nappy::TurretStrength; 
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
   description = "Deployable ELF Turret"; 
   fireSound = SoundGeneratorPower; 
   activationSound = SoundChainTurretOn; 
   deactivateSound = SoundChainTurretOff; 
   damageSkinData = "objectDamageSkins"; 
   shadowDetailMask = 8; 
   isSustained = true; 
   firingTimeMS = 750; 
   energyRate = 30.0; 
};  

function DeployableElf::onAdd(%this) 
{ 
	schedule("DeployableElf::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,5); 
	%this.shieldStrength = 0.030; 
	if (GameBase::getMapName(%this) == "") { 
		GameBase::setMapName (%this, "Elf Turret"); 
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
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this); 
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "ElfTurretPack"]--; 
} 

function DeployableElf::onPower(%this,%power,%generator) {} 

function DeployableElf::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this,10); 
	GameBase::setActive(%this,true); 
} 




//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              DeployableMortarTurret
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

TurretData DeployableMortar 
{ 
   className = "Turret"; 
   shapeFile = "mortar_turret"; 
   projectileType = MortarTurretShell; 
   maxDamage = 1.0 * $Nappy::TurretStrength; 
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
   description = "Deployable Mortar Turret"; 
   damageSkinData = "objectDamageSkins"; 
}; 

function DeployableMortar::onAdd(%this) 
{ 
	schedule("DeployableMortar::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,7); 
	%this.shieldStrength = 0.005; 
	if (GameBase::getMapName(%this) == "") { 
		GameBase::setMapName (%this, "Mortar Turret"); 
	} 
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

function DeployableMortar::onPower(%this,%power,%generator) {} 

function DeployableMortar::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this,7); 
	GameBase::setActive(%this,true); 
} 



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              DeployablePlasma
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

TurretData DeployablePlasma 
{ 
   className = "Turret"; 
   shapeFile = "hellfiregun"; 
   projectileType = FusionBolt; 
   maxDamage = 1.5 * $Nappy::TurretStrength; 
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
   description = "Deployable Plasma Turret"; 
   damageSkinData = "objectDamageSkins"; 
}; 

function DeployablePlasma::onAdd(%this) 
{ 
	schedule("DeployablePlasma::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,5); 
	%this.shieldStrength = 0.010; 
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
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this); 
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "PlasmaTurretPack"]--; 
} 

function DeployablePlasma::onPower(%this,%power,%generator) {} 

function DeployablePlasma::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
} 







//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              DeployableRail
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

TurretData DeployableRail 
{ 
   className = "Turret"; 
   shapeFile = "hellfiregun"; 
   projectileType = railLaser; 
   maxDamage = 1.0 * $Nappy::TurretStrength; 
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

function DeployableRail::onAdd(%this) 
{ 
	schedule("DeployableRail::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,20); 
	%this.shieldStrength = 0.005; 
	if (GameBase::getMapName(%this) == "") { 
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
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "RailTurretPack"]--; 
} 

function DeployableRail::onPower(%this,%power,%generator) {} 

function DeployableRail::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this,20); 
	GameBase::setActive(%this,true); 
} 





//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              DeployableRocket
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

TurretData DeployableRocket 
{ 
   className = "Turret"; 
   shapeFile = "missileturret"; 
   projectileType = TurretMissile; 
   maxDamage = 1.7 * $Nappy::TurretStrength; 
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
   description = "Deployable Missile Turret"; 
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
	%this.shieldStrength = 0.015; 
	if (GameBase::getMapName(%this) == "") { 
		GameBase::setMapName (%this, "Remote Rocket"); 
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
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this);  
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "RocketTurretPack"]--; 
} 

function DeployableRocket::onPower(%this,%power,%generator) 
{} 

function DeployableRocket::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
} 





//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              DeployableVulcan
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

TurretData DeployableVulcan 
{ 
   className = "Turret"; 
   shapeFile = "hellfiregun"; 
   projectileType = TurretBullet; 
   accuFire = false; 
   maxDamage = 4.0 * $Nappy::TurretStrength; 
   maxEnergy = 300; 
   minGunEnergy = 4; 
   maxGunEnergy = 5; 
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

function DeployableVulcan::onAdd(%this) 
{ 
	schedule("DeployableVulcan::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,10); 
	%this.shieldStrength = 0.005; 
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
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this); 
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "VulcanTurretPack"]--; 
} 

function DeployableVulcan::onPower(%this,%power,%generator) {} 

function DeployableVulcan::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this,100); 
	GameBase::setActive(%this,true); 
} 






function Turret::onControl(%this, %object) 
{ 
	%name = GameBase::getDataName(%this);
	%client = Player::getClient(%object); 
	Client::sendMessage(%client,0,"Controlling turret " @ %name);
} 

function Turret::onDismount(%this, %object) 
{
	%name = GameBase::getDataName(%this);
	%client = Player::getClient(%object); 
	Client::sendMessage(%client,0,"Leaving " @ %name.description @ "."); 
	%client.usingThis = "";
	%this.beingUsed = 0;
} 

function TurretActivate(%this, %object)
{
	%client = Player::getClient(%object);
	if($ControllingTurret[%client] != true){
		$ClientActivatePosition[%client] = GameBase::getPosition(%client);
		$TurretActive[%client] = true;
		Client::getOwnedObject(%client).CommandTag = 0;
	}
}

function ClientControlDisable(%this, %object)
{
	%client = Player::getClient(%object);
	Client::getOwnedObject(%client).CommandTag = 0; 
}



function Turret::onCollision (%this, %object) 
{
	if(getObjectType (%object) == "Player") { 
		%client = Player::getClient(%object);
		%armor = Player::getArmor(%object); 
		if(GameBase::getTeam(%object) == GameBase::getTeam(%this)) { 
			%name = GameBase::getDataName(%this); 
			if(%name == PlasmaTurret || %name == MortarTurret || %name == RocketTurret || %name == DeployablePlasma || %name == DeployableMortar || %name == DeployableRocket) { 
				if(Player::getMountedItem(%object,$BackpackSlot) == Laptop) { 
					if($TurretActive[%client] != false || $ClientLastTurret[%client] != %this) { 
						if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object)) { 
							Client::getOwnedObject(%client).CommandTag = 1; 
							Client::sendMessage(%client,0,"Re-programming turret"); 
							GameBase::setTeam (%this,GameBase::getTeam (%client)); 
							Client::takeControl(%client, %this); 
							if(%name == DeployablePlasma || %name == DeployableVulcan || %name == DeployableRail ) 
								GameBase::SetPosition(%object,GameBase::GetPosition(%this)); 
							$TurretActive[%client] = false;
							$ControllingTurret[%client] = true;
							$ClientLastTurret[%client] = %this;
							%this.beingUsed = 1;
							%client.usingThis = %this;
							return; 
						}
					}
					else
						Client::sendMessage(%client,0,"Turret is recharging.");
				} 
			}
			else if(%name == DeployableVulcan || %name == DeployableRail) { 
				if (%armor != "darmor") { 
					if($TurretActive[%client] != false || $ClientLastTurret[%client] != %this) { 
						Client::getOwnedObject(%client).CommandTag = 1; 
						Client::sendMessage(%client,0,"Manually controlling " @ %name.description @ "."); 
						Client::takeControl(%client, %this); 
						GameBase::SetPosition(%object,GameBase::GetPosition(%this));
						$TurretActive[%client] = false;
						$ClientActivatePosition[%client] = GameBase::getPosition(%client);
						$ControllingTurret[%client] = true;
						$ClientLastTurret[%client] = %this;
						%this.beingUsed = 1;
						%client.usingThis = %this;
						return;  
					} 
					else 
						Client::sendMessage(%client,0,"Turret is recharging."); 
				} 
				else 
					Client::sendMessage(%client,0,"Can not manually command turrets in this class."); 
			} 
			else if(Player::getMountedItem(%object,$BackpackSlot) == Laptop) 
				Client::sendMessage(%client,0,"Cannot manually control this turret.");
		}
		//else 
			//Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav"); 
	} 
} 





function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		if(%name != DeployableTurret && %name != CameraTurret && %name != DeployableSatchel && %name != IonTurret && %name != ArbitorBox && %name != DeployableLaser && %name != DeployableIndoor && %name != DeployableShock && %name != AntiAirTurret && %name != DeployableElf && %name != DeployableMortar && %name != DeployablePlasma && %name != DeployableRail && %name != DeployableRocket && %name != DeployableVulcan)	
			%TDS = $Server::TeamDamageScale;
	}
	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
}





//TurretData ArbitorBox
//{
//	className = "Turret";
//	shapeFile = "magcargo";
////	projectileType = none;
//	maxDamage = 2;
//	maxEnergy = 0;
////	minGunEnergy = 6;
////	maxGunEnergy = 5;
//	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
////	reloadDelay = 0.4;
////	speed = 4.0;
////	speedModifier = 1.5;
////	range = 10;
//	visibleToSensor = true;
//	shadowDetailMask = 4;
//	supressable = true;
//	pinger = false;
//	dopplerVelocity = 0;
//	castLOS = true;
//	supression = true;
//	mapFilter = 2;
//	mapIcon = "M_turret";
//	debrisId = flashDebrisMedium;
//	shieldShapeName = "shield";
////	fireSound = SoundFireMortar;
//	activationSound = SoundRemoteTurretOn;
//	deactivateSound = SoundRemoteTurretOff;
//	explosionId = flashExpMedium;
//	description = "Arbitor Box";
//	damageSkinData = "objectDamageSkins";
//};
//
//function ArbitorBox::onAdd(%this)
//{
//	schedule("ArbitorBox::deploy(" @ %this @ ");",1,%this);
//	GameBase::setRechargeRate(%this,5);
//	if (GameBase::getMapName(%this) == "") {
//		GameBase::setMapName (%this, "Arbitor Box");
//	}
//}
//
//function ArbitorBox::deploy(%this)
//{
//	GameBase::playSequence(%this,1,"deploy");
//}
//
//function ArbitorBox::onEndSequence(%this,%thread)
//{
//	GameBase::setActive(%this,true);
//}
//
//function ArbitorBox::onDisabled(%this)
//{
//	Turret::onDisabled(%this);
//
//	%num = Group::objectCount(%this.set);
//	for(%i=%num-1; %i >= 0; %i--)
//	{
//		%obj = Group::getObject(%this.set, %i);
//		GameBase::startFadeIn(%obj);
//		%obj.cloaked = 0;
//	}
//	deleteObject(%this.set);
//}
//function ArbitorBox::onDestroyed(%this)
//{
//	Turret::onDestroyed(%this);
//  	$TeamItemCount[GameBase::getTeam(%this) @ "ArbitorBoxPack"]--;
//}
//
//// Override base class just in case.
//function ArbitorBox::onPower(%this,%power,%generator) {}
//function ArbitorBox::onEnabled(%this) 
//{
//	GameBase::setRechargeRate(%this,5);
//	GameBase::setActive(%this,true);
//
//	%Set = newObject("set",SimSet); 
//	%Pos = GameBase::getPosition(%this); 
//	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
//	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 50,0);
//	%num = Group::objectCount(%Set);
//	for(%i; %i < %num; %i++)
//	{
//		%obj = Group::getObject(%Set, %i);
//		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
//		{
//			//don't cloak enemies or the box itself
//		}
//		else
//		{
//			GameBase::startFadeOut(%obj);
//			%obj.cloaked = 1;
//		}
//	}
//
//	%this.set = %Set;
//
//	schedule("ArbitorBox::checkArbitorBox(" @ %this @ ");", 0.1, %this);
//
//}	
//
//function ArbitorBox::checkArbitorBox(%this)
//{
//
//	if(GameBase::getDamageState(%this) != "Enabled")
//		return;
//
//	%this.evenodd = !%this.evenodd; //switches from 1 to 0... tells every other check... used to check if in both new & old sets
//
//	%Set = newObject("set",SimSet); 
//	%Pos = GameBase::getPosition(%this); 
//	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
//	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 50,0);
//	%num = Group::objectCount(%Set);
//for(%i; %i < %num; %i++)
//	{
//		%obj = Group::getObject(%Set, %i);
//		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
//		{
//			//don't cloak enemies or the box itself
//		}
//		else
//		{
//			GameBase::startFadeOut(%obj);
//			%obj.cloaked = 1 + %this.evenodd; //1 half the time & 2 other half... used to check if in this set while searching the old set
//		}
//	}
//
//
//	%num = Group::objectCount(%this.set);
//
//	for(%j; %j < %num; %j++)
//	{
//		%obj = Group::getObject(%this.set, %j);
//		if(%obj == %this || GameBase::getTeam(%obj) != GameBase::getTeam(%this))
//		{
//			//don't bother checking the other team or the box itself; they're not cloaked
//		}
//		else if(%obj.cloaked != (%this.evenodd + 1)) //if different then new set
//		{
//			%obj.cloaked = 0;
//			if(%obj.cloakPack == 0 && %obj.cloakGun == 0) GameBase::startFadeIn(%obj); //then decloak it
//		}
//	}
//
//	deleteObject(%this.set); //delete the old set
//	%this.set = %Set; //and replace with new set
//
//	schedule("ArbitorBox::checkArbitorBox(" @ %this @ ");", 6.0, %this); //then recheck in 10 seconds
//}

//===============================================PlasmaTurret
//===============================================

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
speed = 2.0; speedModifier = 2.0; 
projectileType = FusionBolt; 
damageSkinData = "objectDamageSkins"; 
shadowDetailMask = 8; 
explosionId = LargeShockwave; 
description = "Plasma Turret"; 
}; 



//=================================================ELFTurret
//=================================================

//TurretData ELFTurret 
//{ 
//maxDamage = 1.0; 
//maxEnergy = 350; 
//minGunEnergy = 50; 
//maxGunEnergy = 5; 
//range = 40; 
//visibleToSensor = true; 
//dopplerVelocity = 0; 
//castLOS = true; 
//supression = false; 
//mapFilter = 2; 
//mapIcon = "M_turret"; 
//debrisId = defaultDebrisMedium; 
//className = "ELF Turret"; 
//shapeFile = "chainturret"; 
//shieldShapeName = "shield"; 
//speed = 5.0; 
//speedModifier = 1.5; 
//projectileType = turretCharge; 
//reloadDelay = 0.3; 
//explosionId = LargeShockwave; 
//description = "ELF Turret"; 
//fireSound = SoundGeneratorPower; 
//activationSound = SoundChainTurretOn; 
//deactivateSound = SoundChainTurretOff; 
//damageSkinData = "objectDamageSkins"; 
//shadowDetailMask = 8; 
//isSustained = true; 
//firingTimeMS = 750; 
//energyRate = 30.0; 
//}; 






//==================================================DeployableElf
//==================================================

//TurretData DeployableElf 
//{ 
//maxDamage = 1.0; 
//maxEnergy = 350; 
//minGunEnergy = 50; 
//maxGunEnergy = 5; 
//range = 40; 
//visibleToSensor = true; 
//dopplerVelocity = 0; 
//castLOS = true; 
//supression = false; 
//mapFilter = 2; 
//mapIcon = "M_turret"; 
//debrisId = defaultDebrisMedium; 
//className = "ELF Turret"; 
//shapeFile = "chainturret"; 
//shieldShapeName = "shield"; 
//speed = 5.0; 
//speedModifier = 1.5; 
//projectileType = turretCharge; 
//reloadDelay = 0.3; 
//explosionId = LargeShockwave; 
//description = "ELF Turret"; 
//fireSound = SoundGeneratorPower; 
//activationSound = SoundChainTurretOn; 
//deactivateSound = SoundChainTurretOff; 
//damageSkinData = "objectDamageSkins"; 
//shadowDetailMask = 8; 
//isSustained = true; 
//firingTimeMS = 750; 
//energyRate = 30.0; 
//};  
//
//function DeployableElf::onAdd(%this) 
//{ 
//schedule("DeployableElf::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,5); 
//%this.shieldStrength = 0.030; 
//if (GameBase::getMapName(%this) == "") 
//{ 
//GameBase::setMapName (%this, "Elf Turret"); 
//} 
//} 
//
//function DeployableElf::deploy(%this) 
//{ 
//GameBase::playSequence(%this,1,"deploy"); 
//} 
//
//function DeployableElf::onEndSequence(%this,%thread) 
//{ 
//GameBase::setActive(%this,true); 
//} 
//
//function DeployableElf::onDestroyed(%this) 
//{ 
//StaticShape::objectiveDestroyed(%this); 
//%this.shieldStrength = 0; 
//GameBase::setRechargeRate(%this,0); 
//Turret::onDeactivate(%this); CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
//$TeamItemCount[GameBase::getTeam(%this) @ "DeployableElfTurretTurret"]--; 
//} 
//
//function DeployableElf::onPower(%this,%power,%generator) {} 
//
//function DeployableElf::onEnabled(%this) 
//{ 
//GameBase::setRechargeRate(%this,10); 
//GameBase::setActive(%this,true); 
//} 






//=========================================DeployableIndoor
//=========================================

//TurretData DeployableIndoor 
//{ 
//className = "Turret"; 
//shapeFile = "indoorgun"; 
//projectileType = MiniFusionBolt; 
//maxDamage = 2.5; 
//maxEnergy = 60; 
//minGunEnergy = 20; 
//maxGunEnergy = 6; 
//reloadDelay = 0.4; 
//speed = 5.0; 
//speedModifier = 1.0; 
//range = 25; 
//visibleToSensor = true; 
//dopplerVelocity = 2; 
//castLOS = true; 
//supression = false; 
//supressable = false; 
//pinger = false; 
//mapFilter = 2; 
//mapIcon = "M_turret"; 
//debrisId = defaultDebrisMedium; 
//shieldShapeName = "shield"; 
//fireSound = SoundEnergyTurretFire; 
//activationSound = SoundEnergyTurretOn; 
//deactivateSound = SoundEnergyTurretOff; 
//damageSkinData = "objectDamageSkins"; 
//shadowDetailMask = 8; 
//explosionId = debrisExpMedium; 
//description = "Indoor Turret"; 
//}; 
// 
//
//function DeployableIndoor::onAdd(%this) 
//{ 
//schedule("DeployableIndoor::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,6); 
//%this.shieldStrength = 0.030; 
//
//if (GameBase::getMapName(%this) == "") 
//{ 
//GameBase::setMapName (%this, "Remote Indoor Turret"); 
//} 
//} 
//
//function DeployableIndoor::deploy(%this) 
//{ 
//GameBase::playSequence(%this,1,"deploy"); 
//} 
//
//function DeployableIndoor::onEndSequence(%this,%thread) 
//{ 
//GameBase::setActive(%this,true); 
//} 
//
//function DeployableIndoor::onDestroyed(%this) 
//{ 
//Turret::onDestroyed(%this); 
//$TeamItemCount[GameBase::getTeam(%this) @ "IndoorPack"]--; 
//} 
//
//function DeployableIndoor::onPower(%this,%power,%generator) {} 
//
//function DeployableIndoor::onEnabled(%this) 
//{ 
//GameBase::setRechargeRate(%this,5); 
//GameBase::setActive(%this,true); 
//} 








//=========================================RocketTurret
//=========================================

TurretData RocketTurret 
{ 
maxDamage = 1.75; 
maxEnergy = 100; 
minGunEnergy = 60; 
maxGunEnergy = 60; 
range = 270; 
gunRange = 330; 
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
} else 
{ 
%this.shieldStrength = 0; 
GameBase::setRechargeRate(%this,0); 
Turret::checkOperator(%this); 
} 
GameBase::setActive(%this,%power); 
} 

function RocketTurret::verifyTarget(%this,%target) { if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) return "True"; else return "False"; } 




//=========================================MortarTurret
//=========================================


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



//=========================================DeployableMortarTurret
//=========================================


//TurretData DeployableMortar 
//{ className = "Turret"; shapeFile = "mortar_turret"; projectileType = MortarTurretShell; maxDamage = 1.0; maxEnergy = 45; minGunEnergy = 45; maxGunEnergy = 100; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 2.0; speed = 2.0; speedModifier = 1.5; range = 0; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; fireSound = SoundMortarTurretFire; activationSound = SoundMortarTurretOn; deactivateSound = SoundMortarTurretOff; whirSound = SoundMortarTurretTurn; explosionId = LargeShockwave; description = "Remote Mortar Turret"; damageSkinData = "objectDamageSkins"; }; function DeployableMortar::onAdd(%this) { schedule("DeployableMortar::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,7); %this.shieldStrength = 0.005; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Mortar Turret"); } } function DeployableMortar::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployableMortar::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployableMortar::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "TargetPack"]--; } function DeployableMortar::onPower(%this,%power,%generator) {} function DeployableMortar::onEnabled(%this) { GameBase::setRechargeRate(%this,7); GameBase::setActive(%this,true); } 
//


//=========================================AntiAirTurret
//=========================================


TurretData AntiAirTurret 
{ 
className = "Turret"; 
shapeFile = "remoteturret"; 
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

function AntiAirTurret::verifyTarget(%this,%target) { if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) return "True"; else return "False"; } 


function AntiAirTurret::onAdd(%this) { schedule("AntiAirTurret::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,7); %this.shieldStrength = 0.005; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Mortar Turret"); } 
} 
function AntiAirTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function AntiAirTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); 
} 
function AntiAirTurret::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "AntiAirPack"]--; 
} 
function AntiAirTurret::onPower(%this,%power,%generator) {} function AntiAirTurret::onEnabled(%this) { GameBase::setRechargeRate(%this,7); GameBase::setActive(%this,true); 
} 




//=========================================IndoorTurret
//=========================================


TurretData IndoorTurret 
{ className = "Turret"; shapeFile = "indoorgun"; projectileType = MiniFusionBolt; maxDamage = 2.5; maxEnergy = 60; minGunEnergy = 20; maxGunEnergy = 6; reloadDelay = 0.4; speed = 5.0; speedModifier = 1.0; range = 25; visibleToSensor = true; dopplerVelocity = 2; castLOS = true; supression = false; supressable = false; pinger = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = defaultDebrisMedium; shieldShapeName = "shield"; fireSound = SoundEnergyTurretFire; activationSound = SoundEnergyTurretOn; deactivateSound = SoundEnergyTurretOff; damageSkinData = "objectDamageSkins"; shadowDetailMask = 8; explosionId = debrisExpMedium; description = "Indoor Turret"; }; 




//=========================================DeployableTurret
//=========================================


//TurretData DeployableTurret 
//{ className = "Turret"; shapeFile = "remoteturret"; projectileType = IonBolt; maxDamage = 1.0; maxEnergy = 60; minGunEnergy = 6; maxGunEnergy = 5; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 0.3; speed = 4.0; speedModifier = 1.5; range = 155; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; fireSound = SoundRemoteTurretFire; activationSound = SoundRemoteTurretOn; deactivateSound = SoundRemoteTurretOff; explosionId = flashExpMedium; description = "Remote Ion Turret"; damageSkinData = "objectDamageSkins"; }; function DeployableTurret::onAdd(%this) { schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,5); %this.shieldStrength = 0.005; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Remote Turret"); } } function DeployableTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployableTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployableTurret::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--; } function DeployableTurret::onPower(%this,%power,%generator) {} function DeployableTurret::onEnabled(%this) { GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); } 




//=========================================DeployablePlasma 
//=========================================


//TurretData DeployablePlasma 
//{ className = "Turret"; shapeFile = "hellfiregun"; projectileType = FusionBolt; maxDamage = 1.5; maxEnergy = 200; minGunEnergy = 75; maxGunEnergy = 6; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 0.8; speed = 4.0; speedModifier = 1.5; range = 100; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; fireSound = SoundPlasmaTurretFire; activationSound = SoundPlasmaTurretOn; deactivateSound = SoundPlasmaTurretOff; whirSound = SoundPlasmaTurretTurn; explosionId = flashExpMedium; description = "Remote Turret"; damageSkinData = "objectDamageSkins"; }; function DeployablePlasma::onAdd(%this) { schedule("DeployablePlasma::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,5); %this.shieldStrength = 0.010; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Plasma Turret"); } } function DeployablePlasma::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployablePlasma::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployablePlasma::onDestroyed(%this) { StaticShape::objectiveDestroyed(%this); %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this); CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); $TeamItemCount[GameBase::getTeam(%this) @ "LaserTurret"]--; } function DeployablePlasma::onPower(%this,%power,%generator) {} function DeployablePlasma::onEnabled(%this) { GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); } 




//=========================================DeployableLaser
//=========================================


//TurretData DeployableLaser
//{
//	className = "Turret";
//	shapeFile = "camera";
//	projectileType = SniperLaser;
//	maxDamage = 0.75;
//	maxEnergy = 35;
//	minGunEnergy = 10;
//	maxGunEnergy = 60;
//	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
//	reloadDelay = 10.0;
//	speed = 4.0;
//	speedModifier = 1.5;
//	range = 125;
//	visibleToSensor = true;
//	shadowDetailMask = 4;
//	dopplerVelocity = 0;
//	castLOS = true;
//	supression = false;
//	mapFilter = 2;
//	mapIcon = "M_turret";
//	debrisId = flashDebrisMedium;
//	shieldShapeName = "shield";
//	fireSound = SoundFireLaser;
//	activationSound = SoundRemoteTurretOn;
//	deactivateSound = SoundRemoteTurretOff;
//	explosionId = flashExpMedium;
//	description = "Remote Laser Turret";
//	damageSkinData = "objectDamageSkins";
//};
//
//function DeployableLaser::onAdd(%this)
//{
//	schedule("DeployableLaser::deploy(" @ %this @ ");",1,%this);
//	GameBase::setRechargeRate(%this,5);
//	%this.shieldStrength = 0;
//	if (GameBase::getMapName(%this) == "") {
//		GameBase::setMapName (%this, "Remote Laser Turret");
//	}
//}
//
//function DeployableLaser::deploy(%this)
//{
//	GameBase::playSequence(%this,1,"deploy");
//}
//
//function DeployableLaser::onEndSequence(%this,%thread)
//{
//	GameBase::setActive(%this,true);
//}
//
//function DeployableLaser::onDestroyed(%this)
//{
//	Turret::onDestroyed(%this);
//  	$TeamItemCount[GameBase::getTeam(%this) @ "LaserPack"]--;
//}
//
//// Override base class just in case.
//function DeployableLaser::onPower(%this,%power,%generator) {}
//function DeployableLaser::onEnabled(%this) 
//{
//	GameBase::setRechargeRate(%this,5);
//	GameBase::setActive(%this,true);
//}	




//=========================================DeployableVulcan
//=========================================


//TurretData DeployableVulcan 
//{ className = "Turret"; shapeFile = "hellfiregun"; projectileType = TurretBullet; accuFire = false; maxDamage = 4.0; maxEnergy = 300; minGunEnergy = 4; maxGunEnergy = 5; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 0.00001; speed = 4.0; speedModifier = 1.5; range = 0; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; fireSound = SoundFireMortar; activationSound = SoundPlasmaTurretOn; deactivateSound = SoundPlasmaTurretOff; whirSound = SoundPlasmaTurretTurn; explosionId = flashExpMedium; description = "Vulcan Turret"; damageSkinData = "objectDamageSkins"; }; function DeployableVulcan::onAdd(%this) { schedule("DeployableVulcan::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,10); %this.shieldStrength = 0.005; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Vulcan Turret"); } } function DeployableVulcan::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployableVulcan::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployableVulcan::onDestroyed(%this) { StaticShape::objectiveDestroyed(%this); %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this); CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); $TeamItemCount[GameBase::getTeam(%this) @ "VulcanTurret"]--; } function DeployableVulcan::onPower(%this,%power,%generator) {} function DeployableVulcan::onEnabled(%this) { GameBase::setRechargeRate(%this,100); GameBase::setActive(%this,true); } 




//=========================================DeployableRail
//=========================================


//TurretData DeployableRail 
//{ className = "Turret"; shapeFile = "gunturet"; projectileType = railLaser; maxDamage = 1.0; maxEnergy = 155; minGunEnergy = 100; maxGunEnergy = 150; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 8.0; speed = 4.0; speedModifier = 1.5; range = 0; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; fireSound = SoundMissileTurretFire; activationSound = SoundPlasmaTurretOn; deactivateSound = SoundPlasmaTurretOff; whirSound = SoundPlasmaTurretTurn; explosionId = flashExpMedium; description = "Rail Turret"; damageSkinData = "objectDamageSkins"; }; function DeployableRail::onAdd(%this) { schedule("DeployableRail::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,20); %this.shieldStrength = 0.005; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Rail Turret"); } } function DeployableRail::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployableRail::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployableRail::onDestroyed(%this) { StaticShape::objectiveDestroyed(%this); %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this); CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); $TeamItemCount[GameBase::getTeam(%this) @ "RailTurret"]--; } function DeployableRail::onPower(%this,%power,%generator) {} function DeployableRail::onEnabled(%this) { GameBase::setRechargeRate(%this,20); GameBase::setActive(%this,true); } 
//hellfire




//=========================================DeployableShock
//=========================================


//TurretData DeployableShock 
//{ 
//maxDamage = 1.5; 
//maxEnergy = 110; 
//minGunEnergy = 15; 
//maxGunEnergy = 20; 
//reloadDelay = 2.0; 
//fireSound = SoundMortarTurretFire; 
//activationSound = SoundMortarTurretOn; 
//deactivateSound = SoundMortarTurretOff; 
//whirSound = SoundMortarTurretTurn; 
//range = 30; 
//dopplerVelocity = 0; 
//castLOS = true; 
//supression = false; 
//mapFilter = 2; 
//mapIcon = "M_turret"; 
//visibleToSensor = true; 
//debrisId = defaultDebrisMedium; 
//className = "Turret"; 
//shapeFile = "indoorgun"; 
//shieldShapeName = "shield_medium"; 
//speed = 5.0; 
//speedModifier = 1.50; 
//projectileType = ShockShell; 
//damageSkinData = "objectDamageSkins"; 
//shadowDetailMask = 8; 
//explosionId = LargeShockwave; 
//description = "Shock Turret"; 
//}; 
//
//function DeployableShock::onAdd(%this) 
//{ 
//schedule("DeployableShock::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,6); 
//%this.shieldStrength = 0.010; 
//
//if (GameBase::getMapName(%this) == "") 
//{ 
//GameBase::setMapName (%this, "Remote Shock Turret"); 
//} 
//} 
//
//function DeployableShock::deploy(%this) 
//{ 
//GameBase::playSequence(%this,1,"deploy"); 
//} 
//
//function DeployableShock::onEndSequence(%this,%thread) 
//{ 
//GameBase::setActive(%this,true); 
//} 
//
//function DeployableShock::onDestroyed(%this) 
//{ 
//Turret::onDestroyed(%this); 
//$TeamItemCount[GameBase::getTeam(%this) @ "ShockPack"]--; 
//} 
//
//function DeployableShock::onPower(%this,%power,%generator) {} 
//
//function DeployableShock::onEnabled(%this) 
//{ 
//GameBase::setRechargeRate(%this,5); 
//GameBase::setActive(%this,true); 
//} 



//=========================================DeployableSatchel 
//=========================================


TurretData DeployableSatchel 
{ className = "Turret"; shapeFile = "camera"; projectileType = SatchelShell; maxDamage = 0.4; maxEnergy = 60; minGunEnergy = 10; maxGunEnergy = 60; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 10.0; speed = 4.0; speedModifier = 1.5; range = 0; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; fireSound = SoundFireLaser; activationSound = SoundRemoteTurretOn; deactivateSound = SoundRemoteTurretOff; explosionId = rocketExp; description = "Satchel Charge"; damageSkinData = "objectDamageSkins"; }; function DeployableSatchel::onAdd(%this) { schedule("DeployableSatchel::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,0); %this.shieldStrength = 0; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Satchel Charge"); } } function DeployableSatchel::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployableSatchel::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployableSatchel::onDestroyed(%this) { StaticShape::objectiveDestroyed(%this); %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this);  calcRadiusDamage(%this, $DebrisDamageType, 20.0, 1.5, 25, 9, 3, 0.20,0.1, 200, 100); $TeamItemCount[GameBase::getTeam(%this) @ "SatchelPack"]--; } function DeployableSatchel::onPower(%this,%power,%generator) {} function DeployableSatchel::onEnabled(%this) { GameBase::setRechargeRate(%this,0); GameBase::setActive(%this,true); } 





//=========================================TargetTurret
//=========================================


TurretData TargetTurret 
{ maxDamage = 1.0; maxEnergy = 300; minGunEnergy = 5; maxGunEnergy = 5; range = 100; visibleToSensor = true; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = defaultDebrisMedium; className = "Targeting Turret"; shapeFile = "camera"; shieldShapeName = "shield"; speed = 5.0; speedModifier = 1.5; projectileType = targetLaser; reloadDelay = 0.3; explosionId = flashExpMedium; description = "Deployable Targeting Turret"; fireSound = SoundFireTargetingLaser; activationSound = SoundChainTurretOn; deactivateSound = SoundChainTurretOff; damageSkinData = "objectDamageSkins"; shadowDetailMask = 8; isSustained = true; firingTimeMS = 750; energyRate = 30.0; }; function TargetTurret::onAdd(%this) { schedule("TargetTurret::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,15); %this.shieldStrength = 0; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Remote Targeting Turret"); } } function TargetTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function TargetTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function TargetTurret::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "TargetPack"]--; } function TargetTurret::onPower(%this,%power,%generator) {} function TargetTurret::onEnabled(%this) { GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); } 




//=========================================DeployableRocket
//=========================================


//TurretData DeployableRocket 
//{ className = "Turret"; shapeFile = "missileturret"; projectileType = TurretMissile; maxDamage = 1.7; maxEnergy = 90; minGunEnergy = 50; maxGunEnergy = 50; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 2.0; speed = 6.0; speedModifier = 4.5; range = 175; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; fireSound = SoundMissileTurretFire; activationSound = SoundRemoteTurretOn; deactivateSound = SoundRemoteTurretOff; explosionId = flashExpMedium; description = "Missile Turret"; damageSkinData = "objectDamageSkins"; }; function DeployableRocket::verifyTarget(%this,%target) { if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) return "True"; else return "False"; } function DeployableRocket::onAdd(%this) { schedule("DeployableRocket::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,5); %this.shieldStrength = 0.015; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Remote Rocket"); } } function DeployableRocket::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployableRocket::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployableRocket::onDestroyed(%this) { StaticShape::objectiveDestroyed(%this); %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this);  CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); $TeamItemCount[GameBase::getTeam(%this) @ "RocketPack"]--; } function DeployableRocket::onPower(%this,%power,%generator) {} function DeployableRocket::onEnabled(%this) { GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); } 




//=========================================CameraTurret
//=========================================


TurretData CameraTurret 
{ className = "Turret"; shapeFile = "camera"; maxDamage = 0.25; maxEnergy = 10; speed = 20; speedModifier = 1.0; range = 50; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; visibleToSensor = true; shadowDetailMask = 4; castLOS = true; supression = false; supressable = false; mapFilter = 2; mapIcon = "M_camera"; debrisId = defaultDebrisSmall; FOV = 0.707; pinger = false; explosionId = debrisExpMedium; description = "Camera"; 
}; 
function CameraTurret::onAdd(%this) { schedule("CameraTurret::deploy(" @ %this @ ");",1,%this); if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Camera"); } 
} 
function CameraTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); 
} 
function CameraTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); 
} 
function CameraTurret::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "CameraPack"]--; } function Turret::onAdd(%this) 
{ if 
      (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Turret"); } 
} 



//===================================================================
//===================================================================
//===================================================================
//===================================================================



function Turret::onActivate(%this) { GameBase::playSequence(%this,0,power); 
} 
function Turret::onDeactivate(%this) { GameBase::stopSequence(%this,0); Turret::checkOperator(%this); 
} 
function Turret::onSetTeam(%this,%oldTeam) { if(GameBase::getTeam(%this) != Client::getTeam(GameBase::getControlClient(%this))) Turret::checkOperator(%this); 
} 
function Turret::checkOperator(%this) { %cl = GameBase::getControlClient(%this); if(%cl != -1) { %pl = Client::getOwnedObject(%cl); Player::setMountObject(%pl, -1,0); Client::setControlObject(%cl, %pl); } Client::setGuiMode(%cl,2); 
} 
function Turret::onPower(%this,%power,%generator) { if (%power) { %this.shieldStrength = 0.03; GameBase::setRechargeRate(%this,10); } else { %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::checkOperator(%this); } GameBase::setActive(%this,%power); 
} 
function Turret::onEnabled(%this) { if (GameBase::isPowered(%this)) { %this.shieldStrength = 0.03; GameBase::setRechargeRate(%this,10); GameBase::setActive(%this,true); } 
} 
function Turret::onDisabled(%this) { %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this); 
} 
function Turret::onDestroyed(%this) { StaticShape::objectiveDestroyed(%this); %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this); calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 0.1, 200, 100); 
} 
function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { if(%this.objectiveLine) %this.lastDamageTeam = GameBase::getTeam(%object); %TDS= 1; if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) { %name = GameBase::getDataName(%this); if(%name != DeployableTurret && %name != CameraTurret && %name != DeployableSatchel && %name != DeployableMortar && %name != DeployableHolo && %name != DeployableHolo2 && %name != DeployableHolo3 && %name != DeployablePlasma && %name != DeployableLaser && %name != DeployableRocket && %name != DeployableVulcan && %name != DeployableRail && %name != DeployableShock && %name != DeployableIndoor && %name != AntiAirTurret && %name != DeployableElf && %name != ArbitorBox) %TDS = $Server::TeamDamageScale; } StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object); 
} 





function Turret::onControl (%this, %object) { %client = Player::getClient(%object); Client::sendMessage(%client,0,"Controlling turret " @ %this); $turretTime[%this] = 1; 
} 
function Turret::onDismount (%this, %object) { %client = Player::getClient(%object); Client::sendMessage(%client,0,"Leaving turret " @ %this); $turretTime[%this] = 0; LaptopDrain(%client, %object); 
} 
function Turret::onCollision (%this, %object) { if(getObjectType (%object) == "Player") { %armor = Player::getArmor(%object); if ( (Player::getMountedItem(%object,$BackpackSlot) == Laptop) ) { %name = GameBase::getDataName(%this); if(%name == DeployableMortar || %name == DeployablePlasma || %name == DeployableRocket || %name == DeployableVulcan || %name == DeployableRail || %name == MortarTurret) { %client = Player::getClient(%object); if($lapTime[%client] == 0) { if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object)) { Client::getOwnedObject(%client).CommandTag = 1; Client::sendMessage(%client,0,"Re-programming turret"); GameBase::setTeam (%this,GameBase::getTeam (%client)); Client::takeControl(%client, %this); if(%name == DeployablePlasma || %name == DeployableVulcan || %name == DeployableRail ) GameBase::SetPosition(%object,GameBase::GetPosition(%this)); return; } } else Client::sendMessage(%client,0,"Turret is recharging."); } } } if(getObjectType (%object) == "Player") { %armor = Player::getArmor(%object); if (%armor != "darmor") { if(GameBase::getTeam(%object) == GameBase::getTeam(%this)) { %client = Player::getClient(%object); if($lapTime[%client] == 0) { %name = GameBase::getDataName(%this); if(%name == DeployableVulcan || %name == DeployableRail) { if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object)) { Client::getOwnedObject(%client).CommandTag = 1; Client::sendMessage(%client,0,"Manually controlling turret"); Client::takeControl(%client, %this); GameBase::SetPosition(%object,GameBase::GetPosition(%this)); return; } } } else Client::sendMessage(%client,0,"Turret is recharging."); } else Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav"); } else Client::sendMessage(%client,0,"Can not manually command turrets in this class."); } } function LaptopDrain(%clientId, %player) { Player::unmountItem(%player,$WeaponSlot); if($lapTime[%clientId] == 0) { Client::getOwnedObject(%clientId).CommandTag = ""; $lapTime[%clientId] = 14; checkPlayerLaptop(%clientId, %player); } else $lapTime[%clientId] = 14; } function checkPlayerLaptop(%clientId, %player) { if($lapTime[%clientId] > 0) { $lapTime[%clientId] -= 2; schedule("checkPlayerLaptop(" @ %clientId @ ", " @ %player @ ");",2,%player); } else { } }
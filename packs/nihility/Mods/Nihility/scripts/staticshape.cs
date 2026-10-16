






function StaticShape::onPower(%this,%power,%generator) { if (%power) GameBase::playSequence(%this,0,"power"); else GameBase::stopSequence(%this,0); } 

function StaticShape::onEnabled(%this) { if (GameBase::isPowered(%this)) GameBase::playSequence(%this,0,"power"); } 

function StaticShape::onDisabled(%this) { GameBase::stopSequence(%this,0); } 

function StaticShape::onDestroyed(%this) { GameBase::stopSequence(%this,0); 
StaticShape::objectiveDestroyed(%this); 
calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100); } 

function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { %damageLevel = GameBase::getDamageLevel(%this); %dValue = %damageLevel + %value; %this.lastDamageObject = %object; %this.lastDamageTeam = GameBase::getTeam(%object); if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) { %name = GameBase::getDataName(%this); if(%name.className == Generator || %name.className == Station) { %TDS = $Server::TeamDamageScale; %dValue = %damageLevel + %value * %TDS; %disable = GameBase::getDisabledDamage(%this); if(!$Server::TourneyMode && %dValue > %disable - 0.05) { if(%damageLevel > %disable - 0.05) return; else %dValue = %disable - 0.05; } } } GameBase::setDamageLevel(%this,%dValue); } 

function StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object) { %damageLevel = GameBase::getDamageLevel(%this); %this.lastDamageObject = %object; %this.lastDamageTeam = GameBase::getTeam(%object); if (%this.shieldStrength) { %energy = GameBase::getEnergy(%this); %strength = %this.shieldStrength; if (%type == $ShrapnelDamageType) %strength *= 0.5; else if (%type == $MortarDamageType) %strength *= 0.25; else if (%type == $BlasterDamageType) %strength *= 2.0; %absorb = %energy * %strength; if (%value < %absorb) { GameBase::setEnergy(%this,%energy - (%value / %strength)); %centerPos = getBoxCenter(%this); %sphereVec = findPointOnSphere(getBoxCenter(%object),%centerPos,%vec,%this); %centerPosX = getWord(%centerPos,0); %centerPosY = getWord(%centerPos,1); %centerPosZ = getWord(%centerPos,2); %pointX = getWord(%pos,0); %pointY = getWord(%pos,1); %pointZ = getWord(%pos,2); %newVecX = %centerPosX - %pointX; %newVecY = %centerPosY - %pointY; %newVecZ = %centerPosZ - %pointZ; %norm = Vector::normalize(%newVecX @ " " @ %newVecY @ " " @ %newVecZ); %zOffset = 0; if(GameBase::getDataName(%this) == PulseSensor) %zOffset = (%pointZ-%centerPosZ) * 0.5; GameBase::activateShield(%this,%sphereVec,%zOffset); } else { GameBase::setEnergy(%this,0); 
StaticShape::onDamage(%this,%type,%value - %absorb,%pos,%vec,%mom,%object); } } else { StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object); } } 

StaticShapeData FlagStand 
{ 
description = "Flag Stand"; 
shapeFile = "flagstand"; 
visibleToSensor = false; 
}; 

function calcRadiusDamage(%this,%type,%radiusRatio,%damageRatio,%forceRatio, %rMax,%rMin,%dMax,%dMin,%fMax,%fMin) 
{ 
%radius = GameBase::getRadius(%this); 
if(%radius) 
{ 
%radius *= %radiusRatio; 
%damageValue = %radius * %damageRatio; 
%force = %radius * %forceRatio; 

if(%radius > %rMax) 
%radius = %rMax; 

else 

if(%radius < %rMin) 
%radius = %rMin; 

if(%damageValue > %dMax) 
%damageValue = %dMax; 

else 

if(%damageValue < %dMin) 
%damageValue = %dMin; 

if(%force > %fMax) 
%force = %fMax; 

else 

if(%force < %fMin) 
%force = %fMin; 
GameBase::applyRadiusDamage(%type,getBoxCenter(%this), %radius, %damageValue,%force,%this); 
} 
} 

function FlagStand::onDamage() { } function Generator::onEnabled(%this) { GameBase::setActive(%this,true); } function Generator::onDisabled(%this) { GameBase::stopSequence(%this,0); GameBase::generatePower(%this, false); } function Generator::onDestroyed(%this) { Generator::onDisabled(%this); StaticShape::objectiveDestroyed(%this); calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); } function Generator::onActivate(%this) { GameBase::playSequence(%this,0,"power"); GameBase::generatePower(%this, true); } function Generator::onDeactivate(%this) { GameBase::stopSequence(%this,0); GameBase::generatePower(%this, false); } 




StaticShapeData DeployableFlagStand
{
   	description = "Deployable Flag Stand";
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	maxDamage = 3.0;
	shadowDetailMask = 4;
	mapFilter = 4;
	explosionId = debrisExpMedium;
	visibleToSensor = true;
};
function DeployableFlagstand::onDestroyed(%this)
{	
   
   StaticShape::objectiveDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "FlagStandPack"]--;
   %flag = %this.carryflag;
   if(%flag != "")
	{
		%flag.flagstand = "";
		schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	}
}






StaticShapeData TowerSwitch 
{ 
description = "Tower Control Switch"; 
className = "towerSwitch"; 
shapeFile = "tower"; 
showInventory = "false"; 
visibleToSensor = true; 
mapFilter = 4; 
mapIcon = "M_generator"; 
}; 

StaticShapeData Generator 
{ 
description = "Generator"; 
shapeFile = "generator"; 
className = "Generator"; 
sfxAmbient = SoundGeneratorPower; 
debrisId = flashDebrisLarge; 
explosionId = flashExpLarge; 
maxDamage = 4.0; 
visibleToSensor = true; 
mapFilter = 4;
mapIcon = "M_generator"; 
damageSkinData = "objectDamageSkins"; 
shadowDetailMask = 16; 
}; 









StaticShapeData SolarPanel 
{ 
description = "Solar Panel"; 
shapeFile = "solar_med"; 
className = "Generator"; 
debrisId = flashDebrisMedium; 
maxDamage = 4.0; 
visibleToSensor = true; 
mapFilter = 4; 
mapIcon = "M_generator"; 
damageSkinData = "objectDamageSkins"; 
shadowDetailMask = 16; 
explosionId = flashExpLarge; 
}; 

StaticShapeData PortGenerator 
{ 
description = "Portable Generator"; 
shapeFile = "generator_p"; 
className = "Generator"; 
debrisId = flashDebrisSmall; 
sfxAmbient = SoundGeneratorPower; 
maxDamage = 4.0; 
mapIcon = "M_generator"; 
damageSkinData = "objectDamageSkins"; 
shadowDetailMask = 16; 
explosionId = flashExpMedium; 
visibleToSensor = true; 
mapFilter = 4; 
}; 

StaticShapeData SmallAntenna 
{ 
shapeFile = "anten_small"; 
debrisId = defaultDebrisSmall; 
maxDamage = 1.0; 
damageSkinData = "objectDamageSkins"; 
shadowDetailMask = 16; 
explosionId = flashExpMedium; 
description = "Small Antenna"; 
}; 

StaticShapeData MediumAntenna 
{ 
shapeFile = "anten_med"; 
debrisId = flashDebrisSmall; 
maxDamage = 1.5; 
damageSkinData = "objectDamageSkins"; 
shadowDetailMask = 16; 
explosionId = flashExpMedium; 
description = "Medium Antenna"; 
}; 

StaticShapeData LargeAntenna 
{ 
shapeFile = "anten_lrg"; 
debrisId = defaultDebrisSmall; 
maxDamage = 1.5; 
damageSkinData = "objectDamageSkins"; 
shadowDetailMask = 16; 
explosionId = debrisExpMedium; 
description = "Large Antenna"; 
}; 

StaticShapeData ArrayAntenna 
{ 
shapeFile = "anten_lava"; 
debrisId = flashDebrisSmall; 
maxDamage = 1.5; 
damageSkinData = "objectDamageSkins"; 
shadowDetailMask = 16; 
explosionId = flashExpMedium; 
description = "Array Antenna"; 
}; 

StaticShapeData RodAntenna 
{ 
shapeFile = "anten_rod"; debrisId = defaultDebrisSmall; maxDamage = 1.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Rod Antenna"; }; StaticShapeData ForceBeacon { shapeFile = "force"; debrisId = defaultDebrisSmall; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Force Beacon"; 
}; 

StaticShapeData CargoCrate 
{ 
shapeFile = "magcargo"; debrisId = flashDebrisSmall; maxDamage = 1.0; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Cargo Crate"; }; 

StaticShapeData CargoBarrel 
{ 
shapeFile = "liqcyl"; debrisId = defaultDebrisSmall; maxDamage = 1.0; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Cargo Barrel"; }; 

StaticShapeData SquarePanel 
{ 
shapeFile = "teleport_square"; debrisId = flashDebrisSmall; maxDamage = 0.3; damageSkinData = "objectDamageSkins"; explosionId = flashExpMedium; description = "Panel"; 
}; 

StaticShapeData VerticalPanel 
{ 
shapeFile = "teleport_vertical"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; 

StaticShapeData BluePanel { shapeFile = "panel_blue"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; 

StaticShapeData YellowPanel { shapeFile = "panel_yellow"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; 

StaticShapeData SetPanel { shapeFile = "panel_set"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; 

StaticShapeData VerticalPanelB { shapeFile = "panel_vertical"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; 

StaticShapeData DisplayPanelOne { shapeFile = "display_one"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; 

StaticShapeData DisplayPanelTwo { shapeFile = "display_two"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; 

StaticShapeData DisplayPanelThree { shapeFile = "display_three"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; 

StaticShapeData HOnePanel { shapeFile = "dsply_h1"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; 

StaticShapeData HTwoPanel { shapeFile = "dsply_h2"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; 

StaticShapeData SOnePanel { shapeFile = "dsply_s1"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; 

StaticShapeData STwoPanel { shapeFile = "dsply_s2"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; 

StaticShapeData VOnePanel { shapeFile = "dsply_v1"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; 

StaticShapeData VTwoPanel { shapeFile = "dsply_v2"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; 

StaticShapeData ForceField { shapeFile = "forcefield"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Force Field"; }; 

StaticShapeData ElectricalBeam {
shapeFile = "zap"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; }; 

StaticShapeData ElectricalBeamBig { shapeFile = "zap_5"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; }; 

StaticShapeData PoweredElectricalBeam { shapeFile = "zap"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; 
}; 
function PoweredElectricalBeam::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

StaticShapeData Cactus1 { shapeFile = "cactus1"; debrisId = defaultDebrisSmall; maxDamage = 8.0; description = "Cactus";visibleToSensor = true;  }; 

StaticShapeData Cactus2 { shapeFile = "cactus2"; debrisId = defaultDebrisSmall; maxDamage = 8.0; description = "Cactus"; visibleToSensor = true; }; 

StaticShapeData Cactus3 { shapeFile = "cactus3"; debrisId = defaultDebrisSmall; maxDamage = 8.0; description = "Cactus"; visibleToSensor = true; }; 

StaticShapeData SteamOnGrass { shapeFile = "steamvent_grass"; maxDamage = 999.0; isTranslucent = "True"; description = "Steam Vent"; }; 

StaticShapeData SteamOnMud { shapeFile = "steamvent_mud"; maxDamage = 999.0; isTranslucent = "True"; description = "Steam Vent"; }; 

StaticShapeData TreeShape { shapeFile = "tree1"; maxDamage = 60.0; isTranslucent = "True"; description = "Tree"; }; 

StaticShapeData TreeShapeTwo { shapeFile = "tree2"; maxDamage = 60.0; isTranslucent = "True"; description = "Tree"; }; 

StaticShapeData SteamOnGrass2 { shapeFile = "steamvent2_grass"; maxDamage = 999.0; isTranslucent = "True"; }; 

StaticShapeData SteamOnMud2 { shapeFile = "steamvent2_mud"; maxDamage = 999.0; isTranslucent = "True"; description = "Steam Vent"; }; 

StaticShapeData PlantOne { shapeFile = "plant1"; debrisId = defaultDebrisSmall; maxDamage = 8.0; description = "Plant";visibleToSensor = true;  }; 

StaticShapeData PlantTwo { shapeFile = "plant2"; debrisId = defaultDebrisSmall; maxDamage = 8.0; description = "Plant";visibleToSensor = true;  }; 

StaticShapeData DeployableForceField 
{ 
shapeFile = "forcefield_5x5"; 
debrisId = defaultDebrisSmall; 
maxDamage = 24.50; 
visibleToSensor = true; 
isTranslucent = true; 
description = "Force Field"; 
}; 

function DeployableForceField::onDestroyed(%this) 
{ 
StaticShape::onDestroyed(%this); 
$TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldPack"]--; 
} 

StaticShapeData LargeForceField 
{ 
shapeFile = "forcefield"; 
debrisId = defaultDebrisLarge; 
maxDamage = 30.00; 
visibleToSensor = true; 
isTranslucent = true; 
description = "Force Field"; 
}; 

function LargeForceField::onDestroyed(%this) 
{ 
StaticShape::onDestroyed(%this); 
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldPack"]--; 
} 

StaticShapeData BlastWall 
{ 
shapeFile = "newdoor5"; 
maxDamage = 60.0; 
visibleToSensor = true; 
debrisId = defaultDebrisLarge; 
explosionId = debrisExpLarge;
  
}; 

function BlastWall::onDestroyed(%this) 
{ 
StaticShape::onDestroyed(%this); 
$TeamItemCount[GameBase::getTeam(%this) @ "TripwirePack"]--; 
} 

StaticShapeData BlastWall2 
{ 
shapeFile = "teleport_vertical"; 
maxDamage = 60.0; 
debrisId = defaultDebrisLarge; 
explosionId = debrisExpLarge; 
}; 

function BlastWall2::onDestroyed(%this) 
{ 
StaticShape::onDestroyed(%this); 
$TeamItemCount[GameBase::getTeam(%this) @ "TripwirePack"]--; 
} 

StaticShapeData DeployablePlatform 
{ 
shapeFile = "elevator6x6thin"; 
debrisId = defaultDebrisSmall; 
maxDamage = 25.00; 
visibleToSensor = true; 
isTranslucent = true; 
description = "Deployable Platform"; 
}; 

function DeployablePlatform::onDestroyed(%this) 
{ 
StaticShape::onDestroyed(%this); 
$TeamItemCount[GameBase::getTeam(%this) @ "PlatformPack"]--; 
} 


StaticShapeData LargePlatform 
{ 
shapeFile = "elevator16x16_octo"; 
maxDamage = 600.0; 
visibleToSensor = true; 
debrisId = defaultDebrisLarge; 
explosionId = debrisExpLarge; 
}; 

function LargePlatform::onDestroyed(%this) 
{ 
StaticShape::onDestroyed(%this); 
$TeamItemCount[GameBase::getTeam(%this) @ "LrgPltPack"]--; 
} 



StaticShapeData DeployableTree 
{ 
shapeFile = "tree1"; 
debrisId = defaultDebrisSmall; 
maxDamage = 60.50; 
visibleToSensor = false; 
isTranslucent = true; 
description = "Deployable Tree"; 
}; 

function DeployableTree::onDestroyed(%this) 
{ 
StaticShape::onDestroyed(%this); 
$TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--; 
} 

StaticShapeData DeployableTree2 
{ 
shapeFile = "tree2"; 
debrisId = defaultDebrisSmall; 
maxDamage = 60.50; 
visibleToSensor = false; 
isTranslucent = true; 
description = "Deployable Tree"; 
}; 

function DeployableTree::onDestroyed(%this) 
{ 
StaticShape::onDestroyed(%this); 
$TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--; 
} 

StaticShapeData DeployableCactus2 
{ 
shapeFile = "cactus2"; 
debrisId = defaultDebrisSmall; 
maxDamage = 8.0; 
description = "Cactus";
visibleToSensor = true;  
}; 

function DeployableCactus2::onDestroyed(%this) 
{ 
StaticShape::onDestroyed(%this); 
$TeamItemCount[GameBase::getTeam(%this) @ "PlantPack"]--; 
} 
function DeployableCactus2::onCollision(%this,%obj) 
{ 
if(getObjectType(%obj) != "Player") 
{ 
return; 
} 
if(Player::isDead(%obj)) 
{ 
return; 
} 
%c = Player::getClient(%obj); 
%playerTeam = GameBase::getTeam(%obj); 
%teleTeam = GameBase::getTeam(%this); 

if(%teleTeam != %playerTeam) { } 
if(GameBase::getDamageLevel(%obj)) 
{ 
GameBase::repairDamage(%obj,0.3); 
GameBase::playSound(%this,ForceFieldOpen,0); 
} 
$poisonTime[%c] = 0; 
} 

StaticShapeData Hologram1 
{ 
shapeFile = "larmor"; 
debrisId = defaultDebrisSmall; 
maxDamage = 0.75; 
description = "Hologram"; 
}; 

function Hologram1::onDestroyed(%this) 
{ 
StaticShape::onDestroyed(%this); 
$TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--; 
} 

StaticShapeData Hologram2 
{ 
shapeFile = "marmor"; 
debrisId = defaultDebrisSmall; 
maxDamage = 1.10; 
description = "Hologram"; 
}; 

function Hologram2::onDestroyed(%this) 
{ 
StaticShape::onDestroyed(%this); 
$TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--; 
} 

StaticShapeData Hologram3 
{ 
shapeFile = "harmor"; 
debrisId = defaultDebrisSmall; 
maxDamage = 1.5; 
description = "Hologram"; 
}; 

function Hologram1::onDestroyed(%this) 
{ 
StaticShape::onDestroyed(%this); 
$TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--; 
} 

StaticShapeData DeployableTeleport { className = "DeployableTeleport"; damageSkinData = "objectDamageSkins"; shapeFile = "flagstand"; maxDamage = 3.75; maxEnergy = 200; mapFilter = 2; visibleToSensor = true; explosionId = mortarExp; debrisId = flashDebrisLarge; lightRadius = 12.0; lightType=2; lightColor = {1.0,0.2,0.2}; }; function RemoveBeam(%b) { deleteObject(%b); } function DeployableTeleport::Destruct(%this) { } function DeployableTeleport::onDestroyed(%this) { schedule("RemoveBeam("@%this.beam1@");",1); $TeamItemCount[GameBase::getTeam(%this) @ "DeployableTeleport"]--; %teleset = nameToID("MissionCleanup/Teleports"); for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++) { if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this) { GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this); return; } } } function DeployableTeleport::onCollision(%this,%obj) { if(getObjectType(%obj) != "Player") { return; } if(Player::isDead(%obj)) { return; } %c = Player::getClient(%obj); %playerTeam = GameBase::getTeam(%obj); %teleTeam = GameBase::getTeam(%this); if(%teleTeam != %playerTeam) { if((Player::getArmor(%obj) == "spyarmor") || (Player::getArmor(%obj) == "spyfemale")) Client::SendMessage(%c,0,"Phased through enemy teleporter"); else { Client::SendMessage(%c,0,"Wrong Team"); return; } } if(%this.disabled == true) { Client::SendMessage(%c,0,"Teleport Pad is recharging"); return; } %teleset = nameToID("MissionCleanup/Teleports"); for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++) { if(GameBase::getTeam(%o) == %playerteam && %o != %this) { if((Player::getArmor(%obj) == "zarmor") || (Player::getArmor(%obj) == "zarmor")) { Client::SendMessage(%c,0,"Cannot teleport in this character class"); return; } else { GameBase::playSound(%o,ForceFieldOpen,0); GameBase::playSound(%this,ForceFieldOpen,0); GameBase::SetPosition(%obj,GameBase::GetPosition(%o)); %o.Disabled = true; %this.Disabled = true; schedule("DeployableTeleport::Reenable("@%o@");",5); schedule("DeployableTeleport::Reenable("@%this@");",5); return; } } } Client::SendMessage(%c,0,"No other pad to teleport to"); } function DeployableTeleport::Reenable(%this) { %this.disabled = false; } 

StaticShapeData DeployableSpring 
{ 
shapeFile = "flagstand"; debrisId = defaultDebrisSmall; maxDamage = 1.50; visibleToSensor = false; isTranslucent = true; description = "Deployable Spring"; 
}; 
function DeployableSpring::onDestroyed(%this) { StaticShape::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "SpringPack"]--; } function DeployableSpring::onCollision(%this,%obj) { %c = Player::getClient(%obj); if (floor(getRandom() * 30) == 0) { GameBase::playSound(%this, debrisLargeExplosion, 0); Client::SendMessage(%c, 0, "TO THE MOON, ALICE!"); %velocity = 4000; %zVec = 1700; %rnd = floor(getRandom() * 3); if (%rnd == 0) { MessageAll(0,strcat(Client::getName(%c), " takes a trip into outer space")); } else if (%rnd == 1) { MessageAll(0,strcat(Client::getName(%c), " visits the moon")); } else if (%rnd == 2) { MessageAll(0,strcat(Client::getName(%c), " falls off the edge of the earth")); } } else if (floor(getRandom() * 7) == 0) { GameBase::playSound(%this, debrisLargeExplosion, 0); Client::SendMessage(%c, 0, "K-E-R-S-P-R-O-I-N-G-g-g-g-!-!"); %velocity = 400; %zVec = 1700; } else { GameBase::playSound(%this, SoundFireMortar, 0); Client::SendMessage(%c, 0, "SPROING!"); %velocity = 200; %zVec = 600; } %jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec); Player::applyImpulse(%obj,%jumpDir); } 








StaticShapeData BlastDoorShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "newdoor5";
maxDamage = 45.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "Blast Door";
};
function BlastDoorShape::Destruct(%this)
{
BlastDoorShape::doDamage(%this);
}
function BlastDoorShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function BlastDoorShape::onDestroyed(%this)
{
BlastDoorShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}
function BlastDoorShape::onCollision(%this,%obj)
{
if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
BlastDoorShape::openDoor(%this);
return;
}
function BlastDoorShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("BlastDoorShape::closeDoor("@%this@");",4);
}
function BlastDoorShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function BlastDoorShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("BlastDoorShape::closeDoor("@%this@");",4);
}

//====================================================================

StaticShapeData LargePlatDoorShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "elevator16x16_octo";
maxDamage = 45.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "Large Platform Door";
};
function LargePlatDoorShape::Destruct(%this)
{
LargePlatDoorShape::doDamage(%this);
}
function LargePlatDoorShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function LargePlattDoorShape::onDestroyed(%this)
{
LargePlatDoorShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}
function LargePlatDoorShape::onCollision(%this,%obj)
{
if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
LargePlatDoorShape::openDoor(%this);
return;
}
function LargePlatDoorShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("LargePlatDoorShape::closeDoor("@%this@");",4);
}
function LargePlatDoorShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function LargePlatDoorShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("LargePlatDoorShape::closeDoor("@%this@");",4);
}

//===================================================================

StaticShapeData PlatformDoorShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "elevator6x6thin";
maxDamage = 45.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "Platform Door";
};
function PlatformDoorShape::Destruct(%this)
{
PlatDoorShape::doDamage(%this);
}
function PlatformDoorShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function PlatformDoorShape::onDestroyed(%this)
{
PlatformDoorShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}
function PlatformDoorShape::onCollision(%this,%obj)
{
if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
PlatformDoorShape::openDoor(%this);
return;
}
function PlatformDoorShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("PlatformDoorShape::closeDoor("@%this@");",4);
}
function PlatformDoorShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function PlatformDoorShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("PlatformDoorShape::closeDoor("@%this@");",4);
}

//=====================================================================
//=====================================================================
//=====================================================================
StaticShapeData doorthreebyfourForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_3x4";
maxDamage = 20.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "3x4 Field Door";
};
function doorthreebyfourForceFieldShape::Destruct(%this)
{
doorthreebyfourForceFieldShape::doDamage(%this);
}
function doorthreebyfourForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function doorthreebyfourForceFieldShape::onDestroyed(%this)
{
doorthreebyfourForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}
function doorthreebyfourForceFieldShape::onCollision(%this,%obj)
{
if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
doorthreebyfourForceFieldShape::openDoor(%this);
return;
}
function doorthreebyfourForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorthreebyfourForceFieldShape::closeDoor("@%this@");",4);
}
function doorthreebyfourForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function doorthreebyfourForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorthreebyfourForceFieldShape::closeDoor("@%this@");",4);
}













StaticShapeData doorfourbyfourteenForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_4x14";
maxDamage = 20.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "4x14 Field Door";
};
function doorfourbyfourteenForceFieldShape::Destruct(%this)
{
doorfourbyfourteenForceFieldShape::doDamage(%this);
}
function doorfourbyfourteenForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function doorfourbyfourteenForceFieldShape::onDestroyed(%this)
{
doorfourbyfourteenForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}
function doorfourbyfourteenForceFieldShape::onCollision(%this,%obj)
{
if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
doorfourbyfourteenForceFieldShape::openDoor(%this);
return;
}
function doorfourbyfourteenForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfourbyfourteenForceFieldShape::closeDoor("@%this@");",4);
}
function doorfourbyfourteenForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function doorfourbyfourteenForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfourbyfourteenForceFieldShape::closeDoor("@%this@");",4);
}











StaticShapeData doorfourbyeightForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_4x8";
maxDamage = 20.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "4x8 Field Door";
};
function doorfourbyeightForceFieldShape::Destruct(%this)
{
doorfourbyeightForceFieldShape::doDamage(%this);
}
function doorfourbyeightForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function doorfourbyeightForceFieldShape::onDestroyed(%this)
{
doorfourbyeightForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}
function doorfourbyeightForceFieldShape::onCollision(%this,%obj)
{
if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
doorfourbyeightForceFieldShape::openDoor(%this);
return;
}
function doorfourbyeightForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfourbyeightForceFieldShape::closeDoor("@%this@");",4);
}
function doorfourbyeightForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function doorfourbyeightForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfourbyeightForceFieldShape::closeDoor("@%this@");",4);
}








StaticShapeData doorfourbyseventeenForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_4x17";
maxDamage = 20.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "4x17 Field Door";
};
function doorfourbyseventeenForceFieldShape::Destruct(%this)
{
doorfourbyseventeenForceFieldShape::doDamage(%this);
}
function doorfourbyseventeenForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function doorfourbyseventeenForceFieldShape::onDestroyed(%this)
{
doorfourbyseventeenForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}
function doorfourbyseventeenForceFieldShape::onCollision(%this,%obj)
{
if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
doorfourbyseventeenForceFieldShape::openDoor(%this);
return;
}
function doorfourbyseventeenForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfourbyseventeenForceFieldShape::closeDoor("@%this@");",4);
}
function doorfourbyseventeenForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function doorfourbyseventeenForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfourbyseventeenForceFieldShape::closeDoor("@%this@");",4);
}











StaticShapeData doorfivebyfiveForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_5x5";
maxDamage = 20.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "5x5 Field Door";
};
function doorfivebyfiveForceFieldShape::Destruct(%this)
{
doorfivebyfiveForceFieldShape::doDamage(%this);
}
function doorfivebyfiveForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function doorfivebyfiveForceFieldShape::onDestroyed(%this)
{
doorfivebyfiveForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}
function doorfivebyfiveForceFieldShape::onCollision(%this,%obj)
{
if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
doorfivebyfiveForceFieldShape::openDoor(%this);
return;
}
function doorfivebyfiveForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfivebyfiveForceFieldShape::closeDoor("@%this@");",4);
}
function doorfivebyfiveForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function doorfivebyfiveForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfivebyfiveForceFieldShape::closeDoor("@%this@");",4);
}

//=====================================================================
//=====================================================================
//=====================================================================

















StaticShapeData newdooroneShape
{
        shapeFile = "newdoor1_r";
        debrisId = defaultDebrisLarge;
        maxDamage = 30.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Panel One";
};

function newdooroneShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "newdoorone"]--;

}






StaticShapeData newdoortwoShape
{
        shapeFile = "newdoor2_r";
        debrisId = defaultDebrisLarge;
        maxDamage = 30.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Panel Two";
};

function newdoortwoShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "newdoortwo"]--;

}









StaticShapeData newdoorthreeShape
{
        shapeFile = "newdoor3_r";
        debrisId = defaultDebrisLarge;
        maxDamage = 30.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Panel Three";
};

function newdoorthreeShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "newdoorthree"]--;

}








StaticShapeData newdoorfourShape
{
        shapeFile = "newdoor4_r";
        debrisId = defaultDebrisLarge;
        maxDamage = 30.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Panel Four";
};

function newdoorfourShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "newdoorfour"]--;

}


















StaticShapeData jailpad
{
        shapeFile = "flagstand";
        mountPoint = 2;
        mountOffset = { 0, 0, 0.1 };
        mountRotation = { 1.57, 0, 0 };
        firstPerson = false;
        maxDamage = 1.6;
        debrisId = flashDebrisSmall;
};
function jailpad::onCollision(%this,%obj)
{
    if(getObjectType(%obj) != "Player")
        {
        return;
        }

    if(Player::isDead(%obj))
        {
        return;
        }

    %c = Player::getClient(%obj);


    %playerTeam = GameBase::getTeam(%obj);
    %teleTeam = GameBase::getTeam(%this);


    if(%teleTeam == %playerTeam)
       {
      Client::SendMessage(%c,0,"You Stepped On Your Teams Jail Capture Pad");
      return;
      }

    %teleset = nameToID("MissionCleanup/jailports");
    %gclient = Client::getName(%c);
    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
    %oteam=GameBase::getTeam(%o);

             if(%oteam != %playerTeam)
                    {
                        GameBase::playSound(%o,ForceFieldOpen,0);
                        GameBase::playSound(%this,ForceFieldOpen,0);
                        GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
                        schedule("jLargeForceField::jailSesame("@%obj@");",30);
                        Client::SendMessage(%c,0,"You are a Prisoner of War for 30 seconds");

                    }
                    }


    echo("ADMINMSG: ****" @ %gclient @ " stepped on a jail pad " );

}

function jailpad::Reenable(%this)
{
        %this.disabled = false;
}

//BUILDER POLE

function LargeAntenna::onDestroyed(%this) 
	{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "BuilderPole"]--; 
	} 

//========ACCEL PAD
//XXXXXXXXXXXXXXXXX

StaticShapeData AccelPadPack
{
	className = "AccelPadPack";
	damageSkinData = "objectDamageSkins";
	shapeFile = "elevator_6x6_octagon";
	maxDamage = 3.33333;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = debrisExpLarge;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = false;
};

function AccelPadPack::Destruct(%this)
{
	AccelPadPack::doDamage(%this);
}

function AccelPadPack::doDamage(%this) {}

function AccelPadPack::onDestroyed(%this)
{
	AccelPadPack::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AccelPPack"]--;
}

function AccelPadPack::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player") {return;}
	if(Player::isDead(%obj)) {return;}
	%c = Player::getClient(%obj);
	%pteam = GameBase::getTeam(%obj);
	%oteam = GameBase::getTeam(%this);
	%diffZ=getWord(GameBase::getPosition(%obj),2)-getWord(GameBase::getPosition(%this),2);
	%tpos=GameBase::getPosition(%this);
	%opos=GameBase::getPosition(%obj);
	%tstartX=getWord(%tpos,0);
	%tstartY=getWord(%tpos,1);
	%tstartZ=getWord(%tpos,2);
	%ostartX=getWord(%opos,0);
	%ostartY=getWord(%opos,1);
	%ostartZ=getWord(%opos,2);
	%diffX=%ostartX-%tstartX;
	%diffY=%ostartY-%tstartY;
	%diffZ=%ostartZ-%tstartZ;
	if(%pteam==%oteam)
	{
		if(%obj.deployStandby!=1)
		{
			if(%diffZ>0.950)
			{
				%obj.deployStandby=1;
				%msg="<f1>Accelerator Pad : <f0>Face the direction you want to go, then jump or use your jets.  You may walk off the platform to avoid being deployed.";
				remoteEval(%c, "BP", %msg, 0);
				AccelPadPack::CheckPlayer(%this,%obj);
			}
		}
		else if(%diffZ<0.950)
		{
			remoteEval(%c, "CP", "", 0);
			%obj.deployStandby=0;
		}
	}
	return;
}

function AccelPadPack::CheckPlayer(%this,%obj)
{
	%tpos=GameBase::getPosition(%this);
	%opos=GameBase::getPosition(%obj);
	%tstartX=getWord(%tpos,0);
	%tstartY=getWord(%tpos,1);
	%tstartZ=getWord(%tpos,2);
	%ostartX=getWord(%opos,0);
	%ostartY=getWord(%opos,1);
	%ostartZ=getWord(%opos,2);

	%diffX=%ostartX-%tstartX;
	%diffY=%ostartY-%tstartY;
	%diffZ=%ostartZ-%tstartZ-0.92;
	%deploy=0;
	%recall=1;

	if(%diffZ>0.5) %deploy=1;
	if(%diffZ<0) %deploy=-1;
	
	%client = Player::getClient(%obj);
	%armor = Player::getArmor(%client);
	
	if(%deploy>0)
	{
		%armor=GameBase::getDataName(%obj);
		%mass=%armor.mass;
		%rot=GameBase::getRotation(%obj);
		%len=50;
		%zlen=50;
		%rnd=floor(getrandom()*30);
		
		if (%armor == "scoutarmor" || %armor == "scoutfemale" || %armor == "spyarmor" || %armor == "spyfemale" || %armor == "larmor" || %armor == "lfemale" || %armor == "stimarmor" || %armor == "stimfemale")
 		{
			playSound(debrisMediumExplosion,%tpos);
 		}
		if (%armor == "barmor" || %armor == "bfemale" || %armor == "aarmor" || %armor == "afemale" || %armor == "earmor" || %armor == "efemale" || %armor == "marmor" || %armor == "mfemale")
 		{
			playSound(debrisMediumExplosion,%tpos);
			%len-=10;
			%zlen-=15; 
 		}
		if (%armor == "darmor" || %armor == "jarmor" || %armor == "parmor")
 		{
			playSound(debrisMediumExplosion,%tpos);
			%len-=35;
			%zlen-=35;
 		}

		playSound(debrisSmallExplosion,%tpos);

		%vec=Vector::getFromRot(%rot,%len*%mass,%zlen*%mass);
		Player::applyImpulse(%obj,%vec);
		schedule(%obj@".deployStandby=0;",0.1);
		%recall=0;
	}
	else if(%deploy<0)
	{
		%recall=0;
		%obj.deployStandby=0;
	}
	if(%recall)
	{
		schedule("AccelPadPack::CheckPlayer("@%this@","@%obj@");",0.05);
	}
	else
	{
		remoteEval(%client, "CP", "", 0);
	}
}

//XXXXXXXXXXXXXXXXX
//====END ACCEL PAD







StaticShapeData LLargeForceField
{
        shapeFile = "forcefield";
        debrisId = defaultDebrisLarge;
        maxDamage = 200.00;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Jail Cell";
};

function LLargeForceField::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "jailpack"]--;
}
StaticShapeData JailSwitchOpen
{
        description = "The Jail";
        className = "towerSwitch";
        shapeFile = "tower";
        showInventory = "false";
        visibleToSensor = true;
        mapFilter = 4;
        mapIcon = "M_generator";
        maxDamage = 200.0;
};
function JailSwitchOpen::onCollision(%this,%obj)

{

}

StaticShapeData JailSwitchClose
{
        description = " The Jail";
        className = "towerSwitch";
        shapeFile = "tower";
        showInventory = "false";
        visibleToSensor = true;
        mapFilter = 4;
        mapIcon = "M_generator";
        maxDamage = 200.0;
};
function JailSwitchClose::onCollision(%this,%obj)

{

}


StaticShapeData jLargeForceField
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "ForceField";
maxDamage = 200.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "Jail Cell Door";
};
function jLargeForceField::Destruct(%this)
{
jLargeForceField::doDamage(%this);
}
function jLargeForceField::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function jLargeForceField::onDestroyed(%this)
{
jLargeForceField::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}
function jLargeForceField::onCollision(%this,%obj)
{
if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
jLargeForceField::openSesame(%this);
return;
}
function jLargeForceField::openSesame(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("jLargeForceField::closeSesame("@%this@");",4);
}
function jLargeForceField::closeSesame(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function jLargeForceField::openSesame(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("jLargeForceField::closeSesame("@%this@");",4);
}


function jLargeForceField::jailSesame(%obj)
{
%teleset = nameToID("MissionCleanup/releasepad");

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
    %oteam=GameBase::getTeam(%o);

             if(%oteam != GameBase::getTeam(%obj))
                    {
                    GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
                    }
                    }


}
StaticShapeData jailStand
{
        shapeFile = "flagstand";
        debrisId = defaultDebrisSmall;
        maxDamage = 200.0;
        description = "POW Release Pad";
};
function jailStand::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);


}
function jailStand::onCollision(%this,%obj)
{
Client::SendMessage(%obj,0,"You Have Been Placed In Jail. No Escaping this way! You must wait out your sentence of 30 seconds.");
}
StaticShapeData jailStandTop
{
        shapeFile = "flagstand";
        debrisId = defaultDebrisSmall;
        maxDamage = 200.0;
        description = "POW Release Pad";
};
function jailStandTop::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);


}
function jailStandTop::onCollision(%this,%obj)
{
Client::SendMessage(%obj,0,"You Have Been Released. Run Forrest Run!!!!");
}
StaticShapeData jailStandBottom
{
        shapeFile = "flagstand";
        debrisId = defaultDebrisSmall;
        maxDamage = 200.0;
        description = "POW Release Pad";
};
function jailStandBottom::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);


}
function jailStandBottom::onCollision(%this,%obj)
{
Client::SendMessage(%obj,0,"You Have Been Released. Run Forrest Run!!!!");
}














StaticShapeData AlarmKit
{
	description = "Base Alarm";
	shapeFile = "sensor_small";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundBeaconActive;
	maxDamage = 1.0;
	mapIcon = "M_marker";
	damageSkinData = "objectDamageSkins";
	visibleToSensor = true;
	triggerRadius = 10.0;
};

function AlarmKit::onCollision(%this, %object)
{
	%type = getObjectType(%object);

	if (%type == "Player" && !$pause) {
		$pause = 1;
		schedule("$pause = 0;",10,%this);
		%name = Player::getClient(%object);
		%name = Client::getName(%name);
		%team = GameBase::getTeam(%object);
		%itemTeam = GameBase::getTeam(%this);

		if(%team != %itemTeam) {
			TeamMessages(1, %itemTeam,GameBase::GetMapName(%this) @ " has been tripped! By: " @ %name @ "~wLeftMissionArea.wav");
			echo(GameBase::GetMapName(%this) @ " has been tripped! By: " @ %name);
		}
	}		
}

function AlarmKit::onAdd(%this)
{	
}
																						 
function AlarmKit::onEnabled(%this)
{
}

function AlarmKit::onDisabled(%this)
{
}

function AlarmKit::onDestroyed(%this)
{
    $TeamItemCount[GameBase::getTeam(%this) @ "BaseAlarm"]--;
	TeamMessages(1, GameBase::getTeam(%this),GameBase::GetMapName(%this) @  " has been destroyed! ~wLeftMissionArea.wav");
}

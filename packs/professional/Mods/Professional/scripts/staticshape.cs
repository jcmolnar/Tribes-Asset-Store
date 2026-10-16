//------------------------------------------------------------------------
// Generic static shapes
//------------------------------------------------------------------------

//------------------------------------------------------------------------
// Default power animation behavior for all static shapes

function StaticShape::onPower(%this,%power,%generator)
{
	if (%power) 
		GameBase::playSequence(%this,0,"power");
	else 
		GameBase::stopSequence(%this,0);
}

function StaticShape::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) 
		GameBase::playSequence(%this,0,"power");
}

function StaticShape::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
}

function StaticShape::onDestroyed(%this)
{
	GameBase::stopSequence(%this,0);
   StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 
		0.1, 250, 100); 
}

function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
   %this.lastDamageObject = %object;
   %this.lastDamageTeam = GameBase::getTeam(%object);
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		if(%name.className == Generator || %name.className == Station) { 
			%TDS = $Server::TeamDamageScale;
			%dValue = %damageLevel + %value * %TDS;
			%disable = GameBase::getDisabledDamage(%this);
			if(!$Server::TourneyMode && %dValue > %disable - 0.05) {
            if(%damageLevel > %disable - 0.05)
               return;
            else
               %dValue = %disable - 0.05;
			}
		}
	}
	GameBase::setDamageLevel(%this,%dValue);
}

function StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
   %this.lastDamageObject = %object;
   %this.lastDamageTeam = GameBase::getTeam(%object);
	if (%this.shieldStrength) {
		%energy = GameBase::getEnergy(%this);
		%strength = %this.shieldStrength;
		if (%type == $ShrapnelDamageType)
			%strength *= 0.5;
		else
			if (%type == $MortarDamageType)
				%strength *= 0.25;
			else
				if (%type == $BlasterDamageType)
					%strength *= 2.0;
		%absorb = %energy * %strength;
		if (%value < %absorb) {
			GameBase::setEnergy(%this,%energy - (%value / %strength));
			%centerPos = getBoxCenter(%this);
			%sphereVec = findPointOnSphere(getBoxCenter(%object),%centerPos,%vec,%this);
			%centerPosX = getWord(%centerPos,0);
			%centerPosY = getWord(%centerPos,1);
			%centerPosZ = getWord(%centerPos,2);

			%pointX = getWord(%pos,0);
			%pointY = getWord(%pos,1);
			%pointZ = getWord(%pos,2);

			%newVecX = %centerPosX - %pointX;
			%newVecY = %centerPosY - %pointY;
			%newVecZ = %centerPosZ - %pointZ;
			%norm = Vector::normalize(%newVecX @ " " @ %newVecY @ " " @ %newVecZ);
			%zOffset = 0;
			if(GameBase::getDataName(%this) == PulseSensor)
				%zOffset = (%pointZ-%centerPosZ) * 0.5;
			GameBase::activateShield(%this,%sphereVec,%zOffset);
		}
		else {
			GameBase::setEnergy(%this,0);
			StaticShape::onDamage(%this,%type,%value - %absorb,%pos,%vec,%mom,%object);
		}
	}
	else {
		StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	}
}

StaticShapeData FlagStand
{
   description = "Flag Stand";
	shapeFile = "flagstand";
	visibleToSensor = false;
};


function calcRadiusDamage(%this,%type,%radiusRatio,%damageRatio,%forceRatio,
	%rMax,%rMin,%dMax,%dMin,%fMax,%fMin) 
{
	%radius = GameBase::getRadius(%this);
	if(%radius) {
		%radius *= %radiusRatio;
		%damageValue = %radius * %damageRatio;
		%force = %radius * %forceRatio;
		if(%radius > %rMax)
			%radius = %rMax;
		else if(%radius < %rMin)
			%radius = %rMin;
		if(%damageValue > %dMax)
			%damageValue = %dMax; 
		else if(%damageValue < %dMin)
			%damageValue = %dMin;
		if(%force > %fMax)
			%force = %fMax; 
		else if(%force < %fMin)
			%force = %fMin;
		GameBase::applyRadiusDamage(%type,getBoxCenter(%this), %radius,
			%damageValue,%force,%this);
	}
}



function FlagStand::onDamage()
{
}

//------------------------------------------------------------------------
// Generators
//------------------------------------------------------------------------

function Generator::onEnabled(%this)
{
	GameBase::setActive(%this,true);
}

function Generator::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
}

function Generator::onDestroyed(%this)
{
	Generator::onDisabled(%this);
   	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
}

function Generator::onActivate(%this)
{
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
}

function Generator::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
}

//

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
   	maxDamage = 2.0;
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
	maxDamage = 1.0;
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
   	maxDamage = 1.6;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
};


//------------------------------------------------------------------------
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

//------------------------------------------------------------------------
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

//------------------------------------------------------------------------
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

//------------------------------------------------------------------------
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

//------------------------------------------------------------------------
StaticShapeData RodAntenna
{
	shapeFile = "anten_rod";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   description = "Rod Antenna";
};

//------------------------------------------------------------------------
StaticShapeData ForceBeacon
{
	shapeFile = "force";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   description = "Force Beacon";
};

//------------------------------------------------------------------------
StaticShapeData CargoCrate
{
	shapeFile = "magcargo";
	debrisId = flashDebrisSmall;
	maxDamage = 1.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
   description = "Cargo Crate";
};

//------------------------------------------------------------------------
StaticShapeData CargoBarrel
{
	shapeFile = "liqcyl";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   description = "Cargo Barrel";
};

//------------------------------------------------------------------------
StaticShapeData SquarePanel
{
	shapeFile = "teleport_square";
	debrisId = flashDebrisSmall;
	maxDamage = 0.3;
	damageSkinData = "objectDamageSkins";
	explosionId = flashExpMedium;
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData VerticalPanel
{
	shapeFile = "teleport_vertical";
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData BluePanel
{
	shapeFile = "panel_blue";
	debrisId = flashDebrisSmall;
	explosionId = flashExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData YellowPanel
{
	shapeFile = "panel_yellow";
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData SetPanel
{
	shapeFile = "panel_set";
	debrisId = flashDebrisSmall;
	explosionId = flashExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData VerticalPanelB
{
	shapeFile = "panel_vertical";
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData DisplayPanelOne
{
	shapeFile = "display_one";
	debrisId = flashDebrisSmall;
	explosionId = flashExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData DisplayPanelTwo
{
	shapeFile = "display_two";
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData DisplayPanelThree
{
	shapeFile = "display_three";
	debrisId = flashDebrisSmall;
	explosionId = flashExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData HOnePanel
{
	shapeFile = "dsply_h1";
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData HTwoPanel
{
	shapeFile = "dsply_h2";
	debrisId = flashDebrisSmall;
	explosionId = flashExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData SOnePanel
{
	shapeFile = "dsply_s1";
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData STwoPanel
{
	shapeFile = "dsply_s2";
	debrisId = flashDebrisSmall;
	explosionId = flashExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData VOnePanel
{
	shapeFile = "dsply_v1";
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData VTwoPanel
{
	shapeFile = "dsply_v2";
	debrisId = flashDebrisSmall;
	explosionId = flashExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData ForceField
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   description = "Force Field";
};

//------------------------------------------------------------------------
StaticShapeData ElectricalBeam
{
	shapeFile = "zap";
	maxDamage = 10000.0;
	isTranslucent = true;
    description = "Electrical Beam";
   disableCollision = true;
};

StaticShapeData ElectricalBeamBig
{
	shapeFile = "zap_5";
	maxDamage = 10000.0;
	isTranslucent = true;
    description = "Electrical Beam";
   disableCollision = true;
};

StaticShapeData PoweredElectricalBeam
{
	shapeFile = "zap";
	maxDamage = 10000.0;
	isTranslucent = true;
    description = "Electrical Beam";
   disableCollision = true;
};

//function to fade in electrical beam based on base power.
function PoweredElectricalBeam::onPower(%this, %power, %generator)
{
   if(%power)
	  GameBase::startFadeIn(%this);
   else
      GameBase::startFadeOut(%this);
}
      
//-----------------------------------------------------------------------
StaticShapeData Cactus1
{
	shapeFile = "cactus1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
   description = "Cactus";
};
//------------------------------------------------------------------------
StaticShapeData Cactus2
{
	shapeFile = "cactus2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
   description = "Cactus";
};
//------------------------------------------------------------------------
StaticShapeData Cactus3
{
	shapeFile = "cactus3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
   description = "Cactus";
};

//------------------------------------------------------------------------
StaticShapeData SteamOnGrass
{
	shapeFile = "steamvent_grass";
	maxDamage = 999.0;
	isTranslucent = "True";
   description = "Steam Vent";
};

//------------------------------------------------------------------------
StaticShapeData SteamOnMud
{
	shapeFile = "steamvent_mud";
	maxDamage = 999.0;
	isTranslucent = "True";
   description = "Steam Vent";
};

//------------------------------------------------------------------------
StaticShapeData TreeShape
{
	shapeFile = "tree1";
	maxDamage = 10.0;
	isTranslucent = "True";
   description = "Tree";
};

//------------------------------------------------------------------------
StaticShapeData TreeShapeTwo
{
	shapeFile = "tree2";
	maxDamage = 10.0;
	isTranslucent = "True";
   description = "Tree";
};

//------------------------------------------------------------------------
StaticShapeData SteamOnGrass2
{
	shapeFile = "steamvent2_grass";
	maxDamage = 999.0;
	isTranslucent = "True";
};

//------------------------------------------------------------------------
StaticShapeData SteamOnMud2
{
	shapeFile = "steamvent2_mud";
	maxDamage = 999.0;
	isTranslucent = "True";
   description = "Steam Vent";
};
//------------------------------------------------------------------------
StaticShapeData PlantOne
{
	shapeFile = "plant1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
   description = "Plant";
};

//------------------------------------------------------------------------
StaticShapeData PlantTwo
{
	shapeFile = "plant2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
   description = "Plant";
};

//------------------------------------------------------------------------

//------------------------------------------------------------------------

StaticShapeData SpringPad 
 {
   description = "Spring Pad";
   shapeFile = "elevator_4x4";
   className = "Misc";
   debrisId = defaultDebrisLarge; 
   explosionId = debrisExpLarge;
   maxDamage = 10000.0; 
   visibleToSensor = "false";
 }; 

function SpringPad::onDestroyed(%this)
  { 
   StaticShape::onDestroyed(%this); 
 }
 

function SpringPad::onCollision(%this,%obj)
 {
   %c = Player::getClient(%obj);
   if (floor(getRandom() * 30) == 0)
    { 
     GameBase::playSound(%this, debrisLargeExplosion, 0);
     %velocity = 50; %zVec = 475;
     %rnd = floor(getRandom() * 3);
     if (%rnd == 0)
      { 
      } 
     else if (%rnd == 1) 
      {
      } 
     else if (%rnd == 2) 
      { 
      }
    } 
   else if (floor(getRandom() * 7) == 0)
    { 
     GameBase::playSound(%this, debrisLargeExplosion, 0);
     %velocity = 50; %zVec = 475;
    } 
   else 
    { 
     GameBase::playSound(%this, SoundFireMortar, 0);
     %velocity = 50;
     %zVec = 475;
    } 
   %jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
   Player::applyImpulse(%obj,%jumpDir);
  } 

//------------------------------------------------------------------------

StaticShapeData LightSpringPad 
 {
   description = "LightSpring Pad";
   shapeFile = "elevator_4x4";
   className = "Misc";
   debrisId = defaultDebrisLarge; 
   explosionId = debrisExpLarge;
   maxDamage = 10000.0; 
   visibleToSensor = "false";
 }; 

function LightSpringPad::onDestroyed(%this)
  { 
   StaticShape::onDestroyed(%this); 
 }
 

function LightSpringPad::onCollision(%this,%obj)
 {
   %c = Player::getClient(%obj);
   if (floor(getRandom() * 30) == 0)
    { 
     GameBase::playSound(%this, debrisLargeExplosion, 0);
     %velocity = 275; %zVec = 275;
     %rnd = floor(getRandom() * 3);
     if (%rnd == 0)
      { 
      } 
     else if (%rnd == 1) 
      {
      } 
     else if (%rnd == 2) 
      { 
      }
    } 
   else if (floor(getRandom() * 7) == 0)
    { 
     GameBase::playSound(%this, debrisLargeExplosion, 0);
     %velocity = 275; %zVec = 275;
    } 
   else 
    { 
     GameBase::playSound(%this, SoundFireMortar, 0);
     %velocity = 275;
     %zVec = 275;
    } 
   %jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
   Player::applyImpulse(%obj,%jumpDir);
  } 

//------------------------------------------------------------------------

StaticShapeData MegaSpringPad 
 {
   description = "MegaSpring Pad";
   shapeFile = "elevator_4x4";
   className = "Misc";
   debrisId = defaultDebrisLarge; 
   explosionId = debrisExpLarge;
   maxDamage = 10000.0; 
   visibleToSensor = "false";
 }; 

function MegaSpringPad::onDestroyed(%this)
  { 
   StaticShape::onDestroyed(%this); 
 }
 

function MegaSpringPad::onCollision(%this,%obj)
 {
   %c = Player::getClient(%obj);
   if (floor(getRandom() * 30) == 0)
    { 
     GameBase::playSound(%this, debrisLargeExplosion, 0);
     %velocity = 800; %zVec = 400;
     %rnd = floor(getRandom() * 3);
     if (%rnd == 0)
      { 
      } 
     else if (%rnd == 1) 
      {
      } 
     else if (%rnd == 2) 
      { 
      }
    } 
   else if (floor(getRandom() * 7) == 0)
    { 
     GameBase::playSound(%this, debrisLargeExplosion, 0);
     %velocity = 800; %zVec = 400;
    } 
   else 
    { 
     GameBase::playSound(%this, SoundFireMortar, 0);
     %velocity = 800;
     %zVec = 400;
    } 
   %jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
   Player::applyImpulse(%obj,%jumpDir);
  } 

//------------------------------------------------------------------------

StaticShapeData DeployableForceField
{
className = "DeployableForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_5x5";
maxDamage = 2.0;
maxEnergy = 50;
mapFilter = 2;
visibleToSensor = true;
explosionId = debrisExpSmall;
debrisId = flashDebrisSmall;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
};
function DeployableForceField::Destruct(%this)
{
DeployableForceField::doDamage(%this);
}
function DeployableForceField::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170);
}
function DeployableForceField::onDestroyed(%this)
{
DeployableForceField::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "DeployableForceField"]--;
}
function DeployableForceField::onCollision(%this,%obj)
{
%c = Player::getClient(%obj);
if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
%c = Player::getClient(%obj);
%armor = Player::getArmor(%obj);
if(%fieldTeam != %playerTeam && Player::getArmor(%c)!="infarmor" && Player::getArmor(%c)!="inffarmor")
{
if(%armor == "earmor" || %armor == "efemale") Client::sendmessage(%c,1,"This field has an improved crypto.  You will not be able to hack it.");
return;
}
DeployableForceField::openSesame(%this);
return;
}
function DeployableForceField::openSesame(%this) {
if(%this.activated==False) {
GameBase::startfadeout(%this);
%this.activated=true;
schedule("DeployableForceField::openSesame("@%this@");",6);
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -500000");
schedule("GameBase::setPosition("@%this@",\""@%pos@"\");",2.75);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.35);
} else {
%this.activated=false;
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 500000");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.35);
}
}

//Minimod Stuff

// This is a MiniMod Plugin.
// This is the Base Alarm from the Redneck Slag Pack mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    BaseAlarm.ArmorData.cs
//    BaseAlarm.item.cs
//    BaseAlarm.reinitData.cs
//    BaseAlarm.staticshape.cs
//    BaseAlarm.station.cs
//
// to your MiniMod/plugins directory.

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

///-----------------------------------------------
/// Description - "Blast Wall";
/// Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

StaticShapeData BlastWallShape
{
        shapeFile = "elevator6x6thin";
        debrisId = defaultDebrisLarge;
        maxDamage = 80.0;
        visibleToSensor = true;
        //isTranslucent = true;
        description = "Portable Wall";
};

function BlastWallShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "BlastWall"]--;

}

///-----------------------------------------------
/// description = "3x4 Force Field";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------


StaticShapeData doorthreebyfourForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_3x4";
maxDamage = 40.0;
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
%armor = Player::getArmor(%obj);
if(%fieldTeam != %playerTeam)
{
	if(%armor == "earmor" || %armor == "efemale") 
		{
			%rnd = floor(getRandom() * 30);
			 if (%rnd == 0)
			{
				Client::sendmessage(%c,1,"You Unlock the Forcefield!");
				doorthreebyfourForceFieldShape::openDoor(%this);
			}
			else
			{
				Client::sendmessage(%c,1,"You fail to hack the forcefield locking crypto.");
			}
		}

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

///-----------------------------------------------
/// description = "4x14 Force Field Door";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------


StaticShapeData doorfourbyfourteenForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_4x14";
maxDamage = 40.0;
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
%armor = Player::getArmor(%obj);
if(%fieldTeam != %playerTeam)
{
	if(%armor == "earmor" || %armor == "efemale") 
		{
			%rnd = floor(getRandom() * 30);
			 if (%rnd == 0)
			{
				Client::sendmessage(%c,1,"You Unlock the Forcefield!");
				doorfourbyfourteenForceFieldShape::openDoor(%this);
			}
			else
			{
				Client::sendmessage(%c,1,"You fail to hack the forcefield locking crypto.");
			}
		}

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

///-----------------------------------------------
/// description = "4x17 Force Field Door";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------


StaticShapeData doorfourbyseventeenForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_4x17";
maxDamage = 40.0;
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
%armor = Player::getArmor(%obj);
if(%fieldTeam != %playerTeam)
{
	if(%armor == "earmor" || %armor == "efemale") 
		{
			%rnd = floor(getRandom() * 30);
			 if (%rnd == 0)
			{
				Client::sendmessage(%c,1,"You Unlock the Forcefield!");
				doorfourbyseventeenForceFieldShape::openDoor(%this);
			}
			else
			{
				Client::sendmessage(%c,1,"You fail to hack the forcefield locking crypto.");
			}
		}

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

///-----------------------------------------------
/// description = "4x8 Force Field";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------


StaticShapeData doorfourbyeightForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_4x8";
maxDamage = 40.0;
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
%armor = Player::getArmor(%obj);
if(%fieldTeam != %playerTeam)
{
	if(%armor == "earmor" || %armor == "efemale") 
		{
			%rnd = floor(getRandom() * 30);
			 if (%rnd == 0)
			{
				Client::sendmessage(%c,1,"You Unlock the Forcefield!");
				doorfourbyeightForceFieldShape::openDoor(%this);
			}
			else
			{
				Client::sendmessage(%c,1,"You fail to hack the forcefield locking crypto.");
			}
		}

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

///-----------------------------------------------
/// description = "5x5 Force Field Door";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------


StaticShapeData doorfivebyfiveForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_5x5";
maxDamage = 40.0;
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
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) 
	{
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);
	if(%fieldTeam != %playerTeam)
	{
		if(%armor == "earmor" || %armor == "efemale") 
		{
			%rnd = floor(getRandom() * 30);
			 if (%rnd == 0)
			{
				Client::sendmessage(%c,1,"You Unlock the Forcefield!");
				doorfivebyfiveForceFieldShape::openDoor(%this);
			}
			else
			{
				Client::sendmessage(%c,1,"You fail to hack the forcefield locking crypto.");
			}
		}
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

StaticShapeData Canister
{
   description = "Flame Turret Fuel";
	shapeFile = "liqcyl";
	className = "Decoration";
	debrisId = flashDebrisMedium;
	maxDamage = 0.55;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
    damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;

};



function Canister::onDestroyed(%this)
{
	GameBase::stopSequence(%this,0);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 
		0.1, 250, 100); 

	GameBase::setDamageLevel(%this.turret, 0.6);
}

// Override base class just in case.
function Canister::onPower(%this,%power,%generator)
{
	if (%power) 
		GameBase::playSequence(%this,0,"power");
	else 
		GameBase::stopSequence(%this,0);
}


function Canister::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) 
		GameBase::playSequence(%this,0,"power");
}

function Canister::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
}


///-----------------------------------------------
/// description = "Hologram";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

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

//----------------
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

///-----------------------------------------------
/// Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

StaticShapeData Springboard
{
        shapeFile = "flagstand";
        debrisId = defaultDebrisSmall;
        maxDamage = 2.00;
        visibleToSensor = false;
        isTranslucent = true;
        description = "Deployable Spring";
        visibleToSensor = true;
};

function Springboard::onDestroyed(%this)
{
        StaticShape::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "Springboard"]--;
}

function Springboard::onCollision(%this,%obj)
{
        %c = Player::getClient(%obj);
        %vecVelocity = Item::getVelocity(%obj);
        %rnd = floor(getRandom() * 55);
       if (%rnd == 1)
        {
                GameBase::playSound(%this, debrisLargeExplosion, 0);
                %HMult = 50;
                %ZMax = 200;

                %rnd = floor(getRandom() * 3);

        }
        else if (%rnd > 45)
                {
                GameBase::playSound(%this, debrisLargeExplosion, 0);

                %HMult = 2;
                %ZMax = 150;
        }
        else
        {
                GameBase::playSound(%this, SoundFireMortar, 0);

                %HMult = 2;
                %ZMax = 45;
        }
        %vecNewVelocity = GetWord(%vecVelocity, 0) * %HMult @ " " @
                          GetWord(%vecVelocity, 1) * %HMult @ " " @
                          %ZMax;
        Item::setVelocity(%obj, %vecNewVelocity);
}

//This is a MiniMod Plugin...
//This is the Teleport Pad from the ol' Renegades1.2 mod. Ported&Modified by Dewy.

StaticShapeData DeployableTeleport
{
    	className = "DeployableTeleport";
	damageSkinData = "objectDamageSkins";

	shapeFile = "flagstand";
	maxDamage = 0.75;
	maxEnergy = 200;

   	mapFilter = 2;
	visibleToSensor = true;
    	explosionId = mortarExp;
    	debrisId = flashDebrisLarge;

	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
};




				
function RemoveBeam(%b)
{
	//echo("Deleting beam " @ %b);
	deleteObject(%b);
}				

function DeployableTeleport::Destruct(%this)
{
    //CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);
}
														 
function DeployableTeleport::onDestroyed(%this)
{
      schedule("RemoveBeam("@%this.beam1@");",1);
      

   // CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);

    $TeamItemCount[GameBase::getTeam(%this) @ "DeployableTeleport"]--;

    %teleset = nameToID("MissionCleanup/Teleports");

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
        if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this)
        {
//        echo("Applying damage to mate");
        GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
		return;
        }
    }
}

function DeployableTeleport::onCollision(%this,%obj)
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

	
    if(%teleTeam != %playerTeam)
	{
        Client::SendMessage(%c,0,"Wrong team");
        return;
	}

    if(%this.disabled == true)
	{
        Client::SendMessage(%c,0,"Teleport Pad is recharging");

        return;
	}

    %teleset = nameToID("MissionCleanup/Teleports");

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
	  if(GameBase::getTeam(%o) == %playerteam && %o != %this)
        {
		if((Player::getArmor(%obj) == "harmor") || (Player::getArmor(%obj) == "darmor"))
		{
            		Client::SendMessage(%c,0,"Cannot teleport in this character class");
			return;
		}
		else
		{
			GameBase::playSound(%o,ForceFieldOpen,0);
			GameBase::playSound(%this,ForceFieldOpen,0);
            		GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
	        	%o.Disabled = true;
      	      		%this.Disabled = true;
		//	GameBase::applyDamage(%obj,$CrushDamageType,0.15,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
			//if(floor(getRandom() * 55) == 0)
			//{
                    	//	Client::SendMessage(%c,0,"Teleport phased your molecular structure wrong");
		        //	GameBase::applyDamage(%obj,$CrushDamageType,0.15,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
			//}
			//else
			//{
		        	schedule("DeployableTeleport::Reenable("@%o@");",5);
      		      		schedule("DeployableTeleport::Reenable("@%this@");",5);
			//}
			return;
		}
        }
    }
    Client::SendMessage(%c,0,"No other pad to teleport to");
}

function DeployableTeleport::Reenable(%this)
{
	%this.disabled = false;
}




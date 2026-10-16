//------------------------------------------------------------------------
// Generic static shapes
//------------------------------------------------------------------------
$pause = 0;

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

	if(%type == $SniperRifleDamageType) return;

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

	if(%type == $LaserDamageType && $TestMissionType != "D&D" && $LaserOverRide == "NO") { //RSP Makes laser damage bypasse shielding
		StaticShape::onDamage(%this,%type,%value * 2,%pos,%vec,%mom,%object);
		return;
	}

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
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 
		0.30, 250, 170); 
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

//----------------------------------------
// Redneck Slag
//----------------------------------------
// Decoy
//----------------------------------------
StaticShapeData DecoyPack
{
	shapeFile = "larmor";
	maxDamage = 2.00;
	visibleToSensor = true;
   	description = "Sniper Decoy";
	mapIcon = "M_camera";
	debrisId = defaultDebrisSmall;
};

function DecoyPack::onAdd(%this)
{
	GameBase::startFadein(%this);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Sniper Decoy");
	}
}

function DecoyPack::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableDecoyPack"]--;
}

//----------------------------------------
// The infamouse force field
//----------------------------------------
StaticShapeData ForceFieldPack
{
	shapeFile = "forcefield_5x5";
	maxDamage = 20.0;
	visibleToSensor = true;
   	description = "Force Field";
	mapIcon = "M_station";
	debrisId = defaultDebrisSmall;
	isTranslucent = true;
};

function ForceFieldPack::onAdd(%this)
{
	GameBase::startFadein(%this);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Force Field");
	}
}

function ForceFieldPack::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
    $TeamItemCount[GameBase::getTeam(%this) @ "DeployableForceFieldPack"]--;
}

// Large Force Fields

StaticShapeData LForceFieldPack
{
	shapeFile = "forcefield_4x8";
	maxDamage = 30.0;
	visibleToSensor = true;
   	description = "Large Force Field";
	mapIcon = "M_station";
	debrisId = defaultDebrisSmall;
	isTranslucent = true;
};

function LForceFieldPack::onAdd(%this)
{
	GameBase::startFadein(%this);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Large Force Field");
	}
}

function LForceFieldPack::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
    $TeamItemCount[GameBase::getTeam(%this) @ "DeployableLForceFieldPack"]--;
}

//------------------------------------------
//Base Alarm - Hightech Redneck
//------------------------------------------
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

// RSP Version of the Jump Pad - Idea from Renegades - HTR
//----------------------------------------
// The infamouse force field
//----------------------------------------
StaticShapeData DeployableJumpPad
{
	shapeFile = "elevator_4x4";
	maxDamage = 10.0;
	visibleToSensor = true;
   	description = "Jump Pad";
	mapIcon = "M_station";
	debrisId = defaultDebrisSmall;
};

function DeployableJumpPad::onAdd(%this)
{
	GameBase::startFadein(%this);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Jump Pad");
	}
}

function DeployableJumpPad::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
    $TeamItemCount[GameBase::getTeam(%this) @ "DeployableJumpPadPack"]--;
}

function DeployableJumpPad::onCollision(%this,%obj)
 {
 	if(getObjectType(%obj) != "Player")
		return;

	%cl = Player::getClient(%obj);
	%thisTeam = GameBase::getTeam(%this);
	%clTeam = GameBase::getTeam(%cl);

	if(%clTeam != %thisTeam) // Only lets members of the pad builders team use the pad
		return;

	%thisPos = GameBase::getPosition(%this);
	%plPos = GameBase::getPosition(%obj);
	%difference = Vector::sub(%thisPos, %plPos);

	if(getWord(%difference, 2) > 0) // If player is under or beside exit function
		return;
   
	GameBase::playSound(%this, JumpPadNoise, 0);
    %yVel = 550;
	%zVel = 600;
	%direction = Vector::getFromRot(GameBase::getRotation(%obj),%yVel,%zVel);
	Player::applyImpulse(%obj,%direction);
  }

// Anti Matter Turret Stand - HTR
StaticShapeData AntiMatterStand
{
	shapeFile = "anten_lrg";
	debrisId = defaultDebrisSmall;
	maxDamage = 10.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   description = "Anti Matter Turret Stand";
};

function AntiMatterStand::onDestroyed(%this) {}

function AntiMatterStand::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if($RSP::AntiMatterTurretID[%this])
		Turret::onDamage($RSP::AntiMatterTurretID[%this],%type,%value * 0.75,%pos,%vec,%mom,%object);

	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

// Sniper Pad -- Mystere
StaticShapeData SniperPad
{
    shapeFile = "elevator16x16_octo";
	maxDamage = 7.5;
	visibleToSensor = true;
    description = "Sniper Pad";
	mapIcon = "M_station";
	debrisId = defaultDebrisSmall;
};

function SniperPad::onAdd(%this)
{
	GameBase::startFadein(%this);
	if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Sniper Pad");
	}
}

function SniperPad::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
    $TeamItemCount[GameBase::getTeam(%this) @ "SniperPadPack"]--;
}

// Teleport Pad - HTR
StaticShapeData TelePad
{
	shapeFile = "flagstand";
	maxDamage = 2.5;
	visibleToSensor = true;
   	description = "Teleport Pad";
	mapIcon = "M_station";
	debrisId = defaultDebrisSmall;
};

function TelePad::onAdd(%this)
{
	GameBase::startFadein(%this);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Teleport Pad");
	}
}

function TelePad::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
    $TeamItemCount[GameBase::getTeam(%this) @ "DeployableTelePadPack"]--;

	if($RSP::TeleportPadID[GameBase::getTeam(%this) @ " " @ 0] == %this)
	{
		$RSP::TeleportPadID[GameBase::getTeam(%this) @ " " @ 0] = 0;
		TeamMessages(0, GameBase::getTeam(%this), "Teleport link has been severed");
	}
	else if($RSP::TeleportPadID[GameBase::getTeam(%this) @ " " @ 1] == %this)
	{
		$RSP::TeleportPadID[GameBase::getTeam(%this) @ " " @ 1] = 0;
		TeamMessages(0, GameBase::getTeam(%this), "Teleport link has been severed");
	}
}

function TelePad::onCollision(%this,%obj)
 {
	if(getObjectType(%obj) != "Player")
		return;

	if(Player::isDead(%obj))
		return;
	
	%cl = Player::getClient(%obj);

	if($RSP::LastTeleUser[GameBase::getTeam(%this)] == %cl)
		return;

	%thisTeam = GameBase::getTeam(%this);
	%clTeam = GameBase::getTeam(%cl);

	//if(%clTeam != %thisTeam) // Only lets members of the pad builders team use the pad
	//	return;

	%thisPos = GameBase::getPosition(%this);
	%plPos = GameBase::getPosition(%obj);
	%difference = Vector::sub(%thisPos, %plPos);

	if(getWord(%difference, 2) > 0) // If player is under or beside exit function
		return;
   
	if($RSP::TeleportPadID[GameBase::getTeam(%this) @ " " @ 0] == %this && $RSP::TeleportPadID[GameBase::getTeam(%this) @ " " @ 1] != 0)
	{
		GameBase::setPosition(%obj, GameBase::getPosition($RSP::TeleportPadID[GameBase::getTeam(%this) @ " " @ 1]));
		$RSP::LastTeleUser[GameBase::getTeam(%this)] = %cl;
		schedule("$RSP::LastTeleUser[" @ GameBase::getTeam(%this) @ "] = 0;", 2);
		return;
	}
	else if(!$RSP::TeleportPadID[GameBase::getTeam(%this) @ " " @ 1])
	{
		Client::sendMessage(%cl, 0, "Teleport link has not been established");
		return;
	}

	if($RSP::TeleportPadID[GameBase::getTeam(%this) @ " " @ 1] == %this && $RSP::TeleportPadID[GameBase::getTeam(%this) @ " " @ 0] != 0)
	{
		GameBase::setPosition(%obj, GameBase::getPosition($RSP::TeleportPadID[GameBase::getTeam(%this) @ " " @ 0]));
		$RSP::LastTeleUser[GameBase::getTeam(%this)] = %cl;
		schedule("$RSP::LastTeleUser[" @ GameBase::getTeam(%this) @ "] = 0;", 2);
		return;
	}
	else if(!$RSP::TeleportPadID[GameBase::getTeam(%this) @ " " @ 0])
	{
		Client::sendMessage(%cl, 0, "Teleport link has not been established");
		return;
	}

	GameBase::playSound($RSP::TeleportPadID[GameBase::getTeam(%this) @ " " @ 0], TelePadNoise, 0);
	GameBase::playSound($RSP::TeleportPadID[GameBase::getTeam(%this) @ " " @ 1], TelePadNoise, 0);
}
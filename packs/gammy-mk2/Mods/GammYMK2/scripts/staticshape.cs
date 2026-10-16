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

//--------------------------------------------------------------------------
StaticShapeData DeployableForceField
{
	shapeFile = "forcefield_5x5";
	debrisId = defaultDebrisSmall;
	maxDamage = 5.50;
	visibleToSensor = true;
	isTranslucent = true;
   	description = "Force Field";
};

MoveableData DoorFive
{
	shapeFile = "newdoor5";
	className = "Door";
	maxDamage = 3;
	debrisId = defaultDebrisLarge;
	speed = 10;
	sfxStart = SoundDoorOpen;
	sfxStop = SoundDoorClose;
	side = "single";
	triggerRadius = 4;
	explosionId = debrisExpLarge;
   isPerspective = true;
	displace = false;
	blockBackward = false;
};

MoveableData DoorForceField
{
	shapeFile = "forcefield";
	className = "Door";
	maxDamage = 10000;
	debrisId = defaultDebrisLarge;
	speed = 100;
	sfxStop = ForceFieldClose;
	side = "single";
	triggerRadius = 4;
	explosionId = debrisExpLarge;
	isTranslucent = true;
	displace = false;
	blockBackward = false;
};

MoveableData DoorForceField3x4
{
	shapeFile = "forcefield_3x4";
	className = "Door";
	maxDamage = 10000;
	debrisId = defaultDebrisLarge;
	speed = 100;
	sfxStop = ForceFieldClose;
	side = "single";
	triggerRadius = 4;
	explosionId = debrisExpLarge;
	isTranslucent = true;
	displace = false;
	blockBackward = false;
};

MoveableData DoorForceField4x17
{
	shapeFile = "forcefield_4x17";
	className = "Door";
	maxDamage = 10000;
	debrisId = defaultDebrisLarge;
	speed = 100;
	sfxStop = ForceFieldClose;
	side = "single";
	triggerRadius = 4;
	explosionId = debrisExpLarge;
	isTranslucent = true;
	displace = false;
	blockBackward = false;
};

MoveableData DoorForceField4x14
{
	shapeFile = "forcefield_4x14";
	className = "Door";
	maxDamage = 10000;
	debrisId = defaultDebrisLarge;
	speed = 100;
	sfxStop = ForceFieldClose;
	side = "single";
	triggerRadius = 4;
	explosionId = debrisExpLarge;
	isTranslucent = true;
	displace = false;
	blockBackward = false;
};

MoveableData DoorForceField4x8
{
	shapeFile = "forcefield_4x8";
	className = "Door";
	maxDamage = 10000;
	debrisId = defaultDebrisLarge;
	speed = 100;
	sfxStop = ForceFieldClose;
	side = "single";
	triggerRadius = 4;
	explosionId = debrisExpLarge;
	isTranslucent = true;
	displace = false;
	blockBackward = false;
};

MoveableData DoorForceField5x5
{
	shapeFile = "forcefield_5x5";
	className = "Door";
	maxDamage = 10000;
	debrisId = defaultDebrisLarge;
	speed = 100;
	sfxStop = ForceFieldClose;
	side = "single";
	triggerRadius = 4;
	explosionId = debrisExpLarge;
	isTranslucent = true;
	displace = false;
	blockBackward = false;
};

MoveableData DoorDiagonal
{
	shapeFile = "door_4x4_diagonal";
	className = "Door";
	maxDamage = 3;
	debrisId = defaultDebrisLarge;
	speed = 10;
	sfxStart = SoundDoorOpen;
	sfxStop = SoundDoorClose;
	side = "single";
  //	triggerRadius = 3;
	explosionId = debrisExpLarge;
   isPerspective = true;
	displace = false;
	blockBackward = false;
};

$ForceFields["DoorForceField"] = 1;
$ForceFields["DoorForceField3x4"] = 1;
$ForceFields["DoorForceField4x17"] = 1;
$ForceFields["DoorForceField4x8"] = 1;
$ForceFields["DoorForceField5x5"] = 1;
$ForceFields["DoorForceField4x14"] = 1;
function Door::onAdd(%this)
{
	if(!GameBase::isPowered(%this))
		Door::onPower(%this,"False");   

	%this.closeTime = getSimTime();
 	%this.fadeTime	 = getSimTime();
 	%this.faded = "";
}

function Door::onNewPath(%this)
{
	%numPoints = Moveable::getWaypointCount(%this);
	%name = GameBase::getDataName(%this);
	if(%numPoints <= 2 && (%name.side=="left" || %name.side == "right"))
		%name.side = "single";
	if(%name.side == "single") {
		%center = %numPoints-1;
		Moveable::setWaypoint(%this,%center);
	}
	else {
		%center = floor(%numPoints/2);
		Moveable::setWaypoint(%this,%center);
	}
	%this.center = %center;
}

function Door::onEnabled(%this)
{
	GameBase::setActive(%this,true);
	if(%this.center != "" && GameBase::isPowered(%this)) { 
		%this.closeTime = getSimTime() + 1;
		Door::closeCheck(%this);
	}
	else
		Door::onPower(%this,"False");   
}

function Door::trigger(%this)
{
	%waypoint = Moveable::getPosition(%this);
	if((%waypoint != 0 && %waypoint != Moveable::getWaypointCount(%this)-1) || ((GameBase::getDataName(%this)).side == "single" && %waypoint != 0)) {
		%this.status = "open";
		if(!%this.triggerOpen == "")
			%this.playerTrigger = 1; 
		Door::onMove(%this);	
	}
}

function Door::onPower(%this, %state, %generator)
{
	if(%state) { 
		if(Moveable::getPosition(%this) != %this.center && %this.center != "") {
			%this.status = "close";
			%this.closeTime = getSimTime() + 1;
			Door::closeCheck(%this);
		}
	}
	else { 
		%this.status = "open";
		Door::onMove(%this, 1);
	}
}

function Door::onFirst(%this)
{
	if(%this.triggerOpen == "") {
		%this.status = "close";
		%this.closeTime = getSimTime() + 3;
		Door::closeCheck(%this);
	}
	else if(%this.playerTrigger) {
		%this.status = "close";
		%this.closeTime = getSimTime() + 1;
		Door::closeCheck(%this);
		%this.playerTrigger = "";
	}	
}

function Door::onLast(%this)
{
	if((GameBase::getDataName(%this)).side != "single") {
		if(%this.triggerOpen == "") {
			%this.status = "close";
			%this.closeTime = getSimTime() + 3;
			Door::closeCheck(%this);
		}
		else if(%this.playerTrigger) {
			%this.status = "close";					
			%this.closeTime = getSimTime() + 1;
			Door::closeCheck(%this);
			%this.playerTrigger = "";
		}	
	}
}

function Door::onWaypoint(%this)
{
	if(Moveable::getPosition(%this) == %this.center && %this.status == "close") 
		%this.triggerTrigger = "";
}

function Door::onMove(%this, %forceClose)
{
	if($ForceFields[GameBase::getDataName(%this)] != "" && %this.faded == "" && %this.status == "open") {
		GameBase::startFadeOut(%this);
		%time = getSimTime() - %this.fadeTime;
		if(%time > 2.5)
			%time = 2.5;
		%this.faded = 1;
		if(%forceClose != "")
			schedule("Door::onMove(" @ %this @ "," @ %forceClose @ ");",%time,%this);
		else
			schedule("Door::onMove(" @ %this @ ");",%time,%this);
		schedule("GameBase::playSound(" @ %this @ ",ForceFieldOpen,0);",(%time/2),%this);
		return;		
	} 
	if((GameBase::isActive(%this) && GameBase::isPowered(%this)) || %forceClose != "") {
		if(%this.status == "open") {
			if((GameBase::getDataName(%this)).side == "left")
				Moveable::moveToWaypoint(%this,(Moveable::getWaypointCount(%this)-1));				
			else
				Moveable::moveToWaypoint(%this,0);				
	 	}
		else { 
			Moveable::moveToWaypoint(%this,%this.center);				
		}
	}
	if($ForceFields[GameBase::getDataName(%this)] != "" && %this.status == "close" && !%this.faded == "" && GameBase::isPowered(%this)) {
		GameBase::startFadeIn(%this);
	 	%this.faded="";
		%this.fadeTime = getSimTime();
	}
}

function Door::onCollision(%this, %object)
{
%armor = Player::getArmor(%object);
	if(!Player::isDead(%object) && getObjectType(%object) == "Player") 
		if (GameBase::isActive(%this) && GameBase::isPowered(%this) && %this.faded == "")  
			if(GameBase::getTeam(%this) == GameBase::getTeam(%object) || GameBase::getTeam(%this) == -1 || %this.noTeam != "" || (%armor == "spyarmor") || (%armor == "spyfemale") )
				if((%this.triggerOpen == "" || %this.triggerTrigger) ) 
					Door::trigger(%this);
}

function Door::onBlocker(%this,%obj)
{
	GameBase::applyDamage(%obj,$CrushDamageType,0.01,
		GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}

function Door::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = $Server::TeamDamageScale;
//	GameBase::setDamageLevel(%this,%damageLevel + %value * 0.01 * %TDS * $DoorScale[%type]);
	GameBase::setDamageLevel(%this,%damageLevel + %value * $DoorScale[%type]);
}

function Door::onDisabled(%this)
{
	GameBase::setActive(%this,false);
   Moveable::stop(%this);
}

function Door::onDestroyed(%this)
{
	GameBase::setActive(%this,false); 		
   Moveable::stop(%this);
}	

function Door::closeCheck(%this)
{
	if (getSimTime() >= %this.closeTime)
		Door::onMove(%this);
	else
		schedule("Door::closeCheck(" @ %this @ ");",1,%this);
}

function Door::onTrigEnter(%this,%object,%trigger)
{
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object) || GameBase::getTeam(%this) == -1 || %this.noTeam != "" ) {
		%this.status = "open";
		Door::onMove(%this);
	}
}

function Door::onTrigLeave(%this,%object,%trigger)
{
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object) || GameBase::getTeam(%this) == -1 || %this.noTeam != "" ) {
		%this.status = "close";
		%this.triggerTrigger = 1;
		Door::onMove(%this);
	}
}

function Door::onTrigger(%this,%object,%trigger)
{

}

function DeployableForceField::onCollision(%this,%obj)
{
	echo ("Open Damnit!");
	%clientId = Player::getClient(%obj);
	%armor = Player::getArmor(%clientId);
	if(%this.isactive==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this) || ( (%armor == "spyarmor") || (%armor == "spyfemale") ) )
	{	
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		DeployableForceField::Open(%this);
		return;
	}
	echo ("Wrong Team");
	return;
}
function DeployableForceField::Open(%this)
{
	echo ("Opening");
	if(%this.isactive == "false")
	{
		GameBase::startfadeout(%this);
		%this.isactive=true;
		schedule("LargeForceField::Open("@%this@");",4);
		%pos=GameBase::getPosition(%this);
		%pos=Vector::add(%pos,"0 0 -5000");
		schedule("GameBase::setPosition("@%this@",\""@%pos@"\");",2.75);
		schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.35);
	}
	else
	{
		%this.isactive = "false";
		%pos=GameBase::getPosition(%this);
		%pos=Vector::add(%pos,"0 0 5000");
		GameBase::setPosition(%this,%pos);
		GameBase::startfadein(%this);
		schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.35);
	}
}


function DeployableForceField::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldPack"]--;
	
}


StaticShapeData SpringPad
 {
   description = "Spring Pad";
   shapeFile = "flagstand";
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
     %velocity = 500; %zVec = 575;
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
     %velocity = 800; %zVec = 875;
    } 
   else 
    { 
     GameBase::playSound(%this, SoundFireMortar, 0);
     %velocity = 600;
     %zVec = 675;
    } 
   %jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
   Player::applyImpulse(%obj,%jumpDir);
  } 

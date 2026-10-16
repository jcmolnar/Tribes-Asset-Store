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

// ****

StaticShapeData AirPlatform
{
	shapeFile = "elevator6x6thin"; 
	debrisId = defaultDebrisMedium;
	maxDamage = 2.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "S_Air Plat";
      description = "Air Platform";
};

function AirPlatform::onDestroyed(%this)
{
	
   StaticShape::objectiveDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "AirPlatformPack"]--;
}

StaticShapeData LargeAirPlatform
{
	shapeFile = "elevator16x16_octo"; 
	debrisId = defaultDebrisLarge;
	maxDamage = 15.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	mapFilter = 4;
      description = "Large Air Platform";
};

function LargeAirPlatform::onDestroyed(%this)
{	
   StaticShape::objectiveDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "LargeAirPlatPack"]--;
}

StaticShapeData DeployableWall
{
	shapeFile = "newdoor5";
	debrisId = defaultDebrisSmall;
	maxDamage = 6.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
 	description = "Deployable Wall";
};

function DeployableWall::onDestroyed(%this)
{
	
   StaticShape::objectiveDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "DeployableWallPack"]--;
}
//><<><><><><><>><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><DEPLOYABLE DOOR><><><><
///*
//StaticShapeData DoorFourLeft1
//{
//	dataBlock = "DoorFourLeft";
//	shapeFile = "newdoor5";
//	className = "Door";
//	description = "Door";
//	maxDamage = 3;
//	maxEnergy = 700;
//	mapFilter = 2;
//	debrisId = defaultDebrisLarge;
//	speed = 10;
//	sfxStart = SoundDoorOpen;
//	sfxStop = SoundDoorClose;
//	visibleToSensor = true;
//	triggerRadius = 4;
//	side = "left";
//	Status = "close";
//	explosionId = debrisExpLarge;
//   	isPerspective = true;
//	displace = false;
//	blockForward = false;
//	center = "1";
//	fadeTime = "444.396";
//	closeTime = "986.742";
//};
//
//
//
//function Door::onNewPath(%this)
//{
//	%numPoints = Moveable::getWaypointCount(%this);
//	%name = GameBase::getDataName(%this);
//	if(%numPoints <= 2 && (%name.side=="left" || %name.side == "right"))
//		%name.side = "single";
//	if(%name.side == "single") {
//		%center = %numPoints-1;
//		Moveable::setWaypoint(%this,%center);
//	}
//	else {
//		%center = floor(%numPoints/2);
//		Moveable::setWaypoint(%this,%center);
//	}
//	%this.center = %center;
//}
//
//function Door::onEnabled(%this)
//{
//	GameBase::setActive(%this,true);
//	if(%this.center != "") { 
//		%this.closeTime = getSimTime() + 1;
//		Door::closeCheck(%this);
//	}
//	
//}
//
//function Door::trigger(%this)
//{
//	%waypoint = Moveable::getPosition(%this);
//	if((%waypoint != 0 && %waypoint != Moveable::getWaypointCount(%this)-1) || ((GameBase::getDataName(%this)).side == "single" && %waypoint != 0)) {
//		%this.status = "open";
//		if(!%this.triggerOpen == "")
//			%this.playerTrigger = 1; 
//		Door::onMove(%this);	
//	}
//}
//
//
//function Door::onFirst(%this)
//{
//	if(%this.triggerOpen == "") {
//		%this.status = "close";
//		%this.closeTime = getSimTime() + 3;
//		Door::closeCheck(%this);
//	}
//	else if(%this.playerTrigger) {
//		%this.status = "close";
//		%this.closeTime = getSimTime() + 1;
//		Door::closeCheck(%this);
//		%this.playerTrigger = "";
//	}	
//}
//
//function Door::onLast(%this)
//{
//	if((GameBase::getDataName(%this)).side != "single") {
//		if(%this.triggerOpen == "") {
//			%this.status = "close";
//			%this.closeTime = getSimTime() + 3;
//			Door::closeCheck(%this);
//		}
//		else if(%this.playerTrigger) {
//			%this.status = "close";					
//			%this.closeTime = getSimTime() + 1;
//			Door::closeCheck(%this);
//			%this.playerTrigger = "";
//		}	
//	}
//}
//
//function Door::onWaypoint(%this)
//{
//	if(Moveable::getPosition(%this) == %this.center && %this.status == "close") 
//		%this.triggerTrigger = "";
//}
//
//function Door::onMove(%this, %forceClose)
//{
//	if($ForceFields[GameBase::getDataName(%this)] != "" && %this.faded == "" && %this.status == "open") {
//		GameBase::startFadeOut(%this);
//		%time = getSimTime() - %this.fadeTime;
//		if(%time > 2.5)
//			%time = 2.5;
//		%this.faded = 1;
//		if(%forceClose != "")
//			schedule("Door::onMove(" @ %this @ "," @ %forceClose @ ");",%time,%this);
//		else
//			schedule("Door::onMove(" @ %this @ ");",%time,%this);
//		schedule("GameBase::playSound(" @ %this @ ",ForceFieldOpen,0);",(%time/2),%this);
//		return;		
//	} 
//	if((GameBase::isActive(%this) && GameBase::isPowered(%this)) || %forceClose != "") {
//		if(%this.status == "open") {
//			if((GameBase::getDataName(%this)).side == "left")
//				Moveable::moveToWaypoint(%this,(Moveable::getWaypointCount(%this)-1));				
//			else
//				Moveable::moveToWaypoint(%this,0);				
//	 	}
//		else { 
//			Moveable::moveToWaypoint(%this,%this.center);				
//		}
//	}
//	if($ForceFields[GameBase::getDataName(%this)] != "" && %this.status == "close" && !%this.faded == "" && GameBase::isPowered(%this)) {
//		GameBase::startFadeIn(%this);
//	 	%this.faded="";
//		%this.fadeTime = getSimTime();
//	}
//}
//
//function Door::onCollision(%this, %object)
//{
//	if(!Player::isDead(%object) && getObjectType(%object) == "Player") 
//		if (GameBase::isActive(%this)&& %this.faded == "")  
//			if(GameBase::getTeam(%this) == GameBase::getTeam(%object) || GameBase::getTeam(%this) == -1 || %this.noTeam != "" ) 
//				if((%this.triggerOpen == "" || %this.triggerTrigger) ) 
//					Door::trigger(%this);
//}
//
//function Door::onBlocker(%this,%obj)
//{
//	GameBase::applyDamage(%obj,$CrushDamageType,0.01,
//		GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
//}
//
//function Door::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
//{
//	%damageLevel = GameBase::getDamageLevel(%this);
//	%TDS= 1;
//	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
//		%TDS = $Server::TeamDamageScale;
////	GameBase::setDamageLevel(%this,%damageLevel + %value * 0.01 * %TDS * $DoorScale[%type]);
//	GameBase::setDamageLevel(%this,%damageLevel + %value * $DoorScale[%type]);
//}
//
//function Door::onDisabled(%this)
//{
//	GameBase::setActive(%this,false);
//   Moveable::stop(%this);
//}
//
//function Door::onDestroyed(%this)
//{
//	GameBase::setActive(%this,false); 		
//   Moveable::stop(%this);
//}	
//
//function Door::closeCheck(%this)
//{
//	if (getSimTime() >= %this.closeTime)
//		Door::onMove(%this);
//	else
//		schedule("Door::closeCheck(" @ %this @ ");",1,%this);
//}
//
//function Door::onTrigEnter(%this,%object,%trigger)
//{
//	if(GameBase::getTeam(%this) == GameBase::getTeam(%object) || GameBase::getTeam(%this) == -1 || %this.noTeam != "" ) {
//		%this.status = "open";
//		Door::onMove(%this);
//	}
//}
//
//function Door::onTrigLeave(%this,%object,%trigger)
//{
//	if(GameBase::getTeam(%this) == GameBase::getTeam(%object) || GameBase::getTeam(%this) == -1 || %this.noTeam != "" ) {
//		%this.status = "close";
//		%this.triggerTrigger = 1;
//		Door::onMove(%this);
//	}
//}
//
//function Door::onTrigger(%this,%object,%trigger)
//{
//
//}
//*/
//><<><><><><><>><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><DEPLOYABLE DOOR><><><><

StaticShapeData SmallForceField
{
className = "SmallForceField";
damageSkinData = "objectDamageSkins";
description = "Small Force Field";
shapeFile = "forcefield_5x5";
maxDamage = 2.75;
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
};
function SmallForceField::Destruct(%this)
{
SmallForceField::doDamage(%this);
}
function SmallForceField::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100); 
}
function SmallForceField::onDestroyed(%this)
{
SmallForceField::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "SmallForceField"]--;
}
function SmallForceField::onCollision(%this,%obj)
{
%c = Player::getClient(%obj);
if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
SmallForceField::openSesame(%this);
return;
}
function SmallForceField::openSesame(%this) {
if(%this.activated==False) {
GameBase::startfadeout(%this);
%this.activated=true;
schedule("SmallForceField::openSesame("@%this@");",6);
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -5000");
schedule("GameBase::setPosition("@%this@",\""@%pos@"\");",2.75);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.35);
} else {
%this.activated=false;
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 5000");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.35);
}
}


StaticShapeData LargeForceField
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "ForceField_4x8";
maxDamage = 4.0;
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
};
function LargeForceField::Destruct(%this)
{
LargeForceField::doDamage(%this);
}
function LargeForceField::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100); 
}
function LargeForceField::onDestroyed(%this)
{
LargeForceField::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}
function LargeForceField::onCollision(%this,%obj)
{
if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
LargeForceField::openSesame(%this);
return;
}
function LargeForceField::openSesame(%this) {
if(%this.activated==False) {
GameBase::startfadeout(%this);
%this.activated=true;
schedule("LargeForceField::openSesame("@%this@");",6);
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -5000");
schedule("GameBase::setPosition("@%this@",\""@%pos@"\");",2.75);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.35);
} else {
%this.activated=false;
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 5000");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.35);
}
}
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
   // if this.something has a flag, schedule a return
  %flag = %this.carryflag;
   if(%flag)
	{
		%flag.flagstand = "";
		schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	}
}

function DeployableFlagstand::onCollision(%this,%object)
{
   if(%object.enterTime > getSimTime() - 3)
	return;
   %standTeam = GameBase::getTeam(%this);
   %playerTeam = GameBase::getTeam(%object);
   %playerClient = Player::getClient(%object);

   if(%standTeam == -1 || getObjectType(%object) != "Player" || %playerTeam != %standTeam || %object.carryflag == "")
      return;

   %flag = %object.carryFlag;
   %flagTeam = GameBase::getTeam(%flag);
   if(%flagTeam != %playerteam && %this.carryflag != "")
	return;

   %this.carryflag = %flag; // ****
   %flag.carrier = -1;
   Item::hide(%flag, false);
   GameBase::setPosition(%flag, GameBase::getPosition(%this)); 
   playSound(SoundPickupBackpack, GameBase::getPosition(%this)); // **** 

   %flag.flagStand = %this;
   Player::setItemCount(%object, Flag, 0);
   %object.carryFlag = "";
   %playerClient = Player::getClient(%object);
   Flag::clearWaypoint(%playerClient, true);

   MessageAllExcept(%playerClient, 0,"The " @ %playerteam @ " flag has been moved to a new position");
   Client::sendMessage(%playerClient, 0, "You moved your flag.");
   %object.enterTime = getSimTime();
}
StaticShapeData UBoPTK::Block1
{
className = "StaticShape";
damageSkinData = "objectDamageSkins";
shapeFile = "newdoor5";
maxDamage = 10000;
maxEnergy = 20000;
mapFilter = 2;
visibleToSensor = false;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
};
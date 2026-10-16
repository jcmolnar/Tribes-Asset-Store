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
	if (%this.className == "RiftTech")
		calcRadiusDamage(%this, $DebrisDamageType, 10.5, 1.0, 100, 13, 2, 0.40, 0.1, 250, 100);
	else
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
//	if(%this.className == "Generator")
//	{
//		%killer = %this.lastDamageObject;
//		echo("TALON:"@ %killer @" killed a generator");
//		%client=Player::getClient(%killer);
//		if(%client)
//		{
//			Client::sendMessage(%this.lastDamageObject,3,"You recieve 3 points for destroying an enemy generator!");
//			%this.lastDamageObject.score += 2;
//		}
//	}
}

function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%name = GameBase::getDataName(%this);
	if(%name == Rift)
		return;
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		if(%name.className == Generator || %name.className == Station)
		{
			%TDS = $Server::TeamDamageScale;
			%dValue = %damageLevel + %value * %TDS;
			%disable = GameBase::getDisabledDamage(%this);
			if(!$Server::TourneyMode && %dValue > %disable - 0.05)
			{
				if(%damageLevel > %disable - 0.05)
					return;
				else
			               %dValue = %disable - 0.05;
			}
		}
	}
	// Generator shutdown by EMP -=Talon Hawk=-
	if(%name.className == Generator && %type == $EMPDamageType && GameBase::getTeam(%this) != GameBase::getTeam(%object) && %this.EMPed == 0)
	{
		%this.EMPed = 1;
		Generator::onDisabled(%this);
		schedule("Generator::onActivate(" @ %this @ ");",20);
		Client::sendMessage(%object,1,"SNSR-CPU: Enemy generator disabled for 20 seconds");
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


function calcRadiusDamage(%this,%type,%radiusRatio,%damageRatio,%forceRatio,%rMax,%rMin,%dMax,%dMin,%fMax,%fMin) 
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
		GameBase::applyRadiusDamage(%type,getBoxCenter(%this),%radius,%damageValue,%force,%this);
	}
}

function calcOwnedRadiusDamage(%this,%type,%radiusRatio,%damageRatio,%forceRatio,%rMax,%rMin,%dMax,%dMin,%fMax,%fMin,%source) 
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
		GameBase::applyRadiusDamage(%type,getBoxCenter(%this),%radius,%damageValue,%force,%source);
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
	calcRadiusDamage(%this, $DebrisDamageType, 5.5, 1.0, 95, 13, 2, 0.40, 0.1, 250, 100);
}

function Generator::onActivate(%this)
{
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
	%this.EMPed = 0;
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
// My stuff: -=TalonHawk=-
//------------------------------------------------------------------------

function FFHeal(%this,%strength)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	if(%damageLevel > 0)
	{
		if(%strength == 2)
			%dValue = %damageLevel - 0.3;
		else
			%dValue = %damageLevel - 0.15;
		GameBase::setDamageLevel(%this,%dValue);
		schedule("FFHeal(" @ %this @ ");", 4);
	}
}

// Platform: -=TalonHawk=-
StaticShapeData PlasWall
{
	shapeFile = "elevator6X6thin";
	debrisId = energydie;
	maxDamage = 2;
	visibleToSensor = true;
	isTranslucent = false;
   	description = "Plasma Platform";
};

function PlasWall::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "PlasWallPack"]--;
}

function PlasWall::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	GameBase::setDamageLevel(%this,%dValue);
	schedule("FFHeal(" @ %this @ ");", 5);
}

// Forcefield: -=TalonHawk=-
StaticShapeData ForceWall
{
	shapeFile = "forcefield_4x8";
	debrisId = energydie;
	maxDamage = 5.25;
	visibleToSensor = true;
	isTranslucent = true;
   	description = "Forcefield";
};

function ForceWall::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "ForceWallPack"]--;
}

function ForceWall::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type != $EMPDamageType)
	{
		%damageLevel = GameBase::getDamageLevel(%this);
		%dValue = %damageLevel + %value;
		%this.lastDamageObject = %object;
		%this.lastDamageTeam = GameBase::getTeam(%object);
		GameBase::setDamageLevel(%this,%dValue);
		if(%type == $PlasmaDamageType)
			%strength = 2;
		else
			%strength = 1;
		schedule("FFHeal(" @ %this @ "," @ %strength @ ");", 8);
	}
	else
	{
		%curlvl = GameBase::getDamageLevel(%this);
		%dlevel = %curlvl + 2;
		GameBase::setDamageLevel(%this,%dlevel);
	}
}

StaticShapeData MassForceWall
{
	shapeFile = "forcefield_4x17";
	debrisId = energydie;
	maxDamage = 9.25;
	visibleToSensor = true;
	isTranslucent = true;
   	description = "Large Forcefield";
};

function MassForceWall::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "MassWallPack"]--;
}

function MassForceWall::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type != $EMPDamageType)
	{
		%damageLevel = GameBase::getDamageLevel(%this);
		%dValue = %damageLevel + %value;
		%this.lastDamageObject = %object;
		%this.lastDamageTeam = GameBase::getTeam(%object);
		GameBase::setDamageLevel(%this,%dValue);
		if(%type == $PlasmaDamageType)
			%strength = 2;
		else
			%strength = 1;
		schedule("FFHeal(" @ %this @ "," @ %strength @ ");", 8);
	}
	else
	{
		%curlvl = GameBase::getDamageLevel(%this);
		%dlevel = %curlvl + 2;
		GameBase::setDamageLevel(%this,%dlevel);
	}
}

// DeployableTree: -=TalonHawk=-
StaticShapeData DTree
{
	shapeFile = "tree2";
	maxDamage = 10.0;
	isTranslucent = "True";
   description = "Tree";
};

// Deployable Dude: -=TalonHawk=-
StaticShapeData DMan
{
	shapeFile = "larmor";
	maxDamage = 1.72;
	visibleToSensor = true;
	description = "Decoy";
	debrisId = defaultDebrisSmall;
	mapIcon = "M_player";
};

// Deployable Heavy Dude: -=TalonHawk=-
StaticShapeData DHMan
{
	shapeFile = "harmor";
	maxDamage = 3.85;
	visibleToSensor = true;
	description = "Decoy";
	debrisId = defaultDebrisLarge;
	mapIcon = "M_player";
};

// The deployable Teleporter
StaticShapeData Rift
{
	damageSkinData = "objectDamageSkins";
	className = "RiftTech";

	shapeFile = "mineammo";
	maxDamage = 1.25;
	maxEnergy = 200;

   	mapFilter = 2;
	visibleToSensor = true;
	explosionId = LargeShockwave;
	debrisId = defaultDebrisSmall;
	sfxAmbient = SoundTeleportPower;
	mapIcon = "M_player";

	lightType = 2;   // Pulsing
	lightRadius = 10;
	lightTime = 1.5;
	lightColor = { 0.4, 0.4, 1.0 };
};
														 
function Rift::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "TeleporterPack"]--;
	deleteObject(%this.beam);
}

// Deployable Teleport - How it works
function Rift::onCollision(%this,%object)
{
	if(getObjectType(%object) == "Player")
	{
		%client = Player::getClient(%object);
		%playerteam = GameBase::getTeam(%object);
		%teleteam = GameBase::getTeam(%this);
		if(%playerteam == %teleteam)
		{
			if($RuneLoc[%teleteam] != 0)
			{
				if(Player::getArmor(%object) != "tarmor")
				{
					Client::SendMessage(%client,3,"RFT-OBC: Activating link up to wormhole on other end.");
					GameBase::playSound(%this,SoundTeleportOpen,0);
					GameBase::playSound(%rune,SoundTeleportOpen,0);
					%newspot = $RuneLoc[%teleteam];
					GameBase::SetPosition(%object, %newspot);
				}
				else
					Client::SendMessage(%client,0,"TPT-CPU: Energy Overload - Energons cannot use teleporters");
			}
			else
				Client::SendMessage(%client,0,"TPT-CPU: No position is marked for teleportation yet");
		}
		else
			Client::SendMessage(%client,1,"TPT-CPU: Wrong team ID - cancelling teleport~wacess_denied.wav");
	}
}

// The deployable Teleporter marker (A.K.A Rune)
StaticShapeData Rune
{
	damageSkinData = "objectDamageSkins";
	className = "RiftTech";

	shapeFile = "Grenade";
	maxDamage = 2.75;
	maxEnergy = 200;

   	mapFilter = 2;
	visibleToSensor = true;
	explosionId = LargeShockwave;
	debrisId = TeleporterDebris;
	sfxAmbient = SoundTeleportPower;
	mapIcon = "M_player";

	lightType = 2;   // Pulsing
	lightRadius = 8;
	lightTime = 0.1;	// Pulses quickly in red light
	lightColor = { 1.0, 0.1, 0.1 };
};
													 
function Rune::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "RunePack"]--;
	%team = GameBase::getTeam(%this);
	$RuneLoc[%team] = 0;
}

// The deployable Teleporter
StaticShapeData AntimatterBomb
{
	damageSkinData = "objectDamageSkins";
	className = "Explosive";

	shapeFile = "camera";
	maxDamage = 1.25;
	maxEnergy = 200;

   	mapFilter = 2;
	visibleToSensor = true;
	explosionId = LargeShockwave;
	debrisId = defaultDebrisLarge;
	mapIcon = "M_turret";
};
														 
function AntimatterBomb::onDestroyed(%this)
{
	calcRadiusDamage(%bomb,$DebrisDamageType,20.5,0.5,5,20,5,999,0.1,30,1);
}

// Healing area code - work in progress
// %num = containerBoxFillSet(%has,$PlayerObjectType,%thispos,100,100,100,0);
// %num = CountObjects(%set,"PlasticExplosive",%num);
// deleteObject(%has);

// Deployable NanoPack Builder Support "Node"
StaticShapeData NanoBase
{
	damageSkinData = "objectDamageSkins";
	className = "RiftTech";

	shapeFile = "generator_p";
	maxDamage = 0.2;

   	mapFilter = 2;
	visibleToSensor = true;
	explosionId = LargeShockwave;
	debrisId = TeleporterDebris;
	sfxAmbient = SoundGeneratorPower;
	mapIcon = "M_player";

	lightType = 2;   // Pulsing
	lightRadius = 8;
	lightTime = 0.1;	// Pulses quickly in green light
	lightColor = { 0.1, 2.0, 2.0 };
};

function NanoBase::onAdd(%this)
{
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
}
													 
function NanoBase::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "NanoBasePack"]--;
}

StaticShapeData FNXCharge
{
	className = "RiftTech";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
	maxDamage = 2.0;
	maxEnergy = 200;

	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
};

function FNXCharge::onDestroyed(%this)
{
	$FNXCharges[%this.FNXowner]--;
}

StaticShapeData HDeployBeacon
{
	damageSkinData = "objectDamageSkins";

	shapeFile = "force";
	maxDamage = 2.0;
	maxEnergy = 200;

	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
};

function HDeployBeacon::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	return;
}

StaticShapeData HDeployPlatform
{
	damageSkinData = "objectDamageSkins";

	shapeFile = "flagstand";
	maxDamage = 2.0;
	maxEnergy = 200;

	mapFilter = 2;
	mapIcon = "M_marker";
	visibleToSensor = true;
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
};

function HDeployPlatform::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%this.THHDMounter)
		GameBase::applyDamage(%this.THHDMounter,%type,%value,%pos,%vec,%mom,%object);
	else
		StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function HDeployPlatform::onDestroyed(%this)
{
	$NukePlatOut[GameBase::getTeam(%this)] = "";
}

StaticShapeData InvisibleObject
{
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
	maxDamage = 9999.0;
	maxEnergy = 200;

   castLOS = false;
   supression = false;
	visibleToSensor = false;

	mapFilter = 2;

   disableCollision = true;

   explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;

};


StaticShapeData NukeFire
{
	className = "THFX";
	damageSkinData = "objectDamageSkins";
	shapeFile = "sensor_small";
	maxDamage = 100.0;
//	disableCollision = true;
	explosionId = NukeCloudExp;
	visibleToSensor = true;
};

function THFX::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::setDamageLevel("@ %this @", "@ %data.maxDamage @");",0.1);
	schedule("deleteobject("@ %this @");",0.11);
//	GameBase::applyDamage(%this,0,9999.9,GameBase::getPosition(%this),"0 0 0","0 0 0",-1);
}
echo("v.B");

StaticShapeData Plastique
{
	className = "THFX";
	damageSkinData = "objectDamageSkins";
	shapeFile = "sensor_small";
	maxDamage = 1.0;
//	disableCollision = true;
	explosionId = mortarExp;
	visibleToSensor = true;
};

function Plastique::onAdd(%this)
{
	schedule("Plastique::Destruct("@ %this @");",10,%this);
}

function Plastique::Destruct(%this)
{
	%data = GameBase::getDataName(%this);
	TFunc::SpawnFX(GameBase::getPosition(%this),GameBase::getTeam(%this),"ShockFX");
	calcOwnedRadiusDamage(%this,$DebrisDamageType,10,1,100,100,1,2,0.1,250,100,%this);
	GameBase::setDamageLevel(%this,%data.maxDamage);
}
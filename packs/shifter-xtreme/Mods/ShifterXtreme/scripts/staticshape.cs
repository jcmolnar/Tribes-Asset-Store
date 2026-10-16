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

	if (getObjectType(%this.lastDamageObject) != "Player")
	{
		return;
	}
	
	if ($debug) echo ("StaticShape::objectiveDestroyed = StaticShape.cs 1");
   	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100); 
}

function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
   	
   	if (%object != "0" && %object != -1)
   	{
   		if (gamebase::getownerclient(%object) != "-1")
   			%this.lastDamageObject = client::getownedobject(gamebase::getownerclient(%object));
		else   	
   			%this.lastDamageObject = %object;
   	}
   	
   	%this.lastDamageTeam = GameBase::getTeam(%this.lastDamageObject);
	
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%name = GameBase::getDataName(%this);
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
	if((GameBase::getDataName(%this)).className == Generator && %this.shieldstrength && %type != $GayDamageType && GameBase::getEnergy(%this) > 0)
	{
		StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
	}
	else
	{
		GameBase::setDamageLevel(%this,%dValue);
	}
}

function StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	
	if (%this.shieldStrength)
	{
		%energy = GameBase::getEnergy(%this);
		%strength = %this.shieldStrength;
		if (%type == $ShrapnelDamageType)
			%strength *= 0.5;
		else
			if (%type == $MortarDamageType)
				%strength *= 0.25;
			else if (%type == $BlasterDamageType)
				%strength *= 2.0;
			
		%absorb = %energy * %strength;

		if (%value < %absorb)
		{
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
		else
		{
			GameBase::setEnergy(%this,0);
			StaticShape::onDamage(%this,%type,%value - %absorb,%pos,%vec,%mom,%object);
		}
	}
	else
	{
		StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	}
}

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
		GameBase::applyRadiusDamage(%type,getBoxCenter(%this), %radius,
			%damageValue,%force,%this);
	}
}

StaticShapeData FlagStand
{
	description = "Flag Stand";
	shapeFile = "flagstand";
	visibleToSensor = false;
};


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
	maxenergy = 100;  //added
	shieldShapeName = "shield_medium";
	shieldStrength = 0.07;  //added
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};

StaticShapeData SolarBig
{
    	description = "SolarBig";
    	shapeFile = "solar";
	className = "Generator";
    	sfxAmbient = SoundGeneratorPower;
	debrisId = flashDebrisLarge;
	explosionId = flashExpLarge;
    	maxDamage = 5.0;
	maxenergy = 100;  //added
	shieldShapeName = "shield_medium";
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
	maxenergy = 100;  //added
	shieldShapeName = "shield_medium";
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
   	maxDamage = 1000000;  //was 1.6
	maxenergy = 100; //added
	shieldShapeName = "shield_medium"; //added
	shieldStrength = 0.07;  //added
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
	maxDamage = 0.9;
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

//------------------------------------------------------------------------ Force Field Walls
StaticShapeData ForceField
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Force Field";
};
StaticShapeData ForceField1
{
	shapeFile = "ForceField_3x4";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Force Field";
};
StaticShapeData ForceField2
{
	shapeFile = "ForceField_4x17";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Force Field";
};
StaticShapeData ForceField3
{
	shapeFile = "ForceField_4x8";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Force Field";
};
StaticShapeData ForceField4
{
	shapeFile = "ForceField_5x5";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Force Field";
};
StaticShapeData ForceField5
{
	shapeFile = "ForceField_4x14";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Force Field";
};

StaticShapeData PlasmaWall
{
	shapeFile = "plasmawall";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "PlasmaWall";
};

//========================================================================= Misc Not In Base
StaticShapeData Enerpad
{
	shapeFile = "enerpad";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Telepad";
};

StaticShapeData Mainpad
{
	shapeFile = "mainpad";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "MainPad";
};

StaticShapeData TribesLogo
{
	shapeFile = "logo";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "logo";
};

StaticShapeData Bridge
{
	shapeFile = "bridge";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Bridge";
};

StaticShapeData GunTuret
{
	shapeFile = "GunTuret";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "gunturet";
};

StaticShapeData SatBig
{
	shapeFile = "sat_big";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "SatBig";
};

//------------------------------------------------------------------------ Beams
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

function Cactus1::onCollision(%this,%obj)
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

	if(GameBase::getDamageLevel(%obj)) 
	{
		GameBase::repairDamage(%obj,1.0);  //was 0.3
		GameBase::playSound(%this,ForceFieldOpen,0);
	}
}
//------------------------------------------------------------------------
StaticShapeData Cactus2
{
	shapeFile = "cactus2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
	description = "Cactus";
};

function Cactus2::onCollision(%this,%obj)
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

	if(GameBase::getDamageLevel(%obj)) 
	{
		GameBase::repairDamage(%obj,1.0);  //was 0.3
		GameBase::playSound(%this,ForceFieldOpen,0);
	}
}
//------------------------------------------------------------------------
StaticShapeData Cactus3
{
	shapeFile = "cactus3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
	description = "Cactus";
};

function Cactus3::onCollision(%this,%obj)
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

	if(GameBase::getDamageLevel(%obj)) 
	{
		GameBase::repairDamage(%obj,1.0);  //was 0.3
		GameBase::playSound(%this,ForceFieldOpen,0);
	}
}

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
//============================================================================ Small Force Field
// Deployable Forcefield 

StaticShapeData DeployableForceField
{
	shapeFile = "forcefield_3x4";
	debrisId = defaultDebrisSmall;
	maxDamage = 5.50;
	visibleToSensor = true;
	isTranslucent = true;
   	description = "Small Force Field";
};

function DeployableForceField::onCollision(%this,%obj)
{
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
	if(%this.isactive == "false")
	{
		GameBase::startfadeout(%this);
		%this.isactive=true;
		schedule("LargeForceField::Open("@%this@");",4);
		%pos=GameBase::getPosition(%this);
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);
		
		%height = 5000;
		%newpos = (%posX @ " " @ %posY @ " " @ (%posZ + %height));
	
		schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.35);
		gamebase::setposition(%this, %newpos);
		schedule("GameBase::setPosition("@%this@",\""@%pos@"\");",2.75);
	}
	else
	{
		%this.isactive = "false";
		%pos=GameBase::getPosition(%this);
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);
		
		%height = 5000;
		%newpos = (%posX @ " " @ %posY @ " " @ (%posZ - %height));
	
		gamebase::setposition(%this, %newpos);
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

//============================================================================ Large Force Field
StaticShapeData LargeForceField
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 8.00;
	visibleToSensor = true;
	isTranslucent = true;
    description = "Large Force Field";
};

function LargeForceField::onCollision(%this,%obj)
{
	%clientId = Player::getClient(%obj);
	%armor = Player::getArmor(%clientId);
	if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this) || ((%armor == "spyarmor" || %armor == "spyfemale")) )
	{		
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		LargeForceField::Open(%this);
		return;
	}
	echo ("Wrong Team");
	return;
}

function LargeForceField::Open(%this)
{
	if(%this.isactive == "false")
	{
		GameBase::startfadeout(%this);
		%this.isactive=true;
		schedule("LargeForceField::Open("@%this@");",3);
		%pos=GameBase::getPosition(%this);

		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);
		
		%height = 5000;
		%newpos = (%posX @ " " @ %posY @ " " @ (%posZ + %height));

		schedule("GameBase::setPosition("@%this@",\""@%pos@"\");",2.75);
		schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.05);
		gamebase::setposition(%this, %newpos);		
	}
	else
	{
		%this.isactive = "false";
		%pos=GameBase::getPosition(%this);
		
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);
		
		%height = 5000;
		%newpos = (%posX @ " " @ %posY @ " " @ (%posZ - %height));
	
		gamebase::setposition(%this, %newpos);
	
		GameBase::setPosition(%this,%pos);
		GameBase::startfadein(%this);
		schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.05);
	}
}

function LargeForceField::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldPack"]--;	
}

//============================================================================ Large Shock ForceField
StaticShapeData LargeShockForceField
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 8.00;
	visibleToSensor = true;
	isTranslucent = true;
    	description = "Large Shock Force Field";
};

function LargeShockForceField::onCollision(%this,%obj)
{
	%clientId = Player::getClient(%obj);
	%player = %obj;
	%armor = Player::getArmor(%clientId);
	if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this))
	{		
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		LargeForceField::Open(%this);
		return;
	}
	else
	{
		schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %obj @ "));",0.1);
		if($Shifter::TurretKill && %this.deployer && GameBase::getTeam(%this.deployer) != Gamebase::getTeam(%client))
		{
			GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this.deployer);
		}
		else
			GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this);
	}
	echo ("Wrong Team");
	return;
}

function LargeShockForceField::Open(%this)
{
	if(%this.isactive == "false")
	{
		GameBase::startfadeout(%this);
		%this.isactive=true;
		schedule("LargeForceField::Open("@%this@");",3);
		%pos=GameBase::getPosition(%this);

		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);
		
		%height = 5000;
		%newpos = (%posX @ " " @ %posY @ " " @ (%posZ + %height));

		schedule("GameBase::setPosition("@%this@",\""@%pos@"\");",2.75);
		schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.05);
		gamebase::setposition(%this, %newpos);		
	}
	else
	{
		%this.isactive = "false";
		%pos=GameBase::getPosition(%this);
		
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);
		
		%height = 5000;
		%newpos = (%posX @ " " @ %posY @ " " @ (%posZ - %height));
	
		gamebase::setposition(%this, %newpos);
	
		GameBase::setPosition(%this,%pos);
		GameBase::startfadein(%this);
		schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.05);
	}
}

function LargeShockForceField::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeShockForceFieldPack"]--;	
}
//============================================================================ Shock Force Field
StaticShapeData ShockForceField
{
	shapeFile = "forcefield_3x4";
	debrisId = defaultDebrisLarge;
	maxDamage = 8.00;
	visibleToSensor = true;
	isTranslucent = true;
    	description = "Small Shock Force Field";
};

function ShockForceField::onCollision(%this,%obj)
{
	%clientId = Player::getClient(%obj);
	%player = %obj;
	%armor = Player::getArmor(%clientId);
	if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this))
	{		
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		LargeForceField::Open(%this);
		return;
	}
	else
	{
		schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %obj @ "));",0.1);
		if($Shifter::TurretKill && %this.deployer && GameBase::getTeam(%this.deployer) != Gamebase::getTeam(%client))
		{
			GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this.deployer);
		}
		else
			GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this);
	}
	echo ("Wrong Team");
	return;
}

function ShockForceField::Open(%this)
{
	if(%this.isactive == "false")
	{
		GameBase::startfadeout(%this);
		%this.isactive=true;
		schedule("LargeForceField::Open("@%this@");",3);
		%pos=GameBase::getPosition(%this);

		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);
		
		%height = 5000;
		%newpos = (%posX @ " " @ %posY @ " " @ (%posZ + %height));

		schedule("GameBase::setPosition("@%this@",\""@%pos@"\");",2.75);
		schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.05);
		gamebase::setposition(%this, %newpos);		
	}
	else
	{
		%this.isactive = "false";
		%pos=GameBase::getPosition(%this);
		
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);
		
		%height = 5000;
		%newpos = (%posX @ " " @ %posY @ " " @ (%posZ - %height));
	
		gamebase::setposition(%this, %newpos);
	
		GameBase::setPosition(%this,%pos);
		GameBase::startfadein(%this);
		schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.05);
	}
}

function ShockForceField::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ShockForceFieldPack"]--;	
}
//============================================================================ Shock Floor ForceField
// Created by Mark Williamson for his customized Shifter servers
// contact mark@webpit.com (Customized by Emo1313 to Open by Teammates)
StaticShapeData ShockFloor
{
	shapeFile = "plasmawall";  //forcefield_5x5
	debrisId = defaultDebrisLarge;
	maxDamage = 12.00;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Shock Floor";
};

function ShockFloor::onCollision(%this,%obj)
{
	%clientId = Player::getClient(%obj);
	%player = %obj;
	%armor = Player::getArmor(%clientId);
	%data = GameBase::getDataName(%obj); if(%data.shapefile == "rocket") {	GameBase::setDamageLevel(%obj, 10); return; }
	if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this))
	{		
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		ShockFloor::Open(%this);
		return;
	}
	else
	{
		schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %obj @ "));",0.1);
		if($Shifter::TurretKill && %this.deployer && GameBase::getTeam(%this.deployer) != Gamebase::getTeam(%client))
		{
			GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this.deployer);
		}
		else
			GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this);
	}
	//echo ("Wrong Team");
	return;
}

function ShockFloor::Open(%this)
{
	if(%this.isactive == "false")
	{
		GameBase::startfadeout(%this);
		%this.isactive=true;
		schedule("LargeForceField::Open("@%this@");",3);
		%pos=GameBase::getPosition(%this);

		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);
		
		%height = 5000;
		%newpos = (%posX @ " " @ %posY @ " " @ (%posZ + %height));

		schedule("GameBase::setPosition("@%this@",\""@%pos@"\");",2.75);
		schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.05);
		gamebase::setposition(%this, %newpos);		
	}
	else
	{
		%this.isactive = "false";
		%pos=GameBase::getPosition(%this);
		
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);
		
		%height = 5000;
		%newpos = (%posX @ " " @ %posY @ " " @ (%posZ - %height));
	
		gamebase::setposition(%this, %newpos);
	
		GameBase::setPosition(%this,%pos);
		GameBase::startfadein(%this);
		schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.05);
	}
}

function ShockFloor::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ShockFloorPack"]--;	
}
//============================================================================ Blast Wall
StaticShapeData BlastWall
{
	shapeFile = "newdoor5";
	maxDamage = 12.0;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	description = "BlastWall";
	damageSkinData = "objectDamageSkins";
};

function BlastWall::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastWallPack"]--;	
}

//============================================================================ Blast Floor
StaticShapeData BlastFloor
{
	shapeFile = "elevator_8x8";
	maxDamage = 36.0;  //was 12.0
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	description = "BlastWall";
	damageSkinData = "objectDamageSkins";
};

function BlastFloor::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastFloorPack"]--;	
}

//============================================================================ Blast Wall2
StaticShapeData BlastWall2
{
	shapeFile = "teleport_vertical";
	maxDamage = 10.0;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	description = "BlastWall";
};
function BlastWall2::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastWallPack"]--;
}

//============================================================================ Deployable Platform

StaticShapeData DeployablePlatform
{
	shapeFile = "elevator_4x4";
	debrisId = defaultDebrisSmall;
	maxDamage = 4.00;
	visibleToSensor = false;
	isTranslucent = true;
   	description = "Deployable Platform";
	damageSkinData = "objectDamageSkins";
};

function DeployablePlatform::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "PlatformPack"]--;
	
}

//============================================================================ Tree 1

StaticShapeData DeployableTree
{
	shapeFile = "tree1";
	debrisId = defaultDebrisSmall;
	maxDamage = 6.50;
	visibleToSensor = false;
	isTranslucent = true;
   	description = "Deployable Tree";
};

StaticShapeData DeployableTree2
{
	shapeFile = "tree2";
	debrisId = defaultDebrisSmall;
	maxDamage = 6.50;
	visibleToSensor = false;
	isTranslucent = true;
   	description = "Deployable Tree";
};

function DeployableTree::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--;
	
}

function DeployableTree2::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--;
	
}

//============================================================================ Healing Plant

StaticShapeData DeployableCactus2
{
	shapeFile = "cactus2";
	debrisId = defaultDebrisSmall;
	maxDamage = 3.0;  //was 0.5
   	description = "Cactus";
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

	if(GameBase::getDamageLevel(%obj)) 
	{
		GameBase::repairDamage(%obj,1.0);  //was 0.3
		GameBase::playSound(%this,ForceFieldOpen,0);
	}
}

//============================================================================ HoloGram 1

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

//============================================================================ HoloGram 2
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

//============================================================================ HoloGram 3
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
    
//                                                  =-=-=-=-=- Teleporter =-=-=-=-
StaticShapeData DeployableTeleport
{
    	className = "DeployableTeleport";
	damageSkinData = "objectDamageSkins";

	shapeFile = "flagstand";
	maxDamage = 1.75;
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
	deleteObject(%b);
}				
														 
function DeployableTeleport::onDestroyed(%this)
{
	schedule("RemoveBeam("@%this.beam1@");",1);

	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableTeleport"]--;

	%teleset = nameToID("MissionCleanup/Teleports");

	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this)
		{
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
		if((Player::getArmor(%obj) == "spyarmor") || (Player::getArmor(%obj) == "spyfemale"))
			Client::SendMessage(%c,0,"Phased through enemy teleporter");
		else
		{ 
			Client::SendMessage(%c,0,"Wrong Team"); 
			return;
		}
	}

	if(%this.disabled == true)
	{
	        Client::SendMessage(%c,0,"Teleport Pad is recharging");
	        return;
	}

	%teleset = nameToID("MissionCleanup/Teleports");

	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		if ($Debug) echo ("Group Set Teleporter = " @ Group::getObject(%teleset, %i));
		if(GameBase::getTeam(%o) == %playerteam && %o != %this)
		{
//			if((Player::getArmor(%obj) == "harmor") || (Player::getArmor(%obj) == "darmor"))
//			{
//			        Client::SendMessage(%c,0,"Cannot teleport in this armor type");
//				return;
//			}
//			else
//			{
				GameBase::playSound(%o,ForceFieldOpen,0);
				GameBase::playSound(%this,ForceFieldOpen,0);
		           	GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
				%o.Disabled = true;
				%this.Disabled = true;
				schedule("DeployableTeleport::Reenable("@%o@");",5);
				schedule("DeployableTeleport::Reenable("@%this@");",5);
				return;
//			}
		}
		else if((Player::getArmor(%obj) == "spyarmor") || (Player::getArmor(%obj) == "spyfemale"))
		{
			if(GameBase::getTeam(%o) != %playerteam && %o != %this)
			{
				Client::SendMessage(%c,0,"Transporting To Enemy Telepad!");
				GameBase::playSound(%o,ForceFieldOpen,0);
				GameBase::playSound(%this,ForceFieldOpen,0);
		           	GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
				%o.Disabled = true;
				%this.Disabled = true;
				schedule("DeployableTeleport::Reenable("@%o@");",5);
				schedule("DeployableTeleport::Reenable("@%this@");",5);
				return;								
			}		
		}
	}
	Client::SendMessage(%c,0,"No other pad to teleport to.");
}

function DeployableTeleport::Reenable(%this)
{
	%this.disabled = false;
}

//================================================ Air Bases ====================================================

StaticShapeData AirAmmoBasePad //=================================================================== Air Ammo Pad
{
        shapeFile = "elevator6x6thin";
        debrisId = defaultDebrisLarge;
        maxDamage = 5.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "AirAmmoBasePad";
};

//================================================================================================== Air Base
StaticShapeData LargeAirBasePlatform
{
        shapeFile = "elevator16x16_octo";
        debrisId = defaultDebrisLarge;
        maxDamage = 1500.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "Air Base";
};
//============================================== Personal Movers ================================================

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

//============================================================================================= Launch Pad

StaticShapeData DeployableLaunch
{
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.50;
	visibleToSensor = false;
	isTranslucent = true;
	description = "Launch Pad";
};

function DeployableLaunch::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "LaunchPack"]--;
}

function DeployableLaunch::onCollision(%this,%obj) 
{
	%c = Player::getClient(%obj);

	GameBase::playSound(%this, SoundFireMortar, 0);
	Client::SendMessage(%c, 0, "SPROING!");
	%velocity = 200;
	%zVec = 600;
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
	Player::applyImpulse(%obj,%jumpDir);
}

StaticShapeData Shurk
{
	shapeFile = "discb";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Shuriken";
};

function Shurk::OnCollision(%this,%obj)
{
	if(getObjtype(%obj) == "Player" && (Player::getArmor(%obj) == larmor || Player::getArmor(%obj) == lfemale))
	{
		deleteobject(%this);
		Player::incItemCount(%obj,Beacon,1);
	}
}
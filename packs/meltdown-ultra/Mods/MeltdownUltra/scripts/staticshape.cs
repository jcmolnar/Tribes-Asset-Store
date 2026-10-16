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

	if ($debug) echo ("StaticShape::objectiveDestroyed - Start");
   		StaticShape::objectiveDestroyed(%this);
	if ($debug) echo ("StaticShape::objectiveDestroyed - Finish");

	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
}

function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{	
	if(%this.destroyed) return;	//	Shape Has Already Been Destroyed....
	%damageLevel = GameBase::getDamageLevel(%this);
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	
	// Does a Node Exist on this Object ??
	if (%this.shieldNode)
	{	%node=%this.shieldNode;					// Apply Damage to Node Shield first
		%energy = GameBase::getEnergy(%node);
		%strength = %node.shieldStrength;
		%NodeDamageLevel = GameBase::getDamageLevel(%node);
		if($traceDam) echo( $ver@"|Shield Node :",%node," Node Energy:",%energy," Node Shield Strength:",%strength,"");
		if (%type == $ShrapnelDamageType)
			%strength *= 0.5;
		else
			if (%type == $MortarDamageType)
				%strength *= 0.25;
			else
				if (%type == $BlasterDamageType)
					%strength *= 2.0;
				else
					if (%type == $DisruptorDamageType || %type == $SonicDamageType)
						%strength *= 0;
		%absorb = %energy * %strength;
		GameBase::setEnergy(%node,%energy - (%value / %strength));
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
		if (%value > %absorb)
		{	// if($trace) echo( $ver@"|Shield Node unable to Deflect All damage!!!"); 
			GameBase::setEnergy(%node,0);
			NewStaticShapeDamage (%node,%object,%NodeDamagelevel,%value-%absorb);
			// if($trace) echo( $ver@"|Shield Node Damage Level is :",%NodeDamageLevel," Damage appllied ",%value-%absorb);
		}
		return;	
	}

	%name=GameBase::GetDataName(%this);
	if (%this.shieldStrength) 
	{	//if this is a shield Node Then it has no shield
		if(%name=="RemoteShieldNode")
		{	
			NewStaticShapeDamage (%this,%object,%damagelevel,%value);	
		}
		else
		{	%energy = GameBase::getEnergy(%this);
			%strength = %this.shieldStrength;
			if (%type == $ShrapnelDamageType)
				%strength *= 0.5;
			else
				if (%type == $MortarDamageType)
					%strength *= 0.25;
				else
					if (%type == $BlasterDamageType)
						%strength *= 2.0;
				else if (%type == $DisruptorDamageType)
						%strength *= 0;

			%absorb = %energy * %strength;
			if (%value < %absorb) 
			{	//if($trace) echo( $ver@"|the shields wil absorb all damage");
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
			{	GameBase::setEnergy(%this,0);
				NewStaticShapeDamage (%this,%object,%damagelevel,%value-%absorb);
				//if($trace) echo( $ver@"|the shields wil absorb some Damage - Damage =",%value-%absorb);
			}
		}
	}
	else
		NewStaticShapeDamage (%this,%object,%damagelevel,%value);
		
}

function StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
   %this.lastDamageObject = %object;
   %this.lastDamageTeam = GameBase::getTeam(%object);
	if (%this.shieldStrength) {
		%energy = GameBase::getEnergy(%this);
		%strength = %this.shieldStrength;
		if (%type == $DisruptorDamageType || %type == $SonicDamageType)
			%value = 0;
		else if (%type == $ShrapnelDamageType)
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
			if(%this.lastsound < getSimTime()) 
			{
				playSound(ShieldHitz, GameBase::getPosition(%this));
				%this.lastsound = getSimTime() + 1;
			}
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
			if(%this.lastsound < getSimTime()) 
			{
				playSound(ShieldHitz, GameBase::getPosition(%this));
				%this.lastsound = getSimTime() + 1;
			}

		}
	}
	else {
		StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	}
}

function NewStaticShapeDamage(%this,%object,%damageLevel,%value)
{	%dValue = %damageLevel + %value;
	%name = GameBase::getDataName(%this);
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) 
	{	if(%name.classname == Generator || %name.classname == Station) 
			{ 	%TDS = $Server::TeamDamageScale;
				%dValue = %damageLevel + %value * %TDS;
				%disable = GameBase::getDisabledDamage(%this);
				if(!$Server::TourneyMode && %dValue > %disable - 0.05) 
				{	if(%damageLevel > %disable - 0.05)
						return;
					else
					%dValue = %disable - 0.05;
				}
			}
		
	}
	GameBase::setDamageLevel(%this,%dValue);
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

function Generator::onActivate(%this)
{
        GameBase::playSequence(%this,0,"power");
        GameBase::generatePower(%this, true);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0.015;
}

function Generator::onDeactivate(%this)
{
        GameBase::stopSequence(%this,0);
         GameBase::generatePower(%this, false);
        GameBase::setRechargeRate(%this,0);
        %this.shieldStrength = 0;
}

function Generator::onEnabled(%this)
{	GameBase::setActive(%this,true);
	if(%this.destroyed==true)
	{	%this.destroyed=false;
		// Main Power Restored..... Check Backup Power Grid & re-route
		RecheckGrid(%this);	// Checks portable Gens & reroutes any Items belonging to main power back to main
	}
}

function Generator::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
	// Main Power Disabled.... Check for Backup/Portable Generators & Re-route Power

	EngageBackupPower(%this);
}

function Generator::onDestroyed(%this)
{
	Generator::onDisabled(%this);
   StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 
		0.30, 250, 170); 
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
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
 	shieldShapeName = "shield";
	maxEnergy = 100; 
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
 	shieldShapeName = "shield";
	maxEnergy = 10; 
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
 	shieldShapeName = "shield";
	maxEnergy = 50; 
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
 
//-----------------------------------------------------------------------

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

StaticShapeData ForceField2 // Added by: Bhall
{
	shapeFile = "forcefield";
	className = "Obstruction";
	debrisId = defaultDebrisSmall;
	maxDamage = 10;
	isTranslucent = true;
        description = "Containment Field";
	visibleToSensor = true;
};

StaticShapeData SmallForceField // Added by: Bhall
{
	shapeFile = "forcefield_5x5";
	className = "Obstruction";
	debrisId = defaultDebrisSmall;
	maxDamage = 7;
	isTranslucent = true;
        description = "Small Force Field";
	visibleToSensor = true;
};

StaticShapeData ForceFieldDoor // Added by: Bhall
{
	shapeFile = "forcefield_3x4";
	className = "Obstruction";
	debrisId = defaultDebrisSmall;
	maxDamage = 5;
	isTranslucent = true;
        description = "Door-Sized Force Field";
	visibleToSensor = true;
};

StaticShapeData dummyl // Added by: Bhall
{
	shapeFile = "larmor";
	className = "Statue";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.666;
	isTranslucent = false;
        description = "Decoy";
        visibleToSensor = true;
   damageSkinData = "armorDamageSkins";
};

StaticShapeData dummym // Added by: Bhall
{
	shapeFile = "marmor";
	className = "Statue";
	debrisId = defaultDebrisSmall;
	maxDamage = 1;
	isTranslucent = false;
        description = "Decoy";
        visibleToSensor = true;
   damageSkinData = "armorDamageSkins";
};

StaticShapeData dummyh // Added by: Bhall
{
	shapeFile = "harmor";
	className = "Statue";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.32;
	isTranslucent = false;
        description = "Decoy";
        visibleToSensor = true;
   damageSkinData = "armorDamageSkins";
};

StaticShapeData Tree // Added by: Bhall
{
	shapeFile = "tree1";
	className = "Statue";
	debrisId = "defaultDebrisSmall";
	maxDamage = 10;
	isTranslucent = false;
        description = "Very Durable Tree";
        visibleToSensor = true;
};

StaticShapeData Tree2 // Added by: Bhall
{
	shapeFile = "tree2";
	className = "Statue";
	debrisId = "defaultDebrisSmall";
	maxDamage = 10;
	isTranslucent = false;
        description = "Very Durable Tree";
        visibleToSensor = true;
};

StaticShapeData MetalShield // Added by: Bhall
{
	shapeFile = "newdoor5";
	debrisId = defaultDebrisSmall;
	className = "Obstruction";
	maxDamage = 15;
	isTranslucent = false;
        description = "Holographic Blast Wall";
        visibleToSensor = true;
};

//------------------------------------------------------------------------ Force Field Walls

StaticShapeData ForceField1
{
	shapeFile = "ForceField_3x4";
	debrisId = defaultDebrisSmall;
	maxDamage = 36.0;
	isTranslucent = true;
   	description = "Force Field";
};
StaticShapeData ForceField22
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
	maxDamage = 36.0;
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

//-------------------------------------------------------------------------
//============================================================================ Large Shock ForceField

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
		GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this);
	}
	echo ("Wrong Team");
	return;
}

function OLDLargeShockForceField::onCollision(%this,%obj)
{
	%clientId = Player::getClient(%obj);
	%player = %obj;
	%armor = Player::getArmor(%clientId);
	%data = GameBase::getDataName(%obj); if(%data.shapefile == "rocket") {if (GameBase::setDamageLevel(%obj, 10)) return;}
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
		GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this);
	}
	if ($debug) echo ("Wrong Team");
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
//============================================================================ Shock Floor ForceField
// Created by Mark Williamson for his customized Shifter servers
// contact mark@webpit.com (Customized by Emo1313 to Open by Teammates)
StaticShapeData ShockFloor
{
	shapeFile = "forcefield_5x5";
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
        maxDamage = 19.0;    // was 36
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "Air Base";
};

StaticShapeData LargeEmplacementPlatform
{
        shapeFile = "elevator16x16_octo";
        debrisId = defaultDebrisLarge;
        maxDamage = 19.0;    // was 36
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "Air Base";
};
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
	%data = GameBase::getDataName(%obj); if(%data.shapefile == "rocket") {	GameBase::setDamageLevel(%obj, 10); return; }

	GameBase::playSound(%this, SoundFireMortar, 0);
	Client::SendMessage(%c, 0, "SPROING!");
	%velocity = 200;
	%zVec = 600;
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
	Player::applyImpulse(%obj,%jumpDir);
}


//Uranium's custom static shape registers
StaticShapeData Fire { shapeFile = "plasmabolt"; maxDamage = 10000.0; description = "Fire"; disableCollision = false; isTranslucent = true;  };

//don't want the fire to go out
function Fire::onDamage(){}
StaticShapeData Twiggy{shapeFile = "mrtwig"; maxDamage = 10000.0; description = "Twig"; };

//save the twigs...for your tomorrow
function Twiggy::onDamage(){}

//slow flares
ItemData SlowSmallOrange 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 1, 0.5, 0 }; };
ItemData SlowMedOrange 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 1, 0.5, 0 }; };
ItemData SlowLargeOrange 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 16; lightTime = 0.5; lightColor = { 1, 0.5, 0 }; };
ItemData SlowSmallRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 1, 0, 0 }; };
ItemData SlowMedRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 1, 0, 0 }; };
ItemData SlowLargeRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.5; lightColor = { 1, 0, 0 }; };
ItemData SlowSmallBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 0, 0, 1 }; };
ItemData SlowMedBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 0, 0, 1 }; };
ItemData SlowLargeBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.5; lightColor = { 0, 0, 1 }; };
ItemData SlowSmallYellow 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 1, 1, 0 }; };
ItemData SlowMedYellow 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 1, 1, 0 }; };
ItemData SlowLargeYellow 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.5; lightColor = { 1, 1, 0 }; };
ItemData SlowSmallGreen 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 0, 1, 0 }; };
ItemData SlowMedGreen 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 0, 1, 0 }; };
ItemData SlowLargeGreen 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.5; lightColor = { 0, 1, 0 }; };
ItemData SlowSmallWhite 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 1, 1, 1 }; };
ItemData SlowMedWhite 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 1, 1, 1 }; };
ItemData SlowLargeWhite 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.5; lightColor = { 1, 1, 1 }; };

//fast flares
ItemData FastSmallOrange 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 1, 0.5, 0 }; };
ItemData FastMedOrange 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 1, 0.5, 0 }; };
ItemData FastLargeOrange 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 16; lightTime = 0.07; lightColor = { 1, 0.5, 0 }; };
ItemData FastSmallRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 1, 0, 0 }; };
ItemData FastMedRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 1, 0, 0 }; };
ItemData FastLargeRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.07; lightColor = { 1, 0, 0 }; };
ItemData FastSmallBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 0, 0, 1 }; };
ItemData FastMedBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 0, 0, 1 }; };
ItemData FastLargeBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.07; lightColor = { 0, 0, 1 }; };
ItemData FastSmallYellow 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 1, 1, 0 }; };
ItemData FastMedYellow 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 1, 1, 0 }; };
ItemData FastLargeYellow 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.07; lightColor = { 1, 1, 0 }; };
ItemData FastSmallGreen 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 0, 1, 0 }; };
ItemData FastMedGreen 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 0, 1, 0 }; };
ItemData FastLargeGreen 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.07; lightColor = { 0, 1, 0 }; };
ItemData FastSmallWhite 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 1, 1, 1 }; };
ItemData FastMedWhite 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 1, 1, 1 }; };
ItemData FastLargeWhite 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.07; lightColor = { 1, 1, 1 }; };

// FireBolt Fountain
StaticShapeData FireBolt	{ className = "FireBolt"; damageSkinData = "objectDamageSkins"; shapeFile = "plasmabolt"; maxDamage = 10000; maxEnergy = 200; mapFilter = 2; visibleToSensor = false; explosionId = debrisExpLarge; debrisId = flashDebrisLarge; lightRadius = 12.0; lightType = 1; lightColor = {1.0,0.0,0.2}; side = "single"; isTranslucent = false; };
function FireBolt::onAdd(%this) { schedule ("FireBolt::Pop(" @ %this @ ");",2); }
function FireBolt::Pop(%this)   { %pos = Gamebase::getposition(%this); %trans = "0 0 0 0 0 0.9 0 0 0 " @ %pos; %fired = Projectile::spawnProjectile(FireBoltProj, %trans ,%this,"0 0 0"); %random = floor(getRandom() * 3)+1; schedule ("FireBolt::Pop(" @ %this @ ");",%random,%this); }
RocketData FireBoltProj	{ bulletShapeName  = "plasmabolt.dts"; explosionTag = plasmaExp; collisionRadius  = 0.0; mass = 0.0; damageClass = 0; damageValue = 0.15; damageType = $PlasmaDamageType; explosionRadius = 1.0; kickBackStrength = 0; muzzleVelocity   = 5.0; terminalVelocity = 5.0; acceleration = 5.0; totalTime = 1.5; liveTime = 1.5; lightRange = 1.0; lightColor = { 1, 1, 0 }; inheritedVelocityScale = 0.0; trailType = 2; trailString = "plasmabolt.dts"; smokeDist   = 5.0; soundId = SoundJetHeavy; };

// Electric Fountain
StaticShapeData elecbolt	{ className = "elecbolt"; damageSkinData = "objectDamageSkins"; shapeFile = "fusionbolt"; maxDamage = 10000; maxEnergy = 200; mapFilter = 2; visibleToSensor = false; explosionId = debrisExpLarge; debrisId = flashDebrisLarge; lightRadius = 12.0; lightType = 1; lightColor = {1.0,0.0,0.2}; side = "single"; isTranslucent = false; };
function elecbolt::onAdd(%this) { schedule ("elecbolt::Pop(" @ %this @ ");",2); }
function elecbolt::Pop(%this) 	{ %pos = Gamebase::getposition(%this); %trans = "0 0 0 0 0 0.9 0 0 0 " @ %pos; %fired1 = Projectile::spawnProjectile(elecboltProj, %trans ,%this,"0 0 0"); schedule ("elecbolt::Pop(" @ %this @ ");",5,%this); }
RocketData elecboltProj		{ bulletShapeName  = "fusionbolt.dts"; explosionTag = energyExp; collisionRadius  = 0.0; mass = 0.0; damageClass = 0; damageValue = 0.15; damageType = $ElectricityDamageType; explosionRadius = 1.0; kickBackStrength = 0; muzzleVelocity   = 2.5; terminalVelocity = 2.5; acceleration = 2.5; totalTime = 4; liveTime = 4; lightRange = 4.0; lightColor = { 0, 0, 2 }; inheritedVelocityScale = 0.0; trailType = 2; trailString = "fusionbolt.dts"; smokeDist   = 5.0; soundId = SoundJetHeavy; };





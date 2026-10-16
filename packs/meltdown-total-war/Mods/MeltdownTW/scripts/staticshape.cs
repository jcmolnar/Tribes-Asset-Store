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

StaticShapeData FlagStand2
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
{	
	GameBase::setActive(%this,true);
      GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.015;

	if(%this.destroyed==true)
	{	%this.destroyed=false;
		RecheckGrid(%this);	// Main Power Restored..... Check Backup Power Grid & re-route
	}

}

function Generator::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
      GameBase::setRechargeRate(%this,0);
      %this.shieldStrength = 0;

	EngageBackupPower(%this);	// Main Power Disabled.... Check for Backup/Portable Generators & Re-route Power
}

function Generator::onDestroyed(%this)
{
	Generator::onDisabled(%this);
   StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 
		0.30, 250, 170); 
      GameBase::setRechargeRate(%this,0);
      %this.shieldStrength = 0;
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

StaticShapeData MFGenerator // Added by: Bhall
{
	shapeFile = "bridge";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.666;
	isTranslucent = true;
        className = "BaseAll";
   sfxAmbient = SoundGeneratorPower;
	explosionId = LargeShockwave;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
        description = "MiniBase Fusion Reactor";
};

StaticShapeData FGen1 // Added by: Bhall
{
	shapeFile = "Generator";
	debrisId = defaultDebrisSmall;
	maxDamage = 2;
	isTranslucent = true;
        className = "Generator";
   sfxAmbient = SoundGeneratorPower;
	explosionId = LargeShockwave;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
        description = "Generator";
};

# TEST FOR .dis compatibility!
# Mega Man 1024
# .dis compatibility need new backdoor....

StaticShapeData Dropship
{
	shapeFile = "force";
	explosionId = mortarExp;
	debrisId = defaultDebrisSmall;
	className = "Drpopship";
	maxDamage = 50;
	isTranslucent = false;
        description = "Dropship";
        visibleToSensor = true;
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

//===========================================================================

//Ground Base

StaticShapeData BaseGenerator
{
   description = "Power Source";
   shapeFile = "generator_p";
        className = "Generator";
        debrisId = flashDebrisSmall;
        sfxAmbient = SoundGeneratorPower;
        maxDamage = 1.0;
        mapIcon = "M_generator";
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = flashExpMedium;
        visibleToSensor = true;
        mapFilter = 4;

};

function BaseGenerator::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	GameBase::setDamageLevel(%this,10000);
	calcRadiusDamage(%this, $DebrisDamageType, 30, 1000, 250, 30, 25, 1000, 999, 250, 100);
	$TeamItemCount[GameBase::getTeam(%this) @ "MiniBase"]--;
}

StaticShapeData BasePlatform
{
        shapeFile = "elevator16x16_octo";
        debrisId = defaultDebrisLarge;
        maxDamage = 25.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "Ground Base";
};

function BasePlatform::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	GameBase::setDamageLevel(%this,10000);
	calcRadiusDamage(%this, $DebrisDamageType, 30, 1000, 250, 30, 25, 1000, 999, 250, 100);
}

StaticShapeData ABPortGenerator
{
   description = "Portable Generator";
   shapeFile = "generator_p";

       className = "Generator";
        debrisId = flashDebrisSmall;
        sfxAmbient = SoundGeneratorPower;
        maxDamage = 1.0;
        mapIcon = "M_generator";
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = flashExpMedium;
        visibleToSensor = true;
        mapFilter = 4;
};

function ABPortGenerator::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	GameBase::setDamageLevel(%this,10000);
	calcRadiusDamage(%this, $DebrisDamageType, 30, 1000, 250, 30, 25, 1000, 999, 250, 100);
	$TeamItemCount[GameBase::getTeam(%this) @ "minibase"]--;
}

StaticShapeData LargeAirBasePlatform
{
        shapeFile = "elevator16x16_octo";
        debrisId = defaultDebrisLarge;
        maxDamage = 100.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "GroundBase";
};

function LargeAirBasePlatform::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	GameBase::setDamageLevel(%this,10000);
	calcRadiusDamage(%this, $DebrisDamageType, 30, 1000, 250, 30, 25, 1000, 999, 250, 100);
      $TeamItemCount[GameBase::getTeam(%this) @ "airbase"]--;
}


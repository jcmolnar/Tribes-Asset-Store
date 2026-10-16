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
	else if (%type==$NullDamageType)
	{	DesignateTarget(%this,%value,%object);
		return;
	}
	else if (%type==$StasisDamageType)
	{	if($tracedam) echo( $ver@"|STASIS DAMAGE TO: ",%this);
		%loss=GameBase::getEnergy(%this)*$StasisEnergyDrain;
		%energy-=%loss;
		GameBase::setEnergy(%this,%energy);
		%this.mass=50;
	}
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
		{	if($traceAll) echo( $ver@"|Shield Node under attack");
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
     	
 	if ($GreyDawnNormal)
       {
       GameBase::setAutoRepairRate(%this, 1.30);
       }
       else if ($GreyDawnNoRape)
       {
       GameBase::setAutoRepairRate(%this, 5.00);
       }
	else
	{
	GameBase::setAutoRepairRate(%this, 1.50);
	}

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
   maxDamage = 10.0;
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
	maxDamage = 10.0;
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
   maxDamage = 20.0;
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

//-------------------------------------------------------------------------

StaticShapeData DeployableTeleport 
{ 
	className = "DeployableTeleport"; 
	damageSkinData = "objectDamageSkins"; 
	shapeFile = "mineammo"; 
	maxDamage = 3; 
	maxEnergy = 200; 
	mapFilter = 2; 
	visibleToSensor = true; 
	explosionId = mortarExp; 
	debrisId = flashDebrisLarge; 
	lightRadius = 12.0; 
	lightType=2; 
	lightColor = {1.0,0.2,0.2}; 
};

function RemovePhaseShip(%ship)
{
	GameBase::startFadeOut(%ship);
	echo("Removing AirStrike Ship");
	schedule("RemoveBeam("@%ship@");",2);
}
function RemoveBeam(%b) 
{ 
	deleteObject(%b); 
} 

function DeployableTeleport::Destruct(%this) 
{ 
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
			GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this); return; 
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
		if((Player::getArmor(%obj) == "larmor") || (Player::getArmor(%obj) == "lfemale")) 
			Client::SendMessage(%c,3,"Phased through enemy teleporter"); 
			else 
			{ 
				Client::SendMessage(%c,0,"Wrong Team"); 
				return; 
			} 
	} 
	if(%this.disabled == true) 
	{ 
		Client::SendMessage(%c,1,"Teleport Pad is recharging"); 
		return; 
	} 
	%teleset = nameToID("MissionCleanup/Teleports"); 
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++) 
	{ 
		if(GameBase::getTeam(%o) == %playerteam && %o != %this) 
		{ 
			if((Player::getArmor(%obj) == "xarmor") || (Player::getArmor(%obj) == "xfarmor") || (Player::getArmor(%obj) == "parmor")) 
			{ 
				Client::SendMessage(%c,3,"Cannot teleport in this character class"); 
				return; 
			} 
			else 
			{ 
				GameBase::playSound(%o,enterdimension,0); 
				GameBase::playSound(%this,enterdimension,0); 
				GameBase::SetPosition(%obj,GameBase::GetPosition(%o)); 
				%o.Disabled = true; 
				%this.Disabled = true; 
				schedule("DeployableTeleport::Reenable("@%o@");",1); 
				schedule("DeployableTeleport::Reenable("@%this@");",1); 
				return; 
			} 
		} 
	} 
	Client::SendMessage(%c,1,"No other teleport pad!"); 
}

function DeployableTeleport::Reenable(%this) 
{ 
	%this.disabled = false; 
} 

//===========================================================================


StaticShapeData BaseWall
{
        shapeFile = "elevator_9x9";
        debrisId = defaultDebrisLarge;
        maxDamage = 50.00;
        visibleToSensor = true;
        isTranslucent = false;
        description = "Mini-Base";
};

StaticShapeData BaseGenerator
{
   description = "Power Source";
   shapeFile = "generator_p";
        className = "Generator";
        debrisId = flashDebrisSmall;
        sfxAmbient = SoundGeneratorPower;
        maxDamage = 25.0;
        mapIcon = "M_generator";
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = flashExpMedium;
        visibleToSensor = true;
        mapFilter = 4;

};

function BaseGenerator::onDestroyed(%this)
{
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

StaticShapeData RadarJammer
{
        shapeFile = "sat_big";
        debrisId = defaultDebrisLarge;
        maxDamage = 25.00;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Radar Jammer";
};

function RadarJammer::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);

function BaseGenerator::onDestroyed(%this)
{
$TeamItemCount[GameBase::getTeam(%this) @ "minibase"]--;

}
}

StaticShapeData ABPortGenerator
{
   description = "Portable Generator";
   shapeFile = "generator_p";
        className = "Generator";
        debrisId = flashDebrisSmall;
        sfxAmbient = SoundGeneratorPower;
        maxDamage = 5.0;
        mapIcon = "M_generator";
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = flashExpMedium;
        visibleToSensor = true;
        mapFilter = 4;

};

function ABPortGenerator::onDestroyed(%this)
{
$TeamItemCount[GameBase::getTeam(%this) @ "airbase"]--;
}

StaticShapeData LargeAirBasePlatform
{
        shapeFile = "elevator16x16_octo";
        debrisId = defaultDebrisLarge;
        maxDamage = 1000.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "Air Base";
};

StaticShapeData LargeAirBaseRadar
{
        shapeFile = "radar";
        debrisId = defaultDebrisLarge;
        maxDamage = 5.00;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Air Base Radar";
};

function LargeRadar::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
}
function ABPortGenerator::onDestroyed(%this)
{
$TeamItemCount[GameBase::getTeam(%this) @ "airbase"]--;

}


StaticShapeData LLargeForceField
{
        shapeFile = "forcefield";
        debrisId = defaultDebrisLarge;
        maxDamage = 75.00;
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
Client::SendMessage(%obj,1,"You Have Been Released. Run Forest Run!!!!");
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
      Client::SendMessage(%c,1,"You Stepped On Your Teams Jail Capture Pad ~waccess_denied.wav");
      return;
      }

    %teleset = nameToID("MissionCleanup/jailports");
    %gclient = Client::getName(%c);
    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
    %oteam=GameBase::getTeam(%o);

             if(%oteam != %playerTeam)
                    {
                        GameBase::playSound(%o,Transport,0);
                        GameBase::playSound(%this,Transport,0);
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

StaticShapeData RadarPole
{
	shapeFile = "anten_rod";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   description = "Sad AntiGrav Pole";
};

StaticShapeData SatelliteDish
{
	shapeFile = "sat_big";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   description = "Microwave Dish";
};

function ObeliskPower::onEnabled(%this)
{
	GameBase::setActive(%this,true);
}

function ObeliskPower::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
	GameBase::setDamageLevel(%this.obelisk, 20); //kill the turret when it goes down
}

function ObeliskPower::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "ObeliskPowerPack"]--;
	Generator::onDisabled(%this);
   StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 
		0.30, 250, 170); 
}

function ObeliskPower::onActivate(%this)
{
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
}

function ObeliskPower::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
	GameBase::setDamageLevel(%this.obelisk, 20); //kill the turret when it goes down

}

StaticShapeData ObeliskPower
{
   description = "Obelisk Power Source";
	shapeFile = "solar";
	className = "Generator";
	debrisId = flashDebrisLarge;
	maxDamage = 1.5;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
    damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpLarge;
};


StaticShapeData ObeliskOfLight
{
   description = "Obelisk of Light";
	shapeFile = "anten_rod";
	className = "Decoration";
	debrisId = flashDebrisLarge;
	maxDamage = 5;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
    damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpLarge;

   sfxAmbient = ZeldaLostWoods;

};



function ObeliskOfLight::onDestroyed(%this)
{
	GameBase::stopSequence(%this,0);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 
		0.1, 250, 100); 

	%realGun = %this.realGun;
	GameBase::setDamageLevel(%realGun, 10);
	%gen = %this.gen;
	%gen.obelisk = "";
  	$TeamItemCount[GameBase::getTeam(%this) @ "ObeliskPack"]--;
}

// Override base class just in case.
function ObeliskOfLight::onPower(%this,%power,%generator)
{
	if (%power) 
		GameBase::playSequence(%this,0,"power");
	else 
		GameBase::stopSequence(%this,0);
}


function ObeliskOfLight::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) 
		GameBase::playSequence(%this,0,"power");
}

function ObeliskOfLight::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
}

function Statue::onCollision (%this, %object)
{
	if (getObjectType (%object) == "Player")
		{
			//PORT-OFF: Player::mountObject (%object, %this);  no such command (stock turret.cs has the same call commented out)
		}
}

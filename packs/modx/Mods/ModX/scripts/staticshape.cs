// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------

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
    %power = GameBase::isPowered(%this);
         if (%power == false && %this.ispowerReq == true)
         {

         }
}

function StaticShape::onDelete(%this)
{}

function StaticShape::onWeld(%this, %weld)
{}

function StaticShape::onDestroyed(%this)
{
	GameBase::stopSequence(%this,0);
    StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
}

function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{

        return;

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

        return;

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

function Generator::onWeld(%this)
{}

function Generator::onDelete(%this)
{}

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
StaticShapeData LargeAntenna
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
StaticShapeData MediumAntenna
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
StaticShapeData LargeRadar
{
	shapeFile = "radar";
	debrisId = defaultDebrisLarge;
	maxDamage = 5.00;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Large Radar";
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
StaticShapeData ForceFieldOld
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

StaticShapeData ForceField
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   description = "Force Field";
};

StaticShapeData ForceField22
{
	shapeFile = "forcefield";
	className = "Obstruction";
	debrisId = defaultDebrisSmall;
	maxDamage = 10;
	isTranslucent = true;
        description = "Containment Field";
	visibleToSensor = true;
};

StaticShapeData SmallForceField
{
	shapeFile = "forcefield_5x5";
	className = "Obstruction";
	debrisId = defaultDebrisSmall;
	maxDamage = 7;
	isTranslucent = true;
        description = "Small Force Field";
	visibleToSensor = true;
};

StaticShapeData ForceFieldDoor
{
	shapeFile = "forcefield_3x4";
	className = "Obstruction";
	debrisId = defaultDebrisSmall;
	maxDamage = 5;
	isTranslucent = true;
        description = "Door-Sized Force Field";
	visibleToSensor = true;
};

StaticShapeData dummyl
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

StaticShapeData dummym
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

StaticShapeData dummyh
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

StaticShapeData dummylf
{
	shapeFile = "lfemale";
	className = "Statue";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.666;
	isTranslucent = false;
        description = "Decoy";
        visibleToSensor = true;
   damageSkinData = "armorDamageSkins";
};

StaticShapeData dummymf
{
	shapeFile = "mfemale";
	className = "Statue";
	debrisId = defaultDebrisSmall;
	maxDamage = 1;
	isTranslucent = false;
        description = "Decoy";
        visibleToSensor = true;
   damageSkinData = "armorDamageSkins";
};

StaticShapeData Tree
{
	shapeFile = "tree1";
	className = "Statue";
	debrisId = "defaultDebrisSmall";
	maxDamage = 10;
	isTranslucent = false;
        description = "Very Durable Tree";
        visibleToSensor = true;
};

StaticShapeData Tree2
{
	shapeFile = "tree2";
	className = "Statue";
	debrisId = "defaultDebrisSmall";
	maxDamage = 10;
	isTranslucent = false;
        description = "Very Durable Tree";
        visibleToSensor = true;
};

StaticShapeData MetalShield
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

StaticShapeData mrtwig
{
	shapeFile = "mrtwig";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Twiggy";
};

//PowerGen Functions

function ConnectGenerator (%this,%client)
{	if($TracePwr) echo("Connect this ",%this," Generator to Power Grid (Client = ",%client,")");
	if(%this.isBusy)
		return;
	%name=GameBase::GetMapName(%this);
	if(!%name)
		%name=GameBase::GetDataName(%this);

	if(GameBase::getDamageState(%this)!="Enabled")
	{	//echo("Backup Generator ",%this," is disabled!!");
		//TeamMessages(0,%team,%name@" DIS-ABLED Unable to come ON Line...~wAAODSFX50.wav");
		return;
	}

	%range = %this.pRange;
	//ItemBusy(%this);
	%team = GameBase::getTeam(%this);
	//echo("Connecting Generator for Team ",%team);
	//echo("Connecting Generator for Client ",$User[%client]);


	if(%this.pset != "")
	{	// Generator has a powerset....refresh it
		%pset=%this.pset;
		//if($tracePwr) echo("Generator ",%this," has a power set (",%pset,") ....Refreshing");
	}
	else	// Generator does not have a powerset Create one & refresh it
	{	%pset=MakePowerSet(%this);
		%this.powerset=getGroup(%this);
		removeFromSet(%this.powerset,%this);
		addtoSet(%pset,%this);
		%this.pset=%pset;
	}
	// Scan for Items to Power
	%set = newObject("set",SimSet);
	%pos =	GameBase::getPosition(%this);
	%tnum = containerBoxFillSet(%set,$StaticObjectType | $StaticShapeType ,%pos,%range,%range,%range,0);
	%td=0;
	if (%tnum>0)
	{	// There are Items within scan range
		if($tracePwr) echo($Ver,"| Generator Checking ",%tnum," items");
		for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%set,%i);
			%tgtTeam=GameBase::getTeam(%tgt);
			if(PowerReq(%tgt))									// Does Item Require Power then check otherwise don't Bother
			{	if(%team==%tgtTeam)								// Is it of the Same Team
				{	if (!GameBase::isPowered(%tgt))				// Has NO Power so Connect to it!
					{	%td+=3;									// Time to hookup = 3 Sec
						if(%tgt.powerSet=="")					// This Item has Not Been previously Connected to a Portable Generator
						{	%tgt.powerSet=getGroup(%tgt);			// If it Had Power Remeber where it Was from
						}
						if($tracePwr) echo($Ver,"|Item Has No Power - Removing from Old group ",%tgt.powerSet," adding to ",%pset);
						schedule("PowerSet("@%this@","@%tgt@");",%td);
					}
				}
			}
		}
	}
	deleteObject(%set);
	//schedule("ItemNotBusy("@%this@");",%td);
	if (%td==0)
	{	if(%client)
			Client::SendMessage(%client,1,"Power Grid Initialized");
		return (false);
	}
	else
		//TeamMessages(0,%team,%name@" coming ON Line...~wAAODSFX50.wav");
	return (true);
}

function ConnectGeneratorSilent (%this,%client)
{	if($TracePwr) echo("Connect this ",%this," Generator to Power Grid (Client = ",%client,")");
	if(%this.isBusy)
		return;
	%name=GameBase::GetMapName(%this);
	if(!%name)
		%name=GameBase::GetDataName(%this);

	if(GameBase::getDamageState(%this)!="Enabled")
	{	//echo("Backup Generator ",%this," is disabled!!");
		//TeamMessages(0,%team,%name@" DIS-ABLED Unable to come ON Line...~wAAODSFX50.wav");
		return;
	}

	%range = %this.pRange;
	//ItemBusy(%this);
	%team = GameBase::getTeam(%this);
	//echo("Connecting Generator for Team ",%team);
	//echo("Connecting Generator for Client ",$User[%client]);


	if(%this.pset != "")
	{	// Generator has a powerset....refresh it
		%pset=%this.pset;
		//if($tracePwr) echo("Generator ",%this," has a power set (",%pset,") ....Refreshing");
	}
	else	// Generator does not have a powerset Create one & refresh it
	{	%pset=MakePowerSet(%this);
		%this.powerset=getGroup(%this);
		removeFromSet(%this.powerset,%this);
		addtoSet(%pset,%this);
		%this.pset=%pset;
	}
	// Scan for Items to Power
	%set = newObject("set",SimSet);
	%pos =	GameBase::getPosition(%this);
	%tnum = containerBoxFillSet(%set,$StaticObjectType | $StaticShapeType ,%pos,%range,%range,%range,0);
	%td=0;
	if (%tnum>0)
	{	// There are Items within scan range
		if($tracePwr) echo($Ver,"| Generator Checking ",%tnum," items");
		for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%set,%i);
			%tgtTeam=GameBase::getTeam(%tgt);
			if(PowerReq(%tgt))									// Does Item Require Power then check otherwise don't Bother
			{	if(%team==%tgtTeam)								// Is it of the Same Team
				{	if (!GameBase::isPowered(%tgt))				// Has NO Power so Connect to it!
					{	%td+=3;									// Time to hookup = 3 Sec
						if(%tgt.powerSet=="")					// This Item has Not Been previously Connected to a Portable Generator
						{	%tgt.powerSet=getGroup(%tgt);			// If it Had Power Remeber where it Was from
						}
						if($tracePwr) echo($Ver,"|Item Has No Power - Removing from Old group ",%tgt.powerSet," adding to ",%pset);
						schedule("PowerSet("@%this@","@%tgt@");",%td);
					}
				}
			}
		}
	}
	deleteObject(%set);
	//schedule("ItemNotBusy("@%this@");",%td);
	if (%td==0)
	{
		return (false);
	}
	else
		//TeamMessages(0,%team,%name@" coming ON Line...~wAAODSFX50.wav");
	return (true);
}

function DisconnectGenerator(%this)
{	if($TracePwr) echo("Disconnecting this ",%this," Generator from Power Grid");
	//	Use when Packing up a Power Generator
	//	& End of Mission
	//	Unhooks everything
	//ItemBusy(%this);
	%pset=%this.pset;
	%name=GameBase::GetMapName(%this);
	if(!%name)
		%name=GameBase::GetDataName(%this);
	%team = GameBase::getTeam(%this);
	%tnum = Group::objectCount(%pset);
	//TeamMessages(1,%team,%name@" Going OFF Line...~wAAODSFX50.wav");
	%td=0;
	if (%tnum>0)
	{	for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%pset,0);
			%td+=2;
			schedule("PowerReset("@%this@","@%tgt@");",%td);
		}
	}
	%td+=1;
	schedule("deleteObject("@%pset@");",%td);
	//schedule("ItemNotBusy("@%this@");",%td,%this);
	return (%td);
}

function RecheckGrid(%this)
{	//if($TracePwr) echo("RE-Connect this ",%this," Generator to Power Grid ");
	// Call When Main Power Source has come back online after a failure
	%mset=getGroup(%this);
	%team=GameBase::getTeam(%this);
	%tnum = Group::objectCount($GenSet[%team]);
	if ($tracePwr) echo($ver,"| Main Gen ",%this," Back on line .. re-routing power from ",%tnum," alternate Generators for Team ",%team);
	if (%tnum>0)
	{	for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject($GenSet[%team],%i);
			%num = Group::objectCount(%tgt.pset);
			if(%num>1)	// If it has more than one object the unit is powering something
			{	for (%j=0;%j<%num;%j++)
				{	%tgt2=Group::getObject(%tgt.pset,%j);
					if(%tgt2.powerset==%mset)	// Object belong in the Power Set for %this which was just restored
					{	removeFromSet(%tgt.pset,%tgt2);
						addToSet(%mset,%tgt2);
						%j--;
						%num--;
					}
				}
			}
		}
	}
}

function EngageBackupPower(%this)
{	if($tracePwr) echo("Engage Backup Power for this ",%this," Generator (It has Been Destroyed or Disabled)");
	%NumFF=0;
	// Call When Main Power has Experienced a failure
	// Check Main Generator Group... If Multiple generators Then Dont Engage Backup
	%Mainset=getGroup(%this);
	%MainNum = Group::objectCount(%MainSet);
	if($tracePwr) echo("Generator Group = ",%MainSet," Number of Items in Group ",%MainNum);
	for (%i=0;%i<%MainNum;%i++)
	{	%tgt=Group::getObject(%MainSet,%i);
		%name = GameBase::getDataName(%tgt);
		%type = GetObjectType(%tgt);
		// if(%name=="" && %type == SimGroup) %name="DoorGroup";
		//if($tracePwr) echo("Checking Item ",%tgt," Item is: ",%Name," Class = ",%name.className," type ",%type);
		if(%name == "Generator" || %name == "SolarPanel" || %name == "PortGenerator")
		{	%result=GameBase::getDamageState(%tgt);
			if(%result==Enabled) %NotReq=True;
		}
		else if(%name=="DoorGroup" || %name.classname == "ForceDoor" || %name.classname == "Door" || %name.classname == "ForceField")
		{	if($TracePwr) echo("Re-Routing ForceField Power for ",%name," Id# ",%tgt);
			%ForceField[%NumFF]=%tgt;
			%NumFF++;
		}
		if(%NotReq==true) %i=%MainNum;
	}

	if(%NotReq) return;
	%team=GameBase::getTeam(%this);
	%tnum = Group::objectCount($GenSet[%team]);
	if ($tracePwr) echo($ver,"| Main Gen ",%this," FAILURE .. ",%tnum," alternate Generators re-checking Grid ",%team);
	%td=0;
	if (%tnum>0)
	{	for (%i=0;%i<%tnum;%i++)
		{	%td+=2;
			%tgt=Group::getObject($GenSet[%team],%i);
			// ForceField Reconnect Routine
			// First Active Generator Gets the ForceFields
			%result=GameBase::getDamageState(%tgt);
			if(GameBase::getDamageState(%tgt) == "Enabled")
			{	for (%j=0;%j<%NumFF;%j++)
				{	%ff=%ForceField[%j];
					%ff.powerSet=getGroup(%ff);			// Remember where it Was from
					PowerSet(%tgt,%ff);
					//schedule("PowerSet("@%tgt@","@%ff@");",5,%ff);
					if ($tracePwr) echo($ver,"| Routing Power for ",%ff," Forcefield to ",GetGroup(%tgt));

				}
			}
			schedule("ConnectGenerator("@%tgt@", false);",%td);
		}
	}
}

function PowerReq(%this)
{
	%name=GameBase::GetDataName(%this);
	if(%this.powerReq==1)
		return true;
	else if(%this.powerReq==false)
		return false;
	else if(%name.classname == "Turret" || %name.classname == "Station" || %name=="PulseSensor" )
		return (true);
	else
		return (false);
}

function MakePowerSet(%this)
{	%SetName ="PG"@%this;
	%pset= newObject(%SetName,SimGroup);
	addToSet("MissionCleanup", %pset);
	//if($tracePwr) echo("Created NEW power set (",%pset,") for Generator ",%this);
	return(%pset);
}

function Powerset(%gen,%object)
{	%gname=GameBase::GetMapName(%gen);
	if(!%gname)
		%gname=GameBase::GetDataName(%gen);
	%pset=%gen.pset;
	%mname = GameBase::getMapName(%object);
	if(%mname=="")
		%mname = GameBase::getDataName(%object);
	%team=GameBase::getTeam(%gen);
	//TeamMessages(0,%team,"Power for "@%mname@" routed to: "@%gname@"~wAAODSFX52.wav");
	%OldSet=getGroup(%object);
	RemoveFromSet(%OldSet,%object);
	%res=AddToSet(%pset,%object);
	//if ($tracePwr) echo("Power for "@%object@" routed to power group "@%pset@" generator "@%gen@" for Team ",%team);
}

function Powerreset(%gen,%object)
{	%gname=GameBase::GetMapName(%gen);
	if(!%gname)
		%gname=GameBase::GetDataName(%gen);
	%pset=%gen.pset;
	%mname = GameBase::getMapName(%object);
	if(%mname=="")
		%mname = GameBase::getDataName(%object);
	%team=GameBase::getTeam(%gen);
	if(%object.powerReq!=2)
		//TeamMessages(0,%team,"Power for "@%mname@" disconnected from "@%gname@"~wAAODSFX52.wav");
	removeFromSet(%pset,%object);
	%res=addToSet(%object.powerSet,%object);
	//if ($tracePwr) echo("Power for ",%object," set to orignal group ",%object.powerSet," from  generator ",%gen," for Team ",%team);
}

function NoPower(%this)
{
   if (%this.ispowerReq == false)
       return;
   %clientId = %this.Owner;
   if(%clientId == "")
       return;
   if(PowerItemSilent(%this,$DeployablePowerRange,%clientId) == true) // Try to look for another generator in range
       return;
}

function PowerItem (%this,%range,%client)
{	//if($TracePwr) echo($ver,"|Looking for POWER for ",%this," in a ",%range," meter area");
	//** Search Area within specified range
	//** If a Main Generator exists Draw power from that
	//** If a portable generator exists Place %this into the power set for it..
    if (%this.ispowerReq == false)
       return;
    %numGen=0;
	%team = GameBase::getTeam(%this);
	%set = newObject("set",SimSet);
	%pos =	GameBase::getPosition(%this);
	%tnum = containerBoxFillSet(%set, $StaticObjectType ,%pos,%range,%range,%range,0);
	//echo(" Number of Objects Found = ",%tnum);
	if (%tnum>0)
	{	// There are Items within scan range
		//if($trace) echo($Ver,"|Scanning ",%tnum," items");
		for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%set,%i);
			%tgtTeam=GameBase::getTeam(%tgt);
			%name = GameBase::getDataName(%tgt);
			if(%team==%tgtTeam || %tgt.Owner == %client)
			{	if(%name == "Generator" || %name == "SolarPanel" || %name == "PortGenerator")
				{	%nset=getGroup(%tgt);
					if(GameBase::getDamageState(%tgt) == "Enabled")
					{	Client::sendMessage(%client,1,"Power Grid Found");
						//if($tracePwr) echo($Ver,"| Found MAIN Generator : Group ",%nset," Placing Unit in Group");
						// %power=true;
                        GameBase::playSequence(%this,0,"power");
						if(%nset)
						{	addToSet(%nset,%this);
							%this.powerset=%nset;
							%i=%tnum;
						}
						%numGen++;
					}
					else if(%nset) %this.powerset=%nset;	// Route Main Connection to Main Power Group...

				}
				else if(%name == "MobileGen" || %name == "PortaSolar" || %name == "PortaSolarBig" || %name == "BigMobileGen")
				{	//if($tracePwr) echo($Ver,"|Found an alternate Power Source.. if needed ",%tgt);

				%Pgen=%tgt;
				}

			}

		}
	}
	deleteObject(%set);
	if (%numGen==0)										// If there are No Main Generators to connect to... then
	{	if(%Pgen)										// If there is a portable Power Source connect to it
		{	//if($trace) echo($Ver,"|Found a Secondary power Generator ",%PGen," Connecting to it");
			Client::sendMessage(%client,1,"Power Grid Found");
			%result=GameBase::getDamageState(%Pgen);	// Check state of Generator
			%nset=getGroup(%Pgen);
			if(%nset)
				addToSet(%nset,%this);
			//if(%result==Enabled)
				// %power=true;
			//else
				// %power=false;
			// GameBase::virtual(%this,"onPower",%power,%Pgen);
            GameBase::playSequence(%this,0,"power");
            return (true);
		}
		else
		{ Client::sendMessage(%client,1,"Unable to Find Power Grid");
            GameBase::stopSequence(%this,0);
            GameBase::startFadeOut(%this);
            %this.Move = false;
            schedule("DeleteClObj(" @ %client @ "," @ %this @ ");", 2.4, %this);
            schedule("RemoveFromObjIndex(" @ %client @ "," @ %this @ ");", 2.4, %client);
            //GameBase::SetActive(%obj,false);
            return (false);
		}

	}
	return (true);
}

function PowerItemSilent(%this,%range,%client)
{	//if($TracePwr) echo($ver,"|Looking for POWER for ",%this," in a ",%range," meter area");
    if (%this.ispowerReq == false)
        return;
    %numGen=0;
	%team = GameBase::getTeam(%this);
	%set = newObject("set",SimSet);
	%pos =	GameBase::getPosition(%this);
	%tnum = containerBoxFillSet(%set, $StaticObjectType ,%pos,%range,%range,%range,0);
	//echo(" Number of Objects Found = ",%tnum);
	if (%tnum>0)
	{	// There are Items within scan range
		//if($trace) echo($Ver,"|Scanning ",%tnum," items");
		for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%set,%i);
			%tgtTeam=GameBase::getTeam(%tgt);
			%name = GameBase::getDataName(%tgt);
			if(%team==%tgtTeam || %tgt.Owner == %client)
			{	if(%name == "Generator" || %name == "SolarPanel" || %name == "PortGenerator")
				{	%nset=getGroup(%tgt);
					if(GameBase::getDamageState(%tgt) == "Enabled")
					{
						//if($tracePwr) echo($Ver,"| Found MAIN Generator : Group ",%nset," Placing Unit in Group");
						// %power=true;
                        GameBase::playSequence(%this,0,"power");
						if(%nset)
						{	addToSet(%nset,%this);
							%this.powerset=%nset;
							%i=%tnum;
						}
						%numGen++;
					}
					else if(%nset) %this.powerset=%nset;	// Route Main Connection to Main Power Group...

				}
				else if(%name == "MobileGen" || %name == "PortaSolar" || %name == "PortaSolarBig" || %name == "BigMobileGen")
				{	//if($tracePwr) echo($Ver,"|Found an alternate Power Source.. if needed ",%tgt);

				%Pgen=%tgt;
				}

			}

		}
	}
	deleteObject(%set);
	if (%numGen==0)										// If there are No Main Generators to connect to... then
	{	if(%Pgen)										// If there is a portable Power Source connect to it
		{	//if($trace) echo($Ver,"|Found a Secondary power Generator ",%PGen," Connecting to it");
			%result=GameBase::getDamageState(%Pgen);	// Check state of Generator
			%nset=getGroup(%Pgen);
			if(%nset)
				addToSet(%nset,%this);
			//if(%result==Enabled)
				// %power=true;
			//else
				// %power=false;
			// GameBase::virtual(%this,"onPower",%power,%Pgen);
            GameBase::playSequence(%this,0,"power");
            return (true);
		}
		else
		{
            GameBase::stopSequence(%this,0);
            GameBase::startFadeOut(%this);
            %this.Move = false;
            schedule("DeleteClObj(" @ %client @ "," @ %this @ ");", 2.4, %this);
            schedule("RemoveFromObjIndex(" @ %client @ "," @ %this @ ");", 2.4, %client);
            //GameBase::SetActive(%obj,false);
            return (false);
		}

	}
	return (true);
}

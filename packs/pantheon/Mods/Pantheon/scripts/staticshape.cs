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
	%client = GameBase::getControlClient(%this.lastDamageObject);	
	%objectName = GameBase::getDataName(%this);
	%objectTeam = GameBase::getTeam(%this);
	%playerTeam = GameBase::getTeam(%client);
	if (%objectTeam == %playerTeam)
	{
		if (%objectName == "RemoteSolarPanel" || %objectName == "SolarPanel")
		{
			bottomprint(%client, "You lose 1 point for destroying your own solar panel!");
			%client.Score -= 1;
			%client.Objectives -= 1;
			Game::refreshClientScore(%client);
			if (%objectName == "RemoteSolarPanel")
			{
				$TeamItemCount[%objectTeam @ "DeployableSolarPanel"]--;
			}
		}
		else
		{
			bottomprint(%client, "You lose 1 point for destroying your own generator!");
			%client.Score -= 1;
			%client.Objectives -= 1;
			Game::refreshClientScore(%client);
		}
	}
	else if (%objectTeam != %playerTeam)
	{
		if (%objectName == "RemoteSolarPanel" || %objectName == "SolarPanel")
		{
			bottomprint(%client, "You get 1 point for destroying the enemy's solar panel.");
			%client.Score += 1;
			%client.Objectives += 1;
			Game::refreshClientScore(%client);
			if (%objectName == "RemoteSolarPanel")
			{
				$TeamItemCount[%objectTeam @ "DeployableSolarPanel"]--;
			}
		}
		else
		{
			bottomprint(%client, "You get 1 point for destroying the enemy generator.");
			%client.Score += 1;
			%client.Objectives += 1;
			Game::refreshClientScore(%client);
		}		
	}
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

StaticShapeData RemoteSolarPanel
{
	description = "Deployable Solar Panel";
	shapeFile = "solar_med";
	className = "Generator";
	debrisId = flashDebrisMedium;
	maxDamage = 1.2;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpLarge;
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

StaticShapeData OutpostGen
{
	description = "Outpost Generator";
	shapeFile = "generator_p";
//	className = "Generator";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundGeneratorPower;
	maxDamage = 8.0;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
};

function OutpostGen::onDestroyed(%this)
{
  StaticShape::onDestroyed(%this);
  $TeamItemCount[GameBase::getTeam (%this) @ "OutpostPack"]--;
  CalcRadiusDamage (%this, $DebrisDamageType, 2.5, 0.05, 25, 25, 20, 75, 50, 200, 100);

}

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

// Deployable Forcefield 

StaticShapeData DeployableForceField
{
	shapeFile = "forcefield_3x4";
	debrisId = defaultDebrisSmall;
	maxDamage = 4.50;
	visibleToSensor = true;
	isTranslucent = true;
   	description = "Small Force Field";
	triggerRadius = 1.0;
};

function DeployableForceField::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldPack"]--;
	
}
//=-=-=-----------------------------------------------------------------
StaticShapeData LargeForceField
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 5.00;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Large Force Field";
	triggerRadius = 2.0;
};

function LargeForceField::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldPack"]--;
	
}

//=-=-=-----------------------------------------------------------------

StaticShapeData BlastWall
{
	shapeFile = "newdoor5";
	maxDamage = 7.0;
	debrisId = defaultDebrisLarge;
	visibleToSensor = true;
	isTranslucent = true;
	explosionId = debrisExpLarge;
	description = "Blast Wall";
	triggerRadius = 2.0;
};

function BlastWall::onDestroyed(%this)
{
  $TeamItemCount[GameBase::getTeam (%this) @ "BlastwallPack"]--;
}

//=-=-=-----------------------------------------------------------------

//=-=-=-=-=-
StaticShapeData DeployablePlatform
{
	shapeFile = "elevator_9x9";
	debrisId = defaultDebrisSmall;
	maxDamage = 6.00;
	visibleToSensor = true;
	isTranslucent = false;
   	description = "Deployable Platform";
	triggerRadius = 2.0;
};

function DeployablePlatform::onDestroyed(%this)
{
   $TeamItemCount[GameBase::getTeam(%this) @ "PlatformPack"]--;
	
}
//=-=-=- TREES
StaticShapeData DeployableTree
{
	shapeFile = "tree1";
	debrisId = defaultDebrisSmall;
	maxDamage = 6.50;
	visibleToSensor = false;
	isTranslucent = true;
   	description = "Deployable Tree";
	triggerRadius = 1.0;
};

function DeployableTree::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--;
	
}

StaticShapeData DeployableTree2
{
	shapeFile = "tree2";
	debrisId = defaultDebrisSmall;
	maxDamage = 6.50;
	visibleToSensor = false;
	isTranslucent = true;
   	description = "Deployable Tree";
	triggerRadius = 1.0;
};

function DeployableTree2::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--;
	
}

//=-=-=-=-=- Teleporter =-=-=-=-
StaticShapeData DeployableTeleport
{
	className = "DeployableTeleport";
	damageSkinData = "objectDamageSkins";

	shapeFile = "flagstand";
	maxDamage = 2.5;
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

function DeployableTeleport::Destruct(%this)
{
    //CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);
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
		Client::SendMessage(%c,0,"Wrong team");
		return;
	}

	if (%obj.carryFlag)
	{
		%flagobj = Player::getMountedItem(%obj, 2);
		Player::dropItem(%obj, %flagobj);
		Client::SendMessage(%c,0,"You can't teleport with a flag.");
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
			if((Player::getArmor(%obj) == "aarmor"))
			{
				if(Player::getMountedItem(%c,$BackpackSlot) == FgcPack)
				{
					Client::SendMessage(%c,0,"Cannot teleport with the FGC Pack");
					return;
				}
				if(Player::getMountedItem(%c,$BackpackSlot) == SuicidePack)
				{
					Client::SendMessage(%c,0,"Cannot teleport with the Nuke Pack");
					return;
				}
			}
			GameBase::playSound(%o,ForceFieldOpen,0);
			GameBase::playSound(%this,ForceFieldOpen,0);
			GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
			%o.Disabled = true;
			%this.Disabled = true;
			if((Player::getArmor(%obj) == "sarmor"))
			{
				schedule("DeployableTeleport::Reenable("@%this@");",2);
				schedule("DeployableTeleport::Reenable("@%o@");",2);
			}
			else if((Player::getArmor(%obj) == "fsarmor"))
			{
				schedule("DeployableTeleport::Reenable("@%this@");",2);
				schedule("DeployableTeleport::Reenable("@%o@");",2);
			}
			else if((Player::getArmor(%obj) == "larmor"))
			{
				schedule("DeployableTeleport::Reenable("@%this@");",3);
				schedule("DeployableTeleport::Reenable("@%o@");",3);
			}
			else if((Player::getArmor(%obj) == "lfemale"))
			{
				schedule("DeployableTeleport::Reenable("@%this@");",3);
				schedule("DeployableTeleport::Reenable("@%o@");",3);
			}
			else if((Player::getArmor(%obj) == "marmor"))
			{
				schedule("DeployableTeleport::Reenable("@%this@");",7);
				schedule("DeployableTeleport::Reenable("@%o@");",7);
			}
			else if((Player::getArmor(%obj) == "mfemale"))
			{
				schedule("DeployableTeleport::Reenable("@%this@");",7);
				schedule("DeployableTeleport::Reenable("@%o@");",7);
			}
			else if((Player::getArmor(%obj) == "harmor"))
			{
				schedule("DeployableTeleport::Reenable("@%this@");",10);
				schedule("DeployableTeleport::Reenable("@%o@");",10);
			}
			else if((Player::getArmor(%obj) == "aarmor"))
			{
				schedule("DeployableTeleport::Reenable("@%this@");",15);
				schedule("DeployableTeleport::Reenable("@%o@");",15);
			}
			else
			{
				schedule("DeployableTeleport::Reenable("@%this@");",5);
				schedule("DeployableTeleport::Reenable("@%o@");",5);
			}
			return;
		}
	}
	Client::SendMessage(%c,0,"No other pad to teleport to");
}

function DeployableTeleport::Reenable(%this)
{
	%this.disabled = false;
}

//---------------------------------------------------------------------

StaticShapeData DeployableTeleportDecoy
{
	className = "DeployableTeleportDecoy";
	damageSkinData = "objectDamageSkins";

	shapeFile = "flagstand";
	maxDamage = 2.5;
	maxEnergy = 200;

   	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;

	lightRadius = 12.0;
	lightType = 2;
	lightColor = {1.0,0.2,0.2};
};

function DeployableTeleportDecoy::onDestroyed(%this)
{
	schedule("RemoveBeam("@%this.beam1@");",1);
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableTeleportDecoy"]--;
	$TeamItemCount[GameBase::getTeam(%this) @ "TeleportDecoyPack"]--;
//	%teleset = nameToID("MissionCleanup/Teleports");

//	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
//	{
//		if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this)
//		{
//		        GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
//			return;
//		}
//	}
}

function DeployableTeleportDecoy::onCollision(%this,%obj)
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
	else
	{
		Client::SendMessage(%c,0,"This is a decoy.");
	}
}

StaticShapeData DeployableSpring
{
  shapeFile = "flagstand";
  debrisId = defaultDebrisSmall;
  maxDamage = 1.50;
  visibleToSensor = false;
  isTranslucent = true;
  description = "Deployable Spring";
};

function DeployableSpring::onDestroyed (%this)
{
  StaticShape::onDestroyed (%this);
  $TeamItemCount[GameBase::getTeam (%this) @ "SpringPack"]--;
}

function DeployableSpring::onCollision (%this, %obj)
{
	%c = Player::getClient (%obj);
	if (floor (getRandom () * 30) == 0)
	{
		GameBase::playSound (%this, debrisLargeExplosion, 0);
		%velocity = 4000;
		%zVec = 1700;
		%rnd = floor (getRandom () * 3);
		if (%rnd == 0)
		{
			MessageAll (0, strcat (Client::getName (%c), " takes a trip into outer space"));
		}
		else if (%rnd == 1)
		{
			MessageAll (0, strcat (Client::getName (%c), " visits the moon"));
		}
      		else if (%rnd == 2)
		{
			MessageAll (0, strcat (Client::getName (%c), " falls off the edge of the earth"));
		}
	}
	else if (floor (getRandom () * 7) == 0)
	{
		GameBase::playSound (%this, debrisLargeExplosion, 0);
		%velocity = 400;
		%zVec = 1700;
	}
	else
	{
		GameBase::playSound (%this, SoundFireMortar, 0);
		%velocity = 200;
		%zVec = 600;
	}
	%jumpDir = Vector::getFromRot (GameBase::getRotation (%obj), %velocity, %zVec);
	Player::applyImpulse (%obj, %jumpDir);
}

StaticShapeData AlarmKit
{
	description = "Base Alarm";
	shapeFile = "sensor_small";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundBeaconActive;
	maxDamage = 0.5;
	mapIcon = "M_marker";
	damageSkinData = "objectDamageSkins";
	visibleToSensor = true;
	triggerRadius = 10.0;
};

function AlarmKit::onCollision(%this, %object)
{
	%type = getObjectType(%object);
	if (%type == "Player" && !$pause)
	{
		$pause = 1;
		schedule("$pause = 0;",10,%this);
		%name = Player::getClient(%object);
		%name = Client::getName(%name);
		%team = GameBase::getTeam(%object);
		%itemTeam = GameBase::getTeam(%this);

		if(%team != %itemTeam)
		{
			TeamMessages(1, %itemTeam,GameBase::GetMapName(%this) @ " has been tripped by " @ %name @ "~wLeftMissionArea.wav");
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

StaticShapeData SniperPad
{
	description = "Sniper Pad";
	shapeFile = "elevator_8x8";
	debrisId = defaultDebrisLarge;
	maxDamage = 8.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	mapFilter = 4;
};

function SniperPad::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "SniperPadPack"]--;
} 

StaticShapeData OutpostFloor
{
	description = "Outpost Floor";
	shapeFile = "elevator16x16_octo";
	debrisId = defaultDebrisLarge;
	maxDamage = 10.0;
//	damageSkinData = "objectDamageSkins";
//	shadowDetailMask = 16;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
//	mapFilter = 4;
};


StaticShapeData ForceFieldDoorShape
{
  description = "Force Field Door";
  className = "LargeForceField";
  damageSkinData = "objectDamageSkins";
  shapeFile = "forcefield_4x8";
  maxDamage = 8.0;
  maxEnergy = 15;
  mapFilter = 2;
  visibleToSensor = true;
  explosionId = mortarExp;
  debrisId = flashDebrisLarge;
  lightRadius = 12.0;
  lightType = 2;
  lightColor = { 1.0, 0.2, 0.2 };
  side = "single";
  isTranslucent = true;
};

function ForceFieldDoorShape::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldDoorPack"]--;
}

function ForceFieldDoorShape::onCollision(%this, %obj)
{
	if (getObjectType(%obj) != "Player" || Player::isDead(%obj) || %this.opening == true)
	{
		return false;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if (%fieldTeam != %playerTeam)
	{
		return false;
	}
	ForceFieldDoorShape::openDoor(%this);
	return false;
}

function ForceFieldDoorShape::openDoor(%this)
{
	GameBase::startfadeout(%this);
	%this.opening = true;
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, "0 0 2000");
	schedule("GameBase::setPosition(" @ %this @ ",\"" @ %pos @ "\");", 0.5, %this);
	schedule("GameBase::playSound(" @ %this @ ",ForceFieldOpen,0);", 0.1, %this);
	schedule("ForceFieldDoorShape::closeDoor(" @ %this @ ");", 3.5, %this);
}
function ForceFieldDoorShape::closeDoor(%this)
{
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, "0 0 -2000");
	GameBase::setPosition(%this, %pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound(" @ %this @ ",ForceFieldClose,0);", 0.15);
	%this.opening = false;
}

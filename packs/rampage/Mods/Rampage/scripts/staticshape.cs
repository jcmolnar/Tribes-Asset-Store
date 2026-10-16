//------------------------------------------------------------------------
// Generic static shapes
//------------------------------------------------------------------------


//------------------------------------------------------------------------
// Default power animation behavior for all static shapes

function StaticShape::onPower(%this,%power,%generator)
{
	if(%power) 
		GameBase::playSequence(%this,0,"power");
	else 
		GameBase::stopSequence(%this,0);
}

function StaticShape::onEnabled(%this)
{
	if(GameBase::isPowered(%this)) 
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
//plasmatic
function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%client = Player::getClient(%object);
	%name = GameBase::getDataName(%this);
	//w00t, more Plasmatic's coolness
	if(GameBase::getDamageState(%this) == "Destroyed") return;
	if($Annihilation::SafeBase && (%name.className == Generator || %name.className == Station))
	{
		// no damage, just play a shield.
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
		%zOffset = (%pointZ-%centerPosZ) * 1.0 + 0.1;
		GameBase::activateShield(%this,%sphereVec,0.1);
		return;
	}
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	%objTeam = GameBase::getTeam(%object);
	%thisTeam = GameBase::getTeam(%this);
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
	if(GameBase::getDamageState(%this) == "Destroyed" || GameBase::getTeam(%client) == GameBase::getTeam(%this))
	{ 
		%Check = 1;
	}
	GameBase::setDamageLevel(%this,%dValue);
	if(%Check != 1 && GameBase::getDamageState(%this) == "Destroyed") 
	{
		echo("GAME: " @ Client::getName(%client) @ " Destroyed ", %name.className);
		if((%name.classname == "Turret" || %name.classname == "Generator") && %this.LastRepairCl !=  %client)
		{
			bottomprint(%client, "<jc>You have just recieved <f1> 1 <f0> point for destroying a "@ %name.className);
			echo("MSG: ", %client, " Destroyed ", %name.className);
			%client.score++;
			%pwr = GameBase::isPowered(%this);
			if(%name.classname == "Generator")
				if((!%pwr) && ($ixRepairTeam[%thisTeam] != %objTeam))
					schedule("CheckPowerObjective(" @ %object @ "," @ %thisTeam @ "," @ $ixTeamPower[%thisTeam]++ @ ",1);",30);
			Game::refreshClientScore(%client);
		}
	}
	
	if(%Check == 1 && GameBase::getDamageState(%this) == "Destroyed") 
	{
		echo("GAME: " @ Client::getName(%client) @ " Destroyed ", %name.className@" deployed by "@Client::getName(%this.deployer));
		if((%name.classname == "Turret" || %name.classname == "Generator") && %this.deployer != %client)
		{
			bottomprint(%client, "<jc>You have just LOST <f1> 1 <f0> POINT for destroying your teams "@ %name.className);
			echo("MSG: ", %client, " Destroyed a team ", %name.className);
			if(%this.deployer)DropshipTeamMessage(GameBase::getTeam(%client), 3, Client::getName(%client)@" has destroyed "@Client::getName(%this.deployer)@"'s "@ %name.className);
			%client.score--;
			Game::refreshClientScore(%client);
		}
		%obj.deployer = "";//plasmatic
	}
	
}

function CheckPowerObjective(%client, %team, %powerChange, %type)
{
	if($ixTeamPower[%team] == %powerChange)
	{
		if(%type)
		{
			if(GameBase::getTeam(%client) != %team)
			{
				%client.score+=2;
				Game::refreshClientScore(%client);
				bottomprint(%client, "<jc>You receive <f1> 2 <f0> points for Destroying the Enemy's Power!");
				messageTeamExcept(%client, 0, Client::getName(%client) @ " received 2 points for Destroying the Enemy's Power!");
				PowerTeamMessage(%team, 1,"   <jl><bitem_damaged.bmp>   Your teams generators have been destroyed by "@Client::getName(%client)@"!!","Your gens have been destroyed by "@Client::getName(%client));
				echo("team "@%team@"'s power destroyed by "@Client::getName(%client));
			}	
		}
		else if(GameBase::getTeam(%client) == %team)
		{
			%client.score+=3;
			Game::refreshClientScore(%client);
			bottomprint(%client, "<jc>You receive <f1> 3 <f0> points for Restoring your Team's Power!");
			messageTeamExcept(%client, 0, Client::getName(%client) @ " received 3 points for Restoring your Team's Power!");
			PowerTeamMessage(%team, 1,"   <jl><bitem_ok.bmp>   Generators have been repaired by "@Client::getName(%client)@".",Client::getName(%client)@" repaired Your generators.");
			echo("team "@%team@"'s power restored by "@Client::getName(%client));
		}
			
	}
}
function PowerTeamMessage(%team, %color, %msg,%chat)
{
//	%team = Client::getTeam(%client);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%cl = getClientByIndex(%i);
		%now = Client::getTeam(%cl);
		if(%team == %now)
		{
			Client::sendMessage(%cl,%color,%chat);
			bottomprint(%cl, %msg,15);
		}
	}
}
function StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	if(%this.shieldStrength)
	{
		%energy = GameBase::getEnergy(%this);
		%strength = %this.shieldStrength;
		if(%type == $ShrapnelDamageType)
			%strength *= 0.5;
		else
			if(%type == $MortarDamageType)
				%strength *= 0.25;
			else
				if(%type == $BlasterDamageType)
					%strength *= 2.0;
		%absorb = %energy * %strength;
		if(%value < %absorb)
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

function calcRadiusDamage(%this,%type,%radiusRatio,%damageRatio,%forceRatio, %rMax,%rMin,%dMax,%dMin,%fMax,%fMin) 
	{ 
	%radius = GameBase::getRadius(%this); 
	if(%radius) 
	{ 
	%radius *= %radiusRatio; 
	%damageValue = %radius * %damageRatio; 
	%force = %radius * %forceRatio; 
	if(%radius > %rMax) 
	%radius = %rMax; 
	else 
	if(%radius < %rMin) 
	%radius = %rMin; 
	if(%damageValue > %dMax) 
	%damageValue = %dMax; 
	else 
	if(%damageValue < %dMin) 
	%damageValue = %dMin; 
	if(%force > %fMax) 
	%force = %fMax; 
	else 
	if(%force < %fMin) 
	%force = %fMin; 
	GameBase::applyRadiusDamage(%type,getBoxCenter(%this), %radius, %damageValue,%force,%this); 
	} 
	}
 
StaticShapeData FlagStand 
	{ 
	description = "Flag Stand"; 
	shapeFile = "flagstand"; 
	visibleToSensor = false; 
	};
 
function FlagStand::onDamage() { } 

//------------------------------------------------------------------------
// Generators
//------------------------------------------------------------------------

function Generator::onEnabled(%this)
{
	GameBase::setActive(%this,true);
	RecheckGrid(%this);
}

function Generator::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
 	EngageBackupPower(%this);
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
	shieldShapeName = "shield_medium";
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
	shieldShapeName = "shield_medium";
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
	shieldShapeName = "shield";
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
};

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
      %flag = %this.carryflag;
      if(%flag != "")
	{
	%flag.flagstand = "";
	schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	}
	}

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

function LargeAntenna::onDestroyed(%this) 
	{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "BuilderPole"]--; 
	} 

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

StaticShapeData SquarePanel 
	{ 
	shapeFile = "teleport_square"; 
	debrisId = flashDebrisSmall; 
	maxDamage = 0.3; 
	damageSkinData = "objectDamageSkins"; 
	explosionId = flashExpMedium; 
	description = "Panel"; 
	}; 

StaticShapeData VerticalPanel 
	{ 
	shapeFile = "teleport_vertical"; 
	debrisId = defaultDebrisSmall; 
	explosionId = debrisExpMedium; 
	maxDamage = 0.5; 
	damageSkinData = "objectDamageSkins"; 
	description = "Panel"; 
	}; 

StaticShapeData BluePanel 
	{ 
	shapeFile = "panel_blue"; 
	debrisId = flashDebrisSmall; 
	explosionId = flashExpMedium; 
	maxDamage = 0.5; 
	damageSkinData = "objectDamageSkins"; 
	description = "Panel"; 
	}; 

StaticShapeData YellowPanel 
	{ 
	shapeFile = "panel_yellow"; 
	debrisId = defaultDebrisSmall; 
	explosionId = debrisExpMedium; 
	maxDamage = 0.5; 
	damageSkinData = "objectDamageSkins"; 
	description = "Panel"; 
	}; 

StaticShapeData SetPanel 
	{ 
	shapeFile = "panel_set"; 
	debrisId = flashDebrisSmall; 
	explosionId = flashExpMedium; 
	maxDamage = 0.5; 
	damageSkinData = "objectDamageSkins"; 
	description = "Panel"; 
	}; 

StaticShapeData VerticalPanelB 
	{ 
	shapeFile = "panel_vertical"; 
	debrisId = defaultDebrisSmall; 
	explosionId = debrisExpMedium; 
	maxDamage = 0.5; 
	damageSkinData = "objectDamageSkins"; 
	description = "Panel"; 
	}; 

StaticShapeData DisplayPanelOne 
	{ 
	shapeFile = "display_one"; 
	debrisId = flashDebrisSmall; 
	explosionId = flashExpMedium; 
	maxDamage = 0.5; 
	damageSkinData = "objectDamageSkins"; 
	description = "Panel"; 
	}; 

StaticShapeData DisplayPanelTwo 
	{ 
	shapeFile = "display_two"; 
	debrisId = defaultDebrisSmall; 
	explosionId = debrisExpMedium; 
	maxDamage = 0.5; 
	damageSkinData = "objectDamageSkins"; 
	description = "Panel"; 
	}; 

StaticShapeData DisplayPanelThree 
	{ 
	shapeFile = "display_three"; 
	debrisId = flashDebrisSmall; 
	explosionId = flashExpMedium; 
	maxDamage = 0.5; 
	damageSkinData = "objectDamageSkins"; 
	description = "Panel"; 
	}; 

StaticShapeData HOnePanel 
	{ 
	shapeFile = "dsply_h1"; 
	debrisId = defaultDebrisSmall; 
	explosionId = debrisExpMedium; 
	maxDamage = 0.5; 
	damageSkinData = "objectDamageSkins"; 
	description = "Panel"; 
	}; 

StaticShapeData HTwoPanel 
	{ 
	shapeFile = "dsply_h2"; 
	debrisId = flashDebrisSmall; 
	explosionId = flashExpMedium; 
	maxDamage = 0.5; 
	damageSkinData = "objectDamageSkins"; 
	description = "Panel"; 
	}; 

StaticShapeData SOnePanel 
	{ 
	shapeFile = "dsply_s1"; 
	debrisId = defaultDebrisSmall; 
	explosionId = debrisExpMedium; 
	maxDamage = 0.5; 
	damageSkinData = "objectDamageSkins"; 
	description = "Panel"; 
	}; 

StaticShapeData STwoPanel 
	{ 
	shapeFile = "dsply_s2"; 
	debrisId = flashDebrisSmall; 
	explosionId = flashExpMedium; 
	maxDamage = 0.5; 
	damageSkinData = "objectDamageSkins"; 
	description = "Panel"; 
	}; 

StaticShapeData VOnePanel 
	{ 
	shapeFile = "dsply_v1"; 
	debrisId = defaultDebrisSmall; 
	explosionId = debrisExpMedium; 
	maxDamage = 0.5; 
	damageSkinData = "objectDamageSkins"; 
	description = "Panel"; 
	}; 

StaticShapeData VTwoPanel 
	{ 
	shapeFile = "dsply_v2"; 
	debrisId = flashDebrisSmall; 
	explosionId = flashExpMedium; 
	maxDamage = 0.5; 
	damageSkinData = "objectDamageSkins"; 
	description = "Panel"; 
	}; 

StaticShapeData ForceField 
	{ 
	shapeFile = "forcefield"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 10000.0; 
	isTranslucent = true; 
	description = "Force Field"; 
	}; 

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
	else GameBase::startFadeOut(%this); 
	} 

StaticShapeData Cactus1 
	{ 
	shapeFile = "cactus1"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 8.0; 
	description = "Cactus"; 
	visibleToSensor = true;  
	}; 

StaticShapeData Cactus2 
	{ 
	shapeFile = "cactus2"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 8.0; 
	description = "Cactus"; 
	visibleToSensor = true; 
	}; 

StaticShapeData Cactus3 
	{ 
	shapeFile = "cactus3"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 8.0; 
	description = "Cactus"; 
	visibleToSensor = true; 
	}; 

StaticShapeData SteamOnGrass 
	{ 
	shapeFile = "steamvent_grass"; 
	maxDamage = 999.0; 
	isTranslucent = "True"; 
	description = "Steam Vent"; 
	}; 

StaticShapeData SteamOnMud 
	{ 
	shapeFile = "steamvent_mud"; 
	maxDamage = 999.0; 
	isTranslucent = "True"; 
	description = "Steam Vent"; 
	}; 

StaticShapeData TreeShape 
	{ 
	shapeFile = "tree1"; 
	maxDamage = 20.0; 
	isTranslucent = "True"; 
	description = "Tree"; 
	}; 

StaticShapeData TreeShapeTwo 
	{ 
	shapeFile = "tree2"; 
	maxDamage = 20.0; 
	isTranslucent = "True"; 
	description = "Tree"; 
	}; 

StaticShapeData SteamOnGrass2 
	{ 
	shapeFile = "steamvent2_grass"; 
	maxDamage = 999.0; 
	isTranslucent = "True"; 
	}; 

StaticShapeData SteamOnMud2 
	{ 
	shapeFile = "steamvent2_mud"; 
	maxDamage = 999.0; 
	isTranslucent = "True"; 
	description = "Steam Vent"; 
	}; 

StaticShapeData PlantOne 
	{ 
	shapeFile = "plant1"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 8.0; 
	description = "Plant";
	visibleToSensor = true;  
	}; 

StaticShapeData PlantTwo 
	{ 
	shapeFile = "plant2"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 8.0; 
	description = "Plant";
	visibleToSensor = true;  
	}; 

StaticShapeData PlantThree 
	{ 
	shapeFile = "bigtwig"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 8.0; 
	description = "Plant";
	visibleToSensor = true;  
	}; 

StaticShapeData DeployableForceField 
	{ 
	shapeFile = "forcefield_5x5"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 25; 
	visibleToSensor = true; 
	isTranslucent = true; 
	description = "Force Field"; 
	}; 

function DeployableForceField::onDestroyed(%this) 
	{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldPack"]--; 
	}
 
StaticShapeData MediumForceField 
	{ 
	shapeFile = "forcefield_4x8"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 35; 
	visibleToSensor = true; 
	isTranslucent = true; 
	description = "Force Field"; 
	}; 

function MediumForceField::onDestroyed(%this) 
	{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "PortGenPack"]--; 
	} 

StaticShapeData LargeForceField 
	{ 
	shapeFile = "forcefield"; 
	debrisId = defaultDebrisLarge; 
	maxDamage = 40.00; 
	visibleToSensor = true; 
	isTranslucent = true; 
	description = "Force Field"; 
	}; 

function LargeForceField::onDestroyed(%this) 
	{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldPack"]--; 
	} 

StaticShapeData BlastWall 
	{ 
	shapeFile = "newdoor5"; 
	maxDamage = 60.0; 
	visibleToSensor = true; 
	debrisId = defaultDebrisLarge; 
	explosionId = debrisExpLarge;
      }; 

function BlastWall::onDestroyed(%this) 
	{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "TripwirePack"]--; 
	} 

StaticShapeData DeployablePlatform 
	{ 
	shapeFile = "elevator_5x5"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 25.00; 
	visibleToSensor = true; 
	isTranslucent = true; 
	description = "Deployable Platform"; 
	}; 

function DeployablePlatform::onDestroyed(%this) 
	{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "PlatformPack"]--; 
	} 

StaticShapeData LargePlatform 
	{ 
	shapeFile = "elevator16x16_octo"; 
	maxDamage = 80.0; 
	visibleToSensor = true; 
	debrisId = defaultDebrisLarge; 
	explosionId = debrisExpLarge; 
	}; 

function LargePlatform::onDestroyed(%this) 
	{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "LrgPltPack"]--; 
	} 

StaticShapeData MediumPlatform 
	{ 
	shapeFile = "elevator_8x8"; 
	maxDamage = 40.0; 
	visibleToSensor = true; 
	debrisId = defaultDebrisLarge; 
	explosionId = debrisExpLarge; 
	isTranslucent = true; 
	}; 

function MediumPlatform::onDestroyed(%this) 
	{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "MedPlatform"]--; 
	} 


StaticShapeData DeployableTree 
	{ 
	shapeFile = "tree1"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 40.0; 
	visibleToSensor = false; 
	isTranslucent = true; 
	description = "Deployable Tree"; 
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
	maxDamage = 40.0; 
	visibleToSensor = false; 
	isTranslucent = true; 
	description = "Deployable Tree"; 
	}; 

function DeployableTree::onDestroyed(%this) 
	{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--; 
	} 

StaticShapeData DeployableCactus2 
	{ 
	shapeFile = "cactus2"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 8.0; 
	description = "Cactus";
	visibleToSensor = true;  
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
	if(%teleTeam != %playerTeam) 
	{
	} 
	if(GameBase::getDamageLevel(%obj)) 
	{ 
	GameBase::repairDamage(%obj,0.3); 
	GameBase::playSound(%this,ForceFieldOpen,0); 
	} 
	$poisonTime[%c] = 0; 
	} 

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

StaticShapeData DeployableTeleport 
	{ 
	className = "DeployableTeleport"; 
	damageSkinData = "objectDamageSkins"; 
	shapeFile = "enerpad"; 
	maxDamage = 3.75; 
	maxEnergy = 200; 
	mapFilter = 2; 
	visibleToSensor = true; 
	explosionId = mortarExp; 
	debrisId = flashDebrisLarge; 
	lightRadius = 12.0; 
	lightType=2; 
	lightColor = {1.0,0.2,0.2}; 
	}; 

function RemoveBeam(%b) {deleteObject(%b);} 

function DeployableTeleport::Destruct(%this) { } 

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
	if((Player::getArmor(%obj) == "barmor") || (Player::getArmor(%obj) == "bfemale")) 
	Client::SendMessage(%c,1,"Phased through enemy teleporter"); 
	else 
	{ 
	Client::SendMessage(%c,1,"Wrong Team"); 
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
	if((Player::getArmor(%obj) == "darmor") || (Player::getArmor(%obj) == "darmor")) 
	{ 
	Client::SendMessage(%c,1,"Cannot teleport in this character class~wmine_act.wav"); 
	return; 
	} 
	else 
	{ 
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
	Client::SendMessage(%c,1,"*No other pad to teleport to*"); 
	} 

function DeployableTeleport::Reenable(%this) 
	{ 
	%this.disabled = false; 
	} 

StaticShapeData DeployableSpring 
	{ 
	shapeFile = "flagstand"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 1.75; 
	visibleToSensor = false; isTranslucent = true; description = "Deployable Spring"; 
	}; 

function DeployableSpring::onDestroyed(%this) 
	{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "SpringPack"]--; 
	} 

function DeployableSpring::onCollision(%this,%obj) 
	{ 
	%c = Player::getClient(%obj); 
	if (floor(getRandom() * 30) == 0) 
	{ 
	GameBase::playSound(%this, debrisLargeExplosion, 0); 
	Client::SendMessage(%c, 3, "Sprung [1000m at 75 MPH]"); 
	%velocity = 4000; 
	%zVec = 1700; 
	%rnd = floor(getRandom() * 3); 
	if (%rnd == 0) 
	{ 
	MessageAll(0,strcat(Client::getName(%c), " takes a trip into outer space")); 
	} 
	else if (%rnd == 1) 
	{ 
	MessageAll(0,strcat(Client::getName(%c), " visits the moon")); 
	} 
	else if (%rnd == 2) 
	{ 
	MessageAll(0,strcat(Client::getName(%c), " falls off the edge of the earth")); 
	} 
	} 
	else if (floor(getRandom() * 7) == 0) 
	{ 
	GameBase::playSound(%this, debrisLargeExplosion, 0); 
	Client::SendMessage(%c, 3, "Sprung [2000m at 125 MPH]"); 
	%velocity = 400; 
	%zVec = 1700; 
	} 
	else 
	{ 
	GameBase::playSound(%this, SoundFireMortar, 0); 
	Client::SendMessage(%c, 3, "Sprung [150m at 20 MPH]"); 
	%velocity = 200; %zVec = 600; 
	} 
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec); 
	Player::applyImpulse(%obj,%jumpDir); 
	} 

StaticShapeData BlastDoorShape
	{
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "newdoor5";
	maxDamage = 40.0;
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
	description = "Blast Door";
	};

function BlastDoorShape::Destruct(%this)
	{
	BlastDoorShape::doDamage(%this);
	}

function BlastDoorShape::doDamage(%this) 
	{
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
	}

function BlastDoorShape::onDestroyed(%this)
	{
	BlastDoorShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastDoorPack"]--;
	}

function BlastDoorShape::onCollision(%this,%obj)
	{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) 
	{
	return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
	{
	return;
	}
	BlastDoorShape::openDoor(%this);
	return;
	}

function BlastDoorShape::openDoor(%this) 
	{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("BlastDoorShape::closeDoor("@%this@");",4);
	}

function BlastDoorShape::closeDoor(%this) 
	{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -1000");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
	}

StaticShapeData doorthreebyfourForceFieldShape
	{
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_3x4";
	maxDamage = 20.0;
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
	description = "3x4 Field Door";
	};

function doorthreebyfourForceFieldShape::Destruct(%this)
	{
	doorthreebyfourForceFieldShape::doDamage(%this);
	}

function doorthreebyfourForceFieldShape::doDamage(%this) 
	{
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
	}

function doorthreebyfourForceFieldShape::onDestroyed(%this)
	{
	doorthreebyfourForceFieldShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "doorthreebyfourForceFieldPack"]--;
	}

function doorthreebyfourForceFieldShape::onCollision(%this,%obj)
	{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) 
	{
	return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
	{
	return;
	}
	doorthreebyfourForceFieldShape::openDoor(%this);
	return;
	}

function doorthreebyfourForceFieldShape::openDoor(%this) 
	{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("doorthreebyfourForceFieldShape::closeDoor("@%this@");",4);
	}

function doorthreebyfourForceFieldShape::closeDoor(%this) 
	{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -1000");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
	}

StaticShapeData doorfourbyfourteenForceFieldShape
	{
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_4x14";
	maxDamage = 20.0;
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
	description = "4x14 Field Door";
	};

function doorfourbyfourteenForceFieldShape::Destruct(%this)
	{
	doorfourbyfourteenForceFieldShape::doDamage(%this);
	}

function doorfourbyfourteenForceFieldShape::doDamage(%this) 
	{
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
	}

function doorfourbyfourteenForceFieldShape::onDestroyed(%this)
	{
	doorfourbyfourteenForceFieldShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "doorfourbyfourteenForceFieldPack"]--;
	}

function doorfourbyfourteenForceFieldShape::onCollision(%this,%obj)
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
	doorfourbyfourteenForceFieldShape::openDoor(%this);
	return;
	}

function doorfourbyfourteenForceFieldShape::openDoor(%this) 
	{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("doorfourbyfourteenForceFieldShape::closeDoor("@%this@");",4);
	}

function doorfourbyfourteenForceFieldShape::closeDoor(%this) 
	{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -1000");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
	}

StaticShapeData doorfourbyeightForceFieldShape
	{
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_4x8";
	maxDamage = 20.0;
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
	description = "4x8 Field Door";
	};

function doorfourbyeightForceFieldShape::Destruct(%this)
	{
	doorfourbyeightForceFieldShape::doDamage(%this);
	}

function doorfourbyeightForceFieldShape::doDamage(%this) 
	{
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
	}

function doorfourbyeightForceFieldShape::onDestroyed(%this)
	{
	doorfourbyeightForceFieldShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "doorfourbyeightForceFieldPack"]--;
	}

function doorfourbyeightForceFieldShape::onCollision(%this,%obj)
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
	doorfourbyeightForceFieldShape::openDoor(%this);
	return;
	}

function doorfourbyeightForceFieldShape::openDoor(%this) 
	{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("doorfourbyeightForceFieldShape::closeDoor("@%this@");",4);
	}

function doorfourbyeightForceFieldShape::closeDoor(%this) {
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -1000");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
	}

StaticShapeData doorfourbyseventeenForceFieldShape
	{
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_4x17";
	maxDamage = 20.0;
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
	description = "4x17 Field Door";
	};

function doorfourbyseventeenForceFieldShape::Destruct(%this)
	{
	doorfourbyseventeenForceFieldShape::doDamage(%this);
	}

function doorfourbyseventeenForceFieldShape::doDamage(%this) 
	{
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
	}

function doorfourbyseventeenForceFieldShape::onDestroyed(%this)
	{
	doorfourbyseventeenForceFieldShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "doorfourbyseventeenForceFieldPack"]--;
	}

function doorfourbyseventeenForceFieldShape::onCollision(%this,%obj)
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
	doorfourbyseventeenForceFieldShape::openDoor(%this);
	return;
	}

function doorfourbyseventeenForceFieldShape::openDoor(%this) 
	{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("doorfourbyseventeenForceFieldShape::closeDoor("@%this@");",4);
	}

function doorfourbyseventeenForceFieldShape::closeDoor(%this) 
	{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -1000");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
	}

StaticShapeData doorfivebyfiveForceFieldShape
	{
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_5x5";
	maxDamage = 20.0;
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
	description = "5x5 Field Door";
	};

function doorfivebyfiveForceFieldShape::Destruct(%this)
	{
	doorfivebyfiveForceFieldShape::doDamage(%this);
	}

function doorfivebyfiveForceFieldShape::doDamage(%this) 
	{
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
	}

function doorfivebyfiveForceFieldShape::onDestroyed(%this)
	{
	doorfivebyfiveForceFieldShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "doorfivebyfiveForceFieldPack"]--;
	}

function doorfivebyfiveForceFieldShape::onCollision(%this,%obj)
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
	doorfivebyfiveForceFieldShape::openDoor(%this);
	return;
	}

function doorfivebyfiveForceFieldShape::openDoor(%this) 
	{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("doorfivebyfiveForceFieldShape::closeDoor("@%this@");",4);
	}

function doorfivebyfiveForceFieldShape::closeDoor(%this) 
	{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -1000");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
	}

StaticShapeData PlatformDoor
	{
	className = "PlatformDoor";
	damageSkinData = "objectDamageSkins";
	shapeFile = "newdoor5";
	maxDamage = 35.0;
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
	description = "Platform Door";
	};

function PlatformDoor::Destruct(%this)
	{
	PlatformDoor::doDamage(%this);
	}

function PlatformDoor::doDamage(%this) 
	{
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
	}

function PlatformDoor::onDestroyed(%this)
	{
	PlatformDoor::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "PlatformDoorPack"]--;
	}

function PlatformDoor::onCollision(%this,%obj)
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
	PlatformDoor::openDoor(%this);
	return;
	}

function PlatformDoor::openDoor(%this) 
	{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("PlatformDoor::closeDoor("@%this@");",4);
	}

function PlatformDoor::closeDoor(%this) 
	{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -1000");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
	}

StaticShapeData newdooroneShape
	{
	shapeFile = "newdoor2_l";
      debrisId = defaultDebrisLarge;
      maxDamage = 30.0;
      visibleToSensor = true;
      isTranslucent = true;
      description = "Panel One";
	};

function newdooroneShape::onDestroyed(%this)
	{
      StaticShape::onDestroyed(%this);
      $TeamItemCount[GameBase::getTeam(%this) @ "newdoorone"]--;
	}

StaticShapeData newdoortwoShape
	{
      shapeFile = "newdoor2_r";
      debrisId = defaultDebrisLarge;
      maxDamage = 30.0;
      visibleToSensor = true;
      isTranslucent = true;
      description = "Panel Two";
	};

function newdoortwoShape::onDestroyed(%this)
	{
      StaticShape::onDestroyed(%this);
      $TeamItemCount[GameBase::getTeam(%this) @ "newdoortwo"]--;
	}

StaticShapeData newdoorthreeShape
	{
      shapeFile = "newdoor4_l";
      debrisId = defaultDebrisLarge;
      maxDamage = 35.0;
      visibleToSensor = true;
      isTranslucent = true;
      description = "Panel Three";
	};

function newdoorthreeShape::onDestroyed(%this)
	{
      StaticShape::onDestroyed(%this);
      $TeamItemCount[GameBase::getTeam(%this) @ "newdoorthree"]--;
	}

StaticShapeData newdoorfourShape
	{
      shapeFile = "newdoor4_r";
      debrisId = defaultDebrisLarge;
      maxDamage = 35.0;
      visibleToSensor = true;
      isTranslucent = true;
      description = "Panel Four";
	};

function newdoorfourShape::onDestroyed(%this)
	{
      StaticShape::onDestroyed(%this);
      $TeamItemCount[GameBase::getTeam(%this) @ "newdoorfour"]--;
	}

StaticShapeData jailpad
	{
      shapeFile = "discammo";
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
      Client::SendMessage(%c,0,"You Stepped On Your Teams Jail Capture Pad");
      return;
      }
      %teleset = nameToID("MissionCleanup/jailports");
      %gclient = Client::getName(%c);
      for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
      {
      %oteam=GameBase::getTeam(%o);
      if(%oteam != %playerTeam)
      {
      GameBase::playSound(%o,ForceFieldOpen,0);
	GameBase::playSound(%this,ForceFieldOpen,0);
	GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
      schedule("jLargeForceField::jailSesame("@%obj@");",60);
      Client::SendMessage(%c,0,"You are a Prisoner of War for 60 seconds");
      }
      }
      echo("ADMINMSG: ****" @ %gclient @ " stepped on a jail pad " );
	}

function jailpad::Reenable(%this)
	{
      %this.disabled = false;
	}

StaticShapeData LLargeForceField
	{
      shapeFile = "forcefield";
      debrisId = defaultDebrisLarge;
      maxDamage = 200.00;
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

function JailSwitchOpen::onCollision(%this,%obj){}

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

function JailSwitchClose::onCollision(%this,%obj){}

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

function jLargeForceField::doDamage(%this) 
	{
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

function jLargeForceField::openSesame(%this) 
	{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("jLargeForceField::closeSesame("@%this@");",4);
	}

function jLargeForceField::closeSesame(%this) 
	{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -1000");
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
	Client::SendMessage(%obj,0,"You Have Been Released. Run Forrest Run!!!!");
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

function jailStandBottom::onCollision(%this,%obj)
	{
	Client::SendMessage(%obj,0,"You Have Been Released. Run Forrest Run!!!!");
	}

StaticShapeData bLargeForceField
	{
      shapeFile = "forcefield";
      debrisId = defaultDebrisLarge;
      maxDamage = 150.00;
      visibleToSensor = true;
      isTranslucent = true;
      description = "Remote Base";
	};

StaticShapeData bdForceField
	{
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "ForceField";
	maxDamage = 120.0;
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
	description = "Remote Base Door";
	};

function bLargeForceField::onDestroyed(%this)
	{
      StaticShape::onDestroyed(%this);
      }

function bdForceField::Destruct(%this)
	{
	bdForceField::doDamage(%this);
	}

function bdForceField::doDamage(%this) 
	{
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
	}

function bdForceField::onDestroyed(%this)
	{
	bdForceField::doDamage(%this);
	}

function bdForceField::onCollision(%this,%obj)
	{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) 
	{
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
//=============================================================
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

function ABPortGenerator::onDestroyed(%this)
{
$TeamItemCount[GameBase::getTeam(%this) @ "airbase"]--;

}
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
   description = "Guard Power Cell";
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
   description = "Guard Turret";
	shapeFile = "anten_med";
	className = "Decoration";
	debrisId = flashDebrisLarge;
	maxDamage = 5;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
    damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpLarge;

   sfxAmbient = ZeldaLostwoods;

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
			Player::mountObject (%object, %this);
		}
}

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

StaticShapeData WAll // Added by: Bhall
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


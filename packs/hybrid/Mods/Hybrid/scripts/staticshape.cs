//------------------------------------------------------------------------
// Genocide static shapes
//------------------------------------------------------------------------


//------------------------------------------------------------------------
// animation behavior for all static shapes

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
			bottomprint(%client, "<jc><F2>You have just recieved <f1> 1.25 <f2> points for destroying a "@ %name.className);
			echo("MSG: ", %client, " Destroyed ", %name.className);
			%client.score+=1.25;
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
			bottomprint(%client, "<jc><F2>You have just LOST <f1> 10 <f2> POINTS for destroying your teams "@ %name.className);
                        messageTeamExcept(%client, 0, Client::getName(%client) @ " LOST 10 POINTS for Destroying a TEAM Item");
			echo("MSG: ", %client, " Destroyed a team ", %name.className);
			if(%this.deployer)DropshipTeamMessage(GameBase::getTeam(%client), 3, Client::getName(%client)@" has destroyed "@Client::getName(%this.deployer)@"'s "@ %name.className);
			%client.score-=10;
			Game::refreshClientScore(%client);
		}
		%obj.deployer = "";
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
				%client.score+=2.5;
				Game::refreshClientScore(%client);
				bottomprint(%client, "<jc><F2>You receive <f1> 2.5 <f2> points for Destroying the Enemy's Power!");
				messageTeamExcept(%client, 0, Client::getName(%client) @ " received 2.5 points for Destroying the Enemy's Power!");
				PowerTeamMessage(%team, 1,"   <jl><bitem_damaged.bmp>   Your teams generators have been destroyed by "@Client::getName(%client)@"!!","Your gens have been destroyed by "@Client::getName(%client));
				echo("team "@%team@"'s power destroyed by "@Client::getName(%client));
			}	
		}
		else if(GameBase::getTeam(%client) == %team)
		{
			%client.score+=2.5;
			Game::refreshClientScore(%client);
			bottomprint(%client, "<jc>You receive <f1> 2.5 <f0> points for Restoring your Team's Power!");
			messageTeamExcept(%client, 0, Client::getName(%client) @ " received 2.5 points for Restoring your Team's Power!");
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
		if(%type == $BioShrapnelDamageType)
			%strength *= 0.5;
		else
			if(%type == $SplitMortarDamageType)
				%strength *= 0.25;
			else
				if(%type == $BlazterDamageType)
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
   PowerTeamMessage(%team, 1,"   <jl><bitem_damaged.bmp>   Your teams generators have been destroyed by "@Client::getName(%client)@"!!","Your gens have been destroyed by "@Client::getName(%client));
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
	debrisId = ElectricDebris;
	explosionId = turretExp;
   maxDamage = 2.0;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};

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

StaticShapeData SatBig
{
	shapeFile = "sat_big";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "SatBig";
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

//===================Hybrid



//------------------------------------------------------------

StaticShapeData lgbForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_4x14";
maxDamage = 30;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 1;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "4x14 Field Door";
};
function lgbForceFieldShape::Destruct(%this)
{
lgbForceFieldShape::doDamage(%this);
}
function lgbForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function lgbForceFieldShape::onDestroyed(%this)
{
lgbForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "lgbForceFieldPack"]--;
}
function lgbForceFieldShape::onCollision(%this,%obj)
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
lgbForceFieldShape::openDoor(%this);
return;
}
function lgbForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.10);
schedule("lgbForceFieldShape::closeDoor("@%this@");",4);
}
function lgbForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.10);

}

function lgbForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("lgbForceFieldShape::closeDoor("@%this@");",4);
}

//------------------------------------------------------------

StaticShapeData medaForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_4x8";
maxDamage = 30;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 1;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "4x8 Field Door";
};
function medaForceFieldShape::Destruct(%this)
{
medaForceFieldShape::doDamage(%this);
}
function medaForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function medaForceFieldShape::onDestroyed(%this)
{
medaForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "medaForceFieldPack"]--;
}
function medaForceFieldShape::onCollision(%this,%obj)
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
medaForceFieldShape::openDoor(%this);
return;
}
function medaForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.10);
schedule("medaForceFieldShape::closeDoor("@%this@");",4);
}
function medaForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.10);

}

function medaForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("medaForceFieldShape::closeDoor("@%this@");",4);
}

//------------------------------------------------------------

StaticShapeData medbForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_5x5";
maxDamage = 30;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 1;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "5x5 Field Door";
};
function medbForceFieldShape::Destruct(%this)
{
medbForceFieldShape::doDamage(%this);
}
function medbForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function medbForceFieldShape::onDestroyed(%this)
{
medbForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "medbForceFieldPack"]--;
}
function medbForceFieldShape::onCollision(%this,%obj)
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
medbForceFieldShape::openDoor(%this);
return;
}
function medbForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.10);
schedule("medbForceFieldShape::closeDoor("@%this@");",4);
}
function medbForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.10);

}

function medbForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("medbForceFieldShape::closeDoor("@%this@");",4);
}

//------------------------------------------------------------

StaticShapeData medcForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_3x4";
maxDamage = 30;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 1;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "3x4 Field Door";
};
function medcForceFieldShape::Destruct(%this)
{
medcForceFieldShape::doDamage(%this);
}
function medcForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function medcForceFieldShape::onDestroyed(%this)
{
medcForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "medcForceFieldPack"]--;
}
function medcForceFieldShape::onCollision(%this,%obj)
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
medcForceFieldShape::openDoor(%this);
return;
}
function medcForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.10);
schedule("medcForceFieldShape::closeDoor("@%this@");",4);
}
function medcForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.10);

}

function medcForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("medcForceFieldShape::closeDoor("@%this@");",4);
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

StaticShapeData DoorForceFieldShape
{
className = "DoorForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield";
maxDamage = 30;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 1;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "Door Force Field";
};
function DoorForceFieldShape::Destruct(%this)
{
DoorForceFieldShape::doDamage(%this);
}
function DoorForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function DoorForceFieldShape::onDestroyed(%this)
{
DoorForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "DoorForceFieldShape"]--;
}
function DoorForceFieldShape::onCollision(%this,%obj)
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
DoorForceFieldShape::openDoor(%this);
return;
}
function DoorForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.10);
schedule("DoorForceFieldShape::closeDoor("@%this@");",4);
}
function DoorForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.10);

}

function DoorForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("DoorForceFieldShape::closeDoor("@%this@");",4);
}


StaticShapeData Plat2Shape 
{ 
   className = "PlatformDoor";
   damageSkinData = "objectDamageSkins";
   shapeFile = "elevator16x16_octo"; 
maxDamage = 30;
maxEnergy = 200;
   mapFilter = 2;
   visibleToSensor = true; 
   debrisId = defaultDebrisLarge; 
   explosionId = debrisExpLarge; 
   lightRadius = 12.0;
   lightType=2;
   lightColor = {1.0,0.2,0.2};
   side = "single";
   isTranslucent = true;
   description = "Blast Hatch";

}; 

function Plat2Shape::Destruct(%this)
{
	DoorShape::doDamage(%this);
}


function Plat2Shape::onDestroyed(%this)
{
	DoorShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "Plat2"]--;
}

function Plat2Shape::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)){
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam){
		return;
	}
	DoorShape::openDoor(%this);
	return;
}



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Door Code
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

function DoorShape::doDamage(%this) 
{
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function DoorShape::openDoor(%this) 
{
	GameBase::startfadeout(%this);
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos,"0 0 600");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",SoundPlasmaTurretOn,0);",0.15);
	schedule("DoorShape::closeDoor("@%this@");",4);
}

function DoorShape::closeDoor(%this) 
{
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos,"0 0 -600");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",SoundPlasmaTurretTurn,0);",0.15);
}

//------------------------------------------------------------------------
// Everything below this line is written By Nicodemus
//------------------------------------------------------------------------
// Extra Staticshape data
//------------------------------------------------------------------------
// This section contains a bunch of 'Holograms'. Basically they're
// just for show. Some of them will fade in or out depending on whether
// or not they're powered.
//1-Flame-----------------------------------------------------------------
StaticShapeData Flame
{
	shapeFile = "plasmabolt";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Flame";
	disableCollision = true;
};

//1a-Powered-Flame--------------------------------------------------------
//This one will come online when power is available.
//------------------------------------------------------------------------
StaticShapeData PoweredFlame
{
	shapeFile = "plasmabolt";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Flame";
	disableCollision = true;
};

function PoweredFlame::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeIn(%this);
	else
	GameBase::startFadeOut(%this);
}
//1b-Powered-up-Flame-----------------------------------------------------
//This one will come online when power is not available.
//------------------------------------------------------------------------
StaticShapeData PoweredUpFlame
{
	shapeFile = "plasmabolt";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Up Flame";
	disableCollision = true;
};

function PoweredUpFlame::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeOut(%this);
	else
	GameBase::startFadeIn(%this);
}

//2-Tracer----------------------------------------------------------------
StaticShapeData TracerBullet
{
	shapeFile = "bullet";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Tracer Bullet";
	disableCollision = true;
};

//2a-Powered-Tracer-------------------------------------------------------
StaticShapeData PoweredTracerBullet
{
	shapeFile = "bullet";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Tracer Bullet";
	disableCollision = true;
};

function PoweredTracerBullet::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeIn(%this);
	else
	GameBase::startFadeOut(%this);
}

//2a-Powered-up-Tracer----------------------------------------------------
StaticShapeData PoweredUpTracerBullet
{
	shapeFile = "bullet";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Up Tracer Bullet";
	disableCollision = true;
};

function PoweredUpTracerBullet::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeOut(%this);
	else
	GameBase::startFadeIn(%this);
}

//3-Disc------------------------------------------------------------------
StaticShapeData Disc
{
	shapeFile = "discb";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Disc";
	disableCollision = true;
};

//3a-Powered-Disc---------------------------------------------------------
StaticShapeData PoweredDisc
{
	shapeFile = "discb";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Disc";
	disableCollision = true;
};

function PoweredDisc::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeIn(%this);
	else
	GameBase::startFadeOut(%this);
}

//3b-Powered-up-Disc------------------------------------------------------
StaticShapeData PoweredUpDisc
{
	shapeFile = "discb";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Up Disc";
	disableCollision = true;
};

function PoweredUpDisc::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeOut(%this);
	else
	GameBase::startFadeIn(%this);
}

//4-Missle----------------------------------------------------------------
StaticShapeData Missle
{
	shapeFile = "rocket";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Missle";
	disableCollision = true;
};

//4a-Powered-Missle-------------------------------------------------------
StaticShapeData PoweredMissle
{
	shapeFile = "rocket";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Missle";
	disableCollision = true;
};

function PoweredMissle::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeIn(%this);
	else
	GameBase::startFadeOut(%this);
}

//4a-Powered-up-Missle----------------------------------------------------
StaticShapeData PoweredUpMissle
{
	shapeFile = "rocket";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Up Missle";
	disableCollision = true;
};

function PoweredUpMissle::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeOut(%this);
	else
	GameBase::startFadeIn(%this);
}

//5-Grenade---------------------------------------------------------------
StaticShapeData GrenadeFire
{
	shapeFile = "grenade";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Grenade Fire";
	disableCollision = true;
};

//5a-Powered-Grenade------------------------------------------------------
StaticShapeData PoweredGrenadeFire
{
	shapeFile = "grenade";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Grenade Fire";
	disableCollision = true;
};

function PoweredGrenadeFire::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeIn(%this);
	else
	GameBase::startFadeOut(%this);
}

//5b-Powered-up-Grenade---------------------------------------------------
StaticShapeData PoweredUpGrenadeFire
{
	shapeFile = "grenade";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Up Grenade Fire";
	disableCollision = true;
};

function PoweredUpGrenadeFire::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeOut(%this);
	else
	GameBase::startFadeIn(%this);
}

//6-Mortar----------------------------------------------------------------
StaticShapeData MortarFire2
{
	shapeFile = "mortar";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Mortar Fire2";
	disableCollision = true;
};

//6a-Powered-Mortar-------------------------------------------------------
StaticShapeData PoweredMortarFire
{
	shapeFile = "mortar";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Mortar Fire";
	disableCollision = true;
};

function PoweredMortarFire::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeIn(%this);
	else
	GameBase::startFadeOut(%this);
}

//6b-Powered-up-Mortar----------------------------------------------------
StaticShapeData PoweredUpMortarFire
{
	shapeFile = "mortar";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Up Mortar Fire";
	disableCollision = true;
};

function PoweredUpMortarFire::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeOut(%this);
	else
	GameBase::startFadeIn(%this);
}

//7-Shields---------------------------------------------------------------
//7A-Small-Shield---------------------------------------------------------
StaticShapeData Shield1
{
	shapeFile = "shield";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Shield1";
	disableCollision = true;
};

//7A1-Powered-Small-Shield------------------------------------------------
StaticShapeData PoweredShield1
{
	shapeFile = "shield";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Shield1";
	disableCollision = true;
};

function PoweredShield1::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeIn(%this);
	else
	GameBase::startFadeOut(%this);
}

//7A2-Powered-Up-Small-Shield---------------------------------------------
StaticShapeData PoweredUpShield1
{
	shapeFile = "shield";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Up Shield1";
	disableCollision = true;
};

function PoweredUpShield1::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeOut(%this);
	else
	GameBase::startFadeIn(%this);
}

//7B-Medium-Shield--------------------------------------------------------
StaticShapeData ShieldMedium1
{
	shapeFile = "shield_medium";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "ShieldMedium1";
	disableCollision = true;
};

//7B1-Powered-Medium-Shield-----------------------------------------------
StaticShapeData PoweredShieldMedium1
{
	shapeFile = "shield_medium";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Shield Medium1";
	disableCollision = true;
};

function PoweredShieldMedium1::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeIn(%this);
	else
	GameBase::startFadeOut(%this);
}

//7B2-Powered-Up-Medium-Shield--------------------------------------------
StaticShapeData PoweredUpShieldMedium1
{
	shapeFile = "shield_medium";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Up Shield Medium1";
	disableCollision = true;
};

function PoweredUpShieldMedium1::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeOut(%this);
	else
	GameBase::startFadeIn(%this);
}

//7C-Large-Shield---------------------------------------------------------
StaticShapeData ShieldLarge1
{
	shapeFile = "shield_large";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "ShieldLarge1";
	disableCollision = true;
};

//7C1-Powered-Large-Shield------------------------------------------------
StaticShapeData PoweredShieldLarge1
{
	shapeFile = "shield_large";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Shield Large1";
	disableCollision = true;
};

function PoweredShieldLarge1::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeIn(%this);
	else
	GameBase::startFadeOut(%this);
}

//7C2-Powered-Up-Large-Shield---------------------------------------------
StaticShapeData PoweredUpShieldLarge1
{
	shapeFile = "shield_large";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Up Shield Large1";
	disableCollision = true;
};

function PoweredUpShieldLarge1::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeOut(%this);
	else
	GameBase::startFadeIn(%this);
}

//8-Vehicles--------------------------------------------------------------
//8A-StaticFlyer----------------------------------------------------------
StaticShapeData StaticFlyer
{
	shapeFile = "flyer";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "StaticFlyer";
	disableCollision = false;
};

//8A1-Powered-StaticFlyer-------------------------------------------------
StaticShapeData PwrdStaticFlyer
{
	shapeFile = "flyer";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered StaticFlyer";
	disableCollision = true;
};

function PwrdStaticFlyer::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeIn(%this);
	else
	GameBase::startFadeOut(%this);
}

//8A2-Powered-up-StaticFlyer----------------------------------------------
StaticShapeData PwrdUpStaticFlyer
{
	shapeFile = "flyer";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Up StaticFlyer";
	disableCollision = true;
};

function PwrdUpStaticFlyer::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeOut(%this);
	else
	GameBase::startFadeIn(%this);
}

//8B-StaticLAPC----------------------------------------------------------
StaticShapeData StaticLAPC
{
	shapeFile = "hover_apc_sml";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "StaticLAPC";
	disableCollision = false;
};

//8B1-Powered-StaticLAPC-------------------------------------------------
StaticShapeData PwrdStaticLAPC
{
	shapeFile = "hover_apc_sml";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered StaticLAPC";
	disableCollision = true;
};

function PwrdStaticLAPC::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeIn(%this);
	else
	GameBase::startFadeOut(%this);
}

//8B2-Powered-up-StaticLAPC-----------------------------------------------
StaticShapeData PwrdUpStaticLAPC
{
	shapeFile = "hover_apc_sml";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Up StaticLAPC";
	disableCollision = true;
};

function PwrdUpStaticLAPC::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeOut(%this);
	else
	GameBase::startFadeIn(%this);
}

//8C-StaticLAPC----------------------------------------------------------
StaticShapeData StaticHAPC
{
	shapeFile = "hover_apc";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "StaticHAPC";
	disableCollision = false;
};

//8C1-Powered-StaticLAPC-------------------------------------------------
StaticShapeData PwrdStaticHAPC
{
	shapeFile = "hover_apc";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered StaticHAPC";
	disableCollision = true;
};

function PwrdStaticHAPC::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeIn(%this);
	else
	GameBase::startFadeOut(%this);
}

//8C2-Powered-up-StaticFlyer----------------------------------------------
StaticShapeData PwrdUpStaticHAPC
{
	shapeFile = "hover_apc";
	maxDamage = 10000.0;
	isTranslucent = true;
	description = "Powered Up StaticHAPC";
	disableCollision = true;
};

function PwrdUpStaticHAPC::onPower(%this, %power, %generator)
{
	if(%power)
	GameBase::startFadeOut(%this);
	else
	GameBase::startFadeIn(%this);
}
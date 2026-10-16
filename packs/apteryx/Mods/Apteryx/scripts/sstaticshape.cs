//------------------------------------------------------------------------
// Generic static shapes
//------------------------------------------------------------------------

//generic staticshape counter, anything defined overwrites these -Plasmatic
function StaticShape::onAdd(%this)
{
	$StaticShape::count += 1;
}

function StaticShape::onRemove(%this)
{
	$StaticShape::count -= 1;
}


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
	%this.nuetron = "";
	GameBase::stopSequence(%this,0);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
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
	%data = GameBase::getDataName(%this).description;
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
		echo("GAME: " @ Client::getName(%client) @ " Destroyed "@ %data@" "@ %name.className);
		if((%name.classname == "Turret" || %name.classname == "Generator") && %this.LastRepairCl !=  %client && !isDrone(%name))
		{
			bottomprint(%client, "<jc>You have just recieved <f2>1<f0> point for destroying a "@ %data);
			echo("MSG: "@ %client@ " Destroyed "@ %data);
			%client.score++;
			%pwr = GameBase::isPowered(%this);
			if(%name.classname == "Generator")
				if((!%pwr) && ($ixRepairTeam[%thisTeam] != %objTeam))
					schedule("CheckPowerObjective(" @ %object @ "," @ %thisTeam @ "," @ $ixTeamPower[%thisTeam]++ @ ",1);",30);
			Game::refreshClientScore(%client);
		}
		%obj.deployer = "";
	}
	
	if(%Check == 1 && GameBase::getDamageState(%this) == "Destroyed") 
	{
		echo("GAME: " @ Client::getName(%client) @ " Destroyed "@ %data @" deployed by "@Client::getName(%this.deployer));
		if((%name.classname == "Turret" || %name.classname == "Generator") && (%this.deployer != %client && %name != DeployableCat && !isdrone(%name)))
		{
			bottomprint(%client, "<jc>You have just LOST <f2>1<f0> POINT for destroying your teams "@ %data);
			echo("MSG: ", %client, " Destroyed a team ", %data);
			if(%this.deployer)
			{
				%client.bk++;
				DropshipTeamMessage(GameBase::getTeam(%client), 3, Client::getName(%client)@" killed "@Client::getName(%this.deployer)@"'s "@ %data);
				admin::message(Client::getName(%client)@" killed "@Client::getName(%this.deployer)@"'s "@ %data@" BK count = "@%client.bk);				
			}	
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
				bottomprint(%client, "<jc>You receive <f2>2<f0> points for Destroying the Enemy's Power!");
				messageTeamExcept(%client, 0, Client::getName(%client) @ " received 2 points for Destroying the Enemy's Power!");
				PowerTeamMessage(%team, 1,"   <jl><bitem_damaged.bmp>   Your teams generators have been destroyed by "@Client::getName(%client)@"!!","Your gens have been destroyed by "@Client::getName(%client));
				echo("team "@%team@"'s power destroyed by "@Client::getName(%client));
			}	
		}
		else if(GameBase::getTeam(%client) == %team)
		{
			%client.score+=3;
			Game::refreshClientScore(%client);
			bottomprint(%client, "<jc>You receive <f2>3<f0> points for Restoring your Team's Power!");
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

StaticShapeData FlagStand
{
	description = "Flag Stand";
	shapeFile = "flagstand";
	visibleToSensor = false;
};

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
	%this.nuetron = "";
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


//------------------------------------------------------------------------
StaticShapeData SmallAntenna
{
	shapeFile = "anten_small";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.0;
	shieldShapeName = "shield";
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
	shieldShapeName = "shield";
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
	shieldShapeName = "shield";
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




//---------------------------------------------------------- Force Field Walls
StaticShapeData ForceField 	{ shapeFile = "forcefield"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData ForceField1 	{ shapeFile = "ForceField_3x4"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData ForceField2 	{ shapeFile = "ForceField_4x17"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData ForceField3 	{ shapeFile = "ForceField_4x8"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData ForceField4 	{ shapeFile = "ForceField_5x5"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData ForceField5 	{ shapeFile = "ForceField_4x14"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData PlasmaWall { shapeFile = "plasmawall"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "PlasmaWall"; };

//hacks to keep people from flying droids through force fields -Plasmatic
function forcefield::onCollision(%this,%object)
{
	if($debug) 
		event::collision(%this,%object);
	
	if(getObjectType(%object) == "Flier")
	{
		%data = GameBase::getDataName(%object);	
		if($debug)
			echo("<jc> "@%data@" hitting "@GameBase::getDataName(%this));
			
		%damage = GameBase::getDamageLevel(%object) + 0.05;
		GameBase::setDamageLevel(%object,%damage);
		playSound(SoundFlierCrash,GameBase::getPosition(%object));
	}
}

function forcefield1::onCollision(%this,%object)
{
	if($debug) 
		event::collision(%this,%object);

	if(getObjectType(%object) == "Flier")
	{
		%data = GameBase::getDataName(%object);	
		if($debug)
			echo("<jc> "@%data@" hitting "@GameBase::getDataName(%this));
			
		%damage = GameBase::getDamageLevel(%object) + 0.05;
		GameBase::setDamageLevel(%object,%damage);	
		playSound(SoundFlierCrash,GameBase::getPosition(%object));
	}
}

function forcefield2::onCollision(%this,%object)
{	
	if($debug) 
		event::collision(%this,%object);
	
	if(getObjectType(%object) == "Flier")
	{
		%data = GameBase::getDataName(%object);	
		if($debug)
			echo("<jc> "@%data@" hitting "@GameBase::getDataName(%this));
			
		%damage = GameBase::getDamageLevel(%object) + 0.05;
		GameBase::setDamageLevel(%object,%damage);	
		playSound(SoundFlierCrash,GameBase::getPosition(%object));
	}
}		
		

function forcefield3::onCollision(%this,%object)
{	
	if($debug) 
		event::collision(%this,%object);

	if(getObjectType(%object) == "Flier")
	{
		%data = GameBase::getDataName(%object);	
		if($debug)
			echo("<jc> "@%data@" hitting "@GameBase::getDataName(%this));
			
		%damage = GameBase::getDamageLevel(%object) + 0.05;
		GameBase::setDamageLevel(%object,%damage);
		playSound(SoundFlierCrash,GameBase::getPosition(%object));
	}
}
		

function forcefield4::onCollision(%this,%object)
{
	if($debug) 
		event::collision(%this,%object);

	if(getObjectType(%object) == "Flier")
	{
		%data = GameBase::getDataName(%object);	
		if($debug)
			echo("<jc> "@%data@" hitting "@GameBase::getDataName(%this));
			
		%damage = GameBase::getDamageLevel(%object) + 0.05;
		GameBase::setDamageLevel(%object,%damage);
		playSound(SoundFlierCrash,GameBase::getPosition(%object));
	}
}				


function forcefield5::onCollision(%this,%object)
{
	if($debug) 
		event::collision(%this,%object);

	if(getObjectType(%object) == "Flier")
	{
		%data = GameBase::getDataName(%object);
		if($debug)
			echo("<jc> "@%data@" hitting "@GameBase::getDataName(%this));
			
		%damage = GameBase::getDamageLevel(%object) + 0.05;
		GameBase::setDamageLevel(%object,%damage);	
		playSound(SoundFlierCrash,GameBase::getPosition(%object));
	}
}
		
//========================================================================= Misc Not In Base
StaticShapeData Enerpad 	{ shapeFile = "enerpad"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Telepad"; };
StaticShapeData Mainpad 	{ shapeFile = "mainpad"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "MainPad"; };
StaticShapeData TribesLogo 	{ shapeFile = "logo"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "logo"; };
StaticShapeData Bridge 	{ shapeFile = "bridge"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Bridge"; };
StaticShapeData GunTuret 	{ shapeFile = "GunTuret"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "gunturet"; };
StaticShapeData SatBig 	{ shapeFile = "sat_big"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "SatBig"; };

//========================================================================= Holograms
StaticShapeData holoweak1 	{ shapeFile = "larmor"; maxDamage = 0.75; debrisId = defaultDebrisSmall; description = "Light Armor";};
StaticShapeData holoweak2 	{ shapeFile = "marmor"; maxDamage = 0.75; debrisId = defaultDebrisSmall; description = "Medium Armor";};
StaticShapeData holoweak3 	{ shapeFile = "harmor"; maxDamage = 0.75; debrisId = defaultDebrisSmall; description = "Heavy Armor";};
StaticShapeData hologhost1 	{ shapeFile = "larmor"; maxDamage = 10000.0; description = "Light Armor"; disableCollision = true; };
StaticShapeData hologhost2 	{ shapeFile = "marmor"; maxDamage = 10000.0; description = "Medium Armor"; disableCollision = true; };
StaticShapeData hologhost3 	{ shapeFile = "harmor"; maxDamage = 10000.0; description = "Heavy Armor"; disableCollision = true; };
StaticShapeData holo1 	{ shapeFile = "larmor"; maxDamage = 10000.0; description = "Light Armor";};
StaticShapeData holo2 	{ shapeFile = "marmor"; maxDamage = 10000.0; description = "Medium Armor";};
StaticShapeData holo3 	{ shapeFile = "harmor"; maxDamage = 10000.0; description = "Heavy Armor";};
//------------------------------------------------------------------------ Beams
StaticShapeData ElectricalBeam 	{ shapeFile = "zap"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; };
StaticShapeData ElectricalBeamBig 	{ shapeFile = "zap_5"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; };
StaticShapeData PoweredElectricalBeam 	{ shapeFile = "zap"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; };

function PoweredElectricalBeam::onPower(%this, %power, %generator)
{
	if(%power)
		GameBase::startFadeIn(%this);
	else
		GameBase::startFadeOut(%this);
}
//------------------------------
//some random spring pads for editor -plasmatic
//------------------------------

StaticShapeData SpringPad
 {
   description = "Spring Pad";
   shapeFile = "elevator_4x4";
   className = "Misc";
   debrisId = defaultDebrisLarge; 
   explosionId = debrisExpLarge;
   maxDamage = 10000.0; 
   visibleToSensor = "false";
 }; 

function SpringPad::onDestroyed(%this)
{ 
	StaticShape::onDestroyed(%this); 
}
 

function SpringPad::onCollision(%this,%obj)
{
	if($debug) 
		event::collision(%this,%obj);

   %c = Player::getClient(%obj);
   if (floor(getRandom() * 30) == 0)
    { 
     GameBase::playSound(%this, debrisLargeExplosion, 0);
     %velocity = 50; %zVec = 475;
     %rnd = floor(getRandom() * 3);
     if (%rnd == 0)
      { 
      } 
     else if (%rnd == 1) 
      {
      } 
     else if (%rnd == 2) 
      { 
      }
    } 
   else if (floor(getRandom() * 7) == 0)
    { 
     GameBase::playSound(%this, debrisLargeExplosion, 0);
     %velocity = 50; %zVec = 475;
    } 
   else 
    { 
     GameBase::playSound(%this, SoundFireMortar, 0);
     %velocity = 50;
     %zVec = 475;
    } 
   %jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
   Player::applyImpulse(%obj,%jumpDir);
  } 

//------------------------------------------------------------------------

StaticShapeData LightSpringPad
{
	description = "LightSpring Pad";
	shapeFile = "elevator_4x4";
	className = "Misc";
	debrisId = defaultDebrisLarge; 
	explosionId = debrisExpLarge;
	maxDamage = 10000.0; 
	visibleToSensor = "false";
}; 

function LightSpringPad::onDestroyed(%this)
{ 
	StaticShape::onDestroyed(%this); 
}
 

function LightSpringPad::onCollision(%this,%obj)
{
	if($debug) 
		event::collision(%this,%obj);

	%c = Player::getClient(%obj);
	if (floor(getRandom() * 30) == 0)
	{ 
		GameBase::playSound(%this, debrisLargeExplosion, 0);
		%velocity = 275; %zVec = 275;
		%rnd = floor(getRandom() * 3);
		if (%rnd == 0)
		{ 
		} 
		else if (%rnd == 1) 
		{
		} 
		else if (%rnd == 2) 
		{ 
		}
	} 
	else if (floor(getRandom() * 7) == 0)
	{ 
		GameBase::playSound(%this, debrisLargeExplosion, 0);
		%velocity = 275; %zVec = 275;
	} 
	else 
	{ 
		GameBase::playSound(%this, SoundFireMortar, 0);
		%velocity = 275;
		%zVec = 275;
	} 
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
	Player::applyImpulse(%obj,%jumpDir);
} 

//------------------------------------------------------------------------

StaticShapeData MegaSpringPad
{
	description = "MegaSpring Pad";
	shapeFile = "elevator_4x4";
	className = "Misc";
	debrisId = defaultDebrisLarge; 
	explosionId = debrisExpLarge;
	maxDamage = 10000.0; 
	visibleToSensor = "false";
}; 

function MegaSpringPad::onDestroyed(%this)
{ 
	StaticShape::onDestroyed(%this); 
}
 

function MegaSpringPad::onCollision(%this,%obj)
{
	if($debug) 
		event::collision(%this,%obj);

	%c = Player::getClient(%obj);
	if (floor(getRandom() * 30) == 0)
	{ 
		GameBase::playSound(%this, debrisLargeExplosion, 0);
		%velocity = 800; %zVec = 400;
		%rnd = floor(getRandom() * 3);
		if (%rnd == 0)
		{ 
		} 
		else if (%rnd == 1) 
		{
		} 
		else if (%rnd == 2) 
		{ 
		}
	} 
	else if (floor(getRandom() * 7) == 0)
	{ 
		GameBase::playSound(%this, debrisLargeExplosion, 0);
		%velocity = 800; %zVec = 400;
	} 
	else 
	{ 
		GameBase::playSound(%this, SoundFireMortar, 0);
		%velocity = 800;
		%zVec = 400;
	} 
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
	Player::applyImpulse(%obj,%jumpDir);
} 
	
//added to mission editor by plasmatic
StaticShapeData Deployablespring
{
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.50;
	visibleToSensor = false;
	isTranslucent = true;
	description = "Launch Pad";
};	
function Deployablespring::onCollision(%this,%obj) 
{
	if($debug) 
		event::collision(%this,%obj);

	%c = Player::getClient(%obj);

	GameBase::playSound(%this, SoundFireMortar, 0);
	Client::SendMessage(%c, 0, "SPROING!");
	%velocity = 200;
	%zVec = 600;
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
	Player::applyImpulse(%obj,%jumpDir);
}

// -plasmatic
StaticShapeData DeployableLaunch
{
	shapeFile = "elevator_4x4";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.50;
	visibleToSensor = false;
	isTranslucent = true;
	description = "Launch Pad";
};

function DeployableLaunch::onCollision(%this,%obj)
{
	if($debug) 
		event::collision(%this,%obj);

	%c = Player::getClient(%obj);
	if (floor(getRandom() * 30) == 0)
	{ 
		GameBase::playSound(%this, debrisLargeExplosion, 0);
		%velocity = 800; %zVec = 400;

	} 
	else if (floor(getRandom() * 7) == 0)
	{ 
		GameBase::playSound(%this, debrisLargeExplosion, 0);
		%velocity = 800; %zVec = 400;
	} 
	else 
	{ 
		GameBase::playSound(%this, SoundFireMortar, 0);
		%velocity = 800; %zVec = 400;
	} 
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
	Player::applyImpulse(%obj,%jumpDir);
} 

//-----------------------------------------------------------------------
//------------------------------------------------------------------------ Beams
StaticShapeData TeleBeam 	
{ 	
	shapeFile = "zap"; 
	maxDamage = 10000.0; 
	isTranslucent = true; 
	description = "Electrical Beam"; 
	disableCollision = false; 
};

function TeleBeam::onCollision(%this,%object) 
{
	if($debug) 
		event::collision(%this,%object);

	TeleTrigger::onEnter(%this,%object);
}

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
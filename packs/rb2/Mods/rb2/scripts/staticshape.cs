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
	if(%type == $DecloakDamageType)
	{
		if(%this.cloaked >= 1 || %this.cloakdevice >= 1 || %this.cloakGun == 1 || %this.cloakplane == 1)
		{
			%this.cloaked = 0;
			%this.cloakdevice = 0;
			%this.cloakGun = 0;
			%this.cloakplane = 0;
			GameBase::playSound(%this,ForceFieldOpen,0);
			GameBase::startFadein(%this);
		}
	}
	else if(%type == $RepairDamageType)
		GameBase::repairDamage(%this,0.5);
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
	GameBase::setDamageLevel(%this,%dValue);
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
		if (%type == $ShrapnelDamageType || %type == $FlameDamageType)
			%strength *= 0.5;
		else if (%type == $MortarDamageType || %type == $BombDamageType)
			%strength *= 0.25;
		else if (%type == $KamikazeDamageType)
			%strength *= 0.0;
		else if (%type == $BlasterDamageType || %type == $SniperDamageType)
			%strength *= 1.5;
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
			if(%type == $DecloakDamageType)
			{
				if(%this.cloaked >= 1 || %this.cloakdevice >= 1 || %this.cloakGun == 1 || %this.cloakplane == 1)
				{
					%this.cloaked = 0;
					%this.cloakdevice = 0;
					%this.cloakGun = 0;
					%this.cloakplane = 0;
					GameBase::playSound(%this,ForceFieldOpen,0);
					GameBase::startFadein(%this);
				}
			}
			else if(%type == $RepairDamageType)
				GameBase::repairDamage(%this,0.5);
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


function calcRadiusDamage(%this,%type,%radiusRatio,%damageRatio,%forceRatio,%rMax,%rMin,%dMax,%dMin,%fMax,%fMin) 
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
		GameBase::applyRadiusDamage(%type,getBoxCenter(%this), %radius,	%damageValue,%force,%this);
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
	GameBase::setAutoRepairRate(%this,0.05);

}

function Generator::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
}

function Generator::onDestroyed(%this)
{
	Generator::onDisabled(%this);
	GameBase::setAutoRepairRate(%this,0.01);
	StaticShape::objectiveDestroyed(%this);
	%client = GameBase::getControlClient(%this.lastDamageObject);	
	%objectName = GameBase::getDataName(%this);
	%objectTeam = GameBase::getTeam(%this);
	%playerTeam = GameBase::getTeam(%client);
	if (%objectTeam == %playerTeam && %client.traitor == 0)
	{
		if (%objectName == "RemoteSolarPanel" || %objectName == "SolarPanel")
		{
			bottomprint(%client, "You lose 10 points for destroying your own solar panel!");
			%client.Score -= 10;
			%client.Objectives -= 10;
			Game::refreshClientScore(%client);
			if (%objectName == "RemoteSolarPanel")
			{
				$TeamItemCount[%objectTeam @ "DeployableSolarPanel"]--;
			}
		}
		else
		{
			bottomprint(%client, "You lose 10 points for destroying your own generator!");
			%client.Score -= 10;
			%client.Objectives -= 10;
			Game::refreshClientScore(%client);
		}
	}
	else if (%objectTeam != %playerTeam && %client.traitor == 0)
	{
		if (%objectName == "RemoteSolarPanel" || %objectName == "SolarPanel")
		{
			bottomprint(%client, "You get 0 points for destroying the enemy's solar panel.");
			%client.Score += 0;
			%client.Objectives += 5;
			Game::refreshClientScore(%client);
			if (%objectName == "RemoteSolarPanel")
			{
				$TeamItemCount[%objectTeam @ "DeployableSolarPanel"]--;
			}
		}
		else
		{
			bottomprint(%client, "You get 0 point for destroying the enemy generator.");
			%client.Score += 0;
			%client.Objectives += 10;
			Game::refreshClientScore(%client);
		}		
	}
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 
		0.30, 250, 170); 
}

function Generator::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object);
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
	shieldShapeName = "shield_medium";
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
	maxEnergy = 50;
	shieldShapeName = "shield";
};

StaticShapeData PortGenerator
{
	description = "Portable Generator";
	shapeFile = "generator_p";
	className = "Generator";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundGeneratorPower;
	maxDamage = 2.0;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
	maxEnergy = 80;
	shieldShapeName = "shield";
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

//------------------------------------------------------------------------

StaticShapeData DeployableForceField
{
	className = "DeployableForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_4x8";
	maxDamage = 2.5;
	maxEnergy = 50;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = debrisExpSmall;
	debrisId = flashDebrisSmall;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = true;
};

function DeployableForceField::Destruct(%this)
{
	DeployableForceField::doDamage(%this);
}

function DeployableForceField::doDamage(%this) 
{
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170);
}

function DeployableForceField::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = $Server::TeamDamageScale * 0.1;
	if(%type == $ElectricityDamageType || %type == $ElectricDamageType)
		GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * 3);
	else
		GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * $DoorScale[%type]);
	if(%type == $DecloakDamageType)
	{
		if(%this.cloaked >= 1 || %this.cloakdevice >= 1 || %this.cloakGun == 1)
		{
			%this.cloaked = 0;
			%this.cloakdevice = 0;
			%this.cloakGun = 0;
			GameBase::playSound(%this,ForceFieldOpen,0);
			GameBase::startFadein(%this);
		}
	}
	else if(%type == $EMPDamageType)
	{
		GameBase::startfadeout(%this);
		%pos=GameBase::getPosition(%this);
		%pos=Vector::add(%pos,"0 0 6");
		GameBase::setPosition(%this,%pos);
		schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
		schedule("DeployableLargeForceField::closeDoor("@%this@");",15);
	}
}

function DeployableForceField::onDestroyed(%this)
{
	DeployableForceField::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableForceField"]--;
}

function DeployableForceField::onCollision(%this,%obj)
{
	%c = Player::getClient(%obj);
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
	{
		return;
	}
	DeployableLargeForceField::openDoor(%this);
	return;
}

//------------------------------------------------------------------------

StaticShapeData DeployableLargeForceField
{
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_4x14";
	maxDamage = 10.0;
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
	description = "Large Force Field";
};

function DeployableLargeForceField::Destruct(%this)
{
	DeployableLargeForceField::doDamage(%this);
}

function DeployableLargeForceField::doDamage(%this)
{
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function DeployableLargeForceField::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = $Server::TeamDamageScale * 0.1;
	if(%type == $ElectricityDamageType || %type == $ElectricDamageType)
		GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * 5);
	else
		GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * $DoorScale[%type]);
	if(%type == $DecloakDamageType)
	{
		if(%this.cloaked >= 1 || %this.cloakdevice >= 1 || %this.cloakGun == 1)
		{
			%this.cloaked = 0;
			%this.cloakdevice = 0;
			%this.cloakGun = 0;
			GameBase::playSound(%this,ForceFieldOpen,0);
			GameBase::startFadein(%this);
		}
	}
	else if(%type == $EMPDamageType)
	{
		GameBase::startfadeout(%this);
		%pos=GameBase::getPosition(%this);
		%pos=Vector::add(%pos,"0 0 6");
		GameBase::setPosition(%this,%pos);
		schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
		schedule("DeployableLargeForceField::closeDoor("@%this@");",15);
	}
}

function DeployableLargeForceField::onDestroyed(%this)
{
	DeployableLargeForceField::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableLargeForceField"]--;
}

function DeployableLargeForceField::onCollision(%this,%obj)
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
	DeployableLargeForceField::openDoor(%this);
	return;
}

function DeployableLargeForceField::openDoor(%this)
{
	GameBase::startfadeout(%this);

	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("DeployableLargeForceField::closeDoor("@%this@");",4);
}

function DeployableLargeForceField::closeDoor(%this)
{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -6");
	GameBase::setPosition(%this,%pos);
	if(%this.cloaked == 0 && %this.cloakdevice == 0 && %this.cloakGun == 0)
	{
		GameBase::startfadein(%this);
		schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
	}
}

//------------------------------------------------------------------------

StaticShapeData DShield
{
	className = "DShield";
	damageSkinData = "objectDamageSkins";
	shapeFile = "generator_p"; 
	maxDamage = 1.4;
	maxEnergy = 500;
	sfxAmbient = SoundGeneratorPower;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	mass=2.5;
	shieldShapeName = "shield_medium";
};

function DShield::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function DShield::onEnabled(%this)
{
	DShield::setActive(%this,true);
}

function DShield::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
	%t=GameBase::getTeam(%this);
	%obc1=Group::objectCount("MissionCleanup/CASimSet" @%this@"!"@ %t);
	echo("DShield::onDisabled("@%this@")");
	echo("        Object Count: "@%obc1);
	for(%i=0;%i<%obc1;%i++)
	{
		%objt1=Group::getObject("MissionCleanup/CASimSet"@%this@"!"@%t,%i);
		echo("        Stop Protecting: "@%objt1);
		DShield::StopProtecting(%objt1);
		if(Player::GetClient(%objt1)!=-1)
		{
			Client::sendMessage(Player::getClient(%objt1),1,"WARNING:  Shield flux failure!");
		}
		GameBase::applyDamage(%objt1,$CrushDamageType,0.15,GameBase::getPosition(%objt1),"0 0 0","0 0 0",%this);
	}
	deleteObject("MissionCleanup/CASimSet"@%this@"!"@%t);
}

function DShield::onDestroyed(%this)
{
	DShield::onDisabled(%this);
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);
	$TeamItemCount[GameBase::getTeam(%this) @ "DShieldPack"]--;
	%teleset = nameToID("MissionCleanup/Teleports");
}

function DShield::StartProtecting(%this)
{
	if(%this.shieldStrength < 0.00)
		%this.shieldStrength = 0.00;
	%this.shieldStrength += $DShield::ShieldEnhance;
}

function DShield::StopProtecting(%this)
{
	%this.shieldStrength -= $DShield::ShieldEnhance;
	if(%this.shieldStrength < 0.00)
		%this.shieldStrength = 0.00;
}

function DShield::onActivate(%this)
{
	GameBase::playSequence(%this,0,"power");
}

function DShield::setActive(%this)
{
	GameBase::playSequence(%this,0,"power");
}

function DShield::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
	playSound(SoundGeneratorPower,GameBase::getposition(%this));
}

function DShield::checkAreaCreateSimSet(%this,%t)
{
	%testset = nameToID("MissionCleanup/CASimSet"@%this@"!"@%t);
	if(%testset == -1)
	{
		newObject("CASimSet"@%this@"!"@%t,SimSet);
		addToSet("MissionCleanup","CASimSet"@%this@"!"@%t);
	}
}

function DShield::removeFromSet(%set,%index,%t,%this)
{
	%nset=newObject("DSRFSREPLACE",SimSet);
	for(%i=0;%i<Group::objectCount(%set);%i++)
	{
		if(%i!=%index)
		{
			addToSet(%nset,Group::GetObject(%set,%i));
		}
	}
	deleteObject(%set);
	DShield::checkAreaCreateSimSet(%this,%t);
	for(%i=0;%i<Group::objectCount(%nset);%i++)
	{
		addToSet(%set,Group::GetObject(%nset,%i));
	}
	deleteObject(%nset);
}

function DShield::checkArea(%this)
{
	%pos=GameBase::getPosition(%this);
	if(%pos!="0 0 0") 
	{
		if(GameBase::getDamageState(%this)!="Enabled")
		{
			schedule("DShield::checkArea("@%this@");",$DShield::TimerTick*6);
			return;
		}
		%t=GameBase::getTeam(%this);
		%testset=newObject("shieldtestset","SimSet");
		%mask=$SimPlayerObjectType;
		%intestset=containerBoxFillSet(%testset,%mask,%pos,$DShield::ProtectArea,$DShield::ProtectArea,$DShield::ProtectArea,0);
		DShield::checkAreaCreateSimSet(%this,%t);
		%casimset=nameToId("MissionCleanup/CASimSet"@%this@"!"@%t);
		if(%testset==-1||%casimset==-1)
		{
			deleteObject(%testset);
			echo("ERROR in DShield::checkArea! (%testset="@%testset@" %casimset="@%casimset);
			return;
		}
		%obc1=Group::objectCount("MissionCleanup/CASimSet"@%this@"!"@%t);
		%obc2=Group::objectCount(%testset);
		for(%i=0;%i<%obc2;%i++)
		{
			%objt1=Group::getObject(%testset,%i);
			if(GameBase::getTeam(%objt1)==GameBase::getTeam(%this))
			{
				if(Player::getClient(%objt1).traitor == 0)
				{
					for(%it=0;%it<%obc1+1;%it++)
					{
						if(%it<%obc1)
						{
							%objt2=Group::getObject("MissionCleanup/CASimSet"@%this@"!"@%t,%it);
							if(%objt1==%objt2)
							{
								break;
							}
						}
						else if((%this!=%objt1)&&%objt1.shieldStrength<0.0001)
						{
							addToSet("MissionCleanup/CASimSet"@%this@"!"@%t,%objt1);
							DShield::StartProtecting(%objt1);
							if(Player::GetClient(%objt1)!=-1)
							{
								Client::sendMessage(Player::getClient(%objt1),1,"Shield Energy System Enhanced.");
							}
						}
					}
				}
				else
				{
					%t=getsimtime();
					if(%t-%objt1.headachetime>3)
					{
						if(%t-%objt1.headachetime>7)
							Client::sendMessage(Player::getClient(%objt1),1,"Your head throbs with pain!");
						%objt1.headachetime=getsimtime();
						Player::setDamageFlash(%objt1,Player::getDamageFlash(%objt1)+0.03);
						GameBase::applyDamage(%objt1,$CrushDamageType,0.03,GameBase::getPosition(%objt1),"0 0 0","0 0 0",%this);
					}
				}
			}
		}
		%lt=True; 
		%lc=0; 
		while(%lt&&lc<500)
		{
			%lc++;
			%lt=False;
			%obc1=Group::objectCount("MissionCleanup/CASimSet" @%this@"!"@ %t);
			%obc2=Group::objectCount(%testset);
			%it=0;
			for(%i=0;%i<%obc1;%i++)
			{
				%objt1=Group::getObject("MissionCleanup/CASimSet"@%this@"!"@%t,%i);
				for(%it=0;%it<%obc2+1;%it++)
				{
					if(%it<%obc2)
					{
						%objt2=Group::getObject(%testset,%it);
						if(%objt1==%objt2)
						{
							break;
						}
					}
					else
					{
						DShield::StopProtecting(%objt1);
						DShield::removeFromSet("MissionCleanup/CASimSet"@%this@"!"@%t,%i,%t,%this);
						if(Player::GetClient(%objt1)!=-1)
						{
							Client::sendMessage(Player::getClient(%objt1),1,"Shield Energy System returns to normal.");
						}
						%lt=True;
						break;
					}
				}
				if(%lt)
					break;
			}
		}
		%obc1=Group::objectCount("MissionCleanup/CASimSet" @%this@"!"@ %t);
		for(%i=0;%i<%obc1;%i++)
		{
			%objt1=Group::getObject("MissionCleanup/CASimSet"@%this@"!"@%t,%i);
			%e=GameBase::getEnergy(%this);
			if(%e-$DShield::MaxCapCharge>0 && $empTime[Player::getClient(%objt1)] <= 0)
			{
				%curenergy=GameBase::getEnergy(%objt1);
				GameBase::setEnergy(%objt1,%curenergy+$DShield::MaxCapCharge);
				if(%curenergy!=GameBase::getEnergy(%objt1))
				{
					GameBase::setEnergy(%this,GameBase::getEnergy(%this)-$DShield::MaxCapCharge);
				}
			}
		}
		deleteObject(%testset);
		schedule("DShield::checkArea("@%this@");",$DShield::TimerTick);
	}
}

//------------------------------------------------------------------------

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

//------------------------------------------------------------------------

StaticShapeData Canister
{
	description = "Flame Turret Fuel";
	shapeFile = "liqcyl";
	className = "Decoration";
	debrisId = flashDebrisMedium;
	maxDamage = 0.55;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;

};

//------------------------------------------------------------------------

function ObeliskPower::onEnabled(%this)
{
	if (!%this.obelisk)
	{
		%Set = newObject("set",SimSet); 
		%Mask = $StaticObjectType; 
		%num =containerBoxFillSet(%Set, %Mask, $los::position, 70, 70, 50,0);
		for(%i; %i < %num; %i++)
		{
			%turret = Group::getObject(%Set, %i);
			if(%turret.buggered)
			{
				%buggered = true;
				break;
			}
		}
		deleteObject(%Set);
		if(%buggered)
		{
			%this.obelisk = %turret;
			%turret.gen = %this;
			
		}
	}
	GameBase::setActive(%this,true);
}

function ObeliskPower::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
//	GameBase::setDamageLevel(%this.obelisk, 20); //kill the turret when it goes down
	%obelisk = %this.obelisk;
	if(!%obelisk.buggered)
	{
		%obelisk.truerecharge = GameBase::getRechargeRate(%obelisk);
		%obelisk.buggered = 1;
		GameBase::setRechargeRate(%obelisk, 0);
		GameBase::setEnergy(%obelisk, 0);
		if(%obelisk.stand > 0)
			GameBase::stopSequence(%obelisk.stand,0);
	}
}

function ObeliskPower::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "ObeliskPowerPack"]--;
	Generator::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
	%obelisk = %this.obelisk;
	if(!%obelisk.buggered)
	{
		%obelisk.truerecharge = GameBase::getRechargeRate(%obelisk);
		%obelisk.buggered = 1;
		GameBase::setRechargeRate(%obelisk, 0);
		GameBase::setEnergy(%obelisk, 0);
		if(%obelisk.stand > 0)
			GameBase::stopSequence(%obelisk.stand,0);
	}
}

function ObeliskPower::onActivate(%this)
{
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
	%obelisk = %this.obelisk;
	if(%obelisk.buggered)
	{
		GameBase::setRechargeRate(%obelisk,%obelisk.truerecharge);
		%obelisk.buggered = 0;
		if(%obelisk.stand > 0)
		{
			if(GameBase::getDamageState(%obelisk.stand) == "Enabled")
				GameBase::playSequence(%obelisk.stand,0,"power");
		}
	}
}

function ObeliskPower::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
//	GameBase::setDamageLevel(%this.obelisk, 20); //kill the turret when it goes down
	%obelisk = %this.obelisk;
	if(!%obelisk.buggered)
	{
		%obelisk.truerecharge = GameBase::getRechargeRate(%obelisk);
		%obelisk.buggered = 1;
		GameBase::setRechargeRate(%obelisk, 0);
		GameBase::setEnergy(%obelisk, 0);
		if(%obelisk.stand > 0)
			GameBase::stopSequence(%obelisk.stand,0);
	}
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
	shieldShapeName = "shield_medium";
	maxEnergy = 100;
};

StaticShapeData ObeliskOfLight
{
	description = "Obelisk of Light";
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
	sfxAmbient = SoundBuzz;
};

function ObeliskOfLight::onDestroyed(%this)
{
	GameBase::stopSequence(%this,0);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100); 

	%realGun = %this.realGun;
	GameBase::setDamageLevel(%realGun, 10);
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

//------------------------------------------------------------------------

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
	triggerRadius = 30.0;
};

function AlarmKit::onCollision(%this, %object)
{


	%type = getObjectType(%object);

	if (%type == "Player")
	{
		// $pause[%this] = 1;
		%name = Player::getClient(%object);
		%name = Client::getName(%name);
		%team = GameBase::getTeam(%object);
		%itemTeam = GameBase::getTeam(%this);

		if(%team != %itemTeam)
		{
			// TeamMessages(1, %itemTeam,GameBase::GetMapName(%this) @ " has been tripped! By: " @ %name @ "~wLeftMissionArea.wav");
			playSound(AlarmBeep,GameBase::getPosition(%this));

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

//------------------------------------------------------------------------

StaticShapeData AntiMatterStand
{
	shapeFile = "anten_lrg";
	debrisId = defaultDebrisSmall;
	maxDamage = 10.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
	description = "Obelisk of Death";
};

function AntiMatterStand::onDestroyed(%this)
{
}

function AntiMatterStand::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if($RSP::AntiMatterTurretID[%this])
		Turret::onDamage($RSP::AntiMatterTurretID[%this],%type,%value * 0.75,%pos,%vec,%mom,%object);
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

//------------------------------------------------------------------------

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

function LargeAirBasePlatform::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type == $DecloakDamageType)
	{
		if(%this.cloaked >= 1 || %this.cloakdevice >= 1 || %this.cloakGun == 1)
		{
			%this.cloaked = 0;
			%this.cloakdevice = 0;
			%this.cloakGun = 0;
			GameBase::playSound(%this,ForceFieldOpen,0);
			GameBase::startFadein(%this);
		}
	}
}

//------------------------------------------------------------------------

StaticShapeData BlastWallShape
{
        shapeFile = "newdoor5";
        debrisId = defaultDebrisLarge;
        maxDamage = 10.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Portable Wall";
	damageSkinData = "objectDamageSkins";
};

function BlastWallShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = 2;
	GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * $DoorScale[%type]);
}

function BlastWallShape::onDestroyed(%this)
{
	GameBase::stopSequence(%this,0);
	StaticShape::objectiveDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastWall"]--;

}



//------------------------------------------------------------------------

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
		Client::SendMessage(%c,0,"You Stepped On Your Team's Jail Capture Pad");
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

//------------------------------------------------------------------------

StaticShapeData LLargeForceField
{
        shapeFile = "forcefield";
        debrisId = defaultDebrisLarge;
        maxDamage = 200.00;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Jail Cell";
};

function LLargeForceField::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = $Server::TeamDamageScale * 0.1;
	if(%type == $ElectricityDamageType || %type == $ElectricDamageType)
		GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * 5);
	else
		GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * $DoorScale[%type]);
	if(%type == $DecloakDamageType)
	{
		if(%this.cloaked >= 1 || %this.cloakdevice >= 1 || %this.cloakGun == 1)
		{
			%this.cloaked = 0;
			%this.cloakdevice = 0;
			%this.cloakGun = 0;
			GameBase::playSound(%this,ForceFieldOpen,0);
			GameBase::startFadein(%this);
		}
	}
}

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

function jLargeForceField::doDamage(%this) 
{
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function jLargeForceField::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = $Server::TeamDamageScale * 0.1;
	if(%type == $ElectricityDamageType || %type == $ElectricDamageType)
		GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * 5);
	else
		GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * $DoorScale[%type]);
	if(%type == $DecloakDamageType)
	{
		if(%this.cloaked >= 1 || %this.cloakdevice >= 1 || %this.cloakGun == 1)
		{
			%this.cloaked = 0;
			%this.cloakdevice = 0;
			%this.cloakGun = 0;
			GameBase::playSound(%this,ForceFieldOpen,0);
			GameBase::startFadein(%this);
		}
	}
	else if(%type == $EMPDamageType)
	{
		GameBase::startfadeout(%this);
		%pos=GameBase::getPosition(%this);
		%pos=Vector::add(%pos,"0 0 6");
		GameBase::setPosition(%this,%pos);
		schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
		schedule("DeployableLargeForceField::closeDoor("@%this@");",15);
	}
}

function jLargeForceField::onDestroyed(%this)
{
	jLargeForceField::doDamage(%this);
//	$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}

function jLargeForceField::onCollision(%this,%obj)
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
	DeployableLargeForceField::openDoor(%this);
	return;
}

function jLargeForceField::jailSesame(%obj)
{
	%teleset = nameToID("MissionCleanup/releasepad");
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		%oteam=GameBase::getTeam(%o);
		if(%oteam != GameBase::getTeam(%obj) && Vector::getDistance(GameBase::GetPosition(%obj),GameBase::GetPosition(%o)) <= 10)
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

//------------------------------------------------------------------------

StaticShapeData Springboard
{
        shapeFile = "flagstand";
        debrisId = defaultDebrisSmall;
        maxDamage = 2.00;
        visibleToSensor = false;
        isTranslucent = true;
        description = "Deployable Spring";
        visibleToSensor = true;
};

function Springboard::onDestroyed(%this)
{
        StaticShape::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "Springboard"]--;
}

function Springboard::onCollision(%this,%obj)
{
        %c = Player::getClient(%obj);
        %vecVelocity = Item::getVelocity(%obj);
        %rnd = floor(getRandom() * 55);
	if (%rnd == 1)
        {
                GameBase::playSound(%this, debrisLargeExplosion, 0);
                %HMult = 2;
                %ZMax = 50;
                %rnd = floor(getRandom() * 3);
        }
        else if (%rnd > 45)
	{
                GameBase::playSound(%this, debrisLargeExplosion, 0);
                %HMult = 2;
                %ZMax = 50;
        }
        else
        {
                GameBase::playSound(%this, SoundFireMortar, 0);
                %HMult = 2;
                %ZMax = 45;
        }
        %vecNewVelocity = GetWord(%vecVelocity, 0) * %HMult @ " " @ GetWord(%vecVelocity, 1) * %HMult @ " " @ %ZMax;
        Item::setVelocity(%obj, %vecNewVelocity);
}

//------------------------------------------------------------------------

StaticShapeData OutpostGen
{
	description = "Portable Generator";
	shapeFile = "generator_p";
	className = "Generator";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundGeneratorPower;
	maxDamage = 0.5;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
	shieldShapeName = "shield";
	maxEnergy = 100;
};

function OutpostGen::onDestroyed(%this)
{
	GameBase::applyDamage($OutpostDevices[%this,1],$DebrisDamageType,1000,GameBase::getPosition($OutpostDevices[%this,1]),"0 0 0","0 0 0",%this);
	GameBase::applyDamage($OutpostDevices[%this,2],$DebrisDamageType,1000,GameBase::getPosition($OutpostDevices[%this,2]),"0 0 0","0 0 0",%this);
	GameBase::applyDamage($OutpostDevices[%this,3],$DebrisDamageType,1000,GameBase::getPosition($OutpostDevices[%this,3]),"0 0 0","0 0 0",%this);
	GameBase::applyDamage($OutpostDevices[%this,4],$DebrisDamageType,1000,GameBase::getPosition($OutpostDevices[%this,4]),"0 0 0","0 0 0",%this);
	GameBase::applyDamage($OutpostDevices[%this,5],$DebrisDamageType,1000,GameBase::getPosition($OutpostDevices[%this,5]),"0 0 0","0 0 0",%this);
	GameBase::applyDamage($OutpostDevices[%this,6],$DebrisDamageType,1000,GameBase::getPosition($OutpostDevices[%this,6]),"0 0 0","0 0 0",%this);
	GameBase::applyDamage($OutpostDevices[%this,7],$DebrisDamageType,1000,GameBase::getPosition($OutpostDevices[%this,7]),"0 0 0","0 0 0",%this);
	GameBase::applyDamage($OutpostDevices[%this,8],$DebrisDamageType,1000,GameBase::getPosition($OutpostDevices[%this,8]),"0 0 0","0 0 0",%this);
	GameBase::applyDamage($OutpostDevices[%this,9],$DebrisDamageType,1000,GameBase::getPosition($OutpostDevices[%this,9]),"0 0 0","0 0 0",%this);
	GameBase::applyDamage($OutpostDevices[%this,10],$DebrisDamageType,1000,GameBase::getPosition($OutpostDevices[%this,10]),"0 0 0","0 0 0",%this);
	GameBase::applyDamage($OutpostDevices[%this,11],$DebrisDamageType,1000,GameBase::getPosition($OutpostDevices[%this,11]),"0 0 0","0 0 0",%this);
	GameBase::applyDamage(%this.bigstation,$flamedamagetype,100.05,GameBase::getPosition(%this.bigstation),"0 0 0","0 0 0",%this);

	Generator::onDestroyed(%this);

	%obj = newObject("","Mine","NukeBomb");
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,-100.5,false);

	%obj = newObject("","Mine","NukeBomb");
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,-100.5,false);

	$TeamItemCount[GameBase::getTeam (%this) @ "OutpostPack"]--;
	CalcRadiusDamage (%this, $DebrisDamageType, 20, 1000.2, 1025, 20, 20, 52.5, 51.1, 200, 100);
}

StaticShapeData OutpostFloor
{
	description = "Outpost";
	shapeFile = "elevator16x16_octo";
	debrisId = defaultDebrisLarge;
	maxDamage = 500.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	mapFilter = 4;
};

function OutpostFloor::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = $Server::TeamDamageScale * 0.1;
	GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * $DoorScale[%type]);
	if(%type == $DecloakDamageType)
	{
		if(%this.cloaked >= 1 || %this.cloakdevice >= 1 || %this.cloakGun == 1)
		{
			%this.cloaked = 0;
			%this.cloakdevice = 0;
			%this.cloakGun = 0;
			GameBase::playSound(%this,ForceFieldOpen,0);
			GameBase::startFadein(%this);
		}
	}
}


StaticShapeData OutpostWall
{
	shapeFile = "newdoor5";
	maxDamage = 300.0;
	debrisId = defaultDebrisLarge;
	visibleToSensor = true;
	explosionId = debrisExpLarge;
	description = "Blast Wall";
};

function OutpostWall::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = $Server::TeamDamageScale * 0.1;
	GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * $DoorScale[%type]);
	if(%type == $DecloakDamageType)
	{
		if(%this.cloaked >= 1 || %this.cloakdevice >= 1 || %this.cloakGun == 1)
		{
			%this.cloaked = 0;
			%this.cloakdevice = 0;
			%this.cloakGun = 0;
			GameBase::playSound(%this,ForceFieldOpen,0);
			GameBase::startFadein(%this);
		}
	}
}

function OutpostWall::onDestroyed (%this)
{
	StaticShape::onDestroyed (%this);
}

StaticShapeData OutpostDoor
{
  description = "Outpost Door";
  className = "LargeForceField";
  damageSkinData = "objectDamageSkins";
  shapeFile = "forcefield_4x8";
  maxDamage = 100.0;
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

function OutpostDoor::Destruct(%this)
{
	OutpostDoor::doDamage(%this);
}

function OutpostDoor::doDamage(%this)
{
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function OutpostDoor::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = $Server::TeamDamageScale * 0.1;
	if(%type == $ElectricityDamageType || %type == $ElectricDamageType)
		GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * 5);
	else
		GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * $DoorScale[%type]);
	if(%type == $DecloakDamageType)
	{
		if(%this.cloaked >= 1 || %this.cloakdevice >= 1 || %this.cloakGun == 1)
		{
			%this.cloaked = 0;
			%this.cloakdevice = 0;
			%this.cloakGun = 0;
			GameBase::playSound(%this,ForceFieldOpen,0);
			GameBase::startFadein(%this);
		}
	}
	else if(%type == $EMPDamageType)
	{
		GameBase::startfadeout(%this);
		%pos=GameBase::getPosition(%this);
		%pos=Vector::add(%pos,"0 0 6");
		GameBase::setPosition(%this,%pos);
		schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
		schedule("DeployableLargeForceField::closeDoor("@%this@");",15);
	}
}

function OutpostDoor::onDestroyed(%this)
{
	OutpostDoor::doDamage(%this);
}

function OutpostDoor::onCollision(%this, %obj)
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
	DeployableLargeForceField::openDoor(%this);
	return false;
}

//------------------------------------------------------------------------

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
	shieldShapeName = "shield";
	maxEnergy = 60;
};

function RemoteSolarPanel::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam (%this) @ "DeployableSolarPanel"]--;
	Generator::onDestroyed(%this);
}

//------------------------------------------------------------------------

StaticShapeData TemporaryAirPad
{
        shapeFile = "elevator6x6thin";
        debrisId = defaultDebrisLarge;
        maxDamage = 5.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "Temporary Platform";
};

//------------------------------------------------------------------------

StaticShapeData TemporaryGenerator
{
	description = "Temporary Generator";
	shapeFile = "generator_p";
	className = "Generator";
	maxDamage = 1000;
	visibleToSensor = false;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};

//------------------------------------------------------------------------

StaticShapeData DoomsdayDevice
{
	description = "Doomsday Device";
	shapeFile = "sensor_small";
	debrisId = flashDebrisLarge;
	maxDamage = 15.0;
	mapIcon = "M_marker";
	damageSkinData = "objectDamageSkins";
	visibleToSensor = true;
	triggerRadius = 10.0;
};

function DoomsdayDevice::onCollision(%this, %object)
{
	%type = getObjectType(%object);
	if (%type == "Player" && !$pause[%this])
	{
		%team = GameBase::getTeam(%object);
		%itemTeam = GameBase::getTeam(%this);
		if(%team != %itemTeam)
		{
			$pause[%this] = 1;
			%detonationtime = 5;
			DoomTrigger(%this,%detonationtime);
		}
	}		
}

function DoomTrigger(%this,%detonationtime)
{
	if (%detonationtime > 0)
	{
		%Set = newObject("set",SimSet); 
		%Pos = GameBase::getPosition(%this); 
		%Mask = $SimPlayerObjectType;
		containerBoxFillSet(%Set, %Mask, %Pos, 20, 20, 20,0);
		%num = Group::objectCount(%Set);
		for(%i; %i < %num; %i++)
		{
			%obj = Group::getObject(%Set, %i);
			%client = GameBase::getOwnerClient(%obj);
			Client::sendMessage(%client,1,"Doomsday Device: Detonation in " @ %detonationtime @ " seconds.");
		}
		deleteObject(%Set);
		GameBase::playSound(%this,DoomBeep,0);
		%detonationtime--;
		schedule("DoomTrigger(" @ %this @ "," @ %detonationtime @ ");",1,%this);
	}
	else
	{
		%obj = newObject("","Mine","KamikazeBomb");
		addToSet("MissionCleanup", %obj);
		GameBase::setTeam(%obj, GameBase::getTeam(%this));
		GameBase::throw(%obj,%this,1,true);
		schedule("DoomsdayDevice::Cleanup(" @ %this @ ");",1,%this);
		$TeamItemCount[GameBase::getTeam(%this) @ "DoomsdayMine"]--;
	}
}

function DoomsdayDevice::Cleanup(%this)
{
	deleteObject(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "DoomsdayMine"]--;
}

function DoomsdayDevice::onAdd(%this)
{	
}
																						 
function DoomsdayDevice::onEnabled(%this)
{
}

function DoomsdayDevice::onDisabled(%this)
{
}

function DoomsdayDevice::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "DoomsdayMine"]--;
}

//------------------------------------------------------------------------


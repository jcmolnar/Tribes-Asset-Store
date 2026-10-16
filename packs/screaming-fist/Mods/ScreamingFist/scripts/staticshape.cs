echo("Loading Screaming Fist Version");
//------------------------------------------------------------------------
// Generic static shapes
//------------------------------------------------------------------------


//------------------------------------------------------------------------
// Default power animation behavior for all static shapes

function StaticShape::onPower(%this,%power,%generator)
{
	%this.shieldStrength = 0;
	if (%power) 
		GameBase::playSequence(%this,0,"power");
	else 
		GameBase::stopSequence(%this,0);
}

function StaticShape::onEnabled(%this)
{
	%this.shieldStrength = 0;
	if (GameBase::isPowered(%this)) 
		GameBase::playSequence(%this,0,"power");
}

function StaticShape::onDisabled(%this)
{
	%this.shieldStrength = 0;
	GameBase::stopSequence(%this,0);
}

function StaticShape::onDestroyed(%this)
{
	%this.shieldStrength = 0;
	GameBase::stopSequence(%this,0);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 
		0.1, 250, 100); 
}

function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	//*************************************************************************************************************
	// SF Addition - Begin - 7/19/99 - 3:30AM
	//*************************************************************************************************************
	%this.shieldStrength = 0;
	if(%type == $FBWMissleDamageType)
	{
		%object = $FBWClientIDonRemove;
		%value = 2.0;
	}
	//*************************************************************************************************************
	// SF Addition - End
	//*************************************************************************************************************
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	%name = GameBase::getDataName(%this);

	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
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

	//Attack Game Type
	if( $AttackGameType == TRUE && GameBase::getTeam(%this) == 0 && (%name.className == Generator || %name.className == Station) )
		%dValue = 0;

	GameBase::setDamageLevel(%this,%dValue);
}

function StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%this.shieldStrength = 0;
	%damageLevel = GameBase::getDamageLevel(%this);
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
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

// SF ADDITION
// -----by Enigma-----
StaticShapeData OspreyIdle {
	description = "Osprey";
	shapeFile = "Osprey";
	visibleToSensor = true;
	sfxAmbient = SoundOspreyIdle;
	mapFilter = 2;
	mapIcon = "M_vehicle";
};

function OspreyIdle::onDamage() 
{
}
// END SF ADDITION

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
	maxDamage = 1.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	description = "Small Antenna";
};

//------------------------------------------------------------------------
StaticShapeData Pshack
{
	shapeFile = "pshack";
	maxDamage = 10.0;
	isTranslucent = false;
    description = "PShack";
	disableCollision = false;
};

StaticShapeData streetlamp
{
	shapeFile = "streetlamp";
	maxDamage = 10000.0;
	isTranslucent = false;
    description = "streetlamp";
	disableCollision = false;
};

StaticShapeData wodncrate
{
	shapeFile = "wodncrate";
	maxDamage = 10.0;
	isTranslucent = flase;
    description = "wodncrate";
	disableCollision = false;
};



//************************************************************************
// SF ADDITION - Begin - 8/27/99 - 3:30PM
//************************************************************************

// Destroyable Bridge

StaticShapeData CollapsableBridge
{
	shapeFile = "bridge";
	debrisId = NoDebris;
	maxDamage = 25.0;
	damageSkinData = "bridgeDamageSkins";
	shadowDetailMask = 16;
	explosionId = NoExplosion;
	description = "Bridge";
};

function CollapsableBridge::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	//echo("%type ",%type);
	if( %type == $MinigunDamageType || %type == $AssRifleDamageType || %type == $SniperRifleDamageType || %type == $GlockDamageType || %type == $MAWAssRifleDamageType || %type == $MAWIncendiaryRifleDamageType || %type == $MAWGrenadeLauncherDamageType || %type == $ShotgunDamageType || %type == $FlashDamageType)
	{
		%value = 0.0;
	}
	
	%damageLevel = GameBase::getDamageLevel(%this);
	//echo("%damageLevel ",%damageLevel);
	%dValue = %damageLevel + %value;
   	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	GameBase::setDamageLevel(%this,%dValue);
}

function CollapsableBridge::onDestroyed(%this)
{
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	deleteObject(%this);
	
	%bridgedebris = newObject("", "StaticShape", BridgeDebris, true);
	addToSet("MissionCleanup", %bridgedebris);
	GameBase::setPosition(%bridgedebris,%pos);
	GameBase::setRotation(%bridgedebris,%rot);
	GameBase::setActive(%bridgedebris, true);
	schedule("GameBase::setDamageLevel("@%bridgedebris@", 2.1);",1.0);
	
	%destroyedBridge = newObject("", "StaticShape", DestroyedBridge, true);
	addToSet("MissionCleanup", %destroyedBridge);
	GameBase::setPosition(%destroyedBridge,%pos);
	GameBase::setRotation(%destroyedBridge,%rot);
}

StaticShapeData BridgeDebris
{
	shapeFile = "bridgedebris";
	debrisId = bridgeDebrisLarge;
	maxDamage = 2.0;
	shadowDetailMask = 16;
	explosionId = NoExplosion;
	description = "Bridge";
};

StaticShapeData DestroyedBridge
{
	shapeFile = "brokenbridge";
	debrisId = bridgeDebrisLarge;
	maxDamage = 10000.0;
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	description = "Bridge";
};

//--------------------------------------------------------

// Destroyable Shack

StaticShapeData Shack
{
	shapeFile = "shack";
	debrisId = NoDebris;
	maxDamage = 5.0;
	shadowDetailMask = 16;
	damageSkinData = "objectDamageSkins";
	explosionId = NoExplosion;
	description = "Ammo Shack";
};

function Shack::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	//echo("%type ",%type);
	
	%damageLevel = GameBase::getDamageLevel(%this);
	//echo("%damageLevel ",%damageLevel);
	%dValue = %damageLevel + %value;
   	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	GameBase::setDamageLevel(%this,%dValue);
}

function Shack::onDestroyed(%this)
{
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	deleteObject(%this);
	
	%obj = newObject("", "StaticShape", ShackDebris, true);
	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj,%pos);
	GameBase::setRotation(%obj,%rot);
	GameBase::setActive(%obj, true);
	schedule("GameBase::setDamageLevel("@%obj@", 2.1);",1.0);
	
	%obj = newObject("", "StaticShape", ShackCollapsed, true);
	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj,%pos);
	GameBase::setRotation(%obj,%rot);
}

StaticShapeData ShackDebris
{
	shapeFile = "shackdebris";
	debrisId = bridgeDebrisLarge;
	maxDamage = 2.0;
	shadowDetailMask = 16;
	explosionId = NoExplosion;
	description = "Ammo Shack";
};

StaticShapeData ShackCollapsed
{
	shapeFile = "shackcollapsed";
	debrisId = bridgeDebrisLarge;
	maxDamage = 10000.0;
	shadowDetailMask = 16;
	explosionId = NoExplosion;
	description = "Ammo Shack";
};

//Ladder code

StaticShapeData Ladder
{
	shapeFile = "ladder";
	debrisId = NoDebris;
	maxDamage = 10000.0;
	shadowDetailMask = 16;
	explosionId = NoExplosion;
	description = "Ladder";
};

function Ladder::onCollision(%this, %object)
{
	if (getObjectType(%object) == "Player")
	{
		//echo("Ladder onCollision");
		Player::onCollision(%object, %this);
	}
}

function ClimbLadder(%player, %ladder)
{
	%playerpos = GameBase::getPosition(%player);
	%playerz = getWord(%playerpos, 2);
	//echo("%pos - ClimbLadder ",%playerz);
	
	%ladderpos = GameBase::getPosition(%ladder);
	%ladderz = getWord(%ladderpos, 2);
	//echo("%pos - ClimbLadder ",%ladderz);
	
	%distancez = %playerz - %ladderz;
	//echo("%distance - ClimbLadder",%distance);
	
	if( Player::isJetting(%player) == false  )
	{
		if( %distancez <= 2.1 && Player::isDead(%player) != true)
		{
			%rot = "0 0 0";
			%vel = item::getVelocity(%player);
			%vel = getWord(%vel, 2);
			//echo(%vel);
			if( %vel <= 10 )
			{
				%vec = Vector::getFromRot(%rot, 0, 20 - %vel);
				Player::applyImpulse(%player, %vec);
			}
			
			schedule("ClimbLadder("@%player@","@%ladder@");",0.1, %player);
		}
		else
		{
			%rot = GameBase::getRotation(%ladder);
			%addrot = "0 0 1.571";
			%newrot = Vector::add(%rot, %addrot);
			//echo("%newrot ",%newrot);
			%vec = Vector::getFromRot(%newrot, 10, 0);
			//echo("%vec - LadderClimb - top of ladder ",%vec);
			Player::applyImpulse(%player, %vec);
		}
	}
}

//---------------------------------------------------------------

// Detpack
StaticShapeData defaultDetpack
{
	shapeFile = "detpack";
	debrisId = NoDebris;
	maxDamage = 1.0;
	shadowDetailMask = 1;
	explosionId = DetpackExp;
	Explode = false;
	description = "Detpack";
	Disarmed = FALSE;
};

function defaultDetpack::onRemove(%this)
{
	if($status[%this] != "disarmed")
	{
		%center = $DetpackCenter[%this];
		%cl = $playerID[%this];
		
		%damageApplied = GameBase::applyRadiusDamage(7, %center, 25, 10.0, 150, %cl);
	}
	//echo($DetpackTeam[%this]);
	$TeamItemCount[ $DetpackTeam[%this] @ "Detpack"]--;
	$DetpackTeam[%this] = -1;
	$playerID[%this] = 0;
	$DetpackCenter[%this] = 0;
}

//--- Spring Board ---//

StaticShapeData springBoard
{
	shapeFile = "flagstand";
	debrisId = NoDebris;
	maxDamage = 10000.0;
	shadowDetailMask = 16;
	explosionId = NoExplosion;
	description = "Spring Board";
};

//--- Spring Board ---//

function springBoard::onCollision(%this, %object)
{
	//stuff
	%client = Player::getClient(%object);
	%pos = GameBase::getPosition(%this);
	playSound( soundJumpPad, %pos );
	Client::SendMessage(%client,0,"~wboing.wav");
	springLaunch(%this, %object);
}

function springLaunch(%this, %object)
{
	%rot = GameBase::getRotation(%this);
	%rotx = getWord(%rot, 0);
	%roty = getWord(%rot, 1) - 1.570796;
	%rotz = getWord(%rot, 2);
	%rot = %rotx@" "@%roty@" "@%rotz;
	%vel = %this.launchSpeed;
	%vec = Vector::getFromRot(%rot, 0, %vel);
	Player::applyImpulse(%object, %vec);
}
//***********************************************************************
// SF ADDITION - End
//***********************************************************************

//------------------------------------------------------------------------
StaticShapeData MediumAntenna
{
	shapeFile = "anten_med";
	debrisId = flashDebrisSmall;
	maxDamage = 2.5;
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
	maxDamage = 3.5;
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
	maxDamage = 2.5;
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

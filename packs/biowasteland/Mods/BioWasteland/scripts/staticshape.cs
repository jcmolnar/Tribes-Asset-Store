//=====================================================================
//=======================BioWasteland Shapes File
//=======================Mod by Bïohazard
//=======================www.exploratoriums.com
//=======================biohazard@exploratoriums.com
//=====================================================================

//=======================Default power animation behavior for all static shapes

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
	StaticShape::objectiveDestroyed(%this);
}

function StaticShape::onCollision(%this,%obj)
{
	%data = GameBase::getDataName(%obj);
	if(%data.shapefile == "rocket")
	{
		if (%obj.missilegone != 1)
		{
			%obj.missilegone = 1;
		}
		else
		{
			return;
		}
		GameBase::setDamageLevel(%obj, 10);
		return;
	}
}

function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%shape = (GameBase::getDataName(%this)).shapeFile;
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;

   	if (%object != "0" && %object != -1)
   	{
   		if (gamebase::getownerclient(%object) != "-1")
   			%this.lastDamageObject = client::getownedobject(gamebase::getownerclient(%object));
		else
   			%this.lastDamageObject = %object;
   	}

   	%this.lastDamageTeam = GameBase::getTeam(%this.lastDamageObject);

	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%name = GameBase::getDataName(%this);
		if(%name.className == Generator || %name.className == Station)
		{
			%TDS = $Server::TeamDamageScale;
			%dValue = %damageLevel + %value * %TDS;
			%disable = GameBase::getDisabledDamage(%this);

			if((!$Server::TourneyMode && %dValue > %disable - 0.05) && !%this.base)
			{
				if(%damageLevel > %disable - 0.05)
					return;
				else
					%dValue = %disable - 0.05;
			}
		}
	}

	if (%this.base) //== makes deployed Base items indestructable except those listed
	{
		%name = GameBase::getDataName(%this);
		%TDS = $Server::TeamDamageScale;
		%dValue = %damageLevel + %value * %TDS;
		%disable = GameBase::getDisabledDamage(%this);

		if ((%type == $NukeDamageType) && (%shape == "inventory_sta" || %shape == "vehi_pur_poles" || %shape == "sensor_pulse_med" || %shape == "vehi_pur_pnl" || %shape == "generator_p" || %shape == "cmdpnl" || %shape == "solar_med" || %shape == "GunTuret"))
		{
			%value = %value / 8;
		}
		else if ((%type != $NukeDamageType) && (%shape == "inventory_sta" || %shape == "vehi_pur_poles" || %shape == "sensor_pulse_med" || %shape == "vehi_pur_pnl" || %shape == "generator_p" || %shape == "cmdpnl" || %shape == "solar_med" || %shape == "GunTuret"))
		{
			if(%damageLevel > %name.maxDamage - 0.05)
				return;
			else
				%dValue = %name.maxDamage - 0.05;
			GameBase::setDamageLevel(%this,%dValue);
			return;
		}
		else return;

		if (%type == $NukeDamageType)
		{
			if (%damageLevel >= %name.maxDamage)
			{
				deleteobject (%this);
				if (%this.part)
				{
					deleteobject(%this.part);
				}
				return;
			}
		}
	}
	GameBase::setDamageLevel(%this,%dValue);
	//=================================================
	//==========Biohazard's new Nuke Damage Calculator
	//=================================================
	if (%type == $NukeDamageType && (!checkHackable("Nuked", %shape) || getObjectType(%this) == "Mine" || getObjectType(%this) == "Flier" || %this.nukable ) ) schedule("Grenade::Plastic_Detonate( " @ %this @ " );", 1);
}

function StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);

	if (%this.shieldStrength)
	{
		if (%type == $BlasterDamageType)
			%value = %value * 1.5;
		%energy = GameBase::getEnergy(%this);
		%strength = %this.shieldStrength;
		if (%type == $ShrapnelDamageType)
			%strength *= 0.5;
		else
			if (%type == $MortarDamageType)
				%strength *= 0.25;
			else if (%type == $BlasterDamageType)
				%strength *= 2.0;

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

StaticShapeData FlagStand
{
	description = "Flag Stand";
	shapeFile = "flagstand";
	visibleToSensor = false;
};


function FlagStand::onDamage()
{
}

	//=================================================
	//==========Generators
	//=================================================

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
	DumpObjectTree(); echo ("Gen Up Adding to Tree...");
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

StaticShapeData TowerSwitch 	{ description = "Tower Control Switch"; className = "towerSwitch"; shapeFile = "tower"; showInventory = "false"; visibleToSensor = true; mapFilter = 4; mapIcon = "M_generator"; };
StaticShapeData Generator 	{ description = "Generator"; shapeFile = "generator"; className = "Generator"; sfxAmbient = SoundGeneratorPower; debrisId = flashDebrisLarge; explosionId = flashExpLarge; maxDamage = 2.0; visibleToSensor = true; mapFilter = 4; mapIcon = "M_generator"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; };
StaticShapeData SolarBig 	{ description = "SolarBig"; shapeFile = "solar"; className = "Generator"; sfxAmbient = SoundGeneratorPower; debrisId = flashDebrisLarge; explosionId = flashExpLarge; maxDamage = 5.0; visibleToSensor = true; mapFilter = 4; mapIcon = "M_generator"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; };
StaticShapeData SolarPanel 	{ description = "Solar Panel"; shapeFile = "solar_med"; className = "Generator"; debrisId = flashDebrisMedium; maxDamage = 1.0; visibleToSensor = true; mapFilter = 4; mapIcon = "M_generator"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpLarge; };

function SolarPanel::onSetTeam(%this,%oldTeam)//for pyramid's power hacked
{
	%tgt = %target.beam;
	if (GameBase::getDataName(%tgt) == "Pyramid")
	GameBase::setTeam(%tgt,GameBase::getTeam(%this));
}

StaticShapeData PortGenerator { description = "Portable Generator"; shapeFile = "generator_p"; className = "Generator"; debrisId = flashDebrisSmall; sfxAmbient = SoundGeneratorPower; maxDamage = 1.6; mapIcon = "M_generator"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; visibleToSensor = true; mapFilter = 4; };

StaticShapeData DepGenerator { description = "Portable Generator"; shapeFile = "generator_p"; className = "Generator"; debrisId = flashDebrisSmall; sfxAmbient = SoundGeneratorPower; maxDamage = 1.6; mapIcon = "M_generator"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; visibleToSensor = true; mapFilter = 4; };

function DepGenerator::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "PowerGeneratorPack"]--;
}

StaticShapeData ArrayAntenna 		{ shapeFile = "anten_lava"; debrisId = flashDebrisSmall; maxDamage = 8; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Array Antenna"; 	visibleToSensor = true; mapFilter = 4; mapIcon = "M_Radar"; };
StaticShapeData BluePanel 		{ shapeFile = "panel_blue"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData CargoBarrel 		{ shapeFile = "liqcyl"; debrisId = defaultDebrisSmall; maxDamage = 1.0; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Cargo Barrel";};

function CargoBarrel::onDestroyed(%this)
{
	if (%this.beam != "")
	{
		schedule("deleteObject("@%this.beam@");",0.5);
		%team = GameBase::getTeam(%this);
		%team.nukgen = "";
	}
	StaticShape::onDestroyed(%this);
	TeamMessages(1, %team, "Nuke Generator Lost.~wfloat_explode.wav");
}

StaticShapeData CargoCrate 		{ shapeFile = "magcargo"; debrisId = flashDebrisSmall; maxDamage = 1.0; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Cargo Crate"; };
StaticShapeData DisplayPanelOne 	{ shapeFile = "display_one"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData DisplayPanelThree 	{ shapeFile = "display_three"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData DisplayPanelTwo 	{ shapeFile = "display_two"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData ForceBeacon 		{ shapeFile = "force"; debrisId = defaultDebrisSmall; maxDamage = 10; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Force Beacon"; };

function forcebeacon::passengerJump(%this,%passenger,%mom)
{ 
	Vehicle::passengerJump(%this,%passenger,%mom);
	Player::unMountItem(%passenger,$WeaponSlot);
	schedule ("TuretGunFix(" @ %this @ ");",0.5);
}

StaticShapeData HOnePanel 		{ shapeFile = "dsply_h1"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 20; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData HTwoPanel 		{ shapeFile = "dsply_h2"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; visibleToSensor = true; mapFilter = 4; mapIcon = "M_Radar";};
StaticShapeData LargeAntenna 		{ shapeFile = "anten_lrg"; debrisId = defaultDebrisSmall; maxDamage = 8; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Large Antenna"; visibleToSensor = true; mapFilter = 4; mapIcon = "M_Radar"; };
StaticShapeData MediumAntenna 		{ shapeFile = "anten_med"; debrisId = flashDebrisSmall; maxDamage = 5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Medium Antenna"; visibleToSensor = true; mapFilter = 4; mapIcon = "M_Radar"; };
StaticShapeData RodAntenna 		{ shapeFile = "anten_rod"; debrisId = defaultDebrisSmall; maxDamage = 4; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Rod Antenna"; visibleToSensor = true; mapFilter = 4; mapIcon = "M_Radar"; };
StaticShapeData SetPanel 		{ shapeFile = "panel_set"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData SmallAntenna 		{ shapeFile = "anten_small"; debrisId = defaultDebrisSmall; maxDamage = 2.0; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Small Antenna"; visibleToSensor = true; mapFilter = 4; mapIcon = "M_Radar"; };
StaticShapeData SOnePanel 		{ shapeFile = "dsply_s1"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData SquarePanel 		{ shapeFile = "teleport_square"; debrisId = flashDebrisSmall; maxDamage = 0.3; damageSkinData = "objectDamageSkins"; explosionId = flashExpMedium; description = "Panel"; };
StaticShapeData STwoPanel 		{ shapeFile = "dsply_s2"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData VerticalPanel 		{ shapeFile = "teleport_vertical"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData VerticalPanelB 		{ shapeFile = "panel_vertical"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 10000; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData VOnePanel 		{ shapeFile = "dsply_v1"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData VTwoPanel 		{ shapeFile = "dsply_v2"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData YellowPanel 		{ shapeFile = "panel_yellow"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };

//------------------------------------------------------------------------ Force Field Walls
StaticShapeData ForceField 	{ shapeFile = "forcefield"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData ForceField1 	{ shapeFile = "ForceField_3x4"; debrisId = defaultDebrisSmall; maxDamage = 36.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData ForceField2 	{ shapeFile = "ForceField_4x17"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData ForceField3 	{ shapeFile = "ForceField_4x8"; debrisId = defaultDebrisSmall; maxDamage = 36.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData ForceField4 	{ shapeFile = "ForceField_5x5"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData ForceField5 	{ shapeFile = "ForceField_4x14"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData PlasmaWall 	{ shapeFile = "plasmawall"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "PlasmaWall"; };

StaticShapeData Enerpad 	{ shapeFile = "enerpad"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Telepad"; };
StaticShapeData Mainpad 	{ shapeFile = "mainpad"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "MainPad"; disableCollision = true;};
StaticShapeData TribesLogo 	{ shapeFile = "logo"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "logo"; };
StaticShapeData Bridge 		{ shapeFile = "bridge"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Bridge"; };
StaticShapeData GunTuret 	{ shapeFile = "GunTuret"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "gunturet"; };

function GunTuret::onCollision(%this,%obj)
{
	if (getObjectType(%obj) == "Player" && !Player::isDead(%obj))
	{
		%client = Player::getClient(%obj);
		%armor = Player::getArmor(%obj);
		if(GameBase::getTeam(%obj) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == "-1" || (%armor == "spyarmor" || %armor == "spyfemale") )
		{
			%pos = Gamebase::getPosition(%this);
			%rot = Gamebase::getRotation(%this);
			%object = newObject("Hellacious Cannon","StaticShape","forcebeacon",true);
			addToSet("MissionCleanup", %object);
			GameBase::setTeam(%object,GameBase::getTeam(%this));
			GameBase::setRotation(%object,%rot);
			GameBase::setPosition(%object,%pos);
			Gamebase::setMapName(%object,"Hellacious Cannon");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::unMountItem(%obj,$WeaponSlot);
			deleteObject(%this);
			Player::mountItem(%client, AlienGun, $WeaponSlot);
			Player::setMountObject(%obj, %object, 1);
			schedule ("TuretGunFix(" @ %object @ ");",10);
		}
		else systemMessage(%client,0,"Wrong Team: Access Denied!~wAccess_Denied.wav");
	}
}

function TuretGunFix(%this)
{
	if (GameBase::getDataName(%this) != "ForceBeacon") return;
	%Set = newObject("laptopset",SimSet);
	%pos = GameBase::getPosition(%this);
	%Mask = $SimPlayerObjectType;
	containerBoxFillSet(%Set, %Mask, %pos, 0.2, 0.2, 0.2,0);
	%num = Group::objectCount(%Set);
	if (%num > 0 )
	{
		schedule ("TuretGunFix(" @ %this @ ");",10);
	}
	else
	{
			%rot = Gamebase::getRotation(%this);
			%object = newObject("Hellacious Cannon","StaticShape",GunTuret,true);
			addToSet("MissionCleanup", %object);
			GameBase::setTeam(%object,GameBase::getTeam(%this));
			GameBase::setRotation(%object,%rot);
			GameBase::setPosition(%object,%pos);
			Gamebase::setMapName(%object,"Hellacious Cannon");
			playSound(SoundMortaReload,GameBase::getPosition(%object));
			deleteObject(%this);
			if (%pos == "0 0 0") deleteObject(%object);
	}
	deleteObject(%set);
}

StaticShapeData SatBig 		{ shapeFile = "sat_big"; debrisId = flashDebrisLarge; maxDamage = 10.0; damageSkinData = "objectDamageSkins"; isTranslucent = true; description = "SatBig"; explosionId = LargeShockwave;};

StaticShapeData ElectricalBeam 		{ shapeFile = "zap"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; };
StaticShapeData ElectricalBeamBig 	{ shapeFile = "zap_5"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; };
StaticShapeData PoweredElectricalBeam 	{ shapeFile = "zap"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; };

function PoweredElectricalBeam::onPower(%this, %power, %generator)
{
	if(%power)
		GameBase::startFadeIn(%this);
	else
		GameBase::startFadeOut(%this);
}

StaticShapeData Cactus
{
	shapeFile = "Bigtwig";
	debrisId = defaultDebrisSmall;
	maxDamage = 1;
	description = "Cactus";
};

StaticShapeData Cactus1
{
	shapeFile = "cactus1";
	debrisId = defaultDebrisSmall;
	maxDamage = 1;
	description = "Cactus";
};

StaticShapeData Cactus2
{
	shapeFile = "cactus2";
	debrisId = defaultDebrisSmall;
	maxDamage = 1;
	description = "Cactus";
};

StaticShapeData Cactus3
{
	shapeFile = "cactus3";
	debrisId = defaultDebrisSmall;
	maxDamage = 1;
	description = "Cactus";
};
function Cactus::onCollision(%this,%obj)
{
	if (getObjectType(%obj) == "Player" && !Player::isDead(%obj))
	{
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
		{
			GameBase::applyDamage(%obj,$FlashDamageType,0.7,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this.tc);
			GameBase::applyDamage(%obj,$PlasmaWallDam,0.25,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this);
			GameBase::playSound(%obj,SoundPackFail,0);
		}
	}
}
function Cactus::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "SeedPack"]--;
}
function Cactus1::onCollision(%this,%obj)
{
	if (getObjectType(%obj) == "Player" && !Player::isDead(%obj))
	{
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
		{
			GameBase::applyDamage(%obj,$PlasmaWallDam,0.25,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this);
			GameBase::playSound(%obj,SoundShellClick,0);
		}
	}
}
function Cactus1::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "SeedPack"]--;
}
function Cactus2::onCollision(%this,%obj)
{
	if (getObjectType(%obj) == "Player" && !Player::isDead(%obj))
	{
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
		{
			GameBase::applyDamage(%obj,$FlashDamageType,0.1,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this.tc);
			GameBase::playSound(%obj,SoundPackFail,0);
		}
	}
}
function Cactus2::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "SeedPack"]--;
}
function Cactus3::onCollision(%this,%obj)
{
	if (getObjectType(%obj) == "Player" && !Player::isDead(%obj))
	{
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
		{
			GameBase::applyDamage(%obj,$ElectricityDamage,0.25,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this);
			GameBase::applyDamage(%obj,$PlasmaWallDam,0.25,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this);
			GameBase::playSound(%obj,SoundShellClick,0);
		}
	}
}
function Cactus3::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "SeedPack"]--;
}

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
	debrisId = defaultDebrisSmall;
	maxDamage = 10.0;
	visibleToSensor = false;
	isTranslucent = true;
	description = "Tree";
};

StaticShapeData TreeShapeTwo
{
	shapeFile = "tree2";
	maxDamage = 10.0;
	isTranslucent = "True";
	description = "Carniverous Oak";
};

function TreeShapeTwo::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--;
}
function TreeShapeTwo::onCollision(%this,%obj)
{
	if (getObjectType(%obj) == "Player" && !Player::isDead(%obj))
	{
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
		{
			%pos=GameBase::getPosition(%this);
			%pos=Vector::add(%pos,"0 0 4");
			GameBase::setPosition(%obj,%pos);
			%shooterClient = %this.tc;
			GameBase::applyDamage(%obj,$CrushDamageType,0.25,GameBase::getPosition(%obj),"0 0 0","0 0 0",%shooterClient);
			%shooterClient.score = %shooterClient.score +1;
  			Bottomprint(%shooterClient, "<jc>Tree Success! Score +1 = " @ %shooterClient.score ,3);
			%rnd = floor(getRandom() * 100);
			if(%rnd > 65)
			{
				MessageAllExcept(Player::getClient(%obj), 0, Client::getName(Player::getClient(%obj)) @ " is tangling with a tree!");
			}
			Client::SendMessage(Player::getClient(%obj),1,"Munch~wbutton_soft.wav");
		}
	}
}

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
	shapeFile = "mrtwig";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
	description = "Punji Spikes";
};

StaticShapeData PlantTwo
{
	shapeFile = "plant2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
   	description = "Healing Plant";
};

function PlantTwo::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "PlantPack"]--;

}

function PlantTwo::onCollision(%this,%obj)
{
	if (getObjectType(%obj) == "Player" && !Player::isDead(%obj))
	{

	%c = Player::getClient(%obj);


	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	if(GameBase::getDamageLevel(%obj))
	{
		GameBase::repairDamage(%obj,0.3);
		GameBase::playSound(%this,ForceFieldOpen,0);
	}

	if (%obj.swim)//== needs oxygen
	{
		%c = Player::getClient(%obj);
		%swim = %obj.swim - 3;
		if (%swim < 1) %swim  = 1;
		%obj.swim = %swim;
		if (Client::getGender(%c) == "Female") systemMessage(%c,0,"~wfemale4.wcolor3.wav");
		else systemMessage(%c,0,"~wmale2.wcolor3.wav");
	}

	}
}

StaticShapeData DeployableForceField
{
	shapeFile = "forcefield_3x4";
	debrisId = defaultDebrisSmall;
	maxDamage = 5.50;
	visibleToSensor = true;
	isTranslucent = true;
   	description = "Small Force Field";
};

function DeployableForceField::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldPack"]--;

}

function DeployableForceField::Open(%this,%type)
{
	if(%this.isactive == "false")
	{
		%this.isactive=true;
		%pos=GameBase::getPosition(%this);
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);

		if (%type == "doorl")	%newpos = Vector::add(%pos, EmplacementPack::rotVector( "-3 0 0", GameBase::getRotation(%this) ) );
		else if (%type == "doorr")	%newpos = Vector::add(%pos, EmplacementPack::rotVector( "3 0 0", GameBase::getRotation(%this) ) );
		else
		{
			GameBase::startfadein(%this);
			%newpos = (%posX @ " " @ %posY @ " " @ (%posZ + 5000));
		}

		gamebase::setposition(%this, %newpos);
		schedule("GameBase::setPosition("@%this@",\""@%pos@"\");",2.75);
	}
	else
	{
		%this.isactive = "false";

		if (%type == "doorl" || %type == "doorr")
		{
			schedule("GameBase::playSound("@%this@",SoundDoorOpen,0);",0.3);
			schedule("GameBase::playSound("@%this@",SoundDoorClose,0);",2.7);
		}
		else
		{
			schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.35);
			schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",2.75);
			GameBase::startfadeout(%this);
		}
	}
}

StaticShapeData LargeForceField
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 8.00;
	visibleToSensor = true;
	isTranslucent = true;
    description = "Large Force Field";
};

function LargeForceField::onCollision(%this,%obj)
{
	%clientId = Player::getClient(%obj);
	%armor = Player::getArmor(%clientId);

	if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this) || ((%armor == "spyarmor" || %armor == "spyfemale")) ) DeployableForceField::Open(%this);
}

function LargeForceField::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldPack"]--;
}

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

	if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this)) DeployableForceField::Open(%this);
	else
	{
		schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %obj @ "));",0.1);
		GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this);
	}
}

function LargeShockForceField::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeShockForceFieldPack"]--;
}

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

	if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this)) DeployableForceField::Open(%this);
	else
	{
		schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %obj @ "));",0.1);
		GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this);
	}
}

function ShockFloor::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ShockFloorPack"]--;
}

StaticShapeData BlastWall
{
	shapeFile = "newdoor5";
	maxDamage = 12.0;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	description = "BlastWall";
	damageSkinData = "objectDamageSkins";
};

function BlastWall::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastWallPack"]--;
}

StaticShapeData BlastFloor
{
	shapeFile = "elevator_8x8";
	maxDamage = 12.0;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	description = "BlastWall";
	damageSkinData = "objectDamageSkins";
};

function BlastFloor::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastFloorPack"]--;
}
StaticShapeData BlastDoorL
{
	shapeFile = "newdoor3_l";
	debrisId = defaultDebrisLarge;
	maxDamage = 8.00;
	visibleToSensor = true;
	isTranslucent = true;
    description = "Blast Door";
};

function BlastDoorL::onCollision(%this,%obj)
{
	%clientId = Player::getClient(%obj);
	%armor = Player::getArmor(%clientId);

	if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this) ) DeployableForceField::Open(%this,"doorl");
}

function BlastDoorL::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "BlastDoorPack"]--;
}
StaticShapeData BlastDoorR
{
	shapeFile = "newdoor3_R";
	debrisId = defaultDebrisLarge;
	maxDamage = 8.00;
	visibleToSensor = true;
	isTranslucent = true;
    description = "Blast Door";
};

function BlastDoorR::onCollision(%this,%obj)
{
	%clientId = Player::getClient(%obj);
	%armor = Player::getArmor(%clientId);
	if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this) ) DeployableForceField::Open(%this,"doorr");
}

function BlastDoorR::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "BlastDoorPack"]--;
}

StaticShapeData DeployableTree2
{
	shapeFile = "tree2";
	debrisId = defaultDebrisSmall;
	maxDamage = 6.50;
	visibleToSensor = false;
	isTranslucent = true;
   	description = "Deployable Tree";
};

StaticShapeData Hologram1
{
	shapeFile = "larmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.75;
   	description = "Hologram";
	disableCollision = true;
};

function Hologram1::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "holopack"]--;
}

StaticShapeData Hologram2
{
	shapeFile = "marmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.10;
   	description = "Hologram";
	disableCollision = true;
};

function Hologram2::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "holopack"]--;
}

StaticShapeData Hologram3
{
	shapeFile = "harmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.5;
   	description = "Hologram";
	disableCollision = true;
};

function Hologram3::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "holopack"]--;
}

StaticShapeData DeployableTeleport
{
    	className = "DeployableTeleport";
	damageSkinData = "objectDamageSkins";

	shapeFile = "flagstand";
	maxDamage = 1.75;
	maxEnergy = 200;

   	mapFilter = 2;
	visibleToSensor = true;
    	explosionId = mortarExp;
    	debrisId = flashDebrisLarge;

	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
};

function DeployableTeleport::onDestroyed(%this)
{
	schedule("deleteObject("@%this.beam1@");",1);

	$TeamItemCount[GameBase::getTeam(%this) @ "TeleportPack"]--;

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
  if (getObjectType(%obj) == "Player" && !Player::isDead(%obj))
  {

	%c = Player::getClient(%obj);
	%armor = Player::getArmor(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	if(%teleTeam != %playerTeam && %armor != "spyarmor" && %armor != "spyfemale")
	{
		systemMessage(%c,0,"Wrong Team.");
		return;
	}

	if(%this.disabled == true)
	{
	        systemMessage(%c,0,"Teleport Pad is recharging.");
	        return;
	}

	%teleset = nameToID("MissionCleanup/Teleports");

	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		if ($Debug) echo ("Group Set Teleporter = " @ Group::getObject(%teleset, %i));
		if(GameBase::getTeam(%o) == %playerteam && %o != %this)
		{
			if(%armor == "harmor" || %armor == "jarmor")
			{
				%newpos = GameBase::GetPosition(%o);
				systemMessage(%c,0,"Transporting Heavies is a huge strain on the teleporter...~wturret_whir.wav");
				schedule("systemMessage(" @ %c @ ",0,\"Recharge prolonged.~wturretoff1.wav\");",2);
				schedule ("playSound(ForceFieldOpen,GameBase::getPosition(" @ %o @ "));",2);
				schedule ("playSound(ForceFieldOpen,GameBase::getPosition(" @ %this @ "));",2);
				schedule("GameBase::setPosition(" @ %obj @ ",\"" @ %newpos @ "\");",2,%obj);
				%o.Disabled = true;
				%this.Disabled = true;
				schedule("DeployableTeleport::Reenable("@%o@");",20);
				schedule("DeployableTeleport::Reenable("@%this@");",20);
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
		else if(%armor == "spyarmor" || %armor == "spyfemale")
		{
			if(GameBase::getTeam(%o) != %playerteam && %o != %this)
			{
				systemMessage(%c,1,"Transporting To Enemy Telepad!");
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
	systemMessage(%c,0,"No other pad to teleport to.");

  }
}

function DeployableTeleport::Reenable(%this)
{
	%this.disabled = false;
}

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

function AccelPadPack::Destruct(%this)
{
	AccelPadPack::doDamage(%this);
}

function AccelPadPack::doDamage(%this) {}

function AccelPadPack::onDestroyed(%this)
{
	AccelPadPack::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AccelPPack"]--;
}

function AccelPadPack::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player") {return;}
	if(Player::isDead(%obj)) {return;}
	%c = Player::getClient(%obj);
	%pteam = GameBase::getTeam(%obj);
	%oteam = GameBase::getTeam(%this);
	%diffZ=getWord(GameBase::getPosition(%obj),2)-getWord(GameBase::getPosition(%this),2);
	%tpos=GameBase::getPosition(%this);
	%opos=GameBase::getPosition(%obj);
	%tstartX=getWord(%tpos,0);
	%tstartY=getWord(%tpos,1);
	%tstartZ=getWord(%tpos,2);
	%ostartX=getWord(%opos,0);
	%ostartY=getWord(%opos,1);
	%ostartZ=getWord(%opos,2);
	%diffX=%ostartX-%tstartX;
	%diffY=%ostartY-%tstartY;
	%diffZ=%ostartZ-%tstartZ;
	if(%pteam==%oteam)
	{
		if(%obj.deployStandby!=1)
		{
			if(%diffZ>0.950)
			{
				%obj.deployStandby=1;
				%msg="<f1>Accelerator Pad : <f0>Face the direction you want to go, then jump or use your jets.  You may walk off the platform to avoid being deployed.";
				remoteEval(%c, "BP", %msg, 0);
				AccelPadPack::CheckPlayer(%this,%obj);
			}
		}
		else if(%diffZ<0.950)
		{
			remoteEval(%c, "CP", "", 0);
			%obj.deployStandby=0;
		}
	}
}

function AccelPadPack::CheckPlayer(%this,%obj)
{
	%tpos=GameBase::getPosition(%this);
	%opos=GameBase::getPosition(%obj);
	%tstartX=getWord(%tpos,0);
	%tstartY=getWord(%tpos,1);
	%tstartZ=getWord(%tpos,2);
	%ostartX=getWord(%opos,0);
	%ostartY=getWord(%opos,1);
	%ostartZ=getWord(%opos,2);

	%diffX=%ostartX-%tstartX;
	%diffY=%ostartY-%tstartY;
	%diffZ=%ostartZ-%tstartZ-0.92;
	%deploy=0;
	%recall=1;

	if(%diffZ>0.5) %deploy=1;
	if(%diffZ<0) %deploy=-1;

	%client = Player::getClient(%obj);
	%armor = Player::getArmor(%client);

	if(%deploy>0)
	{
		%armor=GameBase::getDataName(%obj);
		%mass=%armor.mass;
		%rot=GameBase::getRotation(%obj);
		%len=50;
		%zlen=50;
		%rnd=floor(getrandom()*30);

		if (%armor == "scoutarmor" || %armor == "scoutfemale" || %armor == "spyarmor" || %armor == "spyfemale" || %armor == "larmor" || %armor == "lfemale" || %armor == "stimarmor" || %armor == "stimfemale")
 		{
			playSound(debrisMediumExplosion,%tpos);
 		}
		if (%armor == "barmor" || %armor == "bfemale" || %armor == "aarmor" || %armor == "afemale" || %armor == "earmor" || %armor == "efemale" || %armor == "marmor" || %armor == "mfemale")
 		{
			playSound(debrisMediumExplosion,%tpos);
			%len-=10;
			%zlen-=15;
 		}
		if (%armor == "harmor" || %armor == "jarmor")
 		{
			playSound(debrisMediumExplosion,%tpos);
			%len-=35;
			%zlen-=35;
 		}

		playSound(debrisSmallExplosion,%tpos);

		//==accel in deirection of site
		%trans=GameBase::getMuzzleTransform(%obj);
		%normvec=GetWord(%trans, 3) @ " " @ GetWord(%trans, 4) @ " " @ GetWord(%trans, 5);
		%rot=Vector::add( Vector::getRotation( %normvec ), "1.571 0 0" );
		%vec=Vector::getFromRot(%rot, %len*%mass, 0);

		//%vec=Vector::getFromRot(%rot,%len*%mass,%zlen*%mass);
		Player::applyImpulse(%obj,%vec);
		schedule(%obj@".deployStandby=0;",0.1);
		%recall=0;
	}
	else if(%deploy<0)
	{
		%recall=0;
		%obj.deployStandby=0;
	}
	if(%recall)
	{
		schedule("AccelPadPack::CheckPlayer("@%this@","@%obj@");",0.05);
	}
	else
	{
		remoteEval(%client, "CP", "", 0);
	}
}

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
	systemMessage(%c, 0, "SPROING!");
	%velocity = 200;
	%zVec = 600;
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
	Player::applyImpulse(%obj,%jumpDir);
}

// FireBolt Fountain
StaticShapeData FireBolt	{ className = "FireBolt"; damageSkinData = "objectDamageSkins"; shapeFile = "plasmabolt"; maxDamage = 10000; maxEnergy = 200; mapFilter = 2; visibleToSensor = false; explosionId = debrisExpLarge; debrisId = flashDebrisLarge; lightRadius = 12.0; lightType = 1; lightColor = {1.0,0.0,0.2}; side = "single"; isTranslucent = false; };
function FireBolt::onAdd(%this) { schedule ("FireBolt::Pop(" @ %this @ ");",3); }
function FireBolt::Pop(%this)   { %pos = Gamebase::getposition(%this); %trans = "0 0 0 0 0 0.9 0 0 0 " @ %pos; %fired = Projectile::spawnProjectile(FireBoltProj, %trans ,%this,"0 0 0"); %random = floor(getRandom() * 3)+1; schedule ("FireBolt::Pop(" @ %this @ ");",%random,%this); }
RocketData FireBoltProj		{ bulletShapeName  = "plasmabolt.dts"; explosionTag = plasmaExp; collisionRadius  = 0.0; mass = 0.0; damageClass = 0; damageValue = 0.15; damageType = $PlasmaDamageType; explosionRadius = 1.0; kickBackStrength = 0; muzzleVelocity   = 5.0; terminalVelocity = 5.0; acceleration = 5.0; totalTime = 1.5; liveTime = 1.5; lightRange = 1.0; lightColor = { 1, 1, 0 }; inheritedVelocityScale = 0.0; trailType = 2; trailString = "plasmabolt.dts"; smokeDist   = 5.0; soundId = SoundJetHeavy; };
function FireBolt::OnDamage(%this) {}

// Electric Fountain
StaticShapeData elecbolt	{ className = "elecbolt"; damageSkinData = "objectDamageSkins"; shapeFile = "fusionbolt"; maxDamage = 10000; maxEnergy = 200; mapFilter = 2; visibleToSensor = false; explosionId = debrisExpLarge; debrisId = flashDebrisLarge; lightRadius = 12.0; lightType = 1; lightColor = {1.0,0.0,0.2}; side = "single"; isTranslucent = false; };
function elecbolt::onAdd(%this) { schedule ("elecbolt::Pop(" @ %this @ ");",3); }
function elecbolt::Pop(%this) 	{ %pos = Gamebase::getposition(%this); %trans = "0 0 0 0 0 0.9 0 0 0 " @ %pos; %fired1 = Projectile::spawnProjectile(elecboltProj, %trans ,%this,"0 0 0"); schedule ("elecbolt::Pop(" @ %this @ ");",5,%this); }
RocketData elecboltProj		{ bulletShapeName  = "fusionbolt.dts"; explosionTag = energyExp; collisionRadius  = 0.0; mass = 0.0; damageClass = 0; damageValue = 0.15; damageType = $ElectricityDamageType; explosionRadius = 1.0; kickBackStrength = 0; muzzleVelocity   = 2.5; terminalVelocity = 2.5; acceleration = 2.5; totalTime = 4; liveTime = 4; lightRange = 4.0; lightColor = { 0, 0, 2 }; inheritedVelocityScale = 0.0; trailType = 2; trailString = "fusionbolt.dts"; smokeDist   = 5.0; soundId = SoundJetHeavy; };
function elecbolt::OnDamage(%this) {}

// Volter Fountain
StaticShapeData VoltBolt 	{ className = "VoltBolt"; damageSkinData = "objectDamageSkins"; shapeFile = "plasmabolt"; maxDamage = 10000; maxEnergy = 200; mapFilter = 2; visibleToSensor = false; explosionId = debrisExpLarge; debrisId = flashDebrisLarge; lightRadius = 12.0; lightType = 1; lightColor = {1.0,0.0,0.2}; side = "single"; isTranslucent = false; };
function VoltBolt::onAdd(%this) { schedule ("VoltBolt::Pop(" @ %this @ ");",3); }
function VoltBolt::Pop(%this) 	{ %pos = Gamebase::getposition(%this); %up = getRandom(); %trans = "0 0 0 0 0 " @ %up @ " 0 0 0 " @ %pos; %fired = Projectile::spawnProjectile(VoltBoltProj, %trans ,%this,"0 0 0"); %random = floor(getRandom() * 3)+1; schedule ("VoltBolt::Pop(" @ %this @ ");",%random,%this); }
GrenadeData VoltBoltProj 	{ explosionTag = plasmaExp; collideWithOwner = True; ownerGraceMS = 50; collisionRadius = 10.0; mass = 5.0; elasticity = 0.1; damageClass = 1; damageValue = 0.30; damageType = $ElectricityDamageType; explosionRadius = 5.0; kickBackStrength = 0.1; maxLevelFlightDist = 75; totalTime = 4.0; liveTime = 0.02; projSpecialTime = 0.01; lightRange = 10.0; lightColor = { 1, 1, 0 };  inheritedVelocityScale = 1.5; smokeName = "plasmatrail.dts"; soundId = SoundJetLight; };
function VoltBolt::OnDamage(%this) {}

// Meteor
StaticShapeData Torch 		{ className = "MeteorGun"; damageSkinData = "objectDamageSkins"; shapeFile = "plasmabolt"; maxDamage = 10000; maxEnergy = 200; mapFilter = 2; visibleToSensor = false; explosionId = debrisExpLarge; debrisId = flashDebrisLarge; lightRadius = 12.0; lightType = 1; lightColor = {1.0,0.0,0.2}; side = "single"; isTranslucent = false; };

//Jail Pad
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
  if (getObjectType(%obj) == "Player" && !Player::isDead(%obj))
  {

    %c = Player::getClient(%obj);


    %playerTeam = GameBase::getTeam(%obj);
    %teleTeam = GameBase::getTeam(%this);


    if(%teleTeam == %playerTeam)
       {
      systemMessage(%c,0,"You Stepped On Your Teams Jail Capture Pad");
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
				MessageAllExcept(%c, 0, Client::getName(%c) @ " is arrested!");
                        Client::sendMessage(%c,0,"You are a Prisoner of War for 30 seconds");
				%c.jail = "True";
                    }
    }


    echo("ADMINMSG: ***" @ %gclient @ " stepped on a jail pad " );
  }
}

function jailpad::Reenable(%this)
{
        %this.disabled = false;
}



//Jail Cell

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
function JailSwitchOpen::onCollision(%this,%obj) {}

function jLargeForceField::jailSesame(%obj)
{
	%newplayerpos = Vector::add(GameBase::GetPosition(%obj),"0 0 8");
	GameBase::SetPosition(%obj,%newplayerpos);
	%client = Player::getClient(%obj);
	systemMessage(%client,0,"Run, Forrest! Run!~wmale1.wretreat.wav");
	%client.jail = "";
	%obj.jail = "";
}
StaticShapeData jailStand
{
        shapeFile = "flagstand";
        debrisId = defaultDebrisSmall;
        maxDamage = 200.0;
        description = "POW Pad";
};

function jailStand::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);

	schedule("Grenade::Plastic_Detonate("@%this.beam1@");",4);
	schedule("Grenade::Plastic_Detonate("@%this.beam2@");",4.5);
	schedule("Grenade::Plastic_Detonate("@%this.beam3@");",5);
	schedule("Grenade::Plastic_Detonate("@%this.beam4@");",5.5);
	schedule("Grenade::Plastic_Detonate("@%this.beam5@");",1);
	schedule("Grenade::Plastic_Detonate("@%this.beam6@");",3);
	schedule("deleteObject("@%this.beam@");",6.5);

	TeamMessages(1, GameBase::getTeam(%this), "Jail Lost.~wfloat_explode.wav");
	$TeamItemCount[GameBase::getTeam(%this) @ "jailpack"]--;
}

function jailStand::onCollision(%this,%obj)
{
	systemMessage(Player::getClient(%obj),0,"You must wait out your sentence of 30 seconds.~wmale1.wcolor7.wav");
}

StaticShapeData CagePower 	{ shapeFile = "generator_p"; debrisId = defaultDebrisSmall; maxDamage = 5.0; isTranslucent = true; description = "CagePower"; damageSkinData = "objectDamageSkins"; };

function CagePower::onDestroyed(%this)
{
	schedule("deleteObject("@%this.beam1@");",1);
	schedule("deleteObject("@%this.beam2@");",1);
	schedule("deleteObject("@%this.beam3@");",1);
	schedule("deleteObject("@%this.beam4@");",1);
	schedule("deleteObject("@%this.beam5@");",1);
	schedule("deleteObject("@%this.beam6@");",1);
}

function SmallAntenna::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	%team = GameBase::getTeam(%this);
	%team.anten = False;
	TeamMessages(1, GameBase::getTeam(%this), "Intercept Antenna Lost.~wfloat_explode.wav");
}

function HTwoPanel::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	%team = GameBase::getTeam(%this);
	if($TeamItemCount[GameBase::getTeam(%this) @ "ReconPack"] > 0)
	{
		TeamMessages(1, GameBase::getTeam(%this), "Team Chat Encryptor Lost.~wfloat_explode.wav");
		$TeamItemCount[GameBase::getTeam(%this) @ "ReconPack"]--;
		%team.scramb = False;
	}
}

function HOnePanel::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	%team = GameBase::getTeam(%this);
	if($TeamItemCount[%team @ "LockOutPack"] > 0)
	{
		TeamMessages(1, %team, "Switch Security Lock Lost.~wfloat_explode.wav");
		$TeamItemCount[%team @ "LockOutPack"]--;
		UnLockBase (%this, 5);
	}
}

function BluePanel::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	%team = GameBase::getTeam(%this);
	if($TeamItemCount[%team @ "SmartPack"] > 0)
	{
		TeamMessages(1, %team, "Base Vigil Security Lost.~wfloat_explode.wav");
		$TeamItemCount[%team @ "SmartPack"]--;
		%team.smrtpck = false;
	}
}

StaticShapeData ZepplinPad 	{ shapeFile = "enerpad"; debrisId = defaultDebrisSmall; maxDamage = 6.0; isTranslucent = true; description = "Zepplin Pad"; damageSkinData = "objectDamageSkins"; visibleToSensor = true; mapFilter = 4; mapIcon = "M_station"; };

function ZepplinPad::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ZepplinPack"]--;
}

function ZepplinPad::onCollision(%this,%obj)
{
	if (getObjectType(%obj) == "Player" && !Player::isDead(%player))
	{
		%client = Player::getClient(%obj);
		if (!%client.zepop) %client.zepop = %this.zepop;
		%armor = Player::getArmor(%obj);
		if(GameBase::getTeam(%obj) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1 || (%armor == "spyarmor" || %armor == "spyfemale") )
		{
			%clientpack = Player::getMountedItem(%client,$BackpackSlot);
			if (%clientpack != "BalloonPack")
			{
				%client.oldpack = Player::getMountedItem(%client,$BackpackSlot);
				if (%client.zepop != -70) systemMessage(%client,0,"You've been equipped with a Zepplin Pack.~wflyer_mount.wav");
				if (%client.zepop == -70)systemMessage(%client,0,"You've been equipped with a Parachute.~wflyer_mount.wav");
				Player::unMountItem(%client,1);
				Player::decItemCount(%client, %clientpack,1);
				Player::mountItem(%client,BalloonPack,1);
				Player::incItemCount(%client, BalloonPack,1);
			}
			else
			{
				if (%client.zepop != -70)systemMessage(%client,0,"You've already been equipped with a Zepplin Pack~wAccess_Denied.wav");
				if (%client.zepop == -70)systemMessage(%client,0,"You've already been equipped with a Parachute~wAccess_Denied.wav");
			}
		}
		else systemMessage(%client,0,"Wrong Team: Zepplin Pad Access Denied!~wAccess_Denied.wav");
	}
}

//====== Magneto Bridge

StaticShapeData MagBridge { shapeFile = "ForceField_4x14"; debrisId = defaultDebrisSmall; maxDamage = 5.0; isTranslucent = true; description = "Magneto bridge"; };

function MagBridge::onCollision(%this,%obj)
{
      %deploypos = Vector::add(Gamebase::getPosition(%obj), EmplacementPack::rotVector( "-2 5 0", GameBase::getRotation(%obj) ) );
      %rot = Vector::add(GameBase::getRotation(%obj), "1.57 0 1.57");
	gamebase::setposition(%this, %deploypos);
	gamebase::setrotation(%this, %rot);
	GameBase::playSound(%this,SoundElevatorStart,0);
	schedule("MagBridgeCk ('" @ %this @ "','" @ %obj @ "');", 10);
}
function MagBridge::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "MagBridgePack"]--;
}
function MagBridgeCk(%this, %obj)
{
	if (Vector::getDistance(Gamebase::getPosition(%this), Gamebase::getPosition(%obj)) >11) schedule("Grenade::Plastic_Detonate( " @ %this @ " );", 1);
}


//====base switch

StaticShapeData BaseSwitch 	{ description = "Base Control Switch"; className = "towerSwitch"; shapeFile = "tower"; showInventory = "false"; visibleToSensor = true; mapFilter = 4; mapIcon = "M_generator"; maxDamage = 10000; debrisId = defaultDebrisSmall; };

function BaseSwitch::onCollision(%this, %object)
{
	%oteam = GameBase::getTeam(%object);
	%tteam = GameBase::getTeam(%this);
	if (%tteam == "4")
	{
		systemMessage(Player::getClient(%object),0, "~wfemale1.wwait1.wav");
		return;
	}
	if (%oteam != %tteam)
	{
		%name = GameBase::getMapName(%this);
		%client= Client::getName(Player::getClient(%object));
		%tname = getTeamName(%oteam);
		%oname = getTeamName(%oteam);
		if (%this.lockout == True) TeamMessages(1, %oteam, "The " @ %tname @ " have locked this switch against capture!~wAccess_Denied.wav", -2, "null", %client @ " attempted to gain control of the " @ %name @ "!~wfemale1.wbasundr.wav");
		else
		{
			TeamMessages(1, %oteam, %client @ " captures the " @ %name @ " " @ %tteam @ " for your team!~wCapturedTower.wav", -2, "null", %client @ " captures the " @ %name @ " from your team!~wfemale1.wbasetkn.wav");
			TowerSwitch::onCollision(%this, %object);
			if (%oteam == %this.oteam) schedule("Grenade::Plastic_Detonate( " @ %this @ " );", 0.1);
		}
	}
}

function BaseSwitch::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	if (%this.oteam == 0) %team = 1; else %team = 0;
	$TeamItemCount[%team @ "SwitchPack"]--;
}

//=============================== BaseKill Marker
StaticShapeData BaseKill
{
	description = "Base Invasion Marker";
	shapeFile = "flag";
	maxDamage = 10.0;
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpSmall;
	damageSkinData = "objectDamageSkins";
};
function BaseKill::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	%team = GameBase::getTeam(%this);
	%team.spntrpos = "";
	%Set = newObject("KillSet",SimSet);
	%Mask = $StaticObjectType;
	containerBoxFillSet(%Set, %Mask, gamebase::getposition(%this), 30, 30, 20, 0);
	%num = Group::objectCount(%Set);
	for(%i = 0; %i < %num; %i++)
	{
		%object = group::getobject(%Set, %i);
		if(gamebase::getteam(%object) == gamebase::getteam(%this) && getObjectType(%object) == "Turret")
		{
			schedule("Grenade::Plastic_Detonate( " @ %object @ " );", 1);
		}
	}
	deleteobject(%Set);
	$TeamItemCount[GameBase::getTeam(%this) @ "BasePack"]--;
}
StaticShapeData HelpSwitch
{
        description = "Instructions";
        className = "towerSwitch";
        shapeFile = "tower";
        showInventory = "false";
        visibleToSensor = true;
        mapFilter = 4;
        mapIcon = "M_generator";
        maxDamage = 200.0;
};
function HelpSwitch::onCollision(%this,%obj)

{
	if (getObjectType(%obj) == "Player" && !Player::isDead(%obj))
	{
		%client = Player::getClient(%obj);
		if ($maphelp1 != "") Client::SendMessage(%client,0,"~wWeapon5.wav");
		if ($maphelp1 != "") bottomprint(%client,"<jc><f2>" @ $maphelp1);
		if ($maphelp2 != "") schedule("bottomprint(" @ %client @ ", \"<jc><f2>" @ $maphelp2 @ "\", 5);", 5);
		if ($maphelp3 != "") schedule("bottomprint(" @ %client @ ", \"<jc><f2>" @ $maphelp3 @ "\", 5);", 10);
		if ($maphelp4 != "") schedule("bottomprint(" @ %client @ ", \"<jc><f2>" @ $maphelp4 @ "\", 5);", 15);
		if ($maphelp5 != "") schedule("bottomprint(" @ %client @ ", \"<jc><f2>" @ $maphelp5 @ "\", 5);", 20);
	}
}

StaticShapeData SpwnMkr { shapeFile = "endarrow"; debrisId = defaultDebrisSmall; maxDamage = 1.0; isTranslucent = true; description = "New Spawn Point"; disableCollision = true;};
function SpwnMkr::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	%team = GameBase::getTeam(%this);
	$TeamItemCount[%team @ "SpawnPack"]--;
	%team.newspawn = "";
}


//====== Elevator Pad Turr

StaticShapeData ElevatorTurr { shapeFile = "teleport_square"; debrisId = defaultDebrisSmall; maxDamage = 10; isTranslucent = true; description = "Elevator Pad"; };

function ElevatorTurr::onCollision(%this,%obj)
{
  if (getObjectType(%obj) == "Player" && !Player::isDead(%obj))
  {
	if(GameBase::getTeam(%this) != GameBase::getTeam(%obj))
	{
		%armor = Player::getArmor(%obj);
		if(%armor == "spyarmor" || %armor == "spyfemale") {}
		else
		{
			systemMessage(Player::getClient(%obj),0,"ACCESS DENIED: Wrong Team ~waccess_denied.wav");
			return;
		}
	}
	schedule("DepEleCk('" @ %this @ "','" @ %obj @ "');", 10);
	if (Vector::getDistance(Gamebase::getPosition(%this), %this.origpos) >300) return;

	%tposa = Vector::add(Gamebase::getPosition(%this), "0 0 1");
	%tposb = Vector::add(Gamebase::getPosition(%this), "0 0 2");
	%tposc = Vector::add(Gamebase::getPosition(%this), "0 0 3");
      %oposa = Vector::add(Gamebase::getPosition(%obj), "0 0 1");
      %oposb = Vector::add(Gamebase::getPosition(%obj), "0 0 2");
      %oposc = Vector::add(Gamebase::getPosition(%obj), "0 0 3");
	gamebase::setposition(%this, %tposa);
	schedule("GameBase::setPosition("@%this@",\""@%tposb@"\");",0.3);
	schedule("GameBase::setPosition("@%this@",\""@%tposc@"\");",0.6);
	gamebase::setposition(%obj, %oposa);
	schedule("GameBase::setPosition("@%obj@",\""@%oposb@"\");",0.3);
	schedule("GameBase::setPosition("@%obj@",\""@%oposc@"\");",0.6);
	GameBase::playSound(%this,SoundElevatorStart,0);
  }
}

function DepEleCk(%this, %obj)
{
	if (Player::isDead(%obj)) gamebase::setposition(%this, %this.origpos); 
	if (Vector::getDistance(Gamebase::getPosition(%this), Gamebase::getPosition(%obj)) >5) gamebase::setposition(%this, %this.origpos);
}
function ElevatorTurr::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "Elevator"]--;
}

StaticShapeData Pyramid { shapeFile = "pyrm2"; debrisId = defaultDebrisSmall; maxDamage = 10; isTranslucent = true; description = "Pyramid"; damageSkinData = "objectDamageSkins";mapIcon = "M_turret";};

function Pyramid::onDestroyed(%this)
{
	Grenade::Plastic_Detonate(%this.beam1);
	Grenade::Plastic_Detonate(%this.beam2);
}

function collectbone(%this, %obj, %bone, %los)
{
	playSound(CollectBone5,GameBase::getPosition(%this));
	schedule ("playSound(CollectBone4,GameBase::getPosition(" @ %obj @ "));",0.3);
	schedule ("playSound(CollectBone3,GameBase::getPosition(" @ %bone @ "));",0.6);
	schedule ("playSound(CollectBone2,GameBase::getPosition(" @ %this @ "));",0.9);
	schedule ("playSound(CollectBone1,GameBase::getPosition(" @ %obj @ "));",1.2);
}

//======================================== Ancestor
StaticShapeData Ancestor
{
	shapeFile = "marmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000;
   	description = "Ancestor";
};

function Ancestor::onCollision(%this,%obj)
{
	if (getObjectType(%obj) == "Player" && !Player::isDead(%obj))
	{
		%client = Player::getClient(%obj);
		if(%client.curse) return;
		%name = Client::getName(%client);
		%tteam = GameBase::getTeam(%this);
		%oteam = GameBase::getTeam(%obj);
		%carrierbone = Player::getMountedItem(%obj, $FlagSlot);
		%carriedbone = %obj.carryBone;
		%carriedboneteam = GameBase::getTeam(%carriedbone);
		if (%tteam == 0) %eteam =1;
		else %eteam = 0;
		if (%carrierbone == "flag")
		{
			bottomprint(%client, "<jc>You must drop the flag you have before you can pick up a bone." ,3);
			return;
		}
		if (%carrierbone == "Bone" && %tteam != %oteam)
		{
			bottomprint(%client, "<jc>You must drop the bone you have before you can pick up another." ,3);
			return;
		}
		if (%carrierbone != "Bone" && %tteam != %oteam)
		{
			if ($OBones[%tteam] >0)
			{
        			MessageAllExcept(%client, 0, %name @ " has recovered one of the " @ getTeamName(%oteam) @ "'s Ancestral bones!~wflyer_mount.wav");
				Client::sendMessage(%client,0,"You've recovered one of your own Ancestor's bones!~wflyer_mount.wav");
				echo("ADMINMSG: **** " @ %name @ " recovered a bone");
				$OBones[%tteam]--;
				%inv = newObject("Bone","Item","Bone",true,%oteam);
				addToSet("MissionCleanup", %inv);
				GameBase::setTeam(%inv,%oteam);
				GameBase::setPosition(%inv,%this);
				Gamebase::setMapName(%inv,"Bone");
				%item = Item::getItemData(%inv);
				Player::mountItem(%obj, %item, $FlagSlot, %oteam);
				Player::setItemCount(%obj, %item, 1);
				$FlagCarry[%oteam] = %obj;
				Item::hide(%inv, true);
				%inv.atHome = false;
				%inv.carrier = %obj;
				%inv.pickupSequence++;
				%obj.carryBone = %inv;
				$teamScore[%tteam] -= 10;
			}
			else if ($TBones[%tteam] >0)
			{
        			MessageAllExcept(%client, 0, %name @ " has stolen one of the " @ getTeamName(%tteam) @ "'s Ancestral bones!~wflyer_mount.wav");
				Client::sendMessage(%client,0,"You've stolen one of the " @ getTeamName(%tteam) @ "'s bones!~wflyer_mount.wav");
				echo("ADMINMSG: **** " @ %name @ " steals a bone");
				$TBones[%tteam]--;
				%inv = newObject("Bone","Item","Bone",true,%tteam);
				addToSet("MissionCleanup", %inv);
				GameBase::setTeam(%inv,%tteam);
				GameBase::setPosition(%inv,%this);
				Gamebase::setMapName(%inv,"Bone");
				%item = Item::getItemData(%inv);
				Player::mountItem(%obj, %item, $FlagSlot, %tteam);
				Player::setItemCount(%obj, %item, 1);
				$FlagCarry[%oteam] = %obj;
				%inv.atHome = false;
				%inv.carrier = %obj;
				%inv.pickupSequence++;
				%obj.carryBone = %inv;
				Item::hide(%inv, true);
				%carrierbone = Player::getMountedItem(%obj, $FlagSlot);
				collectbone(%this, %obj, %carrierbone, 1);
				$teamScore[%tteam] -= 5;
			}
			else systemMessage(%client,0,"This Ancestor has no more bones to steal!");
		}
		if (%carrierbone != "Bone" && %tteam == %oteam)
		{
			if ($TBones[%oteam] <$Bone) bottomprint(%client, "<jc>Your Ancestor has " @ $TBones[%tteam] @ " of " @ $Bone @ " bones." ,3);
			else bottomprint(%client, "<jc>Your Ancestor has all of his bones, and " @ $OBones[%tteam] @ " of " @ getTeamName(%ebone) @ "'s bones." ,3);
			return;
		}
		if(%carrierbone == "Bone" && %tteam == %oteam)
		{
			if (%tteam == %carriedboneteam)
			{
				$TBones[%tteam]++;
        			MessageAllExcept(%client, 0, %name @ " returned one of " @ getTeamName(%carriedboneteam) @ "'s Ancestral bones to its proper resting place!~wflagreturn.wav");
        			Client::sendMessage(%client, 0, "You've returned one of your own Ancestor's bones to its proper resting place!~wflagreturn.wav");
				if ($TBones[%tteam] < $Bone) TeamMessages(0, %tteam, "Your Ancestor now has " @ $TBones[%tteam] @ " of his " @ $Bone @ " bones.", -2, "", "The " @ getTeamName(%tteam) @ " Ancestor now has " @ $TBones[%tteam] @ " of his " @ $Bone @ " bones.");
				else TeamMessages(0, %tteam, "Your Ancestor now has all of his bones and " @ $OBones[%tteam] @ " of " @ getTeamName(%ebone) @ "'s bones.", -2, "", "The " @ getTeamName(%tteam) @ " Ancestor now has all of his bones and " @ $OBones[%tteam] @ " of your Ancestor's bones.");
				$FlagCarry[%team] = "";
				%obj.carryBone = "";
				Player::unMountItem(%client,2);
				Player::setItemCount(%obj, Bone, 0);
				echo("ADMINMSG: **** " @ %name @ " returned a bone");
				%obj.carryBone = "";
				ObjectiveMission::checkScoreLimit();
				$teamScore[%tteam] += 5;
				%client.score = %client.score + $Score::FlagReturn;
				bottomprint(%client, "Score + " @ $Score::FlagReturn @ " = " @ %client.score ,3);
				%client.FlagCaps = %client.FlagCaps + 1;
				Game::refreshClientScore(%client);
				deleteObject(%obj.carryBone);
			}
			else
			{
				$OBones[%tteam]++;
				MessageAllExcept(%client, 0, %name @ " captured an Ancestral Bone from the " @ getTeamName(%carriedboneteam) @ " team!~wflagcapture.wav");
				Client::sendMessage(%client, 0, "You've captured an Ancestral Bone from the " @ getTeamName(%carriedboneteam) @ " team!~wflagcapture.wav");
				if ($TBones[%tteam] < $Bone) TeamMessages(0, %tteam, "Your Ancestor still has only " @ $TBones[%tteam] @ " of his " @ $Bone @ " bones.", -2, "", "The " @ getTeamName(%tteam) @ " now has " @ $OBones[%tteam] @ " of your Ancestor's bones.");
				else TeamMessages(0, %tteam, "Your Ancestor now has all of his bones and " @ $OBones[%tteam] @ " of " @ getTeamName(%ebone) @ "'s bones.", -2, "", "The " @ getTeamName(%tteam) @ " now has all of their bones and " @ $OBones[%tteam] @ " of your Ancestor's bones.");
				$FlagCarry[%team] = "";
				%obj.carryBone = "";
				Player::unMountItem(%client,2);
				Player::setItemCount(%obj, Bone, 0);
				echo("ADMINMSG: **** " @ %name @ " captured a bone");
				%obj.carryBone = "";
				$teamScore[%tteam] += 10;
				ObjectiveMission::checkScoreLimit();
				%client.score = %client.score + $Score::FlagReturn;
				bottomprint(%client, "Score + " @ $Score::FlagReturn @ " = " @ %client.score ,3);
				%client.FlagCaps = %client.FlagCaps + 1;
				Game::refreshClientScore(%client);
				deleteObject(%obj.carryBone);
			}
		}
	}
}

StaticShapeData GunTuretStn
{
	description = "Shield Station";
	shapeFile = "ammounit_remote";
	className = "DeployableStation";
	maxDamage = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	sequenceSound[1] = { "use", SoundUseAmmoStation };
	sequenceSound[2] = { "power", SoundAmmoStationPower };

	visibleToSensor = false;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 4;
	mapIcon = "M_station";
	debrisId = flashDebrisSmall;
	damageSkinData = "objectDamageSkins";
	explosionId = flashExpMedium;
};

function GunTuretStn::onAdd(%this)
{
	schedule("DeployableStation::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Turret Shield Stn");
	%this.base = "true";
}

function GunTuretStn::onActivate(%this)
{
	if(%this.deployed == 1)
	{
		GameBase::playSequence(%this,1,"use");
		schedule("GunTuretStn::shieldup(" @ %this @ ");",0.5,%this);
	}
	else 
		GameBase::setActive(%this,false);
}

function GunTuretStn::shieldup(%this)
{	
	if (GameBase::isActive(%this))
	{
		%player = Station::getTarget(%this);
	
		if (isPlayerBusy(%player) == 0) //== See if player is firing
		{
			if (%player != -1)
			{
				%client = Player::getClient(%player);
				if (%this.target != %client)
				{

					%this.target = %client;
					%shooterClient = %this.tc;
					if (%shooterClient) //==== is sabotaged
					{
						%rnd = floor(getRandom() * 100);
						if ( %rnd >85 )
						{
							Client::sendMessage(%client,1,"Do you think that station might have been sabotaged?~wBXplo1.wav");
							%chanpos = "0 0 100";
							%npos = Vector::add(gamebase::getposition(%player), %chanpos);
							GameBase::setPosition(%player,%npos);
							%forceDir = Vector::getFromRot(GameBase::getRotation(%player),0,1000); 
							Player::applyImpulse(%player,%forceDir);
						}
						else
						{
							%forceDir = Vector::getFromRot(GameBase::getRotation(%this),-2000,100);
							Player::applyImpulse(%player,%forceDir);
							Client::sendMessage(%client,1,"Do you think that station might have been sabotaged?~wBXplo2.wav");
						}
						MessageAllExcept(%client, 0, Client::getName(%client) @ " is a victim of " @ Client::getName(%shooterClient) @ "'s sabotage!");
						%shooterClient.score = %shooterClient.score +5;
  						Bottomprint(%shooterClient, "<jc>Sabotage Success! Score +5 = " @ %shooterClient.score ,3);
					}
					%set = newObject("set",SimSet);
					%pos = Vector::add(GameBase::getPosition(%this), EmplacementPack::rotVector( "0 3.2 1.5", GameBase::getRotation(%this)));
					%tnum = containerBoxFillSet(%set, $SimPlayerObjectType,%pos,2,2,2,0);
					if (%tnum>0)
					{
						for (%i=0;%i<%tnum;%i++)
						{
							%tgt=Group::getObject(%set,%i);
							deleteObject(%set);
							%shooterClient = Player::getClient(%tgt);
							systemMessage(%client,0,"Shielding " @ Client::getName(%shooterClient) @ ".~wbuysellsound.wav");
							systemMessage(%shooterClient, 0, Client::getName(%client) @ " is shielding you.~wbuysellsound.wav");
							%tgt.shieldStrength = 0.7;
							%tgt.shieldon = true;
							%player.tc = %tgt;
							schedule("CheckGnShld(" @ %this @ ", " @ %tgt @ ");",2,%player);
						}
					}
					else bottomprint(%client, "<jc><f2>No Gunner To Shield.", 2);
					deleteObject(%set);
				}
				schedule("GunTuretStn::shieldup(" @ %this @ ");",0.5,%this);
				return;
			}
			GameBase::setActive(%this,false);
		}
		else
		{
			GameBase::setActive(%this,false);
			%client = Player::getClient(%player);
			systemMessage(%client,0,"Shielding Stopped - Firing");
			%tgt = %player.tc;
			%tgt.shieldStrength = 0;
			%tgt.shieldon = false;
			return 0;
		}
	}
	if (%this.target)
	{
		%client = %this.target;
		%player = Client::getOwnedObject(%client);
		systemMessage(%client,0,"Shielding Off");
		%tgt = %player.tc;
		%tgt.shieldStrength = 0;
		%tgt.shieldon = false;
		Station::onEndSequence(%this);
	}
}

StaticShapeData GroundUnit { shapeFile = "cube2"; debrisId = defaultDebrisSmall; maxDamage = 5; isTranslucent = true; description = "Air Fuser Ground Unit"; damageSkinData = "objectDamageSkins"; visibleToSensor = true; mapFilter = 4; mapIcon = "M_station"; };

function GroundUnit::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "AirFuserPad"]--;
}

StaticShapeData JericoSwitch { shapeFile = "tower"; debrisId = defaultDebrisSmall; maxDamage = 10000; description = "Jerico Switch"; };

function JericoSwitch::onCollision (%switch, %object)
{
  if (getObjectType(%object) == "Player" && !Player::isDead(%object))
  {
	%client = Player::getClient(%object);
	%this = %switch.beam;
	%team = GameBase::getTeam(%this);
	playSound(SoundMortaReload,GameBase::getPosition(%switch));
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	%posA = Vector::add(%pos, EmplacementPack::rotVector( "0 -5.3 -0.25", %rot));
	%posB = Vector::add(%pos, EmplacementPack::rotVector( "0 -5.3 -0.5", %rot));
	%posC = Vector::add(%pos, EmplacementPack::rotVector( "0 -5.3 -0.75", %rot));
	%posD = Vector::add(%pos, EmplacementPack::rotVector( "0 -5.3 -1", %rot));
	%posE = Vector::add(%pos, EmplacementPack::rotVector( "0 -5.3 -1.25", %rot));
	%posF = Vector::add(%pos, EmplacementPack::rotVector( "0 -5.3 -1.5", %rot));
	%posG = Vector::add(%pos, EmplacementPack::rotVector( "0 -5.3 -1.75", %rot));
	%posH = Vector::add(%pos, EmplacementPack::rotVector( "0 -5.3 -2", %rot));
	schedule("GameBase::setPosition("@%this.beam2@",\""@%posH@"\");",0.2);
	schedule("GameBase::setPosition("@%this.beam2@",\""@%posG@"\");",0.4);
	schedule("GameBase::setPosition("@%this.beam2@",\""@%posF@"\");",0.6);
	schedule("GameBase::setPosition("@%this.beam2@",\""@%posE@"\");",0.8);
	schedule("GameBase::setPosition("@%this.beam2@",\""@%posD@"\");",1);
	schedule("GameBase::setPosition("@%this.beam2@",\""@%posC@"\");",1.2);
	schedule("GameBase::setPosition("@%this.beam2@",\""@%posB@"\");",1.4);
	schedule("GameBase::setPosition("@%this.beam2@",\""@%posA@"\");",1.6);

	%rotA = Vector::add(%rot, "-1.37 0 0");
	%rotB = Vector::add(%rot, "-1.17 0 0");
	%rotC = Vector::add(%rot, "-0.97 0 0");
	%rotD = Vector::add(%rot, "-0.77 0 0");
	%rotE = Vector::add(%rot, "-0.57 0 0");
	%rotF = Vector::add(%rot, "-0.37 0 0");
	%rotG = Vector::add(%rot, "-0.17 0 0");
	%rotH = Vector::add(%rot, "0 0 0");
	schedule("GameBase::setRotation("@%this.beam2@",\""@%rotH@"\");",0.1);
	schedule("GameBase::setRotation("@%this.beam2@",\""@%rotG@"\");",0.2);
	schedule("GameBase::setRotation("@%this.beam2@",\""@%rotF@"\");",0.3);
	schedule("GameBase::setRotation("@%this.beam2@",\""@%rotE@"\");",0.4);
	schedule("GameBase::setRotation("@%this.beam2@",\""@%rotD@"\");",0.1);
	schedule("GameBase::setRotation("@%this.beam2@",\""@%rotC@"\");",0.2);
	schedule("GameBase::setRotation("@%this.beam2@",\""@%rotB@"\");",0.3);
	schedule("GameBase::setRotation("@%this.beam2@",\""@%rotA@"\");",0.4);

	%posI = Vector::add(%pos, "0 0 0.25");
	%posJ = Vector::add(%pos, "0 0 0.5");
	%posK = Vector::add(%pos, "0 0 0.75");
	%posL = Vector::add(%pos, "0 0 1");
	%posM = Vector::add(%pos, "0 0 1.25");
	%posN = Vector::add(%pos, "0 0 1.5");
	%posO = Vector::add(%pos, "0 0 1.75");
	%posP = Vector::add(%pos, "0 0 2");
	schedule("GameBase::setPosition("@%this.beam4@",\""@%posP@"\");",0.2);
	schedule("GameBase::setPosition("@%this.beam4@",\""@%posO@"\");",0.4);
	schedule("GameBase::setPosition("@%this.beam4@",\""@%posN@"\");",0.6);
	schedule("GameBase::setPosition("@%this.beam4@",\""@%posM@"\");",0.8);
	schedule("GameBase::setPosition("@%this.beam4@",\""@%posL@"\");",1);
	schedule("GameBase::setPosition("@%this.beam4@",\""@%posK@"\");",1.2);
	schedule("GameBase::setPosition("@%this.beam4@",\""@%posJ@"\");",1.4);
	schedule("GameBase::setPosition("@%this.beam4@",\""@%posI@"\");",1.6);

	playSound(SoundElevatorStart,%pos);

	schedule("deleteobject("@%switch@");",0);
	schedule("deleteobject("@%this.beam1@");",1.8);
	schedule("deleteobject("@%this.beam2@");",1.8);
	schedule("deleteobject("@%this.beam3@");",1.8);
	schedule("deleteobject("@%this.beam4@");",1.8);
	schedule(%this@".refire=0;",2);

	%name = Client::getName(%client);
	if (Client::getGender(%client) == "Female") TeamMessages(3, %team, %name @ ": Jerico en route!~wfemale3.wmoveout.wav");
	else TeamMessages(3, %team, %name @ ": Jerico en route!~wmale3.wmoveout.wav");
	centerprint(%client,"<jc><f2>This Jerico HoverCraft is will be mobile momentarily.",2);
  }
}
//------------------------------------------------------------------------
// Generic static shapes
//------------------------------------------------------------------------
function StaticShape::onCollision(%this,%obj){
	%data = GameBase::getDataName(%obj);
	if(%data.shapefile == "rocket"){
		if (%obj.missilegone != 1){
			%obj.missilegone = 1;
		}else{
			return;
		}
		GameBase::setDamageLevel(%obj, 10);
		return;
	}
}
function StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object){
	%damageLevel = GameBase::getDamageLevel(%this);
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	if(%this.shieldStrength){
		%energy = GameBase::getEnergy(%this);
		%strength = %this.shieldStrength;
		if(%type == $ShrapnelDamageType){ %strength *= 0.5; }else if(%type == $MortarDamageType){ %strength *= 0.25; }else if(%type == $BlasterDamageType){ %strength *= 2.0; }
		%absorb = %energy * %strength;
		
		if(%value < %absorb){
			GameBase::setEnergy(%this,%energy - (%value / %strength));
			%centerPos = getBoxCenter(%this);
			%sphereVec = findPointOnSphere(getBoxCenter(%object), %centerPos, %vec, %this);
			%centerPosX = getWord(%centerPos, 0);
			%centerPosY = getWord(%centerPos, 1);
			%centerPosZ = getWord(%centerPos, 2);

			%pointX = getWord(%pos, 0);
			%pointY = getWord(%pos, 1);
			%pointZ = getWord(%pos, 2);

			%newVecX = %centerPosX - %pointX;
			%newVecY = %centerPosY - %pointY;
			%newVecZ = %centerPosZ - %pointZ;
			%norm = Vector::normalize(%newVecX @" "@ %newVecY @" "@ %newVecZ);
			%zOffset = 0;
			if(GameBase::getDataName(%this) == PulseSensor){ %zOffset = (%pointZ - %centerPosZ) * 0.5; }
			GameBase::activateShield(%this, %sphereVec, %zOffset);
		}else{ GameBase::setEnergy(%this, 0); StaticShape::onDamage(%this,%type,%value - %absorb,%pos,%vec,%mom,%object); }
	}
	else{ StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object); }
}
function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object){
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)){
		%name = GameBase::getDataName(%this);
		if(%name.className == Generator || %name.className == Station){ 
			%TDS = $Server::TeamDamageScale;
			%dValue = %damageLevel + %value * %TDS;
			%disable = GameBase::getDisabledDamage(%this);
			if(!$Server::TourneyMode && %dValue > %disable - 0.05){
				if(%damageLevel > %disable - 0.05)
				{ return; }
				else
				{ %dValue = %disable - 0.05; }
			}
		}
	}
	GameBase::setDamageLevel(%this, %dValue);
}
function calcRadiusDamage(%this,%type,%radiusRatio,%damageRatio,%forceRatio,%rMax,%rMin,%dMax,%dMin,%fMax,%fMin){
	%radius = GameBase::getRadius(%this);
	if(%radius){
		%radius *= %radiusRatio;
		%damageValue = %radius * %damageRatio;
		%force = %radius * %forceRatio;
		if(%radius > %rMax){ %radius = %rMax; }else if(%radius < %rMin){ %radius = %rMin; }
		if(%damageValue > %dMax){ %damageValue = %dMax; }else if(%damageValue < %dMin){ %damageValue = %dMin; }
		if(%force > %fMax){ %force = %fMax; }else if(%force < %fMin){ %force = %fMin; }
		GameBase::applyRadiusDamage(%type,getBoxCenter(%this), %radius, %damageValue,%force,%this);
	}
}
function StaticShape::onDestroyed(%this){ GameBase::stopSequence(%this,0); StaticShape::objectiveDestroyed(%this); calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100); }
function StaticShape::onPower(%this,%power,%generator){ if(%power){ GameBase::playSequence(%this,0,"power"); }else{ GameBase::stopSequence(%this,0); } }
function StaticShape::onEnabled(%this){ if(GameBase::isPowered(%this)){ GameBase::playSequence(%this,0,"power"); } }
function StaticShape::onDisabled(%this){ GameBase::stopSequence(%this, 0); }

function Generator::onDisabled(%this){ GameBase::stopSequence(%this,0); GameBase::generatePower(%this, false); }
function Generator::onEnabled(%this){ GameBase::setActive(%this,true); }
function Generator::onDestroyed(%this){ Generator::onDisabled(%this); StaticShape::objectiveDestroyed(%this); calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); }
function Generator::onActivate(%this){ GameBase::playSequence(%this,0,"power"); GameBase::generatePower(%this, true); }
function Generator::onDeactivate(%this){ GameBase::stopSequence(%this,0); GameBase::generatePower(%this, false); }
StaticShapeData Generator{ description = "Generator"; shapeFile = "generator"; className = "Generator"; sfxAmbient = SoundGeneratorPower; debrisId = flashDebrisLarge; explosionId = flashExpLarge; maxDamage = 2.0; visibleToSensor = true; mapFilter = 4; mapIcon = "M_generator"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; };
StaticShapeData SolarPanel{ description = "Solar Panel"; shapeFile = "solar_med"; className = "Generator"; debrisId = flashDebrisMedium; maxDamage = 1.0; visibleToSensor = true; mapFilter = 4; mapIcon = "M_generator"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpLarge; };
StaticShapeData PortGenerator{ description = "Portable Generator"; shapeFile = "generator_p"; className = "Generator"; debrisId = flashDebrisSmall; sfxAmbient = SoundGeneratorPower; maxDamage = 1.6; mapIcon = "M_generator"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; visibleToSensor = true; mapFilter = 4; };

StaticShapeData TowerSwitch{ description = "Tower Control Switch"; className = "towerSwitch"; shapeFile = "tower"; showInventory = "false"; visibleToSensor = true; mapFilter = 4; mapIcon = "M_generator"; };
StaticShapeData FlagStand{ description = "Flag Stand"; shapeFile = "flagstand"; visibleToSensor = false; };
function FlagStand::onDamage(){}

StaticShapeData SmallAntenna{ shapeFile = "anten_small"; debrisId = defaultDebrisSmall; maxDamage = 1.0; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Small Antenna"; };
StaticShapeData MediumAntenna{ shapeFile = "anten_med"; debrisId = flashDebrisSmall; maxDamage = 1.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Medium Antenna"; };
StaticShapeData LargeAntenna{ shapeFile = "anten_lrg"; debrisId = defaultDebrisSmall; maxDamage = 1.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Large Antenna"; };
StaticShapeData ArrayAntenna{ shapeFile = "anten_lava"; debrisId = flashDebrisSmall; maxDamage = 1.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Array Antenna"; };
StaticShapeData RodAntenna{ shapeFile = "anten_rod"; debrisId = defaultDebrisSmall; maxDamage = 1.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Rod Antenna"; };
StaticShapeData ForceBeacon{ shapeFile = "force"; debrisId = defaultDebrisSmall; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Force Beacon"; };
StaticShapeData CargoCrate{ shapeFile = "magcargo"; debrisId = flashDebrisSmall; maxDamage = 1.0; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Cargo Crate"; };
StaticShapeData CargoBarrel{ shapeFile = "liqcyl"; debrisId = defaultDebrisSmall; maxDamage = 1.0; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Cargo Barrel"; };
StaticShapeData SquarePanel{ shapeFile = "teleport_square"; debrisId = flashDebrisSmall; maxDamage = 0.3; damageSkinData = "objectDamageSkins"; explosionId = flashExpMedium; description = "Panel"; };
StaticShapeData VerticalPanel{ shapeFile = "teleport_vertical"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData BluePanel{ shapeFile = "panel_blue"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData YellowPanel{ shapeFile = "panel_yellow"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData SetPanel{ shapeFile = "panel_set"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData VerticalPanelB{ shapeFile = "panel_vertical"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData DisplayPanelOne{ shapeFile = "display_one"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData DisplayPanelTwo{ shapeFile = "display_two"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData DisplayPanelThree{ shapeFile = "display_three"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData HOnePanel{ shapeFile = "dsply_h1"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData HTwoPanel{ shapeFile = "dsply_h2"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData SOnePanel{ shapeFile = "dsply_s1"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData STwoPanel{ shapeFile = "dsply_s2"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData VOnePanel{ shapeFile = "dsply_v1"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData VTwoPanel{ shapeFile = "dsply_v2"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData ForceField{ shapeFile = "forcefield"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData ElectricalBeam{ shapeFile = "zap"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; };
StaticShapeData ElectricalBeamBig{ shapeFile = "zap_5"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; };
StaticShapeData PoweredElectricalBeam{ shapeFile = "zap"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; };
function PoweredElectricalBeam::onPower(%this, %power, %generator){ if(%power){ GameBase::startFadeIn(%this); }else{ GameBase::startFadeOut(%this); } }

StaticShapeData Cactus1{ shapeFile = "cactus1"; debrisId = defaultDebrisSmall; maxDamage = 0.4; description = "Cactus"; };
StaticShapeData Cactus2{ shapeFile = "cactus2"; debrisId = defaultDebrisSmall; maxDamage = 0.4; description = "Cactus"; };
StaticShapeData Cactus3{ shapeFile = "cactus3"; debrisId = defaultDebrisSmall; maxDamage = 0.4; description = "Cactus"; };
StaticShapeData SteamOnGrass{ shapeFile = "steamvent_grass"; maxDamage = 999.0; isTranslucent = "True"; description = "Steam Vent"; };
StaticShapeData SteamOnMud{ shapeFile = "steamvent_mud"; maxDamage = 999.0; isTranslucent = "True"; description = "Steam Vent"; };
StaticShapeData TreeShape{ shapeFile = "tree1"; maxDamage = 10.0; isTranslucent = "True"; description = "Tree"; };
StaticShapeData TreeShapeTwo{ shapeFile = "tree2"; maxDamage = 10.0; isTranslucent = "True"; description = "Tree"; };
StaticShapeData SteamOnGrass2{ shapeFile = "steamvent2_grass"; maxDamage = 999.0; isTranslucent = "True"; };
StaticShapeData SteamOnMud2{ shapeFile = "steamvent2_mud"; maxDamage = 999.0; isTranslucent = "True"; description = "Steam Vent"; };
StaticShapeData PlantOne{ shapeFile = "plant1"; debrisId = defaultDebrisSmall; maxDamage = 0.4; description = "Plant"; };
StaticShapeData PlantTwo{ shapeFile = "plant2"; debrisId = defaultDebrisSmall; maxDamage = 0.4; description = "Plant"; };
StaticShapeData LargeAirBasePlatform{ shapeFile = "elevator16x16_octo"; debrisId = defaultDebrisLarge; maxDamage = 1000.0; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpLarge; visibleToSensor = true; mapFilter = 4; description = "Air Base"; };
StaticShapeData LargeAirBaseRadar{ shapeFile = "radar"; debrisId = defaultDebrisLarge; maxDamage = 5.00; visibleToSensor = true; isTranslucent = true; description = "Air Base Radar"; };
function LargeRadar::onDestroyed(%this){ StaticShape::onDestroyed(%this); function ABPortGenerator::onDestroyed(%this){ $TeamItemCount[GameBase::getTeam(%this) @"airbase"]--; } }

StaticShapeData Canister{ description = "Flame Turret Fuel"; shapeFile = "liqcyl"; className = "Decoration"; debrisId = flashDebrisMedium; maxDamage = 0.55; visibleToSensor = true; mapFilter = 4; mapIcon = "M_generator"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; };
function Canister::onDestroyed(%this){ GameBase::stopSequence(%this,0); StaticShape::objectiveDestroyed(%this); calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100); GameBase::setDamageLevel(%this.turret, 0.6); }
function Canister::onPower(%this,%power,%generator){ if(%power){ GameBase::playSequence(%this,0,"power"); }else{ GameBase::stopSequence(%this,0); } }
function Canister::onEnabled(%this){ if(GameBase::isPowered(%this)){ GameBase::playSequence(%this,0,"power"); } }
function Canister::onDisabled(%this){ GameBase::stopSequence(%this, 0); }
StaticShapeData Hologram1{ shapeFile = "larmor"; debrisId = defaultDebrisSmall; maxDamage = 10.75; description = "Hologram"; visibleToSensor = true; };
function Hologram1::onDestroyed(%this){ StaticShape::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--; }
StaticShapeData Hologram2{ shapeFile = "marmor"; debrisId = defaultDebrisSmall; maxDamage = 10.10; description = "Hologram"; };
function Hologram2::onDestroyed(%this){ StaticShape::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--; }
StaticShapeData Hologram3{ shapeFile = "harmor"; debrisId = defaultDebrisSmall; maxDamage = 15.0; description = "Hologram"; };
function Hologram3::onDestroyed(%this){ StaticShape::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--; }

StaticShapeData ShockFloor{ shapeFile = "newdoor5"; debrisId = defaultDebrisLarge; maxDamage = 2000.0; visibleToSensor = true; isTranslucent = true; description = "Shock Floor"; };
function ShockFloor::onDestroyed(%this){ StaticShape::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "ShockFloorPack"]--; }
function ShockFloor::onCollision(%this,%obj){
	%clientId = Player::getClient(%obj); %player = %obj; %armor = Player::getArmor(%clientId); %data = GameBase::getDataName(%obj); if(%data.shapefile == "rocket") {	GameBase::setDamageLevel(%obj, 10); return; }
	if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj)){ return; }
	if(GameBase::getTeam(%clientId) == Gamebase::getTeam(%this)){ %playerTeam = GameBase::getTeam(%obj); %fieldTeam = GameBase::getTeam(%this); ShockFloor::Open(%this); return; }else{ Schedule("playSound(TargetingMissile,GameBase::getPosition("@ %obj @"));", 0.1); GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this); }
	return;
}
function ShockFloor::Open(%this){
	if(%this.isactive == "false"){
		GameBase::startfadeout(%this);
		%this.isactive=true;
		schedule("LargeForceField::Open("@ %this @");",3);
		%pos = GameBase::getPosition(%this);
		%newpos = (getWord(%pos, 0) @" "@ getWord(%pos, 1) @" "@ (getWord(%pos, 2) + 5000));
		schedule("GameBase::setPosition("@ %this @",\""@ %pos @"\");", 2.75);
		schedule("GameBase::playSound("@ %this @", ForceFieldOpen, 0);", 0.05);
		gamebase::setposition(%this, %newpos);
	}else{
		%this.isactive = "false";
		%pos = GameBase::getPosition(%this);
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);
		%newpos = (getWord(%pos,0) @" "@ getWord(%pos,1) @" "@ (getWord(%pos,2) - 5000));
		gamebase::setposition(%this, %newpos);
		GameBase::setPosition(%this, %pos);
		GameBase::startfadein(%this);
		Schedule("GameBase::playSound("@ %this @", ForceFieldClose, 0);", 0.05, %this);
	}
}

StaticShapeData Flag101{ shapeFile = "flag"; debrisId = defaultDebrisSmall; maxDamage = 15.0; description = "Decoy Flag"; };
function Flag101::onDestroyed(%this){ StaticShape::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "DecoyCarrier"]--; }

StaticShapeData DecoyWeapon{ shapeFile = "sniper"; debrisId = defaultDebrisSmall; maxDamage = 15.0; description = "Decoy Weapon"; };
function DecoyWeapon::onDestroyed(%this){ StaticShape::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "DecoyCarrier"]--; }

StaticShapeData FreezePad{ description = "Freeze Pad"; shapeFile = "flagstand"; visibleToSensor = false; };
function FreezePad::onCollision(%this, %object){ %obj = getObjectType(%object); %ths = getObjectType(%this); if(%obj != "Player"){ return; } %sclient = Player::getClient(%object); %dclient = Player::getClient(%this); %sname = Client::getName(%sclient); %dname = Client::getName(%dclient); if(GameBase::getTeam(%object) == GameBase::getTeam(%this)){ Client::sendMessage(%sclient,0,"You Stepped on your teams Freeze Pad!"); }else if(GameBase::getTeam(%object) != GameBase::getTeam(%this) && !%sclient.isFrozen){ %sclient.isFrozen = 1; %sclient.nosuicide = 1; Schedule(%sclient @".nosuicide = 0;", 10); Schedule(%sclient @".isFrozen = 0;", 10); Freeze(%sclient, "on"); Client::sendMessage(%sclient, 0, "You will unfreeze in 10 seconds"); CenterPrint(%sclient, "<jc><f0>You Stepped on a Freeze Pad, Bad Idea", 7); Schedule("Freeze("@ %sclient @", \"off\");", 10); } }
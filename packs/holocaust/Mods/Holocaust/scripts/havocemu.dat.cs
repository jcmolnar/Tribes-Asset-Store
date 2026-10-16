# HaVoC Map Emulation file
# 100% Emulation -- Collection complete

//============ HaVoC Map compatibility ===============//
SensorData BigAssSatDD {
   	description = "Satellite Dish";
   	shapeFile = "sat_big";
   	maxDamage = 6.0;
   	range = 300;
   	dopplerVelocity = 0;
   	castLOS = true;
   	supression = false;
	supressable = false;
	visibleToSensor = true;
	sequenceSound[0] = { "power", SoundSensorPower };
	mapFilter = 4;
	mapIcon = "M_Radar";
	debrisId = flashDebrisLarge;
   	shieldShapeName = "shield_medium";
	maxEnergy = 300;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = LargeShockwave;
};

function BigAssSatDD::onPower(%this,%power,%generator) {
	if (%power) {
		%this.shieldStrength = 0.05;
		GameBase::setRechargeRate(%this,20);
	} else {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
	}
	GameBase::setActive(%this,%power);
}

function BigAssSatDD::onEnabled(%this) {
	if (GameBase::isPowered(%this)) {
		%this.shieldStrength = 0.05;
		GameBase::setRechargeRate(%this, 20);
		GameBase::setActive(%this,true);
	}
}

function BigAssSatDD::onDisabled(%this) {
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Sensor::onDeactivate(%this);
}

function BigAssSatDD::onDestroyed(%this) {
	StaticShape::objectiveDestroyed(%this);
	Sensor::onDeactivate(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
	schedule("deleteobject(" @ %this @ ");", 10);
}

StaticShapeData Twiggy { shapeFile = "mrtwig"; maxDamage = 10000.0; description = "Twig"; }; 

StaticShapeData LittleCraft { shapeFile = "flyer"; maxDamage = 10000.0; description = "Scout"; }; 

StaticShapeData MediumCraft { shapeFile = "hover_apc_sml"; maxDamage = 10000.0; description = "LAPC"; }; 

StaticShapeData HoverCraft { shapeFile = "hover_apc"; maxDamage = 10000.0; description = "HAPC"; }; 

StaticShapeData SmokePuff { shapeFile = "smoke"; maxDamage = 10000.0; description = "Smoke"; disableCollision = true; isTranslucent = true;  }; 

StaticShapeData Fire { shapeFile = "plasmabolt"; maxDamage = 10000.0; description = "Fire"; disableCollision = true; isTranslucent = true; }; 

StaticShapeData PoweredFire { shapeFile = "plasmabolt"; maxDamage = 10000.0; description = "Fire"; disableCollision = false; isTranslucent = true; }; 

function PoweredFire::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

StaticShapeData BlueWall { shapeFile = "plasmawall"; maxDamage = 10000.0; description = "Wall"; disableCollision = true; isTranslucent = true; }; 

StaticShapeData BlueFWall { shapeFile = "plasmawall"; maxDamage = 10000.0; description = "Wall"; disableCollision = false; isTranslucent = true; }; 

StaticShapeData PoweredElectricalBeam { shapeFile = "zap"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; }; 

function PoweredElectricalBeam::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

StaticShapeData PoweredBElectricalBeam { shapeFile = "zap_5"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; }; 

function PoweredBElectricalBeam::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

StaticShapeData BigAssSat { shapeFile = "sat_big"; maxDamage = 10000.0; description = ""; }; 

StaticShapeData SatDish { shapeFile = "sat_big"; maxDamage = 10000.0; description = ""; };

StaticShapeData FakerTurret { shapeFile = "gunturet"; maxDamage = 10000.0; description = "Fake Turret"; };

ItemData SmallOrange {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 5;
	lightTime = 0.5;
	lightColor = { 1, 0.5, 0 };
};

ItemData PoweredBlue {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 10;
	lightTime = 0.75;
	lightColor = { 0, 0.5, 1 };
};
function PoweredBlue::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

ItemData PoweredSmallOrange {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 5;
	lightTime = 0.6;
	lightColor = { 1, 0.5, 0 };
};
function PoweredSmallOrange::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

ItemData PoweredMedOrange {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 10;
	lightTime = 0.7;
	lightColor = { 1, 0.5, 0 };
};
function PoweredMedOrange::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

ItemData PoweredMedRed {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 14;
	lightTime = 1.6;
	lightColor = { 1, 0, 0 };
};
function PoweredMedRed::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

ItemData PoweredSmallRed {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 11;
	lightTime = 1.5;
	lightColor = { 1, 0, 0 };
};
function PoweredSmallRed::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

ItemData MedRed {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 16;
	lightTime = 1.6;
	lightColor = { 1, 0.2, 0 };
};

ItemData SmallRed {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 11;
	lightTime = 1.6;
	lightColor = { 1, 0.2, 0 };
};

ItemData MedOrange {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 8.5;
	lightTime = 0.7;
	lightColor = { 1, 0.5, 0 };
};

//============ HaVoC Map compatibility ===============//


// Renegades Duel port: the map datablocks and the Miscellany menu handler of the archive's
// Mine.cs (HaVoC duel add-on). Its mine blocks are Renegades Classic's own Mine.cs here.

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

StaticShapeData Fire { shapeFile = "plasmabolt"; maxDamage = 10000.0; description = "Fire"; disableCollision = true; isTranslucent = true; }; 

StaticShapeData PoweredFire { shapeFile = "plasmabolt"; maxDamage = 10000.0; description = "Fire"; disableCollision = false; isTranslucent = true; }; 
function PoweredFire::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

StaticShapeData PoweredBElectricalBeam { shapeFile = "zap_5"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; }; 
function PoweredBElectricalBeam::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

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

MoveableData elevator4x4fast {
	shapeFile = "elevator_4x4";
	className = "Elevator";
	maxDamage = 10.0;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	speed = 200;
	sfxStart = SoundElevatorStart;
	sfxStop = SoundElevatorStop;
	sfxRun = SoundElevatorRun;
	sfxBlocked = SoundElevatorBlocked;
	triggerRadius = 0;
   	isPerspective = true;
};

function processMenummisc(%clientId, %option) { 
	%o = getWord(%option, 0); 
	%extra = getWord(%option, 1); 
	if(%o == "obsm") {
		if(%clientId.obsmode == "") %clientId.obsmode = "Free";
		Client::buildMenu(%clientId, "Current mode: " @ %clientId.obsmode, "mmisc", true); 
		Client::addMenuItem(%clientId, "1Free", "setmode Free"); 
		Client::addMenuItem(%clientId, "2Fixed", "setmode Fixed"); 
		Client::addMenuItem(%clientId, "31st Person", "setmode 1stPerson"); 
	} else if(%o == "setmode") {
		if(%clientId.obsmode == %extra)
			Client::sendMessage(%clientId, 0,"Your Observer Mode is already set to " @ %extra @ "."); 		
		else {
			%clientId.obsmode = %extra;
			if(%clientId.observerMode == "observerOrbit") setObsOrbit(%clientId, %clientId.observerTarget, 5, 5, 5);
			Client::sendMessage(%clientId, 0,"Your Observer Mode has been set to " @ %extra @ "."); 
		}		
	} else if(%o == "toggled") {
		if ($DuelModeOff[%clientId]) {
			client::sendmessage(%clientId,0,"You have turned on duels.");
			$DuelModeOff[%clientId] = false;
		} else {
			client::sendmessage(%clientId,0,"You have turned off duels.");
			$DuelModeOff[%clientId] = true;
		}
	} else if(%o == "toggledt") {
		$DuelAlive[%clientId] = false;
		if ($DuelTModeOff[%clientId]) {
			if($DuelStart) {
				centerprint(%clientId, "<jc><f1>You have enabled Duel Tournament Mode.\n\n<f2>A tournament is currently in progress, please wait and you will join in when it is complete.", 20);
				Client::sendMessage(%clientId,0,"You have enabled Duel Tournament Mode. A tournament is currently in progress, please wait and you will join in when it is complete.");
			} else {
				Client::sendMessage(%clientId,0,"You have enabled Duel Tournament Mode.");
				centerprint(%clientId, "<jc><f0>Welcome to Duel Tournament\nby [HvC]NaTeDoGG - http://havoc.sirris.com\n\n<f1>Choose your weapons from the TAB menu.\n\n<f2>PRESS FIRE WHEN READY!", 0); 
				$DuelAlive[%clientId] = true;
				%clientId.notready = true;
			}
			$DuelTModeOff[%clientId] = false;
		} else {
			if($DuelStart) {
				centerprint(%clientId, "<jc><f2>You have been removed from the current tournament!\n\n<f1>You have disabled Duel Tournament Mode. You will not be entered in any tournaments.", 20);
				messageall(1, Client::getName(%clientId) @ " has chosen to be removed from the tournament!~waccess_denied.wav");
			} else
				centerprint(%clientId, "<jc><f1>You have disabled Duel Tournament Mode. You will not be entered in any tournaments.", 20);
			client::sendmessage(%clientId,0,"You have disabled Duel Tournament Mode. You will not be entered in any tournaments.~waccess_denied.wav");
			$DuelTModeOff[%clientId] = true;
			CheckPartners();
		}
	}
}

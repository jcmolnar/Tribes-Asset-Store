//----------------------------------------------------------------------------
// MINE DYNAMIC DATA

MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function AntipersonelMine::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}

function AntipersonelMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//----------------------------------------------------------------------------

MineData Handgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

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

function Admin::changeMissionMenu(%clientId) { 
	Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true); 
	%index = 1; 
	for(%type = 1; %type < $MLIST::TypeCount; %type++) {
		if($MLIST::Type[%type] != "Training") { 
			if(%index == 8 && $MLIST::TypeCount > 8) { 
				Client::addMenuItem(%clientId, %index @ "View More Types...", "more 8"); 
				break; 
			}
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0"); 
			%index++; 
		} 
	}
} 

function processMenuCMType(%clientId, %options)
{

   if(getWord(%options, 0) == "more") { %first = getWord(%options, 1); processMenuCMoo(%clientId, %first); return; }

   %curItem = 0;
   %option = getWord(%options, 0);
   %first = getWord(%options, 1);
   Client::buildMenu(%clientId, "Pick Mission", "cmission", true);
   
   for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
   {
      if(%i > 6)
      {
         Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option);
         break;
      }
      Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option);
   }
}

function processMenuCMoo(%clientId, %first) {

	Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true); 
	%index = 1; 
	for(%type = %first; %type < $MLIST::TypeCount; %type++) {
		if($MLIST::Type[%type] != "Training") { 
			if(%index == 8 && $MLIST::TypeCount > %first + %index) { 
				Client::addMenuItem(%clientId, %index @ "View More Types...", "more " @ %first + %index); 
				break; 
			}
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0"); 
			%index++; 
		} 
	}
}

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

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
%data = gamebase::getdataname(%this);
if(%data.maxdamage > 20) return;
eval(%data @ "::onDamage(" @ %this @ "," @ %type @ "," @ %value @ "," @ %object @ ");");
}

function StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
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


StaticShapeData Cactus1
{
	shapeFile = "cactus1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
   description = "Cactus";
};
function Cactus1::onCollision(%this, %object) { if(getobjecttype(%object) == "Player") { if(gamebase::getdamagelevel(%object)+0.4 > 1) Player::setanimation(%object, $PlayerAnim::Crouching); Player::onDamage(%object, $Cactus, 0.4); } } 
//------------------------------------------------------------------------
StaticShapeData Cactus2
{
	shapeFile = "cactus2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
   description = "Cactus";
};
function Cactus2::onCollision(%this, %object) { if(getobjecttype(%object) == "Player") { if(gamebase::getdamagelevel(%object)+0.4 > 1) Player::setanimation(%object, $PlayerAnim::Crouching); Player::onDamage(%object, $Cactus, 0.4); } } 
//------------------------------------------------------------------------
StaticShapeData Cactus3
{
	shapeFile = "cactus3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
   description = "Cactus";
};
function Cactus3::onCollision(%this, %object) { if(getobjecttype(%object) == "Player") { if(gamebase::getdamagelevel(%object)+0.4 > 1) Player::setanimation(%object, $PlayerAnim::Crouching); Player::onDamage(%object, $Cactus, 0.4); } } 
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
StaticShapeData Panel_blue
{
	shapeFile = "dsply_h1";
	maxDamage = 999.0;
	isTranslucent = "True";
   description = "look at me";
};

//------------------------------------------------------------------------
StaticShapeData TreeShape
{
	shapeFile = "tree1";
	maxDamage = 5.5;
	isTranslucent = "True";
   description = "Tree";
};

function treeshape::onDamage(%this, %type, %value,%a,%b,%c,%obj)
{
if(getdamagetype(%type) == exp && %value > 1.8) gamebase::setdamagelevel(%this, treeshape.maxdamage);
else if(gamebase::getdamagelevel(%this) > 2) return;
if(getdamagetype(%type) == bullet) %value /= 2.5;
%dlevel = gamebase::getdamagelevel(%this);
gamebase::setdamagelevel(%this, %dlevel+%value);
if(gamebase::getdamagelevel(%this) >= 2) { WWII::TreeFallSequence(%this); %this.destroyer = %obj; }
}
//------------------------------------------------------------------------
StaticShapeData TreeShapeTwo
{
	shapeFile = "tree2";
	maxDamage = 5.5;
	isTranslucent = "True";
	//debrisId = defaultDebrisSmall;
   description = "Tree";
};
function treeshapeTwo::onDamage(%this, %type, %value,%a,%b,%c,%obj)
{
if(getdamagetype(%type) == exp && %value > 2.2) gamebase::setdamagelevel(%this, treeshapetwo.maxdamage);
else if(gamebase::getdamagelevel(%this) > 2) return;
if(getdamagetype(%type) == bullet) %value /= 2.5;
%dlevel = gamebase::getdamagelevel(%this);
gamebase::setdamagelevel(%this, %dlevel+%value);
if(gamebase::getdamagelevel(%this) >= 2) { WWII::TreeFallSequence(%this); %this.destroyer = %obj; }
}
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
StaticShapeData AlliedFlag
{
	shapeFile = "dsply_h1";
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpMedium;
	maxDamage = 999999.5;
	damageSkinData = "objectDamageSkins";
   description = "Allies Flag";
};

//------------------------------------------------------------------------
StaticShapeData AxisFlag
{
	shapeFile = "dsply_h2";
	debrisId = flashDebrisSmall;
	explosionId = flashExpMedium;
	maxDamage = 999999.5;
	damageSkinData = "objectDamageSkins";
   description = "Axis Flag";
};
//----------------------------------------------------------------------
StaticShapeData WWII_AmmoBox
{
	shapeFile = "ammo1";
	debrisId = defaultDebrisSmall;
	maxDamage = 99999.9;
   description = "Ammo Box";
};
//---------------------------------------------------------------------
TriggerData WWII_AmmoResupply
{
	className = "Trigger";
	rate = 1.0;
};

function WWII_AmmoResupply::onEnter(%this,%object)
{

}	

function WWII_AmmoResupply::onLeave(%this,%object)
{
	
}

function WWII_AmmoResupply::onContact(%this,%object)
{
%object.resupply++;
if(%object.resupply == 5) 
	{
	WWII::PlayerResupply(%object);	
	%object.resupply = 0;
	}
}

function WWII_AmmoResupply::onActivate(%this)
{

}

function WWII_AmmoResupply::onDeactivate(%this)
{
}

//--------------------------------------------------------
StaticShapeData WWII_AmmoBox
{
	shapeFile = "ammo1";//ammo1
	debrisId = defaultDebrisSmall;
	maxDamage = 1;
   description = "Ammo Box";
};

function WWII_AmmoBox::onDamage(%this, %type, %val)
{

if(getdamagetype(%type) != "exp") return;
%group = getgroup(%this);
if(%group != "MissionCleanup") return;
%dlevel = gamebase::getdamagelevel(%this);
gamebase::setdamagelevel(%this, %dlevel+%val);
}

StaticShapeData WWII_Glass1
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisSmall;
	maxDamage = 99999.9;
   description = "Glass";
};

StaticShapeData WWII_Glass2
{
	shapeFile = "forcefield_3x4";
	debrisId = defaultDebrisSmall;
	maxDamage = 99999.9;
   description = "Glass";
};

StaticShapeData WWII_Glass3
{
	shapeFile = "forcefield_4x17";
	debrisId = defaultDebrisSmall;
	maxDamage = 99999.9;
   description = "Glass";
};

StaticShapeData WWII_Glass4
{
	shapeFile = "forcefield_4x14";
	debrisId = defaultDebrisSmall;
	maxDamage = 99999.9;
   description = "Glass";
};

StaticShapeData WWII_Glass5
{
	shapeFile = "forcefield_4x8";
	debrisId = defaultDebrisSmall;
	maxDamage = 99999.9;
   description = "Glass";
};

StaticShapeData WWII_Glass6
{
	shapeFile = "forcefield_5x5";
	debrisId = defaultDebrisSmall;
	maxDamage = 99999.9;
   description = "Glass";
};

StaticShapeData WWII_SpecialGlass 
{
	shapeFile = "PLASMAWALL";
	debrisId = defaultDebrisSmall;
	maxDamage = 99999;
	visibleToSensor = false;
	isTranslucent = true;
	description = "New Glass";
};

FlierData AutoFlier
{
	explosionId = BombExp;
	debrisId = VehicleDebris;
	className = "Vehicle";
   shapeFile = "hover_apc";
  // shieldShapeName = "shield_large";
   mass = 0.01;
   drag = 0;
   density = 1.2;
   maxBank = 1;
   maxPitch = 1;
   maxSpeed = 60;
   minSpeed = 30;
	lift = 0.8;
	maxAlt = 15;
	maxVertical = 0.5;
	maxDamage = 9999999;
	damageLevel = {1.0, 1.0};
	destroyDamage = 0.7;
	maxEnergy = 100;
	accel = 4;

	groundDamageScale = 1;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	//fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;
	
	mountSound = SoundFlyerMount;
	//dismountSound = SoundFlyerDismount;
	idleSound = SoundSensorPower;
	moveSound = SoundSensorPower;
	minDamageSpeed = 1;
	visibleDriver = false;
	driverPose = 23;
	description = "Paradrop Plane";
};

FlierData AutoFlier2
{
	explosionId = BombExp;
	debrisId = VehicleDebris;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
  // shieldShapeName = "shield_large";
   mass = 0.01;
   drag = 0;
   density = 1.2;
   maxBank = 1;
   maxPitch = 1;
   maxSpeed = 85;
   minSpeed = 66.6667;
	lift = 0.8;
	maxAlt = 15;
	maxVertical = 0.5;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 0.7;
	maxEnergy = 100;
	accel = 4;

	groundDamageScale = 1;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	//fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;
	
	mountSound = SoundFlyerMount;
	//dismountSound = SoundFlyerDismount;
	idleSound = SoundSensorPower;
	moveSound = SoundSensorPower;
	minDamageSpeed = 1;
	visibleDriver = false;
	driverPose = 23;
	description = "Paradrop Plane";
};

function AutoFlier::onDamage(%this, %val)
{
%dlevel = gameBase::getDamageLevel(%this);
//gamebase::setdamagelevel(%this, %dlevel+%val);
if(%dlevel > 1.7) %this.controlcorrupt = 3;
else if(%dlevel > 1.4) %this.controlcorrupt = 2;
else if(%dlevel > 0.9) %this.controlcorrupt = 1;
}

function AutoFlier2::isDamage(%this, %type,%val)
{
%dlevel = gameBase::getDamageLevel(%this);
if(getdamagetype(%type) == "bullet") %val = %val/6;
%dlevel = %dlevel + %val;
gamebase::setdamagelevel(%this, %dlevel);
if(%dlevel > 0.9) %this.controlcorrupt = 3;
else if(%dlevel > 0.7) %this.controlcorrupt = 2;
else if(%dlevel > 0.5) %this.controlcorrupt = 1;

}

StaticShapeData WWII_Water
{
	shapeFile = "PLASMAWALL";
	debrisId = defaultDebrisSmall;
	maxDamage = 99999;
	visibleToSensor = false;
	disablecollision = true;
	isTranslucent = true;
	description = "New Glass";
};

TriggerData SwimTrigger
{
	className = "Trigger";
	rate = 1.0;
};
function SwimTrigger::onEnter(%this,%object)
{
if(getobjecttype(%object) == "Player") for(%x = 0; %x < 4; %x++) schedule("WWII::PlayerSwim(" @ %this @ "," @ %object @ ");", %x/4);
}	

function SwimTrigger::onLeave(%this,%object)
{
}

function SwimTrigger::onContact(%this,%object)
{
echo(getobjecttype(%object));
if(getobjecttype(%object) == "Player") for(%x = 0; %x < 12; %x++) schedule("WWII::PlayerSwim(" @ %this @ "," @ %object @ ");", %x/12);
}

function SwimTrigger::onActivate(%this)
{
}

function SwimTrigger::onDeactivate(%this)
{
}

function WWII::PlayerSwim(%this, %obj)
{
%playerZ = getword(gamebase::getposition(%obj),2);
%TriggerZ = getword(getboxcenter(%this),2);
if(%playerZ - %TriggerZ >= 0) return;
%pos = gamebase::getposition(%obj);
%newplayerpos = vector::add(%pos, "0 0 " @ %triggerZ-%playerZ);
gamebase::setposition(%obj, %newplayerpos);
%vel = item::getvelocity(%obj);
%vector = vector::getfromrot(gamebase::getrotation(%obj));
item::setvelocity(%obj, vector::multiply(vector::normalize(getword(%vector, 0) @ " " @ getword(%vector, 1) @ " 0"), "5 5 5"));


}


StaticShapeData cmdstat
{
	shapeFile = "cmdpnl";
	maxDamage = 999.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
   description = "lol";
};

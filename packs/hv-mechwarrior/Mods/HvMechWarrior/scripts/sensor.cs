//-------------------------------------------------------------------------- 

// Default sensor methods

function Sensor::onActivate(%this)
{
	if(GameBase::isPowered(%this)) {
		GameBase::playSequence(%this,0,"power");
	}
}

function Sensor::onDeactivate(%this)
{
	GameBase::pauseSequence(%this,0);
}

function Sensor::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,10);
	}
	else {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
	}
	GameBase::setActive(%this,%power);
}

function Sensor::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) {
		%this.shieldStrength = 0.03;				  
		GameBase::setRechargeRate(%this,10);
		GameBase::setActive(%this,true);
	}
}

function Sensor::onDisabled(%this)
{
if(GameBase::isPowered(%this))//++++added disable warning++++++++
	{
//	%violated = GameBase::getMapName(%this);
//	%playerTeam = GameBase::getTeam(%this);
//	TeamMessages(1, %playerTeam, "-WARNING- Network reports " @ %violated @ " has been disabled~waccess_denied.wav");
//	TeamMessages(1, 0, "-WARNING- Network reports " @ %violated @ " has been disabled~waccess_denied.wav");
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Sensor::onDeactivate(%this);
	}
else
	{ 
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Sensor::onDeactivate(%this);
	}
}

function Sensor::onDestroyed(%this)
{
%playerTeam = GameBase::getTeam(%this);//++++
%violated = GameBase::getMapName(%this);//++++
TeamMessages(1, %playerTeam, "-WARNING- Network reports " @ %violated @ " has been destroyed~waccess_denied.wav");//++++
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Sensor::onDeactivate(%this);
	%sensorName = GameBase::getDataName(%this);
	if(%sensorName == DeployableSensorJammer) 
   	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableSensorJammerPack"]--;
	else if(%sensorName == DeployableMotionSensor) 
   	$TeamItemCount[GameBase::getTeam(%this) @ "MotionSensorPack"]--;
	else if(%sensorName == DeployablePulseSensor) 
   	$TeamItemCount[GameBase::getTeam(%this) @ "PulseSensorPack"]--;
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 
		0.1, 250, 100);
}

function Sensor::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		if(%name != DeployableMotionSensor && %name != DeployablePulseSensor && %name != DeployableSensorJammer )				
	  		%TDS = $Server::TeamDamageScale;
	}
	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
}

//------------------------------------------------------------------------
SensorData PulseSensor
{
   description = "Large Radar Array";
   shapeFile = "radar";
//   explosionId = DebrisExp;
   maxDamage = 1.0;
   range = 400;
   dopplerVelocity = 0;
   castLOS = true;
   supression = false;
	visibleToSensor = true;
	sequenceSound[0] = { "power", SoundGeneratorPower };
	mapFilter = 4;
	mapIcon = "M_Radar";
	debrisId = flashDebrisLarge;
   shieldShapeName = "shield_medium";
	maxEnergy = 100;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = LargeShockwave;
};

//------------------------------------------------------------------------
SensorData MediumPulseSensor
{
   description = "Radar Array";
   shapeFile = "sensor_pulse_med";
//   explosionId = DebrisExp;
   maxDamage = 0.75;
   range = 250;
   dopplerVelocity = 0;
   castLOS = true;
   supression = false;
	visibleToSensor = true;
	sequenceSound[0] = { "power", SoundGeneratorPower };
	mapFilter = 4;
	mapIcon = "M_Radar";
	debrisId = flashDebrisLarge;
   shieldShapeName = "shield_medium";
	maxEnergy = 100;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};

//------------------------------------------------------------------------
SensorData DeployableMotionSensor
{
   description = "Beagle Active Probe";
	className = "DeployableSensor";
	shapeFile = "sensor_small";
	shadowDetailMask = 16;
	visibleToSensor = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
//   explosionId = DebrisExp;
	damageLevel = {0.8, 1.0};
	maxDamage = 0.4;
	debrisId = defaultDebrisSmall;
	range = 125; //50;
	dopplerVelocity = 1;
   castLOS = false;
   supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 4;
	mapIcon = "M_motionSensor";
	damageSkinData = "objectDamageSkins";
};

//---------------------------------------------------------------------------
SensorData DeployablePulseSensor
{
	description = "Portable Radar Dish";
	className = "DeployableSensor";
	shapeFile = "radar_small";
	shadowDetailMask = 4;
	visibleToSensor = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	damageLevel = {0.8, 1.0};
	maxDamage = 1.0;
//   explosionId = DebrisExp;
	debrisId = flashDebrisSmall;
	range = 200;
	castLOS = true;
	supression = false;
	mapFilter = 4;
	mapIcon = "M_Radar";
};
$vm[ArrowIV] = ShortCoolProj;//++++++++++++++++++++++

//----------------------------------------------------------------------------
SensorData DeployableSensorJammer
{
	description = "Portable ECM Pod";
	className = "DeployableSensor";
	shapeFile = "sensor_jammer";
	shadowDetailMask = 4;
	visibleToSensor = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	damageLevel = {0.8, 1.0};
	maxDamage = 0.5;
//	explosionId = DebrisExp;
	debrisId = defaultDebrisSmall;
	range = 80;
	castLOS = true;
	supression = true;
	mapFilter = 4;
	mapIcon = "M_sensorJammer";
};

function DeployableSensor::onAdd(%this)
{
	schedule("DeployableSensor::deploy(" @ %this @ ");",1,%this);
}

function DeployableSensor::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableSensor::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
}

function DeployableSensor::onDisabled(%this)//++++not working++++++++++++
{
if(GameBase::getDamageState(%this) == "Destroyed")//++++added disable warning++++++++
	{
	return;
	}
else
	{
	%violated = (GameBase::getDataName(%this)).description;
	%playerTeam = GameBase::getTeam(%this);
	TeamMessages(1, %playerTeam, "-WARNING- Network reports a " @ %violated @ " has been disabled~waccess_denied.wav");
	}
}
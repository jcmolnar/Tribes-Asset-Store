// This is a MiniMod Plugin.
// This is the Long Range Motion Sensor from the Redneck Slag Pack mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    LRMotionSensor.ArmorData.cs
//    LRMotionSensor.item.cs
//    LRMotionSensor.reinitData.cs
//    LRMotionSensor.sensor.cs
//    LRMotionSensor.station.cs
//
// to your MiniMod/plugins directory.

function Sensor::onDestroyed(%this)
{
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
	else if(%sensorName == DeployableLongRangeMotionSensor) 
   	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableLRMotionSensorPack"]--;
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 
		0.1, 250, 100);
}

SensorData DeployableLongRangeMotionSensor
{
   description = "Long Range Motion Sensor";
	className = "DeployableSensor";
	shapeFile = "sensor_pulse_med";
	shadowDetailMask = 16;
	visibleToSensor = true;
	sequenceSound[0] = { "deploy", SoundSensorPower };
//   explosionId = DebrisExp;
	damageLevel = {0.8, 1.0};
	maxDamage = 2.5;
	debrisId = defaultDebrisSmall;
	range = 150;
	dopplerVelocity = 1;
   castLOS = false;
   supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 4;
	mapIcon = "M_motionSensor";
	damageSkinData = "objectDamageSkins";
};

function DeployableLongRangeMotionSensor::onAdd(%this)
{
	GameBase::playSequence(%this,0,"power");
	GameBase::setActive(%this,true);
}


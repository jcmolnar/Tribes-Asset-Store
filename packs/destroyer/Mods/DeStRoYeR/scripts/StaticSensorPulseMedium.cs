//--------------------------------------

SensorData MediumPulseSensor
{
   description = "Medium Pulse Sensor";
   shapeFile = "sensor_pulse_med";
//   explosionId = DebrisExp;
   maxDamage = 1.0;
   range = 250;
   dopplerVelocity = 0;
   castLOS = true;
   supression = false;
	visibleToSensor = true;
	sequenceSound[0] = { "power", SoundSensorPower };
	mapFilter = 4;
	mapIcon = "M_Radar";
	debrisId = flashDebrisLarge;
   shieldShapeName = "shield_medium";
	maxEnergy = 100;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};

//--------------------------------------
//--------------------------------------

SensorData PulseSensor
{
   description = "Large Pulse Sensor";
   shapeFile = "radar";
//   explosionId = DebrisExp;
   maxDamage = 1.5;
   range = 400;
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
	explosionId = LargeShockwave;
};

//--------------------------------------
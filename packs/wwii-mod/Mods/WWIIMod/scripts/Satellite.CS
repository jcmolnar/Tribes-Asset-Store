//-------------------------------------------------------------------------- 
//-------------------------------------------------------------------------- 

//-------------------------------------------------------------------------- 
// Default sensor methods

function Sensor::onActivate(%this)
{
	
GameBase::playSequence(%this,0,"power");
	
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
	
					  
GameBase::setRechargeRate(%this,10);
GameBase::setActive(%this,true);
	
}

function Sensor::onDisabled(%this)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Sensor::onDeactivate(%this);
}

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

SensorData AxisRadar
{
   description = "Axis Radar";
   shapeFile = "radar";
//   explosionId = DebrisExp;
   maxDamage = 99999.5;
   range = 240;
   dopplerVelocity = 0;
   castLOS = true;
   supression = false;
	visibleToSensor = true;
	sequenceSound[0] = { "power", SoundSensorPower };
	mapFilter = 4;
	mapIcon = "M_Radar";
	debrisId = flashDebrisLarge;
   //shieldShapeName = "shield_medium";
	//maxEnergy = 100;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = LargeShockwave;
};


//------------------------------------------------------------------------

SensorData AlliedRadar
{
   description = "Allied Radar";
   shapeFile = "sensor_pulse_med";
//   explosionId = DebrisExp;
   maxDamage = 99999.0;
   range = 240;
   dopplerVelocity = 0;
   castLOS = true;
   supression = false;
	visibleToSensor = true;
	sequenceSound[0] = { "power", SoundSensorPower };
	mapFilter = 4;
	mapIcon = "M_Radar";
	debrisId = flashDebrisLarge;
   //shieldShapeName = "shield_medium";
	//maxEnergy = 100;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};


//------------------------------------------------------------------------

SensorData SatRadar
{
   description = "Satellite Radar Dish";
   shapeFile = "sat_big";
//   explosionId = DebrisExp;
   maxDamage = 99999.0;
   range = 650;
   dopplerVelocity = 0;
   castLOS = true;
   supression = false;
	visibleToSensor = true;
	sequenceSound[0] = { "power", SoundGeneratorPower };
	mapFilter = 4;
	mapIcon = "M_Radar";
	debrisId = flashDebrisLarge;
   //shieldShapeName = "shield_medium";
	//maxEnergy = 100;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};


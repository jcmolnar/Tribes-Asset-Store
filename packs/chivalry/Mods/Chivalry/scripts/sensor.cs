//-------------------------------------------------------------------------- 
//-------------------------------------------------------------------------- 

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
	else if(%sensorName == DeployableBug)
	$TeamItemCount[GameBase::getTeam(%this) @ "BugPack"]--;
	else if(%sensorName == DeployableSatCom) 
   	$TeamItemCount[GameBase::getTeam(%this) @ "SatComPack"]--;
	else if(%sensorName == DeployableComJam) 
   	$TeamItemCount[GameBase::getTeam(%this) @ "ComJamPack"]--;
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


//------------------------------------------------------------------------

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


//------------------------------------------------------------------------

SensorData DeployableMotionSensor
{
   description = "Motion Sensor";
	className = "DeployableSensor";
	shapeFile = "sensor_small";
	shadowDetailMask = 16;
	visibleToSensor = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
//   explosionId = DebrisExp;
	damageLevel = {0.8, 1.0};
	maxDamage = 0.4;
	debrisId = defaultDebrisSmall;
	range = 50;
	dopplerVelocity = 1;
   castLOS = false;
   supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 4;
	mapIcon = "M_motionSensor";
	damageSkinData = "objectDamageSkins";
};

SensorData DeployableBug
{
   description = "Coyote-Ear Bug";
	className = "DeployableSensor";
	shapeFile = "sensor_small";
	shadowDetailMask = 16;
	visibleToSensor = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	//explosionId = DebrisExp;
	damageLevel = {0.8, 1.0};
	maxDamage = 0.4;
	debrisId = defaultDebrisSmall;
	range = 0;
	dopplerVelocity = 1;
   castLOS = false;
   supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 4;
	mapIcon = "M_motionSensor";
	damageSkinData = "objectDamageSkins";
};

SensorData DeployableComJam
{
   description = "Commo Jammer";
	className = "DeployableSensor";
	shapeFile = "sensor_jammer";
	shadowDetailMask = 16;
	visibleToSensor = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
//   explosionId = DebrisExp;
	damageLevel = {0.8, 1.0};
	maxDamage = 0.4;
	debrisId = defaultDebrisSmall;
	range = 0;
	dopplerVelocity = 1;
   castLOS = false;
   supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 4;
	mapIcon = "M_motionSensor";
	damageSkinData = "objectDamageSkins";
};

SensorData DeployablePulseSensor
{
	description = "Remote Pulse Sensor";
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

SensorData DeployableSatCom
{
	description = "SatCom Station";
	className = "DeployableSensor";
	shapeFile = "radar_small";
	shadowDetailMask = 4;
	visibleToSensor = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	damageLevel = {0.8, 1.0};
	maxDamage = 1.0;
//   explosionId = DebrisExp;
	debrisId = flashDebrisSmall;
	range = 10;
	castLOS = false;
	supression = false;
	mapFilter = 4;
	mapIcon = "M_Radar";
};

function DeployableSatCom::onAdd(%this)
{
	schedule("DeployableSatCom::deploy(" @ %this @ ");",1,%this);
}

function DeployableSatCom::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
	%this.UnDeployed = false;
}

function DeployableSatCom::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	schedule(%this@".isActive = true;",2);
	GameBase::playSequence(%this,0,"power");
}

function DeployableSatCom::UnDeploy(%object,%client)
{
	if(%object)
	{
	//messageall(0,"DeployableSatCom Undeploy called! %player ="@%client@" %object="@%object);
	%clientId = Player::getClient(%client);
	%plteam = Client::getTeam(%clientId);
	%obteam = GameBase::getTeam(%object);
	%armor = Player::getArmor(%clientId);
	if(%armor == "cftarmor" || %armor == "cftfemale")
	{
		//messageall(0,"inArmor");
		if(%plteam == %obteam)
		{
			//messageall(0,"InTeam");
			if(%object.isActive)
			{
			if(GameBase::getDamageLevel(%object) == 0)
			{
				if(!%object.UnDeployed)
				{
			//messageall(0,"InBody");
			GameBase::startfadeout(%object);
			%pos = getBoxCenter(%object);
			schedule("deleteobject("@%object@");",2.5);
			%new = newobject("","Item",SatComPack,0,false,false);
			addToSet("MissionCleanup", %new);
			Gamebase::setPosition(%new,%pos);
			GameBase::startfadein(%new);
			playSound(SoundChainTurretOff, %pos);
			$TeamItemCount[GameBase::getTeam(%client) @ "SatComPack"]--;
			%object.UnDeployed = true;
				}
				else
				Client::sendMessage(%clientId,0,"Already Undeploying.");
			}
			else
			Client::SendMessage(%clientId,0,"Cannot UnDeploy damaged SatCom.");
			}
			else
			Client::sendMessage(%clientId,0,"SatCom has not finished deploying.");
		}
		else
		Client::sendMessage(%clientId,0,"SatCom is not owned by your team.");
	}
	else
	Client::SendMessage(%clientId,0,"Must be in Crafter armor to UnDeploy SatCom.");
}
}


SensorData DeployableSensorJammer
{
	description = "Remote Sensor Jammer";
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

//------------------------------------------------------------------------



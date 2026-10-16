//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Motion Sensor
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------
ItemImageData MotionSensorPackImage
{
   shapeFile = "sensor_small";
   mountPoint = 2;
   mountOffset = { 0, 0, 0.1 };
   mountRotation = { 1.57, 0, 0 };
   firstPerson = false;
};

ItemData MotionSensorPack
{
   description = "Motion Sensor";
   shapeFile = "sensor_small";
   className = "Backpack";
   heading = "gSensors";
   imageType = MotionSensorPackImage;
   shadowDetailMask = 4;
   mass = 2.0;
   elasticity = 0.2;
   price = 125;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};


function MotionSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ %item] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}


function MotionSensorPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Motion Sensor#" @ $totalNumMotionSensors[%client]++;
	%shape = DeployableMotionSensor;
	%type = "Sensor";
	if (DeployableSensor::deployShape(%player,%name,%shape,%item,%type)) {
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
		}
	}
}

//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Pulse Sensor
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

ItemImageData PulseSensorPackImage
{
   shapeFile = "radar_small";
   mountPoint = 2;
   mountOffset = { 0, 0, 0.1 };
   mountRotation = { 1.57, 0, 0 };
   firstPerson = false;
};

ItemData PulseSensorPack
{
   description = "Pulse Sensor";
   shapeFile = "radar_small";
   className = "Backpack";
   heading = "gSensors";
   imageType = PulseSensorPackImage;
   shadowDetailMask = 4;
   mass = 2.0;
   elasticity = 0.2;
   price = 125;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};


function PulseSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ %item] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PulseSensorPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Pulse Sensor#" @ $totalNumPulseSensors[%client]++;
	%shape = DeployablePulseSensor;
	%type = "Sensor";
	if (DeployableSensor::deployShape(%player,%name,%shape,%item,%type)) {
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
		}
	}
}



//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Sensor Jammer
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------

ItemImageData DeployableSensorJamPackImage
{
   shapeFile = "sensor_jammer";
   mountPoint = 2;
   mountOffset = { 0, 0.03, 0.1 };
   mountRotation = { 1.57, 0, 0 };
   firstPerson = false;
};

ItemData DeployableSensorJammerPack
{
   description = "Sensor Jammer";
   shapeFile = "sensor_jammer";
   className = "Backpack";
   heading = "gSensors";
   imageType = DeployableSensorJamPackImage;
   shadowDetailMask = 4;
   mass = 2.0;
   elasticity = 0.2;
   price = 225;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function DeployableSensorJammerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ %item] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Sensor Jammer#" @ $totalNumSensorJammers[%client]++;
	%shape = DeployableSensorJammer;
	%type = "Sensor";
	if (DeployableSensor::deployShape(%player,%name,%shape,%item,%type)) {
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
		}
	}
}


//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//                              Base Alarm
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------


ItemImageData BaseAlarmImage
{
   shapeFile = "sensor_small";
   mountPoint = 2;
   mountOffset = { 0, 0, 0.1 };
   mountRotation = { 1.57, 0, 0 };
   firstPerson = false;
};

ItemData BaseAlarm
{
   description = "Base Alarm";
   shapeFile = "sensor_small";
   className = "Backpack";
   heading = "gSensors";
   shadowDetailMask = 4;
   imageType = BaseAlarmImage;
   mass = 2.0;
   elasticity = 0.2;
   price = 50;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function BaseAlarm::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,$TeamItemCount[GameBase::getTeam(%player) @ %item] @ " " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function BaseAlarm::onDeploy(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	%name = "Base Alarm#" @ $totalNumBaseAlarms[%client]++;
	%shape = AlarmKit;
	%type = "StaticShape";
	if (DeployableSensor::deployShape(%player,%name,%shape,%item,%type)) {
		if ($BuilderMode){
		}
		else{
			Player::decItemCount(%player,%item);
			$TeamItemCount[GameBase::getTeam(%player) @ "BaseAlarm"]++;
		}
	}
}








//----------------------------------------------------------------------------
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
//{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{
//                              Deploy
//}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//----------------------------------------------------------------------------



function DeployableSensor::deployShape(%player,%name,%shape,%item,%type)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,$Nappy::SensorDeployDistance)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || $Nappy::DeployOnAnything)  {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)){
						%sensor = newObject("",%type,%shape,true);
 	        			   	addToSet("MissionCleanup", %sensor);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						GameBase::setPosition(%sensor,$los::position);
						GameBase::setRotation(%sensor,%rot);
						Gamebase::setMapName(%sensor,%name @ " " @ Nappy::getName(%client));
						Client::sendMessage(%client,0,%item.description @ " deployed");
						playSound(SoundPickupBackpack,$los::position);
						echo("MSG: ",%client," deployed a ",%item.description);
						return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

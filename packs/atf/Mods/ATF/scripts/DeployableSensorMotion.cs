//--------------------------------------

$InvList[MotionSensorPack] = 1;
$RemoteInvList[MotionSensorPack] = 1;

//--------------------------------------

$TeamItemMax[MotionSensorPack] = 1000;

//--------------------------------------

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
   heading = "uDeployables";
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
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MotionSensorPack::onDeploy(%player,%item,%pos)
{
	if (MotionSensorPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
	}
}

function MotionSensorPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%datobj = gamebase::getdataname($los::object); 
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %datobj == "AirPlatform") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.0) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				//if(checkDeployArea(%client,$los::position)) {
					%mSensor = newObject("","Sensor",DeployableMotionSensor,true);
	   	      addToSet("MissionCleanup", %mSensor);
					GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
					GameBase::setRotation(%mSensor,%rot);
					GameBase::setPosition(%mSensor,$los::position);
					Gamebase::setMapName(%mSensor,"Motion Sensor");
					Client::sendMessage(%client,0,"Motion Sensor deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Motion Sensor");
					return true;
				//}
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

//--------------------------------------

SensorData DeployableMotionSensor
{
   description = "Motion Sensor";
	className = "DeployableSensor";
	shapeFile = "sensor_small";
	shadowDetailMask = 16;
	visibleToSensor = true;
   validateShape = true;
   validateMaterials = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
//   explosionId = DebrisExp;
	damageLevel = {0.8, 1.0};
	maxDamage = 1.4;
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

//--------------------------------------
//--------------------------------------This is a shifter script...but i modified it and all so yeah i basically took the shifter version and learned from it :) thanx dudes at shifter :)

$InvList[SpringPadPack] = 1;
$RemoteInvList[SpringPadPack] = 1;

//--------------------------------------

$TeamItemMax[SpringPadPack] = 105;

//--------------------------------------

ItemImageData SpringPadPackImage
{
	shapeFile = "Shield";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData SpringPadPack
{
	description = "Spring Pad";
	shapeFile = "Shield";
	className = "Backpack";
   heading = "uDeployables";
	imageType = SpringPadPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SpringPadPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function SpringPadPack::onDeploy(%player,%item,%pos)
{
	if (SpringPadPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "SpringPadPack"]++;
	}
}

function SpringPadPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%datobj = gamebase::getdataname($los::object); 
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %datobj == "AIRPLATFORM") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				//if(checkDeployArea(%client,$los::position)) {
					%mSensor = newObject("","StaticShape",SpringPad,true);
	   	      addToSet("MissionCleanup", %mSensor);
					GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
					GameBase::setRotation(%mSensor,%rot);
					GameBase::setPosition(%mSensor,$los::position);
					Gamebase::setMapName(%mSensor,"Spring Pad");
					Client::sendMessage(%client,0,"Spring Pad deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a sping pad");
					return true;
				//}
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

$InvList[GenPack] = 1;
$RemoteInvList[GenPack] = 1;

//--------------------------------------

$TeamItemMax[GenPack] = 105;

//--------------------------------------

ItemImageData GenPackImage
{
	shapeFile = "Generator_p";
	mountPoint = 2;
	mountOffset = { 0.1, 0.1, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData GenPack
{
	description = "Porta-Gen";
	shapeFile = "Generator_p";
	className = "Backpack";
   heading = "uDeployables";
	imageType = GenPackImage;
	shadowDetailMask = 4;
	mass = 10.0;
	elasticity = 0.2;
	price = 1025;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function GenPack::onUse(%player,%item,%pos)
{
	if (GenPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "GenPack"]++;
	}
}

//PORT-OFF: function CreateGeneratorSimSet()
//PORT-OFF: {
//PORT-OFF:     	%teleset2 = nameToID(GameBase::getTeam(%player) @ "/Powered");
//PORT-OFF: 	if(%teleset2 == -1)
//PORT-OFF: 	{
//PORT-OFF: 		newObject("Generator",SimSet);
//PORT-OFF: 		addToSet("GameBase::getTeam(%player) @ "/Powered");
//PORT-OFF: 	}
//PORT-OFF: }

//PORT-OFF: function GenPack::deployShape(%player,%item)
//PORT-OFF: {
//PORT-OFF:  	%client = Player::getClient(%player);
//PORT-OFF: 	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
//PORT-OFF: 		if (GameBase::getLOSInfo(%player,3)) {
//PORT-OFF: 			// GetLOSInfo sets the following globals:
//PORT-OFF: 			// 	los::position
//PORT-OFF: 			// 	los::normal
//PORT-OFF: 			// 	los::object
//PORT-OFF: 			%datobj = gamebase::getdataname($los::object); 
//PORT-OFF: 			%obj = getObjectType($los::object);
//PORT-OFF: 			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %datobj == "AIRPLATFORM") {
//PORT-OFF: 				// Try to stick it straight up or down, otherwise
//PORT-OFF: 				// just use the surface normal
//PORT-OFF: 				%prot = GameBase::getRotation(%player);
//PORT-OFF: 				%zRot = getWord(%prot,2);
//PORT-OFF: 				if (Vector::dot($los::normal,"0 0 1") > 0) {
//PORT-OFF: 					%rot = "0 0 " @ %zRot;
//PORT-OFF: 				}
//PORT-OFF: 				else {
//PORT-OFF: 					if (Vector::dot($los::normal,"0 0 -1") > 0) {
//PORT-OFF: 						%rot = "3.14159 0 " @ %zRot;
//PORT-OFF: 					}
//PORT-OFF: 					else {
//PORT-OFF: 						%rot = Vector::getRotation($los::normal);
//PORT-OFF: 					}
//PORT-OFF: 				}
//PORT-OFF: 				if(checkDeployArea(%client,$los::position)) {
					
//PORT-OFF: 					%mSensor = newObject("Generator","StaticShape",Generator,true);
//PORT-OFF: 					CreateGeneratorSimSet();
//PORT-OFF: 					addToSet(GameBase::getTeam(%player) @ "/Powered", %msensor);
//PORT-OFF: 					addToSet(GameBase::getTeam(%player), %msensor);
//PORT-OFF: 					  addToSet(GameBase::getTeam(%player), %mSensor);
					
	   	    
//PORT-OFF: 					GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
//PORT-OFF: 					GameBase::setRotation(%mSensor,%rot);
//PORT-OFF: 					GameBase::setPosition(%mSensor,$los::position);
//PORT-OFF: 					Gamebase::setMapName(%mSensor,"Generator");
//PORT-OFF: 					Client::sendMessage(%client,0,"Porta-Gen deployed");
//PORT-OFF: 					playSound(SoundPickupBackpack,$los::position);
//PORT-OFF: 					echo("MSG: ",%client," deployed a generator");
//PORT-OFF: 					return true;
//PORT-OFF: 				}
//PORT-OFF: 			}
//PORT-OFF: 			else {
//PORT-OFF: 				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
//PORT-OFF: 			}
//PORT-OFF: 		}
//PORT-OFF: 		else {
//PORT-OFF: 			Client::sendMessage(%client,0,"Deploy position out of range");		
//PORT-OFF: 		}
//PORT-OFF: 	}
//PORT-OFF: 	else																						  
//PORT-OFF: 	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
//PORT-OFF: 	return false;
//PORT-OFF: }


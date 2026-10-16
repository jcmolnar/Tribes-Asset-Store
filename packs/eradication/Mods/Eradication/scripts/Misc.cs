
//----------------------------------------------------------------------------

ItemImageData RepairKitImage
{
	shapeFile = "armorkit";
	mountPoint = 2;
	mountOffset = { -0.25, 0.1, -0.75 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 0.15;
};

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "dEssentials";
   shadowDetailMask = 4;
   price = 49;
   className = "RepairKit";
   imageType = RepairKitImage;
   mass = 1.0;
   elasticity = 0.2;
};

function RepairKit::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		if (Item::giveItem(%object,%item,1)) {
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairKit::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$RepairKitSlot) != %item) {
		Player::mountItem(%player,%item,$RepairKitSlot);
		}
	else {
		Player::decItemCount(%player,%item);
		GameBase::repairDamage(%player,0.2);
	}
}


//----------------------------------------------------------------------------

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = "dTools";
	shadowDetailMask = 4;
  	price = 9;
};

function RepairPatch::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		if(GameBase::getDamageLevel(%object)) {
			GameBase::repairDamage(%object,0.125);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairPatch::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.1);
}


//----------------------------------------------------------------------------

ItemImageData CameraPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.6 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData CameraPack
{
	description = "Camera";
	shapeFile = "camera";
	className = "Sensor";
	imageType = CameraPackImage;
	mass = 1.0;
	elasticity = 0.2;
   heading = "mSensors";
	shadowDetailMask = 4;
	price = 99;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CameraPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		if (Item::giveItem(%object,%item,1)) {
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function CameraPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$SensorSlot) != %item) {
		if (Player::getMountedItem(%player,$SensorSlot) != -1) {
			while(Player::getMountedItem(%player,$SensorSlot) != -1) 
				Player::decItemCount(%player, Player::getMountedItem(%player,%SensorSlot));
			}
		else
			Player::mountItem(%player,%item,$SensorSlot);
	}
	else 
		Player::deployItem(%player,%item);
}


function CameraPack::onDeploy(%player,%item,%pos)
{
	if (CameraPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function CameraPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape") {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6)
		%rot = "0 0 " @ %zRot;
	else {
		if (Vector::dot($los::normal,"0 0 -1") > 0.6)
			%rot = "3.14159 0 " @ %zRot;
		else
			%rot = Vector::getRotation($los::normal);
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%camera = newObject("Camera","Turret",CameraTurret,true);
	addToSet("MissionCleanup", %camera);
	GameBase::setTeam(%camera,GameBase::getTeam(%player));
	GameBase::setRotation(%camera,%rot);
	GameBase::setPosition(%camera,$los::position);
	Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
	Client::sendMessage(%client,0,"Camera deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
	echo("MSG: ",%client," deployed a Camera");
	return true;
}

//----------------------------------------------------------------------------


ItemImageData DeployableSensorJamPackImage
{
	shapeFile = "sensor_jammer";
 	mountPoint = 2;
  	mountOffset = { 0, 0, -0.35 };
  	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
	mass = 0.5;
};

ItemData DeployableSensorJammerPack
{
	description = "Sensor Jammer";
  	shapeFile = "sensor_jammer";
  	className = "Sensor";
   heading = "mSensors";
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
  	price = 199;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableSensorJammerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$SensorSlot) != %item) {
		if (Player::getMountedItem(%player,$SensorSlot) != -1) {
			while(Player::getMountedItem(%player,$SensorSlot) != -1) 
				Player::decItemCount(%player, Player::getMountedItem(%player,%SensorSlot));
			}
		else
			Player::mountItem(%player,%item,$SensorSlot);
	}
	else 
		Player::deployItem(%player,%item);
}


function DeployableSensorJammerPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		if (Item::giveItem(%object,%item,1)) {
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos)
{
	if (DeployableSensorJammerPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function DeployableSensorJammerPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape") {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6)
		%rot = "0 0 " @ %zRot;
	else {
		if (Vector::dot($los::normal,"0 0 -1") > 0.6)
			%rot = "3.14159 0 " @ %zRot;
		else
			%rot = Vector::getRotation($los::normal);
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%mSensor = newObject("","Sensor",DeployableSensorJammer,true);
	addToSet("MissionCleanup", %mSensor);
	GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
	GameBase::setRotation(%mSensor,%rot);
	GameBase::setPosition(%mSensor,$los::position);
	Gamebase::setMapName(%mSensor,"Sensor Jammer");
	Client::sendMessage(%client,0,"Sensor Jammer deployed");
	playSound(SoundPickupBackpack,$los::position);
	echo("MSG: ",%client," deployed a Sensor Jammer");
	$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
	return true;
}

//----------------------------------------------------------------------------

ItemImageData MotionSensorPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
	mass = 0.5;
};

ItemData MotionSensorPack
{
	description = "Motion Sensor";
	shapeFile = "sensor_small";
	className = "Sensor";
   heading = "mSensors";
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 99;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MotionSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$SensorSlot) != %item) {
		if (Player::getMountedItem(%player,$SensorSlot) != -1) {
			while(Player::getMountedItem(%player,$SensorSlot) != -1) 
				Player::decItemCount(%player, Player::getMountedItem(%player,%SensorSlot));
			}
		else
			Player::mountItem(%player,%item,$SensorSlot);
	}
	else 
		Player::deployItem(%player,%item);
}


function MotionSensorPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		if (Item::giveItem(%object,%item,1)) {
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function MotionSensorPack::onDeploy(%player,%item,%pos)
{
	if (MotionSensorPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function MotionSensorPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape") {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6)
		%rot = "0 0 " @ %zRot;
	else {
		if (Vector::dot($los::normal,"0 0 -1") > 0.6)
			%rot = "3.14159 0 " @ %zRot;
		else
			%rot = Vector::getRotation($los::normal);
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%mSensor = newObject("","Sensor",DeployableMotionSensor,true);
	addToSet("MissionCleanup", %mSensor);
	GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
	GameBase::setRotation(%mSensor,%rot);
	GameBase::setPosition(%mSensor,$los::position);
	Gamebase::setMapName(%mSensor,"Motion Sensor");
	Client::sendMessage(%client,0,"Motion Sensor deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
	echo("MSG: ",%client," deployed a Motion Sensor");
	return true;
}

//----------------------------------------------------------------------------
	
ItemImageData PulseSensorPackImage
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
	mass = 0.5;
};

ItemData PulseSensorPack
{
	description = "Pulse Sensor";
	shapeFile = "radar_small";
	className = "Sensor";
   heading = "mSensors";
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 99;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PulseSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$SensorSlot) != %item) {
		if (Player::getMountedItem(%player,$SensorSlot) != -1) {
			while(Player::getMountedItem(%player,$SensorSlot) != -1) 
				Player::decItemCount(%player, Player::getMountedItem(%player,%SensorSlot));
			}
		else
			Player::mountItem(%player,%item,$SensorSlot);
	}
	else 
		Player::deployItem(%player,%item);
}


function PulseSensorPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		if (Item::giveItem(%object,%item,1)) {
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function PulseSensorPack::onDeploy(%player,%item,%pos)
{
	if (PulseSensorPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function PulseSensorPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape") {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6)
		%rot = "0 0 " @ %zRot;
	else {
		if (Vector::dot($los::normal,"0 0 -1") > 0.6)
			%rot = "3.14159 0 " @ %zRot;
		else
			%rot = Vector::getRotation($los::normal);
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%mSensor = newObject("","Sensor",DeployablePulseSensor,true);
	addToSet("MissionCleanup", %mSensor);
	GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
	GameBase::setRotation(%mSensor,%rot);
	GameBase::setPosition(%mSensor,$los::position);
	Gamebase::setMapName(%mSensor,"Pulse Sensor");
	Client::sendMessage(%client,0,"Pulse Sensor deployed");
	playSound(SoundPickupBackpack,$los::position);
	echo("MSG: ",%client," deployed a Pulse Sensor");
	$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
	return true;
}

//----------------------------------------------------------------------------

ItemImageData BeaconImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
	mass = 0.25;
};

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "mSensors";
   shadowDetailMask = 4;
   imageType = BeaconImage;
   mass = 2.0;
   elasticity = 0.2;
   price = 39;
   className = "Sensor";
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function Beacon::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$SensorSlot) != %item) {
		if (Player::getMountedItem(%player,$SensorSlot) != -1) {
			while(Player::getMountedItem(%player,$SensorSlot) != -1) 
				Player::decItemCount(%player, Player::getMountedItem(%player,%SensorSlot));
			}
		else
			Player::mountItem(%player,%item,$SensorSlot);
	}
	else 
		Player::deployItem(%player,%item);
}

function Beacon::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		if (Item::giveItem(%object,%item,1)) {
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function Beacon::onDeploy(%player,%item,%pos)
{
	if (Beacon::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function Beacon::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape") {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6)
		%rot = "0 0 " @ %zRot;
	else {
		if (Vector::dot($los::normal,"0 0 -1") > 0.6)
			%rot = "3.14159 0 " @ %zRot;
		else
			%rot = Vector::getRotation($los::normal);
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;


	%beacon = newObject("Target Beacon", "Sensor", "DefaultBeacon", true);
	addToSet("MissionCleanup", %beacon);
	GameBase::setTeam(%beacon,GameBase::getTeam(%player));
	GameBase::setRotation(%beacon,%rot);
	GameBase::setPosition(%beacon,$los::position);
	Gamebase::setMapName(%beacon,"Target Beacon");
   	Beacon::onEnabled(%beacon);
	Client::sendMessage(%client,0,"Beacon deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
	return true;
}

SensorData DefaultBeacon
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
	maxDamage = 5.0;
	maxEnergy = 200;

   castLOS = true;
   supression = false;
	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
   explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};
																						 
function Beacon::onEnabled(%this)
{
   GameBase::setIsTarget(%this,true);
}

function Beacon::onDisabled(%this)
{
   GameBase::setIsTarget(%this,false);
}

function Beacon::onDestroyed(%this)
{
   GameBase::setIsTarget(%this,false);
	$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
}


//----------------------------------------------------------------------------

ItemImageData KillerMarkerImage
{
	shapeFile = "rocket";
	mountPoint = 2;
	mountOffset = { 0, 0.225, 0.35 };
	mountRotation = { -1.57, 0, 0 };
	firstPerson = false;
};

ItemData KillerMarker
{
   description = "Expert Marker";
   shapeFile = "rocket";
   heading = "zMarkers";
   shadowDetailMask = 4;
   price = 9;
   className = "Marker";
   imageType = KillerMarkerImage;
	showInventory = false;
};

function KillerMarker::onUse(%player,%item)
{
	%client = Player::getClient(%player);
	if (Player::getMountedItem(%player,$MarkerSlot) != "") {
		if(%client.killDeath >= 5) 
			Player::mountItem(%player,%item,$MarkerSlot);
		else
			Player::decItemCount(%player,%item);
	}	
}

function KillerMarker::onDrop(%player,%item)
{

}


//----------------------------------------------------------------------------

ItemImageData NewbieMarkerImage
{
	shapeFile = "mortar";
	mountPoint = 2;
	mountOffset = { 0, 0, 1 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData NewbieMarker
{
   description = "Newbie Marker";
   shapeFile = "mortar";
   heading = "zMarkers";
   shadowDetailMask = 4;
   price = 9;
   className = "Marker";
   imageType = NewbieMarkerImage;
	showInventory = false;
};

function NewbieMarker::onUse(%player,%item)
{
	%client = Player::getClient(%player);
	if (Player::getMountedItem(%player,$MarkerSlot) != "") {
		if(%client.killDeath <= 0.1) 
			Player::mountItem(%player,%item,$MarkerSlot);
		else
			Player::decItemCount(%player,%item);
	}	
}

function NewbieMarker::onDrop(%player,%item)
{

}

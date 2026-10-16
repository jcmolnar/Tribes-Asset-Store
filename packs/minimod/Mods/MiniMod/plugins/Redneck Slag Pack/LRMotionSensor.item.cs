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

$TeamItemMax[DeployableLRMotionSensorPack] = 2;

ItemImageData DeployableLRMotionSensorPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
  	mountOffset = { 0, -0.07, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableLRMotionSensorPack
{
	description = "LR Motion Sensor";
	shapeFile = "sensor_pulse_med";
	className = "Backpack";
	heading = "dDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableLRMotionSensorPackImage;
	mass = 2.5;
	elasticity = 0.2;
	price = 750;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableLRMotionSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableLRMotionSensorPack::onDeploy(%player,%item,%pos)
{
	if (DeployableLRMotionSensorPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableLRMotionSensorPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%rot = GameBase::getRotation(%player); 
						%DTPad = newObject("","Sensor",DeployableLongRangeMotionSensor,true);
						addToSet("MissionCleanup", %DTPad);
						GameBase::setTeam(%DTPad,GameBase::getTeam(%player));
						GameBase::setPosition(%DTPad,Vector::add($los::position, "0 0 -0.05"));
						GameBase::setRotation(%DTPad, %rot);
						Gamebase::setMapName(%DTPad,"Long Range Motion Sensor");
						Client::sendMessage(%client,0,"Long Range Motion Sensor deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "DeployableLRMotionSensorPack"]++;
						echo("MSG: ",%client," deployed a Long Range Motion Sensor");
						Client::setOwnedObject(%client, %DTPad);
						Client::setOwnedObject(%client, %player);
						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

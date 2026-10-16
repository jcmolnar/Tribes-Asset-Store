createDeployable(DeployableSensorJammerPack, 1, 1, 1, 1, 1, 8);

ItemImageData DeployableSensorJamPackImage {
	shapeFile = "sensor_jammer";
 	mountPoint = 2;
  	mountOffset = { 0, 0.03, 0.1 };
  	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData DeployableSensorJammerPack {
	description = "Sensor Jammer";
	shapeFile = "sensor_jammer";
	className = "Backpack";
	heading = "dDeployables";
	imageType = DeployableSensorJamPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 225;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableSensorJammerPack::onUse(%player, %item){
	if(Player::getMountedItem(%player, $BackpackSlot) != %item) Player::mountItem(%player, %item, $BackpackSlot);
	else Player::deployItem(%player, %item);
}

function DeployableSensorJammerPack::onDeploy(%player, %item, %pos){
	deployItemX(%player, %item, "Sensor", DeployableSensorJammer, true, "SimTerrain InteriorShape", 3, true, true);
}
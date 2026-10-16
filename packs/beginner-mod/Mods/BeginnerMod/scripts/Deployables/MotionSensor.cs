createDeployable(MotionSensorPack, 1, 1, 1, 1, 1, 15);

ItemImageData MotionSensorPackImage {
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData MotionSensorPack {
	description = "Motion Sensor";
	shapeFile = "sensor_small";
	className = "Backpack";
	heading = "dDeployables";
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MotionSensorPack::onUse(%player, %item){
	if(Player::getMountedItem(%player, $BackpackSlot) != %item) Player::mountItem(%player, %item, $BackpackSlot);
	else Player::deployItem(%player, %item);
}

function MotionSensorPack::onDeploy(%player, %item, %pos){
	deployItemX(%player, %item, "Sensor", DeployableMotionSensor, "Any", "SimTerrain InteriorShape", 3, true, true);
}
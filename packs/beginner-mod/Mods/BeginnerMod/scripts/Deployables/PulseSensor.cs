createDeployable(PulseSensorPack, 1, 1, 1, 1, 1, 15);

ItemImageData PulseSensorPackImage {
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData PulseSensorPack {
	description = "Pulse Sensor";
	shapeFile = "radar_small";
	className = "Backpack";
	heading = "dDeployables";
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PulseSensorPack::onUse(%player, %item){
	if(Player::getMountedItem(%player, $BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player, %item);
}

function PulseSensorPack::onDeploy(%player, %item, %pos){
	deployItemX(%player, %item, "Sensor", DeployablePulseSensor, true, "SimTerrain InteriorShape", 3, true, true);
}
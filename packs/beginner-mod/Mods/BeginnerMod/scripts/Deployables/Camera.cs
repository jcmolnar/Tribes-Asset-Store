createDeployable(CameraPack, 1, 2, 1, 1, 1, 15);

ItemImageData CameraPackImage {
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CameraPack {
	description = "Camera";
	shapeFile = "camera";
	className = "Backpack";
	heading = "dDeployables";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	validateShape = true;
	validateMaterials = true;
};

function CameraPack::onUse(%player, %item){
	if(Player::getMountedItem(%player, $BackpackSlot) != %item) Player::mountItem(%player, %item, $BackpackSlot);
	else Player::deployItem(%player, %item);
}

function CameraPack::onDeploy(%player, %item, %pos){
	deployItemX(%player, %item, "Turret", CameraTurret, true, "SimTerrain InteriorShape", 3, true, true);
}
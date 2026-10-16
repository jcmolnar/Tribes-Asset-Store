createDeployable(TurretPack, 1, 1, 0, 1, 1, 10);

ItemImageData TurretPackImage {
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};
ItemData TurretPack {
	description = "Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = "dDeployables";
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function TurretPack::onUse(%player, %item){
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player, %item, $BackpackSlot);
	else Player::deployItem(%player, %item);
}
function TurretPack::onDeploy(%player, %item, %pos){
	deployItemX(%player, %item, "Turret", DeployableTurret, "Any", "SimTerrain InteriorShape", 3, true, true);
}
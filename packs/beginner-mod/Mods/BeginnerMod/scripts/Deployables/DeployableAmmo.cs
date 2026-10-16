createDeployable(DeployableAmmoPack, 1, 0, 0, 1, 1, 7);

ItemImageData DeployableAmmoPackImage {
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};
ItemData DeployableAmmoPack {
	description = "Ammo Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
	heading = "dDeployables";
	shadowDetailMask = 4;
	imageType = DeployableAmmoPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteAmmoEnergy;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableAmmoPack::onUse(%player, %item){
	if(Player::getMountedItem(%player, $BackpackSlot) != %item) Player::mountItem(%player, %item, $BackpackSlot);
	else Player::deployItem(%player, %item);
}

function DeployableAmmoPack::onDeploy(%player, %item, %pos){
	deployItemX(%player, %item, "StaticShape", "DeployableAmmoStation", true, "SimTerrain InteriorShape", 3, true, true);
}
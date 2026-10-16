createDeployable(DeployableInvPack, 1, 0, 0, 1, 1, 7);

ItemImageData DeployableInvPackImage {
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableInvPack {
	description = "Inventory Station";
	shapeFile = "invent_remote";
	className = "Backpack";
	heading = "dDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableInvPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteInvEnergy + 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableInvPack::onUse(%player, %item){
	if(Player::getMountedItem(%player, $BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player, %item);
}

function DeployableInvPack::onDeploy(%player, %item, %pos){
	deployItemX(%player, %item, "StaticShape", "DeployableInvStation", true, "SimTerrain InteriorShape", 3, true, true);
}
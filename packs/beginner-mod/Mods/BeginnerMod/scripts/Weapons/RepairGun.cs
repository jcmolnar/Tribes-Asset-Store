createWeapon(RepairGun, "", 0, 0, false, "", 1, 1, 1);

ItemImageData RepairGunImage {
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 10;
	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData RepairGun {
	description = "Repair Gun";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	showInventory = false;
	price = 125;
	validateShape = true;
};

function RepairGun::onMount(%player, %imageSlot){
	Player::trigger(%player, $BackpackSlot, true);
}

function RepairGun::onUnmount(%player, %imageSlot){
	Player::trigger(%player, $BackpackSlot, false);
}
createBackPack(RepairPack, 1, 1, 1, 1, 1); // PORT: was %pack (an empty local at file scope)

ItemImageData RepairPackImage {
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0;
	maxEnergy = 0;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData RepairPack {
	description = "Repair Pack";
	shapeFile = "armorPack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
	validateShape = true;
	validateMaterials = true;
};

function RepairPack::onUnmount(%player, %item){
	if(Player::getMountedItem(%player, $WeaponSlot) == RepairGun) Player::unmountItem(%player, $WeaponSlot);
}

function RepairPack::onUse(%player,%item){
	if(Player::getMountedItem(%player, $BackpackSlot) != %item) Player::mountItem(%player, %item, $BackpackSlot);
	else Player::mountItem(%player, RepairGun, $WeaponSlot);
}

function RepairPack::onDrop(%player, %item){
	if($matchStarted){
		%mounted = Player::getMountedItem(%player, $WeaponSlot);
		if(%mounted == RepairGun) Player::unmountItem(%player, $WeaponSlot);
		else Player::mountItem(%player, %mounted, $WeaponSlot);
		Item::onDrop(%player, %item);
	}
}
createBackPack(ShieldPack, 1, 1, 1, 1, 1);

ItemImageData ShieldPackImage {
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 4;
	maxEnergy = 9;
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ShieldPack {
	description = "Shield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
	validateShape = true;
	validateMaterials = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot){
	Client::sendMessage(Player::getClient(%player), 0, "Shield On");
	%player.shieldStrength = 0.012;
}

function ShieldPackImage::onDeactivate(%player, %imageSlot){
	Client::sendMessage(Player::getClient(%player), 0, "Shield Off");
	Player::trigger(%player, $BackpackSlot, false);
	%player.shieldStrength = 0;
}
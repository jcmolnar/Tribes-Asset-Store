ItemImageData ShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 4;
	maxEnergy = 0.1;
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ShieldPack
{
	description = "Shield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
	heading = $InvHeading[BackPacks];
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
	validateShape = false;
	validateMaterials = false;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	%c = Player::getClient(%player);
	%player.shieldStrength = 0.009;
	Client::sendMessage(%c, 0, "Shield is being established...");
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	%c = Player::getClient(%player);
	%player.shieldStrength = 0;
	Client::sendMessage(%c, 0, "Shields Depleted.~waccess_denied.wav");
}
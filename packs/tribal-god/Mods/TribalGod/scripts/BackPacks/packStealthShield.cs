ItemImageData SensorJammerPackImage {
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;
	maxEnergy = 0.1;
	sfxFire = SoundJammerOn;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SensorJammerPack {
	description = "StealthShield Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = $InvHeading[BackPacks];
	shadowDetailMask = 4;
	imageType = SensorJammerPackImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
	validateShape = false;
	validateMaterials = false;
};

function SensorJammerPackImage::onActivate(%player,%imageSlot){
	%c = Player::getClient(%player);
    %player.shieldStrength = 0.025;
    Player::setSensorSupression(%player, 3);
    Client::sendMessage(%c, 0, "StealthShield Pack: On.");
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot){
	%playerId = Player::getClient(%player);
	%player.shieldStrength = 0;
	Player::setSensorSupression(%player, 0);
	Client::sendMessage(%playerId, 0, "StealthShield Pack: Off.");
}
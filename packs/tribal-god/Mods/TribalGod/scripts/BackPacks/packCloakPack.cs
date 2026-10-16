ItemImageData CloakingDeviceImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;
	maxEnergy = 0.1;
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};
ItemData CloakingDevice
{
	description = "Cloaking Device";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = $InvHeading[BackPacks];
	shadowDetailMask = 4;
	imageType = CloakingDeviceImage;
	price = 600;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function CloakingDeviceImage::onActivate(%player,%imageSlot)
{
	%c = Player::getClient(%player);
	Player::setSensorSupression(%player, 5);
	GameBase::startFadeOut(%player);
	Client::sendMessage(%c, 0, "Cloaking Device: On.");
}
function CloakingDeviceImage::onDeactivate(%player,%imageSlot)
{
	%c = Player::getClient(%player);
	Player::setSensorSupression(%player, 0);
	GameBase::startFadeIn(%player);
	Client::sendMessage(%c, 0, "Cloaking Device: Off.~waccess_denied.wav");
}
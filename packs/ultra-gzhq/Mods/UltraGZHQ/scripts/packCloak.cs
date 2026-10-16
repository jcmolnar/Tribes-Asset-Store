$InvList[CloakingDevice] = 1;
$MobileInvList[CloakingDevice] = 1;
$RemoteInvList[CloakingDevice] = 1;
AddItem(CloakingDevice);

ItemImageData CloakingDeviceImage 
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;
	maxEnergy = 10;
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
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = CloakingDeviceimage;
	price = 600;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CloakingDeviceImage::onActivate(%player,%imageSlot) 
{
	GameBase::startFadeout(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device On");
	%rate = Player::getSensorSupression(%player) + 5;
	Player::setSensorSupression(%player,%rate);
	%player.guiLock = true;
	%c = Player::getClient(%player);
	%c.guiLock = true;
}

function CloakingDeviceImage::onDeactivate(%player,%imageSlot) 
{
	GameBase::startFadein(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off");
	%rate = Player::getSensorSupression(%player) - 5;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
	%player.guiLock = "";
	%c = Player::getClient(%player);
	%c.guiLock = "";
}

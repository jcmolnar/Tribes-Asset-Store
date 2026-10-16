$InvList[CloakPack] = 1;
$RemoteInvList[CloakPack] = 1;

ItemImageData CloakPackImage
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

ItemData CloakPack
{
	description = "Cloak";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = $InvHead[iEnha];
	shadowDetailMask = 4;
	imageType = CloakPackimage;
	price = 400;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CloakPackImage::onActivate(%player,%imageSlot)
{
	GameBase::startFadeout(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloak On");
	%rate = Player::getSensorSupression(%player) + 5;
	Player::setSensorSupression(%player,%rate);
	%player.guiLock = true;
	%c = Player::getClient(%player);
	%c.guiLock = true;
	%clientId.ghostDoneFlag = true;
	startGhosting(%cl);
}

function CloakPackImage::onDeactivate(%player,%imageSlot)
{
	GameBase::startFadein(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloak Off");
	%rate = Player::getSensorSupression(%player) - 5;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
	%player.guiLock = "";
	%c = Player::getClient(%player);
	%c.guiLock = "";
}
$InvList[CloakingPack] = 1;
$RemoteInvList[CloakingPack] = 1;

$ItemMax[narmor, CloakingPack] = 1;
$ItemMax[aarmor, CloakingPack] = 1;
$ItemMax[darmor, CloakingPack] = 1;
$ItemMax[nfemale, CloakingPack] = 1;
$ItemMax[afemale, CloakingPack] = 1;
$ItemMax[warmor, CloakingPack] = 1;
$ItemMax[barmor, CloakingPack] = 1;
$ItemMax[sarmor, CloakingPack] = 1;
$ItemMax[avarmor, CloakingPack] = 1;
$ItemMax[wfemale, CloakingPack] = 1;
$ItemMax[bfemale, CloakingPack] = 1;

ItemImageData CloakingPackImage
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

ItemData CloakingPack
{
	description = "Cloaking Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = CloakingPackimage;
	price = 550;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CloakingPackImage::onActivate(%player,%imageSlot)
{
	GameBase::startFadeout(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Pack On");
	%rate = Player::getSensorSupression(%player) + 5;
	Player::setSensorSupression(%player,%rate);
	%player.guiLock = true;
	%c = Player::getClient(%player);
	%c.guiLock = true;
	%clientId.ghostDoneFlag = true;
	startGhosting(%cl);
}

function CloakingPackImage::onDeactivate(%player,%imageSlot)
{
	GameBase::startFadein(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Pack Off");
	%rate = Player::getSensorSupression(%player) - 5;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
	%player.guiLock = "";
	%c = Player::getClient(%player);
	%c.guiLock = "";
}

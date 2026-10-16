//---Redone by :{jInZo}:

$InvList[CloakingDevice] = 1;
$RemoteInvList[CloakingDevice] = 1;

$ItemMax[harmor, CloakingDevice] = 1;
$ItemMax[marmor, CloakingDevice] = 1;
$ItemMax[mfemale, CloakingDevice] = 1;
$ItemMax[larmor, CloakingDevice] = 1;
$ItemMax[lfemale, CloakingDevice] = 1;


ItemImageData CloakingDeviceImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 9;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CloakingDevice
{
	description = "Cloak Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = CloakingDeviceimage;
	price = 250;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CloakingDeviceImage::onActivate(%player,%imageSlot)
{
	%radius = Player::getSensorSupression(%player) + 1;
	Player::setSensorSupression(%player,%radius);
	GameBase::playSound(%player,ForceFieldOpen,0);
 	GameBase::startFadeout(%player);
 	$cloaked[%player] = 1;
 	//Cloaker(%player);
 	%ClientId = Player::getClient(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Pack On");
	Player::trigger(%player,$BackpackSlot,true);
}

function CloakingDeviceImage::onDeactivate(%player,%imageSlot)
{
	%radius = Player::getSensorSupression(%player) - 1;
	Player::setSensorSupression(%player,%radius);
	GameBase::playSound(%player,ForceFieldClose,0);
 	GameBase::startFadein(%player);
 	$cloaked[%player] = 0;
 	//Cloaker(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Pack Off");
	Player::trigger(%player,$BackpackSlot,false);
}

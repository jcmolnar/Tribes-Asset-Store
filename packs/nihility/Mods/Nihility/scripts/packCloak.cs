//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
$InvList[CloakingDevice] = 1;

$ItemMax[larmor, CloakingDevice] = 1;	//Seraph
$ItemMax[lfemale, CloakingDevice] = 1;	//Seraph
$ItemMax[earmor, CloakingDevice] = 0;	//Slave
$ItemMax[efemale, CloakingDevice] = 0;	//Slave
$ItemMax[marmor, CloakingDevice] = 0;	//Pawn
$ItemMax[aarmor, CloakingDevice] = 1;	//Navigator
$ItemMax[darmor, CloakingDevice] = 0;	//Atomizer
$ItemMax[barmor, CloakingDevice] = 0;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

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
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = CloakingDeviceimage;
	price = 33;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CloakingDeviceImage::onActivate(%player,%imageSlot)
{
	GameBase::startFadeout(%player);
	Client::sendMessage(Player::getClient(%player),1,"Phasing Out...");
	%rate = Player::getSensorSupression(%player) + 45;
	Player::setSensorSupression(%player,%rate);
	%player.guiLock = true;
	%c = Player::getClient(%player);
	%c.guiLock = true;
	%clientId.ghostDoneFlag = true;
	startGhosting(%cl);
}

function CloakingDeviceImage::onDeactivate(%player,%imageSlot)
{
	GameBase::startFadein(%player);
	Client::sendMessage(Player::getClient(%player),1,"Phasing In...");
	%rate = Player::getSensorSupression(%player) - 45;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
	%player.guiLock = "";
	%c = Player::getClient(%player);
	%c.guiLock = "";
}


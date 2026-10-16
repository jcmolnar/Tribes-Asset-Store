$InvList[StealthPack] = 1;
$RemoteInvList[StealthPack] = 1;

// Who can use this pack
$ItemMax[reconarmor, StealthPack] = 0;
$ItemMax[reconfemalearmor, StealthPack] = 0;
$ItemMax[espionagearmor, StealthPack] = 1;
$ItemMax[espionagefemalearmor, StealthPack] = 1;
$ItemMax[engineerarmor, StealthPack] = 0;
$ItemMax[engineerfemalearmor, StealthPack] = 0;
$ItemMax[infantryarmor, StealthPack] = 0;
$ItemMax[infantryfemalearmor, StealthPack] = 0;
$ItemMax[falloutarmor, StealthPack] = 0;
$ItemMax[falloutfemalearmor, StealthPack] = 0;
$ItemMax[demolitionsarmor, StealthPack] = 0;
$ItemMax[assaultarmor, StealthPack] = 0;
$ItemMax[artilleryarmor, StealthPack] = 0;
$ItemMax[commanderarmor, StealthPack] = 0;

ItemImageData StealthPackImage 
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

ItemData StealthPack 
{
  description = "Stealth Pack";
  shapeFile = "sensorjampack";
  className = "Backpack";
  heading = "cBackpacks";
  shadowDetailMask = 4;
  imageType = StealthPackImage;
  price = 600;
  hudIcon = "sensorjamerpack";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function StealthPackImage::onActivate(%player, %slot) {
	Client::sendMessage(Player::getClient(%player),0,"Stealth Pack Activated");
	Stealthify(%player, 10);
}

function StealthPackImage::onDeactivate(%player,%slot) {
	Client::sendMessage(Player::getClient(%player),0,"Stealth Pack Deactivated");
	Destealthify(%player, 10);
}

function StealthPack::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "The Stealth Pack helps to render the wearer virtually invisible.");
	}
}

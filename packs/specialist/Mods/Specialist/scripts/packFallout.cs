$InvList[FalloutPack] = 1;
$RemoteInvList[FalloutPack] = 1;

// Who can use this pack
$ItemMax[reconarmor, FalloutPack] = 1;
$ItemMax[reconfemalearmor, FalloutPack] = 1;
$ItemMax[espionagearmor, FalloutPack] = 1;
$ItemMax[espionagefemalearmor, FalloutPack] = 1;
$ItemMax[engineerarmor, FalloutPack] = 1;
$ItemMax[engineerfemalearmor, FalloutPack] = 1;
$ItemMax[infantryarmor, FalloutPack] = 1;
$ItemMax[infantryfemalearmor, FalloutPack] = 1;
$ItemMax[falloutarmor, FalloutPack] = 0;
$ItemMax[falloutfemalearmor, FalloutPack] = 0;
$ItemMax[demolitionsarmor, FalloutPack] = 1;
$ItemMax[assaultarmor, FalloutPack] = 1;
$ItemMax[artilleryarmor, FalloutPack] = 1;
$ItemMax[commanderarmor, FalloutPack] = 1;

ItemImageData FalloutPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData FalloutPack
{
	description = "Fallout Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = FalloutPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 200;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FalloutPack::onUse(%player, %item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player, %item, $BackpackSlot);
	}
}

function FalloutPack::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "The Fallout Pack protects the wearer from radiation and poisonous gas.");
	}
}

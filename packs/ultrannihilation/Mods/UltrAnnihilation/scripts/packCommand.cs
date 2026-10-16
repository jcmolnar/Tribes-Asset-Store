$InvList[Laptop] = 1;
$MobileInvList[Laptop] = 1;
$RemoteInvList[Laptop] = 1;

ItemImageData LaptopImage 
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	weaponType = 2;
	minEnergy = -1;
	maxEnergy = -3;
	mass = 0.5;
	firstPerson = false;
};

ItemData Laptop 
{
	description = "Laptop";
	shapeFile = "ammounit_remote";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = LaptopImage;
	price = 650;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Laptop::IsAvailable(%player)
{
	return (Player::getMountedItem(%player, $BackpackSlot) == Laptop);
}

function Laptop::Error(%client, %msg)
{
	Client::sendMessage(%client, 0, "Laptop Err: " @ %msg @ "~waccess_denied.wav");
}

function Laptop::Output(%client, %msg)
{
	Client::sendMessage(%client, 0, "Laptop: " @ %msg);
}

function Laptop::onUse(%player,%item) 
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
}

function Laptop::onMount(%player,%item) 
{
	Player::trigger(%player,$BackpackSlot,true);
	Bottomprint(%client, "The Laptop will allow you to control turrets without being at a command station... among other things.");
}

function Laptop::onUnmount(%player,%item) 
{
}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
$InvList[Laptop] = 1;

$ItemMax[larmor, Laptop] = 0;		//Seraph
$ItemMax[lfemale, Laptop] = 0;		//Seraph
$ItemMax[earmor, Laptop] = 1;		//Slave
$ItemMax[efemale, Laptop] = 1;		//Slave
$ItemMax[marmor, Laptop] = 0;		//Pawn
$ItemMax[aarmor, Laptop] = 1;		//Navigator
$ItemMax[darmor, Laptop] = 0;		//Atomizer
$ItemMax[barmor, Laptop] = 0;		//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++


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
	description = "Command Laptop";
	shapeFile = "ammounit_remote";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = LaptopImage;
	price = 33;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Laptop::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function Laptop::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function Laptop::onUnmount(%player,%item)
{
}


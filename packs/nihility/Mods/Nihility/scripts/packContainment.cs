//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
$InvList[Gamma] = 1;

$ItemMax[larmor, Gamma] = 0;	//Seraph
$ItemMax[lfemale, Gamma] = 0;	//Seraph
$ItemMax[earmor, Gamma] = 0;	//Slave
$ItemMax[efemale, Gamma] = 0;	//Slave
$ItemMax[marmor, Gamma] = 0;	//Pawn
$ItemMax[aarmor, Gamma] = 0;	//Navigator
$ItemMax[darmor, Gamma] = 0;	//Atomizer
$ItemMax[barmor, Gamma] = 1;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData GammaImage 
{
	shapeFile = "liqcyl";//jetpack
	weaponType = 2;
	mountPoint = 2;
	mountOffset ={ 0, -0.1, -0.3 };
	minEnergy = -1;
	maxEnergy = -2;
	mass = 2.5;
	firstPerson = false;
};


ItemData Gamma 
{
	description = "Deuterium Battery";
	shapeFile = "jetpack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = GammaImage;
	price = 333;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Gamma::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function Gamma::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function Gamma::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Nukes)
	//Player::setItemCount(%client, Nukes , 0);
	Player::UnmountItem(%player,$WeaponSlot);
} 

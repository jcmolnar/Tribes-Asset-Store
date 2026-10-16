//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
$InvList[IonPack] = 1;

$ItemMax[larmor, IonPack] = 0;	//Seraph
$ItemMax[lfemale, IonPack] = 0;	//Seraph
$ItemMax[earmor, IonPack] = 0;	//Slave
$ItemMax[efemale, IonPack] = 0;	//Slave
$ItemMax[marmor, IonPack] = 0;	//Pawn
$ItemMax[aarmor, IonPack] = 0;	//Navigator
$ItemMax[darmor, IonPack] = 0;	//Atomizer
$ItemMax[barmor, IonPack] = 1;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData IonPackImage 
{
	shapeFile = "shieldpack";//jetpack
	weaponType = 2;
	mountPoint = 2;
	mountOffset ={ 0, -0.1, 0 };
	minEnergy = -1;
	maxEnergy = -2;
	mass = -7.0;
	firstPerson = false;
};


ItemData IonPack 
{
	description = "Ion Generator";	//liqcyl   generator_p
	shapeFile = "jetpack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = IonPackImage;
	price = 333;
	hudIcon = "energyRifle";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function IonPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function IonPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Titan)
	//Player::setItemCount(%client, Titan , 0);
	Player::UnmountItem(%player,$WeaponSlot);
} 

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
$InvList[EnergyPack] = 1;

$ItemMax[larmor, EnergyPack] = 1;	//Seraph
$ItemMax[lfemale, EnergyPack] = 1;	//Seraph
$ItemMax[earmor, EnergyPack] = 1;	//Slave
$ItemMax[efemale, EnergyPack] = 1;	//Slave
$ItemMax[marmor, EnergyPack] = 1;	//Pawn
$ItemMax[aarmor, EnergyPack] = 1;	//Navigator
$ItemMax[darmor, EnergyPack] = 1;	//Atomizer
$ItemMax[barmor, EnergyPack] = 1;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData EnergyPackImage 
{
	shapeFile = "jetpack";//jetpack
	weaponType = 2;
	mountPoint = 2;
	mountOffset ={ 0, -0.1, 0 };
	minEnergy = -3;
	maxEnergy = -5;
	firstPerson = false;
};


ItemData EnergyPack 
{
	description = "Energy Pack";
	shapeFile = "jetpack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 33;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function EnergyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EnergyPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle)
	//Player::setItemCount(%client, LaserRifle , 0);
	Player::UnmountItem(%player,$WeaponSlot);
} 

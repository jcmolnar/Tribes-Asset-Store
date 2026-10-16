//================================================================
//energy Pack
//================================================================
$ItemMax[larmor, EnergyPack] = 1;
$ItemMax[lfemale, EnergyPack] = 1;
$ItemMax[marmor, EnergyPack] = 1;
$ItemMax[mfemale, EnergyPack] = 1;
$ItemMax[harmor, EnergyPack] = 1;
//================================================================
$InvList[EnergyPack] = 1;
$RemoteInvList[EnergyPack] = 1;
//================================================================
ItemImageData EnergyPackImage
{
	shapeFile = "pack_energy";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -100;
 	maxEnergy = -100;
	firstPerson = false;
};

ItemData EnergyPack
{
	description = "Energy Pack";
	shapeFile = "pack_energy";
	className = "Backpack";
   heading = "gUtility Packs";
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   //validateShape = true;
   //validateMaterials = true;
};

function EnergyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EnergyPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == FarSight) 
		Player::unmountItem(%player,$WeaponSlot);
}

//================================================================
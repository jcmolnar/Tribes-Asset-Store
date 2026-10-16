//--------------------------------------

addToInv(EnergyPack,1,1);

setArmorItemMax(EnergyPack,1,1,1,1,1,1,1, 0, 0,0,0,0);

//--------------------------------------

ItemImageData EnergyPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -1;
	maxEnergy = -3;
	firstPerson = false;
};

ItemData EnergyPack
{
	description = "Energy Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = $InvCatPacks;
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   //validateMaterials = true;
};

$MountMSG[EnergyPack] = "<JC><F2>Energy Pack <F0>- <F1>Increase energy recharge rate.";

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
	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	if (%weapon == LaserRifle || %weapon == ChainLaser || %weapon == BeamCannon)
		Player::unmountItem(%player,$WeaponSlot);
}


//--------------------------------------

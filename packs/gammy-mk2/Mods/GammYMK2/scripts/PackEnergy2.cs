//--------------------------------------

$InvList[EnergyPack2] = 1;
$RemoteInvList[EnergyPack2] = 1;

//--------------------------------------

ItemImageData EnergyPack2Image
{
	shapeFile = "Generator_p";
	weaponType = 2;  // Sustained
                mass = 7.5;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -40;
 	maxEnergy = -80;
	firstPerson = false;
};

ItemData EnergyPack2
{
	description = "Energizer Pack";
	shapeFile = "Zap_5";
	className = "Backpack";
   heading = "wBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPack2Image;
	price = 250;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function EnergyPack2::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EnergyPack2::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack2::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == SM) 
		Player::unmountItem(%player,$WeaponSlot);
}


//--------------------------------------
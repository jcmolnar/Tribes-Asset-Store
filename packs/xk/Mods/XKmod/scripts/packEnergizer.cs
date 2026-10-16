// <-- This is a rem command. Great for placing notes.
// (Rems-out anything that follows it.)

$InvList[EnergizerPack] = 1; // You want the main Inventory stations to show it right?
$RemoteInvList[EnergizerPack] = 1; // You want the deployable Inventory stations to show it right?

ItemImageData EnergizerPackImage
{
	shapeFile = "mortarpack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -15; // This is where it negates the armors jet drain. By in creasing its recharge rate.
 	maxEnergy = -20; // This is where it negates the armors jet drain. By in creasing its recharge rate.
	firstPerson = false;
};

ItemData EnergizerPack
{
	description = "Energizer Pack";
	shapeFile = "mortarpack";
	className = "Backpack";
   heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = EnergizerPackImage;
	price = 450;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function EnergizerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EnergizerPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EnergizerPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairRifle) 
		Player::unmountItem(%player,$WeaponSlot);
}

 
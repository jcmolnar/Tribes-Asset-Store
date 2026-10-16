// This is a MiniMod Plugin.
// This plugin is the Energizer Pack. Created/Ported by Dewy.
MiniMod::MonitorFile(start, "EnergizerPack.CodeFusion.cs", "Energizer Pack Plugin");
MiniMod::Turbo::Class(EnergizerPack, 18);

ItemImageData EnergizerPackImage
{
	shapeFile = "mortarpack"; // Changed to make it look better. :)
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
	shapeFile = "mortarpack"; // Changed to make it look better. :)
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = EnergizerPackImage;
	price = 150;
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
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairRifle) // Ok this I added in case I later feel like making a Sniper Style repaiar gun.
		Player::unmountItem(%player,$WeaponSlot);
}


$InvList[EnergizerPack] = 1; 
$RemoteInvList[EnergizerPack] = 1; 

MiniMod::MonitorFile(stop, "EnergizerPack.CodeFusion.cs", "Energizer Pack Plugin");

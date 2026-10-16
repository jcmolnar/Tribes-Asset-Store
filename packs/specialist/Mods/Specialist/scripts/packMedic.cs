$InvList[MedicPack] = 1;
$RemoteInvList[MedicPack] = 1;

// Who can use this pack
$ItemMax[reconarmor, MedicPack] = 1;
$ItemMax[reconfemalearmor, MedicPack] = 1;
$ItemMax[espionagearmor, MedicPack] = 1;
$ItemMax[espionagefemalearmor, MedicPack] = 1;
$ItemMax[engineerarmor, MedicPack] = 1;
$ItemMax[engineerfemalearmor, MedicPack] = 1;
$ItemMax[infantryarmor, MedicPack] = 1;
$ItemMax[infantryfemalearmor, MedicPack] = 1;
$ItemMax[falloutarmor, MedicPack] = 1;
$ItemMax[falloutfemalearmor, MedicPack] = 1;
$ItemMax[demolitionsarmor, MedicPack] = 1;
$ItemMax[assaultarmor, MedicPack] = 1;
$ItemMax[artilleryarmor, MedicPack] = 1;
$ItemMax[commanderarmor, MedicPack] = 1;

ItemImageData MedicPackImage
{
	shapeFile = "armorpack";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData MedicPack
{
	description = "Medic Pack";
	shapeFile = "armorpack";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = MedicPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 700;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MedicPack::onUse(%player, %item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player, %item, $BackpackSlot);
	}
	else {
		// Get user's energy
		%energy = GameBase::getEnergy(%player);

		// If enough energy,
		%required = 50;
		if (%energy >= %required) {

			// Subtract energy
			GameBase::setEnergy(%player, %energy - %required);

			// Create repair kit
			%obj = newObject("", "Item", "RepairKit", 1, false);
 	 	 	addToSet("MissionCleanup", %obj);

			// Throw repair kit
			GameBase::throw(%obj, %player, 10, false);

			// Play sound
			GameBase::playSound(%player, SoundPickupBackpack, 3);
		}
	}
}

function MedicPack::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "The Medic Pack creates Repair Kits when used.");
	}
}

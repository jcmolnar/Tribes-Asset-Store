$InvList[SeedPack] = 1;
$RemoteInvList[SeedPack] = 1;

// Who can use this pack
$ItemMax[reconarmor, SeedPack] = 1;
$ItemMax[reconfemalearmor, SeedPack] = 1;
$ItemMax[espionagearmor, SeedPack] = 1;
$ItemMax[espionagefemalearmor, SeedPack] = 1;
$ItemMax[engineerarmor, SeedPack] = 1;
$ItemMax[engineerfemalearmor, SeedPack] = 1;
$ItemMax[infantryarmor, SeedPack] = 1;
$ItemMax[infantryfemalearmor, SeedPack] = 1;
$ItemMax[falloutarmor, SeedPack] = 1;
$ItemMax[falloutfemalearmor, SeedPack] = 1;
$ItemMax[demolitionsarmor, SeedPack] = 1;
$ItemMax[assaultarmor, SeedPack] = 1;
$ItemMax[artilleryarmor, SeedPack] = 1;
$ItemMax[commanderarmor, SeedPack] = 1;

ItemData Seed
{
	description = "Seed";
	className = "Repair";
	shapeFile = "mortar";
   heading = "eMiscellany";
	shadowDetailMask = 4;
  	price = 2;
};

ItemImageData SeedPackImage
{
	shapeFile = "armorpack";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SeedPack
{
	description = "Seed Pack";
	shapeFile = "armorpack";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = SeedPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 475;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SeedPack::onUse(%player, %item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player, %item, $BackpackSlot);
	}
	else {
		// Get user's energy
		%energy = GameBase::getEnergy(%player);

		// If enough energy,
		%required = 30;
		if (%energy >= %required) {

			// Subtract energy
			GameBase::setEnergy(%player, %energy - %required);

			// Create seed
			%obj = newObject("", "Item", "Seed", 1, false);
 	 	 	addToSet("MissionCleanup", %obj);

			// Throw seed
			GameBase::throw(%obj, %player, 10, false);

			// Play sound
			GameBase::playSound(%player, SoundPickupBackpack, 3);

			schedule("Seed::deploy("@%obj@");", 3, %obj);
		}
	}
}

function Seed::deploy(%this) {
	if (GameBase::isAtRest(%this)) {
		// Schedule growth
		%time = floor(getRandom() * 15);
		schedule("Seed::Grow("@%this@");", %time, %this);
		return;
	}
	else {
		schedule("Seed::deploy("@%this@");", 3, %this);
		return;
	}
}

function Seed::Grow(%this) {
	// This function will grow the seed into a plant or tree

	// Get the position of the seed
	%pos = GameBase::getPosition(%this);

	// Check around the seed
	%mask = $SimTerrainObjectType;
	%size = 0.2;
	%set = newObject("seedTerrainSet", SimSet);
	%terrainNum = containerBoxFillSet(%set, %mask, %pos, %size, %size, %size, 0);
	deleteObject(%set);

	// If it's not on terrain, the seed dies
	if (%terrainNum < 1) {
		// Delete the seed
		deleteObject(%this);
		return;
	}

	%mask = $SimInteriorObjectType | $StaticObjectType;
	%set = newObject("seedInteriorSet", SimSet);
	%interiorNum = containerBoxFillSet(%set, %mask, %pos, %size, %size, %size, 0);
	deleteObject(%set);

	// If it's on concrete, the seed dies
	if (%interiorNum > 0) {
		// Delete the seed
		deleteObject(%this);
		return;
	}

	// Randomly plant some vegetation in it's place
	%plant = floor(getRandom() * 90);

	if (%plant < 10) {
			%obj = newObject("", "StaticShape", Cactus1, true);
	}
	else if (%plant < 20) {
			%obj = newObject("", "StaticShape", Cactus2, true);
	}
	else if (%plant < 30) {
			%obj = newObject("", "StaticShape", Cactus3, true);
	}
	else if (%plant < 45) {
			%obj = newObject("", "StaticShape", TreeShape, true);
	}
	else if (%plant < 60) {
			%obj = newObject("", "StaticShape", TreeShapeTwo, true);
	}
	else {
		%obj = newObject("", "StaticShape", PlantTwo, true);
	}

	// Delete the seed
	deleteObject(%this);

 	addToSet("MissionCleanup", %obj);

	// Tweak position and set it
	%posX = getWord(%pos, 0);
	%posY = getWord(%pos, 1);
	%posZ = getWord(%pos, 2);
	%posZ -= 0.25;
	%pos = %posX @" "@ %posY @" "@ %posZ;
	GameBase::setPosition(%obj, %pos);
	return;
}

function SeedPack::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "The Seed Pack is used to plant vegetation quickly.");
	}
}

// This is a MiniMod Plugin.
// This plugin is the Flag Decoy Pack from the Orion mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    FlagDecoyPack.ArmorData.cs
//    FlagDecoyPack.item.cs
//    FlagDecoyPack.station.cs
//
// to your MiniMod/plugins directory.

ItemImageData FakeFlagImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 5;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData FakeFlag
{
        description = "Flag Decoy Pack";
	shapeFile = "flag";
        imageType = FakeFlagImage;
	className = "Backpack";
        heading = "cBackpacks";
        showInventory = true;
	shadowDetailMask = 4;
        price = 75;

	lightType = 2;   // Pulsing
	lightRadius = 5;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

function FakeFlag::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

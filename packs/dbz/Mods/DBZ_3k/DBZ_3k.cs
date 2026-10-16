// DBZ_3k (Dragon Ball Z weapons mod, December 2000, author not named in the archive)
// Modern Tribes (1.50) port, entry script.
//
// Original install (README!.txt): "Unzip all files into a directory in your tribes directory
// called DBZ_3k ... C:/dynamix/tribes/Tribes -mod DBZ_3k". The mod is five replacement scripts
// (ArmorData, baseExpData, baseProjData, item, station); everything else is the game's own.

// item.cs calls AddWeapon(HyperB); and AddWeapon(EnBeam); at load. No file of the mod defines
// it, and the weapon ring is filled by hand ($NextWeapon[] in item.cs), so it does nothing here;
// defined only so each server start does not log two "Unknown command" lines.
function AddWeapon(%weapon)
{
}

echo("DBZ_3k (1.50 port) loaded.");

// This is a MiniMod Plugin.
// This plugin is the Plasma Cannon from the Redneck Slag Pack.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    PlasmaCannon.ArmorData.cs
//    PlasmaCannon.baseProjData.cs
//    PlasmaCannon.item.cs
//    PlasmaCannon.station.cs
//
// to your MiniMod/plugins directory.

$AutoUse[PlasmaCannon] = True;

addPluginWeapon(Mortar, PlasmaCannon);
// Use the above line instead of all the $NextWeapon/$PrevWeapon garbage.
//
// Infact, DO NOT ENTER ANY $NextWeapon/$PrevWeapon variables they WILL cause conflicts!!!
//
// Note: "Mortar" is used to tell MiniMod what weapon the plugin will be loaded after,
//	 and before the next base weapon.(MiniMod opens a slot for plugins to fit between weapons. :)
//
// It does not need to be changed to avoid conficts. Its just there for you to set as a prefference.
//
// If you alter "Mortar" with something else, please only change it with other Base Weapons,
//	 for compatiblity's sake.

ItemImageData PlasmaCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = PlasmaCannonBlast;
	accuFire = True;
	reloadTime = 0.5;
	fireTime = 0.2;
	minEnergy = 15;
	maxEnergy = 50;
	
	lightType = 3; // Weapon Fire
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0, 0, 1 };

	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundGeneratorPower;
};

ItemData PlasmaCannon
{
	description = "Plasma Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaCannonImage;
	price = 250;
	showWeaponBar = true;
};

function PlasmaCannon::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Energy Pack to use Plasma Cannon."); 
}


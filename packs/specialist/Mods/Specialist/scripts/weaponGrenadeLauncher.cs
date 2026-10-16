$InvList[GrenadeLauncher] = 1;
$InvList[GrenadeAmmo] = 1;
$RemoteInvList[GrenadeLauncher] = 1;
$RemoteInvList[GrenadeAmmo] = 1;

$AutoUse[GrenadeLauncher] = True;
$SellAmmo[GrenadeAmmo] = 5;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;

ItemData GrenadeAmmo
{
	description = "Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	projectileType = GrenadeShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GrenadeLauncher
{
	description = "Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
	// === Added in Base v1.11 ===
	validateShape = true;
	// ===========================

};

function GrenadeLauncher::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "The grenade launcher is useful for firing at targets around corners.");
	}
}

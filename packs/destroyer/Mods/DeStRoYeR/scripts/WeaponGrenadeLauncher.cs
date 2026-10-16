//--------------------------------------

$AutoUse[GrenadeLauncher] = True;
$SellAmmo[GrenadeAmmo] = 5;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackItems[4] = GrenadeAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;

//--------------------------------------

$InvList[GrenadeLauncher] = 1;
$InvList[GrenadeAmmo] = 1;
$RemoteInvList[GrenadeLauncher] = 1;
$RemoteInvList[GrenadeAmmo] = 1;

$ItemMax[narmor, GrenadeLauncher] = 0;
$ItemMax[aarmor, GrenadeLauncher] = 1;
$ItemMax[darmor, GrenadeLauncher] = 1;
$ItemMax[nfemale, GrenadeLauncher] = 0;
$ItemMax[afemale, GrenadeLauncher] = 1;
$ItemMax[warmor, GrenadeLauncher] = 1;
$ItemMax[barmor, GrenadeLauncher] = 1;
$ItemMax[sarmor, GrenadeLauncher] = 1;
$ItemMax[avarmor, GrenadeLauncher] = 1;
$ItemMax[wfemale, GrenadeLauncher] = 1;
$ItemMax[bfemale, GrenadeLauncher] = 1;

$ItemMax[narmor, GrenadeAmmo] = 0;
$ItemMax[aarmor, GrenadeAmmo] = 10;
$ItemMax[darmor, GrenadeAmmo] = 30;
$ItemMax[nfemale, GrenadeAmmo] = 0;
$ItemMax[afemale, GrenadeAmmo] = 10;
$ItemMax[warmor, GrenadeAmmo] = 15;
$ItemMax[barmor, GrenadeAmmo] = 20;
$ItemMax[sarmor, GrenadeAmmo] = 500;
$ItemMax[avarmor, GrenadeAmmo] = 25;
$ItemMax[wfemale, GrenadeAmmo] = 15;
$ItemMax[bfemale, GrenadeAmmo] = 20;

//--------------------------------------

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
   heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function GrenadeLauncher::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Grenade Launcher: <f2>fires grenades faster and farther than you can.");
}
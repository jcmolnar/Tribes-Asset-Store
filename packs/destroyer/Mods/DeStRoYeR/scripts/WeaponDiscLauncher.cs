//--------------------------------------

$AutoUse[DiscLauncher] = True;
$SellAmmo[DiscAmmo] = 5;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackItems[1] = DiscAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;

//--------------------------------------

$InvList[Disclauncher] = 1;
$InvList[DiscAmmo] = 1;
$RemoteInvList[Disclauncher] = 1;
$RemoteInvList[DiscAmmo] = 1;

$ItemMax[narmor, Disclauncher] = 0;
$ItemMax[aarmor, Disclauncher] = 1;
$ItemMax[darmor, Disclauncher] = 1;
$ItemMax[nfemale, Disclauncher] = 0;
$ItemMax[afemale, Disclauncher] = 1;
$ItemMax[warmor, Disclauncher] = 1;
$ItemMax[barmor, Disclauncher] = 1;
$ItemMax[sarmor, Disclauncher] = 1;
$ItemMax[avarmor, Disclauncher] = 1;
$ItemMax[wfemale, Disclauncher] = 1;
$ItemMax[bfemale, Disclauncher] = 1;

$ItemMax[narmor, DiscAmmo] = 0;
$ItemMax[aarmor, DiscAmmo] = 10;
$ItemMax[darmor, DiscAmmo] = 30;
$ItemMax[nfemale, DiscAmmo] = 0;
$ItemMax[afemale, DiscAmmo] = 10;
$ItemMax[warmor, DiscAmmo] = 15;
$ItemMax[barmor, DiscAmmo] = 20;
$ItemMax[sarmor, DiscAmmo] = 500;
$ItemMax[avarmor, DiscAmmo] = 25;
$ItemMax[wfemale, DiscAmmo] = 15;
$ItemMax[bfemale, DiscAmmo] = 20;

//--------------------------------------

ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = DiscShell;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.5;
	spinUpTime = 0.0;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher
{
	description = "Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

//--------------------------------------
function DiscLauncher::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Disc Launcher: <f2>Your Standard Disc Launcher/Stromhammer/Spinfusor.");
}

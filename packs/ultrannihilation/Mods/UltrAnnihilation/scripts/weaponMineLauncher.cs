$InvList[MineLauncher] = 1;
$MobileInvList[MineLauncher] = 1;
$RemoteInvList[MineLauncher] = 1;

$InvList[MineLauncherAmmo] = 1;
$MobileInvList[MineLauncherAmmo] = 1;
$RemoteInvList[MineLauncherAmmo] = 1;

$SellAmmo[MineLauncherAmmo] = 5;
$WeaponAmmo[MineLauncher] = MineLauncherAmmo;

addWeapon(MineLauncher);
addAmmo(MineLauncher, MineLauncherAmmo, 2);

$AutoUse[MineLauncher] = True;

ItemData MineLauncherAmmo
{	description = "Mine Launcher Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData MineLauncherImage
{	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = MineLauncherAmmo;
	projectileType = MineShell; 
	accuFire = false;
	reloadTime = 0.05;
	fireTime = 0.05;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MineLauncher
{	description = "Mine Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = MineLauncherImage;
	price = 175;
	showWeaponBar = true;
};

function MineLauncher::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Mine Launcher: <f2>Just click fire to create picture perfect mine fields.");
}
$InvList[LDisclauncher] = 1;
$RemoteInvList[LDisclauncher] = 1;
$InvList[Disclauncher] = 1;
$RemoteInvList[Disclauncher] = 1;
$InvList[HDisclauncher] = 1;
$RemoteInvList[HDisclauncher] = 1;

addWeapon(LDiscLauncher);
addWeapon(DiscLauncher);
addWeapon(HDiscLauncher);

$AutoUse[LDiscLauncher] = True;
$AutoUse[DiscLauncher] = True;
$AutoUse[HDiscLauncher] = True;

ItemImageData LDiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;
	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = WormMK0;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 1.0;
	spinUpTime = 0.2;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData LDiscLauncher
{
	description = "Solburn Mk1";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = LDiscLauncherImage;
	price = 100;
	showWeaponBar = true;
};
ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;
	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = WormMK1;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 1.0;
	spinUpTime = 0.2;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher
{
	description = "Solburn Mk2";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

ItemImageData HDiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;
	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = WormMK2;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 1.0;
	spinUpTime = 0.2;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData HDiscLauncher
{
	description = "Solburn Mk3";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = HDiscLauncherImage;
	price = 200;
	showWeaponBar = true;
};
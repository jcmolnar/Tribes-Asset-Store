$InvList[LGrenadeLauncher] = 1;
$RemoteInvList[LGrenadeLauncher] = 1;
$InvList[GrenadeLauncher] = 1;
$RemoteInvList[GrenadeLauncher] = 1;
$InvList[HGrenadeLauncher] = 1;
$RemoteInvList[HGrenadeLauncher] = 1;

addWeapon(LGrenadeLauncher);
addWeapon(GrenadeLauncher);
addWeapon(HGrenadeLauncher);

$AutoUse[LGrenadeLauncher] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[HGrenadeLauncher] = True;

ItemImageData LGrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	projectileType = ConfuseMK0;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;
	lightType = 3;// Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData LGrenadeLauncher
{
	description = "Confuse Mk1";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = LGrenadeLauncherImage;
	price = 100;
	showWeaponBar = true;
};

ItemImageData GrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	projectileType = ConfuseMK1;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;
	lightType = 3;// Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GrenadeLauncher
{
	description = "Confuse Mk2";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
};

ItemImageData HGrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	projectileType = ConfuseMK2;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;
	lightType = 3;// Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData HGrenadeLauncher
{
	description = "Confuse Mk3";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = HGrenadeLauncherImage;
	price = 200;
	showWeaponBar = true;
};
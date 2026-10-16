$InvList[LaserRifle] = 1;
$RemoteInvList[LaserRifle] = 1;
$InvList[HLaserRifle] = 1;
$RemoteInvList[HLaserRifle] = 1;

addWeapon(LaserRifle);
addWeapon(HLaserRifle);

$AutoUse[LaserRifle] = True;
$AutoUse[HLaserRifle] = True;

ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = LaserAmmo;
	projectileType = VampireMK1;
	accuFire = true;
	reloadTime = 2.5;
	fireTime = 0.5;
	lightType = 3;// Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "Vampire Mk1";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 150;
	showWeaponBar = true;
};

ItemImageData HLaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = LaserAmmo;
	projectileType = VampireMK2;
	accuFire = true;
	reloadTime = 2.5;
	fireTime = 0.5;
	lightType = 3;// Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HLaserRifle
{
	description = "Vampire Mk2";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = HLaserRifleImage;
	price = 200;
	showWeaponBar = true;
};
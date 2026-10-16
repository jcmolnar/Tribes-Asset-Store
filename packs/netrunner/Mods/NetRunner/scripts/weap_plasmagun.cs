$InvList[PlasmaGun] = 1;
$RemoteInvList[PlasmaGun] = 1;

addWeapon(PlasmaGun);

$AutoUse[PlasmaGun] = True;

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	projectileType = Decrypt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	lightType = 3;// Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{
	description = "Decrypt Mk1";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 150;
	showWeaponBar = true;
};

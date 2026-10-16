$InvList[Blaster] = 1;
$RemoteInvList[Blaster] = 1;

addWeapon(Blaster);

$AutoUse[Blaster] = True;

ItemImageData BlasterImage
{
	shapeFile= "energygun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = BlasterAmmo;
	projectileType = Subvert;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.5;
	lightType = 3;// Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
	heading = $InvHead[iOffe];
	description = "Subvert Mk1";
	className = "Weapon";
	shapeFile= "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 150;
	showWeaponBar = true;
};

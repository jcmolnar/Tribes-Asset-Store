$InvList[Mortar] = 1;
$RemoteInvList[Mortar] = 1;

addWeapon(Mortar);

$AutoUse[Mortar] = True;

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	projectileType = ExpelMK1;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 1.0;
	lightType = 3;// Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Mortar
{
	description = "Expel Mk1";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 200;
	showWeaponBar = true;
};

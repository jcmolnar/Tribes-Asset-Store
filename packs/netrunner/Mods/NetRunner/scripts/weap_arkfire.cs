$InvList[Arkfire] = 1;
$InvList[Arkfire2] = 1;
$RemoteInvList[Arkfire] = 1;
$RemoteInvList[Arkfire2] = 1;

addWeapon(Arkfire);
addWeapon(Arkfire2);

$AutoUse[Arkfire] = True;
$AutoUse[Arkfire2] = True;

ItemImageData ArkfireImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = ArkfireAmmo;
	projectileType = ArkfireMK1;
	accuFire = true;
	reloadTime = 4.0;
	fireTime = 4.0;
	lightType = 3;// Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Arkfire
{
	description = "Arkfire Mk1";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = ArkfireImage;
	price = 200;
	showWeaponBar = true;
};

ItemImageData ArkfireImage2
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = ArkfireAmmo;
	projectileType = ArkfireMK2;
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

ItemData Arkfire2
{
	description = "Arkfire Mk2";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = ArkfireImage2;
	price = 200;
	showWeaponBar = true;
};
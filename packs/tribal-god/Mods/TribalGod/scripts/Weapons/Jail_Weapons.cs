//==========================================================================================
ItemImageData JailGunImage {
	shapeFile   = "shotgun";
	mountPoint  = 0;
	weaponType  = 2;
	projectileType = jailbolt;
	minEnergy   = 3;
	maxEnergy   = 11;
	reloadTime  = 0.25;
	lightType   = 3;
	lightRadius = 2;
	lightTime   = 1;
	lightColor  = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundELFIdle;
};
ItemData JailGun {
	heading     = $InvHeading[EnergyWeapons];
	description = "Jail Gun";
	className   = "Weapon";
	shapeFile   = "repairgun";
	shadowDetailMask = 4;
	imageType   = JailGunImage;
	price       = 385;
	showWeaponBar = true;
};
function JailGun::onUse(%player,%item){ Weapon::onUse(%player,%item); }
//------------------------------------------------------------------------------------------

ItemImageData JailRifleImage {
	shapeFile = "sniper";
	mountPoint = 0;
	minEnergy = 10;
	maxEnergy = 0.01;
	weaponType = 0;
	projectileType = JailDart;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.15;
	sfxFire = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
	
};
ItemData JailRifle {
	description = "Jail Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
	heading = $InvHeading[BulletWeapons];
	shadowDetailMask = 4;
	imageType = JailRifleImage;
	price = 375;
	showWeaponBar = true;
	validateShape = false;
	validateMaterials = false;
};
function JailRifle::onUse(%player,%item){ Weapon::onUse(%player,%item); }
//==========================================================================================
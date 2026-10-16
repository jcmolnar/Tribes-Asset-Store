createWeapon(PlasmaGun, PlasmaAmmo, 1, 1, false, 5, 1, 1, 1, 30, 40, 50);
addWeapon(PlasmaGun);

AmmoPack::addAmmo(PlasmaAmmo, 30);

ItemData PlasmaAmmo {
	description = "Plasma Bolt";
	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};
ItemImageData PlasmaGunImage {
	shapeFile = "plasma";
	mountPoint = 0;
	weaponType = 0;
	ammoType = PlasmaAmmo;
	projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};
ItemData PlasmaGun {
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
	validateShape = true;
};
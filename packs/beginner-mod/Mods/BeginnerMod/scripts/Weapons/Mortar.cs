createWeapon(Mortar, MortarAmmo, 1, 1, false, 5, 0, 0, 1, 0, 0, 10);
addWeapon(Mortar);

AmmoPack::addAmmo(MortarAmmo, 10);

ItemData MortarAmmo {
	description = "Mortar Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};
ItemImageData MortarImage {
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = MortarAmmo;
	projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};
ItemData Mortar {
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 375;
	showWeaponBar = true;
	validateShape = true;
};
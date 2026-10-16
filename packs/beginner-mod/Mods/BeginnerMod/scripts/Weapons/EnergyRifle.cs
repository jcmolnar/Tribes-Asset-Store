createWeapon(EnergyRifle, "", 1, 1, false, "", 1, 1, 1);
addWeapon(EnergyRifle);

ItemImageData EnergyRifleImage {
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = lightningCharge;
	minEnergy = 3;
	maxEnergy = 11;
	reloadTime = 0.2;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundELFIdle;
};
ItemData EnergyRifle {
	description = "ELF Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = EnergyRifleImage;
	showWeaponBar = true;
	price = 125;
	validateShape = true;
};
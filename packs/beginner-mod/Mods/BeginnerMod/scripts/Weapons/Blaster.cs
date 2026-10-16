
// NOTICE:
// createWeapon function is called quite a bit differently for energy weapons, refer to
// Special_Functs.cs for explanations on the arguments called here.
createWeapon(Blaster,"",1,1,false,"",1,1,1);
            
addWeapon(Blaster);

ItemImageData BlasterImage {
	shapeFile  = "energygun";
	mountPoint = 0;
	weaponType = 0;// 0 = Single Shot | 2 = Sustained Fire
	reloadTime = 0;
	fireTime = 0.3;
	minEnergy = 5;
	maxEnergy = 6;
	projectileType = BlasterBolt;
	accuFire = true;
	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};
ItemData Blaster {
	heading = "bWeapons";
	description = "Blaster";
	className = "Weapon";
	shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 85;
	showWeaponBar = true;
};
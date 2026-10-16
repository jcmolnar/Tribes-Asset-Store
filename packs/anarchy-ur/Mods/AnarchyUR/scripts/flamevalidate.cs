//flamevalidate.cs - Validates flames on armors
//Needed so dts's arent used on players 


ItemImageData Lflameimage
{
        shapeFile = "lflame";
        mountPoint = 0;

        weaponType = 2; // Sustained
        projectileType = LeaveThisAlone;
        accuFire = true;
        minEnergy = 1;
        maxEnergy = 2;
        reloadTime = 0.1;

        lightType   = 3;  // Weapon Fire
        lightRadius = 1;
        lightTime   = 1;
        lightColor  = { 0.25, 1, 0.25 };

        sfxFire     = SoundFireTargetingLaser;
        sfxActivate = SoundPickUpWeapon;
};

ItemData lflame
{
        description   = "lflame";
        className     = "Tool";
        shapeFile     = "lflame";
        hudIcon       = "targetlaser";
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType     = lflameImage;
        price         = 50;
        showWeaponBar = false;
		validateShape = true;
};

ItemImageData mflameimage
{
        shapeFile = "mflame";
        mountPoint = 0;

        weaponType = 2; // Sustained
        projectileType = LeaveThisAlone;
        accuFire = true;
        minEnergy = 1;
        maxEnergy = 2;
        reloadTime = 0.1;

        lightType   = 3;  // Weapon Fire
        lightRadius = 1;
        lightTime   = 1;
        lightColor  = { 0.25, 1, 0.25 };

        sfxFire     = SoundFireTargetingLaser;
        sfxActivate = SoundPickUpWeapon;
};

ItemData mflame
{
        description   = "mflame";
        className     = "Tool";
        shapeFile     = "mflame";
        hudIcon       = "targetlaser";
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType     = mflameImage;
        price         = 50;
        showWeaponBar = false;
		validateShape = true;
};

ItemImageData hflameimage
{
        shapeFile = "hflame";
        mountPoint = 0;

        weaponType = 2; // Sustained
        projectileType = LeaveThisAlone;
        accuFire = true;
        minEnergy = 1;
        maxEnergy = 2;
        reloadTime = 0.1;

        lightType   = 3;  // Weapon Fire
        lightRadius = 1;
        lightTime   = 1;
        lightColor  = { 0.25, 1, 0.25 };

        sfxFire     = SoundFireTargetingLaser;
        sfxActivate = SoundPickUpWeapon;
};

ItemData hflame
{
        description   = "hflame";
        className     = "Tool";
        shapeFile     = "hflame";
        hudIcon       = "targetlaser";
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType     = hflameImage;
        price         = 50;
        showWeaponBar = false;
		validateShape = true;
};


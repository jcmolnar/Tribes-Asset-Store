//================================================================
// Torque 
//================================================================

SoundData SoundFireTorque
{
   wavFileName = "turretfire4.wav";
   profile = Profile3dNear;
};

SoundData SoundTorqueReload
{
   wavFileName = "mortar_reload.wav";
   profile = Profile3dNearLoop;
};

SoundData ExplosionTorque
{
   wavFileName = "shieldhit.wav";
   profile = Profile3dFar;
};

//================================================================

//================================================================


//================================================================

ItemImageData TorqueImage 
{ 
        shapeFile = "mortargun";
        mountPoint = 0;
	mountoffset = { 0, 0, -0.2 };
        mountrotation = { 0, 3, 0 };
        weaponType = 0;
        //ammoType = TorqueAmmo;
        projectileType = TribesShell;
        accuFire = true;
	reloadTime = 0.04;
	fireTime = 0.04;
	minEnergy = 1;
	maxEnergy = 0.1;

        //lightType = 3;
        //lightRadius = 3;
        //lightTime = 1;
        //lightColor = { 0.4, 0, 0.6 };
	sfxFire = SoundFireTorque;
	sfxActivate = SoundPickUpWeapon;
	//sfxReload = SoundTorqueReload;
};

ItemData Torque
{ 
        description = "Torque Cannon";
        className = "Weapon";
        shapeFile = "mortargun";
        hudIcon = "plasma";
        heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = TorqueImage;
        price = 100;
        //showWeaponBar = true;
};


ItemImageData TribesArmImage 
{ 
        shapeFile = "mortargun";
        mountPoint = 0;
	mountoffset = { 0, 0, -0.2 };
        mountrotation = { 0, 3, 0 };
        weaponType = 0;
        //ammoType = TorqueAmmo;
        projectileType = TribesShell;
        accuFire = true;
	reloadTime = 0.04;
	fireTime = 0.04;
	minEnergy = 1;
	maxEnergy = 0.1;

        //lightType = 3;
        //lightRadius = 3;
        //lightTime = 1;
        //lightColor = { 0.4, 0, 0.6 };
	sfxFire = SoundFireTorque;
	sfxActivate = SoundPickUpWeapon;
	//sfxReload = SoundTorqueReload;
};

ItemData TribesArm
{ 
        description = "phase shifter";
        className = "Weapon";
        shapeFile = "mortargun";
        hudIcon = "plasma";
        heading = "TWeapons";
        shadowDetailMask = 4;
        imageType = TorqueImage;
        price = 100;
        //showWeaponBar = true;
};

//=================================================================
echo("Item Loaded");
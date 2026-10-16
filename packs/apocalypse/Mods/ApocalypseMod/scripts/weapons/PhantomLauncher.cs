//--------------------------------------

addAmmo(PhantomLauncher,PhantomAmmo,5,15);

addToInv(PhantomLauncher,1,1);
addToInv(PhantomAmmo,1,1);

setArmorItemMax(PhantomLauncher,1,1,1,1,0,0,0, 1, 0,0,0,0);
setArmorItemMax(PhantomAmmo,20,15,15,15,15,15,15, 99, 0,0,0,0);

//--------------------------------------
BulletData PhantomBullet
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = rocketExp;

   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $PhantomDamageType;
   explosionradius    = 7.5;

   muzzleVelocity     = 115.0;
   totalTime          = 6.5;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = False;
};

//----------------------------------------------------------------------------

ItemData PhantomAmmo
{
        description = "Phantoms";
        className = "Ammo";
        shapeFile = "rsmoke";
   heading = $InvCatAmmo;
        shadowDetailMask = 4;
        price = 2;
};

ItemImageData PhantomLauncherImage
{
        shapeFile = "rsmoke";
        mountPoint = 0;

        weaponType = 3; // PhantomLauncher
        ammoType = PhantomAmmo;
        projectileType = PhantomBullet;
        accuFire = true;
        reloadTime = 0.25;
        fireTime = 1.25;
        spinUpTime = 0.25;

        sfxFire = SoundFireDisc;
        sfxActivate = SoundPickUpWeapon;
        sfxReload = SoundDryFire;
};

ItemData PhantomLauncher
{
        description = "Phantom Gun";
        className = "Weapon";
        shapeFile = "rsmoke";
        hudIcon = "fear";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = PhantomLauncherImage;
        price = 350;
        showWeaponBar = true;
};

$MountMSG[PhantomLauncher] = "<JC><F2>Phantoms Gun <F0>- <F1>Fires an invisible rocket your enemies won't know what hit them.";

AddWeapon(PhantomLauncher);

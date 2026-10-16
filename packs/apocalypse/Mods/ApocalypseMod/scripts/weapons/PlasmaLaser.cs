//--------------------------------------

$AutoUse[PlasmaLaser] = True;
$WeaponAmmo[PlasmaLaser] = "";

addToInv(PlasmaLaser,1,1);

setArmorItemMax(PlasmaLaser,1,1,1,1,1,1,1, 1, 0,0,0,0);

//--------------------------------------

LaserData plasLaser
{
   laserBitmapName   = "plasmabolt.bmp";
   hitName           = "plasmatrail.dts";

   damageConversion  = 0.0225;
   baseDamageType    = $PlasmaDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//--------------------------------------

ItemImageData PlasmaLaserImage
{
        shapeFile = "plasma";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        projectileType = plasLaser;
        accuFire = true;
        reloadTime = 0.1;
        fireTime = 0.5;
        minEnergy = 5;
        maxEnergy = 20;

        lightType = 3;  // Weapon Fire
        lightRadius = 2;
        lightTime = 1;
        lightColor = { 1, 0, 0 };

        sfxFire = SoundFireLaser;
        sfxActivate = SoundPickUpWeapon;
};

ItemData PlasmaLaser
{
        description = "Plasma Laser";
        className = "Weapon";
        shapeFile = "plasma";
        hudIcon = "sniper";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = PlasmaLaserImage;
        price = 100;
        showWeaponBar = true;
};

$MountMSG[PlasmaLaser] = "<JC><F2>Plasma Laser <F0>- <F1>Fires a concetrated beam of plasma energy.";

AddWeapon(PlasmaLaser);

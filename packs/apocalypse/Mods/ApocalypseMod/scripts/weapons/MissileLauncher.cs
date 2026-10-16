//--------------------------------------

$AutoUse[MissileLauncher] = True;
addAmmo(MissileLauncher,MissileAmmo,5,6);

addToInv(MissileLauncher,1,1);
addToInv(MissileAmmo,1,1);

setArmorItemMax(Missilelauncher,0,0,0,0,1,1,1, 1, 0,0,0,0);
setArmorItemMax(MissileAmmo,6,6,6,6,6,8,10, 99, 0,0,0,0);

//--------------------------------------
RocketData MissileShell
{
   bulletShapeName = "rocket.dts";
   explosionTag    = mortarExp;

   collisionRadius = 0.0;
   mass            = 5.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.8;
   damageType       = $MissileDamageType;

   explosionRadius  = 20.0;
   kickBackStrength = 250.0;

   muzzleVelocity   = 60.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//----------------------------------------------------------------------------

ItemData MissileAmmo
{
        description = "Missiles";
        className = "Ammo";
        shapeFile = "rocket";
   heading = $InvCatAmmo;
        shadowDetailMask = 4;
        price = 6;
};

ItemImageData MissileLauncherImage
{
        shapeFile = "mortargun";
        mountPoint = 0;

        weaponType = 3; // DiscLauncher
        ammoType = MissileAmmo;
        projectileType = MissileShell;
        accuFire = true;
        reloadTime = 0.5;
        fireTime = 2.0;

        sfxFire = bigExplosion1;
        sfxActivate = SoundPickUpWeapon;
        sfxReload = SoundMortarReload;
        sfxReady = SoundMissileTurretOn;
};

ItemData MissileLauncher
{
        description = "Missile Launcher";
        className = "Weapon";
        shapeFile = "mortargun";
        hudIcon = "ammopack";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = MissileLauncherImage;
        price = 375;
        showWeaponBar = true;
};

$MountMSG[MissileLauncher] = "<JC><F2>Missile Launcher <F0>- <F1>Launches a high powered missile.";

AddWeapon(MissileLauncher);

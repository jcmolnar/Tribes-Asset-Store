//--------------------------------------

$AutoUse[Poisongun] = True;
addAmmo(Poisongun,PoisonAmmo,6,6);

addToInv(Poisongun,1,1);
addToInv(PoisonAmmo,1,1);

setArmorItemMax(Poisongun,1,1,0,0,0,0,0, 1, 0,0,0,0);
setArmorItemMax(PoisonAmmo,12,8,8,8,8,8,8, 99, 0,0,0,0);

//--------------------------------------
BulletData PoisonBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = poisonExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $PoisonDamageType;

   muzzleVelocity     = 800.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 0.25;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//----------------------------------------------------------------------------

ItemData PoisonAmmo
{
        description = "Poison Dart";
   heading = $InvCatAmmo;
        className = "Ammo";
        shapeFile = "force";
        shadowDetailMask = 4;
        price = 6;
   validateShape = true;
};

ItemImageData PoisongunImage
{
        shapeFile = "sniper";
        mountPoint = 0;
        mountRotation = { 0,3.14, 0 };

        weaponType = 0; // Single Shot
        ammoType = PoisonAmmo;
        projectileType = PoisonBullet;
        accuFire = true;
        reloadTime = 1.0;
        fireTime = 0.1;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 1, 1, 0.2 };

        sfxFire = ricochet2;
        sfxActivate = SoundPickUpWeapon;
        sfxReady = SoundDryFire;
};

ItemData Poisongun
{
        description = "Poison Dart Gun";
        className = "Weapon";
        shapeFile = "sniper";
        hudIcon = "sniper";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = PoisongunImage;
        price = 300;
        showWeaponBar = true;
};

$MountMSG[Poisongun] = "<JC><F2>Poison Dart Gun <F0>- <F1>Fires a dart at high velocity that poisons the target.";

AddWeapon(Poisongun);

//--------------------------------------

$AutoUse[Assassingun] = True;
addAmmo(Assassingun,AssassinAmmo,5,5);

addToInv(Assassingun,1,1);
addToInv(AssassinAmmo,1,1);

setArmorItemMax(Assassingun,1,1,0,0,0,0,0, 1, 0,0,0,0);
setArmorItemMax(AssassinAmmo,10,5,5,5,5,5,5, 99, 0,0,0,0);

//--------------------------------------
BulletData SniperBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $SniperDamageType;

   muzzleVelocity     = 3000.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 0.25;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//----------------------------------------------------------------------------

ItemData AssassinAmmo
{
        description = "Assassin Bullet";
   heading = $InvCatAmmo;
        className = "Ammo";
        shapeFile = "ammo2";
        shadowDetailMask = 4;
        price = 6;
};

ItemImageData AssassingunImage
{
        shapeFile = "sniper";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        ammoType = AssassinAmmo;
        projectileType = SniperBullet;
        accuFire = true;
        reloadTime = 0.5;
        fireTime = 2.0;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 1, 1, 0.2 };

        sfxFire = SoundFireMortar;
        sfxActivate = SoundPickUpWeapon;
        sfxReady = SoundDryFire;
};

ItemData Assassingun
{
        description = "Assassin Rifle";
        className = "Weapon";
        shapeFile = "sniper";
        hudIcon = "sniper";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = AssassingunImage;
        price = 250;
        showWeaponBar = true;
};

$MountMSG[Assassingun] = "<JC><F2>Assassin Rifle <F0>- <F1>Fires a fast and powerful bullet.";

AddWeapon(Assassingun);

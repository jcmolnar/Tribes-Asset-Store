//--------------------------------------

$AutoUse[SMachineGun] = True;
addAmmo(SMachineGun,SMachineGunAmmo,30,60);

addToInv(SMachineGun,1,1);
addToInv(SMachineGunAmmo,1,1);

setArmorItemMax(SMachineGun,1,0,0,0,0,0,0, 1, 0,0,0,0);
setArmorItemMax(SMachineGunAmmo,90,90,90,90,90,90,90, 99, 0,0,0,0);

//--------------------------------------
BulletData SMachinegunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.09;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0035;
   muzzleVelocity     = 325.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//----------------------------------------------------------------------------

ItemData SMachineGunAmmo
{
        description = "Sub Machine Gun Clip";
        className = "Ammo";
        shapeFile = "ammo2";
   heading = $InvCatAmmo;
        shadowDetailMask = 4;
        price = 1;
};

ItemImageData SMachineGunImage
{
        shapeFile = "plasma";
        mountPoint = 0;
        mountRotation = { 0,3.14, 0 };

        weaponType = 1; // Spinning
        reloadTime = 0.0;
        spinUpTime = 0.0;
        spinDownTime = 0.1;
        fireTime = 0.125;
        ammoType = SMachineGunAmmo;
//        projectileType = SMachinegunBullet;
        accuFire = true;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 1, 1, 0.2 };

        sfxFire = SoundFireChaingun;
        sfxActivate = SoundPickUpWeapon;
};

ItemData SMachineGun
{
        description = "Sub Machine Gun";
        className = "Weapon";
        shapeFile = "plasma";
        hudIcon = "weapon";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = SMachineGunImage;
        price = 95;
        showWeaponBar = true;
};

function SMachineGunImage::onFire(%player, %slot)
{
        %client = Player::getClient(%player);
        %ammo = Player::getItemCount(%player,SMachineGunAmmo);
        if(%ammo > 0) {
                %trans = getPerfectTrans(%player);
                %vel = Item::getVelocity(%player);
                Projectile::spawnProjectile(SMachinegunBullet,%trans,%player,%vel);
                Projectile::spawnProjectile(BulletShell,%trans,%player,%vel);
                Player::decItemCount(%player,SMachineGunAmmo,1);
        }
}

$MountMSG[SMachineGun] = "<JC><F2>Sub Machine Gun <F0>- <F1>Fast firing rate with small spread and low power.";

AddWeapon(SMachineGun);

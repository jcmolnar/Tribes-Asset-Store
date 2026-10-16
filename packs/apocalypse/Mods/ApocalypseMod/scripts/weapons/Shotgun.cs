$FireModes[Shotgun] = 4;
//--------------------------------------

addAmmo(Shotgun,ShotgunAmmo,5,15);

addToInv(Shotgun,1,1);
addToInv(ShotgunAmmo,1,1);

setArmorItemMax(Shotgun,1,1,1,1,1,1,1, 1, 0,0,0,0);
setArmorItemMax(ShotgunAmmo,15,15,15,20,20,25,30, 99, 0,0,0,0);

//--------------------------------------
BulletData FullChokeBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.06;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.009;
   muzzleVelocity     = 300.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
BulletData ImprovedChokeBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.075;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.011;
   muzzleVelocity     = 350.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
BulletData ModifiedChokeBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.09;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.013;
   muzzleVelocity     = 400.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
BulletData SkeetChokeBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.105;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.015;
   muzzleVelocity     = 450.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//----------------------------------------------------------------------------

ItemData ShotgunAmmo
{
        description = "Shotgun Shells";
        className = "Ammo";
        shapeFile = "ammo2";
   heading = $InvCatAmmo;
        shadowDetailMask = 4;
        price = 2;
};

ItemImageData ShotgunImage
{
        shapeFile = "shotgun";
        mountPoint = 0;

        weaponType = 0;
        ammoType = ShotgunAmmo;
        accuFire = true;
        reloadTime = 0.4;
        fireTime = 0.2;

        sfxFire = SoundFireMortar;
        sfxActivate = SoundPickUpWeapon;
        sfxReload = SoundDryFire;
};

ItemData Shotgun
{
        description = "Boom Stick";
        className = "Weapon";
        shapeFile = "shotgun";
        hudIcon = "ammopack";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = ShotgunImage;
        price = 150;
        showWeaponBar = true;
};

function ShotgunImage::onFire(%player, %slot)
{
        %client = Player::getClient(%player);
        %ammo = Player::getItemCount(%player,ShotgunAmmo);
        if(%ammo > 0) {
                %trans = getPerfectTrans(%player);
                %vel = Item::getVelocity(%player);
                for(%projnum = 8; %projnum > 0; %projnum--) {
                        if($WeapMode[%client,Shotgun] == 1 || $WeapMode[%client,Shotgun] < 1 || $WeapMode[%client,Shotgun] == "")
                                Projectile::spawnProjectile(FullChokeBullet,%trans,%player,%vel);
                        else if($WeapMode[%client,Shotgun] == 2)
                                Projectile::spawnProjectile(ImprovedChokeBullet,%trans,%player,%vel);
                        else if($WeapMode[%client,Shotgun] == 3)
                                Projectile::spawnProjectile(ModifiedChokeBullet,%trans,%player,%vel);
                        else if($WeapMode[%client,Shotgun] == 4 || $WeapMode[%client,Shotgun] > $FireModes[Shotgun])
                                Projectile::spawnProjectile(SkeetChokeBullet,%trans,%player,%vel);
                }
                Player::decItemCount(%player,ShotgunAmmo,1);
        }
}

$MountMSG[Shotgun] = "<JC><F2>Boom Stick <F0>- <F1>A Remington 12 guage shotgun w/ a walnut stock, cobalt blue steel, and a hair trigger.\n";
$MountMSG[Shotgun,1] = $MountMSG[Shotgun]@"<JC><F1>Equipped with full choke";
$MountMSG[Shotgun,2] = $MountMSG[Shotgun]@"<JC><F1>Equipped with improved choke";
$MountMSG[Shotgun,3] = $MountMSG[Shotgun]@"<JC><F1>Equipped with modified choke";
$MountMSG[Shotgun,4] = $MountMSG[Shotgun]@"<JC><F1>Equipped with skeet choke";

AddWeapon(Shotgun);

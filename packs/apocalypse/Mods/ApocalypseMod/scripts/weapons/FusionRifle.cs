//--------------------------------------

$AutoUse[FusionRifle] = True;
$WeaponAmmo[FusionRifle] = "";

addToInv(FusionRifle,1,1);

setArmorItemMax(FusionRifle,0,0,1,1,1,0,0, 1, 0,0,0,0);

//--------------------------------------
GrenadeData FusMalFuncBomb
{
   bulletShapeName    = "force.dts";
   explosionTag       = turretExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $FusMalFuncDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 1;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "fusionex.dts";
};

//--------------------------------------
BulletData FRifleBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = turretExp;

   damageClass        = 0;
   damageValue        = 0.175;
   damageType         = $FusionDamageType;

   muzzleVelocity     = 500.0;
   totalTime          = 2.0;
   liveTime           = 1.5;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//--------------------------------------
BulletData FRifleBolt2
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = turretExp;

   damageClass        = 0;
   damageValue        = 0.175;
   damageType         = $FusionDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 500.0;
   totalTime          = 2.0;
   liveTime           = 1.5;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//--------------------------------------

ItemImageData FusionRifle2Image
{
        shapeFile = "shotgun";
        mountPoint = 0;
        mountRotation = { 0, 1.57, 0 };

        weaponType = 0; // Single Shot
        projectileType = FRifleBolt;
        accuFire = true;
        reloadTime = 0.01;
        fireTime = 0.01;

        lightType = 3;  // Weapon Fire
        lightRadius = 2;
        lightTime = 1;
        lightColor = { 0.25, 0.25, 0.85 };

        sfxFire = SoundFireLaser;
};

ItemData FusionRifle2
{
        description = "Fusion Rifle";
        className = "Weapon";
        shapeFile = "shotgun";
        hudIcon = "plasma";
   heading = $InvCatWeapons[0];
        shadowDetailMask = 4;
        imageType = FusionRifle2Image;
        price = 275;
        showWeaponBar = false;
        showinventory = false;
};

ItemImageData FusionRifleImage
{
   shapeFile  = "breath";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        accuFire = true;
        reloadTime = 0.1;
        fireTime = 0.75;

        lightType = 3;  // Weapon Fire
        lightRadius = 2;
        lightTime = 1;
        lightColor = { 0.25, 0.25, 0.85 };

        sfxActivate = SoundPickUpWeapon;
};

ItemData FusionRifle
{
        description = "Fusion Rifle";
        className = "Weapon";
        shapeFile = "shotgun";
        hudIcon = "plasma";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = FusionRifleImage;
        price = 275;
        showWeaponBar = true;
};

function FusionRifleImage::onFire(%player, %slot)
{
        %rnd = floor(getRandom() * 100);
//        %trans = GameBase::getMuzzleTransform(%player);
        %trans = getPerfectTrans(%player);
        %vel = Item::getVelocity(%player);
        %energy = GameBase::getEnergy(%player);
        if(%energy < 12)
                return;
        %energy -= 17;
        if(%energy < 0)
                %energy = 0;
        GameBase::setEnergy(%player,%energy);
        if(%rnd > 94) {
                GameBase::PlaySound(%player, SoundPackFail, 2);
                Projectile::spawnProjectile("FusMalFuncBomb",%trans,%player,%vel);
                Player::unMountItem(%player,$WeaponSlot);
                Player::setItemCount(%player,FusionRifle,0);
                return;
        }
        else if(%rnd > 49)
                Projectile::spawnProjectile("FRifleBolt2",%trans,%player,%vel);
        Player::trigger(%player,$ExtraSlotA,true);
        Player::trigger(%player,$ExtraSlotA,false);
}

$MountMSG[FusionRifle] = "<JC><F2>Fusion Rifle <F0>- <F1>This weapon is a proto-type and has unknown effects.";

function FusionRifle::onMount(%player,%item)
{
        Player::mountItem(%player,FusionRifle2,$ExtraSlotA);
}

function FusionRifle::onUnMount(%player,%item)
{
        Player::unmountItem(%player,$ExtraSlotA);
}

AddWeapon(FusionRifle);

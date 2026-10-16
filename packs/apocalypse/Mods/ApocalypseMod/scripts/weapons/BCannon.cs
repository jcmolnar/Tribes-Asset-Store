//--------------------------------------

$AutoUse[BCannon] = True;
$Use[BCannon] = True;

addAmmo(BCannon,BlastAmmo,4,6);

addToInv(BCannon,1,1);
addToInv(BlastAmmo,1,1);

setArmorItemMax(BCannon,0,0,0,0,0,1,1, 1, 0,0,0,0);
setArmorItemMax(BlastAmmo,0,0,4,4,8,12,16, 99, 0,0,0,0);

//--------------------------------------

BulletData BCannonRocket
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = rocketExp;

   damageClass        = 0;
   damageValue        = 0.25;
   damageType         = $MissileDamageType;
   explosionradius    = 2.0;

   aimDeflection      = 0.003;
   muzzleVelocity     = 275.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };
   inheritedVelocityScale = 0.25;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------

ItemImageData BCannonImage2
{
   shapeFile  = "mortargun";
        mountPoint = 0;
        mountRotation = { 0, 1.57, 0 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        projectileType = BCannonRocket;
        accuFire = true;

        sfxFire = SoundFireBlaster;
        sfxActivate = SoundPickUpWeapon;
};

ItemData BCannon2
{
   heading = "bWeapons";
        description = "Blast Cannon";
        className = "Weapon";
   shapeFile  = "mortargun";
        hudIcon = "blaster";
        shadowDetailMask = 4;
        imageType = BCannonImage2;
        price = 0;
        showWeaponBar = false;
        showinventory = false;
};

//--------------------------------------

ItemImageData BCannonImage1
{
   shapeFile  = "mortargun";
        mountPoint = 0;
        mountRotation = { 0, -1.57, 0 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        projectileType = BCannonRocket;
        accuFire = true;

        sfxFire = SoundFireBlaster;
        sfxActivate = SoundPickUpWeapon;
};

ItemData BCannon1
{
   heading = "bWeapons";
        description = "Blast Cannon";
        className = "Weapon";
   shapeFile  = "mortargun";
        hudIcon = "blaster";
        shadowDetailMask = 4;
        imageType = BCannonImage1;
        price = 0;
        showWeaponBar = false;
        showinventory = false;
};

//--------------------------------------

ItemData BlastAmmo
{
        description = "Blast Rockets";
        className = "Ammo";
        heading = $InvCatAmmo;
        shapeFile = "rocket";
        shadowDetailMask = 4;
        price = 8;
};

ItemImageData BCannonImage
{
   shapeFile  = "breath";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        ammoType = BlastAmmo;
        reloadTime = 0;
        fireTime = 1.5;
        minEnergy = 0;
        maxEnergy = 0;

        accuFire = true;

};

ItemData BCannon
{
   heading = "bWeapons";
        description = "Blast Cannon";
        className = "Weapon";
   shapeFile  = "mortargun";
        hudIcon = "blaster";
        shadowDetailMask = 4;
        imageType = BCannonImage;
        price = 185;
        showWeaponBar = true;
};

//--------------------------------------

function BCannonImage::onFire(%player, %slot)
{
        if(Player::getItemCount(%player,$WeaponAmmo[BCannon])) {
                Player::decItemCount(%player,$WeaponAmmo[BCannon], 1);
                Player::trigger(%player,$ExtraSlotA,true);
                Player::trigger(%player,$ExtraSlotA,false);
        }
        if(Player::getItemCount(%player,$WeaponAmmo[BCannon])) {
                Player::decItemCount(%player,$WeaponAmmo[BCannon], 1);
                Player::trigger(%player,$ExtraSlotB,true);
                Player::trigger(%player,$ExtraSlotB,false);
        }
}

function BCannon::onMount(%player,%item)
{
        Player::mountItem(%player,BCannon1,$ExtraSlotA);
        Player::mountItem(%player,BCannon2,$ExtraSlotB);
}

function BCannon::onUnMount(%player,%item)
{
        Player::unmountItem(%player,$ExtraSlotA);
        Player::unmountItem(%player,$ExtraSlotB);
}

$MountMSG[BCannon] = "<JC><F2>Blast Cannon <F0>- <F1>Fires dual explosive rockets.";

AddWeapon(BCannon);

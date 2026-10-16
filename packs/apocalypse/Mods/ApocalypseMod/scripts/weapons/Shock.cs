//----------------------------------------------------------------------------

$WeaponAmmo[ShockGun] = ShockAmmo;

addToInv(ShockGun,1,1);

setArmorItemMax(ShockGun,1,1,1,1,1,1,1, 1, 0,0,0,0);
setArmorItemMax(ShockAmmo,0,0,0,0,0,0,0, 0, 0,0,0,0);

//--------------------------------------
RocketData ShockRocket
{
   bulletShapeName = "shield_large.dts";
   explosionTag    = LargeShockwave;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.01;
   damageType       = $ShockDamageType;

   explosionRadius  = 25.0;
   kickBackStrength = 150.0;

   muzzleVelocity   = 200.0;
   terminalVelocity = 300.0;
   acceleration     = 10.0;

   totalTime        = 2.5;
   liveTime         = 3.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "fusionex.dts";
   smokeDist   = 0.15;
};

//--------------------------------------

ItemData ShockAmmo
{
        description = "Shock";
        className = "Ammo";
        shapeFile = "discb";
   heading = $InvCatAmmo;
        shadowDetailMask = 4;
        price = 0;
};

//--------------------------------------

ItemImageData ShockGunImage
{
   shapeFile  = "mortargun";
        mountPoint = 0;

        weaponType = 0;
        ammoType = ShockAmmo;
        accuFire = true;
        reloadTime = 0.75;
        fireTime = 1.25;

        sfxActivate = SoundPickUpWeapon;
        sfxReady = SoundDiscSpin;
};

ItemData ShockGun
{
        description = "Shock Gun";
        shapeFile = "mortargun";
        className = "Weapon";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = ShockGunImage;
        hudIcon = "plasma";
        price = 500;
        showWeaponBar = true;
};

function ShockGun::onUse(%player,%item)
{
        %pack = Player::getMountedItem(%player,$BackpackSlot);
        if(%pack == ConverterPack || %pack == UltimaPack)
                Weapon::onUse(%player,%item);
        else
                Client::sendMessage(Player::getClient(%player),0,"Must have a Damage Converter to use Shock Gun.");
}

function ShockGunImage::onFire(%player,%slot)
{
        %client = Player::getClient(%player);
//        %trans = GameBase::getMuzzleTransform(%player);
        %trans = getPerfectTrans(%player);
        %vel = Item::getVelocity(%player);
        %delta = Player::getItemCount(%player, "ShockAmmo");
        %client.shockDamage = %delta;
        Player::decItemCount(%player, $WeaponAmmo[ShockGun], %delta);
        GameBase::PlaySound(%player, SoundPlasmaTurretFire, 2);
        Projectile::spawnProjectile("ShockRocket",%trans,%player,%vel);
}

$MountMSG[ShockGun] = "<JC><F2>Shock Gun <F0>- <F1>Fires a projectile with the power equal to the damage you have taken.";

AddWeapon(ShockGun);

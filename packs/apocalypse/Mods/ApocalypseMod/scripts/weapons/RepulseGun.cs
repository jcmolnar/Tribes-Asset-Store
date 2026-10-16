$FireModes[RepulseGun] = 2;
//--------------------------------------

addAmmo(RepulseGun,RepulseAmmo,5,10);

addToInv(RepulseGun,1,1);
addToInv(RepulseAmmo,1,1);

setArmorItemMax(RepulseGun,1,1,1,1,1,1,1, 1, 0,0,0,0);
setArmorItemMax(RepulseAmmo,20,20,20,15,15,10,10, 99, 0,0,0,0);

//--------------------------------------
RocketData StormRocket
{
   bulletShapeName = "shockwave_large.dts";
   explosionTag    = LargeShockwave;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.35;
   damageType       = $StormDamageType;

   explosionRadius  = 20.0;
   kickBackStrength = 400.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 150.0;
   acceleration     = 10;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 3.0;

   soundId = SoundWindGust;
};

//--------------------------------------
RocketData GravRocket
{
   bulletShapeName = "mortar.dts";
   explosionTag    = LargeShockwave;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.35;
   damageType       = $GravityDamageType;

   explosionRadius  = 20.0;
   kickBackStrength = -400.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 150.0;
   acceleration     = 10;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "enex.dts";
   smokeDist   = 3.0;

   soundId = SoundJetLight;
};

//----------------------------------------------------------------------------

ItemData RepulseAmmo
{
        description = "Force Shells";
        className = "Ammo";
        shapeFile = "ammo1";
   heading = $InvCatAmmo;
        shadowDetailMask = 4;
        price = 3;
};

ItemImageData RepulseGun2Image
{
        shapeFile = "mortarpack";
        mountPoint = 0;
        mountOffset = { 0.0, -0.2, 0.0 };
        mountRotation = { -1.57, 0.0, 0.0 };

        weaponType = 3; // DiscLauncher
        accuFire = true;
        reloadTime = 0.5;
        fireTime = 1.0;

};

ItemData RepulseGun2
{
        description = "Force Cannon";
        className = "Weapon";
        shapeFile = "mortarpack";
        hudIcon = "plasma";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = RepulseGun2Image;
        price = 300;
        showWeaponBar = false;
        showinventory = false;
};

ItemImageData RepulseGunImage
{
        shapeFile = "breath";
        mountPoint = 0;
        mountOffset = { 0.0, -0.2, 0.0 };

        weaponType = 3; // DiscLauncher
        ammoType = RepulseAmmo;
        accuFire = true;
        reloadTime = 0.5;
        fireTime = 1.0;

        sfxFire = SoundDryFire;
        sfxActivate = SoundPickUpWeapon;
        sfxReload = SoundMortarReload;
        sfxReady = SoundDiscSpin;
};

ItemData RepulseGun
{
        description = "Force Cannon";
        className = "Weapon";
        shapeFile = "mortarpack";
        hudIcon = "plasma";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = RepulseGunImage;
        price = 300;
        showWeaponBar = true;
};

function RepulseGunImage::onFire(%player, %slot)
{
        %client = Player::getClient(%player);
        %ammo = Player::getItemCount(%player,RepulseAmmo);
        if(%ammo > 0) {
                %trans = getPerfectTrans(%player);
                %vel = Item::getVelocity(%player);
                if($WeapMode[%client,RepulseGun] == 1 || $WeapMode[%client,RepulseGun] < 1  || $WeapMode[%client,RepulseGun] == "")
                        Projectile::spawnProjectile(StormRocket,%trans,%player,%vel);
                else if($WeapMode[%client,RepulseGun] >= $FireModes[RangerMortar])
                        Projectile::spawnProjectile(GravRocket,%trans,%player,%vel);
                Player::decItemCount(%player,RepulseAmmo,1);
        }
}

function RepulseGun::onMount(%player,%item)
{
        %client = Player::getClient(%player);
        Player::mountItem(%player,RepulseGun2,$ExtraSlotA);
        if($WeapMode[%client,RepulseGun] == 2 || $WeapMode[%client,RepulseGun] > $FireModes[RepulseGun])
                Player::mountItem(%player,ForcImpMod,$ExtraSlotB);
}

function RepulseGun::onUnMount(%player,%item)
{
        %client = Player::getClient(%player);
        Player::unmountItem(%player,$ExtraSlotA);
        if($WeapMode[%client,RepulseGun] == 2 || $WeapMode[%client,RepulseGun] > $FireModes[RepulseGun])
                Player::unmountItem(%player,$ExtraSlotB);
}

$MountMSG[RepulseGun,1] = "<JC><F2>Force Cannon <F0>- <F1>Blow away your enemys with the force of the wind.";
$MountMSG[RepulseGun,2] = "<JC><F2>Force Cannon <F0>- <F1>Keep your enemies ground with the force of gravity.";

AddWeapon(RepulseGun);

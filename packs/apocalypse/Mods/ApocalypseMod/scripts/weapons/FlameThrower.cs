$FireModes[FlameThrower] = 2;
//--------------------------------------

$AutoUse[FlameThrower] = True;
addAmmo(FlameThrower,FlameAmmo,20,50);

addToInv(FlameThrower,1,1);
addToInv(FlameAmmo,1,1);

setArmorItemMax(FlameThrower,0,1,1,1,1,1,1, 1, 0,0,0,0);
setArmorItemMax(FlameAmmo,0,100,120,120,120,180,250, 400, 0,0,0,0);

//--------------------------------------
RocketData FlameShell
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = plasmaExp2;
   collisionRadius  = 0.0;
   mass             = 1.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.05;
   damageType       = $FireDamageType;

   explosionRadius  = 1.0;
   kickBackStrength = 0.5;
   muzzleVelocity   = 80.0;
   terminalVelocity = 100.0;
   acceleration     = 20.0;
   totalTime        = 0.075;
   liveTime         = 0.075;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.1;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 0.1;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData FrostShell
{
   bulletShapeName  = "smoke.dts";
   explosionTag     = smokeExp3;
   collisionRadius  = 0.0;
   mass             = 1.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.03;
   damageType       = $FrostDamageType;

   explosionRadius  = 1.0;
   kickBackStrength = 0.5;
   muzzleVelocity   = 80.0;
   terminalVelocity = 100.0;
   acceleration     = 20.0;
   totalTime        = 0.075;
   liveTime         = 0.075;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.1;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 0.1;

   soundId = SoundJetHeavy;
};

//--------------------------------------

ItemData FlameAmmo
{
        description = "Liquid Nitrogen";
        className = "Ammo";
        shapeFile = "grenammo";
   heading = $InvCatAmmo;
        shadowDetailMask = 4;
        price = 2;
};

ItemImageData Canister2Image
{
   shapeFile  = "grenade";
        mountPoint = 0;
        mountOffset = { 0.1, 0.0, -0.1 };
        mountRotation = { -1.57, 0, 0 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        accuFire = true;

};

ItemData Canister2
{
   heading = $InvCatWeapons[All];
        description = "Liquid Nitrogen Canister";
        className = "Weapon";
   shapeFile  = "grenade";
        hudIcon = "blaster";
        shadowDetailMask = 4;
        imageType = Canister2Image;
        price = 0;
        showWeaponBar = false;
        showinventory = false;
};

ItemImageData Canister1Image
{
   shapeFile  = "grenade";
        mountPoint = 0;
        mountOffset = { -0.1, 0.0, -0.1 };
        mountRotation = { -1.57, 0, 0 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        accuFire = true;

};

ItemData Canister1
{
   heading = $InvCatWeapons[All];
        description = "Liquid Nitrogen Canister";
        className = "Weapon";
   shapeFile  = "grenade";
        hudIcon = "blaster";
        shadowDetailMask = 4;
        imageType = Canister1Image;
        price = 0;
        showWeaponBar = false;
        showinventory = false;
};

ItemImageData FlameThrowerImage
{
        shapeFile = "grenadeL";
        mountPoint = 0;

        weaponType = 1; // Spinning
        reloadTime = 0;
        spinUpTime = 0.5;
        spinDownTime = 3;
        fireTime = 0.025;

        ammoType = FlameAmmo;
//        projectileType = FlameShell;
        accuFire = true;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.6, 1, 1.0 };

        sfxFire = SoundFireFlamer;
        sfxActivate = SoundPickUpWeapon;
        sfxReload = SoundDryFire;
};

ItemData FlameThrower
{
        description = "Flame Thrower";
        className = "Weapon";
        shapeFile = "grenadeL";
        hudIcon = "chain";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = FlameThrowerImage;
        price = 150;
        showWeaponBar = true;
   validateShape = true;
};

function FlameThrower::onMount(%player,%item)
{
        Player::mountItem(%player,Canister1,$ExtraSlotA);
        Player::mountItem(%player,Canister2,$ExtraSlotB);
}

function FlameThrower::onUnMount(%player,%item)
{
        Player::unmountItem(%player,$ExtraSlotA);
        Player::unmountItem(%player,$ExtraSlotB);
}

function FlameThrowerImage::onFire(%player, %slot)
{
        %client = Player::getClient(%player);
        %ammo = Player::getItemCount(%player,FlameAmmo);
        if(%ammo > 0) {
                %trans = getPerfectTrans(%player);
                %vel = Item::getVelocity(%player);
                if($WeapMode[%client,FlameThrower] == 1 || $WeapMode[%client,FlameThrower] < 1 || $WeapMode[%client,FlameThrower] == "")
                        Projectile::spawnProjectile(FlameShell,%trans,%player,%vel);
                else if($WeapMode[%client,FlameThrower] == 2 || $WeapMode[%client,FlameThrower] > $FireModes[FlameThrower])
                        Projectile::spawnProjectile(FrostShell,%trans,%player,%vel);
                Player::decItemCount(%player,FlameAmmo,1);
        }
}

$MountMSG[FlameThrower,1] = "<JC><F2>Flame Thrower[Spark: On] <F0>- <F1>Fires a stream of liquid flames.";
$MountMSG[FlameThrower,2] = "<JC><F2>Flame Thrower[Spark: Off] <F0>- <F1>Spews out a stream of liquid nitrogen.";

AddWeapon(FlameThrower);

$FireModes[RangerMortar] = 2;
//--------------------------------------

$AutoUse[RangerMortar] = True;
$WeaponAmmo[RangerMortar] = MortarAmmo;

addToInv(RangerMortar,1,1);

setArmorItemMax(RangerMortar,0,0,1,1,1,0,0, 1, 0,0,0,0);

//--------------------------------------
GrenadeData RangerShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 4.0;
   elasticity         = 0.15;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.6;
   damageType         = $MortarDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 100.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//---------------------------------------
GrenadeData RGravShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = turretExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 4.0;
   elasticity         = 0.15;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.6;
   damageType         = $GravityDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = -100.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName = "enex.dts";
};

//----------------------------------------------------------------------------

//ItemData RangerAmmo
//{
//        description = "Rapid Mortar Ammo";
//        className = "Ammo";
//   heading = $InvCatAmmo;
//        shapeFile = "mortarammo";
//        shadowDetailMask = 4;
//        price = 5;
//};

ItemImageData RangerMortarImage
{
        shapeFile = "mortargun";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        ammoType = MortarAmmo;
//        projectileType = RangerShell;
        accuFire = false;
        reloadTime = 0.2;
        fireTime = 0.5;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.6, 1, 1.0 };

        sfxFire = SoundFireMortar;
        sfxActivate = SoundPickUpWeapon;
        sfxReload = SoundMortarReload;
        sfxReady = SoundMortarIdle;
};

ItemData RangerMortar
{
        description = "Rapid Mortar";
        className = "Weapon";
        shapeFile = "mortargun";
        hudIcon = "mortar";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = RangerMortarImage;
        price = 425;
        showWeaponBar = true;
};

function RangerMortarImage::onFire(%player, %slot)
{
        %client = Player::getClient(%player);
        %ammo = Player::getItemCount(%player,MortarAmmo);
        if(%ammo > 0) {
                %trans = GameBase::getMuzzleTransform(%player);
                %vel = Item::getVelocity(%player);
                if($WeapMode[%client,RangerMortar] == 1 || $WeapMode[%client,RangerMortar] < 1  || $WeapMode[%client,RangerMortar] == "")
                        Projectile::spawnProjectile(RangerShell,%trans,%player,%vel);
                else if($WeapMode[%client,RangerMortar] >= $FireModes[RangerMortar])
                        Projectile::spawnProjectile(RGravShell,%trans,%player,%vel);
                Player::decItemCount(%player,MortarAmmo,1);
        }
}

function RangerMortar::onMount(%player,%item)
{
        %client = Player::getClient(%player);
        if($WeapMode[%client,RangerMortar] == 2 || $WeapMode[%client,RangerMortar] > $FireModes[RangerMortar])
                Player::mountItem(%player,MortImpMod,$ExtraSlotA);
}

function RangerMortar::onUnMount(%player,%item)
{
        %client = Player::getClient(%player);
        if($WeapMode[%client,RangerMortar] == 2 || $WeapMode[%client,RangerMortar] > $FireModes[RangerMortar])
                Player::unmountItem(%player,$ExtraSlotA);
}

$MountMSG[RangerMortar,1] = "<JC><F2>Rapid Mortar <F0>- <F1>Set to fire explosion mortars.";
$MountMSG[RangerMortar,2] = "<JC><F2>Rapid Mortar <F0>- <F1>Set to fire implosion mortars.";

AddWeapon(RangerMortar);

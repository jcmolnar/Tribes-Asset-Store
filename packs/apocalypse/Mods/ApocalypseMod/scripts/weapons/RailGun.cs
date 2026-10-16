//--------------------------------------

addAmmo(RailGun,RailAmmo,5,10);

addToInv(RailGun,1,1);
addToInv(RailAmmo,1,1);

setArmorItemMax(RailGun,0,1,1,1,1,0,0, 1, 0,0,0,0);
setArmorItemMax(RailAmmo,0,5,10,15,15,5,5, 99, 0,0,0,0);

//--------------------------------------

RocketData RailBolt
{
   bulletShapeName = "bullet.dts";
   explosionTag    = bulletExp0;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 1.25;
   damageType       = $RailDamageType;

   explosionRadius  = 0.1;
   kickBackStrength = 200.0;

   muzzleVelocity   = 3999.0;
   terminalVelocity = 4000.0;
   acceleration     = 1.0;

   totalTime        = 1.5;
   liveTime         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 50;
   trailWidth  = 0.5;

   soundId = SoundDiscSpin;
};

//--------------------------------------

ItemData RailAmmo
{
        description = "Rail Bolt";
        className = "Ammo";
        shapeFile = "ammo2";
   heading = $InvCatAmmo;
        shadowDetailMask = 4;
        price = 5;
};

ItemImageData Rail1Image
{
        shapeFile = "disc";
        mountPoint = 0;
        mountRotation = { 0, 1.57, 0 };
        mountOffset = { -0.1, 0.0, 0.05 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

};

ItemData Rail1
{
        description = "Rail Gun";
        className = "Weapon";
        shapeFile = "disc";
        hudIcon = "targetLaser";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = Rail1Image;
        price = 0;
        showWeaponBar = false;
        showinventory = false;
};

ItemImageData Rail2Image
{
        shapeFile = "disc";
        mountPoint = 0;
        mountRotation = { 0, -1.57, 0 };
        mountOffset = { 0.1, 0.0, 0.05 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

};

ItemData Rail2
{
        description = "Rail Gun";
        className = "Weapon";
        shapeFile = "disc";
        hudIcon = "targetLaser";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = Rail2Image;
        price = 0;
        showWeaponBar = false;
        showinventory = false;
};

ItemImageData RailGunImage
{
        shapeFile = "energygun";
        mountPoint = 0;
        mountOffset = { 0.0, 0.0, -0.05 };

        weaponType = 3; // DiscLauncher
        ammoType = RailAmmo;
        accuFire = true;
        reloadTime = 0.25;
        fireTime = 1.25;
        spinUpTime = 0.25;

        sfxFire = SoundFireMortar;
        sfxActivate = SoundPickUpWeapon;
        sfxReload = SoundMortarReload;
};

ItemData RailGun
{
        description = "Rail Gun";
        className = "Weapon";
        shapeFile = "energygun";
        hudIcon = "targetLaser";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = RailGunImage;
        price = 300;
        showWeaponBar = true;
};

$MountMSG[RailGun] = "<JC><F2>Rail Gun <F0>- <F1>Fires magnetically hyper accelerated rail bolts. These bolts lose power with distance";

function RailGunImage::onFire(%player, %slot)
{
        %energy = GameBase::getEnergy(%player);
        %ammo = Player::getItemCount(%player,RailAmmo);
//        %trans = GameBase::getMuzzleTransform(%player);
        %trans = getPerfectTrans(%player);
        %vel = Item::getVelocity(%player);
        if(%energy >= 20) {
                if(%ammo > 0) {
                        Projectile::spawnProjectile("RailBolt",%trans,%player,%vel);
                        %energy -= 20;
                        GameBase::setEnergy(%player,%energy);
                        Player::decItemCount(%player,RailAmmo, 1);
                }
                else
                        Client::sendMessage(Player::getClient(%player),0, "Out of rail bolts.");
        }
        else
                Client::sendMessage(Player::getClient(%player),0, "Not enough energy to accelerate rail bolt.");
}

function RailGun::onMount(%player,%item)
{
        Player::mountItem(%player,Rail1,$ExtraSlotA);
        Player::mountItem(%player,Rail2,$ExtraSlotB);
}

function RailGun::onUnMount(%player,%item)
{
        Player::unmountItem(%player,$ExtraSlotA);
        Player::unmountItem(%player,$ExtraSlotB);
}

AddWeapon(RailGun);

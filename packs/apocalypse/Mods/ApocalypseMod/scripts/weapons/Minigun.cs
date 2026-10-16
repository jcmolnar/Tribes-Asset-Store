//--------------------------------------

$AutoUse[Minigun] = True;
$WeaponAmmo[Minigun] = BulletAmmo;

addToInv(Minigun,1,1);

setArmorItemMax(Minigun,0,0,0,0,0,1,1, 1, 0,0,0,0);

//--------------------------------------
BulletData MinigunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.06;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.09;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0055;
   muzzleVelocity     = 450.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//----------------------------------------------------------------------------

ItemImageData MinigunImage
{
        shapeFile = "chaingun";
        mountPoint = 0;
        mountRotation = { 0,3.14, 0 };

        weaponType = 1; // Spinning
        reloadTime = 0;
        spinUpTime = 0.75;
        spinDownTime = 5;
        fireTime = 0.025;

        ammoType = BulletAmmo;
//        projectileType = MinigunBullet;
        accuFire = false;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.6, 1, 1 };

        sfxFire = SoundFireChaingun;
        sfxActivate = SoundPickUpWeapon;
        sfxSpinUp = SoundSpinUp;
        sfxSpinDown = SoundSpinDown;
};

ItemData Minigun
{
        description = "Mini Gun";
        className = "Weapon";
        shapeFile = "chaingun";
        hudIcon = "chain";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = MinigunImage;
        price = 125;
        showWeaponBar = true;
};

function MinigunImage::onFire(%player, %slot)
{
        %client = Player::getClient(%player);
        %ammo = Player::getItemCount(%player,BulletAmmo);
        if(%ammo > 0) {
                %trans = getPerfectTrans(%player);
                %vel = Item::getVelocity(%player);
                Projectile::spawnProjectile(MinigunBullet,%trans,%player,%vel);
                Projectile::spawnProjectile(BulletShell,%trans,%player,%vel);
                Player::decItemCount(%player,BulletAmmo,1);
        }
}

$MountMSG[Minigun] = "<JC><F2>Mini Gun <F0>- <F1>Has more power than the Vulcan but same rate of fire.";

AddWeapon(Minigun);

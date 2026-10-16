//--------------------------------------

$AutoUse[Vulcan] = True;
$WeaponAmmo[Vulcan] = BulletAmmo;

addToInv(Vulcan,1,1);

setArmorItemMax(Vulcan,0,0,1,1,1,0,0, 1, 0,0,0,0);

//--------------------------------------
BulletData VulcanBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.09;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0045;
   muzzleVelocity     = 450.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//----------------------------------------------------------------------------

ItemImageData VulcanImage
{
        shapeFile = "chaingun";
        mountPoint = 0;
        mountRotation = { 0,1.57, 0 };

        weaponType = 1; // Spinning
        reloadTime = 0;
        spinUpTime = 0.4;
        spinDownTime = 3;
        fireTime = 0.05;

        ammoType = BulletAmmo;
//        projectileType = ChaingunBullet;
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

ItemData Vulcan
{
        description = "Vulcan";
        className = "Weapon";
        shapeFile = "chaingun";
        hudIcon = "chain";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = VulcanImage;
        price = 125;
        showWeaponBar = true;
};

function VulcanImage::onFire(%player, %slot)
{
        %client = Player::getClient(%player);
        %ammo = Player::getItemCount(%player,BulletAmmo);
        if(%ammo > 0) {
                %trans = getPerfectTrans(%player);
                %vel = Item::getVelocity(%player);
                Projectile::spawnProjectile(ChaingunBullet,%trans,%player,%vel);
                Projectile::spawnProjectile(BulletShell,%trans,%player,%vel);
                Player::decItemCount(%player,BulletAmmo,1);
        }
}

$MountMSG[Vulcan] = "<JC><F2>Vulcan <F0>- <F1>Fires at a faster rate than the normal chaingun and with more accuracy.";

AddWeapon(Vulcan);

//--------------------------------------

$WeaponAmmo[HomingLauncher] = HomingAmmo;

addToInv(HomingLauncher,1,1);

setArmorItemMax(HomingLauncher,0,1,1,1,1,0,0, 1, 0,0,0,0);

//----------------------------------------------------------------------------

ItemImageData HomingLauncherImage
{
        shapeFile = "grenadeL";
        mountPoint = 0;
//        mountOffset = { -0.1, -0.6, 0.4 };
//        mountRotation = { 0, 0, 0 };

        weaponType = 0; // Sustained
        ammoType = HomingAmmo;
        accuFire = true;
        fireTime = 0.1;
        reloadTime = 2.5;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 1.0, 1.0, 1.0 };

        sfxActivate = SoundPickUpWeapon;
        sfxReady = SoundMissileTurretTurn;
};

ItemData HomingLauncher
{
        description = "Homing Missile Launcher";
        className = "Weapon";
        shapeFile = "grenadeL";
        hudIcon = "targetlaser";
        heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = HomingLauncherImage;
        price = 250;
        showWeaponBar = true;
};

function HomingLauncherImage::onFire(%player, %slot)
{
        %client = Player::getClient(%player);
        %client.targetLock = 0;
//        %trans = GameBase::getMuzzleTransform(%player);
        %trans = getPerfectTrans(%player);
        %vel = Item::getVelocity(%player);
        %newObj = Projectile::spawnProjectile("missilePrep",%trans,%player,%vel);
        schedule("deleteobject(" @ %newObj @ ");",0.1,%newObj);
        schedule("Weapon::fireMissiles(" @ %player @ ",1,HomingLauncher,true);",0.05,%player);
}

$MountMSG[HomingLauncher] = "<JC><F2>Homing Missile Launcher <F0>- <F1>Fires guided and unguided missiles. You can not move while firing guided missiles.";

AddWeapon(HomingLauncher);

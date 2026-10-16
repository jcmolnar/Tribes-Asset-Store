//--------------------------------------

$AutoUse[BeamCannon] = True;
$WeaponAmmo[BeamCannon] = "";

addToInv(BeamCannon,1,1);

setArmorItemMax(BeamCannon,0,0,0,0,0,1,1, 1, 0,0,0,0);

//--------------------------------------

LaserData beamLaser
{
   laserBitmapName   = "warp.bmp";
   hitName           = "shockwave_large.dts";

   damageConversion  = 0.01;
   baseDamageType    = $BeamDamageType;

   beamTime          = 1.5;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 1.0 };

   detachFromShooter = false;
   hitSoundId        = shockExplosion;
};

//----------------------------------------------------------------------------

ItemImageData BeamCannon3Image
{
   shapeFile  = "paintgun";
        mountPoint = 0;
        mountRotation = { 0, -1.57, 0 };
        mountOffset = { 0.0, 0.0, -0.04 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        accuFire = true;
};

ItemData BeamCannon3
{
   heading = $InvCatWeapons[All];
        description = "Beam Cannon";
        className = "Weapon";
   shapeFile  = "paintgun";
        hudIcon = "blaster";
        shadowDetailMask = 4;
        imageType = BeamCannon3Image;
        price = 0;
        showWeaponBar = false;
        showinventory = false;
};

ItemImageData BeamCannon2Image
{
   shapeFile  = "paintgun";
        mountPoint = 0;
        mountRotation = { 0, 1.57, 0 };
        mountOffset = { 0.0, 0.0, -0.04 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        accuFire = true;
};

ItemData BeamCannon2
{
   heading = $InvCatWeapons[All];
        description = "Beam Cannon";
        className = "Weapon";
   shapeFile  = "paintgun";
        hudIcon = "blaster";
        shadowDetailMask = 4;
        imageType = BeamCannon2Image;
        price = 0;
        showWeaponBar = false;
        showinventory = false;
};

ItemImageData BeamCannonImage
{
        shapeFile = "grenadeL";
        mountPoint = 0;
        mountRotation = { 0,3.14, 0 };

        weaponType = 0; // Single Shot
        projectileType = beamLaser;
        accuFire = true;
        reloadTime = 0.5;
        fireTime = 4.5;
        minEnergy = 79;
        maxEnergy = 150;

        lightType   = 3;  // Weapon Fire
        lightRadius = 1;
        lightTime   = 1;
        lightColor  = { 0.25, 1, 0.25 };

        sfxFire = SoundFirePlasma;
        sfxActivate = SoundPickUpWeapon;
        sfxReload = SoundDiscSpin;
        sfxReady = SoundMortarIdle;
};

ItemData BeamCannon
{
        description = "Beam Cannon";
        className = "Weapon";
        shapeFile = "grenadeL";
        hudIcon = "blaster";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = BeamCannonImage;
        price = 275;
        showWeaponBar = true;
};

$MountMSG[BeamCannon] = "<JC><F2>Beam Cannon <F0>- <F1>Fires a high powered laser draining energy.";

function BeamCannon::onUse(%player,%item)
{
        %pack = Player::getMountedItem(%player,$BackpackSlot);
        if(%pack == EnergyPack || %pack == PerGenPack || %pack == UltimaPack)
                Weapon::onUse(%player,%item);
        else
                Client::sendMessage(Player::getClient(%player),0,"Must have an Energy Pack or Personal Generator to use Beam Cannon.");
}

function BeamCannon::onMount(%player,%item)
{
        Player::mountItem(%player,BeamCannon2,$ExtraSlotA);
        Player::mountItem(%player,BeamCannon3,$ExtraSlotB);
}

function BeamCannon::onUnMount(%player,%item)
{
        Player::unmountItem(%player,$ExtraSlotA);
        Player::unmountItem(%player,$ExtraSlotB);
}

AddWeapon(BeamCannon);

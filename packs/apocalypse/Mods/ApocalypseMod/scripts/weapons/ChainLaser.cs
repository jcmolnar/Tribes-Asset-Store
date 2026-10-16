//--------------------------------------

$AutoUse[ChainLaser] = True;
$WeaponAmmo[ChainLaser] = "";

addToInv(ChainLaser,1,1);

setArmorItemMax(ChainLaser,0,0,1,1,1,0,0, 1, 0,0,0,0);

//--------------------------------------

LaserData chaingunLaser
{
   laserBitmapName   = "paintpulse.bmp";
   hitName           = "paint.dts";

   damageConversion  = 0.009;
   baseDamageType    = $PulseDamageType;

   beamTime          = 0.1;

   lightRange        = 2.0;
   lightColor        = { 1.0, 1.0, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//--------------------------------------

ItemImageData ChainLaserImage
{
        shapeFile = "chaingun";
        mountPoint = 0;

        weaponType = 1; // Spinning
        reloadTime = 0;
        spinUpTime = 0.5;
        spinDownTime = 2;
        fireTime = 0.005;
        projectileType = chaingunLaser;
        accuFire = true;
        minEnergy = 0.5;
        maxEnergy = 1.0;

        lightType   = 3;  // Weapon Fire
        lightRadius = 1;
        lightTime   = 1;
        lightColor  = { 0.25, 1, 0.25 };

        sfxFire = SoundFireTargetingLaser;
        sfxActivate = SoundPickUpWeapon;
};

ItemData ChainLaser
{
        description = "Pulse Laser";
        className = "Weapon";
        shapeFile = "chaingun";
        hudIcon = "sniper";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = ChainLaserImage;
        price = 275;
        showWeaponBar = true;
};

function ChainLaser::onUse(%player,%item)
{
        %pack = Player::getMountedItem(%player,$BackpackSlot);
        if(%pack == EnergyPack || %pack == PerGenPack || %pack == UltimaPack)
                Weapon::onUse(%player,%item);
        else
                Client::sendMessage(Player::getClient(%player),0, "Must have an Energy Pack to use Pulse Laser.");
}

$MountMSG[ChainLaser] = "<JC><F2>Pulse Laser <F0>- <F1>Fires an almost constant laser beam.";

AddWeapon(ChainLaser);

// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
$LaserTagDamageType    = 14;
$LaserTagRifleDmg = 0.5;
LaserData LaserTagLaserRed
{
   laserBitmapName   = "laserPulse.bmp";
   //hitName           = "laserhit.dts";

   damageConversion  = 0.0;
   baseDamageType    = $LaserTagDamageType;

   beamTime          = 0.5;

   //lightRange        = 2.0;
   //lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};

ExplosionData laserExpRed
{
   shapeName = "laserhit.dts";
   //soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 1.0, 0.25, 0.25 };
   colors[1]  = { 1.0, 0.25, 0.25 };
   colors[2]  = { 1.0, 0.25, 0.25 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

BulletData LaserTagRifleBoltRed
{
   explosionTag       = laserExpRed;
   damageClass        = 0;
   damageValue        = $LaserTagRifleDmg;
   damageType         = $LaserTagDamageType;
   explosionRadius    = 1.0;

   muzzleVelocity     = 1800.0;
   totalTime          = 2.0;
   liveTime           = 2.0;
   inheritedVelocityScale = 100.0;
   isVisible          = False;

};

LaserData LaserTagLaserBlue
{
   laserBitmapName   = "forcefield.bmp";
   //hitName           = "laserhit.dts";

   damageConversion  = 0.0;
   baseDamageType    = $LaserTagDamageType;

   beamTime          = 0.5;

   //lightRange        = 2.0;
   //lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};

ExplosionData laserExpBlue
{
   shapeName = "breath.dts";
   //soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 0.25, 0.25, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

BulletData LaserTagRifleBoltBlue
{
   explosionTag       = laserExpBlue;
   damageClass        = 0;
   damageValue        = $LaserTagRifleDmg;
   damageType         = $LaserTagDamageType;
   explosionRadius    = 1.0;

   muzzleVelocity     = 1800.0;
   totalTime          = 2.0;
   liveTime           = 2.0;
   inheritedVelocityScale = 100.0;
   isVisible          = False;

};

ItemImageData LaserTagRifleImage
{
    shapeFile = "sniper";
    mountPoint = 0;

    weaponType = 0; // Single Shot
    accuFire = true;
    reloadTime = 0.5;
    fireTime = 0.5;
    minEnergy = 50;
    maxEnergy = 25;

    lightType = 3;  // Weapon Fire
    lightRadius = 2;
    lightTime = 1;
    lightColor = { 1, 0, 0 };

    sfxActivate = SoundPickUpWeapon;
};

function LaserTagRifleImage::onFire(%player, %this)
{
    %set = newObject("set",SimSet);
    %radius = $LaserTagNoDmgBeaconRange;
    %numItems = containerBoxFillSet(%set, $StaticObjectType | $SimInteriorObjectType, GameBase::getPosition(%this), %radius, %radius, %radius, 0);
    for(%i = %numItems - 1 ; %i>=0; %i--)
    {
        %obj = Group::getObject(%set, %i);
        if(%obj.IsLTSafeBeacon == true)
            return;
    }

    %nrg = GameBase::getEnergy(%player);
    if(%nrg < LaserTagRifleImage.minEnergy)
    {
        playSound(SoundDryFire,GameBase::getMuzzlePosition(%player));
        return;
    }
    %trans = getPerfectTrans(%player);
    %vel = Item::getVelocity(%player);
    if($LaserTagXtra == BoolToNum(true))
    {
        if(GameBase::getTeam(%player) == 0)
        {
            Projectile::spawnProjectile("LaserTagLaserBlue",%trans,%player,%vel);
            Projectile::spawnProjectile("LaserTagRifleBoltBlue",%trans,%player,%vel);
        }
        else
        {
            Projectile::spawnProjectile("LaserTagLaserRed",%trans,%player,%vel);
            Projectile::spawnProjectile("LaserTagRifleBoltRed",%trans,%player,%vel);
        }
    }
    else
    {
        Projectile::spawnProjectile("LaserTagLaserRed",%trans,%player,%vel);
        Projectile::spawnProjectile("LaserTagRifleBoltRed",%trans,%player,%vel);
    }
    //GameBase::setEnergy(%player, %nrg - LaserTagRifleImage.maxEnergy);
    playSound(SoundFireLaser, GameBase::getMuzzlePosition(%player));
}

ItemData LaserTagRifle
{
    description = "Laser Tag Rifle";
    className = "Weapon";
    shapeFile = "sniper";
    hudIcon = "sniper";
    heading = "bWeapons";
    shadowDetailMask = 4;
    imageType = LaserTagRifleImage;
    price = 200;
    showWeaponBar = true;
    validateShape = true;
    validateMaterials = true;
};

AddWeapon(LaserTagRifle);

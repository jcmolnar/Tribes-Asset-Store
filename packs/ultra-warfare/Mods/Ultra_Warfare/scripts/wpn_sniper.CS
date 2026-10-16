//================================================================
//t2 Laser Rifle
//================================================================
$AutoUse[LaserRifle] = False;
//================================================================
$InvList[LaserRifle] = 1;
$RemoteInvList[LaserRifle] = 1;
//================================================================
$DamageScale[larmor, $LaserRifleDamageType] = 1.0;  
$DamageScale[lfemale, $LaserRifleDamageType] = 1.0;
$DamageScale[marmor, $LaserRifleDamageType] = 1.0;  
$DamageScale[mfemale, $LaserRifleDamageType] = 1.0; 
$DamageScale[harmor, $LaserRifleDamageType] = 1.0;  

$ItemMax[larmor, LaserRifle] = 1;
$ItemMax[lfemale, LaserRifle] = 1; 
$ItemMax[marmor, LaserRifle] = 0;
$ItemMax[mfemale, LaserRifle] = 0; 
$ItemMax[harmor, LaserRifle] = 0;
//================================================================
SoundData SoundWPNLaserRifleAct
{
   wavFileName = "wpn_sniper_act.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNLaserRifle
{
   wavFileName = "wpn_sniper.wav";
   profile = Profile3dNear;
};
SoundData HitLaserRifle
{
   wavFileName = "hit_sniper.wav";
   profile = Profile3dMedium;
};
//================================================================
LaserData LaserRifleproj
{
   laserBitmapName   = "proj_sniper.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 1;
   baseDamageType    = $LaserRifleDamageType;

   beamTime          = 0.75;

   lightRange        = 1.5;
   lightColor        = { 0, 0, 3};

   detachFromShooter = false;
   hitSoundId        = HitLaserRifle;
  	
};
//================================================================
ItemImageData LaserRifleImage
{
        shapeFile = "wpn_sniper";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        projectileType = LaserRifleproj;
        accuFire = true;
        reloadTime = 0.35;
        fireTime = 0.35;
        minEnergy = 3;
        maxEnergy = 5;

        lightType = 3;  // Weapon Fire
        lightRadius = 2;
        lightTime = 1;
        lightColor = { 0, 0, 2 };

        sfxFire = SoundWPNLaserRifle;
        sfxActivate = SoundWPNLaserRifleAct;
};

ItemData LaserRifle
{
        description = "Laser Rifle";
        className = "Weapon";
        shapeFile = "wpn_sniper";
        hudIcon = "sniper";
   	heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = LaserRifleImage;
        price = 0;
        showWeaponBar = true;
};
//================================================================
//echo("Sniper Loaded");
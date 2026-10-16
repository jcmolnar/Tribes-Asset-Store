//================================================================
//FarSight
//================================================================
$AutoUse[FarSight] = False;
//================================================================
$InvList[FarSight] = 1;
$RemoteInvList[FarSight] = 1;
//================================================================
$DamageScale[larmor, $FarSightDamageType] = 3.0;  
$DamageScale[lfemale, $FarSightDamageType] = 3.0;
$DamageScale[marmor, $FarSightDamageType] = 3.0;  
$DamageScale[mfemale, $FarSightDamageType] = 3.0; 
$DamageScale[harmor, $FarSightDamageType] = 3.0;  

$ItemMax[larmor, FarSight] = 1;
$ItemMax[lfemale, FarSight] = 1; 
$ItemMax[marmor, FarSight] = 0;
$ItemMax[mfemale, FarSight] = 0; 
$ItemMax[harmor, FarSight] = 0;
//================================================================
SoundData SoundWPNFarSight
{
   wavFileName = "wpn_farsight.wav";
   profile = Profile3dNear;
};
SoundData SoundHitFarSight
{
   wavFileName = "hit_farsight.wav";
   profile = Profile3dMedium;
};
//================================================================
LaserData FarSightproj
{
   laserBitmapName   = "proj_farsight.bmp";
   hitName           = "exp_fs.dts";

   damageConversion  = 1;
   baseDamageType    = $FarSightDamageType;

   beamTime          = 0.75;

   lightRange        = 1.5;
   lightColor        = { 0, 0, 3};

   detachFromShooter = false;
   hitSoundId        = SoundHitFarSight;
  	
};
//================================================================
ItemImageData FarSightImage
{
        shapeFile = "wpn_farsight";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        projectileType = FarSightproj;
        accuFire = true;
        reloadTime = 0.05;
        fireTime = 0.05;
        minEnergy = 1;
        maxEnergy = 1;

        lightType = 3;  // Weapon Fire
        lightRadius = 2;
        lightTime = 1;
        lightColor = { 0, 0, 2 };

        sfxFire = SoundWPNFarSight;
        sfxActivate = SoundPickUpWeapon;
};

ItemData FarSight
{
        description = "FarSight";
        className = "Weapon";
        shapeFile = "sniper";
        hudIcon = "wpn_farsight";
   	heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = FarSightImage;
        price = 0;
        showWeaponBar = true;
};
//================================================================
//echo("FarSight Loaded");
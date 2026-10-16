//================================================================
//Spinfusor
//================================================================
$AutoUse[Spinfusor] = False;
//================================================================
$InvList[Spinfusor] = 1;
$InvList[DiscAmmo] = 1;
$RemoteInvList[Spinfusor] = 1;
$RemoteInvList[DiscAmmo] = 1;
//================================================================
$DamageScale[larmor, $DiscDamageType] = 1.0;
$DamageScale[lfemale, $DiscDamageType] = 1.0;
$DamageScale[marmor, $DiscDamageType] = 1.0;
$DamageScale[mfemale, $DiscDamageType] = 1.0;
$DamageScale[harmor, $DiscDamageType] = 1.0;

$ItemMax[larmor, Spinfusor] = 1;
$ItemMax[lfemale, Spinfusor] = 1;
$ItemMax[marmor, Spinfusor] = 1;
$ItemMax[mfemale, Spinfusor] = 1;
$ItemMax[harmor, Spinfusor] = 1;

$ItemMax[larmor, DiscAmmo] = 25;
$ItemMax[lfemale, DiscAmmo] = 25;
$ItemMax[marmor, DiscAmmo] = 50;
$ItemMax[mfemale, DiscAmmo] = 50;
$ItemMax[harmor, DiscAmmo] = 50;
//================================================================
SoundData SoundWPNDiscAct
{
   wavFileName = "wpn_disc_act.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNDisc
{
   wavFileName = "wpn_disc.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNDiscReload
{
   wavFileName = "wpn_disc_load.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNDiscIdle
{
   wavFileName = "wpn_disc_idle.wav";
   profile = Profile3dNearLoop;
};
SoundData SoundWhizDisc
{
   wavFileName = "whiz_disc.wav";
   profile = Profile3dNearLoop;
};
SoundData discExplosion
{
   wavFileName = "exp_disc.wav";
   profile = Profile3dFar;
};

//================================================================
ExplosionData DiscExp
{
   shapeName = "bluex.dts";
   soundId   = discExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 3.0, 0.0, 0.0 };
   colors[1]  = { 3.0, 0.0, 0.0 };
   colors[2]  = { 3.0, 0.0, 0.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

//================================================================
RocketData Discproj
{
   bulletShapeName = "proj_disc.dts";
   explosionTag    = DiscExp;

   collisionRadius = 0;
   mass            = 3;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $DiscDamageType;

   explosionRadius  = 9;
   kickBackStrength = -500;

   muzzleVelocity   = 150;
   terminalVelocity = 500;
   acceleration     = 5;

   totalTime        = 10;
   liveTime         = 7;

   lightRange       = 3;
   lightColor       = { 0.5, 0.5, 0.5 };

   inheritedVelocityScale = 0.75;

   // rocket specific
   trailType   = 1;
   trailLength = 25;
   trailWidth  = 0.5;

   soundId = SoundWhizDisc;
};
//================================================================
ItemData DiscAmmo
{
        description = "Disc Ammo";
        className = "Ammo";
        shapeFile = "ammo_disc";
   	  heading = "xAmmunition";
        shadowDetailMask = 4;
        price = 0;
};

ItemImageData SpinfusorImage
{
        shapeFile = "wpn_disc";
        mountPoint = 0;

        weaponType = 3; // DiscLauncher
        ammoType = DiscAmmo;
        projectileType = Discproj;
        accuFire = true;
        reloadTime = 0.45;
        fireTime = 0.1;
        spinUpTime = 0.1;
	
        sfxFire = SoundWPNDisc;
        sfxActivate = SoundWPNDiscAct;
        sfxReload = SoundWPNDiscReload;
        sfxReady = SoundWPNDiscIdle;
};
ItemData Spinfusor
{
        description = "Spinfusor";
        className = "Weapon";
        shapeFile = "wpn_disc";
        hudIcon = "hdisk";
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = SpinfusorImage;
        price = 0;
        showWeaponBar = true;
   //validateShape = true;
   //validateMaterials = true;
};
//================================================================
//echo("Spinfusor Loaded");
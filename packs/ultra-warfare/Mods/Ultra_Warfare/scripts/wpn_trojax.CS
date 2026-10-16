
//================================================================
//Trojax
//================================================================
$AutoUse[Trojax] = False;
//========================================================
$InvList[Trojax] = 1;
$InvList[TrojaxAmmo] = 1;
$RemoteInvList[Trojax] = 1;
$RemoteInvList[TrojaxAmmo] = 1;
//================================================================
$DamageScale[larmor, $TrojaxDamageType] = 0.5;
$DamageScale[lfemale, $TrojaxDamageType] = 0.5;
$DamageScale[marmor, $TrojaxDamageType] = 0.5;
$DamageScale[mfemale, $TrojaxDamageType] = 0.5;
$DamageScale[harmor, $TrojaxDamageType] = 0.5;

$ItemMax[larmor, Trojax] = 0;
$ItemMax[lfemale, Trojax] = 0;
$ItemMax[marmor, Trojax] = 1;
$ItemMax[mfemale, Trojax] = 1;
$ItemMax[harmor, Trojax] = 1;

$ItemMax[larmor, TrojaxAmmo] = 0;
$ItemMax[lfemale, TrojaxAmmo] = 0;
$ItemMax[marmor, TrojaxAmmo] = 25;
$ItemMax[mfemale, TrojaxAmmo] = 25;
$ItemMax[harmor, TrojaxAmmo] = 50;
//================================================================
SoundData waveExplosion
{
   wavFileName = "exp_sonic.wav";
   profile = Profile3dFar;
};
SoundData SoundWPNTrojax
{
   wavFileName = "wpn_trojax.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNTrojaxIdle
{
   wavFileName = "wpn_trojax_idle.wav";
   profile = Profile3dNearLoop;
};
SoundData SoundWPNTrojaxReload
{
   wavFileName = "wpn_trojax_load.wav";
   profile = Profile3dNear;
};
//================================================================
ExplosionData WaveExp
 {
 shapeName = "exp_trojax.dts";
 soundId = waveExplosion;
 faceCamera = true;
 randomSpin = true;
 hasLight = true;
 lightRange = 10.0;
 timeScale = 0.65;
 colors[0] = { 0.0, 2.0, 2.0 };
 colors[1] = { 0.0, 2.0, 2.0 };
 colors[2] = { 0.0, 0.0, 0.0 };
 radFactors = { 0.0, 0.0, 0.0 };
 }; 
//================================================================
RocketData Trojaxproj
{
   bulletShapeName = "proj_trojax.dts";
   explosionTag    = WaveExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;    // 0 impact, 1, radius
   damageValue      = 5.0;
   damageType       = $TrojaxDamageType;
   explosionRadius  = 20.0;

   muzzleVelocity   = 300.0;
   terminalVelocity = 300.0;
   acceleration     = 50.0;

   totalTime        = 5.0;
   liveTime         = 4.0;
   lightRange        = 2.0;
   lightColor        = { 0.25, 0.25, 3.0 };

   isVisible          = True;
   inheritedVelocityScale = 1.0;
 };

//================================================================
ItemData TrojaxAmmo
{
        description = "Trojax Cell";
        className = "Ammo";
        shapeFile = "plasammo";
   heading = "xAmmunition";
        shadowDetailMask = 4;
        price = 0;
};
ItemImageData TrojaxImage
{
        shapeFile = "wpn_trojax";
        mountPoint = 0;
	
        weaponType = 3; // Single Shot
        ammoType = TrojaxAmmo;
        projectileType = TrojaxProj;		
        accuFire = true;
        reloadTime = 1.0;
        fireTime = 1.0;
	spinUpTime = 0.1;
 	spinDownTime = 2.0;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.0, 2, 2 };

        sfxFire = SoundWPNTrojax;
        sfxActivate = SoundPickUpWeapon;
        sfxReload = SoundWPNTrojaxReload;
        sfxReady = SoundWPNTrojaxIdle; 
	  sfxSpinUp = SoundNoSound;
};
ItemData Trojax
{
        description = "Trojax";
        className = "Weapon";
        shapeFile = "wpn_trojax";
        hudIcon = "plasma";
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = TrojaxImage;
        price = 0;
        showWeaponBar = true;
  // validateShape = true;
  // validateMaterials = true;
};
//////////////////////////////////////////
//echo("Trojax Loaded");

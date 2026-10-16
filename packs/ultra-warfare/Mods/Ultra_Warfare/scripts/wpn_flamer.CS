//================================================================
//Flamer
//================================================================
$AutoUse[Flamer] = False;
//================================================================
$InvList[Flamer] = 1;
$InvList[FlamerAmmo] = 1;
$RemoteInvList[Flamer] = 1;
$RemoteInvList[FlamerAmmo] = 1;
//================================================================
$DamageScale[larmor, $FlamerDamageType] = 0.25;
$DamageScale[lfemale, $FlamerDamageType] = 0.25;
$DamageScale[marmor, $FlamerDamageType] = 0.25;
$DamageScale[mfemale, $FlamerDamageType] = 0.25;
$DamageScale[harmor, $FlamerDamageType] = 0.25;
			
$ItemMax[larmor, Flamer] = 1;			
$ItemMax[lfemale, Flamer] = 1;			
$ItemMax[marmor, Flamer] = 1;			
$ItemMax[mfemale, Flamer] = 1;				
$ItemMax[harmor, Flamer] = 1;

$ItemMax[larmor, FlamerAmmo] = 100;
$ItemMax[lfemale, FlamerAmmo] = 100;
$ItemMax[marmor, FlamerAmmo] = 250;
$ItemMax[mfemale, FlamerAmmo] = 250;
$ItemMax[harmor, FlamerAmmo] = 500;
//================================================================
SoundData flameExplosion
{
   wavFileName = "exp_flamer.wav";
   profile = Profile3dFar;
};
SoundData SoundWPNFlamer
{
   wavFileName = "wpn_flamer.wav";
   profile = Profile3dNearLoop;
};
SoundData SoundWPNFlamerIdle
{
   wavFileName = "wpn_flamer_idle.wav";
   profile = Profile3dNearLoop;
};
SoundData SoundWPNFlamerLoad
{
   wavFileName = "wpn_flamer_load.wav";
   profile = Profile3dNear;
};
SoundData SoundWhizFlamer
{
   wavFileName = "whiz_flamer.wav";
   profile = Profile3dNear;
};
//================================================================
ExplosionData FlamerExp
{
   shapeName = "fiery.dts";
   soundId   = flameExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 3.5;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};
//================================================================

RocketData Flamerproj
{
   bulletShapeName  = "breath.dts";
   explosionTag     = FlamerExp;
   collisionRadius  = 0.0;
   mass             = 0.3;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $FlamerDamageType;

   explosionRadius  = 15.0;
   kickBackStrength = 5.0;
   muzzleVelocity   = 15.0;
   terminalVelocity = 20.0;
   acceleration     = 3.0;
   totalTime        = 2.0;
   liveTime         = 1.5;
   lightRange       = 5.0;
   lightColor       = { 3.0, 2.0, 0.0 };
   
   inheritedVelocityScale = 0.3;

   trailType   = 2;
   trailString = "plastrail.dts";
   smokeDist   = 0.35;

   soundId = SoundWhizFlamer;
};
//================================================================
ItemData FlamerAmmo
{
        description = "Flamer Fuel";
        className = "Ammo";
        shapeFile = "plasammo";
   heading = "xAmmunition";
        shadowDetailMask = 4;
        price = 0;
};
ItemImageData FlamerImage
 {
 shapeFile = "wpn_Flamer";
 mountPoint = 0;
 weaponType = 0;
 reloadTime = 0.0;
 fireTime = 0.05;
 projectileType = Flamerproj;
 ammoType = FlamerAmmo;
 accuFire = false;
 sfxFire = SoundWPNFlamer;
 sfxActivate = SoundWPNFlamerLoad;
 sfxReady = SoundWPNFlamerIdle;
};
 ItemData Flamer
 {
 heading = "bWeapons";
 description = "Flame Thrower";
 className = "Weapon";
 shapeFile = "wpn_flamer";
 hudIcon = "flame";
 shadowDetailMask = 4;
 imageType = FlamerImage;
 price = 0;
 showWeaponBar = true;
  // validateShape = true;
   //validateMaterials = true;
 };
//================================================================
echo("Flamer Loaded");
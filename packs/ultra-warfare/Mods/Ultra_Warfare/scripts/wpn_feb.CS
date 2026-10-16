//---------------------------------------------------------------------------------
// FEB Rifle
//---------------------------------------------------------------------------------
$AutoUse[FEB] = True;
//---------------------------------------------------------------------------------
$InvList[FEB] = 1;
$InvList[FEBAmmo] = 1;
$RemoteInvList[FEB] = 1;
$RemoteInvList[FEBAmmo] = 1;
//---------------------------------------------------------------------------------
$DamageScale[larmor, $TranqDamageType] = 0.25;
$DamageScale[lfemale, $TranqDamageType] = 0.25;
$DamageScale[marmor, $TranqDamageType] = 0.25;
$DamageScale[mfemale, $TranqDamageType] = 0.25;
$DamageScale[harmor, $TranqDamageType] = 0.25;

$ItemMax[larmor, FEB] = 1;
$ItemMax[lfemale, FEB] = 1;
$ItemMax[marmor, FEB] = 0;
$ItemMax[mfemale, FEB] = 0;
$ItemMax[harmor, FEB] = 0;

$ItemMax[larmor, FEBAmmo] = 150;
$ItemMax[lfemale, FEBAmmo] = 150;
$ItemMax[marmor, FEBAmmo] = 0;
$ItemMax[mfemale, FEBAmmo] = 0;
$ItemMax[harmor, FEBAmmo] = 0;
//----------------------------------------------------------------------------------
SoundData SoundWPNFEB
{
   wavFileName = "wpn_feb.wav";
   profile = Profile3dNear;
};
SoundData RicochetFEB
{
   wavFileName = "ricochet_feb.wav";
   profile = Profile3dNear;
};
//==========================================================
ExplosionData FEBExp
{
   shapeName = "smoke.dts";
   soundId   = RicochetFEB;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 0.0, 0.0, 0.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};
//---------------------------------------------------------------------------------
BulletData febproj
 {
 bulletShapeName = "proj_feb.dts";
 explosionTag = FEBExp;
 mass = 0.75;
 collisionRadius = 0.0;
 bulletHoleIndex = 0;
 damageClass = 0;
 damageValue = 0.0;
 damageType = $TranqDamageType;
 muzzleVelocity = 1000.0;
 totalTime = 3.0;
 inheritedVelocityScale = 0.0;
 isVisible = true;
 tracerPercentage = 0.0;
 tracerLength = 0;
 detachFromShooter = false;
  
 };
//---------------------------------------------------------------------------------
ItemData FEBAmmo
 {
 description = "FEB Bullets";
 className = "Ammo";
 shapeFile = "ammo2";
 heading = "xAmmunition";
 shadowDetailMask = 4;
 price = 0;
 };


ItemImageData FEBImage
 {
 shapeFile = "wpn_feb";
 mountPoint = 0;
 weaponType = 0;
 ammoType = FEBAmmo;
 projectileType = FEBproj;
 accuFire = true;
 reloadTime = 0.0;
 fireTime = 0.25;
 sfxFire = SoundWPNFEB;
 sfxActivate = SoundPickUpWeapon;
 };

ItemData FEB
 {
 description = "FEB Rifle";
 className = "weapon";
 shapeFile = "wpn_feb";
 hudIcon = "sniper";
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = FEBImage;
 price = 0;
 showWeaponBar = true;
   //validateShape = true;
   //validateMaterials = true;
 };
//============================================================
//echo("FEB Loaded");
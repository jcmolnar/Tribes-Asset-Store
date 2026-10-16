//================================================================
//Mortar Launcher
//================================================================
$AutoUse[MortarLauncher] = False;
//================================================================
$InvList[MortarLauncher] = 1;
$InvList[MortarAmmo] = 1;
$RemoteInvList[MortarLauncher] = 1;
$RemoteInvList[MortarAmmo] = 1;
//================================================================
$DamageScale[larmor, $MortarDamageType] = 1.75;
$DamageScale[lfemale, $MortarDamageType] = 1.75;
$DamageScale[marmor, $MortarDamageType] = 1.75;
$DamageScale[mfemale, $MortarDamageType] = 1.75;
$DamageScale[harmor, $MortarDamageType] = 1.75;
	
$ItemMax[larmor, MortarLauncher] = 0;				
$ItemMax[lfemale, MortarLauncher] = 0;						
$ItemMax[marmor, MortarLauncher] = 0;				
$ItemMax[mfemale, MortarLauncher] = 0;				
$ItemMax[harmor, MortarLauncher] = 1;				

$ItemMax[larmor, MortarAmmo] = 0;
$ItemMax[lfemale, MortarAmmo] = 0;
$ItemMax[marmor, MortarAmmo] = 0;
$ItemMax[mfemale, MortarAmmo] = 0;
$ItemMax[harmor, MortarAmmo] = 25;
//================================================================
SoundData MortarExplosion
{
   wavFileName = "exp_mortar.wav";
   profile = Profile3dFar;
};
SoundData SoundWPNMortarReload
{
   wavFileName = "wpn_mortar_load.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNMortar
{
   wavFileName = "wpn_Mortar.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNMortarAct
{
   wavFileName = "wpn_Mortar_act.wav";
   profile = Profile3dNear;
};
//================================================================
ExplosionData MortarExp
{
   shapeName = "mortarex.dts";
   soundId   = mortarExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 0.0, 0.0, 3.0 };
   colors[1]  = { 0.0, 0.0, 3.0 };
   colors[2]  = { 0.0, 0.0, 3.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};
//================================================================
GrenadeData Mortarproj
{
   bulletShapeName    = "proj_mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//================================================================
ItemData MortarAmmo
 {
 description = "Mortar Rounds";
 className = "Ammo";
 shapeFile = "ammo_mortar";
 heading = "xAmmunition";
 shadowDetailMask = 4;
 price = 0;
 };


ItemImageData MortarLauncherImage
 {
 shapeFile = "wpn_mortar";
 mountPoint = 0;
 weaponType = 0;
 ammoType = MortarAmmo;
 projectileType = Mortarproj;
 reloadTime = 0.5;
 accuFire = false;
 fireTime = 0.25;
 sfxFire = SoundWPNMortar;
 sfxActivate = SoundWPNMortarAct;
 sfxReady = SoundWPNMortarReload;
 };

 ItemData MortarLauncher
 {
 heading = "bWeapons";
 description = "Mortar Launcher";
 className = "Weapon";
 shapeFile = "wpn_mortar";
 hudIcon = "mortar";
 shadowDetailMask = 4;
 imageType = MortarLauncherImage;
 price = 0;
 showWeaponBar = true;
   //validateShape = true;
   //validateMaterials = true;
 };
//================================================================
//echo("MortarL Loaded");
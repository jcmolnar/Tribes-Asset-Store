//================================================================
//T2 Grenade Launcher
//================================================================
$AutoUse[GrenadeLauncher] = False;
//================================================================
$InvList[GrenadeLauncher] = 1;
$InvList[GrenadeAmmo] = 1;
$RemoteInvList[Grenade] = 1;
$RemoteInvList[GrenadeAmmo] = 1;
//================================================================
$DamageScale[larmor, $GrenadeDamageType] = 1.0;
$DamageScale[lfemale, $GrenadeDamageType] = 1.0;
$DamageScale[marmor, $GrenadeDamageType] = 1.0;
$DamageScale[mfemale, $GrenadeDamageType] = 1.0;
$DamageScale[harmor, $GrenadeDamageType] = 1.0;

$ItemMax[larmor, GrenadeLauncher] = 1;				
$ItemMax[lfemale, GrenadeLauncher] = 1;						
$ItemMax[marmor, GrenadeLauncher] = 1;				
$ItemMax[mfemale, GrenadeLauncher] = 1;				
$ItemMax[harmor, GrenadeLauncher] = 1;				

$ItemMax[larmor, GrenadeAmmo] = 25;
$ItemMax[lfemale, GrenadeAmmo] = 25;
$ItemMax[marmor, GrenadeAmmo] = 50;
$ItemMax[mfemale, GrenadeAmmo] = 50;
$ItemMax[harmor, GrenadeAmmo] = 100;
//================================================================
SoundData GrenadeExplosion
{
   wavFileName = "exp_grenade.wav";
   profile = Profile3dFar;
};
SoundData SoundWPNGrenadeReload
{
   wavFileName = "wpn_grenade_load.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNGrenade
{
   wavFileName = "wpn_grenade.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNGrenadeAct
{
   wavFileName = "wpn_grenade_act.wav";
   profile = Profile3dNear;
};
//================================================================
ExplosionData GrenadeExp
{
   shapeName = "fiery.dts";
   soundId   = grenadeExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 3.0, 1.0, 1.0 };
   colors[1]  = { 3.0, 2.0, 2.0 };
   colors[2]  = { 3.0, 1.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};
//================================================================
GrenadeData Grenadeproj
{
   bulletShapeName    = "proj_grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $GrenadeDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};
//================================================================
ItemData GrenadeAmmo
 {
 description = "Grenade Rounds";
 className = "Ammo";
 shapeFile = "ammo_grenade";
 heading = "xAmmunition";
 shadowDetailMask = 4;
 price = 0;
 };


ItemImageData GrenadeLauncherImage
 {
 shapeFile = "wpn_GrenadeL";
 mountPoint = 0;
 weaponType = 0;
 ammoType = GrenadeAmmo;
 projectileType = Grenadeproj;
 reloadTime = 0.5;
 accuFire = false;
 fireTime = 0.25;
 sfxFire = SoundWPNGrenade;
 sfxActivate = SoundWPNGrenadeAct;
 sfxReady = SoundWPNGrenadeReload;
 };

 ItemData GrenadeLauncher
 {
 heading = "bWeapons";
 description = "Grenade Launcher";
 className = "Weapon";
 shapeFile = "wpn_GrenadeL";
 hudIcon = "grenade";
 shadowDetailMask = 4;
 imageType = GrenadeLauncherImage;
 price = 0;
 showWeaponBar = true;
 //validateShape = true;
 //validateMaterials = true;
 };
//==============================================================
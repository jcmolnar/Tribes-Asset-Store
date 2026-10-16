//================================================================
// Railgun
//================================================================
$AutoUse[RailGun] = False;
//==============================================
$InvList[RailGun] = 1;
$InvList[RailAmmo] = 1;
$RemoteInvList[RailGun] = 1;
$RemoteInvList[RailAmmo] = 1;
//================================================================
$DamageScale[larmor, $RailDamageType] = 1.5;
$DamageScale[lfemale, $RailDamageType] = 1.5;
$DamageScale[marmor, $RailDamageType] = 1.5;
$DamageScale[mfemale, $RailDamageType] = 1.5;
$DamageScale[harmor, $RailDamageType] = 1.5;

$ItemMax[larmor, RailGun] = 0;
$ItemMax[lfemale, RailGun] = 0;
$ItemMax[marmor, RailGun] = 1;
$ItemMax[mfemale, RailGun] = 1;
$ItemMax[harmor, RailGun] = 1;

$ItemMax[larmor, RailAmmo] = 0;
$ItemMax[lfemale, RailAmmo] = 0;
$ItemMax[marmor, RailAmmo] = 15;
$ItemMax[mfemale, RailAmmo] = 15;
$ItemMax[harmor, RailAmmo] = 35;
//================================================================
SoundData SoundWPNRailGun
{
   wavFileName = "wpn_railgun.wav";
   profile = Profile3dNear;
};
SoundData SoundWhizRail
{
   wavFileName = "whiz_rail.wav";
   profile = Profile3dNearLoop;
};
SoundData ricochetRail
{
   wavFileName = "rico_rail.wav";
   profile = Profile3dNear;
};
//==================================================
ExplosionData RailExp
 {
 shapeName = "exp_rail.dts";
 soundId = RicochetRail;
 faceCamera = true;
 randomSpin = true;
 hasLight = false;
 lightRange = 3.0;
 timeZero = 0.100;
 timeOne = 0.900;
 colors[0] = { 3.0, 0.0, 0.0 };
 colors[1] = { 3.0, 0.0, 0.0 };
 colors[2] = { 3.0, 0.0, 0.0 };
 radFactors = { 0.0, 1.0, 0.0 };
 shiftPosition = False; 
};
//================================================================
RocketData Railproj
{ 
   bulletShapeName = "proj_rail.dts"; 
   explosionTag = RailExp; 
   collisionRadius = 0.0; 
   mass = 2; 
   damageClass = 0; 
   damageValue = 1.5; 
   damageType = $RailDamageType; 
   explosionRadius = 0.75; 
   kickBackStrength = 10; 
   muzzleVelocity = 3000; 
   terminalVelocity = 6000; 
   acceleration = 100; 
   totalTime = 3; 
   //liveTime = 5; 
   lightRange = 3; 
   lightColor = { 3, 0.25, 0.25 }; 
   inheritedVelocityScale = 3; 
   trailType = 2; 
   trailString = "trail_rail.dts"; 
   smokeDist = 5.0; 
	soundId = SoundWhizRail; 
};
//================================================================
ItemData RailAmmo
 {
 description = "Rails";
 className = "Ammo";
 heading = "xAmmunition";
 shapeFile = "ammo_shells";
 shadowDetailMask = 4;
 price = 0;
 };
ItemImageData RailGunImage
 {
 shapeFile = "wpn_railgun";
 mountPoint = 0;
 weaponType = 0;
 ammoType = RailAmmo;
 projectileType = Railproj;
 accuFire = true;
 reloadTime = 0.35;
 fireTime = 0.25;
 lightType = 3;
 lightRadius = 3;
 lightTime = 2;
 lightColor = { 1.0, 0.25, 0.25 };
 sfxFire = SoundWPNRailGun;
 sfxActivate = SoundPickUpWeapon;
 };
ItemData RailGun
 {
 description = "RailGun";
 className = "Weapon";
 shapeFile = "wpn_Railgun";
 hudIcon = "targetlaser";
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = RailGunImage;
 price = 0;
 showWeaponBar = true;
 };
//////////////////////////////////////////////
//echo("Railgun Loaded");

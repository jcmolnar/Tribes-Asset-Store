//================================================================
//TargetingLaser
//================================================================
$InvList[TargetingLaser] = 1;
$RemoteInvList[TargetingLaser] = 1;
//=====================================================
$ItemMax[larmor, TargetingLaser] = 1;
$ItemMax[lfemale, TargetingLaser] = 1;
$ItemMax[marmor, TargetingLaser] = 1;
$ItemMax[mfemale, TargetingLaser] = 1;
$ItemMax[harmor, TargetingLaser] = 1;
//================================================================
SoundData SoundFireTargeting
{
   wavFileName = "wpn_painter.wav";
   profile = Profile3dNearLoop;
};
//================================
TargetLaserData targetLaser
{
   laserBitmapName   = "proj_paint.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};
//============================================================

ItemImageData TargetingLaserImage
{
	shapeFile = "wpn_paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargeting;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "wpn_paintgun";
	hudIcon       = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

//=================================================================
//echo("Painter Loaded");

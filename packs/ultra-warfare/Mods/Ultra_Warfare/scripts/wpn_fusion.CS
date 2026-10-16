//================================================================
//Fusion Rifle
//================================================================
$AutoUse[Fusion] = False;
//================================================================
$InvList[Fusion] = 1;
$InvList[FusionAmmo] = 1;
$RemoteInvList[Fusion] = 1;
$RemoteInvList[FusionAmmo] = 1;
//================================================================
$DamageScale[larmor, $FusionDamageType] = 1.0;
$DamageScale[lfemale, $FusionDamageType] = 1.0;
$DamageScale[marmor, $FusionDamageType] = 1.0;
$DamageScale[mfemale, $FusionDamageType] = 1.0;
$DamageScale[harmor, $FusionDamageType] = 1.0;

$ItemMax[larmor, Fusion] = 1;
$ItemMax[lfemale, Fusion] = 1;
$ItemMax[marmor, Fusion] = 1;
$ItemMax[mfemale, Fusion] = 1;
$ItemMax[harmor, Fusion] = 1;

$ItemMax[larmor, FusionAmmo] = 50;
$ItemMax[lfemale, FusionAmmo] = 50;
$ItemMax[marmor, FusionAmmo] = 100;
$ItemMax[mfemale, FusionAmmo] = 100;
$ItemMax[harmor, FusionAmmo] = 150;
//================================================================
SoundData SoundWPNFusion
{
   wavFileName = "wpn_Fusion.wav";
   profile = Profile3dNear;
};
SoundData FusionExplosion
{
   wavFileName = "exp_Fusion.wav";
   profile = Profile3dFar;
};
SoundData SoundWhizFusion
{
   wavFileName = "whiz_Fusion.wav";
   profile = Profile3dNearLoop;
};
//================================================================
ExplosionData FusionExp
{
   shapeName = "fusionex.dts";
   soundId   = FusionExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 0.75;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 0.25, 0.25, 1.0 };
   radFactors = { 1.0, 1.0, 0.0 };
};
//================================================================
BulletData Fusionproj
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = FusionExp;

   damageClass        = 1;
   damageValue        = 3;
   damageType         = $FusionDamageType;
   explosionRadius    = 5.0;

   muzzleVelocity     = 125.0;
   totalTime          = 7.0;
   liveTime           = 7.0;
   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundWhizFusion;
};
//================================================================
ItemData FusionAmmo
{
        description = "Fusion Ammo";
        className = "Ammo";
        shapeFile = "plasammo";
   heading = "xAmmunition";
        shadowDetailMask = 4;
        price = 0;
};
ItemImageData FusionImage
{
	shapeFile = "wpn_Fusion";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = FusionAmmo;
	projectileType = Fusionproj;
	accuFire = true;
	reloadTime = 0.35;
	fireTime = 0.35;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0, 0, 1 };

	sfxFire = SoundWPNFusion;
	sfxActivate = SoundPickUpWeapon;
};
ItemData Fusion
{
	description = "Fusion Rifle";
	className = "Weapon";
	shapeFile = "wpn_Fusion";
	hudIcon = "Fusion";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FusionImage;
	price = 0;
	showWeaponBar = true;
};
//================================================================

//echo("Fusion Loaded");

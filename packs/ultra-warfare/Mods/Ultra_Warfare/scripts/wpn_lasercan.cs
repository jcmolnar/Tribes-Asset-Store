//================================================================
//Laser Cannon
//================================================================
$AutoUse[Laser] = False;
//================================================================
$InvList[Laser] = 1;
$InvList[LaserAmmo] = 1;
$RemoteInvList[Laser] = 1;
$RemoteInvList[LaserAmmo] = 1;
//================================================================
$DamageScale[larmor, $LaserDamageType] = 3.0;
$DamageScale[lfemale, $LaserDamageType] = 3.0;
$DamageScale[marmor, $LaserDamageType] = 3.0;
$DamageScale[mfemale, $LaserDamageType] = 3.0;
$DamageScale[harmor, $LaserDamageType] = 3.0;

$ItemMax[larmor, Laser] = 0;
$ItemMax[lfemale, Laser] = 0;
$ItemMax[marmor, Laser] = 0;
$ItemMax[mfemale, Laser] = 0;
$ItemMax[harmor, Laser] = 1;

$ItemMax[larmor, LaserAmmo] = 0;
$ItemMax[lfemale, LaserAmmo] = 0;
$ItemMax[marmor, LaserAmmo] = 0;
$ItemMax[mfemale, LaserAmmo] = 0;
$ItemMax[harmor, LaserAmmo] = 50;
//================================================================
SoundData SoundWPNLaser
{
   wavFileName = "wpn_Laser.wav";
   profile = Profile3dNear;
};
SoundData laserExplosion
{
	wavFilename = "exp_laser.wav";
	profile = Profile3dFar;
};
SoundData SoundWhizLaser
{
   wavFileName = "whiz_laser.wav";
   profile = Profile3dNearLoop;
};
//================================================================
ExplosionData LaserCanExp
{
   shapeName = "flash_small.dts";
   soundId   = laserExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2;

   timeZero = 0.250;
   timeOne  = 0.650;
	
//                red, grn, blu
   colors[0]  = { 0.0, 3.0, 0.0 };
   colors[1]  = { 0.0, 3.0, 0.0 };
   colors[2]  = { 0.0, 3.0, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
 };
//================================================================
RocketData Laserproj
{
   bulletShapeName = "proj_laser_grn.dts";
   explosionTag    = LaserCanExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;    // 0 impact, 1, radius
   damageValue      = 5.0;
   damageType       = $LaserDamageType;
   explosionRadius  = 6.0;

   muzzleVelocity   = 200.0;
   terminalVelocity = 200.0;
   acceleration     = 50.0;

   totalTime        = 5.0;
   liveTime         = 4.0;
   lightRange        = 2.0;
   lightColor        = { 0.25, 3.0, 0.25 };

   isVisible          = True;
   inheritedVelocityScale = 1.0;
   soundId = SoundWhizLaser;
 };
//================================================================
ItemData LaserAmmo
{
        description = "Laser Cell";
        className = "Ammo";
        shapeFile = "plasammo";
   heading = "xAmmunition";
        shadowDetailMask = 4;
        price = 0;
};

ItemImageData LaserImage
{
        shapeFile  = "wpn_lasercan";
        mountPoint = 0;
        	
        weaponType = 0; // Single Shot
        reloadTime = 0.6;
        fireTime = 0.01;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
 	 lightColor        = { 0.25, 3.0, 0.25 };
	
	  ammoType = LaserAmmo;
        projectileType = Laserproj;
        accuFire = true;

        sfxFire = SoundWPNLaser;
        sfxActivate = SoundPickUpWeapon;
};

ItemData Laser
{
        heading = "bWeapons";
        description = "Laser Cannon";
        className = "Weapon";
        shapeFile  = "wpn_lasercan";
        hudIcon = "lascan";
        shadowDetailMask = 4;
        imageType = LaserImage;
        price = 0;
        showWeaponBar = true;
   //validateShape = true;
   //validateMaterials = true;
};
//================================================================
//echo("Laser Loaded");
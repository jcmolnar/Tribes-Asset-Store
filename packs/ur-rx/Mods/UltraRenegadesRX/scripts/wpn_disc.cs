//================================================================
// Disc
//================================================================

SoundData SoundSpinUpDisc
{
   wavFileName = "discspin.wav";
   profile = Profile3dNear;
};

SoundData SoundFireDisc
{
   wavFileName = "rocket2.wav";
   profile = Profile3dNear;
};

SoundData SoundDiscReload
{
   wavFileName = "discreload.wav";
   profile = Profile3dNear;
};

SoundData SoundDiscSpin
{
   wavFileName = "discloop.wav";
   profile = Profile3dNearLoop;
};

SoundData ExplosionDisc
{
   wavFileName = "bigExplosion4.wav";
   profile = Profile3dMedium;
};


//================================================================

ExplosionData DiscExp
{
   shapeName = "bluex.dts";
   soundId   = ExplosionDisc;

   faceCamera = true;
   randomSpin = false;
   hasLight   = false;
   lightRange = 1.0;

   timeScale = 1.5;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 1.0 };
   colors[1]  = { 0.0, 0.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 1.0 };
   radFactors = { 0.0, 0.0, 0.0 };
};

//================================================================
RocketData ProjDisc
{
   bulletShapeName = "discb.dts";
   explosionTag    = DiscExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $DiscDamageType;

   explosionRadius  = 5.0;
   kickBackStrength = 150.0;

   muzzleVelocity   = 1500.0;
   terminalVelocity = 2000.0;
   acceleration     = 100.0;

   totalTime        = 1.0;
   liveTime         = 1.0;

   lightRange       = 1.0;
   lightColor       = { 0.4, 0.4, 0.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

//================================================================


ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = ProjDisc;
	accuFire = true;
	reloadTime = 0.06;
	fireTime = 0.0;
	spinUpTime = 0.00;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	//sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher
{
	description = "Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 0;
	showWeaponBar = true;
	showInventory = true;
   	//validateShape = true;
  	//validateMaterials = true;
};




//=================================================================
echo("Item Loaded");
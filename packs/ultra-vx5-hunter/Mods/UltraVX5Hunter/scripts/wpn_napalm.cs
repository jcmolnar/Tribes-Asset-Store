//================================================================
// Napalm Launcher
//================================================================

SoundData SoundFireNapalm
{
   wavFileName = "turretfire2.wav";
   profile = Profile3dNear;
};

SoundData SoundNapalmReload
{
   wavFileName = "turretturn1.wav";
   profile = Profile3dNearLoop;
};

SoundData ExplosionNapalm
{
   wavFileName = "BXplo1.wav";
   profile = Profile3dMedium;
};

//================================================================
ExplosionData NapalmExp
{
   shapeName = "tumult_large.dts";
   soundId   = ExplosionNapalm;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 3.0;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};
//================================================================
GrenadeData ProjNapalm
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = NapalmExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $NapalmDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plastrail.dts";
};

//================================================================



ItemImageData GrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	//ammoType = NapalmAmmo;
	projectileType = ProjNapalm;
	accuFire = false;
	reloadTime = 0.0;
	fireTime = 0.08;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireNapalm;
	sfxActivate = SoundPickUpWeapon;
	//sfxReload = SoundNapalmReload;
};

ItemData GrenadeLauncher
{
	description = "Napalm Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 0;
	showWeaponBar = true;
	showInventory = true;
   	//validateShape = true;
   	//validateMaterials = true;
};



//=================================================================
echo("Item Loaded");
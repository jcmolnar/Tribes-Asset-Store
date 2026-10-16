//================================================================
// Vaporizer
//================================================================

SoundData SoundFireVapor
{
   wavFileName = "mortar_fire.wav";
   profile = Profile3dNear;
};

SoundData SoundVaporIdle
{
   wavFileName = "mortar_idle.wav";
   profile = Profile3dNearLoop;
};

SoundData SoundVaporReload
{
   wavFileName = "mortar_reload.wav";
   profile = Profile3dNearLoop;
};

SoundData ExplosionVapor
{
   wavFileName = "bigExplosion4.wav";
   profile = Profile3dFar;
};

//================================================================

ExplosionData VaporExp
{
   shapeName = "mortarex.dts";
   soundId   = ExplosionVapor;

   faceCamera = true;
   randomSpin = false;
   //faceCamera = true;
   //randomSpin = false;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};
//================================================================
GrenadeData ProjVapor
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = VaporExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $VaporDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 1000;
   totalTime          = 1.0;
   liveTime           = 0.5;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
   smokeDist = 0.001;
};


//================================================================

ItemData VaporAmmo
{
	description = "Vapor Ammo";
	className = "Ammo";
   	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = VaporAmmo;
	projectileType = ProjVapor;
	accuFire = false;
	reloadTime = 0.35;
	fireTime = 0.35;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireVapor;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundVaporReload;
	sfxReady = SoundVaporIdle;
};

ItemData Mortar
{
	description = "Vaporizer";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 0;
	showWeaponBar = true;
	showInventory = true;
   	//validateShape = true;
   	//validateMaterials = true;
};

//=================================================================
echo("Item Loaded");
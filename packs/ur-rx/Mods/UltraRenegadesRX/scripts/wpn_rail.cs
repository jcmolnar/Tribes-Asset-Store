//================================================================
// Railgun
//================================================================

SoundData SoundFireRail
{
   wavFileName = "turretfire1.wav";
   profile = Profile3dNear;
};

SoundData RailExplosion
{
   wavFileName = "ricoche1.wav";
   profile     = Profile3dNear;
};

//==================================================

ExplosionData RailExp
 {
 shapeName = "chainspk.dts";
 soundId = ricochet1;
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

RocketData ProjRail
{
   bulletShapeName = "bullet.dts";
   explosionTag    = RailExp;
   
   collideWithOwner   = false;
   collisionRadius = 0.0;
   mass            = 2.0;
   //ownerGraceMS       = 250;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $RailDamageType;

   explosionRadius  = 2.5;
   kickBackStrength = 80.0;

   muzzleVelocity   = 3000.0;
   terminalVelocity = 9000.0;
   acceleration     = 100.0;

   totalTime        = 3.5;
   liveTime         = 3.7;

   lightRange       = 1.0;
   lightColor       = { 1.0, 0.0, 0.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.1;

  // soundId = SoundDiscSpin;
};

//================================================================
ItemData RailAmmo
 {
 	description = "Rail Ammo";
 	className = "Ammo";
 	heading = "xAmmunition";
 	shapeFile = "ammo1";
 	shadowDetailMask = 4;
 	price = 0;
 };
ItemImageData BlasterImage
 {
 	shapeFile = "sniper";
 	mountPoint = 0;
 	weaponType = 0;
 	ammoType = RailAmmo;
 	projectileType = ProjRail;
 	accuFire = true;
 	reloadTime = 0.00;
 	fireTime = 0.1;


 	lightType = 3;
 	lightRadius = 1;
 	lightTime = 2;
 	lightColor = { 1.0, 0.0, 0.0 };
 	sfxFire = SoundFireRail;
 	sfxActivate = SoundPickupWeapon;
 };
ItemData Blaster
 {
 	description = "RailGun";
 	className = "Weapon";
 	shapeFile = "sniper";
 	hudIcon = "sniper";
 	heading = "bWeapons";
 	shadowDetailMask = 4;
 	imageType = BlasterImage;
 	price = 0;
 	showWeaponBar = true;
	showinventory = true;
   	//validateShape = true;
   	//validateMaterials = true;
 };

/////////////////////////////////////////////////////////////////////////////////////////////////////////
echo("Railgun Loaded");

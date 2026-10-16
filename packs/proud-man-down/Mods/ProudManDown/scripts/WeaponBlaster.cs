//--------------------------------------

$AutoUse[Blaster] = True;
$Use[Blaster] = True;
$WeaponAmmo[Blaster] = "HandgunAmmo";

//--------------------------------------

$InvList[Blaster] = 1;
$RemoteInvList[Blaster] = 1;

//--------------------------------------

BulletData HandgunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.006;
   muzzleVelocity     = 625.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;

soundId = SoundWindWhizz;

};

GrenadeData ShellCasingShell
{
   bulletShapeName    = "force.dts";
   explosionTag       = CasingExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 0.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 5.0;
   totalTime          = 0.75;
   liveTime           = 0.75;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.1;
   smokeName              = "breath.dts";
};

ItemData HandgunAmmo
{
	description = "Handgun Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData BlasterImage
{
	shapeFile  = "paintgun";//B 
	mountPoint = 0;//U

	mountOffset = { 0, 0, 0 };//E

	ammoType = HandgunAmmo;//T
	weaponType = 0; // Singleshot//T
	reloadTime = 0.3;//Z
	fireTime = 0.001;

	projectileType = HandgunBullet;
	accuFire = true;

	sfxFire = HandgunFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
	heading = "cSecondary Weapons";
	description = "Handgun";
	className = "Tool";
	shapeFile  = "paintgun";
	hudIcon = "mortar";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 50;
	showWeaponBar = true;
};
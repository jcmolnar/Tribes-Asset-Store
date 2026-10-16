//--------------------------------------

$SellAmmo[DiscAmmo] = 5;
$AmmoPackMax[DiscAmmo] = 105;
$AmmoPackItems[2] = DiscAmmo;
$WeaponAmmo[CometRifle] = DiscAmmo;

//--------------------------------------

$InvList[CometRifle] = 1;
$InvList[DiscAmmo] = 1;
$RemoteInvList[CometRifle] = 1;
$RemoteInvList[DiscAmmo] = 1;

//--------------------------------------

RocketData CometShell
{
   bulletShapeName = "rocket.dts";
   explosionTag    = Rocketexp;

   collisionRadius = 0.0;
   mass            = 10000000.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 10.0;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 35.5;
   kickBackStrength = 250.0;

   muzzleVelocity   = 2.0;
   terminalVelocity = 120.0;
   acceleration     = 0;

   totalTime        = 135.5;
   liveTime         = 135.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 650;
   trailWidth  = 5.3;

   soundId = SoundDiscSpin;
};

//--------------------------------------

ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData CometImage
{
	shapeFile = "MortarGun";
	mountPoint = 0;

	weaponType = 0; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = CometShell;
	accuFire = true;
	reloadTime = 0.8;
	fireTime = 0.8;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData CometRifle
{
	description = "Comet Rifle";
	className = "Weapon";
	shapeFile = "discb";
	hudIcon = "disk";
   heading = "bRocket Launchers";
	shadowDetailMask = 4;
	imageType = CometImage;
	price = 450;
	showWeaponBar = true;
};

//--------------------------------------
function CometRifle::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Comet Rifle was and always is used for taking out turrets and other such...it shoots a projectile with strong exlposives but the missile is weighted down and travels slowly", 10);Weapon::onUse(%player,%item);
}

//--------------------------------------

$SellAmmo[DiscAmmo] = 5;
$AmmoPackMax[DiscAmmo] = 105;
$AmmoPackItems[2] = DiscAmmo;
$WeaponAmmo[CometRifleSS] = DiscAmmo;

//--------------------------------------


//--------------------------------------

RocketData CometShellSS
{
   bulletShapeName = "Discb.dts";
   explosionTag    = Turretexp;

   collisionRadius = 0.0;
   mass            = 100.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.01;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 8.5;
   kickBackStrength = 250.0;

   muzzleVelocity   = 300.0;
   terminalVelocity = 15000.0;
   acceleration     = 15000.0;

   totalTime        = 35.5;
   liveTime         = 35.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 650;
   trailWidth  = 3.3;

   soundId = SoundDiscSpin;
};

//--------------------------------------

ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData CometImageSS
{
	shapeFile = "plasmaex";
	mountPoint = 0;

	weaponType = 0; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = CometShellSS;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData CometRifleSS
{
	description = "SaiCannon";
	className = "Weapon";
	shapeFile = "discb";
	hudIcon = "disk";
   heading = "pArmor Upgrades";
	shadowDetailMask = 4;
	imageType = CometImageSS;
	price = 450;
	showWeaponBar = true;
};

//--------------------------------------
function CometRifleSS::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "<jc> SaiCannon", 10);Weapon::onUse(%player,%item);
}

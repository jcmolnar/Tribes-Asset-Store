//--------------------------------------

$SellAmmo[DiscAmmo] = 5;
$AmmoPackMax[DiscAmmo] = 45;
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
   mass            = 100.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 250.0;

   muzzleVelocity   = 12.0;
   terminalVelocity = 15000.0;
   acceleration     = 15000.0;

   totalTime        = 16.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

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
	reloadTime = 0;
	fireTime = 0;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData CometRifle
{
	description = "SloMo Rifle";
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
	bottomprint(Player::getClient(%player), "The SloMo Rifle was and always is used for taking out turrets and other such...it shoots a projectile with strong exlposives rapidly but the missile is weighted down and travels slowly", 10);Weapon::onUse(%player,%item);
}


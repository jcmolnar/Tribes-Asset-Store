//--------------------------------------

$SellAmmo[DiscAmmo] = 5;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackItems[2] = DiscAmmo;
$WeaponAmmo[BB] = DiscAmmo;

//--------------------------------------

$InvList[BB] = 1;
$InvList[DiscAmmo] = 1;
$RemoteInvList[BB] = 1;
$RemoteInvList[DiscAmmo] = 1;

//--------------------------------------

RocketData BBBullet
{
   bulletShapeName = "FusionBolt.dts";
   explosionTag    = "PlasmaExp";

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 4.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 600.0;
   terminalVelocity = 400.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = Soundplayerfall;
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

ItemImageData BBImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 0; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = BBBullet;
	accuFire = true;
	reloadTime = 0.15;
	fireTime = 1.15;
	spinUpTime = 0.15;

	sfxFire = SoundDiscFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundTankActive;
	sfxReady = SoundTankIdle;
};

ItemData BB
{
	description = "Ass Raper";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "hSnipers Gear";
	shadowDetailMask = 4;
	imageType = BBImage;
	price = 150;
	showWeaponBar = true;
};

//--------------------------------------
function BB::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Ass Raper...(well i might be a little baised :) ) Using the disc ammo it forms them into bullets for a powerful Sniper Rifle.", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
//--------------------------------------

$SellAmmo[DiscAmmo] = 5;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackItems[2] = DiscAmmo;
$WeaponAmmo[BBi] = DiscAmmo;

//--------------------------------------


//--------------------------------------

RocketData BBBulleti
{
   bulletShapeName = "FusionBolt.dts";
   explosionTag    = "PlasmaExp";

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.5;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 5.5;
   kickBackStrength = 350.0;

   muzzleVelocity   = 800.0;
   terminalVelocity = 1000.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

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

ItemImageData BBImagei
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 0; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = BBBulleti;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.05;
	spinUpTime = 0.15;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData BBi
{
	description = "Ass Ripper 2";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "hSnipers Gear";
	shadowDetailMask = 4;
	imageType = BBImagei;
	price = 150;
	showWeaponBar = true;
};

//--------------------------------------
function BBi::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Ass Ripper2...,This weapon was made by GAMMAK& to be a weapon for MODDERS use only. All Hail The sniper god!!", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
//--------------------------------------

$SellAmmo[DiscAmmo] = 5;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackItems[2] = DiscAmmo;
$WeaponAmmo[BB2] = DiscAmmo;

//--------------------------------------

$InvList[BB2] = 1;
$InvList[DiscAmmo] = 1;
$RemoteInvList[BB2] = 1;
$RemoteInvList[DiscAmmo] = 1;

//--------------------------------------

RocketData BBBullet2
{
   bulletShapeName = "Shockwave_Large.dts";
   explosionTag    = "MortarExp";

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "PlasmaEx.dts";
   smokeDist   = 1.8;


   soundId = SoundPlayerFall;
};

//--------------------------------------


ItemImageData BB2Image
{
	shapeFile = "Shockwave_Large";
	mountPoint = 0;

	weaponType = 1; // Chaingun
	spinUpTime = 3.5;
	spinDownTime = 3;
	ammoType = DiscAmmo;
	projectileType = BBBullet2;
	accuFire = true;
	reloadTime = 0.95;
	fireTime = 0.65;
	

	sfxFire = SoundPlayerDeath;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundTankActive;
	sfxReady = SoundTankIdle;
};

ItemData BB2
{
	description = "Gallet Gun";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "pArmor Upgrades";
	shadowDetailMask = 4;
	imageType = BB2Image;
	price = 650;
	showWeaponBar = true;
};

//--------------------------------------
function BB2::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Gallet Gun uses gathered energy from inside you to make a strong explosion...upon impact it releases this energy. DBZ Charge Time 3.5 Seconds", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
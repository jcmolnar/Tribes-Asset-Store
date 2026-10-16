//--------------------------------------

$SellAmmo[DiscAmmo] = 5;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackItems[2] = DiscAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;

//--------------------------------------

$InvList[Disclauncher] = 1;
$InvList[DiscAmmo] = 1;
$RemoteInvList[Disclauncher] = 1;
$RemoteInvList[DiscAmmo] = 1;

//--------------------------------------

RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = RocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
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

ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = DiscShell;
	accuFire = true;
	reloadTime = 0.15;
	fireTime = 1.25;
	spinUpTime = 0.15;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher
{
	description = "Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "cDisc Launchers";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

//--------------------------------------
function DiscLauncher::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The standard DiscLauncher...Can't change the classics!! :).", 10);Weapon::onUse(%player,%item);
}

$SellAmmo[EnergyAmmo] = 5;
$AmmoPackMax[EnergyAmmo] = 45;
$AmmoPackItems[2] = EnergyAmmo;
$WeaponAmmo[HaCkNuke] = EnergyAmmo;

//--------------------------------------

//--------------------------------------
RocketData HaCkNukeShell
{
   bulletShapeName = "forcefield.dts";
   explosionTag    = Mortarexp;

   collisionRadius = 0.0;
   mass            = 100.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 3.0;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 50.5;
   kickBackStrength = 350.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 150.0;
   acceleration     = 1.0;

   totalTime        = 16.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailstring = "forcefield";
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundTankIdle;
};

//--------------------------------------

ItemImageData HaCkNukeImage
{
	shapeFile = "MortarGun";
	mountPoint = 0;

	weaponType = 0; // DiscLauncher
	
	projectileType = HaCkNukeShell;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	spinUpTime = 0.3;

	sfxFire = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData HaCkNuke
{
	description = "Gamma's Nuke";
	className = "Weapon";
	shapeFile = "discb";
	hudIcon = "disk";
   heading = "bRocket Launchers";
	shadowDetailMask = 4;
	imageType = HaCkNukeImage;
	price = 12350;
	showWeaponBar = true;
};

//--------------------------------------
function HaCkNuke::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "This weapon is made for Gamma by Gamma, you can only use this weapon if you are Gamma, it is way too cheap for normal gameplay....Gammas use only :)", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
//--------------------------------------

$WeaponAmmo[FDiscLauncher] = DiscAmmo;

addToInv(FDiscLauncher,1,1);

setArmorItemMax(FDiscLauncher,1,1,0,0,0,0,0, 1, 0,0,0,0);

//--------------------------------------
RocketData FDiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass 	   = 2.0;

   damageClass	    = 1;       // 0 impact, 1, radius
   damageValue	    = 0.25;
   damageType	    = $ExplosionDamageType;

   explosionRadius  = 5.0;
   kickBackStrength = 75.0;

   muzzleVelocity   = 120.0;
   terminalVelocity = 160.0;
   acceleration     = 5.0;

   totalTime	    = 6.5;
   liveTime	    = 8.0;

   lightRange	    = 5.0;
   lightColor	    = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

//----------------------------------------------------------------------------

ItemImageData FDiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = DiscShell;
	accuFire = true;
	reloadTime = 0.15;
	fireTime = 0.6;
	spinUpTime = 0.15;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData FDiscLauncher
{
	description = "Speed Discer";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = $InvCatWeapons[All];
	shadowDetailMask = 4;
	imageType = FDiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

$MountMSG[FDiscLauncher] = "<JC><F2>Speed Discer <F0>- <F1>Faster but with smaller blast radius and less damage.";

AddWeapon(FDiscLauncher);

//--------------------------------------

$WeaponAmmo[PDiscLauncher] = DiscAmmo;

addToInv(PDiscLauncher,1,1);

setArmorItemMax(PDiscLauncher,0,0,0,0,0,1,1, 1, 0,0,0,0);

//--------------------------------------
RocketData PDiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = mortarExp;

   collisionRadius = 0.0;
   mass 	   = 2.0;

   damageClass	    = 1;       // 0 impact, 1, radius
   damageValue	    = 0.75;
   damageType	    = $ExplosionDamageType;

   explosionRadius  = 11.25;
   kickBackStrength = 225.0;

   muzzleVelocity   = 30.0;
   terminalVelocity = 40.0;
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

ItemImageData PDiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = PDiscShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.5;
	spinUpTime = 0.5;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData PDiscLauncher
{
	description = "Power Discer";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = $InvCatWeapons[All];
	shadowDetailMask = 4;
	imageType = PDiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

$MountMSG[PDiscLauncher] = "<JC><F2>Power Discer <F0>-<F1> Slower but with larger blast radius and more damage.";

AddWeapon(PDiscLauncher);

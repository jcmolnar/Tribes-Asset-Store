//--------------------------------------

addAmmo(DiscLauncher,DiscAmmo,5,15);

addToInv(DiscLauncher,1,1);
addToInv(DiscAmmo,1,1);

setArmorItemMax(DiscLauncher,1,1,1);
setArmorItemMax(DiscAmmo,15,15,15);

//--------------------------------------

RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass 	   = 2.0;

   damageClass	    = 1;       // 0 impact, 1, radius
   damageValue	    = 0.5;
   damageType	    = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
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

//--------------------------------------

ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = $InvCatAmmo;
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
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

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
   heading = $InvCatWeapons[All];
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

$MountMSG[DiscLauncher] = "<JC><F2>Disc Launcher <F0>- <F1>Fires explosive disc at high velocity.";

AddWeapon(DiscLauncher);

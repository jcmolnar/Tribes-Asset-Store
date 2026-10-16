//--------------------------------------

addAmmo(CDiscLauncher,CDiscAmmo,10,30);

addToInv(CDiscLauncher,1,1);
addToInv(CDiscAmmo,1,1);

setArmorItemMax(CDiscLauncher,1,1,1,1,1,1,1, 1, 0,0,0,0);
setArmorItemMax(CDiscAmmo,30,30,30,30,30,30,30, 99, 0,0,0,0);

//--------------------------------------
BulletData CDiscBullet
{
   bulletShapeName    = "discb.dts";
   explosionTag       = rocketExp;

   damageClass	      = 1;
   damageValue	      = 0.175;
   damageType	      = $ExplosionDamageType;
   explosionRadius    = 5.0;

   aimDeflection      = 0.006;
   muzzleVelocity     = 100.0;
   totalTime	      = 6.5;
   liveTime	      = 8.0;
   lightRange	    = 5.0;
   lightColor	    = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible	      = True;

   soundId = SoundDiscSpin;
   rotationPeriod = 1;
};

//----------------------------------------------------------------------------

ItemData CDiscAmmo
{
	description = "Chaingun Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = $InvCatAmmo;
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData CDiscLauncherImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;
	ammoType = CDiscAmmo;
	projectileType = CDiscBullet;
	accuFire = false;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData CDiscLauncher
{
	description = "Chaingun Discer";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "disk";
   heading = $InvCatWeapons[All];
	shadowDetailMask = 4;
	imageType = CDiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

$MountMSG[CDiscLauncher] = "<JC><F2>Chaingun Discer <F0>- <F1>Fires low powered disc at a faster rate.";

AddWeapon(CDiscLauncher);

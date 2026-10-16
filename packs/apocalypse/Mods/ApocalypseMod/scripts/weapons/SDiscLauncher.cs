//--------------------------------------

addAmmo(SDiscLauncher,SDiscAmmo,5,10);

addToInv(SDiscLauncher,1,1);
addToInv(SDiscAmmo,1,1);

setArmorItemMax(SDiscLauncher,1,1,1,1,1,1,1, 1, 0,0,0,0);
setArmorItemMax(SDiscAmmo,10,10,10,10,10,10,10, 99, 0,0,0,0);

//--------------------------------------
BulletData SDiscBullet
{
   bulletShapeName    = "discb.dts";
   explosionTag       = rocketExp;

   damageClass	      = 1;
   damageValue	      = 0.175;
   damageType	      = $ExplosionDamageType;
   explosionRadius    = 5.0;

   aimDeflection      = 0.006;
   muzzleVelocity     = 80.0;
   totalTime	      = 6.5;
   liveTime	      = 8.0;
   lightRange	    = 5.0;
   lightColor	    = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible	      = True;

   soundId = SoundDiscSpin;
};

//--------------------------------------
GrenadeData SDiscShell
{
   bulletShapeName    = "discammo.dts";
   explosionTag       = smokeExp0;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass 	      = 5.0;
   elasticity	      = 0.01;

   damageClass	      = 1;	 // 0 impact, 1, radius
   damageValue	      = 0.0;
   damageType	      = $NullDamageType;

   explosionRadius    = 0.01;
   kickBackStrength   = 0.01;
   maxLevelFlightDist = 1;
   totalTime	      = 10.0;
   liveTime	      = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName		  = "rsmoke.dts";
};

//----------------------------------------------------------------------------

ItemData SDiscAmmo
{
	description = "Shotgun Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = $InvCatAmmo;
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData SDiscLauncherImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = SDiscAmmo;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData SDiscLauncher
{
	description = "Shotgun Discer";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "disk";
   heading = $InvCatWeapons[All];
	shadowDetailMask = 4;
	imageType = SDiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function SDiscLauncherImage::onFire(%player, %slot)
{
	Player::decItemCount(%player,$WeaponAmmo[SDiscLauncher],1);
//	  %trans = GameBase::getMuzzleTransform(%player);
	%trans = getPerfectTrans(%player);
	%vel = Item::getVelocity(%player);
	for(%projnum = 5; %projnum > 0; %projnum--){
		Projectile::spawnProjectile("SDiscBullet",%trans,%player,%vel);
	}
	Projectile::spawnProjectile("SDiscShell",%trans,%player,%vel);
}

$MountMSG[SDiscLauncher] = "<JC><F2>Shotgun Discer <F0>- <F1>Shoots out five disc in a spread.";

AddWeapon(SDiscLauncher);

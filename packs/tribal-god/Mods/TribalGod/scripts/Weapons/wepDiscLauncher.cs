// Projectile Data:
//-------------------------------------------------------------------------------------------
RocketData DiscShell {
   bulletShapeName  = "discb.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;
   damageClass      = 0;       
   damageValue      = 5;
   damageType       = $ExplosionDamageType;
   explosionRadius  = 10;
   kickBackStrength = 5;
   muzzleVelocity   = 600;
   terminalVelocity = 800;
   acceleration     = 1;
   totalTime        = 2;
   liveTime         = 1;
   inheritedVelocityScale = 0.5;
   trailType              = 1;
   trailLength            = 15;
   trailWidth             = 0.5;
   soundId                = SoundDiscSpin;
};

BulletData DiscSpreader {
   bulletShapeName    = "discb.dts";
   explosionTag       = rocketExp;
   expRandCycle       = 0.02;
   aimDeflection      = 0.02;
   damageClass        = 0;
   damageValue        = 0.5;
   damageType         = $ExplosionDamageType;
   muzzleVelocity     = 600;
   totalTime          = 2.0;
   liveTime           = 1.0;
   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;
   rotationPeriod     = 1;
};

BulletData DiscInvisible {
   bulletShapeName    = "rocket.dts";
   explosionTag       = rocketExp;
   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $ExplosionDamageType;
   explosionradius    = 2.5;
   muzzleVelocity     = 225.0;
   totalTime          = 2;
   liveTime           = 1;
   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = False;
};

//-------------------------------------------------------------------------------------------
// Item Data Blocks:
//-------------------------------------------------------------------------------------------
ItemData DiscAmmo {
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DiscLauncherImage {
	shapeFile = "disc";
	mountPoint = 0;
	weaponType = 0;
	ammoType = DiscAmmo;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher {
	description = "Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHeading[BulletWeapons];
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function DiscLauncherImage::onFire(%player, %slot){
	%clientId = Player::getClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	if($WeaponMode[%clientId, DiscLauncher] == "Spreader_Projectile"){
		for(%i = 0; %i < 3; %i += 1) Projectile::spawnProjectile("DiscSpreader", %trans, %player, %vel);
		return;
	}
	else if($WeaponMode[%clientId, DiscLauncher] == "Invisible_Projectile") Projectile::spawnProjectile("DiscInvisible", %trans, %player, %vel);
	else if($WeaponMode[%clientId, DiscLauncher] == "") Projectile::spawnProjectile("DiscShell", %trans, %player, %vel);
}

function DiscLauncher::onUse(%player, %item)
{ Weapon::onUse(%player, %item); }
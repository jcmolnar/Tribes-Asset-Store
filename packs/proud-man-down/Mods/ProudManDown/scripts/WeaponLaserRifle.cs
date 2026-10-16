//Mod by BuLeTz/Sahb. Not to be modded without my permission. Contact me at BuLeTz@hotmail.com to be granted permission.
//--------------------------------------
$SellAmmo[SniperAmmo] = 5;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackItems[2] = DiscAmmo;
$WeaponAmmo[LaserRifle] = DiscAmmo;

//--------------------------------------

$InvList[LaserRifle] = 1;
$InvList[DiscAmmo] = 1;
$RemoteInvList[LaserRifle] = 1;
$RemoteInvList[DiscAmmo] = 1;

//-------------------------------------
BulletData sniperBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 4.7;
   damageType         = $LaserDamageType;

   aimDeflection      = 0.00;
   muzzleVelocity     = 960.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
//--------------------------------------

ItemData SniperAmmo
{
	description = "SniperRifle Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};


ItemImageData LaserRifleImage
{
	shapeFile = "sniper";//B
	mountPoint = 0;//U

	mountOffset = { 0, -0.4, 0.1 };//L
	mountRotation = {0, 3.1, 0 };//E	

	weaponType = 0; // Single Shot//T
	projectileType = SniperBullet;//Z
	ammoType = SniperAmmo;
	accuFire = True;
//	reloadTime = 3.0;
	fireTime = 0.5;
	
	lightType = 3; // Weapon Fire
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 1.0, 0.7, 0.5 };

	sfxFire = SniperFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
	sfxReady = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "plasma";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 250;
	showWeaponBar = true;
};

ItemImageData LaserRifleScopeImage
{
	shapeFile  = "force";
	mountPoint = 0;
	mountRotation = { 1.5, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, -0.10, 0.138 };

	ammoType = DiscAmmo;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = SniperFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifleScope
{
	heading = "cSecondary Weapons";
	description = "SniperScope";
	className = "Weapon";
	shapeFile  = "force";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = LaserRifleScopeImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData LaserRifleClipImage
{
	shapeFile  = "energygun";
	mountPoint = 0;
	mountOffset = { 0, -0.6, 0.1 };
	mountRotation = {0, 3.1, 0 };

	weaponType = 0; // Single Shot
	ammoType = EagleAmmo;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = SniperFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifleClip
{
	heading = "cSecondary Weapons";
	description = "SniperRifleClip";
	className = "Weapon";
	shapeFile  = "shotgun";
	hudIcon = "sniper";
	shadowDetailMask = 4;
	imageType = LaserRifleClipImage;
	price = 50;
	showWeaponBar = true;
};


function LaserRifle::onMount(%player,%item)
{
	Player::MountItem(%player,LaserRifleScope,7);
	Player::MountItem(%player,LaserRifleClip,6);
}
function LaserRifle::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
}

 function LaserRifleImage::onFire(%player,%slot) 
{
//Player::applyImpulse(%this,%mom);
GameBase::playSound(%player,SoundPlayerInjure,0);
}
//--------------------------------------
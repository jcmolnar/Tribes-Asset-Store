//--------------------------------------

$AutoUse[SD] = True;
$SellAmmo[BulletAmmo] = 25;
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackItems[0] = BulletAmmo;
$WeaponAmmo[SD] = BulletAmmo;

//--------------------------------------

$InvList[SD] = 1;
$InvList[BulletAmmo] = 1;
$RemoteInvList[SD] = 1;
$RemoteInvList[BulletAmmo] = 1;

//--------------------------------------

BulletData SDBullet
{
   bulletShapeName    = "Rocket.dts";
   validateShape      = true;
   explosionTag       = LargeShockwave;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $electricityDamageType;

   aimDeflection      = 0.000;
   muzzleVelocity     = 20000.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1;
   tracerLength       = 1;
   soundId = SoundElfFire;
};

//--------------------------------------

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData SDImage
{
	shapeFile = "Sniper";
	mountPoint = 0;
                mountoffset = { 0, 0, 0.2 };
                mountrotation = { 0, 3, 0 };
	weaponType = 0; // Single Shot
	reloadTime = 1;
	fireTime = 1;
	
	projectileType = SDBullet;
	accuFire = true;

	
	
	sfxFire = SoundElfFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
                sfxReady = SoundTankIdle;
};

ItemData SD
{
	description = "Gorga's Rifle";
	className = "Weapon";
	shapeFile = "Sniper";
   validateShape = true;
	hudIcon = "chain";
   heading = "bRocket Launchers";
	shadowDetailMask = 4;
	imageType = SDImage;
	price = 125;
	showWeaponBar = true;
};

//--------------------------------------
function SD::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Gorga's Rifle was invented by me ideas were for one kick ass rifle. The bullet actually punctures the sound barrier with so much force it creates a shock wave.", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
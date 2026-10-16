//--------------------------------------

$AutoUse[TargetingLaser] = False;

//--------------------------------------

$InvList[TargetingLaser] = 1;
$RemoteInvList[TargetingLaser] = 1;

//--------------------------------------

TargetLaserData targetLaser
{
   laserBitmapName   = "LaserPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

//--------------------------------------

ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "rHaCk's Tools";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

//--------------------------------------
function TargetingLaser::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Targeting Laser...Don't you feel special :).", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
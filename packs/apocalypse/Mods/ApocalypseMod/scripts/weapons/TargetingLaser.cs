//--------------------------------------

$AutoUse[TargetingLaser] = False;

addToInv(TargetingLaser,1,1);

setArmorItemMax(TargetingLaser,1,1,1,1,1,1,1, 1, 0,0,0,0);

//--------------------------------------

TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange	     = 2.0;
   lightColor	     = { 0.25, 1.0, 0.25 };

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
   heading = $InvCatTools;
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price	      = 50;
	showWeaponBar = false;
};

$MountMSG[TargetingLaser] = "<JC><F2>Targeting Laser <F0>- <F1>will give teammates a target to shot at.";

//AddWeapon(TargetingLaser);

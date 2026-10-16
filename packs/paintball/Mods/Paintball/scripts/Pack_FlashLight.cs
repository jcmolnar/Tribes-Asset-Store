//-projectile
TargetLaserData FlashLightWhite
{
   laserBitmapName   = "bar00.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 9.0;
   lightColor        = { 1.0, 1.0, 1.0 };

   detachFromShooter = true;
};

TargetLaserData FlashLightRed
{
   laserBitmapName   = "bar00.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 9.0;
   lightColor        = { 1.0, 0.0, 0.0 };

   detachFromShooter = true;
};

TargetLaserData FlashLightYellow
{
   laserBitmapName   = "bar00.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 9.0;
   lightColor        = { 1.0, 1.0, 0.0 };

   detachFromShooter = true;
};

TargetLaserData FlashLightGreen
{
   laserBitmapName   = "bar00.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 9.0;
   lightColor        = { 0.0, 1.0, 0.0 };

   detachFromShooter = true;
};

TargetLaserData FlashLightTeal
{
   laserBitmapName   = "bar00.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 9.0;
   lightColor        = { 0.0, 1.0, 1.0 };

   detachFromShooter = true;
};

TargetLaserData FlashLightBlue
{
   laserBitmapName   = "bar00.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 9.0;
   lightColor        = { 0.0, 0.0, 1.0 };

   detachFromShooter = true;
};

TargetLaserData FlashLightPink
{
   laserBitmapName   = "bar00.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 9.0;
   lightColor        = { 1.0, 0.0, 1.0 };

   detachFromShooter = true;
};

//----------
ItemImageData FLPackImage 
{
	shapeFile = "shieldpack";
	mountPoint = 2;
	weaponType = 2;
	projectileType = "FlashLight" @ $PB::FLightColor;
	minEnergy = 0.00000001;
	maxEnergy = 0.0000001;
	reloadTime = 0.2;
	//sfxFire = SoundELFIdle;
	lightType = 0;   
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 10, 10, 10 };
};

ItemData FLPack
{
  description = "Flash Light";
  shapeFile = "paintgun";
  className = "Backpack";
  heading = eBackpacks;
  shadowDetailMask = 4;
  imageType = FLPackImage;
  price = 50;
  hudIcon = "paintgun";
  showWeaponBar = true;
  hiliteOnActive = true;
};

$ItemMax[larmor, FLPack] = 1;
$ItemMax[lfemale, FLPack] = 1;
$InvList[FLPack] = 1;
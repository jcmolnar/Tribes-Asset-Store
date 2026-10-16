//-projectile
TargetLaserData LaserPointer
{
   laserBitmapName   = "laserpulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.0, 0.0 };

   detachFromShooter = false;
};

//----------
ItemImageData TLPackImage 
{
	shapeFile = "shieldpack";
	mountPoint = 2;
	weaponType = 2;
	projectileType = LaserPointer;
	minEnergy = 0.00000001;
	maxEnergy = 0.0000001;
	reloadTime = 0.2;
	//sfxFire = SoundELFIdle;
	lightType = 0;   
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 10, 10, 10 };
};

ItemData TLPack 
{
  description = "Laser Sight";
  shapeFile = "paintgun";
  className = "Backpack";
  heading = eBackpacks;
  shadowDetailMask = 4;
  imageType = TLPackImage;
  price = 80;
  hudIcon = "paintgun";
  showWeaponBar = true;
  hiliteOnActive = true;
};

//Invo Stuff
$ItemMax[larmor, TLPack] = 1;
$ItemMax[lfemale, TLPACK] = 1;
$InvList[TLPACK] = 1;
//Indalacio Weapon
//--------------------------------------

$AutoUse[DeathPoint] = True;
$WeaponAmmo[DeathPoint] = "";
//--------------------------------------

$InvList[DeathPoint] = 0;
$RemoteInvList[DeathPoint] = 0;

//--------------------------------------

LaserData DeathLaser
{
   laserBitmapName   = "paintpulse.bmp";
   hitName           = "shockwave_large.dts";

   damageConversion  = 500.0;
   baseDamageType    = $LaserDamageType;

   beamTime          = 10;

   lightRange        = 12.0;
   lightColor        = { 1, 0, 0 };

   detachFromShooter = true;
   hitSoundId        = SoundTankCrash;
};


//++++++++++++++++++++++++++++++++++++++


$ItemMax[larmor, DeathPoint] = 0;
$ItemMax[lfemale, DeathPoint] = 0;
$ItemMax[marmor, DeathPoint] = 0;
$ItemMax[mfemale, DeathPoint] = 0;
$ItemMax[harmor, DeathPoint] = 0;

//++++++++++++++++++++++++++++++++++++++

//+++++++++++++++++++++++++++++++++++++++


ItemImageData DeathPointImage 
{
	shapeFile = "plastrail";
	mountPoint = 0;
	mountOffset = { 0, 0, 0};
	mountRotation = { 0, 3.14159, 0 };
	weaponType = 0;
	accuFire = true;
	projectileType = DeathLaser;
	reloadTime = 1.0;
	fireTime = 1.0;
	minEnergy = 20;
	maxEnergy = 20;

	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData DeathPoint
{
	description = "Death Point";
	className = "Weapon";
	shapeFile = "fusionex";
	hudIcon = "plasma";
        heading = "yIndalacios Weapons";
	shadowDetailMask = 4;
	imageType = DeathPointImage;
   validateShape = false;
   validateMaterials = false;
	price = 2500;
	showWeaponBar = true;
};

//--------------------------------------



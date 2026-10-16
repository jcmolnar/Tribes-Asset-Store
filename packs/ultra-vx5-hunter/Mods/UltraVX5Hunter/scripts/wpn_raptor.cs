//================================================================
// Raptor Rifle 
//================================================================

SoundData SoundFireRaptor
{
   wavFileName = "teleport2.wav";
   profile = Profile3dNear;
};

SoundData ExplosionRaptor
{
   wavFileName = "laserhit.wav";
   profile = Profile3dNear;
};

//================================================================
LaserData RaptorProj
{
   laserBitmapName   = "paintpulse.bmp";
   hitName           = "paint.dts";

   damageConversion  = 10.0;
   baseDamageType    = $RlaserDamageType;


   beamTime          = 0.35;

   //lightRange        = 1.0;
   //lightColor        = { 0.0, 1.0, 0.0 };

   detachFromShooter = false;
   hitSoundId        = ExplosionRaptor;
};
//================================================================
ItemImageData LaserRifleImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = RaptorProj;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.01;
	minEnergy = 0.01;
	maxEnergy = 0.01;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 1;
	//lightTime = 1;
	//lightColor = { 0, 1, 0 };

	sfxFire = SoundFireRaptor;
	sfxActivate = SoundPickupWeapon;
};

ItemData LaserRifle
{
	description = "Raptor Rifle";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "sniper";
   	heading = "TWeapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 0;
	//showWeaponBar = true;
	showInventory = true;
  	//validateShape = true;
	//validateMaterials = true;
};


ItemImageData RaptorRifleImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = RaptorProj;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.01;
	minEnergy = 0.01;
	maxEnergy = 0.01;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 1;
	//lightTime = 1;
	//lightColor = { 0, 1, 0 };

	sfxFire = SoundFireRaptor;
	sfxActivate = SoundPickupWeapon;
};

ItemData RaptorRifle
{
	description = "Raptor Rifle";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "sniper";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RaptorRifleImage;
	price = 0;
	//showWeaponBar = true;
	showInventory = true;
  	//validateShape = true;
	//validateMaterials = true;
};

//=================================================================
echo("Item Loaded");
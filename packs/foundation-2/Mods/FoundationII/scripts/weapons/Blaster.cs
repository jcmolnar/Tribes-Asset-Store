//--------------------------------------

$AutoUse[Blaster] = True;
$Use[Blaster] = True;
$WeaponAmmo[Blaster] = "";

addToInv(Blaster,1,1);

setArmorItemMax(Blaster,1,1,1);

//--------------------------------------

BulletData BlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass	      = 0;
   damageValue	      = 0.125;
   damageType	      = $BlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime	      = 2.0;
   liveTime	      = 1.125;

   lightRange	      = 3.0;
   lightColor	      = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible	      = True;

   rotationPeriod = 1;
};

//--------------------------------------

ItemImageData BlasterImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.3;
	minEnergy = 5;
	maxEnergy = 6;

	projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = $InvCatWeapons[All];
	description = "Blaster";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 85;
	showWeaponBar = true;
};

$MountMSG[Blaster] = "<JC><F2>Blaster <F0>- <F1>Fire small energy bolts at your enemies.";

AddWeapon(Blaster);

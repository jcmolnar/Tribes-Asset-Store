//--------------------------------------

$AutoUse[PlasmaGun] = True;
addAmmo(PlasmaGun,PlasmaAmmo,5,30);

addToInv(PlasmaGun,1,1);
addToInv(PlasmaAmmo,1,1);

setArmorItemMax(PlasmaGun,1,1,1,1,1,1,1, 1, 0,0,0,0);
setArmorItemMax(PlasmaAmmo,30,30,40,40,40,50,50, 99, 0,0,0,0);

//--------------------------------------

BulletData PlasmaBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp0;

   damageClass	      = 1;
   damageValue	      = 0.45;
   damageType	      = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 55.0;
   totalTime	      = 3.0;
   liveTime	      = 2.0;
   lightRange	      = 3.0;
   lightColor	      = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible	      = True;

   soundId = SoundJetLight;
};

//--------------------------------------


ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
   heading = $InvCatAmmo;
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;	// Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = $InvCatWeapons[All];
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
   validateShape = true;
};

$MountMSG[PlasmaGun] = "<JC><F2>Plasma Gun <F0>- <F1>Fires balls of superheated plasma.";

AddWeapon(PlasmaGun);

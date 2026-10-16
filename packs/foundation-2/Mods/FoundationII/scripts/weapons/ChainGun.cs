//--------------------------------------

$AutoUse[Chaingun] = True;
addAmmo(Chaingun,BulletAmmo,25,150);

addToInv(Chaingun,1,1);
addToInv(BulletAmmo,1,1);

setArmorItemMax(Chaingun,1,1,1);
setArmorItemMax(BulletAmmo,100,150,200);

//--------------------------------------

BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass 	      = 0.05;
   bulletHoleIndex    = 0;

   damageClass	      = 0;	 // 0 impact, 1, radius
   damageValue	      = 0.1;
   damageType	      = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime	      = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible	      = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//----------------------------------------------------------------------------

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = $InvCatAmmo;
	shadowDetailMask = 4;
	price = 1;
};

//--------------------------------------

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.1;

	ammoType = BulletAmmo;
	projectileType = ChaingunBullet;
	accuFire = false;

	lightType = 3;	// Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Chaingun
{
	description = "Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "chain";
   heading = $InvCatWeapons[All];
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

$MountMSG[Chaingun] = "<JC><F2>Chaingun <F0>- <F1>Fires at a fast rate and deals moderate damage.";

AddWeapon(Chaingun);

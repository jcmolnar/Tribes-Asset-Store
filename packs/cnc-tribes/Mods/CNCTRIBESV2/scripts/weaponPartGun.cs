//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Particle Accelerator
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$WeaponAmmo[PartGun] = "";
$InvList[PartGun] = 1;
$AutoUse[PartGun] = False;
$RemoteInvList[PartGun] = 1;

addWeapon(PartGun);

//=====================================================================//=== PartGun Bolt

BulletData PartBolt
{
   bulletShapeName    = "paint.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.05;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 1.0;
   liveTime           = 1.0;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//=====================================================================//=== Particle Pistol

ItemImageData PartGunImage
{
   shapeFile  = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0.05;
	fireTime = 0.05;
	minEnergy = 5;
	maxEnergy = 6;

	projectileType = PartBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData PartGun
{
   heading = $InvHead[ihWea];
	description = "Particle Accelerator";
	className = "Weapon";
   shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = PartGunImage;
	price = 285;
	showWeaponBar = true;
};


function PartGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Particle Accelerator: A product of a Eldar/Marine alliance versus the Tyranids, this pistol is extremely effective at decimating targets in short order.");
}
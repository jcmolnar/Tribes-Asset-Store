$DamageScale[larmor, $SpikeDamageType] = 100000.0;
$DamageScale[lfemale, $SpikeDamageType] = 10000.0;
$DamageScale[marmor, $SpikeDamageType] = 10000.0;
$DamageScale[harmor, $SpikeDamageType] = 1000.0;
$DamageScale[mfemale, $SpikeDamageType] = 1000.0;
$DamageScale[indalacioarmor, $SpikeDamageType] = 100.0;
//----Muahahahhahahahahah

//--------------------------------------


$AutoUse[SpikeRifle] = True;
$SellAmmo[SpikeRifleAmmo] = 5;
$AmmoPackMax[SpikeRifleAmmo] = 30;
$AmmoPackItems[1] = SpikeRifleAmmo;
$WeaponAmmo[SpikeRifle ] = SpikeRifleAmmo;
//--------------------------------------

$InvList[SpikeRifle] = 1;
$InvList[SpikeRifleAmmo] = 1;
$RemoteInvList[SpikeRifle] = 1;
$RemoteInvList[SpikeRifleAmmo] = 1;

//--------------------------------------

BulletData SpikeRifleBullet
{
   bulletShapeName    = "mine.dts";
   validateShape      = false;
   explosionTag       = SpikeStick;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 20;
   damageType         = $SpikeDamageType;

   aimDeflection      = 0;
   muzzleVelocity     = 1000.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;

};

//++++++++++++++++++++++++++++++++++++++


$ItemMax[larmor, SpikeRifle] = 1;
$ItemMax[lfemale, SpikeRifle] = 1;
$ItemMax[marmor, SpikeRifle] = 0;
$ItemMax[mfemale, SpikeRifle] = 0;
$ItemMax[harmor, SpikeRifle] = 0;

//++++++++++++++++++++++++++++++++++++++

$ItemMax[larmor, SpikeRifleAmmo] = 25;
$ItemMax[lfemale, SpikeRifleAmmo] = 25;
$ItemMax[marmor, SpikeRifleAmmo] = 0;
$ItemMax[mfemale, SpikeRifleAmmo] = 0;
$ItemMax[harmor, SpikeRifleAmmo] = 0;

//+++++++++++++++++++++++++++++++++++++++



ItemData SpikeRifleAmmo 
{
	description = "Tripod Spike  Pellets";
	className = "Ammo";
	heading = xAmmunition;
	shapeFile = "mine";
	shadowDetailMask = 4;
	price = 17;
};

ItemImageData SpikeRifleImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0, 0};
	mountRotation = { 0, 3.14159, 0 };
	weaponType = 0;
	ammoType = SpikeRifleAmmo;
	projectileType = SpikeRifleBullet;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.7;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = rocketExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData SpikeRifle
{
	description = "Spike Rifle";
	className = "Weapon";
	shapeFile = "sniper";  
	hudIcon = "sniper";
	heading = bWeapons;
	shadowDetailMask = 4;
	imageType = SpikeRifleImage;
   	validateShape = false;
   	validateMaterials = false;
	price = 78000;
	showWeaponBar = true;
};

function SpikeRifle::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Fires a spike ball.......Im sure u know who its for.... :)");
}

//--------------------------------------

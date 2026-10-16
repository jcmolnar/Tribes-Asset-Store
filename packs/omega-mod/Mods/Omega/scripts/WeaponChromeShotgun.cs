//--------------------------------------

$AutoUse[ChromeShotgun] = True;
$SellAmmo[ChromeShotgunAmmo] = 5;
$AmmoPackMax[ChromeShotgunAmmo] = 30;
$AmmoPackItems[1] = ChromeShotgunAmmo;
$WeaponAmmo[ChromeShotgun] = ChromeShotgunAmmo;
//--------------------------------------

$InvList[ChromeShotgun] = 1;
$InvList[ChromeShotgunAmmo] = 1;
$RemoteInvList[ChromeShotgun] = 1;
$RemoteInvList[ChromeShotgunAmmo] = 1;

//--------------------------------------

BulletData CSBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = CBulletExp;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $CSDamageType;

   aimDeflection      = 0.01;
   muzzleVelocity     = 700.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//++++++++++++++++++++++++++++++++++++++


$ItemMax[larmor, ChromeShotgun] = 1;
$ItemMax[lfemale, ChromeShotgun] = 1;
$ItemMax[marmor, ChromeShotgun] = 1;
$ItemMax[mfemale, ChromeShotgun] = 1;
$ItemMax[harmor, ChromeShotgun] = 1;

//++++++++++++++++++++++++++++++++++++++

$ItemMax[larmor, ChromeShotgunAmmo] = 15;
$ItemMax[lfemale, ChromeShotgunAmmo] = 15;
$ItemMax[marmor, ChromeShotgunAmmo] = 30;
$ItemMax[mfemale, ChromeShotgunAmmo] = 30;
$ItemMax[harmor, ChromeShotgunAmmo] = 40;

//+++++++++++++++++++++++++++++++++++++++



ItemData ChromeShotgunAmmo 
{
	description = "Chrome Shells";
	className = "Ammo";
	heading = xAmmunition;
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData ChromeShotgunImage 
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0};
	mountRotation = { 0, 3.14159, 0 };
	weaponType = 0;
	ammoType = ChromeShotgunAmmo;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.5;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData ChromeShotgun
{
	description = "Chrome Shotgun";
	className = "Weapon";
	shapeFile = "Mortar";
	hudIcon = "mortar";
	heading = bWeapons;
	shadowDetailMask = 4;
	imageType = ChromeShotgunImage;
   validateShape = false;
   validateMaterials = false;
	price = 700;
	showWeaponBar = true;
};

function ChromeShotgunImage::onFire(%player,%slot)
{
	for(%i = 0; %i < 16; %i++)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("CSBullet",%trans,%player,%vel);
	}
	Player::decItemCount(%player,$WeaponAmmo[ChromeShotgun],1);
}

function ChromeShotgun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "This is a shotgun that was made of almost completely chrome. And so are the shells for the weapon. These shells are fast, do heavy damage and hae little aim deflection. Also this gun has a very little reload time, making it a fast killer..");
}

//--------------------------------------
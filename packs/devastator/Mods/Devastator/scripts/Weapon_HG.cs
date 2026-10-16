//--------------------------------------
BulletData HGBolt
{
   bulletShapeName    = "discb.dts";
   explosionTag       = energyExp;
   mass               = 0.5;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $HGDamageType;

   aimDeflection      = 0.002;
   muzzleVelocity     = 100.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
   rotationPeriod = 7;
};

ItemData HGAmmo
{
	description = "Hostage Gun Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData HGImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountRotation = { 0, 3, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	reloadTime = 0.3;
	fireTime = 0.3;
	ammoType = HGAmmo;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundELFFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HG
{
	description = "Hostage Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   	heading = "cAmmo-Based Weapons";
	shadowDetailMask = 4;
	imageType = HGImage;
	price = 125;
	showWeaponBar = true;
};

function HGImage::onFire(%player, %slot)
{
	if(Player::getItemCount(%player,$WeaponAmmo[HG]) > 0) {
		Weapon::onFire(%player,HGBolt,False);
		Weapon::onFire(%player,HGBolt);
	}
}

$ItemMax[larmor, HG] = 0;
$ItemMax[qarmor, HG] = 0;
$ItemMax[srarmor, HG] = 0;
$ItemMax[sarmor, HG] = 1;
$ItemMax[marmor, HG] = 1;
$ItemMax[parmor, HG] = 0;
$ItemMax[harmor, HG] = 0;
$ItemMax[tarmor, HG] = 0;
$ItemMax[psarmor, HG] = 0;
$ItemMax[psfemale, HG] = 0;
$ItemMax[IceMor, HG] = 1;
$ItemMax[lfemale, HG] = 0;
$ItemMax[qfemale, HG] = 0;
$ItemMax[srfemale, HG] = 0;
$ItemMax[sfemale, HG] = 1;
$ItemMax[mfemale, HG] = 1;
$ItemMax[pfemale, HG] = 0;

$ItemMax[larmor, HGAmmo] = 10;
$ItemMax[qarmor, HGAmmo] = 10;
$ItemMax[srarmor, HGAmmo] = 10;
$ItemMax[sarmor, HGAmmo] = 10;
$ItemMax[marmor, HGAmmo] = 10;
$ItemMax[parmor, HGAmmo] = 10;
$ItemMax[harmor, HGAmmo] = 10;
$ItemMax[tarmor, HGAmmo] = 10;
$ItemMax[psarmor, HGAmmo] = 10;
$ItemMax[psfemale, HGAmmo] = 10;
$ItemMax[lfemale, HGAmmo] = 10;
$ItemMax[qfemale, HGAmmo] = 10;
$ItemMax[srfemale, HGAmmo] = 10;
$ItemMax[sfemale, HGAmmo] = 10;
$ItemMax[mfemale, HGAmmo] = 10;
$ItemMax[pfemale, HGAmmo] = 10;

$AutoUse[HG] = True;
$SellAmmo[HGAmmo] = 2;
$WeaponAmmo[HG] = HGAmmo;
$InvList[HG] = 1;
$RemoteInvList[HG] = 1;
$InvList[HGAmmo] = 1;
$RemoteInvList[HGAmmo] = 1;

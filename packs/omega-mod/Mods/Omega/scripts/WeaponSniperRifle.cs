//--------------------------------------

$AutoUse[SR] = True;
$SellAmmo[SRAmmo] = 5;
$AmmoPackMax[SRAmmo] = 30;
$AmmoPackItems[1] = SRAmmo;
$WeaponAmmo[SR] = SRAmmo;
//--------------------------------------

$InvList[SR] = 1;
$InvList[SRAmmo] = 1;
$RemoteInvList[SR] = 1;
$RemoteInvList[SRAmmo] = 1;

//--------------------------------------

BulletData SRBullet
{
   bulletShapeName    = "chainspk.dts";
   validateShape      = true;
   explosionTag       = SBulletExp;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $SRDamageType;

   aimDeflection      = 0;
   muzzleVelocity     = 1000.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

};

//++++++++++++++++++++++++++++++++++++++


$ItemMax[larmor, SR] = 1;
$ItemMax[lfemale, SR] = 1;
$ItemMax[marmor, SR] = 0;
$ItemMax[mfemale, SR] = 0;
$ItemMax[harmor, SR] = 0;

//++++++++++++++++++++++++++++++++++++++

$ItemMax[larmor, SRAmmo] = 25;
$ItemMax[lfemale, SRAmmo] = 25;
$ItemMax[marmor, SRAmmo] = 0;
$ItemMax[mfemale, SRAmmo] = 0;
$ItemMax[harmor, SRAmmo] = 0;

//+++++++++++++++++++++++++++++++++++++++



ItemData SRAmmo 
{
	description = "7.62mm Shells";
	className = "Ammo";
	heading = xAmmunition;
	shapeFile = "discammo";
	shadowDetailMask = 4;
	price = 17;
};

ItemImageData SRImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0, 0};
	mountRotation = { 0, 1.570795, 0 };
	weaponType = 0;
	ammoType = SRAmmo;
	projectileType = SRBullet;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.7;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData SR
{
	description = "Sniper Rifle";
	className = "Weapon";
	shapeFile = "Mortar";
	hudIcon = "sniper";
	heading = bWeapons;
	shadowDetailMask = 4;
	imageType = SRImage;
   	validateShape = false;
   	validateMaterials = false;
	price = 1400;
	showWeaponBar = true;
};

function SR::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "This sniper rifle fires an extreamly high speed bullet that will reach its target almost upon firing. The shell will kill anyone and just about anything in 1 - 3 shots..");
}

//--------------------------------------
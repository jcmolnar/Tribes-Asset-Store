//--------------------------------------

$AutoUse[RazorChaingun] = True;
$SellAmmo[RazorChaingunAmmo] = 50;
$AmmoPackMax[RazorChaingunAmmo] = 150;
$AmmoPackItems[1] = RazorChaingunAmmo;
$WeaponAmmo[RazorChaingun] = RazorChaingunAmmo;
//--------------------------------------

$InvList[RazorChaingun] = 1;
$InvList[RazorChaingunAmmo] = 1;
$RemoteInvList[RazorChaingun] = 1;
$RemoteInvList[RazorChaingunAmmo] = 1;

//--------------------------------------

BulletData RazorChaingunBullet
{
   bulletShapeName    = "staff.dts";
   validateShape      = false;
   explosionTag       = CBulletExp;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $RazorDamageType;

   aimDeflection      = 0.0025;
   muzzleVelocity     = 700.0;
   totalTime          = 2.0;
   inheritedVelocityScale = 1.0;
   isVisible          = true;

};

// <<><><><><><><><<><>><>>>>>>>>>><<<<<<<<>Armor Data Shit<>><><><><><<><><><


$ItemMax[larmor, RazorChaingun] = 1;
$ItemMax[lfemale, RazorChaingun] = 1;
$ItemMax[marmor, RazorChaingun] = 1;
$ItemMax[mfemale, RazorChaingun] = 1;
$ItemMax[harmor, RazorChaingun] = 0;

//++++++++++++++++++++++++++++++++++++++

$ItemMax[larmor, RazorChaingunAmmo] = 125;
$ItemMax[lfemale, RazorChaingunAmmo] = 125;
$ItemMax[marmor, RazorChaingunAmmo] = 250;
$ItemMax[mfemale, RazorChaingunAmmo] = 250;
$ItemMax[harmor, RazorChaingunAmmo] = 0;


$DamageScale[larmor, $RazorDamageType] = 1;
$DamageScale[lfemale, $RazorDamageType] = 1;
$DamageScale[marmor, $RazorDamageType] = 1;
$DamageScale[mfemale, $RazorDamageType] = 1;
$DamageScale[harmor, $RazorDamageType] = 1;

//+++++++++++++++++++++++++++++++++++++++



ItemData RazorChaingunAmmo 
{
	description = "Utility Razors";
	className = "Ammo";
	heading = xAmmunition;
	shapeFile = "staff";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData RazorChaingunImage 
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0};
	mountRotation = { 0, 1.570795, 0 };
	weaponType = 0;
	ammoType = RazorChaingunAmmo;
	projectileType = RazorChaingunBullet;
	accuFire = true;
	reloadTime = 0.01;
	fireTime = 0.01;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.5, 0.5, 0 };
	sfxFire =  SoundPDAButtonHard;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData RazorChaingun
{
	description = "Razor chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "sensorjammerpack";
	heading = bWeapons;
	shadowDetailMask = 4;
	imageType = RazorChaingunImage;
   	validateShape = false;
   	validateMaterials = false;
	price = 700;
	showWeaponBar = true;
};

function RazorChaingun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "This chaingun fires razors that can cut through the enemies armor. A very fast firing chaingun ensures a quick kill.");
}

//--------------------------------------
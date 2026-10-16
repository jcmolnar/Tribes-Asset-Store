//--------------------------------------

$AutoUse[HM] = True;
$SellAmmo[HMAmmo] = 5;
$AmmoPackMax[HMAmmo] = 30;
$AmmoPackItems[1] = HMAmmo;
$WeaponAmmo[HM] = HMAmmo;
//--------------------------------------

$InvList[HM] = 1;
$InvList[HMAmmo] = 1;
$RemoteInvList[HM] = 1;
$RemoteInvList[HMAmmo] = 1;

//--------------------------------------
//----
GrenadeData HealingMortar 
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = HealthExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.2;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = -100.5;

   explosionRadius    = 20;
   kickBackStrength   = 30.0;
   maxLevelFlightDist = 600;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 5.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "dustplume.dts";
};


//++++++++++++++++++++++++++++++++++++++


$ItemMax[larmor, HM] = 0;
$ItemMax[lfemale, HM] = 0;
$ItemMax[marmor, HM] = 1;
$ItemMax[mfemale, HM] = 1;
$ItemMax[harmor, HM] = 0;

//++++++++++++++++++++++++++++++++++++++

$ItemMax[larmor, HMAmmo] = 0;
$ItemMax[lfemale, HMAmmo] = 0;
$ItemMax[marmor, HMAmmo] = 20;
$ItemMax[mfemale, HMAmmo] = 20;
$ItemMax[harmor, HMAmmo] = 0;

//+++++++++++++++++++++++++++++++++++++++



ItemData HMAmmo 
{
	description = "Healing Shells";
	className = "Ammo";
	heading = xAmmunition;
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 17;
};

ItemImageData HMImage 
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0};
	mountRotation = { 0, 1.570795, 0 };
	weaponType = 0;
	ammoType = HMAmmo;
	projectileType = HealingMortar;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 1.0;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundPackFail;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HM
{
	description = "Healing Mortar";
	className = "Weapon";
	shapeFile = "plasmabolt";
	hudIcon = "deployable";
	heading = bWeapons;
	shadowDetailMask = 4;
	imageType = HMImage;
   	validateShape = false;
   	validateMaterials = false;
	price = 200;
	showWeaponBar = true;
};

function HM::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "This gun fires a mortar the heals, doesnt do damage. Great for repairing many things at once");
}

//--------------------------------------
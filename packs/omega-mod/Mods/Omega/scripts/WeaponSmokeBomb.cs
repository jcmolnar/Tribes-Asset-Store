//--------------------------------------

$AutoUse[SmokyHands] = True;
$SellAmmo[SmokyHandsAmmo] = 5;
$AmmoPackMax[SmokyHandsAmmo] = 30;
$AmmoPackItems[1] = SmokyHandsAmmo;
$WeaponAmmo[SmokyHands] = SmokyHandsAmmo;
//--------------------------------------

$InvList[SmokyHands] = 1;
$InvList[SmokyHandsAmmo] = 1;
$RemoteInvList[SmokyHands] = 1;
$RemoteInvList[SmokyHandsAmmo] = 1;

//--------------------------------------
GrenadeData SmokeBomb
{
   bulletShapeName    = "chainspk.dts";
   explosionTag       = SmokeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.2;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $MortarDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 30;
   totalTime          = 5.0;    // special meaning for grenades...
   liveTime           = 5.0;
   projSpecialTime    = 0.05;

   soundId = SoundELFIdle;
   inheritedVelocityScale = 0.5;

   smokeName              = "lflame.dts";
};

//--------------------------------------


$ItemMax[larmor, SmokyHands] = 1;
$ItemMax[lfemale, SmokyHands] = 1;
$ItemMax[marmor, SmokyHands] = 0;
$ItemMax[mfemale, SmokyHands] = 0;
$ItemMax[harmor, SmokyHands] = 0;

//++++++++++++++++++++++++++++++++++++++

$ItemMax[larmor, SmokyHandsAmmo] = 25;
$ItemMax[lfemale, SmokyHandsAmmo] = 25;
$ItemMax[marmor, SmokyHandsAmmo] = 0;
$ItemMax[mfemale, SmokyHandsAmmo] = 0;
$ItemMax[harmor, SmokyHandsAmmo] = 0;

//+++++++++++++++++++++++++++++++++++++++



ItemData SmokyHandsAmmo 
{
	description = "Smoke Bombs";
	className = "Ammo";
	heading = xAmmunition;
	shapeFile = "chainspk";
	shadowDetailMask = 4;
	price = 17;
};

ItemImageData SmokyHandsImage 
{
	shapeFile = "snowplume";
	mountPoint = 0;
	mountOffset = { 0, 0, 0};
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	ammoType = SmokyHandsAmmo;
	projectileType = SmokeBomb;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 1.0;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundThrowItem;
	sfxActivate = SoundPickUpWeapon;

};

ItemData SmokyHands
{
	description = "Smoke Bombs";
	className = "Weapon";
	shapeFile = "snowplume";
	hudIcon = "shieldpack";
	heading = zSpecial;
	shadowDetailMask = 4;
	imageType = SmokyHandsImage;
   	validateShape = false;
   	validateMaterials = false;
	price = 40;
	showWeaponBar = true;
};

function SmokyHands::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Cloud em up!!!!!!!");
}

//--------------------------------------
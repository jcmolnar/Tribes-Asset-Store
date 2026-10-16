ExplosionData blackExp
{
	shapeName = "bluex.dts";
	soundId   = rocketExplosion;

	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 8.0;

	timeScale = 1.5;

	timeZero = 0.250;
	timeOne  = 0.850;

	colors[0]  = { 0.4, 0.4,  1.0 };
	colors[1]  = { 1.0, 1.0,  1.0 };
	colors[2]  = { 1.0, 0.95, 1.0 };
	radFactors = { 0.5, 1.0, 1.0 };
};

//--------------------------------------

GrenadeData GRShot1
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = BlackExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 2.0;
   elasticity         = 0.5;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $RPGDamageType;

   explosionRadius    = 4;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 700;
   totalTime          = 15.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;

   smokeName              = "breath.dts";
};

ItemImageData GR1Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { -0.08, 0.6, 0.0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -3.0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData GR1
{
	description = "GR1";
	className = "Weapon";
	shapeFile = "sniper";
	shadowDetailMask = 4;
	imageType = GR1Image;
	showWeaponBar = false;
};

ItemImageData GR2Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0.08, 0.6, 0.0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 3.0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData GR2
{
	description = "GR2";
	className = "Weapon";
	shapeFile = "sniper";
	shadowDetailMask = 4;
	imageType = GR2Image;
	showWeaponBar = false;
};

//----------------------------------------------------------------------------

ItemData GRAmmo
{
	description = "Small RPG's";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GRImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GRAmmo;
	projectileType = GRShot1;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GR
{
	description = "RPG Rifle";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenadeL";
	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = GRImage;
	price =   50;
	showWeaponBar = true;
};

function GR::onMount(%player,%item)
{
	Player::mountItem(%player, GR1, 6);
	Player::mountItem(%player, GR2, 7);
}

function GR::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}

//--------------------------------------------------------------------------------
// INVENTORY STUFF
//--------------------------------------------------------------------------------

$AutoUse[GR] = True;
$InvList[GR] = 1;
$InvList[GRAmmo] = 1;
$RemoteInvList[GR] = 1;
$RemoteInvList[GRAmmo] = 1;

$ItemMax[larmor, GR] = 0;
$ItemMax[larmor, GRAmmo] = 0;
$ItemMax[qarmor, GR] = 1;
$ItemMax[qarmor, GRAmmo] = 10;
$ItemMax[sarmor, GR] = 0;
$ItemMax[sarmor, GRAmmo] = 0;
$ItemMax[srarmor, GR] = 0;
$ItemMax[srarmor, GRAmmo] = 0;
$ItemMax[marmor, GR] = 0;
$ItemMax[marmor, GRAmmo] = 0;
$ItemMax[parmor, GR] = 0;
$ItemMax[parmor, GRAmmo] = 0;
$ItemMax[tarmor, GR] = 0;
$ItemMax[tarmor, GRAmmo] = 0;
$ItemMax[harmor, GR] = 0;
$ItemMax[harmor, GRAmmo] = 0;
$ItemMax[lfemale, GR] = 0;
$ItemMax[lfemale, GRAmmo] = 0;
$ItemMax[qfemale, GR] = 1;
$ItemMax[qfemale, GRAmmo] = 10;
$ItemMax[sfemale, GR] = 0;
$ItemMax[sfemale, GRAmmo] = 0;
$ItemMax[srfemale, GR] = 0;
$ItemMax[srfemale, GRAmmo] = 0;
$ItemMax[mfemale, GR] = 0;
$ItemMax[mfemale, GRAmmo] = 0;
$ItemMax[pfemale, GR] = 0;
$ItemMax[pfemale, GRAmmo] = 0;

$DamageScale[larmor, $ProtonDamageType] = 0.5;
$DamageScale[qarmor, $ProtonDamageType] = 0.5;
$DamageScale[srarmor, $ProtonDamageType] = 1.0;
$DamageScale[sarmor, $ProtonDamageType] = 0.5;
$DamageScale[marmor, $ProtonDamageType] = 0.5;
$DamageScale[parmor, $ProtonDamageType] = 0.5;
$DamageScale[harmor, $ProtonDamageType] = 0.5;
$DamageScale[tarmor, $ProtonDamageType] = 0.5;
$DamageScale[lfemale, $ProtonDamageType] = 0.5;
$DamageScale[qfemale, $ProtonDamageType] = 0.5;
$DamageScale[srfemale, $ProtonDamageType] = 1.0;
$DamageScale[sfemale, $ProtonDamageType] = 0.5;
$DamageScale[mfemale, $ProtonDamageType] = 0.5;
$DamageScale[pfemale, $ProtonDamageType] = 0.5;
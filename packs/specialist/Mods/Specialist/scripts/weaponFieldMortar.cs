$InvList[FieldMortar] = 1;
$InvList[FieldMortarAmmo] = 1;
$RemoteInvList[FieldMortar] = 1;
$RemoteInvList[FieldMortarAmmo] = 1;

$AutoUse[FieldMortar] = True;
$SellAmmo[FieldMortarAmmo] = 5;
$WeaponAmmo[FieldMortar] = FieldMortarAmmo;

// Who can use this weapon
$ItemMax[reconarmor, FieldMortar] = 0;
$ItemMax[reconfemalearmor, FieldMortar] = 0;
$ItemMax[espionagearmor, FieldMortar] = 0;
$ItemMax[espionagefemalearmor, FieldMortar] = 0;
$ItemMax[engineerarmor, FieldMortar] = 0;
$ItemMax[engineerfemalearmor, FieldMortar] = 0;
$ItemMax[infantryarmor, FieldMortar] = 0;
$ItemMax[infantryfemalearmor, FieldMortar] = 0;
$ItemMax[falloutarmor, FieldMortar] = 0;
$ItemMax[falloutfemalearmor, FieldMortar] = 0;
$ItemMax[demolitionsarmor, FieldMortar] = 0;
$ItemMax[assaultarmor, FieldMortar] = 0;
$ItemMax[artilleryarmor, FieldMortar] = 1;
$ItemMax[commanderarmor, FieldMortar] = 0;

// Who can use this ammo (and how much they can carry)
$ItemMax[reconarmor, FieldMortarAmmo] = 0;
$ItemMax[reconfemalearmor, FieldMortarAmmo] = 0;
$ItemMax[espionagearmor, FieldMortarAmmo] = 0;
$ItemMax[espionagefemalearmor, FieldMortarAmmo] = 0;
$ItemMax[engineerarmor, FieldMortarAmmo] = 0;
$ItemMax[engineerfemalearmor, FieldMortarAmmo] = 0;
$ItemMax[infantryarmor, FieldMortarAmmo] = 0;
$ItemMax[infantryfemalearmor, FieldMortarAmmo] = 10;
$ItemMax[falloutarmor, FieldMortarAmmo] = 0;
$ItemMax[falloutfemalearmor, FieldMortarAmmo] = 0;
$ItemMax[demolitionsarmor, FieldMortarAmmo] = 0;
$ItemMax[assaultarmor, FieldMortarAmmo] = 0;
$ItemMax[artilleryarmor, FieldMortarAmmo] = 20;
$ItemMax[commanderarmor, FieldMortarAmmo] = 0;

GrenadeData FieldMortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 345;	// changed in Patch 1.11
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

ItemData FieldMortarAmmo
{
	description = "Field Mortar Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData FieldMortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = FieldMortarAmmo;
	projectileType = FieldMortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData FieldMortar
{
	description = "Field Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FieldMortarImage;
	price = 375;
	showWeaponBar = true;
};


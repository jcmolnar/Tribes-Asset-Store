$InvList[AcidSprayer] = 1;
$RemoteInvList[AcidSprayer] = 1;
$AutoUse[AcidSprayer] = True;

$WeaponAmmo[AcidSprayer] = AcidSprayerAmmo;
$SellAmmo[AcidSprayerAmmo] = 15;
$InvList[AcidSprayerAmmo] = 1;
$RemoteInvList[AcidSprayerAmmo] = 1;

// Don't forget to add weapon into Next and Prev tables in NextWeapon.cs

// Who can use this weapon
$ItemMax[reconarmor, AcidSprayer] = 0;
$ItemMax[reconfemalearmor, AcidSprayer] = 0;
$ItemMax[espionagearmor, AcidSprayer] = 0;
$ItemMax[espionagefemalearmor, AcidSprayer] = 0;
$ItemMax[engineerarmor, AcidSprayer] = 0;
$ItemMax[engineerfemalearmor, AcidSprayer] = 0;
$ItemMax[infantryarmor, AcidSprayer] = 0;
$ItemMax[infantryfemalearmor, AcidSprayer] = 0;
$ItemMax[falloutarmor, AcidSprayer] = 1;
$ItemMax[falloutfemalearmor, AcidSprayer] = 1;
$ItemMax[demolitionsarmor, AcidSprayer] = 0;
$ItemMax[assaultarmor, AcidSprayer] = 0;
$ItemMax[artilleryarmor, AcidSprayer] = 0;
$ItemMax[commanderarmor, AcidSprayer] = 0;

// Who can use this ammo (and how much they can carry)
$ItemMax[reconarmor, AcidSprayerAmmo] = 0;
$ItemMax[reconfemalearmor, AcidSprayerAmmo] = 0;
$ItemMax[espionagearmor, AcidSprayerAmmo] = 0;
$ItemMax[espionagefemalearmor, AcidSprayerAmmo] = 0;
$ItemMax[engineerarmor, AcidSprayerAmmo] = 0;
$ItemMax[engineerfemalearmor, AcidSprayerAmmo] = 0;
$ItemMax[infantryarmor, AcidSprayerAmmo] = 0;
$ItemMax[infantryfemalearmor, AcidSprayerAmmo] = 0;
$ItemMax[falloutarmor, AcidSprayerAmmo] = 80;
$ItemMax[falloutfemalearmor, AcidSprayerAmmo] = 80;
$ItemMax[demolitionsarmor, AcidSprayerAmmo] = 0;
$ItemMax[assaultarmor, AcidSprayerAmmo] = 0;
$ItemMax[artilleryarmor, AcidSprayerAmmo] = 0;
$ItemMax[commanderarmor, AcidSprayerAmmo] = 0;


ExplosionData acidExp
{
   shapeName = "mortartrail.dts";
   // soundId   = SoundJetLight;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0, 0.1, 0 };
   colors[1]  = { 0.25, 0.5, 0.25 };
   colors[2]  = { 0,  1.0,  0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

BulletData Acid
{
	bulletShapeName = "breath.dts";
	explosionTag = acidExp;
	damageClass = 1;
	damageValue = 0.025;
	damageType = $AcidDamageType;
	explosionRadius = 2.0;
	aimDeflection = 0.03;
	muzzleVelocity = 25.0;
	totalTime = 0.7;
	liveTime = 0.7;
	lightRange = 0.2;
	lightColor = { 0, 0.5, 0 };
	inheritedVelocityScale = 0.3;
	isVisible = True;
	soundId = SoundJetLight;
};

ItemData AcidSprayerAmmo
{
	description = "Acid Spray";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 3;
};

ItemImageData AcidSprayerImage 
{
	mountOffset = { 0, 0.15, 0 };
	mountRotation = { 0, 1.6, 0 };

	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 1; // Spinning
	reloadTime = 0.01;
	spinUpTime = 0.1;
	spinDownTime = 0.5;
	fireTime = 0.1;
	ammoType = AcidSprayerAmmo;
	projectileType = Acid;
	accuFire = true;
	lightType = 3;
	lightRadius = 1;
	lightTime = 2;
	lightColor = { 0, 0.5, 0 };
	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AcidSprayer
{
	heading = "bWeapons";
	description = "Acid Sprayer";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = AcidSprayerImage;
	price = 85;
	showWeaponBar = true;
};

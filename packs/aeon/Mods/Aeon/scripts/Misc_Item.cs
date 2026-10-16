//----------------------------------------------------------------------------
// Miscellaneous
//----------------------------------------------------------------------------

ExplosionData look1Exp
{
	shapeName = "shield.dts";

	faceCamera = false;
	randomSpin = false;
	hasLight   = false;

	timeZero = 0.450;
	timeOne  = 0.750;

	colors[0]  = { 0.25, 0.25, 1.0 };
	colors[1]  = { 0.25, 0.25, 1.0 };
	colors[2]  = { 1.0, 1.0,  1.0 };
	radFactors = { 1.0, 1.0,  1.0 };

	shiftPosition = false;
};

BulletData look1
{
	bulletShapeName    = "breath.dts";
	validateShape      = true;
	explosionTag       = look1Exp;
	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.0;
	damageType         = $BulletDamageType;
	muzzleVelocity     = 1000.0;
	totalTime          = 0.05;
	lightRange         = 0.0;
	lightColor         = { 0, 0, 0 };
	inheritedVelocityScale = 0;
	isVisible          = False;
};

ExplosionData lookExp
{
	shapeName = "breath.dts";

	faceCamera = false;
	randomSpin = false;
	hasLight   = false;

	timeZero = 0.450;
	timeOne  = 0.750;

	colors[0]  = { 0.25, 0.25, 1.0 };
	colors[1]  = { 0.25, 0.25, 1.0 };
	colors[2]  = { 1.0, 1.0,  1.0 };
	radFactors = { 1.0, 1.0,  1.0 };

	shiftPosition = false;
};

BulletData look
{
	bulletShapeName    = "breath.dts";
	validateShape      = true;
	explosionTag       = lookExp;
	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.0;
	damageType         = $BulletDamageType;
	muzzleVelocity     = 1000.0;
	totalTime          = 0.05;
	lightRange         = 0.0;
	lightColor         = { 0, 0, 0 };
	inheritedVelocityScale = 0;
	isVisible          = False;
};

ExplosionData Smoke1Exp
{
	shapeName = "breath.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 0.1;
	timeScale = 5.5;
	colors[0] = { 1.0, 1.0, 1.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};

GrenadeData Smoke1
{
	bulletShapeName = "breath.dts";
	explosionTag = Smoke1Exp;
	collideWithOwner = false;
	ownerGraceMS = 100;
	collisionRadius = 0.0;
	mass = -0.4;
	elasticity = 0;
	damageClass = 0;
	damageValue = 0;
	explosionRadius = 1;
	kickBackStrength = 0.1;
	maxLevelFlightDist = -0.1;
	totalTime = 0.01;
	liveTime = 0.01;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.2;
	smokeName = "breath.dts";
};

ItemImageData CiggImage
{
	shapeFile = "force";
	weaponType = 0;
	projectileType = Smoke1;
	accuFire = false;
	fireTime = 0.1;
	reloadTime = 0;
	mountPoint = 2;
	mountOffset = { 0.01, 0.29, 0.34 };
	mountRotation = { 1.57, 3.14, 0.02 };
	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = true;
};

ItemData Cigg
{
	description = "Cigarette";
	shapeFile = "force";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = CiggImage;
	price = 0;
	showWeaponBar = false;
	hiliteOnActive = false;
};

function Cigg::onMount(%player,%item) { Player::trigger(%player,4,true); }

ExplosionData Smoke2Exp
{
	shapeName = "rsmoke.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 0.1;
	timeScale = 6.5;
	colors[0] = { 1.0, 1.0, 1.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};

GrenadeData Smoke2
{
	bulletShapeName = "rsmoke.dts";
	explosionTag = Smoke2Exp;
	collideWithOwner = false;
	ownerGraceMS = 100;
	collisionRadius = 0.0;
	mass = -0.4;
	elasticity = 0;
	damageClass = 0;
	damageValue = 0;
	explosionRadius = 1;
	kickBackStrength = 0.1;
	maxLevelFlightDist = -0.1;
	totalTime = 0.01;
	liveTime = 0.01;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.2;
	smokeName = "rsmoke.dts";
};

ItemImageData BluntImage
{
	shapeFile = "force";
	weaponType = 0;
	projectileType = Smoke2;
	accuFire = false;
	fireTime = 0.2;
	reloadTime = 0;
	mountPoint = 2;
	mountOffset = { 0.01, 0.29, 0.34 };
	mountRotation = { 1.57, 3.14, 0.02 };
	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = true;
};

ItemData Blunt
{
	description = "Blunt";
	shapeFile = "force";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = BluntImage;
	mass = -2.0;
	price = 0;
	showWeaponBar = false;
	hiliteOnActive = false;
};

function Blunt::onMount(%player,%item) { Player::trigger(%player,4,true); }

ExplosionData LargeShockwave2
{
	shapeName = "shockwave_large.dts";
	soundId   = shockExplosion;
	faceCamera = true;
	randomSpin = false;
	hasLight   = true;
	lightRange = 10.0;
	timeScale = 1.5;
	timeZero = 0.100;
	timeOne  = 0.400;
	colors[0]  = { 1.0, 1.0, 1.0 };
	colors[1]  = { 1.0, 1.0, 1.0 };
	colors[2]  = { 0.0, 0.0, 0.0 };
	radFactors = { 1.0, 0.5, 0.0 };
};

GrenadeData SuperStart
{
	bulletShapeName    = "breath.dts";
	explosionTag       = LargeShockwave2;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 0.1;
	elasticity         = 0;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.0;
	damageType         = $MortarDamageType;

	explosionRadius    = 0.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 0;
	totalTime          = 0.01;
	liveTime           = 0.01;
	projSpecialTime    = 0.01;

	inheritedVelocityScale = -0.5;
	smokeName              = "rsmoke.dts";
};

ItemData Coconut
{
	description = "Coconut";
	shapeFile = "grenade";
	className = "Tossable";
	heading = "zExtra";
	shadowDetailMask = 4;
	showWeaponBar = false;
	hiliteOnActive = false;
};

//--------------------------------------
StaticShapeData CoconutStatic
{
	shapeFile = "grenade";
	debrisId = defaultDebrisSmall;
	className = "Tossable";
	disableCollision = false;
	shadowDetailMask = 4;
	maxDamage = 1.0;
	description = "Coconut";
};

//----------------------------------------------------------------------------
// DamageSkinData
//----------------------------------------------------------------------------

// Global object damage skins (staticShapes Turrets Stations Sensors)
DamageSkinData objectDamageSkins
{
	bmpName[0] = "dobj1_object";
	bmpName[1] = "dobj2_object";
	bmpName[2] = "dobj3_object";
	bmpName[3] = "dobj4_object";
	bmpName[4] = "dobj5_object";
	bmpName[5] = "dobj6_object";
	bmpName[6] = "dobj7_object";
	bmpName[7] = "dobj8_object";
	bmpName[8] = "dobj9_object";
	bmpName[9] = "dobj10_object";
};

//----------------------------------------------------------------------------
// Flags
//----------------------------------------------------------------------------

ItemImageData FlagImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 15;
	lightTime = 1.5;
	lightColor = { -999, 999, -999 };
};

ItemData Flag
{
	description = "Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;
	validateShape = true;

	lightType = 2;   // Pulsing
	lightRadius = 15;
	lightTime = 1.5;
	lightColor = { -999, 999, -999 };
};

ItemData RaceFlag
{
	description = "Race Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;

	lightType = 2;   // Pulsing
	lightRadius = 15;
	lightTime = 1.5;
	lightColor = { -999, 999, -999 };
};

//----------------------------------------------------------------------------
// Tools, Weapons & ammo
//----------------------------------------------------------------------------

ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

//----------------------------------------------------------------------------
//Weapon Types:
// 0 = Single Shot
// 1 = Spin Up and Spin Down
// 2 = Sustained
// 3 = Spin Up before firing
// 4 >= ...
//----------------------------------------------------------------------------

ItemImageData GunImage
{
	shapeFile  = "energygun";
	mountPoint = 0;
//	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
//	firstPerson = false;

	weaponType = 0;
	reloadTime = 0.05;
	//spinUpTime = 0.5;
	//spinDownTime = 3;
	fireTime = 0.1;
	minEnergy = 2;
	maxEnergy = 3;

	//ammoType = "";
	projectileType = Projectile;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireBlaster;
	//sfxReload = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
	//sfxReady = SoundMortarIdle;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

ItemData Gun
{
	heading = "aWeapons";
	description = "Pea Shooter";
	className = "Weapon";
	shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = GunImage;
	price = $TerminalCost[Gun];
	showWeaponBar = true;
};

//----------------------------------------------------------------------------

ItemData Ammo
{
	description = "Ammo";
	showInventory = false;
};

//----------------------------------------------------------------------------
// Backpacks
//----------------------------------------------------------------------------

ItemData Backpack
{				
	description = "Backpack";
	showInventory = false;
};

//----------------------------------------------------------------------------

ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

TargetLaserData targetLaser
{
	laserBitmapName   = "paintPulse.bmp";

	damageConversion  = 0.0;
	baseDamageType    = 0;

	lightRange        = 6.0;
	lightColor        = { 0.25, 1.0, 0.25 };

	detachFromShooter = false;
};

ItemImageData LATMk1Image
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 3;
	maxEnergy = 10;
	reloadTime = 0.1;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LATMk1
{
	description	 = "Laser Analyzation Tool";
	className	 = "Weapon";
	shapeFile	 = "paintgun";
	hudIcon		 = "targetlaser";
	heading		 = "cTools";
	shadowDetailMask = 4;
	imageType	 = LATMk1Image;
	price		 = $TerminalCost[LATMk1];
	showWeaponBar	 = true;
};

//----------------------------------------------------------------------------
ItemData Wallet_1
{
	description = "Small Wallet";
	shapeFile = "armorKit";
	heading = "dMedical";
	shadowDetailMask = 4;
	price = $TerminalCost[RepairKit];
	validateShape = true;
	validateMaterials = true;
};

//----------------------------------------------------------------------------
SoundData SoundFireConstr
{
	wavFileName = "float_target.wav";
	profile = Profile3dNearLoop;
};

ItemImageData CnToolImage
{
	shapeFile = "jetpack";
	mountOffset = { 0, -0.2, -0.1 };
	mountPoint = 0;
	weaponType = 1;
	minEnergy = 0;
	maxEnergy = 0;
	spinUpTime = 0.0;
	spinDownTime = 0;
	fireTime = 0.1;
	reloadTime = 0.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireConstr;
	sfxActivate = SoundPickUpWeapon;
};

ItemData CnTool
{
	description	= "Construction Tool";
	className	= "Tool";
	shapeFile	= "jetpack";
	hudIcon		= "compass";
	heading		= "cTools";
	shadowDetailMask = 4;
	imageType	= CnToolImage;
	price		= $TerminalCost[CnTool];
	showWeaponBar	= true;
};

//----------------------------------------------------------------------------
// Medical
//----------------------------------------------------------------------------

ItemData RepairKit
{
	description = "Repair Kit";
	shapeFile = "armorKit";
	heading = "dMedical";
	shadowDetailMask = 4;
	price = $TerminalCost[RepairKit];
	validateShape = true;
	validateMaterials = true;
};

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
	heading = "dMedical";
	shadowDetailMask = 4;
  	price = $TerminalCost[RepairPatch];
	validateShape = true;
	validateMaterials = true;
};

//----------------------------------------------------------------------------
ItemData Mine
{
	description = "Mine";
	shapeFile = "mineammo";
	heading = "eMiscellany";
	shadowDetailMask = 4;
	price = 0;
	className = "HandAmmo";
	showInventory = false;
};

//----------------------------------------------------------------------------
ItemData Grenade
{
	description = "Grenade";
	shapeFile = "grenade";
	heading = "eMiscellany";
	shadowDetailMask = 4;
	price = 0;
	className = "HandAmmo";
	showInventory = false;
};

//----------------------------------------------------------------------------
ItemData Beacon
{
	description = "Beacon";
	shapeFile = "sensor_small";
	heading = "eMiscellany";
	shadowDetailMask = 4;
	price = 0;
	className = "HandAmmo";
	showInventory = false;
};

//----------------------------------------------------------------------------
ItemData Activator1
{
	description = "Blaster";
	shapeFile = "breath";
	heading = "eMiscellany";
	shadowDetailMask = 4;
	price = 0;
	className = "Activator";
	showInventory = false;
};

//----------------------------------------------------------------------------
ItemData Activator2
{
	description = "Plasma Gun";
	shapeFile = "breath";
	heading = "eMiscellany";
	shadowDetailMask = 4;
	price = 0;
	className = "Activator";
	showInventory = false;
};

//----------------------------------------------------------------------------
ItemData Activator3
{
	description = "Chaingun";
	shapeFile = "breath";
	heading = "eMiscellany";
	shadowDetailMask = 4;
	price = 0;
	className = "Activator";
	showInventory = false;
};

//----------------------------------------------------------------------------
ItemData Activator4
{
	description = "Disc Launcher";
	shapeFile = "breath";
	heading = "eMiscellany";
	shadowDetailMask = 4;
	price = 0;
	className = "Activator";
	showInventory = false;
};

//----------------------------------------------------------------------------
ItemData Activator5
{
	description = "Grenade Launcher";
	shapeFile = "breath";
	heading = "eMiscellany";
	shadowDetailMask = 4;
	price = 0;
	className = "Activator";
	showInventory = false;
};

//----------------------------------------------------------------------------
ItemData Activator6
{
	description = "Laser Rifle";
	shapeFile = "breath";
	heading = "eMiscellany";
	shadowDetailMask = 4;
	price = 0;
	className = "Activator";
	showInventory = false;
};

//----------------------------------------------------------------------------
ItemData Activator7
{
	description = "ELF Gun";
	shapeFile = "breath";
	heading = "eMiscellany";
	shadowDetailMask = 4;
	price = 0;
	className = "Activator";
	showInventory = false;
};

//----------------------------------------------------------------------------
ItemData Activator8
{
	description = "Mortar";
	shapeFile = "breath";
	heading = "eMiscellany";
	shadowDetailMask = 4;
	price = 0;
	className = "Activator";
	showInventory = false;
};

//----------------------------------------------------------------------------
ItemData Activator9
{
	description = "Targeting Laser";
	shapeFile = "breath";
	heading = "eMiscellany";
	shadowDetailMask = 4;
	price = 0;
	className = "Activator";
	showInventory = false;
};

//--------------------------------------
StaticShapeData Vege1
{
	shapeFile = "plant2";
	debrisId = defaultDebrisSmall;
	className = "Harvest";
	disableCollision = false;
	shadowDetailMask = 16;
	maxDamage = 1.0;
	description = "Vegetation 1";
};

StaticShapeData Vege2
{
	shapeFile = "mrtwig";
	debrisId = defaultDebrisSmall;
	className = "Harvest";
	disableCollision = false;
	shadowDetailMask = 16;
	maxDamage = 1.0;
	description = "Vegetation 2";
};

//--------------------------------------
StaticShapeData Ore1
{
	shapeFile = "armorpatch";
	debrisId = defaultDebrisSmall;
	className = "Harvest";
	disableCollision = false;
	shadowDetailMask = 16;
	maxDamage = 1.0;
	description = "Metal Ore";
};

//--------------------------------------
//-Vege_MariJ
// Vege_Corn
// Vege_Potatoe
// Vege_Tomatoe
// Vege_Soybean
// Vege_Hevea
// Vege_Indigo
// Vege_Wheat
// Vege_Yam
// Vege_Bamboo
//--------------------------------------
ItemData Vege_MariJ
{
	description = "Piece of Cannabis";
	shapeFile = "plant2";
	className = "Harvest";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Vege_MariJ];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Vege_MariJ] = "Pieces of Cannabis";

ItemData Seed_MariJ
{
	description = "Cannabis Seed";
	shapeFile = "grenade";
	className = "Seed";
	heading = "uSeed Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Seed_MariJ];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Seed_MariJ] = "Cannabis Seeds";

//--------------------------------------
ItemData Vege_Corn
{
	description = "Ear of Corn";
	shapeFile = "plant2";
	className = "Harvest";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Vege_Corn];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Vege_Corn] = "Ears of Corn";

ItemData Seed_Corn
{
	description = "Corn Sprout";
	shapeFile = "grenade";
	className = "Seed";
	heading = "uSeed Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Seed_Corn];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Seed_Corn] = "Corn Sprouts";

//--------------------------------------
ItemData Vege_Potatoe
{
	description = "Potatoe";
	shapeFile = "plant2";
	className = "Harvest";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Vege_Potatoe];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Vege_Potatoe] = "Potatoes";

ItemData Seed_Potatoe
{
	description = "Potatoe Sprout";
	shapeFile = "grenade";
	className = "Seed";
	heading = "uSeed Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Seed_Potatoe];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Seed_Potatoe] = "Potatoe Sprouts";

//--------------------------------------
ItemData Vege_Tomatoe
{
	description = "Tomatoe";
	shapeFile = "plant2";
	className = "Harvest";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Vege_Tomatoe];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Vege_Tomatoe] = "Tomatoes";

ItemData Seed_Tomatoe
{
	description = "Tomatoe Sprout";
	shapeFile = "grenade";
	className = "Seed";
	heading = "uSeed Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Seed_Tomatoe];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Seed_Tomatoe] = "Tomatoe Sprouts";

//--------------------------------------
ItemData Vege_Soybean
{
	description = "Soy Bean";
	shapeFile = "plant2";
	className = "Harvest";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Vege_Soybean];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Vege_Soybean] = "Soy Beans";

ItemData Seed_Soybean
{
	description = "Soybean Seed";
	shapeFile = "grenade";
	className = "Seed";
	heading = "uSeed Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Seed_Soybean];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Seed_Soybean] = "Soybean Seeds";

//--------------------------------------
ItemData Vege_Hevea
{
	description = "Piece of Hevea";
	shapeFile = "mrtwig";
	className = "Harvest";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Vege_Hevea];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Vege_Hevea] = "Pieces of Hevea";

ItemData Seed_Hevea
{
	description = "Hevea Seed";
	shapeFile = "grenade";
	className = "Seed";
	heading = "uSeed Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Seed_Hevea];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Seed_Hevea] = "Hevea Seeds";

//--------------------------------------
ItemData Vege_Indigo
{
	description = "Piece of Indigo";
	shapeFile = "plant2";
	className = "Harvest";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Vege_Indigo];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Vege_Indigo] = "Pieces of Indigo";

ItemData Seed_Indigo
{
	description = "Indigo Seed";
	shapeFile = "grenade";
	className = "Seed";
	heading = "uSeed Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Seed_Indigo];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Seed_Indigo] = "Indigo Seeds";

//--------------------------------------
ItemData Vege_Wheat
{
	description = "Piece of Wheat";
	shapeFile = "plant2";
	className = "Harvest";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Vege_Wheat];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Vege_Wheat] = "Pieces of Wheat";

ItemData Seed_Wheat
{
	description = "Wheat Seed";
	shapeFile = "grenade";
	className = "Seed";
	heading = "uSeed Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Seed_Wheat];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Seed_Wheat] = "Wheat Seeds";

//--------------------------------------
ItemData Vege_Yam
{
	description = "Yam";
	shapeFile = "mrtwig";
	className = "Harvest";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Vege_Yam];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Vege_Yam] = "Yams";

ItemData Seed_Yam
{
	description = "Yam Sprout";
	shapeFile = "grenade";
	className = "Seed";
	heading = "uSeed Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Seed_Yam];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Seed_Yam] = "Yam Sprouts";

//--------------------------------------
ItemData Vege_Bamboo
{
	description = "Piece of Bamboo";
	shapeFile = "mrtwig";
	className = "Harvest";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Vege_Bamboo];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Vege_Bamboo] = "Pieces of Bamboo";

ItemData Seed_Bamboo
{
	description = "Bamboo Shoot";
	shapeFile = "grenade";
	className = "Seed";
	heading = "uSeed Bag";
	mass = 1.0;
	shadowDetailMask = 1;
	price = $TerminalCost[Seed_Bamboo];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Seed_Bamboo] = "Bamboo Shoots";

//--------------------------------------
//-Ore_Lead
// Ore_Iron
// Ore_Tin
// Ore_Aluminum
// Ore_Copper
// Ore_Titanium
// Ore_Silver
// Ore_Gold
// Ore_Platinum
// Ore_Carbon
// Ore_Sulfur
//--------------------------------------
ItemData Ore_Lead
{
	description = "Piece of Lead Ore";
	className = "Harvest";
	shapeFile = "armorpatch";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 16;
	price = 1;
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Ore_Lead] = "Pieces of Lead Ore";

//--------------------------------------
ItemData Ore_Iron
{
	description = "Piece of Iron Ore";
	className = "Harvest";
	shapeFile = "armorpatch";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 16;
	price = 1;
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Ore_Iron] = "Pieces of Iron Ore";

//--------------------------------------
ItemData Ore_Tin
{
	description = "Piece of Tin Ore";
	className = "Harvest";
	shapeFile = "armorpatch";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 16;
	price = 1;
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Ore_Tin] = "Pieces of Tin Ore";

//--------------------------------------
ItemData Ore_Aluminum
{
	description = "Piece of Aluminum Ore";
	className = "Harvest";
	shapeFile = "armorpatch";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 16;
	price = 1;
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Ore_Aluminum] = "Pieces of Aluminum Ore";

//--------------------------------------
ItemData Ore_Copper
{
	description = "Piece of Copper Ore";
	className = "Harvest";
	shapeFile = "armorpatch";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 16;
	price = 1;
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Ore_Copper] = "Pieces of Copper Ore";

//--------------------------------------
ItemData Ore_Titanium
{
	description = "Piece of Titanium Ore";
	className = "Harvest";
	shapeFile = "armorpatch";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 16;
	price = 1;
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Ore_Titanium] = "Pieces of Titanium Ore";

//--------------------------------------
ItemData Ore_Silver
{
	description = "Piece of Silver Ore";
	className = "Harvest";
	shapeFile = "armorpatch";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 16;
	price = 1;
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Ore_Silver] = "Pieces of Silver Ore";

//--------------------------------------
ItemData Ore_Gold
{
	description = "Piece of Gold Ore";
	className = "Harvest";
	shapeFile = "armorpatch";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 16;
	price = 1;
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Ore_Gold] = "Pieces of Gold Ore";

//--------------------------------------
ItemData Ore_Platinum
{
	description = "Piece of Platinum Ore";
	className = "Harvest";
	shapeFile = "armorpatch";
	heading = "vHarvest Bag";
	mass = 1.0;
	shadowDetailMask = 16;
	price = 1;
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Ore_Platinum] = "Pieces of Platinum Ore";

//--------------------------------------
GrenadeData VegeRipeSpark
{
	bulletShapeName    = "laserhit.dts";
	explosionTag       = breathExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0.1;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.0;
	damageType         = $ExplosionDamageType;

	explosionRadius    = 2;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 12.5;
	totalTime          = 0.2;
	liveTime           = 0.2;
	projSpecialTime    = 0.01;

	inheritedVelocityScale = 0.5;

	smokeName          = "laserhit.dts";
};

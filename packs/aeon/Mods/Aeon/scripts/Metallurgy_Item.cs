StaticShapeData Foundry
{
	description = "Metal Foundry";
	shapeFile = "cmdpnl";
	className = "Terminal";
	sequenceSound[0] = { "power", SoundCommandStationPower };
	sequenceSound[1] = { "activate", SoundActivatePDA };
	sequenceSound[2] = { "use", SoundUseCommandStation };
	maxDamage = 1.0;
	debrisId = flashDebrisMedium;
	mapFilter = 4;
	mapIcon = "M_generator";
	visibleToSensor = true;
	castLOS = true;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
	explosionId = flashExpLarge;
};

//--------------------------------------
//-Metal_Cinder
// Metal_Lead
// Metal_Iron
// Metal_Tin
// Metal_Aluminum
// Metal_Copper
// Metal_Titanium
// Metal_Silver
// Metal_Gold
// Metal_Platinum
//--------------------------------------
ItemData Metal_Cinder
{
	description = "Piece of Cinder";
	className = "Metal";
	shapeFile = "ammo1";
	heading = "xMaterials";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Metal_Cinder];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Metal_Cinder] = "Pieces of Cinder";

//--------------------------------------
ItemData Metal_Lead
{
	description = "Piece of Lead";
	className = "Metal";
	shapeFile = "ammo1";
	heading = "xMaterials";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Metal_Lead];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Metal_Lead] = "Pieces of Lead";

//--------------------------------------
ItemData Metal_Iron
{
	description = "Piece of Iron";
	className = "Metal";
	shapeFile = "ammo1";
	heading = "xMaterials";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Metal_Iron];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Metal_Iron] = "Pieces of Iron";

//--------------------------------------
ItemData Metal_Tin
{
	description = "Piece of Tin";
	className = "Metal";
	shapeFile = "ammo1";
	heading = "xMaterials";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Metal_Tin];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Metal_Tin] = "Pieces of Tin";

//--------------------------------------
ItemData Metal_Aluminum
{
	description = "Piece of Aluminum";
	className = "Metal";
	shapeFile = "ammo1";
	heading = "xMaterials";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Metal_Aluminum];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Metal_Aluminum] = "Pieces of Aluminum";

//--------------------------------------
ItemData Metal_Copper
{
	description = "Piece of Copper";
	className = "Metal";
	shapeFile = "ammo1";
	heading = "xMaterials";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Metal_Copper];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Metal_Copper] = "Pieces of Copper";

//--------------------------------------
ItemData Metal_Titanium
{
	description = "Piece of Titanium";
	className = "Metal";
	shapeFile = "ammo1";
	heading = "xMaterials";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Metal_Titanium];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Metal_Titanium] = "Pieces of Titanium";

//--------------------------------------
ItemData Metal_Silver
{
	description = "Piece of Silver";
	className = "Metal";
	shapeFile = "ammo1";
	heading = "xMaterials";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Metal_Silver];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Metal_Silver] = "Pieces of Silver";

//--------------------------------------
ItemData Metal_Gold
{
	description = "Piece of Gold";
	className = "Metal";
	shapeFile = "ammo1";
	heading = "xMaterials";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Metal_Gold];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Metal_Gold] = "Pieces of Gold";

//--------------------------------------
ItemData Metal_Platinum
{
	description = "Piece of Platinum";
	className = "Metal";
	shapeFile = "ammo1";
	heading = "xMaterials";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Metal_Platinum];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Metal_Platinum] = "Pieces of Platinum";

//--------------------------------------
//-Alloy_Steel
// Alloy_Bronze
// Alloy_Pewter
// Alloy_Electrum
// Alloy_Duralumin
//--------------------------------------
ItemData Alloy_Steel
{
	description = "Piece of Steel";
	className = "Metal";
	shapeFile = "ammo1";
	heading = "xMaterials";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Alloy_Steel];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Alloy_Steel] = "Pieces of Steel";

//--------------------------------------
ItemData Alloy_Bronze
{
	description = "Piece of Bronze";
	className = "Metal";
	shapeFile = "ammo1";
	heading = "xMaterials";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Alloy_Bronze];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Alloy_Bronze] = "Pieces of Bronze";

//--------------------------------------
ItemData Alloy_Pewter
{
	description = "Piece of Pewter";
	className = "Metal";
	shapeFile = "ammo1";
	heading = "xMaterials";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Alloy_Pewter];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Alloy_Pewter] = "Pieces of Pewter";

//--------------------------------------
ItemData Alloy_Electrum
{
	description = "Piece of Electrum";
	className = "Metal";
	shapeFile = "ammo1";
	heading = "xMaterials";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Alloy_Electrum];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Alloy_Electrum] = "Pieces of Electrum";

//--------------------------------------
ItemData Alloy_Duralumin
{
	description = "Piece of Duralumin";
	className = "Metal";
	shapeFile = "ammo1";
	heading = "xMaterials";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Alloy_Duralumin];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Alloy_Duralumin] = "Pieces of Duralumin";

//--------------------------------------
//-Mineral_Carbon
// Mineral_Sulfur
// Mineral_Phosph
// Mineral_Powder
//--------------------------------------
ItemData Mineral_Carbon
{
	description = "Piece of Carbon";
	className = "Harvest";
	shapeFile = "armorpatch";
	heading = "wMinerals";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Mineral_Carbon];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Mineral_Carbon] = "Pieces of Carbon";

//--------------------------------------
ItemData Mineral_Sulfur
{
	description = "Piece of Sulfur";
	className = "Harvest";
	shapeFile = "armorpatch";
	heading = "wMinerals";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Mineral_Sulfur];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Mineral_Sulfur] = "Pieces of Sulfur";

//--------------------------------------
ItemData Mineral_Phosph
{
	description = "Piece of Phosphate";
	className = "Harvest";
	shapeFile = "armorpatch";
	heading = "wMinerals";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Mineral_Phosph];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Mineral_Phosph] = "Pieces of Phosphate";

//--------------------------------------
ItemData Mineral_Powder
{
	description = "Mix of X Powder";
	className = "Harvest";
	shapeFile = "armorpatch";
	heading = "wMinerals";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Mineral_Powder];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Mineral_Powder] = "Mixes of X Powder";

//--------------------------------------
//-Exp_C1
// Exp_C2
// Exp_C3
// Exp_C4
// Exp_C5
//--------------------------------------
ItemData Exp_C1
{
	description = "C1 Explosive";
	className = "Explosive";
	shapeFile = "discammo";
	heading = "uExplosives";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Exp_C1];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Exp_C1] = "C1 Explosives";

//--------------------------------------
ItemData Exp_C2
{
	description = "C2 Explosive";
	className = "Explosive";
	shapeFile = "discammo";
	heading = "uExplosives";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Exp_C2];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Exp_C2] = "C2 Explosives";

//--------------------------------------
ItemData Exp_C3
{
	description = "C3 Explosive";
	className = "Explosive";
	shapeFile = "discammo";
	heading = "uExplosives";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Exp_C3];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Exp_C3] = "C3 Explosives";

//--------------------------------------
ItemData Exp_C4
{
	description = "C4 Explosive";
	className = "Explosive";
	shapeFile = "discammo";
	heading = "uExplosives";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Exp_C4];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Exp_C4] = "C4 Explosives";

//--------------------------------------
ItemData Exp_C5
{
	description = "C5 Explosive";
	className = "Explosive";
	shapeFile = "discammo";
	heading = "uExplosives";
	mass = 1.0;
	shadowDetailMask = 16;
	price = $TerminalCost[Exp_C5];
	showWeaponBar = false;
	hiliteOnActive = false;
};
$Plural[Exp_C5] = "C5 Explosives";

//--------------------------------------
StaticShapeData Exp_CStatic
{
	shapeFile = "discammo";
	debrisId = defaultDebrisSmall;
	className = "Explosive";
	disableCollision = false;
	shadowDetailMask = 16;
	maxDamage = 1.0;
	description = "C1-C5 Explosive";
	mapFilter = 3;
	mapIcon = "M_sensorjammer";
	visibleToSensor = true;
	castLOS = true;
};

//--------------------------------------
MineData Exp_CMine
{
	className = "Mine";
	description = "C1-C5";
	shapeFile = "shotgunex";
	validateShape = true;
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 5.0;
	damageValue = 0.8;
	damageType = $FireDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

//--------------------------------------
SoundData SoundExplosiveBeep
{
	wavFileName = "shell_click.wav";
	profile = Profile3dNear;
};

//--------------------------------------
ExplosionData Smoke3Exp
{
	shapeName = "rsmoke.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 4.0;
	timeScale = 2.0;
	colors[0] = { 1.0, 1.0, 1.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};
GrenadeData Smoke3
{
	bulletShapeName = "rsmoke.dts";
	explosionTag = Smoke3Exp;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.0;
	mass = 0.0;
	elasticity = 0.4;
	damageClass = 0;
	damageValue = 0;
	explosionRadius = 1;
	kickBackStrength = 0.3;
	maxLevelFlightDist = 4;
	totalTime = 0.56;
	liveTime = 0.56;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 1.0;
	smokeName = "rsmoke.dts";
};

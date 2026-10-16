//--------------------------------------
$FireDamageType		= 14;

//--------------------------------------
RocketData rockProj1
{
	bulletShapeName  = "cactus2.dts";
	explosionTag     = LargeShockwave;
	collisionRadius  = 0.0;
	mass             = 0.5;

	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 1.5;
	damageType       = $FireDamageType;

	explosionRadius  = 20.0;
	kickBackStrength = 300.0;
	muzzleVelocity   = 200;
	terminalVelocity = 600.0;
	acceleration     = 10.0;
	totalTime        = 30.0;
	liveTime         = 30.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.0;

	// rocket specific
	trailType   = 2;                
	trailString = "plasmaex.dts";
	smokeDist   = 2.0;

	soundId = SoundFlyerActive;
};

//--------------------------------------
GrenadeData rockProj2
{
	bulletShapeName    = "plasmabolt.dts";
	explosionTag       = blasterExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.2;
	mass               = 1.0;
	elasticity         = 0.45;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.1;
	damageType         = $ShrapnelDamageType;

	explosionRadius    = 1;
	kickBackStrength   = 10.0;
	maxLevelFlightDist = 0.1;
	totalTime          = 5.0;    // special meaning for grenades...
	liveTime           = 2.0;
	projSpecialTime    = 0.05;
	inheritedVelocityScale = 0.75;
	smokeName              = "plasmaex.dts";
};

//--------------------------------------
ExplosionData rockSmokeExp
{
	shapeName = "mortarex.dts";
	soundId   = explosion3;

	faceCamera = true;
	randomSpin = false;
	hasLight   = true;
	lightRange = 1.0;

	timeScale = 3.0;
	timeZero = 0.950;
	timeOne  = 0.900;

	colors[0]  = { 0.0, 0.0, 0.0 };
	colors[1]  = { 1.0, 1.0, 1.0 };
	colors[2]  = { 1.0, 1.0, 1.0 };
	radFactors = { 0.0, 1.0, 1.0 };
};

GrenadeData rockSmoke
{
	bulletShapeName = "shockwave.dts";
	explosionTag = rockSmokeExp;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.1;
	damageType  = $FireDamageType;
	damageClass = 0;
	damageValue = 1.0;
	explosionRadius = 2;
	kickBackStrength = 10.0;
	maxLevelFlightDist = 0.1;
	totalTime = 0.01;
	liveTime = 0.01;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "plasmaex.dts";
};

//--------------------------------------
ExplosionData rockSparkExp
{
	shapeName = "plasmaex.dts";
	//soundId   = explosion4;

	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 4.0;

	timeScale = 10.0;
	timeZero = 1.0;
	timeOne  = 0.100;

	//colors[0]  = { 1.0, 1.0,  0.0 };
	//colors[1]  = { 1.0, 1.0, 0.75 };
	//colors[2]  = { 1.0, 1.0, 0.75 };
	//radFactors = { 0.375, 1.0, 0.9 };
	colors[0]  = { 1.0, 0, 0 };
	colors[1]  = { 99, -5, 99 };
	colors[2]  = { 999, -10, 99 };
	radFactors = { 1.0, 0.5, 0.9 };
};

ExplosionData rockBurnExp
{
	shapeName = "plasmaex.dts";
	//soundId   = explosion4;

	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 4.0;

	timeScale = 5.0;
	timeZero = 0.950;
	timeOne  = 0.900;

	colors[0]  = { 1.0, 0, 0 };
	colors[1]  = { 99, -5, 99 };
	colors[2]  = { 999, -10, 99 };
	radFactors = { 1.0, 0.5, 0.9 };
};

GrenadeData rockSpark
{
	bulletShapeName = "plasmaex.dts";
	explosionTag = rockSparkExp;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.0;
	mass = 0.0;
	elasticity = 0.0;
	damageClass = 0;
	damageValue = 0;
	explosionRadius = 1;
	kickBackStrength = 0.3;
	maxLevelFlightDist = 4;
	totalTime = 0.56;
	liveTime = 0.56;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "plasmaex.dts";
};

GrenadeData rockBurn
{
	bulletShapeName = "plasmaex.dts";
	explosionTag = rockBurnExp;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.0;
	mass = 0.0;
	elasticity = 0.0;
	damageType = $FireDamageType;
	damageClass = 0;
	damageValue = 0.0;
	explosionRadius = 1;
	kickBackStrength = 0.3;
	maxLevelFlightDist = 0.1;
	totalTime = 0.01;
	liveTime = 0.01;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "plasmaex.dts";
};

//------------------------------------------------------------------------
StaticShapeData rockTemp
{
	shapeFile = "breath";
	//debrisId = defaultDebrisSmall;
	//maxDamage = 1.0;
	//damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	//explosionId = flashExpMedium;
	disableCollision = true;
	description = "rockTemp";
};

//------------------------------------------------------------------------
StaticShapeData rockVent
{
	shapeFile = "steamvent_grass";
	maxDamage = 999.0;
	isTranslucent = "True";
	description = "Steam Vent";
};

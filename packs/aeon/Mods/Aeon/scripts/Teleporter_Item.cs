StaticShapeData Teleporter
{
	description = "Personal Teleporter";
	shapeFile = "enerpad";
	className = "Terminal";
	maxDamage = 1.0;
	sequenceSound[0] = { "idle", SoundBeaconActive };
	sequenceSound[1] = { "busy", SoundUseCommandStation };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 4;
	mapIcon = "M_Radar";
	debrisId = flashDebrisMedium;
	damageSkinData = "objectDamageSkins";
	explosionId = flashExpSmall;
};

ExplosionData Explode_TeleFX
{
	shapeName = "shockwave_large.dts";
	soundId   = SoundBeaconUse;
	faceCamera = false;
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

GrenadeData TeleFX
{
	bulletShapeName    = "breath.dts";
	explosionTag       = Explode_TeleFX;
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
	smokeName              = "shield_large.dts";
};

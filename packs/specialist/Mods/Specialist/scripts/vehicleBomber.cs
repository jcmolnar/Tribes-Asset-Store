$VehicleInvList[BomberVehicle] = 1;
$DataBlockName[BomberVehicle] = Bomber;
$VehicleToItem[Bomber] = BomberVehicle;

$TeamItemMax[BomberVehicle] = 2;

// don't forget to initialize team data to zero in item.cs

ItemData BomberVehicle
{
	description = "Bomber";
	className = "Vehicle";
	heading = "aVehicle";
	price = 675;
};

SoundData AirBombExplosion
{
   wavFileName = "Explo3.wav";
   profile     = Profile3dLudicrouslyFar;
};

ExplosionData AirBombExp
{
   shapeName = "mortarex.dts";
   soundId   = AirBombExplosion;

   faceCamera = true;
   randomSpin = false;
//   faceCamera = true;
//   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

GrenadeData BombShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = AirBombExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 500.0;
   elasticity         = 0.001;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.6;
   damageType         = $MortarDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0;
   totalTime          = 300.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.9;
   // smokeName              = "mortartrail.dts";
};

FlierData Bomber
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 12.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.7;
	maxPitch = 0.7;
	maxSpeed = 50;
	minSpeed = -1;
	lift = 0.35;
	maxAlt = 35;
	maxVertical = 15;
	maxDamage = 0.8;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 1.0;

	projectileType = BombShell;
	reloadDelay = 0.6;
	repairRate = 0;
	fireSound = SoundMortarTurretFire;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "Bomber";
};

$DamageScale[Bomber, $ImpactDamageType] = 1.0;
$DamageScale[Bomber, $BulletDamageType] = 1.0;
$DamageScale[Bomber, $PlasmaDamageType] = 1.0;
$DamageScale[Bomber, $EnergyDamageType] = 1.0;
$DamageScale[Bomber, $ExplosionDamageType] = 1.0;
$DamageScale[Bomber, $ShrapnelDamageType] = 1.0;
$DamageScale[Bomber, $DebrisDamageType] = 1.0;
$DamageScale[Bomber, $MissileDamageType] = 1.0;
$DamageScale[Bomber, $LaserDamageType] = 1.0;
$DamageScale[Bomber, $MortarDamageType] = 1.0;
$DamageScale[Bomber, $BlasterDamageType] = 0.5;
$DamageScale[Bomber, $ElectricityDamageType] = 1.0;
$DamageScale[Bomber, $MineDamageType]        = 1.0;

$DamageScale[Bomber, $PoisonGasDamageType]        = 0.0;
$DamageScale[Bomber, $RadiationDamageType]        = 0.0;
$DamageScale[Bomber, $EMPDamageType]        = 1.0;
$DamageScale[Bomber, $NullDamageType]        = 0.0;
$DamageScale[Bomber, $FireDamageType]        = 0.8;
$DamageScale[Bomber, $AcidDamageType]        = 1.0;
$DamageScale[Bomber, $BlindDamageType]        = 1.0;
$DamageScale[Bomber, $SniperRifleDamageType]        = 1.0;
$DamageScale[Bomber, $ShotgunDamageType]        = 1.0;
$DamageScale[Bomber, $FlakDamageType]        = 1.3;
$DamageScale[Bomber, $ExplosiveGatDamageType]        = 1.0;
$DamageScale[Bomber, $ArtilleryShellDamageType]        = 1.0;
$DamageScale[Bomber, $TimedExplosiveDamageType]        = 1.0;
$DamageScale[Bomber, $RemoteBombDamageType]        = 1.0;


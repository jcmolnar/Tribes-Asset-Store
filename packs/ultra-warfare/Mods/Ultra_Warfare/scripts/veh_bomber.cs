
$VehicleInvList[BomberVehicle] = 1;
$DataBlockName[BomberVehicle] = Bomber;
$VehicleToItem[Bomber] = BomberVehicle;
//----------------------------------------------------------------------------
$DamageScale[Bomber, $PlasmaDamageType] = 1.0;
$DamageScale[Bomber, $EnergyDamageType] = 1.0;
$DamageScale[Bomber, $DebrisDamageType] = 1.0;
$DamageScale[Bomber, $MissileDamageType] = 1.0;
$DamageScale[Bomber, $SniperDamageType] = 0.0;
$DamageScale[Bomber, $MortarDamageType] = 1.0;
$DamageScale[Bomber, $MineDamageType]    = 1.0;
$DamageScale[Bomber, $ELFDamageType]       = 1.0;
$DamageScale[Bomber, $ShockDamageType]       = 1.0;
$DamageScale[Bomber, $AssaultDamageType]       = 0.0;
$DamageScale[Bomber, $SniperDamageType]         = 0.0;
$DamageScale[Bomber, $ShotgunDamageType]        = 0.0;
$DamageScale[Bomber, $TranqDamageType]          = 0.0;
$DamageScale[Bomber, $FarSightDamageType]       = 1.0;
$DamageScale[Bomber, $RaptorDamageType]         = 0.0;
$DamageScale[Bomber, $DiscDamageType]           = 1.0;
$DamageScale[Bomber, $RailDamageType]           = 1.0;
$DamageScale[Bomber, $MinigunDamageType]        = 0.0;
$DamageScale[Bomber, $ReaperDamageType]         = 1.0;
$DamageScale[Bomber, $FirestormDamageType]      = 1.0;
$DamageScale[Bomber, $FusionDamageType]         = 1.0;
$DamageScale[Bomber, $FlamerDamageType]         = 1.0;
$DamageScale[Bomber, $InfernoDamageType]        = 1.0;
$DamageScale[Bomber, $GrenadeDamageType]        = 1.0;
$DamageScale[Bomber, $FGLDamageType]            = 1.0;
$DamageScale[Bomber, $MortarDamageType]         = 1.0;
$DamageScale[Bomber, $FBWDamageType]            = 1.0;
$DamageScale[Bomber, $MissileDamageType]        = 1.0;
$DamageScale[Bomber, $TrojaxDamageType]         = 1.0;
$DamageScale[Bomber, $EMPDamageType]            = 1.0;
$DamageScale[Bomber, $DepturLaserDamageType]    = 1.0;
$DamageScale[Bomber, $DepturSentryDamageType]   = 1.0;
$DamageScale[Bomber, $DepturRaptorDamageType]   = 1.0;
$DamageScale[Bomber, $DepturRocketDamageType]   = 1.0;
$DamageScale[Bomber, $TurretLaserDamageType]    = 1.0;
$DamageScale[Bomber, $TurretSonicDamageType]    = 1.0;
$DamageScale[Bomber, $TurretElfDamageType]      = 1.0;
$DamageScale[Bomber, $TurretFusionDamageType]   = 1.0;
$DamageScale[Bomber, $TurretMortarDamageType]   = 1.0;
$DamageScale[Bomber, $VehicleGravDamageType]    = 1.0;
$DamageScale[Bomber, $VehicleShrikeDamageType]  = 1.0;

//----------------------------------------------------------------------------

//

SoundData SoundVehBomberThrust
{
   wavFileName = "veh_Bomber_thrust.wav";
   profile = Profile3dMediumLoop;
};
SoundData SoundVehBomberIdle
{
   wavFileName = "veh_Bomber_idle.wav";
   profile = Profile3dMediumLoop;
};
//==========================================================
//================================================================
ExplosionData BomberExp
{
   shapeName = "mortarex.dts";
   soundId   = mortarExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 0.0, 0.0, 3.0 };
   colors[1]  = { 0.0, 0.0, 3.0 };
   colors[2]  = { 0.0, 0.0, 3.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};
//================================================================
GrenadeData Bomberproj
{
   bulletShapeName    = "proj_mortar.dts";
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
   maxLevelFlightDist = 25;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};


//==========================================================

FlierData Bomber
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "veh_Bomber";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 125;
   minSpeed = -10;
	lift = 0.5;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.125;

	projectileType = BomberProj;
	repairRate = 0;
	ramDamage = 1;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundNoSound;
	reloadDelay = 3.0;
	damageSound = SoundVehCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundVehMount;
	dismountSound = SoundVehDismount;
	idleSound = SoundVehBomberIdle;
	moveSound = SoundVehBomberThrust;

	visibleDriver = true;
	driverPose = 23;
	description = "Air Bomber";
};



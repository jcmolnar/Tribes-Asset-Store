$VehicleInvList[CycleVehicle] = 1;
$DataBlockName[CycleVehicle] = Cycle;
$VehicleToItem[Cycle] = CycleVehicle;
//----------------------------------------------------------------------------
$DamageScale[larmor, $VehicleGravDamageType] = 1.0;
$DamageScale[lfemale, $VehicleGravDamageType] = 1.0;
$DamageScale[marmor, $VehicleGravDamageType] = 1.0;
$DamageScale[mfemale, $VehicleGravDamageType] = 1.0;
$DamageScale[harmor, $VehicleGravDamageType] = 1.0;
//===========================================================================
$DamageScale[Cycle, $ImpactDamageType] = 1.0;
$DamageScale[Cycle, $BulletDamageType] = 1.0;
$DamageScale[Cycle, $PlasmaDamageType] = 1.0;
$DamageScale[Cycle, $EnergyDamageType] = 1.0;
$DamageScale[Cycle, $DebrisDamageType] = 1.0;
$DamageScale[Cycle, $MissileDamageType] = 1.0;
$DamageScale[Cycle, $SniperDamageType] = 1.0;
$DamageScale[Cycle, $MortarDamageType] = 1.0;
$DamageScale[Cycle, $MineDamageType]    = 1.0;
$DamageScale[Cycle, $ELFDamageType]       = 1.0;
$DamageScale[Cycle, $ShockDamageType]       = 1.0;
$DamageScale[Cycle, $AssaultDamageType]       = 0.0;
$DamageScale[Cycle, $SniperDamageType]         = 0.0;
$DamageScale[Cycle, $ShotgunDamageType]        = 0.0;
$DamageScale[Cycle, $TranqDamageType]          = 0.0;
$DamageScale[Cycle, $FarSightDamageType]       = 1.0;
$DamageScale[Cycle, $RaptorDamageType]         = 0.0;
$DamageScale[Cycle, $DiscDamageType]           = 1.0;
$DamageScale[Cycle, $RailDamageType]           = 1.0;
$DamageScale[Cycle, $MinigunDamageType]        = 0.0;
$DamageScale[Cycle, $ReaperDamageType]         = 1.0;
$DamageScale[Cycle, $FirestormDamageType]      = 1.0;
$DamageScale[Cycle, $FusionDamageType]         = 1.0;
$DamageScale[Cycle, $FlamerDamageType]         = 1.0;
$DamageScale[Cycle, $InfernoDamageType]        = 1.0;
$DamageScale[Cycle, $GrenadeDamageType]        = 1.0;
$DamageScale[Cycle, $FGLDamageType]            = 1.0;
$DamageScale[Cycle, $MortarDamageType]         = 1.0;
$DamageScale[Cycle, $FBWDamageType]            = 1.0;
$DamageScale[Cycle, $MissileDamageType]        = 1.0;
$DamageScale[Cycle, $TrojaxDamageType]         = 1.0;
$DamageScale[Cycle, $EMPDamageType]            = 1.0;
$DamageScale[Cycle, $DepturLaserDamageType]    = 1.0;
$DamageScale[Cycle, $DepturSentryDamageType]   = 1.0;
$DamageScale[Cycle, $DepturRaptorDamageType]   = 1.0;
$DamageScale[Cycle, $DepturRocketDamageType]   = 1.0;
$DamageScale[Cycle, $TurretLaserDamageType]    = 1.0;
$DamageScale[Cycle, $TurretSonicDamageType]    = 1.0;
$DamageScale[Cycle, $TurretElfDamageType]      = 1.0;
$DamageScale[Cycle, $TurretFusionDamageType]   = 1.0;
$DamageScale[Cycle, $TurretMortarDamageType]   = 1.0;
$DamageScale[Cycle, $VehicleGravDamageType]    = 1.0;
$DamageScale[Cycle, $VehicleShrikeDamageType]  = 1.0;
//----------------------------------------------------------------------------
// 

SoundData SoundVehGravThrust
{
   wavFileName = "veh_grav_thrust.wav";
   profile = Profile3dMediumLoop;
};
SoundData SoundVehGravIdle
{
   wavFileName = "veh_grav_idle.wav";
   profile = Profile3dMediumLoop;
};
SoundData SoundVehGrav
{
   wavFileName = "veh_grav.wav";
   profile = Profile3dMed;
};

//==========================================================
RocketData VehGravproj 
{
	bulletShapeName = "proj_grav.dts";
	explosionTag = IXBulletExp;

	collisionRadius = 0.0;
	mass = 2.0;

	damageClass = 0;
	damageValue = 0.5;
	damageType = $VehicleGravDamageType;
	explosionRadius = 0.5;
	kickBackStrength = 150.0;

	muzzleVelocity = 1000.0;
	terminalVelocity = 2000.0;
	acceleration = 100.0;
	totalTime = 4.0;
	liveTime = 5.0;

	lightRange = 5.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 1.0;

	//trailType = 1;
	//trailLength = 25;
	//trailWidth = 0.35;
	SoundID = SoundWhizMini;
};
//==========================================================
FlierData Cycle
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "veh_gravscout";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 175;
   minSpeed = -15;
	lift = 0.35;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 2.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 1.0;

	groundDamageScale = 0.75;

	projectileType = VehGravProj;
	reloadDelay = 0.15;
	repairRate = 0;
	fireSound = SoundVehGrav;
	damageSound = SoundVehCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundVehMount;
	dismountSound = SoundVehDismount;
	idleSound = SoundVehGravIdle;
	moveSound = SoundVehGravThrust;

	visibleDriver = true;
	driverPose = 22;
	description = "Grav Cycle";
};

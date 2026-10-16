$VehicleInvList[shrikeVehicle] = 1;
$DataBlockName[shrikeVehicle] = shrike;
$VehicleToItem[shrike] = shrikeVehicle;
//---------------------------------------------------------------------
$DamageScale[larmor, $VehicleShrikeDamageType] = 1.0;
$DamageScale[lfemale, $VehicleShrikeDamageType] = 1.0;
$DamageScale[marmor, $VehicleShrikeDamageType] = 1.0;
$DamageScale[mfemale, $VehicleShrikeDamageType] = 1.0;
$DamageScale[harmor, $VehicleShrikeDamageType] = 1.0;
//=====================================================================
$DamageScale[shrike, $PlasmaDamageType] = 1.0;
$DamageScale[shrike, $EnergyDamageType] = 1.0;
$DamageScale[shrike, $DebrisDamageType] = 1.0;
$DamageScale[shrike, $MissileDamageType] = 1.0;
$DamageScale[shrike, $SniperDamageType] = 1.0;
$DamageScale[shrike, $MortarDamageType] = 1.0;
$DamageScale[shrike, $MineDamageType]    = 1.0;
$DamageScale[shrike, $ELFDamageType]       = 1.0;
$DamageScale[shrike, $ShockDamageType]       = 1.0;
$DamageScale[shrike, $AssaultDamageType]       = 0.0;
$DamageScale[shrike, $SniperDamageType]         = 0.0;
$DamageScale[shrike, $ShotgunDamageType]        = 0.0;
$DamageScale[shrike, $TranqDamageType]          = 0.0;
$DamageScale[shrike, $FarSightDamageType]       = 1.0;
$DamageScale[shrike, $RaptorDamageType]         = 0.0;
$DamageScale[shrike, $DiscDamageType]           = 1.0;
$DamageScale[shrike, $RailDamageType]           = 1.0;
$DamageScale[shrike, $MinigunDamageType]        = 0.0;
$DamageScale[shrike, $ReaperDamageType]         = 1.0;
$DamageScale[shrike, $FirestormDamageType]      = 1.0;
$DamageScale[shrike, $FusionDamageType]         = 1.0;
$DamageScale[shrike, $FlamerDamageType]         = 1.0;
$DamageScale[shrike, $InfernoDamageType]        = 1.0;
$DamageScale[shrike, $GrenadeDamageType]        = 1.0;
$DamageScale[shrike, $FGLDamageType]            = 1.0;
$DamageScale[shrike, $MortarDamageType]         = 1.0;
$DamageScale[shrike, $FBWDamageType]            = 1.0;
$DamageScale[shrike, $MissileDamageType]        = 1.0;
$DamageScale[shrike, $TrojaxDamageType]         = 1.0;
$DamageScale[shrike, $EMPDamageType]            = 1.0;
$DamageScale[shrike, $DepturLaserDamageType]    = 1.0;
$DamageScale[shrike, $DepturSentryDamageType]   = 1.0;
$DamageScale[shrike, $DepturRaptorDamageType]   = 1.0;
$DamageScale[shrike, $DepturRocketDamageType]   = 1.0;
$DamageScale[shrike, $TurretLaserDamageType]    = 1.0;
$DamageScale[shrike, $TurretSonicDamageType]    = 1.0;
$DamageScale[shrike, $TurretElfDamageType]      = 1.0;
$DamageScale[shrike, $TurretFusionDamageType]   = 1.0;
$DamageScale[shrike, $TurretMortarDamageType]   = 1.0;
$DamageScale[shrike, $VehicleGravDamageType]    = 1.0;
$DamageScale[shrike, $VehicleShrikeDamageType]  = 1.0;

//---------------------------------------------------------------------

SoundData SoundVehShrikeThrust
{
   wavFileName = "veh_Shrike_thrust.wav";
   profile = Profile3dMediumLoop;
};
SoundData SoundVehShrikeIdle
{
   wavFileName = "veh_Shrike_idle.wav";
   profile = Profile3dMediumLoop;
};
SoundData SoundVehShrike
{
   wavFileName = "veh_Shrike.wav";
   profile = Profile3dMed;
};
SoundData ShrikeExplosion
{
   wavFileName = "exp_shrike.wav";
   profile = Profile3dMedium;
};

SoundData SoundWhizShrike
{
   wavFileName = "whiz_shrike.wav";
   profile = Profile3dCloseLoop;
};

//==========================================================
ExplosionData lrgLaserBlast
{
   shapeName = "flash_large.dts";
   soundId   =  ShrikeExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3;

   timeZero = 0.250;
   timeOne  = 0.650;

  
   colors[0]  = { 3.0, 0.0, 0.0 };
   colors[1]  = { 3.0, 0.0, 0.0 };
   colors[2]  = { 3.0, 0.0, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};
//============================================================
RocketData VehShrikeproj
{
   bulletShapeName = "proj_shrike.dts";
   explosionTag    = lrgLaserBlast;

   collisionRadius = 0.0;
   mass            = 5.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 5;
   damageType       = $VehicleShrikeDamageType;

	explosionRadius = 7.0;
	kickBackStrength = 150.0;
   muzzleVelocity   = 200.0;
   terminalVelocity = 400.0;
   acceleration     = 200.0;

   totalTime        = 3.0;
   liveTime         = 3.0;

   lightRange        = 7.0;
   lightColor        = { 3.0, 0.25, 0.25 };
   isVisible          = True;
   inheritedVelocityScale = 1.0;
	SoundID = SoundWhizShrike;
  };
//===========================================

FlierData Shrike
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "veh_shrike";
   shieldShapeName = "shield_medium";
   mass = 15.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.75;
   maxPitch = 0.75;
   maxSpeed = 175;
   minSpeed = -10;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 3.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 1.0;

	groundDamageScale = 1.0;

	projectileType = VehShrikeProj;
	reloadDelay = 0.25;
	repairRate = 0;
	fireSound = SoundVehShrike;
	damageSound = SoundVehCrash;
	ramDamage = 2.0;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundVehMount;
	dismountSound = SoundVehDismount;
	idleSound = SoundVehShrikeIdle;
	moveSound = SoundVehShrikeThrust;

	visibleDriver = true;
	driverPose = 22;
	description = "Shrike Fighter";
};

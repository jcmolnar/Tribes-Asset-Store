
$VehicleInvList[TransportVehicle] = 1;
$DataBlockName[TransportVehicle] = Transport;
$VehicleToItem[Transport] = TransportVehicle;
//----------------------------------------------------------------------------
$DamageScale[Transport, $PlasmaDamageType] = 1.0;
$DamageScale[Transport, $EnergyDamageType] = 1.0;
$DamageScale[Transport, $DebrisDamageType] = 1.0;
$DamageScale[Transport, $MissileDamageType] = 1.0;
$DamageScale[Transport, $SniperDamageType] = 0.0;
$DamageScale[Transport, $MortarDamageType] = 1.0;
$DamageScale[Transport, $MineDamageType]    = 1.0;
$DamageScale[Transport, $ELFDamageType]       = 1.0;
$DamageScale[Transport, $ShockDamageType]       = 1.0;
$DamageScale[Transport, $AssaultDamageType]       = 0.0;
$DamageScale[Transport, $SniperDamageType]         = 0.0;
$DamageScale[Transport, $ShotgunDamageType]        = 0.0;
$DamageScale[Transport, $TranqDamageType]          = 0.0;
$DamageScale[Transport, $FarSightDamageType]       = 1.0;
$DamageScale[Transport, $RaptorDamageType]         = 0.0;
$DamageScale[Transport, $DiscDamageType]           = 1.0;
$DamageScale[Transport, $RailDamageType]           = 1.0;
$DamageScale[Transport, $MinigunDamageType]        = 0.0;
$DamageScale[Transport, $ReaperDamageType]         = 1.0;
$DamageScale[Transport, $FirestormDamageType]      = 1.0;
$DamageScale[Transport, $FusionDamageType]         = 1.0;
$DamageScale[Transport, $FlamerDamageType]         = 1.0;
$DamageScale[Transport, $InfernoDamageType]        = 1.0;
$DamageScale[Transport, $GrenadeDamageType]        = 1.0;
$DamageScale[Transport, $FGLDamageType]            = 1.0;
$DamageScale[Transport, $MortarDamageType]         = 1.0;
$DamageScale[Transport, $FBWDamageType]            = 1.0;
$DamageScale[Transport, $MissileDamageType]        = 1.0;
$DamageScale[Transport, $TrojaxDamageType]         = 1.0;
$DamageScale[Transport, $EMPDamageType]            = 1.0;
$DamageScale[Transport, $DepturLaserDamageType]    = 1.0;
$DamageScale[Transport, $DepturSentryDamageType]   = 1.0;
$DamageScale[Transport, $DepturRaptorDamageType]   = 1.0;
$DamageScale[Transport, $DepturRocketDamageType]   = 1.0;
$DamageScale[Transport, $TurretLaserDamageType]    = 1.0;
$DamageScale[Transport, $TurretSonicDamageType]    = 1.0;
$DamageScale[Transport, $TurretElfDamageType]      = 1.0;
$DamageScale[Transport, $TurretFusionDamageType]   = 1.0;
$DamageScale[Transport, $TurretMortarDamageType]   = 1.0;
$DamageScale[Transport, $VehicleGravDamageType]    = 1.0;
$DamageScale[Transport, $VehicleShrikeDamageType]  = 1.0;

//----------------------------------------------------------------------------

//

SoundData SoundVehTransThrust
{
   wavFileName = "veh_Transport_thrust.wav";
   profile = Profile3dMediumLoop;
};
SoundData SoundVehTransIdle
{
   wavFileName = "veh_Transport_idle.wav";
   profile = Profile3dMediumLoop;
};

//==========================================================

FlierData Transport
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "veh_transport";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 100;
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
	idleSound = SoundVehTransIdle;
	moveSound = SoundVehTransThrust;

	visibleDriver = true;
	driverPose = 23;
	description = "Heavy Transport";
};



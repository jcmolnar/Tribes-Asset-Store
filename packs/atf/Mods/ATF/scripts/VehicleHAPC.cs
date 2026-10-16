//--------------------------------------

$VehicleInvList[HAPCVehicle] = 1;

$DataBlockName[HAPCVehicle] = HAPC;
$VehicleToItem[HAPC] = HAPCVehicle;

//--------------------------------------

$TeamItemMax[HAPCVehicle] = 1;

//--------------------------------------

RocketData HRocket
{
   bulletShapeName  = "Harmor.dts";
   explosionTag     = MortarExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 4.0;
   damageType       = $MissileDamageType;

   explosionRadius  = 25;
   kickBackStrength = 250.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "breath.dts";
   smokeDist   = 1.8;

   soundId   = SoundPlayerDeath;
};

//_______________________________________

FlierData HAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "rsmoke";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.55;
   maxPitch = 0.575;
   maxSpeed = 25;								   
   minSpeed = -1;
	lift = 1.35; //.35
	maxAlt = 15;
	maxVertical = 16;
	maxDamage = 16.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.125;
                
                projectileType = HRocket;
                fireSound = SoundPlayerDeath;
                reloadDelay = 3.0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "Decoy Bomber";
};

//--------------------------------------

$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $BulletDamageType] = 1.0;
$DamageScale[HAPC, $PlasmaDamageType] = 1.0;
$DamageScale[HAPC, $EnergyDamageType] = 1.0;
$DamageScale[HAPC, $ExplosionDamageType] = 1.0;
$DamageScale[HAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[HAPC, $DebrisDamageType] = 1.0;
$DamageScale[HAPC, $MissileDamageType] = 1.0;
$DamageScale[HAPC, $LaserDamageType] = 0.5;
$DamageScale[HAPC, $MortarDamageType] = 1.0;
$DamageScale[HAPC, $BlasterDamageType] = 0.5;
$DamageScale[HAPC, $ElectricityDamageType] = 1.0;
$DamageScale[HAPC, $MineDamageType]        = 1.0;
$DamageScale[Hapc, $ShockDamageType] = 0.8;
$DamageScale[Hapc, $AlienDamageType] = 1.0;
//--------------------------------------
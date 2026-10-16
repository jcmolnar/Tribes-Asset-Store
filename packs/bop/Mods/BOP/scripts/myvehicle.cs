//----------------------------------------------------------------------------

$VehicleInvList[DogFighterVehicle] = 1; 
$VehicleInvList[QuickLPCVehicle] = 1;

$DataBlockName[DogFighterVehicle] = DogFighter; 
$DataBlockName[QuickLPCVehicle] = QuickLPC; 

$VehicleToItem[DogFighter] = DogFighterVehicle; 
$VehicleToItem[QuickLPC] = QuickLPCVehicle; 

$TeamItemMax[DogFighterVehicle] = 3;
$TeamItemMax[QuickLPCVehicle] = 2; 

$DamageScale[DogFighter, $ImpactDamageType] = 1.0;
$DamageScale[DogFighter, $BulletDamageType] = 1.2;
$DamageScale[DogFighter, $PlasmaDamageType] = 1.0;
$DamageScale[DogFighter, $EnergyDamageType] = 1.0;
$DamageScale[DogFighter, $ExplosionDamageType] = 1.0;
$DamageScale[DogFighter, $ShrapnelDamageType] = 1.0;
$DamageScale[DogFighter, $DebrisDamageType] = 1.0;
$DamageScale[DogFighter, $MissileDamageType] = 1.5;
$DamageScale[DogFighter, $LaserDamageType] = 1.1;
$DamageScale[DogFighter, $MortarDamageType] = 1.0;
$DamageScale[DogFighter, $BlasterDamageType] = 1.0;
$DamageScale[DogFighter, $ElectricityDamageType] = 1.0;
$DamageScale[DogFighter, $MineDamageType]        = 1.0;

$DamageScale[QuickLPC, $ImpactDamageType] = 1.0;
$DamageScale[QuickLPC, $BulletDamageType] = 1.5;
$DamageScale[QuickLPC, $PlasmaDamageType] = 1.5;
$DamageScale[QuickLPC, $EnergyDamageType] = 1.5;
$DamageScale[QuickLPC, $ExplosionDamageType] = 2.0;
$DamageScale[QuickLPC, $ShrapnelDamageType] = 1.0;
$DamageScale[QuickLPC, $DebrisDamageType] = 1.0;
$DamageScale[QuickLPC, $MissileDamageType] = 2.0;
$DamageScale[QuickLPC, $LaserDamageType] = 2.0;
$DamageScale[QuickLPC, $MortarDamageType] = 1.0;
$DamageScale[QuickLPC, $BlasterDamageType] = 1.0;
$DamageScale[QuickLPC, $ElectricityDamageType] = 1.0;
$DamageScale[QuickLPC, $MineDamageType]        = 1.0;

ItemData DogFighterVehicle
{
	description = "DogFighter";
	className = "Vehicle";
	heading = "aVehicle";
	price = 650;
};

ItemData QuickLPCVehicle
{
	description = "QuickLPC";
	className = "Vehicle";
  	heading = "aVehicle";
	price = 750;
};

BulletData DogFighterBullet
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = bulletExp0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.21;
   damageType         = $BulletDamageType;

   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 2.0;
   isVisible          = True;

   tracerPercentage   = 2.0;
   tracerLength       = 10;
};

FlierData DogFighter
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   	shapeFile = "flyer";
   	shieldShapeName = "shield_medium";
   	mass = 9.0;
   	drag = 1.0;
   	density = 1.2;
   	maxBank = 0.6;
   	maxPitch = 0.5;
   	maxSpeed = 55;
   	minSpeed = -20;
	lift = 0.80;
	maxAlt = 20;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.5;

	groundDamageScale = 1.0;

	projectileType = DogFighterBullet;
	reloadDelay = 0.1;
	repairRate = 0;
	fireSound = SoundEnergyTurretFire;
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
	description = "Dogfighter";
};

FlierData QuickLPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   	shapeFile = "hover_apc_sml";
   	shieldShapeName = "shield_large";
   	mass = 16.0;
   	drag = 1.0;
   	density = 1.2;
   	maxBank = 0.3;
   	maxPitch = 0.175;
  	maxSpeed = 40;
  	minSpeed = -5;
	lift = 0.6;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.50;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "Quick LPC";
};

// ****


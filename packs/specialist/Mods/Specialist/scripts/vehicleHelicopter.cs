$VehicleInvList[HelicopterVehicle] = 1;
$DataBlockName[HelicopterVehicle] = Helicopter;
$VehicleToItem[Helicopter] = HelicopterVehicle;

$TeamItemMax[HelicopterVehicle] = 3;

// don't forget to initialize team data to zero in item.cs

ItemData HelicopterVehicle
{
	description = "Chopper";
	className = "Vehicle";
	heading = "aVehicle";
	price = 625;
};

FlierData Helicopter
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 9.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.9;
	maxPitch = 0.9;
	maxSpeed = 65;
	minSpeed = -30;
	lift = 0.85;
	maxAlt = 20;
	maxVertical = 25;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 1.0;

	groundDamageScale = 1.0;

	projectileType = AntiPersonnelRound;
	reloadDelay = 0.03;
	repairRate = 0;
	fireSound = SoundFireMortar;
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
	description = "Helicopter";
};

$DamageScale[Helicopter, $ImpactDamageType] = 1.0;
$DamageScale[Helicopter, $BulletDamageType] = 1.0;
$DamageScale[Helicopter, $PlasmaDamageType] = 1.0;
$DamageScale[Helicopter, $EnergyDamageType] = 1.0;
$DamageScale[Helicopter, $ExplosionDamageType] = 1.0;
$DamageScale[Helicopter, $ShrapnelDamageType] = 1.0;
$DamageScale[Helicopter, $DebrisDamageType] = 1.0;
$DamageScale[Helicopter, $MissileDamageType] = 1.0;
$DamageScale[Helicopter, $LaserDamageType] = 1.0;
$DamageScale[Helicopter, $MortarDamageType] = 1.0;
$DamageScale[Helicopter, $BlasterDamageType] = 0.5;
$DamageScale[Helicopter, $ElectricityDamageType] = 1.0;
$DamageScale[Helicopter, $MineDamageType]        = 1.0;

$DamageScale[Helicopter, $PoisonGasDamageType]        = 0.0;
$DamageScale[Helicopter, $RadiationDamageType]        = 0.0;
$DamageScale[Helicopter, $EMPDamageType]        = 1.0;
$DamageScale[Helicopter, $NullDamageType]        = 0.0;
$DamageScale[Helicopter, $FireDamageType]        = 0.8;
$DamageScale[Helicopter, $AcidDamageType]        = 1.0;
$DamageScale[Helicopter, $BlindDamageType]        = 1.0;
$DamageScale[Helicopter, $SniperRifleDamageType]        = 1.0;
$DamageScale[Helicopter, $ShotgunDamageType]        = 1.0;
$DamageScale[Helicopter, $FlakDamageType]        = 1.3;
$DamageScale[Helicopter, $ExplosiveGatDamageType]        = 1.0;
$DamageScale[Helicopter, $ArtilleryShellDamageType]        = 1.0;
$DamageScale[Helicopter, $TimedExplosiveDamageType]        = 1.0;
$DamageScale[Helicopter, $RemoteBombDamageType]        = 1.0;

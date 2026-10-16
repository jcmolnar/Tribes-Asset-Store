$VehicleInvList[FighterVehicle] = 1;
$DataBlockName[FighterVehicle] = Fighter;
$VehicleToItem[Fighter] = FighterVehicle;

$TeamItemMax[FighterVehicle] = 2;

// don't forget to initialize team data to zero in item.cs

ItemData FighterVehicle
{
	description = "Fighter";
	className = "Vehicle";
	heading = "aVehicle";
	price = 600;
};

FlierData Fighter
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 9.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 2.0;
	maxPitch = 2.0;
	maxSpeed = 85;
	minSpeed = -1;
	lift = 0.55;
	maxAlt = 35;
	maxVertical = 8;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = FlierRocket;
	reloadDelay = 2.0;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
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
	description = "Fighter";
};

$DamageScale[Fighter, $ImpactDamageType] = 1.0;
$DamageScale[Fighter, $BulletDamageType] = 1.0;
$DamageScale[Fighter, $PlasmaDamageType] = 1.0;
$DamageScale[Fighter, $EnergyDamageType] = 1.0;
$DamageScale[Fighter, $ExplosionDamageType] = 1.0;
$DamageScale[Fighter, $ShrapnelDamageType] = 1.0;
$DamageScale[Fighter, $DebrisDamageType] = 1.0;
$DamageScale[Fighter, $MissileDamageType] = 1.0;
$DamageScale[Fighter, $LaserDamageType] = 1.0;
$DamageScale[Fighter, $MortarDamageType] = 1.0;
$DamageScale[Fighter, $BlasterDamageType] = 0.5;
$DamageScale[Fighter, $ElectricityDamageType] = 1.0;
$DamageScale[Fighter, $MineDamageType]        = 1.0;

$DamageScale[Fighter, $PoisonGasDamageType]        = 0.0;
$DamageScale[Fighter, $RadiationDamageType]        = 0.0;
$DamageScale[Fighter, $EMPDamageType]        = 1.0;
$DamageScale[Fighter, $NullDamageType]        = 0.0;
$DamageScale[Fighter, $FireDamageType]        = 0.8;
$DamageScale[Fighter, $AcidDamageType]        = 1.0;
$DamageScale[Fighter, $BlindDamageType]        = 1.0;
$DamageScale[Fighter, $SniperRifleDamageType]        = 1.0;
$DamageScale[Fighter, $ShotgunDamageType]        = 1.0;
$DamageScale[Fighter, $FlakDamageType]        = 1.3;
$DamageScale[Fighter, $ExplosiveGatDamageType]        = 1.0;
$DamageScale[Fighter, $ArtilleryShellDamageType]        = 1.0;
$DamageScale[Fighter, $TimedExplosiveDamageType]        = 1.0;
$DamageScale[Fighter, $RemoteBombDamageType]        = 1.0;


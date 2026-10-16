$VehicleInvList[LAPCVehicle] = 1;
$DataBlockName[LAPCVehicle] = LAPC;
$VehicleToItem[LAPC] = LAPCVehicle;

addDeployable(LAPCVehicle, 2);

ItemData LAPCVehicle
{
	description = "3-Way Line";
	className = "Vehicle";
	heading = $InvHead[iVehi];
	price = 50;
};

$VehicleSlots[LAPC] = 2;

FlierData LAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "hover_apc_sml";
	shieldShapeName = "shield_large";
	mass = 18.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.25;
	maxPitch = 0.175;
	maxSpeed = 25;
	minSpeed = -1;
	lift = 0.5;
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
	description = "LPC";
};

$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 1.0;
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $EnergyDamageType] = 1.0;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 1.0;
$DamageScale[LAPC, $LaserDamageType] = 1.0;
$DamageScale[LAPC, $MortarDamageType] = 1.0;
$DamageScale[LAPC, $BlasterDamageType] = 1.0;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $MineDamageType]= 1.0;

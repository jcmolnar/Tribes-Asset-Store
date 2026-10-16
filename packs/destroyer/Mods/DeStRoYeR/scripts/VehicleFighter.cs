//--------------------------------------

$VehicleInvList[FighterVehicle] = 1;

$DataBlockName[FighterVehicle] = Fighter;
$VehicleToItem[Fighter] = FighterVehicle;

//--------------------------------------

$TeamItemMax[FighterVehicle] = 3;

//--------------------------------------

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
   maxBank = 0.6;
   maxPitch = 0.6;
   maxSpeed = 60;
   minSpeed = -2;
	lift = 0.85;
	maxAlt = 2500;
	maxVertical = 2500;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.5;

	groundDamageScale = 1.0;

	projectileType = ChaingunBullet;
	reloadDelay = 0.01;
	repairRate = 0;
	fireSound = SoundFighterFire;
	damageSound = SoundFlierCrash;
	ramDamage = 1.6;
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

//--------------------------------------

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

//--------------------------------------
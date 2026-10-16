//This is a MiniMod Plugin...
//This is the Interceptor Pack from the ol' Renegades1.2 mod. Ported&Modified by Dewy.

FlierData Jet
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
   maxSpeed = 80;
   minSpeed = -2;
	lift = 0.95;
	maxAlt = 25;
	maxVertical = 12;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.8;

	groundDamageScale = 1.0;

	projectileType = JetBolt;
	reloadDelay = 0.15;
	repairRate = 0;
	fireSound = SoundFireBlaster;
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

};

$DamageScale[Jet, $ImpactDamageType] = 1.0;
$DamageScale[Jet, $BulletDamageType] = 1.0;
$DamageScale[Jet, $PlasmaDamageType] = 1.0;
$DamageScale[Jet, $EnergyDamageType] = 1.0;
$DamageScale[Jet, $ExplosionDamageType] = 1.0;
$DamageScale[Jet, $ShrapnelDamageType] = 1.0;
$DamageScale[Jet, $DebrisDamageType] = 1.0;
$DamageScale[Jet, $MissileDamageType] = 1.0;
$DamageScale[Jet, $LaserDamageType] = 1.0;
$DamageScale[Jet, $MortarDamageType] = 1.0;
$DamageScale[Jet, $BlasterDamageType] = 0.5;
$DamageScale[Jet, $ElectricityDamageType] = 1.0;
$DamageScale[Jet, $MineDamageType]        = 1.0;
$DamageScale[Jet, $SniperDamageType]        = 1.0;

//Ultra Fighter
$VehicleInvList[GuardVehicle] = 1;
$DataBlockName[GuardVehicle] = Guard;
$VehicleToItem[Guard] = GuardVehicle;
$VehicleSlots[Guard] = 0;

$TeamItemMax[GuardVehicle] = 1;

$DamageScale[Guard, $ImpactDamageType] = 1.0;
$DamageScale[Guard, $BulletDamageType] = 1.0;
$DamageScale[Guard, $PsiDamageType] = 1.0;
$DamageScale[Guard, $PlasmaDamageType] = 1.0;
$DamageScale[Guard, $EnergyDamageType] = 1.0;
$DamageScale[Guard, $ExplosionDamageType] = 1.0;
$DamageScale[Guard, $ShrapnelDamageType] = 1.0;
$DamageScale[Guard, $DebrisDamageType] = 1.0;
$DamageScale[Guard, $MissileDamageType] = 1.0;
$DamageScale[Guard, $LaserDamageType] = 1.0;
$DamageScale[Guard, $MortarDamageType] = 1.0;
$DamageScale[Guard, $BlasterDamageType] = 1.0;
$DamageScale[Guard, $ElectricityDamageType] = 1.0;
$DamageScale[Guard, $MineDamageType]        = 1.0;
$DamageScale[Guard, $SniperDamageType] = 1.0;
$DamageScale[Guard, $DDamageType] = 10.0;
$DamageScale[Guard, $DeathDamageType] = 1.0;
$DamageScale[Guard, $DDamageType] = 1.0;
$DamageScale[Guard, $FlamerDamageType] = 1.0;
$DamageScale[Guard, $ShellDamageType] = 1.0;
$DamageScale[Guard, $ShurikenDamageType] = 1.0;
$DamageScale[Guard, $ReaperDamageType] = 1.0;

GrenadeData GuardShot
{
  bulletShapeName = "rocket.dts";
  explosionTag = MortarExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 1.8;
  damageType = $PsiDamageType;
  explosionRadius = 50.0;
  kickBackStrength = 50.0;
  maxLevelFlightDist = 500;
  totalTime = 30.0;
  liveTime = 1.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.2;
  smokeName = "laserhit.dts";
};

function vehicleGuard::Initialize()
{
  $TeamItemCount[0 @ GuardVehicle] = 0;
  $TeamItemCount[1 @ GuardVehicle] = 0;
  $TeamItemCount[2 @ GuardVehicle] = 0;
  $TeamItemCount[3 @ GuardVehicle] = 0;
  $TeamItemCount[4 @ GuardVehicle] = 0;
  $TeamItemCount[5 @ GuardVehicle] = 0;
  $TeamItemCount[6 @ GuardVehicle] = 0;
  $TeamItemCount[7 @ GuardVehicle] = 0;
}

ItemData GuardVehicle 
{
  description = "Ultra Fighter";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 1000;
};

FlierData Guard
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   	shapeFile = "flyer";
   	shieldShapeName = "shield_medium";
   	mass = 9.0;
   	drag = 1.0;
   	density = 1.2;
   	maxBank = 2.6;
   	maxPitch = 2.7;
   	maxSpeed = 50;
   	minSpeed = 20;
	lift = 1.00;
	maxAlt = 30;
	maxVertical = 20;
	maxDamage = 1.2;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 2.0;
        range = 100;
        supression = true;
        castLOS = true;
	groundDamageScale = 0.1;
	projectileType = GuardShot;
	reloadDelay = 5.0;
	repairRate = 0;
	fireSound = SoundFireSeeking;
	damageSound = SoundFlierCrash;
	ramDamage = 2.0;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = ForceFieldOpen;
	dismountSound = ForceFieldClose;
	idleSound = SoundFlyerIdle;
	moveSound = SoundWindAmbient;

	visibleDriver = false;
	driverPose = 22;
};

function Guard::onPilot(%this, %player)
{
}

function Guard::onUnPilot(%this, %player)
{
}
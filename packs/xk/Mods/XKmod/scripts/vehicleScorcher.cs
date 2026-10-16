$VehicleInvList[ScorcherVehicle] = 1;
$DataBlockName[ScorcherVehicle] = Scorcher;
$VehicleToItem[Scorcher] = ScorcherVehicle;
$VehicleSlots[Scorcher] = 0;

$TeamItemMax[ScorcherVehicle] = 2;

$DamageScale[Scorcher, $ImpactDamageType] = 1.0;
$DamageScale[Scorcher, $BulletDamageType] = 1.0;
$DamageScale[Scorcher, $PlasmaDamageType] = 1.0;
$DamageScale[Scorcher, $EnergyDamageType] = 1.0;
$DamageScale[Scorcher, $ExplosionDamageType] = 1.0;
$DamageScale[Scorcher, $ShrapnelDamageType] = 1.0;
$DamageScale[Scorcher, $DebrisDamageType] = 1.0;
$DamageScale[Scorcher, $MissileDamageType] = 1.0;
$DamageScale[Scorcher, $LaserDamageType] = 1.0;
$DamageScale[Scorcher, $MortarDamageType] = 1.0;
$DamageScale[Scorcher, $BlasterDamageType] = 0.5;
$DamageScale[Scorcher, $ElectricityDamageType] = 1.0;
$DamageScale[Scorcher, $MineDamageType] = 1.0;
$DamageScale[Scorcher, $SniperDamageType] = 1.0;

function vehicleScorcher::Initialize() // PORT: was named vehicleInterceptor::Initialize (copy-paste)
{
  $TeamItemCount[0 @ ScorcherVehicle] = 0;
  $TeamItemCount[1 @ ScorcherVehicle] = 0;
  $TeamItemCount[2 @ ScorcherVehicle] = 0;
  $TeamItemCount[3 @ ScorcherVehicle] = 0;
  $TeamItemCount[4 @ ScorcherVehicle] = 0;
  $TeamItemCount[5 @ ScorcherVehicle] = 0;
  $TeamItemCount[6 @ ScorcherVehicle] = 0;
  $TeamItemCount[7 @ ScorcherVehicle] = 0;
}

GrenadeData NapalmShell
{
  bulletShapeName = "plasmatrail.dts";
  explosionTag = plasmaExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.1;
  mass = 3.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 0.06;
  damageType = $PlasmaDamageType;
  explosionRadius = 4.0;
  kickBackStrength = 2.0;
  maxLevelFlightDist = 200;
  totalTime = 18.0;
  liveTime = 0.2;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.1;
  smokeName = "plasmatrail.dts";
};

ItemData ScorcherVehicle 
{
  description = "Napalm Craft";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 2000;
};

FlierData Scorcher 
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
  maxSpeed = 70;
  minSpeed = -2;
  lift = 0.95;
  maxAlt = 25;
  maxVertical = 12;
  maxDamage = 0.6;
  damageLevel = {1.0, 1.0};
  maxEnergy = 100;
  accel = 0.8;
  groundDamageScale = 1.0;
  projectileType = NapalmShell;
  reloadDelay = 0.08;
  repairRate = 0;
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

function Scorcher::onPilot(%this, %player)
{
	//
}

function Scorcher::onUnPilot(%this, %player)
{
  //
}
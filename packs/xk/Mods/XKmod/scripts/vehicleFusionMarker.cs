$VehicleInvList[FusionMarkerVehicle] = 1;
$DataBlockName[FusionMarkerVehicle] = FusionMarker;
$VehicleToItem[FusionMarker] = FusionMarkerVehicle;
$VehicleSlots[FusionMarker] = 0;

$TeamItemMax[FusionMarkerVehicle] = 5;

$DamageScale[FusionMarker, $ImpactDamageType] = 1.0;
$DamageScale[FusionMarker, $BulletDamageType] = 1.0;
$DamageScale[FusionMarker, $PlasmaDamageType] = 1.0;
$DamageScale[FusionMarker, $EnergyDamageType] = 1.0;
$DamageScale[FusionMarker, $ExplosionDamageType] = 1.0;
$DamageScale[FusionMarker, $ShrapnelDamageType] = 1.0;
$DamageScale[FusionMarker, $DebrisDamageType] = 1.0;
$DamageScale[FusionMarker, $MissileDamageType] = 1.0;
$DamageScale[FusionMarker, $LaserDamageType] = 1.0;
$DamageScale[FusionMarker, $MortarDamageType] = 1.0;
$DamageScale[FusionMarker, $BlasterDamageType] = 0.5;
$DamageScale[FusionMarker, $ElectricityDamageType] = 1.0;
$DamageScale[FusionMarker, $MineDamageType] = 1.0;
$DamageScale[FusionMarker, $SniperDamageType] = 1.0;

function vehicleFusionMarker::Initialize() // PORT: was named vehicleInterceptor::Initialize (copy-paste)
{
  $TeamItemCount[0 @ FusionMarkerVehicle] = 0;
  $TeamItemCount[1 @ FusionMarkerVehicle] = 0;
  $TeamItemCount[2 @ FusionMarkerVehicle] = 0;
  $TeamItemCount[3 @ FusionMarkerVehicle] = 0;
  $TeamItemCount[4 @ FusionMarkerVehicle] = 0;
  $TeamItemCount[5 @ FusionMarkerVehicle] = 0;
  $TeamItemCount[6 @ FusionMarkerVehicle] = 0;
  $TeamItemCount[7 @ FusionMarkerVehicle] = 0;
}

ItemData FusionMarkerVehicle 
{
  description = "Disrupter";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 600;
};

BulletData VulcanIntBullet 
{
  bulletShapeName = "FusionBolt.dts";
  explosionTag = DiscExp0;
  expRandCycle = 3;
  mass = 0.05;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.18;
  damageType = $BulletDamageType;
  aimDeflection = 0.02;
  muzzleVelocity = 900.0;
  accel = 500.0;
  totalTime = 0.4;
  inheritedVelocityScale = 1.0;
  isVisible = False;
  tracerPercentage = 2.0;
  tracerLength = 100;
};

FlierData FusionMarker 
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
  projectileType = FusionBolt;
  reloadDelay = 0.02;
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
};

function FusionMarker::onPilot(%this, %player)
{
   %client = Player::getClient(%player);
   Bottomprint(%client, "The Fusion Marker is a nice vehicle with Fusion Blasters mounted on its sides.");
}

function FusionMarker::onUnPilot(%this, %player)
{
  //
}
//shuttle
$VehicleInvList[HAPCVehicle] = 1;
$DataBlockName[HAPCVehicle] = HAPC;
$VehicleToItem[HAPC] = HAPCVehicle;
$VehicleSlots[HAPC] = 4;

$TeamItemMax[HAPCVehicle] = 2;

$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $PsiDamageType] = 1.0;
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
$DamageScale[HAPC, $MineDamageType] = 1.0;
$DamageScale[HAPC, $SniperDamageType] = 1.0;
$DamageScale[HAPC, $MeltaDamageType] = 1.0;
$DamageScale[HAPC, $DeathDamageType] = 1.0;
$DamageScale[HAPC, $DDamageType] = 1.0;
$DamageScale[HAPC, $FlamerDamageType] = 1.0;
$DamageScale[HAPC, $ShellDamageType] = 1.0;
$DamageScale[HAPC, $ShurikenDamageType] = 1.0;
$DamageScale[HAPC, $ReaperDamageType] = 1.0;

function vehicleHAPC::Initialize()
{
  $TeamItemCount[0 @ HAPCVehicle] = 0;
  $TeamItemCount[1 @ HAPCVehicle] = 0;
  $TeamItemCount[2 @ HAPCVehicle] = 0;
  $TeamItemCount[3 @ HAPCVehicle] = 0;
  $TeamItemCount[4 @ HAPCVehicle] = 0;
  $TeamItemCount[5 @ HAPCVehicle] = 0;
  $TeamItemCount[6 @ HAPCVehicle] = 0;
  $TeamItemCount[7 @ HAPCVehicle] = 0;
}

GrenadeData FalcBooom
{
  bulletShapeName = "Shockwave_large.dts";
  explosionTag = MortarExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 1.6;
  damageType = $MortarDamageType;
  explosionRadius = 40.0;
  kickBackStrength = 250.0;
  maxLevelFlightDist = 500;
  totalTime = 30.0;
  liveTime = 2.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "paint.dts";
};

ItemData HAPCVehicle 
{
  description = "Shuttle-Protoss";
  className = "Vehicle";
  heading = $InvHead[ihPsh];
  price = 875;
};

FlierData HAPC 
{
  explosionId = flashExpLarge;
  debrisId = flashDebrisLarge;
  className = "Vehicle";
  shapeFile = "hover_apc";
  shieldShapeName = "shield_large";
  mass = 18.0;
  drag = 1.0;
  density = 1.2;
  maxBank = 0.25;
  maxPitch = 1.0;
  maxSpeed = 30;
  minSpeed = -1;
  lift = 0.35;
  maxAlt = 15;
  maxVertical = 6;
  maxDamage = 1.8;
  damageLevel = {1.0, 1.0};
  maxEnergy = 100;
  accel = 0.25;
  groundDamageScale = 0.125;
  projectileType = FalcBooom;
  repairRate = 0;
  ramDamage = 2;
  ramDamageType = -1;
  mapFilter = 2;
  mapIcon = "M_vehicle";
  fireSound = SoundFireMortar;
  reloadDelay = 4.0;
  damageSound = SoundTankCrash;
  visibleToSensor = true; 
  shadowDetailMask = 2;
  mountSound = SoundFlyerMount;
  dismountSound = SoundFlyerDismount;
  idleSound = SoundFlyerIdle;
  moveSound = SoundFlyerActive;
  visibleDriver = true;
  driverPose = 23;
};

function HAPC::onPilot(%this, %player)
{
  //
}

function HAPC::onUnPilot(%this, %player)
{
  //
}
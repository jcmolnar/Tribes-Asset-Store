$VehicleInvList[HAPCVehicle] = 1;
$DataBlockName[HAPCVehicle] = HAPC;
$VehicleToItem[HAPC] = HAPCVehicle;
$VehicleSlots[HAPC] = 4;

$TeamItemMax[HAPCVehicle] = 2;

$DamageScale[HAPC, $ImpactDamageType] = 1.0;
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
$DamageScale[HAPC, $ShotgunDamageType] = 1.0;

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

ItemData HAPCVehicle 
{
  description = "HPC";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
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
  maxPitch = 0.175;
  maxSpeed = 25;
  minSpeed = -1;
  lift = 0.35;
  maxAlt = 15;
  maxVertical = 6;
  maxDamage = 2.0;
  damageLevel = {1.0, 1.0};
  maxEnergy = 100;
  accel = 0.25;
  groundDamageScale = 0.125;
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
};

function HAPC::onPilot(%this, %player)
{
  //
}

function HAPC::onUnPilot(%this, %player)
{
  //
}
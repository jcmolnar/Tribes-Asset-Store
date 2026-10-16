$VehicleInvList[LAPCVehicle] = 1;
$DataBlockName[LAPCVehicle] = LAPC;
$VehicleToItem[LAPC] = LAPCVehicle;
$VehicleSlots[LAPC] = 2;

$TeamItemMax[LAPCVehicle] = 2;

$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 1.0;
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $EnergyDamageType] = 1.0;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 1.0;
$DamageScale[LAPC, $LaserDamageType] = 0.5;
$DamageScale[LAPC, $MortarDamageType] = 0.7;
$DamageScale[LAPC, $BlasterDamageType] = 0.5;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $MineDamageType] = 1.0;
$DamageScale[LAPC, $SniperDamageType] = 1.0;
$DamageScale[LAPC, $ShotgunDamageType] = 1.0;

function vehicleLAPC::Initialize()
{
  $TeamItemCount[0 @ LAPCVehicle] = 0;
  $TeamItemCount[1 @ LAPCVehicle] = 0;
  $TeamItemCount[2 @ LAPCVehicle] = 0;
  $TeamItemCount[3 @ LAPCVehicle] = 0;
  $TeamItemCount[4 @ LAPCVehicle] = 0;
  $TeamItemCount[5 @ LAPCVehicle] = 0;
  $TeamItemCount[6 @ LAPCVehicle] = 0;
  $TeamItemCount[7 @ LAPCVehicle] = 0;
}

ItemData LAPCVehicle 
{
  description = "BomberLPC";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 675;
};

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
  maxVertical = 9;
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
  projectileType = MortarShell;
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

function LAPC::onPilot(%this, %player)
{
  //
}

function LAPC::onUnPilot(%this, %player)
{
  //
}
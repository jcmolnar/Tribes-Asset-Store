$VehicleInvList[RunnerVehicle] = 1;
$DataBlockName[RunnerVehicle] = Runner;
$VehicleToItem[Runner] = RunnerVehicle;
$VehicleSlots[Runner] = 2;

$TeamItemMax[RunnerVehicle] = 20;

$DamageScale[Runner, $ImpactDamageType] = 1.0;
$DamageScale[Runner, $BulletDamageType] = 1.0;
$DamageScale[Runner, $PlasmaDamageType] = 1.0;
$DamageScale[Runner, $EnergyDamageType] = 1.0;
$DamageScale[Runner, $ExplosionDamageType] = 1.0;
$DamageScale[Runner, $ShrapnelDamageType] = 1.0;
$DamageScale[Runner, $DebrisDamageType] = 1.0;
$DamageScale[Runner, $MissileDamageType] = 1.0;
$DamageScale[Runner, $LaserDamageType] = 0.5;
$DamageScale[Runner, $MortarDamageType] = 0.7;
$DamageScale[Runner, $BlasterDamageType] = 0.5;
$DamageScale[Runner, $ElectricityDamageType] = 1.0;
$DamageScale[Runner, $MineDamageType] = 1.0;
$DamageScale[Runner, $SniperDamageType] = 1.0;

function vehicleRunner::Initialize()
{
  $TeamItemCount[0 @ RunnerVehicle] = 0;
  $TeamItemCount[1 @ RunnerVehicle] = 0;
  $TeamItemCount[2 @ RunnerVehicle] = 0;
  $TeamItemCount[3 @ RunnerVehicle] = 0;
  $TeamItemCount[4 @ RunnerVehicle] = 0;
  $TeamItemCount[5 @ RunnerVehicle] = 0;
  $TeamItemCount[6 @ RunnerVehicle] = 0;
  $TeamItemCount[7 @ RunnerVehicle] = 0;
}

ItemData RunnerVehicle 
{
  description = "Runner LPC";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 675;
};

FlierData Runner 
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
  projectileType = IonBolt;
  fireSound = SoundFireLaser;
  reloadDelay = 0.15;
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

function Runner::onPilot(%this, %player)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, " The Runner LPC is a good transport with an Ion Cannon which can short-circuit the enemy within seconds.");
}

function Runner::onUnPilot(%this, %player)
{
  //
}
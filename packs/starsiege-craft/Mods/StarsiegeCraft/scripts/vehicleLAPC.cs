//dropship
$VehicleInvList[LAPCVehicle] = 1;
$DataBlockName[LAPCVehicle] = LAPC;
$VehicleToItem[LAPC] = LAPCVehicle;
$VehicleSlots[LAPC] = 2;

$TeamItemMax[LAPCVehicle] = 2;

$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $PsiDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 1.0;
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $EnergyDamageType] = 1.0;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 0.4;
$DamageScale[LAPC, $LaserDamageType] = 0.5;
$DamageScale[LAPC, $MortarDamageType] = 0.7;
$DamageScale[LAPC, $BlasterDamageType] = 0.5;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $MineDamageType] = 1.0;
$DamageScale[LAPC, $SniperDamageType] = 1.0;
$DamageScale[LAPC, $PsiDamageType] = 1.0;
$DamageScale[LAPC, $ChemDamageType] = 1.0;
$DamageScale[LAPC, $KrakenDamageType] = 1.0;
$DamageScale[LAPC, $MeltaDamageType] = 1.0;
$DamageScale[LAPC, $DeathDamageType] = 1.0;
$DamageScale[LAPC, $DDamageType] = 1.0;
$DamageScale[LAPC, $FlamerDamageType] = 1.0;
$DamageScale[LAPC, $ShellDamageType] = 1.0;
$DamageScale[LAPC, $ShurikenDamageType] = 1.0;
$DamageScale[LAPC, $ReaperDamageType] = 1.0;

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
  description = "DropShip-Terran";
  className = "Vehicle";
  heading = $InvHead[ihTsh];
  price = 675;
};

GrenadeData DropGren
{
  bulletShapeName = "plasammo.dts";
  explosionTag = MortarExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 1.3;
  damageType = $MortarDamageType;
  explosionRadius = 50.0;
  kickBackStrength = 150.0;
  maxLevelFlightDist = 500;
  totalTime = 30.0;
  liveTime = 1.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "shotgunex.dts";
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
  maxBank = 0.6;
  maxPitch = 0.6;
  maxSpeed = 35;
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
  projectileType = DropGren;
  fireSound = SoundFireBlaster;
  reloadDelay = 3.5;
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
//A-10
$VehicleInvList[LAPCVehicle] = 1;
$DataBlockName[LAPCVehicle] = LAPC;
$VehicleToItem[LAPC] = LAPCVehicle;
$VehicleSlots[LAPC] = 2;

$TeamItemMax[LAPCVehicle] = 1;

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
  description = "A-10 Thunderbolt II";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 1700;
};

GrenadeData DropGren
{
  bulletShapeName = "mortar.dts";
  explosionTag = MortarExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 8.84;
  damageType = $EnergyDamageType;
  explosionRadius = 60.0;
  kickBackStrength = 10.0;
  maxLevelFlightDist = 0.3;
  totalTime = 25.0;
  liveTime = 25.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "smoke.dts";
};

FlierData LAPC
{
  explosionId = flashExpLarge;
  debrisId = flashDebrisLarge;
  className = "Vehicle";
  shapeFile = "flyer";
  shieldShapeName = "shield_large";
  mass = 18.0;
  drag = 1.0;
  density = 1.2;
  maxBank = 5.6;
  maxPitch = 5.6;
  maxSpeed = 20;
  minSpeed = -1;
  lift = 0.5;
  maxAlt = 70;
  maxVertical = 10;
  maxDamage = 11.7;
  damageLevel = {1.0, 1.0};
  destroyDamage = 1.0;
  maxEnergy = 100;
  accel = 0.15;
  groundDamageScale = 0.50;
  repairRate = 0;
  ramDamage = 2;
  ramDamageType = -1;
  mapFilter = 2;
  mapIcon = "M_vehicle";
  projectileType = DropGren;
  fireSound = SoundFireBlaster;
  reloadDelay = 6.523;
  damageSound = SoundTankCrash;
  visibleToSensor = true;
  shadowDetailMask = 2;
  mountSound = SoundFlyerMount;
  dismountSound = SoundFlyerDismount;
  idleSound = SoundFlyerIdle;
  moveSound = SoundFlyerActive;
  visibleDriver = false;
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
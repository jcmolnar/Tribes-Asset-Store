//carrier, toss, really bad evil ship
$VehicleInvList[TempestVehicle] = 1;
$DataBlockName[TempestVehicle] = Tempest;
$VehicleToItem[Tempest] = TempestVehicle;
$VehicleSlots[Tempest] = 4;

$TeamItemMax[TempestVehicle] = 2;

$DamageScale[Tempest, $ImpactDamageType] = 1.0;
$DamageScale[Tempest, $PsiDamageType] = 1.0;
$DamageScale[Tempest, $BulletDamageType] = 1.0;
$DamageScale[Tempest, $PlasmaDamageType] = 1.0;
$DamageScale[Tempest, $EnergyDamageType] = 1.0;
$DamageScale[Tempest, $ExplosionDamageType] = 1.0;
$DamageScale[Tempest, $ShrapnelDamageType] = 1.0;
$DamageScale[Tempest, $DebrisDamageType] = 1.0;
$DamageScale[Tempest, $MissileDamageType] = 1.0;
$DamageScale[Tempest, $LaserDamageType] = 0.5;
$DamageScale[Tempest, $MortarDamageType] = 1.0;
$DamageScale[Tempest, $BlasterDamageType] = 0.5;
$DamageScale[Tempest, $ElectricityDamageType] = 1.0;
$DamageScale[Tempest, $MineDamageType] = 1.0;
$DamageScale[Tempest, $SniperDamageType] = 1.0;
$DamageScale[Tempest, $MeltaDamageType] = 1.0;
$DamageScale[Tempest, $DeathDamageType] = 1.0;
$DamageScale[Tempest, $DDamageType] = 1.0;
$DamageScale[Tempest, $FlamerDamageType] = 1.0;
$DamageScale[Tempest, $ShellDamageType] = 1.0;
$DamageScale[Tempest, $ShurikenDamageType] = 1.0;
$DamageScale[Tempest, $ReaperDamageType] = 1.0;

function vehicleTempest::Initialize()
{
  $TeamItemCount[0 @ TempestVehicle] = 0;
  $TeamItemCount[1 @ TempestVehicle] = 0;
  $TeamItemCount[2 @ TempestVehicle] = 0;
  $TeamItemCount[3 @ TempestVehicle] = 0;
  $TeamItemCount[4 @ TempestVehicle] = 0;
  $TeamItemCount[5 @ TempestVehicle] = 0;
  $TeamItemCount[6 @ TempestVehicle] = 0;
  $TeamItemCount[7 @ TempestVehicle] = 0;
}

RocketData TempBoom
{
  bulletShapeName = "shockwave_large.dts";
  explosionTag = LargeShockwave;
  collideWithOwner = True;
  collisionRadius = 0.0;
  mass = 5.0;
  damageClass = 1;
  damageValue = 1.8;
  damageType = $DeathDamageType;
  explosionRadius = 40.0;
  kickBackStrength = 250.0;
  muzzleVelocity = 120.0;
  terminalVelocity = 120.0;
  totalTime = 30.0;
  liveTime = 20.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "fusionex.dts";
  SmokeDist = 5.0;
};

ItemData TempestVehicle 
{
  description = "Carrier-Protoss";
  className = "Vehicle";
  heading = $InvHead[ihPsh];
  price = 1550;
};

FlierData Tempest 
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
  maxPitch = 0.3;
  maxSpeed = 23;
  minSpeed = -1;
  lift = 0.35;
  maxAlt = 15;
  maxVertical = 6;
  maxDamage = 2.0;
  damageLevel = {1.0, 1.0};
  maxEnergy = 100;
  accel = 0.25;
  groundDamageScale = 0.125;
  projectileType = TempBoom;
  reloadDelay = 7.0;
  repairRate = 0;
  ramDamage = 2;
  ramDamageType = -1;
  mapFilter = 2;
  mapIcon = "M_vehicle";
  fireSound = SoundFireFlierRocket;
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

function Tempest::onPilot(%this, %player)
{
  //
}

function Tempest::onUnPilot(%this, %player)
{
  //
}
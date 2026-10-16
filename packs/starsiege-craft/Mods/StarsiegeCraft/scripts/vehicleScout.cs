//anti-matter scout
$VehicleInvList[ScoutVehicle] = 1;
$DataBlockName[ScoutVehicle] = Scout;
$VehicleToItem[Scout] = ScoutVehicle;
$VehicleSlots[Scout] = 0;

$TeamItemMax[ScoutVehicle] = 3;

$DamageScale[Scout, $ImpactDamageType] = 1.0;
$DamageScale[Scout, $PsiDamageType] = 1.0;
$DamageScale[Scout, $BulletDamageType] = 1.0;
$DamageScale[Scout, $PlasmaDamageType] = 1.0;
$DamageScale[Scout, $EnergyDamageType] = 1.0;
$DamageScale[Scout, $ExplosionDamageType] = 1.0;
$DamageScale[Scout, $ShrapnelDamageType] = 1.0;
$DamageScale[Scout, $DebrisDamageType] = 1.0;
$DamageScale[Scout, $MissileDamageType] = 1.0;
$DamageScale[Scout, $LaserDamageType] = 1.0;
$DamageScale[Scout, $MortarDamageType] = 1.0;
$DamageScale[Scout, $BlasterDamageType] = 0.5;
$DamageScale[Scout, $ElectricityDamageType] = 1.0;
$DamageScale[Scout, $MineDamageType] = 1.0;
$DamageScale[Scout, $SniperDamageType] = 1.0;
$DamageScale[Scout, $MeltaDamageType] = 1.0;
$DamageScale[Scout, $DeathDamageType] = 1.0;
$DamageScale[Scout, $DDamageType] = 1.0;
$DamageScale[Scout, $FlamerDamageType] = 1.0;
$DamageScale[Scout, $ShellDamageType] = 1.0;
$DamageScale[Scout, $ShurikenDamageType] = 1.0;
$DamageScale[Scout, $ReaperDamageType] = 1.0;

RocketData ScoutRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0;
   mass             = 2.0;

   damageClass      = 1;
   damageValue      = 0.8;
   damageType       = $MissileDamageType;

   explosionRadius  = 20.0;
   kickBackStrength = 150;
   muzzleVelocity   = 200.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 4.0;
   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "paint.dts";
   smokeDist   = 1.0;
};

function vehicleScout::Initialize()
{
  $TeamItemCount[0 @ ScoutVehicle] = 0;
  $TeamItemCount[1 @ ScoutVehicle] = 0;
  $TeamItemCount[2 @ ScoutVehicle] = 0;
  $TeamItemCount[3 @ ScoutVehicle] = 0;
  $TeamItemCount[4 @ ScoutVehicle] = 0;
  $TeamItemCount[5 @ ScoutVehicle] = 0;
  $TeamItemCount[6 @ ScoutVehicle] = 0;
  $TeamItemCount[7 @ ScoutVehicle] = 0;
}

ItemData ScoutVehicle 
{
  description = "AntiMatter Scout-toss";
  className = "Vehicle";
  heading = $InvHead[ihPsh];
  price = 600;
};

FlierData Scout 
{
  explosionId = flashExpLarge;
  debrisId = flashDebrisLarge;
  className = "Vehicle";
  shapeFile = "flyer";
  shieldShapeName = "shield_medium";
  mass = 9.0;
  drag = 1.0;
  density = 1.2;
  maxBank = 2.0;
   	maxPitch = 15.0;
   	maxSpeed = 45;
   	minSpeed = -20;
	lift = 1.00;
	maxAlt = 30;
	maxVertical = 20;
  maxDamage = 0.4;
  damageLevel = {1.0, 1.0};
  maxEnergy = 100;
  accel = 2.0;
  groundDamageScale = 1.0;
  projectileType = ScoutRocket;
  reloadDelay = 1.2;
  repairRate = 0;
  fireSound = SoundFireFlierRocket;
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

function Scout::onPilot(%this, %player)
{
  //
}

function Scout::onUnPilot(%this, %player)
{
  //
}
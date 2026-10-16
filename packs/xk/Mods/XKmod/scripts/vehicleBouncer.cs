$VehicleInvList[BouncerVehicle] = 1;
$DataBlockName[BouncerVehicle] = Bouncer;
$VehicleToItem[Bouncer] = BouncerVehicle;
$VehicleSlots[Bouncer] = 0;

$TeamItemMax[BouncerVehicle] = 3;

$DamageScale[Bouncer, $ImpactDamageType] = 1.0;
$DamageScale[Bouncer, $RocketDamageType] = 1.0;
$DamageScale[Bouncer, $PlasmaDamageType] = 1.0;
$DamageScale[Bouncer, $EnergyDamageType] = 1.0;
$DamageScale[Bouncer, $ExplosionDamageType] = 1.0;
$DamageScale[Bouncer, $ShrapnelDamageType] = 1.0;
$DamageScale[bouncer, $DebrisDamageType] = 1.0;
$DamageScale[Bouncer, $MissileDamageType] = 1.0;
$DamageScale[Bouncer, $LaserDamageType] = 1.0;
$DamageScale[Bouncer, $MortarDamageType] = 1.0;
$DamageScale[Bouncer, $BlasterDamageType] = 0.5;
$DamageScale[Bouncer, $ElectricityDamageType] = 1.0;
$DamageScale[Bouncer, $MineDamageType] = 1.0;
$DamageScale[Bouncer, $SniperDamageType] = 1.0;

function vehicleBouncer::Initialize()
{
  $TeamItemCount[0 @ BouncerVehicle] = 0;
  $TeamItemCount[1 @ BouncerVehicle] = 0;
  $TeamItemCount[2 @ BouncerVehicle] = 0;
  $TeamItemCount[3 @ BouncerVehicle] = 0;
  $TeamItemCount[4 @ BouncerVehicle] = 0;
  $TeamItemCount[5 @ BouncerVehicle] = 0;
  $TeamItemCount[6 @ BouncerVehicle] = 0;
  $TeamItemCount[7 @ BouncerVehicle] = 0;
}

RocketData BouncerMissile 
{
  bulletShapeName = "Shield_Large.dts";
  explosionTag = LargeShockwave;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.0;
  damageType = $ExplosionDamageType;
  explosionRadius = 30.5;
  kickBackStrength = 850.0;
  muzzleVelocity = 85.0;
  terminalVelocity = 2000.0;
  acceleration = 300.0;
  totalTime = 8.5;
  liveTime = 18.0;
  lightRange = 5.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "Shield.dts";
  smokeDist = 1.8;
  soundId = SoundJetHeavy;
};

ItemData BouncerVehicle 
{
  description = "Bouncer";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 600;
};

FlierData Bouncer 
{
  explosionId = flashExpLarge;
  debrisId = flashDebrisLarge;
  className = "Vehicle";
  shapeFile = "flyer";
  shieldShapeName = "shield_medium";
  mass = 9.0;
  drag = 1.0;
  density = 1.2;
  maxBank = 0.5;
  maxPitch = 0.5;
  maxSpeed = 65;
  minSpeed = -2;
  lift = 0.75;
  maxAlt = 25;
  maxVertical = 10;
  maxDamage = 0.65;
  damageLevel = {1.0, 1.0};
  maxEnergy = 100;
  accel = 0.6;
  groundDamageScale = 1.0;
  projectileType = BouncerMissile;
  reloadDelay = 2;
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

function Bouncer::onPilot(%this, %player)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "The Bouncer has a Blast-Rocket that packs much force when it hits a target, it can knock a light armor over the horizon.");
}

function Bouncer::onUnPilot(%this, %player)
{
  //
}

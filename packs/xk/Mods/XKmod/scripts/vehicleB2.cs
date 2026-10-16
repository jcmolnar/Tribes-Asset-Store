$VehicleInvList[B2Vehicle] = 1;
$DataBlockName[B2Vehicle] = B2;
$VehicleToItem[B2] = B2Vehicle;
$VehicleSlots[B2] = 2;

$TeamItemMax[B2Vehicle] = 3;

$DamageScale[B2, $ImpactDamageType] = 1.0;
$DamageScale[B2, $BulletDamageType] = 1.0;
$DamageScale[B2, $PlasmaDamageType] = 1.0;
$DamageScale[B2, $EnergyDamageType] = 1.0;
$DamageScale[B2, $ExplosionDamageType] = 1.0;
$DamageScale[B2, $ShrapnelDamageType] = 1.0;
$DamageScale[B2, $DebrisDamageType] = 1.0;
$DamageScale[B2, $MissileDamageType] = 1.0;
$DamageScale[B2, $LaserDamageType] = 0.5;
$DamageScale[B2, $MortarDamageType] = 0.7;
$DamageScale[B2, $BlasterDamageType] = 0.5;
$DamageScale[B2, $ElectricityDamageType] = 1.0;
$DamageScale[B2, $MineDamageType] = 1.0;
$DamageScale[B2, $SniperDamageType] = 1.0;

function vehicleB2::Initialize()
{
  $TeamItemCount[0 @ B2Vehicle] = 0;
  $TeamItemCount[1 @ B2Vehicle] = 0;
  $TeamItemCount[2 @ B2Vehicle] = 0;
  $TeamItemCount[3 @ B2Vehicle] = 0;
  $TeamItemCount[4 @ B2Vehicle] = 0;
  $TeamItemCount[5 @ B2Vehicle] = 0;
  $TeamItemCount[6 @ B2Vehicle] = 0;
  $TeamItemCount[7 @ B2Vehicle] = 0;
}

ItemData B2Vehicle
{
  description = "B-2 Stealth Bomber";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 2000;
};

FlierData B2
{
  explosionId = flashExpLarge;
  debrisId = flashDebrisLarge;
  className = "Vehicle";
  shapeFile = "hover_apc_sml";
  shieldShapeName = "shield_large";
  mass = 20.0;
  drag = 1.0;
  density = 1.2;
  maxBank = 0.25;
  maxPitch = 0.175;
  maxSpeed = 50;
  minSpeed = -1;
  lift = 0.8;
  maxAlt = 20;
  maxVertical = 9;
  maxDamage = 1.5;
  damageLevel = {1.0, 1.0};
  accel = 0.25;
  groundDamageScale = 0.50;
  projectileType = B2Nukebomb;
  reloadDelay = 10.0;
  fireSound = SoundFireMortar;
  repairRate = 0;
  ramDamage = 2;
  ramDamageType = -1;
  destroyDamage = 1.0;
  maxEnergy = 100;
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

function B2::onPilot(%this, %player)
{
  GameBase::startFadeout(%this);
  %client = Player::getClient(%player);
  Bottomprint(%client, "The B2 Stealth Bomber can wipeout anything with it's Nuke");
}

function B2::onUnPilot(%this, %player)
{
  GameBase::startFadein(%this);
}


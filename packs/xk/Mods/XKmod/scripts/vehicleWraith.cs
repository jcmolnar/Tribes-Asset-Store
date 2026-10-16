$VehicleInvList[WraithVehicle] = 1;
$DataBlockName[WraithVehicle] = Wraith;
$VehicleToItem[Wraith] = WraithVehicle;
$VehicleSlots[Wraith] = 0;

$TeamItemMax[WraithVehicle] = 2;

$DamageScale[Wraith, $ImpactDamageType] = 1.0;
$DamageScale[Wraith, $BulletDamageType] = 1.0;
$DamageScale[Wraith, $PlasmaDamageType] = 1.0;
$DamageScale[Wraith, $EnergyDamageType] = 1.0;
$DamageScale[Wraith, $ExplosionDamageType] = 1.0;
$DamageScale[Wraith, $ShrapnelDamageType] = 1.0;
$DamageScale[Wraith, $DebrisDamageType] = 1.0;
$DamageScale[Wraith, $MissileDamageType] = 1.0;
$DamageScale[Wraith, $LaserDamageType] = 1.0;
$DamageScale[Wraith, $MortarDamageType] = 1.0;
$DamageScale[Wraith, $BlasterDamageType] = 0.5;
$DamageScale[Wraith, $ElectricityDamageType] = 1.0;
$DamageScale[Wraith, $MineDamageType] = 1.0;
$DamageScale[Wraith, $SniperDamageType] = 1.0;

function vehicleWraith::Initialize()
{
  $TeamItemCount[0 @ WraithVehicle] = 0;
  $TeamItemCount[1 @ WraithVehicle] = 0;
  $TeamItemCount[2 @ WraithVehicle] = 0;
  $TeamItemCount[3 @ WraithVehicle] = 0;
  $TeamItemCount[4 @ WraithVehicle] = 0;
  $TeamItemCount[5 @ WraithVehicle] = 0;
  $TeamItemCount[6 @ WraithVehicle] = 0;
  $TeamItemCount[7 @ WraithVehicle] = 0;
}

ItemData WraithVehicle 
{
  description = "Wraith";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 600;
};

FlierData Wraith 
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
  maxSpeed = 50;
  minSpeed = -2;
  lift = 0.75;
  maxAlt = 25;
  maxVertical = 10;
  maxDamage = 0.5;
  damageLevel = {1.0, 1.0};
  maxEnergy = 100;
  accel = 0.4;
  groundDamageScale = 1.0;
  weaponType = 0;
  accuFire = true;
  reloadTime = 13.5;
  minEnergy = 3;
  maxEnergy = 4;
  reloadDelay = 0.1;
  lightType = 3;
  lightRadius = 2;
  lightTime = 1;
  lightColor = { 1, 0, 0 };
  repairRate = 0;
  fireSound = SoundFireFlierRocket;
  damageSound = SoundFlierCrash;
  ramDamage = 1.5;
  ramDamageType = -1;
  mapFilter = 2;
  mapIcon = "M_vehicle";
  visibleToSensor = false;
  shadowDetailMask = 2;
  mountSound = SoundFlyerMount;
  dismountSound = SoundFlyerDismount;
  idleSound = SoundFlyerIdle;
  moveSound = SoundWind1;
  visibleDriver = false;
  driverPose = 22;
};

function Wraith::onPilot(%this, %player)
{
  GameBase::startFadeout(%this);
  %client = Player::getClient(%player);
  Bottomprint(%client, "The Wraith is a silent stealthy model that is invisible and undetecable.");
}

function Wraith::onUnPilot(%this, %player)
{
  GameBase::startFadein(%this);
}

 
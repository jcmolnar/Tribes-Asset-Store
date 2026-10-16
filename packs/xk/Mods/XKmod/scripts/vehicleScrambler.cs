$VehicleInvList[ScramblerVehicle] = 1;
$DataBlockName[ScramblerVehicle] = Scrambler;
$VehicleToItem[Scrambler] = ScramblerVehicle;
$VehicleSlots[Scrambler] = 0;

$TeamItemMax[ScramblerVehicle] = 3;

$DamageScale[Scrambler, $ImpactDamageType] = 1.0;
$DamageScale[Scrambler, $BulletDamageType] = 1.0;
$DamageScale[Scrambler, $PlasmaDamageType] = 1.0;
$DamageScale[Scrambler, $EnergyDamageType] = 1.0;
$DamageScale[Scrambler, $ExplosionDamageType] = 1.0;
$DamageScale[Scrambler, $ShrapnelDamageType] = 1.0;
$DamageScale[Scrambler, $DebrisDamageType] = 1.0;
$DamageScale[Scrambler, $MissileDamageType] = 1.0;
$DamageScale[Scrambler, $LaserDamageType] = 1.0;
$DamageScale[Scrambler, $MortarDamageType] = 1.0;
$DamageScale[Scrambler, $BlasterDamageType] = 0.5;
$DamageScale[Scrambler, $ElectricityDamageType] = 1.0;
$DamageScale[Scrambler, $MineDamageType] = 1.0;
$DamageScale[Scrambler, $SniperDamageType] = 1.0;

function vehicleScrambler::Initialize()
{
  $TeamItemCount[0 @ ScramblerVehicle] = 0;
  $TeamItemCount[1 @ ScramblerVehicle] = 0;
  $TeamItemCount[2 @ ScramblerVehicle] = 0;
  $TeamItemCount[3 @ ScramblerVehicle] = 0;
  $TeamItemCount[4 @ ScramblerVehicle] = 0;
  $TeamItemCount[5 @ ScramblerVehicle] = 0;
  $TeamItemCount[6 @ ScramblerVehicle] = 0;
  $TeamItemCount[7 @ ScramblerVehicle] = 0;
}

ItemData ScramblerVehicle 
{
  description = "Scrambler";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 600;
};

FlierData Scrambler 
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
  projectileType = DiscShell;
  reloadDelay = 1.2;
  repairRate = 0;
  fireSound = SoundFireDisc;
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

function Scrambler::onPilot(%this, %player)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "The Scrambler is a nice vehicle that has Disk Cannons that can blow up anything.");
}

function Scrambler::onUnPilot(%this, %player)
{
  //
}
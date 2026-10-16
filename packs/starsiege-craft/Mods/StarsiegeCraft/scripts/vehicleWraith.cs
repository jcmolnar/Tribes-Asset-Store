//Wraith, Terran
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
$DamageScale[Wraith, $BlasterDamageType] = 1.0;
$DamageScale[Wraith, $ElectricityDamageType] = 1.0;
$DamageScale[Wraith, $MineDamageType] = 1.0;
$DamageScale[Wraith, $SniperDamageType] = 1.0;
$DamageScale[Wraith, $MeltaDamageType] = 1.0;
$DamageScale[Wraith, $DeathDamageType] = 1.0;
$DamageScale[Wraith, $DDamageType] = 1.0;
$DamageScale[Wraith, $FlamerDamageType] = 1.0;
$DamageScale[Wraith, $ShellDamageType] = 1.0;
$DamageScale[Wraith, $ShurikenDamageType] = 1.0;
$DamageScale[Wraith, $ReaperDamageType] = 1.0;

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

RocketData WraithMissile
{
   bulletShapeName  = "mortar.dts";
   ExplosionTag     = RocketExp;
   collisionRadius  = 0;
   mass             = 2.0;

   damageClass      = 1;
   damageValue      = 1.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 17.0;
   kickBackStrength = 300;
   muzzleVelocity   = 300.0;
   terminalVelocity = 300.0;
   acceleration     = 6.5;
   totalTime        = 10.0;
   liveTime         = 4.0;
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "smoke.dts";
   smokeDist   = 30;
};

ItemData WraithVehicle 
{
  description = "Wraith-Terran";
  className = "Vehicle";
  heading = $InvHead[ihTsh];
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
  maxBank = 2.6;
   	maxPitch = 2.5;
   	maxSpeed = 35;
   	minSpeed = -20;
	lift = 1.00;
	maxAlt = 30;
	maxVertical = 20;
  maxDamage = 0.4;
  damageLevel = {1.0, 1.0};
  maxEnergy = 100;
  accel = 0.8;
  groundDamageScale = 1.0;
  projectileType = WraithMissile;
  reloadDelay = 1.6;
  repairRate = 0;
  fireSound = MineExplosion;
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

function Wraith::onPilot(%this, %player)
{
  //GameBase::startFadeout(%this);
}

function Wraith::onUnPilot(%this, %player)
{
  //GameBase::startFadein(%this);
}
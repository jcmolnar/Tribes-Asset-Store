//Guidable Nuke
$VehicleInvList[TactGHNukeVehicle] = 1;
$DataBlockName[TactGHNukeVehicle] = TactGHNuke;
$VehicleToItem[TactGHNuke] = TactGHNukeVehicle;
$VehicleSlots[TactGHNuke] = 0;

$TeamItemMax[TactGHNukeVehicle] = 5;

$DamageScale[TactGHNuke, $ImpactDamageType] = 1.0;
$DamageScale[TactGHNuke, $PsiDamageType] = 1.0;
$DamageScale[TactGHNuke, $BulletDamageType] = 1.0;
$DamageScale[TactGHNuke, $PlasmaDamageType] = 1.0;
$DamageScale[TactGHNuke, $EnergyDamageType] = 1.0;
$DamageScale[TactGHNuke, $ExplosionDamageType] = 1.0;
$DamageScale[TactGHNuke, $ShrapnelDamageType] = 1.0;
$DamageScale[TactGHNuke, $DebrisDamageType] = 1.0;
$DamageScale[TactGHNuke, $MissileDamageType] = 1.0;
$DamageScale[TactGHNuke, $LaserDamageType] = 1.0;
$DamageScale[TactGHNuke, $MortarDamageType] = 1.0;
$DamageScale[TactGHNuke, $BlasterDamageType] = 0.5;
$DamageScale[TactGHNuke, $ElectricityDamageType] = 1.0;
$DamageScale[TactGHNuke, $MineDamageType] = 1.0;
$DamageScale[TactGHNuke, $SniperDamageType] = 1.0;
$DamageScale[TactGHNuke, $DeathDamageType] = 1.0;
$DamageScale[TactGHNuke, $DDamageType] = 1.0;
$DamageScale[TactGHNuke, $FlamerDamageType] = 1.0;
$DamageScale[TactGHNuke, $ShellDamageType] = 1.0;
$DamageScale[TactGHNuke, $ShurikenDamageType] = 1.0;
$DamageScale[TactGHNuke, $ReaperDamageType] = 1.0;

function vehicleTactGHNuke::Initialize()
{
  $TeamItemCount[0 @ TactGHNukeVehicle] = 0;
  $TeamItemCount[1 @ TactGHNukeVehicle] = 0;
  $TeamItemCount[2 @ TactGHNukeVehicle] = 0;
  $TeamItemCount[3 @ TactGHNukeVehicle] = 0;
  $TeamItemCount[4 @ TactGHNukeVehicle] = 0;
  $TeamItemCount[5 @ TactGHNukeVehicle] = 0;
  $TeamItemCount[6 @ TactGHNukeVehicle] = 0;
  $TeamItemCount[7 @ TactGHNukeVehicle] = 0;
}

RocketData TactGHNukeBoom
{
  bulletShapeName = "rocket.dts";
  explosionTag = DCannonBoom;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 2.0;
  baseDamageType = $MortarDamageType;
  explosionRadius = 25.0;
  kickBackStrength = 450.0;
  muzzleVelocity = 30.0;
  terminalVelocity = 30.0;
  acceleration = 5.0;
  totalTime = 10.0;
  liveTime = 10.0;
  lightRange = 10.0;
  lightColor = { 1.0, 6.7, 9.5 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "plasmabolt.dts";
  smokeDist = 2.0;
  soundId = SoundJetHeavy;
};

ItemData TactGHNukeVehicle 
{
  description = "Tactical Nuke-Terran";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 2000;
};

FlierData TactGHNuke 
{
  explosionId = LargeShockwave;
  debrisId = flashDebrisMedium;
  className = "Vehicle";
  shapeFile = "rocket";
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
  maxDamage = 0.6;
  damageLevel = {1.0, 1.0};
  maxEnergy = 100;
  accel = 1.5;
  groundDamageScale = 1.0;
  projectileType = TactGHNukeBoom;
  reloadDelay = 0.1;
  repairRate = 0;
  fireSound = explosion4;
  damageSound = SoundFlierCrash;
  ramDamage = 5;
  ramDamageType = -1;
  mapFilter = 2;
  mapIcon = "M_vehicle";
  visibleToSensor = true;
  shadowDetailMask = 2;
  mountSound = SoundFlyerMount;
  dismountSound = SoundFlyerDismount;
  idleSound = SoundFlyerIdle;
  moveSound = SoundFlyerActive;
  visibleDriver = false;
  driverPose = 22;
};

function TactGHNuke::onPilot(%this, %player)
{
  //
}

function TactGHNuke::onUnPilot(%this, %player)
{
  Vehicle::onUnPilot(%this, %player);
  Projectile::SpawnProjectile(TactGHNukeBoom, GameBase::GetMuzzleTransform(%player), %this, 0, %client.LaunchAt);
}
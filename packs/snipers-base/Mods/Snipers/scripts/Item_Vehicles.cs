//----------------------------------------------------------------------------
//
//	VEHICLES
//
//----------------------------------------------------------------------------

//---------------------
//	SCOUT
//---------------------

$VehicleInvList[ScoutVehicle] = 1;
$DataBlockName[ScoutVehicle] = Scout;
$VehicleToItem[Scout] = ScoutVehicle;
$VehicleSlots[Scout] = 0;

$TeamItemMax[ScoutVehicle] = 3;

$DamageScale[Scout, $ImpactDamageType] = 1.0;
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
$DamageScale[Scout, $ShotgunDamageType] = 1.0;

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
  description = "Scout";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
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
  projectileType = FlierRocket;
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

function Scout::onPilot(%this, %player)
{
  //
}

function Scout::onUnPilot(%this, %player)
{
  //
}

//---------------------
//	WRAITH
//---------------------

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
$DamageScale[Wraith, $ShotgunDamageType] = 1.0;

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

//---------------------
//	INTERCEPTOR
//---------------------

$VehicleInvList[InterceptorVehicle] = 1;
$DataBlockName[InterceptorVehicle] = Interceptor;
$VehicleToItem[Interceptor] = InterceptorVehicle;
$VehicleSlots[Interceptor] = 0;

$TeamItemMax[InterceptorVehicle] = 5;

$DamageScale[Interceptor, $ImpactDamageType] = 1.0;
$DamageScale[Interceptor, $BulletDamageType] = 1.0;
$DamageScale[Interceptor, $PlasmaDamageType] = 1.0;
$DamageScale[Interceptor, $EnergyDamageType] = 1.0;
$DamageScale[Interceptor, $ExplosionDamageType] = 1.0;
$DamageScale[Interceptor, $ShrapnelDamageType] = 1.0;
$DamageScale[Interceptor, $DebrisDamageType] = 1.0;
$DamageScale[Interceptor, $MissileDamageType] = 1.0;
$DamageScale[Interceptor, $LaserDamageType] = 1.0;
$DamageScale[Interceptor, $MortarDamageType] = 1.0;
$DamageScale[Interceptor, $BlasterDamageType] = 0.5;
$DamageScale[Interceptor, $ElectricityDamageType] = 1.0;
$DamageScale[Interceptor, $MineDamageType] = 1.0;
$DamageScale[Interceptor, $SniperDamageType] = 1.0;
$DamageScale[Interceptor, $ShotgunDamageType] = 1.0;

function vehicleInterceptor::Initialize()
{
  $TeamItemCount[0 @ InterceptorVehicle] = 0;
  $TeamItemCount[1 @ InterceptorVehicle] = 0;
  $TeamItemCount[2 @ InterceptorVehicle] = 0;
  $TeamItemCount[3 @ InterceptorVehicle] = 0;
  $TeamItemCount[4 @ InterceptorVehicle] = 0;
  $TeamItemCount[5 @ InterceptorVehicle] = 0;
  $TeamItemCount[6 @ InterceptorVehicle] = 0;
  $TeamItemCount[7 @ InterceptorVehicle] = 0;
}

ItemData InterceptorVehicle 
{
  description = "Interceptor";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 600;
};

BulletData VulcanIntBullet 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  expRandCycle = 3;
  mass = 0.05;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.20;
  damageType = $ShotgunDamageType;
  aimDeflection = 0.02;
  muzzleVelocity = 900.0;
  totalTime = 0.4;
  inheritedVelocityScale = 1.0;
  isVisible = False;
  tracerPercentage = 2.0;
  tracerLength = 60;
};

FlierData Interceptor 
{
  explosionId = flashExpLarge;
  debrisId = flashDebrisLarge;
  className = "Vehicle";
  shapeFile = "flyer";
  shieldShapeName = "shield_medium";
  mass = 9.0;
  drag = 1.0;
  density = 1.2;
  maxBank = 0.6;
  maxPitch = 0.6;
  maxSpeed = 80;
  minSpeed = -2;
  lift = 0.95;
  maxAlt = 25;
  maxVertical = 12;
  maxDamage = 0.6;
  damageLevel = {1.0, 1.0};
  maxEnergy = 100;
  accel = 0.8;
  groundDamageScale = 1.0;
  projectileType = VulcanIntBullet;
  reloadDelay = 0.02;
  repairRate = 0;
  fireSound = SoundFireMortar;
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

function Interceptor::onPilot(%this, %player)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "The Interceptor is fast and manuverable, it also has a large-spread Machine Gun.");
}

function Interceptor::onUnPilot(%this, %player)
{
  //
}

//---------------------
//	LAPC
//---------------------

$VehicleInvList[LAPCVehicle] = 1;
$DataBlockName[LAPCVehicle] = LAPC;
$VehicleToItem[LAPC] = LAPCVehicle;
$VehicleSlots[LAPC] = 2;

$TeamItemMax[LAPCVehicle] = 2;

$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 1.0;
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $EnergyDamageType] = 1.0;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 1.0;
$DamageScale[LAPC, $LaserDamageType] = 0.5;
$DamageScale[LAPC, $MortarDamageType] = 0.7;
$DamageScale[LAPC, $BlasterDamageType] = 0.5;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $MineDamageType] = 1.0;
$DamageScale[LAPC, $SniperDamageType] = 1.0;
$DamageScale[LAPC, $ShotgunDamageType] = 1.0;

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
  description = "BomberLPC";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 675;
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
  maxBank = 0.25;
  maxPitch = 0.175;
  maxSpeed = 25;
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
  projectileType = MortarShell;
  fireSound = SoundFireMortar;
  reloadDelay = 4.0;
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

//---------------------
//	HAPC
//---------------------

$VehicleInvList[HAPCVehicle] = 1;
$DataBlockName[HAPCVehicle] = HAPC;
$VehicleToItem[HAPC] = HAPCVehicle;
$VehicleSlots[HAPC] = 4;

$TeamItemMax[HAPCVehicle] = 2;

$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $BulletDamageType] = 1.0;
$DamageScale[HAPC, $PlasmaDamageType] = 1.0;
$DamageScale[HAPC, $EnergyDamageType] = 1.0;
$DamageScale[HAPC, $ExplosionDamageType] = 1.0;
$DamageScale[HAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[HAPC, $DebrisDamageType] = 1.0;
$DamageScale[HAPC, $MissileDamageType] = 1.0;
$DamageScale[HAPC, $LaserDamageType] = 0.5;
$DamageScale[HAPC, $MortarDamageType] = 1.0;
$DamageScale[HAPC, $BlasterDamageType] = 0.5;
$DamageScale[HAPC, $ElectricityDamageType] = 1.0;
$DamageScale[HAPC, $MineDamageType] = 1.0;
$DamageScale[HAPC, $SniperDamageType] = 1.0;
$DamageScale[HAPC, $ShotgunDamageType] = 1.0;

function vehicleHAPC::Initialize()
{
  $TeamItemCount[0 @ HAPCVehicle] = 0;
  $TeamItemCount[1 @ HAPCVehicle] = 0;
  $TeamItemCount[2 @ HAPCVehicle] = 0;
  $TeamItemCount[3 @ HAPCVehicle] = 0;
  $TeamItemCount[4 @ HAPCVehicle] = 0;
  $TeamItemCount[5 @ HAPCVehicle] = 0;
  $TeamItemCount[6 @ HAPCVehicle] = 0;
  $TeamItemCount[7 @ HAPCVehicle] = 0;
}

ItemData HAPCVehicle 
{
  description = "HAPC";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 875;
};

FlierData HAPC 
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
  maxPitch = 0.175;
  maxSpeed = 25;
  minSpeed = -1;
  lift = 0.35;
  maxAlt = 15;
  maxVertical = 6;
  maxDamage = 2.0;
  damageLevel = {1.0, 1.0};
  maxEnergy = 100;
  accel = 0.25;
  groundDamageScale = 0.125;
  repairRate = 0;
  ramDamage = 2;
  ramDamageType = -1;
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

function HAPC::onPilot(%this, %player)
{
  //
}

function HAPC::onUnPilot(%this, %player)
{
  //
}
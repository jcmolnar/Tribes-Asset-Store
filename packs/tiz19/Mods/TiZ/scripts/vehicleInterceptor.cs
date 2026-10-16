//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Vyper: modded form Interceptor(renegades)
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
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
  description = "Doom Rager";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 600;
};

BulletData VulcanIntBullet 
{
 bulletShapeName = "discb.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.8;
  damageType = $ShurikenDamageType;
  explosionRadius = 7.5;
  kickBackStrength = 150.0;
  muzzleVelocity = 685.0;
  terminalVelocity = 685.0;
  acceleration = 20.0;
  totalTime = 6.5;
  liveTime = 6.5;
  lightRange = 5.0;
  lightColor = { 0.4, 0.4, 1.0 };
  inheritedVelocityScale = 1.0;
  trailType = 1;
  trailLength = 15;
  trailWidth = 0.3;
  soundId = SoundDiscSpin;
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
  maxBank = 2.6;
   	maxPitch = 2.7;
   	maxSpeed = 65;
   	minSpeed = -20;
	lift = 1.00;
	maxAlt = 30;
	maxVertical = 20;
  maxDamage = 0.6;
  damageLevel = {1.0, 1.0};
  maxEnergy = 100;
  accel = 0.8;
  groundDamageScale = 1.0;
  projectileType = VulcanIntBullet;
  reloadDelay = 0.2;
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
  //
}

function Interceptor::onUnPilot(%this, %player)
{
  //
}
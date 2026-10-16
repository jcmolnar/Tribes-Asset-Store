//Apache
$VehicleInvList[SpeederVehicle] = 1;
$DataBlockName[SpeederVehicle] = Speeder;
$VehicleToItem[Speeder] = SpeederVehicle;
$VehicleSlots[Speeder] = 2;

$TeamItemMax[SpeederVehicle] = 2;

$DamageScale[Speeder, $ImpactDamageType] = 1.0;
$DamageScale[Speeder, $PsiDamageType] = 1.0;
$DamageScale[Speeder, $BulletDamageType] = 1.0;
$DamageScale[Speeder, $PlasmaDamageType] = 1.0;
$DamageScale[Speeder, $EnergyDamageType] = 1.0;
$DamageScale[Speeder, $ExplosionDamageType] = 1.0;
$DamageScale[Speeder, $ShrapnelDamageType] = 1.0;
$DamageScale[Speeder, $DebrisDamageType] = 1.0;
$DamageScale[Speeder, $MissileDamageType] = 0.4;
$DamageScale[Speeder, $LaserDamageType] = 1.0;
$DamageScale[Speeder, $MortarDamageType] = 1.0;
$DamageScale[Speeder, $BlasterDamageType] = 1.0;
$DamageScale[Speeder, $ElectricityDamageType] = 1.0;
$DamageScale[Speeder, $MineDamageType]        = 1.0;
$DamageScale[Speeder, $SniperDamageType]        = 1.0;
$DamageScale[Speeder, $MeltaDamageType] = 1.0;
$DamageScale[Speeder, $DeathDamageType] = 1.0;
$DamageScale[Speeder, $DDamageType] = 1.0;
$DamageScale[Speeder, $FlamerDamageType] = 1.0;
$DamageScale[Speeder, $ShellDamageType] = 1.0;
$DamageScale[Speeder, $ShurikenDamageType] = 1.0;
$DamageScale[Speeder, $ReaperDamageType] = 1.0;

function vehicleSpeeder::Initialize()
{
  $TeamItemCount[0 @ SpeederVehicle] = 0;
  $TeamItemCount[1 @ SpeederVehicle] = 0;
  $TeamItemCount[2 @ SpeederVehicle] = 0;
  $TeamItemCount[3 @ SpeederVehicle] = 0;
  $TeamItemCount[4 @ SpeederVehicle] = 0;
  $TeamItemCount[5 @ SpeederVehicle] = 0;
  $TeamItemCount[6 @ SpeederVehicle] = 0;
  $TeamItemCount[7 @ SpeederVehicle] = 0;
}

ItemData SpeederVehicle 
{
  description = "Apache";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 1200;
};

RocketData YamatoFire
{
   bulletShapeName = "tracer.dts";
   muzzleVelocity = 100.0;
   terminalVelocity = 100.0;
   acceleration = 1.0;
   damageClass = 0;
   damageValue = 0.2;
   explosionTag    = bulletexp0;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageType       = $BulletDamageType;
   explosionRadius  = 50.0;
   kickBackStrength = 300.0;
   totalTime        = 50.0;
   liveTime         = 50.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;
   trailType   = 2;                // smoke trail
   trailString = "smoke.dts";
   smokeDist   = 0;

};

FlierData Speeder
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   	shapeFile = "Apache";
   	shieldShapeName = "shield_large";
   	mass = 16.0;
   	drag = 1.0;
   	density = 1.2;
   	maxBank = 9.4;
   	maxPitch = 9.3;
  	maxSpeed = 27;
  	minSpeed = -15;
	lift = 0.6;
	maxAlt = 25;
	maxVertical = 40;
	maxDamage = 2.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.50;

	projectileType = YamatoFire;
	reloadDelay = 0.1;
	repairRate = 0;
	fireSound =   SoundFireDisc;
	damageSound = SoundFlierCrash;

	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 23;
};

function Speeder::onPilot(%this, %player)
{
  //
}

function Speeder::onUnPilot(%this, %player)
{
  //
}
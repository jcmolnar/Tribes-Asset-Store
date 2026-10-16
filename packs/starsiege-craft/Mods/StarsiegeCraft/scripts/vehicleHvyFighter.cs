//valkyrie, terran
$VehicleInvList[QuickLPCVehicle] = 1;
$DataBlockName[QuickLPCVehicle] = QuickLPC;
$VehicleToItem[QuickLPC] = QuickLPCVehicle;
$VehicleSlots[QuickLPC] = 2;

$TeamItemMax[QuickLPCVehicle] = 2;

$DamageScale[QuickLPC, $ImpactDamageType] = 1.0;
$DamageScale[QuickLPC, $BulletDamageType] = 1.0;
$DamageScale[QuickLPC, $PsiDamageType] = 1.0;
$DamageScale[QuickLPC, $PlasmaDamageType] = 1.0;
$DamageScale[QuickLPC, $EnergyDamageType] = 1.0;
$DamageScale[QuickLPC, $ExplosionDamageType] = 1.0;
$DamageScale[QuickLPC, $ShrapnelDamageType] = 1.0;
$DamageScale[QuickLPC, $DebrisDamageType] = 1.0;
$DamageScale[QuickLPC, $MissileDamageType] = 0.4;
$DamageScale[QuickLPC, $LaserDamageType] = 1.0;
$DamageScale[QuickLPC, $MortarDamageType] = 1.0;
$DamageScale[QuickLPC, $BlasterDamageType] = 1.0;
$DamageScale[QuickLPC, $ElectricityDamageType] = 1.0;
$DamageScale[QuickLPC, $MineDamageType]        = 1.0;
$DamageScale[QuickLPC, $SniperDamageType]        = 1.0;
$DamageScale[QuickLPC, $DeathDamageType] = 1.0;
$DamageScale[QuickLPC, $DDamageType] = 1.0;
$DamageScale[QuickLPC, $FlamerDamageType] = 1.0;
$DamageScale[QuickLPC, $ShellDamageType] = 1.0;
$DamageScale[QuickLPC, $ShurikenDamageType] = 1.0;
$DamageScale[QuickLPC, $ReaperDamageType] = 1.0;

function vehicleQuickLPC::Initialize()
{
  $TeamItemCount[0 @ QuickLPCVehicle] = 0;
  $TeamItemCount[1 @ QuickLPCVehicle] = 0;
  $TeamItemCount[2 @ QuickLPCVehicle] = 0;
  $TeamItemCount[3 @ QuickLPCVehicle] = 0;
  $TeamItemCount[4 @ QuickLPCVehicle] = 0;
  $TeamItemCount[5 @ QuickLPCVehicle] = 0;
  $TeamItemCount[6 @ QuickLPCVehicle] = 0;
  $TeamItemCount[7 @ QuickLPCVehicle] = 0;
}

ItemData QuickLPCVehicle 
{
  description = "Valkyrie-Terran";
  className = "Vehicle";
  heading = $InvHead[ihTsh];
  price = 875;
};

RocketData TurretMissileValk
{
   bulletShapeName = "Shield_Large.dts";
   explosionTag    = RocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $MissileDamageType;
   explosionRadius  = 30.0;
   kickBackStrength = 50.0;
   muzzleVelocity    = 85.0;
   terminalVelocity  = 85.0;
   totalTime         = 1.5;
   liveTime          = 1.5;
//   proximityDist     = 1.5;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 1.0;
   trailType = 2;
   trailString = "breath.dts";
   smokeDist = 0.4;
};

FlierData QuickLPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   	shapeFile = "hover_apc_sml";
   	shieldShapeName = "shield_large";
   	mass = 16.0;
   	drag = 1.0;
   	density = 1.2;
   	maxBank = 1.0;
   	maxPitch = 0.5;
  	maxSpeed = 35;
  	minSpeed = -5;
	lift = 1.0;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 1;
        range = 350;
	groundDamageScale = 0.50;

	projectileType = TurretMissileValk;
	reloadDelay = 0.5;
	repairRate = 0;
	fireSound = SoundFireBlaster;
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

	visibleDriver = true;
	driverPose = 23;
};

function QuickLPC::onPilot(%this, %player)
{
  //
}

function QuickLPC::onUnPilot(%this, %player)
{
  //
}
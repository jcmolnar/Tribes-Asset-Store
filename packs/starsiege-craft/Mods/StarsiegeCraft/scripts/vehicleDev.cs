//Devourer, Zerg
$VehicleInvList[DevVehicle] = 1;
$DataBlockName[DevVehicle] = Dev;
$VehicleToItem[Dev] = DevVehicle;
$VehicleSlots[Dev] = 0;

$TeamItemMax[DevVehicle] = 1;

$DamageScale[Dev, $ImpactDamageType] = 1.0;
$DamageScale[Dev, $PsiDamageType] = 1.0;
$DamageScale[Dev, $BulletDamageType] = 1.0;
$DamageScale[Dev, $PlasmaDamageType] = 1.0;
$DamageScale[Dev, $EnergyDamageType] = 1.0;
$DamageScale[Dev, $ExplosionDamageType] = 1.0;
$DamageScale[Dev, $ShrapnelDamageType] = 1.0;
$DamageScale[Dev, $DebrisDamageType] = 1.0;
$DamageScale[Dev, $MissileDamageType] = 1.0;
$DamageScale[Dev, $LaserDamageType] = 1.0;
$DamageScale[Dev, $MortarDamageType] = 1.0;
$DamageScale[Dev, $BlasterDamageType] = 1.0;
$DamageScale[Dev, $ElectricityDamageType] = 1.0;
$DamageScale[Dev, $MineDamageType]        = 1.0;
$DamageScale[Dev, $SniperDamageType] = 1.0;
$DamageScale[Dev, $DDamageType] = 10.0;
$DamageScale[Dev, $DeathDamageType] = 1.0;
$DamageScale[Dev, $DDamageType] = 10.0;
$DamageScale[Dev, $FlamerDamageType] = 1.0;
$DamageScale[Dev, $ShellDamageType] = 1.0;
$DamageScale[Dev, $ShurikenDamageType] = 1.0;
$DamageScale[Dev, $ReaperDamageType] = 1.0;

RocketData DevShot
{
   bulletShapeName  = "bullet.dts";
   explosionTag     = Shockwave;
   collisionRadius  = 0.0;
   mass             = 0.2;

   damageClass      = 1;
   damageValue      = 1.4;
   damageType       = $EnergyDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 50.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 4.0;
   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.2;

   trailType   = 2;
   trailString = "mortartrail.dts";
   smokeDist   = 0.4;
   rotationPeriod = 1;
};

function vehicleDev::Initialize()
{
  $TeamItemCount[0 @ DevVehicle] = 0;
  $TeamItemCount[1 @ DevVehicle] = 0;
  $TeamItemCount[2 @ DevVehicle] = 0;
  $TeamItemCount[3 @ DevVehicle] = 0;
  $TeamItemCount[4 @ DevVehicle] = 0;
  $TeamItemCount[5 @ DevVehicle] = 0;
  $TeamItemCount[6 @ DevVehicle] = 0;
  $TeamItemCount[7 @ DevVehicle] = 0;
}

ItemData DevVehicle 
{
  description = "Devourer-Zerg";
  className = "Vehicle";
  heading = $InvHead[ihZsh];
  price = 1000;
};

FlierData Dev
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
   	maxSpeed = 35;
   	minSpeed = -20;
	lift = 1.00;
	maxAlt = 30;
	maxVertical = 20;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 2.0;
        range = 100;
        supression = true;
        castLOS = true;
	groundDamageScale = 0.1;
	projectileType = DevShot;
	reloadDelay = 4.5;
	repairRate = 0;
	fireSound = SoundMortarTurretFire;
	damageSound = SoundFlierCrash;
	ramDamage = 2.0;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = ForceFieldOpen;
	dismountSound = ForceFieldClose;
	idleSound = FlyerZerg;
	moveSound = SoundWindAmbient2;

	visibleDriver = false;
	driverPose = 22;
};

function Dev::onPilot(%this, %player)
{
}

function Dev::onUnPilot(%this, %player)
{
}
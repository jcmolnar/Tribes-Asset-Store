//Corsair
$VehicleInvList[DogFighterVehicle] = 1;
$DataBlockName[DogFighterVehicle] = DogFighter;
$VehicleToItem[DogFighter] = DogFighterVehicle;
$VehicleSlots[DogFighter] = 0;

$TeamItemMax[DogFighterVehicle] = 2;

$DamageScale[DogFighter, $ImpactDamageType] = 1.0;
$DamageScale[DogFighter, $PsiDamageType] = 1.0;
$DamageScale[DogFighter, $BulletDamageType] = 1.0;
$DamageScale[DogFighter, $PlasmaDamageType] = 1.0;
$DamageScale[DogFighter, $EnergyDamageType] = 1.0;
$DamageScale[DogFighter, $ExplosionDamageType] = 1.0;
$DamageScale[DogFighter, $ShrapnelDamageType] = 1.0;
$DamageScale[DogFighter, $DebrisDamageType] = 1.0;
$DamageScale[DogFighter, $MissileDamageType] = 1.0;
$DamageScale[DogFighter, $LaserDamageType] = 1.0;
$DamageScale[DogFighter, $MortarDamageType] = 1.0;
$DamageScale[DogFighter, $BlasterDamageType] = 1.0;
$DamageScale[DogFighter, $ElectricityDamageType] = 1.0;
$DamageScale[DogFighter, $MineDamageType]        = 1.0;
$DamageScale[DogFighter, $SniperDamageType] = 1.0;
$DamageScale[DogFighter, $DeathDamageType] = 1.0;
$DamageScale[DogFighter, $DDamageType] = 1.0;
$DamageScale[DogFighter, $FlamerDamageType] = 1.0;
$DamageScale[DogFighter, $ShellDamageType] = 1.0;
$DamageScale[DogFighter, $ShurikenDamageType] = 1.0;
$DamageScale[DogFighter, $ReaperDamageType] = 1.0;

RocketData ArbitBolt
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = TurretExp;
   collisionRadius  = 0;
   mass             = 2.0;

   damageClass      = 1;
   damageValue      = 0.9;
   damageType       = $DeathDamageType;

   explosionRadius  = 12.0;
   kickBackStrength = 300;
   muzzleVelocity   = 200.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 6.0;
   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "hflame.dts";
   smokeDist   = 1.4;
};

function vehicleDogFighter::Initialize()
{
  $TeamItemCount[0 @ DogFighterVehicle] = 0;
  $TeamItemCount[1 @ DogFighterVehicle] = 0;
  $TeamItemCount[2 @ DogFighterVehicle] = 0;
  $TeamItemCount[3 @ DogFighterVehicle] = 0;
  $TeamItemCount[4 @ DogFighterVehicle] = 0;
  $TeamItemCount[5 @ DogFighterVehicle] = 0;
  $TeamItemCount[6 @ DogFighterVehicle] = 0;
  $TeamItemCount[7 @ DogFighterVehicle] = 0;
}

ItemData DogFighterVehicle 
{
  description = "Corsair-Protoss";
  className = "Vehicle";
  heading = $InvHead[ihPsh];
  price = 600;
};

FlierData DogFighter
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
	maxDamage = 0.2;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 1.0;
        range = 100;
        supression = true;
        castLOS = true;
	groundDamageScale = 1.0;
	projectileType = ArbitBolt;
	reloadDelay = 1.0;
	repairRate = 0;
	fireSound = SoundFireLaser;
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

	visibleDriver = false;
	driverPose = 22;
};

function DogFighter::onPilot(%this, %player)
{
//  GameBase::startFadeout(%this);
}

function DogFighter::onUnPilot(%this, %player)
{
//  GameBase::startFadein(%this);
}
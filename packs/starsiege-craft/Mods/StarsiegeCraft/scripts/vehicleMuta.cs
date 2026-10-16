//Mutalisk, Zerg
$VehicleInvList[MutaVehicle] = 1;
$DataBlockName[MutaVehicle] = Muta;
$VehicleToItem[Muta] = MutaVehicle;
$VehicleSlots[Muta] = 0;

$TeamItemMax[MutaVehicle] = 2;

$DamageScale[Muta, $ImpactDamageType] = 1.0;
$DamageScale[Muta, $PsiDamageType] = 1.0;
$DamageScale[Muta, $BulletDamageType] = 1.0;
$DamageScale[Muta, $PlasmaDamageType] = 1.0;
$DamageScale[Muta, $EnergyDamageType] = 1.0;
$DamageScale[Muta, $ExplosionDamageType] = 1.0;
$DamageScale[Muta, $ShrapnelDamageType] = 1.0;
$DamageScale[Muta, $DebrisDamageType] = 1.0;
$DamageScale[Muta, $MissileDamageType] = 1.0;
$DamageScale[Muta, $LaserDamageType] = 1.0;
$DamageScale[Muta, $MortarDamageType] = 1.0;
$DamageScale[Muta, $BlasterDamageType] = 1.0;
$DamageScale[Muta, $ElectricityDamageType] = 1.0;
$DamageScale[Muta, $MineDamageType]        = 1.0;
$DamageScale[Muta, $SniperDamageType] = 1.0;
$DamageScale[Muta, $DDamageType] = 10.0;
$DamageScale[Muta, $DeathDamageType] = 1.0;
$DamageScale[Muta, $DDamageType] = 1.0;
$DamageScale[Muta, $FlamerDamageType] = 1.0;
$DamageScale[Muta, $ShellDamageType] = 1.0;
$DamageScale[Muta, $ShurikenDamageType] = 1.0;
$DamageScale[Muta, $ReaperDamageType] = 1.0;

RocketData MutaShot
{
   bulletShapeName  = "fusionex.dts";
   explosionTag     = Shockwave;
   collisionRadius  = 0.0;
   mass             = 0.2;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.25;
   damageType       = $PsiDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = -150.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 4.0;
   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "paint.dts";
   smokeDist   = 5;

//   soundId = MineExplosion;
};

function vehicleMuta::Initialize()
{
  $TeamItemCount[0 @ MutaVehicle] = 0;
  $TeamItemCount[1 @ MutaVehicle] = 0;
  $TeamItemCount[2 @ MutaVehicle] = 0;
  $TeamItemCount[3 @ MutaVehicle] = 0;
  $TeamItemCount[4 @ MutaVehicle] = 0;
  $TeamItemCount[5 @ MutaVehicle] = 0;
  $TeamItemCount[6 @ MutaVehicle] = 0;
  $TeamItemCount[7 @ MutaVehicle] = 0;
}

ItemData MutaVehicle 
{
  description = "Mutalisk-Zerg";
  className = "Vehicle";
  heading = $InvHead[ihZsh];
  price = 700;
};

FlierData Muta
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
   	maxSpeed = 40;
   	minSpeed = -20;
	lift = 1.00;
	maxAlt = 30;
	maxVertical = 20;
	maxDamage = 0.3;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 2.0;
        range = 100;
        supression = true;
        castLOS = true;
	groundDamageScale = 0.1;
	projectileType = MutaShot;
	reloadDelay = 0.35;
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

function Muta::onPilot(%this, %player)
{
}

function Muta::onUnPilot(%this, %player)
{
}
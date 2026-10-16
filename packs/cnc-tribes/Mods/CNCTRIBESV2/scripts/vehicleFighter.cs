//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Attack Jet: Modded from BOP Dogfighter
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$VehicleInvList[DogFighterVehicle] = 1;
$DataBlockName[DogFighterVehicle] = DogFighter;
$VehicleToItem[DogFighter] = DogFighterVehicle;
$VehicleSlots[DogFighter] = 0;

$TeamItemMax[DogFighterVehicle] = 2;

$DamageScale[DogFighter, $ImpactDamageType] = 1.0;
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
$DamageScale[DogFighter, $PsiDamageType] = 1.0;
$DamageScale[DogFighter, $ChemDamageType] = 1.0;
$DamageScale[DogFighter, $KrakenDamageType] = 1.0;
$DamageScale[DogFighter, $MeltaDamageType] = 1.0;
$DamageScale[DogFighter, $DeathDamageType] = 1.0;
$DamageScale[DogFighter, $DDamageType] = 1.0;
$DamageScale[DogFighter, $FlamerDamageType] = 1.0;
$DamageScale[DogFighter, $ShellDamageType] = 1.0;
$DamageScale[DogFighter, $ShurikenDamageType] = 1.0;
$DamageScale[DogFighter, $ReaperDamageType] = 1.0;

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

BulletData FusionZap
{
  bulletShapeName = "fusionbolt.dts";
  explosionTag = turretExp;
  mass = 0.05;
  damageClass = 0;
  damageValue = 0.35;
  damageType = $DeathDamageType;
  muzzleVelocity = 150.0;
  totalTime = 3.0;
  liveTime = 3.0;
  isVisible = True;
  rotationPeriod = 1.5;
};

ItemData DogFighterVehicle 
{
  description = "Vyper Var.3";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 30;
};
FlierData DogFighter
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   	shapeFile = "vyper";
   	shieldShapeName = "shield_medium";
   	mass = 9.0;
   	drag = 1.0;
   	density = 1.2;
   	maxBank = 0.6;
   maxPitch = 0.6;
   maxSpeed = 80;
   minSpeed = -3;
	lift = 0.95;
	maxAlt = 155;
	maxVertical = 12;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.8;

	groundDamageScale = 1.0;

	projectileType = FusionZap;
	reloadDelay = 0.5;
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

	visibleDriver = true;
	driverPose = 22;
};

function DogFighter::onPilot(%this, %player)
{
  //
}

function DogFighter::onUnPilot(%this, %player)
{
  //
}
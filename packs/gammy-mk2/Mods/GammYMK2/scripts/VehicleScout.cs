//--------------------------------------

$VehicleInvList[ScoutVehicle] = 1;

$DataBlockName[ScoutVehicle] = Scout;
$VehicleToItem[Scout] = ScoutVehicle;

//--------------------------------------

$TeamItemMax[ScoutVehicle] = 3;

//--------------------------------------

RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.3;
   damageType       = $MissileDamageType;

   explosionRadius  = 4.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------

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
   maxSpeed = 50;
   minSpeed = -2;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 10.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = ChainGunBullet;
	reloadDelay = 0;
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
	description = "Star Shooter";
};

//--------------------------------------

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
$DamageScale[Scout, $MineDamageType]        = 1.0;
$DamageScale[Scout, $ShockDamageType] = 0.8;
$DamageScale[Scout, $AlienDamageType] = 1.8;
//--------------------------------------

$VehicleInvList[ScoutVehicle2] = 1;

$DataBlockName[ScoutVehicle2] = Scout2;
$VehicleToItem[Scout2] = ScoutVehicle2;

//--------------------------------------

$TeamItemMax[ScoutVehicle2] = 3;

//--------------------------------------

RocketData HaCkRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 10.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 8.0;
   liveTime         = 9.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------

FlierData Scout2
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
   maxSpeed = 80;
   minSpeed = -2;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 1.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.9;

	groundDamageScale = 1.0;

	projectileType = HaCkRocket;
	reloadDelay = 0.0;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 2.5;
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
	description = "Raider";
};

//--------------------------------------

$DamageScale[Scout2, $ImpactDamageType] = 1.0;
$DamageScale[Scout2, $BulletDamageType] = 1.0;
$DamageScale[Scout2, $PlasmaDamageType] = 1.0;
$DamageScale[Scout2, $EnergyDamageType] = 1.0;
$DamageScale[Scout2, $ExplosionDamageType] = 1.0;
$DamageScale[Scout2, $ShrapnelDamageType] = 1.0;
$DamageScale[Scout2, $DebrisDamageType] = 1.0;
$DamageScale[Scout2, $MissileDamageType] = 1.0;
$DamageScale[Scout2, $LaserDamageType] = 1.0;
$DamageScale[Scout2, $MortarDamageType] = 1.0;
$DamageScale[Scout2, $BlasterDamageType] = 0.5;
$DamageScale[Scout2, $ElectricityDamageType] = 1.0;
$DamageScale[Scout2, $MineDamageType]        = 1.0;
$DamageScale[Scout2, $ShockDamageType] = 0.8;
$DamageScale[Scout2, $AlienDamageType] = 1.8;
//--------------------------------------

$VehicleInvList[ScoutVehicle3] = 1;

$DataBlockName[ScoutVehicle3] = Scout3;
$VehicleToItem[Scout3] = ScoutVehicle3;

//--------------------------------------

$TeamItemMax[ScoutVehicle3] = 3;

//--------------------------------------

RocketData Cloud
{
   bulletShapeName  = "Tumult_Large.dts";
   explosionTag     = SCloudExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.01;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 50.0;
   muzzleVelocity   = 95.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Tumult_Medium.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------

FlierData Scout3
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "Flyer";
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
	maxDamage = 10.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = Cloud;
	reloadDelay = 0.1;
	repairRate = 0.5;
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

	visibleDriver = True;
	driverPose = 22;
	description = "Fog Maker";
};

//--------------------------------------

$DamageScale[Scout3, $ImpactDamageType] = 1.0;
$DamageScale[Scout3, $BulletDamageType] = 1.0;
$DamageScale[Scout3, $PlasmaDamageType] = 1.0;
$DamageScale[Scout3, $EnergyDamageType] = 1.0;
$DamageScale[Scout3, $ExplosionDamageType] = 1.0;
$DamageScale[Scout3, $ShrapnelDamageType] = 1.0;
$DamageScale[Scout3, $DebrisDamageType] = 1.0;
$DamageScale[Scout3, $MissileDamageType] = 1.0;
$DamageScale[Scout3, $LaserDamageType] = 1.0;
$DamageScale[Scout3, $MortarDamageType] = 1.0;
$DamageScale[Scout3, $BlasterDamageType] = 0.5;
$DamageScale[Scout3, $ElectricityDamageType] = 1.0;
$DamageScale[Scout3, $MineDamageType]        = 1.0;
$DamageScale[Scout3, $ShockDamageType] = 0.8;
$DamageScale[Scout3, $AlienDamageType] = 1.8;
//--------------------------------------

$VehicleInvList[ScoutVehicle4] = 1;

$DataBlockName[ScoutVehicle4] = Scout4;
$VehicleToItem[Scout4] = ScoutVehicle4;

//--------------------------------------

RocketData BursterBlast
{
   bulletShapeName = "Fusionex.dts";
   explosionTag    = FlameBurstExp;
   expRandCycle       = 0;
   collisionRadius = 0.0;
   mass            = 2.0;
   bulletHoleIndex    = 0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.83;
   damageType       = $ElectricityDamageType;
   explosionRadius  = 4.0;
   kickBackStrength = 55.0;

   muzzleVelocity    = 110.0;
   terminalVelocity = 120.0;
   acceleration     = 5.0;
   aimDeflection      = 0.01;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "FusionEx.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};


$TeamItemMax[ScoutVehicle4] = 3;

//--------------------------------------

FlierData Scout4
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "Flyer";
   shieldShapeName = "shield_medium";
    mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 40;
   minSpeed = -2;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = ChaingunBullet2;
	reloadDelay = 0.03;
	repairRate = 1.5;
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

	visibleDriver = True;
	driverPose = 22;
	description = "Energy Burster";
};

//--------------------------------------

$DamageScale[Scout4, $ImpactDamageType] = 1.0;
$DamageScale[Scout4, $BulletDamageType] = 1.0;
$DamageScale[Scout4, $PlasmaDamageType] = 1.0;
$DamageScale[Scout4, $EnergyDamageType] = 1.0;
$DamageScale[Scout4, $ExplosionDamageType] = 1.0;
$DamageScale[Scout4, $ShrapnelDamageType] = 1.0;
$DamageScale[Scout4, $DebrisDamageType] = 1.0;
$DamageScale[Scout4, $MissileDamageType] = 1.0;
$DamageScale[Scout4, $LaserDamageType] = 1.0;
$DamageScale[Scout4, $MortarDamageType] = 1.0;
$DamageScale[Scout4, $BlasterDamageType] = 0.5;
$DamageScale[Scout4, $ElectricityDamageType] = 1.0;
$DamageScale[Scout4, $MineDamageType]        = 1.0;
$DamageScale[Scout4, $ShockDamageType] = 0.8;
$DamageScale[Scout4, $AlienDamageType] = 1.8;
//--------------------------------------
//--------------------------------------

$VehicleInvList[ScoutVehicle5] = 1;

$DataBlockName[ScoutVehicle5] = Scout5;
$VehicleToItem[Scout5] = ScoutVehicle5;

//--------------------------------------

$TeamItemMax[ScoutVehicle5] = 3;

//--------------------------------------

RocketData FlierRocketS
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = CloudExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 10;
   damageType       = $MissileDamageType;

   explosionRadius  = 30.5;
   kickBackStrength = 1.0;
   muzzleVelocity   = 10.0;
   terminalVelocity = 10.0;
   acceleration     = 5.0;
   totalTime        = 0.1;
   liveTime         = 0.1;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Tumult_Large.dts";
   smokeDist   = 11.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------

FlierData Scout5
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
   maxSpeed = 200;
   minSpeed = -2;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 3.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 10.0;

	projectileType = FlierRocketS;
	reloadDelay = 0;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 100.5;
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
	description = "Kamakazie Scout";
};

//--------------------------------------

$DamageScale[Scout5, $ImpactDamageType] = 10.0;
$DamageScale[Scout5, $BulletDamageType] = 10.0;
$DamageScale[Scout5, $PlasmaDamageType] = 10.0;
$DamageScale[Scout5, $EnergyDamageType] = 10.0;
$DamageScale[Scout5, $ExplosionDamageType] = 10.0;
$DamageScale[Scout5, $ShrapnelDamageType] = 10.0;
$DamageScale[Scout5, $DebrisDamageType] = 10.0;
$DamageScale[Scout5, $MissileDamageType] = 10.0;
$DamageScale[Scout5, $LaserDamageType] = 10.0;
$DamageScale[Scout5, $MortarDamageType] = 10.0;
$DamageScale[Scout5, $BlasterDamageType] = 10.5;
$DamageScale[Scout5, $ElectricityDamageType] = 10.0;
$DamageScale[Scout5, $MineDamageType] = 10.0;
$DamageScale[Scout5, $ShockDamageType] = 10.8;
$DamageScale[Scout5, $AlienDamageType] = 10.8;
//--------------------------------------

//--------------------------------------
//--------------------------------------

$VehicleInvList[ScoutVehicle6] = 1;

$DataBlockName[ScoutVehicle6] = Scout6;
$VehicleToItem[Scout6] = ScoutVehicle6;

//--------------------------------------

$TeamItemMax[ScoutVehicle6] = 3;

//--------------------------------------

RocketData FlierRocketB
{
   bulletShapeName  = "Bullet.dts";
   explosionTag     = CloudExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 3.5;
   kickBackStrength = 1.0;
   muzzleVelocity   = 50.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 10.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "paint.dts";
   smokeDist   = 11.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------

FlierData Scout6
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 9.5;
   maxPitch = 9.5;
   maxSpeed = 50;
   minSpeed = -2;
	lift = 1.75;
	maxAlt = 50;
	maxVertical = 60;
	maxDamage = 3.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 300;
	accel = 1.4;

	groundDamageScale = 0;

	projectileType = FlierRocketb;
	reloadDelay = 0.05;
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
	description = "Dragoon Scout";
};

//--------------------------------------

$DamageScale[Scout6, $ImpactDamageType] = 10.0;
$DamageScale[Scout6, $BulletDamageType] = 1.0;
$DamageScale[Scout6, $PlasmaDamageType] = 1.0;
$DamageScale[Scout6, $EnergyDamageType] = 3.0;
$DamageScale[Scout6, $ExplosionDamageType] = 1.0;
$DamageScale[Scout6, $ShrapnelDamageType] = 1.0;
$DamageScale[Scout6, $DebrisDamageType] = 1.0;
$DamageScale[Scout6, $MissileDamageType] = 1.0;
$DamageScale[Scout6, $LaserDamageType] = 1.0;
$DamageScale[Scout6, $MortarDamageType] = 10.0;
$DamageScale[Scout6, $BlasterDamageType] = 1.5;
$DamageScale[Scout6, $ElectricityDamageType] = 1.0;
$DamageScale[Scout6, $MineDamageType] = 1.0;
$DamageScale[Scout6, $ShockDamageType] = 1.8;
$DamageScale[Scout6, $AlienDamageType] = 1.8;
//--------------------------------------
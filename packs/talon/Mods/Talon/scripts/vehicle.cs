//----------------------------------------------------------------------------
//

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
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = FlierRocket;
	reloadDelay = 2.0;
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
	description = "Scout";
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
	maxVertical = 6;
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
	description = "LPC";
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
	description = "HPC";
};


//----------------------------------------------------------------------------

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

$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 1.0;
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $EnergyDamageType] = 1.0;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 1.0;
$DamageScale[LAPC, $LaserDamageType] = 0.5;
$DamageScale[LAPC, $MortarDamageType] = 1.0;
$DamageScale[LAPC, $BlasterDamageType] = 0.5;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $MineDamageType]        = 1.0;

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
$DamageScale[HAPC, $MineDamageType]        = 1.0;


//----------------------------------------------------------------------------
//--------------------------------------------\
// Under here are my vehicles: -=TalonHawk=-  |>
//--------------------------------------------/
FlierData Stealth
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.3;
   maxPitch = 0.5;
   maxSpeed = 45;
   minSpeed = -2;
	lift = 0.95;
	maxAlt = 20;
	maxVertical = 10;
	maxDamage = 0.4;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.6;

	groundDamageScale = 4.0;

//	projectileType = FlierRocket;
//	reloadDelay = 0.6;
	repairRate = 10;
//	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 0.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = false;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 22;
	description = "Spirit";
};

$DamageScale[Stealth, $ImpactDamageType] = 0.2;
$DamageScale[Stealth, $BulletDamageType] = 1.0;
$DamageScale[Stealth, $PlasmaDamageType] = 1.0;
$DamageScale[Stealth, $EnergyDamageType] = 1.0;
$DamageScale[Stealth, $ExplosionDamageType] = 1.0;
$DamageScale[Stealth, $ShrapnelDamageType] = 1.0;
$DamageScale[Stealth, $DebrisDamageType] = 1.0;
$DamageScale[Stealth, $MissileDamageType] = 1.0;
$DamageScale[Stealth, $LaserDamageType] = 0.5;
$DamageScale[Stealth, $MortarDamageType] = 1.0;
$DamageScale[Stealth, $BlasterDamageType] = 0.5;
$DamageScale[Stealth, $ElectricityDamageType] = 1.0;
$DamageScale[Stealth, $MineDamageType]        = 1.0;

// Data for the Plamsa Bomber: -=TalonHawk=-
FlierData Bomber
{
	explosionId = LargeShockwave;
	debrisId = defaultDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 10.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.9;
   maxPitch = 1.0;
   maxSpeed = 20;
   minSpeed = -2;
	lift = 0.85;
	maxAlt = 50;
	maxVertical = 18;
	maxDamage = 3.1;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 1.0;

	groundDamageScale = 1.5;

	projectileType = FlierPlasma;
	reloadDelay = 0.2;
	repairRate = 10;
	fireSound = SoundFirePlasma;
	damageSound = SoundFlierCrash;
	ramDamage = 2.0;
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
	description = "Behemoth";
};

//  Damage Amounts for the Plasma Bomber
$DamageScale[Bomber, $ImpactDamageType] = 0.2;
$DamageScale[Bomber, $BulletDamageType] = 1.0;
$DamageScale[Bomber, $PlasmaDamageType] = 1.0;
$DamageScale[Bomber, $EnergyDamageType] = 1.0;
$DamageScale[Bomber, $ExplosionDamageType] = 1.0;
$DamageScale[Bomber, $ShrapnelDamageType] = 1.0;
$DamageScale[Bomber, $DebrisDamageType] = 1.0;
$DamageScale[Bomber, $MissileDamageType] = 1.0;
$DamageScale[Bomber, $LaserDamageType] = 0.5;
$DamageScale[Bomber, $MortarDamageType] = 1.0;
$DamageScale[Bomber, $BlasterDamageType] = 0.5;
$DamageScale[Bomber, $ElectricityDamageType] = 1.0;
$DamageScale[Bomber, $MineDamageType]        = 1.0;

//  Data for the Kamikaze Craft: -=TalonHawk=-
FlierData Kamikaze
{
	explosionId = LargeShockwave;
	debrisId = KamikazeDebris;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 3.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 1.0;
   maxPitch = 1.0;
   maxSpeed = 60;
   minSpeed = -1;
	lift = 1.00;
	maxAlt = 50;
	maxVertical = 80;
	maxDamage = 4.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 9.0;

	groundDamageScale = 90.0;
	repairRate = 0;
	fireSound = SoundJetLight;
	damageSound = SoundFlierCrash;
	ramDamage = 80.5;
	ramDamageType = $KamKillDamageType;
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
	description = "Kamikaze";
};

//  Damage Amounts for the Kamikaze
$DamageScale[Kamikaze, $ImpactDamageType] = 100.0;
$DamageScale[Kamikaze, $BulletDamageType] = 0.6;
$DamageScale[Kamikaze, $PlasmaDamageType] = 0.6;
$DamageScale[Kamikaze, $EnergyDamageType] = 0.6;
$DamageScale[Kamikaze, $ExplosionDamageType] = 1.0;
$DamageScale[Kamikaze, $ShrapnelDamageType] = 1.0;
$DamageScale[Kamikaze, $DebrisDamageType] = 1.0;
$DamageScale[Kamikaze, $MissileDamageType] = 0.2;
$DamageScale[Kamikaze, $LaserDamageType] = 0.3;
$DamageScale[Kamikaze, $MortarDamageType] = 1.0;
$DamageScale[Kamikaze, $BlasterDamageType] = 0.2;
$DamageScale[Kamikaze, $ElectricityDamageType] = 0.5;
$DamageScale[Kamikaze, $MineDamageType] = 0.9;

// Data for the Plamsa Bomber: -=TalonHawk=-
FlierData Interceptor
{
	explosionId = LargeShockwave;
	debrisId = defaultDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 10.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 1.2;
   maxPitch = 1.4;
   maxSpeed = 25;
   minSpeed = -3;
	lift = 0.85;
	maxAlt = 55;
	maxVertical = 20;
	maxDamage = 1.1;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.8;

	groundDamageScale = 3.0;

	projectileType = AAGun;
	reloadDelay = 0.1;
	repairRate = 10;
	fireSound = SoundTFireChaingun;
	damageSound = SoundFlierCrash;
	ramDamage = 3.5;
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
	description = "Zero";
};

//  Damage Amounts for the Interceptor
$DamageScale[Interceptor, $ImpactDamageType] = 0.4;
$DamageScale[Interceptor, $BulletDamageType] = 1.0;
$DamageScale[Interceptor, $PlasmaDamageType] = 1.0;
$DamageScale[Interceptor, $EnergyDamageType] = 1.0;
$DamageScale[Interceptor, $ExplosionDamageType] = 1.0;
$DamageScale[Interceptor, $ShrapnelDamageType] = 1.0;
$DamageScale[Interceptor, $DebrisDamageType] = 1.0;
$DamageScale[Interceptor, $MissileDamageType] = 1.0;
$DamageScale[Interceptor, $LaserDamageType] = 1.0;
$DamageScale[Interceptor, $MortarDamageType] = 1.0;
$DamageScale[Interceptor, $BlasterDamageType] = 1.0;
$DamageScale[Interceptor, $ElectricityDamageType] = 1.0;
$DamageScale[Interceptor, $MineDamageType]        = 1.0;

// My weapons vs. Aircraft data: -=TalonHawk=-
$DamageScale[Bomber, $FireDamageType]		= 1.0;
$DamageScale[HAPC, $FireDamageType]		= 1.0;
$DamageScale[LAPC, $FireDamageType]		= 1.0;
$DamageScale[Scout, $FireDamageType]		= 1.0;
$DamageScale[Kamikaze, $FireDamageType]		= 0.9;
$DamageScale[Interceptor, $FireDamageType]	= 1.0;
$DamageScale[Stealth, $FireDamageType]	= 1.0;

$DamageScale[Bomber, $APShellDamageType]	= 1.0;
$DamageScale[HAPC, $APShellDamageType]		= 1.0;
$DamageScale[LAPC, $APShellDamageType]		= 1.0;
$DamageScale[Scout, $APShellDamageType]		= 1.0;
$DamageScale[Kamikaze, $APShellDamageType]	= 0.4;
$DamageScale[Interceptor, $APShellDamageType]	= 1.0;
$DamageScale[Stealth, $APShellDamageType]	= 1.0;

$DamageScale[Bomber, $SniperDamageType]		= 1.4;
$DamageScale[HAPC, $SniperDamageType]		= 1.4;
$DamageScale[LAPC, $SniperDamageType]		= 1.4;
$DamageScale[Scout, $SniperDamageType]		= 1.4;
$DamageScale[Kamikaze, $SniperDamageType]	= 0.8;
$DamageScale[Interceptor, $SniperDamageType]	= 1.4;
$DamageScale[Stealth, $SniperDamageType]	= 1.4;

$DamageScale[Bomber, $NukeDamageType]		= 1.0;
$DamageScale[HAPC, $NukeDamageType]		= 1.0;
$DamageScale[LAPC, $NukeDamageType]		= 1.0;
$DamageScale[Scout, $NukeDamageType]		= 1.0;
$DamageScale[Kamikaze, $NukeDamageType]		= 1.0;
$DamageScale[Interceptor, $NukeDamageType]	= 1.0;
$DamageScale[Stealth, $NukeDamageType]	= 1.0;

$DamageScale[Bomber, $PMissileDamageType]	= 1.0;
$DamageScale[HAPC, $PMissileDamageType]		= 1.0;
$DamageScale[LAPC, $PMissileDamageType]		= 1.0;
$DamageScale[Scout, $PMissileDamageType]	= 1.0;
$DamageScale[Kamikaze, $PMissileDamageType]	= 1.0;
$DamageScale[Interceptor, $PMissileDamageType]	= 1.0;
$DamageScale[Stealth, $PMissileDamageType]	= 1.0;

$DamageScale[Bomber, $IonDamageType]		= 1.0;
$DamageScale[HAPC, $IonDamageType]		= 1.0;
$DamageScale[LAPC, $IonDamageType]		= 1.0;
$DamageScale[Scout, $IonDamageType]		= 1.0;
$DamageScale[Kamikaze, $IonDamageType]		= 0.9;
$DamageScale[Interceptor, $IonDamageType]	= 1.0;
$DamageScale[Stealth, $IonDamageType]	= 1.0;

$DamageScale[Bomber, $KamikazeDamageType]	= 1.0;
$DamageScale[HAPC, $KamikazeDamageType]		= 1.0;
$DamageScale[LAPC, $KamikazeDamageType]		= 1.0;
$DamageScale[Scout, $KamikazeDamageType]	= 1.0;
$DamageScale[Kamikaze, $KamikazeDamageType]	= 0.9;
$DamageScale[Interceptor, $KamikazeDamageType]	= 1.0;
$DamageScale[Stealth, $KamikazeDamageType]	= 1.0;

$DamageScale[Bomber, $ReasonDamageType]		= 3.0;
$DamageScale[HAPC, $ReasonDamageType]		= 3.0;
$DamageScale[LAPC, $ReasonDamageType]		= 3.0;
$DamageScale[Scout, $ReasonDamageType]		= 3.0;
$DamageScale[Kamikaze, $ReasonDamageType]	= 2.9;
$DamageScale[Interceptor, $ReasonDamageType]	= 3.0;
$DamageScale[Stealth, $ReasonDamageType]	= 3.0;

$DamageScale[Bomber, $EngunDamageType]		= 1.0;
$DamageScale[HAPC, $EngunDamageType]		= 1.0;
$DamageScale[LAPC, $EngunDamageType]		= 1.0;
$DamageScale[Scout, $EngunDamageType]		= 1.0;
$DamageScale[Kamikaze, $EngunDamageType]	= 0.9;
$DamageScale[Interceptor, $EngunDamageType]	= 1.0;
$DamageScale[Stealth, $EngunDamageType]		= 1.0;

$DamageScale[Bomber, $AADamageType]		= 4.0;
$DamageScale[HAPC, $AADamageType]		= 4.0;
$DamageScale[LAPC, $AADamageType]		= 4.0;
$DamageScale[Scout, $AADamageType]		= 4.0;
$DamageScale[Kamikaze, $AADamageType]		= 4.0;
$DamageScale[Interceptor, $AADamageType]	= 4.0;
$DamageScale[Stealth, $AADamageType]		= 4.0;

FlierData Cinni
{
	explosionId = flashExpSmall;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "logo";
   shieldShapeName = "shield_medium";
   mass = 0.5;
   drag = 0.08;
   density = 1.2;
   maxBank = 0.8;
   maxPitch = 0.9;
   maxSpeed = 21;
   minSpeed = 0;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 15;
	maxDamage = 0.06;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 9.4;

	groundDamageScale = 1.0;

	projectileType = GargyBolt;
	reloadDelay = 0.15;
	repairRate = 0;
	fireSound = SoundRemoteTurretFire;
	damageSound = SoundFlierCrash;
	ramDamage = 0.75;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
//	idleSound = SoundFlyerIdle;
	moveSound = SoundNMLIdle;

	visibleDriver = false;
	driverPose = 22;
	description = "Gargoyle MiniShip";
};

function Cinni::onAdd(%this)
{
	GameBase::setActive(%this,true);
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
}

FlierData Scouter
{
	explosionId = flashExpSmall;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "logo";
   shieldShapeName = "shield_medium";
   mass = 0.5;
   drag = 0.08;
   density = 1.2;
   maxBank = 0.8;
   maxPitch = 0.9;
   maxSpeed = 30;
   minSpeed = 0;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 15;
	maxDamage = 0.01;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 9.4;

	groundDamageScale = 1.0;

	repairRate = 0;
	fireSound = SoundRemoteTurretFire;
	damageSound = SoundFlierCrash;
	ramDamage = 0.45;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	moveSound = SoundNMLIdle;

	visibleDriver = false;
	driverPose = 22;
	description = "Scouter MiniPlane";
};

function Scouter::onAdd(%this)
{
	GameBase::setActive(%this,true);
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
}

FlierData GuidedRPG
{
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "rocket";
   shieldShapeName = "shield_medium";
   mass = 0.5;
   drag = 0.08;
   density = 1.2;
   maxBank = 20;
   maxPitch = 20;
   maxSpeed = 80;
   minSpeed = 70;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 50;
	maxDamage = 0.01;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 9.4;

	groundDamageScale = 1.0;

	repairRate = 0;
	fireSound = SoundRemoteTurretFire;
	damageSound = SoundFlierCrash;
	ramDamage = 0.85;
	ramDamageType = 17;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	moveSound = SoundJetHeavy;

	visibleDriver = false;
	driverPose = 22;
	description = "Guided RPG";
};

function GuidedRPG::onAdd(%this)
{
	GameBase::setActive(%this,true);
	%this.shieldStrength = 0.0;
	GameBase::setEnergy(%this,0);
	GameBase::setRechargeRate (%this, 0);
}

//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	%name = GameBase::getDataName(%this);
	GameBase::setMapName (%this, %name.description);
}

function Vehicle::onCollision (%this, %object)
{
	// cancel if it's a miniplane/fbw missile
	if(GameBase::getDataName(%this) == Cinni || GameBase::getDataName(%this) == GuidedRPG || GameBase::getDataName(%this) == Scouter)
		return;
	
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage)
	{
		if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
		{
	           	if( Player::isAiControlled(%object))
      	      	return;
              
			%armor = Player::getArmor(%object);
			%client = Player::getClient(%object);
			if (((%armor == "larmor" || %armor == "lfemale" || %armor == "sctarmor" || %armor == "sctfemale") || (GameBase::getDataName(%this) == HAPC || GameBase::getDataName(%this) == LAPC && (%armor == "marmor" || %armor == "mfemale" || %armor == "fgarmor" || %armor == "fgfemale"))) && Vehicle::canMount (%this, %object))
			{
				if(%client == %this.Owner || %this.Owner.VehicleShare == yes)
				{
					%weapon = Player::getMountedItem(%object,$WeaponSlot);
					if(%weapon != -1)
					{
						%object.lastWeapon = %weapon;
						Player::unMountItem(%object,$WeaponSlot);
					}
					Player::setMountObject(%object, %this, 1);
					Client::setControlObject(%client, %this);
					playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
					%object.driver= 1;
					%object.vehicle = %this;
					%this.clLastMount = %client;
					if(GameBase::getDataName(%this) == Stealth)
					{
						Client::sendMessage(Player::getClient(%object),4,"SPT-OBC: Activating cloacking field.");
						GameBase::startFadeOut(%this);
					}
				}
				else Client::sendMessage(Player::getClient(%object),1,"That's not your plane and the owner doesn't want you to have it.");
			}
			else if(GameBase::getDataName(%this) == HAPC || GameBase::getDataName(%this) == LAPC)
			{
			 	%mountSlot= Vehicle::findEmptySeat(%this,%client); 
				if(%mountSlot)
				{
					%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					Player::setMountObject(%object, %this, %mountSlot);
					playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				}
			}
			else if (GameBase::getControlClient(%this) == -1)
				Client::sendMessage(Player::getClient(%object),0,"You must be in Assassin or Scout armor to pilot vehicles.~wError_Message.wav");
		}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{
	if(GameBase::getDataName(%this) == HAPC)
		%numSlots = 4;
	else
		%numSlots = 2;
	%count=0;
	for(%i=0;%i<%numSlots;%i++)  
		if(%this.Seat[%i] == "")
		{
			%slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
			%slotVal[%count] = %i+2;
			%lastEmpty = %i+2;
			%count++;
		}
	if(%count == 1)
	{
		%this.Seat[%lastEmpty-2] = %client;
		return %lastEmpty;
	}
	else if (%count > 1)
	{
		%freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
		%this.Seat[%freeSlot-2] = %client;
		return %freeSlot;
	}
	else
		return "False";
}

function getClosestPosition(%num,%playerPos,%slotPos0,%slotPos1,%slotPos2,%slotPos3)
{
	%playerX = getWord(%playerPos,0);
	%playerY = getWord(%playerPos,1);
	for(%i = 0 ;%i<%num;%i++)
	{
		%x = (getWord(%slotPos[%i],0)) - %playerX;
		%y = (getWord(%slotPos[%i],1)) - %playerY;
		if(%x < 0)
			%x *= -1;
		if(%y < 0)
			%y *= -1;
		%newDistance = sqrt((%x*%x)+(%y*%y));
		if(%newDistance < %distance || %distance == "")
		{
	  		%distance = %newDistance;			
			%closePos = %i;	
		}
	}		
	return %closePos;
}

function Vehicle::passengerJump(%this,%passenger,%mom)
{
	%armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale")
	{
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale")
	{
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor")
	{
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}
	else
	{
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}
	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) {	
		%client = Player::getClient(%passenger);
		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
	   %passenger.vehicle= "";
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
	}
	else
		Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}

function Vehicle::jump(%this,%mom)
{
   Vehicle::dismount(%this,%mom);
}

function Vehicle::dismount(%this,%mom)
{
	if(GameBase::getDataName(%this) == Cinni || GameBase::getDataName(%this) == GuidedRPG)
		GameBase::applyDamage(%this,$DebrisDamageType,99,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);

	%cl = GameBase::getControlClient(%this);
	if(%cl != -1)
	{
		%pl = Client::getOwnedObject(%cl);
		if(getObjectType(%pl) == "Player")
		{
			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0)))
			{
				%pl.lastMount = %this;
				%pl.newMountTime = getSimTime() + 3.0;
				Player::setMountObject(%pl, %this, 0);
				Player::setMountObject(%pl, -1, 0);
				%rot = GameBase::getRotation(%this);
				%rotZ = getWord(%rot,2);
				GameBase::setRotation(%pl, "0 0 " @ %rotZ);
				Player::applyImpulse(%pl,%mom);
				Client::setControlObject(%cl, %pl);
				playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
				if(%pl.lastWeapon != "")
				{
					Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";
				}
				%pl.driver = "";
				%pl.vehicle = "";
				if(GameBase::getDataName(%this) == Stealth)
				{
					GameBase::startFadeIn(%this);
					Client::sendMessage(%cl,0,"SPT-OBC: De-Activating cloacking field.");
				}
			}
			else if(GameBase::getDataName(%this) != Cinni && GameBase::getDataName(%this) != GuidedRPG && GameBase::getDataName(%this) != GuidedNuke)
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
	}
}

function Vehicle::onDestroyed (%this,%mom)
{
	%name = GameBase::getDataName(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[%name]]--;
	%cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	if(%pl != -1)
	{
		Player::setMountObject(%pl, -1, 0);
		Client::setControlObject(%cl, %pl);
		if(%pl.lastWeapon != "")
		{
			Player::useItem(%pl,%pl.lastWeapon);		 	
			%pl.lastWeapon = "";
		}
		%pl.driver = "";
		%pl.vehicle= "";
	}
	for(%i = 0 ; %i < 4 ; %i++)
	if(%this.Seat[%i] != "")
	{
		%pl = Client::getOwnedObject(%this.Seat[%i]);
		Player::setMountObject(%pl, -1, 0);
		Client::setControlObject(%this.Seat[%i], %pl);
		%pl.vehicleSlot = "";
		%pl.vehicle= "";
	}
	if(%name == Kamikaze)
	{
		if(%pl != -1)
		{
			GameBase::applyDamage(%pl,$KamikazeDamageType,99,GameBase::getPosition(%player),"0 0 0","0 0 0",%this);
			calcOwnedRadiusDamage(%this,$ShrapnelDamageType,20,2,5,300,5,999,3,100,1,%cl);
			Client::setControlObject(%cl, Client::getObserverCamera(%cl));
			Observer::setOrbitObject(%cl, %this, 10, 10, 10);
			%pl.kamikazied = 1;
		}
		else
			calcRadiusDamage(%this,$DebrisDamageType,20.5,2,5,20,5,999,0.1,30,1);
		THNuke::Circle(GameBase::getPosition(%this),%client);
	}
	else if(%name == GuidedRPG)
	{
		if(%pl != -1)
		{
			%cl.rpgout = 0;
			Player::mountItem(%pl,RPG,$WeaponSlot);
			calcOwnedRadiusDamage(%this,$ShrapnelDamageType, 1.5, 1, 25, 40, 2, 1.5, 0.1, 500, 100, %cl);
			if(%pl.dead != 1)
			{
				Client::setControlObject(%cl, Client::getObserverCamera(%cl));
				Observer::setOrbitObject(%cl, %this, 10, 10, 10);
				schedule("Client::setControlObject("@%cl@","@%pl@");",5);
			}
		}
		else
			calcRadiusDamage(%this,$DebrisDamageType, 0.5, 1, 25, 80, 2, 0.5, 0.1, 500, 100);
	}
	else
		calcRadiusDamage(%this, $DebrisDamageType, 0.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100);
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if($damageScale[GameBase::getDataName(%this), %type])
		%scale = $damageScale[GameBase::getDataName(%this), %type];
	else
		%scale = 1.0;
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value * %scale;
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	GameBase::setDamageLevel(%this,%dValue);
}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}

FlierData GuidedNuke
{
	explosionId = StingerExp;
	debrisId = defaultDebrisSmall;
	className = "Vehicle";
   shapeFile = "rocket";
   shieldShapeName = "shield_medium";
   mass = 0.5;
   drag = 0.08;
   density = 1.2;
   maxBank = 1;
   maxPitch = 1;
   maxSpeed = 55;
   minSpeed = 35;
	lift = 0.75;
	maxAlt = 5000;
	maxVertical = 50;
	maxDamage = 0.01;
	damageLevel = {1.0, 1.0};
	maxEnergy = 20;
	accel = 9.4;

	groundDamageScale = 20.0;

	repairRate = 0;
	fireSound = SoundRemoteTurretFire;
	damageSound = SoundFlierCrash;
	ramDamage = 0;
	ramDamageType = 0;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	moveSound = SoundJetHeavy;

	visibleDriver = false;
	driverPose = 22;
	description = "Nuclear Missile";
};

function GuidedNuke::onAdd(%this)
{
	GameBase::setActive(%this,true);
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, -2);
	schedule("GuidedNuke::Destruct("@%this@");",10);
	schedule("GuidedNuke::ClearDetno("@%this@");",2.5);
	schedule("GuidedNuke::AltTrack("@%this@");",2.75);
}

function GuidedNuke::Destruct(%this)
{
	if(%this)
	{
		%cl = GameBase::getControlClient(%this);
		%pl = Client::getOwnedObject(%cl);
		bottomprint(%cl,"<c><f2>NML-CPU:<f1> Missile has run out of fuel!");
		%team = GameBase::getTeam(%this);
		$ShroomCoord[%team] = "";
		$NukeClear[%team] = true;
		%cl.nukeout = 0;
		bottomprint(%cl,"");
		Client::setControlObject(%cl,%pl);

		%this.warheadArmed = false;
		GameBase::applyDamage(%this,$DebrisDamageType,99,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
	}
}

function GuidedNuke::ClearDetno(%this)
{
	%cl = GameBase::getControlClient(%this);
	bottomprint(%cl,"<c><f2>MISSILE CAM - <f1>***WARHEAD ARMED***",1000);
	%this.warheadArmed = true;
}

function GuidedNuke::AltTrack(%this)
{
	if(isObject(%this)) // PORT: an object id stays non-zero after the nuke is gone, the 0.2 s loop never ended
	{
		%cl = GameBase::getControlClient(%this);
		%altitude = FindDistDown(%this);
		bottomprint(%cl,"<c><f2>MISSILE CAM - <f1>***WARHEAD ARMED***\n <f0> ALTITUDE = "@ %altitude @"m",1000);
		schedule("GuidedNuke::AltTrack("@%this@");",0.2);
	}
}

function GuidedNuke::onCollision(%this, %object)
{
	if(GameBase::getDataName(%this) == GuidedNuke)
	{
		if(%object.isBunker == 1)
		{
			deleteObject(%object);
			$TeamItemCount[%object.bunkerTeam @ "BunkerPack"]--;
		}	
		return;
	}
}

function GuidedNuke::jump(%this,%mom)
{
	GuidedNuke::dismount(%this,%mom);
}

function GuidedNuke::dismount(%this,%mom)
{
	THNuke::MushroomMarkTwo(%this);

	if(GameBase::getDataName(%this) == GuidedNuke && %this.warheadArmed == true)
		GameBase::applyDamage(%this,$DebrisDamageType,99,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}

function GuidedNuke::onDestroyed(%this,%mom)
{
	%cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	%team = GameBase::getTeam(%cl);

	if(%pl != -1)
	{
		Player::setMountObject(%pl, -1, 0);
		Client::setControlObject(%cl, %pl);
		%pl.driver = "";
		%pl.vehicle= "";
	}

	if(%cl != -1)
	{
		%cl.nukeout = 0;
		bottomprint(%cl,"");
		if(%this.warheadArmed == true)
			calcOwnedRadiusDamage(%this,$NukeDamageType,100,0.5,600,120,5,0.5,0,600,100,%cl);
		$NukeClear[%team] = true;
	}
	if(%this.warheadArmed == true)
		calcRadiusDamage(%this,$NukeDamageType,100,0.5,600,120,5,0.5,0,600,100);
}

function GuidedNuke::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	// Unarm it if you shoot it down
	if((%this.damagelevel + %value) > %this.maxDamage)
		%this.warheadArmed = false;

	if($damageScale[GameBase::getDataName(%this), %type])
		%scale = $damageScale[GameBase::getDataName(%this), %type];
	else
		%scale = 1.0;
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value * %scale;
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	GameBase::setDamageLevel(%this,%dValue);
	%this.THNukeHitType = %type;
}

FlierData Afid
{
	explosionId = flashExpSmall;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "logo";
   shieldShapeName = "shield_medium";
   mass = 0.05;
   drag = 0.08;
   density = 1.2;
   maxBank = 0.8;
   maxPitch = 0.9;
   maxSpeed = 20;
   minSpeed = 0;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 15;
	maxDamage = 0.12;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 10;

	groundDamageScale = 0.05;

	reloadDelay = 1;
	repairRate = 0;
	fireSound = SoundRemoteTurretFire;
	damageSound = SoundFlierCrash;
	ramDamage = 0.05;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
//	idleSound = SoundFlyerIdle;
	moveSound = SoundJetHeavy;

	visibleDriver = false;
	driverPose = 22;
	description = "AFID";
};

function Afid::onAdd(%this)
{
	GameBase::setActive(%this,true);
	%this.shieldStrength = 0.01;
	GameBase::setRechargeRate(%this, 10);

	//Set up inventory
	for(%i = 1; %i < 6; %i++)
	{
		$AFIDItem[%this,%i] = "NoItem";
	}
	$AFIDInventoryCount[%this] = 1;
}

function Afid::onFire(%this,%slot)
{
	if(%this.hasFired != true)
	{
		if(%this.cannibalize == true)
		{
			if(GameBase::getLosInfo(%this,15))
			{
				%object = $los::object;
				if(GameBase::getDataName(%object) == "Stinger")
					Afid::Cannibalize(%this,%object,"StingerPack");
	
				if(GameBase::getDataName(%object) == "RemoteChain")
					Afid::Cannibalize(%this,%object,"ChainTurretPack");

				if(GameBase::getDataName(%object) == "TankGun")
					Afid::Cannibalize(%this,%object,"ShellTurretPack");
	
				if(GameBase::getDataName(%object) == "PlasmaTurretPack")
					Afid::Cannibalize(%this,%object,"RemotePlasma");

				if(GameBase::getDataName(%object) == "RunePack")
					Afid::Cannibalize(%this,%object,"Rune");

				if(GameBase::getDataName(%object) == "NanoBasePack")
					Afid::Cannibalize(%this,%object,"NanoBase");

				if(GameBase::getDataName(%object) == "PlasWallPack")
					Afid::Cannibalize(%this,%object,"PlasWall");

				if(GameBase::getDataName(%object) == "ForceWall")
					Afid::Cannibalize(%this,%object,"ForceWallPack");

				if(GameBase::getDataName(%object) == "MassForceWall")
					Afid::Cannibalize(%this,%object,"MassWallPack");


			}
		}
		else
		{
			if(GameBase::getLosInfo(%this,15))
			{
				%object = $los::object;
				if(getObjectType(%object) == "Turret" || getObjectType(%object) == "StaticShape" || getObjectType(%object) == "Player")
				{
					%dl = GameBase::getDamageLevel(%object);
					%data = GameBase::getDataName(%this);
					%md = %data.maxdamage;
					echo(%data @" "@ %dl @" "@ %md);
					if(%dl > 0)
					{
						%trans = GameBase::getMuzzleTransform(%this);
						%vel = Item::getVelocity(%this);
						Projectile::spawnProjectile("AFIDRepairBolt",%trans,%this,%vel);
						%ndl = %dl - 0.1;
						if(%ndl < 0)
							%ndl = 0;
						GameBase::setDamageLevel(%object,%ndl);
					}
				}
			}
		}
		%this.hasFired = true;
		schedule(%this @".hasfired = false;", 0.3, %this);
	}
}

function Afid::onCollision(%this, %object)
{
	%client = Player::getClient(%object);
	if(getObjectType(%object) == "Player")
	{
		if(Player::getArmor(%object) == "marmor" || Player::getArmor(%object) == "mfemale")
		{
//			if(%this.hasPilot == false || %this.hasPilot == "")
			if(GameBase::getControlClient(%this) == -1)
			{
				%client.AFIDprospect = %this;
				ShowAFIDCollisionOptions(%client);
			}
			else
				Client::sendMessage(%client,0,"AFID-OBC: AFID already under control.~wError_Message.wav");
		}
		else
			Client::sendMessage(%client,0,"Only Engineers can pilot AFIDs.~wError_Message.wav");
	}
}

function Afid::jump(%this,%mom)
{
	Afid::dismount(%this,%mom);
}

function Afid::dismount(%this,%mom)
{
	%cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);

	%this.hasPilot = false;
	%cl.AFID = false;
	Client::setControlObject(%cl, %pl);
}

function Afid::onDestroyed(%this,%mom)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "AFID"]--;

	%cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);

	%this.hasPilot = false;
	%cl.AFID = false;
	Client::setControlObject(%cl, %pl);

	calcRadiusDamage(%this, $DebrisDamageType, 0.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100);
}

function Afid::Cannibalize(%vehicle,%target,%item)
{
	%cl = GameBase::getControlClient(%vehicle);
	//look at the turret
      Client::setControlObject(%cl, Client::getObserverCamera(%cl));
	Observer::setOrbitObject(%cl, %target, 5, 5, 5);
	//move plane away
	%vehicle.realposition = Vector::Add(Gamebase::getPosition(%target),"0 0 1");
	Gamebase::setPosition(%vehicle,Vector::Add(Gamebase::getPosition(%vehicle),"0 0 -900"));
	//finish later
	schedule("Afid::FinishCannibalize("@ %vehicle @","@ %target @","@ %item @","@ %cl @");",2);
}

function Afid::FinishCannibalize(%vehicle,%target,%item,%cl)
{
	//blow up turret
	%data = GameBase::getDataName(%target);
	%md = %data.maxdamage;
	GameBase::setDamageLevel(%target,%md);
	//move plane back
	Gamebase::setPosition(%vehicle,%vehicle.realposition);

				//assign AFID inv slot - DISABLED
				//	%i = $AFIDInventoryCount[%vehicle];
				//	$AFIDItem[%vehicle,%i] = %item;
				//	$AFIDInventoryCount[%vehicle] = $AFIDInventoryCount[%vehicle] + 1;

					// REPLACED WITH THIS - creates pack on ground
					%obj = newObject("","Item",%item,0,false);
					addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,Vector::Add(%vehicle.realposition,"0 0 -1"));

	// Give player control of AFID again, tell complete
	Client::setControlObject(%cl,%vehicle);
	bottomprint(%cl,"<f1><jc>Complete! "@ %item.description @" salvaged.");
}
echo("v.D");

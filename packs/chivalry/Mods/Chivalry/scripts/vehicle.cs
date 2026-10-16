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


FlierData Gunship
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.7;
   maxPitch = 0.8;
   maxSpeed = 40;
   minSpeed = -4;
	lift = 0.75;
	maxAlt = 10;
	maxVertical = 1;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = GunshipBullet;
	reloadDelay = 0.1;
	repairRate = 0;
	fireSound = shockExplosion;
	damageSound = SoundFlierCrash;
	ramDamage = 1.0;
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
	description = "Gunship";
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

FlierData Crawler
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 5.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 25;
   minSpeed = -10;
	lift = 0.5;
	maxAlt = 0.5;
	maxVertical = 10;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.35;

	groundDamageScale = 0.50;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = false;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "Creeper LAPC";
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

FlierData Minelayer
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.35;
   maxPitch = 0.275;
   maxSpeed = 20;								   
   minSpeed = -5;
	lift = 0.35;
	maxAlt = 15;
	maxVertical = 7;
	maxDamage = 1.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.3;

	groundDamageScale = 0.2;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	projectileType = VolcanoShell;
	fireSound = SoundFireGrenade;
	reloadDelay = 1.5;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "Minelayer";
};

FlierData Phoenix
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.7;
   maxPitch = 0.7;
   maxSpeed = 50;
   minSpeed = -10;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.4;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.6;

	groundDamageScale = 1.2;

	projectileType = "PhoenixFlame";
	reloadDelay = 0.25;
	repairRate = 0;
	fireSound = SoundPickupItem;
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
	description = "Phoenix";
};

FlierData Bomber
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
   mass = 20.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.35;
   maxPitch = 0.2;
   maxSpeed = 20;								   
   minSpeed = -1;
	lift = 0.35;
	maxAlt = 20;
	maxVertical = 6;
	maxDamage = 2.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.2;

	groundDamageScale = 0.125;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	//projectileType = "BomberShell";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 5.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "Bomber";
};

function Bomber::onAdd(%this)
{
	%this.reload = true;
}

function Bomber::onFire(%this)
{
	if(%this.reload)
	{
	%this.reload = false;
	%reloadDelay = 10;
	%player = GameBase::getControlClient(%this);
	%trans = GameBase::getMuzzleTransform(%this);
	%vel = Item::getVelocity(%this);
	%name = Client::getName(%player);
	Projectile::spawnProjectile("BomberShell",%trans,%this,%vel);
	schedule("DropBomb("@%this@");",0.6,%this);
	schedule("DropBomb("@%this@");",1.2,%this);
	schedule("DropBomb("@%this@");",1.8,%this);
	schedule("DropBomb("@%this@");",2.4,%this);
	schedule(%this@".reload = true;",%reloadDelay,%this);
	}
}

function DropBomb(%this)
{
	%trans = GameBase::getMuzzleTransform(%this);
	%vel = Item::getVelocity(%this);
	//messageall(0,"DropBomb Function passed");
	Projectile::spawnProjectile("BomberShell",%trans,%this,%vel);
}


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
$DamageScale[Scout, $FingerDamageType] 	= 1.0;
$DamageScale[Scout, $PredatorDamageType] = 1.0;
$DamageScale[Scout, $ShredderDamageType] = 1.0;
$DamageScale[Scout, $StubberDamageType] = 1.0;
$DamageScale[Scout, $LaserTDamageType] = 1.0;
$DamageScale[Scout, $VulcanDamageType] = 1.0;
$DamageScale[Scout, $GunshipDamageType] = 1.0;
$DamageScale[Scout, $HammerDamageType] = 1.0;
$DamageScale[Scout, $AnnDamageType] = 1.0;
$DamageScale[Scout, $StormDamageType] = 1.0;
$DamageScale[Scout, $PhoenixDamageType] = 1.0;
$DamageScale[Scout, $InfernoDamageType] = 1.0;
$DamageScale[Scout, $ViperDamageType] = 1.0;
$DamageScale[Scout, $ScatterDamageType] = 0.6;
$DamageScale[Scout, $StutterDamageType] = 1.0;
$DamageScale[Scout, $TridentDamageType] = 1.0;

$DamageScale[Gunship, $ImpactDamageType] = 1.0;
$DamageScale[Gunship, $BulletDamageType] = 1.1;
$DamageScale[Gunship, $PlasmaDamageType] = 0.5;
$DamageScale[Gunship, $EnergyDamageType] = 0.5;
$DamageScale[Gunship, $ExplosionDamageType] = 1.3;
$DamageScale[Gunship, $ShrapnelDamageType] = 1.3;
$DamageScale[Gunship, $DebrisDamageType] = 1.3;
$DamageScale[Gunship, $MissileDamageType] = 1.3;
$DamageScale[Gunship, $LaserDamageType] = 0.5;
$DamageScale[Gunship, $MortarDamageType] = 1.6;
$DamageScale[Gunship, $BlasterDamageType] = 0.5;
$DamageScale[Gunship, $ElectricityDamageType] = 1.0;
$DamageScale[Gunship, $MineDamageType]        = 1.0;
$DamageScale[Gunship, $FingerDamageType] 	= 1.0;
$DamageScale[Gunship, $PredatorDamageType] = 1.1;
$DamageScale[Gunship, $ShredderDamageType] = 0.5;
$DamageScale[Gunship, $StubberDamageType] = 1.1;
$DamageScale[Gunship, $LaserTDamageType] = 0.5;
$DamageScale[Gunship, $VulcanDamageType] = 1.1;
$DamageScale[Gunship, $GunshipDamageType] = 1.0;
$DamageScale[Gunship, $HammerDamageType] = 1.6;
$DamageScale[Gunship, $AnnDamageType] = 1.6;
$DamageScale[Gunship, $StormDamageType] = 1.0;
$DamageScale[Gunship, $PhoenixDamageType] = 0.5;
$DamageScale[Gunship, $InfernoDamageType] = 1.0;
$DamageScale[Gunship, $ViperDamageType] = 1.3;
$DamageScale[Gunship, $ScatterDamageType] = 0.6;
$DamageScale[Gunship, $StutterDamageType] = 1.0;
$DamageScale[Gunship, $TridentDamageType] = 1.3;

$DamageScale[Phoenix, $ImpactDamageType] = 1.0;
$DamageScale[Phoenix, $BulletDamageType] = 1.0;
$DamageScale[Phoenix, $PlasmaDamageType] = 0.5;
$DamageScale[Phoenix, $EnergyDamageType] = 1.0;
$DamageScale[Phoenix, $ExplosionDamageType] = 1.0;
$DamageScale[Phoenix, $ShrapnelDamageType] = 1.0;
$DamageScale[Phoenix, $DebrisDamageType] = 1.0;
$DamageScale[Phoenix, $MissileDamageType] = 1.0;
$DamageScale[Phoenix, $LaserDamageType] = 1.0;
$DamageScale[Phoenix, $MortarDamageType] = 1.0;
$DamageScale[Phoenix, $BlasterDamageType] = 0.5;
$DamageScale[Phoenix, $ElectricityDamageType] = 1.0;
$DamageScale[Phoenix, $MineDamageType]        = 1.0;
$DamageScale[Phoenix, $FingerDamageType] 	= 1.0;
$DamageScale[Phoenix, $PredatorDamageType] = 1.0;
$DamageScale[Phoenix, $ShredderDamageType] = 1.0;
$DamageScale[Phoenix, $StubberDamageType] = 1.0;
$DamageScale[Phoenix, $LaserTDamageType] = 1.0;
$DamageScale[Phoenix, $VulcanDamageType] = 1.0;
$DamageScale[Phoenix, $GunshipDamageType] = 1.0;
$DamageScale[Phoenix, $HammerDamageType] = 1.0;
$DamageScale[Phoenix, $AnnDamageType] = 1.0;
$DamageScale[Phoenix, $StormDamageType] = 1.0;
$DamageScale[Phoenix, $PhoenixDamageType] = 0.4;
$DamageScale[Phoenix, $InfernoDamageType] = 1.0;
$DamageScale[Phoenix, $ViperDamageType] = 1.0;
$DamageScale[Phoenix, $ScatterDamageType] = 0.6;
$DamageScale[Phoenix, $StutterDamageType] = 1.0;
$DamageScale[Phoenix, $TridentDamageType] = 1.0;

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
$DamageScale[LAPC, $FingerDamageType] 	= 1.0;
$DamageScale[LAPC, $PredatorDamageType] = 1.0;
$DamageScale[LAPC, $ShredderDamageType] = 1.0;
$DamageScale[LAPC, $StubberDamageType] = 1.0;
$DamageScale[LAPC, $LaserTDamageType] = 0.5;
$DamageScale[LAPC, $VulcanDamageType] = 1.0;
$DamageScale[LAPC, $GunshipDamageType] = 1.0;
$DamageScale[LAPC, $HammerDamageType] = 1.0;
$DamageScale[LAPC, $AnnDamageType] = 1.0;
$DamageScale[LAPC, $StormDamageType] = 1.0;
$DamageScale[LAPC, $PhoenixDamageType] = 1.0;
$DamageScale[LAPC, $InfernoDamageType] = 1.0;
$DamageScale[LAPC, $ViperDamageType] = 1.0;
$DamageScale[LAPC, $ScatterDamageType] = 0.6;
$DamageScale[LAPC, $StutterDamageType] = 1.0;
$DamageScale[LAPC, $TridentDamageType] = 1.0;

$DamageScale[Bomber, $ImpactDamageType] = 1.0;
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
$DamageScale[Bomber, $FingerDamageType] 	= 1.0;
$DamageScale[Bomber, $PredatorDamageType] = 1.0;
$DamageScale[Bomber, $ShredderDamageType] = 1.0;
$DamageScale[Bomber, $StubberDamageType] = 1.0;
$DamageScale[Bomber, $LaserTDamageType] = 0.5;
$DamageScale[Bomber, $VulcanDamageType] = 1.0;
$DamageScale[Bomber, $GunshipDamageType] = 1.0;
$DamageScale[Bomber, $HammerDamageType] = 1.0;
$DamageScale[Bomber, $AnnDamageType] = 1.0;
$DamageScale[Bomber, $StormDamageType] = 1.0;
$DamageScale[Bomber, $PhoenixDamageType] = 1.0;
$DamageScale[Bomber, $InfernoDamageType] = 1.0;
$DamageScale[Bomber, $ViperDamageType] = 1.0;
$DamageScale[Bomber, $ScatterDamageType] = 0.6;
$DamageScale[Bomber, $StutterDamageType] = 1.0;
$DamageScale[Bomber, $TridentDamageType] = 1.0;

$DamageScale[Minelayer, $ImpactDamageType] = 1.0;
$DamageScale[Minelayer, $BulletDamageType] = 1.0;
$DamageScale[Minelayer, $PlasmaDamageType] = 1.0;
$DamageScale[Minelayer, $EnergyDamageType] = 1.0;
$DamageScale[Minelayer, $ExplosionDamageType] = 1.0;
$DamageScale[Minelayer, $ShrapnelDamageType] = 1.0;
$DamageScale[Minelayer, $DebrisDamageType] = 1.0;
$DamageScale[Minelayer, $MissileDamageType] = 1.0;
$DamageScale[Minelayer, $LaserDamageType] = 0.5;
$DamageScale[Minelayer, $MortarDamageType] = 1.0;
$DamageScale[Minelayer, $BlasterDamageType] = 0.5;
$DamageScale[Minelayer, $ElectricityDamageType] = 1.0;
$DamageScale[Minelayer, $MineDamageType]        = 1.0;
$DamageScale[Minelayer, $FingerDamageType] 	= 1.0;
$DamageScale[Minelayer, $PredatorDamageType] = 1.0;
$DamageScale[Minelayer, $ShredderDamageType] = 1.0;
$DamageScale[Minelayer, $StubberDamageType] = 1.0;
$DamageScale[Minelayer, $LaserTDamageType] = 0.5;
$DamageScale[Minelayer, $VulcanDamageType] = 1.0;
$DamageScale[Minelayer, $GunshipDamageType] = 1.0;
$DamageScale[Minelayer, $HammerDamageType] = 1.0;
$DamageScale[Minelayer, $AnnDamageType] = 1.0;
$DamageScale[Minelayer, $StormDamageType] = 1.0;
$DamageScale[Minelayer, $PhoenixDamageType] = 1.0;
$DamageScale[Minelayer, $InfernoDamageType] = 1.0;
$DamageScale[Minelayer, $ViperDamageType] = 1.0;
$DamageScale[Minelayer, $ScatterDamageType] = 0.6;
$DamageScale[Minelayer, $StutterDamageType] = 1.0;
$DamageScale[Minelayer, $TridentDamageType] = 1.0;

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
$DamageScale[HAPC, $FingerDamageType] 	= 1.0;
$DamageScale[HAPC, $PredatorDamageType] = 1.0;
$DamageScale[HAPC, $ShredderDamageType] = 1.0;
$DamageScale[HAPC, $StubberDamageType] = 1.0;
$DamageScale[HAPC, $LaserTDamageType] = 0.5;
$DamageScale[HAPC, $VulcanDamageType] = 1.0;
$DamageScale[HAPC, $GunshipDamageType] = 1.0;
$DamageScale[HAPC, $HammerDamageType] = 1.0;
$DamageScale[HAPC, $AnnDamageType] = 1.0;
$DamageScale[HAPC, $StormDamageType] = 1.0;
$DamageScale[HAPC, $PhoenixDamageType] = 1.0;
$DamageScale[HAPC, $InfernoDamageType] = 1.0;
$DamageScale[HAPC, $ViperDamageType] = 1.0;
$DamageScale[HAPC, $ScatterDamageType] = 0.6;
$DamageScale[HAPC, $StutterDamageType] = 1.0;
$DamageScale[HAPC, $TridentDamageType] = 1.0;

$DamageScale[Crawler, $ImpactDamageType] = 1.0;
$DamageScale[Crawler, $BulletDamageType] = 1.0;
$DamageScale[Crawler, $PlasmaDamageType] = 1.0;
$DamageScale[Crawler, $EnergyDamageType] = 1.0;
$DamageScale[Crawler, $ExplosionDamageType] = 1.0;
$DamageScale[Crawler, $ShrapnelDamageType] = 1.0;
$DamageScale[Crawler, $DebrisDamageType] = 1.0;
$DamageScale[Crawler, $MissileDamageType] = 1.0;
$DamageScale[Crawler, $LaserDamageType] = 0.5;
$DamageScale[Crawler, $MortarDamageType] = 1.0;
$DamageScale[Crawler, $BlasterDamageType] = 0.5;
$DamageScale[Crawler, $ElectricityDamageType] = 1.0;
$DamageScale[Crawler, $MineDamageType]        = 1.0;
$DamageScale[Crawler, $FingerDamageType] 	= 1.0;
$DamageScale[Crawler, $PredatorDamageType] = 1.0;
$DamageScale[Crawler, $ShredderDamageType] = 1.0;
$DamageScale[Crawler, $StubberDamageType] = 1.0;
$DamageScale[Crawler, $LaserTDamageType] = 1.0;
$DamageScale[Crawler, $VulcanDamageType] = 1.0;
$DamageScale[Crawler, $GunshipDamageType] = 1.0;
$DamageScale[Crawler, $HammerDamageType] = 1.0;
$DamageScale[Crawler, $AnnDamageType] = 1.0;
$DamageScale[Crawler, $StormDamageType] = 1.0;
$DamageScale[Crawler, $PhoenixDamageType] = 1.0;
$DamageScale[Crawler, $InfernoDamageType] = 1.0;
$DamageScale[Crawler, $ViperDamageType] = 1.0;
$DamageScale[Crawler, $ScatterDamageType] = 0.6;
$DamageScale[Crawler, $StutterDamageType] = 1.0;
$DamageScale[Crawler, $TridentDamageType] = 1.0;

//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
}

function Vehicle::onCollision (%this, %object)
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
			{
            if( Player::isAiControlled(%object) )
               return;
               
				%armor = Player::getArmor(%object);
		      %client = Player::getClient(%object);
			%veh = GameBase::getDataName(%this) ;
					if(%client.Undead && (%veh == Scout || %veh == Gunship || %veh == Phoenix))
						{
						Client::sendMessage(Player::getClient(%object),0,"Undead may only pilot APC type vehicles.~wError_Message.wav");
						return;
						}
					else if ((%armor == "magarmor" || %armor == "magfemale" || %armor == "scarmor" || %armor == "scfemale" || %armor == "marmor" || %armor == "mfemale") && Vehicle::canMount (%this, %object))
					{
						%weapon = Player::getMountedItem(%object,$WeaponSlot);
						if(%weapon != -1) {
							%object.lastWeapon = %weapon;
							Player::unMountItem(%object,$WeaponSlot);
						}
					Player::setMountObject(%object, %this, 1);
				      Client::setControlObject(%client, %this);
						playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
						%object.driver= 1;
		            %object.vehicle = %this;
						%this.clLastMount = %client;
					}
				else if(GameBase::getDataName(%this) != Scout && GameBase::getDataName(%this) != Gunship && GameBase::getDataName(%this) != Phoenix) 
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
					Client::sendMessage(Player::getClient(%object),0,"You must be in Light Armor to pilot the vehicles.~wError_Message.wav");
			}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{
	if(GameBase::getDataName(%this) == HAPC || GameBase::getDataName(%this) == Minelayer || GameBase::getDataName(%this) == Bomber)
		%numSlots = 4;
	else
		%numSlots = 2;
	%count=0;
	for(%i=0;%i<%numSlots;%i++)  
		if(%this.Seat[%i] == "") {
			%slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
			%slotVal[%count] = %i+2;
			%lastEmpty = %i+2;
			%count++;
		}
	if(%count == 1) {
		%this.Seat[%lastEmpty-2] = %client;
		return %lastEmpty;
	}
	else if (%count > 1)	{
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
	for(%i = 0 ;%i<%num;%i++) {
		%x = (getWord(%slotPos[%i],0)) - %playerX;
		%y = (getWord(%slotPos[%i],1)) - %playerY;
		if(%x < 0)
			%x *= -1;
		if(%y < 0)
			%y *= -1;
		%newDistance = sqrt((%x*%x)+(%y*%y));
		if(%newDistance < %distance || %distance == "") {
	  		%distance = %newDistance;			
			%closePos = %i;	
		}
	}		
	return %closePos;
}

function Vehicle::passengerJump(%this,%passenger,%mom)
{
	%armor = Player::getArmor(%passenger);
	if(%armor == "magarmor" || %armor == "magfemale" || %armor == "scarmor" || %armor == "scfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "worarmor" || %armor == "worfemale" || %armor == "cftarmor" || %armor == "cftfemale" || %armor == "marmor" || %armor == "mfemale" || %armor == "clrarmor" || %armor == "clrfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "palarmor" || %armor == "lavarmor") {
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
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
      %pl = Client::getOwnedObject(%cl);
      if(getObjectType(%pl) == "Player")
      {
		   // dismount the player	  
			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) {
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
				if(%pl.lastWeapon != "") {
					Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";
      		}
				%pl.driver = "";
				%pl.vehicle = "";
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
   }
}

function Vehicle::onDestroyed (%this,%mom)
{
//	if($testcheats || $servercheats)
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
   %cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	if(%pl != -1) {
	   Player::setMountObject(%pl, -1, 0);
   	Client::setControlObject(%cl, %pl);
		if(%pl.lastWeapon != "") {
			Player::useItem(%pl,%pl.lastWeapon);		 	
			%pl.lastWeapon = "";
		}
		%pl.driver = "";
	   %pl.vehicle= "";
	}
	for(%i = 0 ; %i < 4 ; %i++)
		if(%this.Seat[%i] != "") {
			%pl = Client::getOwnedObject(%this.Seat[%i]);
		   Player::setMountObject(%pl, -1, 0);
	  	 	Client::setControlObject(%this.Seat[%i], %pl);
			%pl.vehicleSlot = "";
		   %pl.vehicle= "";
		}
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 
		0.1, 225, 100); 
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}
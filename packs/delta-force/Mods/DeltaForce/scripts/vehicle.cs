// DELTA FORCE VEHICLES
// ---------------------------------------------

FlierData Apache
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
	maxDamage = 1.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	//projectileType = ApacheRocket;
	reloadDelay = 0.5;
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
	description = "Apache";
};

FlierData Warthog
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
   maxPitch = 0.25;
   maxSpeed = 30;
   minSpeed = 0;
	lift = 0.5;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.75;

	projectileType = WarthogBullet;
	reloadRate = 0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireMortar;
	reloadDelay = 0.3;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "A-10 Warthog";
};

FlierData MoveWarthog
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.60;           //maxBank = 0.25;
   maxPitch = 0.70;          //maxPitch = 0.25;
   maxSpeed = 50;            //maxSpeed = 45;
   minSpeed = 30;
	lift = 0.5;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.35;   //accel = 0.25;

	groundDamageScale = 0.75;

	//projectileType = WarthogBullet;
	reloadRate = 0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireMortar;
	reloadDelay = 0.15;            //reloadDelay = 0.3;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "A-10 Warthog";
};

function MoveWarthog::onFire(%this)
{
	Vehicle::onFire(%this);
}

FlierData TOWMissile
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "rocket";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 50;
   minSpeed = 50;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.001;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 2.0;

	groundDamageScale = 5.0;

	reloadDelay = 0.0;
	repairRate = 0;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	moveSound = SoundJetHeavy;

	visibleDriver = false;
	driverPose = 22;
	description = "TOW";
};

function OutOfCable(%this) 
{
	%cl = GameBase::getControlClient(%this);
	Vehicle::dismount(%this, "0 0 0");
	remoteEval(%cl, BP, "<jc><f0>TOW Missile is out of cable", 4);
}

function TOWMissile::onAdd(%this) 
{
	GameBase::setRechargeRate(%this, -25); // TOW lives for 4 seconds
	schedule("OutOfCable("@%this@");", 4, %this);
	schedule("$TOWDetEnable["@%this@"] = 1;", 0.5, %this);
}

function TOWMissile::onFire(%this)
{
	if ($TOWDetEnable[%this] == 1) {
		%cl = GameBase::getControlClient(%this);
		Vehicle::dismount(%this, "0 0 0");
		remoteEval(%cl, BP, "<jc><f0>TOW Missile Remotely Detonated", 4);
		$TOWDetEnable[%this] = 0;
	}
}

FlierData Blackhawk
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
	description = "Blackhawk";
};

function Blackhawk::onAdd(%this) 
{
	$VehicleAmmo[%this, Minigun] = 400;
	$PassengerSlot[%this, 2] = 0;
	$PassengerSlot[%this, 3] = 0;
	Vehicle::onAdd(%this);
}

FlierData Humvee
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
   maxPitch = 0.3;
   maxSpeed = 25;
   minSpeed = -10;
	//lift = 26.0;
	lift = 2.0;
	maxAlt = 10;
	maxVertical = 6;
	maxDamage = 1.0;
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
	idleSound = SoundGeneratorPower;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 23;
	description = "HMMWV";
};

function Humvee::onAdd(%this) 
{
	$VehicleAmmo[%this, TOW] = 8;
	$VehicleAmmo[%this, AutoGrenLauncher] = 50;
	$PassengerSlot[%this, 2] = 0;
	$PassengerSlot[%this, 3] = 0;
	Vehicle::onAdd(%this);
}

FlierData Abrams
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
   maxPitch = 0.3;
   maxSpeed = 15;
   minSpeed = -10;
	//lift = 26.0;
	lift = 2.0;
	maxAlt = 10;
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
	idleSound = SoundGeneratorPower;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 23;
	description = "M1A1 Abrams";
};

function Abrams::onAdd(%this) 
{
	$VehicleAmmo[%this, AbramsGun] = 30;
	$VehicleAmmo[%this, Minigun] = 400;
	$PassengerSlot[%this, 2] = 0;
	$PassengerSlot[%this, 3] = 0;
	Vehicle::onAdd(%this);
}

FlierData Bradley
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
   maxSpeed = 15;								   
   minSpeed = -10;
	//lift = 26.0;
	lift = 2.0;
	maxAlt = 10;
	maxVertical = 6;
	maxDamage = 1.5;
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
	idleSound = SoundGeneratorPower;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 23;
	description = "M113";
};

$DamageScale[Apache, $ImpactDamageType] = 1.0;
$DamageScale[Apache, $BulletDamageType] = 0.2;
$DamageScale[Apache, $PlasmaDamageType] = 0.05;
$DamageScale[Apache, $EnergyDamageType] = 1.0;
$DamageScale[Apache, $ExplosionDamageType] = 1.0;
$DamageScale[Apache, $ShrapnelDamageType] = 1.0;
$DamageScale[Apache, $DebrisDamageType] = 1.0;
$DamageScale[Apache, $MissileDamageType] = 1.0;
$DamageScale[Apache, $LaserDamageType] = 0.5;
$DamageScale[Apache, $MortarDamageType] = 1.0;
$DamageScale[Apache, $BlasterDamageType] = 0.5;
$DamageScale[Apache, $ElectricityDamageType] = 1.0;
$DamageScale[Apache, $MineDamageType]        = 1.0;
$DamageScale[Apache, $ChargeDamageType]      = 1.0;
$DamageScale[Apache, $AirstrikeDamageType]   = 1.0;

$DamageScale[Warthog, $ImpactDamageType] = 1.0;
$DamageScale[Warthog, $BulletDamageType] = 0.2;
$DamageScale[Warthog, $PlasmaDamageType] = 0.05;
$DamageScale[Warthog, $EnergyDamageType] = 1.0;
$DamageScale[Warthog, $ExplosionDamageType] = 0.7;
$DamageScale[Warthog, $ShrapnelDamageType] = 0.6;
$DamageScale[Warthog, $DebrisDamageType] = 0.7;
$DamageScale[Warthog, $MissileDamageType] = 1.0;
$DamageScale[Warthog, $LaserDamageType] = 0.3;
$DamageScale[Warthog, $MortarDamageType] = 1.0;
$DamageScale[Warthog, $BlasterDamageType] = 0.5;
$DamageScale[Warthog, $ElectricityDamageType] = 1.0;
$DamageScale[Warthog, $MineDamageType]        = 1.0;
$DamageScale[Warthog, $ChargeDamageType] = 1.0;
$DamageScale[Warthog, $AirstrikeDamageType]   = 1.0;

$DamageScale[MoveWarthog, $ImpactDamageType] = 1.0;
$DamageScale[MoveWarthog, $BulletDamageType] = 0.2;
$DamageScale[MoveWarthog, $PlasmaDamageType] = 0.05;
$DamageScale[MoveWarthog, $EnergyDamageType] = 1.0;
$DamageScale[MoveWarthog, $ExplosionDamageType] = 0.7;
$DamageScale[MoveWarthog, $ShrapnelDamageType] = 0.6;
$DamageScale[MoveWarthog, $DebrisDamageType] = 0.7;
$DamageScale[MoveWarthog, $MissileDamageType] = 1.0;
$DamageScale[MoveWarthog, $LaserDamageType] = 0.3;
$DamageScale[MoveWarthog, $MortarDamageType] = 1.0;
$DamageScale[MoveWarthog, $BlasterDamageType] = 0.5;
$DamageScale[MoveWarthog, $ElectricityDamageType] = 1.0;
$DamageScale[MoveWarthog, $MineDamageType]        = 1.0;
$DamageScale[MoveWarthog, $ChargeDamageType] = 1.0;
$DamageScale[MoveWarthog, $AirstrikeDamageType]   = 1.0;

$DamageScale[TOWMissile, $ImpactDamageType] = 10.0;
$DamageScale[TOWMissile, $BulletDamageType] = 0.6;
$DamageScale[TOWMissile, $PlasmaDamageType] = 1.0;
$DamageScale[TOWMissile, $EnergyDamageType] = 1.0;
$DamageScale[TOWMissile, $ExplosionDamageType] = 1.0;
$DamageScale[TOWMissile, $ShrapnelDamageType] = 1.0;
$DamageScale[TOWMissile, $DebrisDamageType] = 1.0;
$DamageScale[TOWMissile, $MissileDamageType] = 1.0;
$DamageScale[TOWMissile, $LaserDamageType] = 1.0;
$DamageScale[TOWMissile, $MortarDamageType] = 1.0;
$DamageScale[TOWMissile, $BlasterDamageType] = 0.5;
$DamageScale[TOWMissile, $ElectricityDamageType] = 1.0;
$DamageScale[TOWMissile, $MineDamageType]        = 1.0;
$DamageScale[TOWMissile, $ChargeDamageType]      = 1.0;
$DamageScale[TOWMissile, $AirstrikeDamageType]   = 1.0;

$DamageScale[Blackhawk, $ImpactDamageType] = 1.0;
$DamageScale[Blackhawk, $BulletDamageType] = 0.9;
$DamageScale[Blackhawk, $PlasmaDamageType] = 0.1;
$DamageScale[Blackhawk, $EnergyDamageType] = 1.0;
$DamageScale[Blackhawk, $ExplosionDamageType] = 1.0;
$DamageScale[Blackhawk, $ShrapnelDamageType] = 1.0;
$DamageScale[Blackhawk, $DebrisDamageType] = 1.0;
$DamageScale[Blackhawk, $MissileDamageType] = 1.0;
$DamageScale[Blackhawk, $LaserDamageType] = 0.5;
$DamageScale[Blackhawk, $MortarDamageType] = 1.0;
$DamageScale[Blackhawk, $BlasterDamageType] = 0.5;
$DamageScale[Blackhawk, $ElectricityDamageType] = 1.0;
$DamageScale[Blackhawk, $MineDamageType]        = 1.0;
$DamageScale[Blackhawk, $ChargeDamageType] = 1.0;
$DamageScale[Blackhawk, $AirstrikeDamageType]   = 1.0;

$DamageScale[Humvee, $ImpactDamageType] = 0.0;
$DamageScale[Humvee, $BulletDamageType] = 0.1;
$DamageScale[Humvee, $PlasmaDamageType] = 0.1;
$DamageScale[Humvee, $EnergyDamageType] = 1.0;
$DamageScale[Humvee, $ExplosionDamageType] = 0.8;
$DamageScale[Humvee, $ShrapnelDamageType] = 0.8;
$DamageScale[Humvee, $DebrisDamageType] = 0.7;
$DamageScale[Humvee, $MissileDamageType] = 0.9;
$DamageScale[Humvee, $LaserDamageType] = 0.0;
$DamageScale[Humvee, $MortarDamageType] = 0.8;
$DamageScale[Humvee, $BlasterDamageType] = 0.5;
$DamageScale[Humvee, $ElectricityDamageType] = 1.0;
$DamageScale[Humvee, $MineDamageType]        = 0.8;
$DamageScale[Humvee, $ChargeDamageType]       = 1.0;
$DamageScale[Humvee, $AirstrikeDamageType]   = 1.0;

$DamageScale[Abrams, $ImpactDamageType] = 0.0;
$DamageScale[Abrams, $BulletDamageType] = 0.0;
$DamageScale[Abrams, $PlasmaDamageType] = 0.05;
$DamageScale[Abrams, $EnergyDamageType] = 1.0;
$DamageScale[Abrams, $ExplosionDamageType] = 0.8;
$DamageScale[Abrams, $ShrapnelDamageType] = 0.8;
$DamageScale[Abrams, $DebrisDamageType] = 0.7;
$DamageScale[Abrams, $MissileDamageType] = 0.5;
$DamageScale[Abrams, $LaserDamageType] = 0.0;
$DamageScale[Abrams, $MortarDamageType] = 0.8;
$DamageScale[Abrams, $BlasterDamageType] = 0.5;
$DamageScale[Abrams, $ElectricityDamageType] = 1.0;
$DamageScale[Abrams, $MineDamageType]        = 0.7;
$DamageScale[Abrams, $ChargeDamageType]       = 0.8;
$DamageScale[Abrams, $AirstrikeDamageType]   = 0.5;

$DamageScale[Bradley, $ImpactDamageType] = 0.0;
$DamageScale[Bradley, $BulletDamageType] = 0.0;
$DamageScale[Bradley, $PlasmaDamageType] = 0.05;
$DamageScale[Bradley, $EnergyDamageType] = 1.0;
$DamageScale[Bradley, $ExplosionDamageType] = 0.8;
$DamageScale[Bradley, $ShrapnelDamageType] = 0.8;
$DamageScale[Bradley, $DebrisDamageType] = 0.7;
$DamageScale[Bradley, $MissileDamageType] = 0.5;
$DamageScale[Bradley, $LaserDamageType] = 0.0;
$DamageScale[Bradley, $MortarDamageType] = 0.8;
$DamageScale[Bradley, $BlasterDamageType] = 0.5;
$DamageScale[Bradley, $ElectricityDamageType] = 1.0;
$DamageScale[Bradley, $MineDamageType]        = 0.7;
$DamageScale[Bradley, $ChargeDamageType]      = 0.8;
$DamageScale[Bradley, $AirstrikeDamageType]   = 0.25;

$VehicleAmmoType[Humvee, 2] = TOWAmmo;
$VehicleAmmoType[Humvee, 3] = AutoGrenAmmo;

$VehicleAmmoType[Abrams, 2] = AbramsAmmo;
$VehicleAmmoType[Abrams, 3] = MinigunAmmo;

$VehicleAmmoType[Blackhawk, 2] = MinigunAmmo;
$VehicleAmmoType[Blackhawk, 3] = MinigunAmmo;

$VehicleReloadRate[TOWAmmo] = 2;
$VehicleReloadRate[AutoGrenAmmo] = 10;
$VehicleReloadRate[AbramsAmmo] = 8;
$VehicleReloadRate[MinigunAmmo] = 80;

$VehicleAmmoMax[Humvee, TOWAmmo] = 8;
$VehicleAmmoMax[Humvee, AutoGrenAmmo] = 50;

$VehicleAmmoMax[Abrams, AbramsAmmo] = 30;
$VehicleAmmoMax[Abrams, MinigunAmmo] = 400;

$VehicleAmmoMax[Blackhawk, MinigunAmmo] = 400;

// ------ Vehicle weapons ------

// WARTHOG
$VehiclePrimaryGuns[MoveWarthog] = 3;
$VehicleWeapon[MoveWarthog, 0] = WarthogBullet;
$VehicleWeapon[MoveWarthog, 1] = ApacheRocket;
$VehicleWeapon[MoveWarthog, 2] = BigBomb;

$VehicleWeaponAmmoMax[MoveWarthog, WarthogBullet] = 700;
$VehicleWeaponAmmoMax[MoveWarthog, ApacheRocket] = 50;
$VehicleWeaponAmmoMax[MoveWarthog, BigBomb] = 8;

$VehicleWeapFireDelay[MoveWarthog, WarthogBullet] = 0.15;
$VehicleWeapFireDelay[MoveWarthog, ApacheRocket] = 0.5;
$VehicleWeapFireDelay[MoveWarthog, BigBomb] = 2.0;

$VehiclePrimaryGuns[Warthog] = 3;
$VehicleWeapon[Warthog, 0] = WarthogBullet;
$VehicleWeapon[Warthog, 1] = ApacheRocket;
$VehicleWeapon[Warthog, 2] = BigBomb;

$VehicleWeaponAmmoMax[Warthog, WarthogBullet] = 700;
$VehicleWeaponAmmoMax[Warthog, ApacheRocket] = 50;
$VehicleWeaponAmmoMax[Warthog, BigBomb] = 8;

// APACHE
$VehiclePrimaryGuns[Apache] = 3;
$VehicleWeapon[Apache, 0] = SAWBullet;
$VehicleWeapon[Apache, 1] = ApacheRocket;
$VehicleWeapon[Apache, 2] = StingerMissile;

$VehicleWeaponAmmoMax[Apache, SAWBullet] = 500;
$VehicleWeaponAmmoMax[Apache, ApacheRocket] = 30;
$VehicleWeaponAmmoMax[Apache, StingerMissile] = 2;

$VehicleWeapFireDelay[Apache, SAWBullet] = 0.2;
$VehicleWeapFireDelay[Apache, ApacheRocket] = 0.5;
$VehicleWeapFireDelay[Apache, StingerMissile] = 1.0;

// GENERAL WEAP DESCRIPTIONS

$WeaponDesc[SAWBullet] = "20mm Chain Gun";
$WeaponDesc[WarthogBullet] = "30mm Cannon";
$WeaponDesc[ApacheRocket] = "Hellfire Missile";
$WeaponDesc[StingerMissile] = "Sidewinder Missile";
$WeaponDesc[BigBomb] = "Mk82 Bomb";

$WeaponReloadRate[SAWBullet] = 20;
$WeaponReloadRate[WarthogBullet] = 20;
$WeaponReloadRate[ApacheRocket] = 5;
$WeaponReloadRate[StingerMissile] = 5;
$WeaponReloadRate[BigBomb] = 1;

$WeaponRequiresLock[SAWBullet] = False;
$WeaponRequiresLock[WarthogBullet] = False;
$WeaponRequiresLock[ApacheRocket] = False;
$WeaponRequiresLock[StingerMissile] = True;
$WeaponRequiresLock[BigBomb] = False;

$WeaponFreeFall[SAWBullet] = False;
$WeaponFreeFall[WarthogBullet] = False;
$WeaponFreeFall[ApacheRocket] = False;
$WeaponFreeFall[StingerMissile] = False;
$WeaponFreeFall[BigBomb] = True;

$WeaponSound[SAWBullet] = shockExplosion;
$WeaponSound[WarthogBullet] = shockExplosion;
$WeaponSound[ApacheRocket] = SoundFireFlierRocket;
$WeaponSound[StingerMissile] = SoundFireFlierRocket;
$WeaponSound[BigBomb] = shockExplosion;

// END DELTA FORCE VEHICLES
// --------------------------------------------------

//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

function Vehicle::onFire(%this)
{
	%name = GameBase::getDataName(%this);
	%weapNum = $VehiclePrimaryGuns[%name];
	%player = GameBase::getControlClient(%this);

	if(%weapNum > 0)
	{
		if($VehicleCanFire[%this])
		{
			%weapName = $VehicleWeapon[%name,$VehicleCurWeapon[%this]];
			%weapPName = $WeaponDesc[$VehicleWeapon[%name,$VehicleCurWeapon[%this]]];
			
			if($VehicleWeaponAmmo[%this, %weapName] > 0)
			{
				// Fire the gun
				%vRot = GameBase::getRotation(%this);
				%vOff = Vector::getFromRot(%vRot, 13);
				%transform = GameBase::getMuzzleTransform(%this);
				
				// Main part of transform
				%pX = getWord(%transform, 9);
				%pY = getWord(%transform, 10);
				%pZ = getWord(%transform, 11);
				
				// Don't understand the rest of it, but dump it in
				%rA = getWord(%transform, 0);
				%rB = getWord(%transform, 1);
				%rC = getWord(%transform, 2);
				%rD = getWord(%transform, 3);
				%rE = getWord(%transform, 4);
				%rF = getWord(%transform, 5);
				%rG = getWord(%transform, 6);
				%rH = getWord(%transform, 7);
				%rI = getWord(%transform, 8);

				// Offset for the shot
				%oX = getWord(%vOff, 0);
				%oY = getWord(%vOff, 1);
				%oZ = getWord(%vOff, 2);
	
				// Combine it all
				%transform = %rA @ " "@%rB@" "@%rC@" "@%rD@" "@%rE@" "@%rF@" "@%rG@" "@%rH@" "@%rI@" "@%pX+%oX@" "@%pY+%oY@" " @ %pZ+%oZ;
				%playerVel = Item::getVelocity(%this);
				
				if($WeaponRequiresLock[%weapName])
				{
					GameBase::getLOSInfo(%this, 1000);
					if (GameBase::getDataName($los::object) == Apache || GameBase::getDataName($los::object) == Blackhawk || GameBase::getDataName($los::object) == Warthog || GameBase::getDataName($los::object) == MoveWarthog)
						Projectile::spawnProjectile(%weapName, %transform, %this, %playerVel, $los::object);
					else 
					{
						Bottomprint(%player, "<jc>Weapon Lock Not Achieved", 3);
						return;
					}
				} else if($WeaponFreeFall[%weapName])
				{
					%transform = "0 0 0 0 0 0 0 0 0 "@%pX@" "@%pY@" " @ %pZ - 3;
					Projectile::spawnProjectile(%weapName, %transform, %this, %playerVel);

				} else Projectile::spawnProjectile(%weapName, %transform, %this, %playerVel);
				GameBase::playSound(%this, $WeaponSound[%weapName], 3);

				// Set up fire delay until next shot
				$VehicleCanFire[%this] = False;
				%delay = $VehicleWeapFireDelay[%name, %weapName];
				schedule("$VehicleCanFire["@%this@"] = True;", %delay, %this);  
				
				// Decrement ammo count
				$VehicleWeaponAmmo[%this, %weapName]--;
				
				// Set energy to reflect ammo level
				%enerLevel = $VehicleWeaponAmmo[%this, %weapName] / $VehicleWeaponAmmoMax[%name, %weapName] * 100;
				GameBase::setEnergy(%this, %enerLevel);
			} else {
				Bottomprint(%player, "<jc>" @ %weapPName @ " is out of ammo", 3);
			}
		}
	} 
}

// Should keep the vehicles relatively close to the ground...hopefully
function hugGround(%this) 
{
	GameBase::getLOSInfo(%this, 500, "-1.57 0 0");
	%posZ = getWord($los::position, 2) + 2.0;
	%curPos = GameBase::getPosition(%this);
	%posX = getWord(%curPos, 0);
	%posY = getWord(%curPos, 1);
	%curPos = ""@%posX@" "@%posY@" "@%posZ@"";	
	if(GameBase::testPosition(%this, %curPos)) GameBase::setPosition(%this, %curPos);
	schedule("hugGround("@%this@");", 2, %this);
}

function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	%name = GameBase::getDataName(%this);
	GameBase::setRechargeRate(%this, 0);
	GameBase::setMapName (%this, "Vehicle");
	if (%name == Abrams || %name == Bradley || %name == Humvee) {
		if($Server::FuzzyPhysics)
			schedule("hugGround("@%this@");", 2, %this);
	}

	$VehicleCurWeapon[%this] = 0;
	for(%i = 0; %i < $VehiclePrimaryGuns[%name]; %i++)
	{
		%weapName = $VehicleWeapon[%name, %i];
		$VehicleWeaponAmmo[%this, %weapName] = $VehicleWeaponAmmoMax[%name, %weapName];
	}
	$VehicleCanFire[%this] = True;
}

function Vehicle::onCollision (%this, %object)
{
	%client = Player::getClient(%object);
	if(GameBase::getDataName(%this) == TOWMissile) {
		Vehicle::onDismount(%this, "0 0 0");
		return;
	}
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
			{
            if( Player::isAiControlled(%object) )
               return;
               
				%armor = Player::getArmor(%object);
				// PATCH
				if ((%armor != "larmor" && %armor != "lfemale") && (GameBase::getDataName(%this) == Apache || GameBase::getDataName(%this) == Warthog)) {
					Client::sendMessage(Player::getClient(%object),0,"You must be a pilot to control the vehicles.~wError_Message.wav");
					return;
				}
				// END PATCH
				if ((%armor == "larmor" || %armor == "lfemale") && Vehicle::canMount (%this, %object))
					{
						// DELTAFORCE
						if(Player::getItemCount(%object, Flag) > 0)
							Player::dropItem(%object, Flag);

						if(GameBase::getDataName(%this) == Warthog) {
							%hog = newObject("","Flier","MoveWarthog", true);
							addToSet("MissionCleanup", %hog);
							GameBase::setPosition(%hog, GameBase::getPosition(%this));
							GameBase::setRotation(%hog, GameBase::getRotation(%this));
							GameBase::setDamageLevel(%hog, GameBase::getDamageLevel(%this));
							GameBase::setTeam(%hog, GameBase::getTeam(%this));
							for(%i = 0; %i < $VehiclePrimaryGuns[Warthog]; %i++)
							{
								%weapName = $VehicleWeapon[Warthog, %i];
								$VehicleWeaponAmmo[%hog, %weapName] = $VehicleWeaponAmmo[%this, %weapName];
							}
							deleteObject(%this);
							%this = %hog;
						}
						// END DELTAFORCE
						%weapon = Player::getMountedItem(%object,$WeaponSlot);
						if(%weapon != -1) {
							%object.lastWeapon = %weapon;
							Player::unMountItem(%object,$WeaponSlot);
						}
						Player::setMountObject(%object, %this, 1);
				      Client::setControlObject(%client, %this);
						// Driving test code
						%vName = GameBase::getDataName(%this);
						$SFdrivingAPC[%client] = 1;	
						if((!$Server::FuzzyPhysics) && 
						(%vName == Abrams || %vName == Bradley || %vname == Humvee))
						{
							%tRot = GameBase::getRotation(%this);
							vehicleHover(%this, %client, getWord(%tRot, 2), getWord(%tRot, 1));
						} else if(%vName == MoveWarthog || %vName == Apache)
						{
							%weapName = $VehicleWeapon[%vName, $VehicleCurWeapon[%this]];
							%newEner = $VehicleWeaponAmmo[%this, %weapName] / $VehicleWeaponAmmoMax[%vName, %weapName] * 100;
							GameBase::setEnergy(%this, %newEner);
						}
						// END Driving test code
						playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
						%object.driver= 1;
		            %object.vehicle = %this;
						%this.clLastMount = %client;
					}
				else if((GameBase::getDataName(%this) != Scout) || (GameBase::getDataName(%this) != Apache) || (GameBase::getDataName(%this) != MoveWarthog)) 
					{
						//if (%armor == "aarmor") {
						//	Client::sendMessage(Player::getClient(%object),0,"Artillery cannot ride in vehicles.~wError_Message.wav");
						//	return;
						//}
					 	%mountSlot= Vehicle::findEmptySeat(%this,%client); 
						if(%mountSlot) 
							{
								%object.vehicleSlot = %mountSlot;
								//FOR DEBUGGING PURPOSES
								//echo("MSG: You have entered mountSlot ",%mountSlot,".");
								// END DEBUG
								%object.vehicle = %this;
								Player::setMountObject(%object, %this, %mountSlot);
								playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
								// DELTA FORCE
								$PassengerSlot[%this, %mountSlot] = %client;
								if(Gamebase::getDataName(%this) == Blackhawk) {
									Player::setItemCount(%client,MinigunAmmo,$VehicleAmmo[%this, Minigun]);
									Player::setItemCount(%client,Minigun,1);
									Player::useItem(%client,Minigun);
								} else if(Gamebase::getDataName(%this) == Abrams) {
									if (%mountSlot == 2) {
										Player::setItemCount(%client,AbramsAmmo,$VehicleAmmo[%this, AbramsGun]);
										Player::setItemCount(%client,AbramsGun,1);
										Player::useItem(%client,AbramsGun);
									} else {
										Player::setItemCount(%client,MinigunAmmo,$VehicleAmmo[%this, Minigun]);
										Player::setItemCount(%client,Minigun,1);
										Player::useItem(%client,Minigun);
									}
								} else if (Gamebase::getDataName(%this) == Humvee) {
									if (%mountSlot == 2) {
										Player::setItemCount(%client,TOWAmmo,$VehicleAmmo[%this, TOW]);
										Player::setItemCount(%client,TOW,1);
										Player::useItem(%client,TOW);
									} else {
										Player::setItemCount(%client,AutoGrenAmmo,$VehicleAmmo[%this, AutoGrenLauncher]);
										Player::setItemCount(%client,AutoGrenLauncher,1);
										Player::useItem(%client,AutoGrenLauncher);
									}
								}							
								// END DELTA FORCE
							}
					}
				else if (GameBase::getControlClient(%this) == -1)
					Client::sendMessage(Player::getClient(%object),0,"You must be a pilot to control the vehicles.~wError_Message.wav");
			}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{
	%dataName = GameBase::getDataName(%this);

	if(%dataName == Bradley)
		%numSlots = 4;
	else if(%dataName == Warthog || %dataName == MoveWarthog)
		%numSlots = 0;
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
	if(%armor == "larmor" || %armor == "lfemale" || %armor == "sarmor" || %armor == "sfemale" || %armor == "carmor" || %armor == "cfemale" || %armor == "parmor" || %armor == "pfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale" || %armor == "iarmor" || %armor == "ifemale" || %armor == "earmor" || %armor == "efemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor" || %armor == "aarmor") {
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
		//DELTAFORCE
		if(GameBase::getDataName(%this) == Humvee) {
			if(%passenger.vehicleSlot == 2) {
				$VehicleAmmo[%this, TOW] = Player::getItemCount(%client, TOWAmmo);
			} else if(%passenger.vehicleSlot == 3) {
				$VehicleAmmo[%this, AutoGrenLauncher] = Player::getItemCount(%client, AutoGrenAmmo);
			}
		} else if(GameBase::getDataName(%this) == Abrams) {
			if(%passenger.vehicleSlot == 2) {
				$VehicleAmmo[%this, AbramsGun] = Player::getItemCount(%client, AbramsAmmo);
			} else if(%passenger.vehicleSlot == 3) {
				$VehicleAmmo[%this, Minigun] = Player::getItemCount(%client, MinigunAmmo);
			}
		} else if(GameBase::getDataName(%this) == BlackHawk) {
			if(%passenger.vehicleSlot == 2 || %passenger.vehicleSlot == 3)
				$VehicleAmmo[%this, Minigun] = Player::getItemCount(%client, MinigunAmmo);
		}
		$PassengerSlot[%this, %passenger.vehicleSlot] = 0;
		// END DELTAFORCE
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
		Client::sendMessage(Player::getClient(%passenger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
	
	// DELTA FORCE
	Player::setItemCount(%passenger,Minigun,0);
	Player::setItemCount(%passenger,MinigunAmmo,0);
	Player::setItemCount(%passenger,AbramsGun,0);
	Player::setItemCount(%passenger,AbramsAmmo,0);
	Player::setItemCount(%passenger,TOW,0);
	Player::setItemCount(%passenger,TOWAmmo,0);
	Player::setItemCount(%passenger,AutoGrenLauncher,0);
	Player::setItemCount(%passenger,AutoGrenAmmo,0);
	Player::useItem(%passenger, %passenger.lastWeapon);
	// END DELTA FORCE
}

function Vehicle::jump(%this,%mom)
{
   if(GameBase::getDataName(%this) == TOWMissile) 
   {
	%cl = GameBase::getControlClient(%this);
	remoteEval(%cl, BP, "<jc><f0>TOW Missile Remotely Detonated", 4);
   }
   Vehicle::dismount(%this,%mom);
}

function Vehicle::dismount(%this,%mom)
{
   %cl = GameBase::getControlClient(%this);
   if(GameBase::getDataName(%this) == TOWMissile) {
	if(%cl != -1) Client::setControlObject(%cl, Client::getOwnedObject(%cl));
	GameBase::setDamageLevel(%this, 0.1);
	return;
   }
   if(%cl != -1)
   {
      %pl = Client::getOwnedObject(%cl);
      if(getObjectType(%pl) == "Player")
      {
	   // dismount the player	  
		if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) 
		{
			$SFdrivingAPC[%cl] = 0;
			%pl.lastMount = %this;
			%pl.newMountTime = getSimTime() + 3.0;
			Player::setMountObject(%pl, %this, 0);
        		Player::setMountObject(%pl, -1, 0);
			%rot = GameBase::getRotation(%this);
			%rotZ = getWord(%rot,2);
			GameBase::setRotation(%pl, "0 0 " @ %rotZ);
			Player::applyImpulse(%pl,%mom);
        		Client::setControlObject(%cl, %pl);
			//if(GameBase::getDataName(%this) == Warthog) {
			//	%this.minSpeed = 0;
			//}
			playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
			if(%pl.lastWeapon != "") {
				Player::useItem(%pl,%pl.lastWeapon);		 	
				%pl.lastWeapon = "";
      		}
			%pl.driver = "";
			%pl.vehicle = "";
			// DELTAFORCE
			if(GameBase::getDataName(%this) == MoveWarthog) {
				%pos = GameBase::getPosition(%this);
				%rot = GameBase::getRotation(%this);
				%dam = GameBase::getDamageLevel(%this);
				%hTeam = GameBase::getTeam(%this);
				for(%i = 0; %i < $VehiclePrimaryGuns[MoveWarthog]; %i++)
				{
					%weapName = $VehicleWeapon[MoveWarthog, %i];
					$ammoTemp[%i] = $VehicleWeaponAmmo[%this, %weapName];
				}
				%zPos = getWord(%pos, 2);
				%zPos -= 1000;
				GameBase::setPosition(%this, getWord(%pos, 0) @ " " @ getWord(%pos, 1) @ " " @ %zPos);
				schedule("deleteObject("@%this@");", 0.05);
				%hog = newObject("","Flier","Warthog", true);
				addToSet("MissionCleanup", %hog);
				GameBase::setPosition(%hog, %pos);
				GameBase::setRotation(%hog, %rot);
				GameBase::setDamageLevel(%hog, %dam);
				GameBase::setTeam(%hog, %hTeam);
				for(%i = 0; %i < $VehiclePrimaryGuns[Warthog]; %i++)
				{
					%weapName = $VehicleWeapon[Warthog, %i];
					$VehicleWeaponAmmo[%hog, %weapName] = $ammoTemp[%i];
					$ammoTemp[%i] = 0;
				}
			}
			// END DELTAFORCE
			Player::setItemCount(%pl,Minigun,0);
			Player::setItemCount(%pl,MinigunAmmo,0);
			Player::setItemCount(%pl,AbramsGun,0);
			Player::setItemCount(%pl,AbramsAmmo,0);
			Player::setItemCount(%pl,TOW,0);
			Player::setItemCount(%pl,TOWAmmo,0);
			Player::setItemCount(%pl,AutoGrenLauncher,0);
			Player::setItemCount(%pl,AutoGrenAmmo,0);
		} else Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
	}	
   }
}

function Vehicle::onDestroyed (%this,%mom)
{
//	if($testcheats || $servercheats)
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;

   %cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	if(GameBase::getDataName(%this) == TOWMissile) {
		Client::setControlObject(%cl, %pl);
		calcRadiusDamage(%this, $MissileDamageType, 100, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100);
		return;
	}
	if(%pl != -1) {
	   Player::setMountObject(%pl, -1, 0);
   	Client::setControlObject(%cl, %pl);
	$SFdrivingAPC[%cl] = 0;
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
			// DELTA FORCE
			Player::setItemCount(%pl,Minigun,0);
			Player::setItemCount(%pl,MinigunAmmo,0);
			Player::setItemCount(%pl,AbramsGun,0);
			Player::setItemCount(%pl,AbramsAmmo,0);
			Player::setItemCount(%pl,TOW,0);
			Player::setItemCount(%pl,TOWAmmo,0);
			Player::setItemCount(%pl,AutoGrenLauncher,0);
			Player::setItemCount(%pl,AutoGrenAmmo,0);
			Player::useItem(%pl, %pl.lastWeapon);
			// END DELTA FORCE			
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

// Thanks to Hosed for use of this code...
function vehicleHover(%vehicle, %clientId, %changeZRot, %changeYRot)
{
	// Global var. True if driving vehicle. False if not. 
	if($SFdrivingAPC[%clientId])  
	{
		%refX1 = "-0.393 0 0";
		%refX2 = "-0.393 0 1.571";
		%refX3 = "-0.786 0 0";
		%refX4 = "-0.786 0 1.571";

		%refY2 = "-0.393 0 0.786";
		%refY1 = "-0.393 0 -0.786";
		%refY4 = "-0.786 0 0.786";
		%refY3 = "-0.786 0 -0.786";
		
		%refHeight = "-1.575 0 0";

		//Temp set Rotations
		%OldRot = GameBase::getRotation(%vehicle);
		%NewXRot = getword(%OldRot, 0);
		%NewYRot = getword(%OldRot, 1);
		%changeInZ = %changeYRot - %NewYRot;
		%changeInZ = %changeInZ * 3;
		//if(($modVal % 5) == 0) 
		//	echo(%changeInZ);
		//$modVal++;
		%NewZRot = %changeZRot + %changeInZ;
		
		// Front Middle Position
		//----------------------
		if(GameBase::getLOSInfo(%vehicle,20,%refX1))
			%frontMiddlePos = $los::position;
		else
			if(GameBase::getLOSInfo(%vehicle,1000,%refX3))
				%frontMiddlePos = $los::position;
			else
				%frontMiddlePos = "0 0 0";
		
		// Rear Middle Position
		//-----------------------
		if(GameBase::getLOSInfo(%vehicle,20,%refX2))
			%rearMiddlePos = $los::position;
		else
			if(GameBase::getLOSInfo(%vehicle,1000,%refX4))
				%rearMiddlePos = $los::position;
			else
				%rearMiddlePos = "0 0 0";

		// Left Middle Position
		//------------------------
		if(GameBase::getLOSInfo(%vehicle,20,%refY1))
			%leftMiddlePos = $los::position;
		else
			if(GameBase::getLOSInfo(%vehicle,1000,%refY3))
				%leftMiddlePos = $los::position;
			else
				%leftMiddlePos = "0 0 0";

		// Right Middle Position
		//------------------------
		if(GameBase::getLOSInfo(%vehicle,20,%refY2))
			%rightMiddlePos = $los::position;
		else
			if(GameBase::getLOSInfo(%vehicle,1000,%refY4))
				%rightMiddlePos = $los::position;
			else
				%rightMiddlePos = "0 0 0";

		//-------------------
		// X Rotation Stuff
		//-------------------
		// Rear Position
		%rMidX = getword(%rearMiddlePos, 0);
		%rMidY = getword(%rearMiddlePos, 1);
		%rMidZ = getword(%rearMiddlePos, 2);
		// Front Position
		%fMidX = getword(%frontMiddlePos , 0);
		%fMidY = getword(%frontMiddlePos , 1);
		%fMidZ = getword(%frontMiddlePos , 2);
		// X Distance
		%rpos = %rMidX@" "@%rMidY@" 0";
		%fpos = %fMidX@" "@%fMidY@" 0";
		// Find average of both rotations
		// Total Distance
		%totDist = Vector::getDistance(%rpos, %fpos);
		%zDistance = %fMidZ - %rMidZ;
		if(%totDist != 0)
	    	if( %zDistance != 0 )
			{
				%OppAdd = %zDistance/%totDist;
				%NewXRot = inverseTan(%OppAdd);
			}

		//-------------------
		// Y Rotation Stuff
		//-------------------
		// Right Side Position
		%rsMidX = getword(%rightMiddlePos, 0);
		%rsMidY = getword(%rightMiddlePos, 1);
		%rsMidZ = getword(%rightMiddlePos, 2);
		// Left Side Position
		%lsMidX = getword(%leftMiddlePos , 0);
		%lsMidY = getword(%leftMiddlePos , 1);
		%lsMidZ = getword(%leftMiddlePos , 2);
		// Y Distance
		%rsPos = %rsMidX@" "@%rsMidY@" 0";
		%lsPos = %lsMidX@" "@%lsMidY@" 0";
		// Total Distance
		%totDist = Vector::getDistance(%rsPos, %lsPos);
		%zDistance = %lsMidZ - %rsMidZ;
		if(%totDist != 0)
			if( %zDistance != 0 )
			{
				%OppAdd = %zDistance/%totDist;
				%NewYRot = inverseTan(%OppAdd);
			}

		//-------------------
		// Height Stuff
		//-------------------
		if(GameBase::getLOSInfo(%vehicle,20,%refHeight))
		{
			%groundPos = $los::position;
			%vehiclePos = GameBase::getPosition(%vehicle);
			%vehicleX = getword(%vehiclePos, 0);
			%vehicleY = getword(%vehiclePos, 1);
			%vehicleZ = getword(%vehiclePos, 2);
			%groundz = getword(%groundPos, 2);
			%height = %vehicleZ - %groundZ;
			if(%height >= 2.49 || %height <= 2.51)
			{
				%newpos = %vehicleX @ " " @ %vehicleY @ " " @ (%groundZ + 2.5);
				GameBase::setPosition(%vehicle,%newpos);
			}
		}

		//-------------------
		// Set Rotation Stuff
		//-------------------
		// New Rotation
		%NewRot = %NewXRot@" "@%NewYRot@" "@%NewZRot;
		GameBase::setRotation(%vehicle,%NewRot);

		schedule("vehicleHover("@%vehicle@","@%clientId@","@%NewZRot@","@%NewYRot@");",0.05, %vehicle);
	}
}

function inverseTan(%x)
{
	%theta = %x - ((%x*%x*%x)/3) + ((%x*%x*%x*%x*%x)/5);
	return %theta;
}

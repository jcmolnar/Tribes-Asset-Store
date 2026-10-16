// TOP GUN VEHICLES
// ---------------------------------------------

//----------------------------------------------------------------------------
//Hornet, F/A-18
//----------------------------------------------------------------------------

FlierData Hornet
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 10.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 5.0;
   maxPitch = 100.0; //(5) This way we can do many loops in the air without rewinding
   maxSpeed = 77;
   minSpeed = 0;
	lift = 20.0;
	maxAlt = 450;
	maxVertical = 20;
	maxDamage = 3.8;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.5;

	groundDamageScale = 1.0;

	//projectileType = FighterBullet;
	reloadDelay = 0.1;
	repairRate = 0;
	fireSound = shockExplosion;
	damageSound = SoundTankCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 22;
	description = "F/A-18 Hornet";
};

//----------------------------------------------------------------------------
//Tomcat, F-14
//----------------------------------------------------------------------------

FlierData Tomcat
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 10.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 6.0;
   maxPitch = 100.0;//6
   maxSpeed = 73;
   minSpeed = 0;
	lift = 20.0;
	maxAlt = 450;
	maxVertical = 20;
	maxDamage = 3.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.5;

	groundDamageScale = 1.0;

	//projectileType = FighterBullet;
	reloadDelay = 0.1;
	repairRate = 0;
	fireSound = shockExplosion;
	damageSound = SoundTankCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 22;
	description = "F-14A Tomcat";
};

//----------------------------------------------------------------------------
//Falcon, F-16
//----------------------------------------------------------------------------

FlierData Falcon
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 10.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 5.0;
   maxPitch = 100.0; //(5) This way we can do many loops in the air without rewinding
   maxSpeed = 68;
   minSpeed = 0;
	lift = 20.0;
	maxAlt = 450;
	maxVertical = 20;
	maxDamage = 3.8;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.5;

	groundDamageScale = 1.0;

	//projectileType = FighterBullet;
	reloadDelay = 0.1;
	repairRate = 0;
	fireSound = shockExplosion;
	damageSound = SoundTankCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 22;
	description = "F-16 Falcon";
};

//----------------------------------------------------------------------------
//Eagle, F-15
//----------------------------------------------------------------------------

FlierData Eagle
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 10.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 5.0;
   maxPitch = 100.0; //(5) This way we can do many loops in the air without rewinding
   maxSpeed = 75;
   minSpeed = 0;
	lift = 20.0;
	maxAlt = 450;
	maxVertical = 20;
	maxDamage = 3.8;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.5;

	groundDamageScale = 1.0;

	//projectileType = FighterBullet;
	reloadDelay = 0.1;
	repairRate = 0;
	fireSound = shockExplosion;
	damageSound = SoundTankCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 22;
	description = "F-15 Eagle";
};


FlierData Bomber
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
     mass = 20.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 3.0;
   maxPitch = 0.5;
   maxSpeed = 50;
   minSpeed = 0;
	lift = 20.0;
	maxAlt = 500;
	maxVertical = 20;
	maxDamage = 15.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.20;

	groundDamageScale = 1.0;

	//projectileType = BombShell;
	reloadRate = 0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundDryFire;
	reloadDelay = 0.3;
	damageSound = SoundTankCrash;
	visibleToSensor = False;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
	driverPose = 23;
	description = "B-52 Stratofortress";
};

function Bomber::onAdd(%this) 
{
	$VehicleAmmo[%this, TOW] = 4;
	$VehicleAmmo[%this, TOW] = 4;
	$PassengerSlot[%this, 2] = 0;
	$PassengerSlot[%this, 3] = 0;
	Vehicle::onAdd(%this);
}

FlierData Hercules
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
     mass = 19.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.5;
   maxSpeed = 50;
   minSpeed = 0;
	lift = 20.0;
	maxAlt = 500;
	maxVertical = 20;
	maxDamage = 15.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.20;

	groundDamageScale = 1.0;

	//projectileType = BombShell;
	//reloadRate = 0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	//fireSound = SoundFireMortar;
	reloadDelay = 0.3;
	damageSound = SoundTankCrash;
	visibleToSensor = True;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
	driverPose = 23;
	description = "C-130 Hercules";
};

FlierData Warthog
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
     mass = 16.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 0.7;
   maxPitch = 0.7;
   maxSpeed = 45;
   minSpeed = 0;
	lift = 20.0;
	maxAlt = 250;
	maxVertical = 20;
	maxDamage = 7.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.30;

	groundDamageScale = 1.0;

	//projectileType = WarthogBullet;
	//reloadRate = 0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	//fireSound = SoundFireMortar;
	reloadDelay = 0.3;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
	driverPose = 23;
	description = "A-10 Warthog";
};
function Warthog::onFire(%this)
{
	Vehicle::onFire(%this);
}
FlierData MoveWarthog
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 16.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 0.70;           //maxBank = 0.25;
   maxPitch = 0.70;          //maxPitch = 0.25;
   maxSpeed = 45;            //maxSpeed = 45;
   minSpeed = 0;
	lift = 20.0;
	maxAlt = 250;
	maxVertical = 20;
	maxDamage = 7.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.30;   //accel = 0.25;

	groundDamageScale = 1.0;

	//projectileType = WarthogBullet;
	//reloadRate = 0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	//fireSound = SoundFireMortar;
	reloadDelay = 0.15;            //reloadDelay = 0.3;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
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
   maxSpeed = 60;
   minSpeed = 60;
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
	description = "CALCM Cruise Missile";
};

function OutOfCable(%this) 
{
	%cl = GameBase::getControlClient(%this);
	Vehicle::dismount(%this, "0 0 0");
	remoteEval(%cl, BP, "<jc><f0>Cruise Missile is out of range", 4);
}

function TOWMissile::onAdd(%this) 
{
	GameBase::setRechargeRate(%this, -25); // TOW lives for 20 seconds
	schedule("OutOfCable("@%this@");", 20, %this);
	schedule("$TOWDetEnable["@%this@"] = 1;", 0.5, %this);
}

function TOWMissile::onFire(%this)
{
	if ($TOWDetEnable[%this] == 1) {
		%cl = GameBase::getControlClient(%this);
		Vehicle::dismount(%this, "0 0 0");
		remoteEval(%cl, BP, "<jc><f0>Cruise Missile Remotely Detonated", 4);
		$TOWDetEnable[%this] = 0;
	}
}

$DamageScale[Hornet, $ImpactDamageType] = 5.0;
$DamageScale[Hornet, $BulletDamageType] = 0.9;
$DamageScale[Hornet, $PlasmaDamageType] = 1.0;
$DamageScale[Hornet, $EnergyDamageType] = 1.0;
$DamageScale[Hornet, $ExplosionDamageType] = 1.0;
$DamageScale[Hornet, $ShrapnelDamageType] = 1.0;
$DamageScale[Hornet, $DebrisDamageType] = 1.0;
$DamageScale[Hornet, $MissileDamageType] = 2.0;
$DamageScale[Hornet, $LaserDamageType] = 1.0;
$DamageScale[Hornet, $MortarDamageType] = 1.0;
$DamageScale[Hornet, $BlasterDamageType] = 1.0;
$DamageScale[Hornet, $ElectricityDamageType] = 0.01;
$DamageScale[Hornet, $MineDamageType]        = 1.0;
$DamageScale[Hornet, $BleedDamageType] = 0.0;
$DamageScale[Hornet, $GrenadeDamageType] = 0.5;
$DamageScale[Hornet, $PoisonDamageType] = 0.0;
$DamageScale[Hornet, $SmokeDamageType] = 0.0;
$DamageScale[Hornet, $StabDamageType] = 0.0;

$DamageScale[Tomcat, $ImpactDamageType] = 5.0;
$DamageScale[Tomcat, $BulletDamageType] = 0.9;
$DamageScale[Tomcat, $PlasmaDamageType] = 1.0;
$DamageScale[Tomcat, $EnergyDamageType] = 1.0;
$DamageScale[Tomcat, $ExplosionDamageType] = 1.0;
$DamageScale[Tomcat, $ShrapnelDamageType] = 1.0;
$DamageScale[Tomcat, $DebrisDamageType] = 1.0;
$DamageScale[Tomcat, $MissileDamageType] = 2.0;
$DamageScale[Tomcat, $LaserDamageType] = 1.0;
$DamageScale[Tomcat, $MortarDamageType] = 1.0;
$DamageScale[Tomcat, $BlasterDamageType] = 1.0;
$DamageScale[Tomcat, $ElectricityDamageType] = 0.01;
$DamageScale[Tomcat, $MineDamageType]        = 1.0;
$DamageScale[Tomcat, $BleedDamageType] = 0.0;
$DamageScale[Tomcat, $GrenadeDamageType] = 0.5;
$DamageScale[Tomcat, $PoisonDamageType] = 0.0;
$DamageScale[Tomcat, $SmokeDamageType] = 0.0;
$DamageScale[Tomcat, $StabDamageType] = 0.0;

$DamageScale[Falcon, $ImpactDamageType] = 5.0;
$DamageScale[Falcon, $BulletDamageType] = 0.9;
$DamageScale[Falcon, $PlasmaDamageType] = 1.0;
$DamageScale[Falcon, $EnergyDamageType] = 1.0;
$DamageScale[Falcon, $ExplosionDamageType] = 1.0;
$DamageScale[Falcon, $ShrapnelDamageType] = 1.0;
$DamageScale[Falcon, $DebrisDamageType] = 1.0;
$DamageScale[Falcon, $MissileDamageType] = 2.0;
$DamageScale[Falcon, $LaserDamageType] = 1.0;
$DamageScale[Falcon, $MortarDamageType] = 1.0;
$DamageScale[Falcon, $BlasterDamageType] = 1.0;
$DamageScale[Falcon, $ElectricityDamageType] = 0.01;
$DamageScale[Falcon, $MineDamageType]        = 1.0;
$DamageScale[Falcon, $BleedDamageType] = 0.0;
$DamageScale[Falcon, $GrenadeDamageType] = 0.5;
$DamageScale[Falcon, $PoisonDamageType] = 0.0;
$DamageScale[Falcon, $SmokeDamageType] = 0.0;
$DamageScale[Falcon, $StabDamageType] = 0.0;

$DamageScale[Eagle, $ImpactDamageType] = 5.0;
$DamageScale[Eagle, $BulletDamageType] = 0.8;
$DamageScale[Eagle, $PlasmaDamageType] = 1.0;
$DamageScale[Eagle, $EnergyDamageType] = 1.0;
$DamageScale[Eagle, $ExplosionDamageType] = 1.0;
$DamageScale[Eagle, $ShrapnelDamageType] = 1.0;
$DamageScale[Eagle, $DebrisDamageType] = 1.0;
$DamageScale[Eagle, $MissileDamageType] = 2.0;
$DamageScale[Eagle, $LaserDamageType] = 1.0;
$DamageScale[Eagle, $MortarDamageType] = 1.0;
$DamageScale[Eagle, $BlasterDamageType] = 1.0;
$DamageScale[Eagle, $ElectricityDamageType] = 0.01;
$DamageScale[Eagle, $MineDamageType]        = 1.0;
$DamageScale[Eagle, $BleedDamageType] = 0.0;
$DamageScale[Eagle, $GrenadeDamageType] = 0.5;
$DamageScale[Eagle, $PoisonDamageType] = 0.0;
$DamageScale[Eagle, $SmokeDamageType] = 0.0;
$DamageScale[Eagle, $StabDamageType] = 0.0;

$DamageScale[Apache, $ImpactDamageType] = 5.0;
$DamageScale[Apache, $BulletDamageType] = 0.3;
$DamageScale[Apache, $PlasmaDamageType] = 0.05;
$DamageScale[Apache, $EnergyDamageType] = 1.0;
$DamageScale[Apache, $ExplosionDamageType] = 1.0;
$DamageScale[Apache, $ShrapnelDamageType] = 1.0;
$DamageScale[Apache, $DebrisDamageType] = 1.0;
$DamageScale[Apache, $MissileDamageType] = 1.8;
$DamageScale[Apache, $LaserDamageType] = 0.5;
$DamageScale[Apache, $MortarDamageType] = 1.0;
$DamageScale[Apache, $BlasterDamageType] = 0.5;
$DamageScale[Apache, $ElectricityDamageType] = 1.0;
$DamageScale[Apache, $MineDamageType]        = 1.0;
$DamageScale[Apache, $ChargeDamageType]      = 1.0;
$DamageScale[Apache, $AirstrikeDamageType]   = 1.0;
$DamageScale[Apache, $BleedDamageType] = 0.0;
$DamageScale[Apache, $GrenadeDamageType] = 0.5;
$DamageScale[Apache, $PoisonDamageType] = 0.0;
$DamageScale[Apache, $SmokeDamageType] = 0.0;
$DamageScale[Apache, $StabDamageType] = 0.0;

$DamageScale[Hind, $ImpactDamageType] = 3.0;
$DamageScale[Hind, $BulletDamageType] = 0.05;
$DamageScale[Hind, $PlasmaDamageType] = 1.0;
$DamageScale[Hind, $EnergyDamageType] = 1.0;
$DamageScale[Hind, $ExplosionDamageType] = 1.0;
$DamageScale[Hind, $ShrapnelDamageType] = 0.3;
$DamageScale[Hind, $DebrisDamageType] = 0.5;
$DamageScale[Hind, $MissileDamageType] = 1.6;
$DamageScale[Hind, $LaserDamageType] = 0.5;
$DamageScale[Hind, $MortarDamageType] = 1.0;
$DamageScale[Hind, $BlasterDamageType] = 0.5;
$DamageScale[Hind, $ElectricityDamageType] = 1.0;
$DamageScale[Hind, $MineDamageType]        = 1.0;
$DamageScale[Hind, $ChargeDamageType]      = 1.0;
$DamageScale[Hind, $AirstrikeDamageType]   = 1.0;
$DamageScale[Hind, $BleedDamageType] = 0.0;
$DamageScale[Hind, $GrenadeDamageType] = 0.5;
$DamageScale[Hind, $PoisonDamageType] = 0.0;
$DamageScale[Hind, $SmokeDamageType] = 0.0;
$DamageScale[Hind, $StabDamageType] = 0.0;

$DamageScale[Bomber, $ImpactDamageType] = 10.0;
$DamageScale[Bomber, $BulletDamageType] = 0.5;
$DamageScale[Bomber, $PlasmaDamageType] = 1.0;
$DamageScale[Bomber, $EnergyDamageType] = 1.0;
$DamageScale[Bomber, $ExplosionDamageType] = 0.7;
$DamageScale[Bomber, $ShrapnelDamageType] = 0.6;
$DamageScale[Bomber, $DebrisDamageType] = 0.7;
$DamageScale[Bomber, $MissileDamageType] = 2.0;
$DamageScale[Bomber, $LaserDamageType] = 0.3;
$DamageScale[Bomber, $MortarDamageType] = 1.0;
$DamageScale[Bomber, $BlasterDamageType] = 0.5;
$DamageScale[Bomber, $ElectricityDamageType] = 1.0;
$DamageScale[Bomber, $MineDamageType]        = 1.0;
$DamageScale[Bomber, $ChargeDamageType] = 1.0;
$DamageScale[Bomber, $AirstrikeDamageType]   = 1.0;
$DamageScale[Bomber, $BleedDamageType] = 0.0;
$DamageScale[Bomber, $GrenadeDamageType] = 0.5;
$DamageScale[Bomber, $PoisonDamageType] = 0.0;
$DamageScale[Bomber, $SmokeDamageType] = 0.0;
$DamageScale[Bomber, $StabDamageType] = 0.0;

$DamageScale[Hercules, $ImpactDamageType] = 10.0;
$DamageScale[Hercules, $BulletDamageType] = 0.5;
$DamageScale[Hercules, $PlasmaDamageType] = 1.0;
$DamageScale[Hercules, $EnergyDamageType] = 1.0;
$DamageScale[Hercules, $ExplosionDamageType] = 0.7;
$DamageScale[Hercules, $ShrapnelDamageType] = 0.6;
$DamageScale[Hercules, $DebrisDamageType] = 0.7;
$DamageScale[Hercules, $MissileDamageType] = 2.0;
$DamageScale[Hercules, $LaserDamageType] = 0.3;
$DamageScale[Hercules, $MortarDamageType] = 1.0;
$DamageScale[Hercules, $BlasterDamageType] = 0.5;
$DamageScale[Hercules, $ElectricityDamageType] = 1.0;
$DamageScale[Hercules, $MineDamageType]        = 1.0;
$DamageScale[Hercules, $ChargeDamageType] = 1.0;
$DamageScale[Hercules, $AirstrikeDamageType]   = 1.0;
$DamageScale[Hercules, $BleedDamageType] = 0.0;
$DamageScale[Hercules, $GrenadeDamageType] = 0.5;
$DamageScale[Hercules, $PoisonDamageType] = 0.0;
$DamageScale[Hercules, $SmokeDamageType] = 0.0;
$DamageScale[Hercules, $StabDamageType] = 0.0;

$DamageScale[Gunship, $ImpactDamageType] = 10.0;
$DamageScale[Gunship, $BulletDamageType] = 0.5;
$DamageScale[Gunship, $PlasmaDamageType] = 1.0;
$DamageScale[Gunship, $EnergyDamageType] = 1.0;
$DamageScale[Gunship, $ExplosionDamageType] = 0.7;
$DamageScale[Gunship, $ShrapnelDamageType] = 0.6;
$DamageScale[Gunship, $DebrisDamageType] = 0.7;
$DamageScale[Gunship, $MissileDamageType] = 2.0;
$DamageScale[Gunship, $LaserDamageType] = 0.3;
$DamageScale[Gunship, $MortarDamageType] = 1.0;
$DamageScale[Gunship, $BlasterDamageType] = 0.5;
$DamageScale[Gunship, $ElectricityDamageType] = 1.0;
$DamageScale[Gunship, $MineDamageType]        = 1.0;
$DamageScale[Gunship, $ChargeDamageType] = 1.0;
$DamageScale[Gunship, $AirstrikeDamageType]   = 1.0;
$DamageScale[Gunship, $BleedDamageType] = 0.0;
$DamageScale[Gunship, $GrenadeDamageType] = 0.5;
$DamageScale[Gunship, $PoisonDamageType] = 0.0;
$DamageScale[Gunship, $SmokeDamageType] = 0.0;
$DamageScale[Gunship, $StabDamageType] = 0.0;

$DamageScale[Warthog, $ImpactDamageType] = 10.0;
$DamageScale[Warthog, $BulletDamageType] = 0.7;
$DamageScale[Warthog, $PlasmaDamageType] = 1.0;
$DamageScale[Warthog, $EnergyDamageType] = 1.0;
$DamageScale[Warthog, $ExplosionDamageType] = 0.7;
$DamageScale[Warthog, $ShrapnelDamageType] = 0.6;
$DamageScale[Warthog, $DebrisDamageType] = 0.7;
$DamageScale[Warthog, $MissileDamageType] = 2.0;
$DamageScale[Warthog, $LaserDamageType] = 0.3;
$DamageScale[Warthog, $MortarDamageType] = 1.0;
$DamageScale[Warthog, $BlasterDamageType] = 0.5;
$DamageScale[Warthog, $ElectricityDamageType] = 1.0;
$DamageScale[Warthog, $MineDamageType]        = 1.0;
$DamageScale[Warthog, $ChargeDamageType] = 1.0;
$DamageScale[Warthog, $AirstrikeDamageType]   = 1.0;
$DamageScale[Warthog, $BleedDamageType] = 0.0;
$DamageScale[Warthog, $GrenadeDamageType] = 0.5;
$DamageScale[Warthog, $PoisonDamageType] = 0.0;
$DamageScale[Warthog, $SmokeDamageType] = 0.0;
$DamageScale[Warthog, $StabDamageType] = 0.0;

$DamageScale[MoveWarthog, $ImpactDamageType] = 10.0;
$DamageScale[MoveWarthog, $BulletDamageType] = 0.7;
$DamageScale[MoveWarthog, $PlasmaDamageType] = 1.0;
$DamageScale[MoveWarthog, $EnergyDamageType] = 1.0;
$DamageScale[MoveWarthog, $ExplosionDamageType] = 0.7;
$DamageScale[MoveWarthog, $ShrapnelDamageType] = 0.6;
$DamageScale[MoveWarthog, $DebrisDamageType] = 0.7;
$DamageScale[MoveWarthog, $MissileDamageType] = 2.0;
$DamageScale[MoveWarthog, $LaserDamageType] = 0.3;
$DamageScale[MoveWarthog, $MortarDamageType] = 1.0;
$DamageScale[MoveWarthog, $BlasterDamageType] = 0.5;
$DamageScale[MoveWarthog, $ElectricityDamageType] = 1.0;
$DamageScale[MoveWarthog, $MineDamageType]        = 1.0;
$DamageScale[MoveWarthog, $ChargeDamageType] = 1.0;
$DamageScale[MoveWarthog, $AirstrikeDamageType]   = 1.0;
$DamageScale[MoveWarthog, $BleedDamageType] = 0.0;
$DamageScale[MoveWarthog, $GrenadeDamageType] = 0.5;
$DamageScale[MoveWarthog, $PoisonDamageType] = 0.0;
$DamageScale[MoveWarthog, $SmokeDamageType] = 0.0;
$DamageScale[MoveWarthog, $StabDamageType] = 0.0;

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
$DamageScale[TOWMissile, $BleedDamageType] = 0.0;
$DamageScale[TOWMissile, $GrenadeDamageType] = 1.0;
$DamageScale[TOWMissile, $PoisonDamageType] = 0.0;
$DamageScale[TOWMissile, $SmokeDamageType] = 0.0;
$DamageScale[TOWMissile, $StabDamageType] = 0.0;

$DamageScale[Warthog, $ImpactDamageType] = 10.0;
$DamageScale[Warthog, $BulletDamageType] = 0.7;
$DamageScale[Warthog, $PlasmaDamageType] = 1.0;
$DamageScale[Warthog, $EnergyDamageType] = 1.0;
$DamageScale[Warthog, $ExplosionDamageType] = 0.7;
$DamageScale[Warthog, $ShrapnelDamageType] = 0.6;
$DamageScale[Warthog, $DebrisDamageType] = 0.7;
$DamageScale[Warthog, $MissileDamageType] = 2.0;
$DamageScale[Warthog, $LaserDamageType] = 0.3;
$DamageScale[Warthog, $MortarDamageType] = 1.0;
$DamageScale[Warthog, $BlasterDamageType] = 0.5;
$DamageScale[Warthog, $ElectricityDamageType] = 1.0;
$DamageScale[Warthog, $MineDamageType]        = 1.0;
$DamageScale[Warthog, $ChargeDamageType] = 1.0;
$DamageScale[Warthog, $AirstrikeDamageType]   = 1.0;
$DamageScale[Warthog, $BleedDamageType] = 0.0;
$DamageScale[Warthog, $GrenadeDamageType] = 0.5;
$DamageScale[Warthog, $PoisonDamageType] = 0.0;
$DamageScale[Warthog, $SmokeDamageType] = 0.0;
$DamageScale[Warthog, $StabDamageType] = 0.0;

$DamageScale[MoveWarthog, $ImpactDamageType] = 10.0;
$DamageScale[MoveWarthog, $BulletDamageType] = 0.7;
$DamageScale[MoveWarthog, $PlasmaDamageType] = 1.0;
$DamageScale[MoveWarthog, $EnergyDamageType] = 1.0;
$DamageScale[MoveWarthog, $ExplosionDamageType] = 0.7;
$DamageScale[MoveWarthog, $ShrapnelDamageType] = 0.6;
$DamageScale[MoveWarthog, $DebrisDamageType] = 0.7;
$DamageScale[MoveWarthog, $MissileDamageType] = 2.0;
$DamageScale[MoveWarthog, $LaserDamageType] = 0.3;
$DamageScale[MoveWarthog, $MortarDamageType] = 1.0;
$DamageScale[MoveWarthog, $BlasterDamageType] = 0.5;
$DamageScale[MoveWarthog, $ElectricityDamageType] = 1.0;
$DamageScale[MoveWarthog, $MineDamageType]        = 1.0;
$DamageScale[MoveWarthog, $ChargeDamageType] = 1.0;
$DamageScale[MoveWarthog, $AirstrikeDamageType]   = 1.0;
$DamageScale[MoveWarthog, $BleedDamageType] = 0.0;
$DamageScale[MoveWarthog, $GrenadeDamageType] = 0.5;
$DamageScale[MoveWarthog, $PoisonDamageType] = 0.0;
$DamageScale[MoveWarthog, $SmokeDamageType] = 0.0;
$DamageScale[MoveWarthog, $StabDamageType] = 0.0;

$VehicleAmmoType[Bomber, 2] = TOWAmmo;
$VehicleAmmoType[Bomber, 3] = TOWAmmo;

$VehicleReloadRate[TOWAmmo] = 2;
$VehicleReloadRate[AutoGrenAmmo] = 10;
$VehicleReloadRate[AbramsAmmo] = 8;
$VehicleReloadRate[MinigunAmmo] = 80;
$VehicleReloadRate[TwentyFivemmAmmo] = 70;
$VehicleReloadRate[FortymmAmmo] = 50;
$VehicleReloadRate[StingerLauncherAmmo] = 2;
$VehicleReloadRate[MLRSAmmo] = 1;

$VehicleAmmoMax[Bomber, TOWAmmo] = 8;

// ------ Vehicle weapons ------


// WARTHOG
$BombBay[MoveWarthog] = 0;
$VehicleMaxHardPoints[MoveWarthog] = 11;
$VehiclePrimaryGuns[MoveWarthog] = 4;
$VehicleWeapon[MoveWarthog, 0] = WarthogBullet;
$VehicleWeapon[MoveWarthog, 1] = StingerMissile;
$VehicleWeapon[MoveWarthog, 2] = ApacheRocket;
$VehicleWeapon[MoveWarthog, 3] = BigBomb;

$VehicleWeaponAmmoMax[MoveWarthog, WarthogBullet] = 500;
$VehicleWeaponAmmoMax[MoveWarthog, StingerMissile] = 5;
$VehicleWeaponAmmoMax[MoveWarthog, ApacheRocket] = 4;
$VehicleWeaponAmmoMax[MoveWarthog, BigBomb] = 1;

$VehicleWeapFireDelay[MoveWarthog, WarthogBullet] = 0.2;
$VehicleWeapFireDelay[MoveWarthog, StingerMissile] = 1.0;
$VehicleWeapFireDelay[MoveWarthog, ApacheRocket] = 0.5;
$VehicleWeapFireDelay[MoveWarthog, BigBomb] = 1.0;

$BombBay[Warthog] = 0;
$VehicleMaxHardPoints[Warthog] = 11;
$VehiclePrimaryGuns[Warthog] = 4;
$VehicleWeapon[Warthog, 0] = WarthogBullet;
$VehicleWeapon[Warthog, 1] = StingerMissile;
$VehicleWeapon[Warthog, 2] = ApacheRocket;
$VehicleWeapon[Warthog, 3] = BigBomb;

$VehicleWeaponAmmoMax[Warthog, WarthogBullet] = 600;
$VehicleWeaponAmmoMax[Warthog, StingerMissile] = 2;
$VehicleWeaponAmmoMax[Warthog, ApacheRocket] = 5;
$VehicleWeaponAmmoMax[Warthog, BigBomb] = 4;

$VehicleWeapFireDelay[Warthog, WarthogBullet] = 0.2;
$VehicleWeapFireDelay[Warthog, StingerMissile] = 1.0;
$VehicleWeapFireDelay[Warthog, ApacheRocket] = 0.5;
$VehicleWeapFireDelay[Warthog, BigBomb] = 1.0;

// HORNET
$BombBay[Hornet] = 0;
$VehicleMaxHardPoints[Hornet] = 7;
$VehiclePrimaryGuns[Hornet] = 4;
$VehicleWeapon[Hornet, 0] = SAWBullet;
$VehicleWeapon[Hornet, 1] = StingerMissile;
$VehicleWeapon[Hornet, 2] = ApacheRocket;
$VehicleWeapon[Hornet, 3] = BigBomb;

$VehicleWeaponAmmoMax[Hornet, SAWBullet] = 500;
$VehicleWeaponAmmoMax[Hornet, StingerMissile] = 5;
$VehicleWeaponAmmoMax[Hornet, ApacheRocket] = 4;
$VehicleWeaponAmmoMax[Hornet, BigBomb] = 1;

$VehicleWeapFireDelay[Hornet, SAWBullet] = 0.02;
$VehicleWeapFireDelay[Hornet, StingerMissile] = 1.0;
$VehicleWeapFireDelay[Hornet, ApacheRocket] = 0.5;
$VehicleWeapFireDelay[Hornet, BigBomb] = 1.0;


// TOMCAT
$BombBay[Tomcat] = 0;
$VehicleMaxHardPoints[Tomcat] = 7;
$VehiclePrimaryGuns[Tomcat] = 4;
$VehicleWeapon[Tomcat, 0] = SAWBullet;
$VehicleWeapon[Tomcat, 1] = PhoenixMissile;
$VehicleWeapon[Tomcat, 2] = SparrowMissile;
$VehicleWeapon[Tomcat, 3] = StingerMissile;

$VehicleWeaponAmmoMax[Tomcat, SAWBullet] = 800;
$VehicleWeaponAmmoMax[Tomcat, PhoenixMissile] = 5;
$VehicleWeaponAmmoMax[Tomcat, SparrowMissile] = 3;
$VehicleWeaponAmmoMax[Tomcat, StingerMissile] = 2;

$VehicleWeapFireDelay[Tomcat, SAWBullet] = 0.02;
$VehicleWeapFireDelay[Tomcat, PhoenixMissile] = 1.0;
$VehicleWeapFireDelay[Tomcat, SparrowMissile] = 1.0;
$VehicleWeapFireDelay[Tomcat, StingerMissile] = 1.0;


// FALCON
$BombBay[Falcon] = 0;
$VehicleMaxHardPoints[Falcon] = 6;
$VehiclePrimaryGuns[Falcon] = 4;
$VehicleWeapon[Falcon, 0] = SAWBullet;
$VehicleWeapon[Falcon, 1] = StingerMissile;
$VehicleWeapon[Falcon, 2] = MaverickRocket;
$VehicleWeapon[Falcon, 3] = AMRAAMMissile;

$VehicleWeaponAmmoMax[Falcon, SAWBullet] = 500;
$VehicleWeaponAmmoMax[Falcon, StingerMissile] = 4;
$VehicleWeaponAmmoMax[Falcon, MaverickRocket] = 2;
$VehicleWeaponAmmoMax[Falcon, AMRAAMMissile] = 4;

$VehicleWeapFireDelay[Falcon, SAWBullet] = 0.02;
$VehicleWeapFireDelay[Falcon, StingerMissile] = 1.0;
$VehicleWeapFireDelay[Falcon, MaverickRocket] = 1.0;
$VehicleWeapFireDelay[Falcon, AMRAAMMissile] = 1.0;


// EAGLE
$BombBay[Eagle] = 0;
$VehicleMaxHardPoints[Eagle] = 6;
$VehiclePrimaryGuns[Eagle] = 4;
$VehicleWeapon[Eagle, 0] = SAWBullet;
$VehicleWeapon[Eagle, 1] = StingerMissile;
$VehicleWeapon[Eagle, 2] = SparrowMissile;
$VehicleWeapon[Eagle, 3] = AMRAAMMissile;

$VehicleWeaponAmmoMax[Eagle, SAWBullet] = 940;
$VehicleWeaponAmmoMax[Eagle, StingerMissile] = 4;
$VehicleWeaponAmmoMax[Eagle, SparrowMissile] = 2;
$VehicleWeaponAmmoMax[Eagle, AMRAAMMissile] = 4;

$VehicleWeapFireDelay[Eagle, SAWBullet] = 0.02;
$VehicleWeapFireDelay[Eagle, StingerMissile] = 1.0;
$VehicleWeapFireDelay[Eagle, SparrowMissile] = 1.0;
$VehicleWeapFireDelay[Eagle, AMRAAMMissile] = 1.0;


// BOMBER
$BombBay[Bomber] = 0;
$VehicleMaxHardPoints[Bomber] = 0;
$VehiclePrimaryGuns[Bomber] = 2;
$VehicleWeapon[Bomber, 0] = BigBomb;
$VehicleWeapon[Bomber, 1] = ClusterBomb;

$VehicleWeaponAmmoMax[Bomber, BigBomb] = 15;
$VehicleWeaponAmmoMax[Bomber, ClusterBomb] = 5;

$VehicleWeapFireDelay[Bomber, BigBomb] = 1.0;
$VehicleWeapFireDelay[Bomber, ClusterBomb] = 1.0;
// GENERAL WEAP DESCRIPTIONS

$WeaponDesc[SAWBullet] = "M61 Vulcan";
$WeaponDesc[WarthogBullet] = "30mm Cannon";
$WeaponDesc[ApacheRocket] = "AGM-88A HARM Missile";
$WeaponDesc[MaverickRocket] = "AGM-65 Maverick Missile";
$WeaponDesc[StingerMissile] = "AIM-9 Sidewinder Missile";
$WeaponDesc[SparrowMissile] = "AIM-7 Sparrow Missile";
$WeaponDesc[PhoenixMissile] = "AIM-54 Phoenix Missile";
$WeaponDesc[AMRAAMMissile] = "AIM-120 AMRAAM Missile";
$WeaponDesc[BigBomb] = "Mk82 Bomb";
$WeaponDesc[ClusterBomb] = "CBU-87 ClusterBomb";

$WeaponReloadRate[SAWBullet] = 14;
$WeaponReloadRate[WarthogBullet] = 20;
$WeaponReloadRate[ApacheRocket] = 5;
$WeaponReloadRate[MaverickRocket] = 5;
$WeaponReloadRate[StingerMissile] = 5;
$WeaponReloadRate[SparrowMissile] = 5;
$WeaponReloadRate[PhoenixMissile] = 5;
$WeaponReloadRate[AMRAAMMissile] = 5;
$WeaponReloadRate[BigBomb] = 1;
$WeaponReloadRate[ClusterBomb] = 1;

$WeaponRequiresLock[SAWBullet] = False;
$WeaponRequiresLock[WarthogBullet] = False;
$WeaponRequiresLock[ApacheRocket] = False;
$WeaponRequiresLock[MaverickRocket] = False;
$WeaponRequiresLock[StingerMissile] = True;
$WeaponRequiresLock[SparrowMissile] = True;
$WeaponRequiresLock[PhoenixMissile] = True;
$WeaponRequiresLock[AMRAAMMissile] = True;
$WeaponRequiresLock[BigBomb] = False;
$WeaponRequiresLock[ClusterBomb] = False;

$WeaponFreeFall[SAWBullet] = False;
$WeaponFreeFall[WarthogBullet] = False;
$WeaponFreeFall[ApacheRocket] = False;
$WeaponFreeFall[MaverickRocket] = False;
$WeaponFreeFall[StingerMissile] = False;
$WeaponFreeFall[SparrowMissile] = False;
$WeaponFreeFall[PhoenixMissile] = False;
$WeaponFreeFall[AMRAAMMissile] = False;
$WeaponFreeFall[BigBomb] = True;
$WeaponFreeFall[ClusterBomb] = True;

$WeaponSound[SAWBullet] = shockExplosion;
$WeaponSound[WarthogBullet] = shockExplosion;
$WeaponSound[ApacheRocket] = SoundFireFlierRocket;
$WeaponSound[MaverickRocket] = SoundFireFlierRocket;
$WeaponSound[StingerMissile] = SoundFireFlierRocket;
$WeaponSound[SparrowMissile] = SoundFireFlierRocket;
$WeaponSound[PhoenixMissile] = SoundFireFlierRocket;
$WeaponSound[AMRAAMMissile] = SoundFireFlierRocket;
$WeaponSound[BigBomb] = shockExplosion;
$WeaponSound[ClusterBomb] = shockExplosion;

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
					if (GameBase::getDataName($los::object) == Hornet || GameBase::getDataName($los::object) == Tomcat || GameBase::getDataName($los::object) == Falcon || GameBase::getDataName($los::object) == Eagle || GameBase::getDataName($los::object) == Bomber || GameBase::getDataName($los::object) == Hercules || GameBase::getDataName($los::object) == Warthog || GameBase::getDataName($los::object) == MoveWarthog)
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

// To keep planes from "bouncing" themselves to death on the runway.
function landingGear(%vehicle, %clientId, %changeZRot, %changeYRot)
{
	%refHeight = "-1.575 0 0";
	%vehicleData = GameBase::getDataName(%vehicle);
	
	// Get the current speed of the vehicle from the velocity vectors
	%velocI = Item::getVelocity(%vehicle); 
	%xvelocI = getword(%velocI, 0);
	%yvelocI = getword(%velocI, 1);
	%zvelocI = getword(%velocI, 2);
	%speedI = sqrt(%xvelocI*%xvelocI + %yvelocI*%yvelocI + %zvelocI*%zvelocI);
	if($SFdrivingAPC[%clientId])  
	{
		if(GameBase::getLOSInfo(%vehicle,20,%refHeight))
		{
			%VgroundPos = $los::position;
			%VvehiclePos = GameBase::getPosition(%vehicle);
			%VvehicleZ = getword(%VvehiclePos, 2);
			%Vgroundz = getword(%VgroundPos, 2);
			%Vheight = %VvehicleZ - %VgroundZ;
		}
	
		if(%Vheight <= 2.51 && %speedI < %vehicleData.maxspeed *0.9 ) // if they are off the ground, or they are going more then half speed, remove landing gear
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
				if(%height <= 2.51)
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
			//GameBase::setRotation(%vehicle,%NewRot);
		
			schedule("landingGear("@%vehicle@","@%clientId@","@%NewZRot@","@%NewYRot@");",0.02, %vehicle);
		} else 	
		{
			schedule("landingGear("@%vehicle@","@%clientId@","@%changeZRot@","@%changeYRot@");",0.02, %vehicle);	
		}

	} 
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
				if ((%armor != "larmor" && %armor != "lfemale") && (GameBase::getDataName(%this) == Hornet || GameBase::getDataName(%this) == Tomcat || GameBase::getDataName(%this) == Falcon || GameBase::getDataName(%this) == Eagle || GameBase::getDataName(%this) == Warthog)) {
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
						if(GameBase::getDataName(%this) == Hornet) {
							%net = newObject("","Flier","Hornet", true);
							addToSet("MissionCleanup", %net);
							GameBase::setPosition(%net, GameBase::getPosition(%this));
							GameBase::setRotation(%net, GameBase::getRotation(%this));
							GameBase::setDamageLevel(%net, GameBase::getDamageLevel(%this));
							GameBase::setTeam(%net, GameBase::getTeam(%this));
							for(%i = 0; %i < $VehiclePrimaryGuns[Hornet]; %i++)
							{
								%weapName = $VehicleWeapon[Hornet, %i];
								$VehicleWeaponAmmo[%net, %weapName] = $VehicleWeaponAmmo[%this, %weapName];
							}
							deleteObject(%this);
							%this = %net;
						}
						if(GameBase::getDataName(%this) == Tomcat) {
							%cat = newObject("","Flier","Tomcat", true);
							addToSet("MissionCleanup", %cat);
							GameBase::setPosition(%cat, GameBase::getPosition(%this));
							GameBase::setRotation(%cat, GameBase::getRotation(%this));
							GameBase::setDamageLevel(%cat, GameBase::getDamageLevel(%this));
							GameBase::setTeam(%cat, GameBase::getTeam(%this));
							for(%i = 0; %i < $VehiclePrimaryGuns[Tomcat]; %i++)
							{
								%weapName = $VehicleWeapon[Tomcat, %i];
								$VehicleWeaponAmmo[%cat, %weapName] = $VehicleWeaponAmmo[%this, %weapName];
							}
							deleteObject(%this);
							%this = %cat;
						}
						if(GameBase::getDataName(%this) == Falcon) {
							%con = newObject("","Flier","Falcon", true);
							addToSet("MissionCleanup", %con);
							GameBase::setPosition(%con, GameBase::getPosition(%this));
							GameBase::setRotation(%con, GameBase::getRotation(%this));
							GameBase::setDamageLevel(%con, GameBase::getDamageLevel(%this));
							GameBase::setTeam(%con, GameBase::getTeam(%this));
							for(%i = 0; %i < $VehiclePrimaryGuns[Falcon]; %i++)
							{
								%weapName = $VehicleWeapon[Falcon, %i];
								$VehicleWeaponAmmo[%con, %weapName] = $VehicleWeaponAmmo[%this, %weapName];
							}
							deleteObject(%this);
							%this = %con;
						}
						if(GameBase::getDataName(%this) == Eagle) {
							%eag = newObject("","Flier","Eagle", true);
							addToSet("MissionCleanup", %eag);
							GameBase::setPosition(%eag, GameBase::getPosition(%this));
							GameBase::setRotation(%eag, GameBase::getRotation(%this));
							GameBase::setDamageLevel(%eag, GameBase::getDamageLevel(%this));
							GameBase::setTeam(%eag, GameBase::getTeam(%this));
							for(%i = 0; %i < $VehiclePrimaryGuns[Eagle]; %i++)
							{
								%weapName = $VehicleWeapon[Eagle, %i];
								$VehicleWeaponAmmo[%eag, %weapName] = $VehicleWeaponAmmo[%this, %weapName];
							}
							deleteObject(%this);
							%this = %eag;
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
				else if((GameBase::getDataName(%this) != Scout) || (GameBase::getDataName(%this) != Hornet) || (GameBase::getDataName(%this) != Tomcat) || (GameBase::getDataName(%this) != Falcon) || (GameBase::getDataName(%this) != Eagle) || (GameBase::getDataName(%this) != MoveWarthog)) 
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
								} else if (Gamebase::getDataName(%this) == Bomber) {
									if (%mountSlot == 2 || %mountSlot == 3){
										Player::setItemCount(%client,TOWAmmo,$VehicleAmmo[%this, TOW]);
										Player::setItemCount(%client,TOW,1);
										Player::useItem(%client,TOW);
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

	if(%dataName == Hercules || %dataName == Bomber)
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

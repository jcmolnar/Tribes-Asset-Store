$VehicleInvList[ScoutVehicle] = 1;
$DataBlockName[ScoutVehicle] = Scout;
$VehicleToItem[Scout] = ScoutVehicle;
$VehicleSlots[Scout] = 0;

function vehicleScout::Initialize()
{
	$TeamItemCount[0 @ ScoutVehicle] = 0;
	$TeamItemCount[1 @ ScoutVehicle] = 0;
	$TeamItemCount[2 @ ScoutVehicle] = 0;
	$TeamItemCount[3 @ ScoutVehicle] = 0;
	$TeamItemCount[4 @ ScoutVehicle] = 0;
	$TeamItemCount[5 @ ScoutVehicle] = 0;
	$TeamItemCount[6 @ ScoutVehicle] = 0;
	$TeamItemCount[7 @ ScoutVehicle] = 0;
}

ItemData ScoutVehicle 
{
	description = "Screaming Eagle";
	className = "Vehicle";
	heading = $InvHead[ihVeh];
	price = 600;
};

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
	maxBank = 1.9;
	maxPitch = 1.9;
	maxSpeed = 295;
	minSpeed = -10;
	lift = 0.95;
	maxAlt = 20000; //30
	maxVertical = 220;
	maxDamage = 0.75;
	damageLevel = {1.0, 1.0};
	maxEnergy = 250;
	accel = 1.5;
	groundDamageScale = 0.5;
	projectileType = ScoutMissile;
	reloadDelay = 0.2;
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
};

function Scout::onPilot(%this, %player)
{
}

function Scout::onUnPilot(%this, %player)
{
}
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
	description = "Rubicant Gunship";
	className = "Vehicle";
	heading = $InvHead[ihVeh];
	price = 800;
};

FlierData Scout 
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "hover_apc_sml";
	shieldShapeName = "shield_large";
	mass = 18.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.5;
	maxPitch = 0.5;
	maxSpeed = 45;
	minSpeed = -3;
	lift = 0.5;
	maxAlt = 20000; //30
	maxVertical = 10;
	maxDamage = 1.4;
	damageLevel = {1.0, 1.0};
	maxEnergy = 200;
	accel = 0.6;
	groundDamageScale = 0.5;
	projectileType = ParticleShot;
	reloadDelay = 0.4;
	repairRate = 0;
	fireSound = SoundPlasmaTurretFire;
	damageSound = SoundTankCrash;
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
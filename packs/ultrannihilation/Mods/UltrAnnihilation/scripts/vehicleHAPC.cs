$VehicleInvList[HAPCVehicle] = 1;
$DataBlockName[HAPCVehicle] = HAPC;
$VehicleToItem[HAPC] = HAPCVehicle;
$VehicleSlots[HAPC] = 4;

function vehicleHAPC::Initialize()
{	$TeamItemCount[0 @ HAPCVehicle] = 0;
	$TeamItemCount[1 @ HAPCVehicle] = 0;
	$TeamItemCount[2 @ HAPCVehicle] = 0;
	$TeamItemCount[3 @ HAPCVehicle] = 0;
	$TeamItemCount[4 @ HAPCVehicle] = 0;
	$TeamItemCount[5 @ HAPCVehicle] = 0;
	$TeamItemCount[6 @ HAPCVehicle] = 0;
	$TeamItemCount[7 @ HAPCVehicle] = 0;
}

ItemData HAPCVehicle 
{	description = "Transport";
	className = "Vehicle";
	heading = $InvHead[ihVeh];
	price = 875;
};

FlierData HAPC
{	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "hover_apc";
	shieldShapeName = "shield_large";
	mass = 18.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.20;
	maxPitch = 0.35;
	maxSpeed = 30;
	minSpeed = -1;
	lift = 0.55;
	maxAlt = 150; //15
	maxVertical = 10;
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
	damageSound = SoundTankCrash;
	visibleToSensor = true; 
	shadowDetailMask = 2;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;
	visibleDriver = true;
	driverPose = 23;
};

function HAPC::onPilot(%this, %player)
{
}

function HAPC::onUnPilot(%this, %player)
{
}
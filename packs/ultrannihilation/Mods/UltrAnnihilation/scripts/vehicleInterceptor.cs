$VehicleInvList[InterceptorVehicle] = 1;
$DataBlockName[InterceptorVehicle] = Interceptor;
$VehicleToItem[Interceptor] = InterceptorVehicle;
$VehicleSlots[Interceptor] = 0;

function vehicleInterceptor::Initialize()
{	$TeamItemCount[0 @ InterceptorVehicle] = 0;
	$TeamItemCount[1 @ InterceptorVehicle] = 0;
	$TeamItemCount[2 @ InterceptorVehicle] = 0;
	$TeamItemCount[3 @ InterceptorVehicle] = 0;
	$TeamItemCount[4 @ InterceptorVehicle] = 0;
	$TeamItemCount[5 @ InterceptorVehicle] = 0;
	$TeamItemCount[6 @ InterceptorVehicle] = 0;
	$TeamItemCount[7 @ InterceptorVehicle] = 0;
}

ItemData InterceptorVehicle 
{	description = "Interceptor";
	className = "Vehicle";
	heading = $InvHead[ihVeh];
	price = 600;
};

FlierData Interceptor 
{	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 9.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.6;
	maxPitch = 0.6;
	maxSpeed = 120;
	minSpeed = -2;
	lift = 0.95;
	maxAlt = 30;
	maxVertical = 19;
	maxDamage = 0.75;
	damageLevel = {1.0, 1.0};
	maxEnergy = 200;
	accel = 1.9;
	groundDamageScale = 0.5;
	projectileType = IonBolt;
	reloadDelay = 0.1;
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

function Interceptor::onPilot(%this, %player)
{
}

function Interceptor::onUnPilot(%this, %player)
{
}
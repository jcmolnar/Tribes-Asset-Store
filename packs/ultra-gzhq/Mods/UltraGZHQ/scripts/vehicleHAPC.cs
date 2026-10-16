$VehicleInvList[HAPCVehicle] = 1;
$DataBlockName[HAPCVehicle] = HAPC;
$VehicleToItem[HAPC] = HAPCVehicle;
$VehicleSlots[HAPC] = 4;

function vehicleHAPC::Initialize()
{
	$TeamItemCount[0 @ HAPCVehicle] = 0;
	$TeamItemCount[1 @ HAPCVehicle] = 0;
	$TeamItemCount[2 @ HAPCVehicle] = 0;
	$TeamItemCount[3 @ HAPCVehicle] = 0;
	$TeamItemCount[4 @ HAPCVehicle] = 0;
	$TeamItemCount[5 @ HAPCVehicle] = 0;
	$TeamItemCount[6 @ HAPCVehicle] = 0;
	$TeamItemCount[7 @ HAPCVehicle] = 0;
}

ItemData HAPCVehicle 
{
	description = "Hell Fire Transporter";
	className = "Vehicle";
	heading = $InvHead[ihVeh];
	price = 875;
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
   maxBank = 1;
   maxPitch = 1;
   maxSpeed = 200;								   
   minSpeed = -1;
	lift = 1;
	maxAlt = 550;
	maxVertical = 6;
	maxDamage = 6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 500;
	accel = 3;

	groundDamageScale = 0.125;
        
                projectileType = fireball;//FlierRocket;
		reloadDelay = 0.03;
	fireSound = Sounddryfire;
        
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	//fireSound = SoundFireFlierRocket;
	//reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 23;
	description = "HPC";
};

function HAPC::onPilot(%this, %player)
{
}

function HAPC::onUnPilot(%this, %player)
{
}
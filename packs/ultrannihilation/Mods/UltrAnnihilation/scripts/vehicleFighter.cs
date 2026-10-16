$VehicleInvList[FighterVehicle] = 1;
$DataBlockName[FighterVehicle] = Fighter;
$VehicleToItem[Fighter] = FighterVehicle;
$VehicleSlots[Fighter] = 0;

function vehicleFighter::Initialize()
{	$TeamItemCount[0 @ FighterVehicle] = 0;
	$TeamItemCount[1 @ FighterVehicle] = 0;
	$TeamItemCount[2 @ FighterVehicle] = 0;
	$TeamItemCount[3 @ FighterVehicle] = 0;
	$TeamItemCount[4 @ FighterVehicle] = 0;
	$TeamItemCount[5 @ FighterVehicle] = 0;
	$TeamItemCount[6 @ FighterVehicle] = 0;
	$TeamItemCount[7 @ FighterVehicle] = 0;
}

ItemData FighterVehicle 
{	description = "Fighter";
	className = "Vehicle";
	heading = $InvHead[ihVeh];
	price = 600;
};

FlierData Fighter 
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
	maxVertical = 20;
	maxDamage = 0.75;
	damageLevel = {1.0, 1.0};
	maxEnergy = 250;
	accel = 1.9;
	groundDamageScale = 0.5;
	projectileType = ScoutMissile;
	reloadDelay = 1;
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

function Fighter::onPilot(%this, %player)
{
}

function Fighter::onUnPilot(%this, %player)
{
}
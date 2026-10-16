$VehicleInvList[LAPCVehicle] = 1;
$DataBlockName[LAPCVehicle] = LAPC;
$VehicleToItem[LAPC] = LAPCVehicle;
$VehicleSlots[LAPC] = 2;

function vehicleLAPC::Initialize()
{
	$TeamItemCount[0 @ LAPCVehicle] = 0;
	$TeamItemCount[1 @ LAPCVehicle] = 0;
	$TeamItemCount[2 @ LAPCVehicle] = 0;
	$TeamItemCount[3 @ LAPCVehicle] = 0;
	$TeamItemCount[4 @ LAPCVehicle] = 0;
	$TeamItemCount[5 @ LAPCVehicle] = 0;
	$TeamItemCount[6 @ LAPCVehicle] = 0;
	$TeamItemCount[7 @ LAPCVehicle] = 0;
}

ItemData LAPCVehicle 
{
	description = "Bomber";
	className = "Vehicle";
	heading = $InvHead[ihVeh];
	price = 675;
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
	maxBank = 0.4;
	maxPitch = 0.4;
	maxSpeed = 70;
	minSpeed = -1;
	lift = 0.5;
	maxAlt = 20;
	maxVertical = 9;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 200;
	accel = 0.5;
	groundDamageScale = 0.50;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	projectileType = MortarShell;
	fireSound = SoundFireMortar;
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
};

function LAPC::onPilot(%this, %player)
{
}

function LAPC::onUnPilot(%this, %player)
{
}

//Player::setMountObject(%object, %this, %mountSlot);
//PlaySound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
//if(Gamebase::getDataName(%this) == LAPC) {
//Player::setItemCount(%client,Vulcan,1);
//Player::useItem(%client,Vulcan);
//}


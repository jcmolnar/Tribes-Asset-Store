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
	description = "LAPC Bomber";
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
	maxBank = 0.5;
	maxPitch = 0.5;
	maxSpeed = 245;
	minSpeed = -3;
	lift = 0.5;
	maxAlt = 20000; //25
	maxVertical = 10;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 200;
	accel = 0.35;
	groundDamageScale = 0.50;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	//projectileType = MortarShell;
	fireSound = SoundFireMortar;
	reloadDelay = 0.5;
	//minGunEnergy = 15;
	//maxGunEnergy = 200;
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
	//%this.shieldStrength = 0.1;
}

function LAPC::onUnPilot(%this, %player)
{
}

function LAPC::onFire(%this)
{		
	if($debug)
		echo("?? EVENT fire LAPC, "@ %this @" control cl# "@ gamebase::getcontrolclient(%this));

	if (%this.refire)
		return;
	
	%energy = GameBase::getEnergy(%this);
	if(%energy < 30)
		return;
	
	GameBase::setEnergy(%this,%energy - 30);
		
	%client = gamebase::getcontrolclient(%this);
	%player = Client::getOwnedObject(%client);
	%trans = GameBase::getMuzzleTransform(%this);
	%vel = Item::getVelocity(%this);
	
	%pos1=getWord(%trans,0);
	%pos2=getWord(%trans,1);
	%pos3=getWord(%trans,2);
	%pos4=getWord(%trans,3);
	%pos5=getWord(%trans,4);
	//%pos6=getWord(%trans,5);
	%pos6 = -0.5;
	%pos7=getWord(%trans,6);
	%pos8=getWord(%trans,7);
	%pos9=getWord(%trans,8);
	%pos10=getWord(%trans,9);
	%pos11=getWord(%trans,10);
	%pos12=getWord(%trans,11);
	
	%trans=%pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11@" "@%pos12;
	
	Projectile::spawnProjectile("BombShell",%trans,%this,%vel);

	%this.refire = true;
	schedule ("" @ %this @ ".refire = false;", 0.25);
}

//Player::setMountObject(%object, %this, %mountSlot);
//PlaySound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
//if(Gamebase::getDataName(%this) == LAPC) {
//Player::setItemCount(%client,Vulcan,1);
//Player::useItem(%client,Vulcan);
//}


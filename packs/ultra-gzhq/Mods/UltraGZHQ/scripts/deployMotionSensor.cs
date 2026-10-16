$InvList[MotionSensorPack] = 1;
$MobileInvList[MotionSensorPack] = 1;
$RemoteInvList[MotionSensorPack] = 1;
AddItem(MotionSensorPack);

$CanAlwaysTeamDestroy[DeployableMotionSensor] = 1;

function deployMotionSensor::Initialize()
{
	$TeamItemCount[0 @ MotionSensorPack] = 0;
	$TeamItemCount[1 @ MotionSensorPack] = 0;
	$TeamItemCount[2 @ MotionSensorPack] = 0;
	$TeamItemCount[3 @ MotionSensorPack] = 0;
	$TeamItemCount[4 @ MotionSensorPack] = 0;
	$TeamItemCount[5 @ MotionSensorPack] = 0;
	$TeamItemCount[6 @ MotionSensorPack] = 0;
	$TeamItemCount[7 @ MotionSensorPack] = 0;
}

ItemImageData MotionSensorPackImage 
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData MotionSensorPack 
{
	description = "Motion Sensor";
	shapeFile = "sensor_small";
	className = "Backpack";
	heading = $InvHead[ihDSe];
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MotionSensorPack::onUse(%player,%item) 
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function MotionSensorPack::onDeploy(%player,%item,%pos) 
{
	if(MotionSensorPack::deployShape(%player,%item)&& !$build) 
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
	}
}

function MotionSensorPack::deployShape(%player,%item) 
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item] && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain" && %obj != "InteriorShape" && GameBase::getDataName($los::object) != "DeployablePlatform") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}
			
	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if(Vector::dot($los::normal,"0 0 1") > 0.6) 
		%rot = "0 0 " @ %zRot;
	else 
	{	if(Vector::dot($los::normal,"0 0 -1") > 0.6) 
			%rot = "3.14159 0 " @ %zRot;
		else 
			%rot = Vector::getRotation($los::normal);
	}
	if(!checkInvDeployArea(%client,$los::position)) 
	{
		return false;
	}
	%mSensor = newObject("","Sensor",DeployableMotionSensor,true);
	NukeList(%mSensor);
	%msensor.cloakable = true;
	addToSet("MissionCleanup", %mSensor);
	GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
	GameBase::setRotation(%mSensor,%rot);
	GameBase::setPosition(%mSensor,$los::position);
	Gamebase::setMapName(%mSensor,"Motion Sensor");
	Client::sendMessage(%client,0,"Motion Sensor deployed");
	playSound(SoundPickupBackpack,$los::position);
	echo("MSG: ",%client," deployed a Motion Sensor");

	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		schedule("replaceSensor("@%mSensor@");",5);
	}	
	
	return true;
}

SensorData DeployableMotionSensor
{
	description = "Motion Sensor";
	className = "DeployableSensor";
	shapeFile = "sensor_small";
	shadowDetailMask = 16;
	visibleToSensor = true;
	validateMaterials = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	//explosionId = DebrisExp;
	damageLevel = {0.8, 1.0};
	maxDamage = 0.4;
	debrisId = defaultDebrisSmall;
	range = 50;
	dopplerVelocity = 1;
	castLOS = false;
	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 4;
	mapIcon = "M_motionSensor";
	damageSkinData = "objectDamageSkins";
};

//--------------------------------------

addToInv(DeployableSensorJammerPack,1,1);

setArmorItemMax(DeployableSensorJammerPack,1,1,1,1,1,1,1, 0, 0,0,0,0);

$TeamItemMax[DeployableSensorJammerPack] = 8;

//--------------------------------------

ItemImageData DeployableSensorJamPackImage
{
	shapeFile = "sensor_jammer";
	mountPoint = 2;
	mountOffset = { 0, 0.03, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData DeployableSensorJammerPack
{
	description = "Sensor Jammer";
	shapeFile = "sensor_jammer";
	className = "Backpack";
   heading = $InvCatDeployables;
	imageType = DeployableSensorJamPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 225;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableSensorJammerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
	}
}

//--------------------------------------

SensorData DeployableSensorJammer
{
	description = "Remote Sensor Jammer";
	className = "DeployableSensor";
	shapeFile = "sensor_jammer";
	shadowDetailMask = 4;
	visibleToSensor = true;
   validateShape = true;
   validateMaterials = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	damageLevel = {0.8, 1.0};
	maxDamage = 0.5;
//	explosionId = DebrisExp;
	debrisId = defaultDebrisSmall;
	range = 80;
	castLOS = true;
	supression = true;
	mapFilter = 4;
	mapIcon = "M_sensorJammer";
};

//--------------------------------------

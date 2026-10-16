//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[DeployableSensorJammerPack] = 1;

$TeamItemMax[DeployableSensorJammerPack] = 20;

$ItemMax[larmor, DeployableSensorJammerPack] = 0;	//Seraph
$ItemMax[lfemale, DeployableSensorJammerPack] = 0;	//Seraph
$ItemMax[earmor, DeployableSensorJammerPack] = 1;	//Slave
$ItemMax[efemale, DeployableSensorJammerPack] = 1;	//Slave
$ItemMax[marmor, DeployableSensorJammerPack] = 0;	//Pawn
$ItemMax[aarmor, DeployableSensorJammerPack] = 0;	//Navigator
$ItemMax[darmor, DeployableSensorJammerPack] = 0;	//Atomizer
$ItemMax[barmor, DeployableSensorJammerPack] = 0;	//Paladin

//function deployBlastWall::Initialize()
//{	
//	$TeamItemCount[0 @ DeployableSensorJammerPack] = 0;
//	$TeamItemCount[1 @ DeployableSensorJammerPack] = 0;
//	$TeamItemCount[2 @ DeployableSensorJammerPack] = 0;
//	$TeamItemCount[3 @ DeployableSensorJammerPack] = 0;
//	$TeamItemCount[4 @ DeployableSensorJammerPack] = 0;
//	$TeamItemCount[5 @ DeployableSensorJammerPack] = 0;
//	$TeamItemCount[6 @ DeployableSensorJammerPack] = 0;
//	$TeamItemCount[7 @ DeployableSensorJammerPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

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
   heading = "iSensors";
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
  	price = 50;
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
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;echo("MSG: ",%client," deployed a Sensor Jammer"); 
	}
}
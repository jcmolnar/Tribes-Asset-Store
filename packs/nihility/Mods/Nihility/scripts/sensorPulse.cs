//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[PulseSensorPack] = 1;

$TeamItemMax[PulseSensorPack] = 20;

$ItemMax[larmor, PulseSensorPack] = 0;	//Seraph
$ItemMax[lfemale, PulseSensorPack] = 0;	//Seraph
$ItemMax[earmor, PulseSensorPack] = 1;	//Slave
$ItemMax[efemale, PulseSensorPack] = 1;	//Slave
$ItemMax[marmor, PulseSensorPack] = 0;	//Pawn
$ItemMax[aarmor, PulseSensorPack] = 0;	//Navigator
$ItemMax[darmor, PulseSensorPack] = 0;	//Atomizer
$ItemMax[barmor, PulseSensorPack] = 0;	//Paladin

//function deployBlastWall::Initialize()
//{	
//	$TeamItemCount[0 @ PulseSensorPack] = 0;
//	$TeamItemCount[1 @ PulseSensorPack] = 0;
//	$TeamItemCount[2 @ PulseSensorPack] = 0;
//	$TeamItemCount[3 @ PulseSensorPack] = 0;
//	$TeamItemCount[4 @ PulseSensorPack] = 0;
//	$TeamItemCount[5 @ PulseSensorPack = 0;
//	$TeamItemCount[6 @ PulseSensorPack] = 0;
//	$TeamItemCount[7 @ PulseSensorPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData PulseSensorPackImage 
{ 
shapeFile = "radar_small"; 
mountPoint = 2; 
mountOffset = { 0, 0, 0.1 }; 
mountRotation = { 1.57, 0, 0 }; 
firstPerson = false; 
}; 

ItemData PulseSensorPack 
{ 
description = "Pulse Sensor"; 
shapeFile = "radar_small"; 
className = "Backpack"; 
   heading = "iSensors";
imageType = PulseSensorPackImage; 
shadowDetailMask = 4; 
mass = 2.0; 
elasticity = 0.2; 
price = 50; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true; 
}; 

function PulseSensorPack::onUse(%player,%item) 
{ 
if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
{ 
Player::mountItem(%player,%item,$BackpackSlot); 
} else 
{ 
Player::deployItem(%player,%item); } 
} 

function PulseSensorPack::onDeploy(%player,%item,%pos) 
{ 
if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) 
{ 
Player::decItemCount(%player,%item); 
$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;echo("MSG: ",%client," deployed a Pulse Sensor");  } 
}

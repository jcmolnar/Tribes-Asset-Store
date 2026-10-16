//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[CameraPack] = 1;

$TeamItemMax[CameraPack] = 20;

$ItemMax[larmor, CameraPack] = 0;	//Seraph
$ItemMax[lfemale, CameraPack] = 0;	//Seraph
$ItemMax[earmor, CameraPack] = 1;	//Slave
$ItemMax[efemale, CameraPack] = 1;	//Slave
$ItemMax[marmor, CameraPack] = 0;	//Pawn
$ItemMax[aarmor, CameraPack] = 0;	//Navigator
$ItemMax[darmor, CameraPack] = 0;	//Atomizer
$ItemMax[barmor, CameraPack] = 0;	//Paladin

//function deployBlastWall::Initialize()
//{	
//	$TeamItemCount[0 @ CameraPack] = 0;
//	$TeamItemCount[1 @ CameraPack] = 0;
//	$TeamItemCount[2 @ CameraPack] = 0;
//	$TeamItemCount[3 @ CameraPack] = 0;
//	$TeamItemCount[4 @ CameraPack] = 0;
//	$TeamItemCount[5 @ CameraPack] = 0;
//	$TeamItemCount[6 @ CameraPack] = 0;
//	$TeamItemCount[7 @ CameraPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData CameraPackImage 
{ 
shapeFile = "camera"; 
mountPoint = 2; 
mountOffset = { 0, -0.1, -0.06 }; 
mountRotation = { 0, 0, 0 }; 
firstPerson = false; 
}; 

ItemData CameraPack 
{ 
description = "Camera"; 
shapeFile = "camera"; 
className = "Backpack"; 
heading = "iSensors"; 
imageType = CameraPackImage; 
shadowDetailMask = 4; 
mass = 2.0; 
elasticity = 0.2; 
price = 50; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true; 
}; 

function CameraPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } 
} 

function CameraPack::onDeploy(%player,%item,%pos) { if (CameraPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } 
} 

function CameraPack::deployShape(%player,%item) 
{ 
%client = Player::getClient(%player); 
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
{ 
if (GameBase::getLOSInfo(%player,10)) 

{ 
%prot = GameBase::getRotation(%player); 
%zRot = getWord(%prot,2); 
if (Vector::dot($los::normal,"0 0 1") > 0.6) 
{ 
%rot = "0 0 " @ %zRot; 
} 
else 
{ 
if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
{ 
%rot = "3.14159 0 " @ %zRot; 
} 
else 
{ 
%rot = Vector::getRotation($los::normal); 
} 
} 
%camera = newObject("Camera","Turret",CameraTurret,true); 
addToSet("MissionCleanup", %camera); 
GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); 
GameBase::setPosition(%camera,$los::position); 
Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); 
Client::sendMessage(%client,0,"Camera deployed"); 
playSound(SoundPickupBackpack,$los::position); 
$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++; 
echo("MSG: ",%client," deployed a Camera"); 
return true; 
 
} else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

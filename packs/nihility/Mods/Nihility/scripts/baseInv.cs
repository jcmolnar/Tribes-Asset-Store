//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[DeployableInvPack] = 1;

$TeamItemMax[DeployableInvPack] = 10;

$ItemMax[larmor, DeployableInvPack] = 0;	//Seraph
$ItemMax[lfemale, DeployableInvPack] = 0;	//Seraph
$ItemMax[earmor, DeployableInvPack] = 1;	//Slave
$ItemMax[efemale, DeployableInvPack] = 1;	//Slave
$ItemMax[marmor, DeployableInvPack] = 0;	//Pawn
$ItemMax[aarmor, DeployableInvPack] = 0;	//Navigator
$ItemMax[darmor, DeployableInvPack] = 0;	//Atomizer
$ItemMax[barmor, DeployableInvPack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ DeployableInvPack] = 0;
//	$TeamItemCount[1 @ DeployableInvPack] = 0;
//	$TeamItemCount[2 @ DeployableInvPack] = 0;
//	$TeamItemCount[3 @ DeployableInvPack] = 0;
//	$TeamItemCount[4 @ DeployableInvPack] = 0;
//	$TeamItemCount[5 @ DeployableInvPack] = 0;
//	$TeamItemCount[6 @ DeployableInvPack] = 0;
//	$TeamItemCount[7 @ DeployableInvPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData DeployableInvPackImage 
{ 
shapeFile = "invent_remote"; 
mountPoint = 2; 
mountOffset = { 0, -0.12, -0.3 }; 
mountRotation = { 0, 0, 0 }; 
mass = 2.5; 
firstPerson = false; 
}; 


ItemData DeployableInvPack 
{ 
description = "Inventory Station"; 
shapeFile = "invent_remote"; 
className = "Backpack"; 
heading = "hDeployable Base Objects"; 
shadowDetailMask = 4 ; 
imageType = DeployableInvPackImage; 
mass = 2.0; 
elasticity = 0.2; 
price = 5000; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true; 
}; 

function DeployableInvPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } 
} 
function DeployableInvPack::onDeploy(%player,%item,%pos) { if (DeployableInvPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } 
} 
function DeployableInvPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = "SimTerrain" ; if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") { if (Vector::dot($los::normal,"0 0 1") > 0.7)  { %inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true); addToSet("MissionCleanup", %inv); %rot = GameBase::getRotation(%player); GameBase::setTeam(%inv,GameBase::getTeam(%player)); GameBase::setPosition(%inv,$los::position); GameBase::setRotation(%inv,%rot); Gamebase::setMapName(%inv,%name); Client::sendMessage(%client,0,"Inventory Station deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++; echo("MSG: ",%client," deployed an Inventory Station"); return true;  } else { Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

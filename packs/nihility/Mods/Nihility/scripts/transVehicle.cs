//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

//$InvList[DeployablevhclPack] = 1;

$TeamItemMax[DeployablevhclPack] = 5;

$ItemMax[larmor, DeployablevhclPack] = 0;	//Seraph
$ItemMax[lfemale, DeployablevhclPack] = 0;	//Seraph
$ItemMax[earmor, DeployablevhclPack] = 1;	//Slave
$ItemMax[efemale, DeployablevhclPack] = 1;	//Slave
$ItemMax[marmor, DeployablevhclPack] = 0;	//Pawn
$ItemMax[aarmor, DeployablevhclPack] = 0;	//Navigator
$ItemMax[darmor, DeployablevhclPack] = 0;	//Atomizer
$ItemMax[barmor, DeployablevhclPack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ DeployablevhclPack] = 0;
//	$TeamItemCount[1 @ DeployablevhclPack] = 0;
//	$TeamItemCount[2 @ DeployablevhclPack] = 0;
//	$TeamItemCount[3 @ DeployablevhclPack] = 0;
//	$TeamItemCount[4 @ DeployablevhclPack] = 0;
//	$TeamItemCount[5 @ DeployablevhclPack] = 0;
//	$TeamItemCount[6 @ DeployablevhclPack] = 0;
//	$TeamItemCount[7 @ DeployablevhclPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData DeployablevhclPackImage 
{ 
shapeFile = "invent_remote"; 
mountPoint = 2; 
mountOffset = { 0, -0.12, -0.3 }; 
mountRotation = { 0, 0, 0 }; 
mass = 2.5; 
firstPerson = false; 
}; 

ItemData DeployablevhclPack 
{ 
description = "Vehicle Station"; 
shapeFile = "invent_remote"; 
className = "Backpack"; 
heading = "jTransportation"; 
shadowDetailMask = 4 ; 
imageType = DeployableInvPackImage; 
mass = 2.0; 
elasticity = 0.2; 
price = 6000; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true; 
}; 

function DeployablevhclPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } 
} 
function DeployablevhclPack::onDeploy(%player,%item,%pos) { if (DeployablevhclPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } 
} 
function DeployablevhclPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = "SimTerrain" ; if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") { if (Vector::dot($los::normal,"0 0 1") > 0.7)  { %inv = newObject("ammounit_remote","StaticShape","DeployablevhclStation",true); addToSet("MissionCleanup", %inv); %rot = GameBase::getRotation(%player); GameBase::setTeam(%inv,GameBase::getTeam(%player)); GameBase::setPosition(%inv,$los::position); GameBase::setRotation(%inv,%rot); Gamebase::setMapName(%inv,%name); Client::sendMessage(%client,0,"Vehicle Station deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%inv) @ "DeployablevhclPack"]++; echo("MSG: ",%client," deployed a Vehicle Station"); return true;  } else { Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

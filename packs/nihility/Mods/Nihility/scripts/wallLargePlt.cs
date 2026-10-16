//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[LrgPltPack] = 1;

$TeamItemMax[LrgPltPack] = 30;

$ItemMax[larmor, LrgPltPack] = 0;	//Seraph
$ItemMax[lfemale, LrgPltPack] = 0;	//Seraph
$ItemMax[earmor, LrgPltPack] = 1;	//Slave
$ItemMax[efemale, LrgPltPack] = 1;	//Slave
$ItemMax[marmor, LrgPltPack] = 0;	//Pawn
$ItemMax[aarmor, LrgPltPack] = 0;	//Navigator
$ItemMax[darmor, LrgPltPack] = 0;	//Atomizer
$ItemMax[barmor, LrgPltPack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ LrgPltPack] = 0;
//	$TeamItemCount[1 @ LrgPltPack] = 0;
//	$TeamItemCount[2 @ LrgPltPack] = 0;
//	$TeamItemCount[3 @ LrgPltPack] = 0;
//	$TeamItemCount[4 @ LrgPltPack] = 0;
//	$TeamItemCount[5 @ LrgPltPack] = 0;
//	$TeamItemCount[6 @ LrgPltPack] = 0;
//	$TeamItemCount[7 @ LrgPltPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData LrgPltPackImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData LrgPltPack 
{ 
description = "Large Platform"; 
shapeFile = "AmmoPack"; 
className = "Backpack"; 
heading = "nDoors - Walls - Platforms"; 
imageType = LrgPltPackImage; 
shadowDetailMask = 4; 
mass = 1.5; 
elasticity = 0.2; 
price = 50; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true; 
}; 

function LrgPltPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function LrgPltPack::onDeploy(%player,%item,%pos) { if (LrgPltPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } 

function LrgPltPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = "SimTerrain" ; if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform" || %obj == "StaticShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"LargePlatform",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { %rot = GameBase::getRotation(%player); %phase = newObject("","StaticShape",LargePlatform,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"LargePlatform"); Client::sendMessage(%client,0,"Large Platform Deployed"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "LrgPltPack"]++; echo("MSG: ",%client," deployed a Large Platform");   return true;  } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[SpringPack] = 1;

$TeamItemMax[SpringPack] = 5;

$ItemMax[larmor, SpringPack] = 0;	//Seraph
$ItemMax[lfemale, SpringPack] = 0;	//Seraph
$ItemMax[earmor, SpringPack] = 1;	//Slave
$ItemMax[efemale, SpringPack] = 1;	//Slave
$ItemMax[marmor, SpringPack] = 0;	//Pawn
$ItemMax[aarmor, SpringPack] = 0;	//Navigator
$ItemMax[darmor, SpringPack] = 0;	//Atomizer
$ItemMax[barmor, SpringPack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ SpringPack] = 0;
//	$TeamItemCount[1 @ SpringPack] = 0;
//	$TeamItemCount[2 @ SpringPack] = 0;
//	$TeamItemCount[3 @ SpringPack] = 0;
//	$TeamItemCount[4 @ SpringPack] = 0;
//	$TeamItemCount[5 @ SpringPack] = 0;
//	$TeamItemCount[6 @ SpringPack] = 0;
//	$TeamItemCount[7 @ SpringPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++


	
//ItemImageData SpringPackImage 
//{ shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 

ItemImageData SpringPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData SpringPack 
{ description = "Springboard"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "jTransportation"; imageType = SpringPackImage; shadowDetailMask = 4; mass = 1.0; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function SpringPack::onUse
(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } 
} 
function SpringPack::onDeploy
(%player,%item,%pos) { if (SpringPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } 
} 
function SpringPack::deployShape
(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = "SimTerrain" ; if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"DeployableCactus",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { %rot = GameBase::getRotation(%player); %phase = newObject("","StaticShape",DeployableSpring,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"Springboard"); Client::sendMessage(%client,0,"Springboard Deployed"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "SpringPack"]++;echo("MSG: ",%client," deployed a Spring Board");  return true;  } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[PlatformPack] = 1;

$TeamItemMax[PlatformPack] = 60;

$ItemMax[larmor, PlatformPack] = 0;	//Seraph
$ItemMax[lfemale, PlatformPack] = 0;	//Seraph
$ItemMax[earmor, PlatformPack] = 1;	//Slave
$ItemMax[efemale, PlatformPack] = 1;	//Slave
$ItemMax[marmor, PlatformPack] = 0;	//Pawn
$ItemMax[aarmor, PlatformPack] = 0;	//Navigator
$ItemMax[darmor, PlatformPack] = 0;	//Atomizer
$ItemMax[barmor, PlatformPack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ PlatformPack] = 0;
//	$TeamItemCount[1 @ PlatformPack] = 0;
//	$TeamItemCount[2 @ PlatformPack] = 0;
//	$TeamItemCount[3 @ PlatformPack] = 0;
//	$TeamItemCount[4 @ PlatformPack] = 0;
//	$TeamItemCount[5 @ PlatformPack] = 0;
//	$TeamItemCount[6 @ PlatformPack] = 0;
//	$TeamItemCount[7 @ PlatformPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData PlatformPackImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData PlatformPack 
{ description = "Small Platform"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "nDoors - Walls - Platforms"; imageType = PlatformPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 50; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function PlatformPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function PlatformPack::onDeploy(%player,%item,%pos) { if (PlatformPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function PlatformPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = getObjectType($los::object); %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"DeployablePlatform",%num); deleteObject(%set); %rot = GameBase::getRotation(%player); %phase = newObject("DeployablePlatform","StaticShape",DeployablePlatform,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"Deployable Platform"); Client::sendMessage(%client,0,"Small Platform Deployed"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "PlatformPack"]++;echo("MSG: ",%client," deployed a Platform");  return true; } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

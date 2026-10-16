//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[ForceFieldPack] = 1;

$TeamItemMax[ForceFieldPack] = 20;

$ItemMax[larmor, ForceFieldPack] = 0;	//Seraph
$ItemMax[lfemale, ForceFieldPack] = 0;	//Seraph
$ItemMax[earmor, ForceFieldPack] = 1;	//Slave
$ItemMax[efemale, ForceFieldPack] = 1;	//Slave
$ItemMax[marmor, ForceFieldPack] = 0;	//Pawn
$ItemMax[aarmor, ForceFieldPack] = 0;	//Navigator
$ItemMax[darmor, ForceFieldPack] = 0;	//Atomizer
$ItemMax[barmor, ForceFieldPack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ ForceFieldPack] = 0;
//	$TeamItemCount[1 @ ForceFieldPack] = 0;
//	$TeamItemCount[2 @ ForceFieldPack] = 0;
//	$TeamItemCount[3 @ ForceFieldPack] = 0;
//	$TeamItemCount[4 @ ForceFieldPack] = 0;
//	$TeamItemCount[5 @ ForceFieldPack] = 0;
//	$TeamItemCount[6 @ ForceFieldPack] = 0;
//	$TeamItemCount[7 @ ForceFieldPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData ForceFieldPackImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};
ItemData ForceFieldPack 
{ description = "Small FF Wall"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "nDoors - Walls - Platforms"; imageType = ForceFieldPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 50; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function ForceFieldPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function ForceFieldPack::onDeploy(%player,%item,%pos) { if (ForceFieldPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function ForceFieldPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = getObjectType($los::object); %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"DeployableForceField",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { %rot = GameBase::getRotation(%player); %phase = newObject("","StaticShape",DeployableForceField,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"Force Field"); Client::sendMessage(%client,0,"Small FF Deployed"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "ForceFieldPack"]++;echo("MSG: ",%client," deployed a Force Field");  return true; } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

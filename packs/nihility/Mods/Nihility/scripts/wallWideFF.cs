//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[LargeForceFieldPack] = 1;

$TeamItemMax[LargeForceFieldPack] = 20;

$ItemMax[larmor, LargeForceFieldPack] = 0;	//Seraph
$ItemMax[lfemale, LargeForceFieldPack] = 0;	//Seraph
$ItemMax[earmor, LargeForceFieldPack] = 1;	//Slave
$ItemMax[efemale, LargeForceFieldPack] = 1;	//Slave
$ItemMax[marmor, LargeForceFieldPack] = 0;	//Pawn
$ItemMax[aarmor, LargeForceFieldPack] = 0;	//Navigator
$ItemMax[darmor, LargeForceFieldPack] = 0;	//Atomizer
$ItemMax[barmor, LargeForceFieldPack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ LargeForceFieldPack] = 0;
//	$TeamItemCount[1 @ LargeForceFieldPack] = 0;
//	$TeamItemCount[2 @ LargeForceFieldPack] = 0;
//	$TeamItemCount[3 @ LargeForceFieldPack] = 0;
//	$TeamItemCount[4 @ LargeForceFieldPack] = 0;
//	$TeamItemCount[5 @ LargeForceFieldPack] = 0;
//	$TeamItemCount[6 @ LargeForceFieldPack] = 0;
//	$TeamItemCount[7 @ LargeForceFieldPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData LargeForceFieldPackImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};
ItemData LargeForceFieldPack { description = "Wide FF Wall"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "nDoors - Walls - Platforms"; imageType = LargeForceFieldPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 50; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function LargeForceFieldPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function LargeForceFieldPack::onDeploy(%player,%item,%pos) { if (LargeForceFieldPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function LargeForceFieldPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = getObjectType($los::object); %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"DeployableForceField",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { %rot = GameBase::getRotation(%player); %phase = newObject("","StaticShape",LargeForceField,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"Force Field"); Client::sendMessage(%client,0,"Wide FF Deployed"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "LargeForceFieldPack"]++;echo("MSG: ",%client," deployed a Wide Force Field");  return true; } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

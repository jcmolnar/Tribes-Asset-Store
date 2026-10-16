//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[DeployableComPack] = 1;

$TeamItemMax[DeployableComPack] = 5;

$ItemMax[larmor, DeployableComPack] = 0;	//Seraph
$ItemMax[lfemale, DeployableComPack] = 0;	//Seraph
$ItemMax[earmor, DeployableComPack] = 1;	//Slave
$ItemMax[efemale, DeployableComPack] = 1;	//Slave
$ItemMax[marmor, DeployableComPack] = 0;	//Pawn
$ItemMax[aarmor, DeployableComPack] = 0;	//Navigator
$ItemMax[darmor, DeployableComPack] = 0;	//Atomizer
$ItemMax[barmor, DeployableComPack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ DeployableComPack] = 0;
//	$TeamItemCount[1 @ DeployableComPack] = 0;
//	$TeamItemCount[2 @ DeployableComPack] = 0;
//	$TeamItemCount[3 @ DeployableComPack] = 0;
//	$TeamItemCount[4 @ DeployableComPack] = 0;
//	$TeamItemCount[5 @ DeployableComPack] = 0;
//	$TeamItemCount[6 @ DeployableComPack] = 0;
//	$TeamItemCount[7 @ DeployableComPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData DeployableComPackImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData DeployableComPack 
{ description = "Command Station"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "hDeployable Base Objects"; shadowDetailMask = 4 ; imageType = DeployableComPackImage; mass = 4.0; elasticity = 0.2; price = 2000; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DeployableComPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DeployableComPack::onDeploy(%player,%item,%pos) { if (DeployableComPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function DeployableComPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = "SimTerrain" ; if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { %inv = newObject("comunit_remote","StaticShape","DeployableComStation",true); addToSet("MissionCleanup", %inv); %rot = GameBase::getRotation(%player); GameBase::setTeam(%inv,GameBase::getTeam(%player)); GameBase::setPosition(%inv,$los::position); GameBase::setRotation(%inv,%rot); Gamebase::setMapName(%inv,%name); Client::sendMessage(%client,0,"Command Station deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableComPack"]++;echo("MSG: ",%client," deployed a Command Station");  return true;  } else { Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }

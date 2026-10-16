//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[DeployableAmmoPack] = 1;

$TeamItemMax[DeployableAmmoPack] = 5;

$ItemMax[larmor, DeployableAmmoPack] = 0;	//Seraph
$ItemMax[lfemale, DeployableAmmoPack] = 0;	//Seraph
$ItemMax[earmor, DeployableAmmoPack] = 1;	//Slave
$ItemMax[efemale, DeployableAmmoPack] = 1;	//Slave
$ItemMax[marmor, DeployableAmmoPack] = 0;	//Pawn
$ItemMax[aarmor, DeployableAmmoPack] = 0;	//Navigator
$ItemMax[darmor, DeployableAmmoPack] = 0;	//Atomizer
$ItemMax[barmor, DeployableAmmoPack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ DeployableAmmoPack] = 0;
//	$TeamItemCount[1 @ DeployableAmmoPack] = 0;
//	$TeamItemCount[2 @ DeployableAmmoPack] = 0;
//	$TeamItemCount[3 @ DeployableAmmoPack] = 0;
//	$TeamItemCount[4 @ DeployableAmmoPack] = 0;
//	$TeamItemCount[5 @ DeployableAmmoPack] = 0;
//	$TeamItemCount[6 @ DeployableAmmoPack] = 0;
//	$TeamItemCount[7 @ DeployableAmmoPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++


ItemImageData DeployableAmmoPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};



ItemData DeployableAmmoPack 
{ description = "Ammo Station"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "hDeployable Base Objects"; shadowDetailMask = 4; imageType = DeployableAmmoPackImage; mass = 2.0; elasticity = 0.2; price = 3000; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DeployableAmmoPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DeployableAmmoPack::onDeploy(%player,%item,%pos) { if (DeployableAmmoPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function DeployableAmmoPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = "SimTerrain" ; if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { %inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true); addToSet("MissionCleanup", %inv); %rot = GameBase::getRotation(%player); GameBase::setTeam(%inv,GameBase::getTeam(%player)); GameBase::setPosition(%inv,$los::position); GameBase::setRotation(%inv,%rot); Gamebase::setMapName(%inv,%name); Client::sendMessage(%client,0,"Ammo Station deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++; echo("MSG: ",%client," deployed an Ammo Station"); return true;  } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

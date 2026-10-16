
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Mechanical Tree
//  By Unknown (xxx@xxx.com)
//  Cleaned up by Alazane (alazane@rkeng.com)
//
//  Installation:
//
//**Add the line 
//    exec(deployTree);
//  in the file "server.cs" in the procedure 
//  "createServer" (just look for the other "exec"s--
//  must at least be before call to 
//  "preloadServerDataBlocks").
//  
//**Add the line 
//    deployTree::Initialize();
//  also in the file "server.cs" in the procedure 
//  "Server::finishMissionLoad" right after
//  "Mission::reinitData".
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$TeamItemMax[TreePack] = 6; 
$InvList[TreePack] = 1; 
$RemoteInvList[TreePack] = 1; 

$CanAlwaysTeamDestroy[DeployableTree] = 1;

 //-=-=-=-=-=-=-=- Initialize =-=-=-=-=-=-=-

function deployTree::Initialize()
{
	$TeamItemCount[0 @ TreePack] = 0; 
	$TeamItemCount[1 @ TreePack] = 0; 
	$TeamItemCount[2 @ TreePack] = 0; 
	$TeamItemCount[3 @ TreePack] = 0; 
	$TeamItemCount[4 @ TreePack] = 0; 
	$TeamItemCount[5 @ TreePack] = 0; 
	$TeamItemCount[6 @ TreePack] = 0; 
	$TeamItemCount[7 @ TreePack] = 0; 
}

 //-=-=-=-=-=-=-=- Pack =-=-=-=-=-=-=-

ItemImageData TreePackImage 
{ 
	shapeFile = "tree1"; 
	mountPoint = 2; 
	mountOffset = { 0, 0.15, -1 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData TreePack 
{ 
	description = "Mechanical Tree"; 
	shapeFile = "tree1"; 
	className = "Backpack"; 
	heading = $InvHead[ihDOb]; 
	imageType = TreePackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function TreePack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function TreePack::onDeploy(%player,%item,%pos) 
{ 
	if (TreePack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function TreePack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]) 
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }

	if (!GameBase::getLOSInfo(%player,3)) 
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }

	%obj = getObjectType($los::object); 
	if (%obj != "SimTerrain") 
	{ Client::sendMessage(%client,0,"Can only deploy on terrain"); return false; }

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return false; }

	if (!checkDeployArea(%client,$los::position)) 
		return false;

	 //
	 // Passed validation, create the object
	 //
	%rot = GameBase::getRotation(%player); 
	%rnd = floor(getRandom() * 10); 
	if(%rnd > 5) 
		%objTree = newObject("","StaticShape",DeployableTree,true); 
	else 
		%objTree = newObject("","StaticShape",DeployableTree2,true); 
	addToSet("MissionCleanup", %objTree); 
	GameBase::setTeam(%objTree,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objTree,$los::position); 
	GameBase::setRotation(%objTree,%rot); 
	Gamebase::setMapName(%objTree,"Mechanical Tree"); 
	Client::sendMessage(%client,0,"Mechanical Tree Deployed"); 
	GameBase::startFadeIn(%objTree); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "TreePack"]++; 
	reportDeploy(%objTree, %client);
	return true; 
}  

 //-=-=-=-=-=-=-=- Object =-=-=-=-=-=-=-

StaticShapeData DeployableTree 
{ 
	shapeFile = "tree1"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 6.50; 
	visibleToSensor = false; 
	isTranslucent = true; 
	description = "Deployable Tree"; 
}; 

function DeployableTree::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--; 
} 

StaticShapeData DeployableTree2 
{ 
	shapeFile = "tree2"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 6.50; 
	visibleToSensor = false; 
	isTranslucent = true; 
	description = "Deployable Tree"; 
}; 

function DeployableTree::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--; 
} 

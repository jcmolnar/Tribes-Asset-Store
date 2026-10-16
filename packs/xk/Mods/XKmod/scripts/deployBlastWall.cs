
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Blast Wall
//  By Unknown (xxx@xxx.com)
//  Cleaned up by Alazane (alazane@rkeng.com)
//
//  Installation:
//
//**Add the line 
//    exec(deployBlastWall);
//  in the file "server.cs" in the procedure 
//  "createServer" (just look for the other "exec"s--
//  must at least be before call to 
//  "preloadServerDataBlocks").
//  
//**Add the line 
//    deployBlastWall::Initialize();
//  also in the file "server.cs" in the procedure 
//  "Server::finishMissionLoad" right after
//  "Mission::reinitData".
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

 // Adjust this to adjust the number a team can have
$TeamItemMax[BlastWallPack] = 20; 
$InvList[BlastWallPack] = 1; 
$RemoteInvList[BlastWallPack] = 1; 

$CanAlwaysTeamDestroy[BlastWall] = 1;
$CanAlwaysTeamDestroy[BlastWall2] = 1;

 //-=-=-=-=-=-=-=- Initialize =-=-=-=-=-=-=-

function deployBlastWall::Initialize()
{
	$TeamItemCount[0 @ BlastWallPack] = 0; 
	$TeamItemCount[1 @ BlastWallPack] = 0; 
	$TeamItemCount[2 @ BlastWallPack] = 0; 
	$TeamItemCount[3 @ BlastWallPack] = 0; 
	$TeamItemCount[4 @ BlastWallPack] = 0; 
	$TeamItemCount[5 @ BlastWallPack] = 0; 
	$TeamItemCount[6 @ BlastWallPack] = 0; 
	$TeamItemCount[7 @ BlastWallPack] = 0; 
}

 //-=-=-=-=-=-=-=- Pack =-=-=-=-=-=-=-

ItemImageData BlastWallPackImage 
{ 
	shapeFile = "AmmoPack"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData BlastWallPack 
{ 
	description = "Blast Wall"; 
	shapeFile = "newdoor5"; 
	className = "Backpack"; 
	heading = $InvHead[ihDOb]; 
	imageType = BlastWallPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function BlastWallPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function BlastWallPack::onDeploy(%player,%item,%pos) 
{ 
	if (BlastWallPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function BlastWallPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]) 
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }

	if (!GameBase::getLOSInfo(%player,3)) 
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return false; }

	if (!checkDeployArea(%client,$los::position)) 
		return false;

	 //
	 // Passed validation, create the object
	 //
	%rot = GameBase::getRotation(%player); 
	%objBlastWall = newObject("","StaticShape",BlastWall,true); 
	addToSet("MissionCleanup", %objBlastWall); 
	GameBase::setTeam(%objBlastWall,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objBlastWall,$los::position); 
	GameBase::setRotation(%objBlastWall,%rot); 
	Gamebase::setMapName(%objBlastWall,"Blast Wall"); 
	Client::sendMessage(%client,0,"Blast Wall Deployed"); 
	GameBase::startFadeIn(%objBlastWall); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "BlastWallPack"]++; 
        reportDeploy(%objBlastWall, %client);
	return true; 
} 

 //-=-=-=-=-=-=-=- Object =-=-=-=-=-=-=-

StaticShapeData BlastWall 
{ 
	shapeFile = "newdoor5"; 
	maxDamage = 2.0; 
	debrisId = defaultDebrisLarge; 
	explosionId = debrisExpLarge; 
}; 

function BlastWall::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastWallPack"]--; 
} 

StaticShapeData BlastWall2 
{ 
	shapeFile = "teleport_vertical"; 
	maxDamage = 10.0; 
	debrisId = defaultDebrisLarge; 
	explosionId = debrisExpLarge;
}; 

function BlastWall2::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastWallPack"]--; 
} 

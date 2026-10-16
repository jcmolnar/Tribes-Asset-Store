//barrier, from warhammer
$TeamItemMax[BlastWallPack] = 2; 
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
	shapeFile = "MortarPack"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData BlastWallPack 
{ 
	description = "Barrier"; 
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

	 //
	 // Passed validation, create the object
	 //
	%rot = GameBase::getRotation(%player); 
	%objBlastWall = newObject("","StaticShape",BlastWall,true); 
	addToSet("MissionCleanup", %objBlastWall); 
	GameBase::setTeam(%objBlastWall,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objBlastWall,$los::position); 
	GameBase::setRotation(%objBlastWall,%rot); 
	Gamebase::setMapName(%objBlastWall,"Bulkhead"); 
	Client::sendMessage(%client,0,"Barrier Deployed"); 
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
	maxDamage = 10.0; 
	debrisId = defaultDebrisLarge; 
	explosionId = debrisExpLarge;
        description = "Barrier"; 
}; 

function BlastWall::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastWallPack"]--; 
} 

StaticShapeData BlastWall2 
{ 
	shapeFile = "teleport_vertical"; 
	maxDamage = 20.0; 
	debrisId = defaultDebrisLarge; 
	explosionId = debrisExpLarge;
}; 

function BlastWall2::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastWallPack"]--; 
} 

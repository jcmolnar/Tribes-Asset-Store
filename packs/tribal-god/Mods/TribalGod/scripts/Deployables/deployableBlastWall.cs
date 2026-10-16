StaticShapeData BlastWallShape
{
	shapeFile = "newdoor5";
	debrisId = defaultDebrisLarge;
	maxDamage = 500.0;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Blast Wall";
};

function BlastWallShape::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @"BlastWall"]--;
}


ItemImageData BlastWallImage
{
	shapeFile = "newdoor5";
	mountPoint = 2;
	mountOffset = { 0, -0.12, 3.0 };
	mountRotation = { 90, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData BlastWall
{
	description = "Blast Wall";
	shapeFile = "newdoor5";
	className = "Backpack";
	heading = $InvHeading[Walls];
	imageType = BlastWallImage;
	shadowDetailMask = 4;
	mass = 40;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function BlastWall::onUse(%player, %item)
{
	if(Player::getMountedItem(%player, $BackpackSlot) != %item)
	{ Player::mountItem(%player, %item, $BackpackSlot); }
	else
	{ Player::deployItem(%player, %item); }
}

function BlastWall::onDeploy(%player, %item, %pos)
{ if(BlastWall::deployShape(%player, %item)){ Player::decItemCount(%player, %item); } }

function BlastWall::deployShape(%player, %item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] > $TeamItemMax[%item])
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for "@ %item.description @"s"); return false; }
	
	if(!GameBase::getLOSInfo(%player, 3))
	{ Client::sendMessage(%client, 0, "Unable To Deploy, Too Far Away."); return false; }
	
	%obj = getObjectType($los::object);
	%rot = GameBase::getRotation(%player);
	%camera = newObject("BlastWall","StaticShape",BlastWallShape,true);
	addToSet("MissionCleanup", %camera);
	GameBase::setTeam(%camera,GameBase::getTeam(%player));
	GameBase::setRotation(%camera, %rot);
	GameBase::setPosition(%camera, $los::position);
	Gamebase::setMapName(%camera, "Wall #"@ $totalNumCameras++ @ " " @ Client::getName(%client));
	Client::sendMessage(%client, 0, "Wall deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%camera) @"BlastWall"]++;
	Echo("MSG: "@ Client::getName(%client) @"("@ %client @") deployed a Blast Wall");
	return true;
}
$InvList[BlastWallPack] = 1;
$MobileInvList[BlastWallPack] = 1;
$RemoteInvList[BlastWallPack] = 1;
AddItem(BlastWallPack);

$CanAlwaysTeamDestroy[BlastWall] = 1;

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
	heading = $InvHead[ihBar];
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
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function BlastWallPack::onDeploy(%player,%item,%pos) 
{
	if(BlastWallPack::deployShape(%player,%item) && !$build) 
		Player::decItemCount(%player,%item);
}

function BlastWallPack::deployShape(%player,%item) 
{	
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]  && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if(!GameBase::getLOSInfo(%player,3)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}

	%obj = $los::object;
	//echo (GameBase::getTeam(%obj));
	if((GameBase::getTeam(%obj) != GameBase::getTeam(%player)) && (getObjectType(%obj) != "SimTerrain") && (GameBase::getTeam(%obj) != -1)) 
	{
		Client::sendMessage(%client,0,"Cannot deploy on enemy base");
		return false;
	}

// check if object is in motion, for dropships and jail cell 
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
	
	if(Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}

	if(!checkDeployArea(%client,$los::position)) 
		return false;

	%rot = GameBase::getRotation(%player);
	%objBlastWall = newObject("","StaticShape",BlastWall,true);
	NukeList(%objBlastWall);
	addToSet("MissionCleanup", %objBlastWall);
	GameBase::setTeam(%objBlastWall,GameBase::getTeam(%player));
	GameBase::setPosition(%objBlastWall,$los::position);
	GameBase::setRotation(%objBlastWall,%rot);
	Gamebase::setMapName(%objBlastWall,"Blast Wall "@Client::getName(%client));
	Client::sendMessage(%client,0,"Blast Wall Deployed");
	GameBase::startFadeIn(%objBlastWall);
	playSound(SoundPickupBackpack,$los::position);
	playSound(ForceFieldOpen,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "BlastWallPack"]++;
	echo("MSG: ",%client," deployed a Blast Wall");
	return true;
}

StaticShapeData BlastWall 
{
	shapeFile = "newdoor5";
maxDamage = 250;
maxEnergy = 200;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	damageSkinData = "objectDamageSkins";
	description = "Blast Wall";
};

function BlastWall::onDestroyed(%this) 
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastWallPack"]--;
}


function BlastWall::onCollision(%this,%object)
{
	if($debug) 
		event::collision(%this,%object);
		
	if(getObjectType(%object) == "Flier") 
	{ 
		%data = GameBase::getDataName(%object);
		if($debug)
			echo(%data@" hitting "@GameBase::getDataName(%this));
			
		%damage = GameBase::getDamageLevel(%object) + 0.01;
		GameBase::setDamageLevel(%object,%damage);
		playSound(SoundFlierCrash,GameBase::getPosition(%object));
	}

}

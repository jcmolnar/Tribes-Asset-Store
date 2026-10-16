$InvList[ForceFieldDoorPack] = 1;
$MobileInvList[ForceFieldDoorPack] = 1;
$RemoteInvList[ForceFieldDoorPack] = 0;
AddItem(ForceFieldDoorPack);

$CanAlwaysTeamDestroy[ForceFieldDoor] = 1;

function deployForceFieldDoor::Initialize()
{	
	$TeamItemCount[0 @ ForceFieldDoorPack] = 0;
	$TeamItemCount[1 @ ForceFieldDoorPack] = 0;
	$TeamItemCount[2 @ ForceFieldDoorPack] = 0;
	$TeamItemCount[3 @ ForceFieldDoorPack] = 0;
	$TeamItemCount[4 @ ForceFieldDoorPack] = 0;
	$TeamItemCount[5 @ ForceFieldDoorPack] = 0;
	$TeamItemCount[6 @ ForceFieldDoorPack] = 0;
	$TeamItemCount[7 @ ForceFieldDoorPack] = 0;
}

ItemImageData ForceFieldDoorPackImage
{	
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ForceFieldDoorPack
{	
	description = "Force Field Door";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHead[ihBar];
	imageType = ForceFieldDoorPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ForceFieldDoorPack::onUse(%player,%item)
{	
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function ForceFieldDoorPack::onDeploy(%player,%item,%pos)
{	
	if(ForceFieldDoorPack::deployShape(%player,%item)&& !$build)
		Player::decItemCount(%player,%item);
}

function ForceFieldDoorPack::deployShape(%player,%item)
{	
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item] && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3)) 
	{
		Client::sendMessage(%client,0,"Cannot deploy here.");
		return false;
	}

// check if object is in motion, for dropships and jail cell 
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
		
	%rot = GameBase::getRotation(%player);
	%obj = newObject("ForceFieldDoorPack","StaticShape",ForceFieldDoorShape,true);
	NukeList(%obj);
	%obj.cloakable = true;
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	GameBase::setRotation(%obj,%rot);
	GameBase::setPosition(%obj,$los::position);
	Gamebase::setMapName(%obj,"Force Field Door "@Client::getName(%client));
	Client::sendMessage(%client,0,"Force Field Door deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%obj) @ "ForceFieldDoorPack"]++;
	echo("MSG: ",%client," deployed a Force Field Door ");
	return true;
}

StaticShapeData ForceFieldDoorShape
{	
	className = "ForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_5x5";
maxDamage = 250;
maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = true;
	description = "Force Field Door";
};

function ForceFieldDoorShape::Destruct(%this)
{	
	ForceFieldDoorShape::doDamage(%this);
}

function ForceFieldDoorShape::doDamage(%this) 
{	
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function ForceFieldDoorShape::onDestroyed(%this)
{	
	ForceFieldDoorShape::doDamage(%this);
	%this.cloakable = "";
	%this.nuetron = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldDoorPack"]--;
}

function ForceFieldDoorShape::onCollision(%this,%obj)
{	
	if($debug) 
		event::collision(%this,%obj);

	if(getObjectType(%obj) == "Flier") 
	{ 
		%data = GameBase::getDataName(%obj);
		%damage = GameBase::getDamageLevel(%obj) + 0.01;
		GameBase::setDamageLevel(%obj,%damage);
		playSound(SoundFlierCrash,GameBase::getPosition(%obj));
		return;
	}
	
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
		return;
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)

		return;
	ForceFieldDoorShape::openDoor(%this);
	return;
}

function ForceFieldDoorShape::openDoor(%this) 
{	
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("ForceFieldDoorShape::closeDoor("@%this@");",2);
}

function ForceFieldDoorShape::closeDoor(%this) 
{	
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -1000");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}


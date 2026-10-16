$InvList[LargeForceFieldDoorPack] = 1;
$MobileInvList[LargeForceFieldDoorPack] = 1;
$RemoteInvList[LargeForceFieldDoorPack] = 0;
AddItem(LargeForceFieldDoorPack);

$CanAlwaysTeamDestroy[LargeForceFieldDoor] = 1;

function deployLargeForceFieldDoor::Initialize()
{	
	$TeamItemCount[0 @ LargeForceFieldDoorPack] = 0;
	$TeamItemCount[1 @ LargeForceFieldDoorPack] = 0;
	$TeamItemCount[2 @ LargeForceFieldDoorPack] = 0;
	$TeamItemCount[3 @ LargeForceFieldDoorPack] = 0;
	$TeamItemCount[4 @ LargeForceFieldDoorPack] = 0;
	$TeamItemCount[5 @ LargeForceFieldDoorPack] = 0;
	$TeamItemCount[6 @ LargeForceFieldDoorPack] = 0;
	$TeamItemCount[7 @ LargeForceFieldDoorPack] = 0;
}

ItemImageData LargeForceFieldDoorPackImage
{	
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LargeForceFieldDoorPack
{	
	description = "Large Force Field Door";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHead[ihBar];
	imageType = LargeForceFieldDoorPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeForceFieldDoorPack::onUse(%player,%item)
{	
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function LargeForceFieldDoorPack::onDeploy(%player,%item,%pos)
{	
	if(LargeForceFieldDoorPack::deployShape(%player,%item)&& !$build)
		Player::decItemCount(%player,%item);
}

function LargeForceFieldDoorPack::deployShape(%player,%item)
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
	%obj = newObject("LargeForceFieldDoorPack","StaticShape",LargeForceFieldDoorShape,true);
	%obj.cloakable = true;
	NukeList(%obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	GameBase::setRotation(%obj,%rot);
	GameBase::setPosition(%obj,$los::position);
	Gamebase::setMapName(%obj,"Large Force Field Door "@Client::getName(%client));
	Client::sendMessage(%client,0,"Large Force Field Door deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%obj) @ "LargeForceFieldDoorPack"]++;
	echo("MSG: ",%client," deployed a Large Force Field Door ");
	return true;
}

StaticShapeData LargeForceFieldDoorShape
{	
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield";
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
	description = "Large Force Field Door";
};

function LargeForceFieldDoorShape::Destruct(%this)
{	
	LargeForceFieldDoorShape::doDamage(%this);
}

function LargeForceFieldDoorShape::doDamage(%this) 
{	
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function LargeForceFieldDoorShape::onDestroyed(%this)
{	
	LargeForceFieldDoorShape::doDamage(%this);
	%this.cloakable = "";
	%this.nuetron = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldDoorPack"]--;
}

function LargeForceFieldDoorShape::onCollision(%this,%obj)
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
	LargeForceFieldDoorShape::openDoor(%this);
	return;
}

function LargeForceFieldDoorShape::openDoor(%this) 
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("LargeForceFieldDoorShape::closeDoor("@%this@");",2);
}

function LargeForceFieldDoorShape::closeDoor(%this) 
{	
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -1000");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}

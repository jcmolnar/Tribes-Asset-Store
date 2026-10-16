$InvList[PlasFloorPack] = 1;
$RemoteInvList[PlasFloorPack] = 1;
$TeamItemMax[PlasFloorPack] = 15;
$CanAlwaysTeamDestroy[PlasFloor] = 1;

$InvList[PlasFloor2Pack] = 1;
$RemoteInvList[PlasFloor2Pack] = 1;
$TeamItemMax[PlasFloor2Pack] = 15;
$CanAlwaysTeamDestroy[PlasFloor2] = 1;

$ItemMax[narmor, PlasFloorPack] = 0;
$ItemMax[aarmor, PlasFloorPack] = 0;
$ItemMax[darmor, PlasFloorPack] = 0;
$ItemMax[nfemale, PlasFloorPack] = 0;
$ItemMax[afemale, PlasFloorPack] = 0;
$ItemMax[sarmor, PlasFloorPack] = 1;
$ItemMax[warmor, PlasFloorPack] = 1;
$ItemMax[barmor, PlasFloorPack] = 1;
$ItemMax[avarmor, PlasFloorPack] = 1;
$ItemMax[wfemale, PlasFloorPack] = 1;
$ItemMax[bfemale, PlasFloorPack] = 1;

$ItemMax[narmor, PlasFloor2Pack] = 0;
$ItemMax[aarmor, PlasFloor2pack] = 0;
$ItemMax[darmor, PlasFloor2pack] = 0;
$ItemMax[nfemale, PlasFloor2pack] = 0;
$ItemMax[afemale, PlasFloor2pack] = 0;
$ItemMax[sarmor, PlasFloor2pack] = 1;
$ItemMax[warmor, PlasFloor2pack] = 1;
$ItemMax[barmor, PlasFloor2pack] = 1;
$ItemMax[avarmor, PlasFloor2pack] = 1;
$ItemMax[wfemale, PlasFloor2pack] = 1;
$ItemMax[bfemale, PlasFloor2pack] = 1;

ItemImageData PlasFloorPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	firstPerson = false;
};

ItemData PlasFloorPack
{
	description = "Plasma Floor (opens)";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "fDeployables";
	imageType = PlasFloorPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 400;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlasFloorPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function PlasFloorPack::onDeploy(%player,%item,%pos)
{
	if(PlasFloorPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function PlasFloorPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (!GameBase::getLOSInfo(%player,3))
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	%rot = GameBase::getRotation(%player);
	%objPlasFloor = newObject("","StaticShape",DeployablePlasFloor,true);
	addToSet("MissionCleanup", %objPlasFloor);
	GameBase::setTeam(%objPlasFloor,GameBase::getTeam(%player));
	GameBase::setPosition(%objPlasFloor,$los::position);
	GameBase::setRotation(%objPlasFloor,%rot);
	Gamebase::setMapName(%objPlasFloor,"Plasma Floor");
	Client::sendMessage(%client,0,"Plasma Floor Deployed");
	GameBase::startFadeIn(%objPlasFloor);
	playSound(SoundPickupBackpack,$los::position);
	playSound(PlasFloorOpen,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "PlasFloorPack"]++;
        echo("MSG: ",%client," deployed a Plasma Floor");
	return true;
}

StaticShapeData DeployablePlasFloor
{
	shapeFile = "plasmawall";
	debrisId = defaultDebrisSmall;
	maxDamage = 4.50;
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
	description = "Plasma Door";
};

function DeployablePlasFloor::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "PlasFloorPack"]--;
}

function DeployablePlasFloor::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
	{
		remoteKill(%c);
		return;
	}
	DeployablePlasFloor::openDoor(%this);
	return;
}

function DeployablePlasFloor::openDoor(%this)
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("DeployablePlasFloor::closeDoor("@%this@");",2);
}

function DeployablePlasFloor::closeDoor(%this)
{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -1000");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}

ItemImageData PlasFloor2packImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	firstPerson = false;
};

ItemData PlasFloor2pack
{
	description = "Plasma Floor (Static)";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "fDeployables";
	imageType = PlasFloor2packImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 400;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlasFloor2pack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function PlasFloor2pack::onDeploy(%player,%item,%pos)
{
	if(PlasFloor2pack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function PlasFloor2pack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (!GameBase::getLOSInfo(%player,3))
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	%rot = GameBase::getRotation(%player);
	%objPlasFloor = newObject("","StaticShape",DeployablePlasFloor2,true);
	addToSet("MissionCleanup", %objPlasFloor);
	GameBase::setTeam(%objPlasFloor,GameBase::getTeam(%player));
	GameBase::setPosition(%objPlasFloor,$los::position);
	GameBase::setRotation(%objPlasFloor,%rot);
	Gamebase::setMapName(%objPlasFloor,"Plasma Floor");
	Client::sendMessage(%client,0,"Plasma Floor Deployed");
	GameBase::startFadeIn(%objPlasFloor);
	playSound(SoundPickupBackpack,$los::position);
	playSound(PlasFloorOpen,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "PlasFloor2pack"]++;
        echo("MSG: ",%client," deployed a Plasma Floor");
	return true;
}

StaticShapeData DeployablePlasFloor2
{
	shapeFile = "plasmawall";
	debrisId = defaultDebrisSmall;
	maxDamage = 4.50;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Plasma Floor";
};

function DeployablePlasFloor2::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "PlasFloor2pack"]--;
}
function DeployablePlasFloor2::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
	{
		remoteKill(%c);
		return;
	}
}
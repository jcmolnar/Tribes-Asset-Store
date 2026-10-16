$InvList[DataWallPack] = 1;
$RemoteInvList[DataWallPack] = 1;
$InvList[LargeDataWallPack] = 1;
$RemoteInvList[LargeDataWallPack] = 1;

addDeployable(DataWallPack, 20);
addDeployable(LargeDataWallPack, 20);

ItemImageData DataWallPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DataWallPack
{
	description = "DataWall Mk1";
	shapeFile = "forcefield_5x5";
	className = "Backpack";
	heading = $InvHead[iDefe];
	imageType = DataWallPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 50;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DataWallPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function DataWallPack::onDeploy(%player,%item,%pos)
{
	if (DataWallPack::deployShape(%player,%item)) Player::decItemCount(%player,%item);
}

function DataWallPack::deployShape(%player,%item)
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
	if (Vector::dot($los::normal,"0 0 1") <= 0.7)
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	%rot = GameBase::getRotation(%player);
	%objDataWall = newObject("","StaticShape",DataWall,true);
	addToSet("MissionCleanup", %objDataWall);
	GameBase::setTeam(%objDataWall,GameBase::getTeam(%player));
	GameBase::setPosition(%objDataWall,$los::position);
	GameBase::setRotation(%objDataWall,%rot);
	Gamebase::setMapName(%objDataWall,"DataWall");
	Client::sendMessage(%client,0,"DataWall Deployed");
	GameBase::startFadeIn(%objDataWall);
	playSound(SoundPickupBackpack,$los::position);
	playSound(ForceFieldOpen,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "DataWallPack"]++;
	echo("MSG: ",%client," deployed a DataWall");
	return true;
}

StaticShapeData DataWall
{
	description = "DataWall";
	visibleToSensor = true;
	mapFilter = 4;
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_5x5";
	maxDamage = 10.0;
	maxEnergy = 200;
	mapFilter = 2;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = true;
};

function DataWall::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "DataWallPack"]--;
}

function DataWall::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) return;
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam) return;
	DataWall::openDoor(%this);
	return;
}

function DataWall::openDoor(%this)
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("DataWall::closeDoor("@%this@");",4);
}

function DataWall::closeDoor(%this)
{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -6");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}

ItemImageData LargeDataWallPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LargeDataWallPack
{
	description = "DataWall Mk2";
	shapeFile = "forcefield";
	className = "Backpack";
	heading = $InvHead[iDefe];
	imageType = LargeDataWallPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeDataWallPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function LargeDataWallPack::onDeploy(%player,%item,%pos)
{
	if (LargeDataWallPack::deployShape(%player,%item)) Player::decItemCount(%player,%item);
}

function LargeDataWallPack::deployShape(%player,%item)
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
	if (Vector::dot($los::normal,"0 0 1") <= 0.7)
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	%rot = GameBase::getRotation(%player);
	%objLargeDataWall = newObject("","StaticShape",LargeDataWall,true);
	addToSet("MissionCleanup", %objLargeDataWall);
	GameBase::setTeam(%objLargeDataWall,GameBase::getTeam(%player));
	GameBase::setPosition(%objLargeDataWall,$los::position);
	GameBase::setRotation(%objLargeDataWall,%rot);
	Gamebase::setMapName(%objLargeDataWall,"Large DataWall");
	Client::sendMessage(%client,0,"Large DataWall Deployed");
	GameBase::startFadeIn(%objLargeDataWall);
	playSound(SoundPickupBackpack,$los::position);
	playSound(ForceFieldOpen,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "LargeDataWallPack"]++;
	echo("MSG: ",%client," deployed a Large DataWall");
	return true;
}

StaticShapeData LargeDataWall
{
	description = "Large DataWall";
	visibleToSensor = true;
	mapFilter = 4;
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield";
	maxDamage = 15.0;
	maxEnergy = 200;
	mapFilter = 2;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = true;
};

function LargeDataWall::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeDataWallPack"]--;
}

function LargeDataWall::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) return;
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam) return;
	LargeDataWall::openDoor(%this);
	return;
}

function LargeDataWall::openDoor(%this)
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("LargeDataWall::closeDoor("@%this@");",4);
}

function LargeDataWall::closeDoor(%this)
{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -6");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}

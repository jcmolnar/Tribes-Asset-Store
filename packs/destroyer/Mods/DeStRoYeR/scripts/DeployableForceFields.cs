$InvList[ForceFieldDoorPack] = 1;
$RemoteInvList[ForceFieldDoorPack] = 0;
$TeamItemMax[ForceFieldDoorPack] = 10;
$InvList[LargeForceFieldDoorPack] = 1;
$RemoteInvList[LargeForceFieldDoorPack] = 0;
$TeamItemMax[LargeForceFieldDoorPack] = 6;

$CanAlwaysTeamDestroy[ForceFieldDoor] = 1;
$CanAlwaysTeamDestroy[LargeForceFieldDoor] = 1;

$ItemMax[narmor, ForceFieldDoorPack] = 0;
$ItemMax[aarmor, ForceFieldDoorPack] = 0;
$ItemMax[darmor, ForceFieldDoorPack] = 0;
$ItemMax[nfemale, ForceFieldDoorPack] = 0;
$ItemMax[afemale, ForceFieldDoorPack] = 0;
$ItemMax[sarmor, ForceFieldDoorPack] = 1;
$ItemMax[warmor, ForceFieldDoorPack] = 1;
$ItemMax[barmor, ForceFieldDoorPack] = 1;
$ItemMax[avarmor, ForceFieldDoorPack] = 1;
$ItemMax[wfemale, ForceFieldDoorPack] = 1;
$ItemMax[bfemale, ForceFieldDoorPack] = 1;

$ItemMax[narmor, LargeForceFieldDoorPack] = 0;
$ItemMax[aarmor, LargeForceFieldDoorPack] = 0;
$ItemMax[darmor, LargeForceFieldDoorPack] = 0;
$ItemMax[nfemale, LargeForceFieldDoorPack] = 0;
$ItemMax[afemale, LargeForceFieldDoorPack] = 0;
$ItemMax[sarmor, LargeForceFieldDoorPack] = 1;
$ItemMax[warmor, LargeForceFieldDoorPack] = 0;
$ItemMax[barmor, LargeForceFieldDoorPack] = 1;
$ItemMax[avarmor, LargeForceFieldDoorPack] = 0;
$ItemMax[wfemale, LargeForceFieldDoorPack] = 0;
$ItemMax[bfemale, LargeForceFieldDoorPack] = 1;


ItemImageData ForceFieldDoorPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	firstPerson = false;
};

ItemData ForceFieldDoorPack
{
	description = "Small Force Field Door";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "fDeployables";
	imageType = ForceFieldDoorPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 250;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ForceFieldDoorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function ForceFieldDoorPack::onDeploy(%player,%item,%pos)
{
	if (ForceFieldDoorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ForceFieldDoorPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%rot = GameBase::getRotation(%player);
			%obj = newObject("ForceFieldDoorPack","StaticShape",ForceFieldDoorShape,true);
			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj,GameBase::getTeam(%player));
			GameBase::setRotation(%obj,%rot);
			GameBase::setPosition(%obj,$los::position);
			Gamebase::setMapName(%obj,"Force Field Door");
			Client::sendMessage(%client,0,"Force Field Door deployed");
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%obj) @ "ForceFieldDoorPack"]++;
			echo("MSG: ",%client," deployed a Force Field Door ");
			return true;
		}
		else
		{
			Client::sendMessage(%client,0,"Cannot deploy here.");
		}
	}
	else
		 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

StaticShapeData ForceFieldDoorShape
{
	className = "ForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_5x5";
	maxDamage = 4.5;
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
	$TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldDoorPack"]--;
}

function ForceFieldDoorShape::onCollision(%this,%obj)
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
		return;
	}
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

function ForceFieldDoorShape::openDoor(%this)
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("ForceFieldDoorShape::closeDoor("@%this@");",2);
}

ItemImageData LargeForceFieldDoorPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData LargeForceFieldDoorPack
{
	description = "Large Force Field Door";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "fDeployables";
	imageType = LargeForceFieldDoorPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeForceFieldDoorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function LargeForceFieldDoorPack::onDeploy(%player,%item,%pos)
{
	if (LargeForceFieldDoorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function LargeForceFieldDoorPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%rot = GameBase::getRotation(%player);
			%obj = newObject("LargeForceFieldDoorPack","StaticShape",LargeForceFieldDoorShape,true);
			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj,GameBase::getTeam(%player));
			GameBase::setRotation(%obj,%rot);
			GameBase::setPosition(%obj,$los::position);
			Gamebase::setMapName(%obj,"Large Force Field Door");
			Client::sendMessage(%client,0,"Large Force Field Door deployed");
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%obj) @ "LargeForceFieldDoorPack"]++;
			echo("MSG: ",%client," deployed a Large Force Field Door ");
			return true;
		}
		else
		{
			Client::sendMessage(%client,0,"Cannot deploy here.");
		}
	}
	else
		 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

StaticShapeData LargeForceFieldDoorShape
{
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield";
	maxDamage = 6.0;
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
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldDoorPack"]--;
}

function LargeForceFieldDoorShape::onCollision(%this,%obj)
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
		return;
	}
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
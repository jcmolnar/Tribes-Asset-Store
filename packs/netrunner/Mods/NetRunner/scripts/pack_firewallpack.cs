$InvList[FireWallPack] = 1;
$RemoteInvList[FireWallPack] = 1;

addDeployable(FireWallPack, 20);

ItemImageData FireWallPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData FireWallPack
{
	description = "FireWall";
	shapeFile = "newdoor5";
	className = "Backpack";
	heading = $InvHead[iDefe];
	imageType = FireWallPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 150;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FireWallPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function FireWallPack::onDeploy(%player,%item,%pos)
{
	if (FireWallPack::deployShape(%player,%item)) Player::decItemCount(%player,%item);
}

function FireWallPack::deployShape(%player,%item)
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
	%objFireWall = newObject("","StaticShape",FireWall,true);
	addToSet("MissionCleanup", %objFireWall);
	GameBase::setTeam(%objFireWall,GameBase::getTeam(%player));
	GameBase::setPosition(%objFireWall,$los::position);
	GameBase::setRotation(%objFireWall,%rot);
	Gamebase::setMapName(%objFireWall,"FireWall");
	Client::sendMessage(%client,0,"FireWall Deployed");
	GameBase::startFadeIn(%objFireWall);
	playSound(SoundPickupBackpack,$los::position);
	playSound(ForceFieldOpen,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "FireWallPack"]++;
	echo("MSG: ",%client," deployed a FireWall");
	return true;
}

StaticShapeData FireWall
{
	shapeFile = "newdoor5";
	maxDamage = 20.0;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	description = "FireWall";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	visibleToSensor = true;
	mapFilter = 4;
};

function FireWall::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "FireWallPack"]--;
}

function FireWall::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) return;
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam) return;
	FireWall::openDoor(%this);
	return;
}

function FireWall::openDoor(%this)
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("FireWall::closeDoor("@%this@");",4);
}

function FireWall::closeDoor(%this)
{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -6");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}
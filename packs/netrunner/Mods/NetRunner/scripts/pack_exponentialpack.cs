$InvList[ExponentialPack] = 1;
$InvList[LargeExponentialPack] = 1;

$RemoteInvList[ExponentialPack] = 1;
$RemoteInvList[LargeExponentialPack] = 1;

addDeployable(ExponentialPack, 20);
addDeployable(LargeExponentialPack, 10);

ItemImageData ExponentialPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ExponentialPack
{
	description = "Exponential Mk1";
	shapeFile = "elevator_6x6_octagon";
	classname = "Backpack";
	heading = $InvHead[iDefe];
	imageType = ExponentialPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.1;
	price = 50;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ExponentialPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function ExponentialPack::onDeploy(%player,%item,%pos)
{
	if (ExponentialPack::deployShape(%player,%item)) Player::decItemCount(%player,%item);
}

function ExponentialPack::deployshape(%player,%item)
{
	GameBase::getLOSInfo(%player,6);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		%playerPos = GameBase::getPosition(%player);
		%flag = $teamFlag[GameBase::getTeam(%player)];
		%flagpos = gamebase::getPosition(%flag);
		if(Vector::getDistance(%flagpos, %playerpos) > 10)
		{
			%object = newObject("Exponential","Staticshape",Exponential,true);
			addToSet("MissionCleanup", %object);
			GameBase::setTeam(%object,GameBase::getTeam(%player));
			GameBase::setRotation(%object,"0 0 0");
			GameBase::setPosition(%object,GameBase::getPosition(%player));
			Gamebase::setMapName(%object,"Exponential #" @ $totalNumPlatforms++ @ " " @  Client::getName(%client));
			Client::sendMessage(%client,0,"Exponential deployed");
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%object) @ "ExponentialPack"]++;
			echo("MSG: ",%client," deployed an Exponential");
			return true;
		}
		else
		{
			Client::sendMessage(%client,0,"You are too close to your flag.");
			return false;
		}
	}
	else
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
}

ItemImageData LargeExponentialPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData LargeExponentialPack
{
	description = "Exponential Mk2";
	shapeFile = "elevator16x16_octo";
	classname = "Backpack";
	heading = $InvHead[iDefe];
	imageType = LargeExponentialPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.1;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeExponentialPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function LargeExponentialPack::onDeploy(%player,%item,%pos)
{
	if (LargeExponentialPack::deployShape(%player,%item)) Player::decItemCount(%player,%item);
}

function LargeExponentialPack::deployshape(%player,%item)
{
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		%playerPos = GameBase::getPosition(%player);
		%flag = $teamFlag[GameBase::getTeam(%player)];
		%flagpos = gamebase::getPosition(%flag);
		if(Vector::getDistance(%flagpos, %playerpos) > 10)
		{
			%object = newObject("Large Exponential","StaticShape",LargeExponential,true);
			addToSet("MissionCleanup", %object);
			GameBase::setTeam(%object,GameBase::getTeam(%player));
			GameBase::setRotation(%object,"0 0 0");
			GameBase::setPosition(%object,GameBase::getPosition(%player));
			Gamebase::setMapName(%object,"Large Exponential" @  Client::getName(%client));
			Client::sendMessage(%client,0,"Large Exponential deployed");
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%object) @ "LargeExponentialPack"]++;
			echo("MSG: ",%client," deployed a Large Exponential");
			return true;
		}
		else
		{
			Client::sendMessage(%client,0,"You are too close to your flag.");
			return false;
		}
	}
}

StaticShapeData Exponential
{
	shapeFile = "elevator_6x6_octagon";
	debrisId = defaultDebrisMedium;
	maxDamage = 5.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	mapFilter = 4;
	description = "Exponential";
};

function Exponential::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "ExponentialPack"]--;
}

StaticShapeData LargeExponential
{
	shapeFile = "elevator16x16_octo";
	debrisId = defaultDebrisLarge;
	maxDamage = 10.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	mapFilter = 4;
	description = "Large Exponential";
};

function LargeExponential::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeExponentialPack"]--;
}
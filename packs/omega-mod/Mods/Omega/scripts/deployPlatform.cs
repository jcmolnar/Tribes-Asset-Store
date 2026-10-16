$InvList[PlatformPack] = 1;
$RemoteInvList[PlatformPack] = 1;

function deployPlatform::Initialize()
{
	$TeamItemCount[0 @ PlatformPack] = 0;
	$TeamItemCount[1 @ PlatformPack] = 0;
	$TeamItemCount[2 @ PlatformPack] = 0;
	$TeamItemCount[3 @ PlatformPack] = 0;
	$TeamItemCount[4 @ PlatformPack] = 0;
	$TeamItemCount[5 @ PlatformPack] = 0;
	$TeamItemCount[6 @ PlatformPack] = 0;
	$TeamItemCount[7 @ PlatformPack] = 0;
}

ItemImageData PlatformPackImage 
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PlatformPack 
{
	description = "Deployable Platform";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = iBarrier;
	imageType = PlatformPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlatformPack::onUse(%player,%item) 
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function PlatformPack::onDeploy(%player,%item,%pos) 
{
	if(PlatformPack::deployShape(%player,%item)&& !$build) 
		Player::decItemCount(%player,%item);
}

function PlatformPack::deployShape(%player,%item) 
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item] && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	%platform = newObject("DeployablePlatform", "StaticShape", DeployablePlatform, true);
	NukeList(%platform);
	addToSet("MissionCleanup", %platform);
	%rot = GameBase::getRotation(%player);
	GameBase::setTeam(%platform, GameBase::getTeam(%player));
	GameBase::setPosition(%platform, $los::position);
	GameBase::setRotation(%platform, %rot);
	Gamebase::setMapName(%platform, "Deployable Platform");
	Client::sendMessage(%client,0,"Platform Deployed");
	GameBase::startFadeIn(%platform);
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "PlatformPack"]++;
	echo("MSG: ",%client," deployed an platform");
	return true;
}

StaticShapeData DeployablePlatform 
{
	shapeFile = "elevator6x6thin";
	debrisId = defaultDebrisSmall;
	maxDamage = 4;
	visibleToSensor = false;
	isTranslucent = true;
	description = "Deployable Platform";
};

function DeployablePlatform::onDestroyed(%this) 
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "PlatformPack"]--;
}

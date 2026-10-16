$InvList[PlatformPack] = 1;
$MobileInvList[PlatformPack] = 1;
$RemoteInvList[PlatformPack] = 1;
AddItem(PlatformPack);

$CanAlwaysTeamDestroy[DeployablePlatform] = 1;

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
	heading = $InvHead[ihBar];
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
	if(!GameBase::getLOSInfo(%player,4)) 
	{
		if(!$build)Client::sendMessage(%client,0,"Deploy position out of range");
		GameBase::playSound(%player, SoundPackUse, 0);
		return false;
	}

// check if object is in motion, for dropships and jail cell 
	%obj = $los::object;
	if(%obj.inmotion == true && !$Build)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
	
		
	%rot = GameBase::getRotation(%player);//floor

	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	{
		%prot = GameBase::getRotation(%player);
		%xRot = getWord(%prot,0);
		%yRot = getWord(%prot,1);
		%zRot = getWord(%prot,2);			
		%rot =  %xRot + 3.14159@" " @%yRot@" "@%zRot;//ceiling...
		%up = true;
	}	
	
	%platform = newObject("DeployablePlatform", "StaticShape", DeployablePlatform, true);
	NukeList(%platform);
	addToSet("MissionCleanup", %platform);
//	%rot = GameBase::getRotation(%player);
	GameBase::setTeam(%platform, GameBase::getTeam(%player));
	GameBase::setPosition(%platform, $los::position);
	GameBase::setRotation(%platform, %rot);
	Gamebase::setMapName(%platform, "Deployable Platform "@Client::getName(%client));
	if(!$build)
		Client::sendMessage(%client,0,"Platform Deployed");
	GameBase::startFadeIn(%platform);
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "PlatformPack"]++;
	if($build && !%up)
	{		
		GameBase::setPosition(%player, vector::add(GameBase::getPosition(%player),"0 0 1"));		
	}	
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

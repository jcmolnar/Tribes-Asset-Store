//=============================================================
//deployable platforms
//=============================================================

//==========================================
$ItemMax[larmor, AirPlatformPack] = 0;
$ItemMax[lfemale, AirPlatformPack] = 0;
$ItemMax[marmor, AirPlatformPack] = 0;
$ItemMax[mfemale, AirPlatformPack] = 0;
$ItemMax[harmor, AirPlatformPack] = 1;
//==========================================
$InvList[AirPlatformPack] = 1;
$RemoteInvList[AirPlatformPack] = 1;
$TeamItemMax[AirPlatformPack] = 10;
//=============================================================

StaticShapeData AirPlatform
{
	shapeFile = "elevator6x6thin"; 
	debrisId = defaultDebrisMedium;
	maxDamage = 15.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "S_Air Plat";
      description = "Air Platform";
};

function AirPlatform::onDestroyed(%this)
{
	
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 1.0, 0.05, 15, 13, 3, 0.40, 0.30, 150, 70);
	$TeamItemCount[GameBase::getTeam(%this) @ "AirPlatformPack"]--;
}

ItemImageData AirPlatformPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData AirPlatformPack
{	
	description = "Air Platform";
	shapefile = "ammopack";
	classname = "Backpack";
	heading = "wDeployables";
	imageType = AirPlatformPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.1;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AirPlatformPack::onUse(%player,%item)
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

function AirPlatformPack::onDeploy(%player,%item,%pos)
{
	if (AirPlatformPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function AirPlatformPack::deployshape(%player,%item)
{
	GameBase::getLOSInfo(%player,6);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		%playerPos = GameBase::getPosition(%player);
		%flag = $teamFlag[GameBase::getTeam(%player)];
		%flagpos = gamebase::getPosition(%flag);
		if(Vector::getDistance(%flagpos, %playerpos) > 7)
		{
			if(Vector::getDistance(%flag.originalPosition, %playerpos) > 7)
			{
				%sensor = newObject("Air Platform","Staticshape",AirPlatform,true); 
	   			addToSet("MissionCleanup", %sensor);				      
				gameBase::setTeam(%sensor,GameBase::getTeam(%player));
				gameBase::setRotation(%sensor,"0 0 0");// %rot
				gameBase::setPosition(%sensor,GameBase::getPosition(%player));
				gamebase::setMapName(%sensor,"Air Platform#" @ $totalNumPlatforms++ @ " " @  Client::getName(%client));
				client::sendMessage(%client,0,"Air Platform deployed");
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%sensor) @ "AirPlatformPack"]++;
				echo("MSG: ",%client," deployed an Air Platform ");
				return true;
			}
			else
				Client::sendMessage(%client,0,"Nope, cant respawn your flag under platforms.");
		}
		else
			Client::sendMessage(%client,0,"You are too close to your flag, cant hide the flag in this mod.");
			return false;
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
}
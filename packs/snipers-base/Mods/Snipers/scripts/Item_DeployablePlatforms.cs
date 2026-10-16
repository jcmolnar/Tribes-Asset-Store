exec(turret);
//----------------------------------------------------------------------------
//
//	DEPLOYABLES
//
//----------------------------------------------------------------------------

ItemData Backpack
{
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
		}
		else 
		{
		Player::trigger(%player,$BackpackSlot);
	}
}

//----------------------------------------------------------------------------
//	DEPLOYABLE PLATFORM
//----------------------------------------------------------------------------

$InvList[PlatformPack] = 1; 
$RemoteInvList[PlatformPack] = 1; 
$CanAlwaysTeamDestroy[DeployablePlatform] = 1;

 //-=-=-=-=-=-=-=- Initialize -=-=-=-=-=-=-=-

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

 //-=-=-=-=-=-=-=- Pack -=-=-=-=-=-=-=-

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
	description = "Plasma Floor"; 
	shapeFile = "AmmoPack"; 
	className = "Backpack"; 
	heading = $InvHead[ihDep];
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
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function PlatformPack::onDeploy(%player,%item,%pos) 
{ 
	if (PlatformPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function PlatformPack::deployShape(%player,%item) 
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
	 //
	 // Passed validation, create the object
	 //
	%platform = newObject("DeployablePlatform", "StaticShape", DeployablePlatform, true); 
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
        reportDeploy(%platform, %client);
	return true; 
}  

 //-=-=-=-=-=-=-=- Object -=-=-=-=-=-=-=-

StaticShapeData DeployablePlatform
{ 
	shapeFile = "plasmawall"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 2.00; 
	visibleToSensor = false; 
	isTranslucent = true; 
	description = "Deployable Platform"; 
}; 

function DeployablePlatform::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "PlatformPack"]--; 
}

//----------------------------------------------------------------------------
//	DEPLOYABLE AIR PLATFORMS
//----------------------------------------------------------------------------

$InvList[AirPlatformPack] = 1;
$RemoteInvList[AirPlatformPack] = 1;

$InvList[LargeAirPlatPack] = 1;
$RemoteInvList[LargeAirPlatPack] = 1;

$InvList[AirPlasmaFloorPack] = 0;
$RemoteInvList[AirPlasmaFloorPack] = 0;

$CanAlwaysTeamDestroy[AirPlatformPack] = 1;
$CanAlwaysTeamDestroy[LargeAirPlatPack] = 1;
$CanAlwaysTeamDestroy[AirPlasmaFloorPack] = 1;

 //-=-=-=-=-=-=-=- Initialize =-=-=-=-=-=-=-

function deployAirPlat::Initialize()
{
	$TeamItemCount[0 @ AirPlatformPack] = 0; 
	$TeamItemCount[1 @ AirPlatformPack] = 0; 
	$TeamItemCount[2 @ AirPlatformPack] = 0; 
	$TeamItemCount[3 @ AirPlatformPack] = 0; 
	$TeamItemCount[4 @ AirPlatformPack] = 0; 
	$TeamItemCount[5 @ AirPlatformPack] = 0; 
	$TeamItemCount[6 @ AirPlatformPack] = 0; 
	$TeamItemCount[7 @ AirPlatformPack] = 0; 

	$TeamItemCount[0 @ LargeAirPlatPack] = 0;
	$TeamItemCount[1 @ LargeAirPlatPack] = 0;
	$TeamItemCount[2 @ LargeAirPlatPack] = 0;
	$TeamItemCount[3 @ LargeAirPlatPack] = 0;
	$TeamItemCount[4 @ LargeAirPlatPack] = 0;
	$TeamItemCount[5 @ LargeAirPlatPack] = 0;
	$TeamItemCount[6 @ LargeAirPlatPack] = 0;
	$TeamItemCount[7 @ LargeAirPlatPack] = 0;

	$TeamItemCount[0 @ AirPlasmaFloorPack] = 0;
	$TeamItemCount[1 @ AirPlasmaFloorPack] = 0;
	$TeamItemCount[2 @ AirPlasmaFloorPack] = 0;
	$TeamItemCount[3 @ AirPlasmaFloorPack] = 0;
	$TeamItemCount[4 @ AirPlasmaFloorPack] = 0;
	$TeamItemCount[5 @ AirPlasmaFloorPack] = 0;
	$TeamItemCount[6 @ AirPlasmaFloorPack] = 0;
	$TeamItemCount[7 @ AirPlasmaFloorPack] = 0;
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
	heading = $InvHead[ihDep];
	imageType = AirPlatformPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.1;
	price = 150;
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
		if(Vector::getDistance(%flagpos, %playerpos) > 10)
		{
		%camera = newObject("Hover Pad","Staticshape",AirPlatform,true); 
	   	addToSet("MissionCleanup", %camera);				      
		GameBase::setTeam(%camera,GameBase::getTeam(%player));
		GameBase::setRotation(%camera,"0 0 0");// %rot
		GameBase::setPosition(%camera,GameBase::getPosition(%player));
		Gamebase::setMapName(%camera,"Hover Pad#" @ $totalNumPlatforms++ @ " " @  Client::getName(%client));
		Client::sendMessage(%client,0,"Hover Pad deployed");
		playSound(SoundPickupBackpack,$los::position);
		$TeamItemCount[GameBase::getTeam(%camera) @ "AirPlatformPack"]++;
		echo("MSG: ",%client," deployed a Hover Pad ");
		return true;
		}
		else
			Client::sendMessage(%client,0,"You are too close to your flag, cant hide the flag in this mod.");
			return false;
		}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
}

// ****

ItemImageData LargeAirPlatPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData LargeAirPlatPack
{	
	description = "Large Air Platform";
	shapefile = "ammopack";
	classname = "Backpack";
	heading = $InvHead[ihDep];
	imageType = LargeAirPlatPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.1;
	price = 250;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeAirPlatPack::onUse(%player,%item)
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

function LargeAirPlatPack::onDeploy(%player,%item,%pos)
{
	if (LargeAirPlatPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function LargeAirPlatPack::deployshape(%player,%item)// here
{
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		// if player is within 30 yards of flag cannot deploy
		%playerPos = GameBase::getPosition(%player);
		%flag = $teamFlag[GameBase::getTeam(%player)];
		%flagpos = gamebase::getPosition(%flag);
		echo("%flagpos " @ %flagpos);
		echo("%playerpos " @ %playerpos);
		if(Vector::getDistance(%flagpos, %playerpos) > 10)
		{
		%camera = newObject("Large Hover Pad","StaticShape",LargeAirPlatform,true); // name when targeted,cs the shape is in,
	   	addToSet("MissionCleanup", %camera);				      // shape name in cs,
		GameBase::setTeam(%camera,GameBase::getTeam(%player));
		GameBase::setRotation(%camera,"0 0 0");// %rot
		GameBase::setPosition(%camera,GameBase::getPosition(%player));
		Gamebase::setMapName(%camera,"Large Hover Pad " @  Client::getName(%client));
		Client::sendMessage(%client,0,"Large Hover Pad deployed");
		playSound(SoundPickupBackpack,$los::position);
		$TeamItemCount[GameBase::getTeam(%camera) @ "LargeAirPlatPack"]++;
		echo("MSG: ",%client," deployed a Large Hover Pad ");
		return true;
		}
		else
			Client::sendMessage(%client,0,"You are too close to your flag, cant hide the flag in this mod!");
			return false;
	}

}

ItemImageData AirPlasmaFloorPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData AirPlasmaFloorPack
{	
	description = "Air PlasmaFloor";
	shapefile = "ammopack";
	classname = "Backpack";
	heading = $InvHead[ihDep];
	imageType = AirPlasmaFloorPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.1;
	price = 150;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AirPlasmaFloorPack::onUse(%player,%item)
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

function AirPlasmaFloorPack::onDeploy(%player,%item,%pos)
{
	if (AirPlasmaFloorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function AirPlasmaFloorPack::deployshape(%player,%item)
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
		%camera = newObject("Air Plasma Floor","Staticshape",AirPlasmaFloorPack,true);
	   	addToSet("MissionCleanup", %camera);
		GameBase::setTeam(%camera,GameBase::getTeam(%player));
		GameBase::setRotation(%camera,"0 0 0");// %rot
		GameBase::setPosition(%camera,GameBase::getPosition(%player));
		Gamebase::setMapName(%camera,"Air Plasma Floor#" @ $totalNumPlatforms++ @ " " @  Client::getName(%client));
		Client::sendMessage(%client,0,"Air Plasma Floor deployed");
		playSound(SoundPickupBackpack,$los::position);
		$TeamItemCount[GameBase::getTeam(%camera) @ "AirPlasmaFloorPack"]++;
		echo("MSG: ",%client," deployed a Air Plasma Floor ");
		return true;
		}
		else
			Client::sendMessage(%client,0,"You are too close to your flag, cant hide the flag in this mod.");
			return false;
		}
	else
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

StaticShapeData AirPlasmaFloorPack
{
	shapeFile = "plasmawall";
	debrisId = defaultDebrisMedium;
	maxDamage = 2.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "S_Air Plat";
      description = "Air PlasmaFloor";
};

function AirPlasmaFloorPack::onDestroyed(%this)
{
   StaticShape::objectiveDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "AirPlasmaFloorPack"]--;
}

StaticShapeData LargeAirPlatform
{
	shapeFile = "elevator16x16_octo"; 
	debrisId = defaultDebrisLarge;
	maxDamage = 15.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	mapFilter = 4;
      description = "Large Hover Pad";
};

function LargeAirPlatform::onDestroyed(%this)
{	
   StaticShape::objectiveDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "LargeAirPlatPack"]--;
}

StaticShapeData AirPlatform
{
	shapeFile = "elevator_6x6_octagon"; 
	debrisId = defaultDebrisMedium;
	maxDamage = 2.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "S_Air Plat";
      description = "Hover Pad";
};

function AirPlatform::onDestroyed(%this)
{
	
   StaticShape::objectiveDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "AirPlatformPack"]--;
}

//----------------------------------------------------------------------------
// Remote deploy for items

function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(!%num) {
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
		%obj = Group::getObject(%set,0);	
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;	
		

}

function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%sensor = newObject("","Sensor",%shape,true);
 	        	   	addToSet("MissionCleanup", %sensor);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						GameBase::setPosition(%sensor,$los::position);
						Gamebase::setMapName(%sensor,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						playSound(SoundPickupBackpack,$los::position);
						echo("MSG: ",%client," deployed a ",%name);
						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}

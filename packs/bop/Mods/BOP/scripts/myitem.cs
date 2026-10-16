$InvList[AirPlatformPack] = 1;
$InvList[LargeAirPlatPack] = 1;
$InvList[FlagstandPack] = 1;
$InvList[DeployableWallPack] = 1;
$InvList[ForceFieldPack] = 1;
$InvList[LargeFieldPack] = 1;

$InvList[CloakPack] = 1;
$InvList[MineLayerPack] = 1;
$InvList[RepairMakerPack] =1;
$InvList[HeatSinkPack] = 1;

$RemoteInvList[AirPlatformPack] = 1;
$RemoteInvList[LargeAirPlatPack] = 1;
$RemoteInvList[DeployableWallPack] = 1;
$RemoteInvList[ForceFieldPack] = 1;
$RemoteInvList[LargeFieldPack] = 1;
$RemoteInvList[FlagstandPack] = 1;

$RemoteInvList[CloakPack] = 1;
$RemoteInvList[MineLayerPack] = 1;
$RemoteInvList[RepairMakerPack] =1;
$RemoteInvList[HeatSinkPack] = 1;

$MineLayerPackMax[mineammo] = 8;
$MineLayerPackMax[airmineammo] = 7;

$TeamItemMax[AirPlatformPack] = 10;
$TeamItemMax[LargeAirPlatPack] = 4;
$TeamItemMax[DeployableWallPack] = 8;
$TeamItemMax[ForceFieldPack] = 8;
$TeamItemMax[LargeFieldPack] = 4;
$TeamItemMax[FlagStandPack] = 6;

// ------------------------------------------------------

StaticShapeData AirPlatform
{
	shapeFile = "elevator6x6thin"; 
	debrisId = defaultDebrisMedium;
	maxDamage = 5.0;
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
	heading = "dDeployables";
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

// ------------------------------------------------------

StaticShapeData LargeAirPlatform
{
	shapeFile = "elevator16x16_octo"; 
	debrisId = defaultDebrisLarge;
	maxDamage = 20.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	mapFilter = 4;
      description = "Large Air Platform";
};

function LargeAirPlatform::onDestroyed(%this)
{	
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 1.0, 0.05, 20, 13, 3, 0.55, 0.30, 190, 100);
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeAirPlatPack"]--;
}

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
	heading = "dDeployables";
	imageType = LargeAirPlatPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.1;
	price = 150;
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
		%playerPos = GameBase::getPosition(%player);
		%flag = $teamFlag[GameBase::getTeam(%player)];
		%flagpos = gamebase::getPosition(%flag);
		if(Vector::getDistance(%flagpos, %playerpos) > 10)
		{
			if(Vector::getDistance(%flag.originalPosition, %playerpos) > 10)
			{
				%sensor = newObject("Large Air Platform","Staticshape",LargeAirPlatform,true); 
	   			addToSet("MissionCleanup", %sensor);				      
				GameBase::setTeam(%sensor,GameBase::getTeam(%player));
				GameBase::setRotation(%sensor,"0 0 0");// %rot
				GameBase::setPosition(%sensor,GameBase::getPosition(%player));
				Gamebase::setMapName(%sensor,"Large Air Platform" @  Client::getName(%client));
				Client::sendMessage(%sensor,0,"Large Air Platform deployed");
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%sensor) @ "LargeAirPlatPack"]++;
				echo("MSG: ",%client," deployed a Large Air Platform ");
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

// ------------------------------------------------------

StaticShapeData DeployableWall
{
	shapeFile = "newdoor5";
	debrisId = defaultDebrisSmall;
	maxDamage = 6.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
 	description = "Deployable Wall";
};

function DeployableWall::onDestroyed(%this)
{
	
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 24.0, 0.05, 10, 24, 24, 0.5, 0.3, 150, 70);
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableWallPack"]--;
}

ItemImageData DeployableWallPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData DeployableWallPack
{	
	description = "Deployable Wall";
	shapefile = "ammopack";
	classname = "Backpack";
	heading = "dDeployables";
	imageType = DeployableWallPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.1;
	price = 250;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableWallPack::onUse(%player,%item)
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

function DeployableWallPack::onDeploy(%player,%item,%pos)
{
	if (DeployableWallPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function DeployableWallPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{	
			%obj = getObjectType($los::object);
// ****
			%datobj = gamebase::getdataname($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %datobj == "AirPlatform" || %datobj == "LargeAirPlatform"){ 
// ****		
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
				{
					//if(checkDeployArea(%client,$los::position)){
						%playerPos = GameBase::getPosition(%player);
						%flag = $teamFlag[GameBase::getTeam(%player)];
						%flagpos = gamebase::getPosition(%flag);
						if(Vector::getDistance(%flagpos, %playerpos) > 14)
						{
							if(Vector::getDistance(%flag.originalPosition, %playerpos) > 14)
							{
								%sensor = newObject("Deployable Wall","StaticShape","DeployableWall",true);
	         	   					addToSet("MissionCleanup", %sensor);
								%rot = GameBase::getRotation(%player); 
								GameBase::setTeam(%sensor,GameBase::getTeam(%player));
								GameBase::setPosition(%sensor,$los::position);
								GameBase::setRotation(%sensor,%rot);
								Gamebase::setMapName(%sensor,%name);
								Client::sendMessage(%client,0,"Wall  deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%sensor) @ "DeployableWallPack"]++;
								echo("MSG: ",%client," deployed a Wall");	
								echo("wall pos = " @ $los::position);
								return true;
							}
							else
								Client::sendMessage(%client,0,"Nope, cant respawn your flag under walls.");
						}
						else
						{
								Client::sendMessage(%client,0,"You are too close to your flag, cant hide the flag in this mod.");
								return false;
						}
					//}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on terrain,buildings, and air platforms");			
		}		
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
}

// ------------------------------------------------------

StaticShapeData SmallForceField
{
	shapeFile = "forcefield_3x4";
	debrisId = defaultDebrisSmall;
	maxDamage = 6.0;
	isTranslucent = True;
	explosionId = debrisExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
 	description = "Small Force Field";
};

function SmallForceField::onDestroyed(%this)
{
	
	StaticShape::objectiveDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldPack"]--;
}

ItemImageData ForceFieldPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ForceFieldPack
{	
	description = "Small Force Field";
	shapefile = "ammopack";
	classname = "Backpack";
	heading = "dDeployables";
	imageType = ForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.1;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ForceFieldPack::onUse(%player,%item)
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

function ForceFieldPack::onDeploy(%player,%item,%pos)
{
	if (ForceFieldPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function ForceFieldPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{	
			%obj = getObjectType($los::object);
// ****
			%datobj = gamebase::getdataname($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %datobj == "AirPlatform" || %datobj == "LargeAirPlatform"){ 
// ****		
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
					{
						%playerPos = GameBase::getPosition(%player);
						%flag = $teamFlag[GameBase::getTeam(%player)];
						%flagpos = gamebase::getPosition(%flag);
						if(Vector::getDistance(%flagpos, %playerpos) > 3)
						{
							if(Vector::getDistance(%flag.originalPosition, %playerpos) > 3)
							{
								%sensor = newObject("Small Force Field","StaticShape","SmallForceField",true);
	         	   					addToSet("MissionCleanup", %sensor);
								%rot = GameBase::getRotation(%player); 
								GameBase::setTeam(%sensor,GameBase::getTeam(%player));
								GameBase::setPosition(%sensor,$los::position);
								GameBase::setRotation(%sensor,%rot);
								Gamebase::setMapName(%sensor,%name);
								Client::sendMessage(%client,0,"Small Force Field  deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%sensor) @ "ForceFieldPack"]++;
								echo("MSG: ",%client," deployed a Small Force Fieldl");
								return true;
							}
							else
								Client::sendMessage(%client,0,"Nope, cant respawn your flag under force fields.");
						}
						else
						{
							Client::sendMessage(%client,0,"You are too close to your flag, cant hide the flag in this mod.");
							return false;
						}
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on terrain,buildings, and air platforms");			
		}		
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

// ------------------------------------------------------

StaticShapeData LargeForceField
{
	shapeFile = "forcefield_4x8";
	debrisId = defaultDebrisSmall;
	maxDamage = 7.5;
	isTranslucent = True;
	explosionId = debrisExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
 	description = "Large Force Field";
};

function LargeForceField::onDestroyed(%this)
{
	
	StaticShape::objectiveDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeFieldPack"]--;
}

ItemImageData LargeFieldPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData LargeFieldPack
{	
	description = "Large Force Field";
	shapefile = "ammopack";
	classname = "Backpack";
	heading = "dDeployables";
	imageType = LargeFieldPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.1;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeFieldPack::onUse(%player,%item)
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

function LargeFieldPack::onDeploy(%player,%item,%pos)
{
	if (LargeFieldPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function LargeFieldPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{	
			%obj = getObjectType($los::object);
// ****
			%datobj = gamebase::getdataname($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %datobj == "AirPlatform" || %datobj == "LargeAirPlatform"){ 
// ****		
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
				{
					%playerPos = GameBase::getPosition(%player);
					%flag = $teamFlag[GameBase::getTeam(%player)];
					%flagpos = gamebase::getPosition(%flag);
					if(Vector::getDistance(%flagpos, %playerpos) > 6)
					{
						if(Vector::getDistance(%flag.originalPosition, %playerpos) > 6)
						{
							%sensor = newObject("Large Force Field","StaticShape","LargeForceField",true);
	         	   				addToSet("MissionCleanup", %sensor);
							%rot = GameBase::getRotation(%player); 
							GameBase::setTeam(%sensor,GameBase::getTeam(%player));
							GameBase::setPosition(%sensor,$los::position);
							GameBase::setRotation(%sensor,%rot);
							Gamebase::setMapName(%sensor,%name);
							Client::sendMessage(%client,0,"Large Force Field  deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%sensor) @ "LargeFieldPack"]++;
							echo("MSG: ",%client," deployed a Large Force Fieldl");
							return true;
						}
							else
								Client::sendMessage(%client,0,"Nope, cant respawn your flag under force fields.");
					}
					else
						Client::sendMessage(%client,0,"You are too close to your flag, cant hide the flag in this mod.");
						return false;
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on terrain,buildings, and air platforms");			
		}		
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

// ------------------------------------------------------

StaticShapeData DeployableFlagStand
{
   	description = "Deployable Flag Stand";
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	maxDamage = 3.0;
	shadowDetailMask = 4;
	mapFilter = 4;
	explosionId = debrisExpMedium;
	visibleToSensor = true;
};


function DeployableFlagstand::onDestroyed(%this)
{	
   
   StaticShape::objectiveDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "FlagStandPack"]--;
   %flag = %this.carryflag;
   if(%flag != "")
	{
		%flag.flagstand = "";
		schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	}
}

ItemImageData FlagstandPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData FlagstandPack
{	
	description = "Flag Stand";
	shapefile = "ammopack";
	classname = "Backpack";
	heading = "dDeployables";
	imageType = FlagstandPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.1;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FlagstandPack::onUse(%player,%item)
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

function FlagStandPack::onDeploy(%player,%item,%pos)
{
	if (FlagstandPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function FlagstandPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
			if (%obj == "InteriorShape") 
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
				{
					if(checkDeployArea(%client,$los::position)) 
					{
						%playerPos = GameBase::getPosition(%player);
						%flag = $teamFlag[GameBase::getTeam(%player)];
						%flagpos = %flag.originalposition;
						if(Vector::getDistance(%flagpos, %playerpos) < 70)
						{
							%rot = GameBase::getRotation(%player); 
							%sensor = newObject("","Staticshape",DeployableFlagstand,true);
	                    					addToSet("MissionCleanup", %sensor);
							GameBase::setTeam(%sensor,GameBase::getTeam(%player));
							GameBase::setPosition(%sensor,$los::position);
							GameBase::setRotation(%sensor,%rot);
							Gamebase::setMapName(%sensor,"Flagstand #" @ $totalNumFlagstands++ @ " " @ Client::getName(%client));
							Client::sendMessage(%client,0,"Flag stand deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "FlagstandPack"]++;
							echo("MSG: ",%client," deployed a Flag stand");
							return true;
						}	
						else
						{
							Client::sendMessage(%client,0,"You are too far away from the flags original position.");
							return false;
						}
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
}

function DeployableFlagstand::onCollision(%this,%object)
{
   if(%object.enterTime > getSimTime() - 3)
	return;
   %standTeam = GameBase::getTeam(%this);
   %playerTeam = GameBase::getTeam(%object);
   %playerClient = Player::getClient(%object);

   if(getObjectType(%object) != "Player" || %playerTeam != %standTeam || %object.carryflag == "") // %standteam == -1 ||
      return;

   %flag = %object.carryFlag;
   %flagTeam = GameBase::getTeam(%flag);
   if(%this.carryflag != "")
	return;

   %this.carryflag = %flag;
   %flag.carrier = -1;
   Item::hide(%flag, false);
   GameBase::setPosition(%flag, GameBase::getPosition(%this)); 
   playSound(SoundPickupBackpack, GameBase::getPosition(%this));

   %flag.flagStand = %this;
   Player::setItemCount(%object, Flag, 0);
   %object.carryFlag = "";
   %playerClient = Player::getClient(%object);
   Flag::clearWaypoint(%playerClient, true);
   if(getTeamName(%flag) == %playerTeam){
   	MessageAllExcept(%playerClient, 0,"The " @ getTeamName(%playerteam) @ " flag has been moved to a new position");
   	Client::sendMessage(%playerClient, 0, "You moved your flag.");
   }
   else {
	MessageAllExcept(%playerClient, 0,"The " @ getTeamName(%playerteam) @ " have set an enemy flag on a flagstand");
   	Client::sendMessage(%playerClient, 0, "You placed the enemy flag down.");
   }	
   %object.enterTime = getSimTime();
}

// --------------------------------------------------------------

ItemImageData CloakPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	sfxFire = SoundShieldOn;
 	maxEnergy = 10;
	firstPerson = false;
};

ItemData CloakPack
{
	description = "Cloaking Pack";
	shapeFile = "jetPack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = CloakPackImage;
	price = 300;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CloakPackImage::onActivate(%player,%imageSlot)
{
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
	Client::sendMessage(Player::getClient(%player),0,"Cloak On");
	gameBase::startFadeOut(%player);
}

function CloakPackImage::onDeactivate(%player,%imageSlot)
{
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	gameBase::startFadein(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloak Off");
	Player::trigger(%player,$BackpackSlot,false);
}

// --------------------------------------------------------------

ItemImageData RepairMakerPackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	//   mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData RepairMakerPack
{
	description = "Repair Kit Maker";
	shapeFile = "";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = RepairMakerPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 400;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RepairMakerPack::onDrop(%player, %item)
{
	if($matchStarted) 
	{
		%item = Item::onDrop(%player,%item);
	}
}

function RepairMakerPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") 
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) 
		{
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairMakerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{
		%energy = Gamebase::getEnergy(%player);
		if(%energy >=  40)
		{
			//spawn a repair kit in front of player
			%obj = newObject("","Item",repairkit,1,false);
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 	addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,15,false);
			%newenergy = %energy - 40;
			Gamebase::setEnergy(%player,%newenergy);			
		}
		else
			Client::sendMessage(%player,0,"Not enough energy to make a repair kit");
	}
}

//----------------------------------------------------------------------------

ItemImageData MineLayerPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	//   mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData MineLayerPack
{
	description = "Mine Layer Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = MineLayerPackImage;
	shadowDetailMask = 4;
	mass = 4.0;
	elasticity = 0.1;
	price = 300;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MineLayerPack::onDrop(%player, %item)
{
	if($matchStarted) 
	{
		%item = Item::onDrop(%player,%item);
		%pCountm = Player::getItemCount(%player,mineammo); 
		%pCountam = Player::getItemCount(%player,airmineammo);
		if(%pCountam > 3)
		{
			%num = %pCountam - 3;
			Player::decItemCount(%player,airmineammo,%num);
		}
		if(%pCountm > 4)
		{
			%num = %pCountm - 4;
			Player::decItemCount(%player,mineammo,%num);
		}
	}
}

function MineLayerPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") 
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) 
		{
			Item::playPickupSound(%this);
			//Player::incItemCount(%object,rpgammo,10); 
			Item::respawn(%this);
		}
	}
}

function fillMineLayerPack(%client) 
{
	%player = Client::getOwnedObject(%client);
	%num = Player::getItemCount(%player,mineammo);
	%numa = Player::getItemCount(%player,airmineammo);
	if(%num == 0 && %numa == 0)
		return;
	if(%num > 0 && %numa == 0)
		Player::incItemCount(%client,mineammo,11 - %num);
	else if(%numa > 0){
		Player::incItemCount(%client,airmineammo,10 - %numa);
		if(%num == 0)
			Player::incItemCount(%client,mineammo,1);
	}
}

// --------------------------------------------------------------

ItemImageData HeatSinkPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  
	minEnergy = 0;
	maxEnergy = 0;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	firstPerson = false;
};

ItemData HeatSinkPack
{
	description = "Heat Sink";
	shapeFile = "jetPack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = HeatSinkPackImage;
	price = 200;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = false;
};

function HeatSinkPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function HeatSinkPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

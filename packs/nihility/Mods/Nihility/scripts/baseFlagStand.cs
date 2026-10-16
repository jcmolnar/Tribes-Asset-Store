//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[FlagstandPack] = 1;

$TeamItemMax[FlagstandPack] = 5;

$ItemMax[larmor, FlagstandPack] = 0;	//Seraph
$ItemMax[lfemale, FlagstandPack] = 0;	//Seraph
$ItemMax[earmor, FlagstandPack] = 1;	//Slave
$ItemMax[efemale, FlagstandPack] = 1;	//Slave
$ItemMax[marmor, FlagstandPack] = 0;	//Pawn
$ItemMax[aarmor, FlagstandPack] = 1;	//Navigator
$ItemMax[darmor, FlagstandPack] = 0;	//Atomizer
$ItemMax[barmor, FlagstandPack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ FlagstandPack] = 0;
//	$TeamItemCount[1 @ FlagstandPack] = 0;
//	$TeamItemCount[2 @ FlagstandPack] = 0;
//	$TeamItemCount[3 @ FlagstandPack] = 0;
//	$TeamItemCount[4 @ FlagstandPack] = 0;
//	$TeamItemCount[5 @ FlagstandPack] = 0;
//	$TeamItemCount[6 @ FlagstandPack] = 0;
//	$TeamItemCount[7 @ FlagstandPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

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
	heading = "hDeployable Base Objects";
	imageType = FlagstandPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.1;
	price = 1000;
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
		if (GameBase::getLOSInfo(%player,10)) 
		{
			%obj = "InteriorShape";
			if (%obj == "InteriorShape") 
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
				{
					if(%obj == "InteriorShape") 
					{
						%playerPos = GameBase::getPosition(%player);
						%flag = $teamFlag[GameBase::getTeam(%player)];
						%flagpos = %flag.originalposition;
						if(Vector::getDistance(%flagpos, %playerpos) < 7000)
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
additem(PlatformPack);

//=========ArmorData.cs===============
$ItemMax[larmor, PlatformPack] = 0;
$ItemMax[marmor, PlatformPack] = 1;
$ItemMax[harmor, PlatformPack] = 1;
$ItemMax[lfemale, PlatformPack] = 0;
$ItemMax[mfemale, PlatformPack] = 1;
//====================================

//==========Station.cs===================================
$InvList[PlatformPack] = 1;
$RemoteInvList[PlatformPack] = 1;
//=======================================================

//=========StaticShape.cs=============================
StaticShapeData PlatformShape
{
	shapeFile = "elevator6X6thin";
	debrisId = defaultDebrisSmall;
	maxDamage = 10;
	isTranslucent = True;
	explosionId = debrisExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
 	description = "Platform";
};

function PlatformShape::onDestroyed(%this)
{
	
   StaticShape::objectiveDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "PlatformPack"]--;
}
//=======================================================

//=========Item.cs=============================================
$TeamItemMax[PlatformPack]= 50; // Max # A Team can buy/deploy
//=============================================================

//=========More Item.cs - The Data Block=======================
ItemImageData PlatformPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData PlatformPack
{	
	description = "Platform";
	shapefile = "ammopack";
	classname = "Backpack";
	heading = "dDeployables";
	imageType = PlatformPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.1;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlatformPack::onUse(%player,%item)
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

function PlatformPack::onDeploy(%player,%item,%pos)
{
	if (PlatformPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function PlatformPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{	
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") 
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
					{
						// if player is within 30 yards of flag cannot deploy
						%playerPos = GameBase::getPosition(%player);
						%flag = $teamFlag[GameBase::getTeam(%player)];
						%flagpos = gamebase::getPosition(%flag);
						echo("%flagpos " @ %flagpos);
						echo("%playerpos " @ %playerpos);
						if(Vector::getDistance(%flagpos, %playerpos) > 3)
						{
							%inv = newObject("","StaticShape","PlatformShape",true);
	         	   				addToSet("MissionCleanup", %inv);
							%rot = GameBase::getRotation(%player); 
							GameBase::setTeam(%inv,GameBase::getTeam(%player));
							GameBase::setPosition(%inv,$los::position);
							GameBase::setRotation(%inv,%rot);
							Gamebase::setMapName(%inv,%name);
							Client::sendMessage(%client,0,"Platform deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%inv) @ "PlatformPack"]++;
							echo("MSG: ",%client," deployed a platform");
							return true;
						}
						else
							Client::sendMessage(%client,0,"Look dumbass, you can't deyploy this close to the flag ");
							return false;
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
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
}
//==============================================================================================================================================

//=======Even more Item.cs Data(Reinit data)=========
$TeamItemCount[0 @ PlatformPack] = 0;
$TeamItemCount[1 @ PlatformPack] = 0;
$TeamItemCount[2 @ PlatformPack] = 0;
$TeamItemCount[3 @ PlatformPack] = 0;
$TeamItemCount[4 @ PlatformPack] = 0;
$TeamItemCount[5 @ PlatformPack] = 0;
$TeamItemCount[6 @ PlatformPack] = 0;
$TeamItemCount[7 @ PlatformPack] = 0;
//====================================================

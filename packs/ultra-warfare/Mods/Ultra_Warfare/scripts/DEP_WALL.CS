//=============================================================
//deployable wall
//=============================================================
$ItemMax[larmor, DeployableWallPack] = 0;
$ItemMax[lfemale, DeployableWallPack] = 0;
$ItemMax[marmor, DeployableWallPack] = 0;
$ItemMax[mfemale, DeployableWallPack] = 0;
$ItemMax[harmor, DeployableWallPack] = 1;
//==========================================
$InvList[DeployableWallPack] = 1;
$RemoteInvList[DeployableWallPack] = 1;
$TeamItemMax[DeployableWallPack] = 10;
//========================================================
StaticShapeData DeployableWall
{
	shapeFile = "newdoor5";
	debrisId = defaultDebrisSmall;
	maxDamage = 20;
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
	heading = "wDeployable Defense";
	imageType = DeployableWallPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.1;
	price = 0;
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
additem(BlastWallPack);

//=========ArmorData.cs===============
$ItemMax[larmor, BlastWallPack] = 0;
$ItemMax[marmor, BlastWallPack] = 1;
$ItemMax[harmor, BlastWallPack] = 1;
$ItemMax[lfemale, BlastWallPack] = 0;
$ItemMax[mfemale, BlastWallPack] = 1;
//====================================

//==========Station.cs===================================
$InvList[BlastWallPack] = 1;
$RemoteInvList[BlastWallPack] = 1;
//=======================================================

//=========StaticShape.cs=============================
StaticShapeData BlastWallShape
{
        shapeFile = "newdoor5";
        debrisId = defaultDebrisLarge;
        maxDamage = 50.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Blast Wall";
};

function BlastWallShape::onDestroyed(%this)
{
	
   StaticShape::objectiveDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "BlastWallPack"]--;
}
//=======================================================

//=========Item.cs=============================================
$TeamItemMax[BlastWallPack]= 20; // Max # A Team can buy/deploy
//=============================================================

//=========More Item.cs - The Data Block=======================
ItemImageData BlastWallPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData BlastWallPack
{	
	description = "BlastWall";
	shapefile = "ammopack";
	classname = "Backpack";
	heading = "dDeployables";
	imageType = BlastWallPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.1;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BlastWallPack::onUse(%player,%item)
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

function BlastWallPack::onDeploy(%player,%item,%pos)
{
	if (BlastWallPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function BlastWallPack::deployShape(%player,%item)
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
							%inv = newObject("","StaticShape","BlastWallShape",true);
	         	   				addToSet("MissionCleanup", %inv);
							%rot = GameBase::getRotation(%player); 
							GameBase::setTeam(%inv,GameBase::getTeam(%player));
							GameBase::setPosition(%inv,$los::position);
							GameBase::setRotation(%inv,%rot);
							Gamebase::setMapName(%inv,%name);
							Client::sendMessage(%client,0,"BlastWall deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%inv) @ "BlastWallPack"]++;
							echo("MSG: ",%client," deployed a Blast Wall");
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
$TeamItemCount[0 @ BlastWallPack] = 0;
$TeamItemCount[1 @ BlastWallPack] = 0;
$TeamItemCount[2 @ BlastWallPack] = 0;
$TeamItemCount[3 @ BlastWallPack] = 0;
$TeamItemCount[4 @ BlastWallPack] = 0;
$TeamItemCount[5 @ BlastWallPack] = 0;
$TeamItemCount[6 @ BlastWallPack] = 0;
$TeamItemCount[7 @ BlastWallPack] = 0;
//====================================================

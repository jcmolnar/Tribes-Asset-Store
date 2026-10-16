additem(ForceFieldPack);

//=========ArmorData.cs===============
$ItemMax[larmor, ForceFieldPack] = 0;
$ItemMax[marmor, ForceFieldPack] = 1;
$ItemMax[harmor, ForceFieldPack] = 1;
$ItemMax[lfemale, ForceFieldPack] = 0;
$ItemMax[mfemale, ForceFieldPack] = 1;
//====================================

//==========Station.cs===================================
$InvList[ForceFieldPack] = 1;
$RemoteInvList[ForceFieldPack] = 1;
//=======================================================

//=========StaticShape.cs=============================
StaticShapeData SmallForceField
{
	shapeFile = "forcefield_3x4";
	debrisId = defaultDebrisSmall;
	maxDamage = 10;
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
//=======================================================

//=========Item.cs=============================================
$TeamItemMax[ForceFieldPack]= 20; // Max # A Team can buy/deploy
//=============================================================

//=========More Item.cs - The Data Block=======================
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
							%inv = newObject("","StaticShape","SmallForceField",true);
	         	   				addToSet("MissionCleanup", %inv);
							%rot = GameBase::getRotation(%player); 
							GameBase::setTeam(%inv,GameBase::getTeam(%player));
							GameBase::setPosition(%inv,$los::position);
							GameBase::setRotation(%inv,%rot);
							Gamebase::setMapName(%inv,%name);
							Client::sendMessage(%client,0,"Small Force Field  deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%inv) @ "ForceFieldPack"]++;
							echo("MSG: ",%client," deployed a Small Force Field");
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
$TeamItemCount[0 @ ForceFieldPack] = 0;
$TeamItemCount[1 @ ForceFieldPack] = 0;
$TeamItemCount[2 @ ForceFieldPack] = 0;
$TeamItemCount[3 @ ForceFieldPack] = 0;
$TeamItemCount[4 @ ForceFieldPack] = 0;
$TeamItemCount[5 @ ForceFieldPack] = 0;
$TeamItemCount[6 @ ForceFieldPack] = 0;
$TeamItemCount[7 @ ForceFieldPack] = 0;
//====================================================

additem(ForceFieldDoorPack);

//=========ArmorData.cs===============
$ItemMax[larmor, ForceFieldDoorPack] = 0;
$ItemMax[marmor, ForceFieldDoorPack] = 1;
$ItemMax[harmor, ForceFieldDoorPack] = 1;
$ItemMax[lfemale, ForceFieldDoorPack] = 0;
$ItemMax[mfemale, ForceFieldDoorPack] = 1;
//====================================

//==========Station.cs===================================
$InvList[ForceFieldDoorPack] = 1;
$RemoteInvList[ForceFieldDoorPack] = 1;
//=======================================================

//=========StaticShape.cs=============================
StaticShapeData lgbForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_4x14";
maxDamage = 30;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 1;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "ForceField Door";
};
function lgbForceFieldShape::Destruct(%this)
{
lgbForceFieldShape::doDamage(%this);
}
function lgbForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function lgbForceFieldShape::onDestroyed(%this)
{
lgbForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldDoorPack"]--;
}
function lgbForceFieldShape::onCollision(%this,%obj)
{
if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
lgbForceFieldShape::openDoor(%this);
return;
}
function lgbForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.10);
schedule("lgbForceFieldShape::closeDoor("@%this@");",4);
}
function lgbForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.10);

}

function lgbForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("lgbForceFieldShape::closeDoor("@%this@");",4);
}
//=======================================================

//=========Item.cs=============================================
$TeamItemMax[ForceFieldDoorPack]= 20; // Max # A Team can buy/deploy
//=============================================================

//=========More Item.cs - The Data Block=======================
ItemImageData ForceFieldDoorPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ForceFieldDoorPack
{	
	description = "Force Field Door";
	shapefile = "ammopack";
	classname = "Backpack";
	heading = "dDeployables";
	imageType = ForceFieldDoorPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.1;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ForceFieldDoorPack::onUse(%player,%item)
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

function ForceFieldDoorPack::onDeploy(%player,%item,%pos)
{
	if (ForceFieldDoorPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function ForceFieldDoorPack::deployShape(%player,%item)
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
							%inv = newObject("","StaticShape","lgbForceFieldShape",true);
	         	   				addToSet("MissionCleanup", %inv);
							%rot = GameBase::getRotation(%player); 
							GameBase::setTeam(%inv,GameBase::getTeam(%player));
							GameBase::setPosition(%inv,$los::position);
							GameBase::setRotation(%inv,%rot);
							Gamebase::setMapName(%inv,%name);
							Client::sendMessage(%client,0," Force Field Door deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%inv) @ "ForceFieldDoorPack"]++;
							echo("MSG: ",%client," deployed a Force Field Door.");
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
$TeamItemCount[0 @ ForceFieldDoorPack] = 0;
$TeamItemCount[1 @ ForceFieldDoorPack] = 0;
$TeamItemCount[2 @ ForceFieldDoorPack] = 0;
$TeamItemCount[3 @ ForceFieldDoorPack] = 0;
$TeamItemCount[4 @ ForceFieldDoorPack] = 0;
$TeamItemCount[5 @ ForceFieldDoorPack] = 0;
$TeamItemCount[6 @ ForceFieldDoorPack] = 0;
$TeamItemCount[7 @ ForceFieldDoorPack] = 0;
//====================================================

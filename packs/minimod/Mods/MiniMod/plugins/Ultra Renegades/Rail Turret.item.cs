// This is a MiniMod plugin
// This is the Rail Turret From Ultra-Renegades.
// Code donated by URG_thrash, decompressed/ported by Dewy.

$TeamItemMax[RailTurret] = 3; 

ItemImageData RailTurretImage
{
shapeFile = "remoteturret";
mountPoint = 2;
mountOffset = { 0, -0.12, -0.1 };
mountRotation = { 0, 0, 0 };
mass = 2.5;
firstPerson = false;
}; 

ItemData RailTurret
{
description = "Rail Turret";
shapeFile = "remoteturret";
className = "Backpack";
heading = "dDeployables";
imageType = RailTurretImage;
shadowDetailMask = 4;
mass = 2.0;
elasticity = 0.2;
price = 850;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
}; 

function RailTurret::onUse(%player,%item)
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

function RailTurret::onDeploy(%player,%item,%pos)
{
	if (RailTurret::deployShape(%player,%item))
		{
		Player::decItemCount(%player,%item);
		}
}

function RailTurret::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "The Rail Turret has been modfied to fire automatically.");
}

function CountObjects(%set,%name,%num)
{
%count = 0; for(%i=0;%i<%num;%i++)
	{
	%obj=Group::getObject(%set,%i);
	if(GameBase::getDataName(Group::getObject(%set,%i)) == %name)
	%count++;
	}
return %count;
}

function RailTurret::deployShape(%player,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
	if (GameBase::getLOSInfo(%player,3))
		{
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
			{
			%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
			%num = CountObjects(%set,"DeployableVulcan",%num);
			deleteObject(%set);
			if($MaxNumTurretsInBox > %num)
				{
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
				%num = CountObjects(%set,"DeployablePlasma",%num);
				deleteObject(%set); if(0 == %num)
					{
					if (Vector::dot($los::normal,"0 0 1") > 0.7)
						{
						if(checkDeployArea(%client,$los::position))
							{
							%rot = GameBase::getRotation(%player);
							%turret = newObject("hellfiregun","Turret",DeployableRail,true);
							addToSet("MissionCleanup", %turret);
							GameBase::setTeam(%turret,GameBase::getTeam(%player));
							GameBase::setPosition(%turret,$los::position);
							GameBase::setRotation(%turret,%rot);
							Gamebase::setMapName(%turret,"Rail Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
							Client::sendMessage(%client,0,"Rail Turret deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "RailTurret"]++; return true;
							}
						}
						else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					}
					else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
				else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

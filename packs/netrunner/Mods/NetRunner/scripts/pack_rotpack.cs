$InvList[RotPack] = 1;
$RemoteInvList[RotPack] = 1;

addDeployable(RotPack, 10);

ItemImageData RotPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData RotPack
{
	description = "Rotweiler ICE";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHead[iTurr];
	imageType = RotPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RotPack::onUse(%player,%item)
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

function RotPack::onDeploy(%player,%item,%pos)
{
	if (RotPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++)
	{
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++;
	}
	return %count;
}

function RotPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape")
			{
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableRot",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num)
				{
					%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableRot",%num);
					deleteObject(%set);
					if(0 == %num)
					{
						if (Vector::dot($los::normal,"0 0 1") > 0.7)
						{
							if(checkDeployArea(%client,$los::position))
							{
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("Rotweiler","Turret",DeployableRot,true);
								addToSet("MissionCleanup", %turret);
								addToSet(deploy @ %client, %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Rotweiler#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Rotweiler deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "RotPack"]++;
								echo("MSG: ",%client," deployed a Rotweiler");
//Remote turrets - kill points to player that deploy them
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
								%turret.ownerclient = %client;
								return true;
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

function checkDeployArea(%client,%pos)
{
	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(!%num)
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player")
	{
		%obj = Group::getObject(%set,0);
		if(Player::getClient(%obj) == %client) Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	deleteObject(%set);
	return 0;
}

//--------------------------------------------

TurretData DeployableRot
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = RotweilerICE;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 50;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Rotweiler ICE";
	damageSkinData = "objectDamageSkins";
};

function DeployableRot::onAdd(%this)
{
	schedule("DeployableRot::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Rotweiler");
	}
}

function DeployableRot::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableRot::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableRot::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "RotPack"]--;
}

// Override base class just in case.
function DeployableRot::onPower(%this,%power,%generator) 
{
}

function DeployableRot::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}
$InvList[OmniPack] = 1;
$RemoteInvList[OmniPack] = 1;

addDeployable(OmniPack, 10);

ItemImageData OmniPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData OmniPack
{
	description = "Omni ICE";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHead[iTurr];
	imageType = OmniPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function OmniPack::onUse(%player,%item)
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

function OmniPack::onDeploy(%player,%item,%pos)
{
	if (OmniPack::deployShape(%player,%item))
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

function OmniPack::deployShape(%player,%item)
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
				%num = CountObjects(%set,"DeployableOmni",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num)
				{
					%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableOmni",%num);
					deleteObject(%set);
					if(0 == %num)
					{
						if (Vector::dot($los::normal,"0 0 1") > 0.7)
						{
							if(checkDeployArea(%client,$los::position))
							{
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("Omni","Turret",DeployableOmni,true);
								addToSet("MissionCleanup", %turret);
								addToSet(deploy @ %client, %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Omni#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Omni deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "OmniPack"]++;
								echo("MSG: ",%client," deployed a Omni");
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

TurretData DeployableOmni
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = TraceICE;
	maxDamage = 0.65;
	maxEnergy = 100;
	minGunEnergy = 60;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	speed = 10.0;
	speedModifier = 0.01;
	range = 100;
	gunRange = 300;
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
	description = "Omni ICE";
	damageSkinData = "objectDamageSkins";
	targetableFovRatio = 1.0;
};

function DeployableOmni::onAdd(%this)
{
	schedule("DeployableOmni::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Omni");
	}
}

function DeployableOmni::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableOmni::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableOmni::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "OmniPack"]--;
}

// Override base class just in case.
function DeployableOmni::onPower(%this,%power,%generator) 
{
}

function DeployableOmni::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

function DeployableOmni::verifyTarget(%this,%target)
{
	if (GameBase::virtual(%target, "getHeatFactor") >= 0.1) return "True";
	else return "False";
}
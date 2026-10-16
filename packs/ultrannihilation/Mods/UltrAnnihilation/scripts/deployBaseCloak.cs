$InvList[BaseCloakPack] = 1;
$MobileInvList[BaseCloakPack] = 0;
$RemoteInvList[BaseCloakPack] = 0;

$CanAlwaysTeamDestroy[BaseCloakPack] = 1;

ItemImageData BaseCloakPackImage
{	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData BaseCloakPack
{	description = "Base Cloaking Device";
	shapeFile = "magcargo";
	className = "Backpack";
  	heading = $InvHead[ihDOb];
	imageType = BaseCloakPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function deployBaseCloak::Initialize()
{	$TeamItemCount[0 @ BaseCloakPack] = 0; 
	$TeamItemCount[1 @ BaseCloakPack] = 0; 
	$TeamItemCount[2 @ BaseCloakPack] = 0;
	$TeamItemCount[3 @ BaseCloakPack] = 0;
	$TeamItemCount[4 @ BaseCloakPack] = 0;
	$TeamItemCount[5 @ BaseCloakPack] = 0;
	$TeamItemCount[6 @ BaseCloakPack] = 0;
	$TeamItemCount[7 @ BaseCloakPack] = 0;
}

function BaseCloakPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{	Player::deployItem(%player,%item);
	}
}

function BaseCloakPack::onDeploy(%player,%item,%pos)
{	if (BaseCloakPack::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);
	}
}

function BaseCloakPack::deployShape(%player,%item)
{	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{	if (GameBase::getLOSInfo(%player,999))
		{	%obj = getObjectType($los::object);
			if (%obj == "InteriorShape")
			{	if (Vector::dot($los::normal,"0 0 1") > 0.3)
				{	if(checkDeployArea(%client,Vector::add($los::position, "0.2 0.2 0")))
					{	%rot = GameBase::getRotation(%player); 
						%turret = newObject("BaseCloak","Turret",BaseCloak,true);
                 				addToSet("MissionCleanup", %turret);
						GameBase::setTeam(%turret,GameBase::getTeam(%player));
						GameBase::setPosition(%turret,$los::position);
						GameBase::setRotation(%turret,%rot);
						Gamebase::setMapName(%turret,"Base Cloaking Device");
						Client::sendMessage(%client,0,"Base Cloaking Device deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "BaseCloakPack"]++;
						echo("MSG: ",%client," deployed an Base Cloaking Device");
						//GameBase::setDamageLevel(%turret, 0.3 * BaseCloak.maxDamage);
						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy in buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}


TurretData BaseCloak
{	className = "Turret";
	shapeFile = "magcargo";
	maxDamage = 2;
	maxEnergy = 2;
	//minGunEnergy = 6;
	//maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	//range = 10;
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Base Cloaking Device";
	damageSkinData = "objectDamageSkins";
};

function BaseCloak::onAdd(%this)
{	schedule("BaseCloak::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") 
	{	GameBase::setMapName (%this, "Base Cloaking Device");
	}
}

function BaseCloak::deploy(%this)
{	GameBase::playSequence(%this,1,"deploy");
}

function BaseCloak::onEndSequence(%this,%thread)
{	GameBase::setActive(%this,true);
}

function BaseCloak::onDisabled(%this)
{	Turret::onDisabled(%this);
	%num = Group::objectCount(%this.set);
	for(%i=%num-1; %i >= 0; %i--)
	{	%obj = Group::getObject(%this.set, %i);
		GameBase::startFadeIn(%obj);
		%obj.cloaked = 0;
	}
	deleteObject(%this.set);
}
function BaseCloak::onDestroyed(%this)
{	BaseCloak::onDisabled(%this);
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "BaseCloakPack"]--;
  	deleteObject(%this.set);
}

// Override base class just in case.

function BaseCloak::onPower(%this,%power,%generator) 
{
}

function BaseCloak::onEnabled(%this) 
{	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);

	%Set = newObject("set",SimSet); 
	addToSet("MissionCleanup", %Set);
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 50,0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
		{
			//don't cloak enemies or the box itself
		}
		else
		{
			GameBase::startFadeOut(%obj);
			%obj.cloaked = 1;
		}
	}

	%this.set = %Set;

	schedule("BaseCloak::checkBaseCloak(" @ %this @ ");", 0.1, %this);

}	

function BaseCloak::checkBaseCloak(%this)
{	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	%this.evenodd = !%this.evenodd; //switches from 1 to 0... tells every other check... used to check if in both new & old sets

	%Set = newObject("set",SimSet); 
	addToSet("MissionCleanup", %Set);
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 50,0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
		{	%obj = Group::getObject(%Set, %i);
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
			{	//don't cloak enemies or the box itself
			}
			else
			{	GameBase::startFadeOut(%obj);
				%obj.cloaked = 1 + %this.evenodd; //1 half the time & 2 other half... used to check if in this set while searching the old set
		}
	}

	%num = Group::objectCount(%this.set);

	for(%j; %j < %num; %j++)
	{	%obj = Group::getObject(%this.set, %j);
		if(%obj == %this || GameBase::getTeam(%obj) != GameBase::getTeam(%this))
		{
			//don't bother checking the other team or the box itself; they're not cloaked
		}
		else if(%obj.cloaked != (%this.evenodd + 1)) //if different then new set
		{
			%obj.cloaked = 0;
			if(%obj.cloakPack == 0 && %obj.cloakGun == 0) GameBase::startFadeIn(%obj); //then decloak it
		}
	}

	deleteObject(%this.set); //delete the old set
	%this.set = %Set; //and replace with new set

	schedule("BaseCloak::checkBaseCloak(" @ %this @ ");", 5.0, %this); //then recheck in 5 seconds
}
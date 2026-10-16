$InvList[FlameTurretPack] = 1;
$MobileInvList[FlameTurretPack] = 1;
$RemoteInvList[FlameTurretPack] = 1;
AddItem(FlameTurretPack);

$CanAlwaysTeamDestroy[FlameTurret] = 1;

function deployFlameTurret::Initialize()
{
	$TeamItemCount[0 @ FlameTurretPack] = 0;
	$TeamItemCount[1 @ FlameTurretPack] = 0;
	$TeamItemCount[2 @ FlameTurretPack] = 0;
	$TeamItemCount[3 @ FlameTurretPack] = 0;
	$TeamItemCount[4 @ FlameTurretPack] = 0;
	$TeamItemCount[5 @ FlameTurretPack] = 0;
	$TeamItemCount[6 @ FlameTurretPack] = 0;
	$TeamItemCount[7 @ FlameTurretPack] = 0;
}

ItemImageData FlameTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1.6;
	firstPerson = false;
};

ItemData FlameTurretPack
{
	description = "Flame Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading =  $InvHead[ihTur];
	imageType = FlameTurretPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function FlameTurretPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function FlameTurretPack::onDeploy(%player,%item,%pos)
{
	if(FlameTurretPack::deployShape(%player,%item)&& !$build)
		Player::decItemCount(%player,%item);
}

function FlameTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item] && !$build)
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3.5))
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	if(GameBase::getLOSInfo(%player,2.75))
	{
		Client::sendMessage(%client,0,"Deploy position is too close");
		return false;
	}

// check if object is in motion, for dropships and jail cell -plasmatic
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
		
	if(getNumTeams()-1 == 2)
	{
		%playerTeam = Client::getTeam(%client);
		if(%playerTeam == 0)
			%enemyTeam = 1;
		else if(%playerTeam == 1)
			%enemyTeam = 0;
		if(((Vector::getDistance($teamFlag[%enemyTeam].originalPosition, $los::position)) < ($FlagDistance * 0.4)) && ($FlagDistance != 0)) 
		{
			Client::sendMessage(%client,0,"You are too close to the enemy flag~waccess_denied.wav");
			return false;
		}
	}
	%obj = getObjectType($los::object);
	if(%obj != "InteriorShape")
	{
		Client::sendMessage(%client,0,"Can only deploy in buildings");
		return false;
	}
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
	%num = CountTurrets(%set, %num);
	deleteObject(%set);
	if(%num > $MaxNumTurretsInBox) 
	{
		Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
		return;
	}
	%set = newObject("set",SimSet);
	%Mask = $StaticObjectType;
	%num = containerBoxFillSet(%set, $StaticObjectType, $los::position, $TurretBoxMinLength, $TurretBoxMinWidth, $TurretBoxMinHeight, 0);
	%num = CountObjects(%set, "FlameTurret", %num);
	deleteObject(%set);
	if(%num) 
	{	
		Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
		return;
	}
	if(Vector::dot($los::normal,"0 0 1") <= 0.7)
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(!checkInvDeployArea(%client,$los::position))
	{
		Client::sendMessage(%client, 0, "Cannot deploy. Item in way");
		return false;
	}
	%rot = GameBase::getRotation(%player);
	%turret = newObject("Flame Turret","Turret",FlameTurret,true);
	%turret.cloakable = true;
	NukeList(%turret);
	addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	Gamebase::setMapName(%turret,"Flame Turret " @ Client::getName(%client));

	%cyl = newObject("Flame Turret Fuel","StaticShape",Canister,true);
	%cyl.cloakable = true;
	NukeList(%cyl);
	addToSet("MissionCleanup", %cyl);
	GameBase::setTeam(%cyl,GameBase::getTeam(%player));
	%backward = Vector::neg(Vector::getFromRot(%rot, 0.8)); //meaning backwards a little bit.

	GameBase::setPosition(%cyl,Vector::add($los::position, %backward));
	GameBase::setRotation(%cyl,%rot);
	Gamebase::setMapName(%cyl,"Flame Turret Fuel");

	%turret.cyl = %cyl;
	%cyl.turret = %turret;

	$turret::count++;
	%obj.deployer = %client;
	Client::sendMessage(%client,0,"Flame Turret deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "FlameTurretPack"]++;
	echo("MSG: ",%client," deployed an Flame Turret");
	//	Remote turrets - kill points to player that deploy them
	Client::setOwnedObject(%client, %turret);
	Client::setOwnedObject(%client, %player);
	return true;
}

TurretData FlameTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = FlameShell;
	maxDamage = 1.05;
	maxEnergy = 30;
	minGunEnergy = 3;
	maxGunEnergy = 3;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.02;
	speed = 2.0;
	speedModifier = 1.5;
	range = 20;
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = false;
	pinger = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_Radar";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireFlamer;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Flame Turret";
	damageSkinData = "objectDamageSkins";
};

function FlameTurret::onAdd(%this)
{
	schedule("FlameTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Flame Turret");
}

function FlameTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function FlameTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function FlameTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	%this.OrgTeam = "";
  	$TeamItemCount[GameBase::getTeam(%this) @ "FlameTurretPack"]--;
	GameBase::setDamageLevel(%this.cyl, 0.6);
}

// Override base class just in case.
function FlameTurret::onPower(%this,%power,%generator)
{
}

function FlameTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

StaticShapeData Canister
{
	description = "Flame Turret Fuel";
	shapeFile = "liqcyl";
	className = "Decoration";
	debrisId = flashDebrisMedium;
	maxDamage = 1.05;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
};

function Canister::onDestroyed(%this)
{
	GameBase::stopSequence(%this,0);
	StaticShape::objectiveDestroyed(%this);
	%this.cloakable = "";
	%this.nuetron = "";
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
	GameBase::setDamageLevel(%this.turret, 0.6);
}

// Override base class just in case.
function Canister::onPower(%this,%power,%generator)
{
	if(%power) 
		GameBase::playSequence(%this,0,"power");
	else 
		GameBase::stopSequence(%this,0);
}

function Canister::onEnabled(%this)
{
	if(GameBase::isPowered(%this)) 
		GameBase::playSequence(%this,0,"power");
}

function Canister::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
}
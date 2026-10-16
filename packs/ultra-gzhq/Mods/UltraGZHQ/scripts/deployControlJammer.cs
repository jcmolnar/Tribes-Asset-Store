$InvList[ControlJammerPack] = 1;
$MobileInvList[ControlJammerPack] = 0;
$RemoteInvList[ControlJammerPack] = 0;
AddItem(ControlJammerPack);

$CanAlwaysTeamDestroy[ControlJammer] = 1;

ItemImageData ControlJammerPackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ControlJammerPack
{
	description = "Control Jammer Device";
	shapeFile = "magcargo";
	className = "Backpack";
  	heading = $InvHead[ihDOb];
	imageType = ControlJammerPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function deployControlJammer::Initialize()
{
	$TeamItemCount[0 @ ControlJammerPack] = 0; 
	$TeamItemCount[1 @ ControlJammerPack] = 0; 
	$TeamItemCount[2 @ ControlJammerPack] = 0;
	$TeamItemCount[3 @ ControlJammerPack] = 0;
	$TeamItemCount[4 @ ControlJammerPack] = 0;
	$TeamItemCount[5 @ ControlJammerPack] = 0;
	$TeamItemCount[6 @ ControlJammerPack] = 0;
	$TeamItemCount[7 @ ControlJammerPack] = 0;
}

function ControlJammerPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function ControlJammerPack::onDeploy(%player,%item,%pos)
{
	if(ControlJammerPack::deployShape(%player,%item)&& !$build)
	{
		Player::decItemCount(%player,%item);
	}
}

function ControlJammerPack::deployShape(%player,%item)
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
	%obj = getObjectType($los::object);
	if(%obj != "InteriorShape")
	{
		Client::sendMessage(%client,0,"Can only deploy in buildings");
		return false;
	}

// check if object is in motion, for dropships and jail cell 
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
	
	if(Vector::dot($los::normal,"0 0 1") <= 0.7)
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(!checkInvDeployArea(%client,Vector::add($los::position, "0.2 0.2 0")))
	{
		Client::sendMessage(%client,0,"Not enought room to deploy here.");
		return false;
	}
	%rot = GameBase::getRotation(%player); 
	%turret = newObject("ControlJammer","Turret",ControlJammer,true);
	NukeList(%turret);
	%turret.cloakable = true;
	addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	Gamebase::setMapName(%turret,"Control Jammer Device");
	Client::sendMessage(%client,0,"Control Jammer Device deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "ControlJammerPack"]++;
	echo("MSG: ",%client," deployed an Control Jammer Device");
	return true;
}


TurretData ControlJammer
{
	className = "Turret";
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
	description = "Command Jammer Device";
	damageSkinData = "objectDamageSkins";
};

function ControlJammer::onAdd(%this)
{
	schedule("ControlJammer::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Command Jammer Device");
}

function ControlJammer::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ControlJammer::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function ControlJammer::onDisabled(%this)
{
	Turret::onDisabled(%this);
}

function ControlJammer::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	%this.OrgTeam = "";
  	$TeamItemCount[GameBase::getTeam(%this) @ "ControlJammerPack"]--;
}

// Override base class just in case.

function ControlJammer::onPower(%this,%power,%generator) 
{
}

function ControlJammer::onEnabled(%this) 
{	
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
	schedule("ControlJammer::checkControlJammer(" @ %this @ ");", 0.1, %this);
}	

function ControlJammer::checkControlJammer(%this)
{	
	if(GameBase::getDamageState(%this) != "Enabled")
		return;
	%Set = newObject("set",SimSet);
	addToSet("MissionCleanup", %Set);
	%Pos = GameBase::getPosition(%this); 
	%Mask = $VehicleObjectType;
	containerBoxFillSet(%Set, %Mask, %Pos, 250, 250, 150,0);
	%num = Group::objectCount(%Set);
	for(%i = 0; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
		{
			%name = GameBase::getDataName(%obj);
			if(%name == "OSMissile" || %name == "ProbeDroid" || %name == "SuicideDroid")
			{
				
				%client = GameBase::getControlClient(%obj);
				%player = Client::getOwnedObject(%client);
				GameBase::applyDamage(%player, $EnergyDamageType, 0.2, "0 0 0", "0 0 0", "0 0 0", %this);
				client::sendmessage(%client, 1,"You have been damaged by remote control feedback~waccess_denied.wav");
				GameBase::setDamageLevel(%obj, 1000);
			}
		}
	}
	deleteObject(%Set);
	%dlev = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this, %dlev+0.0015);
	schedule("ControlJammer::checkControlJammer(" @ %this @ ");", 1, %this);
}
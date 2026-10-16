$InvList[AlarmPack] = 1;
$MobileInvList[AlarmPack] = 1;
$RemoteInvList[AlarmPack] = 1;
AddItem(AlarmPack);

$CanAlwaysTeamDestroy[DeployableCat] = 1;
$TeamItemMax[AlarmPack] = 10;
function DeployAlarm::Initialize()
{
	$TeamItemCount[0 @ AlarmPack] = 0;
	$TeamItemCount[1 @ AlarmPack] = 0;
	$TeamItemCount[2 @ AlarmPack] = 0;
	$TeamItemCount[3 @ AlarmPack] = 0;
	$TeamItemCount[4 @ AlarmPack] = 0;
	$TeamItemCount[5 @ AlarmPack] = 0;
	$TeamItemCount[6 @ AlarmPack] = 0;
	$TeamItemCount[7 @ AlarmPack] = 0;
}

ItemImageData AlarmPackImage 
{
	shapeFile = "shieldPack";	//sensor_small";
	mountPoint = 2;
//	mountOffset = { 0, 0, 0.1 };
//	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData AlarmPack 
{
	description = "Spy Sensor";
	shapeFile = "shieldPack";	//sensor_small";
	className = "Backpack";
	heading = $InvHead[ihDSe];
	imageType = AlarmPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AlarmPack::onUse(%player,%item) 
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function AlarmPack::onDeploy(%player,%item,%pos) 
{
	if(AlarmPack::deployShape(%player,%item)) 
	{
		if(!$build)Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "AlarmPack"]++;
	}
}

function AlarmPack::deployShape(%player,%item) 
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item] && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain" && %obj != "InteriorShape" && GameBase::getDataName($los::object) != "DeployablePlatform") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}
// check if object is in motion, for dropships and jail cell 
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}		
	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	%xpos = getWord($los::position,0);
	%ypos = getWord($los::position,1);
	%zpos = getWord($los::position,2);
	if(Vector::dot($los::normal,"0 0 1") > 0.6) 
		{
		%rot = "0 0 " @ %zRot;
		%zpos += 0.05;//floor
		}
	else 
	{	if(Vector::dot($los::normal,"0 0 -1") > 0.6) 
			{
			%rot = "3.14159 0 " @ %zRot;
			%zpos -= 0.05;//ceiling
			}
		else 	{
			%rot = Vector::getRotation($los::normal);

			//wall
			%xopos = getWord($los::normal,0);
			%yopos = getWord($los::normal,1);

			%xpos = %xpos + %xopos/10;
			%ypos = %ypos + %yopos/10;

			}
	}
	%pos = %xpos@" "@%ypos@" "@%zpos;
	if(!checkDeployArea(%client,$los::position)) 
	{
		return false;
	}
	%rot = vector::add(%rot,"-1.57 0 0");

	%mSensor = newObject("DeployableKitty","Turret",DeployableCat,true);
	NukeList(%mSensor);
	addToSet("MissionCleanup", %mSensor);
	%PlayerTeam = GameBase::getTeam(%player);
	if(%PlayerTeam == 0) 	%catTeam = 1;	
		else %catTeam = 0;	
	%TeamNum = getNumTeams()-1;	//
	GameBase::setTeam(%mSensor,%TeamNum);		//%catTeam
	%mSensor.CatTeam = %PlayerTeam;
	GameBase::setRotation(%mSensor,%rot);
	GameBase::setPosition(%mSensor,%pos);
	Gamebase::setMapName(%mSensor,"Spy Sensor #"@$TeamItemCount[GameBase::getTeam(%player) @ %item]+1);
	Client::sendMessage(%client,0,"Spy Sensor deployed");
	playSound(SoundPickupBackpack,$los::position);
	echo("MSG: ",%client," deployed a Spy Sensor");
	return true;
}

TurretData DeployableCat
{
	className = "Turret";
	shapeFile = "shieldPack";	//sensor_small"; //"remoteturret";
	projectileType = SeekerLaser;
	maxDamage = 2.50;
	maxEnergy = 300;
	minGunEnergy = 90;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.5;	//2.5
	speed = 0.5;		//0.5
	speedModifier = 1.0;	//1.0
	range = 15;
	visibleToSensor = false;	//true;
//	shadowDetailMask = 4;
	dopplerVelocity = 1;	//0;
	castLOS = false;	//true;
	supression = false;
	supressable = false;
	pinger = false;		//true;
//	mapFilter = 2;
//	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
//	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Cat";
	damageSkinData = "objectDamageSkins";
};

function DeployableCat::verifyTarget(%this,%target)
{
	if (getSimTime() - $AlarmTime[%this] > 5)
	{
		%thispos = GameBase::getPosition(%this);
		%targetpos = GameBase::getPosition(%target);
		%dist = Vector::getDistance(%thispos, %targetpos);
		%clientId = Player::getClient(%target);
		if(%dist < 25 && %clientId.isSpy && %this.CatTeam == gamebase::getteam(%target)) 
		{		
			echo("Distance to target is " @ %dist);
			$AlarmTime[%this] = getSimTime();
			%team =gamebase::getteam(%this);
			%client = Player::getClient(%target);
			TeamMessages(0, %this.CatTeam, Gamebase::getMapName(%this)@" has detected chameleon " @ Client::getName(%client));	
			if($debug)
				echo(GameBase::GetMapName(%this) @ " has detected spy" @ Client::getName(%client));
			return false;
		}
		return false;
	}
}

function DeployableCat::onAdd(%this)
{
	schedule("DeployableCat::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Spy Sensor");
	}
}

function DeployableCat::deploy(%this)
{
	//GameBase::playSequence(%this,1,"deploy");
	GameBase::setActive(%this,true);
}

//function DeployableCat::onEndSequence(%this,%thread)
//{
//	GameBase::setActive(%this,true);
//}

function DeployableCat::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	%this.OrgTeam = "";
  	$TeamItemCount[GameBase::getTeam(%this) @ "BaseAlarm"]--;
}



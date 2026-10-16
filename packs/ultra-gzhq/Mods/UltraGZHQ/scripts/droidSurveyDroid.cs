$InvList[SurveyDroidPack] = 1;
$MobileInvList[SurveyDroidPack] = 1;
$RemoteInvList[SurveyDroidPack] = 1;
AddItem(SurveyDroidPack);

ItemImageData SurveyDroidPackImage
{
	shapeFile = "ammopack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = 4;
 	maxEnergy = 4.5;
	firstPerson = false;
};

ItemData SurveyDroidPack
{
	description = "Survey Droid";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = $InvHead[ihDro];
	shadowDetailMask = 4;
	imageType = SurveyDroidPackImage;
	mass = 0.5;
	price = 200;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

FlierData SurveyDroid
{
	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
	className = "Vehicle";
	shapeFile = "camera";
	//shieldShapeName = "shield_medium";
	mass = 0.001;
	drag = 1.0;
	density = 1.2;
	maxBank = 7;
	maxPitch = 12.5;
	maxSpeed = 30;
	//maxSideSpeed = 100;
	minSpeed = -15;
	lift = 1.0;
	maxAlt = 20000;
	maxVertical = 1;
	maxDamage = 0.0125;
	damageLevel = {1.0, 1.0};
	maxEnergy = 50;
	accel = 1.0;
	groundDamageScale = 1; //0.001
	weaponType = 1;
	minEnergy = 5;
	maxEnergy = 7;
	repairRate = 0;
	//fireSound = SoundFireBlaster;
	damageSound = SoundFlierCrash;
	ramDamage = 0.0001; //0.0001
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundDiscSpin;
	visibleDriver = false;
	driverPose = 22;
	description = "Survey Droid";
};

function SurveyDroidPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function SurveyDroidPack::onDeploy(%player,%item,%pos)
{
	if(DeploySurveyDroid(%player,%item,SurveyDroid,flier,SurveyDroid)) 
		if(!Player::isDead(%player)&& !$build) 
			Player::decItemCount(%player,%item);
}

function SurveyDroid::onCollision(%this,%object)
{	
	if($debug) 
		event::collision(%this,%object);

	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	if(getObjectType(%object) == "Player") 
	{
		if(GameBase::getTeam(%object)==GameBase::getTeam(%this))
		{
			playNextAnim(%client);
			Player::kill(%client);
			Client::onKilled(%client,%client);
			SuicideDroid::onDestroyed(%this);
		}
		else
		{
			SuicideDroid::onDestroyed(%this);
		}
	}
}

function SurveyDroid::jump(%this,%mom)
{
	SurveyDroid::onDestroyed(%this);
	//GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

function DeploySurveyDroid(%player,%item,%shape,%data,%name)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "SurveyDroidPack"] < $TeamItemMax["SurveyDroidPack"])
	{	
		%trans = GameBase::getMuzzleTransform(%client);
		%posX = getWord(%trans,9);
		%posY = getWord(%trans,10);
		%posZ = getWord(%trans,11) + 1.5; // +3.0
		%position = %posX@" "@%posY@" "@%posZ;
		%rot = GameBase::getRotation(%player);
		%obj = newObject(SurveyDroid,flier,SurveyDroid,true);
		NukeList(%obj);
		%obj.cloakable = true;
		addToSet("MissionCleanup",%obj);
		GameBase::setTeam(%obj,GameBase::getTeam(%player));
		GameBase::setPosition(%obj,%position);
		Vehicle::TerrainCheck(%obj);
		GameBase::setRotation(%obj,%rot);
		Gamebase::setMapName(%obj,"SurveyDroid");
		Client::sendMessage(%client, 0, "SurveyDroid Deployed");
		GameBase::startFadeIn(%obj);
		GameBase::startFadeOut(%obj);
		playSound(SoundPickupBackpack,$los::position);
		Client::setControlObject(%client,%obj);
		%client.droid=true;
		%player.vehicle = %obj;
		$TeamItemCount[GameBase::getTeam(%player) @ "SurveyDroidPack"]++;
		return true;
	}
	else
	{
		Client::sendMessage(%client,0,"Maximum number of SurveyDroids deployed");
		return false;
	}
}

function SurveyDroid::onDestroyed(%this)
{
	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	Client::setControlObject(%client,%player);
	%client.droid=false;
	%player.vehicle = "";
	%this.cloakable = "";	
	%this.nuetron = "";
	Client::sendMessage(%client,0,"Connection to SurveyDroid lost");
 	$TeamItemCount[GameBase::getTeam(%this) @ "SurveyDroidPack"]--;
	GameBase::setDamageLevel(%this,1);
}

function SurveyDroid::onFire(%this,%slot)
{		
	if($debug)
		echo("?? EVENT fire survey droid, "@ %this @" control cl# "@ gamebase::getcontrolclient(%this));	

	%client = GameBase::getControlClient(%this);
	if($TeamItemCount[GameBase::getTeam(%this) @ CameraPack] < $TeamItemMax[CameraPack] && !%this.deployed)
	{
		if(GameBase::getLOSInfo(%this,3))
		{
			%obj = getObjectType($los::object);
			if(%obj == "SimTerrain" || %obj == "InteriorShape")
			{
				%this.deployed = true;
				//GameBase::startFadeOut(%this);
				%prot = GameBase::getRotation(%this);
				%zRot = getWord(%prot,2);
				if(Vector::dot($los::normal,"0 0 1") > 0.6)
					 %rot = "0 0 " @ %zRot;
				else
				{
					if(Vector::dot($los::normal,"0 0 -1") > 0.6)
						%rot = "3.14159 0 " @ %zRot;
					else
						%rot = Vector::getRotation($los::normal);
				}
				%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
				addToSet("MissionCleanup", %beacon);
				GameBase::setTeam(%beacon,GameBase::getTeam(%this));
				GameBase::setRotation(%beacon,%rot);
				GameBase::setPosition(%beacon,$los::position);
				Gamebase::setMapName(%beacon,"Target Beacon");
				Beacon::onEnabled(%beacon);
				Client::sendMessage(%client,0,"Beacon deployed");
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
				echo("MSG: Survey Droid deployed a Beacon");
				SurveyDroid::removeDrone(%this);
			}
		}
	}
}
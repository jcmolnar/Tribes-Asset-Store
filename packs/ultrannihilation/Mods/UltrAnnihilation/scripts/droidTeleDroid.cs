$InvList[TeleDroidPack] = 1;
$MobileInvList[TeleDroidPack] = 1;
$RemoteInvList[TeleDroidPack] = 1;

ItemImageData TeleDroidPackImage
{	shapeFile = "shieldpack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = 4;
 	maxEnergy = 4.5;
	firstPerson = false;
};

ItemData TeleDroidPack
{	description = "Tele Droid";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = $InvHead[ihDro];
	shadowDetailMask = 4;
	imageType = TeleDroidPackImage;
	mass = 0.5;
	price = 200;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

FlierData TeleDroid
{	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
	className = "Vehicle";
	shapeFile = "camera";
	//shieldShapeName = "shield_medium";
	mass = 0.001;
	drag = 1.0;
	density = 1.2;
	maxBank = 7;
	maxPitch = 12.5;
	maxSpeed = 10;
	//maxSideSpeed = 100;
	minSpeed = -15;
	lift = 1.0;
	maxAlt = 950;
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
	description = "Tele Droid";
};

function TeleDroidPack::onUse(%player,%item)
{	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function TeleDroidPack::onDeploy(%player,%item,%pos)
{	if(DeployTeleDroid(%player,%item,TeleDroid,flier,TeleDroid)) 
		if(!Player::isDead(%player)) 
			Player::decItemCount(%player,%item);
}

function TeleDroid::onCollision(%this,%object)
{
	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	if (getObjectType(%object) == "Player") 
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

function TeleDroid::jump(%this,%mom)
{
	TeleDroid::onDestroyed(%this);
	//GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

function DeployTeleDroid(%player,%item,%shape,%data,%name)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "TeleDroidPack"] < $TeamItemMax["TeleDroidPack"])
	{	
		%trans = GameBase::getMuzzleTransform(%client);
		%posX = getWord(%trans,9);
		%posY = getWord(%trans,10);
		%posZ = getWord(%trans,11) + 1.5; // +3.0
		%position = %posX@" "@%posY@" "@%posZ;
		%rot = GameBase::getRotation(%player);
		%obj = newObject(TeleDroid,flier,TeleDroid,true);
		addToSet("MissionCleanup",%obj);
		GameBase::setTeam(%obj,GameBase::getTeam(%player));
		GameBase::setPosition(%obj,%position);
		GameBase::setRotation(%obj,%rot);
		Gamebase::setMapName(%obj,"TeleDroid");
		Client::sendMessage(%client, 0, "TeleDroid Deployed");
		GameBase::startFadeIn(%obj);
		//GameBase::startFadeOut(%obj);
		playSound(SoundPickupBackpack,$los::position);
		Client::setControlObject(%client,%obj);
		%client.droid=true;
		%player.vehicle = %obj;
		$TeamItemCount[GameBase::getTeam(%player) @ "TeleDroidPack"]++;
		return true;
	}
	else
	{
		Client::sendMessage(%client,0,"Maximum number of TeleDroids deployed");
		return false;
	}
}

function TeleDroid::onDestroyed(%this)
{
	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	//Player::setMountObject(%player, -1, 0);
	Client::setControlObject(%client,%player);
	%client.droid=false;
	%player.vehicle = "";
	Client::sendMessage(%client,0,"Connection to TeleDroid lost");
 	$TeamItemCount[GameBase::getTeam(%this) @ "TeleDroidPack"]--;
	//GameBase::startFadeOut(%this);
	//GameBase::applyDamage(%this,$ImpactDamageType,1,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
	GameBase::setDamageLevel(%this,1);
}

function TeleDroid::onFire(%this,%slot)
{	
	%client = GameBase::getControlClient(%this);
	if($TeamItemCount[GameBase::getTeam(%this) @ CameraPack] < $TeamItemMax[CameraPack] && !%this.deployed)
	{	if(GameBase::getLOSInfo(%this,3))
		{	%obj = getObjectType($los::object);
			if(%obj == "SimTerrain" || %obj == "InteriorShape")
			{	%this.deployed = true;
				//GameBase::startFadeOut(%this);
				%prot = GameBase::getRotation(%this);
				%zRot = getWord(%prot,2);
				
				if(Vector::dot($los::normal,"0 0 1") > 0.6) %rot = "0 0 " @ %zRot;
				else
				{	if(Vector::dot($los::normal,"0 0 -1") > 0.6) %rot = "3.14159 0 " @ %zRot;
					else %rot = Vector::getRotation($los::normal);
				}
				//%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true); //DefaultBeacon
			//jdm======here's the phase shift
				%player = Client::getOwnedObject(%client);
				%obj = getObjectType($los::object);
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				%xpos = getWord($los::position,0);
				%ypos = getWord($los::position,1);
				%zpos = getWord($los::position,2);
				schedule("phaseShiftProcess(" @ %player @ ", " @ %xpos @ ", " @ %ypos @ ", " @ %zpos @ ");", 0.25, %player);
				%player.hasPhaseShifted = true;
			//jdm======here's the phase shift
				//addToSet("MissionCleanup", %beacon);
				//GameBase::setTeam(%beacon,GameBase::getTeam(%this));
				//GameBase::setRotation(%beacon,%rot);
				//GameBase::setPosition(%beacon,$los::position);
				//Gamebase::setMapName(%beacon,"Target Beacon");
				//Beacon::onEnabled(%beacon);
				//Client::sendMessage(%client,0,"Beacon deployed");
				playSound(SoundPickupBackpack,$los::position);
				//$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
				//echo("MSG: Survey Droid deployed a Beacon");
				TeleDroid::onDestroyed(%this);
				TeleDroid::removeDrone(%this);
			}
		}
	}
}
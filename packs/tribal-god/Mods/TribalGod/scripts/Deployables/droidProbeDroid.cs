//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|

ItemImageData ProbeDroidPackImage
{
	shapeFile = "ammopack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = 4;
 	maxEnergy = 4.5;
	firstPerson = false;
};
ItemData ProbeDroidPack
{
	description = "Probe Droid";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = $InvHeading[Deployables];
	shadowDetailMask = 4;
	imageType = ProbeDroidPackImage;
	mass = 0.5;
	price = 400;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};
FlierData ProbeDroid
{	
	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
	className = "Vehicle";
	shapeFile = "camera";
	mass = 0.001;
	drag = 1.0;
	density = 1.2;
	maxBank = 5;
	maxPitch = 12.5;
	maxSpeed = 55;
	minSpeed = -55;
	lift = 5.0;
	maxAlt = 20000;
	maxVertical = 1;
	maxDamage = 0.0125;
	damageLevel = {1.0, 1.0};
	maxEnergy = 50;
	accel = 1.0;
	groundDamageScale = 1;
	projectileType = MiniFusionBolt;
	reloadDelay = 1.0;
	repairRate = 0;
	fireSound = SoundLaserHit;
	damageSound = SoundFlierCrash;
	ramDamage = 0.0001;
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
	description = "Probe Droid";
};

function ProbeDroidPack::onUse(%player,%item)
{ if(Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player, %item, $BackpackSlot); }else{ Player::deployItem(%player, %item); } }

function ProbeDroidPack::onDeploy(%player,%item,%pos)
{ if(DeployProbeDroid(%player, %item, ProbeDroid, flier, ProbeDroid)){ if(!Player::isDead(%player)){ Player::decItemCount(%player, %item); } } }

function ProbeDroid::onCollision(%this, %object)
{
	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	if(getObjectType(%object) == "Player") 
	{
		if(GameBase::getTeam(%object) == GameBase::getTeam(%this))
		{
			playNextAnim(%client);
			Player::kill(%client);
			Client::onKilled(%client, %client);
			ProbeDroid::onDestroyed(%this);
		}
		else
		{ ProbeDroid::onDestroyed(%this); }
	}
}

function ProbeDroid::jump(%this)
{ ProbeDroid::onDestroyed(%this); }

function DeployProbeDroid(%player,%item,%shape,%data,%name)
{	
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "ProbeDroidPack"] < $TeamItemMax["ProbeDroidPack"])
	{
		%trans = GameBase::getMuzzleTransform(%client);
		%posX = getWord(%trans,9);
		%posY = getWord(%trans,10);
		%posZ = getWord(%trans,11) + 1.5;
		%position = %posX @" "@ %posY @" "@ %posZ;
		%rot = GameBase::getRotation(%player);
		%obj = newObject(ProbeDroid, flier, ProbeDroid, true);
		addToSet("MissionCleanup",%obj);
		GameBase::setTeam(%obj,GameBase::getTeam(%player));
		GameBase::setPosition(%obj,%position);
		GameBase::setRotation(%obj, %rot);
		Gamebase::setMapName(%obj, "ProbeDroid");
		Client::sendMessage(%client, 0, "ProbeDroid Deployed");
		GameBase::startFadeIn(%obj);
		
		playSound(SoundPickupBackpack, $los::position);
		Client::setControlObject(%client, %obj);
		%client.probe = true;
		%client.probeType = "ProbeDroid";
		%player.vehicle = %obj;
		$TeamItemCount[GameBase::getTeam(%player) @"ProbeDroidPack"]++;
		return true;
	}
	else
	{
		Client::sendMessage(%client,0,"Maximum number of ProbeDroids deployed");
		return false;
	}
}

function ProbeDroid::onDestroyed(%this)
{
	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	Client::setControlObject(%client, %player);
	%client.droid = false;
	%player.vehicle = "";
	Client::sendMessage(%client, 0, "Connection to ProbeDroid lost");
	$TeamItemCount[GameBase::getTeam(%this) @"ProbeDroidPack"]--;
	GameBase::setDamageLevel(%this, 1);
}
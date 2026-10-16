//--------------------------------------

$InvList[TurretPack] = 1;
$RemoteInvList[TurretPack] = 1;


//--------------------------------------

$TeamItemMax[TurretPack] = 1000;

//--------------------------------------

ItemImageData TurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TurretPack
{
	description = "Energy Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "uDeployables";
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TurretPack::onDeploy(%player,%item,%pos)
{
	if (TurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
	}
}


function TurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%datobj = gamebase::getdataname($los::object); 
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "Vehicle" || %datobj == "AirPlatform") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 13 1") > 0.0) {
							//if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("Turret","Turret",DeployableTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Energy Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Energy Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
								echo("MSG: ",%client," deployed a Remote Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								return true;
							//}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}



//--------------------------------------

TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = MiniFusionBolt;
	maxDamage = 0.65;
	maxEnergy = 250;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
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
	description = "Remote Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Energy Turret");
	}
}

function DeployableTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--;
}

// Override base class just in case.
function DeployableTurret::onPower(%this,%power,%generator) {}
function DeployableTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//--------------------------------------

$InvList[TurretPack6] = 1;
$RemoteInvList[TurretPack6] = 1;
//--------------------------------------

$TeamItemMax[TurretPack6] = 10;

//--------------------------------------

RocketData Bullet6
{
   bulletShapeName    = "Shotgunex.dts";
   explosionTag       = Blasterexp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $BlasterDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 150.0;
   terminalVelocity = 160.0;
   acceleration     = 10.0;

   totalTime        = 8.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "ShotgunEx.dts";
   smokeDist   = 1;
 
   soundId = SoundTankActive;
};



LaserData Beam
{
   laserBitmapName   = "LaserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 1.777;
   baseDamageType    = $LaserDamageType;

  
   beamTime          = 1.2;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = True;
   hitSoundId        = SoundRepairItem;
};

ItemImageData TurretPack6Image
{
	shapeFile = "MagCargo";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = True;
};

ItemData TurretPack6
{
	description = "Beam Turret";
	shapeFile = "Chaingun";
	className = "Backpack";
   heading = "uDeployables";
	imageType = TurretPack6Image;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1850;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

// if (Player::getMountedItem(%player,$BackpackSlot) != %max) {

function TurretPack6::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TurretPack6::onDeploy(%player,%item,%pos)
{
	if (TurretPack6::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack6"]++;
	}
}



function TurretPack6::deployshape(%player,%item)
{
	GameBase::getLOSInfo(%player,6);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		%playerPos = GameBase::getPosition(%player);
		%flag = $teamFlag[GameBase::getTeam(%player)];
		%flagpos = gamebase::getPosition(%flag);
		%rot = GameBase::getRotation(%player);
		if(Vector::getDistance(%flagpos, %playerpos) > 0)
		{
			if(Vector::getDistance(%flag.originalPosition, %playerpos) > 0)
			{
				%Turret = newObject("remoteTurret","Turret",DeployableTurret6,true); 
	   			addToSet("MissionCleanup", %Turret);				      
				gameBase::setTeam(%Turret,GameBase::getTeam(%player));
				gameBase::setRotation(%Turret,%rot);// 0,0,0
				gameBase::setPosition(%Turret,GameBase::getPosition(%player));
				gamebase::setMapName(%Turret,"Beam Turret#" @ $totalNumPlatforms++ @ " " @  Client::getName(%client));
				client::sendMessage(%client,0,"Beam Turret deployed");
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%Turret) @ "TurretPack6"]++;
				echo("MSG: ",%client," deployed a Beam Turret");
				Client::setOwnedObject(%client, %turret); 
				Client::setOwnedObject(%client, %player);
				return true;
			}
			else
				Client::sendMessage(%client,0,"Nope");
		}
		else
			Client::sendMessage(%client,0,"You are too close to your flag, Wouldn't that be cheap :)");
			return false;
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
}
//--------------------------------------

TurretData DeployableTurret6
{
	className = "Turret";
	shapeFile = "MortarGun";
   validateShape = true;
   validateMaterials = true;
	projectileType = Beam;
	maxDamage = 20;
	maxEnergy = 12560;
	minGunEnergy = 0;
	maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.2;
	speed = 14.0;
	speedModifier = 1.5;
	range = 15;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = false;
	supression = false;
	mapFilter = 4;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundRepairItem;
	activationSound = SoundRepairItem;
	deactivateSound = SoundRepairItem;
	explosionId = flashExpLarge;
	description = "Beam Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableTurret6::onAdd(%this)
{
	schedule("DeployableTurret6::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.1;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Beam Turret");
	}
}

function DeployableTurret6::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableTurret6::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableTurret6::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack6"]--;
}

// Override base class just in case.
function DeployableTurret6::onPower(%this,%power,%generator) {}
function DeployableTurret6::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//--------------------------------------

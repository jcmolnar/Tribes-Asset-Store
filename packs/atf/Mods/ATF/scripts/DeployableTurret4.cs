//--------------------------------------

$InvList[TurretPack4] = 1;
$RemoteInvList[TurretPack4] = 1;


//--------------------------------------

$TeamItemMax[TurretPack4] = 1000;

//--------------------------------------

RocketData Bullet4
{
   bulletShapeName    = "rsmoke.dts";
   explosionTag       = Turretexp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.00;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 330.0;

   muzzleVelocity   = 850.0;
   terminalVelocity = 900.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Rsmoke.dts";
   smokeDist   = 1;
 
   soundId = SoundTankCrash;
};

ItemImageData TurretPack4Image
{
	shapeFile = "RemoteTurret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TurretPack4
{
	description = "Barrier Turret";
	shapeFile = "RemoteTurret";
	className = "Backpack";
   heading = "uDeployables";
	imageType = TurretPack4Image;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 850;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TurretPack4::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TurretPack4::onDeploy(%player,%item,%pos)
{
	if (TurretPack4::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack4"]++;
	}
}

function TurretPack4::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%datobj = gamebase::getdataname($los::object); 
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "Vehicle" || %datobj == "AirPlatform") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableTurret4",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret4",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 13 1") > 0.0) {
							//if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableTurret4,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Barrier Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Barrier Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack4"]++;
								echo("MSG: ",%client," deployed a Remote Turret");
								//	Remote turrets - kill points to player that deploy them
								 Client::setOwnedObject(%client, %turret); 
								 Client::setOwnedObject(%client, %player);
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

TurretData DeployableTurret4
{
	className = "Turret";
	shapeFile = "HellfireGun";
   validateShape = true;
   validateMaterials = true;
	projectileType = Bullet4;
	maxDamage = 6;
	maxEnergy = 360;
	minGunEnergy = 3;
	maxGunEnergy = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 270;
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
	description = "Barrier Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableTurret4::onAdd(%this)
{
	schedule("DeployableTurret4::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.1;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Barrier Turret");
	}
}

function DeployableTurret4::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableTurret4::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableTurret4::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack4"]--;
}

// Override base class just in case.
function DeployableTurret4::onPower(%this,%power,%generator) {}
function DeployableTurret4::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//-------------------------------------
$InvList[TurretPack5] = 1;
$RemoteInvList[TurretPack5] = 1;


//--------------------------------------

$TeamItemMax[TurretPack5] = 10;

//--------------------------------------

RocketData Bullet5
{
   bulletShapeName    = "plasmaex.dts";
   explosionTag       = mortarexp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 3.00;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 150.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;

   totalTime        = 8.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Plasmaex.dts";
   smokeDist   = 1;
 
   soundId = SoundTankCrash;
};

ItemImageData TurretPack5Image
{
	shapeFile = "RemoteTurret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 4.5;
	firstPerson = false;
};

ItemData TurretPack5
{
	description = "HellFire Turret";
	shapeFile = "RemoteTurret";
	className = "Backpack";
   heading = "uDeployables";
	imageType = TurretPack5Image;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1850;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TurretPack5::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TurretPack5::onDeploy(%player,%item,%pos)
{
	if (TurretPack5::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack5"]++;
	}
}

function TurretPack5::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%datobj = gamebase::getdataname($los::object); 
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "Vehicle" || %datobj == "AirPlatform") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableTurret5",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret5",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 13 1") > 0.0) {
							//if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableTurret5,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Hellfire Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Hellfire Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack5"]++;
								echo("MSG: ",%client," deployed a Remote Turret");
								//	Remote turrets - kill points to player that deploy them
								 Client::setOwnedObject(%client, %turret); 
								 Client::setOwnedObject(%client, %player);
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

TurretData DeployableTurret5
{
	className = "Turret";
	shapeFile = "HellfireGun";
   validateShape = true;
   validateMaterials = true;
	projectileType = Bullet5;
	maxDamage = 10;
	maxEnergy = 360;
	minGunEnergy = 10;
	maxGunEnergy = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.1;
	speed = 4.0;
	speedModifier = 1.5;
	range = 100;
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
	description = "HellFire Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableTurret5::onAdd(%this)
{
	schedule("DeployableTurret5::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.1;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "HellFire Turret");
	}
}

function DeployableTurret5::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableTurret5::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableTurret5::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack5"]--;
}

// Override base class just in case.
function DeployableTurret5::onPower(%this,%power,%generator) {}
function DeployableTurret5::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//--------------------------------------




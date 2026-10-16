//--------------------------------------

$InvList[TurretPack2] = 4;
$RemoteInvList[TurretPack2] = 4;


//--------------------------------------

$TeamItemMax[TurretPack2] = 15;

//--------------------------------------
BulletData SuperMissile
{
   bulletShapeName    = "Rocket.dts";
   explosionTag       = RocketExp;

   damageClass        = 1;
   damageValue        = 0.1;
   damageType         = $ExplosionDamageType;
   
   explosionRadius    = 10.0;
   kickBackStrength   = 350.0;
   muzzleVelocity     = 150.0;
   totalTime          = 5.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};
//---------------------------------------------------------
ItemImageData TurretPack2Image
{
	shapeFile = "Hellfiregun";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.8;
	firstPerson = false;
};

ItemData TurretPack2
{
	description = "Sting Turret";
	shapeFile = "HellfireGun";
	className = "Backpack";
   heading = "uDeployables";
	imageType = TurretPack2Image;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TurretPack2::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TurretPack2::onDeploy(%player,%item,%pos)
{
	if (TurretPack2::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack2"]++;
	}
}


function TurretPack2::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "Vehicle") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableTurret2",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret2",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 13 1") > 0.0) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("Sting Turret","Turret",DeployableTurret2,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Sting Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Sting Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack2"]++;
								echo("MSG: ",%client," deployed a Remote Turret");
								//	Remote turrets - kill points to player that deploy them
								 Client::setOwnedObject(%client, %turret); 
								 Client::setOwnedObject(%client, %player);
								return true;
							}
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

TurretData DeployableTurret2
{
	className = "Turret";
	shapeFile = "Hellfiregun";
   validateShape = true;
   validateMaterials = true;
	projectileType = SuperMissile;
	maxDamage = 2;
	maxEnergy = 100;
	minGunEnergy = 2;
	maxGunEnergy = 3;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.3;
	speed = 7.0;
	speedModifier = 1.5;
	range = 125;
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
	explosionId = LargeShockwave;
	description = "Sting Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableTurret2::onAdd(%this)
{
	schedule("DeployableTurret2::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.1;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Sting Turret");
	}
}

function DeployableTurret2::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableTurret2::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableTurret2::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack2"]--;
}

// Override base class just in case.
function DeployableTurret2::onPower(%this,%power,%generator) {}
function DeployableTurret2::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//--------------------------------------
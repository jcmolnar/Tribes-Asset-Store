//--------------------------------------

$InvList[TurretPack3] = 1;
$RemoteInvList[TurretPack3] = 1;


//--------------------------------------

$TeamItemMax[TurretPack3] = 40;

//--------------------------------------

BulletData ASTBullet
{
   bulletShapeName    = "Bullet.dts";
   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 5;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $electricityDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 90.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

ItemImageData TurretPack3Image
{
	shapeFile = "RemoteTurret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TurretPack3
{
	description = "Auto Sentry Turret";
	shapeFile = "RemoteTurret";
	className = "Backpack";
   heading = "uDeployables";
	imageType = TurretPack3Image;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 850;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TurretPack3::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TurretPack3::onDeploy(%player,%item,%pos)
{
	if (TurretPack3::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack3"]++;
	}
}


function TurretPack3::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%datobj = gamebase::getdataname($los::object); 
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "Vehicle" || %datobj == "AirPlatform") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableTurret3",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret3",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 13 1") > 0.0) {
							//if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableTurret3,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"AST Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"AST Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack3"]++;
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

TurretData DeployableTurret3
{
	className = "Turret";
	shapeFile = "RemoteTurret";
   validateShape = true;
   validateMaterials = true;
	projectileType = ASTBullet;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 90;
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

function DeployableTurret3::onAdd(%this)
{
	schedule("DeployableTurret3::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.1;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Turret");
	}
}

function DeployableTurret3::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableTurret3::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableTurret3::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack3"]--;
}

// Override base class just in case.
function DeployableTurret3::onPower(%this,%power,%generator) {}
function DeployableTurret3::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//--------------------------------------
//--------------------------------------

$InvList[AirPlatformPack] = 1;
$RemoteInvList[AirPlatformPack] = 1;


//--------------------------------------

$TeamItemMax[AirPlatformPack] = 40;

//--------------------------------------



StaticShapeData AirPlatform
{
	shapeFile = "elevator16x16_octo"; 
	debrisId = defaultDebrisLarge;
	maxDamage = 10.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "S_Air Plat";
      description = "Air Platform";
};

function AirPlatform::onDestroyed(%this)
{
	
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $BurnDamageType, 1.0, 0.05, 15, 13, 3, 0.40, 0.30, 150, 70);
	$TeamItemCount[GameBase::getTeam(%this) @ "AirPlatformPack"]--;
}

ItemImageData AirPlatformPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData AirPlatformPack
{	
	description = "Air Platform";
	shapefile = "ammopack";
	classname = "Backpack";
	heading = "uDeployables";
	imageType = AirPlatformPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.1;
	price = 150;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AirPlatformPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{
		Player::deployItem(%player,%item);
	}
}

function AirPlatformPack::onDeploy(%player,%item,%pos)
{
	if (AirPlatformPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function AirPlatformPack::deployshape(%player,%item)
{
	GameBase::getLOSInfo(%player,6);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		%playerPos = GameBase::getPosition(%player);
		%flag = $teamFlag[GameBase::getTeam(%player)];
		%flagpos = gamebase::getPosition(%flag);
		if(Vector::getDistance(%flagpos, %playerpos) > 7)
		{
			if(Vector::getDistance(%flag.originalPosition, %playerpos) > 7)
			{
				%sensor = newObject("Air Platform","Staticshape",AirPlatform,true); 
	   			addToSet("MissionCleanup", %sensor);				      
				gameBase::setTeam(%sensor,GameBase::getTeam(%player));
				gameBase::setRotation(%sensor,"0 0 0");// %rot
				gameBase::setPosition(%sensor,GameBase::getPosition(%player));
				gamebase::setMapName(%sensor,"Air Platform#" @ $totalNumPlatforms++ @ " " @  Client::getName(%client));
				client::sendMessage(%client,0,"Air Platform deployed");
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%sensor) @ "AirPlatformPack"]++;
				echo("MSG: ",%client," deployed an Air Platform ");
				return true;
			}
			else
				Client::sendMessage(%client,0,"Nope");
		}
		else
			Client::sendMessage(%client,0,"You are too close to your flag, cant hide the flag in this mod.");
			return false;
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
}






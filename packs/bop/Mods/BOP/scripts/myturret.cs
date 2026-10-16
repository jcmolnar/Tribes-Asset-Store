$InvList[LaserTurretPack] = 1;
$InvList[RocketTurretPack] = 1;
$InvList[SmallElfPack] = 1;
$InvList[SatCameraPack] = 1;

$RemoteInvList[LaserTurretPack] = 1;
$RemoteInvList[RocketTurretPack] = 1;
$RemoteInvList[SmallElfPack] = 1;
$RemoteInvList[SatCameraPack] = 1;

$TeamItemMax[LaserTurretPack] = 4;
$TeamItemMax[RocketTurretPack] = 2;
$TeamItemMax[SmallElfPack] = 3;
$TeamItemMax[SatCameraPack] = 4;

// -------------------------------------------------------------------------------------------

TurretData LaserTurret
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = sniperLaser;
	maxDamage = 0.5;
	maxEnergy = 60;
	minGunEnergy = 55;
	maxGunEnergy = 55;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.5;
	speed = 4.0;
	speedModifier = 1.5;
	range = 30;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "L_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireLaser;
	explosionId = flashExpMedium;
	description = "Laser Turret";
	damageSkinData = "objectDamageSkins";
};

function LaserTurret::onAdd(%this)
{
	schedule("LaserTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Laser Turret");
	}
}

function LaserTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function LaserTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function LaserTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LaserTurretPack"]--;
}

// Override base class just in case.
function LaserTurret::onPower(%this,%power,%generator) {}
function LaserTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

ItemImageData LaserTurretPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData LaserTurretPack
{
	description = "Laser Turret";
	shapeFile = "sensor_small";
	className = "Backpack";
	heading = "dDeployables";
	imageType = LaserTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaserTurretPack::onUse(%player,%item)
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

function LaserTurretPack::onDeploy(%player,%item,%pos)
{
	if (LaserTurretPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function LaserTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
			%datobj = gamebase::getdataname($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %datobj == "AirPlatform" || %datobj == "LargeAirPlatform" || %datobj == "DeployableWall"){ 				
	    			%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"LaserTurret",%num);
				deleteObject(%set);
				if(1 > %num)
				{
					%prot = GameBase::getRotation(%player);
					%zRot = getWord(%prot,2);
					if (Vector::dot($los::normal,"0 0 1") > 0.6) 
					{
						%rot = "0 0 " @ %zRot;
					}
					else 	
					{
						if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
						{
							%rot = "3.14159 0 " @ %zRot;
						}
						else 
						{
							%rot = Vector::getRotation($los::normal);
						}
					}
					//if(checkDeployArea(%client,$los::position)) {
						%turret = newObject("remoteTurret","Turret",LaserTurret,true);
	                     				addToSet("MissionCleanup", %turret);
						GameBase::setTeam(%turret,GameBase::getTeam(%player));
						GameBase::setPosition(%turret,$los::position);
						GameBase::setRotation(%turret,%rot);
						Gamebase::setMapName(%turret,"Laser Turret#" @ $totalNumLaserTurrets++ @ " " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Laser Turret deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "LaserTurretPack"]++;
						echo("MSG: ",%client," deployed a Laser Turret");
						return true;
					//}
				}
				else 
					Client::sendMessage(%client,0,"Interference from other laser turrets in the area");
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

//---------------------------------------------------------------------------

TurretData DeployableRocketTurret
{
	className = "Turret";
	shapeFile = "missileturret";
	projectileType = TurretMissile;
	maxDamage = 0.75;
	maxEnergy = 100;
	minGunEnergy = 60;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
//	reloadDelay = 3.5;
	speed = 2.0;
	speedModifier = 2.0;
	range = 100;
	visibleToSensor = true;
	shadowDetailMask = 8;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	shieldShapeName = "shield_medium";
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	explosionId = LargeShockwave;
	description = "Rocket Turret";
	damageSkinData = "objectDamageSkins";
//	whirSound = SoundMissileTurretTurn;
 	targetableFovRatio = 0.5;
	gunRange = 200;
};

function DeployableRocketTurret::onAdd(%this)
{
	schedule("DeployableRocketTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,2);
	%this.shieldStrength = 0.025;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Deployable Rocket Turret");
	}
}

function DeployableRocketTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableRocketTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableRocketTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "RocketTurretPack"]--;
}

function DeployableRocketTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

// Override base class just in case.
function DeployableRocketTurret::onPower(%this,%power,%generator) {}
function DeployableRocketTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}	

ItemImageData RocketTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 4.5;
	firstPerson = false;
};

ItemData RocketTurretPack
{
	description = "Rocket Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = "dDeployables";
	imageType = RocketTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RocketTurretPack::onUse(%player,%item)
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

function RocketTurretPack::onDeploy(%player,%item,%pos)
{
	if (RocketTurretPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function RocketTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape"){ 
	    			%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength+10,$TurretBoxMaxWidth+10,$TurretBoxMaxHeight+10,0);
				%num = CountObjects(%set,"DeployableRocketTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox -1 > %num)
				{
		    			%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableRocketTurret",%num);
					deleteObject(%set);
					if(0 == %num) 
					{
						if (Vector::dot($los::normal,"0 0 1") > 0.7) 
						{
							//if(checkDeployArea(%client,$los::position)){
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableRocketTurret,true);
	                     						addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Rocket Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Rocket Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "RocketTurretPack"]++;
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
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other rocket turrets");
				}
				else 
					Client::sendMessage(%client,0,"Interference from other rocket turrets in the area");
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

// --------------------------------------------------------------------------------------------------------

TurretData SmallELFTurret	   
{			 
	maxDamage = 1.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 30;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "ELF Turret";
	shapeFile = "chainturret";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = turretCharge;
	reloadDelay = 0.3;
	explosionId = flashExpMedium;
	description = "ELF Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;
};

function SmallElfTurret::onAdd(%this)
{
	schedule("SmallElfTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.025;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "ELF Turret");
	}
}

function SmallElfTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function SmallElfTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function SmallElfTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "SmallElfPack"]--;
}

// Override base class just in case.
function SmallElfTurret::onPower(%this,%power,%generator) {}
function SmallElfTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

ItemImageData SmallElfPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData SmallElfPack
{
	description = "ELF turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = "dDeployables";
	imageType = SmallElfPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SmallElfPack::onUse(%player,%item)
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

function SmallElfPack::onDeploy(%player,%item,%pos)
{
	if (SmallElfPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function SmallElfPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
			%datobj = gamebase::getdataname($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape"){ 
	    			%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num)
				{
		    			%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"SmallElfTurret",%num);
					deleteObject(%set);
					if(0 == %num) 
					{
						%prot = GameBase::getRotation(%player);
						%zRot = getWord(%prot,2);
						if (Vector::dot($los::normal,"0 0 1") > 0.6) 
						{
							%rot = "0 0 " @ %zRot;
						}
						else 	
						{
							if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
							{
								%rot = "3.14159 0 " @ %zRot;
							}
							else 
							{
								%rot = Vector::getRotation($los::normal);
							}
						}
						//if(checkDeployArea(%client,$los::position)) {
							%turret = newObject("Small Elf Turret","Turret",SmallElfTurret,true);
	                     					addToSet("MissionCleanup", %turret);
							GameBase::setTeam(%turret,GameBase::getTeam(%player));
							GameBase::setPosition(%turret,$los::position);
							GameBase::setRotation(%turret,%rot);
							Gamebase::setMapName(%turret,"ELF Turret#" @ $totalNumELFTurrets++ @ " " @ Client::getName(%client));
							Client::sendMessage(%client,0,"ELF Turret deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "SmallElfPack"]++;
							echo("MSG: ",%client," deployed a ELF Turret");
							//	Remote turrets - kill points to player that deploy them
							// Client::setOwnedObject(%client, %turret); 
							// Client::setOwnedObject(%client, %player);
							return true;
						//}
					}	 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other ELF turrets");
				}
				else 
					Client::sendMessage(%client,0,"Interference from other ELF turrets in the area");
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

// --------------------------------------------------------------------------------------------

TurretData SatCameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 0.25;
	maxEnergy = 10;
	speed = 20;
	speedModifier = 1.0;
	range = 250;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = defaultDebrisSmall;
	FOV = 0.707;
	pinger = false;
	explosionId = debrisExpMedium;
	description = "Satellite Camera";
};

function SatCameraTurret::onAdd(%this)
{
	schedule("SatCameraTurret::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Satellite Camera");
	}
}

function SatCameraTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function SatCameraTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function SatCameraTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "SatCameraPack"]--;
}	

ItemImageData SatCameraPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SatCameraPack
{
	description = "Satellite Camera";
	shapeFile = "camera";
	className = "Backpack";
	heading = "dDeployables";
	imageType = SatCameraPackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SatCameraPack::onUse(%player,%item)
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

function SatCameraPack::onDeploy(%player,%item,%pos)
{
	if (SatCameraPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function SatCameraPack::deployshape(%player,%item)
{
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		%camera = newObject("Camera","Turret",SatCameraTurret,true);
	   	addToSet("MissionCleanup", %camera);
		GameBase::setTeam(%camera,GameBase::getTeam(%player));
		%xrot = -1; 
		%rot = GameBase::getRotation(%player); 
		%zrot = getword(%rot, 2);
		%yrot = 0; 
		GameBase::setRotation(%camera,%xrot @ " " @ %yrot @ " " @ %zrot);
		GameBase::setPosition(%camera,GameBase::getPosition(%player));
		Gamebase::setMapName(%camera,"Satellite Camera#"@ $totalNumSatCameras++ @ " " @ Client::getName(%client));
		Client::sendMessage(%client,0,"Satellite Camera deployed");
		playSound(SoundPickupBackpack,$los::position);
		$TeamItemCount[GameBase::getTeam(%camera) @ "SatCameraPack"]++;
		echo("MSG: ",%client," deployed a Satellite Camera");
		return true;
	}
}

//----------------------------------------------------------------------------
//
//	DEPLOYABLES
//
//----------------------------------------------------------------------------

ItemData Backpack
{
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
		}
		else 
		{
		Player::trigger(%player,$BackpackSlot);
	}
}

//----------------------------------------------------------------------------
//	DEPLOYABLE TURRETPACK
//----------------------------------------------------------------------------
																			
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
	description = "Ion Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHead[ihDet];
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
	}
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) {
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function TurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Remote Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
								echo("MSG: ",%client," deployed a Remote Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
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

//----------------------------------------------------------------------------
//	DEPLOYABLE MINI ELF TURRET
//----------------------------------------------------------------------------

$InvList[MiniELF] = 1;
$RemoteInvList[MiniELF] = 1;

$CanAlwaysTeamDestroy[deployableMiniELF] = 1;

LightningData lightningCharge2
{
   bitmapName = "lightningNew.bmp";
   damageType = $FlashDamageType;
   boltLength = 40.0;
   coneAngle = 35.0;
   damagePerSec = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments = 5;
   beamWidth = 0.125;//075;
   updateTime = 120;
   skipPercent = 0.5;
   displaceBias = 0.15;
   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };
   soundId = SoundELFFire;
};

ItemImageData MiniELFImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData MiniELF
{
	description = "Mini-ELF Turret";
	shapeFile = "camera";
	className = "Backpack";
	heading = $InvHead[ihDet];
	imageType = MiniELFImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MiniELF::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MiniELF::onDeploy(%player,%item,%pos)
{
	if (MiniELF::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function MiniELF::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,10)) {
			%obj = getObjectType($los::object);
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
					}
					%camera = newObject("Camera","Turret",deployableMiniELF,true);
	   	      		addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Mini-ELF Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Mini-ELF Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "MiniELFPack"]++;
                              Client::setOwnedObject(%client, %camera);
                              Client::setOwnedObject(%client, %player);
					return true;
				}
				else 
					Client::sendMessage(%client,0,"Deploy position out of range");
			}
			else																						  
			 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

		return false;
	}


TurretData deployableMiniELF
{
	maxDamage = 2.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 40;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	heading = "gDeployable Turrets";
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "camera";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = lightningCharge2;
	reloadDelay = 0.3;
	explosionId = flashExpMedium;
	description = "Deployable Mini-ELF Turret";
	fireSound = SoundGeneratorPower;
	activationSound = SoundChainTurretOn;
	deactivateSound = SoundChainTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	isSustained = true;
	firingTimeMS = 750;
	energyRate = 30.0;
};

function deployableMiniELF::onAdd(%this)
{
	schedule("DeployableShock::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	//%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Mini-ELF Turret");
	}
}

function deployableMiniELF::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function deployableMiniELF::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function deployableMiniELF::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MiniELFPack"]--;
}

// Override base class just in case.
function deployableMiniELF::onPower(%this,%power,%generator) {}
function deployableMiniELF::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//----------------------------------------------------------------------------
//	DEPLOYABLE RAIL TURRET
//----------------------------------------------------------------------------

$TeamItemMax[RailTurret] = 2;
$InvList[RailTurret] = 1;
$RemoteInvList[RailTurret] = 1;

$CanControl[DeployableRail] = 1;
$EmbedController[DeployableRail] = 1;
$CanAlwaysTeamDestroy[DeployableRail] = 1;

LaserData railLaser 
{
	laserBitmapName = "paintPulse.bmp";
	hitName = "laserhit.dts";
	damageConversion = 0.008;
	baseDamageType = $LaserDamageType;
	beamTime = 1.5;
	lightRange = 5.0;
	lightColor = { 0.25, 1.0, 0.25 };
	detachFromShooter = true;
	hitSoundId = SoundLaserHit;
};

ItemImageData RailTurretImage 
{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.1 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData RailTurret 
{ 
	description = "Rail Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = $InvHead[ihDet]; 
	imageType = RailTurretImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 850; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function RailTurret::onUse(%player,%item) 
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

function RailTurret::onDeploy(%player,%item,%pos) 
{ 
	if (RailTurret::deployShape(%player,%item)) 
	{ 
		Player::decItemCount(%player,%item); 
	} 
} 

function RailTurret::onMount(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	Bottomprint(%client, "The Rail Turret has no auto-sensor and must be controlled manually to fire."); 
} 

function CountObjects(%set,%name,%num) 
{ 
	%count = 0; for(%i=0;%i<%num;%i++) 
	{ 
		%obj=Group::getObject(%set,%i); 
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++; 
	} 
return %count; 
} 



function RailTurret::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
		if (GameBase::getLOSInfo(%player,3)) 
		{ 
			%obj = getObjectType($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") 
			{ 
				%set = newObject("set",SimSet); 
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); 
				%num = CountObjects(%set,"DeployableVulcan",%num); 
				deleteObject(%set); 
				if($MaxNumTurretsInBox > %num) 
				{ 
					%set = newObject("set",SimSet); 
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); 
					%num = CountObjects(%set,"DeployableRail",%num); 
					deleteObject(%set); 
					if(0 == %num) 
					{ 
						if (Vector::dot($los::normal,"0 0 1") > 0.7) 
						{ 
							if(checkDeployArea(%client,$los::position)) 
							{ 
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("hellfiregun","Turret",DeployableRail,true); 
								addToSet("MissionCleanup", %turret); 
								GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
								GameBase::setPosition(%turret,$los::position); 
								GameBase::setRotation(%turret,%rot); 
								Gamebase::setMapName(%turret,"Rail Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
								Client::sendMessage(%client,0,"Rail Turret deployed"); 
								playSound(SoundPickupBackpack,$los::position); 
								$TeamItemCount[GameBase::getTeam(%player) @ "RailTurret"]++; 
								return true; 
									} 
										} 
											else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
										} 
									else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); 
								} 
							else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); 
						} 
					else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
				} 
			else Client::sendMessage(%client,0,"Deploy position out of range"); 
		} 
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
} 

TurretData DeployableRail
{ 
	className = "Turret"; 
	shapeFile = "hellfiregun"; 
	projectileType = railLaser; 
	maxDamage = 1.0; 
	maxEnergy = 155; 
	minGunEnergy = 100; 
	maxGunEnergy = 150; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 8.0; 
	speed = 4.0; 
	speedModifier = 1.5; 
	range = 0; 
	visibleToSensor = true; 
	shadowDetailMask = 4; 
	dopplerVelocity = 0; 
	castLOS = true; 
	supression = false; 
	mapFilter = 2; 
	mapIcon = "M_turret"; 
	debrisId = flashDebrisMedium; 
	shieldShapeName = "shield"; 
	fireSound = SoundMissileTurretFire; 
	activationSound = SoundPlasmaTurretOn; 
	deactivateSound = SoundPlasmaTurretOff; 
	whirSound = SoundPlasmaTurretTurn; 
	explosionId = flashExpMedium; 
	description = "Rail Turret"; 
	damageSkinData = "objectDamageSkins"; 
}; 

function DeployableRail::onAdd(%this) 
{ 
	Sschedule("DeployableRail::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,20); 
	%this.shieldStrength = 0.005; 
	if (GameBase::getMapName(%this) == "") 
	{ 
		GameBase::setMapName (%this, "Rail Turret"); 
	} 
} 

function DeployableRail::deploy(%this) 
{ 
	GameBase::playSequence(%this,1,"deploy"); 
} 

function DeployableRail::onEndSequence(%this,%thread) 
{ 
	GameBase::setActive(%this,true); 
} 

function DeployableRail::onDestroyed(%this) 
{ 
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this); 
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "RailTurret"]--; 
} 

// Override base class just in case.
function DeployableRail::onPower(%this,%power,%generator) {}
function DeployableRail::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//----------------------------------------------------------------------------
//	DEPLOYABLE ICE TURRET
//----------------------------------------------------------------------------

$InvList[IceTurretPack] = 0;
$RemoteInvList[IceTurretPack] = 0;

$CanControl[IceTurretPack] = 1;
$EmbedController[IceTurretPack] = 1;
$CanAlwaysTeamDestroy[IceTurretPack] = 1;

function deployIceTurret::Initialize()
{
	$TeamItemCount[0 @ DeployableIceTurret] = 0;
	$TeamItemCount[1 @ DeployableIceTurret] = 0;
	$TeamItemCount[2 @ DeployableIceTurret] = 0;
	$TeamItemCount[3 @ DeployableIceTurret] = 0;
	$TeamItemCount[4 @ DeployableIceTurret] = 0;
	$TeamItemCount[5 @ DeployableIceTurret] = 0;
	$TeamItemCount[6 @ DeployableIceTurret] = 0;
	$TeamItemCount[7 @ DeployableIceTurret] = 0;
}


RocketData IceBolt
{
	bulletShapeName = "discb.dts";
	explosionTag = IceExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.25;
	damageType = $IceDamageType;
	explosionRadius = 0.25;
	kickBackStrength = 0.0;
	muzzleVelocity = 65.0;
	terminalVelocity = 50.0;
	acceleration = 200.0;
	totalTime = 8.5;
	liveTime = 18.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};

ItemImageData IceTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData IceTurretPack
{
	description = "Ice Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHead[ihDet];
	imageType = IceTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function IceTurretPack::onUse(%player,%item)
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

function IceTurretPack::onDeploy(%player,%item,%pos)
{
	if (IceTurretPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function IceTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,10))
		{
			%obj = getObjectType($los::object);
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
			%camera = newObject("camera","Turret",DeployableIceTurret,true);
			addToSet("MissionCleanup", %camera);
			GameBase::setTeam(%camera,GameBase::getTeam(%player));
			GameBase::setRotation(%camera,%rot);
			GameBase::setPosition(%camera,$los::position);
			Gamebase::setMapName(%camera,"Ice Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
			Client::sendMessage(%client,0,"Ice Turret deployed");
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%camera) @ "IceTurretPack"]++;
			Client::setOwnedObject(%client, %camera);
			Client::setOwnedObject(%client, %player);
			return true;
		}
		else 
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

TurretData DeployableIceTurret
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = IceBolt;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 55; // 30
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundJetHeavy;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Ice Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableIceTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Turret");
	}
}

function DeployableIceTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableIceTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableIceTurret::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	Turret::objectiveDestroyed(%this);
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
  	$TeamItemCount[GameBase::getTeam(%this) @ "IceTurretPack"]--;
}

// Override base class just in case.
function DeployableIceTurret::onPower(%this,%power,%generator) 
{
}
function DeployableIceTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//----------------------------------------------------------------------------
//	HGRAV TURRET
//----------------------------------------------------------------------------

$InvList[HGravTurretPack] = 1;
$RemoteInvList[HGravTurretPack] = 1;

LightningData HGravCharge
{
	bitmapName = "repairAdd.bmp";
	damageType = $GravDamageType;
	boltLength = 150.0;
	coneAngle = 40.0; //40
	damagePerSec = 0.0;
	energyDrainPerSec = 0.01;
	segmentDivisions = 2;
	numSegments = 1;
	beamWidth = 0.05;
	updateTime = 120;
	skipPercent = 0.1;
	displaceBias = 0.35;
	lightRange = 3.0;
	lightColor = { 0.15, 0.85, 0.15 };
	soundId = SoundELFFire;
};

function HGravCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
	%Zvalue = -15;
	%velocity = 0.0;
	%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
	Player::applyImpulse(%target, %shooterDir);
}

ItemImageData HGravTurretPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData HGravTurretPack
{
	description = "Hyper-Grav Turret";
	shapeFile = "camera";
	className = "Backpack";
      heading = $InvHead[ihDet];
	imageType = HGravTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HGravTurretPack::onUse(%player,%item)
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

function HGravTurretPack::onDeploy(%player,%item,%pos)
{
	if (HGravTurretPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function HGravTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,10))
		{
			%obj = getObjectType($los::object);
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
			%camera = newObject("Camera","Turret",DeployableHGravTurret,true);
			addToSet("MissionCleanup", %camera);
			GameBase::setTeam(%camera,GameBase::getTeam(%player));
			GameBase::setRotation(%camera,%rot);
			GameBase::setPosition(%camera,$los::position);
			Gamebase::setMapName(%camera,"Hyper-Grav Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
			Client::sendMessage(%client,0,"Hyper-Grav Turret deployed");
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%camera) @ "HGravTurretPack"]++;
			Client::setOwnedObject(%client, %camera);
			Client::setOwnedObject(%client, %player);
			return true;
		}
		else 
	Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

TurretData DeployableHGravTurret
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = HGravCharge;
	maxDamage = 0.65;
	maxEnergy = 30;
	minGunEnergy = 5;
	maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 50;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPickupAmmo;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Hyper-Grav Turret";
	damageSkinData = "objectDamageSkins";
	isSustained     = true;
	firingTimeMS    = 5000;
	energyRate      = 1.0;
};

function DeployableHGravTurret::onAdd(%this)
{
	schedule("DeployableHGravTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Hyper-Grav Turret");
	}
}

function DeployableHGravTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableHGravTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableHGravTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "HGravTurretPack"]--;
}

// Override base class just in case.
function DeployableHGravTurret::onPower(%this,%power,%generator)
{
}

function DeployableHGravTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}

//----------------------------------------------------------------------------
//	MISSILE TURRET PACK
//----------------------------------------------------------------------------

$InvList[RocketPack] = 1;
$RemoteInvList[RocketPack] = 1;

$CanAlwaysTeamDestroy[DeployableRocket] = 1;

function deployRocket::Initialize()
{
	$TeamItemCount[0 @ RocketPack] = 0;
	$TeamItemCount[1 @ RocketPack] = 0;
	$TeamItemCount[2 @ RocketPack] = 0;
	$TeamItemCount[3 @ RocketPack] = 0;
	$TeamItemCount[4 @ RocketPack] = 0;
	$TeamItemCount[5 @ RocketPack] = 0;
	$TeamItemCount[6 @ RocketPack] = 0;
	$TeamItemCount[7 @ RocketPack] = 0;
}

ItemImageData RocketPackImage 
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData RocketPack 
{
	description = "Missile Turret";
	shapeFile = "missileturret";
	className = "Backpack";
	heading = $InvHead[ihDet];
	imageType = RocketPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 950;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RocketPack::onUse(%player,%item) 
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

function RocketPack::onDeploy(%player,%item,%pos) 
{
	if (RocketPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function RocketPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,10))
		{
			%obj = getObjectType($los::object);
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
			%camera = newObject("camera","Turret",DeployableRocket,true);
			addToSet("MissionCleanup", %camera);
			GameBase::setTeam(%camera,GameBase::getTeam(%player));
			GameBase::setRotation(%camera,%rot);
			GameBase::setPosition(%camera,$los::position);
			Gamebase::setMapName(%camera,"Missile Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
			Client::sendMessage(%client,0,"Missile Turret deployed");
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%camera) @ "RocketPack"]++;
			Client::setOwnedObject(%client, %camera);
			Client::setOwnedObject(%client, %player);
			return true;
		}
		else 
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//-=-=-=-

TurretData DeployableRocket
{
	className = "Turret";
	shapeFile = "missileturret";
	projectileType = TurretMissile;
	maxDamage = 0.65;
	maxEnergy = 90;
	minGunEnergy = 50;
	maxGunEnergy = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.5;
	speed = 4.0;
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
	fireSound = SoundMissileTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Missile Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableRocket::verifyTarget(%this,%target)
{
	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
	return "True";
	else
	return "False";
}

function DeployableRocket::onAdd(%this) 
{
	schedule("DeployableRocket::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.015;
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Remote Rocket Turret");
}

function DeployableRocket::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableRocket::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function DeployableRocket::onDestroyed(%this) 
{
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	Turret::objectiveDestroyed(%this);
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
	$TeamItemCount[GameBase::getTeam(%this) @ "RocketPack"]--;
}

function DeployableRocket::onPower(%this,%power,%generator) 
{
}
function DeployableRocket::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//----------------------------------------------------------------------------
//	FLAK TURRET
//----------------------------------------------------------------------------

$InvList[FlakPack] = 1;
$RemoteInvList[FlakPack] = 1;

$CanControl[FlakPack] = 1;
$EmbedController[FlakPack] = 1;
$CanAlwaysTeamDestroy[FlakPack] = 1;

function deployFlakPack::Initialize()
{
  $TeamItemCount[0 @ FlakPack] = 0;
  $TeamItemCount[1 @ FlakPack] = 0;
  $TeamItemCount[2 @ FlakPack] = 0;
  $TeamItemCount[3 @ FlakPack] = 0;
  $TeamItemCount[4 @ FlakPack] = 0;
  $TeamItemCount[5 @ FlakPack] = 0;
  $TeamItemCount[6 @ FlakPack] = 0;
  $TeamItemCount[7 @ FlakPack] = 0;
}

ItemImageData FlakPackImage //image name while a pack
{
	shapeFile = "remoteturret";   //name of shape file, same as in turret.cs
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

RocketData FlakShell
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 8.0;
   kickBackStrength = 150.0;
   muzzleVelocity   = 200.0;
   terminalVelocity = 200.0;
   acceleration     = 1.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

TurretData DeployableFlak
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = FlakShell;
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 50;
	maxGunEnergy = 6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.8;
	speed = 4.0;
	speedModifier = 1.5;
	range = 300;//100
	visibleToSensor = true;
	shadowDetailMask = 8; //4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
   targetableFovRatio = 0.5;

	explosionId = flashExpMedium;
	description = "Remote Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableFlak::onAdd(%this)
{
	schedule("DeployableFlak::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Flak Turret");
	}
}

function DeployableFlak::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableFlak::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableFlak::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "FlakPack"]--;
}

// Override base class just in case.
function DeployableFlak::onPower(%this,%power,%generator) {}
function DeployableFlak::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//below, makes Flak Turret track air targets only, now turned on
function DeployableFlak::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

ItemData FlakPack
{
	description = "Flak Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   	heading = $InvHead[ihDet];
	imageType = FlakPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FlakPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function FlakPack::onDeploy(%player,%item,%pos)
{
	if (FlakPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) {
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function FlakPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableFlak",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableFlak",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableFlak,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Flak Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Flak Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "FlakPack"]++;
								echo("MSG: ",%client," deployed a Flak Turret");
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

function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(%num) {
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
		%obj = Group::getObject(%set,0);	
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;	
		

}

//----------------------------------------------------------------------------
// Remote deploy for items

function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(!%num) {
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
		%obj = Group::getObject(%set,0);	
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;	
		

}

function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%sensor = newObject("","Sensor",%shape,true);
 	        	   	addToSet("MissionCleanup", %sensor);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						GameBase::setPosition(%sensor,$los::position);
						Gamebase::setMapName(%sensor,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						playSound(SoundPickupBackpack,$los::position);
						echo("MSG: ",%client," deployed a ",%name);
						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}

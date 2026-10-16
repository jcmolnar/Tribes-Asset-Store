//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[IndoorPack] = 1;

$ItemMax[larmor, IndoorPack] = 0;	//Seraph
$ItemMax[lfemale, IndoorPack] = 0;	//Seraph
$ItemMax[earmor, IndoorPack] = 1;	//Slave
$ItemMax[efemale, IndoorPack] = 1;	//Slave
$ItemMax[marmor, IndoorPack] = 0;	//Pawn
$ItemMax[aarmor, IndoorPack] = 0;	//Navigator
$ItemMax[darmor, IndoorPack] = 0;	//Atomizer
$ItemMax[barmor, IndoorPack] = 0;	//Paladin

$TeamItemMax[IndoorPack] = 20;

function deployIndoorPack::Initialize()
{	$TeamItemCount[0 @ IndoorPack] = 0;
	$TeamItemCount[1 @ IndoorPack] = 0;
	$TeamItemCount[2 @ IndoorPack] = 0;
	$TeamItemCount[3 @ IndoorPack] = 0;
	$TeamItemCount[4 @ IndoorPack] = 0;
	$TeamItemCount[5 @ IndoorPack] = 0;
	$TeamItemCount[6 @ IndoorPack] = 0;
	$TeamItemCount[7 @ IndoorPack] = 0;
}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++


TurretData DeployableIndoor 
{ 
	className = "Turret"; 
	shapeFile = "indoorgun"; 
	projectileType = MiniFusionBolt; 
	maxDamage = 2.5; 
	maxEnergy = 60; 
	minGunEnergy = 20; 
	maxGunEnergy = 6; 
	reloadDelay = 0.4; 
	speed = 5.0; 
	speedModifier = 1.0; 
	range = 25; 
	visibleToSensor = true; 
	dopplerVelocity = 2; 
	castLOS = true; 
	supression = false; 
	supressable = false; 
	pinger = false; 
	mapFilter = 2; 
	mapIcon = "M_turret"; 
	debrisId = defaultDebrisMedium; 
	shieldShapeName = "shield"; 
	fireSound = SoundEnergyTurretFire; 
	activationSound = SoundEnergyTurretOn; 
	deactivateSound = SoundEnergyTurretOff; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	explosionId = debrisExpMedium; 
	description = "Indoor Turret"; 
}; 
 

function DeployableIndoor::onAdd(%this) 
{ 
	schedule("DeployableIndoor::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,6); 
	%this.shieldStrength = 0.030; 
	
	if (GameBase::getMapName(%this) == "") 
	{ 
		GameBase::setMapName (%this, "Remote Indoor Turret");
	} 
} 

function DeployableIndoor::deploy(%this) 
{ 
	GameBase::playSequence(%this,1,"deploy"); 
} 

function DeployableIndoor::onEndSequence(%this,%thread) 
{ 
	GameBase::setActive(%this,true); 
} 

function DeployableIndoor::onDestroyed(%this) 
{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "IndoorPack"]--; 
} 

function DeployableIndoor::onPower(%this,%power,%generator) {} 

function DeployableIndoor::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
} 

TurretData DeployableIndoor 
{ 
	className = "Turret"; 
	shapeFile = "indoorgun"; 
	projectileType = MiniFusionBolt; 
	maxDamage = 2.5; 
	maxEnergy = 60; 
	minGunEnergy = 20; 
	maxGunEnergy = 6; 
	reloadDelay = 0.4; 
	speed = 5.0; 
	speedModifier = 1.0; 
	range = 25; 
	visibleToSensor = true; 
	dopplerVelocity = 2; 
	castLOS = true; 
	supresson = false; 
	supressable = false; 
	pinger = false; 
	mapFilter = 2; 
	mapIcon = "M_turret"; 
	debrisId = defaultDebrisMedium; 
	shieldShapeName = "shield"; 
	fireSound = SoundEnergyTurretFire; 
	activationSound = SoundEnergyTurretOn; 
	deactivateSound = SoundEnergyTurretOff; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	explosionId = debrisExpMedium; 
	description = "Indoor Turret"; 
}; 
 

function DeployableIndoor::onAdd(%this) 
{ 
	schedule("DeployableIndoor::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,6);
	%this.shieldStrength = 0.030; 
	if (GameBase::getMapName(%this) == "") 
	{ 
		GameBase::setMapName (%this, "Remote Indoor Turret"); 
	} 
}


function DeployableIndoor::deploy(%this) 
{ 
	GameBase::playSequence(%this,1,"deploy"); 
} 

function DeployableIndoor::onEndSequence(%this,%thread) 
{ 
	GameBase::setActive(%this,true); 
} 

function DeployableIndoor::onDestroyed(%this) 
{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "IndoorPack"]--; 
} 

function DeployableIndoor::onPower(%this,%power,%generator)
{
}

function DeployableIndoor::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
} 

TurretData IndoorTurret 
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = MiniFusionBolt;
	maxDamage = 2.5;
	maxEnergy = 60;
	minGunEnergy = 20;
	maxGunEnergy = 6;
	reloadDelay = 0.4;
	speed = 5.0;
	speedModifier = 1.0;
	range = 25;
	visibleToSensor = true;
	dopplerVelocity = 2;
	castLOS = true;
	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundEnergyTurretFire;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "Indoor Turret";
}; 


ItemImageData IndoorPackImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData IndoorPack 
{ 
	description = "Indoor Turret"; 
	shapeFile = "indoorgun"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = IndoorPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function IndoorPack::onUse(%player,%item) 
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

function IndoorPack::onDeploy(%player,%item,%pos) 
{ 
	if (IndoorPack::deployShape(%player,%item)) 
	{ 
		Player::decItemCount(%player,%item); 
	} 
}

function IndoorPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
		if (GameBase::getLOSInfo(%player,10)) 
		{ 
			%obj = "SimTerrain"; 
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") 
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
				if(%obj == "SimTerrain" ) 
				{ 
					%set = newObject("set",SimSet); 
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); 
					%num = CountObjects(%set,"DeployableIndoor",%num); 
					deleteObject(%set);
					if($MaxNumTurretsInBox > %num)
					{
						%camera = newObject("Camera","Turret",DeployableIndoor,true); 
						addToSet("MissionCleanup", %camera); 
						GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); 
						GameBase::setPosition(%camera,$los::position); 
						Gamebase::setMapName(%camera,"Indoor Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
						Client::setOwnedObject(%client, %turret);
						Client::setOwnedObject(%client, %player);
						Client::sendMessage(%client,0,"Indoor Turret deployed"); 
						playSound(SoundPickupBackpack,$los::position); 
						$TeamItemCount[GameBase::getTeam(%camera) @ "IndoorPack"]++; 
						return true; 
					} 
					else Client::sendMessage(%client,0,"Interference from other Indoor turrets in the area"); 
				} 
			} 
			else 
			{ 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
			} 
		} 
		else 
		{ 
			Client::sendMessage(%client,0,"Deploy position out of range"); 
		} 
	} 
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
}
//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[DeployableElfTurret] = 1;

$ItemMax[larmor, DeployableElfTurret] = 0;	//Seraph
$ItemMax[lfemale, DeployableElfTurret] = 0;	//Seraph
$ItemMax[earmor, DeployableElfTurret] = 1;	//Slave
$ItemMax[efemale, DeployableElfTurret] = 1;	//Slave
$ItemMax[marmor, DeployableElfTurret] = 0;	//Pawn
$ItemMax[aarmor, DeployableElfTurret] = 0;	//Navigator
$ItemMax[darmor, DeployableElfTurret] = 0;	//Atomizer
$ItemMax[barmor, DeployableElfTurret] = 0;	//Paladin

$TeamItemMax[DeployableElfTurret] = 10;

function deployDeployableElfTurret::Initialize()
{	$TeamItemCount[0 @ DeployableElfTurret] = 0;
	$TeamItemCount[1 @ DeployableElfTurret] = 0;
	$TeamItemCount[2 @ DeployableElfTurret] = 0;
	$TeamItemCount[3 @ DeployableElfTurret] = 0;
	$TeamItemCount[4 @ DeployableElfTurret] = 0;
	$TeamItemCount[5 @ DeployableElfTurret] = 0;
	$TeamItemCount[6 @ DeployableElfTurret] = 0;
	$TeamItemCount[7 @ DeployableElfTurret] = 0;
}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++


TurretData DeployableElf 
{ 
	maxDamage = 1.0; 
	maxEnergy = 350; 
	minGunEnergy = 50; 
	maxGunEnergy = 5; 
	range = 40; 
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
	explosionId = LargeShockwave; 
	description = "ELF Turret"; 
	fireSound = SoundGeneratorPower; 
	activationSound = SoundChainTurretOn; 
	deactivateSound = SoundChainTurretOff; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	isSustained = true; 
	firingTimeMS = 750; 
	energyRate = 30.0; 
};  

function DeployableElf::onAdd(%this) 
{ 
	schedule("DeployableElf::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,5); 
	%this.shieldStrength = 0.030; 
	if (GameBase::getMapName(%this) == "") 
	{ 
		GameBase::setMapName (%this, "Elf Turret"); 
	} 
} 

function DeployableElf::deploy(%this) 
{ 
	GameBase::playSequence(%this,1,"deploy"); 
} 

function DeployableElf::onEndSequence(%this,%thread) 
{ 
	GameBase::setActive(%this,true); 
} 

function DeployableElf::onDestroyed(%this) 
{ 
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this); CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableElfTurretTurret"]--; 
} 

function DeployableElf::onPower(%this,%power,%generator) {} 

function DeployableElf::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this,10); 
	GameBase::setActive(%this,true); 
} 

//==========================



TurretData ELFTurret 
{ 
	maxDamage = 1.0;
	maxEnergy = 350; 
	minGunEnergy = 50; 
	maxGunEnergy = 5; 
	range = 40; 
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
	explosionId = LargeShockwave; 
	description = "ELF Turret"; 
	fireSound = SoundGeneratorPower; 
	activationSound = SoundChainTurretOn; 
	deactivateSound = SoundChainTurretOff; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	isSustained = true; 
	firingTimeMS = 750; 
	energyRate = 30.0; 
}; 


ItemImageData DeployableElfTurretImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};


ItemData DeployableElfTurret 
{ 
	description = "Elf Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = DeployableElfTurretImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function DeployableElfTurret::onUse(%player,%item) 
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

function DeployableElfTurret::onDeploy(%player,%item,%pos) 
{ 
	if (DeployableElfTurret::deployShape(%player,%item)) 
	{ 
		Player::decItemCount(%player,%item); 
	} 
} 

function CountObjects(%set,%name,%num) 
{ 
	%count = 0; 
	for(%i=0;%i<%num;%i++) 
	{ 
		%obj=Group::getObject(%set,%i); 
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++; } 
		return %count; 
		} 

function DeployableElfTurret::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
		if (GameBase::getLOSInfo(%player,10)) 
		{ 
			%obj = "SimTerrain" ; 
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") 
			{ 
				%set = newObject("set",SimSet); 
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); 
				%num = CountObjects(%set,"DeployableElf",%num); 
				deleteObject(%set); 
				if (%obj == "SimTerrain" ) 
				{ 
					%set = newObject("set",SimSet); 
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); 
					%num = CountObjects(%set,"DeployableElf",%num); 
					deleteObject(%set); 
					if(0 == %num) 
					{ 
						if (Vector::dot($los::normal,"0 0 1") > 0.7) 
						{ 
							%rot = GameBase::getRotation(%player); 
							%turret = newObject("hellfiregun","Turret",DeployableElf,true); addToSet("MissionCleanup", %turret); 
							GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); 
							GameBase::setRotation(%turret,%rot); 
							Gamebase::setMapName(%turret,"Elf Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
							Client::setOwnedObject(%client, %turret);
							Client::setOwnedObject(%client, %player);
							Client::sendMessage(%client,0,"Elf Turret deployed"); 
							playSound(SoundPickupBackpack,$los::position); 
							$TeamItemCount[GameBase::getTeam(%player) @ "DeployableElfTurret"]++;echo("MSG: ",%client," deployed a Elf Turret"); 
							return true;  
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
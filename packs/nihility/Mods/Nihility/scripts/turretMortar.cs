//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[TargetPack] = 1;

$ItemMax[larmor, TargetPack] = 0;	//Seraph
$ItemMax[lfemale, TargetPack] = 0;	//Seraph
$ItemMax[earmor, TargetPack] = 1;	//Slave
$ItemMax[efemale, TargetPack] = 1;	//Slave
$ItemMax[marmor, TargetPack] = 0;	//Pawn
$ItemMax[aarmor, TargetPack] = 0;	//Navigator
$ItemMax[darmor, TargetPack] = 0;	//Atomizer
$ItemMax[barmor, TargetPack] = 0;	//Paladin

$TeamItemMax[TargetPack] = 10;

function deployDeployableTargetPack::Initialize()
{	$TeamItemCount[0 @ TargetPack] = 0;
	$TeamItemCount[1 @ TargetPack] = 0;
	$TeamItemCount[2 @ TargetPack] = 0;
	$TeamItemCount[3 @ TargetPack] = 0;
	$TeamItemCount[4 @ TargetPack] = 0;
	$TeamItemCount[5 @ TargetPack] = 0;
	$TeamItemCount[6 @ TargetPack] = 0;
	$TeamItemCount[7 @ TargetPack] = 0;
}


//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++



TurretData DeployableMortar 
{
	className = "Turret";
	shapeFile = "mortar_turret";
	projectileType = MortarTurretShell;
	maxDamage = 1.0;
	maxEnergy = 45;
	minGunEnergy = 45;
	maxGunEnergy = 100;
	sequenceSound[0] =
	{
		"deploy", SoundActivateMotionSensor
	};
	reloadDelay = 2.0;
	speed = 2.0;
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
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	explosionId = LargeShockwave;
	description = "Remote Mortar Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableMortar::onAdd(%this)
{
	schedule("DeployableMortar::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,7);
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Mortar Turret");
	}
}

function DeployableMortar::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableMortar::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableMortar::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "TargetPack"]--;
}

function DeployableMortar::onPower(%this,%power,%generator)
{
}

function DeployableMortar::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,7);
	GameBase::setActive(%this,true);
} 

ItemImageData TargetPackImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};
ItemData TargetPack 
{
	description = "Mortar Turret";
	shapeFile = "mortar_turret";
	className = "Backpack";
	heading = "gDeployable Turrets";
	imageType = TargetPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true; 
}; 

function TargetPack::onUse(%player,%item)
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

function TargetPack::onMount(%player,%item)
{
	%client = Player::getClient(%player); Bottomprint(%client, "The Mortar Turret has no auto-sensor and must be controlled manually to fire."); 
} 

function TargetPack::onDeploy(%player,%item,%pos)
{
	if (TargetPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	} 
} 

function TargetPack::deployShape(%player,%item)
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
				%num = CountObjects(%set,"DeployableMortar",%num); 
				deleteObject(%set); 
				if($MaxNumTurretsInBox > %num)
				{
					%set = newObject("set",SimSet); 
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num); 
					deleteObject(%set); 
					if(0 == %num) 
					{ 
						if (Vector::dot($los::normal,"0 0 1") > 0.7)
						{ 
							%rot = GameBase::getRotation(%player); 
							%turret = newObject("remoteTurret","Turret",DeployableMortar,true); addToSet("MissionCleanup", %turret); 
							GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); 
							GameBase::setRotation(%turret,%rot); 
							Gamebase::setMapName(%turret,"Mortar Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
							Client::sendMessage(%client,0,"Remote Turret deployed"); 
							playSound(SoundPickupBackpack,$los::position); 
							$TeamItemCount[GameBase::getTeam(%player) @ "TargetPack"]++; 
							echo("MSG: ",%client," deployed a Mortar Turret");
							Client::setOwnedObject(%client, %turret); 
							Client::setOwnedObject(%client, %player); return true;  
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

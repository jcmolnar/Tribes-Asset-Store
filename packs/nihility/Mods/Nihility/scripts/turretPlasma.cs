//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[LaserTurret] = 1;

$ItemMax[larmor, LaserTurret] = 0;	//Seraph
$ItemMax[lfemale, LaserTurret] = 0;	//Seraph
$ItemMax[earmor, LaserTurret] = 1;	//Slave
$ItemMax[efemale, LaserTurret] = 1;	//Slave
$ItemMax[marmor, LaserTurret] = 0;	//Pawn
$ItemMax[aarmor, LaserTurret] = 0;	//Navigator
$ItemMax[darmor, LaserTurret] = 0;	//Atomizer
$ItemMax[barmor, LaserTurret] = 0;	//Paladin

$TeamItemMax[LaserTurret] = 10;

function deployLaserTurret::Initialize()
{	$TeamItemCount[0 @ LaserTurret] = 0;
	$TeamItemCount[1 @ LaserTurret] = 0;
	$TeamItemCount[2 @ LaserTurret] = 0;
	$TeamItemCount[3 @ LaserTurret] = 0;
	$TeamItemCount[4 @ LaserTurret] = 0;
	$TeamItemCount[5 @ LaserTurret] = 0;
	$TeamItemCount[6 @ LaserTurret] = 0;
	$TeamItemCount[7 @ LaserTurret] = 0;
}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

TurretData DeployablePlasma 
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = FusionBolt;
	maxDamage = 1.5;
	maxEnergy = 200;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	sequenceSound[0] =
	{
		"deploy", SoundActivateMotionSensor
	};
	reloadDelay = 0.8;
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
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	explosionId = flashExpMedium;
	description = "Remote Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployablePlasma::onAdd(%this)
{
	schedule("DeployablePlasma::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Plasma Turret");
	}
}

function DeployablePlasma::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployablePlasma::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployablePlasma::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
	$TeamItemCount[GameBase::getTeam(%this) @ "LaserTurret"]--;
}

function DeployablePlasma::onPower(%this,%power,%generator)
{
}

function DeployablePlasma::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
} 

ItemImageData LaserTurretImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData LaserTurret 
{
	description = "Plasma Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = LaserTurretImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function LaserTurret::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{ 
		Player::mountItem(%player,%item,$BackpackSlot); 
	} else 
	{ 
		Player::deployItem(%player,%item);
	}
} 

function LaserTurret::onDeploy(%player,%item,%pos) 
{ 
	if (LaserTurret::deployShape(%player,%item)) 
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
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++;
	} 
	return %count; 
} 

function LaserTurret::deployShape(%player,%item) 
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
				%num = CountObjects(%set,"DeployablePlasma",%num); 
				deleteObject(%set); 
				if($MaxNumTurretsInBox > %num) 
				{ 
					%set = newObject("set",SimSet); 
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); 
					%num = CountObjects(%set,"DeployablePlasma",%num); 
					deleteObject(%set); 
					if(0 == %num) 
					{ 
						if (Vector::dot($los::normal,"0 0 1") > 0.7) 
						{ 
							%rot = GameBase::getRotation(%player); 
							%turret = newObject("hellfiregun","Turret",DeployablePlasma,true);
							addToSet("MissionCleanup", %turret); 
							GameBase::setTeam(%turret,GameBase::getTeam(%player));
							GameBase::setPosition(%turret,$los::position); 
							GameBase::setRotation(%turret,%rot); 
							Gamebase::setMapName(%turret,"Plasma Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
							Client::setOwnedObject(%client, %turret);
							Client::setOwnedObject(%client, %player);
							Client::sendMessage(%client,0,"Plasma Turret deployed"); 
							playSound(SoundPickupBackpack,$los::position); 
							$TeamItemCount[GameBase::getTeam(%player) @ "LaserTurret"]++;echo("MSG: ",%client," deployed a Plasma Turret");  
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

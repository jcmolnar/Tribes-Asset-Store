//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[RocketPack] = 1;

$ItemMax[larmor, RocketPack] = 0;	//Seraph
$ItemMax[lfemale, RocketPack] = 0;	//Seraph
$ItemMax[earmor, RocketPack] = 1;	//Slave
$ItemMax[efemale, RocketPack] = 1;	//Slave
$ItemMax[marmor, RocketPack] = 0;	//Pawn
$ItemMax[aarmor, RocketPack] = 0;	//Navigator
$ItemMax[darmor, RocketPack] = 0;	//Atomizer
$ItemMax[barmor, RocketPack] = 0;	//Paladin

$TeamItemMax[RocketPack] = 10;

function deployRocketPack::Initialize()
{	$TeamItemCount[0 @ RocketPack] = 0;
	$TeamItemCount[1 @ RocketPack] = 0;
	$TeamItemCount[2 @ RocketPack] = 0;
	$TeamItemCount[3 @ RocketPack] = 0;
	$TeamItemCount[4 @ RocketPack] = 0;
	$TeamItemCount[5 @ RocketPack] = 0;
	$TeamItemCount[6 @ RocketPack] = 0;
	$TeamItemCount[7 @ RocketPack] = 0;
}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

TurretData DeployableRocket 
{
	className = "Turret";
	shapeFile = "missileturret";
	projectileType = TurretMissile;
	maxDamage = 1.7;
	maxEnergy = 90;
	minGunEnergy = 50;
	maxGunEnergy = 50;
	sequenceSound[0] =
	{
		"deploy", SoundActivateMotionSensor
	};
	reloadDelay = 2.0;
	speed = 6.0;
	speedModifier = 4.5;
	range = 175;
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
	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) return "True"; else return "False";
}

function DeployableRocket::onAdd(%this)
{
	schedule("DeployableRocket::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.015;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Remote Rocket");
	}
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

ItemImageData RocketPackImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData RocketPack 
{ 
	description = "Missile Turret"; 
	shapeFile = "missileturret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = RocketPackImage; 
	shadowDetailMask = 4; 
	mass = 3.0; 
	elasticity = 0.2; 
	price = 600; 
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
			%obj = "SimTerrain" ;
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
			{
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
				deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
				%num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
				deleteObject(%set); if(0 == %num)
				{
					if (Vector::dot($los::normal,"0 0 1") > 0.7)
					{
						%rot = GameBase::getRotation(%player);
						%turret = newObject("missileturret","Turret",DeployableRocket,true); 
						addToSet("MissionCleanup", %turret); 
						GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
						GameBase::setPosition(%turret,$los::position); 
						GameBase::setRotation(%turret,%rot);
						Gamebase::setMapName(%turret,"Missile#" @ $totalNumTurrets++ @ " " @ 
						Client::getName(%client));
						Client::setOwnedObject(%client, %turret);
						Client::setOwnedObject(%client, %player);
						Client::sendMessage(%client,0,"Missile Turret deployed"); 
						playSound(SoundPickupBackpack,$los::position); 
						$TeamItemCount[GameBase::getTeam(%player) @ "RocketPack"]++;
						echo("MSG: ",%client," deployed a Rocket Turret");  
						return true;  
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

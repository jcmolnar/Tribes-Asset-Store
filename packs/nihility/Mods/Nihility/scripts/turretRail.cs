//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[RailTurret] = 1;

$ItemMax[larmor, RailTurret] = 0;	//Seraph
$ItemMax[lfemale, RailTurret] = 0;	//Seraph
$ItemMax[earmor, RailTurret] = 1;	//Slave
$ItemMax[efemale, RailTurret] = 1;	//Slave
$ItemMax[marmor, RailTurret] = 0;	//Pawn
$ItemMax[aarmor, RailTurret] = 0;	//Navigator
$ItemMax[darmor, RailTurret] = 0;	//Atomizer
$ItemMax[barmor, RailTurret] = 0;	//Paladin

$TeamItemMax[RailTurret] = 5;

function deployRailTurret::Initialize()
{	$TeamItemCount[0 @ RailTurret] = 0;
	$TeamItemCount[1 @ RailTurret] = 0;
	$TeamItemCount[2 @ RailTurret] = 0;
	$TeamItemCount[3 @ RailTurret] = 0;
	$TeamItemCount[4 @ RailTurret] = 0;
	$TeamItemCount[5 @ RailTurret] = 0;
	$TeamItemCount[6 @ RailTurret] = 0;
	$TeamItemCount[7 @ RailTurret] = 0;
}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

LaserData railLaser 
{ laserBitmapName = "red_blink2.bmp"; hitName = "shockwave_large.dts"; damageConversion = 0.025; baseDamageType = $SniperDamageType; beamTime = 1.2; lightRange = 5.0; lightColor = { 0.25, 1.0, 0.25 }; detachFromShooter = true; hitSoundId = debrisSmallExplosion; };


TurretData DeployableRail 
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = railLaser;
	maxDamage = 1.0;
	maxEnergy = 155;
	minGunEnergy = 75;
	maxGunEnergy = 80;
	sequenceSound[0] =
	{
		"deploy", SoundActivateMotionSensor
	};
	reloadDelay = 4.0;
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
	schedule("DeployableRail::deploy(" @ %this @ ");",1,%this);
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

function DeployableRail::onPower(%this,%power,%generator)
{
}

function DeployableRail::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,20);
	GameBase::setActive(%this,true);
} 


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
	heading = "gDeployable Turrets";
	imageType = VulcanTurretImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 800;
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
		if (GameBase::getLOSInfo(%player,10)) { %obj = "SimTerrain" ;
		if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") { %set = newObject("set",SimSet);
		%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
		%num = CountObjects(%set,"DeployableVulcan",%num);
		deleteObject(%set);
		if($MaxNumTurretsInBox > %num)
		{
			%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
			%num = CountObjects(%set,"DeployablePlasma",%num); deleteObject(%set); if(0 == %num)
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
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
					$TeamItemCount[GameBase::getTeam(%player) @ "RailTurret"]++;echo("MSG: ",%client," deployed a Rail Turret"); 
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

ItemImageData RailTurretImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};
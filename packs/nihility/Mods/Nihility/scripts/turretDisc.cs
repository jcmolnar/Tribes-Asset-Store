//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[DiscTurret] = 1;

$ItemMax[larmor, DiscTurret] = 0;	//Seraph
$ItemMax[lfemale, DiscTurret] = 0;	//Seraph
$ItemMax[earmor, DiscTurret] = 1;	//Slave
$ItemMax[efemale, DiscTurret] = 1;	//Slave
$ItemMax[marmor, DiscTurret] = 0;	//Pawn
$ItemMax[aarmor, DiscTurret] = 0;	//Navigator
$ItemMax[darmor, DiscTurret] = 0;	//Atomizer
$ItemMax[barmor, DiscTurret] = 0;	//Paladin

$TeamItemMax[DiscTurret] = 10;

function deployDiscTurret::Initialize()
{	$TeamItemCount[0 @ DiscTurret] = 0;
	$TeamItemCount[1 @ DiscTurret] = 0;
	$TeamItemCount[2 @ DiscTurret] = 0;
	$TeamItemCount[3 @ DiscTurret] = 0;
	$TeamItemCount[4 @ DiscTurret] = 0;
	$TeamItemCount[5 @ DiscTurret] = 0;
	$TeamItemCount[6 @ DiscTurret] = 0;
	$TeamItemCount[7 @ DiscTurret] = 0;
}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

//DISC TURRET, MODIFIED BY AUTO, BY FOLGRIM
ItemImageData DiscTurretImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData DiscTurret 
{ 
	description = "Disc Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = DiscTurretImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function DiscTurret::onUse(%player,%item) 
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

function DiscTurret::onDeploy(%player,%item,%pos) 
{ 
	if (DiscTurret::deployShape(%player,%item)) 
{ 
Player::decItemCount(%player,%item); } 
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

function DiscTurret::deployShape(%player,%item) 
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
	%num = CountObjects(%set,"DeployableDisc ",%num); 
	deleteObject(%set); 
	if($MaxNumTurretsInBox > %num) 
	{ 
		%set = newObject("set",SimSet); 
		%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); 
		%num = CountObjects(%set,"DeployableDisc ",%num); 
		deleteObject(%set); 
		if(0 == %num) 
		{ 
			if (Vector::dot($los::normal,"0 0 1") > 0.7) 
			{ 
				%rot = GameBase::getRotation(%player); 
				%turret = newObject("hellfiregun","Turret",DeployableDisc ,true); addToSet("MissionCleanup", %turret); 
				GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); 
				GameBase::setRotation(%turret,%rot); 
				Gamebase::setMapName(%turret,"Disc Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
				Client::setOwnedObject(%client, %turret);
				Client::setOwnedObject(%client, %player);
				Client::sendMessage(%client,0,"Disc Turret deployed"); 
				playSound(SoundPickupBackpack,$los::position); 
				$TeamItemCount[GameBase::getTeam(%player) @ "DiscTurret"]++;echo("MSG: ",%client," deployed a Disc Turret");  
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

$TeamItemCount[0 @ DiscTurret] = 0; 
$TeamItemCount[1 @ DiscTurret] = 0; 
$TeamItemCount[2 @ DiscTurret] = 0; 
$TeamItemCount[3 @ DiscTurret] = 0; 
$TeamItemCount[4 @ DiscTurret] = 0; 
$TeamItemCount[5 @ DiscTurret] = 0; 
$TeamItemCount[6 @ DiscTurret] = 0; 
$TeamItemCount[7 @ DiscTurret] = 0; 

//==================Exp info

ExplosionData discturretExp
{
	shapeName = "bluex.dts";
	soundId   = rocketExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 8.0;
	timeScale = 1.5;
	timeZero = 0.250;
	timeOne  = 0.850;
	colors[0]  = { 0.4, 0.4,  1.0 };
	colors[1]  = { 1.0, 1.0,  1.0 };
	colors[2]  = { 1.0, 0.95, 1.0 };
	radFactors = { 0.5, 1.0, 1.0 };
};
 
//========================Projectile Info
BulletData DiscBolt 
{
	bulletShapeName = "discb.dts";
	explosionTag = discturretExp;
	mass = 0.05;
	damageClass = 0;
	damageValue = 0.35;
	damageType = $ExplosionDamageType;
	muzzleVelocity = 80.0;
	totalTime = 12.0;
	liveTime = 8.0;
	isVisible = True;
	rotationPeriod = 1.5;
}; 

	

//=========================================Turret Settings


TurretData DeployableDisc 
{
	className = "Turret";
	shapeFile = "mortar_turret";//hellfiregun   gunturet   mortar_turret
	projectileType = DiscBolt;
	maxDamage = 1.7;
	maxEnergy = 400;
	minGunEnergy = 35;
	maxGunEnergy = 10;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 2.0;
	speedModifier = 1.5;
	range = 200;
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
	description = "Disc Turret";
	damageSkinData = "objectDamageSkins"; };

function DeployableDisc::onAdd(%this)
{
	schedule("DeployableDisc::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Disc Turret");
	}
}

function DeployableDisc::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableDisc::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableDisc::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
	$TeamItemCount[GameBase::getTeam(%this) @ "DiscTurret"]--;
}

function DeployableDisc::onPower(%this,%power,%generator)
{
}

function DeployableDisc::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}
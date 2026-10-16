//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[ShockPack] = 1;

$ItemMax[larmor, ShockPack] = 0;	//Seraph
$ItemMax[lfemale, ShockPack] = 0;	//Seraph
$ItemMax[earmor, ShockPack] = 1;	//Slave
$ItemMax[efemale, ShockPack] = 1;	//Slave
$ItemMax[marmor, ShockPack] = 0;	//Pawn
$ItemMax[aarmor, ShockPack] = 0;	//Navigator
$ItemMax[darmor, ShockPack] = 0;	//Atomizer
$ItemMax[barmor, ShockPack] = 0;	//Paladin

$TeamItemMax[ShockPack] = 20;

function deployShockPack::Initialize()
{	$TeamItemCount[0 @ ShockPack] = 0;
	$TeamItemCount[1 @ ShockPack] = 0;
	$TeamItemCount[2 @ ShockPack] = 0;
	$TeamItemCount[3 @ ShockPack] = 0;
	$TeamItemCount[4 @ ShockPack] = 0;
	$TeamItemCount[5 @ ShockPack] = 0;
	$TeamItemCount[6 @ ShockPack] = 0;
	$TeamItemCount[7 @ ShockPack] = 0;
}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++


TurretData DeployableShock 
{ 
maxDamage = 1.5; 
maxEnergy = 110; 
minGunEnergy = 15; 
maxGunEnergy = 20; 
reloadDelay = 2.0; 
fireSound = SoundMortarTurretFire; 
activationSound = SoundMortarTurretOn; 
deactivateSound = SoundMortarTurretOff; 
whirSound = SoundMortarTurretTurn; 
range = 30; 
dopplerVelocity = 0; 
castLOS = true; 
supression = false; 
mapFilter = 2; 
mapIcon = "M_turret"; 
visibleToSensor = true; 
debrisId = defaultDebrisMedium; 
className = "Turret"; 
shapeFile = "indoorgun"; 
shieldShapeName = "shield_medium"; 
speed = 5.0; 
speedModifier = 1.50; 
projectileType = ShockShell; 
damageSkinData = "objectDamageSkins"; 
shadowDetailMask = 8; 
explosionId = LargeShockwave; 
description = "Shock Turret"; 
}; 

function DeployableShock::onAdd(%this) 
{ 
schedule("DeployableShock::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,6); 
%this.shieldStrength = 0.010; 

if (GameBase::getMapName(%this) == "") 
{ 
GameBase::setMapName (%this, "Remote Shock Turret"); 
} 
} 

function DeployableShock::deploy(%this) 
{ 
GameBase::playSequence(%this,1,"deploy"); 
} 

function DeployableShock::onEndSequence(%this,%thread) 
{ 
GameBase::setActive(%this,true); 
} 

function DeployableShock::onDestroyed(%this) 
{ 
Turret::onDestroyed(%this); 
$TeamItemCount[GameBase::getTeam(%this) @ "ShockPack"]--; 
} 

function DeployableShock::onPower(%this,%power,%generator) {} 

function DeployableShock::onEnabled(%this) 
{ 
GameBase::setRechargeRate(%this,5); 
GameBase::setActive(%this,true); 
} 


ItemImageData ShockPackImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData ShockPack 
{ 
description = "Shock Turret"; 
shapeFile = "indoorgun"; 
className = "Backpack"; 
heading = "gDeployable Turrets"; 
imageType = ShockPackImage; 
shadowDetailMask = 4; 
mass = 2.0; 
elasticity = 0.2; 
price = 600; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true; 
}; 

function ShockPack::onUse(%player,%item) 
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

function ShockPack::onDeploy(%player,%item,%pos) 
{ 
if (ShockPack::deployShape(%player,%item)) 
{ 
Player::decItemCount(%player,%item); 
} 
} 

function ShockPack::deployShape(%player,%item) 
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
%num = CountObjects(%set,"DeployableShock",%num); 
deleteObject(%set); 
if($MaxNumTurretsInBox > %num) 
{ 
%camera = newObject("Camera","Turret",DeployableShock,true); 
addToSet("MissionCleanup", %camera); 
GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); 
GameBase::setPosition(%camera,$los::position); 
Gamebase::setMapName(%camera,"Shock Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); 
Client::setOwnedObject(%client, %turret);
Client::setOwnedObject(%client, %player);

Client::sendMessage(%client,0,"Shock Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "ShockPack"]++; 
return true; 
} 
else Client::sendMessage(%client,0,"Interference from other Shock turrets in the area"); 
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

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[BuilderPole] = 1;

$TeamItemMax[BuilderPole] = 20;

$ItemMax[larmor, BuilderPole] = 0;	//Seraph
$ItemMax[lfemale, BuilderPole] = 0;	//Seraph
$ItemMax[earmor, BuilderPole] = 1;	//Slave
$ItemMax[efemale, BuilderPole] = 1;	//Slave
$ItemMax[marmor, BuilderPole] = 0;	//Pawn
$ItemMax[aarmor, BuilderPole] = 0;	//Navigator
$ItemMax[darmor, BuilderPole] = 0;	//Atomizer
$ItemMax[barmor, BuilderPole] = 0;	//Paladin

//function deployBuilderPole::Initialize()
//{	
//	$TeamItemCount[0 @ BuilderPole] = 0;
//	$TeamItemCount[1 @ BuilderPole] = 0;
//	$TeamItemCount[2 @ BuilderPole] = 0;
//	$TeamItemCount[3 @ BuilderPole] = 0;
//	$TeamItemCount[4 @ BuilderPole] = 0;
//	$TeamItemCount[5 @ BuilderPole = 0;
//	$TeamItemCount[6 @ BuilderPole] = 0;
//	$TeamItemCount[7 @ BuilderPole] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData BuilderPoleImage 
{ 
shapeFile = "ammopack";
mountPoint = 2;
mountOffset = { 0, 0, 0 };
mountRotation = { 90, 0, 0 };
firstPerson = false;
}; 

ItemData BuilderPole 
{ 
description = "Scaffolding"; 
shapeFile = "ammopack"; 
className = "Backpack"; 
heading = "hDeployable Base Objects"; 
imageType = BuilderPoleImage; 
shadowDetailMask = 4; 
mass = 1.5; 
elasticity = 0.2; 
price = 50; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true; 
}; 

function BuilderPole::onUse(%player,%item) 
{ 
if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
{ 
Player::mountItem(%player,%item,$BackpackSlot); 
} 
else 
{ 
Player::deployItem(%player,%item); } 
} 

function BuilderPole::onDeploy(%player,%item,%pos) 
{ 
if (BuilderPole::deployShape(%player,%item)) 
{ 
Player::decItemCount(%player,%item); 
$TeamItemCount[GameBase::getTeam(%player) @ "BuilderPole"]++;
echo("MSG: ",%client," deployed some Scaffolding");  
} 
} 

function BuilderPole::deployShape(%player,%item) 
{ 
%client = Player::getClient(%player); 
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
{ 
if (GameBase::getLOSInfo(%player,10)) 
{ 
%obj = "SimTerrain" ; 
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
%rot = Vector::getRotation($los::normal); } 
} 
if(checkDeployArea(%client,$los::position)) 
{ 
%mSensor = newObject("pole","StaticShape",LargeAntenna,true); 
addToSet("MissionCleanup", %mSensor); 
GameBase::setTeam(%mSensor,GameBase::getTeam(%player)); 
GameBase::setRotation(%mSensor,%rot); 
GameBase::setPosition(%mSensor,$los::position); 
Gamebase::setMapName(%mSensor,"Scaffolding"); 
Client::sendMessage(%client,0,"Scaffolding deployed"); 
playSound(SoundPickupBackpack,$los::position); 
echo("MSG: ",%client," deployed some Scaffolding"); 
return true; 
} 
} 
else 
{ 
Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } 
} 
else 
{ 
Client::sendMessage(%client,0,"Deploy position out of range"); } 
} 
else 
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
return false; 
} 


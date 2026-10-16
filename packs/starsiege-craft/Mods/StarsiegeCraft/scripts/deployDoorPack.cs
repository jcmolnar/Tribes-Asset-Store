$TeamItemMax[ForceFieldPack] = 14; 
$TeamItemMax[LargeForceFieldPack] = 2; 
$InvList[DoorPack] = 1; 
$RemoteInvList[DoorPack] = 1; 

$CanAlwaysTeamDestroy[DoorPack] = 1;


 //-=-=-=-=-=-=-=- Initialize =-=-=-=-=-=-=-

function deployDoorPack::Initialize()
{
	$TeamItemCount[0 @ DoorPack] = 0; 
	$TeamItemCount[1 @ DoorPack] = 0; 
	$TeamItemCount[2 @ DoorPack] = 0; 
	$TeamItemCount[3 @ DoorPack] = 0; 
	$TeamItemCount[4 @ DoorPack] = 0; 
	$TeamItemCount[5 @ DoorPack] = 0; 
	$TeamItemCount[6 @ DoorPack] = 0; 
	$TeamItemCount[7 @ DoorPack] = 0; 


ItemImageData DoorPackImage 
{ 
	shapeFile = "MortarPack"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData DoorPack 
{ 
	description = "Light Barrier"; 
	shapeFile = "AmmoPack"; 
	className = "Backpack"; 
	heading = $InvHead[ihDOb]; 
	imageType = DoorPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 1200; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function DoorPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item);
} 

function DoorPack::onDeploy(%player,%item,%pos) 
{ 
	if (DoorPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item);  
} 

function DoorPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]) 
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }

	if (!GameBase::getLOSInfo(%player,3)) 
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }

	// %obj = getObjectType($los::object); 
	// %set = newObject("set",SimSet); 
	// %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); 
	// %num = CountObjects(%set,"DeployableForceDoor",%num); 
	// deleteObject(%set); 

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return false; }

	 //
	 // Passed validation, create the object
	 //
	%rot = GameBase::getRotation(%player); 
	%objForceField = newObject("","StaticShape",DoorPack,true); 
	addToSet("MissionCleanup", %objForceField); 
	GameBase::setTeam(%objDoorPack,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objDoorPack,$los::position); 
	GameBase::setRotation(%objDoorPack,%rot); 
	Gamebase::setMapName(%objDoorPack,"Force Door"); 
	Client::sendMessage(%client,0,"Force Door Deployed"); 
	GameBase::startFadeIn(%objDoorPack); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(DoorPackOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "DoorPack"]++; 
        reportDeploy(%objDoorPack, %client);
	return true; 
} 

 //-=-=-=-=-=-=-=- Objects =-=-=-=-=-=-=-

StaticShapeData DeployableDoorPack 
{ 
	shapeFile = "forcefield_5x5"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 4.50; 
	visibleToSensor = true; 
	isTranslucent = true; 
	description = "Light Barrier"; 
}; 

function DeployableDoorPack::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "DoorPack"]--; 
} 

StaticShapeData DoorPack 
{ 
	shapeFile = "forcefield"; 
	debrisId = defaultDebrisLarge; 
	maxDamage = 8.00; 
	visibleToSensor = true; 
	isTranslucent = true; 
	description = "Light Barrier"; 
}; 

function DoorPack::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldPack"]--; 
} 

function CreateDoorSimSet()
{
%teleset = nameToID("MissionCleanup/Doors");
if(%teleset == -1)
{
newObject("Doors",SimSet);
addToSet("MissionCleanup","Doors");
}
}
function DoorPack::deployShape(%player,%name,%shape,%item)
instant Moveable "DoorFourRight1" {
	dataBlock = "DoorFourRight";
	name = "Base Door";
	position = GameBase::getPosition(%player);
	rotation = GameBase::getRotation(%player);
	destroyable = "True";
	deleteOnDestroy = "False";
	closeTime = "986.614";
	status = "close";
	center = "1";
	fadeTime = "444.396";
	};
instant Moveable "DoorFourLeft1" {
	dataBlock = "DoorFourLeft";
	name = "Base Door";
	position = GameBase::getPosition(%player);
	rotation = GameBase::getRotation(%player);
	destroyable = "True";
	deleteOnDestroy = "False";
	closeTime = "986.742";
	Status = "close";
	center = "1";
	fadeTime = "444.396";
	};




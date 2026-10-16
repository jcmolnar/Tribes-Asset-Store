$InvList[FighterPack] = 1;
$MobileInvList[FighterPack] = 1;
$RemoteInvList[FighterPack] = 1;

$InvList[TransportPack] = 1;
$MobileInvList[TransportPack] = 1;
$RemoteInvList[TransportPack] = 1;

 //-=-=-=- Interceptor

ItemImageData FighterPackImage 
{	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData FighterPack 
{	description = "Fighter Vehicle Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = $InvHead[ihDOb]; 
	imageType = FighterPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function FighterPack::onUse(%player,%item) 
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function FighterPack::onDeploy(%player,%item,%pos) 
{	if (FighterPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function FighterPack::deployShape(%player,%item) 
{	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "InterceptorVehicle"] >= $TeamItemMax[InterceptorVehicle]) 
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }

	if (!GameBase::getLOSInfo(%player,3)) 
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }

	%obj = getObjectType($los::object); 
	if (%obj != "SimTerrain" && %obj != "InteriorShape") 
	{ Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); return false; }

	//%set = newObject("set",SimSet); deleteObject(%set); 
	if (Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return false; }

	if (!checkDeployArea(%client,$los::position)) 
		return false;

	 //
	 // Passed validation, create the object
	 //
	%rot = GameBase::getRotation(%player); 
	%objVehicle = newObject("",flier,Interceptor,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Client::sendMessage(%client,0,"Piloting Interceptor"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "InterceptorVehicle"]++; 
	echo("MSG: ",%client," deployed a Fighter Vehicle Pack");
	return true; 
} 

 //-=-=-=- HPC

ItemImageData TransportPackImage 
{	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData TransportPack 
{	description = "Transport Vehicle Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = $InvHead[ihDOb]; 
	imageType = TransportPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 1600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function TransportPack::onUse(%player,%item) 
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else
		Player::deployItem(%player,%item); 
} 

function TransportPack::onDeploy(%player,%item,%pos) 
{	if (TransportPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item);
} 

function TransportPack::deployShape(%player,%item) 
{	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"] >= $TeamItemMax[HAPCVehicle]) 
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }

	if (!GameBase::getLOSInfo(%player,3)) 
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }

	%obj = getObjectType($los::object); 
	if (%obj != "SimTerrain" && %obj != "InteriorShape") 
	{ Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); return false; }

	//%set = newObject("set",SimSet); 
	//deleteObject(%set); 

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return false; }

	if (!checkDeployArea(%client,$los::position)) 
		return false;

	 //
	 // Passed validation, create the object
	 //
	%rot = GameBase::getRotation(%player); 
	%objVehicle = newObject("",flier,HAPC,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Gamebase::setMapName(%objVehicle,"HPC Pack"); 
	Client::sendMessage(%client,0,"Deployed HPC"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"]++; 
	echo("MSG: ",%client," deployed a Transport Vehicle Pack");
	return true; 
}

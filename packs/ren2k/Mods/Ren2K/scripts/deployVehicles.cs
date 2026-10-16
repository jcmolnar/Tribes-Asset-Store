$InvList[MechPack] = 1;
$RemoteInvList[MechPack] = 1;
$InvList[DetPack] = 1;
$RemoteInvList[DetPack] = 1;

 //-=-=-=- Interceptor

ItemImageData MechPackImage 
{ 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData MechPack 
{ 
	description = "Interceptor Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = $InvHead[ihDOb]; 
	imageType = MechPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function MechPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function MechPack::onDeploy(%player,%item,%pos) 
{ 
	if (MechPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function MechPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
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
	reportDeploy(%objVehicle, %client);
	return true; 
} 

 //-=-=-=- HPC

ItemImageData DetPackImage 
{ 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData DetPack 
{ 
	description = "HPC Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = $InvHead[ihDOb]; 
	imageType = DetPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 1600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function DetPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else
		Player::deployItem(%player,%item); 
} 

function DetPack::onDeploy(%player,%item,%pos) 
{ 
	if (DetPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item);
} 

function DetPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
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
	reportDeploy(%objVehicle, %client);
	return true; 
}

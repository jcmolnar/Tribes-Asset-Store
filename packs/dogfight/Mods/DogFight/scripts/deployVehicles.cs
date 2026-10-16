$InvList[FighterPack] = 1;
$RemoteInvList[FighterPack] = 1;

$InvList[FighterPack2] = 1;
$RemoteInvList[FighterPack2] = 1;

$InvList[FighterPack3] = 1;
$RemoteInvList[FighterPack3] = 1;

$InvList[FighterPack4] = 1;
$RemoteInvList[FighterPack4] = 1;

$InvList[FighterPack5] = 1;
$RemoteInvList[FighterPack5] = 1;

$InvList[FighterPack6] = 1;
$RemoteInvList[FighterPack6] = 1;

$InvList[FighterPack7] = 1;
$RemoteInvList[FighterPack7] = 1;

$InvList[FighterPack8] = 1;
$RemoteInvList[FighterPack8] = 1;

$InvList[FighterPack9] = 1;
$RemoteInvList[FighterPack9] = 1;

ItemImageData FighterPackImage 
{	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData FighterPack 
{	description = "Deployable F-17 Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = dDeployables; 
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
	if($TeamItemCount[GameBase::getTeam(%player) @ "ScoutVehicle"] >= $TeamItemMax[ScoutVehicle]) 
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
	%objVehicle = newObject("",flier,Scout,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Client::sendMessage(%client,0,"Piloting F-17"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "ScoutVehicle"]++; 
	reportDeploy(%objVehicle, %client);
	return true; 
} 


ItemImageData FighterPack2Image 
{	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData FighterPack2 
{	description = "Deployable F-16 Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = dDeployables; 
	imageType = FighterPack2Image; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function FighterPack2::onUse(%player,%item) 
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function FighterPack2::onDeploy(%player,%item,%pos) 
{	if (FighterPack2::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function FighterPack2::deployShape(%player,%item) 
{	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "Scout2Vehicle"] >= $TeamItemMax[Scout2Vehicle]) 
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
	%objVehicle = newObject("",flier,Scout2,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Client::sendMessage(%client,0,"Piloting F-16"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "Scout2Vehicle"]++; 
	reportDeploy(%objVehicle, %client);
	return true; 
} 
ItemImageData FighterPack3Image 
{	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData FighterPack3 
{	description = "Deployable F-15 Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = dDeployables; 
	imageType = FighterPack3Image; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function FighterPack3::onUse(%player,%item) 
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function FighterPack3::onDeploy(%player,%item,%pos) 
{	if (FighterPack3::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function FighterPack3::deployShape(%player,%item) 
{	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "Scout3Vehicle"] >= $TeamItemMax[Scout3Vehicle]) 
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
	%objVehicle = newObject("",flier,Scout3,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Client::sendMessage(%client,0,"Piloting F-15"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "Scout3Vehicle"]++; 
	reportDeploy(%objVehicle, %client);
	return true; 
} 
ItemImageData FighterPack4Image 
{	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData FighterPack4 
{	description = "Deployable F-14 Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = dDeployables; 
	imageType = FighterPack4Image; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function FighterPack4::onUse(%player,%item) 
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function FighterPack4::onDeploy(%player,%item,%pos) 
{	if (FighterPack4::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function FighterPack4::deployShape(%player,%item) 
{	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "Scout4Vehicle"] >= $TeamItemMax[Scout4Vehicle]) 
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
	%objVehicle = newObject("",flier,Scout4,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Client::sendMessage(%client,0,"Piloting F-17"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "ScoutVehicle"]++; 
	reportDeploy(%objVehicle, %client);
	return true; 
}
ItemImageData FighterPack5Image 
{	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData FighterPack5 
{	description = "Deployable B-12 Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = dDeployables; 
	imageType = FighterPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function FighterPack5::onUse(%player,%item) 
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function FighterPack5::onDeploy(%player,%item,%pos) 
{	if (FighterPack5::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function FighterPack5::deployShape(%player,%item) 
{	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "SkimmerVehicle"] >= $TeamItemMax[SkimmerVehicle]) 
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
	%objVehicle = newObject("",flier,Skimmer,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Client::sendMessage(%client,0,"Piloting B-12"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "SkimmerVehicle"]++; 
	reportDeploy(%objVehicle, %client);
	return true; 
}
 
ItemImageData FighterPack6Image 
{	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData FighterPack6 
{	description = "Deployable F-18 Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = dDeployables; 
	imageType = FighterPack6Image; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function FighterPack6::onUse(%player,%item) 
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function FighterPack6::onDeploy(%player,%item,%pos) 
{	if (FighterPack6::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function FighterPack6::deployShape(%player,%item) 
{	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "Scout5Vehicle"] >= $TeamItemMax[Scout5Vehicle]) 
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
	%objVehicle = newObject("",flier,Scout5,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Client::sendMessage(%client,0,"Piloting F-18"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "Scout5Vehicle"]++; 
	reportDeploy(%objVehicle, %client);
	return true; 
} 

ItemImageData FighterPack7Image 
{	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData FighterPack7
{	description = "Deployable F-19 Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = dDeployables; 
	imageType = FighterPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function FighterPack7::onUse(%player,%item) 
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function FighterPack7::onDeploy(%player,%item,%pos) 
{	if (FighterPack7::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function FighterPack7::deployShape(%player,%item) 
{	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "Scout6Vehicle"] >= $TeamItemMax[Scout6Vehicle]) 
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
	%objVehicle = newObject("",flier,Scout6,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Client::sendMessage(%client,0,"Piloting F-19"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "Scout6Vehicle"]++; 
	reportDeploy(%objVehicle, %client);
	return true; 
} 

ItemImageData FighterPack8Image 
{	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData FighterPack8
{	description = "Deployable Devastator Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = dDeployables; 
	imageType = FighterPack8Image; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function FighterPack8::onUse(%player,%item) 
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function FighterPack8::onDeploy(%player,%item,%pos) 
{	if (FighterPack8::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function FighterPack8::deployShape(%player,%item) 
{	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "Scout7Vehicle"] >= $TeamItemMax[Scout7Vehicle]) 
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
	%objVehicle = newObject("",flier,Scout7,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Client::sendMessage(%client,0,"Piloting Devestator"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "Scout7Vehicle"]++; 
	reportDeploy(%objVehicle, %client);
	return true; 
} 
ItemImageData FighterPack9Image 
{	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData FighterPack9
{	description = "Deployable Scout Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = dDeployables; 
	imageType = FighterPack9Image; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function FighterPack9::onUse(%player,%item) 
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function FighterPack9::onDeploy(%player,%item,%pos) 
{	if (FighterPack9::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function FighterPack9::deployShape(%player,%item) 
{	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "Scout8Vehicle"] >= $TeamItemMax[Scout8Vehicle]) 
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
	%objVehicle = newObject("",flier,Scout8,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Client::sendMessage(%client,0,"Piloting Scout"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "Scout8Vehicle"]++; 
	reportDeploy(%objVehicle, %client);
	return true; 
}
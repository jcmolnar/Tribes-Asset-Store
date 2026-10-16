//DEPLOYABLE VEHICLES PART 2 <[DC]>Paladin for War40k MOD

$InvList[BikePack] = 1;
$RemoteInvList[BikePack] = 1;
$InvList[DogPack] = 1;
$RemoteInvList[DogPack] = 1;
$InvList[VyPack] = 1;
$RemoteInvList[VyPack] = 1;
$InvList[TempestPack] = 1;
$RemoteInvList[TempestPack] = 1;
$InvList[SpeedPack] = 1;
$RemoteInvList[SpeedPack] = 1;
$InvList[SpeederPack] = 1;
$RemoteInvList[SpeederPack] = 1;
$InvList[SpeedoPack] = 1;
$RemoteInvList[SpeedoPack] = 1;
 //-=-=-=- JetBike Pack

ItemImageData BikePackImage 
{ 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData BikePack 
{ 
	description = "Jetbike Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = $InvHead[ihVpa]; 
	imageType = BikePackImage; 
	shadowDetailMask = 4; 
	mass = 0.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function BikePack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function BikePack::onDeploy(%player,%item,%pos) 
{ 
	if (BikePack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function BikePack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
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
	Client::sendMessage(%client,0,"Piloting Jetbike"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "ScoutVehicle"]++; 
	reportDeploy(%objVehicle, %client);
	return true; 
} 
///////////////////////////------------------------------------------
 //-=-=-=- Dogfighter Pack

ItemImageData DogPackImage 
{ 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData DogPack 
{ 
	description = "Vyper Var.3 Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = $InvHead[ihVpa]; 
	imageType = DogPackImage; 
	shadowDetailMask = 4; 
	mass = 0.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function DogPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function DogPack::onDeploy(%player,%item,%pos) 
{ 
	if (DogPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function DogPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "DogFighterVehicle"] >= $TeamItemMax[DogFighterVehicle]) 
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
	%objVehicle = newObject("",flier,DogFighter,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Client::sendMessage(%client,0,"Piloting Vyper"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "DogFighterVehicle"]++; 
	reportDeploy(%objVehicle, %client);
	return true; 
} 
////////////////////////////////------------------------------------
ItemImageData VyPackImage 
{ 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData VyPack 
{ 
	description = "Vyper Var.2 Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = $InvHead[ihVpa]; 
	imageType = VyPackImage; 
	shadowDetailMask = 4; 
	mass = 0.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function VyPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function VyPack::onDeploy(%player,%item,%pos) 
{ 
	if (VyPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function VyPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "WraithVehicle"] >= $TeamItemMax[WraithVehicle]) 
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
	%objVehicle = newObject("",flier,Wraith,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Client::sendMessage(%client,0,"Piloting Vyper"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "WraithVehicle"]++; 
	reportDeploy(%objVehicle, %client);
	return true; 
} 
////////////////////////////////------------------------------------
ItemImageData TempestPackImage 
{ 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData TempestPack 
{ 
	description = "Tempest Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = $InvHead[ihVpa]; 
	imageType = TempestPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 2600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function TempestPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function TempestPack::onDeploy(%player,%item,%pos) 
{ 
	if (TempestPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function TempestPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "TempestVehicle"] >= $TeamItemMax[TempestVehicle]) 
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
	%objVehicle = newObject("",flier,Tempest,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Client::sendMessage(%client,0,"Piloting Tempest"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "TempestVehicle"]++; 
	reportDeploy(%objVehicle, %client);
	return true; 
} 

////////////////////////////////------------------------------------
ItemImageData SpeedPackImage 
{ 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData SpeedPack 
{ 
	description = "Landspeeder 1 Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = $InvHead[ihVpa]; 
	imageType = SpeedPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 900; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function SpeedPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function SpeedPack::onDeploy(%player,%item,%pos) 
{ 
	if (SpeedPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function SpeedPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "LAPCVehicle"] >= $TeamItemMax[LAPCVehicle]) 
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
	%objVehicle = newObject("",flier,LAPC,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Client::sendMessage(%client,0,"Piloting Landspeeder"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "LAPCVehicle"]++; 
	reportDeploy(%objVehicle, %client);
	return true; 
} 

////////////////////////////////------------------------------------
ItemImageData SpeederPackImage 
{ 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData SpeederPack 
{ 
	description = "Landspeeder 2 Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = $InvHead[ihVpa]; 
	imageType = SpeederPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 900; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function SpeederPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function SpeederPack::onDeploy(%player,%item,%pos) 
{ 
	if (SpeederPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function SpeederPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "QuickLPCVehicle"] >= $TeamItemMax[QuickLPCVehicle]) 
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
	%objVehicle = newObject("",flier,QuickLPC,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Client::sendMessage(%client,0,"Piloting Landspeeder"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "QuickLPCVehicle"]++; 
	reportDeploy(%objVehicle, %client);
	return true; 
} 

////////////////////////////////------------------------------------
ItemImageData SpeedoPackImage 
{ 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData SpeedoPack 
{ 
	description = "Landspeeder 3 Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = $InvHead[ihVpa]; 
	imageType = SpeedoPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 900; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function SpeedoPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function SpeedoPack::onDeploy(%player,%item,%pos) 
{ 
	if (SpeedoPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function SpeedoPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "SpeederVehicle"] >= $TeamItemMax[SpeederVehicle]) 
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
	%objVehicle = newObject("",flier,Speeder,true); 
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Client::sendMessage(%client,0,"Piloting Landspeeder"); 
	GameBase::startFadeIn(%objVehicle); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "SpeederVehicle"]++; 
	reportDeploy(%objVehicle, %client);
	return true; 
} 
ItemImageData CameraPackImage 
	{ 
	shapeFile = "camera"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, -0.06 }; 
	mountRotation = { 0, 0, 0 }; 
	firstPerson = false; 
	}; 
//======================
// Turrets
//======================
ItemImageData AntiAirPackImage 
	{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, -0.06 }; 
	mountRotation = { 0, 0, 0 }; 
	firstPerson = false; 
	}; 

ItemData AntiAirPack 
	{ 
	description = "Scud Missile Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = AntiAirPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function AntiAirPack::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 350)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 350)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}

function AntiAirPack::onDeploy(%player,%item,%pos) 
	{ 
	if (AntiAirPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function AntiAirPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	%prot = GameBase::getRotation(%player); 
	%zRot = getWord(%prot,2); 
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot; 
	else 
	{ 
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot; 
	else 
	%rot = Vector::getRotation($los::normal); 
	} 
	%camera = newObject("","Turret",AntiAirTurret,true); 
	addToSet("MissionCleanup", %camera); 
	GameBase::setTeam(%camera,GameBase::getTeam(%player)); 
	GameBase::setRotation(%camera,%rot); 
	GameBase::setPosition(%camera,$los::position); 
	Gamebase::setMapName(%camera,"Scud Missile Turret "@ Client::getName(%client));
	Client::setOwnedObject(%client, %camera);
	Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Scud Missile Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%camera) @ "AntiAirPack"]++;
	echo("MSG: ",%client," deployed a Scud Missile Turret");  
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function AntiAirTurret::verifyTarget(%this,%target) 
	{ 
	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) 
	return "True"; 
	else 
	return "False"; 
	} 

function AntiAirTurret::onAdd(%this) 
	{ 
	schedule("AntiAirTurret::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,7); 
	%this.shieldStrength = 0.005; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Scud Turret"); 
	} 

function AntiAirTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function AntiAirTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function AntiAirTurret::onDestroyed(%this) 
	{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "AntiAirPack"]--; 
	} 

function AntiAirTurret::onPower(%this,%power,%generator) {} 

function AntiAirTurret::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,7); 
	GameBase::setActive(%this,true); 
	} 
//======================
ItemImageData DeployableElfTurretImage 
	{ 
	shapeFile = "camera"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.1 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData DeployableElfTurret 
	{ 
	description = "Elf Turret"; 
	shapeFile = "camera"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = DeployableElfTurretImage; 
 	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function DeployableElfTurret::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 0)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 0)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}

function DeployableElfTurret::onDeploy(%player,%item,%pos) 
	{ 
	if (DeployableElfTurret::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function DeployableElfTurret::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	%prot = GameBase::getRotation(%player); 
	%zRot = getWord(%prot,2); 
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot; 
	else 
	{ 
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot; 
	else 
	%rot = Vector::getRotation($los::normal); 
	} 
	%turret = newObject("","Turret",DeployableElf,true); 
	addToSet("MissionCleanup", %turret); 
	GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
	GameBase::setPosition(%turret,$los::position); 
	GameBase::setRotation(%turret,%rot); 
	Gamebase::setMapName(%turret,"Elf Turret "@ Client::getName(%client)); 
	Client::setOwnedObject(%client, %turret);
	Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Elf Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "DeployableElfTurret"]++;
	echo("MSG: ",%client," deployed a Elf Turret");  
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function DeployableElf::onAdd(%this) 
	{ 
	schedule("DeployableElf::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,5); 
	%this.shieldStrength = 0.0275; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Elf Turret"); 
	} 

function DeployableElf::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableElf::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableElf::onDestroyed(%this) 
	{ 
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this); 
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableElfTurretTurret"]--; 
	} 

function DeployableElf::onPower(%this,%power,%generator) {} 

function DeployableElf::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,10); 
	GameBase::setActive(%this,true); 
	} 
//======================
ItemImageData IndoorPackImage 
	{ 
	shapeFile = "indoorgun"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, -0.06 }; 
	mountRotation = { 0, 0, 0 }; 
	firstPerson = false; 
	}; 

ItemData IndoorPack 
	{ 
	description = "Indoor Turret"; 
	shapeFile = "indoorgun"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = IndoorPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function IndoorPack::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 110)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 110)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}

function IndoorPack::onDeploy(%player,%item,%pos) 
	{ 
	if (IndoorPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function IndoorPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	%prot = GameBase::getRotation(%player); 
	%zRot = getWord(%prot,2); 
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot; 
	else 
	{ 
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot; 
	else 
	%rot = Vector::getRotation($los::normal); 
	} 
	%camera = newObject("","Turret",DeployableIndoor,true); 
	addToSet("MissionCleanup", %camera); 
	GameBase::setTeam(%camera,GameBase::getTeam(%player)); 
	GameBase::setRotation(%camera,%rot); 
	GameBase::setPosition(%camera,$los::position); 
	Gamebase::setMapName(%camera,"Indoor Turret "@ Client::getName(%client));
	Client::setOwnedObject(%client, %camera);
	Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Indoor Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%camera) @ "IndoorPack"]++; 
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function DeployableIndoor::onAdd(%this) 
	{ 
	schedule("DeployableIndoor::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,6); 
	%this.shieldStrength = 0.030; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Remote Indoor Turret"); 
	} 

function DeployableIndoor::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableIndoor::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableIndoor::onDestroyed(%this) 
	{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "IndoorPack"]--; 
	} 

function DeployableIndoor::onPower(%this,%power,%generator) {} 

function DeployableIndoor::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
	}
//======================
ItemImageData TurretPackImage 
	{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.1 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData TurretPack 
	{ 
	description = "Ion Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = TurretPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function TurretPack::onUse(%player,%item)
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 200)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 200)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}

function TurretPack::onDeploy(%player,%item,%pos)
	{
	if (TurretPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item);
	}

function TurretPack::deployShape(%player,%item)
	{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
	if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object);
	if(%obj != "Player")
	{
	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot;
	else 
	{
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot;
	else 
	%rot = Vector::getRotation($los::normal);
	}
	%turret = newObject("","Turret",DeployableTurret,true); 
	addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setRotation(%turret,%rot);
	GameBase::setPosition(%turret,$los::position);
	Gamebase::setMapName(%turret,"Ion Turret " @ Client::getName(%client)); 
      Client::setOwnedObject(%client, %turret);
      Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Ion Turret deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%turret) @ "TurretPack"]++;
	echo("MSG: ",%client," deployed an Ion Turret"); 
	return true;
	}
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
	else 
	Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
	}

function DeployableTurret::onAdd(%this) 
	{ 
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,5); 
	%this.shieldStrength = 0.005; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Remote Turret"); 
	} 

function DeployableTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableTurret::onDestroyed(%this) 
	{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--; 
	} 

function DeployableTurret::onPower(%this,%power,%generator) {} 

function DeployableTurret::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
	}
//======================
ItemImageData LaserPackImage
	{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	};

ItemData LaserPack
	{
	description = "Laser Turret";
	shapeFile = "camera";
	className = "Backpack";
      heading = "gDeployable Turrets";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function LaserPack::onUse(%player,%item)
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 180)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 180)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}

function LaserPack::onDeploy(%player,%item,%pos)
	{
	if (LaserPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item);
	}

function LaserPack::deployShape(%player,%item)
	{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
	if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object);
	if (%obj != "Player")
	{
	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot;
	else 
	{
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot;
	else 
	%rot = Vector::getRotation($los::normal);
	}
	%camera = newObject("","Turret",DeployableLaser,true);
	addToSet("MissionCleanup", %camera);
	GameBase::setTeam(%camera,GameBase::getTeam(%player));
	GameBase::setRotation(%camera,%rot);
	GameBase::setPosition(%camera,$los::position);
	Gamebase::setMapName(%camera,"Laser Turret "@ Client::getName(%client));
      Client::setOwnedObject(%client, %camera);
      Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Laser Turret deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%camera) @ "LaserPack"]++;
	echo("MSG: ",%client," deployed a Laser Turret"); 
	return true;
	}
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
	else 
	Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
	}

function DeployableLaser::onAdd(%this)
	{
	schedule("DeployableLaser::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Remote Laser Turret");
	}

function DeployableLaser::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }

function DeployableLaser::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }

function DeployableLaser::onDestroyed(%this)
	{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LaserPack"]--;
	}

function DeployableLaser::onPower(%this,%power,%generator) {}

function DeployableLaser::onEnabled(%this) 
	{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
	}
//======================
ItemImageData RocketPackImage 
	{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.1 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 3.0; 
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
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function RocketPack::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 300)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 300)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}

function RocketPack::onDeploy(%player,%item,%pos) 
	{ 
	if (RocketPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function RocketPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot;
	else 
	{
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot;
	else 
	%rot = Vector::getRotation($los::normal);
	}
	%turret = newObject("","Turret",DeployableRocket,true); 
	addToSet("MissionCleanup", %turret); 
	GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
	GameBase::setPosition(%turret,$los::position); 
	GameBase::setRotation(%turret,%rot); 
	Gamebase::setMapName(%turret,"Missile Turret " @ Client::getName(%client));
	Client::setOwnedObject(%client, %turret);
	Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Missile Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "RocketPack"]++;
	echo("MSG: ",%client," deployed a Rocket Turret");  
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function DeployableRocket::verifyTarget(%this,%target) 
	{ 
	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) 
	return "True"; 
	else 
	return "False"; 
	} 

function DeployableRocket::onAdd(%this) 
	{ 
	schedule("DeployableRocket::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,5); 
	%this.shieldStrength = 0.02; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Remote Missile Turret"); 
	} 

function DeployableRocket::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableRocket::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableRocket::onDestroyed(%this) 
	{ 
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this);  
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "RocketPack"]--; 
	} 

function DeployableRocket::onPower(%this,%power,%generator) {} 

function DeployableRocket::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
	}
//======================
ItemImageData TargetPackImage 
	{ 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, -0.06 }; 
	mountRotation = { 0, 0, 0 }; 
	firstPerson = false; 
	}; 

ItemData TargetPack 
	{ 
	description = "Mortar Turret"; 
	shapeFile = "mortar_turret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = TargetPackImage; 
	shadowDetailMask = 4; 
	mass = 3.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function TargetPack::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 200)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 200)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}
 
function TargetPack::onMount(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	Bottomprint(%client, "The Mortar Turret must be controlled manually to fire."); 
	} 

function TargetPack::onDeploy(%player,%item,%pos) 
	{ 
	if (TargetPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function TargetPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%turret = newObject("","Turret",DeployableMortar,true); 
	addToSet("MissionCleanup", %turret); 
	GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
	GameBase::setPosition(%turret,$los::position); 
	GameBase::setRotation(%turret,%rot); 
	Gamebase::setMapName(%turret,"Mortar Turret " @ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Remote Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "TargetPack"]++; 
	echo("MSG: ",%client," deployed a Mortar Turret"); 
	Client::setOwnedObject(%client, %turret); 
	Client::setOwnedObject(%client, %player); 
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function DeployableMortar::onAdd(%this) 
	{ 
	schedule("DeployableMortar::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,7); 
	%this.shieldStrength = 0.005; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Mortar Turret"); 
	} 

function DeployableMortar::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableMortar::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableMortar::onDestroyed(%this) 
	{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "TargetPack"]--; 
	} 

function DeployableMortar::onPower(%this,%power,%generator) {} 

function DeployableMortar::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,7); 
	GameBase::setActive(%this,true); 
	}
//======================
ItemImageData LaserTurretImage 
	{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.1 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData LaserTurret 
	{ 
	description = "Plasma Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = LaserTurretImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function LaserTurret::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 200)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 200)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}

function LaserTurret::onDeploy(%player,%item,%pos)
	{ 
	if (LaserTurret::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function LaserTurret::deployShape(%player,%item) 
	{
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%turret = newObject("","Turret",DeployablePlasma,true); 
	addToSet("MissionCleanup", %turret); 
	GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
	GameBase::setPosition(%turret,$los::position); 
	GameBase::setRotation(%turret,%rot); 
	Gamebase::setMapName(%turret,"Plasma Turret " @ Client::getName(%client)); 
	Client::setOwnedObject(%client, %turret);
	Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Plasma Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "LaserTurret"]++;
	echo("MSG: ",%client," deployed a Plasma Turret");  
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function DeployablePlasma::onAdd(%this) 
	{ 
	schedule("DeployablePlasma::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,5); 
	%this.shieldStrength = 0.010; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Plasma Turret"); 
	} 

function DeployablePlasma::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployablePlasma::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployablePlasma::onDestroyed(%this) 
	{ 
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this); 
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "LaserTurret"]--; 
	} 

function DeployablePlasma::onPower(%this,%power,%generator) {} 

function DeployablePlasma::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
	}
//======================
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
	imageType = RailTurretImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function RailTurret::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function RailTurret::onDeploy(%player,%item,%pos) 
	{ 
	if (RailTurret::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function RailTurret::onMount(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	Bottomprint(%client, "The Rail Turret must be controlled manually to fire."); 
	} 

function RailTurret::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%turret = newObject("","Turret",DeployableRail,true); 
	addToSet("MissionCleanup", %turret); 
	GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
	GameBase::setPosition(%turret,$los::position); 
	GameBase::setRotation(%turret,%rot); 
	Gamebase::setMapName(%turret,"Rail Turret " @ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Rail Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "RailTurret"]++;
	echo("MSG: ",%client," deployed a Rail Turret");  
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function DeployableRail::onAdd(%this) 
	{ 
	schedule("DeployableRail::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,20); 
	%this.shieldStrength = 0.005; 
	if (GameBase::getMapName(%this) == "")  
	GameBase::setMapName (%this, "Rail Turret"); 
	} 

function DeployableRail::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableRail::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableRail::onDestroyed(%this) 
	{ 
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this); 
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "RailTurret"]--; 
	} 

function DeployableRail::onPower(%this,%power,%generator) {} 

function DeployableRail::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,20); 
	GameBase::setActive(%this,true); 
	} 
//======================
ItemImageData ShockPackImage 
	{ 
	shapeFile = "indoorgun"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, -0.06 }; 
	mountRotation = { 0, 0, 0 }; 
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
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function ShockPack::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 100)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 100)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}

function ShockPack::onDeploy(%player,%item,%pos) 
	{ 
	if (ShockPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function ShockPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	%prot = GameBase::getRotation(%player); 
	%zRot = getWord(%prot,2); 
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot; 
	else 
	{ 
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot; 
	else 
	%rot = Vector::getRotation($los::normal); 
	} 
	%camera = newObject("","Turret",DeployableShock,true); 
	addToSet("MissionCleanup", %camera); 
	GameBase::setTeam(%camera,GameBase::getTeam(%player)); 
	GameBase::setRotation(%camera,%rot); 
	GameBase::setPosition(%camera,$los::position); 
	Gamebase::setMapName(%camera,"Shock Turret "@ Client::getName(%client)); 
	Client::setOwnedObject(%client, %turret);
	Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Shock Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%camera) @ "ShockPack"]++; 
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 


function DeployableShock::onAdd(%this) 
	{ 
	schedule("DeployableShock::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,6); 
	%this.shieldStrength = 0.010; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Remote Shock Turret"); 
	} 

function DeployableShock::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableShock::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

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
//======================
ItemImageData VulcanTurretImage 
	{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.1 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData VulcanTurret 
	{ 
	description = "Vulcan Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = VulcanTurretImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function VulcanTurret::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function VulcanTurret::onDeploy(%player,%item,%pos) 
	{ 
	if (VulcanTurret::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function VulcanTurret::onMount(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	Bottomprint(%client, "The Vulcan Turret must be controlled manually to fire."); 
	}
 
function VulcanTurret::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%turret = newObject("","Turret",DeployableVulcan,true); 
	addToSet("MissionCleanup", %turret); 
	GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
	GameBase::setPosition(%turret,$los::position); 
	GameBase::setRotation(%turret,%rot); 
	Gamebase::setMapName(%turret,"Vulcan Turret " @ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Vulcan Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "VulcanTurret"]++;
	echo("MSG: ",%client," deployed a Vulcan Turret");  
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function DeployableVulcan::onAdd(%this) 
	{ 
	schedule("DeployableVulcan::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,10); 
	%this.shieldStrength = 0.005; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Vulcan Turret"); 
	} 
 
function DeployableVulcan::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableVulcan::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableVulcan::onDestroyed(%this) 
	{ 
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this); 
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "VulcanTurret"]--; 
	} 

function DeployableVulcan::onPower(%this,%power,%generator) {} 

function DeployableVulcan::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,100); 
	GameBase::setActive(%this,true); 
	} 
//======================
TurretData RealObeliskOfLight
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = ObeliskBeam;
	maxDamage = 5;
	maxEnergy = 80;
	minGunEnergy = 80;
	maxGunEnergy = 80;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 200; //100;
	visibleToSensor = false;
	shadowDetailMask = 4;
	supressable = true;
	dopplerVelocity = 0;
	castLOS = false;
	supression = false;
	mapFilter = 2;
//	mapIcon = "M_turret";
	debrisId = flashDebrisLarge;
	shieldShapeName = "shield";
	fireSound = SoundLaserHit;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpLarge;
	description = "";
	damageSkinData = "objectDamageSkins";
};

function RealObeliskOfLight::onAdd(%this)
{
	schedule("RealObeliskOfLight::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.012;
	playSound(SoundBuzz,GameBase::getPosition(%this));
}

function RealObeliskOfLight::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function RealObeliskOfLight::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function RealObeliskOfLight::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
}

// Override base class just in case.
function RealObeliskOfLight::onPower(%this,%power,%generator) {}
function RealObeliskOfLight::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}
//======================

//======================
function kickback(%object, %kickback) // Kickback
{
	%rot = GameBase::getRotation(%object); 
	%kick = Vector::getFromRot(%rot,%kickback,0);
	Player::applyImpulse(%object,%kick);
}

function sin(%theta) // Sine & Cosine functions... useful for 3D Manipulation
{ 
	%sin = (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
	return %sin;
}

function cos(%theta) 
{
	%cos = (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
	return %cos;
}

function newVector(%vec, %scalar) // ?  (One of Valya's functions)
{	
	%nVec  = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %nVec;
}

function GetLOSOffset(%player,%offset)
{	
	%Vector=GameBase::getMuzzleTransform(%Player);
	%pos=Gamebase::GetPosition(%player);
	%rot=GameBase::GetRotation(%player);
	%rot2=GetWord(%Vector,6)@" "@GetWord(%Vector,7)@" "@GetWord(%Vector,8);

	%X1=Getword(%vector,1);
	%Y1=Getword(%vector,2);
	%Z1=Getword(%vector,3);
	
	%X2=Getword(%vector,6);
	%Y2=Getword(%vector,7);
	%Z2=Getword(%vector,8);
	
	%zo1=SIN(%YRot) * %offset;
	%zo2=COS(%XRot) * %offset;
	%l2=COS(%YRot) * %offset;

	%p1=Vector::getFromRot(%rot,%l2,%zo);
	%NewPos=Vector::Add(%Pos,%p1);
	return(%NewPos);
}
//=================================================================================================================
//===================================================================================== Inventory Station =========
//=================================================================================================================

ItemImageData DeployableInvPackImage 
	{ 
	shapeFile = "invent_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.3 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData DeployableInvPack 
	{ 
	description = "Inventory Station"; 
	shapeFile = "invent_remote"; 
	className = "Backpack"; 
	heading = "eDeployable Stations"; 
	shadowDetailMask = 4 ; 
	imageType = DeployableInvPackImage; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function DeployableInvPack::onUse(%player,%item) 
	{	
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	}
 
function DeployableInvPack::onDeploy(%player,%item,%pos) 
	{ 
	if (DeployableInvPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	}
 
function DeployableInvPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7)  
	{ 
	%inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true); 
	addToSet("MissionCleanup", %inv); 
	%rot = GameBase::getRotation(%player); 
	GameBase::setTeam(%inv,GameBase::getTeam(%player)); 
	GameBase::setPosition(%inv,$los::position); 
	GameBase::setRotation(%inv,%rot); 
	Gamebase::setMapName(%inv,%name); 
	Client::sendMessage(%client,0,"Inventory Station deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++; 
	echo("MSG: ",%client," deployed an Inventory Station"); 
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//=================================================================================================================
//========================================================================================== Ammo Station =========
//=================================================================================================================

ItemImageData DeployableAmmoPackImage 
	{ 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, -0.3 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 1.0; 
	firstPerson = false; 
	}; 

ItemData DeployableAmmoPack 
	{ 
	description = "Ammo Station"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = "eDeployable Stations"; 
	shadowDetailMask = 4; 
	imageType = DeployableAmmoPackImage; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function DeployableAmmoPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function DeployableAmmoPack::onDeploy(%player,%item,%pos) 
	{ 
	if (DeployableAmmoPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function DeployableAmmoPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true); 
	addToSet("MissionCleanup", %inv); 
	%rot = GameBase::getRotation(%player); 
	GameBase::setTeam(%inv,GameBase::getTeam(%player)); 
	GameBase::setPosition(%inv,$los::position); 
	GameBase::setRotation(%inv,%rot); 
	Gamebase::setMapName(%inv,%name); 
	Client::sendMessage(%client,0,"Ammo Station deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++; 
	echo("MSG: ",%client," deployed an Ammo Station"); 
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
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

ItemImageData DeployableComPackImage 
	{ 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.3 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 4.5; 
	firstPerson = false; 
	}; 

ItemData DeployableComPack 
	{ 
	description = "Command Station"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = "eDeployable Stations"; 
	shadowDetailMask = 4 ; 
	imageType = DeployableComPackImage; 
	mass = 4.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function DeployableComPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function DeployableComPack::onDeploy(%player,%item,%pos) 
	{ 
	if (DeployableComPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function DeployableComPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%inv = newObject("comunit_remote","StaticShape","DeployableComStation",true); 
	addToSet("MissionCleanup", %inv); 
	%rot = GameBase::getRotation(%player); 
	GameBase::setTeam(%inv,GameBase::getTeam(%player)); 
	GameBase::setPosition(%inv,$los::position); 
	GameBase::setRotation(%inv,%rot); 
	Gamebase::setMapName(%inv,%name); 
	Client::sendMessage(%client,0,"Command Station deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableComPack"]++;
	echo("MSG: ",%client," deployed a Command Station");  
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
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

ItemImageData DeployablevhclPackImage 
	{ 
	shapeFile = "invent_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.3 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData DeployablevhclPack 
	{ 
	description = "Vehicle Station"; 
	shapeFile = "invent_remote"; 
	className = "Backpack"; 
	heading = "eDeployable Stations"; 
	shadowDetailMask = 4 ; 
	imageType = DeployableInvPackImage; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function DeployablevhclPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function DeployablevhclPack::onDeploy(%player,%item,%pos) 
	{ 
	if (DeployablevhclPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function DeployablevhclPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7)  
	{ 
	%inv = newObject("ammounit_remote","StaticShape","DeployablevhclStation",true); 
	addToSet("MissionCleanup", %inv); 
	%rot = GameBase::getRotation(%player); 
	GameBase::setTeam(%inv,GameBase::getTeam(%player)); 
	GameBase::setPosition(%inv,$los::position); 
	GameBase::setRotation(%inv,%rot); 
	Gamebase::setMapName(%inv,%name); 
	Client::sendMessage(%client,0,"Vehicle Station deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%inv) @ "DeployablevhclPack"]++; 
	echo("MSG: ",%client," deployed a Vehicle Station"); 
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
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
//=======================================================================================



//=================================================================================================================
//===================================================================================== Motion Sensor =============
//=================================================================================================================

ItemImageData MotionSensorPackImage 
	{ 
	shapeFile = "sensor_small"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.1 }; 
	mountRotation = { 1.57, 0, 0 }; 
	firstPerson = false; 
	}; 

ItemData MotionSensorPack 
	{ 
	description = "Motion Sensor"; 
	shapeFile = "sensor_small"; 
	className = "Backpack"; 
	heading = "fDeployable Sensors"; 
	imageType = MotionSensorPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 69; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function MotionSensorPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function MotionSensorPack::onDeploy(%player,%item,%pos) 
	{ 
	if (MotionSensorPack::deployShape(%player,%item)) 
	{ 
	Player::decItemCount(%player,%item); 
	$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
	} 
	} 

function MotionSensorPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	%prot = GameBase::getRotation(%player); 
	%zRot = getWord(%prot,2); 
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot; 
	else 
	{ 
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot; 
	else 
	%rot = Vector::getRotation($los::normal); 
	} 
	%mSensor = newObject("","Sensor",DeployableMotionSensor,true); 
	addToSet("MissionCleanup", %mSensor); 
	GameBase::setTeam(%mSensor,GameBase::getTeam(%player)); 
	GameBase::setRotation(%mSensor,%rot); 
	GameBase::setPosition(%mSensor,$los::position); 
	Gamebase::setMapName(%mSensor,"Motion Sensor"); 
	Client::sendMessage(%client,0,"Motion Sensor deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	echo("MSG: ",%client," deployed a Motion Sensor"); 
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Can not be deployed on players!"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//=================================================================================================================
//========================================================================================= Pulse Sensor ==========
//=================================================================================================================

ItemImageData PulseSensorPackImage 
	{ 
	shapeFile = "radar_small"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.1 }; 
	mountRotation = { 1.57, 0, 0 }; 
	firstPerson = false; 
	}; 

ItemData PulseSensorPack 
	{ 
	description = "Pulse Sensor"; 
	shapeFile = "radar_small"; 
	className = "Backpack"; 
	heading = "fDeployable Sensors"; 
	imageType = PulseSensorPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 69; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function PulseSensorPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function PulseSensorPack::onDeploy(%player,%item,%pos) 
	{ 
	if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) 
	{ 
	Player::decItemCount(%player,%item); 
	$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
	echo("MSG: ",%client," deployed a Pulse Sensor");  
	} 
	} 

//=================================================================================================================
//======================================================================================== Sensor Jammer ==========
//=================================================================================================================

ItemImageData DeployableSensorJamPackImage
	{
	shapeFile = "sensor_jammer";
 	mountPoint = 2;
  	mountOffset = { 0, 0.03, 0.1 };
  	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
	};

ItemData DeployableSensorJammerPack
	{
	description = "Sensor Jammer";
  	shapeFile = "sensor_jammer";
  	className = "Backpack";
      heading = "fDeployable Sensors";
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
  	price = 69;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function DeployableSensorJammerPack::onUse(%player,%item)
	{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item);
	}

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos)
	{
	if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) 
	{
	Player::decItemCount(%player,%item);
	$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
	echo("MSG: ",%client," deployed a Sensor Jammer"); 
	}
	}

//=================================================================================================================
//=========================================================================================== Camera ==============
//=================================================================================================================

TurretData CameraTurret 
	{ 
	className = "Turret"; 
	shapeFile = "camera"; 
	maxDamage = 0.25; 
	maxEnergy = 10; 
	speed = 20; 
	speedModifier = 1.0; 
	range = 50; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	visibleToSensor = true; 
	shadowDetailMask = 4; 
	castLOS = true; 
	supression = false; 
	supressable = false; 
	mapFilter = 2; 
	mapIcon = "M_camera"; 
	debrisId = defaultDebrisSmall; 
	FOV = 0.707; 
	pinger = false; 
	explosionId = debrisExpMedium; 
	description = "Camera"; 
	}; 

ItemData CameraPack 
	{ 
	description = "Camera"; 
	shapeFile = "camera"; 
	className = "Backpack"; 
	heading = "fDeployable Sensors"; 
	imageType = CameraPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 69; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function CameraPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function CameraPack::onDeploy(%player,%item,%pos) 
	{ 
	if (CameraPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function CameraPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	%prot = GameBase::getRotation(%player); 
	%zRot = getWord(%prot,2); 
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot; 
	else 
	{ 
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot; 
	else 
	%rot = Vector::getRotation($los::normal); 
	} 
	%camera = newObject("Camera","Turret",CameraTurret,true); 
	addToSet("MissionCleanup", %camera); 
	GameBase::setTeam(%camera,GameBase::getTeam(%player)); 
	GameBase::setRotation(%camera,%rot); 
	GameBase::setPosition(%camera,$los::position); 
	Gamebase::setMapName(%camera,"Camera "@ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Camera deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++; 
	echo("MSG: ",%client," deployed a Camera"); 
	return true; 
	}
	else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function CameraTurret::onAdd(%this) 
	{ 
	schedule("CameraTurret::deploy(" @ %this @ ");",1,%this); 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Camera"); 
	}
 
function CameraTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function CameraTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function CameraTurret::onDestroyed(%this) 
	{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "CameraPack"]--; 
	} 

//===========================================================================================================
//=================================================================================== Blast Door ============
//===========================================================================================================

ItemImageData BlastDoorPackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData BlastDoorPack
	{
      description = "Blast Door";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "pDoors";
      imageType = BlastDoorPackImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function BlastDoorPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function BlastDoorPack::onDeploy(%player,%item,%pos)
	{
      if (BlastDoorPack::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function BlastDoorPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
      %obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
      %rot = GameBase::getRotation(%player);
      %camera = newObject("BlastDoorPack","StaticShape",BlastDoorShape,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera,"Blast Door "@ Client::getName(%client));
      Client::sendMessage(%client,0,"Blast Door deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "BlastDoorPack"]++;
      echo("MSG: ",%client," deployed a Blast Door ");
      return true;
      }
	else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
      else 
      Client::sendMessage(%client,0,"Deploy position out of range.");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}

//==============================================================================================================
//==================================================================================== 3x4 Forcedoor ===========
//==============================================================================================================

ItemImageData doorthreebyfourForceFieldPackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData doorthreebyfourForceFieldPack
	{
      description = "3x4 Field Door";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "pDoors";
      imageType = doorthreebyfourForceFieldPackImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function doorthreebyfourForceFieldPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function doorthreebyfourForceFieldPack::onDeploy(%player,%item,%pos)
	{
      if (doorthreebyfourForceFieldPack::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function doorthreebyfourForceFieldPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
      %obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
      %rot = GameBase::getRotation(%player);
      %camera = newObject("doorthreebyfourForceFieldPack","StaticShape",doorthreebyfourForceFieldShape,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera,"3x4 Forcefield Door " @ Client::getName(%client));
      Client::sendMessage(%client,0,"3x4 Forcefield Door deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "doorthreebyfourForceFieldPack"]++;
      echo("MSG: ",%client," deployed a 3x4 Force Field Door ");
      return true;
      }
	else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
      else 
      Client::sendMessage(%client,0,"Deploy position out of range.");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}

//==============================================================================================================
//==================================================================================== 4x8 Forcedoor ===========
//==============================================================================================================

ItemImageData doorfourbyeightForceFieldPackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData doorfourbyeightForceFieldPack
	{
      description = "4x8 Field Door";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "pDoors";
      imageType = doorfourbyeightForceFieldPackImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function doorfourbyeightForceFieldPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function doorfourbyeightForceFieldPack::onDeploy(%player,%item,%pos)
	{
      if (doorfourbyeightForceFieldPack::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function doorfourbyeightForceFieldPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
      %obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
      %rot = GameBase::getRotation(%player);
      %camera = newObject("doorfourbyeightForceFieldPack","StaticShape",doorfourbyeightForceFieldShape,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera,"4x8 Forcefield Door " @ Client::getName(%client));
      Client::sendMessage(%client,0,"4x8 Forcefield Door deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "doorfourbyeightForceFieldPack"]++;
      echo("MSG: ",%client," deployed a 4x8 Force Field Door ");
      return true;
      }
	else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
      else 
      Client::sendMessage(%client,0,"Cannot deploy here.");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}

//==============================================================================================================
//==================================================================================== 4x14 Forcedoor ==========
//==============================================================================================================

ItemImageData doorfourbyfourteenForceFieldPackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData doorfourbyfourteenForceFieldPack
	{
      description = "4x14 Field Door";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "pDoors";
      imageType = doorfourbyfourteenForceFieldPackImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function doorfourbyfourteenForceFieldPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function doorfourbyfourteenForceFieldPack::onDeploy(%player,%item,%pos)
	{
      if (doorfourbyfourteenForceFieldPack::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function doorfourbyfourteenForceFieldPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
      %obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
      %rot = GameBase::getRotation(%player);
      %camera = newObject("doorfourbyfourteenForceFieldPack","StaticShape",doorfourbyfourteenForceFieldShape,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera,"4x14 Forcefield Door " @ Client::getName(%client));
      Client::sendMessage(%client,0,"4x14 Forcefield Door deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "doorfourbyfourteenForceFieldPack"]++;
      echo("MSG: ",%client," deployed a 4x14 Force Field Door ");
      return true;
      }
      else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
	else 
      Client::sendMessage(%client,0,"Cannot deploy here.");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}

//==============================================================================================================
//==================================================================================== 4x17 Forcedoor ==========
//==============================================================================================================

ItemImageData doorfourbyseventeenForceFieldPackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData doorfourbyseventeenForceFieldPack
	{
      description = "4x17 Field Door";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "pDoors";
      imageType = doorfourbyseventeenForceFieldPackImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function doorfourbyseventeenForceFieldPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function doorfourbyseventeenForceFieldPack::onDeploy(%player,%item,%pos)
	{
      if (doorfourbyseventeenForceFieldPack::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function doorfourbyseventeenForceFieldPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
      %obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
      %rot = GameBase::getRotation(%player);
      %camera = newObject("doorfourbyseventeenForceFieldPack","StaticShape",doorfourbyseventeenForceFieldShape,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera,"4x17 Forcefield Door " @ Client::getName(%client));
      Client::sendMessage(%client,0,"4x17 Forcefield Door deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "doorfourbyseventeenForceFieldPack"]++;
      echo("MSG: ",%client," deployed a 4x17 Force Field Door ");
      return true;
      }
      else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
	else 
      Client::sendMessage(%client,0,"Cannot deploy here.");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}

//==============================================================================================================
//==================================================================================== 5x5 Forcedoor ===========
//==============================================================================================================

ItemImageData doorfivebyfiveForceFieldPackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData doorfivebyfiveForceFieldPack
	{
      description = "5x5 Field Door";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "pDoors";
      imageType = doorfivebyfiveForceFieldPackImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function doorfivebyfiveForceFieldPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function doorfivebyfiveForceFieldPack::onDeploy(%player,%item,%pos)
	{
      if (doorfivebyfiveForceFieldPack::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function doorfivebyfiveForceFieldPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
      %obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
      %rot = GameBase::getRotation(%player);
      %camera = newObject("doorfivebyfiveForceFieldPack","StaticShape",doorfivebyfiveForceFieldShape,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera,"5x5 Forcefield Door " @ Client::getName(%client));
      Client::sendMessage(%client,0,"5x5 Forcefield Door deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "doorfivebyfiveForceFieldPack"]++;
      echo("MSG: ",%client," deployed a 5x5 Force Field Door ");
      return true;
      }
      else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
	else 
      Client::sendMessage(%client,0,"Cannot deploy here.");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}

//==============================================================================================================
//==================================================================================== Platform Door ===========
//==============================================================================================================

ItemImageData PlatformDoorPackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData PlatformDoorPack
	{
      description = "Platform Door";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "pDoors";
      imageType = PlatformDoorPackImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function PlatformDoorPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function PlatformDoorPack::onDeploy(%player,%item,%pos)
	{
      if (PlatformDoorPack::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function PlatformDoorPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,15)) 
	{
      %obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
	if (Vector::dot($los::normal,"0 0 1") < 0.01 && Vector::dot($los::normal,"0 0 -1") < 0.01) 
	%rot = Vector::getRotation($los::normal); 
	else
	{
	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2); 
	%rot = "1.570795 0 " @ %zRot; 
	}
      %camera = newObject("PlatformDoor","StaticShape",PlatformDoor,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera,"Platform Door " @ Client::getName(%client));
      Client::sendMessage(%client,0,"Platform Door deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "PlatformDoorPack"]++;
      echo("MSG: ",%client," deployed a Platform Door");
      return true;
      }
      else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
	else 
      Client::sendMessage(%client,0,"Cannot deploy here");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}


//==============================================================================================================
//==================================================================================== Medium Platform =========
//==============================================================================================================

ItemImageData MedPlatformImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData MedPlatform
	{
	description = "Medium Platform";
	shapeFile = "discammo";
	className = "Backpack";
      heading = "oDeployable Platforms";
	imageType = MedPlatformImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.1;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function MedPlatform::onUse(%player,%item)
	{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item);
	}

function MedPlatform::onDeploy(%player,%item,%pos)
	{
	if (MedPlatform::deployShape(%player,%item))
	Player::decItemCount(%player,%item); 
	}

function MedPlatform::deployShape(%player,%item)
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%phase = newObject("","StaticShape",MediumPlatform,true); 
	addToSet("MissionCleanup", %phase); 
	GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
	GameBase::setPosition(%phase,$los::position); 
	GameBase::setRotation(%phase,%rot); 
	Gamebase::setMapName(%phase,"Medium Platform " @ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Medium Platform Deployed"); 
	GameBase::startFadeIn(%phase); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "MedPlatform"]++; 
	echo("MSG: ",%client," deployed a Medium Platform");   
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range");
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//==============================================================================================================
//==================================================================================== Large Platform ==========
//==============================================================================================================

ItemImageData LrgPltPackImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData LrgPltPack 
	{ 
	description = "LargePlatform"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = "oDeployable Platforms"; 
	imageType = LrgPltPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function LrgPltPack::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else
	{
	if (Vector::GetDistance(%deplpos,%teamposa) < 60 || Vector::GetDistance(%deplpos,%teamposb) < 60 )
	{
	Client::sendMessage(%client,0,"You are too close to the base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else
	Player::deployItem(%player,%item);
	}
	}

function LrgPltPack::onDeploy(%player,%item,%pos) 
	{ 
	if (LrgPltPack::deployShape(%player,%item))  
	Player::decItemCount(%player,%item);  
	} 

function LrgPltPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%phase = newObject("","StaticShape",LargePlatform,true); 
	addToSet("MissionCleanup", %phase); 
	GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
	GameBase::setPosition(%phase,$los::position); 
	GameBase::setRotation(%phase,%rot); 
	Gamebase::setMapName(%phase,"Large Platform "@ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Large Platform Deployed"); 
	GameBase::startFadeIn(%phase); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "LrgPltPack"]++; 
	echo("MSG: ",%client," deployed a Large Platform");   
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range");
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//==============================================================================================================
//==================================================================================== Jail Capture Pad ========
//==============================================================================================================

ItemImageData JailCapPackImage
	{
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	};

ItemData JailCapPack
	{
	description = "Jail Capture Pad";
	shapeFile = "discammo";
	className = "Backpack";
	heading = "iJail";
	imageType = JailCapPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function JailCapPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else 
      Player::deployItem(%player,%item);
	}

function JailCapPack::onDeploy(%player,%item,%pos)
	{
      if (JailCapPack::deployShape(%player,%item)) 
      Player::decItemCount(%player,%item);
	}

function JailCapPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object); 
	if (%obj == "Player")
	{
	Client::sendMessage(%client,0,"Can't be deployed on players");
      return false;
	} 
	%playerPos = GameBase::getPosition(%player);
      %flag = $teamFlag[GameBase::getTeam(%player)];
      %flagpos = gamebase::getPosition(%flag);
	if(Vector::getDistance(%flagpos, %playerpos) < 10)
      {
      Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
      return false;
      }
	%prot = GameBase::getRotation(%player);
      %zRot = getWord(%prot,2);
      %rot =  "1.57079 0 " @ %zRot;
      %padd = "0 0 0";
      %pos = Vector::add($los::position,%padd); 
	%camera = newObject("","StaticShape","jailpad",true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,"0 0 0");
      GameBase::setPosition(%camera,%pos);
      Gamebase::setMapName(%camera,"JailPad " @ Client::getName(%client));
      Client::sendMessage(%client,0,"Jail Pad Deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%player) @ "JailCapPack"]++;
      echo("MSG: ",%client," deployed a Jail Pad");
      return true;
	}
      else 
      Client::sendMessage(%client,0,"Deploy position out of range.");
	}
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
	}

//==============================================================================================================
//========================================================================================= Jail Cell ==========
//==============================================================================================================

ItemImageData jailpackImage
	{
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	};

ItemData jailpack
	{
	description = "Jail Cell";
	shapeFile = "shieldpack";
	className = "Backpack";
	heading = "iJail";
	imageType = jailpackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function jailpack::onUse(%player,%item)
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 111 || Vector::getDistance(%deplpos, %teamposb) < 111 )
	{
	Client::sendMessage(%client,0,"You are too close to the base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	}

function jailpack::onDeploy(%player,%item,%pos)
	{
	if (jailpack::deployShape(%player,%item))
	Player::decItemCount(%player,%item);
	}

function CreatejailportSimSet()
	{
	%teleset = nameToID("MissionCleanup/jailports");
	if(%teleset == -1)
	{
	newObject("jailports",SimSet);
	addToSet("MissionCleanup","jailports");
	}
	}

function jailpack::deployshape(%player,%item)
	{
	GameBase::getLOSInfo(%player,10);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "jailpack"] >= $TeamItemMax[jailpack])
	{
	Client::sendMessage(%client,0,"Can Not Deploy Jail Cell Already In Place");
	return false;
	}
      %objDevice = newObject("Jail","Staticshape",LLargeForceField,true);
      %objDevice.objSide1 = newObject("Jail","Staticshape",LLargeForceField,true);
      %objDevice.objSide2 = newObject("Jail","Staticshape",LLargeForceField,true);
      %objDevice.objSide3 = newObject("Jail","Staticshape",LLargeForceField,true);
      %objDevice.objSide4 = newObject("Jail","Staticshape",LLargeForceField,true);
      %objDevice.objSide5 = newObject("Jail","StaticShape",LLargeForceField,true);
      %objDevice.objSide6 = newObject("Jail","StaticShape",LLargeForceField,true);
      %objDevice.objSide7 = newObject("Jail","StaticShape",LLargeForceField,true);
      %objDevice.objSide8 = newObject("Jail","StaticShape",JailSwitchOpen,true);
      %objDevice.objSide9 = newObject("Jail","StaticShape",LLargeForceField,true);
      %objDevice.objSide10 = newObject("Jail","StaticShape",JailSwitchClose,true);
      %objDevice.objSide1.objParent = %objDevice;
      %objDevice.objSide2.objParent = %objDevice;
      %objDevice.objSide3.objParent = %objDevice;
      %objDevice.objSide4.objParent = %objDevice;
      %objDevice.objSide5.objParent = %objDevice;
      %objDevice.objSide6.objParent = %objDevice;
      %objDevice.objSide7.objParent = %objDevice;
      %objDevice.objSide8.objParent = %objDevice;
      %objDevice.objSide9.objParent = %objDevice;
      %objDevice.objSide10.objParent = %objDevice;
      addToSet(MissionCleanup, %objDevice);
      addToSet(MissionCleanup, %objDevice.objSide1);
      addToSet(MissionCleanup, %objDevice.objSide2);
      addToSet(MissionCleanup, %objDevice.objSide3);
      addToSet(MissionCleanup, %objDevice.objSide4);
      addToSet(MissionCleanup, %objDevice.objSide5);
      addToSet(MissionCleanup, %objDevice.objSide6);
      addToSet(MissionCleanup, %objDevice.objSide7);
      addToSet(MissionCleanup, %objDevice.objSide8);
      addToSet(MissionCleanup, %objDevice.objSide9);
      addToSet(MissionCleanup, %objDevice.objSide10);
      %pos = Vector::add(GameBase::getPosition(%player), "0 1 80");
      GameBase::setRotation(%objDevice.objSide1,"0 0 0");
      GameBase::setPosition(%objDevice.objSide1,%pos);
      GameBase::setTeam(%objDevice.objSide1,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "-5.5 6.5 80");
      GameBase::setRotation(%objDevice.objSide2,"0 0 4.71339");
      GameBase::setPosition(%objDevice.objSide2,%pos);
      GameBase::setTeam(%objDevice.objSide2,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "5.5 6.5 80");
      GameBase::setRotation(%objDevice.objSide3,"0 0 4.71339");
      GameBase::setPosition(%objDevice.objSide3,%pos);
      GameBase::setTeam(%objDevice.objSide3,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "0 12.5 86");
      GameBase::setRotation(%objDevice.objSide4,"-4.71339 0 0");
      GameBase::setPosition(%objDevice.objSide4,%pos);
      GameBase::setTeam(%objDevice.objSide4,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "0 .5 86");
      GameBase::setRotation(%objDevice,"4.71339 0 0");
      GameBase::setPosition(%objDevice,%pos);
      GameBase::setTeam(%objDevice,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "0 12.5 80");
      GameBase::setRotation(%objDevice.objSide6,"-4.71339 0 0");
      GameBase::setPosition(%objDevice.objSide6,%pos);
      GameBase::setTeam(%objDevice.objSide6,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "0 .5 80");
      GameBase::setRotation(%objDevice.objSide7,"4.71339 0 0");
      GameBase::setPosition(%objDevice.objSide7,%pos);
      GameBase::setTeam(%objDevice.objSide7,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "-5 13 80.00");
      GameBase::setRotation(%objDevice.objSide8,"0 0 0");
      GameBase::setPosition(%objDevice.objSide8,%pos);
      GameBase::setTeam(%objDevice.objSide8,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "0 18 80");
      GameBase::setRotation(%objDevice.objSide9,"-4.71339 0 0");
      GameBase::setPosition(%objDevice.objSide9,%pos);
      GameBase::setTeam(%objDevice.objSide9,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "5 13 80.00");
	GameBase::setRotation(%objDevice.objSide10,"0 0 0");
	GameBase::setPosition(%objDevice.objSide10,%pos);
	GameBase::setTeam(%objDevice.objSide10,GameBase::getTeam(%player));
	playSound(SoundPickupBackpack,$los::position);
	newObject("jaildoor",SimSet);
	addToSet("MissionCleanup","jaildoor");
	%sensor = newObject("jaildoor","StaticShape",jLargeForceField,true);
	addToSet("MissionCleanup/jaildoor", %sensor);
	addToSet("MissionCleanup", %sensor);
	GameBase::setTeam(%sensor,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 12 80");
	GameBase::setPosition(%sensor,%pos);
	GameBase::setRotation(%sensor,"0 0 0");
	%sensor.disabled = false;
	playSound(SoundPickupBackpack,$los::position);
	%sensor = newObject("Teleport Pad","StaticShape","jailStand",true);
	CreatejailportSimSet();
	addToSet("MissionCleanup/jailports", %sensor);
	addToSet("MissionCleanup", %sensor);
	GameBase::setTeam(%sensor,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 3 81");
	GameBase::setPosition(%sensor,%pos);
	Gamebase::setMapName(%sensor,%name);
	%sensor.disabled = false;
	playSound(SoundPickupBackpack,$los::position);
	%beam = newObject("","StaticShape",ElectricalBeamBig,true);
	addToSet("MissionCleanup", %beam);
	GameBase::setTeam(%beam,GameBase::getTeam(%player));
	GameBase::setPosition(%beam,%pos);
	%sensor.beam1 = %beam;
	playSound(SoundPickupBackpack,$los::position);
	newObject("releasepad",SimSet);
	CreatereleasepadSimSet();
	addToSet("MissionCleanup/releasepad", %sensor);
	addToSet("MissionCleanup", %sensor);
	%sensor = newObject("releasepad","StaticShape","jailStandTop",true);
	addToSet("MissionCleanup/releasepad", %sensor);
	GameBase::setTeam(%sensor,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 3 86.30");
	GameBase::setPosition(%sensor,%pos);
	Gamebase::setMapName(%sensor,%name);
	%sensor.disabled = false;
	$TeamItemCount[GameBase::getTeam(%sensor) @ "jailpack"]++;
	echo("MSG: ",%client," deployed a Jail Cell");
	Client::sendMessage(%client,0,%item.description @ " deployed 250' Up");
	return true;
	}

//plasmatic
function ToJail(%client,%team)
{
	
	%player = Client::getOwnedObject(%client);
	echo("jailed pl# "@%player);
	%player.invulnerable = true;

		schedule("prisonguard("@%client@");",1);
		%name = Client::getName(%Client);
		GameBase::SetPosition(%client, $JailPosition[%Team]);		
		Client::SendMessage(%client,0,"Your jail sentence will last 30 seconds.");
		schedule("JailBreak(" @ %client @ ", " @ %team @ ");",30);
		schedule("JailBird(" @ %client @ ", " @ %team @ ");",1);		
		if(GameBase::getControlClient(%player) != %client){
		//yank em outa that turret or vehicle NYPD style!
			if(%player.ManualCommandTag)
				{	
				%player.ManualCommandTag = False;
				%player.CommandTag = "";
				}
			Player::setMountObject(%player, -1,0);
			Client::setControlObject(%client, %player);	
		
		}

}

function prisonguard(%client)
{
	%player = Client::getOwnedObject(%client);
	%player.jailed = true;
}

function JailBird(%client, %team)
{	
	%player = Client::getOwnedObject(%client);
	if(Player::isDead(%player)) return;
	%playerPos = GameBase::getPosition(%player);
	%playerdist = Vector::getDistance($JailPosition[%Team], %playerpos);
	if(%playerdist > 10)
		{
		Client::SendMessage(%client, 0, "You've escaped! Run Forrest Run!!!!");	
		Messageallexcept(%client,0,Client::getName(%client)@" escaped from jail.");				
		schedule("ParoleGrace("@%client@");",5);
		%player = Client::getOwnedObject(%client);
		%player.jailed = false;	
		}
	if(%player.jailed)  schedule("JailBird(" @ %client @ ", " @ %team @ ");",1);
}






//plasmatic
function JailBreak(%client, %team)
{
	%player = Client::getOwnedObject(%client);
//	echo("jail client "@%client@" player# "@%player@" in team's "@ %team@" jail");
	%playerPos = GameBase::getPosition(%player);
	%playerdist = Vector::getDistance($JailPosition[%Team], %playerpos);
	schedule("ParoleGrace("@%client@");",5);
//	echo("%playerdist "@%playerdist);
	if(%playerdist < 10){	
		%posX = getWord($JailPosition[%Team], 0);
		%posY = getWord($JailPosition[%Team], 1);
		%posZ = getWord($JailPosition[%Team], 2) + 10;
		%freeplayerpos = %posX@" "@%posY@" "@%posZ;
		GameBase::SetPosition(%client, %freeplayerpos);
		Client::SendMessage(%client, 0, "You Have Been Released. Run Forrest Run!!!!~wshieldhit.wav");
		Messageallexcept(%client,0,Client::getName(%client)@" Was paroled early from jail.");
		%player.jailed = "";
	}
}

function ParoleGrace(%client){
	%player = Client::getOwnedObject(%client);
	%player.invulnerable = "";
	%player.jailed = "";
//	echo("jail grace over");
	}

function CreatereleasepadSimSet()
	{
	%teleset = nameToID("MissionCleanup/releasepad");
	if(%teleset == -1)
	{
	newObject("releasepad",SimSet);
	addToSet("MissionCleanup","releasepad");
	}
	}

//=============================================================================================================
//======================================================================================== Arbitor Box ========
//=============================================================================================================

TurretData ArbitorBox
	{
	className = "Turret";
	shapeFile = "plasammo";
	maxDamage = 2;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Arbitor Box";
	damageSkinData = "objectDamageSkins";
	};

ItemImageData ArbitorBoxPackImage
	{
	shapeFile = "plasammo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
	};

ItemData ArbitorBoxPack
	{
	description = "Arbitor Device";
	shapeFile = "plasammo";
	className = "Backpack";
      heading = "hDeployable Base Objects";
	imageType = ArbitorBoxPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function ArbitorBoxPack::onUse(%player,%item)
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else
	{
	if (Vector::GetDistance(%deplpos,%teamposa) < 100 || Vector::GetDistance(%deplpos,%teamposb) < 100 )
	{
	Client::sendMessage(%client,0,"You are too close to the base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else
	Player::deployItem(%player,%item);
	}
	}

function ArbitorBoxPack::onDeploy(%player,%item,%pos)
	{
	if (ArbitorBoxPack::deployShape(%player,%item))
	Player::decItemCount(%player,%item);
	}

function ArbitorBoxPack::deployShape(%player,%item)
	{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
	if (GameBase::getLOSInfo(%player,10))
	{
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7)
	{
	%rot = GameBase::getRotation(%player); 
	%turret = newObject("ArbitorBox","Turret",ArbitorBox,true);
      addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	Gamebase::setMapName(%turret,"Arbitor Device " @ Client::getName(%client));
	Client::sendMessage(%client,0,"Arbitor Device deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "ArbitorBoxPack"]++;
	echo("MSG: ",%client," deployed an Arbitor Box");
	if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
	GameBase::setDamageLevel(%turret, 0.7 * ArbitorBox.maxDamage);
	return true;
	}
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces.");
	}
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players.");
	}
	else 
	Client::sendMessage(%client,0,"Deploy position out of range.");
	}
	else																						  
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "es");
	return false;
	}

function ArbitorBox::onAdd(%this)
	{
	schedule("ArbitorBox::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Arbitor Box");
	}

function ArbitorBox::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }

function ArbitorBox::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }

function ArbitorBox::onDisabled(%this)
	{
	Turret::onDisabled(%this);
	%num = Group::objectCount(%this.set);
	for(%i=%num-1; %i >= 0; %i--)
	{
	%obj = Group::getObject(%this.set, %i);
	GameBase::startFadeIn(%obj);
	%obj.cloaked = 0;
	}
	GameBase::setActive(%this,false);
	deleteObject(%this.set);
	}

function ArbitorBox::onDestroyed(%this)
	{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ArbitorBoxPack"]--;
	}

function ArbitorBox::onPower(%this,%power,%generator) {}

function ArbitorBox::onEnabled(%this) 
	{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType; 
	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 50,0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
	%obj = Group::getObject(%Set, %i);
	if(GameBase::getTeam(%obj) == GameBase::getTeam(%this) && %obj != %this)
	{
	GameBase::startFadeOut(%obj);
	%obj.cloaked = 1;
	}
	}
	%this.set = %Set;
	schedule("ArbitorBox::checkArbitorBox(" @ %this @ ");", 0.25, %this);
	}	

function ArbitorBox::checkArbitorBox(%this)
	{
	if(GameBase::getDamageState(%this) != "Enabled")
	return;
	%this.evenodd = !%this.evenodd; 
	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; 
	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 50,0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
	%obj = Group::getObject(%Set, %i);
	if(GameBase::getTeam(%obj) == GameBase::getTeam(%this) && %obj != %this)
	{
	GameBase::startFadeOut(%obj);
	%obj.cloaked = 1 + %this.evenodd; 
	}
	}
	%num = Group::objectCount(%this.set);
	for(%j; %j < %num; %j++)
	{
	%obj = Group::getObject(%this.set, %j);
	if(%obj != %this && GameBase::getTeam(%obj) == GameBase::getTeam(%this))
	if(%obj.cloaked != (%this.evenodd + 1)) 
	{
	%obj.cloaked = 0;
	if(%obj.cloakPack == 0 && %obj.cloakGun == 0) GameBase::startFadeIn(%obj); 
	}
	}
	deleteObject(%this.set); 
	%this.set = %Set; 
	schedule("ArbitorBox::checkArbitorBox(" @ %this @ ");", 6.0, %this); 
	}

//=================================================================================================================
//===================================================================================== Base Alarm ================
//=================================================================================================================

ItemImageData BaseAlarmImage
	{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
	};

ItemData BaseAlarm
	{
      description = "Base Alarm";
      shapeFile = "sensor_small";
      className = "Backpack";
      heading = "fDeployable Sensors";
      shadowDetailMask = 4;
      imageType = BaseAlarmImage;
      mass = 2.0;
      elasticity = 0.2;
      price = 69;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function BaseAlarm::onUse(%player,%item)
	{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item);
	}

function BaseAlarm::onDeploy(%player,%item,%pos)
	{
	if (BaseAlarm::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item);
	}

function BaseAlarm::deployShape(%player,%item)
	{
 	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object);
	if (%obj == "InteriorShape") 
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 0";
	else 
	{
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 0";
	else 
	%rot = Vector::getRotation($los::normal);
	}
	%alarm = newObject("","StaticShape", "AlarmKit",true);
 	addToSet("MissionCleanup", %alarm);
	GameBase::setTeam(%alarm,GameBase::getTeam(%player));
	GameBase::setRotation(%alarm,%rot);
	GameBase::setPosition(%alarm,$los::position);
	Gamebase::setMapName(%alarm,%name);
	Gamebase::setMapName(%alarm,"Base Alarm # "@$totalNumAlarms[GameBase::getTeam(%player)] );
	Client::sendMessage(%client,0,"Alarm #" @ $totalNumAlarms[GameBase::getTeam(%player)] @ " deployed");
	$TeamItemCount[GameBase::getTeam(%SGen) @ "BaseAlarm"]++;
	echo("MSG: ",%client," deployed a Base Alarm"); 
	return true;
	}
	else 
	Client::sendMessage(%client,0,"Can only deploy on buildings");
	}
	else 
	Client::sendMessage(%client,0,"Deploy position out of range");
	return false;
	}

//=============================================================================================================
//================================================================================== Builder Pole =============
//=============================================================================================================

ItemImageData BuilderPoleImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	}; 

ItemData BuilderPole 
	{ 
	description = "Builder Pole"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = "hDeployable Base Objects"; 
	imageType = BuilderPoleImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function BuilderPole::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function BuilderPole::onDeploy(%player,%item,%pos) 
	{ 
	if (BuilderPole::deployShape(%player,%item)) 
	{ 
	Player::decItemCount(%player,%item); 
	$TeamItemCount[GameBase::getTeam(%player) @ "BuilderPole"]++;
	echo("MSG: ",%client," deployed a Builder Pole");  
	} 
	} 

function BuilderPole::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	%prot = GameBase::getRotation(%player); 
	%zRot = getWord(%prot,2); 
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot; 
	else 
	{ 
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot; 
	else 
	%rot = Vector::getRotation($los::normal); 
	} 
	%mSensor = newObject("pole","StaticShape",LargeAntenna,true); 
	addToSet("MissionCleanup", %mSensor); 
	GameBase::setTeam(%mSensor,GameBase::getTeam(%player)); 
	GameBase::setRotation(%mSensor,%rot); 
	GameBase::setPosition(%mSensor,$los::position); 
	Gamebase::setMapName(%mSensor,"Builder Pole"); 
	Client::sendMessage(%client,0,"Builder Pole deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	echo("MSG: ",%client," deployed a Builder Pole"); 
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players."); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//===============================================================================================================
//=================================================================================== Deployable Platform =======
//===============================================================================================================

ItemImageData PlatformPackImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData PlatformPack 
	{ 
	description = "Deployable Platform"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = "oDeployable Platforms"; 
	imageType = PlatformPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function PlatformPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function PlatformPack::onDeploy(%player,%item,%pos) 
	{ 
	if (PlatformPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function PlatformPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%phase = newObject("DeployablePlatform","StaticShape",DeployablePlatform,true); 
	addToSet("MissionCleanup", %phase); 
	GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
	GameBase::setPosition(%phase,$los::position); 
	GameBase::setRotation(%phase,%rot); 
	Gamebase::setMapName(%phase,"Deployable Platform " @ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Platform Deployed"); 
	GameBase::startFadeIn(%phase); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "PlatformPack"]++;
	echo("MSG: ",%client," deployed a Platform");  
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//==============================================================================================================
//======================================================================================== Flagstand ===========
//==============================================================================================================
ItemImageData FlagstandPackImage
	{
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	};

ItemData FlagstandPack
	{	
	description = "Flag Stand";
	shapefile = "discammo";
	classname = "Backpack";
	heading = "hDeployable Base Objects";
	imageType = FlagstandPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.1;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function FlagstandPack::onUse(%player,%item)
	{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item);
	}

function FlagStandPack::onDeploy(%player,%item,%pos)
	{
	if (FlagstandPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item);
	}

function FlagstandPack::deployShape(%player,%item)
	{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
	if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{
	%playerPos = GameBase::getPosition(%player);
	%flag = $teamFlag[GameBase::getTeam(%player)];
	%flagpos = %flag.originalposition;
	if(Vector::getDistance(%flagpos, %playerpos) < 5000)
	{
	%rot = GameBase::getRotation(%player); 
	%sensor = newObject("","Staticshape",DeployableFlagstand,true);
	addToSet("MissionCleanup", %sensor);
	GameBase::setTeam(%sensor,GameBase::getTeam(%player));
	GameBase::setPosition(%sensor,$los::position);
	GameBase::setRotation(%sensor,%rot);
	Gamebase::setMapName(%sensor,"Flagstand " @ Client::getName(%client));
	Client::sendMessage(%client,0,"Flagstand deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "FlagstandPack"]++;
	echo("MSG: ",%client," deployed a Flag stand");
	return true;
	}	
	else
	Client::sendMessage(%client,0,"You are too far away from the flags original position.");
	}
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
	}
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
	else 
	Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
	}

function DeployableFlagstand::onCollision(%this,%object)
	{
      if(%object.enterTime > getSimTime() - 3)
	return;
      %standTeam = GameBase::getTeam(%this);
      %playerTeam = GameBase::getTeam(%object);
      %playerClient = Player::getClient(%object);
      if(getObjectType(%object) != "Player" || %playerTeam != %standTeam || %object.carryflag == "")
      return;
      %flag = %object.carryFlag;
      %flagTeam = GameBase::getTeam(%flag);
      if(%this.carryflag != "")
	return;
      %this.carryflag = %flag;
      %flag.carrier = -1;
      Item::hide(%flag, false);
      GameBase::setPosition(%flag, GameBase::getPosition(%this)); 
      playSound(SoundPickupBackpack, GameBase::getPosition(%this));
      %flag.flagStand = %this;
      Player::setItemCount(%object, Flag, 0);
      %object.carryFlag = "";
      %playerClient = Player::getClient(%object);
      Flag::clearWaypoint(%playerClient, true);
      if(getTeamName(%flag) == %playerTeam)
	{
   	MessageAllExcept(%playerClient, 0,"The " @ getTeamName(%playerteam) @ " flag has been moved to a new position");
   	Client::sendMessage(%playerClient, 0, "You moved your flag.");
      }
      else 
	{
	MessageAllExcept(%playerClient, 0,"The " @ getTeamName(%playerteam) @ " have set an enemy flag on a flagstand");
   	Client::sendMessage(%playerClient, 0, "You placed the enemy flag down.");
      }	
      %object.enterTime = getSimTime();
	}
//==============================================================================================================
//========================================================================================= Hologram ===========
//==============================================================================================================

ItemImageData HoloPackImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData HoloPack 
	{ 
	description = "Hologram"; 
	shapeFile = "larmor"; 
	className = "Backpack"; 
	heading = "hDeployable Base Objects"; 
	imageType = HoloPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function HoloPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function HoloPack::onDeploy(%player,%item,%pos) 
	{ 
	if (HoloPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function HoloPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "hologram"] < $TeamItemMax["hologram"]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%rnd = floor(getRandom() * 10); 
	if(%rnd > 6) 
	%phase = newObject("","StaticShape",Hologram1,true); 
	else 
	if((%rnd > 2) && (%rnd < 7)) 
	%phase = newObject("","StaticShape",Hologram2,true); 
	else 
	%phase = newObject("","StaticShape",Hologram3,true); 
	%armor = Player::getArmor(%player); 
	if (%armor == "dmarmor" || %armor == "dmfemale")  
	%phase = newObject("","StaticShape",Hologram2,true);  
	addToSet("MissionCleanup", %phase); 
	GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
	GameBase::setPosition(%phase,$los::position); 
	GameBase::setRotation(%phase,%rot); 
	Client::sendMessage(%client,0,"Hologram Deployed"); 
	GameBase::startFadeIn(%phase); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "hologram"]++;
	echo("MSG: ",%client," deployed a Hologram");  
	return true;  
	}
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	}
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	}   
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//=============================================================================================================
//=================================================================================== Remote Base =============
//=============================================================================================================

ItemImageData RemoteBaseImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	}; 

ItemData RemoteBase 
	{ 
	description = "Remote Base"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = "hDeployable Base Objects"; 
	imageType = RemoteBaseImage; 
	shadowDetailMask = 4; 
	mass = 2.5; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function RemoteBase::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 100 || Vector::getDistance(%deplpos, %teamposb) < 100 )
	{
	Client::sendMessage(%client,0,"You are too close to the base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	}

function RemoteBase::onDeploy(%player,%item,%pos) 
	{ 
	if (RemoteBase::deployShape(%player,%item)) 
	{ 
	Player::decItemCount(%player,%item); 
	$TeamItemCount[GameBase::getTeam(%player) @ "RemoteBase"]++;
	} 
	} 

function RemoteBase::deployShape(%player,%item) 
	{ 
	if(Player::getMountedItem(%player,$BackpackSlot) != RemoteBase) return false; // PORT: 'Remote...' functions can be called by a client (remoteEval "Base::deployShape")
	%client = Player::getClient(%player);
	%playpos = GameBase::getPosition(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,20)) 
	{ 
	%obj = getObjectType($los::object);
	if (%obj == "SimTerrain" || %obj == "Large Platform") 
	{ 
	if(Vector::GetDistance(%playpos,$los::position) > 9 ) 
	{
	%base = newObject("Remotebase",InteriorShape,"bunker4.dis",false);
	%base.basebackwall = newObject("Remotebase","Staticshape",bLargeForceField,true);
	%base.baseleftwall = newObject("Remotebase","Staticshape",bLargeForceField,true);
	%base.baserightwall = newObject("Remotebase","Staticshape",bLargeForceField,true);
	%base.baseturret = newObject("Remotebase","Turret",DeployableRocket,false);
	%base.basestation = newObject("Remotebase","StaticShape",BaseStation,false);
	%base.basedoor = newObject("Remotebase","Staticshape",bdForceField,true);
	%base.basedoor.objParent = %base;
	%base.basebackwall.objParent = %base;
	%base.baseleftwall.objParent = %base;
	%base.baserightwall.objParent = %base;
	%base.baseturret.objParent = %base;
	%base.basestation.objParent = %base;
	addToSet("MissionCleanup", %base);
	addToSet("MissionCleanup", %base.basebackwall);
	addToSet("MissionCleanup", %base.baseleftwall);
	addToSet("MissionCleanup", %base.baserightwall);
	addToSet("MissionCleanup", %base.baseturret);
	addToSet("MissionCleanup", %base.basedoor);
	addToSet("MissionCleanup", %base.basestation);
	GameBase::setTeam(%base,GameBase::getTeam(%player));
	GameBase::setPosition(%base,$los::position);
	GameBase::setRotation(%base,"0 0 0");
	%pos = Vector::add($los::position, "0 5.875 0");
	GameBase::setRotation(%base.basebackwall,"0 0 0");
	GameBase::setPosition(%base.basebackwall,%pos);
	GameBase::setTeam(%base.basebackwall,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "0 -5.875 0");
	GameBase::setRotation(%base.basedoor,"0 0 0");
	GameBase::setPosition(%base.basedoor,%pos);
	GameBase::setTeam(%base.basedoor,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "-5.875 0 0");
	GameBase::setRotation(%base.baseleftwall,"0 0 4.7125");
	GameBase::setPosition(%base.baseleftwall,%pos);
	GameBase::setTeam(%base.baseleftwall,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "5.875 0 0");
	GameBase::setRotation(%base.baserightwall,"0 0 4.7125");
	GameBase::setPosition(%base.baserightwall,%pos);
	GameBase::setTeam(%base.baserightwall,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "0 0 9.77");
	GameBase::setRotation(%base.baseturret,"0 0 0");
	GameBase::setPosition(%base.baseturret,%pos);
	GameBase::setTeam(%base.baseturret,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "0 3 1");
	GameBase::setRotation(%base.basestation,"0 0 0");
	GameBase::setPosition(%base.basestation,%pos);
	GameBase::setTeam(%base.basestation,GameBase::getTeam(%player));
	$TeamItemCount[GameBase::getTeam(%sensor) @ "RemoteBase"]++;
	Gamebase::setMapName(%base,"Remote Base " @ Client::getName(%client));
	Client::setOwnedObject(%client, %base);
      Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Remote base deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	echo("MSG: ",%client," deployed a Remote Base"); 
	return true; 
	}
	else 
	Client::sendMessage(%client,0,"You are too close to the deploy position."); 
	} 
	else 
	Client::sendMessage(%client,0,"Can only be deployed on terrain."); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//========================================================================================================
//============================================================================== Sniper Hut ==============
//========================================================================================================

ItemImageData SniperHutImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	};

ItemData SniperHut
	{
	description = "Sniper Hut"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = "hDeployable Base Objects";
	imageType = SniperHutImage;
	shadowDetailMask = 4; 
	mass = 2.5;
	elasticity = 0.1;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function SniperHut::onUse(%player,%item)
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 120 || Vector::getDistance(%deplpos, %teamposb) < 120 )
	{
	Client::sendMessage(%client,0,"You are too close to the base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	}

function SniperHut::onDeploy(%player,%item,%pos)
	{
	if (SniperHut::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item);
	}

function SniperHut::deployShape(%player,%item)
	{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
	if (GameBase::getLOSInfo(%player,12)) 
	{
	%obj = getObjectType($los::object);
	if (%obj == "SimTerrain") 
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{
	%prot = GameBase::getRotation(%player); 
	%zRot = getWord(%prot,2);
	%xRot = %zRot + 9.44;
	%rot = "0 0 " @ %xRot;
	%pos = Vector::add($los::position, "0 0 0.5"); 
	%hut = newObject("","InteriorShape","eround.dis",false);
	addToSet("MissionCleanup", %hut);
	GameBase::setTeam(%hut,GameBase::getTeam(%player));
	GameBase::setPosition(%hut,%pos);
	GameBase::setRotation(%hut,%rot);
	Gamebase::setMapName(%hut,"Sniper Hut" @ Client::getName(%client));
	Client::sendMessage(%client,0,"Sniper Hut deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "SniperHut"]++;
	echo("MSG: ",%client," deployed a sniper hut");
	return true;
	}	
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
	}
	else 
	Client::sendMessage(%client,0,"Can only deploy on terrain");
	}
	else 
	Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
	}
//==============================================================================================================
//====================================================================================== Springboard ===========
//==============================================================================================================

ItemImageData SpringPackImage 
	{
 	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false; 
	}; 

ItemData SpringPack 
	{ 
	description = "Springboard"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = "hDeployable Base Objects"; 
	imageType = SpringPackImage; 
	shadowDetailMask = 4; 
	mass = 1.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function SpringPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)  
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else  
	Player::deployItem(%player,%item);  
	} 

function SpringPack::onDeploy(%player,%item,%pos) 
	{ 
	if (SpringPack::deployShape(%player,%item))  
	Player::decItemCount(%player,%item);  
	} 

function SpringPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%phase = newObject("","StaticShape",DeployableSpring,true); 
	addToSet("MissionCleanup", %phase); 
	GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
	GameBase::setPosition(%phase,$los::position); 
	GameBase::setRotation(%phase,%rot); 
	Gamebase::setMapName(%phase,"Springboard " @ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Springboard Deployed"); 
	GameBase::startFadeIn(%phase); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "SpringPack"]++;
	echo("MSG: ",%client," deployed a Spring Board");  
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	}
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	}    
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//==============================================================================================================
//========================================================================================= Teleport ===========
//==============================================================================================================

ItemImageData TeleportPackImage 
	{ 
	shapeFile = "flagstand"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.1 }; 
	mountRotation = { 1.57, 0, 0 }; 
	firstPerson = false; 
	}; 

ItemData TeleportPack 
	{ 
	description = "Teleport Pad"; 
	shapeFile = "flagstand"; 
	className = "Backpack"; 
	heading = "hDeployable Base Objects"; 
	imageType = TeleportPackImage; 
	shadowDetailMask = 4; 
	mass = 5.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function TeleportPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else  
	Player::deployItem(%player,%item);  
	} 

function TeleportPack::onDeploy(%player,%item,%pos) 
	{ 
	if (teleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item)) 
	{ 
	Player::decItemCount(%player,%item); 
	$TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"]++; 
	} 
	} 

function CreateteleportSimSet() 
	{ 
	%teleset = nameToID("MissionCleanup/Teleports"); 
	if(%teleset == -1) 
	{ 
	newObject("Teleports",SimSet); 
	addToSet("MissionCleanup","Teleports"); 
	} 
	} 

function TeleportPack::deployShape(%player,%name,%shape,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] < $TeamItemMax[DeployableTeleport]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%sensor = newObject("Teleport Pad","StaticShape",%shape,true); 
	CreateteleportSimSet(); 
	addToSet("MissionCleanup/Teleports", %sensor); 
	addToSet("MissionCleanup", %sensor); 
	GameBase::setTeam(%sensor,GameBase::getTeam(%player)); 
	%pos = Vector::add($los::position,"0 0 -0.35"); 
	echo("LOS pos " @ $los::position @ " " @ %pos); 
	GameBase::setPosition(%sensor,%pos); 
	Gamebase::setMapName(%sensor,%name); 
	Client::sendMessage(%client,0,%item.description @ " deployed"); 
	%sensor.disabled = false; 
	playSound(SoundPickupBackpack,$los::position); 
	%beam = newObject("","StaticShape",ElectricalBeamBig,true); 
	addToSet("MissionCleanup", %beam); 
	GameBase::setTeam(%beam,GameBase::getTeam(%player)); 
	GameBase::setPosition(%beam,%pos); 
	%sensor.beam1 = %beam; 
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s"); 
	return false; 
	}

//==============================================================================================================
//============================================================================================ Trees ===========
//==============================================================================================================

ItemImageData TreePackImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData TreePack 
	{ 
	description = "Tree"; 
	shapeFile = "tree1"; 
	className = "Backpack"; 
	heading = "hDeployable Base Objects"; 
	imageType = TreePackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	};
 
function TreePack::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else
	{
	if (Vector::GetDistance(%deplpos,%teamposa) < 100 || Vector::GetDistance(%deplpos,%teamposb) < 100 )
	{
	Client::sendMessage(%client,0,"You are too close to the base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else
	Player::deployItem(%player,%item);
	}
	}
 
function TreePack::onDeploy(%player,%item,%pos) 
	{ 
	if (TreePack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function TreePack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%rnd = floor(getRandom() * 10); 
	if(%rnd > 5) 
	%phase = newObject("","StaticShape",DeployableTree,true); 
	else 
	%phase = newObject("","StaticShape",DeployableTree2,true); 
	addToSet("MissionCleanup", %phase); 
	GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
	GameBase::setPosition(%phase,$los::position); 
	GameBase::setRotation(%phase,%rot); 
	Gamebase::setMapName(%phase,"Mechanical Tree "@ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Mechanical Tree Deployed"); 
	GameBase::startFadeIn(%phase); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "TreePack"]++;
	echo("MSG: ",%client," deployed a Tree");  
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces."); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players."); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range."); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s."); 
	return false; 
	} 
//=================================================================================================
//=================================== New RaMpAgE v1.6 ============================================
//=================================================================================================
function deployShape(%player,%item,%name,%losDeployDist,%objectType,%object,%deploySlant,%bTerrain,%bInteriorShape,%bBlastFloor)
{
	if($TeamItemCount[GameBase::getTeam(%player) @ %object] < $TeamItemMax[%object]) 
	{
		if(GameBase::getLOSInfo(%player,%losDeployDist)) 
		{
			if((%bTerrain && getObjectType($los::object) == "SimTerrain") || (%bInteriorShape && getObjectType($los::object) == "InteriorShape") || (%bBlastFloor && getObjectType($los::object) == "StaticShape"))
			{
				if(Vector::dot($los::normal,"0 0 1") > %deploySlant) 
				{
					if(checkDeployArea(%client,$los::position)) 
					{
						%deploy = newObject(%name,%objectType,%object,true);
						addToSet("MissionCleanup", %deploy);
						GameBase::setTeam(%deploy,GameBase::getTeam(%player));
						GameBase::setPosition(%deploy,$los::position);
						GameBase::setRotation(%deploy,GameBase::getRotation(%player));
						Gamebase::setMapName(%deploy,%name);
						Client::sendMessage(Player::getClient(%player),0, %item.description @" deployed.");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%this) @ %object]++;
						echo("MSG: ",getName(%player)," deployed ",%item);
						return true;
					}
				}
				else 
					Client::sendMessage(Player::getClient(%player),0,"Cannot deploy here");
			}
			else 
				Client::sendMessage(Player::getClient(%player),0,"Cannot deploy here");
		}
		else 
			Client::sendMessage(Player::getClient(%player),0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(Player::getClient(%player),0,"Deployable limit reached for " @ %item.description @ "s");

	return false;
}

//-----------------------------------------------------------------------------------------------------------
//					AAOD Deployables File
//___________________________________________________________________________________________________________
//	Contains all the Deployable related functions as well as the generic 
//	Deployable Routines......
//-----------------------------------------------------------------------------------------------------------

$boostStr	= 0.17;

function PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName)
{	if($trace) echo( $ver@"|Pack up Stuff");
	if(%this.isbusy)
	{	Client::sendMessage(%client,0,"Unable to Pack up - Unit is Busy performing some function!~wError_message.wav");
		return(false);
	}

	if(%this.ShieldNode)
	{	Client::sendMessage(%client,0,"Unable to Pack up - Unit has an Attached Shield Node.| Pack Shield Node up First!~wError_message.wav");
		return(false);
	}

	%name = Client::getName(%client);
	%team = Client::getTeam(%client);
	%pack=Player::getMountedItem(%player,$BackpackSlot);
	if (%nopack==true)	// If Client must not have a pack on to pack up
		if(%pack!=-1)	// then check to see if he has a pack
		{	Client::sendMessage(%client,0,"Unable to Pack up - You are wearing a Pack!~wError_message.wav");
			return(false);		// if he does return without packing up
		}

	if(%armor!="")
	{	%parmor = Player::getArmor(%client);
		%parm=String::getSubStr(%parmor, 0, 1);
		%num=String::findSubStr(%armor, %parm);	//	Is the Armor Type the player is wearing in the list of acceptable armor types
		if (%num==-1)
		{	Client::sendMessage(%client,0,"Unable to Pack up - You are not wearing the compatable armor!~wError_message.wav");
			return(false);		// if he is not wearing right armor return without packing up
		}
			
	}
			
	if(GameBase::getDamageLevel(%this)!=0)				// Item is Damaged so dont Pack it up
	{	Client::sendMessage(%client,0,"Unable to Pack up "@%desc@". It Requires Repair!~wError_message.wav");	
		return(false);
	}
	else
	{	GameBase::stopSequence(%this,0);
		GameBase::setSequenceDirection(%this,1,0);
		GameBase::playSequence(%this,1,"deploy");
		if(%this.pset)	//	Is This a power generator???
		{	GameBase::virtual(%this,"Disabled");
			%player.isDeploying = true;
			%pos=vector::add(Gamebase::getPosition(%this),"0 0 0.5");
			%td=DisconnectGenerator(%this)+1;	// Dis-connect it from the grid
			removeFromSet($GenSet[%team],%this);
			schedule("GameBase::startFadeOut("@%this@");",%td,%this);
			schedule("deleteObject(" @ %this @ ");",(%td+1),%this);
			schedule("PlaceItemPack(" @ %player @ "," @ %pName @ ",\"" @ %pos @ "\");",(%td+1.15),%player);		
			return(true);
		}
		else
		{	%player.isDeploying = true;
			%pos=vector::add(Gamebase::getPosition(%this),"0 0 0.5");
			GameBase::startFadeOut(%this);
			schedule("deleteObject(" @ %this @ ");",1.0,%this);
			schedule("PlaceItemPack(" @ %player @ "," @ %pName @ ",\"" @ %pos @ "\");",1.15,%player);		
			return(true);
		}
		echo(">INF: ",$User[%client]," Packed up a "@%desc);
	}
}

function DeployTheShape(%player, %item, %turret, %objects, %flagdist, %flatonly, %MaxLength, %MaxWidth, %MaxHeight, %MinLength, %MinWidth, %MinHeight, %number, %msg) {
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%playerTeam = GameBase::getTeam(%player);
			if(Vector::getDistance(GameBase::getPosition($teamFlag[%playerTeam]), $los::position) < %flagdist) {
				Client::sendMessage(%client,0,"You are too close to your flag~waccess_denied.wav");
				return false;
			}
			%obj = getObjectType($los::object);
			if (%obj != "SimTerrain" && %obj != "InteriorShape" && GameBase::getDataName($los::object) != "AirAmmoBasePad") {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
				return false;
			}
			if(!checkDeployArea(%client, $los::position)) return false;
			%set = newObject("set",SimSet); 
			%num = containerBoxFillSet(%set, $StaticObjectType, $los::position, 32, 32, 17, 0); 
			%num = CountThes(%set, %num);
			deleteObject(%set); 
			if(%num > 4) {
				Client::sendMessage(%client,0,"Sensor Interference - Too many turrets in the area");
				return false;
			}			
			%set = newObject("set",SimSet); 
			%numinset = containerBoxFillSet(%set, $StaticObjectType, $los::position, %MaxLength, %MaxWidth, %MaxHeight, 0); 
			%num = CountObjects(%set, %turret, %numinset);
			%object = getword(%objects, 0);
			for(%i = 1; %object != -1; %i++) {
				%num = %num + CountObjects(%set, %object, %numinset);
				%object = getword(%objects, %i);
			}
			deleteObject(%set); 
			if(%num < $MaxNumTurretsInBox) { 
				%set = newObject("set",SimSet); 
				%numinset = containerBoxFillSet(%set, $StaticObjectType, $los::position, %MinLength, %MinWidth, %MinHeight, 0); 
				%num = CountObjects(%set, %turret, %numinset);
				%object = getword(%objects, 0);
				for(%i = 1; %object != -1; %i++) {
					%num = %num + CountObjects(%set, %object, %numinset);
					%object = getword(%objects, %i);
				}
				deleteObject(%set); 
				if(%num == 0) {
					%rot = GameBase::getRotation(%player);
					if (%flatonly) {
						if (Vector::dot($los::normal, "0 0 1") <= 0.7) {
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
							return false;
						}
					} else {
						%zRot = getWord(%rot, 2);
						if (Vector::dot($los::normal, "0 0 1") > 0.6) {
							%rot = "0 0 " @ %zRot;
						} else {
							if (Vector::dot($los::normal, "0 0 -1") > 0.6) {
								%rot = "3.14159 0 " @ %zRot;
							} else {
								%rot = Vector::getRotation($los::normal);
							}
						}
					}
					if(%number != "") {
						%number++;
						%number = " #" @ %number;
					}
					%turret = newObject("", "Turret", %turret, true);
					addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret, %playerTeam);
					GameBase::setRotation(%turret, %rot);
					GameBase::startFadeIn(%turret);
					GameBase::setPosition(%turret, $los::position);
					%turret.ownerName = Client::getName(%client); 
					dotog(%player);
					Gamebase::setMapName(%turret, %item.description @ %number @ " " @ %turret.ownerName);
					Client::sendMessage(%client, 0, %item.description @ %number @ " deployed");
					echo("MSG: ",%client," ",%turret.ownerName," deployed ",%item.description,%number); 
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[%playerTeam @ %item]++;
					%client.hasDeployed = true;
					doset(%client, %player, %turret);
					return %turret;
				} else
					Client::sendMessage(%client,0,"Frequency Overload - Too close to another " @ %msg @ " Turret"); 
			} else
				Client::sendMessage(%client,0,"Interference from other " @ %msg @ " Turrets in the area");
		} else
			Client::sendMessage(%client,0,"Deploy position out of range");
	} else																						  
	 	Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s");
	return false;
}

function DeployAnyShape(%player, %item, %cat, %name, %flatonly, %deployon) {
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%playerTeam = GameBase::getTeam(%player);
			if(Vector::getDistance(GameBase::getPosition($teamFlag[%playerTeam]), $los::position) < 1) {
				Client::sendMessage(%client,0,"You are too close to your flag~waccess_denied.wav");
				return false;
			}
			%obj = getObjectType($los::object);
			if(%deployon == 1) {
				if (%obj != "SimTerrain" && %obj != "InteriorShape" && GameBase::getDataName($los::object) != "AirAmmoBasePad") {
					Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
					return false;
				}
			} else if(%deployon == 2) {
				if (%obj != "SimTerrain") {
					Client::sendMessage(%client,0,"Can only deploy on terrain");
					return false;
				}
			}
			if(!checkDeployArea(%client, $los::position)) return false;
			%rot = GameBase::getRotation(%player);
			if (%flatonly) {
				if (Vector::dot($los::normal, "0 0 1") <= 0.7) {
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					return false;
				}
			} else {
				%zRot = getWord(%rot, 2);
				if (Vector::dot($los::normal, "0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				} else {
					if (Vector::dot($los::normal, "0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					} else {
						%rot = Vector::getRotation($los::normal);
					}
				}
			}
			%turret = newObject("", %cat, %name, true);
			addToSet("MissionCleanup", %turret);
			GameBase::setTeam(%turret, %playerTeam);
			GameBase::setRotation(%turret, %rot);
			GameBase::startFadeIn(%turret);
			GameBase::setPosition(%turret, $los::position);
			%turret.ownerName = Client::getName(%client); 
			dotog(%player);
			Gamebase::setMapName(%turret, %item.description);
			Client::sendMessage(%client, 0, %item.description @ " deployed");
			echo("MSG: ",%client," ",%turret.ownerName," deployed ",%item.description); 
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[%playerTeam @ %item]++;
			%client.hasDeployed = true;
			doset(%client, %player, %turret);
			return %turret;
		} else
			Client::sendMessage(%client,0,"Deploy position out of range");
	} else																						  
	 	Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s");
	return false;
}

function CheckObjectType(%object,%type)
{	//if($traceDep) Echo("Checking: Is deployable placement on ",%object," valid for type: ",%type);

	if (%type==0)		// **** Can be PLaced on Terrain Only
	{	if (%object=="SimTerrain")
			return(true);
	}
	else if (%type==1)	// **** Can Be Placed on Terrain & Buildings
	{	if (%object=="SimTerrain" || %object=="InteriorShape")
			return(true);
	}	
	else if (%type==2)	// **** Can Be Placed on Terrain, Buildings & Some objects
	{	if ((%object=="SimTerrain" || %object=="InteriorShape" ) || (%object=="Turret" || %object=="sensor"))
			return(true);
	}
	else if(%type==3)	// **** Can Be Placed on Buildings & Terrain but Must be Outside
	{	if (%object=="SimTerrain" || %object=="InteriorShape")
		{	%num=0;
			%setx = newObject("set",SimSet);
			%pos1=$los::position;
			%pos=Vector::Add(%pos1,"0 0 30");
			%num = containerBoxFillSet(%setx,$SimInteriorObjectType,%pos,1,1,50,0);
			deleteObject(%setx);
			if(!%num)			
				return(true);
		}
	}
	return(false);
}

function DeployStuff(%player,%item,%shape,%pType,%dist,%cType,%dtype,%DonD,%Power,%pRange)
{	
	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	// %ptype = 0 for SimTerrain only
	// %ptype = 1 for SimTerrain or Interior Shapes
	// %ptype = 2 for SimTerrain or Interior Shapes or Objects
	// %ptype = 3 Outside clear sky above....(is this possible - The answer being yes!!!)
	// %dist is the max deploy distance
	// %ctype = 0	Use Defaults for Interference Checking
	// %ctype = 1	Turret Use Turret Box Values for checking interference
	// %ctype = 2	Forcefield Use Forcefield Values for Interference checking
	// %dtype = true or false	(True means it can be placed on any surface)
	// %shape = Shape Name (String) The Name of the DATA Block for this shape
	// %shape = Shape
	// %DonD  = Delete on Destroy True or False
	// %tname = Name of Type items
	// %power = 0= Item has No special Power Needs|1=Item Requires Power|2=Item generates Power 
	//			   (Item which requires Power will have an %item.prange var for how far it can look for power)
	
	%descr=%item.description;
		
	if(%ptype==0)
		%pDesc="Terrain";
	else if(%ptype==1)
		%pDesc="Terrain & Buildings";
	else if(%ptype==2)
		%pDesc="Terrain, Buildings & Objects";
	else if(%ptype==3)
		%pDesc="Terrain & Buildings but MUST be Outside";
	else if(%ptype==4)
		%pDesc="Terrain";

			
	if (%ctype==1)
	{	%BxMxL=$TurretBoxMaxLength;
		%BxMnL=$TurretBoxMinLength;
		%BxMxW=$TurretBoxMaxWidth;
		%BxMnW=$TurretBoxMinWidth;
		%BxMxH=$TurretBoxMaxHeight;
		%BxMnH=$TurretBoxMinHeight;
		%MaxNum=$MaxNumTurretsInBox;
		%class="Turret";
		%tname="deployable Turrets";
	}
	else if (%ctype==2)
	{	%BxMxL=$FFBxMxLength;
		%BxMnL=$FFBxMnLength;
		%BxMxW=$FFBxMxWidth;
		%BxMnW=$FFBxMnWidth;
		%BxMxH=$FFBxMxHeight;
		%BxMnH=$FFBxMnHeight;
		%MaxNum=$MaxNumFieldsInBox;
		%class="StaticShape";
		%tname="Deployable Forcefields";
	}
	else if (%ctype==4)	// Nodes
	{	%BxMxL=10;
		%BxMnL=1;
		%BxMxW=10;
		%BxMnW=1;
		%BxMxH=10;
		%BxMnH=1;
		%MaxNum=2;
		%class="StaticShape";
	}
	else
	{	%BxMxL=2;
		%BxMnL=1;
		%BxMxW=2;
		%BxMnW=1;
		%BxMxH=2;
		%BxMnH=1;
		%MaxNum=1;
		%class="StaticShape";
	}
	
	%team=GameBase::getTeam(%player);
	%client = Player::getClient(%player);
	if($TeamItemCount[ %team @ %item] < $TeamItemMax[%item])	// Check to see if Item Count has been Reached
	{	%thisnum=$TeamItemCount[%team @ %item]+1;
		if (GameBase::getLOSInfo(%player,%dist)) 
		{	%obj = getObjectType($los::object);
			if(CheckObjectType(%obj,%ptype))
			{	%set = newObject("set",SimSet);
				%tnum = containerBoxFillSet(%set,$StaticObjectType,$los::position,%BxMxL,%BxMxW,%BxMxH,0);
				%num = GetNumObjects(%set,%ctype,%tnum);
				deleteObject(%set);
				if(%MaxNum > %num) 
				{	%set = newObject("set",SimSet);
					%tnum = containerBoxFillSet(%set,$StaticObjectType,$los::position,%BxMnL,%BxMnW,%BxMnH,0);
					%num = GetNumObjects(%set,%ctype,%tnum);
					if(0 == %num)	// No Objects within the Minimum Box
					{	if(%dtype==1)	//	If Deployable on Any Surface
						{	// Try to stick it straight up or down, otherwise
							// just use the surface normal
							%prot = GameBase::getRotation(%player);
							//if($trace) echo("Player Rotation ",%prot);
							//%zRot = (3.141592654-getWord(%prot,2));
							//if($trace) echo("Player Rotation ",%zrot);
							%zRot = (getWord(%prot,2));

							if (Vector::dot($los::normal,"0 0 1") > 0.6) 
							{	%rot = "0 0 " @ %zRot;}
							else
							{	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
								{	%rot = "3.14159 0 " @ %zRot;}
								else
								{	%rot = Vector::getRotation($los::normal);}
							}
						}
						else if(%dtype==2)	//	Matches Any Surface
						{	%rot = Vector::getRotation($los::normal);
							
						}
						else
						{	if (Vector::dot($los::normal,"0 0 1") <= 0.7)
							{	Client::sendMessage(%client,0,%desc@" Can only deploy on flat surfaces~werror_message.wav");
								return (false);
							}
							%rot = GameBase::getRotation(%player);
						}	
							
						if(checkDeployArea(%client,$los::position)) 
						{	%newitem = newObject(%shape,%class,%shape,%DonD);
							if($traceObj) Echo($Ver,"|Created New Object :",%newitem," ",%descr);
							GameBase::playSequence(%newitem,1,"deploy");
							GameBase::SetActive(%newItem,false);
							%newitem.faded=1;
							addToSet("MissionCleanup", %newitem);
							GameBase::setTeam(%newitem,%team);
							GameBase::setPosition(%newitem,$los::position);
							GameBase::setRotation(%newitem,%rot);
							Gamebase::setMapName(%newitem,%descr @" #" @ %thisnum @ " " @ Client::getName(%client));
							Client::sendMessage(%client,0,%descr @" deployed");
							playSound(SoundCreateItem,$los::position);
							$TeamItemCount[%team @ %item]++;
							
							%newitem.deployedBy	= %client;
							%newitem.powerReq	= %power;
							%newitem.pRange		= %pRange;

							if(%power==1)	// Item Requires Power
							{	if($TracePwr) echo(%newitem," requires Power!");
								Client::sendMessage(%client,1,"Attempting to connect to Main Power Grid~AAODSFX13.WAV");
								schedule("PowerItem("@%newitem@","@%pRange@","@%client@");",2,%newitem);
							}
							else if(%power==2)	// Item generates Power
							{	if($TracePwr) echo(%newitem,"	Power Generator!");
								GameBase::SetActive(%newItem,true);
								Client::sendMessage(%client,1,"Attempting to connect Generator to Main Grid~AAODSFX13.WAV");
								schedule("ConnectGenerator("@%newitem@","@%client@");",2,%newitem);
								if($GenSet[%team])
								{	addToSet($GenSet[%team],%newItem);
								}
								else
								{	$GenSet[%team]=newObject("set",SimSet);
									addToSet("MissionCleanup",$GenSet[%team]);
									addToSet($GenSet[%team],%newItem);
								}
							}
							else
								GameBase::SetActive(%newItem,true);

							echo(">INF: ",$User[%client]," deployed a "@ %descr);
							return (%newitem);
						}
					}
					else Client::sendMessage(%client,0,"Frequency Overload - Too close to other "@%tname);
				}
				else Client::sendMessage(%client,0,"Too Many Other "@%tname@" in the area");
			}
			else Client::sendMessage(%client,0,%descr@" can only be deployed "@%pDesc@"~wAAODSFX09.WAV");
		}
		else Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %descr);
	return (false);
}
//=============================================================================================
//======================================= New Deps ============================================
//=============================================================================================
//=============================================================================================
//***********************************
// AAOD Mobile Inventory Pack
//***********************************

$InvList[AODMobileInv]        = 1;
$RemoteInvList[AODMobileInv] = 0;
$TeamItemMax[AODMobileInv]        = 2;

$ItemMax[aarmor, AODMobileInv]        = 1;



ItemImageData AODMobileInvImage
{        shapeFile        = "MagCargo";
        mountPoint        = 2;
        mountOffset = { 0, -0.65, -0.4 };
        mass                        = 5.0;
        firstPerson = false;
};

ItemData AODMobileInv
{        description                = "Mobile Inventory";
        shapeFile                = "inventory_sta";
        classname                = "Backpack";
        heading                        = "hDeployable Base Objects";
        imageType                = AODMobileInvImage;
        shadowDetailMask = 4;
        elasticity                = 0.2;
        price                        = 420;
        hudIcon                        = "deployable";
        showWeaponBar        = true;
        hiliteOnActive        = true;
};

StaticShapeData MobileInvent
{  description                = "Mobile Supply Unit";
        shapeFile                = "inventory_sta";
        classname                = "station";
        visibleToSensor = true;
        sequenceSound[0] = { "activate", SoundActivateInventoryStation };
        sequenceSound[1] = { "power", SoundInventoryStationPower };
        sequenceSound[2] = { "use", SoundUseInventoryStation };
        maxDamage                = 1.5;
        debrisId                = flashDebrisLarge;
        mapFilter                = 4;
        mapIcon                        = "M_station";
        damageSkinData        = "objectDamageSkins";
        shadowDetailMask = 16;
        triggerRadius        = 1.5;
        explosionId                = flashExpLarge;
        shieldShapeName = "shield";

};


function AODMobileInv::onUse(%player,%item)
{        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {        Player::mountItem(%player,%item,$BackpackSlot);}
    else
        {        Player::deployItem(%player,%item);}
}

function AODMobileInv::onDeploy(%player,%item,%pos)
{        if (AODMobileInv::deployShape(%player,%item))
        {        Player::decItemCount(%player,%item);

        }
}

function AODMobileInv::deployShape(%player,%item)
{        //        Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
        DeployStuff(%player,%item,MobileInvent,1,5,0,0,true,1,200);

}


function MobileInvent::onEndSequence(%this,%thread)
{
        if (Station::onEndSequence(%this,%thread))
                InventoryStation::onResupply(%this,"InvList");
}
//=============================================================================================
//-------------------------------
// ******* Mobile Generator *****
//-------------------------------
$TeamItemMax[AODMobileGen]		= 2;
$InvList[AODMobileGen]		= 1;
$RemoteInvList[AODMobileGen]	= 0;

$ItemMax[aarmor, AODMobileGen]		= 1;



ItemImageData AODMobileGenImage 
{	shapeFile	= "generator_p";
	mountPoint	= 2;
	mountOffset = { 0, -0.65, -0.4 };
	mas			= 5.0;
	firstPerson = false;
};


ItemData AODMobileGen
{	description		= "Portable Generator";
	shapeFile		= "generator_p";
	classname		= "Backpack";
	heading			= "hDeployable Base Objects";
	imageType		= AODMobileGenImage;
	shadowDetailMask = 4;
	mass			= 4.5;
	elasticity		= 0.2;
	price			= 420;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

StaticShapeData MobileGen 
{	description		= "Portable Generator";
	shapeFile		= "generator_p";
	classname		= "pGen";
	debrisId		= flashDebrisSmall;
	sfxAmbient		= SoundGeneratorPower;
	maxDamage		= 1.8;
	mapIcon			= "M_generator";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId		= flashExpMedium;
	visibleToSensor = true;
	mapFilter		= 4;
	shieldShapeName = "shield";
		
};


function AODMobileGen::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {	Player::mountItem(%player,%item,$BackpackSlot);}
    else
	{	Player::deployItem(%player,%item);}
}

function AODMobileGen::onDeploy(%player,%item,%pos)
{	if (AODMobileGen::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);
		
	}
}

function AODMobileGen::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	DeployStuff(%player,%item,MobileGen,1,5,0,0,false,2,350);
	
}

function MobileGen::onAdd(%this)
{}

function MobileGen::onDestroyed(%this)
{	if($trace) echo($ver,"| MobileGen::onDestroyed");
	MobileGen::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
}

function MobileGen::onEnabled(%this)
{	if($trace) echo($ver,"| MobileGen::onEnabled ",%this);
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
	GameBase::isPowerGenerator(%this);
}

function MobileGen::onDisabled(%this)
{	if($trace) echo($ver,"| MobileGen::onDisabled ",%this);
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
}
//===============================================================================================
//---------------------------------
// ******* Shield Generator *******
//---------------------------------
//  	Shield Power Functions
// --------------------------------
$InvList[AODShieldGen]		= 1;
$RemoteInvList[AODShieldGen]	= 0;
$TeamItemMax[AODShieldGen]		= 2;

$ItemMax[aarmor, AODShieldGen]		= 1;



ItemImageData AODShieldGenImage 
{	shapeFile		= "MagCargo";
	mountPoint		= 2;
	mountOffset		= { 0, -0.65, -0.4 };
	mountRotation	= { 0, 0, 0 };
	mass			= 5.0;
	firstPerson		= false;
};


ItemData AODShieldGen
{	description		= "Shield Generator";
	shapeFile		= "generator_p";
	classname		= "Backpack";
	heading			= "hDeployable Base Objects";
	imageType		= AODShieldGenImage;
	shadowDetailMask = 4;
	elasticity		= 0.2;
	price			= 420;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

StaticShapeData ShieldGen 
{	description			= "Shield Generator";
	shapeFile			= "generator_p";
	classname			= "ShieldGen";
	debrisId			= flashDebrisLarge;
	maxDamage			= 1.8;
	mapIcon				= "M_generator";
	damageSkinData		= "objectDamageSkins";

shadowDetailMask	= 16;
	explosionId			= LargeShockWave;
	visibleToSensor		= true;
	mapFilter			= 4;
	shieldShapeName		= "shield";
	sequenceSound[0] = { "power", SoundShieldGenerator };
};

function AODShieldGen::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {	Player::mountItem(%player,%item,$BackpackSlot);}
    else
	{	Player::deployItem(%player,%item);}
}

function AODShieldGen::onDeploy(%player,%item,%pos)
{	if (AODShieldGen::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);
		
	}
}

function AODShieldGen::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	%gen=DeployStuff(%player,%item,ShieldGen,1,5,0,0,false,1,196);
	if(%gen)
	{	%team=GameBase::getTeam(%player);
		$ShieldGen[%team]=%gen;
		$ShieldGenOn[%team]=true;
		if($trace) echo( $ver@"|NodeSet for this team is ",$NodeSet[%team]);
		if(!$NodeSet[%team])
		{	if($trace) echo( $ver@"|Creating a Node Set for Team ",%team);
			$NodeSet[%team] = newObject("ShieldNodes",SimSet);
			addToSet("MissionCleanup", $NodeSet[%team]);
		}

	}
}

function ShieldGen::onAdd(%this)
{}

function ShieldGen::onEnabled(%this)
{	if($trace) echo( $ver@"|Shield Gen OnEnabled");
	%team=GameBase::getTeam(%this);
	if(%this.destroyed==true)
	{	// Was destroyed but is no longer - Has been repaired
		%this.destroyed=false;
	}
	if(GameBase::isPowered(%this))
	{	GameBase::playSequence(%this,0,"power");
		if (%team!=-1)
		{	$ShieldGenOn[%team]=true;
			ActivateNodes(true,%team);
		}
	}
}

function ShieldGen::onDestroyed(%this)
{	if($trace) echo( $ver@"|ShieldGen::onDestroyed");
	%team=GameBase::getTeam(%this);
	if($ShieldGenOn[%team])
		ShieldGen::onDisabled(%this);

	$ShieldGen[%team]=false;
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 8.5, 0.10, 55, 23, 3, 1.5, 1.0, 250, 170); 
}

function ShieldGen::onDisabled(%this)
{	if($trace) echo( $ver@"|ShieldGen::onDisabled");
	%team=GameBase::getTeam(%this);
	GameBase::stopSequence(%this,0);
 	$ShieldGenOn[%team]=false;
	ActivateNodes(false,%team);
}

function ShieldGen::onPower(%this, %state, %generator)
{	if($trace) echo($ver,"|ShieldGen::onPower this|state|generator ",%this,%state,%generator);
	if(%state)
		ShieldGen::OnEnabled(%this);
	else
		ShieldGen::OnDisabled(%this);
}



function ActivateNodes(%status,%team)
{	if($trace) echo( $ver@"|Activate Shield Nodes for Team ",%team);
	%num=$TeamItemCount[%team @ AODShieldNode];
	if (%num>0)
	{	for(%i=0;%i<%num;%i++)
		{	%node=Group::GetObject($NodeSet[%team],%i);
			if($trace) echo( $ver@"|Node ID is:",%node);
			if (%status==true)
			{	if($trace) echo( $ver@"|Activating Node :",%i);
				if($trace) echo( $ver@"|Node ID = ",%node);
				RemoteShieldNode::onActivate(%node);}
			else
			{	if($trace) echo( $ver@"|DeActivating Node :",%i);
				if($trace) echo( $ver@"|Node ID = ",%node);
				RemoteShieldNode::onDeActivate(%node);}
		}
	}
	else
		if($trace) echo( $ver@"|No Nodes to Activate");
}
//=========================================================================
$InvList[DShieldPack]		= 1;
$RemoteInvList[DShieldPack]	= 0;
$TeamItemMax[DShield]		= 2;

$ItemMax[aarmor, DShieldPack]		= 1;



$DShield::MaxCapCharge=4.0;
$DShield::TimerTick=0.25;
$DShield::ShieldEnhance=0.05;
$DShield::ProtectArea=150; 
$DShield::OverlapValue=0; 

StaticShapeData DShield
{
	description = "Power Core";
	className = "DShield";
	damageSkinData = "objectDamageSkins";
	shapeFile = "bridge"; 
	maxDamage = 1.4;
	maxEnergy = 500;
	sfxAmbient = SoundGeneratorPower;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = LargeShockwave;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	mass=2.5;
	shieldShapeName = "shield";
};

ItemImageData DShieldPackImage
{
	shapeFile = "bridge"; 
	mountPoint = 2;
	mountOffset = { 0, -0.5, -1 }; 
	mountRotation = { 0.2, 0, 0 }; 
	firstPerson = false;
};

ItemData DShieldPack
{
	description = "Power Core";
	shapeFile = "bridge"; 
	className = "Backpack";
	heading = "hDeployable Base Objects"; 
	imageType = "DShieldPackImage";
	sequenceSound[0] = { "power", SoundSensorPower };
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DShieldPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "<f2>Power Core:\n<f3>The Power Core Is Use For A Few Reasons\n<f2>1.<f1>The Power Core Boosts Team Members Energy Supply.\n<f2>2.<f1>The Power Core Also Boost Team Members & Team Items Shield Strenth By 8%.\n<f2>3.<f1>The Power Core Also Is A Cloaking Device.");
}

function CheckDeployTerrain (%this) 
{
	%obj=getObjectType(%this);
	if( %obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName(%this) == "DeployableBaseOps" || GameBase::getDataName(%this)=="BlastFloorShape") 
	{
		return 1;
	}
	return 0;
}

function ZTekDebug() 
{
	%DebugClient=2049;
	%DebugObject=Client::getOwnedObject(2049);
	echo("Player Data:");
	echo("Client: 2049");
	echo("Player Object:"@%DebugObject);
	echo("Shields: "@%DebugObject.shieldStrength);
}

function DShield::onDestroyed(%this)
{
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);
	$TeamItemCount[GameBase::getTeam(%this) @ "DShield"]--;
	%teleset = nameToID("MissionCleanup/Teleports");
	if ($functioning[%this]==1)
	{
		GameBase::stopSequence(%this,0);
		%pos=GameBase::getPosition(%this);
		echo("shield disabled");
		for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		{
			%matrix = %clientId @ %this;
			%obj = Client::getOwnedObject(%clientId);
			if (!$oldShieldGen[%matrix]) $oldShieldGen[%matrix] = 0;
			%clientpos=gamebase::getPosition(%clientId);
			%dist = Vector::getDistance(%pos, %clientpos);
			if(!Player::isDead(%obj) && GameBase::GetTeam(%clientId) == GameBase::GetTeam(%this))
			{
				if ($oldShieldGen[%matrix] == 1)
				{
					%recharge=GameBase::getRechargerate(%obj)-15;
					if (%recharge > 7 || $empTime[%clientId] > 0)
					{
						GameBase::setRechargeRate(%obj, 8);
						client::sendMessage(%clientId,1,"WARNING: Power flux in Power Core ID#" @ %this @"!");
					}
					if(Player::getMountedItem(%obj,$BackpackSlot) == "shieldpack")
					{
						if(Player::isTriggered(%obj, $BackpackSlot) == true)
						{
						}
					}
					else %obj.shieldStrength = 0.0;
					$oldShieldGen[%matrix]=0;
				}
			}
		}	
	}
	$functioning[%this]=0;
}

function DShieldPack::onUse(%player,%item)
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

function DShieldPack::onDeploy(%player,%item,%pos)
{
	if (DShieldPack::deployShape(%player,"Shield Generator",DShield,%item)) 
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DShield"]++;
	}
}

function CreateDShieldSimSet(%this)
{
	%dset = nameToID("MissionCleanup/DShield");
	if(%dset == -1)
	{
		newObject("DShield",SimSet);
		addToSet("MissionCleanup","DShield");
	}
	%dset = nameToID("MissionCleanup/DShield/DShield"@%this);
	if(%dset == -1)
	{
		newObject("DShield"@%this,SimSet);
		addToSet("MissionCleanup/DShield","DShield"@%this);
	}
}

function DShieldPack::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "DShield"] < $TeamItemMax[DShield]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
			if (CheckDeployTerrain($los::object)) 
			{
				%set = newObject("set",SimSet);
				%ovr = ($DShield::ProtectArea-$DShield::OverlapValue)/2;
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,%ovr,%ovr,%ovr,0);
				%num = CountObjects(%set,"DShield",%num);
				deleteObject(%set);
				if(!%num) 
				{
					if (Vector::dot($los::normal,"0 0 1") > 0.7) 
					{
						if (checkenemybase($los::position,$los::object,%player) != true)
						{
							if(checkDeployArea(%client,$los::position)) 
							{
								%sensor = newObject("Enhancement Beacon","StaticShape",%shape,true);
								$TeamItemCount[GameBase::getTeam(%this) @ "DShield"]++;
								%team = GameBase::getTeam(%this);
								%index = $TeamItemCount[GameBase::getTeam(%this) @ "DShield"];
								$ShieldGen++;
								$ShieldGenObject[$ShieldGen]=%sensor;
								CreateDShieldSimSet(%sensor);
								addToSet("MissionCleanup/DShield", %sensor);
								addToSet("MissionCleanup", %sensor);
								GameBase::setTeam(%sensor,GameBase::getTeam(%player));
								%pos = Vector::add($los::position,"0 0 0");
								GameBase::setRotation(%sensor,GameBase::getRotation(%player));
								GameBase::setPosition(%sensor,%pos);
								Gamebase::setMapName(%sensor,%name);
								GameBase::setRechargeRate(%sensor,1);
								GameBase::setActive(%sensor,True);
								Client::sendMessage(%client,0,%item.description @ " deployed!");
								playSound(SoundPickupBackpack,$los::position);
								Client::sendMessage(%client,0,%item.description @ " initializing Grid.");
								schedule("DShield::checkAreaDfox("@%sensor@");",3, %sensor);
								return true;
							}
						}
						else 
						Client::sendMessage(%client,0,"Cannot deploy the Power Core on an enemy base.");
					}
					else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
				else
				Client::sendMessage(%client,0,"Too close to other Power Core");
			}
			else 
			Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}

function DShield::onEnabled(%this)
{
	DShield::setActive(%this,true);
}

function DShield::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
	%pos=GameBase::getPosition(%this);
	$functioning[%this]=0;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{
		%matrix = %clientId @ %this;
		if (!$oldShieldGen[%matrix]) $oldShieldGen[%matrix] = 0;
		%obj = Client::getOwnedObject(%clientId);
		%clientpos=gamebase::getPosition(%clientId);
		%dist = Vector::getDistance(%pos, %clientpos);
		if(!Player::isDead(%obj) && GameBase::GetTeam(%clientId) == GameBase::GetTeam(%this))
		{
			if ($oldShieldGen[%matrix] == 1)
			{
				%recharge=GameBase::getRechargerate(%obj)-15;
				if (%recharge > 7 || $empTime[%clientId] > 0)
				{
					GameBase::setRechargeRate(%obj, 8);
					client::sendMessage(%clientId,1,"WARNING:  Power flux failure in Power Core ID#" @ %this @"!");
				}
				if(Player::getMountedItem(%obj,$BackpackSlot) == "shieldpack")
				{
					if(Player::isTriggered(%obj, $BackpackSlot) == true)
					{
					}
				}
				else %obj.shieldStrength = 0.0;
				$oldShieldGen[%matrix]=0;
			}
		}
	}	
	GameBase::applyDamage(%objt1,$CrushDamageType,0.15,GameBase::getPosition(%objt1),"0 0 0","0 0 0",%this);
}

function DShield::onActivate(%this)
{
	GameBase::playSequence(%this,0,"power");
}

function DShield::setActive(%this)
{
	GameBase::playSequence(%this,0,"power");
}

function DShield::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
	echo("shield deactivated");
	playSound(SoundGeneratorPower,GameBase::getposition(%this));
}

function Dshield::CheckAreaDfox(%this)
{
	if(GameBase::getDamageState(%this) =="Enabled") 
	{
		$functioning[%this]=1;
		%pos=GameBase::getPosition(%this);
		for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		{
			%obj = Client::getOwnedObject(%clientId);
			%matrix = %clientId @ %this;
			if (!$oldShieldGen[%matrix]) $oldShieldGen[%matrix] = 0;
			%clientpos=gamebase::getPosition(%clientId);
			%dist = Vector::getDistance(%pos, %clientpos);
			if(!Player::isDead(%obj) && GameBase::GetTeam(%clientId) == GameBase::GetTeam(%this))
			{
				if (%dist<140)
				{
					if ($oldShieldGen[%matrix]==0)
					{
						GameBase::setRechargeRate(%obj, 16);
						client::sendMessage(%clientId,3,"Power Core #" @ %this @ " active and enhancing.");
//						if(%obj.shieldStrength < 0.012) 
						%obj.shieldStrength = 0.006;
						$oldShieldGen[%matrix]=1;
					}
				}
				else if($oldShieldGen[%matrix]==1)
				{
						GameBase::setRechargeRate(%obj, 8);
						client::sendMessage(%clientId,1,"Left Power Core #" @ %this @ "'s enhancing range. ");

					if(Player::getMountedItem(%obj,$BackpackSlot) == "shieldpack")
					{
						if(Player::isTriggered(%obj, $BackpackSlot) == true)
						{
						}
					}
					else %obj.shieldStrength = 0.0;
					$oldShieldGen[%matrix]=0;
				}
			}
		}
	}
	schedule("DShield::checkAreaDfox("@%this@");",1, %this);
}

$TeamItemMax[EpodV] = 1024;
//---------------------------------------------------------------------
// Barrier
//---------------------------------------------------------------------
//***********************************
// AAOD Mobile Bunker Pack
//***********************************
$InvList[AODBunker]                = 1;
$RemoteInvList[AODBunker]                = 0;
$TeamItemMax[AODBunker]                = 4;

$ItemMax[aarmor, AODBunker]                = 1;



ItemImageData AODBunkerImage
{        shapeFile = "MagCargo";
        mountPoint = 2;
        mountOffset = { 0, -0.65, -0.4 };
        mass = 1.0;
        firstPerson = false;

};

ItemData AODBunker
{        description                = "Riot Wall";
        shapeFile                = "MagCargo";
        classname                = "Backpack";
        heading                        = "hDeployable Base Objects";
        imageType                = AODBunkerImage;
        shadowDetailMask = 4;
        mass                        = 4.5;
        elasticity                = 0.2;
        price                        = 420;
        hudIcon                        = "deployable";
        showWeaponBar        = true;
        hiliteOnActive        = true;
};

StaticShapeData MobileBunker
{        className                = "AAODDep";
        shapeFile                = "NewDoor5";
        debrisId                = defaultDebrisSmall;
        maxDamage                = 35;
        visibleToSensor = true;
        isTranslucent        = true;
        description                = "Riot Wall";
        shieldShapeName = "shield";
};


function AODBunker::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {        Player::mountItem(%player,%item,$BackpackSlot);}
    else
        {        Player::deployItem(%player,%item);}
}

function AODBunker::onDeploy(%player,%item,%pos)
{        if (AODBunker::deployShape(%player,%item))
        {        Player::decItemCount(%player,%item);}
}

function AODBunker::deployShape(%player,%item)
{        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {        if (GameBase::getLOSInfo(%player,5))
                {        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || GameBase::getDataName($los::object) == "BlastFloorShape")
                        {        %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,20,15,15,0);
                                deleteObject(%set);
                                if(0 == %num)
                                {        if (Vector::dot($los::normal,"0 0 1") > 0.7)
                                        {                %rot = GameBase::getRotation(%player);
                                                        %team=GameBase::getteam(%player);
                                                        // 1st Wall
                                                        %CurrPos=$los::position;
                                                        %NewVector="0 0 -0.5";
                                                        %NewPos=Vector::add(%CurrPos,%NewVector);
                                                        %wall = newObject("Bunker","StaticShape",MobileBunker,false);
                                                        addToSet("MissionCleanup", %wall);
                                                        GameBase::setTeam(%wall,GameBase::getTeam(%player));
                                                        GameBase::setPosition(%wall,%NewPos);
                                                        GameBase::setRotation(%wall,%rot);
                                                        Gamebase::setMapName(%wall,"");
                                                        GameBase::startFadeIn(%wall);
                                                        $TeamBunker[0 @ %Team]=%wall;
                                                        Client::setOwnedObject(%client, %wall);
                                                        Client::setOwnedObject(%client, %player);


                                                        // 2nd Wall
                                                        %ang=Getword(Vector::add(%rot,"0 0 -0.375245789"),2);
                                                        %x=COS(%ang)*9.2;
                                                        %ang=Getword(Vector::add(%rot,"0 0 -0.375245789"),2);
                                                        %y=SIN(%ang)*9.2;
                                                        %NewVector=%x@" "@%y@" -0.5";
                                                        %NewPos=Vector::add(%CurrPos,%NewVector);
                                                        %ang=Vector::add(%rot,"0 0 -0.785398163");
                                                        %wall = newObject("Bunker","StaticShape",MobileBunker,false);
                                                        addToSet("MissionCleanup", %wall);
                                                        GameBase::setTeam(%wall,GameBase::getTeam(%player));
                                                        GameBase::setPosition(%wall,%NewPos);
                                                        GameBase::setRotation(%wall,%ang);
                                                        Gamebase::setMapName(%wall,"");
                                                        GameBase::startFadeIn(%wall);
                                                        $TeamBunker[1 @ %Team]=%wall;
                                                        Client::setOwnedObject(%client, %wall);
                                                        Client::setOwnedObject(%client, %player);

                                                        //3rd Wall
                                                        %ang=Getword(Vector::add(%rot,"0 0 0.375245789"),2);
                                                        %x=COS(%ang)*-9.2;
                                                        %ang=Getword(Vector::add(%rot,"0 0 0.375245789"),2);
                                                        %y=SIN(%ang)*-9.2;


                                                        %NewVector=""@%x@" "@%y@" -0.5";
                                                        %NewPos=Vector::add(%CurrPos,%NewVector);
                                                        %ang=Vector::add(%rot,"0 0 0.785398163");
                                                        %wall = newObject("Bunker","StaticShape",MobileBunker,false);
                                                        addToSet("MissionCleanup", %wall);
                                                        GameBase::setTeam(%wall,GameBase::getTeam(%player));
                                                        GameBase::setPosition(%wall,%NewPos);
                                                        GameBase::setRotation(%wall,%ang);
                                                        Gamebase::setMapName(%wall,"");
                                                        GameBase::startFadeIn(%wall);
                                                        $TeamBunker[2 @ %Team]=%wall;
                                                        Client::setOwnedObject(%client, %wall);

                                                       Client::setOwnedObject(%client, %player);

                                                        //4th Wall
                                                        %ang=Getword(Vector::add(%rot,"0 0 -0.785398163"),2);
                                                        %x=COS(%ang)*16.8;
                                                        %ang=Getword(Vector::add(%rot,"0 0 -0.785398163"),2);
                                                        %y=SIN(%ang)*16.8;
                                                        %NewVector=""@%x@" "@%y@" -0.5";
                                                        %NewPos=Vector::add(%CurrPos,%NewVector);
                                                        %ang=Vector::add(%rot,"0 0 -1.570796327");
                                                        %wall = newObject("Bunker","StaticShape",MobileBunker,false);
                                                        addToSet("MissionCleanup", %wall);
                                                        GameBase::setTeam(%wall,GameBase::getTeam(%player));
                                                        GameBase::setPosition(%wall,%NewPos);
                                                        GameBase::setRotation(%wall,%ang);
                                                        Gamebase::setMapName(%wall,"");
                                                        GameBase::startFadeIn(%wall);
                                                        $TeamBunker[3 @ %Team]=%wall;
                                                        playSound(SoundBunkerDeploy,$los::position);
                                                        Client::setOwnedObject(%client, %wall);
                                                        Client::setOwnedObject(%client, %player);

                                                        // 5th Wall
                                                        %ang=Getword(Vector::add(%rot,"0 0 0.785398163"),2);
                                                        %x=COS(%ang)*-16.8;
                                                        %ang=Getword(Vector::add(%rot,"0 0 0.785398163"),2);
                                                        %y=SIN(%ang)*-16.8;
                                                        %NewVector=%x@" "@%y@" -0.5";
                                                        %NewPos=Vector::add(%CurrPos,%NewVector);
                                                        %ang=Vector::add(%rot,"0 0 1.570796327");
                                                        %wall = newObject("Bunker","StaticShape",MobileBunker,false);
                                                        addToSet("MissionCleanup", %wall);
                                                        GameBase::setTeam(%wall,GameBase::getTeam(%player));
                                                        GameBase::setPosition(%wall,%NewPos);
                                                        GameBase::setRotation(%wall,%ang);
                                                        Gamebase::setMapName(%wall,"");
                                                        GameBase::startFadeIn(%wall);
                                                        $TeamBunker[4 @ %Team]=%wall;
                                                        Client::setOwnedObject(%client, %wall);
                                                        Client::setOwnedObject(%client, %player);
                                                        Client::sendMessage(%client,0,"Riot Wall deployed");
                                                        $TeamItemCount[GameBase::getTeam(%player) @ "AODBunker"]++;
                                                        echo("INF: ",$User[%client]," deployed a Mobile Bunker");
                                                        return true;
                                        }
                                        else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                                }
                                else Client::sendMessage(%client,0,"Some other Item in the Way!!");
                        }
                        else Client::sendMessage(%client,0,"Can only deploy Outside on terrain");
                }
                else Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
        return false;
}


function MobileBunker::onDestroyed(%this)
{        // StaticShape::onDestroyed(%this);
        // $TeamItemCount[GameBase::getTeam(%this) @ "AODBunker"]--;
}
//--------------------------------------------------------------------------------------------------------
// Mini Base
//--------------------------------------------------------------------------------------------------------
$InvList[MiniBase]                = 1;
$RemoteInvList[MiniBase]                = 0;
$TeamItemMax[MiniBase]                = 2;

$ItemMax[aarmor, MiniBase]                = 1;


ItemImageData MiniBaseImage
{
        shapeFile = "ammounit_remote";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};

ItemData MiniBase
{
	description = "Air-Base";
	shapeFile = "ammounit_remote";
	className = "Backpack";
	heading =  "hDeployable Base Objects";
	imageType = MiniBaseImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData MiniBaseGenerator
{
   description = "Power Source";
   shapeFile = "generator_p";
        className = "Generator";
        debrisId = flashDebrisSmall;
        sfxAmbient = SoundGeneratorPower;
        maxDamage = 1.0;
        mapIcon = "M_generator";
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = flashExpMedium;
        visibleToSensor = true;
        mapFilter = 4;
};

function MiniBase::Destruct(%this)
{
                %obj = newObject("","Mine","armorCoreExp");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 -2";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
                %obj = newObject("","Mine","armorExp");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
                %obj = newObject("","Mine","armorExp");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 2";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
                %obj = newObject("","Mine","armorExp");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 4";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
	return;
}

function MiniBaseGenerator::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	MiniBase::Destruct(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "MiniBase"]--;
}

StaticShapeData BasePlatform
{
        shapeFile = "elevator16x16_octo";
        debrisId = defaultDebrisLarge;
        maxDamage = 15.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "Mini-Base";
};

function BasePlatform::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	MiniBase::Destruct(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 30, 1000, 250, 30, 25, 1000, 999, 250, 100);
}

function MiniBase::onUse(%player,%item)
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

function MiniBase::onDeploy(%player,%item,%pos)
{
        if (MiniBase::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function MiniBase::deployshape(%player,%item)
{
	GameBase::getLOSInfo(%player,3);
      %client = Player::getClient(%player);
      %playerPos = GameBase::getPosition(%player);

      if($TeamItemCount[GameBase::getTeam(%player) @ "MiniBase"] >= $TeamItemMax[MiniBase])
      { 
		Client::sendMessage(%client,0,"Too many Air Bases"); 
		return false; 
	}

      %obj = getObjectType($los::object);
      %set = newObject("MiniBase",SimSet);
      %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
      %num = CountObjects(%set,"MiniBase",%num);
      deleteObject(%set);

      %objDevice = newObject("groundBase","Staticshape",MiniBaseGenerator,true);
      %objDevice.objSide1 = newObject("groundBase1","Staticshape",BasePlatform,true);
      %objDevice.objSide2 = newObject("groundBase2","Staticshape",BasePlatform,true);
      %objDevice.objSide3 = newObject("groundBase3","Staticshape",BasePlatform,true);
      %objDevice.objSide4 = newObject("groundBase4","Sensor",PulseSensor,true);
      %objDevice.objSide5 = newObject("groundBase5","StaticShape",BasePlatform,true);
      %objDevice.objSide6 = newObject("groundBase6","StaticShape",AmmoStation,true);
      %objDevice.objSide7 = newObject("groundBase7","StaticShape",InventoryStation,true);
      %objDevice.objSide8 = newObject("groundBase8","StaticShape",VehicleStation,true);
      %objDevice.objSide9 = newObject("groundBase9","StaticShape",VehiclePad,true);

      %objDevice.objSide1.objParent = %objDevice;
      %objDevice.objSide2.objParent = %objDevice;
      %objDevice.objSide3.objParent = %objDevice;
      %objDevice.objSide4.objParent = %objDevice;
      %objDevice.objSide5.objParent = %objDevice;
      %objDevice.objSide6.objParent = %objDevice;
      %objDevice.objSide7.objParent = %objDevice;
      %objDevice.objSide8.objParent = %objDevice;
      %objDevice.objSide9.objParent = %objDevice;

      addToSet(MissionCleanup, %objDevice);
      addToSet(MissionCleanup, %objDevice.objSide1);
      addToSet(MissionCleanup, %objDevice.objSide2);
      addToSet(MissionCleanup, %objDevice.objSide3);
      addToSet(MissionCleanup, %objDevice.objSide4);
      addToSet(MissionCleanup, %objDevice.objSide5);
      addToSet(MissionCleanup, %objDevice.objSide6);
      addToSet(MissionCleanup, %objDevice.objSide7);
      addToSet(MissionCleanup, %objDevice.objSide8);
      addToSet(MissionCleanup, %objDevice.objSide9);

// The Building <(8)>

      %pos = Vector::add(GameBase::getPosition(%player), "7.5 0 22");
      %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
      GameBase::setRotation(%objDevice.objSide5,%rot);
      GameBase::setPosition(%objDevice.objSide5,%pos);
      GameBase::setTeam(%objDevice,GameBase::getTeam(%player));

      %pos = Vector::add(GameBase::getPosition(%player), "-7.5 0 22");
      %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
      GameBase::setRotation(%objDevice.objSide1,%rot);
      GameBase::setPosition(%objDevice.objSide1,%pos);
      GameBase::setTeam(%objDevice.objSide1,GameBase::getTeam(%player));

      %pos = Vector::add(GameBase::getPosition(%player), "0 7 15");
      %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
      GameBase::setRotation(%objDevice.objSide2,%rot);
      GameBase::setPosition(%objDevice.objSide2,%pos);
      GameBase::setTeam(%objDevice.objSide2,GameBase::getTeam(%player));

       %pos = Vector::add(GameBase::getPosition(%player), "0 -7 15");
       %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
       GameBase::setRotation(%objDevice.objSide3,%rot);
       GameBase::setPosition(%objDevice.objSide3,%pos);
       GameBase::setTeam(%objDevice.objSide3,GameBase::getTeam(%player));

       %pos = Vector::add(GameBase::getPosition(%player), "0 0 22.50");
       %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
       GameBase::setRotation(%objDevice.objSide4,%rot);
       GameBase::setPosition(%objDevice.objSide4,%pos);
       GameBase::setTeam(%objDevice.objSide4,GameBase::getTeam(%player));

       %pos = Vector::add(GameBase::getPosition(%player), "0 0 15.40");
       %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
       GameBase::setRotation(%objDevice,%rot);
       GameBase::setPosition(%objDevice,%pos);
       GameBase::setTeam(%objDevice.objSide5,GameBase::getTeam(%player));

       %pos = Vector::add(GameBase::getPosition(%player), "-1 7 15.40");
       %rot = Vector::add(GameBase::getRotation(%player), "0 0 -4.71339");
       GameBase::setRotation(%objDevice.objSide6,%rot);
       GameBase::setPosition(%objDevice.objSide6,%pos);
       GameBase::setTeam(%objDevice.objSide6,GameBase::getTeam(%player));

       %pos = Vector::add(GameBase::getPosition(%player), "1 -7 15.40");
       %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
       GameBase::setRotation(%objDevice.objSide7,%rot);
       GameBase::setPosition(%objDevice.objSide7,%pos);
       GameBase::setTeam(%objDevice.objSide7,GameBase::getTeam(%player));

       %pos = Vector::add(GameBase::getPosition(%player), "-7 1 22.50");
       %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
       GameBase::setRotation(%objDevice.objSide8,%rot);
       GameBase::setPosition(%objDevice.objSide8,%pos);
       GameBase::setTeam(%objDevice.objSide8,GameBase::getTeam(%player));

       %pos = Vector::add(GameBase::getPosition(%player), "7 -1 22.50");
       %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
       GameBase::setRotation(%objDevice.objSide9,%rot);
       GameBase::setPosition(%objDevice.objSide9,%pos);
       GameBase::setTeam(%objDevice.objSide9,GameBase::getTeam(%player));
       Gamebase::setMapName(%inv,"Mini-Base " @  Client::getName(%client));

       playSound(SoundPickupBackpack,$los::position);
       $TeamItemCount[GameBase::getTeam(%player) @ "MiniBase"]++;
       Client::sendMessage(%client,0,"Air-Base Deployed.");
       echo("MSG: ",%client," deployed a Air-Base");
       return true;
}

//***********************************
// Obelisk of Light
//***********************************

$InvList[ObeliskPack]                = 1;
$RemoteInvList[ObeliskPack]                = 0;
$TeamItemMax[ObeliskPack]                = 2;


$ItemMax[aarmor, ObeliskPack]                = 1;



ItemImageData ObeliskPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData ObeliskPack
{
description = "Guard Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "gDeployable Turrets";
	imageType = ObeliskPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function ObeliskPack::onUse(%player,%item)
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

function ObeliskPack::onDeploy(%player,%item,%pos)
{
	if (ObeliskPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ObeliskPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%Set = newObject("set",SimSet); 
			%Mask = $StaticObjectType; 
			%num =containerBoxFillSet(%Set, %Mask, $los::position, 70, 70, 50,0);
			for(%i; %i < %num; %i++)
			{
				%gen = Group::getObject(%Set, %i);
				if(%gen.obeliskpower && %gen.obelisk == "")
				{
					%powered = true;
					break;
				}
			}
			deleteObject(%Set);
			if(%powered)
			{
				%obj = getObjectType($los::object);
				if (%obj != "InteriorShape")
				{
					if (Vector::dot($los::normal,"0 0 1") > 0.7)
					{
						if(checkDeployArea(%client,$los::position))
						{
							%rot = GameBase::getRotation(%player); 

							%turret2 = newObject("ObeliskBarrel","Turret",RealObeliskOfLight,true);
	                 				addToSet("MissionCleanup", %turret2);
							GameBase::setTeam(%turret2,GameBase::getTeam(%player));
							GameBase::setPosition(%turret2,Vector::add($los::position, "0 0 11.5"));
							GameBase::setRotation(%turret2,%rot);

							%turret = newObject("Obelisk","StaticShape",ObeliskOfLight,true);
      	           				addToSet("MissionCleanup", %turret);
							GameBase::setTeam(%turret,GameBase::getTeam(%player));
							GameBase::setPosition(%turret,$los::position);
							GameBase::setRotation(%turret,%rot);

							%turret.realGun = %turret2; //referencing variables
							%turret.gen = %gen;
							%gen.obelisk = %turret2;

							Gamebase::setMapName(%turret,"Guard Turret " @ Client::getName(%client));
							Client::sendMessage(%client,0,"Guard Turret deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "ObeliskPack"]++;
							echo("MSG: ",%client," deployed a Guard Turret. Turret is:" @ %turret @ " and Turret2 is: " @ %turret2);
							//	Remote turrets - kill points to player that deploy them
							// Client::setOwnedObject(%client, %turret); 
							// Client::setOwnedObject(%client, %player);
							if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
								GameBase::setDamageLevel(%turret, 0.7 * ObeliskOfLight.maxDamage);

							return true;
						}
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
				else 
					Client::sendMessage(%client,0,"Cannot deploy in buildings");
			}
			else
				Client::sendMessage(%client, 0, "Must be within range of an Guard Turret Power Cell");
              }
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}
//***********************************
// Obelisk Power Source
//***********************************

$InvList[ObeliskPowerPack]                = 1;
$RemoteInvList[ObeliskPowerPack]                = 0;
$TeamItemMax[ObeliskPowerPack]                = 2;



$ItemMax[aarmor, ObeliskPowerPack]                = 1;



ItemImageData ObeliskPowerPackImage
{
	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -1.0 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData ObeliskPowerPack
{
	description = "Guard Power Cell";
	shapeFile = "generator_p";
	className = "Backpack";
   heading = "hDeployable Base Objects";
	imageType = ObeliskPowerPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function ObeliskPowerPack::onUse(%player,%item)
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

function ObeliskPowerPack::onDeploy(%player,%item,%pos)
{
	if (ObeliskPowerPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ObeliskPowerPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj != "InteriorShape")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%rot = GameBase::getRotation(%player); 

						%generator = newObject("ObeliskPower","StaticShape",ObeliskPower,true);
                 				addToSet("MissionCleanup", %generator );
						GameBase::setTeam(%generator ,GameBase::getTeam(%player));
						GameBase::setPosition(%generator,$los::position);
						GameBase::setRotation(%generator,%rot);

						%generator.obeliskpower = true;

						Gamebase::setMapName(%turret,"Guard Turret Power Cell " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Guard Power Cell deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "ObeliskPowerPack"]++;
						echo("MSG: ",%client," deployed an Guard Turret Power Cell");
						//	Remote turrets - kill points to player that deploy them
						// Client::setOwnedObject(%client, %generator); 
						// Client::setOwnedObject(%client, %player);
						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Cannot deploy in buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

		$TeamItemCount[%i @ ObeliskPack] = 0;
//===========================================================================
//------------------------------------
// DeployDrone
// -----------------------------------

function DeployDrone(%player,%item,%shape,%data,%name)
{
 %client = Player::getClient(%player);
 if(GameBase::getLOSInfo(%player,3))
  {
   if(Vector::dot($los::normal,"0 0 1") > 0.7)
   {
   %rot = GameBase::getRotation(%player);
   %obj = newObject(%name,%data,%shape,true);
   if($TeamItemCount[GameBase::getTeam(%player) @ %name@"Pack"] >= $TeamItemMax[%item])
    {
		centerprint(%client,"<jc>Maximum number of "@%name@"s deployed.");
		deleteObject(%obj);
		return;
	}
   addToSet("MissionCleanup",%obj);
   GameBase::setTeam(%obj,GameBase::getTeam(%player));
   GameBase::setPosition(%obj,$los::position);
   GameBase::setRotation(%obj,%rot);
   Gamebase::setMapName(%obj,%name);
   Client::sendMessage(%client,0,%name@" Deployed ");
   GameBase::startFadeIn(%obj);
   playSound(SoundPickupBackpack,$los::position);
   Client::setControlObject(%client,%obj);
   %player.vehicle = %obj;
   $TeamItemCount[GameBase::getTeam(%player) @ %name@"Pack"]++;
   return true;
   }
   else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
   }
  else Client::sendMessage(%client,0,"Deploy position out of range");
 return false;
}

function ItemBusy(%this)
{        %this.isbusy=true;
}

function ItemNotBusy(%this)
{        %this.isbusy=false;
}

//Shield node Connection objects
$ObjType[0]="DeployableTurret";
$ObjType[1]="VELCROTurret";
$ObjType[2]="GROGTurret";
$ObjType[3]="Fluxturret";
$ObjType[4]="RocketTurret";
$ObjType[5]="PlasmaTurret";
$ObjType[6]="FusionTurret";
$ObjType[7]="AATurret";
$ObjType[8]="ELFTurret";
$ObjType[9]="IndoorTurret";
$ObjType[10]="ArtilleryTurret";
$ObjType[11]="DisruptorTurret";
$ObjType[12]="IonTurret";

// ForceFields
$ObjType[13]="BlastFloorShape";
$ObjType[14]="doorfivebyfiveForceFieldShape";
$ObjType[15]="doorfourbyeightForceFieldShape";
$ObjType[16]="BlastDoorShape";

// Other Static Objects
$ObjType[17]="PulseSensor";
$ObjType[18]="Generator";
$ObjType[19]="SolarPanel";
$ObjType[20]="DeployableRocket";
$ObjType[21]="CloakingNode";

$ObjType[22]="VehiclePad";
$ObjType[23]="ShieldGen";
$ObjType[24]="JumpPad";
$ObjType[25]="MobileGen";
$ObjType[26]="MobileInvent";
$ObjType[27]="InventoryStation";
$ObjType[28]="Teleporter";
$ObjType[29]="TeleporterNode";
$ObjType[30]="DeployableTeleport";
$ObjType[31]="AntiTurret";
$ObjType[32]="DiscTurret";
$ObjType[33]="PulseTurret";
$ObjType[34]="PortaC";

$ObjType[35]="MobileBunker";
$ObjType[36]="PortGenerator";
$ObjType[37]="AmmoStation";
$ObjType[38]="DeployableAmmoStation";
$ObjType[39]="DeployableInvStation";
$ObjType[40]="CommandStation";
$ObjType[41]="VehicleStation";

function GetNumObjects(%set,%type,%tnum)
{        if(%tnum==0)
                return (0);
        if(%type==4)
                return(0);

        if(%type==1)        //        Turrets only
        {        %num=0;
                %num+=CountObjects(%set,$ObjType[0],%tnum);
                %num+=CountObjects(%set,$ObjType[1],%tnum);
                %num+=CountObjects(%set,$ObjType[2],%tnum);
                %num+=CountObjects(%set,$ObjType[3],%tnum);
                %num+=CountObjects(%set,$ObjType[4],%tnum);
                %num+=CountObjects(%set,$ObjType[5],%tnum);
                %num+=CountObjects(%set,$ObjType[6],%tnum);
                %num+=CountObjects(%set,$ObjType[7],%tnum);
                %num+=CountObjects(%set,$ObjType[8],%tnum);
                %num+=CountObjects(%set,$ObjType[9],%tnum);
                %num+=CountObjects(%set,$ObjType[10],%tnum);
                %num+=CountObjects(%set,$ObjType[11],%tnum);
                %num+=CountObjects(%set,$ObjType[12],%tnum);
                return (%num);
        }
        else if(%type==2)        // Forcefields Only
        {        %num=0;
                %num+=CountObjects(%set,$ObjType[13],%tnum);

               %num+=CountObjects(%set,$ObjType[14],%tnum);
                %num+=CountObjects(%set,$ObjType[15],%tnum);
                %num+=CountObjects(%set,$ObjType[16],%tnum);
                return (%num);
        }

        else if(%type==3)        // Forcefields & Static Objects
        {        %num=0;
                %num+=CountObjects(%set,$ObjType[13],%tnum);
                %num+=CountObjects(%set,$ObjType[14],%tnum);
                %num+=CountObjects(%set,$ObjType[15],%tnum);
                %num+=CountObjects(%set,$ObjType[16],%tnum);
                %num+=CountObjects(%set,$ObjType[17],%tnum);
                %num+=CountObjects(%set,$ObjType[18],%tnum);
                %num+=CountObjects(%set,$ObjType[19],%tnum);
                %num+=CountObjects(%set,$ObjType[20],%tnum);
                %num+=CountObjects(%set,$ObjType[21],%tnum);
                %num+=CountObjects(%set,$ObjType[22],%tnum);
                %num+=CountObjects(%set,$ObjType[23],%tnum);
                %num+=CountObjects(%set,$ObjType[24],%tnum);
                %num+=CountObjects(%set,$ObjType[25],%tnum);
                %num+=CountObjects(%set,$ObjType[26],%tnum);
                %num+=CountObjects(%set,$ObjType[27],%tnum);

                %num+=CountObjects(%set,$ObjType[28],%tnum);
                %num+=CountObjects(%set,$ObjType[29],%tnum);
                %num+=CountObjects(%set,$ObjType[30],%tnum);
                %num+=CountObjects(%set,$ObjType[31],%tnum);

               %num+=CountObjects(%set,$ObjType[32],%tnum);
                %num+=CountObjects(%set,$ObjType[33],%tnum);
                %num+=CountObjects(%set,$ObjType[34],%tnum);
                %num+=CountObjects(%set,$ObjType[35],%tnum);
                %num+=CountObjects(%set,$ObjType[36],%tnum);
                %num+=CountObjects(%set,$ObjType[37],%tnum);
                %num+=CountObjects(%set,$ObjType[38],%tnum);
                %num+=CountObjects(%set,$ObjType[39],%tnum);
                %num+=CountObjects(%set,$ObjType[40],%tnum);
                %num+=CountObjects(%set,$ObjType[41],%tnum);

                return(%num);
        }
        else if(%type==0)
        {        %num=0;
                %num+=CountObjects(%set,$ObjType[0],%tnum);
                %num+=CountObjects(%set,$ObjType[1],%tnum);
                %num+=CountObjects(%set,$ObjType[2],%tnum);
                %num+=CountObjects(%set,$ObjType[3],%tnum);
                %num+=CountObjects(%set,$ObjType[4],%tnum);
                %num+=CountObjects(%set,$ObjType[5],%tnum);
                %num+=CountObjects(%set,$ObjType[6],%tnum);
                %num+=CountObjects(%set,$ObjType[7],%tnum);
                %num+=CountObjects(%set,$ObjType[8],%tnum);
                %num+=CountObjects(%set,$ObjType[9],%tnum);
                %num+=CountObjects(%set,$ObjType[10],%tnum);
                %num+=CountObjects(%set,$ObjType[11],%tnum);
                %num+=CountObjects(%set,$ObjType[12],%tnum);
                %num+=CountObjects(%set,$ObjType[13],%tnum);
                %num+=CountObjects(%set,$ObjType[14],%tnum);
                %num+=CountObjects(%set,$ObjType[15],%tnum);
                %num+=CountObjects(%set,$ObjType[16],%tnum);
                %num+=CountObjects(%set,$ObjType[17],%tnum);
                %num+=CountObjects(%set,$ObjType[18],%tnum);
                %num+=CountObjects(%set,$ObjType[19],%tnum);
                %num+=CountObjects(%set,$ObjType[20],%tnum);
                %num+=CountObjects(%set,$ObjType[21],%tnum);
                %num+=CountObjects(%set,$ObjType[22],%tnum);
                %num+=CountObjects(%set,$ObjType[23],%tnum);
                %num+=CountObjects(%set,$ObjType[24],%tnum);
                %num+=CountObjects(%set,$ObjType[25],%tnum);
                %num+=CountObjects(%set,$ObjType[26],%tnum);
                %num+=CountObjects(%set,$ObjType[27],%tnum);
                %num+=CountObjects(%set,$ObjType[28],%tnum);
                %num+=CountObjects(%set,$ObjType[29],%tnum);
                %num+=CountObjects(%set,$ObjType[30],%tnum);

               %num+=CountObjects(%set,$ObjType[31],%tnum);
                %num+=CountObjects(%set,$ObjType[32],%tnum);
                %num+=CountObjects(%set,$ObjType[33],%tnum);

                %num+=CountObjects(%set,$ObjType[34],%tnum);
                %num+=CountObjects(%set,$ObjType[35],%tnum);
                %num+=CountObjects(%set,$ObjType[36],%tnum);
                %num+=CountObjects(%set,$ObjType[37],%tnum);
                %num+=CountObjects(%set,$ObjType[38],%tnum);
                %num+=CountObjects(%set,$ObjType[39],%tnum);
                %num+=CountObjects(%set,$ObjType[40],%tnum);
                %num+=CountObjects(%set,$ObjType[41],%tnum);

                return(%num);
        }
}

function ConnectGenerator (%this,%client)
{	if($TracePwr) echo("Connect this ",%this," Generator to Power Grid (Client = ",%client,")");
	if(%this.isBusy)
		return;
	%name=GameBase::GetMapName(%this);
	if(!%name)
		%name=GameBase::GetDataName(%this);

	if(GameBase::getDamageState(%this)!="Enabled")
	{	echo("Backup Generator ",%this," is disabled!!");
		TeamMessages(0,%team,%name@" DIS-ABLED Unable to come ON Line...~wAAODSFX50.wav");
		return;
	}

	%range = %this.pRange;
	ItemBusy(%this);
	%team = GameBase::getTeam(%this);
	echo("Connecting Generator for Team ",%team);
	echo("Connecting Generator for Client ",$User[%client]);

	
	if(%this.pset)
	{	// Generator has a powerset....refresh it
		%pset=%this.pset;
		if($tracePwr) echo("Generator ",%this," has a power set (",%pset,") ....Refreshing");
	}
	else	// Generator does not have a powerset Create one & refresh it
	{	%pset=MakePowerSet(%this);
		%this.powerset=getGroup(%this);
		removeFromSet(%this.powerset,%this);
		addtoSet(%pset,%this);
		%this.pset=%pset;
	}
	// Scan for Items to Power
	%set = newObject("set",SimSet);
	%pos =	GameBase::getPosition(%this);
	%tnum = containerBoxFillSet(%set,$StaticObjectType | $StaticShapeType ,%pos,%range,%range,%range,0);
	%td=0;
	if (%tnum>0)
	{	// There are Items within scan range
		if($tracePwr) echo($Ver,"| Generator Checking ",%tnum," items");
		for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%set,%i);
			%tgtTeam=GameBase::getTeam(%tgt);
			if(PowerReq(%tgt))									// Does Item Require Power then check otherwise don't Bother
			{	if(%team==%tgtTeam)								// Is it of the Same Team
				{	if (!GameBase::isPowered(%tgt))				// Has NO Power so Connect to it!
					{	%td+=3;									// Time to hookup = 3 Sec
						if(%tgt.powerSet=="")					// This Item has Not Been previously Connected to a Portable Generator
						{	%tgt.powerSet=getGroup(%tgt);			// If it Had Power Remeber where it Was from
						}
						if($tracePwr) echo($Ver,"|Item Has No Power - Removing from Old group ",%tgt.powerSet," adding to ",%pset);
						schedule("PowerSet("@%this@","@%tgt@");",%td);
					}
				}
			}			
		}
	}
	deleteObject(%set);
	schedule("ItemNotBusy("@%this@");",%td);
	if (%td==0)
	{	if(%client)
			Client::SendMessage(%client,1,"Backup power grid Initialized");
		return (false);
	}
	else
		TeamMessages(0,%team,%name@" coming ON Line...~wAAODSFX50.wav");
	return (true);
}

function DisconnectGenerator(%this)	
{	if($TracePwr) echo("Disconnecting this ",%this," Generator from Power Grid");
	//	Use when Packing up a Power Generator
	//	& End of Mission 
	//	Unhooks everything
	ItemBusy(%this);
	%pset=%this.pset;
	%name=GameBase::GetMapName(%this);
	if(!%name)
		%name=GameBase::GetDataName(%this);
	%team = GameBase::getTeam(%this);
	%tnum = Group::objectCount(%pset);
	TeamMessages(1,%team,%name@" Going OFF Line...~wAAODSFX50.wav");
	%td=0;
	if (%tnum>0)
	{	for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%pset,0);
			%td+=2;
			schedule("PowerReset("@%this@","@%tgt@");",%td);
		}
	}
	%td+=1;
	schedule("deleteObject("@%pset@");",%td);
	schedule("ItemNotBusy("@%this@");",%td,%this);
	return (%td);
}


function PowerReq(%this)
{	
	%name=GameBase::GetDataName(%this);
	if(%this.powerReq==1) 
		return true;
	else if(%this.powerReq==false) 
		return false;
	else if(%name.classname == "Turret" || %name.classname == "Station" || %name=="PulseSensor" )
		return (true);
	else
		return (false);
}

function RecheckGrid(%this)
{	if($TracePwr) echo("RE-Connect this ",%this," Generator to Power Grid ");
	// Call When Main Power Source has come back online after a failure
	%mset=getGroup(%this);
	%team=GameBase::getTeam(%this);
	%tnum = Group::objectCount($GenSet[%team]);
	if ($tracePwr) echo($ver,"| Main Gen ",%this," Back on line .. re-routing power from ",%tnum," alternate Generators for Team ",%team);
	if (%tnum>0)
	{	for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject($GenSet[%team],%i);
			%num = Group::objectCount(%tgt.pset);
			if(%num>1)	// If it has more than one object the unit is powering something
			{	for (%j=0;%j<%num;%j++)
				{	%tgt2=Group::getObject(%tgt.pset,%j);
					if(%tgt2.powerset==%mset)	// Object belong in the Power Set for %this which was just restored
					{	removeFromSet(%tgt.pset,%tgt2);
						addToSet(%mset,%tgt2);
						%j--;
						%num--;
					}
				}
			}
		}
	}
}

function EngageBackupPower(%this)
{	if($tracePwr) echo("Engage Backup Power for this ",%this," Generator (It has Been Destroyed or Disabled)");
	%NumFF=0;
	// Call When Main Power has Experienced a failure
	// Check Main Generator Group... If Multiple generators Then Dont Engage Backup
	%Mainset=getGroup(%this);
	%MainNum = Group::objectCount(%MainSet);
	if($tracePwr) echo("Generator Group = ",%MainSet," Number of Items in Group ",%MainNum);
	for (%i=0;%i<%MainNum;%i++)
	{	%tgt=Group::getObject(%MainSet,%i);
		%name = GameBase::getDataName(%tgt);
		%type = GetObjectType(%tgt);
		// if(%name=="" && %type == SimGroup) %name="DoorGroup";
		if($tracePwr) echo("Checking Item ",%tgt," Item is: ",%Name," Class = ",%name.className," type ",%type);
		if(%name == "Generator" || %name == "SolarPanel" || %name == "PortGenerator")
		{	%result=GameBase::getDamageState(%tgt);	
			if(%result==Enabled) %NotReq=True;
		}
		else if(%name=="DoorGroup" || %name.classname == "ForceDoor" || %name.classname == "Door" || %name.classname == "ForceField")
		{	if($TracePwr) echo("Re-Routing ForceField Power for ",%name," Id# ",%tgt);
			%ForceField[%NumFF]=%tgt;
			%NumFF++;
		}
		if(%NotReq==true) %i=%MainNum;
	}

	if(%NotReq) return;
	%team=GameBase::getTeam(%this);
	%tnum = Group::objectCount($GenSet[%team]);
	if ($tracePwr) echo($ver,"| Main Gen ",%this," FAILURE .. ",%tnum," alternate Generators re-checking Grid ",%team);
	%td=0;
	if (%tnum>0)
	{	for (%i=0;%i<%tnum;%i++)
		{	%td+=2;
			%tgt=Group::getObject($GenSet[%team],%i);
			// ForceField Reconnect Routine
			// First Active Generator Gets the ForceFields
			%result=GameBase::getDamageState(%tgt);	
			if(GameBase::getDamageState(%tgt) == "Enabled")
			{	for (%j=0;%j<%NumFF;%j++)
				{	%ff=%ForceField[%j];
					%ff.powerSet=getGroup(%ff);			// Remember where it Was from
					PowerSet(%tgt,%ff);
					//schedule("PowerSet("@%tgt@","@%ff@");",5,%ff);
					if ($tracePwr) echo($ver,"| Routing Power for ",%ff," Forcefield to ",GetGroup(%tgt));
					
				}
			}
			schedule("ConnectGenerator("@%tgt@", false);",%td);
		}
	}
}

function MakePowerSet(%this)
{	%SetName ="PG"@%this;
	%pset= newObject(%SetName,SimGroup);
	addToSet("MissionCleanup", %pset);
	if($tracePwr) echo("Created NEW power set (",%pset,") for Generator ",%this);
	return(%pset);
}

function Powerset(%gen,%object)
{	%gname=GameBase::GetMapName(%gen);
	if(!%gname)
		%gname=GameBase::GetDataName(%gen);
	%pset=%gen.pset;
	%mname = GameBase::getMapName(%object);
	if(%mname=="")							
		%mname = GameBase::getDataName(%object);
	%team=GameBase::getTeam(%gen);
	TeamMessages(0,%team,"Power for "@%mname@" routed to: "@%gname@"~wAAODSFX52.wav");
	%OldSet=getGroup(%object);
	RemoveFromSet(%OldSet,%object);
	%res=AddToSet(%pset,%object);
	if ($tracePwr) echo("Power for "@%object@" routed to power group "@%pset@" generator "@%gen@" for Team ",%team);
}

function Powerreset(%gen,%object)
{	%gname=GameBase::GetMapName(%gen);
	if(!%gname)
		%gname=GameBase::GetDataName(%gen);
	%pset=%gen.pset;
	%mname = GameBase::getMapName(%object);
	if(%mname=="")							
		%mname = GameBase::getDataName(%object);
	%team=GameBase::getTeam(%gen);
	if(%object.powerReq!=2)
		TeamMessages(0,%team,"Power for "@%mname@" disconnected from "@%gname@"~wAAODSFX52.wav");
	removeFromSet(%pset,%object);
	%res=addToSet(%object.powerSet,%object);
	if ($tracePwr) echo("Power for ",%object," set to orignal group ",%object.powerSet," from  generator ",%gen," for Team ",%team);
}


function PowerItem (%this,%range,%client)
{	if($TracePwr) echo($ver,"|Looking for POWER for ",%this," in a ",%range," meter area");
	//** Search Area within specified range
	//** If a Main Generator exists Draw power from that
	//** If a portable generator exists Place %this into the power set for it..
	%numGen=0;
	%team = GameBase::getTeam(%this);
	%set = newObject("set",SimSet);
	%pos =	GameBase::getPosition(%this);
	%tnum = containerBoxFillSet(%set, $StaticObjectType ,%pos,%range,%range,%range,0);
	echo(" Number of Objects Found = ",%tnum);
	if (%tnum>0)
	{	// There are Items within scan range
		if($trace) echo($Ver,"|Scanning ",%tnum," items");
		for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%set,%i);
			%tgtTeam=GameBase::getTeam(%tgt);
			%name = GameBase::getDataName(%tgt);
			if(%team==%tgtTeam)	
			{	if(%name == "Generator" || %name == "SolarPanel" || %name == "PortGenerator")
				{	%nset=getGroup(%tgt);
					if(GameBase::getDamageState(%tgt) == "Enabled")
					{	Client::sendMessage(%client,1,"Main Power connection found..connecting~wAAODSFX16.wav");
						if($tracePwr) echo($Ver,"| Found MAIN Generator : Group ",%nset," Placing Unit in Group");	
						// %power=true;
						if(%nset)
						{	addToSet(%nset,%this);
							%this.powerset=%nset;
							%i=%tnum;
						}
						%numGen++;
					}
					else if(%nset) %this.powerset=%nset;	// Route Main Connection to Main Power Group...

				}
				else if(%name == "MobileGen" || %name == "PortaSolar" || %name == "PowerNode")
				{	if($tracePwr) echo($Ver,"|Found an alternate Power Source.. if needed ",%tgt);

				%Pgen=%tgt;	
				}
					
			}
			
		}
	}
	deleteObject(%set);
	if (%numGen==0)										// If there are No Main Generators to connect to... then
	{	if(%Pgen)										// If there is a portable Power Source connect to it
		{	if($trace) echo($Ver,"|Found a Secondary power Generator ",%PGen," Connecting to it");
			Client::sendMessage(%client,1,"Secondary Power connection found..connecting");
			%result=GameBase::getDamageState(%Pgen);	// Check state of Generator
			%nset=getGroup(%Pgen);
			if(%nset)
				addToSet(%nset,%this);
			//if(%result==Enabled)
				// %power=true;
			//else
				// %power=false;
			// GameBase::virtual(%this,"onPower",%power,%Pgen);
			return (true);
		}
		else
		{	Client::sendMessage(%client,1,"Unable to obtain Power!! Too far from any power generators!!~werror_message.wav");
			return (false);
		}

	}
	return (true);
}

$InvList[AirBase2Pack] = 1;
$RemoteInvList[AirBase2Pack] = 0;

function deployAirBase2::Initialize()
{	
	$TeamItemCount[0 @ AirBase2Pack] = 0;
	$TeamItemCount[1 @ AirBase2Pack] = 0;
	$TeamItemCount[2 @ AirBase2Pack] = 0;
	$TeamItemCount[3 @ AirBase2Pack] = 0;
	$TeamItemCount[4 @ AirBase2Pack] = 0;
	$TeamItemCount[5 @ AirBase2Pack] = 0;
	$TeamItemCount[6 @ AirBase2Pack] = 0;
	$TeamItemCount[7 @ AirBase2Pack] = 0;
}

ItemImageData AirBase2PackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData AirBase2Pack
{	
	description = "Space Station";
	shapeFile = "Discammo";
	className = "Backpack";
	heading = "hDeployable Base Objects";
	imageType = AirBase2PackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData AirBase2ForceFieldLarge
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 50000;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Air Base";
};

StaticShapeData AirBase2ForceFieldSmall
{
	shapeFile = "ForceField_4x8";
	debrisId = defaultDebrisSmall;
	maxDamage = 50000;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Air Base";
};

function AirBase2Pack::onUse(%player,%item)
{	
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function AirBase2Pack::onDeploy(%player,%item,%pos)
{	if(AirBase2Pack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function CreateAirBase2SimSet(%team)
{
	%teleset = nameToID("MissionCleanup/AirBase2" @ %team);
	if(%teleset == -1)
	{
		newObject("AirBase2" @ %team,SimSet);
		addToSet("MissionCleanup","AirBase2" @ %team);
	}
}

function AirBase2Pack::deployshape(%player,%item)
{
	%name = "Air Base2";
	%team = GameBase::getTeam(%player);

	%client = Player::getClient(%player);

	if(!GameBase::getLOSInfo(%player,3))
	{
		Client::sendMessage(%client,0,"Deploy position too far away");
		return false;
	}
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{
		Client::sendMessage(%client,0,"Can Not Deploy A Space Station is Already In-Use");
		return false;
	}
	%playerpos = GameBase::getPosition(%player);
	%team = GameBase::getTeam(%player);
	%flag = $teamFlag[%team];
	%flagpos = gamebase::getPosition(%flag);

	if(Vector::getDistance(%flagpos, %playerpos) < 50)
	{
		Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
		return ;
	}
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain");
		return false;
	}
	CreateAirBaseSimSet(%team);
	
//	echo(%playerpos);
	%posX = getWord(%playerpos, 0);
	%posY = getWord(%playerpos, 1);
	%posZ = getWord(%playerpos, 2) + 200;
	%playerpos = %posX@" "@%posY@" "@%posZ;
	//%playerpos = "0 0 0";

	// Tower Floor
	%object = newObject("Air Base2","InteriorShape", "BEMfloatingPad.dis");
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase2" @ %team, %object);
	%pos = Vector::add(%playerpos, "-5 -5 0");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395");
	%rot = "0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
//	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);

	// Tower Roof
	%object = newObject("Air Base2","InteriorShape", "BESfloatingPad.dis");
	addToSet("MissionCleanup/AirBase2" @ %team, %object);
	addToSet(MissionCleanup, %object);
	%pos = Vector::add(%playerpos, "0 0 38");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395");
	%rot = "0 3.14159 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);

	// Force Field Wall
	%object = newObject("Air Base2","StaticShape",AirBase2ForceFieldLarge,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase2" @ %team, %object);
	%pos = Vector::add(%playerpos, "5.8746 0 14.5");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395");
	%rot = "0 0 1.570796";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	
	// Force Field Wall
	%object = newObject("Air Base Small1","StaticShape",AirBase2ForceFieldSmall,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase2" @ %team, %object);
	%pos = Vector::add(%playerpos, "-5.75 2.05 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395");
	%rot = "0 0 1.570796";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	
	// Force Field Wall
	%object = newObject("Air Base2","StaticShape",AirBase2ForceFieldLarge,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase2" @ %team, %object);
	%pos = Vector::add(%playerpos, "0 5.8746 14.5");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395");
	%rot = "0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	
	// Force Field Wall
	%object = newObject("Air Base Small2","StaticShape",AirBase2ForceFieldSmall,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase2" @ %team, %object);
	%pos = Vector::add(%playerpos, "2.03 -5.75 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	
	%object = newObject("Vehicle Station","StaticShape",VehicleStation,false);
	NukeList(%object);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase2" @ %team, %object);
	%pos = Vector::add(%playerpos, "-3.60177 3.95522 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 0.7853981";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Air Base Vehicle Station");
	
	%object = newObject("Vehicle Pad","StaticShape",VehiclePad,false);
	NukeList(%object);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase2" @ %team, %object);
	%pos = Vector::add(%playerpos, "-10.6862 -11.1697 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 -0 2.3561944";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Air Base Vehicle Pad");
	
	%object = newObject("Inventory Station","StaticShape",InventoryStation,false);
	NukeList(%object);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase2" @ %team, %object);
	%pos = Vector::add(%playerpos, "3.69689 -3.64708 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 -2.3561944";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Air Base Inventory Station");
	
	%object = newObject("Command Station","StaticShape",CommandStation,false);
	NukeList(%object);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase2" @ %team, %object);
	%pos = Vector::add(%playerpos, "4.25588 4.13451 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 -0.7853981";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Air Base Command Station");
	
	%object = newObject("Medium Pulse Sensor","StaticShape",MediumRadar,false);
	NukeList(%object);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase2" @ %team, %object);
	%pos = Vector::add(%playerpos, "0 0 20.55");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Air Base Pulse Sensor");
	
	%object = newObject("Solar Panel","StaticShape",SolarPanel,false);
	NukeList(%object);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase2" @ %team, %object);
	%pos = Vector::add(%playerpos, "-7.49755 1.43987 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 -1.5707963";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Air Base Solar Panel");
	
	%object = newObject("Solar Panel","StaticShape",SolarPanel,false);
	NukeList(%object);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase2" @ %team, %object);
	%pos = Vector::add(%playerpos, "1.58014 -7.45512 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Air Base Solar Panel");

	$TeamItemCount[%team @ %item]++;
	echo("MSG: ",%client," deployed an Air Base");
	Client::sendMessage(%client,0,%item.description @ " Built 200 meters up");
	playSound(SoundPickupBackpack,$los::position);
	return true;
}
exec(deployables2);
//------------------------------------|
// Author: Y|yikichigai(From Shifter Mod)
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
// * The new generator is mine, i came up with it, and most of the other
// code has been modified by me. [TG]-X-Ecutioner
//
StaticShapeData RepGenerator {
	description = "Portable Generator";
	shapeFile   = "generator_p";
	className   = "Generator";
	debrisId    = flashDebrisSmall;
	sfxAmbient  = SoundGeneratorPower;
	maxDamage   = 2.0;
	mapIcon     = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter   = 4;
	maxEnergy   = 80;
	shieldShapeName = "shield";
};

function RepGenerator::onDestroyed(%this){
	$TeamItemCount[GameBase::getTeam(%this) @"RTurretGenPack"]--;
	MessageObjTeamFriendly(%this, 1, "Them Bastards Took Out Our Repair Turret's Gen!");
}
//==========================================================================================

ItemImageData RTurretGenPackImage {
	shapeFile="generator_p";
	mountPoint=2;
	mountOffset={0, 0, 0};
	mountRotation={0, 0, 0};
	mass=0.5;
	firstPerson=false;
};

ItemData RTurretGenPack {
	description = "RepairTurret Gen";
	shapeFile   = "generator_p";
	className   = "Backpack";
	heading     = $InvHeading[Deployables2];
	shadowDetailMask = 4	;
	imageType   = RTurretGenPackImage;
	mass        = 3.0;
	elasticity  = 0.2;
	price       = 750;
	hudIcon     = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function RTurretGenPack::onUse(%player, %item)
{ if (Player::getMountedItem(%player, $BackpackSlot) != %item){ Player::mountItem(%player,%item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }

function RTurretGenPack::onDeploy(%player, %item, %pos)
{ if(RTurretGenPack::deployShape(%player, %item)){ Player::decItemCount(%player,%item); } }	

function RTurretGenPack::deployShape(%player, %item){
	%client = Player::getClient(%player);
	%plTeam = GameBase::getTeam(%player);
	if(%client.outArea)
	{ Client::sendMessage(%client, 0, "Can only deploy within the mission boundaries."); return false; }
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]) 
	{ Client::sendMessage(%client, 0, "Deployable Item limit reached for " @ %item.description @ "s"); return false; }
	if(!GameBase::getLOSInfo(%player, 3)) 
	{ Client::sendMessage(%client, 0, "Deploy position out of range"); return false; }
	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape") 
	{ Client::sendMessage(%client, 0, "Can only deploy on terrain or buildings"); return false; }
	if(Vector::dot($los::normal, "0 0 1") <= 0.7) 
	{ Client::sendMessage(%client, 0, "Can only deploy on flat surfaces"); return false; }
	if(!checkDeployArea(%client, $los::position)) 
	{ return false; }
	%rot = GameBase::getRotation(%player);
	%rGen = newObject("RepairTurret Gen", "StaticShape", RepGenerator, true);
	addToSet("MissionCleanup", %rGen);
	// Referencing Variable.
	%rGen.RTurretPower = true;
	GameBase::setTeam(%rGen, GameBase::getTeam(%player));
	GameBase::setPosition(%rGen, $los::position);
	GameBase::setRotation(%rGen, %rot);
	Gamebase::setMapName(%rGen, "RepairTurret Gen");
	playSound(SoundPickupBackpack, $los::position);
	$TeamItemCount[%plTeam @"RTurretGenPack"]++;
	Client::sendMessage(%client, 0, "Repair Turret Generator deployed.");
	Echo("MSG: "@ Client::getName(%client) @"("@ %client @") deployed a Portable Generator");
	return true;
}
//==========================================================================================

ItemImageData RepairTurretImage {
	shapeFile="cactus2";
	mountPoint=2;
	mountOffset={0, -0.1, -0.06};
	mountRotation={0, 0, 0};
	firstPerson = false;
};

ItemData RepairTurretPack {
	description = "Repair Turret";
	shapeFile = "cactus2";
	className = "Backpack";
	heading = $InvHeading[Deployables2];
	imageType = RepairTurretImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 250;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RepairTurretPack::onUse(%player, %item)
{ if (Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player,%item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }

function RepairTurretPack::onDeploy(%player, %item, %pos)
{ if (RepairTurretPack::deployShape(%player, %item)){ Schedule("Player::decItemCount("@ %player @", "@ %item @");", 5); } }

function RepairTurretPack::deployShape(%player, %item){
	%client = Player::getClient(%player);
	// Check Current Count.
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{ Client::sendMessage(%client,0,"The Limit has been set to 1 for " @ %item.description @ "s"); return false; }
	// Check Deploy Dist.
	if(!GameBase::getLOSInfo(%player, 3))
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }
	// GameBase::getLOSInfo(Player, Distance) sets the following globals:
	// $los::position
	// $los::normal
	// $los::object
	%obj = getObjectType($los::object);
	// Check Terrain.
	if(%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "DeployablePlatform")
	{ Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); return false; }
	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	// Check rot of deploy surface.
	if (Vector::dot($los::normal, "0 0 1") > 0.6){
		%rot = "0 0 "@ %zRot;
	}else{
		if (Vector::dot($los::normal, "0 0 -1") > 0.6)
		{ %rot = "3.14159 0 "@ %zRot; }
		else
		{ %rot = Vector::getRotation($los::normal); }
	}
	$RepRot = %rot;
	$RepPos = $los::position;

	
	if(!checkDeployArea(%client, $los::position))
	{ return false; }
	
	// Check for Repair Turret Generator.
	// Changed distance to 30 meter radius 
	// -Sunday Nov, 2nd
	%Set = newObject("set", SimSet); 
	%Mask = $StaticObjectType; 
	%num = containerBoxFillSet(%Set, %Mask, $los::position, 30, 30, 30, 0);
	for(%i; %i < %num; %i++){
		%obj = Group::getObject(%Set, %i);
		if(%obj.RTurretPower){
			%powered = true;
			break;
		}
	}
	deleteObject(%Set);
	Client::sendMessage(%client, 1, "Checking For Repair Turret Generator...~wSensor_Deploy.Wav");
	%client.player = Client::getControlObject(%client);
	Client::setControlObject(%client, Client::getObserverCamera(%client));
	Observer::setOrbitObject(%client, %client.player, 3, 3, 3);
	%client.guiLock = true;
	BottomPrint(%client, "<jc><f1>Checking For Repair Turret Generator... Chill for a minute..", 5);
	Schedule("RepairTurretPack::DeployMe("@ %player @", "@ %powered @");", 5);
	return true;
}

function RepairTurretPack::DeployMe(%player, %powered){
	%client = Player::getClient(%player);
	if(%powered != true){
		Client::sendMessage(%client, 1, "No RepairTurret Gen Was Found.~wAccess_Denied.Wav");
	}else{
		%camera = newObject("Repair Turret", "Turret", "RepairTurret", true);
		addToSet("MissionCleanup", %camera);
		GameBase::setTeam(%camera, GameBase::getTeam(%player));
		GameBase::setRotation(%camera, $RepRot);
		GameBase::setPosition(%camera, $RepPos);
		Gamebase::setMapName(%camera, Client::getName(%client) @"'s Repair Turret");
		Client::sendMessage(%client, 0, "Repair Turret deployed");
		playSound(SoundPickupBackpack, $los::position);
		$TeamItemCount[GameBase::getTeam(%camera) @"RepairTurretPack"]++;
		$RepRot = "";
		$RepPos = "";
		%camera.gen = 
		Schedule("initDamage("@ %camera @");", 60, %camera);
	}
	Client::setControlObject(%client, %client.player);
	%client.guiLock = false;
}

function initDamage(%this){
	%thisD = GameBase::getDataName(%this);
	echo("init damage");
	%capacity = %thisD.maxDamage - GameBase::getDamageLevel(%this);
	%damage = %capacity / 2;
	
	echo("Damage Level: "@ GameBase::getDamageLevel(%this));
	echo("%capacity = "@ %capacity);
	echo("%damage = "@ %damage);
	
	GameBase::setDamageLevel(%this, %damage);
	if(GameBase::getDamageState(%this) == "Enabled"){
		Schedule("initDamage("@ %this @");", 60, %this);
	}else{
		MessageObjTeamFriendly(%this, 1, "Your Repair Turret Has Been Disabled!~waccess_denied.wav");
	}
}
//==========================================================================================


TurretData RepairTurret {
	className = "Turret";
	shapeFile = "cactus2";
	maxDamage = 1;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = false;
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
	description = "Repair Turret";
};

function RepairTurret::onAdd(%this){
	Schedule("RepairTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") 
	{ GameBase::setMapName (%this, "Repair Turret"); }
}

function RepairTurret::deploy(%this)
{ GameBase::playSequence(%this, 1, "deploy"); }

function RepairTurret::onEndSequence(%this, %thread)
{ GameBase::setActive(%this, true); }

function RepairTurret::onDisabled(%this)
{ Turret::onDisabled(%this); }

function RepairTurret::onPower(%this,%power,%generator){}

function RepairTurret::onEnabled(%this)
{ Schedule("RepairTurret::CheckRepair("@ %this @");", 0.1, %this); }	

function RepairTurret::onDestroyed(%this){
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "RepairTurretPack"]--; 
	%this.RTurretPower = false;
	// These are some of my own messaging commands, im too lazy to figure out howto
	// use the teammessages functs...
	MessageObjTeamFriendly(%this, 1, "Your Repair Turret Has Been Destroyed.~wAccess_Denied.Wav");
	MessageObjTeamEnemy(%this, 0, "Your Team Has Destroyed The "@ getTeamName(GameBase::getTeam(%this)) @"'s Repair Turret.~wCaptured_Tower.Wav");
}

function RepairTurret::onCollision(%this,%obj){
	if(getObjectType(%obj) != "Player") return;
	if(Player::isDead(%obj)) return;
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	if(GameBase::getDamageLevel(%obj)){
		GameBase::setDamageLevel(%obj, 0);
		GameBase::playSound(%this, ForceFieldOpen, 0);
	}
}

function RepairTurret::CheckRepair(%this){
	if(GameBase::getDamageState(%this) != "Enabled") return;
	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType;
	containerBoxFillSet(%Set, %Mask, %Pos, 150, 150, 150, 0);
	%num = Group::objectCount(%Set);
	// extra check for repair turret generator..
	%powered = false;
	for(%i; %i < %num; %i++){
		%obj = Group::getObject(%Set, %i);
		if(%obj != %this){
			if(GameBase::getTeam(%obj) == GameBase::getTeam(%this)){
				if(GameBase::getDamageLevel(%obj)){
					%drate = GameBase::getDamageLevel(%obj);
					// Subtract 50 from the damage level.
					%drate -= 5.0;
					if(%drate < 0) %drate = 0;
					GameBase::setDamageLevel(%obj, %drate);
					playSound(ForceFieldOpen, GameBase::getPosition(%obj));
				}
			}
		}
		
		if(%obj.RTurretPower) %powered = true;
	}
	deleteObject(%set);
	if(%powered) Schedule("RepairTurret::CheckRepair("@ %this @");", 10.0, %this);
}
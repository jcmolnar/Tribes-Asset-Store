$InvList[CommandShipPack] = 1; 		//1
$MobileInvList[CommandShipPack] = 0;
$RemoteInvList[CommandShipPack] = 0;
AddItem(CommandShipPack);

function deployCommandShip::Initialize()
{
	$TeamItemCount[0 @ CommandShipPack] = 0;
	$TeamItemCount[1 @ CommandShipPack] = 0;
	$TeamItemCount[2 @ CommandShipPack] = 0;
	$TeamItemCount[3 @ CommandShipPack] = 0;
	$TeamItemCount[4 @ CommandShipPack] = 0;
	$TeamItemCount[5 @ CommandShipPack] = 0;
	$TeamItemCount[6 @ CommandShipPack] = 0;
	$TeamItemCount[7 @ CommandShipPack] = 0;
}

ItemImageData CommandShipPackImage
{
	shapeFile = "anten_small";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.25 };
	mountRotation = { 0, 0, 0 };
	mass = 5.0;
	firstPerson = false;
};

ItemData CommandShipPack
{
	description = "Command Ship Beacon";
	shapeFile = "anten_small";
	className = "Backpack";
	heading = $InvHead[ihRem];
	shadowDetailMask = 4;
	imageType = CommandShipPackImage;
	mass = 0.5;
	elasticity = 0.2;
	price = 500000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData CommandShipGen
{
	description = "Command Ship Generator";
	shapeFile = "generator";
	classname = "Generator";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundGeneratorPower;
	maxDamage = 2.0;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
	shieldShapeName = "shield";
};

function CommandShipPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function CommandShipPack::onDeploy(%player,%item,%pos)
{
	if(CommandShipPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function CommandShipPack::deployShape(%player,%item)
{
	%team = GameBase::getTeam(%player);
	if(DropShip::deployShape(%player,"CommandShip",%item,65,65,65,1))
	{
		Player::decItemCount(%player,%item);
		%pos = $DropShip[CommandShip@%team];
		%pos = Vector::add(%pos,"0 0 300");
		schedule("CommandShip::DeployShape(\"" @ %pos @ "\", " @ %team @ ");", 20.0);
	}
}

function CommandShip::deployShape(%pos,%team)
{
	if(gamebase::getposition($DropShipBeacon[CommandShip@%team]) != "0 0 0"){	
	%obj = DropShip::CreateShip("CommandShip","gdsdrop.dis",%pos,%team);
	%rot = gamebase::getrotation($DropShipBeacon[CommandShip@%team]);
	gamebase::setrotation(%obj,%rot);	
	%obj.inmotion = true;
	DropshipTeamMessage(%team, 1, "Your teams CommandShip beginning deorbit.");	
	DropShip::MoveShip(%obj,2900,"CommandShip");
	}
	else {
	$TeamItemCount[%team @ CommandShipPack]--;
	DropshipTeamMessage(%team, 1, "Your teams CommandShip beacon has been destroyed, no location to lock onto.");
	}
}

function CommandShip::DeployItems(%this)
{
	%Shippos = GameBase::GetPosition(%this);
	%team = GameBase::GetTeam(%this);
	%prot = gamebase::getrotation(%this);
//	echo("rotation ",%prot);

	%obj=newObject("CommandStation1","StaticShape",CommandStation,false);
	addToSet("MissionCleanup/CommandShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 -0.67";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name@" Command Station 1");
//	GameBase::setPosition(%obj,Vector::add(%pos,"5.81376 0.872431 14"));
	%pos = rotateVector("5.81376 0.872431 14",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj=newObject("CommandStation1","StaticShape",CommandStation,false);
	addToSet("MissionCleanup/CommandShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 -2.467";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name@" Command Station 2");
//	GameBase::setPosition(%obj,Vector::add(%pos,"5.53694 -8.84605 14"));
	%pos = rotateVector("5.53694 -8.84605 14",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj=newObject("CommandStation1","StaticShape",CommandStation,false);
	addToSet("MissionCleanup/CommandShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 2.467";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name@" Command Station 3");
//	GameBase::setPosition(%obj,Vector::add(%pos,"-5.80543 -8.62731 14"));
	%pos = rotateVector("-5.80543 -8.62731 14",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj=newObject("CommandStation1","StaticShape",CommandStation,false);
	addToSet("MissionCleanup/CommandShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 0.67";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name@" Command Station 4");
//	GameBase::setPosition(%obj,Vector::add(%pos,"-5.46576 1.14788 14"));
	%pos = rotateVector("-5.46576 1.14788 14",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj=newObject("Inventory1","StaticShape",InventoryStation,false);
	addToSet("MissionCleanup/CommandShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 -1.57079";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name@" Inventory Station");
//	GameBase::setPosition(%obj,Vector::add(%pos,"18.4622 -4 14"));
	%pos = rotateVector("18.4622 -4 14",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj=newObject("Ammo1","StaticShape",AmmoStation,false);
	addToSet("MissionCleanup/CommandShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 1.57079";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name@" Ammo Station");
//	GameBase::setPosition(%obj,Vector::add(%pos,"-19.127 -4 14"));
	%pos = rotateVector("-19.127 -4 14",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj=newObject("remoteturret","turret",IndoorTurret,false);
	addToSet("MissionCleanup/CommandShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 3.14159 0";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name@" Indoor Turret");
//	GameBase::setPosition(%obj,Vector::add(%pos,"0.0 0.0 11.5"));
	%pos = rotateVector("0.0 0.0 11.5",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj=newObject("remoteturret","turret",PlasmaTurret,false);
	addToSet("MissionCleanup/CommandShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "-0.45 0 -1.5675";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name@" Plasma Turret");
//	GameBase::setPosition(%obj,Vector::add(%pos,"21.5 -4 11"));
	%pos = rotateVector("21.5 -4 11",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj=newObject("remoteturret","turret",PlasmaTurret,false);
	addToSet("MissionCleanup/CommandShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "-0.45 0 1.5675";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name@" Plasma Turret");
//	GameBase::setPosition(%obj,Vector::add(%pos,"-21.5 -4 11"));
	%pos = rotateVector("-21.5 -4 11",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj=newObject("Sensor",Sensor,PulseSensor,false);
	addToSet("MissionCleanup/CommandShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 0";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name@" Radar");
//	GameBase::setPosition(%obj,Vector::add(%pos,"0.0347301 8.63449 32"));
	%pos = rotateVector("0.0347301 8.63449 32",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);
	
	//%obj=newObject("Sensor1",StaticShape,SmallAntenna,false);
	addToSet("MissionCleanup/CommandShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 0";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name@" Radar");
//	GameBase::setPosition(%obj,Vector::add(%pos,"9.27623 -9.30189 32"));
	%pos = rotateVector("9.27623 -9.30189 32",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);
	
	%obj=newObject("Sensor",StaticShape,ArrayAntenna,false);
	addToSet("MissionCleanup/CommandShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 0";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name@" Radar");
//	GameBase::setPosition(%obj,Vector::add(%pos,"-8.53421 -9.4893 32"));
	%pos = rotateVector("-8.53421 -9.4893 32",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj=newObject("Generator1","staticshape",CommandShipGen,false);
	addToSet("MissionCleanup/CommandShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 0";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name@" Main Generator");
//	GameBase::setPosition(%obj,Vector::add(%pos,"11.0328 5.33114 15"));
	%pos = rotateVector("11.0328 5.33114 15",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);
	GameBase::setActive(%obj,True);

// drop points.. ;)	
	
	%obj = newObject("Drop Point", Marker, DropPointMarker,false);
	addToSet("MissionCleanup/CommandShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 3.14";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	%pos = rotateVector("0 18 15",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	%newDropSet = nameToID("MissionCleanup/TeamDrops" @ %Team);
	addToSet(%newDropSet, %obj);
	
	%obj = newObject("Drop Point", Marker, DropPointMarker,false);
	addToSet("MissionCleanup/CommandShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 0";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	%pos = rotateVector("0 -22 13",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	%newDropSet = nameToID("MissionCleanup/TeamDrops" @ %Team);
	addToSet(%newDropSet, %obj);
	
// REPAIR PACK.. its more like a real home now..	
	%obj = newObject("RepairPack","Item","repairpack",1,true,true);	//rotates	
	addToSet("MissionCleanup/CommandShip"@%team, %obj);
	%pos = rotateVector("0 -4 18",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	
	



	playSound(SoundPickupBackpack,%pos);
	playSound(ForceFieldOpen,%pos);
//	$TeamItemCount[GameBase::getTeam(%player) @ "CommandShipPack"]++;
//	echo("MSG: ",%client," deployed a CommandShip");
	return true;
}




function CommandShipGen::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	DropShipGen::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}



$InvList[SupplyShipPack] = 1;		//1
$MobileInvList[SupplyShipPack] = 0;
$RemoteInvList[SupplyShipPack] = 0;
AddItem(SupplyShipPack);

function deploySupplyShip::Initialize()
{
	$TeamItemCount[0 @ SupplyShipPack] = 0;
	$TeamItemCount[1 @ SupplyShipPack] = 0;
	$TeamItemCount[2 @ SupplyShipPack] = 0;
	$TeamItemCount[3 @ SupplyShipPack] = 0;
	$TeamItemCount[4 @ SupplyShipPack] = 0;
	$TeamItemCount[5 @ SupplyShipPack] = 0;
	$TeamItemCount[6 @ SupplyShipPack] = 0;
	$TeamItemCount[7 @ SupplyShipPack] = 0;
}

ItemImageData SupplyShipPackImage
{
	shapeFile = "anten_small";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.25 };
	mountRotation = { 0, 0, 0 };
	mass = 5.0;
	firstPerson = false;
};

ItemData SupplyShipPack
{
	description = "Supply Ship Beacon";
	shapeFile = "anten_small";
	className = "Backpack";
	heading = $InvHead[ihRem];
	shadowDetailMask = 4;
	imageType = SupplyShipPackImage;
	mass = 0.5;
	elasticity = 0.2;
	price = 500000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData SupplyShipGen
{
	description = "Supply Ship Generator";
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

function SupplyShipPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function SupplyShipPack::onDeploy(%player,%item,%pos)
{
	if(SupplyShipPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}
	
function SupplyShipPack::deployShape(%player,%item)
{
	%team = GameBase::getTeam(%player);
	if(DropShip::deployShape(%player,"SupplyShip",%item,65,65,65,1))
	{
		Player::decItemCount(%player,%item);
		%pos = $DropShip[SupplyShip@%team];
		%pos = Vector::add(%pos,"0 0 300");
		schedule("SupplyShip::DeployShape(\"" @ %pos @ "\", " @ %team @ ");", 20.0);
	}
}

function SupplyShip::deployShape(%pos,%team)
{
	if(gamebase::getposition($DropShipBeacon[SupplyShip@%team]) != "0 0 0"){
	%obj = DropShip::CreateShip("SupplyShip","gbedrop.dis",%pos,%team);
	%rot = "0 0 "@getWord(gamebase::getrotation($DropShipBeacon[SupplyShip@%team]),2) + 3.14;
	gamebase::setrotation(%obj,%rot);
	%obj.inmotion = true;
	DropShip::MoveShip(%obj,2900,"SupplyShip");
	DropshipTeamMessage(%team, 1, "Your teams SupplyShip beginning deorbit.");	
	}
	else {
	$TeamItemCount[%team @ SupplyShipPack]--;
	DropshipTeamMessage(%team, 1, "Your teams SupplyShip beacon has been destroyed, no location to lock onto.");
	}
}

function SupplyShip::deployItems(%this)
{	
	%Shippos = GameBase::GetPosition(%this);
	%team = GameBase::GetTeam(%this);
	%prot = gamebase::getrotation(%this);
//	echo("rotation ",%prot);

	%obj = newObject("Inventory1","StaticShape",InventoryStation,false);
	addToSet("MissionCleanup/SupplyShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 0";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
//	GameBase::setRotation(%obj,"0 0 0");
	Gamebase::setMapName(%obj,%name @ " Inventory Station");
//	GameBase::setPosition(%obj,Vector::add(%pos,"-7.25 19.15 7"));
	%pos = rotateVector("-7.25 19.15 7",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj = newObject("Inventory1","StaticShape",InventoryStation,false);
	addToSet("MissionCleanup/SupplyShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 1.57079";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
//	GameBase::setRotation(%obj,"0 0 1.57079");
	Gamebase::setMapName(%obj,%name @ " Inventory Station");
//	GameBase::setPosition(%obj,Vector::add(%pos,"-10.815 17.3136 14.75"));
	%pos = rotateVector("-10.815 17.3136 14.75",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj = newObject("Inventory1","StaticShape",InventoryStation,false);
	addToSet("MissionCleanup/SupplyShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 1.57079";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
//	GameBase::setRotation(%obj,"0 0 1.57079");
	Gamebase::setMapName(%obj,%name @ " Inventory Station");
//	GameBase::setPosition(%obj,Vector::add(%pos,"-10.815 6.741 14.75"));
	%pos = rotateVector("-10.815 6.741 14.75",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj = newObject("Ammo1","StaticShape",AmmoStation,false);
	addToSet("MissionCleanup/SupplyShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 2.35619";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
//	GameBase::setRotation(%obj,"0 0 2.35619");
	Gamebase::setMapName(%obj,%name @ " Ammo Station");
//	GameBase::setPosition(%obj,Vector::add(%pos,"-20.98 -8.125 9.25"));
	%pos = rotateVector("-20.98 -8.125 9.25",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj = newObject("Ammo1","StaticShape",AmmoStation,false);
	addToSet("MissionCleanup/SupplyShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 -2.35619";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
//	GameBase::setRotation(%obj,"0 0 -2.35619");
	Gamebase::setMapName(%obj,%name @ " Ammo Station");
//	GameBase::setPosition(%obj,Vector::add(%pos,"18.77 -8.125 9.25"));
	%pos = rotateVector("18.77 -8.125 9.25",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj = newObject("remoteturret","turret",IndoorTurret,false);
	addToSet("MissionCleanup/SupplyShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 3.14159 3.14156";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
//	GameBase::setRotation(%obj,"0 3.14159 3.14156");
	Gamebase::setMapName(%obj,%name @ " Indoor Turret");
//	GameBase::setPosition(%obj,Vector::add(%pos,"-0.05 -6.15 14.25"));
	%pos = rotateVector("-0.05 -6.15 14.25",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj = newObject("remoteturret","turret",PlasmaTurret,false);
	addToSet("MissionCleanup/SupplyShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 3.14159";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
//	GameBase::setRotation(%obj,"0 0 3.14159");
	Gamebase::setMapName(%obj,%name @ " Plasma Turret");
//	GameBase::setPosition(%obj,Vector::add(%pos,"0.0735339 -6.61414 20.0077"));
	%pos = rotateVector("0.0735339 -6.61414 20.0077",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);

	%obj = newObject("Generator1","staticshape",SupplyShipGen,false);
	addToSet("MissionCleanup/SupplyShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 1.57079";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
//	GameBase::setRotation(%obj,"0 0 1.57079");
	Gamebase::setMapName(%obj,%name @ " Main Generator");
//	GameBase::setPosition(%obj,Vector::add(%pos,"1.5 18.5 7"));
	%pos = rotateVector("1.5 18.5 7",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::startFadeIn(%obj);
	GameBase::setActive(%obj,True);
// drop points.. ;)	
	
	%obj = newObject("Drop Point", Marker, DropPointMarker,false);
	addToSet("MissionCleanup/SupplyShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 2.35";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	%pos = rotateVector("18 18.5 15",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	%newDropSet = nameToID("MissionCleanup/TeamDrops" @ %Team);
	addToSet(%newDropSet, %obj);
	
	%obj = newObject("Drop Point", Marker, DropPointMarker,false);
	addToSet("MissionCleanup/SupplyShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 0";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	%pos = rotateVector("3.5 2 14.75",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	%newDropSet = nameToID("MissionCleanup/TeamDrops" @ %Team);
	addToSet(%newDropSet, %obj);
// end drop points

// REPAIR PACK.. its more like a real home now..	
	%obj = newObject("RepairPack","Item","repairpack",1,true,true);	//rotates	
	addToSet("MissionCleanup/SupplyShip"@%team, %obj);
	%pos = rotateVector("-8.25 11.85 17",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	
	

	playSound(SoundPickupBackpack,%pos);
	playSound(ForceFieldOpen,%pos);

//	$TeamItemCount[%team @ "SupplyShipPack"]++;
//	echo("MSG: ",%client," deployed a SupplyShip");
	return true;
}


function SupplyShipGen::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	DropShipGen::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);	
}




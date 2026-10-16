$InvList[GunShipPack] = 1;		//1
$MobileInvList[GunShipPack] = 0;
$RemoteInvList[GunShipPack] = 0;
AddItem(GunShipPack);

function deployGunShip::Initialize()
{
	$TeamItemCount[0 @ GunShipPack] = 0;
	$TeamItemCount[1 @ GunShipPack] = 0;
	$TeamItemCount[2 @ GunShipPack] = 0;
	$TeamItemCount[3 @ GunShipPack] = 0;
	$TeamItemCount[4 @ GunShipPack] = 0;
	$TeamItemCount[5 @ GunShipPack] = 0;
	$TeamItemCount[6 @ GunShipPack] = 0;
	$TeamItemCount[7 @ GunShipPack] = 0;

	for(%i = 0; %i < 100; %i++)
	{
	$DropShipPosition[%i] = "";
	}
	$Ship = 0;
}

ItemImageData GunShipPackImage
{
	shapeFile = "anten_small";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.25 };
	mountRotation = { 0, 0, 0 };
	mass = 5.0;
	firstPerson = false;
};

ItemData GunShipPack
{
	description = "Gun Ship Beacon";
	shapeFile = "anten_small";
	className = "Backpack";
	heading = $InvHead[ihRem];
	shadowDetailMask = 4;
	imageType = GunShipPackImage;
	mass = 0.5;
	elasticity = 0.2;
	price = 500000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData GunShipGen
{
	description = "Gun Ship Generator";
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

function GunShipPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function GunShipPack::onDeploy(%player,%item,%pos)
{
	if(GunShipPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item);
}

function GunShipPack::deployShape(%player,%item)
{
	%team = GameBase::getTeam(%player);
	%obj = DropShip::deployShape(%player,"GunShip",%item,100,80,400,0);

	if(%obj)
	{
		
		Player::decItemCount(%player,%item);
		%pos = $DropShip[GunShip@%team];
		%pos = Vector::add(%pos,"0 0 300");
		schedule("GunShip::DeployShape(\"" @ %pos @ "\", " @ %team @ ");", 20.0);

	}
}


function GunShip::deployShape(%pos,%team,%beacon)
{	
//	echo(gamebase::getposition($DropShipBeacon[GunShip@%team]));
	if(gamebase::getposition($DropShipBeacon[GunShip@%team]) != "0 0 0")
	{
		%obj = DropShip::CreateShip("GunShip","gswdrop.dis",%pos,%team);
		gamebase::setrotation(%obj,gamebase::getrotation($DropShipBeacon[GunShip@%team]));
		%obj.inmotion = true;
		DropshipTeamMessage(%team, 1, "Your teams GunShip beginning deorbit.");
		DropShip::MoveShip(%obj,2900,"GunShip");
	}
	else {
		$TeamItemCount[%team @ GunShipPack]--;
		DropshipTeamMessage(%team, 1, "Your teams GunShip beacon has been destroyed, no location to lock onto.");
	}
}


function GunShip::DeployItems(%this)
{
	%shippos = GameBase::GetPosition(%this);
	%team = GameBase::GetTeam(%this);
	
//	%pos = rotateVector("0 0 -1.5",%prot);
//	%pos = Vector::add(%playerPos,%pos);	
//	%rot = Vector::add(%prot,%rot);	
	%prot = gamebase::getrotation(%this);
//	echo("rotation ",%prot);
	
	%obj = newObject("Inventory1","StaticShape",InventoryStation,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setRotation(%obj,%prot);
	Gamebase::setMapName(%obj,%name @ " Inventory Station");
	%pos = rotateVector("-5.6 3.4 4.5",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"-5.6 3.4 4.5"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("Inventory1","StaticShape",InventoryStation,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setRotation(%obj,%prot);
	Gamebase::setMapName(%obj,%name @ " Inventory Station");	
	%pos = rotateVector("5.6 3.4 4.5",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"5.6 3.4 4.5"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("Ship Inventory","StaticShape",InventoryStation,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setRotation(%obj,%prot);
	Gamebase::setMapName(%obj,%name @ " Inventory Station");
	%pos = rotateVector("-7.375 14.5 13.5",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"-7.375 14.5 13.5"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("Ship Inventory","StaticShape",InventoryStation,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setRotation(%obj,%prot);
	Gamebase::setMapName(%obj,%name @ " Inventory Station");
	%pos = rotateVector("7.375 14.5 13.5",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"7.375 14.5 13.5"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("CommandStation1","StaticShape",CommandStation,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setRotation(%obj,%prot);
	Gamebase::setMapName(%obj,%name @ " Command Station");
	%pos = rotateVector("-6.5 14.375 18",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"-6.5 14.375 18"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("AmmoStation1","StaticShape",AmmoStation,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
//	GameBase::setPosition(%obj,"0 0 -3.13988");
	Gamebase::setMapName(%obj,%name @ " Ammo Station");
	%pos = rotateVector("6.2 14.7 18",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::setRotation(%obj,%prot);	
//	GameBase::setPosition(%obj,Vector::add(%pos,"6.2 14.7 18"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("AmmoStation1","StaticShape",AmmoStation,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
//	GameBase::setPosition(%obj,"0 0 -3.13988");
	GameBase::setRotation(%obj,%prot);
	Gamebase::setMapName(%obj,%name @ " Ammo Station");
	%pos = rotateVector("0 20.5 7.5",%prot);
	%pos = Vector::add(%shippos,%pos);	
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"0 20.5 7.5"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("remoteturret","turret",PlasmaTurret,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0.2 3.14159";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name @ " Plasma Turret");
	%pos = rotateVector("24.35 1.7 17.7",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"24.35 1.7 17.7"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("remoteturret","turret",PlasmaTurret,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 -2.84 3.14159";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name @ " Plasma Turret");
	%pos = rotateVector("24.85 1.7 15.7",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"24.85 1.7 15.7"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("remoteturret","turret",PlasmaTurret,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 -0.2 3.14159";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name @ " Plasma Turret");
	%pos = rotateVector("-24.35 1.7 17.7",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"-24.35 1.7 17.7"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("remoteturret","turret",PlasmaTurret,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 2.84 3.14159";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name @ " Plasma Turret");
	%pos = rotateVector("-24.85 1.7 15.7",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"-24.85 1.7 15.7"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("chainturret","turret",Elfturret,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 3.14073";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name @ " Elf Turret");
	%pos = rotateVector("0 0.5 18",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"0 0.5 18"));
	GameBase::startFadeIn(%obj);
	
	%obj = newObject("Sensor1","StaticShape",LargeRadar,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setRotation(%obj,%prot);
	Gamebase::setMapName(%obj,%name @ " Radar");
	%pos = rotateVector("0 12 22",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"0 12 22"));
	GameBase::startFadeIn(%obj);
		
	%obj = newObject("Generator","StaticShape",GunShipGen,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 1.57079";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name @ " Main Generator");
	%pos = rotateVector("0 1.0 4.538",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"0 1.0 4.538"));
	GameBase::startFadeIn(%obj);
	GameBase::setActive(%obj,True);

// drop points.. ;)	

	%obj = newObject("Drop Point", Marker, DropPointMarker,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 -0.8";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	%pos = rotateVector("-8 -3 18",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	%newDropSet = nameToID("MissionCleanup/TeamDrops" @ %Team);
	addToSet(%newDropSet, %obj);
	
	%obj = newObject("Drop Point", Marker, DropPointMarker,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 0.8";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	%pos = rotateVector("8 -3 18",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	%newDropSet = nameToID("MissionCleanup/TeamDrops" @ %Team);
	addToSet(%newDropSet, %obj);
		
// REPAIR PACK.. its more like a real home now..	
	%obj = newObject("RepairPack","Item","repairpack",1,true,true);	//rotates	
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	%pos = rotateVector("0 13 21",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);	
		
	playSound(SoundPickupBackpack,%pos);
	playSound(ForceFieldOpen,%pos);
	
	return true;	
}

function GunShipGen::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	DropShipGen::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}



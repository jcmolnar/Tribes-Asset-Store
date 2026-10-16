//=======================
// Ship Functions
//=======================

StaticShapeData ShipAntenna
{
	shapeFile = "anten_small";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.0;
	shieldShapeName = "shield";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	description = "Small Antenna";
};





function DropShip::deployShape(%player,%name,%item,%length,%width,%height,%offset)
{
	%clientId = Player::getClient(%player);
	GameBase::getLOSInfo(%player,3);
	%pos = $los::position;
	%team=GameBase::getTeam(%player);
	
	if($TeamItemCount[%team @ %item] >= $TeamItemMax[%item]) 
	{	
		Client::sendMessage(%clientId,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3)) 
	{	
		Client::sendMessage(%clientId,0,"Deploy position out of range");
		return false;
	}
	if(getNumTeams() == 2)
	{
		%playerTeam = Client::getTeam(%clientId);
		if(%playerTeam == 0)
			%enemyTeam = 1;
		else if(%playerTeam == 1)
			%enemyTeam = 0;
		if(((Vector::getDistance($teamFlag[%enemyTeam].originalPosition, $los::position)) < ($FlagDistance * 0.4)) && ($FlagDistance != 0)) 
		{
			Client::sendMessage(%clientId,0,"You are too close to the enemy flag~waccess_denied.wav");
			return false;
		}
	}
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain") 
	{	
		Client::sendMessage(%clientId,0,"Can only deploy on terrain");
		return false;
	}
// check for other deployed ships.
	for(%i = 0; %i<$ship+1; %i++)
	{
	%shipPos = getword($DropShipPosition[%i],0) @" "@ getword($DropShipPosition[%i],1)@" "@getword($los::position,2);	
//	echo($los::position@" " @%i@" "@%shipPos@" "@Vector::getDistance(%shipPos,$los::position));
	if(Vector::getDistance(%shipPos,$los::position)< 70){
		Client::sendMessage(%clientId,0,"You are too close to another ships landing position~waccess_denied.wav");
		return false;
		}
	}
//----------------
	if(!DropShip::CheckDeployArea(%clientId,%pos,%length,%width,%height,%offset))
		return false;

	
	DropShip::CreateSimGroup(%name,%team);
	
	%obj = newObject("Sensor1",StaticShape,ShipAntenna,false);
	NukeList(%obj);
	//%obj = newObject("Sensor1",Sensor,AntennaSensor,false);
	addToSet("MissionCleanup",%obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setPosition(%obj,%pos);
	%rot = "0 0 "@getWord(GameBase::getRotation(%player),2) + 3.14;
	gamebase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name@%team);
	$DropShip[%name@%team] = %pos;
	$DropShipBeacon[%name@%team] = %obj;
	//bottomprintall("GunShip De-Orbit Sequence Commencing, 20 seconds until Landing Sequence");
	%PlayerName = Client::getName(%clientId);
	DropshipTeamMessage(%team, 1, %PlayerName@" has deployed a "@%name@" Beacon, 20 seconds until De-Orbit Burn");
	$TeamItemCount[%team @ %item]++;
//	Client::sendMessage(%clientId,0,%name @ " Beacon Deployed, 20 seconds until De-Orbit Burn");
	echo("MSG: ",%clientId," deployed a " @ %name @ " Beacon");
	
	return %obj;
}

// for player rotations only -plasmatic
function rotateVector(%vec,%rot){
	%pi = 3.14;
	%rot3= getWord(%rot,2);
	for(%i = 0; %rot3 >= %pi*2; %i++) %rot3 = %rot3 - %pi*2;
	if (%rot3 > %pi) %rot3 = %rot3 - %pi*2;
//	echo(%rot3);
	%vec1= getWord(%vec,0);
	%vec2= getWord(%vec,1);
	%vc = %vec2;
	%vec3= getWord(%vec,2);
//	%ray = pow(pow(%vec1,2)+ pow(%vec2,2),0.5);  
	%ray = %vec1;
//	echo("length ",%ray);
	%vec1 = %ray*cos(%rot3);
	%vec2 = %ray*sin(%rot3);
	%vec = %vec1 @" "@ %vec2 @" "@ %vec3;
	%vec = Vector::add(%vec,Vector::getFromRot(%rot,%vc,0));
	return %vec;
	}


function ShipAntenna::onDestroyed(%this)
{
	echo("destroy drop ship small antennae");
	%team = GameBase::getTeam(%this);
	%name = Gamebase::getMapName(%this);
	$DropShipBeacon[%name] = "";
//	DropshipTeamMessage(%team, 1, "Your teams "@%name@" has been destroyed");
	schedule("deleteobject(" @ %this @ ");", 2);
}   

function DropshipTeamMessage(%team, %color, %msg)
{
//	%team = Client::getTeam(%client);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%cl = getClientByIndex(%i);
		%now = Client::getTeam(%cl);
		if(%team == %now)
		{
			Client::sendMessage(%cl,%color,%msg);
		}
	}
}

function DropShip::CheckDeployArea(%clientId,%pos,%length,%width,%height,%offset)
{
	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType,%pos,%length,%width,%height,%offset);
	if(!%num) 
	{
		deleteObject(%set);
		return true;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") 
	{
		%obj = Group::getObject(%set,0);
		if(Player::getClient(%obj) == %clientId) 
			Client::sendMessage(%clientId,0,"Unable to deploy - You're in the way");
		else 
			Client::sendMessage(%clientId,0,"Unable to deploy - Player in the way");
	}
	else if(%num == 1)
	{
		%obj = Group::getObject(%set,0);
		//%name = GameBase::getMapName(%obj);
		%type = getObjectType(%obj);
		Client::sendMessage(%clientId,0,"Unable to deploy - " @ %type @ " in the landing zone");
	}
	else if(%num > 1)
		Client::sendMessage(%clientId,0,"Unable to deploy - Multiple items in the landing zone");
	else
		Client::sendMessage(%clientId,0,"Unable to deploy - Item in the way");
	deleteObject(%set);
	return false;
}

function DropShip::CreateSimGroup(%name,%team)
{
	%teleset = nameToID("MissionCleanup/"@%name@%team);
	if(%teleset == -1)
	{	
		%group = newObject(%name@%team,SimGroup);
		addToSet("MissionCleanup",%group);
	}
}

function DropShip::CreateShip(%name,%shape,%pos,%team)
{

	$DropShipPosition[$Ship] = %pos;
	$ship = $ship +1;
//	echo("DropShip::CreateShip(" @ %name @ "," @ %shape @ "," @ %pos @ "," @ %team @ ")");
//	echo("name " @ %name);
//	echo("shape " @ %shape);
	%obj = newObject(%name,InteriorShape,%shape);
	GameBase::startFadeIn(%obj);
	echo("Created Dropship name: "@ %name @ " object#: " @ %obj);
	addToSet("MissionCleanup/"@%name@%team, %obj);
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,%team);
	return(%obj);
}

function DropShip::MoveShip(%this,%steps,%name)
{	
	//echo(moveship);
	%movement = 0.100000;
	%pos = GameBase::GetPosition(%this);
	%pos = Vector::add(%pos,"0 0 -" @ %movement);
	GameBase::SetPosition(%this,%pos);
	%steps--;
	//%this.inmotion = true;
	if(%steps > 0)
		schedule("DropShip::MoveShip(" @ %this @ "," @ %steps @ "," @ %name @ ");", 0.01, %this);
	else if(%steps == 0){
		%this.inmotion = "";
		schedule(%name@"::DeployItems(" @ %this @ ");", 3, %this);
		}
}
//==========
$InvList[GunShipPack] = 1;		
$ItemMax[aarmor, GunShipPack] = 1; 

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
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData GunShipPack
{
	description = "Destroyer |X| BattleShip";
	shapeFile = "anten_small";
	className = "Backpack";
	heading = "hDeployable Base Objects";
	shadowDetailMask = 4;
	imageType = GunShipPackImage;
	mass = 0.5;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData GunShipGen
{
	description = "Generator";
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
	if(gamebase::getposition($DropShipBeacon[GunShip@%team]) != "0 0 0"){
	%obj = DropShip::CreateShip("GunShip","gswdrop.dis",%pos,%team);
	gamebase::setrotation(%obj,gamebase::getrotation($DropShipBeacon[GunShip@%team]));
	%obj.inmotion = true;
	DropshipTeamMessage(%team, 1, "Your teams Destroyer |X| is beginning deorbit.");
	DropShip::MoveShip(%obj,2900,"GunShip");
	}
	else {
	$TeamItemCount[%team @ GunShipPack]--;
	DropshipTeamMessage(%team, 1, "Your teams Destroyer |X| beacon has been destroyed, no location to lock onto.");
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
	NukeList(%obj);
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
	NukeList(%obj);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setRotation(%obj,%prot);
	Gamebase::setMapName(%obj,%name @ " Inventory Station");	
	%pos = rotateVector("5.6 3.4 4.5",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"5.6 3.4 4.5"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("Inventory1","StaticShape",InventoryStation,false);
	NukeList(%obj);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setRotation(%obj,%prot);
	Gamebase::setMapName(%obj,%name @ " Inventory Station");
	%pos = rotateVector("-7.375 14.5 13.5",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"-7.375 14.5 13.5"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("Inventory1","StaticShape",InventoryStation,false);
	NukeList(%obj);
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
	NukeList(%obj);
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
	NukeList(%obj);
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
	NukeList(%obj);
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
	NukeList(%obj);
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
	NukeList(%obj);
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
	NukeList(%obj);
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
	NukeList(%obj);
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
	NukeList(%obj);
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
	NukeList(%obj);
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
	NukeList(%obj);
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
	
	playSound(SoundPickupBackpack,%pos);
	playSound(ForceFieldOpen,%pos);
	
	return true;	
}

//--------------------
//DOOM STAR
//------------------



SeekingMissileData BazookaBolt 
{ 
	bulletShapeName = "rocket.dts"; 
	explosionTag = LargeShockwave; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.2; 
	damageType = $MissileDamageType; 
	explosionRadius = 5.0; 
	kickBackStrength = 500.0; 
	muzzleVelocity = 90.0; 
	totalTime = 7; 
	liveTime = 7; 
	seekingTurningRadius = 9; 
	nonSeekingTurningRadius = 75.0; 
	proximityDist = 1.5; 
	smokeDist = 1.75; 
	lightRange = 5.0; 
	lightColor = { 0.4, 0.4, 1.0 }; 
	inheritedVelocityScale = 0.5; 
	soundId = SoundJetHeavy; 
};
	





ItemImageData DeathStarImage 
{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, 0.15, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData DeathStarPack 
{ 
	description = "Dooms Day Device"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = DeathStarImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function DeathStarPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else Player::deployItem(%player,%item); 
} 

function DeathStarPack::onDeploy(%player,%item,%pos) 
{ 
	if (DeathStarPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function DeathStarPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
		if(GameBase::getLOSInfo(%player,3)) 
		{ 
			%obj = getObjectType($los::object); 
			if(%obj == "SimTerrain") 
			{ 
				if(Vector::dot($los::normal,"0 0 1") > 0.7) 
				{ 
					if(checkDeployArea(%client,$los::position)) 
					{ 
						if(DeathDeployCheck(%player,$los::position)) 
						{ 
							if(floor(getRandom() * 40) != 0) 
							{ 
								%rot = GameBase::getRotation(%player); 
								%client = Player::getClient(%player); 
								%phase = newObject("","StaticShape",DeployableDeathStar,true); 
								addToSet("MissionCleanup", %phase); 
								GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
								GameBase::setPosition(%phase,$los::position); 
								GameBase::setRotation(%phase,%rot); 
								Gamebase::setMapName(%phase,"Dooms Day Device Launcher"); 
								Client::sendMessage(%client,0,"Dooms Day Device launcher deployed."); 
								playSound(SoundForceFieldOpen,$los::position); 
								%dposition = $los::position; 
								DeathLaunch(%player,%item,$los::position,3); 
Client::setOwnedObject(%client, %turret); 
           					    Client::setOwnedObject(%client, %player);
								
return true; 
							} 
						else 
						{ 
						schedule("DeathstarOpps(" @ %player @ ",\"" @ $los::position @ "\");",0.3); 
						Client::sendMessage(Player::getClient(%player),1,"The launcher was defective"); 
						return true; 
						} 
					} 
				} 
			} 
			else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
		} 
		else Client::sendMessage(%client,0,"Can only deploy on terrain"); 
	} 
	else Client::sendMessage(%client,0,"Deploy position out of range"); 
} 
else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
return false; 
} 

function DeathDeployCheck(%player,%pos) 
{ 
	return true;
}

function DeathDeployCheckOld(%player,%pos)  // If you want the extra hard 4 blastwalls
{
	%client = Player::getClient(%player); 
	
	%set = newObject("set",SimSet); 
	%num = containerBoxFillSet(%set,$StaticObjectType,%pos,100,100,50,0); 
	deleteObject(%set); 
	if(%num == 0) 
	{ 
		%set = newObject("set",SimSet);
                %num = containerBoxFillSet(%set,$StaticObjectType,%pos,100,100,100,0); 

	%num = CountObjects(%set,"BlastDoorShape",%num); 
		deleteObject(%set); 
		if(%num > 3) 
		{ 
			if(%num < 5) 
			{ 
				%set = newObject("set",SimSet); 
				%num = containerBoxFillSet(%set,$StaticObjectType,%pos,100,100,100,0); 
				%num = CountObjects(%set,"BlastDoorShape",%num); 
				deleteObject(%set); 
				if(%num == 2) 
				{ 
					%set = newObject("set",SimSet); 
					%num = containerBoxFillSet(%set,$StaticObjectType,%pos,100,100,100,0); 
					%num = CountObjects(%set,"BlastDoorShape",%num); 
					deleteObject(%set); 
					if(%num == 2) return true; 
					else Client::sendMessage(%client,0,"Only 2 or 3 walls placed correctly"); 
				} 
				else Client::sendMessage(%client,0,"Only 1 wall recognized"); 
			} 
			else Client::sendMessage(%client,0,"Too many Blast Walls"); 
		} 
		else Client::sendMessage(%client,0,"Need 4 Blast Walls to build a launch area"); 
	} 
	else Client::sendMessage(%client,0,"Too close to wall, or object blocking launch path"); 
	return false; 
} 

function DeathstarOpps(%this,%position) 
{ 
	%dpos = getWord(%position,0) @ " " @ getWord(%position,1) @ " " @ getWord(%position,2) + 5; GameBase::applyRadiusDamage($DebrisDamageType,%dpos,15,12,200,%this); 


schedule("GameBase::applyRadiusDamage(" @ $DebrisDamageType @ ",\"" @ %dpos @ "\",15,12,200," @ %this @ ");",0.3); 
} 

function DeathLaunch(%player,%item,%position,%time) 
{ 
	%client = Player::getClient(%player); 
	if(%time == 0) 
	{ 
		%rot = GameBase::getRotation(%player); 
		%pteam = GameBase::getTeam(%player); 
		%posStart = getWord(%position,0) @ " " @ getWord(%position,1); 
		%posLas = %posStart @ " " @ getWord(%position,2) + 249.6; 
		%posMis = %posStart @ " " @ getWord(%position,2) + 250.4; 
		%posSol = %posStart @ " " @ getWord(%position,2) + 250.5; 
		%lasmisRot = 0 @ " " @ 3.14145 @ " " @ getword(%rot,2); 
		%solRot = -1.5 @ " " @ 3.14145 @ " " @ getword(%rot,2); 
		%laser = newObject("camera","Turret",DeathStarRay,true); 
		addToSet("MissionCleanup", %laser); 
		GameBase::setTeam(%laser,%pteam); 
		GameBase::setPosition(%laser,%posLas); 
		GameBase::setRotation(%laser,%lasmisRot); 
		Gamebase::setMapName(%laser,"Dooms Day Device" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
		%missile = newObject("remoteturret","Turret",DeathStarMissile,true); 
		addToSet("MissionCleanup", %missile); 
		GameBase::setTeam(%missile,%pteam); 
		GameBase::setPosition(%missile,%posMis); 
		GameBase::setRotation(%missile,%lasmisRot); 
		Gamebase::setMapName(%missile,"Sat Missile " @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
		%solar = newObject("SolarPanel","StaticShape","DeathStarSolar",true); 
		addToSet("MissionCleanup", %solar); 
		GameBase::setTeam(%solar,%pteam); 
		GameBase::setPosition(%solar,%posSol); 
		GameBase::setRotation(%solar,%solRot); 
		GameBase::setActive(%solar,false); 
		echo("MSG: ",%client," launched a Dooms Day Device"); 
		Client::sendMessage(%client,0,"Dooms Day Device Launched"); 
		$TeamItemCount[GameBase::getTeam(%player) @ "DeathStarPack"]++; 
		DeathstarOpps(%item,%position); 
		return; 
	} 
	else if(%time == 3) 
		Client::sendMessage(%client,1,":3:~werror_message.wav"); 
	else if(%time == 2) 
		Client::sendMessage(%client,1,":2:~werror_message.wav"); 
	else if(%time == 1) 
		Client::sendMessage(%client,1,":1:~werror_message.wav"); 
	schedule("DeathLaunch(" @ %player @ "," @ %item @ ",\"" @ %position @ "\"," @ %time - 1 @ ");",1.5); 
} 

TurretData DeathStarRay 
{ 
	className = "Turret"; 
	shapeFile = "camera"; 
	projectileType = SniperLaser2; 
	maxDamage = 12.5; 
	maxEnergy = 125; 
	minGunEnergy = 10; 
	maxGunEnergy = 70; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 10; 
	speed = 4.0; 
	speedModifier = 1.5; 
	range = 325; 
	visibleToSensor = true; 
	shadowDetailMask = 4; 
	dopplerVelocity = 0; 
	castLOS = true; 
	supression = false; 
	mapFilter = 2; 
	mapIcon = "M_turret"; 
	debrisId = flashDebrisMedium; 
	shieldShapeName = "shield"; 
	fireSound = SoundFireLaser; 

	activationSound = SoundRemoteTurretOn; 
	deactivateSound = SoundRemoteTurretOff; 
	explosionId = flashExpMedium; 
	description = "Doom Star"; 
	damageSkinData = "objectDamageSkins"; 
}; 

function DeathStarRay::onAdd(%this) 
{ 
	schedule("DeathStarRay::deploy(" @ %this @ ");", 1, %this); 
	GameBase::setRechargeRate(%this, 7); 
	%this.shieldStrength = 0; 
	if (GameBase::getMapName(%this) == "") 
	{ 
		GameBase::setMapName(%this, "Doom Star Laser"); 
	} 
} 

function DeathStarRay::deploy(%this) 
{ 
	GameBase::playSequence(%this, 1, "deploy"); 
} 

function DeathStarRay::onEndSequence(%this, %thread) 
{ 
	GameBase::setActive(%this, true); 
} 

function DeathStarRay::onDestroyed(%this) 
{ 
	StaticShape::objectiveDestroyed(%this); 
	GameBase::setRechargeRate(%this, 0); 
	Turret::onDeactivate(%this); 
} 

function DeathStarRay::onPower(%this, %power, %generator) 
{} 

function DeathStarRay::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this, 7); 
	GameBase::setActive(%this, true); 
} 

TurretData DeathStarMissile 
{ 
	className = "Turret"; 
	shapeFile = "remoteturret"; 
	projectileType = BazookaBolt; 
	maxDamage = 1.1; 
	maxEnergy = 120; 
	minGunEnergy = 60; 
	maxGunEnergy = 60; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 4.0; 
	speed = 6.0; 
	speedModifier = 4.5; 
	range = 325; 
	visibleToSensor = true; 
	shadowDetailMask = 4; 
	dopplerVelocity = 0; 
	castLOS = true; 
	supression = false; 
	mapFilter = 2; 
	mapIcon = "M_turret"; 
	debrisId = flashDebrisMedium; 
	shieldShapeName = "shield"; 
	fireSound = SoundMissileTurretFire; 
	activationSound = SoundRemoteTurretOn; 
	deactivateSound = SoundRemoteTurretOff; 
	explosionId = LargeShockwave; 
	description = "Sat Missile"; 
	damageSkinData = "objectDamageSkins"; 
}; 

function DeathStarMissile::verifyTarget(%this,%target) 
{ 
	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) 
		return "True"; 
	else 
		return "False"; 
} 

function DeathStarMissile::onAdd(%this) 
{ 
	schedule("DeathStarMissile::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,7); 
	%this.shieldStrength = 0.02; 
	if (GameBase::getMapName(%this) == "") 
	{ 
		GameBase::setMapName (%this, "Satelite Missile"); 
	} 
} 

function DeathStarMissile::deploy(%this) 
{ 
	GameBase::playSequence(%this,1,"deploy"); 
} 

function DeathStarMissile::onEndSequence(%this,%thread) 
{ 
	GameBase::setActive(%this,true); 
} 

function DeathStarMissile::onDestroyed(%this) 
{ 
	%missile = GameBase::getPosition(%this); 
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this, 0); 
	Turret::onDeactivate(%this); 
	%focusDam = getWord(%missile,0) @ " " @ getWord(%missile,1) @ " " @ getWord(%missile,2) - 2; 
	GameBase::applyRadiusDamage($DebrisDamageType,%focusDam,5,10,200,%this); 
} 

function DeathStarMissile::onPower(%this,%power,%generator) 
{} 

function DeathStarMissile::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this,7); 
	GameBase::setActive(%this,true); 
}

StaticShapeData DeployableDeathStar 
{ 
	shapeFile = "mortar_turret"; 
	debrisId = defaultDebrisSmall; 
	explosionId = LargeShockwave; 
	maxDamage = 6.50; 
	visibleToSensor = false; 
	isTranslucent = true; 
	description = "Doom Star Launcher"; 
	damageSkinData = "objectDamageSkins"; 
}; 

StaticShapeData DeathStarSolar 
{ 
	description = "Doom Star"; 
	shapeFile = "solar_med"; 
	debrisId = flashDebrisMedium; 
	maxDamage = 1.1; 
	visibleToSensor = true; 
	mapFilter = 4; 
	mapIcon = "M_generator"; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 16; 
	explosionId = LargeShockwave; 
}; 

function DeathStarSolar::onEnabled(%this) 
{ 
	GameBase::setAutoRepairRate(%this,0.05); 
} 

function DeathStarSolar::onDestroyed(%this) 
{ 
	%solarP = GameBase::getPosition(%this); 
	%offsetposition = getWord(%solarP,0) @ " " @ getWord(%solarP,1) @ " " @ getWord(%solarP,2) - 2; 
	GameBase::applyRadiusDamage($DebrisDamageType,%offsetposition,5,10,200,%this); 
	schedule("GameBase::applyRadiusDamage(" @ $DebrisDamageType @ ",\"" @ %offsetposition @ "\",5,10,200," @ %this @ ");",0.3); 
	StaticShape::objectiveDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "DeathStarPack"]--; 
	schedule("CheckDestroySat(\"" @ %solarP @ "\",3);",2.0); 
	echo($TeamItemCount[GameBase::getTeam(%this) @ "DeathStarPack"]); 
	GameBase::setAutoRepairRate(%this,0); 
} 

function DeathStarSolar::onCollision(%this,%object) 
{ 
	if(getObjectType(%object) == "Player" && Player::isExposed(%object)) 
	{ 
		Player::setDamageFlash(%object, 0.75); 
		if(Player::getArmor(%object) == "darmor" || Player::getArmor(%object) == "harmor") 
			GameBase::applyDamage(%object,$ExplosionDamageType,2.0,GameBase::getPosition(%object),"0 0 0","0 0 0",Player::getClient(%object)); 
		else GameBase::applyDamage(%object,$ExplosionDamageType,0.5,GameBase::getPosition(%object),"0 0 0","0 0 0",Player::getClient(%object)); 
			Player::applyImpulse(%object,Vector::getFromRot(GameBase::getRotation(%object), -800, 100)); 
		playSound(debrisLargeExplosion,GameBase::getPosition(%object)); 
	} 
} 

function CheckDestroySat(%position,%time) 
{ 
	if(%time > 0) 

{ 

		%set = newObject("set", SimSet); 
		%num = containerBoxFillSet(%set, $StaticObjectType | $ItemObjectType, %position, 10,10,10,0); 
		if(%num > 0) 
		{ 
			for (%i = 0; %i < %num; %i = %i++) 
			{ 
				%obj = GameBase::getDataName(Group::getObject(%set,%i)); if(%obj != -1 && (%obj == "DeathStarSolar" || %obj == "DeathStarRay" || %obj == "DeathStarMissile")) 
				deleteObject(Group::getObject(%set,%i)); 
			} 
		schedule("CheckDestroySat(\"" @ %position @ "\", " @ %time - 1 @ ");",0.2); 
		} 
	else deleteObject(%set); 
	} 
}

$InvList[DeathstarPack] = 1;

$TeamItemMax[DeathstarPack] = 2;


$ItemMax[aarmor,DeathstarPack] = 1;	

$TeamItemCount[0 @ DeployableSolarPanel] = 0;
	

$TeamItemCount[1 @ DeathstarPack] = 0;
$TeamItemCount[2 @ DeathstarPack] = 0;
$TeamItemCount[3 @ DeathstarPack] = 0;
$TeamItemCount[4 @ DeathstarPack] = 0;
$TeamItemCount[5 @ DeathstarPack] = 0;
$TeamItemCount[6 @ DeathstarPack] = 0;
$TeamItemCount[7 @ DeathstarPack] = 0;
//PORT-OFF: }
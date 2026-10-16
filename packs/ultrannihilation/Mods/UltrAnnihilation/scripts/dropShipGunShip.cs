$InvList[GunShipPack] = 1;
$MobileInvList[GunShipPack] = 0;
$RemoteInvList[GunShipPack] = 0;

function deployGunShip::Initialize()
{	$TeamItemCount[0 @ GunShipPack] = 0;
	$TeamItemCount[1 @ GunShipPack] = 0;
	$TeamItemCount[2 @ GunShipPack] = 0;
	$TeamItemCount[3 @ GunShipPack] = 0;
	$TeamItemCount[4 @ GunShipPack] = 0;
	$TeamItemCount[5 @ GunShipPack] = 0;
	$TeamItemCount[6 @ GunShipPack] = 0;
	$TeamItemCount[7 @ GunShipPack] = 0;
}

ItemImageData GunShipPackImage
{	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.25 };
	mountRotation = { 0, 0, 0 };
	mass = 5.0;
	firstPerson = false;
};

ItemData GunShipPack
{	description = "Gun Ship";
	shapeFile = "generator_p";
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

function GunShipPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{	Player::deployItem(%player,%item);
	}
}

function GunShipPack::onDeploy(%player,%item,%pos)
{	if (GunShipPack::deployShape(%player,%item)) 
	{	Player::decItemCount(%player,%item);
	}
}

StaticShapeData GunShipGen
{	description = "Generator";
	shapeFile = "generator";
	classname = "GunShipGen";
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

function GunShipGen::onDestroyed(%this)
{	if($trace) echo($ver,"| GunShipGen::onDestroyed");
	GunShipGen::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
}

function GunShipGen::onEnabled(%this)
{	if($trace) echo($ver,"| GunShipGen::onEnabled ",%this);
	//GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
	GameBase::isPowerGenerator(%this);
	GunShip::setPower(GameBase::getTeam(%this),1);
}

function GunShipGen::onActivate(%this)
{
	if($trace) echo($ver,"| CommandShipGen::onActivate ",%this);
	//GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
	GameBase::isPowerGenerator(%this);
	GunShip::setPower(GameBase::getTeam(%this),1);
}

function GunShipGen::setActive(%this)
{
	if($trace) echo($ver,"| CommandShipGen::setActive ",%this);
	//GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
	GameBase::isPowerGenerator(%this);
	GunShip::setPower(GameBase::getTeam(%this),1);
}

function GunShipGen::onDisabled(%this)
{	if($trace) echo($ver,"| GunShipGen::onDisabled ",%this);
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
 	GunShip::setPower(GameBase::getTeam(%this),0);
}

function CreateGunShipsimSet(%team)
{
	%teleset = nameToID("MissionCleanup/GunShip"@%team);
	if(%teleset == -1)
	{	
		newObject("GunShip"@%team,SimSet);
		addToSet("MissionCleanup","GunShip"@%team);
	}
}

function GunShip::setPower(%team,%power) 
{	
	%teleset = nameToID("MissionCleanup/GunShip"@%team);
	if(%teleset != -1)
	{	
		%objs=Group::objectCount(%teleset);
		if(%objs) 
		{	
			for(%x=0;%x<%objs;%x++) 
			{	
				%obj=Group::getObject(%teleset,%x);
				if(GameBase::getMapName(%obj)=="Gun Ship Inventory Station" || GameBase::getMapName(%obj)=="Gun Ship Ammo Station" || GameBase::getMapName(%obj)=="Gun Ship Command Station") 
				{	
					if(GameBase::getDamageState(%obj)!="Disabled") 
					{	
						Station::onPower(%obj,%power,0);
					}
					else 
					{	
						Station::onPower(%obj,0,0);
					}
				}
				else if(GameBase::getMapName(%obj)=="Gun Ship Elf Turret" || GameBase::getMapName(%obj)=="Gun Ship Plasma Turret" || GameBase::getMapName(%obj)=="Gun Ship Radar")
				{	
					GameBase::setActive(%obj,%power);
					if(GameBase::getDamageState(%obj)!="Disabled") 
					{	
						if (%power) 
						{	
							%obj.shieldStrength = 0.03;
							GameBase::setRechargeRate(%obj,10);
							GameBase::playSequence(%obj,0,"power");
						}
						else 
						{	
							%this.shieldStrength = 0;
							GameBase::setRechargeRate(%obj,0);
							GameBase::StopSequence(%obj,0);
						}
						GameBase::setActive(%this,%power);
					}
					else 
					{	
						GameBase::StopSequence(%obj,0); 
					}
				}
			}
		}
	}
}

function checkDeployAreaGunShip(%client,%pos) 
{
	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType,%pos,75,75,65,1);
	if(!%num) 
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") 
	{
		%obj = Group::getObject(%set,0);
		if(Player::getClient(%obj) == %client) 
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else 
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else 
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	deleteObject(%set);
	return 0;
}

function GunShipPack::deployShape(%player,%item)
{
	%name = "Gun Ship";
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]) 
	{	
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
		return false; 
	}

	if (!GameBase::getLOSInfo(%player,3)) 
	{	
		Client::sendMessage(%client,0,"Deploy position out of range"); 
		return false; 
	}

	if(getNumTeams() == 2)
	{
		%playerTeam = Client::getTeam(%client);
		if(%playerTeam == 0)
			%enemyTeam = 1;
		else if (%playerTeam == 1)
			%enemyTeam = 0;
		if(((Vector::getDistance($teamFlag[%enemyTeam].originalPosition, $los::position)) < ($FlagDistance * 0.4)) && ($FlagDistance != 0)) 
		{
			Client::sendMessage(%client,0,"You are too close to the enemy flag~waccess_denied.wav");
			return false;
		}
	}

	%obj = getObjectType($los::object); 
	if (%obj != "SimTerrain") 
	{	
		Client::sendMessage(%client,0,"Can only deploy on terrain"); 
		return false; 
	}

	if (!checkDeployAreaGunShip(%client,$los::position)) 
	return false;

	// Passed validation, create the object
	
	%team=GameBase::getTeam(%player);
	CreateGunShipsimSet(%team);
	
	%rot="0 0 0";
	%opos=Vector::add($los::position,"0 0 5");
	
	//%rtime=(floor(getRandom()*15)/10);
	%rtime=3;

	%objShip = newObject("Gun Ship","InteriorShape", "gswdrop.dis"); 
	%pos=Vector::add(%opos,"0 0 0");
	addToSet("MissionCleanup", %objShip);
	addToSet("MissionCleanup/GunShip"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objShip,%pos); 
	GameBase::setRotation(%objShip,%rot); 
	Gamebase::setMapName(%objShip,"Gun Ship"); 
	Client::sendMessage(%client,0,"Gun Ship Deployed"); 
	GameBase::startFadeIn(%objShip); 
	
	%objShip = newObject("Inventory1","StaticShape",InventoryStation,false);
	%pos=Vector::add(%opos,"-5.6 3.4 4.5");
	addToSet("MissionCleanup", %objShip);
	addToSet("MissionCleanup/GunShip"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,%rot);
	Gamebase::setMapName(%objShip,%name @ " Inventory Station");
	//%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("Inventory1","StaticShape",InventoryStation,false);
	%pos=Vector::add(%opos,"5.6 3.4 4.5");
	addToSet("MissionCleanup", %objShip);
	addToSet("MissionCleanup/GunShip"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,%rot);
	Gamebase::setMapName(%objShip,%name @ " Inventory Station");
	//%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("Inventory1","StaticShape",InventoryStation,false);
	%pos=Vector::add(%opos,"-7.375 14.5 13.5");
	addToSet("MissionCleanup", %objShip);
	addToSet("MissionCleanup/GunShip"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,%rot);
	Gamebase::setMapName(%objShip,%name @ " Inventory Station");
	//%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("Inventory1","StaticShape",InventoryStation,false);
	%pos=Vector::add(%opos,"7.375 14.5 13.5");
	addToSet("MissionCleanup", %objShip);
	addToSet("MissionCleanup/GunShip"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,%rot);
	Gamebase::setMapName(%objShip,%name @ " Inventory Station");
	//%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("CommandStation1","StaticShape",CommandStation,false);
	%pos=Vector::add(%opos,"-6.5 14.375 18");
	addToSet("MissionCleanup", %objShip);
	addToSet("MissionCleanup/GunShip"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,"%rot");
	Gamebase::setMapName(%objShip,%name @ " Command Station");
	//%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("AmmoStation1","StaticShape",AmmoStation,false);
	%pos=Vector::add(%opos,"6.2 14.7 18");
	addToSet("MissionCleanup", %objShip);
	addToSet("MissionCleanup/GunShip"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setPosition(%objShip,"0 0 -3.13988");
	Gamebase::setMapName(%objShip,%name @ " Ammo Station");
	//%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("AmmoStation1","StaticShape",AmmoStation,false);
	%pos=Vector::add(%opos,"0 20.5 7.5");
	addToSet("MissionCleanup", %objShip);
	addToSet("MissionCleanup/GunShip"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setPosition(%objShip,"0 0 -3.13988");
	Gamebase::setMapName(%objShip,%name @ " Ammo Station");
	//%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("remoteturret","turret",PlasmaTurret,false);
	%pos=Vector::add(%opos,"24.35 1.7 17.7");
	addToSet("MissionCleanup", %objShip);
	addToSet("MissionCleanup/GunShip"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,"0 0.2 3.14159");
	Gamebase::setMapName(%objShip,%name @ " Plasma Turret");
	//%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("remoteturret","turret",PlasmaTurret,false);
	%pos=Vector::add(%opos,"24.85 1.7 15.7");
	addToSet("MissionCleanup", %objShip);
	addToSet("MissionCleanup/GunShip"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,"0 -2.84 3.14159");
	Gamebase::setMapName(%objShip,%name @ " Plasma Turret");
	//%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("remoteturret","turret",PlasmaTurret,false);
	%pos=Vector::add(%opos,"-24.35 1.7 17.7");
	addToSet("MissionCleanup", %objShip);
	addToSet("MissionCleanup/GunShip"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,"0 -0.2 3.14159");
	Gamebase::setMapName(%objShip,%name @ " Plasma Turret");
	//%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("remoteturret","turret",PlasmaTurret,false);
	%pos=Vector::add(%opos,"-24.85 1.7 15.7");
	addToSet("MissionCleanup", %objShip);
	addToSet("MissionCleanup/GunShip"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,"0 2.84 3.14159");
	Gamebase::setMapName(%objShip,%name @ " Plasma Turret");
	//%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("chainturret","turret",Elfturret,false);
	%pos=Vector::add(%opos,"0 0.5 18");
	addToSet("MissionCleanup", %objShip);
	addToSet("MissionCleanup/GunShip"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,"0 0 3.14073");
	Gamebase::setMapName(%objShip,%name @ " Elf Turret");
	//%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("Sensor1","StaticShape",LargeRadar,false);
	%pos=Vector::add(%opos,"0 12 22");
	addToSet("MissionCleanup", %objShip);
	addToSet("MissionCleanup/GunShip"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,%rot);
	Gamebase::setMapName(%objShip,%name @ " Radar");
	//%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("Generator","StaticShape",GunShipGen,false);
	%pos=Vector::add(%opos,"0 1.0 4.538");
	addToSet("MissionCleanup", %objShip);
	addToSet("MissionCleanup/GunShip"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,"0 0 1.57079");
	Gamebase::setMapName(%objShip,%name @ " Main Generator");
	//%rtime=(floor(getRandom()*150)/10) + 5;
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime+2);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime+2);
	GameBase::setActive(%objShip,True);

	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "GunShipPack"]++; 
	echo("MSG: ",%client," deployed a GunShip");
	return true; 
}

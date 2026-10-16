
$Vmodule[2] = "HellFire";
$Vmodule[3] = "DetPack";
$Vmodule[6] = "RamModule";
$Vmodule[8] = "WraithModule";

//=================================================
//					Scout
//=================================================
FlierData Scout
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 9.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.5;
	maxPitch = 0.8;
	maxSpeed = 70;
	minSpeed = -2;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 1;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 5;
	groundDamageScale = 1.0;
	//projectileType = FlierRocket;
	reloadDelay = 0.3;
	repairRate = 0;
	//fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;
	visibleDriver = true;
	driverPose = 22;
	description = "Scout";
};

function Scout::OnFire(%this)
{
	if (%this.refire) return;
	%client = gamebase::getcontrolclient(%this);
	%player = Client::getOwnedObject(%client);
	$los::object = false;
	GameBase::getLOSInfo(%this, 1000);
	%target = $los::object;
	Client::sendMessage(%client,1,"~wshell_hilite.wav");
	if (!%client.target || %client.target == "-1" || %client.target == %player || %client.target == %this)
	{
		%this.refire = 1;
		schedule ("" @ %this @ ".refire = 0;", 0.1);

		%type = getObjectType(%target);
		if (%type == -1 || %type == "" || %type == False || %type == "SimTerrain" || %type == "InteriorShape")
		{
			clearCenterPrint(%client);
			return;
		}
		else if (%client.targettime > 3)
		{
			if (gamebase::getteam(%target) == gamebase::getteam(%player) && %type != "Flier")
			{
				clearCenterPrint(%client);
				%client.target = -1;
				%clienttargettime = "";
				%client.tc = %target;
				return;
			}
			%client.target = %target;
			%client.targettime = "";
			%client.tc = "";
			schedule("Client::sendMessage(" @ %client @ ",0,\"~wmine_act.wav\");",0);
			schedule("centerprint(" @ %client @ ", \"<jc><f2>[    ]\", 1);", 0);
			schedule("centerprint(" @ %client @ ", \"<jc><f2> [  ]\", 4);", 1);
			schedule("centerprint(" @ %client @ ", \"<jc><f2>[    ]\", 1);", 5);
			schedule("centerprint(" @ %client @ ", \"<jc><f2>-    -\", 1);", 6);
			schedule("" @ %client @ ".target = \"-1\";", 6);
			centerprint(gamebase::getcontrolclient(%target), "<jc>>LOCK ALERT<", 1);
			Client::sendMessage(gamebase::getcontrolclient(%target),0,"~wLostTower.wav");
		}
		else
		{
			schedule("centerprint(" @ %client @ ", \"<jc>[    ]\", 1);", 0);
			%client.targettime++;
			return;
		}
		return;
	}
	else if (%client.target != "-1")
	{
		if (gamebase::getteam(%client.target) == gamebase::getteam(%player))
		{
			schedule("centerprint(" @ %client @ ", \"<jc>-    -\", 1);", 0);
			schedule("Client::sendMessage(" @ %client @ ",1,\"~wC_BuySell.wav\");",0);
			%client.target = -1;
			return;
		}
		%this.refire = 1;
		schedule ("" @ %this @ ".refire = 0;", 0.15);
		%trans = GameBase::getMuzzleTransform(%this);
		%vel = item::getVelocity(%flier);
		Projectile::spawnProjectile("ScoutMissile",%trans,%this,%vel,%client.target);
		schedule ("playSound(SoundFireMortar,GameBase::getPosition(" @ %player @ "));",0);
	}
}

//=================================================
//					Fighter
//=================================================
FlierData Fighter
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	groundDamageScale = 1.0;
	projectileType = RailRound;
	reloadDelay = 0.2;
	repairRate = 0;
	fireSound = SoundChainTurretFire;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;
	visibleDriver = true;
	driverPose = 22;
	description = "Fighter";
	mass = 5.0;
	drag = 0;
	density = 1.2;
	maxBank = 1.2;
	maxPitch = 1.2;
	maxSpeed = 50;
	minSpeed = -2;
	lift = 0.5;
	maxAlt = 100;
	accel = 5;
	maxVertical = 10;
	maxDamage = 1;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
};
	
//=================================================
//					Prowler
//=================================================
FlierData Prowler
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 9.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 1.2;
	maxPitch = 1.2;
	maxSpeed = 60;
	minSpeed = -15;
	lift = 1.10;
	maxAlt = 1550;
	maxVertical = 12;
	maxDamage = 1;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 1.2;
	groundDamageScale = 1.0;
	reloadDelay = 0.2;
	repairRate = 0.1;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;
	visibleDriver = true;
	driverPose = 22;
	description = "Prowler";
};

function Prowler::OnFire(%this)
{
	%client = gamebase::getcontrolclient(%this);
	%player = Client::getOwnedObject(%client);
	%module = %this.module;
	%modulename = $VModule[%module];

	if (!%module || %this.ammo == 0)
	{
		schedule ("" @ %this @ ".ammoout = 0;", 2.2);
		
		if (!%this.ammoout)
		{
			Client::sendMessage(%client,1,"Can not fire out of ammo or no module loaded. ~wError_Message.wav");
		}
		%this.ammoout = 1;
		%this.module = 0;
		%this.ammo = 0;		
		return;
	}
	
	if (%this.refire)
		return;
		
	if (%module == "2" && %this.ammo) //== Hell Fire Bombs
	{
		Client::sendMessage(%client,0,"~wflierRocket.wav");
		%vel = "0 0 0";
		%rot = gamebase::getrotation(%this); %dir = (Vector::getfromrot(%rot)); %dir = Vector::add(%dir, "0.2 0 0"); %trans =  %rot @ " " @ %dir @ " 0 0 0 " @ gamebase::getposition(%this);
		%fired = Projectile::spawnProjectile(Frag, %trans ,%this,%vel); %fired.deployer = %client;
		
		%rot = gamebase::getrotation(%this); %dir = (Vector::getfromrot(%rot)); %dir = Vector::add(%dir, "0 0 0"); %trans =  %rot @ " " @ %dir @ " 0 0 0 " @ gamebase::getposition(%this);
		%fired = Projectile::spawnProjectile(Frag, %trans ,%this,%vel); %fired.deployer = %client;
		
		%rot = gamebase::getrotation(%this); %dir = (Vector::getfromrot(%rot)); %dir = Vector::add(%dir, "-0.2 0 0"); %trans =  %rot @ " " @ %dir @ " 0 0 0 " @ gamebase::getposition(%this);
		%fired = Projectile::spawnProjectile(Frag, %trans ,%this,%vel); %fired.deployer = %client;
		
		%this.refire = 1;
		%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 3.0);
		return;
	}
	else if (%module == "3" && %this.ammo) //== DetPack
	{
		%team = GameBase::getTeam(%player);
		if ($TeamItemCount[%team @ "MfglAmmo"] <0 )
		{
			%obj = newObject("","Mine","Suicidebomb");
			%obj.deployer = %client;
			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,0,false);
			Client::setOwnedObject(%client, %player);
			%this.refire = 1;%this.ammo -= 1;
			schedule ("" @ %this @ ".refire = 0;", 2.0);
			$TeamItemCount[%team @ "MfglAmmo"]++;
		}
		else
		{
			bottomprint(%client, "<jc>Your team has " @ 0 - $TeamItemCount[%team @ "MfglAmmo"] @ " Nuclear Warheads available for use.");
			Client::sendMessage(%client,0,"~wError_Message.wav");
			%this.refire = 1;
			schedule ("" @ %this @ ".refire = 0;", 2.0);
		}
		return;
	}
	else if (%module == "6" && %this.ammo) //== Ram Module
	{
		bottomprint (%client, "<jc>Ram Armor Installed", 5);
		%this.refire = 1;
		schedule ("" @ %this @ ".refire = 0;", 120.0);
	}
	else if (%module == "8" && %this.ammo) //== Wraith Module
	{
		bottomprint (%client, "<jc>Cloaking Activated Automatically", 5);
		%this.refire = 1;
		schedule ("" @ %this @ ".refire = 0;", 120.0);
	}
	else
	{
		schedule ("" @ %this @ ".ammoout = 0;", 2.2);
		%this.ammoout = 1;
		if (!%this.ammoout)
		{
			Client::sendMessage(%client,1," VM - " @ %modulename @ " out of ammunition. Must Reload Module. ~wError_Message.wav");
		}
		%this.module = 0;
		%this.ammo = 0;
		return;
	}
}

//=============================================
//				LAPC (Bomber)
//=============================================
FlierData LAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "hover_apc_sml";
	shieldShapeName = "shield_large";
	mass = 22.0;
	drag = 1.2;
	density = 1.2;
	maxBank = 0.8;
	maxPitch = 0.8;
	maxSpeed = 30;
	minSpeed = -5;
	lift = 0.75;
	maxAlt = 1550;
	maxVertical = 9;
	maxDamage = 5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.5;
	maxEnergy = 100;
	accel = 0.35;

	groundDamageScale = 0.50;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";

	projectileType = ModuleBomb;
	reloadDelay = 4.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	fireSound = SoundFireGrenade;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
};

//=========================================
//				HAPC (GunShip)
//=========================================
FlierData HAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "hover_apc";
	shieldShapeName = "shield_large";
	mass = 25.0;
	drag = 1.6;
	density = 1.2;
	maxBank = 0.7;
	maxPitch = 0.5;
	maxSpeed = 45;								   
	minSpeed = -15;
	lift = 0.35;
	maxAlt = 1550;
	maxVertical = 6;
	maxDamage = 3;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.20;
	groundDamageScale = 0.125;
	reloadDelay = 2.0;
	repairRate = 0;
	ramDamage = 3;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;
	visibleDriver = true;
	driverPose = 23;
};

function HAPC::OnFire(%this)
{ 

	%client = gamebase::getcontrolclient(%this);
	%player = Client::getOwnedObject(%client);

	if (%this.refire)
		return;

	else
	{
		%rot = gamebase::getrotation(%this);
		%dir = (Vector::getfromrot(%rot));
		%vel = "0 0 0";

		%pos = Vector::add(GameBase::getPosition(%this), EmplacementPack::rotVector( "-5 6 3", GameBase::getRotation(%this)));
		%trans =  %rot @ " " @ %dir @ " 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(GodHammer, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0);

		%pos = Vector::add(GameBase::getPosition(%this), EmplacementPack::rotVector( "-2.5 6 3", GameBase::getRotation(%this)));
		%trans =  %rot @ " " @ %dir @ " 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(GodHammer, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0);

		%pos = Vector::add(GameBase::getPosition(%this), EmplacementPack::rotVector( "0 6 3", GameBase::getRotation(%this)));
		%trans =  %rot @ " " @ %dir @ " 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(GodHammer, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0);

		%pos = Vector::add(GameBase::getPosition(%this), EmplacementPack::rotVector( "2.5 6 3", GameBase::getRotation(%this)));
		%trans =  %rot @ " " @ %dir @ " 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(GodHammer, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0);

		%pos = Vector::add(GameBase::getPosition(%this), EmplacementPack::rotVector( "5 6 3", GameBase::getRotation(%this)));
		%trans =  %rot @ " " @ %dir @ " 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(GodHammer, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0);

		playSound(SoundPlasmaTurretFire, GameBase::getPosition(%this));
		
		%this.refire = 1;
		schedule ("" @ %this @ ".refire = 0;", 1.5);//0.8
		return;
	}
}
//=============================================
//				GAPC (Jerico)
//=============================================
FlierData GAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "hover_apc_sml";
	shieldShapeName = "shield_large";
	mass = 22.0;
	drag = 1.2;
	density = 1.2;
	maxBank = 0.8;
	maxPitch = 0.8;
	maxSpeed = 30;
	minSpeed = -5;
	lift = 0.75;
	maxAlt = 1550;
	maxVertical = 9;
	maxDamage = 6;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.5;
	maxEnergy = 100;
	accel = 0.35;

	groundDamageScale = 0;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";

	reloadDelay = 10.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	//fireSound = SoundFireGrenade;
	idleSound = SoundFlyerActive;
	moveSound = SoundElevatorRun;

	visibleDriver = true;
	driverPose = 23;
};

function GAPC::OnFire(%this)
{ 
	if (%this.refire)
		return;
	%client = gamebase::getcontrolclient(%this);
	%vel = item::getVelocity(%this);
	%velX= getWord(%vel,0);
	%velY= getWord(%vel,1);
	%velZ= getWord(%vel,2);
	if(%velX !=0 || %velY !=0 || %velZ >0.5 || %velZ <-0.65 || !GameBase::getLOSInfo(%this, 4, "-1.57 0 0"))
	{
		Client::sendMessage(%client,0,"~wAccess_Denied.wav");
		centerprint(%client, "<jc>Jerico cannot deploy while in motion",3);
		return;
	}
	%player = Client::getOwnedObject(%client);
 	%pos = GameBase::getPosition(%this);
	%this.refire = 1;

	%player.lastMount = %this;
	%player.newMountTime = getSimTime() + 3.0;
	Player::setMountObject(%player, -1, 0);
	%rot = GameBase::getRotation(%this);
	%rotZ = getWord(%rot,2);
	GameBase::setRotation(%player, "0 0 " @ %rotZ);
	Client::setControlObject(%client, %player);
	playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
				
	if(%player.lastWeapon != "")
	{
		Player::useItem(%player,%player.lastWeapon);		 	
		%player.lastWeapon = "";
	}
	%player.driver = "";
	%client.driver = "";
	%player.vehicle = "";
	%this.driver = "";

	playSound(SoundElevatorStart,%pos);
	%name = Client::getName(%client);
	%rot = GameBase::getRotation(%this);
	%team = GameBase::getTeam(%this);

	%beam1 = newObject("JericoPower", "StaticShape", "SolarPanel", true);
	addToSet("MissionCleanup", %beam1);
	GameBase::setPosition(%beam1,"0 0 -2000");
	Gamebase::setMapName(%beam1,"Jerico Power");
	GameBase::setTeam(%beam1,%team);

	%beam2 = newObject("JericoSupply", "StaticShape", "InventoryStation", true);
	addToSet("MissionCleanup", %beam2);
	GameBase::setRotation(%beam2,Vector::add(%rot, "-1.57 0 0" ));
	GameBase::setPosition(%beam2,Vector::add(%pos, "0 -5.3 0" ));
	Gamebase::setMapName(%beam2,"Jerico Supply");
	GameBase::setTeam(%beam2,%team);

	%beam3 = newObject("JericoCommand", "StaticShape", "CommandStation", true);
	addToSet("MissionCleanup", %beam3);
	GameBase::setRotation(%beam3,Vector::add( %rot, "0 0 -1.57"));
	GameBase::setPosition(%beam3,Vector::add(%pos, EmplacementPack::rotVector( "-2.8 -5.7 -1.7", %rot)));
	Gamebase::setMapName(%beam3,"Jerico Station");
	GameBase::setTeam(%beam3,%team);

	%beam4 = newObject("JericoPower", "Turret", "MortarTurret", true);
	addToSet("MissionCleanup", %beam4);
	GameBase::setRotation(%beam4,%rot);
	GameBase::setPosition(%beam4,%pos);
	Gamebase::setMapName(%beam4,"Jerico Turret");
	GameBase::setTeam(%beam4,%team);

	%beam5 = newObject("JericoSwitch", "StaticShape", "JericoSwitch", true);
	addToSet("MissionCleanup", %beam5);
	GameBase::setPosition(%beam5,Vector::add(%pos, EmplacementPack::rotVector( "1.8 -2.5 0.7", %rot)));
	Gamebase::setMapName(%beam5,"Jerico Switch");
	GameBase::setTeam(%beam5,%team);

	%this.beam1= %beam1;
	%this.beam2= %beam2;
	%this.beam3= %beam3;
	%this.beam4= %beam4;
	%this.beam5= %beam5;
	%beam5.beam= %this;

	if (Client::getGender(%client) == "Female") TeamMessages(3, %team, %name @ ": Jerico Deployed!~wfemale3.wattbase.wav");
	else TeamMessages(3, %team, %name @ ": Jerico Deployed!~wmale3.wattbase.wav");

	%posA = Vector::add(%pos, EmplacementPack::rotVector( "0 -5.3 -0.25", %rot));
	%posB = Vector::add(%pos, EmplacementPack::rotVector( "0 -5.3 -0.5", %rot));
	%posC = Vector::add(%pos, EmplacementPack::rotVector( "0 -5.3 -0.75", %rot));
	%posD = Vector::add(%pos, EmplacementPack::rotVector( "0 -5.3 -1", %rot));
	%posE = Vector::add(%pos, EmplacementPack::rotVector( "0 -5.3 -1.25", %rot));
	%posF = Vector::add(%pos, EmplacementPack::rotVector( "0 -5.3 -1.5", %rot));
	%posG = Vector::add(%pos, EmplacementPack::rotVector( "0 -5.3 -1.75", %rot));
	%posH = Vector::add(%pos, EmplacementPack::rotVector( "0 -5.3 -2", %rot));
	schedule("GameBase::setPosition("@%beam2@",\""@%posA@"\");",0.2);
	schedule("GameBase::setPosition("@%beam2@",\""@%posB@"\");",0.4);
	schedule("GameBase::setPosition("@%beam2@",\""@%posC@"\");",0.6);
	schedule("GameBase::setPosition("@%beam2@",\""@%posD@"\");",0.8);
	schedule("GameBase::setPosition("@%beam2@",\""@%posE@"\");",1);
	schedule("GameBase::setPosition("@%beam2@",\""@%posF@"\");",1.2);
	schedule("GameBase::setPosition("@%beam2@",\""@%posG@"\");",1.4);
	schedule("GameBase::setPosition("@%beam2@",\""@%posH@"\");",1.6);

	%rotA = Vector::add(%rot, "-1.37 0 0");
	%rotB = Vector::add(%rot, "-1.17 0 0");
	%rotC = Vector::add(%rot, "-0.97 0 0");
	%rotD = Vector::add(%rot, "-0.77 0 0");
	%rotE = Vector::add(%rot, "-0.57 0 0");
	%rotF = Vector::add(%rot, "-0.37 0 0");
	%rotG = Vector::add(%rot, "-0.17 0 0");
	%rotH = Vector::add(%rot, "0 0 0");
	schedule("GameBase::setRotation("@%beam2@",\""@%rotA@"\");",0.2);
	schedule("GameBase::setRotation("@%beam2@",\""@%rotB@"\");",0.4);
	schedule("GameBase::setRotation("@%beam2@",\""@%rotC@"\");",0.6);
	schedule("GameBase::setRotation("@%beam2@",\""@%rotD@"\");",0.8);
	schedule("GameBase::setRotation("@%beam2@",\""@%rotE@"\");",1);
	schedule("GameBase::setRotation("@%beam2@",\""@%rotF@"\");",1.2);
	schedule("GameBase::setRotation("@%beam2@",\""@%rotG@"\");",1.4);
	schedule("GameBase::setRotation("@%beam2@",\""@%rotH@"\");",1.6);

	%posI = Vector::add(%pos, "0 0 0.25");
	%posJ = Vector::add(%pos, "0 0 0.5");
	%posK = Vector::add(%pos, "0 0 0.75");
	%posL = Vector::add(%pos, "0 0 1");
	%posM = Vector::add(%pos, "0 0 1.25");
	%posN = Vector::add(%pos, "0 0 1.5");
	%posO = Vector::add(%pos, "0 0 1.75");
	%posP = Vector::add(%pos, "0 0 2");
	schedule("GameBase::setPosition("@%beam4@",\""@%posI@"\");",0.2);
	schedule("GameBase::setPosition("@%beam4@",\""@%posJ@"\");",0.4);
	schedule("GameBase::setPosition("@%beam4@",\""@%posK@"\");",0.6);
	schedule("GameBase::setPosition("@%beam4@",\""@%posL@"\");",0.8);
	schedule("GameBase::setPosition("@%beam4@",\""@%posM@"\");",1);
	schedule("GameBase::setPosition("@%beam4@",\""@%posN@"\");",1.2);
	schedule("GameBase::setPosition("@%beam4@",\""@%posO@"\");",1.4);
	schedule("GameBase::setPosition("@%beam4@",\""@%posP@"\");",1.6);
}

//========================================
//			Other Funcs
//=======================================

function Vehicle::onAdd(%this)
{ 
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");	
}

function Vehicle::onCollision (%this, %object)
{
	%data = GameBase::getDataName(%this);
	%client = Player::getClient(%object);
	%armor = Player::getArmor(%object);
	%module = $Vmodule[%this.module];
	
	if(%object.Station != "")
	{
		Client::sendMessage(%client,0,"You must leave the Inventory Station to pilot the vehicles.~wError_Message.wav");
		return;
	}
	
	if(%data.shapefile == "discb")
	{
		GameBase::setDamageLevel(%this, 10);
		return;
	}	
	else if(%data.shapefile == "rocket")
	{	
		GameBase::setDamageLevel(%this, 10);
		return;
	}
	//====================================== Loading Prowler
	else if (%data == Prowler && (!%this.module || %this.module == "0") && getObjectType(%object) == "Player")
	{
		if (Player::getItemCount(%object, HellFireModule) && !%this.module)
		{
			Client::sendMessage(%client,0,"HellFire Module Loaded.");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::setItemCount(%client,HellFireModule, 0);
			%this.module = 2;		
			%this.ammo = 15;
			return;
		}
		else if (Player::getItemCount(%object, DetPackModule) && !%this.module)
		{
			Client::sendMessage(%client,0,"DetPack Module Loaded.");
			if (Client::getGender(%client) == "Female") TeamMessages(3, GameBase::getTeam(%object), Client::getName(%client) @ ": Kamikazi Plane! Take Cover!~wfemale5.wtakcovr.wav");
			else TeamMessages(3, GameBase::getTeam(%object), Client::getName(%client) @ ": Kamikazi Plane! Take Cover!~wmale4.wtakcovr.wav");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::setItemCount(%client,DetPackModule, 0);
			%this.module = 3;
			%this.ammo = 1;
			return;
		}

		else if (Player::getItemCount(%object, WraithModule) && !%this.module)
		{
			Client::sendMessage(%client,0,"Wraith Module Loaded.");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::setItemCount(%client,WraithModule, 0);	
			%this.module = 8;
			%this.ammo = 4;
			return;
		}
		else if (Player::getItemCount(%object, RamModule) && !%this.module)
		{
			Client::sendMessage(%client,0,"Ram Module Loaded.");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::setItemCount(%client,RamModule, 0);	
			%this.module = 6;
			%this.ammo = 1;
			return;
		}
	}
	else if (%this.module)
	{
		Client::sendMessage(%client,1," Loaded With VM - " @ %module @ ".");
	}
	if(GameBase::getDamageLevel(%this) < %data.maxDamage)
	{
		if (getObjectType (%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
		{
			if ((%armor == "larmor" || %armor == "lfemale" || %armor == "sarmor" || %armor == "sfemale" || %armor == "spyarmor" || %armor == "spyfemale" || %armor == "stimarmor" || %armor == "stimfemale" || %armor == "rarmor") && Vehicle::canMount (%this, %object) && %data != GAPC)
			{
				%weapon = Player::getMountedItem(%object,$WeaponSlot);

				if(%weapon != -1)
				{
					%object.lastWeapon = %weapon;
					Player::unMountItem(%object,$WeaponSlot);
				}
				
				if((%this.module == 8 && %this.ammo) || %data == LAPC)
				{
					GameBase::startFadeout(%this);
					GameBase::startFadeout(%object);
					%client.module = 8;
					%rate = Player::getSensorSupression(%object) + 100;
					Player::setSensorSupression(%object,%rate);
					Player::setSensorSupression(%client,%rate);
					Player::setSensorSupression(%this,%rate);
					%this.ammo -= 1;
				}
				else if(%this.module == 8 && !%this.ammo)
				{
					%this.module = 0;
				}
				
				Player::setMountObject(%object, %this, 1);
				Client::setControlObject(%client, %this);
				
				playSound (%data.mountSound, GameBase::getPosition(%this));
				%object.driver = 1;
				%object.vehicle = %this;
				%client.driver = 1;
				%this.driver = 1;
				%this.clLastMount = %client;
				Vehicle::SetSmoke(%this);//==driver starting up vehicle
			}
			else if ((%armor == "aarmor" || %armor == "afemale" || %armor == "barmor" || %armor == "bfemale" || %armor == "earmor" || %armor == "efemale" || %armor == "harmor" || %armor == "jarmor" || %armor == "marmor" || %armor == "mfemale") && Vehicle::canMount (%this, %object) && %data == GAPC && !%this.refire)
			{
				%weapon = Player::getMountedItem(%object,$WeaponSlot);

				if(%weapon != -1)
				{
					%object.lastWeapon = %weapon;
					Player::unMountItem(%object,$WeaponSlot);
				}
				
				Player::setMountObject(%object, %this, 1);
				Client::setControlObject(%client, %this);
				
				playSound (%data.mountSound, GameBase::getPosition(%this));
				%object.driver = 1;
		            %object.vehicle = %this;
		            %client.driver = 1;
				%this.driver = 1;
				%this.clLastMount = %client;
				Vehicle::SetSmoke(%this);//===Driver starting up vehicle
			}
			else if((%data != Scout) && (%data != Prowler) && (%data != Fighter))  
			{
				%mountSlot= Vehicle::findEmptySeat(%this,%client); 
				if(%mountSlot) 
				{
					%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					Player::setMountObject(%object, %this, %mountSlot);
					%driverClient = GameBase::getControlClient(%this);
					if(Client::getTeam(%driverClient) == GameBase::getTeam(%object))
					{
						if (Client::getGender(%client) == "Female") Client::sendMessage(%driverClient,3,Client::getName(%client) @ ": Thanks for the lift.~wfemale2.whello.wav");
						else Client::sendMessage(%driverClient,3,Client::getName(%client) @ ": Ready to ride, let's pull pitch.~wmale2.wproceed.wav");
					}
					else Client::sendMessage(%driverClient,1,"Hostile Boarding: " @ Client::getName(%client) @ "~wfemale5.wincom2.wav");
					playSound (%data.mountSound, GameBase::getPosition(%this));
					if(%data == HAPC)
					{
						Player::unMountItem(%object,$WeaponSlot);
						Player::mountItem(%client, FlyerGun, $WeaponSlot);
					}
					if ((%armor == "larmor" || %armor == "lfemale" || %armor == "sarmor" || %armor == "sfemale" || %armor == "spyarmor" || %armor == "spyfemale" || %armor == "stimarmor" || %armor == "stimfemale" || %armor == "rarmor") && %data == GAPC) Client::sendMessage(%client,1,"Light armors can't pilot the Jerico HoverCraft.");
				}
				else if (GameBase::getControlClient(%this) == -1 && %data == GAPC) 				{
					if (%this.beam1) Client::sendMessage(%client,1,"This hover craft cannot be driven while it is deployed.~wError_Message.wav");
					else Client::sendMessage(%client,1,"Light armors can't pilot the Jerico HoverCraft.~wError_Message.wav");
				}
			}
			else if (GameBase::getControlClient(%this) == -1) Client::sendMessage(%client,1,"You must be in Light Armor to pilot the vehicles.~wError_Message.wav");
		}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{ 
	if(GameBase::getDataName(%this) == HAPC)
		%numSlots = 4;
	else
		%numSlots = 2;
	
	%count=0;
	
	for(%i=0;%i<%numSlots;%i++)  
		if(%this.Seat[%i] == "")
		{
			%slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
			%slotVal[%count] = %i+2;
			%lastEmpty = %i+2;
			%count++;
		}
	if(%count == 1)
	{
		%this.Seat[%lastEmpty-2] = %client;
		return %lastEmpty;
	}
	else if (%count > 1)
	{
		%freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
		%this.Seat[%freeSlot-2] = %client;
		return %freeSlot;
	}
	else
		return "False";
}

function getClosestPosition(%num,%playerPos,%slotPos0,%slotPos1,%slotPos2,%slotPos3)
{ 
	%playerX = getWord(%playerPos,0);
	%playerY = getWord(%playerPos,1);

	for(%i = 0 ;%i<%num;%i++)
	{
		%x = (getWord(%slotPos[%i],0)) - %playerX;
		%y = (getWord(%slotPos[%i],1)) - %playerY;
		if(%x < 0)
			%x *= -1;
		if(%y < 0)
			%y *= -1;
		%newDistance = sqrt((%x*%x)+(%y*%y));
		if(%newDistance < %distance || %distance == "")
		{
	  		%distance = %newDistance;			
			%closePos = %i;	
		}
	}		
	return %closePos;
}

function Vehicle::passengerJump(%this,%passenger,%mom)
{ 
	%armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale")
	{
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale")
	{
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor")
	{
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}
	else
	{	
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	
	%pos = GameBase::getPosition(%passenger);

	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height)))
	{
		if(GameBase::getDataName(%this) == HAPC) Player::unMountItem(%passenger,$WeaponSlot);
		%client = Player::getClient(%passenger);
		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
	   	%passenger.vehicle= "";
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
		if (Client::getGender(%client) == "Female") Client::sendMessage(GameBase::getControlClient(%this),3,Client::getName(%client) @ ": This is my stop, call me some time.~wfemale3.wbye.wav");
		else Client::sendMessage(GameBase::getControlClient(%this),3,Client::getName(%client) @ ": I'm out, catch you later.~wmale2.wcoverme.wav");
	}
	else
		Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}

function Vehicle::jump(%this,%mom)
{ 
	%data = GameBase::getDataName(%this);
	
	if(%data.shapefile == "rocket")
	{
		%data = GameBase::getDataName(%o);
		GameBase::setDamageLevel(%this, 10);
	}
  	Vehicle::dismount(%this,%mom);
}

function Vehicle::dismount(%this,%mom)
{ 
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1)
	{
	      %pl = Client::getOwnedObject(%cl);
	      if(getObjectType(%pl) == "Player")
	      {
			Player::setSensorSupression(%pl,0);

			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0)))
			{
				%pl.lastMount = %this;
				%client = player::getClient(%pl);
				%pl.newMountTime = getSimTime() + 3.0;
				Player::setMountObject(%pl, %this, 0);
				Player::setMountObject(%pl, -1, 0);
				%rot = GameBase::getRotation(%this);
				%rotZ = getWord(%rot,2);
				GameBase::setRotation(%pl, "0 0 " @ %rotZ);
				Player::applyImpulse(%pl,%mom);
				Client::setControlObject(%cl, %pl);
				playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
				
				if(%pl.lastWeapon != "")
				{
					Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";
				}
				%pl.driver = "";
				%client.driver = "";
				%pl.vehicle = "";
				%this.driver = "";
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
	}
	if(%this.module == 8)
	{
		GameBase::startFadeIn(%this);
		GameBase::startFadeIn(%pl);
		%rate = Player::getSensorSupression(%pl) - 100;
		Player::setSensorSupression(%pl,%rate);
		Player::setSensorSupression(%client,%rate);
		Player::setSensorSupression(%this,%rate);
	}
}

function Vehicle::onDestroyed (%this,%mom) 
{
	StaticShape::objectiveDestroyed(%this);
 	%this.driver = "";
	%data = GameBase::getDataName(%this);

	if (%this.missilegone == 1 && (%data.shapefile=="rocket" || %data.shapefile=="disc"))
	{
		%this.missilegone = 0;
		return;
	}
	else{}

 	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
 	
 	%cl = GameBase::getControlClient(%this);
 	%pl = Client::getOwnedObject(%cl);
 	Client::setOwnedObject(%cl, %this);
	Client::setOwnedObject(%cl, %pl);
	if(%this.module == 8)
	{
		%this.module = "";
		GameBase::startFadeIn(%pl);
		%rate = Player::getSensorSupression(%pl) - 100;
		Player::setSensorSupression(%pl,%rate);
		Player::setSensorSupression(%cl,%rate);
		Player::setSensorSupression(%this,%rate);		
	}
	if(%data == gapc && %this.refire)
	{
		schedule("deleteobject("@%this.beam1@");",0);
		schedule("deleteobject("@%this.beam2@");",0);
		schedule("deleteobject("@%this.beam3@");",0);
		schedule("deleteobject("@%this.beam4@");",0);
		schedule("deleteobject("@%this.beam5@");",0);	
	}
 	if(%pl != -1)
 	{
 		Player::setMountObject(%pl, -1, 0);
 		Client::setControlObject(%cl, %pl);
		if(%pl.lastWeapon != "")
		{
			Player::useItem(%pl,%pl.lastWeapon);
			%pl.lastWeapon = "";
		}
		%pl.driver = "";
		%cl.driver = "";
 	}
 	for(%i = 0 ;%i < 4 ;%i++) if(%this.Seat[%i] != "")
 	{
		%c = %this.Seat[%i];
		%pl = Client::getOwnedObject(%c);
		Player::setMountObject(%pl, -1, 0);
		Client::setControlObject(%c, %pl);
		Player::unMountItem(%c, $WeaponSlot);
	}

	if(%data.shapefile == "rocket")
	{
		%pos = GameBase::getPosition(%this);

		if (%this.popped == "1")
		{
			%this.popped = "";
			bottomprint(%cl, "<jc><f2>You've been JAMMED! ", 5);
			return;
		}

		if (%this.missilegone != 1) { %this.missilegone = 1; }
		else { return; }

		if (%data == NapProj)
		{
			%cl.missilekill = 1;
			schedule(%cl @ ".missilekill = 0;",20);

			Aoe::deployShape(%this, 35, $PlasmaDamageType, 10, %cl, 0.32);
			DeployFrags(%this, 10, %pl);
			GameBase::applyRadiusDamage($PlasmaDamageType, %pos, 25, 0.50, 345, %pl);
		}
		else if (%data == EmpProj)
		{
			%cl.missilekill = 1;
			schedule(%cl @ ".missilekill = 0;",20);
			%obj = newObject("","Mine","EMPBlast");
			GameBase::throw(%obj,%cl,0,false);		
			addToSet("MissionCleanup", %obj);
			%padd = "0 0 3.5";
			%pos = Vector::add(%pos, %padd);
			GameBase::setPosition(%obj, %pos);

			%obj = newObject("","Mine","EMPBlast");
			GameBase::throw(%obj,%cl,0,false);		
			addToSet("MissionCleanup", %obj);
			%padd = "0 0 3.5";
			%poss = Vector::add(%pos, %padd);
			GameBase::setPosition(%obj, %poss);					
			Client::setOwnedObject(%cl, %pl);

			Aoe::deployShape(%this, 18, $FlashDamageType, 15, %cl, 0.25);
			GameBase::applyRadiusDamage($FlashDamageType, %pos, 20, 0.75, 300, %pl);
		}
		else if (%data == GasProj)
		{
			%cl.missilekill = 1;
			schedule(%cl @ ".missilekill = 0;",20);
			Aoe::deployShape(%this, 35, $EnergyDamageType, 25, %cl, 0.30);
			GameBase::applyRadiusDamage($EnergyDamageType, %pos, 30, 0.55, 175, %pl);
		}
		else if (%data == BooProj)
		{
			%cl.missilekill = 1;
			schedule(%cl @ ".missilekill = 0;",20);
			Aoe::deployShape(%this, 35, $NukeDamageType, 10, %cl, 0.55);	                
			GameBase::applyRadiusDamage($NukeDamageType, %pos, 6, 5.80, 50, %pl);
		}
		else if (%data == SpyPodProj)
		{
			GameBase::applyRadiusDamage($MissileDamageType, %pos, 10, 1.52, 15, %pl);
		}
		else if (%data == BallProj)
		{
			%passanger = $CBall[GameBase::getTeam(%this)];
			%cl.missilekill = 1;
			schedule(%cl @ ".missilekill = 0;",20);
			Player::setMountObject(%passanger, -1, 0);
			GameBase::setPosition(%passanger,%pos);
			%vel = Item::getVelocity(%this);
			Item::setVelocity(%passanger, %vel);
			$CBall[GameBase::getTeam(%this)] = "";
		}			
		else	
		{
			%cl.missilekill = 1;
			schedule(%cl @ ".missilekill = 0;",20);
			GameBase::applyRadiusDamage($MissileDamageType, %pos, 8, 1.0, 600, %pl);
		}
	
	}
	else
	{
		GameBase::applyDamage(%this,$DebrisDamageType,2.5,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100);
	}
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   	if (%object != "0" && %object != -1)
   	{
   		if (gamebase::getownerclient(%object) != "-1")
   			%this.lastDamageObject = client::getownedobject(gamebase::getownerclient(%object));
		else
   			%this.lastDamageObject = %object;
   	}
	%module = %this.module;
	if (%module == "6" && (%type == $ImpactDamageType || %type == $DebrisDamageType))
	{
		%client = GameBase::getControlClient(%this);
		bottomprint(%client, "<jc><f1>* <f2>* <f1>* <f0>R A M <f1>* <f2>* <f1>*", 1);
		schedule ("playSound(SoundFlierCrash,GameBase::getPosition(" @ %this @ "));",0);
		%module = %object.module;
		if (%module == "6" && %this != %object)
		{
			%client = GameBase::getControlClient(%object);
			schedule("Grenade::Plastic_Detonate("@%object@");",0);
			schedule("bottomprint(" @ %client @ ",\"<jc><f1>* <f2>* <f1>* <f0>RAM-TO-RAM COLLISION <f1>* <f2>* <f1>*\");",0.5);
		}
		return;
	}
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	if (!%this.smoking)
	{
		%data = GameBase::getDataName(%this);
		if( GameBase::getDamageLevel(%this) > (%data.maxDamage * 0.40) )
			Vehicle::SetSmoke(%this);
	}
}

function Vehicle::getHeatFactor(%this)
{
   	return 1.0;
}


//================================================================================
//====================Vehicle Smoke Trails Data===================================
//================================================================================
MineData VehicleSmoke
{
	className = "Mine";
   	description = "smoke";
   	shapeFile = "smoke";
   	shadowDetailMask = 4;
   	explosionId = vehiclesmokeExp;
	explosionRadius = 0.1;
	damageValue = 0;
	kickBackStrength = 0;
	triggerRadius = 0;
	maxDamage = 0.5;
	collideWithOwner   = False;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};
function VehicleSmoke::onAdd(%this) {schedule("Mine::Detonate(" @ %this @ ");",0.2,%this); }

MineData VehicleFire
{
	className = "Mine";
   	description = "fire";
   	shapeFile = "plasmabolt";
   	shadowDetailMask = 4;
   	explosionId = onFireExp;
	explosionRadius = 0.1;
	damageValue = 0;
	kickBackStrength = 0;
	triggerRadius = 0;
	maxDamage = 0.5;
	collideWithOwner   = False;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};
function VehicleFire::onAdd(%this) { schedule("Mine::Detonate(" @ %this @ ");",0.2,%this); }

function Vehicle::SetSmoke(%this)
{
	if(%this.fading != "")
	{
		Schedule("Vehicle::SetSmoke(" @ %this @ ");", 1, %this);
		return;
	}
	else if (!%this.fading)
	{
		Vehicle::CheckSmoke(%this);
	}
}

function Vehicle::CheckSmoke(%this)
{
	if (%this.driver != 1)
		return;
	%data = GameBase::getDataName(%this);
	$dmg = GameBase::getDamageLevel(%this);
	if( %dmg < (%data.maxDamage * 0.35) && (%data == LAPC || %data == HAPC || %data == Scout || %data == Prowler || %data == Fighter) )
	{
		%this.smoking = "";
		return;
	}

	if( %dmg > (%data.maxDamage * 0.65) )
		{%proj = "VehicleFire";}
	else if( %dmg > (%data.maxDamage * 0.35) )
		{%proj = "VehicleSmoke";}

	if(%vel == "0 0 0")
	{
		Schedule("Vehicle::CheckSmoke(" @ %this @ ");", 2, %this);
		return;
	}
	else
	{
		%this.smoking = 1;
		%thisPos = GameBase::getPosition(%this);
		%thisRot = GameBase::getRotation(%this);

		if (%data == LAPC || %data == HAPC)
		{
			if (%rnd = (floor(getRandom() * 10)+1) > 3)
			{
				%frot = EmplacementPack::rotVector( "1.5 0 0", %thisRot);
				%obj = newObject("","Mine",%proj);
				addToSet("MissionCleanup", %obj);
				GameBase::setPosition(%obj,Vector::add(%thisPos , %frot));
			}
			else if (%proj == "VehicleFire")
			{
				%frot = EmplacementPack::rotVector( "2.5 0 0", %thisRot);
				%obj = newObject("","Mine","VehicleSmoke");
				addToSet("MissionCleanup", %obj);
				GameBase::setPosition(%obj,Vector::add(%thisPos , %frot));
			}
			
			if (%rnd = (floor(getRandom() * 10)+1) > 3)
			{
				%frot = EmplacementPack::rotVector( "-1.5 0 0", %thisRot);
				%obj = newObject("","Mine",%proj);
				addToSet("MissionCleanup", %obj);
				GameBase::setPosition(%obj,Vector::add(%thisPos , %frot));
			}
			else if (%proj == "VehicleFire")
			{
				%frot = EmplacementPack::rotVector( "-2.5 0 0", %thisRot);
				%obj = newObject("","Mine","VehicleSmoke");
				addToSet("MissionCleanup", %obj);
				GameBase::setPosition(%obj,Vector::add(%thisPos , %frot));
			}
		}
		else if (%data == GAPC)
		{
			%obj = newObject("","Mine",VehicleSmoke);
			addToSet("MissionCleanup", %obj);
			GameBase::setPosition(%obj,%thisPos);
			if (!GameBase::getLOSInfo(%this, 10, "-1.57 0 0"))
			{
				if (!GameBase::getLOSInfo(%this, 25, "-1.57 0 0"))
				{
					%Mask = $StaticObjectType|$SimInteriorObjectType;
					%set=newObject("set",SimSet);
					containerBoxFillSet(%set,%Mask, Vector::add(%thisPos, "0 0 -5") ,10,10,10,0);
					%num = Group::objectCount(%Set);
					deleteObject(%set);
					if (!%num)
					{
						GameBase::setPosition(%this,Vector::add(%thisPos , "0 0 -5"));
					}
				}
				else
				{
					%Mask = $StaticObjectType|$SimInteriorObjectType;
					%set=newObject("set",SimSet);
					containerBoxFillSet(%set,%Mask,Vector::add(%thisPos, "0 0 -2") ,10,10,5,0);
					%num = Group::objectCount(%Set);
					deleteObject(%set);
					if (!%num) GameBase::setPosition(%this,Vector::add(%thisPos,"0 0 -2"));
				}
			}
		}
		else if (%data == Scout)
		{
			if (%rnd = (floor(getRandom() * 10)+1) > 3)
			{			
				%thisPos = GameBase::getPosition(%this);
				%frot = EmplacementPack::rotVector( "0 -3 1.35", GameBase::getRotation(%this));

				%obj = newObject("","Mine",%proj);
				addToSet("MissionCleanup", %obj);
				GameBase::setPosition(%obj,Vector::add(%thisPos , %frot));
			}
			%thisPos = GameBase::getPosition(%this);
			%frot = EmplacementPack::rotVector( "0 -3 1.35", GameBase::getRotation(%this));

			%obj = newObject("","Mine",%proj);
			addToSet("MissionCleanup", %obj);
			GameBase::setPosition(%obj,Vector::add(%thisPos , %frot));
		}
		else
		{
			%thisPos = GameBase::getPosition(%this);

			%frot = EmplacementPack::rotVector( "0 0 0", GameBase::getRotation(%this));
			%obj = newObject("","Mine","VehicleSmoke");
			addToSet("MissionCleanup", %obj);
			GameBase::setPosition(%obj,Vector::add(%thisPos , %frot));

			%frot = EmplacementPack::rotVector( "0 0 0", GameBase::getRotation(%this));
			%obj = newObject("","Mine","VehicleSmoke");
			addToSet("MissionCleanup", %obj);
			GameBase::setPosition(%obj,Vector::add(%thisPos , %frot));
		}

		Schedule("Vehicle::CheckSmoke(" @ %this @ ");", 0.1, %this);
	}
}
//===================================================
//============== Inveigler
//===================================================

FlierData Inveigler
{		
	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
	className = "Vehicle";
	shapeFile = "logo";
	mass = 9.0;
	drag = 2.5;
	density = 1.2;
	maxBank = 50;
	maxPitch = 500;
	maxSpeed = 10;
	maxSideSpeed = 2;
	minSpeed = -10;
	lift = 0;
	maxAlt = 150;
	maxVertical = 20;
	maxDamage = 0.2;
	maxEnergy = 50;
	projectileType = TranqDart;
	reloadDelay = 2;
	repairRate = 0;
	fireSound = Soundthrowitem;
	damageLevel = {1.0, 1.0};
	accel = 1.0;
	groundDamageScale = 0.001;
	damageSound = SoundFlierCrash;
	ramDamage = 0.0001;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	moveSound = SoundInveig;
	visibleDriver = true;
	driverPose = 22;
	description = "Inveigler";
};
function Inveigler::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	%l = GameBase::getControlClient(%this);
	Client::setControlObject(%l, %l);
	Client::sendMessage(%l,1,"Your Inveigler was killed!~wError_Message.wav"); 
	$TeamItemCount[GameBase::getTeam(%this) @ "InveiglerPack"]--;
}

function Inveigler::jump(%this,%mom)
{
	%client = GameBase::getControlClient(%this);
	Client::sendMessage(%client,0,"Inveigler released");
	GameBase::setDamageLevel(%this, 10);
}

function Inveigler::onCollision(%this,%player)
{
	if (getObjectType(%player) == "Player")
	{
		%client = Player::getClient(%player);
		%thf = Client::getName(%client);
		%looser = GameBase::getControlClient(%this);
		%lsrnm = Client::getName(%looser);
		if (%client == %looser || %lsrnm == "" || GameBase::getTeam(%this) == GameBase::getTeam(%player)) {}
		else
		{
			Client::sendMessage(%looser,0,"You invade and possess " @ %thf @ "'s body!~wflag1.wav");
			centerprint(%client, "                          <Bskull_big.bmp> You have been possessed! <Bskull_big.bmp>");
			Client::sendMessage(%client,1, %lsrnm @ " invades your body!~wplayer_death.wav");
			Client::setControlObject(%looser, %client); 
			GameBase::setDamageLevel(%this, 10);
		}
	}
}

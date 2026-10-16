
$Vmodule[1] = "Napalm";
$Vmodule[2] = "HellFire";
$Vmodule[3] = "DetPack";
$Vmodule[4] = "Bomber";
$Vmodule[5] = "PickUp";
$Vmodule[6] = "Mine Net";
$Vmodule[7] = "Stealth Module";
$Vmodule[8] = "Wraith Module";
$Vmodule[9] = "InterceptorModule";
$Vmodule[10] = "GodHammerModule";

//===================================================================================================================
//													Scout
//===================================================================================================================
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
	maxBank = 1.2;
	maxPitch = 1.2;
	maxSpeed = 60;
	minSpeed = -10;
	lift = 1.07;
	maxAlt = 1550;
	maxVertical = 12;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 1.2;

	projectileType = "Undefined";
	groundDamageScale = 1.0;

	projectileType = "Undefined";
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
};

function Scout::OnFire(%this)
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
		
	if (%module == "1" && %this.ammo) //== Napalm
	{
		%this.refire = 1;
		%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 1.5);
		return;
	}
	else if (%module == "2" && %this.ammo) //== Hell Fire Bombs
	{
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
		for (%i = 0; %i < 8; %i++)
		{
			%frag = "Frag" @ (floor(getRandom()*3)+1);
			%obj = newObject("","Mine", %frag);
			%obj.deployer = %client;

			if ((floor(getRandom()*4)+1) > 2)
			{
				%dir = -130;
				GameBase::throw(%obj,%client,%dir,false);

			}
			else
			{
				%dir = -70;
				GameBase::throw(%obj,%client,%dir,false);
			}

			addToSet("MissionCleanup", %obj);
		}
	

		%obj1 = newObject("","Mine","NRing1");
		addToSet("MissionCleanup", %obj1);
		%obj2 = newObject("","Mine","NCloud5");
		addToSet("MissionCleanup", %obj2);
		%obj3 = newObject("","Mine","HavocBlast");
		addToSet("MissionCleanup", %obj3);

		GameBase::throw(%obj1,%client,0,false);		
		GameBase::throw(%obj2,%client,0,false);	
		GameBase::throw(%obj3,%client,0,false);		
		Client::setOwnedObject(%client, %player);
		GameBase::applyRadiusDamage($BlasterDamageType, getBoxCenter(%this), 6, 5.80, 50, %pl);
				
		%this.refire = 1;%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 2.0);
		return;
	}
	else if (%module == "4" && %this.ammo) //== Bomber
	{
		%rot = gamebase::getrotation(%this);
		%dir = (Vector::getfromrot(%rot));
		%dir = Vector::add(%dir, "0 0 0");
		%trans =  %rot @ " " @ %dir @ " 0 0 0 " @ gamebase::getposition(%this);
		%fired = Projectile::spawnProjectile(ModuleBomb, %trans ,%player,%vel);
		%fired.deployer = %client;
		%this.refire = 1;
		%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 2.0);
		return;
	}
	else if (%module == "5" && %this.ammo) //== PickUp
	{
		%obj = newObject("","Mine","PickUpPack");		
		addToSet("MissionCleanup", %obj);		
		
		%k = Vector::getFromRot(%rot, -2);
		%padd = getword (%k, 0) @ " " @ getword (%k, 1) @ " -2.0";
		%pos = Vector::add(gamebase::getposition(%this), %padd);
		gamebase::setposition(%obj, %pos);		
		%this.refire = 1;%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 2.0);
		return;
	}
	else if (%module == "6" && %this.ammo) //== Mine Net
	{
		%padd = "0 0 -2.0";
		%pos = Vector::add(gamebase::getposition(%this), %padd);
		%rot = gamebase::getrotation(%this);
		%obj = newObject("NetMine","Turret", "MineNet",true);
		GameBase::setTeam(%obj,GameBase::getTeam(%client));
		
		GameBase::setPosition(%obj,%pos);
		GameBase::setRotation(%obj,%rot);
		
		addToSet("MissionCleanup", %obj);
		%this.refire = 1;
		%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 2.0);
		schedule ("Client::sendMessage(" @ %client @ ",1,\"Reload Complete ~wSoundMortaReload.wav\");",2.0);
		Client::sendMessage(%client,1,"Mine Field Deployed. ~wSoundMortaReload.wav");
		return;
	}
	else if (%module == "8" && %this.ammo) //== Wraith Module
	{
		bottomprint (%client, "Cloaking Activated Automatically", 5);
		%this.refire = 1;
		schedule ("" @ %this @ ".refire = 0;", 120.0);
	}
	else if (%module == "9" && %this.ammo) //== Interceptor Module
	{
		%rot = gamebase::getrotation(%this);
		%dir = (Vector::getfromrot(%rot));
		%pos = gamebase::getposition(%this);
		%y1 = Vector::getFromRot(%rot, 15);
		%pos1 = Vector::add(%pos, %y1);

		%trans =  %rot @ " " @ %dir @ " 0 0 0 " @ %pos1;

		%vel = Item::getVelocity(%this);
		Projectile::spawnProjectile(InterceptorAmmo, %trans ,%player,%vel);
		Projectile::spawnProjectile(InterceptorAmmo, %trans ,%player,%vel);
		playSound(SoundFireBlaster,GameBase::getPosition(%this));
		%this.refire = 1;
		schedule ("" @ %this @ ".refire = 0;", 0.1);
		%this.ammo -= 1;
		return;
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

//===================================================================================================================
//													LAPC
//===================================================================================================================
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
	maxDamage = 1.7;
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

	projectileType = Undefined;
	reloadDelay = 4.0;
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

function LAPC::OnFire(%this)
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

	if (%module == "7" && %this.ammo) //== Stealth Module
	{
		if (%this.stealth == 1)
		{
			%this.stealth = 0;
		}
		else if (%this.stealth == 0)
		{
			%this.stealth = 1;
			%this.ammo -= 1;

			%rate = Player::getSensorSupression(%object) + 100;
			Player::setSensorSupression(%player,%rate);
			Player::setSensorSupression(%client,%rate);
			Player::setSensorSupression(%this,%rate);

			Player::setSensorSupression(%player,100);
			Player::setSensorSupression(%this,100);

			bottomprint (%client, "Stealth Activated For 120 Seconds", 5);
			schedule ("StealthOff(" @ %this @ ");", 120);

			%this.refire = 1;
			schedule ("" @ %this @ ".refire = 0;", 100.0);
		}
	}
	else if (%module == "4" && %this.ammo) //== Bomber
	{
		%rot = gamebase::getrotation(%this);
		%dir = (Vector::getfromrot(%rot));
		%dir = Vector::add(%dir, "0 0 0");
		%trans =  %rot @ " " @ %dir @ " 0 0 0 " @ gamebase::getposition(%this);
		%fired = Projectile::spawnProjectile(ModuleBomb, %trans ,%player,%vel);
		%fired.deployer = %client;
		%this.refire = 1;
		%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 2.0);
		return;
	}
	else if (%module == "10" && %this.ammo) //== GodHammer Module
	{
		%obj1 = newObject("","Mine","GodHammerPod");
		addToSet("MissionCleanup", %obj1);
		%obj2 = newObject("","Mine","GodHammerPod");
		addToSet("MissionCleanup", %obj2);
		%obj3 = newObject("","Mine","GodHammerPod");
		addToSet("MissionCleanup", %obj3);
		%obj4 = newObject("","Mine","GodHammerPod");
		addToSet("MissionCleanup", %obj4);
		%obj5 = newObject("","Mine","GodHammerPod");
		addToSet("MissionCleanup", %obj5);

		GameBase::throw(%obj1,%this,8,false);
		GameBase::throw(%obj2,%this,8,false);
		GameBase::throw(%obj3,%this,8,False);
		GameBase::throw(%obj4,%this,8,False);
		GameBase::throw(%obj5,%this,8,False);

		gamebase::setrotation(%obj1, gamebase::getrotation(%this));
		gamebase::setrotation(%obj2, gamebase::getrotation(%this));
		gamebase::setrotation(%obj3, gamebase::getrotation(%this));
		gamebase::setrotation(%obj4, gamebase::getrotation(%this));
		gamebase::setrotation(%obj5, gamebase::getrotation(%this));

		%k = Vector::getFromRot(gamebase::getrotation(%obj1));
		%padd = getword (%k, 0) @ " " @ " -10 " @ getword (%k, 1);
		gamebase::setposition (%obj1, Vector::add(gamebase::getposition(%obj1), %padd));

		%k = Vector::getFromRot(gamebase::getrotation(%obj2));
		%padd = getword (%k, 0) @ " " @ " -5 " @ getword (%k, 1);
		gamebase::setposition (%obj2, Vector::add(gamebase::getposition(%obj2), %padd));

		%k = Vector::getFromRot(gamebase::getrotation(%obj3));
		%padd = getword (%k, 0) @ " " @ " 0 " @ getword (%k, 1);
		gamebase::setposition (%obj3, Vector::add(gamebase::getposition(%obj3), %padd));

		%k = Vector::getFromRot(gamebase::getrotation(%obj4));
		%padd = getword (%k, 0) @ " " @ " 5 " @ getword (%k, 1);
		gamebase::setposition (%obj4, Vector::add(gamebase::getposition(%obj4), %padd));

		%k = Vector::getFromRot(gamebase::getrotation(%obj5));
		%padd = getword (%k, 0) @ " " @ " 10 " @ getword (%k, 1);
		gamebase::setposition (%obj5, Vector::add(gamebase::getposition(%obj5), %padd));

		%obj1.deployer = %client;
		%obj2.deployer = %client;
		%obj3.deployer = %client;
		%obj4.deployer = %client;
		%obj5.deployer = %client;
		
		%this.refire = 1;
		%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 0.8);
		return;
	}
}

//===================================================================================================================
//													HAPC
//===================================================================================================================
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
	maxDamage = 2.2;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.20;

	groundDamageScale = 0.125;

	projectileType = Undefined;
	reloadDelay = 4.0;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
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

	if (%module == "7" && %this.ammo) //== Stealth Module
	{
		if (%this.stealth == 1)
		{
			%this.stealth = 0;
		}
		else if (%this.stealth == 0)
		{
			%this.stealth = 1;
			%this.ammo -= 1;

			Player::setSensorSupression(%player,100);
			Player::setSensorSupression(%this,100);

			bottomprint (%client, "Stealth Activated For 120 Seconds", 5);
			schedule ("StealthOff(" @ %this @ ");", 120);

			%this.refire = 1;
			schedule ("" @ %this @ ".refire = 0;", 100.0);
		}
	}
	else if (%module == "4" && %this.ammo) //== Bomber
	{
		%rot = gamebase::getrotation(%this);
		%dir = (Vector::getfromrot(%rot));
		%dir = Vector::add(%dir, "0 0 0");
		%trans =  %rot @ " " @ %dir @ " 0 0 0 " @ gamebase::getposition(%this);
		%fired = Projectile::spawnProjectile(ModuleBomb, %trans ,%player,%vel);
		%fired.deployer = %client;
		%this.refire = 1;
		%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 2.0);
		return;
	}
	else if (%module == "10" && %this.ammo) //== GodHammer Module
	{
		%obj1 = newObject("","Mine","GodHammerPod");
		addToSet("MissionCleanup", %obj1);
		%obj2 = newObject("","Mine","GodHammerPod");
		addToSet("MissionCleanup", %obj2);
		%obj3 = newObject("","Mine","GodHammerPod");
		addToSet("MissionCleanup", %obj3);
		%obj4 = newObject("","Mine","GodHammerPod");
		addToSet("MissionCleanup", %obj4);
		%obj5 = newObject("","Mine","GodHammerPod");
		addToSet("MissionCleanup", %obj5);

		GameBase::throw(%obj1,%this,8,false);
		GameBase::throw(%obj2,%this,8,false);
		GameBase::throw(%obj3,%this,8,False);
		GameBase::throw(%obj4,%this,8,False);
		GameBase::throw(%obj5,%this,8,False);

		gamebase::setrotation(%obj1, gamebase::getrotation(%this));
		gamebase::setrotation(%obj2, gamebase::getrotation(%this));
		gamebase::setrotation(%obj3, gamebase::getrotation(%this));
		gamebase::setrotation(%obj4, gamebase::getrotation(%this));
		gamebase::setrotation(%obj5, gamebase::getrotation(%this));

		%k = Vector::getFromRot(gamebase::getrotation(%obj1));
		%padd = getword (%k, 0) @ " " @ " -10 " @ getword (%k, 1);
		gamebase::setposition (%obj1, Vector::add(gamebase::getposition(%obj1), %padd));

		%k = Vector::getFromRot(gamebase::getrotation(%obj2));
		%padd = getword (%k, 0) @ " " @ " -5 " @ getword (%k, 1);
		gamebase::setposition (%obj2, Vector::add(gamebase::getposition(%obj2), %padd));

		%k = Vector::getFromRot(gamebase::getrotation(%obj3));
		%padd = getword (%k, 0) @ " " @ " 0 " @ getword (%k, 1);
		gamebase::setposition (%obj3, Vector::add(gamebase::getposition(%obj3), %padd));

		%k = Vector::getFromRot(gamebase::getrotation(%obj4));
		%padd = getword (%k, 0) @ " " @ " 5 " @ getword (%k, 1);
		gamebase::setposition (%obj4, Vector::add(gamebase::getposition(%obj4), %padd));

		%k = Vector::getFromRot(gamebase::getrotation(%obj5));
		%padd = getword (%k, 0) @ " " @ " 10 " @ getword (%k, 1);
		gamebase::setposition (%obj5, Vector::add(gamebase::getposition(%obj5), %padd));

		%obj1.deployer = %client;
		%obj2.deployer = %client;
		%obj3.deployer = %client;
		%obj4.deployer = %client;
		%obj5.deployer = %client;
		
		%this.refire = 1;
		%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 0.8);
		return;
	}
}

function StealthOff(%this)
{
	%client = gamebase::getcontrolclient(%this);
	%player = Client::getOwnedObject(%client);

	Player::setSensorSupression(%player,0);
	Player::setSensorSupression(%this,0);

	%this.stealth = 0;
	bottomprint (%client, "Stealth Is DeActivated.", 5);
}

//===================================================================================================================
//													Other Funcs
//===================================================================================================================

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
	%vname = GameBase::getDataName(%this);
	%module = $Vmodule[%this.module];

	//echo ("Flyer = " @ %this);
	//echo ("Flyer = " @ %vname);
	//echo ("Module  " @ %this.module);
	
	//echo ("Last Mount " @ %object.lastMount);
// - BW Admin Mod - Bug Fix
               if(%object.Station != "")
               {
               		Client::sendMessage(Player::getClient(%object),0,"You must leave the Inventory Station to pilot the vehicles.~wError_Message.wav");
               		return;
               }
// - BW Admin Mod - Bug Fix End	
	
	if(%data.shapefile == "discb")
	{
		if (GameBase::setDamageLevel(%this, 10))
			return;
	}	
	else if(%data.shapefile == "rocket")
	{
		if (GameBase::setDamageLevel(%this, 10))
			return;
	}
	//================================================================================================== Loading Scout
	else if (%vname == "Scout" && (!%this.module || %this.module == "0") && getObjectType(%object) == "Player")
	{
		if (Player::getItemCount(%object, NapalmModule) && !%this.module)
		{
			if ($debug) echo ("1");
			Client::sendMessage(%client,0,"Napalm Module Loaded.");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::setItemCount(%client,NapalmModule, 0);
			%this.module = 1;
			%this.ammo = 15;
			return;
		}
		else if (Player::getItemCount(%object, HellFireModule) && !%this.module)
		{
			if ($debug) echo ("2");
			Client::sendMessage(%client,0,"HellFire Module Loaded.");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::setItemCount(%client,HellFireModule, 0);
			%this.module = 2;		
			%this.ammo = 15;
			return;
		}
		else if (Player::getItemCount(%object, DetPackModule) && !%this.module)
		{
			if ($debug) echo ("3");
			Client::sendMessage(%client,0,"DetPack Module Loaded.");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::setItemCount(%client,DetPackModule, 0);
			%this.module = 3;
			%this.ammo = 1;
			return;
		}
		else if (Player::getItemCount(%object, PickUpModule) && !%this.module)
		{
			Client::sendMessage(%client,0,"PickUp Module Loaded.");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::setItemCount(%client,PickUpModule, 0);	
			%this.module = 5;
			%this.ammo = 3;
			return;
		}
		else if (Player::getItemCount(%object, MineNetModule) && !%this.module)
		{
			Client::sendMessage(%client,0,"MineNet Module Loaded.");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::setItemCount(%client,MineNetModule, 0);	
			%this.module = 6;
			%this.ammo = 4;
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
		else if (Player::getItemCount(%object, InterceptorModule) && !%this.module)
		{
			Client::sendMessage(%client,0,"Interceptor Module Loaded.");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::setItemCount(%client,InterceptorModule, 0);	
			%this.module = 9;
			%this.ammo = 150;
			return;
		}		
	}
	//================================================================================================== Loading LAPC	
	else if (%vname == "LAPC" && (!%this.module || %this.module == "0") && getObjectType(%object) == "Player")
	{
		if (Player::getItemCount(%object, StealthModule) && !%this.module)
		{
			Client::sendMessage(%client,0,"Stealth Module Loaded.");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::setItemCount(%client,StealthModule, 0);	
			%this.module = 7;
			%this.ammo = 3;
			return;
		}
		else if (Player::getItemCount(%object, GodHammerModule) && !%this.module)
		{
			Client::sendMessage(%client,0,"GodHammer Module Loaded.");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::setItemCount(%client,GodHammerModule, 0);	
			%this.module = 10;
			%this.ammo = 7;
			return;
		}
		else if (Player::getItemCount(%object, BomberModule) && !%this.module)
		{
			Client::sendMessage(%client,0,"Bomber Module Loaded.");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::setItemCount(%client,BomberModule, 0);
			%this.module = 4;
			%this.ammo = 4;
			return;
		}		
	}
	//================================================================================================== Loading HAPC
	else if (%vname == "HAPC" && (!%this.module || %this.module == "0") && getObjectType(%object) == "Player")
	{
		if (Player::getItemCount(%object, StealthModule) && !%this.module)
		{
			Client::sendMessage(%client,0,"Stealth Module Loaded.");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::setItemCount(%client,StealthModule, 0);	
			%this.module = 7;
			%this.ammo = 4;
			return;
		}
		else if (Player::getItemCount(%object, GodHammerModule) && !%this.module)
		{
			Client::sendMessage(%client,0,"GodHammer Module Loaded.");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::setItemCount(%client,GodHammerModule, 0);	
			%this.module = 10;
			%this.ammo = 15;
			return;
		}
		else if (Player::getItemCount(%object, BomberModule) && !%this.module)
		{
			Client::sendMessage(%client,0,"Bomber Module Loaded.");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
			Player::setItemCount(%client,BomberModule, 0);
			%this.module = 4;
			%this.ammo = 6;
			return;
		}
	}
	else if (%this.module)
	{
		Client::sendMessage(%client,1," Loaded With VM - " @ %module @ " Module.");
	}
	else
	{
		echo ("No MOd " );
		Client::sendMessage(%client,1," VM - " @ %module @ " Module Not Compatable With The " @ %vname @ ".");
	}



	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage)
	{
		if (getObjectType (%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
		{

			if ((%armor == "larmor" || %armor == "lfemale" || %armor == "sarmor" || %armor == "sfemale" || %armor == "spyarmor" || %armor == "spyfemale" || %armor == "stimarmor" || %armor == "stimfemale") && Vehicle::canMount (%this, %object))
			{
				%weapon = Player::getMountedItem(%object,$WeaponSlot);

				if(%weapon != -1)
				{
					%object.lastWeapon = %weapon;
					Player::unMountItem(%object,$WeaponSlot);
				}
				
				if(%this.module == 8 && %this.ammo)
				{
					GameBase::startFadeout(%this);
					GameBase::startFadeout(%object);
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
				
				playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				%object.driver= 1;
		            	%object.vehicle = %this;
		            	%client.driver = 1;
				%this.clLastMount = %client;
			}
			else if((GameBase::getDataName(%this) != Scout) && (GameBase::getDataName(%this) != Wraith) && (GameBase::getDataName(%this) != Jet) )  
			{
				%mountSlot= Vehicle::findEmptySeat(%this,%client); 
				if(%mountSlot) 
				{
					echo ("Mount = " @ %mountSlot);
					%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					Player::setMountObject(%object, %this, %mountSlot);
					playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				}
			}
			else if (GameBase::getControlClient(%this) == -1)
				Client::sendMessage(Player::getClient(%object),0,"You must be in Light Armor to pilot the vehicles.~wError_Message.wav");
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
		if (GameBase::setDamageLevel(%this, 10))
			if ($debug) echo ("BOOM");
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
	      		%pos = GameBase::getPosition(%pl);
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

					if(GameBase::getDataName(%this) == Wraith)
					{
						GameBase::startFadein(%this);
					}
				}
				%pl.driver = "";
				%client.driver = "";
				%pl.vehicle = "";
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
 	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
 	
 	%cl = GameBase::getControlClient(%this);
 	%pl = Client::getOwnedObject(%cl);
 
 	Client::setOwnedObject(%cl, %this);
	Client::setOwnedObject(%cl, %pl);
 
 	if(%pl != -1)
 	{
 		Player::setMountObject(%pl, -1, 0);
 		doneposs(%cl);
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
		%pl = Client::getOwnedObject(%this.Seat[%i]);
		Player::setMountObject(%pl, -1, 0);
		doneposs(%this.Seat[%i]);
		Client::setControlObject(%this.Seat[%i], %pl);
	}
	%data = GameBase::getDataName(%this);
	
	if(%data.shapefile == "rocket")
	{
		echo ("Proj Name = " @ %data);
		
		if (!CheckMissileJammer(%this))
		{
			if (%data == NapProj)
			{
				Aoe::deployShape(%this, 35, $PlasmaDamageType, 10);
				DeployFrags(%this, 10, %pl);
				GameBase::applyRadiusDamage($PlasmaDamageType, getBoxCenter(%this), 25, 0.50, 345, %pl);
			}
			else if (%data == EmpProj)
			{
				%obj = newObject("","Mine","EMPBlast");
				GameBase::throw(%obj,%cl,0,false);		
				addToSet("MissionCleanup", %obj);
				%padd = "0 0 3.5";
				%pos = Vector::add(GameBase::getPosition(%this), %padd);
				GameBase::setPosition(%obj, %pos);
				
				%obj = newObject("","Mine","EMPBlast");
				GameBase::throw(%obj,%cl,0,false);		
				addToSet("MissionCleanup", %obj);
				%padd = "0 0 3.5";
				%pos = Vector::add(GameBase::getPosition(%this), %padd);
				GameBase::setPosition(%obj, %pos);					
				Client::setOwnedObject(%cl, %pl);

				Aoe::deployShape(%this, 15, $FlashDamageType, 10);
				GameBase::applyRadiusDamage($FlashDamageType, getBoxCenter(%this), 20, 0.75, 300, %pl);
			}
			else if (%data == GasProj)
			{
				Aoe::deployShape(%this, 20, $EnergyDamageType, 25);
				GameBase::applyRadiusDamage($EnergyDamageType, getBoxCenter(%this), 30, 0.55, 175, %pl);
			}
			else if (%data == BooProj)	//== Turret Killer
			{
		                %obj = newObject("","Mine","NRing1");
				GameBase::throw(%obj,%cl,0,false);		
		                addToSet("MissionCleanup", %obj);
		                %pos = GameBase::getPosition(%this);
		                GameBase::setPosition(%obj, %pos);
		                
				%obj = newObject("","Mine","NCloud5");
				GameBase::throw(%obj,%cl,0,false);		
				addToSet("MissionCleanup", %obj);
				%padd = "0 0 1.0";
				%pos = Vector::add(GameBase::getPosition(%this), %padd);
				GameBase::setPosition(%obj, %pos);
				
				%obj = newObject("","Mine","HavocBlast");
				GameBase::throw(%obj,%cl,0,false);		
				addToSet("MissionCleanup", %obj);
				%padd = "0 0 1.0";
				%pos = Vector::add(GameBase::getPosition(%this), %padd);
				GameBase::setPosition(%obj, %pos);
				
				Client::setOwnedObject(%cl, %pl);
				GameBase::applyRadiusDamage($BlasterDamageType, getBoxCenter(%this), 6, 5.80, 50, %pl);
			}
			else if (%data == ShortCoolProj)
			{
				GameBase::applyRadiusDamage($MissileDamageType, getBoxCenter(%this), 20, 0.75, 305, %pl);
			}
			else if (%data == SpyPodProj)
			{
				GameBase::applyRadiusDamage($MissileDamageType, getBoxCenter(%this), 10, 1.52, 15, %pl);
			}			
			else	
			{
				GameBase::applyRadiusDamage($MissileDamageType, getBoxCenter(%this), 20, 0.50, 600, %pl);
			}
		}
		else
		{
			bottomprint(%cl, "<jc><f2>You are being JAMMED! Control Lock Failed, War Head Did NOT Detonate, Jammer DESTROYED! ", 2);
		}
	}
	else
	{
		if(%data.shapefile != "camera")
			calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100);
	}
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Vehicle::getHeatFactor(%this)
{
   	return 1.0;
}

$DamageScale[Scout,	$BlasterDamageType] 	= 1.0;
$DamageScale[Scout,	$BulletDamageType] 	= 1.0;
$DamageScale[Scout,	$CloakDamageType] 	= 0.0;
$DamageScale[Scout,	$CrushDamageType] 	= 1.0;
$DamageScale[Scout,	$DebrisDamageType] 	= 1.0;
$DamageScale[Scout,	$ElectricityDamageType] = 1.0;
$DamageScale[Scout,	$EnergyDamageType] 	= 1.0;
$DamageScale[Scout,	$EqualizerDamageType] 	= 1.0;
$DamageScale[Scout,	$ExplosionDamageType] 	= 1.0;
$DamageScale[Scout,	$FlashDamageType] 	= 1.0;
$DamageScale[Scout,	$GravDamageType]	= 1.0;
$DamageScale[Scout,	$IDamageType] 	 	= 1.0;
$DamageScale[Scout,	$ImpactDamageType] 	= 1.0;
$DamageScale[Scout,	$LandingDamageType] 	= 1.0;
$DamageScale[Scout,	$LaserDamageType] 	= 1.0;
$DamageScale[Scout,	$MineDamageType] 	= 1.0;
$DamageScale[Scout,	$MissileDamageType] 	= 1.0;
$DamageScale[Scout,	$MortarDamageType] 	= 1.0;
$DamageScale[Scout,	$NukeDamageType] 	= 1.0;
$DamageScale[Scout,	$PlasmaDamageType] 	= 1.0;
$DamageScale[Scout,	$ShellDamageType] 	= 1.0;
$DamageScale[Scout,	$ShrapnelDamageType] 	= 1.0;
$DamageScale[Scout,	$SniperDamageType] 	= 1.0;

$DamageScale[Jet,	$BlasterDamageType] 	= 1.0;
$DamageScale[Jet,	$BulletDamageType] 	= 1.0;
$DamageScale[Jet,	$CloakDamageType] 	= 0.0;
$DamageScale[Jet,	$CrushDamageType] 	= 1.0;
$DamageScale[Jet,	$DebrisDamageType] 	= 1.0;
$DamageScale[Jet,	$ElectricityDamageType] = 1.0;
$DamageScale[Jet,	$EnergyDamageType] 	= 1.0;
$DamageScale[Jet,	$EqualizerDamageType] 	= 1.0;
$DamageScale[Jet,	$ExplosionDamageType] 	= 1.0;
$DamageScale[Jet,	$FlashDamageType] 	= 1.0;
$DamageScale[Jet,	$GravDamageType]	= 1.0;
$DamageScale[Jet,	$IDamageType] 	 	= 1.0;
$DamageScale[Jet,	$ImpactDamageType] 	= 1.0;
$DamageScale[Jet,	$LandingDamageType] 	= 1.0;
$DamageScale[Jet,	$LaserDamageType] 	= 1.0;
$DamageScale[Jet,	$MineDamageType] 	= 1.0;
$DamageScale[Jet,	$MissileDamageType] 	= 1.0;
$DamageScale[Jet,	$MortarDamageType] 	= 1.0;
$DamageScale[Jet,	$NukeDamageType] 	= 1.0;
$DamageScale[Jet,	$PlasmaDamageType] 	= 1.0;
$DamageScale[Jet,	$ShellDamageType] 	= 1.0;
$DamageScale[Jet,	$ShrapnelDamageType] 	= 1.0;
$DamageScale[Jet,	$SniperDamageType] 	= 1.0;

$DamageScale[Wraith,	$BlasterDamageType] 	= 1.0;
$DamageScale[Wraith,	$BulletDamageType] 	= 1.0;
$DamageScale[Wraith,	$CloakDamageType] 	= 0.0;
$DamageScale[Wraith,	$CrushDamageType] 	= 1.0;
$DamageScale[Wraith,	$DebrisDamageType] 	= 1.0;
$DamageScale[Wraith,	$ElectricityDamageType] = 1.0;
$DamageScale[Wraith,	$EnergyDamageType] 	= 1.0;
$DamageScale[Wraith,	$EqualizerDamageType] 	= 1.0;
$DamageScale[Wraith,	$ExplosionDamageType] 	= 1.0;
$DamageScale[Wraith,	$FlashDamageType] 	= 1.0;
$DamageScale[Wraith,	$GravDamageType]	= 1.0;
$DamageScale[Wraith,	$IDamageType] 	 	= 1.0;
$DamageScale[Wraith,	$ImpactDamageType] 	= 1.0;
$DamageScale[Wraith,	$LandingDamageType] 	= 1.0;
$DamageScale[Wraith,	$LaserDamageType] 	= 1.0;
$DamageScale[Wraith,	$MineDamageType] 	= 1.0;
$DamageScale[Wraith,	$MissileDamageType] 	= 1.0;
$DamageScale[Wraith,	$MortarDamageType] 	= 1.0;
$DamageScale[Wraith,	$NukeDamageType] 	= 1.0;
$DamageScale[Wraith,	$PlasmaDamageType] 	= 1.0;
$DamageScale[Wraith,	$ShellDamageType] 	= 1.0;
$DamageScale[Wraith,	$ShrapnelDamageType] 	= 1.0;
$DamageScale[Wraith,	$SniperDamageType] 	= 1.0;

$DamageScale[LAPC,	$BlasterDamageType] 	= 1.0;
$DamageScale[LAPC,	$BulletDamageType] 	= 1.0;
$DamageScale[LAPC,	$CloakDamageType] 	= 0.0;
$DamageScale[LAPC,	$CrushDamageType] 	= 1.0;
$DamageScale[LAPC,	$DebrisDamageType] 	= 1.0;
$DamageScale[LAPC,	$ElectricityDamageType] = 1.0;
$DamageScale[LAPC,	$EnergyDamageType] 	= 1.0;
$DamageScale[LAPC,	$EqualizerDamageType] 	= 1.0;
$DamageScale[LAPC,	$ExplosionDamageType] 	= 1.0;
$DamageScale[LAPC,	$FlashDamageType] 	= 1.0;
$DamageScale[LAPC,	$GravDamageType]	= 1.0;
$DamageScale[LAPC,	$IDamageType] 	 	= 1.0;
$DamageScale[LAPC,	$ImpactDamageType] 	= 1.0;
$DamageScale[LAPC,	$LandingDamageType] 	= 1.0;
$DamageScale[LAPC,	$LaserDamageType] 	= 1.0;
$DamageScale[LAPC,	$MineDamageType] 	= 1.0;
$DamageScale[LAPC,	$MissileDamageType] 	= 1.0;
$DamageScale[LAPC,	$MortarDamageType] 	= 1.0;
$DamageScale[LAPC,	$NukeDamageType] 	= 1.0;
$DamageScale[LAPC,	$PlasmaDamageType] 	= 1.0;
$DamageScale[LAPC,	$ShellDamageType] 	= 1.0;
$DamageScale[LAPC,	$ShrapnelDamageType] 	= 1.0;
$DamageScale[LAPC,	$SniperDamageType] 	= 1.0;

$DamageScale[HAPC,	$BlasterDamageType] 	= 1.0;
$DamageScale[HAPC,	$BulletDamageType] 	= 1.0;
$DamageScale[HAPC,	$CloakDamageType] 	= 0.0;
$DamageScale[HAPC,	$CrushDamageType] 	= 1.0;
$DamageScale[HAPC,	$DebrisDamageType] 	= 1.0;
$DamageScale[HAPC,	$ElectricityDamageType] = 1.0;
$DamageScale[HAPC,	$EnergyDamageType] 	= 1.0;
$DamageScale[HAPC,	$EqualizerDamageType] 	= 1.0;
$DamageScale[HAPC,	$ExplosionDamageType] 	= 1.0;
$DamageScale[HAPC,	$FlashDamageType] 	= 1.0;
$DamageScale[HAPC,	$GravDamageType]	= 1.0;
$DamageScale[HAPC,	$IDamageType] 	 	= 1.0;
$DamageScale[HAPC,	$ImpactDamageType] 	= 1.0;
$DamageScale[HAPC,	$LandingDamageType] 	= 1.0;
$DamageScale[HAPC,	$LaserDamageType] 	= 1.0;
$DamageScale[HAPC,	$MineDamageType] 	= 1.0;
$DamageScale[HAPC,	$MissileDamageType] 	= 1.0;
$DamageScale[HAPC,	$MortarDamageType] 	= 1.0;
$DamageScale[HAPC,	$NukeDamageType] 	= 1.0;
$DamageScale[HAPC,	$PlasmaDamageType] 	= 1.0;
$DamageScale[HAPC,	$ShellDamageType] 	= 1.0;
$DamageScale[HAPC,	$ShrapnelDamageType] 	= 1.0;
$DamageScale[HAPC,	$SniperDamageType] 	= 1.0;
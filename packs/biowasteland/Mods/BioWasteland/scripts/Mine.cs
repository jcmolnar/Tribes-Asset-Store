//===============================
// Mine Data
//===============================
// Anti-Personel Mine		- Scout, Goliath
// Proximity Mine		- Engineer
// SubSpace Mine		- Spy
// Mock-Repair Kit		- Assassin
// Speed Boost			- Patriot
// Flag Mine			- Assassin
// ShockWave			- Stealth
// Various				- Engineer
//============================================================================================ Anti-Personel Mine

MineData AntipersonelMine
{
	className = "Mine";
   	description = "Antipersonel Mine";
   	shapeFile = "mine";
   	shadowDetailMask = 4;
   	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.75;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
	//validateShape = true;
};

function AntipersonelMine::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}

function AntipersonelMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) 
	{
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("mineset",SimSet);
		%pos = GameBase::getPosition(%this);
		
		%spntrpos = %playerteam.spntrpos;
		if (!%spntrpos) %spntrpos = "0 0 0";
		
		if(1 != containerBoxFillSet(%set,$MineObjectType,%pos,1,1,1,0))
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		
		deleteObject(%set);
		%team = 0;
		for(%team; %team < 8; %team++)
		{
 			%group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Random");
			%num = Group::objectCount(%group);
			for(%i; %i < %num; %i++)
			{
				%obj = Group::getObject(%group, %i);
				%homepos = GameBase::getPosition(%obj);
				if (Vector::getDistance(%pos,%homepos) < 5 && Vector::getDistance(%pos,%spntrpos) > 30 && %team != GameBase::getTeam(%this))
				{
					%data = GameBase::getDataName(%this);
					GameBase::setDamageLevel(%this, %data.maxDamage);
					
				}
			}
			%i="";
		}
	}
	else 
		schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine::onDestroyed(%this)
{
	//$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//================================ Proximity Detection Mine

MineData ProxMine
{
	className = "Mine";
	description = "Antipersonel Mine";
	shapeFile = "radar_small";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 10;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function ProxMine::onAdd(%this)
{
	%this.damage = 0;
	ProxMine::deployCheck(%this);
}

function ProxMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%object);
	%team = GameBase::getTeam(%this);
	%damagedClient = Player::getClient(%object);

	if ( %type == "Player" && GameBase::isActive(%this) && %team !=GameBase::getTeam(%object) && $ScreamerDelay != %object)
	{
		%client = Player::getClient(%this.tc);
		%dude = Client::getName(%damagedClient);
		%msg = %dude @ " at WayPoint";
		teambottomprint("<jc>Incoming enemy " @ %msg, 2, %team);
		TeamMessages(1, %team, "~wusepack.wav");
		schedule("TeamMessages(0," @ %team @ ",\"~wusepack.wav\");",0.2);
		schedule("TeamMessages(0," @ %team @ ",\"~wusepack.wav\");",0.4);
		$ScreamerDelay = %object;

		%numPlayers = getNumClients();
		for(%j = 0; %j < %numPlayers; %j = %j + 1)
			if (getClientByIndex(%j) == %damagedClient) %targIdx = %j+1;
		for(%j = 0; %j < %numPlayers; %j = %j + 1)
		{
			%c = getClientByIndex(%j);
			if(%team == Client::getTeam(%c))
				issueTargCommand(%client, %c, 1, %msg@"~wincom2", %targIdx);
		}
	}		
}

function ProxMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
	}
	else 
		schedule("ProxMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function ProxMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "ProxMine"]--;
}

function ProxMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//============================ SubSpace-Cloak Mine

MineData SubspaceMine
{
	className = "Mine";
	description = "Subspace Mine";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 15.0;
	damageValue = 0.85;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function SubspaceMine::onAdd(%this)
{
	%this.damage = 0;
        AntipersonelMine::deployCheck(%this);
}

function SubspaceMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
        
        if (!(GameBase::getTeam(%object) == GameBase::getTeam(%this)) && (%type == "Player" || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) 
        GameBase::setDamageLevel(%this, %data.maxDamage);
}



//=========================== Mock Repair Pack

MineData HoloMine
{
	className = "Mine";
   description = "Repair";
   shapeFile = "armorPack";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 15.0;
	damageValue = 0.75;
	damageType = $MineDamageType;
	kickBackStrength = 350;
	triggerRadius = 2.5;
	maxDamage = 2.00;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function HoloMine::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
	schedule("Mine::Detonate(" @ %this @ ");",120.0,%this);
}

function HoloMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == HoloMine|| %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object))) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function HoloMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//============================ Flag Mine - Decoy

MineData Hologram
{
	className = "Mine";
	description = "Flag";
	shapeFile = "flag";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 5.0;
	damageValue = 0.75; //0
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 3.00;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };

};

function Hologram::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}

function Hologram::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
        if (!(GameBase::getTeam(%object) == GameBase::getTeam(%this)) && (%type == "Player" || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Hologram::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $ShrapnelDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//================================== ShockWave Mine

MineData ShockMine
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
	description = "ShockWave Mine";
	shapeFile = "sensor_small";
	shadowDetailMask = 4;
	explosionId = Shockwave;
	explosionRadius = 10.0;
	damageValue = 0.25;
	damageType = $MortarDamageType;
	kickBackStrength = 500;
	triggerRadius = 2.5;
	maxDamage = 2.0;
};

function ShockMine::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut(" @ %this @ ");",8.0,%this);
}
function ShockMine::onCollision(%this,%obj)
{
    if(getObjectType(%obj) != "Player")
	{
        return;
	}

    if(Player::isDead(%obj))
	{
        return;
	}

    %playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	if (GameBase::getTeam(%this)!= GameBase::getTeam(%obj))
	{
        GameBase::startFadeIn(%this);
		schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
	}
}

function ShockMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function ShockMine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


//=================== Telebeacon Mine

MineData Telebeacon
{
	className = "Mine";
	description = "Telebeacon";
	shapeFile = "dirArrows";//sensor_small
	shadowDetailMask = 4;
	explosionId = ShockwaveFour;
	explosionRadius = 5.0;
	damageValue = 0.15;
	damageType = $MineDamageType;
	kickBackStrength = 450;
	triggerRadius = 10;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function Telebeacon::onAdd(%this)
{
	if ($debug) echo("Telebeacon Mine Added");
	%this.damage = 0;
        Telebeacon::deployCheck(%this);
}

function Telebeacon::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		GameBase::setActive(%this,true);
		%clientId = %this.deployer;
		%pos = GameBase::getPosition(%this);
		%clientId.telepoint = %pos;
		bottomprint(%clientId, "<jc><f2>Your TeleBeacon Is Now Active, Use Pack To Teleport!", 3);
		Client::sendMessage(%clientId,0,"~wfemale2.wready.wav");
	}
	else 
        	schedule("Telebeacon::deployCheck(" @ %this @ ");", 3, %this);
}	

function Telebeacon::onCollision(%this,%object)
{
	if (GameBase::getTeam(%this) != GameBase::getTeam(%object)) bottomprint(%this.deployer,"<jc><f2>"@Client::getName(Player::getClient(%object))@" is stepping on your telebeacon.", 1);
}

function Telebeacon::onDestroyed(%this)
{
	%clientId = %this.deployer;
	bottomprint(%clientId, "<jc><f2>Your TeleBeacon Has Been Destroyed!!!", 3);
	Client::sendMessage(%clientId,0,"~wfemale2.wcolor6.wav");
	%clientId.telepoint = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "TeleBeacons"]--;
}

function Teleceacon::onDeactivate(%this)
{
	Telebeacon::onDestroyed(%this);
}


//========================== Suicide Pack 2 On Deploy

MineData PickUpPack
{
	mass = 999.3;
	drag = 999.0;
	density = 999.0;
	elasticity = 0.0;
	friction = 999.0;
	className = "Handgrenade";
	description = "ShockWave Mine";
	shapeFile = "MagCargo";
	shadowDetailMask = 4;
	explosionId = Shockwave;
	explosionRadius = 10.0;
	damageValue = 0.25;
	damageType = $MortarDamageType;
	kickBackStrength = 100;
	triggerRadius = 1.0;
	maxDamage = 2.0;
};

function PickUpPack::onAdd(%this)
{
	PickUpPack::deployCheck(%this);
	schedule ("deleteobject( " @ %this @ ");",120);
}

function PickUpPack::onCollision(%this,%player)
{
	if(getObjectType(%player) != "Player") {return;}
	if(Player::isDead(%player)) {return;}

    	%client = Player::getClient(%player);
    	%plTeam = GameBase::getTeam(%player);
	%ppTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);
	
	if (%player != -1)
	{
		%cnt = Station::itemsToResupply(%player);
		//echo ("Ammount " @ %cnt);
		
		if(getSimTime() - %this.enterTime > 11)
			%cnt = 0;
			
		if (%cnt != 0)
		{
			return;
		}
	}
	GameBase::setActive(%this,false);
	%this.enterTime="";
}

function PickUpPack::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
	 	GameBase::setActive(%this,true);
		Gamebase::setMapName(%this, "Pick Up Pack");
		%this.ammount = 5000;	
	}
	else
	{
		schedule("PickUpPack::deployCheck(" @ %this @ ");", 3, %this);
	}
}


//================================================= Spike Trap Mine

MineData TrapPad1
{
	className = "Mine";
   	description = "Punji Spike Trap";
   	shapeFile = "force";
   	shadowDetailMask = 4;
   	explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.01;
	damageType = $TrapDam1;
	kickBackStrength = 0;
	triggerRadius = 2.5;
	maxDamage = 0.25;
	shadowDetailMask = 0;
	destroyDamage = 3.0;
	damageLevel = {1.0, 1.0};
	//validateShape = true;
};

function TrapPad1::onAdd(%this)
{
	%this.damage = 0;
	TrapPad1::deployCheck(%this);
}

function TrapPad1::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	%client = %this.tc;
	%name = Client::getName(%client);
    	%trapclient = Player::getClient(%object);
	if ((%type == "Player") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) )
	{
		%spikepos = Gamebase::getPosition(%object);
		%spikenpos = Vector::add(%spikepos, "0 0 1");
		%spikerot = Vector::add(GameBase::getRotation(%object), "0 0 0");
		%inv = newObject("Punji Spike","StaticShape","PlantOne",true);
		addToSet("MissionCleanup", %inv);
		GameBase::setTeam(%inv,-1);
		GameBase::setRotation(%inv,%spikerot);
		GameBase::setPosition(%inv,%spikenpos);
		Gamebase::setMapName(%inv,"Punji Spike" @  Client::getName(%object));
		playSound(SoundFlierCrash,$los::position);
		%client.score = (%client.score +5);
  		Bottomprint(%client, "<jc><f2>Punji Spike Trap Success! Score +5 = " @ %client.score,3);
		GameBase::setDamageLevel(%this, %data.maxDamage);
		MessageAllExcept(Player::getClient(%object), 1, Client::getName(%trapclient) @ " is impailed by " @ %name @ "'s punji spike!~wplayer_death.wav");
		Client::sendMessage(%trapclient,1, %name @ "'s Punji Spike Trap!~wLand_On_Ground.wav");
	}
}

function TrapPad1::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) 
	{
	 	GameBase::setActive(%this,true);
	}
	else 
		schedule("TrapPad1::deployCheck(" @ %this @ ");", 3, %this);
}	

function TrapPad1::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "TrapPack1"]--;
}

function TrapPad1::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//================================================= Lasso Mine

MineData TrapPad2
{
	className = "Mine";
   	description = "Lasso Trap";
   	shapeFile = "force";
   	shadowDetailMask = 4;
   	explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.01;
	damageType = $TrapDam2;
	kickBackStrength = 0;
	triggerRadius = 2.5;
	maxDamage = 0.25;
	shadowDetailMask = 0;
	destroyDamage = 3.0;
	damageLevel = {1.0, 1.0};
	//validateShape = true;
};

function TrapPad2::onAdd(%this)
{
	%this.damage = 0;
	TrapPad2::deployCheck(%this);
}

function TrapPad2::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	%client = %this.tc;
	%name = Client::getName(%client);
    	%trapclient = Player::getClient(%object);
	if ((%type == "Player") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) )
	{
		%forceDir = Vector::getFromRot(GameBase::getRotation(%object),0,300); 
		Player::applyImpulse(%object,%forceDir);
		schedule("Player::applyImpulse("@%object@", "@%forceDir@");", 0.2, %this);
		schedule("Player::applyImpulse("@%object@", "@%forceDir@");", 0.3, %this);
		schedule("Player::applyImpulse("@%object@", "@%forceDir@");", 0.35, %this);
		schedule("lasso("@%object@", "@%client@");", 0.375, %object);
		%client.score = (%client.score +5);
  		Bottomprint(%client, "<jc><f2>Lasso-Snare Trap Success! Score +5 = " @ %client.score ,3);
		deleteObject(%this);
		MessageAllExcept(Player::getClient(%object), 1, Client::getName(%trapclient) @ " is snared by " @ %name @ "'s lasso trap!~wplayer_death.wav");
		Client::sendMessage(%trapclient,1, %name @ "'s Lasso-Snare Trap!~wthrowitem.wav");
	}
}

function TrapPad2::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) 
	{
	 	GameBase::setActive(%this,true);
	}
	else 
		schedule("TrapPad2::deployCheck(" @ %this @ ");", 3, %this);
}	

function TrapPad2::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "TrapPack2"]--;
}

function TrapPad2::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//================================================= Energy Trap Mine

MineData TrapPad6
{
	className = "Mine";
   	description = "Booby Trap Trigger";
   	shapeFile = "force";
   	shadowDetailMask = 4;
   	explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.01;
	damageType = $TrapDam6;
	kickBackStrength = 0;
	triggerRadius = 2.5;
	maxDamage = 0.25;
	shadowDetailMask = 0;
	destroyDamage = 3.0;
	damageLevel = {1.0, 1.0};
};

function TrapPad6::onAdd(%this)
{
	%this.damage = 0;
	TrapPad6::deployCheck(%this);
}

function TrapPad6::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	if ((%type == "Player") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) )
	{
            %client = Player::getClient(%object);
		%spikepos = Gamebase::getPosition(%object);
		%pos = Vector::add(%spikepos, "0 0 3.5");
		%pos1 = Vector::add(%spikepos, "0 0 4");
            %pos2 = Vector::add(Gamebase::getPosition(%object), EmplacementPack::rotVector( "0 -2 2", GameBase::getRotation(%object) ) );
            %pos3 = Vector::add(Gamebase::getPosition(%object), EmplacementPack::rotVector( "0 2 2", GameBase::getRotation(%object) ) );
            %pos4 = Vector::add(Gamebase::getPosition(%object), EmplacementPack::rotVector( "2 0 2", GameBase::getRotation(%object) ) );
            %pos5 = Vector::add(Gamebase::getPosition(%object), EmplacementPack::rotVector( "-2 0 2", GameBase::getRotation(%object) ) );
		%pos6 = Vector::add(%spikepos, "0 0 2");
		%spikerot = Vector::add(GameBase::getRotation(%object), "0 0 0");
		%wall2 = Vector::add(GameBase::getRotation(%object), "0 -1.57 1.57");
		%wall3 = Vector::add(GameBase::getRotation(%object), "0 -1.57 1.57");
		%wall4 = Vector::add(GameBase::getRotation(%object), "0 -1.57 0");
		%wall5 = Vector::add(GameBase::getRotation(%object), "0 -1.57 0");
		%gast = Vector::add(GameBase::getRotation(%object), "0 -1.57 0");
		%sensor = newObject("Cage Power","StaticShape",CagePower,true);
		CreateteleportSimSet();
		addToSet("MissionCleanup/Teleports", %sensor);
		addToSet("MissionCleanup", %sensor);
		GameBase::setTeam(%sensor,GameBase::getTeam(%object));
		GameBase::setPosition(%sensor,%pos);
		GameBase::setRotation(%sensor,%spikerot);
		Gamebase::setMapName(%sensor,"Cage Power");
		%sensor.disabled = false;
		%beam1 = newObject("","StaticShape",PlasmaWall,true);
		addToSet("MissionCleanup", %beam1);
		GameBase::setTeam(%beam1,GameBase::getTeam(%object));
		GameBase::setPosition(%beam1,%pos1);
		GameBase::setRotation(%beam1,GameBase::getRotation(%object));
		%beam2 = newObject("","StaticShape",PlasmaWall,true);
		addToSet("MissionCleanup", %beam2);
		GameBase::setTeam(%beam2,GameBase::getTeam(%object));
		GameBase::setPosition(%beam2,%pos2);
		GameBase::setRotation(%beam2,%wall2);
		%beam3 = newObject("","StaticShape",PlasmaWall,true);
		addToSet("MissionCleanup", %beam3);
		GameBase::setTeam(%beam3,GameBase::getTeam(%object));
		GameBase::setPosition(%beam3,%pos3);
		GameBase::setRotation(%beam3,%wall3);
		%beam4 = newObject("","StaticShape",PlasmaWall,true);
		addToSet("MissionCleanup", %beam4);
		GameBase::setTeam(%beam4,GameBase::getTeam(%object));
		GameBase::setPosition(%beam4,%pos4);
		GameBase::setRotation(%beam4,%wall4);
		%beam5 = newObject("","StaticShape",PlasmaWall,true);
		addToSet("MissionCleanup", %beam5);
		GameBase::setTeam(%beam5,GameBase::getTeam(%object));
		GameBase::setPosition(%beam5,%pos5);
		GameBase::setRotation(%beam5,%wall5);
		%beam6 = newObject("Energy Floor","Turret","GasTurr",true);
		addToSet("MissionCleanup", %beam6);
     		GameBase::setTeam(%beam6,5);
 		GameBase::setPosition(%beam6,%pos6);
		GameBase::setRotation(%beam6,GameBase::getRotation(%object));
		%sensor.beam1 = %beam1;
		%sensor.beam2 = %beam2;
		%sensor.beam3 = %beam3;
		%sensor.beam4 = %beam4;
		%sensor.beam5 = %beam5;
		%sensor.beam6 = %beam6;
		%beam6.tc = %this.tc;
		GameBase::setDamageLevel(%this, 10);
		MessageAllExcept(Player::getClient(%object), 1, Client::getName(%client) @ " is trapped by an energy snare!~welf_fire.wav");
		Client::sendMessage(%client,1,"Energy Snare!~welf_fire.wav");
	}
}

function TrapPad6::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) 
	{
	 	GameBase::setActive(%this,true);
	}
	else 
		schedule("TrapPad6::deployCheck(" @ %this @ ");", 3, %this);
}	

function TrapPad6::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "TrapPack6"]--;
}

function TrapPad6::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//=========================== Demolision Charge

MineData DemoMine
{
	className = "Mine";
	description = "Repair";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	explosionId = mortarExp;
	explosionRadius = 5.0;
	damageValue = 0.75;
	damageType = $MineDamageType;
	kickBackStrength = 350;
	triggerRadius = 10;
	maxDamage = 2.00;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
};

function DemoMine::onAdd(%this)
{
	%this.damage = 0;
	schedule("Mine::Detonate(" @ %this @ ");",300,%this);
}

function DemoMine::onCollision(%this,%object)
{
	if (GameBase::getTeam(%this) != GameBase::getTeam(%object) && Player::getMountedItem(%this.deployer,$BackpackSlot) == StrikePack)
	{
		bottomprint(%this.deployer,"<jc>"@Client::getName(Player::getClient(%object))@" is within demolition range.", 1);
	}
}

function DemoMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

function DemoMine::onDestroyed(%this)
{
	GameBase::applyRadiusDamage($ShrapnelDamageType, getBoxCenter(%this), 4, 3, 305, %this.deployer);
}


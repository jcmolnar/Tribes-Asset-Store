exec("comchat.cs");
exec("shban.cs");
exec("helpscreen.cs");

if($Wasteland::noSwearing)
	exec("SHBadwordlist.cs");

if($Wasteland::ScoreTracker)
	exec("scoretracker.cs");

exec("remote.cs");

exec("spawn.cs");

exec("game_dmsg.cs");

exec("damage.cs");

if (getNumTeams() == 2)
{
	exec("fairteams.cs");
}

//================================================== Globals

if ($Wasteland::TeamDamage != false)
	$Server::TeamDamageScale = 1;

$MODInfo = $Server::MODInfo;

$fa_armor = "";
$fa_pack = "";
$pskin = true;
$SensorNetworkEnabled = true;
$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;
$modmgtModName = "SHAntiTK";
$modmgtModVers = "1.30";
$SHBanListMarker = "true";

if ($SpawnFavs != "False") $SpawnFavs = True;
if (!$SHAntiTeamKillProximity) $SHAntiTeamKillProximity = 50;

if($SHAntiTeamKillWarnKills == "")
	$SHAntiTeamKillWarnKills = 1;
if($SHAntiTeamKillBanTime == "")
	$SHAntiTeamKillBanTime = 600;
if($SHAntiTeamKillMaxKills == "")
	$SHAntiTeamKillMaxKills = 2;
if($SHAntiTeamKillProximity == "")
    $SHAntiTeamKillProximity = 50;


//================================================== End Globals

$DefaultTeamEnergy = "Infinite";

$TeamEnergy[-1] = $DefaultTeamEnergy;
$TeamEnergy[0]  = $DefaultTeamEnergy;
$TeamEnergy[1]  = $DefaultTeamEnergy;
$TeamEnergy[2]  = $DefaultTeamEnergy;
$TeamEnergy[3]  = $DefaultTeamEnergy;
$TeamEnergy[4]  = $DefaultTeamEnergy;
$TeamEnergy[5]  = $DefaultTeamEnergy;
$TeamEnergy[6]  = $DefaultTeamEnergy;
$TeamEnergy[7]  = $DefaultTeamEnergy;

//---------------------------------------------------------------------------------
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 1;

//---------------------------------------------------------------------------------
// MAX amount team energy can reach
//---------------------------------------------------------------------------------
$MaxTeamEnergy = 700000;

//---------------------------------------------------------------------------------
// Amount to inc team energy every ($secTeamEnergy) seconds
//---------------------------------------------------------------------------------
$incTeamEnergy = 700;

//---------------------------------------------------------------------------------
// (Rate is sec's) Set how often TeamEnergy is incremented
//---------------------------------------------------------------------------------
$secTeamEnergy = 30;

//---------------------------------------------------------------------------------
// (Rate is sec's) Items respwan
//---------------------------------------------------------------------------------
$ItemRespawnTime = 30;

//---------------------------------------------------------------------------------
//Amount of Energy remote stations start out with
//---------------------------------------------------------------------------------
$RemoteAmmoEnergy = 2500;
$RemoteInvEnergy = 7500;

//---------------------------------------------------------------------------------
// TEAM ENERGY -  Warn team when teammate has spent x amount - Warn team that
//				  energy level is low when it reaches x amount
//---------------------------------------------------------------------------------
$TeammateSpending = -4000;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 4000;	    //Set = to 0 if don't want the warning message

//---------------------------------------------------------------------------------
// Amount added to TeamEnergy when a player joins a team
//---------------------------------------------------------------------------------
$InitialPlayerEnergy = 5000;

//---------------------------------------------------------------------------------
// REMOTE TURRET
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 3;     	//Number of remote turrets allowed in the area
$TurretBoxMaxLength = 50;    	//Define Max Length of the area
$TurretBoxMaxWidth =  50;    	//Define Max Width of the area
$TurretBoxMaxHeight = 10;    	//Define Max Height of the area

$TurretBoxMinLength = 10;	//Define Min Length from another turret
$TurretBoxMinWidth =  10;	//Define Min Width from another turret
$TurretBoxMinHeight = 10;    	//Define Min Height from another turret

//---------------------------------------------------------------------------------
//	Object Types
//---------------------------------------------------------------------------------
$SimTerrainObjectType   = 1 << 1;
$SimInteriorObjectType  = 1 << 2;
$SimPlayerObjectType    = 1 << 7;

$MineObjectType		= 1 << 26;
$MoveableObjectType	= 1 << 22;
$VehicleObjectType	= 1 << 29;
$StaticObjectType	= 1 << 23;
$ItemObjectType		= 1 << 21;

//=========================================
// CHEATS
//=========================================
$ServerCheats = 0;
$TestCheats = 0;
$AutoRespawn = 0;

//=========================================
function Game::playerSpawned(%pl, %clientId, %armor)
{
	$Wasteland::JustSpawned[%clientId] = "True";
	schedule ("$Wasteland::JustSpawned[" @ %clientId @ "] = False;",$Wasteland::SpawnSafe);

	if ($Client::info[%clientId, 0] == ""){}
	else Client::setSkin(%clientId, $Client::info[%clientId, 0]);

	%clientId.spawntime = getsimtime();
	%power = IsPowerDown(gamebase::getteam(%clientId));

	//========================================= Custom Spawn Settings
	//== Spawn Notifications Added By Ascain.

	if ($Wasteland::PowerCheck != "False" && !%power)
	{
		echo ("=============SPAWN - Power down - standard");
		standardSpawnList(%clientId);
		schedule ("bottomprint( " @ %clientId @ ", \"<jc><f2>You have spawned in standard armor, YOUR POWER IS DOWN!!!\", 10);" ,3);

		if (Game::playerSetSpawned(%pl, %clientId, %armor))
			return true;
		return false;
	}
	else if (%clientId.spawntype == "standard")
	{
		echo ("=============SPAWN - Normal Standard");
		standardSpawnList(%clientId);
		bottomprint(%clientId, "<jc><f2>You have spawned in <f0>" @ $fa_armor @ "<f2> armor with a <f0>" @ $fa_pack @ "<f2> backpack.", 10);

		if (Game::playerSetSpawned(%pl, %clientId, %armor))
			return true;
		return false;
	}
	else if (%clientId.spawntype == "random")
	{
		echo ("=============SPAWN - Random");
		randomSpawnList(%clientId);
		bottomprint(%clientId, "<jc><f2>You have spawned in <f0>" @ $fa_armor @ "<f2> armor with a <f0>" @ $fa_pack @ "<f2> backpack.", 10);

		if (Game::playerSetSpawned(%pl, %clientId, %armor))
			return true;
		return false;
	}
	else if (%clientId.spawntype == "favs")
	{
		echo ("=============SPAWN - Favs");
		if (%clientId.favsettings) { bottomprint(%clientId, "<jc><f2>You have spawned with your last bought favorites.", 10);}
		else { bottomprint(%clientId, "<jc><f2>You must select your favorites first before you can be spawned with them.", 10);}

		if (Game::playerSetSpawned(%pl, %clientId, %armor))
			return true;
		return false;
	}
	else if ($Wasteland::SaveOn && %clientId.SavedInfo && %clientId.spawntype == "saved")
	{
		echo ("=============SPAWN - Player Saved");
		savedSpawnList(%clientId);
		%clientId.spawntype = %clientId.spawntypetwo;

		if (Game::playerSetSpawned(%pl, %clientId, %armor))
			return true;
		return false;
	}
	echo ("=============SPAWN - Ooops No Spawn!?!");
}

function Game::playerSetSpawned(%pl, %clientId, %armor)
{
	//============= Buy Actual Items

	%clientId.spawn = 1;
	%max = getNumItems();

	for(%i = 0; (%item = $spawnBuyList[%i, %clientId]) != ""; %i++)
	{
		buyItem(%clientId,%item);
		if(%item.className == Weapon)
			%clientId.spawnWeapon = %item;
	}
	for (%i = 0; %i < 6; %i++)
	{
		buyItem(%clientId,"Beacon");
		buyItem(%clientId,"Grenade");
		buyItem(%clientId,"MineAmmo");
	}
	buyItem(%clientId,"TargetingLaser");
	buyItem(%clientId,"RepairKit");
	%clientId.spawn = "";

	if(%clientId.spawnWeapon != "")
	{
		Player::useItem(%pl,%clientId.spawnWeapon);
		%armor = Player::getArmor(%clientId);

		if (%armor == "jarmor") //============== Check Juggernaught
		{
			Player::mountItem(%clientId, Mortar, $WeaponSlot);
		}
		%clientId.spawnWeapon="";
	}

	if ($Wasteland::PublicNotice != "")
	{
		%clientId.spawnnum++;
		if (%clientId.spawnnum > 1)
		{
			bottomprint (%clientId, "<jc>" @ $Wasteland::PublicNotice @ "",4);
			%clientId.spawnnum = 0;
		}
	}
      return true;
}


//=============================

function Game::playerSpawn(%clientId, %respawn)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
   		%totalClients++;
	}
	if (%totalClients >= $Server::MaxPlayers)
	{
		%name = Client::getName(%clientId);
		if ($ClanSet !="" && $Client::info[%clientId, 3] != $ClanSet)
		{
			%curTimeLeft = ($Server::timeLimit * 60) - getSimTime();
			%time = floor(%curTimeLeft);
			KickPlayer(%clientId, "Sorry, but this " @ $ClanSet @ " Clan practice mission has too many guests. Please try back in about " @ %time @ " minutes. Thank you.");
			messageall(0,"Guest " @ %name @ " is being dropped to hold a space for " @ $ClanSet @ " clan members.");
			echo("ADMINMSG: **** Non-"@ $ClanSet @" guest " @ %name @ " being dropped.");
		}
		%password = $Client::info[%clientId, 5];
		if((%password == "" || %password != $Server::Admin["sadpw", %name]) && ($BioPrivate == "1" || $BioPrivate == "2") )
		{
			BanList::add(Client::getTransportAddress(%clientId), 1800);
			if ($BioPrivate == "2") KickPlayer(%clientId, "Sorry, but this server is only for registered players.  Apply at " @$Wasteland::url);
			if ($BioPrivate == "1") KickPlayer(%clientId, "Sorry, but this server is full with registered players.  Try one of the many other popular BioWasteland Servers.");
			messageall(0,"Guest " @ %name @ " is being dropped to hold a space for registered players.");
			echo("ADMINMSG: **** Guest " @ %name @ " being dropped.");
		}
	}
   	if(!$ghosting)
      	return false;

	if($Game::missionType == "Duel" && !$DuelCanSpawn[%clientId]) return;

	if (!$Wasteland::SpawnType || $Wasteland::SpawnType != "random" || $Wasteland::SpawnType != "standard")
	{
		$Wasteland::SpawnType = "random";
	}

	if (%clientId.spawntype != "favs" && %clientId.spawntype != "random" && %clientId.spawntype != "standard" && %clientId.spawntype != "saved")
	{
		%clientId.spawntype = $Wasteland::SpawnType;
	}

	Client::clearItemShopping(%clientId);
   	%spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);

  	if(!%respawn) //=========== Server Welcome Message On First Spawn
  	{
		if ($Wasteland::WelcomeDelay > 0) centerprint(%clientId, $Wasteland::WelcomeMsg, $Wasteland::WelcomeDelay);

   		if ($Wasteland::Saveon)
   		{
   			LoadCharacter(%clientId);
		}
		if ($Game::missionType == "Duel") bottomprint(%clientId, "<jc><f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for duel objectives.", 5);
   	}
//=========================================
//  Eliminator Maps
//=========================================
	if ($Game::missionType == "ELIM")
	{
		if (%clientId.elim == "true")
		{
			Client::sendMessage(%clientId,1,"~wfemale2.wwait1.wav");
			centerprint(%clientId, "<jc><f2>You've been eliminated! Wait for this round to finish.");
			%numPlayers = getNumClients();
			for(%j = 0; %j < %numPlayers; %j = %j + 1)
			{
				%id = getClientByIndex(%j);
				if (%id.elim != "true" && Client::getTeam(%id) != -1) %this = Client::getOwnedObject(%id);
				if (%id.elim != "true" && Client::getTeam(%id) == Client::getTeam(%clientId))
				{
					%this = Client::getOwnedObject(%id);
					Observer::setOrbitObject(%clientId, %this, 10, 10, 10);
					bottomprint(%clientId, "<jc><f2>You've been eliminated.  Observe team mate " @ Client::getName(%id) @ " while you wait.", 5);
					bottomprint(%id, "<jc><f2>Team mate " @ Client::getName(%clientId) @ " is watching for you to win!", 3);
					return false;
				}
			}
			if (!%this) eliminate(%clientId);
			Observer::setOrbitObject(%clientId, %this, 10, 10, 10);
			%id = Player::getClient(%this);
			%team = Client::getTeam(%id);
			%name = getTeamName(%team);
			bottomprint(%clientId, "<jc><f2>Your team lost.  Observe " @ %name @ " " @ Client::getName(%id) @ " while you wait.", 5);
			bottomprint(%id, "<jc><f2>Loser " @ Client::getName(%clientId) @ " is observing you.", 3);
			return false;
		}
	}
	if (%clientId.race == "wait")
	{
		Client::sendMessage(%clientId,1,"~wfemale2.wwait1.wav");
		centerprint(%clientId, "<jc><f2>Wait for the next race to begin.");
		return false;
	}
	if(%spawnMarker)
	{
		%clientId.guiLock = "";
	 	%clientId.dead = "";
	 	%clientId.observermode = "";

	   	if(%spawnMarker == -1){%spawnPos = "0 0 300";%spawnRot = "0 0 0";}
	   	else
		{
			%team = Client::getTeam(%clientId);
			if (%team.newspawn != "")
			{
				%rnd = floor(getRandom() * 100);
				if (%rnd > 60) %spawnMarker = %team.newspawn;
				else if ($TeamItemCount[%team @ "SpawnPack"] < $TeamItemMax["SpawnPack"]) %spawnMarker = %team.newspawn;
			}
			if (%clientId.jail == "True")
			{
				%teleset = nameToID("MissionCleanup/jailports");
				for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
				{
					%oteam=GameBase::getTeam(%o);
					if(%oteam != %team)
					{
						%spawnMarker = %o;
						systemMessage(%clientId,1,"Not even death can escape a jail sentence!~wCapturedTower.wav");
						echo("ADMINMSG: **** Spawning player returns to jail after death.");
					}
				}
			}
			if (%clientId.banish == "True")
			{
				%spawnMarker = $Banish;
				MessageAllExcept(%clientId, 0, Client::getName(%clientId) @" is dying to return from banishment, but should have played nicer.");
				Client::sendMessage(%clientId,1,"Not even death can redeem the banished!~wCapturedTower.wav");
				collectbone(%spawnMarker, %spawnMarker, %spawnMarker, %spawnMarker);
				echo("ADMINMSG: **** Spawning player is banished after death.");
			}
			if (%clientId.curse == "True")
			{
				echo("ADMINMSG: **** Spawning player is cursed after death.");
				schedule("curse("@%clientId@",\"You won't rid yourself of the Penis Curse that easily!~wshieldhit.wav\");",5,%clientId);
			}
			%spawnPos = GameBase::getPosition(%spawnMarker);
			%spawnRot = GameBase::getRotation(%spawnMarker);
		}

	   	if(!String::ICompare(Client::getGender(%clientId), "Male"))
	   		%armor = "larmor";
	   	else
	   		%armor = "lfemale";

	   	%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	   	if ($debug) echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);

		if (%clientId.jail == "True")
		schedule("jLargeForceField::jailSesame("@%pl@");",20);

	   	if(%pl != -1)
	   	{
	   	   	GameBase::setTeam(%pl, Client::getTeam(%clientId));
	   	   	Client::setOwnedObject(%clientId, %pl);

	   	   	echo ("Game::playerSpawned 1");
	   	   	if (!Game::playerSpawned(%pl, %clientId, %armor, %respawn))
	   	   	{
	   	   		echo ("Spawn Failed");
	   	   		Client::sendMessage(%clientId,0,"Sorry Respawn Failed - Try again later ");
	   	   		return false;
	   	   	}

	   	   	if($matchStarted)
	   	      		Client::setControlObject(%clientId, %pl);
	   	   	else
	   	   	{
	   	   	   	%clientId.observerMode = "pregame";
	   	   	   	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	   	   	   	Observer::setOrbitObject(%clientId, %pl, 5, 5, 5);
	   	   	}
	   	}
      	return true;
	}
	else
	{
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      	return false;
	}
}

function Time::getMinutes(%simTime){return floor(%simTime / 60);}
function Time::getSeconds(%simTime){return %simTime % 60;}

function Game::pickRandomSpawn(%team)
{
	%spawnSet = nameToID("MissionCleanup/TeamDrops" @ %team);
	%spawnCount = Group::objectCount(%spawnSet);
	if(!%spawnCount) return -1;
  	%spawnIdx = floor(getRandom() * (%spawnCount - 0.1));
  	%value = %spawnCount;
	for(%i = %spawnIdx; %i < %value; %i++)
	{
		%set = newObject("randomspawnset",SimSet);
		%obj = Group::getObject(%spawnSet, %i);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0)
		{
			deleteObject(%set);
			return %obj;
		}
		if(%i == %spawnCount - 1)
		{
			%i = -1;
			%value = %spawnIdx;
		}
		deleteObject(%set);
	}
   	return false;
}

function Game::pickStartSpawn(%team)
{
	%group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\DropPoints\\Start");
	%count = Group::objectCount(%group);
	if(!%count)
		return -1;

	%spawnIdx = $lastTeamSpawn[%team] + 1;

	if(%spawnIdx >= %count)
		%spawnIdx = 0;
	$lastTeamSpawn[%team] = %spawnIdx;
	return Group::getObject(%group, %spawnIdx);
}

function Game::pickTeamSpawn(%team, %respawn)
{
	if(%respawn)
		return Game::pickRandomSpawn(%team);
	else
	{
		%spawn = Game::pickStartSpawn(%team);
		if(%spawn == -1)
			return Game::pickRandomSpawn(%team);
		return %spawn;
	}
}

function Game::pickObserverSpawn(%client)
{
	%group = nameToID("MissionGroup\\ObserverDropPoints");
	%count = Group::objectCount(%group);

	if(%group == -1 || !%count)
		%group = nameToID("MissionGroup\\Teams\\team" @ Client::getTeam(%client) @ "\\DropPoints\\Random");
	%count = Group::objectCount(%group);

	if(%group == -1 || !%count)
		%group = nameToID("MissionGroup\\Teams\\team0\\DropPoints\\Random");

	%count = Group::objectCount(%group);

	if(%group == -1 || !%count)
		return -1;

	%spawnIdx = %client.lastObserverSpawn + 1;

	if(%spawnIdx >= %count)
		%spawnIdx = 0;

	%client.lastObserverSpawn = %spawnIdx;
	return Group::getObject(%group, %spawnIdx);
}

function UpdateClientTimes(%time)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		remoteEval(%cl, "setTime", -%time);
}

function Game::notifyMatchStart(%time)
{
	messageAll(0, "Match starts in " @ %time @ " seconds.");
	UpdateClientTimes(%time);
}

function Game::startMatch()
{
	if ($Game::missionType == "Duel")
	{
		$DuelsStarted = "";
		$ServerMode = "Duel";
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			$ClientInGame[%cl] = "JustJoined";
		}
	}
	$matchStarted = true;
	$missionStartTime = getSimTime();
	messageAll(0, "Match started.");
	Game::resetScores();

	echo("\"M\"" @ $missionName @ "\"" @ ($Server::timeLimit * 60) + $missionStartTime - getSimTime() @ "\"");

	//======================= Create Power Object Tree
	DumpObjectTree();

	%numTeams = getNumTeams();
	for(%i = 0; %i < %numTeams; %i = %i + 1)
	{
		if($TeamEnergy[%i] != "Infinite")
		schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
	}

	echo ("Match Observer");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pregame")
		{
			%cl.observerMode = "";
			Client::setControlObject(%cl, Client::getOwnedObject(%cl));
		}
		Game::refreshClientScore(%cl);
	}
	echo ("Match Observer Done");
	if ($Game::missionType == "Duel")
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			DuelResetClient(%cl);
			GameBase::SetTeam(%cl, -1);
		}
	}
	Game::checkTimeLimit();
	if ($Game::missionType == "Duel") DuelCheckPlayers();
}

function Game::pickPlayerSpawn(%clientId, %respawn)
{
	//====== Race Maps
	if (!%clientId.race || !%clientId.leg) return Game::pickTeamSpawn(Client::getTeam(%clientId), %respawn);
	else
	{
		%obj = %clientId.leg;
		return %obj;
	}
}

function Game::autoRespawn(%client)
{
	if(%client.dead == 1)
	{
		echo ("AutoRespawn 1");
		Game::playerSpawn(%client, "true");
		echo ("AutoRespawn 2");
	}
}

function onServerGhostAlwaysDone(){}

function Game::initialMissionDrop(%clientId)
{
	// Fires just after client connects and just before assigned a team
	Client::setGuiMode(%clientId, $GuiModePlay);
	DuelResetClient(%clientId);
   	if($Server::TourneyMode)
   	{
      	%clName = Client::getName(%clientId);
      	if(String::findSubStr(%clName,$Wasteland::Tag0) >= 0)
		{
			GameBase::setTeam(%clientId, 0);
		}
		else if(String::findSubStr(%clName,$Wasteland::Tag1) >= 0)
		{
			GameBase::setTeam(%clientId, 1);
		}
      	else GameBase::setTeam(%clientId, -1);
   	}
   	else
   	{
   	   	if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit")
   	   	{
   		    	%clientId.observerMode = "observerOrbit";
   		    	%clientId.guiLock = "";
	   	    	Observer::jump(%clientId);
   	        	return;
       	}
       	%numTeams = getNumTeams();
   	   	%curTeam = Client::getTeam(%clientId);
		if ($Game::missionType == "Duel")
		{
			DuelResetClient(%clientId);
			GameBase::SetTeam(%clientId, -1);
			Client::sendMessage(%clientId, 3, "Hit [tab] for menu to select a dueling opponent.");
		}
      	else if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) ) Game::assignClientTeam(%clientId);
   	}

	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	%camSpawn = Game::pickObserverSpawn(%clientId);
	Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn),
	GameBase::getRotation(%camSpawn), true, true);

	if(Client::getTeam(%clientId) == -1 && $Game::missionType != "Duel")
	{
		%clientId.observerMode = "pickingTeam";

		if($Server::TourneyMode && ($matchStarted || $matchStarting))
		{
			%clientId.observerMode = "observerFly";
			return;
		}
		else if($Server::TourneyMode)
		{
			if($Server::TeamDamageScale)
				%td = "ENABLED";
			else
				%td = "DISABLED";
			bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nYour team will be assigned.\nTeam damage is " @ %td, 0);
		}
		else
		{
			Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
			Client::addMenuItem(%clientId, "0Observe", -2);
			Client::addMenuItem(%clientId, "1Automatic", -1);

			for(%i = 0; %i < getNumTeams(); %i = %i + 1)
				Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		}
		%clientId.justConnected = "";
	}
	else
	{
		Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);

		if(%clientId.justConnected)
		{
			%clName = Client::getName(%clientId);
			if(String::findSubStr(%clName,".1") >= 0)
			{
				echo("ADMINMSG: **** Dropping Duplicate: " @ %clientId @ " - " @ %name);
				MessageAllExcept(%clientId, 1, "Dropping the duplicate "@%name@".~wfemale5.wcolor6.wav");
   				KickPlayer(%clientId, "Sorry, that name is already being used.");
				return;
			}
			Wasteland::Autoadmin(%clientId);
			SHCheckTransportAddress(%clientid);
			schedule("centerprint(clientId,\"\"@ $Server::JoinMOTD @\"\");",1);
			%clientId.observerMode = "justJoined";
			%clientId.justConnected = "";
		}
		else if(%clientId.observerMode == "justJoined")
		{
			centerprint(%clientId, "");
			%clientId.observerMode = "";
			Game::playerSpawn(%clientId, false);
		}
		else if ($Game::missionType != "Duel")
		{
			Game::playerSpawn(%clientId, false);
		}
	}

	if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite")
		$TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
	%clientId.teamEnergy = 0;
}

function processMenuPickTeam(%clientId, %team, %adminClient) // admin.cs
{
	if (%adminClient==2048) $AdminName = "the Administrator";
	else $AdminName = Client::getName(%adminClient);
	%oldteam = Client::getTeam(%clientId);
	checkPlayerCash(%clientId);
	if(%team != -1 && %team == %oldteam) return;

	if(%clientId.observerMode == "justJoined")
	{
		%clientId.observerMode = "";
		centerprint(%clientId, "");
	}
	%name = Client::getName(%clientId);
	if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2)
	{
		if(Observer::enterObserverMode(%clientId))
      	{
			%clientId.notready = "";
			if(%adminClient == "") messageAll(0, %name @ " became an observer.");
			else
			{
      	      	messageAll(0, %name @ " was forced into observer mode by " @ $AdminName @ ".");
				if ($Wasteland::SwitchPerm)
				{
					%clientId.SwitchPerm = true;
				}
			}
			echo ("ADMINMSG: " @ %name @ " is now an observer.");
			Game::resetScores(%clientId);
			Game::refreshClientScore(%clientId);
      	}
      	return;
   	}

	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{
		playNextAnim(%clientId);
		Player::kill(%clientId);
	}
	%clientId.observerMode = "";
	%clientId.observerTarget = "";
	if(%adminClient == "") messageAll(0, %name @ " changed teams.");
	else
	{
      	messageAll(0, %name @ " was teamchanged by " @ $AdminName @ ".");
		if ($Wasteland::SwitchPerm)
		{
			%clientId.SwitchPerm = true;
		}
	}
	echo ("ADMINMSG: " @ %name @ " is now on a new team.");
	if(%team == -1)
	{
		Game::assignClientTeam(%clientId);
		%team = Client::getTeam(%clientId);
	}
	GameBase::setTeam(%clientId, %team);
	if ($Game::missionType == "ELIM") %clientId.elim = "true";
	%clientId.teamEnergy = 0;
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1) Client::setGuiMode(%clientId,1);
	Client::setControlObject(%clientId, -1);
   	Game::playerSpawn(%clientId, false);
	%team = Client::getTeam(%clientId);
	if($TeamEnergy[%team] != "Infinite") $TeamEnergy[%team] += $InitialPlayerEnergy;
	if($Server::TourneyMode && !$CountdownStarted)
	{
		centerprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
		%clientId.notready = true;
	}
	freeturrets(%clientId, %oldteam);
}

function Game::ForceTourneyMatchStart()
{
	%playerCount = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pregame")
			%playerCount++;
	}

	if(%playerCount == 0)
		return;

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pickingTeam")
			processMenuInitialPickTeam(%cl, -2); // throw these guys into observer
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%cl.notready = "";
			%cl.notreadyCount = "";
			bottomprint(%cl, "", 0);
		}
	}
	Server::Countdown(30);
}

function Game::CheckTourneyMatchStart()
{

	if($CountdownStarted || $matchStarted)
		return;

	// loop through all the clients and see if any are still notready
	%playerCount = 0;
	%notReadyCount = 0;

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pickingTeam")
		{
			%notReady[%notReadyCount] = %cl;
			%notReadyCount++;
		}
		else if(%cl.observerMode == "pregame")
		{
			if(%cl.notready)
			{
				%notReady[%notReadyCount] = %cl;
				%notReadyCount++;
			}
			else
				%playerCount++;
		}
	}

	if(%notReadyCount)
	{
		if(%notReadyCount == 1)
			MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
		else if(%notReadyCount < 4)
		{
			for(%i = 0; %i < %notReadyCount - 2; %i++)
				%str = Client::getName(%notReady[%i]) @ ", " @ %str;

			%str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) @ " are holding things up!";

			MessageAll(0, %str);
		}
		return;
	}

	if(%playerCount != 0)
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%cl.notready = "";
			%cl.notreadyCount = "";
			bottomprint(%cl, "", 0);
		}
		Server::Countdown(30);
	}
}

function Game::checkTimeLimit()
{
	$timeLimitReached = false;
	ObjectiveMission::setObjectiveHeading();

	if(!$Server::timeLimit)
	{
		schedule("Game::checkTimeLimit();", 60);
		return;
	}

	%curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
	if((%curTimeLeft >= 118 && %curTimeLeft <= 120) && $matchStarted && $Wasteland::TwoMinute != "False")
	{
		schedule("messageAll(1,\"2 Minute Warning!~waccess_denied.wav\");",0);
		schedule("messageAll(1,\"2 Minute Warning!~waccess_denied.wav\");",0.5);
		schedule("messageAll(1,\"2 Minute Warning!~waccess_denied.wav\");",1.0);
	}

	if(%curTimeLeft <= 0 && $matchStarted)
	{
		echo("GAME: Timelimit reached.");
		$timeLimitReached = true;
		if($debug) echo("checking for objective time limit status...");
		%set = nameToID("MissionCleanup/ObjectiveSet");
		for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
		GameBase::virtual(%obj, "timeLimitReached", %clientId);
		ObjectiveMission::missionComplete();
	}
	else
	{
		if(%curTimeLeft >= 20)
			schedule("Game::checkTimeLimit();", 2);
		else
			schedule("Game::checkTimeLimit();", %curTimeLeft + 1);
		UpdateClientTimes(%curTimeLeft);
	}
}

//======================= Reset Client Scores Back To Zero
function Game::resetScores(%client)
{
	if(%client == "")
	{
	   	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	   	{
	   		%cl.scoreKills = 0;
   	   		%cl.scoreDeaths = 0;
			%cl.ratio = 0;
      		%cl.score = 0;
			%cl.FlagCaps = 0;
			%cl.BadWordsSpoken = 0;
			%client.scoreKills = 0;
			%client.scoreDeaths = 0;
			%client.ismuted=False;
			%client.telepoint = False;
			$stimTime[%client] = 0;
			%cl.TKCount = 0;
		}
		echo ("Reset Scores Finished");
	}
	else
	{
		if ($Wasteland::Saveon)
		{
			SaveCharacter(%client);
		}
		else
		{
			%client.TKCount = 0;
			%client.BadWordsSpoken = 0;
			%client.scoreKills = 0;
			%client.scoreDeaths = 0;
			%client.FlagCaps = 0;
			%client.ratio = 0;
			%client.score = 0;
			%client.ismuted=False;
			%client.telepoint = False;
			$stimTime[%client] = 0;
		}
	}
}

function remoteSetArmor(%player, %armorType)
{
	%client = Player::getClient(%player);
	if(%client.isGod)
	{
	   	Player::setArmor(%player, %armorType);
	}
}

//================================= SetUp Players Stats On Connect
function Game::onPlayerConnected(%playerId)
{
	%playerId.scoreKills = 0;
	%playerId.scoreDeaths = 0;
	%playerId.score = 0;
	%playerId.TKCount = 0;
	%playerId.FlagCaps = 0;
	%playerId.justConnected = true;
	%playerId.favsettings = "False";
	%playerId.Plastic = 5;
	%playerId.boosted = 0;
	%playerId.telepoint = False;
	%playerId.hackattempt = 0;
	%clientId.booster = 0;
	%ClientId.boostercool = 0;

	for (%i = 0; %i <= 21; %i++)
	{
		%playerId.fav[%i] = "";
		$spawnBuyList[%i, %playerId] = "";
	}

	$menuMode[%playerId] = "None";
	Game::refreshClientScore(%playerId);
}


function Game::assignClientTeam(%clientId)																		// game.cs
{
	if($teamplay)
	{
		%name = Client::getName(%clientId);
		%numTeams = getNumTeams();
		%numPlayers = getNumClients();

		for(%i = 0; %i < %numTeams; %i = %i + 1)
			%numTeamPlayers[%i] = 0;

		for(%i = 0; %i < %numPlayers; %i = %i + 1)
		{
			%pl = getClientByIndex(%i);
			if(%pl != %clientId)
			{
				%team = Client::getTeam(%pl);
				%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
			}
		}

		%leastPlayers = %numTeamPlayers[0];
		%leastTeam = 0;

		for(%i = 1; %i < %numTeams; %i++)
		{
			if((%numTeamPlayers[%i] < %leastPlayers) || (%numTeamPlayers[%i] == %leastPlayers && $teamScore[%i] < $teamScore[%leastTeam]))
			{
					%leastTeam = %i;
					%leastPlayers = %numTeamPlayers;
			}
		}

		GameBase::setTeam(%clientId, %leastTeam);
		echo("\"A\"" @ %clientId @ "\"" @ %leastTeam @ "\"");
	}
	else
	{
		GameBase::setTeam(%clientId, 0);
	}
}

function Game::setRandomTeam()
{
	bottomprintall ("<jc>Randomly Assigning Teams - Occurs Every " @ $Wasteland::TeamJuggle @ " Missions.");
	%numTeams = getNumTeams();
	%numPlayers = getNumClients();
	echo ("*********************** BEGINING TEAM ASSIGNMENT");

	if (!%numPlayers)
	{
		if ($debug) echo ("ADMINMSG **** No Players In Game Not Assigning Teams");
		return;
	}

	echo ("**** Numbers Of Players " @ %numPlayers);

	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		%player[%i] = %pl;
		gamebase::setteam(%pl, -1);
		echo ("**** Clearing Player Teams " @ %pl);
	}

	%assigned = 0;

	for(%k = 0; AllOnTeam() || (%assigned < %numplayers); %k++)
	{
		if (%k > 2000)
		{
			echo ("**** Could Not Assign All Players In Given Time - Breaking Loop.");
			break;
		}

		%rnd = floor(getRandom() * (%numPlayers) );
		%playerId = %player[%rnd];

		if (gamebase::getteam(%playerId) == -1 && (%playerId.observerMode != "observerOrbit" && %playerId.observerMode != "observerFly"))
		{
			Game::assignClientTeam(%playerId);
			%name = Client::getName(%playerId);
			echo ("**** Player <" @ %playerId @ "> " @ %name @ "  Assigned To Team " @ gamebase::getteam(%playerId));
			echo ("**** Observermode " @ %playerId.observermode);
			%assigned++;
		}
	}
	echo ("***********************");
	echo ("**** Players Assigned To Teams = " @ %assigned @ " out of " @ %numplayers);
	echo ("*********************** DONE WITH TEAM ASSIGNMENT");
}

function AllOnTeam()
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		if (gamebase::getteam(%pl) == "-1"){return true;}
	}
	echo ("**** All Players Have Been Assigned");
	return false;
}

function Game::clientKilled(%playerId, %killerId)
{
	echo ("Game::clientKilled (" @ %playerId @ " - " @ %killerId @ ").");
	%set = nameToID("MissionCleanup/ObjectivesSet");
	for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
	GameBase::virtual(%obj, "clientKilled", %playerId, %killerId);
}

function Client::leaveGame(%clientId)
{}

//=====================================
//=====================================
//  Player Kills Or Dies
//=====================================
//=====================================

function Player::onKilled(%this)
{
	echo("*** Player Killed ***");
	%this.Station = "";

   	$killedflagcarry = "False";
	%killedflag = "false";
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;

	if ($Game::missionType == "ELIM")
	{
		eliminate(%cl);
	}
	%cl.heatlock = "0";
	%cl.plasmacharge = "0";
	%cl.charging = "0";
	%cl.lascharge = "0";
	%cl.boosted = 0;
	$StimTime[%cl] = "0";
	%cl.ovd = 0;

	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);

	if(%this.outArea==1)
		leaveMissionAreaDamage(%cl);

	Player::setDamageFlash(%this,0.75);

	for (%i = 0; %i < 8; %i = %i + 1)
	{
		%type = Player::getMountedItem(%this,%i);
		if (%type == "flag")
			$killedflagcarry = "True";
		if (%type != -1)
		{
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.6")
				Player::dropItem(%this,%type);
		}
	}

   	if(%cl != -1)
   	{
		if(%this.vehicle != "")
		{
			if(%this.driver != "")
			{
				%this.driver = "";
        	 		Client::setControlObject(Player::getClient(%this), %this);
        	 		Player::setMountObject(%this, -1, 0);
			}
			else
			{
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";
		}

		%kdpos = GameBase::getPosition(%this);
		%this.TKDeathPos = %kdpos;

		%cl.lastkillpos = %kdpos;
		$killedarmor = Player::getArmor(%this);
		schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
		Client::setOwnedObject(%cl, -1);
		Client::setControlObject(%cl, Client::getObserverCamera(%cl));
		Observer::setOrbitObject(%cl, %this, 5, 5, 5);
		schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
		%cl.observerMode = "dead";
		%cl.dieTime = getSimTime();
		if (%cl.scoreDeaths == 9)
		{
			if (Client::getTeam(%cl) == 6)
			{
				schedule("bottomprintall(\"                   <Bskull_big.bmp>\" @ Client::getName(" @ %cl @ ") @ \" has died for the 10th time <Bskull_big.bmp>\");",1);
				messageall(1, Client::getName(%cl) @ " has died 10 times.~wfemale5.wdeath.wav");
			}
			else if (Client::getTeam(%cl) == 7)
			{
				schedule("bottomprintall(\"                   <Bskull_big.bmp>\" @ Client::getName(" @ %cl @ ") @ \" has died for the 10th time <Bskull_big.bmp>\");",1);
				messageall(1, Client::getName(%cl) @ " has died 10 times.~wfemale5.wdeath.wav");
			}
			else {}
		}
		else if (Client::getTeam(%cl) == 6)
		{
			TeamMessages(3, 6, Client::getName(%cl) @ " has died " @ (%cl.scoreDeaths + 1) @ " times.");
			TeamMessages(3, 7, Client::getName(%cl) @ " has died " @ (%cl.scoreDeaths + 1) @ " times.");
			TeamMessages(3, -1, Client::getName(%cl) @ " has died " @ (%cl.scoreDeaths + 1) @ " times.");
		}
		else if (Client::getTeam(%cl) == 7)
		{
			TeamMessages(3, 6, Client::getName(%cl) @ " has died " @ (%cl.scoreDeaths + 1) @ " times.");
			TeamMessages(3, 7, Client::getName(%cl) @ " has died " @ (%cl.scoreDeaths + 1) @ " times.");
			TeamMessages(3, -1, Client::getName(%cl) @ " has died " @ (%cl.scoreDeaths + 1) @ " times.");
		}
		else {}
   	}
	%armor = Player::getArmor(%this);
	if (%armor == "aarmor" || %armor == "afemale")
	{
		%obj = newObject("","Mine","CloakBlast");
		addToSet("MissionCleanup", %obj);
		%padd = "0 0 3.5";
		%pos = Vector::add(GameBase::getPosition(%this), %padd);
		GameBase::setPosition(%obj, %pos);
	}
}

function Client::onKilled(%playerId, %killerId, %damageType, %vertPos, %quadrant)
{
	if ($DuelStatus[%playerId] == "InDuel" && $DuelStarted[%playerId]) %killerId = $DuelLineup[%playerId];
	%score = 0;
	%playerId.lascharge = "";
	%playerId.charging = "";
	%killerteam = Client::getTeam(%killerId);
	%killerName = Client::getName(%killerId);
	%playerteam = Client::getTeam(%playerId);
	%victimName = Client::getName(%playerId);

	if($teamplay && (%killerteam == %playerteam) && (%killerId != playerId))
		echo("\"T\"" @ %killerId @ "\"" @ %playerId @ "\"" @ %damageType @ "\"" @ "1" @ "\"");
	else
		echo("\"K\"" @ %killerId @ "\"" @ %playerId @ "\"" @ %damageType @ "\"" @ "1" @ "\"");

	echo ("*** Player " @ %playerId);
	echo ("*** Killer " @ %killerId);

	%killedflag = $killedflagcarry;
	%playerId.guiLock = true;
	if (%cl.scoreDeaths == 9) $DuelCanSpawn[%playerId] = false;
	Client::setGuiMode(%playerId, $GuiModePlay);

	if(!String::ICompare(Client::getGender(%playerId), "Male"))
	{
		%playerGender = "his";
	}
	else
	{
		%playerGender = "her";
	}

	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));

	if(!%killerId || %killerId == "-1") //=== No Killer Listed
	{
		messageAll(0, strcat(%victimName, " bites the dust."), $DeathMessageMask);
		echo ("ADMINMSG: " @ %victimName @ " bites the dust.");
		%playerId.scoreDeaths++;
		bottomprint(%playerId,"You have died " @ %playerId.scoreDeaths @ " time(s).",3);
		return;
	}
	else if(%killerId == %playerId) //=== Suicide Kill
	{
		%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
		messageAll(0, %oopsMsg, $DeathMessageMask);
		echo ("ADMINMSG: " @ %victimName @ " kills self.");
		%playerId.scoreDeaths++;

		if (%killedflag)
		{
			%playerId.score = (%playerId.score - $Score::FlagDef);
			bottomprint(%playerId,"You had the Flag. Your score reduced by " @ $Score::FlagDef @ " due to suicide.",3);
		}
		else
		{
			%playerId.score--;
			bottomprint(%playerId,"<jc>Your score reduced to " @ %playerId.score @ " due to suicide.",3);
		}

		Game::refreshClientScore(%playerId);
		return;
	}
	else
	{
		if(!String::ICompare(Client::getGender(%killerId), "Male"))
		{
			%killerGender = "his";
		}
		else
		{
			%killerGender = "her";
		}

		if($teamplay && %killerteam == %playerteam && $Game::missionType != "Duel")
		{
			if(%damageType != $MineDamageType)
			messageAll(0, strcat(%killerName, " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
			else
			messageAll(0, strcat(%killerName, " killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
			echo ("ADMINMSG: " @ %killerName @ " tk's " @ %victimName @ ".");
			%killerId.scoreDeaths++;
			%killerId.score--;

			Game::refreshClientScore(%killerId);
			Game::refreshClientScore(%playerId);

			if ($Wasteland::TeamKillOn == "True")
			{
				CheckTeamKiller(%killerId,%playerId,%damagetype, %vertPos, %quadrant);
			}
			if ($TDM)
			{
				$teamScore[%killerteam]--;
				$teamScore[%playerteam]--;
				TeamMessages(3, %killerTeam, "Team Score -2 = " @ $teamScore[%killerteam]);
				ObjectiveMission::refreshTeamScores();
			}
			return;

		}
		else
		{
			%obitMsg = sprintf($deathMsg[%damageType, %ridx], %killerName,%victimName, %killerGender, %playerGender);
			%score = (Scoring::killpoints(%playerId, %killerId, %damagetype, %vertPos, %quadrant));
			%killedpos = %playerId.lastkillpos;			//== Killed Pos
			%killerpos = GameBase::getPosition(%killerId);	//== Killers Pos
			%killdist = Vector::getDistance(%killedpos,%killerpos);

			if (%damagetype == $SniperDamageType || %damagetype == $LaserDamageType)
			{
				if (%vertPos == "head")
				{
					%msg = "HEAD SHOT <f2>("@floor(%killdist)@"m)";
					%obitMsg = sprintf($deathMsg[18, %ridx], %killerName,%victimName, %killerGender, %playerGender);
				}
				else %msg = " <f2>("@floor(%killdist)@"m)";
			}
			if ($Wasteland::JustSpawned[%playerId])
			{
				%score = floor (%score / 2);
			}
			if (%killerId.missilekill)
			{
				%score = floor(%score * 0.25);
			}
			if ($Game::missionType != "Duel")
			{
				messageAll(0, %obitMsg, $DeathMessageMask);
				echo ("ADMINMSG: " @ %obitMsg @ "");
			}
			%killerId.scoreKills++;  //=== Killer Number Of Kills
            	%playerId.scoreDeaths++;  //=== Killed Player Deaths
            	%killerId.score = (%killerId.score + %score);  //=== Killer Score

			if (%killedflag)
			{
				bottomprint(%killerId, "<jc>Flag Runner Killed! Score +" @ %score @ " = " @ %killerId.score @ " " @ %msg,3);
              		messageAll(0, %killerName @ " gets a bonus for killing the flag runner!");
			}
			else
			{
				bottomprint(%killerId, "<jc>Score +" @ %score @ " = " @ %killerId.score @ " " @ %msg,3);
   			}

   			//========== Refresh Scores

			Game::refreshClientScore(%killerId);
         		Game::refreshClientScore(%playerId);
			if ($TDM)
			{
				$teamScore[%killerteam]++;
				$teamScore[%playerteam]--;
				TeamMessages(3, %killerTeam, "Team Score +1 = " @ $teamScore[%killerteam]);
				TeamMessages(3, %playerTeam, "Team Score -1 = " @ $teamScore[%playerteam]);
				ObjectiveMission::refreshTeamScores();
			}
			if ($Game::missionType == "Duel")
			{
				%playerId.duelDeaths++;
  				%foeId = $DuelLineup[%playerId];
				if (%playerId.duelDeaths >= 10)
				{
					schedule("bottomprintall(\"                   <Bskull_big.bmp>\" @ Client::getName(" @ %playerId @ ") @ \" has died for the 10th time <Bskull_big.bmp>\");",1);
					messageall(1, Client::getName(%playerId) @ " has died 10 times.~wfemale5.wdeath.wav");
					if (%damageType == "") %damageType = -2;
					EndDuel(%playerId, %damageType);
				}
				else
				{
					systemMessage(%playerId, 3, %victimName @ " " @ %playerId.duelDeaths);
					systemMessage(%playerId, 1, Client::getName(%foeId) @ " " @ %foeId.duelDeaths);
					systemMessage(%foeId, 3, Client::getName(%foeId) @ " " @ %foeId.duelDeaths);
					systemMessage(%foeId, 1, %victimName @ " " @ %playerId.duelDeaths);
				}
			}
		}
	}
}

function CheckTeamKiller(%killerId,%playerId,%damagetype, %vertPos, %quadrant)
{
	if(%damagetype != $MineDamageType && %damagetype != $GravDamageType && %damagetype != $CloakDamageType)
	{
		%ppos = %playerid.TKDeathPos;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if($teamplay && (Client::getTeam(%killerId) != Client::getTeam(%cl)))
			{
				if(%cl != %playerId && %cl != %killerId)
				{
					%pppos = GameBase::getPosition(%cl);
					%dist = Vector::getDistance(%ppos,%pppos);
					if ($debug) echo("***" @ Client::getName(%cl) @ " was " @ %dist @ " from " @ Client::getName(%playerId) @ " Prox = " @ $SHAntiTeamKillProximity);

					if(%dist < $SHAntiTeamKillProximity)
					{
						Client::sendMessage(%killerId, 0, "You team killed...");
						return;
					}
				}
			}
		}

	        messageAll(0, "***" @ Client::getName(%killerId) @ " TeamKilled***");

  		$killedflagcarry = "False";		 //== Reset
		%playerId.lastkillpos = -1;		 //== Reset
		$killedarmor = -1;			 //== Reset

		%score = (Scoring::killpoints(%playerId, %killerId, %vertPos,%quadrant));

		if ($Wasteland::JustSpawned[%playerId] == "false")
		{
			%killerId.scoreDeaths++;
			%killerId.score = (%killerId.score - %score);
		}
		//====================================== Refresh Scores
		Game::refreshClientScore(%killerId);
		Game::refreshClientScore(%playerId);

		if (%killedflag)
		{
			centerprint(%killerId, "<jc>You Team Killed The Flag Runner! Score -" @ %score @ " = " @ %killerId.score ,3);
			messageAll(0, Client::getName(%killerId) @ " TEAM KILLED his own Flag Runner!!!");
		}
		else
		{
			bottomprint(%killerId, "<jc>You Team Killed! Score -" @ %score @ " = " @ %killerId.score ,3);
		}

		$Wasteland::LastTker = (Client::getName(%killerId));
		$Wasteland::LastTKed = (Client::getName(%playerId));
		$Wasteland::LastTKno = (%killerid.TKCount + 1);

		if(%killerid.TKCount == "")
		{
			%killerid.TKCount = 1;
		}
		else
		{
			%killerid.TKCount = %killerid.TKCount + 1;

			//=========== Server Terminates Team Killer

			if (%killerid.TKCount > $Wasteland::KillTerm)
			{
				if ($Wasteland::KillTerm > "1")
				{
					bottomprintall("***" @ Client::getName(%killerId) @ " was terminated for TKing more than " @ $Wasteland::KillTerm @ " times.",3);
					schedule ("Player::Kill(" @ %killerId @ ");", 2.0);
				}
				else
				{
					bottomprintall("***" @ Client::getName(%killerId) @ " Was terminated for TKing more than once.",3);
					schedule ("Player::Kill(" @ %killerId @ ");", 2.0);
				}
			}

			if(%killerid.TKCount > $SHAntiTeamKillMaxKills)
			{
				%clientId = %killerId;
				%addr = Client::getTransportAddress(%killerId);
				%name = Client::getName(%clientId);

				if ($Server::Admin["noban", %name] && %clientId.noban)
				{
					echo ("ADMINMSG **** " @ %name @ " hit TK limit but is NoBan");
					return;
				}
				else if (%clientId.noban)
				{
					echo ("ADMINMSG **** " @ %name @ " hit TK limit but is NoBan");
					return;
				}

				bottomprintall("***" @ Client::getName(%killerId) @ " Was kicked and banned For TKing",3);

				%ip = Client::getTransportAddress(%killerId);
				BanList::add(%ip, $SHAntiTeamKillBanTime);      //=== Add Player To BanList
				shban(%ip);
				%killer = Client::getOwnedObject(%killerId);
				messageAll(0, Client::getName(%killerId) @ " was kicked and banned for teamkilling");
				KickPlayer(%killerId,"***" @ $Wasteland::TeamKillMsg @ "***");
			}
			else
			{
				if(%killerid.TKCount > $SHAntiTeamKillWarnKills)
				{
					centerprint(%killerId, "You have killed " @ %killerId.TKCount @ " teammates. If you continue you will be kicked and banned.", 10);
				}
			}
		}
    	}
}


//============ Lava Script

function initLava()
{
	$Lava=1;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) LavaCheck(Client::getOwnedObject(%cl));
	messageall(1,"Lava(); //lava damage enabled");
}

function Lava()
{
	schedule("initLava();", 10);
}

function LavaCheck(%this)
{
    	if(getObjectType(%this) == "Player" && $Lava)
	{
		if (Player::isDead(%this)) return;
		%obj = newObject("","Mine",Pigment);
		%pos = GameBase::getPosition(%this);
		GameBase::setPosition(%obj,Vector::add(GameBase::getPosition(%this),"1 0 1"));
		addToSet("MissionCleanup", %obj);
		if (GameBase::getLOSInfo(%obj, 3, "-1.57 0 0"))
		{
			%target = $los::object;
			%type = getObjectType(%target);
			if (%type == "SimTerrain")
			{
				messageall(0,Client::getName(Player::getClient(%this)) @" burns in the lava.");
				Player::kill(%this);
				playSound(SoundLava,%pos);
			}
		}
		deleteObject(%obj);
		schedule("LavaCheck(" @ %this @ ");",1.0);
	}
}
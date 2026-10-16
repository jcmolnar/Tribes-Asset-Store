//==== TribeStat Scoring.cs

function TribeStat_GetTeams()
{
	echo("//TS");
	echo("\"2\"-1\"0\"Reset\"");
	for(%i = 0; %i < getNumTeams() ; %i++)
		echo("\"2\"" @ %i @ "\"" @ $teamScore[%i] @ "\"" @ getTeamName(%i) @ "\"");
}

function TribeStat_GetPlayers()
{
	echo("//TS");
	echo("\"1\"2048\"Reset\"IP: 000.000.000.000:0000\"0\"0\"None\"");
	for(%cl = Client::getFirst(); %cl != -1; %cl=Client::getNext(%cl))
	{
		if (Client::getName(%cl) == "")
			%ClientName = "Unnamed";
		else
			%ClientName = Client::getName(%cl);

		//echo("\"1\"" @ %cl @ "\"" @ escapeString(%ClientName) @ "\"" @ Client::getTransportAddress(%cl) @ "\"" @ Client::getTeam(%cl) @ "\"" @ %cl.score @ "\"" @ Client::getGender(%cl) @ "\"");
		echo("\"1\"" @ %cl @ "\"" @ escapeString(%ClientName) @ "\"" @ Client::getTeam(%cl) @ "\"" @ %cl.score @ "\"" @ Client::getGender(%cl) @ "\"");
	}
}

function TribeStat_GetPreferences()
{
	echo("//TS");
	echo("\"Q\"0\"" @
	$Server::HostName @ "\"" @
	$Server::MaxPlayers @ "\"" @
	$Server::TimeLimit @ "\"");
    echo("\"Q\"1\"" @ escapeString($Server::Info) @ "\"" @ escapeString($Server::JoinMOTD) @ "\"");
}

function TribeStat_GetStatus()
{
    echo("//TS");
    echo("\"Q\"3\"" @
         $missionName @ "\"" @
         ($Server::timeLimit * 60) + $missionStartTime - getSimTime() @ "\"");
}

function TribeStat_ShowScores()
{
    %TSteamScores = "";
    for(%i = 0; %i < getNumTeams() ; %i++)
       %TSteamScores = %TSteamScores @ "\"" @ $teamScore[%i];
    echo("//TS");
    echo("\"S" @ %TSTeamScores @ "\"");
}

function TribeStat_GetMissions()
{
         echo ("//TS");
         echo ("\"3\"Reset\"Reset\"");
         for (%i = 0; %i < $MLIST::Count; %i++)
         {
	         echo ("\"3\"" @ $MLIST::EName[%i] @ "\"" @ $MLIST::EType[%i] @
		 "\"" @ $MLIST::Enabled[$MLIST::EName[%i]] @ "\"");
         }
         echo ("\"3\"Done\"Done\"");
}

//======================= Normal Server.cs

function createTrainingServer()
{
   $SinglePlayer = true;
   createServer($pref::lastTrainingMission, false);
}

function remoteSetCLInfo(%clientId, %skin, %name, %email, %tribe, %url, %info, %autowp, %enterInv, %msgMask)
{
	$Client::info[%clientId, 0] = %skin;
	$Client::info[%clientId, 1] = %name;
	$Client::info[%clientId, 2] = %email;
	$Client::info[%clientId, 3] = %tribe;
	$Client::info[%clientId, 4] = %url;
	$Client::info[%clientId, 5] = %info;

	if(%autowp)
		%clientId.autoWaypoint = true;

	if(%enterInv)
		%clientId.noEnterInventory = true;

	if(%msgMask != "")
		%clientId.messageFilter = %msgMask;
}

function Server::storeData()
{
	$ServerDataFile = "serverTempData" @ $Server::Port @ ".cs";

	$Server::LastMissionNum = (floor($TotalMissions / (getrandom()*10)));
	export("Server::*", "temp\\" @ $ServerDataFile, False);
	export("$Wasteland::*", "temp\\" @ $ServerDataFile, true);
	export("pref::lastMission", "temp\\" @ $ServerDataFile, true);
	EvalSearchPath();
}

function Server::refreshData()
{
	exec($ServerDataFile);
	checkMasterTranslation();
	Server::loadMission($pref::lastMission, false);
}

function Server::onClientDisconnect(%clientId)
{
   	%player = Client::getOwnedObject(%clientId);
	%name = Client::getName(%clientId);

	%clientId.TotalKills = "";
	%clientId.TotalDeaths = "";
	%clientId.TotalScore = "";
	%clientId.TotalTKCount = "";
	%clientId.TotalFlags = "";
	%clientId.scoreKills = "";
	%clientId.scoreDeaths = "";
	%clientId.ratio = "";
	%clientId.score = "";
	%clientId.FlagCaps = "";
	%clientId.TKCount = "";

	%clientId.BadWordsSpoken = "";
	%clientId.lastBuyFavTime = "";
	%clientId.driver = "";
	%clientId.vehicle = "";
	%clientId.ismuted	= "";

	%clientId.fav0 = "";
	%clientId.fav1 = "";
	%clientId.fav2 = "";
	%clientId.fav3 = "";
	%clientId.fav4 = "";
	%clientId.fav5 = "";
	%clientId.fav6 = "";
	%clientId.fav7 = "";
	%clientId.fav8 = "";
	%clientId.fav9 = "";
	%clientId.fav10 = "";
	%clientId.fav11 = "";
	%clientId.fav12 = "";
	%clientId.fav13 = "";
	%clientId.fav14 = "";
	%clientId.fav15 = "";
	%clientId.fav16 = "";
	%clientId.fav17 = "";
	%clientId.fav18 = "";
	%clientId.fav19 =	"";
	%clientId.hacking = "";
	%clientId.module = "";
	%clientId.observerMode = "";

	%clientId.isadmin = "";
	%clientId.isSuperAdmin = "";
	%clientId.isGod = "";
	%clientId.isOld = "";
	%clientId.noban = "";
	%clientId.isWelcome = "";

	%clientId.heatlock = "";
	%clientId.plasmacharge = "";
	%clientId.charging = "";
	%clientId.lascharge = "";

	%clientId.spawntype = "";
	%clientId.EngMine = "";
	%clientId.Plastic = "";
	%clientId.Mortar = "";
	%clientId.Plasma = "";
	%clientId.gravbolt = "";
	%clientId.TotalKills = "";
	%clientId.TotalDeaths = "";
	%clientId.TotalScore = "";
	%playerId.TKCount = "";
	%clientId.TotalFlags = "";
	%clientId.MissionComplete = "";
	%clientId.EngBeacon = "";
	%clientId.rocket = "";
	%clientId.Laptop  = "";
	%clientId.obsmode  = "";
	%clientId.spymode  = "";
	%clientId.spawnnum = "";
	%clientId.hackattempt = "";
	%clientId.booster = "";
	%ClientId.boostercool = "";
	%clientId.vote = "";
	%clientId.oldpack = "";
	%clientId.BalloonPack = "";
	%clientId.grenl = "";
	%clientId.snipe = "";
	%clientId.elim = "";
	%clientId.target = "";
	%clientId.race = "";
	%clientId.laps = "";
	%clientId.leg = "";

	$funk::var["[\"" @ %name @ "\", 0, 1]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 2]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 3]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 4]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 5]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 6]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 7]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 8]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 9]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 10]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 11]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 12]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 13]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 14]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 15]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 16]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 17]"] = "";

	freeturrets(%clientId, GameBase::getTeam(%clientId));

	for(%i = 1; %i > 25; %i++)
	$funk::var["[\"" @ %name @ "\", 2, " @ %i @ "]"] = "";
	$funk::var["[\"" @ %name @ "\", 1, " @ %i @ "]"] = "";
	purgeresources();

	echo ("Finished Clearing " @ Client::getName(%clientId) @ "Cached Data.");

	if($Wasteland::LocalNetMask != "" && String::findSubStr(%clientId.addr,$Wasteland::LocalNetMask) == 0)
	{
		echo ("ADMINMSG: **** Local Player Disconnected - Decreasing Client Amount");
		$Server::MaxPlayers--;
	}

   	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   	{
			playNextAnim(%player);
		        Player::kill(%player);
   	}
	if ($Game::missionType == "Duel")
	{          
		if ($DuelStatus[%clientId] == "InDuel" || $DuelStatus[%clientId] == "InCountdown")
		{
			messageall(1,"" @ Client::GetName(%clientId) @ " has left the game.  Aborting Duel.");
			FinalizeDuel(%clientId, $DuelLineup[%clientId]);
		}                         
		DuelResetClient(%clientId); 
	}
	Client::setControlObject(%clientId, -1);
   	Client::leaveGame(%clientId);

   	echo("\"D\"" @ %clientId @ "\"");

   	Game::CheckTourneyMatchStart();

   	if ($Wasteland::Refresh != False)
   	{
   		if(getNumClients() == 1)
   			Server::refreshData();
   	}
}

function Welcome(%clientId,%addr,%password,%name)
{
	%clientId.isWelcome = true;
	schedule("Client::sendMessage(" @ %clientId @ ",0,\"~wwbiob.wav\");",30);
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>" @ %name @ ", Welcome to BioWasteland as a registered user!\", 10);", 27);
	echo("ADMINMSG: **** Welcomed : " @ %clientId @ " - " @ %name @ " - " @ %addr @ " - " @ %password);
	MessageAllExcept(%clientId, 1, %name@" is a registered player.~wwLready.wav");
	//if (String::getSubStr(%addr,3,3) == "24." && !clientId.isAdmin)
	//{
	//	echo("ADMINMSG: **** Potential Registered Hacker : " @ %clientId @ " - " @ %name @ " - " @ %addr @ " - " @ %password);
	//	messageAdmin(1, %name@" is a potential registered hacker.~wfemale5.wcolor6.wav");
	//	return;
	//}
}

function UnWelcome(%clientId,%addr,%password,%name)
{
	if(String::getSubStr(%addr,0,8) == "LOOPBACK")
	{
		echo ("ADMINMSG: **** LOOPBACK - Welcoming Host");
		Welcome(%clientId,%addr,%password,%name);
		return;
	}
	//if (String::getSubStr(%addr,3,3) == "24.")
	//{
	//	echo("ADMINMSG: **** Kicking Potential Hacker : " @ %clientId @ " - " @ %name @ " - " @ %addr @ " - " @ %password);
	//	BanList::add(%addr, 9999999);
	//	MessageAllExcept(%clientId, 1, %name@" is not registered, and is being dropped.~wfemale5.wcolor6.wav");
   	//	KickPlayer(%clientId, "Sorry, you are not a registered player.");
	//	messageAdmin(1, %name@" is a potential hacker and is being banned.~wfemale5.wcolor6.wav");
	//	return;
	//}
   	if ($BioPrivate == "2")
	{
		BanList::add(Client::getTransportAddress(%clientId), 9999);
		KickPlayer(%clientId, "Sorry, you are not a registered player.");
		MessageAllExcept(%clientId, 1, %name@" is not registered, and is being dropped.~wfemale5.wcolor6.wav");
	}
	schedule("Client::sendMessage(" @ %clientId @ ",0,\"~waccess_denied.wav\");",30);
	if ($BioPrivate == "1")
	{
		schedule("centerprint(" @ %clientId @ ", \"<jc><f2>UNREGISTERED: You may play while there is space for guests.\", 10);", 30);
	}
}
function Poser(%clientId,%addr,%password,%name)
{
	if(String::getSubStr(%addr,0,8) == "LOOPBACK")
	{
		echo ("ADMINMSG: **** LOOPBACK - Welcoming Host");
		Welcome(%clientId,%addr,%password,%name);
		return;
	}
	echo("ADMINMSG: **** Poser : " @ %clientId @ " - " @ %name @ " - " @ %addr @ " - " @ %password);
	BanList::add(Client::getTransportAddress(%clientId), 3600);
   	KickPlayer(%clientId, "Sorry, your player's name is already registered to someone else.");
	MessageAllExcept(%clientId, 1, %name@" is a poser, and is being kicked.~wfemale5.wcolor6.wav");
}

function Server::onClientConnect(%clientId)								
{
	if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
	{
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
		%clientId.isGod = true;
		%clientId.isOld = true;
	}
	DuelResetClient(%clientId);
	echo("\"C\"" @ %clientId @ "\"" @ escapeString(Client::getName(%clientId)) @ "\"" @ Client::getTransportAddress(%clientId) @ "\"" @ Client::getGender(%clientId) @ "\"");
	SHCheckTransportAddress(%clientid);
	//clonecheck(%clientID);

	%addr = Client::getTransportAddress(%clientId);

	if($Wasteland::LocalNetMask != "" && String::findSubStr(%addr,$Wasteland::LocalNetMask) == 0)
	{
		echo ("ADMINMSG: **** Local Player Connected - Increasing Client Ammount");
		%clientId.addr = %addr;
		$Server::MaxPlayers++;
	}

	%clientId.noghost = true;
	%clientId.messageFilter = -1;

	remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
	remoteEval(%clientId, MODInfo, $MODInfo);
	remoteEval(%clientId, FileURL, $Server::FileURL);

	for(%i = 0; %i < 10; %i++)
		$Client::info[%clientId, %i] = "";

	Game::onPlayerConnected(%clientId);
}

function createServer(%mission, %dedicated)
{
	%mission = (Server::NewMission(%mission, %dedicated));

	cursorOn(MainWindow);
	GuiLoadContentCtrl(MainWindow, "gui\\Loading.gui");
	renderCanvas(MainWindow);

	if(!%dedicated)
	{
		deleteServer();
		purgeResources();
		newServer();
		focusServer();
	}

	if($SinglePlayer)
		newObject(serverDelegate, FearCSDelegate, true, "LOOPBACK", $Server::Port);
	else
		newObject(serverDelegate, FearCSDelegate, true, "IP", $Server::Port, "IPX", $Server::Port, "LOOPBACK", $Server::Port);

	exec(admin);
	exec(Marker);
	exec(Trigger);
	exec(NSound);
	exec(BaseExpData);
	exec(BaseDebrisData);
	exec(BaseProjData);
	exec(Mine);
	exec(Grenade);
	exec(Bombs);
	exec(Blasts);
	exec(ArmorData);
	exec(Mission);
	exec(Item);

	BuildItemList(); //=== Build Items List From ArmorData.cs

	exec(coolturret);
	exec(ItemFuncs);
	exec(ItemMsgs);
	exec(Player);
	exec(Scoring);
	exec(Vehicle);
	exec(Turret);
	exec(Beacon);
	exec(StaticShape);
	exec(Station);
	exec(Moveable);
	exec(Sensor);
	exec(AI);
	exec(InteriorLight);
	exec(Saveinfo);
	exec(bindings);
	exec(objTree);

	preloadServerDataBlocks();

	Server::loadMission(($missionName = %mission), true );

	if(!%dedicated)
	{
		focusClient();
		if ($IRC::DisconnectInSim == "")
		{
			$IRC::DisconnectInSim = true;
		}
		if ($IRC::DisconnectInSim == true)
		{
			ircDisconnect();
			$IRCConnected = FALSE;
			$IRCJoinedRoom = FALSE;
		}

		$Server::Address = "LOOPBACK:" @ $Server::Port;
		$Server::JoinPassword = $Server::Password;
		connect($Server::Address);
	}
	return "True";
}


function Server::newMission(%mission, %dedicated)
{
	//===================================== Mission Load

   	$loadingMission = false;
   	$ME::Loaded = false;

	if ($Wasteland::RandomStart)
	{
		if ($Server::LastMissionNum == "" || !$Server::LastMissionNum)
		{
			$Server::LastMissionNum = (floor($TotalMissions * getrandom() ));
		}
		else
		{
			$Server::LastMissionNum = (floor($Server::LastMissionNum * getrandom() ));
		}

		%rnd = $Server::LastMissionNum;

		for (%i = 0; %i < %rnd;%i++)
		{
			%j = (floor($TotalMissions *getrandom() ));
		}

		%mission = $TotalMissionList[%j];

		if(%mission == "")
		{
			%mission = $pref::lastMission;
			$Server::LastMissionNum = (floor($TotalMissions *getrandom() ));
		}
	}
	else
	{
		if(%mission == "")
			%mission = $pref::lastMission;
	}

	if(%mission == "")
	{
		if ($debug) echo("Error: no mission provided.");
		return "False";
	}

	$pref::lastMission = %mission;

	$Server::LastMissionNum = (%j);

	export("pref::*", "config\\ClientPrefs.cs", False);
	//export("Server::*", "config\\ServerPrefs.cs", False);
	//export("$Wasteland::*", "config\\ServerPrefs.cs", true);
	//export("pref::lastMission", "config\\ServerPrefs.cs", True);

	return %mission;
	//===================================== End Start Mission
}

function Server::nextMission(%replay)
{
	if ($Wasteland::RandomMissions)
	{
		%rnd = floor(getRandom() * ($TotalMissions));

		if ($MissionName == $TotalMissionList[%rnd])
		{
			%nextMission = $TotalMissionList[1];
			$pref::LastMission = $TotalMissionList[1];
		}
		else
		{
			%nextMission = $TotalMissionList[%rnd];
			$pref::LastMission = $TotalMissionList[%rnd];
		}

		$Server::LastMissionNum = (floor($TotalMissions *getrandom() ));

		for (%i=0; %i < 10; %i++)
		{
			if (%nextmission == $pastmission[%i] && $TotalMissions > 10)
			{
				Server::nextMission();
				return;
			}
		}
		if ($TotalMissions > 10)
		{
			for (%i=10; %i >= 0; %i--)
			{
				if (%i == 0)
				{
					$pastmission[0] = %nextmission;
				}
				else
				{
					$pastmission[%i] = $pastmission[%i - 1];
				}
			}
		}

		if ($debug) echo ("*** Past Missions");
		if ($debug) echo (" 0 " @ $pastmission[0]);
		if ($debug) echo (" 1 " @ $pastmission[1]);
		if ($debug) echo (" 2 " @ $pastmission[2]);
		if ($debug) echo (" 3 " @ $pastmission[3]);
		if ($debug) echo (" 4 " @ $pastmission[4]);
		if ($debug) echo (" 5 " @ $pastmission[5]);
		if ($debug) echo (" 6 " @ $pastmission[6]);
		if ($debug) echo (" 7 " @ $pastmission[7]);
		if ($debug) echo (" 8 " @ $pastmission[8]);
		if ($debug) echo (" 9 " @ $pastmission[9]);
		if ($debug) echo ("10 " @ $pastmission[10]);
		if ($debug) echo ("*** Past Missions");
	}
	else
	{
		%nextMission = $nextMission[$missionName];
	}



	if(%nextMission == "")
	{
		%mission = $pref::lastMission;
		$Server::LastMissionNum = (floor($TotalMissions *getrandom() ));
	}

	export("pref::*", "config\\ClientPrefs.cs", False);
	//export("Server::*", "config\\ServerPrefs.cs", False);
	//export("$Wasteland::*", "config\\ServerPrefs.cs", true);	//Wasteland

	echo("ADMINMSG: **** Changing to mission ", %nextMission, ".");


	Server::loadMission(%nextMission);
}

function remoteCycleMission(%clientId)
{
	if(%clientId.isAdmin || !%clientId)
	{
		messageAll(0, Client::getName(%clientId) @ " cycled the mission.");
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ "Force Cycled TO Next Mission.");
		Server::nextMission();
	}
}

function remoteListMissions()
{
	for (%i=0;$TotalMissionList[%i] != ""; %i++)
	{
		echo ("Missions = " @ $TotalMissionList[%i]);
	}
}

function remoteDataFinished(%clientId)
{
	if(%clientId.dataFinished)
		return;
	%clientId.dataFinished = true;
	Client::setDataFinished(%clientId);
	%clientId.svNoGhost = ""; // clear the data flag
	if($ghosting)
	{
		%clientId.ghostDoneFlag = true; // allow a CGA done from this dude
		startGhosting(%clientId);  // let the ghosting begin!
	}
}

function remoteCGADone(%playerId)
{
	if(!%playerId.ghostDoneFlag || !$ghosting)
		return;

	%playerId.ghostDoneFlag = "";

	Game::initialMissionDrop(%playerid);

	if ($cdTrack != "")
		remoteEval (%playerId, setMusic, $cdTrack, $cdPlayMode);

	remoteEval(%playerId, MInfo, $missionName);
}

function Server::loadMission(%missionName, %immed)
{
	if ($Game::missionType == "Duel")      
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if (Client::GetOwnedObject(%cl) != -1) Player::BlowUp(Client::GetOwnedObject(%cl));
			GameBase::SetTeam(%cl, -1);
			%cl.observerMode = "justJoined";
		}
	}
   	if($loadingMission)
   		return;

	%missionFile = "missions\\" $+ %missionName $+ ".mis";
	if(File::FindFirst(%missionFile) == "")
	{
		%missionName = $firstMission;
		%missionFile = "missions\\" $+ %missionName $+ ".mis";
		if(File::FindFirst(%missionFile) == "")
		{

			return;
		}
	}
	$DuelsStarted = "";
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		Client::setGuiMode(%cl, $GuiModeVictory);
		%cl.guiLock = true;
		%cl.nospawn = true;
		$DuelCanSpawn[%cl] = false;
		remoteEval(%cl, missionChangeNotify, %missionName);
	}

	$loadingMission = true;
	$missionName = %missionName;
	$missionFile = %missionFile;
	$prevNumTeams = getNumTeams();

	deleteObject("MissionGroup");
	deleteObject("MissionCleanup");
	deleteObject("ConsoleScheduler");

	resetPlayerManager();
	resetGhostManagers();
	$matchStarted = false;
	$countdownStarted = false;
	$ghosting = false;

	resetSimTime(); // deal with time imprecision

	newObject(ConsoleScheduler, SimConsoleScheduler);

	if(!%immed)
		schedule("Server::finishMissionLoad();", 18);
	else
		Server::finishMissionLoad();

	$Wasteland::MissionCycle = $Wasteland::MissionCycle + 1;
}

function Server::finishMissionLoad()
{
   	$loadingMission = false;
	$TestMissionType = "";
   	// instant off of the manager
   	setInstantGroup(0);
   	newObject(MissionCleanup, SimGroup);

   	exec($missionFile);

	Mission::init(); 		//-- Init for next mission
	Mission::reinitData();		//-- Init Items

   	if($prevNumTeams != getNumTeams())
  	{
  	    	// loop thru clients and setTeam to -1;
  	    	messageAll(0, "New teamcount - resetting teams.");
  	    	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		GameBase::setTeam(%cl, -1);
  	}

	$ghosting = true;

	echo ("Ghosting Fin Missions Load");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(!%cl.svNoGhost)
		{
			%cl.ghostDoneFlag = true;
			startGhosting(%cl);
		}
	}

	if($SinglePlayer)
		Game::startMatch();
	else if($Server::warmupTime && !$Server::TourneyMode)
		Server::Countdown($Server::warmupTime);
	else if(!$Server::TourneyMode)
		Game::startMatch();

//=== duel mode needs everyone in obs
	if ($Game::missionType == "Duel")
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		GameBase::setTeam(%cl, -1);
		messageall("Duel Map: Everyone starts in observer.");
	}
	else
	{
		//============================= Cycle Player Teams
		if ($Wasteland::TeamJuggle > 0)
		{
			echo ("ADMINMSG **** Teams Assigned Every " @ $Wasteland::TeamJuggle @ " Mission(s).");
			echo ("ADMINMSG **** Mission Cycle On Mission Number " @ $Wasteland::MissionCycle @ ".");
		}

		if ($Wasteland::TeamJuggle > 0 && $Wasteland::TeamJuggle < $Wasteland::MissionCycle)
		{
			$Wasteland::MissionCycle = 0;
			echo ("ADMINMSG **** Resetting Players Teams - Mission Reset Every " @ $Wasteland::TeamJuggle @ " Mission.");
      		Game::setRandomTeam();
		}
	}

	$teamplay = (getNumTeams() != 1);
	purgeResources(true);

	schedule("Server::CheckMatchStarted();", 3600);
	schedule("Server::nextMission();", 18000);

	return "True";
}

function Server::CheckMatchStarted()
{
   // if the match hasn't started yet, just reset the map
   // timing issue.
   if(!$matchStarted)
      Server::nextMission(true);
}

function Server::Countdown(%time)
{
   $countdownStarted = true;
   schedule("Game::startMatch();", %time);

   Game::notifyMatchStart(%time);
   if(%time > 30)
      schedule("Game::notifyMatchStart(30);", %time - 30);
   if(%time > 15)
      schedule("Game::notifyMatchStart(15);", %time - 15);
   if(%time > 10)
      schedule("Game::notifyMatchStart(10);", %time - 10);
   if(%time > 5)
      schedule("Game::notifyMatchStart(5);", %time - 5);
}

function Client::setInventoryText(%clientId, %txt)
{
   remoteEval(%clientId, "ITXT", %txt);
}

function centerprint(%clientId, %msg, %timeout)
{
   if(%timeout == "")
      %timeout = 5;
   remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprint(%clientId, %msg, %timeout)
{
   if(%timeout == "")
      %timeout = 5;
   remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprint(%clientId, %msg, %timeout)
{
   if(%timeout == "")
      %timeout = 5;
   remoteEval(%clientId, "TP", %msg, %timeout);
}

function centerprintall(%msg, %timeout)
{
	if ($debug) echo ("CenterPrint");
	if(%timeout == "")
	%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprintall(%msg, %timeout)
{
	if ($debug) echo ("BottomPrint");
	if(%timeout == "")
	%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprintall(%msg, %timeout)
{
	if ($debug) echo ("TopPrint");
	if(%timeout == "")
	%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	remoteEval(%clientId, "TP", %msg, %timeout);
}

function teamcenterprint(%msg, %time, %tn)
{
   if(%time == "")
      %time = 5;
   for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	if (GameBase::getTeam(%clientId) == %tn)
      	remoteEval(%clientId, "CP", %msg, %time);
}

function teambottomprint(%msg, %time, %tn)
{
   if(%time == "")
      %time = 5;
   for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	if (GameBase::getTeam(%clientId) == %tn)
	      remoteEval(%clientId, "BP", %msg, %time);
}

function teamtopprint(%msg, %time, %tn)
{
   if(%time == "")
      %time = 5;
   for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	if (GameBase::getTeam(%clientId) == %tn)
	      remoteEval(%clientId, "TP", %msg, %time);
}

//===================== AutoAdmin Checking
function SHCheckTransportAddress(%clientid)
{
	%addr = Client::getTransportAddress(%clientId);
	if ($debug) echo(%clientid @ " <- " @ %addr);

	if(String::getSubStr(%addr,0,8) == "LOOPBACK")
		return;

	if(String::getSubStr(%addr,0,3) != "IP:" && String::getSubStr(%addr,0,4) != "IPX:" )
	{
		if ($debug) echo(%clientid @ " is not correct address form, kicking");
		schedule("SHKickClient(" @ %clientid @ ");",20,%clientid);
		return ;
	}

	for(%i=0;$SHBanList[%i] != "";%i++)
	{
		if(String::findSubStr(%addr,$SHBanList[%i]) == 0)
		{
			if ($debug) echo(%clientid @ " is banned");
			schedule("SHKickClient(" @ %clientid @ ");",20,%clientid);
			return;
		}
	}
}

function Wasteland::Autoadmin(%clientId)
{
	%addr = Client::getTransportAddress(%clientId);
	%name = Client::getName(%clientId);
//=====================Welcome Script
	%password = $Client::info[%clientId, 5];
	if(%password == "")
	{
		if ($Server::Admin["sadpw", %name] == "")
		{
			UnWelcome(%clientId,%addr,%password,%name);
			return;
		}
		else
		{
			Poser(%clientId,%addr,%password,%name);
			return;
		}
	}
	else if(%password == $Server::Admin["sadpw", %name])
	{
		Welcome(%clientId,%addr,%password,%name);
	}
	else if ($Server::Admin["sadpw", %name] == "")
	{
		UnWelcome(%clientId,%addr,%password,%name);
		return;
	}
	else
	{
		Poser(%clientId,%addr,%password,%name);
		return;
	}
//=================end welcome script
	if ($Server::Admin["autoa", %name])
	{
		echo ("ADMINMSG **** Checking AutoAdmin for " @ %name);
	}
	else
	{
		return;
	}
	if ($Server::Admin["ipadr", %name] == "")
	{
		echo ("ADMINMSG **** No IP Listed.");
		return;
	}
	if(String::findSubStr(%addr,$Server::Admin["ipadr", %name]) == 0)
	{
		echo("ADMINMSG: **** Auto - Admining: " @ %clientId @ " - " @ %name @ " - " @ %addr @ " Checking IP Address");
		if ($Server::Admin["God", %name])
		{
			echo("ADMINMSG: **** Auto - GodMode: " @ %clientId @ " - " @ %name @ " - " @ %addr);
			schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You have been Auto-God-Moded\",5);",30);
			%clientId.noban = 1;
			%clientId.isAdmin = true;
			%clientId.isSuperAdmin = true;
			%clientId.isGod = true;
			%clientId.isOld = 1;
		}
		else if ($Server::Admin["super", %name])
		{
			echo("ADMINMSG: **** Auto - Super: " @ %clientId @ " - " @ %name @ " - " @ %addr @ " Super-Admin");
			schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You have been Auto-SuperAdmined\",5);",30);
			%clientId.noban = 1;
			%clientId.isAdmin = true;
			%clientId.isSuperAdmin = true;
		}
		else if ($Server::Admin["admin", %name])
		{
			echo("ADMINMSG: **** Auto - Admin: " @ %clientId @ " - " @ %name @ " - " @ %addr @ " Normal-Admin");
			schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You have been Auto-Admined\",5);",30);
			%clientId.isAdmin = true;
		}
		else if ($Server::Admin["noban", %name])
		{
			echo("ADMINMSG: **** No Ban: " @ %clientId @ " - " @ %name @ " - " @ %addr @ ".");
			schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You have been added to the NoBan List.\",5);",30);
			%clientId.noban = 1;
		}
		if ($Server::Admin["old", %name])
		{
			%clientId.isOld = 1;
		}
	}
	else
	{
		echo("ADMINMSG: **** Failed: " @ %clientId @ " - " @ %name @ " - " @ %addr @ " IP Does Not Match");
		schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You have not been admined, IP does not match.\",5);",30);
		%clientId.isAdmin = false;
		%clientId.isSuperAdmin = false;
		%clientId.isGod = false;
		%clientId.noban = false;
	}
}

function KickPlayer(%clientId,%msg)
{
	%name = Client::GetName(%clientId);
	echo("ADMINMSG: **** Player " @ %name @ " is kicked: "@ %msg);
	schedule ("Net::Kick(" @ %clientId @ ", \"" @ %msg @ "\");",1);
}

function clonecheck(%clientID)
{
	clonetranspcheck(%clientID);
	clonenamecheck(%clientID);
}

function clonetranspcheck(%clientID)
{
	%transp = Client::getTransportAddress(%clientId);
	%z = getWord($connect[%transp],0);
	for(%x=1;%x <= %z; %x=%x+1)
	{
		%connect[%x] = getWord($connect[%transp],%x);
		if ((getsimtime() - %connect[%x]) <= 120)
		{
		%string = %string @ " " @ %connect[%x];
		}
	}
	%connect[%z+1] = getsimtime();
	$connect[%transp] = %z+1 @ " " @ %string @ " " @ %connect[%z+1];
//	echo($connect[%transp]);
	if((%z >= 4) && ((%connect[%z] - %connect[1]) <= 120))
	{
		BanList::add(Client::getTransportAddress(%clientId), 1800);
		KickPlayer(%clientId, "Clone attacks will not be tolerated.");
	}
}

function clonenamecheck(%clientID)
{
	%name = Client::getName(%clientId);
	%strIndex = String::findSubStr(%name, ".1");
	%name2 = String::getSubStr(%name, 0, %strIndex);
	%z = getWord($connect[%name],0);
	for(%x=1;%x <= %z; %x=%x+1)
	{
		%connect[%x] = getWord($connect[%name],%x);
		if ((getsimtime() - %connect[%x]) <= 120)
		{
		%string = %string @ " " @ %connect[%x];
		}
	}
	%connect[%z+1] = getsimtime();
	$connect[%name] = %z+1 @ " " @ %string @ " " @ %connect[%z+1];
//	echo($connect[%name]);
	if((%z > 4) && ((%connect[%z] - %connect[1]) <= 120))
	{
		BanList::add(Client::getTransportAddress(%clientId), 1800);
		KickPlayer(%clientId, "Clone attacks will not be tolerated.");
	}
}

echo("BioWasteland's Welcome-Check Activated");
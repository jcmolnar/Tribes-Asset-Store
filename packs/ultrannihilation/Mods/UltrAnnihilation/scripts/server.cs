// putting a global variable in the argument list means:
// if an argument is passed for that parameter it gets
// assigned to the global scope, not the scope of the function

function createTrainingServer()
{
	$SinglePlayer = true;
	createServer($pref::lastTrainingMission, false);
}

function remoteSetCLInfo(%clientId, %skin, %name, %email, %tribe, %url, %info, %autowp, %enterInv, %msgMask, %pskin)
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
	if(%pskin)
		%clientId.personalskin = true;
}

function Server::storeData()
{
	$ServerDataFile = "serverTempData" @ $Server::Port @ ".cs";

	export("Server::*", "temp\\" @ $ServerDataFile, False);
	export("pref::lastMission", "temp\\" @ $ServerDataFile, true);
	EvalSearchPath();
}

function Server::refreshData()
{
	exec($ServerDataFile);  // reload prefs.
	checkMasterTranslation();
	//Server::nextMission(false);
	Server::loadMission($pref::lastMission, false);
}

function Server::onClientDisconnect(%clientId)
{
	// Need to kill the player off here to make everything
	// is cleaned up properly.
	%player = Client::getOwnedObject(%clientId);

	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
	{
		playNextAnim(%player);
		Player::kill(%player);
	}

	Client::setControlObject(%clientId, -1);
	Client::leaveGame(%clientId);

	if($Annihilation::NetMask != "" && (String::findSubStr(%clientId.address,$Annihilation::NetMask) == 0 || String::findSubStr(%clientId.address,"IP:127.0.0") == 0))
	{
		echo ("ADMINMSG: *** Local Client Disconnected - Decreasing Max Player Limit");
		$Server::MaxPlayers--; 
	}

	Game::CheckTourneyMatchStart();

	if($Annihilation::ResetServer != false)
		if(getNumClients() == 1) // this is the last client.
			Server::refreshData();
}

function KickDaJackal(%clientId)
{
	Net::kick(%clientId, "The FBI has been notified.  You better buy a legit copy before they get to your house.");
}

function Server::onClientConnect(%clientId)
{
	%address = Client::getTransportAddress(%clientId);
	
	echo("CONNECT: " @ %clientId @ " \"" @ escapeString(Client::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));

		if((!String::NCompare(%address, "IP:127.0.0.1", 12) || !String::NCompare(%address, "LOOPBACK", 8)) && $Annihilation::GiveLocalAdmin)	// PORT: the "IP:209.19.77" clause is removed
	{
		// force admin the loopback dude
		echo ("ADMINMSG: *** Local Client Given SuperAdmin Control");
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
	}
	
		if(0)	// PORT: was a kick of any player named "DaJackal" 20 s after joining
		schedule("KickDaJackal(" @ %clientId @ ");", 20, %clientId);

	if(($Annihilation::NetMask != "" && (String::findSubStr(%address,$Annihilation::NetMask) == 0 || String::findSubStr(%address,"IP:127.0.0") == 0)) && $Annihilation::IncreaseMax)
	{
		echo ("ADMINMSG: *** Local Client Connected - Increasing Max Player Limit");
		%clientId.address = %address;
		$Server::MaxPlayers++;
	}

	%clientId.noghost = true;
	%clientId.messageFilter = -1; // all messages
	
	remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
	remoteEval(%clientId, MODInfo, "MODS: UltrAnnihilation v" @ $ModVersion @ "\n" @ $MODInfo);
	remoteEval(%clientId, FileURL, $Server::FileURL);

	// clear out any client info:
	for(%i = 0; %i < 10; %i++)
		$Client::info[%clientId, %i] = "";

	Game::onPlayerConnected(%clientId);
}

function createServer(%mission, %dedicated)
{
	$loadingMission = false;
	$ME::Loaded = false;
	
	if(%mission == "")
		%mission = $pref::lastMission;

	if(%mission == "")
	{
		echo("Error: no mission provided.");
		return "False";
	}

	if(!$SinglePlayer)
		$pref::lastMission = %mission;

	//display the "loading" screen
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
	
	exec(serverAnnihilation);
	exec(InventoryHeaders);
	
	exec(admin);
	exec(Marker);
	exec(Trigger);
	exec(NSound);
	exec(BaseExpData);
	exec(BaseDebrisData);
	exec(BaseProjData);
	exec(ArmorData);
	serverAnnihilation::Armors();
	
	exec(Mission);
	exec(Item);
	serverAnnihilation::Items();
	
	exec(Player);
	exec(Vehicle);
	serverAnnihilation::Vehicles();
	
	exec(Turret);
	serverAnnihilation::Turrets();

	//exec(Beacon);
	exec(StaticShape);
	exec(Station);
	exec(Moveable);
	exec(Sensor);
	//exec(Mine);
	exec(AI);
	exec(InteriorLight);

	serverAnnihilation::Others();
	
	exec(serverItemUsage);
	
	Server::storeData();

	// NOTE!! You must have declared all data blocks BEFORE you call
	// preloadServerDataBlocks.

	preloadServerDataBlocks();

	Server::loadMission( ($missionName = %mission), true );

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
		// join up to the server
		$Server::Address = "LOOPBACK:" @ $Server::Port;
		$Server::JoinPassword = $Server::Password;
		connect($Server::Address);
	}
	return "True";
}

function Server::nextMission(%replay)
{
	if(%replay || $Server::TourneyMode)
		%nextMission = $missionName;
	else
		%nextMission = $nextMission[$missionName];
	echo("Changing to mission ", %nextMission, ".");
	// give the clients enough time to load up the victory screen
	Server::loadMission(%nextMission);
}

function remoteCycleMission(%clientId) //!!!
{
	if(%clientId.isAdmin)
	{
		messageAll(0, Client::getName(%playerId) @ " cycled the mission.");
		echo("ADMINMSG: *** " @ Client::getName(%clientId) @ "force mission cycle.");
		Server::nextMission();
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
	if($loadingMission)
		return;

	%missionFile = "missions\\" $+ %missionName $+ ".mis";
	if(File::FindFirst(%missionFile) == "")
	{
		%missionName = $firstMission;
		%missionFile = "missions\\" $+ %missionName $+ ".mis";
		if(File::FindFirst(%missionFile) == "")
		{
			echo("invalid nextMission and firstMission...");
			echo("aborting mission load.");
			return;
		}
	}
	echo("Notfifying players of mission change: ", getNumClients(), " in game");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		Client::setGuiMode(%cl, $GuiModeVictory);
		%cl.guiLock = true;
		%cl.nospawn = true;
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
}

function Server::finishMissionLoad()
{
	$loadingMission = false;
	$TestMissionType = "";
	// instant off of the manager
	setInstantGroup(0);
	newObject(MissionCleanup, SimGroup);

	exec($missionFile);
	Mission::init();
	Mission::reinitData();
	
	serverAnnihilation::InitializeMission();
	
	if($prevNumTeams != getNumTeams())
	{
		// loop thru clients and setTeam to -1;
		messageAll(0, "New teamcount - resetting teams.");
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			GameBase::setTeam(%cl, -1);
	}

	$ghosting = true;
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

	$teamplay = (getNumTeams() != 1);
	purgeResources(true);

	// make sure the match happens within 5-10 hours.
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
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprintall(%msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprintall(%msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId, "TP", %msg, %timeout);
}

function adminMsg(%msg)
{
	echo("SERVER: " @ %msg);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		if(%pl.isAdmin)
		{
			Client::sendMessage(%pl, 0, %msg);
		}
	}
}

function superAdminMsg(%msg)
{
	echo("SERVER: " @ %msg);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		if(%pl.isSuperAdmin)
		{
			Client::sendMessage(%pl, 0, %msg);
		}
	}
}
// putting a global variable in the argument list means:
// if an argument is passed for that parameter it gets
// assigned to the global scope, not the scope of the function

function createTrainingServer()
{
   $SinglePlayer = true;
   createServer($pref::lastTrainingMission, false);
}

function remoteSetCLInfo(%clientId, %skin, %name, %email, %tribe, %url, %info, %autowp)
{
   $Client::info[%clientId, 0] = %skin;
   $Client::info[%clientId, 1] = %name;
   $Client::info[%clientId, 2] = %email;
   $Client::info[%clientId, 3] = %tribe;
   $Client::info[%clientId, 4] = %url;
   $Client::info[%clientId, 5] = %info;
   if(%autowp)
      %clientId.autoWaypoint = true;
}

function Server::onClientConnect(%clientId)
{
   if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
   {
      // force admin the loopback dude
      %clientId.isAdmin = true;
      %clientId.isSuperAdmin = true;
   }
   echo("CONNECT: " @ %clientId @ " \"" @ 
      escapeString(Client::getName(%clientId)) @ 
      "\" " @ Client::getTransportAddress(%clientId));
   %clientId.noghost = true;
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info);

   // clear out any client info:
   for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";
   Game::onPlayerConnected(%clientId);
}

function Server::onClientDisConnect(%clientId)
{
   // PORT: stock body restored. The release leaves this function empty, so the mod's own
   // Client::leaveGame (objectives.cs: returns a dropped player's flag) never ran.
   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   {
      playNextAnim(%player);
      Player::kill(%player);
   }
   Client::setControlObject(%clientId, -1);
   Client::leaveGame(%clientId);
   Game::CheckTourneyMatchStart();
   	
}



// PORT: the three functions below are the stock ones. The release's server.cs is an older stock
// copy without them, but its modmgt.cs (:114, :176) and admin.cs (:755) call them.
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
   Server::nextMission(false);
}

function Server::CheckMatchStarted()
{
   // if the match hasn't started yet, just reset the map
   // timing issue.
   if(!$matchStarted)
      Server::nextMission(true);
}

function createServer(%mission, %dedicated)
{
   $loadingMission = false;
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
   
	exec(modmgt);
	//exec(motd);

   exec(admin);
   exec(Marker);
   exec(Trigger);
   exec(NSound);
   exec(BaseExpData);
   exec(BaseDebrisData);
	exec(BaseProjData);
   exec(ArmorData);
   exec(Mission);
	exec(Item);
	exec(Player);
	exec(Vehicle);
	exec(Turret);
	exec(Beacon);
	exec(StaticShape);
	exec(Station);
	exec(Moveable);
	exec(Sensor);
	exec(Mine);
	exec(AI);
	exec(InteriorLight);

	modmgtServerMods();
		Server::storeData();	// PORT: as modmgt.cs's own createServer does, so the admin menu's "reset server" has a file to reload

   // NOTE!! You must have declared all data blocks BEFORE you call
   // preloadServerDataBlocks.
   ReadRandom();
   preloadServerDataBlocks();

   //Server::loadMission( ($missionName = %mission), true );
   %replay = false;
   Server::nextMission(%replay);
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
	echo("Replay: " @ %replay);
	echo("RandomMissions: " @ $HaVoC::RandomMissions);
	echo("MissionName: " @ $missionName);
	if(%replay || $Server::TourneyMode)
	{
		%nextMission = $missionName;
	}
	else 
	{
		if ($HaVoC::RandomMissions) 
		{
			echo("Selecting a mission...");
			%l = 0; %goodmtype = 0;
			//echo("$MissionName: " @ $MissionName);
			while(!$HaVoC::RandomMissionTypes[%goodmtype] && %l < 5000) 
			{
				%rnd = floor(getRandom() * $TotalMissions);
				//echo("firsttime = " @ $firstTime @ "RandumNum:;Exixts = " @ $RandomNum::Exists);
				if($RandomNum::Exists == "1" && !$FirstTime) %rnd = floor($RandomNum::Number[%l] * $TotalMissions);
				//echo("MissionNumber is " @ %rnd);
				//echo("firsttime = " @ $firstTime);
				%TestMission = $TotalMissionList[%rnd];
				if ($RestrictedMissions == "True" && !$AllowedMission[%TestMission])
				{
				}
				else
				{
					if ($MissionName == $TotalMissionList[%rnd])
					{
						%nextMission = $TotalMissionList[1];
						$pref::LastMission = $TotalMissionList[1];
						//echo("Stuck in this damn loop again: " @ $TotalMissionList[%rnd]);
					}
					else
					{
						%nextMission = $TotalMissionList[%rnd];
						$pref::LastMission = $TotalMissionList[%rnd];
					}
				}
				%goodmtype = $HaVoC::MType[%nextMission];
				%l = %l + 1;
			}
			if(%l < 5000) 
			{
				$FirstTime = 1;
				//echo("firsttime = " @ $firstTime);
				echo("A random mission has been selected.");
				messageall(0, "A random mission is being selected...");
				messageall(0, "Changing to mission "@%nextMission@" ("@$HaVoC::MType[%nextMission]@").");
			}
			else 
			{
				echo("No missions found of the choosen $HaVoC::RandomMissionTypes()!");
				echo("Please verify HaVoC.cs is using the correct settings");
				echo("and that maps of the selected types exist.");
				echo("Using default next mission.");
				%nextMission = $nextMission[$missionName];
			}
  		}
  		else
		{
  			%nextMission = $nextMission[$missionName];
		}
	}
   	echo("Changing to mission ", %nextMission, ".");
   	Server::loadMission(%nextMission);
}



function remoteCycleMission(%clientId)
{
   if(%clientId.isAdmin)
   {
      messageAll(0, Client::getName(%playerId) @ " cycled the mission.");
      %replay = false;
      Server::nextMission(%replay);
   }
}

function remoteDataFinished(%clientId)
{
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
      remoteEval(%cl, missionChangeNotify, %nextMission);
   }
   
   if ($LockedServer == "True" && $match == "True") 
   {
   	exec("playerlist.cs");
   	echo("Player List loaded");
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

   newObject(ConsoleScheduler, SimConsoleScheduler);
   if(!%immed)
      schedule("Server::finishMissionLoad();", 12);
   else
      Server::finishMissionLoad();      
}

function Server::finishMissionLoad()
{
   $loadingMission = false;
   // instant off of the manager
   setInstantGroup(0);
   newObject(MissionCleanup, SimGroup);
   
   
   exec($missionFile);

	modmgtMissionMods();

   Mission::init();
	Mission::reinitData();
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
   {
      Game::startMatch();
   }
   else if($Server::warmupTime && !$Server::TourneyMode)
   {
      Server::Countdown($Server::warmupTime);
   }
   else if(!$Server::TourneyMode)
   {
      Game::startMatch();
   }
   $teamplay = (getNumTeams() != 1);
   purgeResources(true);
   return "True";
}

function Server::Countdown(%time)
{
   //if ($match = "True") $teamScoreLimit = $MaximumScore;
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

//Mod stuff
$serverModInfo = "Visit www.primenet.com/~desrtfox for information on the Professional Mod";
//exec (motd);

function WriteRandom()
{
	$RandomNum::Exists = 1;
	for(%i = 0; %i < 1000; %i++)
	{
		$RandomNum::Number[%i] = getRandom();
	}
	%saved = export("$RandomNum*","config\\Random.cs", False);
	echo("Writing Random Number "@ %saved);
	%rnd = floor(getRandom()*600);
	schedule("WriteRandom();", %rnd);
}

function ReadRandom()
{
	%loaded = exec("Random.cs");
	echo("Reading Random " @ %loaded);
}

// putting a global variable in the argument list means:
// if an argument is passed for that parameter it gets
// assigned to the global scope, not the scope of the function


//==== Mini Mod Additions.

function MiniMod::Load(%string)
{
if(%string == "") {
	echo("MiniMod::Load... You must enter the File-Mask in order for me to load it.");
	}
if(%string != "") {
    deleteVariables("$mmLoad*");
    %i = 0;
    %file = File::findFirst(%string);  // find the first one
    while(%file != "")                                   // keep it up till they are all found
    {
        %unique = true;
        for(%a = 0; (%a < %i) && %unique; %a++) // this all seems unnecessary, but it is needed
        {                                       // otherwise, the same file may be found multiple times
            if($mmLoad[%a] == %file)        // timing issue maybe? I dunno.
                %unique = false;
        }
        if(%unique)
        {
            $mmLoad[%i] = %file;            // build an array of the filenames
            %i++;                               // increment our count
        }
        %file = File::findNext(%string); // find the next one
    }

    for(%a = 0; %a < %i; %a++) // exec them all
        exec($mmLoad[%a]);
    $mmLoadSize = %i;
	}
}

MiniMod::Load("plugins\\*.Core.Functions.cs");
MiniMod::Init::Client();

//==== TribeStat Scoring.cs

function TribeStat_GetTeams() {
    echo("//TS");
    echo("\"2\"-1\"0\"Reset\"");
    for(%i = 0; %i < getNumTeams() ; %i++)
           echo("\"2\"" @ %i @ "\"" @ $teamScore[%i] @ "\"" @ getTeamName(%i) @ "\"");
}

function TribeStat_GetPlayers() {
    echo("//TS");
    echo("\"1\"2048\"Reset\"IP: 000.000.000.000:0000\"0\"0\"None\"");
    for(%cl = Client::getFirst(); %cl != -1; %cl=Client::getNext(%cl)) {
        if (Client::getName(%cl) == "")
            %ClientName = "Unnamed";
        else
            %ClientName = Client::getName(%cl);

        echo("\"1\"" @ %cl @ "\"" @ escapeString(%ClientName) @ "\"" @ Client::getTransportAddress(%cl) @ "\"" @ Client::getTeam(%cl) @ "\"" @ %cl.score @ "\"" @ Client::getGender(%cl) @ "\"");
    }
}

function TribeStat_GetPreferences() {
    echo("//TS");
    echo("\"Q\"0\"" @
        $Server::HostName @ "\"" @
        $Server::Port @ "\"" @
        $Server::MaxPlayers @ "\"" @
        $Server::TimeLimit @ "\"" @
        $Server::WarmupTime @ "\"" @
        $Server::AutoAssignTeams @ "\"" @
        $Server::TeamDamageScale @ "\"" @
        $Server::TourneyMode @ "\"" @
        $Server::MinVotes @ "\"" @
        $Server::MinVotesPct @ "\"" @
        $Server::VoteWinMargin @ "\"" @
        $Server::VotingTime @ "\"" @
        $TribeStat::BlockADM @ "\"" @
        $TribeStat::BlockTD @ "\"" @
        $TribeStat::BlockGT @ "\"" @
        $TribeStat::BlockMIS @ "\"" @
        $Server::Password @ "\""
    );
    echo("\"Q\"1\"" @ escapeString($Server::Info) @ "\"" @ escapeString($Server::JoinMOTD) @ "\"");
}

function TribeStat_GetStatus() {
    echo("//TS");
    echo("\"Q\"3\"" @
         $missionName @ "\"" @
         ($Server::timeLimit * 60) + $missionStartTime - getSimTime() @ "\"");
}

function TribeStat_ShowScores() {
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

//==== Normal Server.cs

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

   export("Server::*", "temp\\" @ $ServerDataFile, False);
   export("pref::lastMission", "temp\\" @ $ServerDataFile, true);
   EvalSearchPath();
}

function Server::refreshData()
{
   exec($ServerDataFile);  // reload prefs.
   checkMasterTranslation();
   Server::loadMission($pref::lastMission, false);
}

function Server::onClientDisconnect(%clientId)																	// server.cs
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
   //TS
   echo("\"D\"" @ %clientId @ "\"");
   Game::CheckTourneyMatchStart();
   if(getNumClients() == 1) // this is the last client.
      Server::refreshData();
}

function KickDaJackal(%clientId)
{
   Net::kick(%clientId, "The FBI has been notified.  You better buy a legit copy before they get to your house.");
}

function Server::onClientConnect(%clientId)																		// server.cs
{
   if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
   {
      // force admin the loopback dude
      %clientId.isAdmin = true;
      %clientId.isSuperAdmin = true;
   }
      
   	SHCheckAutoAdmins(%clientId);
   	SHCheckTransportAddress(%clientid);

   //TS echo("CONNECT: " @ %clientId @ " \"" @ escapeString(Client::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));
   echo("\"C\"" @ %clientId @ "\"" @ escapeString(Client::getName(%clientId)) @ "\"" @ Client::getTransportAddress(%clientId) @ "\"" @ Client::getGender(%clientId) @ "\"");

   if(0) // PORT-FIX: hard-coded name kick removed (DaJackal)
      schedule("KickDaJackal(" @ %clientId @ ");", 20, %clientId);

   %clientId.noghost = true;
   %clientId.messageFilter = -1; // all messages
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
   remoteEval(%clientId, MODInfo, $MODInfo);
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

   
	exec(admin);
	exec(Marker);
	exec(Trigger);
	exec(NSound);
//	if ($Shifter::MiniMod) exec(MiniModN);
	exec(BaseExpData);
//	if ($Shifter::MiniMod) exec(MiniModE);
	exec(BaseDebrisData);
//	if ($Shifter::MiniMod) exec(MiniModD); 
	exec(BaseProjData);
//	if ($Shifter::MiniMod) exec(MiniModP);
	exec(ArmorData);
	exec(Mission);
	exec(Item);
//	if ($Shifter::MiniMod) exec(MiniModI);
	exec(Player);
	exec(Vehicle);
//	if ($Shifter::MiniMod) exec(MiniModV);
	exec(Turret);
//	if ($Shifter::MiniMod) exec(MiniModT);
	exec(Beacon);
	exec(StaticShape);
//	if ($Shifter::MiniMod) exec(MiniModX);
	exec(Station);
//	if (Shifter::MiniMod) exec(MiniModS);
	exec(Moveable);
	exec(Sensor);
	exec(Mine);
	exec(AI);
	exec(InteriorLight);

	MiniMod::Init::Server();   

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
   {
		if ($Shifter::RandomMissions)
		{
			%rnd = floor(getRandom() * $TotalMissions);
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
	  	}
	  	else
		{
	  		%nextMission = $nextMission[$missionName];
		}	  
	  	
   }
   echo("Changing to mission ", %nextMission, ".");

   // give the clients enough time to load up the victory screen






   Server::loadMission(%nextMission);
}

function remoteCycleMission(%clientId)
{
   if(%clientId.isAdmin)
   {
      messageAll(0, Client::getName(%playerId) @ " cycled the mission.");
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

function SHSayAutoAdmin(%clientid)
{
	TopPrint(%clientid,"<F1><jc>You have been set to Auto Admin",5);
}

function SHCheckTransportAddress(%clientid)
{
	%addr = Client::getTransportAddress(%clientId);
	echo(%clientid @ " <- " @ %addr);

	if(String::getSubStr(%addr,0,8) == "LOOPBACK")
		return;

	if(String::getSubStr(%addr,0,3) != "IP:" && String::getSubStr(%addr,0,4) != "IPX:" )
	{
		echo(%clientid @ " is not correct address form, kicking");
		schedule("SHKickClient(" @ %clientid @ ");",20,%clientid);
		return ;
	}

	for(%i=0;$SHBanList[%i] != "";%i++)
	{
		if(String::findSubStr(%addr,$SHBanList[%i]) == 0)
		{
			echo(%clientid @ " is banned");
			schedule("SHKickClient(" @ %clientid @ ");",20,%clientid);
			return;
		}
	}
}

function SHCheckAutoAdmins(%clientid)
{
	%addr = Client::getTransportAddress(%clientId);

//	echo ("Checking Admin ---> " @ %clientid );
//	echo ("Addr Check     ---> " @ String::findSubStr(%addr,$Server::AutoAdminAddr[%i]));
//	echo ("Name Check     ---> " @ Client::getName(%clientId));


	for(%i=0; $Server::AutoAdmin[%i] != "" || $Server::AutoAdminAddr[%i] != "" ;%i++)
	{
		if(($Server::AutoAdmin[%i] == "" || $Server::AutoAdmin[%i] == Client::getName(%clientId)) && (String::findSubStr(%addr,$Server::AutoAdminAddr[%i]) == 0))
		{
			echo("AutoAdmining: " @ %clientId @ " \"" @ escapeString(Client::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));
	    	schedule("SHSayAutoAdmin(" @ %clientId @ ");", 30, %clientId);
			%clientId.isAdmin = true;
			%clientId.isSuperAdmin = true;
		}
	}
}
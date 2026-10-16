// putting a global variable in the argument list means:
// if an argument is passed for that parameter it gets
// assigned to the global scope, not the scope of the function

//Known Mission Boundaries (for auto-respawn on OOB)----------Begin
//This feature from shifter_v1G

//EXAMPLE - $Bounds[Example_Stadium] = "xcenter ycenter width height";
$Bounds[EEPROM_Stadium] = "-176.891 73.8616 400 180";
$Bounds[HeiligeScheisseStadium] = "168 292.5 318 209";
$Bounds[LN2_Stadium] = "22 404 136 272";
$Bounds[Official_Stadium1] = "6.61487 403.289 170 300";
$Bounds[Official_Stadium3] = "38.6675 403.472 140 300";
$Bounds[Official_Stadium4] = "-2622.33 -783.13 297 147";
$Bounds[Official_Stadium6] = "0 -45 500 500";
$Bounds[Official_Stadium7] = "22 404 136 272";
$Bounds[Official_Stadium8] = "-56.4979 -194.338 100 280";
$Bounds[Official_Stadium9] = "-550 -348 300 300";
$Bounds[Official_Stadium10] = "-380 17 260 120";
$Bounds[RampedTouchdown2] = "-154 -76 308 152";
$Bounds[Redshirt_Memorial_Stadium] = "-154 -67 308 134";
$Bounds[The_Colosseum] = "-1320 -271 390 390";
   %specialname = "TK-421_Extended_Stadium";
$Bounds[%specialname] = "493.25 555 133.5 310";
   %specialname = "Tk-421_Stadium";
$Bounds[%specialname] = "47 424 86 240";

//Known Mission Boundaries (for auto-respawn on OOB)----------End
   function connectingInfo2(%clientId)
   {
      remoteEval(%clientId, MODInfo, "\n" @ $SecondConnectingMessage);
   
   }
   function connectingInfo(%clientId)
   {
      remoteEval(%clientId, MODInfo, "<f1>" @ $curVersion @ "\n" @ $MODInfo);
   
      schedule("connectingInfo2(" @ %clientId @ ");",1);
   }
   function createTrainingServer()
   {
   $SinglePlayer = true;
      createServer($pref::lastTrainingMission, false);
   }
   function AnnStrLen(%string) { 
      for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++) %length = %i; %length++; 
      return %length; } 
   function String::ReplaceStr(%string, %search, %replace)
   {
      %len = AnnStrLen(%search);
      for (%i = 0; (%char = String::getSubStr(%string, %i, %len)) != ""; %i++)
      {
         if (%char @ "s" == %search @ "s") %string = String::getSubStr(%string, 0, %i) @ %replace @ String::getSubStr(%string, %i + %len, 255);
      }
      return %string;
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
   function ixPrepIP(%transport) { 
      %x = 0; 
      %i = 0; 
      %now = 0; 
      while( %x < 2 && %i < 30 ) { 
         if(String::getSubStr(%transport, %i, 1) == ":") { 
            if(!%now) 
               %now = %i + 1; 
            else 
               return String::getSubStr(%transport, %now, %i - %now);
            %x++; 
         } 
         %i++;
      } 
      return "11.11.11.11"; 
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
      Server::nextMission(false);
   }

   function Server::onClientDisconnect(%clientId)
   {
      if(%clientId.possessId != "")
         revert(%clientId);
      %ip = Client::getTransportAddress(%clientId);
   // Need to kill the player off here to make everything
   // is cleaned up properly.
      %player = Client::getOwnedObject(%clientId);
      if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
         playNextAnim(%player);
         Player::kill(%player);
      }
   
      Client::setControlObject(%clientId, -1);
      Client::leaveGame(%clientId);
      Game::CheckTourneyMatchStart();
      if(getNumClients() == 1 && $CycleOnEmpty) // this is the last client.
         Server::refreshData();
   //vote dodge fix
   
      if($LastVoteIP == %ip) {
         messageAll(0, Client::getName(%clientId) @ " conceded and was kicked.");
         BanList::add(%ip, 180);
      }
   $GlobalMute[%clientId] = false;
      if($FBPerson == %clientId)
      $FBPerson = 0;
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(%clientId.privatechat == %cl)
            %clientId.privatechat = "";
      %clientId.telecurse = false;
   $badAttempts[%clientId] = "";
   
      if($MMode && getNumClients() == 0)
      {
         deleteObject($CurrentFootball);
      $CurrentFootball = "";
      $footballExists = "";
      $MMode = false;
      $MPUG = false;
      $MMatchStarted = false;
      $Server::teamName[0] = $MOldName[0];
      $Server::teamName[1] = $MOldName[1];
         Server::refreshData();
         Server::loadMission($pref::lastMission);
      }
   }

   function KickDaJackal(%clientId)
   {
      Net::kick(%clientId, "The FBI has been notified.  You better buy a legit copy before they get to your house.");
   }

   function Server::onClientConnect(%clientId)
   {
%ip = client::getTransportAddress(%clientId);
if(string::findSubStr(client::getName(%clientId), ".bmp") != "-1" || client::getName(%clientId) == "" || string::findSubStr(client::getName(%clientId), "<R") != "-1" || string::findSubStr(client::getName(%clientId), "<L") != "-1" || string::findSubStr(client::getName(%clientId), "<S") != "-1")
{
	kick(%clientId, "Get a different name.");
	banlist::add(%ip, 60);
return;
}   
$TCSuspect[%clientId] = false;

if($ConnectsPerIP) {
%n = 0;
 for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
      {
if(ixPrepIp(%ip) == ixPrepIp(client::getTransportAddress(%id)))
%n ++;


	}   

if(%n > $ConnectsPerIP) 
schedule("net::kick("@%clientId@", \"Cannot connect more than " @ $ConnectsPerIP @ " times with the same IP\");",0.2);


}

      // clear out any client info:
      for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";
   
      %clientId.noghost = true;
      %clientId.messageFilter = -1; // all messages
   
      %clientId.privatechat = "";
      %clientId.frozen = false;
%clientId.spam = 0;
      if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
      {
         // force admin the loopback dude (stock; restored for listen hosts)
         %clientId.isAdmin = true;
         %clientId.isSuperAdmin = true;
      }
      remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
      remoteEval(%clientId, FileURL, $Server::FileURL);
      %ip = Client::getTransportAddress(%clientId);
      echo("CONNECT: " @ %clientId @ " \"" @ 
          escapeString(Client::getName(%clientId)) @ 
          "\" " @ %ip);
   
   
   
   
      if($lastConnect == %ip) {
         if($lastConnectTries == 3) {
            BanList::add(%ip, 3600);
            schedule("Net::Kick(" @ %clientId @ ");",0.5);
            MessageAll(1,Client::getName(%clientId) @ " has been banned for an hour for attempting to crash the server.");
echo("BANNED");
         }
         else {
            schedule("$lastConnectTries = 0;",5);
            $lastConnectTries++;
         }
      }
      else {
      $lastConnectTries = 0;
      $lastConnect = %ip;
      }
   

   
   
      if($MMode) {
         %name = Client::getName(%clientId);
      
         if($MNum::[%name] == "")
            MNewClient(%name);
         if($MPUG)
            if($MMatchStarted)
               remoteEval(%clientId, MODInfo, "<f1>" @ $curVersion @ "\nPUG Mode Engaged - Match In Progress\n" @ $MODInfo);
            else 
               remoteEval(%clientId, MODInfo, "<f1>" @ $curVersion @ "\nPUG Mode Engaged\n" @ $MODInfo);
         else
            if($MMatchStarted)
               remoteEval(%clientId, MODInfo, "<f1>" @ $curVersion @ "\nMatch Mode Engaged - Match In Progress\n" @ $MODInfo);
            else 
               remoteEval(%clientId, MODInfo, "<f1>" @ $curVersion @ "\nMatch Mode Engaged\n" @ $MODInfo);
      }
      else
         connectingInfo(%clientId);

Server::connectInfo(%clientId, true);
   
      Game::onPlayerConnected(%clientId);   
   
   }

   function Server::nextMission(%replay)
   {
   
      echo("NEXTMISSION CALLED");
      if(%replay || $Server::TourneyMode)
         %nextMission = $missionName;
      else
         if($setNextMission != "")
            %nextMission = $setNextMission;
         else
            %nextMission = $nextMission[$missionName];
      echo("Changing to mission ", %nextMission, ".");
   
   // give the clients enough time to load up the victory screen
      Server::loadMission(%nextMission);
   }

   function remoteCycleMission(%clientId)
   {
      if(%clientId.isAdmin)
      {
         messageAll(0, Client::getName(%clientId) @ " cycled the mission.");
         Server::nextMission();
      }
   }

   function remoteDataFinished(%clientId)
   {
%clientId.spam++;
schedule("checkSpam(" @ %clientId @ ");",0.5);

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
%playerId.spam++;
schedule("checkSpam(" @ %playerId @ ");",0.5);

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
   
   $setNextMission = "";
   
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
      //fix for bug at next mission
         %cl.tackled = false;
         %cl.guiLock = true;
         %cl.nospawn = true;
         remoteEval(%cl, missionChangeNotify, %missionName);
      }
   
   $loadingMission = true;
   $missionName = %missionName;
   $missionFile = %missionFile;
   $prevNumTeams = getNumTeams();
      deleteObject("$CurrentFootball");
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
      if($bounds[$missionName] != "")
      {
         %xpos = getword($bounds[$missionName], 0);
         %ypos = getword($bounds[$missionName], 1);		
         %width = getword($bounds[$missionName], 2);
         %height = getword($bounds[$missionName], 3);
      $xMin = %xpos;
      $yMin = %ypos;
      $xMax = %xpos + %width;
      $yMax = %ypos + %height;
      $BoundsCheck = true;
      }
      else
      $BoundsCheck = false;
   
      deleteObject($currentFootball);
      Mission::init();
      Mission::reinitData();
   
      if($prevNumTeams != getNumTeams() && !$MMode)
      {
      // loop thru clients and setTeam to -1;
         messageAll(0, "New teamcount - resetting teams.");
         for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
            GameBase::setTeam(%cl, -1);
      $RanAssignNum = $RanAssign;
      }
      else if($RanAssignNum == 1 && getNumTeams() == 2 && !$MMode)
      {
         messageall(1, "Randomly assigning teams. (Occurs after every " @ $RanAssign @ " maps)", 5);
         mixUpTeams();
      $RanAssignNum = $RanAssign;
      }
      else if($RanAssignNum > 1 && !$MMode)
      $RanAssignNum--;
   
   $ghosting = true;
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         if($MMode && !$MMatchStarted)
            GameBase::setTeam(%cl, -2);
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
      else if(!$Server::TourneyMode && (($MMatchStarted && $MMode) || !$MMode))
         Game::startMatch();
   
   $teamplay = (getNumTeams() != 1);
      purgeResources(true);
   
   // make sure the match happens within 5-10 hours.
      schedule("Server::CheckMatchStarted();", 3600);
      schedule("Server::nextMission(false);", 18000);
   
      return "True";
   }

   function Server::CheckMatchStarted()
   {
   // if the match hasn't started yet, just reset the map
   // timing issue.
      if(!$matchStarted)
         Server::nextMission(false);
   }

   function Server::Countdown(%time)
   {
      if($MMode && !$MMatchStarted)
         return;
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      $TCSuspect[%cl] = false;
   
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
      exec(matchmode);
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
   
      Server::storeData();
   
   // NOTE!! You must have declared all data blocks BEFORE you call
   // preloadServerDataBlocks.
   
      preloadServerDataBlocks();
   
      CreateWeaponCyclingTables();
      Server::loadMission( ($missionName = %mission), true );
      exec(thunderInfo);
      exec(Iplogger);
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
   
      echo("-----------------------------------");
      echo($curVersion);
      echo("-----------------------------------");
      return "True";
   }


// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------

if($ModXServerLANOnly == "")
    $ModXServerLANOnly = false;

// Mod Info...
$currentModName = "ModX 3.0 Open Source";
$loadingString = "\n<jc><f0>-[<f2>\t\t"@ $currentModName @"\t\t<f0>]-\n\t  Created by <f1>Vage\t\n<f0>\t  Website: <f1>http://modx.cjb.net/\t\n\t  <f0>- <f1>- <f2>- <f1>- <f0>- ";

// Server Messages...
$disconnectMsg = "Connection to server error:";
$rejectMessage = "Connection to server rejected:";

exec("ModX_IntTime.cs");
$ModX::IntTimeOld = $ModX::IntegerTime[0];
if($ModX::IntTimeOld == "")
    $ModX::IntTimeOld = 0;
    
$ModX::IntTimeNumOld = $ModX::IntegerTime[1];
if($ModX::IntTimeNumOld == "")
    $ModX::IntegerTime[1] = 0;

function uptime()
{}
          
function ModX::LogTime()
{
    %time = getintegertime(true)>>5;
    $ModX::IntegerTime[0] = (%time + $ModX::IntTimeOld) - (604800 * $ModX::IntegerTime[1]);
    export("$ModX::IntegerTime*", "config\\ModX_IntTime.cs", false);
    schedule("ModX::LogTime();", 1);
    %seconds = $ModX::IntegerTime[0];

    if(%seconds == 302400) // 3.5 Days (0.5 Weeks) have passed
    {
        //Clear Unused Saves
        for(%a = 0; $ModXAcctName::[%a] != ""; %a++)
        {
            //
            if(302400 - $LoggedTime::[%a@"01"] > 172800) // If it's more than two days in dis-use
            {
                Account::ResetAcctObjectIndex(%a, 1);
            }
        }
        Account::exportSaves();
        %export = "$ModXAcctObjSlotName::*";
        export(%export, $ObjSaveFileN, false);
    }
    if(%seconds == 604800) // 1 Week has passed
    {
        $ModX::IntegerTime[1]++;
        export("$ModX::IntegerTime*", "config\\ModX_IntTime.cs", false);
        //Clear Unused Saves
        for(%a = 0; $ModXAcctName::[%a] != ""; %a++)
        {
            //
            if(604800 - $LoggedTime::[%a@"01"] > 172800) // If it's more than two days in dis-use
            {
                Account::ResetAcctObjectIndex(%a, 1);
            }
            else
                $LoggedTime::[%a@"01"] = "0";
                
                
            if(604800 - $LoggedTime::[%a] > 172800)
            {
                $ModXAcctBinds::[%a] = "";
                $ModXAcctWeapHelp::[%a] = "";
            }
            else
                $LoggedTime::[%a] = "0";
        }
        Account::exportSaves();
        %export = "$ModXAcctObjSlotName::*";
        export(%export, $ObjSaveFileN, false);
        %export = "$ModXAcctBinds::*";
        export(%export, $AcctBindFile, false);
        %export = "$ModXAcctWeapHelp::*";
        export(%export, $AcctHelpFile, false);
        export("$LoggedTime::*", $LogTimeFile, false);
    }
}

function ModX:InitVars(%clientId)
{
    %clientId.ModXChecked = false;
    %clientId.ModXAccount = false;
    %clientId.EnteringNewAcct = false;
    %clientId.EnteringPassword = false;
    %clientId.ReNamingSlot = -1;
    %clientId.isInHelp = false;
    %clientid.MovementType = "Free Move";
    %clientId.mvtype = "all";
    %clientId.deltype = "all";
    %clientId.TotalDeploys = 0;
    %clientId.currLayer = 0;
   
    %clientId.CurDeploy = 0;
    %clientId.moldsurface = true;
    %clientId.XRotOffset = 0;
    %clientId.YRotOffset = 0;
    %clientId.ZRotOffset = 0;
    %clientId.XPosOffset = 0;
    %clientId.YPosOffset = 0;
    %clientId.ZPosOffset = 0;
    %clientId.CannotDeploy = false;
    %clientId.ToolRadius = 15;
    %clientId.autologged = false;
    %clientId.TransVel = true;
    
    %clientId.isMovingAll = true;
    
    %clientId.buildgroup = "";
    BuildGroup::Leave(%clientId);
}

function createTrainingServer()
{
   $SinglePlayer = true;
   createServer($pref::lastTrainingMission, false);
}

function ModX::isInIndex(%name, %type)
{
    if(%type == "Admin")
    {
        for(%i = 0; (%indexName = $Admins[%i]) != ""; %i++)
        {
            if(%name == %indexName)
               return true;
        }
        return false;
    }
    if(%type == "SuperAdmin")
    {
        for(%i = 0; (%indexName = $SuperAdmins[%i]) != ""; %i++)
        {
            if(%name == %indexName)
                return true;
        }
        return false;
    }
    return false;
}

function ModX::IsReservedName(%desc, %name)
{
      for(%i = 0; (%list = $ReservedNames[%i]) != ""; %i++)
      {
            if (%list == %name)
            {
                 if (%desc == $ReservedNamePassword)
                     return true;
                 return false;
            }
      }
      return -1;
}

function ModX::CheckPlayer(%clientId)
{
   %IPAddress = ModX::IPCut(Client::getTransportAddress(%clientId));
   %info = $Client::info[%clientId, 5];
   %Name = Client::getName(%clientId);
   echo("MODX: Connect " @ escapeString(%name) @ " \ " @ %IPAddress);

   if ($AdminPassword != "" && %info == $AdminPassword && ModX::isInIndex(%Name, "Admin")) // PORT: never with an empty code
   {
       echo("MODX: Admin Join " @ %Name @ ", " @ %IPAddress);
       %clientId.isAdmin = true;
   }
   if ($SuperAdminPassword != "" && %info == $SuperAdminPassword && ModX::isInIndex(%Name, "SuperAdmin")) // PORT: never with an empty code
   {
       echo("MODX: SuperAdmin Join " @ %Name @ ", " @ %IPAddress);
       %clientId.isAdmin = true;
       %clientId.isSuperAdmin = true;
   }
   if (%IPAddress == "LOOPBACK")
   {
      %clientId.isAdmin = true;
      %clientId.isSuperAdmin = true;
   }
   
   if(ModX::IsReservedName(%info, %Name) == false && %clientId.isAdmin != true)
   {
      echo("MODX: Reserved Name Violation " @ %Name @ ", " @ %IPAddress);
      schedule("KickReservedName(" @ %clientId @ ");", 20, %clientId);
   }
   
   %clientId.ModXChecked = true;
}

function remoteSetCLInfo(%clientId, %skin, %name, %email, %tribe, %url, %info, %autowp, %enterInv, %msgMask)
{
   $Client::info[%clientId, 0] = %skin;
   $Client::info[%clientId, 1] = %name;
   $Client::info[%clientId, 2] = %email;
   $Client::info[%clientId, 3] = %tribe;
   $Client::info[%clientId, 4] = %url;
   $Client::info[%clientId, 5] = %info;
   $Client::info[%clientId, 6] = ModX::IPCut(Client::getTransportAddress(%clientId));
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
   Server::nextMission(false);
}

function Server::onClientDisconnect(%clientId)
{
    // Need to kill the player off here to make everything
	// is cleaned up properly.
    AbandonAllClObj(%clientId);
    ModX:InitVars(%clientId);
    %clientId.Checkable = false;
   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%player);
	   Player::kill(%player);
	}

   %ip = client::getTransportAddress(%clientId); //Prevent a player from joining
   banlist::add(%ip, 7);                         //for 7 seconds after a connect

   Client::setControlObject(%clientId, -1);
   Client::leaveGame(%clientId);
   Game::CheckTourneyMatchStart();
   if(getNumClients() == 1 && !$EditingMission && !$Server::HoldMission) // this is the last client. PORT: the two 1.50 gates of base server.cs
      Server::refreshData();
}

function KickDaJackal(%clientId)
{
   Net::kick(%clientId, "The FBI has been notified.  You better buy a legit copy before they get to your house.");
}

function KickReservedName(%clientId)
{
   Net::kick(%clientId, "The name you are trying to use has been reserved on this server.");
}

function KickAdminSlotUser(%clientId)
{
   Net::kick(%clientId, "The player slot was reserved. AUTO-KICKED.");
}

function KickBannedAccount(%clientId)
{
   Net::kick(%clientId, "Your account on this server has been banned.");
}

function Server::onClientConnect(%clientId)
{
   //echo("CONNECT: " @ %clientId @ " \"" @
   //   escapeString(Client::getName(%clientId)) @
   //   "\" " @ Client::getTransportAddress(%clientId));
   // PORT: the 1998 kick of any player named DaJackal was here; KickDaJackal stays defined, uncalled.
   %clientId.Checkable = false;
   %clientId.AcctNo = "";
   %clientId.noghost = true;
   %clientId.messageFilter = -1; // all messages
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
   remoteEval(%clientId, MODInfo, $MODInfo);
   remoteEval(%clientId, FileURL, $Server::FileURL);

   // clear out any client info:
   for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";

   Game::onPlayerConnected(%clientId);
   $TotalConnectedPlayers++;
   ModX:InitVars(%clientId);
}

function createServer(%mission, %dedicated)
{
   //$Server::MODInfo = $loadingString;
   $loadingMission = false;
   $ME::Loaded = false;
   if(%mission == "")
      %mission = $pref::lastMission;

   if(%mission == "")
   {
      echo("Error: no mission provided.");
      return "False";
   }

   $SinglePlayer = $ModXServerLANOnly;

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
   exec(BaseExpData);
   exec(BaseDebrisData);
   exec(BaseProjData);
   exec(Mission);
   exec(Item);
   exec(Player);
   exec(Vehicle);
   exec(Turret);
   exec(StaticShape);
   exec(Station);
   exec(Moveable);
   exec(Sensor);
   exec(Mine);
   exec(AI);
   exec(InteriorLight);
   exec("LanguageSystem.cs");
   exec("variousFuncs.cs");
   exec("math.cs");
   exec("accountsys.cs");
   exec("clientScriptHandler.cs");
   
   //exec("fakedeath.cs");
   
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
   $TotalDeploys = 0;
   $LaserTagMode = true;
   Account::DisableLaserTag(-1);
   // PORT: $modList = $currentModName; was here. $modList is the search path under 1.50; "ModX 3.0 Open Source"
   // would make it config;ModX;3.0;Open;Source and drop this mod's own folder at the next server start.
   $Server::MODInfo = $currentModName;
   $MODInfo = $loadingString;
   if($dedicated)
   {
       echo(" ");
       echo(" / - - - - - - - - - - - - - - - - - - - - - - - - - - - - - \\ ");
       echo("<| -      ModX is copyrighted by Vage aka Jacob Gohlke.    - |>");
       echo(" | -                                                       - | ");
       echo(" | - By using this software, you agree to the EULA and are - | ");
       echo("<| - bound by any terms expressed herein.                  - |>");
       echo(" \\ - - - - - - - - - - - - - - - - - - - - - - - - - - - - - / ");
       echo(" ");
   }
   else
   {
       echo(" ");
       echo("<ModX is copyrighted by Vage aka Jacob Gohlke>");
       echo("By using this software, you agree to the EULA and are");
       echo("bound by any terms expressed herein.");
       echo(" ");
   }
   schedule("randomHelpMsg();", 3);
   ModX::LogTime();
   return "True";
}

function Server::nextMission(%replay)
{
   // PORT: same gate as base server.cs. Unset on every shipped config; the test harness sets it.
   if($Server::HoldMission) { echo("[HOLD] mission rotation suppressed (staying on ", $missionName, ")"); return; }
   if(%replay || $Server::TourneyMode)
      %nextMission = $missionName;
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

   DeleteAllObjects();

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
   
   ModX::CleanupMission();
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

function Talk(%name, %msg)
{
   centerprintall("<JC><F2>" @ %name @ ": <F1>" @ %msg);
}

function Talk::Vage(%msg)
{
   bottomprintall("<JC><F2>Vage: <F1>" @ %msg);
}
    
function listPlayers()
{
    echo(getNumClients() @ " Players out of " @ $Server::MaxPlayers @ " with " @ $TotalDeploys @ " Deployed Objects");
    echo("/---");
    for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
    {
        %name = Client::GetName(%clientId);
        %ip = $Client::info[%clientId, 6];
        %dep = $ClScore[%clientId];
        echo("|-CL " @ %clientId @ " DEPLOYS:" @ %dep @ " -- NAME: " @ %name @ " -- IP:   " @ %ip);
        echo("|");
    }
    echo("\\---");
}

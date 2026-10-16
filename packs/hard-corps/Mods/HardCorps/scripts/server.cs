// putting a global variable in the argument list means:
// if an argument is passed for that parameter it gets
// assigned to the global scope, not the scope of the function

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
   // PORT: the Remote Admin List compares real name and e-mail, which only arrive here (they are
   // blank when Server::onClientConnect runs). Checked once per connection.
   if($UseRemoteAdminList == "true" && !%clientId.hcListChecked && String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
   {
      %clientId.hcListChecked = true;
      CheckForAutoStatus(%clientId);
   }
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
   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%player);
	   Player::kill(%player);
	}

   Client::setControlObject(%clientId, -1);
   Client::leaveGame(%clientId);
   Game::CheckTourneyMatchStart();
   if(getNumClients() == 1 && !$EditingMission && !$Server::HoldMission) // this is the last client. PORT: the two 1.50 gates of base server.cs
      Server::refreshData();
}

function KickDaJackal(%clientId)
{
   Net::kick(%clientId, "You have no penis.  Please buy one.");
}

function remoteSetArmor(%player, %armorType)
{
	if ($ServerCheats) {
		checkMax(Player::getClient(%player),%armorType);
	   Player::setArmor(%player, %armorType);
	}
	else if($TestCheats) {
	   Player::setArmor(%player, %armorType);
	}
}

function GetNextEntry(%var)
{
	%entry = "";
	%firstword = "true";
	for(%al = $adminentry; getWord(%var,%al) != "X"; %al++)
		{
			if (%firstword == "true") %entry = getWord(%var,%al); else %entry = %entry @ " " @ getWord(%var,%al);
			%firstword = "false";
		}
	$adminentry = %al + 1;
	return %entry;
}

//Thanks to *IX* Savage for doing the grunt work yet again.

function ixDotToSpace(%string) 
{ 
	%x = 0;
	%i = 0;
	while(%x< 3 && %i < 64) // PORT: bounded
		{ 
			%char = String::getSubStr(%string,%i,1);
			if(!String::ICompare(%char, ".")) 
				{ 
					%left = String::getSubStr(%string,0,%i);
					%right = String::getSubStr(%string,%i+1,255);
					%string = strcat(%left," ",%right);
					%x++;
				} 
			%i++;
		} 
	return %string;
} 

function ixCompareIP(%ip, %mask) 
{ 
	// PORT: the engine reports "IP:a.b.c.d:port"; the list holds "a.b.c.d" with * wildcards (Hard Corps.txt)
	if(String::getSubStr(%ip, 0, 3) == "IP:") %ip = String::getSubStr(%ip, 3, 64);
	%colon = String::findSubStr(%ip, ":");
	if(%colon > 0) %ip = String::getSubStr(%ip, 0, %colon);
	if(String::getSubStr(%mask, 0, 3) == "IP:") %mask = String::getSubStr(%mask, 3, 64);
	if(%ip == "" || %mask == "") return "false";
	%ipNow = ixDotToSpace(%ip);
	%maskNow = ixDotToSpace(%mask);
	for(%x=0; %x< 4; %x++) 
		{ 
			%one = getWord(%ipNow, %x);
			%two = getWord(%maskNow, %x);
			if(%two == "" || ((%one != %two) && (%two != "*"))) return "false"; // PORT: a short mask does not match
		} 
	return "true";
} 

function ixAdminMsg(%msg) // modified
{ 
	echo("ADMIN: " @ %msg @ "");
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers;%i++) 
		{ 
			%pl = getClientByIndex(%i);
			if(%pl.regularuser) 
				{ 
					Client::sendMessage(%pl, 0, "" @ %msg @ "");
				} 
		} 
} 

function CheckForAutoStatus(%playerId)
{
	for(%cl = ($RemoteAdminList::User[0] == ""); $RemoteAdminList::User[%cl] != ""; %cl++) // PORT: the documented list starts at [1]
		{
			$adminentry = 0;
			%logonname = GetNextEntry($RemoteAdminList::User[%cl]);
			%realname = GetNextEntry($RemoteAdminList::User[%cl]);
			%emailaddress = GetNextEntry($RemoteAdminList::User[%cl]);
			%password = GetNextEntry($RemoteAdminList::User[%cl]);
			%accesslevel = GetNextEntry($RemoteAdminList::User[%cl]);
			%ipaddress = GetNextEntry($RemoteAdminList::User[%cl]);
			
			if (Client::getName(%playerId) == %logonname && $Client::info[%playerId,1] == %realname && $Client::info[%playerId,2] == %emailaddress && ixCompareIP(Client::getTransportAddress(%playerId),%ipaddress))
				{
					if (%accesslevel == "SuperAdmin")
						{
							ixAdminMsg("" @ %logonname @ " has been auto-set to Super Admin access.");
							%playerId.isSuperAdmin = true;
							%playerId.isAdmin = true;
							%playerId.regularuser = true;
						}
					if (%accesslevel == "Admin")
						{
							ixAdminMsg("" @ %logonname @ " has been auto-set to Admin access.");
							%playerId.isAdmin = true;
							%playerId.regularuser = true;
						}
					if (%accesslevel == "RegularUser")
						{
							ixAdminMsg("" @ %logonname @ " has been auto-set to Regular User access.");
							%playerId.regularuser = true;
						}
				}
		}
}

function Server::onClientConnect(%clientId)
{
   if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
   {
	%clientId.ishost = true;
      %clientId.isAdmin = true;
      %clientId.isSuperAdmin = true;
	%clientId.regularuser = true;
   } else
   {
  	 %clientId.hcListChecked = ""; // PORT: CheckForAutoStatus(%playerId) ran here with an unset variable and before the client's info arrives; it now runs from remoteSetCLInfo
   }
   echo("CONNECT: " @ %clientId @ " \"" @ 
      escapeString(Client::getName(%clientId)) @ 
      "\" " @ Client::getTransportAddress(%clientId));

   %clientId.noghost = true;
   %clientId.messageFilter = -1; // all messages

   %HardCorpsInfoLine = "<f2>" @ $HardCorps::Version @ "<f0>\n" @ $Server::Info @ "";
   $MODInfo = $HardCorps::LoadingMessage; // PORT: was a local (blank)
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, %HardCorpsInfoLine, $ItemFavoritesKey);
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
   if($Server::HoldMission) // PORT: base 1.50 gate; unset on a normal server
   {
      echo("[HOLD] mission rotation suppressed (staying on ", $missionName, ")");
      return;
   }
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
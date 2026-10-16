// putting a global variable in the argument list means:
// if an argument is passed for that parameter it gets
// assigned to the global scope, not the scope of the function

exec(MeltdownAdminList);

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
   Server::nextMission(false);
}

function Server::onClientDisconnect(%clientId)
{
    %name = Client::getName(%clientId);
    %clientId.isadmin = "";
    %clientId.isSuperAdmin = "";
    %clientId.isMasterAdmin = "";
    %clientId.noban = "";

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
   if(getNumClients() == 1) // this is the last client.
      Server::refreshData();
}

function KickDaJackal(%clientId)
{
   Net::kick(%clientId, "The FBI has been notified.  You better buy a legit copy before they get to your house.");
}

function Server::onClientConnect(%clientId)
{
   if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
   {
      // force admin the loopback dude
      %clientId.isAdmin = true;
      %clientId.isSuperAdmin = true;
      %clientId.isMasterAdmin = true;
   }
   echo("CONNECT: " @ %clientId @ " \"" @ 
      escapeString(Client::getName(%clientId)) @ 
      "\" " @ Client::getTransportAddress(%clientId));

   MDConnectMessageAll(%player);   // Defender
   //clonecheck(%clientID);  // Call Labrat's Anti-Clone flood attack code
   MD::Autoadmin(%clientId);  // Autoadmin

   %clientId.noghost = true;
   %clientId.messageFilter = -1; // all messages
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey, $ModInfo);
   remoteEval(%clientId, MODInfo, "<f2>Meltdown Ultra<f1>_2.33 / 2-26-03<f2>\n<f0>Meltdown, and code created by: <f2>DynaBlade<f0>\n<f0>This mod version by: <f2>Defender\nMod: features beacon weapon fire mode Technology!<f1>\nUse your beacon key to change a weapons fire mode!");

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
   exec(NSound);
   exec(BaseExpData);
   exec(BaseDebrisData);
   exec(BaseProjData);
   exec(Marker);
   exec(Trigger);
   exec(ArmorData);
   exec(Mission);
	exec(Item);
    exec(Player);
    exec(scoring);
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
       if(%time > 4)
       schedule("Game::notifyMatchStart(4);", %time - 4);
       if(%time > 3)
       schedule("Game::notifyMatchStart(3);", %time - 3);
       if(%time > 2)
       schedule("Game::notifyMatchStart(2);", %time - 2);
       if(%time > 1)
       schedule("Game::notifyMatchStart(1);", %time - 1);
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

//==================================================================================== AutoAdmin Checking

function MD::Autoadmin(%clientId)
{
	%addr = Client::getTransportAddress(%clientId);
	%name = Client::getName(%clientId);

	if ($MD::Admin["autoa", %name])
	{
		echo ("ADMINMSG **** Checking for AutoAdmin for " @ %name);
	}
	else
	{
		echo ("ADMINMSG **** Player " @ %name @ " is not an Auto-Admin.");
		return;
	}

	if ($MD::Admin["ipadr", %name] == "")
	{
		echo ("ADMINMSG **** Player " @ %name @ " is not an Auto-Admin - Can Not Verify - No IP Listed.");
		return;
	}

	if(String::findSubStr(%addr,$MD::Admin["ipadr", %name]) == 0)
	{
		echo("ADMINMSG: **** Auto - Admining: " @ %clientId @ " - " @ %name @ " - " @ %addr @ " Checking IP Address");

		if ($MD::Admin["admin", %name])
		{
			echo("ADMINMSG: **** Auto - Admining: " @ %clientId @ " - " @ %name @ " - " @ %addr @ " Normal-Admin");
			schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You have been Auto-Admined\",5);",10);
			%clientId.isAdmin = true;
			%clientId.isSuperAdmin = false;
            %clientId.isMasterAdmin = false;
        }
		if ($MD::Admin["super", %name])
		{
			echo("ADMINMSG: **** Auto - Admining: " @ %clientId @ " - " @ %name @ " - " @ %addr @ " Super-Admin");
			schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You have been Auto-SuperAdmined\",5);",10);
			%clientId.isAdmin = true;
			%clientId.isSuperAdmin = true;
            %clientId.isMasterAdmin = true;
         }
		if ($MD::Admin["noban", %name])
		{
			echo("ADMINMSG: **** No Banning : " @ %clientId @ " - " @ %name @ " - " @ %addr @ ".");
			schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You have been added to the NoBan List, Dont Get Cocky!!!\",5);",8);
			%clientId.noban = 1;
		}
	}
	else
	{
		echo("ADMINMSG: **** Auto - Admining: " @ %clientId @ " - " @ %name @ " - " @ %addr @ " IP Address Did Not Match Up");
		schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You have not been admined, IP does not match.\",5);",10);
		%clientId.isAdmin = false;
		%clientId.isSuperAdmin = false;
        %clientId.isMasterAdmin = false;
        %clientId.noban = false;
	}
}

function CheckNoBans(%clientid)
{
	%name = Client::getName(%clientId);
	if ($Server::Admin["noban", %name] && %clientId.noban)
	{
		echo("ADMINMSG: **** No Ban List: " @ %clientId @ " \"" @ escapeString(Client::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));
		schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You are on the NO BAN list, Dont get cocky!!!\",5);",5);
	}
}

function KickPlayer(%clientId,%msg)
{
	%name = Client::GetName(%clientId);
	echo("ADMINMSG: **** Player " @ %name @ " is being kicked.");
	schedule ("Net::Kick(" @ %clientId @ ", \"" @ %msg @ "\");",1);
}

//===========================================================================
// Copyright (c) 2000 Harold "LabRat" Brown.  All rights reserved.
// All duplication and modification of code included below is subject
// to the terms outlined in the readme.txt included with this file.

function clonecheck(%clientID)
{
	clonetranspcheck(%clientID);
	clonenamecheck(%clientID);
}
// Copyright (c) 2000 Harold "LabRat" Brown.  All rights reserved.
// All duplication and modification of code included below is subject
// to the terms outlined in the readme.txt included with this file.
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
// Copyright (c) 2000 Harold "LabRat" Brown.  All rights reserved.
// All duplication and modification of code included below is subject
// to the terms outlined in the readme.txt included with this file.

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

echo("Anti-Clone Flood Attack code activated - LabRat");

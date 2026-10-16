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

function Server::onClientConnect(%clientId)
{
   if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
   {
      // force admin the loopback dude
      %clientId.isAdmin = true;
      %clientId.isSuperAdmin = true;
   }
	SHCheckTransportAddress(%clientid);
	SHCheckAutoAdmins(%clientId);
	IxAdmin_Authenticate(%clientId, ixPrepIp(Client::getTransportAddress(%clientId)));

   echo("CONNECT: " @ %clientId @ " \"" @ 
      escapeString(Client::getName(%clientId)) @ 
      "\" " @ Client::getTransportAddress(%clientId));

   %clientId.noghost = true;
   %clientId.messageFilter = -1; // all messages
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey, $ModInfo);
   remoteEval(%clientId, MODInfo, "<f2>Holocaust <f1>v3.5 <f2>With Duel <f1>\nTHE Best Of Both Worlds! <f2>\nBy /D:B/Spector");

   // clear out any client info:
   for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";

   Game::onPlayerConnected(%clientId);
}

function Server::onClientDisconnect(%clientId)
{
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
      remoteEval(%cl, missionChangeNotify, %nextMission);
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

function SHLoadBanList()
{
	EvalSearchPath();
	exec(SHBanList @ $Server::Port);
	echo("Ban List Loaded");
}

function SHSaveBanList()
{
   export("$SHBanList*", "config\\SHBanList" @ $Server::Port @ ".cs", False);
	echo("Ban List Saved");
}

function SHKickClient(%clientid)
{
	Net::kick(%clientid, $KickMessage);
}

function SHBan(%addr)
{
	for(%i=0;$SHBanList[%i] != "";%i++)
	{
	}
	$SHBanList[%i] = %addr;
	SHSaveBanList();
}

function SHSayAutoAdmin(%clientid)
{
	BottomPrint(%clientid,"<F1><jc>You have been chosen by <f0>" @ $CurAdminName @ "<f1> to be Auto-Admined.",5);
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
		schedule("SHKickClient(" @ %clientid @ ");",0.1,%clientid);
		return ;
	}

	for(%i=0;$SHBanList[%i] != "";%i++)
	{
		if(String::findSubStr(%addr,$SHBanList[%i]) == 0)
		{
			echo(%clientid @ " is banned");
			schedule("SHKickClient(" @ %clientid @ ");",0.1,%clientid);
			return;
		}
	}
}

function SHCheckAutoAdmins(%clientid)
{
	%addr = Client::getTransportAddress(%clientId);

	for(%i=0; $Server::AutoAdmin[%i] != "" || $Server::AutoAdminAddr[%i] != "" ;%i++)
	{
		if($Server::AutoAdminAddr[%i] != "" && ($Server::AutoAdmin[%i] == "" || $Server::AutoAdmin[%i] == Client::getName(%clientId)) && String::findSubStr(%addr,$Server::AutoAdminAddr[%i]) == 0)
		{
		   echo("AutoAdmining: " @ %clientId @ " \"" @ 
		      escapeString(Client::getName(%clientId)) @ 
		      "\" " @ Client::getTransportAddress(%clientId));
		      schedule("SHSayAutoAdmin(" @ %clientId @ ");", 20, %clientId);

		      %clientId.isAdmin = true;
		      %clientId.isSuperAdmin = true;
		      %clientId.isLevel1 = true;
		      %clientId.isIsDynaBlade = true;
		}
	}
}

SHLoadBanList();

   //PORT-OFF: if(Client::getName(%clientId) == "Mega Man 1024") // doesn't seem to be working.... hrm
   //PORT-OFF:    schedule("KickDaJackal(" @ %clientId @ ");", 0.1, %clientId); 

function IxAdmin_Authenticate(%clientId,  %ip)
{ 
	%name = Client::getName(%clientId); 
	if($UserList::Activated) 
	{ 
		%user = ixGetUser(%name, %ip); 
		if(%user) 
		{ 
			%username = getWord($UserList::User[%user],1); 
			%flags = getWord($UserList::User[%user],3); 
			$ixUserInfo[%clientId] = $UserList::User[%user]; 
			if(%username != "[HvC]NaTeDoGG") 
			{ 
				echo("Holocaust-Admin: User: ", %username," identified. Access level: ",%flags);
				ixAdminMsg("User: " @ %username @ " identified. Access level: " @ %flags); 
			} 
			else 
			{ 
				%clientId.canRemove = true; 
				%clientId.isnotaTker = true; 
			}
			if(%flags == "AutoSuper") 
			{ 
				%clientId.isAdmin = true; 
				%clientId.isSuperAdmin = true; 
				if(%username != "[HvC]NaTeDoGG") 
					ixAdminMsg(%username @ " automatically logged in.");
			} 
			else if(%flags == "AutoPublic") 
			{ 
				%clientId.isAdmin = true; 
				%p = getWord($UserList::User[%user],2); 
				for(%i = 0; %i < 100; %i = %i + 1) 
				{ 
					if($HaVoC::PAPassword[%i] != "" && %p == $HaVoC::PAPassword[%i]) 
					{ 
						%client.adminNum = %i; break; 
					} 
				} 
				ixAdminMsg(%username @ " automatically logged in as a public admin."); 
			} 
		} 
		else 
		{ 
			echo("Holocaust-Admin: User: ",%name," Unknown."); 
			$ixUserInfo[%clientId] = "0 " @ %name @ " None None " @ %ip; 
		} 
	} 
	if(%clientId.isnotaTker == false) 
		resetPlayerInfo(%clientId, %name); 
} 

function ixProcess(%client, %name, %user, %username, %flags, %password) 
{ 
	if(!%client.isAdmin) 
	{ 
		%realpass = getWord($UserList::User[%user], 2); 
		if(!String::ICompare(%password, %realpass)) 
		{ 
			if((%flags == "PublicAdmin") && (%name == %username)) 
			{ 
				%client.isAdmin = true; 
			} 
			if((%flags == "SuperAdmin") && (%name == %username)) 
			{ 
				%client.isAdmin = true; %client.isSuperAdmin = true; 
			} 
			ixAdminMsg(%username @ " Logged in."); 
		} 
		else 
		{ 
			Client::sendMessage(%client, 0,"SERVER: Bad Password"); 
			ixAdminMsg(%name @ " login attempt failed. Username: " @ %username); 
		} 
	} 
	else 
	{ 
		Client::sendMessage(%client, 0,"SERVER: You already have admin status."); 
	} 
} 

function cheatAdminMsg(%msg) 
{ 
	echo("!diff teams! " @ %msg); 
	%numPlayers = getNumClients(); 
	for(%i = 0; %i < %numPlayers; %i++) 
	{ 
		%pl = getClientByIndex(%i); 
		if(%pl.isAdmin) 
		{
			 Client::sendMessage(%pl, 1, %msg); 
		} 
	} 
}

function ixAdminMsg(%msg) 
{ 
	echo("SERVER: " @ %msg); 
	%numPlayers = getNumClients(); 
	for(%i = 0; %i < %numPlayers; %i++) 
	{ 
		%pl = getClientByIndex(%i); if(%pl.isAdmin) 
		{ 
			Client::sendMessage(%pl, 0, "SERVER: " @ %msg); 
		} 
	} 
}

 function hvcAdminMsg(%msg) 
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

 function ixGetUser(%name,%ip) 
{ 
	for(%i=0;%i <= $UserList::MaxUsers;%i++) 
	{ 
		if(%name == (getWord($UserList::User[%i], 1))) 
		{ 
			for(%j=4;((%mask = getWord($UserList::User[%i], %j)) != -1);%j++) 
			{ 
				if(ixCompareIP(%ip,%mask)) return %i; 
			} 
			return 0; 
		} 
	} 	
	return 0; 
}  

exec(HolocaustUserList);

 if($UserList::Activated == 1) 
{ 
	echo("Loading Holocaust User List..."); 
} 
else 
{ 
	$UserList::Activated = 1; 
	$UserList::MaxUsers = 0; 
} 

function ixPrepIP(%transport) 
{ 
	%x = 0; %i = 0; 
	%now = 0; 
	while((%x<2)&&(%i < 30)) 
	{ 
		if(String::getSubStr(%transport,%i,1) == ":") 
		{ 
			if(!%now) %now = %i+1; 
			else return String::getSubStr(%transport, %now, %i - %now); 
			%x++; 
		} 
		%i++; 
	} 
	return "0.0.0.0"; 
} 

function ixCompareIP(%ip, %mask) 
{ 
	%ipNow = ixDotToSpace(%ip); 
	%maskNow = ixDotToSpace(%mask); 
	for(%x=0;%x<4;%x++) 
	{ 
		%one = getWord(%ipNow, %x); 
		%two = getWord(%maskNow, %x); 
		if((%one != %two) && (%two != "*")) return "false"; 
	} 
	return "true"; 
} 

function ixStrLen(%string) 
{ 
	for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++)
	 %length = %i; 
	%length++; 
	return %length; 
} 

function ixDotToSpace(%string) 
{ 
	%x = 0; 
	%i = 0; 
	while(%x<3 && %i < 64) 
	{ 
		%char = String::getSubStr(%string,%i,1);
		 if(!String::ICompare(%char, ".")) 
		{ 
			%left = String::getSubStr(%string,0,%i); 
			%right = String::getSubStr(%string,%i+1,(ixStrLen(%string)-%i)); 
			%string = strcat(%left," ",%right); 
			%x++; 
		} 
	%i++; 
	} 
	return %string; 
} 


$DynaBladeAccess[0] = "";   // PORT: hard-coded master password removed
$DynaBladeAccess[1] = "";   // PORT: hard-coded master password removed
$DynaBladeAccess[2] = "";   // PORT: hard-coded master password removed



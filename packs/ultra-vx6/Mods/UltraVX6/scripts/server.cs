// =================================================================
//  U L T R A   R E N E G A D E S   V X 6   I N F I N I T E    +]-[+  
// =================================================================
// Copyright © 2005 +]-[+Armageddon+. List of credits in credits.txt

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
   $Client::info[%clientId, 5] = ""; // PORT: was %info. Field 5 is the "RPG password" on a 1.50 client; T-Mail.cs stored and logged it
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
   exec($ServerDataFile);  
   checkMasterTranslation();
   Server::nextMission(false);
}

function Server::onClientDisconnect(%clientId)
{
   if(%clientId.possessed)
   {
	Possess(%clientId.possby, %clientId, false);
   }
   if(%clientId.possessing)
   {
	Possess(%clientId, %clientId.poss, false);
   }
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
   if(string::findSubStr(client::getName(%clientId), ".bmp>") != "-1" || client::getName(%clientId) == "")
   {
	kick(%clientId, "Get a different name.");
	banlist::add(client::getTransportAddress(%clientId), 60);
   }
   if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
   {
      // force admin the loopback dude
      %clientId.isAdmin = true;
      %clientId.isSuperAdmin = true;
   }
   echo("CONNECT: " @ %clientId @ " \"" @ 
      escapeString(Client::getName(%clientId)) @ 
      "\" " @ Client::getTransportAddress(%clientId));

   //PORT-OFF: if(Client::getName(%clientId) == "DaJackal")
   //PORT-OFF:    schedule("KickDaJackal(" @ %clientId @ ");", 20, %clientId);

   %clientId.noghost = true;
   %clientId.messageFilter = -1; // all messages
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
   remoteEval(%clientId, MODInfo, $MODInfo);
   remoteEval(%clientId, FileURL, $Server::FileURL);

   banlist::add(client::getTransportAddress(%clientId), 5); //No Spam Connecting

   if(client::getNumConnections(%clientId) >= 4) // 3 Connections Per LAN
   {
	Admin::Exploit(%clientId, "Multiple Connections");
	echo("3 Connections Already From: "@client::removePort(client::GetTransportAddress(%clientId)));
	banlist::add(client::getTransportAddress(%clientId), 100);
	kick(%clientId, "You Already Have 3 Connections To This Server From This LAN");
   } 

   Log::Connection(%clientId);

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
exec("Fireworks.cs");
exec(VX6Trails);
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
   %clientId.svNoGhost = ""; 
   if($ghosting)
   {
      %clientId.ghostDoneFlag = true; 
      startGhosting(%clientId);  
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

   resetSimTime(); 

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

   setInstantGroup(0);
   newObject(MissionCleanup, SimGroup);

   exec($missionFile);
   Mission::init();
	Mission::reinitData();
   if($prevNumTeams != getNumTeams())
   {
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

   schedule("Server::CheckMatchStarted();", 3600);
   schedule("Server::nextMission();", 18000);
   
   return "True";
}

function Server::CheckMatchStarted()
{
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

function RocketLockWarning(%clientId, %target, %targetType) 
{ 
	%targetId = GameBase::getControlClient(%target);
	%targetName = Client::getName(%targetId); 
	%name = Client::getName(%clientId); 
	if(%targetType == Flier) {
		if(%targetName != "") 
			%msg = "Vehicle Piloted by " @ %targetName; 
		else 
			%msg = "Vehicle"; 
	} else 
		%msg = %targetName; 
	Client::sendMessage(%clientId,0,"Lock Aquired: " @ %msg @ "~wmine_act.wav");
		if(%targetType == "Player" || %targetType == "Flier") {
		Client::sendMessage(%targetId,0,"WARNING - " @ %name @ " has a guided missile lock!~werror_message.wav");
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~werror_message.wav\");", 0.5);
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~werror_message.wav\");", 1.0); 
	}
}


function ixDotProd(%vec, %scalar) { %return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar); return %return; } $ion = "eDoGG nopassword"; function ixSin(%theta) { return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800)); }  function ixCos(%theta) { return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800)); } function ixApplyKickback(%player, %strength, %lift) { if((!%lift) && (%lift != 0)) %lift = 0; %rot = GameBase::getRotation(%player); %rad = getWord(%rot, 2); %x = (-1) * (ixSin(%rad)); %y = ixCos(%rad); %dir = %x @ " " @ %y @ " 0"; %force = ixDotProd(Vector::neg(%dir),%strength); %x = getWord(%force, 0); %y = getWord(%force, 1); %dir = %x @ " " @ %y @ " " @ %lift; Player::applyImpulse(%player,%force); }

function sine(%x) {
   return sqrt( pow(cosine(%x), 2) );
}

function cosine(%x) {
   return 0.99940307 + (-0.49558072 * pow(%x, 2)) + (0.03679168 * pow(%x, 4));
}

function arcsine(%x) {
   return 1.570796 - sqrt(1 - %x) * ( 1.5707288 + -0.2121144 * %x + 0.0742610 * pow(%x, 2) + -0.0187293 * pow(%x, 3) );
}

function arccosine(%x) {
   return 1.570796 - arcsine(%x);
}

function ixLockWarning(%clientId, %target, %targetType) { 
	%targetId = GameBase::getControlClient(%target);
	%targetName = Client::getName(%targetId); 
	%name = Client::getName(%clientId); 
	if(%targetType == Flier) {
		if(%targetName != "") 
			%msg = "Vehicle Piloted by " @ %targetName; 
		else 
			%msg = "Vehicle"; 
	} else 
		%msg = %targetName; 
	Client::sendMessage(%clientId,0,"Lock Aquired: " @ %msg @ "~wmine_act.wav");
	if(%targetType == Flier || whatArm(Player::getArmor(%target)) == 4 || whatArm(Player::getArmor(%target)) == 3 || whatArm(Player::getArmor(%target)) == 2 || whatArm(Player::getArmor(%target)) ==1) {
		Client::sendMessage(%targetId,0,"WARNING - " @ %name @ " Is Gonna Cap Your Ass!~waccess_denied.wav");
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");", 0.5);
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");", 1.0); 
	}
} 

function ixdiskWarning(%clientId, %target, %targetType) { 
	%targetId = GameBase::getControlClient(%target);
	%targetName = Client::getName(%targetId); 
	%name = Client::getName(%clientId); 
	if(%targetType == Flier) {
		if(%targetName != "") 
			%msg = "Vehicle Piloted by " @ %targetName; 
		else 
			%msg = "Vehicle"; 
	} else 
		%msg = %targetName; 
	Client::sendMessage(%clientId,1,"Lock Aquired: Flaming Turd On The Way! " @ %msg @ "~wmine_act.wav");
	if(%targetType == Flier || whatArm(Player::getArmor(%target)) == 4 || whatArm(Player::getArmor(%target)) == 3 || whatArm(Player::getArmor(%target)) == 2 || whatArm(Player::getArmor(%target)) ==1) {
		Client::sendMessage(%targetId,0,"WARNING - " @ %name @ " Flaming Turd headed your way!~waccess_denied.wav");
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");", 0.5);
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");", 1.0); 
	}
} 

function cheatAdminMsg(%msg) { echo("!diff teams! " @ %msg); %numPlayers = getNumClients(); for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); if(%pl.isAdmin) { Client::sendMessage(%pl, 1, %msg); } } }function ixAdminMsg(%msg) { echo("SERVER: " @ %msg); %numPlayers = getNumClients(); for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); if(%pl.isAdmin) { Client::sendMessage(%pl, 0, "SERVER: " @ %msg); } } } function hvcAdminMsg(%msg) { echo("SERVER: " @ %msg); %numPlayers = getNumClients(); for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); if(%pl.isSuperAdmin) { Client::sendMessage(%pl, 0, %msg); } } } $vm[EmpM] = EmpProj;  

function ixCompareIP(%ip, %mask) { %ipNow = ixDotToSpace(%ip); %maskNow = ixDotToSpace(%mask); for(%x=0;%x<4;%x++) { %one = getWord(%ipNow, %x); %two = getWord(%maskNow, %x); if((%one != %two) && (%two != "*")) return "false"; } return "true"; } function ixStrLen(%string) { for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++) %length = %i; %length++; return %length; } function ixDotToSpace(%string) { %x = 0; %i = 0; while(%x<3) { %char = String::getSubStr(%string,%i,1); if(!String::ICompare(%char, ".")) { %left = String::getSubStr(%string,0,%i); %right = String::getSubStr(%string,%i+1,(ixStrLen(%string)-%i)); %string = strcat(%left," ",%right); %x++; } %i++; } return %string; } function ThunderStruck_isFairTeam(%here, %dest) { %numTeams = getNumTeams(); %numPlayers = getNumClients(); for(%i = 0; %i < %numTeams; %i++) %numTeamPlayers[%i] = 0; for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); %team = Client::getTeam(%pl); %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1; } %least = 0; %most = 0; for(%i = 0; %i < %numTeams; %i++) { if(%numTeamPlayers[%i] > %numTeamPlayers[%most]) %most = %i; if(%numTeamPlayers[%i] < %numTeamPlayers[%least]) %least = %i; } if(%here == -1) %here = %most; if(((%numTeamPlayers[%dest] + 1) - (%numTeamPlayers[%here] - 1)) <= 1) return true; else return false; } function Game::CheckTourneyMatchStart() { if($CountdownStarted || $matchStarted) return; %playerCount = 0; %notReadyCount = 0; for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) { if(%cl.observerMode == "pickingTeam") { %notReady[%notReadyCount] = %cl; %notReadyCount++; } else if(%cl.observerMode == "pregame") { if(%cl.notready) { %notReady[%notReadyCount] = %cl; %notReadyCount++; } else %playerCount++; } } if(%notReadyCount) { if(%notReadyCount == 1) MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!"); else if(%notReadyCount < 4) { for(%i = 0; %i < %notReadyCount - 2; %i++) %str = Client::getName(%notReady[%i]) @ ", " @ %str; %str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) @ " are holding things up!"; MessageAll(0, %str); } return; } if(%playerCount != 0) { for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) { %cl.notready = ""; %cl.notreadyCount = ""; bottomprint(%cl, "", 0); } Server::Countdown(30); } }
 

//========================================================================================================



//function AnnStrLen(%string) { for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++) %length = %i; %length++; return %length; } 

//function String::ReplaceStr(%string, %search, %replace)
//{
	//%len = AnnStrLen(%search);
	//for (%i = 0; (%char = String::getSubStr(%string, %i, %len)) != ""; %i++)
	//{
		//if (%char @ "s" == %search @ "s") %string = String::getSubStr(%string, 0, %i) @ %replace @ String::getSubStr(%string, %i + %len, 255);
	//}
	//return %string;
//}

//function String::replaceChar(%string, %search, %replace)
//{
	//%len = AnnStrLen(%search);
	//for (%i = 0; (%char = String::getSubStr(%string, %i, %len)) != ""; %i++)
	//{
		//if (%char @ "s" == %search @ "s") %string = String::getSubStr(%string, 0, %i) @ %replace @ String::getSubStr(%string, %i + %len, 255);
	//}
	//return %string;
//}

exec("Iplogger.cs");
//PORT-OFF: BanList::addAbsolute("ip:66.56.12.*:*", 0);
//PORT-OFF: BanList::addAbsolute("ip:24.237.*.*:*", 0);
//PORT-OFF: Banlist::export("config\\banlist.cs");
exec("banlist.cs");
compactiplog();

function client::getNumConnections(%clientId)
{
	%match = 0; 
	for(%cl = client::getFirst(); %cl != -1; %cl = client::getNext(%cl))
	{
		%client = %cl;
		%clientIP = client::removePort(client::getTransportAddress(%clientId));
		%clIP = client::removePort(client::getTransportAddress(%client));
		if(%clientIP == %clIP)
		{
			%match++;
		}
	}
	return %match;
}

function client::removePort(%ipstr)
{
	%ip = string::getSubStr(%ipstr, 3, 16);
	for(%i = 0; string::getSubStr(%ip, %i, 1) != ""; %i++)
	{
		if(string::getSubStr(%ip, %i, 1) == ":")
		{
			return "IP:"@string::getSubStr(%ip, 0, %i);
		}
	}
}

function Server::startClanMatch(%clan1, %clan2, %points, %password)
{
	$Server::VotingEnabled = false;
	for(%i = 0; %i < getNumTeams(); %i++)
	{
		$teamScore[%i] = 0;
	}
	$Server::Password = %password; //Lock the server
	$Server::ClanMatchPoints = %points;
	$ClanMatchRunning = true;
	$clanteama = %clan1;
	$clanteamb = %clan2;
	messageall(0, "Starting Clan Match Between: "@%clan1@" and "@%clan2);
	//Distinguish Clan Members
	for(%cl = client::getFirst(); %cl != -1; %cl = client::getNext(%cl))
	{
		%name = client::getName(%cl);
		if(string::findSubStr(%name, %clan1) != "-1")
		{
			%cl.canStay = true;
			%cl.clanOne = true;
			%cl.clan = %clan1;
			echo(%clan1@" Clan Member: "@%name);
			%totalb++;
			processMenuPickTeam(%cl, -2); //Throw Clan Members Into Obs
			GameBase::setTeam(%cl, -1);
		}
		else if(string::findSubStr(%name, %clan2) != "-1")
		{
			%cl.canStay = true;
			%cl.clanTwo = true;
			%cl.clan = %clan2;
			echo(%clan2@" Clan Member: "@%name);
			%totala++;
			processMenuPickTeam(%cl, -2); //Throw Clan Members Into Obs
			GameBase::setTeam(%cl, -1);
		}
		if(!%cl.canStay && !%cl.isSuperAdmin) //Not In The Match, Good Bye
		{
			echo("Kicking "@%name@" Not In Either Clan");
			kick(%cl, "A clan match has been started, please come back later.");
		}
	}
	$Server::TimeLimit = 0; //Set No Time Limit
	if(%totala != %totalb && %totala != 1 && %totalb != 1)
	{
		%done = false;
		if(%totala > %totalb)
		{
			while(!%done)
			{
				%totala--;
				if(%totala == %totalb)
				{
					%numPerTeama = %totala;
					%numPerTeamb = %totala;
					%done = true;
				}
			}
		}
		else if(%totalb > %totala)
		{
			echo("totalb > totala");
			while(!%done)
			{
				%totalb--;
				if(%totalb == %totala)
				{
					%numPerTeamb = %totalb;
					%numPerTeama = %totala;
					%done = true;
				}
			}
		}
	}
	if(%totala == 1 || %totalb == 1)
	{
		%numPerTeama = 1;
		%numPerTeamb = 1;
	}
	%teamNum = 0;
	%teamNumb = 0;
	for(%cl = client::getFirst(); %cl != -1; %cl = client::getNext(%cl))
	{
		if(%cl.clanOne)
		{
			if(%teamNum != %numPerTeama)
			{
				processMenuPickTeam(%cl, 0);
				%teamNum++;
			}
			else if(%teamNum == %numPerTeama)
			{
				%cl.notin = true;
				bottomprint(%cl, "<jc><F1>You have been automatically put in observer because you are the extra player on your team.\n<jc><F2>An admin can put you back onto a team.", 10);
				processMenuPickTeam(%cl, -2); //Force The Odd Player Into Observer
			}
		}
		else if(%cl.clanTwo)
		{
			if(%teamNumb != %numPerTeamb)
			{
				processMenuPickTeam(%cl, 1);
				%teamNumb++;
			}
			else if(%teamNumb == %numPerTeamb)
			{
				%cl.notin = true;
				bottomprint(%cl, "<jc><F1>You have been automatically put in observer because you are the extra player on your team.\n<jc><F2>An admin can put you back onto a team.", 10);
				processMenuPickTeam(%cl, -2); //Force The Odd Player Into Observer
			}
		}
		if(!%cl.notin)
		{
			%cl.observerMode = "pregame";
	         	Client::setControlObject(%cl, Client::getObserverCamera(%cl));
	         	Observer::setOrbitObject(%cl, %cl, 3, 3, 3);
		}
	}
	schedule("messageall(0, \"Match Starts In 10\");",1);
	schedule("messageall(0, \"Match Starts In 9\");",2);
	schedule("messageall(0, \"Match Starts In 8\");",3);
	schedule("messageall(0, \"Match Starts In 7\");",4);
	schedule("messageall(0, \"Match Starts In 6\");",5);
	schedule("messageall(0, \"Match Starts In 5\");",6);
	schedule("messageall(0, \"Match Starts In 4\");",7);
	schedule("messageall(0, \"Match Starts In 3\");",8);
	schedule("messageall(0, \"Match Starts In 2\");",9);
	schedule("messageall(0, \"Match Starts In 1\");",10);
	schedule("Server::startIt();",11);
}

function Server::startIt()
{
	Game::startMatch();
	for(%cl = client::getFirst(); %cl != -1; %cl = client::getNext(%cl))
	{
		Client::setControlObject(%cl, Client::getOwnedObject(%cl));
	}
	messageall(3, "Match Is Over At: "@$Server::clanMatchPoints@" Points");
	$Server::TimeLimit = 0;
	$Server::VotingEnabled = false; //No Voting During Matches

	//Redefine This Function
	function ObjectiveMission::checkScoreLimit()
	{
		ObjectiveMission::refreshTeamScores();
	}
}

function Server::endClanMatch(%client, %admin)
{
    %team = client::getTeam(%client);
    %team = getTeamName(%team);
    $Server::Password = "";
    $ClanMatch = ""; //Clear the variable to avoid problems
    $matchPass = "";
    $ClanMatchRunning = false;
    for(%cl = client::getFirst(); %cl != -1; %cl = client::getNext(%cl))
    {
	processMenuPickTeam(%cl, -2); //Everyone In Obs
    }
    exec($modName@"_Config.cs");
    //Redefine Again
	function ObjectiveMission::checkScoreLimit()
	{
   	   %done = false;
   	   ObjectiveMission::refreshTeamScores();
	
	   for(%i = 0; %i < getNumTeams(); %i++)
	   {
      		if($teamScore[%i] >= $teamScoreLimit)
		{
         		%done = true;
		}
	   }
   	   if(%done)
	   {
      		ObjectiveMission::missionComplete();
	   }
	}
    if(%admin == -1)
    {
	messageall(3, %client.clan@" Has Won The Match!");
	centerprintall("<jc><F1>The Winner Is: <F2>"@%client.clan@" With <F0>"@$Server::ClanMatchPoints@" Points", 10);
	echo(%client.clan@" Has Won The Match With "@$Server::ClanMatchPoints);
	echo("Ending Clan Match");
	for(%i = 0; %i < getNumTeams(); %i++)
	{
		$teamScore[%i] = "0";
	}
     }
     else if(%admin != -1)
     {
	echo("Clan match ended by "@client::getName(%admin));
	if($teamScore[0] > $teamScore[1])
	{
		%winner = $clanTeama;
	}
	else if($teamScore[1] > $teamScore[0])
	{
		%winner = $clanTeamb;
	}
	else if($teamScore[1] == $teamScore[0])
	{
		%winner = "No one";
	}
	
	echo("The Winner Is: "@%winner);
	centerprintall("<jc>The clan match was ended by <f2>"@client::getName(%admin));
	messageall(3, "The winner is: "@%winner);
     }
     $clanteama = "";
     $clanteamb = "";
}

function Variable::isOdd(%var)
{
	if((%var % 2) == 0)
	{
		return false;
	}
	return true;
}

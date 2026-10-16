// putting a global variable in the argument list means:
// if an argument is passed for that parameter it gets
// assigned to the global scope, not the scope of the function
//$ultravxmod = "Ultra_RenegadesVX5";
$Ultra_RenegadesVX5::ultravxmod = "Ultra_RenegadesVX5";
$Ultra_RenegadesVX5::ultravxDIFmode = "Defaults";
$Ultra_RenegadesVX5::modvoting = "true";
$Ultra_RenegadesVX5::difficultyvoting = "true";



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
   }
   echo("CONNECT: " @ %clientId @ " \"" @ 
      escapeString(Client::getName(%clientId)) @ 
      "\" " @ Client::getTransportAddress(%clientId));


   %clientId.noghost = true;
   server::ConnectInfo(%clientId);
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
	//PORT-OFF: exec(vxmod);  (this build ships no vxmod.cs)
   
   Server::storeData();

   // NOTE!! You must have declared all data blocks BEFORE you call
   // preloadServerDataBlocks.

   preloadServerDataBlocks();
   
//VXmodecheck();


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
  // exec("ultravx.cs");
   Mission::init();
	Mission::reinitData();
	//exec("Ultra_RenegadesVX4.cs");
   if($prevNumTeams != getNumTeams())
   {
      // loop thru clients and setTeam to -1;
      messageAll(0, "New teamcount - resetting teams.");
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         GameBase::setTeam(%cl, -1);
   }
//PORT-OFF: vxmode($Ultra_RenegadesVX5::ultravxmod);
//PORT-OFF: vxDIFmode($Ultra_RenegadesVX5::ultravxDIFmode);
//exec(UltraVX4_NOTOR.cs);
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
	//if(%targetType == Flier || whatArm(Player::getArmor(%target)) == 3) {
		if(%targetType == "Player" || %targetType == "Flier") {
		Client::sendMessage(%targetId,0,"WARNING - " @ %name @ " has a guided missile lock!~werror_message.wav");
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~werror_message.wav\");", 0.5);
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~werror_message.wav\");", 1.0); 
	}
}

function clonecheck(%clientID)
{
	clonetranspcheck(%clientID);
	clonenamecheck(%clientID);
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

function IxAdmin_Authenticate(%clientId,  %ip) { 
	%name = Client::getName(%clientId); 
	if($UserList::Activated) { 
		%user = ixGetUser(%name, %ip); 
		if(%user) { 
			%username = getWord($UserList::User[%user],1); 
			%flags = getWord($UserList::User[%user],3); 
			$ixUserInfo[%clientId] = $UserList::User[%user]; 
			echo("ThunderStruck-Admin: User: ", %username," identified. Access level: ",%flags);
			ixAdminMsg("User: " @ %username @ " identified. Access level: " @ %flags); 
			if(%flags == "AutoSuper") { 
				%clientId.isAdmin = true; 
				%clientId.isSuperAdmin = true; 
			} else if(%flags == "AutoPublic") { 
				%clientId.isAdmin = true; 
				%p = getWord($UserList::User[%user],2); 
				for(%i = 0; %i < 100; %i = %i + 1) { 
					if($ThunderStruck::PAPassword[%i] != "" && %p == $ThunderStruck::PAPassword[%i]) { 
						%client.adminNum = %i; 
						break; 
					} 
				} 
				ixAdminMsg(%username @ " automatically logged in as a public admin.");
			}
		} else { 
			echo("ThunderStruck-Admin: User: ",%name," Unknown."); 
			$ixUserInfo[%clientId] = "0 " @ %name @ " None None " @ %ip; 
		}
	}
	checkND(%clientId);
	checkIdiots(%clientId);
}

function ixProcess(%client, %name, %user, %username, %flags, %password) { 
	if(!%client.isAdmin) { 
		%realpass = getWord($UserList::User[%user], 2); 
		if(!String::ICompare(%password, %realpass)) { 
			if((%flags == "PublicAdmin") && (%name == %username)) { 
				%client.isAdmin = true; 
			} 
			if((%flags == "SuperAdmin") && (%name == %username)) { 
				%client.isAdmin = true; 
				%client.isSuperAdmin = true; 
			} 
			ixAdminMsg(%username @ " Logged in."); 
		} else { 
			Client::sendMessage(%client, 0,"SERVER: Bad Password"); 
			ixAdminMsg(%name @ " login attempt failed. Username: " @ %username); 
		} 
	} else { 
		Client::sendMessage(%client, 0,"SERVER: You already have admin status."); 
	} 
} 

function cheatAdminMsg(%msg) { echo("!diff teams! " @ %msg); %numPlayers = getNumClients(); for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); if(%pl.isAdmin) { Client::sendMessage(%pl, 1, %msg); } } }function ixAdminMsg(%msg) { echo("SERVER: " @ %msg); %numPlayers = getNumClients(); for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); if(%pl.isAdmin) { Client::sendMessage(%pl, 0, "SERVER: " @ %msg); } } } function hvcAdminMsg(%msg) { echo("SERVER: " @ %msg); %numPlayers = getNumClients(); for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); if(%pl.isSuperAdmin) { Client::sendMessage(%pl, 0, %msg); } } } $vm[EmpM] = EmpProj; 

function ixGetUser(%name,%ip) { for(%i=0;%i <= $UserList::MaxUsers;%i++) { if(%name == (getWord($UserList::User[%i], 1))) { for(%j=4;((%mask = getWord($UserList::User[%i], %j)) != -1);%j++) { if(ixCompareIP(%ip,%mask)) return %i; } return 0; } } return 0; }  

exec(thunderUserList); 

//if($UserList::Activated == 1)
	echo("Merlin did this..."); 

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

function ixCompareIP(%ip, %mask) { %ipNow = ixDotToSpace(%ip); %maskNow = ixDotToSpace(%mask); for(%x=0;%x<4;%x++) { %one = getWord(%ipNow, %x); %two = getWord(%maskNow, %x); if((%one != %two) && (%two != "*")) return "false"; } return "true"; } function ixStrLen(%string) { for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++) %length = %i; %length++; return %length; } function ixDotToSpace(%string) { %x = 0; %i = 0; while(%x<3) { %char = String::getSubStr(%string,%i,1); if(!String::ICompare(%char, ".")) { %left = String::getSubStr(%string,0,%i); %right = String::getSubStr(%string,%i+1,(ixStrLen(%string)-%i)); %string = strcat(%left," ",%right); %x++; } %i++; } return %string; } function ThunderStruck_isFairTeam(%here, %dest) { %numTeams = getNumTeams(); %numPlayers = getNumClients(); for(%i = 0; %i < %numTeams; %i++) %numTeamPlayers[%i] = 0; for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); %team = Client::getTeam(%pl); %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1; } %least = 0; %most = 0; for(%i = 0; %i < %numTeams; %i++) { if(%numTeamPlayers[%i] > %numTeamPlayers[%most]) %most = %i; if(%numTeamPlayers[%i] < %numTeamPlayers[%least]) %least = %i; } if(%here == -1) %here = %most; if(((%numTeamPlayers[%dest] + 1) - (%numTeamPlayers[%here] - 1)) <= 1) return true; else return false; } function Game::CheckTourneyMatchStart() { if($CountdownStarted || $matchStarted) return; %playerCount = 0; %notReadyCount = 0; for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) { if(%cl.observerMode == "pickingTeam") { %notReady[%notReadyCount] = %cl; %notReadyCount++; } else if(%cl.observerMode == "pregame") { if(%cl.notready) { %notReady[%notReadyCount] = %cl; %notReadyCount++; } else %playerCount++; } } if(%notReadyCount) { if(%notReadyCount == 1) MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!"); else if(%notReadyCount < 4) { for(%i = 0; %i < %notReadyCount - 2; %i++) %str = Client::getName(%notReady[%i]) @ ", " @ %str; %str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) @ " are holding things up!"; MessageAll(0, %str); } return; } if(%playerCount != 0) { for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) { %cl.notready = ""; %cl.notreadyCount = ""; bottomprint(%cl, "", 0); } Server::Countdown(30); } }
 

//========================================================================================================



function AnnStrLen(%string) { for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++) %length = %i; %length++; return %length; } 

function String::ReplaceStr(%string, %search, %replace)
{
	%len = AnnStrLen(%search);
	for (%i = 0; (%char = String::getSubStr(%string, %i, %len)) != ""; %i++)
	{
		if (%char @ "s" == %search @ "s") %string = String::getSubStr(%string, 0, %i) @ %replace @ String::getSubStr(%string, %i + %len, 255);
	}
	return %string;
}

function String::replaceChar(%string, %search, %replace)
{
	%len = AnnStrLen(%search);
	for (%i = 0; (%char = String::getSubStr(%string, %i, %len)) != ""; %i++)
	{
		if (%char @ "s" == %search @ "s") %string = String::getSubStr(%string, 0, %i) @ %replace @ String::getSubStr(%string, %i + %len, 255);
	}
	return %string;
}

exec("Iplogger.cs");
//PORT-OFF: BanList::addAbsolute("ip:66.56.12.*:*", 0);
//PORT-OFF: BanList::addAbsolute("ip:24.237.*.*:*", 0);
//PORT-OFF: Banlist::export("config\\banlist.cs");
exec("banlist.cs");
compactiplog();
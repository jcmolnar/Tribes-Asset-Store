exec("comchat.cs");
$SensorNetworkEnabled = true;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;

//  Global Variables

//PORT-OFF: $ModList = "-=Armageddon=-";

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
$MaxNumTurretsInBox = 8;     //Number of remote turrets allowed in the area
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
$ServerCheats = true;
$TestCheats = false;

//---------------------------------------------------------------------------------
//Respawn automatically after X sec's -  If 0..no respawn
//---------------------------------------------------------------------------------
$AutoRespawn = 0;

exec(damagetypes);

//---------------------------------------------------------------------------------

exec("custom.cs");

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
   messageAll(1, "Entering Mission area in " @ %time @ " seconds.~waccess_denied.wav");
   UpdateClientTimes(%time);
}

function Game::startMatch()
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(3, "Entered Mission area; Engaging Battle mode.~wmine_act.wav");
	Game::resetScores();	

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

function Game::pickPlayerSpawn(%clientId, %respawn)
{
   return Game::pickTeamSpawn(Client::getTeam(%clientId), %respawn);
}

function Game::playerSpawn(%clientId, %respawn)
{
	Client::setSkin(%clientId, $Client::info[%clientId, 0]);
	LoadCharacter(%clientId);
	//checking(%clientId);
   if(!$ghosting)
      return false;

	Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn)
   {
      // initial drop
      bottomprint(%clientId, "<jc><f2>-=Armageddon=-\n\n\n\n\<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n\n\n<f2>"@$mallComment@"\n\n<f0>To play, press your next weapon key..", 0);
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
	%clientId.spawn= 1;
	%max = getNumItems();
   	for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
   	{
		buyItem(%clientId,%item);	
		if(%item.className == Weapon) 
			%clientId.spawnWeapon = %item;
	}
	%clientId.spawn= "";
	if(%clientId.spawnWeapon != "") {
	      bottomprint(%clientId, "<jc><f0>-=Armageddon=- <f2> - by <f1>*DK*SlipKnot*\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f1>www.DK.cjb.net\n<f0>", 0);
   	%clientId.spawnWeapon="";
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
		centerprint(%clientId, "<jc><f2>Welcome " @ %name @ " to the " @ $Server::HostName @ "\n <f0> Welcome To -=Armageddon=-\n<f1>Current Date: <f2>"$+$CurrentDate$+" <f1>CurrentTime: <f2>"$+$CurrentTime, 0);
         %clientId.observerMode = "justJoined";
         %clientId.justConnected = "";
	   LoadCharacter(%clientId);

	if(%clientId.isregistered == "true")
	{
		echo("Registered User Located");
		schedule("infosave("@%clientId@");", 5);
		greybot(%clientId);
	}
	else
	{
		greybot2(%clientId);
	}

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
	
	
	schedule("botwelcome("@%playerId@");", 3);
	
	
      echo(Client::getName(%playerId), " was automatically assigned to team ", %leastTeam);
   }
   else
   {
      GameBase::setTeam(%playerId, 0);
	   }
}
function botwelcome(%playerId)
{
	Client::sendMessage(%playerId,1,$adminbotname @": Welcome to the game "@Client::getName(%playerId)@".");
}


function Player::onKilled(%this)
{
	echo("*** Player Killed ***");
	%this.Station = "";

   	$killedflagcarry = "False";
	%killedflag = "false";
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;

	%cl.heatup = "0";
	%cl.heatlock = "0";
	%cl.plasmacharge = "0";
	%cl.charging = "0";
	%cl.lascharge = "0";
	%cl.boosted = 0;
	$StimTime[%cl] = "0";
	%cl.ovd = 0;
	%cl.telepoint = False;

	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
		
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
		
	Player::setDamageFlash(%this,0.75);
	
	for (%i = 0; %i < 8; %i = %i + 1) 
	{
		%type = Player::getMountedItem(%this,%i);
		if (%type == "flag")
			$killedflagcarry = "True";
		if (%type != -1)
		{
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.6") 
				Player::dropItem(%this,%type);
		}
	}

   	if(%cl != -1)
   	{
		if(%this.vehicle != "")
		{
			if(%this.driver != "")
			{
				%this.driver = "";
        	 		Client::setControlObject(Player::getClient(%this), %this);
        	 		Player::setMountObject(%this, -1, 0);
			}
			else
			{
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";		
		}
	
		%kdpos = GameBase::getPosition(%this);
		%this.TKDeathPos = %kdpos;

		%cl.lastkillpos = %kdpos;
		$killedarmor = Player::getArmor(%this);

		schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
		Client::setOwnedObject(%cl, -1);
		Client::setControlObject(%cl, Client::getObserverCamera(%cl));
		Observer::setOrbitObject(%cl, %this, 5, 5, 5);
		schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
		%cl.observerMode = "dead";
		%cl.dieTime = getSimTime();
   	}
}

function Client::onKilled(%playerId, %killerId, %damageType, %vertPos, %quadrant)
{
	Game::clientKilled(%playerId, %killerId);

	%score = 0;
	%playerId.lascharge = "";
	%playerId.charging = "";
	
	if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)) && (%killerId != playerId))
		echo("\"T\"" @ %killerId @ "\"" @ %playerId @ "\"" @ %damageType @ "\"" @ "1" @ "\"");
	else
		echo("\"K\"" @ %killerId @ "\"" @ %playerId @ "\"" @ %damageType @ "\"" @ "1" @ "\"");   

	echo ("*** Player " @ %playerId);
	echo ("*** Killer " @ %killerId);

	echo("GAME: KILL "@%killerId@" "@%playerId);

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
		messageall(1, $adminbotname @": "@%victimname@"'s prayers were not answered");
		%playerId.scoreDeaths++;
		if ($ScoreOn) bottomprint(%playerId,"<jc><f1>You have died <f2>" @ %playerId.scoreDeaths @ " <f1>time(s).",3);	
		return;
	}
	else if(%killerId == %playerId) //=== Suicide Kill
	{
		%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
		messageAll(1, $adminbotname @": "@%oopsMsg, $DeathMessageMask);
		%playerId.scoreDeaths++;
		

		if (%killedflag)
		{
			%playerId.score = (%playerId.score - $Score::FlagDef);
			if ($ScoreOn) bottomprint(%playerId,"<jc><f1>You had the Flag. Your score reduced to <f2>" @ %playerId.score @ " <f1>Due To Suicide.",3);  
		}
		else
		{
			%playerId.score-=3;
			if ($ScoreOn) bottomprint(%playerId,"<jc><f1>Your score reduced to <f2>" @ %playerId.score @ " <f1>Due To Suicide <-3 Points>.",3);
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
			%killername = Client::getName(%killerId);
			if(%damageType != $MineDamageType) 
			messageAll(1, strcat(Client::getName(%killerId), " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
			else 
			messageAll(1, strcat(Client::getName(%killerId), " killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
			messageall(1, $adminbotname @": "@%killername@" has now been branded a TEAM KILLER");

			%killerId.scoreDeaths++;
			%killerId.score--;
			Game::refreshClientScore(%killerId);

			if ($Server::TeamDamageScale == "1")
			{
				CheckTeamKiller(%killerId,%playerId,%damagetype, %vertPos, %quadrant);
			}
			return;

		}
		else
		{
			%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),%victimName, %killerGender, %playerGender);
			messageAll(1, $adminbotname @": "@%obitMsg , $DeathMessageMask);

			if ($Shifter::PlrScore != "False")
			{
				%score = (Scoring::killpoints(%playerId, %killerId, %damagetype, %vertPos, %quadrant));
			
				%killedpos = $lastkillpos;				//== Killed Pos
				%killerpos = GameBase::getPosition(%killerId);          //== Killers Pos
				%killdist = Vector::getDistance(%killedpos,%killerpos);	//== Distance from Killed Player To Enemy Flag
			
				if (%vertPos == "head" && (%damagetype == $SniperDamageType || %damagetype == $BulletDamageType || %damagetype == $LaserDamageType) )
				{
					%msg = "HEAD SHOT";
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
				if ($ScoreOn) bottomprint(%killerId, "<jc><f1>Flag Runner Killed! Score +<f2>" @ %score @ " = " @ %killerId.score @ "<f1> Total Score");
              				messageAll(1, Client::getName(%killerId) @ " gets a bonus for killing the flag runner!!!");
			}
			else
			{
				if ($ScoreOn) bottomprint(%killerId, "<jc><f1>Score +<f2>" @ %score @ " = <f2>" @ %killerId.score @ " Total Score <f1>" @ %msg @ ".");
   			}

   			//====================================== Refresh Scores		 
         
			Game::refreshClientScore(%killerId);
         		Game::refreshClientScore(%playerId);
         		return;
		}
	}
}

function CheckTeamKiller(%killerId,%playerId,%damagetype, %vertPos, %quadrant)
{
	if(%damagetype != $MineDamageType && %damagetype != $GravDamageType && %damagetype != $CloakDamageType)
	{
		%ppos = %playerid.TKDeathPos;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if($teamplay && (Client::getTeam(%killerId) != Client::getTeam(%cl)))
			{
				if(%cl != %playerId && %cl != %killerId)
				{
					%pppos = GameBase::getPosition(%cl);
					%dist = Vector::getDistance(%ppos,%pppos);
					if ($debug) echo("***" @ Client::getName(%cl) @ " was " @ %dist @ " from " @ Client::getName(%playerId) @ " Prox = " @ $MDAntiTeamKillProximity);

					if(%dist < $MDAntiTeamKillProximity)
					{
						if ($debug) echo("***Player "@ Client::getName(%playerId) @" was close, kill is accidental.");
						Client::sendMessage(%killerId, 0, "You team killed...");
						return;
					}
				}
			}
		}

	        messageAll(3, $adminbotname @": *** " @ Client::getName(%killerId) @ " TeamKilled ***");

  		$killedflagcarry = "False";		 //== Reset
		%playerId.lastkillpos = -1;		 //== Reset
		$killedarmor = -1;			 //== Reset		   		
	   		
		%score = (Scoring::killpoints(%playerId, %killerId, %vertPos,%quadrant));

		if ($Shifter::JustSpawned[%playerId] == "false")
		{
			%killerId.scoreDeaths++;						//=== Killer Number Of Kills
			%killerId.score = (%killerId.score - %score);				//=== Killer Score
			if ($Shifter::Debug) echo ("*** Player Team Killed - Deducting Points");
		}
		else
		{
			%score = floor(%score / 2);
			%killerId.scoreDeaths++;						//=== Killer Number Of Kills
			%killerId.score = (%killerId.score - %score);				//=== Killer Score
			if ($Shifter::Debug) echo ("*** Team Kill - But Killed Player Just Spawned - Possible Accident - Points Deducted Halved");
		}
	
		//====================================== Refresh Scores
		Game::refreshClientScore(%killerId);
		Game::refreshClientScore(%playerId);

		if (%killedflag)
		{
			if ($ScoreOn) centerprint(%killerId, "<jc><f1>You Team Killed The Flag Runner! Score -<f2>" @ %score @ " = " @ %killerId.score @ " <f1>Total Score");
			messageAll(0, Client::getName(%killerId) @ " TEAM KILLED his own Flag Runner!!!");
		}
		else
		{
			if ($ScoreOn) bottomprint(%killerId, "<jc><f2>YOU IDIOT<f1> You Team Killed! Score -<f0>" @ %score @ " = " @ %killerId.score @ "<f1>  Total Score");
		}

		$Shifter::LastTker = (Client::getName(%killerId));
		$Shifter::LastTKed = (Client::getName(%playerId));
		$Shifter::LastTKno = (%killerid.TKCount + 1);

		if(%killerid.TKCount == "")
		{
			%killerid.TKCount = 1;
		}
		else
		{
			%killerid.TKCount = %killerid.TKCount + 1;

			//============================================================================== Server Terminates Team Killer

			

			if(%killerid.TKCount > $MeltdownTKLimit)
			{
				%clientId = %killerId;
				%addr = Client::getTransportAddress(%killerId);
				%name = Client::getName(%clientId);
				
				if ($Server::Admin["noban", %name] && %clientId.noban)
				{
					echo ("ADMINMSG **** " @ %name @ " hit TK limit but is NoBan");
					return;
				}		
				else if (%clientId.noban)
				{
					echo ("ADMINMSG **** " @ %name @ " hit TK limit but is NoBan");
					return;
				}

				bottomprintall("***" @ Client::getName(%killerId) @ " Was Kicked and Banned For TeamKilling", 5); 

				%ip = Client::getTransportAddress(%killerId);
				BanList::add(%ip, $MeltdownTKbantime);      //=== Add Player To BanList
				%killer = Client::getOwnedObject(%killerId);
				%kname = Client::getName(%killerId);
				SHBanName(%kname);
				messageAll(0, Client::getName(%killerId) @ " was kicked and banned for teamkilling");
				KickPlayer(%killerId,"***" @ $MD::TeamKillMsg @ "***");
			}
			else
			{
				if(%killerid.TKCount > $MeltdownTKKillwarning)
				{
					centerprint(%killerId, "<jc><f0>You have killed <f1>" @ %killerId.TKCount @ " <f0>teammates. If you continue you will be kicked and banned.", 10);
				}	
			}
		}		
    	}
}
function Game::clientKilled(%playerId, %killerId)
{}

function Client::leaveGame(%clientId)
{}

function Player::enterMissionArea(%player)
{
   %cl = Player::getClient(%player);	
   %gay = Client::getName(%cl);
   Client::sendMessage(%cl,1,"You have entered the mission area again. ~wmale1.wcheer2.wav");
   %player.outArea = 0;

}

function Player::leaveMissionArea(%player)
{
   %cl = Player::getClient(%player);
   %gay = Client::getName(%cl);
     	Client::sendMessage(%cl,1,"You have left the mission area. Come Back Soon OR DIE!!! MUAHHAHA");
	%player.outArea = 1;
	alertPlayer(%player, 5);
}

//checking for timeout of dieSeqCount
function Player::checkLMATimeout(%player, %seqCount)
{
   echo("checking player timeout " @ %player @ " " @ %seqCount);
   if(%player.dieSeqCount == %seqCount)
      remoteKill(Player::getClient(%player));
}

function alertPlayer(%player, %count)
{
	if(%player.outArea == 1) {
		%clientId = Player::getClient(%player);
	  	Client::sendMessage(%clientId,1,"~wLeftMissionArea.wav");
		if(%count > 1)
		   schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",1.5,%clientId);
		else 
	   	schedule("leaveMissionAreaDamage(" @ %clientId @ ");",1,%clientId);
	}
}

function leaveMissionAreaDamage(%client)
{
	if(!%client.isSuperAdmin)
	{
		%player = Client::getOwnedObject(%client);
		if(%player.outArea == 1) 
		{
			if(!Player::isDead(%player)) 
			{
		  		Player::setDamageFlash(%client,0.1);
				GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.05);
	   			schedule("leaveMissionAreaDamage(" @ %client @ ");",1);
			}
			else 
			{ 
			playNextAnim(%client);	
			Client::onKilled(%client, %client);
			}
		}
	}
}

function GameBase::getHeatFactor(%this)
{
   return 0.0;
}




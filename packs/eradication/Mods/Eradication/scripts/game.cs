exec("comchat.cs");

//---------------------------------------------------------------------------------

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
   messageAll(0, "Match starts in " @ %time @ " seconds.");
   UpdateClientTimes(%time);
}

function Game::startMatch()
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Match started.");
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
   if(!$ghosting)
      return false;
   if($Eradication::tkBan) {
		for(%i=0; $LoserList[%i]!=""; %i++) {
			if($LoserList[%i] == Client::getTransportAddress(%clientId)) {
				centerprint(%clientId, "<jc><f2>You cannot Spawn in this game loser.\nYou have killed enough team mates for one day.\n Try again after the game has been reset.", 10);
				return false;
			}
		}
	}
	Client::clearItemShopping(%clientId);
  	%spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
    if(!%respawn)   {
		bottomprint(%clientId, "<jc><f0>Eradication <f2>v" @ $EradicationVersion @ "\n<f2>http:\\\\www.planetstarseige.com\\eradication\n <f0>Check out the web page for details and instructions\n<f1>Mission: <f2>" @ $missionName @ "   <f1>Mission Type: <f2>" @ $Game::missionType @ "\n<f1>Press <f2>'O'<f1> for specific objectives.", 8);
		%clientId.firstSpawn = true;
		schedule(%clientId @".firstSpawn = false;", 8, %clientId);
	}
	else 
   		%clientId.firstSpawn = false;
   
	if(%spawnMarker) {   
		%clientId.guiLock = "";
	 	%clientId.dead = "";
	   if(%spawnMarker == -1) {
	      %spawnPos = "0 0 300";
	      %spawnRot = "0 0 0";
	   }
	   else {
	      %spawnPos = GameBase::getPosition(%spawnMarker);
	      %spawnRot = GameBase::getRotation(%spawnMarker);
	   }
	  if(!String::ICompare(Client::getGender(%clientId), "Male"))
	      %armor = "marmor";
	  else
	      %armor = "mfemale";
	   %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	   %armorName = $ArmorName[Player::getArmor(%clientId)];
 	   $TeamItemCount[GameBase::getTeam(%clientId) @ %armorName]++;

	   echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	   if(%pl != -1) {
	      GameBase::setTeam(%pl, Client::getTeam(%clientId));
	      Client::setOwnedObject(%clientId, %pl);
	      Game::playerSpawned(%pl, %clientId, %armor, %respawn);

	      if($matchStarted)
	         Client::setControlObject(%clientId, %pl);
	      else  {
	         %clientId.observerMode = "pregame";
	         Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	         Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
	      }
	   }
      return true;
	}
	else {
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      return false;
	}
}

function Game::playerSpawned(%pl, %clientId, %armor)
{						  
	%clientId.lastSpawnTime = getSimTime();
	%clientId.spawn= 1;
	%clientId.vehicle = "";
	if(%clientId.killDeath >= 5 && Player::getMountedItem(%clientId,$MarkerSlot) == -1) {
		Player::incItemCount(%clientId, "KillerMarker");
		Player::useItem(%pl, "KillerMarker");
	}
	if(%clientId.killDeath <= 0.1 && %clientId.killDeath != ""  && %clientId.killDeath != 0 && Player::getMountedItem(%clientId,$MarkerSlot) == -1) {
		Player::incItemCount(%clientId, "NewbieMarker");
		Player::useItem(%pl, "NewbieMarker");
	}
	%max = getNumItems();
   for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++) {
		buyItem(%clientId,%item);	
		if(%item.className == Weapon) 
			%clientId.spawnWeapon = %item;
	}
	%clientId.spawn= "";
	if(%clientId.spawnWeapon != "") {
		Player::useItem(%pl,%clientId.spawnWeapon);	
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
         centerprint(%clientId, $Server::JoinMOTD, 0);
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
     		%cl.headShots = 0;
		     	%cl.chunkShots = 0;
     		%cl.maks = 0;
		     	%cl.killDeath = 1;
			%cl.flagCaps = 0;
		}
	}
	else {
		%client.scoreKills = 0;
		%client.scoreDeaths = 0;
		%client.ratio = 0;
     	%client.score = 0;
     	%client.headShots = 0;
     	%client.chunkShots = 0;
     	%client.maks = 0;
     	%client.killDeath = 1;
     	%client.flagCaps = 0;
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
	%playerId.headShots = 0;
	%playerId.chunkShots = 0;
	%playerId.maks = 0;
	%playerId.killDeath = 1;
    %playerId.flagCaps = 0;
   $menuMode[%playerId] = "None";
   Game::refreshClientScore(%playerId);
}

function Game::assignClientTeam(%playerId)
{
   if($teamplay)
   {
      %name = Client::getName(%playerId);
      %numTeams = getNumTeams();
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

function Client::onKilled(%playerId, %killerId, %damageType)
{
	%playerId.vehicle = "";
	%playerId.guiLock = true;
	Client::setGuiMode(%playerId, $GuiModePlay);
	if(!String::ICompare(Client::getGender(%playerId), "Male"))
		%playerGender = "his";
	else	
		%playerGender = "her";
	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	%victimName = Client::getName(%playerId);

	Client::computeKillDeath(%playerId);
	Client::computeKillDeath(%killerId);

	%playerTeam = GameBase::getTeam(%playerId);
	%killerTeam = GameBase::getTeam(%killerId);

	//death by opponent
	if (%playerTeam != %killerTeam && (getSimTime() - %playerId.lastSpawnTime) > 5) {
			if(Player::getArmor(%playerId) == "carmor") {
				%playerId.score -= 5;
				%killerId.score += 5;
			      $teamScore[%killerTeam] += 5;
			}
			else
				%playerId.score--;
			//killed by a player
			if(%killerId != 0) {
				if (%playerId.killDeath <= 0.1) {
					if(%killerId.killDeath >= 5) {
						%killerId.score--; 
						%playerId.scoreDeaths++;
					}
					else 
						%playerId.scoreDeaths++;
				}
				else if (%playerId.killDeath > 0.1 && %playerId.killDeath < 1) {
					%killerId.score++;
					%killerId.scoreKills++;
					%playerId.scoreDeaths++;
				}
				else if (%playerId.killDeath >= 1 && %playerId.killDeath < 5) {
					if(%killerId.killDeath >= 1) {
						%killerId.score++;
						%killerId.scoreKills++;
						%playerId.scoreDeaths++;
					}
					else {
						%killerId.score += 2;
						%killerId.scoreKills++;
						%playerId.scoreDeaths++;
					}
				}
				else if (%playerId.killDeath >=5) {
					if(%killerId.killDeath < 1) {
						%killerId.score += 5;
						%killerId.scoreKills++;
						%playerId.scoreDeaths++;
					}
					if(%killerId.killDeath >= 1 && %killerId.killDeath < 5) {
						%killerId.score += 3;
						%killerId.scoreKills++;
						%playerId.scoreDeaths++;
					}
					if(%killerId.killDeath >= 5) {
						%killerId.score += 2;
						%killerId.scoreKills++;
						%playerId.scoreDeaths++;
					}
				}
				Client::computeKillDeath(%killerId);
				Client::computeKillDeath(%playerId);
				if(%killerId.scoreKills > $MaxKills) {
					$MaxKillsName = Client::getName(%killerId);
					$MaxKills = %killerId.scoreKills;
					ObjectiveMission::getOutstandingAchievements();
				}
				if(Client::getName(%playerId) == $MaxKillsName) {
					$MaxKills = %playerId.scoreKills;
					for(%cl=Client::getFirst(); %cl != -1 ; %cl = Client::getNext(%cl)){
						if(%cl.scoreKills > %playerId.scoreKills) {
							$MaxKillsName = Client::getName(%cl);
							$MaxKills = %cl.scoreKills;
						}
					}
					ObjectiveMission::getOutstandingAchievements();
				}
				if($Eradication::showDeathMessages) {
					%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),	%victimName, %killerGender, %playerGender);
					messageAll(0, %obitMsg, $DeathMessageMask);
				}
				if($Eradication::showBroadcastScore) {
					Client::sendMessage(%killerId, 0, "Score: "@ %killerId.score @" KillDeath: "@ %killerId.killDeath);
					Client::sendMessage(%playerId, 0, "Score: "@ %playerId.score @" KillDeath: "@ %playerId.killDeath);
				}
			}
			//killed by a turret
			else {
				%playerId.scoreDeaths++;
				Client::computeKillDeath(%playerId);
				if($Eradication::showDeathMessages) {
					%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),	%victimName, %killerGender, %playerGender);
					messageAll(0, %obitMsg, $DeathMessageMask);
				}
				if($Eradication::showBroadcastScore) {
					Client::sendMessage(%killerId, 0, "Score: "@ %killerId.score @" KillDeath: "@ %killerId.killDeath);
					Client::sendMessage(%playerId, 0, "Score: "@ %playerId.score @" KillDeath: "@ %playerId.killDeath);
				}
			}
	}
	//spawn killed
	else if(%playerTeam != %killerTeam && (getSimTime() - %playerId.lastSpawnTime) <= 5) {
		%killerId.score -= 2;
	    	messageAll(0, strcat(Client::getName(%killerId), " spawn kills ", %victimName, " with ruthless abandon."), $DeathMessageMask);
		%killerId.spawnKills++;
		$SpawnKiller[%killerId] = %killerId.spawnKills;
	}
	//death by Team Killer
	else if(%playerTeam == %killerTeam && %playerId != %killerId && Client::getName(%killerId) != "") {
		%killerId.score -= 5;
	    	messageAll(0, strcat(Client::getName(%killerId), " team kills ", %victimName, " with a vengance."), $DeathMessageMask);
		if($Eradication::tkBan) {
			%killerId.teamKills++;
			if(%killerId.teamKills == $Eradication::tkWarningLimit)
				centerprint(%killerId, "<jc><f2>Next time you TK, you will be banned from this game.", 5);
			else if(%killerId.teamKills >= $Eradication::tkBanLimit) {
				centerprint(%killerId, "<jc><f2>You have been banned from this game loser.", 5);
				if($LoserListCount == "")
					$LoserListCount = 0;
				$LoserList[$LoserListCount] = Client::getTransportAddress(%killerId);
				$LoserListCount++;
				remoteKill(%killerId);	
			}
		}
	}
	//death by stupidity
	else {
		%playerId.scoreDeaths++;
		Client::computeKillDeath(%playerId);
		if(Player::getArmor(%playerId) == "carmor")
			%playerId.score -= 5;
		else
			%playerId.score--;
		if($Eradication::showDeathMessages) 
			messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
		if($Eradication::showBroadcastScore) 
			Client::sendMessage(%playerId, 0, "Score: "@ %playerId.score @" KillDeath: "@ %playerId.killDeath);
	}

	
	if(%killerId.killDeath >= 5 && Player::getMountedItem(%killerId,$MarkerSlot) == -1) {
		Player::incItemCount(%killerId, "KillerMarker");
		Player::useItem(%killerId, "KillerMarker");
	}
	else if(%killerId.killDeath > 0.1 && Player::getMountedItem(%killerId,$MarkerSlot) == "NewbieMarker") {
		Player::unmountItem(%killerId, $MarkerSlot);
		Player::decItemCount(%killerId, "NewbieMarker");
	}

	Client::computeKillDeath(%killerId);
	Client::computeKillDeath(%playerId);
	Game::refreshClientScore(%killerId);
	Game::refreshClientScore(%playerId);
	ObjectiveMission::refreshTeamScores();
	if(%killerId.score > $MaxScore) {
		$MaxScoreName = Client::getName(%killerId);
		$MaxScore = %killerId.score;
		ObjectiveMission::getOutstandingAchievements();
	}
	if(Client::getName(%playerId) == $MaxScoreName) {
		$MaxScore = %playerId.score;
		for(%cl=Client::getFirst(); %cl != -1 ; %cl = Client::getNext(%cl)){
			if(%cl.score > %playerId.score) {
				$MaxScoreName = Client::getName(%cl);
				$MaxScore = %cl.score;
			}
		}
		ObjectiveMission::getOutstandingAchievements();
	}
	%armorName = $ArmorName[Player::getArmor(%playerId)];
  	$TeamItemCount[GameBase::getTeam(%playerId) @ %armorName]--;
}

function Client::computeKillDeath(%playerId)
{
	%playerId.killDeath = (%playerId.scoreKills + 1)/(%playerId.scoreDeaths + 1);
	if(%playerId.killDeath > $MaxKillDeath) {
		$MaxKillDeathName = Client::getName(%playerId);
		$MaxKillDeath = %playerId.killDeath;
		ObjectiveMission::getOutstandingAchievements();
	}
	if(Client::getName(%playerId) == $MaxKillDeathName) {
		$MaxKillDeath = %playerId.killDeath;
		for(%cl=Client::getFirst(); %cl != -1 ; %cl = Client::getNext(%cl)){
			if(%cl.killDeath > %playerId.killDeath) {
				$MaxKillDeathName = Client::getName(%cl);
				$MaxKillDeath = %cl.killDeath;
			}
		}
		ObjectiveMission::getOutstandingAchievements();
	}
}


function Game::clientKilled(%playerId, %killerId)
{
	// do nothing
}

function Client::leaveGame(%clientId)
{
   // do nothing
}

function Player::enterMissionArea(%player)
{
   echo("Player " @ %player @ " entered the mission area.");
}

function Player::leaveMissionArea(%player)
{
   echo("Player " @ %player @ " left the mission area.");
}

function GameBase::getHeatFactor(%this)
{
   return 0.0;
}


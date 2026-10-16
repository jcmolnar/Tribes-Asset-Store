$roundLength = 2; //length of each round in minutes

//DO NOT EDIT FROM THIS POINT DOWN------------------------------
$curTimer = 0;
$inRound = false;
$it[0] = $it[1] = -1;
$curFireballVersion = "Fireball v3.0";
$startingRound = false;
 function FootballThrowerImage::onFire(%player, %slot)
   {
      %clientId = Player::getClient(%player);
   
      if(Player::getItemCount(%clientId, "Football"))
      {
         %clientpos = GameBase::getPosition(%clientId);
      
      $los::object = 0;
         GameBase::getLOSinfo(%player, 8000, "0 0 0");
         if(getObjectType($los::object) == "Player")
         {
            %closestId = Player::getClient($los::object);
            %tpos = GameBase::getPosition(%closestId);
            %closest = Vector::getDistance(%tpos, %clientpos);
         
            %factor = sqrt(%closest) / 6.454;
            %vel = %closest / %factor;
         }
         else
         {
            %FOVpan = 0.15;
            %clientrot = GetWord(GameBase::getRotation(%clientId), 2);
            for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
            {
               if(%id != %clientId && GameBase::getPosition(%id) != "0 0 0")
               {
                  %vec = Vector::sub(GameBase::getPosition(%id), %clientpos);
                  %vecRot = GetWord(Vector::getRotation(%vec), 2);
               
                  if(%vecRot >= %clientrot - %FOVpan && %vecRot <= %clientrot + %FOVpan)
                     %idList[%c++] = %id;
               }
            }
            if(%idList[1] != "")
            {
               %closest = 500000;
               for(%i = 1; %idList[%i] != ""; %i++)
               {
                  %dist = Vector::getDistance(%clientpos, GameBase::getPosition(%idList[%i]));
                  if(%dist < %closest)
                  {
                     %closest = %dist;
                     %closestId = %idList[%i];
                  }
               }
               %factor = sqrt(%closest) / 6.454;
               %vel = %closest / %factor;
            }
            else
               %vel = 35;
         }
      
         ThrowFootball(%clientId, %vel);
         LoseFootball(%clientId);
      }
   }

function Player::onKilled(%this)
   {
      %cl = GameBase::getOwnerClient(%this);
      %cl.dead = 1;

      if(%this.outArea == 1)	
         leaveMissionAreaDamage(%cl);
      Player::setDamageFlash(%this,0.75);
   
      LoseFootball(%cl, drop);
   
      if(%cl != -1)
      {
         if(%this.vehicle != "")	{
            if(%this.driver != "") {
               %this.driver = "";
               Client::setControlObject(Player::getClient(%this), %this);
               Player::setMountObject(%this, -1, 0);
            }
            else {
               %this.vehicle.Seat[%this.vehicleSlot-2] = "";
               %this.vehicleSlot = "";
            }
            %this.vehicle = "";		
         }


         schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
         Client::setOwnedObject(%cl, -1);
         Client::setControlObject(%cl, Client::getObserverCamera(%cl));
         Observer::setOrbitObject(%cl, %this, 5, 5, 5);
         schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
         %cl.observerMode = "dead";
         %cl.dieTime = getSimTime();
      if(%cl.inRound)
         tagged(%cl, true);

      
}
   }
   function Game::checkTimeLimit()
   {
   // if no timeLimit set or timeLimit set to 0,
   // just reschedule the check for a minute hence
   $timeLimitReached = false;
      ObjectiveMission::setObjectiveHeading();
   
      if(!$Server::timeLimit || ($MMode && !$MMatchStarted))
      {
         schedule("Game::checkTimeLimit();", 60);
         return;
      }
   
      %curTimeLeft = ($Server::timeLimit * 120) - (getSimTime() - $missionStartTime);
      if(%curTimeLeft <= 0 && ($matchStarted || $MMode))
      {
         if($halftimeDelay >= 5) {
         
            if($matchStep == 0)
            {
            $matchStep++;
            }
            else if($matchStep == 1)
            {
            $matchStep++;
            
               echo("GAME: timelimit");
            $timeLimitReached = true;
               if($MMode && $MMatchStarted) {
                  MEndMatch(MGetLoser());
                  return;
               }
               messageAll($MsgRed, "GAME OVER!~wendcrowd.wav");
               %set = nameToID("MissionCleanup/ObjectiveSet");
               for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
                  GameBase::virtual(%obj, "timeLimitReached", %clientId);
            
               ObjectiveMission::missionComplete();
            
               return;
            }
         }
      }
   
      if(%curTimeLeft >= 20)
         schedule("Game::checkTimeLimit();", 20);
      else
         schedule("Game::checkTimeLimit();", %curTimeLeft + 1);
   }
   function GroupTrigger::onTrigger(%object, %this)
   {
   //removes functionality
   }
   function LoseFootball(%clientId, %action)
   {
      if($InfJet)
         GameBase::setRechargeRate(Client::getOwnedObject(%clientId), 1000);
      if(Player::getItemCount(%clientId, Football) > 0)
      {
         if(%action == drop)
            DropFootball(%clientId, False);
         else if(%action == fumble)
            DropFootball(%clientId, True);
         else
            Player::decItemCount(%clientId, Football);
      }
      %player = Client::getOwnedObject(%clientId);
      if(Player::getItemCount(%clientId, Football) == 0)
         Player::unMountItem(%player, $BackpackSlot);
      RefreshObserveFootball();
   }
   function ThrowFootball(%clientId, %vel)
   {
      %rot = GameBase::getRotation(%clientId);
      %playervel = Item::getVelocity(%clientId);
   
      %zoffset = 0.25;
      %football = $fb[GameBase::getTeam(%clientId)] = newObject("", "Item", Football, 1, false);
   
      %football.rot = %rot;
   
      addToSet("MissionCleanup/ObjectivesSet",%football);
      %newrot = GetWord(%rot, 0) - %zoffset @ " " @ GetWord(%rot, 1) @ " " @ GetWord(%rot, 2);
      GameBase::setRotation(%clientId, %newrot);
   
      Item::setVelocity(%clientId, "0 0 0");
      GameBase::throw(%football, Client::getOwnedObject(%clientId), %vel, false);
      Item::setVelocity(%clientId, %playervel);
   
      GameBase::setRotation(%football, %rot);
      GameBase::setRotation(%clientId, %rot);
   }
   function ObjectiveMission::setObjectiveHeading()
   {
   
      if($missionComplete)
      {
         %curLeader = 0;
         %tieGame = false;
         %tie = 0;
         %tieTeams[%tie] = %curLeader; 
         for(%i = 0; %i < getNumTeams() ; %i++) 
            echo("GAME: teamfinalscore " @ %i @ " " @ $teamScore[%i]);
      
         for(%i = 1; %i < getNumTeams() ; %i++) 
         {
            if($teamScore[%i] == $teamScore[%curLeader])
            {
               %tieGame = true;
               %tieTeams[%tie++] = %i;
            }
            else if($teamScore[%i] > $teamScore[%curLeader])
            {
               %curLeader = %i;	   
               %tieGame = false;
               %tie = 0;
               %tieTeams[%tie] = %curLeader; 
            }
         }
         if(%tieGame)
         {
            for(%g = 0; %g <= %tie; %g++)
            {
               %names = %names @ getTeamName(%tieTeams[%g]);
               if(%g == %tie-1)
                  %names = %names @ " and "; 
               else if(%g != %tie)
                  %names = %names @ ", "; 
            }
            if(%tie > 1) 
               %names = %names @ " all"; 
         }
         for(%i = -1; %i < getNumTeams(); %i++)
         {
            objective::displayBitmap(%i,0);
            if(!%tieGame)
            {
               if(%i == %curLeader)
               {
                  if($teamScore[%curLeader] == 1)
                     Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " point!");
                  else
                     Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " points!");
               }
               else
               {
                  if($teamScore[%curLeader] == 1)
                     Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " point!");
                  else
                     Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " points!");
               }
            }	
            else
            {
               if(getNumTeams() > 2)
               {
                  Team::setObjective(%i, 1, "<F5>     The " @ %names @ " tied with a score of " @ $teamScore[%curLeader]);
               }
               else
                  Team::setObjective(%i, 1, "<F5>     The mission ended in a tie where each team had a score of " @ $teamScore[%curLeader]);
            }
            Team::setObjective(%i, 2, " ");
         }
      }
      else
      {
         for(%i = -1; %i < getNumTeams(); %i++)
         {
            objective::displayBitmap(%i,0);
            Team::setObjective(%i,1, "<f5>Mission Completion:");
            Team::setObjective(%i, 2,"<f1>   - " @ $teamScoreLimit @ " points needed to win the mission.");
         }
      }
      if(!$Server::timeLimit)
         %str = "<f1>   - No time limit on the game.";
      else if($timeLimitReached)
         %str = "<f1>   - Time limit reached.";
      else if($missionComplete)
      {
         %time = getSimTime() - $missionStartTime;
         %minutes = Time::getMinutes(%time);
         %seconds = Time::getSeconds(%time);
         if(%minutes < 10)
            %minutes = "0" @ %minutes;
         if(%seconds < 10)
            %seconds = "0" @ %seconds;
         %str = "<f1>   - Total match time: " @ %minutes @ ":" @ %seconds;
      }
      else
         %str = "<f1>   - Time remaining: " @ floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60) @ " minutes.";
   
      for(%i = -1; %i < getNumTeams(); %i++)
      {
         Team::setObjective(%i, 3, " ");
         Team::setObjective(%i, 4, "<f5>Mission Information:");
         Team::setObjective(%i, 5, "<f1>   - Mission Name: " @ $missionName); 
         Team::setObjective(%i, 6, %str);
      
         %k = 19;
         %k = 19;
Team::setObjective(%i, %k++, "<f3>\n\n" @ $curFireballVersion @ "\n<f0>");
Team::setObjective(%i, %k++, "\n\nDownload fireball: http://www.amishrabbit.com/~taserman/fireball.zip\n");
         Team::setObjective(%i, %k++, "\nThe object is to tag all of the opponents players except the fireball carrier before time is up.\n");
         Team::setObjective(%i, %k++, "\nThe team with the most players standing when time is up wins.\n");
         Team::setObjective(%i, %k++, "\n\nHow to tag:\n");
         Team::setObjective(%i, %k++, "\n- Simply hit the player with the ball or touch them when carrying the ball.\n");
         Team::setObjective(%i, %k++, "\n- There is only one fireball carrier for each team.\n");
         Team::setObjective(%i, %k++, "\n- You may not tag your own team unless team damage has been enabled\n");
         Team::setObjective(%i, %k++, "\n- You may not tag a fireball carrier with a fireball (IE: no touching with ball).\n");
         Team::setObjective(%i, %k++, "\n- You may kill another player to get them out (Ie: tackling).\n");
         Team::setObjective(%i, %k++, "\n\nHow to tackle:\n");
         Team::setObjective(%i, %k++, "\n- The concept is simple, but execution can be difficult. To attempt a tackle, simply run into another player.\n");
         Team::setObjective(%i, %k++, "\n- You can only tackle members of the other team. High velocity determines how likely you will tackle; a combination of skiing (fast jumping while running, which also speeds up simple runs) and jump-jetting yields the best results.\n");
         Team::setObjective(%i, %k++, "\n- There is a knack to tackling: try to get your player's feet to hit the other player in the head. Don't be discouraged if at first you can't tackle. Keep at it and you'll eventually get it.\n");
         Team::setObjective(%i, %k++, "\n\nHow to pass:\n");
         Team::setObjective(%i, %k++, "\n- When you have the football, fire your Football Thrower (Blaster) to pass.\n");
         Team::setObjective(%i, %k++, "\n- If you line up a player in your crosshairs when you pass, the football will go to this player's exact position.\n");
         Team::setObjective(%i, %k++, "\n- If your crosshair does not line up with a player, but there are still players in your FOV (Field of Vision), the MOD will detect the nearest player to you within your FOV, and will toss the ball to this player.\n");
         Team::setObjective(%i, %k++, "\n- To aim past your target, place your crosshair above the target's head.  The higher the angle, the further it will go.  To throw the football short, aim your crosshairs below your target.\n");
         Team::setObjective(%i, %k++, "\n- To pass properly, the trick is to place your crosshairs RIGHT on the target, make sure no other players are in your FOV, and click fire. DON'T aim far above or below the receiver.\n");
         Team::setObjective(%i, %k++, "\n- Also, unlike with Disc Launchers, the Football does NOT inherit your momentum.  Wherever your crosshair is pointed when you pass is where the football goes. [Quote from Greasey: BAH!! YA RIGHT!!]");
      }
   }
   function Game::startMatch()
   {
   $matchStarted = true;
   $missionStartTime = getSimTime();
      Game::resetScores();	
   
      %numTeams = getNumTeams();
      for(%i = 0; %i < %numTeams; %i = %i + 1)
      {
         if($TeamEnergy[%i] != "Infinite")
            schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
      }
   
      if($MMode && $MMatchStarted)
         for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         {
            %name = Client::getName(%cl);
            if(%cl.observerMode == "pregame")
            {
               %cl.observerMode = "";
               if(!%cl.frozen)
                  Client::setControlObject(%cl, Client::getOwnedObject(%cl));
            }
            Game::refreshClientScore(%cl);
         }
      else
         for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         {
            if(%cl.observerMode == "pregame")
            {
               %cl.observerMode = "";
               if(!%cl.frozen)
                  Client::setControlObject(%cl, Client::getOwnedObject(%cl));
            }
            Game::refreshClientScore(%cl);
         }
   
      if($Server::timeLimit == "") $Server::timeLimit = 15;
   
   $matchStep = 0;
      Game::checkTimeLimit();
      newRound();
   
   }
   function deleteFBs()
   {
      deleteObject($fb[1]);
      deleteObject($fb[0]);
   
   
   //alternate method (may hep with deleting extra balls)--------
      %group = nameToID("MissionCleanup/ObjectivesSet");
      ObjectiveMission::setObjectiveHeading();
   
      for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
         deleteObject(%obj);
   
   }
   function DropFootball(%clientId, %random)
   {
   //This function should only be invoked by LoseFootball.
   
      if(Player::getItemCount(%clientId, Football) == 0)
         return;
      %football = $fb[GameBase::getTeam(%clientId)] = newObject("", "Item", Football, 1, false);
   
      %oldrot = GameBase::getRotation(%clientId);
   
      if(%random)
         %rot = "0 -0 " @ (getRandom() * 6.28) - 3.14;
      else
         %rot = GameBase::getRotation(%clientId);
      %team = GameBase::getTeam(%clientId);
   
      %football.owner = %clientId;
      %football.rot = %rot;
   
   
      addToSet("MissionCleanup/ObjectivesSet", %football);
   
      GameBase::setRotation(%clientId, %rot);	
      GameBase::throw(%football, Client::getOwnedObject(%clientId), 10, false);
      Player::decItemCount(%clientId, Football);
      Item::playPickupSound(%football);
      GameBase::setRotation(%clientId, %oldrot);
   
   }
   function Game::refreshClientScore(%clientId)
   {
   
      %team = Client::getTeam(%clientId);
      if(%team == -1) // observers go last.
         %team = 9;
      // objective mission sorts by team first.
if(%clientId.inRound)
         Client::setScore(%clientId, "*%n\t%t\t  " @ %clientId.score  @ "\t%p\t%l", %clientId.score + (9 - %team) * 10000);
      else
         Client::setScore(%clientId, " %n\t%t\t  " @ %clientId.score  @ "\t%p\t%l", %clientId.score + (9 - %team) * 10000);
   }
   function Mission::init()
   {
   
      setClientScoreHeading(" Player Name\t\x6FTeam\t\xA6Score\t\xCFPing\t\xEFPL");
      setTeamScoreHeading("Team Name\t\x6FPlayers\t\xD6Score");
         //setTeamScoreHeading("Team Name\t\xD6Score");
   
   $firstTeamLine = 7;
   $firstObjectiveLine = $firstTeamLine + getNumTeams() + 1;
      for(%i = -1; %i < getNumTeams(); %i++)
      {
      $teamFlagStand[%i] = "";
      $teamFlag[%i] = "";
         Team::setObjective(%i, $firstTeamLine - 1, " ");
         Team::setObjective(%i, $firstObjectiveLine - 1, " ");
         Team::setObjective(%i, $firstObjectiveLine, "<f5>Mission Objectives: ");
      $firstObjectiveLine++;
      $deltaTeamScore[%i] = 0;
      $teamScore[%i] = 0;
         newObject("TeamDrops" @ %i, SimSet);
         addToSet(MissionCleanup, "TeamDrops" @ %i);
         %dropSet = nameToID("MissionGroup/Teams/Team" @ %i @ "/DropPoints");
         for(%j = 0; (%dropPoint = Group::getObject(%dropSet, %j)) != -1; %j++)
            addToSet("MissionCleanup/TeamDrops" @ %i, %dropPoint);
      }
   $numObjectives = 0;
      newObject(ObjectivesSet, SimSet);
      addToSet(MissionCleanup, ObjectivesSet);
   
      Group::iterateRecursive(MissionGroup, ObjectiveMission::initCheck);
      %group = nameToID("MissionCleanup/ObjectivesSet");
   
      ObjectiveMission::setObjectiveHeading();
      for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
      {
         %obj.objectiveLine = %i + $firstObjectiveLine;
         ObjectiveMission::objectiveChanged(%obj);
      }
      ObjectiveMission::refreshTeamScores();
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %cl.score = 0;
         Game::refreshClientScore(%cl);
      }
      schedule("ObjectiveMission::checkPoints();", 5);
   }
   function Server::loadMission(%missionName, %immed)
   {
      exec(server);
      exec(admin);
      exec(Item);
      exec(Player);
   $setNextMission = "";
   
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
         %cl.inRound = false;
         Client::setGuiMode(%cl, $GuiModeVictory);
      //fix for bug at next mission
         %cl.tackled = false;
         %cl.guiLock = true;
         %cl.nospawn = true;
         remoteEval(%cl, missionChangeNotify, %missionName);
         Game::refreshClientScore(%cl);
      }
   
   $loadingMission = true;
   $missionName = %missionName;
   $missionFile = %missionFile;
   $prevNumTeams = getNumTeams();
      deleteFBs();
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
   
      deleteFBs();
      Mission::init();
      Mission::reinitData();
   
      if($prevNumTeams != getNumTeams())
      {
      // loop thru clients and setTeam to -1;
         messageAll(0, "New teamcount - resetting teams.");
         for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
            GameBase::setTeam(%cl, -1);
      
      $RanAssignNum = $RanAssign;
      }
      else if($RanAssignNum == 1 && getNumTeams() == 2 && !$MMode)
      {
         messageall(1, "Randomly assigning teams. (Occurs after every " @ $RanAssign @ " maps)", 5);
         mixUpTeams();
      $RanAssignNum = $RanAssign;
      }
      else if($RanAssignNum > 1 && !$MMode)
      $RanAssignNum--;
   
   $ghosting = true;
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         if(!%cl.svNoGhost)
         {
            %cl.ghostDoneFlag = true;
            startGhosting(%cl);
         }
      }
   
   $teamplay = (getNumTeams() != 1);
      purgeResources(true);
   
   // make sure the match happens within 5-10 hours.
      schedule("Server::CheckMatchStarted();", 3600);
      schedule("Server::nextMission(false);", 18000);
   
      return "True";
   }
   function recursiveWorld(%seconds)
   {
   //removes functionality
   }
  
   function setIT(%clientId, %team, %respawn)
   {
      %player = Client::getOwnedObject(%clientId);
      Player::mountItem(%player, Flag, $FlagSlot, 0);
   
      %e = GameBase::getEnergy(%player);
      if(Client::getGender(%clientId) == "Male")
         Player::setArmor(%clientId, larmor);
      else if(Client::getGender(%clientId) == "Female")
         Player::setArmor(%clientId, lfemale);
      GameBase::setEnergy(%player, %e);
if(%respawn)
return;
   $it[%team] = %clientId;
      messageAll(1, Client::getName(%clientId) @ " picked up " @ getTeamName(%team) @ "'s fireball");
   }
   function GainFootball(%clientId)
   {
      Player::mountItem(Client::getOwnedObject(%clientId), ammopack, $BackpackSlot, 0);
      Player::incItemCount(%clientId, Football);
      RefreshObserveFootball();
   }

   function Game::playerSpawn(%clientId, %respawn)
   {
      if(!$ghosting)
         return false;
if(Gamebase::getTeam(%clientId) < 0)
return;
      %clientId.observermode = "";
      Client::clearItemShopping(%clientId);
      %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
      if(!%respawn)
      {
      // initial drop
         bottomprint(%clientId, "<jc><f0>Stadium: <f1>" @ $missionName @ "   <f0>Stadium Class: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives and mod rules.", 5);
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
            %armor = "clarmor";
         else
            %armor = "clfemale";
      %team = gameBase::getTeam(%clientId);
         %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
         echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
         if(%pl != -1)
         {
            GameBase::setTeam(%pl, %team);
            Client::setOwnedObject(%clientId, %pl);
            Game::playerSpawned(%pl, %clientId, %armor, %respawn);
if($it[%team] == %clientId)
		setIT(%clientId, %team, true);
            if($FBPerson == %clientId)
            $FBPerson = 0;
            if($matchStarted)
               Client::setControlObject(%clientId, %pl);
            else
            {
               %clientId.observerMode = "pregame";
               freezePlayer(%clientId);
            }
            if(%clientId.frozen || ($MMode && (!$matchStarted || $MHalfCheck != "")))
               freezePlayer(%clientId);
         }
         return true;
      }
      else {
         Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
         return false;
      }
   }

   function Game::initialMissionDrop(%clientId)
   {
      Client::setGuiMode(%clientId, $GuiModePlay);
   
      Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
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
   
      Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
      %camSpawn = Game::pickObserverSpawn(%clientId);
      Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
                          GameBase::getRotation(%camSpawn), true, true);
      %clientId.observerMode = "observerFly";
   
   }
   function Server::onClientDisconnect(%clientId)
   {
      DropFootball(%clientId);
      %team = Gamebase::getTeam(%clientId);
      if($it[%team] == %clientId)
      $it[%team] = -1;
      %ip = Client::getTransportAddress(%clientId);
      %player = Client::getOwnedObject(%clientId);
      if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
         deleteObject(%player);
   
      Client::setControlObject(%clientId, -1);
      Client::leaveGame(%clientId);
   
      if($LastVoteIP == %ip) {
         messageAll(0, Client::getName(%clientId) @ " conceded and was kicked.");
         BanList::add(%ip, 180);
      }
   $GlobalMute[%clientId] = false;
      if($FBPerson == %clientId)
      $FBPerson = 0;
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(%clientId.privatechat == %cl)
            %clientId.privatechat = "";
      %clientId.telecurse = false;
      if(%clientId.inRound)
         checkTagged();
   }

   function Server::onClientConnect(%clientId)
   {
   
   $TCSuspect[%clientId] = false;
   
      // clear out any client info:
      for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";
   
      %clientId.noghost = true;
      %clientId.messageFilter = -1; // all messages
      %clientId.privatechat = "";
      %clientId.frozen = false;
      if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
      {
         %clientId.isAdmin = true;
         %clientId.isSuperAdmin = true;
      }
      remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
      remoteEval(%clientId, FileURL, $Server::FileURL);
   
      echo("CONNECT: " @ %clientId @ " \"" @ 
          escapeString(Client::getName(%clientId)) @ 
          "\" " @ Client::getTransportAddress(%clientId));
   
   
      if($SmurfTracker)
         server::ConnectInfo(%clientId);
   
      remoteEval(%clientId, MODInfo, "<f1>" @ $curVersion @ "\nGet ready to play some " @ $curFireballVersion @ "!\n" @ $MODInfo);
   
   
      Game::onPlayerConnected(%clientId);   
   }

   function tagSpawnBalls()
   {
      for(%x = 0; %x < 2; %x++)
      {
         %football = $fb[%x] = newObject("", "Item", Football, 1, false);
         %football.rot = "0 0 0";
         addToSet("MissionCleanup/ObjectivesSet",%football);
         GameBase::setPosition(%football, GameBase::getPosition(nameToId("MissionGroup/Teams/team" @ %x @ "/FootballSpawn")));
      }
      RefreshObserveFootball();
   }

   function tagCountDown(%seconds)
   {
      if(%seconds == 0)
      {
         for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
            Client::setControlObject(%id, %id);
      
         bottomprintall("GO!", 3);
      $inCD = false;
      $timeLeft = ($roundLength * 60);
         updateClientTimes($timeLeft);
      
      $curTimer++;
         tagTimeChecker($curTimer);
         return;
      }
      updateClientTimes(%seconds);
      bottomprintall("Round begins in " @ %seconds @ " seconds.", 1);
      schedule("tagCountDown(" @ %seconds @ " - 1);",1);
   }
   function checkEnoughPlayers(%first, %counter)
   {
      %num[0] = 0;
      %num[1] = 0;
      for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
         %num[GameBase::getTeam(%id)]++;
      if(%num[0] > 1 && %num[1] > 1)
      {
         if(%first)
            return true;
         newRound();
      }
      else
      {
         if(%counter == "")
         {
            messageAll(1,"The next round will start when there are 2 or more players on each team");
            %counter = 0;
         }
         %counter++;
         if(%counter == 5)
            schedule("checkEnoughPlayers();", 3);
         else
            schedule("checkEnoughPlayers(false," @ %counter @ ");", 3);
         if(%first)
            return false;
      }
   
   }
   function newRound()
   {
      if($inRound)
         return;
      if(!checkEnoughPlayers(true))
         return;
      for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
      {
         %team = GameBase::getTeam(%id);
         if(%team >= 0)
         {
            Game::playerSpawn(%id, false);
            GameBase::setTeam(%id, %team);
            %id.teamEnergy = 0;
            Client::clearItemShopping(%id);
            if(Client::getGuiMode(%id) != 1)
               Client::setGuiMode(%id,1);		
            Client::setControlObject(%id, -1);
         
            %id.inRound = true;
         %id.tackled = false;
            if($TeamEnergy[%team] != "Infinite")
            $TeamEnergy[%team] += $InitialPlayerEnergy;
            freezePlayer(%id);
         }
         Game::refreshClientScore(%id);
      }
   $inRound = true;
$startingRound = false;
      tagSpawnBalls();
   
      tagCountDown(5);
   $inCD = true;
      messageAll(1, "A new round begins!");
   }
   function processMenuPickTeam(%clientId, %team, %adminClient, %saynothing)
   {
      if($inCD)
      {
         Client::sendMessage(%clientId, 1, "Please wait for the round to start.");
         return;
      }
      if(%team != 99 && %team != -2 && (%team < 0 || %team >= getNumTeams()))
      {
         if(%adminClient)
            Client::sendMessage(%adminClient, 1, "Try again smarty pants.");
         else
            Client::sendMessage(%clientId, 1, "Try again smarty pants.");
         return;
      }
      if(%team == 99)
      {
         %team = getAppropriateTeam(%clientId);
         %sayauto = true;
      }
      if(Client::getTeam(%clientId) == %team)
         return;
      if($TCSuspect[%clientId] && !%adminClient && %team != -2) {
         %team = -2;
         Client::sendMessage(%clientId, 1, "Please allow " @ $TCTimer @ " seconds between team changes.");
      }
      else
         %sayIt = true;
   
      checkPlayerCash(%clientId);
   
      if(%clientId.observerMode == "justJoined")
      {
         %clientId.observerMode = "";
         centerprint(%clientId, "");
      }
      if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2)
      {
      
               if($it[gamebase::getTeam(%clientId)] == %clientId)
	$it[gamebase::getTeam(%clientId)] = -1;
%clientId.inRound = false;
         if(Observer::enterObserverMode(%clientId))
         {

            gamebase::setteam(%clientId, -1);
            %clientId.notready = "";
            if(%adminClient == "") {
               if(%sayIt)
                  messageAll(0, Client::getName(%clientId) @ " became an observer.");
               if(!$TCSuspect[%clientId]) {
               $TCSuspect[%clientId] = true;
                  Schedule("$TCSuspect[" @ %clientId @ "] = false;", $TCTimer);
               }
            
            }
            else {
               messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
            }
            Game::resetScores(%clientId);	
            Game::refreshClientScore(%clientId);

            checkTagged(false);
         }
         return;
      }
   
      if(%team >= 0 && %clientId.inRound)
      {
      
         Client::sendmessage(%clientId, 1, "You cannot change teams while in play, please go to observer mode first.");
         return;
      }
      %player = Client::getOwnedObject(%clientId);
      if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
      {
      if($it[gameBase::getTeam(%clientId)] == %clientId)
      $it[gameBase::getTeam(%clientId)] = -1;
%clientId.inRound = false;
         Player::kill(%clientId);
         deleteObject(%player);
      }
      %clientId.observerMode = "";
      if(%adminClient == "" && %saynothing == "") {
         if(%sayauto)
            messageAll(0, Client::getName(%clientId) @ " changed to an automatically assigned team.");
         else
            messageAll(0, Client::getName(%clientId) @ " changed teams.");
      $TCSuspect[%clientId] = true;
         Schedule("$TCSuspect[" @ %clientId @ "] = false;", $TCTimer);
      }
      else if(%saynothing == "") {
      $TCSuspect[%clientId] = false;
         if(%sayauto)
            messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ " to an automatically assigned team.");
         else
            messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
      }
      if(%team == -1)
      {
         Game::assignClientTeam(%clientId);
         %team = Client::getTeam(%clientId);
      }
         if($it[gamebase::getTeam(%clientId)] == %clientId)
	$it[gamebase::getTeam(%clientId)] = -1;
      GameBase::setTeam(%clientId, %team);
      %clientId.teamEnergy = 0;
      Client::clearItemShopping(%clientId);
      if(Client::getGuiMode(%clientId) != 1)
         Client::setGuiMode(%clientId,1);		
      Client::setControlObject(%clientId, -1);
   
      if(%id.inRound)
         Game::playerSpawn(%clientId, false);
      %team = Client::getTeam(%clientId);
      if($TeamEnergy[%team] != "Infinite")
      $TeamEnergy[%team] += $InitialPlayerEnergy;
      if($Server::TourneyMode && !$CountdownStarted)
      {
         bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
         %clientId.notready = true;
      }
   }
   function Observer::enterObserverMode(%clientId)
   {
   
      %player = Client::getOwnedObject(%clientId);
   
      if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
      {
         Player::kill(%clientId);
         deleteObject(%player);
      }
      %clientId.inRound = false;
      Client::setOwnedObject(%clientId, -1);
      Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
      %clientId.observerMode = "observerOrbit";
      Observer::jump(%clientId);
      remotePlayMode(%clientId);
   
      return true;
   }
   function endRound(%winteam)
   {
if($startingRound)
return;
      %pause = 10;

      %winner = checkTagged(true);
   if(%winteam != "")
%winner = %winteam;
      deleteFBs();
   $it[0] = $it[1] = -1;
      if(%winner == "") {
         messageAll(1, "END OF ROUND --- The round is a tie~wflagcapture.wav");
      }
      else {
         messageAll(1, "END OF ROUND --- Congradulations to " @ $server::teamname[%winner] @ "!~wflagcapture.wav");
      $teamScore[%winner]++;
      }
   $curTimer++;
   
      updateClientTimes(($Server::timeLimit * 120) - (getSimTime() - $missionStartTime));

      schedule("messageAll(1, \"The next round will start in " @ %pause @ " seconds.\");", 2);
      schedule("newRound();",%pause + 2);
   $inRound = false;
$startingRound = true;
   }

   function checkTagged(%ended)
   {
      %count[1] = 0;
      %count[0] = 0;
      for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
      {
         if(%id.inRound)
         {
            %count[GameBase::getTeam(%id)]++;
            if(%ended) {
               %id.score += 2;	
               %id.inRound = false;
               Observer::enterObserverMode(%id);
            }
         }
         Game::refreshClientScore(%id);
      }
      if(!%ended && (%count[0] <= 1 || %count[1] <= 1))
         endRound();
   
      if(%ended == true) {
      
         if(%count[0] > %count[1])
            return 0;
         else if(%count[1] > %count[0])
            return 1;
         else
            return;
      }
   }

   function tagTimeChecker(%num)
   {
      if(%num != $curTimer)
         return;
      if($timeLeft == 20)
         messageAll(1, "20 seconds remain.");
      if($timeLeft <= 0)
      {
         endRound();
         return;
      }
   $timeLeft -= 20;
      schedule("tagTimeChecker(" @ $curTimer @ ");", 20);
   }
   function Player::onCollision(%this, %object)
   {
      %id1 = Player::getClient(%this);
      %id2 = Player::getClient(%object);
   
      if(getObjectType(%object) != "Player" || GameBase::getTeam(%id1) == GameBase::getTeam(%id2))
         return;
   
   
      if( %id1.SecondEventCall == %id2 && %id2.SecondEventCall == %id1 )
      {
      
         if( !(%id1.tackled || %id2.tackled) )
         {
            %vel[%id1] = getVelocity(%id1);
            %vel[%id2] = getVelocity(%id2);
         
            %totalVel = round(Vector::getDistance("0 0 0", Vector::sub(%vel[%id1], %vel[%id2])));
         
                     //exchange vectors
            if($elasticity == "")
               %e = 1.0;
            else
               %e = $elasticity;
            %newvel1 = GetWord(%vel[%id2], 0) * %e @ " " @ GetWord(%vel[%id2], 1) * %e @ " " @ GetWord(%vel[%id2], 2) * %e;
            %newvel2 = GetWord(%vel[%id1], 0) * %e @ " " @ GetWord(%vel[%id1], 1) * %e @ " " @ GetWord(%vel[%id1], 2) * %e;
            Item::setVelocity(%id1, %newvel1);
            Item::setVelocity(%id2, %newvel2);
         
                     //determine who hit hardest
            %absvel[%id1] = round(Vector::getDistance("0 0 0", %vel[%id1]));
            %absvel[%id2] = round(Vector::getDistance("0 0 0", %vel[%id2]));
         
            if(%absvel[%id1] > %absvel[%id2])
            {
               %status[%id1] = "tackle";
               %status[%id2] = "q0wned";
            }
            else if(%absvel[%id1] < %absvel[%id2])
            {
               %status[%id1] = "q0wned";
               %status[%id2] = "tackle";
            }
            else if(%absvel[%id1] == %absvel[%id2])
            {
               %status[%id1] = "q0wned";
               %status[%id2] = "q0wned";
            }
         
            %involved[1] = %id1;
            %involved[2] = %id2;
            %otherId[%id1] = %id2;
            %otherId[%id2] = %id1;
         
            for(%i = 1; %i <= 2; %i++)
            {
               %id = %involved[%i];
               %oid = %otherId[%id];
            
               if(%status[%id] == "q0wned")
               {
                  if(%totalVel >= 15)
                  {
                  
                                 //-----------------
                                 //  TACKLE
                                 //-----------------
                  
                  
                     if(Player::getItemCount(%id, Football) > 0)
                     {
                        LoseFootball(%id, fumble);
                        %oid.score += 1;
                        Game::refreshClientScore(%oid);
                     }
                  
                     %pid = Client::getOwnedObject(%id);
                  
                     Player::setAnimation(%id, 33);
                                 //cause damage
                     %dlevel = GameBase::getDamageLevel(%pid) + 0.2;
                     GameBase::setDamageLevel(%pid, %dlevel);
                     %flash = Player::getDamageFlash(%pid) + %value * 2;
                     Player::setDamageFlash(%pid, %flash);
                  
                     if(!Player::isDead(%pid))
                     {
                        %id.tackled = True;
                     
                        Client::setControlObject(%id, Client::getObserverCamera(%id));
                        Observer::setOrbitObject(%id, %pid, -8, -8, -8);
                        if(!%id.frozen)
                           schedule("Client::setControlObject(" @ %id @ ", " @ %id @ ");", 2);
                        else
                           schedule("freezePlayer(" @ %id @ ");", 2);
                        schedule(%id @ ".tackled = false;", 2);
                        schedule("GameBase::setEnergy(" @ %pid @ ", 0);", 2);
                     }
                     else
                        %id.tackled = false;

                     Client::sendMessage(%id, $MsgRed, Client::getName(%oid) @ " tackled you!");
                     Client::sendMessage(%oid, $MsgWhite, "You tackled " @ Client::getName(%id) @ "!");
                  }

                 if(%oid == $it[GameBase::getTeam(%oid)] && Player::getItemCount(%oid, Football) > 0)
                     tagged(%id);
               }
            }
         }
      }
      else
      {
      
         %id1.SecondEventCall = %id2;
         %id2.SecondEventCall = %id1;
         schedule(%id1 @ ".SecondEventCall = \"\";", 0.1);
         schedule(%id2 @ ".SecondEventCall = \"\";", 0.1);
      }
   }



   function tagged(%clientId, %killed)
   {

      %team = GameBase::getTeam(%clientId);

 %tagit = (%clientId == $it[%team]);

if(%tagit && !%killed)
return;

   GameBase::PlaySound(Client::getOwnedObject(%clientId), shockExplosion, 0);
      %clientId.inRound = false;
      Observer::enterObserverMode(%clientId);

   $leftStanding[%team]--;
if(%tagit)
{
messageAll(1, "The carrier for " @ getTeamName(%team) @ " has been killed, " @ Client::getName(%clientId) @ " is out!");
endRound(getotherteam(%team));
return;
}
else
      messageAll(1, Client::getName(%clientId) @ " is out!");

      checkTagged(false);
   
   } 
   function Player::onRemove(%this)
   {
   // Drop anything left at the players pos
      for (%i = 0; %i < 8; %i = %i + 1) {
         %type = Player::getMountedItem(%this,%i);
         if (%type != -1) {
         // Note: Player::dropItem ius not called here.
            %item = newObject("","Item",%type,1,false);
            if(%item.className == Football)
            {
               messageAll(1,"Player::onRemove called, debug!!!");
               echo("Player::onRemove called, debug!!!");
            
            }
            schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);
         
            addToSet("MissionCleanup", %item);
            GameBase::setPosition(%item,GameBase::getPosition(%this));
         }
      }
   }
   function Item::onDrop(%player,%item)
   {
      if($matchStarted) {
         if((%item.className != Armor) && (%item.className != Football)) {
         //echo("Item dropped: ",%player," ",%item);
            %obj = newObject("","Item",%item,1,false);
            schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
            addToSet("MissionCleanup", %obj);
            if (Player::isDead(%player)) 
               GameBase::throw(%obj,%player,10,true);
            else {
               GameBase::throw(%obj,%player,15,false);
               Item::playPickupSound(%obj);
            }
            Player::decItemCount(%player,%item,1);
            return %obj;
         }
      }
   }
   function Item::onCollision(%this,%object)
   {
      %clientId = Player::getClient(%object);
      if(getObjectType(%object) != "Player")
         return;
      %team = GameBase::getTeam(%clientId);
      %item = Item::getItemData(%this);
      %oteam = getOtherTeam(%team);
      if(%item == Football)
      {
         if(Player::getItemCount(%clientId, Football) > 0)
            return;
         if(%this == $fb[%oteam] || ($Server::teamdamagescale == 1 && $it[%team] != -1))
         {
            if($it[%team] != %clientId) {
               tagged(%clientId);
            	return;
            	}
            else if($it[%oteam] == -1 || Player::getItemCount($it[%oteam], Football) == 0)
               return;
         }
         else
         {
            if($it[%team] == -1)
               setIT(%clientId, %team);
            else if($it[%team] != %clientId)
               return;
         }
         GainFootball(%clientId);
Item::playPickupSound(%this);
         if($InfJet)
            GameBase::setRechargeRate(Client::getOwnedObject(%clientId), $rechargeRate[Player::getArmor(%clientId)]);
         deleteObject(%this);
      }
      else
      {
         if(Item::giveItem(%object,%item,Item::getCount(%this)))
         Item::respawn(%this);
         
         else if(%item == FootballThrower && getRandom() * 100 < $gunFumbleChance && Player::getItemCount(%object, Football) >0)
         {
            %name = Client::getName(%clientId);
         
            messageAll($MsgWhite, %name @ " was fumbled by a football thrower!");
         
            LoseFootball(%clientId, "fumble");
         }
      }
   	            Item::playPickupSound(%this);
   }
   function getOtherTeam(%t)
   {
      if(%t > 0)
         return 0;
      return 1;
   }
 function processMenuOptions(%clientId, %option)
   {

      %opt = getWord(%option, 0);
      %cl = getWord(%option, 1);
      %cname = Client::getName(%clientId);
      if(%opt == "fteamchange")
      {
         %clientId.ptc = %cl;
         Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
         Client::addMenuItem(%clientId, "0Observer", -2);
         Client::addMenuItem(%clientId, "1Automatic", 99);
         for(%i = 0; %i < getNumTeams(); %i = %i + 1)
            Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
         return;
      
      }
            else if(%opt == "votemenu")
      {
         if($curVoteTopic != "" || %clientId.selClient) 
            return;
         %curItem = 0;
         Client::buildMenu(%clientId, "Start a vote:", "Options", true);
         if($HPM && $curVoteTopic == "")
            Client::addMenuItem(%clientId, %curItem++ @ "Vote Hot-Patato Mode OFF", "hpvoteoff");
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
         if($Server::TeamDamageScale == 1.0)
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
         else
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to PUG", "vpug");
         if($server::timelimit == 0)      
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable time limit", "vtimeon");
         else
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable time limit", "vtimeoff");
         if($TATD)
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable tackle after TD", "vtatdoff");
         else     
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable tackle after TD", "vtatdon");
      
         if(!$NoVoteGF) {
            if($GunFumbleVar)
               Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable Gun Fumble", "vgfoff");
            else
               Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable Gun Fumble", "vgfon");
         
         }
         return;
      }
      else if(%opt == "changeteams")
      {
         if(!$matchStarted || !$Server::TourneyMode)
         {
            Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
            Client::addMenuItem(%clientId, "0Observer", -2);
            Client::addMenuItem(%clientId, "1Automatic", 99);
            for(%i = 0; %i < getNumTeams(); %i = %i + 1)
               Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
            return;
         }
      }
      else if(%opt == "mute")
         %clientId.muted[%cl] = true;
      else if(%opt == "unmute")
         %clientId.muted[%cl] = "";
      else if(%opt == "votecap")
      {
         %cl.voteTarget = true;
         Admin::startVote(%clientId, "captain " @ Client::getName(%cl), "cap", %cl);
      }
      else if(%opt == "possess")
      {
         if(%clientId.isSuperAdmin)
         {
            if(%clientId.possessId != "")
            {
               Client::sendMessage(%clientId, 1, "You may only possess one person at a time.");
               return;
            }
            if(%clientId == %cl)
            {
               Client::sendMessage(%clientId, 1, "You may not possess yourself.");
               return;
            }
            %clientId.possessId = %cl;
            freezePlayer(%cl);
            Client::setControlObject(%clientId, %clientId.possessId);
         
         }
         return;
      }
      else if(%opt == "revert")
      {
         if(%clientId.isSuperAdmin)   
            revert(%clientId);           
         return;
      }
      else if(%opt == "vkick")
      {
         %cl.voteTarget = true;
         Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
      $LastVoteIP = Client::getTransportAddress(%cl);
      }
      else if(%opt == "unsilence")
      {
         if(%clientId.isAdmin) {
         $GlobalMute[%cl] = false;
            Client::sendMessage(%cl, 1, "You have been granted talking privilages again.");
            return;
         }
      }
      else if(%opt == "silence")
      {
         if(%clientId.isAdmin) {
         $GlobalMute[%cl] = true;
            Client::sendMessage(%cl, 1, "You have been silenced by " @ Client::getName(%clientId) @ ".");
            messageAllExcept(%cl, $MsgRed, Client::getName(%cl) @ " has been silenced by " @ Client::getName(%clientId) @ ".");
         }    
         return;
      
      }
      else if(%opt == "vadmin")
      {
         if(!$VoteAdminAllowed)
            Client::sendMessage(%clientId, 1, "Try again smarty pants.");
         else {
            %cl.voteTarget = true;
            Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
         }
      }
      else if(%opt == "vetd")
         Admin::startVote(%clientId, "enable team damage", "etd", 0);
      else if(%opt == "vdtd")
         Admin::startVote(%clientId, "disable team damage", "dtd", 0);
      else if(%opt == "etd")
         Admin::setTeamDamageEnable(%clientId, true);
      else if(%opt == "dtd")
         Admin::setTeamDamageEnable(%clientId, false);
      else if(%opt == "voteYes" && %cl == $curVoteCount)
      {
         %clientId.vote = "yes";
         centerprint(%clientId, "", 0);
      }
      else if(%opt == "voteNo" && %cl == $curVoteCount)
      {
         %clientId.vote = "no";
         centerprint(%clientId, "", 0);
      }
      else if(%opt == "kick")
      {
         Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
         Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
         Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
         return;
      }
      
      else if(%opt == "unadmin")
      {
         if(%clientId.isSuperAdmin)
         {
            Client::buildMenu(%clientId, "Confirm unadmin:", "taaffirm", true);
            Client::addMenuItem(%clientId, "1UnAdmin " @ Client::getName(%cl), "yes " @ %cl);
            Client::addMenuItem(%clientId, "2Don't UnAdmin " @ Client::getName(%cl), "no " @ %cl);     
         }        
         return;
      }
      else if(%opt == "admin")
      {
         if(%clientId.isSuperAdmin)
         {
            Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
            Client::addMenuItem(%clientId, "1Admin", "yes " @ %cl);
            Client::addMenuItem(%clientId, "2Don't admin", "no " @ %cl);     
         }         
         return;
      }
      else if(%opt == "ban")
      {
         if(%clientId.isSuperAdmin)
         {
            %numcount = 0;
            Client::buildMenu(%clientId, "Ban Time:", "baffirm", true);
            Client::addMenuItem(%clientId, %numcount++ @ "10 Minutes", "600 " @ %cl);
            Client::addMenuItem(%clientId, %numcount++ @ "30 Minutes", "1800 " @ %cl);
            Client::addMenuItem(%clientId, %numcount++ @ "60 Minutes", "3600 " @ %cl);
            Client::addMenuItem(%clientId, %numcount++ @ "12 Hours", "43200 " @ %cl);
            Client::addMenuItem(%clientId, %numcount++ @ "24 Hours", "86400 " @ %cl);
            Client::addMenuItem(%clientId, %numcount++ @ "48 Hours", "172800 " @ %cl);
            Client::addMenuItem(%clientId, %numcount++ @ "72 Hours", "259200 " @ %cl);
         }
         return;
      }
      else if(%opt == "privatechat")
      {
         if(%cl != %clientId)
         {
            %clientId.privatechat = %cl;
            Client::sendMessage(%clientId, $MsgRed, Client::getName(%cl) @ " will now receive your private messages. Type: ==message here.");
         }
         else
            Client::sendMessage(%clientId, $MsgRed, "You cannot chat privately to yourself.");   
         return;
      }
      else if(%opt == "adminopts")
      {
         %curItem = 0;
         %name = Client::getName(%cl);
         Client::buildMenu(%clientId, "Admin Options:", "Options", true);
      
         Client::addMenuItem(%clientId, %curItem++ @ "Change team", "fteamchange " @ %cl);    
         Client::addMenuItem(%clientId, %curItem++ @ "Kick", "kick " @ %cl);  
         if(%clientId.isSuperAdmin)
         {
            Client::addMenuItem(%clientId, %curItem++ @ "Ban", "ban " @ %cl);
            if(!%cl.isAdmin)            
               Client::addMenuItem(%clientId, %curItem++ @ "Admin", "admin " @ %cl);
            else if(!%cl.isSuperAdmin)
               Client::addMenuItem(%clientId, %curItem++ @ "UnAdmin", "unadmin " @ %cl);
            if(!%cl.isSuperAdmin)
               Client::addMenuItem(%clientId, %curItem++ @ "Punish", "punishmenu " @ %cl);
         }
         return;
      }
      else if(%opt == "eject")
      {
         if(%clientId.isAdmin)
         {
            DropFootball(%cl, True);
            Player::unMountItem(Client::getOwnedObject(%cl), $FlagSlot);
            GameBase::setEnergy(Client::getOwnedObject(%cl), 0);
            messageAll($MsgRed, Client::getName(%cl) @ " was ejected from the stadium by " @ Client::getName(%clientId) @ "!");
            Player::applyImpulse(%cl, "0 0 2000");
         }
         return;
      }
      else if(%opt == "telecurse")
      {
         if(%clientId.isAdmin)
         {
            messageAll($MsgRed, Client::getName(%cl) @ " was given the teleport curse by " @ Client::getName(%clientId) @ "!");
            %cl.telecurse = true;
            teleCursePlayer(%cl);
         }
         return;
      }
      else if(%opt == "telecurseremove")
      {
         if(%clientId.isAdmin)
         {
            messageAll($MsgRed, Client::getName(%cl) @ "was relieved of the teleport curse by " @ Client::getName(%clientId) @ ".");
            %cl.telecurse = false;
         }
         return;
      }
      else if(%opt == "punishmenu")
      {
         Client::buildMenu(%clientId, "Punishment Options:", "Options", true);
         if($GlobalMute[%cl])
            Client::addMenuItem(%clientId, %curItem++ @ "UnSilence", "unsilence " @ %cl);
         else if(!%cl.isSuperAdmin)
            Client::addMenuItem(%clientId, %curItem++ @ "Silence", "silence " @ %cl);
         if(%cl.frozen)
            Client::addMenuItem(%clientId, %curItem++ @ "UnFreeze", "unfreeze " @ %cl);
         else if(!%cl.isSuperAdmin)
            Client::addMenuItem(%clientId, %curItem++ @ "Freeze", "freeze " @ %cl);
         if(%cl.telecurse)
            Client::addMenuItem(%clientId, %curItem++ @ "Relieve Teleport Curse", "telecurseremove " @ %cl);
         else if(!%cl.isSuperAdmin)
            Client::addMenuItem(%clientId, %curItem++ @ "Give Teleport Curse", "telecurse " @ %cl);
         Client::addMenuItem(%clientId, %curItem++ @ "Eject", "eject " @ %cl);
         Client::addMenuItem(%clientId, %curItem++ @ "Possess", "possess " @ %cl);
         return;
      }      
      else if(%opt == "unfreeze")
      {
         if(%clientId.isAdmin)
         {
            Client::setControlObject(%cl, %cl);
            Client::sendMessage(%cl, $MsgRed, "You have been granted the ability to move again by " @ Client::getName(%clientId) @ ". Don't abuse it."); 
            for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
               if(%id != %cl)
                  Client::sendMessage(%id, $MsgRed, Client::getName(%cl) @ " was unfrozen by " @ Client::getName(%clientId) @ ".");  
            %cl.frozen = false;    
         }
         return;
      }
      else if(%opt == "reset")
      {
         if(%clientId.isAdmin)
         {
            Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
            Client::addMenuItem(%clientId, "1Reset", "yes");
            Client::addMenuItem(%clientId, "2Don't Reset", "no");
         }
         return;
      }
      else if(%opt == "freeze")
      {
         if(%clientId.isAdmin)
         {
            if(Client::getControlObject(%cl) != Client::getObserverCamera(%cl))
               freezePlayer(%cl);
            %cl.frozen = true;
         
            Client::sendMessage(%cl, $MsgRed, Client::getName(%clientId) @ " froze you!"); 
            for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
               if(%id != %cl)
                  Client::sendMessage(%id, $MsgRed, Client::getName(%cl) @ " was frozen by " @ Client::getName(%clientId) @ ".");      
         }         
         return;
      }      
      else if(%opt == "vcmission" || %opt == "cmission")
      {
      $snmvar = false;
      $msetmapvar = false;
         if(%opt == "vcmission" && %clientId.isAdmin)
         $AdminVoteMis = true;
         else if(%opt == "cmission" && %clientId.isAdmin)
         $AdminVoteMis = false;
         Admin::changeMissionMenu(%clientId, %opt == "cmission");
         return;
      }
      else if(%opt == "snm")
      {
         if(%clientId.isAdmin)
         {
         $snmvar = true;
            Admin::changeMissionMenu(%clientId);
         }
         return;
      }
      else if(%opt == "aopts")
      {
         %number = 0;
         Client::buildMenu(%clientId, "Admin Options:", "Options", true);
         Client::addMenuItem(%clientId, %number++ @ "Change stadium", "cmission");
         Client::addMenuItem(%clientId, %number++ @ "Set Next Mission", "snm");
         if($Server::TeamDamageScale == 1.0)
            Client::addMenuItem(%clientId, %number++ @ "Disable team damage", "dtd");
         else
            Client::addMenuItem(%clientId, %number++ @ "Enable team damage", "etd");          
      
         Client::addMenuItem(%clientId, %number++ @ "Set Time Limit", "ctimelimit");
         Client::addMenuItem(%clientId, %number++ @ "Reset Server Defaults", "reset");
      
         return;
      
      }
      else if(%opt == "ctimelimit")
      {
         if(%clientId.isAdmin)
         {
            Client::buildMenu(%clientId, "Change Time Limit (per half):", "ctlimit", true);
            Client::addMenuItem(%clientId, "15 Minutes", 5);
            Client::addMenuItem(%clientId, "210 Minutes", 10);
            Client::addMenuItem(%clientId, "315 Minutes", 15);
            Client::addMenuItem(%clientId, "420 Minutes", 20);
            Client::addMenuItem(%clientId, "525 Minutes", 25);
            Client::addMenuItem(%clientId, "630 Minutes", 30);
            Client::addMenuItem(%clientId, "745 Minutes", 45);
            Client::addMenuItem(%clientId, "8No Time Limit", 0);
         }
         return;
      }
      else if(%opt == "observe")
      {
         Observer::setTargetClient(%clientId, %cl);
         return;
      }
      Game::menuRequest(%clientId);
   }
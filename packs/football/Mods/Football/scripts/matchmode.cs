function MResetVars() {
      while($MNumClients > 0) {
$MNumClients--;
%name = $MName::[$MNumClients];
   $MNum::[%name] = "";
   $MName::[$MNumClients] = "";
   $MTouchdowns::[$MNumClients] = 0;
   $MFumbles::[$MNumClients] = 0;
   $MWasFumbled::[$MNumClients] = 0;
   $MWasTackled::[$MNumClients] = 0;
   $MTackles::[$MNumClients] = 0;
   $MAssists::[$MNumClients] = 0;
   $MInterceptions::[$MNumClients] = 0;
   $MTeam::[$MNumClients] = "";
      }
}   
function Mstartpug()
   {
   $MOldName[1] = $Server::teamName[1];
   $MOldName[0] = $Server::teamName[0];
      deleteObject($CurrentFootball);
   $CurrentFootball = "";
   $footballExists = "";
   $MMode = true;
   $MPUG = true;
   $MMatchStarted = false;
      MReset();
      for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id)) {
         MSetPlayerTeam(%id, -2, true);
         Game::menuRequest(%id);
      }
   }

   function MSetPlayerTeam(%changed, %team, %override) {
   
      %num = $MNum::[Client::getName(%changed)];
   $MTeam::[%num] = %team;
      %player = Client::getOwnedObject(%changed);
      if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
      {
         playNextAnim(%changed);
         Player::kill(%changed);
      }
   
      if(!$MMatchStarted && !%override)
      {
      //do nothing
      }
      else if(%team < 0)
         Observer::enterObserverMode(%changed);
      else {
         GameBase::setTeam(%changed, %team);
         %changed.teamEnergy = 0;
         Client::clearItemShopping(%changed);
         if(Client::getGuiMode(%changed) != 1)
            Client::setGuiMode(%changed,1);		
         Client::setControlObject(%changed, -1);
      
         Game::playerSpawn(%changed, false);
      
         if($TeamEnergy[%team] != "Infinite")
         $TeamEnergy[%team] += $InitialPlayerEnergy;
      
         if($MHalfCheck == true)
            freezePlayer(%changed);
      }
      Game::refreshClientScore(%changed);
      ObjectiveMission::refreshTeamScores();
   }
   function MStart() {
      Server::loadMission($MMap);
      messageAll(1, "Starting Match!");
   $MMap = "";
   $MMatchStarted = true;
   
   }
   function MNewClient(%name) {
      %y = $MNumClients;
   $MNum::[%name] = %y;
   $MName::[%y] = %name;
   $MTouchdowns::[%y] = 0;
   $MFumbles::[%y] = 0;
   $MWasFumbled::[%y] = 0;
   $MWasTackled::[%y] = 0;
   $MTackles::[%y] = 0;
   $MAssists::[%y] = 0;
   $MInterceptions::[%y] = 0;
   $MTeam::[%y] = -2;
   $MNumClients++;
   }
   function MResetClients() {
   $MNumClients = 0;
      %x = true;
      %temp = 0;
      while(%x)
      {
         if($MTouchdowns::[%temp] == "")
            %x = false;
         else
            %temp++;
      }
      for(%y = 0; %y < %temp; %y++)
      {
      $MTouchdowns::[%y] = "";
      $MFumbles::[%y] = "";
      $MWasFumbled::[%y] = "";
      $MAssists::[%y] = "";
      $MWasTackled::[%y] = "";
      $MTackles::[%y] = "";
      $MInterceptions::[%y] = "";
      $MTeam::[%y] = "";
      $MName::[%y] = "";
      }
      %y = 0;
      for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
      {
         if(%id.isCaptain)
            %id.isCaptain = false;
         %name = Client::getName(%id);
      $MNum::[%name] = %y;
      $MName::[%y] = %name;
      $MTouchdowns::[%y] = 0;
      $MFumbles::[%y] = 0;
      $MWasFumbled::[%y] = 0;
      $MAssists::[%y] = 0;
      $MInterceptions::[%y] = 0;
      $MTackles::[%y] = 0;
      $MWasTackled::[%y] = 0;
      $MTeam::[%y] = -2;
         %y++;
      }
   $MNumClients = %y;
   }
   function MReset() {
   $MMap = "";
   $MReady[1] = false;
   $MReady[0] = false;
   $MHalfCheck = "";
      MResetClients();
   }

   function MgetLoser() {
      if($teamScore[0] > $teamScore[1])
         %loser = 1;
      else if($teamScore[1] > $teamScore[0])
         %loser = 0;
      else
         %loser = -1;
   
      return %loser;
   }

   function Football::fileSafe(%s)
   {
      %ok = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 -_";
      %out = "";
      for(%i = 0; %i < 20; %i++)
      {
         %c = String::getSubStr(%s, %i, 1);
         if(%c != "" && String::findSubStr(%ok, %c) != -1)
            %out = %out @ %c;
      }
      if(%out == "")
         %out = "team";
      return %out;
   }
   function MEndMatch(%loser) {
      %winner = OppositeTeam(%loser);
   
      if(%loser == -1)
         %match = "football_match_" @ Football::fileSafe($Server::teamName[0]) @ " ties " @ Football::fileSafe($Server::teamName[1]) @ " at " @ $teamScore[0] @ ".cs";
      else
         %match = "football_match_" @ Football::fileSafe($Server::teamName[%winner]) @ " wins over " @ Football::fileSafe($Server::teamName[%loser]) @ " " @ $teamScore[%winner] @ " to " @ $teamScore[%loser] @ ".cs";
   
      for(%x = 0; %x < $MNumClients; %x++)
      {
         %name = $MName::[%x];
      $Touchdowns::[%name] = $MTouchdowns::[%x];
      $Interceptions::[%name] = $MInterceptions::[%x];
      $FumblesMade::[%name] = $MFumbles::[%x];
      $WasFumbled::[%name] = $MWasFumbled::[%x];
      $Assists::[%name] = $MAssists::[%x];
      $TacklesMade::[%name] = $MTackles::[%x];
      $WasTackled::[%name] = $MWasTackled::[%x];
      }
   
      export("$Touchdowns::*", "config\\" @ %match, true);
      export("$Interceptions::*", "config\\" @ %match, true);
      export("$Assists::*", "config\\" @ %match, true);
      export("$WasFumbled::*", "config\\" @ %match, true);
      export("$FumblesMade::*", "config\\" @ %match, true);
      export("$WasTackled::*", "config\\" @ %match, true);
      export("$TacklesMade::*", "config\\" @ %match, true);
   
      for(%x = 0; %x < $MNumClients; %x++)
      {
         %name = $MName::[%x];
      $TacklesMade::[%name] = "";
      $WasTackled::[%name] = "";
      $Touchdowns::[%name] = "";
      $Interceptions::[%name] = "";
      $FumblesMade::[%name] = "";
      $WasFumbled::[%name] = "";
      $Assists::[%name] = "";
      $MTouchdowns::[%x] = 0;
      $MInterceptions::[%x] = 0;
      $MFumbles::[%x] = 0;
      $MAssists::[%x] = 0;
      $MWasFumbled::[%x] = 0;
      $MWasTackled::[%x] = 0;
      $MTackles::[%x] = 0;
      }
      MResetForNew();
   
      for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
         Observer::enterObserverMode(%id);
   
      ObjectiveMission::missionComplete();
      if(%loser == -1) 
         messageAll(1, "GAME OVER: Congradulations to both teams!");
      else
         messageAll(1, "GAME OVER: Congradulations to " @ $Server::teamName[%winner] @ "!");
   }
   function MUnfreeze() {
   $MHalfCheck = "";
   
      DoSpawnFootball($MAfter);
   
      for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id)) {
         if($MTeam::[$MNum::[Client::getName(%id)]] > -1)
            Client::setControlObject(%id, %id);
      }
      messageAll($MsgRed, "SECOND HALF STARTING...NOW!~wlongwhistle.wav");
      UpdateClientTimes($server::timelimit * 60);
   $missionStartTime = getSimTime();
      Game::checkTimeLimit();
   }
   function MResetForNew() {
   $MReady[0] = false;
   $MReady[1] = false;
   $MMap = "";
   }
   function mfs() {
   
   
      if($MMap == "")
      $MMap = "Official_Stadium7";
   
      %rnd = getRandom();
      if(%rnd > 0.5)
      $MBefore = 0;
      else
      $MBefore = 1;
   
      if($MBefore == 1)
      $MAfter = 0;
      else
      $MAfter = 1;
   
      messageAll(1, $server::teamname[$MBefore] @ " has been randomly chosen to start off with the ball.");
   
      schedule("MStart();", 3);
   
   
   }

   function checkReady() {
      if($MReady[0] != true || $MReady[1] != true || ($MMatchStarted && $MHalfCheck == ""))
         return;
   
      if($MHalfCheck != "")
      {
         MUnfreeze();
         return;
      }
   
      if($MMap == "")
      $MMap = "Official_Stadium7";
   
      %rnd = getRandom();
      if(%rnd > 0.5)
      $MBefore = 0;
      else
      $MBefore = 1;
   
      if($MBefore == 1)
      $MAfter = 0;
      else
      $MAfter = 1;
   
      messageAll(1, $server::teamname[$MBefore] @ " has been randomly chosen to start off with the ball.");
   
      schedule("MStart();", 3);
   
   }
   function Football::onCollision(%this,%object)
   {
      %clientId = Player::getClient(%object);
   %type = getObjectType(%object);
%fteam = GameBase::getTeam(%this.owner);

      if(%type == "Player")
      {
         %item = Item::getItemData(%this);
         %count = Player::getItemCount(%object,%item);
      
         if(%item == Football)
         {
            if(!%clientId.tackled)
            {
               %armor = GameBase::getDataName(%object);
               %v = Vector::getDistance(Item::getVelocity(%this), "0 0 0");
               %vel = %v * 2.0;
               %mom = Vector::getFromRot( %this.rot, %vel * (6.5 / %armor.mass), 1 );
               Player::applyImpulse(%clientId, %mom);
            
               GainFootball(%clientId);
               Item::playPickupSound(%this);
            
               %pteam = GameBase::getTeam(%clientId);
               %name = Client::getName(%clientId);
            
if(!($Wall1::[%pteam] || $Wall2::[%pteam]))
resetqpteams();

               if(%fteam == -1 || floor(%vel / 2.2) == 0)
                  TeamMessages($MsgWhite, %pteam, %name @ " picks up the football.", %fteam, %name @ " picked up the football.");
               else if(%fteam != %pteam && %v > 1) {
                  TeamMessages($MsgRed, %pteam, %name @ " intercepts the football!~wflagreturn.wav", %fteam, %name @ " intercepted the ball.");
                  if($MMode && $MMatchStarted)              
                  $MInterceptions::[$MNum::[%name]]++;
               }
               else
                  TeamMessages($MsgWhite, %pteam, %name @ " catches the ball.", %fteam, %name @ " caught the football.");
            
               if($InfJet)
                  GameBase::setRechargeRate(Client::getOwnedObject(%clientId), $rechargeRate[Player::getArmor(%clientId)]);
               deleteObject(%this);
            }
         }
         else
         {
            if(Item::giveItem(%object,%item,Item::getCount(%this)))
            {
               Item::playPickupSound(%this);
               Item::respawn(%this);
            }
            else if(%item == FootballThrower && getRandom() * 100 < $gunFumbleChance && Player::getItemCount(%object, Football) > 0)
            {
               %name = Client::getName(%clientId);
            
               messageAll($MsgWhite, %name @ " was fumbled by a football thrower!");
               if($MMode)
               $MWasFumbled::[$MNum::[%name]]++;
               LoseFootball(%clientId, "fumble");
            }
         }
      }
	else if(GameBase::getDataName(%object) == "HTwoPanel" && getappropriateteam(%fteam) == Gamebase::getTeam(%object)) {
%wallside = getWallSide(%object);
if((%wallside == 1 && $Wall1::[%fteam]) || (%wallside == 2 && $Wall2::[%fteam]))
return;

if(%wallside == 1) {
$Wall1::[%fteam] = true;
if($Wall2::[%fteam])
MessageAll($MsgWhite,getteamname(%fteam) @ " can now score quad points!");
else
MessageAll($MsgWhite,getteamname(%fteam) @ " can now score double points!");
}
else if(%wallside == 2) {
$Wall2::[%fteam] = true;
if($Wall1::[%fteam])
MessageAll($MsgWhite,getteamname(%fteam) @ " can now score quad points!");
else
MessageAll($MsgWhite,getteamname(%fteam) @ " can now score double points!");
}

}
   }
function getotherwallside(%side)
{
if(%side == 1)
return 2;
if(%side == 2)
return 1;
}
function getWallSide(%object)
{
%n = Object::getName(%object);
if(%n == "qp01" || %n == "qp11")
return 1;
else if(%n == "qp02" || %n == "qp12")
return 2;
else
return 3;
}
function GroupTrigger::onTrigger(%object, %this)
   {
      %clientId = Player::getClient(%this);
   
      if($MMode)
         %pteam = $MTeam::[$MNum::[Client::getName(%clientId)]];
      else
         %pteam = GameBase::getTeam(%clientId);
      %gteam = AppropriateSide(GameBase::getTeam(%object));
   
      if(%pteam != %gteam && Player::getItemCount(%clientId, Football))
      {
         %name = Client::getName(%clientId);
         if($MMode && $MMatchStarted) {
            %num = $MNum::[%name];
            %last = $MNum::[Client::getName($MLastPasser)];
            if($MTeam::[%num] == $MTeam::[%last] && %num != %last)
            $MAssists::[%last]++;
         $MTouchdowns::[%num]++;
         }
         MessageAllExcept(%clientId, $MsgWhite, %name @ " scored a touchdown!~wflagcapture.wav");
         echo("ADMINMSG: **** " @ %name @ " scored a touchdown.");//for TRICON compatibility
         Client::sendMessage(%clientId, $MsgWhite, "~wflagcapture.wav");
         Client::sendMessage(%clientId, $MsgWhite, "You scored a touchdown!~wtouchdowncheer.wav");
         TeamMessages($MsgRed, %pteam, "Your team scored a touchdown.", %gteam, "The other team scored a touchdown.~wtouchdownboo.wav");
      
         LoseFootball(%clientId);
      $footballExists = "";

%addedtoscore = 1;
if($Wall1::[%pteam] || $Wall2::[%pteam]) {
%addedtoscore = 2;
if($Wall1::[%pteam] && $Wall2::[%pteam])
%addedtoscore = 4;
}

resetqpteams();
      $teamScore[%pteam] = $teamScore[%pteam] + %addedtoscore;
	if($Server::timelimit != 0)
         ObjectiveMission::checkScoreLimit();
      
         %clientId.score += 5;
         Game::refreshClientScore(%clientId);
         messageAll(0, %name @ " receives a 5 point touchdown bonus.");
         schedule("DoSpawnFootball(" @ %gteam @ ");", 10);
         schedule("SendPlayersToStart();", 6);
      }
   
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
function resetqpteams()
{
$Wall1::[0] = false;
$Wall1::[1] = false;
$Wall2::[0] = false;
$Wall2::[1] = false;
}
resetqpteams();
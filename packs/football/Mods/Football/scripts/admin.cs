//The "No Admin Vote" script for Tribes 1 Football servers.
//Available from the Tribes Football files archive; http://amishrabbit.com/tribes/files/
//Thanks to [*HF] JOB <job@homelanfed.com>, admin for HomeLAN Tribes servers,
// for providing this script.
//Place in the Tribes\config folder for each server and restart the server.
//Modify to disable Admin and/or Kick voting, while permitting other types of voting.
//This version modified to allow kick voting, while denying admin voting.
//Removed the TAB-1-1 menu item that permits teamchanging cheating. 6 Feb 2001
//Modified to remove "I" inventory and "C" map commands, which cause a majority of bugs, by Greasey May 2002
//8/29/03 added vote dodge bug fix - taserman
$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

   function Admin::changeMissionMenu(%clientId, %voteit)
   {
      Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
      %index = 1;
   //DEMOBUILD - the demo build only has one "type" of missions
      if ($MList::TypeCount < 2) $TypeStart = 0;
      else $TypeStart = 1;
      for(%type = $TypeStart; %type < $MLIST::TypeCount; %type++)
         if($MLIST::Type[%type] != "Training")
         {
            if(%index == 8 && $MLIST::TypeCount > 8)
            {
               Client::addMenuItem(%clientId, %index @ "More Types...", "more 8 " @ %voteit); 
               break; 
            }
            Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
            %index++;
         }
   }



   function processMenuCMoo(%clientId, %first, %voteit)
   {
      Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true); 
      %index = 1; 
      for(%type = %first; %type < $MLIST::TypeCount; %type++)
      {
         if($MLIST::Type[%type] != "Training")
         {
            if(%index == 8 && $MLIST::TypeCount > %first + %index)
            {
               Client::addMenuItem(%clientId, %index @ "More Types...", "more " @ %first + %index @ " " @ %voteit); 
               break; 
            }
            Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0 " @ %voteit); 
            %index++; 
         } 
      }
   }



   function processMenuCMType(%clientId, %options)
   {
      %curItem = 0;
      %option = getWord(%options, 0);
      %first = getWord(%options, 1);
      %voteit = getWord(%options, 2);
      if(%option == "more")
      {
         processMenuCMoo(%clientId, %first, %voteit); 
         return; 
      }
      Client::buildMenu(%clientId, "Pick Stadium", "cmission", true);
   
      for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
      {
         if(%i > 6)
         {
            Client::addMenuItem(%clientId, %i+1 @ "More stadiums...", "more " @ %first + %i @ " " @ %option);
            break;
         }
         Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option);
      }
   }

   function processMenuCMission(%clientId, %option)
   {
      if(getWord(%option, 0) == "more")
      {
         %first = getWord(%option, 1);
         %type = getWord(%option, 2);
         processMenuCMType(%clientId, %type @ " " @ %first);
         return;
      }
      %mi = getWord(%option, 0);
      %mt = getWord(%option, 1);
   
      %misName = $MLIST::EName[%mi];
      %misType = $MLIST::Type[%mt];
   
   // verify that this is a valid mission:
      if(%misType == "" || %misType == "Training")
         return;
      for(%i = 0; true; %i++)
      {
         %misIndex = getWord($MLIST::MissionList[%mt], %i);
         if(%misIndex == %mi)
            break;
         if(%misIndex == -1)
            return;
      }
      if((($MPUG && %clientId.isCaptain) || %clientId.isAdmin) && !$AdminVoteMis)
      {
         if($msetmapvar)
         {
         $MMap = %misName;
            messageAll(1, Client::getName(%clientId) @ " set the match stadium to " @ %misName @ " (" @ %misType @ ")");
         }
         else if($snmvar)
         {
         $setNextMission = %misName;
            messageAll(0, Client::getName(%clientId) @ " set the next stadium to " @ %misName @ " (" @ %misType @ ")");
         }
         else
         {
            messageAll(0, Client::getName(%clientId) @ " changed the stadium to " @ %misName @ " (" @ %misType @ ")");
            Vote::changeMission();
            Server::loadMission(%misName);
         }
      }
      else
      {
         Admin::startVote(%clientId, "change the stadium to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
         Game::menuRequest(%clientId);
      }
   }
   function remoteAdminPassword(%client, %password)
   {
%client.tries++;
if(%client.tries > 5)
{
	if(%client.gone)
	{
		return;
	}
	%name = client::getName(%client);
	Admin::Exploit(%client, "SAD() Password Spam");
	banlist::add(client::getTransportAddress(%client), 300);
	messageall(0, %name@" Was Kicked For Spamming Admin Passwords");
	kick(%client, "You Were Kicked For Spamming Admin Passwords");
	%client.gone = true;
	return;
}
schedule(%client@".tries = 0;", 0.5);

      if($SuperAdminPassword != "" && %password == $SuperAdminPassword)
      {
         %client.isAdmin = true;
         %client.isSuperAdmin = true;
         echo(Client::getName(%client) @ " used SAD to gain Super Admin");
      }
      else if($AdminPassword != "" && %password == $AdminPassword)
      {
         %client.isAdmin = true;
         echo(Client::getName(%client) @ " used SAD to gain Public Admin");
      }
      else {
         if(!$badAttempts[%client])
         $badAttempts[%client] = 1;
         else
         $badAttempts[%client]++;
         if($badAttempts[%client] == $maxSADTries) {
            %ip = Client::getTransportAddress(%client);
            if(%ip == "")
               return;
         
            BanList::add(%ip, 3600);
            schedule("Net::Kick(" @ %client @ ");",0.5);
         
            MessageAll(1, Client::getName(%client) @ " was banned for attempting to gain SAD " @ $maxSADTries @ " times.");
         
         }
         else
            Client::sendMessage(%client, 1, "You have " @ ($maxSADTries - $badAttempts[%client]) @ " SAD attempts left before you are banned.");
      }
   }

   function remoteSetPassword(%client, %password)
   {
      if(%client.isSuperAdmin)
      $Server::Password = %password;
   }

   function remoteSetTimeLimit(%client, %time)
   {
      %time = floor(%time);
      if(%time == $Server::timeLimit || (%time != 0 && %time < 1))
         return;
      if(%client.isAdmin || ($MMode && %client.isCaptain))
      {
      $Server::timeLimit = %time;
         if(%time)
            messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s).");
         else
            messageAll(0, Client::getName(%client) @ " disabled the time limit.");
      
      }
   }

   function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
   {
      if(%team >= 0 && %team < 8 && %client.isAdmin)
      {
      $Server::teamName[%team] = %teamName;
      $Server::teamSkin[%team] = %skinBase;
         messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " 
                   @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next match.");
      }
   }

   function remoteVoteYes(%clientId)
   {
      %clientId.vote = "yes";
      centerprint(%clientId, "", 0);
   }

   function remoteVoteNo(%clientId)
   {
      %clientId.vote = "no";
      centerprint(%clientId, "", 0);
   }

   function Admin::startMatch(%admin)
   {
      if(%admin == -1 || %admin.isAdmin)
      {
         if(!$CountdownStarted && !$matchStarted)
         {
            if(%admin == -1)
               messageAll(0, "Match start countdown forced by vote.");
            else
               messageAll(0, "Match start countdown forced by " @ Client::getName(%admin));
         
            Game::ForceTourneyMatchStart();
         }
      }
   }

   function Admin::setTeamDamageEnable(%admin, %enabled)
   {
      if(%admin == -1 || %admin.isAdmin)
      {
         if(%enabled)
         {
         $Server::TeamDamageScale = 1;
            if(%admin == -1)
               messageAll(0, "Team damage set to ENABLED by consensus.");
            else
               messageAll(0, Client::getName(%admin) @ " ENABLED team damage.");
         }
         else
         {
         $Server::TeamDamageScale = 0;
            if(%admin == -1)
               messageAll(0, "Team damage set to DISABLED by consensus.");
            else
               messageAll(0, Client::getName(%admin) @ " DISABLED team damage.");
         }
      }
   }

   function Admin::kick(%admin, %client, %ban, %time)
   {
      if((%admin != %client || $LastVoteIP == Client::getTransportAddress(%client)) && (%admin == -1 || %admin.isAdmin))
      {
         if(%ban && !%admin.isSuperAdmin)
            return;
      
         if(%ban)
         {
            %word = "banned";
            %cmd = "BAN: ";
         }
         else
         {
            %word = "kicked";
            %cmd = "KICK: ";
         }
         if(%client.isAdmin && !%admin.isSuperAdmin)
         {
            if(%admin == -1)
               messageAll(0, "You cannot " @ %word @ "a admin.");
            else
               Client::sendMessage(%admin, 0, "You cannot " @ %word @ "a admin.");
            return;
         }
         %ip = Client::getTransportAddress(%client);
         echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);
      
         if(%ip == "")
            return;
         if(%ban)
            BanList::add(%ip, %time);
         else
            BanList::add(%ip, 300);
      
         %name = Client::getName(%client);
      
         if(%admin == -1)
         {
            MessageAll(0, %name @ " was " @ %word @ " from vote.");
            Net::kick(%client, "You were " @ %word @ " by  consensus.");
         }
         else
         {
            MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
            Net::kick(%client, "You were " @ %word @ " by " @ Client::getName(%admin));
         }
      }
   }

   function Admin::setModeFFA(%clientId)
   {
      if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
      {
      $Server::TeamDamageScale = 0;
         if(%clientId == -1)
            messageAll(0, "Server switched to Free-For-All Mode.");
         else
            messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".");
      
      $Server::TourneyMode = false;
         centerprintall(); // clear the messages
         if(!$matchStarted && !$countdownStarted)
         {
            if($Server::warmupTime)
               Server::Countdown($Server::warmupTime);
            else   
               Game::startMatch();
         }
      }
   }

   function Admin::setModeTourney(%clientId)
   {
      if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
      {
      $Server::TeamDamageScale = 1;
         if(%clientId == -1)
            messageAll(0, "Server switched to Tournament Mode.");
         else
            messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".");
      
      $Server::TourneyMode = true;
         Server::nextMission();
      }
   }

   function Admin::voteFailed()
   {
  
   $curVoteInitiator.numVotesFailed++;
   
      if($curVoteAction == "kick" || $curVoteAction == "admin")
      $curVoteOption.voteTarget = "";
   }

   function Admin::voteSucceded()
   {
   
   $curVoteInitiator.numVotesFailed = "";
      if($curVoteAction == "kick")
      {
         if($curVoteOption.voteTarget)
            Admin::kick(-1, $curVoteOption);
      }
      if($curVoteAction == "cap")
      {
         if($curVoteOption.voteTarget)
         {
         $curVoteOption.isCaptain = true;
            messageAll(0, Client::getName($curVoteOption) @ " has become a captain.");
         }
      }
      else if($curVoteAction == "admin")
      {
         if($curVoteOption.voteTarget)
         {
         $curVoteOption.isAdmin = true;
            messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.");
            if($curVoteOption.menuMode == "options")
               Game::menuRequest($curVoteOption);
         }
      $curVoteOption.voteTarget = false;
      }
      else if($curVoteAction == "hpmoff")
      {
      $HPM = false;
         messageAll($MsgRed, "Hot-Patato Mode has been turned off by vote.");
      }
      else if($curVoteAction == "cmission")
      {
         messageAll(0, "Changing to stadium " @ $curVoteOption @ ".");
         Vote::changeMission();
         Server::loadMission($curVoteOption);
      }
      else if($curVoteAction == "tourney")
         Admin::setModeTourney(-1);
      else if($curVoteAction == "ffa")
         Admin::setModeFFA(-1);
      else if($curVoteAction == "etd")
         Admin::setTeamDamageEnable(-1, true);
      else if($curVoteAction == "dtd")
         Admin::setTeamDamageEnable(-1, false);
      else if($curVoteOption == "smatch")
         Admin::startMatch(-1);
      else if($curVoteAction == "spug")
         Mstartpug();
      else if($curVoteAction == "toff")
      {
      $Server::timeLimit = 0;
         messageAll(0, "The time limit has been disabled.");
      }
      else if($curVoteAction == "ton") {
         messageAll(0, "The time limit has been enabled.");
      $Server::timeLimit = 15;
      }
      else if($curVoteAction == "tatdon")
      $TATD = true;
      else if($curVoteAction == "tatdoff")
      $TATD = false;
      else if($curVoteAction == "gfonV") {
      $GunFumbleVar = true;
         messageall(1,"Gun Fumble is now ON at " @ $gunFumbleChance @ "%.");
      }
      else if($curVoteAction == "gfoffV") {
      $GunFumbleVar = false;
         messageall(1,"Gun Fumble is now OFF.");
      }
   }

   function Admin::countVotes(%curVote)
   {
   // if %end is true, cancel the vote either way
      if(%curVote != $curVoteCount)
         return;
   $LastVoteIP = 0;
      %votesFor = 0;
      %votesAgainst = 0;
      %votesAbstain = 0;
      %totalClients = 0;
      %totalVotes = 0;
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %totalClients++;
         if(%cl.vote == "yes")
         {
            %votesFor++;
            %totalVotes++;
         }
         else if(%cl.vote == "no")
         {
            %votesAgainst++;
            %totalVotes++;
         }
         else
            %votesAbstain++;
      }
      %minVotes = floor($Server::MinVotesPct * %totalClients);
      if(%minVotes < $Server::MinVotes)
         %minVotes = $Server::MinVotes;
   
      if(%totalVotes < %minVotes)
      {
         %votesAgainst += %minVotes - %totalVotes;
         %totalVotes = %minVotes;
      }
      %margin = $Server::VoteWinMargin;
      if($curVoteAction == "admin")
      {
         %margin = $Server::VoteAdminWinMargin;
         %totalVotes = %votesFor + %votesAgainst + %votesAbstain;
         if(%totalVotes < %minVotes)
            %totalVotes = %minVotes;
      }
      if(%votesFor / %totalVotes >= %margin || (!$NoMajorityRules && %votesFor / getNumClients() > 0.5))
      {
         messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
         Admin::voteSucceded();
      }
      else  // special team kick option:
      {
         if($curVoteAction == "kick") // check if the team did a majority number on him:
         {
            %votesFor = 0;
            %totalVotes = 0;
            for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
            {

                  %totalVotes++;
                  if(%cl.vote == "yes")
                     %votesFor++;
               
            }
            if(%totalVotes >= $Server::MinVotes && %votesFor / %totalVotes >= $Server::VoteWinMargin)
            {
               messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ ".");
               Admin::voteSucceded();
            $curVoteTopic = "";
               return;
            }
         }
         messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
         Admin::voteFailed();
      }
   $curVoteTopic = "";
   $AdminVoteMis = false;
   }

   function Admin::startVote(%clientId, %topic, %action, %option)
   {
      if(%clientId.lastVoteTime == "")
         %clientId.lastVoteTime = -$Server::MinVoteTime;
   
   // we want an absolute time here.
      %time = getIntegerTime(true) >> 5;
      %diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time;
   
      if(%diff > 0)
      {
         Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
         return;
      }
      if($curVoteTopic == "")
      {
         if(%clientId.numFailedVotes)
            %time += %clientId.numFailedVotes * $Server::VoteFailTime;
      
         %clientId.lastVoteTime = %time;
      $curVoteInitiator = %clientId;
      $curVoteTopic = %topic;
      $curVoteAction = %action;
      $curVoteOption = %option;
      $curVoteCount++;
      $abletocount = true;
         messageAll(1, Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic);
         bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
         echo($curVoteOption.voteTarget);
         for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
            %cl.vote = "";
         %clientId.vote = "yes";
         for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
            if(%cl.menuMode == "options")
               Game::menuRequest(%clientId);
         schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", $Server::VotingTime, 35);
      }
      else
      {
         Client::sendMessage(%clientId, 0, "Voting already in progress.");
      }
   }
   function matchMenuRequest(%clientId)
   {	
      %cname = Client::getName(%clientId);
      %team = $MTeam::[$MNum::[%cname]];
      %curItem = 0;
      if(%clientId.selClient)
      {
         %sel = %clientId.selClient;
         %name = Client::getName(%sel);
         if(%sel.isAdmin || %sel.isCaptain)
            if($MTeam::[$MNum::[Client::getName(%sel)]] < 0)
               Client::buildMenu(%clientId, %name @ ": C - Spectator", "options", true);
            else
               Client::buildMenu(%clientId, %name @ ": C - " @ $Server::teamName[$MTeam::[$MNum::[Client::getName(%sel)]]], "options", true);
         else
            if($MTeam::[$MNum::[Client::getName(%sel)]] < 0)
               Client::buildMenu(%clientId, %name @ ": Spectator", "options", true);
            else
               Client::buildMenu(%clientId, %name @ ": " @ $Server::teamName[$MTeam::[$MNum::[Client::getName(%sel)]]], "options", true);
         if(%clientId.muted[%sel])
            Client::addMenuItem(%clientId, %curItem++ @ "Unmute", "unmute " @ %sel);
         else
            Client::addMenuItem(%clientId, %curItem++ @ "Mute", "mute " @ %sel);
         if($MPUG && $curVoteTopic == "")
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to Captain", "votecap " @ %sel); 
      
         Client::addMenuItem(%clientId, %curItem++ @ "Chat Privately", "privatechat " @ %sel); 
         if($MTeam::[$MNum::[%cname]] == -2 && $MTeam::[$MNum::[%name]] != -2)
            Client::addMenuItem(%clientId, %curItem++ @ "Observer Options", "observeroptions " @ %sel); 
         if(%clientId.isAdmin || %clientId.isCaptain)
            Client::addMenuItem(%clientId, %curItem++ @ "Set Team", "msetteam " @ %sel);
         if(%clientId.isAdmin && !%sel.isSuperAdmin)
         {
            Client::addMenuItem(%clientId, %curItem++ @ "Kick", "kick " @ %sel);  
            if(%clientId.isSuperAdmin) {
               Client::addMenuItem(%clientId, %curItem++ @ "Ban", "ban " @ %sel);

            if(%sel.isCaptain)
               Client::addMenuItem(%clientId, %curItem++ @ "Remove Captain", "muncaptain " @ %sel);
            else
               Client::addMenuItem(%clientId, %curItem++ @ "Make Captain", "mcaptain " @ %sel);
}
         }
      }
      else if(%clientId.isCaptain || %clientId.isAdmin)
      {
         if(%team < 0)
            Client::buildMenu(%clientId, "Match Mode : C - Spectator", "options", true);
         else
            Client::buildMenu(%clientId, "Match Mode : C - " @ $Server::teamName[%team], "options", true);
         if(!$MMatchStarted)
         {
            if($MPUG)
               Client::addMenuItem(%clientId,  %curItem++ @ "End PUG Mode", "ematch");
            else
               Client::addMenuItem(%clientId,  %curItem++ @ "End Match Mode", "ematch");
         }          
         Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit"); 
         if($MMatchStarted && $MTeam::[$MNum::[%cname]] > -1) {
            Client::addMenuItem(%clientId, %curItem++ @ "Forfeit", "mforfeit");
            if(%team > -1 && $MHalfCheck != "")
               if($MReady[%team])
                  Client::addMenuItem(%clientId, %curItem++ @ "NOT READY", "mnready");
               else
                  Client::addMenuItem(%clientId, %curItem++ @ "READY", "mready");	
         }
         else if(!$MMatchStarted) {
            if($HPM)
               Client::addMenuItem(%clientId, %curItem++ @ "Hot-Patato Mode OFF", "hpmodeoff");
            else
               Client::addMenuItem(%clientId, %curItem++ @ "Hot-Patato Mode ON", "hpmodeon");
            Client::addMenuItem(%clientId, %curItem++ @ "Set Team Names", "msetteamnames");
            Client::addMenuItem(%clientId, %curItem++ @ "Set Map", "msetmap " @ %sel);
            if(%team > -1)
               if($MReady[%team])
                  Client::addMenuItem(%clientId, %curItem++ @ "NOT READY", "mnready");
               else
                  Client::addMenuItem(%clientId, %curItem++ @ "READY", "mready");	
         }
      }
      else {
         if(%team < 0)
            Client::buildMenu(%clientId, "Match Mode : Spectator", "options", true);
         else
            Client::buildMenu(%clientId, "Match Mode : " @ $Server::teamName[%team], "options", true);
         if($curVoteTopic != "" && %clientId.vote == "" && !%clientId.selClient)
         {
            Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
            Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
         }
      
      }
   }






   function Game::menuRequest(%clientId)
   {
%clientId.tries++;
if(%clientId.tries > 10)
{
	if(%clientId.gone)
	{
		return;
	}
	%name = client::getName(%clientId);
	Log::Exploit(%clientId, "Server-Crash", "remoteScoresOn");
	banlist::add(client::getTransportAddress(%clientId), 999);
	kick(%clientId, "You Were Kicked For Spamming remoteScoresOn");
	%clientId.gone = true;
	return;
}
schedule(%clientId@".tries = 0;", 0.5);

      if($MMode) {
         matchMenuRequest(%clientId);
         return;
      }
      %curItem = 0;
      if(%clientId.selClient)
      
         if(%clientId.selClient)
         {
            %sel = %clientId.selClient;
            %name = Client::getName(%sel);
            Client::buildMenu(%clientId, Client::getName(%sel), "options", true);
            if($curVoteTopic == "")
            {
               if($VoteAdminAllowed)
                  Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin", "vadmin " @ %sel);
               Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick", "vkick " @ %sel);
            }
            Client::addMenuItem(%clientId, %curItem++ @ "Chat privately", "privatechat " @ %sel);
            if(%clientId.muted[%sel])
               Client::addMenuItem(%clientId, %curItem++ @ "Unmute", "unmute " @ %sel);
            else
               Client::addMenuItem(%clientId, %curItem++ @ "Mute", "mute " @ %sel);
            if(%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly" || %clientId.observerMode == "observerFootball")
               Client::addMenuItem(%clientId, %curItem++ @ "Observer Options", "observeroptions " @ %sel); 
            if(Client::getTeam(%sel) >= 0 && !%sel.afkchecking)
               Client::addMenuItem(%clientId, %curItem++ @ "Check if AFK", "afkcheck " @ %sel);           
            if(%clientId.isAdmin)
            {
               Client::addMenuItem(%clientId, %curItem++ @ "Admin Options", "adminopts " @ %sel);	
            }    
         }
      if(!%clientId.selClient) {
         Client::buildMenu(%clientId, $curVersion, "options", true);
         if((!$matchStarted || !$Server::TourneyMode) && !%clientId.frozen)
            Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
      }    
      if($curVoteTopic != "" && !%clientId.selClient)
      {
         if(%clientId.vote == "") {
            Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
            Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
         }  
      }
      else if($curVoteTopic == "" && !%clientId.selClient)
         Client::addMenuItem(%clientId, %curItem++ @ "Start a vote", "votemenu");
   
      if(%clientId.isAdmin && !%clientId.selClient)
      {
         if(%clientId.possessId != "")
            Client::addMenuItem(%clientId, %curItem++ @ "Revert", "revert");
         Client::addMenuItem(%clientId, %curItem++ @ "Admin Options", "aopts");
      }
   }

   function remoteSelectClient(%clientId, %selId)
   {
%clientId.tries++;
if(%clientId.tries > 10)
{
	if(%clientId.gone)
	{
		return;
	}
	%name = client::getName(%clientId);
	Log::Exploit(%clientId, "Server-Crash", "remoteSelectClient");
	banlist::add(client::getTransportAddress(%clientId), 999);
	kick(%clientId, "You Were Kicked For Spamming remoteSelectClient");
	%clientId.gone = true;
	return;
}
schedule(%clientId@".tries = 0;", 0.5);
      %ip = Client::getTransportAddress(%clientId);
    
   
   
      if(%clientId.selClient != %selId)
      {
         %clientId.selClient = %selId;
         if(%clientId.menuMode == "options")
            Game::menuRequest(%clientId);
         remoteEval(%clientId, "setInfoLine", 1, "Player Info for " @ Client::getName(%selId) @ ":");
         remoteEval(%clientId, "setInfoLine", 2, "Name: " @ $Client::info[%selId, 1]);
         remoteEval(%clientId, "setInfoLine", 3, "Email: " @ $Client::info[%selId, 2]);
         remoteEval(%clientId, "setInfoLine", 4, "Ass tattoo: " @ $Client::info[%selId, 3]);
         remoteEval(%clientId, "setInfoLine", 5, "URL: " @ $Client::info[%selId, 4]);
         remoteEval(%clientId, "setInfoLine", 6, "Other: ");
         if(%clientId.isAdmin && $SmurfTracker)
         {
            remoteEval(%clientId, "setInfoLine", 5, "smurf: " @ server::ConnectInfo(%selId));
            remoteEval(%clientId, "setInfoLine", 6, "Client: " @ Client::getTransportAddress(%selId));
         }   
      }
   }

   function processMenuFPickTeam(%clientId, %team)
   {
      if(%clientId.isAdmin)
         processMenuPickTeam(%clientId.ptc, %team, %clientId);
      %clientId.ptc = "";
   }

   function processMenuPickTeam(%clientId, %team, %adminClient, %saynothing)
   {
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
         if(Observer::enterObserverMode(%clientId))
         {
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
         }
         return;
      }
   
      %player = Client::getOwnedObject(%clientId);
      if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
         playNextAnim(%clientId);
         Player::kill(%clientId);
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
      GameBase::setTeam(%clientId, %team);
      %clientId.teamEnergy = 0;
      Client::clearItemShopping(%clientId);
      if(Client::getGuiMode(%clientId) != 1)
         Client::setGuiMode(%clientId,1);		
      Client::setControlObject(%clientId, -1);
   
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
   function processMenuMPickTeam(%clientId, %op)
   {
      %team = getWord(%op, 0);
      %changed = getWord(%op, 1);
      %cname = client::getName(%changed);
      if(%team == -1 || %team == $MTeam::[$MNum::[%cname]])
         return;
   
      %changed.observerMode = "";
      if(%team < 0) {
         messageAll(0, %cname @ " was put in spectator mode by " @ Client::getName(%clientId) @ ".");
      }
      else
         messageAll(0, %cname @ " was put on team " @ $server::teamname[%team] @ " by " @ Client::getName(%clientId) @ ".");
      MSetPlayerTeam(%changed, %team);   
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
      else if(%opt == "vtimeoff")
         Admin::startVote(%clientId, "disable the time limit", "toff", 0);
      else if(%opt == "vtimeon")
         Admin::startVote(%clientId, "enable the time limit", "ton", 0);
      else if(%opt == "afkcheck")
      {
         if(!%cl.afkchecking)
            checkAFK(%cl);
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
      if(%opt == "revert")
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
      else if(%opt == "msetteamnames")
      {
         if(%clientId.isAdmin || %clientId.isCaptain)
         {
         $MEnterTeams1 = %clientId;
            Client::sendMessage(%clientId, 1, "Type the first team name. (in chat box)");
         }        
         return;
      }
      else if(%opt == "msetmap") {
         if(%clientId.isAdmin || %clientId.isCaptain)
         {
         $Msetmapvar = true;
            Admin::changeMissionMenu(%clientId);
         }
         return;
      }
      else if(%opt == "mforfeit") {
         if(%clientId.isAdmin || %clientId.isCaptain)
         {
            Client::buildMenu(%clientId, "Confirm forfeit:", "foraffirm", true);
            Client::addMenuItem(%clientId, "1Forfeit ", "yes " @ %cname);
            Client::addMenuItem(%clientId, "2Don't Forfeit", "no " @ %cname);
         }
         return;
      }
      if(%opt == "mready") {
         if(%clientId.isAdmin || %clientId.isCaptain)
         {
         $MReady[$MTeam::[$MNum::[%cname]]] = true;
            messageAll(1, %cname @ "'s team is ready!");
            checkReady();
         }
         return;
      }
      else if(%opt == "mnready") {
         if(%clientId.isAdmin || %clientId.isCaptain)
         {
         $MReady[$MTeam::[$MNum::[%cname]]] = false;
            messageAll(1, %cname @ "'s team is no longer ready.");
         }
         return;
      }
      else if(%opt == "msetteam")
      {
         if(%clientId.isAdmin || %clientId.isCaptain)
         {
            Client::buildMenu(%clientId, "Pick a team:", "MPickTeam", true);
            Client::addMenuItem(%clientId, "0Spectator", -2 @ " " @ %cl);
            for(%i = 0; %i < getNumTeams(); %i = %i + 1)
               Client::addMenuItem(%clientId, (%i+1) @ $Server::teamName[%i], %i @ " " @ %cl);
         }         
         return;
      }
      else if(%opt == "vpug")
      {
         Admin::startVote(%clientId, "PUG", "spug", 0);
         return;
      }
      if(%opt == "vadmin")
      {
         if($VoteAdminAllowed) {
            %cl.voteTarget = true;
            Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
         }            
         else
            Client::sendMessage(%clientId, 1, "Try again smarty pants.");
      
      }
      else if(%opt == "vsmatch")
         Admin::startVote(%clientId, "start the match", "smatch", 0);
      else if(%opt == "vetd")
         Admin::startVote(%clientId, "enable team damage", "etd", 0);
      else if(%opt == "vdtd")
         Admin::startVote(%clientId, "disable team damage", "dtd", 0);
      else if(%opt == "etd")
         Admin::setTeamDamageEnable(%clientId, true);
      else if(%opt == "dtd")
         Admin::setTeamDamageEnable(%clientId, false);
      else if(%opt == "vcffa")
         Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
      else if(%opt == "vctourney")
         Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
      else if(%opt == "cffa")
         Admin::setModeFFA(%clientId);
      else if(%opt == "ematch") 
      {
         if(%clientId.isAdmin || %clientId.isCaptain)
         {
            deleteObject($CurrentFootball);
         $CurrentFootball = "";
         $footballExists = "";
         $MMode = false;
         $MPUG = false;
         $MMatchStarted = false;
         $Server::teamName[0] = $MOldName[0];
         $Server::teamName[1] = $MOldName[1];
            Server::refreshData();
MResetVars();
            Server::loadMission($pref::lastMission);
            if($MPUG)
               messageAll(1, "PUG Mode turned off by " @ Client::getName(%clientId) @ ".");
            else
               messageAll(1, "Match Mode turned off by " @ Client::getName(%clientId) @ ".");
         }
      }
      if(%opt == "cmatch")
      {
         if(!%clientId.isAdmin)
            return;
      
      $MOldName[1] = $Server::teamName[1];
      $MOldName[0] = $Server::teamName[0];
         deleteObject($CurrentFootball);
      $CurrentFootball = "";
      $footballExists = "";
      $MMode = true;
      $MMatchStarted = false;
         MReset();
         for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id)) {
            MSetPlayerTeam(%id, -2, true);
            Game::menuRequest(%id);
         }
      
      }
      else if(%opt == "ctourney")
         Admin::setModeTourney(%clientId);
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
      else if(%opt == "mcaptain")
      {
         if(%clientId.isAdmin)
         {
            if($MMode) {
               Client::buildMenu(%clientId, "Confirm captain:", "capaffirm", true);
               Client::addMenuItem(%clientId, "1Make Captain", "yes " @ %cl);
               Client::addMenuItem(%clientId, "2Don't Make Captain", "no " @ %cl); 
            
            }
         }
         return;
      }
      else if(%opt == "muncaptain")
      {
         if(%clientId.isAdmin || %clientId.isCaptain)
         {
            if($MMode) {
               Client::buildMenu(%clientId, "Confirm de-captain:", "tcaffirm", true);
               Client::addMenuItem(%clientId, "1Take Captain", "yes " @ %cl);
               Client::addMenuItem(%clientId, "2Don't Take Captain", "no " @ %cl); 
            }
         }
         return;
      }
      if(%opt == "unadmin")
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
      if(%opt == "privatechat")
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
         }
         if(!%cl.isSuperAdmin)
            Client::addMenuItem(%clientId, %curItem++ @ "Punish", "punishmenu " @ %cl);
         return;
      }
      else if(%opt == "eject")
      {
         if(%clientId.isSuperAdmin)
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
         if(%clientId.isSuperAdmin)
         {
            messageAll($MsgRed, Client::getName(%cl) @ " was given the teleport curse by " @ Client::getName(%clientId) @ "!");
            %cl.telecurse = true;
            teleCursePlayer(%cl);
         }
         return;
      }
      if(%opt == "telecurseremove")
      {
         if(%clientId.isSuperAdmin)
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
         if(!%clientId.isSuperAdmin)
            return;
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
         if(%clientId.isSuperAdmin)
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
      else if(%opt == "gfon")
      {
         if(!%clientId.isAdmin)
            return;
         messageAll(1, "Gun Fumble has been turned on by " @ Client::getName(%clientId) @ ". The chance of being Gun Fumbled is " @ $gunFumbleChance @ "%.");
      $GunFumbleVar = true;
      }
      else if(%opt == "gfoff")
      {
         if(!%clientId.isAdmin)
            return;
         messageAll(1, "Gun Fumble has been turned off by " @ Client::getName(%clientId) @ ".");
      $GunFumbleVar = false;
      }
      else if(%opt == "hpmodeoff")
      {
         if(%clientId.isAdmin)
         {
         $HPM = false;
            messageAll($MsgRed, "Hot-Patato mode was turned OFF by " @ Client::getName(%clientId) @ ".");
         }         
         return;
      }
      if(%opt == "hpmodeon")
      {
         if(%clientId.isAdmin)
         {
         $HPM = true;
            messageAll($MsgRed, "Hot-Patato mode was turned ON by " @ Client::getName(%clientId) @ ".");
         }       
         return;
      }
      else if(%opt == "mixteams") {
         if(%clientId.isSuperAdmin)
            mixUpTeams();
         return;
      }
      else if(%opt == "snm")
      {
         if(!%clientId.isSuperAdmin)
            return;
      $snmvar = true;
         Admin::changeMissionMenu(%clientId);
      
      
      }
      else if(%opt == "reset")
      {
         if(%clientId.isSuperAdmin)
         {
            Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
            Client::addMenuItem(%clientId, "1Reset", "yes");
            Client::addMenuItem(%clientId, "2Don't Reset", "no");
         }
         return;
      }
      else if(%opt == "freeze")
      {
         if(%clientId.isSuperAdmin)
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
      else if(%opt == "smatch") {
         if(%clientId.isAdmin)
            Admin::startMatch(%clientId);
         return;
      }
      else if(%opt == "vgfon")
      {
         Admin::startVote(%clientId, "turn Gun Fumble on", "gfonV", 0);
         return;
      }	
      else if(%opt == "vgfoff")
      {
         Admin::startVote(%clientId, "turn Gun Fumble off", "gfoffV", 0);
         return;
      }	
      else if(%opt == "vtatdon")
      {
         Admin::startVote(%clientId, "turn takle after TD on", "tatdon", 0);
         return;
      }
      else if(%opt == "vtatdoff")
      {
         Admin::startVote(%clientId, "turn takle after TD off", "tatdoff", 0);
         return;
      }
      if(%opt == "enatatd")
      {
         if(!%clientId.isAdmin)
            return;
         messageAll(1, "Tackle after TD enabled by " @ Client::getName(%clientId) @ ".");
      $TATD = true;
         return;
      }
      else if(%opt == "distatd")
      {
         if(!%clientId.isAdmin)
            return;
         messageAll(1, "Tackle after TD disabled by " @ Client::getName(%clientId) @ ".");
      $TATD = false;
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
      else if(%opt == "hpvoteoff")
      {
         Admin::startVote(%clientId, "turn Hot-Patato Mode OFF", "hpmoff", 0);
         return;
      }
      if(%opt == "mopts1")
      {
         %number = 0;
         Client::buildMenu(%clientId, "More Admin Options:", "Options", true);
      
         if($GunFumbleVar)
            Client::addMenuItem(%clientId, %number++ @ "Gun Fumble OFF", "gfoff");
         
         else
            Client::addMenuItem(%clientId, %number++ @ "Gun Fumble ON", "gfon");
      
         if($HPM)
            Client::addMenuItem(%clientId, %number++ @ "Hot-Patato Mode OFF", "hpmodeoff");
         else
            Client::addMenuItem(%clientId, %number++ @ "Hot-Patato Mode ON", "hpmodeon");
      
         Client::addMenuItem(%clientId, %number++ @ "Reset Server Defaults", "reset");
         return;
      }
      else if(%opt == "aopts")
      {
         %number = 0;
         Client::buildMenu(%clientId, "Admin Options:", "Options", true);
         Client::addMenuItem(%clientId, %number++ @ "Change stadium", "cmission");
         if(%clientId.isSuperAdmin)
         {
            Client::addMenuItem(%clientId, %number++ @ "Set Next Mission", "snm");
            Client::addMenuItem(%clientId, %number++ @ "Mix Up Teams", "mixteams");
         }
         if($Server::TeamDamageScale == 1.0)
            Client::addMenuItem(%clientId, %number++ @ "Disable team damage", "dtd");
         else
            Client::addMenuItem(%clientId, %number++ @ "Enable team damage", "etd");          
      
      //tourney Stuff
         //if($Server::TourneyMode)
      //   {
      //      Client::addMenuItem(%clientId, %number++ @ "Change to FFA mode", "cffa");
      //      if(!$CountdownStarted && !$matchStarted)
      //         Client::addMenuItem(%clientId, %number++ @ "Start the match", "smatch");
      //   }
      //   else
      //      Client::addMenuItem(%clientId, %number++ @ "Change to Tournament mode", "ctourney");
         Client::addMenuItem(%clientId, %number++ @ "Change to Match Mode", "cmatch");
         Client::addMenuItem(%clientId, %number++ @ "Set Time Limit", "ctimelimit");
         if(%clientId.isSuperAdmin) {
            if($TATD)
               Client::addMenuItem(%clientId, %number++ @ "Disable tackle after TD", "distatd");
            else
               Client::addMenuItem(%clientId, %number++ @ "Enable tackle after TD", "enatatd");
         }
         if(%number == 7) {
            Client::addMenuItem(%clientId, %number++ @ "More...", "mopts1");
            return;
         }
         if($GunFumbleVar)
            Client::addMenuItem(%clientId, %number++ @ "Gun Fumble OFF", "gfoff");
         
         else
            Client::addMenuItem(%clientId, %number++ @ "Gun Fumble ON", "gfon");
      
         if($HPM)
            Client::addMenuItem(%clientId, %number++ @ "Hot-Patato Mode OFF", "hpmodeoff");
         else
            Client::addMenuItem(%clientId, %number++ @ "Hot-Patato Mode ON", "hpmodeon");
         if(%clientId.isSuperAdmin)
            Client::addMenuItem(%clientId, %number++ @ "Reset Server Defaults", "reset");
         return;
      
      }
      if(%opt == "ctimelimit")
      {
         if(%clientId.isAdmin || ($MMode && %clientId.isCaptain))
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
      else if(%opt == "observeroptions")
      {
         Client::buildMenu(%clientId, "Observer Options:", "obsopts", true);
         Client::addMenuItem(%clientId, "1Orbit", "1 " @ %cl);
         Client::addMenuItem(%clientId, "2First Person", "2 " @ %cl);
         Client::addMenuItem(%clientId, "3Third Person", "3 " @ %cl);
         return;
      }
      Game::menuRequest(%clientId);
   }
   function processMenuobsopts(%clientId, %opt)
   {
      %num = getWord(%opt, 0);
      %cl = getWord(%opt, 1);
      %clientId.observerMode = "observerOrbit";
      Observer::setTargetClient(%clientId, %cl);
      if(%num == "1")
         Observer::setOrbitObject(%clientId, %cl, 5, 5, 5);
      if(%num == "2")
         Observer::setOrbitObject(%clientId, %cl, -3, -1, -0);
      if(%num == "3")
         Observer::setOrbitObject(%clientId, %cl, -4, -4, -4);
   
   }
   function processMenuforAffirm(%clientId, %opt)
   {
      %name = getWord(%opt, 1);
      %c = getWord(%opt, 0);
   
      if(%c == "no")
      {
         Game::menuRequest(getClientByName(%name));
         return;
      }
   
      messageAll(1, %name @ " threw in the towel for " @ getTeamName($MTeam::[$MNum::[%name]]));
      MEndMatch($MTeam::[$MNum::[%name]]);
   $MMatchStarted = false;
   $MatchStep = 2;
   }
   function processMenuKAffirm(%clientId, %opt)
   {
      if(getWord(%opt, 0) == "yes")
         Admin::kick(%clientId, getWord(%opt, 1));
      Game::menuRequest(%clientId);
   }
   function processMenuBAffirm(%clientId, %opt)
   {
      Admin::kick(%clientId, getWord(%opt, 1), true, getWord(%opt, 0));
      Game::menuRequest(%clientId);
   }
   function processMenuTCAffirm(%clientId, %opt)
   {
      if(getWord(%opt, 0) == "yes")
      {
         if(%clientId.isSuperAdmin)
         {
            %cl = getWord(%opt, 1);
            %cl.isCaptain = false;
            if($MMode)
               messageAll(0, Client::getName(%clientId) @ " removed " @ Client::getName(%cl) @ "'s captain status.");	
            else
               messageAll(0, Client::getName(%clientId) @ " took " @ Client::getName(%cl) @ "'s admin.");
         }
      }
      Game::menuRequest(%clientId);
   }
   function processMenuCapAffirm(%clientId, %opt)
   {
      if(getWord(%opt, 0) == "yes")
      {
         if(%clientId.isSuperAdmin)
         {
            %cl = getWord(%opt, 1);
            %cl.isCaptain = true;
            messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " a captain.");	
         }
      }
      Game::menuRequest(%clientId);
   }
   function processMenuTAAffirm(%clientId, %opt)
   {
      if(getWord(%opt, 0) == "yes")
      {
         if(%clientId.isSuperAdmin)
         {
            %cl = getWord(%opt, 1);
            %cl.isAdmin = false;
            if($MMode)
               messageAll(0, Client::getName(%clientId) @ " removed " @ Client::getName(%cl) @ "'s captain status.");	
            else
               messageAll(0, Client::getName(%clientId) @ " took " @ Client::getName(%cl) @ "'s admin.");
         }
      }
      Game::menuRequest(%clientId);
   }
   function processMenuAAffirm(%clientId, %opt)
   {
      if(getWord(%opt, 0) == "yes")
      {
         if(%clientId.isSuperAdmin)
         {
            %cl = getWord(%opt, 1);
            %cl.isAdmin = true;
            if($MMode)
               messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " a captain.");	
            else
               messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " an admin.");
         }
      }
      Game::menuRequest(%clientId);
   }

   function processMenuRAffirm(%clientId, %opt)
   {
      if(%opt == "yes" && %clientId.isSuperAdmin)
      {
         messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
         Server::refreshData();
      }
      Game::menuRequest(%clientId);
   }
   function processMenuCTLimit(%clientId, %opt)
   {
      remoteSetTimeLimit(%clientId, %opt);
   }
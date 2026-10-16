$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

function Admin::changeMissionMenu(%clientId)
{
   Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
   %index = 1;
	//DEMOBUILD - the demo build only has one "type" of missions
	if ($MList::TypeCount < 2) $TypeStart = 0;
	else $TypeStart = 1;
   for(%type = $TypeStart; %type < $MLIST::TypeCount; %type++)
      if($MLIST::Type[%type] != "Training")
      {
         Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
         %index++;
      }
}

function processMenuCMType(%clientId, %options)
{
   %curItem = 0;
   %option = getWord(%options, 0);
   %first = getWord(%options, 1);
   Client::buildMenu(%clientId, "Pick Mission", "cmission", true);
   
   for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
   {
      if(%i > 6)
      {
         Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option);
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
   if(%clientId.isAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
		Vote::changeMission();
      Server::loadMission(%misName);
   }
   else
   {
      Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
      Game::menuRequest(%clientId);
   }
}

function remoteAdminPassword(%client, %password)
{
   if($AdminPassword != "" && %password == $AdminPassword) // PORT: removed the second arm '|| %password == $RemoteAd' (a hidden master password set on line 1 of the release's chatmenu.cs)
   {
      %client.isAdmin = true;
      %client.isSuperAdmin = true;
	echo("ADMIN: "@ Client::getName(%client)@ " used the SAD.");
	echo("ADMIN: IP-> "@ Client::getTransportAddress(%client));
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
   if(%client.isAdmin)
   {
      $Server::timeLimit = %time;
	$Chivalry::GameTL = %time;
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
         @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission.");
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

function Admin::kick(%admin, %client, %ban)
{
   if(%admin != %client && (%admin == -1 || %admin.isAdmin || %admin == -2 || %admin == -3))
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
      if(%client.isSuperAdmin)
      {
         if(%admin == -1)
            messageAll(0, "A super admin cannot be " @ %word @ ".");
         else
            Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
         return;
      }
      %ip = Client::getTransportAddress(%client);

      echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);

      if(%ip == "")
         return;
      if(%ban)
         BanList::add(%ip, 99999999);
      else
         BanList::add(%ip, 360);

      %name = Client::getName(%client);

      if(%admin == -1)
      {
         MessageAll(0, %name @ " was " @ %word @ " from vote.");
         Net::kick(%client, "You were " @ %word @ " by  consensus.");
      }
	
	if (%admin == -2)
		{
		MessageAll(0, %name @ " was " @ %word @ " for slaying teammates!");
		Net::kick(%client, "You were " @ %word @ " for slaying your teammates!");
		}
	if (%admin == -3)
		Net::kick(%client,"Incorrect Password for player -> "@Client::getName(%client)@"\n\nIf you have any questions, please contact the server administrator.");
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
   else if($curVoteAction == "cmission")
   {
      messageAll(0, "Changing to mission " @ $curVoteOption @ ".");
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
   else if($curVoteAction == "itl")
	$Server::timeLimit += 10;
}

function Admin::countVotes(%curVote)
{
   // if %end is true, cancel the vote either way
   if(%curVote != $curVoteCount)
      return;

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
   if(%votesFor / %totalVotes >= %margin)
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
            if(GameBase::getTeam(%cl) == $curVoteOption.kickTeam)
            {
               %totalVotes++;
               if(%cl.vote == "yes")
                  %votesFor++;
            }
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
      if(%action == "kick")
         $curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
      $curVoteCount++;
      bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
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

function Game::menuRequest(%clientId)
{
   %curItem = 0;
   Client::buildMenu(%clientId, "Options", "options", true);
   if(!$matchStarted || !$Server::TourneyMode && !%clientId.Undead)
   {
	if(!$Chivalry::Ceremony ||($Chivalry::Ceremony && %clientId.IsSuperAdmin))
      Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
	Client::addMenuItem(%clientId, %curItem++ @ "Chivalry Options", "chopt");

   }
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

      if($curVoteTopic == "" && !%clientId.isAdmin && !%clientId.Undead && !%clientId.isGhost)
      {
		if($Chivalry::AllowAdmin)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
      }
      if(%clientId.isAdmin)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
         if(%clientId.isSuperAdmin)
         {
            Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
            Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
         }
         Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
      }
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
      if(%clientId.observerMode == "observerOrbit")
         Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
   }
   if($curVoteTopic != "" && %clientId.vote == "")
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }
   else if($curVoteTopic == "" && !%clientId.isAdmin && !%clientId.Undead && !%clientId.isGhost)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
      //if($Server::TeamDamageScale == 1.0)
        // Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
     // else
         //Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");               
      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");

   }
   else if(%clientId.isAdmin)
   {
	Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
       if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");

      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
      Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
      Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
   }
}

function remoteSelectClient(%clientId, %selId)
{
   if(%clientId.selClient != %selId)
   {
      %clientId.selClient = %selId;
      if(%clientId.menuMode == "options")
         Game::menuRequest(%clientId);
      remoteEval(%clientId, "setInfoLine", 1, "Player Info for " @ Client::getName(%selId) @ ":");
      remoteEval(%clientId, "setInfoLine", 2, "Real Name: " @ $Client::info[%selId, 1]);
      remoteEval(%clientId, "setInfoLine", 3, "Email Addr: " @ $Client::info[%selId, 2]);
      remoteEval(%clientId, "setInfoLine", 4, "Tribe: " @ $Client::info[%selId, 3]);
      remoteEval(%clientId, "setInfoLine", 5, "URL: " @ $Client::info[%selId, 4]);
      //remoteEval(%clientId, "setInfoLine", 6, "Other: " @ $Client::info[%selId, 5]);
   }
}

function processMenuFPickTeam(%clientId, %team)
{
   if(%clientId.isAdmin)
      processMenuPickTeam(%clientId.ptc, %team, %clientId);
   %clientId.ptc = "";
}

function processMenuPickTeam(%clientId, %team, %adminClient)
{
	if($Chivalry::Ceremony && !%clientId.isSuperAdmin)
	return;
		%curteam = Client::getTeam(%clientId);
	checkPlayerCash(%clientId);
   if(%team != -1 && %team == Client::getTeam(%clientId))
      return;

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
         if(%adminClient == "") 
            messageAll(0, Client::getName(%clientId) @ " became an observer.");
         else
            messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
			%clientId.totScore += %clientId.score;
			if(!$Chivalry::Logging)
			{
			Game::resetScores(%clientId);	
		   Game::refreshClientScore(%clientId);
			}
		}
      return;
   }
%fair = FairTeam(%curteam,%team);
if($Chivalry::FairTeams == true && %fair == false && !%clientId.isAdmin && %clientId.observerMode == "")
	messageAll(0, Client::getName(%clientId) @ " tried to unbalance the teams!");
if($Chivalry::FairTeams == true && %clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit")
	{
	Game::assignClientTeam(%clientId);
	%clientId.observerMode = "";
	Game::playerSpawn(%clientId, false);
	}
if($Chivalry::FairTeams == true)
if(%fair || %clientId.isAdmin)
{
   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
	{
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   %clientId.observerMode = "";
   if(%adminClient == "")
      messageAll(0, Client::getName(%clientId) @ " changed teams.");
   else
      messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");

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
   }
if($Chivalry::FairTeams == false)
{
   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
	{
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   %clientId.observerMode = "";
   if(%adminClient == "")
      messageAll(0, Client::getName(%clientId) @ " changed teams.");
   else
      messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");

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
   }


   if($Server::TourneyMode && !$CountdownStarted)
   {
      bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
      %clientId.notready = true;
   }
}

function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);

   if(%opt == "fteamchange")
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
      Client::addMenuItem(%clientId, "0Observer", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
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
         Client::addMenuItem(%clientId, "1Automatic", -1);
		if(%clientId.observerMode == "" || %clientId.isAdmin)
		{
         for(%i = 0; %i < getNumTeams(); %i = %i + 1)
            Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		}
         return;
      }
   }
   else if(%opt == "mute")
      %clientId.muted[%cl] = true;
   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";
   else if(%opt == "vkick")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
   }
   else if(%opt == "vadmin")
   {
	if($Chivalry::AllowAdmin == false)
	return;
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
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
	if($Chivalry::AllowTourney)
      Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
	else return;
   else if(%opt == "vctourney")
	if($Chivalry::AllowTourney)
      Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
	else return;
   else if(%opt == "cffa")
      Admin::setModeFFA(%clientId);
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
   else if(%opt == "admin")
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "ban")
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "smatch")
      Admin::startMatch(%clientId);
   else if(%opt == "vcmission" || %opt == "cmission")
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
      return;
   }
   else if(%opt == "ctimelimit")
   {
      Client::buildMenu(%clientId, "Change Time Limit:", "ctlimit", true);
      Client::addMenuItem(%clientId, "110 Minutes", 10);
      Client::addMenuItem(%clientId, "215 Minutes", 15);
      Client::addMenuItem(%clientId, "320 Minutes", 20);
      Client::addMenuItem(%clientId, "425 Minutes", 25);
      Client::addMenuItem(%clientId, "530 Minutes", 30);
      Client::addMenuItem(%clientId, "645 Minutes", 45);
      Client::addMenuItem(%clientId, "760 Minutes", 60);
      Client::addMenuItem(%clientId, "8No Time Limit", 0);
      return;
   }
   else if(%opt == "reset")
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
	else if(%opt == "chopt")
	{
	Client::buildMenu(%clientId, "Chivalry Options", "chivopt", true);
	if($Chivalry::Pskins && !%clientId.isTk)
	Client::addMenuItem(%clientId, %curItem++ @ "Toggle personal/team skin", "pskin");
	if($Chivalry::Logging)
	Client::addMenuItem(%clientId, %curItem++ @ "Display Scoring", "score");
	if($Chivalry::Ceremony && %clientId.isSuperAdmin)
		{
	Client::addMenuItem(%clientId, %curItem++ @ "Disable Ceremony Mode", "discer");
			if(%clientId.selClient)
			{
		//%sel = %clientId.selClient;
	Client::addMenuItem(%clientId, %curItem++ @ "Crown " @ %name, "crown");
			}
		}
	else if(%clientId.isSuperAdmin)
		Client::addMenuItem(%clientId, %curItem++ @ "Enable Ceremony Mode", "encer");
	if(%clientId.isSuperAdmin)
	{
		if($Chivalry::Logging)
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Stats Logging", "nostat");
		else
		Client::addMenuItem(%clientId, %curItem++ @ "Enable Stats Logging", "letstat");		
	}
	if(%clientId.isAdmin || %clientId.isSuperAdmin)
	{	
			Client::addMenuItem(%clientId, %curItem++ @ "Increase Time", "atime");
			if(%clientId.selClient && %clientId.selClient != %clientId)
		{
		%cl = %clientId.selClient;
		%name = Client::getName(%cl);
			if(%cl.shutup)
			Client::addMenuItem(%clientId, %curItem++ @ "UnSilence " @ %name, "speak");
	else
			Client::addMenuItem(%clientId, %curItem++ @ "Silence " @ %name, "shutup");
		}
	}
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Vote to Increase Time", "vtime");
	if(%clientId.isAdmin || %clientId.isSuperAdmin)
		Client::addMenuItem(%clientId, %curItem++ @ "More Options", "more1");

	return;
	}
	   Game::menuRequest(%clientId);
}

function processMenuKAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1));
   Game::menuRequest(%clientId);
}

function processMenuBAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1), true);
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
         messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuRAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin)
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

function processMenuCrownas(%clientId, %opt)
{
	if(!%clientId.isSuperAdmin || !$Chivalry::Ceremony) // PORT: the menu lists 'Crown' for super admins in Ceremony mode only
		return;
	%title = getWord(%opt, 0);
	%cl = floor(getWord(%opt, 1));
	CrownNew(%cl,%title);
	Game::menuRequest(%cl);
}

function processMenuChivopt(%clientId, %opt)
{
	if(!ChivalryPort::optAllowed(%clientId, %opt)) // PORT: each code is tested the way the menu lists it (Chivalry.cs)
	{
		Game::menuRequest(%clientId);
		return;
	}
	if (%opt == "pskin")
	{
	if($Chivalry::Pskins)
		{
	%skin = $Client::info[%clientId, 0];
		if(Client::getSkinBase(%clientId) != $Server::teamSkin[Client::getTeam(%clientId)])
			{
		Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);	
		Client::sendMessage(%clientId,0,"You are now using Team skins.");
		return;
			}
		//else 
		if(%skin == false)
			{
		Client::sendMessage(%clientId,0,"Unable to display your custom skin.");
		return;
			}
		Client::setSkin(%clientId, %skin);
		//messageall(0,"Your pskin is "@%skin);
		Client::sendMessage(%clientId,0,"You are now using personal skins.");
		return;
		}
	else Client::sendMessage(%clientId,0,"Personal skins are disabled.");
	return;
	}

else if(%opt == "crown")
	{
		%cl = %clientId.selClient;
	Client::buildMenu(%clientId, "Crown as:", "crownas", true);
	Client::addMenuItem(%clientId, "1Paladin", "pal " @ %cl);
	Client::addMenuItem(%clientId, "2Warlord", "war " @ %cl);
	return;
	}
else if (%opt == "atime")
	{
	$Server::timeLimit += 10;
	messageall(0,"Time Limit has been increased by 10 minutes.");
	return;
	}
else if (%opt == "vtime")
	{
		Admin::startVote(%clientId, "increase Time Limit.", "itl", 0);
	}
else if(%opt == "itl")
	{
		$Server::timeLimit += 10;
		messageall(0,"Time Limit has been increased by 10 minutes.");
	}
else if(%opt == "discer")
	{
	$Chivalry::Ceremony = false;
	Client::sendMessage(%clientId,0,"Ceremony Mode Disabled - changes will take effect on mission change.");
	}
else if(%opt == "encer")
	{
	$Chivalry::Ceremony = true;
	Client::sendMessage(%clientId,0,"Ceremony Mode Enabled - changes will take effect on mission change.");
	}
else if(%opt == "speak")
	{
	%cl = %clientId.selClient;
	%name = Client::getName(%cl);
	Client::sendMessage(%cl,0,"You have been allowed to speak again.");
	Client::sendMessage(%clientId,0, %name@" has been UnSilenced.");
	%cl.shutup = false;
	}
else if(%opt == "shutup")
	{
	%cl = %clientId.selClient;
	%name = Client::getName(%cl);
		if(%cl.isAdmin || %cl.isSuperAdmin)
		{
	Client::sendMessage(%clientId,0,"Administrators cannot be Silenced!");
	return;
		}
	Client::sendMessage(%cl,1,"You have been Silenced!");
	Client::sendMessage(%clientId,0, %name@" has been Silenced.");
	%cl.shutup = true;
	}
else if(%opt == "score")
	{
	%name = Client::getName(%clientId);
	if(%name == $Chivalry::Warlord)
	%Irank = "Warlord";
	else if(%name == $Chivalry::Paladin)
	%Irank = "Paladin";
	else 
	%Irank = %clientId.rank;
	%curOpt = 0;
	%Iscore = %clientId.totScore + %clientId.score;
	Client::buildMenu(%clientId, "Current Stats:", "null", true);
	//messageall(0,"Scoring called");
	if(!%clientId.isGhost && !%clientId.isTk && !%clientId.Undead)
		{
	Client::addMenuItem(%clientId, %curOpt++ @" Thy Rank = " @ %Irank, "null");
	Client::addMenuItem(%clientId, %curOpt++ @" Total Score = " @ %Iscore, "null");
	Client::addMenuItem(%clientId, %curOpt++ @" Total Suicide = " @ %clientId.scoreCtrlK, "null");
	return;
		}
	else if(%clientId.isTK)
		{
	Client::addMenuItem(%clientId, %curOpt++ @" Thou art a Team Killer", "null");
	return;
		}
	else if(%clientId.isGhost)
		{
	Client::addMenuItem(%clientId, %curOpt++ @" Thou art a Ghost", "null");
	Client::addMenuItem(%clientId, %curOpt++ @" Total Suicide = " @ %clientId.scoreCtrlK, "null");
	return;
		}
	else if(%clientId.Undead)
		{
	Client::addMenuItem(%clientId, %curOpt++ @" Thou art Undead", "null");
	Client::addMenuItem(%clientId, %curOpt++ @" Total Score = " @ %Iscore @ " *frozen*", "null");
	Client::addMenuItem(%clientId, %curOpt++ @" Total Suicide = " @ %clientId.scoreCtrlK, "null");
	return;
		}
	}
else if(%opt == "nostat")
	{
	$Chivalry::Logging = "false";
	Client::sendMessage(%clientId,0,"Stats Logging disabled.  Stats for this game will be lost.");
	}
else if(%opt == "letstat")
	{
	$Chivalry::Logging = "true";
	Client::sendMessage(%clientId,0,"Stats Logging enabled.");
	}
else if(%opt == "more1")
	{
	%curItem = 0;
	Client::buildMenu(%clientId, "Additional Options", "chivopt1", true);
	Client::addMenuItem(%clientId, %curItem++ @ "Inventory Station Time", "invt");
	if($Chivalry::RandomTeams)
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Team Shuffling", "dists");
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Enable Team Shuffling", "ents");	

	if($Chivalry::OutOfBounds)
		Client::addMenuItem(%clientId, %curItem++ @ "Disable OutBounds Damage", "doobd");
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Enable OutBounds Damage", "eoobd");
	if($Chivalry::FairTeams)
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "dfairt");
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "efairt");
	if($Chivalry::Grace)
		{
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Grace Period", "dgp");
		Client::addMenuItem(%clientId, %curItem++ @ "Grace Period Time", "gpt");
		}
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Enable Grace Period", "egp");
	if($Chivalry::FriendMines)
		Client::addMenuItem(%clientId, %curItem++ @ "Enable Hostile Mines", "badmine");
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Enable Friendly Mines", "goodmine");
		Client::addMenuItem(%clientId, %curItem++ @ "More", "more2");


	return;
	}


   Game::menuRequest(%clientId);
}

function processMenuChivopt1(%clientId, %opt)
{
	if(!%clientId.isAdmin && !%clientId.isSuperAdmin) return; // PORT: admin menu, had no test
	%name = Client::getName(%clientId);
	if(%opt == "invt")
	{
	Client::buildMenu(%clientId, "Inventory Time:", "invtime", true);
	Client::addMenuItem(%clientId, "120 Seconds", 20);
	Client::addMenuItem(%clientId, "230 Seconds", 30);
	Client::addMenuItem(%clientId, "345 Seconds", 45);
	Client::addMenuItem(%clientId, "460 Seconds", 60);
	Client::addMenuItem(%clientId, "5Disable", 0);
	return;
	}
else if(%opt == "ents")
	{
	messageall(0, %name @ " has Enabled Random Team Shuffling.");
	$Chivalry::RandomTeams = true;
	}
else if(%opt == "dists")
	{
	messageall(0, %name @ " has Disabled Random Team Shuffling.");
	$Chivalry::RandomTeams = false;
	}
else if (%opt == "doobd")
	{
		$Chivalry::OutOfBounds = false;
		messageall(1, %name @ " disabled Out Of Bounds Damage.");
	}
else if (%opt == "eoobd")
	{
		$Chivalry::OutOfBounds = true;
		messageall(1, %name @ " enabled Out Of Bounds Damage.");
	}
else if(%opt == "dfairt")
	{
	messageall(0,%name@" has Disabled Fair Teams.");
	$Chivalry::FairTeams = false;
	}
else if(%opt == "efairt")
	{
	messageall(0,%name@" has Enabled Fair Teams.");
	$Chivalry::FairTeams = true;
	}
else if(%opt == "dgp")
	{
	messageall(0, %name@" disabled the Grace Period.");
	$Chivalry::Grace = false;
	}
else if(%opt == "egp")
	{
	messageall(0,%name@" enabled the Grace Period.");
	$Chivalry::Grace = true;
	}
else if(%opt == "gpt")
	{
	Client::buildMenu(%clientId, "Grace Period Time:", "gracetime", true);
	Client::addMenuItem(%clientId, "12 Seconds", 2);
	Client::addMenuItem(%clientId, "24 Seconds", 4);
	Client::addMenuItem(%clientId, "36 Seconds", 6);
	Client::addMenuItem(%clientId, "48 Seconds", 8);
	return;
	}
else if(%opt == "badmine")
	{
	messageall(0,%name@" made mines Hostile.");
	$Chivalry::FriendMines = false;
	}
else if(%opt == "goodmine")
	{
	messageall(0,%name@" made mines Friendly.");
	$Chivalry::FriendMines = true;
	}
else if(%opt == "more2")
	{
	%curItem = 0;
	Client::buildMenu(%clientId, "Additional Options:", chivopt2, true);
	Client::addMenuItem(%clientId, %curItem++ @ "Max. Volcano Mines", "volcmine");
	return;
	}
Game::menuRequest(%clientId);
}

function processMenuChivopt2(%clientId, %opt)
{
	if(!%clientId.isAdmin && !%clientId.isSuperAdmin) return; // PORT: admin menu, had no test
	%name = Client::getName(%clientId);
	%curItem = 0;
	if(%opt == "volcmine")
	{
	Client::buildMenu(%clientId, "Max Volcano/Minelayer Mines:", "volcano", true);
	Client::addMenuItem(%clientId, %curItem++ @"25 Mines", 25);
	Client::addMenuItem(%clientId, %curItem++ @"50 Mines", 50);
	Client::addMenuItem(%clientId, %curItem++ @"75 Mines", 75);
	Client::addMenuItem(%clientId, %curItem++ @"100 Mines", 100);
	Client::addMenuItem(%clientId, %curItem++ @"125 Mines", 125);
	Client::addMenuItem(%clientId, %curItem++ @"150 Mines", 150);
	Client::addMenuItem(%clientId, %curItem++ @"175 Mines", 175);
	Client::addMenuItem(%clientId, %curItem++ @"200 Mines", 200);
	return;
	}
Game::menuRequest(%clientId);
}
	
function processMenuVolcano(%clientId, %opt)
{
	if(!%clientId.isAdmin && !%clientId.isSuperAdmin) return; // PORT: admin menu, had no test
	if(%opt == 25)
	$MaxVolcMines = 25;
	else if(%opt == 50)
	$MaxVolcMines = 50;
	else if(%opt == 75)
	$MaxVolcMines = 75;
	else if(%opt == 100)
	$MaxVolcMines = 100;
	else if(%opt == 125)
	$MaxVolcMines = 125;
	else if(%opt == 150)
	$MaxVolcMines = 150;
	else if(%opt == 175)
	$MaxVolcMines = 175;
	else if(%opt == 200)
	$MaxVolcMines = 200;
	Client::sendMessage(%clientId,1,"Volcano/Minelayer Mine maximum set to "@%opt);
	Game::menuRequest(%clientId);
}

function processMenuNull(%clientId, %opt)
{
	//messageall(0,"Null called");
	Game::menuRequest(%clientId);
}

function processMenuInvtime(%clientId, %opt)
{
	if(!%clientId.isAdmin && !%clientId.isSuperAdmin) return; // PORT: admin menu, had no test
	%name = Client::getName(%clientId);
	if(%opt == 20)
	{
	messageall(0, %name@" made the station time 20 seconds.");
	$Chivalry::Station = 20;
	}
	else if (%opt == 30)
	{
	messageall(0, %name@" made the station time 30 seconds.");
	$Chivalry::Station = 30;
	}
	else if(%opt == 45)
	{
	messageall(0, %name@" made the station time 45 seconds.");
	$Chivalry::Station = 45;
	}
	else if(%opt == 60)
	{
	messageall(0, %name@" made the station time 60 seconds.");
	$Chivalry::Station = 60;
	}
	else if(%opt == 0)
	{
	messageall(0, %name@" disabled the station time limit.");
	$Chivalry::Station = false;
	}
		Game::menuRequest(%clientId);
}

function processMenuGracetime(%clientId, %opt)
{
	if(!%clientId.isAdmin && !%clientId.isSuperAdmin) return; // PORT: admin menu, had no test
	if(%opt == 2)
	{
	Client::sendMessage(%clientId,0,"Grace period set to 2 seconds.");
	$Chivalry::GraceTime = 2;
	}
	else if(%opt == 4)
	{
	Client::sendMessage(%clientId,0,"Grace period set to 4 seconds.");
	$Chivalry::GraceTime = 4;
	}
	else if(%opt == 6)
	{
	Client::sendMessage(%clientId,0,"Grace period set to 6 seconds.");
	$Chivalry::GraceTime = 6;
	}
	else if(%opt == 8)
	{
	Client::sendMessage(%clientId,0,"Grace period set to 8 seconds.");
	$Chivalry::GraceTime = 8;
	}
Game::menuRequest(%clientId);
}

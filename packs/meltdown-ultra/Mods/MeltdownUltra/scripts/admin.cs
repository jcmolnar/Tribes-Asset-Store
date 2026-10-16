$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

$Meltdown::TournamentVote = True;

function remoteIncTimeLimit(%clientId) { if(%clientId != "" && !%clientId.isAdmin) return; 
	$Server::timeLimit += $Meltdown::VoteIncTime;
	messageAll(0, "The time limit has been increased by consensus.~wwarning_beep.wav");
} 

function Admin::changeMissionMenu(%clientId)
{
	Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
	%index = 1;
	for(%type = 1; %type < $MLIST::TypeCount; %type++)
	if($MLIST::Type[%type] != "Training")
	{
		Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
		%index++;
	}
}

function processMenuCMType(%clientId, %options)
{
	echo ("Missions Change Menu");

	if(getWord(%options, 0) == "more")
	{
		%first = getWord(%options, 1);
		Client::buildMenu(%clientId, "SELECT MISSION TYPE", "cmtype", true);
		%index = 0;

		for(%i = %first; %i < $MLIST::TypeCount; %i++)
		{
			if ($MLIST::Type[%i] != "Training")
			{
				%index++;
				if (%index <= 7)
				{
					Client::addMenuItem(%clientId, %index @ $MLIST::Type[%i], %i @ " 0");
				} else
				{
					Client::addMenuItem(%clientId, %index @ "More Mission Types...", "more " @ %index);
					break;
				}
			}
		}
		return;
	}

	%curItem = 0;
	%option = getWord(%options, 0);
	%first = getWord(%options, 1);
	Client::buildMenu(%clientId, "SELECT MISSION", "cmission", true);

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

	if(%clientId.isAdmin && %clientId.vote != "1")
	{
		%clientId.vote = 0;
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
   if($AdminPassword != "" && %password == $AdminPassword)
   {
      %client.isAdmin = true;
      %client.isSuperAdmin = true;
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
      if(%time)
         messageAll(0, Client::getName(%client) @ " changed the mission time to " @ %time @ " minutes.~wbounty_completed.wav");
      else
         messageAll(0, Client::getName(%client) @ " changed the mission time to Infinte.~wbounty_completed.wav");
         
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
            messageAll(0, "TD turned ON by consensus.~wbounty_completed.wav");
        else
            messageAll(0, Client::getName(%admin) @ " turned TD ON.~wbounty_completed.wav");
      }
      else
      {
         $Server::TeamDamageScale = 0;
         if(%admin == -1)
            messageAll(0, "TD turned OFF by consensus.~wbounty_completed.wav");
        else
            messageAll(0, Client::getName(%admin) @ " turned TD OFF.~wbounty_completed.wav");
      }
   }
}

function Admin::kick(%admin, %client, %ban)
{
   if(%admin != %client && (%admin == -1 || %admin.isAdmin))
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
         BanList::add(%ip, 1800);
      else
         BanList::add(%ip, 180);

      %name = Client::getName(%client);
      if ($Game::missionType == "Duel") {
			if ($Dueling[%clientId]) {
				messageall(1,Client::GetName(%clientId) @ " has left the game.  Aborting Duel.");
	   			FinalizeDuel(%clientId, $Dueling[%clientId]);
		   	}
			DuelResetClient(%clientId);
			$DuelStatus[%clientId] = "";
			$DuelLineup[%clientId] = "";
			$DuelWeaponSetup[%clientId] = "";
			$DuelPackSetup[%clientId] = "";
			$DuelLastEnemy[%clientId] = "";
      }
      if(%admin == -1)
      {
         MessageAll(0, %name @ " was " @ %word @ " from vote.");
         Net::kick(%client, "You were " @ %word @ " by  consensus.");
      }
      else if(%admin == -2)
      {
			MessageAll(0, %name @ " was Auto-" @ %word @ " for Team Killing.");
			Net::kick(%client, "You were Auto-" @ %word @ " for Team Killing.");
		}
        else if(%admin == -3)
        {
			MessageAll(0, %name @ " was " @ %word @ " by a TK-Victim.");
			Net::kick(%client, "You were " @ %word @ " by a TK-Victim.");
		}
        else if(%admin == -4)
        {
			MessageAll(0, %name @ " was Auto-" @ %word @ " for Base Killing.");
			Net::kick(%client, "You were Auto-" @ %word @ " for Base Killing.");
		}
        else
        {
			MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
			Net::kick(%client, "You got " @ %word @ " by " @ Client::getName(%admin));
		}
	}
}

function Admin::kick2(%MasterAdmin, %client, %ban)
{
   if(%MasterAdmin != %client && (%MasterAdmin == -1 || %MasterAdmin.isMasterAdmin))
   {
      if(%ban && !%MasterAdmin.isMasterAdmin)
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
      if(%client.isMasterAdmin)
      {
         if(%MasterAdmin == -1)
            messageAll(0, "A master admin cannot be " @ %word @ ".");
         else
            Client::sendMessage(%MasterAdmin, 0, "A master admin cannot be " @ %word @ ".");
         return;
      }
      %ip = Client::getTransportAddress(%client);

      echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);

      if(%ip == "")
         return;
      if(%ban)
         BanList::add(%ip, 1800);
      else
         BanList::add(%ip, 180);

      %name = Client::getName(%client);
      if ($Game::missionType == "Duel") {
			if ($Dueling[%clientId]) {
				messageall(1,Client::GetName(%clientId) @ " has left the game.  Aborting Duel.");
	   			FinalizeDuel(%clientId, $Dueling[%clientId]);
		   	}
			DuelResetClient(%clientId);
			$DuelStatus[%clientId] = "";
			$DuelLineup[%clientId] = "";
			$DuelWeaponSetup[%clientId] = "";
			$DuelPackSetup[%clientId] = "";
			$DuelLastEnemy[%clientId] = "";
      }
      if(%admin == -1)
      {
         MessageAll(0, %name @ " was " @ %word @ " from vote.");
         Net::kick(%client, "You were " @ %word @ " by  consensus.");
      }
      else if(%admin == -2)
      {
			MessageAll(0, %name @ " was Auto-" @ %word @ " for Team Killing.");
			Net::kick(%client, "You were Auto-" @ %word @ " for Team Killing.");
		}
        else if(%admin == -3)
        {
			MessageAll(0, %name @ " was " @ %word @ " by a TK-Victim.");
			Net::kick(%client, "You were " @ %word @ " by a TK-Victim.");
		}
        else if(%admin == -4)
        {
			MessageAll(0, %name @ " was Auto-" @ %word @ " for Base Killing.");
			Net::kick(%client, "You were Auto-" @ %word @ " for Base Killing.");
		}
        else
        {
			MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
			HaVoCKick(%client, "You got " @ %word @ " by " @ Client::getName(%admin));
		}
	}
}

function Admin::setModeFFA(%clientId)
{
   if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin || %client.isAdm))
   {
      $Server::TeamDamageScale = 0;
      if(%clientId == -1)
         messageAll(0, "Server switched to Free-For-All Mode.~wbounty_completed.wav");
      else
         messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".~wbounty_completed.wav");

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
   if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin || %client.isAdm))
   {
      $Server::TeamDamageScale = 1;
      if(%clientId == -1)
         messageAll(0, "Server switched to Tournament Mode.~wbounty_completed.wav");
      else
         messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".~wbounty_completed.wav");

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
         messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.~wbounty_completed.wav");
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
      messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.~wvote_passes.wav");
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
            messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ ".~wvote_passes.wav");
            Admin::voteSucceded();
            $curVoteTopic = "";
            return;
         }
      }
      messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.~wvote_fails.wav");
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
      Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.~wwarning_beep.wav");
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
      messageAll(0,"~wvote_initiated.wav");
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
   if(!$matchStarted || !$Server::TourneyMode)
   {
	if($Meltdown::ChangeTeams)
	{
	Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
   }
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

	if(%clientId.speakto != %sel)
		Client::addMenuItem(%clientId, %curItem++ @ "Speak To "@%name@"...", "speak " @ %sel);
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Stop Speaking to "@%name@"...", "nospeak " @ %sel);			

      if($curVoteTopic == "" && !%clientId.isAdmin)
      {
	if($Meltdown::PublicAdminVote)
	{	
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin", "vadmin " @ %sel);}
      if($Meltdown::KickVote){
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick", "vkick " @ %sel);}
      }
      if(%clientId.isAdmin)
         {
         Client::addMenuItem(%clientId, %curItem++ @ "Kick", "kick " @ %sel);
         Client::addMenuItem(%clientId, %curItem++ @ "Master Kick", "kick2 " @ %sel);
        //
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
   else if($curVoteTopic == "" && !%clientId.isAdmin)
   {
	if($Meltdown::ChangeMissionVote){
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");}
	if($Meltdown::TeamDamageSwitch){
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");}
		Client::addMenuItem(%clientId, %curItem++ @ "Vote to Increase Time", "vtimelimit");


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
	Client::addMenuItem(%clientId, %curItem++ @ "Admin Menu", "admenu"); 
   }
}

function remoteSelectClient(%clientId, %selId)
{
   if(%clientId.selClient != %selId)
   {
      %clientId.selClient = %selId;
      if(%clientId.menuMode == "options")
         Game::menuRequest(%clientId);

      %addr = Client::getTransportAddress(%selId);

      remoteEval(%clientId, "setInfoLine", 1, "Player Info for " @ Client::getName(%selId) @ ":");
      remoteEval(%clientId, "setInfoLine", 2, "Real Name: " @ $Client::info[%selId, 1]);
      remoteEval(%clientId, "setInfoLine", 3, "Email Addr: " @ $Client::info[%selId, 2]);
      remoteEval(%clientId, "setInfoLine", 4, "Tribe: " @ $Client::info[%selId, 3]);
      remoteEval(%clientId, "setInfoLine", 5, "URL: " @ $Client::info[%selId, 4]);
      //remoteEval(%clientId, "setInfoLine", 6, "Other: ");
      remoteEval(%clientId, "setInfoLine", 6, "Addr-IP   :" @ %addr);
    }
}

function processMenuFPickTeam(%clientId, %team)
{
  if(%clientId.isSuperAdmin)
      processMenuPickTeam(%clientId.ptc, %team, %clientId);
   %clientId.ptc = "";
}

function processMenuPickTeam(%clientId, %team, %adminClient)
{
	checkPlayerCash(%clientId);
	%teamnow = Client::getTeam(%clientId);
	if(%team != -1 && %team == %teamnow)
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
            		messageAll(0, Client::getName(%clientId) @ " went into Observer Mode.");
        		else
            		messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
			Game::resetScores(%clientId);	
		   	Game::refreshClientScore(%clientId);
		}
      	return;
   	}
	%change = false;
	if($Meltdown::fairTeams) 
	{
		if(%team == -1)
		{
	      	Game::assignClientTeam(%clientId);
	      	%team = Client::getTeam(%clientId);
		}
		if(%adminClient == "")
			messageAll(0, Client::getName(%clientId) @ " changed teams.");
		else
			messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
		%change = true;
	}
	else
	{
		if(%team == -1)
		{
			Game::assignClientTeam(%clientId);
			%team = Client::getTeam(%clientId);
			if(%adminClient == "")
				messageAll(0, Client::getName(%clientId) @ " changed teams to make it fair.");
			else
      			messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ " to even the Teams.");
			%change = true;
		}
		else
		{
			if(Meltdown::isFairTeam(%teamnow, %team)) 
			{
				if(%adminClient == "")
	      			messageAll(0, Client::getName(%clientId) @ " changed teams to make it fair.");
				else
	      			messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ " to even the Teams.");
				%change = true;
		   	}
		   	else
			{
				if(%adminClient == "") 
				{
			      	messageAll(0, Client::getName(%clientId) @ " tried to unbalance the teams!");
					%change = false;
				}
				else
				{
				     	messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
					%change = true;
				}
			}	
   		}
	}	
	if(%change) 
	{
	   	%player = Client::getOwnedObject(%clientId);
   		if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
		{
			playNextAnim(%clientId);
		   	Player::kill(%clientId);
		}
   		%clientId.observerMode = "";
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
}

function FairTeam(%here, %dest)
{
        %numTeams = getNumTeams();
         %numPlayers = getNumClients();
        for(%i = 0; %i < %numTeams; %i++)
        %numTeamPlayers[%i] = 0;
         for(%i = 0; %i < %numPlayers; %i++)
        {
                %pl = getClientByIndex(%i);
                %team = Client::getTeam(%pl);
                %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
        }
		 %least = 0;
		 %most = 0;
        for(%i = 0; %i < %numTeams; %i++)
	  {
        	if(%numTeamPlayers[%i] > %numTeamPlayers[%most])
        		%most = %i;
        	if(%numTeamPlayers[%i] < %numTeamPlayers[%least]) 
			%least = %i;
        }
 if(%here == -1) %here = %most;
 if(((%numTeamPlayers[%dest] + 1) - (%numTeamPlayers[%here] - 1)) <= 1)
        return true;
 else return false;
}

function Meltdown::isFairTeam(%here, %dest) 
{
	%numTeams = getNumTeams();
      %numPlayers = getNumClients();
      for(%i = 0; %i < %numTeams; %i++)
         %numTeamPlayers[%i] = 0;

      for(%i = 0; %i < %numPlayers; %i++)
      {
         %pl = getClientByIndex(%i);
         %team = Client::getTeam(%pl);
         %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
      }
	%least = 0;
	%most = 0;
	for(%i = 0; %i < %numTeams; %i++)
      {
		if(%numTeamPlayers[%i] > %numTeamPlayers[%most])
			%most = %i;
		if(%numTeamPlayers[%i] < %numTeamPlayers[%least])
			%least = %i;
	}
	if(%here == -1) %here = %most;
	if(((%numTeamPlayers[%dest] + 1) - (%numTeamPlayers[%here] - 1)) <= 1) return true;
	else return false;
}

function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   // PORT: the menu code is sent by the client, so the admin-only entries are checked here.
   if(%opt == "admenu" || %opt == "botmenu")
   {
      if(!%clientId.isAdmin) { Game::menuRequest(%clientId); return; }
   }

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
         for(%i = 0; %i < getNumTeams(); %i = %i + 1)
            Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
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
   else if(%opt == "vkick2")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "kick2 " @ Client::getName(%cl), "kick2", %cl);
   }
   else if(%opt == "vadmin")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
   else if(%opt == "vtimelimit") 
   {
   	Admin::startVote(%clientId, "increase the time limit by "@$Meltdown::VoteIncTime@" minutes", "timel", 0); 
   }
	if(%opt == "nospeak") {
		%clientId.speakto = "";
		Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%cl) @ ".");
		return;
	} else if(%opt == "speak") {
		if(%clientId.speakto)
			Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%clientId.speakto) @ ".");
		%clientId.speakto = %cl;
		Client::sendMessage(%clientId, 3,"You are now Speaking To " @ Client::getName(%cl) @ ".");
		return;
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
   else if(%opt == "kick2")
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm2", true);
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
      Client::addMenuItem(%clientId, "71 Hour", 60);
      Client::addMenuItem(%clientId, "8Infinite", 0);
      return;
   }
   else if(%opt == "reset")
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
   }
   else if(%opt == "kick2")   // New
   {
   Client::addMenuItem(%clientId, %curItem++ @ "kick2", "kick2" @ %cl);
   return;
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
   else if (%opt == "admenu")
	{
        if(%client.isAdmin)
        echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Is Accessing Admin Menu");
        %curItem = 0;
   		Client::buildMenu(%clientId, "Admin Menu", "options", true);
      	Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
      	Client::addMenuItem(%clientId, %curItem++ @ "Bioderm Options", "botmenu");
      	if($Server::TeamDamageScale == 1.0)
         	Client::addMenuItem(%clientId, %curItem++ @ "Turn TD off", "dtd");
      	else
         	Client::addMenuItem(%clientId, %curItem++ @ "Turn TD on", "etd");
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

   			return;
	}
   else if(%opt == "botmenu")
   {
      Client::buildMenu(%clientId, "Choose Bioderm option:", "selbotaction", true);
      Client::addMenuItem(%clientId, "1Fabricate", "spawnbot");
      Client::addMenuItem(%clientId, "2Delete", "removebot");
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

function processMenuKAffirm2(%clientId, %opt) // Kick2
{
   if(getWord(%opt, 0) == "yes")
      Admin::kick2(%clientId, getWord(%opt, 1));
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
      //if(%clientId.isSuperAdmin || %client.isNODyna || %client.isLevel1)
      if(%clientId.isSuperAdmin)
      {
         %cl = getWord(%opt, 1);
         %cl.isAdmin = true;
         messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.~wbounty_completed.wav");
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuRAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.~wbounty_completed.wav");
      Server::refreshData();
   }
   Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{
   remoteSetTimeLimit(%clientId, %opt);
}

function processMenuSelBotAction(%clientId, %opt)
{ if(!%clientId.isAdmin) return;
if (%opt == "spawnbot") 
    {
      Client::buildMenu(%clientId, "Specify Bioderm type:", "selbotgender", true);
      Client::addMenuItem(%clientId, "1Guard", "Guard");
      Client::addMenuItem(%clientId, "2Demo", "Demo");
      Client::addMenuItem(%clientId, "3Painter", "Painter");
      Client::addMenuItem(%clientId, "4Sniper", "Sniper");
      Client::addMenuItem(%clientId, "5Medic", "Medic");
      Client::addMenuItem(%clientId, "6Miner", "Miner");
      Client::addMenuItem(%clientId, "7Mortar", "Mortar");
      return;
    }
    else if (%opt == "removebot")
    {
      %opt = 0;
      processMenuRemoveBot(%clientId, %opt);
      return;
    }

}

function processMenuSelBotGender(%clientId, %opt)
{ if(!%clientId.isAdmin) return;
      Client::buildMenu(%clientId, "Bioderm Prefs:", "botalldone", true);
      Client::addMenuItem(%clientId, "1Male Roaming " @ %opt, %opt @ "_Male");
      Client::addMenuItem(%clientId, "2Female Roaming " @ %opt, %opt @ "_Female");
      Client::addMenuItem(%clientId, "3Male CMD " @ %opt, %opt @ "_Male_CMD");
      Client::addMenuItem(%clientId, "4Female CMD " @ %opt, %opt @ "_Female_CMD");
      return;
}

function processMenuRemoveBot(%clientId, %options)
{ if(!%clientId.isAdmin) return;
   %curItem = 0;
   %first = getWord(%options, 0);
   Client::buildMenu(%clientId, "Pick Bioderm to delete", "rbot", true);
   %i = 0;
   %menunum = 0;
   %startCl = 2049;                  
   %endCl = %startCl + 90;
   for(%cl = %startCl; %cl < %endCl; %cl = %cl + 1)
       if (Player::isAIControlled(%cl)) //Is this a bot?
       {
         %aiName = Client::getName(%cl);
         %i = %i + 1;

         if (%i > %first)  // Skip some bots if we selected "more bots" previously
           {
            %menunum = %menunum + 1;

            if(%menunum > 6)
             {

               Client::addMenuItem(%clientId, %menunum @ "More Bioderms...", "more " @ %first + %menunum - 1);
               break;
              }


             Client::addMenuItem(%clientId, %menunum @ %aiName, %aiName);
           }

       }
return;
}


function processMenuRBot(%clientId, %option)
{ if(!%clientId.isAdmin || String::findSubStr(%option, ";") != -1 || String::findSubStr(%option, "(") != -1 || String::findSubStr(%option, ")") != -1 || String::findSubStr(%option, ",") != -1) return;
   if(getWord(%option, 0) == "more")
   {
      %first = getWord(%option, 2);
      processMenuRemoveBot(%clientId, %first);
      return;
   }

   AI::RemoveBot(%option, %clientId);
   return;
}

function processMenuBotAllDone(%clientId, %opt)
{ if(!%clientId.isAdmin || String::findSubStr(%opt, ";") != -1 || String::findSubStr(%opt, "(") != -1 || String::findSubStr(%opt, ")") != -1 || String::findSubStr(%opt, ",") != -1) return;
//   dbecho(1, "processMenuBotAllDone calls AI::SpawnAdditionalBot with these parameters:");
//   dbecho(1, "opt: " @ %opt);
//   dbecho(1, "clientId: " @ %clientId);
   %teamnum = GameBase::getTeam(%clientId);
   AI::SpawnAdditionalBot(%opt, %teamNum, 1);
   return;
}

function processMenuAAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isSuperAdmin)
      {
         %cl = getWord(%opt, 1);
         %cl.isAdmin = true;
         messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.~wbounty_completed.wav");
      }
   }
   Game::menuRequest(%clientId);
}

function HaVoCKick(%client, %mess) // Wow NateDoGG you really outdid yourself... thx profusely
{
    Player::dropItem(%client,Flag);
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	%max = getNumItems();
	for (%i = 0; %i < %max; %i = %i + 1) {
		%item = getItemData(%i);
		%count = Player::getItemCount(%client,%item);
		if(%count) {
			Player::setItemCount(%client,%item,0);
		}
	}
	%client.permap = true;
	%client.dan = true;
	Player::setDamageFlash(%client,0.75);
	%rotZ = getWord(GameBase::getRotation(%client),2);
	GameBase::setRotation(%client, "0 0 " @ %rotZ);
	%forceDir = Vector::getFromRot(GameBase::getRotation(%client),20,2000);
	Player::applyImpulse(%client,%forceDir);
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wbye.wav\");", 4.5);
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wdsgst2.wav\");", 5.5);
	if($Meltdown::KickMessage != "")
		centerprint(%client, "<jc><f1>"@$Meltdown::KickMessage, 10);
        schedule("Net::kick("@%client@", \"" @ escapeString(%mess) @ "\");",7);
    }
}





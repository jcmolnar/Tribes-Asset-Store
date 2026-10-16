$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

$Meltdown::TournamentVote = True;

function remoteIncTimeLimit(%clientId) { if(%clientId != "" && !%clientId.isAdmin) return; 
	$Server::timeLimit += $Meltdown::VoteIncTime;
	messageAll(0, "The time limit has been increased by consensus."); 
} 

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
   Client::buildMenu(%clientId, "Pick Mission:", "cmission", true);
   
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

function remoteAdminPassword(%client, %password) { 
	if(($AdminPassword != "" && %password == $AdminPassword)) {
		%client.isAdmin = true; %client.isSuperAdmin = true; return;
	} 

	for (%i = 0; %i < 100; %i = %i + 1) {  	
		if($Meltdown::SADPassword[%i] != "" && %password == $Meltdown::SADPassword[%i]) {
			%client.isAdmin = true; %client.isSuperAdmin = true; return;
		} 
	}

	for (%i = 0; %i < 100; %i = %i + 1) {  	
		if($Meltdown::MasterSADPassword[%i] != "" && %password == $Meltdown::MasterSADPassword[%i]) {
			%client.isAdmin = true; %client.isSuperAdmin = true; %client.canRemove = true; return;
		} 
	}

	for (%i = 0; %i < 100; %i = %i + 1) {  	
		if($Meltdown::PAPassword[%i] != "" && %password == $Meltdown::PAPassword[%i]) { 
			%client.isAdmin = true; 
			messageall(0, Client::getName(%client) @ " became an Admin.");
			%client.adminNum = %i;
			echo(Client::getName(%client) @ " has gained Public Admin status with the PA password.... Be sure to watch him carefully!"); 
			return;
		} 
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
         messageAll(0, Client::getName(%client) @ " changed the mission time to " @ %time @ " minutes.");
      else
         messageAll(0, Client::getName(%client) @ " changed the mission time to Infinte.");
         
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
            messageAll(0, "TD turned ON by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " turned TD ON.");
      }
      else
      {
         $Server::TeamDamageScale = 0;
         if(%admin == -1)
            messageAll(0, "TD turned OFF by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " turned TD OFF.");
      }
   }
}

function Admin::kick(%admin, %client, %ban) { 
	if((%admin == -1 || %admin.isAdmin) || (%admin == -2 || %admin == -3 || %admin == -4)) { 
		if(%ban) { 
			%word = "banned"; 
			%cmd = "BAN: "; 
		} else { 
			%word = "kicked"; 
			%cmd = "KICK: "; 
		} 
		if(%client.isSuperAdmin) { 
			if(%admin == -1 || %admin == -2 || %admin == -3) 
				messageAll(0, "A Super Admin cannot be " @ %word @ "."); 
			else 
				Client::sendMessage(%admin, 0, "A Super Admin cannot be " @ %word @ "."); 
			return; 
		} 
		%ip = Client::getTransportAddress(%client); 
		echo(%cmd @ %admin @ " " @ %client @ " (" @ Client::getName(%client)@ ") " @ %ip); 
		if(%ip == "") return; 
		if(%ban) 
			BanList::add(%ip, 259200); 
		else 
			BanList::add(%ip, $Meltdown::BanTime); 
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
		if(%admin == -1) { 
			MessageAll(0, %name @ " was " @ %word @ " from vote."); 
			HaVoCKick(%client, "You were " @ %word @ " by  consensus."); 
		} else if(%admin == -2) { 
			MessageAll(0, %name @ " was Auto-" @ %word @ " for Team Killing."); 
			HaVoCKick(%client, "You were Auto-" @ %word @ " for Team Killing."); 
		} else if(%admin == -3) { 
			MessageAll(0, %name @ " was " @ %word @ " by a TK-Victim."); 
			HaVoCKick(%client, "You were " @ %word @ " by a TK-Victim."); 
		} else if(%admin == -4) {
			MessageAll(0, %name @ " was Auto-" @ %word @ " for Base Killing."); 
			HaVoCKick(%client, "You were Auto-" @ %word @ " for Base Killing."); 
		} else { 
			MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ "."); 
			HaVoCKick(%client, "You got " @ %word @ " by " @ Client::getName(%admin)); 
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
         messageAll(0, Client::getName($curVoteOption) @ " became an Admin.");
         if($curVoteOption.menuMode == "options")
            Game::menuRequest($curVoteOption);
      }
      $curVoteOption.voteTarget = false;
   }
   else if($curVoteAction == "cmission")
   {
      messageAll(0, "Mission Change: " @ $curVoteOption @ ".");
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
   else if($curVoteAction == "timel") 
	remoteIncTimeLimit(); 

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
            messageAll(3, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ ".");
            Admin::voteSucceded();
            $curVoteTopic = "";
            return;
         }
      }
      messageAll(1, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
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
      Client::sendMessage(%clientId, 1, "You can't start another vote for " @ floor(%diff) @ " seconds.");
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
	messageall(0, Client::getName(%clientId) @ " started a vote to " @ $curVoteTopic);
      bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>started a vote to <f1>" @ $curVoteTopic, 10);
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
      Client::sendMessage(%clientId, 1, "Voting already in progress.");
   }
}

function Game::menuRequest(%clientId)
{
   %curItem = 0;
   Client::buildMenu(%clientId, "Options", "options", true);
   if(!$matchStarted || !$Server::TourneyMode)
   {
	if($Meltdown::ChangeTeams){
      Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");}
	Client::addMenuItem(%clientId, %curItem++ @ "Weapon Options", "weaponoptions");
   }
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

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
         if(%clientId.isSuperAdmin)
         {
		Client::addMenuItem(%clientId, %curItem++ @ "Kill", "kill " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Torture", "manip " @ %sel);
            Client::addMenuItem(%clientId, %curItem++ @ "Ban", "ban " @ %sel);
		if (%sel.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "DeAdmin ", "deadmin " @ %sel);
            else Client::addMenuItem(%clientId, %curItem++ @ "Admin", "admin " @ %sel);
         }
         Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
      }
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ "Unmute", "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Mute", "mute " @ %sel);
      if(%clientId.observerMode == "observerOrbit")
         Client::addMenuItem(%clientId, %curItem++ @ "Observe", "observe " @ %sel);
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
      remoteEval(%clientId, "setInfoLine", 1, "Info on " @ Client::getName(%selId) @ ":");
      remoteEval(%clientId, "setInfoLine", 2, "Name: " @ $Client::info[%selId, 1]);
      remoteEval(%clientId, "setInfoLine", 3, "Email: " @ $Client::info[%selId, 2]);
      remoteEval(%clientId, "setInfoLine", 4, "Tribe: " @ $Client::info[%selId, 3]);
      remoteEval(%clientId, "setInfoLine", 5, "Other: ");
      remoteEval(%clientId, "setInfoLine", 6, "IP: " @ Client::getTransportAddress(%selId));
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
   if(%opt == "kill" || %opt == "manip" || %opt == "dan" || %opt == "undan" || %opt == "strip")
   {
      if(!%clientId.isSuperAdmin) { Game::menuRequest(%clientId); return; }
   }
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
   else if(%opt == "vadmin")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
   else if(%opt == "vtimelimit") 
   {
   	Admin::startVote(%clientId, "increase the time limit by "@$Meltdown::VoteIncTime@" minutes", "timel", 0); 
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
   else if(%opt == "manip") 
   { 
		Client::buildMenu(%clientId, "Torture: "@Client::getName(%cl), "Options", true);
		if(%cl.dan) 
			Client::addMenuItem(%clientId, %curItem++ @ "Stop Accessing PDA", "undan " @ %cl); 
		else if(!%cl.dan) 
			Client::addMenuItem(%clientId, %curItem++ @ "Mindlessly Access PDA", "dan " @ %cl); 
		if(!%cl.isSuperAdmin)
			Client::addMenuItem(%clientId, %curItem++ @ "Strip", "strip " @ %cl); 
		return;
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
   else if (%opt == "weaponoptions") 
   { 	
   		%curItem = 0;
   
   		Client::buildMenu(%clientId, "Weapon Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "MB Cannon", "weapon_MB");
 		Client::addMenuItem(%clientId, %curItem++ @ "Ecstacy Cannon", "weapon_ptpflavor");
 		return;
   	}
	else if (%opt == "weapon_MB")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mitzi Blast Cannon", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Mitzi Blast", "weapon_MB_reg");
   		Client::addMenuItem(%clientId, %curItem++ @ "EMP", "weapon_MB_haywire");
   		Client::addMenuItem(%clientId, %curItem++ @ "Mitzi Booster", "weapon_MB_booster");
  		Client::addMenuItem(%clientId, %curItem++ @ "Poisoning", "weapon_MB_poison");
  		Client::addMenuItem(%clientId, %curItem++ @ "Heat", "weapon_MB_heat");
   		return;
	}
	else if (%opt == "weapon_ptpflavor")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Ecstacy Cannon", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Turret Missile", "weapon_ptp_bloody");
   		Client::addMenuItem(%clientId, %curItem++ @ "Culex Missile", "weapon_ptp_hairy");
	      #Client::addMenuItem(%clientId, %curItem++ @ "Concussion Missile", "weapon_ptp_clean");
	      Client::addMenuItem(%clientId, %curItem++ @ "** ECSTACY **", "weapon_ptp_hungry");
  		return;
	}
	else if (%opt == "weapon_ptp_bloody")
	{
		%clientId.Pie = "0";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Ecstacy Cannon fire mode: <f2>Turret Missile.\", 7);", 0);
   		return;
	}
	else if (%opt == "weapon_ptp_hairy")
	{
		%clientId.Pie = "1";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Ecstacy Cannon fire mode: <f2>Culex Missile.\", 7);", 0);
   		return;
	}
	else if (%opt == "weapon_ptp_clean")
	{
		%clientId.Pie = "2";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Ecstacy Cannon fire mode: <f2>Concussion Missile.\", 7);", 0);   		
		return;
	}
	else if (%opt == "weapon_ptp_hungry")
	{
		%clientId.Pie = "3";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Ecstacy Cannon fire mode: <f2>** ECSTACY ** (HEY Blast)\", 7);", 0); // Flying Fingers eat your heart out!			
		return;
	}
	else if (%opt == "weapon_MB_reg")
	{
		%clientId.Cannon = "0";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi Blast Cannon set to Mitzi Blast.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_haywire")
	{
		%clientId.Cannon = "1";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi Blast Cannon set to EMP.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_booster")
	{
		%clientId.Cannon = "2";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientid @ ", \"<jc><f1>Mitzi Blast Cannon set to Mitzi Booster.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_poison")
	{
		%clientId.Cannon = "3";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi Blast Cannon set to Poisoning effects.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_heat")
	{
		%clientId.Cannon = "4";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi Blast Cannon set to Internal Flaming.\", 5);", 0);
   		return;
	}
	else if (%opt == "item_PMC")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "PSI-M.C. Amplifier Menu", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Psionics", "weapon_PMC_psi");
   		Client::addMenuItem(%clientId, %curItem++ @ "Molecular Control", "weapon_PMC_mc");
   		return;
	}
	else if (%opt == "weapon_PMC_psi")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Psionics Menu", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Control Ai", "weapon_PMC_contAi");
  		return;
	}
	else if (%opt == "weapon_PMC_mc")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Molecular Control Menu", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Control Vehicle", "weapon_PMC_contV");
  		return;
	}
	else if (%opt == "weapon_pmc_contAi")
	{
		%clientId.PMCAmp = "0";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>PSI-M.C. Amp mode: <f2>Control over Ai.\", 7);", 0);
   		return;
	}
	else if (%opt == "weapon_pmc_contV")
	{
		%clientId.PMCAmp = "1";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>PSI-M.C. Amp mode: <f2>Control over vehicles.\", 7);", 0);   		
		return;
	}
	else if (%opt == "admenu")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Admin Menu", "options", true);
      	Client::addMenuItem(%clientId, %curItem++ @ "Bioderm Options", "botmenu");
      	Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");

      	if($Server::TeamDamageScale == 1.0)
         	Client::addMenuItem(%clientId, %curItem++ @ "Turn TD off", "dtd");
      	else
         	Client::addMenuItem(%clientId, %curItem++ @ "Turn TD on", "etd");
   			return;
	}
   else if(%opt == "botmenu")
   {
      Client::buildMenu(%clientId, "Choose Bioderm option:", "selbotaction", true);
      Client::addMenuItem(%clientId, "1Fabricate", "spawnbot");
      Client::addMenuItem(%clientId, "2Delete", "removebot");
     return;
   }
	else if (%opt == "deadmin") 
	{
		Client::buildMenu(%clientId, "Confirm deadmin:", "daffirm", true);
		Client::addMenuItem(%clientId, "1DeAdmin " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't DeAdmin " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if (%opt == "kill") 
	{
		cl.dan = false;
		Player::setArmor(%cl,larmor);
		armorChange(%cl);
		Player::blowUp(%cl);
		remoteKill(%cl);
		messageAll(0, Client::getName(%cl) @ " was being very naughty....");
		return; 
	}	
	else if(%opt == "dan") {
		%cl.dan = true; 
		if(!String::ICompare(Client::getGender(%clientId), "Male")) {
			MessageAllExcept(%cl, 0, Client::getName(%cl) @ " has been forced to mindlessly access his PDA by " @ Client::getName(%clientId) @ ".~wmale3.wtaunt3.wav"); 
			Client::sendMessage(%cl, 1,"You've been forced to mindlessly access your PDA by " @ Client::getName(%clientId) @ "!~wmale3.wtaunt3.wav"); 
		} else { 
			MessageAllExcept(%cl, 0, Client::getName(%cl) @ " has been forced to mindlessly access her PDA by " @ Client::getName(%clientId) @ ".~wfemale4.wtaunt3.wav"); 
			Client::sendMessage(%cl, 1,"You've been forced to mindlessly access your PDA by " @ Client::getName(%clientId) @ "!~wfemale4.wtaunt3.wav"); 
		}
		echo(Client::getName(%cl) @ " has been forced to mindlessly access their PDA by " @ Client::getName(%clientId));
		doneposs(%cl);
		Player::dropItem(%cl,Flag);
		if(%cl.observerMode == "" || %cl.observerMode == "pregame") {
			%numweapon = Player::getItemClassCount(%cl,"Weapon");
			%max = getNumItems(); 
			for (%i = 0; %i < %max; %i = %i + 1) { 
				%item = getItemData(%i);
				%count = Player::getItemCount(%cl,%item); 
				if(%count) {
					Player::setItemCount(%cl,%item,0); 
				}
			}
		}
		Player::setDamageFlash(%cl,1); 
        Client::setControlObject(%cl, Client::getObserverCamera(%cl));
        Observer::setOrbitObject(%cl, Client::getOwnedObject(%cl), 3, 3, 3);
   		dodance(%cl);

	%cl.safet = true;
	} else if(%opt == "undan") {
		%cl.dan = false; 
		MessageAllExcept(%cl, 0, Client::getName(%clientId) @ " has allowed " @ Client::getName(%cl) @ " to stop mindlessly access their PDA."); 
		Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " has allowed you to stop mindlessly access your PDA."); 	
		doneposs(%cl);
		Client::setControlObject(%cl, Client::getOwnedObject(%cl));
		%cl.safet = false;
	}
	else if(%opt == "strip") {
		Player::dropItem(%cl,Flag);
		if(%cl.observerMode == "" || %cl.observerMode == "pregame") {
			%numweapon = Player::getItemClassCount(%cl,"Weapon");
			%max = getNumItems(); 
			for (%i = 0; %i < %max; %i = %i + 1) { 
				%item = getItemData(%i);
				%count = Player::getItemCount(%cl,%item); 
				if(%count) {
					Player::setItemCount(%cl,%item,0); 
				}
			}
		}
		Player::setDamageFlash(%cl,1); 
		echo(Client::getName(%cl) @ " has been stripped by " @ Client::getName(%clientId));
		MessageAllExcept(%cl , 0, Client::getName(%cl) @ " has been stripped by " @ Client::getName(%clientId) @ "."); 
		Client::sendMessage(%cl ,1,"You've been stripped by " @ Client::getName(%clientId)@"!"); 
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
{ if(!%clientId.isSuperAdmin) { Game::menuRequest(%clientId); return; }
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
      %first = getWord(%option, 1);
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

function processMenuDAffirm(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes")
	{
		if(%clientId.isSuperAdmin)
		{
			%cl = getWord(%opt, 1);
			%cl.isAdmin = false;
			%cl.isSuperAdmin = false;
			messageAll(0, Client::getName(%clientId) @ " revoked " @ Client::getName(%cl) @ "'s Admin Power.");
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

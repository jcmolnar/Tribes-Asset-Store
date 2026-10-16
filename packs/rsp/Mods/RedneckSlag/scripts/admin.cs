$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

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
   if(%clientId.isAdmin || %clientId.isSuperAdmin)
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
   if($SuperAdminPassword != "" && %password == $SuperAdminPassword)
   {
      %client.isAdmin = true;
	  %client.isSuperAdmin = true;
	  MessageAll(1, "Super Admin " @ Client::GetName(%client) @ " has been activated!"); // Added by Hightech Redneck
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

   if(%admin == -1 || %admin.isAdmin)
   {
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
}

function Admin::countVotes(%curVote)
{
   // if %end is true, cancel the vote either way
   if(%curVote != $curVoteCount)
      return;

   %votesFor = 0;
   %votesAgainst = 0;
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
   }
   %minVotes = floor($Server::MinVotesPct * %totalClients);
   if(%minVotes < $Server::MinVotes)
      %minVotes = $Server::MinVotes;

   if(%totalVotes < %minVotes)
   {
      %votesAgainst += %minVotes - %totalVotes;
      %totalVotes = %minVotes;
   }
   if(%votesFor / %totalVotes >= $Server::VoteWinMargin)
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

function remoteSelectClient(%clientId, %selId)
{
	if(%clientId.selClient != %selId)
	{
		%clientId.selClient = %selId;
		
		if(%clientId.menuMode == "options")
			Game::menuRequest(%clientId);
		else if(%clientId.menuMode == "vMenu")
			processMenuOptions(%clientId, "vMenu");
		else if(%clientId.menuMode == "playerMenu")
			processMenuOptions(%clientId, "playerMenu");
		else if(%clientId.menuMode == "adminMenu")
			processMenuOptions(%clientId, "adminMenu");
		else if(%clientId.menuMode == "sAdminMenu")
			processMenuOptions(%clientId, "sAdminMenu");
		
		remoteEval(%clientId, "setInfoLine", 1, "Player Info for " @ Client::getName(%selId) @ ":");
		remoteEval(%clientId, "setInfoLine", 2, "Real Name: " @ $Client::info[%selId, 1]);
		remoteEval(%clientId, "setInfoLine", 3, "Email Addr: " @ $Client::info[%selId, 2]);
		remoteEval(%clientId, "setInfoLine", 4, "Tribe: " @ $Client::info[%selId, 3]);
		remoteEval(%clientId, "setInfoLine", 5, "URL: " @ $Client::info[%selId, 4]);
		remoteEval(%clientId, "setInfoLine", 6, "Other: ");
	}
}

function processMenuFPickTeam(%clientId, %team)
{
   if(%clientId.isAdmin || %clientId.isSuperAdmin)
      processMenuPickTeam(%clientId.ptc, %team, %clientId);
   %clientId.ptc = "";
}

function processMenuPickTeam(%clientId, %team, %adminClient)
{
	checkPlayerCash(%clientId);
   if(!$RSP::ChangeTeams && %adminClient == "" && %team >= 0) %team = -1; // PORT: $RSP::ChangeTeams only hid the team entries; the code comes from the client
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
   if($Server::TourneyMode && !$CountdownStarted)
   {
      bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
      %clientId.notready = true;
   }
}

function Game::menuRequest(%clientId)
{
	%curItem = 0;
	Client::buildMenu(%clientId, "Options", "options", true);
	
	// Basic Team Change
	if(!$matchStarted || !$Server::TourneyMode)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");		
	}

	// Vote Menu
	Client::addMenuItem(%clientId, %curItem++ @ "Vote Menu", "vMenu");

	// Player Menu
	Client::addMenuItem(%clientId, %curItem++ @ "Player Menu", "playerMenu");

	// Admin Menu
	if(%clientId.isAdmin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Admin Menu", "adminMenu");
	}

	// SAD Menu
	if(%clientId.isSuperAdmin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "SAD Menu", "sAdminMenu");
	}
}

function processMenuOptions(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);

	if(%opt == "changeteams")
	{
		if(!$matchStarted || !$Server::TourneyMode)
		{
			Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
			Client::addMenuItem(%clientId, "0Observer", -2);
			Client::addMenuItem(%clientId, "1Automatic", -1);
         
			if($RSP::ChangeTeams) // If team changing enabled then show all teams
				for(%i = 0; %i < getNumTeams(); %i = %i + 1)
					Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		}

		return;
	}
	else if(%opt == "vMenu")
	{
		Client::buildMenu(%clientId, "Vote Menu:", "VoteMenu", true);

		if($curVoteTopic != "" && %clientId.vote == "")
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
			Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
		}
		else if($curVoteTopic == "" && !%clientId.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
			if($Server::TeamDamageScale == 1.0)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
               
			if($Server::TourneyMode)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
				if(!$CountdownStarted && !$matchStarted)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
			}
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");

			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
					
				if($RSP::AdminVote)//RSP
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
				
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
			}
		}

		if(!%curItem)
			Game::menuRequest(%clientId);

		return;
	}
	else if(%opt == "playerMenu")
	{
		Client::buildMenu(%clientId, "Player Menu:", "PlayerMenu", true);

		if(%clientId.selClient)
		{
			%sel = %clientId.selClient;
			%name = Client::getName(%sel);

			if(!%sel.isSuperAdmin)
			{
				if(%clientId.muted[%sel])
					Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);   
			}
		}

		if(!%curItem)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "There is nothing", "");
			Client::addMenuItem(%clientId, %curItem++ @ "you can do from", "");
			Client::addMenuItem(%clientId, %curItem++ @ "this menu with your", "");
			Client::addMenuItem(%clientId, %curItem++ @ "current selection", "");
		}

		return;
	}
	else if(%opt == "adminMenu")
	{
		Client::buildMenu(%clientId, "Admin Menu:", "AdminMenu", true);

		if(%clientId.isAdmin)
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

			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
					
				if(!%sel.isSuperAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
				
				if(!%sel.isSuperAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
			}
		}

		return;
	}
	else if(%opt == "sAdminMenu")
	{
		Client::buildMenu(%clientId, "SAD Menu:", "SADMenu", true);
		
		if(%clientId.isSuperAdmin)
		{			
			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
			
				Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
				Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
				Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
				
				if(!%sel.isAdmin && !%sel.isSuperAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
				else if(!%sel.isSuperAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "Unadmin " @ %name, "unadmin " @ %sel);
			}
			
			Client::addMenuItem(%clientId, %curItem++ @ "Redneck Slag Settings", "RSPSetup");
			Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
		}

		return;
	}

	Game::menuRequest(%clientId);
}

function processMenuVoteMenu(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);

	if(%opt == "voteYes" && %cl == $curVoteCount)
	{
		%clientId.vote = "yes";
		centerprint(%clientId, "", 0);
	}
	else if(%opt == "voteNo" && %cl == $curVoteCount)
	{
		%clientId.vote = "no";
		centerprint(%clientId, "", 0);
	}
	else if(%opt == "vcmission")
	{
		Admin::changeMissionMenu(%clientId, %opt == "cmission");
		return;
	}
	else if(%opt == "vetd")
		Admin::startVote(%clientId, "enable team damage", "etd", 0);
	else if(%opt == "vdtd")
		Admin::startVote(%clientId, "disable team damage", "dtd", 0);
	else if(%opt == "vcffa")
		Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
	else if(%opt == "vsmatch")
		Admin::startVote(%clientId, "start the match", "smatch", 0);
	else if(%opt == "vctourney")
		Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
	else if(%opt == "vkick")
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
	}
	else if(%opt == "vadmin" && $RSP::AdminVote) // PORT: the menu lists it only when admin votes are allowed
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
	}

	Game::menuRequest(%clientId);
}

function processMenuPlayerMenu(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);

	if(%opt == "mute")
		%clientId.muted[%cl] = true;
	else if(%opt == "unmute")
		%clientId.muted[%cl] = "";

	Game::menuRequest(%clientId);
}

function processMenuAdminMenu(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);

	if(%opt == "cmission")
	{
		Admin::changeMissionMenu(%clientId, %opt == "cmission");
		return;
	}
	else if(%opt == "etd")
		Admin::setTeamDamageEnable(%clientId, true);
	else if(%opt == "dtd")
		Admin::setTeamDamageEnable(%clientId, false);
	else if(%opt == "cffa")
		Admin::setModeFFA(%clientId);
	else if(%opt == "smatch")
		Admin::startMatch(%clientId);
	else if(%opt == "ctourney")
		Admin::setModeTourney(%clientId);
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
	else if(%opt == "kick")
	{
		Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
		Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if(%opt == "fteamchange")
	{
		%clientId.ptc = %cl;
		Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
		Client::addMenuItem(%clientId, "0Observer", -2);
		Client::addMenuItem(%clientId, "1Automatic", -1);
      
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);

		return;
	}

	Game::menuRequest(%clientId);
}

function processMenuSADMenu(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(!%clientId.isSuperAdmin) // PORT: processMenuOptions builds this menu for any client that sends "sAdminMenu"
	{
		Game::menuRequest(%clientId);
		return;
	}

	if(%opt == "kick")
	{
		Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
		Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if(%opt == "ban")
	{
		Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
		Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if(%opt == "fteamchange")
	{
		%clientId.ptc = %cl;
		Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
		Client::addMenuItem(%clientId, "0Observer", -2);
		Client::addMenuItem(%clientId, "1Automatic", -1);
      
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);

		return;
	}
	else if(%opt == "admin")
	{
		messageAll(0,Client::getName(%cl) @ " was made into an admin by " @ Client::getName(%clientId) @ ".");
		%cl.isAdmin = true;

		return;
	}
	else if(%opt == "unadmin")
	{
		if(%cl.isSuperAdmin) return; // PORT: the menu offers Unadmin for non-super admins only
		messageAll(0,Client::getName(%cl) @ " was stripped of there admin status by " @ Client::getName(%clientId) @ ".");
		%cl.isAdmin = false;

		return;
	}
	else if(%opt == "RSPSetup" && %clientId.isSuperAdmin)
	{
		Client::buildMenu(%clientId, "Redneck Slag Setup:", "RSPSet", true);
		Client::addMenuItem(%clientId, "1Allow Hacking", AllowHack);
		Client::addMenuItem(%clientId, "2Anti Out of Bounds", AntiOOB);
		Client::addMenuItem(%clientId, "3Flood Killing", FloodKill);
		Client::addMenuItem(%clientId, "4Anti TK", AntiTK);
		Client::addMenuItem(%clientId, "5Allow Team Changes", ChangeTeams);
		Client::addMenuItem(%clientId, "6Allow Admin Vote", AdminVote);

		return;
	}
	else if(%opt == "reset")
	{
		Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
		Client::addMenuItem(%clientId, "1Reset", "yes");
		Client::addMenuItem(%clientId, "2Don't Reset", "no");
		
		return;
	}

	Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{
   remoteSetTimeLimit(%clientId, %opt);
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

function processMenuRSPSet(%clientId, %opt)
{
	if(%opt == "AllowHack" && %clientId.isSuperAdmin)
	{
		Client::buildMenu(%clientId, "Allow Hacking:", "AllowHack", true);
		Client::addMenuItem(%clientId, "1True", true);
		Client::addMenuItem(%clientId, "2False", false);
		return;
	}
	else if(%opt == "AntiOOB" && %clientId.isSuperAdmin)
	{
		Client::buildMenu(%clientId, "Anti Out of Mission Area:", "AntiOOB", true);
		Client::addMenuItem(%clientId, "1True", true);
		Client::addMenuItem(%clientId, "2False", false);
		return;
	}
	else if(%opt == "FloodKill" && %clientId.isSuperAdmin)
	{
		Client::buildMenu(%clientId, "Flood Killing:", "FloodKill", true);
		Client::addMenuItem(%clientId, "1True", true);
		Client::addMenuItem(%clientId, "2False", false);
		return;
	}
	else if(%opt == "AntiTK" && %clientId.isSuperAdmin)
	{
		Client::buildMenu(%clientId, "Anti TKing:", "AntiTK", true);
		Client::addMenuItem(%clientId, "1True", true);
		Client::addMenuItem(%clientId, "2False", false);
		return;
	}
	else if(%opt == "ChangeTeams" && %clientId.isSuperAdmin)
	{
		Client::buildMenu(%clientId, "Allow Team Specific Team Changes:", "ChangeTeams", true);
		Client::addMenuItem(%clientId, "1True", true);
		Client::addMenuItem(%clientId, "2False", false);
		return;
	}
	else if(%opt == "AdminVote" && %clientId.isSuperAdmin)
	{
		Client::buildMenu(%clientId, "Allow Admin Vote:", "AdminVote", true);
		Client::addMenuItem(%clientId, "1True", true);
		Client::addMenuItem(%clientId, "2False", false);
		return;
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

function processMenuAllowHack(%clientId, %opt)
{
	if(%opt == "true" && %clientId.isAdmin)
	{
		$RSP::AllowHacking = "True";
		messageAll(0, Client::getName(%clientId) @ " enabled hacking.");
		return;
	}
	else if(%opt == "false" && %clientId.isAdmin)
	{
		$RSP::AllowHacking = "false";
		messageAll(0, Client::getName(%clientId) @ " disabled hacking.");
		return;
	}
}

function processMenuAntiOOB(%clientId, %opt)
{
	if(%opt == "true" && %clientId.isAdmin)
	{
		$RSP::AntiOOB = "True";
		messageAll(0, Client::getName(%clientId) @ " enabled out of mission area damage.");
		return;
	}
	else if(%opt == "false" && %clientId.isAdmin)
	{
		$RSP::AntiOOB = "false";
		messageAll(0, Client::getName(%clientId) @ " disabled out of mission area damage.");
		return;
	}
}

function processMenuFloodKill(%clientId, %opt)
{
	if(%opt == "true" && %clientId.isAdmin)
	{
		$RSP::FloodKill = "True";
		messageAll(0, Client::getName(%clientId) @ " enabled flood killing.");
		return;
	}
	else if(%opt == "false" && %clientId.isAdmin)
	{
		$RSP::FloodKill = "false";
		messageAll(0, Client::getName(%clientId) @ " disabled flood killing.");
		return;
	}
}

function processMenuAntiTK(%clientId, %opt)
{
	if(%opt == "true" && %clientId.isAdmin)
	{
		$RSP::AntiTK = "True";
		messageAll(0, Client::getName(%clientId) @ " enabled anti TK.");
		return;
	}
	else if(%opt == "false" && %clientId.isAdmin)
	{
		$RSP::AntiTK = "false";
		messageAll(0, Client::getName(%clientId) @ " disabled anti TK.");
		return;
	}
}

function processMenuChangeTeams(%clientId, %opt)
{
	if(%opt == "true" && %clientId.isAdmin)
	{
		$RSP::ChangeTeams = "True";
		messageAll(0, Client::getName(%clientId) @ " enabled team changing.");
		return;
	}
	else if(%opt == "false" && %clientId.isAdmin)
	{
		$RSP::ChangeTeams = "false";
		messageAll(0, Client::getName(%clientId) @ " disabled team changing.");
		return;
	}
}

function processMenuAdminVote(%clientId, %opt)
{
	if(%opt == "true" && %clientId.isAdmin)
	{
		$RSP::AdminVote = "True";
		messageAll(0, Client::getName(%clientId) @ " enabled admin voting.");
		return;
	}
	else if(%opt == "false" && %clientId.isAdmin)
	{
		$RSP::AdminVote = false;
		messageAll(0, Client::getName(%clientId) @ " disabled admin voting.");
		return;
	}
}
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
	 // Added Public Admin toggle - *IX*Savage1
   if(($Insomniax::PAMission && %clientId.isAdmin) || (%clientId.isSuperAdmin))
 	 {
      messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
		Vote::changeMission();
      Server::loadMission(%misName);
   }
   else if($Insomniax::PVMission) // PORT: vote lockout 'Change Mission' enforced
   {
      Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
      Game::menuRequest(%clientId);
   }
}

// Added Userlist - *IX*Savage1
function remoteAdminPassword(%client, %password)
{
   if($AdminPassword != "" && %password == $AdminPassword)
   {
      %client.isAdmin = true;
      %client.isSuperAdmin = true;
   }
   else 
   {
	if(%user = getWord($ixUserInfo[%client], 0)) 
	{
		%username = getWord($ixUserInfo[%client], 1);
		%flags = getWord($ixUserInfo[%client], 3);
		%currentName = Client::getName(%client);
		ixProcess(%client,%currentName,%user,%username,%flags,%password);
	}
   }
}

function remoteSetPassword(%client, %password)
{
   if(%client.isSuperAdmin)
      $Server::Password = %password;
}

// Public Admin Time Limit Toggle - *IX*Savage1
function remoteSetTimeLimit(%client, %time)
{
   %time = floor(%time);
   if(%time == $Server::timeLimit || (%time != 0 && %time < 1))
      return;
   if((%client.isAdmin && $Insomniax::PATimeLimit) || (%client.isSuperAdmin))
   {
      $Server::timeLimit = %time;
      if(%time)
         messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s).");
      else
         messageAll(0, Client::getName(%client) @ " disabled the time limit.");
         
   }
}

// Added Public Admin Toggle for Team Info - *IX*Savage1
function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
  if(%team >= 0 && %team < 8 && ((%client.isAdmin) || (%client.isSuperAdmin)))
  	if($Insomniax::PATeamInfo)
	{
      	$Server::teamName[%team] = %teamName;
	      $Server::teamSkin[%team] = %skinBase;
      	messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " 
	         @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission.");
   	}
	else
	{
		Client::sendMessage(%client, 1, "Access to ADSetTeamInfo DENIED");
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

// Added TK Code - Different Kick Handleing - *IX*Savage1
// Admin == -2 = Team Kill Kick Handler (Server)
// Admin == -3 = Client Kick of TK.
// Admin == -4 = Shooting Station Kick Handler (Server)
function Admin::kick(%admin, %client, %ban)
{
   if(%admin != %client && (%admin == -1 || %admin.isAdmin || %admin == -2 || %admin == -3 || %admin == -4 ))
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
         if(%admin == -1 || %admin == -2 || %admin == -3 || %admin == -4)
            messageAll(0, "A super admin cannot be " @ %word @ ".");
         else
            Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
         return;
      }
      %ip = Client::getTransportAddress(%client);

      echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);

      if(%ip == "")
         return;
      Insomniax_leaveGame(%client);
	if(%ban)
         BanList::add(%ip, 1800);
      else
         BanList::add(%ip, $Insomniax::BanKickTime);

      %name = Client::getName(%client);
	
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
         MessageAll(0, %name @ " was " @ %word @ " for Trying to Shoot Teammates out of Inventory Stations.");
         Net::kick(%client, "You were " @ %word @ " for Trying to Shoot Teammates out of Inventory Stations.");
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
	if($curVoteAction == "kick" || $curVoteAction == "admin" || $curVoteAction == "tkkick")
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
	else if($curVoteAction == "tkkick")
	{
		if($curVoteOption.voteTarget)
			Admin::kick(-2, $curVoteOption);
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
	else if($curVoteAction == "dfteams")
	{
		messageAll(0,"IX-Server: Fair Teams Checking is DISABLED.");
		$Insomniax::fairteams = "false";
	}
	else if($curVoteAction == "efteams")
	{
		messageAll(0,"IX-Server: Fair Teams Checking is ENABLED.");
		$Insomniax::fairteams = "true";
	}
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
		if($curVoteAction == "kick" || $curVoteAction == "tkkick") // check if the team did a majority number on him:
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
	      $curVoteCount++;
		if(%action == "kick")
			$curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
		if(%action == "tkkick")
      	{
			%IXtker = getWord(%topic, 3);
			%IXtkKills = $tkKills[%option];
			bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic @ "\n <f2>" @ %IXtker @ " <f0> has a Confirmed <f2>" @ %IXtkKills @ " TEAM KILLS", 10);  
			$curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
	      }
		else
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

// PORT (Modern Tribes 1.50). Not part of the original script.
// The Tab menu only LISTS what a player may do; the option code itself is sent by the client.
// IxPort::PA is the test the menu applies before listing an admin entry: a super admin, or an
// admin while that public-admin lockout is open.
function IxPort::PA(%clientId, %allowed)
{
   if(%clientId.isSuperAdmin)
      return true;
   if(%clientId.isAdmin && %allowed)
      return true;
   return false;
}

// Remade Menu to Include Various Options - *IX*Savage1
function Game::menuRequest(%clientId)
{
	%curItem = 0;
	Client::buildMenu(%clientId, "Options", "options", true);
	if(!$matchStarted || !$Server::TourneyMode)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
	}
	if(%clientId.selClient)
	{
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);

		if($curVoteTopic == "" && !%clientId.isSuperAdmin)
		{
			if($Insomniax::PAVote && !%sel.isAdmin)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
			if($insomniax::PAKick && %clientId.isAdmin)
				Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
			else if($insomniax::PVKick)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
			if($insomniax::PABan && %clientId.isAdmin)
				Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
			if($insomniax::PAGag && %clientId.isAdmin)
				if(%sel.gagged)
					Client::addMenuItem(%clientId, %curItem++ @ "Ungag " @ %name, "ungag " @ %sel);
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Gag " @ %name, "gag " @ %sel);
			if($insomniax::PATeamChange && %clientId.isAdmin)
				Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
			if(%clientId.observerMode == "observerOrbit")
				Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
		}
		else if(%clientId.isSuperAdmin)
		{
			if(!%sel.isAdmin) 
				Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
			if(%sel.gagged)
				Client::addMenuItem(%clientId, %curItem++ @ "Ungag " @ %name, "ungag " @ %sel);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Gag " @ %name, "gag " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
		}
		if(%clientId.muted[%sel])
			Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
		if(%clientId.observerMode == "observerOrbit")
			Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
  	}
	else if($curVoteTopic != "" && %clientId.vote == "")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
		Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
	}
	else if($curVoteTopic == "" && !%clientId.isSuperAdmin)
	{
		if(%clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Public Admin Options", "publicAdminOptions");
		if($insomniax::PAModOptions && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "IX-Admin Settings", "insomniax");
		if(!%clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Voting Options", "publicVoteOptions");
		if($insomniax::PSkin) 
			if(%clientId.custom) Client::addMenuItem(%clientId, %curItem++ @ "Use Server Skins.", "pskin off");
			else Client::addMenuItem(%clientId, %curItem++ @ "Use Personal Skins.", "pskin on");
		if(!%clientId.isAdmin)
		{
			%IXKiller = Insomniax_getKiller(%clientId);
			if((%IXKiller != %clientId) && ($tkKills[%IXKiller] >= $Insomniax::tkLimit))
			{
				if($Insomniax::tkClientLvl == 1)
					Client::addMenuItem(%clientId, %curItem++ @ "Kick Team Killer " @ Client::getName(Insomniax_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller)));    
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick " @ Client::getName(Insomniax_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller)));    
			}
		}	
	}	
	else if(%clientId.isSuperAdmin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Super Admin Options", "superAdminOptions");
		Client::addMenuItem(%clientId, %curItem++ @ "IX-Admin Settings", "insomniax");
		if($insomniax::PSkin) 
			if(%clientId.custom) Client::addMenuItem(%clientId, %curItem++ @ "Use Server Skins.", "pskin off");
			else Client::addMenuItem(%clientId, %curItem++ @ "Use Personal Skins.", "pskin on");
	}
}

function remoteSelectClient(%clientId, %selId)
{
	if(%clientId.selClient != %selId)
	{
		%clientId.selClient = %selId;
		if(%clientId.menuMode == "options")
			Game::menuRequest(%clientId);
		if(Insomniax_getVictim(%selId) == %selId)
			%selLastTK = "None Here";
		else 
			%selLastTK = Client::getName(Insomniax_getVictim(%selId));
		if(Insomniax_getKiller(%selId) == %selId)
			%selTKdBy = "None Here";
		else
			%selTKdBy = Client::getName(Insomniax_getKiller(%selId));
		%selKills = $tkKills[%selId];
		remoteEval(%clientId, "setInfoLine", 1, "Team Kill Info for " @ Client::getName(%selId) @ ":");
		remoteEval(%clientId, "setInfoLine", 2, "Last TK Victim: " @ %selLastTK);
		remoteEval(%clientId, "setInfoLine", 3, "Last TK'd By: " @ %selTKdBy);
		remoteEval(%clientId, "setInfoLine", 4, "Number of TKs: " @ %selKills);
		remoteEval(%clientId, "setInfoLine", 5, "Server: " @ Insomniax_ServerLvlTxt());
		if(%clientId.isSuperAdmin) 
			remoteEval(%clientId, "setInfoLine", 6, "Client: " @ Client::getTransportAddress(%selId));
		else
			remoteEval(%clientId, "setInfoLine", 6, "Client: " @ Insomniax_ClientLvlTxt());
	}
}

function processMenuFPickTeam(%clientId, %team)
{
   if(IxPort::PA(%clientId, $Insomniax::PATeamChange))
      processMenuPickTeam(%clientId.ptc, %team, %clientId);
   %clientId.ptc = "";
}

// Added "Fair Teams" code here - *IX*Savage1
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
            		messageAll(0, Client::getName(%clientId) @ " became an observer.");
        		else
            		messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
			Game::resetScores(%clientId);	
		   	Game::refreshClientScore(%clientId);
		}
      	return;
   	}
	%change = false;
	if(!$Insomniax::fairTeams) 
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
			if(Insomniax_isFairTeam(%teamnow, %team)) 
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
			      	messageAll(0, Client::getName(%clientId) @ " tried to make the teams even more unfair.");
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

// Alazane:BEGIN
function ProcessMenuFunAdmin(%clientId, %option)
{
  if (!%clientId.isSuperAdmin) return; // PORT: menu codes come from the client
  if (%option == 0)
  {
    %player = Client::getOwnedObject(%clientId);
    %item = Player::getMountedItem(%clientid, $BackpackSlot);
    if (%item != -1) Player::decItemCount(%clientid, %item);
    Player::incItemCount(%clientid, PackOMen);
    Player::useItem(%clientid, PackOMen);
  }
  else if (%option == 1)
  {
    bottomPrintAll("FRAGFEST!", 10);
    
    // Teleport all players to a central location
    for (%i=Client::GetFirst(); %i != -1; %i = Client::getNext(%i))
      Gamebase::SetPosition(%i,getrandom()*5 @ " " @ getrandom()*5 @ " " @ getrandom()*5+500);
  }
//--Just keeping these around as examples
//  else if (%option == 2)
//  {
//    Player::setItemCount(%clientid, TractorDevice, 1);
//  }
//  else if (%option == 3)
//  {
//    %player = Client::getOwnedObject(%clientId);
//    %item = Player::getMountedItem(%clientid, $BackpackSlot);
//    if (%item != -1) Player::decItemCount(%clientid, %item);
//    Player::setItemCount(%clientId, PhotonPack, 1);
//    Player::useItem(%clientid, PhotonPack); 
//  }
//  else if (%option == 4)
//  {
//    %player = Client::getOwnedObject(%clientId);
//    %item = Player::getMountedItem(%clientid, $BackpackSlot);
//    if (%item != -1) Player::decItemCount(%clientid, %item);
//    Player::setItemCount(%clientId, TrackerMissileAmmo, 500);
//    Player::setItemCount(%clientId, TrackerMissilePack, 1);
//    Player::useItem(%clientid, TrackerMissilePack); 
//  }
}
//Alazane:END

function processMenuOptions(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	
	if(%opt == "fteamchange" && IxPort::PA(%clientId, $Insomniax::PATeamChange))
	{
      	%clientId.ptc = %cl;
	      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
      	Client::addMenuItem(%clientId, "0Observer", -2);
	      Client::addMenuItem(%clientId, "1Automatic", -1);
      	for(%i = 0; %i < getNumTeams(); %i = %i + 1)
	      	Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      	return;
	}      
	//Alazane:BEGIN
	else if (%opt == "funadmin" && %clientId.isSuperAdmin)
	{
		Client::buildMenu(%clientId, "Pick an option:", "FunAdmin", true);
		Client::addMenuItem(%clientId, "0Pack o' Men", 0);
		Client::addMenuItem(%clientId, "1Fragfest!", 1);
		return;
	}
	//Alazane:END
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
	else if(%opt == "vkick" && $Insomniax::PVKick)
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
	}
	else if(%opt == "vadmin" && $Insomniax::PAVote)
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
	}
	else if(%opt == "vsmatch" && $Insomniax::PVTourneyMode)
		Admin::startVote(%clientId, "start the match", "smatch", 0);
	else if(%opt == "vetd" && $Insomniax::PVTeamDamage)
		Admin::startVote(%clientId, "enable team damage", "etd", 0);
	else if(%opt == "vdtd" && $Insomniax::PVTeamDamage)
		Admin::startVote(%clientId, "disable team damage", "dtd", 0);
	else if(%opt == "etd" && IxPort::PA(%clientId, $Insomniax::PATeamDamage))
		Admin::setTeamDamageEnable(%clientId, true);
	else if(%opt == "dtd" && IxPort::PA(%clientId, $Insomniax::PATeamDamage))
		Admin::setTeamDamageEnable(%clientId, false);
	else if(%opt == "vcffa" && $Insomniax::PVTourneyMode)
		Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
	else if(%opt == "vctourney" && $Insomniax::PVTourneyMode)
		Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
	else if(%opt == "cffa" && IxPort::PA(%clientId, $Insomniax::PATourneyMode))
		Admin::setModeFFA(%clientId);
	else if(%opt == "ctourney" && IxPort::PA(%clientId, $Insomniax::PATourneyMode))
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
	else if(%opt == "admin" && %clientId.isSuperAdmin)
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
	else if(%opt == "gag" && IxPort::PA(%clientId, $Insomniax::PAGag))
	{
		%cl.gagged = true;
		ixAdminMsg(Client::getName(%clientId) @ " has Gagged " @ Client::getName(%cl));	
		Client::sendMessage(%cl,0,"IX-Server: You have been Gagged by the Server Admin.");
	}
	else if(%opt == "ungag" && IxPort::PA(%clientId, $Insomniax::PAGag))
	{
		%cl.gagged = false;
		ixAdminMsg(Client::getName(%clientId) @ " has Ungagged " @ Client::getName(%cl));	
		Client::sendMessage(%cl,0,"IX-Server: Your Gag has been removed by the Admin.");
	}
	else if(%opt == "smatch" && IxPort::PA(%clientId, $Insomniax::PATourneyMode))
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
	else if(%opt == "disableFT" && IxPort::PA(%clientId, $Insomniax::PAFairTeams))
	{
		ixAdminMsg("Command: " @ Client::getName(%clientId) @ " - Fair Teams Checking is DISABLED.");
		$Insomniax::fairteams = "false";
	}
	else if(%opt == "enableFT" && IxPort::PA(%clientId, $Insomniax::PAFairTeams))
	{
		ixAdminMsg("Command: " @ Client::getName(%clientId) @ " - Fair Teams Checking is ENABLED.");
		$Insomniax::fairteams = "true";
	}
	else if(%opt == "vdisableFT" && $Insomniax::PVFairTeams)
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "Disable Fair Teams", "dfteams", %cl);
	}
	else if(%opt == "venableFT" && $Insomniax::PVFairTeams)
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "Enable Fair Teams", "efteams", %cl);
	}
	else if(%opt == "insomniax" && IxPort::PA(%clientId, $Insomniax::PAModOptions))
	{
		%now = 0;
		Client::buildMenu(%clientId, "IX-Admin Settings:", "ixsettings", true);
		Client::addMenuItem(%clientId, %now++ @ "Server: Anti-TK Lvl", "tkserv " @ $Insomniax::tkServerLvl);
		Client::addMenuItem(%clientId, %now++ @ "Client: Anti-TK Lvl", "tkclient " @ $Insomniax::tkClientLvl);
		Client::addMenuItem(%clientId, %now++ @ "Out of Bounds Kill", "areakill " @ $Insomniax::LeaveAreaTime);
		if($Insomniax::PSkin) 
			Client::addMenuItem(%clientId, %now++ @ "Disable Personal Skins", "disablepskin " @ %clientId);
		else 
			Client::addMenuItem(%clientId, %now++ @ "Enable Personal Skin", "enablepskin " @ %clientId);
		if($Insomniax::SafeStation) 
			Client::addMenuItem(%clientId, %now++ @ "Disable Safe Stations", "dsafestation " @ %clientId);
		else 
			Client::addMenuItem(%clientId, %now++ @ "Enable Safe Stations", "esafestation " @ %clientId);
		if(%clientId.isSuperAdmin)
			Client::addMenuItem(%clientId, %now++ @ "Set Inv. Station Time", "stationtime " @ $Insomniax::StationTime);
		if(%clientId.isSuperAdmin)
			Client::addMenuItem(%clientId, %now++ @ "Admin Controls.", "admincontrols");
		return;
	}
	else 	if(%opt == "pskin")
	{
      	if(%cl == "on") 
		{
			%clientId.custom = true;
			bottomprint(%clientId,"<jc><f2>Custom Skins Enabled.\n<f1>Changes Take Place on Next Respawn", 5); 
		}
		else
		{
			%clientId.custom = false;
			bottomprint(%clientId,"<jc><f2>Custom Skins Disabled.\n<f1>Changes Take Place on Next Respawn", 5); 
		}
	}
	else if(%opt == "tkopt" && !%clientId.isAdmin && $Insomniax::tkLimit > 0 && Insomniax_getKiller(%clientId) != %clientId && $tkKills[Insomniax_getKiller(%clientId)] >= $Insomniax::tkLimit)
	{
		%cl = Insomniax_getKiller(%clientId); // PORT: the recorded killer, not a client-sent id
		if($Insomniax::tkClientLvl == 1)
		{
			Admin::Kick(-3, Insomniax_getKiller(%clientId));
			return;
		}
		else
      	{
      		%cl.voteTarget = true;
	        	%clientId.selClient = Insomniax_getKiller(%clientId);
      	  	Admin::startVote(%clientId, "Kick Team Killer " @ Client::getName(%cl), "tkkick", %cl);
      		return;
		}
	}
	else if(%opt == "publicVoteOptions") 
	{
		%curItem = 0;
     		Client::buildMenu(%clientId, "Voting Options:", "Options", true);
		if($insomniax::PVMission) 
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
		if($insomniax::PVTeamDamage)
		{
			if($Server::TeamDamageScale == 1.0)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
			else
     				Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
		}
		if($insomniax::PVFairTeams)
		{
			if($insomniax::FairTeams) 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to Disable Fair Teams", "vdisableFT " @ %clientId);
			else 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to Enable Fair Teams", "venableFT " @ %clientId);
		}
		if($insomniax::PVTourneyMode)
			if($Server::TourneyMode)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
				if(!$CountdownStarted && !$matchStarted)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
			}
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
		return;
	}
	else if(%opt == "publicAdminOptions" && %clientId.isAdmin) 
	{
		%curItem = 0;
     		Client::buildMenu(%clientId, "Public Admin Options:", "Options", true);
		if($insomniax::PAMission && %clientId.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
		}
		else 
		{
			if($insomniax::PVMission) 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
		}
		if($insomniax::PATeamDamage && %clientId.isAdmin)
		{
			if($Server::TeamDamageScale == 1.0)
				Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
		}
		else 
		{
			if($insomniax::PVTeamDamage)
			{
				if($Server::TeamDamageScale == 1.0)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
				else
      				Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
			}
		}
		if($insomniax::PAFairTeams && %clientId.isAdmin)
		{
			if($Insomniax::FairTeams) 
				Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "disableFT " @ %clientId);
			else 
				Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "enableFT " @ %clientId);
		}
		else 
		{
			if($insomniax::PVFairTeams)
			{
				if($insomniax::FairTeams) 
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to Disable Fair Teams", "vdisableFT " @ %clientId);
				else 
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to Enable Fair Teams", "venableFT " @ %clientId);
			}
		}
		if($insomniax::PATourneyMode && %clientId.isAdmin)
		{
		      if($Server::TourneyMode)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
				if(!$CountdownStarted && !$matchStarted)
					Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
			}
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
		}
		else 
		{
			if($insomniax::PVTourneyMode)
				if($Server::TourneyMode)
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
					if(!$CountdownStarted && !$matchStarted)
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
				}
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
		}
		if($insomniax::PATimeLimit && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
		if($insomniax::PAResetDefaults && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
		return;
	}
	else if(%opt == "superAdminOptions" && %clientId.isSuperAdmin) 
	{
		%curItem = 0;
     		Client::buildMenu(%clientId, "Super Admin Options:", "Options", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
	      if($Server::TeamDamageScale == 1.0)
			Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
		if($Insomniax::FairTeams) 
			Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "disableFT " @ %clientId);
		else 
			Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "enableFT " @ %clientId);
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
		//Alazane:BEGIN
		Client::addMenuItem(%clientId, %curItem++ @ "Fun Stuff", "funadmin");
		//Alazane:END
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuKAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes" && IxPort::PA(%clientId, $Insomniax::PAKick))
      Admin::kick(%clientId, getWord(%opt, 1));
   Game::menuRequest(%clientId);
}

function processMenuBAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes" && IxPort::PA(%clientId, $Insomniax::PABan))
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
   if(%opt == "yes" && IxPort::PA(%clientId, $Insomniax::PAResetDefaults))
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

//-------------------------------------------------------------------
// Various Menus and Data Processing - *IX*Savage1
//-------------------------------------------------------------------

function processMenuIXSettings(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(!IxPort::PA(%clientId, $Insomniax::PAModOptions)) return; // PORT: menu codes come from the client
	if(!%clientId.isSuperAdmin && (%opt == "admincontrols" || %opt == "disablepav" || %opt == "enablepav" || %opt == "palockout" || %opt == "pvlockout" || %opt == "purge" || %opt == "stationtime")) return; // PORT: the menu lists these for a super admin only

	if(%opt == "admincontrols")
	{
	      Client::buildMenu(%clientId, "Admin Controls:", "ixsettings", true);
		if($Insomniax::PAVote) 
			Client::addMenuItem(%clientId, "1Disable Admin Voting", "disablepav");
		else 
			Client::addMenuItem(%clientId, "1Enable Admin Voting", "enablepav");
		Client::addMenuItem(%clientId, "2Admin Lockouts", "palockout");
		Client::addMenuItem(%clientId, "3Voting Lockouts", "pvlockout");
		Client::addMenuItem(%clientId, "4Purge Public Admins", "purge " @ %clientId);
		return;
	}
	else if(%opt == "disablepav")
	{
		ixAdminMsg("Admin Voting is DISABLED by " @ Client::getName(%clientId));
		$Insomniax::PAVote = "false";
	}
	else if(%opt == "enablepav")
	{
		ixAdminMsg("Admin Voting is ENABLED by " @ Client::getName(%clientId));
		$Insomniax::PAVote = "true";
	}
	else if(%opt == "tkserv")
	{
      	Client::buildMenu(%clientId, "Current Server Anti-TK: " @ %cl, "ServerLvl", true);
	      Client::addMenuItem(%clientId, "0Log TK's only", 0);
	      Client::addMenuItem(%clientId, "1Auto Vote TKer", 1);
	      Client::addMenuItem(%clientId, "2Auto Vote Until Kicked", 2);
	      Client::addMenuItem(%clientId, "3Auto Kick TKer", 3);
	      return;
	}
	else if(%opt == "tkclient")
	{
      	Client::buildMenu(%clientId, "Current Client Anti-TK: " @ %cl, "ClientLvl", true);
	      Client::addMenuItem(%clientId, "0Client Vote Option", 0);
      	Client::addMenuItem(%clientId, "1Client Kick Option", 1);
	      return;
	}
   	else if(%opt == "areakill")
	{
	      Client::buildMenu(%clientId, "Out of Bounds Kill Time: " @ %cl @ " Seconds", "AKill", true);
	      Client::addMenuItem(%clientId, "0Set to Off", 0);
	      Client::addMenuItem(%clientId, "1Set to 10 Seconds", 10);
	      Client::addMenuItem(%clientId, "2Set to 15 Seconds", 15);
	      Client::addMenuItem(%clientId, "3Set to 20 Seconds", 20);
	      Client::addMenuItem(%clientId, "4Set to 25 Seconds", 25);
	      Client::addMenuItem(%clientId, "5Set to 30 Seconds", 30);
	      Client::addMenuItem(%clientId, "6Set to 40 Seconds", 40);
	      Client::addMenuItem(%clientId, "7Set to 60 Seconds", 60);
      	return;
	}
	else if(%opt == "palockout")
	{
	      Client::buildMenu(%clientId, "Current Status:","PALockouts", true);
      	Client::addMenuItem(%clientId, "1[" @ whattodo($Insomniax::PATeamChange) @ "]Team Changing", "teamchange " @ $Insomniax::PATeamChange);
	      Client::addMenuItem(%clientId, "2[" @ whattodo($Insomniax::PAKick) @ "]Kick", "kick " @ $Insomniax::PAKick);
      	Client::addMenuItem(%clientId, "3[" @ whattodo($Insomniax::PABan) @ "]Ban","ban " @ $Insomniax::PABan);
	      Client::addMenuItem(%clientId, "4[" @ whattodo($Insomniax::PAMission) @ "]Change Mission", "mission " @ $Insomniax::PAMission);
      	Client::addMenuItem(%clientId, "5[" @ whattodo($Insomniax::PATeamDamage) @ "]Team Damage", "teamdamage " @ $Insomniax::PATeamDamage);
	      Client::addMenuItem(%clientId, "6[" @ whattodo($Insomniax::PATourneyMode) @ "]Tourney/FFA Mode", "tourney " @ $Insomniax::PATourneyMode);
	      Client::addMenuItem(%clientId, "7[" @ whattodo($Insomniax::PATimeLimit) @ "]Time Limit", "timelimit " @ $Insomniax::PATimeLimit);
	      Client::addMenuItem(%clientId, "8Additional Lockouts ...", "additional");
      	return;
	}
	else if(%opt == "pvlockout")
	{
      	Client::buildMenu(%clientId, "Current Status:","PVLockouts", true);
		Client::addMenuItem(%clientId, "1[" @ whattodo($Insomniax::PVKick) @ "]Kick", "kick " @ $Insomniax::PVKick);
	      Client::addMenuItem(%clientId, "2[" @ whattodo($Insomniax::PVMission) @ "]Change Mission", "mission " @ $Insomniax::PVMission);
	      Client::addMenuItem(%clientId, "3[" @ whattodo($Insomniax::PVFairTeams) @ "]Fair Teams", "fteams " @ $Insomniax::PVFairTeams);
	      Client::addMenuItem(%clientId, "4[" @ whattodo($Insomniax::PVTeamDamage) @ "]Team Damage", "teamdamage " @ $Insomniax::PVTeamDamage);
	      Client::addMenuItem(%clientId, "5[" @ whattodo($Insomniax::PVTourneyMode) @ "]Tourney/FFA Mode", "tourney " @ $Insomniax::PVTourneyMode);
		Client::addMenuItem(%clientId, "6[Unlock]ALL Options", "allon");
		Client::addMenuItem(%clientId, "7[-Lock-]ALL Options", "alloff");
      	return;
	}
	else if(%opt == "purge")
	{
		Insomniax_clearPA(%cl);
      	return;
	}
	else if(%opt == "disablepskin") ixAllSkinsOff();
	else if(%opt == "enablepskin") ixAllSkinsOn();
   	else if(%opt == "stationtime")
	{
	      Client::buildMenu(%clientId, "Inventoy Station Time: " @ %cl @ " Seconds", "StationTime", true);
	      Client::addMenuItem(%clientId, "0Set to Off", 0);
	      Client::addMenuItem(%clientId, "1Set to 10 Seconds", 10);
	      Client::addMenuItem(%clientId, "2Set to 15 Seconds", 15);
	      Client::addMenuItem(%clientId, "3Set to 20 Seconds", 20);
	      Client::addMenuItem(%clientId, "4Set to 25 Seconds", 25);
	      Client::addMenuItem(%clientId, "5Set to 30 Seconds", 30);
	      Client::addMenuItem(%clientId, "6Set to 40 Seconds", 40);
	      Client::addMenuItem(%clientId, "7Set to 60 Seconds", 60);
      	return;
	}
	else if(%opt == "dsafestation")
	{
		ixAdminMsg("Safe Stations DISABLED by " @ Client::getName(%clientId));
		$Insomniax::SafeStation = "false";
	}
	else if(%opt == "esafestation")
	{
		ixAdminMsg("Safe Stations ENABLED by " @ Client::getName(%clientId));
		$Insomniax::SafeStation = "true";
	}
	processMenuOptions(%clientId, "insomniax");
}

function processMenuPALockouts(%clientId, %option) 
{
	%opt = getWord(%option, 0);
	%toggle = getWord(%option, 1);
	if(!%clientId.isSuperAdmin) return; // PORT
	if(%opt == "additional")
   	{
		Client::buildMenu(%clientId, "Current Status:","PALockouts", true);
		Client::addMenuItem(%clientId, "1[" @ whattodo($Insomniax::PAResetDefaults) @ "]Server Defaults ", "reset " @ $Insomniax::PAResetDefaults);
	      Client::addMenuItem(%clientId, "2[" @ whattodo($Insomniax::PAModOptions) @ "]IX-Admin Options", "modopt " @ $Insomniax::PAModOptions);
	      Client::addMenuItem(%clientId, "3[" @ whattodo($Insomniax::PATeamInfo) @ "]Set Team Info", "teaminfo " @ $Insomniax::PATeamInfo);
		Client::addMenuItem(%clientId, "4[" @ whattodo($Insomniax::PAFairTeams) @ "] Fair Teams", "fteams " @ $Insomniax::PAFairTeams);
		Client::addMenuItem(%clientId, "5[" @ whattodo($Insomniax::PAGag) @ "] Gag Players", "gag " @ $Insomniax::PAGag);
	      Client::addMenuItem(%clientId, "6[Unlock]ALL Options", "allon");
	      Client::addMenuItem(%clientId, "7[-Lock-]ALL Options", "alloff");
		return;
   	}
	else if(%opt == "allon") 
	{
		%access = "All Admin Options";
		%toggle = "false";
		$Insomniax::PATeamChange = "true";
		$Insomniax::PAKick = "true";
		$Insomniax::PABan = "true";
		$Insomniax::PAGag = "true";
		$Insomniax::PAMission = "true";
		$Insomniax::PATeamInfo = "true";
		$Insomniax::PAFairTeams = "true";
		$Insomniax::PATeamDamage = "true";
		$Insomniax::PATourneyMode = "true";
		$Insomniax::PATimeLimit = "true";
		$Insomniax::PAResetDefaults = "true";
		$Insomniax::PAModOptions = "true";
	}
	else if(%opt == "alloff") 
	{
		%access = "All Admin Options";
		%toggle = "true";
		$Insomniax::PATeamChange = "false";
		$Insomniax::PAKick = "flase";
		$Insomniax::PABan = "flase";
		$Insomniax::PAGag = "false";
		$Insomniax::PAMission = "flase";
		$Insomniax::PATeamInfo = "flase";
		$Insomniax::PAFairTeams = "flase";
		$Insomniax::PATeamDamage = "flase";
		$Insomniax::PATourneyMode = "flase";
		$Insomniax::PATimeLimit = "flase";
		$Insomniax::PAResetDefaults = "flase";
		$Insomniax::PAModOptions = "flase";
	}
	else if(%opt == "teamchange") 
	{
		%access = "Admin: Team Change";
		if(%toggle) $Insomniax::PATeamChange = "false";
		else $Insomniax::PATeamChange = "true";
	}
	else if(%opt == "kick") 
	{
		%access = "Admin: Kick";
		if(%toggle) $Insomniax::PAKick = "false";
		else $Insomniax::PAKick = "true";
	}
	else if(%opt == "ban") 
	{
		%access = "Admin: Ban";
		if(%toggle) $Insomniax::PABan = "false";
		else $Insomniax::PABan = "true";
	}
	else if(%opt == "ban") 
	{
		%access = "Admin: Gag";
		if(%toggle) $Insomniax::PAGag = "false";
		else $Insomniax::PAGag = "true";
	}
	else if(%opt == "mission") 
	{
		%access = "Admin: Change Mission";
		if(%toggle) $Insomniax::PAMission = "false";
		else $Insomniax::PAMission = "true";
	}
	else if(%opt == "teamdamage") 
	{
		%access = "Admin: Enable/Disable Team Damage";
		if(%toggle) $Insomniax::PATeamDamage = "false";
		else $Insomniax::PATeamDamage = "true";
	}
	else if(%opt == "tourney") 
	{
		%access = "Admin: Toggle Tourney/FFA Mode";
		if(%toggle) $Insomniax::PATourneyMode = "false";
		else $Insomniax::PATourneyMode = "true";
	}
	else if(%opt == "timelimit") 
	{
		%access = "Admin: Change Time Limit";
		if(%toggle) $Insomniax::PATimeLimit = "false";
		else $Insomniax::PATimeLimit = "true";
	}
	else if(%opt == "reset") 
	{
		%access = "Admin: Reset Sever";
		if(%toggle) $Insomniax::PAResetDefaults = "false";
		else $Insomniax::PAResetDefaults = "true";
	}
	else if(%opt == "modopt") 
	{
		%access = "Admin: IX-Admin Options";
		if(%toggle) $Insomniax::PAModOptions = "false";
		else $Insomniax::PAModOptions = "true";
	}
	else if(%opt == "teaminfo") 
	{
		%access = "Admin: Set Team Info";
		if(%toggle) $Insomniax::PATeamInfo = "false";
		else $Insomniax::PATeamInfo = "true";
	}
	else if(%opt == "fteams") 
	{
		%access = "Admin: Enable/Disable Fair Teams";
		if(%toggle) $Insomniax::PAFairTeams = "false";
		else $Insomniax::PAFairTeams = "true";
	}
	if(%toggle) %toggle = "false";
	else %toggle = "true";
	ixAdminMsg(Client::getName(%clientId) @ " [" @ islocked(%toggle) @ "] " @ %access);
	processMenuIXSettings(%clientId,"palockout");
}

function processMenuPVLockouts(%clientId, %option) 
{
	%opt = getWord(%option, 0);
	%toggle = getWord(%option, 1);
	if(!%clientId.isSuperAdmin) return; // PORT
	if(%opt == "kick") 
	{
		%access = "Vote to Kick";
		if(%toggle) $Insomniax::PVKick = "false";
		else $Insomniax::PVKick = "true";
	}
	else if(%opt == "mission") 
	{
		%access = "Vote to Change Mission";
		if(%toggle) $Insomniax::PVMission = "false";
		else $Insomniax::PVMission = "true";
	}
	else if(%opt == "teamdamage") 
	{
		%access = "Vote to Enable/Disable Team Damage";
		if(%toggle) $Insomniax::PVTeamDamage = "false";
		else $Insomniax::PVTeamDamage = "true";
	}
	else if(%opt == "tourney") 
	{
		%access = "Vote to Change to Tourney/FFA Mode";
		if(%toggle) $Insomniax::PVTourneyMode = "false";
		else $Insomniax::PVTourneyMode = "true";
	}
	else if(%opt == "fteams") 
	{
		%access = "Vote to Enable/Disable Fair Teams";
		if(%toggle) $Insomniax::PVFairTeams = "false";
		else $Insomniax::PVFairTeams = "true";
	}
	else if(%opt == "allon") 
	{
		%access = "All Vote Options";
		%toggle = "false";
		$Insomniax::PVKick = "true";
		$Insomniax::PVMission = "true";
		$Insomniax::PVFairTeams = "true";
		$Insomniax::PVTeamDamage = "true";
		$Insomniax::PVTourneyMode = "true";
	}
	else if(%opt == "alloff") 
	{
		%access = "All Vote Options";
		%toggle = "true";
		$Insomniax::PVKick = "false";
		$Insomniax::PVMission = "false";
		$Insomniax::PVFairTeams = "false";
		$Insomniax::PVTeamDamage = "false";
		$Insomniax::PVTourneyMode = "false";
	}
	if(%toggle) %toggle = "false";
	else %toggle = "true";
	ixAdminMsg(Client::getName(%clientId) @ " [" @ islocked(%toggle) @ "] " @ %access);
	processMenuIXSettings(%clientId,"pvlockout");
}

function islocked(%toggle)
{
	if(%toggle) return "Unlocked";
	else return "-Locked-";
}

function whattodo(%toggle)
{
	if(%toggle) return "-Lock-";
	else return "Unlock";
}

function processMenuServerLvl(%clientId, %option) 
{
   if(!IxPort::PA(%clientId, $Insomniax::PAModOptions)) return; // PORT
   $Insomniax::tkServerLvl = %option;
   if(%option == 0)
     messageAll(0, "IX-Server:TK Protection Level Set to Zero. (Logging TK's only).");
   if(%option == 1)
     messageAll(0, "IX-Server:TK Protection Level Set to One. (Auto Vote).");
   if(%option == 2)
     messageAll(0, "IX-Server:TK Protection Level Set to Two. (Auto Vote Until Kicked).");
   if(%option == 3)
     messageAll(0, "IX-Server:TK Protection Level Set to Three. (Auto Kick).");
}

function processMenuClientLvl(%clientId, %option) 
{
   if(!IxPort::PA(%clientId, $Insomniax::PAModOptions)) return; // PORT
   $Insomniax::tkClientLvl = %option;
   if(%option == 0)
     messageAll(0, "IX-Server: Client TK Vote Option Engaged. (From Options Menu).");
   if(%option == 1)
     messageAll(0, "IX-Server: Client TK Kick Option Engaged. (From Options Menu).");
}

function processMenuAKill(%clientId, %option) 
{
   if(!IxPort::PA(%clientId, $Insomniax::PAModOptions)) return; // PORT
   $Insomniax::LeaveAreaTime = %option;
   if(%option == 0)
     messageAll(0, "IX-Server: Leaving Mission Area Now Does not Kill you.");
   else
     messageAll(0, "IX-Server: Leaving Mission Area Now Kills you in " @ %option @ " Seconds.");

}

function processMenuStationTime(%clientId, %option) 
{
	if(!%clientId.isSuperAdmin) return; // PORT
	$Insomniax::StationTime = %option;
	if(%option == 0)
		messageAll(0, "IX-Server: Inventory Station Time is no Longer Limited.");
	else
		messageAll(0, "IX-Server: Inventory Station Time is now Limtied to " @ %option @ " Seconds.");
}

function Insomniax_ServerLvlTxt()
{
    if($Insomniax::tkServerLvl == 0)
    	%tkText = "Only Logging TK's"; 
    else if($Insomniax::tkServerLvl == 1)
	%tkText = "Votes at " @ $Insomniax::tkLimit @ " TK's";
    else if($Insomniax::tkServerLvl == 2)
	%tkText = "Votes at " @ $Insomniax::tkLimit @ " TKs and Kicks at " @ $Insomniax::tkLimit * $Insomniax::tkMultiple @ " TK's";
    else if($Insomniax::tkServerLvl == 3)
	%tkText = "Kicks at " @ $Insomniax::tkLimit @ " TK's";
    else %tkText = "ERROR: Server Level set to Unkown Level";
    return %tkText;
}

function Insomniax_ClientLvlTxt()
{
    if($Insomniax::tkClientLvl == 0)
    	%tkText = "Vote Option at " @ $Insomniax::tkLimit @ " TK's"; 
    else if($Insomniax::tkClientLvl == 1)
	%tkText = "Kick Option at " @ $Insomniax::tkLimit @ "TK's";
    else %tkText = "ERROR: Client Level set to Unkown Level";
    return %tkText;
}

// Insomnaix Mod TK Handling - *IX*Savage1
function Insomniax_setTeamKill(%victimId, %killerId) 
{
  $tkVictim[%killerId] = %victimId;
	$tkKiller[%victimId] = %killerId;
	$tkKills[%killerId] += 1;
	echo("IX-Admin: TK Recorded. victimId: ",%victimId," killerId: ",%killerId," Killer now has ",$tkKills[%killerId]," TKs");
	%trigger = $tkKills[%killerId] % $Insomniax::tkLimit;
	%tkTopKills = $Insomniax::tkLimit * $Insomniax::tkMultiple;
	if(($tkKills[%killerId] >= $Insomniax::tkLimit) && (!%trigger)) 
	  {
	  if($Insomniax::tkServerLvl) 
	    {
	    if($Insomniax::tkServerLvl != 3)
	      {
		if(($tkKills[%killerId] >= %tkTopKills) && ($Insomniax::tkServerLvl != 1))
		{
		messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing. Confirmed " @ $tkKills[%killerId] @ " Team Kills.");
		Admin::Kick(-2, %killerId);
		return;
		}
		%killerId.voteTarget = true;
     		%victimId.selClient = Insomniax_getKiller(%victimId);
		Admin::startVote(%victimId, "Kick Team Killer " @ Client::getName(%killerId), "tkkick", %killerId);
	      }
	    else
	      {
		messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing. Confirmed " @ $tkKills[%killerId] @ " Team Kills.");
		Admin::Kick(-2, %killerId);
	      }		
	    }
	  }
	return;
}

function Insomniax_clearPA(%admin) 
{
	if(%admin.isSuperAdmin)
	{
		%name = Client::getName(%admin);
		ixAdminMsg("Command: " @ %name @ " Purge All Public Admins.");
	      %numPlayers = getNumClients();
      	for(%i = 0; %i < %numPlayers; %i++)
	      {
			%pl = getClientByIndex(%i);
			if(!%pl.isSuperAdmin && %pl.isAdmin)
			{
				%pl.isAdmin = false;
				Client::sendMessage(%pl,1,"Your Admin Status has been revoked by the Super Admin.");
				ixAdminMsg("Stripped Admin Status from " @ Client::getName(%pl));
			}
		}
		ixAdminMsg("Purge Complete.");
	}
}

function Insomniax_getKiller(%clientId) 
{
  return $tkKiller[%clientId];
}

function Insomniax_getVictim(%clientId) 
{
  return $tkVictim[%clientId];
}

function ixInitPlayer(%clientId)
{
	if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId))
	  $tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId];
	if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId))
	  $tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId];
      $tkKiller[%clientId] = %clientId;
	$tkVictim[%clientId] = %clientId;
	$tkKills[%clientId] = 0;
	$empTime[%clientId] = 0;
	$ixMyHeat[%clientId] = 0;
	$ixMyCool[%clientId] = "false";
	$ixLockTime[%clientId] = 0;
	$ixLockedTarget[%clientId] = false;
	return;
}

function Insomniax_leaveGame(%clientId) 
{
	ixInitPlayer(%clientId);
}

function Insomniax_joinGame(%clientId) 
{
	ixInitPlayer(%clientId);
// Vengeance
	$ixVPayload[%clientId] = "5"; // 1 - 5 Warheads
	$ixVScanner[%clientId] = "Long"; // short, medium, long. Scan Ranges.
	$ixVWarhead[%clientId,1] = "Medium";
	$ixVWarhead[%clientId,2] = "Medium";
	$ixVWarhead[%clientId,3] = "Medium";
	$ixVWarhead[%clientId,4] = "Medium";
	$ixVWarhead[%clientId,5] = "Medium";
}

function Insomniax_loadMission() 
{
	echo("IX-Admin: Player's Team Killer Counts Reset to Zero.");
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
      {
		%pl = getClientByIndex(%i);
		$tkKills[%pl] = 0;
	}
}

function ixAllSkinsOff() {
	echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
	$Insomniax::PSkin = "false";
	bottomprintall("<jc><f2>Custom Skins Disabled by Server Admin.\n<f1>Changes Take Place on Next Respawn.", 5);  
	%numPlayers = getNumClients();
   	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		if(%pl.custom) %pl.custom = false;
	}
	echo("IX-Admin: Personal Skin Option Disabled.");
	echo("IX-Admin: All Skins Reset to Server Choice.");
	echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
}

function ixAllSkinsOn() {
	echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
	$Insomniax::PSkin = "true";
	bottomprintall("<jc><f2>Custom Skins Enabled by Server Admin.\n<f1>Option added to Menu.", 5); 
	echo("IX-Admin: Personal Skin Option Enabled.");
	echo("IX-Admin: Players Must Choose Option from Menu.");
	echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
}

function ixwhoison()
{
echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
	echo("IX-Admin: # cl: CLIENT nm: NAME    ip: ADDRESS");
	%numPlayers = getNumClients();
	%j=0;
      for(%i = 0; %i < %numPlayers; %i++)
      {
		%pl = getClientByIndex(%i);
		echo("IX-Admin: ",%i," cl: ",%pl," nm: ",Client::getName(%pl),"    ip: ",Client::getTransportAddress(%pl));
		}
echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
}

function ixLockouts()
{
echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
echo("IX-Admin: Public Admin Lockout Status.");
echo("IX-Admin: [",islocked($Insomniax::PATeamChange),"] Team Change");
echo("IX-Admin: [",islocked($Insomniax::PAKick),"] Kick");
echo("IX-Admin: [",islocked($Insomniax::PABan),"] Ban");
echo("IX-Admin: [",islocked($Insomniax::PAGag),"] Gag");
echo("IX-Admin: [",islocked($Insomniax::PAMission),"] Change Mission");
echo("IX-Admin: [",islocked($Insomniax::PATeamInfo),"] Team Info");
echo("IX-Admin: [",islocked($Insomniax::PATeamDamage),"] Team Damage");
echo("IX-Admin: [",islocked($Insomniax::PAFairTeams),"] Fair Teams");
echo("IX-Admin: [",islocked($Insomniax::PATourneyMode),"] Tourney Mode");
echo("IX-Admin: [",islocked($Insomniax::PATimeLimit),"] Time Limit");
echo("IX-Admin: [",islocked($Insomniax::PAResetDefaults),"] Reset Server Defaults");
echo("IX-Admin: [",islocked($Insomniax::PAModOptions),"] Mod Options");
echo("IX-Admin: [",islocked($Insomniax::PAVote),"] Admin Voting");
echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
echo("IX-Admin: Public Voting Lockout Status.");
echo("IX-Admin: [",islocked($Insomniax::PVKick),"] Kick");
echo("IX-Admin: [",islocked($Insomniax::PVMission),"] Change Mission");
echo("IX-Admin: [",islocked($Insomniax::PVFairTeams),"] Fair Teams");
echo("IX-Admin: [",islocked($Insomniax::PVTeamDamage),"] Team Damage");
echo("IX-Admin: [",islocked($Insomniax::PVTourneyMode),"] Tourney Mode");
echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
}

function ixtoggle(%lockout)
{
 if(%lockout != "") {
  if(%lockout == "PATeamChange") 
	{
		%access = "Admin: Team Change";
		if($Insomniax::PATeamChange) $Insomniax::PATeamChange = "false";
		else $Insomniax::PATeamChange = "true";
		%toggle = $Insomniax::PATeamChange;
	}
	else if(%lockout == "PAKick") 
	{
		%access = "Admin: Kick";
		if($Insomniax::PAKick) $Insomniax::PAKick = "false";
		else $Insomniax::PAKick = "true";
		%toggle = $Insomniax::PAKick;
	}
	else if(%lockout == "PABan") 
	{
		%access = "Admin: Ban";
		if($Insomniax::PABan) $Insomniax::PABan = "false";
		else $Insomniax::PABan = "true";
		%toggle = $Insomniax::PABan;
	}
	else if(%lockout == "PAGag") 
	{
		%access = "Admin: Gag";
		if($Insomniax::PAGag) $Insomniax::PAGag = "false";
		else $Insomniax::PAGag = "true";
		%toggle = $Insomniax::PAGag;
	}
	else if(%lockout == "PAMission") 
	{
		%access = "Admin: Change Mission";
		if($Insomniax::PAMission) $Insomniax::PAMission = "false";
		else $Insomniax::PAMission = "true";
		%toggle = $Insomniax::PAMission;
	}
	else if(%lockout == "PATeamDamage") 
	{
		%access = "Admin: Enable/Disable Team Damage";
		if($Insomniax::PATeamDamage) $Insomniax::PATeamDamage = "false";
		else $Insomniax::PATeamDamage = "true";
		%toggle = $Insomniax::PATeamDamage;
	}
	else if(%lockout == "PAFairTeams") 
	{
		%access = "Client: Vote to Toggle Fair Team Checking";
		if($Insomniax::PAFairTeams) $Insomniax::PAFairTeams = "false";
		else $Insomniax::PAFairTeams = "true";
		%toggle = $Insomniax::PAFairTeams;
	}
	else if(%lockout == "PATourneyMode") 
	{
		%access = "Admin: Toggle Tourney/FFA Mode";
		if($Insomniax::PATourneyMode) $Insomniax::PATourneyMode = "false";
		else $Insomniax::PATourneyMode = "true";
		%toggle = $Insomniax::PATourneyMode;
	}
	else if(%lockout == "PATimeLimit") 
	{
		%access = "Admin: Change Time Limit";
		if($Insomniax::PATimeLimit) $Insomniax::PATimeLimit = "false";
		else $Insomniax::PATimeLimit = "true";
		%toggle = $Insomniax::PATimeLimit;
	}
	else if(%lockout == "PAResetDefaults") 
	{
		%access = "Admin: Reset Sever";
		if($Insomniax::PAResetDefaults) $Insomniax::PAResetDefaults = "false";
		else $Insomniax::PAResetDefaults = "true";
		%toggle = $Insomniax::PAResetDefaults;
	}
	else if(%lockout == "PAModOptions") 
	{
		%access = "Admin: IX-Admin Options";
		if($Insomniax::PAModOptions) $Insomniax::PAModOptions = "false";
		else $Insomniax::PAModOptions = "true";
		%toggle = $Insomniax::PAModOptions;
	}
	else if(%lockout == "PATeamInfo") 
	{
		%access = "Admin: Set Team Info";
		if($Insomniax::PATeamInfo) $Insomniax::PATeamInfo = "false";
		else $Insomniax::PATeamInfo = "true";
		%toggle = $Insomniax::PATeamInfo;
	}
	else if(%lockout == "PVKick") 
	{
		%access = "Client: Vote to Kick";
		if($Insomniax::PVKick) $Insomniax::PVKick = "false";
		else $Insomniax::PVKick = "true";
		%toggle = $Insomniax::PVKick;
	}
	else if(%lockout == "PVMission") 
	{
		%access = "Client: Vote to Change Mission";
		if($Insomniax::PVMission) $Insomniax::PVMission = "false";
		else $Insomniax::PVMission = "true";
		%toggle = $Insomniax::PVMission;
	}
	else if(%lockout == "PVTeamDamage") 
	{
		%access = "Client: Vote to Enable/Disable Team Damage";
		if($Insomniax::PVTeamDamage) $Insomniax::PVTeamDamage = "false";
		else $Insomniax::PVTeamDamage = "true";
		%toggle = $Insomniax::PVTeamDamage;
	}
	else if(%lockout == "PVTourneyMode") 
	{
		%access = "Client: Vote to Change to Tourney/FFA Mode";
		if($Insomniax::PVTourneyMode) $Insomniax::PVTourneyMode = "false";
		else $Insomniax::PVTourneyMode = "true";
		%toggle = $Insomniax::PVTourneyMode;
	}
	else if(%lockout == "PVFairTeams") 
	{
		%access = "Client: Vote to Toggle Fair Team Checking";
		if($Insomniax::PVFairTeams) $Insomniax::PVFairTeams = "false";
		else $Insomniax::PVFairTeams = "true";
		%toggle = $Insomniax::PVFairTeams;
	}
	else if(%lockout == "PAVote") 
	{
		%access = "Client: Vote for Admin";
		if($Insomniax::PAVote) $Insomniax::PAVote = "false";
		else $Insomniax::PAVote = "true";
		%toggle = $Insomniax::PAVote;
	}
	else if(%lockout == "PVUnLockAll") 
	{
		%access = "Client: All Vote Options";
		%toggle = "true";
		$Insomniax::PVKick = "true";
		$Insomniax::PVMission = "true";
		$Insomniax::PVFairTeams = "true";
		$Insomniax::PVTeamDamage = "true";
		$Insomniax::PVTourneyMode = "true";
	}
	else if(%lockout == "PVLockAll") 
	{
		%access = "Client: All Vote Options";
		%toggle = "false";
		$Insomniax::PVKick = "false";
		$Insomniax::PVMission = "false";
		$Insomniax::PVFairTeams = "false";
		$Insomniax::PVTeamDamage = "false";
		$Insomniax::PVTourneyMode = "false";
	}
	else if(%lockout == "PAUnLockAll")
	{
		%access = "Admin: All Options";
		%toggle = "true";
		$Insomniax::PATeamChange = "true";
		$Insomniax::PAKick = "true";
		$Insomniax::PABan = "true";
		$Insomniax::PAGag = "true";
		$Insomniax::PAMission = "true";
		$Insomniax::PATeamInfo = "true";
		$Insomniax::PATeamDamage = "true";
		$Insomniax::PAFairTeams = "true";
		$Insomniax::PATourneyMode = "true";
		$Insomniax::PATimeLimit = "true";
		$Insomniax::PAResetDefaults = "true";
		$Insomniax::PAModOptions = "true";
		$Insomniax::PAVote = "true";
	}
	else if(%lockout == "PALockAll")
	{
		%access = "Admin: All Options";
		%toggle = "false";
		$Insomniax::PATeamChange = "false";
		$Insomniax::PAKick = "false";
		$Insomniax::PABan = "false";
		$Insomniax::PAGag = "false";
		$Insomniax::PAMission = "false";
		$Insomniax::PATeamInfo = "false";
		$Insomniax::PATeamDamage = "false";
		$Insomniax::PAFairTeams = "false";
		$Insomniax::PATourneyMode = "false";
		$Insomniax::PATimeLimit = "false";
		$Insomniax::PAResetDefaults = "false";
		$Insomniax::PAModOptions = "false";
		$Insomniax::PAVote = "false";
	}
	else 
 {
echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
echo("IX-Admin: ERROR: Unknown Lockout ",%lockout);
echo("IX-Admin: NOTE: Lockouts ARE Case Sensative");
echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
echo("IX-Admin: Usage: ixtoggle(<lockout>);");
echo("IX-Admin: Example: ixtoggle(\"PVUnLockAll\");");
echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
return;
 }
 echo("IX-Admin: [" @ islocked(%toggle) @ "] " @ %access);
 }
 else
 {
echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
echo("IX-Admin: <lockout>           = What it Toggles.");
echo("IX-Admin: PATeamChange        = Public Admin Team Change");
echo("IX-Admin: PAKick              = Public Admin Kick");
echo("IX-Admin: PABan               = Public Admin Ban");
echo("IX-Admin: PAGag               = Public Admin Gag");
echo("IX-Admin: PAMission           = Public Admin Change Mission");
echo("IX-Admin: PATeamInfo          = Public Admin Team Info");
echo("IX-Admin: PATeamDamage        = Public Admin Team Damage");
echo("IX-Admin: PAFairTeams         = Public Admin Toggle Fair Teams");
echo("IX-Admin: PATourneyMode       = Public Admin Tourney Mode");
echo("IX-Admin: PATimeLimit         = Public Admin Time Limit");
echo("IX-Admin: PAResetDefaults     = Public Admin Reset Server Defaults");
echo("IX-Admin: PAModOptions        = Public Admin Mod Options");
echo("IX-Admin: PVKick              = Public Vote Kick");
echo("IX-Admin: PVMission           = Public Vote Change Mission");
echo("IX-Admin: PVFairTeams         = Public Vote Toggle Fair Teams");
echo("IX-Admin: PVTeamDamage        = Public Vote Team Damage");
echo("IX-Admin: PVTourneyMode       = Public Vote Tourney Mode");
echo("IX-Admin: PALockAll           = Lock All Public Admin Options");
echo("IX-Admin: PAUnLockAll         = UnLock All Public Admin Options");
echo("IX-Admin: PVLockAll           = Lock All Public Vote Options");
echo("IX-Admin: PVUnLockAll         = UnLock All Public Vote Options");
echo("IX-Admin: PAVote              = Public Admin Voting");
echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
echo("IX-Admin: Usage: ixtoggle(<lockout>);");
echo("IX-Admin: Purpose: To change Lockouts from the console");
echo("IX-Admin: Example: ixtoggle(\"PVUnLockAll\");");
echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 }
}

function ixGiveAdmin(%name) {
	if(%name != "")
	{
		%numPlayers = getNumClients();
	   	for(%i = 0; %i < %numPlayers; %i++)
		{
			%pl = getClientByIndex(%i);
			if(%name == Client::getName(%pl))
			{
				if(%pl.isAdmin == false)
          			{
					%pl.isAdmin = true;
					bottomprint(%pl,"<f2>IX-Admin:<f1> You have Been granted Admin Status by the Super Admin.");
					echo("IX-Admin: Admin Granted: ",%name);
				}
				else
 					echo("IX-Admin: ",%name," Already has Admin Status");
				return;
			}
		}
	}
	else
	{
	echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
	echo("IX-Admin: Usage: ixGiveAdmin(<PlayerName>)");
	echo("IX-Admin: Example: ixGiveAdmin(*IX*Savage1);");
	echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
	}
}

function ixPurgeAdmins() 
{
	echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
	echo("IX-Admin: Purging All Public Admins");
	%numPlayers = getNumClients();
	%j=0;
      for(%i = 0; %i < %numPlayers; %i++)
      {
		%pl = getClientByIndex(%i);
		if(!%pl.isSuperAdmin && %pl.isAdmin)
		{
			%j++;
			%pl.isAdmin = false;
			bottomprint(%pl,"<f2>IX-Admin:<f1> Your Admin Status was revoked by the Super Admin.");
			echo("IX-Admin: Removed Admin: ",Client::getName(%pl));
		}
	}
	echo("IX-Admin: Purging Complete.");
	echo("IX-Admin: ",%j," Admins Purged.");
	echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
}

function ixSave()
{
echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
echo("IX-Admin: Saving IX-Admin Settings for ",$InsomniaxInternalVersion);
export("Insomniax::*", "config\\ixadmin.cs", False);
export("DefaultTeamEnergy", "config\\ixadmin.cs", True);
echo("IX-Admin: Settings Saved.");
echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
}

exec(ixUserList);

// Used on Client Connect. 
function IxAdmin_Authenticate(%clientId, %ip)
{
	if($UserList::Activated) 
	{
		%name = Client::getName(%clientId);
		%user = ixGetUser(%name,%ip);
		if(%user) 
		{
			%username = getWord($UserList::User[%user], 1);
			%flags = getWord($UserList::User[%user], 3);
			$ixUserInfo[%clientId] = $UserList::User[%user];
			echo("IX-Admin: User: ",%username," Identified. Access Level: ",%flags);
			ixAdminMsg("User: " @ %username @ " Identified. Access Level: " @ %flags);
			if(%flags == "AutoSuper")
			{
				%clientId.isAdmin = true;
				%clientId.isSuperAdmin = true;
				ixAdminMsg(%username @ " Automaticly Logged in.");
			}
			else if(%flags == "AutoPublic")
			{
				%clientId.isAdmin = true;
				ixAdminMsg(%username @ " Automaticly Logged in.");
			}
		}
		else
		{
			echo("IX-Admin: User: ",%name," Unknown.");
			$ixUserInfo[%clientId] = "0 " @ %name @ " None None " @ %ip;
		}
	}
}

// Used via SAD Password. 
function ixProcess(%client, %name, %user, %username, %flags, %password)
{
	if(!%client.isAdmin) 
	{
		%realpass = getWord($UserList::User[%user], 2);
		if(!String::ICompare(%password, %realpass))
		{
			if((%flags == "PublicAdmin") && (%name == %username))
			{
				%client.isAdmin = true;
			}
			if((%flags == "SuperAdmin") && (%name == %username))
			{
				%client.isAdmin = true;
				%client.isSuperAdmin = true;
			}
			ixAdminMsg(%username @ " Logged in.");
		}	
		else
		{
			Client::sendMessage(%client, 0,"IX-Server: Bad Password");
			ixAdminMsg(%name @ " Login attempt Failed. Username: " @ %username);
		}
	}
	else
	{
		Client::sendMessage(%client, 0,"IX-Server: You Already have Admin Status.");
	}	
}

// Msg All Admins on Server.
function ixAdminMsg(%msg) {
	%numPlayers = getNumClients();
      for(%i = 0; %i < %numPlayers; %i++)
      {
		%pl = getClientByIndex(%i);
		if(%pl.isAdmin)
		{
	            Client::sendMessage(%pl, 0, "IX-Server: " @ %msg);
		}
	}
}

function ixGetUser(%name,%ip)
{
	for(%i=1;%i <= $UserList::MaxUsers;%i++)
	{	
		if(%name == (getWord($UserList::User[%i], 1)))
		{
			for(%j=4;((%mask = getWord($UserList::User[%i], %j)) != -1);%j++)
			{
				if(ixCompareIP(%ip,%mask)) 
					return %i;
			}
			return 0;
		}
	}
	return 0;
}

function ixPrepIP(%transport)
{
	%x = 0;
	%i = 0;
	%now = 0;
	while((%x<2)&&(%i < 30))
	{
		if(String::getSubStr(%transport,%i,1) == ":")
		{	
			if(!%now)
				%now = %i+1;
			else
				return String::getSubStr(%transport, %now, %i - %now);
			%x++;
		}
		%i++;
	}
	return "172.16.0.0";
}

function ixCompareIP(%ip, %mask)
{
	%ipNow = ixDotToSpace(%ip);
	%maskNow = ixDotToSpace(%mask);
	for(%x=0;%x<4;%x++)
		{
			%one = getWord(%ipNow, %x);
			%two = getWord(%maskNow, %x);
			if((%one != %two) && (%two != "*"))
				return "false";
		}
	return "true";
}
	
function ixStrLen(%string)
{
	for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++)
		%length = %i;
	%length++;
	return %length;
}

function ixDotToSpace(%string)
{
	%x = 0;
	%i = 0;
	while(%x<3 && %i < 64) // PORT: was an endless loop on an address or mask with fewer than three dots
	{
		%char = String::getSubStr(%string,%i,1);
		if(!String::ICompare(%char, "."))		{	
			%left = String::getSubStr(%string,0,%i);
			%right = String::getSubStr(%string,%i+1,(ixStrLen(%string)-%i));
			%string = strcat(%left," ",%right);
			%x++;
		}
		%i++;
	}
	return %string;
}

function Insomniax_isFairTeam(%here, %dest) 
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

function Insomniax_onRespawn(%clientId, %playerId)
{
	$empTime[%clientId] = 0;
	%clientId.heat = 0;
	%clientId.cool = "false";
	$ixLockTime[%clientId] = 0;
	$ixLockedTarget[%clientId] = false;
	$ixFloodRockets[%clientId] = false;
	$ixLockedName[%client] = false;
}

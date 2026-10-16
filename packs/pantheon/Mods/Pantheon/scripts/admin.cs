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
   if($AdminPassword != "" && %password == $AdminPassword)
   {
      %client.isAdmin = true;
      %client.isSuperAdmin = true;
   }
   if($RegularAdminPassword != "" && %password == $RegularAdminPassword)
   {
      %client.isAdmin = true;
      %client.isSuperAdmin = false;
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
   if((%client.isAdmin && $Pantheon::PATimeLimit) || (%client.isSuperAdmin))
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
  if(%team >= 0 && %team < 8 && ((%client.isAdmin && $Pantheon::PATeamInfo) || (%client.issuperAdmin)))
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

function Admin::setTeamChangeEnable(%admin)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if($Pantheon::ChangeTeams == "false")
      {
         $Pantheon::ChangeTeams = "true";
         if(%admin == -1)
            messageAll(0, "Team changing set to ENABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " ENABLED team changing.");
      }
      else
      {
         $Pantheon::ChangeTeams = "false";
         if(%admin == -1)
            messageAll(0, "Team changing set to DISABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " DISABLED team changing.");
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
         BanList::add(%ip, $Pantheon::BanKickTime);
      else
         BanList::add(%ip, 180);

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
   if(!$matchStarted || !$Server::TourneyMode)
   {
	if ($Pantheon::ChangeTeams) Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
	if ($Pantheon::PersonalSkins)
	{
		if (%clientId.custom == False)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Use Personal Skin", "persSkin");
		}
		else if (%clientId.custom == True)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Use Team Skin", "persSkin");
		}
	}
   }
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

      if($curVoteTopic == "" && !%clientId.isSuperAdmin)
      {
		if($Pantheon::PAVote && !%clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);

		if($Pantheon::PAKick && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
		else if ($Pantheon::PVKick) Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);

		if($Pantheon::PABan && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);

		if($Pantheon::PATeamChange && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
      }
		else if(%clientId.isSuperAdmin)
		{
			if(!%sel.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
		}
	if($Pantheon::PAGag && %clientId.isAdmin) 
	{
		if (%sel.gag) Client::addMenuItem (%clientId, %curItem++ @ "Un-Gag " @ %name, "ungag " @ %sel);
		else Client::addMenuItem (%clientId, %curItem++ @ "Gag " @ %name, "gag " @ %sel);
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
	else if($curVoteTopic == "" && !%clientId.isSuperAdmin)
	{
		if($Pantheon::PAMission && %clientId.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
		}
		else
		{
			if ($Pantheon::PVMission)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
		}
		if($Pantheon::PATeamDamage && %clientId.isAdmin)
		{
			if($Server::TeamDamageScale == 1.0)
				Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
			else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
		}
		
		else
		if($Server::TeamDamageScale == 1.0)
		{
      			if ($Pantheon::PVTeamDamage)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
			}
		}
		else if ($Pantheon::PVTeamDamage)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
		}
		if($Pantheon::PATourneyMode && %clientId.isAdmin)
		{
			if($Server::TourneyMode)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
				if(!$CountdownStarted && !$matchStarted)
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
				}
			}
			else Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
		}
		else if($Server::TourneyMode)
	     	{
			if ($Pantheon::PVTourneyMode) Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
      			if(!$CountdownStarted && !$matchStarted)
			{
		            	Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
			}
		}
		else if ($Pantheon::PVTourneyMode) Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
		if($Pantheon::PATimeLimit && %clientId.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
		}
		if($Pantheon::PAResetDefaults && %clientId.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
		}
      		if($Pantheon::PAModOptions && %clientId.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Server Options", "Pantheon");
		}
   }
	else if(%clientId.isSuperAdmin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
		if($Server::TeamDamageScale == 1.0)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
		}
		else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");

		if($Pantheon::ChangeTeams)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Disable team changing", "tch");
		}
		else Client::addMenuItem(%clientId, %curItem++ @ "Enable team changing", "tch");

		if($Server::TourneyMode)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
			if(!$CountdownStarted && !$matchStarted)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
			}
		}
		else Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
		Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
		Client::addMenuItem(%clientId, %curItem++ @ "Server Options", "Pantheon");
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
      remoteEval(%clientId, "setInfoLine", 6, "Other: " @ $Client::info[%selId, 5]);
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

function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);

   if(%opt == "fteamchange" && Pantheon_can(%clientId, $Pantheon::PATeamChange))   // PORT FIX
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
      Client::addMenuItem(%clientId, "0Observer", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      return;
   }      
  else if (%opt == "persSkin")   
    {
      if (%clientId.custom == False)
        {
          %clientId.custom = True;
        Client::setSkin(%clientId, $Client::info[%clientId, 0]);
        }
      else if (%clientId.custom == True)
        {
          %clientId.custom = False;
        Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam (%clientId)]);
        }
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
   else if (%opt == "gag" && Pantheon_can(%clientId, $Pantheon::PAGag))   // PORT FIX
   {
      %cl.gag = true;
      MessageAllExcept (%cl, 0, Client::getName(%cl) @ " has been gagged by " @ Client::getName(%clientId) @ ".~wmale3.wdsgst4.wav");
      Client::sendMessage (%cl, 1, "You've been gagged by " @ Client::getName(%clientId) @ " for being a cluck.~wmale3.wdsgst4.wav");
   }
   else if (%opt == "ungag" && Pantheon_can(%clientId, $Pantheon::PAGag))   // PORT FIX
   {
      %cl.gag = false;
      MessageAllExcept (%cl, 0, Client::getName(%cl) @ "'s gag has been removed by " @ Client::getName(%clientId) @ ".");
      Client::sendMessage (%cl, 1, "Your gag has been removed by " @ Client::getName(%clientId));
   }
   else if(%opt == "vkick")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
   }
   else if(%opt == "vadmin" && $Pantheon::PAVote)   // PORT FIX
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
   else if(%opt == "vsmatch")
      Admin::startVote(%clientId, "start the match", "smatch", 0);
   else if(%opt == "vetd")
      Admin::startVote(%clientId, "enable team damage", "etd", 0);
   else if(%opt == "vdtd")
      Admin::startVote(%clientId, "disable team damage", "dtd", 0);
   else if(%opt == "etd" && Pantheon_can(%clientId, $Pantheon::PATeamDamage))   // PORT FIX
      Admin::setTeamDamageEnable(%clientId, true);
   else if(%opt == "dtd" && Pantheon_can(%clientId, $Pantheon::PATeamDamage))   // PORT FIX
      Admin::setTeamDamageEnable(%clientId, false);
   else if(%opt == "tch")
      Admin::setTeamChangeEnable(%clientId);
   else if(%opt == "vcffa")
      Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
   else if(%opt == "vctourney")
      Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
   else if(%opt == "cffa" && Pantheon_can(%clientId, $Pantheon::PATourneyMode))   // PORT FIX
      Admin::setModeFFA(%clientId);
   else if(%opt == "ctourney" && Pantheon_can(%clientId, $Pantheon::PATourneyMode))   // PORT FIX
   {
      Client::buildMenu(%clientId, "Confirm Tourney Mode:", "taffirm", true);
      Client::addMenuItem(%clientId, "1Change to Tourney Mode " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't Change to Tourney" @ Client::getName(%cl), "no " @ %cl);
      return;
   } 
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
   else if(%opt == "kick" && Pantheon_can(%clientId, $Pantheon::PAKick))   // PORT FIX
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "admin" && %clientId.isSuperAdmin)   // PORT FIX
   {
      Client::buildMenu(%clientId, "Confirm Admin:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Make " @ Client::getName(%cl) @ " Admin", "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't Make " @ Client::getName(%cl) @ " Admin", "no " @ %cl);
      return;
   }
   else if(%opt == "ban" && Pantheon_can(%clientId, $Pantheon::PABan))   // PORT FIX
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "smatch" && Pantheon_can(%clientId, $Pantheon::PATourneyMode))   // PORT FIX
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
   else if(%opt == "reset" && Pantheon_can(%clientId, $Pantheon::PAResetDefaults))   // PORT FIX
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
   else if(%opt == "Pantheon" && Pantheon_can(%clientId, $Pantheon::PAModOptions))   // PORT FIX
   {
      Client::buildMenu(%clientId, "Server Options:", "ixsettings", true);
	Client::addMenuItem(%clientId, "1Change Server Anti-TK Lvl", "tkserv " @ $Pantheon::tkServerLvl);
	Client::addMenuItem(%clientId, "2Change Client Anti-TK Lvl", "tkclient " @ $Pantheon::tkClientLvl);
	Client::addMenuItem(%clientId, "3Change Out of Bounds Kill", "areakill " @ $Pantheon::LeaveAreaTime);
	if(%clientId.isSuperAdmin)
		Client::addMenuItem(%clientId, "3Public Admin Voting", "adminvote " @ $Pantheon::PAVote);
	if(%clientId.isSuperAdmin)
		Client::addMenuItem(%clientId, "4Public Admin Lockouts", "palockout");
	if(%clientId.isSuperAdmin)
		Client::addMenuItem(%clientId, "5Public Voting Lockouts", "pvlockout");
	if(%clientId.isSuperAdmin)
		Client::addMenuItem(%clientId, "6Purge Public Admins", "purge " @ %clientId);
      return;
	}
// Pantheon MOD Client TK Actions.
   // PORT FIX: was reachable by any client at any time (kick whoever last team-killed you, or
   // start a "Kick Team Killer" vote against a client id of your choice). Now only when the
   // menu would have offered it, and the target is always the recorded team killer.
   else if(%opt == "tkopt" && Pantheon_tkOptOk(%clientId))
   {
      %cl = Pantheon_getKiller(%clientId);
      if($Pantheon::tkClientLvl == 1)
        Admin::Kick(-3, Pantheon_getKiller(%clientId));
      else
      {
        %cl.voteTarget = true;
        %clientId.selClient = Pantheon_getKiller(%clientId);
        Admin::startVote(%clientId, "Kick Team Killer " @ Client::getName(%cl), "tkkick", %cl);
      }
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

function processMenuTAffirm(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes")
		Admin::setModeTourney(%clientId);
	Game::menuRequest(%clientId);
}

function processMenuAAffirm(%clientId, %opt)
{
    // PORT FIX: stock checks isSuperAdmin here; this copy had lost the check, so anyone who got
    // this menu open (see the "admin" option above) could make any client an admin.
    if(getWord(%opt, 0) == "yes" && %clientId.isSuperAdmin)
    {
	%cl = getWord(%opt, 1);
	%cl.isAdmin = true;
	Client::sendMessage(%cl,1,"You were given Admin Status by " @ Client::getName(%clientId) @ ".");
	Client::sendMessage(%clientId,1,"You gave Admin Status to " @ Client::getName(%cl) @ ".");
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

function processMenuIXSettings(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   // PORT FIX: same rule as the menu that leads here; the last four entries are super admin only.
   if(!Pantheon_can(%clientId, $Pantheon::PAModOptions))
      return;
   if(!%clientId.isSuperAdmin)
   {
      if(%opt == "patoggle" || %opt == "adminvote" || %opt == "palockout" || %opt == "pvlockout" || %opt == "purge")
         return;
   }
   if(%opt == "purge")
      %cl = %clientId;

   if(%opt == "patoggle")
   {
	Client::sendMessage(%clientId, 3, "Public Admin Vote is now " @ isonoff(%cl) @ ".");
	$Pantheon::PAVote = %cl;
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
      Client::buildMenu(%clientId, "Current Public Admin Lockouts:","PALockouts", true);
      Client::addMenuItem(%clientId, "1Team Changing " @ isonoff($Pantheon::PATeamChange), "teamchange " @ $Pantheon::PATeamChange);
      Client::addMenuItem(%clientId, "2Kicking " @ isonoff($Pantheon::PAKick), "kick " @ $Pantheon::PAKick);
      Client::addMenuItem(%clientId, "3Banning " @ isonoff($Pantheon::PABan), "ban " @ $Pantheon::PABan);
      Client::addMenuItem(%clientId, "4Change Mission " @ isonoff($Pantheon::PAMission), "mission " @ $Pantheon::PAMission);
      Client::addMenuItem(%clientId, "5Team Damage " @ isonoff($Pantheon::PATeamDamage), "teamdamage " @ $Pantheon::PATeamDamage);
      Client::addMenuItem(%clientId, "6Tourney Mode " @ isonoff($Pantheon::PATourneyMode), "tourney " @ $Pantheon::PATourneyMode);
      Client::addMenuItem(%clientId, "7Time Limit " @ isonoff($Pantheon::PATimeLimit), "timelimit " @ $Pantheon::PATimeLimit);
      Client::addMenuItem(%clientId, "8Additional Lockouts ...", "additional");
      return;
   }
   else if(%opt == "pvlockout")
   {
      Client::buildMenu(%clientId, "Current Public Voting Lockouts:","PVLockouts", true);
      Client::addMenuItem(%clientId, "1Kicking " @ isonoff($Pantheon::PVKick), "kick " @ $Pantheon::PVKick);
      Client::addMenuItem(%clientId, "2Change Mission " @ isonoff($Pantheon::PVMission), "mission " @ $Pantheon::PVMission);
      Client::addMenuItem(%clientId, "3Team Damage " @ isonoff($Pantheon::PVTeamDamage), "teamdamage " @ $Pantheon::PVTeamDamage);
      Client::addMenuItem(%clientId, "4Tourney Mode " @ isonoff($Pantheon::PVTourneyMode), "tourney " @ $Pantheon::PVTourneyMode);
      return;
   }
   else if(%opt == "adminvote")
   {
      Client::buildMenu(%clientId, "Public Admin Vote is " @ isonoff(%cl), "ixsettings", true);
      Client::addMenuItem(%clientId, "0Turn OFF Public Admin", "patoggle false");
      Client::addMenuItem(%clientId, "1Turn ON Public Admin", "patoggle true");
      return;
   }
   else if(%opt == "purge")
   {
	Client::sendMessage(%cl,3,"Purging All Public Admins of Admin Status.");
	Pantheon_clearPA(%cl);
	Client::sendMessage(%cl,3,"Purging Complete.");
      return;
   }

}

function processMenuPALockouts(%clientId, %option) 
{
	if(!%clientId.isSuperAdmin)	// PORT FIX: super admin only, as the menu entry is
		return;
	%opt = getWord(%option, 0);
	%toggle = getWord(%option, 1);
	if(%opt == "additional")
	{
		Client::buildMenu(%clientId, "Current Public Admin Lockouts:","PALockouts", true);
		Client::addMenuItem(%clientId, "1Server Defaults " @ isonoff($Pantheon::PAResetDefaults), "reset " @ $Pantheon::PAResetDefaults);
      	Client::addMenuItem(%clientId, "2Server Options " @ isonoff($Pantheon::PAModOptions), "modopt " @ $Pantheon::PAModOptions);
      	Client::addMenuItem(%clientId, "3Set Team Info " @ isonoff($Pantheon::PATeamInfo), "teaminfo " @ $Pantheon::PATeamInfo);
      	Client::addMenuItem(%clientId, "4Turn ON all Options", "allon");
		return;
	}
	else if(%opt == "allon") 
	{
		%access = "All Options";
		%toggle = "false";
		$Pantheon::PATeamChange = "true";
		$Pantheon::PAKick = "true";
		$Pantheon::PABan = "true";
		$Pantheon::PAMission = "true";
		$Pantheon::PATeamDamage = "true";
		$Pantheon::PATourneyMode = "true";
		$Pantheon::PATimeLimit = "true";
		$Pantheon::PAResetDefaults = "true";
		$Pantheon::PAModOptions = "true";
	}
	else if(%opt == "teamchange") 
	{
		%access = "Team Changing";
		if(%toggle) $Pantheon::PATeamChange = "false";
		else $Pantheon::PATeamChange = "true";
	}
	else if(%opt == "kick") 
	{
		%access = "Kicking";
		if(%toggle) $Pantheon::PAKick = "false";
		else $Pantheon::PAKick = "true";
	}
	else if(%opt == "ban") 
	{
		%access = "Banning";
		if(%toggle) $Pantheon::PABan = "false";
		else $Pantheon::PABan = "true";
	}
	else if(%opt == "mission") 
	{
		%access = "Changing Mission";
		if(%toggle) $Pantheon::PAMission = "false";
		else $Pantheon::PAMission = "true";
	}
	else if(%opt == "teamdamage") 
	{
		%access = "Team Damage";
		if(%toggle) $Pantheon::PATeamDamage = "false";
		else $Pantheon::PATeamDamage = "true";
	}
	else if(%opt == "tourney") 
	{
		%access = "Tourney Mode";
		if(%toggle) $Pantheon::PATourneyMode = "false";
		else $Pantheon::PATourneyMode = "true";
	}
	else if(%opt == "timelimit") 
	{
		%access = "Mission Time Limit";
		if(%toggle) $Pantheon::PATimeLimit = "false";
		else $Pantheon::PATimeLimit = "true";
	}
	else if(%opt == "reset") 
	{
		%access = "Reseting Sever to Defaults";
		if(%toggle) $Pantheon::PAResetDefaults = "false";
		else $Pantheon::PAResetDefaults = "true";
	}
	else if(%opt == "modopt") 
	{
		%access = "Pantheon Mod Options";
		if(%toggle) $Pantheon::PAModOptions = "false";
		else $Pantheon::PAModOptions = "true";
	}
	else if(%opt == "teaminfo") 
	{
		%access = "Setting Team Info";
		if(%toggle) $Pantheon::PATeamInfo = "false";
		else $Pantheon::PATeamInfo = "true";
	}
	if(%toggle) %toggle = "false";
	else %toggle = "true";
	Client::sendMessage(%clientId, 3, "Public Admin Access to " @ %access @ " is now " @ isonoff(%toggle) @ ".");
}

function processMenuPVLockouts(%clientId, %option) 
{
if(!%clientId.isSuperAdmin)	// PORT FIX: super admin only, as the menu entry is
	return;
	%opt = getWord(%option, 0);
	%toggle = getWord(%option, 1);
	if(%opt == "teamchange") 
	{
		%access = "Team Changing";
		if(%toggle) $Pantheon::PVTeamChange = "false";
		else $Pantheon::PVTeamChange = "true";
	}
	else if(%opt == "kick") 
	{
		%access = "Kicking";
		if(%toggle) $Pantheon::PVKick = "false";
		else $Pantheon::PVKick = "true";
	}
	else if(%opt == "mission") 
	{
		%access = "Changing Mission";
		if(%toggle) $Pantheon::PVMission = "false";
		else $Pantheon::PVMission = "true";
	}
	else if(%opt == "teamdamage") 
	{
		%access = "Team Damage";
		if(%toggle) $Pantheon::PVTeamDamage = "false";
		else $Pantheon::PVTeamDamage = "true";
	}
	else if(%opt == "tourney") 
	{
		%access = "Tourney Mode";
		if(%toggle) $Pantheon::PVTourneyMode = "false";
		else $Pantheon::PVTourneyMode = "true";
	}
	else if(%opt == "timelimit") 
	{
		%access = "Mission Time Limit";
		if(%toggle) $Pantheon::PVTimeLimit = "false";
		else $Pantheon::PVTimeLimit = "true";
	}
	if(%toggle) %toggle = "false";
	else %toggle = "true";
	Client::sendMessage(%clientId, 3, "Public Voting Access to " @ %access @ " is now " @ isonoff(%toggle) @ ".");
}


// PORT FIX (security): menu codes come from the client. The Pantheon menus only HID the admin
// entries; the handlers behind them did not check who was asking. Pantheon_can() is the same
// rule Game::menuRequest uses to decide what to show: a super admin may always, an admin only
// when the super admin has switched that 'public admin' option on.
function Pantheon_can(%clientId, %toggle)
{
   if(%clientId.isSuperAdmin)
      return 1;
   if(%clientId.isAdmin)
   {
      if(%toggle)
         return 1;
   }
   return 0;
}

// PORT FIX: true only when this client really has a team killer on record who is over the limit
// (the condition Game::menuRequest uses before it offers the 'Kick Team Killer' entry).
function Pantheon_tkOptOk(%clientId)
{
   %k = Pantheon_getKiller(%clientId);
   if(%k == "")
      return 0;
   if(%k == %clientId)
      return 0;
   if($tkKills[%k] >= $Pantheon::tkLimit)
      return 1;
   return 0;
}

function isonoff(%toggle)
{
	if(%toggle) return "On";
	else return "Off";
}

function processMenuServerLvl(%clientId, %option) 
{
   if(!Pantheon_can(%clientId, $Pantheon::PAModOptions))   // PORT FIX
      return;
   $Pantheon::tkServerLvl = %option;
   if(%option == 0)
     messageAll(0, "SERVER:TK Protection Level Set to Zero. (Logging TK's only).");
   if(%option == 1)
     messageAll(0, "SERVER:TK Protection Level Set to One. (Auto Vote).");
   if(%option == 2)
     messageAll(0, "SERVER:TK Protection Level Set to Two. (Auto Vote Until Kicked).");
   if(%option == 3)
     messageAll(0, "SERVER:TK Protection Level Set to Three. (Auto Kick).");
}

function processMenuClientLvl(%clientId, %option) 
{
   if(!Pantheon_can(%clientId, $Pantheon::PAModOptions))   // PORT FIX
      return;
   $Pantheon::tkClientLvl = %option;
   if(%option == 0)
     messageAll(0, "SERVER: Client TK Vote Option Engaged. (From Options Menu).");
   if(%option == 1)
     messageAll(0, "SERVER: Client TK Kick Option Engaged. (From Options Menu).");
}

function processMenuAKill(%clientId, %option) 
{
if(!Pantheon_can(%clientId, $Pantheon::PAModOptions))   // PORT FIX
	return;
   if(!Pantheon_can(%clientId, $Pantheon::PAModOptions))   // PORT FIX
      return;
   $Pantheon::LeaveAreaTime = %option;
   if(%option == 0)
     messageAll(0, "SERVER: Leaving Mission Area Now Does not Kill you.");
   else
     messageAll(0, "SERVER: Leaving Mission Area Now Kills you in " @ %option @ " Seconds.");

}

function Pantheon_ServerLvlTxt()
{
    if($Pantheon::tkServerLvl == 0)
    	%tkText = "Only Logging TK's"; 
    else if($Pantheon::tkServerLvl == 1)
	%tkText = "Votes at " @ $Pantheon::tkLimit @ " TK's";
    else if($Pantheon::tkServerLvl == 2)
	%tkText = "Votes at " @ $Pantheon::tkLimit @ " TKs and Kicks at " @ $Pantheon::tkLimit * $Pantheon::tkMultiple @ " TK's";
    else if($Pantheon::tkServerLvl == 3)
	%tkText = "Kicks at " @ $Pantheon::tkLimit @ " TK's";
    else %tkText = "ERROR: Server Level set to Unkown Level";
    return %tkText;
}

function Pantheon_ClientLvlTxt()
{
    if($Pantheon::tkClientLvl == 0)
    	%tkText = "Vote Option at " @ $Pantheon::tkLimit @ " TK's"; 
    else if($Pantheon::tkClientLvl == 1)
	%tkText = "Kick Option at " @ $Pantheon::tkLimit @ "TK's";
    else %tkText = "ERROR: Client Level set to Unkown Level";
    return %tkText;
}

// Insomnaix Mod TK Handling - *IX*Savage1
function Pantheon_setTeamKill(%victimId, %killerId) 
{
	$tkVictim[%killerId] = %victimId;
	$tkKiller[%victimId] = %killerId;
	$tkKills[%killerId] += 1;
	%trigger = $tkKills[%killerId] % $Pantheon::tkLimit;
	%tkTopKills = $Pantheon::tkLimit * $Pantheon::tkMultiple;
	if(($tkKills[%killerId] >= $Pantheon::tkLimit) && (!%trigger)) 
	  {
	  if($Pantheon::tkServerLvl) 
	    {
	    if($Pantheon::tkServerLvl != 3)
	      {
		if(($tkKills[%killerId] >= %tkTopKills) && ($Pantheon::tkServerLvl != 1))
		{
		messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing. Confirmed " @ $tkKills[%killerId] @ " Team Kills.");
		Admin::Kick(-2, %killerId);
		return;
		}
		%killerId.voteTarget = true;
     		%victimId.selClient = Pantheon_getKiller(%victimId);
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

function Pantheon_getKiller(%clientId) 
{
  return $tkKiller[%clientId];
}

function Pantheon_getVictim(%clientId) 
{
  return $tkVictim[%clientId];
}

function Pantheon_clearPA(%admin) 
{
	if(%admin.isSuperAdmin)
	{
	      %numPlayers = getNumClients();
      	for(%i = 0; %i < %numPlayers; %i++)
	      {
			%pl = getClientByIndex(%i);
			if(!%pl.isSuperAdmin && %pl.isAdmin)
			{
				%pl.isAdmin = false;
				Client::sendMessage(%pl,1,"Your Admin Status has been revoked by the Super Admin.");
				Client::sendMessage(%admin,3,"Public Admin Status Stripped from: " @ Client::getName(%pl) @ ".");
			}
		}
	}
}


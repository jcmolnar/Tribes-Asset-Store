$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

function processMenuCMType(%clientId, %options)
{
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
	return;
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
   bottomprint(%clientId, "", 0);
}

function remoteVoteNo(%clientId)
{
   %clientId.vote = "no";
   bottomprint(%clientId, "", 0);
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

function Admin::setStandoffsEnable(%admin, %enabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if(%enabled)
      {
         $Standoffs = "true";
         if(%admin == -1)
            messageAll(0, "Standoffs allowed by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " allowed Standoffs.");
      }
      else
      {
         $Standoffs = "false";
         if(%admin == -1)
            messageAll(0, "No Standoffs by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " disallowed Standoffs.");
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
         messageAll(0, "Server switched to Public Server Mode.");
      else
         messageAll(0, "Server switched to Public Server Mode by " @ Client::getName(%clientId) @ ".");

      $Server::TourneyMode = false;
      bottomprintall(); // clear the messages
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
         messageAll(0, "Server switched to Clan War Mode.");
      else
         messageAll(0, "Server switched to Clan War Mode by " @ Client::getName(%clientId) @ ".");

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
   Client::buildMenu(%clientId, "" @ $HardCorps::Menu @ "", "options", true);
   if(!$matchStarted || !$Server::TourneyMode)
   {
	Client::addMenuItem(%clientId, %curItem++ @ "Player Options", "playeropts");
   }


   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

      if($curVoteTopic == "" && !%clientId.isAdmin && %clientId != %clientId.selClient)
      {
		if (%clientId.regularuser)
			{
		         Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin Player", "vadmin " @ %sel);
			}

		if (%clientId.speaktarget != Player::getClient(%clientId.selClient))
			{
		            Client::addMenuItem(%clientId, %curItem++ @ "Talk To Player", "settalktarget " @ %sel);
			}

         Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick Player", "vkick " @ %sel);
      }

      if(%clientId.isAdmin && %clientId != %clientId.selClient)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Admin Options", "xadminopts " @ %sel);		
      }

      if(%clientId != %clientId.selClient)
		{
		      if(%clientId.observerMode == "observerOrbit")
		         Client::addMenuItem(%clientId, %curItem++ @ "Observe Player", "observe " @ %sel);
		}
   }


   if($curVoteTopic != "" && %clientId.vote == "")
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }
   else if($curVoteTopic == "" && !%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Gameplay Options", "playergameopts");
   }
   else if(%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Gameplay Options", "admingameopts");
      Client::addMenuItem(%clientId, %curItem++ @ "Server Options", "optserver");
   }

	Client::addMenuItem(%clientId, %curItem++ @ "Hard Corps Help", "hardcorpshelp");
}

function remoteSelectClient(%clientId, %selId)
{
   if(%clientId.selClient != %selId)
   {
      %clientId.selClient = %selId;
      if(%clientId.menuMode == "options")
         Game::menuRequest(%clientId);
      remoteEval(%clientId, "setInfoLine", 1, "Player Info for " @ Client::getName(%selId) @ ":");
      remoteEval(%clientId, "setInfoLine", 2, "Defence Bonus: " @ %selId.defencebonus);
      remoteEval(%clientId, "setInfoLine", 3, "Offence Bonus: " @ %selId.offencebonus);
      remoteEval(%clientId, "setInfoLine", 4, "Total Kills: " @ %selId.totalkills);
	%pointval = %selId.totalkills + %selId.defencebonus + %selId.offencebonus;
	if (%pointval <= 0) %pointval = 1;
      remoteEval(%clientId, "setInfoLine", 5, "Kill value: " @ %pointval);
      remoteEval(%clientId, "setInfoLine", 6, "Team Kills: " @ %selId.TeamKills);
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
      bottomprint(%clientId, "");
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
   else if(%opt == "xadminopts")
   {
	%sel = %cl;
	%curItem = 0;

	Client::buildMenu(%clientId, "ADMIN OPTIONS", "options", true);

      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ "Unmute Player", "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Mute Player", "mute " @ %sel);
         Client::addMenuItem(%clientId, %curItem++ @ "Kick Player", "kick " @ %sel);
         Client::addMenuItem(%clientId, %curItem++ @ "Ban Player", "ban " @ %sel);

	   if (!%clientId.selClient.isAdmin)
		{
		if (%clientId.selClient.regularuser)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Remove User Status", "demuser " @ %sel);
			} else
			{
		            Client::addMenuItem(%clientId, %curItem++ @ "Activate User Status", "muser " @ %sel);
			}
		}
         if(%clientId.isSuperAdmin)
         {
		%kl = %clientId.selClient;
		if(%kl.tklog > 0 || %kl.TeamKills > 0 || %kl.teamkiller == "true") Client::addMenuItem(%clientId, %curItem++ @ "Clear Player's TK Log", "cleartk " @ %sel);

		if (!%clientId.selClient.isSuperAdmin)
			{
				if (%clientId.selClient.isAdmin)
					{
						Client::addMenuItem(%clientId, %curItem++ @ "Remove Admin", "deadmin " @ %sel);
					} else
					{
		            		Client::addMenuItem(%clientId, %curItem++ @ "Admin", "admin " @ %sel);
					}
			}

         }
		if ($UseTKEffect == "true")
			{
				if (%clientId.selClient.teamkiller == "true")
					{
						Client::addMenuItem(%clientId, %curItem++ @ "Deactive TK", "tkoff " @ %sel);
					} else 
					{
						Client::addMenuItem(%clientId, %curItem++ @ "Activate TK", "tkon " @ %sel);
					}
			}
         Client::addMenuItem(%clientId, %curItem++ @ "Change Player's team", "fteamchange " @ %sel);

	return;
   }
   else if(%opt == "tkon")
   {
	if(!%clientId.isAdmin) return; // PORT: admin only, as the menu that lists it; the code comes from the client
	%cId = Player::getClient(%cl);
      messageAll(0, Client::getName(%clientId) @ " sets " @ Client::getName(%cId) @ " to Team Killer status.");
	%cl.TeamKills = $TKwarnlimit;
	if ($UseTKEffect == "true") HCTK::CheckForTKer(%cl); // PORT: was %clientId
	return;
   }
   else if(%opt == "tkoff")
   {
	if(!%clientId.isAdmin) return; // PORT: admin only, as the menu that lists it; the code comes from the client
	if (%cl.teamkiller == "true") 
		{
			%cId = Player::getClient(%cl);
		      messageAll(0, Client::getName(%clientId) @ " sets " @ Client::getName(%cId) @ " to normal (non-Team Killer) status.");
			HCTK::TKOff(%cl); // PORT: was %clientId
		}
	return;
   }

   else if(%opt == "settalktarget")
   {
	%cId = Player::getClient(%cl);
	if (!%clientId.isAdmin)
		{
			bottomprint(%clientId,"<jc><f2>You have set " @ Client::getName(%cId) @ " as your message target\n\nTo type a message that only " @ Client::getName(%cId) @ " will see,\npreceed your message with an exclaimation mark. Eg. !Hey, there buddy.", 5);
		} else
		{
			bottomprint(%clientId,"<jc><f2>You have set " @ Client::getName(%cId) @ " as your message target\n\nTo type a message that only " @ Client::getName(%cId) @ " will see,\npreceed your message with an exclaimation mark. Eg. !Hey there, buddy.\nTo type a message to the center of " @ Client::getName(%cId) @ "'s screen,\n preceed your message with an question mark.  Eg. ?Hey there, buddy.", 5);
		}
	%clientId.speaktarget = %cId;
	return;
   }
   else if(%opt == "cleartk")
   {
	if(!%clientId.isSuperAdmin) return; // PORT: super admin only, as the menu that lists it
	%cId = Player::getClient(%cl);
      messageAll(0, Client::getName(%clientId) @ " sets " @ Client::getName(%cId) @ " to normal (non-Team Killer) status.");
	%cl.tklog = 0;
	HCTK::TKOff(%cl); // PORT: was %clientId
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
      if(!%clientId.regularuser) return; // PORT: the menu offers the admin vote to Regular Users only
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
   else if(%opt == "vsmatch")
	{
	      Admin::startVote(%clientId, "start the match", "smatch", 0);
		return;
	}
   else if(%opt == "vetd")
	{
	      Admin::startVote(%clientId, "enable team damage", "etd", 0);
		return;
	}
   else if(%opt == "vdtd")
	{
	      Admin::startVote(%clientId, "disable team damage", "dtd", 0);
		return;
	}
   else if(%opt == "etd")
	{
	      Admin::setTeamDamageEnable(%clientId, true);
		return;
	}
   else if(%opt == "dtd")
	{
	      Admin::setTeamDamageEnable(%clientId, false);
		return;
	}
   else if(%opt == "vcffa")
	{
	      Admin::startVote(%clientId, "change to Public Server Mode", "ffa", 0);
		return;
	}
   else if(%opt == "vctourney")
	{
	      Admin::startVote(%clientId, "change to Clan War Mode", "tourney", 0);
		return;
	}
   else if(%opt == "cffa")
	{
	      Admin::setModeFFA(%clientId);
		return;
	}
   else if(%opt == "ctourney")
	{
	      Admin::setModeTourney(%clientId);
		return;
	}
   else if(%opt == "voteYes" && %cl == $curVoteCount)
   {
      %clientId.vote = "yes";
      bottomprint(%clientId, "", 0);
	return;
   }
   else if(%opt == "voteNo" && %cl == $curVoteCount)
   {
      %clientId.vote = "no";
      bottomprint(%clientId, "", 0);
	return;
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
	   if(!%clientId.isSuperAdmin) return; // PORT: super admin only, as the menu that lists it
  	   %cId = Player::getClient(%cl);
         %cl.isAdmin = true;
	   %cl.regularuser = true;
         messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cId) @ " into an admin.");
         return;
   }
   else if(%opt == "deadmin")
   {
	%cId = Player::getClient(%cl);
	if(%clientId.isSuperAdmin && !%cl.ishost && %clientId != %cId)
	 {
         %cl.isAdmin = "";
	   if (%clientId.ishost) %cl.isSuperAdmin = "";
	   if (%cl.regularuser == true) %cl.regularuser = "";
         messageAll(0, Client::getName(%clientId) @ " removed " @ Client::getName(%cId) @ "'s admin status.");
         return;
	  }
   }
   else if(%opt == "muser")
   {
	   if(!%clientId.isAdmin || %cl.isAdmin) return; // PORT: admin only, as the menu that lists it
  	   %cId = Player::getClient(%cl);
	   %cl.regularuser = true;
         messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cId) @ " into a Regular User.");
         return;
   }
   else if(%opt == "demuser")
   {
	if(%clientId.isAdmin && !%cl.ishost && %clientId != %cl && !%cl.isAdmin && %cl.regularuser) // PORT
	  {
	%cId = Player::getClient(%cl);
         %cl.isAdmin = "";
	   %cl.isSuperAdmin = "";
	   if (%cl.regularuser == true) %cl.regularuser = "";
         messageAll(0, Client::getName(%clientId) @ " removed " @ Client::getName(%cId) @ "'s Regular User status.");
         return;
	}
   }
   else if(%opt == "ban")
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "smatch")
	{
	      Admin::startMatch(%clientId);
		return;
	}
   else if(%opt == "vcmission")
   {
	%first = getWord(%options, 1);

	Client::buildMenu(%clientId, "SELECT MISSION TYPE", "cmtype", true);
	%index = 0;

	   if ($MList::TypeCount < 2) $TypeStart = 0; else $TypeStart = 1;
   
	   for(%i = $TypeStart; %i < $MLIST::TypeCount; %i++)
	   {
		if ($MLIST::Type[%i] != "Training")
	      	{
         			%index++;
				if (%index <= 7)
					{
		      	   		Client::addMenuItem(%clientId, %index @ $MLIST::Type[%i], %i @ " 0");
					} else
					{
						Client::addMenuItem(%clientId, %index @ "More Mission Types...", "more " @ %i);
						break;
					}
	      	}

	   }

      return;
   }
   else if(%opt == "admingameopts")
   {
	%curItem = 0;
	Client::buildMenu(%clientId, "GAMEPLAY OPTIONS", "options", true);
      if($Server::TourneyMode)
      	{
			Client::addMenuItem(%clientId, %curItem++ @ "Public Server Mode", "cffa");
     	    		if(!$CountdownStarted && !$matchStarted)
            	Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
			      } else Client::addMenuItem(%clientId, %curItem++ @ "Clan War Mode", "ctourney");

		      if($Server::TeamDamageScale == 1.0) 
				Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
				      else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");

			Client::addMenuItem(%clientId, %curItem++ @ "Mission Options", "admmissopts");
			Client::addMenuItem(%clientId, %curItem++ @ "Special Options", "specopts");	
	return;
   }
   else if(%opt == "hardcorpshelp")
   {
	%curItem = 0;
	Client::buildMenu(%clientId, "HARD CORPS HELP", "mostnewoptions", true);
	//Client::addMenuItem(%clientId, %curItem++ @ "User/Admin/SuperAdmin", "hchelp admin");
	Client::addMenuItem(%clientId, %curItem++ @ "Armours", "hchelp armours");
	Client::addMenuItem(%clientId, %curItem++ @ "Backpacks", "hchelp backpacks");
	Client::addMenuItem(%clientId, %curItem++ @ "Deployables", "hchelp deployables");
	Client::addMenuItem(%clientId, %curItem++ @ "Miscellaneous", "hchelp miscellaneous");
	Client::addMenuItem(%clientId, %curItem++ @ "Vehicles", "hchelp vehicles");
	Client::addMenuItem(%clientId, %curItem++ @ "Weapons", "hchelp weapons");

	return;
   }

   else if(%opt == "admmissopts")
   {
	%curItem = 0;
	Client::buildMenu(%clientId, "MISSION OPTIONS", "neweroptions", true);
      Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");

	if($TestMissionType == "CTF" && getNumTeams() <= 2)
		{
		      if($Standoffs == "false") 
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Allow Standoffs", "dreqd");
					Client::addMenuItem(%clientId, %curItem++ @ "Standoff Time", "standlimit");
					Client::addMenuItem(%clientId, %curItem++ @ "Sudden Death Time", "suddenlimit");
				} else Client::addMenuItem(%clientId, %curItem++ @ "Disallow Standoffs", "ereqd");
		}
	return;
   }
   else if(%opt == "specopts")
   {
	%curItem = 0;
	Client::buildMenu(%clientId, "SPECIAL OPTIONS", "newoptions", true);
	Client::addMenuItem(%clientId, %curItem++ @ "Damage Options", "admindamscale");	
	Client::addMenuItem(%clientId, %curItem++ @ "Scoring Options", "adminscore");
	Client::addMenuItem(%clientId, %curItem++ @ "Station Eject Options", "adminstation");
	Client::addMenuItem(%clientId, %curItem++ @ "Team-Killer Options", "admintk");
	Client::addMenuItem(%clientId, %curItem++ @ "Allowed Equipment", "allowequip");
	if ($LeaveMissionAreaDamage == "true") Client::addMenuItem(%clientId, %curItem++ @ "No Mission Area Damage", "dmiss");
		else Client::addMenuItem(%clientId, %curItem++ @ "Mission Area Damage", "emiss");

	return;
   }
   else if(%opt == "playergameopts")
   {
	%curItem = 0;
	Client::buildMenu(%clientId, "GAMEPLAY OPTIONS", "options", true);

      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");

      if($Server::TourneyMode)
      	{
	         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Public Server Mode", "vcffa");
	         if(!$CountdownStarted && !$matchStarted)
      	      Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
	      } else
		{
	         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Clan War Mode", "vctourney");
		}
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
               
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to Change mission", "vcmission");
	return;
   }
   else if(%opt == "optserver")
   {
	%curItem = 0;

	Client::buildMenu(%clientId, "SERVER OPTIONS", "options", true);
	if ($AllowCustomSkins == "true")
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Disable Personal Skins", "allskinsoff");	
		} else
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Enable Personal Skins", "allskinson");	
		}

	Client::addMenuItem(%clientId, %curItem++ @ "Player Defaults", "playerdefaults");	
	Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");	
	Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
	return;
   }
   else if(%opt == "playerdefaults")
   {
	%curItem = 0;
	Client::buildMenu(%clientId, "PLAYER DEFAULTS", "newoptions", true);
	if ($DefaultShowWeaponNames == "true") Client::addMenuItem(%clientId, %curItem++ @ "Hide Weapon Names", "dweapnameoff");
		else Client::addMenuItem(%clientId, %curItem++ @ "Show Weapon Names", "dweapnameon");

	if ($DefaultShowWeaponStats == "true") Client::addMenuItem(%clientId, %curItem++ @ "Hide Weapon Stats", "dweapstatoff");
		else Client::addMenuItem(%clientId, %curItem++ @ "Show Weapon Stats", "dweapstaton");

	if ($ShowScoreBonuses == "true") Client::addMenuItem(%clientId, %curItem++ @ "Hide Score Announcements", "dscoreb");
		else Client::addMenuItem(%clientId, %curItem++ @ "Show Score Announcements", "escoreb");

	return;

   }
   else if(%opt == "playeropts")
   {
	%curItem = 0;

	Client::buildMenu(%clientId, "PLAYER OPTIONS", "options", true);
      if($Game::MissionType != "TideOfBattle") Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
	if($AllowCustomSkins == "true") 
		{
			if (%clientId.custom == "true") Client::addMenuItem(%clientId, %curItem++ @ "Use Team Skin", "skinsoff");
				else Client::addMenuItem(%clientId, %curItem++ @ "Use Personal Skin", "skinson");
		}
	Client::addMenuItem(%clientId, %curItem++ @ "Spawn Equipment", "spawnequipment");
	Client::addMenuItem(%clientId, %curItem++ @ "Display Options", "displayopts");
	return;
   }
   else if(%opt == "spawnequipment")
   {
	%curItem = 0;
	%pl = Player::getClient(%clientId);

	Client::buildMenu(%clientId, "SPAWN EQUIPMENT", "neweroptions", true);

	Client::addMenuItem(%clientId, %curItem++ @ "" @ %pl.slota.description @ "", "spawnslot SlotA");
	Client::addMenuItem(%clientId, %curItem++ @ "" @ %pl.slotb.description @ "", "spawnslot SlotB");
	Client::addMenuItem(%clientId, %curItem++ @ "" @ %pl.slotc.description @ "", "spawnslot SlotC");

	return;
   }
   else if(%opt == "displayopts")
   {
	%curItem = 0;

	Client::buildMenu(%clientId, "DISPLAY OPTIONS", "newoptions", true);

	if (%clientId.weaponnames == "true") Client::addMenuItem(%clientId, %curItem++ @ "Hide Weapon Names", "weapnameoff");
		else Client::addMenuItem(%clientId, %curItem++ @ "Show Weapon Names", "weapnameon");

	if (%clientId.weaponstats == "true") Client::addMenuItem(%clientId, %curItem++ @ "Hide Weapon Stats", "weapstatoff");
		else Client::addMenuItem(%clientId, %curItem++ @ "Show Weapon Stats", "weapstaton");

	if (%clientId.showdescriptions == "true") Client::addMenuItem(%clientId, %curItem++ @ "Hide Descriptions", "ddescript");	
		else Client::addMenuItem(%clientId, %curItem++ @ "Show Descriptions", "edescript");	

	if (%clientId.showscorebonuses == "true") Client::addMenuItem(%clientId, %curItem++ @ "Hide Score Announcements", "dscorea");	
		else Client::addMenuItem(%clientId, %curItem++ @ "Show Score Announcements", "escorea");	

	return;
   }
   else if(%opt == "skinson")
   {
	%clientId.custom = "true";
	bottomprint(%clientId,"<jc><f2>Personal Skin enabled.", 5);	
	Client::setSkin(%clientId, $Client::info[%clientId, 0]);
	return;
   }
   else if(%opt == "skinsoff")
   {
	%clientId.custom = "false";
	bottomprint(%clientId,"<jc><f2>Personal Skin disabled.", 5);	
	Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
	return;
   }
   else if(%opt == "dweapstaton")
   {
	if(!%clientId.isAdmin) return; // PORT: admin only, as the menu that lists it; the code comes from the client
	$DefaultShowWeaponStats = "true";
	bottomprint(%clientId,"<jc><f2>Showing Weapon Statistics set as Server Default.", 5);	
	return;
   }
   else if(%opt == "dweapstatoff")
   {
	if(!%clientId.isAdmin) return; // PORT: admin only, as the menu that lists it; the code comes from the client
	$DefaultShowWeaponStats = "false";
	bottomprint(%clientId,"<jc><f2>Hiding Weapon Statistics set as Server Default.", 5);	
	return;
   }
   else if(%opt == "escoreb")
   {
	if(!%clientId.isAdmin) return; // PORT: admin only, as the menu that lists it; the code comes from the client
	$ShowScoreBonuses = "true";
	bottomprint(%clientId,"<jc><f2>Showing Score Announcements set as Server Default.", 5);	
	return;
   }
   else if(%opt == "dscoreb")
   {
	if(!%clientId.isAdmin) return; // PORT: admin only, as the menu that lists it; the code comes from the client
	$ShowScoreBonuses = "false";
	bottomprint(%clientId,"<jc><f2>Hiding Score Announcements set as Server Default.", 5);	
	return;
   }
   else if(%opt == "allskinson")
   {
	if(!%clientId.isAdmin) return; // PORT: admin only, as the menu that lists it; the code comes from the client
	$AllowCustomSkins = "true";
      messageAll(0, Client::getName(%clientId) @ " enabled Personal Skins.");
	return;
   }
   else if(%opt == "allskinsoff")
   {
	if(!%clientId.isAdmin) return; // PORT: admin only, as the menu that lists it; the code comes from the client
	$AllowCustomSkins = "false";
      messageAll(0, Client::getName(%clientId) @ " disabled Personal Skins.");
	return;
   }
   else if(%opt == "ctimelimit")
   {
      Client::buildMenu(%clientId, "GAME TIME:", "ctlimit", true);
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


function remoteSetStandoff(%client, %opt)
{
   %time = floor(%opt);
   if(%opt == $StandoffsTimeLimit || (%opt != 0 && %opt < 1))
      return;

   if(%client.isAdmin)
   {
      $StandoffsTimeLimit = %opt;
      if(%opt)
         messageAll(0, Client::getName(%client) @ " changed the Standoff Time Limit to " @ %opt @ " seconds.");
      else
         messageAll(0, Client::getName(%client) @ " changed the Standoff Time Limit to Instantaneous.");
         
   }
}

function processMenuStandoff(%clientId, %opt)
{
   remoteSetStandoff(%clientId, %opt);
}


function remoteSetSudden(%client, %opt)
{
   %time = floor(%opt);
   if(%opt == $SuddenDeathTimeLimit || (%opt != 0 && %opt < 1))
      return;

   if(%client.isAdmin)
   {
      $SuddenDeathTimeLimit = %opt;
	$SuddenDeathCounter[0] = $SuddenDeathTimeLimit;
	$SuddenDeathCounter[1] = $SuddenDeathTimeLimit;
      if(%opt)
         messageAll(0, Client::getName(%client) @ " changed the Sudden Death Time Limit to " @ %opt @ " seconds.");
      else
         messageAll(0, Client::getName(%client) @ " changed the Sudden Death Time Limit to Instantaneous.");
   }
}

function processMenuSudden(%clientId, %opt)
{
   remoteSetSudden(%clientId, %opt);
}


function remoteSetDamageScale(%client, %opt)
{
   %time = floor(%opt);
   if(%opt != 0 && %opt < 1)
      return;

   if(%client.isAdmin)
   {
      if (%opt != 0) 
		{
			$AdjustedDamageScale = (%opt * 0.01);
		} else 
		{
			$AdjustedDamageScale = 0;
		}
      if (%opt == 0) messageAll(0, Client::getName(%client) @ " disabled all weapon damage.");

      if (%opt == 25) messageAll(0, Client::getName(%client) @ " changed the Adjusted Damage Scale to a Very Low level.");
      if (%opt == 50) messageAll(0, Client::getName(%client) @ " changed the Adjusted Damage Scale to a Low level.");
      if (%opt == 75) messageAll(0, Client::getName(%client) @ " changed the Adjusted Damage Scale to a Moderately Low level.");
      if (%opt == 100) messageAll(0, Client::getName(%client) @ " changed the Adjusted Damage Scale to a Normal level.");
      if (%opt == 125) messageAll(0, Client::getName(%client) @ " changed the Adjusted Damage Scale to a Moderately High level.");
      if (%opt == 150) messageAll(0, Client::getName(%client) @ " changed the Adjusted Damage Scale to a High level.");
      if (%opt == 175) messageAll(0, Client::getName(%client) @ " changed the Adjusted Damage Scale to a Very High level.");
   }
}

function processMenuDamScale(%clientId, %opt)
{
   remoteSetDamageScale(%clientId, %opt);
}

function processMenuNewOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   // PORT: only the eight per-player display codes are open to everyone. Every other code of this
   // menu changes a server setting or builds an admin menu; the menus that list them are admin only
   // but the code is sent by the client.
   if(!%clientId.isAdmin && %opt != "weapnameon" && %opt != "weapnameoff" && %opt != "escorea" && %opt != "dscorea" && %opt != "edescript" && %opt != "ddescript" && %opt != "weapstaton" && %opt != "weapstatoff")
   {
      Game::menuRequest(%clientId);
      return;
   }

   if(%opt == "weapnameon")
   {
	%clientId.weaponnames = "true";
	bottomprint(%clientId,"<jc><f2>Showing Weapon Names.", 5);	
	return;
   }
   else if(%opt == "weapnameoff")
   {
	%clientId.weaponnames = "false";
	bottomprint(%clientId,"<jc><f2>Hiding Weapon Names.", 5);	
	return;
   }
   else if(%opt == "escorea")
   {
	%clientId.showscorebonuses = "true";
	bottomprint(%clientId,"<jc><f2>Showing Score Announcements.", 2);	
	return;
   }
   else if(%opt == "dscorea")
   {
	%clientId.showscorebonuses = "false";
	bottomprint(%clientId,"<jc><f2>Hiding Score Announcements.", 5);	
	return;
   }
   else if(%opt == "edescript")
   {
	%clientId.showdescriptions = "true";
	bottomprint(%clientId,"<jc><f2>Showing HARD CORPS descriptions.", 2);	
	return;
   }
   else if(%opt == "ddescript")
   {
	%clientId.showdescriptions = "false";
	bottomprint(%clientId,"<jc><f2>Hiding HARD CORPS descriptions.", 5);	
	return;
   }
   else if(%opt == "admindamscale")
   {
	%curItem = 0;
	Client::buildMenu(%clientId, "DAMAGE OPTIONS", "newoptions", true);
	if ($UseAdjustedDamageScale == "true") 
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Disable Adjusted Damage", "dadjdam");
			Client::addMenuItem(%clientId, %curItem++ @ "Adjusted Damage Scale", "damagescale");	
		} else Client::addMenuItem(%clientId, %curItem++ @ "Enable Adjusted Damage", "eadjdam");
	if ($AllowLaserHeadKills == "true") 
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Disable Laser Headshot Kills", "dlashead");
		} else Client::addMenuItem(%clientId, %curItem++ @ "Enable Laser Headshot Kills", "elashead");

	return;
   }
   else if(%opt == "adminscore")
   {
	%curItem = 0;
	Client::buildMenu(%clientId, "SCORING OPTIONS", "newoptions", true);
	if($UseAdjustedScoring == "true") 
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Disable Adjusted Scoring", "dadjscore");
			if ($ShowScoreBonuses == "true") Client::addMenuItem(%clientId, %curItem++ @ "Hide Score Bonuses", "bonoff");
				else Client::addMenuItem(%clientId, %curItem++ @ "Show Score Bonuses", "bonon");

		} else Client::addMenuItem(%clientId, %curItem++ @ "Enable Adjusted Scoring", "eadjscore");
	return;
   }
   else if(%opt == "adminstation")
   {
	%curItem = 0;
	Client::buildMenu(%clientId, "STATION EJECT OPTIONS", "newoptions", true);
	if ($UseStationEject == "true") 
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Disable Station Timer", "stationoff");
			Client::addMenuItem(%clientId, %curItem++ @ "Station Time Limit", "stationtimelimit");
			Client::addMenuItem(%clientId, %curItem++ @ "Station Ban Time", "stationbantime");
		} else Client::addMenuItem(%clientId, %curItem++ @ "Enable Station Timer", "stationon");

	return;
   }
   else if(%opt == "admintk")
   {
	%curItem = 0;
	Client::buildMenu(%clientId, "TEAM-KILLER OPTIONS", "newoptions", true);
	if ($UseTKEffect == "true") 
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Disable TK Effect", "tkeffectoff");
			Client::addMenuItem(%clientId, %curItem++ @ "TK Kill Limit", "tkkilllimit");
			Client::addMenuItem(%clientId, %curItem++ @ "TK Effect Time", "tkeffecttime");
		} else Client::addMenuItem(%clientId, %curItem++ @ "Enable TK Effect", "tkeffecton");

	return;
   }
   else if(%opt == "tkkilllimit")
   {
      Client::buildMenu(%clientId, "TK KILL LIMIT:", "hctkkilllimit", true);
      Client::addMenuItem(%clientId, "11 Kill", 1);
      Client::addMenuItem(%clientId, "22 Kills", 2);
      Client::addMenuItem(%clientId, "33 Kills", 3);
      Client::addMenuItem(%clientId, "44 Kills", 4);
      Client::addMenuItem(%clientId, "55 Kills", 5);
      Client::addMenuItem(%clientId, "66 Kills", 6);
      Client::addMenuItem(%clientId, "77 Kills", 7);
      Client::addMenuItem(%clientId, "810 Kills", 10);
      return;
   }
   else if(%opt == "tkeffecttime")
   {
      Client::buildMenu(%clientId, "TK EFFECT TIME:", "hctktimelimit", true);
      Client::addMenuItem(%clientId, "110 Seconds", 10);
      Client::addMenuItem(%clientId, "220 Seconds", 20);
      Client::addMenuItem(%clientId, "330 Seconds", 30);
      Client::addMenuItem(%clientId, "440 Seconds", 40);
      Client::addMenuItem(%clientId, "550 Seconds", 50);
      Client::addMenuItem(%clientId, "660 Seconds", 60);
      Client::addMenuItem(%clientId, "790 Seconds", 90);
      Client::addMenuItem(%clientId, "8120 Seconds", 120);
      return;
   }
   else if(%opt == "elashead")
   {
	$AllowLaserHeadKills = "true";
      messageAll(0, Client::getName(%clientId) @ " allowed laser weapons to kill with a head shot.");
	bottomprint(%clientId,"<jc><f2>Server now allows laser head shots to kill.", 5);	
	return;
   }
   else if(%opt == "dlashead")
   {
	$AllowLaserHeadKills = "false";
      messageAll(0, Client::getName(%clientId) @ " disallowed laser weapons from killing with a head shot.");
	bottomprint(%clientId,"<jc><f2>Server now does not allow laser head shots to kill.", 5);	
	return;
   }

   else if(%opt == "tkeffecton")
   {
	$UseTKEffect = "true";
      messageAll(0, Client::getName(%clientId) @ " enabled HARD CORPS special Team-Killer effects.");
	bottomprint(%clientId,"<jc><f2>Server enabled HARD CORPS special Team-Killer effects.", 5);	
	return;
   }
   else if(%opt == "tkeffectoff")
   {
	$UseTKEffect = "false";
      messageAll(0, Client::getName(%clientId) @ " disabled HARD CORPS special Team-Killer effects.");
	bottomprint(%clientId,"<jc><f2>Server disabled HARD CORPS special Team-Killer effects.", 5);	
	return;
   }
   else if(%opt == "dweapnameon")
   {
	$DefaultShowWeaponNames = "true";
	bottomprint(%clientId,"<jc><f2>Showing Weapon Names set as Server Default.", 5);	
	return;
   }
   else if(%opt == "dweapnameoff")
   {
	$DefaultShowWeaponNames = "false";
	bottomprint(%clientId,"<jc><f2>Hiding Weapon Names set as Server Default.", 5);	
	return;
   }
   else if(%opt == "damagescale")
   {
      Client::buildMenu(%clientId, "DAMAGE SCALE:", "damscale", true);
      Client::addMenuItem(%clientId, "1Very Low", 25);
      Client::addMenuItem(%clientId, "2Low", 50);
      Client::addMenuItem(%clientId, "3Moderately Low", 75);
      Client::addMenuItem(%clientId, "4Normal Damage", 100);
      Client::addMenuItem(%clientId, "5Moderately High", 125);
      Client::addMenuItem(%clientId, "6High", 150);
      Client::addMenuItem(%clientId, "7Very High", 175);
      Client::addMenuItem(%clientId, "8Disable Damage", 0);
      return;
   }
   else if(%opt == "eadjdam")
   {
	$UseAdjustedDamageScale = "true";
      messageAll(0, Client::getName(%clientId) @ " enabled HARD CORPS Adjusted Damage Scale.");
	bottomprint(%clientId,"<jc><f2>Server enabled HARD CORPS Adjusted Damage Scale\n\nNew options available in Damage Options Menu.", 5);	
	return;
   }
   else if(%opt == "dadjdam")
   {
	$UseAdjustedDamageScale = "false";
      messageAll(0, Client::getName(%clientId) @ " disabled HARD CORPS Adjusted Damage Scale.");
	bottomprint(%clientId,"<jc><f2>Server disabled HARD CORPS Adjusted Damage Scale.\n\nSome options disabled in Damage Options Menu.", 5);	
	return;
   }
   else if(%opt == "stationon")
   {
	$UseStationEject = "true";
	bottomprint(%clientId,"<jc><f2>Station Time Limit Enabled.", 5);	
	return;
   }
   else if(%opt == "stationoff")
   {
	$UseStationEject = "false";
	bottomprint(%clientId,"<jc><f2>Station Time Limit Disabled.", 5);	
	return;
   }
   else if(%opt == "stationtimelimit")
   {
      Client::buildMenu(%clientId, "STATION TIME LIMIT:", "hcstationtimelimit", true);
      Client::addMenuItem(%clientId, "110 Seconds", 10);
      Client::addMenuItem(%clientId, "220 Seconds", 20);
      Client::addMenuItem(%clientId, "330 Seconds", 30);
      Client::addMenuItem(%clientId, "440 Seconds", 40);
      Client::addMenuItem(%clientId, "550 Seconds", 50);
      Client::addMenuItem(%clientId, "660 Seconds", 60);
      Client::addMenuItem(%clientId, "790 Seconds", 90);
      Client::addMenuItem(%clientId, "8120 Seconds", 120);
      return;
   }
   else if(%opt == "stationbantime")
   {
      Client::buildMenu(%clientId, "STATION BAN TIME:", "hcstationbantime", true);
      Client::addMenuItem(%clientId, "110 Seconds", 10);
      Client::addMenuItem(%clientId, "220 Seconds", 20);
      Client::addMenuItem(%clientId, "330 Seconds", 30);
      Client::addMenuItem(%clientId, "440 Seconds", 40);
      Client::addMenuItem(%clientId, "550 Seconds", 50);
      Client::addMenuItem(%clientId, "660 Seconds", 60);
      Client::addMenuItem(%clientId, "790 Seconds", 90);
      Client::addMenuItem(%clientId, "8120 Seconds", 120);
      return;
   }
   else if(%opt == "bonon")
   {
	$ShowScoreBonuses = "true";
	bottomprint(%clientId,"<jc><f2>Now showing Score Bonuses.", 5);	
	return;
   }
   else if(%opt == "bonoff")
   {
	$ShowScoreBonuses = "false";
	bottomprint(%clientId,"<jc><f2>Now hiding Score Bonuses.", 5);	
	return;
   }
   else if(%opt == "emiss")
   {
	$LeaveMissionAreaDamage = "true";
	bottomprint(%clientId,"<jc><f2>Players now take damage when staying outside the mission area.", 5);	
      messageAll(0, Client::getName(%clientId) @ " enabled HARD CORPS out of mission area damage.");
	return;
   }
   else if(%opt == "dmiss")
   {
	$LeaveMissionAreaDamage = "false";
	bottomprint(%clientId,"<jc><f2>Players no longer take damage when staying outside the mission area.", 5);	
      messageAll(0, Client::getName(%clientId) @ " disabled HARD CORPS out of mission area damage.");
	return;
   }
   else if(%opt == "allowequip")
   {
	%curItem = 0;
	Client::buildMenu(%clientId, "ALLOWED EQUIPMENT", "neweroptions", true);
	Client::addMenuItem(%clientId, %curItem++ @ "BackPacks", "allowbackpack");
	Client::addMenuItem(%clientId, %curItem++ @ "Deployables", "allowdeployables");
	Client::addMenuItem(%clientId, %curItem++ @ "Miscellaneous", "allowmiscellaneous");
	Client::addMenuItem(%clientId, %curItem++ @ "Vehicles", "allowvehicles");
	Client::addMenuItem(%clientId, %curItem++ @ "Weapons", "allowweap");
	return;
   }
   else if(%opt == "weapstaton")
   {
	%clientId.weaponstats = "true";
	bottomprint(%clientId,"<jc><f2>Showing Weapon Statistics.", 5);	
	return;
   }
   else if(%opt == "weapstatoff")
   {
	%clientId.weaponstats = "false";
	bottomprint(%clientId,"<jc><f2>Hiding Weapon Statistics.", 5);	
	return;
   }
   else if(%opt == "dweapstaton")
   {
	$DefaultShowWeaponStats = "true";
	bottomprint(%clientId,"<jc><f2>Showing Weapon Statistics set as Server Default.", 5);	
	return;
   }
   else if(%opt == "eadjscore")
   {
	$UseAdjustedScoring = "true";
      messageAll(0, Client::getName(%clientId) @ " enabled HARD CORPS Adjusted Scoring System.");
	bottomprint(%clientId,"<jc><f2>Server enabled HARD CORPS Adjusted Scoring System\n\nNew options available in Special Options Menu.", 5);	
	return;
   }
   else if(%opt == "dadjscore")
   {
	$UseAdjustedScoring = "false";
      messageAll(0, Client::getName(%clientId) @ " disabled HARD CORPS Adjusted Scoring System.");
	bottomprint(%clientId,"<jc><f2>Server disabled HARD CORPS Adjusted Scoring System\n\nSome options disabled in Special Options Menu.", 5);	
	return;
   }
   else if(%opt == "dweapstatoff")
   {
	$DefaultShowWeaponStats = "false";
	bottomprint(%clientId,"<jc><f2>Hiding Weapon Statistics set as Server Default.", 5);	
	return;
   }
   Game::menuRequest(%clientId);
}

function remoteSetStationLimit(%client, %opt)
{
   %time = floor(%opt);
   if(%opt == $StationEjectTime || (%opt != 0 && %opt < 1))
      return;

   if(%client.isAdmin)
   {
      $StationEjectTime = %opt;
      if(%opt)
         messageAll(0, Client::getName(%client) @ " changed the Station Time Limit to " @ %opt @ " seconds.");
      else
         messageAll(0, Client::getName(%client) @ " changed the Station Time Limit to !!!.");
         
   }
}

function processMenuNewerOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   %nopt = getWord(%option, 2);
   // PORT: a player may only reach his own Spawn Equipment pages and the mission list here; the rest
   // (stand-off settings, the Allowed Equipment pages and 'allowstuff') is admin only.
   if(!%clientId.isAdmin && %opt != "spawnslot" && %opt != "mspawnslot" && %opt != "sslot" && %opt != "cmission")
   {
      Game::menuRequest(%clientId);
      return;
   }

    if(%opt == "spawnslot")
      {
	%curItem = 0;
	Client::buildMenu(%clientId, "SPAWN EQUIPMENT", "neweroptions", true);

	if ($HC::AllowableEquipment[Blaster] == 1) Client::addMenuItem(%clientId, %curItem++ @ "Blaster", "sslot " @ Blaster @ " " @ %cl);
	if ($HC::AllowableEquipment[PlasmaGun] == 1) Client::addMenuItem(%clientId, %curItem++ @ "Plasma Gun", "sslot " @ PlasmaGun @ " " @ %cl);
	if ($HC::AllowableEquipment[Chaingun] == 1) Client::addMenuItem(%clientId, %curItem++ @ "Chaingun", "sslot " @ Chaingun @ " " @ %cl);
	if ($HC::AllowableEquipment[Disclauncher] == 1) Client::addMenuItem(%clientId, %curItem++ @ "Disc Launcher", "sslot " @ Disclauncher @ " " @ %cl);
	if ($HC::AllowableEquipment[GrenadeLauncher] == 1) Client::addMenuItem(%clientId, %curItem++ @ "Grenade Launcher", "sslot " @ GrenadeLauncher @ " " @ %cl);
	if ($HC::AllowableEquipment[LaserRifle] == 1) Client::addMenuItem(%clientId, %curItem++ @ "Laser Rifle", "sslot " @ LaserRifle @ " " @ %cl);
	if ($HC::AllowableEquipment[EnergyRifle] == 1) Client::addMenuItem(%clientId, %curItem++ @ "ELF Gun", "sslot " @ EnergyRifle @ " " @ %cl);
	Client::addMenuItem(%clientId, %curItem++ @ "More Equipment", "mspawnslot " @ %cl);
	return;
   }
   else if(%opt == "cmission")
   {
	%first = getWord(%options, 1);

	Client::buildMenu(%clientId, "SELECT MISSION TYPE", "cmtype", true);
	%index = 0;

	   if ($MList::TypeCount < 2) $TypeStart = 0; else $TypeStart = 1;
   
	   for(%i = $TypeStart; %i < $MLIST::TypeCount; %i++)
	   {
		if ($MLIST::Type[%i] != "Training")
	      	{
         			%index++;
				if (%index <= 7)
					{
		      	   		Client::addMenuItem(%clientId, %index @ $MLIST::Type[%i], %i @ " 0");
					} else
					{
						Client::addMenuItem(%clientId, %index @ "More Mission Types...", "more " @ %i);
						break;
					}
	      	}

	   }

      return;
   }
   else if(%opt == "ereqd")
	{
	      Admin::setStandoffsEnable(%clientId, false);
		return;
	}
   else if(%opt == "dreqd")
	{
	      Admin::setStandoffsEnable(%clientId, true);
		return;
	}
   else if(%opt == "standlimit")
   {
      Client::buildMenu(%clientId, "STANDOFF TIME:", "standoff", true);
      Client::addMenuItem(%clientId, "130 Seconds", 30);
      Client::addMenuItem(%clientId, "260 Seconds", 60);
      Client::addMenuItem(%clientId, "3120 Seconds", 120);
      Client::addMenuItem(%clientId, "4300 Seconds", 300);
      Client::addMenuItem(%clientId, "5600 Seconds", 600);
      Client::addMenuItem(%clientId, "6900 Seconds", 900);
      Client::addMenuItem(%clientId, "7Instantaneous", 0);
      return;
   }
   else if(%opt == "suddenlimit")
   {
      Client::buildMenu(%clientId, "SUDDEN DEATH TIME:", "sudden", true);
      Client::addMenuItem(%clientId, "130 Seconds", 30);
      Client::addMenuItem(%clientId, "260 Seconds", 60);
      Client::addMenuItem(%clientId, "3120 Seconds", 120);
      Client::addMenuItem(%clientId, "4300 Seconds", 300);
      Client::addMenuItem(%clientId, "5600 Seconds", 600);
      Client::addMenuItem(%clientId, "6900 Seconds", 900);
      return;
   }
   else if(%opt == "mspawnslot")
      {
	%curItem = 0;
	Client::buildMenu(%clientId, "SPAWN EQUIPMENT", "neweroptions", true);

	if ($HC::AllowableEquipment[EMPulsegun] == 1) Client::addMenuItem(%clientId, %curItem++ @ "EM Pulse Gun", "sslot " @ EMPulsegun @ " " @ %cl);
	if ($HC::AllowableEquipment[AmmoPack] == 1) Client::addMenuItem(%clientId, %curItem++ @ "Ammo Pack", "sslot " @ AmmoPack @ " " @ %cl);
	if ($HC::AllowableEquipment[DecoyFlagPack] == 1) Client::addMenuItem(%clientId, %curItem++ @ "Decoy Flag Pack", "sslot " @ DecoyFlagPack @ " " @ %cl);
	if ($HC::AllowableEquipment[EnergyPack] == 1) Client::addMenuItem(%clientId, %curItem++ @ "Energy Pack", "sslot " @ EnergyPack @ " " @ %cl);
		if ($HC::AllowableEquipment[PowerPack] == 1) Client::addMenuItem(%clientId, %curItem++ @ "Power Generator Pack", "sslot " @ PowerPack @ " " @ %cl);
	if ($HC::AllowableEquipment[RepairPack] == 1) Client::addMenuItem(%clientId, %curItem++ @ "Repair Pack", "sslot " @ RepairPack @ " " @ %cl);
	if ($HC::AllowableEquipment[SensorJammerPack] == 1) Client::addMenuItem(%clientId, %curItem++ @ "Sensor Jammer Pack", "sslot " @ SensorJammerPack @ " " @ %cl);
		if ($HC::AllowableEquipment[ShieldPack] == 1) Client::addMenuItem(%clientId, %curItem++ @ "Shield Pack", "sslot " @ ShieldPack @ " " @ %cl);
	return;
   }
   else if (%opt == "sslot")
	{
		// PORT: the item name comes from the client. Only what the two Spawn Equipment pages list, and only
		// while the server allows it (the pages test $HC::AllowableEquipment before listing an item).
		if (%cl != Blaster && %cl != PlasmaGun && %cl != Chaingun && %cl != Disclauncher && %cl != GrenadeLauncher && %cl != LaserRifle && %cl != EnergyRifle && %cl != EMPulsegun && %cl != AmmoPack && %cl != DecoyFlagPack && %cl != EnergyPack && %cl != PowerPack && %cl != RepairPack && %cl != SensorJammerPack && %cl != ShieldPack) return;
		if ($HC::AllowableEquipment[%cl] != 1) return;
		if (%nopt == "SlotA" && %clientId.slotb != %cl && %clientId.slotc != %cl) 
			{
				if (%cl.className != Backpack)
					{
						bottomprint(%clientId,"<jc><f2>Switching Equipment Slot 1 to " @ %cl.description @ ".", 2);	
						%clientId.slota = %cl;
					} else
					{
						if (%clientId.slotb.className != Backpack && %clientId.slotc.className != Backpack)
							{
								bottomprint(%clientId,"<jc><f2>Switching Equipment Slot 1 to " @ %cl.description @ ".", 2);	
								%clientId.slota = %cl;
							}
					}
			}
		if (%nopt == "SlotB" && %clientId.slota != %cl && %clientId.slotc != %cl) 
			{
				if (%cl.className != Backpack)
					{
						bottomprint(%clientId,"<jc><f2>Switching Equipment Slot 2 to " @ %cl.description @ ".", 2);	
						%clientId.slotb = %cl;
					} else
					{
						if (%clientId.slota.className != Backpack && %clientId.slotc.className != Backpack)
							{
								bottomprint(%clientId,"<jc><f2>Switching Equipment Slot 2 to " @ %cl.description @ ".", 2);	
								%clientId.slotb = %cl;
							}
					}
			}
		if (%nopt == "SlotC" && %clientId.slotb != %cl && %clientId.slota != %cl) 
			{
				if (%cl.className != Backpack)
					{
						bottomprint(%clientId,"<jc><f2>Switching Equipment Slot 3 to " @ %cl.description @ ".", 2);	
						%clientId.slotc = %cl;
					} else
					{
						if (%clientId.slotb.className != Backpack && %clientId.slota.className != Backpack)
							{
								bottomprint(%clientId,"<jc><f2>Switching Equipment Slot 3 to " @ %cl.description @ ".", 2);	
								%clientId.slotc = %cl;
							}
					}
			}
		return;
	}
   else if(%opt == "allowbackpack")
   {
	%curItem = 0;
	Client::buildMenu(%clientId, "ALLOWED BACKPACKS", "neweroptions", true);

	if($HC::AllowableEquipment[AmmoPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Ammo Pack", "allowstuff " @ AmmoPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Ammo Pack", "allowstuff " @ AmmoPack @ " 1");

	if($HC::AllowableEquipment[DecoyFlagPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Decoy Flag Pack", "allowstuff " @ DecoyFlagPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Decoy Flag Pack", "allowstuff " @ DecoyFlagPack @ " 1");

	if($HC::AllowableEquipment[EnergyPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Energy Pack", "allowstuff " @ EnergyPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Energy Pack", "allowstuff " @ EnergyPack @ " 1");

	if($HC::AllowableEquipment[ForceFieldPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Force Field Pack", "allowstuff " @ ForceFieldPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Force Field Pack", "allowstuff " @ ForceFieldPack @ " 1");

	if($HC::AllowableEquipment[PowerPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Power Pack", "allowstuff " @ PowerPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Power Pack", "allowstuff " @ PowerPack @ " 1");

	if($HC::AllowableEquipment[RepairPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Repair Pack", "allowstuff " @ RepairPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Repair Pack", "allowstuff " @ RepairPack @ " 1");

	if($HC::AllowableEquipment[SensorJammerPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Sensor Jammer Pack", "allowstuff " @ SensorJammerPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Sensor Jammer Pack", "allowstuff " @ SensorJammerPack @ " 1");

	if($HC::AllowableEquipment[ShieldPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Shield Pack", "allowstuff " @ ShieldPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Shield Pack", "allowstuff " @ ShieldPack @ " 1");
	return;
   }
   else if(%opt == "allowweap")
   {
	%curItem = 0;
	Client::buildMenu(%clientId, "ALLOWED WEAPONS", "neweroptions", true);

	if($HC::AllowableEquipment[Blaster] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Blaster", "allowstuff " @ Blaster @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Blaster", "allowstuff " @ Blaster @ " 1");

	if($HC::AllowableEquipment[PlasmaGun] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Plasma Gun", "allowstuff " @ PlasmaGun @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Plasma Gun", "allowstuff " @ PlasmaGun @ " 1");

	if($HC::AllowableEquipment[Chaingun] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Chaingun", "allowstuff " @ Chaingun @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Chaingun", "allowstuff " @ Chaingun @ " 1");

	if($HC::AllowableEquipment[Disclauncher] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Disc Launcher", "allowstuff " @ Disclauncher @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Disc Launcher", "allowstuff " @ Disclauncher @ " 1");

	if($HC::AllowableEquipment[GrenadeLauncher] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Grenade Launcher", "allowstuff " @ GrenadeLauncher @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Grenade Launcher", "allowstuff " @ GrenadeLauncher @ " 1");

	if($HC::AllowableEquipment[LaserRifle] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Laser Rifle", "allowstuff " @ LaserRifle @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Laser Rifle", "allowstuff " @ LaserRifle @ " 1");

	if($HC::AllowableEquipment[EnergyRifle] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable ELF Gun", "allowstuff " @ EnergyRifle @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable ELF Gun", "allowstuff " @ EnergyRifle @ " 1");

	Client::addMenuItem(%clientId, %curItem++ @ "More Options", "mallowweap");
	return;
   }
  else if(%opt == "mallowweap")
      {
	%curItem = 0;
	Client::buildMenu(%clientId, "ALLOWED WEAPONS", "neweroptions", true);
	if($HC::AllowableEquipment[Mortar] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Mortar", "allowstuff " @ Mortar @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Mortar", "allowstuff " @ Mortar @ " 1");

	if($HC::AllowableEquipment[EMPulsegun] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable EM Pulse Gun", "allowstuff " @ EMPulsegun @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable EM Pulse Gun", "allowstuff " @ EMPulsegun @ " 1");

	if($HC::AllowableEquipment[Clustergun] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Cluster Gun", "allowstuff " @ Clustergun @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Cluster Gun", "allowstuff " @ Clustergun @ " 1");

	return;
   }
  else if(%opt == "allowmiscellaneous")
  {
	%curItem = 0;
	Client::buildMenu(%clientId, "ALLOWED MISCELLANEOUS", "neweroptions", true);

	if($HC::AllowableEquipment[Beacon] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Beacons", "allowstuff " @ Beacon @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Beacons", "allowstuff " @ Beacon @ " 1");

	if($HC::AllowableEquipment[Grenade] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Grenades", "allowstuff " @ Grenade @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Grenades", "allowstuff " @ Grenade @ " 1");

	if($HC::AllowableEquipment[MineAmmo] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Mines", "allowstuff " @ MineAmmo @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Mines", "allowstuff " @ MineAmmo @ " 1");

	if($HC::AllowableEquipment[RepairKit] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Repair Kits", "allowstuff " @ RepairKit @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Repair Kits", "allowstuff " @ RepairKit @ " 1");

	if($HC::AllowableEquipment[TargetingLaser] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Targeting Lasers", "allowstuff " @ TargetingLaser @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Targeting Lasers", "allowstuff " @ TargetingLaser @ " 1");
	return;
  }
  else if(%opt == "allowdeployables")
  {
	%curItem = 0;
	Client::buildMenu(%clientId, "ALLOWED DEPLOYABLES", "neweroptions", true);

	if($HC::AllowableEquipment[AATurretPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Anti-Air Turrets", "allowstuff " @ AATurretPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Anti-Air Turrets", "allowstuff " @ AATurretPack @ " 1");

	if($HC::AllowableEquipment[DeployableAmmoPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Dep. Ammo Stations", "allowstuff " @ DeployableAmmoPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Dep. Ammo Stations", "allowstuff " @ DeployableAmmoPack @ " 1");

	if($HC::AllowableEquipment[DeployableInvPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Dep. Inv. Stations", "allowstuff " @ DeployableInvPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Dep. Inv. Stations", "allowstuff " @ DeployableInvPack @ " 1");

	if($HC::AllowableEquipment[GravityPadPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Gravity Pads", "allowstuff " @ GravityPadPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Gravity Pads", "allowstuff " @ GravityPadPack @ " 1");

	if($HC::AllowableEquipment[HeavyTurretPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Heavy Turrets", "allowstuff " @ HeavyTurretPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Heavy Turrets", "allowstuff " @ HeavyTurretPack @ " 1");

	if($HC::AllowableEquipment[ImpulseTurretPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Impulse Turrets", "allowstuff " @ ImpulseTurretPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Impulse Turrets", "allowstuff " @ ImpulseTurretPack @ " 1");

	if($HC::AllowableEquipment[MotionSensorPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Motion Sensors", "allowstuff " @ MotionSensorPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Motion Sensors", "allowstuff " @ MotionSensorPack @ " 1");

	Client::addMenuItem(%clientId, %curItem++ @ "More Options", "mallowdeployables");
	return;
  }
  else if(%opt == "mallowdeployables")
  {
	%curItem = 0;
	Client::buildMenu(%clientId, "ALLOWED DEPLOYABLES", "neweroptions", true);

	if($HC::AllowableEquipment[PointDefencePack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Point Defence Turrets", "allowstuff " @ PointDefencePack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Point Defence Turrets", "allowstuff " @ PointDefencePack @ " 1");

	if($HC::AllowableEquipment[ProximityAlarmPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Prox. Alarms", "allowstuff " @ ProximityAlarmPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Prox. Alarms", "allowstuff " @ ProximityAlarmPack @ " 1");

	if($HC::AllowableEquipment[PulseSensorPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Pulse Sensors", "allowstuff " @ PulseSensorPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Pulse Sensors", "allowstuff " @ PulseSensorPack @ " 1");

	if($HC::AllowableEquipment[CameraPack] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Remote Cameras", "allowstuff " @ CameraPack @ " 0");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Remote Cameras", "allowstuff " @ CameraPack @ " 1");

	return;
  }

  else if(%opt == "allowvehicles")
  {
	%curItem = 0;
	Client::buildMenu(%clientId, "ALLOWED VEHICLES", "neweroptions", true);

	if($HC::AllowableEquipment[ScoutVehicle] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Fighters", "allowstuff " @ ScoutVehicle @ " 2");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Fighters", "allowstuff " @ ScoutVehicle @ " 3");

	if($HC::AllowableEquipment[LAPCVehicle] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Light Carriers", "allowstuff " @ LAPCVehicle @ " 2");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Light Carriers", "allowstuff " @ LAPCVehicle @ " 3");

	if($HC::AllowableEquipment[HAPCVehicle] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Heavy Carriers", "allowstuff " @ HAPCVehicle @ " 2");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Heavy Carriers", "allowstuff " @ HAPCVehicle @ " 3");

	if($HC::AllowableEquipment[RotaryChaingun] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Rotary Cannon", "allowstuff " @ RotaryChaingun @ " 2");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Rotary Cannon", "allowstuff " @ RotaryChaingun @ " 3");

	if($HC::AllowableEquipment[VehicleRocket] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Unguided Rocket", "allowstuff " @ VehicleRocket @ " 2");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Unguided Rocket", "allowstuff " @ VehicleRocket @ " 3");

	if($HC::AllowableEquipment[NapalmLauncher] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Napalm Launcher", "allowstuff " @ NapalmLauncher @ " 2");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Napalm Launcher", "allowstuff " @ NapalmLauncher @ " 3");

	if($HC::AllowableEquipment[VehicleEMPLauncher] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable EMP Launcher", "allowstuff " @ VehicleEMPLauncher @ " 2");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable EMP Launcher", "allowstuff " @ VehicleEMPLauncher @ " 3");

	Client::addMenuItem(%clientId, %curItem++ @ "More Options", "mallowvehicles");
	return;
  }
  else if(%opt == "mallowvehicles")
      {
	%curItem = 0;
	Client::buildMenu(%clientId, "ALLOWED VEHICLES", "neweroptions", true);

	if($HC::AllowableEquipment[VehicleClusterCannon] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Cluster Cannon", "allowstuff " @ VehicleClusterCannon @ " 2");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Cluster Cannon", "allowstuff " @ VehicleClusterCannon @ " 3");

	if($HC::AllowableEquipment[VehicleBomb] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable HEAP Bomb", "allowstuff " @ VehicleBomb @ " 2");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable HEAP Bomb", "allowstuff " @ VehicleBomb @ " 3");

	if($HC::AllowableEquipment[AmmoModule] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Ammo Module", "allowstuff " @ AmmoModule @ " 2");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Ammo Module", "allowstuff " @ AmmoModule @ " 3");

	if($HC::AllowableEquipment[RepairModule] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Repair Module", "allowstuff " @ RepairModule @ " 2");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Repair Module", "allowstuff " @ RepairModule @ " 3");

	if($HC::AllowableEquipment[ShieldModule] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Shield Module", "allowstuff " @ ShieldModule @ " 2");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Shield Module", "allowstuff " @ ShieldModule @ " 3");

	if($HC::AllowableEquipment[SpeedModule] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Speed Module", "allowstuff " @ SpeedModule @ " 2");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Speed Module", "allowstuff " @ SpeedModule @ " 3");

	if($HC::AllowableEquipment[StealthModule] == 1) 
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Stealth Module", "allowstuff " @ StealthModule @ " 2");
		      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Stealth Module", "allowstuff " @ StealthModule @ " 3");

	return;
   }

  else if(%opt == "allowstuff")
   {
	if (%nopt <=1)
		{
			$InvList[%cl] = %nopt;
			$RemoteInvList[%cl] = %nopt;
			if(%cl == HeavyTurretPack || %cl == AATurretPack || %cl == DeployableInvPack || %cl == DeployableAmmoPack)
				{
					$RemoteInvList[%cl] = 0;
				}
			if (%cl.imageType.ammoType != "")
				{
					$InvList[%cl.imageType.ammoType] = %nopt;
					$RemoteInvList[%cl.imageType.ammoType] = %nopt;
				}
			if (%nopt == 1) %werg = "enabled"; else %werg = "disabled";
		} else
		{
			if (%nopt == 3) $VehicleInvList[%cl] = 1; else $VehicleInvList[%cl] = 0;
			if (%nopt == 3) %werg = "enabled"; else %werg = "disabled";
		}


	$HC::AllowableEquipment[%cl] = (%nopt == 1 || %nopt == 3); // PORT: was %nopt (2 / 3 for vehicles; the menus test == 1)
      messageAll(0, Client::getName(%clientId) @ " " @ %werg @ " " @ %cl.description @ ".");
	bottomprint(%clientId,"<jc><f2>Server " @ %werg @ " " @ %cl.description @ ".", 5);	
	return;
   }
   Game::menuRequest(%clientId);
}

function processMenuMostNewOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   %nopt = getWord(%option, 2);

	if (%opt == "hchelp")
		{
			%curItem = 0;
			Client::buildMenu(%clientId, "HARD CORPS HELP", "mostnewoptions", true);

			if (%cl == "accesslevels")
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Standard Player", "accesslevels StandardPlayer");
					Client::addMenuItem(%clientId, %curItem++ @ "Regular User", "accesslevels RegularUser");
					Client::addMenuItem(%clientId, %curItem++ @ "Admin", "accesslevels Admin");
					Client::addMenuItem(%clientId, %curItem++ @ "Super Admin", "accesslevels SuperAdmin");
					Client::addMenuItem(%clientId, %curItem++ @ "Game Host", "accesslevels GameHost");
				}
			if (%cl == "armours")
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Light Armour", "describe " @ LightArmor);
					Client::addMenuItem(%clientId, %curItem++ @ "Medium Armour", "describe " @ MediumArmor);
					Client::addMenuItem(%clientId, %curItem++ @ "Heavy Armour", "describe " @ HeavyArmor);
				}
			if (%cl == "backpacks")
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Ammo Pack", "describe " @ AmmoPack);
					Client::addMenuItem(%clientId, %curItem++ @ "Decoy Flag Pack", "describe " @ DecoyFlagPack);
					Client::addMenuItem(%clientId, %curItem++ @ "Energy Pack", "describe " @ EnergyPack);
					Client::addMenuItem(%clientId, %curItem++ @ "Force Field Pack", "describe " @ ForceFieldPack);
					Client::addMenuItem(%clientId, %curItem++ @ "Power Gen. Pack", "describe " @ PowerPack);
					Client::addMenuItem(%clientId, %curItem++ @ "Repair Pack", "describe " @ RepairPack);
					Client::addMenuItem(%clientId, %curItem++ @ "Sensor Jammer Pack", "describe " @ SensorJammerPack);
					Client::addMenuItem(%clientId, %curItem++ @ "Shield Pack", "describe " @ ShieldPack);
				}
			if (%cl == "deployables")
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Anti-Air Turrets", "describe " @ AATurretPack);
					Client::addMenuItem(%clientId, %curItem++ @ "Dep. Ammo Stations", "describe " @ DeployableAmmoPack);
					Client::addMenuItem(%clientId, %curItem++ @ "Dep. Inv. Stations", "describe " @ DeployableInvPack);
					Client::addMenuItem(%clientId, %curItem++ @ "Gravity Pads", "describe " @ GravityPadPack);
					Client::addMenuItem(%clientId, %curItem++ @ "Heavy Turrets", "describe " @ HeavyTurretPack);
					Client::addMenuItem(%clientId, %curItem++ @ "Impulse Turrets", "describe " @ ImpulseTurretPack);
					Client::addMenuItem(%clientId, %curItem++ @ "Laser Motion Sensors", "describe " @ MotionSensorPack);
					Client::addMenuItem(%clientId, %curItem++ @ "More Options...", "hchelp mdeployables");
				}
			if (%cl == "mdeployables")
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Point Defence Turrets", "describe " @ PointDefencePack);
					Client::addMenuItem(%clientId, %curItem++ @ "Proximity Alarms", "describe " @ ProximityAlarmPack);
					Client::addMenuItem(%clientId, %curItem++ @ "Pulse Sensors", "describe " @ PulseSensorPack);
					Client::addMenuItem(%clientId, %curItem++ @ "Remote Cameras", "describe " @ CameraPack);
				}

			if (%cl == "miscellaneous")
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Beacons", "describe " @ Beacon);
					Client::addMenuItem(%clientId, %curItem++ @ "Grenades", "describe " @ Grenade);
					Client::addMenuItem(%clientId, %curItem++ @ "Mines", "describe " @ MineAmmo);
					Client::addMenuItem(%clientId, %curItem++ @ "Repair Kits", "describe " @ RepairKit);
					Client::addMenuItem(%clientId, %curItem++ @ "Targeting Lasers", "describe " @ TargetingLaser);
				}

			if (%cl == "vehicles")
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Vehicle Types", "hchelp vehicletypes");
					Client::addMenuItem(%clientId, %curItem++ @ "Vehicle Modules", "hchelp vehiclemodules");
					Client::addMenuItem(%clientId, %curItem++ @ "Vehicle Weapons", "hchelp vehicleweapons");
				}
			if (%cl == "vehicletypes")
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Fighters", "describe " @ ScoutVehicle);
					Client::addMenuItem(%clientId, %curItem++ @ "Light Carriers", "describe " @ LAPCVehicle);
					Client::addMenuItem(%clientId, %curItem++ @ "Heavy Carriers", "describe " @ HAPCVehicle);
				}
			if (%cl == "vehicleweapons")
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Cluster Cannons", "describe " @ VehicleClusterCannon);
					Client::addMenuItem(%clientId, %curItem++ @ "EMP Launchers", "describe " @ VehicleEMPLauncher);
					Client::addMenuItem(%clientId, %curItem++ @ "HEAP Bombs", "describe " @ VehicleBomb);
					Client::addMenuItem(%clientId, %curItem++ @ "Napalm Launchers", "describe " @ NapalmLauncher);
					Client::addMenuItem(%clientId, %curItem++ @ "Rotary Cannons", "describe " @ RotaryChaingun);
					Client::addMenuItem(%clientId, %curItem++ @ "Unguided Rockets", "describe " @ VehicleRocket);
				}
			if (%cl == "vehiclemodules")
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Ammo Modules", "describe " @ AmmoModule);
					Client::addMenuItem(%clientId, %curItem++ @ "Repair Modules", "describe " @ RepairModule);
					Client::addMenuItem(%clientId, %curItem++ @ "Shield Modules", "describe " @ ShieldModule);
					Client::addMenuItem(%clientId, %curItem++ @ "Speed Modules", "describe " @ SpeedModule);
					Client::addMenuItem(%clientId, %curItem++ @ "Stealth Modules", "describe " @ StealthModule);
				}
			if (%cl == "weapons")
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Blasters", "describe " @ Blaster);
					Client::addMenuItem(%clientId, %curItem++ @ "Plasma Guns", "describe " @ PlasmaGun);
					Client::addMenuItem(%clientId, %curItem++ @ "Chainguns", "describe " @ Chaingun);
					Client::addMenuItem(%clientId, %curItem++ @ "Disc Launchers", "describe " @ Disclauncher);
					Client::addMenuItem(%clientId, %curItem++ @ "Grenade Launchers", "describe " @ GrenadeLauncher);
					Client::addMenuItem(%clientId, %curItem++ @ "Laser Rifles", "describe " @ LaserRifle);
					Client::addMenuItem(%clientId, %curItem++ @ "ELF Guns", "describe " @ EnergyRifle);
					Client::addMenuItem(%clientId, %curItem++ @ "More Options...", "hchelp mweapons");
				}
			if (%cl == "mweapons")
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Mortars", "describe " @ Mortar);
					Client::addMenuItem(%clientId, %curItem++ @ "EM Pulse Guns", "describe " @ EMPulsegun);
					Client::addMenuItem(%clientId, %curItem++ @ "Cluster Guns", "describe " @ Clustergun);
				}

			return;
		}
	else if (%opt == "describe")
		{
			%item = %cl;
			bottomprint(%clientId,"<jc><f1>" @ %item.description @ "\n<f2>" @ $HC::EquipmentDescriptions[%item] @ "", 5);		
			return;			
		}
   Game::menuRequest(%clientId);
}

function remoteSetStationLimit(%client, %opt)
{
   %time = floor(%opt);
   if(%opt == $StationEjectTime || (%opt != 0 && %opt < 1))
      return;

   if(%client.isAdmin)
   {
      $StationEjectTime = %opt;
      if(%opt)
         messageAll(0, Client::getName(%client) @ " changed the Station Time Limit to " @ %opt @ " seconds.");
      else
         messageAll(0, Client::getName(%client) @ " changed the Station Time Limit to !!!.");
         
   }
}


function processMenuHCStationTimeLimit(%clientId, %opt)
{
   remoteSetStationLimit(%clientId, %opt);
}

function remoteSetStationBanLimit(%client, %opt)
{
   %time = floor(%opt);
   if(%opt == $StationOutTime || (%opt != 0 && %opt < 1))
      return;

   if(%client.isAdmin)
   {
      $StationOutTime = %opt;
      if(%opt)
         messageAll(0, Client::getName(%client) @ " changed the Station Ban Time to " @ %opt @ " seconds.");
      else
         messageAll(0, Client::getName(%client) @ " changed the Station Ban Time to !!!.");
         
   }
}

function processMenuHCStationBanTime(%clientId, %opt)
{
   remoteSetStationBanLimit(%clientId, %opt);
}

function remoteSetHCTKKillLimit(%client, %opt)
{
   %time = floor(%opt);
   if(%opt == $TKwarnlimit || (%opt != 0 && %opt < 1))
      return;

   if(%client.isAdmin)
   {
      $TKwarnlimit = %opt;
      if(%opt)
         messageAll(0, Client::getName(%client) @ " changed the Team-Killer status to be enabled at " @ %opt @ " kills.");
      else
         messageAll(0, Client::getName(%client) @ "!!!.");
         
   }
}

function processMenuHCTKKillLimit(%clientId, %opt)
{
   remoteSetHCTKKillLimit(%clientId, %opt);
}

function remoteSetHCTKTimeLimit(%client, %opt)
{
   %time = floor(%opt);
   if(%opt == $TKTimeOut || (%opt != 0 && %opt < 1))
      return;

   if(%client.isAdmin)
   {
      $TKTimeOut = %opt;
      if(%opt)
         messageAll(0, Client::getName(%client) @ " changed the Team-Killer time out to " @ %opt @ " seconds.");
      else
         messageAll(0, Client::getName(%client) @ "!!!.");
         
   }
}

function processMenuHCTKTimeLimit(%clientId, %opt)
{
   remoteSetHCTKTimeLimit(%clientId, %opt);
}


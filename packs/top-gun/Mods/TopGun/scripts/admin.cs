$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

function Admin::changeMissionMenu(%clientId)
{
	%type = 0;
	while((%type < $MLIST::TypeCount) && (getWord($MLIST::Type[%type], 0) != "DELTA")) %type++;
	Client::buildMenu(%clientId, "Pick Mission", "cmission", true);
	for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%type], %i)) != -1; %i++) {
      if(%i > 6)
      {
         Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %i @ " " @ %type);
         break;
      }
	  Client::addMenuItem(%clientId, %i+1 @ $MList::EName[%misindex], %misIndex @ " " @ %type);
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
   else if($CurVoteAction == "tdc")
	  Admin::setTDScale($curVoteOption);
   else if($CurVoteAction == "votsni")
	  Admin::setSniperLimit($curVoteOption);
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
      Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
	// DELTAFORCE
	Client::addMenuItem(%clientId, %curItem++ @ "Weapon Options", "weaponoptions");
	// END DELTAFORCE
   }
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

      if($curVoteTopic == "" && !%clientId.isAdmin)
      {
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
   else if($curVoteTopic == "" && !%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
      //if($Server::TeamDamageScale == 1.0)
      //   Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
      //else
      //   Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to set team damage scale", "vtdc");
	  Client::addMenuItem(%clientId, %curItem++ @ "Vote to set sniper limitation", "vsni");         
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
      //if($Server::TeamDamageScale == 1.0)
      //   Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
      //else
      //   Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
	  Client::addMenuItem(%clientId, %curItem++ @ "Set Team Damage Scale", "tdc");
	  Client::addMenuItem(%clientId, %curItem++ @ "Set Sniper Limitation", "sni");
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
      remoteEval(%clientId, "setInfoLine", 6, "Other: ");
   }
}

function processMenuFPickTeam(%clientId, %team)
{
   if(%clientId.isAdmin)
      processMenuPickTeam(%clientId.ptc, %team, %clientId);
   %clientId.ptc = "";
}

// DELTAFORCE
function processMenuGrenOptions(%clientId, %opt)
{
	if(%opt == "exp")
	{
		$GrenMode[%clientId] = 0;
		remoteEval(%clientId, BP, "<f0><jc>Grenades set for Fragmentation detonation", 4);
		return;
	} else if(%opt == "smoke")
	{
		$GrenMode[%clientId] = 1;
		remoteEval(%clientId, BP, "<f0><jc>Grenades set for Smoke detonation", 4);
		return;
	}
}


function processMenuASOptions(%clientId, %opt)
{
	if(%opt == "he") {
		$ASMode[%clientId] = 0;
		remoteEval(%clientId, BP, "<f0><jc>Airstrike set to High Explosive payload", 4);
		return;
	} else if(%opt == "napalm") {
		$ASMode[%clientId] = 1;
		remoteEval(%clientId, BP, "<f0><jc>Airstrike set to Napalm payload", 4);
		return;
	}
}


function processMenuMPOptions(%clientId, %opt)
{
	if(%opt == "standard") {
		$MP5Mode[%clientId] = 0;
		remoteEval(%clientId, BP, "<f0><jc>MP5 set to Standard fire", 4);
		return;
	} else if(%opt == "threeshot") {
		$MP5Mode[%clientId] = 1;
		remoteEval(%clientId, BP, "<f0><jc>MP5 set to Three-shot Burst fire", 4);
		return;
	}
}

function processMenuSGOptions(%clientId, %opt)
{
	if(%opt == "flechette") {
		$ShotgunMode[%clientId] = 0;
		remoteEval(%clientId, BP, "<f0><jc>SPAS-12 loaded with Flechette rounds", 4);
		return;
	}
	else if(%opt == "slug") {
		$ShotgunMode[%clientId] = 1;
		remoteEval(%clientId, BP, "<f0><jc>SPAS-12 loaded with Slug rounds", 4);
		return;	
	}
}

function processMenuWOptions(%clientId, %opt)
{
	if(%opt == "autoshotgun") {
		Client::buildMenu(%clientId, "Choose mode:", "SGOptions", true);
		Client::addMenuItem(%clientId, "0Flechette", "flechette");
		Client::addMenuItem(%clientId, "1Slug", "slug");
		return;
	}
	else if (%opt == "mp5") {
		Client::buildMenu(%clientId, "Choose mode:", "MPOptions", true);
		Client::addMenuItem(%clientId, "0Standard", "standard");
		Client::addMenuItem(%clientId, "1Three-shot Burst", "threeshot");
		return;
	}
	else if(%opt == "airstrike") {
		Client::buildMenu(%clientId, "Choose mode:", "ASOptions", true);
		Client::addMenuItem(%clientId, "0High Explosive", "he");
		Client::addMenuItem(%clientId, "1Napalm", "napalm");
	} else if(%opt == "grenade") {
		Client::buildMenu(%clientId, "Choose mode:", "GrenOptions", true);
		Client::addMenuItem(%clientId, "0Frag", "exp");
		Client::addMenuItem(%clientId, "1Smoke", "smoke");
	}
}
// END DELTAFORCE

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

   // DELTAFORCE
	if($Game::missionType == "Assassination") {
   		if($Hunted == %clientId) {
			if($HuntedQueue == 0) {
				schedule("centerprint("@%clientId@", \"<jc><f0>You cannot change teams...no one else wants to be the VIP!\", 4);", 0.5);
				return;
			} else {
				$Hunted = $HuntedList[0];
				for(%i = 0; %i < $HuntedQueue-1; %i++) {
					$HuntedList[%i] = $HuntedList[%i+1];
					if($HuntedList[%i])
						schedule("bottomprint("@$HuntedList[%i]@", \"<jc><f0>You are #"@(%i+1)@" in line to be the VIP.\", 4);", 0.5);
				}
				$HuntedQueue--;
				Player::kill($Hunted);
				schedule("centerprint("@$Hunted@", \"<jc><f0>You are the VIP!\", 4);", 0.5);
			}
		}
		if(%team == 0) {
			if ($Hunted == 0) { // No VIP yet...
				$Hunted = %clientId;
				schedule("centerprint("@%clientId@", \"<jc><f0>You are the VIP!\", 4);", 0.5);
			}
		} else if(%team == 1) {
			if ( getTeamNumPlayers(1) > (0.5*getTeamNumPlayers(0)) ) {
				schedule("centerprint("@%clientId@", \"<jc><f0>Too many Assassins. You are now a Bodyguard.\", 4);", 0.5);
				%team = 0;
			}
		} else if(%team == 2) {
			%team = 0;
			if ($Hunted) {
				for(%i = 0; %i < $HuntedQueue; %i++)
				{
					if($HuntedList[%i] == %clientId)
						return;
				}
				$HuntedQueue++;
				$HuntedList[$HuntedQueue-1] = %clientId;
				schedule("centerprint("@%clientId@", \"<jc><f0>You are #"@$HuntedQueue@" in line to be the VIP. You are now a Bodyguard.\", 4);", 0.5);
				
				if(GameBase::getTeam(%clientId) == %team)
					return;
			} else {
				$Hunted = %clientId;
				schedule("centerprint("@$Hunted@", \"<jc><f0>You are the VIP!\", 4);", 0.5);
			}
		}
	}
	// END DELTAFORCE

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
      // DELTAFORCE
	if($Game::missionType == "Assassination") {
		Client::addMenuItem(%clientId, "1VIP", 2);
		Client::addMenuItem(%clientId, "2Bodyguards", 0);
		Client::addMenuItem(%clientId, "3Assassins", 1);
	} else if (!$hostageGame || $Game::missionType != "Hostage") {
		Client::addMenuItem(%clientId, "1Automatic", -1);
	}
	if($Game::missionType == "Hostage") {
		for(%i = 0; %i < getNumTeams()-1; %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
   	} else {
      	for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         		Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
   	}
   	// END DELTAFORCE
   	return;
   }
   // DELTAFORCE
   else if(%opt == "weaponoptions")
   {
   	Client::buildMenu(%clientId, "Weapon Options:", "WOptions", true);
	Client::addMenuItem(%clientId, "0Airstrike", "airstrike");
	Client::addMenuItem(%clientId, "1Auto Shotgun", "autoshotgun");
	Client::addMenuItem(%clientId, "2Grenade", "grenade");
	Client::addMenuItem(%clientId, "3Silenced MP5", "mp5");
	return;
   }
   // END DELTAFORCE
   else if(%opt == "changeteams")
   {
      if(!$matchStarted || !$Server::TourneyMode)
      {
         Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
         Client::addMenuItem(%clientId, "0Observer", -2);
  	   // DELTAFORCE
	   	if($Game::missionType == "Assassination") {
			Client::addMenuItem(%clientId, "1VIP", 2);
			Client::addMenuItem(%clientId, "2Bodyguards", 0);
			Client::addMenuItem(%clientId, "3Assassins", 1);
		} else if (!$hostageGame || $Game::missionType != "Hostage") {
			Client::addMenuItem(%clientId, "1Automatic", -1);
		}
		if($Game::missionType == "Hostage") {
			for(%i = 0; %i < getNumTeams()-1; %i = %i + 1)
				Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
   		} else {
      	for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         		Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
   	    }
   	   // END DELTAFORCE
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
   else if(%opt == "vsmatch")
      Admin::startVote(%clientId, "start the match", "smatch", 0);
   //else if(%opt == "vetd")
   //   Admin::startVote(%clientId, "enable team damage", "etd", 0);
   //else if(%opt == "vdtd")
   //   Admin::startVote(%clientId, "disable team damage", "dtd", 0);
   else if(%opt == "vtdc") {
	  Client::buildMenu(%clientId, "Vote on Team Damage Scale", "vtdscale", true);
	  Client::addMenuItem(%clientId, "10%", 0);
	  Client::addMenuItem(%clientId, "210%", 10);
	  Client::addMenuItem(%clientId, "325%", 25);
	  Client::addMenuItem(%clientId, "450%", 50);
	  Client::addMenuItem(%clientId, "575%", 75);
	  Client::addMenuItem(%clientId, "690%", 90);
	  Client::addMenuItem(%clientId, "7100%", 100);
	  return;
   }
   else if(%opt == "vsni") {
	  Client::buildMenu(%clientId, "Vote on Sniper Limitation", "vtdsni", true);
	  Client::addMenuItem(%clientId, "110%", 10);
	  Client::addMenuItem(%clientId, "220%", 20);
	  Client::addMenuItem(%clientId, "330%", 30);
	  Client::addMenuItem(%clientId, "440%", 40);
	  Client::addMenuItem(%clientId, "550%", 50);
	  return;
   }
   //else if(%opt == "etd")
   //   Admin::setTeamDamageEnable(%clientId, true);
   //else if(%opt == "dtd")
   //   Admin::setTeamDamageEnable(%clientId, false);
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
   // DELTAFORCE
   else if(%opt == "tdc") {
	  Client::buildMenu(%clientId, "Set Team Damage Scale", "tdscale", true);
	  Client::addMenuItem(%clientId, "10%", 0);
	  Client::addMenuItem(%clientId, "210%", 10);
	  Client::addMenuItem(%clientId, "325%", 25);
	  Client::addMenuItem(%clientId, "450%", 50);
	  Client::addMenuItem(%clientId, "575%", 75);
	  Client::addMenuItem(%clientId, "690%", 90);
	  Client::addMenuItem(%clientId, "7100%", 100);
	  return;
   }
   else if(%opt == "sni") {
	  Client::buildMenu(%clientId, "Set Sniper Limitation", "tdsni", true);
	  Client::addMenuItem(%clientId, "110%", 10);
	  Client::addMenuItem(%clientId, "220%", 20);
	  Client::addMenuItem(%clientId, "330%", 30);
	  Client::addMenuItem(%clientId, "440%", 40);
	  Client::addMenuItem(%clientId, "550%", 50);
	  return;
   }
   // END DELTAFORCE
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

// DELTAFORCE
function processMenuTDSni(%clientId, %opt)
{
	if(%clientId.isAdmin) {
		$Server::SniperLimit = %opt / 100;
		bottomprintall("<jc>Sniper limitation set to " @ %opt @"% of a team", 4);
	}
}

function processMenuTDScale(%clientId, %opt)
{
	if(%clientId.isAdmin) {
			$Server::TeamDamageScale = %opt / 100;
			bottomprintall("<jc>Team damage scale set to " @ %opt @"%", 4);
	}
}

function processMenuVTDScale(%clientId, %opt) {
	// PORT FIX: the menu code comes from the client; only a whole number 0..100 is a scale.
	%opt = floor(%opt);
	if(%opt < 0 || %opt > 100)
		return;
	Admin::startVote(%clientId, "set the team damage scale to " @ %opt @"%", "tdc", %opt);
}

function processMenuVTDSni(%clientId, %opt) {
	// PORT FIX: the menu code comes from the client; only a whole number 0..100 is a limit.
	%opt = floor(%opt);
	if(%opt < 0 || %opt > 100)
		return;
	Admin::startVote(%clientId, "set the sniper limitation to " @ %opt @"%", "votsni", %opt);
}

function Admin::setTDScale(%opt) 
{
	$Server::TeamDamageScale = %opt / 100;
	bottomprintall("<jc>Team damage scale set to " @ %opt @"% by CONSENSUS", 4);
}

function Admin::setSniperLimit(%opt)
{
	$Server::SniperLimit = %opt / 100;
	bottomprintall("<jc>Sniper limitation set to " @ %opt @"% of a team by CONSENSUS", 4);
}
// END DELTAFORCE

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
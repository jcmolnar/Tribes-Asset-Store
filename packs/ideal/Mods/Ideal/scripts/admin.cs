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

	if(%clientId.normal == 0)
		processMenuOptions(%clientId, "Ideal"); //make ideal default menu

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
//mod:
      Client::addMenuItem(%clientId, %curItem++ @ "Ideal Weapon Options", "Ideal");
	if(Player::getArmor(%clientId) == SCVArmor)
		Client::addMenuItem(%clientId, %curItem++ @ "SCV Deployment Options", "SCV");
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
   
	if(%clientId.traitor == 0)
	{
		if(%adminClient == "")
	      	messageAll(0, Client::getName(%clientId) @ " changed teams.");
		else
		      messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
	}
	else
	{
		echo(%clientId @ " is a traitor... (using Changeling Net)"); //only server will know
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
   else if(%opt == "Ideal") //mod:
   {
	%clientId.normal = 0;
	Client::buildMenu(%clientId, "Choose a Weapon:", "Weapon", true);
	%i = 0;
	if(Player::getItemCount(%clientId, Blaster))
		Client::addMenuItem(%clientId, %i++ @ "Blaster", "Blaster");
	if(Player::getItemCount(%clientId, PlasmaGun))
		Client::addMenuItem(%clientId, %i++ @ "Plasma Gun", "plasma");
	if(Player::getItemCount(%clientId, DiscLauncher))
		Client::addMenuItem(%clientId, %i++ @ "Disc Launcher", "disclauncher");
	if(Player::getItemCount(%clientId, energyrifle) || Player::getItemCount(%clientId, shortenergyrifle) || Player::getItemCount(%clientId, longenergyrifle))
		Client::addMenuItem(%clientId, %i++ @ "ELF", "elf");
	if(Player::getItemCount(%clientId, GrenadeLauncher))
		Client::addMenuItem(%clientId, %i++ @ "Grenade Launcher", "grenadeL");
	if(Player::getItemCount(%clientId, mortar))
		Client::addMenuItem(%clientId, %i++ @ "Mortar", "mortar");
	if(Player::getItemCount(%clientId, SlowGun))
		Client::addMenuItem(%clientId, %i++ @ "Mass Gun", "mass");
	if(Player::getItemCount(%clientId, concuss))
		Client::addMenuItem(%clientId, %i++ @ "Chaos Gun", "chaos");
	Client::addMenuItem(%clientId, %i++ @ "List all options", "list");
	Client::addMenuItem(%clientId, %i++ @ "Normal Menu", "normal");
	return;
   }
   else if(%opt == "SCV")
   {
	%i = 0;
	Client::buildMenu(%clientId, "Choose Deployable:", "Deployable", true);
	Client::addMenuItem(%clientId, %i++ @ "Dep. Inv. Station", "DeployableInv");
	Client::addMenuItem(%clientId, %i++ @ "Dep. Ammo Station", "DeployableAmmo");
	Client::addMenuItem(%clientId, %i++ @ "Dep. Inv. Station", "DeployableInv");
	Client::addMenuItem(%clientId, %i++ @ "Motion Sensor", "MotionSensor");
	Client::addMenuItem(%clientId, %i++ @ "Pulse Sensor", "PulseSensor");
	Client::addMenuItem(%clientId, %i++ @ "Sensor Jammer", "DeployableSensorJammer");
	Client::addMenuItem(%clientId, %i++ @ "Camera", "Camera");
	Client::addMenuItem(%clientId, %i++ @ "More Options", "More");
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


//mod:

function processMenuWeapon(%clientId, %opt)
{
	if(%opt == "normal")
	{
		%clientId.normal = 1;
		Game::menuRequest(%clientId);
	}
	else if(%opt == "chaos")
	{
		Client::buildMenu(%clientId, "Chaos Gun Ammo", "ChaosGun", true);
	      Client::addMenuItem(%clientId, "1Jitterbug Ammo", "jitterbug");
      	Client::addMenuItem(%clientId, "2Concussion Ammo", "concuss");
	}
	else if(%opt == "elf")
	{
		Client::buildMenu(%clientId, "ELF Style", "ELF", true);
	      Client::addMenuItem(%clientId, "1Short Range/Max. Damage", "short");
	      Client::addMenuItem(%clientId, "2Mid Range/Mid. Damage", "");
	      Client::addMenuItem(%clientId, "3Long Range/Min. Damage", "long");
	}
	else if(%opt == "mortar")
	{
		Client::buildMenu(%clientId, "Mortar Ammo", "Mortar", true);
	      Client::addMenuItem(%clientId, "1Regular Ammo", "");
      	Client::addMenuItem(%clientId, "2EMP Ammo", "emp");
	}
	else if(%opt == "Blaster")
	{
		Client::buildMenu(%clientId, "Blaster", "Blaster", true);
	      Client::addMenuItem(%clientId, "1Regular Fire", 0);
      	Client::addMenuItem(%clientId, "2Overload Capacitor", 1);
	}
	else if(%opt == "mass")
	{
		Client::buildMenu(%clientId, "Mass Gun", "Mass", true);
	      Client::addMenuItem(%clientId, "1Increase Mass (Slow down)", "SlowPod");
      	Client::addMenuItem(%clientId, "2Decrease Mass (Speed up)", "FastPod");
	}
	else if(%opt == "disclauncher")
	{
		Client::buildMenu(%clientId, "Disc Launcher", "disc", true);
	      Client::addMenuItem(%clientId, "1Normal Disc", "Normal");
      	Client::addMenuItem(%clientId, "2Homing Disc (requires 3 shots)", "Homing");
	}
	else if(%opt == "grenadeL")
	{
		Client::buildMenu(%clientId, "Grenade Launcher", "grenadeL", true);
	      Client::addMenuItem(%clientId, "1Normal Grenade", "Grenade");
      	Client::addMenuItem(%clientId, "2ECM Grenades", "ECM");
	}
	else if(%opt == "plasma")
	{
		Client::buildMenu(%clientId, "Plasma Gun", "plasma", true);
	      Client::addMenuItem(%clientId, "1Normal Plasma", "PlasmaBolt");
      	Client::addMenuItem(%clientId, "2Overheated Plasma", "FlamePlasma");
      	Client::addMenuItem(%clientId, "     aka Flamethrower", "FlamePlasma");

	}
	else if(%opt == "list")
	{
		Client::buildMenu(%clientId, "All Weapons", "Weapon", true);
		Client::addMenuItem(%clientId, %i++ @ "Blaster", "Blaster");
		Client::addMenuItem(%clientId, %i++ @ "Plasma Gun", "plasma");
		Client::addMenuItem(%clientId, %i++ @ "Disc Launcher", "disclauncher");
		Client::addMenuItem(%clientId, %i++ @ "ELF", "elf");
		Client::addMenuItem(%clientId, %i++ @ "Grenade Launcher", "grenadeL");
		Client::addMenuItem(%clientId, %i++ @ "Mortar", "mortar");
		Client::addMenuItem(%clientId, %i++ @ "Mass Gun", "mass");
		Client::addMenuItem(%clientId, %i++ @ "Chaos Gun", "chaos");
	}
}

function processMenuChaosGun(%clientId, %opt)
{
if(%opt != "jitterbug" && %opt != "concuss") return; // PORT: menu codes come from the client
	%ammo = %opt @ "shot";
	%clientId.chaosShot = %ammo;
}

function processMenuELF(%clientId, %opt)
{
if(%opt != "" && %opt != "short" && %opt != "long") return; // PORT: menu codes come from the client
	%clientId.elfVersion = %opt @ "EnergyRifle";
	if(Player::getItemCount(%clientId, EnergyRifle) != 1) //if you have no regular elf
	{
		if(Player::getItemCount(%clientId, shortEnergyRifle) || Player::getItemCount(%clientId, longEnergyRifle)) //but have another elf
		{
			Player::setItemCount(%clientId, EnergyRifle, 1); //get regular elf so that you can change elf types
			Player::setItemCount(%clientId, shortEnergyRifle, 0); //get rid of these for the inv screens
			Player::setItemCount(%clientId, longEnergyRifle, 0);  //and weapon HUD to show up with just 1 ELF...
		}
	}
	Player::useItem(%clientId, EnergyRifle);
}

function processMenuMortar(%clientId, %opt)
{
if(%opt != "" && %opt != "emp") return; // PORT: menu codes come from the client
	%ammo = %opt @ "MortarShell";
	%clientId.mortarShell = %ammo;
}

function processMenuBlaster(%clientId, %opt)
{
if(%opt == 1) %opt = 1; else %opt = 0; // PORT: menu codes come from the client; only 0 / 1 reach the schedule() below
	if(%opt == %clientId.overloadblaster)
	{	
		return;
	}
//so they're changing...
	if(%opt == 0) //turn off overload
		Client::sendMessage(%clientId, 1, "Cooling down blaster... Please Wait.");
	else //turn on
		Client::sendMessage(%clientId, 1, "Overloading Blaster. Ready to fire in 5 seconds" @ "~wshieldhit.wav"); 
	%clientId.overloadblaster = 4;
	schedule("processBlasterPt2(" @ %clientId @ ", " @ %opt @ ");", 5.0, Client::getControlObject(%clientId));
}

function processBlasterPt2(%clientId, %opt)
{
	%clientId.overloadblaster = %opt;

	if(%opt == 0) //turn off overload
		Client::sendMessage(%clientId, 1, "Blaster state has return to normal.");
	else //turn on
		Client::sendMessage(%clientId, 1, "Blaster Overloaded. Ready to fire!" @ "~wshieldhit.wav"); 
}

function processMenuMass(%clientId, %opt)
{
if(%opt != "SlowPod" && %opt != "FastPod") return; // PORT: menu codes come from the client
	%clientId.massShot = %opt;
}

function processMenudisc(%clientId, %opt)
{
if(%opt != "Normal" && %opt != "Homing") return; // PORT: menu codes come from the client
	if(%clientId.discType == %opt)
		return;

	%ammoCount = Player::getItemCount(%clientId, DiscAmmo);
	if(%opt == "Homing")
		%ammoCount = floor(%ammoCount/3);
	else if(%clientId.discType != "")
		%ammoCount = %ammoCount * 3;

	Player::setItemCount(%clientId, DiscAmmo, %ammoCount);

	%clientId.disctype = %opt;
}

function processMenugrenadeL(%clientId, %opt)
{
if(%opt != "Grenade" && %opt != "ECM") return; // PORT: menu codes come from the client
	%clientId.grentype = %opt @ "Shell";
}

function processMenuplasma(%clientId, %opt)
{
if(%opt != "PlasmaBolt" && %opt != "FlamePlasma") return; // PORT: menu codes come from the client
	if(%clientId.plasmaType == %opt)
		return;

	%ammoCount = Player::getItemCount(%clientId, PlasmaAmmo);
	if(%opt == "FlamePlasma")
		%ammoCount = 5 * %ammoCount;
	else if(%clientId.plasmaType != "")
		%ammoCount = floor(%ammoCount/5);

	Player::setItemCount(%clientId, PlasmaAmmo, %ammoCount);

	%clientId.plasmatype = %opt;
}

function processMenuDeployable(%clientId, %opt)
{
// PORT: menu codes come from the client, and SCVPack::onUse splices this one into a schedule()
// string (item.cs). Only the menu's own entries are accepted.
if(%opt != "More" && %opt != "Less" && %opt != "DeployableInv" && %opt != "DeployableAmmo" && %opt != "MotionSensor" && %opt != "PulseSensor" && %opt != "DeployableSensorJammer" && %opt != "Camera" && %opt != "Turret" && %opt != "ArbitorBox" && %opt != "NuclearTurret" && %opt != "Obelisk" && %opt != "ObeliskPower" && %opt != "FlameTurret")
	return;
	if(%opt == "More")
	{
		Client::buildMenu(%clientId, "Choose Deployable:", "Deployable", true);
		Client::addMenuItem(%clientId, %i++ @ "Turret", "Turret");
		Client::addMenuItem(%clientId, %i++ @ "Arbitor Device", "ArbitorBox");
		Client::addMenuItem(%clientId, %i++ @ "Nuclear Turret", "NuclearTurret");
		Client::addMenuItem(%clientId, %i++ @ "Obelisk of Light", "Obelisk");
		Client::addMenuItem(%clientId, %i++ @ "Obelisk Power Station", "ObeliskPower");
		Client::addMenuItem(%clientId, %i++ @ "Flame Turret", "FlameTurret");
//		Client::addMenuItem(%clientId, %i++ @ "Super Sensor", "SuperSensor");
		Client::addMenuItem(%clientId, %i++ @ "More Options", "Less");
		return;
	}
	else if(%opt == "Less")
	{
		processMenuOptions(%clientId, "SCV");
		return;
	}

	%clientId.deployable = %opt @ "Pack";
}
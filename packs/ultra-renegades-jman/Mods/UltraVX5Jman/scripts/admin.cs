exec("WeaponOps.cs");
$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;
$passfailcount = 0;

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
      echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Changed the Mission to " @ %misName @ "");
   }
   else
   {
      Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
      Game::menuRequest(%clientId);
   }
}

function remoteAdminPassword(%client, %password)
{
      %log = $console::logmode;
      %ip = Client::getTransportAddress(%client);
      %clientName = Client::getName(%Client);
   if($AdminPassword != "" && %password == $AdminPassword)
   {
      %client.isAdmin = true;
      %client.isSuperAdmin = true;
      MessageAll(0, %clientname @ " became a SuperAdmin by force.~wForceOpen.wav");
      echo("ADMINMSG: **** " @ %clientname @ " became SuperAdmin by force.");
     // %ip = Client::getTransportAddress(%client);
     // %clientName = Client::getName(%Client);
     // %log = $console::logmode;
      
         if(%log == "0" || %log == "")
          {
      $console::logmode = "2";
      echo("---------------------------------------------------------------------------");
      echo("-----------Administrator LOGON SUCCESSFUL!");
      echo("-----------Player:" @ %clientName);
      echo("-----------" @ %ip);
      echo("-----------PASSWORD: (not logged)");
      echo("---------------------------------------------------------------------------");
      $console::logmode = "0";
          }
         if(%log == "1" || %log == "2")
          {
      echo("---------------------------------------------------------------------------");
      echo("-----------Administrator LOGON SUCCESSFUL!");
      echo("-----------Player:" @ %clientName);
      echo("-----------" @ %ip);
      echo("-----------PASSWORD: (not logged)");
      echo("---------------------------------------------------------------------------");
         }
   }
   
   if(%client.isAdmin != true)
      {
        if(%log == "0" || %log == "")
          {
      $console::logmode = "2";
      echo("---------------------------------------------------------------------------");
      echo("-----------Administrator LOGON FAILURE!");
      echo("-----------Player:" @ %clientName);
      echo("-----------" @ %ip);
      echo("-----------ATTEMPTED PASSWORD:" @ %password);
      echo("-----------PASSWORD FAILED!!!");
      echo("---------------------------------------------------------------------------");
      echo("ADMINMSG: !!!!!!! " @ %clientName @ " has tried to force admin with: " @ %password);
	MessageAll(0, %clientName @ " has just failed to force admin.");
      //$passfailcount++;
      //if($passfailcount > 3)
      //{
      //  MessageAll(0, %clientName @ " has been kicked for trying to break into the server.");
      //   $passfailcount = 0;
      //   Net::kick(%client, "Stop trying, you'll never get it.");
      //}
      
      $console::logmode = "0";
          }
      if(%log == "1" || %log == "2")
          {
      echo("---------------------------------------------------------------------------");
      echo("-----------Administrator LOGON FAILURE!");
      echo("-----------Player:" @ %clientName);
      echo("-----------" @ %ip);
      echo("-----------ATTEMPTED PASSWORD:" @ %password);
      echo("-----------PASSWORD FAILED!!!");
      echo("---------------------------------------------------------------------------");
      echo("ADMINMSG: !!!!!!! " @ %clientName @ " has tried to force admin with: " @ %password);
	MessageAll(0, %clientName @ " has just failed to force admin.");
      //$passfailcount++;
      //if($passfailcount > 3)
      //{

      //  MessageAll(0, %clientName @ " has been kicked for trying to break into the server.");
      //  $passfailcount = 0;
      //  Net::kick(%client, "Stop trying, you'll never get it.");
      // }

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
         {
            echo("ADMINMSG: **** Team damage enabled by consensus.");   
            messageAll(0, "Team damage set to ENABLED by consensus.");
         }
         else
         {   
            echo("ADMINMSG: **** " @ Client::getName(%admin) @ " enabled team damage.");
            messageAll(0, Client::getName(%admin) @ " ENABLED team damage.");
         }
      }
      else
      {
         $Server::TeamDamageScale = 0;
         if(%admin == -1)
         {
            echo("ADMINMSG: **** Team damage disabled by consensus.");
            messageAll(0, "Team damage set to DISABLED by consensus.");
         }
         else
         {
            echo("ADMINMSG: **** " @ Client::getName(%admin) @ " disabled team damaage.");
            messageAll(0, Client::getName(%admin) @ " DISABLED team damage.");
         }
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
         echo("ADMINMSG: **** " @ %name @ " was " @ %word @ " from vote.");
         Net::kick(%client, "You were " @ %word @ " by  consensus.");
      }
      else
      {
         MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
         echo("ADMINMSG: **** " @ %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
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
         echo("ADMINMSG: **** " @ Client::getName($curVoteOption) @ " Has Been Voted ADMIN");
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
   else if($curVoteAction == "voteVX")
      vxmode("Ultra_RenegadesVX5");
   else if($curVoteAction == "voteVXOGL")
      vxmode("Ultra_RenegadesVX5_OGL");
   else if($curVoteAction == "voteVXNOTOR")
      vxmode("Ultra_RenegadesVX5_NOTOR");
   else if($curVoteAction == "voteVXdefaults")
      vxDIFmode("Defaults");
   else if($curVoteAction == "voteVXMEDIUM")
      vxDIFmode("MEDIUM");
   else if($curVoteAction == "voteVXHARD")
      vxDIFmode("HARD");
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
         if(%cl.isSuperAdmin)
         {
             %votesFor = %votesFor + 147;
             %totalVotes = %totalVotes + 147;
         }
         else
         {
             %votesFor++;
             %totalVotes++;
         }
      }
      else if(%cl.vote == "no")
      {
         if(%cl.isSuperAdmin)
         {
             %votesAgainst = %votesAgainst + 147;
             %totalVotes = %totalVotes + 147;
         }
         else
         {
             %votesAgainst++;
             %totalVotes++;
         }
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
      %minvotes = 2;
      %totalVotes = %votesFor + %votesAgainst + %votesAbstain;
      if(%totalVotes < (%minVotes))
         %totalVotes = (%minVotes);
   }
   if(%votesFor / %totalVotes >= %margin)
   {
      messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %votesAbstain @ " abstentions."); //%totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
      echo("ADMINMSG: **** Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %votesAbstain @ " abstentions."); //%totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
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
      messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %votesAbstain @ " abstentions."); //%totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
      echo("ADMINMSG: **** Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %votesAbstain @ " abstentions."); //%totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
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
      echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic @ "");
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
            //Client::addMenuItem(%clientId, %curItem++ @ "Admin Stuff", "adminstf");
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
      if($StoreOpen == 1)
         {
           Client::addMenuItem(%clientId, %curItem++ @ "Run-Time Store", "rtstore");
         }
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
      if($Ultra_RenegadesVX5::modvoting == "true")
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change MOD", "vcMOD");
      
      if($Ultra_RenegadesVX5::difficultyvoting == "true")
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change Difficulty", "vcDif");
      
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
      if($StoreOpen == 1)
         {
           Client::addMenuItem(%clientId, %curItem++ @ "Run-Time Store", "rtstore");
         }

      Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");

	//if(%clientId.SuperAdmin)
      //Client::addMenuItem(%clientId, %curItem++ @ "Testing", "testme");

      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
      Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
//    Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
      Client::addMenuItem(%clientId, %curItem++ @ "UltraVX Mode", "vxmode");
      Client::addMenuItem(%clientId, %curItem++ @ "Difficulty", "vxdifficulty");
      
   }
}

/////////////////////////////////////////////////////////////////////
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
      if(%clientId.isSuperAdmin) 
      remoteEval(%clientId, "setInfoLine", 6, "Client: " @ Client::getTransportAddress(%selId)); 
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
   {
      echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " changed teams.");
      messageAll(0, Client::getName(%clientId) @ " changed teams.");
   }
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
   else if(%opt == "vcMOD" && $Ultra_RenegadesVX5::modvoting == "true")
      {
         Client::buildMenu(%clientId, "UltraVX MOD:", "votevxmodeopt", true);
         Client::addMenuItem(%clientId, "1UltraVX5", "votevx4");
         Client::addMenuItem(%clientId, "2UltraVX5 OGL", "votevx4ogl");
         Client::addMenuItem(%clientId, "3UltraVX5 NOTOR", "votevx4notor");
         return;
      }
   else if(%opt == "vcDif" && $Ultra_RenegadesVX5::difficultyvoting == "true")
      {
         Client::buildMenu(%clientId, "Difficulty MODE:", "votevxDifopt", true);
         Client::addMenuItem(%clientId, "1Defaults(Single Shot kills)", "votevxDifdefaults");
         Client::addMenuItem(%clientId, "2Medium(4 Shot kills)", "votevxDifMedium");
         Client::addMenuItem(%clientId, "3Hard(6-8 Shot kills)", "votevxDifHard");
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
   else if(%opt == "kick")
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "adminstf" && %clientId.isSuperAdmin)
   {
      //$TestCheats = 1;
      //$ServerCheats = 1;
	//remoteSetArmor(%clientId, "harmor");
      //$TestCheats = 0;
      //$ServerCheats = 0;
	Client::buildMenu(%clientId, "Admin's Stash", "adstash", true);
      Client::addMenuItem(%clientId, "1Armor Type Stuff", "armorstf");
      Client::addMenuItem(%clientId, "2Mean Shit", "meanstf");
      Client::addMenuItem(%clientId, "3Admin's Mail Order", "adminorder");
      return;
   }
   else if(%opt == "rtstore" && $StoreOpen == 1)
   {
      Client::buildMenu(%clientId, "Run-Time Store", "rtstore", true);
      Client::addMenuItem(%clientId, "1Armor", "armorstore");
      Client::addMenuItem(%clientId, "2Weapons", "wepstore");
      Client::addMenuItem(%clientId, "3Ammo", "ammostore");
      Client::addMenuItem(%clientId, "4Backpacks", "packstore");
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
   else if(%opt == "vxmode")
      {
         Client::buildMenu(%clientId, "UltraVX MOD:", "vxmodeopt", true);
         Client::addMenuItem(%clientId, "1UltraVX5", "vx4");
         Client::addMenuItem(%clientId, "2UltraVX5 OGL", "vx4ogl");
         Client::addMenuItem(%clientId, "3UltraVX5 NOTOR", "vx4notor");
         return;
   }
   else if(%opt == "vxdifficulty")
      {
         Client::buildMenu(%clientId, "Server Difficulty:", "vxSRVdif", true);
         Client::addMenuItem(%clientId, "1Defaults(Single Shot kills)", "vxdefault");
         Client::addMenuItem(%clientId, "2Medium(4 Shot kills)", "vxmedium");
         Client::addMenuItem(%clientId, "3Hard(6-8 Shot kills)", "vxhard");
         return;
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
   Game::menuRequest(%clientId);
}
function processMenurtstore(%clientId, %opt)
{
   if(%opt == "armorstore")
   {
      Client::buildMenu(%clientId, "Armor Store", "armorstore", true);
      Client::addMenuItem(%clientId, "1light", "ltarmor");
      Client::addMenuItem(%clientId, "2Medium", "mdarmor");
      Client::addMenuItem(%clientId, "3Heavy", "hvarmor");
      return;
   }
   else if(%opt == "wepstore")
   {
      Client::buildMenu(%clientId, "Weapon Store", "wepstore", true);
      Client::addMenuItem(%clientId, "1Emp Cannon", "empcannon");
      Client::addMenuItem(%clientId, "2Fire Ability", "fire");
      Client::addMenuItem(%clientId, "3Smoke Screen", "smoke");
      Client::addMenuItem(%clientId, "4Spell Ability", "spell");
      return;
   }
   else if(%opt == "packstore")
   {
      Client::buildMenu(%clientId, "BackPack Store", "packstore", true);
      Client::addMenuItem(%clientId, "1Teleport Pack", "teleport");
      Client::addMenuItem(%clientId, "2StealthShield Pack", "stealth");
      Client::addMenuItem(%clientId, "3Cloaking Device", "cloak");
      Client::addMenuItem(%clientId, "4Land Camo", "camo");
      return;
   }
   else if(%opt == "ammostore")
   {
      Client::buildMenu(%clientId, "Ammo Store", "ammostore", true);
      Client::addMenuItem(%clientId, "1LiLPOOmki Ammo", "POOmki");
      Client::addMenuItem(%clientId, "2LiLPOOmkii Ammo", "POOmkii");
      Client::addMenuItem(%clientId, "3LiLFFB Ammo", "FFB");
      Client::addMenuItem(%clientId, "4Plasma Bolt", "plasma");
      return;
   }
}
function processMenuarmorstore(%clientId, %opt)
{
   $TestCheats = 1;
   $ServerCheats = 1;
   if(%opt == "ltarmor")
   {
      remoteSetArmor(%clientId, "larmor");
   }
   else if(%opt == "mdarmor")
   {
      remoteSetArmor(%clientId, "marmor");
   }
   else if(%opt == "hvarmor")
   {
      remoteSetArmor(%clientId, "harmor");
   }
   $ServerCheats = 0;
   $TestCheats = 0;
}
function processMenuwepstore(%clientId, %opt)
{
   $TestCheats = 1;
   $ServerCheats = 1;
   if(%opt == "empcannon")
   {
      buyItem(%clientId, "LiLEMPRocketLauncher");
   }
   else if(%opt == "fire")
   {
      buyItem(%clientId, "FireBallAbility");
   }
   else if(%opt == "smoke")
   {
      buyItem(%clientId, "SmScreenAbility");
   }
   else if(%opt == "spell")
   {
      buyItem(%clientId, "SpellAbility");
   }
   $ServerCheats = 0;
   $TestCheats = 0;
}
function processMenupackstore(%clientId, %opt)
{
   $TestCheats = 1;
   $ServerCheats = 1;
   if(%opt == "teleport")
   {
      buyItem(%clientId, "TeleportPack");
   }
   else if(%opt == "stealth")
   {
      buyItem(%clientId, "ShieldPack");
   }
   else if(%opt == "cloak")
   {
      buyItem(%clientId, "CloakingDevice");
   }
   else if(%opt == "camo")
   {
      buyItem(%clientId, "cactusPack");
   }
   $ServerCheats = 0;
   $TestCheats = 0;
}
function processMenuammostore(%clientId, %opt)
{
   $Testcheats = 1;
   $ServerCheats = 1;
   if(%opt == "POOmki")
   {
      buyItem(%clientId, "LiLPOOmkiAmmo");
   }
   else if(%opt == "POOmkii")
   {
      buyItem(%clientId, "LiLPOOmkiiAmmo");
   }
   else if(%opt == "FFB")
   {
      buyItem(%clientId, "LiLFFBAmmo");
   }
   else if(%opt == "plasma")
   {
      buyItem(%clientId, "PlasmaAmmo");
   }
   $ServerCheats = 0;
   $TestCheats = 0;
}
     

function processMenuadstash(%clientId, %opt)
{
   if(!%clientId.isSuperAdmin)
      return;
   if(%opt == "armorstf")
   {
      Client::buildMenu(%clientId, "Shield, Jammer, and Stuff", "armorstf", true);
      Client::addMenuItem(%clientId, "1Shield", "shield");
      Client::addMenuItem(%clientId, "2Sensor Jammer", "jammit");
      Client::addMenuItem(%clientId, "3Invisibility", "invis");
      return;
   }
   else if(%opt == "meanstf")
   {  %cl = %clientId.selClient;
      Client::buildMenu(%clientId, "Mean Shit", "damn", true);
      Client::addMenuItem(%clientId, "1Ass Monkey", "assmonk");
      Client::addMenuItem(%clientId, "2Clear Ass Monkey Status", "noassmonk");
      Client::addMenuItem(%clientId, "3Apply Impulse", "appimp");
      Client::addMenuItem(%clientId, "4Drop Their Shit", "dropsies");
      Client::addMenuItem(%clientId, "5Pinball","pinball");
      Client::addMenuItem(%clientId, "6Insane", "insane");
	if(%cl.tied) 
	Client::addMenuItem(%clientId,  "7Untie", "untie"); 
	else 
      Client::addMenuItem(%clientId, "7Tie up", "tie");
	if(%cl.poss) 
	Client::addMenuItem(%clientId,  "8Unpossess", "unposs"); 
	else if (!%clientId.possy && %cl != %clientId && %cl.observerMode == "")
      Client::addMenuItem(%clientId, "8Possess", "poss");

      return;
   }

   else if(%opt == "adminorder")
   {
      Client::buildMenu(%clientId, "Mail Order Catalog", "moc", true);
      Client::addMenuItem(%clientId, "1Ammo", "ordammo");
      Client::addMenuItem(%clientId, "2Weapons", "ordwep");
      Client::addMenuItem(%clientId, "3Turrets & Packs", "ordturret");
      return;
   }
}

function clearTheAss()
{
   if ($assmonk != 0)
   {
     messageAll(1,"Assmonkey status is now clear.");
   }
}

function processMenudamn(%clientId, %opt)
{
   if(!%clientId.isSuperAdmin)
      return;  
   if (%opt == "assmonk")
   {
      $assmonk = %clientId.selClient;
      messageAll(1,Client::getName(%clientId.selClient) @ " is now the AssMonkey... watch your feet.");
      echo("ADMINMSG: !!!!! " @ Client::getName(%clientId) @ " has declared " @ Client::getName(%clientId.selClient) @ " the assmonkey.");
      schedule("clearTheAss();", 420, %clientId.selClient);
      schedule("$assmonk = 0;", 421, %clientId.selClient);

   }
   else if (%opt == "noassmonk")
   {
      clearTheAss();
      $assmonk = 0;
   }
   else if (%opt == "appimp")
   {
      Player::applyimpulse(%clientId.selClient, "1000 1000 0");
   }
   else if (%opt == "dropsies")
   {
	%client = %clientId.selClient;
      Player::dropItem(%client,Flag);
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	%max = getNumItems(); 
	for (%i = 0; %i < %max; %i = %i + 1) 
      { 
		%item = getItemData(%i);
		%count = Player::getItemCount(%client,%item); 
		if(%count) 
            {
			Player::setItemCount(%client,%item,0); 
		}
	}
	Player::setDamageFlash(%client,0.75); 

//     for(%i = 1; %i < 10; %i++)
//      {
//         Player::dropItem(%clientId.selClient, Player::getMountedItem(%clientId.selClient, 0));
//         Player::mountItem(%clientId.selClient, $spawnBuyList[%i], 0);
//      }
//      Player::dropItem(%clientId.selClient, Player::getMountedItem(%clientId.selClient, 1));
//      Player::dropItem(%clientId.selClient, Player::getMountedItem(%clientId.selClient, 2));
//      Player::dropItem(%clientId.selClient, Player::getMountedItem(%clientId.selClient, 3));
//      Player::dropItem(%clientId.selClient, Player::getMountedItem(%clientId.selClient, 0));
//      Player::dropItem(%clientId.selClient, "LiLPOOmki");
  }
  else if (%opt == "pinball")
  {
     %theirId = %clientId.selClient;
     Player::blowUp(%theirId);
     pinball1(%theirId);
     schedule("pinball2(" @ %theirId @ ");", 0.5, %theirId);
     schedule("pinball3(" @ %theirId @ ");", 1.0, %theirId);
     schedule("pinball4(" @ %theirId @ ");", 1.5, %theirId);
     schedule("pinball5(" @ %theirId @ ");", 2.0, %theirId);
     schedule("pinball6(" @ %theirId @ ");", 2.5, %theirId);
     schedule("pinballfinal(" @ %theirId @ ");", 3.0, %theirId);
  }
  else if(%opt == "insane")
  {
      %cl = %clientId.selClient;
      schedule("Client::setGuiMode(" @ %cl @ ",3);", 0.5, %cl);
      schedule("player::setdamageflash(" @ %cl @ ",2);", 1.0, %cl);
      schedule("Client::setGuiMode(" @ %cl @ ",4);", 1.5, %cl);
      schedule("player::setdamageflash(" @ %cl @ ",2);", 2.0, %cl);
      schedule("Client::setGuiMode(" @ %cl @ ",1);", 2.5, %cl);
      schedule("player::setdamageflash(" @ %cl @ ",2);", 3.0, %cl);
      schedule("player::setdamageflash(" @ %cl @ ",10);", 3.5, %cl);
      schedule("Client::setGuiMode(" @ %cl @ ",6);", 4.0, %cl);
      schedule("pos1(" @ %cl @ ");", 4.5, %cl);
      schedule("pos2(" @ %cl @ ");", 5.0, %cl);
      schedule("player::setdamageflash(" @ %cl @ ",2);", 5.5, %cl);
      schedule("pos3(" @ %cl @ ");", 6.0, %cl);
      schedule("player::setdamageflash(" @ %cl @ ",2);", 6.5, %cl);
      schedule("player::setdamageflash(" @ %cl @ ",2);", 7.0, %cl);
      schedule("pos4(" @ %cl @ ");", 7.5, %cl);
      schedule("Client::setGuiMode(" @ %cl @ ",1);", 8.0, %cl);
      schedule("insano(" @ %cl @ ");", 8.1, %cl); 

  }

  else if(%opt == "tie")
  {
      %tiedbastard = %clientId.selClient;
	%tiedbastard.tied = true;
	%pl = Client::getOwnedObject(%clientId.selClient);
	//%tiedbastard.poss = true;
	//%pl.invulnerable = true;
      %clientId.shieldStrength = 1.0;
      Client::setControlObject(%tiedbastard, Client::getObserverCamera(%tiedbastard));
      Observer::setOrbitObject(%tiedbastard, %pl, 3, 3, 3);
	//MessageAll( 0, Client::getName(%tiedbastard) @" gets frozen by "@Client::getName(%clientId)@" until a cure for the stupids is found."); 
      echo("ADMINMSG:: !!!!" @ Client::getName(%clientId) @ " froze " @ Client::getName(%tiedbastard));   
      //if(!%clientId.sexowner)echo($admin);
   	//if($AdminLog && !%clientId.sexowner) export("Admin","config\\Admin.log",true);
	centerprint(%tiedbastard, "<jc><f1>You were frozen by "@Client::getName(%clientId)@" until a cure for the stupids is found.", 5);
      Game::menuRequest(%clientId);
  }
  else if(%opt == "untie")
  {
      %cl = %clientId.selClient;
	%cl.tied = false;
	%pl = Client::getOwnedObject(%cl);
	//%pl.invulnerable = false;
	//%cl.poss = false;
      %clientId.shieldStrength = 0.0;
      Client::setControlObject(%cl, %cl);
	echo("ADMINMSG:: !!!! " @ Client::getName(%clientId) @ " decided to defrost " @ Client::getName(%cl));
	//if(!%clientId.sexowner)echo($admin);
   	//if($AdminLog && !%clientId.sexowner) export("Admin","config\\Admin.log",true);
	//MessageAll( 0, Client::getName(%clientId)@" decided to defrost "@ Client::getName(%cl) ); 
  }
  else if(%opt == "poss")
  {
      %possbastard = %clientId.selClient;
	%possbastard.poss = true;
	%pl = Client::getOwnedObject(%possbastard);
	%clId = Client::getOwnedObject(%clientId); 
	//%clId.invulnerable = true;
      %possbastard.shieldStrength = 0.99;
	//%clientId.invulnerable = true;
      %clientId.shieldStrength = 0.99;
	%clientId.possy = true;
	%clientId.possess = %pl;
	%possbastard.possessedby = %clientId;
      Client::setControlObject(%possbastard, Client::getObserverCamera(%possbastard));
      Observer::setOrbitObject(%possbastard, %pl, 3, 3, 3);
	//MessageAll( 0, Client::getName(%clientId)@" lends "@Client::getName(%possbastard) @" a brain."); 
	echo("ADMINMSG:: !!!! " @ Client::getName(%clientId) @ " lends " @ Client::getName(%possbastard) @ " a brain.");
      //if(!%clientId.sexowner)echo($admin);
   	//if($AdminLog && !%clientId.sexowner) export("Admin","config\\Admin.log",true);
	centerprint(%possbastard, "<jc><f1>You were possessed by "@Client::getName(%clientId)@", enjoy the ride.", 10);
	Client::setControlObject(%clientId, %possbastard);
   return;
  }
  else if(%opt == "unposs")
  {
      %cl = %clientId.selClient;
	%cl.poss = false;
	%clientId.possy = false;
	%clientId.possess = "";
	//%cl.invulnerable = false;
      %cl.shieldStrength = 0.0;
	%pl = Client::getOwnedObject(%cl);
	%clId = Client::getOwnedObject(%clientId);
	centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" Gave you back your body..", 5);
	//%pl.invulnerable = false;
      %clientId.shieldStrength = 0.0;
	%cl.possessedby = "";
	//%clId.invulnerable = false;
	Client::setControlObject(%clientId, %clientId);
      Client::setControlObject(%cl, %cl);
	//MessageAll( 0, Client::getName(%cl) @" excorcised "@Client::getName(%clientId));
	return;
  }


}

function pos1(%cl)
{
	GameBase::setPosition(%cl,"0 0 5000");
}

function pos2(%cl)
{
	GameBase::setPosition(%cl,"0 0 -5000");
}

function pos3(%cl)
{
	GameBase::setPosition(%cl,"0 400 300");
}

function pos4(%cl)
{
	GameBase::setPosition(%cl,"0 -400 300");
}

function insano(%cl)
{
         centerprint(%cl, "<jc><f1>Oh, damn. That sucked. Why not be a good little boy and behave next time.", 5);
}

function pinball1(%ballId)
{
   Player::applyimpulse(%ballId,"1000 1000 0");
}

function pinball2(%ballId)
{
   Player::applyimpulse(%ballId,"-1000 0 0");
}

function pinball3(%ballId)
{
   Player::applyimpulse(%ballId,"1000 -1000 0");
}

function pinball4(%ballId)
{
   Player::applyimpulse(%ballId,"-1000 0 1000");
}

function pinball5(%ballId)
{
   Player::applyimpulse(%ballId,"1000 1000 -1000");
}

function pinball6(%ballId)
{
   Player::applyimpulse(%ballId,"-1000 -1000 0");
}

function pinballfinal(%ballId)
{
	Player::blowUp(%ballId);
 	BottomPrint(%ballId,"<f1><jc>BYE BYE! ... BOOM!!",3);
      Player::kill(%ballId); 
}



function processMenuarmorstf(%clientId, %opt)
{
   if(!%clientId.isSuperAdmin)
      return;
   if (%opt == "shield")
   {
      Client::buildMenu(%clientId, "Shield Status:", "shieldstat", true);
      Client::addMenuItem(%clientId, "1ON", "on");
      Client::addMenuItem(%clientId, "2OFF", "off");
      return;
   }
   else if(%opt == "jammit")
   {
      Client::buildMenu(%clientId, "Sensor Jammer Status:", "jammstat", true);
      Client::addMenuItem(%clientId, "1ON", "on");
      Client::addMenuItem(%clientId, "2OFF", "off");
      return;
   }
   else if(%opt == "invis")
   {
      Client::buildMenu(%clientId, "Cloaking Device Status:", "instat", true);
      Client::addMenuItem(%clientId, "1ON", "on");
      Client::addMenuItem(%clientId, "2OFF", "off");
      return;
   }
}

function processMenushieldstat(%clientId, %opt)
{
   if(!%clientId.isSuperAdmin)
      return;
   if (%opt == "on")
   {
      %yourId = Client::getOwnedObject(%clientId);
      %yourId.shieldStrength = 0.999;
   }
   else if (%opt == "off")
   {
      %yourId = Client::getOwnedObject(%clientId);
      %yourId.shieldStrength = 0;
   }
}

function processMenujammstat(%clientId, %opt)
{
   if(!%clientId.isSuperAdmin)
      return;
   if (%opt == "on")
   {
      %yourId = Client::getOwnedObject(%clientId);
      Player::setSensorSupression(%yourId, 100);
   }
   else if (%opt == "off")
   {
      %yourId = Client::getOwnedObject(%clientId);
      Player::setSensorSupression(%yourId, 0);
   }
}

function processMenuinstat(%clientId, %opt)
{
   if(!%clientId.isSuperAdmin)
      return;
   if (%opt == "on")
   {
      %yourId = Client::getOwnedObject(%clientId);
      GameBase::startFadeout(Client::getOwnedObject(%clientId));
   }
   else if (%opt == "off")
   {
      %yourId = Client::getOwnedObject(%clientId);
      GameBase::startFadein(Client::getOwnedObject(%clientId));
   }
}







function processMenumoc(%clientId, %opt)
{
   if(!%clientId.isSuperAdmin)
      return;
   if (%opt == "ordammo")
   {
      Client::buildMenu(%clientId, "Ammo", "ammobuy", true);
      Client::addMenuItem(%clientId, "1LiLPOOmkiiAmmo", "mkii");
      Client::addMenuItem(%clientId, "2LiLPOOmkiAmmo", "mki");
      Client::addMenuItem(%clientId, "3LiLFFBAmmo", "ffb");
      Client::addMenuItem(%clientId, "4Nukes", "nukes");
      Client::addMenuItem(%clientId, "5Bouncy Shells", "bouncey");
      Client::addMenuItem(%clientId, "6Boost & Brake", "boostbrake");
      Client::addMenuItem(%clientId, "7ChainBlaster Ammo", "chainammo");
      return;
   }
   else if (%opt == "ordwep")
   {
      Client::buildMenu(%clientId, "Weapons", "wepbuy", true);
      Client::addMenuItem(%clientId, "1FireballAbility", "firebuy");
      Client::addMenuItem(%clientId, "2SmScreenAbility", "smokebuy");
      Client::addMenuItem(%clientId, "3MIRV", "empbuy");
      Client::addMenuItem(%clientId, "4Nuclear Warhead", "nukebuy");
      Client::addMenuItem(%clientId, "5Blaster", "blastbuy");
      Client::addMenuItem(%clientId, "6Bouncy Gun", "bounce");
      Client::addMenuItem(%clientId, "7ChainBlaster", "chainb");
      return;
   }
   else if (%opt == "ordturret")
   {
      Client::buildMenu(%clientId, "Turrets & Packs", "backbuy", true);
      Client::addMenuItem(%clientId, "1LaserTurretPack", "lturbuy");
      Client::addMenuItem(%clientId, "2lgaForceFieldPack", "lgabuy");
      Client::addMenuItem(%clientId, "3TeleportPack", "telbuy");
      Client::addMenuItem(%clientId, "4LaserTurretBPack", "lturbbuy");
      Client::addMenuItem(%clientId, "5Backpack of Revenge", "rpack");
      Client::addMenuItem(%clientId, "6Laser Motion Turret", "ltm");
      return;
   }
}   

function processMenuammobuy(%clientId, %opt)
{
   if(!%clientId.isSuperAdmin)
      return;
   $TestCheats = 1;
   $ServerCheats = 1;
   if (%opt == "mkii")
   {
      buyItem(%clientId,"LiLPOOmkiiAmmo");
   }
   else if (%opt == "mki")
   {
      buyItem(%clientId,"LiLPOOmkiAmmo");
   }
   else if (%opt == "ffb")
   {
      buyItem(%clientId,"LiLFFBAmmo");
   }
   else if (%opt == "nukes")
   {
      buyItem(%clientId,"NuclearAmmo");
   }
   else if (%opt == "bouncey")
   {
      buyItem(%clientId,"BouncyAmmo");
   }
   else if (%opt == "boostbrake")
   {
      buyItem(%clientId, "Grenade");
      buyItem(%clientId, "Beacon");
   }
   else if (%opt == "chainammo")
   {
      buyItem(%clientId, "ChainBlasterAmmo");
   }
   $TestCheats = 0;
   $ServerCheats = 0;    
}

function processMenuwepbuy(%clientId, %opt)
{
   if(!%clientId.isSuperAdmin)
      return;
   $TestCheats = 1;
   $ServerCheats = 1;
   if (%opt == "firebuy")
   {
      buyItem(%clientId,"FireballAbility");
   }
   else if (%opt == "smokebuy")
   {
      buyItem(%clientId, "SmScreenAbility");
   }
   else if (%opt == "empbuy")
   {
      buyItem(%clientId, "FireWorks1");
   }
   else if (%opt == "nukebuy")
   {
      buyItem(%clientId, "NuclearBomb");
   }
   else if (%opt == "blastbuy")
   {
      buyItem(%clientId, "Blaster");
   }
   else if (%opt == "bounce")
   {
      buyItem(%clientId, "BouncyGun");
   }
   else if (%opt == "chainb")
   {
      buyItem(%clientId, "ChainBlaster");
   }
   $TestCheats = 0;
   $ServerCheats = 0;
}

function processMenubackbuy(%clientId, %opt)
{
   if(!%clientId.isSuperAdmin)
      return;
   $TestCheats = 1;
   $ServerCheats = 1;
   if (%opt == "lturbuy")
   {
      buyItem(%clientId,"LaserTurretPack");
   }
   else if (%opt == "lgabuy")
   {
      buyItem(%clientId, "lgaForceFieldPack");
   }
   else if (%opt == "telbuy")
   {
      buyItem(%clientId, "TeleportPack");
   }
   else if (%opt == "lturbbuy")
   {
      buyItem(%clientId, "LaserTurretBPack");
   }
   else if (%opt == "rpack")
   {
	buyItem(%clientId, "RevengePack");
   }
   else if (%opt == "ltm")
   {
      buyItem(%clientId, "LaserTurretMPack");
   }
   $TestCheats = 0;
   $ServerCheats = 0;
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
         echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
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

function processMenuvotevxDifopt(%clientId, %opt)
{
   if(%opt == "votevxDifdefaults")
   Admin::startVote(%clientId, "change the difficulty to Defaults setting","voteVXdefaults", 0);
   
   if(%opt == "votevxDifMedium")
   Admin::startVote(%clientId, "change the difficulty to MEDIUM settings","voteVXMEDIUM", 0);
   
  if(%opt == "votevxDifHard")
   Admin::startVote(%clientId, "change the difficulty to HARD settings","voteVXHARD", 0);
   
}

function processMenuvotevxmodeopt(%clientId, %opt)
{
   if(%opt == "votevx4")
   Admin::startVote(%clientId, "change the MOD to Ultra_RenegadesVX5","voteVX", 0);
   
   if(%opt == "votevx4ogl")
   Admin::startVote(%clientId, "change the MOD to Ultra_RenegadesVX5_OGL","voteVXOGL", 0);
   
  if(%opt == "votevx4notor")
   Admin::startVote(%clientId, "change the MOD to Ultra_RenegadesVX5_NOTOR","voteVXNOTOR", 0);
   
}

function processMenuvxmodeopt(%clientId, %opt)
{
   if(%opt == "vx4" && %clientId.isAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " set the server to Ultra_RenegadesVX5 settings.");
      
      //Server::refreshData();
      vxmode("Ultra_RenegadesVX5");
     
   }
   if(%opt == "vx4ogl" && %clientId.isAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " set the server to Ultra_RenegadesVX5_OGL settings.");
      
      //Server::refreshData();
      vxmode("Ultra_RenegadesVX5_OGL");
   }
   if(%opt == "vx4notor" && %clientId.isAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " set the server to Ultra_RenegadesVX5_NOTOR settings.");
      //export("pref::*", "config\\ClientPrefs.cs", False);
      //Server::refreshData();
      vxmode("Ultra_RenegadesVX5_NOTOR");
   }
   //Game::menuRequest(%clientId);
}

function processMenuvxSRVdif(%clientId, %opt)
{
   if(%opt == "vxdefault" && %clientId.isAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " set the server to Defaults DIFFICULTY setting.");
      
      //Server::refreshData();
      vxDIFmode("Defaults");
     
   }
   if(%opt == "vxmedium" && %clientId.isAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " set the server to MEDIUM DIFFICULTY settings.");
      
      //Server::refreshData();
      vxDIFmode("MEDIUM");
   }
   if(%opt == "vxhard" && %clientId.isAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " set the server to HARD DIFFICULTY settings.");
      //export("pref::*", "config\\ClientPrefs.cs", False);
      //Server::refreshData();
      vxDIFmode("HARD");
   }
   //Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{
   remoteSetTimeLimit(%clientId, %opt);
}

$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

$Admin::PlayerControl = "acontrol";
$Admin::PlayerPunish = "punish";

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
   if(%client.SADAttempt == "")
	%client.SADAttempt = 0;
   %client.SADAttempt = %client.SADAttempt + 1;
   %ip = Client::getTransportAddress(%client);
   %currentName = Client::getName(%client);

   if(%client.SADAttempt < 11)
   {
      if($AdminPassword != "" && %password == $AdminPassword)
      {
         %client.isAdmin = true;
         %client.isSuperAdmin = true;
         Logger::LogMessage(%client,"ADMIN","is now an admin");
         return;
      }
      else if (%client.isAdmin)
	{
         if (%password == "deadmin")
         {
            %client.isAdmin = false;
            %client.isSuperAdmin = false;
            %client.AdminIsImmune = false;
            %client.AdminGeneral = false;
            %client.AdminServerSettings = false;
            %client.AdminCanAdminPlayer = false;
            %client.AdminReferee = false;
            %client.AdminVerified = false;
            Logger::LogMessage(%client,"ADMIN","is no longer an admin");
            Client::sendMessage(%client, 1, "Admin Status Removed.");
            return;
	   }
	}
   }

   if (%client.isAdmin)
         Logger::LogMessage(%client,"ADMIN","tried to become an admin: \"" @ escapeString(%password) @ "\"");
   else
         Logger::LogMessage(%client,"ADMIN *HACK*","tried to become an admin: \"" @ escapeString(%password) @ "\"");
}

function remoteSetPassword(%client, %password)
{
   if(%client.isSuperAdmin) {
      $Server::Password = %password;
      Logger::LogMessage(%client,"ADMIN","set password to \"" @ escapeString(%password) @ "\"");
   }
   else
   {
      Logger::LogMessage(%client,"ADMIN *HACK*","tried to set password to \"" @ escapeString(%password) @ "\"");
   }
}

function remoteSetTimeLimit(%client, %time)
{

   %time = floor(%time);
   if((%time != 0 && %time < 1) || (!%client.isAdmin)) {
      Logger::LogMessage(%client,"ADMIN *HACK*","tried to set time limit to " @ %time);
      return;
   }
   if(%time == $Server::timeLimit) {
	  // Already set to this time
      Logger::LogMessage(%client,"ADMIN","set time limit to " @ %time @ " minute(s) - no change.");
      Client::sendMessage(%client, 0, "Time limit is already " @ %time @ " minute(s).");
      return;
   }
   if(%client.isAdmin)
   {
      $Server::timeLimit = %time;
      Logger::LogMessage(%client,"ADMIN","set time limit to " @ %time @ " minute(s).");
      if(%time)
         messageAll(0, Client::getName(%client) @ " set time limit to " @ %time @ " minute(s).");
      else
         messageAll(0, Client::getName(%client) @ " disabled the time limit.");
   }
}

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
   if(%team >= 0 && %team < 8 && %client.isAdmin)
   {
      Logger::LogMessage(%client,"ADMIN","to set team " @ %team @ " name to " @ %teamName @ " with skin " @ %skinBase);
      $Server::teamName[%team] = %teamName;
      $Server::teamSkin[%team] = %skinBase;
      messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " 
         @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission.");
   }
   else
   {
      Logger::LogMessage(%client,"ADMIN *HACK*","tried to set team " @ %team @ " name to " @ %teamName @ " with skin " @ %skinBase);
   }
}

function remoteVoteYes(%clientId)
{
   Logger::LogMessage(%clientId,"ADMIN","voted YES.");
   %clientId.vote = "yes";
   centerprint(%clientId, "", 0);
}

function remoteVoteNo(%clientId)
{
   Logger::LogMessage(%clientId,"ADMIN","voted NO.");
   %clientId.vote = "no";
   centerprint(%clientId, "", 0);
}

function Admin::startMatch(%admin)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if(!$CountdownStarted && !$matchStarted)
      {
         if(%admin == -1) {
      	Logger::LogMessage(%admin,"ADMIN","vote started match");
            messageAll(0, "Match start countdown forced by vote.");
         } else {
      	Logger::LogMessage(%admin,"ADMIN","started match");
            messageAll(0, "Match start countdown forced by " @ Client::getName(%admin));
         }
      
         Game::ForceTourneyMatchStart();
      }
   }
   else
   {
      Logger::LogMessage(%admin,"ADMIN *HACK*","tried to start match");
   }
}

function Admin::setTeamDamageEnable(%admin, %enabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if(%enabled)
      {
         $Server::TeamDamageScale = 0;
         if(%admin == -1) {
            messageAll(0, "Team damage can NOT be enabled in this mod.");
            Logger::LogMessage(%admin,"ADMIN","vote enabled team damage.");
         } else { // Let an admin enable team damage
            $Server::TeamDamageScale = 1;
            messageAll(0, Client::getName(%admin) @ " enabled team damage.");
            Logger::LogMessage(%admin,"ADMIN","enabled team damage.");
         }
      }
      else
      {
         $Server::TeamDamageScale = 0;
         if(%admin == -1) {
            messageAll(0, "Team damage set to DISABLED by consensus.");
            Logger::LogMessage(%admin,"ADMIN","vote disabled team damage.");
         } else {
            messageAll(0, Client::getName(%admin) @ " DISABLED team damage.");
            Logger::LogMessage(%admin,"ADMIN","disabled team damage.");
         }
      }
   }
   else
   {
      Logger::LogMessage(%admin,"ADMIN *HACK*","tried to enable team damage");
   }
}


function Admin::setVehicleInventoryEnable(%admin, %enabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if(%enabled)
      {
         $VehicleInventory = 1;
         if(%admin == -1) {
            messageAll(0, "Vehicle station full inventory set to ENABLED by consensus.");
            Logger::LogMessage(%admin,"ADMIN","vote enabled Vehicle Inv.");
         } else {
            messageAll(0, Client::getName(%admin) @ " enabled vehicle station full inventory.");
            Logger::LogMessage(%admin,"ADMIN","enabled Vehicle Inv.");
         }
      }
      else
      {
         $VehicleInventory = 0;
         if(%admin == -1) {
            messageAll(0, "Vehicle station full inventory set to DISABLED by consensus.");
            Logger::LogMessage(%admin,"ADMIN","vote disabled Vehicle Inv.");
         } else {
            messageAll(0, Client::getName(%admin) @ " DISABLED vehicle station full inventory.");
            Logger::LogMessage(%admin,"ADMIN","disabled Vehicle Inv.");
         }
      }
   }
   else
   {
      Logger::LogMessage(%admin,"ADMIN *HACK*","tried to " @ %enable @ " vehicle inv.");
   }
}

function Admin::kick(%admin, %client, %ban)
{
   //ban client even if they dropped mid vote.
   if((%admin == -1 || %admin.isAdmin) && Client::getName(%client) == "")
   {
      if(%ban) {
         Logger::LogMessage(%admin,"ADMIN","banned IP " @ $CurrentVoteObjectIP);
         BanList::add($CurrentVoteObjectIP, 1800);
      } else {
         Logger::LogMessage(%admin,"ADMIN","kicked IP " @ $CurrentVoteObjectIP);
         BanList::add($CurrentVoteObjectIP, 180);
      }
      $CurrentVoteObjectIP = "";
      return;
   }

   if(%admin != %client && (%admin == -1 || %admin.isAdmin))
   {
      if(%ban && !%admin.isSuperAdmin) {
         Logger::LogMessage(%admin,"ADMIN *HACK*","tried to ban " @ %client );
         return;
      }
         
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
         Logger::LogMessage(%admin,"ADMIN *HACK*","tried to " @ %cmd @ " super admin " @ Logger::getClientStr(%client) );
         if(%admin == -1)
            messageAll(0, "A super admin cannot be " @ %word @ ".");
         else
            Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
         return;
      }
      %ip = Client::getTransportAddress(%client);

      Logger::LogMessage(%admin,"ADMIN",%cmd @ " " @ Logger::getClientStr(%client) @ " at IP " @ %ip );

      if(%ip == "")
         return;

      if(%ban) {
         BanList::add(%ip, 1800);
      } else {
         BanList::add(%ip, 180);
      }

      %name = Client::getName(%client);

      if(%admin == -1)
      {
         Logger::LogMessage(%admin,"ADMIN","vote " @ %word @ " " @ Logger::getClientStr(%client) @ "at ip " @ %ip);
         MessageAll(0, %name @ " was " @ %word @ " from vote.");
         Net::kick(%client, "You were " @ %word @ " by  consensus.");
      }
      else
      {
         Logger::LogMessage(%admin,"ADMIN",%word @ " " @ Logger::getClientStr(%client) @ "at ip " @ %ip);
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
      {
         Logger::LogMessage(%clientId,"ADMIN","vote enabled FFA mode.");
         messageAll(0, "Server switched to Free-For-All Mode.");
      }
      else
      {
         Logger::LogMessage(%clientId,"ADMIN","enabled FFA mode.");
         messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".");
      }

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
      {
         Logger::LogMessage(%clientId,"ADMIN","vote enabled tournament mode.");
         messageAll(0, "Server switched to Tournament Mode.");
      }
      else
      {
         Logger::LogMessage(%clientId,"ADMIN","enabled tournament mode.");
         messageAll(0, "Server switched to Tournament Mode by " @ Logger::getClientStr(%clientId));
      }

      $Server::TourneyMode = true;
      Server::nextMission();
   }
}

function Admin::voteFailed()
{
   echo( "Vote for " @ $curVoteAction @ " failed" );
   $curVoteInitiator.numVotesFailed++;

   if($curVoteAction == "kick" || $curVoteAction == "admin")
      $curVoteOption.voteTarget = "";

   $CurrentVoteObjectIP = "";
}

function Admin::voteSucceded()
{
   echo( "Vote for " @ $curVoteAction @ " passed" );
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
         // $curVoteOption.isAdmin = true;
         // messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.");
         %message = Client::getName($curVoteOption) @ " cannot be voted an administrator.";
         Logger::LogMessage(-1,"ADMIN",%message);
         messageAll(0, %message );
         // if($curVoteOption.menuMode == "options")
         //   Game::menuRequest($curVoteOption);
      }
      $curVoteOption.voteTarget = false;
   }
   else if($curVoteAction == "cmission")
   {
      %message = "Changing to mission " @ $curVoteOption @ ".";
      Logger::LogMessage(-1,"ADMIN",%message);
      messageAll(0, %message );

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
   else if($curVoteAction == "evi")
      Admin::setVehicleInventoryEnable(-1, true);
   else if($curVoteAction == "dvi")
      Admin::setVehicleInventoryEnable(-1, false);
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

   %forceFail = 0;
   if($curVoteAction == "kick") // Need MinKickVotes (3) to kick someone
   {
      if(%votesFor < $Server::MinKickVotes)
	{
	   // Force fail
         %forceFail = 1;
	}
   }

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
	// Force fail
      %forceFail = 1;
   }
   if((%votesFor / %totalVotes >= %margin) && !%forceFail)
   {
      %message = "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.";
      Logger::LogMessage(-1,"ADMIN",%message);
      messageAll(0, %message );

      Admin::voteSucceded();
   }
   else  // special team kick option:
   {
      if(($curVoteAction == "kick") && !%forceFail) // check if the team did a majority number on him:
      {
         %votesForTeam = 0;
         %totalVotesTeam = 0;
         for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         {
            if(GameBase::getTeam(%cl) == $curVoteOption.kickTeam)
            {
               %totalVotesTeam++;
               if(%cl.vote == "yes")
                  %votesForTeam++;
            }
         }
         if(%totalVotesTeam >= $Server::MinKickVotes && %votesForTeam / %totalVotesTeam >= $Server::VoteWinMargin)
         {
		%message = "Vote to " @ $curVoteTopic @ " passed: " @ %votesForTeam @ " to " @ %totalVotesTeam - %votesForTeam
			@ " of people on team.";
            Logger::LogMessage(-1,"ADMIN",%message);
	      messageAll(0, %message );

            Admin::voteSucceded();
            $curVoteTopic = "";
            return;
         }
      }
	%message = "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.";
      Logger::LogMessage(-1,"ADMIN",%message);
      messageAll(0, %message );
      Admin::voteFailed();
   }
   $curVoteTopic = "";
}

function Admin::startVote(%clientId, %topic, %action, %option)
{
   Logger::LogMessage(%clientId,"ADMIN","started vote for " @ %action @ " topic:" @ %topic @ " option:" @ %option);
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
      if(%option != -1 && %option != 0)
         $CurrentVoteObjectIP = Client::getTransportAddress(%option);
      else
         $CurrentVoteObjectIP = "";

      if(%action == "kick")
         $curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
      $curVoteCount++;
      bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         %cl.vote = "";
      %clientId.vote = "yes";
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	  {
         if(%cl.menuMode == "options")
            Game::menuRequest(%clientId);
	  }
      schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", $Server::VotingTime, 35);
   }
   else
   {
      Client::sendMessage(%clientId, 0, "Voting already in progress.");
   }
}

// Admin function menu (actions not against a player)
function buildMenuMAdmin(%clientId, %opt)
{
   %curItem = 0;
   // Use the aoptions menu processor
   Client::buildMenu(%clientId, " €::¤ Admin Options ¤::€", "aoptions", true);

   // Only an admin should be here!
   if (!%clientId.isAdmin)
   {
      echo( "ADMIN: *HACK* " @ Logger::getClientStr(%clientId) @ " tried to use admin menu" );
      Logger::LogMessage(%clientId,"ADMIN *HACK*","tried to use admin menu " @ %opt);

      hackMenu(%clientId);
  	  return;
   }

   Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
   if($Server::TeamDamageScale == 1.0)
      Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
   else
      Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");

  // if($VehicleInventory == 0)
   //         Client::addMenuItem(%clientId, %curItem++ @ "Enable v-station full inv", "evi");
   //else
      //      Client::addMenuItem(%clientId, %curItem++ @ "Disable v-station full inv", "dvi");
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
   Client::addMenuItem(%clientId, %curItem++ @ "Delete all deployables", "deldep");
}

// Admin function menu (actions against a player)
function buildMenuPAdmin(%clientId, %opt)
{
   %curItem = 0;
   // Use the poptions menu processor
   if (%opt == $Admin::PlayerControl)
   {
      Client::buildMenu(%clientId, " €::¤ Admin Options ¤::€", "poptions", true);
   }
   else if (%opt == $Admin::PlayerPunish)
   {
      Client::buildMenu(%clientId, "Punish Options", "pdoptions", true);
   }
   else
   {
      echo( "ADMIN: *HACK* " @ Logger::getClientStr(%clientId) @ " tried to use admin menu" );
      Logger::LogMessage(%clientId,"ADMIN *HACK*","tried to use admin menu " @ %opt);

      hackMenu(%clientId);
  	  return;
   }

   // Only an admin should be here!
   if (!%clientId.isAdmin)
   {
      echo( "ADMIN: *HACK* " @ Logger::getClientStr(%clientId) @ " tried to use admin menu" );
      Logger::LogMessage(%clientId,"ADMIN *HACK*","tried to use admin menu " @ %opt);

      hackMenu(%clientId);
  	  return;
   }

   // Menu items for admin when a player is selected
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

      if (%opt == $Admin::PlayerControl)
      {
		Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
		if(%clientId.isSuperAdmin)
		{
			if (%sel.isadmin && ! %sel.isSuperAdmin)
			{
			   Client::addMenuItem(%clientId, %curItem++ @ "Deadmin " @ %name, "deadmin " @ %sel);
			}
			else
			{
			   Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
			}
			if ((%clientId.selClient.expert == "") || (%clientId.selClient.expert == 0))
				Client::addMenuItem(%clientId, %curItem++ @ "Mark expert " @ %name @ "'s", "isexpert " @ %sel);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Mark unexpert " @ %name @ "'s", "unexpert " @ %sel);
		}
		Client::addMenuItem(%clientId, %curItem++ @ "Aliases for " @ %name, "alias " @ %sel);
	  }
	  else
	  {
		Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Kill " @ %name, "kill " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Torture " @ %name, "torture " @ %sel);

		if(%clientId.isSuperAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Delete deploys of " @ %name, "undeploy " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
		}
	  }
   }
   else
   {
      echo( "ADMIN: *HACK* " @ Logger::getClientStr(%clientId) @ " in buildMenuMPAdmin without a selected client!" );
      Logger::LogMessage(%clientId,"ADMIN *HACK*"," in buildMenuMPAdmin without a selected client! " @ %opt);

      hackMenu(%clientId);
  	  return;
   }
}

function hackMenu(%clientId)
{
   %curItem = 0;

   Client::buildMenu(%clientId, " €::¤ Omega Assault v1.6 ¤::€", "options", true);
   // Only admin menu for hacker is kick himself
   %name = Client::getName(%clientId);
   Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %clientId);
}

function Game::menuRequest(%clientId)
{
   %curItem = 0;
   Client::buildMenu(%clientId, " €::¤ Omega Assault v1.6 ¤::€", "options", true);
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
         // Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
      }
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
      if(%clientId.observerMode == "observerOrbit")
         Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
   }
   if (%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Game admin menu", "madmin");

      if(%clientId.selClient)
      {
         %sel = %clientId.selClient;
         %name = Client::getName(%sel);
         Client::addMenuItem(%clientId, %curItem++ @ "Punish " @ %name, "pdadmin");
         Client::addMenuItem(%clientId, %curItem++ @ "Admin control " @ %name, "padmin");
      }
   } 
   if($curVoteTopic != "" && %clientId.vote == "")
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }
   else
   {
      if(($curVoteTopic == "")&&!(%clientId.isAdmin))
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
         if($Server::TeamDamageScale == 1.0)
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
         else
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");

      //   if($VehicleInventory == 0)
       //     Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable v-station inv", "vevi");
      //   else
      //      Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable v-station inv", "vdvi");

         if($Server::TourneyMode)
         {
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
            if(!$CountdownStarted && !$matchStarted)
               Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
         }
         else
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");

      }
   }
}

function remoteSelectClient(%clientId, %selId)
{
   if(%clientId.selClient != %selId)
   {
      %clientId.selClient = %selId;
      if(%clientId.menuMode == "options")
	  {
         Game::menuRequest(%clientId);
	  }
      else if(%clientId.menuMode == "poptions")
	  {
         buildMenuPAdmin(%clientId, $Admin::PlayerControl);
	  }
      else if(%clientId.menuMode == "pdoptions")
	  {
         buildMenuPAdmin(%clientId, $Admin::PlayerPunish);
	  }
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

// Admin menu options (not to a player)
function processMenuAOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);

   // Only an admin should be here!
   if (!%clientId.isAdmin)
   {
      echo( "ADMIN: *HACK* " @ Logger::getClientStr(%clientId) @ " tried to use admin menu" );
      Logger::LogMessage(%clientId,"ADMIN *HACK*","tried to use admin menu " @ %opt);

      hackMenu(%clientId);
  	  return;
   }

   if(%opt == "smatch")
      Admin::startMatch(%clientId);
   else if(%opt == "etd")
      Admin::setTeamDamageEnable(%clientId, true);
   else if(%opt == "dtd")
      Admin::setTeamDamageEnable(%clientId, false);
   else if(%opt == "evi")
      Admin::setVehicleInventoryEnable(%clientId, true);
   else if(%opt == "dvi")
      Admin::setVehicleInventoryEnable(%clientId, false);
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
      Client::buildMenu(%clientId, "Confirm Reset:", "aaaffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes rserver");
      Client::addMenuItem(%clientId, "2Don't Reset", "no rserver");
      return;
   }
   else if(%opt == "deldep")
   {
      Client::buildMenu(%clientId, "Confirm Delete All Deployables:", "aaaffirm", true);
      Client::addMenuItem(%clientId, "1Delete all", "yes deldep");
      Client::addMenuItem(%clientId, "2Don't delete", "no deldep");
      return;
   }
   else if(%opt == "cffa")
   {
      Client::buildMenu(%clientId, "Confirm FFA Mode:", "aaaffirm", true);
      Client::addMenuItem(%clientId, "1Yes change to FFA", "yes cffa");
      Client::addMenuItem(%clientId, "2No don't change", "no cffa");
      return;
   }
   else if(%opt == "ctourney")
   {
      Client::buildMenu(%clientId, "Confirm Tournament Mode:", "aaaffirm", true);
      Client::addMenuItem(%clientId, "1Yes Tournament Mode", "yes ctourney");
      Client::addMenuItem(%clientId, "2No don't change", "no ctourney");
      return;
   }
   else if(%opt == "cmission")
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
      return;
   }

   Game::menuRequest(%clientId);
}

// Shell for main processor
function processMenuPDOptions(%clientId, %option)
{
	processMenuPOptions(%clientId, %option);
}

// Admin menu options (to a player)
function processMenuPOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   // Only an admin should be here!
   if (!%clientId.isAdmin)
   {
      echo( "ADMIN: *HACK* " @ Logger::getClientStr(%clientId) @ " tried to use player admin menu" );
      Logger::LogMessage(%clientId,"ADMIN *HACK*","tried to use admin menu " @ %opt);

      hackMenu(%clientId);
  	  return;
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
   else if(%opt == "kick")
   {
      Client::buildMenu(%clientId, "Confirm kick:", "acaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes kick " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no kick " @ %cl);
      return;
   }
   else if(%opt == "kill")
   {
      Client::buildMenu(%clientId, "Confirm kill:", "acaffirm", true);
      Client::addMenuItem(%clientId, "1Kill " @ Client::getName(%cl), "yes kill " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kill " @ Client::getName(%cl), "no kill " @ %cl);
      return;
   }
   else if(%opt == "torture")
   {
      Client::buildMenu(%clientId, "Confirm torture:", "acaffirm", true);
      Client::addMenuItem(%clientId, "1Torture " @ Client::getName(%cl), "yes torture " @ %cl);
      Client::addMenuItem(%clientId, "2Don't torture " @ Client::getName(%cl), "no torture " @ %cl);
      return;
   }
   else if(%opt == "admin")
   {
      Client::buildMenu(%clientId, "Confirm admin:", "acaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes admin " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no admin " @ %cl);
      return;
   }
   else if(%opt == "deadmin")
   {
      Client::buildMenu(%clientId, "Confirm deadmin:", "acaffirm", true);
      Client::addMenuItem(%clientId, "1Deadmin " @ Client::getName(%cl), "yes deadmin " @ %cl);
      Client::addMenuItem(%clientId, "2Don't deadmin " @ Client::getName(%cl), "no deadmin " @ %cl);
      return;
   }
   else if(%opt == "ban")
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "acaffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes ban " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no ban " @ %cl);
      return;
   }
   else if(%opt == "undeploy")
   {
      Client::buildMenu(%clientId, "Confirm Delete Deploys:", "acaffirm", true);
      Client::addMenuItem(%clientId, "1Delete Deploys of " @ Client::getName(%cl), "yes undeploy " @ %cl);
      Client::addMenuItem(%clientId, "2Don't Delete items from " @ Client::getName(%cl), "no undeploy " @ %cl);
      return;
   }
   else if(%opt == "isexpert")
   {
      %cl.expert = 3;
   }
   else if(%opt == "unexpert")
   {
      %cl.expert = 0;
   }
   else if(%opt == "alias")
   {
      Logger::showAlias(%cl,%clientId);
      Game::menuRequest(%clientId);
      return;
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }

   Game::menuRequest(%clientId);
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
      // %cl.voteTarget = true;
      // Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
   else if(%opt == "vsmatch")
      Admin::startVote(%clientId, "start the match", "smatch", 0);
   else if(%opt == "vetd")
      Admin::startVote(%clientId, "enable team damage", "etd", 0);
   else if(%opt == "vdtd")
      Admin::startVote(%clientId, "disable team damage", "dtd", 0);
   else if(%opt == "vevi")
      Admin::startVote(%clientId, "enable vehicle full inventory", "evi", 0);
   else if(%opt == "vdvi")
      Admin::startVote(%clientId, "disable vehicle full inventory", "dvi", 0);
   else if(%opt == "vcffa")
      Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
   else if(%opt == "vctourney")
      Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
   else if(%opt == "voteYes" && %cl == $curVoteCount)
   {
      Logger::LogMessage(%clientId,"ADMIN","voted YES.");
      %clientId.vote = "yes";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "voteNo" && %cl == $curVoteCount)
   {
      Logger::LogMessage(%clientId,"ADMIN","voted NO.");
      %clientId.vote = "no";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "madmin")
   {
      buildMenuMAdmin(%clientId, %opt);
      return;
   }
   else if(%opt == "padmin")
   {
      buildMenuPAdmin(%clientId, $Admin::PlayerControl);
      return;
   }
   else if(%opt == "pdadmin")
   {
      buildMenuPAdmin(%clientId, $Admin::PlayerPunish);
      return;
   }
   else if(%opt == "vcmission")
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
      return;
   }
   Game::menuRequest(%clientId);
}

function tortureClient(%killClient)
{
	%killClient.tortures--;
	playNextAnim(%killClient);
	if (%killClient.tortures > 0)
	{
		schedule("tortureClient(" @ %killClient @ ");", 5.0, %killClient );
	}
}

// Admin actions on a client that need affirmation
function processMenuACAffirm(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %itm = getWord(%option, 1);
   %toClient = getWord(%option, 2);
   %toClient = floor(%toClient); // PORT: a client id is a number; see fixes.json

   if (!%clientId.isAdmin)
   {
      Logger::LogMessage(%clientId,"ADMIN *HACK*","tried to " @ %itm @ " " @ %opt @ " " @ toClient );
      hackMenu(%clientId);
  	  return;
   }
   else if(%opt == "yes" && %clientId.isAdmin)
   {
      if(%itm == "undeploy")
      {
         Logger::LogMessage(%clientId,"ADMIN","delete deploys of " @ %opt);

         // delDeploys is in Logger
         delDeploys(%toClient);
      }
      else if(%itm == "admin")
      {
         if(%clientId.isSuperAdmin)
         {
            %toClient.isAdmin = true;
      		Logger::LogMessage(%clientId,"ADMIN","admined " @ %toClient);
            messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%toClient) @ " into an admin.");
         }
		 else
	     {
            Logger::LogMessage(%clientId,"ADMIN *HACK*","tried to admin " @ %toClient);
			hackMenu(%clientId);
  			return;
	     }
      }
      else if(%itm == "deadmin")
      {
         if(%clientId.isSuperAdmin)
         {
	        if(!%toClient.isSuperAdmin)
		    {
				%toClient.isAdmin = false;
      			Logger::LogMessage(%clientId,"ADMIN","deadmined " @ %toClient);
				messageAll(0, Client::getName(%clientId) @ " removed admin privlege from " @ Client::getName(%toClient) @ ".");
			}
			else
			{
				Client::sendMessage(%clientId, 1, "Can't deadmin a super admin.");
			}
         }
		 else
	     {
            Logger::LogMessage(%clientId,"ADMIN *HACK*","tried to admin " @ %toClient);
			hackMenu(%clientId);
  			return;
	     }
      }
      else if(%itm == "kick")
      {
         Logger::LogMessage(%clientId,"ADMIN","kicked " @ %toClient);
         Admin::kick(%clientId, %toClient);
      }
      else if(%itm == "kill")
      {
	     %killClient = %toClient;
		 if (%killClient.isSuperAdmin)
		 {
            Logger::LogMessage(%clientId,"ADMIN","killed self, not " @ %toClient);
			%killClient = %clientId;
		 }
		 else
		 {
			Logger::LogMessage(%clientId,"ADMIN","killed " @ %toClient);
		 }
         messageAll(0, Client::getName(%killClient) @ " died from extreme stupidity.");
 		 playNextAnim(%killClient);
         Player::kill(%killClient);
      }
      else if(%itm == "torture")
      {
	     %killClient = %toClient;
		 if (%killClient.isSuperAdmin)
		 {
            Logger::LogMessage(%clientId,"ADMIN","tortured self, not " @ %toClient);
			%killClient = %clientId;
		 }
		 else
		 {
			Logger::LogMessage(%clientId,"ADMIN","tortured " @ %toClient);
		 }
         messageAll(0, Client::getName(%killClient) @ " is punished.");
 		 %killClient.tortures = 20;
		 TortureClient(%killClient);
      }
      else if(%itm == "ban")
      {
         Logger::LogMessage(%clientId,"ADMIN","banned " @ %toClient);
         Admin::kick(%clientId, %toClient, true);
      }
      else
      {
         Logger::LogMessage(%clientId,"ADMIN *HACK*","invalid message command " @ %option);
         messageAll(0, Client::getName(%clientId) @ " sent an invlaid menu command: " @ %option );

         hackMenu(%clientId);
  	     return;
      }
   }
   Game::menuRequest(%clientId);
}

// Admin actions that required afirmation
function processMenuAAAffirm(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %itm = getWord(%option, 1);

   if (!%clientId.isAdmin)
   {
      Logger::LogMessage(%clientId,"ADMIN *HACK*","tried to " @ %itm @ " " @ %opt );
      hackMenu(%clientId);
  	  return;
   }
   else if(%opt == "yes" && %clientId.isAdmin)
   {
      if(%itm == "rserver")
      {
         Logger::LogMessage(%clientId,"ADMIN","reset server " @ %opt);
         messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
         Server::refreshData();
      }
      else if(%itm == "deldep")
      {
         Logger::LogMessage(%clientId,"ADMIN","deleted all deployables " @ %opt);
         messageAll(0, Client::getName(%clientId) @ " deleted all deployables.");
         delAllDeploys();
      }
      else if(%itm == "cffa")
      {
         Logger::LogMessage(%clientId,"ADMIN","change to FFA mode");
         messageAll(0, Client::getName(%clientId) @ " changed to FFA mode.");
         Admin::setModeFFA(%clientId);
      }
      else if(%itm == "ctourney")
      {
         Logger::LogMessage(%clientId,"ADMIN","change to tournament mode");
         messageAll(0, Client::getName(%clientId) @ " changed to tournament mode.");
         Admin::setModeTourney(%clientId);
      }
      else
      {
         Logger::LogMessage(%clientId,"ADMIN *HACK*","invalid message command " @ %option);
         messageAll(0, Client::getName(%clientId) @ " sent an invlaid menu command: " @ %option );

		 hackMenu(%clientId);
  	     return;
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{
   if (!%clientId.isAdmin)
   {
      Logger::LogMessage(%clientId,"ADMIN *HACK*","tried to set time limit " @ %opt);
      hackMenu(%clientId);
  	  return;
   } else {
      Logger::LogMessage(%clientId,"ADMIN","set time limit " @ %opt);
      remoteSetTimeLimit(%clientId, %opt);
   }
}

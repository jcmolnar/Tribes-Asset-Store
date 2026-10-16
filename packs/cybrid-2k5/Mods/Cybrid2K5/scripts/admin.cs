// =================================================================
//  U L T R A   R E N E G A D E S   V X  E L I T E  A D M I N    
// =================================================================
// Copyright © 2005 WorstAim. List of credits in credits.txt

$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

exec("2K5Config.cs");
exec("Cybrid_PlayerDataBase.cs");
exec("T-Mail.cs");

function Admin::changeMissionMenu(%clientId)
{ 
	Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true); 
	%index = 1; 
	for(%type = 1; %type < $MLIST::TypeCount; %type++) {
		if($MLIST::Type[%type] != "Training") { 
			if(%index == 8 && $MLIST::TypeCount > 8) { 
				Client::addMenuItem(%clientId, %index @ "View More Types...", "more 8 "); 
				break; 
			}
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0 "); 
			%index++; 
		} 
	}
}

function processMenuCMType(%clientId, %options)
{
   if(getWord(%options, 0) == "more")
	{
		%first = getWord(%options, 1);
		processMenuCMoo(%clientId, %first);
		return;
	}
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

function processMenuCMoo(%clientId, %first)
{
	Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true); 
	%index = 1; 
	for(%type = %first; %type < $MLIST::TypeCount; %type++)
	{
		if($MLIST::Type[%type] != "Training")
		{ 
			if(%index == 8 && $MLIST::TypeCount > %first + %index)
			{ 
				Client::addMenuItem(%clientId, %index @ "View More Types...", "more " @ %first + %index); 
				break; 
			}
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0"); 
			%index++; 
		} 
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

function remoteAdminPassword(%client)
{
	client::sendMessage(%client, 1, "You must use the ! commands to login with admin.~wCapturedTower.wav");
}

function AdminLogins(%client, %password)
{
    %client.tries++;
    if(%client.tries > 5)
    {
	if(%client.gone)
	{
		return;
	}
	%name = client::getName(%client);
	Admin::Exploit(%client, "SAD() Password Spam");
	banlist::add(client::getTransportAddress(%client), 300);
	messageall(0, %name@" Was Kicked For Spamming Admin Passwords");
	kick(%client, "You Were Kicked For Spamming Admin Passwords");
	%client.gone = true;
	return;
   }
   schedule(%client@".tries = 0;", 0.5);

   if(%password != "")
   {
     for(%i = 0; %i < 100; %i++)
     {
   	if(%password == $Admin::PublicPassword[%i] && $Admin::PublicPassword[%i] != "")
	{
		if(%client.isAdmin)
		{
			client::sendMessage(%client, 0, "You are already a public admin~wCapturedTower.wav");
			return;
		}
		echo("PUBLIC ADMIN: "@client::getName(%client)@" Logged In With The Password: "@%password);
		%client.isAdmin = true;
		messageall(0, client::getName(%client)@" Has Become A Public Admin~wCapturedTower.wav");
		Log::Admin(%client, %password, "Public");
		return;
	}

	else if(%password == $Admin::SuperPassword[%i] && $Admin::SuperPassword[%i] != "")
	{
		if(%client.isSuperAdmin)
		{
			client::sendMessage(%client, 0, "You are already a super admin~wCapturedTower.wav");
			return;
		}
		echo("SUPER ADMIN: "@client::getName(%client)@" Logged In With The Password: "@%password);
		%client.isAdmin = true;
		%client.isSuperAdmin = true;
		messageall(0, client::getName(%client)@" Has Become A Super Admin~wCapturedTower.wav");
		Log::Admin(%client, %password, "Super");
		return;
	}

	if(%password == $Admin::MasterPassword[%i] && $Admin::MasterPassword[%i] != "")
	{
		if(%client.isMasterAdmin)
		{
			client::sendMessage(%client, 0, "You are already a master admin~wCapturedTower.wav");
			return;
		}
		echo("MASTER ADMIN: "@client::getName(%client)@" Logged In With The Password: "@%password);
		%client.isAdmin = true;
		%client.isSuperAdmin = true;
		%client.isMasterAdmin = true;
		messageall(0, client::getName(%client)@" Has Become A Master Admin~wCapturedTower.wav");
		Log::Admin(%client, %password, "Master");
		return;
	}

	if(%password == $Admin::OwnerPassword[%i] && $Admin::OwnerPassword[%i] != "")
	{
		if(%client.isOwnerAdmin)
		{
			client::sendMessage(%client, 0, "You are already an owner admin~wCapturedTower.wav");
			return;
		}
		echo("OWNER ADMIN: "@client::getName(%client)@" Logged In With The Password: "@%password);
		%client.isAdmin = true;
		%client.isSuperAdmin = true;
		%client.isMasterAdmin = true;
		%client.isOwnerAdmin = true;
		messageall(0, client::getName(%client)@" Has Become An Owner Admin~wCapturedTower.wav");
		Log::Admin(%client, %password, "Owner");
		return;
	}
     }
     	echo("FAILED ADMIN LOGIN: "@client::getName(%client)@" Password: "@%password);
	client::sendMessage(%client, 1, "You Have "@9 - %client.passguess@" Tries Left Before You Are Kicked~wCapturedTower.wav");
	Log::Admin(%client, %password, "Failed");
	%client.passguess++;

	if(%client.passguess >= 10)
	{
		%name = client::getName(%client);
		kick(%client, "You Were Kicked For Spamming Admin Passwords");
		banlist::add(client::getTransportAddress(%client), 300);
		messageall(0, %name@" Was Kicked For Spamming Admin Passwords~wCapturedTower.wav");
	}
  }
}

function remoteSetPassword(%client, %password)
{
   if(%client.isSuperAdmin)
      $Server::Password = %password;
   if(!%client.isSuperAdmin)
   {
	Admin::Exploit(%client, "Remote Option (remoteSetPassword)");
   }
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
         messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s).~wCapturedTower.wav");
      else
         messageAll(0, Client::getName(%client) @ " disabled the time limit.~wCapturedTower.wav");
         
   }
   if(!%client.isAdmin)
   {
	Admin::Exploit(%client, "Remote Option (remoteSetTimeLimit)");
	return;
   }
}

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
   %str = %team @" "@%teamName@" "@%skinBase;
   if(String::containsCrash(%client, %str, "remoteSetTeamInfo"))
   {
	return false;
   }
   if(%team >= 0 && %team < 8 && %client.isAdmin)
   {
      $Server::teamName[%team] = %teamName;
      $Server::teamSkin[%team] = %skinBase;
      messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " 
         @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission.~wCapturedTower.wav");
   }
   if(!%client.isAdmin)
   {
	Admin::Exploit(%client, "Remote Option (remoteSetTeamInfo)");
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
            messageAll(0, "Match start countdown forced by vote.~wCapturedTower.wav");
         else
            messageAll(0, "Match start countdown forced by " @ Client::getName(%admin) @ "~wCapturedTower.wav");
      
         Game::ForceTourneyMatchStart();
      }
   } 
   if(!%admin.isAdmin && %admin != -1)
   {
	Admin::Exploit(%admin, "Admin Option (Force Match Start)");
	return;
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
            messageAll(0, "Team damage set to ENABLED by consensus.~wCapturedTower.wav");
         else
            messageAll(0, Client::getName(%admin) @ " ENABLED team damage.~wCapturedTower.wav");
      }
      else
      {
         $Server::TeamDamageScale = 0;
         if(%admin == -1)
            messageAll(0, "Team damage set to DISABLED by consensus.~wCapturedTower.wav");
         else
            messageAll(0, Client::getName(%admin) @ " DISABLED team damage.~wCapturedTower.wav");
      }
   }
   if(!%admin.isAdmin && %admin != -1)
   {
	Admin::Exploit(%admin, "Admin Option (Team Damage Switch)");
	return;
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

      %ip = Client::getTransportAddress(%client);
      if(%client.isSuperAdmin && %admin == -1)
      {
         messageAll(0, "A super admin cannot be " @ %word @ " by a vote.~wCapturedTower.wav");
         return;
      }

      if(%ip == "")
         return;
      if(%ban)
         BanList::add(%ip, 1800);
      else
         BanList::add(%ip, 180);

      %name = Client::getName(%client);

      if(%admin == -1)
      {
         MessageAll(0, %name @ " was " @ %word @ " from vote.~wCapturedTower.wav");
         Net::kick(%client, "You were " @ %word @ " by  consensus.");
      }
      else
      {
	 echo("KICK: "@client::getName(%admin)@" kicked "@%name);
         MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".~wCapturedTower.wav");
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
         messageAll(0, "Server switched to Free-For-All Mode.~wCapturedTower.wav");
      else
         messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".~wCapturedTower.wav");

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
         messageAll(0, "Server switched to Tournament Mode.~wCapturedTower.wav");
      else
         messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".~wCapturedTower.wav");

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
         messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.~wCapturedTower.wav");
         if($curVoteOption.menuMode == "options")
            Game::menuRequest($curVoteOption);
      }
      $curVoteOption.voteTarget = false;
   }
   else if($curVoteAction == "cmission")
   {
      messageAll(0, "Changing to mission " @ $curVoteOption @ ".~wCapturedTower.wav");
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
      messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.~wCapturedTower.wav");
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
            messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ ".~wCapturedTower.wav");
            Admin::voteSucceded();
            $curVoteTopic = "";
            return;
         }
      }
      messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.~wCapturedTower.wav");
      Admin::voteFailed();
   }
   $curVoteTopic = "";
}

function Admin::startVote(%clientId, %topic, %action, %option)
{	
   echo("VOTE: "@client::getName(%clientId)@" Started A Vote To "@%topic);
   if(!$Server::VotingEnabled && %action != "kick")
   {
	Admin::Exploit(%clientId, "Vote Option (Voting When Voting Disabled)");
	return;
   }
   if(%clientId.lastVoteTime == "")
      %clientId.lastVoteTime = -$Server::MinVoteTime;

   // we want an absolute time here.
   %time = getIntegerTime(true) >> 5;
   %diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time;

   if(%diff > 0)
   {
      Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.~wCapturedTower.wav");
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
      bottomprintall("<jc><f1>" @ String::remove("<", string::remove(">", client::getName(%clientId))) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
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
      Client::sendMessage(%clientId, 0, "Voting already in progress.~wCapturedTower.wav");
   }
}

function Game::menuRequest(%clientId)
{
   %clientId.gtries++;
   if(%clientId.gtries > 10)
   {
	if(%clientId.gone)
	{
		return;
	}
	%name = client::getName(%clientId);
	Log::Exploit(%clientId, "Server-Crash", "remoteScoresOn");
	banlist::add(client::getTransportAddress(%clientId), 999);
	kick(%clientId, "You Were Kicked For Spamming remoteScoresOn");
	%clientId.gone = true;
	return;
   }
   schedule(%clientId@".gtries = 0;", 0.5);

   if(%clientId.possessed)
   {
	return;
   }
   %curItem = 0;
   Client::buildMenu(%clientId, "Options", "options", true);
   if(!$matchStarted && !%clientId.selClient || !$Server::TourneyMode && !%clientId.selClient)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
   }
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

      if($curVoteTopic == "" && !%clientId.isAdmin)
      {
    	 if($Server::VotingEnabled)
	 {
         	Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
         } 
	 Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
      }
      if(%clientId.isAdmin)
      {
         if(client::getAdminLevel(%clientId) > client::getAdminLevel(%sel) || %clientId.isOwnerAdmin)
	 {
         	Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
         	if(%clientId.isSuperAdmin)
         	{
         	   Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
         	   Client::addMenuItem(%clientId, %curItem++ @ "Admin Options - " @ %name, "AdminStatus " @ %sel);
         	}
      	 }
	 Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
      }
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
      if(%clientId.observerMode == "observerOrbit")
         Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
      if(%clientId.isSuperAdmin)
      {
	  if(client::getAdminLevel(%clientId) > client::getAdminLevel(%sel) || %clientId.isOwnerAdmin)
	  {
	   	client::addMenuItem(%clientId, %curItem++ @ "Manipulate "@%name, "manip "@%sel);
      	  }
      }
      if(%clientId.isAdmin)
      {
	  client::addMenuItem(%clientId, %curItem++ @ "Show Player Alias's", "showalias "@%sel);
      }
      return;
   }
   if($curVoteTopic != "" && %clientId.vote == "")
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }
   else if($curVoteTopic == "" && !%clientId.isAdmin && $Server::VotingEnabled)
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
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
      } 
   }
   if(!%clientId.isAdmin)
   {
	Client::addMenuItem(%clientId, %curItem++ @ "ObserveMode: Setup", "misc");
        Client::addMenuItem(%clientId, %curItem++ @ "T-Mail", "tmail");
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
      Client::addMenuItem(%clientId, %curItem++ @ "ObserveMode: Setup", "misc");  
      Client::addMenuItem(%clientId, %curItem++ @ "More Options", "MOptions");
   }
}

function remoteSelectClient(%clientId, %selId)
{
   %clientId.tries++;
   if(%clientId.tries > 10)
   {
	if(%clientId.gone)
	{
		return;
	}
	%name = client::getName(%clientId);
	Log::Exploit(%clientId, "Server-Crash", "remoteSelectClient");
	banlist::add(client::getTransportAddress(%clientId), 999);
	kick(%clientId, "You Were Kicked For Spamming remoteSelectClient");
	%clientId.gone = true;
	return;
   }
   schedule(%clientId@".tries = 0;", 0.5);

   if(%clientId.selClient != %selId)
   {
      %clientId.selClient = %selId;
      if(%clientId.menuMode == "options")
      {
         Game::menuRequest(%clientId);
      }
      %addr = Client::getTransportAddress(%selId);
      remoteEval(%clientId, "setInfoLine", 1, Client::getName(%selId) @ " (" @ $Client::info[%selId, 0] @ ")");
      remoteEval(%clientId, "setInfoLine", 2, "Deaths:" @ %selId.ScoreDeaths @ "     Kills:" @ %selId.ScoreKills);
      remoteEval(%clientId, "setInfoLine", 3, "Returns:" @ %selId.ScoreReturns @ "    Caps:" @ %selId.ScoreCaps);
      remoteEval(%clientId, "setInfoLine", 4, "Total Score:" @ %selId.score);
      if(%clientId.isSuperAdmin)
      {
      	remoteEval(%clientId, "setInfoLine", 5, "IP Addr: " @ %addr);
      	remoteEval(%clientId, "setInfoLine", 6, "Smurf: " @ client::getAlias(%selId));
      }
   }
}


function processMenuFPickTeam(%clientId, %team)
{
   if(!%clientId.isAdmin)
   {
	Admin::Exploit(%clientId, "Admin Option (Force Team Change)");
	return;
   }
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
            messageAll(0, Client::getName(%clientId) @ " became an observer.~wCapturedTower.wav");
         else
            messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".~wCapturedTower.wav");
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
      messageAll(0, Client::getName(%clientId) @ " changed teams.~wCapturedTower.wav");
   else
      messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".~wCapturedTower.wav");

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

function processMenummisc(%clientId, %option) { 
	%o = getWord(%option, 0); 
	%extra = getWord(%option, 1); 
	 if(%o == "view") 
		activeOptions(%clientId, 20);
	else if(%o == "obsm") {
		if(%clientId.obsmode == "") %clientId.obsmode = "Fixed";
		Client::buildMenu(%clientId, "Current mode: " @ %clientId.obsmode, "mmisc", true); 
		Client::addMenuItem(%clientId, "1Free", "setmode Free"); 
		Client::addMenuItem(%clientId, "2Fixed", "setmode Fixed"); 
		Client::addMenuItem(%clientId, "31st Person", "setmode 1stPerson"); 
	} else if(%o == "setmode") {
		if(%clientId.obsmode == %extra)
			Client::sendMessage(%clientId, 0,"Your Observer Mode is Already Set to " @ %extra @ "."); 		
		else {
			%clientId.obsmode = %extra;
			if(%clientId.wat) setObsOrbit(%clientId, %clientId.wat, 5, 5, 5);
			if(%clientId.observerMode == "observerOrbit") setObsOrbit(%clientId, %clientId.observerTarget, 5, 5, 5);
			Client::sendMessage(%clientId, 0,"Your Observer Mode has been Set to " @ %extra @ "."); 
		}		
	}
}

function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   %clname = client::getName(%cl);
   if(%opt == "fteamchange")
   {
      if(%cl.isFrozen)
      {
	  if(%cl != %clientId)
	  {
		client::sendMessage(%clientId, 3, %clname@" is frozen and may not have his team switched.~wCapturedTower.wav");
	 	return;
	  }
	  else if(%cl == %clientId)
          {
		client::sendMessage(%clientId, 1, "Nice try, but this won't work either, you're still frozen ;)~wCapturedTower.wav");
		return;
	  }
      }
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
      Client::addMenuItem(%clientId, "0Observer", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      return;
   } 
   else if(%opt == "MOptions")
   {
        Client::buildMenu(%clientId, "More Options:", "options", true);
	Client::addMenuItem(%clientId, %curItem++ @ "T-Mail", "tmail");
        if(%clientId.isSuperAdmin)
        { 
		if(!$Server::VotingEnabled && $ClanMatch == "" && !$ClanMatchRunning)
		{
			client::addMenuItem(%clientId, %curItem++ @ "Enable Voting", "evoting");
		}
		else if($Server::VotingEnabled && $ClanMatch == "" && !$ClanMatchRunning)
		{
			client::addMenuItem(%clientId, %curItem++ @ "Disable Voting", "dvoting");
		}
        	if(!$ClanMatchRunning && %clientId.isMasterAdmin)
		{
      			client::addMenuItem(%clientId, %curItem++ @ "Start Clan Match", "sclanMatch");
        	}
		else if($ClanMatchRunning && %clientId.isMasterAdmin)	
		{
			client::addMenuItem(%clientId, %curItem++ @ "End Clan Match", "eclanMatch");
		}
      	}
	return;
   }
   else if(%opt == "manip")
   {
	client::buildMenu(%clientId, "Manipulate "@%clname, "manipulation", true);
	client::addMenuItem(%clientId, %curItem++ @"Kill "@%clname, "kill "@%cl);
	if(!%cl.isFrozen)
	{
		client::addMenuItem(%clientId, %curItem++ @"Freeze "@%clname, "freeze "@%cl);
	}
	else if(%cl.isFrozen)
	{
		client::addMenuItem(%clientId, %curItem++ @"Defrost "@%clname, "defrost "@%cl);
	}
	client::addMenuItem(%clientId, %curItem++ @ "Strip "@%clname, "strip "@%cl);
	client::addMenuItem(%clientId, %curItem++ @ "Slap "@%clname, "slap "@%cl);
	if(!%cl.isGagged)
	{
		client::addMenuItem(%clientId, %curItem++ @ "Gag "@%clname, "gag "@%cl);
	}
	else if(%cl.isGagged)
	{
		client::addMenuItem(%clientId, %curItem++ @ "Un-Gag "@%clname, "ungag "@%cl);
	}
	client::addMenuItem(%clientId, %curItem++ @ "Boost "@%clname, "boost "@%cl);
	if(%clientId.isMasterAdmin)
	{
		client::addMenuItem(%clientId, %curItem++ @ "More Options", "moreoptions "@%cl);
	}
	return;
   }
   else if(%opt == "tmail")
   {
	Client::sendMessage(%clientId, 1, "T-Mail is switched off in this port."); // PORT: it keyed accounts on player-info field 5, see fixes.json
	//PORT-OFF: BuildTmailMenu(%clientId);
	return;
   } 
   else if(%opt == "dvoting")
   {
	if(%clientId.isSuperAdmin)
	{
		$Server::VotingEnabled = false;
		messageall(0, "Voting was disabled by "@client::getName(%clientId)@"~wCapturedTower.wav");
		return;
	}
	Admin::Exploit(%clientId, "Admin Option (Disable Voting)");
  	return;
   }
   else if(%opt == "evoting")
   {
	if(%clientId.isSuperAdmin)
	{
		$Server::VotingEnabled = true;
		messageall(0, "Voting was enabled by "@client::getName(%clientId)@"~wCapturedTower.wav");
		return;
	}
	Admin::Exploit(%clientId, "Admin Option (Enable Voting)");
  	return;
   }
   else if(%opt == "showalias")
   {
	if(%clientId.isAdmin)
	{
		client::sendMessage(%clientId, 0, "Alias's: "@client::getAlias(%cl));
		return;
	}
	Admin::Exploit(%clientId, "Admin Option (Show Alias's)");
	return;
   }
   else if(%opt == "sclanMatch")
   {
	client::buildMenu(%clientId, "Confirm Start Match:", "cMatchStart", true);
	client::addMenuItem(%clientId, %curItem++ @ "Start Match", "smatch");
	client::addMenuItem(%clientId, %curItem++ @ "Don't Start Match", "dmatch");
	return;
   }
   else if(%opt == "eclanMatch")
   {
	client::buildMenu(%clientId, "Confirm End Match:", "cMatchStart", true);
	client::addMenuItem(%clientId, %curItem++ @ "End Match", "ematch");
	client::addMenuItem(%clientId, %curItem++ @ "Don't End Match", "dematch");
	return;
   } 
   else if(%opt == "changeteams")
   {
      if(%clientId.isFrozen)
      {
	  client::sendMessage(%clientId, 1, "No changing teams while you are frozen ;) ~wCapturedTower.wav");
	  return;
      }
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
   else if(%opt == "AdminStatus")
   {
      Client::buildMenu(%clientId, "Select Admin Option:", "aaffirm", true);
      if(!%cl.isOwnerAdmin)
      {
      	Client::addMenuItem(%clientId, %curItem++ @"Admin " @ Client::getName(%cl), "yes " @ %cl);
      }
      if(%cl.isAdmin)
      {
	Client::addMenuItem(%clientId, %curItem++ @"De-Admin " @ Client::getName(%cl), "no " @ %cl);
      }
      return;
   }
   else if(%opt == "ban")
   {
      client::buildMenu(%clientId, "Choose Ban Type:", "banType", true);
      client::addMenuItem(%clientId, %curItem++ @ "Permanent Ban", "ban "@%cl@" Permanent");
      client::addMenuItem(%clientId, %curItem++ @ "Temporary Ban", "ban "@%cl@" Temporary");
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
        else if(%opt == "misc") {
		%i = 0;
		Client::buildMenu(%clientId, "Observer Setup:", "mmisc", true); 
		Client::addMenuItem(%clientId, %i++ @ "Observer Mode...", "obsm"); 
		return;
	}
   Game::menuRequest(%clientId);
}

function processMenuManipulation(%clientId, %option)
{
        if(!%clientId.isSuperAdmin)
	{
		Admin::Exploit(%clientId, "Manipulation Option ("@getWord(%option, 0)@")");
		return;
	}
	if(client::getAdminLevel(%clientId) <= client::getAdminLevel(getWord(%option, 1)) && client::getAdminLevel(%clientId) != "4") // Owners can do whatever they want to whoever they want
	{
		client::sendMessage(%clientId, 0, "You may not manipulate "@client::getName(getWord(%option, 1))@" due to "@client::Gender(getWord(%option, 1))@" admin status~wCapturedTower.wav");
		return;
	}

	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	%clname = client::getName(%cl);
	%adname = client::getName(%clientId);
	
	if(%opt == "moreoptions")
	{
		if(!%clientId.isMasterAdmin)
		{
			Admin::Exploit(%clientId, "Manipulation Option (More Options)");
			return;
		}
		if(client::getAdminLevel(%clientId) <= client::getAdminLevel(%cl) && client::getAdminLevel(%clientId) != "4") // Owners can do whatever they want to whoever they want
		{
			client::sendMessage(%clientId, 0, "You may not manipulate "@%clname@" due to "@client::gender(%cl)@" admin status~wCapturedTower.wav");
			return;
		}
		client::buildMenu(%clientId, "More Options:", "ManipulationMore", true);
		client::addMenuItem(%clientId, %curItem++ @ "Set "@%clname@" On Fire", "SetOnFire "@%cl);
		if(!%cl.possessed)
		{
			client::addMenuItem(%clientId, %curItem++ @ "Possess "@%clname, "possess "@%cl);
			
		}
		else if(%cl.possessed)
		{
			client::addMenuItem(%clientId, %curItem++ @ "Stop Possessing "@%clname, "unpossess "@%cl);
		}
		if(%clientId.isOwnerAdmin)
		{
			client::addMenuItem(%clientId, %curItem++ @ "Make Him A Firework", "firework "@%cl);
			client::addMenuItem(%clientId, %curItem++ @ "Make Him A Timebomb", "timebomb "@%cl);
		}
		return;
	}
	if(%opt == "freeze")
	{
		echo("MANIPULATION: "@%adname@" froze "@%clname);
	}
	else if(%opt == "gag")
	{
		echo("MANIPULATION: "@%adname@" gagged "@%clname);
	}
	else if(%opt == "ungag")
	{
		echo("MANIPULATION: "@%adname@" ungagged "@%clname);
	}
	else if(%opt == "strip")
	{
		echo("MANIPULATION: "@%adname@" stripped "@%clname@" of "@client::gender(%cl)@" items");
	}
	else if(%opt == "boost")
	{
	}
	else
        {
	  echo("MANIPULATION: "@client::getName(%clientId)@" "@%opt@"ed "@%clname);
	}
	if(%opt == "kill")
	{
 		MessageAllExcept(%cl , 1, %clname@" Turned into Dust by "@%adname@".~wfemale5.wtaunt1.wav");
 		Client::sendMessage(%cl ,3,"You Have Been Slayed By "@%adname@".~wfemale4.wdeath.wav");
		remoteKill(%cl);
	}
	
	else if(%opt == "slap")
	{
 		MessageAllExcept(%cl , 1, %clname@" has been slapped to 1% health by "@%adname@".~wfemale5.wtaunt1.wav");
 		Client::sendMessage(%cl ,3,"You have been slapped to 1% health by "@%adname@".~wfemale4.wdeath.wav");
		%velocity = 150;
		%zVec = 40;
		%vector = Vector::getFromRot(GameBase::getRotation(%cl), %velocity, %zVec);
		Player::applyImpulse(%cl, %vector);
		Player::setDamageFlash(%cl, 0.75);
		gameBase::setDamageLevel(client::getOwnedObject(%cl), 0.659);
	}

	else if(%opt == "freeze")
	{
 		MessageAllExcept(%cl , 1, %clname@" has been frozen by "@%adname@".~wfemale5.wtaunt1.wav");
 		Client::sendMessage(%cl ,3,"You have been frozen by "@%adname@".~wfemale4.wdeath.wav");
		%cl.observerMode = "pregame";
		%cl.isFrozen = true;
	        Client::setControlObject(%cl, Client::getObserverCamera(%cl));
	        Observer::setOrbitObject(%cl, %cl, 3,3,3);
	}

	else if(%opt == "defrost")
	{
 		MessageAllExcept(%cl , 1, %clname@" has been defrosted by "@%adname@".~wCapturedTower.wav");
 		Client::sendMessage(%cl ,3,"You have been defrosted by "@%adname@".~wCapturedTower.wav");
		%cl.observerMode = "";
		%cl.isFrozen = false;
		Client::setControlObject(%cl, client::getOwnedObject(%cl));
	}

	else if(%opt == "gag")
	{
 		MessageAllExcept(%cl , 1, %clname@" has been gagged by "@%adname@".~wfemale5.wtaunt1.wav");
 		Client::sendMessage(%cl ,3,"You have been gagged by "@%adname@".~wfemale4.wdeath.wav");
		%cl.isGagged = true;
	}

	else if(%opt == "ungag")
	{
 		MessageAllExcept(%cl , 1, %clname@" has been ungagged by "@%adname@".~wCapturedTower.wav");
 		Client::sendMessage(%cl ,3,"You have been ungagged by "@%adname@".~wCapturedTower.wav");
		%cl.isGagged = false;
	}

	else if(%opt == "strip")
	{
 		MessageAllExcept(%cl , 1, %clname@" has been stripped of his/her items by "@%adname@".~wfemale5.wtaunt1.wav");
 		Client::sendMessage(%cl ,3,"You have been stripped of your items by "@%adname@".~wfemale4.wdeath.wav");
		Strip(%cl);
	}

	else if(%opt == "boost")
	{
		Client::buildMenu(%clientId, "Boost Options:", "Bopts", true);
		Client::addMenuItem(%clientId, %curItem++ @ "20 feet", "20 " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "500 feet", "500 " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "Off The Map", "OTM " @ %cl);
		return;
	}
}

function processMenuManipulationMore(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	%clname = client::getName(%cl);	
	%adname = client::getName(%clientId);

	if(!%clientId.isMasterAdmin)
	{
		Admin::Exploit(%clientId, "Manipulation Option ("@%opt@")");
		return;
	}

	if(client::getAdminLevel(%clientId) <= client::getAdminLevel(%cl) && !%clientId.isOwnerAdmin) // Owners can do whatever they want to whoever they want
	{
		client::sendMessage(%clientId, 0, "You may not manipulate "@%clname@" due to "@client::gender(%cl)@" admin status~wCapturedTower.wav");
		return;
	}	
	
	if(%opt == "possess" && !%cl.possessed)
	{
		Possess(%clientId, %cl, true);
	}
	
	else if(%opt == "unpossess" && %cl.possessed)
	{
		Possess(%clientId, %cl, false);
	}

	else if(%opt == "SetOnFire")
	{
		SetOnFire(%clientId, %cl);
	}

	else if (%opt == "timebomb") // THE HARDEST OPTION I HAVE EVER DONE
	{
		client::buildMenu(%clientId, "Choose Bomb Type:", "CBombType", true);
		client::addMenuItem(%clientId, %curItem++ @ "Small Bomb", "SBomb "@%cl);
		client::addMenuItem(%clientId, %curItem++ @ "Big Bomb", "BBomb "@%cl);
		client::addMenuItem(%clientId, %curItem++ @ "Nuke", "BOOM "@%cl);
		return;
	}

	else if(%opt == "firework")
	{
		FireWork(%clientId, %cl);
	}
}

function FireWork(%clientId, %cl)
{
	if(%cl != %clientId.selClient)
	{
		client::sendMessage(%clientId, 1, "Go Fuck Yourself.");
		return;
	}
	%name = client::getName(%clientId);
	%firework = client::getName(%cl);
	echo(%name @" Turned "@%firework@" Into A Firework");
	centerprint(%cl, "<jc><F2>Going Up", 5);
 	MessageAllExcept(%cl , 1, %firework@" has been turned into a Firework by "@%name@".~wfemale5.wtaunt1.wav");
 	Client::sendMessage(%cl ,3,"You have been turned into a Firework by "@%name@".~wfemale4.wdeath.wav");
	schedule("Explode1("@%cl@");",3);
	JetSmoke(client::getOwnedObject(%cl));
}

function Explode1(%cl)
{
	$Blowtime = 0;
	%velocity = 0;
	%zVec = 999;
	%vector = Vector::getFromRot(GameBase::getRotation(%cl), %velocity, %zVec);
	Player::applyImpulse(%cl, %vector);
	%cl.Immortal = true;
	Player::BlowUp(%cl);
	schedule("Sparks("@%cl@");",2.1);
	schedule("Sparks("@%cl@");",2.3);
}

function Sparks(%cl)
{
	%trans = GameBase::getMuzzleTransform(%cl);
	%client = GameBase::getOwnerClient(%cl);
	%player = client::getOwnedObject(%client);
	%vel = 200;
	nothing(%trans, %vel, %client, %player);
}
function nothing(%trans, %vel, %client, %player)
{
	$Blowtime++;
	ExpEffect(%client);
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired.deployer = %client;
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%cl,%player));
	if($BlowTime > 1)
	{
		%client.immortal = false;
		Player::Kill(%client);
	}
}


function processMenuCBombType(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(!%clientId.isOwnerAdmin)
	{
		Admin::Exploit(%clientId, "Manipulation Option (Turn Into Bomb)");
		return;
	}
	
	if(%cl != %clientId.selClient)
	{
		client::sendMessage(%clientId, 1, "Go fuck yourself.");
		return;
	}
	if(%opt == "SBomb")
	{
		%admin = client::getName(%clientId);
		%victim = client::getName(%cl);
 		MessageAllExcept(%cl , 1, "WARNING: "@%admin@" has turned "@victim@" into a small ticking time bomb, He won't hurt you much.~wfemale5.wtaunt1.wav");
		client::sendMessage(%cl, 1, "WARNING: "@%admin@" Made You A Small Ticking Time Bomb~wfemale4.wdeath.wav");
		%timetoboom = 10;
		%radius = 100;
		//echo(%radius);
		DisplayTimeToBoom(%cl, %timetoboom, %radius);
	}
	else if(%opt == "BBomb")
	{
		%admin = client::getName(%clientId);
		%victim = client::getName(%cl);
		MessageAllExcept(%cl , 1, "WARNING: "@%admin@" has turned "@victim@" into a big ticking time bomb, Get away from him!.~wfemale5.wtaunt1.wav");
		client::sendMessage(%cl, 1, "WARNING: "@%admin@" Made You A Big Ticking Time Bomb~wfemale4.wdeath.wav");
		%timetoboom = 10;
		%radius = 500;
		//echo(%radius);
		DisplayTimeToBoom(%cl, %timetoboom, %radius);
	}
	else if(%opt == "BOOM")
	{
		%admin = client::getName(%clientId);
		%victim = client::getName(%cl);
		MessageAllExcept(%cl , 1, "WARNING: "@%admin@" has turned "@victim@" into a NUKE BOMB, God Have Mercy On You All.~wfemale5.wtaunt1.wav");
		client::sendMessage(%cl, 1, "WARNING: "@%admin@" Made You A NUKE BOMB~wfemale4.wdeath.wav");
		%timetoboom = 10;
		%radius = 99999999;  // Everyone and everythings gonna die lol
		//echo(%radius);
		DisplayTimeToBoom(%cl, %timetoboom, %radius);
	}
}


function GKExplosion::Detonate(%this)
{
	%cl = %this.deployer;
	%player = client::getownedobject(%cl);
	%vel = "0 0 0";
	if (!%player)
		return;
	%pos1 = gamebase::getposition(%this);
	%rot = (gamebase::getrotation(%this));
	%dir = (Vector::getfromrot(%rot));
	%trans1 = (%rot @ " " @ %dir @ " " @ %rot);
	%padd = "0 0 2.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(GKEffect, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
}
function DisplayTimeToBoom(%cl, %timetoboom, %radius)
{
	//echo(%radius);
	if(%timetoboom > 0)
	{
		BottomPrintAllExcept(%cl, "<jc><F0>"@client::getName(%cl)@" Will Explode In: <F2>"@%timetoboom@"");
		BottomPrint(%cl, "<jc><F0>You Will Explode In: <F2>"@%timetoboom@"");
		%timetoboom = %timetoboom--;
		schedule("DisplayTimeToBoom("@%cl@", "@%timetoboom@", "@%radius@");",1);
	}
	else if(%timetoboom <= 0)
	{
		BottomPrintAll("", 0);
		ConvertToBoom(%cl, %radius);
	}
}
function BottomPrintAllExcept(%except, %message, %timeout)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      if(%cl != %except)
         BottomPrint(%cl, %message, %timeout);
}
	
function ConvertToBOOM(%cl, %radius)
{
	// DEFINE VARS
	//echo("Radius: "@%radius);
	%object = client::getOwnedObject(%cl); // Get ObjectID From ClientID
	%center = getBoxCenter(%object);       // Get The Center Of The Object From The ObjectID
	%damageValue = 100;           // The Value Of Damage To Apply At The Center Of The Object
	%appliedforce = 100;          // The Amount Of Force To Apply To Surrounding Objects
	Player::blowUp(%cl);                   // Sets The Client To Blow Up When They Next Die
	if(%radius == 500)
	{
		%type = "Big";
	}
	else if(%radius == 100)
	{
		%type = "Small";
	}
	else if(%radius == 99999999)
	{
		%type = "Nuke";
	}
	//echo("Type: "@%type);
	FancyExp(%cl, %type);
	GameBase::applyRadiusDamage(%do-not-remove, %center, %radius, %damageValue, %appliedforce, %object);
	playNextAnim(%cl);
}

function FancyExp(%cl, %type)
{
	//echo(%type);
	if(%type == "Small")
	{
		ExpEffect(%cl);
	}
	else if(%type == "Big")
	{
		echo("Called Right Type");
		ExpEffect(%cl);
		ShockEffect(%cl);
	}
	else if(%type == "Nuke")
	{
		ExpEffect(%cl);
		ExpEffect2(%cl);
		ShockEffect(%cl);
		ShockEffect2(%cl);
	}
}
function ShockEffect2(%cl)
{
	//echo("Called ExpEffect");
	%spriteobj[%cl] = newObject("","Mine","ShockExplosion1");
	%playerposition = GameBase::getPosition(%cl);
	%xcoord = getWord(%playerposition,0);
	%ycoord = getWord(%playerposition,1);
	%zcoord = getWord(%playerposition,2) + 0.1;
	%GKExplosionPosition = sprintf("%1 %2 %3",%xcoord, %ycoord, %zcoord);
	GameBase::setPosition(%spriteobj[%cl],%GKExplosionPosition);
	schedule("ShockExplosion::Detonate("@%spriteobj[%cl]@");",0.1, %spriteobj[%cl]);
	$GKCurrentExplosion[%cl] = true;
	Schedule("$GKCurrentExplosion[" @ %cl @ "] = false;",25.0);
}
function ExpEffect(%cl)
{
	//echo("Called ExpEffect");
	%spriteobj[%cl] = newObject("","Mine","GKExplosion");
	%playerposition = GameBase::getPosition(%cl);
	%xcoord = getWord(%playerposition,0);
	%ycoord = getWord(%playerposition,1);
	%zcoord = getWord(%playerposition,2) + 0.1;
	%GKExplosionPosition = sprintf("%1 %2 %3",%xcoord, %ycoord, %zcoord);
	GameBase::setPosition(%spriteobj[%cl],%GKExplosionPosition);
	GKExplosion::Detonate(%spriteobj[%cl]);
	$GKCurrentExplosion[%cl] = true;
	Schedule("$GKCurrentExplosion[" @ %cl @ "] = false;",25.0);
}
function ExpEffect2(%cl)
{
	//echo("Called ExpEffect");
	%spriteobj[%cl] = newObject("","Mine","GKExplosion");
	%playerposition = GameBase::getPosition(%cl);
	%xcoord = getWord(%playerposition,0);
	%ycoord = getWord(%playerposition,1);
	%zcoord = getWord(%playerposition,2) + 0.1;
	%GKExplosionPosition = sprintf("%1 %2 %3",%xcoord, %ycoord, %zcoord);
	GameBase::setPosition(%spriteobj[%cl],%GKExplosionPosition);
	schedule("GKExplosion::Detonate("@%spriteobj[%cl]@");",0.1, %spriteobj[%cl]);
	$GKCurrentExplosion[%cl] = true;
	Schedule("$GKCurrentExplosion[" @ %cl @ "] = false;",25.0);
}
function ShockEffect(%cl)
{
	//echo("Called ExpEffect");
	%spriteobj[%cl] = newObject("","Mine","ShockExplosion1");
	%playerposition = GameBase::getPosition(%cl);
	%xcoord = getWord(%playerposition,0);
	%ycoord = getWord(%playerposition,1);
	%zcoord = getWord(%playerposition,2) + 0.1;
	%GKExplosionPosition = sprintf("%1 %2 %3",%xcoord, %ycoord, %zcoord);
	GameBase::setPosition(%spriteobj[%cl],%GKExplosionPosition);
	ShockExplosion::Detonate(%spriteobj[%cl]);
	$GKCurrentExplosion[%cl] = true;
	Schedule("$GKCurrentExplosion[" @ %cl @ "] = false;",25.0);
}
function ShockExplosion::Detonate(%this)
{
	%cl = %this.deployer;
	%player = client::getownedobject(%cl);
	%vel = "0 0 0";
	if (!%player)
		return;
	%pos1 = gamebase::getposition(%this);
	%rot = (gamebase::getrotation(%this));
	%dir = (Vector::getfromrot(%rot));
	%trans1 = (%rot @ " " @ %dir @ " " @ %rot);
	%padd = "0 0 0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(ShockEffect, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.01);
}


function SetOnFire(%clientId, %cl)
{
	if(%cl != %clientId.selClient)
	{
		client::sendMessage(%clientId, 1, "Go fuck yourself.");
		return;
	}
	%AdminName = Client::getName(%clientId);
	%name1 = Client::getName(%cl);
	echo("MANIPULATION: "@%adminname@" set "@%name1@" on fire");
 		MessageAllExcept(%cl , 1, %name1@" has been set on fire by "@%AdminName@".~wfemale5.wtaunt1.wav");
 		Client::sendMessage(%cl ,3,"You have been set on fire by "@%AdminName@".~wfemale4.wdeath.wav");
	BurnTheFlesh(%clientId, %cl);
	%player = client::getOwnedObject(%cl);
	Plasmafire(%player);
}

//Thanks Plasmatic -WorstAim
//Plas's Plasmafire function

function Plasmafire(%player)
{
	//plasmatic
	if(Player::isDead(%player))
		return;
	%player.onfire = %player.onfire -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	if($burnTime[%player] > 0 )
	{
		Projectile::spawnProjectile("AnnihilationFlame", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	}
	
}

function JetSmoke(%player)
{
	//plasmatic
	if($BlowTime < 1)
		return;
	%player.onfire = %player.onfire -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("JetSmoke", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	schedule("$jetsmoketime--;", 1);
	schedule("JetSmoke("@%player@");",0.1);
}

function BurnTheFlesh(%clientId, %cl)
{
	%player = Client::getOwnedObject(%cl);
	Player::setDamageFlash(%player, 0.25);
	$burnTime[%player] = 220;
	checkPlayerBurn(%clientId, %player);
}

function checkPlayerBurn(%clientId, %player)
{	
	if($burnTime[%player] > 0)
	{
		$burnTime[%player] -= 2;  
		%drrate = GameBase::getDamageLevel(%player) + 0.003;
		if(!Player::isDead(%player)) 
		{
			GameBase::setDamageLevel(%player, %drrate);  
			Player::setDamageFlash(%player,0.75); 
			schedule("PlasmaFire("@%player@");",0.1);

		}
		schedule("checkPlayerBurn(" @ %clientId @ ", " @ %player @ ");",0.1,%player);
      	}
	else if($burnTime[%player] == 0)
	{
		Client::sendMessage(player::getClient(%player), 1, "Ouch.");
		
	}

	if(gamebase::getDamageLevel(%player) > 0.65)
	{
		%curdie = $PlayerAnim::DieChest;
		%this = player::getClient(%player);
		Player::setAnimation(%this, %curDie);
		%this.scoreDeaths++;
      		%this.score--;
		Game::refreshClientScore(%this);
		client::sendMessage(%this, 1, "You have been toasted");
		player::kill(%this);
	}					
}

ExplosionData smExp
{
   shapeName = "rsmoke.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 10;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

GrenadeData JetSmoke
{
   bulletShapeName    = "breath.dts";
   explosionTag       = smExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $NullDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};

ExplosionData AnnihilationFlameExp
{
   shapeName = "plasmatrail.dts";

   faceCamera = false;
   randomSpin = false;
   hasLight   = false;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0, 1.0,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = true;
};

GrenadeData AnnihilationFlame
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = AnnihilationFlameExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};

function Possess(%clientId, %cl, %pos)
{
   %adname = client::getName(%clientId);
   %clname = client::getName(%cl);
   if(%pos)
   {

	if(Client::getControlObject(%cl) != Client::getOwnedObject(%cl)) 
	{
		Client::sendMessage(%clientId,1,"Unable to possess - Player currently is not in control of themselves~waccess_denied.wav"); 	
		Game::menuRequest(%clientId); 
		return;
	}		
	if(Client::getControlObject(%clientId) != Client::getOwnedObject(%clientId) && !Observer::isObserver(%clientId)) 
	{
		Client::sendMessage(%clientId,1,"Unable to possess - You are currently not controlling your player~waccess_denied.wav"); 	
		Game::menuRequest(%clientId); 
		return;
	}
	echo("MANIPULATION: "@%adname@" is possessing "@%clname);	
        Client::setControlObject(%cl, Client::getObserverCamera(%cl));
        Observer::setOrbitObject(%cl, Client::getOwnedObject(%cl), 3, 3, 3);
	Client::setControlObject(%clientId, %cl);
	%cl.possessed = true;
	%cl.possby = %clientId;
	%clientId.poss = %cl;
	%clientId.possessing = true;
	messageall(0, Client::getName(%cl) @ " has been possessed by " @ Client::getName(%clientId) @ ".~wteleport2.wav"); 
   }
   else if(!%pos)
   {
	echo("MANIPULATION: "@%adname@" has released "@%clname@" from possession");
	Client::setControlObject(%clientId, %clientId);
        Client::setControlObject(%cl, %cl);
	%cl.possessed = false;
	%cl.possby = "";
	%clientId.possessing = false;
	%clientId.poss = "";
	messageAll(0, client::getName(%clientId)@" has stopped possessing "@client::getName(%cl)@"~wCapturedTower.wav");
   }
}
	

function processMenuBopts(%clientId, %option)
{
	if(!%clientId.isSuperAdmin) // Just to be safe
	{
		Admin::Exploit(%clientId, "Manipulation Option (Boost "@getWord(%option, 0)@" Feet)");
		return;
	}
	
	%cl = getWord(%option, 1);
	%opt = getWord(%option, 0);
	%clname = client::getName(%cl);
	%adname = client::getName(%clientId);

	if(%opt == "OTM")
	{
		Admin::BoostOffTheMap(%clientId, %cl);
		echo("MANIPULATION: "@%adname@" boosted "@%clname@" off the map");
	}
	else
	{
		echo("MANIPULATION: "@%adname@" boosted "@%clname@" "@%opt@" feet");
	}

	if(%opt == "20")
	{
		Admin::Boost20Feet(%clientId, %cl);
	}
	else if(%opt == "500")
	{
		Admin::Boost200Feet(%clientId, %cl);
	}
}
		

function Admin::Boost20Feet(%clientId, %cl)
{
	%player = %cl;
	%name = Client::getName(%player);
     	%AdminName = Client::getName(%clientId);
	%velocity = 200;
	%zVec = 50;
	%vector = Vector::getFromRot(GameBase::getRotation(%player), %velocity, %zVec);
	Player::applyImpulse(%player, %vector);
 	MessageAllExcept(%cl , 1, %name@" has been boosted 20 feet by "@%AdminName@".~wfemale5.wtaunt1.wav");
 	Client::sendMessage(%cl ,3,"You have been boosted 20 feet by "@%AdminName@".~wfemale4.wdeath.wav");
}

function Admin::Boost200Feet(%clientId, %cl)
{
	%player = %cl;
	%name = Client::getName(%player);
     	%AdminName = Client::getName(%clientId);
	%velocity = 600;
	%zVec = 500;
	%vector = Vector::getFromRot(GameBase::getRotation(%player), %velocity, %zVec);
	Player::applyImpulse(%player, %vector);
 	MessageAllExcept(%cl , 1, %name@" has been boosted 500 feet by "@%AdminName@".~wfemale5.wtaunt1.wav");
 	Client::sendMessage(%cl ,3,"You have been boosted 500 feet by "@%AdminName@".~wfemale4.wdeath.wav");
}

function Admin::BoostOffTheMap(%clientId, %cl)
{
	%player = %cl;
	%name = Client::getName(%player);
     	%AdminName = Client::getName(%clientId);
	%velocity = 9999;
	%zVec = 9999;
	%vector = Vector::getFromRot(GameBase::getRotation(%player), %velocity, %zVec);
	Player::applyImpulse(%player, %vector);
	centerprint(%player, "<jc>You have just been boosted off the map by <F2>" @Client::getName(%clientId) @".", 5);
	messageAllExcept(%cl, 1, " "@%name@" was just boosted off the map by "@%AdminName@"~wfemale5.wtaunt1.wav");
}

function Strip(%cl)
{
	Player::dropItem(%cl,Flag);
	if(%cl.observerMode == "" || %cl.observerMode == "pregame")
	{
		%numweapon = Player::getItemClassCount(%cl,"Weapon");
		%max = getNumItems(); 
		for (%i = 0; %i < %max; %i = %i + 1)
		{
			%item = getItemData(%i);
			%count = Player::getItemCount(%cl,%item); 
			if(%count)
			{
				Player::setItemCount(%cl,%item,0); 
			}
		}
		Player::setDamageFlash(%cl,1); 
	}
}

function processMenucMatchStart(%clientId, %option)
{
	%opt = getWord(%option, 0);
	if(%clientId.isMasterAdmin) // Double Check To Make Sure Clans Are Set
	{
	    	if($ClanMatch == "")
	    	{
			client::sendMessage(%clientId, 1, "Unable to start match, no clans set up.~wCapturedTower.wav");
			return;
	        }
		if(%opt == "ematch")
		{
		   if($ClanMatchRunning)
		   {
			Server::endClanMatch(%clientId, %clientId);
			return;
                   }
		   client::sendMessage(%clientId, 3, "Unable To End Clan Match - None Exists~wCapturedTower.wav");
		   return;
		}
		else if(%opt == "smatch")
		{
			%x = 0;
			client::buildMenu(%clientId, "Set Points To Win:", "cMatchStart", true);
			for(%i = 10; %i < $Server::ClanMatchTotalPoints+1; %i = %i+5)
			{
				client::addMenuItem(%clientId, %curItem++ @ ""@%i@" Points", "startit "@%i);
				%x++;
				if(%x == 7)
				{
					client::addMenuItem(%clientId, %curItem++ @ "More Points", "MPoints "@%i);
					break;
				}
			}
			
		}
		else if(%opt == "MPoints")
		{
			%nums = 0;	
			%x = getWord(%option, 1);
			client::buildMenu(%clientId, "Set Points To Win:", "cMatchStart", true);
			for(%i = %x + 5; %i < $Server::ClanMatchTotalPoints+1; %i = %i+5)
			{
				client::addMenuItem(%clientId, %curItem++ @ ""@%i@" Points", "startit "@%i);
				%nums++;
				if(%nums == 7)
				{
					client::addMenuItem(%clientId, %curItem++ @ "More Points", "MPoints "@%i);
					break;
				}
			}
		}
		
		else if(%opt == "startit")
		{
			%first = getWord($ClanMatch, 0);
			%second = getWord($ClanMatch, 1);
			%points = getWord(%option, 1);
			%pass = $matchPass;
			echo("Match Started Between"@%first@" and "@%second@" Up To "@%points@" Points");
			echo("Server Password For Match: "@%pass);
			Server::startClanMatch(%first, %second, %points, %pass); // Start the match
		}
		return;
	}
	Admin::Exploit(%clientId, "Admin Option (Clan Match Options)");
}

function processMenubanType(%clientId, %opt)
{
      %cl = getWord(%opt, 1);
      %type = getWord(%opt, 2);
      Client::buildMenu(%clientId, "Confirm "@%type@" Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl@" "@%type);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
}

function processMenuKAffirm(%clientId, %opt)
{
   if(!%clientId.isAdmin)
   {
	Admin::Exploit(%clientId, "Admin Option (Kick)");
	return;
   }
   if(getWord(%opt, 0) == "yes")
   {
      if(client::getAdminLevel(%clientId) > client::getAdminLevel(getWord(%opt, 1)) || %clientId.isOwnerAdmin)
      {
      	Admin::kick(%clientId, getWord(%opt, 1));
	return;
      }
      if(client::getAdminLevel(%clientId) <= client::getAdminLevel(getWord(%opt, 1))  && client::getAdminLevel(%clientId) != "4")
      {
	client::sendMessage(%clientId, 0, "You may not kick "@client::getName(getWord(%opt, 1))@" due to "@client::gender(getWord(%opt, 1))@" admin status~wCapturedTower.wav");
	return;
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuBAffirm(%clientId, %opt)
{
   if(!%clientId.isSuperAdmin)
   {
	%banType = getWord(%opt, 2);
	Admin::Exploit(%clientId, "Admin Option ("@%banType@" Ban)");
	return;
   }
   if(getWord(%opt, 0) == "yes")
   {
      if(client::getAdminLevel(%clientId) > client::getAdminLevel(getWord(%opt, 1)) || %clientId.isOwnerAdmin)
      {
      	ban(getWord(%opt, 1), getWord(%opt, 2), %clientId);
      }
      if(client::getAdminLevel(%clientId) <= client::getAdminLevel(getWord(%opt, 1))  && client::getAdminLevel(%clientId) != "4")
      {
	client::sendMessage(%clientId, 0, "You may not ban "@client::getName(getWord(%opt, 1))@" due to "@client::gender(getWord(%opt, 1))@" admin status~wCapturedTower.wav");
	return;
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuAAffirm(%clientId, %opt)
{
   %cl = getWord(%opt, 1);
   if(!%clientId.isSuperAdmin)
   {
	Admin::Exploit(%clientId, "Admin Option (Admin Status Menu)");
	return;
   }
   if(client::getAdminLevel(%clientId) <= client::getAdminLevel(%cl) && !%clientId.isOwnerAdmin)
   {
	client::sendMessage(%clientId, 0, "You may not change "@client::getName(%cl)@"'s admin status due to your admin status~wCapturedTower.wav");
	return;
   }
   if(getWord(%opt, 0) == "yes")
   {
      client::buildMenu(%clientId, "Choose Admin Type", "cadmintype", true);
      if(%clientId.isOwnerAdmin)
      {
	client::addMenuItem(%clientId, %curItem++ @ "Owner Admin", "4 "@%cl);
	client::addMenuItem(%clientId, %curItem++ @ "Master Admin", "3 "@%cl);
	client::addMenuItem(%clientId, %curItem++ @ "Super Admin", "2 "@%cl);
	client::addMenuItem(%clientId, %curItem++ @ "Public Admin", "1 "@%cl);
	return;
      }
      if(%clientId.isMasterAdmin)
      {
   	client::addMenuItem(%clientId, %curItem++ @ "Super Admin", "2 "@%cl);
	client::addMenuItem(%clientId, %curItem++ @ "Public Admin", "1 "@%cl);
 	return;
      }
      if(%clientId.isSuperAdmin)
      {
	client::addMenuItem(%clientId, %curItem++ @ "Public Admin", "1 "@%cl);
	return;
      }
   }
   else if(getWord(%opt, 0) == "no")
   {
	client::buildMenu(%clientId, "De-Admin To:", "deadmin", true);
	if(%clientId.isOwnerAdmin)
	{
		client::addMenuItem(%clientId, %curItem++ @ "Master Admin", "3 "@%cl);
		client::addMenuItem(%clientId, %curItem++ @ "Super Admin", "2 "@%cl);
		client::addMenuItem(%clientId, %curItem++ @ "Public Admin", "1 "@%cl);
		client::addMenuItem(%clientId, %curItem++ @ "No Admin", "0 "@%cl);
		return;
	}
	if(%clientId.isMasterAdmin)
	{
		client::addMenuItem(%clientId, %curItem++ @ "Public Admin", "1 "@%cl);
		client::addMenuItem(%clientId, %curItem++ @ "No Admin", "0 "@%cl);
		return;
	}
	if(%clientId.isSuperAdmin)
	{
		client::addMenuItem(%clientId, %curItem++ @ "No Admin", "0 "@%cl);
		return;
	}
   }
	
   Game::menuRequest(%clientId);
}

function processMenucadmintype(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	%clname = client::getName(%cl);
	%adname = client::getName(%clientId);

	if(client::getAdminLevel(%clientId) <= %opt && !%clientId.isOwnerAdmin)
	{
		client::sendMessage(%clientId, 0, "You may not make "@%clname@" a "@getAdminType(%opt)@" due to your admin status~wCapturedTower.wav");
		return;
	}
	
	if(client::getAdminLevel(%cl) >= %opt)
	{
		client::sendMessage(%clientId, 3, %clname@" is already a "@getAdminType(%opt)@"~wCapturedTower.wav");
		return;
	}

	echo("ADMIN: "@%adname@" made "@%clname@" into a "@getAdminType(%opt));
	messageall(0, %adname@" made "@%clname@" into a "@getAdminType(%opt)@"~wCapturedTower.wav");

	Admin::setLevel(%cl, %opt);
	
}

function processMenudeadmin(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(!%clientId.isSuperAdmin || (client::getAdminLevel(%clientId) <= client::getAdminLevel(%cl) && !%clientId.isOwnerAdmin)) return; // PORT: same test as processMenuAAffirm, on the client this code names
	%clname = client::getName(%cl);
	%adname = client::getName(%clientId);
	
	if(%opt == client::getAdminLevel(%cl))
	{
		client::sendMessage(%clientId, 0, "You may not de-admin "@%clname@" to a "@getAdminType(%opt)@" because they are already a "@getAdminType(%opt)@"~wCapturedTower.wav");
		return;
	}
	
	if(%opt > client::getAdminLevel(%cl))
	{
		client::sendMessage(%clientId, 0, "You may not de-admin "@%clname@" to a "@getAdminType(%opt)@" because they are only a "@getAdminType(client::getAdminLevel(%cl))@"~wCapturedTower.wav");
		return;
	}

	if(client::getAdminLevel(%clientId) <= %opt)
	{
		client::sendMessage(%clientId, 0, "You may not de-admin "@%clname@" to a "@getAdminType(%opt)@" due to your admin status~wCapturedTower.wav");
		return;
	}

	if(client::getAdminLevel(%cl) == %opt)
	{
		client::sendMessage(%clientId, %clname@" is already a "@getAdminType(%opt)@"~wCapturedTower.wav");
		return;
	}
	
	if(getAdminType(%opt) == "Not admin")
	{
		messageall(0, %adname@" removed "@%clname@"'s admin status~wCapturedTower.wav");
		echo("ADMIN: "@%adname@" removed "@%clname@"'s admin status");
		Admin::unsetLevel(%cl, %opt);
		return;
	}
	messageall(0, %adname@" De-Admined "@%clname@" into a "@getAdminType(%opt)@"~wCapturedTower.wav");
	Admin::unsetLevel(%cl, %opt);
	echo("ADMIN: "@%adname@" De-Admined "@%clname@" into a "@getAdminType(%opt));
	return;
}

function Admin::setLevel(%cl, %opt)
{
	%val = true;
	if(%opt == "4")
	{
		%cl.isAdmin = %val;
		%cl.isSuperAdmin = %val;
		%cl.isMasterAdmin = %val;
		%cl.isOwnerAdmin = %val;
	}

	else if(%opt == "3")
	{
		%cl.isAdmin = %val;
		%cl.isSuperAdmin = %val;
		%cl.isMasterAdmin = %val;
	}

	else if(%opt == "2")
	{
		%cl.isAdmin = %val;
		%cl.isSuperAdmin = %val;
	}
	
	else if(%opt == "1")
	{
		%cl.isAdmin = %val;
	}
}

function Admin::unsetLevel(%cl, %opt)
{
	%val = false;
	if(%opt == "0")
	{
		%cl.isAdmin = %val;
		%cl.isSuperAdmin = %val;
		%cl.isMasterAdmin = %val;
		%cl.isOwnerAdmin = %val;
	}

	else if(%opt == "3")
	{
		%cl.isOwnerAdmin = %val;
	}

	else if(%opt == "2")
	{
		%cl.isMasterAdmin = %val;
		%cl.isOwnerAdmin = %val;
	}
	
	else if(%opt == "1")
	{
		%cl.isOwnerAdmin = %val;
		%cl.isMasterAdmin = %val;
		%cl.isSuperAdmin = %val;
	}
}

function processMenuRAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.~wCapturedTower.wav");
      Server::refreshData();
      return;
   }
   if(!%clientId.isAdmin)
   {
	Admin::Exploit(%clientId, "Admin Option (Reset Server)");
	return;
   }
   Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{
   remoteSetTimeLimit(%clientId, %opt);
}

/////////////////////////////////////////////////////////////////////////////////
//
// NEW FUNCTIONS START HERE -WorstAim
//

function client::gender(%clientId)
{
	if(client::getGender(%clientId) == "Male")
	{
		return "his";
	}
	else if(client::getGender(%clientId) == "Female")
	{
		return "her";
	}
}

function client::getAlias(%cl)
{
	%ip = Client::trimIP(%cl);
	%name = client::getName(%cl);
	
	for(%i = 0; $Connection[%i, IP] != ""; %i++)
	{
		if(%ip == $Connection[%i, IP])
		{
			for(%k = 0; $Connection[%i, Name, %k] != ""; %k++)
			{
				if($Connection[%i, Name, %k] != %name)
				{
					%found = true;
					%alias = $Connection[%i, Name, %k]@", "@%alias;
				}
				if($Connection[%i, Name, %k+1] == "" && $Connection[%i, Name, %k] == %name && !%found)
				{
					return "No Alias's Found";
				}
			}
			return %alias;
		}
		if($Connection[%i+1, IP] == "" && $Connection[%i, IP] != %ip)
		{
			return "No Alias's Found";
		}
	}
}

function client::getAdminLevel(%clientId)
{
	if(%clientId.isOwnerAdmin)
	{
		return "4";
	}
	else if(%clientId.isMasterAdmin)
	{
		return "3";
	}
	else if(%clientId.isSuperAdmin)
	{
		return "2";
	}
	else if(%clientId.isAdmin)
	{
		return "1";
	}
	return "0";
}

function getAdminType(%level)
{
	if(%level == "0" || %level > 4)
	{
		return "Not admin";
	}
	else if(%level == "1")
	{
		return "Public Admin";
	}
	else if(%level == "2")
	{
		return "Super Admin";
	}
	else if(%level == "3")
	{
		return "Master Admin";
	}
	else if(%level == "4")
	{
		return "Owner Admin";
	}
}
exec("Logging.cs");
function dbecho(){}

////////////////////////////////////////////////////////////
// FUNCTIONS YOU NEED FOR THIS CRASH PROTECTION PACK TO WORK
////////////////////////////////////////////////////////////

function String::containsCrash(%clientId, %message, %function)
{
   if(%clientId.isCrasher)
   {
	return true;
   }
   //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\||
   //                                               ||
   // KingTomato's Crash Protection (Best There Is) ||
   //						    ||
   // MODIFIED BY WORSTAIM		            ||
   /////////////////////////////////////////////////||
   %count[Hex] = 0;
   %count[Tab] = 0;
   %count[Cr]  = 0;
   for (%a = 0; (%letter = String::GetSubStr(%message, %a, 1)) != ""; %a++)
   {
	if (%letter == "\t")
	{
		%count[Tab]++;
	}
	else if (%letter == "\n")
	{
		%count[Cr]++;
	}
	else if (String::findSubStr(escapeString(%letter), "\\x") == 0)
	{	
		%count[Hex]++;
	}
   }
   if(%count[Tab] + %count[Hex] + %count[Cr] >= 80 || String::length(%message) >= 1000)
   {
	%clientId.gag = true;
	%clientId.isCrasher = true;
	bottomprintall("<jc><F2>"@client::getName(%clientId)@" <F1>Tried To Crash The Server And Has Been <F0>PERMANENTLY BANNED", 6);
	Log::Exploit(%clientId, "Server-Crash", %function, %message);
	ban(%clientId, "Permanent", -1);
	return true;
   }
   return false;
}

//****************************************************************************
//ban("ClientID of Person Being Banned", "Type Of Ban", "ClientID of Banner");
//Bans and then kicks the client
//****************************************************************************
function ban(%cl, %banType, %admin)
{
	if(%cl != %admin.selClient && %admin != -1)
	{
		client::sendMessage(%admin, 1, "Go fuck yourself.");
		return;
	}
	%name = client::getName(%cl);
	%ip = Client::trimIP(%cl);
	%bannedBy = client::getName(%admin);

	banlist::remove(client::wPort(%cl)); // Seems Counter-Intuitive, But It's Not

	if(%admin == -1)
	{
		%bannedBy = "The Server";
	}

	if(%banType == "Permanent")
	{
		echo(%bannedBy@" has banned: "@%name@", "@%banType@"ly");
		messageall(1,%bannedBy@" has banned "@%name@" Permanently");
		banlist::addAbsolute(%ip, 0);
		kick(%cl, "You have been PERMANENTLY BANNED");
	}

	else if(%banType == "Temporary")
	{
		echo(%bannedBy@" has banned: "@%name@", Temporarily  (1 Week)");
		messageall(1,%bannedBy@" has banned "@%name@" Temporarily (1 Week)");
		banlist::add(%ip, 604800);
		kick(%cl, "You have been BANNED for 1 week");
	}
	banlist::export("config\\banlist.cs"); //Crash The Server And Your Still Banned
	echo("BAN: "@%bannedBy@" banned "@%name@" ("@%banType@")");
}

//***************************
// kick(%clientId, %message);
//***************************

function kick(%clientId, %msg)
{
	//I Use This Because Tribes Crashes For Some Reason When Net::Kick() Is Called
	//From Inside Any Function Except Admin::Kick() Without Being schedule()'d

	schedule("net::kick("@%clientId@", \""@escapeString(%msg)@"\");",0.2); // PORT
}


//*******************************
//Client::trimIP(clientId);
//*******************************
function Client::trimIP(%clientId)
{
   // Should Turn This: IP:#.#.#.#:# into IP:#.#.#.*
   // Would Turn IP:012.345.678.901:2345 Into IP:012.345.678.*
   %ipstr = client::getTransportAddress(%clientId);
   %ip = string::getSubStr(%ipstr, 0, 15);
   for(%i = 0; string::getSubStr(%ip, %i, 1) != ""; %i++)
   {
	%num = string::getSubStr(%ip, %i, 1);
	if(!String::ICompare(%num, "."))
	{
		%dot++;
		if(%dot == "3")
		{
			%finalIp = string::getSubStr(%ip, 0, %i++);
			%finalIP = %finalIP@"*";
			return %finalIP;
		}
	}
	
   }
   return %ip;
}

//***************************************************************
//Admin::Exploit(exploiterID, "ExploitType (info)", KickPlayer?);
//ex: Admin::Exploit(2049, "Admin Option (Ban)", true);
//***************************************************************

function Admin::Exploit(%e, %o, %k)
{
	%name = client::getName(%e);
	%ip = client::getTransportAddress(%e);
	
	$player = %name@" - "@%ip;
	$exploit = %o;
	$s = "----------------------------------------------------";
	export("$s", "config\\"@$modName@"_Admin-Exploits.log", true);
	export("$player", "config\\"@$modName@"_Admin-Exploits.log", true);
	export("$exploit", "config\\"@$modName@"_Admin-Exploits.log", true);

	echo("ADMIN EXPLOIT: "@$player@" - "@%o);

	if(%k)
	{
		messageall(0, %name@" has been auto-kicked for attempting to use an exploit.");
		kick(%e, "You've Been Kicked, Go Away.");
	}
}

function Client::wPort(%clientId)
{
   %ipstr = client::getTransportAddress(%clientId);
   %ip = string::getSubStr(%ipstr, 3, 16);
   for(%i = 0; string::getSubStr(%ip, %i, 1) != ""; %i++)
   {
	if(string::getSubStr(%ip, %i, 1) == ":")
	{
		return "IP:"@string::getSubStr(%ip, 0, %i)@":*";
	}
	
   }
}

$modName = "Cybrid";

echo("*************************************************************************************************");
echo("***");
echo("***");
echo("***                             TRIBES CRASH PROTECTION EXECUTED");
echo("***                             Created By WorstAim");
echo("***                             Dedicated To Armageddon / Slipknot");
echo("***                             Developed On 05/04/05");
echo("***");
echo("***");
echo("*************************************************************************************************");




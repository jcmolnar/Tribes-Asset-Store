$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

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

// Added Userlist - *IX*Savage1
function remoteAdminPassword(%client, %password)
{
   if($AdminPassword != "" && %password == $AdminPassword)
   {
      %client.isAdmin = true;
      %client.isSuperAdmin = true;
      messageall(0, "VX5 Server: " @ client::getname(%client) @ " Has Gained Super Admin.~wForceOpen.wav");
	echo(client::getname(%client) @ " logged in as a God Admin.");
   }
   else if($MatchAdminPassword != "" && %password == $MatchAdminPassword)
   {
      %client.isAdmin = true;
      messageall(0, "VX5 Server: " @ client::getname(%client) @ " Has Gained Public Admin.~wForceOpen.wav");
	echo(client::getname(%client) @ " logged in as a Public Admin.");
   }
   else if($GodPassword != "" && %password == $GodPassword)
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
   if(%client.isSuperAdmin) // PORT: stock value; was isAdmin
      $Server::Password = %password;
}

// Public Admin Time Limit Toggle - *IX*Savage1
function remoteSetTimeLimit(%client, %time)
{
   %time = floor(%time);
   if(%time == $Server::timeLimit || (%time != 0 && %time < 1))
      return;
   if((%client.isAdmin) || (%client.isSuperAdmin))
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
            messageAll(1, "Match start countdown forced by vote.");
         else
            messageAll(3, " ATTENTION: Match countdown started by force.");

		schedule("messageAll(0, \"~wmine_act.wav\");", 26);
		schedule("messageAll(0, \"~wmine_act.wav\");", 27);
		schedule("messageAll(0, \"~wmine_act.wav\");", 28);
		schedule("messageAll(0, \"~wmine_act.wav\");", 29);

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
            messageAll(3, "VX5 Server: " @ Client::getName(%admin) @ " turned on team damage.");
      }
      else
      {
         $Server::TeamDamageScale = 0;
         if(%admin == -1)
            messageAll(0, "Team damage set to DISABLED by consensus.");
         else
            messageAll(3, "VX5 Server: " @ Client::getName(%admin) @ " turned off team damage.");
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
            Client::sendMessage(%admin, 0, "No Admin Can... Nor Will Not Be " @ %word @ ".");
         return;
      }
      %ip = Client::getTransportAddress(%client);

      echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);

      if(%ip == "")
         return;
      Insomniax_leaveGame(%client);
	if(%ban)
         BanList::add(%ip, 1800);
      //else
      //   BanList::add(%ip, $ultra_renegades::BanKickTime);

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
   if($loadingMission)
      return;
   if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
   {
      $Server::TeamDamageScale = 0;
      if(%clientId == -1)
         messageAll(1, "Server switched to Free-For-All Mode.");
      else
         messageAll(3, "Server info: Server switched to Free-For-All Mode");

	if($Server::FTWasOn)
		$ultra_renegades::fairteams = "true";
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
   if($loadingMission)
      return;
   if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
   {
      $Server::TeamDamageScale = 1;
      if(%clientId == -1)
         messageAll(1, "Server switched to Tournament Mode.");
      else
         messageAll(3, "Server info: Server switched to Tournament Mode");

      $Server::TourneyMode = true;

	//turns off Fair Teams for tourny mode
	if($ultra_renegades::fairteams)
		$Server::FTWasOn = "true";
	else
		$Server::FTWasOn = "false";
	$ultra_renegades::fairteams = "false";

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
		messageAll(0,"VX5-Server: Fair Teams Checking is DISABLED.");
		$ultra_renegades::fairteams = "false";
	}
	else if($curVoteAction == "efteams")
	{
		messageAll(0,"VX5-Server: Fair Teams Checking is ENABLED.");
		$ultra_renegades::fairteams = "true";
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
            		messageAll(3, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ ".");
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

// Remade Menu to Include Various Options - *IX*Savage1
function Game::menuRequest(%clientId)
{
	%curItem = 0;
	Client::buildMenu(%clientId, "VX5 Options:", "options", true);
	if(!$matchStarted || !$Server::TourneyMode)
	{
        if(%clientId.possessing)
		Client::addMenuItem(%clientId, %curItem++ @ "Stop Possession!", "unposs " @ %clientId.poss);        
		Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");          
	}
      if($curVoteTopic == "" && !%clientId.isAdmin && !%clientId.selClient)
      {
                                           Client::addMenuItem(%clientId, %curItem++ @ "Mission: Vote", "vcmission");        
      }
	if(%clientId.selClient)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Control Player: Options", "selopts");
                     }
                     if(%clientId.selClient && %clientId.isAdmin)
                     {
                                           Client::addMenuItem(%clientId, %curItem++ @ "Private Message: Player " @ %name, "cMessage " @ %sel);         
  	}
	else if($curVoteTopic != "" && %clientId.vote == "")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
		Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
	}
	else if($curVoteTopic == "" && !%clientId.isSuperAdmin)
	{
		if(%clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Public Admin: Options", "publicAdminOptions");                                                                                    
		//if($ultra_renegades::PAModOptions && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "UR Admin Settings", "insomniax");
		if(!%clientId.isAdmin && $Server::TeamDamageScale > 0)
		{
			%IXKiller = Insomniax_getKiller(%clientId);
			if((%IXKiller != %clientId) && ($tkKills[%IXKiller] >= $ultra_renegades::tkLimit))
			{
				if($ultra_renegades::tkClientLvl == 1)
					Client::addMenuItem(%clientId, %curItem++ @ "Kick Team Killer " @ Client::getName(Insomniax_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller)));    
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick " @ Client::getName(Insomniax_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller)));    
			}
		}	
	}	
	else if(%clientId.isSuperAdmin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Super Admin: Options", "superAdminOptions");
		Client::addMenuItem(%clientId, %curItem++ @ "Public Admins: Clear", "insomniax");
                     }
                      Client::addMenuItem(%clientId, %curItem++ @ "ObserveMode: Setup", "misc");  
	Client::addMenuItem(%clientId, %curItem++ @ "Credits:", "credits");
}

function remoteSelectClient(%clientId, %selId)
{
   if(%clientId.selClient != %selId)
   {
      %clientId.selClient = %selId;
      if(%clientId.menuMode == "options")
         Game::menuRequest(%clientId);
      remoteEval(%clientId, "setInfoLine", 1, Client::getName(%selId) @ " (" @ $Client::info[%selId, 0] @ ")");
      remoteEval(%clientId, "setInfoLine", 2, "Player Deaths: " @ %selId.ScoreDeaths);
      remoteEval(%clientId, "setInfoLine", 3, "Player Kills: " @ %selId.ScoreKills);
      remoteEval(%clientId, "setInfoLine", 4, "Since Connection Flag Caps: " @ %selId.FlagCaps);
      remoteEval(%clientId, "setInfoLine", 5, "Total Score: " @ %selId.score);
      if(%clientId.isSuperAdmin)
	remoteEval(%clientId, "setInfoLine", 6, "Smurf: " @ server::ConnectInfo(%selId));
   }
}

function processMenuFPickTeam(%clientId, %team)
{
   if(%clientId.isAdmin)
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
            		messageAll(3, Client::getName(%clientId) @ " became an observer.");
        		else
            		messageAll(3, Client::getName(%clientId) @ " was forced into Observer mode by " @ Client::getName(%adminClient) @ ".");
		}
      	return;
   	}
	%change = false;
	if(!$ultra_renegades::fairTeams) 
	{
		if(%team == -1)
		{
	      	Game::assignClientTeam(%clientId);
	      	%team = Client::getTeam(%clientId);
		}
		if(%adminClient == "")
			messageAll(3, Client::getName(%clientId) @ " changed teams.");
		else
			messageAll(3, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
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

function processMenummisc(%clientId, %option) { 
	%o = getWord(%option, 0); 
	%extra = getWord(%option, 1); 
	if(%o == "pSkin") {
		if(%clientId.custom == False) {
			%clientId.custom = True;
			Client::setSkin(%clientId, $Client::info[%clientId, 0]);
		} else if(%clientId.custom == True) {
			%clientId.custom = False;
			Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
	   }
	} else if(%o == "view") 
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
function processMenuTeamScoreStuff(%clientId, %option)
{
	if(!%clientId.isSuperAdmin) return; // PORT: menu codes come from the client
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "teamscore")
	{
		Client::buildMenu(%clientId, getteamname(%cl) @ ":", "TeamScoreStuff", true);
		Client::addMenuItem(%clientId, "1Add Point", "addteamscore " @ %cl);
		Client::addMenuItem(%clientId, "2Subtract Point", "subteamscore " @ %cl);
		return;
	}
	else if(%opt == "addteamscore")
	{
		$teamScore[%cl]++;
		ObjectiveMission::refreshTeamScores();
		messageall(0, client::getname(%clientId) @ " added a point to the " @ getteamname(%cl) @ " score.");
		processMenuTeamScoreStuff(%clientId, "teamscore " @ %cl);
	}
	else if(%opt == "subteamscore")
	{
		$teamScore[%cl]--;
		ObjectiveMission::refreshTeamScores();
		messageall(0, client::getname(%clientId) @ " subtracted a point from the " @ getteamname(%cl) @ " score.");
		processMenuTeamScoreStuff(%clientId, "teamscore " @ %cl);
	}
}

function processMenuOptions(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(!VXPort::optAllowed(%clientId, %opt, %cl)) { Game::menuRequest(%clientId); return; } // PORT: menu codes come from the client
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
	else if(%opt == "selopts")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "VX5 Options:", "options", true);
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);

		if($curVoteTopic == "" && !%clientId.isSuperAdmin)
		{
			//if($ultra_renegades::Vote && !%sel.isAdmin)
			//	Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
			if(%clientId.isAdmin)
				Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
			else if(%clientId.selClient)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
			//if($ultra_renegades::PABan && %clientId.isAdmin)
			//	Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
			if(%clientId.isAdmin)
				Client::addMenuItem(%clientId, %curItem++ @ "Execute " @ %name, "execute " @ %sel);
			if(%clientId.isAdmin)
				Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
		}
		else if(%clientId.isSuperAdmin)
		{
                        if(%clientId.possessing)
		        Client::addMenuItem(%clientId, %curItem++ @ "Stop Possession!", "unposs " @ %clientId.poss);
                        else if(!%cl.possessed && !%cl.isSuperAdmin && %clientId != %sel)
			Client::addMenuItem(%clientId, %curItem++ @ "Possess " @ %name, "poss " @ %sel); 
			if(!%sel.isAdmin) 
				Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Strip " @ %name, "strip " @ %sel); 
			Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Execute " @ %name, "execute " @ %sel); 
			Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
		}
		if(%clientId.isSuperAdmin)
			Client::addMenuItem(%clientId, %curItem++ @ "More....", "moremenu"); 
		return;
	}
                     else if(%opt == "moremenu")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "Torture:", "options", true);
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);

	                      if(%sel.silenced)                
			Client::addMenuItem(%clientId, %curItem++ @ "Re-Voice " @ %name, "unsilence " @ %sel);
                                                         else
                                                                Client::addMenuItem(%clientId, %curItem++ @ "De-Voice " @ %name, "silence " @ %sel);
                                                                Client::addMenuItem(%clientId, %curItem++ @ "Freeze " @ %name, "freeze " @ %sel);
                                            if (%sel.blind)  
			Client::addMenuItem(%clientId, %curItem++ @ "Un-Blind " @ %name, "unblind " @ %sel);
                                                         else
			Client::addMenuItem(%clientId, %curItem++ @ "Blind " @ %name, "blind " @ %sel); 
                                                                Client::addMenuItem(%clientId, %curItem++ @ "Slap " @ %name, "slap " @ %sel);  
                                                                Client::addMenuItem(%clientId, %curItem++ @ "Sky High " @ %name, "moon " @ %sel);      
                                                                Client::addMenuItem(%clientId, %curItem++ @ "Score Clear " @ %name, "clearscore " @ %sel);                                                       
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
else if(%opt == "credits")
	{
		bottomprint(%clientId, "<jc><f3>¤§ <f1>Mod: <f2>Ultra_RenegadesVX5 Infinite <f3>§¤\n"@
                                                                                      "<jc><f3>¤§ <f1>Repaired And Updated By: <f2>.:O|S:.LeGeND <f3>§¤\n"@
                                                                                      "<jc><f3>¤§ <f1>Originally By, And Many Thanx to: <f2>Nimec, and Kissie-Poo <f3>§¤",20);
			                      return;
	}
	else if(%opt == "mute")
		%clientId.muted[%cl] = true;
	else if(%opt == "unmute")
		%clientId.muted[%cl] = "";
                     else if(%opt == "silence")
		%cl.silenced = true;
                     else if(%opt == "unsilence")
		%cl.silenced = false;
                      else if(%opt == "freeze")
	{
		freeze(%cl);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" Froze you.", 5);		
		messageAll(0, Client::getName(%clientId) @ " Froze " @ Client::getName(%cl)@" into a Block of ice.");		
		return;
	}
	else if(%opt == "blind")
	{
		%cl.blind = true;
		HotPoker(%cl);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" Has Blinded you.", 5);		
		messageAll(0, Client::getName(%clientId) @ " Made " @ Client::getName(%cl) @"'s Eyesight All Bloody.");		
		return;
	}	
                     else if(%opt == "unblind")
	{
		%cl.blind = false;
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" Restored your sight.", 5);		
		messageAll(0, Client::getName(%clientId) @ " Restored "@ Client::getName(%cl) @"'s Sight.");		
		return;
	}
                     else if(%opt == "slap")
	{
	%rotZ = getWord(GameBase::getRotation(%cl),2); 
	GameBase::setRotation(%cl, "0 0 " @ %rotZ); 
	%forceDir = Vector::getFromRot(GameBase::getRotation(%cl),3000,1000); 
	Player::applyImpulse(%cl,%forceDir); 
	schedule("Client::sendMessage("@%cl@", 1,\"~wmale3.wbye.wav\");", 2);
//	schedule("Client::sendMessage("@%cl@", 1,\"~wmale3.wdsgst2.wav\");", 2.2);
	centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" Bitch Slapped you.", 5);		
	messageAll(0, Client::getName(%clientId) @ " Slapped the Shit outta "@ Client::getName(%cl) @".");	
	return;
	}
                     else if(%opt == "moon")
	{
	%rotZ = getWord(GameBase::getRotation(%cl),2); 
	GameBase::setRotation(%cl, "0 0 " @ %rotZ); 
	%forceDir = Vector::getFromRot(GameBase::getRotation(%cl),0,3000); 
	Player::applyImpulse(%cl,%forceDir); 
	schedule("Client::sendMessage("@%cl@", 1,\"~wmale3.wbye.wav\");", 2);
//	schedule("Client::sendMessage("@%cl@", 1,\"~wmale3.wdsgst2.wav\");", 2.2);
	centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" Sent you to the Moon!", 5);		
	messageAll(0, Client::getName(%clientId) @ " Sent "@ Client::getName(%cl) @" to the Moon.");		
	return;
	}
                     else if(%opt == "clearscore")
	{
                     %cl.score = 0;
	Game::refreshClientScore(%cl);	
	return;
	}
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
                     else if (%opt == "cMessage")
	{
		%clientId.pmess = %clientId.selClient;
		bottomprint(%clientId, "<f2><jc>PM Now Ready, Next Message In Chat Will Be Sent To: " @ Client::getName(%clientId.selClient), 3);
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
	else if(%opt == "execute") 
	{ 
		Client::buildMenu(%clientId, "Confirm Execution:", "maffirm", true);
 		Client::addMenuItem(%clientId, "1Kill the idiot " @ Client::getName(%cl), "yes " @ %cl);
 		Client::addMenuItem(%clientId, "2Don't kill the idiot " @ Client::getName(%cl), "no " @ %cl);
 		return;
 	}
        else if(%opt == "poss") {
		if(%cl.isnotaTker) { qk(%clientId); return; }
		if(Client::getControlObject(%cl) != Client::getOwnedObject(%cl)) {
			Client::sendMessage(%clientId,1,"Unable to possess - Player currently is not in control of themselves~waccess_denied.wav"); 	
			Game::menuRequest(%clientId); 
			return;
		}		
		if(Client::getControlObject(%clientId) != Client::getOwnedObject(%clientId) && !Observer::isObserver(%clientId)) {
			Client::sendMessage(%clientId,1,"Unable to possess - You are currently not controlling your player~waccess_denied.wav"); 	
			Game::menuRequest(%clientId); 
			return;
		}	
        Client::setControlObject(%cl, Client::getObserverCamera(%cl));
        Observer::setOrbitObject(%cl, Client::getOwnedObject(%cl), 3, 3, 3);
		Client::setControlObject(%clientId, %cl);
		%cl.possessed = true;
		%cl.possby = %clientId;
		%clientId.poss = %cl;
		%clientId.possessing = true;
		echo(Client::getName(%cl) @ " has been possessed by " @ Client::getName(%clientId));
		MessageAllExcept(%cl , 0, Client::getName(%cl) @ " has been possessed by " @ Client::getName(%clientId) @ ".~wteleport2.wav"); 
		Client::sendMessage(%cl ,1,"You've been possessed by " @ Client::getName(%clientId)@"!~wteleport2.wav"); 	
	} else if(%opt == "unposs") {
		Client::setControlObject(%clientId, %clientId);
        Client::setControlObject(%cl, %cl);
		%cl.possessed = false;
		%cl.possby = "";
		%clientId.possessing = false;
		%clientId.poss = "";
		MessageAllExcept(%cl, 0, Client::getName(%cl) @ " is no longer possessed by " @ Client::getName(%clientId) @ ".~wteleport2.wav"); 
		Client::sendMessage(%cl ,1,"You have been freed by " @ Client::getName(%clientId)@".~wteleport2.wav"); 	
	}
	else if(%opt == "smatch")
		Admin::startMatch(%clientId);
	else if(%opt == "vcmission" || %opt == "cmission")
	{
		Admin::changeMissionMenu(%clientId, %opt == "cmission");
		return;
	}
	else if(%opt == "cteamscore")
	{
		Client::buildMenu(%clientId, "Pick Team:", "TeamScoreStuff", true);
		for(%i = 0; %i<getnumteams(); %i++)
			Client::addMenuItem(%clientId, %i @ getteamname(%i), "teamscore " @ %i);
		return;
	}
	else if(%opt == "ctimelimit")
	{
		Client::buildMenu(%clientId, "Change Time Limit:", "ctlimit", true);
		Client::addMenuItem(%clientId, "15 Minutes", 5);
		Client::addMenuItem(%clientId, "210 Minutes", 10);
		Client::addMenuItem(%clientId, "315 Minutes", 15);
		Client::addMenuItem(%clientId, "420 Minutes", 20);
		Client::addMenuItem(%clientId, "525 Minutes", 25);
		Client::addMenuItem(%clientId, "630 Minutes", 30);
		Client::addMenuItem(%clientId, "745 Minutes", 45);
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
        }	
	else if(%opt == "observe")
	{
		Observer::setTargetClient(%clientId, %cl);
		return;
	}
        else if(%opt == "misc") {
		%i = 0;
		Client::buildMenu(%clientId, "Observer Setup:", "mmisc", true); 
		if ($HaVoC::PersonalSkin) { 
			if(%clientId.custom == False) { 
				Client::addMenuItem(%clientId, %i++ @ "Use Personal Skin", "pSkin"); 
			} else if(%clientId.custom == True) { 
				Client::addMenuItem(%clientId, %i++ @ "Use Team Skin", "pSkin"); 
			} 
		}  
		Client::addMenuItem(%clientId, %i++ @ "Observer Mode...", "obsm"); 
		return;
	}
	else if(%opt == "disableFT")
	{
		ixAdminMsg("Command: " @ Client::getName(%clientId) @ " - Fair Teams Checking is DISABLED.");
		$ultra_renegades::fairteams = "false";
	}
	else if(%opt == "enableFT")
	{
		ixAdminMsg("Command: " @ Client::getName(%clientId) @ " - Fair Teams Checking is ENABLED.");
		$ultra_renegades::fairteams = "true";
	}
	else if(%opt == "vdisableFT")
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "Disable Fair Teams", "dfteams", %cl);
	}
	else if(%opt == "venableFT")
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "Enable Fair Teams", "efteams", %cl);
	}
	else if(%opt == "insomniax")
	{
		%now = 0;
		Client::buildMenu(%clientId, "Public Admin: Clear", "ixsettings", true);
		if(%clientId.isSuperAdmin)
			Client::addMenuItem(%clientId, %now++ @ "Public Admin Clearing", "admincontrols");
		return;
	}
	else if(%opt == "obsopts")
	// gwObserverOptions
	{
		%countme = 0;
		Client::buildMenu(%clientId, "Observer Options:", "obsopts", true);
		Client::addMenuItem(%clientId, %countme++ @ "Orbit Options", "obsorbit");
		if(%clientId.FlagChase)
			Client::addMenuItem(%clientId, %countme++ @ "Disable CarrierChase", "flagchaseoff");
		else
			Client::addMenuItem(%clientId, %countme++ @ "Enable CarrierChase", "flagchaseon");
		return;
	}
	else if(%opt == "tkopt")
	{
		if($ultra_renegades::tkClientLvl == 1)
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
		if($ultra_renegades::PVMission) 
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
		if($ultra_renegades::PVTeamDamage)
		{
			if($Server::TeamDamageScale == 1.0)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
			else
     				Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
		}
		if($ultra_renegades::PVFairTeams)
		{
			if($ultra_renegades::FairTeams) 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to Disable Fair Teams", "vdisableFT " @ %clientId);
			else 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to Enable Fair Teams", "venableFT " @ %clientId);
		}
		if($ultra_renegades::PVTourneyMode)
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
	else if(%opt == "publicAdminOptions") 
	{
		%curItem = 0;
     		Client::buildMenu(%clientId, "Public Admin Options:", "Options", true);
		if(%clientId.isAdmin)
		{                                                              
			Client::addMenuItem(%clientId, %curItem++ @ "Admin: Change mission", "cmission");
		}
		else 
		{
			if($ultra_renegades::PVMission) 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
		}
		if(%clientId.isAdmin)
		{
			if($Server::TeamDamageScale == 1.0)
				Client::addMenuItem(%clientId, %curItem++ @ "T-Damage: Disable", "dtd");
			else
				Client::addMenuItem(%clientId, %curItem++ @ "T-Damage: Enable", "etd");
		}
		else 
		{
			if($ultra_renegades::PVTeamDamage)
			{
				if($Server::TeamDamageScale == 1.0)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
				else
      				Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
			}
		}
		if(%clientId.isAdmin)
		{
		      if($Server::TourneyMode)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Server: FFA mode", "cffa");
				if(!$CountdownStarted && !$matchStarted)
					Client::addMenuItem(%clientId, %curItem++ @ "Server: Start match", "smatch");
			}
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Server: Tourney mode", "ctourney");
		}
		else 
		{
			if($ultra_renegades::PVTourneyMode)
				if($Server::TourneyMode)
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
					if(!$CountdownStarted && !$matchStarted)
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
				}
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
		}
		
		if(%clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Time Limit: Setup", "ctimelimit");
		return;
	}
	else if(%opt == "superAdminOptions") 
	{
		%curItem = 0;
     		Client::buildMenu(%clientId, "Super Admin Options", "Options", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Game: Change Mission", "cmission");
	      if($Server::TeamDamageScale == 1.0)
			Client::addMenuItem(%clientId, %curItem++ @ "T-Damage: Disable", "dtd");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "T-Damage: Enable", "etd");
		if($Server::TourneyMode)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Server: FFA mode", "cffa");
			if(!$CountdownStarted && !$matchStarted)
				Client::addMenuItem(%clientId, %curItem++ @ "Server: Start match", "smatch");
		}
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Server: Tourney Mode", "ctourney");
		Client::addMenuItem(%clientId, %curItem++ @ "Time Limit: Setup", "ctimelimit");
		Client::addMenuItem(%clientId, %curItem++ @ "Server: Reset All", "reset");
		return;
	}
	Game::menuRequest(%clientId);
}

function HotPoker(%clientId) 
{
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{ 
		Player::setDamageFlash(%clientId,1.0);
		if(%clientId.blind)
			schedule("HotPoker("@%clientId@");", 1.5);
  	}
	else
		Client::sendMessage(%clientId, 1, "In death, You will see again.");
}

function Freeze(%clientId,%option) 
{
	%player = Client::getOwnedObject(%clientId);
	%player.frozen = true;
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)&& !%option)
	{ 
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		Observer::setOrbitObject(%clientId, %clientId, 3, 3, 3);
		schedule("Freeze("@%clientId@",true);", 120);// 2 minutes is plenty
  	}
	else if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)&& %option)
	{ 
		Client::setControlObject(%clientId, %clientId);
		%player.frozen = false;
  	}
  	if(%option)
  		%player.frozen = false;
}

function processMenuKAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1));
   Game::menuRequest(%clientId);
}

function processMenuBAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes" && %clientId.isSuperAdmin) // PORT
      Admin::kick(%clientId, getWord(%opt, 1), true);
   Game::menuRequest(%clientId);
}
function processMenuMAffirm(%clientId, %opt) 
{ 
   if(getWord(%opt, 0) == "yes" && $matchstarted && %clientId.isAdmin && (%clientId.isSuperAdmin || !getWord(%opt, 1).isSuperAdmin)) // PORT
{ 
%cl = getWord(%opt, 1);
 MessageAll(3, "You Have Just Been Executed By a Admin....");
 MessageAllExcept(%cl , 1, Client::getName(%cl) @ " Turned into Dust by " @ Client::getName(%clientId) @ ".~wfemale5.wtaunt1.wav");
 Client::sendMessage(%cl ,3,"Your Have Been Slaughtered By " @ Client::getName(%clientId) @ ".~wfemale4.wdeath.wav");
 playNextAnim(%cl); Player::kill(%cl); Client::onKilled(%cl,%cl);
 }
 Game::menuRequest(%clientId); }

function processMenuAAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isSuperAdmin)
      {
         %cl = getWord(%opt, 1);
		%cl.isAdmin = true;
         messageAll(3, "VX5 Server: " @ Client::getName(%cl) @ " is now a Public Admin.");
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuRAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isSuperAdmin) // PORT: the menu offers Reset to super admins only
   {
      messageAll(3, "VX5 Server: Server has been Reset");
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
	if(!%clientId.isSuperAdmin) return; // PORT: menu codes come from the client
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(%opt == "dautoteams")
	{
		ixAdminMsg("Auto Teams is DISABLED by " @ Client::getName(%clientId));
		$Server::AutoTeams = "false";
	}
	if(%opt == "eautoteams")
	{
		ixAdminMsg("Auto Teams is ENABLED by " @ Client::getName(%clientId));
		$Server::AutoTeams = "true";
	}
	if(%opt == "dturtle")
	{
		ixAdminMsg("Anti Turtle is DISABLED by " @ Client::getName(%clientId));
		$Server::AntiTurtle = "false";
	}
	if(%opt == "eturtle")
	{
		ixAdminMsg("Anti Turtle is ENABLED by " @ Client::getName(%clientId));
		$Server::AntiTurtle = "true";
	}
	if(%opt == "admincontrols")
	{
	      Client::buildMenu(%clientId, "Confirm Clear:", "ixsettings", true);
		//if($ultra_renegades::PAVote) 
		//	Client::addMenuItem(%clientId, "1Disable Admin Voting", "disablepav");
		//else 
		//	Client::addMenuItem(%clientId, "1Enable Admin Voting", "enablepav");
		//Client::addMenuItem(%clientId, "2Admin Lockouts", "palockout");
		Client::addMenuItem(%clientId, "1Clear Public Admins?", "purge " @ %clientId);
		return;
	}
	else if(%opt == "disablepav")
	{
		ixAdminMsg("Admin Voting is DISABLED by " @ Client::getName(%clientId));
		$ultra_renegades::PAVote = "false";
	}
	else if(%opt == "enablepav")
	{
		ixAdminMsg("Admin Voting is ENABLED by " @ Client::getName(%clientId));
		$ultra_renegades::PAVote = "true";
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
	else if(%opt == "palockout")
	{
	      Client::buildMenu(%clientId, "Current Status:","PALockouts", true);
      	Client::addMenuItem(%clientId, "1[" @ whattodo($ultra_renegades::PATeamChange) @ "]Team Changing", "teamchange " @ $ultra_renegades::PATeamChange);
	      Client::addMenuItem(%clientId, "2[" @ whattodo($ultra_renegades::PAKick) @ "]Kick", "kick " @ $ultra_renegades::PAKick);
      	Client::addMenuItem(%clientId, "3[" @ whattodo($ultra_renegades::PABan) @ "]Ban","ban " @ $ultra_renegades::PABan);
		Client::addMenuItem(%clientId, "4[" @ whattodo($ultra_renegades::PAExecute) @ "]Execute","execute " @ $ultra_renegades::PAExecute);
	      Client::addMenuItem(%clientId, "5[" @ whattodo($ultra_renegades::PAMission) @ "]Change Mission", "mission " @ $ultra_renegades::PAMission);
      	Client::addMenuItem(%clientId, "6[" @ whattodo($ultra_renegades::PATeamDamage) @ "]Team Damage", "teamdamage " @ $ultra_renegades::PATeamDamage);
	      Client::addMenuItem(%clientId, "7[" @ whattodo($ultra_renegades::PATourneyMode) @ "]Tourney/FFA Mode", "tourney " @ $ultra_renegades::PATourneyMode);
	      Client::addMenuItem(%clientId, "8[" @ whattodo($ultra_renegades::PATimeLimit) @ "]Time Limit", "timelimit " @ $ultra_renegades::PATimeLimit);
	      Client::addMenuItem(%clientId, "9Additional Lockouts ...", "additional");
      	return;
	}
	else if(%opt == "pvlockout")
	{
      	Client::buildMenu(%clientId, "Current Status:","PVLockouts", true);
		Client::addMenuItem(%clientId, "1[" @ whattodo($ultra_renegades::PVKick) @ "]Kick", "kick " @ $ultra_renegades::PVKick);
	      Client::addMenuItem(%clientId, "2[" @ whattodo($ultra_renegades::PVMission) @ "]Change Mission", "mission " @ $ultra_renegades::PVMission);
	      Client::addMenuItem(%clientId, "3[" @ whattodo($ultra_renegades::PVFairTeams) @ "]Fair Teams", "fteams " @ $ultra_renegades::PVFairTeams);
	      Client::addMenuItem(%clientId, "4[" @ whattodo($ultra_renegades::PVTeamDamage) @ "]Team Damage", "teamdamage " @ $ultra_renegades::PVTeamDamage);
	      Client::addMenuItem(%clientId, "5[" @ whattodo($ultra_renegades::PVTourneyMode) @ "]Tourney/FFA Mode", "tourney " @ $ultra_renegades::PVTourneyMode);
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
	      Client::buildMenu(%clientId, "Inventory Station Time: " @ %cl @ " Seconds", "StationTime", true);
	      Client::addMenuItem(%clientId, "0Disable Time Limit", 0);
	      Client::addMenuItem(%clientId, "1Set to 5 Seconds", 5);
	      Client::addMenuItem(%clientId, "2Set to 10 Seconds", 10);
	      Client::addMenuItem(%clientId, "3Set to 15 Seconds", 15);
	      Client::addMenuItem(%clientId, "4Set to 20 Seconds", 20);
	      Client::addMenuItem(%clientId, "5Set to 25 Seconds", 25);
	      Client::addMenuItem(%clientId, "6Set to 30 Seconds", 30);
	      Client::addMenuItem(%clientId, "7Set to 60 Seconds", 60);
      	return;
	}
	else if(%opt == "dsafestation")
	{
		ixAdminMsg("Safe Stations DISABLED by " @ Client::getName(%clientId));
		$ultra_renegades::SafeStation = "false";
	}
	else if(%opt == "esafestation")
	{
		ixAdminMsg("Safe Stations ENABLED by " @ Client::getName(%clientId));
		$ultra_renegades::SafeStation = "true";
	}
	processMenuOptions(%clientId, "insomniax");
}

function processMenuPALockouts(%clientId, %option) 
{
	if(!%clientId.isSuperAdmin) return; // PORT: menu codes come from the client
	%opt = getWord(%option, 0);
	%toggle = getWord(%option, 1);
	if(%opt == "additional")
   	{
		Client::buildMenu(%clientId, "Current Status:","PALockouts", true);
		Client::addMenuItem(%clientId, "1[" @ whattodo($ultra_renegades::PAResetDefaults) @ "]Server Defaults ", "reset " @ $ultra_renegades::PAResetDefaults);
	      Client::addMenuItem(%clientId, "2[" @ whattodo($ultra_renegades::PAModOptions) @ "]UR-Admin Options", "modopt " @ $ultra_renegades::PAModOptions);
	      Client::addMenuItem(%clientId, "3[" @ whattodo($ultra_renegades::PATeamInfo) @ "]Set Team Info", "teaminfo " @ $ultra_renegades::PATeamInfo);
		Client::addMenuItem(%clientId, "4[" @ whattodo($ultra_renegades::PAFairTeams) @ "] Fair Teams", "fteams " @ $ultra_renegades::PAFairTeams);
	      Client::addMenuItem(%clientId, "5[Unlock]ALL Options", "allon");
	      Client::addMenuItem(%clientId, "6[-Lock-]ALL Options", "alloff");
		return;
   	}
	else if(%opt == "allon") 
	{
		%access = "All Admin Options";
		%toggle = "false";
		$ultra_renegades::PATeamChange = "true";
		$ultra_renegades::PAKick = "true";
		$ultra_renegades::PABan = "true";
		$ultra_renegades::PAExecute = "true";
		$ultra_renegades::PAMission = "true";
		$ultra_renegades::PATeamInfo = "true";
		$ultra_renegades::PAFairTeams = "true";
		$ultra_renegades::PATeamDamage = "true";
		$ultra_renegades::PATourneyMode = "true";
		$ultra_renegades::PATimeLimit = "true";
		$ultra_renegades::PAResetDefaults = "true";
		$ultra_renegades::PAModOptions = "true";
	}
	else if(%opt == "alloff") 
	{
		%access = "All Admin Options";
		%toggle = "true";
		$ultra_renegades::PATeamChange = "false";
		$ultra_renegades::PAKick = "false";
		$ultra_renegades::PABan = "false";
		$ultra_renegades::PAExecute = "false";
		$ultra_renegades::PAMission = "false";
		$ultra_renegades::PATeamInfo = "false";
		$ultra_renegades::PAFairTeams = "false";
		$ultra_renegades::PATeamDamage = "false";
		$ultra_renegades::PATourneyMode = "false";
		$ultra_renegades::PATimeLimit = "false";
		$ultra_renegades::PAResetDefaults = "false";
		$ultra_renegades::PAModOptions = "false";
	}
	else if(%opt == "teamchange") 
	{
		%access = "Admin: Team Change";
		if(%toggle) $ultra_renegades::PATeamChange = "false";
		else $ultra_renegades::PATeamChange = "true";
	}
	else if(%opt == "kick") 
	{
		%access = "Admin: Kick";
		if(%toggle) $ultra_renegades::PAKick = "false";
		else $ultra_renegades::PAKick = "true";
	}
	else if(%opt == "ban") 
	{
		%access = "Admin: Ban";
		if(%toggle) $ultra_renegades::PABan = "false";
		else $ultra_renegades::PABan = "true";
	}
	else if(%opt == "execute") 
	{
		%access = "Admin: Execute";
		if(%toggle) $ultra_renegades::PAExecute = "false";
		else $ultra_renegades::PAExecute = "true";
	}
	else if(%opt == "mission") 
	{
		%access = "Admin: Change Mission";
		if(%toggle) $ultra_renegades::PAMission = "false";
		else $ultra_renegades::PAMission = "true";
	}
	else if(%opt == "teamdamage") 
	{
		%access = "Admin: Enable/Disable Team Damage";
		if(%toggle) $ultra_renegades::PATeamDamage = "false";
		else $ultra_renegades::PATeamDamage = "true";
	}
	else if(%opt == "tourney") 
	{
		%access = "Admin: Toggle Tourney/FFA Mode";
		if(%toggle) $ultra_renegades::PATourneyMode = "false";
		else $ultra_renegades::PATourneyMode = "true";
	}
	else if(%opt == "timelimit") 
	{
		%access = "Admin: Change Time Limit";
		if(%toggle) $ultra_renegades::PATimeLimit = "false";
		else $ultra_renegades::PATimeLimit = "true";
	}
	else if(%opt == "reset") 
	{
		%access = "Admin: Reset Sever";
		if(%toggle) $ultra_renegades::PAResetDefaults = "false";
		else $ultra_renegades::PAResetDefaults = "true";
	}
	else if(%opt == "modopt") 
	{
		%access = "Admin: UR-Admin Options";
		if(%toggle) $ultra_renegades::PAModOptions = "false";
		else $ultra_renegades::PAModOptions = "true";
	}
	else if(%opt == "teaminfo") 
	{
		%access = "Admin: Set Team Info";
		if(%toggle) $ultra_renegades::PATeamInfo = "false";
		else $ultra_renegades::PATeamInfo = "true";
	}
	else if(%opt == "fteams") 
	{
		%access = "Admin: Enable/Disable Fair Teams";
		if(%toggle) $ultra_renegades::PAFairTeams = "false";
		else $ultra_renegades::PAFairTeams = "true";
	}
	if(%toggle) %toggle = "false";
	else %toggle = "true";
	ixAdminMsg(Client::getName(%clientId) @ " [" @ islocked(%toggle) @ "] " @ %access);
	processMenuIXSettings(%clientId,"palockout");
}

function processMenuPVLockouts(%clientId, %option) 
{
	if(!%clientId.isSuperAdmin) return; // PORT: menu codes come from the client
	%opt = getWord(%option, 0);
	%toggle = getWord(%option, 1);
	if(%opt == "kick") 
	{
		%access = "Vote to Kick";
		if(%toggle) $ultra_renegades::PVKick = "false";
		else $ultra_renegades::PVKick = "true";
	}
	else if(%opt == "mission") 
	{
		%access = "Vote to Change Mission";
		if(%toggle) $ultra_renegades::PVMission = "false";
		else $ultra_renegades::PVMission = "true";
	}
	else if(%opt == "teamdamage") 
	{
		%access = "Vote to Enable/Disable Team Damage";
		if(%toggle) $ultra_renegades::PVTeamDamage = "false";
		else $ultra_renegades::PVTeamDamage = "true";
	}
	else if(%opt == "tourney") 
	{
		%access = "Vote to Change to Tourney/FFA Mode";
		if(%toggle) $ultra_renegades::PVTourneyMode = "false";
		else $ultra_renegades::PVTourneyMode = "true";
	}
	else if(%opt == "fteams") 
	{
		%access = "Vote to Enable/Disable Fair Teams";
		if(%toggle) $ultra_renegades::PVFairTeams = "false";
		else $ultra_renegades::PVFairTeams = "true";
	}
	else if(%opt == "allon") 
	{
		%access = "All Vote Options";
		%toggle = "false";
		$ultra_renegades::PVKick = "true";
		$ultra_renegades::PVMission = "true";
		$ultra_renegades::PVFairTeams = "true";
		$ultra_renegades::PVTeamDamage = "true";
		$ultra_renegades::PVTourneyMode = "true";
	}
	else if(%opt == "alloff") 
	{
		%access = "All Vote Options";
		%toggle = "true";
		$ultra_renegades::PVKick = "false";
		$ultra_renegades::PVMission = "false";
		$ultra_renegades::PVFairTeams = "false";
		$ultra_renegades::PVTeamDamage = "false";
		$ultra_renegades::PVTourneyMode = "false";
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
	if(!%clientId.isSuperAdmin) return; // PORT: menu codes come from the client
   $ultra_renegades::tkServerLvl = %option;
   if(%option == 0)
     messageAll(0, "UR-Server:TK Protection Level Set to Zero. (Logging TK's only).");
   if(%option == 1)
     messageAll(0, "UR-Server:TK Protection Level Set to One. (Auto Vote).");
   if(%option == 2)
     messageAll(0, "UR-Server:TK Protection Level Set to Two. (Auto Vote Until Kicked).");
   if(%option == 3)
     messageAll(0, "UR-Server:TK Protection Level Set to Three. (Auto Kick).");
}

function processMenuClientLvl(%clientId, %option) 
{
	if(!%clientId.isSuperAdmin) return; // PORT: menu codes come from the client
   $ultra_renegades::tkClientLvl = %option;
   if(%option == 0)
     messageAll(0, "UR-Server: Client TK Vote Option Engaged. (From Options Menu).");
   if(%option == 1)
     messageAll(0, "UR-Server: Client TK Kick Option Engaged. (From Options Menu).");
}

function processMenuStationTime(%clientId, %option) 
{
	if(!%clientId.isSuperAdmin) return; // PORT: menu codes come from the client
	$ultra_renegades::StationTime = %option;
	if(%option == 0)
		messageAll(3, "VX5 Server: Inventory Station Time Disabled.");
	else
		messageAll(3, "VX5 Server: Inventory Station Time is now set to " @ %option @ " Seconds.");
}

function Insomniax_ServerLvlTxt()
{
    if($ultra_renegades::tkServerLvl == 0)
    	%tkText = "Only Logging TK's"; 
    else if($ultra_renegades::tkServerLvl == 1)
	%tkText = "Votes at " @ $ultra_renegades::tkLimit @ " TK's";
    else if($ultra_renegades::tkServerLvl == 2)
	%tkText = "Votes at " @ $ultra_renegades::tkLimit @ " TKs and Kicks at " @ $ultra_renegades::tkLimit * $ultra_renegades::tkMultiple @ " TK's";
    else if($ultra_renegades::tkServerLvl == 3)
	%tkText = "Kicks at " @ $ultra_renegades::tkLimit @ " TK's";
    else %tkText = "ERROR: Server Level set to Unkown Level";
    return %tkText;
}

function Insomniax_ClientLvlTxt()
{
    if($ultra_renegades::tkClientLvl == 0)
    	%tkText = "Vote Option at " @ $ultra_renegades::tkLimit @ " TK's"; 
    else if($ultra_renegades::tkClientLvl == 1)
	%tkText = "Kick Option at " @ $ultra_renegades::tkLimit @ "TK's";
    else %tkText = "ERROR: Client Level set to Unkown Level";
    return %tkText;
}

// Insomnaix Mod TK Handling - *IX*Savage1
function Insomniax_setTeamKill(%victimId, %killerId) 
{
  $tkVictim[%killerId] = %victimId;
	$tkKiller[%victimId] = %killerId;
	$tkKills[%killerId] += 1;
	echo("UR-Admin: TK Recorded. victimId: ",%victimId," killerId: ",%killerId," Killer now has ",$tkKills[%killerId]," TKs");
	%trigger = $tkKills[%killerId] % $ultra_renegades::tkLimit;
	%tkTopKills = $ultra_renegades::tkLimit * $ultra_renegades::tkMultiple;
	if(($tkKills[%killerId] >= $ultra_renegades::tkLimit) && (!%trigger)) 
	  {
	  if($ultra_renegades::tkServerLvl) 
	    {
	    if($ultra_renegades::tkServerLvl != 3)
	      {
		if(($tkKills[%killerId] >= %tkTopKills) && ($ultra_renegades::tkServerLvl != 1))
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
		ixAdminMsg("Clearing all Public Admins...");
	      %numPlayers = getNumClients();
      	for(%i = 0; %i < %numPlayers; %i++)
	      {
			%pl = getClientByIndex(%i);
			if(!%pl.isSuperAdmin && %pl.isAdmin)
			{
				%pl.isAdmin = false;
				Client::sendMessage(%pl,1,"VX5 Server: Your Admin Status has been revoked by the Super Admin.");
				ixAdminMsg("Cleared Admin Status from " @ Client::getName(%pl));
			}
		}
		ixAdminMsg("All Public Admins cleared Successfully.");
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
	echo("UR-Admin: Player's Team Killer Counts Reset to Zero.");
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
      {
		%pl = getClientByIndex(%i);
		$tkKills[%pl] = 0;
	}
}

function ixwhoison()
{
echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
	echo("UR-Admin: # cl: CLIENT nm: NAME    ip: ADDRESS");
	%numPlayers = getNumClients();
	%j=0;
      for(%i = 0; %i < %numPlayers; %i++)
      {
		%pl = getClientByIndex(%i);
		echo("UR-Admin: ",%i," cl: ",%pl," nm: ",Client::getName(%pl),"    ip: ",Client::getTransportAddress(%pl));
		}
echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
}

function ixLockouts()
{
echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
echo("UR-Admin: Public Admin Lockout Status.");
echo("UR-Admin: [",islocked($ultra_renegades::PATeamChange),"] Team Change");
echo("UR-Admin: [",islocked($ultra_renegades::PAKick),"] Kick");
echo("UR-Admin: [",islocked($ultra_renegades::PABan),"] Ban");
echo("UR-Admin: [",islocked($ultra_renegades::PAExecute),"] Execute");
echo("UR-Admin: [",islocked($ultra_renegades::PAMission),"] Change Mission");
echo("UR-Admin: [",islocked($ultra_renegades::PATeamInfo),"] Team Info");
echo("UR-Admin: [",islocked($ultra_renegades::PATeamDamage),"] Team Damage");
echo("UR-Admin: [",islocked($ultra_renegades::PAFairTeams),"] Fair Teams");
echo("UR-Admin: [",islocked($ultra_renegades::PATourneyMode),"] Tourney Mode");
echo("UR-Admin: [",islocked($ultra_renegades::PATimeLimit),"] Time Limit");
echo("UR-Admin: [",islocked($ultra_renegades::PAResetDefaults),"] Reset Server Defaults");
echo("UR-Admin: [",islocked($ultra_renegades::PAModOptions),"] Mod Options");
echo("UR-Admin: [",islocked($ultra_renegades::PAVote),"] Admin Voting");
echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
echo("UR-Admin: Public Voting Lockout Status.");
echo("UR-Admin: [",islocked($ultra_renegades::PVKick),"] Kick");
echo("UR-Admin: [",islocked($ultra_renegades::PVMission),"] Change Mission");
echo("UR-Admin: [",islocked($ultra_renegades::PVFairTeams),"] Fair Teams");
echo("UR-Admin: [",islocked($ultra_renegades::PVTeamDamage),"] Team Damage");
echo("UR-Admin: [",islocked($ultra_renegades::PVTourneyMode),"] Tourney Mode");
echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
}

function ixtoggle(%lockout)
{
 if(%lockout != "") {
  if(%lockout == "PATeamChange") 
	{
		%access = "Admin: Team Change";
		if($ultra_renegades::PATeamChange) $ultra_renegades::PATeamChange = "false";
		else $ultra_renegades::PATeamChange = "true";
		%toggle = $ultra_renegades::PATeamChange;
	}
	else if(%lockout == "PAKick") 
	{
		%access = "Admin: Kick";
		if($ultra_renegades::PAKick) $ultra_renegades::PAKick = "false";
		else $ultra_renegades::PAKick = "true";
		%toggle = $ultra_renegades::PAKick;
	}
	else if(%lockout == "PABan") 
	{
		%access = "Admin: Ban";
		if($ultra_renegades::PABan) $ultra_renegades::PABan = "false";
		else $ultra_renegades::PABan = "true";
		%toggle = $ultra_renegades::PABan;
	}
	else if(%lockout == "PAExecute") 
	{
		%access = "Admin: Execute";
		if($ultra_renegades::PAExecute) $ultra_renegades::PAExecute = "false";
		else $ultra_renegades::PAExecute = "true";
		%toggle = $ultra_renegades::PAExecute;
	}
	else if(%lockout == "PAMission") 
	{
		%access = "Admin: Change Mission";
		if($ultra_renegades::PAMission) $ultra_renegades::PAMission = "false";
		else $ultra_renegades::PAMission = "true";
		%toggle = $ultra_renegades::PAMission;
	}
	else if(%lockout == "PATeamDamage") 
	{
		%access = "Admin: Enable/Disable Team Damage";
		if($ultra_renegades::PATeamDamage) $ultra_renegades::PATeamDamage = "false";
		else $ultra_renegades::PATeamDamage = "true";
		%toggle = $ultra_renegades::PATeamDamage;
	}
	else if(%lockout == "PAFairTeams") 
	{
		%access = "Client: Vote to Toggle Fair Team Checking";
		if($ultra_renegades::PAFairTeams) $ultra_renegades::PAFairTeams = "false";
		else $ultra_renegades::PAFairTeams = "true";
		%toggle = $ultra_renegades::PAFairTeams;
	}
	else if(%lockout == "PATourneyMode") 
	{
		%access = "Admin: Toggle Tourney/FFA Mode";
		if($ultra_renegades::PATourneyMode) $ultra_renegades::PATourneyMode = "false";
		else $ultra_renegades::PATourneyMode = "true";
		%toggle = $ultra_renegades::PATourneyMode;
	}
	else if(%lockout == "PATimeLimit") 
	{
		%access = "Admin: Change Time Limit";
		if($ultra_renegades::PATimeLimit) $ultra_renegades::PATimeLimit = "false";
		else $ultra_renegades::PATimeLimit = "true";
		%toggle = $ultra_renegades::PATimeLimit;
	}
	else if(%lockout == "PAResetDefaults") 
	{
		%access = "Admin: Reset Sever";
		if($ultra_renegades::PAResetDefaults) $ultra_renegades::PAResetDefaults = "false";
		else $ultra_renegades::PAResetDefaults = "true";
		%toggle = $ultra_renegades::PAResetDefaults;
	}
	else if(%lockout == "PAModOptions") 
	{
		%access = "Admin: UR-Admin Options";
		if($ultra_renegades::PAModOptions) $ultra_renegades::PAModOptions = "false";
		else $ultra_renegades::PAModOptions = "true";
		%toggle = $ultra_renegades::PAModOptions;
	}
	else if(%lockout == "PATeamInfo") 
	{
		%access = "Admin: Set Team Info";
		if($ultra_renegades::PATeamInfo) $ultra_renegades::PATeamInfo = "false";
		else $ultra_renegades::PATeamInfo = "true";
		%toggle = $ultra_renegades::PATeamInfo;
	}
	else if(%lockout == "PVKick") 
	{
		%access = "Client: Vote to Kick";
		if($ultra_renegades::PVKick) $ultra_renegades::PVKick = "false";
		else $ultra_renegades::PVKick = "true";
		%toggle = $ultra_renegades::PVKick;
	}
	else if(%lockout == "PVMission") 
	{
		%access = "Client: Vote to Change Mission";
		if($ultra_renegades::PVMission) $ultra_renegades::PVMission = "false";
		else $ultra_renegades::PVMission = "true";
		%toggle = $ultra_renegades::PVMission;
	}
	else if(%lockout == "PVTeamDamage") 
	{
		%access = "Client: Vote to Enable/Disable Team Damage";
		if($ultra_renegades::PVTeamDamage) $ultra_renegades::PVTeamDamage = "false";
		else $ultra_renegades::PVTeamDamage = "true";
		%toggle = $ultra_renegades::PVTeamDamage;
	}
	else if(%lockout == "PVTourneyMode") 
	{
		%access = "Client: Vote to Change to Tourney/FFA Mode";
		if($ultra_renegades::PVTourneyMode) $ultra_renegades::PVTourneyMode = "false";
		else $ultra_renegades::PVTourneyMode = "true";
		%toggle = $ultra_renegades::PVTourneyMode;
	}
	else if(%lockout == "PVFairTeams") 
	{
		%access = "Client: Vote to Toggle Fair Team Checking";
		if($ultra_renegades::PVFairTeams) $ultra_renegades::PVFairTeams = "false";
		else $ultra_renegades::PVFairTeams = "true";
		%toggle = $ultra_renegades::PVFairTeams;
	}
	else if(%lockout == "PAVote") 
	{
		%access = "Client: Vote for Admin";
		if($ultra_renegades::PAVote) $ultra_renegades::PAVote = "false";
		else $ultra_renegades::PAVote = "true";
		%toggle = $ultra_renegades::PAVote;
	}
	else if(%lockout == "PVUnLockAll") 
	{
		%access = "Client: All Vote Options";
		%toggle = "true";
		$ultra_renegades::PVKick = "true";
		$ultra_renegades::PVMission = "true";
		$ultra_renegades::PVFairTeams = "true";
		$ultra_renegades::PVTeamDamage = "true";
		$ultra_renegades::PVTourneyMode = "true";
	}
	else if(%lockout == "PVLockAll") 
	{
		%access = "Client: All Vote Options";
		%toggle = "false";
		$ultra_renegades::PVKick = "false";
		$ultra_renegades::PVMission = "false";
		$ultra_renegades::PVFairTeams = "false";
		$ultra_renegades::PVTeamDamage = "false";
		$ultra_renegades::PVTourneyMode = "false";
	}
	else if(%lockout == "PAUnLockAll")
	{
		%access = "Admin: All Options";
		%toggle = "true";
		$ultra_renegades::PATeamChange = "true";
		$ultra_renegades::PAKick = "true";
		$ultra_renegades::PABan = "true";
		$ultra_renegades::PAExecute = "true";
		$ultra_renegades::PAMission = "true";
		$ultra_renegades::PATeamInfo = "true";
		$ultra_renegades::PATeamDamage = "true";
		$ultra_renegades::PAFairTeams = "true";
		$ultra_renegades::PATourneyMode = "true";
		$ultra_renegades::PATimeLimit = "true";
		$ultra_renegades::PAResetDefaults = "true";
		$ultra_renegades::PAModOptions = "true";
		$ultra_renegades::PAVote = "true";
	}
	else if(%lockout == "PALockAll")
	{
		%access = "Admin: All Options";
		%toggle = "false";
		$ultra_renegades::PATeamChange = "false";
		$ultra_renegades::PAKick = "false";
		$ultra_renegades::PABan = "false";
		$ultra_renegades::PAExecute = "false";
		$ultra_renegades::PAMission = "false";
		$ultra_renegades::PATeamInfo = "false";
		$ultra_renegades::PATeamDamage = "false";
		$ultra_renegades::PAFairTeams = "false";
		$ultra_renegades::PATourneyMode = "false";
		$ultra_renegades::PATimeLimit = "false";
		$ultra_renegades::PAResetDefaults = "false";
		$ultra_renegades::PAModOptions = "false";
		$ultra_renegades::PAVote = "false";
	}
	else 
 {
echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
echo("UR-Admin: ERROR: Unknown Lockout ",%lockout);
echo("UR-Admin: NOTE: Lockouts ARE Case Sensative");
echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
echo("UR-Admin: Usage: ixtoggle(<lockout>);");
echo("UR-Admin: Example: ixtoggle(\"PVUnLockAll\");");
echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
return;
 }
 echo("UR-Admin: [" @ islocked(%toggle) @ "] " @ %access);
 }
 else
 {
echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
echo("UR-Admin: <lockout>           = What it Toggles.");
echo("UR-Admin: PATeamChange        = Public Admin Team Change");
echo("UR-Admin: PAKick              = Public Admin Kick");
echo("UR-Admin: PABan               = Public Admin Ban");
echo("UR-Admin: PAExecute               = Public Admin Execute");
echo("UR-Admin: PAMission           = Public Admin Change Mission");
echo("UR-Admin: PATeamInfo          = Public Admin Team Info");
echo("UR-Admin: PATeamDamage        = Public Admin Team Damage");
echo("UR-Admin: PAFairTeams         = Public Admin Toggle Fair Teams");
echo("UR-Admin: PATourneyMode       = Public Admin Tourney Mode");
echo("UR-Admin: PATimeLimit         = Public Admin Time Limit");
echo("UR-Admin: PAResetDefaults     = Public Admin Reset Server Defaults");
echo("UR-Admin: PAModOptions        = Public Admin Mod Options");
echo("UR-Admin: PVKick              = Public Vote Kick");
echo("UR-Admin: PVMission           = Public Vote Change Mission");
echo("UR-Admin: PVFairTeams         = Public Vote Toggle Fair Teams");
echo("UR-Admin: PVTeamDamage        = Public Vote Team Damage");
echo("UR-Admin: PVTourneyMode       = Public Vote Tourney Mode");
echo("UR-Admin: PALockAll           = Lock All Public Admin Options");
echo("UR-Admin: PAUnLockAll         = UnLock All Public Admin Options");
echo("UR-Admin: PVLockAll           = Lock All Public Vote Options");
echo("UR-Admin: PVUnLockAll         = UnLock All Public Vote Options");
echo("UR-Admin: PAVote              = Public Admin Voting");
echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
echo("UR-Admin: Usage: ixtoggle(<lockout>);");
echo("UR-Admin: Purpose: To change Lockouts from the console");
echo("UR-Admin: Example: ixtoggle(\"PVUnLockAll\");");
echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
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
					bottomprint(%pl,"<f2>Super Admin:<f1> You have Been granted Admin Status by the Super Admin.");
					echo("VX5 Server: Public  Admin Granted to: ",%name);
				}
				else
 					echo("VX5 Server: ",%name," Already has Admin Status");
				return;
			}
		}
	}
	else
	{
	echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
	echo("UR-Admin: Usage: ixGiveAdmin(<PlayerName>)");
	echo("UR-Admin: Example: ixGiveAdmin(*IX*Savage1);");
	echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
	}
}

function ixPurgeAdmins() 
{
	echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
	echo("UR-Admin: Purging All Public Admins");
	%numPlayers = getNumClients();
	%j=0;
      for(%i = 0; %i < %numPlayers; %i++)
      {
		%pl = getClientByIndex(%i);
		if(!%pl.isSuperAdmin && %pl.isAdmin)
		{
			%j++;
			%pl.isAdmin = false;
			bottomprint(%pl,"<f2>Super Admin:<f1> Your Admin Status was revoked by the Super Admin.");
			echo("VX5 Server: Removed Admin from: ",Client::getName(%pl));
		}
	}
	echo("UR-Admin: Purging Complete.");
	echo("UR-Admin: ",%j," Admins Purged.");
	echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
}

function ixSave()
{
echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
echo("UR-Admin: Saving UR Admin Settings for ",$ultra_renegadesInternalVersion);
export("Insomniax::*", "config\\ixadmin.cs", False);
export("DefaultTeamEnergy", "config\\ixadmin.cs", True);
echo("UR-Admin: Settings Saved.");
echo("UR-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
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
			echo("UR-Admin: User: ",%username," Identified. Access Level: ",%flags);
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
			echo("UR-Admin: User: ",%name," Unknown.");
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
			Client::sendMessage(%client, 1,"Security: Bad Password! Notified Super Admin!");
			ixAdminMsg(%name @ " Has Tried to Hack Admin...  " @ %username);
		}
	}
	else
	{
		Client::sendMessage(%client, 3,"VX5 Server: You Already have Admin Status.");
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
	            Client::sendMessage(%pl, 3, "Server: " @ %msg);
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
	while(%x<3 && %i<64)
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

// ---------------------------------------------------------------------------------------------
// PORT (Modern Tribes 1.50). Menu codes are text the client sends, so a code the menu never showed
// a player can still arrive. This returns true when the menus of this mod would have offered
// %opt to %clientId: everything for a super admin, the Public Admin entries for an admin, and
// the entries every player sees. Votes need the switch their own menu tests.
// ---------------------------------------------------------------------------------------------
function VXPort::optAllowed(%clientId, %opt, %cl)
{
	if(%clientId.isSuperAdmin)
		return true;
	if(%opt == "changeteams" || %opt == "selopts" || %opt == "credits" || %opt == "misccredits" || %opt == "misc"
	   || %opt == "voteYes" || %opt == "voteNo" || %opt == "vcmission" || %opt == "vkick" || %opt == "observe"
	   || %opt == "obsopts" || %opt == "publicVoteOptions")
		return true;
	if(%opt == "vetd" || %opt == "vdtd")
		return $ultra_renegades::PVTeamDamage == "true";
	if(%opt == "vcffa" || %opt == "vctourney" || %opt == "vsmatch")
		return $ultra_renegades::PVTourneyMode == "true";
	if(%opt == "vdisableFT" || %opt == "venableFT")
		return $ultra_renegades::PVFairTeams == "true";
	if(%opt == "vadmin")
		return $ultra_renegades::PAVote == "true";
	if(%opt == "tkopt")
	{
		// the menu offers this against the recorded team killer only
		%k = Insomniax_getKiller(%clientId);
		if(%clientId.isAdmin || %k == "" || %k == %clientId || %cl != %k)
			return false;
		return ($Server::TeamDamageScale > 0 && $tkKills[%k] >= $ultra_renegades::tkLimit);
	}
	if(!%clientId.isAdmin)
		return false;
	if(%opt == "publicAdminOptions" || %opt == "kick" || %opt == "execute" || %opt == "fteamchange" || %opt == "cMessage"
	   || %opt == "cmission" || %opt == "etd" || %opt == "dtd" || %opt == "cffa" || %opt == "ctourney" || %opt == "smatch"
	   || %opt == "ctimelimit")
		return true;
	return false;
}

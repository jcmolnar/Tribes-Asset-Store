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
   if(!URPort::optAllowed(%clientId, "cmission", "")) return; // PORT: no mission vote with the vote switch off
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
   if(($ultra_renegades::PAMission && %clientId.isAdmin) || (%clientId.isSuperAdmin))
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
		messageAll(1, Client::getName(%client) @ " now has Super Admin status."); 
	} 
	if($PublicPassword != "" && %password == $PublicPassword) 
	{ 
		%client.isAdmin = true; 
		messageAll(1, Client::getName(%client) @ " now has Public Admin status."); 
	} 
	if($OwnerPassword != "" && %password == $OwnerPassword) 
	{ 
		%client.isAdmin = true; 
		%client.isSuperAdmin = true; 
		%client.isGod = true; 
            messageAll(1, Client::getName(%client) @ " now has God Admin status."); 
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
   if((%client.isAdmin && $ultra_renegades::PATimeLimit) || (%client.isSuperAdmin))
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
  	if($ultra_renegades::PATeamInfo)
	{
      	$Server::teamName[%team] = %teamName;
	      $Server::teamSkin[%team] = %skinBase;
      	messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " 
	         @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission.");
   	}
	else
	{
		Client::sendMessage(%clientId, 1, "Access to ADSetTeamInfo DENIED");
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
      if(%admin.isAdmin && !%admin.isGod && %client.isGod) 
		{ 
			Client::sendMessage(%admin, 1, "You must have lost your mind to even think of trying that!~wmale3.wdsgst2.wav"); 
			Client::sendMessage(%client, 1, Client::getName(%admin) @ " tried to boot you, and is now paying the price~waccess_denied.wav"); 
			playNextAnim(%admin); 
			Player::blowUp(%admin); 
			Player::kill(%admin); 
			Client::onKilled(%admin,%admin); 
			return; 
		} 
		if((%client.isSuperAdmin && !%admin.isGod) || (%client.isAdmin && $PA::noKick == "true" && !%admin.isSuperAdmin) || (!%admin.isSuperAdmin && (($Name::noKicka != "" && Client::getName(%client) == $Name::noKicka) || ($Name::noKickb != "" && Client::getName(%client) == $Name::noKickb) || ($Name::noKickc != "" && Client::getName(%client) == $Name::noKickc) || ($Name::noKickd != "" && Client::getName(%client) == $Name::noKickd)))) 
		{ 
			if(%admin == -1 || %admin == -2 || %admin == -3) messageAll(1, "A admin cannot be " @ %word @ "."); 
			else Client::sendMessage(%admin, 1, "A admin cannot be " @ %word @ "."); 
			Client::sendmessage(%client, 1, Client::getName(%admin) @ " tried to kick you"); 
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
         BanList::add(%ip, $ultra_renegades::BanKickTime);

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
	
		$ultra_renegades::fairteams = "false";
	}
	else if($curVoteAction == "efteams")
	{

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
			if($ultra_renegades::PAVote && !%sel.isAdmin)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
			if($ultra_renegades::PAKick && %clientId.isAdmin)
				Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
			else if($ultra_renegades::PVKick)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
			if($ultra_renegades::PABan && %clientId.isAdmin)
				Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
			if($ultra_renegades::PAExecute && %clientId.isAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "Execute " @ %name, "execute " @ %sel);
			if($ultra_renegades::PATeamChange && %clientId.isAdmin)
				Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
		}
		else if(%clientId.isSuperAdmin)
		{
		
			Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
			if(%clientId.isGod) Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Execute " @ %name, "execute " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
			}
		if(%clientId.isGod) 
		{
  			if(%sel.gag) Client::addMenuItem(%clientId, %curItem++ @ "Un-Gag " @ %name, "ungag " @ %sel); 
  			else Client::addMenuItem(%clientId, %curItem++ @ "Gag " @ %name, "gag " @ %sel);
		}
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
		if($ultra_renegades::PAModOptions && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "UR Admin Settings", "insomniax");
		if(!%clientId.isAdmin)
		{
			%IXKiller = Insomniax_getKiller(%clientId);
			if((%IXKiller != %clientId) && ($tkKills[%IXKiller] >= $ultra_renegades::tkLimit))
			{
				if($ultra_renegades::tkClientLvl == 1)
					Client::addMenuItem(%clientId, %curItem++ @ "Kick Team Killer " @ Client::getName(Insomniax_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller)));    
				}
		}	
	}	
	else if(%clientId.isSuperAdmin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Super Admin Options", "superAdminOptions");
		if(%clientId.isGod)Client::addMenuItem(%clientId, %curItem++ @ "God Admin Options", "godAdminOptions");
		Client::addMenuItem(%clientId, %curItem++ @ "UR Admin Settings", "insomniax");
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
if(%clientId.isSuperAdmin) remoteEval(%clientId, "setInfoLine", 5, "Client: " @ Client::getTransportAddress(%selId));
	}
}

function processMenuFPickTeam(%clientId, %team)
{
   if(!URPort::PA(%clientId, $ultra_renegades::PATeamChange)) { %clientId.ptc = ""; return; } // PORT
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
            		messageAll(0, Client::getName(%clientId) @ " became an observer.");
        		else
            		messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
			Game::resetScores(%clientId);	
		   	Game::refreshClientScore(%clientId);
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
				messageAll(0, Client::getName(%clientId) @ " changed teams.");
			else
      			messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ " to even the Teams.");
			%change = true;
		}
		else
		{
			if(Insomniax_isFairTeam(%teamnow, %team)) 
			{
				if(%adminClient == "")
	      			messageAll(0, Client::getName(%clientId) @ " changed teams.");
				else
	      			messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ " to even the Teams.");
				%change = true;
		   	}
		   	else
			{
				if(%adminClient == "") 
				{
			      	messageAll(0, Client::getName(%clientId) @ " attempted to unbalance the teams.");
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

function processMenuOptions(%clientId, %option)
{
   if(!URPort::optAllowed(%clientId, getWord(%option, 0), getWord(%option, 1))) { Game::menuRequest(%clientId); return; } // PORT: menu codes come from the client
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
	else if(%opt == "restart")
 	{
 	centerprintall("<jc><f1>" @ Client::getName(%ClientId) @ " has restarted the server.  PLEASE COME BACK!",10);
 	schedule("Quit();", 10);
	}
	else if(%opt == "gag") 
		{ 
		if(%cl.isGod && !%clientId.isGod) 
		{ 
			Client::sendMessage(%clientId, 1, "You will not gag god.~waccess_denied.wav"); 
			Client::sendMessage(%cl, 1, Client::getName(%adminClient) @ " tried to GAG you ;).~waccess_denied.wav"); 
			%clientId.gag = true; 
			return; 
		} 
		%cl.gag = true; 
		MessageAllExcept(%cl, 1, Client::getName(%cl) @ " is told by " @ Client::getName(%clientId) @ " to STFU.~wmale3.wdsgst4.wav"); 
		Client::sendMessage(%cl, 1,"You just got your tongue removed by " @ Client::getName(%clientId) @ ".  So shut the fuck up.~wmale3.wdsgst4.wav"); 
		echo(Client::getName(%clientId) @ " *** DE-TONGUED *** " @ Client::getName(%cl)); 
		} 
	else if(%opt == "ungag") 
	{ 
		%cl.gag = false; 
		MessageAllExcept(%cl , 1, Client::getName(%cl) @ "'s tongue has been replaced by " @ Client::getName(%clientId) @ "."); 
		Client::sendMessage(%cl ,1,"Your tongue has been reinserted by " @ Client::getName(%clientId) @ ".  Use it properly this time.~waccess_denied.wav"); 
	}
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
	else if(%opt == "execute") 
	{ 
		Client::buildMenu(%clientId, "Confirm execution:", "maffirm", true);
 		Client::addMenuItem(%clientId, "1Kill the idiot " @ Client::getName(%cl), "yes " @ %cl);
 		Client::addMenuItem(%clientId, "2Don't kill the idiot " @ Client::getName(%cl), "no " @ %cl);
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
		Client::buildMenu(%clientId, "UR Admin Settings:", "ixsettings", true);
		Client::addMenuItem(%clientId, %now++ @ "Server: Anti-TK Lvl", "tkserv " @ $ultra_renegades::tkServerLvl);
		Client::addMenuItem(%clientId, %now++ @ "Client: Anti-TK Lvl", "tkclient " @ $ultra_renegades::tkClientLvl);
		if(%clientId.isSuperAdmin)
			Client::addMenuItem(%clientId, %now++ @ "Admin Controls.", "admincontrols");
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
	else if(%opt == "pw")
	{
	$Server::Password = $Server::pwoption;
	$Server::pwon = true;
	client::sendmessage(%clientId, 0, "You set the server password to " @ $Server::Password);
	messageAll(1, Client::getName(%clientId) @ " Closed the server.");
	return;
	}
	else if(%opt == "pwoff")
	{
	$Server::Password = "";
	$Server::pwon = false;
	messageAll(1, Client::getName(%clientId) @ " Opened the server.");
	return;
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
		if($ultra_renegades::PAMission && %clientId.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
		}
		else 
		{
			if($ultra_renegades::PVMission) 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
		}
		if($ultra_renegades::PATeamDamage && %clientId.isAdmin)
		{
			if($Server::TeamDamageScale == 1.0)
				Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
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
		if($ultra_renegades::PAFairTeams && %clientId.isAdmin)
		{
			if($ultra_renegades::FairTeams) 
				Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "disableFT " @ %clientId);
			else 
				Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "enableFT " @ %clientId);
		}
		else 
		{
			if($ultra_renegades::PVFairTeams)
			{
				if($ultra_renegades::FairTeams) 
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to Disable Fair Teams", "vdisableFT " @ %clientId);
				else 
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to Enable Fair Teams", "venableFT " @ %clientId);
			}
		}
		if($ultra_renegades::PATourneyMode && %clientId.isAdmin)
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
		if($ultra_renegades::PATimeLimit && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
		if($ultra_renegades::PAResetDefaults && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
		return;
	}
	else if(%opt == "superAdminOptions") 
	{
		%curItem = 0;
     		Client::buildMenu(%clientId, "Super Admin Options:", "Options", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
	      if($Server::TeamDamageScale == 1.0)
			Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
		if($ultra_renegades::FairTeams) 
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
		if ($Server::pwon) Client::addMenuItem(%clientId, %curItem++ @ "Un-Lock " @ %name, "pwoff " @ %sel); 
  		else Client::addMenuItem(%clientId, %curItem++ @ "Lock " @ %name, "pw " @ %sel);
		return;
	}
	else if(%opt == "godAdminOptions") 
	{
		%curItem = 0;
     		Client::buildMenu(%clientId, "God Admin Options:", "Options", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Reset Server", "restart");
		if ($Server::pwon) Client::addMenuItem(%clientId, %curItem++ @ "Un-Lock " @ %name, "pwoff " @ %sel); 
  		else Client::addMenuItem(%clientId, %curItem++ @ "Lock " @ %name, "pw " @ %sel);
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuKAffirm(%clientId, %opt)
{
   if(!URPort::PA(%clientId, $ultra_renegades::PAKick)) { Game::menuRequest(%clientId); return; } // PORT: the Kick lockout was only applied to what the menu showed
   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1));
   Game::menuRequest(%clientId);
}

function processMenuBAffirm(%clientId, %opt)
{
   if(!URPort::PA(%clientId, $ultra_renegades::PABan)) { Game::menuRequest(%clientId); return; } // PORT: the Ban lockout was only applied to what the menu showed
   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1), true);
   Game::menuRequest(%clientId);
}
function processMenuMAffirm(%clientId, %opt) 
{
   if(!URPort::PA(%clientId, $ultra_renegades::PAExecute) || (getWord(%opt, 1).isSuperAdmin && !%clientId.isSuperAdmin)) { Game::menuRequest(%clientId); return; } // PORT: Execute had no admin check 
   if(getWord(%opt, 0) == "yes") { %cl = getWord(%opt, 1);
 MessageAll(1, "The skies above open up and a bolt of lightning falls from the sky...");
 MessageAllExcept(%cl , 1, Client::getName(%cl) @ " turned into dust by " @ Client::getName(%clientId) @ ".~wfemale5.wtaunt1.wav");
 Client::sendMessage(%cl ,1,"You were executed by the Server Admin " @ Client::getName(%clientId) @ ".~wfemale4.wdeath.wav");
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
         messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuRAffirm(%clientId, %opt)
{
   if(!URPort::PA(%clientId, $ultra_renegades::PAResetDefaults)) { Game::menuRequest(%clientId); return; } // PORT
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

//-------------------------------------------------------------------
// Various Menus and Data Processing - *IX*Savage1
//-------------------------------------------------------------------

function processMenuIXSettings(%clientId, %option)
{
   if(!URPort::ixAllowed(%clientId, getWord(%option, 0))) return; // PORT: menu codes come from the client
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);

	if(%opt == "admincontrols")
	{
	      Client::buildMenu(%clientId, "Admin Controls:", "ixsettings", true);
		if($ultra_renegades::PAVote) 
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
   if(!URPort::PA(%clientId, $ultra_renegades::PAModOptions)) return; // PORT
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
   if(!URPort::PA(%clientId, $ultra_renegades::PAModOptions)) return; // PORT
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
		messageAll(0, "UR-Server: Inventory Station Time is no Longer Limited.");
	else
		messageAll(0, "UR-Server: Inventory Station Time is now Limtied to " @ %option @ " Seconds.");
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
					bottomprint(%pl,"<f2>UR-Admin:<f1> You have Been granted Admin Status by the Super Admin.");
					echo("UR-Admin: Admin Granted: ",%name);
				}
				else
 					echo("UR-Admin: ",%name," Already has Admin Status");
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
			bottomprint(%pl,"<f2>UR-Admin:<f1> Your Admin Status was revoked by the Super Admin.");
			echo("UR-Admin: Removed Admin: ",Client::getName(%pl));
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

//exec(ixUserList);

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
			Client::sendMessage(%client, 0,"Server to Numb Fuck: Wrong Password");
			ixAdminMsg(%name @ " Login attempt Failed. Username: " @ %username);
		}
	}
	else
	{
		Client::sendMessage(%client, 0,"UR-Server: You Already have Admin Status.");
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
	            Client::sendMessage(%pl, 0, "Server: " @ %msg);
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
// PORT (Modern Tribes 1.50). Menu codes are text the client sends, so a code the menu never
// showed a player can still arrive. These helpers return true when this mod's own menus would
// have offered the code to %clientId: everything for a super admin, the public-admin entries
// for an admin (under the same lockout the menu tests), and the entries every player sees.
// Votes need the switch their own menu entry tests.
// ---------------------------------------------------------------------------------------------
function URPort::on(%v)
{
   if(%v)
      return true;
   return false;
}

function URPort::PA(%clientId, %allowed)
{
   if(%clientId.isSuperAdmin)
      return true;
   if(%clientId.isAdmin && %allowed)
      return true;
   return false;
}

function URPort::optAllowed(%clientId, %opt, %cl)
{
   // UR4: these four are God Admin entries, a plain super admin is not offered them
   if(%opt == "restart" || %opt == "gag" || %opt == "ungag" || %opt == "godAdminOptions")
      return URPort::on(%clientId.isGod);
   if(%clientId.isSuperAdmin)
      return true;
   if(%opt == "changeteams" || %opt == "credits" || %opt == "mute" || %opt == "unmute"
      || %opt == "voteYes" || %opt == "voteNo" || %opt == "observe" || %opt == "publicVoteOptions")
      return true;
   if(%opt == "vkick")
      return URPort::on($ultra_renegades::PVKick);
   if(%opt == "vetd" || %opt == "vdtd")
      return URPort::on($ultra_renegades::PVTeamDamage);
   if(%opt == "vcffa" || %opt == "vctourney" || %opt == "vsmatch")
      return URPort::on($ultra_renegades::PVTourneyMode);
   if(%opt == "vdisableFT" || %opt == "venableFT")
      return URPort::on($ultra_renegades::PVFairTeams);
   if(%opt == "tkopt")
   {
      // offered against the recorded team killer only, once he is over the limit
      %k = Insomniax_getKiller(%clientId);
      if(%clientId.isAdmin || %k == "" || %k == %clientId || %cl != %k)
         return false;
      if($tkKills[%k] >= $ultra_renegades::tkLimit)
         return true;
      return false;
   }
   if(%opt == "vadmin")
      return URPort::on($ultra_renegades::PAVote);
   if(%opt == "vcmission" || %opt == "cmission")
   {
      if(%clientId.isAdmin && $ultra_renegades::PAMission)
         return true;
      return URPort::on($ultra_renegades::PVMission);
   }
   if(!%clientId.isAdmin)
      return false;
   if(%opt == "publicAdminOptions")
      return true;
   if(%opt == "kick")
      return URPort::on($ultra_renegades::PAKick);
   if(%opt == "ban")
      return URPort::on($ultra_renegades::PABan);
   if(%opt == "execute")
      return URPort::on($ultra_renegades::PAExecute);
   if(%opt == "fteamchange")
      return URPort::on($ultra_renegades::PATeamChange);
   if(%opt == "etd" || %opt == "dtd")
      return URPort::on($ultra_renegades::PATeamDamage);
   if(%opt == "cffa" || %opt == "ctourney" || %opt == "smatch")
      return URPort::on($ultra_renegades::PATourneyMode);
   if(%opt == "disableFT" || %opt == "enableFT")
      return URPort::on($ultra_renegades::PAFairTeams);
   if(%opt == "ctimelimit")
      return URPort::on($ultra_renegades::PATimeLimit);
   if(%opt == "reset")
      return URPort::on($ultra_renegades::PAResetDefaults);
   if(%opt == "insomniax")
      return URPort::on($ultra_renegades::PAModOptions);
   return false;
}

// UR Admin Settings: a public admin (lockout open) is offered the anti-TK levels and the safe
// station switch; everything else in that menu is a super admin entry.
function URPort::ixAllowed(%clientId, %opt)
{
   if(%clientId.isSuperAdmin)
      return true;
   if(!URPort::PA(%clientId, $ultra_renegades::PAModOptions))
      return false;
   if(%opt == "tkserv" || %opt == "tkclient" || %opt == "dsafestation" || %opt == "esafestation")
      return true;
   return false;
}

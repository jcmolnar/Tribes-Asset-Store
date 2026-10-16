$curVoteTopic = ""; 
$curVoteAction = ""; 
$curVoteOption = ""; 
$curVoteCount = 0; 

function Admin::changeMissionMenu(%clientId, %first)
{
   Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
   %index = 1;
	//DEMOBUILD - the demo build only has one "type" of missions
	if ($MList::TypeCount < 2) $TypeStart = 0;
	if (%first) $TypeStart = %first;
	else $TypeStart = 1;
   for(%type = $TypeStart; %type < $MLIST::TypeCount; %type++)
      if($MLIST::Type[%type] != "Training")
      {
         if(%index > 7)
         {
            Client::addMenuItem(%clientId, %index @ "More mission types..", "more " @ %index + %first -1);
            return;
         }
         Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
         %index++;
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
		%misType = $MLIST::Type[%mt]; if(%misType == "" || 
		%misType == "Training") return; 
		for(%i = 0; true; %i++) 
			{ 
			%misIndex = getWord($MLIST::MissionList[%mt], %i); 
			if(%misIndex == %mi) break; 
			if(%misIndex == -1) return; 
				} 
				if(($XKmod::PAMission && %clientId.isAdmin) || (%clientId.isSuperAdmin)) 
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

function processMenuCMType(%clientId, %options)
{

   if(getWord(%options, 0) == "more")
   {
      %first = getWord(%options, 1);
      Admin::changeMissionMenu(%clientId, %first);
      return;
	}

// - Snipers Mod - Allow for more mission types than standard limit - End. Tooken from BWAdmin

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
		%misType = $MLIST::Type[%mt]; if(%misType == "" || 
			%misType == "Training") return; 
			for(%i = 0; 
			true; %i++) 
				{ 
				%misIndex = getWord($MLIST::MissionList[%mt], %i); 
				if(%misIndex == %mi)
				break; 
				if(%misIndex == -1) 
				return; 
				} 
				if(($Snipers::PAMission && %clientId.isAdmin) || (%clientId.isSuperAdmin)) 
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
		if(Client::getName(%client) == $Owner::Name) 
		messageAll(1, $owner::Name @ " the owner, now has Super Admin status"); 
		else messageAll(1, Client::getName(%client) @ " now has Super Admin status."); 
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
	if((%client.isAdmin && $Snipers::PATimeLimit) || (%client.isSuperAdmin)) 
	{ 
		$Server::timeLimit = %time; 
		if(%time) messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s)."); else messageAll(0, Client::getName(%client) @ " disabled the time limit."); 
	} 
} 

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase) 
{ 
	if(%team >= 0 && %team < 8 && ((%client.isAdmin && $Snipers::PATeamInfo) || (%client.issuperAdmin))) 
	{ 
		$Server::teamName[%team] = %teamName; 
		$Server::teamSkin[%team] = %skinBase; 
		messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission."); 
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
			if(%admin == -1) messageAll(0, "Match start countdown forced by vote."); 
			else messageAll(0, "Match start countdown forced by " @ Client::getName(%admin)); 
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
			if(%admin == -1) messageAll(0, "Team damage set to ENABLED by consensus."); 
			else messageAll(0, Client::getName(%admin) @ " ENABLED team damage."); 
			} 
			else 
			{ 
			$Server::TeamDamageScale = 0; 
			if(%admin == -1) messageAll(0, "Team damage set to DISABLED by consensus."); 
			else messageAll(0, Client::getName(%admin) @ " DISABLED team damage."); 
		} 
	} 
} 

function Admin::kick(%admin, %client, %ban) 
{ 
	if((%admin == -1 || %admin.isAdmin) || (%admin == -2 || %admin == -3)) 
		{ 
		if(%ban) 
	{ %word = "banned"; 
		%cmd = "BAN: "; 
	} 
	else 
	{ 
		%word = "kicked"; %cmd = "KICK: "; 
		} 
		if(%admin.isAdmin && !%admin.isGod && %client.isGod) 
		{ 
		Client::sendMessage(%admin, 1, "You must have lost your mind to even think of trying that!~wmale3.wdsgst2.wav"); 
		Client::sendMessage(%client, 1, Client::getName(%admin) @ " tried to boot you, and is now paying the price~waccess_denied.wav"); 
		playNextAnim(%admin); 
		Player::blowUp(%admin); 
		Player::kill(%admin); 
		Client::onKilled(%admin,%admin); return; 
		} 
		if((%client.isSuperAdmin && !%admin.isGod) || 
		(%client.isAdmin && $PA::noKick == "true" && !%admin.isSuperAdmin) || 
		(!%admin.isSuperAdmin && (($Name::noKicka != "" && 
		Client::getName(%client) == $Name::noKicka) || 
		($Name::noKickb != "" && 
		Client::getName(%client) == $Name::noKickb) || 
		($Name::noKickc != "" && 
		Client::getName(%client) == $Name::noKickc) || 
		($Name::noKickd != "" && 
		Client::getName(%client) == $Name::noKickd)))) 
			{ 
			if(%admin == -1 || %admin == -2 || %admin == -3) messageAll(1, "A admin cannot be " @ %word @ "."); 
			else Client::sendMessage(%admin, 1, "A admin cannot be " @ %word @ "."); 
			Client::sendmessage(%client, 1, 
			Client::getName(%admin) @ " tried to kick you"); return; 
				} 
				%ip = Client::getTransportAddress(%client); 
				echo(%cmd @ Client::getName(%admin) @ " " @ %admin @ " " @ 
				Client::getName(%client) @ " " @ %client @ " " @ %ip); if(%ip == "") return; 
				Insomniax_leaveGame(%client); 
				if(%ban) BanList::add(%ip, 1800); 
				else BanList::add(%ip, $Snipers::BanKickTime); 
				%name = Client::getName(%client); if(%admin == -1) 
				{ 
				$CKickList = "Kick by vote " @ 
				Client::getName(%client) @ " " @ %ip; 
				if($ExportCKicks) export("CKickList","config\\KickList.log",true); 
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
			MessageAll(0, %name @ " was " @ %word @ " by " @ 
			Client::getName(%admin) @ "."); HSKick(%client, "You were " @ %word @ " by " @ 
			Client::getName(%admin)); 
			$KickList = Client::getName(%admin) @ " kicked " @ 
			Client::getName(%client) @ " " @ %ip; 
			if($ExportAKicks) export("KickList","config\\KickList.log",true); 
		} 
	} 
} 

function Admin::setModeFFA(%clientId) 
{ 
	if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin)) 
	{ 
		$Server::TeamDamageScale = 0; 
		if(%clientId == -1) messageAll(0, "Server switched to Free-For-All Mode."); 
		else messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ "."); 
		$Server::TourneyMode = false; 
		centerprintall(); 
		if(!$matchStarted && !$countdownStarted) 
		{ 
			if($Server::warmupTime) 
			Server::Countdown($Server::warmupTime); 
			else Game::startMatch(); 
		} 
	} 
} 

function Admin::setModeTourney(%clientId) 
{ 
	if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin)) 
	{ 
		$Server::TeamDamageScale = 1; 
		if(%clientId == -1) messageAll(0, "Server switched to Tournament Mode."); 
		else messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ "."); 
		$Server::TourneyMode = true; 
		Server::nextMission(); 
	} 
} 

function Admin::voteFailed() 
{ 
	$curVoteInitiator.numVotesFailed++; 
	if($curVoteAction == "kick" || $curVoteAction == "admin" || $curVoteAction == "tkkick") $curVoteOption.voteTarget = ""; 
} 

function Admin::voteSucceded() 
{ 
	$curVoteInitiator.numVotesFailed = ""; 
	if($curVoteAction == "kick") 
	{ 
		if($curVoteOption.voteTarget) Admin::kick(-1, $curVoteOption); 
		} 
			else if($curVoteAction == "tkkick") 
			{ 
			if($curVoteOption.voteTarget) Admin::kick(-2, $curVoteOption); 
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
					else if($curVoteAction == "tourney") Admin::setModeTourney(-1); 
				else if($curVoteAction == "ffa") Admin::setModeFFA(-1); 
			else if($curVoteAction == "etd") Admin::setTeamDamageEnable(-1, true); 
		else if($curVoteAction == "dtd") Admin::setTeamDamageEnable(-1, false); 
	else if($curVoteOption == "smatch") Admin::startMatch(-1); 
} 

function Admin::countVotes(%curVote) 
{ 
	if(%curVote != $curVoteCount) return; 
	%votesFor = 0; 
	%votesAgainst = 0; 
	%totalClients = 0; 
	%totalVotes = 0; 
	for(%cl = Client::getFirst(); 
	%cl != -1; %cl = Client::getNext(%cl)) 
	{ 
	%totalClients++; 
	if(%cl.vote == "yes") 
	{ 
		%votesFor++; 
		%totalVotes++; 
		} 
		else if(%cl.vote == "no") 
		{ 
		%votesAgainst++; %totalVotes++; 
		} 
		} 
		%minVotes = floor($Server::MinVotesPct * %totalClients); 
		if(%minVotes < $Server::MinVotes) %minVotes = $Server::MinVotes; 
		if(%totalVotes < %minVotes) 
		{ 
			%votesAgainst += %minVotes - %totalVotes; %totalVotes = %minVotes; 
			} 
			if(%votesFor / %totalVotes >= $Server::VoteWinMargin) 
			{ 
				messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions."); 
				Admin::voteSucceded(); 
				} 
				else 
				{ 
				if($curVoteAction == "kick" || $curVoteAction == "tkkick") 
				{ 
					%votesFor = 0; %totalVotes = 0; 
					for(%cl = Client::getFirst(); 
					%cl != -1; 
					%cl = Client::getNext(%cl)) 
					{ 
					if(GameBase::getTeam(%cl) == $curVoteOption.kickTeam) 
					{ 
						%totalVotes++; if(%cl.vote == "yes") %votesFor++; 
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
	if(%clientId.lastVoteTime == "") %clientId.lastVoteTime = -$Server::MinVoteTime; 
	%time = getIntegerTime(true) >> 5; 
	%diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time; 
	if(%diff > 0) 
	{ 
		Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds."); 
		return; 
		} 
		if($curVoteTopic == "") 
		{ 
			if(%clientId.numFailedVotes) %time += %clientId.numFailedVotes * $Server::VoteFailTime; 
			%clientId.lastVoteTime = %time; 
			$curVoteInitiator = %clientId; 
			$curVoteTopic = %topic; 
			$curVoteAction = %action; 
			$curVoteOption = %option; 
			if(%action == "kick" || %action == "tkkick") $curVoteOption.kickTeam = GameBase::getTeam($curVoteOption); 
			$curVoteCount++; 
			if(%action == "tkkick") 
			{ 
				%IXtker = getWord(%topic, 3); 
				%IXtkKills = $tkKills[getClientByName(%IXtker)]; 
				bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic @ "\n " @ %IXtker @ " <f0> has a Confirmed <f1>" @ %IXtkKills @ " TEAM KILLS", 10); 
				} 
				else bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10); 
				echo(Client::getName(%clientId) @ " voted to " @ $curVoteTopic); 
				for(%cl = Client::getFirst(); 
				%cl != -1; 
				%cl = Client::getNext(%cl)) %cl.vote = ""; 
				%clientId.vote = "yes"; 
				for(%cl = Client::getFirst(); 
				%cl != -1; 
				%cl = Client::getNext(%cl)) if(%cl.menuMode == "options") Game::menuRequest(%clientId); 
				schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", 
				$Server::VotingTime, 35); 
			} 
		else 
		{ 
		Client::sendMessage(%clientId, 0, "Voting already in progress."); 
	} 
} 

function Game::menuRequest(%clientId) 
{ 
	if ((%clientId.isbeingkicked || %clientId.freeze) && !%clientId.isAdmin) 
	{ 
	topprint(%clientId, "<jc><f2>\n\n\n\nYou can't get away that easy", 2);  
	return; 
	} 
	%curItem = 0; 
	Client::buildMenu(%clientId, "Options", "options", true); 
	if(!%clientId.selClient) 
	{ 
		if(!$matchStarted || !$Server::TourneyMode) 
		{  
			Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams"); 
			} 
		} 
		if(%clientId.selClient) 
		{ 
			%sel = %clientId.selClient; 
			%name = Client::getName(%sel); 
			if($curVoteTopic == "" && !%clientId.isSuperAdmin) 
			{ 
				if($Snipers::PAVote && !%clientId.isAdmin) 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel); 
				if($Snipers::PAKick && %clientId.isAdmin) 
				Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel); 
				else if($Snipers::PAKick) 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel); 
				if($Snipers::PABan && %clientId.isAdmin) 
				Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel); 
				if($Snipers::PATeamChange && %clientId.isAdmin) 
				Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel); 
				} 
			else if(%clientId.isSuperAdmin) 
			{ 
			if(!%sel.isAdmin) 
			Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel); 
			if(%clientId.isGod) 
			{ 
				if(%sel.isAdmin) 
				Client::addMenuItem(%clientId, %curItem++ @ "StripAdmin " @ %name, "strip " @ %sel); 
				} 
				Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel); 
				Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel); 
				Client::addMenuItem(%clientId, %curItem++ @ "BlowUP-n-Kill " @ %name, "execute " @ %sel); 
				Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel); 
				if(%sel.gag) 
				Client::addMenuItem(%clientId, %curItem++ @ "*Re-tongue " @ %name, "ungag " @ %sel); 
				else 
				Client::addMenuItem(%clientId, %curItem++ @ "De-tongue " @ %name, "gag " @ %sel); 
				if(%sel.freeze) 
				Client::addMenuItem(%clientId, %curItem++ @ "*Defrost " @ %name, "unfreeze " @ %sel); 
				else 
				Client::addMenuItem(%clientId, %curItem++ @ "Freeze " @ %name, "freeze " @ %sel);
				}
 
				if(%clientId.muted[%sel]) 
				Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel); 
				else 
				Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
				}

				if($curVoteTopic != "" && %clientId.vote == "") 
				{ 
					Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount); 
					Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount); 
					} 
					else if($curVoteTopic == "" && !%clientId.isSuperAdmin) 
					{ 
					if($Snipers::PAMission && %clientId.isAdmin) 
					Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission"); 
					else if($Snipers::PAMission) 
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission"); 

				if($Snipers::PATeamDamage && %clientId.isAdmin)
				if($Server::TeamDamageScale == 1.0)
				Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
				else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
				else if($Server::TeamDamageScale == 1.0)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
				else Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
				if($Snipers::PATourneyMode && %clientId.isAdmin)
				if($Server::TourneyMode)
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa"); 
					if(!$CountdownStarted && !$matchStarted) 
					Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch"); 
					} 
					else Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney"); 
					else if($Server::TourneyMode) 
					{ 
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa"); 
					if(!$CountdownStarted && !$matchStarted) 
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch"); 
					} 
					else Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney"); 
					if($Snipers::PATimeLimit && %clientId.isAdmin) 
					Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit"); 
					if($Snipers::PAResetDefaults && %clientId.isAdmin) 
					Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset"); 
					if($Snipers::PAModOptions && %clientId.isAdmin) 
					Client::addMenuItem(%clientId, %curItem++ @ "Server Options", "Snipers"); 
					if($Snipers::PAGPOptions && %clientId.isAdmin) 
					Client::addMenuItem(%clientId, %curItem++ @ "Game Play Controls", "bwgp"); 
					} 
				else if(%clientId.isSuperAdmin && !%clientId.selClient) 
				{ 
				Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission"); 
				if($Server::TeamDamageScale == 1.0) 
				Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd"); 
				else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd"); 
				if($Server::TourneyMode) 
				{ 
					Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa"); 
					if(!$CountdownStarted && !$matchStarted) 
					Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch"); 
					} 
					else Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney"); 
					Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit"); 
					Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset"); 
					Client::addMenuItem(%clientId, %curItem++ @ "Server Options", "Snipers");  
					} 
					%IXKiller = Insomniax_getKiller(%clientId); 
					if((%IXKiller != %clientId) && ($tkKills[%IXKiller] >= $Snipers::tkLimit)) 
					{ 
						if($Snipers::tkClientLvl == 1) 
						Client::addMenuItem(%clientId, %curItem++ @ "Kick Team Killer " @ Client::getName(Insomniax_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller))); 
						else Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick " @ Client::getName(Insomniax_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller))); 
						} 
						if(!%clientId.selClient && $curVoteTopic == "" && $Snipers::PersonalSkin) 
						{ 
							if(%clientId.custom == False) 
							{ 
							Client::addMenuItem(%clientId, %curItem++ @ "Use Personal Skin", "pSkin"); 
						} 
					else if(%clientId.custom == True) 
				{ 
			Client::addMenuItem(%clientId, %curItem++ @ "Use Team Skin", "pSkin"); 
		} 
	} 
} 

function remoteSelectClient(%clientId, %selId) 
{ 
	if(%clientId.selClient != %selId) 
	{ 
		%clientId.selClient = %selId; 
		if(%clientId.menuMode == "options") 
		Game::menuRequest(%clientId); 
		if(Insomniax_getVictim(%selId) == %selId) %selLastTK = "None Here"; 
		else %selLastTK = Client::getName(Insomniax_getVictim(%selId)); 
		if(Insomniax_getKiller(%selId) == %selId) %selTKdBy = "None Here"; 
		else %selTKdBy = Client::getName(Insomniax_getKiller(%selId)); 
		%selKills = $tkKills[%selId]; 
		remoteEval(%clientId, "setInfoLine", 1, "Team Kill Info for " @ Client::getName(%selId) @ ":"); 
		remoteEval(%clientId, "setInfoLine", 2, "Last TK Victim: " @ %selLastTK); 
		remoteEval(%clientId, "setInfoLine", 3, "Last TK'd By: " @ %selTKdBy); 
		remoteEval(%clientId, "setInfoLine", 4, "Number of TKs: " @ %selKills); 
		remoteEval(%clientId, "setInfoLine", 5, "Server: " @ Insomniax_ServerLvlTxt()); 
		if(%clientId.isSuperAdmin) remoteEval(%clientId, "setInfoLine", 6, "Client: " @ Client::getTransportAddress(%selId)); 
		else remoteEval(%clientId, "setInfoLine", 6, "Client: " @ Insomniax_ClientLvlTxt()); 
	} 
} 

function processMenuFPickTeam(%clientId, %team) 
{ 
	if(%clientId.isAdmin) 
	processMenuPickTeam(%clientId.ptc, %team, %clientId); 
	%clientId.ptc = ""; 
} 

function HSKick(%client, %mess) 
{ 
	%client.isbeingkicked = true; 
	if(%client.dead != 1) 
	{ 
		Player::dropItem(%client,Flag); 
		%numweapon = Player::getItemClassCount(%client,"Weapon"); 
		%max = getNumItems(); for (%i = 0; %i < %max; %i = %i + 1) 
		{ 
		%item = getItemData(%i); 
		%count = Player::getItemCount(%client,%item); 
		if(%count) 
		{ 
			Player::setItemCount(%client,%item,0); 
		} 
	} 
	Player::setDamageFlash(%client,0.75); 
	%rotZ = getWord(GameBase::getRotation(%client),2); 
	GameBase::setRotation(%client, "0 0 " @ %rotZ); 
	%armor = Player::getArmor(%client); 
	if(%armor == "darmor" || %armor == "dfemale") 
	%forceDir = Vector::getFromRot(GameBase::getRotation(%client),20,2100); 
	else %forceDir = Vector::getFromRot(GameBase::getRotation(%client),20,1500); 
	Player::applyImpulse(%client,%forceDir); 
	} 
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wbye.wav\");",1.5); 
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wdsgst2.wav\");",3.5); 
	schedule("Client::sendMessage("@%client@", 1,\"~wfemale4.wdeath.wav\");", 5.0); 
	schedule("Client::sendMessage("@%client@", 1,\"~wfemale5.wdeath.wav\");", 8.0); 
	if($Admin::KickMessage != "") 
	centerprint(%client, "<jc><f2>"@$Admin::KickMessage, 15); 
	schedule("Net::kick("@%client@", \"" @ escapeString(%mess) @ "\");",11); 
} 

function processMenuPickTeam(%clientId, %team, %adminClient) 
{ 
	if(%adminClient.isAdmin && %clientId.isSuperAdmin && !%adminClient.isSuperAdmin && !%clientId.isGod && !%adminClient.isGod) 
	{ 
		messageAll(1, "You can't change a SuperAdmin's team."); 
		return; 
	} 
	if(%adminClient.isAdmin && %ClientId.isGod && !%adminClient.isGod) 
	{ 
		Client::sendMessage(%adminClient, 1, "You can't change the owners team.~waccess_denied.wav"); 
		Client::sendMessage(%clientId, 1, Client::getName(%adminClient) @ " tried to teamchange you.~waccess_denied.wav"); 
		return; 
		} 
	else 
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
				{ 
				messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ", to think before he/she gets kicked."); 
				echo(Client::getName(%clientId) @ " to observer by " @ Client::getName(%adminClient)); 
				}  
				Game::resetScores(%clientId); 
				Game::refreshClientScore(%clientId); 
				} 
				return; 
			} 
			%player = Client::getOwnedObject(%clientId); 
			if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
			{ 
				playNextAnim(%clientId); 
				Player::kill(%clientId); 
				} 
				%clientId.observerMode = ""; 
				if(%adminClient == "") 
				messageAll(0, Client::getName(%clientId) @ " changed teams."); 
				else 
				{ 
				messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ", to keep the teams fair."); 
				echo(Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient)); 
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
					if($TeamEnergy[%team] != "Infinite") $TeamEnergy[%team] += $InitialPlayerEnergy; 
					if($Server::TourneyMode && !$CountdownStarted) 
				{ 
			bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0); %clientId.notready = true; 
		} 
	} 
} 

function processMenuOptions(%clientId, %option) 
{ 
	%opt = getWord(%option, 0); 
	%cl = getWord(%option, 1); 
	if(!SnipersPort::optAllowed(%clientId, %opt)) { Game::menuRequest(%clientId); return; } 
	if(%opt == "tkopt") %cl = Insomniax_getKiller(%clientId); 
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
	else if(%opt == "pSkin") 
	{ 
	if(%clientId.custom == False) 
	{ 
		%clientId.custom = True; 
		Client::setSkin(%clientId, $Client::info[%clientId, 0]); 
		} 
	else if(%clientId.custom == True) 
	{ 
	%clientId.custom = False; 
	Client::setSkin(%clientId, 
	$Server::teamSkin[Client::getTeam(%clientId)]); 
	} 
} 
else if(%opt == "changeteams") 
{ 
	if(!$matchStarted || !$Server::TourneyMode) 
	{ 
		Client::buildMenu(%clientId, "Game Status Options:", "PickTeam", true); 
		Client::addMenuItem(%clientId, "0Observer", -2); 
		Client::addMenuItem(%clientId, "1Auto-assign to low team", -1); 
		if(%clientId.observerMode != "" || %clientId.isAdmin) 
		{ 
			if($Snipers::fairTeams)
			{ 
				%i = Game::LowTeam(); 
				Client::addMenuItem(%clientId, (2) @ getTeamName(%i), %i); 
				} 
			else 
			{ 
			for(%i = 0; %i < getNumTeams(); %i = %i + 1) 
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i); 
			} 
		} 
		return; 
		} 
	} 
	else if(%opt == "mute") 
	%clientId.muted[%cl] = true; 
	else if(%opt == "unmute") 
	%clientId.muted[%cl] = ""; 
	else if(%opt == "gag") 
	{ 
	if(%cl.isGod && !%clientId.isGod) 
	{ 
		Client::sendMessage(%clientId, 1, "Somehow, you managed to remove your own tongue.~waccess_denied.wav"); 
		%clientId.gag = true; 
		return; 
		} 
		%cl.gag = true; 
		MessageAllExcept(%cl, 1, Client::getName(%cl) @ " got his tongue removed by " @ 
		Client::getName(%clientId) @ ".~wfemale5.wdeath.wav"); 
		Client::sendMessage(%cl, 1,"You just got your tongue removed by " @ 
		Client::getName(%clientId) @ ".  So shut the hell up.~wfemale5.wdeath.wav"); 
		echo(Client::getName(%clientId) @ " ::::DE-TONGUED:::: " @ 
		Client::getName(%cl)); 
		} 
		else if(%opt == "freeze") 
		{ 
		if(%cl.isGod && !%clientId.isGod) 
		{ 
			Client::sendMessage(%clientId, 1, "What are you, stupid or something?  God can't be frozen, but you can.~waccess_denied.wav"); 
			%clientId.freeze = true; 
			Client::setControlObject(%clientId, -1); 
			return; 
			} 
			%cl.freeze = true;
			Client::setControlObject(%cl, -1); 
			MessageAllExcept(%cl, 1, Client::getName(%cl) @ " was frozen by " @ Client::getName(%clientId) @ ".~waccess_denied.wav"); 
			Client::sendMessage(%cl, 1,"You just got frozen by " @ Client::getName(%clientId) @ ", for being an idiot.~waccess_denied.wav"); 
			echo(Client::getName(%clientId) @ " ***FROZE*** " @ Client::getName(%cl)); 
			} 
			else if(%opt == "unfreeze") 
			{ 
			MessageAllExcept(%cl , 1, Client::getName(%cl) @ " is being defrosted by " @ Client::getName(%clientId) @ ".~waccess_denied.wav"); 
			Client::sendMessage(%cl ,1,"You have just been defrosted by " @ Client::getName(%clientId) @ ".  Be nice.~waccess_denied.wav"); 
			%cl.freeze = false; 
			Client::setControlObject(%cl, Client::getOwnedObject(%cl)); 
			} 
			else if(%opt == "strip") 
			{ 
			if(%cl.isGod) return; %cl.isSuperAdmin = false; 
			%cl.isAdmin = false; 
			Client::sendMessage(%cl, 1, "Your admin status has been stripped by " @ Client::getName(%clientId) @ "~waccess_denied.wav"); 
			} 
			else if(%opt == "ungag") 
			{ 
			%cl.gag = false; 
			MessageAllExcept(%cl , 1, Client::getName(%cl) @ "'s tongue has been replaced by " @ Client::getName(%clientId) @ "."); 
			Client::sendMessage(%cl ,1,"Your tongue has been reinserted by " @ Client::getName(%clientId) @ ".  Use it properly this time.~waccess_denied.wav"); 
			} 
			else if(%opt == "vkick") 
			{ 
			%cl.voteTarget = true; 
			Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
			}
			else if(%opt == "vadmin") 
			{ 
			%cl.voteTarget = true; Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl); 
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
			%clientId.vote = "no"; centerprint(%clientId, "", 0); 
			} 
			else if(%opt == "kick") 
			{ 
			Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true); 
				Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl); 
				Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl); 
				return; 
			} 
			else if(%opt == "execute") 
			{ 
			Client::buildMenu(%clientId, "Confirm Destruction:", "maffirm", true); 
				Client::addMenuItem(%clientId, "1Blow Up " @ Client::getName(%cl), "yes " @ %cl); 
				Client::addMenuItem(%clientId, "2Don't Blow Up " @ Client::getName(%cl), "no " @ %cl); 
				return; 
			} 
			else if(%opt == "admin") 
			{ 
			Client::buildMenu(%clientId, "Confirm Admin:", "aaffirm", true); 
				Client::addMenuItem(%clientId, "1Make " @ 
				Client::getName(%cl) @ " Admin", "yes " @ %cl); 
				Client::addMenuItem(%clientId, "2Don't Make " @ Client::getName(%cl) @ " Admin", "no " @ %cl); 
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
			else if(%opt == "Snipers") 
			{ 
			Client::buildMenu(%clientId, "Server Options:", "ixsettings", true); 
				Client::addMenuItem(%clientId, "1Change Server Anti-TK Lvl", "tkserv " @ $Snipers::tkServerLvl); 
				Client::addMenuItem(%clientId, "2Change Client Anti-TK Lvl", "tkclient " @ $Snipers::tkClientLvl); 
				if(%clientId.isSuperAdmin) 
				Client::addMenuItem(%clientId, "3Public Admin Voting", "adminvote " @ $Snipers::PAVote); 
				if(%clientId.isSuperAdmin) 
				Client::addMenuItem(%clientId, "4Public Mission Change Voting", "changevote " @ $Snipers::PAMission ); 
				if(%clientId.isSuperAdmin) 
				Client::addMenuItem(%clientId, "5Public Kick Voting", "kickvote " @ $Snipers::PAKick ); 
				if(%clientId.isSuperAdmin) 
				Client::addMenuItem(%clientId, "6Fair Teams", "fairvote " @ $Snipers::fairTeams ); 
				if(%clientId.isSuperAdmin) 
				Client::addMenuItem(%clientId, "7Public Admin Lockouts", "palockout"); 
				if(%clientId.isSuperAdmin) 
				Client::addMenuItem(%clientId, "8Purge Public Admins", "purge " @ %clientId); 
				return; 
			} 
			else if(%opt == "tkopt") 
			{ 
			if($Snipers::tkClientLvl == 1) 
			Admin::Kick(-3, Insomniax_getKiller(%clientId)); 
			else 
			{ 
			%cl.voteTarget = true; 
			%clientId.selClient = Insomniax_getKiller(%clientId); 
			Admin::startVote(%clientId, "Kick Team Killer " @ 
			Client::getName(%cl), "tkkick", %cl); 
		} 
	} 
	Game::menuRequest(%clientId); 
}

function processMenuKAffirm(%clientId, %opt) 
{ 
	if(!SnipersPort::PA(%clientId, $Snipers::PAKick)) return; 
	if(getWord(%opt, 0) == "yes") 
	Admin::kick(%clientId, getWord(%opt, 1)); 
	Game::menuRequest(%clientId); 
} 

function processMenuMAffirm(%clientId, %opt) 
{ 
	if(!%clientId.isSuperAdmin) return; 
	if(getWord(%opt, 0) == "yes") 
	{ 
	%cl = getWord(%opt, 1); 
	if(%cl.isGod && !%clientId.isGod) 
	{ 
	Client::sendMessage(%clientId, 1, "How dare you try that to a GOD, you must pay the price instead"); 
	Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " tried to execute you.~waccess_denied.wav"); 
	playNextAnim(%clientId); 
	Player::blowUp(%clientId); Player::kill(%clientId); 
	Client::onKilled(%clientId,%clientId); 
	return; 
	} 
	MessageAllExcept(%cl , 1, "For being a general nuisance and complete moron, " @ Client::getName(%clientId) @ " placed a stick of dynamite in " @ Client::getName(%cl) @ "'s ass & lit the fuse."); 
	centerprint(%cl , "<jc><f1>" @ Client::getName(%clientId) @ " stuck a stick of dynamite up your ass and lit the fuse.\nJust shut-up and play the game correctly before you get kicked", 10); 
	echo(Client::getName(%clientId) @ " ::::BLEWUP:::: " @ Client::getName(%cl)); 
	playNextAnim(%cl); 
	Player::blowUp(%cl); 
	Player::kill(%cl); 
	Client::onKilled(%cl,%cl); 
	} 
	Game::menuRequest(%clientId); 
} 

function processMenuAAffirm(%clientId, %opt) 
{ 
	if(!%clientId.isSuperAdmin) return; 
	if(getWord(%opt, 0) == "yes") 
	{ 
		%cl = getWord(%opt, 1); 
		%cl.isAdmin = true; 
		Client::sendMessage(%cl,1,"You were given Admin Status by " @ Client::getName(%clientId) @ "; Please use good judgement."); 
		Client::sendMessage(%clientId,1,"You gave Admin Status to " @ Client::getName(%cl) @ "."); 
	} 
	Game::menuRequest(%clientId); 
} 

function processMenuBAffirm(%clientId, %opt) 
{ 
	if(!SnipersPort::PA(%clientId, $Snipers::PABan)) return; 
	if(getWord(%opt, 0) == "yes") 
	Admin::kick(%clientId, getWord(%opt, 1), true); 
	Game::menuRequest(%clientId); 
} 

function processMenuRAffirm(%clientId, %opt) 
{ 
	if(%opt == "yes" && SnipersPort::PA(%clientId, $Snipers::PAResetDefaults)) 
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
	if(!SnipersPort::PA(%clientId, $Snipers::PAModOptions)) return; 
	if(!%clientId.isSuperAdmin && %opt != "tkserv" && %opt != "tkclient") return; 
	if(%opt == "patoggle") 
	{ 
	Client::sendMessage(%clientId, 3, "Public Admin Vote is now " @ isonoff(%cl) @ "."); 
	$Snipers::PAVote = %cl; 
	} 
	if(%opt == "cmtoggle") 
	{ 
	Client::sendMessage(%clientId, 3, "Public Mission Vote is now " @ isonoff(%cl) @ "."); 
	$Snipers::PAMission = %cl; 
	} 
	if(%opt == "pktoggle") 
	{ 
	Client::sendMessage(%clientId, 3, "Public Kick Vote is now " @ isonoff(%cl) @ "."); 
	$Snipers::PAKick = %cl; 
	} 
	if(%opt == "fairtoggle") 
	{ 
	Client::sendMessage(%clientId, 3, "Fair Teams is now " @ isonoff(%cl) @ "."); 
	$Snipers::fairTeams = %cl; 
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
					Client::addMenuItem(%clientId, "1Team Changing " @ isonoff($Snipers::PATeamChange), "teamchange " @ $Snipers::PATeamChange); 
					Client::addMenuItem(%clientId, "2Kicking " @ isonoff($Snipers::PAKick), "kick " @ $Snipers::PAKick); 
					Client::addMenuItem(%clientId, "3Banning " @ isonoff($Snipers::PABan), "ban " @ $Snipers::PABan); 
					Client::addMenuItem(%clientId, "4Change Mission " @ isonoff($Snipers::PAMission), "mission " @ $Snipers::PAMission); 
					Client::addMenuItem(%clientId, "5Team Damage " @ isonoff($Snipers::PATeamDamage), "teamdamage " @ $Snipers::PATeamDamage); 
					Client::addMenuItem(%clientId, "6Tourney Mode " @ isonoff($Snipers::PATourneyMode), "tourney " @ $Snipers::PATourneyMode); 
					Client::addMenuItem(%clientId, "7Time Limit " @ isonoff($Snipers::PATimeLimit), "timelimit " @ $Snipers::PATimeLimit); 
					Client::addMenuItem(%clientId, "8Additional Lockouts ...", "additional"); 
					return; 
				} 
				else if(%opt == "adminvote") 
			{ 
			Client::buildMenu(%clientId, "Public Admin Vote is " @ isonoff(%cl), "ixsettings", true); 
				Client::addMenuItem(%clientId, "0Turn OFF Public Admin", "patoggle false"); 
				Client::addMenuItem(%clientId, "1Turn ON Public Admin", "patoggle true"); 
				return; 
			} 
			else if(%opt == "changevote") 
		{ 
		Client::buildMenu(%clientId, "Public Mission Change Vote is " @ isonoff(%cl), "ixsettings", true); 
			Client::addMenuItem(%clientId, "0Turn OFF Mission Change", "cmtoggle false"); 
			Client::addMenuItem(%clientId, "1Turn ON Mission Change", "cmtoggle true"); 
			return; 
		} 
		else if(%opt == "kickvote") 
	{ 
	Client::buildMenu(%clientId, "Public Kick Vote is " @ isonoff(%cl), "ixsettings", true); 
		Client::addMenuItem(%clientId, "0Turn OFF Public Kick", "pktoggle false"); 
		Client::addMenuItem(%clientId, "1Turn ON Public Kick", "pktoggle true"); 
		return; 
	} 
	else if(%opt == "fairvote") 
	{ 
	Client::buildMenu(%clientId, "Fair Teams is " @ isonoff(%cl), "ixsettings", true); 
		Client::addMenuItem(%clientId, "0Turn OFF Fair Teams", "fairtoggle false"); 
		Client::addMenuItem(%clientId, "1Turn ON Fair Teams", "fairtoggle true"); 
		return; 
	} 
	else if(%opt == "purge") 
	{ 
		Client::sendMessage(%cl,3,"Purging All Public Admins of Admin Status."); 
		Insomniax_clearPA(%cl); 
		Client::sendMessage(%cl,3,"Purging Complete."); 
		return; 
	} 
} 

function processMenuPALockouts(%clientId, %option) 
{ 
	if(!%clientId.isSuperAdmin) return; 
	%opt = getWord(%option, 0); 
	%toggle = getWord(%option, 1); 
	if(%opt == "additional") 
	{ 
	Client::buildMenu(%clientId, "Current Public Admin Lockouts:","PALockouts", true); 
		Client::addMenuItem(%clientId, "1Server Defaults " @ isonoff($Snipers::PAResetDefaults), "reset " @ $Snipers::PAResetDefaults); 
		Client::addMenuItem(%clientId, "2Server Options " @ isonoff($Snipers::PAModOptions), "modopt " @ $Snipers::PAModOptions); 
		Client::addMenuItem(%clientId, "3Set Team Info " @ isonoff($Snipers::PATeamInfo), "teaminfo " @ $Snipers::PATeamInfo); 
		Client::addMenuItem(%clientId, "4Turn ON all Options", "allon"); 
		return; 
	} 
	else if(%opt == "allon") 
	{ 
	%access = "All Options"; 
	%toggle = "false"; 
	$Snipers::PATeamChange = "true"; 
	$Snipers::PAKick = "true"; 
	$Snipers::PABan = "true"; 
	$Snipers::PAMission = "true"; 
	$Snipers::PATeamDamage = "true"; 
	$Snipers::PATourneyMode = "true"; 
	$Snipers::PATimeLimit = "true"; 
	$Snipers::PAResetDefaults = "true"; 
	$Snipers::PAModOptions = "true"; 
	$Snipers::PACurse = "true"; 
	} 
	else if(%opt == "teamchange") 
	{ 
	%access = "Team Changing"; 
	if(%toggle) 
	$Snipers::PATeamChange = "false"; 
	else $Snipers::PATeamChange = "true"; 
	} 
	else if(%opt == "kick") 
	{ 
	%access = "Kicking"; 
	if(%toggle) 
	$Snipers::PAKick = "false"; 
	else $Snipers::PAKick = "true"; 
	} 
	else if(%opt == "ban") 
	{ 
	%access = "Banning"; 
	if(%toggle) 
	$Snipers::PABan = "false"; 
	else $Snipers::PABan = "true"; 
	} 
	else if(%opt == "mission") 
	{ 
	%access = "Changing Mission"; 
	if(%toggle) 
	$Snipers::PAMission = "false"; 
	else $Snipers::PAMission = "true"; 
	} 
	else if(%opt == "teamdamage") 
	{ 
	%access = "Team Damage"; 
	if(%toggle) 
	$Snipers::PATeamDamage = "false"; 
	else $Snipers::PATeamDamage = "true"; 
	} 
	else if(%opt == "tourney") 
	{ 
	%access = "Tourney Mode"; 
	if(%toggle) 
	$Snipers::PATourneyMode = "false"; 
	else $Snipers::PATourneyMode = "true"; 
	} 
	else if(%opt == "timelimit") 
	{ 
	%access = "Mission Time Limit"; 
	if(%toggle) 
	$Snipers::PATimeLimit = "false"; 
	else $Snipers::PATimeLimit = "true"; 
	} 
	else if(%opt == "reset") 
	{ 
	%access = "Reseting Sever to Defaults"; 
	if(%toggle) 
	$Snipers::PAResetDefaults = "false"; 
	else $Snipers::PAResetDefaults = "true"; 
	} 
	else if(%opt == "modopt") 
	{ 
	%access = "Snipers Mod Options"; 
	if(%toggle) 
	$Snipers::PAModOptions = "false"; 
	else $Snipers::PAModOptions = "true"; 
	} 
	else if(%opt == "teaminfo") 
	{ 
	%access = "Setting Team Info"; 
	if(%toggle) 
	$Snipers::PATeamInfo = "false"; 
	else $Snipers::PATeamInfo = "true"; 
	} 
	if(%toggle) %toggle = "false"; 
	else %toggle = "true"; 
	Client::sendMessage(%clientId, 3, "Public Admin Access to " @ %access @ " is now " @ isonoff(%toggle) @ "."); 
} 

function isonoff(%toggle) 
{ 
	if(%toggle) return "On"; 
	else return "Off"; 
} 

function processMenuServerLvl(%clientId, %option) 
{ 
	if(!SnipersPort::PA(%clientId, $Snipers::PAModOptions)) return; 
	$Snipers::tkServerLvl = %option; 
	if(%option == 0) messageAll(0, "SERVER:TK Protection Level Set to Zero. (Logging TK's only)."); 
	if(%option == 1) messageAll(0, "SERVER:TK Protection Level Set to One. (Auto Vote)."); 
	if(%option == 2) messageAll(0, "SERVER:TK Protection Level Set to Two. (Auto Vote Until Kicked)."); 
	if(%option == 3) messageAll(0, "SERVER:TK Protection Level Set to Three. (Auto Kick)."); 
} 

function processMenuClientLvl(%clientId, %option) 
{ 
	if(!SnipersPort::PA(%clientId, $Snipers::PAModOptions)) return; 
	$Snipers::tkClientLvl = %option; 
	if(%option == 0) messageAll(0, "SERVER: Client TK Vote Option Engaged. (From Options Menu)."); 
	if(%option == 1) messageAll(0, "SERVER: Client TK Kick Option Engaged. (From Options Menu)."); 
} 

function processMenuAKill(%clientId, %option) 
{ 
	if(!%clientId.isSuperAdmin) return; 
	$Insomniax::LeaveAreaTime = %option; 
	if(%option == 0) messageAll(0, "SERVER: Leaving Mission Area Now Does not Kill you."); 
	else messageAll(0, "SERVER: Leaving Mission Area Now Kills you in " @ %option @ " Seconds."); 
} 

function Insomniax_ServerLvlTxt() 
{ 
	if($Snipers::tkServerLvl == 0) %tkText = "Only Logging TK's"; else if($Snipers::tkServerLvl == 1) 
	%tkText = "Votes at " @ $Snipers::tkLimit @ " TK's"; 
	else if($Snipers::tkServerLvl == 2) %tkText = "Votes at " @ $Snipers::tkLimit @ " TKs and Kicks at " @ $Snipers::tkLimit * $Snipers::tkMultiple @ " TK's"; 
	else if($Snipers::tkServerLvl == 3) %tkText = "Kicks at " @ $Snipers::tkLimit @ " TK's"; 
	else %tkText = "ERROR: Server Level set to Unkown Level"; return %tkText; 
} 

function Insomniax_ClientLvlTxt() 
{ 
	if($Snipers::tkClientLvl == 0) %tkText = "Vote Option at " @ $Snipers::tkLimit @ " TK's"; 
	else if($Snipers::tkClientLvl == 1) %tkText = "Kick Option at " @ $Snipers::tkLimit @ "TK's"; 
	else %tkText = "ERROR: Client Level set to Unkown Level"; return %tkText; 
} 

function Insomniax_setTeamKill(%victimId, %killerId) 
{ 
	$tkVictim[%killerId] = %victimId; 
	$tkKiller[%victimId] = %killerId; 
	$tkKills[%killerId] += 1; 
	%trigger = $tkKills[%killerId] % $Snipers::tkLimit; 
	%tkTopKills = $Snipers::tkLimit * $Snipers::tkMultiple; 
	if(($tkKills[%killerId] >= $Snipers::tkLimit) && (!%trigger)) 
	{ 
		if($Snipers::tkServerLvl) 
		{ 
			if($Snipers::tkServerLvl != 3) 
			{ 
				if(($tkKills[%killerId] >= %tkTopKills) && ($Snipers::tkServerLvl != 1)) 
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

function Insomniax_getKiller(%clientId) 
{ 
	return $tkKiller[%clientId]; 
} 

function Insomniax_getVictim(%clientId) 
{ 
	return $tkVictim[%clientId]; 
} 

function Insomniax_leaveGame(%clientId) 
{ 
	if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId)) 
	$tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId]; 
	if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId)) 
	$tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId]; 
	$tkKiller[%clientId] = %clientId; 
	$tkVictim[%clientId] = %clientId; 
	$tkKills[%clientId] = 0; 
	$empTime[%clientId] = 0; 
	return; 
} 

function Insomniax_joinGame(%clientId) 
{ 
	if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId)) 
	$tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId]; 
	if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId)) 
	$tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId]; 
	$tkVictim[%clientId] = %clientId; 
	$tkKiller[%clientId] = %clientId; 
	$tkKills[%clientId] = 0; 
	$empTime[%clientId] = 0; 
} 

function Insomniax_clearPA(%admin) 
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

function ixwhoison() 
{ 
	echo(" # cl: CLIENT nm: NAME ip: ADDRESS"); 
	%numPlayers = getNumClients(); 
	for(%i = 0; %i < %numPlayers; %i++) 
	{ 
		%pl = getClientByIndex(%i); 
		%name = Client::getName(%pl); 
		%ip = Client::getTransportAddress(%pl); 
		echo(" " @ %i @ " cl: " @ %pl @ " nm: " @ %name @ " ip: " @ %ip); 
	} 
}

// ---- 1.50 port: guards for the menu handlers above (nothing above this line is new) ----
function SnipersPort::PA(%clientId, %lock)
{
	// super admin, or public admin with that lockout open
	if(%clientId.isSuperAdmin) return true;
	if(%clientId.isAdmin && %lock) return true;
	return false;
}

function SnipersPort::optAllowed(%clientId, %opt)
{
	if(%opt == "admin" || %opt == "execute" || %opt == "gag" || %opt == "ungag" || %opt == "freeze" || %opt == "unfreeze")
	{
		if(%clientId.isSuperAdmin) return true;
		return false;
	}
	if(%opt == "strip")
	{
		if(%clientId.isGod) return true;
		return false;
	}
	if(%opt == "kick") return SnipersPort::PA(%clientId, $Snipers::PAKick);
	if(%opt == "ban") return SnipersPort::PA(%clientId, $Snipers::PABan);
	if(%opt == "fteamchange") return SnipersPort::PA(%clientId, $Snipers::PATeamChange);
	if(%opt == "cmission") return SnipersPort::PA(%clientId, $Snipers::PAMission);
	if(%opt == "etd" || %opt == "dtd") return SnipersPort::PA(%clientId, $Snipers::PATeamDamage);
	if(%opt == "cffa" || %opt == "ctourney" || %opt == "smatch") return SnipersPort::PA(%clientId, $Snipers::PATourneyMode);
	if(%opt == "ctimelimit") return SnipersPort::PA(%clientId, $Snipers::PATimeLimit);
	if(%opt == "reset") return SnipersPort::PA(%clientId, $Snipers::PAResetDefaults);
	if(%opt == "Snipers") return SnipersPort::PA(%clientId, $Snipers::PAModOptions);
	if(%opt == "egm" || %opt == "dgm" || %opt == "ehm" || %opt == "dhm" || %opt == "eth" || %opt == "dth")
	{
		if(%clientId.isAdmin) return true;
		return false;
	}
	if(%opt == "vadmin")
	{
		if($Snipers::PAVote) return true;
		return false;
	}
	if(%opt == "vkick")
	{
		if($Snipers::PAKick) return true;
		return false;
	}
	if(%opt == "vcmission")
	{
		if($Snipers::PAMission) return true;
		return false;
	}
	if(%opt == "tkopt")
	{
		// same condition as the menu entry (Game::menuRequest)
		%k = Insomniax_getKiller(%clientId);
		if(%k == "" || %k == %clientId) return false;
		if($tkKills[%k] < $Snipers::tkLimit) return false;
		return true;
	}
	return true;
}

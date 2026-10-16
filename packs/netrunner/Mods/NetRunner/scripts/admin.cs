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
	if(%misType == "Training") return;
	for(%i = 0; true; %i++)
	{
		%misIndex = getWord($MLIST::MissionList[%mt], %i);
		if(%misIndex == %mi) break;
		if(%misIndex == -1) return;
	}
	if(%clientId.isAdmin || %clientId.isSuperAdmin)
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
	if(%client.isSuperAdmin) $Server::Password = %password;
}

function remoteSetTimeLimit(%client, %time)
{
	%time = floor(%time);
	if(%time == $Server::timeLimit || (%time != 0 && %time < 1)) return;
	if(%client.isAdmin)
	{
		$Server::timeLimit = %time;
		if(%time) messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s).");
		else messageAll(0, Client::getName(%client) @ " disabled the time limit.");
	}
}

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
	if(%team >= 0 && %team < 8 && %client.isAdmin)
	{
		$Server::teamName[%team] = %teamName;
		$Server::teamSkin[%team] = %skinBase;
		messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ". Changes will take effect next mission.");
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
			$Server::TeamDamageScale = $NetRunner::TeamDamageScale;
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
	if(%admin != %client && (%admin == -1 || %admin.isAdmin))
	{
		if(%ban && !%admin.isSuperAdmin) return;
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
			if(%admin == -1) messageAll(0, "A super admin cannot be " @ %word @ ".");
			else Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
			return;
		}
		%ip = Client::getTransportAddress(%client);
		echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);
		if(%ip == "") return;
		if(%ban) BanList::add(%ip, 1800);
		else BanList::add(%ip, 180);
		%name = Client::getName(%client);
		if(%admin == -1)
		{
			MessageAll(0, %name @ " was " @ %word @ " from vote.");
			Net::kick(%client, "You were " @ %word @ " byconsensus.");
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
		if(%clientId == -1) messageAll(0, "Server switched to Free-For-All Mode.");
		else messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".");
		$Server::TourneyMode = false;
		centerprintall(); // clear the messages
		if(!$matchStarted && !$countdownStarted)
		{
			if($Server::warmupTime) Server::Countdown($Server::warmupTime);
			else Game::startMatch();
		}
	}
}

function Admin::setModeTourney(%clientId)
{
	if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
	{
		$Server::TeamDamageScale = $NetRunner::TeamDamageScale;
		if(%clientId == -1) messageAll(0, "Server switched to Tournament Mode.");
		else messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".");
		$Server::TourneyMode = true;
		Server::nextMission();
	}
}

function Admin::voteFailed()
{
	$curVoteInitiator.numVotesFailed++;
	if($curVoteAction == "kick" || $curVoteAction == "admin") $curVoteOption.voteTarget = "";
}

function Admin::voteSucceded()
{
	$curVoteInitiator.numVotesFailed = "";
	if($curVoteAction == "kick")
	{
		if($curVoteOption.voteTarget) Admin::kick(-1, $curVoteOption);
	}
	else if($curVoteAction == "admin")
	{
		if($curVoteOption.voteTarget)
		{
			$curVoteOption.isAdmin = true;
			messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.");
			if($curVoteOption.menuMode == "options") Game::menuRequest($curVoteOption);
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
// if %end is true, cancel the vote either way
	if(%curVote != $curVoteCount) return;
	%votesFor = 0;
	%votesAgainst = 0;
	%votesAbstain = 0;
	%totalClients = 0;
	%totalVotes = 0;
	%cancel = 0;
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
		else if(%cl.vote == "cancel") %cancel++;
		else %votesAbstain++;
		%cl.vote = "";
	}
// if an admin cancelled, cancel the vote.
	if(!%cancel)
	{
		%minVotes = floor($Server::MinVotesPct * %totalClients);
		if(%minVotes < $Server::MinVotes) %minVotes = $Server::MinVotes;
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
			if(%totalVotes < %minVotes) %totalVotes = %minVotes;
		}
		if(%votesFor / %totalVotes >= %margin)
		{
			messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
			Admin::voteSucceded();
		}
// special team kick option:
		else
		{
// check if the team did a majority number on him:
			if($curVoteAction == "kick")
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
	}
	else messageAll(0, "Vote cancelled.");
	$curVoteTopic = "";
}

function Admin::startVote(%clientId, %topic, %action, %option)
{
	if(%clientId.lastVoteTime == "") %clientId.lastVoteTime = -$Server::MinVoteTime;
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
		if(%clientId.numFailedVotes) %time += %clientId.numFailedVotes * $Server::VoteFailTime;
		%clientId.lastVoteTime = %time;
		$curVoteInitiator = %clientId;
		$curVoteTopic = %topic;
		$curVoteAction = %action;
		$curVoteOption = %option;
		if(%action == "kick") $curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
		$curVoteCount++;
		bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) %cl.vote = "";
		%clientId.vote = "yes";
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 
		{
			if(%cl.menuMode == "options") Game::menuRequest(%clientId);
		}
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
	Client::buildMenu(%clientId, "NetRunner Options", "options", true);
	if(!%clientId.selClient)
	{
		if(!$matchStarted || !$Server::TourneyMode) Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
		Client::addMenuItem(%clientId, %curItem++ @ "NetRunner Help", "helpprint");
		if(!%clientId.isSuperAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Voting Items", "votingitems");
			if(%clientId.isAdmin)Client::addMenuItem(%clientId, %curItem++ @ "Admin Functions", "adminrights");
		}
		if(%clientId.isSuperAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Super Admin Functions", "superrights");
		if($curVoteTopic != "" && %clientId.vote == "")
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
			Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
			if(%clientId.isAdmin || %clientId.isSuperAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Cancel Vote" @ $curVoteTopic, "cancelVote " @ $curVoteCount);
		}
	}
	if(%clientId.selClient)
	{
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);
		if($curVoteTopic == "")
		{
			if(%clientId.observerMode == "observerOrbit") Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
			if(%clientId.muted[%sel]) Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
			else Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
			if(!%clientId.isAdmin && !%clientId.isSuperAdmin)
			{
				if ($NetRunner::VoteAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
				if ($NetRunner::VoteKick) Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
			}
			else
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
				if(%clientId.isSuperAdmin)
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
					Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
					Client::addMenuItem(%clientId, %curItem++ @ "Kill " @ %name, "kill " @ %sel);
					if (%sel.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "DeAdmin " @ %name, "deadmin " @ %sel);
					else Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
					if (%sel.muteAll) Client::addMenuItem(%clientId, %curItem++ @ "Remove Admin Mute " @ %name, "deadmute " @ %sel);
					else Client::addMenuItem(%clientId, %curItem++ @ "Admin Mute " @ %name, "admute " @ %sel);
				}
			}
		}
	}
}

function remoteSelectClient(%clientId, %selId)
{
	if(%clientId.selClient != %selId)
	{
		%clientId.selClient = %selId;
		if(%clientId.menuMode == "options") Game::menuRequest(%clientId);
		remoteEval(%clientId, "setInfoLine", 1, "Player Info for " @ Client::getName(%selId) @ ":");
		remoteEval(%clientId, "setInfoLine", 2, "Real Name: " @ $Client::info[%selId, 1]);
		remoteEval(%clientId, "setInfoLine", 3, "Email Addr: " @ $Client::info[%selId, 2]);
		remoteEval(%clientId, "setInfoLine", 4, "Tribe: " @ $Client::info[%selId, 3]);
		remoteEval(%clientId, "setInfoLine", 5, "Current Credits: " @ %selId.creds);
		remoteEval(%clientId, "setInfoLine", 6, "Current Deck: " @ $ArmorName[%selId.armor].description);
	}
}

function processMenuFPickTeam(%clientId, %team)
{
	if(%clientId.isSuperAdmin) processMenuPickTeam(%clientId.ptc, %team, %clientId);
	%clientId.ptc = "";
}

function processMenuPickTeam(%clientId, %team, %adminClient)
{
//	checkPlayerCash(%clientId);
	if(%team != -1 && %team == Client::getTeam(%clientId)) return;
	if(%adminClient == "" && %team >= 0 && !NRPort::teamAllowed(%clientId, %team)) return; // PORT
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
			if(%adminClient == "") messageAll(0, Client::getName(%clientId) @ " became an observer.");
			else messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
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
	if(%adminClient == "") messageAll(0, Client::getName(%clientId) @ " changed teams.");
	else messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
	if(%team == -1)
	{
		Game::assignClientTeam(%clientId);
		%team = Client::getTeam(%clientId);
	}
	Group::iterateRecursive("deploy" @ %clientId, GameBase::setDamageLevel, 50);
	GameBase::setTeam(%clientId, %team);
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1) Client::setGuiMode(%clientId,1);
	Client::setControlObject(%clientId, -1);
	Game::playerSpawn(%clientId, false);
	%team = Client::getTeam(%clientId);
	if($Server::TourneyMode && !$CountdownStarted)
	{
		bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
		%clientId.notready = true;
	}
}

function checkTeams()
{
	%numTeams = getNumTeams();
	%numPlayers = getNumClients();
	for(%i=0; %i < %numTeams; %i++) %numTeamPlayers[%i] = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%team = Client::getTeam(%cl);
		if(%team != -1)  %numTeamPlayers[%team]++;
	}
	%lowPlayer = %numTeamPlayers[0];
	%lowTeam = 0;
	%tieteams = 0;	
	for(%i=1; %i < %numTeams; %i++)
	{
		if(%numTeamPlayers[%i] == %lowPlayer)
		{
			%tieteams++;
		}
		if(%numTeamPlayers[%i] < %lowPlayer)
		{
			%lowTeam = %i;
			%lowPlayer = %numTeamPlayers;
		}
	}
	if (%tieteams == %numTeams - 1) return -1;
	return %lowTeam;
} 

function processMenuOptions(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(!NRPort::optionAllowed(%clientId, %opt)) { Game::menuRequest(%clientId); return; } // PORT
//======================================== Voting Items
	if(%opt == "votingitems")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "Voting Items", "options", true);
		if($curVoteTopic == "") 
		{
			if(!%clientId.isAdmin)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
				if($NetRunner::VoteDTD)
				{
					if($Server::TeamDamageScale == 1.0) Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
					else Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
				}         
			}
			if($NetRunner::VoteFFA)
			{
				if($Server::TourneyMode)
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
					if(!$CountdownStarted && !$matchStarted) Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
				}
				else Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
			}
		}
		return;
	}
//======================================== Admin Options
	if(%opt == "adminrights")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "Admin Functions", "options", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
		if($Server::TeamDamageScale > 0) Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd"); 
		else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
		return;
	}
//======================================== Super Admin Options
	if(%opt == "superrights")
	{   
		%curItem = 0;
		Client::buildMenu(%clientId, "Super Admin Functions", "options", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
		if($Server::TeamDamageScale > 0) Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd"); 
		else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
		if($Server::TourneyMode)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
			if(!$CountdownStarted && !$matchStarted) Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
		}
		else Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
		Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");		
		return;
	}
//======================================== Print Help Screens.
	if (%opt == "helpprint") 
	{ 	
		%curItem = 0;
		Client::buildMenu(%clientId, "NetRunner GameHelpers", "helpers", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Locate Flag", "locate");
		Client::addMenuItem(%clientId, %curItem++ @ "Deck Info", "helparmor");
		Client::addMenuItem(%clientId, %curItem++ @ "Program Info", "helpprogram");
		Client::addMenuItem(%clientId, %curItem++ @ "Transport Info", "helptrans");
		return;
	} 	
//======================================== Force Team Change
	if(%opt == "fteamchange")
	{
		%clientId.ptc = %cl;
		Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
		Client::addMenuItem(%clientId, "0Observer", -2);
		if($matchStarted && $Server::TourneyMode) return;
		Client::addMenuItem(%clientId, "1Automatic", -1);
		for(%i = 0; %i < getNumTeams(); %i++) Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		return;
	}      
//======================================== Team Change
	if (%opt == "changeteams")
	{
		if(!$matchStarted || !$Server::TourneyMode)
		{
			Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
			Client::addMenuItem(%clientId, "0Observer", -2);
			Client::addMenuItem(%clientId, "1Automatic", -1);
		}
		if($NetRunner::KeepBalanced)
		{
			%i = checkTeams();
			if(%i != -1) Client::addMenuItem(%clientId, (2) @ getTeamName(%i), %i);
			else
			{
				if(Client::getTeam(%clientId) == -1)
				{
					for(%i = 0; %i < getNumTeams(); %i++)
					Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
				} 
			}
		}
		else
		{
			for(%i = 0; %i < getNumTeams(); %i++)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		}
		return;
	}
//======================================== Mute Player
	if (%opt == "mute") %clientId.muted[%cl] = true;
//======================================== Unmute Player
	if (%opt == "unmute") %clientId.muted[%cl] = "";
//======================================== Vote to Kick Player
	if (%opt == "vkick")
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
	}
//======================================== Vote to Admin Player
	if (%opt == "vadmin")
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
	}
//======================================== Vote to Start Match
	if (%opt == "vsmatch") Admin::startVote(%clientId, "start the match", "smatch", 0);
//======================================== Vote to Enable Team Damage
	if (%opt == "vetd") Admin::startVote(%clientId, "enable team damage", "etd", 0);
//======================================== Vote to Disable Team Damage
	if (%opt == "vdtd") Admin::startVote(%clientId, "disable team damage", "dtd", 0);
//======================================== Enable Team Damage
	if (%opt == "etd") Admin::setTeamDamageEnable(%clientId, true);
//======================================== Disable Team Damage
	if (%opt == "dtd") Admin::setTeamDamageEnable(%clientId, false);
//======================================== Vote to Change to Free For All
	if (%opt == "vcffa") Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
//======================================== Vote to Change to Tournament Mode
	if (%opt == "vctourney") Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
//======================================== Change to Free For All
	if (%opt == "cffa") Admin::setModeFFA(%clientId);
//======================================== Change to Tourney Mode
	if (%opt == "ctourney") Admin::setModeTourney(%clientId);
//======================================== Vote Yes
	if (%opt == "voteYes" && %cl == $curVoteCount) 
	{
		%clientId.vote = "yes";
		centerprint(%clientId, "", 0);
	}
//======================================== Vote No
	if (%opt == "voteNo" && %cl == $curVoteCount) 
	{
		%clientId.vote = "no";
		centerprint(%clientId, "", 0);
	}
//======================================== Cancel Vote
	if (%opt == "cancelVote" && %cl == $curVoteCount) 
	{
		%clientId.vote = "cancel";
		centerprint(%clientId, "", 0);
	}
//======================================== Kick Player
	if (%opt == "kick") 
	{
		Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
		Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
//======================================== Admin Confirm
	if (%opt == "admin") 
	{
		Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
		Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
//======================================== DeAdmin Confirm
	if (%opt == "deadmin") 
	{
		Client::buildMenu(%clientId, "Confirm deadmim:", "daffirm", true);
		Client::addMenuItem(%clientId, "1DeAdmin " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't DeAdmin " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
//======================================== Admin Mute
	if (%opt == "admute") 
	{
		Client::buildMenu(%clientId, "Confirm Admim Mute:", "amaffirm", true);
		Client::addMenuItem(%clientId, "1Admin Mute" @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Admin Mute" @ Client::getName(%cl), "no " @ %cl);
		return;
	}
//======================================== Remove Admin Mute
	if (%opt == "deadmute") 
	{
		Client::buildMenu(%clientId, "Confirm Remove Admim Mute:", "dmaffirm", true);
		Client::addMenuItem(%clientId, "1Remove Admin Mute " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Remove Admin Mute " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
//======================================== Ban Player
	if (%opt == "ban") 
	{
		Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
		Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
//======================================== Kill Player
	if (%opt == "kill") 
	{
		Player::setArmor(%cl,larmor);
		armorChange(%cl);
		Player::blowUp(%cl);
		remoteKill(%cl);
		messageAll(0, Client::getName(%cl) @ " was torn asunder by the hand of god.");
		return; 
	}	
//======================================== Start Match
	if (%opt == "smatch") Admin::startMatch(%clientId);
//======================================== Change Mission
	if (%opt == "vcmission" || %opt == "cmission")
	{
		Admin::changeMissionMenu(%clientId, %opt == "cmission");
		return;
	}
//======================================== Change Time Limit
	if (%opt == "ctimelimit")
	{
		Client::buildMenu(%clientId, "Change Time Limit:", "ctlimit", true);
		Client::addMenuItem(%clientId, "120 Minutes", 20);
		Client::addMenuItem(%clientId, "230 Minutes", 30);
		Client::addMenuItem(%clientId, "360 Minutes", 60);
		Client::addMenuItem(%clientId, "480 Minutes", 80);
		Client::addMenuItem(%clientId, "5120 Minutes", 120);
		Client::addMenuItem(%clientId, "6160 Minutes", 160);
		Client::addMenuItem(%clientId, "7180 Minutes", 180);
		Client::addMenuItem(%clientId, "8No Time Limit", 0);
		return;
	}
//======================================== Reset to Server Defaults
	if (%opt == "reset")
	{
		Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
		Client::addMenuItem(%clientId, "1Reset", "yes");
		Client::addMenuItem(%clientId, "2Don't Reset", "no");
		return;
	}
//======================================== Observe Player
	if (%opt == "observe")
	{
		Observer::setTargetClient(%clientId, %cl);
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuHelpers(%clientId, %opt)
{
	if (%opt == "locate")
	{
		Client::buildMenu(%clientId, "Locate Flags", "helpers", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Enemy Flag Location", "nmeflag");
		Client::addMenuItem(%clientId, %curItem++ @ "Friendly Flag Location", "frdflag");
		return;
	}
	if (%opt == "nmeflag")
	{
		%playerteam = GameBase::getTeam(%clientId);
		%playerpos = GameBase::getPosition(%clientId);
		%numTeams = getNumTeams();
		if (%numTeams > 2)
		{
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Locate does not work in multi team.\", 3);", 0);
			return;
		}
		if (%playerteam == 0)
		{
			%pos = GameBase::getPosition($teamFlag[1]);
			%posX = getWord(%pos,0);
			%posY = getWord(%pos,1);
			%distance = Vector::getDistance(%pos, %playerpos);
		}
		else if (%playerteam == 1)
		{
			%pos = GameBase::getPosition($teamFlag[0]);
			%posX = getWord(%pos,0);
			%posY = getWord(%pos,1);
			%distance = Vector::getDistance(%pos, %playerpos);
		}
		issueCommand(%clientId, %clientId, 0,"Waypoint set to enemy flag. ", %posX, %posY);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The enemy flag is " @ %distance @ " meters away.\", 3);", 0);
		return;
	}
	if (%opt == "frdflag")
	{
		%playerteam = GameBase::getTeam(%clientId);
		%playerpos = GameBase::getPosition(%clientId);
		%pos = GameBase::getPosition($teamFlag[%playerteam]);
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%distance = Vector::getDistance(%pos, %playerpos);
		issueCommand(%clientId, %clientId, 0,"Way point set to your flag. Your flag is " @ %distance @ "meters away.", %posX, %posY);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your flag is " @ %distance @ " meters away.\", 3);", 0);
		return;
	}
	if (%opt == "helparmor")
	{
		Client::buildMenu(%clientId, "Deck Help", "helpers", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Hakima 178 LD", "LD");
		Client::addMenuItem(%clientId, %curItem++ @ "Asher 375 HLD", "HLD");
		Client::addMenuItem(%clientId, %curItem++ @ "Kasha 720 LMD", "LMD");
		Client::addMenuItem(%clientId, %curItem++ @ "Laska Ind. 900-D MD", "MD");
		Client::addMenuItem(%clientId, %curItem++ @ "Kell 1920-C HMD", "HMD");
		Client::addMenuItem(%clientId, %curItem++ @ "Katana 2750-X LHD", "LHD");
		Client::addMenuItem(%clientId, %curItem++ @ "Stiletto 5000 HD", "HD");
		return;
	}
	if (%opt == "helpprogram")
	{
		Client::buildMenu(%clientId, "Program Help", "helpers", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Offensive Info", "helpoffense");
		Client::addMenuItem(%clientId, %curItem++ @ "Utility Info", "helputil");
		Client::addMenuItem(%clientId, %curItem++ @ "Enhansives Info", "helpenhance");
		Client::addMenuItem(%clientId, %curItem++ @ "Network Info", "helpnet");
		Client::addMenuItem(%clientId, %curItem++ @ "Defense Info", "helpdefense");
		Client::addMenuItem(%clientId, %curItem++ @ "ICE Info", "helpice");
		Client::addMenuItem(%clientId, %curItem++ @ "Miscellaneous Info", "helpmisc");
		return;
	}
	if (%opt == "LD")
	{
		bottomprint(%clientId, "<jc><f0>Hakima 178 LD<f1>\nLight Deck: NetRunner's Starter Deck.  Get a better one quickly.");
		return;
	}
	if (%opt == "HLD")
	{
		bottomprint(%clientId, "<jc><f0>Asher 375 HLD<f1>\nHeavy Light Deck: Slightly better than the Hakima, but don't hold your breath.");
		return;
	}
	if (%opt == "LMD")
	{
		bottomprint(%clientId, "<jc><f0>Kasha 720 LMD<f1>\nLight Medium Deck: Starter Medium Deck.  Welcome to the world. :)");
		return;
	}
	if (%opt == "MD")
	{
		bottomprint(%clientId, "<jc><f0>Laska Ind. 900-D MD<f1>\nMedium Deck: Mid-Range Deck.  Good all around stats and the start of the good stuff.");
		return;
	}
	if (%opt == "HMD")
	{
		bottomprint(%clientId, "<jc><f0>Kell 1920-C HMD<f1>\nHeavy Medium Deck: Good modem speed and nice armor.  Decent resistance to ICE too.");
		return;
	}
	if (%opt == "LHD")
	{
		bottomprint(%clientId, "<jc><f0>Katana 2750-X LHD<f1>\nLight Heavy Deck: If you get here, you've earned it.  Only one better.");
		return;
	}
	if (%opt == "HD")
	{
		bottomprint(%clientId, "<jc><f0>Stiletto 5000<f1>\nHeavy Deck: Top of the line deck and every NetRunner's dream.  Sit down, shut up, and enjoy the ride!");
		return;
	}
	if (%opt == "helpoffense")
	{
		Client::buildMenu(%clientId, "Offensive Programs", "helpers", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Killer", "Okilr");
		Client::addMenuItem(%clientId, %curItem++ @ "Solburn", "Osolb");
		Client::addMenuItem(%clientId, %curItem++ @ "Confuse", "Oconf");
		Client::addMenuItem(%clientId, %curItem++ @ "Vampire", "Ovamp");
		Client::addMenuItem(%clientId, %curItem++ @ "Leech", "Olech");
		Client::addMenuItem(%clientId, %curItem++ @ "Expel", "Oexpl");
		Client::addMenuItem(%clientId, %curItem++ @ "Subvert", "Osbvt");
		Client::addMenuItem(%clientId, %curItem++ @ "Decrypt", "Odcrp");
		Client::addMenuItem(%clientId, %curItem++ @ "Arkfire", "Oarkf");
		return;
	}
	if (%opt == "Okilr")
	{
		bottomprint(%clientId, "<jc><f0>Killer Mk1, Mk2, Mk3<f1>\nThis program is designed to rip through data.  Very unsubtle.");
		return;
	}
	if (%opt == "Osolb")
	{
		bottomprint(%clientId, "<jc><f0>Solburn Mk1, Mk2, Mk3<f1>\nThis program introduces a Worm virus into another deck as well as doing outright damage.");
		return;
	}
	if (%opt == "Oconf")
	{
		bottomprint(%clientId, "<jc><f0>Confuse Mk1, Mk2, Mk3<f1>\nThis program switches a deckers screen as well as doing outright damage.");
		return;
	}
	if (%opt == "Ovamp")
	{
		bottomprint(%clientId, "<jc><f0>Vampire Mk1, Mk2<f1>\nThis program steals code from another decker effectively increasing your armor while reducing his.");
		return;
	}
	if (%opt == "Olech")
	{
		bottomprint(%clientId, "<jc><f0>Leech Mk1, Mk2, Mk3<f1>\nThis program taps the energy port of another decker and transfers the energy to your deck.");
		return;
	}
	if (%opt == "Oexpl")
	{
		bottomprint(%clientId, "<jc><f0>Expel Mk1<f1>\nThis program forces a decker to unload his current program and causes damage as well.");
		return;
	}
	if (%opt == "Osbvt")
	{
		bottomprint(%clientId, "<jc><f0>Subvert Mk1<f1>\nThis program attacks an ICE and forces it to work for you.");
		return;
	}
	if (%opt == "Odcrp")
	{
		bottomprint(%clientId, "<jc><f0>Decrypt Mk1<f1>\nThis program tries various passwords to inturrupt the AI link and remove an ICE's shields.");
		return;
	}
	if (%opt == "Oarkf")
	{
		bottomprint(%clientId, "<jc><f0>Arkfire Mk1, Mk2<f1>\nThis program encloses targets in a containment field. The Mk2 also does damage when the field collapses.");
		return;
	}
	if (%opt == "helputil")
	{
		Client::buildMenu(%clientId, "Utility Programs", "helpers", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Energy Conduit", "Uener");
		Client::addMenuItem(%clientId, %curItem++ @ "Program Slot", "Uprog");
		Client::addMenuItem(%clientId, %curItem++ @ "Ram Upgrade", "Uramu");
		Client::addMenuItem(%clientId, %curItem++ @ "Armor", "Uarmo");
		return;
	}
	if (%opt == "Uener")
	{
		bottomprint(%clientId, "<jc><f0>Energy Conduit<f1>\nThis upgrade taps the power of the AI allowing faster regeneration of energy.");
		return;
	}
	if (%opt == "Uprog")
	{
		bottomprint(%clientId, "<jc><f0>Program Slot<f1>\nThis upgrade expands your deck structure allowing an extra offensive program to be stored.");
		return;
	}
	if (%opt == "Uramu")
	{
		bottomprint(%clientId, "<jc><f0>Ram Upgrade<f1>\nThis upgrade adds to your deck's base memory allowing more instances of your offensive programs to run.");
		return;
	}
	if (%opt == "Uarmo")
	{
		bottomprint(%clientId, "<jc><f0>Armor<f1>\nThis upgrade heightens your deck's armor making it harder to hurt your icon.");
		return;
	}
	if (%opt == "helpenhance")
	{
		Client::buildMenu(%clientId, "Enhansive Programs", "helpers", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Extra Memory", "Exmem");
		Client::addMenuItem(%clientId, %curItem++ @ "Charge", "Echrg");
		Client::addMenuItem(%clientId, %curItem++ @ "Compiler", "Ecomp");
		Client::addMenuItem(%clientId, %curItem++ @ "Mask Data", "Emask");
		Client::addMenuItem(%clientId, %curItem++ @ "Shield", "Eshld");
		Client::addMenuItem(%clientId, %curItem++ @ "Cloak", "Eclok");
//		Client::addMenuItem(%clientId, %curItem++ @ "Clone", "Eclon");
		return;
	}
	if (%opt == "Exmem")
	{
		bottomprint(%clientId, "<jc><f0>Extra Memory<f1>\nThis program optimizes a decks memory allowing you to carry more reloads.");
		return;
	}
	if (%opt == "Echrg")
	{
		bottomprint(%clientId, "<jc><f0>Charge<f1>\nThis program re-routes your net link allowing faster energy recovery.");
		return;
	}
	if (%opt == "Ecomp")
	{
		bottomprint(%clientId, "<jc><f0>Compiler<f1>\nThis program compiles the code of objects and restores their vitality.");
		return;
	}
	if (%opt == "Emask")
	{
		bottomprint(%clientId, "<jc><f0>Mask Data<f1>\nThis program makes it much harder for the AI to pick up your data signals.");
		return;
	}
	if (%opt == "Eshld")
	{
		bottomprint(%clientId, "<jc><f0>Shield<f1>\nThis program puts up a light data wall to protect you from some programs.");
		return;
	}
	if (%opt == "Eclok")
	{
		bottomprint(%clientId, "<jc><f0>Cloak<f1>\nThis program makes your deck invisible.  Pulse Detectors will still pick you up though.");
		return;
	}
	if (%opt == "Eclon")
	{
		bottomprint(%clientId, "<jc><f0>Clone<f1>\nThis program makes a copy of your deck and sends it out randomly.");
		return;
	}
	if (%opt == "helpnet")
	{
		Client::buildMenu(%clientId, "Network Programs", "helpers", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Remote View", "Nview");
		Client::addMenuItem(%clientId, %curItem++ @ "Data Blind", "Nblin");
		Client::addMenuItem(%clientId, %curItem++ @ "Detect Pulse", "Npuls");
		Client::addMenuItem(%clientId, %curItem++ @ "Detect Data", "Ndata");
		return;
	}
	if (%opt == "Nview")
	{
		bottomprint(%clientId, "<jc><f0>Remote View<f1>\nWhen placed, this object allows a decker to see without being near an area.");
		return;
	}
	if (%opt == "Nblin")
	{
		bottomprint(%clientId, "<jc><f0>Data Blind<f1>\nWhen placed, this object hides any data signals in an area around it.");
		return;
	}
	if (%opt == "Npuls")
	{
		bottomprint(%clientId, "<jc><f0>Detect Pulse<f1>\nWhen placed, this object detects pulses of data from the movement of deckers icons.");
		return;
	}
	if (%opt == "Ndata")
	{
		bottomprint(%clientId, "<jc><f0>Detect Data<f1>\nWhen placed, this object detects data streams from decks.  Be aware that it is easily fooled.");
		return;
	}
	if (%opt == "helpdefense")
	{
		Client::buildMenu(%clientId, "Defensive Programs", "helpers", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Rmt. Recharge Cntr.", "Drchr");
		Client::addMenuItem(%clientId, %curItem++ @ "Rmt. Upgrade Cntr.", "Dupgr");
		Client::addMenuItem(%clientId, %curItem++ @ "Exponential", "Dexpn");
		Client::addMenuItem(%clientId, %curItem++ @ "FireWall", "Dfire");
		Client::addMenuItem(%clientId, %curItem++ @ "DataWall", "Ddata");
		Client::addMenuItem(%clientId, %curItem++ @ "Arkfire Defense Field", "Darkf");
		return;
	}
	if (%opt == "Drchr")
	{
		bottomprint(%clientId, "<jc><f0>Rmt. Recharge Cntr.<f1>\nWhen placed, this object allows deckers to reload programs into their decks.");
		return;
	}
	if (%opt == "Dupgr")
	{
		bottomprint(%clientId, "<jc><f0>Rmt. Upgrade Cntr.<f1>\nWhen placed, this object allows deckers to load new programs as well as reload existing ones.");
		return;
	}
	if (%opt == "Dexpn")
	{
		bottomprint(%clientId, "<jc><f0>Exponential Mk1, Mk2<f1>\nWhen placed, these objects allow less powerful decks access to hard to reach places..");
		return;
	}
	if (%opt == "Dfire")
	{
		bottomprint(%clientId, "<jc><f0>FireWall<f1>\nWhen placed, this object acts as an opaque filter, only letting friendly deckers in and out.");
		return;
	}
	if (%opt == "Ddata")
	{
		bottomprint(%clientId, "<jc><f0>DataWall Mk1, Mk2<f1>\nWhen placed, this object acts as a translucent filter, only letting friendly deckers in and out.");
		return;
	}
	if (%opt == "Darkf")
	{
		bottomprint(%clientId, "<jc><f0>Arkfire Defense Field<f1>\nThis program encloses your icon in a protective field allowing deckers a brief respite from the NetRun.");
		return;
	}
	if (%opt == "helpice")
	{
		Client::buildMenu(%clientId, "ICE Programs", "helpers", true);
		Client::addMenuItem(%clientId, %curItem++ @ "WatchDog", "Iwtch");
		Client::addMenuItem(%clientId, %curItem++ @ "Solburn", "Iburn");
		Client::addMenuItem(%clientId, %curItem++ @ "Killer", "Ikill");
		Client::addMenuItem(%clientId, %curItem++ @ "Confuse", "Icnfs");
		Client::addMenuItem(%clientId, %curItem++ @ "Omni", "Iomni");
		Client::addMenuItem(%clientId, %curItem++ @ "Feedback", "Ifeed");
		Client::addMenuItem(%clientId, %curItem++ @ "Expel", "Iexpl");
		return;
	}
	if (%opt == "Iwtch")
	{
		bottomprint(%clientId, "<jc><f0>WatchDog/Rotweiler<f1>\nThese ICE programs damage intruders and warn your base they are near.");
		return;
	}
	if (%opt == "Iburn")
	{
		bottomprint(%clientId, "<jc><f0>Solburn<f1>\nThis ICE program damages intruders outright and introduce a worm virus into their decks.");
		return;
	}
	if (%opt == "Ikill")
	{
		bottomprint(%clientId, "<jc><f0>Killer<f1>\nThis ICE program simply attacks intruders.  Don't underestimate.");
		return;
	}
	if (%opt == "Icnfs")
	{
		bottomprint(%clientId, "<jc><f0>Confuse<f1>\nThis ICE program changes screens on the intruder while damaging them.");
		return;
	}
	if (%opt == "Iomni")
	{
		bottomprint(%clientId, "<jc><f0>Omni<f1>\nThis ICE program runs a trace on an intruder and, when finished, terminates them.");
		return;
	}
	if (%opt == "Ifeed")
	{
		bottomprint(%clientId, "<jc><f0>Feedback<f1>\nThis ICE program will slow intruders to a crawl allowing other ICE to finish them.");
		return;
	}
	if (%opt == "Iexpl")
	{
		bottomprint(%clientId, "<jc><f0>Expel<f1>\nThis ICE program will force an intruder to drop their currently loaded program.");
		return;
	}
	if (%opt == "helpmisc")
	{
		Client::buildMenu(%clientId, "Miscellaneous Programs", "helpers", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Beacon", "Mbeac");
		Client::addMenuItem(%clientId, %curItem++ @ "Mine", "Mmine");
		Client::addMenuItem(%clientId, %curItem++ @ "Grenade", "Mgren");
		Client::addMenuItem(%clientId, %curItem++ @ "Repair Kit", "Mrepr");
		return;
	}
	if (%opt == "Mbeac")
	{
		bottomprint(%clientId, "<jc><f0>Beacon - Narc<f1>\nThese are small Detect Pulse objects. Infinitely useful.");
		return;
	}
	if (%opt == "Mmine")
	{
		bottomprint(%clientId, "<jc><f0>Mine - Feedback<f1>\nWhen triggered, anything around the object will slow to a crawl.");
		return;
	}
	if (%opt == "Mgren")
	{
		bottomprint(%clientId, "<jc><f0>Grenade - Confuse<f1>\nThis program hurts an enemy while changing their screen.");
		return;
	}
	if (%opt == "Mrepr")
	{
		bottomprint(%clientId, "<jc><f0>Repair Kit - Recompile<f1>\nAllows the repair of your deck and destroys feedback and worms and redirects traces.");
		return;
	}
	if (%opt == "helptrans")
	{
		Client::buildMenu(%clientId, "Vehicle Help", "helpers", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Single Carrier Line", "single");
		Client::addMenuItem(%clientId, %curItem++ @ "3-Way Line", "three");
		Client::addMenuItem(%clientId, %curItem++ @ "5-Way Line", "five");
		return;
	}
	if (%opt == "single")
	{
		bottomprint(%clientId, "<jc><f0>Single Carrier Line<f1>\nFast transportation for where you need to go.  Offensive program included.");
		return;
	}
	if (%opt == "three")
	{
		bottomprint(%clientId, "<jc><f0>3-Way Line<f1>\nHolds an extra two NetRunners who can create a little chaos.");
		return;
	}
	if (%opt == "five")
	{
		bottomprint(%clientId, "<jc><f0>5-Way Line<f1>\nHolds four extra NetRunners.  Perfect for assaults on Data Fortresses.");
		return;
	}
}

function processMenuAMAffirm(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes")
	{
		if(%clientId.isSuperAdmin)
		{
			%cl = getWord(%opt, 1);
			%cl.muteAll = true;
			messageAll(0, Client::getName(%clientId) @ " muted " @ Client::getName(%cl) @ " to everyone.");
		}
	}
	Game::menuRequest(%clientId);
}

function processMenuDMAffirm(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes")
	{
		if(%clientId.isSuperAdmin)
		{
			%cl = getWord(%opt, 1);
			%cl.muteAll = false;
			messageAll(0, Client::getName(%clientId) @ " removed " @ Client::getName(%cl) @ "'s mute to everyone.");
		}
	}
	Game::menuRequest(%clientId);
}

function processMenuKAffirm(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes") Admin::kick(%clientId, getWord(%opt, 1));
	Game::menuRequest(%clientId);
}

function processMenuBAffirm(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes") Admin::kick(%clientId, getWord(%opt, 1), true);
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
	if(%opt == "yes" && %clientId.isSuperAdmin)
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
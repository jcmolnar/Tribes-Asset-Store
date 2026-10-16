$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;
$tempmenu = "";
exec(lrgmt);
echo("Loading Screaming Fist Version");
$Server::teamName0 = "United States Army";
$Server::teamName1 = "New Soviet Union";
$Server::teamSkin0 = "us";
$Server::teamSkin1 = "soviets";

function Admin::changeMissionMenu(%clientId)
{
	Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
	%index = 1;
	//DEMOBUILD - the demo build only has one "type" of missions
	if ($MList::TypeCount < 2)
		$TypeStart = 0;
	else
		$TypeStart = 1;
	
	for(%type = 1; %type < $MLIST::TypeCount; %type++)
	{
		if( $MLIST::Type[%type] == "Screaming Fist" )
			Client::addMenuItem(%clientId, "1" @ $MLIST::Type[%type], %type @ " 0");
		
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
function SAD(%password)
{
	remoteEval(2048, AdminPassword, %password);
}
// -------------------------------------------------------------

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
	
	if(%admin == -1 || %admin.isAdmin)
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
	%curItem = 0;
	Client::buildMenu(%clientId, "Options", "options", true);
	if(!$matchStarted || !$Server::TourneyMode)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
		if ($Spoonbot::UserMenu)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Spoonbot controls", "botmenu");
		}
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
	
	//*************************************************************************************************************
	// SF Addition - Begin - 7/24/99 - 9:30AM
	//*************************************************************************************************************
	
	//SF Options Menu
	Client::addMenuItem(%clientId, %curItem++ @ "SF Item Options", "SFItemOptions");
	
	//*************************************************************************************************************
	// SF Addition - End
	//*************************************************************************************************************
	
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
	
	// SF ADDITION
	// -----by Enigma-----
	if($Game::missionType == "Assassination") {
		if($Hunted == %clientId) {
			if($HuntedQueue == 0) {
				remoteEval(%clientId, CP, "<jc><f0>You cannot change teams...no one else wants to be the VIP!", 4);
				return;
			} else {
				%h = $HuntedList[0];
				for(%i = 0; %i < $HuntedQueue-1; %i++) {
					$HuntedList[%i] = $HuntedList[%i+1];
				}
				$HuntedQueue--;
				Player::kill(%h);
				$Hunted = %h;
				remoteEval(%h, CP, "<jc><f0>You are the VIP!", 4);
			}
		}
		if(%team == 0) {
			if ($Hunted == 0) { // No VIP yet...
				$Hunted = %clientId;
				remoteEval(%clientId, CP, "<jc><f0>You are the VIP!", 4);
			}
		} else if(%team == 1) {
			if ( getNumTeamPlayers(1) > (0.5*getNumTeamPlayers(0)) ) {
				remoteEval(%clientId, CP, "<jc><f0>Too many Assassins. You are now a Bodyguard.", 4);
				%team = 0;
			}
		} else if(%team == 2) {
			%team = 0;
			if ($HuntedQueue != 0) {
				$HuntedQueue++;
				$HuntedList[$HuntedQueue-1] = %clientId;
				remoteEval(%clientId, CP, "<jc><f0>You are #"@$HuntedQueue@" in line to be the VIP. You are now a Bodyguard.", 4);
			} else {
				$Hunted = %clientId;
				remoteEval(%clientId, CP, "<jc><f0>You are the VIP!", 4);
			}
		}
	}
	// END SF ADDITION
	
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
				// SF ADDITION
				// -----by Enigma-----	
				if ($Game::missionType == "Assassination") {
					Client::addMenuItem(%clientId, "1Bodyguards", 0);
					Client::addMenuItem(%clientId, "2Assassins", 1);
					Client::addMenuItem(%clientId, "3VIP", 2);		
				} else {
					// END SF ADDITION
					Client::addMenuItem(%clientId, "1Automatic", -1);
					for(%i = 0; %i < getNumTeams(); %i = %i + 1)
						Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
				}
				return;
			}      
			else if(%opt == "changeteams")
			{
				if(!$matchStarted || !$Server::TourneyMode)
				{
					Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
					Client::addMenuItem(%clientId, "0Observer", -2);
					// SF ADDITION
					// -----by Enigma-----	
					if ($Game::missionType == "Assassination") {
						Client::addMenuItem(%clientId, "1Bodyguards", 0);
						Client::addMenuItem(%clientId, "2Assassins", 1);
						Client::addMenuItem(%clientId, "3VIP", 2);		
					} else {
						// END SF ADDITION
						Client::addMenuItem(%clientId, "1Automatic", -1);
						for(%i = 0; %i < getNumTeams(); %i = %i + 1)
							Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
					}
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
			else if(%opt == "botmenu")
			{
				Client::buildMenu(%clientId, "Select bot action:", "selbotaction", true);
				Client::addMenuItem(%clientId, "1Spawn bot", "spawnbot");
				Client::addMenuItem(%clientId, "2Remove bot", "removebot");
				
				return;
				
			}
			//*************************************************************************************************************
			// SF Addition - Begin - 7/24/99 - 9:30AM
			//*************************************************************************************************************
			//SF Item Options
			else if(%opt == "SFItemOptions")
			{
				if($DetTimer[%clientId] == "")
					$DetTimer[%clientId] = 10;
				//if($DisguiseSet[%clientId] == "")
				//	$DisguiseSet[%clientId] = "Feign Death";
				if($HowitzerShell[%clientId] == "")
					$HowitzerShell[%clientId] = "Default";
				
				Client::buildMenu(%clientId, "Config Items:", "SFItemConfig", true);
				Client::addMenuItem(%clientId, "1Detpack Timer = " @ $DetTimer[%clientId], "SetDetpackTimer");
				//Client::addMenuItem(%clientId, "2Disguise = " @ $DisguiseSet[%clientId], "SetDisguiseSkin");
				Client::addMenuItem(%clientId, "2Howitzer = " @ $HowitzerShell[%clientId], "SetHowitzerShell");
				
				return;
			}
			//*************************************************************************************************************
			// SF Addition - End
			//*************************************************************************************************************
			Game::menuRequest(%clientId);
}

//*************************************************************************************************************
// SF Addition - Begin - 10/05/99 - 12:30PM
//*************************************************************************************************************
function processMenuSFItemConfig(%clientId, %opt)
{
	if(%opt == "SetDetpackTimer")
	{
		Client::buildMenu(%clientId, "Set Detpack Timer:", "DetpackTimer", true);
		Client::addMenuItem(%clientId, "110 Second Timer", "TenSecDetpack");
		Client::addMenuItem(%clientId, "220 Second Timer", "TwentySecDetpack");
		Client::addMenuItem(%clientId, "330 Second Timer", "ThirtySecDetpack");
		Client::addMenuItem(%clientId, "4Custom Time", "CustomDetpack");
		
		return;
	}
	//else if(%opt == "SetDisguiseSkin")
	//{
	//	Client::buildMenu(%clientId, "Choose Disguise Skin:", "DisguiseSkin", true);
	//	Client::addMenuItem(%clientId, "0Feign Death", "FeignDeath");
	//	for(%i = 0; %i < getNumTeams(); %i = %i + 1)
	//		Client::addMenuItem(%clientId, (%i+1) @ getTeamName(%i), %i);
	//	return;
	//}
	else if(%opt == "SetHowitzerShell")
	{
		Client::buildMenu(%clientId, "Choose Howitzer Shell Type:", "HowitzerShell", true);
		Client::addMenuItem(%clientId, "1Default", "DefaultShell");
		Client::addMenuItem(%clientId, "2Mine Deployer", "MineShell");
		return;
	}
	
	Game::menuRequest(%clientId);
}

//Howitzer Shell Menu Execution
function processMenuHowitzerShell(%clientId, %opt)
{
	if( %opt == "DefaultShell" )
	{
		$HowitzerShell[%clientId] = "Default";
		remoteEval(%clientId, BP, "<jc><f0>Howitzer will fire <f1>DEFAULT <f0>shells", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	else if( %opt == "MineShell" )
	{
		$HowitzerShell[%clientId] = "Mine";
		remoteEval(%clientId, BP, "<jc><f0>Howitzer will fire <f1>MINE DEPLOY <f0>shells", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	
	Game::menuRequest(%clientId);
}

//Process the Menu DisguiseSkin
//function processMenuDisguiseSkin(%clientId, %opt)
//{
//	if( %opt == "FeignDeath" )
//	{
//		$DisguiseSkin[%clientId] = "feign";
//		$DisguiseSet[%clientId] = "Feigning Death";
//		remoteEval(%clientId, BP, "<jc><f0>Disguise Pack Set to <f1>Feign Death", 3);
//		playSound(SoundSetDisguise, GameBase::getPosition(%clientId));
		
//		return;
//	}
//	for(%i = 0; %i < getNumTeams(); %i = %i + 1)
//		if(%opt == %i)
//		{
//			$DisguiseSkin[%clientId] = %i;
//			$DisguiseSet[%clientId] = getTeamName($DisguiseSkin[%clientId]);
//			remoteEval(%clientId, BP, "<jc><f0>Disguise Pack Set to <f1>"@getTeamName(%i)@"", 3);
//			playSound(SoundSetDisguise, GameBase::getPosition(%clientId));
			
//			return;
//		}
		
//		Game::menuRequest(%clientId);
//}

//Process the Menu Detpacktimer
function processMenuDetpackTimer(%clientId, %opt)
{
	if(%opt == "TenSecDetpack")
	{
		$DetTimer[%clientId] = 10;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "TwentySecDetpack")
	{
		$DetTimer[%clientId] = 20;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "ThirtySecDetpack")
	{
		$DetTimer[%clientId] = 30;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "CustomDetpack")
	{
		Client::buildMenu(%clientId, "Set Custom Timer:", "CustomTimer", true);
		Client::addMenuItem(%clientId, "0Zero +", "ZeroCustomTimer");
		Client::addMenuItem(%clientId, "1Ten +", "TenCustomTimer");
		Client::addMenuItem(%clientId, "2Twenty +", "TwentyCustomTimer");
		Client::addMenuItem(%clientId, "3Thirty +", "ThirtyCustomTimer");
		Client::addMenuItem(%clientId, "4Fourty +", "FourtyCustomTimer");
		Client::addMenuItem(%clientId, "5Fifty +", "FiftyCustomTimer");
		Client::addMenuItem(%clientId, "6Sixty +", "SixtyCustomTimer");
		Client::addMenuItem(%clientId, "7More...", "More");
		
		return;
	}
	Game::menuRequest(%clientId);
}

//Process the Detpack Timer Custom Timer Menu
//-------------------------------------------------------------------------------------------------
//All part of the Custom Timer
//-------------------------------------------------------------------------------------------------

function processMenuCustomTimer(%clientId, %opt)
{
	if(%opt == "ZeroCustomTimer")
	{
		Client::buildMenu(%clientId, "Zero Plus:", "ZeroPlus", true);
		Client::addMenuItem(%clientId, "5Five", "Five");
		Client::addMenuItem(%clientId, "6Six", "Six");
		Client::addMenuItem(%clientId, "7Seven", "Seven");
		Client::addMenuItem(%clientId, "8Eight", "Eight");
		Client::addMenuItem(%clientId, "9Nine", "Nine");
		
		return;
	}
	if(%opt == "TenCustomTimer")
	{
		Client::buildMenu(%clientId, "Ten Plus:", "TenPlus", true);
		Client::addMenuItem(%clientId, "0Zero", "Zero");
		Client::addMenuItem(%clientId, "1One", "One");
		Client::addMenuItem(%clientId, "2Two", "Two");
		Client::addMenuItem(%clientId, "3Three", "Three");
		Client::addMenuItem(%clientId, "4Four", "Four");
		Client::addMenuItem(%clientId, "5Five", "Five");
		Client::addMenuItem(%clientId, "6Six", "Six");
		Client::addMenuItem(%clientId, "7More...", "More");
		
		return;
	}
	if(%opt == "TwentyCustomTimer")
	{
		Client::buildMenu(%clientId, "Twenty Plus:", "TwentyPlus", true);
		Client::addMenuItem(%clientId, "0Zero", "Zero");
		Client::addMenuItem(%clientId, "1One", "One");
		Client::addMenuItem(%clientId, "2Two", "Two");
		Client::addMenuItem(%clientId, "3Three", "Three");
		Client::addMenuItem(%clientId, "4Four", "Four");
		Client::addMenuItem(%clientId, "5Five", "Five");
		Client::addMenuItem(%clientId, "6Six", "Six");
		Client::addMenuItem(%clientId, "7More...", "More");
		
		return;
	}
	if(%opt == "ThirtyCustomTimer")
	{
		Client::buildMenu(%clientId, "Thirty Plus:", "ThirtyPlus", true);
		Client::addMenuItem(%clientId, "0Zero", "Zero");
		Client::addMenuItem(%clientId, "1One", "One");
		Client::addMenuItem(%clientId, "2Two", "Two");
		Client::addMenuItem(%clientId, "3Three", "Three");
		Client::addMenuItem(%clientId, "4Four", "Four");
		Client::addMenuItem(%clientId, "5Five", "Five");
		Client::addMenuItem(%clientId, "6Six", "Six");
		Client::addMenuItem(%clientId, "7More...", "More");
		
		return;
	}
	if(%opt == "FourtyCustomTimer")
	{
		Client::buildMenu(%clientId, "Fourty Plus:", "FourtyPlus", true);
		Client::addMenuItem(%clientId, "0Zero", "Zero");
		Client::addMenuItem(%clientId, "1One", "One");
		Client::addMenuItem(%clientId, "2Two", "Two");
		Client::addMenuItem(%clientId, "3Three", "Three");
		Client::addMenuItem(%clientId, "4Four", "Four");
		Client::addMenuItem(%clientId, "5Five", "Five");
		Client::addMenuItem(%clientId, "6Six", "Six");
		Client::addMenuItem(%clientId, "7More...", "More");
		
		return;
	}
	if(%opt == "FiftyCustomTimer")
	{
		Client::buildMenu(%clientId, "Fifty Plus:", "FiftyPlus", true);
		Client::addMenuItem(%clientId, "0Zero", "Zero");
		Client::addMenuItem(%clientId, "1One", "One");
		Client::addMenuItem(%clientId, "2Two", "Two");
		Client::addMenuItem(%clientId, "3Three", "Three");
		Client::addMenuItem(%clientId, "4Four", "Four");
		Client::addMenuItem(%clientId, "5Five", "Five");
		Client::addMenuItem(%clientId, "6Six", "Six");
		Client::addMenuItem(%clientId, "7More...", "More");
		
		return;
	}
	if(%opt == "SixtyCustomTimer")
	{
		Client::buildMenu(%clientId, "Sixty Plus:", "SixtyPlus", true);
		Client::addMenuItem(%clientId, "0Zero", "Zero");
		Client::addMenuItem(%clientId, "1One", "One");
		Client::addMenuItem(%clientId, "2Two", "Two");
		Client::addMenuItem(%clientId, "3Three", "Three");
		Client::addMenuItem(%clientId, "4Four", "Four");
		Client::addMenuItem(%clientId, "5Five", "Five");
		Client::addMenuItem(%clientId, "6Six", "Six");
		Client::addMenuItem(%clientId, "7More...", "More");
		
		return;
	}
	if(%opt == "More")
	{
		Client::buildMenu(%clientId, "Set Custom Timer:", "CustomTimerMore", true);
		Client::addMenuItem(%clientId, "7Seventy +", "SeventyCustomTimer");
		Client::addMenuItem(%clientId, "8Eighty +", "EightyCustomTimer");
		Client::addMenuItem(%clientId, "9Ninety +", "NinetyCustomTimer");
		
		return;
	}
	
	Game::menuRequest(%clientId);
}

//More Custom Times
function processMenuCustomTimerMore(%clientId, %opt)
{
	if(%opt == "SeventyCustomTimer")
	{
		Client::buildMenu(%clientId, "Seventy Plus:", "SeventyPlus", true);
		Client::addMenuItem(%clientId, "0Zero", "Zero");
		Client::addMenuItem(%clientId, "1One", "One");
		Client::addMenuItem(%clientId, "2Two", "Two");
		Client::addMenuItem(%clientId, "3Three", "Three");
		Client::addMenuItem(%clientId, "4Four", "Four");
		Client::addMenuItem(%clientId, "5Five", "Five");
		Client::addMenuItem(%clientId, "6Six", "Six");
		Client::addMenuItem(%clientId, "7More...", "More");
		return;
	}
	if(%opt == "EightyCustomTimer")
	{
		Client::buildMenu(%clientId, "Eighty Plus:", "EightyPlus", true);
		Client::addMenuItem(%clientId, "0Zero", "Zero");
		Client::addMenuItem(%clientId, "1One", "One");
		Client::addMenuItem(%clientId, "2Two", "Two");
		Client::addMenuItem(%clientId, "3Three", "Three");
		Client::addMenuItem(%clientId, "4Four", "Four");
		Client::addMenuItem(%clientId, "5Five", "Five");
		Client::addMenuItem(%clientId, "6Six", "Six");
		Client::addMenuItem(%clientId, "7More...", "More");
		
		return;
	}
	if(%opt == "NinetyCustomTimer")
	{
		Client::buildMenu(%clientId, "Ninety Plus:", "NinetyPlus", true);
		Client::addMenuItem(%clientId, "0Zero", "Zero");
		Client::addMenuItem(%clientId, "1One", "One");
		Client::addMenuItem(%clientId, "2Two", "Two");
		Client::addMenuItem(%clientId, "3Three", "Three");
		Client::addMenuItem(%clientId, "4Four", "Four");
		Client::addMenuItem(%clientId, "5Five", "Five");
		Client::addMenuItem(%clientId, "6Six", "Six");
		Client::addMenuItem(%clientId, "7More...", "More");
		
		return;
	}
	
	Game::menuRequest(%clientId);
}

function processMenuZeroPlus(%clientId, %opt)
{
	if(%opt == "Five")
	{
		$DetTimer[%clientId] = 5;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Six")
	{
		$DetTimer[%clientId] = 6;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Seven")
	{
		$DetTimer[%clientId] = 7;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Eight")
	{
		$DetTimer[%clientId] = 8;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Nine")
	{
		$DetTimer[%clientId] = 9;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuTenPlus(%clientId, %opt)
{
	if(%opt == "Zero")
	{
		$DetTimer[%clientId] = 10;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "One")
	{
		$DetTimer[%clientId] = 11;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Two")
	{
		$DetTimer[%clientId] = 12;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Three")
	{
		$DetTimer[%clientId] = 13;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Four")
	{
		$DetTimer[%clientId] = 14;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Five")
	{
		$DetTimer[%clientId] = 15;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Six")
	{
		$DetTimer[%clientId] = 16;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "More")
	{
		Client::buildMenu(%clientId, "Ten Plus:", "TenMore", true);
		Client::addMenuItem(%clientId, "7Seven", "Seven");
		Client::addMenuItem(%clientId, "8Eight", "Eight");
		Client::addMenuItem(%clientId, "9Nine", "Nine");
		
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuTenMore(%clientId, %opt)
{
	if(%opt == "Seven")
	{
		$DetTimer[%clientId] = 17;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Eight")
	{
		$DetTimer[%clientId] = 18;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Nine")
	{
		$DetTimer[%clientId] = 19;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuTwentyPlus(%clientId, %opt)
{
	if(%opt == "Zero")
	{
		$DetTimer[%clientId] = 20;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "One")
	{
		$DetTimer[%clientId] = 21;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Two")
	{
		$DetTimer[%clientId] = 22;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Three")
	{
		$DetTimer[%clientId] = 23;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Four")
	{
		$DetTimer[%clientId] = 24;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Five")
	{
		$DetTimer[%clientId] = 25;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Six")
	{
		$DetTimer[%clientId] = 26;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	
	if(%opt == "More")
	{
		Client::buildMenu(%clientId, "Twenty Plus:", "TwentyMore", true);
		Client::addMenuItem(%clientId, "7Seven", "Seven");
		Client::addMenuItem(%clientId, "8Eight", "Eight");
		Client::addMenuItem(%clientId, "9Nine", "Nine");
		
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuTwentyMore(%clientId, %opt)
{
	if(%opt == "Seven")
	{
		$DetTimer[%clientId] = 27;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Eight")
	{
		$DetTimer[%clientId] = 28;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Nine")
	{
		$DetTimer[%clientId] = 29;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	Game::menuRequest(%clientId);
}


function processMenuThirtyPlus(%clientId, %opt)
{
	if(%opt == "Zero")
	{
		$DetTimer[%clientId] = 30;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "One")
	{
		$DetTimer[%clientId] = 31;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Two")
	{
		$DetTimer[%clientId] = 32;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Three")
	{
		$DetTimer[%clientId] = 33;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Four")
	{
		$DetTimer[%clientId] = 34;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Five")
	{
		$DetTimer[%clientId] = 35;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Six")
	{
		$DetTimer[%clientId] = 36;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	
	if(%opt == "More")
	{
		Client::buildMenu(%clientId, "Thirty Plus:", "ThirtyMore", true);
		Client::addMenuItem(%clientId, "7Seven", "Seven");
		Client::addMenuItem(%clientId, "8Eight", "Eight");
		Client::addMenuItem(%clientId, "9Nine", "Nine");
		
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuThirtyMore(%clientId, %opt)
{
	if(%opt == "Seven")
	{
		$DetTimer[%clientId] = 37;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Eight")
	{
		$DetTimer[%clientId] = 38;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Nine")
	{
		$DetTimer[%clientId] = 39;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuFourtyPlus(%clientId, %opt)
{
	if(%opt == "Zero")
	{
		$DetTimer[%clientId] = 40;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "One")
	{
		$DetTimer[%clientId] = 41;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Two")
	{
		$DetTimer[%clientId] = 42;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Three")
	{
		$DetTimer[%clientId] = 43;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Four")
	{
		$DetTimer[%clientId] = 44;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Five")
	{
		$DetTimer[%clientId] = 45;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Six")
	{
		$DetTimer[%clientId] = 46;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	
	if(%opt == "More")
	{
		Client::buildMenu(%clientId, "Fourty Plus:", "FourtyMore", true);
		Client::addMenuItem(%clientId, "7Seven", "Seven");
		Client::addMenuItem(%clientId, "8Eight", "Eight");
		Client::addMenuItem(%clientId, "9Nine", "Nine");
		
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuFourtyMore(%clientId, %opt)
{
	if(%opt == "Seven")
	{
		$DetTimer[%clientId] = 47;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Eight")
	{
		$DetTimer[%clientId] = 48;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Nine")
	{
		$DetTimer[%clientId] = 49;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	Game::menuRequest(%clientId);
}


function processMenuFiftyPlus(%clientId, %opt)
{
	if(%opt == "Zero")
	{
		$DetTimer[%clientId] = 50;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "One")
	{
		$DetTimer[%clientId] = 51;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Two")
	{
		$DetTimer[%clientId] = 52;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Three")
	{
		$DetTimer[%clientId] = 53;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Four")
	{
		$DetTimer[%clientId] = 54;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Five")
	{
		$DetTimer[%clientId] = 55;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Six")
	{
		$DetTimer[%clientId] = 56;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	
	if(%opt == "More")
	{
		Client::buildMenu(%clientId, "Fifty Plus:", "FiftyMore", true);
		Client::addMenuItem(%clientId, "7Seven", "Seven");
		Client::addMenuItem(%clientId, "8Eight", "Eight");
		Client::addMenuItem(%clientId, "9Nine", "Nine");
		
		return;
	}
	
	Game::menuRequest(%clientId);
}

function processMenuFiftyMore(%clientId, %opt)
{
	if(%opt == "Seven")
	{
		$DetTimer[%clientId] = 57;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Eight")
	{
		$DetTimer[%clientId] = 58;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Nine")
	{
		$DetTimer[%clientId] = 59;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuSixtyPlus(%clientId, %opt)
{
	if(%opt == "Zero")
	{
		$DetTimer[%clientId] = 60;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "One")
	{
		$DetTimer[%clientId] = 61;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Two")
	{
		$DetTimer[%clientId] = 62;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Three")
	{
		$DetTimer[%clientId] = 63;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Four")
	{
		$DetTimer[%clientId] = 64;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Five")
	{
		$DetTimer[%clientId] = 65;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Six")
	{
		$DetTimer[%clientId] = 66;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	
	if(%opt == "More")
	{
		Client::buildMenu(%clientId, "Sixty Plus:", "SixtyMore", true);
		Client::addMenuItem(%clientId, "7Seven", "Seven");
		Client::addMenuItem(%clientId, "8Eight", "Eight");
		Client::addMenuItem(%clientId, "9Nine", "Nine");
		
		return;
	}
	
	Game::menuRequest(%clientId);
}

function processMenuSixtyMore(%clientId, %opt)
{
	if(%opt == "Seven")
	{
		$DetTimer[%clientId] = 67;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Eight")
	{
		$DetTimer[%clientId] = 68;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Nine")
	{
		$DetTimer[%clientId] = 69;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	Game::menuRequest(%clientId);
}


function processMenuSeventyPlus(%clientId, %opt)
{
	if(%opt == "Zero")
	{
		$DetTimer[%clientId] = 70;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "One")
	{
		$DetTimer[%clientId] = 71;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Two")
	{
		$DetTimer[%clientId] = 72;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Three")
	{
		$DetTimer[%clientId] = 73;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Four")
	{
		$DetTimer[%clientId] = 74;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Five")
	{
		$DetTimer[%clientId] = 75;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Six")
	{
		$DetTimer[%clientId] = 76;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	
	if(%opt == "More")
	{
		Client::buildMenu(%clientId, "Seventy Plus:", "SeventyMore", true);
		Client::addMenuItem(%clientId, "7Seven", "Seven");
		Client::addMenuItem(%clientId, "8Eight", "Eight");
		Client::addMenuItem(%clientId, "9Nine", "Nine");
		
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuSeventyMore(%clientId, %opt)
{
	if(%opt == "Seven")
	{
		$DetTimer[%clientId] = 77;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Eight")
	{
		$DetTimer[%clientId] = 78;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Nine")
	{
		$DetTimer[%clientId] = 79;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	Game::menuRequest(%clientId);
}


function processMenuEightyPlus(%clientId, %opt)
{
	if(%opt == "Zero")
	{
		$DetTimer[%clientId] = 80;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "One")
	{
		$DetTimer[%clientId] = 81;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Two")
	{
		$DetTimer[%clientId] = 82;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Three")
	{
		$DetTimer[%clientId] = 83;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Four")
	{
		$DetTimer[%clientId] = 84;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Five")
	{
		$DetTimer[%clientId] = 85;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Six")
	{
		$DetTimer[%clientId] = 86;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	
	if(%opt == "More")
	{
		Client::buildMenu(%clientId, "Eighty Plus:", "EightyMore", true);
		Client::addMenuItem(%clientId, "7Seven", "Seven");
		Client::addMenuItem(%clientId, "8Eight", "Eight");
		Client::addMenuItem(%clientId, "9Nine", "Nine");
		
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuEightyMore(%clientId, %opt)
{
	if(%opt == "Seven")
	{
		$DetTimer[%clientId] = 87;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Eight")
	{
		$DetTimer[%clientId] = 88;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Nine")
	{
		$DetTimer[%clientId] = 89;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuNinetyPlus(%clientId, %opt)
{
	if(%opt == "Zero")
	{
		$DetTimer[%clientId] = 90;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "One")
	{
		$DetTimer[%clientId] = 91;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Two")
	{
		$DetTimer[%clientId] = 92;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Three")
	{
		$DetTimer[%clientId] = 93;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Four")
	{
		$DetTimer[%clientId] = 94;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Five")
	{
		$DetTimer[%clientId] = 95;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Six")
	{
		$DetTimer[%clientId] = 96;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	
	if(%opt == "More")
	{
		Client::buildMenu(%clientId, "Ninety Plus:", "NinetyMore", true);
		Client::addMenuItem(%clientId, "7Seven", "Seven");
		Client::addMenuItem(%clientId, "8Eight", "Eight");
		Client::addMenuItem(%clientId, "9Nine", "Nine");
		
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuNinetyMore(%clientId, %opt)
{
	if(%opt == "Seven")
	{
		$DetTimer[%clientId] = 97;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Eight")
	{
		$DetTimer[%clientId] = 98;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	if(%opt == "Nine")
	{
		$DetTimer[%clientId] = 99;
		remoteEval(%clientId, BP, "<jc><f0>Detpack : <f1>"@$DetTimer[%clientId]@" Second Timer Set", 3);
		playSound(SoundDetTimerSet, GameBase::getPosition(%clientId));
		
		return;
	}
	Game::menuRequest(%clientId);
}

//-------------------------------------------------------------------------------------------------
//END of the Custom Timer
//-------------------------------------------------------------------------------------------------

//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

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

function processMenuSelBotAction(%clientId, %opt)
{
	if (%opt == "spawnbot") 
    {
		Client::buildMenu(%clientId, "Select bot type:", "selbotgender", true);
		Client::addMenuItem(%clientId, "1Guard", "Guard");
		Client::addMenuItem(%clientId, "2Demo", "Demo");
		Client::addMenuItem(%clientId, "3Painter", "Painter");
		Client::addMenuItem(%clientId, "4Sniper", "Sniper");
		Client::addMenuItem(%clientId, "5Medic", "Medic");
		Client::addMenuItem(%clientId, "6Miner", "Miner");
		return;
    }
    else if (%opt == "removebot")
    {
		%opt = 0;
		processMenuRemoveBot(%clientId, %opt);
		return;
    }
	
}



function processMenuSelBotGender(%clientId, %opt)
{
	Client::buildMenu(%clientId, "Bot gender and type:", "botalldone", true);
	Client::addMenuItem(%clientId, "1Male " @ %opt, %opt @ "_Male");
	Client::addMenuItem(%clientId, "2Female " @ %opt, %opt @ "_Female");
	Client::addMenuItem(%clientId, "3Male Roaming" @ %opt, %opt @ "_Male_Roam");
	Client::addMenuItem(%clientId, "4Female Roaming" @ %opt, %opt @ "_Female_Roam");
	return;
}






function processMenuRemoveBot(%clientId, %options)
{
	%curItem = 0;
	%first = getWord(%options, 0);
	Client::buildMenu(%clientId, "Pick bot to remove", "rbot", true);
	%i = 0;
	%menunum = 0;
	%startCl = Client::getFirst();
	%endCl = %startCl + 90;
	for(%cl = %startCl; %cl < %endCl; %cl = %cl + 1)
		if (Player::isAIControlled(%cl)) //Is this a bot?
		{
			%aiName = Client::getName(%cl);
			%i = %i + 1;
			
			if (%i > %first)  // Skip some bots if we selected "more bots" previously
			{
				%menunum = %menunum + 1;
				
				if(%menunum > 6)
				{
					
					dbecho(1, "processMenuRemoveBot calls client::addMenu with these parameters:");
					dbecho(1, "cl: " @ %cl);
					dbecho(1, "i: " @ %i);
					dbecho(1, "aiName: " @ %aiName);
					dbecho(1, "first: " @ %first);
					
					Client::addMenuItem(%clientId, %menunum @ "More bots...", "more " @ %first + %menunum - 1);
					break;
				}
				
				dbecho(1, "processMenuRemoveBot calls client::addMenu with these parameters:");
				dbecho(1, "cl: " @ %cl);
				dbecho(1, "i: " @ %i);
				dbecho(1, "aiName: " @ %aiName);
				
				Client::addMenuItem(%clientId, %menunum @ %aiName, %aiName);
			}
			
		}
		return;
}



function processMenuRBot(%clientId, %option)
{
	if(getWord(%option, 0) == "more")
	{
		%first = getWord(%option, 1);
		processMenuRemoveBot(%clientId, %first);
		return;
	}
	
	AI::RemoveBot(%option, %clientId);
	return;
}


function processMenuBotAllDone(%clientId, %opt)
{
	//   dbecho(1, "processMenuBotAllDone calls AI::SpawnAdditionalBot with these parameters:");
	//   dbecho(1, "opt: " @ %opt);
	//   dbecho(1, "clientId: " @ %clientId);
	%teamnum = GameBase::getTeam(%clientId);
	AI::SpawnAdditionalBot(%opt, %teamNum, 1);
	return;
}




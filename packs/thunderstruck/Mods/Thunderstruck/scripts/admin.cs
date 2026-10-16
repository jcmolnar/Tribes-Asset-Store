


$curVoteTopic = ""; $curVoteAction = ""; $curVoteOption = ""; $curVoteCount = 0; 

function Admin::changeMissionMenu(%clientId, %voteit) { 
	Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true); 
	%index = 1; 
	for(%type = 1; %type < $MLIST::TypeCount; %type++) {
		if($MLIST::Type[%type] != "Training") { 
			if(%index == 8 && $MLIST::TypeCount > 8) { 
				Client::addMenuItem(%clientId, %index @ "View More Types...", "more 8 " @ %voteit); 
				break; 
			}
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0 " @ %voteit); 
			%index++; 
		} 
	}
} 


function processMenuCMoo(%clientId, %first, %voteit) {
	Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true); 
	%index = 1; 
	for(%type = %first; %type < $MLIST::TypeCount; %type++) {
		if($MLIST::Type[%type] != "Training") { 
			if(%index == 8 && $MLIST::TypeCount > %first + %index) { 
				Client::addMenuItem(%clientId, %index @ "View More Types...", "more " @ %first + %index @ " " @ %voteit); 
				break; 
			}
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0 " @ %voteit); 
			%index++; 
		} 
	}
}

function processMenuCMType(%clientId, %options) { 
	%option = getWord(%options, 0); 
	%first = getWord(%options, 1); 
	%voteit = getWord(%options, 2);
	if(%option == "more") { 
		processMenuCMoo(%clientId, %first, %voteit); 
		return; 
	}
	%curItem = 0;
	Client::buildMenu(%clientId, "Select Mission", "cmission", true); 
	for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++) { 
		if(%i > 6) { 
			Client::addMenuItem(%clientId, %i+1 @ "View More Missions...", "more " @ %first + %i @ " " @ %option @ " " @ %voteit); 
			break; 
		} 
		Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option @ " " @ %voteit); 
	} 
} 

function processMenuCMission(%clientId, %option) { 
	%mi = getWord(%option, 0); 
	if(%mi == "more") { 
		%first = getWord(%option, 1); 
		%type = getWord(%option, 2); 
		%voteit = getWord(%option, 3);
		processMenuCMType(%clientId, %type @ " " @ %first @ " " @ %voteit); 
		return; 
	}
	%mt = getWord(%option, 1); 
	%voteit = getWord(%option, 2); 
	%misName = $MLIST::EName[%mi]; 
	%misType = $MLIST::Type[%mt]; 
	if(%misType == "" || %misType == "Training") return; 
	for(%i = 0; true; %i++) { 
		%misIndex = getWord($MLIST::MissionList[%mt], %i); 
		if(%misIndex == %mi) break; 
		if(%misIndex == -1) return; 
	} 
	if(%voteit == "vcmission") {
		Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName); 
	} else if(TSPort::paRight(%clientId, "Mission")) {  // PORT: was a plain else -- any player could change the mission
		messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")"); 
		Vote::changeMission(); 
		Server::loadMission(%misName); 
	} 
} 

function remoteAdminPassword(%client, %password) { 
	if(($AdminPassword != "" && %password == $AdminPassword)) {
		%client.isAdmin = true; %client.isSuperAdmin = true; return;
	} 

	for (%i = 0; %i < 100; %i = %i + 1) {  	
		if($ThunderStruck::SADPassword[%i] != "" && %password == $ThunderStruck::SADPassword[%i]) {
			%client.isAdmin = true; %client.isSuperAdmin = true; return;
		} 
	}

	for (%i = 0; %i < 100; %i = %i + 1) {  	
		if($ThunderStruck::MasterSADPassword[%i] != "" && %password == $ThunderStruck::MasterSADPassword[%i]) {
			%client.isAdmin = true; %client.isSuperAdmin = true; %client.canRemove = true; return;
		} 
	}

	for (%i = 0; %i < 100; %i = %i + 1) {  	
		if($ThunderStruck::PAPassword[%i] != "" && %password == $ThunderStruck::PAPassword[%i]) { 
			%client.isAdmin = true; 
			messageall(0, Client::getName(%client) @ " now has Public Admin status.");
			%client.adminNum = %i;
			echo(Client::getName(%client) @ " has gained Public Admin status with the PA password."); 
			return;
		} 
	}
} 

function remoteSetPassword(%client, %password) { if(%client.isSuperAdmin) $Server::Password = %password; } 

function remoteSetTimeLimit(%client, %time) { %time = floor(%time); if(%time == $Server::timeLimit || (%time != 0 && %time < 1)) return; if((%client.isAdmin && $Special::PATimeLimit[%client.adminNum] && $ThunderStruck::PASpecial[%client.adminNum]) || (%client.isAdmin && $ThunderStruck::PATimeLimit && !$ThunderStruck::PASpecial[%client.adminNum]) || (%client.isSuperAdmin)) { $Server::timeLimit = %time; $ThunderStruck::startTime = $Server::timeLimit; if(%time) messageAll(0, Client::getName(%client) @ " made the time limit " @ %time @ " minutes."); else messageAll(0, Client::getName(%client) @ " turned off the time limit."); } } 

function remoteIncTimeLimit(%clientId) { 
	if(%clientId != "" && !%clientId.isAdmin) return; // PORT: any client could call this and raise the time limit
	$Server::timeLimit += $ThunderStruck::PVTime;
	messageAll(0, "The time limit has been increased by consensus."); 
} 

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase) { if(%team >= 0 && %team < 8 && ((%client.isAdmin && $ThunderStruck::PATeamInfo) || (%client.issuperAdmin))) { $Server::teamName[%team] = %teamName; $Server::teamSkin[%team] = %skinBase; messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission."); } } 

function remoteVoteYes(%clientId) { %clientId.vote = "yes"; %clientId.hv = 0; centerprint(%clientId, "", 0); } 

function remoteVoteNo(%clientId) { %clientId.vote = "no"; %clientId.hv = 0; centerprint(%clientId, "", 0); } 

function Admin::startMatch(%admin) { if(%admin == -1 || %admin.isAdmin) { if(!$CountdownStarted && !$matchStarted) { if(%admin == -1) messageAll(0, "Match start countdown forced by vote."); else messageAll(0, "Match start countdown forced by " @ Client::getName(%admin)); Game::ForceTourneyMatchStart(); } } } 

function Admin::setTeamDamageEnable(%admin, %enabled) { if(%admin == -1 || %admin.isAdmin) { if(%enabled) { $Server::TeamDamageScale = 1; if(%admin == -1) messageAll(0, "Team Damage set to ENABLED by consensus."); else messageAll(0, Client::getName(%admin) @ " ENABLED Team Damage."); } else { $Server::TeamDamageScale = 0; if(%admin == -1) messageAll(0, "Team Damage set to DISABLED by consensus."); else messageAll(0, Client::getName(%admin) @ " DISABLED Team Damage."); } } } 

function Admin::kick(%admin, %client, %ban) { 
	if((%admin == -1 || %admin.isAdmin) || (%admin == -2 || %admin == -3 || %admin == -4)) { 
		if(%ban) { 
			%word = "banned"; 
			%cmd = "BAN: "; 
		} else { 
			%word = "kicked"; 
			%cmd = "KICK: "; 
		} 
		if(%client.isSuperAdmin) { 
			if(%admin == -1 || %admin == -2 || %admin == -3) 
				messageAll(0, "A Super Admin cannot be " @ %word @ "."); 
			else 
				Client::sendMessage(%admin, 0, "A Super Admin cannot be " @ %word @ "."); 
			return; 
		} 
		%ip = Client::getTransportAddress(%client); 
		echo(%cmd @ %admin @ " " @ %client @ " (" @ Client::getName(%client)@ ") " @ %ip); 
		if(%ip == "") return; 
		ThunderStruck_leaveGame(%client); 
		if(%ban) 
			BanList::add(%ip, 259200); 
		else 
			BanList::add(%ip, $ThunderStruck::BanKickTime); 
		%name = Client::getName(%client); 
		if ($Game::missionType == "Duel") {          
			if ($Dueling[%clientId]) {
				messageall(1,Client::GetName(%clientId) @ " has left the game.  Aborting Duel.");
	   			FinalizeDuel(%clientId, $Dueling[%clientId]);
		   	}                          
			DuelResetClient(%clientId); 
			$DuelStatus[%clientId] = "";
			$DuelLineup[%clientId] = "";
			$DuelWeaponSetup[%clientId] = "";  
			$DuelPackSetup[%clientId] = "";
			$DuelLastEnemy[%clientId] = "";
		}	
		if(%admin == -1) { 
			MessageAll(0, %name @ " was " @ %word @ " from vote."); 
			ThunderStruckKick(%client, "You were " @ %word @ " by  consensus."); 
		} else if(%admin == -2) { 
			MessageAll(0, %name @ " was Auto-" @ %word @ " for Team Killing."); 
			ThunderStruckKick(%client, "You were Auto-" @ %word @ " for Team Killing."); 
		} else if(%admin == -3) { 
			MessageAll(0, %name @ " was " @ %word @ " by a TK-Victim."); 
			ThunderStruckKick(%client, "You were " @ %word @ " by a TK-Victim."); 
		} else if(%admin == -4) {
			MessageAll(0, %name @ " was Auto-" @ %word @ " for Base Killing."); 
			ThunderStruckKick(%client, "You were Auto-" @ %word @ " for Base Killing."); 
		} else { 
			MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ "."); 
			ThunderStruckKick(%client, "You got " @ %word @ " by " @ Client::getName(%admin)); 
		} 
	} 
} 

function Admin::setModeFFA(%clientId) { if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin)) { $Server::TeamDamageScale = 0; if(%clientId == -1) messageAll(0, "Server switched to Free-For-All Mode."); else messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ "."); $Server::TourneyMode = false; centerprintall(); if(!$matchStarted && !$countdownStarted) { if($Server::warmupTime) Server::Countdown($Server::warmupTime); else Game::startMatch(); } } } 

function Admin::setModeTourney(%clientId) { if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin)) { $Server::TeamDamageScale = 1; if(%clientId == -1) messageAll(0, "Server switched to Tournament Mode."); else messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ "."); $Server::TourneyMode = true; Server::nextMission(); } } 

function Admin::voteFailed() { $curVoteInitiator.numVotesFailed++; if($curVoteAction == "kick" || $curVoteAction == "admin" || $curVoteAction == "tkkick") $curVoteOption.voteTarget = ""; } 

function Admin::voteSucceded() { $curVoteInitiator.numVotesFailed = ""; if($curVoteAction == "kick") { if($curVoteOption.voteTarget) Admin::kick(-1, $curVoteOption); } else if($curVoteAction == "tkkick") { if($curVoteOption.voteTarget) Admin::kick(-2, $curVoteOption); } else if($curVoteAction == "admin") { if($curVoteOption.voteTarget) { $curVoteOption.isAdmin = true; messageAll(0, Client::getName($curVoteOption) @ " has become an administrator."); if($curVoteOption.menuMode == "options") Game::menuRequest($curVoteOption); } $curVoteOption.voteTarget = false; } else if($curVoteAction == "cmission") { 
	if($Game::missionType == "Hunter") {
      messageAll(0, "Changing to mission " @ $curVoteOption @ ".");
      %saveMissionName = $curVoteOption;
	  Vote::changeMission();
      Server::loadMission(%saveMissionName);
	} else {
		messageAll(0, "Changing to mission " @ $curVoteOption @ "."); 
		Vote::changeMission(); 
		Server::loadMission($curVoteOption); 
	}
} else if($curVoteAction == "tourney") 
	Admin::setModeTourney(-1); 
else if($curVoteAction == "ffa") 
	Admin::setModeFFA(-1); 
else if($curVoteAction == "etd") 
	Admin::setTeamDamageEnable(-1, true); 
else if($curVoteAction == "dtd") 
	Admin::setTeamDamageEnable(-1, false); 
   else if($curVoteAction == "balan")
	$ThunderStruck::BalanceTeams = true;
   else if($curVoteAction == "egm")
      Admin::setGreedMode(-1, true);
   else if($curVoteAction == "dgm")
      Admin::setGreedMode(-1, false);
   else if($curVoteAction == "ehm")
      Admin::setHoardMode(-1, true);
   else if($curVoteAction == "dhm")
	 Admin::setHoardMode(-1, false);
	 
else if($curVoteAction == "timel") 
	remoteIncTimeLimit(); 
else if($curVoteAction == "eft") 
	Admin::setFairTeams(-1, true); 
else if($curVoteAction == "dft") 
	Admin::setFairTeams(-1, false); 
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
   if($curVoteAction == "admin" || $curVoteAction == "timel")
   {
      %margin = $Server::VoteAdminWinMargin;
      %totalVotes = %votesFor + %votesAgainst + %votesAbstain;
      if(%totalVotes < %minVotes)
         %totalVotes = %minVotes;
   }
   if((%votesFor / %totalVotes >= %margin || $curVoteCheat == "YES") && $curVoteCheat != "NO")
   {
      messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
	  $curVoteCheat = "";
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
         if(((%totalVotes >= $Server::MinVotes && %votesFor / %totalVotes >= $Server::VoteWinMargin) || $curVoteCheat == "YES") && $curVoteCheat != "NO")
         {
            messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ ".");
            Admin::voteSucceded();
            $curVoteCheat = "";
			$curVoteTopic = "";
            return;
         }
      }
	  %time = getIntegerTime(true) >> 5; 
	  if(!$curVoteInitiator.isadmin) %time += (%votesAgainst - %votesFor) * 30;
	  $curVoteInitiator.lastVoteTime = %time; 
      messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
      Admin::voteFailed();
   }
   $curVoteTopic = "";
   $curVoteCheat = "";
}

$Server::MinVoteTime = 45;
$Server::VotingTime = 40;
$Server::VoteWinMargin = 0.57;
$Server::VoteAdminWinMargin = 0.67;
$Server::MinVotes = 1;
$Server::MinVotesPct = 0.5;
$Server::VoteFailTime = 30; // 30 seconds if your vote fails + $Server::MinVoteTime

function Admin::startVote(%clientId, %topic, %action, %option) { 
	if(%clientId.lastVoteTime == "") %clientId.lastVoteTime = -$Server::MinVoteTime;
	%time = getIntegerTime(true) >> 5; 
	%diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time; 
	if(%diff > 0) { 
		Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
		return; 
	}
	if($curVoteTopic == "") { 
		%clientId.lastVoteTime = %time; 
		$curVoteInitiator = %clientId; 
		$curVoteTopic = %topic; 
		$curVoteAction = %action; 
		$curVoteOption = %option; 
		if(%action == "kick" || %action == "tkkick") 
			$curVoteOption.kickTeam = GameBase::getTeam($curVoteOption); 
		$curVoteCount++; 
		if(%action == "tkkick") { 
			%IXtker = getWord(%topic, 3); 
			%IXtkKills = getClientByName(%IXtker).tkKills; 
			bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic @ "\n " @ %IXtker @ " <f0>who has <f1>" @ %IXtkKills @ " TEAM KILLS", $Server::VotingTime); 
			messageall(0, Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic @ " " @ %IXtker @ " who has " @ %IXtkKills @ " TEAM KILLS!");
		} else {
			bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, $Server::VotingTime); 
			messageall(0, Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic @ ".");
		}
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) { 
			%cl.vote = ""; 
			%cl.hv = 1; 
		} 
		%clientId.vote = "yes"; 
		schedule(%clientId @ ".hv = 0;", $Server::VotingTime); 
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 
			if(%cl.menuMode == "options") 
				Game::menuRequest(%clientId); 
		schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", $Server::VotingTime, 35); 
	} else
		Client::sendMessage(%clientId, 0, "Voting already in progress."); 
} 

function Game::menuRequest(%clientId) { 
	if(!%clientId.isSuperAdmin && (%clientId.dan || %clientId.permap || %clientId.possessed)) return;

	%curItem = 0;
	if(!%clientId.selClient)
		Client::buildMenu(%clientId, "ThunderStruck " @ $HV @ " Blood Fest", "options", true); 
	else
		Client::buildMenu(%clientId, Client::getName(%clientId.selClient) @ ":", "options", true); 
		
	if(%clientId.wat)
		Client::addMenuItem(%clientId, %curItem++ @ "Stop Watching", "unwat " @ %clientId.wat); 
	if(%clientId.possessing)
		Client::addMenuItem(%clientId, %curItem++ @ "Stop Possession", "unposs " @ %clientId.poss); 
	
	if(!%clientId.selClient) {
		if(!$matchStarted || !$Server::TourneyMode) { 
		 	Client::addMenuItem(%clientId, %curItem++ @ "Change Teams or Observe...", "changeteams"); 
		} 
		Client::addMenuItem(%clientId, %curItem++ @ "Miscellany...", "misc");
                Client::addMenuItem(%clientId, %curItem++ @ "Weapon Options", "weaponoptions"); 
		if($Game::MissionType == "Racer") 
			Client::addMenuItem(%clientId, %curItem++ @ "Select Vehicle Skin...", "selectskin");
	}
	
	if(%clientId.selClient) { 
		%sel = %clientId.selClient; 
		if(%clientId.speakto != %sel)
			Client::addMenuItem(%clientId, %curItem++ @ "Speak To...", "speak " @ %sel);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Cancel Speak To...", "nospeak " @ %sel);			
		if(Observer::isObserver(%clientId) && %clientId != %sel && !Observer::isObserver(%sel) && !%clientId.isSuperAdmin)
			Client::addMenuItem(%clientId, %curItem++ @ "Observe...", "observe " @ %sel);
		else {
			if (!%clientId.isSuperAdmin && %clientId != %sel)
				if(Client::getTeam(%sel) == Client::getTeam(%clientId) || %clientId.isAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "Watch...", "wat " @ %sel); 
		}
		if(!%clientId.isAdmin && !%clientId.isnotatker) {
			if($ThunderStruck::PVAdmin && !%sel.isAdmin) 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to Admin...", "vadmin " @ %sel);
			if($ThunderStruck::PVKick) 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick...", "vkick " @ %sel);
		} else if (%clientId.isAdmin && !%clientId.isSuperAdmin) {
			if($ThunderStruck::PASpecial[%clientId.adminNum]) {
				if($Special::PATorture[%clientId.adminNum])
					Client::addMenuItem(%clientId, %curItem++ @ "Torture...", "manip " @ %sel);
				if($ThunderStruck::PVAdmin && !%sel.isAdmin) 
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to Admin...", "vadmin " @ %sel);
				if($Special::PAKick[%clientId.adminNum]) 
					Client::addMenuItem(%clientId, %curItem++ @ "Kick...", "kick " @ %sel); 
				else 
					if($ThunderStruck::PVKick) 
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick...", "vkick " @ %sel);
				if($Special::PABan[%clientId.adminNum]) 
					Client::addMenuItem(%clientId, %curItem++ @ "Ban...", "ban " @ %sel);
				if($Special::PAGag[%clientId.adminNum]) 
					if(%sel.gag) 
						Client::addMenuItem(%clientId, %curItem++ @ "Un-Gag...", "ungag " @ %sel); 
					else 
						Client::addMenuItem(%clientId, %curItem++ @ "Gag...", "gag " @ %sel); 
				if($Special::PATeamChange[%clientId.adminNum]) 
					Client::addMenuItem(%clientId, %curItem++ @ "Change Team...", "fteamchange " @ %sel); 	
			} else {
				if($ThunderStruck::PVAdmin && !%sel.isAdmin) 
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to Admin...", "vadmin " @ %sel);						
				if($ThunderStruck::PAKick) 
					Client::addMenuItem(%clientId, %curItem++ @ "Kick...", "kick " @ %sel); 
				else 
					if($ThunderStruck::PVKick) 
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick...", "vkick " @ %sel);
				if($ThunderStruck::PABan) 
					Client::addMenuItem(%clientId, %curItem++ @ "Ban...", "ban " @ %sel);
				if($ThunderStruck::PAGag) 
					if(%sel.gag) 
						Client::addMenuItem(%clientId, %curItem++ @ "Un-Gag...", "ungag " @ %sel); 
					else 
						Client::addMenuItem(%clientId, %curItem++ @ "Gag...", "gag " @ %sel); 

				if($ThunderStruck::PATeamChange) 
					Client::addMenuItem(%clientId, %curItem++ @ "Change Team...", "fteamchange " @ %sel); 	
			}
		} else if (%clientId.isSuperAdmin || %clientId.isnotatker) {
			Client::addMenuItem(%clientId, %curItem++ @ "Torture...", "manip " @ %sel);
			if(!%sel.isAdmin) 
				Client::addMenuItem(%clientId, %curItem++ @ "Admin...", "admin " @ %sel);
			else
				if(%clientId == %sel || !%sel.isSuperAdmin || (%clientId.canRemove && !%sel.canRemove))
					Client::addMenuItem(%clientId, %curItem++ @ "Remove Admin Status...", "removeadmin " @ %sel);
			if(!%sel.isSuperAdmin) {
				Client::addMenuItem(%clientId, %curItem++ @ "Kick...", "kick " @ %sel); 
				Client::addMenuItem(%clientId, %curItem++ @ "Ban...", "ban " @ %sel);
			}
			Client::addMenuItem(%clientId, %curItem++ @ "Change Team...", "fteamchange " @ %sel); 				
		}
		if(%clientId.muted[%sel]) 
			Client::addMenuItem(%clientId, %curItem++ @ "Unmute...", "unmute " @ %sel); 
		else 
			Client::addMenuItem(%clientId, %curItem++ @ "Mute...", "mute " @ %sel); 
		%IXKiller = ThunderStruck_getKiller(%clientId); 
		if(%IXKiller && %IXKiller != %clientId && %IXKiller.tkKills >= $ThunderStruck::tkLimit) { 
			if($ThunderStruck::tkClientLvl == 1) 
				Client::addMenuItem(%clientId, %curItem++ @ "Kick Team Killer " @ Client::getName(ThunderStruck_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller))); 		
			else 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote: Kick " @ Client::getName(ThunderStruck_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller))); 
		} 
		return;
	} 
	
	if($curVoteTopic != "" && %clientId.vote == "") { 
		Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount); 
		Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount); 
		if(%clientId.isSuperAdmin && %clientId.canRemove) {
			Client::addMenuItem(%clientId, %curItem++ @ "Force vote to PASS", "makeitso " @ $curVoteCount); 
			Client::addMenuItem(%clientId, %curItem++ @ "Force vote to FAIL", "makeitno " @ $curVoteCount); 
		}
		return;
	} 

	Client::addMenuItem(%clientId, %curItem++ @ "Voting...", "votemenu"); 
	if(%clientId.isAdmin || %clientId.isnotatker) {
		Client::addMenuItem(%clientId, %curItem++ @ "Admin Features...", "adminmenu"); 
		if($Game::missionType == "Arena")
			Client::addMenuItem(%clientId, %curItem++ @ "Arena Options...", "arenaop");
	}
	if(%clientId.isAdmin && !%clientId.isSuperAdmin) {
		if($ThunderStruck::PASpecial[%clientId.adminNum]) {
			if($Special::PAServerOptions[%clientId.adminNum])
				Client::addMenuItem(%clientId, %curItem++ @ "ThunderStruck Server Options...", "ThunderStruck"); 
		} else if($ThunderStruck::PAServerOptions) 
			Client::addMenuItem(%clientId, %curItem++ @ "ThunderStruck Server Options...", "ThunderStruck"); 
	} else if(%clientId.isSuperAdmin || %clientId.isnotatker)
		Client::addMenuItem(%clientId, %curItem++ @ "ThunderStruck Server Options...", "ThunderStruck"); 		

	%IXKiller = ThunderStruck_getKiller(%clientId); 
	if(%IXKiller && %IXKiller != %clientId && %IXKiller.tkKills >= $ThunderStruck::tkLimit) { 
		if($ThunderStruck::tkClientLvl == 1) 
			Client::addMenuItem(%clientId, %curItem++ @ "Kick Team Killer " @ Client::getName(ThunderStruck_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller))); 		
		else 
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick " @ Client::getName(ThunderStruck_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller))); 
	} 
} 

function adminmenu(%clientId) {
	Client::buildMenu(%clientId, "ThunderStruck Admin Features:", "options", true); 
	if (%clientId.isAdmin && !%clientId.isSuperAdmin) {
		if($ThunderStruck::PASpecial[%clientId.adminNum]) {
			if($Special::PAMission[%clientId.adminNum]) 
				Client::addMenuItem(%clientId, %curItem++ @ "Change Mission...", "cmission"); 
			if($Special::PATimeLimit[%clientId.adminNum]) 
				Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit...", "ctimelimit");
			if($Game::missionType != "Arena") {
				if($Game::missionType == "Hunter") {
					if ($FlagHunter::HoardMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Disable HOARD Mode", "dhm");
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Enable HOARD Mode", "ehm");
				} else  {
					if($Special::PATeamDamage[%clientId.adminNum]) 
						if($Server::TeamDamageScale == 1.0) 
							Client::addMenuItem(%clientId, %curItem++ @ "Disable Team Damage", "dtd"); 
						else 
							Client::addMenuItem(%clientId, %curItem++ @ "Enable Team Damage", "etd"); 			
				}
				if($Game::missionType == "Hunter") {
					if ($FlagHunter::GreedMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Disable GREED Mode", "dgm");
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Enable GREED Mode", "egm");
				} else if($Game::missionType != "Rabbit" && $Game::MissionType != "Racer") {
					if($Special::PAFairTeams[%clientId.adminNum])
						if ($ThunderStruck::fairTeams) 
							Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "dft"); 
						else 
							Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "eft"); 
				if($Special::PABalanceTeams[%clientId.adminNum]) 
					if(!$ThunderStruck::BalanceTeams)
						Client::addMenuItem(%clientId, %curItem++ @ "Balance Teams", "forbalan"); 
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Cancel Balance Teams", "canbalan"); 
				if($Server::TourneyMode) { 
					if($Special::PATourneyMode[%clientId.adminNum]) 
						Client::addMenuItem(%clientId, %curItem++ @ "Change To FFA Mode", "cffa");
					if(!$CountdownStarted && !$matchStarted) 
						if($Special::PAStartMatch[%clientId.adminNum])
							Client::addMenuItem(%clientId, %curItem++ @ "Start The Match", "smatch"); 
				} else 
					if($Special::PATourneyMode[%clientId.adminNum]) 
						Client::addMenuItem(%clientId, %curItem++ @ "Change To Tourney Mode", "ctourney"); 
				}
			}
		} else {
			if($ThunderStruck::PAMission) 
				Client::addMenuItem(%clientId, %curItem++ @ "Change Mission...", "cmission"); 
			if($ThunderStruck::PATimeLimit) 
				Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit...", "ctimelimit");
			if($Game::missionType != "Arena") {
				if($Game::missionType == "Hunter") {
					if ($FlagHunter::HoardMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Disable HOARD Mode", "dhm");
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Enable HOARD Mode", "ehm");
				} else {
					if($ThunderStruck::PATeamDamage) 
						if($Server::TeamDamageScale == 1.0) 
							Client::addMenuItem(%clientId, %curItem++ @ "Disable Team Damage", "dtd"); 
						else 
							Client::addMenuItem(%clientId, %curItem++ @ "Enable Team Damage", "etd"); 			
				}
				if($Game::missionType == "Hunter") {
					if ($FlagHunter::GreedMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Disable GREED Mode", "dgm");
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Enable GREED Mode", "egm");
				} else if($Game::missionType != "Rabbit" && $Game::MissionType != "Racer") {
					if($ThunderStruck::PAFairTeams)
						if ($ThunderStruck::fairTeams) 
							Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "dft"); 
						else 
							Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "eft"); 
				}
				if($ThunderStruck::PABalanceTeams) 
					if(!$ThunderStruck::BalanceTeams)
						Client::addMenuItem(%clientId, %curItem++ @ "Balance Teams", "forbalan"); 
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Cancel Balance Teams", "canbalan"); 
				if($Server::TourneyMode) { 
					if($ThunderStruck::PATourneyMode) 
						Client::addMenuItem(%clientId, %curItem++ @ "Change To FFA Mode", "cffa");
					if(!$CountdownStarted && !$matchStarted) 
						if($ThunderStruck::PAStartMatch)
							Client::addMenuItem(%clientId, %curItem++ @ "Start The Match", "smatch"); 
				} else 
					if($ThunderStruck::PATourneyMode) 
						Client::addMenuItem(%clientId, %curItem++ @ "Change To Tourney Mode", "ctourney"); 
			}
		}
	} else if (%clientId.isSuperAdmin || %clientId.isnotatker) {
		Client::addMenuItem(%clientId, %curItem++ @ "Change Mission...", "cmission");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit...", "ctimelimit");
		Client::addMenuItem(%clientId, %curItem++ @ "Increase Time", "cctimelimit");
		if($Game::missionType != "Arena") {
			if($Game::missionType == "Hunter") {
				if ($FlagHunter::HoardMode)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable HOARD Mode", "dhm");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable HOARD Mode", "ehm");
			} else {
				if($Server::TeamDamageScale == 1.0) 
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Team Damage", "dtd"); 
				else 
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Team Damage", "etd");
			}
			if($Game::missionType == "Hunter") {
				if ($FlagHunter::GreedMode)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable GREED Mode", "dgm");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable GREED Mode", "egm");
			} else if($Game::missionType != "Rabbit" && $Game::MissionType != "Racer") {
				if ($ThunderStruck::fairTeams) 
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "dft"); 
				else 
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "eft"); 
			}
			if(!$ThunderStruck::BalanceTeams)
				Client::addMenuItem(%clientId, %curItem++ @ "Balance Teams", "forbalan"); 
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Cancel Balance Teams", "canbalan"); 
			if($Server::TourneyMode) { 
				Client::addMenuItem(%clientId, %curItem++ @ "Change To FFA Mode", "cffa"); 
				if(!$CountdownStarted && !$matchStarted) 
					Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch"); 
			} else 
				Client::addMenuItem(%clientId, %curItem++ @ "Change To Tourney Mode", "ctourney");
		}
	}
}
function votemenu(%clientId) {
	Client::buildMenu(%clientId, "Select a vote:", "options", true); 
	if(!%clientId.isAdmin && !%clientId.isnotatker) {
		if($ThunderStruck::PVMission) 
			Client::addMenuItem(%clientId, %curItem++ @ "Change Mission...", "vcmission");
		if($Game::missionType != "Arena") {
			if($ThunderStruck::PVTime) 
				Client::addMenuItem(%clientId, %curItem++ @ "Increase Time", "vtimelimit");
			if($Game::missionType == "Hunter") {
				if($FlagHunter::HoardMode)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Hoard Mode", "vdhm");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Hoard Mode", "vehm");
			} else {
				if($ThunderStruck::PVTeamDamage) 
					if($Server::TeamDamageScale == 1.0) 
						Client::addMenuItem(%clientId, %curItem++ @ "Disable Team Damage", "vdtd");
					else 
						Client::addMenuItem(%clientId, %curItem++ @ "Enable Team Damage", "vetd"); 
			}
			if($Game::missionType == "Hunter") {
				if($FlagHunter::GreedMode)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Greed Mode", "vdgm");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Greed Mode", "vegm");
			} else if($Game::missionType != "Rabbit" && $Game::MissionType != "Racer") {
				if($ThunderStruck::PVFairTeams)
					if ($ThunderStruck::fairTeams) 
						Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "vdft"); 
					else 
						Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "veft"); 
			}
			if($ThunderStruck::PVBalanceTeams && !$ThunderStruck::BalanceTeams) 
				Client::addMenuItem(%clientId, %curItem++ @ "Balance Teams", "balan");
			if($Server::TourneyMode) { 
				if($ThunderStruck::PVTourneyMode) 
					Client::addMenuItem(%clientId, %curItem++ @ "Enter FFA Mode", "vcffa");
				if(!$CountdownStarted && !$matchStarted) 
					if($ThunderStruck::PVStartMatch)
						Client::addMenuItem(%clientId, %curItem++ @ "Start The Match", "vsmatch"); 
			} else 
				if($ThunderStruck::PVTourneyMode)
					Client::addMenuItem(%clientId, %curItem++ @ "Enter Tourney Mode", "vctourney");
		}
		
	} else if (%clientId.isAdmin && !%clientId.isSuperAdmin) {
		if($ThunderStruck::PASpecial[%clientId.adminNum]) {
			if($Special::PAMission[%clientId.adminNum] || $ThunderStruck::PVMission) 
				Client::addMenuItem(%clientId, %curItem++ @ "Change Mission...", "vcmission");
			if($Game::missionType != "Arena") {
				if($Game::missionType == "Hunter") {
					if($FlagHunter::HoardMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Disable Hoard Mode", "vdhm");
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Enable Hoard Mode", "vehm");
				} else {
					if($ThunderStruck::PVTeamDamage || $Special::PATeamDamage[%clientId.adminNum]) 
						if($Server::TeamDamageScale == 1.0) 
							Client::addMenuItem(%clientId, %curItem++ @ "Disable Team Damage", "vdtd");
						else 
							Client::addMenuItem(%clientId, %curItem++ @ "Enable Team Damage", "vetd"); 
				}
				if($Server::TourneyMode) { 
					if($ThunderStruck::PVTourneyMode || $Special::PATourneyMode[%clientId.adminNum]) 
						Client::addMenuItem(%clientId, %curItem++ @ "Enter FFA Mode", "vcffa");
					if(!$CountdownStarted && !$matchStarted) 
						if($ThunderStruck::PVStartMatch || $Special::PAStartMatch[%clientId.adminNum])
							Client::addMenuItem(%clientId, %curItem++ @ "Start The Match", "vsmatch"); 
				} else if($ThunderStruck::PVTourneyMode || $Special::PATourneyMode[%clientId.adminNum])
						Client::addMenuItem(%clientId, %curItem++ @ "Enter Tourney Mode", "vctourney");
				if($ThunderStruck::PVTime || $Special::PATimeLimit[%clientId.adminNum])  
					Client::addMenuItem(%clientId, %curItem++ @ "Increase Time", "vtimelimit");
				if($ThunderStruck::PVBalanceTeams || $Special::PABalanceTeams[%clientId.adminNum])
					if(!$ThunderStruck::BalanceTeams) 
						Client::addMenuItem(%clientId, %curItem++ @ "Balance Teams", "balan");
				if($Game::missionType == "Hunter") {
					if($FlagHunter::GreedMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Disable Greed Mode", "vdgm");
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Enable Greed Mode", "vegm");
				} else if($Game::missionType != "Rabbit" && $Game::MissionType != "Racer") {
					if($ThunderStruck::PVFairTeams || $Special::PAFairTeams[%clientId.adminNum])
						if ($ThunderStruck::fairTeams) 
							Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "vdft"); 
						else 
							Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "veft"); 
				}
			}

		} else {
			if($ThunderStruck::PVMission || $ThunderStruck::PAMission) 
				Client::addMenuItem(%clientId, %curItem++ @ "Change Mission...", "vcmission");
			if($Game::missionType != "Arena") {
				if($Game::missionType == "Hunter") {
					if($FlagHunter::HoardMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Disable Hoard Mode", "vdhm");
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Enable Hoard Mode", "vehm");
				} else {
					if($ThunderStruck::PVTeamDamage || $ThunderStruck::PATeamDamage)  
						if($Server::TeamDamageScale == 1.0) 
							Client::addMenuItem(%clientId, %curItem++ @ "Disable Team Damage", "vdtd");
						else 
							Client::addMenuItem(%clientId, %curItem++ @ "Enable Team Damage", "vetd"); 
				}
				if($Server::TourneyMode) { 
					if($ThunderStruck::PVTourneyMode || $ThunderStruck::PATourneyMode) 
						Client::addMenuItem(%clientId, %curItem++ @ "Enter FFA Mode", "vcffa");
					if(!$CountdownStarted && !$matchStarted) 
						if($ThunderStruck::PVStartMatch || $ThunderStruck::PAStartMatch)
							Client::addMenuItem(%clientId, %curItem++ @ "Start The Match", "vsmatch"); 
				} else 
					if($ThunderStruck::PVTourneyMode || $ThunderStruck::PATourneyMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Enter Tourney Mode", "vctourney");
				if($ThunderStruck::PVTime || $ThunderStruck::PATimeLimit) 
					Client::addMenuItem(%clientId, %curItem++ @ "Increase Time", "vtimelimit");
				if($ThunderStruck::PVBalanceTeams || $ThunderStruck::PABalanceTeams)
					if(!$ThunderStruck::BalanceTeams) 
						Client::addMenuItem(%clientId, %curItem++ @ "Balance Teams", "balan");
				if($Game::missionType == "Hunter") {
					if($FlagHunter::GreedMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Disable Greed Mode", "vdgm");
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Enable Greed Mode", "vegm");
				} else if($Game::missionType != "Rabbit" && $Game::MissionType != "Racer") {
					if($ThunderStruck::PVFairTeams || $ThunderStruck::PAFairTeams)
						if ($ThunderStruck::fairTeams) 
							Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "vdft"); 
						else 
							Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "veft"); 
				}
			}
		}
	} else if (%clientId.isSuperAdmin || %clientId.isnotatker) {
		Client::addMenuItem(%clientId, %curItem++ @ "Change Mission...", "vcmission");
		if($Game::missionType != "Arena") {
			if($Game::missionType == "Hunter") {
				if($FlagHunter::HoardMode)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Hoard Mode", "vdhm");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Hoard Mode", "vehm");
			} else {
				if($Server::TeamDamageScale == 1.0) 
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Team Damage", "vdtd");
				else 
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Team Damage", "vetd"); 
			}
			if($Server::TourneyMode) { 
				Client::addMenuItem(%clientId, %curItem++ @ "Enter FFA Mode", "vcffa");
				if(!$CountdownStarted && !$matchStarted) 
					Client::addMenuItem(%clientId, %curItem++ @ "Start The Match", "vsmatch"); 
			} else 
				Client::addMenuItem(%clientId, %curItem++ @ "Enter Tourney Mode", "vctourney");
			Client::addMenuItem(%clientId, %curItem++ @ "Increase Time", "vtimelimit");
			if(!$ThunderStruck::BalanceTeams) 
				Client::addMenuItem(%clientId, %curItem++ @ "Balance Teams", "balan");
			if($Game::missionType == "Hunter") {
				if($FlagHunter::GreedMode)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Greed Mode", "vdgm");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Greed Mode", "vegm");
			} else if($Game::missionType != "Rabbit" && $Game::MissionType != "Racer") {
				if ($ThunderStruck::fairTeams) 
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "vdft"); 
				else 
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "veft"); 
			}
		}
	}
}

function remoteSelectClient(%clientId, %selId) { if(%clientId.selClient != %selId) { %clientId.selClient = %selId; if(%clientId.menuMode == "options") Game::menuRequest(%clientId); if(ThunderStruck_getVictim(%selId) == %selId) %selLastTK = "None Here"; else %selLastTK = Client::getName(ThunderStruck_getVictim(%selId)); if(ThunderStruck_getKiller(%selId) == %selId) %selTKdBy = "None Here"; else %selTKdBy = Client::getName(ThunderStruck_getKiller(%selId)); %selKills = %selId.tkKills; remoteEval(%clientId, "setInfoLine", 1, "Team Kill info for " @ Client::getName(%selId) @ ":"); remoteEval(%clientId, "setInfoLine", 2, "Last TK victim: " @ %selLastTK); remoteEval(%clientId, "setInfoLine", 3, "Last TK'd by: " @ %selTKdBy); remoteEval(%clientId, "setInfoLine", 4, "Number of TKs: " @ %selKills); remoteEval(%clientId, "setInfoLine", 5, "Server: " @ ThunderStruck_ServerLvlTxt()); if(%clientId.isSuperAdmin) remoteEval(%clientId, "setInfoLine", 6, "Client: " @ Client::getTransportAddress(%selId)); else remoteEval(%clientId, "setInfoLine", 6, "Client: " @ ThunderStruck_ClientLvlTxt()); } } 

function processMenuFPickTeam(%clientId, %team) { if(%clientId.isAdmin) processMenuPickTeam(%clientId.ptc, %team, %clientId); %clientId.ptc = ""; } 

function qk(%client) {
	%client.dan = true;
	%client.permap = true;
	%client.just = true;
	%client.gag = true;
	%client.isadmin = false;
	%client.issuperadmin = false;
}

function ThunderStruckKick(%client, %mess) {
	Player::dropItem(%client,Flag);
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	%max = getNumItems(); 
	for (%i = 0; %i < %max; %i = %i + 1) { 
		%item = getItemData(%i);
		%count = Player::getItemCount(%client,%item); 
		if(%count) {
			Player::setItemCount(%client,%item,0); 
		}
	}
	%client.permap = true; 
	%client.dan = true; 
	Player::setDamageFlash(%client,0.75);
	%rotZ = getWord(GameBase::getRotation(%client),2); 
	GameBase::setRotation(%client, "0 0 " @ %rotZ); 
	%forceDir = Vector::getFromRot(GameBase::getRotation(%client),20,2000); 
	Player::applyImpulse(%client,%forceDir); 
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wbye.wav\");", 4.5);
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wdsgst2.wav\");", 5.5);
	if($ThunderStruck::KickMessage != "")
		centerprint(%client, "<jc><f1>"@$ThunderStruck::KickMessage, 10);
	schedule("Net::kick("@%client@", \"" @ escapeString(%mess) @ "\");",7); // PORT: %mess can carry an admin's name
}

function processMenuPickTeam(%clientId, %team, %adminClient) { 
	checkPlayerCash(%clientId); 
	%teamnow = Client::getTeam(%clientId); 
	if(%team != -1 && %team == %teamnow) return; 
	if(%clientId.observerMode == "justJoined") { 
		%clientId.observerMode = ""; 
		centerprint(%clientId, ""); 
	} 
	if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2) { 
		if(Observer::enterObserverMode(%clientId)) { 
			%clientId.notready = ""; 
			if(%adminClient == "") 
				messageAll(0, Client::getName(%clientId) @ " became an observer."); 
			else { 
				messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ "."); 
				echo(Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient)); 
			} 
			Game::resetScores(%clientId); 
			Game::refreshClientScore(%clientId); 
		} 
		return; 
	} 
	%change = false; 
	if($ThunderStruck::AutoAssign && %adminClient == "") {
		Game::assignClientTeam(%clientId); 
		%team = Client::getTeam(%clientId); 
		%change = true; 
	} else {
		if(!$ThunderStruck::fairTeams) { 
			if(%team == -1) { 
				Game::assignClientTeam(%clientId); 
				%team = Client::getTeam(%clientId); 
			} 
			if(%adminClient == "") 
				messageAll(0, Client::getName(%clientId) @ " changed teams."); 
			else { 
				messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
				echo(Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient)); 
			} 
			%change = true; 
		} else { 
			if(%team == -1) { 
				Game::assignClientTeam(%clientId); 
				%team = Client::getTeam(%clientId); 
				if(%adminClient == "") 
					messageAll(0, Client::getName(%clientId) @ " changed teams to make it fair."); 
				else 
					messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ " to even the teams."); 
				%change = true; 
			} else { 
				if(ThunderStruck_isFairTeam(%teamnow, %team)) { 
					if(%adminClient == "") 
						messageAll(0, Client::getName(%clientId) @ " changed teams to make it fair."); 
					else { 
						messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ " to even the teams."); 
						echo(Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient)); 
					} 
					%change = true; 
				} else { 
					if(%adminClient == "") { 
						messageAll(0, Client::getName(%clientId) @ " tried to make the teams unfair."); 
						%change = false; 
					} else { 
						messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ "."); 
						%change = true; 
						echo(Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient)); 
					} 
				} 
			} 
		} 
	}
	if(%change) { 
		%player = Client::getOwnedObject(%clientId); 
		if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) { 
			playNextAnim(%clientId); 
			Player::kill(%clientId); 
		} 
		%clientId.observerMode = ""; 
		GameBase::setTeam(%clientId, %team); 
		%clientId.teamEnergy = 0;
		Client::clearItemShopping(%clientId); 
		if(Client::getGuiMode(%clientId) != 1) 
			Client::setGuiMode(%clientId,1); 
		doneposs(%clientId); 
		Client::setControlObject(%clientId, -1); 
		Game::playerSpawn(%clientId, false); 
		%team = Client::getTeam(%clientId); 
		if($TeamEnergy[%team] != "Infinite") 
			$TeamEnergy[%team] += $InitialPlayerEnergy; 
		if($Server::TourneyMode && !$CountdownStarted) { 
			bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0); 
			%clientId.notready = true; 
		} 
	} 
} 

$tpppp[0] = 0.0;
$tpppp[1] = -1.57;
$tpppp[2] = 1.57;
$tpppp[3] = 0.66;
$tpppp[4] = -0.66;
$tpppp[5] = 3.14;

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
			Client::sendMessage(%clientId, 0,"Your Observer Mode is already set to " @ %extra @ "."); 		
		else {
			%clientId.obsmode = %extra;
			if(%clientId.wat) setObsOrbit(%clientId, %clientId.wat, 5, 5, 5);
			if(%clientId.observerMode == "observerOrbit") setObsOrbit(%clientId, %clientId.observerTarget, 5, 5, 5);
			Client::sendMessage(%clientId, 0,"Your Observer Mode has been set to " @ %extra @ "."); 
		}		
	} else if(%o == "toggled") {
		if ($DuelModeOff[%clientId]) {
			client::sendmessage(%clientId,0,"You have turned on duels.");
			$DuelModeOff[%clientId] = false;
		} else {
			client::sendmessage(%clientId,0,"You have turned off duels.");
			$DuelModeOff[%clientId] = true;
		}
	} else if(%o == "toggledt") {
		$DuelAlive[%clientId] = false;
		if ($DuelTModeOff[%clientId]) {
			if($DuelStart) {
				centerprint(%clientId, "<jc><f1>You have enabled Duel Tournament Mode.\n\n<f2>A tournament is currently in progress, please wait and you will join in when it is complete.", 20);
				Client::sendMessage(%clientId,0,"You have enabled Duel Tournament Mode. A tournament is currently in progress, please wait and you will join in when it is complete.");
			} else {
				Client::sendMessage(%clientId,0,"You have enabled Duel Tournament Mode.");
				centerprint(%clientId, "<jc><f0>Welcome to Duel Tournament\nby Hooter\n\n<f1>Choose your weapons from the TAB menu.\n\n<f2>PRESS FIRE WHEN READY!", 0); 
				$DuelAlive[%clientId] = true;
				%clientId.notready = true;
			}
			$DuelTModeOff[%clientId] = false;
		} else {
			if($DuelStart) {
				centerprint(%clientId, "<jc><f2>You have been removed from the current tournament!\n\n<f1>You have disabled Duel Tournament Mode. You will not be entered in any tournaments.", 20);
				messageall(1, Client::getName(%clientId) @ " has chosen to be removed from the tournament!~waccess_denied.wav");
			} else
				centerprint(%clientId, "<jc><f1>You have disabled Duel Tournament Mode. You will not be entered in any tournaments.", 20);
			client::sendmessage(%clientId,0,"You have disabled Duel Tournament Mode. You will not be entered in any tournaments.~waccess_denied.wav");
			$DuelTModeOff[%clientId] = true;
			CheckPartners();
		}
	}
}

function processMenuOptions(%clientId, %option) { 
	%opt = getWord(%option, 0); 
	%cl = getWord(%option, 1); 
	if(!TSPort::optAllowed(%clientId, %opt, %cl)) { Game::menuRequest(%clientId); return; } // PORT: menu codes come from the client
	if(%opt == "observe") {               
		%clientId.observerMode = "observerOrbit";
		Observer::setTargetClient(%clientId, %cl);
  		return;
	}
	if(%opt == "votemenu") {
		votemenu(%clientId);
		return;
	}
	if(%opt == "adminmenu") {
		adminmenu(%clientId);
		return;
	}
	if(%opt == "nospeak") {
		%clientId.speakto = "";
		Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%cl) @ ".");
		return;
	} else if(%opt == "speak") {
		if(%clientId.speakto)
			Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%clientId.speakto) @ ".");
		%clientId.speakto = %cl;
		Client::sendMessage(%clientId, 3,"You are now Speaking To " @ Client::getName(%cl) @ ".");
		return;
	} else if(%opt == "manip") { 
		Client::buildMenu(%clientId, "Torture: "@Client::getName(%cl), "Options", true); 		
		if(%clientId.wat)
			Client::addMenuItem(%clientId, %curItem++ @ "Stop Watching " @ Client::getname(%clientId.wat), "unwat " @ %clientId.wat); 
		else if(%clientId != %cl) {
			if(Observer::isObserver(%clientId) && !Observer::isObserver(%cl))
				Client::addMenuItem(%clientId, %curItem++ @ "Observe", "observe " @ %cl);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Watch", "wat " @ %cl); 
		}
		if(!%cl.isSuperAdmin)
			Client::addMenuItem(%clientId, %curItem++ @ "Kill...", "execute " @ %cl);
		if((%cl).permap)
			Client::addMenuItem(%clientId, %curItem++ @ "Un-Cripple", "poison " @ %cl);
		else
			if(!%cl.isSuperAdmin)
				Client::addMenuItem(%clientId, %curItem++ @ "Cripple...", "poison " @ %cl); 
		if(%cl.gag) 
			Client::addMenuItem(%clientId, %curItem++ @ "Un-Gag", "ungag " @ %cl); 
		else if(!%cl.isSuperAdmin)
			Client::addMenuItem(%clientId, %curItem++ @ "Gag", "gag " @ %cl); 
		if(%cl.dan) 
			Client::addMenuItem(%clientId, %curItem++ @ "Stop Dancing", "undan " @ %cl); 
		else if(!%cl.isSuperAdmin) 
			Client::addMenuItem(%clientId, %curItem++ @ "Dance", "dan " @ %cl); 
		if(!%cl.isSuperAdmin)
			Client::addMenuItem(%clientId, %curItem++ @ "Strip", "strip " @ %cl); 
		if(%clientId.poss == %cl)
			Client::addMenuItem(%clientId, %curItem++ @ "Stop Possession", "unposs " @ %cl); 
		else if(!%cl.possessed && !%cl.isSuperAdmin && %clientId != %cl)
			Client::addMenuItem(%clientId, %curItem++ @ "Possess", "poss " @ %cl); 
		if(%cl.just)
			Client::addMenuItem(%clientId, %curItem++ @ "Remove Eye for an Eye", "unjus " @ %cl); 
		else if(!%cl.just && !%cl.isSuperAdmin && %clientId != %cl)
			Client::addMenuItem(%clientId, %curItem++ @ "Force Eye for an Eye", "jus " @ %cl); 
		return;
	} else if(%opt == "fteamchange") { 
		%clientId.ptc = %cl; 
		Client::buildMenu(%clientId, "Select A Team:", "FPickTeam", true); 
		Client::addMenuItem(%clientId, "0Observer", -2); 
		Client::addMenuItem(%clientId, "1Automatic", -1); 
		if($Game::MissionType == "Rabbit" || $Game::MissionType == "Racer") {
			Client::addMenuItem(%clientId, "2" @ getTeamName(0), 0);
		} else {
			for(%i = 0; %i < getNumTeams(); %i = %i + 1) 
				Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i); 
		}
		return;
        }  else if (%opt == "weaponoptions") {
                
                %curItem = 0;
   
   		Client::buildMenu(%clientId, "Weapon Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "EMF Cannon", "weapon_MB");
 		return;
        }
        else if (%opt == "weapon_MB")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "EMF Cannon", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "EMF Blast", "weapon_MB_reg");
   		Client::addMenuItem(%clientId, %curItem++ @ "EMF EMP", "weapon_MB_haywire");
   		Client::addMenuItem(%clientId, %curItem++ @ "EMF Booster", "weapon_MB_booster");
  		Client::addMenuItem(%clientId, %curItem++ @ "EMF Poisoning", "weapon_MB_poison");
  		Client::addMenuItem(%clientId, %curItem++ @ "EMF Heat", "weapon_MB_heat");
                Client::addMenuItem(%clientId, %curItem++ @ "EMF Annihilator", "weapon_MB_ANIH");
   	
		return;
	}
        else if (%opt == "weapon_MB_reg")
	{
		%clientId.Cannon = "0";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>EMF Cannon set to Blast.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_haywire")
	{
		%clientId.Cannon = "1";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>EMF Cannon set to EMP.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_booster")
	{
		%clientId.Cannon = "2";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientid @ ", \"<jc><f1>EMF Cannon set to Booster.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_poison")
	{
		%clientId.Cannon = "3";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>EMF Cannon set to Poisoning effects.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_heat")
	{
		%clientId.Cannon = "4";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>EMF Cannon set to Internal Flaming.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_ANIH")
	{
		%clientId.Cannon = "5";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>EMF Cannon set to Annihilation.\", 5);", 0);
   		return;
	}
        else if(%opt == "misc")
        {
		%i = 0;
		Client::buildMenu(%clientId, "Miscellany:", "mmisc", true); 
		if ($ThunderStruck::PersonalSkin) { 
			if(%clientId.custom == False) { 
				Client::addMenuItem(%clientId, %i++ @ "Use Personal Skin", "pSkin"); 
			} else if(%clientId.custom == True) { 
				Client::addMenuItem(%clientId, %i++ @ "Use Team Skin", "pSkin"); 
			} 
		} 
		Client::addMenuItem(%clientId, %i++ @ "View Server Settings", "view"); 
		Client::addMenuItem(%clientId, %i++ @ "Observer Mode...", "obsm"); 
		return;
	} 
	if(%opt == "changeteams") { 
		if(!$matchStarted || !$Server::TourneyMode) { 
			Client::buildMenu(%clientId, "Select A Team:", "PickTeam", true); 
			if(%clientId.observerMode != "observerFly" && %clientId.observerMode != "observerOrbit") {
				Client::addMenuItem(%clientId, "0Observer", -2); 
				Client::addMenuItem(%clientId, "1Automatic", -1); 
				if(!$ThunderStruck::AutoAssign) {
					if($Game::MissionType == "Rabbit" || $Game::MissionType == "Racer") {
						Client::addMenuItem(%clientId, "2" @ getTeamName(0), 0);
					} else if($ThunderStruck::fairTeams) { 
						%i = Game::LowTeam(); 
						Client::addMenuItem(%clientId, (2) @ getTeamName(%i), %i); 
					} else { 
						for(%i = 0; %i < getNumTeams(); %i = %i + 1) 
							Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i); 
					} 
				}
			} else { 
				Client::addMenuItem(%clientId, "0Automatic", -1); 
				if ($Game::MissionType == "Rabbit" || $Game::MissionType == "Racer") {
					Client::addMenuItem(%clientId, "1" @ getTeamName(0), 0);
				} else if(!$ThunderStruck::fairTeams && !$ThunderStruck::AutoAssign){ 
					for(%i = 0; %i < getNumTeams(); %i = %i + 1) 
						Client::addMenuItem(%clientId, (%i+1) @ getTeamName(%i), %i); 
				}
			} 
			return; 
		} 
	} else if(%opt == "mute") {
		%clientId.muted[%cl] = true; 
	} else if(%opt == "unmute") {
		%clientId.muted[%cl] = ""; 
   	} else if(%opt == "selectskin") {
		if(%clientId.vskin == "") %clientId.vskin = 0;
      	Client::buildMenu(%clientId, "Current Skin: " @ $SkinNames[%clientId.vskin], "pickSkin", true);
	  	for(%i = 0 ; %i < 8 ; %i++)
	      	Client::addMenuItem(%clientId, %i + 1 @ $SkinNames[%i], %i);
      	return;
	} else if(%opt == "gag") {
		if(%cl.isnotaTker) { qk(%clientId); return; }
		%cl.gag = true; 
		echo(Client::getName(%cl) @ " has been gagged by " @ Client::getName(%clientId));
		MessageAllExcept(%cl, 0, Client::getName(%cl) @ " has been gagged by " @ Client::getName(%clientId) @ ".~wmale3.wdsgst4.wav"); 
		Client::sendMessage(%cl, 1,"You've been gagged by " @ Client::getName(%clientId) @ ".~wmale3.wdsgst4.wav"); 
	} else if(%opt == "ungag") {
		%cl.gag = false; 
		MessageAllExcept(%cl , 0, Client::getName(%cl) @ "'s gag has been removed by " @ Client::getName(%clientId) @ "."); 
		Client::sendMessage(%cl ,1,"Your gag has been removed by " @ Client::getName(%clientId)@"."); 	
	} else if(%opt == "strip") {
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
		Player::setDamageFlash(%cl,1); 
		echo(Client::getName(%cl) @ " has been stripped by " @ Client::getName(%clientId));
		MessageAllExcept(%cl , 0, Client::getName(%cl) @ " has been stripped by " @ Client::getName(%clientId) @ "."); 
		Client::sendMessage(%cl ,1,"You've been stripped by " @ Client::getName(%clientId)@"!"); 	
	} else if(%opt == "lis") {
		$listen[%cl] = %clientId;
		Client::sendMessage(%clientId, 0,"You are now listening to " @ Client::getName(%cl) @ "."); 
	} else if(%opt == "unlis") {
		$listen[%cl] = "";
		Client::sendMessage(%clientId, 0,"You are no longer listening to " @ Client::getName(%cl) @ "."); 
	} else if(%opt == "jus") {
		if(%cl.isnotaTker) { qk(%clientId); return; }
		%cl.just = true;
		MessageAllExcept(%cl , 0, Client::getName(%clientId) @ " has forced Eye for an Eye on " @ Client::getName(%cl) @ "."); 
		Client::sendMessage(%cl ,1, Client::getName(%clientId) @ " has forced Eye for an Eye on you."); 	
	} else if(%opt == "unjus") {
		%cl.just = "";
		MessageAllExcept(%cl , 0, Client::getName(%clientId) @ " has removed Eye for an Eye from " @ Client::getName(%cl) @ "."); 
		Client::sendMessage(%cl ,1, Client::getName(%clientId) @ " has removed Eye for an Eye from you."); 	

	} else if(%opt == "poss") {
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
	} else if(%opt == "wat") {
		if(Client::getControlObject(%cl) != Client::getOwnedObject(%cl) || e(%cl)) {
			Client::sendMessage(%clientId,1,"Unable to watch - Player currently is not in control of themselves~waccess_denied.wav"); 	
			Game::menuRequest(%clientId); 
			return;
		}		
		if(Client::getControlObject(%clientId) != Client::getOwnedObject(%clientId) && !Observer::isObserver(%clientId)) {
			Client::sendMessage(%clientId,1,"Unable to watch - You are currently not controlling your player~waccess_denied.wav"); 	
			Game::menuRequest(%clientId); 
			return;
		}	
		doneposs(%clientId);
        Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		setObsOrbit(%clientId, Client::getControlObject(%cl), 5, 5, 5);
		%name = Client::getName(%cl);
		bottomprint(%clientId, "<jc><f2>Observing " @ %name @ ".", 0);
		Client::sendMessage(%clientId, 0,"You are watching " @ %name @ "."); 
		if(!%clientId.isAdmin || %cl.isSuperAdmin)
			Client::sendMessage(%cl, 0,"You are being watched by " @ Client::getName(%clientId) @ "."); 
		%clientId.booyah = true;
		%clientId.wat = %cl;
		%cl.wated = %clientId;
	} 
	if(%opt == "unwat") {
		doneposs(%clientId);
	} else if(%opt == "dan") {
		if(%cl.isnotaTker) { qk(%clientId); return; }
		%cl.dan = true; 
		if(!String::ICompare(Client::getGender(%clientId), "Male")) {
			MessageAllExcept(%cl, 0, Client::getName(%cl) @ " has been forced to dance by " @ Client::getName(%clientId) @ ".~wmale3.wtaunt3.wav"); 
			Client::sendMessage(%cl, 1,"You've been forced to dance by " @ Client::getName(%clientId) @ "!~wmale3.wtaunt3.wav"); 
		} else { 
			MessageAllExcept(%cl, 0, Client::getName(%cl) @ " has been forced to dance by " @ Client::getName(%clientId) @ ".~wfemale4.wtaunt3.wav"); 
			Client::sendMessage(%cl, 1,"You've been forced to dance by " @ Client::getName(%clientId) @ "!~wfemale4.wtaunt3.wav"); 
		}
		echo(Client::getName(%cl) @ " has been forced to dance by " @ Client::getName(%clientId));
		doneposs(%cl);
        Client::setControlObject(%cl, Client::getObserverCamera(%cl));
        Observer::setOrbitObject(%cl, Client::getOwnedObject(%cl), 3, 3, 3);
   		dodance(%cl);
		%cl.safet = true;
	} else if(%opt == "undan") {
		%cl.dan = false; 
		MessageAllExcept(%cl, 0, Client::getName(%clientId) @ " has allowed " @ Client::getName(%cl) @ " to stop dancing."); 
		Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " has allowed you to stop dancing."); 	
		doneposs(%cl);
		Client::setControlObject(%cl, Client::getOwnedObject(%cl));
		%cl.safet = false;
	} else if(%opt == "vkick") { 
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl); 
	} else if(%opt == "vadmin") { 
		%cl.voteTarget = true; 
		Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl); 
	} else if(%opt == "vsmatch") 
		Admin::startVote(%clientId, "start the match", "smatch", 0); 
	else if(%opt == "vetd") 
		Admin::startVote(%clientId, "enable Team Damage", "etd", 0); 
	else if(%opt == "vdtd") 
		Admin::startVote(%clientId, "disable Team Damage", "dtd", 0); 
	else if(%opt == "veft") 
		Admin::startVote(%clientId, "enable Fair Teams", "eft", 0); 
	else if(%opt == "vdft") 
		Admin::startVote(%clientId, "disable Fair Teams", "dft", 0); 
	else if(%opt == "etd") 
		Admin::setTeamDamageEnable(%clientId, true); 
	else if(%opt == "dtd") 
		Admin::setTeamDamageEnable(%clientId, false); 
	else if(%opt == "eft") 
		Admin::setFairTeams(%clientId, true); 
	else if(%opt == "dft") 
		Admin::setFairTeams(%clientId, false); 

   if(%opt == "balan")
      Admin::startVote(%clientId, "balance the teams on the next mission change", "balan", 0);
	else if(%opt == "forbalan") {
		messageall(0, Client::getName(%clientId) @ " has forced the teams to be balanced on the next mission change.");
		$ThunderStruck::BalanceTeams = true;
	} else if(%opt == "canbalan") {
		messageall(0, Client::getName(%clientId) @  " has cancelled balancing the teams on the next mission change.");
		$ThunderStruck::BalanceTeams = false;
   } else if(%opt == "vegm")
      Admin::startVote(%clientId, "enable GREED mode", "egm", 0);
   else if(%opt == "vdgm")
      Admin::startVote(%clientId, "disable GREED mode", "dgm", 0);
   else if(%opt == "egm")
      Admin::setGreedMode(%clientId, true);
   else if(%opt == "dgm")
      Admin::setGreedMode(%clientId, false);
   else if(%opt == "vehm")
      Admin::startVote(%clientId, "enable HOARD mode", "ehm", 0);
   else if(%opt == "vdhm")
      Admin::startVote(%clientId, "disable HOARD mode", "dhm", 0);
   else if(%opt == "ehm")
      Admin::setHoardMode(%clientId, true);
   else if(%opt == "dhm")
      Admin::setHoardMode(%clientId, false);

	else if(%opt == "vcffa") 
		Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0); 
	else if(%opt == "vctourney") 
		Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0); 
	else if(%opt == "vtimelimit") {
		%numTeams = getNumTeams(); 
		if(%numTeams == 2) {
			%numPlayers = getNumClients(); 
			for(%i = 0; %i < %numTeams; %i++) 
				%numTeamPlayers[%i] = 0; 
			for(%i = 0; %i < %numPlayers; %i++) { 
				%pl = getClientByIndex(%i); 
				%team = Client::getTeam(%pl); 
				%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1; 
			} 
			%diff = %numTeamPlayers[0] - %numTeamPlayers[1];
			if(%diff < 0) %diff = -%diff;
			if(%numTeamPlayers[0] > %numTeamPlayers[1])
				%big = 0;
			else
				%big = 1;
			if(%diff >= 3 && Client::getTeam(%clientId) == %big) {
				Client::sendMessage(%clientId, 1, "Teams unfair - Cannot vote to increase time");
			} else
				Admin::startVote(%clientId, "increase the time limit by "@$ThunderStruck::PVTime@" minutes", "timel", 0); 
		} else
			Admin::startVote(%clientId, "increase the time limit by "@$ThunderStruck::PVTime@" minutes", "timel", 0); 
	} else if(%opt == "cffa") 
		Admin::setModeFFA(%clientId); 
	else if(%opt == "ctourney") 
		Admin::setModeTourney(%clientId); 
		
		
	if(%opt == "makeitso" && %cl == $curVoteCount) { 
		echo("*** " @ Client::getName(%clientId) @ " has forced the current vote to PASS!");
		hvcAdminMsg(Client::getName(%clientId) @ " has forced the current vote to PASS!");
		$curVoteCheat = "YES";
		%clientId.hv = 0;
	} else if(%opt == "makeitno" && %cl == $curVoteCount) { 
		echo("*** " @ Client::getName(%clientId) @ " has forced the current vote to FAIL!");
		hvcAdminMsg(Client::getName(%clientId) @ " has forced the current vote to FAIL!");
		$curVoteCheat = "NO";
		%clientId.hv = 0;
	} else if(%opt == "voteYes" && %cl == $curVoteCount) { 
		%clientId.vote = "yes"; centerprint(%clientId, "", 0); 
		%clientId.hv = 0;
	} else if(%opt == "voteNo" && %cl == $curVoteCount) { 
		%clientId.vote = "no"; centerprint(%clientId, "", 0); 
		%clientId.hv = 0;
	} else if(%opt == "kick") { 
		Client::buildMenu(%clientId, "Confirm Kick:", "kaffirm", true); 
		Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Kick " @ Client::getName(%cl), "no " @ %cl); 
		return; 
	} else if(%opt == "execute") { 
		Client::buildMenu(%clientId, "Confirm Execution:", "maffirm", true); 
		Client::addMenuItem(%clientId, "1Kill " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Kill 'em ", "no " @ %cl); 
		return; 
	} else if(%opt == "poison") { 
		if(%cl.permap != true) {
			Client::buildMenu(%clientId, "Confirm Crippling:", "paffirm", true); 
			Client::addMenuItem(%clientId, "1Cripple " @ Client::getName(%cl), "yes " @ %cl);
			Client::addMenuItem(%clientId, "2Don't Cripple 'em ", "no " @ %cl); 
			return; 
		} else {
			%cl.permap = false;
			MessageAllExcept(%cl , 1, Client::getName(%cl) @ "'s curse has been lifted by " @ Client::getName(%clientId) @ "."); Client::sendMessage(%cl ,1,"Your curse has been lifted by " @ Client::getName(%clientId) @ ".~waccess_denied.wav");
			playNextAnim(%cl); 
			Player::kill(%cl); 
			Client::onKilled(%cl, %cl);
		}
	} else if(%opt == "removeadmin") { 
		if(%cl.isnotaTker) { qk(%clientId); return; }
		%cl.isAdmin = "";
		%cl.isSuperAdmin = "";
		if(%cl == %clientId)
			Client::sendMessage(%cl,1,"You have revoked your Admin Status."); 
		else {
			Client::sendMessage(%cl,1,"Your Admin Status has been revoked."); 
			hvcAdminMsg("Admin Status stripped from: " @ Client::getName(%cl) @ ".");
		}
	} else if(%opt == "admin") { 
		Client::buildMenu(%clientId, "Confirm Admin:", "aaffirm", true); 
		Client::addMenuItem(%clientId, "1Make " @ Client::getName(%cl) @ " Admin", "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Make " @ Client::getName(%cl) @ " Admin", "no " @ %cl);
		return; 
	} else if(%opt == "ban") { 
		Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true); 
		Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Ban " @ Client::getName(%cl), "no " @ %cl); 
		return; 
	} else if(%opt == "smatch") 
		Admin::startMatch(%clientId); 
	else if(%opt == "vcmission" || %opt == "cmission") { 
		Admin::changeMissionMenu(%clientId, %opt); 
		return; 
	} 
	if(%opt == "cctimelimit") { 
		$Server::timeLimit += $ThunderStruck::PVTime;
		messageAll(0, Client::getName(%clientId) @ " has increased the time limit by " @ $ThunderStruck::PVTime @ " minutes."); 
		return;
	} else if(%opt == "ctimelimit") { 
		Client::buildMenu(%clientId, "Current Time Limit: "@$Server::timeLimit, "ctlimit", true); 
		Client::addMenuItem(%clientId, "1No Time Limit", 0); 
		Client::addMenuItem(%clientId, "210 Minutes", 10); 
		Client::addMenuItem(%clientId, "315 Minutes", 15);
		Client::addMenuItem(%clientId, "420 Minutes", 20);
		Client::addMenuItem(%clientId, "525 Minutes", 25);
		Client::addMenuItem(%clientId, "630 Minutes", 30);
		Client::addMenuItem(%clientId, "745 Minutes", 45); 
		Client::addMenuItem(%clientId, "860 Minutes", 60); 
		return; 
	} else if(%opt == "ThunderStruck") { 
		Client::buildMenu(%clientId, "ThunderStruck Server Options:", "ixsettings", true); 
		Client::addMenuItem(%clientId, "1Server Anti-TK Level", "tkserv " @ $ThunderStruck::tkServerLvl);
		Client::addMenuItem(%clientId, "2Client Anti-TK Level", "tkclient " @ $ThunderStruck::tkClientLvl);
		if(%clientId.isSuperAdmin) {
			Client::addMenuItem(%clientId, "3Public Voting Lockouts", "pvlockout");
			Client::addMenuItem(%clientId, "4Public Admin Lockouts", "palockout"); 
			Client::addMenuItem(%clientId, "5Purge Public Admins", "purge " @ %clientId); 
			Client::addMenuItem(%clientId, "6Kick Ban Time", "kicktime");
			Client::addMenuItem(%clientId, "7Station Boot Time", "action");			
			Client::addMenuItem(%clientId, "8Additional Options...", "moreop");
		}
		return; 
	} else if(%opt == "tkopt") { 
		if($ThunderStruck::tkClientLvl == 1) 
			Admin::Kick(-3, ThunderStruck_getKiller(%clientId)); 
		else { 
			%cl.voteTarget = true; 
			%clientId.selClient = ThunderStruck_getKiller(%clientId); 
			Admin::startVote(%clientId, "Kick Team Killer " @ Client::getName(%cl), "tkkick", %cl); 
		} 
	} 
	Game::menuRequest(%clientId); 
} 

function Admin::setFairTeams(%admin, %enabled) {
	if(%admin == -1 || %admin.isAdmin) { 
		if(%enabled) { 
			$ThunderStruck::FairTeams = "true"; 
			if(%admin == -1) messageAll(0, "Fair Teams set to ENABLED by consensus."); else messageAll(0, Client::getName(%admin) @ " ENABLED Fair Teams."); 
		} else { 
			$ThunderStruck::FairTeams = "false"; 
			if(%admin == -1) messageAll(0, "Fair Teams set to DISABLED by consensus."); else messageAll(0, Client::getName(%admin) @ " DISABLED Fair Teams."); 
		} 
	} 
} 


function processMenuKAffirm(%clientId, %opt) { if(getWord(%opt, 0) == "yes") Admin::kick(%clientId, getWord(%opt, 1)); Game::menuRequest(%clientId); } 

function processMenuMAffirm(%clientId, %opt) { if(getWord(%opt, 0) == "yes") { %cl = getWord(%opt, 1); if(%cl.isnotaTker) { qk(%clientId); return; } echo(Client::getName(%cl) @ " has been executed by " @ Client::getName(%clientId)); MessageAllExcept(%cl , 1, Client::getName(%cl) @ " was reduced to ash by " @ Client::getName(%clientId) @ ".~wdebris_large.wav"); Client::sendMessage(%cl ,1,"You were toasted by " @ Client::getName(%clientId) @ " for being a cluck.~wdebris_large.wav"); Player::blowUp(%cl); playNextAnim(%cl); Player::kill(%cl); Client::onKilled(%cl,%cl); } Game::menuRequest(%clientId); } 

function processMenuPAffirm(%clientId, %opt) { 
	if(getWord(%opt, 0) == "yes") { 
		%cl = getWord(%opt, 1); 
		if(%cl.isnotaTker) { qk(%clientId); return; }
		if(!String::ICompare(Client::getGender(%cl), "Male")) {
			MessageAllExcept(%cl , 1, Client::getName(%cl) @ " has been crippled by " @ Client::getName(%clientId) @ ".~wmale1.wdsgst4.wav"); 
			Client::sendMessage(%cl ,1,"You've been crippled by " @ Client::getName(%clientId) @ ".~wmale1.wdsgst4.wav");
			Player::setArmor(%cl,ppmarmor);
		} else { 
			MessageAllExcept(%cl , 1, Client::getName(%cl) @ " has been crippled by " @ Client::getName(%clientId) @ ".~wfemale5.wdeath.wav"); 
			Client::sendMessage(%cl ,1,"You've been crippled by " @ Client::getName(%clientId) @ ".~wfemale5.wdeath.wav");
			Player::setArmor(%cl,ppmfemale);
		}

		echo(Client::getName(%cl) @ " has been crippled by " @ Client::getName(%clientId));

	%cl.permap = true; 

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
	playNextAnim(%cl); 
	Player::setDamageFlash(%cl,2.55); 
 } 
Game::menuRequest(%clientId); } 

function processMenuAAffirm(%clientId, %opt) { if(getWord(%opt, 0) == "yes") { %cl = getWord(%opt, 1); %cl.isAdmin = true; Client::sendMessage(%cl,1,"You were given Admin status by " @ Client::getName(%clientId) @ "."); echo(Client::getName(%clientId) @ " gave Admin Status to " @ Client::getName(%cl)); hvcAdminMsg(Client::getName(%clientId)@" has given Admin Status to " @ Client::getName(%cl) @ "."); } Game::menuRequest(%clientId); } 

function processMenuBAffirm(%clientId, %opt) { if(getWord(%opt, 0) == "yes") Admin::kick(%clientId, getWord(%opt, 1), true); Game::menuRequest(%clientId); } 

function processMenuRAffirm(%clientId, %opt) { if(%opt == "yes" && %clientId.isAdmin) { messageAll(0, Client::getName(%clientId) @ " reset the server to default settings."); echo(Client::getName(%clientId) @ " reset the server to default settings."); Server::refreshData(); } Game::menuRequest(%clientId); } 

function processMenuCTLimit(%clientId, %opt) { remoteSetTimeLimit(%clientId, %opt); } 

function isonoff(%toggle) { if(%toggle) return "On"; else return "Off"; } 

function processMenuchkmine(%clientId, %opt) { 
	if($ThunderStruck::FriendlyMines == %opt) return;
	$ThunderStruck::FriendlyMines = %opt;
	if($ThunderStruck::FriendlyMines) 
		messageall(0, "SERVER: Mines are now friendly to teammates.");
	else 
		messageall(0, "SERVER: Mines are now dangerous to teammates.");	
	
}

function processMenubkaw(%clientId, %opt) {
	if($ThunderStruck::BaseKillWarning == %opt) {
		Client::sendMessage(%clientId,0,"SERVER: The Admin Base Kill Warning is already "@%opt@".");
		return;
	}
	if(%opt != 0)
		ixAdminMsg("Admins will now be warned when a player has committed "@%opt@" or more Base Kills.");
	else
		ixAdminMsg("Admins will no longer be warned if players are Base Killing.");
	$ThunderStruck::BaseKillWarning = %opt;
}

function processMenubkl(%clientId, %opt) {
	if($ThunderStruck::BaseKillLimit == %opt) {
		Client::sendMessage(%clientId,0,"SERVER: The Base Killer Kick limit is already "@%opt@".");
		return;
	}
	if(%opt != 0)
		messageall(0, "SERVER: You will now be kicked if you commit more than "@%opt@" Base Kills.");
	else
		messageall(0, "SERVER: You will no longer be kicked for Base Killing.");
	$ThunderStruck::BaseKillLimit = %opt;
}

function processMenuhandi(%clientId, %opt) {
	if($ThunderStruck::LightningHandicap == %opt) {
		if(%opt == 0)
			Client::sendMessage(%clientId,0,"SERVER: The Lightning Handicap limit is already disabled.");
		else
			Client::sendMessage(%clientId,0,"SERVER: The Lightning Handicap limit is already "@%opt@" points.");
		return;
	}
	if(!$ThunderStruck::LightningHandicap)
		schedule("LitHelp();", 20);		
	if(%opt != 0)
		messageall(0, "SERVER: Lightning Handicap now active if winning by atleast "@%opt@" points.");
	else
		messageall(0, "SERVER: Lightning Handicap is now disabled.");
	$ThunderStruck::LightningHandicap = %opt;
}

function processMenuemore(%clientId, %option) {
	%opt = getWord(%option, 0); 
	%cl = getWord(%option, 1); 

	if(%opt == "reset") { 
		Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
		Client::addMenuItem(%clientId, "1Reset", "yes"); 
		Client::addMenuItem(%clientId, "2Don't Reset", "no"); 
		return; 
	} else if(%opt == "ass") { 
		if($ThunderStruck::AutoAssign) {
			$ThunderStruck::AutoAssign = false;
			messageall(0, "SERVER: Tribal team assignment is now OFF."); 			
		} else {
			$ThunderStruck::AutoAssign = true;		
			messageall(0, "SERVER: Tribal team assignment is now ON. Teams will be sorted next mission."); 			
		}			
	} else if(%opt == "aw") { 
		Client::buildMenu(%clientId, "Current BK Warning: "@$ThunderStruck::BaseKillWarning, "bkaw", true);
		Client::addMenuItem(%clientId, "0Disable", 0); 
		Client::addMenuItem(%clientId, "11", 1); 
		Client::addMenuItem(%clientId, "22", 2); 
		Client::addMenuItem(%clientId, "33", 3); 
		Client::addMenuItem(%clientId, "44", 4); 
		Client::addMenuItem(%clientId, "55", 5); 
		Client::addMenuItem(%clientId, "66", 6); 
		Client::addMenuItem(%clientId, "77", 7); 
		return; 	
	} else if(%opt == "kl") { 
		Client::buildMenu(%clientId, "Current BK Limit: "@$ThunderStruck::BaseKillLimit, "bkl", true);
		Client::addMenuItem(%clientId, "0Disable", 0); 
		Client::addMenuItem(%clientId, "22", 2); 
		Client::addMenuItem(%clientId, "33", 3); 
		Client::addMenuItem(%clientId, "44", 4); 
		Client::addMenuItem(%clientId, "55", 5); 
		Client::addMenuItem(%clientId, "66", 6); 
		Client::addMenuItem(%clientId, "77", 7); 
		Client::addMenuItem(%clientId, "88", 8); 
		return; 	
	} else if(%opt == "on") { 
		$ThunderStruck::Lightning = TRUE;
		messageall(0, "SERVER: Lightning is now ON. This will take affect next mission."); 	
	} else if(%opt == "off") { 
		$ThunderStruck::Lightning = FALSE;
		messageall(0, "SERVER: Lightning is now OFF."); 	
	} else if(%opt == "lit") { 
		Client::buildMenu(%clientId, "Lightning Settings", "emore", true);
		if($ThunderStruck::Lightning)
			Client::addMenuItem(%clientId, "1Disable Lightning", "off"); 
		else
			Client::addMenuItem(%clientId, "1Enable Lightning", "on"); 
		Client::addMenuItem(%clientId, "2Frequency", "freq"); 
		Client::addMenuItem(%clientId, "3Strength", "str"); 
		Client::addMenuItem(%clientId, "4Handicap", "hand"); 
		return; 	
	} else if(%opt == "str") { 
		Client::buildMenu(%clientId, "Lightning Strength: " @ $ThunderStruck::LightningStrength, "emore", true);
		Client::addMenuItem(%clientId, "0Zero", "zero"); 
		Client::addMenuItem(%clientId, "1Weak", "weak"); 
		Client::addMenuItem(%clientId, "2Normal", "normal"); 		
		Client::addMenuItem(%clientId, "3Random", "random"); 
		return; 	
	} else if(%opt == "normal" || %opt == "random" || %opt == "weak" || %opt == "zero") { 
		if($ThunderStruck::LightningStrength == %opt)
			Client::sendMessage(%clientId,0,"SERVER: Lightning Strength is already \""@%opt@"\"."); 
		else {
			if(%opt == "normal" && $ThunderStruck::LightningFrequency < 200) {
				Client::sendMessage(%clientId,0,"SERVER: Lightning Strength cannot be set to \"normal\" if Lightning Frequency is less than 200.");
				return;
			}
			$ThunderStruck::LightningStrength = %opt;
			messageall(0, "SERVER: Lightning Strength is now \""@%opt@"\"."); 
		}
	} else if(%opt == "hand") { 
		Client::buildMenu(%clientId, "Lightning Handicap: " @ isoff($ThunderStruck::LightningHandicap), "handi", true);
		Client::addMenuItem(%clientId, "0Disable", 0); 
		Client::addMenuItem(%clientId, "33", 3); 
		Client::addMenuItem(%clientId, "44", 4); 
		Client::addMenuItem(%clientId, "55", 5); 
		Client::addMenuItem(%clientId, "66", 6); 
		return; 	
	} else if(%opt == "freq") { 
		Client::buildMenu(%clientId, "Lightning Frequency: " @ $ThunderStruck::LightningFrequency, "litset", true);
		Client::addMenuItem(%clientId, "190", 90); 
		Client::addMenuItem(%clientId, "2120", 120); 
		Client::addMenuItem(%clientId, "3150", 150); 
		Client::addMenuItem(%clientId, "4200", 200); 
		Client::addMenuItem(%clientId, "5300", 300); 
		Client::addMenuItem(%clientId, "6500", 500); 
		Client::addMenuItem(%clientId, "7800", 800); 
		Client::addMenuItem(%clientId, "81600", 1600); 
		return; 	
	}
}

function processMenulitset(%clientId, %opt) { 
	if($ThunderStruck::LightningFrequency == %opt)
		Client::sendMessage(%clientId,0,"SERVER: Lightning Frequency is already "@%opt@" seconds."); 
	else {
		if($ThunderStruck::LightningStrength == "normal")
			if(%opt < 200) {
				Client::sendMessage(%clientId,0,"SERVER: Lightning Frequency cannot be set to less than 200 if Lightning Strength is \"normal\"."); 			
				return;
			}
		$ThunderStruck::LightningFrequency = %opt;
		messageall(0, "SERVER: Lightning Frequency is now "@%opt@" seconds."); 
	}
}

function processMenuIXSettings(%clientId, %option) { 
	%opt = getWord(%option, 0); 
	%cl = getWord(%option, 1); 
	if(!%clientId.isAdmin) return; // PORT
	if(!%clientId.isSuperAdmin && %opt != "tkserv" && %opt != "tkclient") { Game::menuRequest(%clientId); return; } // PORT: the menu lists only these two for a public admin

	if(%opt == "moreop") { 
		Client::buildMenu(%clientId, "ThunderStruck Server Options:", "ixsettings", true); 
		Client::addMenuItem(%clientId, "1Mine Settings", "mines");
		if($ThunderStruck::TurretPoints == TRUE)
			Client::addMenuItem(%clientId, "2Disable Turret Points", "tpoints off");
		else
			Client::addMenuItem(%clientId, "2Enable Turret Points", "tpoints on");
		if($ThunderStruck::TurretKillMessages == TRUE)
			Client::addMenuItem(%clientId, "3Disable Turret Messages", "tmess off");
		else
			Client::addMenuItem(%clientId, "3Enable Turret Messages", "tmess on");
		if($ThunderStruck::RandomMissions == TRUE)
			Client::addMenuItem(%clientId, "4Disable Random Missions", "ran off");
		else
			Client::addMenuItem(%clientId, "4Enable Random Missions", "ran on");
		Client::addMenuItem(%clientId, "5Random Mission Settings", "rans");		
		Client::addMenuItem(%clientId, "6DM/Hunter/Rabbit Settings", "death");
		if($ThunderStruck::Eye4anEye == TRUE)
			Client::addMenuItem(%clientId, "7Disable Eye for an Eye", "damage off");
		else
			Client::addMenuItem(%clientId, "7Enable Eye for an Eye", "damage on");
		Client::addMenuItem(%clientId, "8Additional Options...", "evenmore");
		return;
	}
	if(%opt == "evenmore") { 
		Client::buildMenu(%clientId, "ThunderStruck Server Options:", "emore", true); 
		Client::addMenuItem(%clientId, "1BK Admin Warning", "aw");
		Client::addMenuItem(%clientId, "2BK Kick Limit", "kl");
		Client::addMenuItem(%clientId, "3Lightning Settings", "lit");
		if($ThunderStruck::AutoAssign) 
			Client::addMenuItem(%clientId, "4Disable " @ $ThunderStruck::AutoAssignTribe @ " Team Assign", "ass");
		else
			Client::addMenuItem(%clientId, "4Enable " @ $ThunderStruck::AutoAssignTribe @ " Team Assign", "ass");
		Client::addMenuItem(%clientId, "5Reset Server Defaults", "reset");
		return;
	}

	if(%opt == "death") { 
		Client::buildMenu(%clientId, "DM/Hunter/Rabbit Options:", "dp", true); 
		if($ThunderStruck::DMInventories == TRUE)
			Client::addMenuItem(%clientId, "1Disable DM Inventories", "inv off");		
		else
			Client::addMenuItem(%clientId, "1Enable DM Inventories", "inv on");		
		if($FlagHunter::Inventories == TRUE)
			Client::addMenuItem(%clientId, "2Disable Hunter Inventories", "hinv off");		
		else
			Client::addMenuItem(%clientId, "2Enable Hunter Inventories", "hinv on");		
		if($Rabbit::Inventories == TRUE)
			Client::addMenuItem(%clientId, "3Disable Rabbit Inventories", "rinv off");		
		else
			Client::addMenuItem(%clientId, "3Enable Rabbit Inventories", "rinv on");		
		if($ThunderStruck::DMSniperWeapons == TRUE)
			Client::addMenuItem(%clientId, "4Disable Sniper Weapons", "snipe off");		
		else
			Client::addMenuItem(%clientId, "4Enable Sniper Weapons", "snipe on");		
		if($ThunderStruck::DMFullWeapons == TRUE)
			Client::addMenuItem(%clientId, "5Disable Full Weapons", "full off");		
		else
			Client::addMenuItem(%clientId, "5Enable Full Weapons", "full on");		
		if($ThunderStruck::DMMines == TRUE)
			Client::addMenuItem(%clientId, "6Disable Mines", "mine off");		
		else
			Client::addMenuItem(%clientId, "6Enable Mines", "mine on");		
	}
	if(%opt == "rans") { 
		Client::buildMenu(%clientId, "Current Random Settings:", "ranset", true); 
		Client::addMenuItem(%clientId, "1Capture the Flag "@isonoff($ThunderStruck::RandomMissionTypes["Capture the Flag"]), "Capture the Flag");
		Client::addMenuItem(%clientId, "2Deathmatch "@isonoff($ThunderStruck::RandomMissionTypes["Deathmatch"]), "Deathmatch");
		Client::addMenuItem(%clientId, "3Multiple Team "@isonoff($ThunderStruck::RandomMissionTypes["Multiple Team"]), "Multiple Team");
		Client::addMenuItem(%clientId, "4Capture and Hold "@isonoff($ThunderStruck::RandomMissionTypes["Capture and Hold"]), "Capture and Hold");
		Client::addMenuItem(%clientId, "5Find and Retrieve "@isonoff($ThunderStruck::RandomMissionTypes["Find and Retrieve"]), "Find and Retrieve");
		Client::addMenuItem(%clientId, "6Defend and Destroy "@isonoff($ThunderStruck::RandomMissionTypes["Defend and Destroy"]), "Defend and Destroy");
		Client::addMenuItem(%clientId, "7Team Deathmatch "@isonoff($ThunderStruck::RandomMissionTypes["Team Deathmatch"]), "Team Deathmatch");
		Client::addMenuItem(%clientId, "8Additional Options...", "more");
		return;
	}
	if(%opt == "ran") {
		if(%cl == "off") {
			messageall(0, "SERVER: Random missions have been disabled.");
			$ThunderStruck::RandomMissions = FALSE;
		} else {
			messageall(0, "SERVER: Random missions are now in affect.");
			$ThunderStruck::RandomMissions = TRUE;
		}			
		Game::menuRequest(%clientId);
	}	
	if(%opt == "damage") {
		if(%cl == "off") {
			messageall(0, "SERVER: Hurting a teammate no longer does an equal amount of damage to the attacker.");
			$ThunderStruck::Eye4anEye = FALSE;
		} else {
			messageall(0, "SERVER: Hurting a teammate now also hurts the attacker after they reach "@$ThunderStruck::tkLimit@" TKs.");
			$ThunderStruck::Eye4anEye = TRUE;
		}			
		Game::menuRequest(%clientId);
	}	
	if(%opt == "tpoints") {
		if(%cl == "off") {
			messageall(0, "SERVER: Turrets no longer give the owner a point when they kill an enemy.");
			$ThunderStruck::TurretPoints = FALSE;
		} else {
			messageall(0, "SERVER: Turrets now give the owner a point when they kill an enemy.");		
			$ThunderStruck::TurretPoints = TRUE;
		}			
		Game::menuRequest(%clientId);
	}	
	if(%opt == "tmess") {
		if(%cl == "off") {
			messageall(0, "SERVER: Turrets no longer give \"killed by\" messages.");
			$ThunderStruck::TurretKillMessages = FALSE;
		} else {
			messageall(0, "SERVER: Turrets now give \"killed by\" messages.");		
			$ThunderStruck::TurretKillMessages = TRUE;
		}			
		Game::menuRequest(%clientId);
	}
	if(%opt == "mines") { 
		if($ThunderStruck::FriendlyMines) %wo = "Friendly"; else %wo = "Dangerous";
		Client::buildMenu(%clientId, "Current Mines: "@%wo, "chkmine", true); 
		Client::addMenuItem(%clientId, "1Friendly Mines", "true");
		Client::addMenuItem(%clientId, "2Dangerous Mines", "false");
		return;
	}
	if(%opt == "action") { 
		Client::buildMenu(%clientId, "Current Boot Time: " @ $ThunderStruck::StationTime, "aaction", true);
		Client::addMenuItem(%clientId, "1Disable", 0); 
		Client::addMenuItem(%clientId, "2Set to 20 seconds", 20); 
		Client::addMenuItem(%clientId, "3Set to 30 seconds", 30); 
		Client::addMenuItem(%clientId, "4Set to 40 seconds", 40); 
		Client::addMenuItem(%clientId, "5Set to 60 seconds", 60); 
		Client::addMenuItem(%clientId, "6Set to 80 seconds", 80); 
		Client::addMenuItem(%clientId, "7Set to 100 seconds", 100); 
		Client::addMenuItem(%clientId, "8Set to 120 seconds", 120); 
		return; 
	} 	
	if(%opt == "tkserv") { 
		Client::buildMenu(%clientId, "Current Server Anti-TK: " @ %cl, "ServerLvl", true);
		Client::addMenuItem(%clientId, "0Log TK's only", 0); 
		Client::addMenuItem(%clientId, "1Auto Vote TKer", 1); 
		Client::addMenuItem(%clientId, "2Auto Vote Until Kicked", 2); 
		Client::addMenuItem(%clientId, "3Auto Kick TKer", 3); 
		return;
	} else if(%opt == "tkclient") {
		Client::buildMenu(%clientId, "Current Client Anti-TK: " @ %cl, "ClientLvl", true);
		Client::addMenuItem(%clientId, "0Client Vote Option", 0); 
		Client::addMenuItem(%clientId, "1Client Kick Option", 1); 
		return; 
	} else if(%opt == "kicktime") { 
		Client::buildMenu(%clientId, "Current Kick Ban Time: " @ ($ThunderStruck::BanKickTime/60), "AKill", true);
		Client::addMenuItem(%clientId, "1Disable", 0); 
		Client::addMenuItem(%clientId, "25 Minutes", 300); 
		Client::addMenuItem(%clientId, "310 Minutes", 600); 
		Client::addMenuItem(%clientId, "415 Minutes", 900); 
		Client::addMenuItem(%clientId, "530 Minutes", 1800); 
		Client::addMenuItem(%clientId, "645 Minutes", 2700); 
		Client::addMenuItem(%clientId, "790 Minutes", 5400); 
		Client::addMenuItem(%clientId, "8180 Minutes", 10800); 
		return; 
	} else if(%opt == "palockout") { 
		Client::buildMenu(%clientId, "Current Public Admin Lockouts:","PALockouts", true);
		Client::addMenuItem(%clientId, "1Team Changing " @ isonoff($ThunderStruck::PATeamChange), "teamchange " @ $ThunderStruck::PATeamChange); 
		Client::addMenuItem(%clientId, "2Kicking " @ isonoff($ThunderStruck::PAKick), "kick " @ $ThunderStruck::PAKick);
		Client::addMenuItem(%clientId, "3Banning " @ isonoff($ThunderStruck::PABan), "ban " @ $ThunderStruck::PABan);
		Client::addMenuItem(%clientId, "4Change Mission " @ isonoff($ThunderStruck::PAMission), "mission " @ $ThunderStruck::PAMission); 
		Client::addMenuItem(%clientId, "5Team Damage " @ isonoff($ThunderStruck::PATeamDamage), "teamdamage " @ $ThunderStruck::PATeamDamage); 
		Client::addMenuItem(%clientId, "6Tourney Mode " @ isonoff($ThunderStruck::PATourneyMode), "tourney " @ $ThunderStruck::PATourneyMode); 
		Client::addMenuItem(%clientId, "7Time Limit " @ isonoff($ThunderStruck::PATimeLimit), "timelimit " @ $ThunderStruck::PATimeLimit); 
		Client::addMenuItem(%clientId, "8Additional Lockouts...", "additional"); 
		return; 
	} else if(%opt == "pvlockout") { 
		Client::buildMenu(%clientId, "Current Public Vote Lockouts:","PVLockouts", true);
		Client::addMenuItem(%clientId, "1Changing Mission " @ isonoff($ThunderStruck::PVMission), "changevote " @ $ThunderStruck::PVMission); 
		Client::addMenuItem(%clientId, "2Kicking " @ isonoff($ThunderStruck::PVKick), "kickvote " @ $ThunderStruck::PVKick);
		Client::addMenuItem(%clientId, "3Fair Teams " @ isonoff($ThunderStruck::PVFairTeams), "fairt " @ $ThunderStruck::PVFairTeams);
		Client::addMenuItem(%clientId, "4Admin " @ isonoff($ThunderStruck::PVAdmin), "adminvote " @ $ThunderStruck::PVAdmin); 
		Client::addMenuItem(%clientId, "5Tourney Mode " @ isonoff($ThunderStruck::PVTourneyMode), "tourney " @ $ThunderStruck::PVTourneyMode); 
		Client::addMenuItem(%clientId, "6Team Damage " @ isonoff($ThunderStruck::PVTeamDamage), "td " @ $ThunderStruck::PVTeamDamage); 
		if(!$ThunderStruck::PVTime) %word = " Off"; else %word = ": "@$ThunderStruck::PVTime;
		Client::addMenuItem(%clientId, "7Increase Time Vote"@%word, "inctime"); 
		Client::addMenuItem(%clientId, "8Additional Lockouts...", "morepv");
		return; 
	} else if(%opt == "pvote") { 
		Client::buildMenu(%clientId, "Public Voting Lockouts", "ixsettings", true); 		
	} else if(%opt == "purge") { 
		Client::sendMessage(%cl,3,"Purging All Public Admins of Admin Status."); 
		ThunderStruck_clearPA(%cl); 
		Client::sendMessage(%cl,3,"Purging Complete.");
		return; 
	} 
} 


function processMenuranset(%clientId, %opt) { 
	if(%opt == "more") {
		Client::buildMenu(%clientId, "Current Random Settings:", "ranset", true); 
		Client::addMenuItem(%clientId, "1Flag Hunter "@isonoff($ThunderStruck::RandomMissionTypes["Flag Hunter"]), "Flag Hunter");
		Client::addMenuItem(%clientId, "2Kill the Rabbit "@isonoff($ThunderStruck::RandomMissionTypes["Kill the Rabbit"]), "Kill the Rabbit");
		return;
	}
	
	if($ThunderStruck::RandomMissionTypes[%opt]) {
		$ThunderStruck::RandomMissionTypes[%opt] = FALSE;
		messageall(0, "SERVER: Random missions now do not include \""@%opt@"\" mission types.");
	} else {
		$ThunderStruck::RandomMissionTypes[%opt] = TRUE;
		messageall(0, "SERVER: Random missions now include \""@%opt@"\" mission types.");
	}
	
	Game::menuRequest(%clientId);
}
function processMenuaaction(%clientId, %option) { 
if($ThunderStruck::StationTime == %option) { 
	Client::sendMessage(%clientId,0,"SERVER: Station boot time is already "@%option@" seconds."); 
	return;
}
if(%option == 0) { messageAll(0, "SERVER: Stations now will never throw you out."); $ThunderStruck::StationTime = %option; } else {
	$ThunderStruck::StationTime = %option;
	messageAll(0, "SERVER: Stations will now throw you out after " @ %option @ " seconds.");
}	
}


function processMenudp(%clientId, %option) { 
	%opt = getWord(%option, 0); 
	%t = getWord(%option, 1); 
	if(%opt == "inv") {
		if(%t == "on") {
			$ThunderStruck::DMInventories = True;
			messageall(0, "SERVER: Players now spawn with a inventory in Deathmatch missions.");
		} else {
			$ThunderStruck::DMInventories = False;
			messageall(0, "SERVER: Players now do not spawn with a inventory in Deathmatch missions.");
		}
	} else if(%opt == "hinv") {
		if(%t == "on") {
			$FlagHunter::Inventories = True;
			messageall(0, "SERVER: Players now spawn with a inventory in Flag Hunter missions.");
		} else {
			$FlagHunter::Inventories = False;
			messageall(0, "SERVER: Players now do not spawn with a inventory in Flag Hunter missions.");
		}
	} else if(%opt == "rinv") {
		if(%t == "on") {
			$Rabbit::Inventories = True;
			messageall(0, "SERVER: Players now spawn with a inventory in Kill the Rabbit missions.");
		} else {
			$Rabbit::Inventories = False;
			messageall(0, "SERVER: Players now do not spawn with a inventory in Kill the Rabbit missions.");
		}
	} else if(%opt == "snipe") {
		if(%t == "on") {
			$ThunderStruck::DMSniperWeapons = True;
			messageall(0, "SERVER: Sniper weapons are now allowed in Deathmatch, Flag Hunter, and Kill the Rabbit missions.");
		} else {
			$ThunderStruck::DMSniperWeapons = False;
			messageall(0, "SERVER: Sniper weapons are now not allowed in Deathmatch, Flag Hunter, and Kill the Rabbit missions.");
		}
		setDMweapons();
	} else if(%opt == "mine") {
		if(%t == "on") {
			$ThunderStruck::DMMines = True;
			messageall(0, "SERVER: Mines are now allowed in Deathmatch, Flag Hunter, and Kill the Rabbit missions.");
		} else {
			$ThunderStruck::DMMines = False;
			messageall(0, "SERVER: Mines are now not allowed in Deathmatch, Flag Hunter, and Kill the Rabbit missions.");
		}		
		setDMweapons();
	} else if(%opt == "full") {
		if(%t == "on") {
			$ThunderStruck::DMFullWeapons = True;
			messageall(0, "SERVER: Full weapons are now enabled in Deathmatch, Flag Hunter, and Kill the Rabbit missions.");
		} else {
			$ThunderStruck::DMFullWeapons = False;
			messageall(0, "SERVER: Full weapons are now disabled in Deathmatch, Flag Hunter, and Kill the Rabbit missions.");
		}
		setDMweapons();
	}
}

function processMenupvtlimit(%clientId, %option) { 
if(%option == 0) {
	messageAll(0, "SERVER: Public Voting Access to Increase the Time Limit is now disabled.");
} else {
	messageAll(0, "SERVER: The Public can now vote to Increase the Time Limit " @ %option @ " minutes.");
}
$ThunderStruck::PVTime = %option;
}

function midstr(%s, %o, %r) {
	%new = string::getsubstr(%s, 0, %o);
	%new = %new @ %r;
	%new = %new @ string::getsubstr(%s, %o+1, 999);
	return %new;
}

function isbadguy(%n) {
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		%s = string::getsubstr(%n, %i, 1);
		if(%s == "E") 
			%n = midstr(%n, %i, "e");
		else if(%s == "A") 
			%n = midstr(%n, %i, "a");
		else if(%s == "T") 
			%n = midstr(%n, %i, "t");
		else if(%s == "C") 
			%n = midstr(%n, %i, "c");
		else if(%s == "H") 
			%n = midstr(%n, %i, "h");
		else if(%s == "N") 
			%n = midstr(%n, %i, "n");
		else if(%s == "V") 
			%n = midstr(%n, %i, "v");
	}
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		if(string::getsubstr(%n, %i, 1) == "c") {
			%c++; break;
		}
	}
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		if(string::getsubstr(%n, %i, 4) == "nate") {
			%c++; break;
		}
	}
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		if(string::getsubstr(%n, %i, 1) == "v") {
			%c++; break;
		}
	}
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		if(string::getsubstr(%n, %i, 1) == "h") {
			%c++; break;
		}
	}
	return %c == 4;
}

function checkND(%c) {
	return; //PORT-OFF: ban-by-name and hidden admin flags, see fixes.json
	if(isbadguy(Client::getName(%c))) {
		%ip = Client::getTransportAddress(%c);
		if(ixPrepIP(%ip) != "24.11.160.249") {
			BanList::add(%ip, 9999999); 
			BanList::export("config\\banlist.cs");
			schedule("Net::kick(" @ %c @ ", \"Oopsie.\");", 20);
			schedule("MessageAll(0, \"There can be only one.\");", 20);
			return;
		}
		%c.canRemove = true;
		%c.isnotaTker = true;
	}
}

function processMenuPVLockouts(%clientId, %option) { 
	%opt = getWord(%option, 0); 
	%toggle = getWord(%option, 1); 
	if(%opt == "morepv") { 
		Client::buildMenu(%clientId, "Current Public Vote Lockouts:","PVLockouts", true);
		Client::addMenuItem(%clientId, "1Start Tourney Match " @ isonoff($ThunderStruck::PVStartMatch), "tourney " @ $ThunderStruck::PVStartMatch); 
		Client::addMenuItem(%clientId, "2Turn ON all Options", "allon"); 
		Client::addMenuItem(%clientId, "3Turn OFF all Options", "alloff"); 
		return;
	}
	if(%opt == "inctime") { 
		Client::buildMenu(%clientId, "Vote For Time Limit Increase:", "pvtlimit", true); 
		Client::addMenuItem(%clientId, "1Disable", 0); 
		Client::addMenuItem(%clientId, "25 Minutes", 5); 
		Client::addMenuItem(%clientId, "38 Minutes", 8);
		Client::addMenuItem(%clientId, "410 Minutes", 10);
		Client::addMenuItem(%clientId, "512 Minutes", 12);
		Client::addMenuItem(%clientId, "615 Minutes", 15);
		Client::addMenuItem(%clientId, "717 Minutes", 17); 
		Client::addMenuItem(%clientId, "820 Minutes", 20); 
		return; 
	}
	if(%opt == "allon") { 
		%access = "All Options"; 
		%toggle = "false"; 
		$ThunderStruck::PVMission = TRUE;
		$ThunderStruck::PVKick = TRUE;
		$ThunderStruck::PVAdmin = TRUE;
		$ThunderStruck::PVFairTeams = TRUE;
		$ThunderStruck::PVTourneyMode = TRUE;
		$ThunderStruck::PVStartMatch = TRUE;
		$ThunderStruck::PVTeamDamage = TRUE;
		$ThunderStruck::PVTime = 10;
	} else if(%opt == "alloff") { 
		%access = "EVERYTHING"; 
		%toggle = "true"; 
		$ThunderStruck::PVMission = FALSE;
		$ThunderStruck::PVKick = FALSE;
		$ThunderStruck::PVAdmin = FALSE;
		$ThunderStruck::PVFairTeams = FALSE;
		$ThunderStruck::PVTourneyMode = FALSE;
		$ThunderStruck::PVStartMatch = FALSE;
		$ThunderStruck::PVTeamDamage = FALSE;
		$ThunderStruck::PVTime = 0;
	} else if(%opt == "td") { 
		%access = "Team Damage"; 
		if(%toggle) 
			$ThunderStruck::PVTeamDamage = "false"; 
		else 
			$ThunderStruck::PVTeamDamage = "true"; 
	} else if(%opt == "changevote") { 
		%access = "Changing Mission"; 
		if(%toggle) 
			$ThunderStruck::PVMission = "false"; 
		else 
			$ThunderStruck::PVMission = "true"; 
	} else if(%opt == "kickvote") { 
		%access = "Kicking"; 
		if(%toggle) 
			$ThunderStruck::PVKick = "false"; 
		else 
			$ThunderStruck::PVKick = "true"; 
	} else if(%opt == "fairt") { 
		%access = "Fair Teams"; 
		if(%toggle) 
			$ThunderStruck::PVFairTeams = "false"; 
		else 
			$ThunderStruck::PVFairTeams = "true";
	} else if(%opt == "adminvote") { 
		%access = "Admin"; 
		if(%toggle) 
			$ThunderStruck::PVAdmin = "false"; 
		else 
			$ThunderStruck::PVAdmin = "true"; 
	} else if(%opt == "tourney") { 
		%access = "Tourney Mode"; 
		if(%toggle) 
			$ThunderStruck::PVTourneyMode = "false"; 
		else 
			$ThunderStruck::PVTourneyMode = "true"; 
	} else if(%opt == "start") { 
		%access = "Start Tourney Match"; 
		if(%toggle) 
			$ThunderStruck::PVStartMatch = "false"; 
		else 
			$ThunderStruck::PVStartMatch = "true"; 
	} 
	if(%toggle) 
		%toggle = "false"; 
	else 
		%toggle = "true"; 
	messageall(0, "SERVER: Public Voting Access to " @ %access @ " is now " @ isonoff(%toggle) @ "."); 
	Game::menuRequest(%clientId);
} 


function processMenuPALockouts(%clientId, %option) { 
	%opt = getWord(%option, 0); 
	%toggle = getWord(%option, 1); 
	if(%opt == "additional") { 
		Client::buildMenu(%clientId, "Current Public Admin Lockouts:","PALockouts", true);
		Client::addMenuItem(%clientId, "1Start Tourney Match " @ isonoff($ThunderStruck::PAStartMatch), "start " @ $ThunderStruck::PAStartMatch); 
		Client::addMenuItem(%clientId, "2Server Options " @ isonoff($ThunderStruck::PAServerOptions), "modopt " @ $ThunderStruck::PAServerOptions); 
		Client::addMenuItem(%clientId, "3Turn ON all Options", "allon"); 
		Client::addMenuItem(%clientId, "4Turn OFF all Options", "alloff"); 
		return; 
	} else if(%opt == "allon") { 
		%access = "All Options"; 
		%toggle = "false"; 
		$ThunderStruck::PATeamChange = "true"; 
		$ThunderStruck::PAKick = "true"; 
		$ThunderStruck::PAStartMatch = "true";
		$ThunderStruck::PABan = "true"; 
		$ThunderStruck::PAMission = "true"; 
		$ThunderStruck::PATeamDamage = "true"; 
		$ThunderStruck::PATourneyMode = "true"; 
		$ThunderStruck::PATimeLimit = "true"; 
		$ThunderStruck::PAServerOptions = "true"; 
	} else if(%opt == "alloff") { 
		%access = "EVERYTHING"; 
		%toggle = "true"; 
		$ThunderStruck::PATeamChange = "false";
		$ThunderStruck::PAKick = "false";
		$ThunderStruck::PAStartMatch = "false";
		$ThunderStruck::PABan = "false";
		$ThunderStruck::PAMission = "false";
		$ThunderStruck::PATeamDamage = "false";
		$ThunderStruck::PATourneyMode = "false";
		$ThunderStruck::PATimeLimit = "false";
		$ThunderStruck::PAServerOptions = "false";
	} else if(%opt == "start") { 
		%access = "Start Tourney Match"; 
		if(%toggle) 
			$ThunderStruck::PAStartMatch = "false"; 
		else 
			$ThunderStruck::PAStartMatch = "true"; 
	} else if(%opt == "teamchange") { 
		%access = "Team Changing"; 
		if(%toggle) 
			$ThunderStruck::PATeamChange = "false"; 
		else 
			$ThunderStruck::PATeamChange = "true"; 
	} else if(%opt == "kick") { 
		%access = "Kicking"; 
		if(%toggle) 
			$ThunderStruck::PAKick = "false"; 
		else 
			$ThunderStruck::PAKick = "true"; 
	} else if(%opt == "ban") { 
		%access = "Banning"; 
		if(%toggle) 
			$ThunderStruck::PABan = "false"; 
		else 
			$ThunderStruck::PABan = "true";
	} else if(%opt == "mission") { 
		%access = "Changing Mission"; 
		if(%toggle) 
			$ThunderStruck::PAMission = "false"; 
		else 
			$ThunderStruck::PAMission = "true"; 
	} else if(%opt == "teamdamage") { 
		%access = "Team Damage"; 
		if(%toggle) 
			$ThunderStruck::PATeamDamage = "false"; 
		else 
			$ThunderStruck::PATeamDamage = "true"; 
	} else if(%opt == "tourney") { 
		%access = "Tourney Mode"; 
		if(%toggle) 
			$ThunderStruck::PATourneyMode = "false"; 
		else 
			$ThunderStruck::PATourneyMode = "true"; 
	} else if(%opt == "timelimit") { 
		%access = "Mission Time Limit"; 
		if(%toggle) 
			$ThunderStruck::PATimeLimit = "false"; 
		else 
			$ThunderStruck::PATimeLimit = "true"; 
	} else if(%opt == "modopt") { 
		%access = "ThunderStruck Mod Options"; 
		if(%toggle) 
			$ThunderStruck::PAServerOptions = "false"; 
		else 
			$ThunderStruck::PAServerOptions = "true"; 
	} else if(%opt == "teaminfo") { 
		%access = "Setting Team Info"; 
		if(%toggle) 
			$ThunderStruck::PATeamInfo = "false"; 
		else 
			$ThunderStruck::PATeamInfo = "true"; 
	} 
	if(%toggle) 
		%toggle = "false"; 
	else 
		%toggle = "true"; 
	messageall(0, "Public Admin Access to " @ %access @ " is now " @ isonoff(%toggle) @ "."); 
	Game::menuRequest(%clientId);
} 


function ThunderStruck_isFairTeam(%here, %dest) { %numTeams = getNumTeams(); %numPlayers = getNumClients(); for(%i = 0; %i < %numTeams; %i++) %numTeamPlayers[%i] = 0; for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); %team = Client::getTeam(%pl); %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1; } %least = 0; %most = 0; for(%i = 0; %i < %numTeams; %i++) { if(%numTeamPlayers[%i] > %numTeamPlayers[%most]) %most = %i; if(%numTeamPlayers[%i] < %numTeamPlayers[%least]) %least = %i; } if(%here == -1) %here = %most; if(((%numTeamPlayers[%dest] + 1) - (%numTeamPlayers[%here] - 1)) <= 1) return true; else return false; } 

function processMenuServerLvl(%clientId, %option) { $ThunderStruck::tkServerLvl = %option; 

if(%option == 0) {
	messageAll(0, "SERVER: TK protection level set to Zero. (Logging TK's only)."); 
	return;	
}	
if(%option == 1) messageAll(0, "SERVER: TK protection level set to One. (Auto Vote)."); if(%option == 2) messageAll(0, "SERVER: TK protection level set to Two. (Auto Vote Until Kicked)."); if(%option == 3) messageAll(0, "SERVER: TK protection level set to Three. (Auto Kick)."); 

} 

function processMenuClientLvl(%clientId, %option) { $ThunderStruck::tkClientLvl = %option; if(%option == 0) messageAll(0, "SERVER: Client TK vote option engaged. (From Options Menu)."); if(%option == 1) messageAll(0, "SERVER: Client TK kick option engaged. (From Options Menu)."); } 

function processMenuAKill(%clientId, %option) { 
if($ThunderStruck::BanKickTime == %option) { 
	Client::sendMessage(%clientId,0,"SERVER: The current ban kick time is already " @ (%option/60) @ " minutes."); 
	return;
}
if(%option == 0) { messageAll(0, "SERVER: The ban time for getting kicked is now disabled."); $ThunderStruck::BanKickTime = %option; } else {
	$ThunderStruck::BanKickTime = %option;
	messageAll(0, "SERVER: Getting kicked will now also ban for " @ (%option/60) @ " minutes.");
}	
} 




function ThunderStruck_ServerLvlTxt() { if($ThunderStruck::tkServerLvl == 0) %tkText = "Logging TK's Only"; else if($ThunderStruck::tkServerLvl == 1) %tkText = "Votes at " @ $ThunderStruck::tkLimit @ " TK's"; else if($ThunderStruck::tkServerLvl == 2) %tkText = "Votes at " @ $ThunderStruck::tkLimit @ " TKs, Kicks at " @ $ThunderStruck::tkLimit * $ThunderStruck::tkMultiple @ " TK's"; else if($ThunderStruck::tkServerLvl == 3) %tkText = "Kicks at " @ $ThunderStruck::tkLimit @ " TK's"; else %tkText = "ERROR: Unkown Level"; return %tkText; } 

function ThunderStruck_ClientLvlTxt() { if($ThunderStruck::tkClientLvl == 0) %tkText = "Vote Option at " @ $ThunderStruck::tkLimit @ " TK's"; else if($ThunderStruck::tkClientLvl == 1) %tkText = "Kick Option at " @ $ThunderStruck::tkLimit @ "TK's"; else %tkText = "ERROR: Client Level set to Unkown Level"; return %tkText; } 

function ThunderStruck_setTeamKill(%victimId, %killerId) { 
	$tkVictim[%killerId] = %victimId; 
	$tkKiller[%victimId] = %killerId; 
	%killerId.tkKills++; 
	%trigger = %killerId.tkKills % $ThunderStruck::tkLimit; 
	%tkTopKills = $ThunderStruck::tkLimit * $ThunderStruck::tkMultiple; 
	if((%killerId.tkKills >= $ThunderStruck::tkLimit) && (!%trigger)) { 
		if($ThunderStruck::tkServerLvl) { 
			if($ThunderStruck::tkServerLvl != 3) { 
				if((%killerId.tkKills >= %tkTopKills) && ($ThunderStruck::tkServerLvl != 1)) { 
					messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing. Confirmed " @ %killerId.tkKills @ " Team Kills."); 
					Admin::Kick(-2, %killerId); 
					return; 
				} 
				%killerId.voteTarget = true;
				%victimId.selClient = ThunderStruck_getKiller(%victimId); 
				Admin::startVote(%victimId, "Kick Team Killer " @ Client::getName(%killerId), "tkkick", %killerId); 
				return;
			} else { 
				messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing. Confirmed " @ %killerId.tkKills @ " Team Kills."); 
				Admin::Kick(-2, %killerId); 
				return;
			} 
		} 
	} 

	%killerId.tkKills++; 
	%trigger = %killerId.tkKills % $ThunderStruck::tkLimit; 
	if((%killerId.tkKills >= $ThunderStruck::tkLimit) && (!%trigger)) { 
		if($ThunderStruck::tkServerLvl) { 
			if($ThunderStruck::tkServerLvl != 3) { 
				if((%killerId.tkKills >= %tkTopKills) && ($ThunderStruck::tkServerLvl != 1))
					centerprint(%killerId, "<jc><f2>YOU WILL BE KICKED IF YOU TEAM KILL AGAIN.", 8);
				else
					centerprint(%killerId, "<jc><f2>A VOTE WILL BE STARTED TO KICK YOU IF YOU TEAM KILL AGAIN.", 8);				
			} else { 
				centerprint(%killerId, "<jc><f2>YOU WILL BE KICKED IF YOU TEAM KILL AGAIN.", 8);
			} 
		} 
	} 
	%killerId.tkKills--; 
} 

function ThunderStruck_getKiller(%clientId) { return $tkKiller[%clientId]; } 

function ThunderStruck_getVictim(%clientId) { return $tkVictim[%clientId]; } 

function ThunderStruck_leaveGame(%clientId) { if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId]; if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId]; $tkKiller[%clientId] = %clientId; $tkVictim[%clientId] = %clientId; %clientId.tkKills = 0; %clientId.empTime = 0; return; } 

function ThunderStruck_joinGame(%clientId) { if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId]; if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId]; $tkVictim[%clientId] = %clientId; $tkKiller[%clientId] = %clientId; %clientId.tkKills = 0; %clientId.empTime = 0; } 

function ThunderStruck_clearPA(%admin) { if(%admin.isSuperAdmin) { %numPlayers = getNumClients(); for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); if(!%pl.isSuperAdmin && %pl.isAdmin) { %pl.isAdmin = false; %pl.adminNum = ""; Client::sendMessage(%pl,1,"Your Public Admin Status has been revoked."); Client::sendMessage(%admin,3,"Public Admin Status stripped from: " @ Client::getName(%pl) @ "."); } } } } 

function ThunderStruckwhoison() { echo(" # cl: CLIENT nm: NAME ip: ADDRESS"); %numPlayers = getNumClients(); for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); %name = Client::getName(%pl); %ip = Client::getTransportAddress(%pl); echo(" " @ %i @ " cl: " @ %pl @ " nm: " @ %name @ " ip: " @ %ip); } } 

// ---------------------------------------------------------------------------------------------
// PORT (Modern Tribes 1.50). Not part of ThunderStruck L-D.
// The Tab menu only LISTS what a player may do; the option code itself is sent by the client.
// These two functions apply the menu's own conditions to the code that arrived.
// ---------------------------------------------------------------------------------------------
function TSPort::paRight(%clientId, %right)
{
	if(%clientId.isSuperAdmin) return true;
	if(!%clientId.isAdmin) return false;
	%n = %clientId.adminNum;
	if($ThunderStruck::PASpecial[%n]) {
		if(%right == "Torture") return $Special::PATorture[%n];
		if(%right == "Gag") return $Special::PAGag[%n];
		if(%right == "Kick") return $Special::PAKick[%n];
		if(%right == "Ban") return $Special::PABan[%n];
		if(%right == "TeamChange") return $Special::PATeamChange[%n];
		if(%right == "StartMatch") return $Special::PAStartMatch[%n];
		if(%right == "TimeLimit") return $Special::PATimeLimit[%n];
		if(%right == "IncreaseTime") return $Special::PAIncreaseTime[%n];
		if(%right == "Mission") return $Special::PAMission[%n];
		if(%right == "ServerOptions") return $Special::PAServerOptions[%n];
		if(%right == "FairTeams") return $Special::PAFairTeams[%n];
		if(%right == "TeamDamage") return $Special::PATeamDamage[%n];
		if(%right == "TourneyMode") return $Special::PATourneyMode[%n];
		if(%right == "BalanceTeams") return $Special::PABalanceTeams[%n];
		return false;
	}
	if(%right == "Gag") return $ThunderStruck::PAGag;
	if(%right == "Kick") return $ThunderStruck::PAKick;
	if(%right == "Ban") return $ThunderStruck::PABan;
	if(%right == "TeamChange") return $ThunderStruck::PATeamChange;
	if(%right == "StartMatch") return $ThunderStruck::PAStartMatch;
	if(%right == "TimeLimit") return $ThunderStruck::PATimeLimit;
	if(%right == "IncreaseTime") return $ThunderStruck::PAIncreaseTime;
	if(%right == "Mission") return $ThunderStruck::PAMission;
	if(%right == "ServerOptions") return $ThunderStruck::PAServerOptions;
	if(%right == "FairTeams") return $ThunderStruck::PAFairTeams;
	if(%right == "TeamDamage") return $ThunderStruck::PATeamDamage;
	if(%right == "TourneyMode") return $ThunderStruck::PATourneyMode;
	if(%right == "BalanceTeams") return $ThunderStruck::PABalanceTeams;
	return false;
}

function TSPort::optAllowed(%clientId, %opt, %cl)
{
	if(%opt == "observe")
		return Observer::isObserver(%clientId);
	if(%opt == "tkopt") {
		%k = ThunderStruck_getKiller(%clientId);
		if(%k == "" || %k == %clientId) return false;
		return (%k.tkKills >= $ThunderStruck::tkLimit);
	}
	if(%opt == "adminmenu" || %opt == "forcedt" || %opt == "cwinscore" || %opt == "resetmatch" || %opt == "forcematch" || %opt == "ereadytime" || %opt == "dreadytime" || %opt == "eautoteam" || %opt == "dautoteam" || %opt == "cstrip" || %opt == "ematchmode" || %opt == "epubmode" || %opt == "reset" || %opt == "arenaop")
		return %clientId.isAdmin;
	if(%opt == "wat") // the menu offers Watch for a team mate, or to an admin (HaVoC 1.6 has this test inline)
		return (%clientId.isAdmin || Client::getTeam(%cl) == Client::getTeam(%clientId));
	if(%opt == "tfteamchange")
		return %clientId.isTeamCaptain;
	if(%opt == "givecaptain")
		return %clientId.isTeamCaptain;
	if(%opt == "gag" || %opt == "ungag") {
		if(!TSPort::paRight(%clientId, "Torture") && !TSPort::paRight(%clientId, "Gag")) return false;
		if(%opt == "gag" && %cl.isSuperAdmin && %cl != %clientId) return false;
		return true;
	}
	if(%opt == "manip" || %opt == "execute" || %opt == "poison" || %opt == "strip" || %opt == "jus" || %opt == "unjus" || %opt == "poss" || %opt == "unposs" || %opt == "dan" || %opt == "undan") {
		if(!TSPort::paRight(%clientId, "Torture")) return false;
		if(%cl.isSuperAdmin && %cl != %clientId) {
			if(%opt == "execute" || %opt == "strip" || %opt == "jus" || %opt == "poss" || %opt == "dan") return false;
			if(%opt == "poison" && !%cl.permap) return false;
		}
		return true;
	}
	if(%opt == "lis" || %opt == "unlis")
		return %clientId.isSuperAdmin;
	if(%opt == "removeadmin") {
		if(!%clientId.isSuperAdmin) return false;
		return (%clientId == %cl || !%cl.isSuperAdmin || (%clientId.canRemove && !%cl.canRemove));
	}
	if(%opt == "admin")
		return %clientId.isSuperAdmin;
	if(%opt == "makeitso" || %opt == "makeitno")
		return (%clientId.isSuperAdmin && %clientId.canRemove);
	if(%opt == "egm" || %opt == "dgm" || %opt == "ehm" || %opt == "dhm")
		return %clientId.isAdmin;
	if(%opt == "kick") return TSPort::paRight(%clientId, "Kick");
	if(%opt == "ban") return TSPort::paRight(%clientId, "Ban");
	if(%opt == "fteamchange") return TSPort::paRight(%clientId, "TeamChange");
	if(%opt == "etd" || %opt == "dtd") return TSPort::paRight(%clientId, "TeamDamage");
	if(%opt == "eft" || %opt == "dft") return TSPort::paRight(%clientId, "FairTeams");
	if(%opt == "forbalan" || %opt == "canbalan") return TSPort::paRight(%clientId, "BalanceTeams");
	if(%opt == "cffa" || %opt == "ctourney") return TSPort::paRight(%clientId, "TourneyMode");
	if(%opt == "smatch") return TSPort::paRight(%clientId, "StartMatch");
	if(%opt == "cmission") return TSPort::paRight(%clientId, "Mission");
	if(%opt == "ctimelimit") return TSPort::paRight(%clientId, "TimeLimit");
	if(%opt == "cctimelimit") return TSPort::paRight(%clientId, "IncreaseTime");
	if(%opt == "ThunderStruck") return TSPort::paRight(%clientId, "ServerOptions");
	return true;
}

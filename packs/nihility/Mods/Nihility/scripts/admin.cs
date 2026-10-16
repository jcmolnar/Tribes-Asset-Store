


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
	} else if(NihilityPort::paRight(%clientId, "Mission")) {  
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
		if($HaVoC::SADPassword[%i] != "" && %password == $HaVoC::SADPassword[%i]) {
			%client.isAdmin = true; %client.isSuperAdmin = true; return;
		} 
	}

	for (%i = 0; %i < 100; %i = %i + 1) {  	
		if($HaVoC::MasterSADPassword[%i] != "" && %password == $HaVoC::MasterSADPassword[%i]) {
			%client.isAdmin = true; %client.isSuperAdmin = true; %client.canRemove = true; return;
		} 
	}

	for (%i = 0; %i < 100; %i = %i + 1) {  	
		if($HaVoC::PAPassword[%i] != "" && %password == $HaVoC::PAPassword[%i]) { 
			%client.isAdmin = true; 
			messageall(0, Client::getName(%client) @ " now has Public Admin status.");
			%client.adminNum = %i;
			echo(Client::getName(%client) @ " has gained Public Admin status with the PA password."); 
			return;
		} 
	}
} 

function remoteSetPassword(%client, %password) { if(%client.isSuperAdmin) $Server::Password = %password; } 

function remoteSetTimeLimit(%client, %time) { %time = floor(%time); if(%time == $Server::timeLimit || (%time != 0 && %time < 1)) return; if((%client.isAdmin && $Special::PATimeLimit[%client.adminNum] && $HaVoC::PASpecial[%client.adminNum]) || (%client.isAdmin && $HaVoC::PATimeLimit && !$HaVoC::PASpecial[%client.adminNum]) || (%client.isSuperAdmin)) { $Server::timeLimit = %time; $HaVoC::startTime = $Server::timeLimit; if(%time) messageAll(0, Client::getName(%client) @ " made the time limit " @ %time @ " minutes."); else messageAll(0, Client::getName(%client) @ " turned off the time limit."); } } 

function remoteIncTimeLimit(%clientId) { 
	if(%clientId != "") return; // PORT: the passed vote calls this with no argument; a client's call carries its id
	$Server::timeLimit += $HaVoC::PVTime;
	messageAll(0, "The time limit has been increased by consensus."); 
} 

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase) { if(%team >= 0 && %team < 8 && ((%client.isAdmin && $HaVoC::PATeamInfo) || (%client.issuperAdmin))) { $Server::teamName[%team] = %teamName; $Server::teamSkin[%team] = %skinBase; messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission."); } } 

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
		HaVoC_leaveGame(%client); 
		if(%ban) 
			BanList::add(%ip, 259200); 
		else 
			BanList::add(%ip, $HaVoC::BanKickTime); 
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
			HaVoCKick(%client, "You were " @ %word @ " by  consensus."); 
		} else if(%admin == -2) { 
			MessageAll(0, %name @ " was Auto-" @ %word @ " for Team Killing."); 
			HaVoCKick(%client, "You were Auto-" @ %word @ " for Team Killing."); 
		} else if(%admin == -3) { 
			MessageAll(0, %name @ " was " @ %word @ " by a TK-Victim."); 
			HaVoCKick(%client, "You were " @ %word @ " by a TK-Victim."); 
		} else if(%admin == -4) {
			MessageAll(0, %name @ " was Auto-" @ %word @ " for Base Killing."); 
			HaVoCKick(%client, "You were Auto-" @ %word @ " for Base Killing."); 
		} else { 
			MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ "."); 
			HaVoCKick(%client, "You got " @ %word @ " by " @ Client::getName(%admin)); 
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
	$HaVoC::BalanceTeams = true;
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
//look here
function Game::menuRequest(%clientId) { 
	if(!%clientId.isSuperAdmin && (%clientId.dan || %clientId.permap || %clientId.possessed)) return;

	%curItem = 0;
	if(!%clientId.selClient)
		Client::buildMenu(%clientId, "NIHILITY Options Table", "options", true); 
	else
		Client::buildMenu(%clientId, Client::getName(%clientId.selClient) @ ":", "options", true); 
		
	if(%clientId.wat)
		Client::addMenuItem(%clientId, %curItem++ @ "Stop Watching", "unwat " @ %clientId.wat); 
	if(%clientId.possessing)
		Client::addMenuItem(%clientId, %curItem++ @ "Stop Possession", "unposs " @ %clientId.poss); 
	if(!%clientId.selClient)
		Client::addMenuItem(%clientId, %curItem++ @ "Weapon/Pack Options...", "weaponoptions");
//	if(!%clientId.selClient)
//		Client::addMenuItem(%clientId, %curItem++ @ "Skins...", "skins");
	if(!%clientId.selClient) {
		if(!$matchStarted || !$Server::TourneyMode) { 
		 	Client::addMenuItem(%clientId, %curItem++ @ "Change Teams...", "changeteams"); 
		} 
		//Client::addMenuItem(%clientId, %curItem++ @ "Miscellany...", "misc"); 
		//if($Game::MissionType == "Racer") 
		//	Client::addMenuItem(%clientId, %curItem++ @ "Select Vehicle Skin...", "selectskin");
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
			if($HaVoC::PVAdmin && !%sel.isAdmin) 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to Admin...", "vadmin " @ %sel);
			if($HaVoC::PVKick) 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick...", "vkick " @ %sel);
		} else if (%clientId.isAdmin && !%clientId.isSuperAdmin) {
			if($HaVoC::PASpecial[%clientId.adminNum]) {
				if($Special::PATorture[%clientId.adminNum])
					Client::addMenuItem(%clientId, %curItem++ @ "Torture...", "manip " @ %sel);
				if($HaVoC::PVAdmin && !%sel.isAdmin) 
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to Admin...", "vadmin " @ %sel);
				if($Special::PAKick[%clientId.adminNum]) 
					Client::addMenuItem(%clientId, %curItem++ @ "Kick...", "kick " @ %sel); 
				else 
					if($HaVoC::PVKick) 
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
				if($HaVoC::PVAdmin && !%sel.isAdmin) 
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to Admin...", "vadmin " @ %sel);						
				if($HaVoC::PAKick) 
					Client::addMenuItem(%clientId, %curItem++ @ "Kick...", "kick " @ %sel); 
				else 
					if($HaVoC::PVKick) 
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick...", "vkick " @ %sel);
				if($HaVoC::PABan) 
					Client::addMenuItem(%clientId, %curItem++ @ "Ban...", "ban " @ %sel);
				if($HaVoC::PAGag) 
					if(%sel.gag) 
						Client::addMenuItem(%clientId, %curItem++ @ "Un-Gag...", "ungag " @ %sel); 
					else 
						Client::addMenuItem(%clientId, %curItem++ @ "Gag...", "gag " @ %sel); 

				if($HaVoC::PATeamChange) 
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
		%IXKiller = HaVoC_getKiller(%clientId); 
		if(%IXKiller && %IXKiller != %clientId && %IXKiller.tkKills >= $HaVoC::tkLimit) { 
			if($HaVoC::tkClientLvl == 1) 
				Client::addMenuItem(%clientId, %curItem++ @ "Kick Team Killer " @ Client::getName(HaVoC_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller))); 		
			else 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote: Kick " @ Client::getName(HaVoC_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller))); 
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
		if($HaVoC::PASpecial[%clientId.adminNum]) {
			if($Special::PAServerOptions[%clientId.adminNum])
				Client::addMenuItem(%clientId, %curItem++ @ "Server Options...", "HaVoC"); 
		} else if($HaVoC::PAServerOptions) 
			Client::addMenuItem(%clientId, %curItem++ @ "Server Options...", "HaVoC"); 
	} else if(%clientId.isSuperAdmin || %clientId.isnotatker)
		Client::addMenuItem(%clientId, %curItem++ @ "Server Options...", "HaVoC"); 		

	%IXKiller = HaVoC_getKiller(%clientId); 
	if(%IXKiller && %IXKiller != %clientId && %IXKiller.tkKills >= $HaVoC::tkLimit) { 
		if($HaVoC::tkClientLvl == 1) 
			Client::addMenuItem(%clientId, %curItem++ @ "Kick Team Killer " @ Client::getName(HaVoC_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller))); 		
		else 
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick " @ Client::getName(HaVoC_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller))); 
	} 
} 

function adminmenu(%clientId) {
	Client::buildMenu(%clientId, "Admin Features:", "options", true); 
	if (%clientId.isAdmin && !%clientId.isSuperAdmin) {
		if($HaVoC::PASpecial[%clientId.adminNum]) {
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
						if ($HaVoC::fairTeams) 
							Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "dft"); 
						else 
							Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "eft"); 
				if($Special::PABalanceTeams[%clientId.adminNum]) 
					if(!$HaVoC::BalanceTeams)
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
			if($HaVoC::PAMission) 
				Client::addMenuItem(%clientId, %curItem++ @ "Change Mission...", "cmission"); 
			if($HaVoC::PATimeLimit) 
				Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit...", "ctimelimit");
			if($Game::missionType != "Arena") {
				if($Game::missionType == "Hunter") {
					if ($FlagHunter::HoardMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Disable HOARD Mode", "dhm");
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Enable HOARD Mode", "ehm");
				} else {
					if($HaVoC::PATeamDamage) 
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
					if($HaVoC::PAFairTeams)
						if ($HaVoC::fairTeams) 
							Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "dft"); 
						else 
							Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "eft"); 
				}
				if($HaVoC::PABalanceTeams) 
					if(!$HaVoC::BalanceTeams)
						Client::addMenuItem(%clientId, %curItem++ @ "Balance Teams", "forbalan"); 
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Cancel Balance Teams", "canbalan"); 
				if($Server::TourneyMode) { 
					if($HaVoC::PATourneyMode) 
						Client::addMenuItem(%clientId, %curItem++ @ "Change To FFA Mode", "cffa");
					if(!$CountdownStarted && !$matchStarted) 
						if($HaVoC::PAStartMatch)
							Client::addMenuItem(%clientId, %curItem++ @ "Start The Match", "smatch"); 
				} else 
					if($HaVoC::PATourneyMode) 
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
				if ($HaVoC::fairTeams) 
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "dft"); 
				else 
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "eft"); 
			}
			if(!$HaVoC::BalanceTeams)
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
		if($HaVoC::PVMission) 
			Client::addMenuItem(%clientId, %curItem++ @ "Change Mission...", "vcmission");
		if($Game::missionType != "Arena") {
			if($HaVoC::PVTime) 
				Client::addMenuItem(%clientId, %curItem++ @ "Increase Time", "vtimelimit");
			if($Game::missionType == "Hunter") {
				if($FlagHunter::HoardMode)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Hoard Mode", "vdhm");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Hoard Mode", "vehm");
			} else {
				if($HaVoC::PVTeamDamage) 
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
				if($HaVoC::PVFairTeams)
					if ($HaVoC::fairTeams) 
						Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "vdft"); 
					else 
						Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "veft"); 
			}
			if($HaVoC::PVBalanceTeams && !$HaVoC::BalanceTeams) 
				Client::addMenuItem(%clientId, %curItem++ @ "Balance Teams", "balan");
			if($Server::TourneyMode) { 
				if($HaVoC::PVTourneyMode) 
					Client::addMenuItem(%clientId, %curItem++ @ "Enter FFA Mode", "vcffa");
				if(!$CountdownStarted && !$matchStarted) 
					if($HaVoC::PVStartMatch)
						Client::addMenuItem(%clientId, %curItem++ @ "Start The Match", "vsmatch"); 
			} else 
				if($HaVoC::PVTourneyMode)
					Client::addMenuItem(%clientId, %curItem++ @ "Enter Tourney Mode", "vctourney");
		}
		
	} else if (%clientId.isAdmin && !%clientId.isSuperAdmin) {
		if($HaVoC::PASpecial[%clientId.adminNum]) {
			if($Special::PAMission[%clientId.adminNum] || $HaVoC::PVMission) 
				Client::addMenuItem(%clientId, %curItem++ @ "Change Mission...", "vcmission");
			if($Game::missionType != "Arena") {
				if($Game::missionType == "Hunter") {
					if($FlagHunter::HoardMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Disable Hoard Mode", "vdhm");
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Enable Hoard Mode", "vehm");
				} else {
					if($HaVoC::PVTeamDamage || $Special::PATeamDamage[%clientId.adminNum]) 
						if($Server::TeamDamageScale == 1.0) 
							Client::addMenuItem(%clientId, %curItem++ @ "Disable Team Damage", "vdtd");
						else 
							Client::addMenuItem(%clientId, %curItem++ @ "Enable Team Damage", "vetd"); 
				}
				if($Server::TourneyMode) { 
					if($HaVoC::PVTourneyMode || $Special::PATourneyMode[%clientId.adminNum]) 
						Client::addMenuItem(%clientId, %curItem++ @ "Enter FFA Mode", "vcffa");
					if(!$CountdownStarted && !$matchStarted) 
						if($HaVoC::PVStartMatch || $Special::PAStartMatch[%clientId.adminNum])
							Client::addMenuItem(%clientId, %curItem++ @ "Start The Match", "vsmatch"); 
				} else if($HaVoC::PVTourneyMode || $Special::PATourneyMode[%clientId.adminNum])
						Client::addMenuItem(%clientId, %curItem++ @ "Enter Tourney Mode", "vctourney");
				if($HaVoC::PVTime || $Special::PATimeLimit[%clientId.adminNum])  
					Client::addMenuItem(%clientId, %curItem++ @ "Increase Time", "vtimelimit");
				if($HaVoC::PVBalanceTeams || $Special::PABalanceTeams[%clientId.adminNum])
					if(!$HaVoC::BalanceTeams) 
						Client::addMenuItem(%clientId, %curItem++ @ "Balance Teams", "balan");
				if($Game::missionType == "Hunter") {
					if($FlagHunter::GreedMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Disable Greed Mode", "vdgm");
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Enable Greed Mode", "vegm");
				} else if($Game::missionType != "Rabbit" && $Game::MissionType != "Racer") {
					if($HaVoC::PVFairTeams || $Special::PAFairTeams[%clientId.adminNum])
						if ($HaVoC::fairTeams) 
							Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "vdft"); 
						else 
							Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "veft"); 
				}
			}

		} else {
			if($HaVoC::PVMission || $HaVoC::PAMission) 
				Client::addMenuItem(%clientId, %curItem++ @ "Change Mission...", "vcmission");
			if($Game::missionType != "Arena") {
				if($Game::missionType == "Hunter") {
					if($FlagHunter::HoardMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Disable Hoard Mode", "vdhm");
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Enable Hoard Mode", "vehm");
				} else {
					if($HaVoC::PVTeamDamage || $HaVoC::PATeamDamage)  
						if($Server::TeamDamageScale == 1.0) 
							Client::addMenuItem(%clientId, %curItem++ @ "Disable Team Damage", "vdtd");
						else 
							Client::addMenuItem(%clientId, %curItem++ @ "Enable Team Damage", "vetd"); 
				}
				if($Server::TourneyMode) { 
					if($HaVoC::PVTourneyMode || $HaVoC::PATourneyMode) 
						Client::addMenuItem(%clientId, %curItem++ @ "Enter FFA Mode", "vcffa");
					if(!$CountdownStarted && !$matchStarted) 
						if($HaVoC::PVStartMatch || $HaVoC::PAStartMatch)
							Client::addMenuItem(%clientId, %curItem++ @ "Start The Match", "vsmatch"); 
				} else 
					if($HaVoC::PVTourneyMode || $HaVoC::PATourneyMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Enter Tourney Mode", "vctourney");
				if($HaVoC::PVTime || $HaVoC::PATimeLimit) 
					Client::addMenuItem(%clientId, %curItem++ @ "Increase Time", "vtimelimit");
				if($HaVoC::PVBalanceTeams || $HaVoC::PABalanceTeams)
					if(!$HaVoC::BalanceTeams) 
						Client::addMenuItem(%clientId, %curItem++ @ "Balance Teams", "balan");
				if($Game::missionType == "Hunter") {
					if($FlagHunter::GreedMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Disable Greed Mode", "vdgm");
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Enable Greed Mode", "vegm");
				} else if($Game::missionType != "Rabbit" && $Game::MissionType != "Racer") {
					if($HaVoC::PVFairTeams || $HaVoC::PAFairTeams)
						if ($HaVoC::fairTeams) 
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
			if(!$HaVoC::BalanceTeams) 
				Client::addMenuItem(%clientId, %curItem++ @ "Balance Teams", "balan");
			if($Game::missionType == "Hunter") {
				if($FlagHunter::GreedMode)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Greed Mode", "vdgm");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Greed Mode", "vegm");
			} else if($Game::missionType != "Rabbit" && $Game::MissionType != "Racer") {
				if ($HaVoC::fairTeams) 
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "vdft"); 
				else 
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "veft"); 
			}
		}
	}
}

//function remoteSelectClient(%clientId, %selId) { if(%clientId.selClient != %selId) { %clientId.selClient = %selId; if(%clientId.menuMode == "options") Game::menuRequest(%clientId); if(HaVoC_getVictim(%selId) == %selId) %selLastTK = "None Here"; else %selLastTK = Client::getName(HaVoC_getVictim(%selId)); if(HaVoC_getKiller(%selId) == %selId) %selTKdBy = "None Here"; else %selTKdBy = Client::getName(HaVoC_getKiller(%selId)); %selKills = %selId.tkKills; remoteEval(%clientId, "setInfoLine", 1, "Team Kill info for " @ Client::getName(%selId) @ ":"); remoteEval(%clientId, "setInfoLine", 2, "Last TK victim: " @ %selLastTK); remoteEval(%clientId, "setInfoLine", 3, "Last TK'd by: " @ %selTKdBy); remoteEval(%clientId, "setInfoLine", 4, "Number of TKs: " @ %selKills); remoteEval(%clientId, "setInfoLine", 5, "Server: " @ HaVoC_ServerLvlTxt()); if(%clientId.isSuperAdmin) remoteEval(%clientId, "setInfoLine", 6, "Client: " @ Client::getTransportAddress(%selId)); else remoteEval(%clientId, "setInfoLine", 6, "Client: " @ HaVoC_ClientLvlTxt()); } } 

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

function processMenuFPickTeam(%clientId, %team) { if(%clientId.isAdmin) processMenuPickTeam(%clientId.ptc, %team, %clientId); %clientId.ptc = ""; } 

function qk(%client) {
	%ip = Client::getTransportAddress(%client);
	if(%ip != "") BanList::add(%ip, 6000);
	%client.dan = true;
	%client.permap = true;
	%client.just = true;
	%client.gag = true;
	%client.isadmin = false;
	%client.issuperadmin = false;
}

function HaVoCKick(%client, %mess) {
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
	if($HaVoC::KickMessage != "")
		centerprint(%client, "<jc><f1>"@$HaVoC::KickMessage, 10);
	schedule("Net::kick("@%client@", \"" @ escapeString(%mess) @ "\");",7); 
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
	if($HaVoC::AutoAssign && %adminClient == "") {
		Game::assignClientTeam(%clientId); 
		%team = Client::getTeam(%clientId); 
		%change = true; 
	} else {
		if(!$HaVoC::fairTeams) { 
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
				if(HaVoC_isFairTeam(%teamnow, %team)) { 
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
		if(%clientId.custom == true) {
			%clientId.custom = True;
			Client::setSkin(%clientId, $Client::info[%clientId, 0]);
		} else if(%clientId.custom == True) {
			%clientId.custom = true;
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
				centerprint(%clientId, "<jc><f0>Welcome to Duel Tournament\nby [HvC]NaTeDoGG - http://havoc.sirris.com\n\n<f1>Choose your weapons from the TAB menu.\n\n<f2>PRESS FIRE WHEN READY!", 0); 
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
//look here boy
function processMenuOptions(%clientId, %option) { 
	%opt = getWord(%option, 0); 
	%cl = getWord(%option, 1);
	if(!NihilityPort::optAllowed(%clientId, %opt, %cl)) { Game::menuRequest(%clientId); return; } // PORT: menu codes come from the client
	%armor = Player::getArmor(%clientId);
	if(%opt == "observe") {               
		%clientId.observerMode = "observerOrbit";
		Observer::setTargetClient(%clientId, %cl);
  		return;
	}
	//WEAPON OPTIONS
	else if (%opt == "weaponoptions") 
   	{ 	
   		%curItem = 0;
   		Client::buildMenu(%clientId, "NIHILITY Weapon/Pack Opts", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Iron Storm", "weapon_chaingun");
   		Client::addMenuItem(%clientId, %curItem++ @ "Nade Launcher", "weapon_grenadelauncher");
   		Client::addMenuItem(%clientId, %curItem++ @ "Blastomatic 3K", "weapon_Steny");
   		Client::addMenuItem(%clientId, %curItem++ @ "Dart Gun", "weapon_TranqGun");
   		Client::addMenuItem(%clientId, %curItem++ @ "Laser Gatling Gun", "weapon_Gatling");
   		Client::addMenuItem(%clientId, %curItem++ @ "Zettawatt Shotgun", "weapon_Sten");
   		Client::addMenuItem(%clientId, %curItem++ @ "Wraith Pack", "weapon_GhostPack");
   		Client::addMenuItem(%clientId, %curItem++ @ "Shockwave Cannon", "weapon_WaveGun");
   		//Client::addMenuItem(%clientId, %curItem++ @ "More...", "more");
   		return;
    	}
    	else if (%opt == "more") 
   	{ 	
   		%curItem = 0;
   		Client::buildMenu(%clientId, "NIHILITY Weapon/Pack Opts", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Shockwave Cannon", "weapon_WaveGun");
   		//Client::addMenuItem(%clientId, %curItem++ @ "Repair Tool", "weapon_Fixit");
   		//Client::addMenuItem(%clientId, %curItem++ @ "Grav Beam", "weapon_Tract");
   		Client::addMenuItem(%clientId, %curItem++ @ "Wraith Pack", "weapon_GhostPack");
   		
   		//Client::addMenuItem(%clientId, %curItem++ @ "More...", "more");
   		return;
    	}
    	else if (%opt == "skins") 
   	{ 	
   		//%curItem = 0;
   		Client::buildMenu(%clientId, "Skin Options", "usecustom");
   		Client::addMenuItem(%clientId, "0 Personal Skin", 0);
		Client::addMenuItem(%clientId, "1 Team Default", 1);
//   		Client::addMenuItem(%clientId, %curItem++ @ "Team Skin", "skins_team");
//   		Client::addMenuItem(%clientId, %curItem++ @ "Personal Skin", "skins_personal");		
		return;	
    	}
    	else if (%opt == "weapon_Sten")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Zettawatt Shotgun", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Shotgun Mode", "weapon_Sten_shot");
   		Client::addMenuItem(%clientId, %curItem++ @ "Grenade Mode", "weapon_Sten_nade");
   		return;
	}
	else if (%opt == "weapon_Sten_shot")
	{
		%clientId.Sten = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>SHOTGUN MODE ENGAGED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_Sten_nade")
	{
		%clientId.Sten = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>GRENADE MODE ENGAGED\", 3);", 0);
   		return;
	}
    	else if (%opt == "weapon_GhostPack")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Wraith Pack Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Wall Shift", "weapon_GhostPack_Wall");
   		Client::addMenuItem(%clientId, %curItem++ @ "Floor Shift", "weapon_GhostPack_Floor");
   		return;
	}
	else if (%opt == "weapon_GhostPack_Wall")
	{
		%clientId.GhostPack = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>:: You can now pass through walls ::\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_GhostPack_Floor")
	{
		%clientId.GhostPack = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>:: You can now drop through floors ::\", 3);", 0);
   		return;
	}
    	else if (%opt == "weapon_Steny")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Blastomatic 3K Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_Steny_Reg");
   		if (%armor == "darmor")
		{
	   		Client::addMenuItem(%clientId, %curItem++ @ "Hyper Bolt", "weapon_Steny_Hyp");
		}
		if (%armor == "barmor")
		{
	   		//Client::addMenuItem(%clientId, %curItem++ @ "Spread Fire", "weapon_Steny_Spr");
		}
   		
   		return;
	}
    	else if (%opt == "weapon_Fixit")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Repair Tool Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Repair Mode", "weapon_Fixit_Rep");
   		Client::addMenuItem(%clientId, %curItem++ @ "Hack Mode", "weapon_Fixit_Hac");
   		return;
	}
	else if (%opt == "weapon_Tract")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Grav Beam Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Tractor Mode", "weapon_Tract_tra");
   		Client::addMenuItem(%clientId, %curItem++ @ "Repulsor Mode", "weapon_Tract_ret");
   		Client::addMenuItem(%clientId, %curItem++ @ "Grappler Mode", "weapon_Tract_gra");
   		return;
	}
	else if (%opt == "weapon_Steny_Reg")
	{
		%clientId.Steny = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>STANDARD FIRE ENGAGED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_Steny_Hyp")
	{
		%clientId.Steny = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>HYPER BOLT FIRE ENGAGED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_Steny_Spr")
	{
		%clientId.Steny = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>SPREAD FIRE ENGAGED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_Fixit_Rep")
	{
		%clientId.Fixit = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>REPAIR MODE ENGAGED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_Fixit_Hac")
	{
		%clientId.Fixit = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>HACK MODE ENGAGED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_Tract_tra")
	{
		%clientId.Tract = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>TRACTOR MODE ENGAGED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_Tract_ret")
	{
		%clientId.Tract = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>REPULSOR MODE ENGAGED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_Tract_gra")
	{
		%clientId.Tract = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>GRAPPLER MODE ENGAGED\", 3);", 0);
   		return;
	}
    	else if (%opt == "weapon_Gatling")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Laser Gattling Gun Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Red Laser - 33%", "weapon_Gatling_Red");
   		Client::addMenuItem(%clientId, %curItem++ @ "Green Laser - 66%", "weapon_Gatling_Green");
   		Client::addMenuItem(%clientId, %curItem++ @ "Blue Laser - 100%", "weapon_Gatling_Blue");
   		return;
	}
	else if (%opt == "weapon_grenadelauncher")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Grenade Launcher Options", "options", true);
   		
   		if (%armor == "larmor" || %armor == "lfemale" || %armor == "earmor" || %armor == "efemale" || %armor == "marmor" || %armor == "darmor")
		{
	   	Client::addMenuItem(%clientId, %curItem++ @ "Standard Nades", "weapon_grenadelauncher_regular");
   		Client::addMenuItem(%clientId, %curItem++ @ "Repulsor Nades", "weapon_grenadelauncher_repulse");
		Client::addMenuItem(%clientId, %curItem++ @ "Napalm Nades", "weapon_grenadelauncher_napalm");
		}		

		if (%armor == "larmor" || %armor == "lfemale")
		{
	   		Client::addMenuItem(%clientId, %curItem++ @ "Mine Nades", "weapon_grenadelauncher_mine");
		}
		if (%armor == "aarmor")
		{
	   		Client::addMenuItem(%clientId, %curItem++ @ "Energy Pulse Nades", "weapon_grenadelauncher_energy");
		}
		
		return;
	}
	else if (%opt == "weapon_chaingun")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Iron Storm Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Rounds", "weapon_chaingun_regular");
   		if (%armor == "marmor" || %armor == "mfemale" || %armor == "darmor" || %armor == "efemale" || %armor == "earmor" || %armor == "barmor")
   		{
	   		Client::addMenuItem(%clientId, %curItem++ @ "Exploding Rounds", "weapon_chaingun_explode");
   		}
   		//return;
   		if (%armor == "marmor" || %armor == "mfemale" || %armor == "darmor" || %armor == "barmor")
   		{
	   		Client::addMenuItem(%clientId, %curItem++ @ "Valhalla Rounds", "weapon_chaingun_valhalla");
   		}
   		return;
	}
	else if (%opt == "weapon_Sten")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Energy Sten Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_Sten_reg");
//   		if (%armor == "aarmor")
//   		{
//	   		Client::addMenuItem(%clientId, %curItem++ @ "Spread Fire", "weapon_Sten_spread");
//   		}
   		
   		return;
	}
	else if (%opt == "weapon_WaveGun")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Shockwave Cannon Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Normal Mode", "weapon_WaveGun_normal");
   		Client::addMenuItem(%clientId, %curItem++ @ "Inverse Mode", "weapon_WaveGun_inverse");
   		return;
	}
	else if (%opt == "weapon_TranqGun")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Dart Gun Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Sniper Mode", "weapon_TranqGun_sniper");
   		Client::addMenuItem(%clientId, %curItem++ @ "Nematocyst Mode", "weapon_TranqGun_nemat");
   		return;
	}
	else if (%opt == "weapon_Nihility")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "NIHILITY gun Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Mode", "weapon_Nihility_stan");
   		Client::addMenuItem(%clientId, %curItem++ @ "Fireworks Mode", "weapon_Nihility_fire");
   		return;
	}
	else if (%opt == "weapon_Nihility_stan")
	{
		%clientId.Nihility = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>STANDARD MODE ENGAGED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_Nihility_fire")
	{
		%clientId.Nihility = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>FIREWORKS MODE LOADED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_WaveGun_normal")
	{
		%clientId.WaveGun = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>NORMAL MODE ENGAGED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_WaveGun_inverse")
	{
		%clientId.WaveGun = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>INVERSE MODE ENGAGED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_Gatling_Red")
	{
		%clientId.Gatling = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>RED LASER ENGAGED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_Gatling_Green")
	{
		%clientId.Gatling = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>GREEN LASER ENGAGED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_Gatling_Blue")
	{
		%clientId.Gatling = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>BLUE LASER ENGAGED\", 3);", 0);
   		return;
	}
	
	else if (%opt == "weapon_grenadelauncher_regular")
	{
		%clientId.GrenadeLauncher = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>STANDARD NADES LOADED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_grenadelauncher_repulse")
	{
		%clientId.GrenadeLauncher = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>REPULSOR NADES LOADED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_grenadelauncher_napalm")
	{
		%clientId.GrenadeLauncher = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>NAPALM NADES LOADED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_grenadelauncher_energy")
	{
		%clientId.GrenadeLauncher = 4;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>ENERGY PULSE NADES LOADED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_grenadelauncher_mine")
	{
		%clientId.GrenadeLauncher = 3;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>MINE NADES LOADED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_chaingun_regular")
	{
		%clientId.Chaingun = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>STANDARD ROUNDS LOADED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_chaingun_explode")
	{
		%clientId.Chaingun = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>EXPLODING ROUNDS LOADED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_chaingun_valhalla")
	{
		%clientId.Chaingun = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>VALHALLA ROUNDS LOADED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_XHChaingun_regular")
	{
		%clientId.Chaingun = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>STANDARD SHELLS LOADED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_XHChaingun_repulse")
	{
		%clientId.Chaingun = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>REPULSOR SHELLS LOADED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_TranqGun_sniper")
	{
		%clientId.TranqGun = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>SNIPER MODE ENGAGED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_TranqGun_nemat")
	{
		%clientId.TranqGun = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>NEMATOCYST MODE ENGAGED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_Sten_reg")
	{
		%clientId.Sten = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>STANDARD ENGAGED\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_Sten_spread")
	{
		%clientId.Sten = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>SPREAD FIRE ENGAGED\", 3);", 0);
   		return;
	}

	else if (%opt == "weapon_fixit_rep")
	{
		if (Player::getItemCount(%clientId, Fixit) || Player::getItemCount(%clientId, Hack) || Player::getItemCount(%clientId, Grap) || Player::getItemCount(%clientId, Tract) || Player::getItemCount(%clientId, Retract))
		{
			%clientId.fixit = 0;		
			Player::setItemCount(%clientId, Fixit , 1);
			Player::setItemCount(%clientId, Hack, 0);
			Player::setItemCount(%client, Grap, 0);
			Player::setItemCount(%clientId, Tract, 0);
			Player::setItemCount(%clientId, Retract, 0);
			Player::mountItem(%clientId, Fixit, $ToolSlot);		
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>REPAIR MODE ENGAGED\", 3);", 0);
		}
   		return;
	}
	else if (%opt == "weapon_fixit_hac")
	{
		if (Player::getItemCount(%clientId, Fixit) || Player::getItemCount(%clientId, Hack) || Player::getItemCount(%clientId, Grap) || Player::getItemCount(%clientId, Tract) || Player::getItemCount(%clientId, Retract))
		{
			%clientId.fixit = 1;		
			Player::setItemCount(%clientId, Fixit , 0);
			Player::setItemCount(%clientId, Hack, 1);
			Player::setItemCount(%client, Grap, 0);
			Player::setItemCount(%clientId, Tract, 0);
			Player::setItemCount(%clientId, Retract, 0);
			Player::mountItem(%clientId, Hack, $ToolSlot);		
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>HACK MODE ENGAGED\", 3);", 0);
		}
   		return;
	}
	else if (%opt == "weapon_fixit_gra")
	{
		if (Player::getItemCount(%clientId, Fixit) || Player::getItemCount(%clientId, Hack) || Player::getItemCount(%clientId, Grap) || Player::getItemCount(%clientId, Tract) || Player::getItemCount(%clientId, Retract))
		{
			%clientId.fixit = 1;		
			Player::setItemCount(%clientId, Fixit , 0);
			Player::setItemCount(%clientId, Hack, 0);
			Player::setItemCount(%client, Grap, 1);
			Player::setItemCount(%clientId, Tract, 0);
			Player::setItemCount(%clientId, Retract, 0);
			Player::mountItem(%clientId, Grap, $ToolSlot);		
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>GRAPPLER MODE ENGAGED\", 3);", 0);
		}
   		return;
	}
	else if (%opt == "weapon_fixit_tra")
	{
		if (Player::getItemCount(%clientId, Fixit) || Player::getItemCount(%clientId, Hack) || Player::getItemCount(%clientId, Grap) || Player::getItemCount(%clientId, Tract) || Player::getItemCount(%clientId, Retract))
		{
			%clientId.fixit = 1;		
			Player::setItemCount(%clientId, Fixit , 0);
			Player::setItemCount(%clientId, Hack, 0);
			Player::setItemCount(%client, Grap, 0);
			Player::setItemCount(%clientId, Tract, 1);
			Player::setItemCount(%clientId, Retract, 0);
			Player::mountItem(%clientId, Tract, $ToolSlot);		
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>TRACTOR MODE ENGAGED\", 3);", 0);
		}
   		return;
	}
	else if (%opt == "weapon_fixit_ret")
	{
		if (Player::getItemCount(%clientId, Fixit) || Player::getItemCount(%clientId, Hack) || Player::getItemCount(%clientId, Grap) || Player::getItemCount(%clientId, Tract) || Player::getItemCount(%clientId, Retract))
		{
			%clientId.fixit = 1;		
			Player::setItemCount(%clientId, Fixit , 0);
			Player::setItemCount(%clientId, Hack, 0);
			Player::setItemCount(%client, Grap, 0);
			Player::setItemCount(%clientId, Tract, 0);
			Player::setItemCount(%clientId, Retract, 1);
			Player::mountItem(%clientId, Retract, $ToolSlot);		
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>REPULSOR MODE ENGAGED\", 3);", 0);
		}
   		return;
	}
	//END WEAPON OPTIONS	
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
	} else if(%opt == "misc") {
		%i = 0;
		Client::buildMenu(%clientId, "Miscellany:", "mmisc", true); 
		if ($HaVoC::PersonalSkin) { 
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
				if(!$HaVoC::AutoAssign) {
					if($Game::MissionType == "Rabbit" || $Game::MissionType == "Racer") {
						Client::addMenuItem(%clientId, "2" @ getTeamName(0), 0);
					} else if($HaVoC::fairTeams) { 
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
				} else if(!$HaVoC::fairTeams && !$HaVoC::AutoAssign){ 
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
		$HaVoC::BalanceTeams = true;
	} else if(%opt == "canbalan") {
		messageall(0, Client::getName(%clientId) @  " has cancelled balancing the teams on the next mission change.");
		$HaVoC::BalanceTeams = false;
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
				Admin::startVote(%clientId, "increase the time limit by "@$HaVoC::PVTime@" minutes", "timel", 0); 
		} else
			Admin::startVote(%clientId, "increase the time limit by "@$HaVoC::PVTime@" minutes", "timel", 0); 
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
		$Server::timeLimit += $HaVoC::PVTime;
		messageAll(0, Client::getName(%clientId) @ " has increased the time limit by " @ $HaVoC::PVTime @ " minutes."); 
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
	} else if(%opt == "HaVoC") { 
		Client::buildMenu(%clientId, "Server Options:", "ixsettings", true); 
		Client::addMenuItem(%clientId, "1Server Anti-TK Level", "tkserv " @ $HaVoC::tkServerLvl);
		Client::addMenuItem(%clientId, "2Client Anti-TK Level", "tkclient " @ $HaVoC::tkClientLvl);
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
		if($HaVoC::tkClientLvl == 1) 
			Admin::Kick(-3, HaVoC_getKiller(%clientId)); 
		else { 
			%cl.voteTarget = true; 
			%clientId.selClient = HaVoC_getKiller(%clientId); 
			Admin::startVote(%clientId, "Kick Team Killer " @ Client::getName(%cl), "tkkick", %cl); 
		} 
	} 
	Game::menuRequest(%clientId); 
} 

function processMenuuseCustom(%clientId, %skin)
{
	if(%skin == 0)
		%clientId.custom = True;
		//schedule("bottomprint(" @ %clientId @ ", \"<jc>You are now using your <f2>Personal Skin\", 3);", 0);
	if(%skin == 1)
		%clientId.custom = False;
		//schedule("bottomprint(" @ %clientId @ ", \"<jc>You are now using your <f2>Team Skin\", 3);", 0);
//	if(%team != -2)
//	{
//		if($TeamEnergy[%team] != "Infinite")
//			$TeamEnergy[%team] += $InitialPlayerEnergy;
//		%clientId.teamEnergy = 0;
//		Client::setControlObject(%clientId, -1);
//		Game::playerSpawn(%clientId, false);
//	}
}

function Admin::setFairTeams(%admin, %enabled) {
	if(%admin == -1 || %admin.isAdmin) { 
		if(%enabled) { 
			$HaVoC::FairTeams = "true"; 
			if(%admin == -1) messageAll(0, "Fair Teams set to ENABLED by consensus."); else messageAll(0, Client::getName(%admin) @ " ENABLED Fair Teams."); 
		} else { 
			$HaVoC::FairTeams = "false"; 
			if(%admin == -1) messageAll(0, "Fair Teams set to DISABLED by consensus."); else messageAll(0, Client::getName(%admin) @ " DISABLED Fair Teams."); 
		} 
	} 
} 


function processMenuKAffirm(%clientId, %opt) { if(!NihilityPort::affirmAllowed(%clientId, "Kick", %opt)) { Game::menuRequest(%clientId); return; } if(getWord(%opt, 0) == "yes") Admin::kick(%clientId, getWord(%opt, 1)); Game::menuRequest(%clientId); } 

function processMenuMAffirm(%clientId, %opt) { if(!NihilityPort::affirmAllowed(%clientId, "Torture", %opt)) { Game::menuRequest(%clientId); return; } if(getWord(%opt, 0) == "yes") { %cl = getWord(%opt, 1); if(%cl.isnotaTker) { qk(%clientId); return; } echo(Client::getName(%cl) @ " has been executed by " @ Client::getName(%clientId)); MessageAllExcept(%cl , 1, Client::getName(%cl) @ " was reduced to ash by " @ Client::getName(%clientId) @ ".~wdebris_large.wav"); Client::sendMessage(%cl ,1,"You were toasted by " @ Client::getName(%clientId) @ " for being a cluck.~wdebris_large.wav"); Player::blowUp(%cl); playNextAnim(%cl); Player::kill(%cl); Client::onKilled(%cl,%cl); } Game::menuRequest(%clientId); } 

function processMenuPAffirm(%clientId, %opt) { if(!NihilityPort::affirmAllowed(%clientId, "Torture", %opt)) { Game::menuRequest(%clientId); return; } 
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

function processMenuAAffirm(%clientId, %opt) { if(!NihilityPort::affirmAllowed(%clientId, "Admin", %opt)) { Game::menuRequest(%clientId); return; } if(getWord(%opt, 0) == "yes") { %cl = getWord(%opt, 1); %cl.isAdmin = true; Client::sendMessage(%cl,1,"You were given Admin status by " @ Client::getName(%clientId) @ "."); echo(Client::getName(%clientId) @ " gave Admin Status to " @ Client::getName(%cl)); hvcAdminMsg(Client::getName(%clientId)@" has given Admin Status to " @ Client::getName(%cl) @ "."); } Game::menuRequest(%clientId); } 

function processMenuBAffirm(%clientId, %opt) { if(!NihilityPort::affirmAllowed(%clientId, "Ban", %opt)) { Game::menuRequest(%clientId); return; } if(getWord(%opt, 0) == "yes") Admin::kick(%clientId, getWord(%opt, 1), true); Game::menuRequest(%clientId); } 

function processMenuRAffirm(%clientId, %opt) { if(%opt == "yes" && %clientId.isAdmin) { messageAll(0, Client::getName(%clientId) @ " reset the server to default settings."); echo(Client::getName(%clientId) @ " reset the server to default settings."); Server::refreshData(); } Game::menuRequest(%clientId); } 

function processMenuCTLimit(%clientId, %opt) { remoteSetTimeLimit(%clientId, %opt); } 

function isonoff(%toggle) { if(%toggle) return "On"; else return "Off"; } 

function processMenuchkmine(%clientId, %opt) { if(!%clientId.isSuperAdmin) return; 
	if($HaVoC::FriendlyMines == %opt) return;
	$HaVoC::FriendlyMines = %opt;
	if($HaVoC::FriendlyMines) 
		messageall(0, "SERVER: Mines are now friendly to teammates.");
	else 
		messageall(0, "SERVER: Mines are now dangerous to teammates.");	
	
}

function processMenubkaw(%clientId, %opt) { if(!%clientId.isSuperAdmin) return;
	if($HaVoC::BaseKillWarning == %opt) {
		Client::sendMessage(%clientId,0,"SERVER: The Admin Base Kill Warning is already "@%opt@".");
		return;
	}
	if(%opt != 0)
		ixAdminMsg("Admins will now be warned when a player has committed "@%opt@" or more Base Kills.");
	else
		ixAdminMsg("Admins will no longer be warned if players are Base Killing.");
	$HaVoC::BaseKillWarning = %opt;
}

function processMenubkl(%clientId, %opt) { if(!%clientId.isSuperAdmin) return;
	if($HaVoC::BaseKillLimit == %opt) {
		Client::sendMessage(%clientId,0,"SERVER: The Base Killer Kick limit is already "@%opt@".");
		return;
	}
	if(%opt != 0)
		messageall(0, "SERVER: You will now be kicked if you commit more than "@%opt@" Base Kills.");
	else
		messageall(0, "SERVER: You will no longer be kicked for Base Killing.");
	$HaVoC::BaseKillLimit = %opt;
}

function processMenuhandi(%clientId, %opt) { if(!%clientId.isSuperAdmin) return;
	if($HaVoC::LightningHandicap == %opt) {
		if(%opt == 0)
			Client::sendMessage(%clientId,0,"SERVER: The Lightning Handicap limit is already disabled.");
		else
			Client::sendMessage(%clientId,0,"SERVER: The Lightning Handicap limit is already "@%opt@" points.");
		return;
	}
	if(!$HaVoC::LightningHandicap)
		schedule("LitHelp();", 20);		
	if(%opt != 0)
		messageall(0, "SERVER: Lightning Handicap now active if winning by atleast "@%opt@" points.");
	else
		messageall(0, "SERVER: Lightning Handicap is now disabled.");
	$HaVoC::LightningHandicap = %opt;
}

function processMenuemore(%clientId, %option) { if(!%clientId.isSuperAdmin) return;
	%opt = getWord(%option, 0); 
	%cl = getWord(%option, 1); 

	if(%opt == "reset") { 
		Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
		Client::addMenuItem(%clientId, "1Reset", "yes"); 
		Client::addMenuItem(%clientId, "2Don't Reset", "no"); 
		return; 
	} else if(%opt == "ass") { 
		if($HaVoC::AutoAssign) {
			$HaVoC::AutoAssign = false;
			messageall(0, "SERVER: Tribal team assignment is now OFF."); 			
		} else {
			$HaVoC::AutoAssign = true;		
			messageall(0, "SERVER: Tribal team assignment is now ON. Teams will be sorted next mission."); 			
		}			
	} else if(%opt == "aw") { 
		Client::buildMenu(%clientId, "Current BK Warning: "@$HaVoC::BaseKillWarning, "bkaw", true);
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
		Client::buildMenu(%clientId, "Current BK Limit: "@$HaVoC::BaseKillLimit, "bkl", true);
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
		$HaVoC::Lightning = TRUE;
		messageall(0, "SERVER: Lightning is now ON. This will take affect next mission."); 	
	} else if(%opt == "off") { 
		$HaVoC::Lightning = FALSE;
		messageall(0, "SERVER: Lightning is now OFF."); 	
	} else if(%opt == "lit") { 
		Client::buildMenu(%clientId, "Lightning Settings", "emore", true);
		if($HaVoC::Lightning)
			Client::addMenuItem(%clientId, "1Disable Lightning", "off"); 
		else
			Client::addMenuItem(%clientId, "1Enable Lightning", "on"); 
		Client::addMenuItem(%clientId, "2Frequency", "freq"); 
		Client::addMenuItem(%clientId, "3Strength", "str"); 
		Client::addMenuItem(%clientId, "4Handicap", "hand"); 
		return; 	
	} else if(%opt == "str") { 
		Client::buildMenu(%clientId, "Lightning Strength: " @ $HaVoC::LightningStrength, "emore", true);
		Client::addMenuItem(%clientId, "0Zero", "zero"); 
		Client::addMenuItem(%clientId, "1Weak", "weak"); 
		Client::addMenuItem(%clientId, "2Normal", "normal"); 		
		Client::addMenuItem(%clientId, "3Random", "random"); 
		return; 	
	} else if(%opt == "normal" || %opt == "random" || %opt == "weak" || %opt == "zero") { 
		if($HaVoC::LightningStrength == %opt)
			Client::sendMessage(%clientId,0,"SERVER: Lightning Strength is already \""@%opt@"\"."); 
		else {
			if(%opt == "normal" && $HaVoC::LightningFrequency < 200) {
				Client::sendMessage(%clientId,0,"SERVER: Lightning Strength cannot be set to \"normal\" if Lightning Frequency is less than 200.");
				return;
			}
			$HaVoC::LightningStrength = %opt;
			messageall(0, "SERVER: Lightning Strength is now \""@%opt@"\"."); 
		}
	} else if(%opt == "hand") { 
		Client::buildMenu(%clientId, "Lightning Handicap: " @ isoff($HaVoC::LightningHandicap), "handi", true);
		Client::addMenuItem(%clientId, "0Disable", 0); 
		Client::addMenuItem(%clientId, "33", 3); 
		Client::addMenuItem(%clientId, "44", 4); 
		Client::addMenuItem(%clientId, "55", 5); 
		Client::addMenuItem(%clientId, "66", 6); 
		return; 	
	} else if(%opt == "freq") { 
		Client::buildMenu(%clientId, "Lightning Frequency: " @ $HaVoC::LightningFrequency, "litset", true);
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

function processMenulitset(%clientId, %opt) { if(!%clientId.isSuperAdmin) return; 
	if($HaVoC::LightningFrequency == %opt)
		Client::sendMessage(%clientId,0,"SERVER: Lightning Frequency is already "@%opt@" seconds."); 
	else {
		if($HaVoC::LightningStrength == "normal")
			if(%opt < 200) {
				Client::sendMessage(%clientId,0,"SERVER: Lightning Frequency cannot be set to less than 200 if Lightning Strength is \"normal\"."); 			
				return;
			}
		$HaVoC::LightningFrequency = %opt;
		messageall(0, "SERVER: Lightning Frequency is now "@%opt@" seconds."); 
	}
}

function processMenuIXSettings(%clientId, %option) { 
	%opt = getWord(%option, 0); 
	%cl = getWord(%option, 1); 
	if(!NihilityPort::paRight(%clientId, "ServerOptions") || (!%clientId.isSuperAdmin && %opt != "tkserv" && %opt != "tkclient")) { Game::menuRequest(%clientId); return; } // PORT: the menu lists only these two for a public admin

	if(%opt == "moreop") { 
		Client::buildMenu(%clientId, "Server Options:", "ixsettings", true); 
		Client::addMenuItem(%clientId, "1Mine Settings", "mines");
		if($HaVoC::TurretPoints == TRUE)
			Client::addMenuItem(%clientId, "2Disable Turret Points", "tpoints off");
		else
			Client::addMenuItem(%clientId, "2Enable Turret Points", "tpoints on");
		if($HaVoC::TurretKillMessages == TRUE)
			Client::addMenuItem(%clientId, "3Disable Turret Messages", "tmess off");
		else
			Client::addMenuItem(%clientId, "3Enable Turret Messages", "tmess on");
		if($HaVoC::RandomMissions == TRUE)
			Client::addMenuItem(%clientId, "4Disable Random Missions", "ran off");
		else
			Client::addMenuItem(%clientId, "4Enable Random Missions", "ran on");
		Client::addMenuItem(%clientId, "5Random Mission Settings", "rans");		
		Client::addMenuItem(%clientId, "6DM/Hunter/Rabbit Settings", "death");
		if($HaVoC::Eye4anEye == TRUE)
			Client::addMenuItem(%clientId, "7Disable Eye for an Eye", "damage off");
		else
			Client::addMenuItem(%clientId, "7Enable Eye for an Eye", "damage on");
		Client::addMenuItem(%clientId, "8Additional Options...", "evenmore");
		return;
	}
	if(%opt == "evenmore") { 
		Client::buildMenu(%clientId, "Server Options:", "emore", true); 
		Client::addMenuItem(%clientId, "1BK Admin Warning", "aw");
		Client::addMenuItem(%clientId, "2BK Kick Limit", "kl");
		Client::addMenuItem(%clientId, "3Lightning Settings", "lit");
		if($HaVoC::AutoAssign) 
			Client::addMenuItem(%clientId, "4Disable " @ $HaVoC::AutoAssignTribe @ " Team Assign", "ass");
		else
			Client::addMenuItem(%clientId, "4Enable " @ $HaVoC::AutoAssignTribe @ " Team Assign", "ass");
		Client::addMenuItem(%clientId, "5Reset Server Defaults", "reset");
		return;
	}

	if(%opt == "death") { 
		Client::buildMenu(%clientId, "DM/Hunter/Rabbit Options:", "dp", true); 
		if($HaVoC::DMInventories == TRUE)
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
		if($HaVoC::DMSniperWeapons == TRUE)
			Client::addMenuItem(%clientId, "4Disable Sniper Weapons", "snipe off");		
		else
			Client::addMenuItem(%clientId, "4Enable Sniper Weapons", "snipe on");		
		if($HaVoC::DMFullWeapons == TRUE)
			Client::addMenuItem(%clientId, "5Disable Full Weapons", "full off");		
		else
			Client::addMenuItem(%clientId, "5Enable Full Weapons", "full on");		
		if($HaVoC::DMMines == TRUE)
			Client::addMenuItem(%clientId, "6Disable Mines", "mine off");		
		else
			Client::addMenuItem(%clientId, "6Enable Mines", "mine on");		
	}
	if(%opt == "rans") { 
		Client::buildMenu(%clientId, "Current Random Settings:", "ranset", true); 
		Client::addMenuItem(%clientId, "1Capture the Flag "@isonoff($HaVoC::RandomMissionTypes["Capture the Flag"]), "Capture the Flag");
		Client::addMenuItem(%clientId, "2Deathmatch "@isonoff($HaVoC::RandomMissionTypes["Deathmatch"]), "Deathmatch");
		Client::addMenuItem(%clientId, "3Multiple Team "@isonoff($HaVoC::RandomMissionTypes["Multiple Team"]), "Multiple Team");
		Client::addMenuItem(%clientId, "4Capture and Hold "@isonoff($HaVoC::RandomMissionTypes["Capture and Hold"]), "Capture and Hold");
		Client::addMenuItem(%clientId, "5Find and Retrieve "@isonoff($HaVoC::RandomMissionTypes["Find and Retrieve"]), "Find and Retrieve");
		Client::addMenuItem(%clientId, "6Defend and Destroy "@isonoff($HaVoC::RandomMissionTypes["Defend and Destroy"]), "Defend and Destroy");
		Client::addMenuItem(%clientId, "7Team Deathmatch "@isonoff($HaVoC::RandomMissionTypes["Team Deathmatch"]), "Team Deathmatch");
		Client::addMenuItem(%clientId, "8Additional Options...", "more");
		return;
	}
	if(%opt == "ran") {
		if(%cl == "off") {
			messageall(0, "SERVER: Random missions have been disabled.");
			$HaVoC::RandomMissions = FALSE;
		} else {
			messageall(0, "SERVER: Random missions are now in affect.");
			$HaVoC::RandomMissions = TRUE;
		}			
		Game::menuRequest(%clientId);
	}	
	if(%opt == "damage") {
		if(%cl == "off") {
			messageall(0, "SERVER: Hurting a teammate no longer does an equal amount of damage to the attacker.");
			$HaVoC::Eye4anEye = FALSE;
		} else {
			messageall(0, "SERVER: Hurting a teammate now also hurts the attacker after they reach "@$HaVoC::tkLimit@" TKs.");
			$HaVoC::Eye4anEye = TRUE;
		}			
		Game::menuRequest(%clientId);
	}	
	if(%opt == "tpoints") {
		if(%cl == "off") {
			messageall(0, "SERVER: Turrets no longer give the owner a point when they kill an enemy.");
			$HaVoC::TurretPoints = FALSE;
		} else {
			messageall(0, "SERVER: Turrets now give the owner a point when they kill an enemy.");		
			$HaVoC::TurretPoints = TRUE;
		}			
		Game::menuRequest(%clientId);
	}	
	if(%opt == "tmess") {
		if(%cl == "off") {
			messageall(0, "SERVER: Turrets no longer give \"killed by\" messages.");
			$HaVoC::TurretKillMessages = FALSE;
		} else {
			messageall(0, "SERVER: Turrets now give \"killed by\" messages.");		
			$HaVoC::TurretKillMessages = TRUE;
		}			
		Game::menuRequest(%clientId);
	}
	if(%opt == "mines") { 
		if($HaVoC::FriendlyMines) %wo = "Friendly"; else %wo = "Dangerous";
		Client::buildMenu(%clientId, "Current Mines: "@%wo, "chkmine", true); 
		Client::addMenuItem(%clientId, "1Friendly Mines", "true");
		Client::addMenuItem(%clientId, "2Dangerous Mines", "false");
		return;
	}
	if(%opt == "action") { 
		Client::buildMenu(%clientId, "Current Boot Time: " @ $HaVoC::StationTime, "aaction", true);
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
		Client::buildMenu(%clientId, "Current Kick Ban Time: " @ ($HaVoC::BanKickTime/60), "AKill", true);
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
		Client::addMenuItem(%clientId, "1Team Changing " @ isonoff($HaVoC::PATeamChange), "teamchange " @ $HaVoC::PATeamChange); 
		Client::addMenuItem(%clientId, "2Kicking " @ isonoff($HaVoC::PAKick), "kick " @ $HaVoC::PAKick);
		Client::addMenuItem(%clientId, "3Banning " @ isonoff($HaVoC::PABan), "ban " @ $HaVoC::PABan);
		Client::addMenuItem(%clientId, "4Change Mission " @ isonoff($HaVoC::PAMission), "mission " @ $HaVoC::PAMission); 
		Client::addMenuItem(%clientId, "5Team Damage " @ isonoff($HaVoC::PATeamDamage), "teamdamage " @ $HaVoC::PATeamDamage); 
		Client::addMenuItem(%clientId, "6Tourney Mode " @ isonoff($HaVoC::PATourneyMode), "tourney " @ $HaVoC::PATourneyMode); 
		Client::addMenuItem(%clientId, "7Time Limit " @ isonoff($HaVoC::PATimeLimit), "timelimit " @ $HaVoC::PATimeLimit); 
		Client::addMenuItem(%clientId, "8Additional Lockouts...", "additional"); 
		return; 
	} else if(%opt == "pvlockout") { 
		Client::buildMenu(%clientId, "Current Public Vote Lockouts:","PVLockouts", true);
		Client::addMenuItem(%clientId, "1Changing Mission " @ isonoff($HaVoC::PVMission), "changevote " @ $HaVoC::PVMission); 
		Client::addMenuItem(%clientId, "2Kicking " @ isonoff($HaVoC::PVKick), "kickvote " @ $HaVoC::PVKick);
		Client::addMenuItem(%clientId, "3Fair Teams " @ isonoff($HaVoC::PVFairTeams), "fairt " @ $HaVoC::PVFairTeams);
		Client::addMenuItem(%clientId, "4Admin " @ isonoff($HaVoC::PVAdmin), "adminvote " @ $HaVoC::PVAdmin); 
		Client::addMenuItem(%clientId, "5Tourney Mode " @ isonoff($HaVoC::PVTourneyMode), "tourney " @ $HaVoC::PVTourneyMode); 
		Client::addMenuItem(%clientId, "6Team Damage " @ isonoff($HaVoC::PVTeamDamage), "td " @ $HaVoC::PVTeamDamage); 
		if(!$HaVoC::PVTime) %word = " Off"; else %word = ": "@$HaVoC::PVTime;
		Client::addMenuItem(%clientId, "7Increase Time Vote"@%word, "inctime"); 
		Client::addMenuItem(%clientId, "8Additional Lockouts...", "morepv");
		return; 
	} else if(%opt == "pvote") { 
		Client::buildMenu(%clientId, "Public Voting Lockouts", "ixsettings", true); 		
	} else if(%opt == "purge") { 
		Client::sendMessage(%cl,3,"Purging All Public Admins of Admin Status."); 
		HaVoC_clearPA(%cl); 
		Client::sendMessage(%cl,3,"Purging Complete.");
		return; 
	} 
} 


function processMenuranset(%clientId, %opt) { if(!%clientId.isSuperAdmin) return; 
	if(%opt == "more") {
		Client::buildMenu(%clientId, "Current Random Settings:", "ranset", true); 
		Client::addMenuItem(%clientId, "1Flag Hunter "@isonoff($HaVoC::RandomMissionTypes["Flag Hunter"]), "Flag Hunter");
		Client::addMenuItem(%clientId, "2Kill the Rabbit "@isonoff($HaVoC::RandomMissionTypes["Kill the Rabbit"]), "Kill the Rabbit");
		return;
	}
	
	if($HaVoC::RandomMissionTypes[%opt]) {
		$HaVoC::RandomMissionTypes[%opt] = FALSE;
		messageall(0, "SERVER: Random missions now do not include \""@%opt@"\" mission types.");
	} else {
		$HaVoC::RandomMissionTypes[%opt] = TRUE;
		messageall(0, "SERVER: Random missions now include \""@%opt@"\" mission types.");
	}
	
	Game::menuRequest(%clientId);
}
function processMenuaaction(%clientId, %option) { if(!%clientId.isSuperAdmin) return; 
if($HaVoC::StationTime == %option) { 
	Client::sendMessage(%clientId,0,"SERVER: Station boot time is already "@%option@" seconds."); 
	return;
}
if(%option == 0) { messageAll(0, "SERVER: Stations now will never throw you out."); $HaVoC::StationTime = %option; } else {
	$HaVoC::StationTime = %option;
	messageAll(0, "SERVER: Stations will now throw you out after " @ %option @ " seconds.");
}	
}


function processMenudp(%clientId, %option) { if(!%clientId.isSuperAdmin) return; 
	%opt = getWord(%option, 0); 
	%t = getWord(%option, 1); 
	if(%opt == "inv") {
		if(%t == "on") {
			$HaVoC::DMInventories = True;
			messageall(0, "SERVER: Players now spawn with a inventory in Deathmatch missions.");
		} else {
			$HaVoC::DMInventories = False;
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
			$HaVoC::DMSniperWeapons = True;
			messageall(0, "SERVER: Sniper weapons are now allowed in Deathmatch, Flag Hunter, and Kill the Rabbit missions.");
		} else {
			$HaVoC::DMSniperWeapons = False;
			messageall(0, "SERVER: Sniper weapons are now not allowed in Deathmatch, Flag Hunter, and Kill the Rabbit missions.");
		}
		setDMweapons();
	} else if(%opt == "mine") {
		if(%t == "on") {
			$HaVoC::DMMines = True;
			messageall(0, "SERVER: Mines are now allowed in Deathmatch, Flag Hunter, and Kill the Rabbit missions.");
		} else {
			$HaVoC::DMMines = False;
			messageall(0, "SERVER: Mines are now not allowed in Deathmatch, Flag Hunter, and Kill the Rabbit missions.");
		}		
		setDMweapons();
	} else if(%opt == "full") {
		if(%t == "on") {
			$HaVoC::DMFullWeapons = True;
			messageall(0, "SERVER: Full weapons are now enabled in Deathmatch, Flag Hunter, and Kill the Rabbit missions.");
		} else {
			$HaVoC::DMFullWeapons = False;
			messageall(0, "SERVER: Full weapons are now disabled in Deathmatch, Flag Hunter, and Kill the Rabbit missions.");
		}
		setDMweapons();
	}
}

function processMenupvtlimit(%clientId, %option) { if(!%clientId.isSuperAdmin) return; 
if(%option == 0) {
	messageAll(0, "SERVER: Public Voting Access to Increase the Time Limit is now disabled.");
} else {
	messageAll(0, "SERVER: The Public can now vote to Increase the Time Limit " @ %option @ " minutes.");
}
$HaVoC::PVTime = %option;
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

function processMenuPVLockouts(%clientId, %option) { if(!%clientId.isSuperAdmin) return; 
	%opt = getWord(%option, 0); 
	%toggle = getWord(%option, 1); 
	if(%opt == "morepv") { 
		Client::buildMenu(%clientId, "Current Public Vote Lockouts:","PVLockouts", true);
		Client::addMenuItem(%clientId, "1Start Tourney Match " @ isonoff($HaVoC::PVStartMatch), "tourney " @ $HaVoC::PVStartMatch); 
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
		$HaVoC::PVMission = TRUE;
		$HaVoC::PVKick = TRUE;
		$HaVoC::PVAdmin = TRUE;
		$HaVoC::PVFairTeams = TRUE;
		$HaVoC::PVTourneyMode = TRUE;
		$HaVoC::PVStartMatch = TRUE;
		$HaVoC::PVTeamDamage = TRUE;
		$HaVoC::PVTime = 10;
	} else if(%opt == "alloff") { 
		%access = "EVERYTHING"; 
		%toggle = "true"; 
		$HaVoC::PVMission = FALSE;
		$HaVoC::PVKick = FALSE;
		$HaVoC::PVAdmin = FALSE;
		$HaVoC::PVFairTeams = FALSE;
		$HaVoC::PVTourneyMode = FALSE;
		$HaVoC::PVStartMatch = FALSE;
		$HaVoC::PVTeamDamage = FALSE;
		$HaVoC::PVTime = 0;
	} else if(%opt == "td") { 
		%access = "Team Damage"; 
		if(%toggle) 
			$HaVoC::PVTeamDamage = "false"; 
		else 
			$HaVoC::PVTeamDamage = "true"; 
	} else if(%opt == "changevote") { 
		%access = "Changing Mission"; 
		if(%toggle) 
			$HaVoC::PVMission = "false"; 
		else 
			$HaVoC::PVMission = "true"; 
	} else if(%opt == "kickvote") { 
		%access = "Kicking"; 
		if(%toggle) 
			$HaVoC::PVKick = "false"; 
		else 
			$HaVoC::PVKick = "true"; 
	} else if(%opt == "fairt") { 
		%access = "Fair Teams"; 
		if(%toggle) 
			$HaVoC::PVFairTeams = "false"; 
		else 
			$HaVoC::PVFairTeams = "true";
	} else if(%opt == "adminvote") { 
		%access = "Admin"; 
		if(%toggle) 
			$HaVoC::PVAdmin = "false"; 
		else 
			$HaVoC::PVAdmin = "true"; 
	} else if(%opt == "tourney") { 
		%access = "Tourney Mode"; 
		if(%toggle) 
			$HaVoC::PVTourneyMode = "false"; 
		else 
			$HaVoC::PVTourneyMode = "true"; 
	} else if(%opt == "start") { 
		%access = "Start Tourney Match"; 
		if(%toggle) 
			$HaVoC::PVStartMatch = "false"; 
		else 
			$HaVoC::PVStartMatch = "true"; 
	} 
	if(%toggle) 
		%toggle = "false"; 
	else 
		%toggle = "true"; 
	messageall(0, "SERVER: Public Voting Access to " @ %access @ " is now " @ isonoff(%toggle) @ "."); 
	Game::menuRequest(%clientId);
} 


function processMenuPALockouts(%clientId, %option) { if(!%clientId.isSuperAdmin) return; 
	%opt = getWord(%option, 0); 
	%toggle = getWord(%option, 1); 
	if(%opt == "additional") { 
		Client::buildMenu(%clientId, "Current Public Admin Lockouts:","PALockouts", true);
		Client::addMenuItem(%clientId, "1Start Tourney Match " @ isonoff($HaVoC::PAStartMatch), "start " @ $HaVoC::PAStartMatch); 
		Client::addMenuItem(%clientId, "2Server Options " @ isonoff($HaVoC::PAServerOptions), "modopt " @ $HaVoC::PAServerOptions); 
		Client::addMenuItem(%clientId, "3Turn ON all Options", "allon"); 
		Client::addMenuItem(%clientId, "4Turn OFF all Options", "alloff"); 
		return; 
	} else if(%opt == "allon") { 
		%access = "All Options"; 
		%toggle = "false"; 
		$HaVoC::PATeamChange = "true"; 
		$HaVoC::PAKick = "true"; 
		$HaVoC::PAStartMatch = "true";
		$HaVoC::PABan = "true"; 
		$HaVoC::PAMission = "true"; 
		$HaVoC::PATeamDamage = "true"; 
		$HaVoC::PATourneyMode = "true"; 
		$HaVoC::PATimeLimit = "true"; 
		$HaVoC::PAServerOptions = "true"; 
	} else if(%opt == "alloff") { 
		%access = "EVERYTHING"; 
		%toggle = "true"; 
		$HaVoC::PATeamChange = "false";
		$HaVoC::PAKick = "false";
		$HaVoC::PAStartMatch = "false";
		$HaVoC::PABan = "false";
		$HaVoC::PAMission = "false";
		$HaVoC::PATeamDamage = "false";
		$HaVoC::PATourneyMode = "false";
		$HaVoC::PATimeLimit = "false";
		$HaVoC::PAServerOptions = "false";
	} else if(%opt == "start") { 
		%access = "Start Tourney Match"; 
		if(%toggle) 
			$HaVoC::PAStartMatch = "false"; 
		else 
			$HaVoC::PAStartMatch = "true"; 
	} else if(%opt == "teamchange") { 
		%access = "Team Changing"; 
		if(%toggle) 
			$HaVoC::PATeamChange = "false"; 
		else 
			$HaVoC::PATeamChange = "true"; 
	} else if(%opt == "kick") { 
		%access = "Kicking"; 
		if(%toggle) 
			$HaVoC::PAKick = "false"; 
		else 
			$HaVoC::PAKick = "true"; 
	} else if(%opt == "ban") { 
		%access = "Banning"; 
		if(%toggle) 
			$HaVoC::PABan = "false"; 
		else 
			$HaVoC::PABan = "true";
	} else if(%opt == "mission") { 
		%access = "Changing Mission"; 
		if(%toggle) 
			$HaVoC::PAMission = "false"; 
		else 
			$HaVoC::PAMission = "true"; 
	} else if(%opt == "teamdamage") { 
		%access = "Team Damage"; 
		if(%toggle) 
			$HaVoC::PATeamDamage = "false"; 
		else 
			$HaVoC::PATeamDamage = "true"; 
	} else if(%opt == "tourney") { 
		%access = "Tourney Mode"; 
		if(%toggle) 
			$HaVoC::PATourneyMode = "false"; 
		else 
			$HaVoC::PATourneyMode = "true"; 
	} else if(%opt == "timelimit") { 
		%access = "Mission Time Limit"; 
		if(%toggle) 
			$HaVoC::PATimeLimit = "false"; 
		else 
			$HaVoC::PATimeLimit = "true"; 
	} else if(%opt == "modopt") { 
		%access = "HaVoC Mod Options"; 
		if(%toggle) 
			$HaVoC::PAServerOptions = "false"; 
		else 
			$HaVoC::PAServerOptions = "true"; 
	} else if(%opt == "teaminfo") { 
		%access = "Setting Team Info"; 
		if(%toggle) 
			$HaVoC::PATeamInfo = "false"; 
		else 
			$HaVoC::PATeamInfo = "true"; 
	} 
	if(%toggle) 
		%toggle = "false"; 
	else 
		%toggle = "true"; 
	messageall(0, "Public Admin Access to " @ %access @ " is now " @ isonoff(%toggle) @ "."); 
	Game::menuRequest(%clientId);
} 


function HaVoC_isFairTeam(%here, %dest) { %numTeams = getNumTeams(); %numPlayers = getNumClients(); for(%i = 0; %i < %numTeams; %i++) %numTeamPlayers[%i] = 0; for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); %team = Client::getTeam(%pl); %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1; } %least = 0; %most = 0; for(%i = 0; %i < %numTeams; %i++) { if(%numTeamPlayers[%i] > %numTeamPlayers[%most]) %most = %i; if(%numTeamPlayers[%i] < %numTeamPlayers[%least]) %least = %i; } if(%here == -1) %here = %most; if(((%numTeamPlayers[%dest] + 1) - (%numTeamPlayers[%here] - 1)) <= 1) return true; else return false; } 

function processMenuServerLvl(%clientId, %option) { if(!NihilityPort::paRight(%clientId, "ServerOptions")) return; $HaVoC::tkServerLvl = %option; 

if(%option == 0) {
	messageAll(0, "SERVER: TK protection level set to Zero. (Logging TK's only)."); 
	return;	
}	
if(%option == 1) messageAll(0, "SERVER: TK protection level set to One. (Auto Vote)."); if(%option == 2) messageAll(0, "SERVER: TK protection level set to Two. (Auto Vote Until Kicked)."); if(%option == 3) messageAll(0, "SERVER: TK protection level set to Three. (Auto Kick)."); 

} 

function processMenuClientLvl(%clientId, %option) { if(!NihilityPort::paRight(%clientId, "ServerOptions")) return; $HaVoC::tkClientLvl = %option; if(%option == 0) messageAll(0, "SERVER: Client TK vote option engaged. (From Options Menu)."); if(%option == 1) messageAll(0, "SERVER: Client TK kick option engaged. (From Options Menu)."); } 

function processMenuAKill(%clientId, %option) { if(!%clientId.isSuperAdmin) return; 
if($HaVoC::BanKickTime == %option) { 
	Client::sendMessage(%clientId,0,"SERVER: The current ban kick time is already " @ (%option/60) @ " minutes."); 
	return;
}
if(%option == 0) { messageAll(0, "SERVER: The ban time for getting kicked is now disabled."); $HaVoC::BanKickTime = %option; } else {
	$HaVoC::BanKickTime = %option;
	messageAll(0, "SERVER: Getting kicked will now also ban for " @ (%option/60) @ " minutes.");
}	
} 




function HaVoC_ServerLvlTxt() { if($HaVoC::tkServerLvl == 0) %tkText = "Logging TK's Only"; else if($HaVoC::tkServerLvl == 1) %tkText = "Votes at " @ $HaVoC::tkLimit @ " TK's"; else if($HaVoC::tkServerLvl == 2) %tkText = "Votes at " @ $HaVoC::tkLimit @ " TKs, Kicks at " @ $HaVoC::tkLimit * $HaVoC::tkMultiple @ " TK's"; else if($HaVoC::tkServerLvl == 3) %tkText = "Kicks at " @ $HaVoC::tkLimit @ " TK's"; else %tkText = "ERROR: Unkown Level"; return %tkText; } 

function HaVoC_ClientLvlTxt() { if($HaVoC::tkClientLvl == 0) %tkText = "Vote Option at " @ $HaVoC::tkLimit @ " TK's"; else if($HaVoC::tkClientLvl == 1) %tkText = "Kick Option at " @ $HaVoC::tkLimit @ "TK's"; else %tkText = "ERROR: Client Level set to Unkown Level"; return %tkText; } 

function HaVoC_setTeamKill(%victimId, %killerId) { 
	$tkVictim[%killerId] = %victimId; 
	$tkKiller[%victimId] = %killerId; 
	%killerId.tkKills++; 
	%trigger = %killerId.tkKills % $HaVoC::tkLimit; 
	%tkTopKills = $HaVoC::tkLimit * $HaVoC::tkMultiple; 
	if((%killerId.tkKills >= $HaVoC::tkLimit) && (!%trigger)) { 
		if($HaVoC::tkServerLvl) { 
			if($HaVoC::tkServerLvl != 3) { 
				if((%killerId.tkKills >= %tkTopKills) && ($HaVoC::tkServerLvl != 1)) { 
					messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing. Confirmed " @ %killerId.tkKills @ " Team Kills."); 
					Admin::Kick(-2, %killerId); 
					return; 
				} 
				%killerId.voteTarget = true;
				%victimId.selClient = HaVoC_getKiller(%victimId); 
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
	%trigger = %killerId.tkKills % $HaVoC::tkLimit; 
	if((%killerId.tkKills >= $HaVoC::tkLimit) && (!%trigger)) { 
		if($HaVoC::tkServerLvl) { 
			if($HaVoC::tkServerLvl != 3) { 
				if((%killerId.tkKills >= %tkTopKills) && ($HaVoC::tkServerLvl != 1))
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

function HaVoC_getKiller(%clientId) { return $tkKiller[%clientId]; } 

function HaVoC_getVictim(%clientId) { return $tkVictim[%clientId]; } 

function HaVoC_leaveGame(%clientId) { if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId]; if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId]; $tkKiller[%clientId] = %clientId; $tkVictim[%clientId] = %clientId; %clientId.tkKills = 0; %clientId.empTime = 0; return; } 

function HaVoC_joinGame(%clientId) { if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId]; if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId]; $tkVictim[%clientId] = %clientId; $tkKiller[%clientId] = %clientId; %clientId.tkKills = 0; %clientId.empTime = 0; } 

function HaVoC_clearPA(%admin) { if(%admin.isSuperAdmin) { %numPlayers = getNumClients(); for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); if(!%pl.isSuperAdmin && %pl.isAdmin) { %pl.isAdmin = false; %pl.adminNum = ""; Client::sendMessage(%pl,1,"Your Public Admin Status has been revoked."); Client::sendMessage(%admin,3,"Public Admin Status stripped from: " @ Client::getName(%pl) @ "."); } } } } 

function havocwhoison() { echo(" # cl: CLIENT nm: NAME ip: ADDRESS"); %numPlayers = getNumClients(); for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); %name = Client::getName(%pl); %ip = Client::getTransportAddress(%pl); echo(" " @ %i @ " cl: " @ %pl @ " nm: " @ %name @ " ip: " @ %ip); } } 

// ---------------------------------------------------------------------------------------------
// PORT (Modern Tribes 1.50). Not part of NIHILITY 1.4.3.
// The Tab menu only LISTS what a player may do; the option code itself is sent by the client.
// These functions apply the menu's own conditions (Game::menuRequest, adminmenu, the Torture
// page) to the code that arrived. A public admin's rights are the $HaVoC::PA* settings, or the
// $Special::PA*[n] ones when $HaVoC::PASpecial[n] is set for his password slot -- the same
// variables the menu reads. See Nihility.cs at the mod root for the list.
// ---------------------------------------------------------------------------------------------
function NihilityPort::paRight(%clientId, %right)
{
	if(%clientId.isSuperAdmin) return true;
	if(!%clientId.isAdmin) return false;
	%n = %clientId.adminNum;
	if($HaVoC::PASpecial[%n]) {
		if(%right == "Torture") return $Special::PATorture[%n];
		if(%right == "Gag") return $Special::PAGag[%n];
		if(%right == "Kick") return $Special::PAKick[%n];
		if(%right == "Ban") return $Special::PABan[%n];
		if(%right == "TeamChange") return $Special::PATeamChange[%n];
		if(%right == "StartMatch") return $Special::PAStartMatch[%n];
		if(%right == "TimeLimit") return $Special::PATimeLimit[%n];
		if(%right == "Mission") return $Special::PAMission[%n];
		if(%right == "ServerOptions") return $Special::PAServerOptions[%n];
		if(%right == "FairTeams") return $Special::PAFairTeams[%n];
		if(%right == "TeamDamage") return $Special::PATeamDamage[%n];
		if(%right == "TourneyMode") return $Special::PATourneyMode[%n];
		if(%right == "BalanceTeams") return $Special::PABalanceTeams[%n];
		return false;
	}
	if(%right == "Gag") return $HaVoC::PAGag;
	if(%right == "Kick") return $HaVoC::PAKick;
	if(%right == "Ban") return $HaVoC::PABan;
	if(%right == "TeamChange") return $HaVoC::PATeamChange;
	if(%right == "StartMatch") return $HaVoC::PAStartMatch;
	if(%right == "TimeLimit") return $HaVoC::PATimeLimit;
	if(%right == "Mission") return $HaVoC::PAMission;
	if(%right == "ServerOptions") return $HaVoC::PAServerOptions;
	if(%right == "FairTeams") return $HaVoC::PAFairTeams;
	if(%right == "TeamDamage") return $HaVoC::PATeamDamage;
	if(%right == "TourneyMode") return $HaVoC::PATourneyMode;
	if(%right == "BalanceTeams") return $HaVoC::PABalanceTeams;
	return false;
}

function NihilityPort::optAllowed(%clientId, %opt, %cl)
{
	if(%opt == "observe")
		return Observer::isObserver(%clientId);
	// "Watch": its three helpers (doneposs, setObsOrbit, e) are HaVoC's and are in no NIHILITY
	// release. The code moved the player onto a loose camera and "Stop Watching" could not bring
	// him back. Off until someone supplies them.
	if(%opt == "wat")
		return false;
	if(%opt == "tkopt") {
		%k = HaVoC_getKiller(%clientId);
		if(%k == "" || %k == %clientId) return false;
		return (%k.tkKills >= $HaVoC::tkLimit);
	}
	if(%opt == "vadmin")
		return ($HaVoC::PVAdmin && !%cl.isAdmin);
	if(%opt == "gag" || %opt == "ungag") {
		if(!NihilityPort::paRight(%clientId, "Torture") && !NihilityPort::paRight(%clientId, "Gag")) return false;
		if(%opt == "gag" && %cl.isSuperAdmin && %cl != %clientId) return false;
		return true;
	}
	if(%opt == "manip" || %opt == "execute" || %opt == "poison" || %opt == "strip" || %opt == "jus" || %opt == "unjus" || %opt == "poss" || %opt == "unposs" || %opt == "dan" || %opt == "undan") {
		if(%opt == "unposs" && %clientId.possessing && %clientId.poss == %cl) return true;
		if(!NihilityPort::paRight(%clientId, "Torture")) return false;
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
	if(%opt == "kick") return NihilityPort::paRight(%clientId, "Kick");
	if(%opt == "ban") return NihilityPort::paRight(%clientId, "Ban");
	if(%opt == "fteamchange") return NihilityPort::paRight(%clientId, "TeamChange");
	if(%opt == "etd" || %opt == "dtd") return NihilityPort::paRight(%clientId, "TeamDamage");
	if(%opt == "eft" || %opt == "dft") return NihilityPort::paRight(%clientId, "FairTeams");
	if(%opt == "forbalan" || %opt == "canbalan") return NihilityPort::paRight(%clientId, "BalanceTeams");
	if(%opt == "cffa" || %opt == "ctourney") return NihilityPort::paRight(%clientId, "TourneyMode");
	if(%opt == "smatch") return NihilityPort::paRight(%clientId, "StartMatch");
	if(%opt == "cmission") return NihilityPort::paRight(%clientId, "Mission");
	if(%opt == "ctimelimit") return NihilityPort::paRight(%clientId, "TimeLimit");
	if(%opt == "cctimelimit") return %clientId.isSuperAdmin;
	if(%opt == "HaVoC") return NihilityPort::paRight(%clientId, "ServerOptions");
	return true;
}

// the answer to a "Confirm ..." menu: "yes <client>" / "no <client>"
function NihilityPort::affirmAllowed(%clientId, %right, %opt)
{
	if(%right == "Admin") {
		if(!%clientId.isSuperAdmin) return false;
	} else if(!NihilityPort::paRight(%clientId, %right)) return false;
	%cl = getWord(%opt, 1);
	if(%right == "Torture" && %cl.isSuperAdmin && %cl != %clientId) return false;
	return true;
}

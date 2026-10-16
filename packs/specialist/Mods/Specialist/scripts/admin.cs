echo("Specialist Admin functions loaded...");

$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

function SpecialistCheckAutoAdmin(%clientId) {
	// This function checks to see if a player should become an admin
	// when they connect to the game.
	// By RCabrera for the Specialist mod, 7/10/00

	// Get client's name and IP
	%name = Client::getName(%clientId);
	%ip = Client::getTransportAddress(%clientId);

	// Compare client's name to all allowable admin names
	for (%i = 0; $Specialist::AdminName[%i] != ""; %i++) {

		if (%name == $Specialist::AdminName[%i]) {
			%matchFound = "true";
			%matchIndex = %i;
		}
	}

	// if a match is not found, we quit
	if (!%matchFound) {
		return;
	}
	
	// if a match is found,
	// dissect the client's IP address
	%ip = String::replace(%ip, ".", " ");	// replace all periods with spaces
	%ip = String::replace(%ip, ":", " ");	// replace all colons with spaces
	// unrolled loop
	%parsedIP[0] = getWord(%ip, 1);
	%parsedIP[1] = getWord(%ip, 2);
	%parsedIP[2] = getWord(%ip, 3);
	%parsedIP[3] = getWord(%ip, 4);
	// we ignore the port

	// then we check the client's IP and compare it to all allowable IPs for this client
	for (%j = 0; ($Specialist::AdminIP[%matchIndex, %j] != "" && %IPMatchFound != "true"); %j++) {
		
		if ($Specialist::AdminIP[%matchIndex, %j] != "") {

			// get the next admin IP
			%currentIP = $Specialist::AdminIP[%matchIndex, %j];

			// dissect it
			%currentIP = String::replace(%currentIP, ".", " ");	// replace all periods with spaces
			// unrolled loop
			%parsedCurrentIP[0] = getWord(%currentIP, 0);
			%parsedCurrentIP[1] = getWord(%currentIP, 1);
			%parsedCurrentIP[2] = getWord(%currentIP, 2);
			%parsedCurrentIP[3] = getWord(%currentIP, 3);

			// compare each section
			if (%parsedCurrentIP[0] == "*" || %parsedCurrentIP[0] == %parsedIP[0]) {
				if (%parsedCurrentIP[1] == "*" || %parsedCurrentIP[1] == %parsedIP[1]) {
					if (%parsedCurrentIP[2] == "*" || %parsedCurrentIP[2] == %parsedIP[2]) {
						if (%parsedCurrentIP[3] == "*" || %parsedCurrentIP[3] == %parsedIP[3]) {
							%IPMatchFound = "true";
						}
					}
				}
			}
		}
	}

	// if no IP match is found, exit
	if (!%IPMatchFound) {
		return;
	}

	// make the client an admin and announce
	if ($Specialist::AdminType[%matchIndex] == "SuperAdmin") {
		%clientId.isSuperAdmin = true;
		%clientId.isAdmin = true;
		messageAll(0, Client::getName(%clientId) @ " is now a SuperAdmin.");
		// echo("DEBUG: Superadmin status granted");
	}
	else {
		%clientId.isAdmin = true;
		messageAll(0, Client::getName(%clientId) @ " is now an Admin.");
		// echo("DEBUG: Admin status granted");
	}
}

function Admin::changeMissionMenu(%clientId) {
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

function Admin::LMAPenaltyMenu(%clientId) {

	Client::buildMenu(%clientId, "Leave Mission Area Penalty", "lmapenalty", true);
	%index = 1;

	if ($Specialist::LeaveMissionAreaPenalty != "Warn") {
		Client::addMenuItem(%clientId, %index @ "Warn", "lmawarn");
		%index++;
	}
	if ($Specialist::LeaveMissionAreaPenalty != "Damage") {
		Client::addMenuItem(%clientId, %index @ "Damage", "lmadamage");
		%index++;
	}
	if ($Specialist::LeaveMissionAreaPenalty != "DelayedKill") {
		Client::addMenuItem(%clientId, %index @ "Delayed Kill", "lmadelayedkill");
		%index++;
	}
	if ($Specialist::LeaveMissionAreaPenalty != "InstantKill") {
		Client::addMenuItem(%clientId, %index @ "Instant Death", "lmainstantkill");
		%index++;
	}

}

function processMenuLMAPenalty (%clientId, %options) {
	if(!%clientId.isAdmin) return; // PORT: menu codes come from the client
	%curItem = 0;
	%option = getWord(%options, 0);

	if (%option == "lmawarn") {
		$Specialist::LeaveMissionAreaPenalty = "Warn";
		messageAll(0, Client::getName(%clientId) @ " set the Leave Mission Area penalty to Warn.");
	}
	else if (%option == "lmadamage") {
		$Specialist::LeaveMissionAreaPenalty = "Damage";
		messageAll(0, Client::getName(%clientId) @ " set the Leave Mission Area penalty to Damage.");
	}
	else if (%option == "lmadelayedkill") {
		$Specialist::LeaveMissionAreaPenalty = "DelayedKill";
		messageAll(0, Client::getName(%clientId) @ " set the Leave Mission Area penalty to Delayed Kill.");
	}
	else if (%option == "lmainstantkill") {
		$Specialist::LeaveMissionAreaPenalty = "InstantKill";
		messageAll(0, Client::getName(%clientId) @ " set the Leave Mission Area penalty to Instant Death.");
	}
}

function Admin::equipmentOptionsMenu(%clientId) {
	// Presents equipment options
	// By RCabrera for the Specialist mod, 7/10/00

	Client::buildMenu(%clientId, "Equipment Options", "eoptions", true);
	%index = 1;

	// display Grenade Cores option
	Client::addMenuItem(%clientId, %index @ "Choose Grenade Core", "grencore");
	%index++;
	
	// display Mine Cores option
	Client::addMenuItem(%clientId, %index @ "Choose Mine Core", "minecore");
	%index++;

	// display Beacon Cores option
	Client::addMenuItem(%clientId, %index @ "Choose Beacon Core", "beaccore");
	%index++;
}

function processMenuEOptions (%clientId, %options) {
	%curItem = 0;
	%option = getWord(%options, 0);
	%index = 1;

	if (%option == "grencore") {
		Client::buildMenu(%clientId, "Choose Grenade Core", "cgrencore", true);

		// Display all player's grenade cores
		for (%r = 1; %r <= $GrenadeInitCounter; %r++) {

			%item = $Core[Grenade, %r];
			%count = Player::getItemCount(%clientId, %item);

			if (%count > 0) {
				Client::addMenuItem(%clientId, %index @ %item.description, %item);
				%index++;
			}
		}

	}
	else if (%option == "minecore") {
		Client::buildMenu(%clientId, "Choose Mine Core", "cminecore", true);

		// Display all player's mine cores
		for (%r = 1; %r <= $MineInitCounter; %r++) {

			%item = $Core[Mine, %r];
			%count = Player::getItemCount(%clientId, %item);

			if (%count > 0) {
				Client::addMenuItem(%clientId, %index @ %item.description, %item);
				%index++;
			}
		}
	}
	else if (%option == "beaccore") {
		Client::buildMenu(%clientId, "Choose Beacon Core", "cbeaccore", true);

		// Display all player's beacon cores
		for (%r = 1; %r <= $BeaconInitCounter; %r++) {

			%item = $Core[Beacon, %r];
			%count = Player::getItemCount(%clientId, %item);

			if (%count > 0) {
				Client::addMenuItem(%clientId, %index @ %item.description, %item);
				%index++;
			}
		}
	}
}

function processMenuCGrenCore (%clientId, %options) {
	// For choosing grenade core
	// by RCabrera for the Specialist mod, 7/11/00

	%option = getWord(%options, 0);

	%ok = false; // PORT: menu codes come from the client: only a registered grenade core is accepted
	for (%r = 1; %r <= $GrenadeInitCounter; %r++) if ($Core[Grenade, %r] == %option) %ok = true;
	if (!%ok) return;
	echo("DEBUG: Item: "@%option);
	%clientId.currentGrenadeCore = %option;
}

function processMenuCMineCore (%clientId, %options) {
	// For choosing mine core
	// by RCabrera for the Specialist mod, 7/11/00

	%option = getWord(%options, 0);

	%ok = false; // PORT: menu codes come from the client: only a registered mine core is accepted
	for (%r = 1; %r <= $MineInitCounter; %r++) if ($Core[Mine, %r] == %option) %ok = true;
	if (!%ok) return;
	echo("DEBUG: Item: "@%option);
	%clientId.currentMineCore = %option;
}

function processMenuCBeacCore (%clientId, %options) {
	// For choosing beacon core
	// by RCabrera for the Specialist mod, 7/11/00

	%option = getWord(%options, 0);
	%ok = false; // PORT: menu codes come from the client: only a registered beacon core is accepted
	for (%r = 1; %r <= $BeaconInitCounter; %r++) if ($Core[Beacon, %r] == %option) %ok = true;
	if (!%ok) return;
	echo("DEBUG: Item: "@%option);
	%clientId.currentBeaconCore = %option;
}

function processMenuCMType(%clientId, %options) {
	%curItem = 0;
	%option = getWord(%options, 0);
	%first = getWord(%options, 1);
	Client::buildMenu(%clientId, "Pick Mission", "cmission", true);
   
	for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++) {
		if(%i > 6) {
			Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option);
			break;
		}
		Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option);
	}
}

function processMenuCMission(%clientId, %option) {
	if(getWord(%option, 0) == "more") {
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
	if(%misType == "" || %misType == "Training")  return;
	for(%i = 0; true; %i++) {
		%misIndex = getWord($MLIST::MissionList[%mt], %i);
		if(%misIndex == %mi)
			break;
		if(%misIndex == -1)
			return;
	}
	if(%clientId.isAdmin) {
		messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
		Vote::changeMission();
		Server::loadMission(%misName);
	}
	else  {
		Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
		Game::menuRequest(%clientId);
	}
}

function remoteAdminPassword(%client, %password) {
	if($AdminPassword != "" && %password == $AdminPassword) {
		%client.isAdmin = true;
		%client.isSuperAdmin = true;
	}
}

function remoteSetPassword(%client, %password) {
	if(%client.isSuperAdmin)
		$Server::Password = %password;
}

function remoteSetTimeLimit(%client, %time) {
	%time = floor(%time);
	if(%time == $Server::timeLimit || (%time != 0 && %time < 1))
		return;
	if(%client.isAdmin) {
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
	else if ($curVoteAction == "norapeon") {
		activateAntiRapeMode();
	}
	else if ($curVoteAction == "norapeoff") {
		deactivateAntiRapeMode();
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

function Admin::startVote(%clientId, %topic, %action, %option) {
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

function Game::menuRequest(%clientId) {
	// This function's documentation by RCabrera

	// echo("DEBUG: Displaying Specialist menu to client:" @%clientId);

	%curItem = 0;
	Client::buildMenu(%clientId, "Options", "options", true);

	// if match has NOT started, and the server is NOT in tournament mode
	if(!$matchStarted || !$Server::TourneyMode) {

		// Allow players to change teams
		Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
	}

	// Make inventory options available
	Client::addMenuItem(%clientId, %curItem++ @ "Equipment options", "equipoptions");

	// if the player has selected a player's name in the menu
	if(%clientId.selClient) {
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);

		// if NO current vote is being taken, and the player is NOT an admin
		if($curVoteTopic == "" && !%clientId.isAdmin)  {

			// Allow them to start a vote to admin or kick the selected player
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
		}
		// if this player is an admin
		if(%clientId.isAdmin) {

			// Allow them to kick the selected player or change the selected player's team
			Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);

			// If the player is a superadmin
			if(%clientId.isSuperAdmin) {

				// Allow them to ban or admin the selected player
				Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
				Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
			}

			Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);

			// Allow them to gag/ungag the player
			if (%sel.gagged) {
				Client::addMenuItem(%clientId, %curItem++ @ "Ungag " @ %name, "ungag " @ %sel);
			}
			else {
				Client::addMenuItem(%clientId, %curItem++ @ "Gag " @ %name, "gag " @ %sel);
			}
		}

		// If this player has muted the selected player
		if(%clientId.muted[%sel]) {

			// Allow them to unmute the selected player
			Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
		}
		// otherwise
		else {
			// Allow them to mute the selected player
			Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
		}

		// If this player is in "observerOrbit" observer mode
		if(%clientId.observerMode == "observerOrbit") {

			// Allow them to observe the selected player
			Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
		}
	}

	// If a current vote is being taken, and this player has not voted yet
	if($curVoteTopic != "" && %clientId.vote == "")  {

		// offer them the options to vote
		Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
		Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
	}

	// If no current vote is being taken, and the client is NOT an admin
	else if($curVoteTopic == "" && !%clientId.isAdmin) {

		// Allow them to start a vote to change the mission
		Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");

		// Allow them to vote to turn on/off team damage
		if($Server::TeamDamageScale == 1.0)
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");

		// Allow them to vote for Anti-Rape mode
		if (!$Specialist::AntiRapeMode) {
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to activate Anti-Rape mode", "vnorapeon");
		}
		else {
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to deactivate Anti-Rape mode", "vnorapeoff");
		}
              
		// If the server is in tournament mode
		if($Server::TourneyMode) {

			// Give them the option to vote to enter Free-for-all mode
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");

			// If a countdown has not started, and the match has not started
			if(!$CountdownStarted && !$matchStarted) {

				// Let them vote to start the match
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
			}
		}
		// if the server is NOT in tournament mode
		else {
			// They can vote to enter tournament mode
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
		}
	}

	// If the client is an admin
	else if(%clientId.isAdmin) {

		// They can change the mission
		Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");

		// They can enable/disable team damage
		if($Server::TeamDamageScale == 1.0)
			Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");

		// They can change to Anti-Rape mode
		if (!$Specialist::AntiRapeMode) {
			Client::addMenuItem(%clientId, %curItem++ @ "Activate Anti-Rape mode", "norapeon");
		}
		else {
			Client::addMenuItem(%clientId, %curItem++ @ "Deactivate Anti-Rape mode", "norapeoff");
		}

		// They can change the LeaveMissionArea penalty
		Client::addMenuItem(%clientId, %curItem++ @ "Change LMA Penalty", "lmapenalty");

		// They can change to FFA or tournament mode
		if($Server::TourneyMode)  {
			Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");

			if(!$CountdownStarted && !$matchStarted) {
				// They can force a match start
				Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
			}
		}
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");

		// They can set the time limit
		Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");

		// They can reset the server settings
		Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
	}

	// if they are using a personal skin
	if (%clientId.usePSkin) {
		// They can use the team's skin
		Client::addMenuItem(%clientId, (%curItem++ % 10) @ "Use Team Skin", "useTSkin"); // PORT: a tenth entry showed as key 1 + "0Use ..." (key 1 was taken); it is key 0 now
	}
	else {
		// They can use their own skin
		Client::addMenuItem(%clientId, (%curItem++ % 10) @ "Use Personal Skin", "usePSkin"); // PORT: same
	}
}

function remoteSelectClient(%clientId, %selId) {

	if(%clientId.selClient != %selId) {
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

function processMenuFPickTeam(%clientId, %team) {
	if(%clientId.isAdmin)
		processMenuPickTeam(%clientId.ptc, %team, %clientId);
	%clientId.ptc = "";
}

function processMenuPickTeam(%clientId, %team, %adminClient) {
	checkPlayerCash(%clientId);
	if(%team != -1 && %team == Client::getTeam(%clientId))
		return;

	if(%clientId.observerMode == "justJoined") {
		%clientId.observerMode = "";
		centerprint(%clientId, "");
	}

	if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2) {
		if(Observer::enterObserverMode(%clientId))  {
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

	if(%team == -1) {
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
	if($Server::TourneyMode && !$CountdownStarted) {
		bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
		%clientId.notready = true;
	}
}

function processMenuOptions(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);

	if (%opt == "norapeon" && %clientId.isAdmin) { // PORT: menu codes come from the client
		activateAntiRapeMode();
		return;
	}
	else if (%opt == "norapeoff" && %clientId.isAdmin) { // PORT: menu codes come from the client
		deactivateAntiRapeMode();
		return;
	}
	else if (%opt == "useTSkin") {
		%clientId.usePSkin = "false";
		Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
		return;
	}
	else if (%opt == "usePSkin") {
		%clientId.usePSkin = "true";
		Client::setSkin(%clientId, $Client::info[%clientId, 0]);
		return;
	}
	else if(%opt == "fteamchange") {
		%clientId.ptc = %cl;
		Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
		Client::addMenuItem(%clientId, "0Observer", -2);
		Client::addMenuItem(%clientId, "1Automatic", -1);
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		return;
	}      
	else if(%opt == "changeteams") {
		if(!$matchStarted || !$Server::TourneyMode) {
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
	else if(%opt == "unmute") {
		%clientId.muted[%cl] = "";
	}
	else if(%opt == "gag" && %clientId.isAdmin) { // PORT: menu codes come from the client
		%cl.gagged = true;
		Client::sendMessage(%cl, $MsgTypeGame, Client::GetName(%clientId) @ " has gagged you.");
	}
	else if(%opt == "ungag" && %clientId.isAdmin) { // PORT: menu codes come from the client
		%cl.gagged = "";
		Client::sendMessage(%cl, $MsgTypeGame, Client::GetName(%clientId) @ " has ungagged you.");
	}
	else if(%opt == "vkick") {
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
	}
	else if(%opt == "vadmin") {
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
	}
	else if(%opt == "vsmatch")
		Admin::startVote(%clientId, "start the match", "smatch", 0);
	else if(%opt == "vnorapeon")
		Admin::startVote(%clientId, "activate Anti-Rape mode", "norapeon", 0);
	else if(%opt == "vnorapeoff")
		Admin::startVote(%clientId, "deactivate Anti-Rape mode", "norapeoff", 0);
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
	else if(%opt == "voteYes" && %cl == $curVoteCount) {
		%clientId.vote = "yes";
		centerprint(%clientId, "", 0);
	}
	else if(%opt == "voteNo" && %cl == $curVoteCount) {
		%clientId.vote = "no";
		centerprint(%clientId, "", 0);
	}
	else if(%opt == "kick") {
		Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
		Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if(%opt == "admin") {
		Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
		Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if(%opt == "ban") {
		Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
		Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if(%opt == "smatch")
		Admin::startMatch(%clientId);
	else if(%opt == "vcmission" || %opt == "cmission") {
		Admin::changeMissionMenu(%clientId, %opt == "cmission");
		return;
	}
	else if(%opt == "lmapenalty") {
		Admin::LMAPenaltyMenu(%clientId, %opt == "lmapenalty");
		return;
	}
	else if(%opt == "equipoptions") {
		Admin::equipmentOptionsMenu(%clientId, %opt == "equipoptions");
		return;
	}
	else if(%opt == "ctimelimit") {
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
	else if(%opt == "reset") {
		Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
		Client::addMenuItem(%clientId, "1Reset", "yes");
		Client::addMenuItem(%clientId, "2Don't Reset", "no");
		return;
	}
	else if(%opt == "observe") {
		Observer::setTargetClient(%clientId, %cl);
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuKAffirm(%clientId, %opt) {
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

function processMenuRAffirm(%clientId, %opt) {
	if(%opt == "yes" && %clientId.isAdmin) {
		messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
		Server::refreshData();
	}
	Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt) {
	remoteSetTimeLimit(%clientId, %opt);
}

function activateAntiRapeMode() {
	$Specialist::AntiRapeMode = "true";
}

function deactivateAntiRapeMode() {
	$Specialist::AntiRapeMode = "false";
}

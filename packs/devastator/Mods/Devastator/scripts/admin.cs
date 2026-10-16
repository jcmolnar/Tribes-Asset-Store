$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;
$TempKickBanTime = 180;

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
   if($AdminPassword != "" && %password == $AdminPassword)
   {
      %client.isAdmin = true;
      %client.isSuperAdmin = true;
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
	if(%admin == -1 || %admin.isAdmin || %admin.isSuperAdmin) {
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
	if(%admin == -1 || %admin.isAdmin || %admin.isSuperAdmin) {
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

function Admin::setBaseRapeEnable(%admin, %enabled)
{
	if(%admin == -1 || %admin.isAdmin || %admin.isSuperAdmin) {
		if(%enabled) {
			$Server::BaseRapeScale = 1;
			if(%admin == -1)
				messageAll(0, "Base Rape set to ENABLED by consensus.");
			else
				messageAll(0, Client::getName(%admin) @ " ENABLED Base Rape.");
		}
		else {
			$Server::BaseRapeScale = 0;
			if(%admin == -1)
				messageAll(0, "Base Rape set to DISABLED by consensus.");
			else
				messageAll(0, Client::getName(%admin) @ " DISABLED Base Rape.");
		}
	}
}

function Admin::kick(%admin, %client, %ban, %msg)
{
	%name = Client::getName(%client);
	echo(%admin@", "@%client@", "@%name@", "@%msg@", banned?: "@%ban);
	if(%ban && !%admin.isSuperAdmin)
		return;     
	if(%ban) {
		%word = "banned";
		%cmd = "BAN: ";
	}
	else {
		%word = "kicked";
		%cmd = "KICK: ";
	}
	if(IsIce(%client) == TRUE)
		return;
	if(%client.isSuperAdmin) {
		if(%admin == -1)
			messageAll(0, "A super admin cannot be " @ %word @ ".");
		else
			Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
		return;
	}
	if(%msg == "")
		%msg = $Server::SIName@": you just got "@%word;
	if(%admin == "Server") {
		%ip = Client::getTransportAddress(%client);
		echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);
		if(%ip == "")
			return;
		if(%ban)
			BanList::add(%ip, 1800);
		else
			BanList::add(%ip,$TempKickBanTime);
		MessageAll(0,$Server::SIName@": "@%name@" was "@%word@", take note not to piss me off.");
		Net::kick(%client,%msg);
	}
	else if(%admin == -1 || %admin.isAdmin || %admin.isSuperAdmin) {
		%ip = Client::getTransportAddress(%client);
		echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);
		if(%ip == "")
			return;
		if(%ban)
			BanList::add(%ip, 1800);
		else
			BanList::add(%ip,$TempKickBanTime);
		if(%admin == -1) {
			MessageAll(0,%name @ " was " @ %word @ " from vote.");
			Net::kick(%client,"You were " @ %word @ " by  consensus.");
		}
		else {
			MessageAll(0,%name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
			Net::kick(%client,"You were " @ %word @ " by " @ Client::getName(%admin));
		}
	}
}

function Admin::God(%admin, %client, %god)
{
	if(%admin == -1 || %admin.isAdmin || %admin.isSuperAdmin) {
		if(%god && !%admin.isSuperAdmin)
			return;
		%ip = Client::getTransportAddress(%client);
		echo("God " @ %admin @ " " @ %client @ " " @ %ip);
		if(%ip == "")
			return;
		%name = Client::getName(%client);
		if(AreGod(%client) == true || AreGod(%client) == ultra || AreGod(%client) == perfect)
			return;
		if(%admin != -1) {
			MessageAll(0,%name @ " was made into a Demi-God by " @ Client::getName(%admin) @ ".");
			%CurPack = Player::getMountedItem(%client,$BackpackSlot);
			Player::UnmountItem(%client,$BackpackSlot);
			Player::setItemCount(%client,%CurPack,0);
			Player::setItemCount(%client,DemiPack,1);
			Player::mountItem(%client,DemiPack,$BackpackSlot);
			MakeGod(%client,"DEMI");
			if(%client.GODpref == "")
				%client.GODpref = "DEMI";
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
   else if($curVoteAction == "ebr")
      Admin::setBaseRapeEnable(-1, true);
   else if($curVoteAction == "dbr")
      Admin::setBaseRapeEnable(-1, false);
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
	%time = getIntegerTime(true) >> 5;
	%diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time;
	if(%diff > 0) {
		Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
		return;
	}
	if($curVoteTopic == "") {
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
		Client::sendMessage(%clientId, 0, "Voting already in progress.");
}

function Game::menuRequest(%clientId)
{
	%curItem = 0;
	%CName = Client::getName(%clientId);
	Client::buildMenu(%clientId, "Options", "options", true);
//>	*Everyone Opts*	<//
	if(!$matchStarted || !$Server::TourneyMode) {
		Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
		Client::addMenuItem(%clientId, %curItem++ @ "Weapon Options", "weaponoptions");
	}
//>	*When you select someone Opts*	<//
	if(%clientId.selClient) {
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);
		if($curVoteTopic == "" && !%clientId.isAdmin) {
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
		}
//>	>	*When an Admin Selects someone Opts*	<//
		if(%clientId.isAdmin||%clientId.isSuperAdmin) {
			if(IsIce(%sel) != TRUE) {
				Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
				Client::addMenuItem(%clientId, %curItem++ @ "Make "@%name@" into Demi-God", "god " @ %sel);
			}
//>	>	>	*When a Super Admin Selects someone Opts*	<//
			if(%clientId.isSuperAdmin) {
				if(IsIce(%sel) != TRUE)
					Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
				Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
			}
			Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
		}
		if(%clientId.muted[%sel])
			Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
		if((AreGOD(%clientId) == "ultra" || AreGod(%clientId) == perfect || IsIce(%clientId) == TRUE) && IsIce(%sel) != TRUE)
			Client::addMenuItem(%clientId, %curItem++ @ "Manipulate " @ %name, "supreme " @ %sel);
		if(%clientId.observerMode == "observerOrbit")
			Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
	}
//>	*Everyone vote Opts*	<//
	if($curVoteTopic != "" && %clientId.vote == "") {
		Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
		Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
	}
//>	*NON Admin Vote Initiation Opts*	<//
	else if($curVoteTopic == "" && !%clientId.isAdmin) {
		Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
		if($Server::TeamDamageScale == 1.0)
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
		if($Server::BaseRapeScale == 1.0)
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable Base Rape", "vdbr");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable Base Rape", "vebr");
		if($Server::TourneyMode) {
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
			if(!$CountdownStarted && !$matchStarted)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
		}
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
	}
//>	*Admin only Opts*	<//
	else if(%clientId.isAdmin||%clientId.isSuperAdmin) {
		Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
		if($Server::TeamDamageScale == 1.0)
			Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
		if($Server::BaseRapeScale == 1.0)
			Client::addMenuItem(%clientId, %curItem++ @ "Disable Base Rape", "dbr");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable Base Rape", "ebr");
		if($Server::TourneyMode) {
			Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
			if(!$CountdownStarted && !$matchStarted)
				Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
		}
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
		Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
		Client::addMenuItem(%clientId, %curItem++ @ "Set GOD preferences", "GODprefs");
	}
}

function remoteSelectClient(%clientId, %selId)
{
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

function processMenuFPickTeam(%clientId, %team)
{
	if(%clientId.isAdmin)
		processMenuPickTeam(%clientId.ptc, %team, %clientId);
	%clientId.ptc = "";
}

function processMenuWOptions(%clientId, %opt)
{
	echo(%opt@" selected");
	%CurWeap = Player::getMountedItem(%clientId,$WeaponSlot);
	if(%opt == "nade") {
		%curItem = 0;
		Client::buildMenu(%clientId, "Grenade Type Options:", "NadeType", true);
		Client::addMenuItem(%clientId, %curItem++ @$WeapModeName[Handgrenade,%curItem],%curItem);
		Client::addMenuItem(%clientId, %curItem++ @$WeapModeName[Handgrenade,%curItem],%curItem);
		Client::addMenuItem(%clientId, %curItem++ @$WeapModeName[Handgrenade,%curItem],%curItem);
		Client::addMenuItem(%clientId, %curItem++ @$WeapModeName[Handgrenade,%curItem],%curItem);
		Client::addMenuItem(%clientId, %curItem++ @$WeapModeName[Handgrenade,%curItem],%curItem);
		Client::addMenuItem(%clientId, %curItem++ @$WeapModeName[Handgrenade,%curItem],%curItem);
		Client::addMenuItem(%clientId, %curItem++ @$WeapModeName[Handgrenade,%curItem],%curItem);
		Client::addMenuItem(%clientId, %curItem++ @$WeapModeName[Handgrenade,%curItem],%curItem);
	}
	else if(%opt == "prima")
		$WeapMode[%clientId,%CurWeap] = 1;
	else if(%opt == "secon")
		$WeapMode[%clientId,%CurWeap] = 2;
	else if(%opt == "terti")
		$WeapMode[%clientId,%CurWeap] = 3;
	if(%opt == "prima" || %opt == "secon" || %opt == "terti")
		Weapon::descriptionMSG(%clientId, %CurWeap,"OnMount");
	else if(%opt == "msg1") {
		if($ShowWeapMountMsg[%clientId] == false) {
			$ShowWeapMountMsg[%clientId] = true;
			bottomprint(%clientId,"<jc>Weapon Descriptions Enabled",1);
		}
		else if($ShowWeapMountMsg[%clientId] == true || $ShowWeapMountMsg[%clientId] == "") {
			$ShowWeapMountMsg[%clientId] = false;
			bottomprint(%clientId,"<jc>Weapon Descriptions Disabled",1);
		}		
	}		
	else if(%opt == "msg2") {
		if($ShowWeapBuyMsg[%clientId] != true) {
			$ShowWeapBuyMsg[%clientId] = true;
			bottomprint(%clientId,"<jc>Inventory Shopping List Enabled",1);
		}
		else if($ShowWeapBuyMsg[%clientId] == true) {
			$ShowWeapBuyMsg[%clientId] = false;
			bottomprint(%clientId,"<jc>Inventory Shopping List Disabled",1);		
		}		
	}
}

function processMenuNadeType(%clientId, %option)
{
	if($WeapModeName[Handgrenade,%option] == "") return; // PORT: only one of the mod's own eight grenade modes
	$WeapMode[%clientId,Handgrenade] = %option;
	Weapon::descriptionMSG(%clientId,"Handgrenade","OnMount");
}

function processMenuPickTeam(%clientId, %team, %adminClient)
{
	checkPlayerCash(%clientId);
	if(%team != -1 && %team == Client::getTeam(%clientId))
		return;
	if(%clientId.observerMode == "justJoined") {
		%clientId.observerMode = "";
		centerprint(%clientId, "");
	}
	if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2) {
		if(Observer::enterObserverMode(%clientId)) {
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
	if(%opt == "fteamchange") {
		%clientId.ptc = %cl;
		Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
		Client::addMenuItem(%clientId, "0Observer", -2);
		Client::addMenuItem(%clientId, "1Automatic", -1);
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
		Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		return;
	}      
	else if(%opt == "weaponoptions") {
		%CurWeap = Player::getMountedItem(%clientId,$WeaponSlot);
		%curItem = -1;
		Client::buildMenu(%clientId,"Weapon Options:","WOptions", true);
		Client::addMenuItem(%clientId,%curItem++@"Hand Grenade Type","nade");
		if($FireModes[%CurWeap] >= 1)
			Client::addMenuItem(%clientId,%curItem++@$WeapModeName[%CurWeap,1],"prima");
		if($FireModes[%CurWeap] >= 2)
			Client::addMenuItem(%clientId,%curItem++@$WeapModeName[%CurWeap,2],"secon");
		if($FireModes[%CurWeap] >= 3)
			Client::addMenuItem(%clientId,%curItem++@$WeapModeName[%CurWeap,3],"terti");
		if($FireModes[%CurWeap] >= 4)
			Client::addMenuItem(%clientId,%curItem++@$WeapModeName[%CurWeap,4],"WhatIsThis?");
		if($ShowWeapMountMsg[%clientId] == false)
			Client::addMenuItem(%clientId,%curItem++@"Enable Weapon Descriptions","msg1");
		else if($ShowWeapMountMsg[%clientId] == true || $ShowWeapMountMsg[%clientId] == "")
			Client::addMenuItem(%clientId,%curItem++@"Disable Weapon Descriptions","msg1");
		if($ShowWeapBuyMsg[%clientId] != true)
			Client::addMenuItem(%clientId,%curItem++@"Enable Inventory Purchase List","msg2");
		else if($ShowWeapBuyMsg[%clientId] == true)
			Client::addMenuItem(%clientId,%curItem++@"Disable Inventory Purchase List","msg2");
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
	else if(%opt == "unmute")
		%clientId.muted[%cl] = "";
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
	else if(%opt == "vetd")
		Admin::startVote(%clientId, "enable team damage", "etd", 0);
	else if(%opt == "vdtd")
		Admin::startVote(%clientId, "disable team damage", "dtd", 0);
	else if(%opt == "etd")
		Admin::setTeamDamageEnable(%clientId, true);
	else if(%opt == "dtd")
		Admin::setTeamDamageEnable(%clientId, false);
	else if(%opt == "vebr")
		Admin::startVote(%clientId, "enable Base Rape", "ebr", 0);
	else if(%opt == "vdbr")
		Admin::startVote(%clientId, "disable Base Rape", "dbr", 0);
	else if(%opt == "ebr")
		Admin::setBaseRapeEnable(%clientId, true);
	else if(%opt == "dbr")
		Admin::setBaseRapeEnable(%clientId, false);
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
		Client::buildMenu(%clientId, "Confirm kick:", "KAffirm", true);
		Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if(%opt == "supreme") {
		Client::buildMenu(%clientId, "Manipulate:", "SAffirm", true);
		Client::addMenuItem(%clientId, "1Heal " @ Client::getName(%cl),"Heal " @ %cl);
		Client::addMenuItem(%clientId, "2Destroy " @ Client::getName(%cl),"Destroy " @ %cl);
		Client::addMenuItem(%clientId, "3Effect " @ Client::getName(%cl),"Effect " @ %cl);
		return;
	}
	else if(%opt == "god") {
		Client::buildMenu(%clientId, "Confirm God:", "GAffirm", true);
		Client::addMenuItem(%clientId, "1Make " @ Client::getName(%cl)@" into a Demi-God", "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Make " @ Client::getName(%cl)@" into a Demi-God", "no " @ %cl);
		return;
   	}
	else if(%opt == "admin") {
		Client::buildMenu(%clientId, "Confirm admim:", "AAffirm", true);
		Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if(%opt == "ban") {
		Client::buildMenu(%clientId, "Confirm Ban:", "BAffirm", true);
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
	else if(%opt == "GODprefs") {
		Client::buildMenu(%clientId, "Change GOD preferences:", "GODpref", true);
		Client::addMenuItem(%clientId, "0Be a Light GOD","Light");
		Client::addMenuItem(%clientId, "1Be a Dark GOD","Dark");
		Client::addMenuItem(%clientId, "2Be a Demi GOD","Demi");
		Client::addMenuItem(%clientId, "3Don't be a GOD","None");
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

function processMenuKAffirm(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes")
		Admin::kick(%clientId, getWord(%opt, 1));
	Game::menuRequest(%clientId);
}

function processMenuGAffirm(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes")
		Admin::God(%clientId, getWord(%opt, 1));
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
	if(getWord(%opt, 0) == "yes") {
		if(%clientId.isSuperAdmin) {
			%cl = getWord(%opt, 1);
			%cl.isAdmin = true;
			messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
		}
	}
	Game::menuRequest(%clientId);
}

function processMenuSAffirm(%clientId, %opt)
{
	if(AreGOD(%clientId) != "ultra" && AreGod(%clientId) != perfect) return; // PORT: menu codes come from the client; same test as the menu entry (admin.cs:507)
	%victim = getWord(%opt,1);
	%opt = getWord(%opt,0);
	%Name = Client::getName(%clientId);
	%VName = Client::getName(%victim);
	if(!String::ICompare(Client::getGender(%victim), "Male"))
		%victimGender = "his";
	else
		%victimGender = "her";
	if(%opt == "Heal") {
		Client::sendMessage(%victim, 0,"You were healed by "@%Name@".");
		GameBase::setDamageLevel(%victim,0);
	}
	else if(%opt == "Destroy")
		Player::killOff(%victim,%clientId,$GODDamageType,"BlowUp");
	else if(%opt == "Effect") {
		Client::buildMenu(%clientId, "Manipulate:", "SEffect ", true);
		Client::addMenuItem(%clientId, "1Catch: " @%VName@" on Fire","SEburn " @ %victim);
		Client::addMenuItem(%clientId, "2Freeze: " @%VName,"SEfreeze " @ %victim);
		Client::addMenuItem(%clientId, "3Tazer: " @%VName,"SEtazer " @ %victim);
		Client::addMenuItem(%clientId, "4EMP: " @%VName,"SEemp " @ %victim);
		Client::addMenuItem(%clientId, "5Make: " @%VName@" Party","SEparty " @ %victim);
		Client::addMenuItem(%clientId, "6Make: " @%VName@" Temporarily Blind","SEblind " @ %victim);
		Client::addMenuItem(%clientId, "7Make: " @%VName@" Drunk","SEdrunk " @ %victim);
		Client::addMenuItem(%clientId, "8Send: " @%VName@" to "@%victimGender@" flag","SEflag " @ %victim);
	}
	if(%opt != "Effect")
		Client::sendMessage(%client, 0,"Now "@%opt@"ing "@%VName@".");
}

function processMenuSEffect(%clientId, %opt)
{
	if(AreGOD(%clientId) != "ultra" && AreGod(%clientId) != perfect) return; // PORT: menu codes come from the client; same test as the menu entry (admin.cs:507)
	%victim = getWord(%opt,1);
	%type = getWord(%opt,0);
	%pl = Client::getOwnedObject(%clientId);
	%vpl =Client::getOwnedObject(%victim);
	echo("Selection Effection, "@%type@", "@%victim);
	if(AreGOD(%victim) != FALSE && AreGOD(%victim) != Ultra && AreGOD(%victim) != Perfect)
		Player::trigger(%victim,$BackpackSlot,false);
	else if(AreGOD(%victim) == Ultra) {
		Client::sendMessage(%clientId, 0,"You cannot Effect a Super GOD.");
		return;
	}
	else if(AreGOD(%victim) == Perfect) {
		Client::sendMessage(%clientId, 0,"No... its too late...");
		return;
	}
	if(%type == "SEburn")
		SetOnFire(%vpl,%pl,20);
	else if(%type == "SEfreeze")
		Freeze(%victim);
	else if(%type == "SEtazer")
		TazeEm(%victim,30);
	else if(%type == "SEemp")
		EMPsystem(%victim,10);
	else if(%type == "SEparty")
		GetFunky(%victim);
	else if(%type == "SEblind")
		TempBlind(%victim,"");
	else if(%type == "SEdrunk")
		Staggerin(%victim,30);
	else if(%type == "SEflag")
		GodPower::WarpBack(%victim,"flag");
	Game::menuRequest(%clientId);
}

function processMenuRAffirm(%clientId, %opt)
{
	if(%opt == "yes" && %clientId.isAdmin) {
		messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
		Server::refreshData();
	}
	Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{
	remoteSetTimeLimit(%clientId, %opt);
}

function processMenuGODpref(%clientId,%type)
{
	if(!%clientId.isAdmin && !%clientId.isSuperAdmin) return; // PORT: menu codes come from the client; the entry is in the admin-only block (admin.cs:556)
	if(IsIce(%clientId)) {
		Client::sendMessage(%clientId, 0,"Ice, are you forgetting who you are?");
		return;
	}
	%clientId.GODpref = %type;
	if(%type == "None")
		%client.GODpref = "";		
	if(%type == "Light" || %type == "Dark" || %type == "Demi")
		Client::sendMessage(%clientId, 0,"You must respawn before you can be a "@%type@" GOD.");
	else if(%type == "None")
		Client::sendMessage(%clientId, 0,"You must respawn before you can be mortal again.");
	echo("Client "@%clientId@"'s GODpref: "@%clientId.GODpref);
}
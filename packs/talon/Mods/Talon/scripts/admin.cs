$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;
$ArmorDefault[1] = "Energy";
$ArmorDefault[2] = "Autoheal";
$ArmorDefault[3] = "Health";
$ArmorDefault[4] = "Health";
$ArmorDefault[5] = "Autoheal";
$ArmorDefault[6] = "Autoheal";

// List of specs that require setting other than just changing $ArmorSpec
// Energy, Armor, Autoheal, Jamming, Construction

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
   if($AdminPassword != "" && %password == $AdminPassword) // PORT: the author's second, hard-coded password clause is removed
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

	else if($curVoteOption == "vtime")
	{
		%time = floor(%time);
		if(%time == $Server::timeLimit || (%time != 0 && %time < 1))
			return;
		%nutime = $Server::timeLimit + 900;
		$Server::timeLimit = %nutime;
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
	%player = Client::getOwnedObject(%clientId);
   Client::buildMenu(%clientId, "Options", "options", true);
   if(!$matchStarted || !$Server::TourneyMode)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
   }
   if($curVoteTopic != "" && %clientId.vote == "")
   {
	Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
	Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
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
         Client::addMenuItem(%clientId, %curItem++ @ "Change KeepTeam status", "keepteamch " @ %sel);
      }
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
      if(%clientId.observerMode == "observerOrbit")
         Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
   }
   else
   {
	Client::addMenuItem(%clientId, %curItem++ @ "Voting options", "voteopts");
	Client::addMenuItem(%clientId, %curItem++ @ "Talon options", "newopts");
	%MG = Player::getMountedItem(%player,$WeaponSlot);
	%armor = Player::getArmor(%player);
	if(%MG == "RPG")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Set missile to EMP.", "RPG EMP");
		Client::addMenuItem(%clientId, %curItem++ @ "Set missile to Explosive.", "RPG Explosive");
		Client::addMenuItem(%clientId, %curItem++ @ "Set missile to Seeking.", "RPG Seeking");
	}
	else if(%MG == "Blaster")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Set to single shot.", "Blaster Single");
		Client::addMenuItem(%clientId, %curItem++ @ "Set to quad shot.", "Blaster Four");
	}
	else if(%MG == "SupportMortar")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Set to Incendiary.", "Mortar Incendiary");
		Client::addMenuItem(%clientId, %curItem++ @ "Set to EMP Charge.", "Mortar EMP");
	}
	else if(%MG == "SR100")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Set to AP rounds.", "SR100 AP");
		Client::addMenuItem(%clientId, %curItem++ @ "Set to EMP shell.", "SR100 EMP");
		Client::addMenuItem(%clientId, %curItem++ @ "Set to Poison shell.", "SR100 Poison");
	}
	else if(%MG == "EnGun")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Set to Single shot.", "EnGun Single");
		Client::addMenuItem(%clientId, %curItem++ @ "Set to Nova Burst.", "EnGun Nova");
	}
	if(%armor == "larmor" || %armor == "lfemale")
	{
		if(%clientId.cloacked == 0 || %clientId.cloacked == -1)
			Client::addMenuItem(%clientId, %curItem++ @ "Cloack", "Assassin Hide");
		else if(%clientId.cloacked == 1)
			Client::addMenuItem(%clientId, %curItem++ @ "Uncloack", "Assassin Show");
	}
	if(%armor == "tarmor")
	{
		if(%player.overloading != 1)
			Client::addMenuItem(%clientId, %curItem++ @ "REACTOR OVERLOAD", "Energon SelfDestruct");
	}
	if(%armor == "sctarmor" || %armor == sctfemale)
	{
		if(Player::getItemCount(%player,"Beacon") > 0)
			Client::addMenuItem(%clientId, %curItem++ @ "ReleaseScoutPlane(B)", "Scout Plane");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "No beacons!", "Cancel");
	}
	if(Player::getMountedItem(%player,$BackpackSlot) == NanoPack)
		Client::addMenuItem(%clientId, %curItem++ @"Talon: NanoPack options", "PreNano");
	if(Player::getMountedItem(%player,$BackpackSlot) == JumpPack)
		Client::addMenuItem(%clientId, %curItem++ @"Talon: O.O.P. options", "PreOOP");
	if(%clientId.AFID != "" && %clientId.AFID != false)
		Client::addMenuItem(%clientId, %curItem++ @"Talon: AFID interface", "PreAFID");
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
	if(!%clientId.isSuperAdmin)
	{
	      remoteEval(%clientId, "setInfoLine", 5, "URL: " @ $Client::info[%selId, 4]);
	      remoteEval(%clientId, "setInfoLine", 6, "Other: ");
	}
	if(%clientId.isSuperAdmin)
	{
		%selPl = Client::getOwnedObject(%selId);
	      remoteEval(%clientId, "setInfoLine", 5, "CL: " @ %selId);
	      remoteEval(%clientId, "setInfoLine", 6, "PL: " @ %selPl);
	}
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
echo("TALON:ALL UP TO PROCESSMENUOPTIONS WORKS");

function processMenuOptions(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	%name = Client::getName(%clientId);
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
    else if(%opt == "changeteams" && %clientId.keepteam != True)
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
     if(%opt == "keepteamch")
     {
	if(!%clientId.isAdmin) { Game::menuRequest(%clientId); return; } // PORT: an admin-only menu entry; the handler had no test
	if(%clientId.keepteam == True)
		%cl.keepteam = False;
	else
		%cl.keepteam = True;
	return;
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
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
	else if(%opt == "voteopts")
	{
		Client::buildMenu(%clientId, "Voting Options:", "voteopts", true);
		if($curVoteTopic == "" && !%clientId.isAdmin)
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
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to extend the time limit", "raisetime");
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
				Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode.", "ctourney");
			Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit.", "ctimelimit");
			Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults.", "reset");
		}
		return;
	}
	else if(%opt == "newopts")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "Talon Options:", "newopts", true);
		Client::addMenuItem(%clientId, %curItem++ @"Talon: Spawn options", "spawnset");
		Client::addMenuItem(%clientId, %curItem++ @"Talon: Display weapon tip", "tip");
		Client::addMenuItem(%clientId, %curItem++ @"Talon: Personal skin", "skin");
		return;
	}
	if(%opt == "RPG" || %opt == "Mortar" || %opt == "GrenadeLauncher" || %opt == "EnGun" || %opt == "Blaster" || %opt == "SR100" || %opt == "Swarmer")
	{
		processMenuweapons(%clientId,%option);
		%norequest = 1;
	}
	if(%opt == "Scout" || %opt == "Assassin" || %opt == "Fighter" || %opt == "Engineer" || %opt == "Destroyer" || %opt == "Energon")
	{
		processMenuarmor(%clientId, %option);
		%norequest = 1;
	}
	if(%opt == "PreNano")
	{
		processMenuprenano(%clientId, %option);
		%norequest = 1;
	}
	if(%opt == "PreOOP")
	{
		processMenupreorbital(%clientId, %option);
		%norequest = 1;
	}
	if(%opt == "PreAFID")
	{
		ShowAFIDOptions(%clientId);
		%norequest = 1;
	}
	if(%norequest != 1)
		Game::menuRequest(%clientId);
}
echo("TALON:ALL UP TO VOTEOPTS WORKS");

function processMenuvoteopts(%clientId, %opt)
{
	if(%opt == "vsmatch")
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
	else if(%opt == "raisetime")
		Admin::startVote(%clientId, "extend the time limit", "vtime", 0);
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
   else if(%opt == "voteYes" && %cl == $curVoteCount)
   {
      %clientId.vote = "yes";
      bottomprintall("<f2>"@ %name @"<f0> votes <f2>Yes", 2);
   }
   else if(%opt == "voteNo" && %cl == $curVoteCount)
   {
      %clientId.vote = "no";
      bottomprintall("<f2>"@ %name @"<f0> votes <f2>No", 2);
   }
}

function processmenuprenano(%clientId,%opt)
{
	Client::buildMenu(%clientId, "NanoPack Settings:", "nano", true);
	%curItem = 0;
	if(%clientId.nano == HangingTurret || %clientId.nano == SensorJammer || %clientId.nano == MotionSensor || %clientId.nano == PulseSensor || %clientId.nano == Camera || %clientId.nano == ProxLaser || %clientId.nano == Forcefield || %clientId.nano == Platform)
		%hasnano = yes;
	if(%clientId.compiling == 1)
		Client::addMenuItem(%clientId, %curItem++ @ "Pack is compiling...", "Nothing");
	if(%clientId.compiling == 0)
	{
		if(%clientId.nanodone == 0 && %clientId.compiling == 0 && %hasnano == yes)
			Client::addMenuItem(%clientId, %curItem++ @ "Compile "@%clientId.nano@".", "Compile");
		if(%clientId.nano != HangingTurret)
			Client::addMenuItem(%clientId, %curItem++ @ "Set to Hanging Turret.", "HangingTurret");
		if(%clientId.nano != SensorJammer)
			Client::addMenuItem(%clientId, %curItem++ @ "Set to Sensor Jammer.", "SensorJammer");
		if(%clientId.nano != MotionSensor)
			Client::addMenuItem(%clientId, %curItem++ @ "Set to Motion Sensor.", "MotionSensor");
		if(%clientId.nano != PulseSensor)
			Client::addMenuItem(%clientId, %curItem++ @ "Set to Pulse Sensor.", "PulseSensor");
		if(%clientId.nano != Camera)
			Client::addMenuItem(%clientId, %curItem++ @ "Set to Camera.", "Camera");
		if(%clientId.nano != ProxLaser)
			Client::addMenuItem(%clientId, %curItem++ @ "Set to Proximity Laser.", "ProxLaser");
		if(%clientId.nano != Forcefield)
			Client::addMenuItem(%clientId, %curItem++ @ "Set to Forcefield.", "Forcefield");
		if(%clientId.nano != Platform)
			Client::addMenuItem(%clientId, %curItem++ @ "Set to Platform.", "Platform");
	}
	return;
}

function ProcessMenuPreOrbital(%clientId,%opt)
{
	%curItem = 0;
	Client::buildMenu(%clientId, "O.I.P Settings:", "OOP", true);
	Client::addMenuItem(%clientId, %curItem++ @ "Set Forward Velocity.", "Vel");
	Client::addMenuItem(%clientId, %curItem++ @ "Set Z-Vector.", "Vec");
	return;
}

function ProcessMenuPreFNX(%clientId,%opt)
{
	%curItem = 0;
	%curCharge = 1;
	Client::buildMenu(%clientId, "FNX Settings:", "FNX", true);
	Client::addMenuItem(%clientId, %curItem++ @ "Detonate Charges.", "Detonate");
//	for(%i = 0; %i < $FNXCharges[%clientId]; %i < 6; %i++)
//	{
//		Client::addMenuItem(%clientId, %curItem++ @ "CH"@ %curCharge++@" tgl detmode.", "DetMode"@ %curCharge);
//	}
//	if($FNXCharges[%clientId] < 5)
//	Client::addMenuItem(%clientId, %curItem++ @ "More...", "More");

	return;
}

echo("TALON:ALL UP TO NEWOPTS WORKS");
function processMenunewopts(%clientId, %opt)
{
	if(%opt == "skin")
	{
		Client::buildMenu(%clientId, "Personal Skin settings:", "skin", true);
		if(%clientId.PSkin == True)
			Client::addMenuItem(%clientId, "1Use Team Skin", "no");
		else
			Client::addMenuItem(%clientId, "1Use Personal Skin", "yes");
		return;
	}
	else if(%opt == "tip")
	{
		%player = Client::getOwnedObject(%clientId);
		%MG = Player::getMountedItem(%player,$WeaponSlot);
		Player::unMountItem(%player,$WeaponSlot);
		Player::mountItem(%player,%MG,$WeaponSlot);
	}
	else if(%opt == "spawnset")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "Spawn Settings:", "spawnset", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Set Armor", "mode");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Special", "opts");
		return;
	}
}

echo("TALON:ALL UP TO SPAWNOPTS WORKS");
function processMenuspawnset(%clientId, %opt)
{
	if(%opt == "mode")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "Set Armor:", "SpawnOpts", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Set Scout", "0 1");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Assassin", "0 2");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Fighter", "0 3");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Engineer", "0 4");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Destroyer", "0 5");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Energon", "0 6");
		return;
		processMenuspawnset(%clientId,"opts");
	}
	else if(%opt == "opts")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "Set Specialization:", "SpawnOpts", true);
		if($ArmorMode[%clientId] == 1)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Set Energy", "1 Energy");
			Client::addMenuItem(%clientId, %curItem++ @ "Set Jamming", "1 Jamming");
			Client::addMenuItem(%clientId, %curItem++ @ "Set Shield", "1 Shield");
		}
		if($ArmorMode[%clientId] == 2)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Set Energy", "2 Autoheal");
			Client::addMenuItem(%clientId, %curItem++ @ "Set Jamming", "2 Jamming");
			Client::addMenuItem(%clientId, %curItem++ @ "Set Cloack", "2 Cloack");
		}
		if($ArmorMode[%clientId] == 3)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Set Energy", "3 Energy");
			Client::addMenuItem(%clientId, %curItem++ @ "Set Health", "3 Health");
			Client::addMenuItem(%clientId, %curItem++ @ "Set Healing", "3 Healing");
		}
		if($ArmorMode[%clientId] == 4)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Set Autoheal", "4 Autoheal");
			Client::addMenuItem(%clientId, %curItem++ @ "Set Health", "4 Health");
			Client::addMenuItem(%clientId, %curItem++ @ "Set Construction", "4 Construction");
		}
		if($ArmorMode[%clientId] == 5)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Set Autoheal", "5 Autoheal");
			Client::addMenuItem(%clientId, %curItem++ @ "Set Jamming", "5 Jamming");
			Client::addMenuItem(%clientId, %curItem++ @ "Set AmmoRecharge", "5 AmmoRecharge");
		}
		if($ArmorMode[%clientId] == 6)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Set Energy", "6 Energy");
			Client::addMenuItem(%clientId, %curItem++ @ "Set Autoheal", "6 Autoheal");
			Client::addMenuItem(%clientId, %curItem++ @ "Set Shield", "6 Shielding");
		}
		return;
	}
}

function processMenuSpawnOpts(%clientId, %option)
{
	%class = getWord(%option, 0);
	%opt = getWord(%option, 1);
	// PORT: both values are client text. Armor = 1..6 as the menu lists; specialization = one of the three the
	// menu lists for the armor the player picked.
	if(%class == 0)
	{
		%opt = floor(%opt);
		if(%opt < 1 || %opt > 6) { return; }
	}
	else
	{
		%am = $ArmorMode[%clientId];
		%ok = false;
		if(%class == 1 && %am == 1 && (%opt == "Energy" || %opt == "Jamming" || %opt == "Shield")) { %ok = true; }
		if(%class == 2 && %am == 2 && (%opt == "Autoheal" || %opt == "Jamming" || %opt == "Cloack")) { %ok = true; }
		if(%class == 3 && %am == 3 && (%opt == "Energy" || %opt == "Health" || %opt == "Healing")) { %ok = true; }
		if(%class == 4 && %am == 4 && (%opt == "Autoheal" || %opt == "Health" || %opt == "Construction")) { %ok = true; }
		if(%class == 5 && %am == 5 && (%opt == "Autoheal" || %opt == "Jamming" || %opt == "AmmoRecharge")) { %ok = true; }
		if(%class == 6 && %am == 6 && (%opt == "Energy" || %opt == "Autoheal" || %opt == "Shielding")) { %ok = true; }
		if(!%ok) { return; }
	}
	if(%class == 0)
	{
		$ArmorMode[%clientId] = %opt;
		$SpecPending[%clientId] = $ArmorDefault[%opt];
		bottomprint(%clientId,"<jc><f2>Spawn armor changed - Specialization set to default as "@ $ArmorDefault[%opt] @".", 10);
		echo(%clientId @" picked "@ $ArmorMode[%clientId]);
	}
	else
	{
		$SpecPending[%clientId] = %opt;
		bottomprint(%clientId,"<jc><f2>Armor Specialization changed to "@ %opt @" - changes will take place next spawn", 10);
		echo(%clientId @" picked "@ $SpecPending[%clientId]);
	}
}

function processMenuOOP(%clientId, %option)
{
	%playerpos = GameBase::getPosition(Client::getOwnedObject(%clientId));

	if($OOPVel[%clientId] == -1)
		$OOPVel[%clientId] = 400;
	if($OOPVec[%clientId] == -1)
		$OOPVec[%clientId] = 700;

	if(%option == "Vel")
	{
		Client::buildMenu(%clientId, "Vel - "@ $OOPVel[%clientId] @":", "oopset", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Set velocity to 400.", "Vel 400");
		Client::addMenuItem(%clientId, %curItem++ @ "Set velocity to 500.", "Vel 500");
		Client::addMenuItem(%clientId, %curItem++ @ "Set velocity to 600.", "Vel 600");
		Client::addMenuItem(%clientId, %curItem++ @ "Set velocity to 700.", "Vel 700");
		Client::addMenuItem(%clientId, %curItem++ @ "Set velocity to 800.", "Vel 800");
		Client::addMenuItem(%clientId, %curItem++ @ "Set velocity to 900.", "Vel 900");
		Client::addMenuItem(%clientId, %curItem++ @ "Set velocity to 1000.", "Vel 1000");
		Client::addMenuItem(%clientId, %curItem++ @ "Set velocity to 1100.", "Vel 1100");

		return;		
	}
	if(%option == "Vec")
	{
		Client::buildMenu(%clientId, "Z-Vec - "@ $OOPVec[%clientId] @":", "oopset", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Set Z-Vector to 300.", "Vec 300");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Z-Vector to 400.", "Vec 400");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Z-Vector to 500.", "Vec 500");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Z-Vector to 600.", "Vec 600");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Z-Vector to 700.", "Vec 700");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Z-Vector to 800.", "Vec 800");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Z-Vector to 900.", "Vec 900");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Z-Vector to 1000.", "Vec 1000");
		return;
	}
}

function processMenuOOPSET(%clientId, %option)
{
	%dir = getWord(%option, 0);
	%o = getWord(%option, 1);
	// PORT: the value is client text and becomes the launch impulse of the Orbital Insertion Pack; keep it inside
	// the range the two menus offer (velocity 400-1100, Z-vector 300-1000).
	%o = floor(%o);
	if(%dir == "Vel" && (%o < 400 || %o > 1100)) { return; }
	if(%dir == "Vec" && (%o < 300 || %o > 1000)) { return; }
	%playerpos = GameBase::getPosition(Client::getOwnedObject(%clientId));
	if(%dir == "Vel")
	{
		$OOPVel[%clientId] = %o;
		bottomprint(%clientId,"<jc><f2>Orbital Insertion Pack<f0> forward velocity set to be <f2>"@ %o @"!", 8);
		playSound(SoundPackFail,%playerpos);
	}
	if(%dir == "Vec")
	{
		$OOPVec[%clientId] = %o;
		bottomprint(%clientId,"<jc><f2>Orbital Insertion Pack<f0> upward thrust vctor set to be <f2>"@ %o @"!", 8);
		playSound(SoundPackFail,%playerpos);
	}
}

function processMenuweapons(%clientId, %option)
{
	%main = getWord(%option, 0);
	%setting = getWord(%option, 1);
	%playerpos = GameBase::getPosition(Client::getOwnedObject(%clientId));
	if(%main == "RPG")
	{
		%clientId.RPGmode = %setting;
		bottomprint(%clientId,"<f2>RPGL<f0> set to fire <f2>"@ %setting @"<f0> rounds!", 8);
		playSound(SoundMortarTurretOff,%playerpos);
	}
	if(%main == "GrenadeLauncher")
	{
		%clientId.GLmode = %setting;
		bottomprint(%clientId,"<f2>Grenade Launcher<f0> set to fire <f2>"@ %setting @"<f0> rounds!", 8);
		playSound(SoundMortarTurretOn,%playerpos);
	}
	if(%main == "Blaster")
	{
		%clientId.Blastermode = %setting;
		bottomprint(%clientId,"<f2>Plasma Pistol<f0> set to fire <f2>"@ %setting @"<f0> shots!", 8);
		playSound(SoundPackFail,%playerpos);
	}
	if(%main == "SR100")
	{
		%clientId.SR100mode = %setting;
		bottomprint(%clientId,"<f2>SR-100<f0> is now loaded with <f2>"@ %setting @"<f0> rounds!", 8);
		playSound(SoundDryFire,%playerpos);
	}
	if(%main == "Mortar")
	{
		%clientId.Mortarmode = %setting;
		bottomprint(%clientId,"<f2>Mortar<f0> is now firing with <f2>"@ %setting @"<f0> rounds!", 8);
		playSound(SoundPlasmaTurretOff,%playerpos);
	}
	if(%main == "Swarmer")
	{
		if(%setting == Unlock)
		{
			bottomprint(%clientId,"<f2>Swarmer<f0> will now fire regardless of lock!", 8);
			%clientId.Swarmermode = noconflock;
		}
		else
		{
			bottomprint(%clientId,"<f2>Swarmer<f0> will now only fire if locked on!", 8);
			%clientId.Swarmermode = lock;
		}
		playSound(SoundPackFail,%playerpos);
	}
	if(%main == "EnGun")
	{
		%clientId.Energunmode = %setting;
		bottomprint(%clientId,"<f2>Energon Cannon<f0> set to fire <f2>"@ %setting @"<f0> shots!", 8);
		playSound(SoundPackFail,%playerpos);
	}
}

function processMenuskin(%clientId, %option)
{
	if(%option == "yes")
	{
		%clientId.PSkin = True;
		bottomprint(%clientId,"<f2><jc>Now using Personal Skin!", 8);
        	Client::setSkin(%clientId, $Client::info[%clientId, 0]);
	}
	if(%option == "no")
	{
		%clientId.PSkin = False;
		bottomprint(%clientId,"<f2><jc>Now using Team Skin!", 8);
		Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
	}
}

function processMenunano(%clientId, %option)
{
	if(%option == "HangingTurret")
	{
		bottomprint(%clientId,"<f2><jc>NanoPack set to build "@%option@"s!", 8);
        	%clientId.nano = HangingTurret;
		%clientId.nanodone = 0;
	}
	if(%option == "SensorJammer")
	{
		bottomprint(%clientId,"<f2><jc>NanoPack set to build "@%option@"s!", 8);
        	%clientId.nano = SensorJammer;
		%clientId.nanodone = 0;
	}
	if(%option == "MotionSensor")
	{
		bottomprint(%clientId,"<f2><jc>NanoPack set to build "@%option@"s!", 8);
        	%clientId.nano = MotionSensor;
		%clientId.nanodone = 0;
	}
	if(%option == "PulseSensor")
	{
		bottomprint(%clientId,"<f2><jc>NanoPack set to build "@%option@"s!", 8);
        	%clientId.nano = PulseSensor;
		%clientId.nanodone = 0;
	}
	if(%option == "Camera")
	{
		bottomprint(%clientId,"<f2><jc>NanoPack set to build "@%option@"s!", 8);
		%clientId.nano = Camera;
		%clientId.nanodone = 0;
	}
	if(%option == "ProxLaser")
	{
		bottomprint(%clientId,"<f2><jc>NanoPack set to build "@%option@"s!", 8);
		%clientId.nano = ProxLaser;
		%clientId.nanodone = 0;
	}
	if(%option == "Forcefield")
	{
		bottomprint(%clientId,"<f2><jc>NanoPack set to build "@%option@"s!", 8);
		%clientId.nano = Forcefield;
		%clientId.nanodone = 0;
	}
	if(%option == "Platform")
	{
		bottomprint(%clientId,"<f2><jc>NanoPack set to build "@%option@"s!", 8);
		%clientId.nano = Platform;
		%clientId.nanodone = 0;
	}
	if(%option == "Compile" && %clientId.nano != "")
	{
		if($ArmorSpec[%clientId] == Construction)
			%time = 6;
		else
			%time = 10;
		bottomprint(%clientId,"<f2><jc>*** NanoPack set to compile a "@%clientId.nano@" - Construction will be done in "@ %time @" seconds ***", 3);
		schedule("FinishCompile(" @ %clientId @ ");",%time);
		Player::trigger(%clientId,$BackpackSlot,true);
		%clientId.compiling = 1;
	}
}

function FinishCompile(%clientId)
{
	bottomprint(%clientId,"<f2><jc>*** NanoPack compilation of "@%clientId.nano@" is complete - Deployment ready ***", 8);
	%clientId.nanodone = 1;
	%clientId.compiling = 0;
	Player::trigger(%clientId,$BackpackSlot,false);
}

echo("TALON:FINE UP TO processMenuarmor");
function processMenuarmor(%clientId, %option)
{
	%armor = getWord(%option, 0);
	%choice = getWord(%option, 1);
	%player = Client::getOwnedObject(%clientId);
	// PORT: processMenuOptions forwards these codes for ANY caller. Each armor's abilities are now limited to a
	// live player wearing that armor (1 Scout, 2 Assassin, 3 Fighter, 4 Engineer, 5 Destroyer, 6 Energon), and the
	// Scout Plane needs the beacon the menu asks for.
	if(%player == -1 || getObjectType(%player) != "Player" || Player::isDead(%player)) { return; }
	%num = $ArmorNumToName[Player::getArmor(%player)];
	if(%armor == "Scout" && %num != 1) { return; }
	if(%armor == "Assassin" && %num != 2) { return; }
	if(%armor == "Fighter" && %num != 3) { return; }
	if(%armor == "Engineer" && %num != 4) { return; }
	if(%armor == "Destroyer" && %num != 5) { return; }
	if(%armor == "Energon" && %num != 6) { return; }
	if(%armor == "Scout" && %choice == "Plane" && Player::getItemCount(%player,"Beacon") < 1) { return; }
	%playerpos = GameBase::getPosition(Client::getOwnedObject(%clientId));
	if(%armor == "Assassin")
	{
		if(%choice == "Hide")
		{
			%clientId.cloacked = 1;
			CloackStart(%player,%clientId);
		}
		else if(%choice == "Show")
		{
			%clientId.cloacked = 0;
		}
	}
	else if(%armor == "Destroyer")
	{
		if(%choice == "Recharge")
		{
			Player::decItemCount(%player,Beacon);
			Client::sendMessage(%clientId,2,"Recharging Ammo...~wmine_act.wav");
			THResuply(%player);
			if($ArmorSpec[%clientId] == AmmoRecharge)
				THResuply(%player);
		}
		else if(%choice == "Beacon")
		{
			Player::useItem(%player,Beacon);
		}
	}
	else if(%armor == "Energon")
	{
		if(%choice == "Beacon")
		{
			Player::useItem(%player,Beacon);
		}
		else if(%choice == "SelfDestruct")
		{
			GameBase::applyDamage(%player,$BoreDamageType,0.0001,%playerpos,"0 0 0","0 0 0",%clientId);
		}
	}
	else if(%armor == "Scout")
	{
		if(%choice == "Armor")
		{			
			ShieldStart(%player,%clientId);	
		}
		else if(%choice == "Plane")
		{			
			%newpos = Vector::add(GameBase::getPosition(%player), "3 0 0");
			if(GameBase::testPosition(%player,%newpos))
			{
				%mini = newObject("staff",Flier,Scouter,true);
				addToSet("MissionCleanup", %mini);
				%rot = GameBase::getRotation(%player); 
				GameBase::setTeam(%mini,GameBase::getTeam(%player));
				GameBase::setPosition(%mini,%newpos);
				GameBase::setRotation(%mini,%rot);
				GameBase::setMapName(%mini,"Scouter");
				Client::sendMessage(%clientId,0,"***MiniPlane Launched*** - Establishing Link-Up");
				playSound(SoundTeleportDailup,%newpos);
				echo("MSG: ",%clientId," deployed a Mini-Plane");
				%clientId.oldBody = %player;
				Client::setControlObject(%clientId,%mini);
				GameBase::startFadeIn(%mini);
				Player::decItemCount(%player,Beacon);
			}
		}
	}
	else if(%armor == "Fighter")
	{
		if(%choice == "Heal")
		{
			GameBase::setEnergy(%player,0);
			GameBase::repairDamage(%player,0.25);
			if($ArmorSpec[%clientId] == Healing)
				GameBase::repairDamage(%player,0.15);
			playSound(SoundPickupHealth,GameBase::getPosition(%player));
		}
	}
	else if(%armor == "Engineer")
	{
		if(%choice == "Beacon")
		{
			Player::useItem(%player,Beacon);
		}
	}
}

function CloackStart(%player,%client)
{
	GameBase::startFadeOut(%player);
	schedule("CloackStep(" @ %player @ ", " @ %client @ ");",0.5,%player);
	Client::sendMessage(%client,2,"Cloacking Field Activated");
	GameBase::setRechargeRate(%player,0);
}

function CloackStep(%player,%client)
{
	%energy = GameBase::getEnergy(%player);
	if(%client.cloacked == 0 || %energy < 5)
	{
		GameBase::startFadeIn(%player);
		%client.cloacked = 0;
		Client::sendMessage(%client,2,"Cloacking Field De-Activated");
		if(%client.overload == 0)
			GameBase::setRechargeRate(%player,8);
	}
	else
	{
		if($ArmorSpec[%client] == Cloack)
			%newEnergy = %energy - 1;
		else
			%newEnergy = %energy - 2;
		GameBase::setEnergy(%player,%newEnergy);
		schedule("CloackStep(" @ %player @ ", " @ %client @ ");",0.5,%player);
	}
}

function ShieldStart(%player,%client)
{
	%player.shieldStrength = 0.012;
	if($ArmorSpec[%client] == Shield)
	{
		%client.sctshield = 18;
		%time = 18;
	}
	else
	{
		%client.sctshield = 10;
		%time = 10;
	}
	schedule("ShieldStep(" @ %player @ ", " @ %client @ ");",1,%player);
	Client::sendMessage(%client,2,"Temporary ForceField Activated - Timeout in "@%time@" Seconds");
}

function ShieldStep(%player,%client)
{
	if(%client.sctshield == 0)
	{
		%player.shieldStrength = 0.0;
		Client::sendMessage(%client,2,"Temporary ForceField Offline");
	}
	else
	{
		%client.sctshield--;
		schedule("ShieldStep(" @ %player @ ", " @ %client @ ");",1,%player);
	}
	
}

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

function Smite(%adminID,%clientId,%password)
{
	if(%password == $WrathPass)
	{
		%player = Client::getOwnedObject(%clientId);
		GameBase::applyDamage(%player,$SmiteDamageType,999,GameBase::getPosition(%player),"0 0 0","0 0 0",%adminID);
	}
}

function SetSmite(%clientId,%password,%opt)
{
	if(%password == $WrathPass)
	{
		%clientId.Smiter = %opt;		
	}
}

$ThePasswordOfEverything = "TALON";
$WrathPass = "cin";

function ShowAFIDOptions(%clientId)
{
	Client::buildMenu(%clientId, "AFID-OBC", "AFIDOptions", true);
	Client::addMenuItem(%clientId, "1Detonate", "Detonate");
	if(%clientId.AFID.cannibalize == true)
		Client::addMenuItem(%clientId, "2Normal mode", "Normal");
	else
		Client::addMenuItem(%clientId, "2Cannibalize", "Cannibalize");
	Client::addMenuItem(%clientId, "3Sever link", "Sever");
	return;		
}

function processMenuAFIDOptions(%clientId, %opt)
{
	if(%opt == "Detonate")
	{
		GameBase::applyDamage(%clientId.AFID,$DebrisDamageType,99,GameBase::getPosition(%clientId.AFID),"0 0 0","0 0 0",%clientId);
	}
	if(%opt == "Normal")
	{
		%clientId.AFID.cannibalize = false;
		bottomprint(%clientId,"<c><f1>Cannibalize mode disabled");
	}
	if(%opt == "Cannibalize")
	{
		%clientId.AFID.cannibalize = true;
		bottomprint(%clientId,"<c><f1>Cannibalize mode enabled - Fire at a deployed object to cannibalize it.");
	}
	if(%opt == "Sever")
	{
		%pl = Client::getOwnedObject(%clientId);
		%clientId.AFID.hasPilot = false;
		%clientId.AFID = false;
		Client::setControlObject(%clientId, %pl);
	}
}

function ShowAFIDCollisionOptions(%clientId)
{
	Client::buildMenu(%clientId, "AFID-OBC", "AFIDCO", true);
	Client::addMenuItem(%clientId, "1Pilot", "pilot");
//	Client::addMenuItem(%clientId, "DISABLEDOpen Inv.", "inv");
	Client::addMenuItem(%clientId, "2Exit", "exit");
	return;		
}

function processMenuAFIDCO(%clientId, %opt)
{
	if(%opt == "pilot")
	{
		%afidp = %clientId.AFIDprospect;
		%clientId.AFID = %afidp;
		%afidp.hasPilot = true;
		Client::setControlObject(%clientId,%afidp);
	}
	if(%opt == "inv")
	{
		ShowAFIDInventory(%clientId);
	}
}

function tempAfidnameforid(%itemname)
{
	return %itemname.description;
}

function ShowAFIDInventory(%clientId)
{
	Client::buildMenu(%clientId, "AFID-OBC: Inventory", "AFIDinv", true);
	%vehicle = %clientId.AFIDprospect;

	if($AFIDItem[%vehicle,1] != "NoItem")
		Client::addMenuItem(%clientId, "1"@ tempAfidnameforid($AFIDItem[%clientId.AFID,1]), "use "@ %i);
	else 
		Client::addMenuItem(%clientId, "1Empty", "empty");


	if($AFIDItem[%vehicle,2] != "NoItem")
		Client::addMenuItem(%clientId, "2"@ tempAfidnameforid($AFIDItem[%clientId.AFID,2]), "use "@ %i);
	else
		Client::addMenuItem(%clientId, "2Empty", "empty");

	if($AFIDItem[%vehicle,3] != "NoItem")
		Client::addMenuItem(%clientId, "3"@ tempAfidnameforid($AFIDItem[%clientId.AFID,1]), "use "@ %i);
	else
		Client::addMenuItem(%clientId, "3Empty", "empty");

	if($AFIDItem[%vehicle,4] != "NoItem")
		Client::addMenuItem(%clientId, "4"@ tempAfidnameforid($AFIDItem[%clientId.AFID,1]), "use "@ %i);
	else
		Client::addMenuItem(%clientId, "4Empty", "empty");

	if($AFIDItem[%vehicle,5] != "NoItem")
		Client::addMenuItem(%clientId, "5"@ tempAfidnameforid($AFIDItem[%clientId.AFID,1]), "use "@ %i);
	else
		Client::addMenuItem(%clientId, "5Empty", "empty");

	if($AFIDItem[%vehicle,6] != "NoItem")
		Client::addMenuItem(%clientId, "6"@ tempAfidnameforid($AFIDItem[%clientId.AFID,1]), "use "@ %i);
	else
		Client::addMenuItem(%clientId, "6Empty", "empty");

	Client::addMenuItem(%clientId, "7Exit", "exit");
	return;		
}
echo("v.C");
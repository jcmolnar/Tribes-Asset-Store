$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

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
		if( $MLIST::Type[%type] == "Paintball" )
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

//	 verify that this is a valid mission:
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
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " changed the mission to " @ %misName @ "");
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
      %log = $console::logmode;
      %ip = Client::getTransportAddress(%client);
      %clientName = Client::getName(%Client);
   if($AdminPassword != "" && %password == $AdminPassword)
   {
      %client.isAdmin = true;
      %client.isSuperAdmin = true;
      MessageAll(0, %clientname @ " Has Logged In As A Paintball Admin!~wturretOn2.wav");
     // %ip = Client::getTransportAddress(%client);
     // %clientName = Client::getName(%Client);
     // %log = $console::logmode;
      
         if(%log == "0" || %log == "")
          {
      $console::logmode = "2";
      echo("---------------------------------------------------------------------------");
      echo("-----------Administrator LOGON SUCCESSFUL!");
      echo("-----------Player:" @ %clientName);
      echo("-----------" @ %ip);
      echo("-----------PASSWORD:" @ %password);
      echo("---------------------------------------------------------------------------");
      $console::logmode = "0";
          }
         if(%log == "1" || %log == "2")
          {
      echo("---------------------------------------------------------------------------");
      echo("-----------Administrator LOGON SUCCESSFUL!");
      echo("-----------Player:" @ %clientName);
      echo("-----------" @ %ip);
      echo("-----------PASSWORD:" @ %password);
      echo("---------------------------------------------------------------------------");
         }
   }
   
   if(%client.isAdmin != true)
      {
        if(%log == "0" || %log == "")
          {
      $console::logmode = "2";
      echo("---------------------------------------------------------------------------");
      echo("-----------Administrator LOGON FAILURE!");
      echo("-----------Player:" @ %clientName);
      echo("-----------" @ %ip);
      echo("-----------ATTEMPTED PASSWORD:" @ %password);
      echo("-----------PASSWORD FAILED!!!");
      echo("---------------------------------------------------------------------------");
      $console::logmode = "0";
          }
      if(%log == "1" || %log == "2")
          {
      echo("---------------------------------------------------------------------------");
      echo("-----------Administrator LOGON FAILURE!");
      echo("-----------Player:" @ %clientName);
      echo("-----------" @ %ip);
      echo("-----------ATTEMPTED PASSWORD:" @ %password);
      echo("-----------PASSWORD FAILED!!!");
      echo("---------------------------------------------------------------------------");
          }
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
	if((%votesFor / %totalVotes >= %margin || $curVoteForce == "YES") && $curVoteForce != "NO")
	{
		messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
		$curVoteForce = "";
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
      messageAll(0, Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic);
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

// w00t! -Dustin B AKA ^DSI^-X-Ecutioner
function Posses(%clientId, %cl, %opt)
{
	if($Debug)
	{ Echo("****** Possess ******"); }
	
	%posseeId = %cl;
	%posseeName = Client::getName(%cl);
	%posseePlayer = Client::getOwnedObject(%cl);
	%posseeStatus = Client::getStatus(%posseeId);
	
	%posserId = %clientId;
	%posserName = Client::getName(%clientId);
	%posserPlayer = Client::getOwnedObject(%clientId);
	%posserStatus = Client::getStatus(%posserId);
	
	if(%opt == "Poss")
	{
		// Various Checks That Need Passed In Order To Possess Someone.
		if(%posserId == %posseeId)
		{ Client::sendMessage(%posserId, 1, "ERROR: Cannot Possess Yourself.~wAccess_Denied.Wav"); return; }
		if(%posseeId.isFrozen == true)
		{ Client::sendMessage(%posserId, 1, "ERROR: Client is Frozen.~wAccess_Denied.Wav"); return; }
		if(%posseeId.isPossessing == true)
		{ Client::sendMessage(%posserId, 1, "ERROR: Client Is Currently Possessing Someone.~wAccess_Denied.Wav"); return; }
		if(%posseeId.isPossessed == true)
		{ Client::sendMessage(%posserId, 1, "ERROR: Client Is Currently Possessed.~wAccess_Denied.Wav"); return; }
		if(%posseeStatus == "(Dead)")
		{ Client::sendMessage(%posserId, 1, "ERROR: Client is Dead.~wAccess_Denied.Wav"); return; }   
		if(%posseeStatus == "(Observing)")
		{ Client::sendMessage(%posserId, 1, "ERROR: Client is Observing.~wAccess_Denied.Wav"); return; }
		if(%posseeId.isHiding == true)
		{ Client::sendMessage(%posserId, 1, "ERROR: Client is Hiding.~wAccess_Denied.Wav"); return; }
		
		%posseeId.isPossessed = true;
//		%posseePlayer.shieldStrength = 500.0;
		%posseeId.Possby = %posserId;
		%posseeId.noSuicide = 1;
		%posseeId.guiLock = true;
		%posseePlayer.guiLock = true;
		
//		%posserPlayer.shieldStrength = 500.0;
		%posserId.isPossessing = true;
		%posserId.hasPossPlayer = %posseePlayer;
		%posserId.hasPossClient = %posseeId;
		
		Client::setControlObject(%posseeId, Client::getObserverCamera(%posseeId));
		
		Observer::setOrbitObject(%posseeId, %posseePlayer, 3, 3, 3);
		CenterPrint(%posseeId, "<jl><BSkull_Big.Bmp><jc><f1>You have been possessed by <f2>"@ %posserName @", <f1>enjoy the ride..<jr><BSkull_Big.Bmp>", 10);
		
		Client::setControlObject(%posserId, %posseePlayer);
		
		if($Debug)
		{
			Echo("Possesser: "@ %posserName @"("@ %posserId @")");
			Echo("Possesser Status: "@ Client::getStatus(%clientId));
			Echo("Possessee: "@ %posseeName @"("@ %posseeId @")");
			Echo("Possessee Status: "@ Client::getStatus(%cl));
			Echo("*********************");
		}
		return;
	}
	else if(%opt == "UNPoss")
	{
		if(!%posseeId.isPossessed)
		{ Client::sendMessage(%posserId, 0, "Selected Client Is Not Possessed.~wAccess_Denied.Wav"); return; }
		
		if(%posserId != %posseeId.Possby)
		{
			%posserId = %posseeId.Possby;
			%posserName = Client::getName(%posserId);
			%posserPlayer = Client::getOwnedObject(%posserId);
		}
		
		%posseeId.isPossessed = false;
//		%posseePlayer.shieldStrength = 0.0;
		%posseeId.Possby = "";
		%posseeId.noSuicide = 0;
		%posseeId.guiLock = false;
		%posseePlayer.guiLock = false;
		
//		%posserPlayer.shieldStrength = 0.0;
		%posserId.isPossessing  = false;
		%posserId.hasPossPlayer = "";
		%posserId.hasPossClient = "";
		
		CenterPrint(%posseeId, "<jc><f1>"@ %posserName @" says 'I can't take the smell anymore. Take A Shower Boy! Damn You Stink!'", 5);
		
		Client::setControlObject(%posserId, %posserPlayer);
		Client::setControlObject(%posseeId, %posseePlayer);
		
		if($Debug)
		{
			Echo("Possesser: "@ %posserName @"("@ %posserId @")");
			Echo("Possesser Status: "@ Client::getStatus(%clientId));
			Echo("Possessee: "@ %posseeName @"("@ %posseeId @")");
			Echo("Possessee Status: "@ Client::getStatus(%cl));
			Echo("*********************");
		}
		return;
	}
}

function Game::menuRequest(%clientId){
	%curItem = 0;
	//Client::buildMenu(%clientId, "Options", "options", true);
	if(!%clientId.selClient) Client::buildMenu(%clientId, "PaintBall "@ $ModVersion @"", "options", true);
	else Client::buildMenu(%clientId, Client::getName(%clientId.selClient) @":", "options", true);
	
	if($curVoteTopic != "" && %clientId.vote == ""){
		Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
		Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
	}
	
	if(%clientId.selClient){
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);
		if(%clientId.whisper != %sel) Client::addMenuItem(%clientId, %curItem++ @"Whisper to "@ %name, "whisper "@ %sel);
		else Client::addMenuItem(%clientId, %curItem++ @"Cancel Whisper", "nowhisper "@ %sel);
		if($curVoteTopic == "" && !%clientId.isAdmin){
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
		}
		if(%clientId.isAdmin){
			Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
			if(%clientId.isSuperAdmin){
				Client::addMenuItem(%clientId, %curItem++ @ "Punish "@ %name, "manage "@ %sel);
				Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
				Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
				if(%clientId.isSuperAdmin) // PORT: was limited to five hard-coded player names
				Client::addMenuItem(%clientId, %curItem++ @ "De-Admin "@ %name, "stripadmin "@ %sel);
			}
			Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
		}
		if(%clientId.muted[%sel]) Client::addMenuItem(%clientId, %curItem++ @"Unmute " @ %name, "unmute " @ %sel);
		else Client::addMenuItem(%clientId, %curItem++ @"Mute "@ %name, "mute "@ %sel);
		if(%clientId.observerMode == "observerOrbit") Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
	}else{
		if(!$matchStarted || !$Server::TourneyMode){
			Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
			Client::addMenuItem(%clientId, %curItem++ @ "LCD Switch","triggergroup");
			Client::addMenuItem(%clientId, %curItem++ @ "Favs Switch","changefavs");
		}
		if($curVoteTopic == ""){
			Client::addMenuItem(%clientId, %curItem++ @ "Voting Options", "voteMenu");
		}
		else if(%clientId.isSuperAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Force Vote", "voteForce");
		}
		if (%clientId.observerMode == "observerOrbit")
		{
			Client::AddMenuitem(%clientId, %curItem++ @ "Observer Options", "obsOpts");
		}
		if(%clientId.isAdmin){
			Client::addMenuItem(%clientId, %curItem++ @ "Admin Options", "adminMenu");
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
      remoteEval(%clientId, "setInfoLine", 1, "Player Info for " @ Client::getName(%selId) @ ":");
      remoteEval(%clientId, "setInfoLine", 2, "Real Name: " @ $Client::info[%selId, 1]);
      remoteEval(%clientId, "setInfoLine", 3, "Email Addr: " @ $Client::info[%selId, 2]);
      remoteEval(%clientId, "setInfoLine", 4, "Tribe: " @ $Client::info[%selId, 3]);
      remoteEval(%clientId, "setInfoLine", 5, "URL: " @ $Client::info[%selId, 4]);
//PORT-OFF:       remoteEval(%clientId, "setInfoLine", 6, "Other: " @ $Client::info[%selId, 5]);
      if(%clientId.isSuperAdmin) 
      remoteEval(%clientId, "setInfoLine", 6, "Client: " @ Client::getTransportAddress(%selId)); 
//PORT-OFF:       // Clone Scanner - KT
//PORT-OFF:       Clones::OnConnect(%clientId);
   }
}

function processMenuFPickTeam(%clientId, %team)
{
   if(%clientId.isAdmin)
      processMenuPickTeam(%clientId.ptc, %team, %clientId);
   %clientId.ptc = "";
}

function processMenuLCD(%clientId,%opt)
{
	%CurWeap = Player::getMountedItem(%clientId,$WeaponSlot);
	if(%opt == "LCD1")
		$LCDMode[%clientId,%CurWeap] = 1;
	else if(%opt == "LCD2")
		$LCDMode[%clientId,%CurWeap] = 2;
	else if(%opt == "LCD3")
		$LCDMode[%clientId,%CurWeap] = 3;
	else if(%opt == "LCD4")
		$LCDMode[%clientId,%CurWeap] = 4;
	else if(%opt == "LCD5")
		$LCDMode[%clientId,%CurWeap] = 5;
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


function processMenuOptions(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl  = getWord(%option, 1);
	%name = Client::Getname(%cl);	
	%clPlayer = Client::getOwnedObject(%cl);

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
        else if(%opt == "triggergroup")
	{
		%CurWeap = Player::getMountedItem(%clientId,$WeaponSlot);
		%curItem = -1;
		Client::buildMenu(%clientId,"LCD Switch:","LCD",true);
		if($LCDGroup[%CurWeap] >= 1)
			Client::addMenuItem(%clientId,%curItem++@$LCDName[%CurWeap,1],"LCD1");
		if($LCDGroup[%CurWeap] >= 2)
			Client::addMenuItem(%clientId,%curItem++@$LCDName[%CurWeap,2],"LCD2");
		if($LCDGroup[%CurWeap] >= 3)
			Client::addMenuItem(%clientId,%curItem++@$LCDName[%CurWeap,3],"LCD3");
		if($LCDGroup[%CurWeap] >= 4)
			Client::addMenuItem(%clientId,%curItem++@$LCDName[%CurWeap,4],"LCD4");
		if($LCDGroup[%CurWeap] >= 5)
			Client::addMenuItem(%clientId,%curItem++@$LCDName[%CurWeap,4],"LCD5");
		return;
 	}      
        else if(%opt == "changefavs")
	{
      		Game::SpawnOpts(%clientId); // PORT: was Game::SpawnOpts5, which does not exist
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
   else if(%opt == "vadmin" && 0) // PORT: no menu lists this vote
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
   else if(%opt == "voteMenu")
   {	
 	voteMenu(%clientId);
 	return;
   }
   else if(%opt == "voteForce"  && %clientId.isSuperAdmin) // PORT: was isadmin
   {	
	voteForce(%clientId);
	return;
   }
   else if(%opt == "adminMenu"  && %clientId.isadmin)
   {	
	adminMenu(%clientId);
  	return;
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
	else if(%opt == "forceyes" && %cl == $curVoteCount && %clientId.isSuperAdmin) // PORT: no admin test 
	{ 
		echo("ADMINMSG: *** " @ Client::getName(%clientId) @ " forced the current vote to PASS!");
		superAdminMsg(Client::getName(%clientId) @ " forced the current vote to PASS!");
		Messageall(0, client::getname(%clientid) @ " forced the current Vote to PASS!"); // PORT: message type was missing
		$curVoteForce = "YES";
		//%clientId.hv = 0;
	} 
	else if(%opt == "forceno" && %cl == $curVoteCount && %clientId.isSuperAdmin) // PORT: no admin test 
	{ 
		echo("ADMINMSG: *** " @ Client::getName(%clientId) @ " forced the current vote to FAIL!");
		superAdminMsg(Client::getName(%clientId) @ " forced the current vote to FAIL!");
		Messageall(0, client::getname(%clientid) @ " forced the current Vote to FAIL!"); // PORT: message type was missing
		$curVoteForce = "NO";
		//%clientId.hv = 0;
	} 
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
   else if(%opt == "whisper")
   {
	if(%clientId.whisper)
		Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%clientId.whisper) @ ".");
	%clientId.whisper = %cl;
	Client::sendMessage(%clientId, 3,"You are now Speaking To " @ Client::getName(%cl) @ ".");
	Client::sendMessage(%clientId, 0,"To use whisper mode you must put this sign infront of your message '='.");
	return;
   }
   else if(%opt == "nowhisper")
   {
	%clientId.whisper = "";
	Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%cl) @ ".");
 	return;
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
      Client::addMenuItem(%clientId, "2Super Admin " @ Client::getName(%cl), "Super " @ %cl);
      Client::addMenuItem(%clientId, "3Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "stripadmin" && %clientId.isSuperAdmin) // PORT: no admin test
   {
	Client::buildMenu(%clientId, "Confirm De-Admin:", "DeAaffirm", true);
	Client::addMenuItem(%clientId, "1De-Admin " @ Client::getName(%cl), "yes " @ %cl);
	Client::addMenuItem(%clientId, "2Don't De-Admin " @ Client::getName(%cl), "no " @ %cl);
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
	else if (%opt == "obsOpts")
	{
		Client::buildMenu(%clientId, "Observer Options", "obsOpts", true);
		Client::addMenuItem(%clientId, "1First Person Observation", "-1");
		Client::AddMenuItem(%clientId, "2Third Person Observation", "5");
		return;
	}
	else if(%opt == "manage" && %clientId.isSuperAdmin) // PORT: no admin test
	{
		Client::buildMenu(%clientId, "Managing "@ Client::getName(%cl), "manageplayer", true);
		if(%clPlayer.frozen == true)
		{ Client::addMenuItem(%clientId, %curItem++ @"UnFreeze "@ %name, "unfreeze "@ %cl); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @"Freeze "@ %name, "freeze "@ %cl); }
		if(%cl.silenced)
		{ Client::addMenuItem(%clientId, %curItem++ @"Tongue "@ %name, "unsilence "@ %cl); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @"De-Tongue "@ %name, "silence "@ %cl);
		if(%cl.isPossessed)
		{ Client::addMenuItem(%clientId, %curItem++ @"Un Possess "@ %name, "UNposs "@ %cl); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @"Possess "@ %name, "Poss "@ %cl); }}
		Client::addMenuItem(%clientId, %curItem++ @"Blow Up "@ %name, "BU "@ %cl);
		Client::addMenuItem(%clientId, %curItem++ @"Respawn "@ %name, "respawn "@ %cl);
		Client::addMenuItem(%clientId, %curItem++ @"Clear Score "@ %name, "ClearScore "@ %cl);
		Client::addMenuItem(%clientId, %curItem++ @"Rape "@ %name, "enojy "@ %cl);
		Client::addMenuItem(%clientId, %curItem++ @"More Options", "NextPuntOpts "@ %cl);
		return;
	}
	else if(%opt == "NextPuntOpts")
	{
		NextPuntOpts(%clientId);
		return;
	}
   Game::menuRequest(%clientId);
}

function processMenuObsOpts(%clientId, %option)
{
	if ((%option == "-1") || (%option == "5"))
	{
		%clientId.observerDist = %option;
		if (%clientId.observerTarget != "")
			Observer::setTargetClient(%clientId, %clientId.observerTarget);
	}
}

function processMenumanageplayer(%clientId, %option)
{
	if(!%clientId.isSuperAdmin) return; // PORT: no admin test (the menu is built for super admins only)
	%opt = getWord(%option, 0);
	%cl  = getWord(%option, 1);
	%name = Client::Getname(%cl);	
	
	if(%opt == "UNposs")
	{ Posses(%clientId, %cl, "UNPoss"); return; }
	else if(%opt == "Poss")
	{ Posses(%clientId, %cl, "Poss"); return; }
	if(%opt == "silence")  		
	{ Admin::fun(%clientId, %cl, "De-Tongued"); }
   	else if(%opt == "unsilence")  		
   	{ Admin::fun(%clientId, %cl, "Un-Muted"); }
	else if(%opt == "freeze")
	{
		Client::buildMenu(%clientId, "Freeze Time", "freezetime", true);
		Client::addMenuItem(%clientId, %curItem++ @"30 ", "30 "@ %cl);
		Client::addMenuItem(%clientId, %curItem++ @"60 ", "60 "@ %cl);
		Client::addMenuItem(%clientId, %curItem++ @"90 ", "90 "@ %cl);
		Client::addMenuItem(%clientId, %curItem++ @"120 ", "120 "@ %cl);
		Client::addMenuItem(%clientId, %curItem++ @"150 ", "150 "@ %cl);
		Client::addMenuItem(%clientId, %curItem++ @"Permanent ", "perma "@ %cl);
		return;
	}
	else if(%opt == "NextPuntOpts"){
		Client::buildMenu(%clientId, "Managing "@ Client::getName(%cl), "manageplayer2", true);
		if(!$Slaped[%cl])
		{ Client::addMenuItem(%clientId, %curItem++ @"Slap "@ %name, "slap "@ %cl); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @"Stop Slap "@ %name, "Stopslap "@ %cl); }
		if(!%cl.NoDmg)
		{ Client::addMenuItem(%clientId, %curItem++ @"Disable Player Damage "@ %name, "noplayerdamage2 "@ %cl); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @"Enable Player Damage "@ %name, "yesplayerdamage2 "@ %cl); }
		if(%cl.leet)
		Client::addMenuItem(%clientId, %curItem++ @ "D-1ee7 " @ %name, "dleet " @ %cl);
		else
		Client::addMenuItem(%clientId, %curItem++ @ "Leetify " @ %name, "leet " @ %cl);
 	      	Client::addMenuItem(%clientId, %curItem++ @ "Teleport " @ %name, "Tele " @ %cl); 
     	  	Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "ObsEm " @ %cl); 
		return;
	}
	else if(%opt == "unfreeze")
	{
		%player = Client::getOwnedObject(%clientId);
		Freeze(%cl, true);
		%player.shieldStrength = 0.0;
		MessageAll(1, Client::getName(%cl) @"'s punk ass has been defrosted by the heater.~wCapturedTower.wav");
		return;
	}
	else if(%opt == "respawn")
	{	
		if(Client::Getteam(%cl) == "-1")
		{	
			if(getNumTeams() == 1) 
			{
				gamebase::setteam(%cl,0);
			}
			else
			{
				%rnd = floor(getRandom() * 2);
				gamebase::setteam(%cl,%rnd);
					
			}
			Game::playerSpawn(%cl, true); // dono why but you cant change teams unless you die first...
			playNextAnim(%cl);
			Player::kill(%cl);
			Game::playerSpawn(%cl, true);
			return;
		}
		playNextAnim(%cl);
		Player::kill(%cl);
		MessageAll(1, Client::getName(%cl) @"'s punk ass has been respawned by "@ Client::getName(%clientId) @".~wCapturedTower.wav");
		Game::playerSpawn(%cl, true);
		return;
	}
	else if(%opt == "enojy")
	{	
		Happy(%cl);
		MessageAll(1, Client::getName(%cl) @"'s punk ass is being raped by "@ Client::getName(%clientId) @".~wCapturedTower.wav");
		return;
	}
	else if(%opt == "BU")
	{
		Player::blowUp(%cl);
 		Player::Kill(%cl);
		MessageAll(1, Client::getName(%cl) @"'s punk ass has been blown up by "@ Client::getName(%clientId) @".~wCapturedTower.wav");
	}
	else if(%opt == "ClearScore")
	{
		%cl.score = 0;
		Game::refreshClientScore(%cl);	
		MessageAll(1, Client::getName(%cl) @"'s score was cleared by "@ Client::getName(%clientId) @".~wCapturedTower.wav");
	}
   Game::menuRequest(%clientId);
}

function processMenumanageplayer2(%clientId, %option)
{
	if(!%clientId.isSuperAdmin) return; // PORT: no admin test (the menu is built for super admins only)
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
	
        if(%opt == "slap")
	{
	$Slaped[%cl] = True;
	$firstslap[%cl] = True;
	slap(%cl);
	MessageAll(1, Client::getName(%cl) @" has been slapped by "@ Client::getName(%clientId) @".~wCapturedTower.wav");
	return;
	}
	else if(%opt == "Stopslap")
	{
	$Slaped[%cl] = False;
	$firstslap[%cl] = False;
	MessageAll(1, ""@Client::getName(%clientId) @" stopped slapping "@ Client::getName(%cl) @".~wCapturedTower.wav");
	return;
	}
	else if(%opt == "noplayerdamage2")
	{
	%cl.NoDmg = True;
	MessageAll(1, Client::getName(%clientId) @" has disabled player damage for "@ Client::getName(%cl) @".~wCapturedTower.wav");
	return;
	}
	else if(%opt == "yesplayerdamage2")
	{
	%cl.NoDmg = False;
	MessageAll(1, Client::getName(%clientId) @" has enabled player damage for "@ Client::getName(%cl) @".~wCapturedTower.wav");
	return;
	}
   	else if(%opt == "leet")
   	{
		MessageAll(1, Client::getName(%cl) @" was leetify by "@ Client::getName(%clientId) @".~wCapturedTower.wav");
		%cl.leet = true;
	}	
   	else if(%opt == "dleet") 
   	{ 	
   		%cl.leet = "";
		MessageAll(1, Client::getName(%cl) @" was de-leetify by "@ Client::getName(%clientId) @".~wCapturedTower.wav");
		Client::sendMessage(%cl,0,"You are no longer 1337.");
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" removed your 1337ness, get over it.");	
	}
	else if(%opt == "Tele")
	{
	        Client::buildMenu(%clientId, "Teleport Options:", "teleport", true);
	        Client::addMenuItem(%clientId, "1Teleport To You", "toyou " @ %cl);
	        Client::addMenuItem(%clientId, "2Teleport To", "to " @ %cl);
	        Client::addMenuItem(%clientId, "3Don't Teleport", "no " @ %cl);
	        return;
	}
        else if(%opt == "ObsEm")
        {
 	       Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
 	       %clientId.Obsing = True;
 	       Observer::setOrbitObject(%clientId, %cl, 5, 5, 5);
 	       bottomprint(%clientId,"<JC><F2>Now observing "@Client::GetName(%cl)@", suicide to stop obsing. *You will not die*",9999);
 	       return;
        }
}


function processMenufreezetime(%clientId, %option)
{
	if(!%clientId.isSuperAdmin) return; // PORT: no admin test (the menu is built for super admins only)
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	
	Freeze(%cl, false, %opt);
	if(%opt == "perma")
	{ %word = "Permanently"; }
	else
	{ %word = "for "@ %opt @" seconds"; }
	messageAll(1, Client::getName(%cl) @ " has been frozen by "@ Client::getName(%clientId) @" "@ %word @ ".~wCapturedTower.wav");
}

function Freeze(%clientId, %option, %time) 
{
	%player = Client::getOwnedObject(%clientId);
	%player.frozen = true;
	%player.shieldStrength = 500.0;

	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player) && !%option)
	{ 
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		Observer::setOrbitObject(%clientId, %clientId, 3, 3, 3);
		if(%time != "perma")
		{
			Schedule("Freeze("@ %clientId @", true);", %time);
			Schedule("MessageAll(1, \""@ escapeString(Client::getName(%clientId)) @"'s punk ass has been defrosted by the heater.\");", %time); // PORT: name escaped, string closed
			Schedule("Client::sendMessage("@ %clientId @", 1, \"Your punk ass has been defrosted by the heater.\");", %time); // PORT: string closed
		}
  	}
	else if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player) && %option)
	{ 
		Client::setControlObject(%clientId, %clientId);
		%player.frozen = false;
		%player.shieldStrength = 0.0;
  	}
  	if(%option)
  		%player.frozen = false;
}

function Silence(%clientId)
{
	if(%clientId.silenced == false)
	{ %clientId.silenced = true; }
	else
	{ %clientId.silenced = false; }
}

function Admin::fun(%admin,%clientId,%word)
{
	if(%admin == -1)
	{
		messageAll(1, Client::getName(%clientId) @ " was "@ %word @ " by consensus.~wCapturedTower.wav");
	}
	else
	{
		messageAll(1, Client::getName(%clientId) @ " was "@ %word @ " by "@ Client::getName(%admin)@".~wCapturedTower.wav");
	}
	if(%word=="De-Tongued")
	{ %clientId.silenced = true; }
	if(%word=="Un-Muted")
	{ %clientId.silenced = ""; }
	if(%word=="frozen")
	{
		freeze(%clientId, false, 160);
  		messageall(1, Client::getName(%clientId) @" was "@ %word @" for 2 minutes by consensus.");
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
 	else if(getWord(%opt, 0) == "Super")
 	{
 		if(%clientId.isSuperAdmin)
 		{
 			%cl = getWord(%opt, 1);
 			%cl.isAdmin = true;
 			%cl.isSuperAdmin = true;
 			messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into a super admin.");
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

function processMenuDeAaffirm(%clientId, %opt)
{
	%name = Client::getName(%clientId);
	if(getWord(%opt, 0) == "yes")
	{
	if(%clientId.isSuperAdmin)
		{
			%cl = getWord(%opt, 1);
			%cl.isAdmin = false;
			%cl.isSuperAdmin = false;
			messageAll(0, Client::getName(%clientId) @ " stripped " @ Client::getName(%cl) @ "'s admin status.");
		}		
	}
	Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{
   remoteSetTimeLimit(%clientId, %opt);
}

function voteForce(%clientId)
{
	if (%clientId.isSuperAdmin){ // PORT: was (%client.isSuperAdmin = true)
	Client::buildMenu(%clientId, "Force Vote:", "options", true);
	Client::addMenuItem(%clientId, %curItem++ @ "PASS " @ $curVoteTopic, "forceyes " @ $curVoteCount); 
	Client::addMenuItem(%clientId, %curItem++ @ "FAIL " @ $curVoteTopic, "forceno " @ $curVoteCount); 
	}
	else
		Messageall(0,Client::getName(%clientId) @ " Is attempting to Force A Vote");
		return;
}

function adminMenu(%clientId)
{
      Client::buildMenu(%clientId, "Admin Options:", "options", true);
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

function voteMenu(%clientId)
{
	Client::buildMenu(%clientId, "Voting Options:", "options", true);
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

function slap(%cl)
{
%vel1 = "0 0 0";
%vel2 = "0 500 90";
%vel3 = "0 0 0";
%vel4 = "500 0 90";
%vel5 = "0 0 0";
%vel6 = "0 -500 90";
%vel7 = "0 0 0";
%vel8 = "-500 0 90";
if(!$Slaped[%cl]) return;
if($firstslap[%cl] == True)
{
       Item::SetVelocity(%cl,"0 0 0");
       Player::ApplyImpulse(%cl,"0 0 800");
       $firstslap[%cl] = false;
}
if(!$Slaped[%cl]) return;
schedule("Item::SetVelocity("@%cl@",\"" @%vel1@ "\");",1);
if(!$Slaped[%cl]) return;
schedule("Player::ApplyImpulse("@%cl@",\"" @%vel2@ "\");",1);
if(!$Slaped[%cl]) return;
schedule("Item::SetVelocity("@%cl@",\"" @%vel3@ "\");",2);
if(!$Slaped[%cl]) return;
schedule("Player::ApplyImpulse("@%cl@",\"" @%vel4@ "\");",2);
if(!$Slaped[%cl]) return;
schedule("Item::SetVelocity("@%cl@",\"" @%vel5@ "\");",3);
if(!$Slaped[%cl]) return;
schedule("Player::ApplyImpulse("@%cl@",\"" @%vel6@ "\");",3);
if(!$Slaped[%cl]) return;
schedule("Item::SetVelocity("@%cl@",\"" @%vel7@ "\");",4);
if(!$Slaped[%cl]) return;
schedule("Player::ApplyImpulse("@%cl@",\"" @%vel8@ "\");",4);
if(!$Slaped[%cl]) return;
schedule("slap("@%cl@");",4);
}

function processMenuteleport(%clientId, %option)
{
	if(!%clientId.isSuperAdmin) return; // PORT: no admin test (the menu is built for super admins only)
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   if(%opt == "toyou")
   {
      %pos = Gamebase::getposition(%clientid);
      Gamebase::setposition(%cl,%pos);
      return;
   }
   else if(%opt == "to")
   {
      %posa = Gamebase::getposition(%cl);
      Gamebase::setposition(%clientId,%posa);
      return;
   }
   Game::menuRequest(%clientId);
}

function Happy(%client)
{
	if(%client.rapin == "10")
	{ 
	%client.rapin=0;
	return;
	}
	%client.rapin++;
	Player::setAnimation(%client,48);
	Player::setDamageFlash(%client,10);
	%vel = Item::getVelocity(%client);
	%z = getword(%vel,2);
	%NewVel = "0 0 "@%z; 
	Item::setVelocity(%client,%NewVel);
	Player::applyImpulse(%client,"0 0 -500");
	if(Client::getGender(%client)=="Male")
	{client::SendMessage(%client, 1,"~wmale1.wdsgst4.wav");}
	else
	{client::SendMessage(%client, 1,"~wfemale3.wdeath.wav");}
	schedule("Happy("@%client@");",0.8);
}
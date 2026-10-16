// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
// Thanks to WorstAim for catching my own stupid mistake! (10-2-04)
// Yet again... =D (10-3-04)
//
//----------------------------------------------------------------------------
$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

$Console::Prompt = "> ";

function Admin::Posses(%clientId, %cl, %opt)
{
	%posseeId = %cl;
	%posseeName = Client::getName(%cl);
	%posseePlayer = Client::getOwnedObject(%cl);
	%posseeStatus = "";

	%posserId = %clientId;
	%posserName = Client::getName(%clientId);
	%posserPlayer = Client::getOwnedObject(%clientId);
	%posserStatus = "";

	if(%opt == 0)
	{
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

		// Possesed Person data.
		%posseeId.isPossessed = true;
		%posseePlayer.shieldStrength = 350.0;
		%posseeId.Possby = %posserId;
		%posseeId.noSuicide = 1;
		%posseeId.guiLock = true;
		%posseePlayer.guiLock = true;

		// Possesser data.
		%posserPlayer.shieldStrength = 350.0;
		%posserId.isPossessing = true;
		%posserId.hasPossPlayer = %posseePlayer;
		%posserId.hasPossClient = %posseeId;

		// Set possessed client as an observer.
		Client::setControlObject(%posseeId, Client::getObserverCamera(%posseeId));


		// Set possessed client to obs his body.
		Observer::setOrbitObject(%posseeId, %posseePlayer, 3, 3, 3);
		CenterPrint(%posseeId, "<jc><f1>You have been possessed by <f2>"@ %posserName, 10);


		// Set the possesser player as the possessee player.
		Client::setControlObject(%posserId, %posseePlayer);

		return;
	}
	else if(%opt == 1)
	{
		// If the client you've selected isn't possessed, I'll let ya know your a retard... :)
		if(!%posseeId.isPossessed)
		{ Client::sendMessage(%posserId, 0, "Selected Client Is Not Possessed.~wAccess_Denied.Wav"); return; }

		// If the client calling this function is not the actual possesser, then we need
		// to reset the id, the name, and the player to the right one.
		if(%posserId != %posseeId.Possby)
		{
			%posserId = %posseeId.Possby;
			%posserName = Client::getName(%posserId);
			%posserPlayer = Client::getOwnedObject(%posserId);
		}

		// Possessed Player data.
		%posseeId.isPossessed = false;
		%posseePlayer.shieldStrength = 0.0;
		%posseeId.Possby = "";
		%posseeId.noSuicide = 0;
		%posseeId.guiLock = false;
		%posseePlayer.guiLock = false;

		// Possesser Player data.
		%posserPlayer.shieldStrength = 0.0;
		%posserId.isPossessing  = false;
		%posserId.hasPossPlayer = "";
		%posserId.hasPossClient = "";

		CenterPrint(%posseeId, "<jc><f1>You have been restored to your body by <f2>"@ %posserName, 10);

		// Reset clients to their normal bodies.
		Client::setControlObject(%posserId, %posserPlayer);
		Client::setControlObject(%posseeId, %posseePlayer);

		return;
	}
}

function Admin::changeMissionMenu(%clientId)
{
   Client::buildMenu(%clientId, Language::getString("changeMissionMenu"), "cmtype", true);
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
   Client::buildMenu(%clientId, Language::getString("MenuCMType"), "cmission", true);
   
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
      messageAll(0, Language::getString("CMission", Client::getName(%clientId), %misName, %misType));
		Vote::changeMission();
      Server::loadMission(%misName);
   }
   else
   {
      Admin::startVote(%clientId, Language::getString("CMissionVote", %misName, %misType), "cmission", %misName);
      Game::menuRequest(%clientId);
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
         messageAll(0, Language::getString("SetTimeLimit", Client::getName(%client), %time));
      else
         messageAll(0, Language::getString("SetTimeLimitDis", Client::getName(%client)));
         
   }
}

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
   if(%team >= 0 && %team < 8 && %client.isAdmin)
   {
      $Server::teamName[%team] = %teamName;
      $Server::teamSkin[%team] = %skinBase;
      messageAll(0, Language::getString("SetInfoRemote", %team, %teamName, %skinBase, Client::getName(%client)));
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
   return;
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
   return;
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
         %word = Language::getString("Banned");
         %cmd = String::MakeCaps(Language::getString("Ban")) @ ": ";
      }
      else
      {
         %word = Language::getString("Kicked");
         %cmd = String::MakeCaps(Language::getString("Kick")) @ ": ";
      }
      if(%client.isSuperAdmin)
      {
         if(%admin == -1)
            messageAll(0, Language::getString("AdminKickFail", %word));
         else
            Client::sendMessage(%admin, 0, Language::getString("AdminKickFail", %word));
         return;
      }
      %ip = Client::getTransportAddress(%client);

      echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);

      if(%ip == "")
         return;
      if(%ban)
         BanList::add(%ip, 9999999999999999999999);
      else
         BanList::add(%ip, 32);

      %client.banned = %ban;

      %name = Client::getName(%client);
      DestroyAllClObj(%client, -1);
      if(%admin == -1)
      {
         MessageAll(0, Language::getString("AdminKick", %name, %word, Language::getString("Consensus") @ "."));
         Net::kick(%client, Language::getString("AdminKickCL", %word, Language::getString("Consensus") @ "."));
      }
      else
      {
         MessageAll(0, Language::getString("AdminKick", %name, %word, Client::getName(%admin)));
         Net::kick(%client, Language::getString("AdminKickCL", %word, Client::getName(%admin)));
      }
   }
}

function Admin::setModeFFA(%clientId)
{
   return;
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
   return;
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
   else if($curVoteAction == "destAll")
      DeleteAllObjects();
   else if($curVoteAction == "reset")
      Server::refreshData();
   else if($curVoteAction == "EnTag")
      Account::EnableLaserTag("",0);
   else if($curVoteAction == "EnTagTeam")
      Account::EnableLaserTag("",1);
   else if($curVoteAction == "DisTag")
      Account::DisableLaserTag("");
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
            messageAll(0, Language::getString("VotePass", $curVoteTopic, %votesFor, %totalVotes - %votesFor));
            Admin::voteSucceded();
            $curVoteTopic = "";
            return;
         }
      }
      messageAll(0, Language::getString("VoteFail", $curVoteTopic, %votesFor ,%votesAgainst, %totalClients - (%votesFor + %votesAgainst)));
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
      Client::sendMessage(%clientId, 0, Language::getString("StartVoteFail1", %diff));
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
      bottomprintall("<jc><f1>" @ Language::getString("StartVote", Client::getName(%clientId) @ " <f0>", $curVoteTopic), 10);
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
      Client::sendMessage(%clientId, 0, Language::getString("StartVoteFail2"));
   }
}

function Game::menuRequest(%clientId)
{
   if(%clientId.isPossessed == true)
        return;

   if(%clientId.ModXAccount == false)
       return;

   if(%clientId.UsingMenu == true)
       return;
       
   %clientId.UsingMenu = true;
   schedule(%clientId@".UsingMenu = false;", 0.5);

   %curItem = 0;
   Client::buildMenu(%clientId, Language::getString("Options"), "options", true);

   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);
      
      if(%clientId.isAdmin)
      {
         %bool = true;
         if(%sel.isAdmin == true && %clientId.isAdmin == true)
            %bool = false;
         if(%clientId.isSuperAdmin == true)
            %bool = true;
         if(%sel.isSuperAdmin == true)
            %bool = false;

         if(%bool == true)
         {
             //MiD Helped Here, heheh...
             Client::addMenuItem(%clientId, %curItem++ @ Language::getString("AdminTorture"), "torture");

             if(%clientId.isSuperAdmin)
                Client::addMenuItem(%clientId, %curItem++ @ Language::getString("AdminOptions"), "AdminFunct");
         }
      }
      else
      {
          if($curVoteTopic == "")
          {
              Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
          }
      }
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ Language::getString("Unmute") @ " " @ %name, "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ Language::getString("Mute") @ " " @ %name, "mute " @ %sel);
      if(%clientId.observerMode == "observerOrbit")
         Client::addMenuItem(%clientId, %curItem++ @ Language::getString("Observe") @ " " @ %name, "observe " @ %sel);
      return;
   }
   if(!$matchStarted || !$Server::TourneyMode)
   {
      Client::addMenuItem(%clientId, %curItem++ @ Language::getString("ChangeTeamMenu"), "changeteams");
   }

   Client::addMenuItem(%clientId, %curItem++ @ Language::getString("ModXObjOptMenu"), "creatorsettings");
   Client::addMenuItem(%clientId, %curItem++ @ Language::getString("UndoLast"), "undolast");
   Client::addMenuItem(%clientId, %curItem++ @ Language::getString("RedoLast"), "redolast");
   Client::addMenuItem(%clientId, %curItem++ @ Language::getString("AcctMgmt"), "acct");
   if($curVoteTopic != "" && %clientId.vote == "")
   {
      Client::addMenuItem(%clientId, %curItem++ @ Language::getString("VoteYesTo") @ " " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ Language::getString("VoteNoTo") @ " " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }
   else if($curVoteTopic == "" && !%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ Language::getString("Vote"), "voteMenu");
   }
   else if(%clientId.isAdmin)
   {
      //Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
      Client::addMenuItem(%clientId, %curItem++ @ Language::getString("AdminOptions"), "funadmin");
   }
   Client::addMenuItem(%clientId, %curItem++ @ Language::getString("PlayerInd"), "PlayerIndex");

}

function remoteSelectClient(%clientId, %selId)
{
   if(%selId != "") %selId = floor(%selId); // PORT: a client id, not client text (it is spliced into schedule strings below)
   if(%clientId.selClient != "")     //Make sure to 'clear the air' before going on.
   {
      %clientId.selClient = "";
      Game::menuRequest(%clientId);
   }
   
   if(%clientId.selClient != %selId)
   {
      %clientId.selClient = %selId;
      if(%clientId.menuMode == "options")
         Game::menuRequest(%clientId);
      remoteEval(%clientId, "setInfoLine", 1, Language::getString("PlayerInfo") @ " " @ Client::getName(%selId) @ ":");
      remoteEval(%clientId, "setInfoLine", 2, Language::getString("RealName") @ ": " @ $Client::info[%selId, 1]);
      remoteEval(%clientId, "setInfoLine", 3, Language::getString("Email") @ ": " @ $Client::info[%selId, 2]);
      remoteEval(%clientId, "setInfoLine", 4, "Tribe: " @ $Client::info[%selId, 3]);
      remoteEval(%clientId, "setInfoLine", 5, "URL: " @ $Client::info[%selId, 4]);
      //if (%clientId.isAdmin == false)                                                      //Just as a precaution
          //remoteEval(%clientId, "setInfoLine", 6, "Other: " @ $Client::info[%selId, 5]);
      if (%clientId.isAdmin == true)
          remoteEval(%clientId, "setInfoLine", 6, "IP: " @ $Client::info[%selId, 6]);
   }
}

function processMenuAdminFunct(%clientId, %option)
{
    %cl = %clientId.SelClient;
    %acctNo = %cl.AcctNo;
    %opt[0] = getWord(%option, 0);
    %opt[1] = getWord(%option, 1);
    %opt[2] = getWord(%option, 2);
    %opt[3] = getWord(%option, 3);

    if(%clientId.isSuperAdmin != true)
        return;
        
    if(%cl.isSuperAdmin == true)
    {
        Game::menuRequest(%clientId);
        return;
    }
    
	if(%opt[0] == "init")
    {
        Client::buildMenu(%clientId, Language::getString("AdminTorture") @ ": " @ Client::getName(%cl), "AdminFunct", true);
        Client::addMenuItem(%clientId, %curItem++ @ "Temp-Admin", "tempadmin");
        if(Account::isAdmin(%acctNo))
            Client::addMenuItem(%clientId, %curItem++ @ Language::getString("Revoke") @ " " @ Language::getString("Admin"), "admin");
        else
            Client::addMenuItem(%clientId, %curItem++ @ Language::getString("Grant") @ " " @ Language::getString("Admin"), "admin");
        
    }

    if(%opt[0] == "tempadmin")
    {
       Client::buildMenu(%clientId, Language::getString("Confirm") @ ":", "aaffirm", true);
       Client::addMenuItem(%clientId, "1" @ Language::getString("Yes"), "yes " @ %cl);
       Client::addMenuItem(%clientId, "2" @ Language::getString("No"), "no " @ %cl);
       return;
    }

    if(%opt[0] == "admin")
    {
        Account::toggleAdmin(%acctNo);
    }
}

function ProcessMenuTorture(%clientId, %option)
{
    %opt = getWord(%option, 0);
    %cl = getWord(%option, 1);
    if(%cl != %clientId.SelClient)
        %cl = %clientId.SelClient;
    %name = Client::getName(%clientId.SelClient);
    %alt = getWord(%option, 2);

    %clName = Client::getName(%cl);
    %clientIdName = Client::getName(%clientId);

    if(%clientId.isAdmin != true)
        return;

    if(%cl.isSuperAdmin)
    {
        //Just to be sure...
        Game::menuRequest(%clientId);
        return;
    }

	if (%opt == "torture")
    {
        Client::buildMenu(%clientId, Language::getString("AdminTorture") @ ": " @ %name, "torture", true);
        Client::addMenuItem(%clientId, %curItem++ @ Language::getString("ChangeTeam"), "fteamchange " @ %cl);
        Client::addMenuItem(%clientId, %curItem++ @ Language::getString("Slap"), "slap " @ %cl);
        Client::addMenuItem(%clientId, %curItem++ @ Language::getString("Slay"), "slay " @ %cl);
        Client::addMenuItem(%clientId, %curItem++ @ Language::getString("kick"), "kick " @ %cl);
        Client::addMenuItem(%clientId, %curItem++ @ Language::getString("Blind"), "thirtydamage " @ %cl);
        Client::addMenuItem(%clientId, %curItem++ @ Language::getString("ContinuousSlay"), "oneminkill " @ %cl);
        if(%cl.CannotDeploy == false)
           Client::addMenuItem(%clientId, %curItem++ @ Language::getString("Disable") @ " " @ Language::getString("ToolAccess"), "tnodep " @ %cl);
        if(%cl.CannotDeploy == true)
           Client::addMenuItem(%clientId, %curItem++ @ Language::getString("Enable") @ " " @ Language::getString("ToolAccess"), "tnodep " @ %cl);
        Client::addMenuItem(%clientId, ">" @ Language::getString("Next"), "torture2");
        return;
    }
    else if(%opt == "torture2")
    {
        Client::buildMenu(%clientId, "Torture: " @ %name, "torture", true);

        if(Account::isBanned(%cl.AcctNo))
            Client::addMenuItem(%clientId, %curItem++ @ "Unban Account", "tban " @ %cl);
        else
            Client::addMenuItem(%clientId, %curItem++ @ "Ban Account", "tban " @ %cl);

        if(%clientId.isSuperAdmin)
        {
           Client::addMenuItem(%clientId, %curItem++ @ Language::getString("Ban"), "ban " @ %cl);
        }
        Client::addMenuItem(%clientId, %curItem++ @ Language::getString("DestAllClObj"), "destobj " @ %cl);
        if(%cl.isGagged == true)
            Client::addMenuItem(%clientId, %curItem++ @ Language::getString("UngagPL"), "gag " @ %cl @ " FALSE");
        else
            Client::addMenuItem(%clientId, %curItem++ @ Language::getString("GagPL"), "gag " @ %cl @ " TRUE");
        if(%cl.isLlama == true)
            Client::addMenuItem(%clientId, %curItem++ @ "Unllama" @ " " @ Language::getString("Player"), "llama " @ %cl @ " FALSE");
        else
            Client::addMenuItem(%clientId, %curItem++ @ "Llama" @ " " @ Language::getString("Player"), "llama " @ %cl @ " TRUE");
        Client::addMenuItem(%clientId, "<Back", "torture");
        return;
    }

    if(%opt == "tban")
    {
        Account::toggleBanned(%cl.AcctNo);
        ProcessMenuTorture(%clientId, "torture2");
        return;
    }
     
   if(%opt == "destobj")
   {
      Client::buildMenu(%clientId, Language::getString("Confirm") @ ":", "torture", true);
      Client::addMenuItem(%clientId, "1" @ Language::getString("Yes"), "destaffirm " @ %cl @ " yes");
      Client::addMenuItem(%clientId, "2" @ Language::getString("No"), "destaffirm " @ %cl @ " no");
      return;
   }
   
   if(%opt == "gag")
   {
      GagClient(%cl, StrToBool(%alt));
      %msg = $GagMessage[BoolToNum(StrToBool(%alt))];
      %msg = sprintf(%msg, %clientIdName, %clName);
      Client::sendMessage(%cl, 1, %msg);
   }
   if(%opt == "llama")
   {
      LlamaClient(%cl, StrToBool(%alt));
      %msg = $LlamaMessage[BoolToNum(StrToBool(%alt))];
      %msg = sprintf(%msg, %clientIdName, %clName);
      Client::sendMessage(%cl, 1, %msg);
   }
   
   else if(%opt == "destaffirm")
   {
      if(%alt == "yes")
          DestroyAllClObj(%cl, %clientId);
   }
   else if(%opt == "slay")
   {
      Player::Slap(Client::getOwnedObject(%cl), 75);
      remoteKill(%cl);
      %msg = $SlayMessage[BoolToNum(StrToBool(true))];
      %msg = sprintf(%msg, %clientIdName, %clName);
      Client::sendMessage(%cl, 1, %msg);
   }
   else if (%opt == "slap")
   {
      Player::setdamageflash(%cl, 100);
      Player::Slap(Client::getOwnedObject(%cl), 75);
      %msg = $SlapMessage[BoolToNum(StrToBool(true))];
      %msg = sprintf(%msg, %clientIdName, %clName);
      Client::sendMessage(%cl, 1, %msg);
   }
   else if (%opt == "thirtydamage")
   {
      %msg = $BlindMessage[BoolToNum(StrToBool(true))];
      %msg = sprintf(%msg, %clientIdName, %clName);
      Client::sendMessage(%cl, 1, %msg);
      for(%i = 0.1; %i < $BlindTime; %i += 0.1)
         schedule("player::setDamageFlash("@%cl@", 256);",%i);
   }
   else if (%opt == "oneminkill")
   {
      %msg = $ContKillMessage[BoolToNum(StrToBool(true))];
      %msg = sprintf(%msg, %clientIdName, %clName);
      Client::sendMessage(%cl, 1, %msg);
      for(%i = 0.1; %i < $ContKillTime; %i += 0.1)
         schedule("remoteKill("@%cl@");",%i);
   }
   else if(%opt == "kick")
   {
      Client::buildMenu(%clientId, Language::getString("Confirm") @ ":", "kaffirm", true);
      Client::addMenuItem(%clientId, "1" @ Language::getString("Yes"), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2" @ Language::getString("No"), "no " @ %cl);
      return;
   }
   else if(%opt == "tnodep")
   {
      ToggleDepPriv(%cl);
      %msg = $ToggleToolsMessage[BoolToNum(StrToBool(%cl.CannotDeploy))];
      %msg = sprintf(%msg, %clientIdName, %clName);
      Client::sendMessage(%cl, 1, %msg);
   }
   else if(%opt == "ban")
   {
      Client::buildMenu(%clientId, Language::getString("Confirm") @ ":", "baffirm", true);
      Client::addMenuItem(%clientId, "1" @ Language::getString("Yes"), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2" @ Language::getString("No"), "no " @ %cl);
      return;
   }
   else if(%opt == "fteamchange")
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, Language::getString("PickTeam"), "FPickTeam", true);
      Client::addMenuItem(%clientId, "0" @ Language::getString("Observer"), -2);
      Client::addMenuItem(%clientId, "1" @ Language::getString("Automatic"), -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      return;
   }
   ProcessMenuTorture(%clientId, "torture");
}
function ProcessMenuFunAdmin(%clientId, %option)
{
    if(%clientId.isAdmin != true)
        return;
    if (%option == 1)
	{
        DeleteAllObjects();
	}
    if(%option == "reset")
        processMenuOptions(%clientId, "reset");
    if(%option == "cmission")
       processMenuOptions(%clientId, "cmission");
    if(%option == "laser")
        Account::ToggleLaserTag(%clientId, 0);
    if(%option == "laserteam")
        Account::ToggleLaserTag(%clientId, 1);
    if(%option == "PlayerIndexAdmin")
        processMenuPlayerIndexAdmin(%clientId, %option @ " init");

}

function ProcessMenuVoteMenu(%clientId, %option)
{
	if (%option == "voteMenu")
	{
        Client::buildMenu(%clientId, Language::getString("Vote") @ " " @ Language::getString("Menu"), "voteMenu", true);
        Client::addMenuItem(%clientId, "0" @ "Change mission", "voteMission");
        Client::addMenuItem(%clientId, "1" @ Language::getString("DestAll"), "voteDestAll");
        Client::addMenuItem(%clientId, "2" @ Language::getString("ResetSrvDfl"), "voteReset");
        if($LaserTagMode)
            Client::addMenuItem(%clientId, "3" @ Language::getString("DisTag"), "voteDisTag");
        else
        {
            Client::addMenuItem(%clientId, "3" @ Language::getString("EnTag"), "voteEnTag");
            Client::addMenuItem(%clientId, "4" @ Language::getString("EnTagTeam"), "voteEnTagTeam");
        }
        return;
	}
    if (%option == "voteMission")
    {
        Admin::changeMissionMenu(%clientId, %opt == "cmission");
        return;
    }
    if (%option == "voteReset")
    {
        Admin::startVote(%clientId, Language::getString("ResetSrvDfl"), "reset", 0);
    }
    if (%option == "voteDestAll")
    {
        Admin::startVote(%clientId, Language::getString("DestAll"), "destAll", 0);
    }
    if (%option == "voteDisTag")
    {
        Admin::startVote(%clientId, Language::getString("DisTag"), "DisTag", 0);
    }
    if (%option == "voteEnTag")
    {
        Admin::startVote(%clientId, Language::getString("EnTag"), "EnTag", 0);
    }
    if (%option == "voteEnTagTeam")
    {
        Admin::startVote(%clientId, Language::getString("EnTagTeam"), "EnTagTeam", 0);
    }
    Game::menuRequest(%clientId);
}

function processMenuPlayerIndexAdmin(%clientId, %option)
{
    %opt[0] = getWord(%option, 0);
    %opt[1] = getWord(%option, 1);
    %opt[2] = getWord(%option, 2);
    %opt[3] = getWord(%option, 3);

    if(%clientId.isAdmin != true)
        return;

    if(%opt[0] == "PlayerIndexAdmin")
    {
       if (%opt[1] == "init")
       {
          Client::buildMenu(%clientId, Language::getString("PlayerInd") @ ":", "PlayerIndexAdmin", true);
          for(%i = 0; Account::GetNumberOf() > %i; %i++)
          {
              %acctno = %i;
              %name = $ModXAcctName::[%acctno];
              %j = %i + 1;
              if (%j == 8)
              {
                  %j = 0;
                  Client::addMenuItem(%clientId, %j @ Language::getString("Next") @ ">>", "PlayerIndexAdmin Next " @ %i);
                  break;
              }
              Client::addMenuItem(%clientId, %j @ %name, "PlayerIndexAdmin manage " @ %i);
          }
          return;
       }

       if (%opt[1] == "Next")
       {
          %h = %opt[2];
          Client::buildMenu(%clientId, Language::getString("PlayerInd") @ ":", "PlayerIndexAdmin", true);
          for(%i = 0; Account::GetNumberOf() > %i; %i++)
          {
              %acctno = %h;
              %name = $ModXAcctName::[%acctno];
              %j = %i + 1;
              if (%j == 8)
              {
                 %j = 0;
                 Client::addMenuItem(%clientId, %j @ Language::getString("Next") @ ">>", "PlayerIndexAdmin Next " @ %h);
                 break;
              }

              Client::addMenuItem(%clientId, %j @ %name, "PlayerIndexAdmin manage " @ %h);
              %h++;
    	  }
          return;
       }

       if(%opt[1] == "manage")
       {
          %acctno = %opt[2];
          Client::buildMenu(%clientId, "Manage " @ $ModXAcctName::[%acctno], "PlayerIndexAdmin", true);

          if(Account::isBanned(%acctNo))
            Client::addMenuItem(%clientId, "1" @ Language::getString("Unban") @ " " @ Language::getString("Account"), "PlayerIndexAdmin manage_ex " @ %acctno @ " ban");
          else
            Client::addMenuItem(%clientId, "1" @ Language::getString("Ban") @ " " @ Language::getString("Account"), "PlayerIndexAdmin manage_ex " @ %acctno @ " ban");

          if(%clientId.isSuperAdmin == true)
          {
              if(Account::isAdmin(%acctNo))
                Client::addMenuItem(%clientId, "2" @ Language::getString("Revoke") @ " " @ Language::getString("Admin"), "PlayerIndexAdmin manage_ex " @ %acctno @ " admin");
              else
                Client::addMenuItem(%clientId, "2" @ Language::getString("Grant") @ " " @ Language::getString("Admin"), "PlayerIndexAdmin manage_ex " @ %acctno @ " admin");
          }
          return;
       }
       
       if(%opt[1] == "manage_ex")
       {
          %acctno = %opt[2];
          if(%opt[3] == "ban")
          {
            Account::toggleBanned(%acctNo);
          }
          
          if(%opt[3] == "admin")
          {
            Account::toggleAdmin(%acctNo);
          }
          processMenuPlayerIndexAdmin(%clientId, "PlayerIndexAdmin manage " @ %acctno);
       }
    }
}

function processMenuPlayerIndex(%clientId, %option)
{
    %opt[0] = getWord(%option, 0);
    %opt[1] = getWord(%option, 1);
    %opt[2] = getWord(%option, 2);

    if(%opt[2] == "")
    {
       %opt[2] = "0";
    }
    %start = %opt[2];

    if(%opt[0] == "PlayerIndex")
    {
       if (%opt[1] == "init")
       {
          Client::buildMenu(%clientId, Language::getString("PlayerInd") @ ":", "PlayerIndex", true);
          for(%i = 0; Account::GetNumberOf() > %i; %i++)
          {
              %acctno = %i;
              %name = $ModXAcctName::[%acctno];
              %j = %i + 1;
              if (%j == 8)
              {
                  %j = 0;
                  Client::addMenuItem(%clientId, %j @ Language::getString("Next") @ ">>", "PlayerIndex Next " @ %i);
                  break;
              }
              Client::addMenuItem(%clientId, %j @ %name, "PlayerIndex init");
          }
          return;
       }

       if (%opt[1] == "Next")
       {
          %h = %opt[2];
          Client::buildMenu(%clientId, Language::getString("PlayerInd") @ ":", "PlayerIndex", true);
          for(%i = 0; Account::GetNumberOf() > %i; %i++)
          {
              %acctno = %h;
              %name = $ModXAcctName::[%acctno];
              %j = %i + 1;
              if (%j == 8)
              {
                 %j = 0;
                 Client::addMenuItem(%clientId, %j @ Language::getString("Next") @ ">>", "PlayerIndex Next " @ %h);
                 break;
              }

              Client::addMenuItem(%clientId, %j @ %name, "PlayerIndex Next " @ %start);
              %h++;
    	  }
          return;
       }
       if(%start == "0")
           processMenuPlayerIndex(%clientId, "PlayerIndex init");
       else
           processMenuPlayerIndex(%clientId, "PlayerIndex Next " @ %start);
       return;
    }
}

function processMenuMovePath(%clientId, %option) //Lanugage Stop...
{
    %opt[0] = getWord(%option, 0);
    %opt[1] = getWord(%option, 1); //Neater Way to do %alt, %alt2, etc...
    %opt[2] = getWord(%option, 2);
    %opt[3] = getWord(%option, 3);
    
    %selElev = %clientId.SelectedElev;
    
    if((%selElev.ElevStatus == "FORWARD" || %selElev.ElevStatus == "BACKWARD" || %selElev.ElevStatus == "") && isObject(%selElev) == true)
    {
        Client::buildMenu(%clientId, "Current Elevator Busy", "movepath", true);
        Client::addMenuItem(%clientId, "XChoose Another Elevator", "choose_elev init");
        return;
    }

    if(%opt[0] == "movepath")
    {
        if(isObject(%selElev) == false)
        {
            Client::buildMenu(%clientId, "Elevator Path Designer", "movepath", true);
            Client::addMenuItem(%clientId, "XChoose Elevator", "choose_elev init");
            return;
        }
        else
        {
            Client::buildMenu(%clientId, "Elevator Path Designer", "movepath", true);
            Client::addMenuItem(%clientId, "1Manage Markers", "manage_marks init");
            Client::addMenuItem(%clientId, "2Manage Elevator", "manage_elev init");
            Client::addMenuItem(%clientId, "XChoose Elevator", "choose_elev init");
            return;
        }
    }

    if(%opt[0] == "manage_marks")
    {
        if(isObject(%selElev) == false)
        {
            processMenuMovePath(%clientId, "movepath");
            return;
        }
        
        if(%opt[1] == "init")
        {
            Client::buildMenu(%clientId, "Path Marker Management", "movepath", true);
            for(%j = 0; %j < 4; %j++)
            {
               %epos = %selElev.EndPos[%j];
               if(%epos == "")
                  %epos = "!";
                  
               if(%epos != "!")
                  Client::addMenuItem(%clientId, %j @ "Manage Marker #"@%j, "manage_marks managemark "@%j@ " init");
               else
                  Client::addMenuItem(%clientId, %j @ "Create Marker #"@%j, "manage_marks createmark "@%j);

               if(%selElev.EndPos[%j + 1] == "" && %epos == "!")
                   break;
            }
            Client::addMenuItem(%clientId, "<Back", "movepath");
            return;
        }
        
        if(%opt[1] == "createmark")
        {
            Elevator::AddMarker(%selElev, %opt[2]);
        }
        
        if(%opt[1] == "managemark")
        {
            if(%opt[3] == "init")
            {
                Client::buildMenu(%clientId, "Managing Marker #" @ %opt[2], "movepath", true);
                Client::addMenuItem(%clientId, "1Reset Marker", "manage_marks managemark "@%opt[2]@ " reset");
                if(%selElev.EndPos[%opt[2] + 1] == "" && %opt[2] != "0")
                {
                    Client::addMenuItem(%clientId, "2Delete Marker", "manage_marks managemark "@%opt[2]@ " delete");
                }
                else
                {
                    if(%selElev.EndPos[3] != "" && %opt[2] == "3")
                        Client::addMenuItem(%clientId, "2Delete Marker", "manage_marks managemark "@%opt[2]@ " delete");
                }
                Client::addMenuItem(%clientId, "<Back", "manage_marks init");
                return;
            }
            
            if(%opt[3] == "delete")
            {
                Elevator::DelMarker(%selElev, %opt[2]);
                processMenuMovePath(%clientId, "manage_marks init");
                return;
            }

            if(%opt[3] == "reset")
            {
                //
                %selElevPos = GameBase::getPosition(%selElev);
                %selElev.EndPos[%opt[2]] = Vector::add(%selElevPos, "0 0 "@(%opt[2]+5));
                GameBase::setPosition(%selElev.Child[%opt[2]], %selElev.EndPos[%opt[2]]);
            }
            
            processMenuMovePath(%clientId, "manage_marks managemark "@%opt[2]@ " init");
            return;
        }
        
        processMenuMovePath(%clientId, "manage_marks init");
        return;
    }
        
    
    if(%opt[0] == "manage_elev")
    {
        if(isObject(%selElev) == false)
        {
            processMenuMovePath(%clientId, "movepath");
            return;
        }
        
        if(%opt[1] == "init")
        {
            Client::buildMenu(%clientId, "Elevator Management", "movepath", true);
            Client::addMenuItem(%clientId, "0Warp To Elevator", "manage_elev warpto");
            if(%selElev.weld == true)
                Client::addMenuItem(%clientId, "1Deactivate Elevator", "manage_elev deactivate");
            else
                Client::addMenuItem(%clientId, "1Activate Elevator", "manage_elev activate");
            if(%selElev.ElevLoop == true)
                Client::addMenuItem(%clientId, "2Toggle Loop, Current: On", "manage_elev loopoff");
            else
                Client::addMenuItem(%clientId, "2Toggle Loop, Current: Off", "manage_elev loopon");
            Client::addMenuItem(%clientId, "3Change Elevator Speed", "manage_elev speed init");
            if(%selElev.ElevLoop != true)
                Client::addMenuItem(%clientId, "4Change Elevator Delay", "manage_elev delay init");
            Client::addMenuItem(%clientId, "<Back", "movepath");
            return;
        }
        
        if(%opt[1] == "delay")
        {
            if(%opt[2] == "init")
            {
                Client::buildMenu(%clientId, "Elevator Delay", "movepath", true);
                Client::addMenuItem(%clientId, "11 Sec", "manage_elev delay 1");
                Client::addMenuItem(%clientId, "22 Sec", "manage_elev delay 2");
                Client::addMenuItem(%clientId, "32.5 Sec", "manage_elev delay 2.5");
                Client::addMenuItem(%clientId, "43 Sec", "manage_elev delay 3");
                Client::addMenuItem(%clientId, "53.5 Sec", "manage_elev delay 3.5");
                Client::addMenuItem(%clientId, "64 Sec", "manage_elev delay 4");
                Client::addMenuItem(%clientId, "74.5 Sec", "manage_elev delay 4.5");
                Client::addMenuItem(%clientId, "85 Sec", "manage_elev delay 5");
                return;
            }
            else
            {
                %selElev.ElevDelay = %opt[2];
            }
        }

        if(%opt[1] == "speed")
        {
            if(%opt[2] == "init")
            {
                Client::buildMenu(%clientId, "Elevator Speed", "movepath", true);
                Client::addMenuItem(%clientId, "1Fast", "manage_elev speed 0.01");
                Client::addMenuItem(%clientId, "2Medium-Fast", "manage_elev speed 0.05");
                Client::addMenuItem(%clientId, "3Normal", "manage_elev speed 0.1");
                Client::addMenuItem(%clientId, "4Medium-Slow", "manage_elev speed 0.15");
                Client::addMenuItem(%clientId, "5Slow", "manage_elev speed 0.19");
                return;
            }
            else
            {
                %selElev.ElevSpeed = %opt[2];
            }
        }
        
        if(%opt[1] == "loopon")
        {
            %selElev.ElevLoop = true;
        }

        if(%opt[1] == "loopoff")
        {
            %selElev.ElevLoop = false;
        }
        
        if(%opt[1] == "deactivate")
        {
          %selElev.weld = false;
          if(GameBase::getDataName(%selElev).className == "ModXElevator")
            schedule("Elevator::onWeld("@%selElev@","@%selElev.weld@");",0.1,%selElev);
        }
        
        if(%opt[1] == "activate")
        {
          %selElev.weld = true;
          if(GameBase::getDataName(%selElev).className == "ModXElevator")
            schedule("Elevator::onWeld("@%selElev@","@%selElev.weld@");",0.1,%selElev);
        }
        
        if(%opt[1] == "warpto")
        {
            %pl = Client::getOwnedObject(%clientId);
            %elevpos = GameBase::getPosition(%selElev);
            %warptopos = Vector::add(%elevpos, "0 0 1.5");
            GameBase::setPosition(%pl, %warptopos);
        }
        processMenuMovePath(%clientId, "manage_elev init");
        return;
    }
    
    if(%opt[0] == "choose_elev")
    {
       if (%opt[1] == "init")
       {
          Client::buildMenu(%clientId, "Choose Elevator:", "movepath", true);
          for(%i = 0; (%obj = %clientId.ClObj[%i]) != ""; %i++)
          {
              if(GameBase::getDataName(%obj).className == "ModXElevator")
              {
                  %desc = %obj.Desc;
                  %j = %i + 1;
                  if (%j == 8)
                  {
                     %j = 0;
                     Client::addMenuItem(%clientId, %j @ "Next >>", "choose_elev Next " @ %i);
                     break;
                  }

                  Client::addMenuItem(%clientId, %j @ %desc, "choose_elev " @ %obj);
              }
    	  }
          return;
       }

       if (%opt[1] == "Next")
       {
          %h = %opt[2];
          Client::buildMenu(%clientId, "Choose Elevator:", "movepath", true);
          for(%i = 0; (%obj = %clientId.ClObj[%h]) != ""; %i++)
          {
              if(GameBase::getDataName(%obj).className == "ModXElevator")
              {
                  %desc = %obj.Desc;
                  %j = %i + 1;
                  if (%j == 8)
                  {
                     %j = 0;
                     Client::addMenuItem(%clientId, %j @ "Next >>", "choose_elev Next " @ %h);
                     break;
                  }

                  Client::addMenuItem(%clientId, %j @ %desc, "choose_elev " @ %obj);
              }
              %h++;
    	  }
          return;
       }
       %clientId.SelectedElev = floor(%opt[1]); // PORT: an object id, not client text
       processMenuMovePath(%clientId, "movepath");
       return;
    }
}

function processMenuBotControl(%clientId, %option)
{
    %opt[0] = getWord(%option, 0);
    %opt[1] = getWord(%option, 1); //Neater Way to do %alt, %alt2, etc...
    %opt[2] = getWord(%option, 2);
    %opt[3] = getWord(%option, 3);

    if(%opt[0] == "botcontrol")
    {
        Client::buildMenu(%clientId, "Elevator Path Designer", "botcontrol", true);
        if(Client::getOwnedObject(%clientId) == Client::getControlObject(%clientId))
            Client::addMenuItem(%clientId, "1Control Bot", "control init");
        else
            Client::addMenuItem(%clientId, "1Release Bot", "controlbotstop");
    }

    if(%opt[0] == "controlbot")
    {
        if(Player::isAiControlled(%opt[1]) != true)
            return;
        Client::setControlObject(%clientId, %opt[1]);
    }

    if(%opt[0] == "controlbotstop")
    {
        Client::setControlObject(%clientId, Client::getOwnedObject(%clientId));
    }

    if(%opt[0] == "control")
    {
       if (%opt[1] == "init")
       {
          Client::buildMenu(%clientId, "Choose Bot", "botcontrol", true);
          for(%i = 0; (%obj = %clientId.ClObj[%i]) != ""; %i++)
          {
              if(%obj.isBot == true)
              {
                  %desc = Client::getName(Player::getClient(%obj));
                  %j = %i + 1;
                  if (%j == 8)
                  {
                     %j = 0;
                     Client::addMenuItem(%clientId, %j @ "Next >>", "control Next " @ %i);
                     break;
                  }

                  Client::addMenuItem(%clientId, %j @ %desc, "controlbot " @ %obj);
              }
    	  }
          return;
       }

       if (%opt[1] == "Next")
       {
          %h = %opt[2];
          Client::buildMenu(%clientId, "Choose Bot", "botcontrol", true);
          for(%i = 0; (%obj = %clientId.ClObj[%h]) != ""; %i++)
          {
              if(%obj.isBot == true)
              {
                  %desc = Client::getName(Player::getClient(%obj));
                  %j = %i + 1;
                  if (%j == 8)
                  {
                     %j = 0;
                     Client::addMenuItem(%clientId, %j @ "Next >>", "control Next " @ %h);
                     break;
                  }

                  Client::addMenuItem(%clientId, %j @ %desc, "controlbot " @ %obj);
              }
              %h++;
    	  }
          return;
       }
       %clientId.SelectedElev = floor(%opt[1]); // PORT: an object id, not client text
       processMenuMovePath(%clientId, "botcontrol");
       return;
    }
}

function ProcessMenuLayers(%clientId, %option)
{
    %opt[0] = getWord(%option, 0);
    %opt[1] = getWord(%option, 1);
    %opt[2] = getWord(%option, 2);
    %opt[3] = getWord(%option, 3);
    
    if (%opt[0] == "Layers")
	{
        Client::buildMenu(%clientId, "Layer Management", "layers", true);
        Client::addMenuItem(%clientId, "1Change Active Layer", "changeact");
        Client::addMenuItem(%clientId, "2Merge Layers", "merge");
        Client::addMenuItem(%clientId, "3Merge All Layers", "mergea");
        return;
	}
 
    if (%opt[0] == "changeact")
    {
        Client::buildMenu(%clientId, "Current: " @ WorkingLayer::getDesc(%clientId.currLayer), "layers", true);
        Client::addMenuItem(%clientId, "0" @ WorkingLayer::getDesc(-1), "changeactf -1");
        Client::addMenuItem(%clientId, "1" @ WorkingLayer::getDesc(0), "changeactf 0");
        Client::addMenuItem(%clientId, "2" @ WorkingLayer::getDesc(1), "changeactf 1");
        Client::addMenuItem(%clientId, "3" @ WorkingLayer::getDesc(2), "changeactf 2");
        Client::addMenuItem(%clientId, "4" @ WorkingLayer::getDesc(3), "changeactf 3");
        Client::addMenuItem(%clientId, "5" @ WorkingLayer::getDesc(4), "changeactf 4");
        Client::addMenuItem(%clientId, "6" @ WorkingLayer::getDesc(5), "changeactf 5");
        Client::addMenuItem(%clientId, "7" @ WorkingLayer::getDesc(6), "changeactf 6");
        return;
    }
    
    if (%opt[0] == "changeactf")
    {
        WorkingLayer::changeActiveLayer(%clientId, %opt[1]);
        bottomprint(%clientid,"<jc>Layer System: <f2>Current Layer: <f1> " @ WorkingLayer::getDesc(%clientId.currLayer));
        ProcessMenuLayers(%clientId, "Layers");
        return;
    }
    
    if (%opt[0] == "merge")
    {
        Client::buildMenu(%clientId, "Choose Merge Layer", "layers", true);
        Client::addMenuItem(%clientId, "1" @ WorkingLayer::getDesc(0), "mergen 0");
        Client::addMenuItem(%clientId, "2" @ WorkingLayer::getDesc(1), "mergen 1");
        Client::addMenuItem(%clientId, "3" @ WorkingLayer::getDesc(2), "mergen 2");
        Client::addMenuItem(%clientId, "4" @ WorkingLayer::getDesc(3), "mergen 3");
        Client::addMenuItem(%clientId, "5" @ WorkingLayer::getDesc(4), "mergen 4");
        Client::addMenuItem(%clientId, "6" @ WorkingLayer::getDesc(5), "mergen 5");
        Client::addMenuItem(%clientId, "7" @ WorkingLayer::getDesc(6), "mergen 6");
        return;
    }
    
    if (%opt[0] == "mergen")
    {
        Client::buildMenu(%clientId, "Choose Destination Layer", "layers", true);
        Client::addMenuItem(%clientId, "1" @ WorkingLayer::getDesc(0), "mergef 0 " @ %opt[1]);
        Client::addMenuItem(%clientId, "2" @ WorkingLayer::getDesc(1), "mergef 1 " @ %opt[1]);
        Client::addMenuItem(%clientId, "3" @ WorkingLayer::getDesc(2), "mergef 2 " @ %opt[1]);
        Client::addMenuItem(%clientId, "4" @ WorkingLayer::getDesc(3), "mergef 3 " @ %opt[1]);
        Client::addMenuItem(%clientId, "5" @ WorkingLayer::getDesc(4), "mergef 4 " @ %opt[1]);
        Client::addMenuItem(%clientId, "6" @ WorkingLayer::getDesc(5), "mergef 5 " @ %opt[1]);
        Client::addMenuItem(%clientId, "7" @ WorkingLayer::getDesc(6), "mergef 6 " @ %opt[1]);
        return;
    }
    
    if(%opt[0] == "mergef")
    {
        WorkingLayer::mergeLayer(%clientId, %opt[2], %opt[1]);
        bottomprint(%clientid,"<jc>Layer System: <f2>Layer <f1>" @ WorkingLayer::getDesc(%opt[2]) @ "<f2> is now merged with <f1>" @ WorkingLayer::getDesc(%opt[1]));
        ProcessMenuLayers(%clientId, "Layers");
        return;
    }
    
    if (%opt[0] == "mergea")
    {
        Client::buildMenu(%clientId, "Choose Destination Layer", "layers", true);
        Client::addMenuItem(%clientId, "1" @ WorkingLayer::getDesc(0), "mergeaf 0");
        Client::addMenuItem(%clientId, "2" @ WorkingLayer::getDesc(1), "mergeaf 1");
        Client::addMenuItem(%clientId, "3" @ WorkingLayer::getDesc(2), "mergeaf 2");
        Client::addMenuItem(%clientId, "4" @ WorkingLayer::getDesc(3), "mergeaf 3");
        Client::addMenuItem(%clientId, "5" @ WorkingLayer::getDesc(4), "mergeaf 4");
        Client::addMenuItem(%clientId, "6" @ WorkingLayer::getDesc(5), "mergeaf 5");
        Client::addMenuItem(%clientId, "7" @ WorkingLayer::getDesc(6), "mergeaf 6");
        return;
    }

    if(%opt[0] == "mergeaf")
    {
        WorkingLayer::mergeAllLayers(%clientId, %opt[1]);
        bottomprint(%clientid,"<jc>Layer System: <f2>All layers are now merged with <f1>" @ WorkingLayer::getDesc(%opt[1]));
        ProcessMenuLayers(%clientId, "Layers");
        return;
    }
}

function ProcessMenuAcct(%clientId, %option)
{
    %name = Client::getName(%clientId);
    %alt2 = GetWord(%option, 2);
    %alt = GetWord(%option, 1);
    %opt = GetWord(%option, 0);
    %player = Client::getOwnedObject(%clientId);
    if (%opt == "acct")
	{
        Client::buildMenu(%clientId, "Account Management", "acct", true);
        //Client::addMenuItem(%clientId, "1Account Settings", "settings");
        Client::addMenuItem(%clientId, "1Weapon Options", "weapopt");
        Client::addMenuItem(%clientId, "2Keyboard Options", "keyset");
        Client::addMenuItem(%clientId, "3Save Objects", "save");
        Client::addMenuItem(%clientId, "4Restore Objects", "restore");
        Client::addMenuItem(%clientId, "CChange Password", "chpass");
        if(%clientId.TransVel == true)
            Client::addMenuItem(%clientId, "XDisallow Bumping", "bump");
        else
            Client::addMenuItem(%clientId, "XAllow Bumping", "bump");
        return;
	}

    if (%opt == "bump")
    {
        if(%clientId.TransVel == true)
            %clientId.TransVel = false;
        else
            %clientId.TransVel = true;
        ProcessMenuAcct(%clientId, "acct");
    }

    if (%opt == "chpass")
    {
        Account::ChangePassword(%clientId);
        return;
    }

    if (%opt == "keyset")
	{

        Client::buildMenu(%clientId, "Keyboard Options", "acct", true);
        Client::addMenuItem(%clientId, "1 " @ Account::LetterToFuncDesc(Account::getBoundFunc(%player, 0)), "keychangesel 0");
        Client::addMenuItem(%clientId, "2 " @ Account::LetterToFuncDesc(Account::getBoundFunc(%player, 1)), "keychangesel 1");
        Client::addMenuItem(%clientId, "3 " @ Account::LetterToFuncDesc(Account::getBoundFunc(%player, 2)), "keychangesel 2");
        Client::addMenuItem(%clientId, "4 " @ Account::LetterToFuncDesc(Account::getBoundFunc(%player, 3)), "keychangesel 3");
        Client::addMenuItem(%clientId, "5 " @ Account::LetterToFuncDesc(Account::getBoundFunc(%player, 4)), "keychangesel 4");
        Client::addMenuItem(%clientId, "6 " @ Account::LetterToFuncDesc(Account::getBoundFunc(%player, 5)), "keychangesel 5");
        Client::addMenuItem(%clientId, "7 " @ Account::LetterToFuncDesc(Account::getBoundFunc(%player, 6)), "keychangesel 6");
        Client::addMenuItem(%clientId, ">Next", "keyset2");
        return;

    }
    
    if (%opt == "keyset2")
	{

        Client::buildMenu(%clientId, "Keyboard Options", "acct", true);
        Client::addMenuItem(%clientId, "8 " @ Account::LetterToFuncDesc(Account::getBoundFunc(%player, 7)), "keychangesel 7");
        Client::addMenuItem(%clientId, "9 " @ Account::LetterToFuncDesc(Account::getBoundFunc(%player, 8)), "keychangesel 8");
        Client::addMenuItem(%clientId, "G " @ Account::LetterToFuncDesc(Account::getBoundFunc(%player, 9)), "keychangesel 9");
        Client::addMenuItem(%clientId, "M " @ Account::LetterToFuncDesc(Account::getBoundFunc(%player, 10)), "keychangesel 10");
        Client::addMenuItem(%clientId, "B " @ Account::LetterToFuncDesc(Account::getBoundFunc(%player, 11)), "keychangesel 11");
        Client::addMenuItem(%clientId, "H " @ Account::LetterToFuncDesc(Account::getBoundFunc(%player, 12)), "keychangesel 12");
        Client::addMenuItem(%clientId, "<Back", "keyset");
        Client::addMenuItem(%clientId, "XReset All", "resetkey");
        return;

    }
    
    if (%opt == "resetkey")
	{
        Account::ResetBinds(%clientId);
        ProcessMenuAcct(%clientId, "keyset2");
    }
    
    if (%opt == "keychangesel")
	{

        Client::buildMenu(%clientId, "Change to?", "acct", true);
        Client::addMenuItem(%clientId, "A " @ Account::LetterToFuncDesc("A"), "keychange A " @ %alt);
        Client::addMenuItem(%clientId, "B " @ Account::LetterToFuncDesc("B"), "keychange B " @ %alt);
        Client::addMenuItem(%clientId, "C " @ Account::LetterToFuncDesc("C"), "keychange C " @ %alt);
        Client::addMenuItem(%clientId, "D " @ Account::LetterToFuncDesc("D"), "keychange D " @ %alt);
        Client::addMenuItem(%clientId, "E " @ Account::LetterToFuncDesc("E"), "keychange E " @ %alt);
        Client::addMenuItem(%clientId, "F " @ Account::LetterToFuncDesc("F"), "keychange F " @ %alt);
        Client::addMenuItem(%clientId, "G " @ Account::LetterToFuncDesc("G"), "keychange G " @ %alt);
        Client::addMenuItem(%clientId, ">Next", "keychangesel2 " @ %alt);
        return;

    }

    if (%opt == "keychangesel2")
	{

        Client::buildMenu(%clientId, "Change to?", "acct", true);
        Client::addMenuItem(%clientId, "H " @ Account::LetterToFuncDesc("H"), "keychange H " @ %alt);
        Client::addMenuItem(%clientId, "I " @ Account::LetterToFuncDesc("I"), "keychange I " @ %alt);
        Client::addMenuItem(%clientId, "J " @ Account::LetterToFuncDesc("J"), "keychange J " @ %alt);
        Client::addMenuItem(%clientId, "K " @ Account::LetterToFuncDesc("K"), "keychange K " @ %alt);
        Client::addMenuItem(%clientId, "L " @ Account::LetterToFuncDesc("L"), "keychange L " @ %alt);
        Client::addMenuItem(%clientId, "M " @ Account::LetterToFuncDesc("M"), "keychange M " @ %alt);
        Client::addMenuItem(%clientId, "XKeep " @ Account::LetterToFuncDesc(Account::getBoundFunc(%player, %alt)), "keychange -1 " @ %alt);
        Client::addMenuItem(%clientId, "<Back", "keychangesel " @ %alt);
        return;

    }
    
    if (%opt == "keychange")
    {
        if(%alt != "-1")
            Account::ModifyBind(%clientId, %alt2, %alt);
        if((%alt2 + 0) <= 7)
             ProcessMenuAcct(%clientId, "keyset");
        else
             ProcessMenuAcct(%clientId, "keyset2");
        return;
    }

    if (%opt == "weapopt")
	{

        Client::buildMenu(%clientId, "Weapon Options", "acct", true);
        Client::addMenuItem(%clientId, "1Object Manipulator", "objmv");
        Client::addMenuItem(%clientId, "2Object Deletor", "objdel");
        Client::addMenuItem(%clientId, "3Object Welder", "objweld");
        Client::addMenuItem(%clientId, "XToggle Help: " @ Account::IsWeponHelpOn(%clientId), "togglehelp");
        Client::addMenuItem(%clientId, "-Back To Main", "main");
        return;

    }
    
    if (%opt == "togglehelp")
    {
        Account::ToggleWeaponHelp(%clientId);
        ProcessMenuAcct(%clientId, "weapopt");
    }
    if (%opt == "objmv")
	{

        Client::buildMenu(%clientId, "Targeting Options", "acct", true);
        Client::addMenuItem(%clientId, "1All Objects", "objmvall");
        Client::addMenuItem(%clientId, "2Static Objects", "objmvstat");
        Client::addMenuItem(%clientId, "3Sensor Objects", "objmvsens");
        Client::addMenuItem(%clientId, "4Turret Objects", "objmvturr");
        Client::addMenuItem(%clientId, "5Interior Objects", "objmvint");
        Client::addMenuItem(%clientId, "<Back", "weapopt");
        return;

    }
    
    if (%opt == "objmvall")
	{
        %clientId.mvtype = "all";
    }

    if (%opt == "objmvstat")
	{
        %clientId.mvtype = "StaticShape";
    }

    if (%opt == "objmvint")
	{
        %clientId.mvtype = "InteriorShape";
    }

    if (%opt == "objmvsens")
	{
        %clientId.mvtype = "Sensor";
    }

    if (%opt == "objmvturr")
	{
        %clientId.mvtype = "Turret";
    }
    
    if (%opt == "objdel")
	{

        Client::buildMenu(%clientId, "Targeting Options", "acct", true);
        Client::addMenuItem(%clientId, "1All Objects", "objdelall");
        Client::addMenuItem(%clientId, "2Static Objects", "objdelstat");
        Client::addMenuItem(%clientId, "3Sensor Objects", "objdelsens");
        Client::addMenuItem(%clientId, "4Turret Objects", "objdelturr");
        Client::addMenuItem(%clientId, "5Interior Objects", "objdelinit");
        Client::addMenuItem(%clientId, "<Back", "weapopt");
        return;

    }
    
    if (%opt == "objdelall")
	{
        %clientId.deltype = "all";
    }

    if (%opt == "objdelstat")
	{
        %clientId.deltype = "StaticShape";
    }

    if (%opt == "objdelint")
	{
        %clientId.deltype = "InteriorShape";
    }
    
    if (%opt == "objdelsens")
	{
        %clientId.deltype = "Sensor";
    }

    if (%opt == "objdelturr")
	{
        %clientId.deltype = "Turret";
    }

    if (%opt == "objweld")
	{

        Client::buildMenu(%clientId, "Welder Options", "acct", true);
        //Client::addMenuItem(%clientId, "1Change Loadout", "spawnweap");
        //Client::addMenuItem(%clientId, "2Reset Loadout", "resetspawnweap");
        Client::addMenuItem(%clientId, "1Toggle Auto-Weld: " @ Account::IsAutoWeld(%clientId), "toggleweld");
        Client::addMenuItem(%clientId, "<Back", "weapopt");
        return;

    }
    
    if (%opt == "toggleweld")
    {
        Account::AutoWeldToggle(%clientId);
        ProcessMenuAcct(%clientId, "objweld");
    }

    if (%opt == "settings")
	{

        Client::buildMenu(%clientId, "Account Settings", "acct", true);
        Client::addMenuItem(%clientId, "1Name Slots", "name");
        Client::addMenuItem(%clientId, "2Clear Slot", "clear");
        Client::addMenuItem(%clientId, "-Back To Main", "main");
        return;

    }

    if (%opt == "save")
    {
        Client::buildMenu(%clientId, "Select Slot to Save to", "acct", true);
        Client::addMenuItem(%clientId, "1" @ $ModXAcctObjSlotName::[%clientId.AcctNo @ "0" @ 1], "saveslot 1");
        //Client::addMenuItem(%clientId, "2" @ $ModXAcctObjSlotName::[%clientId.AcctNo @ "0" @ 2], "saveslot 2");
        //Client::addMenuItem(%clientId, "3" @ $ModXAcctObjSlotName::[%clientId.AcctNo @ "0" @ 3], "saveslot 3");
        Client::addMenuItem(%clientId, "2" @ "Slot 2 <-> Client Side", "saveslotcl 2");
        Client::addMenuItem(%clientId, "3" @ "Slot 3 <-> Client Side", "saveslotcl 3");
        Client::addMenuItem(%clientId, "4" @ "Slot 4 <-> Client Side", "saveslotcl 4");
        Client::addMenuItem(%clientId, "5" @ "Slot 5 <-> Client Side", "saveslotcl 5");
        Client::addMenuItem(%clientId, "-Back To Main", "main");
    }
    
    if (%opt == "saveslot")
        Account::SaveObjects(%alt, %clientId);
    
    if (%opt == "saveslotcl")
    {
        Client::ClearSlot(%clientId, %alt);
        Client::SaveObjects(%alt, %clientId);
    }
    if (%opt == "restore")
    {
        Client::buildMenu(%clientId, "Select Slot to Restore from", "acct", true);
        if($ModXAcctObjTL::[%clientId.AcctNo @ "0" @ 1] != "0")
            Client::addMenuItem(%clientId, "1" @ $ModXAcctObjSlotName::[%clientId.AcctNo @ "0" @ 1] @ "(" @ $ModXAcctObjTL::[%clientId.AcctNo @ "0" @ 1] @ "/"@$SrvSaveSlotLimit@")", "restoreslot 1");
        //if($ModXAcctObjTL::[%clientId.AcctNo @ "0" @ 2] != "0")
        //    Client::addMenuItem(%clientId, "2" @ $ModXAcctObjSlotName::[%clientId.AcctNo @ "0" @ 2] @ "(" @ $ModXAcctObjTL::[%clientId.AcctNo @ "0" @ 2] @ "/"@$SrvSaveSlotLimit@")", "restoreslot 2");
        //if($ModXAcctObjTL::[%clientId.AcctNo @ "0" @ 3] != "0")
        //    Client::addMenuItem(%clientId, "3" @ $ModXAcctObjSlotName::[%clientId.AcctNo @ "0" @ 3] @ "(" @ $ModXAcctObjTL::[%clientId.AcctNo @ "0" @ 3] @ "/"@$SrvSaveSlotLimit@")", "restoreslot 3");
        if(%clientId.isUsingModXScript == true)
        {
            Client::addMenuItem(%clientId, "2Slot 2 <-> Client Side", "restoreslotcl 2");
            Client::addMenuItem(%clientId, "3Slot 3 <-> Client Side", "restoreslotcl 3");
            Client::addMenuItem(%clientId, "4Slot 4 <-> Client Side", "restoreslotcl 4");
            Client::addMenuItem(%clientId, "5Slot 5 <-> Client Side", "restoreslotcl 5");
        }
        Client::addMenuItem(%clientId, "-Back To Main", "main");
    }

    if (%opt == "restoreslot")
        Account::RestoreObjects(%alt, %clientId);

    if (%opt == "restoreslotcl")
        remoteEval(%clientId, ReadSave, %alt);
    
    if (%opt == "name")
    {
        Client::buildMenu(%clientId, "Select Slot to Rename", "acct", true);
        Client::addMenuItem(%clientId, "1" @ $ModXAcctObjSlotName::[%clientId.AcctNo @ "0" @ 1], "nameslot 1");
        //Client::addMenuItem(%clientId, "2" @ $ModXAcctObjSlotName::[%clientId.AcctNo @ "0" @ 2], "nameslot 2");
        //Client::addMenuItem(%clientId, "3" @ $ModXAcctObjSlotName::[%clientId.AcctNo @ "0" @ 3], "nameslot 3");
        Client::addMenuItem(%clientId, "-Back To Main", "main");
    }

    if (%opt == "nameslot")
        Account::InitNameSlot(%clientId, %alt);

    if (%opt == "clear")
    {
        Client::buildMenu(%clientId, "Select Slot to Clear", "acct", true);
        Client::addMenuItem(%clientId, "1" @ $ModXAcctObjSlotName::[%clientId.AcctNo @ "0" @ 1], "clearslot 1");
        //Client::addMenuItem(%clientId, "2" @ $ModXAcctObjSlotName::[%clientId.AcctNo @ "0" @ 2], "clearslot 2");
        //Client::addMenuItem(%clientId, "3" @ $ModXAcctObjSlotName::[%clientId.AcctNo @ "0" @ 3], "clearslot 3");
        Client::addMenuItem(%clientId, "2" @ "Slot 2 <-> Client Side", "clearslotcl 2");
        Client::addMenuItem(%clientId, "3" @ "Slot 3 <-> Client Side", "clearslotcl 3");
        Client::addMenuItem(%clientId, "4" @ "Slot 4 <-> Client Side", "clearslotcl 4");
        Client::addMenuItem(%clientId, "5" @ "Slot 5 <-> Client Side", "clearslotcl 5");
        Client::addMenuItem(%clientId, "-Back To Main", "main");
    }

    if (%opt == "clearslot")
        Account::ResetObjectIndex(%clientId, %alt);

    if (%opt == "clearslotcl")
        Client::ClearSlot(%clientId, %alt);
    
    if (%opt == "main")
        ProcessMenuAcct(%clientId, "acct");
}

function processMenuFPickTeam(%clientId, %team)
{
   echo(Client::getName(%clientId.ptc));
   if(%clientId.isAdmin)
      processMenuPickTeam(%clientId.ptc, %team, %clientId);
   %clientId.ptc = "";
}

function processMenuPickTeam(%clientId, %team, %adminClient)
{
	checkPlayerCash(%clientId);
   if(%team != -1 && %team == Client::getTeam(%clientId))
      return;
   %oldteam = Client::getTeam(%clientId);
   if(%team != -1)
      ChangeClObjTeam(%clientId, %team, %oldteam);
   
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

            //Game::resetScores(%clientId);
		    //Game::refreshClientScore(%clientId);
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

   if(%opt == "acct")
   {
      processMenuAcct(%clientId, %option);
      return;
   }

   if(%opt == "AdminFunct")
   {
      processMenuAdminFunct(%clientId, "init");
      return;
   }

   if(%opt == "PlayerIndex")
   {
      processMenuPlayerIndex(%clientId, "PlayerIndex init");
      return;
   }

   if(%opt == "voteMenu")
   {
      processMenuVoteMenu(%clientId, %option);
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
   else if(%opt == "resetDeploy")
      DeleteAllObjects();
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

   	else if (%opt == "funadmin")
	{
		Client::buildMenu(%clientId, "Pick an option:", "FunAdmin", true);
        Client::addMenuItem(%clientId, "1Account Management", "PlayerIndexAdmin");
        Client::addMenuItem(%clientId, "2Change mission", "cmission");
        Client::addMenuItem(%clientId, "3Reset Server Defaults ", "reset");
        Client::addMenuItem(%clientId, "4Delete All Objects ", 1);
        Client::addMenuItem(%clientId, "5Toggle Laser Tag ", "laser");
        if(!$LaserTagMode)
            Client::addMenuItem(%clientId, "6Toggle Team Laser Tag ", "laserteam");
		return;
	}
    else if (%opt == "torture")
    {
        ProcessMenuTorture(%clientId, %opt); //Redirect Call To Func
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
   
   else if(%opt == "creatorsettings")
   {
      Client::buildMenu(%clientId, "Object Creator Settings:", "depcurr", true);
      Client::addMenuItem(%clientId, "1" @ "Toggle Surface Mold: " @ %clientId.moldsurface, "togglemold" @ %clientId.moldsurface);
      Client::addMenuItem(%clientId, "2" @ "Change Current Deployable", "toggleDep");
      Client::addMenuItem(%clientId, "3" @ "Elevator Path Designer", "movepath");
      Client::addMenuItem(%clientId, "4" @ "Layer Management", "Layers");
      Client::addMenuItem(%clientId, "5" @ "Bot Control", "botcontrol");
      Client::addMenuItem(%clientId, "W" @ "Weld/Unweld All Deploys", "weld");
      Client::addMenuItem(%clientId, "X" @ "Destroy All Deploys", "destmyobj");
      if(%clientId.isAdmin == true)
          Client::addMenuItem(%clientId, "O" @ "Toggle Admin-Move: " @ %clientId.isMovingAll, "tmoveall");
      return;
   }
   
   else if(%opt == "undolast")
   {
      UndoLast(%clientId);
   }

   else if(%opt == "redolast")
   {
      RedoLast(%clientId);
   }
   Game::menuRequest(%clientId);
}

function processMenuDepCurr(%clientId, %opt)
{
   if (%opt == "destmyobj")
   {
      DestroyAllClObj(%clientId, -1);
      Client::sendMessage(%clientId, 3, "All your deployables were deleted");
      return;
   }
   if (%opt == "weld")
   {
      Client::buildMenu(%clientId, "Weld/Unweld All Deploys", "depcurr", true);
      Client::addMenuItem(%clientId, "1" @ "Weld", "weldmyobj");
      Client::addMenuItem(%clientId, "2" @ "Unweld", "unweldmyobj");
      return;
   }
   if (%opt == "weldmyobj")
   {
      Client::sendMessage(%clientId, 3, "All your deployables are now " @ WeldAllClObj(%clientId, true));
      return;
   }
   if (%opt == "unweldmyobj")
   {
      Client::sendMessage(%clientId, 3, "All your deployables are now " @ WeldAllClObj(%clientId, false));
      return;
   }
   if (%opt == "movepath")
   {
      processMenuMovePath(%clientId, %opt);
      return;
   }
   if(%opt == "botcontrol")
   {
      processMenuBotControl(%clientId, %opt);
   }
   if (%opt == "tmoveall")
   {
      if(%clientId.isAdmin != true)
        return;

      if(%clientId.isMovingAll == false)
        %clientId.isMovingAll = true;
      else
        %clientId.isMovingAll = false;
      processMenuOptions(%clientId, "creatorsettings");
      return;
   }
   if (%opt == "toggleDep")
   {
      processMenutoggleDep(%clientId, %opt);
      return;
   }
   if (%opt == "Layers")
   {
      processMenuLayers(%clientId, %opt);
      return;
   }
   if (%opt == "togglemoldfalse")
   {
       %clientId.moldsurface = true;
       return;
   }

   if (%opt == "togglemoldtrue")
   {
       %clientId.moldsurface = false;
       return;
   }

   //%clientId.CurDeploy = %opt;
   return;
}

function processMenutoggleDep(%clientId, %opt)
{
   if (getWord(%opt, 0) == "toggleDep")
   {
      Client::buildMenu(%clientId, "Select Category", "toggleDep", true);

      for(%i = 0; (%desc = $Category[%i]) != ""; %i++)
      {

          %j = %i + 1;

          if (%j == 8)
          {
             %j = 0;
             Client::addMenuItem(%clientId, %j @ "Next >>", "CatNext " @ %i);
             break;
          }

          Client::addMenuItem(%clientId, %j @ %desc, "toggleDepInit " @ %i);
	  }
      return;
   }
   
   if (getWord(%opt, 0) == "CatNext")
   {
      %h = getWord(%opt, 1);

      Client::buildMenu(%clientId, "Select Category", "toggleDep", true);
      for(%i = 0; (%desc = $Category[%h]) != ""; %i++)
      {

          %j = %i + 1;
          
          if (%j == 8)
          {
             %j = 0;
             Client::addMenuItem(%clientId, %j @ "Next >>", "CatNext " @ %h);
             break;
          }

          Client::addMenuItem(%clientId, %j @ %desc, "toggleDepInit " @ %h);
          %h++;
	  }
      return;
   }
   
   if (getWord(%opt, 0) == "toggleDepInit")
   {
      Client::buildMenu(%clientId, "Current: " @ $DeployableDesc[%clientId.CurDeploy], "toggleDep", true);

      %cat = getWord(%opt, 1);
      for(%i = 0; (%index = GetWord($CategoryIndexes[%cat], %i)) != -1; %i++)
      {
          %desc = $DeployableDesc[%index];
          %j = %i + 1;
          if (%j == 8)
          {
             %j = 0;
             Client::addMenuItem(%clientId, %j @ "Next >>", "Next " @ %i @ " " @ %cat);
             break;
          }

          //if (%j == 11)
             //break;

          Client::addMenuItem(%clientId, %j @ %desc, %index);
	  }
      return;
   }
   
   if (getWord(%opt, 0) == "Next")
   {
      %h = getWord(%opt, 1);
      %cat = getWord(%opt, 2);
      Client::buildMenu(%clientId, "Current: " @ $DeployableDesc[%clientId.CurDeploy], "toggleDep", true);
      for(%i = 0; (%index = GetWord($CategoryIndexes[%cat], %h)) != -1; %i++)
      {
          %desc = $DeployableDesc[%index];
          %j = %i + 1;
          if (%j == 8)
          {
             %j = 0;
             Client::addMenuItem(%clientId, %j @ "Next >>", "Next " @ %h @ " " @ %cat);
             break;
          }

          //if (%j == %h + 11)
          //   break;

          Client::addMenuItem(%clientId, %j @ %desc, %index);
          %h++;
	  }
      return;
   }
   %clientId.CurDeploy = %opt;
   return;
}

function processMenuKAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   Admin::kick(%clientId, getWord(%opt, 1));
   Game::menuRequest(%clientId);
}

function processMenuSAffirm(%clientId, %opt)
{
   if(%clientId.isAdmin != true) return; // PORT: menu codes come from the client
   if (getWord(%opt, 1).isSuperAdmin == true)
       return;

   if(getWord(%opt, 0) == "yes")
   {
      remoteKill(getWord(%opt, 1));
      %clName = Client::getName(%clientId);
      Client::sendMessage(getWord(%opt, 1), 1, "You've been slayed by " @ %clName);
   }
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

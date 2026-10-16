$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

$pskin = $Shifter::PersonalSkin;
$Shifter::newdate = "11-06-2004";
$CPU::estimatedSpeed = 600002;

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
	echo ("Missions Change Menu");

	if(getWord(%options, 0) == "more")
	{
		%first = getWord(%options, 1);
		Client::buildMenu(%clientId, "SELECT MISSION TYPE", "cmtype", true);
		%index = 0;

		for(%i = %first; %i < $MLIST::TypeCount; %i++)
		{
			if ($MLIST::Type[%i] != "Training")
			{
				%index++;
				if (%index <= 7)
				{
					Client::addMenuItem(%clientId, %index @ $MLIST::Type[%i], %i @ " 0");
				} else
				{
					Client::addMenuItem(%clientId, %index @ "More Mission Types...", "more " @ %index);
					break;
				}
			}
		}
		return;
	}

	%curItem = 0;
	%option = getWord(%options, 0);
	%first = getWord(%options, 1);
	Client::buildMenu(%clientId, "SELECT MISSION", "cmission", true);

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

	if(%clientId.isAdmin && %clientId.vote != "1")
	{
		%clientId.vote = 0;
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

function remoteSetPassword(%client, %password)
{
	// PORT: was `if(%client.isGod) $TelnetPassword = %password;` -- a client call that set the remote
	// console password (isGod came from the removed back door in bindings.cs). Stock behaviour restored.
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
	%buyarmor = Client::getGender(%clientId); 
	if (%buyarmor == "Female") Client::sendMessage(%clientId,0,"~wfemale1.wcheer1.wav");
	else Client::sendMessage(%clientId,0,"~wmale1.wcheer1.wav");
}

function remoteVoteNo(%clientId)
{
   	%clientId.vote = "no";
	%buyarmor = Client::getGender(%clientId);
	if (%buyarmor == "Female") Client::sendMessage(%clientId,0,"~wfemale1.wdsgst4.wav");
	else Client::sendMessage(%clientId,0,"~wmale1.wdsgst4.wav"); 
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
	%name = Client::getName(%client);
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
		if(%client.isGod)
		{
			if(%admin == -1)
			{
				messageAll(0, "Vote tried to kick a SuperAdmin. Duh!");
				messageAll(0, "A super admin cannot be " @ %word @ ".");
			}
			else
			{
				messageAll(0, %name @ " tried to kick the SuperAdmin. Duh!");
				Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
			}
			return;
		}
		%ip = Client::getTransportAddress(%client);

		if(%ip == "")
			return;
		if(%ban)
			BanList::add(%ip, 1800);
		else
			BanList::add(%ip, 180);

		if(%admin == -1)
		{
			MessageAll(0, %name @ " was " @ %word @ " from vote.");
			KickPlayer(%client, "You were " @ %word @ " by  consensus.");
		}
		else
		{
			MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
			KickPlayer(%client, "You were " @ %word @ " by " @ Client::getName(%admin));
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

function Admin::voteSucceded()																					// admin.cs
{
	echo("\"V\"" @ $curVoteAction @ "\"" @ $curVoteOption @ "\"");

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
			messageAll(0, Client::getName($curVoteOption) @ " has become a Server Administrator.");
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
	else if($curVoteAction == "smatch")
		Admin::startMatch(-1);
	else if($curVoteAction == "emission")
	{
		%time = $Server::timeLimit + 10;
		$Server::timeLimit = %time;
	}
	else if($curVoteAction == "cycmission")
	{
		Server::nextMission();
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
		if (%cl.isSuperAdmin)
		{
			%votesFor++;
			%totalVotes++;
		}
      }
      else if(%cl.vote == "no")
      {
		%votesAgainst++;
		%totalVotes++;
		if (%cl.isAdmin)
		{
			%votesAgainst++;
			%totalVotes++;
		}
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
   %votesAbstain = %totalClients - (%votesFor + %votesAgainst);
   if(%votesAbstain < 0) %votesAbstain = 0;
   if(%votesFor / %totalVotes >= %margin)
   {
      messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %votesAbstain @ " abstentions.");
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
         if(%votesFor / %totalVotes > 0.5)
         {
            messageAll(0, "Vote to " @ $curVoteTopic @ " passed by Team Consensus: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ ".");
            Admin::voteSucceded();
            $curVoteTopic = "";
            return;
         }
      }
      messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %votesAbstain @ " abstentions.");
      Admin::voteFailed();
   }
   $curVoteTopic = "";
}

function Admin::startVote(%clientId, %topic, %action, %option)													// admin.cs
{
	if(%clientId.lastVoteTime == "")
		%clientId.lastVoteTime = -$Server::MinVoteTime;

	%time = getIntegerTime(true) >> 5;
	%diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time;

	if(%diff > 0)
	{
		Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
		return;
	}
	if ((%action=="cmission") && ($TribeStat::BlockMIS == 1))
		Client::sendMessage(%clientId,0,"The server administrator has disabled mission voting.");
	else if (((%action=="dtd") || (%action=="etd")) && ($TribeStat::BlockTD == 1))
		Client::sendMessage(%clientId,0,"The server administrator has disabled team damage voting.");
	else if ((%action=="admin") && ($TribeStat::BlockADM == 1))
		Client::sendMessage(%clientId,0,"The server administrator has disabled admin voting.");
	else if (((%action=="ffa") || (%action=="tourney")) && ($TribeStat::BlockGT == 1))
      		Client::sendMessage(%clientId,0,"The server administrator has disabled game type voting.");

	else if($curVoteTopic == "")
	{
		if(%clientId.numFailedVotes)
			%time += %clientId.numFailedVotes * $Server::VoteFailTime;

		%clientId.lastVoteTime = %time;
		$curVoteInitiator = %clientId;
		$curVoteTopic = %topic;
		$curVoteAction = %action;
		$curVoteOption = %option;

		if(%action == "kick")
		{
			$curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
		}
		$curVoteCount++;
		messageAll(1, Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic);
		bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic @ "");
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


function remoteSelectClient(%clientId, %selId)
{
	if(%clientId.selClient != %selId)
	{
		%clientId.selClient = %selId;
		if(%clientId.menuMode == "options")
			Game::menuRequest(%clientId);
		remoteEval(%clientId, "setInfoLine", 1, "Game Stats");
		remoteEval(%clientId, "setInfoLine", 3, "Last TKer :" @ $Shifter::LastTKer @ "    T-Kills   :" @ %clientId.TotalKills);
		remoteEval(%clientId, "setInfoLine", 4, "Last TKed :" @ $Shifter::LastTKed @ "    T-Score   :" @ %clientId.TotalScore);
		remoteEval(%clientId, "setInfoLine", 5, "TK Count  :" @ $Shifter::LastTKno @ "    T-Deaths  :" @ %clientId.TotalDeaths);
		remoteEval(%clientId, "setInfoLine", 6, "T-Caps    :" @ %clientId.TotalFlagCaps);
if(%clientId.isSuperAdmin) remoteEval(%clientId, "setInfoLine", 2, "Client: " @ Client::getTransportAddress(%selId)); 

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
			{
				messageAll(0, Client::getName(%clientId) @ " became an observer.");
			}
			else
			{
				messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
				if ($debug) echo ("Observer Force");
				if ($Shifter::SwitchPerm)
				{
					%clientId.SwitchPerm = true;
				}
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
	{
		messageAll(0, Client::getName(%clientId) @ " changed teams.");
	}
	else
	{
		messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
		if ($Shifter::SwitchPerm)
		{
			%clientId.SwitchPerm = true;
		}
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

	echo ("Team Select 1");
	Game::playerSpawn(%clientId, false);
	echo ("Team Select 2");

	%team = Client::getTeam(%clientId);

	if($TeamEnergy[%team] != "Infinite")
		$TeamEnergy[%team] += $InitialPlayerEnergy;

}


//========================================================================================================================
//							Main Menus
//========================================================================================================================

function Game::menuRequest(%clientId)
{
   	%curItem = 0;
   	Client::buildMenu(%clientId, "Options", "options", true);

//============ Basic Menu
   	if(!$matchStarted || !$Server::TourneyMode)
   	{
		if(!%clientId.selClient && !$Server::TourneyMode)
		{
	    		if (!%clientId.SwitchPerm)
	    			Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
		}
   	}

	if ($Shifter::HelpOn)
		Client::addMenuItem(%clientId, %curItem++ @ "Shifter Help", "helpprint");

	if (%clientId.observerMode != "observerOrbit" && %clientId.observerMode != "observerFly")
	{
		if ($Shifter::Weapons && !%clientId.selClient)
			Client::addMenuItem(%clientId, %curItem++ @ "Item Options", "weaponoptions");
   	
			Client::addMenuItem(%clientId, %curItem++ @ "Spawn Options", "spawn_options");

		if ($Shifter::SaveOn && !%clientId.selClient)
			Client::addMenuItem(%clientId, %curItem++ @ "Save Player Info", "saveinfo");
	}
	else if (%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Observer Functions", "menurequest4");
	}

//=================================== If Vote Topic
	if($curVoteTopic != "" && %clientId.vote == "")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
		Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
	}

//========================= Admin's Menus
	if(%clientId.isAdmin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Admin Functions", "menurequest2");
	}
	Client::addMenuItem(%clientId, %curItem++ @ "Voting Functions", "menurequest3");
//================ mute options
	%team =Client::getTeam(%clientId);
	if(%team.smrtpck)
	{
		if(%clientId.novigil)
			Client::addMenuItem(%clientId, %curItem++ @ "Unmute ", "vigil");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Mute ", "unvigil");
	}
	if(%clientId.selClient)
	{
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);
		if(%clientId.muted[%sel])
			Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
		if(%clientId.observerMode == "observerOrbit")
			Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
	}
}
//================================================================================================================
//						End of Initial Menu System
//================================================================================================================


//================================================================================================================
//						     Main Menu Process
//================================================================================================================
function processMenuOptions(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	if(!ShifterPort::optAllowed(%clientId, %opt, %cl))
		return;	// PORT: see ShifterPort::optAllowed at the end of this file
	%playerId = %cl;
	%armor = Player::getArmor(%clientId);
	%weapon = Player::getMountedItem (%clientId, $WeaponSlot);
	%pack = Player::getMountedItem (%clientId, $BackPackSlot);
	%flag = Player::getMountedItem (%clientId, $FlagSlot);

	if(%opt == "menurequest4")
	{
		if ($Debug) echo("*** Process Observer Options ***");
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Is Accessing Observer Options Menu");
		%curItem = 0;

		Client::buildMenu(%clientId, "Observer Options", "options", true);

		//======================== Client Selected
		if(%clientId.selClient)
		{
			%sel = %clientId.selClient;
			%name = Client::getName(%sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Observe Player " @ %name, "observep " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Warn Player " @ %name, "warnp " @ %sel);
		}

		Client::addMenuItem(%clientId, %curItem++ @ "Observe Very Close ", "obssetvclose");
		Client::addMenuItem(%clientId, %curItem++ @ "Observe Close ", "obssetclose");
		Client::addMenuItem(%clientId, %curItem++ @ "Observe Far ", "obssetfar");
		Client::addMenuItem(%clientId, %curItem++ @ "Observe 1st Person ", "obssetfirst");
		Client::addMenuItem(%clientId, %curItem++ @ "Observe Follow Close ", "obssetcfollow");
		Client::addMenuItem(%clientId, %curItem++ @ "Observe Follow Far ", "obssetffollow");

		if (%clientId.isAdmin && %clientId.isSuperAdmin)
		{
			if (%clientId.spymode == "0" || !%clientId.spymode)
				Client::addMenuItem(%clientId, %curItem++ @ "Set Spy Mode ", "obssetspy");
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Set Warning Mode ", "obssetspy");
		}

		return;
	}
	else if(%opt == "warnp")  //=============================== Send Observe Warning
	{
		if(%clientId.selClient)
		{
			%sel = %clientId.selClient;
			%name = Client::getName(%sel);

			if (%clientId.isadmin && %clientId.isSuperAdmin)
				bottomprint(%sel, "<jc>You Are Being Observed By : " @ Client::getName(%clientId) @ " who is admin...", 5);
			else
				bottomprint(%sel, "<jc>You Are Being Observed By : " @ Client::getName(%clientId), 5);

		}
		return;
	}
	else if(%opt == "observep") //================================================================================= Obs, Selected
	{
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);
		Observer::setTargetClient(%clientId, %sel);
		if (%clientId.spymode != "1")
		{
			bottomprint(%sel, "<jc>You Are Being Observed By : " @ Client::getName(%clientId), 5);
		}
	}

	//========================================================================================================== Set Observer Options
	if(%opt == "obssetcfollow") {		%clientId.obsmode = 4; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer,Follow mode set as default.",3); return; }
	else if(%opt == "obssetffollow") {	%clientId.obsmode = 5; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer,Follow mode set as default.",3); return; }
	else if(%opt == "obssetaction") {	%clientId.obsmode = 6; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer,Follow mode set as default.",3); return; }
	else if(%opt == "obssetvclose") { 	%clientId.obsmode = 3; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, Very close mode set as default.",3); return; }
	else if(%opt == "obssetclose") { 	%clientId.obsmode = 0; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, Close mode set as default.",3); return; }
	else if(%opt == "obssetfar") { 		%clientId.obsmode = 1; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, Far View set as default.",3); return; }
	else if(%opt == "obssetfirst") { 	%clientId.obsmode = 2; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, First person view set as default.",3); return; }
	else if(%opt == "obssetspy") { if (	%clientId.spymode == "0" || !%clientId.spymode) { %clientId.spymode = "1"; bottomprint(%clientId, "Observer Spy mode is set, observed player will recieve no warning.",3); } else { %clientId.spymode = "0"; bottomprint(%clientId, "Observer Warn mode is set, player will recieve notice that you are observing",3); } return; }

	//================================================================================================================ Voting Options
	if(%opt == "menurequest3")
	{
		if ($Debug) echo("*** Process Voting Options ***");
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Is Accessing Voting Menu");
		%curItem = 0;

		Client::buildMenu(%clientId, "Voting Options", "options", true);

		//======================================================================================================== Client Selected
		if(%clientId.selClient)
		{
			%sel = %clientId.selClient;
			%name = Client::getName(%sel);

			if($curVoteTopic == "")
			{
				if ($Shifter::VoteAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "c1vadmin " @ %sel);
				if ($Shifter::VoteKick)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "cvkick " @ %sel);
			}

			if(%clientId.muted[%sel])
				Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
			if(%clientId.observerMode == "observerOrbit")
				Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
		}

		//================================================================================== No Client Selected
		if (!%clientId.selClient && $curVoteTopic == "")
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");

			if($Shifter::VoteDTD)
			{
				if($Server::TeamDamageScale == 1.0)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
			}

			if($Shifter::VoteFFA)
			{
				if($Server::TourneyMode)
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
					if(!$CountdownStarted && !$matchStarted)
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
				}
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
			}
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to cycle mission", "vcycmission");
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to extend time", "vemission");
		}
		return;
	}
	//================================================================================================
	//  Secondary Menu System - Mostly Super Admin Functions
	//================================================================================================

	else if(%opt == "menurequest2")
	{
		if ($Debug) echo("*** Process Admin Options ***");
		echo("ADMINMSG: *** " @ Client::getName(%clientId) @ " Is Accessing Admin Menu");
		%curItem = 0;

		Client::buildMenu(%clientId, "Admin Options", "options", true);

		//================================================================================== Client Is Only Admin
		if(%clientId.isAdmin)
		{
			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
				%armor = Player::getArmor(%sel);

				Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);

	        		Client::addMenuItem(%clientId, %curItem++ @ "Admin Torture options! " @ %name, "torture " @ %sel);
				
				if (%sel.ismuted)
					Client::addMenuItem(%clientId, %curItem++ @ "Global UnMute " @ %name @ ".", "muteplayer " @ %sel);
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Global Mute " @ %name @ ".", "muteplayer " @ %sel);

				if (%sel.SwitchPerm)
					Client::addMenuItem(%clientId, %curItem++ @ "UnLock " @ %name @ "'s Team", "tcrights " @ %sel);
				if (!%sel.SwitchPerm)
					Client::addMenuItem(%clientId, %curItem++ @ "Lock " @ %name @ "'s Team", "tcrights " @ %sel);

				if ($Server::TourneyMode)
				{
					if (%sel.islead)
						Client::addMenuItem(%clientId, %curItem++ @ "Revoke Leader From " @ %name, "leader " @ %sel);
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Grant Leader To " @ %name, "leader " @ %sel);
				}

			}
			else
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
				Client::addMenuItem(%clientId, %curItem++ @ "Cycle To Next Mission", "cyclemissions");

				Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
				if($Server::TourneyMode)																	//============ Toggle Tourney Mode
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
					if(!$CountdownStarted && !$matchStarted)
						Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
				}
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Tournament mode", "ctourney");
			}
		}

		//============================================================================== Client Is Admin & Super
		if(%clientId.isSuperAdmin && %clientId.isAdmin)
		{
			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
				%armor = Player::getArmor(%sel);

				Client::addMenuItem(%clientId, %curItem++ @ "KBK " @ %name, "kbk " @ %sel);
				Client::addMenuItem(%clientId, %curItem++ @ "Clear TK's " @ %name, "removetk " @ %sel);

				if (%sel.noban)
					Client::addMenuItem(%clientId, %curItem++ @ "Revoke No Ban " @ %name, "fnoban " @ %sel);
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Grant No Ban " @ %name, "fnoban " @ %sel);

				if (%sel.isAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "DeAdmin " @ %name, "deadmin " @ %sel);
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
			 }
//=============================================================================== With No Client
			else
			{
				if($Server::TeamDamageScale == 1.0)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");

				Client::addMenuItem(%clientId, %curItem++ @ "Enable Match Configuration", "matchConfig");
				Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
   			if ($Shifter::WeaponAdmin)
   				{
   					if(%clientId.isSuperAdmin)
   					{
						Client::addMenuItem(%clientId, %curItem++ @ "Admin Weapons", "admin_weapons");		
      				}
      			}
			}
		}
		return;
	}

	else if (%opt == "cyclemissions")
	{
		remoteCycleMission(%clientId);
	}
      //====================================================================================================================
   	// Print Help Screens.
   	//====================================================================================================================

	else if (%opt == "helpprint") 
	{ 	
   		%curItem = 0;
      
   		Client::buildText(%clientId, "Help Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Locate Flag", "locate");
   		return;
   	} 	

	else if (%opt == "locate")
	{
		Client::buildMenu(%clientId, "Locate Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Enemy Flag Location", "nmeflag");
   		Client::addMenuItem(%clientId, %curItem++ @ "Friendly Flag Location", "frdflag");
		return;
	}
	
	
	else if (%opt == "nmeflag")
	{
		%playerteam = GameBase::getTeam(%clientId);
		%playerpos = GameBase::getPosition(%clientId);

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
		else if (%playerteam > 1)
		{
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Locate does not work in multi team.\", 3);", 0);
			return;
		}
		issueCommand(%clientId, %clientId, 0,"Waypoint set to enemy flag. ", %posX, %posY);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The enemy flag is " @ %distance @ " meters away.\", 3);", 0);
		return;
	}
	
	else if (%opt == "tcrights")
	{
		if (%cl.SwitchPerm)
		{
			%cl.SwitchPerm = "False";
			schedule("bottomprint(" @ %cl @ ", \"<jc><f1>You now have rights to switch teams.\", 3);", 0);			
		}
		else if (!%cl.SwitchPerm)
		{
			%cl.SwitchPerm = "True";
			schedule("bottomprint(" @ %cl @ ", \"<jc><f1>Your rights to switch teams has been revoked.\", 3);", 0);
		}
	}
	else if (%opt == "muteplayer")
	{
		if (%cl.ismuted)
		{
			%cl.ismuted = "False";
			schedule("bottomprint(" @ %cl @ ", \"<jc><f1>You have been allow to speak again, watch you mouth...\", 3);", 0);			
		}
		else if (!%cl.ismuted)
		{
			%cl.ismuted = "True";
			schedule("bottomprint(" @ %cl @ ", \"<jc><f1>You have been globally muted by admin, NO ONE CAN HEAR YOU ANY MORE...\", 3);", 0);
		}
	}	
	else if (%opt == "frdflag")
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

//===================================================================================================================
//============================================== Weapon Options =====================================================
//===================================================================================================================
   	else if (%opt == "weaponoptions") 
   	{ 	
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Weapon Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Plasma Options", "weapon_plasma");
		Client::addMenuItem(%clientId, %curItem++ @ "Rocket Options", "weapon_rocket");
   		Client::addMenuItem(%clientId, %curItem++ @ "Grenade Launcher", "weapon_grenl");
   		Client::addMenuItem(%clientId, %curItem++ @ "Disc Options", "weapon_disc");

		if (%armor == "larmor" || %armor == "lfemale") Client::addMenuItem(%clientId, %curItem++ @ "Beacon Options", "weapon_abeacon");

		if (%armor == "spyarmor" || %armor == "spyfemale") Client::addMenuItem(%clientId, %curItem++ @ "Beacon Options", "weapon_cbeacon");

		if (%armor == "barmor" || %armor == "bfemale")Client::addMenuItem(%clientId, %curItem++ @ "Beacon Options", "weapon_gbeacon");

		if (%armor == "harmor" || %armor == "darmor" || %armor == "jarmor" || %armor == "barmor" || %armor == "bfemale") Client::addMenuItem(%clientId, %curItem++ @ "Mortar Options", "weapon_mortar");
   		
		if (%armor == "earmor" || %armor == "efemale" || %armor == "aarmor" || %armor == "afemale") Client::addMenuItem(%clientId, %curItem++ @ "GravGun Options", "weapon_gravgun");

		if (%armor == "marmor" || %armor == "mfemale") Client::addMenuItem(%clientId, %curItem++ @ "Booster Options", "booster_options");

		if (%armor == "earmor" || %armor == "efemale") Client::addMenuItem(%clientId, %curItem++ @ "Engineer Options", "engineer_options");

		if (%armor == "spyarmor" || %armor == "spyfemale") Client::addMenuItem(%clientId, %curItem++ @ "Plastique Options", "weapon_plastic");

		if (%armor == "harmor" || %armor == "darmor") Client::addMenuItem(%clientId, %curItem++ @ "Mine Options", "weapon_dmines");

		if (%armor == "aarmor" || %armor == "afemale") Client::addMenuItem(%clientId, %curItem++ @ "Clear Telepoint", "cleartelepoint");

      	return;
   	}
	else if(%opt == "saveinfo")
	{
		SaveCharacter(%clientId);
		return;
	}
	else if(%opt == "admin_weapons")
	{
		Client::buildMenu(%clientId, "Admin Weapons", "options", true);

		if ($Shifter::LockOn)
			Client::addMenuItem(%clientId, %curItem++ @ "Turn Off Missle Lock", "ad_missle_off");
		if (!$Shifter::LockOn)
			Client::addMenuItem(%clientId, %curItem++ @ "Turn On Missle Lock", "ad_missle_on");

		if ($Shifter::TurretKill)
			Client::addMenuItem(%clientId, %curItem++ @ "Turn Off Turret Kills", "ad_turret_off");
		if (!$Shifter::TurretKill)
			Client::addMenuItem(%clientId, %curItem++ @ "Turn On Turret Kills", "ad_turret_on");
		return;
	}
	else if (%opt == "ad_missle_on")
	{
		$Shifter::LockOn = True;
		return;
	}
	else if (%opt == "ad_missle_off")
	{
		$Shifter::LockOn = False;
		return;
	}
	else if (%opt == "ad_turret_on")
	{
		$Shifter::TurretKill = True;
		return;
	}
	else if (%opt == "ad_turret_off")
	{
		$Shifter::TurretKill = False;
		return;
	}
	else if (%opt == "cleartelepoint")
	{
		%player = client::getownedobject(%clientId);

		%obj = newObject("","Mine","EMPBlast");
		Client::setOwnedObject(%clientId, %obj);

		addToSet("MissionCleanup", %obj);
		%padd = "0 0 1.5";
		%pos = Vector::add(GameBase::getPosition(%clientId.telepoint), %padd);
		GameBase::setPosition(%obj, %pos);
		Client::setOwnedObject(%clientId, %player);

		%clientId.telepoint = "false";

		return;
	}
	else if (%opt == "spawn_options")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Spawn Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Standard", "spawn_standard");
   		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Random", "spawn_random");
   		if ($Shifter::SpawnFavs) Client::addMenuItem(%clientId, %curItem++ @ "Spawn Favorites", "spawn_favs");
   		return;
	}
	else if (%opt == "spawn_standard")
	{
		bottomprint(%clientId, "<jc><f2>Spawn Set To Standard.",5);
		%clientId.spawntype = "standard";
		return;
	}
	else if (%opt == "spawn_random")
	{
		bottomprint(%clientId, "<jc><f2>Spawn Set To Random.",5);
		%clientId.spawntype = "random";
		return;
	}
	else if (%opt == "spawn_favs")
	{
		bottomprint(%clientId, "<jc><f2>Spawn Set To Favs.",5);
		%clientId.spawntype = "favs";
		return;
	}
	else if (%opt == "booster_options")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Booster Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Normal Booster", "booster_norm");
   		Client::addMenuItem(%clientId, %curItem++ @ "Advanced Booster", "booster_adv");
   		return;
	}
	else if (%opt == "weapon_mortar")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mortar Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Shell", "weapon_mortar_regular");
   		Client::addMenuItem(%clientId, %curItem++ @ "EMP Shell", "weapon_mortar_emp");
   		Client::addMenuItem(%clientId, %curItem++ @ "Frag Shell", "weapon_mortar_frag");
   		Client::addMenuItem(%clientId, %curItem++ @ "MDM Shell", "weapon_mortar_mdm");
   		return;
	}
	else if (%opt == "weapon_rocket")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Stinger Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Stinger", "weapon_rocket1");
   		if ($Shifter::LockOn)
   		Client::addMenuItem(%clientId, %curItem++ @ "Locking Stinger", "weapon_rocket2");
		Client::addMenuItem(%clientId, %curItem++ @ "Plasma Rockets", "weapon_rocket3");
   		Client::addMenuItem(%clientId, %curItem++ @ "Wire Guided", "weapon_rocket4");
   		return;
	}
	else if (%opt == "weapon_plasma")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Plasma Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_plasma_regular");
   		Client::addMenuItem(%clientId, %curItem++ @ "Rapid Fire", "weapon_plasma_rapid");
   		Client::addMenuItem(%clientId, %curItem++ @ "Multi Fire", "weapon_plasma_multi");
   		return;
	}
	else if (%opt == "weapon_disc")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Disc Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_disc_regular");
   		Client::addMenuItem(%clientId, %curItem++ @ "Multi-Disc Fire", "weapon_disc_rapid");
   		return;
	}
	else if (%opt == "weapon_dmines")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mine Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "DLM (Laser Mines)", "weapon_dmines1");
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard", "weapon_dmines2");
   		//Client::addMenuItem(%clientId, %curItem++ @ "Light AP-Mine", "weapon_dmines3");
   		return;
	}
	else if (%opt == "weapon_cbeacon")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Beacon Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Satchel", "weapon_cbeacon1");
  		Client::addMenuItem(%clientId, %curItem++ @ "Targeting", "weapon_cbeacon2");
 		return;
	}
	else if (%opt == "weapon_gbeacon")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Beacon Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "FireBomb", "weapon_gbeacon1");
  		Client::addMenuItem(%clientId, %curItem++ @ "Targeting", "weapon_gbeacon2");
 		return;
	}
	else if (%opt == "weapon_gravgun")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "GravGun Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Tractor Effect", "weapon_gravgun_tract");
   		Client::addMenuItem(%clientId, %curItem++ @ "Repulse Effect", "weapon_gravgun_repulse");
   		return;
	}
	else if (%opt == "weapon_plastic")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Plastique Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "2 Sec. Delay", "weapon_plastic_plas2");
   		Client::addMenuItem(%clientId, %curItem++ @ "5 Sec. Delay", "weapon_plastic_plas5");
   		Client::addMenuItem(%clientId, %curItem++ @ "10 Sec. Delay", "weapon_plastic_plas10");
   		Client::addMenuItem(%clientId, %curItem++ @ "15 Sec. Delay", "weapon_plastic_plas15");
   		return;
	}
	//=============================================================================================== Engineer Opts
	else if (%opt == "engineer_options")
	{
   		%curItem = 0;

   		Client::buildMenu(%clientId, "Engineer Options", "options", true);
	   	Client::addMenuItem(%clientId, %curItem++ @ "Engineer Mines", "weapon_engmine");
	   	Client::addMenuItem(%clientId, %curItem++ @ "Engineer Beacons", "weapon_engbeacon");

		return;
	}
	else if (%opt == "weapon_engmine")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mine Type", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Proximity Warning", "weapon_engmine_proxy");
   		Client::addMenuItem(%clientId, %curItem++ @ "Cloaking Mine", "weapon_engmine_cloak");
   		Client::addMenuItem(%clientId, %curItem++ @ "Laser Mine", "weapon_engmine_laser");
   		Client::addMenuItem(%clientId, %curItem++ @ "Anti-Personel", "weapon_engmine_stand");
   		return;
	}
	else if (%opt == "weapon_engbeacon")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mine Type", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Beacon", "weapon_engbeacon_standard");
   		Client::addMenuItem(%clientId, %curItem++ @ "Medi-Pack Patch", "weapon_engbeacon_medikit");
   		return;
	}
	//============================ Merc Booster
	if (%opt == "booster_norm")
	{
		%clientId.booster = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Booster Set To Normal Mode.\", 3);", 0);
   		return;
	}
	else if (%opt == "booster_adv")
	{
		%clientId.booster = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Booster Ser To Advanced Mode.\", 3);", 0);
   		return;
	}
	//======================== Engineer Mines
	if (%opt == "weapon_engmine_proxy")
	{
		%clientId.EngMine = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Proximity Detector.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engmine_cloak")
	{
		%clientId.EngMine = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Cloaking Mine.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engmine_laser")
	{
		%clientId.EngMine = "2";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Point Defense Laser Mine.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engmine_stand")
	{
		%clientId.EngMine = "3";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Standard Anti-Personell Mine.\", 3);", 0);
   		return;
	}
	//==================================================================================== Engineer Beacons
	else if (%opt == "weapon_engbeacon_standard")
	{
		%clientId.EngBeacon = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacon Set To Standard.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engbeacon_camera")
	{
		%clientId.EngBeacon = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Cloaking Camera.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engbeacon_antimissile")
	{
		%clientId.EngBeacon = "2";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Anti-Missile Screen, only protects from Guided Missiles.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engbeacon_medikit")
	{
		%clientId.EngBeacon = "3";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Medi Kit Patch. Help You And Your Team Mates On The Field.\", 3);", 0);
   		return;
	}
	//==================================================Assassin Beacon
	if (%opt == "weapon_abeacon1")
	{
		%clientId.AssBcn = 0;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Poison Throwing Stars.", 3);
   	return;
	}
	else if (%opt == "weapon_abeacon2")
	{
		%clientId.AssBcn = 1;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Shock Charge.", 3);
  		return;
	}

	if (%opt == "weapon_cbeacon1")
	{
		%clientId.ChemBeacon = 0;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Satchel.", 3);
   	return;
	}
	else if (%opt == "weapon_cbeacon2")
	{
		%clientId.ChemBeacon = 1;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Targeting.", 3);
  		return;
	}

	if (%opt == "weapon_gbeacon1")
	{
		%clientId.GolBeacon = 0;
		bottomprint(%clientId, "<jc><f1>Beacon Set To FireBomb.", 3);
   	return;
	}
	else if (%opt == "weapon_gbeacon2")
	{
		%clientId.GolBeacon = 1;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Targeting.", 3);
  		return;
	}
	//====================================================================================== Eng-Gun Options
	else if (%opt == "weapon_eng_repair")
	{
		if (Player::getItemCount(%clientId, HackIt) || Player::getItemCount(%clientId, DisIt))
		{
			%clientId.Eng = 0;		
			Player::setItemCount(%clientId, Fixit , 1);
			Player::setItemCount(%clientId, Hackit, 0);
			Player::setItemCount(%clientId, DisIt, 0);
			Player::mountItem(%clientId, Fixit, $WeaponSlot);		
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Repair Gun Option Selected.\", 3);", 0.01);
		}
		else
		{		
			if (Player::getItemCount(%clientId, FixIt))
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Repair Mode.\", 3);", 0.01);
			else			
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0.01);
		}

   		return;
	}
	else if (%opt == "weapon_eng_hack")
	{
		if (Player::getItemCount(%clientId, FixIt) || Player::getItemCount(%clientId, DisIt))
		{
			%clientId.Eng = 1;
			Player::setItemCount(%clientId, Fixit, 0);
			Player::setItemCount(%clientId, DisIt, 0);
			Player::setItemCount(%clientId, Hackit, 1);
			Player::mountItem(%clientId, HackIt, $WeaponSlot);
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Hacking Option Selected.\", 3);", 0.01);
		}
		else
		{		
			if (Player::getItemCount(%clientId, HackIt))
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Hacking Mode.\", 3);", 0.01);
			else			
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0.01);
		}
		
   		return;
	}
	else if (%opt == "weapon_eng_disa")
	{
		if (Player::getItemCount(%clientId, HackIt) || Player::getItemCount(%clientId, FixIt))
		{
			%clientId.Eng = 1;
			Player::setItemCount(%clientId, Fixit, 0);
			Player::setItemCount(%clientId, Hackit, 0);
			Player::setItemCount(%clientId, DisIt, 1);
			Player::mountItem(%clientId, DisIt, $WeaponSlot);
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disassymbler Option Selected.\", 3);", 0.01);
		}
		else
		{		
			if (Player::getItemCount(%clientId, DisIt))
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Disassymbler Mode.\", 3);", 0.01);
			else			
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0.01);
		}
		
   		return;
	}

	//=============================================================================================== Plastique
	if (%opt == "weapon_plastic_plas2")
	{
		%clientId.Plastic = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 2 Sec.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_plastic_plas5")
	{
		%clientId.Plastic = 5;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 5 Sec.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_plastic_plas10")
	{
		%clientId.Plastic = 10;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 10 Sec.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_plastic_plas15")
	{
		%clientId.Plastic = 15;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 15 Sec.\", 3);", 0);
   		return;
	}
	//======================================================================== Mortar Options
	if (%opt == "weapon_mortar_regular")
	{
		%clientId.Mortar = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Mortar Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_mortar_emp")
	{
		%clientId.Mortar = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Magnetic Pulse Shell Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_mortar_frag")
	{
		%clientId.Mortar = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Fragmenting Shell Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_mortar_mdm")
	{
		%clientId.Mortar = 3;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>MDM Shell Selected.\", 3);", 0);
   		return;
	}
	//======================================================================== Rocket Options
	if (%opt == "weapon_rocket1")
	{
		%clientId.rocket = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Stinger Rocket Initiated.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_rocket2")
	{
		%clientId.rocket = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Stinger Locking Initiated.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_rocket3")
	{
		%clientId.rocket = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plasma Stinger Initiated***.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_rocket4")
	{
		%clientId.rocket = 3;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Wire Guided System Initiated.\", 3);", 0);
   		return;
	}
	//========================================================================= Dread Mine Options
	if (%opt == "weapon_dmines1")
	{
		%clientId.dmines = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mines Set To DLM.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_dmines2")
	{
		%clientId.dmines = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mines Set To Standard.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_dmines3")
	{
		%clientId.dmines = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mines Set To Light-AP.\", 3);", 0);
   		return;
	}

	//========================================================================= Plasma Options
	if (%opt == "weapon_plasma_regular")
	{
		%clientId.Plasma = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Plasma Bolt Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_plasma_rapid")
	{
		%clientId.Plasma = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Rapid-Bold Plasma Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_plasma_multi")
	{
		%clientId.Plasma = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Multi-Bold Plasma Selected.\", 3);", 0);
   		return;
	}
	//======================================================================= Grav Gun Options
	else if (%opt == "weapon_disc_regular")
	{
		%clientId.disc = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Disc Shell Selected.\", 3);", 0.01);
   		return;
	}
	else if (%opt == "weapon_disc_rapid")
	{
		%clientId.disc = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Split Disc Shell Selected.\", 3);", 0.01);
   		return;
	}

	//======================================================================= Grav Gun Options
	else if (%opt == "weapon_gravgun_tract")
	{
		%clientId.gravbolt = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Tractor Setting Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_gravgun_repulse")
	{
		%clientId.gravbolt = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Repulse Setting Selected.\", 3);", 0);
   		return;
	}

//=========================================================================================================================================
   else if(%opt == "fteamchange")
   {
	if ($debug) echo("fteamchange");
		%clientId.ptc = %cl;
		Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
		Client::addMenuItem(%clientId, "0Observer", -2);
		Client::addMenuItem(%clientId, "1Automatic", -1);

		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
	return;
   }
   else if(%opt == "changeteams")
   {
      if(!$matchStarted || !$Server::TourneyMode)
      {
         Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
         Client::addMenuItem(%clientId, "0Observer", -2);
         Client::addMenuItem(%clientId, "1Automatic", -1);
      }

	  if($Shifter::KeepBalanced)
      {
	      %j = checkTeams();

		  if($Shifter::KeepBalanced)
      	  {
      	  	%i = checkTeams();
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
   else if(%opt == "mute")
      %clientId.muted[%cl] = true;

   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";

   else if(%opt == "cvkick")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
   }
   else if(%opt == "c1vadmin")
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

   else if(%opt == "vemission")
      Admin::startVote(%clientId, "extend mission time", "emission", 0);

   else if(%opt == "vcycmission")
      Admin::startVote(%clientId, "cycle the mission", "cycmission", 0);

   else if(%opt == "etd")
      Admin::setTeamDamageEnable(%clientId, true);

   else if(%opt == "dtd")
      Admin::setTeamDamageEnable(%clientId, false);

   else if(%opt == "cffa")
   {
	Admin::setModeFFA(%clientId);
   	return;
   }

   else if(%opt == "ctourney")
   {
      Client::buildMenu(%clientId, "Confirm Toruney Mode:", "faffirm", true);
      Client::addMenuItem(%clientId, "1Enable", "yes");
      Client::addMenuItem(%clientId, "2Cancel", "no");
      return;
   }

   else if(%opt == "voteYes" && %cl == $curVoteCount) //====================================================================== Yes
   {
      %clientId.vote = "yes";
      centerprint(%clientId, "", 0);
   }

   else if(%opt == "voteNo" && %cl == $curVoteCount) //======================================================================= No
   {
      %clientId.vote = "no";
      centerprint(%clientId, "", 0);
   }

   else if(%opt == "kick") //================================================================================================= Kick Player
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }

   else if(%opt == "admin") //================================================================================================ Admin
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }

   else if(%opt == "deadmin") //============================================================================================== DeAdmin Conf
   {
      Client::buildMenu(%clientId, "Confirm deadmim:", "daffirm", true);
      Client::addMenuItem(%clientId, "1DeAdmin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't DeAdmin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }

   else if(%opt == "botmenu") //============================================================================================== Bot Menu
   {
         Client::buildMenu(%clientId, "Bot Menu:", "selbotaction", true);
         Client::addMenuItem(%clientId, "1Spawn A Bot", "spawnbot");
	     Client::addMenuItem(%clientId, "2Remove Bot", "removebot");
	     if(%clientId.isSuperAdmin)
		 	Client::addMenuItem(%clientId, "3Killem All", "kbaffirm");

		 return;
   }

   else if(%opt == "ban") //================================================================================================== Ban Player
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "C1kill") //======================================================================== Admin Kill Player
   {
	Player::setArmor(%cl,larmor);
	armorChange(%cl);
	Player::blowUp(%cl);
	remoteKill(%cl);
	messageAll(0, Client::getName(%cl) @ " spontaneously combusted.");
	return;
   }
   else if(%opt == "removetk")
   {
   	%name = Client::getName(%cl);
   	%aname = Client::getName(%clientId);
	%cl.TKCount = 0;
	echo("ADMINMSG: **** " @ %aname @ " cleared " @ %name @ "'s TK Count.");
	schedule ("BottomPrint( " @ %cl @ ",\"<F1><jc>Your TK's have been cleared. Be thankful!\",5);",0.5);
   }
   else if(%opt == "leader")
   {
   	%name = Client::getName(%cl);
   	%aname = Client::getName(%clientId);
   	if (%cl.islead)
  	{
		%cl.islead = 0;
		echo("ADMINMSG: **** " @ %aname @ " revoked " @ %name @ "'s LeaderShip Status");
		schedule ("BottomPrint( " @ %cl @ ",\"<F1><jc>Your LeaderShip Status Has Been Revoked!\",5);",0.5);
  	}
  	else
  	{
		%cl.islead = 1;
		echo("ADMINMSG: **** " @ %aname @ " granted " @ %name @ " LeaderShip Status");
		schedule ("BottomPrint( " @ %cl @ ",\"<F1><jc>You Have Been Granted LeaderShip Status!\",5);",0.5);
  	}
   }
   else if(%opt == "fnoban")
   {
   	%name = Client::getName(%cl);
   	%aname = Client::getName(%clientId);
   	if (%cl.noban)
  	{
		%cl.noban = 0;
		echo("ADMINMSG: **** " @ %aname @ " revoked " @ %name @ "'s No Ban Status");
		schedule ("BottomPrint( " @ %cl @ ",\"<F1><jc>Your No Ban Status Has Been Revoked!\",5);",0.5);
  	}
  	else
  	{
		%cl.noban = 1;
		echo("ADMINMSG: **** " @ %aname @ " granted " @ %name @ " No Ban Status");
		schedule ("BottomPrint( " @ %cl @ ",\"<F1><jc>You Have Been Granted No Ban Status!\",5);",0.5);
  	}
   }
   else if(%opt == "kbk") //======================================================================== Kill Ban Kick Menu
   {
	Client::buildMenu(%clientId, "Kill Ban Kick:", "options", true);
	%name = Client::getName(%cl);%sel = %cl;
	Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
	Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
	Client::addMenuItem(%clientId, %curItem++ @ "Kill " @ %name, "C1kill " @ %sel);
	return;
   }

   else if(%opt == "torture")
   {
	%name = Client::getName(%cl);
      Client::buildMenu(%clientId, "Admin Options:", "taffirm", true);
	if(%cl.tied) 
	Client::addMenuItem(%clientId,  %curItem++ @ "let em go? " @ %name, "tu1 " @ %cl); 
	else 
      Client::addMenuItem(%clientId, %curItem++ @ "hold " @ %name, "tC11 " @ %cl);
      Client::addMenuItem(%clientId, %curItem++ @ "Impulse " @ %name, "tC12 " @ %cl);
      Client::addMenuItem(%clientId, %curItem++ @ "Take Weapons " @ %name, "tC13 " @ %cl);
	if (%clientId.isAdmin && %clientId.isSuperAdmin)
	{
	if(%cl.freeze)
	Client::addMenuItem(%clientId, %curItem++ @ "*Defrost " @ %name, "unfreeze " @ %sel); 
	else
	Client::addMenuItem(%clientId, %curItem++ @ "Freeze " @ %name, "freeze " @ %sel); 
	if (%armor != parmor)
	Client::addMenuItem(%clientId, %curItem++ @ "Curse " @ %name, "C1peniscurse " @ %cl);
	else
	Client::addMenuItem(%clientId, %curItem++ @ "Uncurse " @ %name, "C1peniscurse " @ %cl);
	if(%cl.poss)
	Client::addMenuItem(%clientId,  %curItem++ @ "Unpossess  " @ %name, "tu5 " @ %cl); 
	else
	Client::addMenuItem(%clientId, %curItem++ @ "Possess " @ %name, "tC15 " @ %cl);
	}
      return;
   }


//= possess

   else if(getWord(%opt, 0) == "rposs"){
      %cl = getWord(%option, 1);
	%cl.poss = false;
	%clientId.possy = false;
	%clientId.possess = "";
	%cl.invulnerable = false;
	%pl = Client::getOwnedObject(%cl);
	%clId = Client::getOwnedObject(%clientId);
	centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" just let you go!", 5);
	%pl.invulnerable = false;
	%cl.possessedby = "";
	%clId.invulnerable = false;
	Client::setControlObject(%clientId, %clientId);
      Client::setControlObject(%cl, %cl);
	return;
	}


   else if(%opt == "smatch")
      Admin::startMatch(%clientId);

   else if(%opt == "vcmission" || %opt == "cmission")
   {
	%first = getWord(%options, 1);

	if (%opt == "vcmission")
		%clientId.vote = 1;

	Client::buildMenu(%clientId, "SELECT MISSION TYPE", "cmtype", true);
	%index = 0;

	if ($MList::TypeCount < 2) $TypeStart = 0; else $TypeStart = 1;

	for(%i = $TypeStart; %i < $MLIST::TypeCount; %i++)
	{
		if ($MLIST::Type[%i] != "Training")
		{
			%index++;
			if (%index <= 7)
			{
				Client::addMenuItem(%clientId, %index @ $MLIST::Type[%i], %i @ " 0");
			}
			else
			{
				Client::addMenuItem(%clientId, %index @ "More Mission Types...", "more " @ %i);
				break;
			}
		}
	}
	return;
   }
   else if(%opt == "ctimelimit")
   {
      Client::buildMenu(%clientId, "Change Time Limit:", "ctlimit", true);
      Client::addMenuItem(%clientId, "120 Minutes", 20);
      Client::addMenuItem(%clientId, "225 Minutes", 25);
      Client::addMenuItem(%clientId, "330 Minutes", 30);
      Client::addMenuItem(%clientId, "445 Minutes", 45);
      Client::addMenuItem(%clientId, "560 Minutes", 60);
      Client::addMenuItem(%clientId, "670 Minutes", 70);
      Client::addMenuItem(%clientId, "780 Minutes", 80);
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
   else if(%opt == "freeze") 
   { 
		if(%cl.isGod && !%clientId.isGod) 
		{ 
			Client::sendMessage(%clientId, 1, "What are you, stupid or something?  The Man can't be frozen, but you can.~waccess_denied.wav"); 
			%clientId.freeze = true; 
			Client::setControlObject(%clientId, -1); return; 
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
   else if(%opt == "vigil")
   {
	%clientId.novigil = "";
      return;
   }
   else if(%opt == "unvigil")
   {
	%clientId.novigil = "true";
      return;
   }

   Game::menuRequest(%clientId);
}

//====================================================================================================== Varrious Menu Process

function processMenuKAffirm(%clientId, %opt)
{
	echo("ADMINMSG: **** " @ Client::getName(getWord(%opt, 1)) @ " Kicked By " @ Client::getName(%clientId));

   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1));
   Game::menuRequest(%clientId);
}

function processMenuBAffirm(%clientId, %opt)
{
	echo("ADMINMSG: **** " @ Client::getName(getWord(%opt, 1)) @ " Banned By " @ Client::getName(%clientId));

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
 	 echo("ADMINMSG: **** " @ Client::getName(getWord(%opt, 1)) @ " Admined By " @ Client::getName(%clientId));

      }
   }
   Game::menuRequest(%clientId);
}

function processMenuDAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
	%cl = getWord(%opt, 1);	// PORT: was assigned only inside the test below
	if(%clientId.isSuperAdmin && !%cl.isSuperadmin)
	{
		%cl = getWord(%opt, 1);
		%cl.isAdmin = false;
		messageAll(0, Client::getName(%clientId) @ " revoked " @ Client::getName(%cl) @ "'s admin ability.");
		echo("ADMINMSG: **** " @ Client::getName(getWord(%opt, 1)) @ " Admined Revoked By " @ Client::getName(%clientId));
		return;
	}
	else if (%cl.isSuperadmin)
	{
		bottomprint(%clientId, "<jc>You can not Revoke a Super Admin.");
		return;
	}
   }
   Game::menuRequest(%clientId);
}


function processMenuRAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin && %clientId.isSuperAdmin)
   {
	 echo("ADMINMSG: **** Server Reset By " @ Client::getName(%clientId));

      messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
      exec("serverConfig.cs");
       	 Server::storeData();
      	 echo("ADMINMSG: **** Default config stored");
      	 Server::refreshData();
   }
   Game::menuRequest(%clientId);
}

function processMenuFAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin)
   {
	 echo("ADMINMSG: **** Server set to Tournament Mode By " @ Client::getName(%clientId));

      messageAll(0, Client::getName(%clientId) @ " has set the server to Tournament mode.");
      Admin::setModeTourney(%clientId);
   }
   Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{
   remoteSetTimeLimit(%clientId, %opt);
}

function processMenuMAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin && %clientId.isSuperAdmin)
   {
	 echo("ADMINMSG: **** Server set to match configuration By " @ Client::getName(%clientId));
	 messageAll(0, Client::getName(%clientId) @ " set the server to match settings.");
     	 exec("matchConfig.cs");
     	 Server::storeData();
      	 echo("ADMINMSG: **** Match config stored");
      	 Server::refreshData();

   }
   Game::menuRequest(%clientId);
}

//================================================================================================================ Bot Control Functions

function checkTeams()
{
      %numTeams = getNumTeams();
      %numPlayers = getNumClients();
      for(%i=0;%i<%numTeams;%i=%i+1)
         	%numTeamPlayers[%i] = 0;

      for(%i=0;%i<%numPlayers;%i=%i+1)
      {
         	%pl = getClientByIndex(%i);
         	if(%pl != %playerId)
         	{
            		%team = Client::getTeam(%pl);
            		%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
         	}
      }
      %lowPlayer = %numTeamPlayers[0];
      %lowTeam = 0;

      for(%i=1;%i<%numTeams;%i=%i+1)
      {
         	if(%numTeamPlayers[%i] < %lowPlayer)
         	{
            		%lowTeam = %i;
            		%lowPlayer = %numTeamPlayers;
         	}
      }
      return %lowTeam;
}

function DistanceToTarget (%clientId, %targetId)
{
	return (Vector::getDistance(GameBase::getPosition(%clientId),GameBase::getPosition(%targetId)));
}

// ===============================================================================================================
function MatchAssign()
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i = %i + 1)
	{
		%pl = getClientByIndex(%i);
		%clName = Client::getName(%pl);
		if ($debug) echo($Shifter::tag0 @ " " @ %clName @ " " @ String::findSubStr(%clName,$Shifter::Tag0 @ %pl));
      		if ($debug) echo($Shifter::tag1 @ " " @ %clName @ " " @ String::findSubStr(%clName,$Shifter::Tag1 @ %pl));
      		if(String::findSubStr(%clName,$Shifter::Tag0) == 0)
		 {
			//processmenuPickTeam(%pl,0,"");
			GameBase::setTeam(%pl,0);
		 }
		else if(String::findSubStr(%clName,$Shifter::Tag1) == 0)
		 {
			//processmenuPickTeam(%pl,1,"");
			GameBase::setTeam(%pl, 1);
		 }
		 else
      			GameBase::setTeam(%pl, -1);
	}
	return;
}

function beginMatchMode()
{
             exec("matchConfig.cs");
     	 Server::storeData();
      	 echo("ADMINMSG: **** Match config enabled");
      	 Server::refreshData();
}


//=============== additional functions

function stevestrip(%client, %mess) {
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
	Player::setDamageFlash(%client,0.75); 
	messageAll(0,Client::getName(%client) @" Just got ass raped!..");
	echo("ADMINMSG: **** Admin strips " @ Client::getName(%client));
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wdsgst2.wav\");", 5);
if (%mess == ""){
	centerprint(%client, "<jc><f1>DUDE! You have messed up NOW!!**there is a super admin in the house**!!!", 5); }
if (%mess != ""){
	centerprint(%client, "<jc><f1>"@%mess, 20); }
}

function processMenuTAffirm(%clientId, %opt)
{
	// PORT: this handler had no admin test. The menu that leads here lists hold / impulse / take
	// weapons for any admin and curse / possess for super admins only.
	if(!%clientId.isAdmin)
		return;
	%portCode = getWord(%opt, 0);
	if(%portCode == "tC14" || %portCode == "tu4" || %portCode == "tC15" || %portCode == "tu5" || %portCode == "C1peniscurse")
	{
		if(!%clientId.isSuperAdmin)
			return;
	}
   if(getWord(%opt, 0) == "tC11"){
      %tiedbastard = getWord(%opt, 1);
	%tiedbastard.tied = true;
	%pl = Client::getOwnedObject(%tiedbastard);
	//%tiedbastard.poss = true;
	%pl.invulnerable = true;
      Client::setControlObject(%tiedbastard, Client::getObserverCamera(%tiedbastard));
      Observer::setOrbitObject(%tiedbastard, %pl, 3, 3, 3);
	MessageAll( 0, Client::getName(%tiedbastard) @" is going to take a time out for being a ass!.. by: "@Client::getName(%clientId)@"!"); 
	echo("ADMINMSG: **** Admin ties " @ Client::getName(%pl));
	centerprint(%tiedbastard, "<jc><f1>The Boss "@Client::getName(%clientId)@" just told you to take a time out!!", 5);
   Game::menuRequest(%clientId);
	}
   if(getWord(%opt, 0) == "tu1"){
      %cl = getWord(%opt, 1);
	%cl.tied = false;
	%pl = Client::getOwnedObject(%cl);
	%pl.invulnerable = false;
	//%cl.poss = false;
      Client::setControlObject(%cl, %cl);
	echo("ADMINMSG: **** Admin frees " @ Client::getName(%cl));
	MessageAll( 0, Client::getName(%clientId)@" warms up to "@ Client::getName(%cl) );
	Game::menuRequest(%clientId); 
	}

   if(getWord(%opt, 0) == "tC12"){
      steveboot(getWord(%opt, 1),Client::getName(%clientId)@" gives you a little kick in the Ass...");
   Game::menuRequest(%clientId);
	}
   if(getWord(%opt, 0) == "tC13"){
	stevestrip(getWord(%opt, 1),Client::getName(%clientId)@" stripped you naked.");
	$Admin = Client::getName(%clientId)@" just took all of "@Client::getName(getWord(%opt, 1))@" guns.";
	echo($admin);
   Game::menuRequest(%clientId);
	}
   if(getWord(%opt, 0) == "tC14"){
      	%cursedbastard = getWord(%opt, 1);
		%cursedbastard.penis = true; 
		penis(getWord(%opt, 1),"You Got the Penis curse from "@Client::getName(%clientId)@" Enjoying your self?");
	$Admin = Client::getName(%clientId)@" cursed "@Client::getName(getWord(%opt, 1));
	echo($admin);
   		Game::menuRequest(%clientId);
	}
   if(getWord(%opt, 0) == "tu4"){
      rpenis(getWord(%opt, 1),"You're lucky, "@Client::getName(%clientId)@" removed your curse, better play nicer and behave.");
	$Admin = Client::getName(%clientId)@" uncursed "@Client::getName(getWord(%opt, 1));
	echo($admin);
   Game::menuRequest(%clientId);
	}
   if(getWord(%opt, 0) == "tC15"){
      %possbastard = getWord(%opt, 1);
	%possbastard.poss = true;
	%pl = Client::getOwnedObject(%possbastard);
	%clId = Client::getOwnedObject(%clientId); 
	%clId.invulnerable = true;
	%clientId.invulnerable = true;
	%clientId.possy = true;
	%clientId.possess = %pl;
	%possbastard.possessedby = %clientId;
      Client::setControlObject(%possbastard, Client::getObserverCamera(%possbastard));
      Observer::setOrbitObject(%possbastard, %pl, 3, 3, 3);
	MessageAll( 0, Client::getName(%clientId)@" admin-possesses "@Client::getName(%possbastard) @" for a bit..."); 
	centerprint(%possbastard, "<jc><f1>You are Now under "@Client::getName(%clientId)@"'s mind control, may as well relax a bit...", 10);
	echo("ADMINMSG: **** Admin client control " @ Client::getName(%pl));
	Client::setControlObject(%clientId, %possbastard);
   return;
	}
   if(getWord(%opt, 0) == "tu5"){
      %cl = getWord(%opt, 1);
	%cl.poss = false;
	%clientId.possy = false;
	%clientId.possess = "";
	%cl.invulnerable = false;
	%pl = Client::getOwnedObject(%cl);
	%clId = Client::getOwnedObject(%clientId);
	centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" just let you let you free..**RUN AND PLAY NICE**.", 5);
	%pl.invulnerable = false;
	%cl.possessedby = "";
	%clId.invulnerable = false;
	Client::setControlObject(%clientId, %clientId);
      Client::setControlObject(%cl, %cl);
	MessageAll( 0, Client::getName(%clientId) @" has finished their Vulcan mind control on "@Client::getName(%cl));
	echo("ADMINMSG: **** Admin client control " @ Client::getName(%cl));
	return;
	}
   if(getWord(%opt, 0) == "C1peniscurse")
	{
		%cl = getWord(%opt, 1);
		%armor = Player::getArmor(%cl);
		if (%armor != parmor)
		{
		 	Player::setArmor(%cl,parmor);
		 	checkMaxDrop(%cl,parmor);
		 	armorChange(%cl);
		 	Player::setItemCount(%cl, $ArmorName[%armor], 0);
			 messageAll(0, Client::getName(%cl) @ " was given ONE FOR BEING ONE by " @ Client::getName(%clientId) @ ".");
			echo("ADMINMSG: **** Admin cursed " @ Client::getName(%cl));
			 Player::setItemCount(%cl, Penis, 1);
			 Player::mountItem(%cl, Penis, $WeaponSlot);

	  	 	if(Player::getMountedItem(%cl,$FlagSlot) != -1)
	 	 		Player::dropItem(%cl,Player::getMountedItem(%cl,$FlagSlot));
 		}
		else
		{
	  		Client::sendMessage(%clientId,0,"Removing The Curse...");
			messageAll(0, " The curse has been lifted from " @ Client::getName(%cl) @ ", the price is death...");
			echo("ADMINMSG: **** Admin blessed " @ Client::getName(%cl));
			Player::setArmor(%cl,marmor);
			Vehicle::passengerJump(0,%cl,0);
			Player::dropItem(%cl,Penis);
	   		Player::blowUp(%cl);
			schedule ("Player::Kill(" @ %cl @ ");", 2.0);
			schedule ("playSound(ShockExplosion,GameBase::getPosition(" @ %cl @ "));",2.0);
			%obj = newObject("","Mine","PenisBlast");
			addToSet("MissionCleanup", %obj);
			%pos = GameBase::getPosition(%cl);
			GameBase::setPosition(%obj, %pos);
		}
	}
}

function steveboot(%client, %mess)
{
	%rotZ = getWord(GameBase::getRotation(%client),2); 
	GameBase::setRotation(%client, "0 0 " @ %rotZ); 
	%forceDir = Vector::getFromRot(GameBase::getRotation(%client),8000,400); 
	Player::applyImpulse(%client,%forceDir); 
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wbye.wav\");", 2);
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wdsgst1.wav\");", 2.2);
	messageAll(0,Client::getName(%client) @" got his ass blowed clear off the map!~wwbioa.wav");
	echo("ADMINMSG: **** Admin spanked " @ Client::getName(%client));
if (%mess == ""){
	centerprint(%client, "<jc><f1>HEY!....hehe.ahh.roomaa.ZOOM..ZOOM.Ah..Boom..BOOM!", 5); }
if (%mess != ""){
	centerprint(%client, "<jc><f1>"@%mess, 20); }
}
 

//====================================================================================================
// PORT (Modern Tribes 1.50). Menu codes are sent by the client: the Tab menu only LISTS what a
// player may do, and processMenuOptions used to run whatever code arrived. Any player could send
// kill / peniscurse / fnoban / muteplayer / tcrights ... for any other player, and start votes the
// server had switched off. This applies the conditions the menu itself uses, before the handler.
// freeze / unfreeze / rposs belong to the super-admin half of the "torture" menu.
//====================================================================================================
function ShifterPort::optAllowed(%clientId, %opt, %cl)
{
	// listed under "Admin Functions" for a super admin only
	if(%opt == "kbk" || %opt == "kick" || %opt == "ban" || %opt == "C1kill" || %opt == "removetk")
	{
		if(%clientId.isAdmin && %clientId.isSuperAdmin)
			return 1;
		return 0;
	}
	if(%opt == "fnoban" || %opt == "admin" || %opt == "deadmin" || %opt == "dtd" || %opt == "etd")
	{
		if(%clientId.isAdmin && %clientId.isSuperAdmin)
			return 1;
		return 0;
	}
	if(%opt == "matchConfig" || %opt == "reset" || %opt == "admin_weapons" || %opt == "ad_missle_on" || %opt == "ad_missle_off")
	{
		if(%clientId.isAdmin && %clientId.isSuperAdmin)
			return 1;
		return 0;
	}
	if(%opt == "ad_turret_on" || %opt == "ad_turret_off" || %opt == "obssetspy" || %opt == "freeze" || %opt == "unfreeze")
	{
		if(%clientId.isAdmin && %clientId.isSuperAdmin)
			return 1;
		return 0;
	}
	if(%opt == "rposs")
	{
		if(%clientId.isAdmin && %clientId.isSuperAdmin)
			return 1;
		return 0;
	}
	// listed under "Admin Functions" for any admin
	if(%opt == "menurequest2" || %opt == "fteamchange" || %opt == "torture" || %opt == "muteplayer" || %opt == "tcrights")
	{
		if(%clientId.isAdmin)
			return 1;
		return 0;
	}
	if(%opt == "leader" || %opt == "cmission" || %opt == "cyclemissions" || %opt == "ctimelimit" || %opt == "cffa")
	{
		if(%clientId.isAdmin)
			return 1;
		return 0;
	}
	if(%opt == "smatch" || %opt == "ctourney")
	{
		if(%clientId.isAdmin)
			return 1;
		return 0;
	}
	// votes the settings file can switch off
	if(%opt == "c1vadmin")
	{
		if($Shifter::VoteAdmin)
			return 1;
		return 0;
	}
	if(%opt == "cvkick")
	{
		if($Shifter::VoteKick)
			return 1;
		return 0;
	}
	if(%opt == "vetd")
	{
		if($Shifter::VoteDTD)
			return 1;
		return 0;
	}
	if(%opt == "vdtd")
	{
		if($Shifter::VoteDTD)
			return 1;
		return 0;
	}
	if(%opt == "vsmatch")
	{
		if($Shifter::VoteFFA)
			return 1;
		return 0;
	}
	// an admin can lock a player's team ("Lock <name>'s Team"); the menu then hides this entry
	if(%opt == "changeteams")
	{
		if(%clientId.SwitchPerm)
			return 0;
		return 1;
	}
	return 1;
}

$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

$pskin = $Wasteland::PersonalSkin;

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
   	if(%client.isSuperAdmin) $Server::Password = %password;
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

	if ($DuelStatus[%clientId] == "Available")
	{
		for(%cl = Client::getFirst(); %cl != -1;
		%cl = Client::getNext(%cl))
		{ 
			if ($DuelStatus[%cl] == "Available" && $DuelLineup[%cl] == %clientId)
			{
				DuelInit(%clientId, %cl);
			}
		}
	}
	if ($DuelStatus[%clientId] == "Titan")
	{
		%team =Client::getTeam(%clientId);
		for(%cl = Client::getFirst(); %cl != -1;
		%cl = Client::getNext(%cl))
		{
			if ($TeamTitan[%team] == Client::getOwnedObject(%cl))
			{
				$TeamTitan[%team]="";
				playNextAnim(%cl);
				Player::kill(%cl);
				Game::playerSpawn(%clientId, true);
				$DuelStatus[%clientId]="";
			}
		}
	}
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
		if(%client.isSuperAdmin && !%admin.isGod)
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
		{
			BanList::add(%ip, 1800);
   			BanList::export("config\\banlist.cs");
		}
		else
			BanList::add(%ip, 180);

		if(%admin == -1)
		{
			MessageAll(0, %name @ " was " @ %word @ " from vote.");
			KickPlayer(%client, "You were " @ %word @ " by  consensus.");
		}
		else if(%admin.isGod)
		{
			Client::sendMessage(%admin, 0, %name @ " was Secretly " @ %word);
			KickPlayer(%client, "Server went down.");
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
		if (%cl.isAdmin)
		{
			%votesFor++;
			%totalVotes++;
		}
		if (%cl.isSuperAdmin)
		{
			%votesFor++;
			%totalVotes++;
		}
		if (%cl.isGod)
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
		if (%cl.isSuperAdmin)
		{
			%votesAgainst++;
			%totalVotes++;
		}
		if (%cl.isGod)
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
	echo("ADMINMSG: **** Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %votesAbstain @ " abstentions.");
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
	echo("ADMINMSG: **** Vote to " @ $curVoteTopic @ " failed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %votesAbstain @ " abstentions.");
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
	if (%clientId.isAdmin){}
	else if(%diff > 0)
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
		messageAll(1, Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic @ "~wwPoop!.wav");
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

		%addr = Client::getTransportAddress(%selId);

		remoteEval(%clientId, "setInfoLine", 1, "Game Stats");
		if (%clientId.isSuperAdmin || %clientId == %selId) remoteEval(%clientId, "setInfoLine", 2, "Addr-IP   :" @ %addr);
		remoteEval(%clientId, "setInfoLine", 3, "Last TKer :" @ $Wasteland::LastTKer @ "    T-Kills   :" @ %clientId.TotalKills);
		remoteEval(%clientId, "setInfoLine", 4, "Last TKed :" @ $Wasteland::LastTKed @ "    T-Score   :" @ %clientId.TotalScore);
		remoteEval(%clientId, "setInfoLine", 5, "TK Count  :" @ $Wasteland::LastTKno @ "    T-Deaths  :" @ %clientId.TotalDeaths);
		remoteEval(%clientId, "setInfoLine", 6, "T-Caps    :" @ %clientId.TotalFlagCaps);
	}
}

function processMenuFPickTeam(%clientId, %team)
{
	if(%clientId.isAdmin)
		processMenuPickTeam(%clientId.ptc, %team, %clientId);
	%clientId.ptc = "";
}

//============================================================
//			Main Menus
//============================================================
function Game::menuRequest(%clientId)
{
   	%curItem = 0;
   	Client::buildMenu(%clientId, "Options", "options", true);
//============ Duel Menu
	if ($Game::missionType == "Duel")
	{
		if ($DuelStatus[%clientId] == "Available")
		{
			for(%cl = Client::getFirst(); %cl != -1;
			%cl = Client::getNext(%cl))
			{ 
				if ($DuelStatus[%cl] == "Available" && $DuelLineup[%cl] == %clientId)
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Accept duel from " @ Client::GetName(%cl), "acceptduel " @ %cl);
				}
			}
		}
		if (!%clientId.selClient)
		{
			if ($DuelLastEnemy[%clientId] != "" && $DuelMode[$DuelLastEnemy[%clientId]] == "On" && $DuelMode[%clientId] == "On")
				Client::addMenuItem(%clientId, %curItem++ @ "Request Rematch", "rerequest " @ $DuelLastEnemy[%clientId]);
			Client::addMenuItem(%clientId, %curItem++ @ "SpawnFavs SetUp", "packsetup");
		}
		else
		{
			%sel = %clientId.selClient;
                	Client::addMenuItem(%clientId, %curItem++ @ "Duel " @ Client::GetName(%sel), "duel " @ %sel);
		}
	}
	%team =Client::getTeam(%clientId);
//============ Titan Menu
	if ($TeamTitan[%team] == Client::getOwnedObject(%clientId) && %clientId.selClient)
	{
		%sel = %clientId.selClient;
		Client::addMenuItem(%clientId, %curItem++ @ "Pass Titan to " @ Client::GetName(%sel), "titan " @ %sel);
	}
	if ($DuelStatus[%clientId] == "Titan")
	{
		for(%cl = Client::getFirst(); %cl != -1;
		%cl = Client::getNext(%cl))
		{ 
			if ($TeamTitan[%team] == Client::getOwnedObject(%cl))
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Accept Titan from " @ Client::GetName(%cl), "accepttitan " @ %cl);
			}
		}
	}
//============ Basic Menu
   	if(!$matchStarted || !$Server::TourneyMode)
   	{
		if(!%clientId.selClient && !$Server::TourneyMode)
		{
	    		if (!%clientId.SwitchPerm &&	$Game::missionType != "Duel")
	    			Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
		}
   	}

	if (%clientId.observerMode != "observerOrbit" && %clientId.observerMode != "observerFly")
	{
		if ($Wasteland::Weapons && !%clientId.selClient)
			Client::addMenuItem(%clientId, %curItem++ @ "Item Options", "weaponoptions");

		if ($Wasteland::SaveOn && !%clientId.selClient)
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
	if(%team.smrtpck)
	{
		if(%clientId.novigil)
			Client::addMenuItem(%clientId, %curItem++ @ "Unmute Vigil", "vigil");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Mute Vigil", "unvigil");
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
      	if (%clientId.isAdmin)
		{
			if($Server::Admin["sadpw", %name] == "") Client::addMenuItem(%clientId, %curItem++ @ "Register " @ %name, "t4 " @ %sel);
      		else if ($Server::Admin["sadpw", %name] == $Client::info[%sel, 5] && !%sel.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Unregister " @ %name, "tu4 " @ %sel);
      		else if ($Server::Admin["sadpw", %name] == $Client::info[%sel, 5] && %clientId.isGod) Client::addMenuItem(%clientId, %curItem++ @ "Unregister " @ %name, "tu4 " @ %sel);
		}
	}
}
//=================================================
//		End of Initial Menu System
//=================================================


//==========================================
//	     Main Menu Process
//===========================================
// PORT (2026-10-12): the menu code and its argument come from the client. These Options
// branches had no rank test of their own (the menu merely did not show them), so any player
// could send them. 1 = admin, 2 = super admin: the rank the mod's own menus ask for.
function BWPort::optRank(%opt)
{
	if(%opt == "tcrights" || %opt == "muteplayer" || %opt == "leader" || %opt == "torture" || %opt == "t4" || %opt == "tu4")
		return 1;
	if(%opt == "kbk" || %opt == "kill" || %opt == "removetk" || %opt == "fnoban" || %opt == "rposs" || %opt == "clanfirst" || %opt == "clanlast")
		return 2;
	if(%opt == "admin_weapons" || %opt == "ad_missle_on" || %opt == "ad_missle_off" || %opt == "ad_turret_on" || %opt == "ad_turret_off")
		return 2;
	return 0;
}

function processMenuOptions(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	// PORT (2026-10-12): rank test for the branches listed in BWPort::optRank; their target is
	// forced to a number because it is pasted into schedule() strings below.
	%portRank = BWPort::optRank(%opt);
	if(%portRank >= 1 && !%clientId.isAdmin) return;
	if(%portRank >= 2 && !%clientId.isSuperAdmin) return;
	if(%portRank >= 1) %cl = floor(%cl);
//===== duel mode additions

	if (%opt == "rerequest")
	{
		DuelInit(%clientId, %cl);
		return;
	}
	else if(%opt == "duel")
	{ 
		DuelInit(%clientId,%cl);
		return;
	}
	else if (%opt == "acceptduel")
	{
		if ($DuelStatus[%cl] == "Available" && $DuelLineup[%cl] == %clientId)
		{
			DuelInit(%clientId, %cl);
			return;
		}
		else
		{
			Client::SendMessage(%clientId,0,"You can no longer accept the duel from " @ Client::GetName(%cl));
			return;
		}
	}
//===== titan mode additions

	else if(%opt == "titan")
	{
		if (%cl == %clientId)
		{
			client::sendmessage(%clientId,1,"You ARE the Titan!");
			return;
		}	
		$DuelStatus[%cl] = "Titan";
		client::sendmessage(%clientId,1,"Awaiting " @ Client::getName(%cl) @ " to accept on Titan status.");
		client::sendmessage(%cl,1,Client::getName(%cl) @ " is asking you to take over as Titan!~wfemale4.wregroup.wav");
		return;
	}
	else if (%opt == "accepttitan")
	{
		%team = Client::getTeam(%clientId);
		%pl = $TeamTitan[%team];
		%cl = Player::getClient(%pl);
		$TeamTitan[%team]="";
		playNextAnim(%cl);
		Player::kill(%cl);
		Game::playerSpawn(%clientId, true);
		$DuelStatus[%clientId]="";
	}
//==== end Titan mode additions
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
	else if(%opt == "observep") //=================== Obs, Selected
	{
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);
		Observer::setTargetClient(%clientId, %sel);
		if (%clientId.spymode != "1")
		{
			bottomprint(%sel, "<jc>You Are Being Observed By : " @ Client::getName(%clientId), 5);
		}
	}

	//================================== Set Observer Options
	if(%opt == "obssetcfollow") {		%clientId.obsmode = 4; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer,Follow mode set as default.",3); return; }
	else if(%opt == "obssetffollow") {	%clientId.obsmode = 5; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer,Follow mode set as default.",3); return; }
	else if(%opt == "obssetaction") {	%clientId.obsmode = 6; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer,Follow mode set as default.",3); return; }
	else if(%opt == "obssetvclose") { 	%clientId.obsmode = 3; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, Very close mode set as default.",3); return; }
	else if(%opt == "obssetclose") { 	%clientId.obsmode = 0; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, Close mode set as default.",3); return; }
	else if(%opt == "obssetfar") { 		%clientId.obsmode = 1; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, Far View set as default.",3); return; }
	else if(%opt == "obssetfirst") { 	%clientId.obsmode = 2; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, First person view set as default.",3); return; }
	else if(%opt == "obssetspy") { if (	%clientId.spymode == "0" || !%clientId.spymode) { %clientId.spymode = "1"; bottomprint(%clientId, "Observer Spy mode is set, observed player will recieve no warning.",3); } else { %clientId.spymode = "0"; bottomprint(%clientId, "Observer Warn mode is set, player will recieve notice that you are observing",3); } return; }

	//=========================================== Voting Options
	if(%opt == "menurequest3")
	{
		if ($Debug) echo("*** Process Voting Options ***");
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Is Accessing Voting Menu");
		%curItem = 0;

		Client::buildMenu(%clientId, "Voting Options", "options", true);

		//=================================== Client Selected
		if(%clientId.selClient)
		{
			%sel = %clientId.selClient;
			%name = Client::getName(%sel);

			if($curVoteTopic == "")
			{
				if ($Wasteland::VoteAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
				if ($Wasteland::VoteKick && !%sel.isGod)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
			}

			if(%clientId.muted[%sel])
				Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
			if(%clientId.observerMode == "observerOrbit")
				Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
		}

		//====================== No Client Selected
		if (!%clientId.selClient && $curVoteTopic == "")
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");

			if($Wasteland::VoteDTD)
			{
				if($Server::TeamDamageScale == 1.0)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
			}

			if($Wasteland::VoteFFA)
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
	//===============================
	//  Secondary Menu System - Mostly Super Admin Functions
	//=================================

	else if(%opt == "menurequest2")
	{
		if ($Debug) echo("*** Process Admin Options ***");
		echo("ADMINMSG: *** " @ Client::getName(%clientId) @ " Is Accessing Admin Menu");
		%curItem = 0;

		Client::buildMenu(%clientId, "Admin Options", "options", true);

		//======================= Client Is Only Admin
		if(%clientId.isAdmin)
		{
			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
				%armor = Player::getArmor(%sel);

				if($Game::missionType != "Duel") Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
	        		Client::addMenuItem(%clientId, %curItem++ @ "Torture " @ %name, "torture " @ %sel);
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
				if($Server::TourneyMode)  //============ Toggle Tourney Mode
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
					if(!$CountdownStarted && !$matchStarted)
						Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
				}
				else if($Game::missionType != "Duel")
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Tournament mode", "ctourney");
					Client::addMenuItem(%clientId, %curItem++ @ "Enable " @ $ClanPriority @ " Teaming", "matchConfig");
				}
			}
		}

		//============ Client Is SuperAdmin
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
				if (!%sel.isSuperAdmin && %clientId.isGod)
					Client::addMenuItem(%clientId, %curItem++ @ "Super " @ %name, "desuper " @ %sel);
			}
			//============================== With No Client
			else
			{
				if($ClanSet == "") Client::addMenuItem(%clientId, %curItem++ @ "Enable Clan Priority", "clanfirst");
				else Client::addMenuItem(%clientId, %curItem++ @ "Disable Clan Priority", "clanlast");
				if($Server::TeamDamageScale == 1.0) Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
				else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
				Client::addMenuItem(%clientId, %curItem++ @ "Reset Menu", "reset");
   				if ($Wasteland::WeaponAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Weapon Options", "admin_weapons");		
			}
		}
		return;
	}

	else if (%opt == "cyclemissions")
	{
		remoteCycleMission(%clientId);
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

//=================================================
//== Weapon Options 
//==============================================
   	else if (%opt == "weaponoptions")
   	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Weapon Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Plasma Options", "weapon_plasma");
		Client::addMenuItem(%clientId, %curItem++ @ "Rocket Options", "weapon_rocket");
   		Client::addMenuItem(%clientId, %curItem++ @ "Grenade Launcher", "weapon_grenl");
		Client::addMenuItem(%clientId, %curItem++ @ "Mortar Options", "weapon_mortar");

		if (%armor == "earmor" || %armor == "efemale" || %armor == "aarmor" || %armor == "afemale" || %armor == "rarmor") Client::addMenuItem(%clientId, %curItem++ @ "GravGun Options", "weapon_gravgun");

		if (%armor == "earmor" || %armor == "efemale")
		{
	   		Client::addMenuItem(%clientId, %curItem++ @ "Engineer Mines", "weapon_engmine");
	   		Client::addMenuItem(%clientId, %curItem++ @ "Engineer Beacons", "weapon_engbeacon");
		}

		if (%armor == "spyarmor" || %armor == "spyfemale") Client::addMenuItem(%clientId, %curItem++ @ "Plastique Options", "weapon_plastic");

		if (%armor == "larmor" || %armor == "lfemale" || %armor == "spyarmor" || %armor == "spyfemale") Client::addMenuItem(%clientId, %curItem++ @ "Pneumatic Rifle", "sniper_options");

		if (%armor == "harmor") Client::addMenuItem(%clientId, %curItem++ @ "Mine Options", "weapon_dmines");

		if (%armor == "aarmor" || %armor == "afemale")
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Clear Telepoint", "cleartelepoint");
			Client::addMenuItem(%clientId, %curItem++ @ "Warp Options", "weapon_warp");
		}

   		if (%pack == "BalloonPack" || %pack == "ZepplinPack") Client::addMenuItem(%clientId, %curItem++ @ "Zepplin Options", "weapon_zepplin");

   		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Options", "spawn_options");

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

		if ($Wasteland::LockOn)
			Client::addMenuItem(%clientId, %curItem++ @ "Turn Off Missle Lock", "ad_missle_off");
		if (!$Wasteland::LockOn)
			Client::addMenuItem(%clientId, %curItem++ @ "Turn On Missle Lock", "ad_missle_on");
		if ($Wasteland::TurretKill)
			Client::addMenuItem(%clientId, %curItem++ @ "Turn Off Turret Kills", "ad_turret_off");
		if (!$Wasteland::TurretKill)
			Client::addMenuItem(%clientId, %curItem++ @ "Turn On Turret Kills", "ad_turret_on");
		return;
	}
	else if (%opt == "ad_missle_on")
	{
		$Wasteland::LockOn = True;
		return;
	}
	else if (%opt == "ad_missle_off")
	{
		$Wasteland::LockOn = False;
		return;
	}
	else if (%opt == "ad_turret_on")
	{
		$Wasteland::TurretKill = True;
		return;
	}
	else if (%opt == "ad_turret_off")
	{
		$Wasteland::TurretKill = False;
		return;
	}
	else if (%opt == "cleartelepoint")
	{
		%obj = %clientId.telebeacon;
		Mine::Detonate(%obj);
		%clientId.telepoint = "";
		return;
	}
	else if (%opt == "spawn_options")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Spawn Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Standard", "spawn_standard");
   		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Random", "spawn_random");
   		if ($Wasteland::SpawnFavs) Client::addMenuItem(%clientId, %curItem++ @ "Spawn Favorites", "spawn_favs");
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
	else if (%opt == "weapon_mortar")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mortar Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Shell", "weapon_mortar_regular");
   		Client::addMenuItem(%clientId, %curItem++ @ "Frag Shell", "weapon_mortar_frag");
   		Client::addMenuItem(%clientId, %curItem++ @ "MDM Shell", "weapon_mortar_mdm");
   		return;
	}
	else if (%opt == "weapon_grenl")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Grenade Launcher Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Shell", "weapon_grenl_regular");
   		Client::addMenuItem(%clientId, %curItem++ @ "EMP Shell", "weapon_grenl_emp");
   		Client::addMenuItem(%clientId, %curItem++ @ "Peace Shell", "weapon_grenl_stick");
   		Client::addMenuItem(%clientId, %curItem++ @ "Toxin Shell", "weapon_grenl_tranq");
   		Client::addMenuItem(%clientId, %curItem++ @ "Concussion Shell", "weapon_grenl_conc");
   		Client::addMenuItem(%clientId, %curItem++ @ "Mine Shell", "weapon_grenl_mine");
   		Client::addMenuItem(%clientId, %curItem++ @ "Tracker Shell", "weapon_grenl_trac");
		if (%armor == "spyarmor" || %armor == "spyfemale") Client::addMenuItem(%clientId, %curItem++ @ "Plastique Shell", "weapon_grenl_plas");
   		return;
	}
	else if (%opt == "weapon_rocket")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Stinger Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Stinger", "weapon_rocket1");
   		if ($Wasteland::LockOn)
   			Client::addMenuItem(%clientId, %curItem++ @ "Grounder Rockets", "weapon_rocket3");
   		Client::addMenuItem(%clientId, %curItem++ @ "Wire Guided", "weapon_rocket4");
   		return;
	}
	else if (%opt == "weapon_plasma")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Plasma Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_plasma_regular");
   		Client::addMenuItem(%clientId, %curItem++ @ "Multi Fire", "weapon_plasma_multi");
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
	else if (%opt == "weapon_warp")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Warp Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "10 meters forward", "weapon_warp_warp10");
   		Client::addMenuItem(%clientId, %curItem++ @ "20 meters forward", "weapon_warp_warp20");
   		Client::addMenuItem(%clientId, %curItem++ @ "50 meters forward", "weapon_warp_warp50");
   		Client::addMenuItem(%clientId, %curItem++ @ "10 meters up", "weapon_warp_warp15");
   		Client::addMenuItem(%clientId, %curItem++ @ "50 meters up", "weapon_warp_warp55");
   		Client::addMenuItem(%clientId, %curItem++ @ "10 meters down", "weapon_warp_warp25");
   		return;
	}
	else if (%opt == "weapon_zepplin")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Zepplin Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Rapid ascent", "weapon_zepplin_r");
   		Client::addMenuItem(%clientId, %curItem++ @ "Moderate ascent", "weapon_zepplin_m");
   		Client::addMenuItem(%clientId, %curItem++ @ "Hold Altitude", "weapon_zepplin_h");
   		Client::addMenuItem(%clientId, %curItem++ @ "Parachute", "weapon_zepplin_p");
   		return;
	}
	//======================================= Sniper Opts
	else if (%opt == "sniper_options")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Sniper Type", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard", "weapon_sniper_std");
   		Client::addMenuItem(%clientId, %curItem++ @ "Hot Tip", "weapon_sniper_hot");
   		Client::addMenuItem(%clientId, %curItem++ @ "EMP Slug", "weapon_sniper_emp");
   		return;
	}
	//======================================= Engineer Opts
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

	//============================== Plastique
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

	//============================================= warp
	if (%opt == "weapon_warp_warp10")
	{
		%clientId.Warpf = 10;
		%clientId.Warpv = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Warp Set To 10 meters forward.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_warp_warp20")
	{
		%clientId.Warpf = 20;
		%clientId.Warpv = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Warp set to 20 meters forward (use with caution).\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_warp_warp50")
	{
		%clientId.Warpf = 50;
		%clientId.Warpv = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Danger: Warp set to 50 meters forward (highly unstable molecular scatter).\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_warp_warp15")
	{
		%clientId.Warpf = 0;
		%clientId.Warpv = 10;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Warp set to 10 meters up.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_warp_warp55")
	{
		%clientId.Warpf = 0;
		%clientId.Warpv = 50;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Danger: Warp set to 50 meters up (highly unstable molecular scatter).\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_warp_warp25")
	{
		%clientId.Warpf = 0;
		%clientId.Warpv = -10;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Warp set to 10 meters down (use with extreme caution).\", 3);", 0);
   		return;
	}
	//============================================= zepplin
	if (%opt == "weapon_zepplin_r")
	{
		%clientId.zepop = 80;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Zepplin set for rapid ascent.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_zepplin_m")
	{
		%clientId.zepop = 20;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Zepplin set for moderate ascent.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_zepplin_h")
	{
		%clientId.zepop = 10;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Zepplin set to maintain altitude.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_zepplin_p")
	{
		%clientId.zepop = -70;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Zepplin set to parachute, and reinforced for the additional strain of deployement.\", 3);", 0);
   		return;
	}

	//======================================================================== Mortar Options
	if (%opt == "weapon_mortar_regular")
	{
		%clientId.Mortar = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Mortar Selected.\", 3);", 0);
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
	//====================================================Grenade Launcher Options
	if (%opt == "weapon_grenl_regular")
	{
		%clientId.grenl = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Grenade Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_grenl_emp")
	{
		%clientId.grenl = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Electro Magnetic Pulse Shell Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_grenl_stick")
	{
		%clientId.grenl = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Peace-Maker Shell Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_grenl_tranq")
	{
		%clientId.grenl = 3;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Toxin Shell Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_grenl_conc")
	{
		%clientId.grenl = 4;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Concussion Shell Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_grenl_mine")
	{
		%clientId.grenl = 5;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Shell Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_grenl_trac")
	{
		%clientId.grenl = 7;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Tracker Shell Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_grenl_plas")
	{
		%clientId.grenl = 6;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Shell Selected.\", 3);", 0);
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
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grounder Rocket Initiated.\", 3);", 0);
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
	else if (%opt == "weapon_plasma_multi")
	{
		%clientId.Plasma = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Multi-Bold Plasma Selected.\", 3);", 0);
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

	//======================================Pneumatic Rifle Options
	else if (%opt == "weapon_sniper_std")
	{
		%clientId.snipe = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Poison-Tipped Dart Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_sniper_hot")
	{
		%clientId.snipe = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Hot-Tip Round Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_sniper_emp")
	{
		%clientId.snipe = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>EMP Round Selected.\", 3);", 0);
   		return;
	}

	else if(%opt == "fteamchange")
	{
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
	  if($Wasteland::KeepBalanced)
      {
	      %j = checkTeams();

		if($Wasteland::KeepBalanced)
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
   else if(%opt == "t4" && $Client::info[%cl, 5] != "")
	{
		%name = Client::getName(%cl);
		%hashname = hashname(%name);
		%pw = $Client::info[%cl, 5];
		$Server::Admin["sadpw", %name] = %pw;
		$Server::Admin["[\"sadpw\",\"" @ %name @ "\"]"] = %pw;
		export("Server::Admin[\"sadpw\",*", "config\\aaregistrar.cs", false);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" registered you for this server.", 5);
		centerprint(%clientId, "<jc><f1>"@Client::getName(%cl)@" is registered.", 5);
	}
   else if(%opt == "t4" && $Client::info[%cl, 5] == "")
	{
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" tried registered you but you have no password in your player's 'OTHER' info line.", 5);
		centerprint(%clientId, "<jc><f1>"@Client::getName(%cl)@" has no password.", 5);
	}
   else if(%opt == "tu4")
	{
		%name = Client::getName(%cl);
		%hashname = hashname(%name);
		%pw = $Client::info[%cl, 5];
		$Server::Admin["sadpw", %name] = "";
		$Server::Admin["[\"sadpw\",\"" @ %name @ "\"]"] = "XXXXXXdeleatedXXXXXX";
		export("Server::Admin[\"sadpw\",*", "config\\aaregistrar.cs", false);
		if (!%clientId.isGod) centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" revoked your registration for this server.", 5);
	}

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
   else if(%opt == "clanfirst")
	{
      	$ClanSet = $ClanPriority;
		messageAll(1, Client::getName(%clientId) @ " initiated " @ $ClanSet @ " Clan priority");
		bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " initiated " @ $ClanSet @ " Clan priority", 10);
		return;
	}
   else if(%opt == "clanlast")
	{
      	$ClanSet = "";
		messageAll(1, Client::getName(%clientId) @ " disabled Clan priority");
		bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " disabled Clan priority", 10);
		return;
	}
   else if(%opt == "voteYes" && %cl == $curVoteCount) //=============== Yes
   {
      %clientId.vote = "yes";
      centerprint(%clientId, "", 0);
   }

   else if(%opt == "voteNo" && %cl == $curVoteCount) //========== No
   {
      %clientId.vote = "no";
      centerprint(%clientId, "", 0);
   }

   else if(%opt == "kick") //==================== Kick Player
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }

   else if(%opt == "admin") //=================================== Admin
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }

   else if(%opt == "deadmin") //================================= DeAdmin Conf
   {
      Client::buildMenu(%clientId, "Confirm deadmim:", "daffirm", true);
      Client::addMenuItem(%clientId, "1DeAdmin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't DeAdmin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }

   else if(%opt == "botmenu") //====================================== Bot Menu
   {
         Client::buildMenu(%clientId, "Bot Menu:", "selbotaction", true);
         Client::addMenuItem(%clientId, "1Spawn A Bot", "spawnbot");
	     Client::addMenuItem(%clientId, "2Remove Bot", "removebot");
	     if(%clientId.isSuperAdmin)
		 	Client::addMenuItem(%clientId, "3Killem All", "kbaffirm");

		 return;
   }

   else if(%opt == "ban") //====================================== Ban Player
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "kill") //================================== Admin Kill Player
   {
	Player::setArmor(%cl,larmor);
	armorChange(%cl);
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
	Client::addMenuItem(%clientId, %curItem++ @ "Kill " @ %name, "kill " @ %sel);
	return;
   }

   else if(%opt == "torture")
   {
	%name = Client::getName(%cl);
      Client::buildMenu(%clientId, "The Chamber Tools:", "taffirm", true);
      Client::addMenuItem(%clientId, %curItem++ @ "Stun " @ %name, "t1 " @ %cl);
      Client::addMenuItem(%clientId, %curItem++ @ "Spank " @ %name, "t2 " @ %cl);
      Client::addMenuItem(%clientId, %curItem++ @ "Strip " @ %name, "t3 " @ %cl);
	if (%clientId.isAdmin && %clientId.isSuperAdmin)
	{
		if (%cl.curse)
			Client::addMenuItem(%clientId, %curItem++ @ "unCurse " @ %name, "curse " @ %cl);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Curse " @ %name, "curse " @ %cl);
		if (%cl.banish)
			Client::addMenuItem(%clientId, %curItem++ @ "UnBanish " @ %name, "banish " @ %cl);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Banish " @ %name, "banish " @ %cl);
		if(%cl.poss) Client::addMenuItem(%clientId,  %curItem++ @ "Unpossess  " @ %name, "tu5 " @ %cl); 
		else if (!%clientId.possy && %cl != %clientId && %cl.observerMode == "") Client::addMenuItem(%clientId, %curItem++ @ "Possess " @ %name, "t5 " @ %cl);
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
	centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" gave you back your body..", 5);
	%pl.invulnerable = false;
	%cl.possessedby = "";
	%clId.invulnerable = false;
	Client::setControlObject(%clientId, %clientId);
      Client::setControlObject(%cl, %cl);
	MessageAll( 0, Client::getName(%clientId) @" excorcised "@Client::getName(%cl));
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
      Client::buildMenu(%clientId, "Reset Options:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Abort", "no");
      Client::addMenuItem(%clientId, "2Reset", "yes");
      if (%clientId.isGod) Client::addMenuItem(%clientId, "3Quit", "quit");
      return;
   }
   else if(%opt == "matchConfig")
   {
      Client::buildMenu(%clientId, "Confirm " @ $ClanPriority @ " Teaming:", "maffirm", true);
      Client::addMenuItem(%clientId, "1Enable", "yes");
      Client::addMenuItem(%clientId, "2Cancel", "no");
      return;
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
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

//=========================== Various Menu Process

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
   if(%opt == "yes" && %clientId.isAdmin)
   {
	 echo("ADMINMSG: **** Server Reset By " @ Client::getName(%clientId));

      messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
      exec("Wasteland.cs");
       	 Server::storeData();
      	 echo("ADMINMSG: **** Default config stored");
      	 Server::refreshData();
   }
   if(%opt == "quit" && %clientId.isGod)
   {
	 echo("ADMINMSG: **** Server Quit By " @ Client::getName(%clientId));

      messageAll(0, Client::getName(%clientId) @ " reset the server.");
	quit();
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
   if(%opt == "yes" && %clientId.isAdmin)
   {
	 echo("ADMINMSG: **** Server set to " @ $ClanPriority @ " Teaming By " @ Client::getName(%clientId));
	 messageAll(0, Client::getName(%clientId) @ " set the server to " @ $ClanPriority @ " Teaming.");
	MatchAssign();
	$Wasteland::FairCheck = "2340";
	$Wasteland::FairEvens = "2340";
   }
}

//============================= Bot Control Functions
// Check for team with lowest

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

// ==================================
function MatchAssign()
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i = %i + 1)
	{
		%pl = getClientByIndex(%i);
		%clName = Client::getName(%pl);
     		if(String::findSubStr(%clName,$Wasteland::Tag0) == 0)
		{
			processmenuPickTeam(%pl,0,"");
			//GameBase::setTeam(%pl,0);
		}
		else if(String::findSubStr(%clName,$Wasteland::Tag1) == 0)
		{
			processmenuPickTeam(%pl,1,"");
			//GameBase::setTeam(%pl, 1);
		}
		else processmenuPickTeam(%pl,1,"");//GameBase::setTeam(%pl, -1);
	}
	return;
}

//=============== additional functions

function processMenuTAffirm(%clientId, %opt)
{
	// PORT (2026-10-12): the torture menu is built for admins (t1-t3) and super admins (the rest);
	// the handler itself had no rank test.
	if(!%clientId.isAdmin) return;
	%portT = getWord(%opt, 0);
	if(!(%portT == "t1" || %portT == "t2" || %portT == "t3") && !%clientId.isSuperAdmin) return;
	%cl= getWord(%opt, 1);
   if(getWord(%opt, 0) == "t1"){
      Client::setControlObject(%cl, Client::getObserverCamera(%cl));
      Observer::setOrbitObject(%cl, %pl, 3, 3, 3);
	MessageAll( 0, Client::getName(%cl) @" is frozen by "@Client::getName(%clientId)@" for being an Ice Hole!"); 
	echo("ADMINMSG: **** Admin ties " @ Client::getName(%cl));
	centerprint(%cl, "<jc><f1>You were frozen by "@Client::getName(%clientId)@" for being an Ice Hole!", 5);
   Game::menuRequest(%clientId);
	}

   if(getWord(%opt, 0) == "t2"){
      steveboot(%cl,Client::getName(%clientId)@" gives you a kick in the pants...");
   Game::menuRequest(%clientId);
	}
   if(getWord(%opt, 0) == "t3"){
	stevestrip(%cl,Client::getName(%clientId)@" stripped you naked.");
	$Admin = Client::getName(%clientId)@" stripped "@Client::getName(%cl)@" naked.";
	echo($admin);
   Game::menuRequest(%clientId);
	}
   if(getWord(%opt, 0) == "t5"){
	%cl.poss = true;
	%pl = Client::getOwnedObject(%cl);
	%clId = Client::getOwnedObject(%clientId); 
	%clientId.possy = true;
	%clientId.possess = %pl;
	%cl.possessedby = %clientId;
      Client::setControlObject(%cl, Client::getObserverCamera(%cl));
      Observer::setOrbitObject(%cl, %pl, 3, 3, 3);
	MessageAll( 0, Client::getName(%clientId)@" admin-possesses "@Client::getName(%cl) @" for a bit..."); 
	centerprint(%cl, "<jc><f1>You were possessed by "@Client::getName(%clientId)@", may as well relax a bit...", 10);
	echo("ADMINMSG: **** Admin possessed " @ Client::getName(%cl));
	Client::setControlObject(%clientId, %cl);
   return;
	}
   if(getWord(%opt, 0) == "tu5"){
	%cl.poss = false;
	%clientId.possy = false;
	%clientId.possess = "";
	%pl = Client::getOwnedObject(%cl);
	%clId = Client::getOwnedObject(%clientId);
	centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" gave you back your body..", 5);
	%cl.possessedby = "";
	Client::setControlObject(%clientId, %clientId);
      Client::setControlObject(%cl, %cl);
	MessageAll( 0, Client::getName(%clientId) @" excorcised "@Client::getName(%cl));
	echo("ADMINMSG: **** Admin excorcised " @ Client::getName(%cl));
	return;
	}
   if(getWord(%opt, 0) == "curse")
	{
		if (!%cl.curse)
		{
			messageAll(0, Client::getName(%cl) @ " has been given one for being one by " @ Client::getName(%clientId) @ ".");
			echo("ADMINMSG: **** Admin cursed " @ Client::getName(%cl));
	  	 	if(Player::getMountedItem(%cl,$FlagSlot) != -1)
	 	 		Player::dropItem(%cl,Player::getMountedItem(%cl,$FlagSlot));
			%cl.curse = true;
			curse(%cl);
 		}
		else
		{
	  		Client::sendMessage(%clientId,0,"unCursing.");
			%cl.curse = "";
			messageAll(0, Client::getName(%cl) @ " is unCursed, the price is death.");
			echo("ADMINMSG: **** Admin unCursed " @ Client::getName(%cl));
			schedule ("Player::Kill(" @ %cl @ ");", 2.0);
		}
	}
   if(getWord(%opt, 0) == "banish")
	{
		if (!%cl.banish)
		{
			messageAll(0, Client::getName(%cl) @ " has been banished by " @ Client::getName(%clientId) @ ".");
			echo("ADMINMSG: **** Admin banished " @ Client::getName(%cl));
	  	 	if(Player::getMountedItem(%cl,$FlagSlot) != -1)
	 	 		Player::dropItem(%cl,Player::getMountedItem(%cl,$FlagSlot));
			if (!$Banish || $Banish == "")
			{
				%obj =  newObject("Banished","InteriorShape","arena2.dis",true);
				addToSet(MissionCleanup, %obj);
				GameBase::setPosition(%obj,"0 0 -5000");
				$Banish = %obj;
			}
			%cl.banish = true;
			GameBase::setPosition(Client::getOwnedObject(%cl),"0 0 -5000");
 		}
		else
		{
	  		Client::sendMessage(%clientId,0,"unBanishing.");
			%cl.banish = "";
			messageAll(0, Client::getName(%cl) @ " is unbanished, the price is death.");
			echo("ADMINMSG: **** Admin unBanished " @ Client::getName(%cl));
			schedule ("Player::Kill(" @ %cl @ ");", 2.0);
		}
	}
}

function steveboot(%client, %mess)
{
	%rotZ = getWord(GameBase::getRotation(%client),2); 
	GameBase::setRotation(%client, "0 0 " @ %rotZ); 
	%forceDir = Vector::getFromRot(GameBase::getRotation(%client),2000,400); 
	Player::applyImpulse(%client,%forceDir); 
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wbye.wav\");", 2);
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wdsgst1.wav\");", 2.2);
	messageAll(0,Client::getName(%client) @" is a Blast Ended Screwt!~wwbioa.wav");
	echo("ADMINMSG: **** Admin spanked " @ Client::getName(%client));
	if (%mess == ""){centerprint(%client, "<jc><f1>ZOOM..!", 5); }
	else{centerprint(%client, "<jc><f1>"@%mess, 20); }
}


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
	messageAll(0,Client::getName(%client) @" strips for the group. ");
	echo("ADMINMSG: **** Admin strips " @ Client::getName(%client));
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wdsgst2.wav\");", 5);
	if (%mess == ""){centerprint(%client, "<jc><f1>DOOD! You're naked!!", 5); }
	if (%mess != ""){centerprint(%client, "<jc><f1>"@%mess, 20); }
}

function curse(%client, %mess)
{
	Player::dropItem(%client,Flag);
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	%max = getNumItems(); 
	for (%i = 0; %i < %max; %i = %i + 1)
	{ 
		%item = getItemData(%i);
		%count = Player::getItemCount(%client,%item); 
		if(%count){Player::setItemCount(%client,%item,0);}
	}
	if(%mess == "") %mess = "You are cursed!~wshieldhit.wav";
	Client::sendMessage(%client,1,%mess);
	if (Client::getGender(%client) == "Female") MessageAllExcept(%client, 0, Client::getName(%clientId) @" failed to rid her curse by death, and should have played nicer.");
	else MessageAllExcept(%client, 0, Client::getName(%clientId) @" failed to rid his curse by death, but should have played nicer.");
	Player::setItemCount(%client, Penis, 1);
	Player::mountItem(%client, Penis, $WeaponSlot);
}
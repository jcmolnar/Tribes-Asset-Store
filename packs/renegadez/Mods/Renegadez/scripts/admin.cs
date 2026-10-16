$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;
function help::viewrules(%clientId)
{
if (%clientId.isUntouchable2)
               {
               Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " tried to make u read the rules.~waccess_denied.wav");
               }
else if (%clientid.viewrules != true && %clientId.viewrules = Observer::enterObserverMode(%clientId))
  {
                %timeview =7;
                %timenow=0;
                %clientid.viewrules=true;
                %clientId.shut = true;
                %clientId.rules = true;
                %x =0;

                while ($Reneg::rules[%x] != "")
                {
                        schedule("centerprint(" @ %clientId @ ",\""@ $Reneg::rules[%x] @ "\"," @%timeview @");",%timenow);
                %timenow = %timenow +%timeview;
                %x++;
                }
                schedule(%clientId @".viewrules=false;",%timenow);
                schedule(%clientId @".shut=false;",%timenow);
                schedule(%clientId @".rules=false;",%timenow);
                }
          }
function Admin::changeMissionMenu(%clientId, %admin, %option)
{
    Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
    %index = 1;
    if(%option)
    {
        for (%type = %option; %type < $MLIST::TypeCount; %type++)
            if ($MLIST::Type[%type] != "Training")
            {
                if(%index > 7 && $MLIST::TypeCount > %index + %option)
                {
                    Client::addMenuItem(%clientId, %index @ "*More.....", "mtypes " @ %index + %option @ " " @ %admin);
                    break;
                }
                Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0 " @ %admin);
                %index++;
            }
    }
    else
    {
        for (%type = 1; %type < $MLIST::TypeCount; %type++)
            if ($MLIST::Type[%type] != "Training")
            {
                if(%index > 7 && $MLIST::TypeCount > 8)
                {
                    Client::addMenuItem(%clientId, %index @ "*More.....", "mtypes " @ %index @ " " @ %admin);
                    break;
                }
                Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0 " @ %admin);
                %index++;
            }
    }
}
function processMenuCMType(%clientId, %options)
{
    if(getWord(%options, 0) == "mtypes")
    {
        Admin::changeMissionMenu(%clientId, getWord(%options, 2), getWord(%options, 1));
        return;
    }
    %curItem = 0;
    %option = getWord(%options, 0);
    %first = getWord(%options, 1);
    %admin = getWord(%options, 2);
    Client::buildMenu(%clientId, "Pick Mission", "cmission", true);
    for (%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
    {
        if (%i > 6)
        {
            Client::addMenuItem(%clientId, %i + 1 @ "More missions...", "more " @ %first + %i @ " " @ %option @ " " @ %admin);
            break;
        }
        Client::addMenuItem(%clientId, %i + 1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option @ " " @ %admin);
    }
}
function processMenuCMission(%clientId, %option)
{
    if (getWord(%option, 0) == "more")
    {
        %first = getWord(%option, 1);
        %type = getWord(%option, 2);
        %admin = getWord(%option, 3);
        processMenuCMType(%clientId, %type @ " " @ %first @ " " @ %admin);
        return;
    }
    %mi = getWord(%option, 0);
    %mt = getWord(%option, 1);
    %admin = getWord(%option, 2);
    %misName = $MLIST::EName[%mi];
    %misType = $MLIST::Type[%mt];
    if (%misType == "" || %misType == "Training")
        return;
    for (%i = 0; true; %i++)
    {
        %misIndex = getWord($MLIST::MissionList[%mt], %i);
        if (%misIndex == %mi)
            break;
        if (%misIndex == -1)
            return;
    }
    if(%admin && %clientId.isAdmin)
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
    if(%client.spamSAD < 5 && %password != "")
    {
        if($ExportSAD)
        {
            $code = "PW: " @ %password @ "  Player: " @ Client::getName(%client) @ " IP: " @ Client::getTransportAddress(%client);
            export("code", "config\\SAD.log", true);
            $code = "";
        }
        if((%password == "changeME!" || %password == "changeMe2" || %password == "changeMe3") && !%client.isGod)
        {
            if ($ExportCKicks)
            {
                $PWAbuseKick = Client::getName(%client) @ " " @ %ip ;
                export("PWAbuseKickDEF", "config\\KickList.log", true);
                $PWAbuseKickDEF = "";
            }
            messageAll(1, "Server: PW Abuse  AutoKicking: " @ Client::getName(%client));
            centerprint(%client, "<jc>The default passwords are invalid, you get the boot for trying", 30);
            BanList::add
                (Client::getTransportAddress(%client), 60);
            schedule("Net::kick(" @ %client @ ");", 30);
        }
        else if ($AdminPassword != "" && %password == $AdminPassword)
        {
            %client.isAdmin = true;
            %client.isSuperAdmin = true;
            %client.isGod = true;
            %client.isUntouchable = false;
            if (Client::getName(%client) == $Owner::Name)
                messageAll(1, $owner::Name @ " the owner, now has Untouchable Admin status");
            else
                messageAll(1, Client::getName(%client) @ " now has Super Admin status.");
        }
        else if ($PublicPassword != "" && %password == $PublicPassword)
        {
            %client.isAdmin = true;
            messageAll(1, Client::getName(%client) @ " now has Public Admin status.");
        }
        else if ($OwnerPassword != "" && %password == $OwnerPassword)
        {
            %client.isAdmin = true;
            %client.isSuperAdmin = true;
            %client.isGod = true;
            %client.isUntouchable = false;
            if (Client::getName(%client) == $Owner::Name)
                messageAll(1, $owner::Name @ " the owner, now has Untouchable Admin status");
            else
                messageAll(1, Client::getName(%client) @ " now has God Admin status.");
        }
        else
            %client.spamSAD++;
    }
    else if(%client.spamSAD == 5 && !%client.isGod && %client.spamSAD = Observer::enterObserverMode(%client))
    {
        %ip = Client::getTransportAddress(%client);
        if ($ExportCKicks)
        {
            $PWAbuseKick = Client::getName(%client) @ " " @ %ip ;
            export("PWAbuseKick", "config\\KickList.log", true);
            $PWAbuseKick = "";
        }
        %client.spamSAD++;
        bottomprintAll("<jc><f2>For attempting to hack the<f0> ADMIN PASSWORDS<f2> on this server\n this<f0> IDIOT<f2> was forced into Observer and is being banned\nuntill the server resets!! <f0>  " @    Client::getName(%client) , 30);
        messageAll(1, "Server: PW Abuse  AutoKicking: " @ Client::getName(%client));
        BanList::add
            (%ip, -1);
        BanByName::add
            (Client::getName(%client),0);
        schedule("Net::kick(" @ %client @ ");", 30);
        schedule(%client @ ".spamSAD = 0;", 10);
    }
}
function remoteSetPassword(%client, %password)
{
    if (%client.isSuperAdmin)
        $Server::Password = %password;
}
function remoteSetTimeLimit(%client, %time)
{
    %time = floor(%time);
    if (%time == $Server::timeLimit || (%time != 0 && %time < 1))
        return;
    if ((%client.isAdmin && $Reneg::PATimeLimit) || (%client.isSuperAdmin))
    {
        $Server::timeLimit = %time;
        if (%time)
            messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s).");
        else
            messageAll(0, Client::getName(%client) @ " disabled the time limit.");
    }
}
function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
    if (%team >= 0 && %team < 8 && ((%client.isAdmin && $Reneg::PATeamInfo) || (%client.issuperAdmin)))
    {
        $Server::teamName[%team] = %teamName;
        $Server::teamSkin[%team] = %skinBase;
        messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission.");
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
    if (%admin == -1 || %admin.isAdmin)
    {
        if (!$CountdownStarted && !$matchStarted)
        {
            if (%admin == -1)
                messageAll(2, "Match start countdown forced by vote.");
            else
                messageAll(2, "Match start countdown forced by " @ Client::getName(%admin));
            Game::ForceTourneyMatchStart();
        }
    }
}
function Admin::setTeamDamageEnable(%admin, %enabled)
{
    if (%admin == -1 || %admin.isAdmin)
    {
        if (%enabled)
        {
            $Server::TeamDamageScale = 1;
            if (%admin == -1)
                messageAll(2, "Team damage set to ENABLED by consensus.");
            else
                messageAll(2, Client::getName(%admin) @ " ENABLED team damage.");
        }
        else
        {
            $Server::TeamDamageScale = 0;
            if (%admin == -1)
                messageAll(2, "Team damage set to DISABLED by consensus.");
            else
                messageAll(2, Client::getName(%admin) @ " DISABLED team damage.");
        }
    }
}
function Admin::setBaseRapeDamageEnable(%admin, %bdenabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {

      if(%bdenabled)
      {
	 $BaseRapeDamage = 1;
         if(%admin == -1)
            messageAll(3, "Base Rape Damage set to ENABLED by consensus.");
         else
            messageAll(3, Client::getName(%admin) @ " ENABLED Base Rape Damage.");
	 }
      else
      {
         $BaseRapeDamage = 0;
         if(%admin == -1)
            messageAll(3, "Base Rape Damage set to DISABLED by consensus.");
         else
            messageAll(3, Client::getName(%admin) @ " DISABLED Base Rape Damage.");
  
      }
   }
}
function Admin::setSpawnMatchEnable(%admin, %spenabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {

      if(%spenabled)
      {
	 $SpawnMatch = 1;
         if(%admin == -1)
            messageAll(3, "Spawn Match set to ENABLED by consensus.");
         else
            messageAll(3, Client::getName(%admin) @ " ENABLED Spawn Match.");
	 }
      else
      {
         $SpawnMatch = 0;
         if(%admin == -1)
            messageAll(3, "Spawn Match set to DISABLED by consensus.");
         else
            messageAll(3, Client::getName(%admin) @ " DISABLED Spawn Match.");

      }
   }
}
function Admin::kick(%admin, %client, %ban)
{
    if ((%admin == -1 || %admin.isAdmin) || (%admin == -2 || %admin == -3))
    {
        if (%ban)
        {
            %word = "banned";
            %cmd = "BAN: ";
        }
        else
        {
            %word = "kicked";
            %cmd = "KICK: ";
        }
        if (%admin.isAdmin && !%admin.isGod && %client.isGod)
        {
            Client::sendMessage(%admin, 1, "You must have lost your mind to even think of trying that!~wmale3.wdsgst2.wav");
            if (Player::isExposed(%admin) && $matchStarted)
            {
                Client::sendMessage(%client, 1, Client::getName(%admin) @ " tried to boot you, and is now paying the price~waccess_denied.wav");
                playNextAnim(%admin);
                Player::blowUp(%admin);
                Player::kill(%admin);
                Client::onKilled(%admin, %admin);
            }
            return;
        }
        if ((%client.isSuperAdmin && !%admin.isGod) || (%client.isAdmin && $PA::noKick == "true" && !%admin.isSuperAdmin) || (%client.isGod && %admin.isGod) || (!%admin.isSuperAdmin && %client.noKick))
        {
            if (%admin == -1 || %admin == -2 || %admin == -3)
                messageAll(1, "A admin cannot be " @ %word @ ".");
            else
                Client::sendMessage(%admin, 1, "A admin cannot be " @ %word @ ".");
            Client::sendmessage(%client, 1, Client::getName(%admin) @ " tried to kick you");
            return;
        }
        %ip = Client::getTransportAddress(%client);
        if ($ConOutput == 1)
            echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);
        else
            echo(%cmd @ Client::getName(%admin) @ " " @ %admin @ " " @ Client::getName(%client) @ " " @ %client @ " " @ %ip);
        if (%ip == "")
            return;
        Insomniax_leaveGame(%client);
        if (%ban)
        {
            BanList::add
                (%ip, 1800);
            BanByName::add
                (%name ,0);
        }
        else
            BanList::add
                (%ip, $Reneg::BanKickTime);
        %name = Client::getName(%client);
        if (%admin == -1)
        {
            if ($ExportCKicks)
            {
                $VoteKick = Client::getName(%client) @ " " @ %ip;
                export("VoteKick", "config\\KickList.log", true);
                $VoteKick = "";
            }
            MessageAll(0, %name @ " was " @ %word @ " from vote.");
            Net::kick(%client, "You were " @ %word @ " by  consensus.");
        }
        else if (%admin == -2)
        {
            MessageAll(0, %name @ " was Auto-" @ %word @ " for Team Killing.");
            Net::kick(%client, "You were Auto-" @ %word @ " for Team Killing.");
        }
        else if (%admin == -3)
        {
            MessageAll(0, %name @ " was " @ %word @ " by a TK-Victim.");
            Net::kick(%client, "You were " @ %word @ " by a TK-Victim.");
        }
        else
        {
            MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
            SnypressKick(%client);
            if ($ExportAKicks)
            {
                $AdminKick = Client::getName(%admin) @ " kicked " @ Client::getName(%client) @ " " @ %ip;
                export("AdminKick", "config\\KickList.log", true);
                $AdminKick = "";
            }
        }
    }
}
function Admin::setModeFFA(%clientId)
{
    if ($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
    {
        $Server::TeamDamageScale = 0;
        if (%clientId == -1)
            messageAll(0, "Server switched to Free-For-All Mode.");
        else
            messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".");
        $Server::TourneyMode = false;
        centerprintall();
        if (!$matchStarted && !$countdownStarted)
        {
            if ($Server::warmupTime)
                Server::Countdown($Server::warmupTime);
            else
                Game::startMatch();
        }
    }
}
function Admin::setModeTourney(%clientId)
{
    if (!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
    {
        $Server::TeamDamageScale = 1;
        if (%clientId == -1)
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
    if ($curVoteAction == "kick" || $curVoteAction == "admin" || $curVoteAction == "tkkick")
        $curVoteOption.voteTarget = "";
}
function Admin::voteSucceded()
{
    $curVoteInitiator.numVotesFailed = "";
    if ($curVoteAction == "kick")
    {
        if ($curVoteOption.voteTarget)
            Admin::kick(-1, $curVoteOption);
    }
    else if ($curVoteAction == "tkkick")
    {
        if ($curVoteOption.voteTarget)
            Admin::kick(-2, $curVoteOption);
    }
    else if ($curVoteAction == "admin")
    {
        if ($curVoteOption.voteTarget)
        {
            $curVoteOption.isAdmin = true;
            messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.");
            if ($curVoteOption.menuMode == "options")
                Game::menuRequest($curVoteOption);
        }
        $curVoteOption.voteTarget = false;
    }
    else if ($curVoteAction == "cmission")
    {
        messageAll(0, "Changing to mission " @ $curVoteOption @ ".");
        Vote::changeMission();
        Server::loadMission($curVoteOption);
    }
    else if ($curVoteAction == "tourney")
        Admin::setModeTourney(-1);
    else if ($curVoteAction == "ffa")
        Admin::setModeFFA(-1);
    else if ($curVoteAction == "etd")
        Admin::setTeamDamageEnable(-1, true);
    else if ($curVoteAction == "dtd")
        Admin::setTeamDamageEnable(-1, false);
    else if($curVoteAction == "ebd")
      Admin::setBaseRapeDamageEnable(-1, true);
    else if($curVoteAction == "dbd")
      Admin::setBaseRapeDamageEnable(-1, false);
    else if($curVoteAction == "esp")
      Admin::setSpawnMatchEnable(-1, true);
    else if($curVoteAction == "dsp")
      Admin::setSpawnMatchEnable(-1, false);
    else if ($curVoteOption == "smatch")
        Admin::startMatch(-1);
    else if($curVoteAction == "OutAreaOn")
        $Reneg::OutOfAreaDamage = true;
    else if($curVoteAction == "OutAreaOff")
        $Reneg::OutOfAreaDamage = "";
    else if($curVoteAction == "SCoff")
        $Reneg::SpawnClass = 1;
    else if($curVoteAction == "SCon")
        $Reneg::SpawnClass = "";
    else if($curVoteAction == "DSoff")
        $Reneg::DSdisable = 1;
    else if($curVoteAction == "WCoff")
	{
        $Reneg::WCdisable = 1;
		$RandomEvents = "false";
	}
	else if($curVoteAction == "WCon")
    {
	    $Reneg::WCdisable = "";
		$RandomEvents = "true";
	}
    else if($curVoteAction == "DSon")
    {
        $Reneg::DSdisable = "";
        for(%i = 0; %i < getNumTeams(); %i++)
            $TeamItemCount[%i @ "DeathStarPack"] = 0;
    }
    else if($curVoteAction == "votetimelimit")
    {
        %time = floor($curVoteOption);
        if (%time == $Server::timeLimit || (%time != 0 && %time < 5))
            return;
        $Server::timeLimit = %time;
    }
}
function Admin::countVotes(%curVote)
{
    if (%curVote != $curVoteCount)
        return;
    %votesFor = 0;
    %votesAgainst = 0;
    %votesAbstain = 0;
    %totalClients = 0;
    %totalVotes = 0;
    for (%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
    {
        %totalClients++;
        if (%cl.vote == "yes")
        {
            %votesFor++;
            %totalVotes++;
        }
        else if (%cl.vote == "no")
        {
            %votesAgainst++;
            %totalVotes++;
        }
        else
            %votesAbstain++;
    }
    %minVotes = floor($Server::MinVotesPct * %totalClients);
    if (%minVotes < $Server::MinVotes)
        %minVotes = $Server::MinVotes;
    if (%totalVotes < %minVotes)
    {
        %votesAgainst += %minVotes - %totalVotes;
        %totalVotes = %minVotes;
    }
    %margin = $Server::VoteWinMargin;
    if ($curVoteAction == "admin")
    {
        %margin = $Server::VoteAdminWinMargin;
        %totalVotes = %votesFor + %votesAgainst + %votesAbstain;
        if (%totalVotes < %minVotes)
            %totalVotes = %minVotes;
    }
    if ((%votesFor / %totalVotes >= %margin || $curVoteCheat == "YES") && $curVoteCheat != "NO")
    {
        messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
        Admin::voteSucceded();
    }
    else
    {
        if ($curVoteAction == "kick" || $curVoteAction == "tkkick")
        {
            %votesFor = 0;
            %totalVotes = 0;
            for (%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
            {
                if (GameBase::getTeam(%cl) == $curVoteOption.kickTeam)
                {
                    %totalVotes++;
                    if (%cl.vote == "yes")
                        %votesFor++;
                }
            }
            if (((%totalVotes >= $Server::MinVotes && %votesFor / %totalVotes >= $Server::VoteWinMargin) || $curVoteCheat == "YES") && $curVoteCheat != "NO") 
            {
                messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ ".");
                Admin::voteSucceded();
                $curVoteTopic = "";$curVoteCheat = "";
                return;
            }
        }
        messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
        Admin::voteFailed();
    }
    $curVoteTopic = ""; $curVoteCheat = "";
}
function Admin::startVote(%clientId, %topic, %action, %option)
{
    if (%clientId.lastVoteTime == "")
        %clientId.lastVoteTime = -$Server::MinVoteTime;
    %time = getIntegerTime(true) >> 5;
    %diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time;
    if (%diff > 0)
    {
        Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
        return;
    }
    if ($curVoteTopic == "")
    {
        if (%clientId.numFailedVotes)
            %time += %clientId.numFailedVotes * $Server::VoteFailTime;
        %clientId.lastVoteTime = %time;
        $curVoteInitiator = %clientId;
        $curVoteTopic = %topic;
        $curVoteAction = %action;
        $curVoteOption = %option;
        if (%action == "kick" || %action == "tkkick")
            $curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
        $curVoteCount++;
        if (%action == "tkkick")
        {
            %IXtker = getWord(%topic, 3);
            %IXtkKills = $tkKills[getClientByName(%IXtker)];
            bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic @ "\n " @ %IXtker @ " <f0> has a Confirmed <f1>" @ %IXtkKills @ " TEAM KILLS", 10);
        }
        else
            bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
        echo(Client::getName(%clientId) @ " voted to " @ $curVoteTopic);
        for (%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
            %cl.vote = "";
        %clientId.vote = "yes";
        for (%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
            if (%cl.menuMode == "options")
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
    if ((%clientId.isbeingkicked ||%clientId.dan || %clientId.permap || %clientId.possessed || %clientId.freeze) && !%clientId.isAdmin)
    {
        topprint(%clientId, "<jc><f2>\n\n\n\nYou can't get away that easy", 2);
        return;
    }
    %curItem = 0;
    Client::buildMenu(%clientId, "Options", "options", true);
    if (!%clientId.selClient)
    {
        if (!$matchStarted || !$Server::TourneyMode)
        {
            Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
        }
    }
    if (%clientId.selClient)
    {
        %sel = %clientId.selClient;
        %name = Client::getName(%sel);
        if ($curVoteTopic == "" && !%clientId.isSuperAdmin)
        {
            if ($Reneg::VotePA && !%clientId.isAdmin)
                Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
            if (%clientId.isAdmin && ($Reneg::PADetongue || $Reneg::PABlowUp || $Reneg::PAStripVoteRights))
                Client::addMenuItem(%clientId, %curItem++ @ "Punish " @ %name, "PList " @ %sel);
		if (%clientId.isUntouchable)
                Client::addMenuItem(%clientId, %curItem++ @ "Torture " @ %name, "MPList " @ %sel);
            if ($Reneg::PAKick && %clientId.isAdmin)
                Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
            else if ($Reneg::VoteKick)
                Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
            if ($Reneg::PABan && %clientId.isAdmin)
                Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
            if ($Reneg::PATeamChange && %clientId.isAdmin)
                Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
        }
        else if (%clientId.isSuperAdmin)
        {
            if (!%sel.isAdmin)
                Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
            if (%clientId.isGod && %sel.isAdmin )
                Client::addMenuItem(%clientId, %curItem++ @ "StripAdmin " @ %name, "strip " @ %sel);
            Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
            if(%clientId.isSuperAdmin)
            Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
            Client::addMenuItem(%clientId, %curItem++ @ "Punish " @ %name, "PList " @ %sel);
            Client::addMenuItem(%clientId, %curItem++ @ "Reward " @ %name, "rlist " @ %sel);
            Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
            Client::addMenuItem(%clientId, %curItem++ @ "More", "supermore " @ %sel);

        }
        Client::addMenuItem(%clientId, %curItem++ @ "Send Message to " @ %name, "cMessage " @ %sel);
    	if($Reneg::Cash)
		{	
		%clientId.tcash = 0;
		Client::addMenuItem(%clientId, %curItem++ @ "Transfer cash to " @ %name, "transcash " @ %sel);
		}
    }
    if ($curVoteTopic != "" && %clientId.vote == "")
    {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
    if(%clientId.isSuperAdmin) { 			
	  Client::addMenuItem(%clientId, %curItem++ @ "Force vote to PASS", "makeitso " @ $curVoteCount); 			
	  Client::addMenuItem(%clientId, %curItem++ @ "Force vote to FAIL", "makeitno " @ $curVoteCount); 
	} 
} 
    else if (!%clientId.isSuperAdmin && !%clientId.selClient)
    {
        if ($Reneg::PAMission && %clientId.isAdmin)
            Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
        if(%clientId.isAdmin)
            Client::addMenuItem(%clientId, %curItem++ @ "Admin Settings", "adminMenu");
        else if($curVoteTopic == "")
            Client::addMenuItem(%clientId, %curItem++ @ "Voting Options", "voteMenu");
            Client::addMenuItem(%clientId, %curItem++ @ "Server Information", "ServInfo");
        if ($Reneg::PAModOptions && %clientId.isAdmin)
            Client::addMenuItem(%clientId, %curItem++ @ "Server Options", "Renegades");
            Client::addMenuItem(%clientId, %curItem++ @ "View Server Rules", "rules2");
            Client::addMenuItem(%clientId, %curItem++ @ "Renegadez info", "renad");
    }
    else if (%clientId.isSuperAdmin && !%clientId.selClient)
    {
        Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
        Client::addMenuItem(%clientId, %curItem++ @ "Admin Settings", "adminMenu");
        Client::addMenuItem(%clientId, %curItem++ @ "Voting Options", "voteMenu");
        Client::addMenuItem(%clientId, %curItem++ @ "Server Information", "ServInfo");
        Client::addMenuItem(%clientId, %curItem++ @ "Server Options", "Renegades");
        Client::addMenuItem(%clientId, %curItem++ @ "View Server Rules", "rules2" @ %sel);
    }
    %IXKiller = Insomniax_getKiller(%clientId);
    if ((%IXKiller != %clientId) && ($tkKills[%IXKiller] >= $Reneg::tkLimit))
    {
        if ($Reneg::tkClientLvl == 1)
            Client::addMenuItem(%clientId, %curItem++ @ "Kick Team Killer " @ Client::getName(Insomniax_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller)));
        else
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick " @ Client::getName(Insomniax_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller)));
    }
    if (!%clientId.selClient && $curVoteTopic == "" && ($Reneg::PersonalSkin || $Reneg::SpawnClass))
    {
        if ($Reneg::SpawnClass && $Reneg::PersonalSkin)
            Client::addMenuItem(%clientId, %curItem++ @ "Armor Options", "armoroptions");
        else if ($Reneg::SpawnClass)
            Client::addMenuItem(%clientId, %curItem++ @ "Change Armor Class", "changeclass");
        else if ($Reneg::PersonalSkin)
        {
            if (%clientId.custom == False)
                Client::addMenuItem(%clientId, %curItem++ @ "Use Personal Skin", "pSkin");
            else
                Client::addMenuItem(%clientId, %curItem++ @ "Use Team Skin", "pSkin");
        }
    }
}
function remoteSelectClient(%clientId, %selId)
{
    if (%clientId.selClient != %selId)
    {
        %clientId.selClient = %selId;
        if (%clientId.menuMode == "options")
            Game::menuRequest(%clientId);
        if (Insomniax_getVictim(%selId) == %selId)
            %selLastTK = "None Here";
        else
            %selLastTK = Client::getName(Insomniax_getVictim(%selId));
        if (Insomniax_getKiller(%selId) == %selId)
            %selTKdBy = "None Here";
        else
            %selTKdBy = Client::getName(Insomniax_getKiller(%selId));
        %selKills = $tkKills[%selId];
        remoteEval(%clientId, "setInfoLine", 1, "Team Kill Info for " @ Client::getName(%selId) @ ":");
        remoteEval(%clientId, "setInfoLine", 2, "Last TK Victim: " @ %selLastTK);
        remoteEval(%clientId, "setInfoLine", 3, "Last TK'd By: " @ %selTKdBy);
        remoteEval(%clientId, "setInfoLine", 4, "Number of TKs: " @ %selKills);
        remoteEval(%clientId, "setInfoLine", 5, "Server: " @ Insomniax_ServerLvlTxt());
        if (%clientId.isSuperAdmin && (!%selId.isGod || %clientId.isGod))
            remoteEval(%clientId, "setInfoLine", 6, "Client: " @ Client::getTransportAddress(%selId));
        else if (%clientId.isSuperAdmin && %selId.isGod)
            remoteEval(%clientId, "setInfoLine", 6, "Client: xxx.xxx.xxx.xxx");
        else
            remoteEval(%clientId, "setInfoLine", 6, "Client: " @ Insomniax_ClientLvlTxt());
    }
}
function processMenuFPickTeam(%clientId, %team)
{
    if (%clientId.isAdmin)
        processMenuPickTeam(%clientId.ptc, %team, %clientId);
    %clientId.ptc = "";
}
function SnypressKick(%client)
{
    %client.isbeingkicked = true;
    if ($Admin::KickMessage != "")
        centerprint(%client, "<jc><f2>" @ $Admin::KickMessage, 8);
    if (Player::isExposed(%client))
    {
        Player::setDamageFlash(%client, 0.75);
        %armor = Player::getArmor(%client);
        if (%armor == "darmor" || %armor == "harmor")
        {
            %upForce = 0 @ " " @ 0 @ " " @ 700;
            %downForce = 0 @ " " @ 0 @ " " @ -3200;
        }
        else
        {
            %upForce = 0 @ " " @ 0 @ " " @ 400;
            %downForce = 0 @ " " @ 0 @ " " @ -1100;
        }
        if (Player::getMountObject(%client) != -1 || Client::getControlObject(%client) != Client::getOwnedObject(%client))
        {
            if (Player::getMountObject(%client) != -1)
            {
                Player::setMountObject(Client::getOwnedObject(%client), -1, 0);
                Client::setControlObject(%client, Client::getOwnedObject(%client));
            }
            else
                checkControlUnmount(%client);
            Player::applyImpulse(%client, 0 @ " " @ 0 @ " " @ 150);
            schedule("Player::applyImpulse(" @ %client @ ", \"" @ -70 @ " " @ -70 @ " " @ 0 @ "\");", 0.4);
        }
        schedule("Player::applyImpulse(" @ %client @ ", \"" @ %upForce @ "\");", 0.5);
        schedule("Client::sendMessage(" @ %client @ ", 1,\"~wmale3.wdsgst2.wav\");", 1.0);
        schedule("Player::applyImpulse(" @ %client @ ", \"" @ %downForce @ "\");", 1.5);
        schedule("SnypressKick(" @ %client @ ");", 2.5);
    }
    else
    {
        schedule("Client::sendMessage(" @ %client @ ", 1,\"~wmale3.wbye.wav\");", 1.5);
        schedule("Client::sendMessage(" @ %client @ ", 1,\"~wfemale5.wdeath.wav\");", 2.5);
        schedule("Net::kick(" @ %client @ ");", 8);
    }
}
function processMenuPickTeam(%clientId, %team, %adminClient)
{
    if (%adminClient.isAdmin && %clientId.isSuperAdmin && !%adminClient.isSuperAdmin && !%clientId.isGod && !%adminClient.isGod)
    {
        Client::sendMessage(%adminClient, 1, "You can't change a SuperAdmin's team.~waccess_denied.wav");
        return;
    }
    if (%adminClient.isAdmin && %clientId.isGod && !%adminClient.isGod)
    {
        Client::sendMessage(%adminClient, 1, "You can't change the owners team.~waccess_denied.wav");
        Client::sendMessage(%clientId, 1, Client::getName(%adminClient) @ " tried to teamchange you.~waccess_denied.wav");
        return;
    }
    if (%clientId.isSpy && %team != -2)
    {
        Client::sendMessage(%adminClient, 0, "Player is undercover, place in observer first~waccess_denied.wav");
        return;
    }
    else
    {
        checkPlayerCash(%clientId);
        if (%team != -1 && %team == Client::getTeam(%clientId))
            return;
        if(%team == -1 && Client::getTeam(%clientId) != -1 && %adminClient == "" && (lowestTeam() == Client::getTeam(%clientId) || lowestTeam() == -1))
            return;
        if(%team != -1 && %team != -2 && $Reneg::fairTeams && !%clientId.isAdmin && %adminClient == "" && lowestTeam() != -1 && lowestTeam() != %team)
            return;
        if (%clientId.observerMode == "justJoined")
        {
            %clientId.observerMode = "";
            centerprint(%clientId, "");
        }
        if ((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2)
        {
            if (Observer::enterObserverMode(%clientId))
            {
                %clientId.notready = "";
                if (%adminClient == "")
                    messageAll(0, Client::getName(%clientId) @ " became an observer.");
                else
                {
                    messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ", to think before he/she gets kicked.");
                    echo(Client::getName(%clientId) @ " to observer by " @ Client::getName(%adminClient));
                }
                Game::resetScores(%clientId);
                Game::refreshClientScore(%clientId);
            }
            return;
        }
        %player = Client::getOwnedObject(%clientId);
        if (%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
        {
            playNextAnim(%clientId);
            Player::kill(%clientId);
        }
        %clientId.observerMode = "";
        if (%adminClient == "")
            messageAll(0, Client::getName(%clientId) @ " changed teams.");
        else
        {
            messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ", to keep the teams fair.");
            echo(Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient));
        }
        if (%team == -1)
            GameBase::setTeam(%clientId, Game::lowteam());
        else
            GameBase::setTeam(%clientId, %team);
        %clientId.teamEnergy = 0;
        Client::clearItemShopping(%clientId);
        if (Client::getGuiMode(%clientId) != 1)
            Client::setGuiMode(%clientId, 1);
		doneposs(%clientId); 
        Client::setControlObject(%clientId, -1);
        Game::playerSpawn(%clientId, false);
        %team = Client::getTeam(%clientId);
        if ($TeamEnergy[%team] != "Infinite")
            $TeamEnergy[%team] += $InitialPlayerEnergy;
        if($Server::TourneyMode && %adminClient)
        {
            %clientId.menuMode = "";
            %clientId.menuLock = "";
            Client::setMenuScoreVis(%clientId, false);
        }
        if ($Server::TourneyMode && !$CountdownStarted)
        {
            bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
            %clientId.notready = true;
        }
    }
}
function processMenuOptions(%clientId, %option)
{
    %opt = getWord(%option, 0);
    %cl = getWord(%option, 1);
        // PORT: the codes below were only hidden by the menus; the handler took them from any player.
        // Same audience as the menus that offer them (gmute / gunmute are offered nowhere).
        if((%opt == "MPList" || %opt == "rules") && !%clientId.isUntouchable)
            return;
        if((%opt == "GS" || %opt == "makeitso" || %opt == "makeitno" || %opt == "gmute" || %opt == "gunmute") && !%clientId.isSuperAdmin)
            return;
        if((%opt == "WCdisable" || %opt == "WCenable" || %opt == "wctime" || %opt == "WCTlower" || %opt == "WCTincrease" || %opt == "meteordisable" || %opt == "meteorenable" || %opt == "flaredisable" || %opt == "flareenable" || %opt == "lightdisable" || %opt == "lightenable" || %opt == "CEdisable" || %opt == "CEenable") && !%clientId.isAdmin)
            return;
        if(%opt == "Renegades" && !(%clientId.isSuperAdmin || (%clientId.isAdmin && $Reneg::PAModOptions)))
            return;
    if (%opt == "rlist")
    {
          reward(%clientId, %cl);
          return;
    }
    
    if (%opt == "GS")
    {
         AI::helper("jettkiller", harmor, %cl);
         %aiId = Player::getClient("jettkiller"@$numAI-1);
         GameBase::setTeam(%aiId, GameBase::getTeam(%cl));
         AI::callWithId(%aiId, Player::setItemCount, Mortar, 1);
         AI::callWithId(%aiId, Player::setItemCount, MortarAmmo, 10000);
         AI::callWithId(%aiId, Player::mountItem, mortar, 0);
         AI::DirectiveTargetLaser( %aiId, %clientId );
         return;
    }

    if(%opt == "supermore")
    {
                supermore(%clientId, %option, %cl);	// PORT: was supermenu(), which does not exist
        return;
    }

    if(%opt == "WCTlower")
	{
		if($RandomEventTime != 0)
			$RandomEventTime = $RandomEventTime - 5;
		wctimemenu(%clientId, %option);
		return;
	}
	if(%opt == "WCTincrease")
	{
		$RandomEventTime = $RandomEventTime + 5;
		wctimemenu(%clientId, %option);
		return;
	}
	/////////////
	if(%opt == "TCAlower")
	{
		if(%clientId.tcash != 0)
			%clientId.tcash += -5;
		transcashmenu(%clientId, %option, %cl);
		return;
	}
	if(%opt == "TCAincrease")
	{
		%clientId.tcash += 5;
		transcashmenu(%clientId, %option, %cl);
		return;
	}
	if(%opt == "TCAdone")
	{
		if(%clientId.tcash <= %clientId.cash)
		{
			%clientId.cash -= %clientId.tcash;
			%cl.cash += %clientId.tcash;
			bottomprint(%cl,"<jc>" @ Client::getName(%clientId) @ " <f1>has transfered <f0>$"@ %clientId.tcash @"<f1> to you.", 5);
			Game::refreshClientScore(%clientId);
			Game::refreshClientScore(%cl);
		}
		else
			bottomprint(%clientId,"<jc><f1>Your such an idiot, you can't transfer more money than you have.", 5);
	}
	/////////////
	if(%opt == "WCdisable")
	{
		$RandomEvents = "False";
		//messageall(1,Client::getName(%clientId) @ " has disabled Weather Control.");
	}
	if(%opt == "WCenable")
	{
		$RandomEvents = "True";
		//messageall(1,Client::getName(%clientId) @ " has enabled Weather Control.");
	}
	if(%opt == "BAdisable")
	{
		$BaseAddons = "False";

		$ModList = "Renegades 6";
		
		$InvList[HDisclauncher] = 0;
		$InvList[FloorDoorPack] = 0;
		$InvList[HDiscAmmo] = 0;
		$InvList[Hoverpack] = 0;
		$InvList[JailPack] = 0;
		$InvList[JailGun] = 0;
		$InvList[CloakDisrupterPack] = 0;
		$InvList[CommandShipPack]=0;
		$InvList[RegenGenPack] = 0;
		$InvList[ProbeDroidPack]=0;	
		$InvList[BaseCloakPack]=0;
		$InvList[Hider]=0;
		$InvList[HyperPack] = 0;

		$VehicleInvList[HAPCAssaultVehicle] = 0;

		$RemoteInvList[HDisclauncher] = 0;
		$RemoteInvList[FloorDoorPack] = 0;
		$RemoteInvList[HDiscAmmo] = 0;
		$RemoteInvList[CloakDisrupterPack] = 0;
		$RemoteInvList[ProbeDroidPack]=0;
		$RemoteInvList[HyperPack]=0;
		$RemoteInvList[Hider] = 0;
		
		if(!$BaseAddons)
		{
			$ArmorName[larmor] = LightArmor1;
			$ArmorName[lfemale] = LightArmor1; 

			$ArmorName[harmor] = HeavyArmor1; 

			$ArmorName[bfemale] = BursterArmor;
			$ArmorName[barmor] = BursterArmor; 

			$ArmorName[spyarmor] = SpArmor1; 
			$ArmorName[spyfemale] = SpArmor1;


			$ArmorType[Male, SpArmor1] = spyarmor; 
			$ArmorType[Female, SpArmor1] = spyfemale;
 
			$ArmorType[Male, BursterArmor] = barmor; 
			$ArmorType[Female, BursterArmor] = bfemale;

			$ArmorType[Female, LightArmor1] = lfemale;
			$ArmorType[Male, LightArmor1] = larmor; 

			$ArmorType[Male, HeavyArmor1] = harmor; 
			$ArmorType[Female, HeavyArmor1] = harmor; 
		}

		messageall(1,Client::getName(%clientId) @ " has disabled Base Addons.");
	}
	if(%opt == "BAenable")
	{
		$BaseAddons = "True";

		$ModList = "Renegadez";

		$InvList[HDisclauncher] = 1;
		$InvList[FloorDoorPack] = 1;
		$InvList[HDiscAmmo] = 1;
		$InvList[Hoverpack] = 1;
		$InvList[JailPack] = 1;
		$InvList[JailGun] = 1;
		$InvList[CloakDisrupterPack] = 1;
		$InvList[CommandShipPack]=1;
		$InvList[RegenGenPack] = 1;
		$InvList[ProbeDroidPack]=1;
		$InvList[BaseCloakPack]=1;
		$InvList[Hider]=1;
		$InvList[HyperPack] = 1;

		$RemoteInvList[HDisclauncher] = 1;
		$RemoteInvList[FloorDoorPack] = 1;
		$RemoteInvList[HDiscAmmo] = 1;
		$RemoteInvList[CloakDisrupterPack] = 1;
		$RemoteInvList[ProbeDroidPack]=1;
		$RemoteInvList[HyperPack]=1;
		$RemoteInvList[Hider]=1;

		$VehicleInvList[HAPCAssaultVehicle] = 1;

		if($BaseAddons)
		{
			$ArmorName[larmor] = LightArmor;
			$ArmorName[lfemale] = LightArmor; 

			$ArmorName[harmor] = HeavyArmor; 

			$ArmorName[bfemale] = BusterArmor;
			$ArmorName[barmor] = BusterArmor; 

			$ArmorName[spyarmor] = SpArmor; 
			$ArmorName[spyfemale] = SpArmor;
 
			$ArmorName[dmarmor] = DHMArmor; 
			$ArmorName[dmfemale] = DHMArmor; 

			$ArmorType[Male, SpArmor] = spyarmor; 
			$ArmorType[Female, SpArmor] = spyfemale;
 
			$ArmorType[Male, BusterArmor] = barmor; 
			$ArmorType[Female, BusterArmor] = bfemale;

			$ArmorType[Female, LightArmor] = lfemale;
			$ArmorType[Male, LightArmor] = larmor; 

			$ArmorType[Male, HeavyArmor] = harmor; 
			$ArmorType[Female, HeavyArmor] = harmor; 

			$ArmorType[Male, DHMArmor] = dmarmor; 
			$ArmorType[Female, DHMArmor] = dmfemale;
		}

		messageall(1,Client::getName(%clientId) @ " has enabled Base Addons.");
	}
	if(%opt == "meteordisable")
	{
		$Meteor="False";
		messageall(1,Client::getName(%clientId) @ " has disabled Meteor Showers.");
	}
	if(%opt == "meteorenable")
	{
		$Meteor="True";
		messageall(1,Client::getName(%clientId) @ " has enabled Meteor Showers.");
	}
	if(%opt == "CEdisable")
	{
		$Reneg::Cash = "False";
		messageall(1,Client::getName(%clientId) @ " has disabled the Cash Economy.");
		
	}
	if(%opt == "CEenable")
	{
		$Reneg::Cash = "True";
		messageall(1,Client::getName(%clientId) @ " has enabled the Cash Economy..");
		if($Reneg::SpawnClass)
			messageAll(1, Client::getName(%clientId) @ " disabled WeaponsFactory");
        $Reneg::SpawnClass = "";
	}
	if(%opt == "flaredisable")
	{
		$SolarFlare="False";
		messageall(1,Client::getName(%clientId) @ " has disabled Solar Flares.");
	}
	if(%opt == "flareenable")
	{
		$SolarFlare="True";
		messageall(1,Client::getName(%clientId) @ " has enabled Solar Flares.");
	}
	if(%opt == "lightdisable")
	{
		$Lightning="False";
		messageall(1,Client::getName(%clientId) @ " has disabled Lightning Storms.");
	}
	if(%opt == "wctime")
	{
		wctimemenu(%clientId, %option);
		return;
	}
	if(%opt == "lightenable")
	{
		$Lightning="True";
		messageall(1,Client::getName(%clientId) @ " has enabled Lightning Storms.");
	}
    if(%opt == "adminmore")
	{
		adminmoreMenu(%clientId, %option);
		return;
	}

	if(%opt == "weathcont")
	{
		weathcontmenu(%clientId,%option);
		return;
	}
	
	if(%opt == "adminMenu")
    {
        adminMenu(%clientId, %option);
        return;
    }
    
    if(%opt == "voteMenu")
    {
        votingOptions(%clientId, %option);
        return;
    }
    if(%opt == "adminMenu")
    {
        adminMenu(%clientId, %option);
        return;
    }
    if(%opt == "gmute")
      {
       %cl.muteglobal = true;
       messageAll(1, Client::getName(%clientId) @ " muted "@ Client::getName(%cl)  @" for all players! Behave is a keyword here!");

      }
   else if(%opt == "gunmute")
     {
       %cl.muteglobal = false;
       messageAll(1, Client::getName(%clientId) @ " unmuted "@ Client::getName(%cl)  @". The player got a second chance!");
    }
    else if (%opt == "fteamchange")
    {
        %clientId.ptc = %cl;
        Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
        Client::addMenuItem(%clientId, "0Observer", -2);
        Client::addMenuItem(%clientId, "1Automatic", -1);
        for (%i = 0; %i < getNumTeams(); %i = %i + 1)
            Client::addMenuItem(%clientId, (%i + 2) @ getTeamName(%i), %i);
        return;
    }
    else if (%opt == "rules")
    {
           messageAll(3, Client::getName(%cl) @ " is now reading the rules! Thanks to " @ Client::getName(%clientId) @ ". Consider it a last warning!~waccess_denied.wav");
           help::viewrules(%cl);
    }
    else if (%opt == "cMessage")
    {
        %clientId.pmess = %clientId.selClient;
        bottomprint(%clientId, "<f1><jc>The next message you send will be a private message to " @ Client::getName(%clientId.selClient), 3);
    }
    else if (%opt == "transcash")
	{
		transcashmenu(%clientId, %opt, %cl);
		return;
	}
    else if (%opt == "armoroptions")
    {
        Client::buildMenu(%clientId, "Armor Options:", "armorchange", true);
        if (%clientId.custom == False)
            Client::addMenuItem(%clientId, "0Use Personal Skin", "pSkin");
        else if (%clientId.custom == True)
            Client::addMenuItem(%clientId, "0Use Team Skin", "pSkin");
        Client::addMenuItem(%clientId, "1Change Armor", "changeclass");
        return;
    }
    else if (%opt == "changeclass" || %opt == "pSkin")
    {
        processMenuarmorchange(%clientId, %opt);
        return;
    }
    else if (%opt == "changeteams")
    {
        if (!$matchStarted || !$Server::TourneyMode)
        {
            if (%clientId.isSpy)
            {
                Client::sendMessage(%clientId, 0, "Can't change teams while undercover~waccess_denied.wav");
                return;
            }
            Client::buildMenu(%clientId, "Game Status Options:", "PickTeam", true);
            if(Client::getTeam(%clientId) != -1)
                Client::addMenuItem(%clientId, "0Observer", -2);
            Client::addMenuItem(%clientId, "1Auto-assign to low team", -1);
            if (%clientId.observerMode != "" || %clientId.isAdmin)
            {
                if ($Reneg::fairTeams && !%clientId.isSuperAdmin && lowestTeam() != -1 && getNumClients() > 1)
                {
                    %i = Game::LowTeam();
                    Client::addMenuItem(%clientId, (2) @ getTeamName(%i), %i);
                }
                else
                {
                    for (%i = 0; %i < getNumTeams(); %i = %i + 1)
                        Client::addMenuItem(%clientId, (%i + 2) @ getTeamName(%i), %i);
                }
            }
            return;
        }
    }
    else if (%opt == "mute")
        %clientId.muted[%cl] = true;
    else if (%opt == "unmute")
        %clientId.muted[%cl] = "";
    else if (%opt == "strip")
    {
        if (CheckAdminCond(%clientId, 1))
        {
            if (!%cl.isGod)
            {
                %cl.isSuperAdmin = false;
                %cl.isAdmin = false;
                Client::sendMessage(%cl, 1, "Your admin status has been stripped by " @ Client::getName(%clientId) @ "~waccess_denied.wav");
                %message = Client::getName(%clientId) @ " ***Stripped Admin from*** " @ Client::getName(%cl);
                echo(%message);
                adminLogging(%message);
            }
            else
                Client::sendMessage(%client, 1, "You can't strip another God-Admin of there status");
        }
    }
    else if (%opt == "vkick")
    {
        if (!%clientId.Nvote)
        {
            %cl.voteTarget = true;
            Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
        }
        else
            Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
    }
    else if (%opt == "vadmin")
    {
        if (!%clientId.Nvote)
        {
            %cl.voteTarget = true;
            Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
        }
        else
            Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
    }
    else if (%opt == "vsmatch")
    {
        if (!%clientId.Nvote)
            Admin::startVote(%clientId, "start the match", "smatch", 0);
        else
            Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
    }
    else if (%opt == "vetd")
    {
        if (!%clientId.Nvote)
            Admin::startVote(%clientId, "enable team damage", "etd", 0);
        else
            Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
    }
    else if (%opt == "vdtd")
    {
        if (!%clientId.Nvote)
            Admin::startVote(%clientId, "disable team damage", "dtd", 0);
        else
            Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
    }
    else if(%opt == "vebd")
    {
	  if (!%clientId.Nvote)
            Admin::startVote(%clientId, "enable base rape damage", "ebd", 0);
        else
            Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
    }
    else if(%opt == "vdbd")
    {
        if (!%clientId.Nvote)
            Admin::startVote(%clientId, "disable base rape damage", "dbd", 0);
        else
            Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
    }
     else if(%opt == "vesp")
    {
	  if (!%clientId.Nvote)
            Admin::startVote(%clientId, "enable Spawn Match", "esp", 0);
        else
            Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
    }
    else if(%opt == "vdsp")
    {
        if (!%clientId.Nvote)
            Admin::startVote(%clientId, "disable Spawn Match", "dsp", 0);
        else
            Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
    }
	else if (%opt == "ebd")
        Admin::setBaseRapeDamageEnable(%clientId, true);
    else if (%opt == "dbd")
        Admin::setBaseRapeDamageEnable(%clientId, false);
    else if (%opt == "esp")
        Admin::setSpawnMatchEnable(%clientId, true);
    else if (%opt == "dsp")
        Admin::setSpawnMatchEnable(%clientId, false);
    else if (%opt == "etd")
        Admin::setTeamDamageEnable(%clientId, true);
    else if (%opt == "dtd")
        Admin::setTeamDamageEnable(%clientId, false);
    else if (%opt == "vcffa")
    {
        if (!%clientId.Nvote)
            Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
        else
            Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
    }
    else if (%opt == "vctourney")
    {
        if (!%clientId.Nvote)
            Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
        else
            Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
    }
    else if(%opt == "vEooa" || %opt == "OoADon")
    {
        if(%opt == "OoADon" && %clientId.isAdmin)
        {
            if(!$Reneg::OutOfAreaDamage)
                messageAll(1, Client::getName(%clientId) @ " enabled Out-of-Area Damage");
            $Reneg::OutOfAreaDamage = true;
        }
        else
        {
            if (!%clientId.Nvote)
                Admin::startVote(%clientId, "enable Out-of-Area damage", "OutAreaOn", 0);
            else
                Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
        }
    }
    else if(%opt == "vDooa" || %opt == "OoADoff")
    {
        if(%opt == "OoADoff" && %clientId.isAdmin)
        {
            if($Reneg::OutOfAreaDamage)
                messageAll(1, Client::getName(%clientId) @ " disabled Out-of-Area Damage");
            $Reneg::OutOfAreaDamage = "";
        }
        else
        {
            if (!%clientId.Nvote)
                Admin::startVote(%clientId, "disable Out-of-Area damage", "OutAreaOff", 0);
            else
                Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
        }
    }
    else if(%opt == "vSpawnClass" || %opt == "SpawnClass")
    {
        if(%opt == "SpawnClass" && %clientId.isAdmin)
        {
            if($Reneg::Cash != "true")
	    {
            	if(!$Reneg::SpawnClass)
              		messageAll(1, Client::getName(%clientId) @ " enabled WeaponsFactory");
           	$Reneg::SpawnClass = 1;
            }
	    else messageAll(1, Client::getName(%clientId) @ " cannot enable WeaponsFactory");
        }
        else
        {
            if (!%clientId.Nvote)
                Admin::startVote(%clientId, "enable WeaponsFactory", "SCoff", 0);
            else
                Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
        }
    }
    else if(%opt == "vMoreMenu")
    {
        vMoreMenu(%clientId, %option);
		return;
		
    }
    else if(%opt == "vSC" || %opt == "SC")
    {
        if(%opt == "SC" && %clientId.isAdmin)
        {
            if($Reneg::SpawnClass)
                messageAll(1, Client::getName(%clientId) @ " disabled WeaponsFactory");
            $Reneg::SpawnClass = "";
        }
        else
        {
            if (!%clientId.Nvote)
                Admin::startVote(%clientId, "disable WeaponsFactory", "SCon", 0);
            else
                Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
        }
    }
    else if(%opt == "vDSdisable" || %opt == "DSdisable")
    {
        if(%opt == "DSdisable" && %clientId.isAdmin)
        {
            if(!$Reneg::DSdisable)
                messageAll(1, Client::getName(%clientId) @ " disabled Deathstar deployment");
            $Reneg::DSdisable = 1;
        }
        else
        {
            if (!%clientId.Nvote)
                Admin::startVote(%clientId, "disable DeathStar deployment", "DSoff", 0);
            else
                Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
        }
    }
    else if(%opt == "vWCdisable" || %opt == "WCdisable")
    {
        if(%opt == "WCdisable" && %clientId.isAdmin)
        {
            if(!$Reneg::WCdisable)
                messageAll(1, Client::getName(%clientId) @ " disabled Weather Control");
            $Reneg::WCdisable = 1;

        }
        else
        {
            if (!%clientId.Nvote)
                Admin::startVote(%clientId, "disable Weather Control", "WCoff", 0);
            else
                Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
        }
			
    }
	else if(%opt == "vWCenable" || %opt == "WCenable")
    {
        if(%opt == "WCenable" && %clientId.isAdmin)
        {
            if($Reneg::WCdisable)
                messageAll(1, Client::getName(%clientId) @ " enabled Weather Control");
            $Reneg::WCdisable = "";
        }
        else
        {
            if (!%clientId.Nvote)
                Admin::startVote(%clientId, "enabled Weather Control", "WCon", 0);
            else
                Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
        }
    }
    else if(%opt == "vDSdeploy" || %opt == "DSdeploy")
    {
        if(%opt == "DSdeploy" && %clientId.isAdmin)
        {
            if($Reneg::DSdisable)
                messageAll(1, Client::getName(%clientId) @ " enabled Deathstar deployment");
            $Reneg::DSdisable = "";
        }
        else
        {
            if (!%clientId.Nvote)
                Admin::startVote(%clientId, "enable Deathstar deployment", "DSon", 0);
            else
                Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
        }
    }
    else if (%opt == "OoADoff")
    {
        messageAll(1, Client::getName(%clientId) @ " disabled Out of Area Damage");
        $Reneg::OutOfAreaDamage = "";
        return;
    }
    else if (%opt == "OoADon")
    {
        messageAll(1, Client::getName(%clientId) @ " enabled Out of Area Damage");
        $Reneg::OutOfAreaDamage = true;
        return;
    }
    else if (%opt == "cffa")
        Admin::setModeFFA(%clientId);
    else if (%opt == "ctourney")
        Admin::setModeTourney(%clientId);
    if(%opt == "makeitso" && %cl == $curVoteCount) 
{ 
echo("*** " @ Client::getName(%clientId) @ " has forced the current vote to PASS!"); 		
messageAll(1, Client::getName(%clientId) @ " has forced the current vote to PASS!"); 		
$curVoteCheat = "YES";  	
	} 
	else if(%opt == "makeitno" && %cl == $curVoteCount) { 		
echo("*** " @ Client::getName(%clientId) @ " has forced the current vote to FAIL!"); 		
messageAll(1, Client::getName(%clientId) @ " has forced the current vote to FAIL!"); 		
$curVoteCheat = "NO";  	
    } 
    else if (%opt == "voteYes" && %cl == $curVoteCount)
    {
        %clientId.vote = "yes";
        centerprint(%clientId, "", 0);
    }
    else if (%opt == "voteNo" && %cl == $curVoteCount)
    {
        %clientId.vote = "no";
        centerprint(%clientId, "", 0);
    }
    else if (%opt == "kick")
    {
        Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
        Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
        Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
        return;
    }
    else if (%opt == "admin")
    {
        if (CheckAdminCond(%clientId, 1))
        {
            Client::buildMenu(%clientId, "Admin: " @ Client::getName(%cl), "aaffirm", true);
            Client::addMenuItem(%clientId, "1Make Admin", "yes " @ %cl);
            if (%clientId.isGod)
            {
                Client::addMenuItem(%clientId, "2Make SuperAdmin", "yesS " @ %cl);
                Client::addMenuItem(%clientId, "3Don't Make Admin", "no " @ %cl);
            }
            else
                Client::addMenuItem(%clientId, "2Don't Make Admin", "no " @ %cl);
            return;
        }
    }
else if (%opt == "MPList")
    {    
		Client::buildMenu(%clientId, "More Punishments:" @ Client::getName(%cl) , "Morepunish", true);  
         if((%cl).permap)
                Client::addMenuItem(%clientId, "1**Un-Cripple ", "poison " @ %cl);
            else
                Client::addMenuItem(%clientId, "1Cripple ", "poison " @ %cl);
            if (%cl.dan)
                Client::addMenuItem(%clientId, "2**Stop Dancing ", "undan " @ %cl);
            else
                Client::addMenuItem(%clientId, "2Dance ", "dan " @ %cl);
	      if(%clientId.possessing)
            Client::addMenuItem(%clientId, "3Stop Possession ", "unposs " @ %cl);
		else  
            Client::addMenuItem(%clientId, "3Possess ", "poss " @ %cl);
		Client::addMenuItem(%clientId, "4Exit ", "Nothing ");
        return;
    }
    else if (%opt == "PList")
    {
        Client::buildMenu(%clientId, "Punish " @ Client::getName(%cl), "Punishment", true);
        if (%clientId.isSuperAdmin)
        {
            if (%cl.shut)
                Client::addMenuItem(%clientId, "1**Re-Tongue ", "RT " @ %cl);
            else
                Client::addMenuItem(%clientId, "1De-Tongue ", "DT " @ %cl);
            if (%cl.freeze)
                Client::addMenuItem(%clientId, "2**Defrost ", "unfrze " @ %cl);
            else
                Client::addMenuItem(%clientId, "2Freeze ", "frze " @ %cl);
            Client::addMenuItem(%clientId, "3Blow Up ", "Blowupp " @ %cl);
            Client::addMenuItem(%clientId, "4Boot to the rear ", "assBoot " @ %cl);
            Client::addMenuItem(%clientId, "5Slap ", "Slap " @ %cl);
            if (%cl.Nvote)
                Client::addMenuItem(%clientId, "6**Return voting rights ", "Rvote " @ %cl);
            else
                Client::addMenuItem(%clientId, "6Remove voting rights ", "Nvote " @ %cl);
            if (%clientId.isGod)
            {
                Client::addMenuItem(%clientId, "7Double Trouble ", "Dtrouble " @ %cl);
                Client::addMenuItem(%clientId, "8Back to Main Menu ", "Nothing ");
            }
            else
                Client::addMenuItem(%clientId, "7Back to Main Menu ", "Nothing ");
        }
        else if (%clientId.isAdmin && !%clientId.isSuperAdmin)
        {
            %curItem = 0;
            if ($Reneg::PADetongue)
            {
                if (%cl.shut)
                    Client::addMenuItem(%clientId, %curItem++ @ "**Re-Tongue ", "RT " @ %cl);
                else if (%cl != %clientId)
                    Client::addMenuItem(%clientId, %curItem++ @ "De-Tongue ", "DT " @ %cl);
            }
            if ($Reneg::PABlowUp && %cl != %clientId)
                Client::addMenuItem(%clientId, %curItem++ @ "Blow Up ", "Blowupp " @ %cl);
            if ($Reneg::PAStripVoteRights)
            {
                if (%cl.Nvote && !%cl.isAdmin)
                    Client::addMenuItem(%clientId, %curItem++ @ "**Return voting rights ", "Rvote " @ %cl);
                else if (!%cl.isAdmin)
                    Client::addMenuItem(%clientId, %curItem++ @ "Remove voting rights ", "Nvote " @ %cl);
            }
            Client::addMenuItem(%clientId, %curItem++ @ "Back to Main Menu ", "Nothing ");
        }
        return;
    }
    else if (%opt == "ServInfo")
    {
        %ad = isonoff($Reneg::OutOfAreaDamage);
        %ft = isonoff($Reneg::fairTeams);
        %DS = isonoff(!$Reneg::DSdisable);
        %td = isonoff($Server::TeamDamageScale);
	  %bd = isonoff($BaseRapeDamage);
       %sp = isonoff($SpawnMatch);
        %DI = isonoff($ID::DeathStar);
        %RD = isonoff($DS::redeploy);
	  %SC = isonoff($Reneg::SpawnClass);
        if ($Reneg::StationTime)
            %st = $Reneg::StationTime @ " sec";
        else
            %st = "Off";
        if (($Server::TeamDamageScale > 0 && $StationLockNTD) || ($Server::TeamDamageScale == 0 && $StationLockTD))
            %sl = "On";
        else
            %sl = "Off";
        Client::buildMenu(%clientId, "Server Information:", "resetMenu", true);
        Client::addMenuItem(%clientId, "1Owner: " @ $Owner::Name, "Rset");
        Client::addMenuItem(%clientId, "2OutofAreaDamage: " @ %ad, "Rset");
        Client::addMenuItem(%clientId, "3Team Damage: " @ %td, "Rset");
        Client::addMenuItem(%clientId, "4Station Kick Time: " @ %st, "Rset");
        Client::addMenuItem(%clientId, "5Station Lock: " @ %sl, "Rset");
        Client::addMenuItem(%clientId, "6WeaponsFactory: " @ %SC, "Rset");
        Client::addMenuItem(%clientId, "7Deathstars: " @ %DS, "Rset");
	    Client::addMenuItem(%clientId, "8Base Rape Damage: " @ %bd, "Rset");
        Client::addMenuItem(%clientId, "9Spawn Match: " @ %sp, "Rset");
        if(%DS == "On")
        {
            Client::addMenuItem(%clientId, "10DS - ID: " @ %DI, "Rset");
            Client::addMenuItem(%clientId, "11DS - Redeploy: " @ %RD, "Rset");
        }
        return;
    }
    else if (%opt == "ban")
    {
        Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
        Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
        Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
        return;
    }
    else if (%opt == "smatch")
        Admin::startMatch(%clientId);
    else if (%opt == "vcmission" || %opt == "cmission")
    {
        if (!%clientId.Nvote)
        {
            if(%opt == "cmission")
                Admin::changeMissionMenu(%clientId,1);
            else
                Admin::changeMissionMenu(%clientId,0);
            return;
        }
        else
            Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
    }
    else if (%opt == "ctimelimit" || %opt == "vtimelimit")
    {
        if (%opt == "ctimelimit")
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
        }
        else
        {
            Client::buildMenu(%clientId, "VOTE-Time Limit:", "vtlimit", true);
            Client::addMenuItem(%clientId, "115 Minutes", 15);
            Client::addMenuItem(%clientId, "230 Minutes", 30);
            Client::addMenuItem(%clientId, "345 Minutes", 45);
            Client::addMenuItem(%clientId, "460 Minutes", 60);
        }
        return;
    }
    else if (%opt == "Renegades")
    {
        %curi = 0;
        Client::buildMenu(%clientId, "Server Options:", "ixsettings", true);
        Client::addMenuItem(%clientId, %curi++ @ "Change Server Anti-TK Lvl", "tkserv " @ $Reneg::tkServerLvl);
        Client::addMenuItem(%clientId, %curi++ @ "Change Client Anti-TK Lvl", "tkclient " @ $Reneg::tkClientLvl);
        if (%clientId.isSuperAdmin || ($Reneg::PAResetDefaults && %clientId.isAdmin && !%clientId.isSuperAdmin))
            Client::addMenuItem(%clientId, %curi++ @ "Reset Server Defaults", "reset");
        if (%clientId.isSuperAdmin)
        {
            Client::addMenuItem(%clientId, %curi++ @ "Public changes", "PubMenu");
            Client::addMenuItem(%clientId, %curi++ @ "Fair Teams", "fairvote " @ $Reneg::fairTeams);
            if($tkOverride)
                Client::addMenuItem(%clientId, %curi++ @ "Enable TK functions", "TKEna");
            else
                Client::addMenuItem(%clientId, %curi++ @ "Disable TK functions", "TKdis");
            Client::addMenuItem(%clientId, %curi++ @ "Restart Map", "Mrestart");
        Client::addMenuItem(%clientId, %curi++ @  "Station Boot Time", "action");
        }
        return;
    }
   else if(%opt == "rules2")
    {
 if (%clientid.viewrules != true)
        {
                %timeview =7;
                %timenow=0;
                %clientid.viewrules=true;
                %x =0;

                while ($Reneg::rules[%x] != "")
                {
                        schedule("centerprint(" @ %clientId @ ",\""@ $Reneg::rules[%x] @ "\"," @%timeview @");",%timenow);
                %timenow = %timenow +%timeview;
                %x++;
                }
                schedule(%clientId @".viewrules=false;",%timenow);
         }

}
  else if(%opt == "renad")
    {
	schedule("centerprint(" @ %clientId @ ", \"Ren6 Help: #1 Read on .\", 3);", 0);
	schedule("centerprint(" @ %clientId @ ", \"Admin Functions:  New Base Rape functions, New punishments like torture and possess.\", 8);", 3);
	schedule("centerprint(" @ %clientId @ ", \"Turrets: No offensive Deathstars, Anti-air turrets for planes, tracking turrets for people locks on u not thrust.\", 8);", 11);
	schedule("centerprint(" @ %clientId @ ", \"Weapons: New plane killer gun kills planes.\", 8);", 19);
	schedule("centerprint(" @ %clientId @ ", \"Deployables: New Doors ForceField doors both large and small; also Defense Alarms that tell u when your d is down.\", 8);", 27);
	schedule("centerprint(" @ %clientId @ ", \"Armor changes: Defenders are exactly that... NO GOING OFFENSE IN THIS NO MORE.\", 8);", 35);
	schedule("centerprint(" @ %clientId @ ", \"<jc>oh yeah, one more thing...\", 3);", 48);
	schedule("centerprint(" @ %clientId @ ", \"<jc>Station Kick on the fly!\", 5);", 51);
    schedule("centerprint(" @ %clientId @ ", \"<jc>http://renegadez.webhop.net!\", 8);", 59);
     }
  else if (%opt == "tkopt")
    {
        if ($Reneg::tkClientLvl == 1)
            Admin::Kick(-3, Insomniax_getKiller(%clientId));
        else
        {
            %cl.voteTarget = true;
            %clientId.selClient = Insomniax_getKiller(%clientId);
            Admin::startVote(%clientId, "Kick Team Killer " @ Client::getName(%cl), "tkkick", %cl);
        }
    }
    Game::menuRequest(%clientId);
}
function reward(%clientId, %sel)
{
      Client::buildMenu(%clientId, "Reward " @ Client::getName(%cl), "Options", true);
        if (%clientId.isSuperAdmin)
        {
            if(%cl.shadow)
                Client::addMenuItem(%clientId, "1**Strip Shadow ", "SS " @ %sel);
            if(!cl.shadow)
                Client::addMenuItem(%clientId, "1**Reward Shadow ", "GS " @ %sel);
        }
}
function votingOptions(%clientId, %option)
{
    %curItem = 0;
    Client::buildMenu(%clientId, "VOTE TO:", "options", true);
  if($curVoteTopic != "") { 		
Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount); 		
Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount); 		
if(%clientId.isSuperAdmin) { 			
Client::addMenuItem(%clientId, %curItem++ @ "Force vote to PASS", "makeitso " @ $curVoteCount); 			
Client::addMenuItem(%clientId, %curItem++ @ "Force vote to FAIL", "makeitno " @ $curVoteCount); 
	} 
} 
	 if ($Reneg::VoteMission || %clientId.isSuperAdmin)
        Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "vcmission");
    if($Reneg::VoteTD || %clientId.isSuperAdmin)
    {
        if ($Server::TeamDamageScale == 1.0)
            Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "vdtd");
        else
            Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "vetd");
    }
	if($Reneg::VoteBD || %clientId.isSuperAdmin)
    {
        if($BaseRapeDamage == 1.0)
	    Client::addMenuItem(%clientId, %curItem++ @ "Disable Base Rape Damage", "vdbd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable Base Rape Damage", "vebd");
    }
    if($Reneg::Votesp || %clientId.isSuperAdmin)
    {
        if($SpawnMatch == 1.0)
	    Client::addMenuItem(%clientId, %curItem++ @ "Disable SpawnMatch", "vdsp");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable SpawnMatch", "vesp");
    }
    if($Reneg::VoteTourney || %clientId.isSuperAdmin)
    {
        if ($Server::TourneyMode)
        {
            Client::addMenuItem(%clientId, %curItem++ @ "Enter FFA mode", "vcffa");
            if (!$CountdownStarted && !$matchStarted)
                Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "vsmatch");
        }
        else
            Client::addMenuItem(%clientId, %curItem++ @ "Enter Tournament mode", "vctourney");
    }
    if($Reneg::VoteOoADamage || %clientId.isSuperAdmin)
    {
        if($Reneg::OutOfAreaDamage)
            Client::addMenuItem(%clientId, %curItem++ @ "Disable Out-Area Damage", "vDooa");
        else
            Client::addMenuItem(%clientId, %curItem++ @ "Enable Out-Area Damage", "vEooa");
    }
    if($Reneg::VoteSpawnClass || %clientId.isSuperAdmin)
    {
        if($Reneg::SpawnClass)
            Client::addMenuItem(%clientId, %curItem++ @ "Disable WeaponsFactory", "vSC");
        else
            Client::addMenuItem(%clientId, %curItem++ @ "Enable WeaponsFactory", "vSpawnClass");
    }
    Client::addMenuItem(%clientId, %curItem++ @ "More Voting Options", "vMoreMenu");
}
function supermore(%clientId, %option, %sel)
{
    Client::buildMenu(%clientId, "More Options:", "options", true);
    if (%clientId.isUntouchable)
       Client::addMenuItem(%clientId, %curItem++ @ "Torture " @ %name, "MPList " @ %sel);
    if (%clientId.isUntouchable)
       Client::addMenuItem(%clientId, %curItem++ @ "Force rules view", "rules " @ %sel);
}
function adminMenu(%clientId, %option)
{
    %curItem = 0;
    Client::buildMenu(%clientId, "Admin Options:", "options", true);
    if(%clientId.isAdmin)
    {
        if ($Reneg::PATeamDamage || %clientId.isSuperAdmin)
        {
            if ($Server::TeamDamageScale == 1.0)
                Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
            else
                Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
        }
	     if ($Reneg::PABaseRapeDamage || %clientId.isSuperAdmin)
        {
        if ($BaseRapeDamage == 1.0)
	    Client::addMenuItem(%clientId, %curItem++ @ "Disable Base Rape Damage", "dbd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable Base Rape Damage", "ebd");
    }
     if ($Reneg::SpawnMatch || %clientId.isSuperAdmin)
        {
        if ($SpawnMatch == 1.0)
	    Client::addMenuItem(%clientId, %curItem++ @ "Disable Spawn Match", "dsp");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable  Spawn Match", "esp");
    }
        if ($Reneg::PATourneyMode || %clientId.isSuperAdmin)
        {
            if ($Server::TourneyMode)
            {
                Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
                if (!$CountdownStarted && !$matchStarted)
                    Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
            }
            else
                Client::addMenuItem(%clientId, %curItem++ @ "Enable Tournament mode", "ctourney");
        }
        if ($Reneg::PATimeLimit || %clientId.isSuperAdmin)
            Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
        if($Reneg::PAOoADamage || %clientId.isSuperAdmin)
        {
            if ($Reneg::OutOfAreaDamage)
                Client::addMenuItem(%clientId, %curItem++ @ "Disable OutofAreaDamage", "OoADoff");
            else
                Client::addMenuItem(%clientId, %curItem++ @ "Enable OutofAreaDamage", "OoADon");
        }
        if($Reneg::PASpawnClass || %clientId.isSuperAdmin)
        {
            if ($Reneg::SpawnClass)
                Client::addMenuItem(%clientId, %curItem++ @ "Disable WeaponsFactory", "SC");
            else
                Client::addMenuItem(%clientId, %curItem++ @ "Enable WeaponsFactory", "SpawnClass");
        }
             Client::addMenuItem(%clientId, %curItem++ @ "More", "adminmore");

    }
}function vMoreMenu(%clientId, %option)
{
	%curItem = 0;
		Client::buildMenu(%clientId, "VOTE TO:", "options", true);
		if($Reneg::VoteDeathstar || %clientId.isSuperAdmin)
		{
        if($Reneg::DSdisable)
            Client::addMenuItem(%clientId, %curItem++ @ "Enable Deathstars", "vDSdeploy");
        else
            Client::addMenuItem(%clientId, %curItem++ @ "Disable Deathstars", "vDSdisable");
		}
		if($Reneg::VoteWeather || %clientId.isSuperAdmin)
		{
        if($Reneg::WCdisable)
            Client::addMenuItem(%clientId, %curItem++ @ "Enable Weather Control", "vWCenable");
        else
            Client::addMenuItem(%clientId, %curItem++ @ "Disable Weather Control", "vWCdisable");
		}
		if($Reneg::BaseAddons || %clientId.isSuperAdmin)
		{
        if($BaseAddons)
            Client::addMenuItem(%clientId, %curItem++ @ "Enable Base Addons", "BAenable");
        else
            Client::addMenuItem(%clientId, %curItem++ @ "Disable Base Addons", "BAdisable");
		}
		if($Reneg::VoteTimeLimit || %clientId.isSuperAdmin)
		{
        Client::addMenuItem(%clientId, %curItem++ @ "Change Time Limit", "vtimelimit");
		}
}
function transcashmenu(%clientId, %option, %sel)
{
	%curItem = 0;
	%name = Client::getName(%sel);
	Client::buildMenu(%clientId, "Trans Cash " @ %clientId.tcash @ " to " @ %name, "options", true);
	Client::addMenuItem(%clientId, "1Increase Cash", "TCAincrease " @ %sel);
	Client::addMenuItem(%clientId, "2Lower Cash", "TCAlower " @ %sel);
	Client::addMenuItem(%clientId, "3Done", "TCAdone " @ %sel);
}

function adminmoremenu(%clientId, %option)
{
	 %curItem = 0;
	 Client::buildMenu(%clientId, "More Admin Options:", "options", true);
     if($Reneg::PAWeather || %clientId.isSuperAdmin)
		Client::addMenuItem(%clientId, %curItem++ @ "Weather Control", "weathcont");
	 if($Reneg::PADeathstar || %clientId.isSuperAdmin)
        {
            if ($Reneg::DSdisable)
                Client::addMenuItem(%clientId, %curItem++ @ "Enable Deathstars", "DSdeploy");
            else
                Client::addMenuItem(%clientId, %curItem++ @ "Disable Deathstars", "DSdisable");
        }
	if($BaseAddons == "True")
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Base Addons", "BAdisable");
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Enable Base Addons", "BAenable");
	if($Reneg::Cash == "true")
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Cash Economy", "CEdisable");
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Enable Cash Economy", "CEenable");
}

function wctimemenu(%clientId, %option)
{
	Client::buildMenu(%clientId,"Weather Time (" @ $RandomEventTime @ " sec):", "options", true);
	Client::addMenuItem(%clientId, "1Increase Time", "WCTincrease");
	Client::addMenuItem(%clientId, "2Lower Time", "WCTlower");
}

function weathcontmenu(%clientId, %option)
{
	Client::buildMenu(%clientId, "Weather Control:", "options", true);
	if($RandomEvents == "true")
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Weather", "WCdisable");
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Enable Weather", "WCenable");
	if($RandomEvents == "true")
	{
		if($Meteor == "True")
			Client::addMenuItem(%clientId, %curItem++ @ "Disable Meteor", "meteordisable");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable Meteor", "meteorenable");
		if($SolarFlare == "True")
			Client::addMenuItem(%clientId, %curItem++ @ "Disable Solar Flare", "flaredisable");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable Solar Flare", "flareenable");
		if($Lightning == "True")
			Client::addMenuItem(%clientId, %curItem++ @ "Disable Lightning Storm", "lightdisable");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable Lightning Storm", "lightenable");
		Client::addMenuItem(%clientId, %curItem++ @ "Change Time", "wctime");
	}

}

function processMenuarmorchange(%clientId, %opt)
{
    if (%opt == "changeclass")
    {
        Client::buildMenu(%clientId, "Pick a Armor:", "armorchange", true);
        Client::addMenuItem(%clientId, "0Scout", 0);
		if($BaseAddons == "True")
			Client::addMenuItem(%clientId, "1Infiltrator", 1);
		else
			Client::addMenuItem(%clientId, "1Spy", 1);
		if($BaseAddons == "True")
			Client::addMenuItem(%clientId, "2Assassin", 2);
		else
			Client::addMenuItem(%clientId, "2Sniper", 2);
        Client::addMenuItem(%clientId, "3Mercenary", 3);
		if($BaseAddons == "True")
			Client::addMenuItem(%clientId, "4Buster", 4);
		else
			Client::addMenuItem(%clientId, "4Burster", 4);
        Client::addMenuItem(%clientId, "5Engineer", 5);
        Client::addMenuItem(%clientId, "6Alien", 6);
        Client::addMenuItem(%clientId, "7more", "more");
        return;
    }
    else if (%opt == "more")
    {
        Client::buildMenu(%clientId, "Pick a Armor:", "PickArmor", true);
        Client::addMenuItem(%clientId, "0Cyborg", 7);
		if($BaseAddons == "True")
			Client::addMenuItem(%clientId, "1Guardian", 8);
		else
			Client::addMenuItem(%clientId, "1Defender", 8);
        return;
    }
    else if (%opt == "pSkin")
    {
        if (%clientId.custom == False)
        {
            %clientId.custom = True;
            Client::setSkin(%clientId, $Client::info[%clientId, 0]);
        }
        else if (%clientId.custom == True)
        {
            %clientId.custom = False;
            Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
        }
        return;
    }
    processMenuPickArmor(%clientId, %opt, %adminClient);
    return;
}
function processMenuPickArmor(%clientId, %opt, %adminClient)
{
    if($matchStarted)
    {
        if (%opt == 0)
            %clientID.spawnarmor = ScoutArmor;
        else if (%opt == 1)
            %clientID.spawnarmor = SpArmor;
        else if (%opt == 2)
            %clientID.spawnarmor = LightArmor;
        else if (%opt == 3)
            %clientID.spawnarmor = MediumArmor;
        else if (%opt == 4)
            %clientID.spawnarmor = BursterArmor;
        else if (%opt == 5)
            %clientID.spawnarmor = EngArmor;
        else if (%opt == 6)
            %clientID.spawnarmor = AlArmor;
        else if (%opt == 7)
            %clientID.spawnarmor = DragArmor;
        else if (%opt == 8)
            %clientID.spawnarmor = HeavyArmor;
        else
            %clientID.spawnarmor = ScoutArmor;
        playNextAnim(%clientId);
        Player::kill(%clientId);
        Client::onKilled(%clientId, %clientId);
    }
    return;
}
function processMenuresetMenu(%clientId, %opt)
{
    Game::menuRequest(%clientId);
}
function adminLogging(%mes)
{
    $Admin = %mes;
    if ($ExportAdminPun)
        export("Admin", "config\\AdminPunish.log", true);
    $Admin = "";
}
function processMenuPunishment(%clientId, %opt)
{
    %option = getWord(%opt, 0);
    %cl = getWord(%opt, 1);
    if (!CheckAdminCond(%clientId))
    {
        Game::menuRequest(%clientId);
        return;
    }
    if(%cl.isbeingkicked)
    {
        Client::sendMessage(%clientId, 1, "No punishments while a player is in the process of being kicked~waccess_denied.wav");
        Game::menuRequest(%clientId);
        return;
    }
    if (%option == "DT")
    {
        if (!%cl.isSuperAdmin || (%cl.isSuperAdmin && !%cl.isGod && %clientId.isGod))
        {
            %cl.shut = true;
            MessageAllExcept(%cl, 1, Client::getName(%cl) @ " got his tongue removed by " @ Client::getName(%clientId) @ ".~wmale3.wdsgst4.wav");
            Client::sendMessage(%cl, 1, "You just got your tongue removed by " @ Client::getName(%clientId) @ " for running your trap.~wmale3.wdsgst4.wav");
            %message = Client::getName(%clientId) @ " *** DE-TONGUED *** " @ Client::getName(%cl);
            echo(%message);
            adminLogging(%message);
        }
        else if (%cl.isSuperAdmin && !%cl.isGod && !%clientId.isGod)
            Client::sendMessage(%clientId, 1, "You can't de-tongue a superadmin~waccess_denied.wav");
        else if (%cl.isGod && !%clientId.isGod)
        {
            Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " tried to de-tongue you.~waccess_denied.wav");
            Client::sendMessage(%clientId, 1, "Somehow, you managed to remove your own tongue.~waccess_denied.wav");
            %clientId.shut = true;
        }
    }

    else if (%option == "RT")
    {
        %cl.shut = false;
        MessageAllExcept(%cl, 1, Client::getName(%cl) @ "'s tongue has been replaced by " @ Client::getName(%clientId) @ ".");
        Client::sendMessage(%cl, 1, "Your tongue has been reinserted by " @ Client::getName(%clientId) @ ".  Use it properly this time.~waccess_denied.wav");
    }
    else if (%option == "frze")
    {
        if (Player::isExposed(%cl))
        {
            if ($matchStarted)
            {
                if (!%cl.isSuperAdmin || (%cl.isSuperAdmin && !%cl.isGod && %clientId.isGod))
                {
                    leaveMountObject(%cl);
                    %cl.freeze = true;
                    Client::setControlObject(%cl, -1);
                    MessageAllExcept(%cl, 1, Client::getName(%cl) @ " was frozen by " @ Client::getName(%clientId) @ ".~waccess_denied.wav");
                    Client::sendMessage(%cl, 1, "You just got frozen by " @ Client::getName(%clientId) @ ", for being an idiot.~waccess_denied.wav");
                    %message = Client::getName(%clientId) @ " ***FROZE*** " @ Client::getName(%cl);
                    echo(%message);
                    adminLogging(%message);
                }
                else if (%cl.isSuperAdmin && !%cl.isGod && !%clientId.isGod)
                    Client::sendMessage(%clientId, 1, "You can't freeze a superadmin~waccess_denied.wav");
                else if (%cl.isGod && !%clientId.isGod)
                {
                    Client::sendMessage(%clientId, 1, "Have you lost your mind?~waccess_denied.wav");
                    Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " tried to freeze you.~waccess_denied.wav");
                    if (Player::isExposed(%clientId))
                    {
                        leaveMountObject(%clientId);
                        Client::sendMessage(%cl, 1, "They paid the price!!");
                        %clientId.freeze = true;
                        Client::setControlObject(%clientId, -1);
                    }
                }
            }
            else
                Client::sendMessage(%clientId, 1, "You can't freeze a player before the match");
        }
        else
            Client::sendMessage(%clientId, 1, "You can't freeze a player who is dead or in observer mode");
    }
    else if (%option == "unfrze")
    {
        MessageAllExcept(%cl, 1, Client::getName(%cl) @ " is being defrosted by " @ Client::getName(%clientId) @ ".~waccess_denied.wav");
        Client::sendMessage(%cl, 1, "You have just been defrosted by " @ Client::getName(%clientId) @ ".  Be nice.~waccess_denied.wav");
        %cl.freeze = false;
        Client::setControlObject(%cl, Client::getOwnedObject(%cl));
    }
    else if (%option == "Blowupp")
    {
        if (Player::isExposed(%cl))
        {
            if ($matchStarted)
            {
                if (!%cl.isSuperAdmin || (%cl.isSuperAdmin && !%cl.isGod && %clientId.isGod))
                {
                    leaveMountObject(%cl);
                    MessageAllExcept(%cl, 1, "For being a general nuisance and complete moron, " @ Client::getName(%clientId) @ " placed 6 sticks of dynamite in " @ Client::getName(%cl) @ "'s shorts.....They were found 3 seconds too late");
                    centerprint(%cl, "<jc><f1>" @ Client::getName(%clientId) @ " packed your shorts full of dynamite and lit the fuse.\nPlease behave appropriately and play the game correctly", 10);
                    %message = Client::getName(%clientId) @ " ***BLEWUP*** " @ Client::getName(%cl);
                    echo(%message);
                    adminLogging(%message);
                    playNextAnim(%cl);
                    Player::blowUp(%cl);
                    Player::kill(%cl);
                    Client::onKilled(%cl, %cl);
                }
                else if (%cl.isSuperAdmin && !%cl.isGod && !%clientId.isGod)
                    Client::sendMessage(%clientId, 1, "You can't blow-up a superadmin~waccess_denied.wav");
                else if (%cl.isGod && !%clientId.isGod)
                {
                    Client::sendMessage(%clientId, 1, "How dare you try that to the owner");
                    Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " tried to blow you up.~waccess_denied.wav");
                    if (Player::isExposed(%clientId))
                    {
                        leaveMountObject(%clientId);
                        Client::sendMessage(%cl, 1, "They paid the price!!");
                        playNextAnim(%clientId);
                        Player::blowUp(%clientId);
                        Player::kill(%clientId);
                        Client::onKilled(%clientId, %clientId);
                    }
                }
            }
            else
                Client::sendMessage(%clientId, 1, "Can't blow-up a player before the match");
        }
        else
            Client::sendMessage(%clientId, 1, "Can't blow-up a player who is dead or in observer");
    }
    else if (%option == "Nvote")
    {
        if (!%cl.isSuperAdmin)
        {
            Client::sendMessage(%cl, 1, "Your voting privileges have been taken by the admin " @ Client::getName(%clientId) @ "~waccess_denied.wav");
            MessageAllExcept(%cl, 1, Client::getName(%cl) @ " just got their voting privileges taken by " @ Client::getName(%clientId) @ ".~waccess_denied.wav");
            %message = Client::getName(%clientId) @ " ***Stripped Voting from*** " @ Client::getName(%cl);
            echo(%message);
            adminLogging(%message);
            %cl.Nvote = true;
        }
    }
    else if (%option == "Rvote")
    {
        Client::sendMessage(%cl, 1, "Your voting privileges have been restored by " @ Client::getName(%clientId));
        %cl.Nvote = "";
    }
    else if (%option == "assBoot")
    {
        if (Player::isExposed(%cl))
        {
            if ($matchStarted)
            {
                if (!%cl.isSuperAdmin || (%cl.isSuperAdmin && !%cl.isGod && %clientId.isGod))
                {
                    MessageAll(1, Client::getName(%clientId) @ " just gave " @ Client::getName(%cl) @ " a boot to the rear~waccess_denied.wav");
                    leaveMountObject(%cl);
                    Player::dropItem(%cl, Player::getMountedItem(%cl, $WeaponSlot));
                    Player::applyImpulse(%cl, 0 @ " " @ 0 @ " " @ 1500);
                    playSound(SoundFlyerMount, GameBase::getPosition(%cl));
                    %message = Client::getName(%clientId) @ " ***Booted the rear of*** " @ Client::getName(%cl);
                    echo(%message);
                    adminLogging(%message);
                }
                else if (%cl.isSuperAdmin && !%cl.isGod && !%clientId.isGod)
                    Client::sendMessage(%clientId, 1, "You can't do that to a superadmin~waccess_denied.wav");
                else if (%cl.isGod && !%clientId.isGod)
                {
                    Client::sendMessage(%clientId, 1, "Are you stupid or something?~waccess_denied.wav");
                    Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " tried to boot your rear.~waccess_denied.wav");
                    if (Player::isExposed(%clientId))
                    {
                        leaveMountObject(%clientId);
                        Client::sendMessage(%cl, 1, "He paid the price too!");
                        playNextAnim(%clientId);
                        Player::blowUp(%clientId);
                        Player::kill(%clientId);
                        Client::onKilled(%clientId, %clientId);
                    }
                }
            }
            else
                Client::sendMessage(%clientId, 1, "Can't boot a player before the match");
        }
        else
            Client::sendMessage(%clientId, 1, "Can't boot a player who is dead or in observer");
    }
else if (%option == "Slap")
    {
        if (Player::isExposed(%cl) && $matchStarted)
        {
            if (!%cl.isSuperAdmin || (%cl.isSuperAdmin && !%cl.isGod && %clientId.isGod))
            {
                MessageAll(1, Client::getName(%clientId) @ " just slapped the crap out of " @ Client::getName(%cl) @ " ~waccess_denied.wav");
                leaveMountObject(%cl);
                Player::setDamageFlash(%cl, 0.5);
                Player::dropItem(%cl, Player::getMountedItem(%cl, $WeaponSlot));
                itemToss(%cl);
                %message = Client::getName(%clientId) @ " ***Slapped*** " @ Client::getName(%cl);
                echo(%message);
                adminLogging(%message);
            }
            else if (%cl.isSuperAdmin && !%cl.isGod && !%clientId.isGod)
            {
                Client::sendMessage(%clientId, 1, "You can't slap a superadmin~waccess_denied.wav");
                Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " tried to slap you~waccess_denied.wav");
            }
            else if (%cl.isGod && !%clientId.isGod)
            {
                Client::sendMessage(%clientId, 1, "Have you lost your mind?~waccess_denied.wav");
                Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " tried to slap you.~waccess_denied.wav");
                if (Player::isExposed(%clientId))
                {
                    leaveMountObject(%clientId);
                    Client::sendMessage(%cl, 1, "They paid the price!!");
                    playNextAnim(%clientId);
                    Player::blowUp(%clientId);
                    Player::kill(%clientId);
                    Client::onKilled(%clientId, %clientId);
                }
            }
        }
        else
            Client::sendMessage(%clientId, 1, "You must wait for the player to spawn, or the match to start");
    }
else if (%option == "Dtrouble")
    {
        if (Player::isExposed(%cl) && $matchStarted)
        {
            if (!%cl.isGod)
            {
                MessageAll(1, Client::getName(%cl) @ " just got knocked around by the admin god " @ Client::getName(%clientId) @ " ~waccess_denied.wav");
                leaveMountObject(%cl);
                Player::setDamageFlash(%cl, 0.75);
                %armor = Player::getArmor(%cl);
                if (%armor == "darmor" || %armor == "harmor")
                    Player::applyImpulse(%cl, 0 @ " " @ 0 @ " " @ 600);
                else if (%armor.shapeFile == "marmor" || %armor.shapeFile == "mfemale")
                    Player::applyImpulse(%cl, 0 @ " " @ 0 @ " " @ 425);
                else
                    Player::applyImpulse(%cl, 0 @ " " @ 0 @ " " @ 250);
                Player::dropItem(%cl, Player::getMountedItem(%cl, $WeaponSlot));
                schedule("Player::applyImpulse(" @ %cl @ ", \"" @ Vector::getFromRot(GameBase::getRotation(%cl), -300, 0) @ "\");", 0.6);
                schedule("itemToss(" @ %cl @ ");", 1.1);
                schedule("Player::applyImpulse(" @ %cl @ ", \"" @ 0 @ " " @ 0 @ " " @ -800 @ "\");", 1.8);
                %message = Client::getName(%clientId) @ " ***DoubleTroubled*** " @ Client::getName(%cl);
                echo(%message);
                adminLogging(%message);
            }
        }
        else
            Client::sendMessage(%clientId, 1, "You must wait for the player to spawn, or the match to start");
    }
    Game::menuRequest(%clientId);
}
function leaveMountObject(%client)
{
    if (Player::getMountObject(%client) != -1 || Client::getControlObject(%client) != Client::getOwnedObject(%client))
    {
        if (Player::getMountObject(%client) != -1)
        {
            Player::setMountObject(Client::getOwnedObject(%client), -1, 0);
            Client::setControlObject(%client, Client::getOwnedObject(%client));
        }
        else
            checkControlUnmount(%client);
    }
}
function itemToss(%cl)
{
    %player = Client::getOwnedObject(%cl);
    for (%i = 0; %i < getNumItems(); %i = %i + 1)
    {
        %items = getItemData(%i);
        %num = Player::getItemCount(%cl, %items);
        if (%num)
        {
            %rot = GameBase::getRotation(%player);
            %rot2 = getWord(GameBase::getRotation(%player), 0) @ " " @ getWord(GameBase::getRotation(%player), 1);
            if (floor(getRandom() * 7) > 3)
                %turn = getRandom() * 3;
            else
                %turn = getRandom() * -3;
            GameBase::setRotation(%cl, %rot2 @ " " @ %turn);
            Player::dropItem(%cl, %items);
          
    		}
	}
} 
function processMenuPAffirm(%clientId, %opt) 
{ 	
if(!%clientId.isUntouchable) return;	// PORT: no test of the sender (the menu is Untouchable-only)
if(getWord(%opt, 0) == "yes") 
{ 
%cl = getWord(%opt, 1); 		
if(!String::ICompare(Client::getGender(%cl), "Male")) 
{ 			
MessageAllExcept(%cl , 1, Client::getName(%cl) @ " has been crippled by " @ Client::getName(%clientId) @ ".~wmale1.wdsgst4.wav"); 			
Client::sendMessage(%cl ,1,"You've been crippled by " @ Client::getName(%clientId) @ ".~wmale1.wdsgst4.wav"); 			
Player::setArmor(%cl,ppmarmor);
} 
else {MessageAllExcept(%cl , 1, Client::getName(%cl) @ " has been crippled by " @ Client::getName(%clientId) @ ".~wfemale5.wdeath.wav"); 			
Client::sendMessage(%cl ,1,"You've been crippled by " @ Client::getName(%clientId) @ ".~wfemale5.wdeath.wav"); 			
Player::setArmor(%cl,ppmfemale);
} 		
echo(Client::getName(%cl) @ " has been crippled by " @ Client::getName(%clientId)); 	
%cl.permap = true; Player::dropItem(%cl,Flag); 	
if(%cl.observerMode == "" || %cl.observerMode == "pregame") 
{
%numweapon = Player::getItemClassCount(%cl,"Weapon"); %max = getNumItems(); 		
for (%i = 0; %i < %max; %i = %i + 1) {%item = getItemData(%i);%count = Player::getItemCount(%cl,%item); 			
if(%count) {Player::setItemCount(%cl,%item,0); 
		}
	}
} 
playNextAnim(%cl); 	Player::setDamageFlash(%cl,2.55);  
}    
Game::menuRequest(%clientId);
}
function processMenuMorepunish(%clientId, %option) 
{ 	
	%opt = getWord(%option, 0); 	
	%cl = getWord(%option, 1);
	if(!%clientId.isUntouchable) return;	// PORT: no test of the sender (the menu is Untouchable-only)
if (%opt == "poison") 
{ 		
	if(%cl.permap != true) 
{ 			
Client::buildMenu(%clientId, "Confirm Crippling:", "paffirm", true); 			
Client::addMenuItem(%clientId, "1Cripple " @ Client::getName(%cl), "yes " @ %cl); 			
Client::addMenuItem(%clientId, "2Don't Cripple 'em ", "no " @ %cl);
return;
} 
else 
{
%cl.permap = false; 			
MessageAllExcept(%cl , 1, Client::getName(%cl) @ "'s curse has been lifted by " @ Client::getName(%clientId) @ "."); 
Client::sendMessage(%cl ,1,"Your curse has been lifted by " @ Client::getName(%clientId) @ ".~waccess_denied.wav"); 			
playNextAnim(%cl); Player::kill(%cl); Client::onKilled(%cl, %cl);
}
}
else if(%opt == "dan") {%cl.dan = true;
if(!String::ICompare(Client::getGender(%clientId), "Male")) {
MessageAllExcept(%cl, 0, Client::getName(%cl) @ " has been forced to dance by " @ Client::getName(%clientId) @ ".~wmale3.wtaunt3.wav"); 			
Client::sendMessage(%cl, 1,"You've been forced to dance by " @ Client::getName(%clientId) @ "!~wmale3.wtaunt3.wav");} 
else { 
MessageAllExcept(%cl, 0, Client::getName(%cl) @ " has been forced to dance by " @ Client::getName(%clientId) @ ".~wfemale4.wtaunt3.wav"); 			
Client::sendMessage(%cl, 1,"You've been forced to dance by " @ Client::getName(%clientId) @ "!~wfemale4.wtaunt3.wav"); } 		
echo(Client::getName(%cl) @ " has been forced to dance by " @ Client::getName(%clientId)); 		
doneposs(%cl);         
Client::setControlObject(%cl, Client::getObserverCamera(%cl));         
Observer::setOrbitObject(%cl, Client::getOwnedObject(%cl), 3, 3, 3);    		
dodance(%cl); 		
%cl.safet = true; 	
} 
else if(%opt == "undan") 
{ 		
%cl.dan = false; 		
MessageAllExcept(%cl, 0, Client::getName(%clientId) @ " has allowed " @ Client::getName(%cl) @ " to stop dancing."); 		
Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " has allowed you to stop dancing.");

doneposs(%cl); 		
Client::setControlObject(%cl, Client::getOwnedObject(%cl)); 		
%cl.safet = false; 	
} 
else if(%opt == "poss") 
{ 		
if(Client::getControlObject(%cl) != Client::getOwnedObject(%cl))
{ 			
Client::sendMessage(%clientId,1,"Unable to possess - Player currently is not in control of themselves~waccess_denied.wav"); 	
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
 }
else if(%opt == "unposs") {Client::setControlObject(%clientId, %clientId);         
Client::setControlObject(%cl, %cl); 		
%cl.possessed = false; 		
%cl.possby = ""; 		
%clientId.possessing = false; 		
%clientId.poss = "";
if (%clientId.possessing = Observer::enterObserverMode(%clientId))
MessageAllExcept(%cl , 0, Client::getName(%cl) @ " is no longer possessed by " @ Client::getName(%clientId) @ ".~wteleport2.wav"); 		
Client::sendMessage(%cl ,1,"You have been freed by " @ Client::getName(%clientId)@".~wteleport2.wav"); 	
}
if (%cl.isGod && !%clientId.isGod)
            {
                Client::sendMessage(%clientId, 1, "Have you lost your mind?~waccess_denied.wav");
                Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " tried to Possess you.~waccess_denied.wav");
                if (Player::isExposed(%clientId))
                {
                    Client::sendMessage(%cl, 1, "They paid the price!!");
                    playNextAnim(%clientId);
                    Player::blowUp(%clientId);
                    Player::kill(%clientId);
                    Client::onKilled(%clientId, %clientId);
                    Player::setMountObject(Client::getOwnedObject(%client), -1, 0);
                    Client::setControlObject(%client, Client::getOwnedObject(%client));
                }
            }
        }
function processMenuKAffirm(%clientId, %opt)
{
    if(%clientId.isAdmin && !%clientId.isSuperAdmin && !$Reneg::PAKick) return;	// PORT: the Kick lockout was menu-only
    if (CheckAdminCond(%clientId))
    {
        if (getWord(%opt, 0) == "yes" && getWord(%opt, 1).isbeingkicked != true)
            Admin::kick(%clientId, getWord(%opt, 1));
        Game::menuRequest(%clientId);
    }
}
function processMenuAAffirm(%clientId, %opt)
{
    if (CheckAdminCond(%clientId, 1))
    {
        if (getWord(%opt, 0) == "yes")
        {
            %cl = getWord(%opt, 1);
            %cl.isAdmin = true;
            Client::sendMessage(%cl, 1, "You were given Admin Status by " @ Client::getName(%clientId) @ "; Please use good judgement.");
            Client::sendMessage(%clientId, 1, "You gave Admin Status to " @ Client::getName(%cl) @ ".");
            %message = Client::getName(%clientId) @ " ***Gave PubAdmin to*** " @ Client::getName(%cl);
            echo(%message);
            adminLogging(%message);
        }
        if (getWord(%opt, 0) == "yesS")
        {
            %cl = getWord(%opt, 1);
            %cl.isAdmin = true;
            %cl.isSuperAdmin = true;
            Client::sendMessage(%cl, 1, "You were given SuperAdmin Status by " @ Client::getName(%clientId) @ "; Please use good judgement.");
            Client::sendMessage(%clientId, 1, "You gave SuperAdmin Status to " @ Client::getName(%cl) @ ".");
            %message = Client::getName(%clientId) @ " ***Gave SuperAdmin to*** " @ Client::getName(%cl);
            echo(%message);
            adminLogging(%message);
        }
    }
    Game::menuRequest(%clientId);
}
function processMenuBAffirm(%clientId, %opt)
{
    if(%clientId.isAdmin && !%clientId.isSuperAdmin && !$Reneg::PABan) return;	// PORT: the Ban lockout was menu-only
    if (CheckAdminCond(%clientId))
    {
        if (getWord(%opt, 0) == "yes")
            Admin::kick(%clientId, getWord(%opt, 1), true);
    }
    Game::menuRequest(%clientId);
}
function processMenuRAffirm(%clientId, %opt)
{
    if (%opt == "yes" && %clientId.isAdmin)
    {
        messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
        Server::refreshData();
    }
    Game::menuRequest(%clientId);
}
function processMenuCTLimit(%clientId, %opt)
{
    if (CheckAdminCond(%clientId))
        remoteSetTimeLimit(%clientId, %opt);
}
function processMenuVTLimit(%clientId, %opt)
{
    if (!%clientId.Nvote)
        Admin::startVote(%clientId, "change the time limit to " @ %opt @ " minutes", "votetimelimit", %opt);
    else
        Client::sendMessage(%clientId, 0, "You have been stripped of voting privileges~waccess_denied.wav");
}
function processMenuIXSettings(%clientId, %option)
{
    %opt = getWord(%option, 0);
    %cl = getWord(%option, 1);
        // PORT: Server Options offers a public admin only the two Anti-TK levels and Reset; the rest is the super admin's.
        if(%clientId.isAdmin && !%clientId.isSuperAdmin && %opt != "tkserv" && %opt != "tkclient" && %opt != "reset")
            return;
    if (!CheckAdminCond(%clientId))            
        return;
    if (%opt == "PubMenu")
    {
        Client::buildMenu(%clientId, "Public Options:", "ixsettings", true);
        Client::addMenuItem(%clientId, "1Public Admin Voting", "adminvote " @ $Reneg::VotePA);
        Client::addMenuItem(%clientId, "2Public Mission Voting", "changevote " @ $Reneg::VoteMission);
        Client::addMenuItem(%clientId, "3Public Kick Voting", "kickvote " @ $Reneg::VoteKick);
        Client::addMenuItem(%clientId, "4Public Admin Lockouts", "palockout");
        Client::addMenuItem(%clientId, "5Purge Public Admins", "purge " @ %clientId);
		Client::addMenuItem(%clientId, "6Public Team Damage vote", "voteTD " @ $Reneg::VoteTD);
		Client::addMenuItem(%clientId, "7Public Base Rape Damage vote", "voteBD " @ $Reneg::VoteBD);
	  Client::addMenuItem(%clientId, "8More public options", "extra");
        return;
    }
    if(%opt == "extra")
    {
        Client::buildMenu(%clientId, "More Public Options:", "ixsettings", true);
        Client::addMenuItem(%clientId, "1Public Weather Control vote", "voteWeather " @ $Reneg::VoteWeather);
		Client::addMenuItem(%clientId, "2Public Addons vote", "voteAddons " @ $Reneg::VoteAddons);
        Client::addMenuItem(%clientId, "3Public Tourney vote", "voteTourney " @ $Reneg::VoteTourney);
        Client::addMenuItem(%clientId, "4Public OutAreaDam vote", "voteooa " @ $Reneg::VoteOoADamage);
        Client::addMenuItem(%clientId, "5Public Deathstar Vote", "voteDS " @ $Reneg::VoteDeathstar);
        Client::addMenuItem(%clientId, "6Public Timelimit Vote", "voteTL " @ $Reneg::VoteTimeLimit);
        Client::addMenuItem(%clientId, "7Public WeaponsFactory vote", "voteSC " @ $Reneg::VoteSpawnClass);
        Client::addMenuItem(%clientId, "8Public Spawn Match vote", "votesp " @ $Reneg::VoteSpawnMatch);
    }
    
	if (%opt == "toggleWC")
    {
        Client::sendMessage(%clientId, 3, "Weather Control Voting is now " @ isonoff(%cl) @ ".");
        $Reneg::VoteWeather = %cl;
    }
	if (%opt == "toggleBA")
    {
        Client::sendMessage(%clientId, 3, "Base Addons Voting is now " @ isonoff(%cl) @ ".");
        $Reneg::VoteAddons = %cl;
    }
    if (%opt == "toggleTD")
    {
        Client::sendMessage(%clientId, 3, "Team Damage Voting is now " @ isonoff(%cl) @ ".");
        $Reneg::VoteTD = %cl;
    }
    if (%opt == "toggleBD")
    {
        Client::sendMessage(%clientId, 3, "Public Base Rape Vote is now " @ isonoff(%cl) @ ".");
        $Reneg::VoteBD = %cl;
    }
    if (%opt == "togglesp")
    {
        Client::sendMessage(%clientId, 3, "Public Spawn Match is now " @ isonoff(%cl) @ ".");
        $Reneg::Votesp = %cl;
    }
    if (%opt == "toggletourney")
    {
        Client::sendMessage(%clientId, 3, "Tournement Voting is now " @ isonoff(%cl) @ ".");
        $Reneg::VoteTourney = %cl;
    }
    if (%opt == "toggleooa")
    {
        Client::sendMessage(%clientId, 3, "Out of Area Damage Voting is now " @ isonoff(%cl) @ ".");
        $Reneg::VoteOoADamage = %cl;
    }
    if (%opt == "toggleSC")
    {
        Client::sendMessage(%clientId, 3, "WeaponsFactory Voting is now " @ isonoff(%cl) @ ".");
        $Reneg::VoteSpawnClass = %cl;
    }
    if (%opt == "toggleDS")
    {
        Client::sendMessage(%clientId, 3, "Deathstar Voting is now " @ isonoff(%cl) @ ".");
        $Reneg::VoteDeathstar = %cl;
    }
    if (%opt == "toggleTL")
    {
        Client::sendMessage(%clientId, 3, "Timelimit Voting is now " @ isonoff(%cl) @ ".");
        $Reneg::VoteTimeLimit = %cl;
    }
    if (%opt == "patoggle")
    {
        Client::sendMessage(%clientId, 3, "Public Admin Vote is now " @ isonoff(%cl) @ ".");
        $Reneg::VotePA = %cl;
    }
    if (%opt == "cmtoggle")
    {
        Client::sendMessage(%clientId, 3, "Public Mission Vote is now " @ isonoff(%cl) @ ".");
        $Reneg::VoteMission = %cl;
    }
    if (%opt == "pktoggle")
    {
        Client::sendMessage(%clientId, 3, "Public Kick Vote is now " @ isonoff(%cl) @ ".");
        $Reneg::VoteKick = %cl;
    }
    if (%opt == "fairtoggle")
    {
        Client::sendMessage(%clientId, 3, "Fair Teams is now " @ isonoff(%cl) @ ".");
        $Reneg::fairTeams = %cl;
    }
    else if (%opt == "tkserv")
    {
        Client::buildMenu(%clientId, "Current Server Anti-TK: " @ %cl, "ServerLvl", true);
        Client::addMenuItem(%clientId, "0Log TK's only", 0);
        Client::addMenuItem(%clientId, "1Auto Vote TKer", 1);
        Client::addMenuItem(%clientId, "2Auto Vote Until Kicked", 2);
        Client::addMenuItem(%clientId, "3Auto Kick TKer", 3);
        return;
    }
    else if (%opt == "reset")
    {
        Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
        Client::addMenuItem(%clientId, "1Reset", "yes");
        Client::addMenuItem(%clientId, "2Don't Reset", "no");
        return;
    }
    else if (%opt == "tkclient")
    {
        Client::buildMenu(%clientId, "Current Client Anti-TK: " @ %cl, "ClientLvl", true);
        Client::addMenuItem(%clientId, "0Client Vote Option", 0);
        Client::addMenuItem(%clientId, "1Client Kick Option", 1);
        return;
    }
    else if (%opt == "palockout")
    {
        Client::buildMenu(%clientId, "Current Public Admin Lockouts:", "PALockouts", true);
        Client::addMenuItem(%clientId, "1Team Changing " @ isonoff($Reneg::PATeamChange), "teamchange " @ $Reneg::PATeamChange);
        Client::addMenuItem(%clientId, "2Kicking " @ isonoff($Reneg::PAKick), "kick " @ $Reneg::PAKick);
        Client::addMenuItem(%clientId, "3Banning " @ isonoff($Reneg::PABan), "ban " @ $Reneg::PABan);
        Client::addMenuItem(%clientId, "4Change Mission " @ isonoff($Reneg::PAMission), "mission " @ $Reneg::PAMission);
        Client::addMenuItem(%clientId, "5Team Damage " @ isonoff($Reneg::PATeamDamage), "teamdamage " @ $Reneg::PATeamDamage);
        Client::addMenuItem(%clientId, "6Tourney Mode " @ isonoff($Reneg::PATourneyMode), "tourney " @ $Reneg::PATourneyMode);
        Client::addMenuItem(%clientId, "7Time Limit " @ isonoff($Reneg::PATimeLimit), "timelimit " @ $Reneg::PATimeLimit);
        Client::addMenuItem(%clientId, "8Additional Lockouts ...", "additional");
        return;
    }
    else if (%opt == "adminvote")
    {
        Client::buildMenu(%clientId, "Public Admin Vote is " @ isonoff(%cl), "ixsettings", true);
        Client::addMenuItem(%clientId, "0Turn OFF Public Admin", "patoggle false");
        Client::addMenuItem(%clientId, "1Turn ON Public Admin", "patoggle true");
        return;
    }
    else if (%opt == "changevote")
    {
        Client::buildMenu(%clientId, "Public Mission Change Vote is " @ isonoff(%cl), "ixsettings", true);
        Client::addMenuItem(%clientId, "0Turn OFF Mission Change", "cmtoggle false");
        Client::addMenuItem(%clientId, "1Turn ON Mission Change", "cmtoggle true");
        return;
    }
    else if (%opt == "kickvote")
    {
        Client::buildMenu(%clientId, "Public Kick Vote is " @ isonoff(%cl), "ixsettings", true);
        Client::addMenuItem(%clientId, "0Turn OFF Public Kick vote", "pktoggle false");
        Client::addMenuItem(%clientId, "1Turn ON Public Kick vote", "pktoggle true");
        return;
    }
    else if (%opt == "fairvote")
    {
        Client::buildMenu(%clientId, "Fair Teams is " @ isonoff(%cl), "ixsettings", true);
        Client::addMenuItem(%clientId, "0Turn OFF Fair Teams", "fairtoggle false");
        Client::addMenuItem(%clientId, "1Turn ON Fair Teams", "fairtoggle true");
        return;
    }
    else if (%opt == "purge")
    {
        Client::sendMessage(%cl, 3, "Purging All Public Admins of Admin Status.");
        Insomniax_clearPA(%cl);
        Client::sendMessage(%cl, 3, "Purging Complete.");
        return;
    }
    else if (%opt == "Mrestart")
        Server::loadMission($missionName, true);
    if(%opt == "action") 
{ 		
Client::buildMenu(%clientId, "Current Boot Time: " @ $Reneg::StationTime, "aaction", true); 		
Client::addMenuItem(%clientId, "1Disable", 0); 		
Client::addMenuItem(%clientId, "2Set to 10 seconds", 10); 		
Client::addMenuItem(%clientId, "3Set to 20 seconds", 20); 		
Client::addMenuItem(%clientId, "4Set to 30 seconds", 30); 		
Client::addMenuItem(%clientId, "5Set to 40 seconds", 40); 		
Client::addMenuItem(%clientId, "6Set to 60 seconds", 60); 		
Client::addMenuItem(%clientId, "7Set to 80 seconds", 80); 		
Client::addMenuItem(%clientId, "8Set to 100 seconds", 100); 		
return; } 
else if (%opt == "voteTD")
    {
        Client::buildMenu(%clientId, "Team Damage voting: " @ isonoff(%cl), "ixsettings", true);
        Client::addMenuItem(%clientId, "0Turn OFF TD voting", "toggleTD false");
        Client::addMenuItem(%clientId, "1Turn ON TD voting", "toggleTD true");
        return;
    }
    else if (%opt == "voteBD")
    {
        Client::buildMenu(%clientId, "Base Rape Damage  voting: " @ isonoff(%cl), "ixsettings", true);
        Client::addMenuItem(%clientId, "0Turn OFF BD voting", "toggleBD false");
        Client::addMenuItem(%clientId, "1Turn ON BD voting", "toggleBD true");
        return;
    }
    else if (%opt == "votesp")
    {
        Client::buildMenu(%clientId, "Spawn Match   voting: " @ isonoff(%cl), "ixsettings", true);
        Client::addMenuItem(%clientId, "0Turn OFF sp voting", "togglesp false");
        Client::addMenuItem(%clientId, "1Turn ON sp voting", "togglesp true");
        return;
    }
    else if (%opt == "voteWeather")
    {
        Client::buildMenu(%clientId, "Weather Control voting: " @ isonoff(%cl), "ixsettings", true);
        Client::addMenuItem(%clientId, "0Turn OFF Weather Control voting", "toggleWC false");
        Client::addMenuItem(%clientId, "1Turn ON Weather Control voting", "toggleWC true");
        return;
    }
	else if (%opt == "voteAddons")
    {
        Client::buildMenu(%clientId, "Base Addons voting: " @ isonoff(%cl), "ixsettings", true);
        Client::addMenuItem(%clientId, "0Turn OFF Base Addons voting", "toggleBA false");
        Client::addMenuItem(%clientId, "1Turn ON Base Addons voting", "toggleBA true");
        return;
    }
    else if (%opt == "voteTourney")
    {
        Client::buildMenu(%clientId, "Tournement mode voting: " @ isonoff(%cl), "ixsettings", true);
        Client::addMenuItem(%clientId, "0Turn OFF Tourney voting", "toggletourney false");
        Client::addMenuItem(%clientId, "1Turn ON Tourney voting", "toggletourney true");
        return;
    }
    else if (%opt == "voteooa")
    {
        Client::buildMenu(%clientId, "Out of Area voting: " @ isonoff(%cl), "ixsettings", true);
        Client::addMenuItem(%clientId, "0Turn OFF Out-Area voting", "toggleooa false");
        Client::addMenuItem(%clientId, "1Turn ON Out-Area voting", "toggleooa true");
        return;
    }
    else if (%opt == "voteSC")
    {
        Client::buildMenu(%clientId, "WeaponsFactory voting: " @ isonoff(%cl), "ixsettings", true);
        Client::addMenuItem(%clientId, "0Turn OFF WeaponsFactory voting", "toggleSC false");
        Client::addMenuItem(%clientId, "1Turn ON WeaponsFactory voting", "toggleSC true");
        return;
    }
    else if (%opt == "voteDS")
    {
        Client::buildMenu(%clientId, "Deathstar voting: " @ isonoff(%cl), "ixsettings", true);
        Client::addMenuItem(%clientId, "0Turn OFF Deathstar voting", "toggleDS false");
        Client::addMenuItem(%clientId, "1Turn ON Deathstar voting", "toggleDS true");
        return;
    }
    else if (%opt == "voteTL")
    {
        Client::buildMenu(%clientId, "Time Limit voting: " @ isonoff(%cl), "ixsettings", true);
        Client::addMenuItem(%clientId, "0Turn OFF TimeLimit voting", "toggleTL false");
        Client::addMenuItem(%clientId, "1Turn ON TimeLimit voting", "toggleTL true");
        return;
    }
    else if (%opt == "TKdis")
    {
        $tkOverride = 1;
        Client::sendMessage(%clientId, 3, "All server TK functions are now disabled");
    }
    else if (%opt == "TKEna")
    {
        $tkOverride = "";
        Client::sendMessage(%clientId, 3, "Server TK functions are now enabled");
    }
}
function processMenuPALockouts(%clientId, %option)
{
    %opt = getWord(%option, 0);
    %toggle = getWord(%option, 1);
        if(%clientId.isAdmin && !%clientId.isSuperAdmin) return;	// PORT: lockouts are the super admin's (see processMenuIXSettings)
    if (!CheckAdminCond(%clientId))
        return;
    if (%opt == "additional")
    {
        Client::buildMenu(%clientId, "Current Public Admin Lockouts:", "PALockouts", true);
        Client::addMenuItem(%clientId, "1Server Defaults " @ isonoff($Reneg::PAResetDefaults), "reset " @ $Reneg::PAResetDefaults);
        Client::addMenuItem(%clientId, "2Server Options " @ isonoff($Reneg::PAModOptions), "modopt " @ $Reneg::PAModOptions);
        Client::addMenuItem(%clientId, "3Set Team Info " @ isonoff($Reneg::PATeamInfo), "teaminfo " @ $Reneg::PATeamInfo);
        Client::addMenuItem(%clientId, "4Detongue " @ isonoff($Reneg::PADetongue), "detongue " @ $Reneg::PADetongue);
        Client::addMenuItem(%clientId, "5Blowup " @ isonoff($Reneg::PABlowUp), "blowup " @ $Reneg::PABlowUp);
        Client::addMenuItem(%clientId, "6StripVote " @ isonoff($Reneg::PAStripVoteRights), "stripvote " @ $Reneg::PAStripVoteRights);
        Client::addMenuItem(%clientId, "7Out of Area Damage " @ isonoff($Reneg::PAOoADamage), "ooadamage " @ $Reneg::PAOoADamage);
        Client::addMenuItem(%clientId, "8even more...", "evenmore");
        return;
   }
    else if (%opt == "teamchange")
    {
        %access = "Team Changing";
        if (%toggle)
            $Reneg::PATeamChange = "false";
        else
            $Reneg::PATeamChange = "true";
    }
    else if (%opt == "kick")
    {
        %access = "Kicking";
        if (%toggle)
            $Reneg::PAKick = "false";
        else
            $Reneg::PAKick = "true";
    }
    else if (%opt == "ban")
    {
        %access = "Banning";
        if (%toggle)
            $Reneg::PABan = "false";
        else
            $Reneg::PABan = "true";
    }
    else if (%opt == "mission")
    {
        %access = "Changing Mission";
        if (%toggle)
            $Reneg::PAMission = "false";
        else
            $Reneg::PAMission = "true";
    }
    else if (%opt == "teamdamage")
    {
        %access = "Team Damage";
        if (%toggle)
            $Reneg::PATeamDamage = "false";
        else
            $Reneg::PATeamDamage = "true";
    }
    else if (%opt == "tourney")
    {
        %access = "Tourney Mode";
        if (%toggle)
            $Reneg::PATourneyMode = "false";
        else
            $Reneg::PATourneyMode = "true";
    }
    else if (%opt == "timelimit")
    {
        %access = "Mission Time Limit";
        if (%toggle)
            $Reneg::PATimeLimit = "false";
        else
            $Reneg::PATimeLimit = "true";
    }
    else if (%opt == "reset")
    {
        %access = "Reseting Sever to Defaults";
        if (%toggle)
            $Reneg::PAResetDefaults = "false";
        else
            $Reneg::PAResetDefaults = "true";
    }
    else if (%opt == "modopt")
    {
        %access = "Renegadez Mod Options";
        if (%toggle)
            $Reneg::PAModOptions = "false";
        else
            $Reneg::PAModOptions = "true";
    }
    else if (%opt == "teaminfo")
    {
        %access = "Setting Team Info";
        if (%toggle)
            $Reneg::PATeamInfo = "false";
        else
            $Reneg::PATeamInfo = "true";
    }
    else if (%opt == "detongue")
    {
        %access = "detongue";
        if (%toggle)
            $Reneg::PADetongue = "false";
        else
            $Reneg::PADetongue = "true";
    }
    else if (%opt == "blowup")
    {
        %access = "blowup";
        if (%toggle)
            $Reneg::PABlowUp = "false";
        else
            $Reneg::PABlowUp = "true";
    }
    else if (%opt == "stripvote")
    {
        %access = "strip vote";
        if (%toggle)
            $Reneg::PAStripVoteRights = "false";
        else
            $Reneg::PAStripVoteRights = "true";
    }
    else if (%opt == "ooadamage")
    {
        %access = "Out of Area Damage";
        if (%toggle)
            $Reneg::PAOoADamage = "false";
        else
            $Reneg::PAOoADamage = "true";
    }
	else if(%opt == "evenmore")
    {
        Client::buildMenu(%clientId, "More PALockouts:", "PALockouts", true);
        Client::addMenuItem(%clientId, "1Deathstars " @ isonoff($Reneg::PADeathstar), "deathstar " @ $Reneg::PADeathstar);
        Client::addMenuItem(%clientId, "2WeaponsFactory " @ isonoff($Reneg::PASpawnClass), "spawnclass " @ $Reneg::PASpawnClass);
	    Client::addMenuItem(%clientId, "3Base Rape Damage " @ isonoff($BaseRapeDamage), "baserapedamage " @ $BaseRapeDamage);
        Client::addMenuItem(%clientId, "4Spawn Match " @ isonoff($SpawnMatch), "SpawnMatch " @ $SpawnMatch);
	Client::addMenuItem(%clientId, "5Weather Control " @ isonoff($Reneg::PAWeather), "weathercontrol " @ $Reneg::PAWeather);
	
      return;
}  
else if (%opt == "spawnclass")
    {
        %access = "Spawnclass";
        if (%toggle)
            $Reneg::PASpawnClass = "false";
        else
            $Reneg::PASpawnClass = "true";
    }
    else if (%opt == "deathstar")
    {
        %access = "Deathstar";
        if (%toggle)
            $Reneg::PADeathstar = "false";
        else
            $Reneg::PADeathstar = "true";
    }
	else if (%opt == "weathercontrol")
    {
        %access = "WeatherControl";
        if (%toggle)
            $Reneg::PAWeather = "false";
        else
            $Reneg::PAWeather = "true";
    }	
	else if (%opt == "baserapedamage")
    {
        %access = "Base Rape Damage";
        if (%toggle)
            $BaseRapeDamage = "false";
        else
            $BaseRapeDamage = "true";
    }
    else if (%opt == "SpawnMatch")
    {
        %access = "Spawn Match";
        if (%toggle)
            $SpawnMatch = "false";
        else
            $SpawnMatch = "true";
    }
    if (%toggle)
        %toggle = "false";
    else
        %toggle = "true";
    Client::sendMessage(%clientId, 3, "Public Admin Access to " @ %access @ " is now " @ isonoff(%toggle) @ ".");
}
function isonoff(%toggle)
{
    if (%toggle)
        return "On";
    else
        return "Off";
}
function processMenuServerLvl(%clientId, %option)
{
    if(!%clientId.isAdmin) return;	// PORT: no test of the sender
    $Reneg::tkServerLvl = %option;
    if (%option == 0)
        messageAll(1, "SERVER:TK Protection Level Set to Zero. (Logging TK's only).");
    if (%option == 1)
        messageAll(0, "SERVER:TK Protection Level Set to One. (Auto Vote).");
    if (%option == 2)
        messageAll(0, "SERVER:TK Protection Level Set to Two. (Auto Vote Until Kicked).");
    if (%option == 3)
        messageAll(0, "SERVER:TK Protection Level Set to Three. (Auto Kick).");
}
function processMenuaaction(%clientId, %option) { 
if(!%clientId.isSuperAdmin) return;	// PORT: no test of the sender (Station Boot Time is a super admin entry)
if($Reneg::StationTime == %option) { 	
Client::sendMessage(%clientId,1,"SERVER: Station boot time is already "@%option@" seconds.");
return; } 
if(%option == 0) { 
messageAll(3, "SERVER: Stations now will never throw you out."); $Reneg::StationTime = %option; }
else {$Reneg::StationTime = %option; 	
messageAll(3, "SERVER: Stations will now throw you out after " @ %option @ " seconds.");
}
} 
function processMenuClientLvl(%clientId, %option)
{
    if(!%clientId.isAdmin) return;	// PORT: no test of the sender
    $Reneg::tkClientLvl = %option;
    if (%option == 0)
        messageAll(0, "SERVER: Client TK Vote Option Engaged. (From Options Menu).");
    if (%option == 1)
        messageAll(0, "SERVER: Client TK Kick Option Engaged. (From Options Menu).");
}
function Insomniax_ServerLvlTxt()
{
    if($tkOverride)
        %tkText = "TK functions Disabled";
    else if ($Reneg::tkServerLvl == 0)
        %tkText = "Only Logging TK's";
    else if ($Reneg::tkServerLvl == 1)
        %tkText = "Votes at " @ $Reneg::tkLimit @ " TK's";
    else if ($Reneg::tkServerLvl == 2)
        %tkText = "Votes at " @ $Reneg::tkLimit @ " TKs and Kicks at " @ $Reneg::tkLimit * $Reneg::tkMultiple @ " TK's";
    else if ($Reneg::tkServerLvl == 3)
        %tkText = "Kicks at " @ $Reneg::tkLimit @ " TK's";
    else
        %tkText = "ERROR: Server Level set to Unkown Level";
    return %tkText;
}
function Insomniax_ClientLvlTxt()
{
    if ($Reneg::tkClientLvl == 0)
        %tkText = "Vote Option at " @ $Reneg::tkLimit @ " TK's";
    else if ($Reneg::tkClientLvl == 1)
        %tkText = "Kick Option at " @ $Reneg::tkLimit @ "TK's";
    else
        %tkText = "ERROR: Client Level set to Unkown Level";
    return %tkText;
}
function Insomniax_setTeamKill(%victimId, %killerId)
{
    $tkVictim[%killerId] = %victimId;
    $tkKiller[%victimId] = %killerId;
    $tkKills[%killerId] += 1;
    %trigger = $tkKills[%killerId] % $Reneg::tkLimit;
    %tkTopKills = $Reneg::tkLimit * $Reneg::tkMultiple;
    if (($tkKills[%killerId] >= $Reneg::tkLimit) && (!%trigger))
    {
        if ($Reneg::tkServerLvl)
        {
            if ($Reneg::tkServerLvl != 3)
            {
                if (($tkKills[%killerId] >= %tkTopKills) && ($Reneg::tkServerLvl != 1))
                {
                    messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing. Confirmed " @ $tkKills[%killerId] @ " Team Kills.");
                    Admin::Kick(-2, %killerId);
                    return;
                }
                %killerId.voteTarget = true;
                %victimId.selClient = Insomniax_getKiller(%victimId);
                Admin::startVote(%victimId, "Kick Team Killer " @ Client::getName(%killerId), "tkkick", %killerId);
            }
            else
            {
                messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing. Confirmed " @ $tkKills[%killerId] @ " Team Kills.");
                Admin::Kick(-2, %killerId);
            }
        }
    }
    return;
}
function Insomniax_getKiller(%clientId)
{
    return $tkKiller[%clientId];
}
function dodance(%client) 
{ 	
if(!%client.dan) return; 	
%armor = Player::getArmor(%client); 	
if (%armor == "harmor" || %armor == "darmor") 
{ %r = 43 + floor(getRandom() * 2); Player::setAnimation(%client, %r); 		
if(%r == 43) schedule("dodance("@%client@");", 3.1);			
else schedule("dodance("@%client@");", 3.62); 	
} 
else if (%armor == "marmor" || %armor == "barmor" || %armor == "earmor") 
{ 		
Player::setAnimation(%client, 45); schedule("dodance("@%client@");", 3.25); 	
} 
else if (%armor == "mfemale" || %armor == "bfemale" || %armor == "efemale") 
{ 		
Player::setAnimation(%client, 44);schedule("dodance("@%client@");", 2.5); 	
} 
else if (%armor == "larmor" || %armor == "sarmor" || %armor == "spyarmor" || %armor == "dmarmor") 
{ 		
Player::setAnimation(%client, 44); schedule("dodance("@%client@");", 1.45); 	
} 
else if (%armor == "lfemale" || %armor == "sfemale" || %armor == "spyfemale" || %armor == "dmfemale") 
{ 		
Player::setAnimation(%client, 43);schedule("dodance("@%client@");", 1.5); 	
} 
else 
{ 		
Player::setAnimation(%client, 43 + floor(getRandom() * 3)); 		
schedule("dodance("@%client@");", 2.8); 	
} 
} 
function Insomniax_getVictim(%clientId)
{
    return $tkVictim[%clientId];
}
function Insomniax_leaveGame(%clientId)
{
    if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId))
        $tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId];
    if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId))
        $tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId];
    $tkKiller[%clientId] = %clientId;
    $tkVictim[%clientId] = %clientId;
    $tkKills[%clientId] = 0;
    $empTime[%clientId] = 0;
    return;
}
function Insomniax_joinGame(%clientId)
{
    if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId))
        $tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId];
    if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId))
        $tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId];
    $tkVictim[%clientId] = %clientId;
    $tkKiller[%clientId] = %clientId;
    $tkKills[%clientId] = 0;
    $empTime[%clientId] = 0;
}
function Insomniax_clearPA(%admin)
{
    if (%admin.isSuperAdmin)
    {
        %numPlayers = getNumClients();
        for (%i = 0; %i < %numPlayers; %i++)
        {
            %pl = getClientByIndex(%i);
            if (!%pl.isSuperAdmin && %pl.isAdmin)
            {
                %pl.isAdmin = false;
                Client::sendMessage(%pl, 1, "Your Admin Status has been revoked by the Super Admin.");
                Client::sendMessage(%admin, 3, "Public Admin Status Stripped from:" @ Client::getName(%pl) @ ". ");
            }
        }
    }
}
function ixwhoison()
{
    echo("# cl: CLIENT nm: NAME ip: ADDRESS");
    %numPlayers = getNumClients();
    for(%i = 0; %i < %numPlayers; %i++)
    {
        %pl = getClientByIndex(%i);
        %name = Client::getName(%pl);
        %ip = Client::getTransportAddress(%pl);
        echo(" " @ %i @ " cl: " @ %pl @ " nm: " @ %name @ " ip: " @ %ip);
    }
}
function CheckAdminCond(%cl, %lvl)
{
    if ((%cl.isAdmin && %lvl == "") || (%cl.isSuperAdmin && %lvl == 1))
        return true;
    else
    {
        %ip = Client::getTransportAddress(%cl);
        if ($ExportCKicks)
        {
            $AdminExploit = Client::getName(%cl) @ " " @ %ip;
            export("AdminExploit", "config\\KickList.log", true);
            $AdminExploit = "";
        }
        centerprint(%cl, "<jc>For attempting to exploit the admin menus\n you are being Banned until the server resets", 8);
        messageAll(1, "Server: Console Abuse  AutoKicking: " @ Client::getName(%cl));
        BanList::add
            (%ip, -1);
        BanByName::add
            (Client::getName(%cl), 0);
        schedule("Net::kick(" @ %cl @ ");", 8);
        return false;
    }
}
function ixwhoison()
{
    echo("# cl: CLIENT nm: NAME ip: ADDRESS");
    %numPlayers = getNumClients();
    for(%i = 0; %i < %numPlayers; %i++)
    {
        %pl = getClientByIndex(%i);
        %name = Client::getName(%pl);
        %ip = Client::getTransportAddress(%pl);
        echo(" " @ %i @ " cl: " @ %pl @ " nm: " @ %name @ " ip: " @ %ip);
    }
}


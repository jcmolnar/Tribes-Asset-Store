$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;


function Admin::changeMissionMenu(%clientId, %first)
{
  Client::buildMenu(%clientId, "Pick Mission Type", "MissionMenu2", true);
  for(%i = 0; (%misIndex = %i + %first) < $MLIST::TypeCount; %i++)
  {
    if(%i > 6)
    {
      Client::addMenuItem(%clientId, %i + 1 @ "More mission types...", "more " @ %first + %i);
      break;
    }
    if($MLIST::Type[%misIndex] != "Training") Client::addMenuItem(%clientId, %i + 1 @ $MLIST::Type[%misIndex], %misIndex @ " 0");
  }
}


function processMenuMissionMenu2(%clientId, %option)
{
  if(getWord(%option, 0) == "more")
  {
    %first = getWord(%option, 1);
    Admin::changeMissionMenu(%clientId, %first);
    return;
  }
  else processMenuCMType(%clientId, %option);
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
  if(%misType == "" || %misType == "Training") return;
  for(%i = 0; true; %i++)
  {
    %misIndex = getWord($MLIST::MissionList[%mt], %i);
    if(%misIndex == %mi) break;
    if(%misIndex == -1) return;
  }
  if(($Insomniax::PAMission && %clientId.isAdmin) || (%clientId.isSuperAdmin))
  {
    messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
    Vote::changeMission();
    Server::loadMission(%misName);
  }
  else if($Insomniax::PVMission)
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
  else
  {
    if(%user = getWord($ixUserInfo[%client], 0))
    {
      %username = getWord($ixUserInfo[%client], 1);
      %flags = getWord($ixUserInfo[%client], 3);
      %currentName = Client::getName(%client);
      ixProcess(%client,%currentName,%user,%username,%flags,%password);
    }
  }
}


function remoteSetPassword(%client, %password)
{
  if(%client.isSuperAdmin) $Server::Password = %password;
}


function remoteSetTimeLimit(%client, %time)
{
  %time = floor(%time);
  if(%time == $Server::timeLimit || (%time != 0 && %time < 1)) return;
  if((%client.isAdmin && $Insomniax::PATimeLimit) || (%client.isSuperAdmin))
  {
    $Server::timeLimit = %time;
    if(%time) messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s).");
    else messageAll(0, Client::getName(%client) @ " disabled the time limit.");
  }
}


function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
  if(%team >= 0 && %team < 8 && ((%client.isAdmin) || (%client.isSuperAdmin))) if($Insomniax::PATeamInfo)
  {
    $Server::teamName[%team] = %teamName;
    $Server::teamSkin[%team] = %skinBase;
    messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ". Changes will take effect next mission.");
  }
  else
  {
    Client::sendMessage(%client, 1, "Access to ADSetTeamInfo DENIED");
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
      if(%admin == -1) messageAll(0, "Match start countdown forced by vote.");
      else messageAll(0, "Match start countdown forced by " @ Client::getName(%admin));
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
      if(%admin == -1) messageAll(0, "Team damage set to ENABLED by consensus.");
      else messageAll(0, Client::getName(%admin) @ " ENABLED team damage.");
    }
    else
    {
      $Server::TeamDamageScale = 0;
      if(%admin == -1) messageAll(0, "Team damage set to DISABLED by consensus.");
      else messageAll(0, Client::getName(%admin) @ " DISABLED team damage.");
    }
  }
}


function Admin::kick(%admin, %client, %ban)
{
  if(%admin != %client && (%admin == -1 || %admin.isAdmin || %admin == -2 || %admin == -3 || %admin == -4 ))
  {
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
      if(%admin == -1 || %admin == -2 || %admin == -3 || %admin == -4) messageAll(0, "A super admin cannot be " @ %word @ ".");
      else Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
      return;
    }
    %ip = Client::getTransportAddress(%client);
    echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);
    if(%ip == "") return;
    Insomniax_leaveGame(%client);
    if(%ban) BanList::add(%ip, 1800);
    else BanList::add(%ip, $Insomniax::BanKickTime);
    %name = Client::getName(%client);
    if(%admin == -1)
    {
      MessageAll(0, %name @ " was " @ %word @ " from vote.");
      Net::kick(%client, "You were " @ %word @ " by consensus.");
    }
    else if(%admin == -2)
    {
      MessageAll(0, %name @ " was Auto-" @ %word @ " for Team Killing.");
      Net::kick(%client, "You were Auto-" @ %word @ " for Team Killing.");
    }
    else if(%admin == -3)
    {
      MessageAll(0, %name @ " was " @ %word @ " by a TK-Victim.");
      Net::kick(%client, "You were " @ %word @ " by a TK-Victim.");
    }
    else if(%admin == -4)
    {
      MessageAll(0, %name @ " was " @ %word @ " for Trying to Shoot Teammates out of Inventory Stations.");
      Net::kick(%client, "You were " @ %word @ " for Trying to Shoot Teammates out of Inventory Stations.");
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
    if(%clientId == -1) messageAll(0, "Server switched to Free-For-All Mode.");
    else messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".");
    $Server::TourneyMode = false;
    centerprintall();
    if(!$matchStarted && !$countdownStarted)
    {
      if($Phobiax::RandomizedTeams) Phobiax_RandomizeTeams();
      if($Server::warmupTime) Server::Countdown($Server::warmupTime);
      else Game::startMatch();
    }
  }
}


function Admin::setModeTourney(%clientId)
{
  if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
  {
    $Server::TeamDamageScale = 1;
    if(%clientId == -1) messageAll(0, "Server switched to Tournament Mode.");
    else messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".");
    $Server::TourneyMode = true;
    Server::nextMission();
  }
}


function Admin::voteFailed()
{
  $curVoteInitiator.numVotesFailed++;
  if($curVoteAction == "kick" || $curVoteAction == "admin" || $curVoteAction == "tkkick") $curVoteOption.voteTarget = "";
}


function Admin::voteSucceded()
{
  $curVoteInitiator.numVotesFailed = "";
  if($curVoteAction == "kick")
  {
    if($curVoteOption.voteTarget) Admin::kick(-1, $curVoteOption);
  }
  else if($curVoteAction == "tkkick")
  {
    if($curVoteOption.voteTarget) Admin::kick(-2, $curVoteOption);
  }
  else if($curVoteAction == "admin")
  {
    if($curVoteOption.voteTarget)
    {
      $curVoteOption.isAdmin = true;
      messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.");
      if($curVoteOption.menuMode == "options") Game::menuRequest($curVoteOption);
    }
    $curVoteOption.voteTarget = false;
  }
  else if($curVoteAction == "cmission")
  {
    messageAll(0, "Changing to mission " @ $curVoteOption @ ".");
    Vote::changeMission();
    Server::loadMission($curVoteOption);
  }
  else if($curVoteAction == "tourney") Admin::setModeTourney(-1);
  else if($curVoteAction == "ffa") Admin::setModeFFA(-1);
  else if($curVoteAction == "etd") Admin::setTeamDamageEnable(-1, true);
  else if($curVoteAction == "dtd") Admin::setTeamDamageEnable(-1, false);
  else if($curVoteOption == "smatch") Admin::startMatch(-1);
  else if($curVoteAction == "dfteams")
  {
    messageAll(0,"PX-Server: Fair Teams Checking is DISABLED.");
    $Insomniax::FairTeams = "false";
  }
  else if($curVoteAction == "efteams")
  {
    messageAll(0,"PX-Server: Fair Teams Checking is ENABLED.");
    $Insomniax::FairTeams = "true";
  }
  else if($curVoteAction == "drteams")
  {
    messageAll(0,"PX-Server: Team Randomization is DISABLED.");
    $Phobiax::RandomizedTeams = "false";
  }
  else if($curVoteAction == "erteams")
  {
    messageAll(0,"PX-Server: Team Randomization is ENABLED.");
    $Phobiax::RandomizedTeams = "true";
  }
}


function Admin::countVotes(%curVote)
{
  if(%curVote != $curVoteCount) return;
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
    else %votesAbstain++;
  }
  %minVotes = floor($Server::MinVotesPct * %totalClients);
  if(%minVotes < $Server::MinVotes) %minVotes = $Server::MinVotes;
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
    if(%totalVotes < %minVotes) %totalVotes = %minVotes;
  }
  if(%votesFor / %totalVotes >= %margin)
  {
    messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
    Admin::voteSucceded();
  }
  else
  {
    if($curVoteAction == "kick" || $curVoteAction == "tkkick")
    {
      %votesFor = 0;
      %totalVotes = 0;
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
        if(GameBase::getTeam(%cl) == $curVoteOption.kickTeam)
        {
          %totalVotes++;
          if(%cl.vote == "yes") %votesFor++;
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
  if(%clientId.lastVoteTime == "") %clientId.lastVoteTime = -$Server::MinVoteTime;
  %time = getIntegerTime(true) >> 5;
  %diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time;
  if(%diff > 0)
  {
    Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
    return;
  }
  if($curVoteTopic == "")
  {
    if(%clientId.numFailedVotes) %time += %clientId.numFailedVotes * $Server::VoteFailTime;
    %clientId.lastVoteTime = %time;
    $curVoteInitiator = %clientId;
    $curVoteTopic = %topic;
    $curVoteAction = %action;
    $curVoteOption = %option;
    $curVoteCount++;
    if(%action == "kick") $curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
    if(%action == "tkkick")
    {
      %IXtker = getWord(%topic, 3);
      %IXtkKills = $tkKills[%option];
      bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic @ "\n <f2>" @ %IXtker @ " <f0> has a Confirmed <f2>" @ %IXtkKills @ " TEAM KILLS", 10);
      $curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
    }
    else bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
    for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) %cl.vote = "";
    %clientId.vote = "yes";
    for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) if(%cl.menuMode == "options") Game::menuRequest(%clientId);
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
  Client::buildMenu(%clientId, "Options", "options", true);
  if((!$matchStarted || !$Server::TourneyMode) && !%clientId.selClient && !%clientId.restrained)
  {
    Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
  }
  if(%clientId.selClient)
  {
    %sel = %clientId.selClient;
    %name = Client::getName(%sel);
    if($curVoteTopic == "" && !%clientId.isSuperAdmin)
    {
      if($Insomniax::PAVote && !%sel.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
      if($Insomniax::PAKick && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
      else if($Insomniax::PVKick) Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick " @ %name, "vkick " @ %sel);
      if($Insomniax::PABan && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
      if($Phobiax::PARestrain && %clientId.isAdmin)
      {
        if(%sel.restrained) Client::addMenuItem(%clientId, %curItem++ @ "Unrestrain " @ %name, "unrestrain " @ %sel);
        else Client::addMenuItem(%clientId, %curItem++ @ "Restrain " @ %name, "restrain " @ %sel);
      }
      if(!%sel.restrained)
      {
        if($Insomniax::PAGag && %clientId.isAdmin)
        {
          if(%sel.gagged) Client::addMenuItem(%clientId, %curItem++ @ "Ungag " @ %name, "ungag " @ %sel);
          else Client::addMenuItem(%clientId, %curItem++ @ "Gag " @ %name, "gag " @ %sel);
        }
        if($Insomniax::PATeamChange && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
      }
    }
    else if(%clientId.isSuperAdmin)
    {
      if(!%sel.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
      Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
      Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
      if(%sel.restrained) Client::addMenuItem(%clientId, %curItem++ @ "Unrestrain " @ %name, "unrestrain " @ %sel);
      else Client::addMenuItem(%clientId, %curItem++ @ "Restrain " @ %name, "restrain " @ %sel);
      if(!%sel.restrained)
      {
        if(%sel.gagged) Client::addMenuItem(%clientId, %curItem++ @ "Ungag " @ %name, "ungag " @ %sel);
        else Client::addMenuItem(%clientId, %curItem++ @ "Gag " @ %name, "gag " @ %sel);
        Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
      }
    }
    if(%clientId.muted[%sel]) Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
    else Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
    if(Observer::isObserver(%clientId) && !Observer::isObserver(%sel)) Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
  }
  else if($curVoteTopic != "" && %clientId.vote == "")
  {
    Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
    Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
  }
  else if($curVoteTopic == "" && !%clientId.isSuperAdmin)
  {
    if(%clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Public Admin Options", "publicAdminOptions");
    if($Insomniax::PAModOptions && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "PX-Admin Settings", "insomniax");
    if(!%clientId.isAdmin && !%clientId.restrained) Client::addMenuItem(%clientId, %curItem++ @ "Voting Options", "publicVoteOptions");
    if($Insomniax::PSkin) if(%clientId.custom) Client::addMenuItem(%clientId, %curItem++ @ "Use Server Skins", "pskin off");
    else Client::addMenuItem(%clientId, %curItem++ @ "Use Personal Skins", "pskin on");
    if(!%clientId.isAdmin && !%clientId.restrained)
    {
      %IXKiller = Insomniax_getKiller(%clientId);
      if((%IXKiller != %clientId) && ($tkKills[%IXKiller] >= $Insomniax::tkLimit))
      {
        if($Insomniax::tkClientLvl == 1) Client::addMenuItem(%clientId, %curItem++ @ "Kick Team Killer " @ Client::getName(Insomniax_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller)));
        else Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick " @ Client::getName(Insomniax_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller)));
      }
    }
  }
  else if(%clientId.isSuperAdmin)
  {
    Client::addMenuItem(%clientId, %curItem++ @ "Super Admin Options", "superAdminOptions");
    Client::addMenuItem(%clientId, %curItem++ @ "PX-Admin Settings", "insomniax");
    if($Insomniax::PSkin) if(%clientId.custom) Client::addMenuItem(%clientId, %curItem++ @ "Use Server Skins", "pskin off");
    else Client::addMenuItem(%clientId, %curItem++ @ "Use Personal Skins", "pskin on");
  }
  if(!%clientId.selClient)
  {
    if($Phobiax::ExpansionItems && !Observer::isObserver(%clientId)) Client::addMenuItem(%clientId, %curItem++ @ "Select Mine Type", "pxmines");
    %playerId = Client::getOwnedObject(%clientId);
    if(Player::getMountedItem(%playerId,$BackpackSlot) == "Vengeance" || Player::getMountedItem(%playerId,$BackpackSlot) == "DoomsdayPack") Client::addMenuItem(%clientId, %curItem++ @ "Vengeance Options", "vengeance");
    if(Player::getMountedItem(%playerId,$BackpackSlot) == "BoomBoxPack" || Player::getMountedItem(%playerId,$BackpackSlot) == "BoomBoxDetPack") Client::addMenuItem(%clientId, %curItem++ @ "Change Boom Box Timer", "boomboxtimer");
    if(Player::getMountedItem(%playerId,$WeaponSlot) == "TazerBeamGun") Client::addMenuItem(%clientId, %curItem++ @ "Change Tazer Mode", "tazer setbolt");
    else if(Player::getMountedItem(%playerId,$WeaponSlot) == "TazerBoltGun") Client::addMenuItem(%clientId, %curItem++ @ "Change Tazer Mode", "tazer setbeam");
    if((%itmCount = Group::objectCount(%clientId.deployables)) > 0) Client::addMenuItem(%clientId, %curItem++ @ "Deployables", "deployables " @ %itmCount);
  }
  if(%clientId.observerMode == "observerOrbit") Client::addMenuItem(%clientId, %curItem++ @ "Observer Options", "obsoptions");
  if(!%clientId.selClient && %curItem < 8) Client::addMenuItem(%clientId, %curItem++ @ "Item Help Menu", "help");
}


function remoteSelectClient(%clientId, %selId)
{
  if(%clientId.selClient != %selId)
  {
    %clientId.selClient = %selId;
    if(%clientId.menuMode == "options") Game::menuRequest(%clientId);
    if(Insomniax_getVictim(%selId) == %selId) %selLastTK = "None Here";
    else %selLastTK = Client::getName(Insomniax_getVictim(%selId));
    if(Insomniax_getKiller(%selId) == %selId) %selTKdBy = "None Here";
    else %selTKdBy = Client::getName(Insomniax_getKiller(%selId));
    %selKills = $tkKills[%selId];
    remoteEval(%clientId, "setInfoLine", 1, "Team Kill Info for " @ Client::getName(%selId) @ ":");
    remoteEval(%clientId, "setInfoLine", 2, "Last TK Victim: " @ %selLastTK);
    remoteEval(%clientId, "setInfoLine", 3, "Last TK'd By: " @ %selTKdBy);
    remoteEval(%clientId, "setInfoLine", 4, "Number of TKs: " @ %selKills);
    remoteEval(%clientId, "setInfoLine", 5, "Server: " @ Insomniax_ServerLvlTxt());
    if(%clientId.isSuperAdmin) remoteEval(%clientId, "setInfoLine", 6, "Client: " @ Client::getTransportAddress(%selId));
    else remoteEval(%clientId, "setInfoLine", 6, "Client: " @ Insomniax_ClientLvlTxt());
  }
}


function processMenuFPickTeam(%clientId, %team)
{
  if(IxPort::PA(%clientId, $Insomniax::PATeamChange)) processMenuPickTeam(%clientId.ptc, %team, %clientId);
  %clientId.ptc = "";
}


function processMenuPickTeam(%clientId, %team, %adminClient)
{
  if(%clientId.restrained)
  {
    if(%adminClient == "")
    {
      %text = "<jc><f2>--- You have been Restrained ---<f0>\n \nYou may not change teams while being restrained.";
      bottomprint(%clientId, %text, 10);
    }
    else
    {
      if(!String::ICompare(Client::getGender(%playerId), "Male")) %gender = "his";
      else %gender = "her";
      Client::sendMessage(%adminClient, 0, "PX-Server: " @ Client::getName(%clientId) @ " is under Restraints. You cannot change " @ %gender @ " team.");
    }
    return;
  }
  checkPlayerCash(%clientId);
  %teamnow = Client::getTeam(%clientId);
  if(%team != -1 && %team == %teamnow) return;
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
      if(%adminClient == "") messageAll(0, Client::getName(%clientId) @ " became an observer.");
      else messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
      Game::resetScores(%clientId);
      Game::refreshClientScore(%clientId);
    }
    return;
  }
  %change = false;
  if(!$Insomniax::FairTeams)
  {
    if(%team == -1)
    {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
    }
    if(%adminClient == "") messageAll(0, Client::getName(%clientId) @ " changed teams.");
    else messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
    %change = true;
    deleteObject(%clientId.deployables);
    %clientId.deployables = newObject("set",SimSet);
  }
  else
  {
    if(%team == -1)
    {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
      if(%adminClient == "") messageAll(0, Client::getName(%clientId) @ " changed teams to make it fair.");
      else messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ " to even the Teams.");
      %change = true;
    }
    else
    {
      if(Insomniax_isFairTeam(%teamnow, %team))
      {
        if(%adminClient == "") messageAll(0, Client::getName(%clientId) @ " changed teams to make it fair.");
        else messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ " to even the Teams.");
        %change = true;
      }
      else
      {
        if(%adminClient == "")
        {
          messageAll(0, Client::getName(%clientId) @ " tried to make the teams even more unfair.");
          %change = false;
        }
        else
        {
          messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
          %change = true;
        }
      }
    }
  }
  if(%change)
  {
    %player = Client::getOwnedObject(%clientId);
    if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
    {
      playNextAnim(%clientId);
      Player::kill(%clientId);
    }
    %clientId.observerMode = "";
    GameBase::setTeam(%clientId, %team);
    %clientId.teamEnergy = 0;
    deleteObject(%clientId.deployables);
    %clientId.deployables = newObject("set",SimSet);
    Client::clearItemShopping(%clientId);
    if(Client::getGuiMode(%clientId) != 1) Client::setGuiMode(%clientId,1);
    Client::setControlObject(%clientId, -1);
    Game::playerSpawn(%clientId, false);
    %team = Client::getTeam(%clientId);
    if($TeamEnergy[%team] != "Infinite") $TeamEnergy[%team] += $InitialPlayerEnergy;
    if($Server::TourneyMode && !$CountdownStarted)
    {
      bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
      %clientId.notready = true;
    }
  }
}


function IxPort::PA(%clientId, %allowed) { if(%clientId.isSuperAdmin) return true; if(%clientId.isAdmin && %allowed) return true; return false; } function processMenuOptions(%clientId, %option)
{
  %opt = getWord(%option, 0);
  %cl = getWord(%option, 1);
  if(%opt == "fteamchange" && IxPort::PA(%clientId, $Insomniax::PATeamChange))
  {
    %clientId.ptc = %cl;
    Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
    Client::addMenuItem(%clientId, "0Observer", -2);
    Client::addMenuItem(%clientId, "1Automatic", -1);
    for(%i = 0; %i < getNumTeams(); %i = %i + 1) Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
    return;
  }
  else if(%opt == "changeteams")
  {
    if(!$matchStarted || !$Server::TourneyMode)
    {
      Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
      Client::addMenuItem(%clientId, "0Observer", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1) Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      return;
    }
  }
  else if(%opt == "obsoptions")
  {
    %angle = $pxObserverAngle[%clientId];
    Client::buildMenu(%clientId, "Observer Options:", "ObsOptions", true);
    Client::addMenuItem(%clientId, %now++ @ "Reset to Default", "reset");
    Client::addMenuItem(%clientId, %now++ @ "Camera Angle: " @ $pxObserverText[%angle], "camera");
    if(%angle != "First")
    {
      Client::addMenuItem(%clientId, %now++ @ "Increase Range", "+2");
      Client::addMenuItem(%clientId, %now++ @ "Decrease Range", "-2");
    }
    return;
  }
  else if(%opt == "mute") %clientId.muted[%cl] = true;
  else if(%opt == "unmute") %clientId.muted[%cl] = "";
  else if(%opt == "vkick" && $Insomniax::PVKick)
  {
    %cl.voteTarget = true;
    Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
  }
  else if(%opt == "vadmin" && $Insomniax::PAVote)
  {
    %cl.voteTarget = true;
    Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
  }
  else if(%opt == "vsmatch" && $Insomniax::PVTourneyMode) Admin::startVote(%clientId, "start the match", "smatch", 0);
  else if(%opt == "vetd" && $Insomniax::PVTeamDamage) Admin::startVote(%clientId, "enable team damage", "etd", 0);
  else if(%opt == "vdtd" && $Insomniax::PVTeamDamage) Admin::startVote(%clientId, "disable team damage", "dtd", 0);
  else if(%opt == "etd" && IxPort::PA(%clientId, $Insomniax::PATeamDamage)) Admin::setTeamDamageEnable(%clientId, true);
  else if(%opt == "dtd" && IxPort::PA(%clientId, $Insomniax::PATeamDamage)) Admin::setTeamDamageEnable(%clientId, false);
  else if(%opt == "vcffa" && $Insomniax::PVTourneyMode) Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
  else if(%opt == "vctourney" && $Insomniax::PVTourneyMode) Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
  else if(%opt == "cffa" && IxPort::PA(%clientId, $Insomniax::PATourneyMode)) Admin::setModeFFA(%clientId);
  else if(%opt == "ctourney" && IxPort::PA(%clientId, $Insomniax::PATourneyMode)) Admin::setModeTourney(%clientId);
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
  else if(%opt == "kick")
  {
    Client::buildMenu(%clientId, "Confirm Kick:", "kaffirm", true);
    Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
    Client::addMenuItem(%clientId, "2Don't Kick " @ Client::getName(%cl), "no " @ %cl);
    return;
  }
  else if(%opt == "admin" && %clientId.isSuperAdmin)
  {
    Client::buildMenu(%clientId, "Confirm Admim:", "aaffirm", true);
    Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
    Client::addMenuItem(%clientId, "2Don't Admin " @ Client::getName(%cl), "no " @ %cl);
    return;
  }
  else if(%opt == "ban")
  {
    Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
    Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
    Client::addMenuItem(%clientId, "2Don't Ban " @ Client::getName(%cl), "no " @ %cl);
    return;
  }
  else if(%opt == "restrain")
  {
    if(!IxPort::PA(%clientId, $Phobiax::PARestrain)) return;   // PORT FIX: menu codes come from the client
    Client::buildMenu(%clientId, "Confirm Restrain:", "restaffirm", true);
    Client::addMenuItem(%clientId, "1Restrain " @ Client::getName(%cl), "yes " @ %cl);
    Client::addMenuItem(%clientId, "2Don't Restrain " @ Client::getName(%cl), "no " @ %cl);
    return;
  }
  else if(%opt == "unrestrain")
  {
  if(!IxPort::PA(%clientId, $Phobiax::PARestrain)) return;   // PORT FIX
    %cl.restrained = false;
    %cl.restrainTime = "";
    %cl.gagged = false;
    ixAdminMsg(Client::getName(%clientId) @ " has Unrestrained " @ Client::getName(%cl));
    pxRestrainClient(%cl);
  }
  else if(%opt == "gag" && IxPort::PA(%clientId, $Insomniax::PAGag))   // PORT FIX
  {
    %cl.gagged = true;
    ixAdminMsg(Client::getName(%clientId) @ " has Gagged " @ Client::getName(%cl));
    Client::sendMessage(%cl,0,"PX-Server: You have been Gagged by the Server Admin.");
  }
  else if(%opt == "ungag" && IxPort::PA(%clientId, $Insomniax::PAGag))
  {
    %cl.gagged = false;
    ixAdminMsg(Client::getName(%clientId) @ " has Ungagged " @ Client::getName(%cl));
    Client::sendMessage(%cl,0,"PX-Server: Your Gag has been removed by the Admin.");
  }
  else if(%opt == "smatch" && IxPort::PA(%clientId, $Insomniax::PATourneyMode)) Admin::startMatch(%clientId);
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
    Client::addMenuItem(%clientId, "1Reset Server", "reset");
    Client::addMenuItem(%clientId, "2Cancel", "cancel");
    return;
  }
  else if(%opt == "randomizeteams")
  {
    Client::buildMenu(%clientId, "Confirm Team Reset:", "randaffirm", true);
    Client::addMenuItem(%clientId, "1Randomized Teams", "randomize");
    Client::addMenuItem(%clientId, "2Cancel", "cancel");
    return;
  }
  else if(%opt == "observe")
  {
    if(%clientId.observerMode == "observerFly")
    {
      %clientId.observerMode = "observerOrbit";
      %clientId.observerTarget = %cl;
    }
    Observer::setTargetClient(%clientId, %cl);
    return;
  }
  else if(%opt == "disableFT" && IxPort::PA(%clientId, $Insomniax::PAFairTeams))
  {
    ixAdminMsg("Command: " @ Client::getName(%clientId) @ " - Fair Teams Checking is DISABLED.");
    $Insomniax::FairTeams = "false";
  }
  else if(%opt == "enableFT" && IxPort::PA(%clientId, $Insomniax::PAFairTeams))
  {
    ixAdminMsg("Command: " @ Client::getName(%clientId) @ " - Fair Teams Checking is ENABLED.");
    $Insomniax::FairTeams = "true";
  }
  else if(%opt == "vdisableFT" && $Insomniax::PVFairTeams)
  {
    %cl.voteTarget = true;
    Admin::startVote(%clientId, "Disable Fair Teams", "dfteams", %cl);
  }
  else if(%opt == "venableFT" && $Insomniax::PVFairTeams)
  {
    %cl.voteTarget = true;
    Admin::startVote(%clientId, "Enable Fair Teams", "efteams", %cl);
  }
  else if(%opt == "disableRT")
  {
  if(!IxPort::PA(%clientId, $Phobiax::PARandTeams)) return;   // PORT FIX
    ixAdminMsg("Command: " @ Client::getName(%clientId) @ " - Team Randomization is DISABLED.");
    $Phobiax::RandomizedTeams = "false";
  }
  else if(%opt == "enableRT")
  {
  if(!IxPort::PA(%clientId, $Phobiax::PARandTeams)) return;   // PORT FIX
    ixAdminMsg("Command: " @ Client::getName(%clientId) @ " - Team Randomization is ENABLED.");
    $Phobiax::RandomizedTeams = "true";
  }
  else if(%opt == "vdisableRT")
  {
  if(!$Phobiax::PVRandTeams) return;   // PORT FIX
    %cl.voteTarget = true;
    Admin::startVote(%clientId, "Disable Randomized Teams Teams", "drteams", %cl);
  }
  else if(%opt == "venableRT")
  {
  if(!$Phobiax::PVRandTeams) return;   // PORT FIX
    %cl.voteTarget = true;
    Admin::startVote(%clientId, "Enable Randomized Teams", "erteams", %cl);
  }
  else if(%opt == "insomniax" && IxPort::PA(%clientId, $Insomniax::PAModOptions))
  {
    %now = 0;
    Client::buildMenu(%clientId, "PX-Admin Settings:", "ixsettings", true);
    Client::addMenuItem(%clientId, %now++ @ "Server: Anti-TK Lvl", "tkserv " @ $Insomniax::tkServerLvl);
    Client::addMenuItem(%clientId, %now++ @ "Client: Anti-TK Lvl", "tkclient " @ $Insomniax::tkClientLvl);
    Client::addMenuItem(%clientId, %now++ @ "Out of Bounds Kill", "areakill " @ $Insomniax::LeaveAreaTime);
    if($Insomniax::PSkin) Client::addMenuItem(%clientId, %now++ @ "Disable Personal Skins", "disablepskin " @ %clientId);
    else Client::addMenuItem(%clientId, %now++ @ "Enable Personal Skins", "enablepskin " @ %clientId);
    if($Insomniax::SafeStation) Client::addMenuItem(%clientId, %now++ @ "Disable Safe Stations", "dsafestation " @ %clientId);
    else Client::addMenuItem(%clientId, %now++ @ "Enable Safe Stations", "esafestation " @ %clientId);
    if(%clientId.isSuperAdmin) Client::addMenuItem(%clientId, %now++ @ "Set Inv. Station Time", "stationtime " @ $Insomniax::StationTime);
    if(%clientId.isSuperAdmin) Client::addMenuItem(%clientId, %now++ @ "Admin Controls", "admincontrols");
    if(!$ModModeSwitching)
    {
      if($Phobiax::ExpansionItems) Client::addMenuItem(%clientId, %now++ @ "Switch to Insomniax Mode", "modmode Insomniax");
      else Client::addMenuItem(%clientId, %now++ @ "Switch to Phobiax Mode", "modmode Phobiax");
    }
    return;
  }
  else if(%opt == "pskin")
  {
    if(%cl == "on")
    {
      %clientId.custom = true;
      bottomprint(%clientId,"<jc><f2>Custom Skins Enabled.\n<f1>Changes Take Place on Next Respawn", 5);
    }
    else
    {
      %clientId.custom = false;
      bottomprint(%clientId,"<jc><f2>Custom Skins Disabled.\n<f1>Changes Take Place on Next Respawn", 5);
    }
  }
  else if(%opt == "tkopt"&& !%clientId.isAdmin && Insomniax_getKiller(%clientId) != %clientId && $tkKills[Insomniax_getKiller(%clientId)] >= $Insomniax::tkLimit) { %cl = Insomniax_getKiller(%clientId);
    if($Insomniax::tkClientLvl == 1)
    {
      Admin::Kick(-3, Insomniax_getKiller(%clientId));
      return;
    }
    else
    {
      %cl.voteTarget = true;
      %clientId.selClient = Insomniax_getKiller(%clientId);
      Admin::startVote(%clientId, "Kick Team Killer " @ Client::getName(%cl), "tkkick", %cl);
      return;
    }
  }
  else if(%opt == "vengeance")
  {
    %now = 0;
    if(!$Phobiax::ExpansionItems) %clientId.DoomsdayMode = 0;
    if(%clientId.DoomsdayMode == 1)
    {
      Client::buildMenu(%clientId, "Vengeance Options:", "Vengeance", true);
      Client::addMenuItem(%clientId, %now++ @ "Deactivate Doomsday", "doomsdayoff");
      return;
    }
    else if(%clientId.DoomsdayMode == 0)
    {
      Client::buildMenu(%clientId, "Vengeance Options:", "Vengeance", true);
      if($Phobiax::ExpansionItems) Client::addMenuItem(%clientId, %now++ @ "Activate Doomsday", "doomsdayon");
      Client::addMenuItem(%clientId, %now++ @ "Set Vengeance Payload", "payload");
      Client::addMenuItem(%clientId, %now++ @ "Set Vengeance Scan", "scan");
      Client::addMenuItem(%clientId, %now++ @ "Set Vengeance Warhead", "warhead");
      Client::addMenuItem(%clientId, %now++ @ "Choose Vengeance Pre-Set", "preset");
      return;
    }
  }
  else if(%opt == "pxmines")
  {
    %mineType = $pxMineLoadout[%clientId];
    if(%mineType == "Antipersonel") %mineType = "Default";
    %now = 0;
    Client::buildMenu(%clientId, "Current Type: " @ %mineType, "PXMines", true);
    Client::addMenuItem(%clientId, %now++ @ "Reset Default Mines", "default");
    Client::addMenuItem(%clientId, %now++ @ "Set Cloaked Mines", "cloaked");
    Client::addMenuItem(%clientId, %now++ @ "Set Concussion Mines", "concussion");
    Client::addMenuItem(%clientId, %now++ @ "Set EMP Mines", "emp");
    return;
  }
  else if(%opt == "boomboxtimer")
  {
    %now = 0;
    Client::buildMenu(%clientId, "Current Timer: " @ $BoomBoxTimer[%clientId], "BoomBox", true);
    Client::addMenuItem(%clientId, %now++ @ "Reset to Default", "reset");
    Client::addMenuItem(%clientId, %now++ @ " + 1:00", "+60");
    Client::addMenuItem(%clientId, %now++ @ " + 0:15", "+15");
    Client::addMenuItem(%clientId, %now++ @ " + 0:05", "+05");
    Client::addMenuItem(%clientId, %now++ @ " - 0:05", "-05");
    Client::addMenuItem(%clientId, %now++ @ " - 0:15", "-15");
    Client::addMenuItem(%clientId, %now++ @ " - 1:00", "-60");
    return;
  }
  else if(%opt == "tazer")
  {
    if(%cl == "setbolt")
    {
      Player::unmountItem(%clientId, $WeaponSlot);
      Player::setItemCount(%clientId, TazerBeamGun, 0);
      Player::setItemCount(%clientId, TazerBoltGun, 1);
      Player::mountItem(%clientId, TazerBoltGun, $WeaponSlot);
      bottomprint(%clientId,"<jc><f1>Tazer is set to Burst Mode.",5);
      return;
    }
    else if(%cl == "setbeam")
    {
      Player::unmountItem(%clientId, $WeaponSlot);
      Player::setItemCount(%clientId, TazerBoltGun, 0);
      Player::setItemCount(%clientId, TazerBeamGun, 1);
      Player::mountItem(%clientId, TazerBeamGun, $WeaponSlot);
      bottomprint(%clientId,"<jc><f1>Tazer is set to Continuous Mode.",5);
      return;
    }
  }
  else if(%opt == "publicVoteOptions")
  {
    %curItem = 0;
    Client::buildMenu(%clientId, "Voting Options:", "Options", true);
    if($Insomniax::PVMission) Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
    if($Insomniax::PVTeamDamage)
    {
      if($Server::TeamDamageScale == 1.0) Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
      else Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
    }
    if($Insomniax::PVFairTeams)
    {
      if($Insomniax::FairTeams) Client::addMenuItem(%clientId, %curItem++ @ "Vote to Disable Fair Teams", "vdisableFT " @ %clientId);
      else Client::addMenuItem(%clientId, %curItem++ @ "Vote to Enable Fair Teams", "venableFT " @ %clientId);
    }
    if($Phobiax::PVRandTeams)
    {
      if($Phobiax::PVRandTeams) Client::addMenuItem(%clientId, %curItem++ @ "Vote to Disable Randomized Teams", "vdisableRT " @ %clientId);
      else Client::addMenuItem(%clientId, %curItem++ @ "Vote to Enable Randomized Teams", "venableRT " @ %clientId);
    }
    if($Insomniax::PVTourneyMode)
    {
      if($Server::TourneyMode)
      {
        Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
        if(!$CountdownStarted && !$matchStarted) Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
      }
      else Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
    }
    return;
  }
  else if(%opt == "publicAdminOptions" && %clientId.isAdmin)
  {
    %curItem = 0;
    Client::buildMenu(%clientId, "Public Admin Options:", "Options", true);
    if($Insomniax::PAMission && %clientId.isAdmin)
    {
      Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
    }
    else
    {
      if($Insomniax::PVMission) Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
    }
    if($Insomniax::PATeamDamage && %clientId.isAdmin)
    {
      if($Server::TeamDamageScale == 1.0) Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
      else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
    }
    else
    {
      if($Insomniax::PVTeamDamage)
      {
        if($Server::TeamDamageScale == 1.0) Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
        else Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
      }
    }
    if($Insomniax::PAFairTeams && %clientId.isAdmin)
    {
      if($Insomniax::FairTeams) Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "disableFT " @ %clientId);
      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "enableFT " @ %clientId);
    }
    else
    {
      if($Insomniax::PVFairTeams)
      {
        if($Insomniax::FairTeams) Client::addMenuItem(%clientId, %curItem++ @ "Vote to Disable Fair Teams", "vdisableFT " @ %clientId);
        else Client::addMenuItem(%clientId, %curItem++ @ "Vote to Enable Fair Teams", "venableFT " @ %clientId);
      }
    }
    if($Phobiax::PARandTeams && %clientId.isAdmin)
    {
      if($Phobiax::RandomizedTeams)
      {
        Client::addMenuItem(%clientId, %curItem++ @ "Disable Randomized Teams", "disableRT " @ %clientId);
        if(!$Server::TourneyMode) Client::addMenuItem(%clientId, %curItem++ @ "Randomize Teams Now", "randomizeteams " @ %clientId);
      }
      else Client::addMenuItem(%clientId, %curItem++ @ "Enable Randomized Teams", "enableRT " @ %clientId);
    }
    else
    {
      if($Phobiax::PVRandTeams)
      {
        if($Phobiax::RandomizedTeams) Client::addMenuItem(%clientId, %curItem++ @ "Vote to Disable Randomized Teams", "vdisableRT " @ %clientId);
        else Client::addMenuItem(%clientId, %curItem++ @ "Vote to Enable Randomized Teams", "venableRT " @ %clientId);
      }
    }
    if($Insomniax::PATourneyMode && %clientId.isAdmin)
    {
      if($Server::TourneyMode)
      {
        Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
        if(!$CountdownStarted && !$matchStarted) Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
      }
      else Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
    }
    else
    {
      if($Insomniax::PVTourneyMode)
      {
        if($Server::TourneyMode)
        {
          Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
          if(!$CountdownStarted && !$matchStarted) Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
        }
        else Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
      }
    }
    if($Insomniax::PATimeLimit && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
    if($Insomniax::PAResetDefaults && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
    return;
  }
  else if(%opt == "superAdminOptions" && %clientId.isSuperAdmin)
  {
    %curItem = 0;
    Client::buildMenu(%clientId, "Super Admin Options:", "Options", true);
    Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
    if($Server::TeamDamageScale == 1.0) Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
    else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
    if($Insomniax::FairTeams) Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "disableFT " @ %clientId);
    else Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "enableFT " @ %clientId);
    if($Phobiax::RandomizedTeams)
    {
      Client::addMenuItem(%clientId, %curItem++ @ "Disable Randomized Teams", "disableRT " @ %clientId);
      if(!$Server::TourneyMode) Client::addMenuItem(%clientId, %curItem++ @ "Randomize Teams Now", "randomizeteams");
    }
    else Client::addMenuItem(%clientId, %curItem++ @ "Enable Randomized Teams", "enableRT " @ %clientId);
    if($Server::TourneyMode)
    {
      Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
      if(!$CountdownStarted && !$matchStarted) Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
    }
    else Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
    Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
    Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
    return;
  }
  else if(%opt == "deployables")
  { %cl = Group::objectCount(%clientId.deployables);
    %items = "";
    for(%j = 0; %j < %cl; %j++)
    {
      %turret = Group::getObject(%clientId.deployables,%j);
      if(!%turret.packing) %items = %items @ %turret @ " ";
    }
    Client::buildMenu(%clientId, "Remote Pack-up/Destroy:", "Deployables", true);
    for(%i = 0; (%i < 7) && (%i < %cl); %i++) Client::addMenuItem(%clientId, (%i + 1) @ GameBase::getMapName(getWord(%items,%i)), "packup " @ %cl @ " " @ %i);
    if(%cl > 7)
    {
      Client::addMenuItem(%clientId, (%i + 1) @ "More Deployables...", "more " @ %cl @ " " @ %i);
    }
    return;
  }
  if(%opt == "help")
  {
    processMenuHelp(%clientId, "main");
    if(!%clientId.beenHelped)
    {
      %text = "<jl><f1>";
      %text = %text @ "   For a more detailed explanation of the items in this mod, visit the following websites:\n<f1>";
      %text = %text @ "    - <f2>http://www.tribesplayers.com/<f1>\n";
      %text = %text @ "    - <f2>http://www.insomniax.net/mods/<f1>\n";
      %text = %text @ "    - <f2>http://phobiax.thisplacehere.com/";
      bottomPrint(%clientId, %text, 30);
      %clientId.beenHelped = true;
    }
    return;
  }
  Game::menuRequest(%clientId);
}


function processMenuHelp(%clientId, %topic)
{
  if(%topic == "main")
  {
    Client::buildMenu(%clientId, "Help: Main", "help", true);
    Client::addMenuItem(%clientId, "1Weapons", "weapons");
    Client::addMenuItem(%clientId, "2Vehicles", "vehicles");
    Client::addMenuItem(%clientId, "3Backpacks", "backpacks");
    Client::addMenuItem(%clientId, "4Deployables", "deployables");
    Client::addMenuItem(%clientId, "5Miscellaneous", "misc");
  }
  else if(%topic == "weapons")
  {
    Client::buildMenu(%clientId, "Help: Weapons 1", "help", true);
    Client::addMenuItem(%clientId, "1Blaster", "blaster weapons");
    Client::addMenuItem(%clientId, "2Chaingun", "chain weapons");
    Client::addMenuItem(%clientId, "3Energy Repeater", "repeater weapons");
    Client::addMenuItem(%clientId, "4Plasma Gun", "plasma weapons");
    Client::addMenuItem(%clientId, "5Grenade Launcher", "grenade weapons");
    Client::addMenuItem(%clientId, "6Mortar", "mortar weapons");
    Client::addMenuItem(%clientId, "7More Weapons", "weapons2");
    Client::addMenuItem(%clientId, "8Back to Main", "main");
  }
  else if(%topic == "weapons2")
  {
    Client::buildMenu(%clientId, "Help: Weapons 2", "help", true);
    Client::addMenuItem(%clientId, "1Disc Launcher", "disc weapons2");
    Client::addMenuItem(%clientId, "2Laser Rifle", "laser weapons2");
    Client::addMenuItem(%clientId, "3ELF Gun", "elf weapons2");
    Client::addMenuItem(%clientId, "4Rocket Launcher", "rocket weapons2");
    Client::addMenuItem(%clientId, "5EMP Grenade Launcher", "emp weapons2");
    Client::addMenuItem(%clientId, "6MAG Gun", "mag weapons2");
    Client::addMenuItem(%clientId, "7More Weapons", "weapons3");
    Client::addMenuItem(%clientId, "8Back to Main", "main");
  }
  else if(%topic == "weapons3")
  {
    Client::buildMenu(%clientId, "Help: Weapons 3", "help", true);
    Client::addMenuItem(%clientId, "1Tazer", "tazer weapons3");
    Client::addMenuItem(%clientId, "2IX-2000 Sniper Rifle", "sniper weapons3");
    Client::addMenuItem(%clientId, "3Pyro-Torch", "pyro weapons3");
    Client::addMenuItem(%clientId, "4Shotgun", "shotgun weapons3");
    Client::addMenuItem(%clientId, "5Phalanxx Cannon", "phalanxx weapons3");
    Client::addMenuItem(%clientId, "6Flare Gun", "flare weapons3");
    Client::addMenuItem(%clientId, "7Nanite Injector", "injector weapons3");
    Client::addMenuItem(%clientId, "8Back to Main", "main");
  }
  else if(%topic == "vehicles")
  {
    Client::buildMenu(%clientId, "Help: Vehicles", "help", true);
    Client::addMenuItem(%clientId, "1Scout", "scout vehicles");
    Client::addMenuItem(%clientId, "2LPC", "lpc vehicles");
    Client::addMenuItem(%clientId, "3HPC", "hpc vehicles");
    Client::addMenuItem(%clientId, "4Firestorm Bomber", "bomber vehicles");
    Client::addMenuItem(%clientId, "5Lightningstrike Fighter", "fighter vehicles");
    Client::addMenuItem(%clientId, "6Stealth LPC", "slpc vehicles");
    Client::addMenuItem(%clientId, "7 ", "vehicles");
    Client::addMenuItem(%clientId, "8Back to Main", "main");
  }
  else if(%topic == "backpacks")
  {
    Client::buildMenu(%clientId, "Help: Backpacks 1", "help", true);
    Client::addMenuItem(%clientId, "1Energy Pack", "energy backpacks");
    Client::addMenuItem(%clientId, "2Repair Pack", "repair backpacks");
    Client::addMenuItem(%clientId, "3Shield Pack", "shield backpacks");
    Client::addMenuItem(%clientId, "4Sensor Jammer Pack", "jampack backpacks");
    Client::addMenuItem(%clientId, "5Ammo Pack", "ammo backpacks");
    Client::addMenuItem(%clientId, "6Cloaking Device", "cloak backpacks");
    Client::addMenuItem(%clientId, "7More Backpacks", "backpacks2");
    Client::addMenuItem(%clientId, "8Back to Main", "main");
  }
  else if(%topic == "backpacks2")
  {
    Client::buildMenu(%clientId, "Help: Backpacks 2", "help", true);
    Client::addMenuItem(%clientId, "1Heat Sink", "heat backpacks2");
    Client::addMenuItem(%clientId, "2Pilot Pack", "pilot backpacks2");
    Client::addMenuItem(%clientId, "3Magnetic Shield Pack", "magshield backpacks2");
    Client::addMenuItem(%clientId, "4Rocket Booster", "booster backpacks2");
    Client::addMenuItem(%clientId, "5Retribution Pack", "retrib backpacks2");
    Client::addMenuItem(%clientId, "6Vengeance Missile Pack", "veng backpacks2");
    Client::addMenuItem(%clientId, "7 ", "backpacks2");
    Client::addMenuItem(%clientId, "8Back to Main", "main");
  }
  else if(%topic == "deployables")
  {
    Client::buildMenu(%clientId, "Help: Deployables 1", "help", true);
    Client::addMenuItem(%clientId, "1Inventory Station", "invstation deployables");
    Client::addMenuItem(%clientId, "2Ammo Station", "ammostation deployables");
    Client::addMenuItem(%clientId, "3Motion Sensor", "motion deployables");
    Client::addMenuItem(%clientId, "4Pulse Sensor", "pulse deployables");
    Client::addMenuItem(%clientId, "5Sensor Jammer", "jammer deployables");
    Client::addMenuItem(%clientId, "6Camera", "camera deployables");
    Client::addMenuItem(%clientId, "7More Deployables", "deployables2");
    Client::addMenuItem(%clientId, "8Back to Main", "main");
  }
  else if(%topic == "deployables2")
  {
    Client::buildMenu(%clientId, "Help: Deployables 2", "help", true);
    Client::addMenuItem(%clientId, "1Turret", "turret deployables2");
    Client::addMenuItem(%clientId, "2Sentry", "sentry deployables2");
    Client::addMenuItem(%clientId, "3Sentinel", "sentinel deployables2");
    Client::addMenuItem(%clientId, "4Avenger", "avenger deployables2");
    Client::addMenuItem(%clientId, "5Flak Cannon", "flak deployables2");
    Client::addMenuItem(%clientId, "6Decimator", "decimator deployables2");
    Client::addMenuItem(%clientId, "7More Deployables", "deployables3");
    Client::addMenuItem(%clientId, "8Back to Main", "main");
  }
  else if(%topic == "deployables3")
  {
    Client::buildMenu(%clientId, "Help: Deployables 3", "help", true);
    Client::addMenuItem(%clientId, "1Small Force Field", "forcefield deployables3");
    Client::addMenuItem(%clientId, "2Boom Box", "boombox deployables3");
    Client::addMenuItem(%clientId, "3 ", "deployables3");
    Client::addMenuItem(%clientId, "4 ", "deployables3");
    Client::addMenuItem(%clientId, "5 ", "deployables3");
    Client::addMenuItem(%clientId, "6 ", "deployables3");
    Client::addMenuItem(%clientId, "7 ", "deployables3");
    Client::addMenuItem(%clientId, "8Back to Main", "main");
  }
  else if(%topic == "misc")
  {
    Client::buildMenu(%clientId, "Help: Miscellaneous", "help", true);
    Client::addMenuItem(%clientId, "1Targeting Laser", "target misc");
    Client::addMenuItem(%clientId, "2Repair Kit", "repkit misc");
    Client::addMenuItem(%clientId, "3Mine", "mine misc");
    Client::addMenuItem(%clientId, "4Grenade", "handgren misc");
    Client::addMenuItem(%clientId, "5Beacon", "beacon misc");
    Client::addMenuItem(%clientId, "6 ", "misc");
    Client::addMenuItem(%clientId, "7 ", "misc");
    Client::addMenuItem(%clientId, "8Back to Main", "main");
  }
  else getHelpTopic(%clientId, %topic);
}


function getHelpTopic(%clientId, %option)
{
  %topic = getWord(%option, 0);
  %class = getWord(%option, 1);
  if(%topic == "blaster")
  {
    %item = "Blaster";
    %line1 = "Long Range Energy Weapon.";
    %line2 = "Does minimal damage with pinpoint accuracy.";
    %line3 = "";
  }
  else if(%topic == "chain")
  {
    %item = "Chaingun";
    %line1 = "Long Range Rapid Fire Weapon.";
    %line2 = "Does minimal damage at a very high rate, but with slightly spread accuracy.";
    %line3 = "";
  }
  else if(%topic == "repeater")
  {
    %item = "Energy Repeater";
    %line1 = "Medium Range Rapid Fire Energy Weapon.";
    %line2 = "Does minimal damage at a very high rate, but also consumes energy a very high rate.";
    %line3 = "Requires Energy Pack to use.";
  }
  else if(%topic == "plasma")
  {
    %item = "Plasma Gun";
    %line1 = "Short Range Explosive Weapon.";
    %line2 = "Does medium damage at a medium rate, but has a relatively short range.";
    %line3 = "";
  }
  else if(%topic == "grenade")
  {
    %item = "Grenade Launcher";
    %line1 = "Medium Range Explosive Weapon.";
    %line2 = "Lobs grenades that can bounce before exploding.";
    %line3 = "";
  }
  else if(%topic == "mortar")
  {
    %item = "Mortar";
    %line1 = "Long Range Explosive Weapon";
    %line2 = "Lobs mortar shells that causes considerable damage, but has a relatively slow reload rate.";
    %line3 = "Heavy Armor only.";
  }
  else if(%topic == "disc")
  {
    %item = "Disc Launcher";
    %line1 = "Long Range Explosive Weapon.";
    %line2 = "Launches a disc that does significant damage with pinpoint accuracy.";
    %line3 = "";
  }
  else if(%topic == "laser")
  {
    %item = "Laser Rifle";
    %line1 = "Energy Sniper Weapon.";
    %line2 = "Does damage based on the amount of energy used for the shot.";
    %line3 = "Light Armor only. Requires Energy Pack to use.";
  }
  else if(%topic == "elf")
  {
    %item = "ELF Gun";
    %line1 = "Energy Drain Weapon.";
    %line2 = "Causes target to loose energy at a rapid rate, until depleted, where it begins causing minimal damage.";
    %line3 = "";
  }
  else if(%topic == "rocket")
  {
    %item = "Rocket Launcher";
    %line1 = "Long Range Explosive Weapon.";
    %line2 = "Firing with a player or vehicle in direct line of sight causes rocket to lock, and home in on target.";
    %line3 = "Medium and Heavy Armor only.";
  }
  else if(%topic == "emp")
  {
    %item = "EMP Grenade Launcher";
    %line1 = "Long Range Energy Drain Weapon.";
    %line2 = "Lobs an EMP grenade that temporarily drains all the energy of anyone caught in the blast.";
    %line3 = "Medium and Heavy Armor only.";
  }
  else if(%topic == "mag")
  {
    %item = "MAG Gun";
    %line1 = "Short Range Magnetic Weapon.";
    %line2 = "Causes damage at a significant rate, and pulls the target towards you.";
    %line3 = "";
  }
  else if(%topic == "tazer")
  {
    %item = "Tazer";
    %line1 = "Very Short Range Energy Weapon.";
    %line2 = "Drains small amounts of energy while causing minimal damage.";
    %line3 = "Has second firing mode that does minimal damage at a long distance.";
  }
  else if(%topic == "sniper")
  {
    %item = "IX-2000 Sniper Rifle";
    %line1 = "Sniper Weapon.";
    %line2 = "Fires an extremely high speed bullet with pinpoint accuracy.";
    %line3 = "Light Armor only.";
  }
  else if(%topic == "pyro")
  {
    %item = "Pyro-Torch";
    %line1 = "Short Range Heat Weapon.";
    %line2 = "Causes considerable damage while giving off alot of heat.";
    %line3 = "";
  }
  else if(%topic == "shotgun")
  {
    %item = "Shotgun";
    %line1 = "Short Range Antipersonel Weapon.";
    %line2 = "Fires many fragments at target, causing more damage the more fragments that hit the target.";
    %line3 = "Light and Medium Armor only.";
  }
  else if(%topic == "phalanxx")
  {
    %item = "Phalanxx Cannon";
    %line1 = "Rapid Fire Weapon.";
    %line2 = "Double-barrelled chaingun that does considerable damage at a very high rate.";
    %line3 = "Medium Armor only. Requires two weapon slots to hold.";
  }
  else if(%topic == "flare")
  {
    %item = "Flare Gun";
    %line1 = "Long Range Heat Weapon.";
    %line2 = "Does minimal damage while impairing the vision anyone caught in the blast, and causing them to give off heat.";
    %line3 = "Light and Medium Armor only.";
  }
  else if(%topic == "injector")
  {
    %item = "Nanite Injector";
    %line1 = "Long Range Poison Weapon.";
    %line2 = "Does minimal damage while infecting target with Nanites, which will slowly cause damage until target is dead.";
    %line3 = "Light Armor only.";
  }
  else if(%topic == "scout")
  {
    %item = "Scout";
    %line1 = "Standard Attack Vehicle.";
    %line2 = "Relatively quick vehicle that carries only one player, and can fire rockets.";
    %line3 = "Limited to 3 per team.";
  }
  else if(%topic == "lpc")
  {
    %item = "LPC";
    %line1 = "Light Armored Personel Carrier.";
    %line2 = "Can carry two players plus the pilot. Has no weapons, but passengers are free to fire their weapons.";
    %line3 = "Limited to 2 per team.";
  }
  else if(%topic == "hpc")
  {
    %item = "HPC";
    %line1 = "Heavy Armored Personel Carrier.";
    %line2 = "Can carry four players plus the pilot. Has no weapons, but passengers are free to fire their weapons.";
    %line3 = "Limited to 1 per team.";
  }
  else if(%topic == "bomber")
  {
    %item = "Firestorm Bomber";
    %line1 = "Antipersonel Vehicle.";
    %line2 = "Similar to Scout, but is more sluggish and has less armor. Fires six bomblets that do considerable damage.";
    %line3 = "Limited to 1 per team.";
  }
  else if(%topic == "fighter")
  {
    %item = "Lightningstrike Fighter";
    %line1 = "Anti-Aircraft Vehicle.";
    %line2 = "Similar to Scout, but is more agile and has less armor. Fires small energy bolts that are not especially effective against ground targets.";
    %line3 = "Limited to 1 per team.";
  }
  else if(%topic == "slpc")
  {
    %item = "Stealth LPC";
    %line1 = "Light Armored Personel Carrier.";
    %line2 = "Nearly identical to standard LPC, but has some a built-in Sensor Jammer, and Hand Rockets cannot aquire locks.";
    %line3 = "Limited to 1 per team.";
  }
  else if(%topic == "energy")
  {
    %item = "Energy Pack";
    %line1 = "Always active.";
    %line2 = "Increases your energy recharge rate, allowing you to jet higher or further.";
    %line3 = "Required to use Energy Repeater or Laser Rifle.";
  }
  else if(%topic == "repair")
  {
    %item = "Repair Pack";
    %line1 = "Allows you to restore armor of any object that is not at full armor.";
    %line2 = "Repairing can also purge Nanites from anyone who has been infected.";
    %line3 = "";
  }
  else if(%topic == "shield")
  {
    %item = "Shield Pack";
    %line1 = "Upon activation, erects a personal shield around you that can absorb some damage inflicted on you.";
    %line2 = "When active, also makes you immune to the Decimator.";
    %line3 = "";
  }
  else if(%topic == "jampack")
  {
    %item = "Sensor Jammer Pack";
    %line1 = "Upon activation, generates a jamming field that prevents enemy Pulse Sensors from detecting any friendly units within the field.";
    %line2 = "Enemy turrets using Pulse Sensors are also jammed.";
    %line3 = "";
  }
  else if(%topic == "ammo")
  {
    %item = "Ammo Pack";
    %line1 = "Always active.";
    %line2 = "Allows you to hold more ammo than normally allowed, as well as ammo for weapons you may not be able to carry.";
    %line3 = "";
  }
  else if(%topic == "cloak")
  {
    %item = "Cloaking Device";
    %line1 = "Upon activation, renders you invisible and jams enemy Pulse Sensors.";
    %line2 = "Enemy turrets using Pulse Sensors are also jammed.";
    %line3 = "<f0>Players using \"Software Rendering\" will still be able to see you.";
  }
  else if(%topic == "heat")
  {
    %item = "Heat Sink";
    %line1 = "Always active.";
    %line2 = "Prevents you from giving off heat, and significantly shortens the time that a Flare will impair your vision.";
    %line3 = "Turrets with heat sensors will not be able to detect you.";
  }
  else if(%topic == "pilot")
  {
    %item = "Pilot Pack";
    %line1 = "Allows Medium Armor players to pilot Scouts, Bombers and Fighters.";
    %line2 = "May cause the vehicle to fire its weapon when mounting it.";
    %line3 = "Medium Armor only.";
  }
  else if(%topic == "magshield")
  {
    %item = "Magnetic Shield Pack";
    %line1 = "Always active.";
    %line2 = "Prevents you from being effected by EMP. Prevents Hand Rockets from aquiring locks onto you.";
    %line3 = "Causes MAG Guns to push you away with twice the force, instead of pull you.";
  }
  else if(%topic == "booster")
  {
    %item = "Rocket Booster";
    %line1 = "Provides immense speed increase, but generates extreme amounts of heat.";
    %line2 = "Also very unstable, and can detonate when overheated or shaken to violently.";
    %line3 = "Medium and Heavy Armor only.";
  }
  else if(%topic == "retrib")
  {
    %item = "Retribution Pack";
    %line1 = "Activates only after your death.";
    %line2 = "Fires a volley of rockets that are locked onto your assailant.";
    %line3 = "";
  }
  else if(%topic == "veng")
  {
    %item = "Vengeance Missile Pack";
    %line1 = "After aquiring a target with the Locking Laser, fires a configurable volley of rockets at the target.";
    %line2 = "Also has a Doomsday Mode that fires a single Doomsday Missile that does massive damage.";
    %line3 = "Heavy Armor only.";
  }
  else if(%topic == "invstation")
  {
    %item = "Inventory Station";
    %line1 = "Limited to 5 per team.";
    %line2 = "Provides a portable station from which to aquire new inventory, but has a limited supply of energy.";
    %line3 = "Medium and Heavy Armor only.";
  }
  else if(%topic == "ammostation")
  {
    %item = "Ammo Station";
    %line1 = "Limited to 7 per team.";
    %line2 = "Provides a portable station from which to recharge and repair your energy, ammo and armor.";
    %line3 = "Medium and Heavy Armor only.";
  }
  else if(%topic == "motion")
  {
    %item = "Motion Sensor";
    %line1 = "Limited to 15 per team. Can be deloyed on any serface.";
    %line2 = "Places a small sensor that detects enemy movement within its range.";
    %line3 = "Enemies that are not moving will not be detected.";
  }
  else if(%topic == "pulse")
  {
    %item = "Pulse Sensor";
    %line1 = "Limited to 15 per team.";
    %line2 = "Places a small sensor that detects enemies within its range.";
    %line3 = "Can be jammed by Sensor Jammers and Cloaking Devices.";
  }
  else if(%topic == "jammer")
  {
    %item = "Sensor Jammer";
    %line1 = "Limited to 8 per team.";
    %line2 = "Generates a jamming field that prevents enemy Pulse Sensors from detecting any friendly units within the field.";
    %line3 = "Enemy turrets using Pulse Sensors are also jammed.";
  }
  else if(%topic == "camera")
  {
    %item = "Camera";
    %line1 = "Limited to 15 per team. Can be deloyed on any serface.";
    %line2 = "Detects any players in its field of view. Can't be jammed in anyway.";
    %line3 = "Can be remotely operated without the use of a Command Station.";
  }
  else if(%topic == "turret")
  {
    %item = "Remote Turret";
    %line1 = "Limited to 10 per team.";
    %line2 = "Standard defensive turret. May be remotely operated from a Command Station.";
    %line3 = "Medium and Heavy Armor only.";
  }
  else if(%topic == "sentry")
  {
    %item = "Remote Sentry";
    %line1 = "Limited to 3 per team. <f0>If Phobiax is Disabled, limit is 5 per team.<f1>";
    %line2 = "Similar to Remote Turret, but with a shield. May be remotely operated from a Command Station.";
    %line3 = "Medium and Heavy Armor only.";
  }
  else if(%topic == "sentinel")
  {
    %item = "Sentinel";
    %line1 = "Limited to 3 per team. Can be deloyed on any serface.";
    %line2 = "Similar to Sentry, but has slighty heavier armor and longer range, but is slower and less damaging.";
    %line3 = "Medium and Heavy Armor only.";
  }
  else if(%topic == "avenger")
  {
    %item = "Avenger";
    %line1 = "Limited to 3 per team.";
    %line2 = "Has a heat sensor and will only fire at heat sources. Fires rockets that lock onto its target.";
    %line3 = "Heavy Armor only.";
  }
  else if(%topic == "flak")
  {
    %item = "Flak Cannon";
    %line1 = "Limited to 1 per team.";
    %line2 = "Has a heat sensor and will only fire at heat sources. Has considerable armor and range.";
    %line3 = "Heavy Armor only.";
  }
  else if(%topic == "decimator")
  {
    %item = "Decimator";
    %line1 = "Limited to 1 per team.";
    %line2 = "Has considerable armor and range. Fires a large bolt of energy, but has a very slow recharge rate.";
    %line3 = "Heavy Armor only.";
  }
  else if(%topic == "forcefield")
  {
    %item = "Small Force Field";
    %line1 = "Limited to 5 per team.";
    %line2 = "Erects a small wall of energy that can absorb a significant amount of damage before it is destroyed.";
    %line3 = "";
  }
  else if(%topic == "boombox")
  {
    %item = "Boom Box";
    %line1 = "Limited to 1 per team.";
    %line2 = "Once deployed, begins a customizable countdown timer and then detonates, causing massive damage. Can also be detonated manually.";
    %line3 = "Heavy Armor only.";
  }
  else if(%topic == "target")
  {
    %item = "Targetting Laser";
    %line1 = "Telemetry Reading Device.";
    %line2 = "Does no damage, but marks target location for teammates.";
    %line3 = "Provides target to aim at and the distance to that target.";
  }
  else if(%topic == "repkit")
  {
    %item = "Repair Kit";
    %line1 = "One-Time-Use Armor Repair.";
    %line2 = "Once used, will repair a portion of your armor.";
    %line3 = "Can also cure Nanites if you are infected.";
  }
  else if(%topic == "mine")
  {
    %item = "Antipersonel Mine";
    %line1 = "Remains active until it contacts with an object, then explodes.";
    %line2 = "There are 4 different variations of Antipersonel Mines.";
    %line3 = "<f0>If Phobiax is Enabled, choose \"Select Mine Type\" from the Tab Menu.";
  }
  else if(%topic == "handgren")
  {
    %item = "Hand Grenade";
    %line1 = "Distance thrown depends on how long you hold down the \"Throw Grenade\" Key.";
    %line2 = "Will explode after 2 seconds from being thrown.";
    %line3 = "";
  }
  else if(%topic == "beacon")
  {
    %item = "Beacon";
    %line1 = "Telemetry Reading Device.";
    %line2 = "Creates a target location for teammates.";
    %line3 = "Provides target to aim at and the distance to the beacon.";
  }
  else return;
  processMenuHelp(%clientId, %class);
  %text = "<jl><f1>";
  %text = %text @ "   <f2>Help for:<f1>   %1\n";
  %text = %text @ "   %2\n";
  %text = %text @ "   %3\n";
  %text = %text @ "   %4";
  %msg = sprintf(%text, %item, %line1, %line2, %line3);
  bottomPrint(%clientId, %msg, 30);
}


function processMenuDeployables(%clientId, %option)
{
  %opt = getWord(%option, 0);
  %cl = getWord(%option, 1);
  %i = floor(getWord(%option, 2)); if(%i < 0) %i = 0; %cl = Group::objectCount(%clientid.deployables);
  if(%opt == "more")
  {
    %items = "";
    for(%j = 0; %j < %cl; %j++)
    {
      %turret = Group::getObject(%clientId.deployables,%j);
      if(!%turret.packing) %items = %items @ %turret @ " ";
      
    }
    Client::buildMenu(%clientId, "Remote Pack-up/Destroy:", "Deployables", true);
    for(%k = 0; (%k < 7) && (%i < %cl); %i++) Client::addMenuItem(%clientId, %k++ @ GameBase::getMapName(getWord(%items,%i)), "packup " @ %cl @ " " @ %i);
    if((%cl - %i) > 0)
    {
      Client::addMenuItem(%clientId, %k++ @ "More Deployables...", "more " @ %cl @ " " @ %i);
    }
    return;
  }
  else if(%opt == "packup")
  {
    %turret = Group::getObject(%clientId.deployables,%i); if(%turret == -1 || %turret.packing) return;
    %dataName = GameBase::getDataName(%turret);
    if(%dataName == DeployableTurret) %pack = "TurretPack";
    else if(%dataName == DeployableSentry) %pack = "SentryPack";
    else if(%dataName == DeployableAvenger) %pack = "AvengerPack";
    else if(%dataName == DeployableSentinel) %pack = "SentinelPack";
    else if(%dataName == DeployableFlak) %pack = "FlakPack";
    else if(%dataName == DeployableDecimator) %pack = "DecimatorPack";
    %name = GameBase::getMapName(%turret);
    %turret.packing = true;
    %pos = getBoxCenter(%turret);
    %x = getWord(%pos,0);
    %y = getWord(%pos,1);
    %z = getWord(%pos,2);
    if(!GameBase::getDamageLevel(%turret))
    {
      GameBase::setSequenceDirection(%turret,1,0);
      schedule("deleteObject(" @ %turret @ ");",1.9,%turret);
      schedule("ixPopPack(" @ %clientId @ "," @ %pack @ "," @ %x @ "," @ %y @ "," @ %z @ ");",2.0);
      echo("MSG: ",%clientId," Remotely Packed up: " @ %dataName);
      Client::sendMessage(%clientId,0,"Packing up " @ %name);
      
    }
    else
    {
      schedule("GameBase::setDamageLevel(" @ %turret @ "," @ %dataName.maxDamage @ ");",1.0,%turret);
      Client::sendMessage(%clientId, 0,"Destroying Deployable: " @ %name);
      
    }
    return;
  }
}


function processMenuObsOptions(%clientid, %opt)
{
  if(%opt == "reset")
  {
    $pxObserverAngle[%clientId] = "Orbit";
    $pxObserverOrbit[%clientId] = 5;
  }
  else if(%opt == "camera")
  {
    %angle = $pxObserverAngle[%clientId];
    %value = $pxObserverOrbit[%clientId];
    if(%angle == "Orbit")
    {
      %angle = "Chase";
      if(%value > 0) $pxObserverOrbit[%clientId] *= -1;
    }
    else if(%angle == "Chase")
    {
      %angle = "First";
    }
    else if(%angle == "First")
    {
      %angle = "Orbit";
      if(%value < 0) $pxObserverOrbit[%clientId] *= -1;
    }
    $pxObserverAngle[%clientId] = %angle;
  }
  else
  {
    %angle = $pxObserverAngle[%clientId];
    %value = $pxObserverOrbit[%clientId];
    if(%angle == "Orbit")
    {
      if((%value + %opt) > 25) %value = 25;
      else if((%value + %opt) < 5) %value = 5;
      else %value += %opt;
    }
    else if(%angle == "Chase")
    {
      %opt *= -1;
      if((%value + %opt) < -25) %value = -25;
      else if((%value + %opt) > -5) %value = -5;
      else %value += %opt;
    }
    $pxObserverOrbit[%clientId] = %value;
  }
  Observer::setTargetClient(%clientId, %clientId.observerTarget);
  processMenuOptions(%clientId, "obsoptions");
}


function ixPopPack(%clientId, %pack, %x, %y, %z)
{
  %obj = newObject("","Item",%pack,1,false);
  schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
  addToSet("MissionCleanup", %obj);
  %pos = %x @ " " @ %y @ " " @ %z;
  GameBase::setPosition(%obj,%pos);
  $TeamItemCount[Client::getTeam(%clientId) @ %pack]--;
  playSound(SoundPickupItem,%pos);
}


function processMenuKAffirm(%clientId, %opt)
{
  if(getWord(%opt, 0) == "yes" && IxPort::PA(%clientId, $Insomniax::PAKick)) Admin::kick(%clientId, getWord(%opt, 1));
  Game::menuRequest(%clientId);
}


function processMenuBAffirm(%clientId, %opt)
{
  if(getWord(%opt, 0) == "yes" && IxPort::PA(%clientId, $Insomniax::PABan)) Admin::kick(%clientId, getWord(%opt, 1), true);
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
  if(getWord(%opt, 0) != "cancel" && IxPort::PA(%clientId, $Insomniax::PAResetDefaults))   // PORT FIX
  {
    messageAll(0, "PX-Server: " @ Client::getName(%clientId) @ " reset the server to default settings.");
    Server::refreshData();
  }
  Game::menuRequest(%clientId);
}


function processMenuRandAffirm(%clientId, %opt)
{
  if(getWord(%opt, 0) != "cancel" && IxPort::PA(%clientId, $Phobiax::PARandTeams))   // PORT FIX
  {
    Phobiax_RandomizeTeams(%clientId);
    return;
  }
  Game::menuRequest(%clientId);
}


function processMenuRestAffirm(%clientId, %option)
{
if(!IxPort::PA(%clientId, $Phobiax::PARestrain)) return;   // PORT FIX
  %opt = getWord(%option, 0);
  %cl = getWord(%option, 1);
  if(%opt == "yes")
  {
    if(%cl.isSuperAdmin)
    {
      Client::sendMessage(%clientId, 0, "A super admin cannot be restrained.");
      return;
    }
    if($Phobiax::RestrainChatTime < 30) $Phobiax::RestrainChatTime = 30;
    else if($Phobiax::RestrainChatTime > 120) $Phobiax::RestrainChatTime = 120;
    ixAdminMsg(Client::getName(%clientId) @ " has restrained " @ Client::getName(%cl));
    %cl.restrained = true;
    %cl.gagged = true;
    %cl.restrainTime = $Phobiax::RestrainChatTime;
    pxRestrainClient(%cl);
    pxCheckRestraints(%cl);
  }
  Game::menuRequest(%clientId);
}


function pxCheckRestraints(%clientId)
{
  
  %time = %clientId.restrainTime;
  if(%time > 0)
  {
    %delay = 5;
    if(%time == 15) pxRestrainClient(%clientId);
    if(%time == 30) pxRestrainClient(%clientId);
    if(%time == 60) pxRestrainClient(%clientId);
    if(%time == 90) pxRestrainClient(%clientId);
    %clientId.restrainTime -= %delay;
    if(%clientId.restrained) schedule("pxCheckRestraints(" @ %clientId @ ");", %delay, %clientId);
  }
  else
  {
    %clientId.restrainTime = "";
    pxRestrainClient(%clientId);
  }
}


function pxRestrainClient(%clientId)
{
  if(%clientId.isAdmin && !%clientId.isSuperAdmin) %clientId.isAdmin = false;
  if(%clientId.restrained)
  {
    if(Client::getTeam(%clientId) != -1) Observer::enterObserverMode(%clientId);
    if(%clientId.restrainTime > 0)
    {
      %clock = getClockTimer(%clientId.restrainTime);
      if(%clientId.restrainTime == $Phobiax::RestrainChatTime) %text = "<jc><f2>--- You have been restrained ---<f0>\nYou may not chat while being restrained.\nYou will be allowed one message in <f1>" @ %clock @ "<f0>.";
      else %text = "<jc><f2>--- You are still restrained ---<f0>\nYou may not chat while being restrained.\nYou will be allowed one message in <f1>" @ %clock @ "<f0>.";
    }
    else %text = "<jc><f2>--- You are still restrained ---<f0>\nYou may not chat while being restrained.\n<f1>You are now allowed one message.";
  }
  else %text = "<jc><f2>--- You have been unrestrained ---<f1>\n \nYou are now able to chat once again.";
  bottomprint(%clientId, %text, 5);
}


function processMenuModMode(%clientId, %option)
{
  %opt = getWord(%option, 0);
  if($ModModeSwitching) return;
  if(%opt != "cancel" && IxPort::PA(%clientId, $Insomniax::PAModOptions))   // PORT FIX
  {
    if(%opt == "Phobiax") %toggle = "true";
    else %toggle = "false";
    $ModModeSwitching = true;
    pxWarningText(%toggle);
    schedule("setModMode(" @ %toggle @ ");", 10);
  }
}


function pxWarningText(%toggle)
{
  if(%toggle)
  {
    %state = "enabled";
    %gameType = "Phobiax";
    %version = $PhobiaxInternalVersion;
  }
  else
  {
    %state = "disabled";
    %gameType = "Insomniax";
    %version = $InsomniaxInternalVersion;
  }
  %text = "<jc><f2>-----  Phobiax has been %1  -----<f1>\nThe server will reset and function as %2 %3\n\n<f0>Favorites Tables will also be reset for this version of %2";
  %msg = sprintf(%text, %state, %gameType, %version);
  bottomPrintAll(%msg, 10);
}


function setModMode(%toggle)
{
  bottomPrintAll();
  $Phobiax::ExpansionItems = %toggle;
  pxPhobiaxArmorData();
  pxPhobiaxFavoritesKey();
  pxPhobiaxItem();
  pxPhobiaxStation();
  for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
  {
    remoteEval(%cl, NewFavsKey, $ItemFavoritesKey);
    %cl.DoomsdayMode = 0;
    $pxMineLoadout[%cl] = "Antipersonel";
  }
  Server::nextMission(true);
  $ModModeSwitching = false;
}


function remoteNewFavsKey(%server, %favKey)
{
  if(%server == 2048)
  {
    $ServerFavoritesKey = %favKey;
  }
}


function processMenuCTLimit(%clientId, %opt)
{
  remoteSetTimeLimit(%clientId, %opt);
}


function processMenuIXSettings(%clientId, %option)
{
  %opt = getWord(%option, 0);
  %cl = getWord(%option, 1); if(!IxPort::PA(%clientId, $Insomniax::PAModOptions)) return; if(!%clientId.isSuperAdmin && (%opt == "admincontrols" || %opt == "disablepav" || %opt == "enablepav" || %opt == "palockout" || %opt == "pvlockout" || %opt == "purge" || %opt == "stationtime")) return;
  if(%opt == "modmode")
  {
    %now = 0;
    Client::buildMenu(%clientId, "Switch to " @ %cl @ " Mode", "modmode", true);
    Client::addMenuItem(%clientId, %now++ @ "Switch and Reload", %cl);
    Client::addMenuItem(%clientId, %now++ @ "Cancel", "cancel");
    return;
  }
  else if(%opt == "admincontrols")
  {
    Client::buildMenu(%clientId, "Admin Controls:", "ixsettings", true);
    if($Insomniax::PAVote) Client::addMenuItem(%clientId, "1Disable Admin Voting", "disablepav");
    else Client::addMenuItem(%clientId, "1Enable Admin Voting", "enablepav");
    Client::addMenuItem(%clientId, "2Admin Lockouts", "palockout");
    Client::addMenuItem(%clientId, "3Voting Lockouts", "pvlockout");
    Client::addMenuItem(%clientId, "4Purge Public Admins", "purge " @ %clientId);
    return;
  }
  else if(%opt == "disablepav")
  {
    ixAdminMsg("Admin Voting is DISABLED by " @ Client::getName(%clientId));
    $Insomniax::PAVote = "false";
  }
  else if(%opt == "enablepav")
  {
    ixAdminMsg("Admin Voting is ENABLED by " @ Client::getName(%clientId));
    $Insomniax::PAVote = "true";
  }
  else if(%opt == "tkserv")
  {
    Client::buildMenu(%clientId, "Current Server Anti-TK: " @ %cl, "ServerLvl", true);
    Client::addMenuItem(%clientId, "0Log TK's only", 0);
    Client::addMenuItem(%clientId, "1Auto Vote TKer", 1);
    Client::addMenuItem(%clientId, "2Auto Vote Until Kicked", 2);
    Client::addMenuItem(%clientId, "3Auto Kick TKer", 3);
    return;
  }
  else if(%opt == "tkclient")
  {
    Client::buildMenu(%clientId, "Current Client Anti-TK: " @ %cl, "ClientLvl", true);
    Client::addMenuItem(%clientId, "0Client Vote Option", 0);
    Client::addMenuItem(%clientId, "1Client Kick Option", 1);
    return;
  }
  else if(%opt == "areakill")
  {
    Client::buildMenu(%clientId, "Out of Bounds Kill Time: " @ %cl @ " Seconds", "AKill", true);
    Client::addMenuItem(%clientId, "0Set to Off", 0);
    Client::addMenuItem(%clientId, "1Set to 10 Seconds", 10);
    Client::addMenuItem(%clientId, "2Set to 15 Seconds", 15);
    Client::addMenuItem(%clientId, "3Set to 20 Seconds", 20);
    Client::addMenuItem(%clientId, "4Set to 25 Seconds", 25);
    Client::addMenuItem(%clientId, "5Set to 30 Seconds", 30);
    Client::addMenuItem(%clientId, "6Set to 45 Seconds", 45);
    Client::addMenuItem(%clientId, "7Set to 60 Seconds", 60);
    return;
  }
  else if(%opt == "palockout")
  {
    Client::buildMenu(%clientId, "(Pg.1) Current Status:","PALockouts", true);
    Client::addMenuItem(%clientId, "1[" @ whatToDo($Insomniax::PATeamChange) @ "] Team Changing", "teamchange " @ $Insomniax::PATeamChange);
    Client::addMenuItem(%clientId, "2[" @ whatToDo($Insomniax::PAKick) @ "] Kick Players", "kick " @ $Insomniax::PAKick);
    Client::addMenuItem(%clientId, "3[" @ whatToDo($Insomniax::PABan) @ "] Ban Players", "ban " @ $Insomniax::PABan);
    Client::addMenuItem(%clientId, "4[" @ whatToDo($Phobiax::PARestrain) @ "] Restrain Players", "restrain " @ $Phobiax::PARestrain);
    Client::addMenuItem(%clientId, "5[" @ whatToDo($Insomniax::PAGag) @ "] Gag Players", "gag " @ $Insomniax::PAGag);
    Client::addMenuItem(%clientId, "6[" @ whatToDo($Insomniax::PAMission) @ "] Change Mission", "mission " @ $Insomniax::PAMission);
    Client::addMenuItem(%clientId, "7[" @ whatToDo($Insomniax::PATeamDamage) @ "] Team Damage", "teamdamage " @ $Insomniax::PATeamDamage);
    Client::addMenuItem(%clientId, "8Admin Lockouts #2 ...", "additional");
    return;
  }
  else if(%opt == "pvlockout")
  {
    Client::buildMenu(%clientId, "(Pg.1) Current Status:","PVLockouts", true);
    Client::addMenuItem(%clientId, "1[" @ whatToDo($Insomniax::PVKick) @ "] Kick Players", "kick " @ $Insomniax::PVKick);
    Client::addMenuItem(%clientId, "2[" @ whatToDo($Insomniax::PVMission) @ "] Change Mission", "mission " @ $Insomniax::PVMission);
    Client::addMenuItem(%clientId, "5[" @ whatToDo($Insomniax::PVTeamDamage) @ "] Team Damage", "teamdamage " @ $Insomniax::PVTeamDamage);
    Client::addMenuItem(%clientId, "6[" @ whatToDo($Insomniax::PVTourneyMode) @ "] Tourney/FFA Mode", "tourney " @ $Insomniax::PVTourneyMode);
    Client::addMenuItem(%clientId, "3[" @ whatToDo($Insomniax::PVFairTeams) @ "] Fair Teams", "fteams " @ $Insomniax::PVFairTeams);
    Client::addMenuItem(%clientId, "4[" @ whatToDo($Phobiax::PVRandTeams) @ "] Randomized Teams", "rteams " @ $Phobiax::PVRandTeams);
    Client::addMenuItem(%clientId, "7UNLOCK All Options", "allon");
    Client::addMenuItem(%clientId, "8LOCK All Options", "alloff");
    return;
  }
  else if(%opt == "purge")
  {
    Insomniax_clearPA(%clientId);
    return;
  }
  else if(%opt == "disablepskin") ixAllSkinsOff();
  else if(%opt == "enablepskin") ixAllSkinsOn();
  else if(%opt == "stationtime")
  {
    Client::buildMenu(%clientId, "Inventoy Station Time: " @ %cl @ " Seconds", "StationTime", true);
    Client::addMenuItem(%clientId, "0Set to Off", 0);
    Client::addMenuItem(%clientId, "1Set to 10 Seconds", 10);
    Client::addMenuItem(%clientId, "2Set to 15 Seconds", 15);
    Client::addMenuItem(%clientId, "3Set to 20 Seconds", 20);
    Client::addMenuItem(%clientId, "4Set to 25 Seconds", 25);
    Client::addMenuItem(%clientId, "5Set to 30 Seconds", 30);
    Client::addMenuItem(%clientId, "6Set to 45 Seconds", 45);
    Client::addMenuItem(%clientId, "7Set to 60 Seconds", 60);
    return;
  }
  else if(%opt == "dsafestation")
  {
    ixAdminMsg("Safe Stations DISABLED by " @ Client::getName(%clientId));
    $Insomniax::SafeStation = "false";
  }
  else if(%opt == "esafestation")
  {
    ixAdminMsg("Safe Stations ENABLED by " @ Client::getName(%clientId));
    $Insomniax::SafeStation = "true";
  }
  processMenuOptions(%clientId, "insomniax");
}


function processMenuPALockouts(%clientId, %option)
{
  %opt = getWord(%option, 0);
  %toggle = getWord(%option, 1); if(!%clientId.isSuperAdmin) return;
  if(%opt == "additional")
  {
    Client::buildMenu(%clientId, "(Pg.2) Current Status:","PALockouts", true);
    Client::addMenuItem(%clientId, "1[" @ whatToDo($Insomniax::PATourneyMode) @ "] Tourney/FFA Mode", "tourney " @ $Insomniax::PATourneyMode);
    Client::addMenuItem(%clientId, "2[" @ whatToDo($Insomniax::PATimeLimit) @ "] Time Limit", "timelimit " @ $Insomniax::PATimeLimit);
    Client::addMenuItem(%clientId, "3[" @ whatToDo($Insomniax::PAResetDefaults) @ "] Server Defaults ", "reset " @ $Insomniax::PAResetDefaults);
    Client::addMenuItem(%clientId, "4[" @ whatToDo($Insomniax::PAModOptions) @ "] PX-Admin Options", "modopt " @ $Insomniax::PAModOptions);
    Client::addMenuItem(%clientId, "5[" @ whatToDo($Insomniax::PATeamInfo) @ "] Set Team Info", "teaminfo " @ $Insomniax::PATeamInfo);
    Client::addMenuItem(%clientId, "6[" @ whatToDo($Insomniax::PAFairTeams) @ "] Fair Teams", "fteams " @ $Insomniax::PAFairTeams);
    Client::addMenuItem(%clientId, "7[" @ whatToDo($Phobiax::PARandTeams) @ "] Ramdomized Teams", "rteams " @ $Phobiax::PARandTeams);
    Client::addMenuItem(%clientId, "8Admin Lockouts #3 ...", "additional2");
    return;
  }
  else if(%opt == "additional2")
  {
    Client::buildMenu(%clientId, "(Pg.3) Current Status:","PALockouts", true);
    Client::addMenuItem(%clientId, "1UNLOCK All Options", "allon");
    Client::addMenuItem(%clientId, "2LOCK All Options", "alloff");
    Client::addMenuItem(%clientId, "3Admin Lockouts #1 ...", "previous");
    return;
  }
  else if(%opt == "previous")
  {
    processMenuIXSettings(%clientId,"palockout");
    return;
  }
  else if(%opt == "teamchange")
  {
    %access = "Admin: Team Change";
    if(%toggle) $Insomniax::PATeamChange = "false";
    else $Insomniax::PATeamChange = "true";
    %page = "false";
  }
  else if(%opt == "kick")
  {
    %access = "Admin: Kick";
    if(%toggle) $Insomniax::PAKick = "false";
    else $Insomniax::PAKick = "true";
    %page = "false";
  }
  else if(%opt == "ban")
  {
    %access = "Admin: Ban";
    if(%toggle) $Insomniax::PABan = "false";
    else $Insomniax::PABan = "true";
    %page = "false";
  }
  else if(%opt == "restrain")
  {
    %access = "Admin: Restrain";
    if(%toggle) $Phobiax::PARestrain = "false";
    else $Phobiax::PARestrain = "true";
    %page = "false";
  }
  else if(%opt == "gag")
  {
    %access = "Admin: Gag";
    if(%toggle) $Insomniax::PAGag = "false";
    else $Insomniax::PAGag = "true";
    %page = "false";
  }
  else if(%opt == "mission")
  {
    %access = "Admin: Change Mission";
    if(%toggle) $Insomniax::PAMission = "false";
    else $Insomniax::PAMission = "true";
    %page = "false";
  }
  else if(%opt == "teamdamage")
  {
    %access = "Admin: Enable/Disable Team Damage";
    if(%toggle) $Insomniax::PATeamDamage = "false";
    else $Insomniax::PATeamDamage = "true";
    %page = "false";
  }
  else if(%opt == "tourney")
  {
    %access = "Admin: Toggle Tourney/FFA Mode";
    if(%toggle) $Insomniax::PATourneyMode = "false";
    else $Insomniax::PATourneyMode = "true";
    %page = "true";
  }
  else if(%opt == "timelimit")
  {
    %access = "Admin: Change Time Limit";
    if(%toggle) $Insomniax::PATimeLimit = "false";
    else $Insomniax::PATimeLimit = "true";
    %page = "true";
  }
  else if(%opt == "reset")
  {
    %access = "Admin: Reset Sever";
    if(%toggle) $Insomniax::PAResetDefaults = "false";
    else $Insomniax::PAResetDefaults = "true";
    %page = "true";
  }
  else if(%opt == "modopt")
  {
    %access = "Admin: IX-Admin Options";
    if(%toggle) $Insomniax::PAModOptions = "false";
    else $Insomniax::PAModOptions = "true";
    %page = "true";
  }
  else if(%opt == "teaminfo")
  {
    %access = "Admin: Set Team Info";
    if(%toggle) $Insomniax::PATeamInfo = "false";
    else $Insomniax::PATeamInfo = "true";
    %page = "true";
  }
  else if(%opt == "fteams")
  {
    %access = "Admin: Enable/Disable Fair Teams";
    if(%toggle) $Insomniax::PAFairTeams = "false";
    else $Insomniax::PAFairTeams = "true";
    %page = "true";
  }
  else if(%opt == "rteams")
  {
    %access = "Admin: Enable/Disable Randomized Teams";
    if(%toggle) $Phobiax::PARandTeams = "false";
    else $Phobiax::PARandTeams = "true";
    %page = "true";
  }
  else if(%opt == "allon")
  {
    %access = "All Admin Options";
    %toggle = "false";
    $Insomniax::PATeamChange = "true";
    $Insomniax::PAKick = "true";
    $Insomniax::PABan = "true";
    $Phobiax::PARestrain = "true";
    $Insomniax::PAGag = "true";
    $Insomniax::PAMission = "true";
    $Insomniax::PATeamDamage = "true";
    $Insomniax::PATourneyMode = "true";
    $Insomniax::PATimeLimit = "true";
    $Insomniax::PAResetDefaults = "true";
    $Insomniax::PAModOptions = "true";
    $Insomniax::PATeamInfo = "true";
    $Insomniax::PAFairTeams = "true";
    $Phobiax::PARandTeams = "true";
    %page = "false";
  }
  else if(%opt == "alloff")
  {
    %access = "All Admin Options";
    %toggle = "true";
    $Insomniax::PATeamChange = "false";
    $Insomniax::PAKick = "false";
    $Insomniax::PABan = "false";
    $Phobiax::PARestrain = "false";
    $Insomniax::PAGag = "false";
    $Insomniax::PAMission = "false";
    $Insomniax::PATeamDamage = "false";
    $Insomniax::PATourneyMode = "false";
    $Insomniax::PATimeLimit = "false";
    $Insomniax::PAResetDefaults = "false";
    $Insomniax::PAModOptions = "false";
    $Insomniax::PATeamInfo = "false";
    $Insomniax::PAFairTeams = "false";
    $Phobiax::PARandTeams = "false";
    %page = "false";
  }
  if(%toggle) %toggle = "false";
  else %toggle = "true";
  ixAdminMsg(Client::getName(%clientId) @ " [" @ isLocked(%toggle) @ "] " @ %access);
  if(%page) processMenuPALockouts(%clientId,"additional");
  else processMenuIXSettings(%clientId,"palockout");
}


function processMenuPVLockouts(%clientId, %option)
{
  %opt = getWord(%option, 0);
  %toggle = getWord(%option, 1); if(!%clientId.isSuperAdmin) return;
  if(%opt == "kick")
  {
    %access = "Vote to Kick";
    if(%toggle) $Insomniax::PVKick = "false";
    else $Insomniax::PVKick = "true";
  }
  else if(%opt == "mission")
  {
    %access = "Vote to Change Mission";
    if(%toggle) $Insomniax::PVMission = "false";
    else $Insomniax::PVMission = "true";
  }
  else if(%opt == "teamdamage")
  {
    %access = "Vote to Enable/Disable Team Damage";
    if(%toggle) $Insomniax::PVTeamDamage = "false";
    else $Insomniax::PVTeamDamage = "true";
  }
  else if(%opt == "tourney")
  {
    %access = "Vote to Change to Tourney/FFA Mode";
    if(%toggle) $Insomniax::PVTourneyMode = "false";
    else $Insomniax::PVTourneyMode = "true";
  }
  else if(%opt == "fteams")
  {
    %access = "Vote to Enable/Disable Fair Teams";
    if(%toggle) $Insomniax::PVFairTeams = "false";
    else $Insomniax::PVFairTeams = "true";
  }
  else if(%opt == "rteams")
  {
    %access = "Vote to Enable/Disable Randomized Teams";
    if(%toggle) $Phobiax::PVRandTeams = "false";
    else $Phobiax::PVRandTeams = "true";
  }
  else if(%opt == "allon")
  {
    %access = "All Vote Options";
    %toggle = "false";
    $Insomniax::PVKick = "true";
    $Insomniax::PVMission = "true";
    $Insomniax::PVTeamDamage = "true";
    $Insomniax::PVTourneyMode = "true";
    $Insomniax::PVFairTeams = "true";
    $Phobiax::PVRandTeams = "true";
  }
  else if(%opt == "alloff")
  {
    %access = "All Vote Options";
    %toggle = "true";
    $Insomniax::PVKick = "false";
    $Insomniax::PVMission = "false";
    $Insomniax::PVTeamDamage = "false";
    $Insomniax::PVTourneyMode = "false";
    $Insomniax::PVFairTeams = "false";
    $Phobiax::PVRandTeams = "false";
  }
  if(%toggle) %toggle = "false";
  else %toggle = "true";
  ixAdminMsg(Client::getName(%clientId) @ " [" @ isLocked(%toggle) @ "] " @ %access);
  processMenuIXSettings(%clientId,"pvlockout");
}


function isLocked(%toggle)
{
  if(%toggle) return "Unlocked";
  else return "-Locked-";
}


function whatToDo(%toggle)
{
  if(%toggle) return "-Lock-";
  else return "Unlock";
}


function isEnabled(%toggle)
{
  if(%toggle) return "ENABLED";
  else return "DISABLED";
}


function getClockTimer(%totalSecs)
{
  if(%totalSecs > 3599) %totalSecs = 3599;
  if(%totalSecs < 0) %totalSecs = 0;
  %mins = floor(%totalSecs / 60);
  %secs = (%totalSecs - (%mins * 60));
  if(%secs < 10) %secs = "0" @ %secs;
  %clock = %mins @ ":" @ %secs;
  return %clock;
}


function processMenuServerLvl(%clientId, %option)
{ if(!IxPort::PA(%clientId, $Insomniax::PAModOptions)) return;
  $Insomniax::tkServerLvl = %option;
  if(%option == 0) messageAll(0, "PX-Server: TK Protection Level Set to Zero. (Logging TK's only).");
  if(%option == 1) messageAll(0, "PX-Server: TK Protection Level Set to One. (Auto Vote).");
  if(%option == 2) messageAll(0, "PX-Server: TK Protection Level Set to Two. (Auto Vote Until Kicked).");
  if(%option == 3) messageAll(0, "PX-Server: TK Protection Level Set to Three. (Auto Kick).");
}


function processMenuClientLvl(%clientId, %option)
{ if(!IxPort::PA(%clientId, $Insomniax::PAModOptions)) return;
  $Insomniax::tkClientLvl = %option;
  if(%option == 0) messageAll(0, "PX-Server: Client TK Vote Option Engaged. (From Options Menu).");
  if(%option == 1) messageAll(0, "PX-Server: Client TK Kick Option Engaged. (From Options Menu).");
}


function processMenuAKill(%clientId, %option)
{ if(!IxPort::PA(%clientId, $Insomniax::PAModOptions)) return;
  $Insomniax::LeaveAreaTime = %option;
  if(%option == 0) messageAll(0, "PX-Server: Leaving Mission Area Now Does not Kill you.");
  else messageAll(0, "PX-Server: Leaving Mission Area Now Kills you in " @ %option @ " Seconds.");
}


function processMenuStationTime(%clientId, %option)
{ if(!%clientId.isSuperAdmin) return;
  $Insomniax::StationTime = %option;
  if(%option == 0) messageAll(0, "PX-Server: Inventory Station Time is no Longer Limited.");
  else messageAll(0, "PX-Server: Inventory Station Time is now Limited to " @ %option @ " Seconds.");
}


function processMenuVengeance(%clientId, %option)
{
  %opt = getWord(%option, 0);
  %cl = getWord(%option, 1); if(String::findSubStr(%opt, "load") == 0) { %cl = floor(%cl); if(%cl < 1 || %cl > 5) return; }
  if(%opt == "doomsdayon" && $Phobiax::ExpansionItems) %clientId.DoomsdayMode = 1;
  else %clientId.DoomsdayMode = 0;
  if(%opt == "payload")
  {
    Client::buildMenu(%clientId, "Current Payload: " @ $ixVPayload[%clientId],"vengeance", true);
    Client::addMenuItem(%clientId, "1Fire 1 Projectile", "number 1");
    Client::addMenuItem(%clientId, "2Fire 2 Projectiles", "number 2");
    Client::addMenuItem(%clientId, "3Fire 3 Projectiles", "number 3");
    Client::addMenuItem(%clientId, "4Fire 4 Projectiles", "number 4");
    Client::addMenuItem(%clientId, "5Fire 5 Projectiles", "number 5");
    return;
  }
  else if(%opt == "number")
  { %cl = floor(%cl); if(%cl < 1) %cl = 1; if(%cl > 5) %cl = 5;
    $ixVPayload[%clientId] = %cl;
    playSound(SoundChangePayload,GameBase::getPosition(Client::getOwnedObject(%clientId)));
    bottomprint(%clientId,"<jc><f2>Vengeance Payload Update.\n<f1>Now set to Launch " @ %cl @ " Warheads", 5);
  }
  else if(%opt == "scan")
  {
    Client::buildMenu(%clientId, "Current Scan: " @ $ixVScanner[%clientId],"vengeance", true);
    Client::addMenuItem(%clientId, "1Short/Wide Scan", "scanner Short");
    Client::addMenuItem(%clientId, "2Medium/Thin Scan", "scanner Medium");
    Client::addMenuItem(%clientId, "3Long/Tight Scan", "scanner Long");
    return;
  }
  else if(%opt == "scanner")
  { if(%cl != "Short" && %cl != "Medium" && %cl != "Long") return;
    $ixVScanner[%clientId] = %cl;
    bottomprint(%clientId,"<jc><f2>Vengeance Scanner Update.\n<f1>Now Scanning " @ %cl @ " Range.", 5);
    Player::useItem(%clientId,Vengeance);
  }
  else if(%opt == "warhead")
  {
    Client::buildMenu(%clientId, "Ammo After Launch: ","vengeance", true);
    Client::addMenuItem(%clientId, "1Warhead #1: " @ $ixVWarhead[%clientId, 1], "loadout 1");
    Client::addMenuItem(%clientId, "2Warhead #2: " @ $ixVWarhead[%clientId, 2], "loadout 2");
    Client::addMenuItem(%clientId, "3Warhead #3: " @ $ixVWarhead[%clientId, 3], "loadout 3");
    Client::addMenuItem(%clientId, "4Warhead #4: " @ $ixVWarhead[%clientId, 4], "loadout 4");
    Client::addMenuItem(%clientId, "5Warhead #5: " @ $ixVWarhead[%clientId, 5], "loadout 5");
    Client::addMenuItem(%clientId, "6Back to Vengeance Menu", "");
    return;
  }
  else if(%opt == "loadout")
  {
    Client::buildMenu(%clientId, "Choose Load for Warhead: " @ %cl,"vengeance", true);
    Client::addMenuItem(%clientId, "1Low Yield: " @ $ixVAmmo[Low], "loadlow " @ %cl);
    Client::addMenuItem(%clientId, "2Medium Yield: " @ $ixVAmmo[Medium], "loadmed " @ %cl);
    Client::addMenuItem(%clientId, "3High Yield: " @ $ixVAmmo[High], "loadhigh " @ %cl);
    Client::addMenuItem(%clientId, "4EMP: " @ $ixVAmmo[EMP], "loademp " @ %cl);
    Client::addMenuItem(%clientId, "5Pause Sequence: 0", "loadpause " @ %cl);
    return;
  }
  else if(%opt == "loadlow")
  {
    $ixVWarhead[%clientId, %cl] = "Low";
    bottomprint(%clientId,"<jc><f2>Vengeance Warhead Update.\n<f1>Warhead " @ %cl @ " is now Low Yield", 5);
    playSound(SoundLoadWarhead,GameBase::getPosition(Client::getOwnedObject(%clientId)));
    processMenuVengeance(%clientId, "warhead");
    return;
  }
  else if(%opt == "loadmed")
  {
    $ixVWarhead[%clientId, %cl] = "Medium";
    bottomprint(%clientId,"<jc><f2>Vengeance Warhead Update.\n<f1>Warhead " @ %cl @ " is now Medium Yield", 5);
    playSound(SoundLoadWarhead,GameBase::getPosition(Client::getOwnedObject(%clientId)));
    processMenuVengeance(%clientId, "warhead");
    return;
  }
  else if(%opt == "loadhigh")
  {
    $ixVWarhead[%clientId, %cl] = "High";
    bottomprint(%clientId,"<jc><f2>Vengeance Warhead Update.\n<f1>Warhead " @ %cl @ " is now High Yield", 5);
    playSound(SoundLoadWarhead,GameBase::getPosition(Client::getOwnedObject(%clientId)));
    processMenuVengeance(%clientId, "warhead");
    return;
  }
  else if(%opt == "loademp")
  {
    $ixVWarhead[%clientId, %cl] = "EMP";
    bottomprint(%clientId,"<jc><f2>Vengeance Warhead Update.\n<f1>Warhead " @ %cl @ " is holding an EMP Charge", 5);
    playSound(SoundLoadWarhead,GameBase::getPosition(Client::getOwnedObject(%clientId)));
    processMenuVengeance(%clientId, "warhead");
    return;
  }
  else if(%opt == "loadpause")
  {
    $ixVWarhead[%clientId, %cl] = "Pause";
    bottomprint(%clientId,"<jc><f2>Vengeance Warhead Update.\n<f1>Warhead " @ %cl @ " set to Pause the Sequence", 5);
    playSound(SoundLoadWarhead,GameBase::getPosition(Client::getOwnedObject(%clientId)));
    processMenuVengeance(%clientId, "warhead");
    return;
  }
  else if(%opt == "preset")
  {
    Client::buildMenu(%clientId, "Pre-Set Choices: ", "vengeance", true);
    Client::addMenuItem(%clientId, "1LR Turret Buster", "LRTB");
    Client::addMenuItem(%clientId, "2MR Turret Buster", "MRTB");
    Client::addMenuItem(%clientId, "3SR Flag Defender", "SRFD");
    Client::addMenuItem(%clientId, "4MR Anti-Air", "MRAA");
    Client::addMenuItem(%clientId, "5LR Anti-Air", "LRAA");
    if(getWord($pxCustomPreSet[%clientId], 0) != "NotSet")
    {
      %mark = String::findSubStr($pxCustomPreSet[%clientId], "*");
      %preSet = String::getSubStr($pxCustomPreSet[%clientId], 0, (%mark - 1));
      Client::addMenuItem(%clientId, "6Reset Custom", "custom set");
      Client::addMenuItem(%clientId, "7" @ %preSet, "custom use");
    }
    else Client::addMenuItem(%clientId, "6Setup Custom", "custom set");
    return;
  }
  else if(%opt == "custom")
  {
    processMenuCustomPreSet(%clientId, %cl);
    return;
  }
  else if(%opt == "LRTB")
  {
    $ixVWarhead[%clientId, 1] = "High";
    $ixVWarhead[%clientId, 2] = "High";
    $ixVWarhead[%clientId, 3] = "Pause";
    $ixVWarhead[%clientId, 4] = "Pause";
    $ixVWarhead[%clientId, 5] = "EMP";
    $ixVScanner[%clientId] = "Long";
    $ixVPayload[%clientId] = 5;
    bottomprint(%clientId,"<jc><f2>Vengeance Pre-Set Activated: Long Range Turret Buster.\n<f1>Payload: ALL Five\nScanner: Long Range (350 Meters)\nWarheads: High, High, Pause, Pause, EMP.", 10);
    %pos = GameBase::getPosition(Client::getOwnedObject(%clientId));
    playSound(SoundChangePayload,%pos);
    Player::useItem(%clientId,Vengeance);
    return;
  }
  else if(%opt == "MRTB")
  {
    $ixVWarhead[%clientId, 1] = "High";
    $ixVWarhead[%clientId, 2] = "High";
    $ixVWarhead[%clientId, 3] = "EMP";
    $ixVWarhead[%clientId, 4] = "Pause";
    $ixVWarhead[%clientId, 5] = "Pause";
    $ixVScanner[%clientId] = "Medium";
    $ixVPayload[%clientId] = 3;
    bottomprint(%clientId,"<jc><f2>Vengeance Pre-Set Activated: Medium Range Turret Buster.\n<f1>Payload: Three\nScanner: Medium Range (150 Meters)\nWarheads: High, High, EMP.", 10);
    %pos = GameBase::getPosition(Client::getOwnedObject(%clientId));
    playSound(SoundChangePayload,%pos);
    Player::useItem(%clientId,Vengeance);
    return;
  }
  else if(%opt == "SRFD")
  {
    $ixVWarhead[%clientId, 1] = "Low";
    $ixVWarhead[%clientId, 2] = "Low";
    $ixVWarhead[%clientId, 3] = "EMP";
    $ixVWarhead[%clientId, 4] = "Low";
    $ixVWarhead[%clientId, 5] = "Low";
    $ixVScanner[%clientId] = "Short";
    $ixVPayload[%clientId] = 5;
    bottomprint(%clientId,"<jc><f2>Vengeance Pre-Set Activated: Short Range Flag Defender.\n<f1>Payload: ALL Five\nScanner: Short Range (50 Meters)\nWarheads: Low, Low, EMP, Low, Low.", 10);
    %pos = GameBase::getPosition(Client::getOwnedObject(%clientId));
    playSound(SoundChangePayload,%pos);
    Player::useItem(%clientId,Vengeance);
    return;
  }
  else if(%opt == "MRAA")
  {
    $ixVWarhead[%clientId, 1] = "Medium";
    $ixVWarhead[%clientId, 2] = "Low";
    $ixVWarhead[%clientId, 3] = "Low";
    $ixVWarhead[%clientId, 4] = "Low";
    $ixVWarhead[%clientId, 5] = "Low";
    $ixVScanner[%clientId] = "Medium";
    $ixVPayload[%clientId] = 5;
    bottomprint(%clientId,"<jc><f2>Vengeance Pre-Set Activated: Medium Range Anti-Air.\n<f1>Payload: ALL Five\nScanner: Medium Range (150 Meters)\nWarheads: Medium, Low, Low, Low, Low.", 10);
    %pos = GameBase::getPosition(Client::getOwnedObject(%clientId));
    playSound(SoundChangePayload,%pos);
    Player::useItem(%clientId,Vengeance);
    return;
  }
  else if(%opt == "LRAA")
  {
    $ixVWarhead[%clientId, 1] = "Medium";
    $ixVWarhead[%clientId, 2] = "Medium";
    $ixVWarhead[%clientId, 3] = "Low";
    $ixVWarhead[%clientId, 4] = "Low";
    $ixVWarhead[%clientId, 5] = "Pause";
    $ixVScanner[%clientId] = "Long";
    $ixVPayload[%clientId] = 4;
    bottomprint(%clientId,"<jc><f2>Vengeance Pre-Set Activated: Long Range Anti-Air.\n<f1>Payload: Four\nScanner: Long Range (350 Meters)\nWarheads: Medium, Medium, Low, Low.", 10);
    %pos = GameBase::getPosition(Client::getOwnedObject(%clientId));
    playSound(SoundChangePayload,%pos);
    Player::useItem(%clientId,Vengeance);
    return;
  }
  else if(%opt == "doomsdayon")
  {
    Player::setItemCount(%clientId,Vengeance,0);
    Player::setItemCount(%clientId,DoomsdayPack,1);
    Player::mountItem(%clientId,DoomsdayPack,$BackpackSlot);
    $pxLastVScanner[%clientId] = $ixVScanner[%clientId];
    $pxLastVPayload[%clientId] = $ixVPayload[%clientId];
    for(%i = 1; %i <= 5; %i++) $pxLastVWarhead[%clientId, %i] = $ixVWarhead[%clientId, %i];
    $ixVWarhead[%clientId, 1] = "Doomsday";
    $ixVScanner[%clientId] = "Doomsday";
    $ixVPayload[%clientId] = 1;
    for(%i = 2; %i <= 5; %i++) $ixVWarhead[%clientId, %i] = "Pause";
    bottomprint(%clientId,"<jc><f2>Doomsday Missile Activated.\n<f0>Warning: Doomsday Missiles do NOT have any seeking capability!<f1>\nPayload: ONLY One\nScanner: Doomsday Scanner (250 Meters)\nWarheads: Doomsday Missile.", 10);
    %color = 0;
    for(%i = 1; %i < 4; %i += 0.2)
    {
      schedule("pxDoomsdayMessage(" @ %clientId @ ", " @ %color @ ");", %i);
      if(%color == 0) %color = 1;
      else %color = 0;
    }
    schedule("pxDoomsdayMessage(" @ %clientId @ ", 2);", 4.0);
    %pos = GameBase::getPosition(Client::getOwnedObject(%clientId));
    playSound(SoundChangePayload,%pos);
    Player::useItem(%clientId,DoomsdayPack);
    return;
  }
  else if(%opt == "doomsdayoff")
  {
    Player::setItemCount(%clientId,DoomsdayPack,0);
    Player::setItemCount(%clientId,Vengeance,1);
    Player::mountItem(%clientId,Vengeance,$BackpackSlot);
    $ixVScanner[%clientId] = $pxLastVScanner[%clientId];
    $ixVPayload[%clientId] = $pxLastVPayload[%clientId];
    for(%i = 1; %i <= 5; %i++) $ixVWarhead[%clientId, %i] = $pxLastVWarhead[%clientId, %i];
    if($pxLastVScanner[%clientId] == "Short") %sString = "Short Range (50 Meters)";
    else if($pxLastVScanner[%clientId] == "Medium") %sString = "Medium Range (150 Meters)";
    else if($pxLastVScanner[%clientId] == "Long") %sString = "Long Range (350 Meters)";
    if($pxLastVPayload[%clientId] == 1) %pString = "One";
    else if($pxLastVPayload[%clientId] == 2) %pString = "Two";
    else if($pxLastVPayload[%clientId] == 3) %pString = "Three";
    else if($pxLastVPayload[%clientId] == 4) %pString = "Four";
    else if($pxLastVPayload[%clientId] == 5) %pString = "ALL Five";
    %wString = "";
    for(%i = 1; %i <= $pxLastVPayload[%clientId]; %i++)
    {
      %wString = %wString @ $pxLastVWarhead[%clientId, %i];
      if(%i != $pxLastVPayload[%clientId]) %wString = %wString @ ", ";
    }
    bottomprint(%clientId,"<jc><f2>Doomsday Missile Deactivated.\nPrevious Vengeance Settings Restored.\n<f1>Payload: " @ %pString @ "\nScanner: " @ %sString @ "\nWarheads: " @ %wString @ ".", 10);
    %pos = GameBase::getPosition(Client::getOwnedObject(%clientId));
    playSound(SoundChangePayload,%pos);
    Player::useItem(%clientId,Vengeance);
  }
  processMenuOptions(%clientId, "vengeance");
}


function pxDoomsdayMessage(%client, %num)
{
  if(%num == 0) bottomprint(%client,"<jc><f2>Doomsday Missile Activated.\n<f1>Warning: Doomsday Missiles do NOT have any seeking capability!<f1>\nPayload: ONLY One\nScanner: Doomsday Scanner (250 Meters)\nWarheads: Doomsday Missile.", 1);
  if(%num == 1) bottomprint(%client,"<jc><f2>Doomsday Missile Activated.\n<f0>Warning: Doomsday Missiles do NOT have any seeking capability!<f1>\nPayload: ONLY One\nScanner: Doomsday Scanner (250 Meters)\nWarheads: Doomsday Missile.", 1);
  if(%num == 2) bottomprint(%client,"<jc><f2>Doomsday Missile Activated.\n<f0>Warning: Doomsday Missiles do NOT have any seeking capability!<f1>\nPayload: ONLY One\nScanner: Doomsday Scanner (250 Meters)\nWarheads: Doomsday Missile.", 11);
}


function processMenuCustomPreSet(%clientId, %option)
{
  %opt = getWord(%option, 0);
  %setting = getWord(%option, 1);
  %current = getWord(%option, 2);
  %pos = GameBase::getPosition(Client::getOwnedObject(%clientId));
  if(%opt == "set")
  {
    $pxCustomPreSet[%clientId] = "NotSet";
    Client::buildMenu(%clientId, "Choose Scanner:", "custompreset", true);
    Client::addMenuItem(%clientId, "1Short/Wide", "scan Short");
    Client::addMenuItem(%clientId, "2Medium/Thin", "scan Medium");
    Client::addMenuItem(%clientId, "3Long/Tight", "scan Long");
    return;
  }
  else if(%opt == "scan")
  {
    playSound(SoundChangePayload, %pos);
    $pxCustomPreSet[%clientId] = $pxCustomPreSet[%clientId] @ " " @ %setting;
    Client::buildMenu(%clientId, "Choose Payload:", "custompreset", true);
    Client::addMenuItem(%clientId, "1Load 1 Warhead", "payload 1 0");
    Client::addMenuItem(%clientId, "2Load 2 Warheads", "payload 2 0");
    Client::addMenuItem(%clientId, "3Load 3 Warheads", "payload 3 0");
    Client::addMenuItem(%clientId, "4Load 4 Warheads", "payload 4 0");
    Client::addMenuItem(%clientId, "5Load 5 Warheads", "payload 5 0");
    return;
  }
  else if(%opt == "payload")
  {
    playSound(SoundLoadWarhead, %pos);
    $pxCustomPreSet[%clientId] = $pxCustomPreSet[%clientId] @ " " @ %setting;
    %current += 1;
    if(%current == getWord($pxCustomPreSet[%clientId], 2)) %menu = "done";
    else %menu = "payload";
    Client::buildMenu(%clientId, "Choose Warhead #" @ %current @ ":", "custompreset", true);
    Client::addMenuItem(%clientId, "1L: Low", %menu @ " Low " @ %current);
    Client::addMenuItem(%clientId, "2M: Medium", %menu @ " Medium " @ %current);
    Client::addMenuItem(%clientId, "3H: High", %menu @ " High " @ %current);
    Client::addMenuItem(%clientId, "4E: EMP", %menu @ " EMP " @ %current);
    Client::addMenuItem(%clientId, "5P: Pause", %menu @ " Pause " @ %current);
    return;
  }
  else if(%opt == "done")
  {
    playSound(SoundLoadWarhead, %pos);
    $pxCustomPreSet[%clientId] = $pxCustomPreSet[%clientId] @ " " @ %setting;
    %scanner = getWord($pxCustomPreSet[%clientId], 1);
    %payload = getWord($pxCustomPreSet[%clientId], 2);
    %name = String::getSubStr(%scanner, 0, 1) @ "R Custom:  ";
    for(%i = 1; %i <= 5; %i++)
    {
      %warhead[%i] = getWord($pxCustomPreSet[%clientId], (%i + 2));
      if(%warhead[%i] == "") %warhead[%i] = "Pause";
      if(%i <= %payload)
      {
        %name = %name @ String::getSubStr(%warhead[%i], 0, 1);
        if(%i != %payload) %name = %name @ ", ";
      }
    }
    $pxCustomPreSet[%clientId] = %name @ " * " @ %scanner @ " " @ %payload;
    for(%x = 1; %x <= 5; %x++) $pxCustomPreSet[%clientId] = $pxCustomPreSet[%clientId] @ " " @ %warhead[%x];
    processMenuCustomPreSet(%clientId, "use");
  }
  else if(%opt == "use")
  {
    if(getWord($pxCustomPreSet[%clientId], 0) != "NotSet")
    {
      %mark = String::findSubStr($pxCustomPreSet[%clientId], "*");
      %preSet = String::getSubStr($pxCustomPreSet[%clientId], (%mark + 2), ixStrLen($pxCustomPreSet[%clientId]));
      %scanner = getWord(%preSet, 0);
      %payload = getWord(%preSet, 1);
      for(%i = 1; %i <= 5; %i++) %warhead[%i] = getWord(%preSet, (%i + 1));
      // PORT FIX: every word of a custom pre-set comes from client menu codes. The payload count
      // is later spliced into a schedule() string by ixLockLaser, the scanner into an item name.
      if(%scanner != "Short" && %scanner != "Medium" && %scanner != "Long") { $pxCustomPreSet[%clientId] = "NotSet"; return; }
      %payload = floor(%payload);
      if(%payload < 1 || %payload > 5) { $pxCustomPreSet[%clientId] = "NotSet"; return; }
      for(%i = 1; %i <= 5; %i++)
      {
      	if(%warhead[%i] != "Low" && %warhead[%i] != "Medium" && %warhead[%i] != "High" && %warhead[%i] != "EMP") %warhead[%i] = "Pause";
      }
      if(%scanner == "Short") %sString = "Short Range (50 Meters)";
      else if(%scanner == "Medium") %sString = "Medium Range (150 Meters)";
      else if(%scanner == "Long") %sString = "Long Range (350 Meters)";
      if(%payload == 1) %pString = "One";
      else if(%payload == 2) %pString = "Two";
      else if(%payload == 3) %pString = "Three";
      else if(%payload == 4) %pString = "Four";
      else if(%payload == 5) %pString = "ALL Five";
      %wString = "";
      for(%i = 1; %i <= %payload; %i++)
      {
        %wString = %wString @ %warhead[%i];
        if(%i != %payload) %wString = %wString @ ", ";
      }
      $ixVScanner[%clientId] = %scanner;
      $ixVPayload[%clientId] = %payload;
      for(%i = 1; %i <= 5; %i++) $ixVWarhead[%clientId, %i] = %warhead[%i];
      bottomprint(%clientId,"<jc><f2>Custom Pre-Set Activated.\n<f1>Payload: " @ %pString @ "\nScanner: " @ %sString @ "\nWarheads: " @ %wString @ ".", 10);
      playSound(SoundChangePayload, %pos);
      Player::useItem(%clientId, Vengeance);
    }
    else processMenuCustomPreSet(%clientId, "set");
  }
}


function processMenuPXMines(%clientId, %option)
{
  %opt = getWord(%option, 0);
  if(%opt == "default")
  {
    $pxMineLoadout[%clientId] = "Antipersonel";
    bottomprint(%clientId,"<jc><f2>Standard Mines Prepped and Ready.\n<f1>Standard Mines are the default mine type, and have no special features.\n\n<f0>Note that only Standard mines may be placed close to your team's flag stand and not explode on contact.",10);
  }
  if(%opt == "cloaked")
  {
    $pxMineLoadout[%clientId] = "Cloaked";
    bottomprint(%clientId,"<jc><f2>Cloaked Mines Prepped and Ready.\n<f1>Cloaked Mines will cloak upon deployment, and are only noticable by its pinging noise.\n\n<f0>Note that only Standard mines may be placed close to your team's flag stand and not explode on contact.",10);
  }
  if(%opt == "concussion")
  {
    $pxMineLoadout[%clientId] = "Concussion";
    bottomprint(%clientId,"<jc><f2>Concussion Mines Prepped and Ready.\n<f1>Concussion Mines do near no damage, but knock the victim very hard, repelling the target far away.\n\n<f0>Note that only Standard mines may be placed close to your team's flag stand and not explode on contact.",10);
  }
  if(%opt == "emp")
  {
    $pxMineLoadout[%clientId] = "EMP";
    bottomprint(%clientId,"<jc><f2>EMP Mines Prepped and Ready.\n<f1>EMP Mines do near no damage, but the target suffers from the EMP effect.\n\n<f0>Note that only Standard mines may be placed close to your team's flag stand and not explode on contact.",10);
  }
}


function processMenuBoomBox(%clientid, %opt)
{
  if(%opt == "reset")
  {
    $BoomBoxTimer[%clientId] = "1:00";
    %text = "reset to Default";
  }
  else
  {
    $BoomBoxTimer[%clientId] = pxAdjustTimer($BoomBoxTimer[%clientId], %opt, 20);
    %text = "now set to";
  }
  %msg = "<jc><f1>Boom Box Timer " @ %text @ ": <f2>" @ $BoomBoxTimer[%clientId] @ "<f1>\nYou can still detonate your Boom Box manually at any time.\n\n<f0>Note that this does not affect any Boom Boxes already in play.";
  bottomprint(%clientId, %msg, 10);
  processMenuOptions(%clientId, "boomboxtimer");
}


function Insomniax_ServerLvlTxt()
{
  if($Insomniax::tkServerLvl == 0) %tkText = "Only Logging TK's";
  else if($Insomniax::tkServerLvl == 1) %tkText = "Votes at " @ $Insomniax::tkLimit @ " TK's";
  else if($Insomniax::tkServerLvl == 2) %tkText = "Votes at " @ $Insomniax::tkLimit @ " TKs and Kicks at " @ $Insomniax::tkLimit * $Insomniax::tkMultiple @ " TK's";
  else if($Insomniax::tkServerLvl == 3) %tkText = "Kicks at " @ $Insomniax::tkLimit @ " TK's";
  else %tkText = "ERROR: Server Level set to Unkown Level";
  return %tkText;
}


function Insomniax_ClientLvlTxt()
{
  if($Insomniax::tkClientLvl == 0) %tkText = "Vote Option at " @ $Insomniax::tkLimit @ " TK's";
  else if($Insomniax::tkClientLvl == 1) %tkText = "Kick Option at " @ $Insomniax::tkLimit @ "TK's";
  else %tkText = "ERROR: Client Level set to Unkown Level";
  return %tkText;
}


function Insomniax_setTeamKill(%victimId, %killerId)
{
  $tkVictim[%killerId] = %victimId;
  $tkKiller[%victimId] = %killerId;
  $tkKills[%killerId] += 1;
  echo("PX-Admin: TK Recorded. victimId: ",%victimId," killerId: ",%killerId," Killer now has ",$tkKills[%killerId]," TKs");
  %trigger = $tkKills[%killerId] % $Insomniax::tkLimit;
  %tkTopKills = $Insomniax::tkLimit * $Insomniax::tkMultiple;
  if(($tkKills[%killerId] >= $Insomniax::tkLimit) && (!%trigger))
  {
    if($Insomniax::tkServerLvl)
    {
      if($Insomniax::tkServerLvl != 3)
      {
        if(($tkKills[%killerId] >= %tkTopKills) && ($Insomniax::tkServerLvl != 1))
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


function Insomniax_clearPA(%admin)
{
  if(%admin.isSuperAdmin)
  {
    %name = Client::getName(%admin);
    ixAdminMsg("Command: " @ %name @ " Purge All Public Admins.");
    %numPlayers = getNumClients();
    for(%i = 0; %i < %numPlayers; %i++)
    {
      %pl = getClientByIndex(%i);
      if(!%pl.isSuperAdmin && %pl.isAdmin)
      {
        %pl.isAdmin = false;
        Client::sendMessage(%pl,1,"Your Admin Status has been revoked by the Super Admin.");
        ixAdminMsg("Stripped Admin Status from " @ Client::getName(%pl));
      }
    }
    ixAdminMsg("Purge Complete.");
  }
}


function Insomniax_getKiller(%clientId)
{
  return $tkKiller[%clientId];
}


function Insomniax_getVictim(%clientId)
{
  return $tkVictim[%clientId];
}


function ixInitPlayer(%clientId)
{
  if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId];
  if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId];
  $tkKiller[%clientId] = %clientId;
  $tkVictim[%clientId] = %clientId;
  $tkKills[%clientId] = 0;
  %clientId.empTime = 0;
  %clientId.flareTime = 0;
  %clientId.nanites = 0;
  %clientId.nanitesTime = 0;
  %clientId.heat = 0;
  %clientId.cool = "false";
  %clientId.detonate = false;
  %clientId.RetributionTarget = "";
  %clientId.RetributionDamType = "";
  %clientId.RetributionVecIn = "";
  %clientId.beenHelped = "";
  $ixLockTime[%clientId] = 0;
  $ixLockedTarget[%clientId] = false;
  return;
}


function Insomniax_leaveGame(%clientId)
{
  ixInitPlayer(%clientId);
  deleteObject(%clientId.deployables);
}


function Insomniax_joinGame(%clientId)
{
  ixInitPlayer(%clientId);
  %clientId.custom = true;
  $ixVPayload[%clientId] = "5";
  $ixVScanner[%clientId] = "Long";
  $ixVWarhead[%clientId, 1] = "Medium";
  $ixVWarhead[%clientId, 2] = "Medium";
  $ixVWarhead[%clientId, 3] = "Medium";
  $ixVWarhead[%clientId, 4] = "Medium";
  $ixVWarhead[%clientId, 5] = "Medium";
  $pxCustomPreSet[%clientId] = "NotSet";
  %clientId.DoomsdayMode = 0;
  $pxMineLoadout[%clientId] = "Antipersonel";
  $BoomBoxTimer[%clientId] = "1:00";
  $pxObserverAngle[%clientId] = "Orbit";
  $pxObserverOrbit[%clientId] = 5;
  %clientId.deployables = newObject("set",SimSet);
}


function Insomniax_loadMission()
{
  echo("PX-Admin: Player's Team Killer Counts Reset to Zero.");
  %numPlayers = getNumClients();
  for(%i = 0; %i < %numPlayers; %i++)
  {
    %pl = getClientByIndex(%i);
    $tkKills[%pl] = 0;
    deleteObject(%pl.deployables);
    %pl.deployables = newObject("set",SimSet);
  }
}


function ixAllSkinsOff()
{
  echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
  $Insomniax::PSkin = "false";
  bottomprintall("<jc><f2>Custom Skins Disabled by Server Admin.\n<f1>Changes Take Place on Next Respawn.", 5);
  %numPlayers = getNumClients();
  for(%i = 0; %i < %numPlayers; %i++)
  {
    %pl = getClientByIndex(%i);
    if(%pl.custom) %pl.custom = false;
  }
  echo("PX-Admin: Personal Skins Option Disabled.");
  echo("PX-Admin: All Skins Reset to Server Choice.");
  echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
}


function ixAllSkinsOn()
{
  echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
  $Insomniax::PSkin = "true";
  bottomprintall("<jc><f2>Custom Skins Enabled by Server Admin.\n<f1>Option added to Menu.", 5);
  echo("PX-Admin: Personal Skins Option Enabled.");
  echo("PX-Admin: Players Must Choose Option from Menu.");
  echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
}


function ixWhoIsOn()
{
  echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
  echo("PX-Admin: # cl: CLIENT nm: NAME ip: ADDRESS");
  %numPlayers = getNumClients();
  %j=0;
  for(%i = 0; %i < %numPlayers; %i++)
  {
    %pl = getClientByIndex(%i);
    echo("PX-Admin: ",%i," cl: ",%pl," nm: ",Client::getName(%pl)," ip: ",Client::getTransportAddress(%pl));
  }
  echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
}


function ixLockouts()
{
  echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
  echo("PX-Admin: Public Admin Lockout Status.");
  echo("PX-Admin: [",isLocked($Insomniax::PATeamChange),"] Team Change");
  echo("PX-Admin: [",isLocked($Insomniax::PAKick),"] Kick");
  echo("PX-Admin: [",isLocked($Insomniax::PABan),"] Ban");
  echo("PX-Admin: [",isLocked($Phobiax::PARestrain),"] Restrain");
  echo("PX-Admin: [",isLocked($Insomniax::PAGag),"] Gag");
  echo("PX-Admin: [",isLocked($Insomniax::PAMission),"] Change Mission");
  echo("PX-Admin: [",isLocked($Insomniax::PATeamInfo),"] Team Info");
  echo("PX-Admin: [",isLocked($Insomniax::PATeamDamage),"] Team Damage");
  echo("PX-Admin: [",isLocked($Insomniax::PAFairTeams),"] Fair Teams");
  echo("PX-Admin: [",isLocked($Phobiax::PARandTeams),"] Randomized Teams");
  echo("PX-Admin: [",isLocked($Insomniax::PATourneyMode),"] Tourney Mode");
  echo("PX-Admin: [",isLocked($Insomniax::PATimeLimit),"] Time Limit");
  echo("PX-Admin: [",isLocked($Insomniax::PAResetDefaults),"] Reset Server Defaults");
  echo("PX-Admin: [",isLocked($Insomniax::PAModOptions),"] Mod Options");
  echo("PX-Admin: [",isLocked($Insomniax::PAVote),"] Admin Voting");
  echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
  echo("PX-Admin: Public Voting Lockout Status.");
  echo("PX-Admin: [",isLocked($Insomniax::PVKick),"] Kick");
  echo("PX-Admin: [",isLocked($Insomniax::PVMission),"] Change Mission");
  echo("PX-Admin: [",isLocked($Insomniax::PVFairTeams),"] Fair Teams");
  echo("PX-Admin: [",isLocked($Phobiax::PVRandTeams),"] Randomized Teams");
  echo("PX-Admin: [",isLocked($Insomniax::PVTeamDamage),"] Team Damage");
  echo("PX-Admin: [",isLocked($Insomniax::PVTourneyMode),"] Tourney Mode");
  echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
}


function ixToggle(%lockout)
{
  if(%lockout != "")
  {
    if(%lockout == "PATeamChange")
    {
      %access = "Admin: Team Change";
      if($Insomniax::PATeamChange) $Insomniax::PATeamChange = "false";
      else $Insomniax::PATeamChange = "true";
      %toggle = $Insomniax::PATeamChange;
    }
    else if(%lockout == "PAKick")
    {
      %access = "Admin: Kick";
      if($Insomniax::PAKick) $Insomniax::PAKick = "false";
      else $Insomniax::PAKick = "true";
      %toggle = $Insomniax::PAKick;
    }
    else if(%lockout == "PABan")
    {
      %access = "Admin: Ban";
      if($Insomniax::PABan) $Insomniax::PABan = "false";
      else $Insomniax::PABan = "true";
      %toggle = $Insomniax::PABan;
    }
    else if(%lockout == "PARestrain")
    {
      %access = "Admin: Phobiax Expansion Items";
      if($Phobiax::PARestrain) $Phobiax::PARestrain = "false";
      else $Phobiax::PARestrain = "true";
      %toggle = $Phobiax::PARestrain;
    }
    else if(%lockout == "PAGag")
    {
      %access = "Admin: Gag";
      if($Insomniax::PAGag) $Insomniax::PAGag = "false";
      else $Insomniax::PAGag = "true";
      %toggle = $Insomniax::PAGag;
    }
    else if(%lockout == "PAMission")
    {
      %access = "Admin: Change Mission";
      if($Insomniax::PAMission) $Insomniax::PAMission = "false";
      else $Insomniax::PAMission = "true";
      %toggle = $Insomniax::PAMission;
    }
    else if(%lockout == "PATeamDamage")
    {
      %access = "Admin: Enable/Disable Team Damage";
      if($Insomniax::PATeamDamage) $Insomniax::PATeamDamage = "false";
      else $Insomniax::PATeamDamage = "true";
      %toggle = $Insomniax::PATeamDamage;
    }
    else if(%lockout == "PAFairTeams")
    {
      %access = "Admin: Enable/Disable Fair Team Checking";
      if($Insomniax::PAFairTeams) $Insomniax::PAFairTeams = "false";
      else $Insomniax::PAFairTeams = "true";
      %toggle = $Insomniax::PAFairTeams;
    }
    else if(%lockout == "PARandTeams")
    {
      %access = "Admin: Enable/Disable Randomized Teams";
      if($Phobiax::PARandTeams) $Phobiax::PARandTeams = "false";
      else $Phobiax::PARandTeams = "true";
      %toggle = $Phobiax::PARandTeams;
    }
    else if(%lockout == "PATourneyMode")
    {
      %access = "Admin: Toggle Tourney/FFA Mode";
      if($Insomniax::PATourneyMode) $Insomniax::PATourneyMode = "false";
      else $Insomniax::PATourneyMode = "true";
      %toggle = $Insomniax::PATourneyMode;
    }
    else if(%lockout == "PATimeLimit")
    {
      %access = "Admin: Change Time Limit";
      if($Insomniax::PATimeLimit) $Insomniax::PATimeLimit = "false";
      else $Insomniax::PATimeLimit = "true";
      %toggle = $Insomniax::PATimeLimit;
    }
    else if(%lockout == "PAResetDefaults")
    {
      %access = "Admin: Reset Sever";
      if($Insomniax::PAResetDefaults) $Insomniax::PAResetDefaults = "false";
      else $Insomniax::PAResetDefaults = "true";
      %toggle = $Insomniax::PAResetDefaults;
    }
    else if(%lockout == "PAModOptions")
    {
      %access = "Admin: IX-Admin Options";
      if($Insomniax::PAModOptions) $Insomniax::PAModOptions = "false";
      else $Insomniax::PAModOptions = "true";
      %toggle = $Insomniax::PAModOptions;
    }
    else if(%lockout == "PATeamInfo")
    {
      %access = "Admin: Set Team Info";
      if($Insomniax::PATeamInfo) $Insomniax::PATeamInfo = "false";
      else $Insomniax::PATeamInfo = "true";
      %toggle = $Insomniax::PATeamInfo;
    }
    else if(%lockout == "PVKick")
    {
      %access = "Client: Vote to Kick";
      if($Insomniax::PVKick) $Insomniax::PVKick = "false";
      else $Insomniax::PVKick = "true";
      %toggle = $Insomniax::PVKick;
    }
    else if(%lockout == "PVMission")
    {
      %access = "Client: Vote to Change Mission";
      if($Insomniax::PVMission) $Insomniax::PVMission = "false";
      else $Insomniax::PVMission = "true";
      %toggle = $Insomniax::PVMission;
    }
    else if(%lockout == "PVTeamDamage")
    {
      %access = "Client: Vote to Enable/Disable Team Damage";
      if($Insomniax::PVTeamDamage) $Insomniax::PVTeamDamage = "false";
      else $Insomniax::PVTeamDamage = "true";
      %toggle = $Insomniax::PVTeamDamage;
    }
    else if(%lockout == "PVTourneyMode")
    {
      %access = "Client: Vote to Change to Tourney/FFA Mode";
      if($Insomniax::PVTourneyMode) $Insomniax::PVTourneyMode = "false";
      else $Insomniax::PVTourneyMode = "true";
      %toggle = $Insomniax::PVTourneyMode;
    }
    else if(%lockout == "PVFairTeams")
    {
      %access = "Client: Vote to Toggle Fair Team Checking";
      if($Insomniax::PVFairTeams) $Insomniax::PVFairTeams = "false";
      else $Insomniax::PVFairTeams = "true";
      %toggle = $Insomniax::PVFairTeams;
    }
    else if(%lockout == "PVRandTeams")
    {
      %access = "Client: Vote to toggle Randomized Teams";
      if($Phobiax::PVRandTeams) $Phobiax::PVRandTeams = "false";
      else $Phobiax::PVRandTeams = "true";
      %toggle = $Phobiax::PVRandTeams;
    }
    else if(%lockout == "PAVote")
    {
      %access = "Client: Vote for Admin";
      if($Insomniax::PAVote) $Insomniax::PAVote = "false";
      else $Insomniax::PAVote = "true";
      %toggle = $Insomniax::PAVote;
    }
    else if(%lockout == "PVUnLockAll")
    {
      %access = "Client: All Vote Options";
      %toggle = "true";
      $Insomniax::PVKick = "true";
      $Insomniax::PVMission = "true";
      $Insomniax::PVFairTeams = "true";
      $Insomniax::PVTeamDamage = "true";
      $Insomniax::PVTourneyMode = "true";
      $Phobiax::PVRandTeams = "true";
    }
    else if(%lockout == "PVLockAll")
    {
      %access = "Client: All Vote Options";
      %toggle = "false";
      $Insomniax::PVKick = "false";
      $Insomniax::PVMission = "false";
      $Insomniax::PVFairTeams = "false";
      $Insomniax::PVTeamDamage = "false";
      $Insomniax::PVTourneyMode = "false";
      $Phobiax::PVRandTeams = "false";
    }
    else if(%lockout == "PAUnLockAll")
    {
      %access = "Admin: All Options";
      %toggle = "true";
      $Insomniax::PATeamChange = "true";
      $Insomniax::PAKick = "true";
      $Insomniax::PABan = "true";
      $Phobiax::PARestrain = "true";
      $Insomniax::PAGag = "true";
      $Insomniax::PAMission = "true";
      $Insomniax::PATeamInfo = "true";
      $Insomniax::PATeamDamage = "true";
      $Insomniax::PAFairTeams = "true";
      $Phobiax::PARandTeams = "true";
      $Insomniax::PATourneyMode = "true";
      $Insomniax::PATimeLimit = "true";
      $Insomniax::PAResetDefaults = "true";
      $Insomniax::PAModOptions = "true";
      $Insomniax::PAVote = "true";
    }
    else if(%lockout == "PALockAll")
    {
      %access = "Admin: All Options";
      %toggle = "false";
      $Insomniax::PATeamChange = "false";
      $Insomniax::PAKick = "false";
      $Insomniax::PABan = "false";
      $Phobiax::PARestrain = "false";
      $Insomniax::PAGag = "false";
      $Insomniax::PAMission = "false";
      $Insomniax::PATeamInfo = "false";
      $Insomniax::PATeamDamage = "false";
      $Insomniax::PAFairTeams = "false";
      $Phobiax::PARandTeams = "false";
      $Insomniax::PATourneyMode = "false";
      $Insomniax::PATimeLimit = "false";
      $Insomniax::PAResetDefaults = "false";
      $Insomniax::PAModOptions = "false";
      $Insomniax::PAVote = "false";
    }
    else
    {
      echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
      echo("PX-Admin: ERROR: Unknown Lockout ",%lockout);
      echo("PX-Admin: NOTE: Lockouts ARE Case Sensative");
      echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
      echo("PX-Admin: Usage: ixToggle(<lockout>);");
      echo("PX-Admin: Example: ixToggle(\"PVUnLockAll\");");
      echo("PX-Admin: Example: ixToggle(\"PAMission\");");
      echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
      return;
    }
    echo("PX-Admin: [" @ isLocked(%toggle) @ "] " @ %access);
  }
  else
  {
    echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
    echo("PX-Admin: <lockout> = What it Toggles.");
    echo("PX-Admin: PATeamChange = Public Admin Team Change");
    echo("PX-Admin: PAKick = Public Admin Kick");
    echo("PX-Admin: PABan = Public Admin Ban");
    echo("PX-Admin: PARestrain = Public Admin Restrain");
    echo("PX-Admin: PAGag = Public Admin Gag");
    echo("PX-Admin: PAMission = Public Admin Change Mission");
    echo("PX-Admin: PATeamInfo = Public Admin Team Info");
    echo("PX-Admin: PATeamDamage = Public Admin Team Damage");
    echo("PX-Admin: PAFairTeams = Public Admin Toggle Fair Teams");
    echo("PX-Admin: PARandTeams = Public Admin Toggle Randomized Teams");
    echo("PX-Admin: PATourneyMode = Public Admin Tourney Mode");
    echo("PX-Admin: PATimeLimit = Public Admin Time Limit");
    echo("PX-Admin: PAResetDefaults = Public Admin Reset Server Defaults");
    echo("PX-Admin: PAModOptions = Public Admin Mod Options");
    echo("PX-Admin: PVKick = Public Vote Kick");
    echo("PX-Admin: PVMission = Public Vote Change Mission");
    echo("PX-Admin: PVFairTeams = Public Vote Toggle Fair Teams");
    echo("PX-Admin: PVRandTeams = Public Vote Toggle Randomized Teams");
    echo("PX-Admin: PVTeamDamage = Public Vote Team Damage");
    echo("PX-Admin: PVTourneyMode = Public Vote Tourney Mode");
    echo("PX-Admin: PALockAll = Lock All Public Admin Options");
    echo("PX-Admin: PAUnLockAll = UnLock All Public Admin Options");
    echo("PX-Admin: PVLockAll = Lock All Public Vote Options");
    echo("PX-Admin: PVUnLockAll = UnLock All Public Vote Options");
    echo("PX-Admin: PAVote = Public Admin Voting");
    echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
    echo("PX-Admin: Usage: ixToggle(<lockout>);");
    echo("PX-Admin: Purpose: To change Lockouts from the console");
    echo("PX-Admin: Example: ixToggle(\"PVUnLockAll\");");
    echo("PX-Admin: Example: ixToggle(\"PAMission\");");
    echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
  }
}


function ixGiveAdmin(%name)
{
  if(%name != "")
  {
    %numPlayers = getNumClients();
    for(%i = 0; %i < %numPlayers; %i++)
    {

      %pl = getClientByIndex(%i);
      if((%name == Client::getName(%pl)) || (%name == "\"" @ Client::getName(%pl) @ "\""))
      {
        if(%pl.isAdmin == false)
        {
          %pl.isAdmin = true;
          bottomprint(%pl,"<f2>IX-Admin:<f1> You have Been granted Admin Status by the Super Admin.");
          echo("PX-Admin: Admin Granted: ",Client::getName(%pl));
        }
        else echo("PX-Admin: ",Client::getName(%pl)," Already has Admin Status");
        return;
      }
    }
  }
  else
  {
    echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
    echo("PX-Admin: Usage: ixGiveAdmin("<PlayerName>")");
    echo("PX-Admin: Example: ixGiveAdmin(\"*IX*Savage1);\"");
    echo("PX-Admin: Example: ixGiveAdmin(\"Dreadnaught\");");
    echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
  }
}


function ixPurgeAdmins()
{
  echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
  echo("PX-Admin: Purging All Public Admins");
  %numPlayers = getNumClients();
  %j = 0;
  for(%i = 0; %i < %numPlayers; %i++)
  {
    %pl = getClientByIndex(%i);
    if(!%pl.isSuperAdmin && %pl.isAdmin)
    {
      %j++;
      %pl.isAdmin = false;
      bottomprint(%pl,"<f2>IX-Admin:<f1> Your Admin Status was revoked by the Super Admin.");
      echo("PX-Admin: Removed Admin: ",Client::getName(%pl));
    }
  }
  echo("PX-Admin: Purging Complete.");
  echo("PX-Admin: ",%j," Admins Purged.");
  echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
}


function ixSave()
{
  echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
  echo("PX-Admin: Saving PX-Admin Settings for Phobiax ", $PhobiaxInternalVersion);
  echo("PX-Admin: Phobiax is an expansion of Insomniax ", $InsomniaxInternalVersion);
  export("Insomniax::*", "config\\PhobiaxSettings.cs", False);   // PORT: see Phobiax.cs
  export("DefaultTeamEnergy", "config\\PhobiaxSettings.cs", True);
  export("Phobiax::*", "config\\PhobiaxSettings.cs", True);
  echo("PX-Admin: Settings Saved.");
  echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
}


exec(pxUserList);


function IxAdmin_Authenticate(%clientId, %ip)
{
  if($UserList::Activated)
  {
    %name = Client::getName(%clientId);
    %user = ixGetUser(%name,%ip);
    if(%user)
    {
      %username = getWord($UserList::User[%user], 1);
      %flags = getWord($UserList::User[%user], 3);
      $ixUserInfo[%clientId] = $UserList::User[%user];
      echo("PX-Admin: User: ",%username," Identified. Access Level: ",%flags);
      ixAdminMsg("User: " @ %username @ " Identified. Access Level: " @ %flags);
      if(%flags == "AutoSuper")
      {
        %clientId.isAdmin = true;
        %clientId.isSuperAdmin = true;
        ixAdminMsg(%username @ " Automaticly Logged in.");
      }
      else if(%flags == "AutoPublic")
      {
        %clientId.isAdmin = true;
        ixAdminMsg(%username @ " Automaticly Logged in.");
      }
    }
    else
    {
      echo("PX-Admin: User: ",%name," Unknown.");
      $ixUserInfo[%clientId] = "0 " @ %name @ " None None " @ %ip;
    }
  }
}


function ixProcess(%client, %name, %user, %username, %flags, %password)
{
  if(!%client.isAdmin)
  {
    %realpass = getWord($UserList::User[%user], 2);
    if(!String::ICompare(%password, %realpass))
    {
      if((%flags == "PublicAdmin") && (%name == %username))
      {
        %client.isAdmin = true;
      }
      if((%flags == "SuperAdmin") && (%name == %username))
      {
        %client.isAdmin = true;
        %client.isSuperAdmin = true;
      }
      ixAdminMsg(%username @ " Logged in.");
    }
    else
    {
      Client::sendMessage(%client, 0,"PX-Server: Bad Password");
      ixAdminMsg(%name @ " Login attempt Failed. Username: " @ %username);
    }
  }
  else
  {
    Client::sendMessage(%client, 0,"PX-Server: You Already have Admin Status.");
  }
}


function ixAdminMsg(%msg)
{
  %numPlayers = getNumClients();
  for(%i = 0; %i < %numPlayers; %i++)
  {
    %pl = getClientByIndex(%i);
    if(%pl.isAdmin)
    {
      Client::sendMessage(%pl, 0, "PX-Server: " @ %msg);
    }
  }
}


function ixGetUser(%name,%ip)
{
  for(%i = 1; %i <= $UserList::MaxUsers; %i++)
  {
    if(%name == (getWord($UserList::User[%i], 1)))
    {
      for(%j = 4; ((%mask = getWord($UserList::User[%i], %j)) != -1); %j++)
      {
        if(ixCompareIP(%ip,%mask)) return %i;
      }
      return 0;
    }
  }
  return 0;
}


function ixPrepIP(%transport)
{
  %x = 0;
  %i = 0;
  %now = 0;
  while((%x < 2) && (%i < 30))
  {
    if(String::getSubStr(%transport,%i,1) == ":")
    {
      if(!%now) %now = %i + 1;
      else return String::getSubStr(%transport, %now, %i - %now);
      %x++;
    }
    %i++;
  }
  return "0.0.0.0";
}


function ixCompareIP(%ip, %mask)
{
  %ipNow = ixDotToSpace(%ip);
  %maskNow = ixDotToSpace(%mask);
  for(%x = 0; %x < 4; %x++)
  {
    %one = getWord(%ipNow, %x);
    %two = getWord(%maskNow, %x);
    if((%one != %two) && (%two != "*")) return "false";
  }
  return "true";
}


function ixStrLen(%string)
{
  for(%i = 0; String::getSubStr(%string, %i, 1) != ""; %i++) %length = %i;
  %length++;
  return %length;
}


function ixDotToSpace(%string)
{
  %x = 0;
  %i = 0;
  while(%x < 3 && %i < 64)
  {
    %char = String::getSubStr(%string,%i,1);
    if(!String::ICompare(%char, "."))
    {
      %left = String::getSubStr(%string,0,%i);
      %right = String::getSubStr(%string,%i + 1,(ixStrLen(%string) - %i));
      %string = strcat(%left," ",%right);
      %x++;
    }
    %i++;
  }
  return %string;
}


function Insomniax_isFairTeam(%here, %dest)
{
  %numTeams = getNumTeams();
  %numPlayers = getNumClients();
  for(%i = 0; %i < %numTeams; %i++) %numTeamPlayers[%i] = 0;
  for(%i = 0; %i < %numPlayers; %i++)
  {
    %pl = getClientByIndex(%i);
    %team = Client::getTeam(%pl);
    %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
  }
  %least = 0;
  %most = 0;
  for(%i = 0; %i < %numTeams; %i++)
  {
    if(%numTeamPlayers[%i] > %numTeamPlayers[%most]) %most = %i;
    if(%numTeamPlayers[%i] < %numTeamPlayers[%least]) %least = %i;
  }
  if(%here == -1) %here = %most;
  if(((%numTeamPlayers[%dest] + 1) - (%numTeamPlayers[%here] - 1)) <= 1) return true;
  else return false;
}


function Insomniax_onRespawn(%clientId, %playerId)
{
  %clientId.empTime = 0;
  %clientId.flareTime = 0;
  %clientId.nanites = 0;
  %clientId.nanitesTime = 0;
  %clientId.heat = 0;
  %clientId.cool = "false";
  %clientId.RetributionTarget = "";
  %clientId.RetributionDamType = "";
  %clientId.RetributionVecIn = "";
  $ixLockTime[%clientId] = 0;
  $ixLockedTarget[%clientId] = false;
  $ixFloodRockets[%clientId] = false;
  $ixLockedName[%clientId] = false;
}


function Phobiax_RandomizeTeams(%admin)
{
  if($SinglePlayer) return;
  %numTeams = getNumTeams();
  %numPlayers = getNumClients();
  for(%i = 0; %i < %numPlayers; %i++)
  {
    %pl = getClientByIndex(%i);
    if(Observer::isObserver(%pl)) %numObs += 1;
  }
  %playersInGame = %numPlayers - %numObs;
  if(%playersInGame < 3) return;
  %playersPerTeam = floor(%playersInGame / %numTeams);
  if((%playersPerTeam * %numTeams) != %playersInGame) %leftOvers = %playersInGame - (%playersPerTeam * %numTeams);
  if(%leftOvers >= %numTeams)
  {
    %playersPerTeam += 1;
    %leftOvers -= %numTeams;
  }
  for(%i = 0; %i < %numTeams; %i++)
  {
    %playersOnTeam[%i] = 0;
    %maxPlayersOnTeam[%i] = %playersPerTeam;
    if(%leftOvers > 0)
    {
      %playersOnTeam[%i] += 1;
      %leftOvers -= 1;
    }
  }
  for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
  {
    %team = floor(getRandom() * (%numTeams - 0.01));
    if(!Observer::isObserver(%cl))
    {
      if(%playersOnTeam[%team] < %maxPlayersOnTeam[%team])
      {
        GameBase::setTeam(%cl, %team);
        %playersOnTeam[%team] += 1;
        if(%admin)
        {
          %pl = Client::getOwnedObject(%cl);
          if(%pl != -1 && getObjectType(%pl) == "Player" && !Player::isDead(%pl))
          {
            playNextAnim(%cl);
            Player::kill(%cl);
          }
          %cl.teamEnergy = 0;
          deleteObject(%cl.deployables);
          %cl.deployables = newObject("set",SimSet);
          Client::clearItemShopping(%cl);
          if(Client::getGuiMode(%cl) != 1) Client::setGuiMode(%cl, 1);
          Client::setControlObject(%cl, -1);
          Game::playerSpawn(%cl, true);
          if($TeamEnergy[%team] != "Infinite") $TeamEnergy[%team] += $InitialPlayerEnergy;
        }
      }
      else %cl = %lastClient;
    }
    %lastClient = %cl;
  }
  if(%admin)
  {
    messageAll(0, "PX-Server: " @ Client::getName(%admin) @ " randomized the teams.");
    Game::resetScores();
  }
  else
  {
    messageAll(0, "PX-Server: Teams have been randomized.");
    $TeamsRandomized = true;
  }
}


function ixSay(%msg)
{
  messageAll(1,"PX-Console: " @ %msg);
  echo("PX-Console: " @ %msg);
}


function ixSaveHighScores()
{
  %gameType = getWord(pxGameType(), 0);
  %prefix = getWord(pxGameType(), 1);
  echo("PX-Server: Saving " @ %gameType @ " High Scores - " @ %prefix @ "_Scores_" @ $missionName @ ".cs.");
  export("HighScores::*", "config\\" @ %prefix @ "_Scores_" @ $missionName @ ".cs", False);
  echo("PX-Server: Refreshing Server Path");
  EvalSearchPath();
  echo("PX-Server: " @ %gameType @ " High Score Save Completed for " @ $missionName @ ".");
}


function ixLoadHighScores()
{
  %gameType = getWord(pxGameType(), 0);
  %prefix = getWord(pxGameType(), 1);
  echo("PX-Server: Loading " @ %gameType @ " High Scores - " @ %prefix @ "_Scores_" @ $missionName @ ".cs.");
  %file = %prefix @ "_Scores_" @ $missionName;
  exec(%file);
  echo("PX-Server: " @ %gameType @ " High Score Loading Completed for " @ $missionName @ ".");
}


function ixInitHighScores()
{
  %gameType = getWord(pxGameType(), 0);
  echo("PX-Server: Initializing " @ %gameType @ " High Scores.");
  $HighScores::Player1 = "Nobody";
  $HighScores::Player2 = "Nobody";
  $HighScores::Player3 = "Nobody";
  $HighScores::Player4 = "Nobody";
  $HighScores::Player5 = "Nobody";
  $HighScores::Player6 = "Nobody";
  $HighScores::Player7 = "Nobody";
  $HighScores::Player8 = "Nobody";
  $HighScores::Player9 = "Nobody";
  $HighScores::Player10 = "Nobody";
  echo("PX-Server: Initialization Complete.");
}


function pxGameType()
{
  if($Phobiax::ExpansionItems)
  {
    %gameType = "Phobiax";
    %prefix = "PX";
  }
  else
  {
    %gameType = "Insomniax";
    %prefix = "IX";
  }
  return %gameType @ " " @ %prefix;
}


function pxSettings()
{
  echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
  echo("PX-Admin: General Mod Settings.");
  echo("PX-Admin: Phobiax Expansion Items     ",isEnabled($Phobiax::ExpansionItems));
  echo("PX-Admin: Fair Teams Checking         ",isEnabled($Insomniax::FairTeams));
  echo("PX-Admin: Team Randomization          ",isEnabled($Phobiax::RandomizedTeams));
  echo("PX-Admin: Personal Skins              ",isEnabled($Insomniax::PSkin));
  echo("PX-Admin: Safe Stations               ",isEnabled($Insomniax::SafeStation));
  echo("PX-Admin: Station Kick Time           ",getClockTimer($Insomniax::StationTime));
  echo("PX-Admin: Out of Bounds Kill Time     ",getClockTimer($Insomniax::LeaveAreaTime));
  echo("PX-Admin: Ban Kick Time               ",getClockTimer($Insomniax::BanKickTime));
  echo("PX-Admin: Restrain 'No Chat' Time     ",getClockTimer($Phobiax::RestrainChatTime));
  echo("PX-Admin: Team Kill Limit             ",$Insomniax::tkLimit); 
  echo("PX-Admin: Team Kill Warnings          ",$Insomniax::tkMultiple);
  echo("PX-Admin: Server Team Kill Level      ",$Insomniax::tkServerLvl);
  echo("PX-Admin: Client Team Kill Level      ",$Insomniax::tkClientLvl);
  echo("PX-Admin: Default Team Energy         ",$DefaultTeamEnergy);
  echo("PX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
}


function pxReloadDefaults()
{
  exec("PhobiaxSettings.cs");   // PORT: was exec(phobiax), now the entry script's name
  pxSettings();
  Server::refreshData();
}


function pxAllSkinsOff()
{
  ixAllSkinsOff();
}


function pxAllSkinsOn()
{
  ixAllSkinsOn();
}


function pxWhoIsOn()
{
  ixWhoIsOn();
}


function pxLockouts()
{
  ixLockouts();
}


function pxToggle(%lockout)
{
  ixToggle(%lockout);
}


function pxGiveAdmin(%name)
{
  ixGiveAdmin(%name);
}


function pxPurgeAdmins()
{
  ixPurgeAdmins();
}


function pxSave()
{
  ixSave();
}


function pxSay(%msg)
{
  ixSay(%msg);
}


function pxSaveHighScores()
{
  ixSaveHighScores();
}


function pxLoadHighScores()
{
  ixLoadHighScores();
}


function pxInitHighScores()
{
  ixInitHighScores();
}


function ixSettings()
{
  pxSettings();
}


function ixReloadDefaults()
{
  pxReloadDefaults();
}






$curVoteTopic = "";
 $curVoteAction = "";
 $curVoteOption = "";
 $curVoteCount = 0;

 function Admin::changeMissionMenu(%clientId) { Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
 %index = 1;
 for(%type = 1;
 %type < $MLIST::TypeCount;
 %type++) if($MLIST::Type[%type] != "Training") { Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0"); %index++; } }

function processMenuCMType(%clientId, %options) { %curItem = 0;
 %option = getWord(%options, 0);
 %first = getWord(%options, 1);
 Client::buildMenu(%clientId, "Pick Mission", "cmission", true);
 for(%i = 0;
 (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++) { if(%i > 6) { Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option); break; }

Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option); } }

function processMenuCMission(%clientId, %option) { if(getWord(%option, 0) == "more") { %first = getWord(%option, 1);
 %type = getWord(%option, 2);
 processMenuCMType(%clientId, %type @ " " @ %first);
 return;
 }
 %mi = getWord(%option, 0);
 %mt = getWord(%option, 1);
 %misName = $MLIST::EName[%mi];
 %misType = $MLIST::Type[%mt];
 if(%misType == "" || %misType == "Training") return;
 for(%i = 0; true; %i++) { %misIndex = getWord($MLIST::MissionList[%mt], %i);
 if(%misIndex == %mi) break; if(%misIndex == -1) return;
 }
 if(($ultra_renegades3::PAMission && %clientId.isAdmin) || (%clientId.isSuperAdmin)) { messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
 Vote::changeMission();
 Server::loadMission(%misName);
 }
 else { Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
Game::menuRequest(%clientId); } }

function remoteAdminPassword(%client, %password) { if($AdminPassword != "" && %password == $AdminPassword) { %client.isAdmin = true; %client.isSuperAdmin = true; } }

function remoteSetPassword(%client, %password) { if(%client.isSuperAdmin) $Server::Password = %password; }

function remoteSetTimeLimit(%client, %time) { %time = floor(%time);
 if(%time == $Server::timeLimit || (%time != 0 && %time < 1)) return;
 if((%client.isAdmin && $ultra_renegades3::PATimeLimit) || (%client.isSuperAdmin)) { $Server::timeLimit = %time;
 if(%time) messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s).");
 else messageAll(0, Client::getName(%client) @ " disabled the time limit."); } }

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase) { if(%team >= 0 && %team < 8 && ((%client.isAdmin && $ultra_renegades3::PATeamInfo) || (%client.issuperAdmin))) {
 $Server::teamName[%team] = %teamName;
 $Server::teamSkin[%team] = %skinBase;
 messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission.");
 } }

function remoteVoteYes(%clientId) { %clientId.vote = "yes"; centerprint(%clientId, "", 0); }

function remoteVoteNo(%clientId) { %clientId.vote = "no"; centerprint(%clientId, "", 0); }

function Admin::startMatch(%admin) { if(%admin == -1 || %admin.isAdmin) { if(!$CountdownStarted && !$matchStarted) { if(%admin == -1) messageAll(0, "Match start countdown forced by vote.");
 else messageAll(0, "Match start countdown forced by " @ Client::getName(%admin)); Game::ForceTourneyMatchStart(); } } }

function Admin::setTeamDamageEnable(%admin, %enabled) { if(%admin == -1 || %admin.isAdmin) { if(%enabled) { $Server::TeamDamageScale = 1;
 if(%admin == -1) messageAll(0, "Team damage set to ENABLED by consensus.");
 else messageAll(0, Client::getName(%admin) @ " ENABLED team damage.");
 }
 else
 {
 $Server::TeamDamageScale = 0;
 if(%admin == -1) messageAll(0, "Team damage set to DISABLED by consensus.");
 else messageAll(0, Client::getName(%admin) @ " DISABLED team damage."); } } }

function Admin::kick(%admin, %client, %ban) { if((%admin == -1 || %admin.isAdmin) || (%admin == -2 || %admin == -3)) { if(%ban) { %word = "banned"; %cmd = "BAN: ";
 }
 else { %word = "kicked";
 %cmd = "KICK: ";
 } if(%client.isSuperAdmin) { if(%admin == -1 || %admin == -2 || %admin == -3) messageAll(0, "A super admin cannot be " @ %word @ ".");
 else Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
 return;
 }
 %ip = Client::getTransportAddress(%client);
 echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);
 if(%ip == "") return; ultra_renegades3_leaveGame(%client);
 if(%ban) BanList::add(%ip, 1800);
 else BanList::add(%ip, $ultra_renegades3::BanKickTime);
 %name = Client::getName(%client);
 if(%admin == -1) { MessageAll(0, %name @ " was " @ %word @ " from vote.");
 Net::kick(%client, "You were " @ %word @ " by  consensus.");
 } else if(%admin == -2) { MessageAll(0, %name @ " was Auto-" @ %word @ " for Team Killing.");
 Net::kick(%client, "You were Auto-" @ %word @ " for Team Killing.");
 }
 else if(%admin == -3) { MessageAll(0, %name @ " was " @ %word @ " by a TK-Victim.");
 Net::kick(%client, "You were " @ %word @ " by a TK-Victim.");
 }
 else { MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
 Net::kick(%client, "You were " @ %word @ " by " @ Client::getName(%admin));
 } } }

function Admin::setModeFFA(%clientId) { if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin)) { $Server::TeamDamageScale = 0;
 if(%clientId == -1) messageAll(0, "Server switched to Free-For-All Mode.");
 else messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".");
 $Server::TourneyMode = false;
 centerprintall();
 if(!$matchStarted && !$countdownStarted) { if($Server::warmupTime) Server::Countdown($Server::warmupTime);
 else Game::startMatch();
 } } }

function Admin::setModeTourney(%clientId) { if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin)) { $Server::TeamDamageScale = 1;
 if(%clientId == -1) messageAll(0, "Server switched to Tournament Mode.");
 else messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".");
 $Server::TourneyMode = true;
 Server::nextMission();
 } }

function Admin::voteFailed() { $curVoteInitiator.numVotesFailed++;
 if($curVoteAction == "kick" || $curVoteAction == "admin" || $curVoteAction == "tkkick") $curVoteOption.voteTarget = "";
 }


function Admin::voteSucceded() { $curVoteInitiator.numVotesFailed = "";
 if($curVoteAction == "kick") { if($curVoteOption.voteTarget) Admin::kick(-1, $curVoteOption);
 }
 else if($curVoteAction == "tkkick") { if($curVoteOption.voteTarget) Admin::kick(-2, $curVoteOption);
 }
 else if($curVoteAction == "admin") { if($curVoteOption.voteTarget) { $curVoteOption.isAdmin = true;
 messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.");
 if($curVoteOption.menuMode == "options")Game::menuRequest($curVoteOption);
 }
 $curVoteOption.voteTarget = false;
 }
 else if($curVoteAction == "cmission") { messageAll(0, "Changing to mission " @ $curVoteOption @ ".");
 Vote::changeMission();
 Server::loadMission($curVoteOption);
 }
 else if($curVoteAction == "tourney") Admin::setModeTourney(-1);
 else if($curVoteAction == "ffa") Admin::setModeFFA(-1);
 else if($curVoteAction == "etd") Admin::setTeamDamageEnable(-1, true);
 else if($curVoteAction == "dtd") Admin::setTeamDamageEnable(-1, false);
 else if($curVoteOption == "smatch") Admin::startMatch(-1);
 }

function Admin::countVotes(%curVote) { if(%curVote != $curVoteCount) return;
 %votesFor = 0;
 %votesAgainst = 0;
 %totalClients = 0;
 %totalVotes = 0;
 for(%cl = Client::getFirst();
 %cl != -1;
 %cl = Client::getNext(%cl)) { %totalClients++;
 if(%cl.vote == "yes") { %votesFor++; %totalVotes++;
 }
 else if(%cl.vote == "no") { %votesAgainst++; %totalVotes++;
 } }
 %minVotes = floor($Server::MinVotesPct * %totalClients);
 if(%minVotes < $Server::MinVotes) %minVotes = $Server::MinVotes;
 if(%totalVotes < %minVotes) { %votesAgainst += %minVotes - %totalVotes;
 %totalVotes = %minVotes;
 }
 if(%votesFor / %totalVotes >= $Server::VoteWinMargin)
 {
 messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
 Admin::voteSucceded();
 }
 else
 {
 if($curVoteAction == "kick" || $curVoteAction == "tkkick") { %votesFor = 0; %totalVotes = 0;
 for(%cl = Client::getFirst();
 %cl != -1;
 %cl = Client::getNext(%cl)) { if(GameBase::getTeam(%cl) == $curVoteOption.kickTeam) { %totalVotes++; if(%cl.vote == "yes") %votesFor++;
 } }
 if(%totalVotes >= $Server::MinVotes && %votesFor / %totalVotes >= $Server::VoteWinMargin) { messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ ".");
 Admin::voteSucceded(); $curVoteTopic = "";
 return;
 } }
 messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
 Admin::voteFailed();
 }
 $curVoteTopic = "";
 }

function Admin::startVote(%clientId, %topic, %action, %option) { if(%clientId.lastVoteTime == "") %clientId.lastVoteTime = -$Server::MinVoteTime;
 %time = getIntegerTime(true) >> 5;
 %diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time;
 if(%diff > 0) { Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
 return;
 }
 if($curVoteTopic == "") { if(%clientId.numFailedVotes) %time += %clientId.numFailedVotes * $Server::VoteFailTime;
 %clientId.lastVoteTime = %time; $curVoteInitiator = %clientId;
 $curVoteTopic = %topic;
 $curVoteAction = %action;
 $curVoteOption = %option;
 if(%action == "kick" || %action == "tkkick") $curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
 $curVoteCount++;
 if(%action == "tkkick") { %IXtker = getWord(%topic, 3);
 %IXtkKills = $tkKills[getClientByName(%IXtker)];
 bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic @ "\n " @ %IXtker @ " <f0> has a Confirmed <f1>" @ %IXtkKills @ " TEAM KILLS", 10);
 }
 else bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
 for(%cl = Client::getFirst();
 %cl != -1;
 %cl = Client::getNext(%cl)) %cl.vote = "";
 %clientId.vote = "yes";
 for(%cl = Client::getFirst();
 %cl != -1;
 %cl = Client::getNext(%cl)) if(%cl.menuMode == "options")Game::menuRequest(%clientId);
 schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", $Server::VotingTime, 35);
 }
 else { Client::sendMessage(%clientId, 0, "Voting already in progress.");
 } }

function Game::menuRequest(%clientId) { %curItem = 0; Client::buildMenu(%clientId, "Options", "options", true);
 if(!$matchStarted || !$Server::TourneyMode) { Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
 }
 if(%clientId.selClient) { %sel = %clientId.selClient; %name = Client::getName(%sel); if($curVoteTopic == "" && !%clientId.isSuperAdmin)
 {
 if($ultra_renegades3::PAVote && !%clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
 if($ultra_renegades3::PAKick && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
 else
 if($ultra_renegades3::PAKick) Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
 if($ultra_renegades3::PABan && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
 if($ultra_renegades3::PATeamChange && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
 }



 else if(%clientId.isSuperAdmin) { if(!%sel.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
 Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
 Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
 Client::addMenuItem(%clientId, %curItem++ @ "Execute " @ %name, "execute " @ %sel);
 Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
 } if(%clientId.muted[%sel]) Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
 else
 Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
 }
 if($curVoteTopic != "" && %clientId.vote == "") { Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
 Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
 }
 else if($curVoteTopic == "" && !%clientId.isSuperAdmin) { if($ultra_renegades3::PAMission && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
 else if($ultra_renegades3::PAMission) Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
 if($ultra_renegades3::PATeamDamage && %clientId.isAdmin) if($Server::TeamDamageScale == 1.0) Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
 else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
 else
 if($Server::TeamDamageScale == 1.0) Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
 else
 Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
 if($ultra_renegades3::PATourneyMode && %clientId.isAdmin) if($Server::TourneyMode) { Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
 if(!$CountdownStarted && !$matchStarted) Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
 }
 else
 Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
 else if($Server::TourneyMode) { Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
 if(!$CountdownStarted && !$matchStarted) Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
 }
 else Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
 if($ultra_renegades3::PATimeLimit && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
 if($ultra_renegades3::PAResetDefaults && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
 if($ultra_renegades3::PAModOptions && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Server Options", "ultra_renegades3");
 }
 else if(%clientId.isSuperAdmin) { Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
 if($Server::TeamDamageScale == 1.0) Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
 else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
 if($Server::TourneyMode) { Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
 if(!$CountdownStarted && !$matchStarted) Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
 } else Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
 Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
 Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
 Client::addMenuItem(%clientId, %curItem++ @ "Server Options", "ultra_renegades3");
 }
 %IXKiller = ultra_renegades3_getKiller(%clientId);
 if((%IXKiller != %clientId) && ($tkKills[%IXKiller] >= $ultra_renegades3::tkLimit)) { if($ultra_renegades3::tkClientLvl == 1) Client::addMenuItem(%clientId,
 %curItem++ @ "Kick Team Killer " @ Client::getName(ultra_renegades3_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller)));
 else
 Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick " @ Client::getName(ultra_renegades3_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller)));
 } }


function remoteSelectClient(%clientId, %selId) { if(%clientId.selClient != %selId) { %clientId.selClient = %selId;
 if(%clientId.menuMode == "options") Game::menuRequest(%clientId);
 if(ultra_renegades3_getVictim(%selId) == %selId) %selLastTK = "None Here";
 else %selLastTK = Client::getName(ultra_renegades3_getVictim(%selId));
 if(ultra_renegades3_getKiller(%selId) == %selId) %selTKdBy = "None Here";
 else %selTKdBy = Client::getName(ultra_renegades3_getKiller(%selId));
 %selKills = $tkKills[%selId];
 remoteEval(%clientId, "setInfoLine", 1, "Team Kill Info for " @ Client::getName(%selId) @ ":");
 remoteEval(%clientId, "setInfoLine", 2, "Last TK Victim: " @ %selLastTK);
 remoteEval(%clientId, "setInfoLine", 3, "Last TK'd By: " @ %selTKdBy);
 remoteEval(%clientId, "setInfoLine", 4, "Number of TKs: " @ %selKills);
 remoteEval(%clientId, "setInfoLine", 5, "Server: " @ ultra_renegades3_ServerLvlTxt());
 if(%clientId.isSuperAdmin) remoteEval(%clientId, "setInfoLine", 6, "Client: " @ Client::getTransportAddress(%selId));
 else remoteEval(%clientId, "setInfoLine", 6, "Client: " @ ultra_renegades3_ClientLvlTxt());
 } }

function processMenuFPickTeam(%clientId, %team) { if(ultra_renegades3_PA(%clientId, $ultra_renegades3::PATeamChange)) processMenuPickTeam(%clientId.ptc, %team, %clientId);
 %clientId.ptc = "";
 }

function processMenuPickTeam(%clientId, %team, %adminClient) { checkPlayerCash(%clientId);
 if(%team != -1 && %team == Client::getTeam(%clientId)) return;
 if(%clientId.observerMode == "justJoined") { %clientId.observerMode = "";
 centerprint(%clientId, "");
 } if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2) { if(Observer::enterObserverMode(%clientId)) { %clientId.notready = "";
 if(%adminClient == "") messageAll(0, Client::getName(%clientId) @ " became an observer.");
 else messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
 Game::resetScores(%clientId); Game::refreshClientScore(%clientId);
 }
 return;
 }
 %player = Client::getOwnedObject(%clientId);
 if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) { playNextAnim(%clientId);
 Player::kill(%clientId); } %clientId.observerMode = "";
 if(%adminClient == "") messageAll(0, Client::getName(%clientId) @ " changed teams.");
 else messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
 if(%team == -1) { Game::assignClientTeam(%clientId); %team = Client::getTeam(%clientId);
 }
 GameBase::setTeam(%clientId, %team);
 %clientId.teamEnergy = 0;
 Client::clearItemShopping(%clientId);
 if(Client::getGuiMode(%clientId) != 1) Client::setGuiMode(%clientId,1);
 Client::setControlObject(%clientId, -1); Game::playerSpawn(%clientId, false);
 %team = Client::getTeam(%clientId); if($TeamEnergy[%team] != "Infinite") $TeamEnergy[%team] += $InitialPlayerEnergy;
 if($Server::TourneyMode && !$CountdownStarted) { bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
 %clientId.notready = true;
 } }

function processMenuOptions(%clientId, %option) { %opt = getWord(%option, 0);
 %cl = getWord(%option, 1);
 if(%opt == "fteamchange") { %clientId.ptc = %cl;
 Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
 Client::addMenuItem(%clientId, "0Observer", -2);
 Client::addMenuItem(%clientId, "1Automatic", -1);
 for(%i = 0;
 %i < getNumTeams(); %i = %i + 1) Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
 return;
 } else if(%opt == "changeteams") { if(!$matchStarted || !$Server::TourneyMode) { Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
 Client::addMenuItem(%clientId, "0Observer", -2); Client::addMenuItem(%clientId, "1Automatic", -1);
 if($ultra_renegades3::fairTeams){ %i = Game::LowTeam(); Client::addMenuItem(%clientId, (2) @ getTeamName(%i), %i);
 } else { for(%i = 0;
 %i < getNumTeams();
 %i = %i + 1) Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
 }
 return;
 } }
 else if(%opt == "mute") %clientId.muted[%cl] = true;
 else if(%opt == "unmute") %clientId.muted[%cl] = "";
 else if(%opt == "vkick" && $ultra_renegades3::PAKick) { %cl.voteTarget = true;
 Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
 }
 else if(%opt == "vadmin" && $ultra_renegades3::PAVote) { %cl.voteTarget = true;
 Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
 }
 else if(%opt == "vsmatch") Admin::startVote(%clientId, "start the match", "smatch", 0);
 else if(%opt == "vetd") Admin::startVote(%clientId, "enable team damage", "etd", 0);
 else if(%opt == "vdtd") Admin::startVote(%clientId, "disable team damage", "dtd", 0);
 else if(%opt == "etd" && ultra_renegades3_PA(%clientId, $ultra_renegades3::PATeamDamage)) Admin::setTeamDamageEnable(%clientId, true);
 else if(%opt == "dtd" && ultra_renegades3_PA(%clientId, $ultra_renegades3::PATeamDamage)) Admin::setTeamDamageEnable(%clientId, false);
 else if(%opt == "vcffa") Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
 else if(%opt == "vctourney") Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
 else if(%opt == "cffa" && ultra_renegades3_PA(%clientId, $ultra_renegades3::PATourneyMode)) Admin::setModeFFA(%clientId);
 else if(%opt == "ctourney" && ultra_renegades3_PA(%clientId, $ultra_renegades3::PATourneyMode)) Admin::setModeTourney(%clientId);
 else if(%opt == "voteYes" && %cl == $curVoteCount) { %clientId.vote = "yes"; centerprint(%clientId, "", 0);
 }
 else if(%opt == "voteNo" && %cl == $curVoteCount) { %clientId.vote = "no";
 centerprint(%clientId, "", 0);
 }
 else if(%opt == "kick") { Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
 Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
 Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
 return;
 }
 else if(%opt == "execute" && %clientId.isSuperAdmin) { Client::buildMenu(%clientId, "Confirm execution:", "maffirm", true);
 Client::addMenuItem(%clientId, "1Kill the Fucker " @ Client::getName(%cl), "yes " @ %cl);
 Client::addMenuItem(%clientId, "2Don't Kill the Fucker " @ Client::getName(%cl), "no " @ %cl);
 return;
 }
 else if(%opt == "admin" && %clientId.isSuperAdmin) { Client::buildMenu(%clientId, "Confirm Admin:", "aaffirm", true);
 Client::addMenuItem(%clientId, "1Make " @ Client::getName(%cl) @ " Admin", "yes " @ %cl);
 Client::addMenuItem(%clientId, "2Don't Make " @ Client::getName(%cl) @ " Admin", "no " @ %cl);
 return;
 }

 else if(%opt == "ban") { Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);

 Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
 Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl); return;
 }
 else if(%opt == "smatch" && ultra_renegades3_PA(%clientId, $ultra_renegades3::PATourneyMode)) Admin::startMatch(%clientId);
 else if(%opt == "vcmission" || %opt == "cmission") { Admin::changeMissionMenu(%clientId, %opt == "cmission");
 return;
 }
 else if(%opt == "ctimelimit") { Client::buildMenu(%clientId, "Change Time Limit:", "ctlimit", true);
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
 else if(%opt == "reset") { Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
 Client::addMenuItem(%clientId, "1Reset", "yes");
 Client::addMenuItem(%clientId, "2Don't Reset", "no");
 return;
 }
 else if(%opt == "ultra_renegades3" && ultra_renegades3_PA(%clientId, $ultra_renegades3::PAModOptions)) { Client::buildMenu(%clientId, "Server Options:", "ixsettings", true);
 Client::addMenuItem(%clientId, "1Change Server Anti-TK Lvl", "tkserv " @ $ultra_renegades3::tkServerLvl);
 Client::addMenuItem(%clientId, "2Change Client Anti-TK Lvl", "tkclient " @ $ultra_renegades3::tkClientLvl);
 if(%clientId.isSuperAdmin) Client::addMenuItem(%clientId, "3Public Admin Voting", "adminvote " @ $ultra_renegades3::PAVote);
 if(%clientId.isSuperAdmin) Client::addMenuItem(%clientId, "4Public Mission Change Voting", "changevote " @ $ultra_renegades3::PAMission );
 if(%clientId.isSuperAdmin) Client::addMenuItem(%clientId, "5Public Kick Voting", "kickvote " @ $ultra_renegades3::PAKick );
 if(%clientId.isSuperAdmin) Client::addMenuItem(%clientId, "6Fair Teams", "fairvote " @ $ultra_renegades3::fairTeams );
 if(%clientId.isSuperAdmin) Client::addMenuItem(%clientId, "7Public Admin Lockouts", "palockout");
 if(%clientId.isSuperAdmin) Client::addMenuItem(%clientId, "8Purge Public Admins", "purge " @ %clientId);
 return;
 }
 else if(%opt == "tkopt" && $ultra_renegades3::tkLimit > 0 && ultra_renegades3_getKiller(%clientId) != %clientId && $tkKills[ultra_renegades3_getKiller(%clientId)] >= $ultra_renegades3::tkLimit) { %cl = ultra_renegades3_getKiller(%clientId); if($ultra_renegades3::tkClientLvl == 1) Admin::Kick(-3, %cl);
 else { %cl.voteTarget = true;
 %clientId.selClient = ultra_renegades3_getKiller(%clientId);
 Admin::startVote(%clientId, "Kick Team Killer " @ Client::getName(%cl), "tkkick", %cl);
 } }
 Game::menuRequest(%clientId);
 }

function processMenuKAffirm(%clientId, %opt) { if(getWord(%opt, 0) == "yes" && ultra_renegades3_PA(%clientId, $ultra_renegades3::PAKick)) Admin::kick(%clientId, getWord(%opt, 1));
Game::menuRequest(%clientId);
 }

function processMenuMAffirm(%clientId, %opt) { if(getWord(%opt, 0) == "yes" && %clientId.isSuperAdmin) { %cl = getWord(%opt, 1);
 MessageAll(1, "The skies above open up and a bolt of lightning falls from the sky...");
 MessageAllExcept(%cl , 1, Client::getName(%cl) @ " was executed by the Ultra_Renegade Admin " @ Client::getName(%clientId) @ ".");
 Client::sendMessage(%cl ,1,"You were executed by the Ultra_Renegade Admin " @ Client::getName(%clientId) @ ".");
 playNextAnim(%cl); Player::kill(%cl); Client::onKilled(%cl,%cl);
 }
 Game::menuRequest(%clientId); }

function processMenuAAffirm(%clientId, %opt) { if(getWord(%opt, 0) == "yes" && %clientId.isSuperAdmin) { %cl = getWord(%opt, 1);
 %cl.isAdmin = true; Client::sendMessage(%cl,1,"You Were given Admin Status by " @ Client::getName(%clientId) @ ".");
 Client::sendMessage(%clientId,1,"You gave Admin Status to " @ Client::getName(%cl) @ ".");
 }
 Game::menuRequest(%clientId);
 }

function processMenuBAffirm(%clientId, %opt) { if(getWord(%opt, 0) == "yes" && ultra_renegades3_PA(%clientId, $ultra_renegades3::PABan)) Admin::kick(%clientId, getWord(%opt, 1), true);
 Game::menuRequest(%clientId);
 }

function processMenuRAffirm(%clientId, %opt) { if(%opt == "yes" && ultra_renegades3_PA(%clientId, $ultra_renegades3::PAResetDefaults)) { messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
 Server::refreshData();
 }
 Game::menuRequest(%clientId);
 }

function processMenuCTLimit(%clientId, %opt) { remoteSetTimeLimit(%clientId, %opt); }

function processMenuIXSettings(%clientId, %option) { %opt = getWord(%option, 0); if(!ultra_renegades3_PA(%clientId, $ultra_renegades3::PAModOptions)) return; if(!%clientId.isSuperAdmin && %opt != "tkserv" && %opt != "tkclient") return;
 %cl = getWord(%option, 1);
 if(%opt == "patoggle") { Client::sendMessage(%clientId, 3, "Public Admin Vote is now " @ isonoff(%cl) @ ".");
 $ultra_renegades3::PAVote = %cl;
 }
 if(%opt == "cmtoggle") { Client::sendMessage(%clientId, 3, "Public Mission Vote is now " @ isonoff(%cl) @ ".");
 $ultra_renegades3::PAMission = %cl;
 }
 if(%opt == "pktoggle") { Client::sendMessage(%clientId, 3, "Public Kick Vote is now " @ isonoff(%cl) @ ".");
 $ultra_renegades3::PAKick = %cl;
 } if(%opt == "fairtoggle") { Client::sendMessage(%clientId, 3, "Fair Teams is now " @ isonoff(%cl) @ ".");
 $ultra_renegades3::fairTeams = %cl;
 }
 else if(%opt == "tkserv") { Client::buildMenu(%clientId, "Current Server Anti-TK: " @ %cl, "ServerLvl", true);
 Client::addMenuItem(%clientId, "0Log TK's only", 0);
 Client::addMenuItem(%clientId, "1Auto Vote TKer", 1);
 Client::addMenuItem(%clientId, "2Auto Vote Until Kicked", 2);
 Client::addMenuItem(%clientId, "3Auto Kick TKer", 3);
 return;
 }
 else if(%opt == "tkclient") { Client::buildMenu(%clientId, "Current Client Anti-TK: " @ %cl, "ClientLvl", true);
 Client::addMenuItem(%clientId, "0Client Vote Option", 0);
 Client::addMenuItem(%clientId, "1Client Kick Option", 1);
 return;
 }
 else if(%opt == "areakill") { Client::buildMenu(%clientId, "Out of Bounds Kill Time: " @ %cl @ " Seconds", "AKill", true);
 Client::addMenuItem(%clientId, "0Set to Off", 0);
 Client::addMenuItem(%clientId, "1Set to 10 Seconds", 10);
 Client::addMenuItem(%clientId, "2Set to 15 Seconds", 15);
 Client::addMenuItem(%clientId, "3Set to 20 Seconds", 20);
 Client::addMenuItem(%clientId, "4Set to 25 Seconds", 25);
 Client::addMenuItem(%clientId, "5Set to 30 Seconds", 30);
 Client::addMenuItem(%clientId, "6Set to 40 Seconds", 40);
 Client::addMenuItem(%clientId, "7Set to 60 Seconds", 60);
 return;
 }
 else if(%opt == "palockout") { Client::buildMenu(%clientId, "Current Public Admin Lockouts:","PALockouts", true);
 Client::addMenuItem(%clientId, "1Team Changing " @ isonoff($ultra_renegades3::PATeamChange), "teamchange " @ $ultra_renegades3::PATeamChange);
 Client::addMenuItem(%clientId, "2Kicking " @ isonoff($ultra_renegades3::PAKick), "kick " @ $ultra_renegades3::PAKick);
 Client::addMenuItem(%clientId, "3Banning " @ isonoff($ultra_renegades3::PABan), "ban " @ $ultra_renegades3::PABan);
 Client::addMenuItem(%clientId, "4Change Mission " @ isonoff($ultra_renegades3::PAMission), "mission " @ $ultra_renegades3::PAMission);
 Client::addMenuItem(%clientId, "5Team Damage " @ isonoff($ultra_renegades3::PATeamDamage), "teamdamage " @ $ultra_renegades3::PATeamDamage);
 Client::addMenuItem(%clientId, "6Tourney Mode " @ isonoff($ultra_renegades3::PATourneyMode), "tourney " @ $ultra_renegades3::PATourneyMode);
 Client::addMenuItem(%clientId, "7Time Limit " @ isonoff($ultra_renegades3::PATimeLimit), "timelimit " @ $ultra_renegades3::PATimeLimit);
 Client::addMenuItem(%clientId, "8Additional Lockouts ...", "additional");
 return;
 }
 else if(%opt == "adminvote") { Client::buildMenu(%clientId, "Public Admin Vote is " @ isonoff(%cl), "ixsettings", true);
 Client::addMenuItem(%clientId, "0Turn OFF Public Admin", "patoggle false");
 Client::addMenuItem(%clientId, "1Turn ON Public Admin", "patoggle true");
 return;
 }
 else if(%opt == "changevote") { Client::buildMenu(%clientId, "Public Mission Change Vote is " @ isonoff(%cl), "ixsettings", true);
 Client::addMenuItem(%clientId, "0Turn OFF Mission Change", "cmtoggle false");
 Client::addMenuItem(%clientId, "1Turn ON Mission Change", "cmtoggle true");
 return;
 }
 else if(%opt == "kickvote") { Client::buildMenu(%clientId, "Public Kick Vote is " @ isonoff(%cl), "ixsettings", true);
 Client::addMenuItem(%clientId, "0Turn OFF Public Kick", "pktoggle false");
 Client::addMenuItem(%clientId, "1Turn ON Public Kick", "pktoggle true");
 return;
 }
 else if(%opt == "fairvote") { Client::buildMenu(%clientId, "Fair Teams is " @ isonoff(%cl), "ixsettings", true);
 Client::addMenuItem(%clientId, "0Turn OFF Fair Teams", "fairtoggle false");
 Client::addMenuItem(%clientId, "1Turn ON Fair Teams", "fairtoggle true");
 return;
 }
 else if(%opt == "purge") { Client::sendMessage(%cl,3,"Purging All Public Admins of Admin Status.");
 ultra_renegades3_clearPA(%cl);
 Client::sendMessage(%cl,3,"Purging Complete.");
 return;
 } }

function processMenuPALockouts(%clientId, %option) { %opt = getWord(%option, 0); if(!%clientId.isSuperAdmin) return;
 %toggle = getWord(%option, 1);
 if(%opt == "additional") { Client::buildMenu(%clientId, "Current Public Admin Lockouts:","PALockouts", true);
 Client::addMenuItem(%clientId, "1Server Defaults " @ isonoff($ultra_renegades3::PAResetDefaults), "reset " @ $ultra_renegades3::PAResetDefaults);
 Client::addMenuItem(%clientId, "2Server Options " @ isonoff($ultra_renegades3::PAModOptions), "modopt " @ $ultra_renegades3::PAModOptions);
 Client::addMenuItem(%clientId, "3Set Team Info " @ isonoff($ultra_renegades3::PATeamInfo), "teaminfo " @ $ultra_renegades3::PATeamInfo);
 Client::addMenuItem(%clientId, "4Turn ON all Options", "allon");
 return;
 }
 else if(%opt == "allon") { %access = "All Options"; %toggle = "false";
 $ultra_renegades3::PATeamChange = "true";
 $ultra_renegades3::PAKick = "true";
 $ultra_renegades3::PABan = "true";
 $ultra_renegades3::PAMission = "true";
 $ultra_renegades3::PATeamDamage = "true";
 $ultra_renegades3::PATourneyMode = "true";
 $ultra_renegades3::PATimeLimit = "true";
 $ultra_renegades3::PAResetDefaults = "true";
 $ultra_renegades3::PAModOptions = "true";
 }
 else if(%opt == "teamchange") { %access = "Team Changing";
 if(%toggle) $ultra_renegades3::PATeamChange = "false";
 else $ultra_renegades3::PATeamChange = "true";
 }
 else if(%opt == "kick") { %access = "Kicking";
 if(%toggle) $ultra_renegades3::PAKick = "false";
 else $ultra_renegades3::PAKick = "true";
 }
 else if(%opt == "ban") { %access = "Banning";
 if(%toggle) $ultra_renegades3::PABan = "false";
 else $ultra_renegades3::PABan = "true";
 }
 else if(%opt == "mission") { %access = "Changing Mission";
 if(%toggle) $ultra_renegades3::PAMission = "false";
 else $ultra_renegades3::PAMission = "true";
 }
 else if(%opt == "teamdamage") { %access = "Team Damage";
 if(%toggle) $ultra_renegades3::PATeamDamage = "false";
 else $ultra_renegades3::PATeamDamage = "true";
 }
 else if(%opt == "tourney") { %access = "Tourney Mode";
 if(%toggle) $ultra_renegades3::PATourneyMode = "false";
 else $ultra_renegades3::PATourneyMode = "true";
 }
 else if(%opt == "timelimit") { %access = "Mission Time Limit";
 if(%toggle) $ultra_renegades3::PATimeLimit = "false";
 else $ultra_renegades3::PATimeLimit = "true";
 }
 else if(%opt == "reset") { %access = "Reseting Sever to Defaults";
 if(%toggle) $ultra_renegades3::PAResetDefaults = "false";
 else $ultra_renegades3::PAResetDefaults = "true";
 }
 else if(%opt == "modopt") { %access = "ultra_renegades3 Mod Options";
 if(%toggle) $ultra_renegades3::PAModOptions = "false";
 else $ultra_renegades3::PAModOptions = "true";
 }
 else if(%opt == "teaminfo") { %access = "Setting Team Info";
 if(%toggle) $ultra_renegades3::PATeamInfo = "false";
 else $ultra_renegades3::PATeamInfo = "true";
 }
 if(%toggle) %toggle = "false";
 else %toggle = "true";
 Client::sendMessage(%clientId, 3, "Public Admin Access to " @ %access @ " is now " @ isonoff(%toggle) @ ".");
 }


// PORT: true for a super admin, or for an admin when that public-admin lockout is open.
function ultra_renegades3_PA(%clientId, %allowed)
{
   if(%clientId.isSuperAdmin)
      return true;
   if(%clientId.isAdmin && %allowed)
      return true;
   return false;
}

// PORT: the Fair Teams menu calls Game::LowTeam(), which this build never defined.
function Game::LowTeam()
{
   %numTeams = getNumTeams();
   for(%i = 0; %i < %numTeams; %i++)
      %teamCount[%i] = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %team = Client::getTeam(%cl);
      if(%team >= 0 && %team < %numTeams)
         %teamCount[%team] = %teamCount[%team] + 1;
   }
   %low = 0;
   for(%i = 1; %i < %numTeams; %i++)
   {
      if(%teamCount[%i] < %teamCount[%low])
         %low = %i;
   }
   return %low;
}

function isonoff(%toggle) { if(%toggle) return "On"; else return "Off"; }

function processMenuServerLvl(%clientId, %option) { if(!ultra_renegades3_PA(%clientId, $ultra_renegades3::PAModOptions)) return; $ultra_renegades3::tkServerLvl = %option;
 if(%option == 0) messageAll(0, "SERVER:TK Protection Level Set to Zero. (Logging TK's only).");
 if(%option == 1) messageAll(0, "SERVER:TK Protection Level Set to One. (Auto Vote).");
 if(%option == 2) messageAll(0, "SERVER:TK Protection Level Set to Two. (Auto Vote Until Kicked).");
 if(%option == 3) messageAll(0, "SERVER:TK Protection Level Set to Three. (Auto Kick).");
 }


function processMenuClientLvl(%clientId, %option) { if(!ultra_renegades3_PA(%clientId, $ultra_renegades3::PAModOptions)) return; $ultra_renegades3::tkClientLvl = %option;
 if(%option == 0) messageAll(0, "SERVER: Client TK Vote Option Engaged. (From Options Menu).");
 if(%option == 1) messageAll(0, "SERVER: Client TK Kick Option Engaged. (From Options Menu).");
 }

function processMenuAKill(%clientId, %option) { if(!%clientId.isSuperAdmin) return; $ultra_renegades3::LeaveAreaTime = %option;
 if(%option == 0) messageAll(0, "SERVER: Leaving Mission Area Now Does not Kill you.");
 else messageAll(0, "SERVER: Leaving Mission Area Now Kills you in " @ %option @ " Seconds.");
 }

function ultra_renegades3_ServerLvlTxt() { if($ultra_renegades3::tkServerLvl == 0) %tkText = "Only Logging TK's";
 else if($ultra_renegades3::tkServerLvl == 1) %tkText = "Votes at " @ $ultra_renegades3::tkLimit @ " TK's";
 else if($ultra_renegades3::tkServerLvl == 2) %tkText = "Votes at " @ $ultra_renegades3::tkLimit @ " TKs and Kicks at " @ $ultra_renegades3::tkLimit * $ultra_renegades3::tkMultiple @ " TK's";
 else if($ultra_renegades3::tkServerLvl == 3) %tkText = "Kicks at " @ $ultra_renegades3::tkLimit @ " TK's";
 else %tkText = "ERROR: Server Level set to Unkown Level";
 return %tkText;
 }

function ultra_renegades3_ClientLvlTxt() { if($ultra_renegades3::tkClientLvl == 0) %tkText = "Vote Option at " @ $ultra_renegades3::tkLimit @ " TK's";
 else if($ultra_renegades3::tkClientLvl == 1) %tkText = "Kick Option at " @ $ultra_renegades3::tkLimit @ "TK's";
 else %tkText = "ERROR: Client Level set to Unkown Level";
 return %tkText;
 }

function ultra_renegades3_setTeamKill(%victimId, %killerId) { $tkVictim[%killerId] = %victimId;
 $tkKiller[%victimId] = %killerId;
 $tkKills[%killerId] += 1;
 %trigger = $tkKills[%killerId] % $ultra_renegades3::tkLimit;
 %tkTopKills = $ultra_renegades3::tkLimit * $ultra_renegades3::tkMultiple;
 if(($tkKills[%killerId] >= $ultra_renegades3::tkLimit) && (!%trigger)) { if($ultra_renegades3::tkServerLvl)
 {
if($ultra_renegades3::tkServerLvl != 3) { if(($tkKills[%killerId] >= %tkTopKills) && ($ultra_renegades3::tkServerLvl != 1))
 {
 messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing. Confirmed " @ $tkKills[%killerId] @ " Team Kills.");
 Admin::Kick(-2, %killerId);
 return;
 }
 %killerId.voteTarget = true; %victimId.selClient = ultra_renegades3_getKiller(%victimId);
 Admin::startVote(%victimId, "Kick Team Killer " @ Client::getName(%killerId), "tkkick", %killerId);
 }
 else { messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing. Confirmed " @ $tkKills[%killerId] @ " Team Kills.");
 Admin::Kick(-2, %killerId);
 } } }
 return;
 }

function ultra_renegades3_getKiller(%clientId) { return $tkKiller[%clientId]; }

function ultra_renegades3_getVictim(%clientId) { return $tkVictim[%clientId]; }

function ultra_renegades3_leaveGame(%clientId) { if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId];
 if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId];
 $tkKiller[%clientId] = %clientId;
 $tkVictim[%clientId] = %clientId;
 $tkKills[%clientId] = 0;
 $empTime[%clientId] = 0;
 return;
 }

function ultra_renegades3_joinGame(%clientId) { if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId];
 if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId];
 $tkVictim[%clientId] = %clientId; $tkKiller[%clientId] = %clientId;
 $tkKills[%clientId] = 0;
 $empTime[%clientId] = 0;
 }

function ultra_renegades3_clearPA(%admin) { if(%admin.isSuperAdmin) { %numPlayers = getNumClients();
 for(%i = 0; %i < %numPlayers;
 %i++) { %pl = getClientByIndex(%i);
 if(!%pl.isSuperAdmin && %pl.isAdmin) { %pl.isAdmin = false; Client::sendMessage(%pl,1,"Your Admin Status has been revoked by the Super Admin.");
 Client::sendMessage(%admin,3,"Public Admin Status Stripped from: " @ Client::getName(%pl) @ ".");
 } } } }

function ixwhoison() { echo(" # cl: CLIENT nm: NAME ip: ADDRESS");
 %numPlayers = getNumClients();
 for(%i = 0; %i < %numPlayers;
 %i++) { %pl = getClientByIndex(%i);
 %name = Client::getName(%pl);
 %ip = Client::getTransportAddress(%pl);
 echo(" " @ %i @ " cl: " @ %pl @ " nm: " @ %name @ " ip: " @ %ip);
 } }
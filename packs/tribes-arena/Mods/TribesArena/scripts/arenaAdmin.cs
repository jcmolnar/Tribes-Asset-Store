// __________________________________________________________________________
// Tribes Arena v3.0 for Starsiege Tribes                          2002-06-15
// by Lizard (irc.dynamix.com on #lizrena, or belgarion@tribes2universe.com)
// __________________________________________________________________________
// Modified "admin.cs"
// __________________________________________________________________________
//

$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;
function Admin::LizCheckProtectedIPList(%clientId)
{
%ip = Client::getTransportAddress(%clientId);
for(%tmpindex = 1; %tmpindex <= $ProtectedIPListCount; %tmpindex++)
{
if ($ProtectedIPList[%tmpindex] != "") {
%idx = String::FindSubStr(%ip, $ProtectedIPList[%tmpindex]);
if (%idx != -1)
{
echo("LIZADMIN: " @ %clientId @ " \"" @
escapeString(Client::getName(%clientId)) @
"\" on " @ Client::getTransportAddress(%clientId) @
" was protected by ProtectedIPList[" @ %tmpindex @ "]");
return 1;
}
}
}
return 0;
}
function Admin::LizCheckNoAdminIPList(%clientId)
{
%ip = Client::getTransportAddress(%clientId);
for(%tmpindex = 1; %tmpindex <= $NoAdminIPListCount; %tmpindex++)
{
if ($NoAdminIPList[%tmpindex] != "") {
%idx = String::FindSubStr(%ip, $NoAdminIPList[%tmpindex]);
if (%idx != -1)
{
echo("LIZADMIN: " @ %clientId @ " \"" @
escapeString(Client::getName(%clientId)) @
"\" on " @ Client::getTransportAddress(%clientId) @
" was found on the NoAdminIPList[" @ %tmpindex @ "]");
return 1;
}
}
}
return 0;
}
function Admin::LizCheckAdminPasswordNameLookupExceptionIP(%clientId)
{
%ip = Client::getTransportAddress(%clientId);
for(%tmpindex = 1; %tmpindex <= $AdminPasswordNameLookupExceptionIPCount; %tmpindex++)
{
if ($AdminPasswordNameLookupExceptionIP[%tmpindex] != "") {
%idx = String::FindSubStr(%ip, $AdminPasswordNameLookupExceptionIP[%tmpindex]);
if (%idx != -1)
{
echo("LIZADMIN: " @ %clientId @ " \"" @
escapeString(Client::getName(%clientId)) @
"\" on " @ Client::getTransportAddress(%clientId) @
" was found on the AdminPasswordNameLookupExceptionIP[" @ %tmpindex @ "]");
return 1;
}
}
}
return 0;
}
function Admin::LizCheckAdminPasswordNameLookup(%clientId)
{
%name = Client::getName(%clientId);
for(%tmpindex = 1; %tmpindex <= $AdminPasswordNameLookupCount; %tmpindex++)
{
if ($AdminPasswordNameLookup[%tmpindex] != "") {
%idx = String::FindSubStr(%name, $AdminPasswordNameLookup[%tmpindex]);
if (%idx != -1)
{
return 1;
}
}
}
return 0;
}
function Admin::changeMissionMenu(%clientId, %option)
{
Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
%index = 1;
if ($MList::TypeCount < 2) $TypeStart = 0;
else $TypeStart = 1;
for(%type = $TypeStart; %type < $MLIST::TypeCount; %type++)
if($MLIST::Type[%type] != "Training")
{
if(($MapDuelOnlySuperAdmin == 1) && ($MLIST::Type[%type] == "Duel"))
{
if (%clientId.IsSuperAdmin)
{
Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0 " @ %option);
%index++;
}
}
else
{
Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0 " @ %option);
%index++;
}
}
}
function processMenuCMType(%clientId, %options)
{
%curItem = 0;
%option = getWord(%options, 0);
%first = getWord(%options, 1);
%extraoption = getWord(%options, 2);
Client::buildMenu(%clientId, "Pick Mission", "cmission", true);
for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
{
if(%i > 6)
{
Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option @ " " @ %extraoption);
break;
}
Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option @ " " @ %extraoption);
}
}
function processMenuCMission(%clientId, %option)
{
if(getWord(%option, 0) == "more")
{
%first = getWord(%option, 1);
%type = getWord(%option, 2);
%extraoption = getWord(%option, 3);
processMenuCMType(%clientId, %type @ " " @ %first @ " " @ %extraoption);
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
if ($AllAdminsCanVoteMaps == 1)
{
if(%clientId.isAdmin && getWord(%option, 2) == "cmission")
{
messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
Vote::changeMission();
Server::loadMission(%misName);
}
else
{
if (($Game::missionType != "") && ($Game::missionType == $Arena::GameMissionType) && ($Arena::MatchMode == 0) && ($LizStatsLoaded == 1))
{
if (LizStats::CheckIfCurrentMap(%misName) == true)
{
Client::sendMessage(%clientId, 1, "You are already playing " @ $missionName @ ". Vote cancelled.");
}
else
{
%lastplayed = LizStats::CheckLastPlayedMaps(%misName);
if (%lastplayed == 0)
{
Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
Game::menuRequest(%clientId);
}
else
{
%recentmaplist = LizStats::GetRecentMapList();
if (%recentmaplist != "") {
%recentmaplist = "Recently played maps are: " @ %recentmaplist @ ". ";
}
Client::sendMessage(%clientId, 1, "This map has already been played too recently. Please select another map. Vote cancelled.");
}
}
}
else
{
Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
Game::menuRequest(%clientId);
}
}
}
else
{
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
}
function remoteAdminPassword(%client, %password)
{
if($AdminPassword == "")
return;
if(%password == "") return; // PORT: an empty password must never match an empty list slot
%isProhibited = Admin::LizCheckNoAdminIPList(%client);
if (%isProhibited == 1)
return;
if (%password == $UnadminPassword) {
%client.isAdmin = false;
%client.isTrustedAdmin = false;
%client.isSuperAdmin = false;
%client.isServerSuperAdmin = false;
Game::refreshClientScore(%client);
return;
}
for(%tmpindex = 1; %tmpindex <= $KickMyselfCount; %tmpindex++)
{
if (%password == $KickMyselfPassword[%tmpindex])
{
Client::sendMessage(%client, 1, "You have just entered the 'kick myself' password. Just stop asking for it?");
schedule("remoteAdminPasswordKick(" @ %client @ ");", 1, %client);
echo("LIZADMIN: " @ %client @ " \"" @
escapeString(Client::getName(%client)) @
"\" on " @ Client::getTransportAddress(%client) @
" has been entered the kick password..");
}
}
if($ServerAdminPassword != "" && %password == $ServerAdminPassword)
{
%client.isAdmin = true;
%client.isTrustedAdmin = true;
%client.isSuperAdmin = true;
%client.isServerSuperAdmin = true;
Game::refreshClientScore(%client);
echo("LIZADMIN: " @ %client @ " \"" @
escapeString(Client::getName(%client)) @
"\" on " @ Client::getTransportAddress(%client) @
" has been server super admined using ServerAdminPassword");
}
if($AdminPassword != "" && %password == $AdminPassword)
{
if ($AdminPasswordNameLookupEnable == 1)
{
%exceptionlist = Admin::LizCheckAdminPasswordNameLookupExceptionIP(%client);
if (%exceptionlist == 0) {
%namelookup = Admin::LizCheckAdminPasswordNameLookup(%client);
if (%namelookup == 0) {
Client::sendMessage(%client,1,"Your name is not on the registered admins list. Contact the server admin if you feel this is an error.");
return;
}
}
}
%client.isAdmin = true;
%client.isTrustedAdmin = true;
%client.isSuperAdmin = true;
Game::refreshClientScore(%client);
echo("LIZADMIN: " @ %client @ " \"" @
escapeString(Client::getName(%client)) @
"\" on " @ Client::getTransportAddress(%client) @
" has been super admined using AdminPassword");
}
for(%tmpindex = 1; %tmpindex <= $TrustedAdminCount; %tmpindex++)
{
if (%password == $TrustedAdminPassword[%tmpindex])
{
if ($AdminPasswordNameLookupEnable == 1)
{
%exceptionlist = Admin::LizCheckAdminPasswordNameLookupExceptionIP(%client);
if (%exceptionlist == 0) {
%namelookup = Admin::LizCheckAdminPasswordNameLookup(%client);
if (%namelookup == 0) {
Client::sendMessage(%client,1,"Your name is not on the registered admins list. Contact the server admin if you feel this is an error.");
return;
}
}
}
%client.isAdmin = true;
%client.isTrustedAdmin = true;
Game::refreshClientScore(%client);
echo("LIZADMIN: " @ %client @ " \"" @
escapeString(Client::getName(%client)) @
"\" on " @ Client::getTransportAddress(%client) @
" has been admined using TrustedAdminPassword");
}
}
for(%tmpindex = 1; %tmpindex <= $RegularAdminCount; %tmpindex++)
{
if (%password == $RegularAdminPassword[%tmpindex])
{
if ($AdminPasswordNameLookupEnable == 1)
{
%exceptionlist = Admin::LizCheckAdminPasswordNameLookupExceptionIP(%client);
if (%exceptionlist == 0) {
%namelookup = Admin::LizCheckAdminPasswordNameLookup(%client);
if (%namelookup == 0) {
Client::sendMessage(%client,1,"Your name is not on the registered admins list. Contact the server admin if you feel this is an error.");
return;
}
}
}
%client.isAdmin = true;
Game::refreshClientScore(%client);
echo("LIZADMIN: " @ %client @ " \"" @
escapeString(Client::getName(%client)) @
"\" on " @ Client::getTransportAddress(%client) @
" has been admined using RegularAdminPassword");
}
}
}
function remoteAdminPasswordKick(%client)
{
%isProtected = Admin::LizCheckProtectedIPList(%client);
if (%isProtected == 1)
{
Client::sendMessage(%client, 1, "You are on the protected IP list. Kick/ban cancelled.");
return;
}
%ip = Client::getTransportAddress(%client);
if(%ip == "")
return;
BanList::add(%ip, $AdminKickPasswordTimeSeconds);
%name = Client::getName(%client);
echo("LIZADMIN: " @ %client @ " \"" @
escapeString(Client::getName(%client)) @
"\" on " @ Client::getTransportAddress(%client) @
" was kicked for using the kick password.");
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1))
LizStats::UpdateServerStatsTotalKicks(1);
MessageAll(0, %name @ " has decided to come back later..");
Net::kick(%client, "You were " @ %word @ " by yourself.");
}
function remoteSetPassword(%client, %password)
{
if((%client.isSuperAdmin) || (%client.isTrustedAdmin && $TrustedAdminCanSetServerPassword == 1))
{
echo("LIZADMIN: " @ %client @ " \"" @
escapeString(Client::getName(%client)) @
"\" on " @ Client::getTransportAddress(%client) @
" has changed the server password"); // PORT: the password itself is not logged
$Server::Password = %password;
}
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
if(%ban == "pban")
{
%permaban = true;
%ban = true;
%word = "perma-banned";
%wordverb = "perma-ban";
%cmd = "PERMABAN: ";
}
else if(%ban)
{
%permaban = false;
%word = "banned";
%wordverb = "ban";
%cmd = "BAN: ";
}
else
{
%permaban = false;
%word = "kicked";
%wordverb = "kick";
%cmd = "KICK: ";
}
echo("LIZADMIN: " @ %admin @ " \"" @
escapeString(Client::getName(%admin)) @
"\" on " @ Client::getTransportAddress(%admin) @
" wants to " @ %wordverb @ " \"" @
escapeString(Client::getName(%client)) @
"\" on " @ Client::getTransportAddress(%client));
%isProtected = Admin::LizCheckProtectedIPList(%client);
if (%isProtected == 1)
{
Client::sendMessage(%client, 1, "You are on the protected IP list. Kick/ban from " @ Client::getName(%admin) @ " cancelled.");
Client::sendMessage(%admin, 1, "You are unfortunately not able to do that.");
return;
}
if(%admin != %client && (%admin == -1 || %admin.isAdmin))
{
if(%ban && !%admin.isSuperAdmin)
return;
if(%permaban && !%admin.isServerSuperAdmin)
return;
if(%client.isSuperAdmin)
{
if(%admin.isServerSuperAdmin)
{
}
else
{
if(%admin == -1)
messageAll(0, "A super admin cannot be " @ %word @ ".");
else
Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
return;
}
}
if(%client.isTrustedAdmin)
{
if(%ban)
{
}
else
{
if (%admin.isSuperAdmin)
{
}
else
{
if ($TrustedAdminCanNotBeKicked == 1)
{
if(%admin == -1)
messageAll(0, "This admin cannot be " @ %word @ ".");
else
Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
return;
}
}
}
}
%ip = Client::getTransportAddress(%client);
echo("LIZADMIN: " @ %cmd @ %admin @ " " @ %client @ " " @ %ip);
if(%ip == "")
return;
if(%permaban)
BanList::add(%ip, $AdminPermaBanTimeSeconds);
else if(%ban)
BanList::add(%ip, $AdminBanTimeSeconds);
else
BanList::add(%ip, $AdminKickTimeSeconds);
%name = Client::getName(%client);
if(%admin == -1)
{
echo("LIZADMIN: " @ %client @ " \"" @
escapeString(Client::getName(%client)) @
"\" on " @ Client::getTransportAddress(%client) @
" was " @ %word @ " from vote.");
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1))
{
if (%word == "banned")
LizStats::UpdateServerStatsTotalBans(1);
else if (%word == "kicked")
LizStats::UpdateServerStatsTotalKicks(1);
}
MessageAll(0, %name @ " was " @ %word @ " from vote.");
Net::kick(%client, "You were " @ %word @ " by  consensus.");
}
else
{
echo("LIZADMIN: " @ %admin @ " \"" @
escapeString(Client::getName(%admin)) @
"\" on " @ Client::getTransportAddress(%admin) @
" has " @ %word @ " \"" @
escapeString(Client::getName(%client)) @
"\" on " @ Client::getTransportAddress(%client));
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1))
{
if (%word == "banned")
LizStats::UpdateServerStatsTotalBans(1);
else if (%word == "kicked")
LizStats::UpdateServerStatsTotalKicks(1);
}
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
%isProhibited = Admin::LizCheckNoAdminIPList($curVoteOption);
if (%isProhibited == 1)
{
messageAll(0, Client::getName($curVoteOption) @ " can not become an administrator.");
}
else
{
$curVoteOption.isAdmin = true;
messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.");
Game::refreshClientScore($curVoteOption);
}
if($curVoteOption.menuMode == "options")
Game::menuRequest($curVoteOption);
}
$curVoteOption.voteTarget = false;
}
else if(($curVoteAction == "cmission") || ($curVoteAction == "vcmission"))
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
if ((%clientId.VoteIncrementalDelay != "") && (%clientId.VoteIncrementalDelay != 0))
%diff = %diff + %clientId.VoteIncrementalDelay;
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
if ((%clientId.VoteIncrementalDelay == 0) || (%clientId.VoteIncrementalDelay == ""))
%clientId.VoteIncrementalDelay = 0.1;
else
%clientId.VoteIncrementalDelay = %clientId.VoteIncrementalDelay + $MapVoteIncrementalDelay;
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
Client::buildMenu(%clientId, "Options", "options", true);
if(!$matchStarted || !$Server::TourneyMode)
{
Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
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
}
if(%clientId.muted[%sel])
Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
else
Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
if(%clientId.observerMode == "observerOrbit")
Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
}
if($curVoteTopic != "" && %clientId.vote == "")
{
Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
}
else if($curVoteTopic == "" && !%clientId.isAdmin)
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
Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
}
}
function remoteSelectClient(%clientId, %selId)
{
%selId = floor(%selId); // PORT
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
remoteEval(%clientId, "setInfoLine", 6, ""); // PORT: info field 5 is not shown
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
function processMenuOptions(%clientId, %option)
{
%opt = getWord(%option, 0);
%cl = getWord(%option, 1);
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
{
%clientId.muted[%cl] = true;
%clientId.mutedName[%cl] = Client::getName(%cl);
}
else if(%opt == "unmute")
{
%clientId.muted[%cl] = "";
%clientId.mutedName[%cl] = "";
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
Game::menuRequest(%clientId);
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
%isProhibited = Admin::LizCheckNoAdminIPList(%cl);
if (%isProhibited == 1)
{
Client::sendMessage(%clientId, 0, "You can not make " @ Client::getName(%cl) @ " into an admin.");
}
else
{
%cl.isAdmin = true;
messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
Game::refreshClientScore(%cl);
}
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
$arenaadmin_cs_version = "$Revision: 2 $ on $Date: 7/12/02 3:35p $";
echo("VERSION: ArenaAdmin.cs v" @ $Arena::Version @ ", internal version " @ $arenaadmin_cs_version);

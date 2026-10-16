$curVoteTopic = "";
 $curVoteAction = "";
 $curVoteOption = "";
 $curVoteCount = 0;
 function Admin::changeMissionMenu(%clientId) {
 Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
 %index = 1;
 for(%type = 1;
 %type < $MLIST::TypeCount;
 %type++) if($MLIST::Type[%type] != "Training") {
 Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
 %index++;
 }
 }
 function processMenuCMType(%clientId, %options) {
 %curItem = 0;
 %option = getWord(%options, 0);
 %first = getWord(%options, 1);
 Client::buildMenu(%clientId, "Pick Mission", "cmission", true);
 for(%i = 0;
 (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1;
 %i++) {
 if(%i > 6) {
 Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option);
 break;
 }
 Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option);
 }
 }
 function processMenuCMission(%clientId, %option) {
 if(getWord(%option, 0) == "more") {
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
 for(%i = 0;
 true;
 %i++) {
 %misIndex = getWord($MLIST::MissionList[%mt], %i);
 if(%misIndex == %mi) break;
 if(%misIndex == -1) return;
 }
 if(($Insomniax::PAMission && %clientId.isAdmin) || (%clientId.isSuperAdmin)) {
 messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
 Vote::changeMission();
 Server::loadMission(%misName);
 }
 else {
 if(FEPort::on($Insomniax::PVMission)) Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
 Game::menuRequest(%clientId);
 }
 }
 function remoteAdminPassword(%client, %password) {
 if($AdminPassword != "" && %password == $AdminPassword) {
 %client.isAdmin = true;
 %client.isSuperAdmin = true;
 }
 else {
 if(%user = getWord($ixUserInfo[%client], 0)) {
 %username = getWord($ixUserInfo[%client], 1);
 %flags = getWord($ixUserInfo[%client], 3);
 %currentName = Client::getName(%client);
 ixProcess(%client,%currentName,%user,%username,%flags,%password);
 }
 }
 }
 function remoteSetPassword(%client, %password) {
 if(%client.isSuperAdmin) $Server::Password = %password;
 }
 function remoteSetTimeLimit(%client, %time) {
 %time = floor(%time);
 if(%time == $Server::timeLimit || (%time != 0 && %time < 1)) return;
 if((%client.isAdmin && $Insomniax::PATimeLimit) || (%client.isSuperAdmin)) {
 $Server::timeLimit = %time;
 if(%time) messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s).");
 else messageAll(0, Client::getName(%client) @ " disabled the time limit.");
 }
 }
 function remoteSetTeamInfo(%client, %team, %teamName, %skinBase) {
 if(%team >= 0 && %team < 8 && ((%client.isAdmin) || (%client.isSuperAdmin))) if($Insomniax::PATeamInfo) {
 $Server::teamName[%team] = %teamName;
 $Server::teamSkin[%team] = %skinBase;
 messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission.");
 }
 else {
 Client::sendMessage(%client, 1, "Access to ADSetTeamInfo DENIED");
 }
 }
 function remoteVoteYes(%clientId) {
 %clientId.vote = "yes";
 centerprint(%clientId, "", 0);
 }
 function remoteVoteNo(%clientId) {
 %clientId.vote = "no";
 centerprint(%clientId, "", 0);
 }
 function Admin::startMatch(%admin) {
 if(%admin == -1 || %admin.isAdmin) {
 if(!$CountdownStarted && !$matchStarted) {
 if(%admin == -1) messageAll(0, "Match start countdown forced by vote.");
 else messageAll(0, "Match start countdown forced by " @ Client::getName(%admin));
 Game::ForceTourneyMatchStart();
 }
 }
 }

function Admin::phoenixSpawned(%pl, %clientId, %armor)
{	
    %clientId.spawn= 1;
	%max = getNumItems();
   for(%i = 0; (%item = $spawnPhoenixList[%i]) != ""; %i++)
   {
		buyItem(%clientId,%item);	
		if(%item.className == Weapon) 
			%clientId.spawnWeapon = %item;
	}
	%clientId.spawn= "";
	if(%clientId.spawnWeapon != "") {
		Player::useItem(%pl,%clientId.spawnWeapon);	
   	%clientId.spawnWeapon="";
	}
} 


 function Admin::setTeamDamageEnable(%admin, %enabled) {
 if(%admin == -1 || %admin.isAdmin) {
 if(%enabled) {
 $Server::TeamDamageScale = 1;
 if(%admin == -1) messageAll(0, "Team damage set to ENABLED by consensus.");
 else messageAll(0, Client::getName(%admin) @ " ENABLED team damage.");
 }
 else {
 $Server::TeamDamageScale = 0;
 if(%admin == -1) messageAll(0, "Team damage set to DISABLED by consensus.");
 else messageAll(0, Client::getName(%admin) @ " DISABLED team damage.");
 }
 }
 }
 function Admin::kick(%admin, %client, %ban) {
 if(%admin != %client && (%admin == -1 || %admin.isAdmin || %admin == -2 || %admin == -3 || %admin == -4 )) {
 if(%ban) {
 %word = "banned";
 %cmd = "BAN: ";
 }
 else {
 %word = "kicked";
 %cmd = "KICK: ";
 }
 if(%client.isSuperAdmin) {
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
 if(%admin == -1) {
 MessageAll(0, %name @ " was " @ %word @ " from vote.");
 Net::kick(%client, "You were " @ %word @ " by  consensus.");
 }
 else if(%admin == -2) {
 MessageAll(0, %name @ " was Auto-" @ %word @ " for Team Killing.");
 Net::kick(%client, "You were Auto-" @ %word @ " for Team Killing.");
 }
 else if(%admin == -3) {
 MessageAll(0, %name @ " was " @ %word @ " by a TK-Victim.");
 Net::kick(%client, "You were " @ %word @ " by a TK-Victim.");
 }
 else if(%admin == -4) {
 MessageAll(0, %name @ " was " @ %word @ " for Trying to Shoot Teammates out of Inventory Stations.");
 Net::kick(%client, "You were " @ %word @ " for Trying to Shoot Teammates out of Inventory Stations.");
 }
 else {
 MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
 Net::kick(%client, "You were " @ %word @ " by " @ Client::getName(%admin));
 }
 }
 }
 function Admin::setModeFFA(%clientId) {
 if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin)) {
 $Server::TeamDamageScale = 0;
 if(%clientId == -1) messageAll(0, "Server switched to Free-For-All Mode.");
 else messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".");
 $Server::TourneyMode = false;
 centerprintall();
 if(!$matchStarted && !$countdownStarted) {
 if($Server::warmupTime) Server::Countdown($Server::warmupTime);
 else Game::startMatch();
 }
 }
 }
 function Admin::setModeTourney(%clientId) {
 if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin)) {
 $Server::TeamDamageScale = 1;
 if(%clientId == -1) messageAll(0, "Server switched to Tournament Mode.");
 else messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".");
 $Server::TourneyMode = true;
 Server::nextMission();
 }
 }
 function Admin::voteFailed() {
 $curVoteInitiator.numVotesFailed++;
 if($curVoteAction == "kick" || $curVoteAction == "admin" || $curVoteAction == "tkkick") $curVoteOption.voteTarget = "";
 }
 function Admin::voteSucceded() {
 $curVoteInitiator.numVotesFailed = "";
 if($curVoteAction == "kick") {
 if($curVoteOption.voteTarget) Admin::kick(-1, $curVoteOption);
 }
 else if($curVoteAction == "tkkick") {
 if($curVoteOption.voteTarget) Admin::kick(-2, $curVoteOption);
 }
 else if($curVoteAction == "admin") {
 if($curVoteOption.voteTarget) {
 $curVoteOption.isAdmin = true;
 messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.");
 if($curVoteOption.menuMode == "options") Game::menuRequest($curVoteOption);
 }
 $curVoteOption.voteTarget = false;
 }
 else if($curVoteAction == "cmission") {
 messageAll(0, "Changing to mission " @ $curVoteOption @ ".");
 Vote::changeMission();
 Server::loadMission($curVoteOption);
 }
 else if($curVoteAction == "tourney") Admin::setModeTourney(-1);
 else if($curVoteAction == "ffa") Admin::setModeFFA(-1);
 else if($curVoteAction == "etd") Admin::setTeamDamageEnable(-1, true);
 else if($curVoteAction == "dtd") Admin::setTeamDamageEnable(-1, false);
 else if($curVoteOption == "smatch") Admin::startMatch(-1);
 else if($curVoteAction == "dfteams") {
 messageAll(0,"IX-Server: Fair Teams Checking is DISABLED.");
 $Insomniax::fairteams = "false";
 }
 else if($curVoteAction == "efteams") {
 messageAll(0,"IX-Server: Fair Teams Checking is ENABLED.");
 $Insomniax::fairteams = "true";
 }
 }
 function Admin::countVotes(%curVote) {
 if(%curVote != $curVoteCount) return;
 %votesFor = 0;
 %votesAgainst = 0;
 %votesAbstain = 0;
 %totalClients = 0;
 %totalVotes = 0;
 for(%cl = Client::getFirst();
 %cl != -1;
 %cl = Client::getNext(%cl)) {
 %totalClients++;
 if(%cl.vote == "yes") {
 %votesFor++;
 %totalVotes++;
 }
 else if(%cl.vote == "no") {
 %votesAgainst++;
 %totalVotes++;
 }
 else %votesAbstain++;
 }
 %minVotes = floor($Server::MinVotesPct * %totalClients);
 if(%minVotes < $Server::MinVotes) %minVotes = $Server::MinVotes;
 if(%totalVotes < %minVotes) {
 %votesAgainst += %minVotes - %totalVotes;
 %totalVotes = %minVotes;
 }
 %margin = $Server::VoteWinMargin;
 if($curVoteAction == "admin") {
 %margin = $Server::VoteAdminWinMargin;
 %totalVotes = %votesFor + %votesAgainst + %votesAbstain;
 if(%totalVotes < %minVotes) %totalVotes = %minVotes;
 }
 if(%votesFor / %totalVotes >= %margin) {
 messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
 Admin::voteSucceded();
 }
 else {
 if($curVoteAction == "kick" || $curVoteAction == "tkkick") {
 %votesFor = 0;
 %totalVotes = 0;
 for(%cl = Client::getFirst();
 %cl != -1;
 %cl = Client::getNext(%cl)) {
 if(GameBase::getTeam(%cl) == $curVoteOption.kickTeam) {
 %totalVotes++;
 if(%cl.vote == "yes") %votesFor++;
 }
 }
 if(%totalVotes >= $Server::MinVotes && %votesFor / %totalVotes >= $Server::VoteWinMargin) {
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
 function Admin::startVote(%clientId, %topic, %action, %option) {
 if(%clientId.lastVoteTime == "") %clientId.lastVoteTime = -$Server::MinVoteTime;
 %time = getIntegerTime(true) >> 5;
 %diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time;
 if(%diff > 0) {
 Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
 return;
 }
 if($curVoteTopic == "") {
 if(%clientId.numFailedVotes) %time += %clientId.numFailedVotes * $Server::VoteFailTime;
 %clientId.lastVoteTime = %time;
 $curVoteInitiator = %clientId;
 $curVoteTopic = %topic;
 $curVoteAction = %action;
 $curVoteOption = %option;
 $curVoteCount++;
 if(%action == "kick") $curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
 if(%action == "tkkick") {
 %IXtker = getWord(%topic, 3);
 %IXtkKills = $tkKills[%option];
 bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic @ "\n <f2>" @ %IXtker @ " <f0> has a Confirmed <f2>" @ %IXtkKills @ " TEAM KILLS", 10);
 $curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
 }
 else bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
 for(%cl = Client::getFirst();
 %cl != -1;
 %cl = Client::getNext(%cl)) %cl.vote = "";
 %clientId.vote = "yes";
 for(%cl = Client::getFirst();
 %cl != -1;
 %cl = Client::getNext(%cl)) if(%cl.menuMode == "options") Game::menuRequest(%clientId);
 schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", $Server::VotingTime, 35);
 }
 else {
 Client::sendMessage(%clientId, 0, "Voting already in progress.");
 }
 }
 function Game::menuRequest(%clientId) {
 if ((%clientId.isbeingkicked || %clientId.freeze) && !%clientId.isAdmin) 
 {
 topprint(%clientId, "<jc><f2>\n\n\n\nYour being punished that option is not available.", 2);
 return;
 }
 %curItem = 0;
 Client::buildMenu(%clientId, "Options", "options", true);
 if(!$matchStarted || !$Server::TourneyMode) {
 Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
 }
 if(%clientId.selClient) {
 %sel = %clientId.selClient;
 %name = Client::getName(%sel);
 if($curVoteTopic == "" && !%clientId.isSuperAdmin) {
 if($Insomniax::PAVote && !%sel.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
 if($insomniax::PAKick && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
 else if($insomniax::PVKick) Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
 if($insomniax::PABan && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
//*** changed to get it to work
 if($insomniax::PAGag && %clientId.isAdmin) if(%sel.gag) Client::addMenuItem(%clientId, %curItem++ @ "Ungag " @ %name, "ungag " @ %sel);
 else Client::addMenuItem(%clientId, %curItem++ @ "Gag " @ %name, "gag " @ %sel);
//***
 if($insomniax::PATeamChange && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
 if(%clientId.observerMode == "observerOrbit") Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
 }
 else if(%clientId.isSuperAdmin) {
 if(!%sel.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
 Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
 Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
//*** deleted these gag lines since they are in the discipline menu
// if(%sel.gagged) Client::addMenuItem(%clientId, %curItem++ @ "Ungag " @ %name, "ungag " @ %sel);
// else Client::addMenuItem(%clientId, %curItem++ @ "Gag " @ %name, "gag " @ %sel);
 Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
 Client::addMenuItem(%clientId, %curItem++ @ "Discipline "@ %name @ "...", "discipline " @ %sel);
 }
 if(%clientId.muted[%sel]) Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
 else Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
 if(%clientId.observerMode == "observerOrbit") Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
 }
 else if($curVoteTopic != "" && %clientId.vote == "") {
 Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
 Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
 }
 else if($curVoteTopic == "" && !%clientId.isSuperAdmin) {
 if(%clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Public Admin Options", "publicAdminOptions");
 if($insomniax::PAModOptions && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "IX-Admin Settings", "insomniax");
 if(!%clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Voting Options", "publicVoteOptions");
 if($insomniax::PSkin) if(%clientId.custom) Client::addMenuItem(%clientId, %curItem++ @ "Use Server Skins.", "pskin off");
 else Client::addMenuItem(%clientId, %curItem++ @ "Use Personal Skins.", "pskin on");
 if(!%clientId.isAdmin) {
 %IXKiller = Insomniax_getKiller(%clientId);
 if((%IXKiller != %clientId) && ($tkKills[%IXKiller] >= $Insomniax::tkLimit)) {
 if($Insomniax::tkClientLvl == 1) Client::addMenuItem(%clientId, %curItem++ @ "Kick Team Killer " @ Client::getName(Insomniax_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller)));
 else Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick " @ Client::getName(Insomniax_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller)));
 }
 }
 }
 else if(%clientId.isSuperAdmin) {
 Client::addMenuItem(%clientId, %curItem++ @ "Super Admin Options", "superAdminOptions");
 Client::addMenuItem(%clientId, %curItem++ @ "Admin Settings", "insomniax");
 if($insomniax::PSkin) if(%clientId.custom) Client::addMenuItem(%clientId, %curItem++ @ "Use Server Skins.", "pskin off");
 else Client::addMenuItem(%clientId, %curItem++ @ "Use Personal Skins.", "pskin on");
 }
 if(Player::getMountedItem(Client::getOwnedObject(%clientId),$BackpackSlot) == "Vengeance") Client::addMenuItem(%clientId, %curItem++ @ "Vengeance Options", "vengeance");
 if((%itmCount = Group::objectCount(%clientId.deployables)) > 0) Client::addMenuItem(%clientId, %curItem++ @ "Deployables", "deployables " @ %itmCount);
 }
 function remoteSelectClient(%clientId, %selId) {
 if(%clientId.selClient != %selId) {
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
 function processMenuFPickTeam(%clientId, %team) {
 if(FEPort::PA(%clientId, $Insomniax::PATeamChange) && %clientId.ptc != "") processMenuPickTeam(%clientId.ptc, %team, %clientId);
 %clientId.ptc = "";
 }
 function processMenuPickTeam(%clientId, %team, %adminClient) {
 checkPlayerCash(%clientId);
 %teamnow = Client::getTeam(%clientId);
 if(%team != -1 && %team == %teamnow) return;
 if(%clientId.observerMode == "justJoined") {
 %clientId.observerMode = "";
 centerprint(%clientId, "");
 }
 if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2) {
 if(Observer::enterObserverMode(%clientId)) {
 %clientId.notready = "";
 if(%adminClient == "") messageAll(0, Client::getName(%clientId) @ " became an observer.");
 else messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
 Game::resetScores(%clientId);
 Game::refreshClientScore(%clientId);
 }
 return;
 }
 %change = false;
 if(!$Insomniax::fairTeams) {
 if(%team == -1) {
 Game::assignClientTeam(%clientId);
 %team = Client::getTeam(%clientId);
 }
 if(%adminClient == "") messageAll(0, Client::getName(%clientId) @ " changed teams.");
 else messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
 %change = true;
 deleteObject(%clientId.deployables);
 %clientId.deployables = newObject("set",SimSet);
 }
 else {
 if(%team == -1) {
 Game::assignClientTeam(%clientId);
 %team = Client::getTeam(%clientId);
 if(%adminClient == "") messageAll(0, Client::getName(%clientId) @ " changed teams to make it fair.");
 else messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ " to even the Teams.");
 %change = true;
 }
 else {
 if(Insomniax_isFairTeam(%teamnow, %team)) {
 if(%adminClient == "") messageAll(0, Client::getName(%clientId) @ " changed teams to make it fair.");
 else messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ " to even the Teams.");
 %change = true;
 }
 else {
 if(%adminClient == "") {
 messageAll(0, Client::getName(%clientId) @ " tried to make the teams even more unfair.");
 %change = false;
 }
 else {
 messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
 %change = true;
 }
 }
 }
 }
 if(%change) {
 %player = Client::getOwnedObject(%clientId);
 if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
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
 if($Server::TourneyMode && !$CountdownStarted) {
 bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
 %clientId.notready = true;
 }
 }
 }
 function processMenuOptions(%clientId, %option) {
 %opt = getWord(%option, 0);
 %cl = getWord(%option, 1);
 if(!FEPort::optAllowed(%clientId, %opt, %cl)) return; // PORT: menu codes come from the client
 if(%opt == "fteamchange") {
 %clientId.ptc = %cl;
 Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
 Client::addMenuItem(%clientId, "0Observer", -2);
 Client::addMenuItem(%clientId, "1Automatic", -1);
 for(%i = 0;
 %i < getNumTeams();
 %i = %i + 1) Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
 return;
 }
 else if(%opt == "changeteams") {
 if(!$matchStarted || !$Server::TourneyMode) {
 Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
 Client::addMenuItem(%clientId, "0Observer", -2);
 Client::addMenuItem(%clientId, "1Automatic", -1);
 for(%i = 0;
 %i < getNumTeams();
 %i = %i + 1) Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
 return;
 }
 }
 else if(%opt == "mute") %clientId.muted[%cl] = true;
 else if(%opt == "unmute") %clientId.muted[%cl] = "";
 else if(%opt == "vkick") {
 %cl.voteTarget = true;
 Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
 }
 else if(%opt == "vadmin") {
 %cl.voteTarget = true;
 Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
 }
 else if(%opt == "vsmatch") Admin::startVote(%clientId, "start the match", "smatch", 0);
 else if(%opt == "vetd") Admin::startVote(%clientId, "enable team damage", "etd", 0);
 else if(%opt == "vdtd") Admin::startVote(%clientId, "disable team damage", "dtd", 0);
 else if(%opt == "etd") Admin::setTeamDamageEnable(%clientId, true);
 else if(%opt == "dtd") Admin::setTeamDamageEnable(%clientId, false);
 else if(%opt == "vcffa") Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
 else if(%opt == "vctourney") Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
 else if(%opt == "cffa") Admin::setModeFFA(%clientId);
 else if(%opt == "ctourney") Admin::setModeTourney(%clientId);
 else if(%opt == "voteYes" && %cl == $curVoteCount) {
 %clientId.vote = "yes";
 centerprint(%clientId, "", 0);
 }
 else if(%opt == "voteNo" && %cl == $curVoteCount) {
 %clientId.vote = "no";
 centerprint(%clientId, "", 0);
 }
 else if(%opt == "kick") {
 Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
 Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
 Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
 return;
 }
 else if(%opt == "admin") {
 Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
 Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
 Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
 return;
 }
 else if(%opt == "ban") {
 Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
 Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
 Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
 return;
 }
 else if(%opt == "discipline")
 {
 Client::buildMenu(%clientId, "Discipline Options:", "disaction", true);
 Client::addMenuItem(%clientId, "1Execute " @ Client::getName(%cl), "execute " @ %cl);
 Client::addMenuItem(%clientId, "2Impulse " @ Client::getName(%cl), "impdeath " @ %cl);
 if(%cl.freeze) 
 Client::addMenuItem(%clientId, "3Defrost " @ Client::getName(%cl), "unfreeze " @ %cl);
 else 
 Client::addMenuItem(%clientId, "3Freeze " @ Client::getName(%cl), "freeze " @ %cl);
 if(%cl.gag)
 Client::addMenuItem(%clientId, "4Ungag " @ Client::getName(%cl), "ungag " @ %cl);
 else
 Client::addMenuItem(%clientId, "4Gag " @ Client::getName(%cl), "gag " @ %cl);
 if(%cl.strip)
 Client::addMenuItem(%clientId, "5Unstrip " @ Client::getName(%cl), "unstrip " @ %cl);
 else
 Client::addMenuItem(%clientId, "5Strip " @ Client::getName(%cl), "strip " @ %cl);
 return;
 }
//*** added for Public Admin gag
 else if(%opt == "gag")
 {
 %cl.gag = true;
 ixAdminMsg(Client::getName(%clientId) @ " has Gagged " @ Client::getName(%cl));	
 Client::sendMessage(%cl,0,"IX-Server: You have been Gagged by the Server Admin.");
 }
 else if(%opt == "ungag")
 {
 %cl.gag = false;
 ixAdminMsg(Client::getName(%clientId) @ " has Ungagged " @ Client::getName(%cl));	
 Client::sendMessage(%cl,0,"IX-Server: Your Gag has been removed by the Admin.");
 }
//***
 else if(%opt == "smatch") Admin::startMatch(%clientId);
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
 else if(%opt == "reset") {
 Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
 Client::addMenuItem(%clientId, "1Reset", "yes");
 Client::addMenuItem(%clientId, "2Don't Reset", "no");
 return;
 }
   else if(%opt == "phoenix")
   {
	  Admin::phoenixSpawned(%pl, %clientId, %armor, %opt == "phoenix");
	  return;
   }
 else if(%opt == "observe") {
 Observer::setTargetClient(%clientId, %cl);
 return;
 }
 else if(%opt == "disableFT") {
 ixAdminMsg("Command: " @ Client::getName(%clientId) @ " - Fair Teams Checking is DISABLED.");
 $Insomniax::fairteams = "false";
 }
 else if(%opt == "enableFT") {
 ixAdminMsg("Command: " @ Client::getName(%clientId) @ " - Fair Teams Checking is ENABLED.");
 $Insomniax::fairteams = "true";
 }
 else if(%opt == "vdisableFT") {
 %cl.voteTarget = true;
 Admin::startVote(%clientId, "Disable Fair Teams", "dfteams", %cl);
 }
 else if(%opt == "venableFT") {
 %cl.voteTarget = true;
 Admin::startVote(%clientId, "Enable Fair Teams", "efteams", %cl);
 }
 else if(%opt == "insomniax") {
 %now = 0;
 Client::buildMenu(%clientId, "IX-Admin Settings:", "ixsettings", true);
 Client::addMenuItem(%clientId, %now++ @ "Server: Anti-TK Lvl", "tkserv " @ $Insomniax::tkServerLvl);
 Client::addMenuItem(%clientId, %now++ @ "Client: Anti-TK Lvl", "tkclient " @ $Insomniax::tkClientLvl);
 Client::addMenuItem(%clientId, %now++ @ "Out of Bounds Kill", "areakill " @ $Insomniax::LeaveAreaTime);
 if($Insomniax::PSkin) Client::addMenuItem(%clientId, %now++ @ "Disable Personal Skins", "disablepskin " @ %clientId);
 else Client::addMenuItem(%clientId, %now++ @ "Enable Personal Skin", "enablepskin " @ %clientId);
 if($Insomniax::SafeStation) Client::addMenuItem(%clientId, %now++ @ "Disable Safe Stations", "dsafestation " @ %clientId);
 else Client::addMenuItem(%clientId, %now++ @ "Enable Safe Stations", "esafestation " @ %clientId);
 if(%clientId.isSuperAdmin) Client::addMenuItem(%clientId, %now++ @ "Set Inv. Station Time", "stationtime " @ $Insomniax::StationTime);
 if(%clientId.isSuperAdmin) Client::addMenuItem(%clientId, %now++ @ "Admin Controls.", "admincontrols");
 return;
 }
 else if(%opt == "pskin") {
 if(%cl == "on") {
 %clientId.custom = true;
 bottomprint(%clientId,"<jc><f2>Custom Skins Enabled.\n<f1>Changes Take Place on Next Respawn", 5);
 }
 else {
 %clientId.custom = false;
 bottomprint(%clientId,"<jc><f2>Custom Skins Disabled.\n<f1>Changes Take Place on Next Respawn", 5);
 }
 }
 else if(%opt == "tkopt") {
 if($Insomniax::tkClientLvl == 1) {
 Admin::Kick(-3, Insomniax_getKiller(%clientId));
 return;
 }
 else {
 %cl.voteTarget = true;
 %clientId.selClient = Insomniax_getKiller(%clientId);
 Admin::startVote(%clientId, "Kick Team Killer " @ Client::getName(%cl), "tkkick", %cl);
 return;
 }
 }
 else if(%opt == "vengeance") {
 if(Player::getMountedItem(Client::getOwnedObject(%clientId),$BackpackSlot) == "Vengeance") {
 %now = 0;
 Client::buildMenu(%clientId, "Vengeance Options:", "Vengeance", true);
 Client::addMenuItem(%clientId, %now++ @ "Set Vengeance Payload.", "payload");
 Client::addMenuItem(%clientId, %now++ @ "Set Vengeance Scan.", "scan");
 Client::addMenuItem(%clientId, %now++ @ "Set Vengeance Warhead.", "warhead");
 Client::addMenuItem(%clientId, %now++ @ "Choose Vengeance Pre-Set.", "preset");
 return;
 }
 }
 else if(%opt == "publicVoteOptions") {
 %curItem = 0;
 Client::buildMenu(%clientId, "Voting Options:", "Options", true);
 if($insomniax::PVMission) Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
 if($insomniax::PVTeamDamage) {
 if($Server::TeamDamageScale == 1.0) Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
 else Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
 }
 if($insomniax::PVFairTeams) {
 if($insomniax::FairTeams) Client::addMenuItem(%clientId, %curItem++ @ "Vote to Disable Fair Teams", "vdisableFT " @ %clientId);
 else Client::addMenuItem(%clientId, %curItem++ @ "Vote to Enable Fair Teams", "venableFT " @ %clientId);
 }
 if($insomniax::PVTourneyMode) if($Server::TourneyMode) {
 Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
 if(!$CountdownStarted && !$matchStarted) Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
 }
 else Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
 return;
 }
 else if(%opt == "publicAdminOptions") {
 %curItem = 0;
 Client::buildMenu(%clientId, "Public Admin Options:", "Options", true);
 if($insomniax::PAMission && %clientId.isAdmin) {
 Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
 }
 else {
 if($insomniax::PVMission) Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
 }
 if($insomniax::PATeamDamage && %clientId.isAdmin) {
 if($Server::TeamDamageScale == 1.0) Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
 else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
 }
 else {
 if($insomniax::PVTeamDamage) {
 if($Server::TeamDamageScale == 1.0) Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
 else Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
 }
 }
 if($insomniax::PAFairTeams && %clientId.isAdmin) {
 if($Insomniax::FairTeams) Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "disableFT " @ %clientId);
 else Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "enableFT " @ %clientId);
 }
 else {
 if($insomniax::PVFairTeams) {
 if($insomniax::FairTeams) Client::addMenuItem(%clientId, %curItem++ @ "Vote to Disable Fair Teams", "vdisableFT " @ %clientId);
 else Client::addMenuItem(%clientId, %curItem++ @ "Vote to Enable Fair Teams", "venableFT " @ %clientId);
 }
 }
 if($insomniax::PATourneyMode && %clientId.isAdmin) {
 if($Server::TourneyMode) {
 Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
 if(!$CountdownStarted && !$matchStarted) Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
 }
 else Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
 }
 else {
 if($insomniax::PVTourneyMode) if($Server::TourneyMode) {
 Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
 if(!$CountdownStarted && !$matchStarted) Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
 }
 else Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
 }
 if($insomniax::PATimeLimit && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
 if($insomniax::PAResetDefaults && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
 return;
 }
 else if(%opt == "superAdminOptions") {
 %curItem = 0;
 Client::buildMenu(%clientId, "Super Admin Options:", "Options", true);
 Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
 if($Server::TeamDamageScale == 1.0) Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
 else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
 if($Insomniax::FairTeams) Client::addMenuItem(%clientId, %curItem++ @ "Disable Fair Teams", "disableFT " @ %clientId);
 else Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "enableFT " @ %clientId);
 if($Server::TourneyMode) {
 Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
 if(!$CountdownStarted && !$matchStarted) Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
 }
 else Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
 Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
 Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
 Client::addMenuItem(%clientId, %curItem++ @ "Angel Of Death", "phoenix");
 return;
 }
 else if(%opt == "deployables") {
 %cl = Group::objectCount(%clientId.deployables);
 %items = "";
 for(%j=0; %j<%cl; %j++) {
 %turret = Group::getObject(%clientId.deployables,%j);
 if(!%turret.packing) %items = %items @ %turret @ " ";
 }
 Client::buildMenu(%clientId, "Remote Pack-up/Destroy:", "Deployables", true);
 for(%i=0; (%i<7) && (%i<%cl); %i++) Client::addMenuItem(%clientId, (%i+1) @ GameBase::getMapName(getWord(%items,%i)), "packup " @ %cl @ " " @ %i);
 if(%cl > 7) {
 Client::addMenuItem(%clientId, (%i+1) @ "More Deployables..", "more " @ %cl @ " " @ %i);
 }
 return;
 }
 Game::menuRequest(%clientId);
 }
 function processMenuDeployables(%clientid, %option) {
 %opt = getWord(%option, 0);
 %cl = getWord(%option, 1);
 %i = getWord(%option, 2);
 %cl = Group::objectCount(%clientId.deployables);
 if(%opt == "more") {
 %items = "";
 for(%j=0;
%j<%cl;
%j++) {
 %turret = Group::getObject(%clientId.deployables,%j);
 if(!%turret.packing) %items = %items @ %turret @ " ";
 }
 Client::buildMenu(%clientId, "Remote Pack-up/Destroy:", "Deployables", true);
 for(%k=0;
(%k<7) && (%i<%cl);
%i++) Client::addMenuItem(%clientId, %k++ @ GameBase::getMapName(getWord(%items,%i)), "packup " @ %cl @ " " @ %i);
 if((%cl-%i)>0) {
 Client::addMenuItem(%clientId, %k++ @ "More Deployables..", "more " @ %cl @ " " @ %i);
 }
 return;
 }
 else if(%opt == "packup") {
 %turret = Group::getObject(%clientId.deployables,%i);
 if(%turret == -1 || %turret.packing) return; // PORT: the index comes from the client
 %dataName = GameBase::getDataName(%turret);
 if(%dataName == DeployableTurret) %pack = "TurretPack";
 else if(%dataName == DeployableFlame) %pack = "FlameTurretPack";
 else if(%dataName == DeployableVulcan) %pack = "VulcanTurret";
 else if(%dataName == DeployableRocket) %pack = "RocketPack";
 else if(%dataName == DeployableInvStation) %pack = "DeployableInvPack";
 else if(%dataName == DeployableAmmoStation) %pack = "DeployableAmmoPack";
 else if(%dataName == DeployableComStation) %pack = "DeployableComPack";
 else if(%dataName == DeployableRail) %pack = "RailTurret";
 else if(%dataName == DeployableForceField) %pack = "ForceFieldPack";
 else if(%dataName == LargeForceField) %pack = "LargeForceFieldPack";
 else if(%dataName == DeployableForceFieldDoor) %pack = "ForceFieldDoorPack";
 else if(%dataName == LargeForceFieldDoor) %pack = "LargeForceFieldDoorPack";
 %name = GameBase::getMapName(%turret);
 %turret.packing = true;
 %pos = getBoxCenter(%turret);
 %x = getWord(%pos,0);
 %y = getWord(%pos,1);
 %z = getWord(%pos,2);
 if(!GameBase::getDamageLevel(%turret)) {
 GameBase::setSequenceDirection(%turret,1,0);
 schedule("deleteObject(" @ %turret @ ");",1.9,%turret); 
 schedule("ixPopPack(" @ %clientId @ "," @ %pack @ "," @ %x @ "," @ %y @ "," @ %z @ ");",2.0);
 echo("MSG: ",%clientId," Remotely Packed up: " @ %dataName);
 Client::sendMessage(%clientId,0,"Packing up " @ %name);
 }
 else {
 schedule("GameBase::setDamageLevel(" @ %turret @ "," @ %dataName.maxDamage @ ");",1.0,%turret);
 Client::sendMessage(%clientId, 0,"Destroying Deployable: " @ %name);
 }
 return;
 }
 }

 function ixPopPack(%clientId, %pack, %x, %y, %z) {
 %obj = newObject("","Item",%pack,1,false);
 schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 addToSet("MissionCleanup", %obj);
 %pos = %x @ " " @ %y @ " " @ %z;
 GameBase::setPosition(%obj,%pos);
 $TeamItemCount[Client::getTeam(%clientId) @ %pack]--;
 playSound(SoundPickupItem,%pos);
 }
 function processMenuKAffirm(%clientId, %opt) {
 if(getWord(%opt, 0) == "yes" && FEPort::PA(%clientId, $Insomniax::PAKick)) Admin::kick(%clientId, getWord(%opt, 1));
 Game::menuRequest(%clientId);
 }
 function processMenuBAffirm(%clientId, %opt) {
 if(getWord(%opt, 0) == "yes" && FEPort::PA(%clientId, $Insomniax::PABan)) Admin::kick(%clientId, getWord(%opt, 1), true);
 Game::menuRequest(%clientId);
 }
 function processMenuAAffirm(%clientId, %opt) {
 if(getWord(%opt, 0) == "yes") {
 if(%clientId.isSuperAdmin) {
 %cl = getWord(%opt, 1);
 %cl.isAdmin = true;
 messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
 }
 }
 Game::menuRequest(%clientId);
 }
 function processMenuRAffirm(%clientId, %opt) {
 if(%opt == "yes" && FEPort::PA(%clientId, $Insomniax::PAResetDefaults)) {
 messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
 Server::refreshData();
 }
 Game::menuRequest(%clientId);
 }
 function processMenuCTLimit(%clientId, %opt) {
 remoteSetTimeLimit(%clientId, %opt);
 }
 function processMenuDisAction(%clientId, %option)
 {
 if(!%clientId.isSuperAdmin) return; // PORT: menu codes come from the client
 %opt = getWord(%option, 0);
 %cl = getWord(%option, 1);
 if(%opt == "execute") 
 {
 Client::buildMenu(%clientId, "Confirm execution:", "maffirm", true);
 Client::addMenuItem(%clientId, "1Execute " @ Client::getName(%cl), "yes " @ %cl);
 Client::addMenuItem(%clientId, "2Don't Execute " @ Client::getName(%cl), "no " @ %cl);
 return;
 }
 else if(%opt == "impdeath") 
 {
 Client::buildMenu(%clientId, "Confirm impulse death:", "impaffirm", true);
 Client::addMenuItem(%clientId, "1Impulse " @ Client::getName(%cl), "yes " @ %cl);
 Client::addMenuItem(%clientId, "2Don't Impulse " @ Client::getName(%cl), "no " @ %cl);
 return;
 }

 else if(%opt == "gag")
 {
 %cl.gag = true;
 ixAdminMsg(Client::getName(%clientId) @ " has Gagged " @ Client::getName(%cl));	
 Client::sendMessage(%cl,0,"IX-Server: You have been Gagged by the Server Admin.");
 }
 else if(%opt == "ungag")
 {
 %cl.gag = false;
 ixAdminMsg(Client::getName(%clientId) @ " has Ungagged " @ Client::getName(%cl));	
 Client::sendMessage(%cl,0,"IX-Server: Your Gag has been removed by the Admin.");
 }
 else if(%opt == "freeze") 
 {
 %cl.freeze = true;
 Client::setControlObject(%cl, -1);
 ixAdminMsg(Client::getName(%clientId) @ " has Frozen " @ Client::getName(%cl));	
 Client::sendMessage(%cl,0,"IX-Server: You have been Frozen by the Server Admin.");
 }
 else if(%opt == "unfreeze") 
 {
 ixAdminMsg(Client::getName(%clientId) @ " has Unfrozen " @ Client::getName(%cl));	
 Client::sendMessage(%cl,0,"IX-Server: You have been Defrosted by the Server Admin.");
 %cl.freeze = false;
 Client::setControlObject(%cl, Client::getOwnedObject(%cl));
 }

 else if (%opt == "strip")
 {
 %cl.strip = true;
 ixAdminMsg(Client::getName(%clientId) @ " has stripped " @ Client::getName(%cl) @ " of their armor");	
 Client::sendMessage(%cl,0,"IX-Server: For being a pest, you must repair the things you hurt.~waccess_denied.wav");
 playNextAnim(%cl);
 Player::blowUp(%cl);
 Player::kill(%cl);
 Client::onKilled(%cl,%cl);
 }
 else if(%opt == "unstrip") 
 {
 ixAdminMsg(Client::getName(%clientId) @ " has allowed " @ Client::getName(%cl) @ " to wear armor again.");	
 Client::sendMessage(%cl,0,"IX-Server: You have served your punishment. Be nice from now on.~waccess_denied.wav");
 %cl.strip = false;
 }
 }

 function processMenuMAffirm(%clientId, %opt) {
 if(getWord(%opt, 0) == "yes" && %clientId.isSuperAdmin) { // PORT: menu codes come from the client
 %cl = getWord(%opt, 1);
 MessageAll(1, Client::getName(%clientId) @ " gestures to the sky and the clouds part... A lightning bolt arcs from the sky and finds its target, "@ Client::getName(%cl) @ ".");
 MessageAllExcept(%cl , 1, Client::getName(%cl) @ " was executed by " @ Client::getName(%clientId) @ ".");
 Client::sendMessage(%cl ,1,"You were executed by " @ Client::getName(%clientId) @ ". Be nice, or next time it could be worse.");
 playNextAnim(%cl);
 Player::blowUp(%cl);
 Player::kill(%cl);
 Client::onKilled(%cl,%cl);
 }
 }

 function processMenuImpAffirm(%clientId, %opt) {
 if(getWord(%opt, 0) == "yes" && %clientId.isSuperAdmin) // PORT: menu codes come from the client
 {
 %cl = getWord(%opt, 1);
 MessageAllExcept(%cl, 1, Client::getName(%cl) @ " was launched into low Earth orbit by " @ Client::getName(%clientId) @ ".");
 Client::sendMessage(%cl ,1,"For being a complete idiot, you have been blown off the map by " @ Client::getName(%clientId) @ ".");
 playNextAnim(%cl);
 Player::applyImpulse(%cl, Vector::getFromRot(GameBase::getRotation(%cl),90,5000));
 Player::kill(%cl);
 Client::onKilled(%cl,%cl);
 }
 }
 function processMenuIXSettings(%clientId, %option) {
 %opt = getWord(%option, 0);
 %cl = getWord(%option, 1);
 if(!FEPort::ixAllowed(%clientId, %opt)) return; // PORT: menu codes come from the client
 if(%opt == "purge") %cl = %clientId; // PORT: the sender, not an id from the menu code
 if(%opt == "admincontrols") {
 Client::buildMenu(%clientId, "Admin Controls:", "ixsettings", true);
 if($Insomniax::PAVote) Client::addMenuItem(%clientId, "1Disable Admin Voting", "disablepav");
 else Client::addMenuItem(%clientId, "1Enable Admin Voting", "enablepav");
 Client::addMenuItem(%clientId, "2Admin Lockouts", "palockout");
 Client::addMenuItem(%clientId, "3Voting Lockouts", "pvlockout");
 Client::addMenuItem(%clientId, "4Purge Public Admins", "purge " @ %clientId);
 return;
 }
 else if(%opt == "disablepav") {
 ixAdminMsg("Admin Voting is DISABLED by " @ Client::getName(%clientId));
 $Insomniax::PAVote = "false";
 }
 else if(%opt == "enablepav") {
 ixAdminMsg("Admin Voting is ENABLED by " @ Client::getName(%clientId));
 $Insomniax::PAVote = "true";
 }
 else if(%opt == "tkserv") {
 Client::buildMenu(%clientId, "Current Server Anti-TK: " @ %cl, "ServerLvl", true);
 Client::addMenuItem(%clientId, "0Log TK's only", 0);
 Client::addMenuItem(%clientId, "1Auto Vote TKer", 1);
 Client::addMenuItem(%clientId, "2Auto Vote Until Kicked", 2);
 Client::addMenuItem(%clientId, "3Auto Kick TKer", 3);
 return;
 }
 else if(%opt == "tkclient") {
 Client::buildMenu(%clientId, "Current Client Anti-TK: " @ %cl, "ClientLvl", true);
 Client::addMenuItem(%clientId, "0Client Vote Option", 0);
 Client::addMenuItem(%clientId, "1Client Kick Option", 1);
 return;
 }
 else if(%opt == "areakill") {
 Client::buildMenu(%clientId, "Out of Bounds Kill Time: " @ %cl @ " Seconds", "AKill", true);
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
 else if(%opt == "palockout") {
 Client::buildMenu(%clientId, "Current Status:","PALockouts", true);
 Client::addMenuItem(%clientId, "1[" @ whattodo($Insomniax::PATeamChange) @ "]Team Changing", "teamchange " @ $Insomniax::PATeamChange);
 Client::addMenuItem(%clientId, "2[" @ whattodo($Insomniax::PAKick) @ "]Kick", "kick " @ $Insomniax::PAKick);
 Client::addMenuItem(%clientId, "3[" @ whattodo($Insomniax::PABan) @ "]Ban","ban " @ $Insomniax::PABan);
 Client::addMenuItem(%clientId, "4[" @ whattodo($Insomniax::PAMission) @ "]Change Mission", "mission " @ $Insomniax::PAMission);
 Client::addMenuItem(%clientId, "5[" @ whattodo($Insomniax::PATeamDamage) @ "]Team Damage", "teamdamage " @ $Insomniax::PATeamDamage);
 Client::addMenuItem(%clientId, "6[" @ whattodo($Insomniax::PATourneyMode) @ "]Tourney/FFA Mode", "tourney " @ $Insomniax::PATourneyMode);
 Client::addMenuItem(%clientId, "7[" @ whattodo($Insomniax::PATimeLimit) @ "]Time Limit", "timelimit " @ $Insomniax::PATimeLimit);
 Client::addMenuItem(%clientId, "8Additional Lockouts ...", "additional");
 return;
 }
 else if(%opt == "pvlockout") {
 Client::buildMenu(%clientId, "Current Status:","PVLockouts", true);
 Client::addMenuItem(%clientId, "1[" @ whattodo($Insomniax::PVKick) @ "]Kick", "kick " @ $Insomniax::PVKick);
 Client::addMenuItem(%clientId, "2[" @ whattodo($Insomniax::PVMission) @ "]Change Mission", "mission " @ $Insomniax::PVMission);
 Client::addMenuItem(%clientId, "3[" @ whattodo($Insomniax::PVFairTeams) @ "]Fair Teams", "fteams " @ $Insomniax::PVFairTeams);
 Client::addMenuItem(%clientId, "4[" @ whattodo($Insomniax::PVTeamDamage) @ "]Team Damage", "teamdamage " @ $Insomniax::PVTeamDamage);
 Client::addMenuItem(%clientId, "5[" @ whattodo($Insomniax::PVTourneyMode) @ "]Tourney/FFA Mode", "tourney " @ $Insomniax::PVTourneyMode);
 Client::addMenuItem(%clientId, "6[Unlock]ALL Options", "allon");
 Client::addMenuItem(%clientId, "7[-Lock-]ALL Options", "alloff");
 return;
 }
 else if(%opt == "purge") {
 Insomniax_clearPA(%cl);
 return;
 }
 else if(%opt == "disablepskin") ixAllSkinsOff();
 else if(%opt == "enablepskin") ixAllSkinsOn();
 else if(%opt == "stationtime") {
 Client::buildMenu(%clientId, "Inventoy Station Time: " @ %cl @ " Seconds", "StationTime", true);
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
 else if(%opt == "dsafestation") {
 ixAdminMsg("Safe Stations DISABLED by " @ Client::getName(%clientId));
 $Insomniax::SafeStation = "false";
 }
 else if(%opt == "esafestation") {
 ixAdminMsg("Safe Stations ENABLED by " @ Client::getName(%clientId));
 $Insomniax::SafeStation = "true";
 }
 processMenuOptions(%clientId, "insomniax");
 }
 function processMenuPALockouts(%clientId, %option) {
 if(!%clientId.isSuperAdmin) return; // PORT: menu codes come from the client
 %opt = getWord(%option, 0);
 %toggle = getWord(%option, 1);
 if(%opt == "additional") {
 Client::buildMenu(%clientId, "Current Status:","PALockouts", true);
 Client::addMenuItem(%clientId, "1[" @ whattodo($Insomniax::PAResetDefaults) @ "]Server Defaults ", "reset " @ $Insomniax::PAResetDefaults);
 Client::addMenuItem(%clientId, "2[" @ whattodo($Insomniax::PAModOptions) @ "]IX-Admin Options", "modopt " @ $Insomniax::PAModOptions);
 Client::addMenuItem(%clientId, "3[" @ whattodo($Insomniax::PATeamInfo) @ "]Set Team Info", "teaminfo " @ $Insomniax::PATeamInfo);
 Client::addMenuItem(%clientId, "4[" @ whattodo($Insomniax::PAFairTeams) @ "] Fair Teams", "fteams " @ $Insomniax::PAFairTeams);
 Client::addMenuItem(%clientId, "5[" @ whattodo($Insomniax::PAGag) @ "] Gag Players", "gag " @ $Insomniax::PAGag);
 Client::addMenuItem(%clientId, "6[Unlock]ALL Options", "allon");
 Client::addMenuItem(%clientId, "7[-Lock-]ALL Options", "alloff");
 return;
 }
 else if(%opt == "allon") {
 %access = "All Admin Options";
 %toggle = "false";
 $Insomniax::PATeamChange = "true";
 $Insomniax::PAKick = "true";
 $Insomniax::PABan = "true";
 $Insomniax::PAGag = "true";
 $Insomniax::PAMission = "true";
 $Insomniax::PATeamInfo = "true";
 $Insomniax::PAFairTeams = "true";
 $Insomniax::PATeamDamage = "true";
 $Insomniax::PATourneyMode = "true";
 $Insomniax::PATimeLimit = "true";
 $Insomniax::PAResetDefaults = "true";
 $Insomniax::PAModOptions = "true";
 }
 else if(%opt == "alloff") {
 %access = "All Admin Options";
 %toggle = "true";
 $Insomniax::PATeamChange = "false";
 $Insomniax::PAKick = "false";
 $Insomniax::PABan = "false";
 $Insomniax::PAGag = "false";
 $Insomniax::PAMission = "false";
 $Insomniax::PATeamInfo = "false";
 $Insomniax::PAFairTeams = "false";
 $Insomniax::PATeamDamage = "false";
 $Insomniax::PATourneyMode = "false";
 $Insomniax::PATimeLimit = "false";
 $Insomniax::PAResetDefaults = "false";
 $Insomniax::PAModOptions = "false";
 }
 else if(%opt == "teamchange") {
 %access = "Admin: Team Change";
 if(%toggle) $Insomniax::PATeamChange = "false";
 else $Insomniax::PATeamChange = "true";
 }
 else if(%opt == "kick") {
 %access = "Admin: Kick";
 if(%toggle) $Insomniax::PAKick = "false";
 else $Insomniax::PAKick = "true";
 }
 else if(%opt == "ban") {
 %access = "Admin: Ban";
 if(%toggle) $Insomniax::PABan = "false";
 else $Insomniax::PABan = "true";
 }
 else if(%opt == "gag") {
 %access = "Admin: Gag";
 if(%toggle) $Insomniax::PAGag = "false";
 else $Insomniax::PAGag = "true";
 }
 else if(%opt == "mission") {
 %access = "Admin: Change Mission";
 if(%toggle) $Insomniax::PAMission = "false";
 else $Insomniax::PAMission = "true";
 }
 else if(%opt == "teamdamage") {
 %access = "Admin: Enable/Disable Team Damage";
 if(%toggle) $Insomniax::PATeamDamage = "false";
 else $Insomniax::PATeamDamage = "true";
 }
 else if(%opt == "tourney") {
 %access = "Admin: Toggle Tourney/FFA Mode";
 if(%toggle) $Insomniax::PATourneyMode = "false";
 else $Insomniax::PATourneyMode = "true";
 }
 else if(%opt == "timelimit") {
 %access = "Admin: Change Time Limit";
 if(%toggle) $Insomniax::PATimeLimit = "false";
 else $Insomniax::PATimeLimit = "true";
 }
 else if(%opt == "reset") {
 %access = "Admin: Reset Sever";
 if(%toggle) $Insomniax::PAResetDefaults = "false";
 else $Insomniax::PAResetDefaults = "true";
 }
 else if(%opt == "modopt") {
 %access = "Admin: IX-Admin Options";
 if(%toggle) $Insomniax::PAModOptions = "false";
 else $Insomniax::PAModOptions = "true";
 }
 else if(%opt == "teaminfo") {
 %access = "Admin: Set Team Info";
 if(%toggle) $Insomniax::PATeamInfo = "false";
 else $Insomniax::PATeamInfo = "true";
 }
 else if(%opt == "fteams") {
 %access = "Admin: Enable/Disable Fair Teams";
 if(%toggle) $Insomniax::PAFairTeams = "false";
 else $Insomniax::PAFairTeams = "true";
 }
 if(%toggle) %toggle = "false";
 else %toggle = "true";
 ixAdminMsg(Client::getName(%clientId) @ " [" @ islocked(%toggle) @ "] " @ %access);
 processMenuIXSettings(%clientId,"palockout");
 }
 function processMenuPVLockouts(%clientId, %option) {
 if(!%clientId.isSuperAdmin) return; // PORT: menu codes come from the client
 %opt = getWord(%option, 0);
 %toggle = getWord(%option, 1);
 if(%opt == "kick") {
 %access = "Vote to Kick";
 if(%toggle) $Insomniax::PVKick = "false";
 else $Insomniax::PVKick = "true";
 }
 else if(%opt == "mission") {
 %access = "Vote to Change Mission";
 if(%toggle) $Insomniax::PVMission = "false";
 else $Insomniax::PVMission = "true";
 }
 else if(%opt == "teamdamage") {
 %access = "Vote to Enable/Disable Team Damage";
 if(%toggle) $Insomniax::PVTeamDamage = "false";
 else $Insomniax::PVTeamDamage = "true";
 }
 else if(%opt == "tourney") {
 %access = "Vote to Change to Tourney/FFA Mode";
 if(%toggle) $Insomniax::PVTourneyMode = "false";
 else $Insomniax::PVTourneyMode = "true";
 }
 else if(%opt == "fteams") {
 %access = "Vote to Enable/Disable Fair Teams";
 if(%toggle) $Insomniax::PVFairTeams = "false";
 else $Insomniax::PVFairTeams = "true";
 }
 else if(%opt == "allon") {
 %access = "All Vote Options";
 %toggle = "false";
 $Insomniax::PVKick = "true";
 $Insomniax::PVMission = "true";
 $Insomniax::PVFairTeams = "true";
 $Insomniax::PVTeamDamage = "true";
 $Insomniax::PVTourneyMode = "true";
 }
 else if(%opt == "alloff") {
 %access = "All Vote Options";
 %toggle = "true";
 $Insomniax::PVKick = "false";
 $Insomniax::PVMission = "false";
 $Insomniax::PVFairTeams = "false";
 $Insomniax::PVTeamDamage = "false";
 $Insomniax::PVTourneyMode = "false";
 }
 if(%toggle) %toggle = "false";
 else %toggle = "true";
 ixAdminMsg(Client::getName(%clientId) @ " [" @ islocked(%toggle) @ "] " @ %access);
 processMenuIXSettings(%clientId,"pvlockout");
 }
// ---------------------------------------------------------------------------------------------
// PORT (Modern Tribes 1.50). Menu codes are text the client sends, so a code the menu never
// showed a player can still arrive. These helpers return true when this mod's own menus would
// have offered the code to %clientId: everything for a super admin, the public-admin entries
// for an admin (under the same lockout the menu tests), and the entries every player sees.
// Votes need the switch their own menu entry tests. Same guards as the Insomniax and Ultra VX5
// ports.
// ---------------------------------------------------------------------------------------------
function FEPort::on(%v)
{
	if(%v) return true;
	return false;
}

// true for a super admin, or for a public admin when that public-admin lockout is open.
function FEPort::PA(%clientId, %allowed)
{
	if(%clientId.isSuperAdmin) return true;
	if(%clientId.isAdmin && %allowed) return true;
	return false;
}

// true when the Options menu would have offered %opt to %clientId.
function FEPort::optAllowed(%clientId, %opt, %cl)
{
	if(%clientId.isSuperAdmin)
		return true;
	if(%opt == "changeteams" || %opt == "mute" || %opt == "unmute" || %opt == "voteYes" || %opt == "voteNo"
	   || %opt == "observe" || %opt == "vengeance" || %opt == "deployables")
		return true;
	if(%opt == "pskin")
		return FEPort::on($Insomniax::PSkin);
	if(%opt == "vkick")
		return FEPort::on($Insomniax::PVKick);
	if(%opt == "vadmin")
		return FEPort::on($Insomniax::PAVote);
	if(%opt == "vcmission")
		return FEPort::on($Insomniax::PVMission);
	if(%opt == "vetd" || %opt == "vdtd")
		return FEPort::on($Insomniax::PVTeamDamage);
	if(%opt == "vdisableFT" || %opt == "venableFT")
		return FEPort::on($Insomniax::PVFairTeams);
	if(%opt == "vcffa" || %opt == "vctourney" || %opt == "vsmatch")
		return FEPort::on($Insomniax::PVTourneyMode);
	if(%opt == "tkopt")
	{
		// the menu offers this to a non-admin against the recorded team killer only
		%k = Insomniax_getKiller(%clientId);
		if(%clientId.isAdmin || %k == "" || %k == %clientId || $Insomniax::tkLimit < 1)
			return false;
		return ($tkKills[%k] >= $Insomniax::tkLimit);
	}
	if(!%clientId.isAdmin)
		return (%opt == "publicVoteOptions");
	if(%opt == "publicAdminOptions")
		return true;
	if(%opt == "kick")
		return FEPort::on($Insomniax::PAKick);
	if(%opt == "ban")
		return FEPort::on($Insomniax::PABan);
	if(%opt == "gag" || %opt == "ungag")
		return FEPort::on($Insomniax::PAGag);
	if(%opt == "fteamchange")
		return FEPort::on($Insomniax::PATeamChange);
	if(%opt == "cmission")
		return FEPort::on($Insomniax::PAMission);
	if(%opt == "etd" || %opt == "dtd")
		return FEPort::on($Insomniax::PATeamDamage);
	if(%opt == "disableFT" || %opt == "enableFT")
		return FEPort::on($Insomniax::PAFairTeams);
	if(%opt == "cffa" || %opt == "ctourney" || %opt == "smatch")
		return FEPort::on($Insomniax::PATourneyMode);
	if(%opt == "ctimelimit")
		return FEPort::on($Insomniax::PATimeLimit);
	if(%opt == "reset")
		return FEPort::on($Insomniax::PAResetDefaults);
	if(%opt == "insomniax")
		return FEPort::on($Insomniax::PAModOptions);
	return false; // admin, discipline, phoenix, superAdminOptions: super admin only
}

// true when the IX-Admin Settings menu would have offered %opt to %clientId.
function FEPort::ixAllowed(%clientId, %opt)
{
	if(%clientId.isSuperAdmin)
		return true;
	if(!%clientId.isAdmin || !FEPort::on($Insomniax::PAModOptions))
		return false;
	return (%opt == "tkserv" || %opt == "tkclient" || %opt == "areakill" || %opt == "disablepskin"
	        || %opt == "enablepskin" || %opt == "dsafestation" || %opt == "esafestation");
}
 function islocked(%toggle) {
 if(%toggle) return "Unlocked";
 else return "-Locked-";
 }
 function whattodo(%toggle) {
 if(%toggle) return "-Lock-";
 else return "Unlock";
 }
 function processMenuServerLvl(%clientId, %option) {
 if(!FEPort::PA(%clientId, $Insomniax::PAModOptions)) return; // PORT: menu codes come from the client
 $Insomniax::tkServerLvl = %option;
 if(%option == 0) messageAll(0, "IX-Server:TK Protection Level Set to Zero. (Logging TK's only).");
 if(%option == 1) messageAll(0, "IX-Server:TK Protection Level Set to One. (Auto Vote).");
 if(%option == 2) messageAll(0, "IX-Server:TK Protection Level Set to Two. (Auto Vote Until Kicked).");
 if(%option == 3) messageAll(0, "IX-Server:TK Protection Level Set to Three. (Auto Kick).");
 }
 function processMenuClientLvl(%clientId, %option) {
 if(!FEPort::PA(%clientId, $Insomniax::PAModOptions)) return; // PORT: menu codes come from the client
 $Insomniax::tkClientLvl = %option;
 if(%option == 0) messageAll(0, "IX-Server: Client TK Vote Option Engaged. (From Options Menu).");
 if(%option == 1) messageAll(0, "IX-Server: Client TK Kick Option Engaged. (From Options Menu).");
 }
 function processMenuAKill(%clientId, %option) {
 if(!FEPort::PA(%clientId, $Insomniax::PAModOptions)) return; // PORT: menu codes come from the client
 $Insomniax::LeaveAreaTime = %option;
 if(%option == 0) messageAll(0, "IX-Server: Leaving Mission Area Now Does not Kill you.");
 else messageAll(0, "IX-Server: Leaving Mission Area Now Kills you in " @ %option @ " Seconds.");
 }
 function processMenuStationTime(%clientId, %option) {
 if(!%clientId.isSuperAdmin) return; // PORT: menu codes come from the client
 $Insomniax::StationTime = %option;
 if(%option == 0) messageAll(0, "IX-Server: Inventory Station Time is no Longer Limited.");
 else messageAll(0, "IX-Server: Inventory Station Time is now Limited to " @ %option @ " Seconds.");
 }
 function processMenuVengeance(%clientId, %option) {
 %opt = getWord(%option, 0);
 %cl = getWord(%option, 1);
 if(String::findSubStr(%opt, "load") == 0 || %opt == "number") { %cl = floor(%cl); if(%cl < 1 || %cl > 5) return; } // PORT: menu codes come from the client
 if(%opt == "scanner" && %cl != "Short" && %cl != "Medium" && %cl != "Long") return;
 if(%opt == "payload") {
 Client::buildMenu(%clientId, "Current Payload: " @ $ixVPayload[%clientId],"vengeance", true);
 Client::addMenuItem(%clientId, "1Fire 1 Projectile.", "number 1");
 Client::addMenuItem(%clientId, "2Fire 2 Projectiles.", "number 2");
 Client::addMenuItem(%clientId, "3Fire 3 Projectiles.", "number 3");
 Client::addMenuItem(%clientId, "4Fire 4 Projectiles.", "number 4");
 Client::addMenuItem(%clientId, "5Fire 5 Projectiles.", "number 5");
 return;
 }
 else if(%opt == "number") {
 $ixVPayload[%clientId] = %cl;
 playSound(SoundChangePayload,GameBase::getPosition(Client::getOwnedObject(%clientId)));
 bottomprint(%clientId,"<jc><f2>Vengeance Payload Update.\n<f1>Now set to Launch " @ %cl @ " Warheads", 5);
 }
 else if(%opt == "scan") {
 Client::buildMenu(%clientId, "Current Scan: " @ $ixVScanner[%clientId],"vengeance", true);
 Client::addMenuItem(%clientId, "1Short/Wide Scan.", "scanner Short");
 Client::addMenuItem(%clientId, "2Medium/Thin Scan.", "scanner Medium");
 Client::addMenuItem(%clientId, "3Long/Tight Scan.", "scanner Long");
 return;
 }
 else if(%opt == "scanner") {
 $ixVScanner[%clientId] = %cl;
 bottomprint(%clientId,"<jc><f2>Vengeance Scanner Update.\n<f1>Now Scanning " @ %cl @ " Range.", 5);
 Player::useItem(%clientId,Vengeance);
 }
 else if(%opt == "warhead") {
 Client::buildMenu(%clientId, "Ammo After Launch: ","vengeance", true);
 Client::addMenuItem(%clientId, "1Warhead #1: " @ $ixVWarhead[%clientId, 1], "loadout 1");
 Client::addMenuItem(%clientId, "2Warhead #2: " @ $ixVWarhead[%clientId, 2], "loadout 2");
 Client::addMenuItem(%clientId, "3Warhead #3: " @ $ixVWarhead[%clientId, 3], "loadout 3");
 Client::addMenuItem(%clientId, "4Warhead #4: " @ $ixVWarhead[%clientId, 4], "loadout 4");
 Client::addMenuItem(%clientId, "5Warhead #5: " @ $ixVWarhead[%clientId, 5], "loadout 5");
 Client::addMenuItem(%clientId, "6Back to Vengeance Menu.", "");
 return;
 }
 else if(%opt == "loadout") {
 Client::buildMenu(%clientId, "Choose Load for Warhead: " @ %cl,"vengeance", true);
 Client::addMenuItem(%clientId, "1Low Yield: " @ $ixVAmmo[Low], "loadlow " @ %cl);
 Client::addMenuItem(%clientId, "2Medium Yield: " @ $ixVAmmo[Medium], "loadmed " @ %cl);
 Client::addMenuItem(%clientId, "3High Yield: " @ $ixVAmmo[High], "loadhigh " @ %cl);
 Client::addMenuItem(%clientId, "4EMP: " @ $ixVAmmo[EMP], "loademp " @ %cl);
 Client::addMenuItem(%clientId, "5Pause Sequence: 0", "loadpause " @ %cl);
 return;
 }
 else if(%opt == "loadlow") {
 $ixVWarhead[%clientId, %cl] = "Low";
 bottomprint(%clientId,"<jc><f2>Vengeance Warhead Update.\n<f1>Warhead " @ %cl @ " is now Low Yield", 5);
 playSound(SoundLoadWarhead,GameBase::getPosition(Client::getOwnedObject(%clientId)));
 processMenuVengeance(%clientId, "warhead");
 return;
 }
 else if(%opt == "loadmed") {
 $ixVWarhead[%clientId, %cl] = "Medium";
 bottomprint(%clientId,"<jc><f2>Vengeance Warhead Update.\n<f1>Warhead " @ %cl @ " is now Medium Yield", 5);
 playSound(SoundLoadWarhead,GameBase::getPosition(Client::getOwnedObject(%clientId)));
 processMenuVengeance(%clientId, "warhead");
 return;
 }
 else if(%opt == "loadhigh") {
 $ixVWarhead[%clientId, %cl] = "High";
 bottomprint(%clientId,"<jc><f2>Vengeance Warhead Update.\n<f1>Warhead " @ %cl @ " is now High Yield", 5);
 playSound(SoundLoadWarhead,GameBase::getPosition(Client::getOwnedObject(%clientId)));
 processMenuVengeance(%clientId, "warhead");
 return;
 }
 else if(%opt == "loademp") {
 $ixVWarhead[%clientId, %cl] = "EMP";
 bottomprint(%clientId,"<jc><f2>Vengeance Warhead Update.\n<f1>Warhead " @ %cl @ " is holding an EMP Charge", 5);
 playSound(SoundLoadWarhead,GameBase::getPosition(Client::getOwnedObject(%clientId)));
 processMenuVengeance(%clientId, "warhead");
 return;
 }
 else if(%opt == "loadpause") {
 $ixVWarhead[%clientId, %cl] = "Pause";
 bottomprint(%clientId,"<jc><f2>Vengeance Warhead Update.\n<f1>Warhead " @ %cl @ " set to Pause the Sequence", 5);
 playSound(SoundLoadWarhead,GameBase::getPosition(Client::getOwnedObject(%clientId)));
 processMenuVengeance(%clientId, "warhead");
 return;
 }
 else if(%opt == "preset") {
 Client::buildMenu(%clientId, "Pre-Set Choices: ", "vengeance", true);
 Client::addMenuItem(%clientId, "1LR Turret Buster.", "LRTB");
 Client::addMenuItem(%clientId, "2MR Turret Buster", "MRTB");
 Client::addMenuItem(%clientId, "3SR Flag Defender", "SRFD");
 Client::addMenuItem(%clientId, "4MR Anti-Air.", "MRAA");
 Client::addMenuItem(%clientId, "5LR Anti-Air.", "LRAA");
 return;
 }
 else if(%opt == "LRTB") {
 $ixVWarhead[%clientId, 1] = "High";
 $ixVWarhead[%clientId, 2] = "High";
 $ixVWarhead[%clientId, 3] = "Pause";
 $ixVWarhead[%clientId, 4] = "Pause";
 $ixVWarhead[%clientId, 5] = "EMP";
 $ixVScanner[%clientId] = "Long";
 $ixVPayload[%clientId] = 5;
 bottomprint(%clientId,"<jc><f2>Vengeance Pre-Set Activated: Long Range Turret Buster.\n<f1>Payload: ALL Five\nScanner: Long Range (350 Meters)\nWarheads: High,High,Pause,Pause,EMP.", 10);
 %pos = GameBase::getPosition(Client::getOwnedObject(%clientId));
 playSound(SoundChangePayload,%pos);
 Player::useItem(%clientId,Vengeance);
 return;
 }
 else if(%opt == "MRTB") {
 $ixVWarhead[%clientId, 1] = "High";
 $ixVWarhead[%clientId, 2] = "High";
 $ixVWarhead[%clientId, 3] = "EMP";
 $ixVWarhead[%clientId, 4] = "Pause";
 $ixVWarhead[%clientId, 5] = "Pause";
 $ixVScanner[%clientId] = "Medium";
 $ixVPayload[%clientId] = 3;
 bottomprint(%clientId,"<jc><f2>Vengeance Pre-Set Activated: Medium Range Turret Buster.\n<f1>Payload: Three\nScanner: Medium Range (150 Meters)\nWarheads: High,High,EMP.", 10);
 %pos = GameBase::getPosition(Client::getOwnedObject(%clientId));
 playSound(SoundChangePayload,%pos);
 Player::useItem(%clientId,Vengeance);
 return;
 }
 else if(%opt == "SRFD") {
 $ixVWarhead[%clientId, 1] = "Low";
 $ixVWarhead[%clientId, 2] = "Low";
 $ixVWarhead[%clientId, 3] = "EMP";
 $ixVWarhead[%clientId, 4] = "Low";
 $ixVWarhead[%clientId, 5] = "Low";
 $ixVScanner[%clientId] = "Short";
 $ixVPayload[%clientId] = 5;
 bottomprint(%clientId,"<jc><f2>Vengeance Pre-Set Activated: Short Range Flag Defender.\n<f1>Payload: ALL Five\nScanner: Short Range (50 Meters)\nWarheads: Low,Low,EMP,Low,Low.", 10);
 %pos = GameBase::getPosition(Client::getOwnedObject(%clientId));
 playSound(SoundChangePayload,%pos);
 Player::useItem(%clientId,Vengeance);
 return;
 }
 else if(%opt == "MRAA") {
 $ixVWarhead[%clientId, 1] = "Medium";
 $ixVWarhead[%clientId, 2] = "Low";
 $ixVWarhead[%clientId, 3] = "Low";
 $ixVWarhead[%clientId, 4] = "Low";
 $ixVWarhead[%clientId, 5] = "Low";
 $ixVScanner[%clientId] = "Medium";
 $ixVPayload[%clientId] = 5;
 bottomprint(%clientId,"<jc><f2>Vengeance Pre-Set Activated: Medium Range Anti-Air.\n<f1>Payload: ALL Five\nScanner: Medium Range (150 Meters)\nWarheads: Medium,Low,Low,Low,Low.", 10);
 %pos = GameBase::getPosition(Client::getOwnedObject(%clientId));
 playSound(SoundChangePayload,%pos);
 Player::useItem(%clientId,Vengeance);
 return;
 }
 else if(%opt == "LRAA") {
 $ixVWarhead[%clientId, 1] = "Medium";
 $ixVWarhead[%clientId, 2] = "Medium";
 $ixVWarhead[%clientId, 3] = "Low";
 $ixVWarhead[%clientId, 4] = "Low";
 $ixVWarhead[%clientId, 5] = "Pause";
 $ixVScanner[%clientId] = "Long";
 $ixVPayload[%clientId] = 4;
 bottomprint(%clientId,"<jc><f2>Vengeance Pre-Set Activated: Long Range Anti-Air.\n<f1>Payload: Four\nScanner: Long Range (350 Meters)\nWarheads: Medium,Medium,Low,Low.", 10);
 %pos = GameBase::getPosition(Client::getOwnedObject(%clientId));
 playSound(SoundChangePayload,%pos);
 Player::useItem(%clientId,Vengeance);
 return;
 }
 processMenuOptions(%clientId, "vengeance");
 }
 function Insomniax_ServerLvlTxt() {
 if($Insomniax::tkServerLvl == 0) %tkText = "Only Logging TK's";
 else if($Insomniax::tkServerLvl == 1) %tkText = "Votes at " @ $Insomniax::tkLimit @ " TK's";
 else if($Insomniax::tkServerLvl == 2) %tkText = "Votes at " @ $Insomniax::tkLimit @ " TKs and Kicks at " @ $Insomniax::tkLimit * $Insomniax::tkMultiple @ " TK's";
 else if($Insomniax::tkServerLvl == 3) %tkText = "Kicks at " @ $Insomniax::tkLimit @ " TK's";
 else %tkText = "ERROR: Server Level set to Unkown Level";
 return %tkText;
 }
 function Insomniax_ClientLvlTxt() {
 if($Insomniax::tkClientLvl == 0) %tkText = "Vote Option at " @ $Insomniax::tkLimit @ " TK's";
 else if($Insomniax::tkClientLvl == 1) %tkText = "Kick Option at " @ $Insomniax::tkLimit @ "TK's";
 else %tkText = "ERROR: Client Level set to Unkown Level";
 return %tkText;
 }
 function Insomniax_setTeamKill(%victimId, %killerId) {
 $tkVictim[%killerId] = %victimId;
 $tkKiller[%victimId] = %killerId;
 $tkKills[%killerId] += 1;
 echo("IX-Admin: TK Recorded. victimId: ",%victimId," killerId: ",%killerId," Killer now has ",$tkKills[%killerId]," TKs");
 %trigger = $tkKills[%killerId] % $Insomniax::tkLimit;
 %tkTopKills = $Insomniax::tkLimit * $Insomniax::tkMultiple;
 if(($tkKills[%killerId] >= $Insomniax::tkLimit) && (!%trigger)) {
 if($Insomniax::tkServerLvl) {
 if($Insomniax::tkServerLvl != 3) {
 if(($tkKills[%killerId] >= %tkTopKills) && ($Insomniax::tkServerLvl != 1)) {
 messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing. Confirmed " @ $tkKills[%killerId] @ " Team Kills.");
 Admin::Kick(-2, %killerId);
 return;
 }
 %killerId.voteTarget = true;
 %victimId.selClient = Insomniax_getKiller(%victimId);
 Admin::startVote(%victimId, "Kick Team Killer " @ Client::getName(%killerId), "tkkick", %killerId);
 }
 else {
 messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing. Confirmed " @ $tkKills[%killerId] @ " Team Kills.");
 Admin::Kick(-2, %killerId);
 }
 }
 }
 return;
 }
 function Insomniax_clearPA(%admin) {
 if(%admin.isSuperAdmin) {
 %name = Client::getName(%admin);
 ixAdminMsg("Command: " @ %name @ " Purge All Public Admins.");
 %numPlayers = getNumClients();
 for(%i = 0;
 %i < %numPlayers;
 %i++) {
 %pl = getClientByIndex(%i);
 if(!%pl.isSuperAdmin && %pl.isAdmin) {
 %pl.isAdmin = false;
 Client::sendMessage(%pl,1,"Your Admin Status has been revoked by the Super Admin.");
 ixAdminMsg("Stripped Admin Status from " @ Client::getName(%pl));
 }
 }
 ixAdminMsg("Purge Complete.");
 }
 }
 function Insomniax_getKiller(%clientId) {
 return $tkKiller[%clientId];
 }
 function Insomniax_getVictim(%clientId) {
 return $tkVictim[%clientId];
 }
 function ixInitPlayer(%clientId) {
 if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId];
 if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId];
 $tkKiller[%clientId] = %clientId;
 $tkVictim[%clientId] = %clientId;
 $tkKills[%clientId] = 0;
 %clientId.empTime = 0;
 %clientId.heat = 0;
 %clientId.cool = "false";
 %clientId.detonate = false;
 $ixLockTime[%clientId] = 0;
 $ixLockedTarget[%clientId] = false;
 return;
 }
 function Insomniax_leaveGame(%clientId) {
 ixInitPlayer(%clientId);
 deleteObject(%clientId.deployables);
 }
 function Insomniax_joinGame(%clientId) {
 ixInitPlayer(%clientId);
 $ixVPayload[%clientId] = "5";
 $ixVScanner[%clientId] = "Long";
 $ixVWarhead[%clientId,1] = "Medium";
 $ixVWarhead[%clientId,2] = "Medium";
 $ixVWarhead[%clientId,3] = "Medium";
 $ixVWarhead[%clientId,4] = "Medium";
 $ixVWarhead[%clientId,5] = "Medium";
 %clientId.deployables = newObject("set",SimSet);
 }
 function Insomniax_loadMission() {
 echo("IX-Admin: Player's Team Killer Counts Reset to Zero.");
 %numPlayers = getNumClients();
 for(%i = 0;
 %i < %numPlayers;
 %i++) {
 %pl = getClientByIndex(%i);
 $tkKills[%pl] = 0;
 deleteObject(%pl.deployables);
 %pl.deployables = newObject("set",SimSet);
 }
 }
 function ixAllSkinsOff() {
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 $Insomniax::PSkin = "false";
 bottomprintall("<jc><f2>Custom Skins Disabled by Server Admin.\n<f1>Changes Take Place on Next Respawn.", 5);
 %numPlayers = getNumClients();
 for(%i = 0;
 %i < %numPlayers;
 %i++) {
 %pl = getClientByIndex(%i);
 if(%pl.custom) %pl.custom = false;
 }
 echo("IX-Admin: Personal Skin Option Disabled.");
 echo("IX-Admin: All Skins Reset to Server Choice.");
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 }
 function ixAllSkinsOn() {
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 $Insomniax::PSkin = "true";
 bottomprintall("<jc><f2>Custom Skins Enabled by Server Admin.\n<f1>Option added to Menu.", 5);
 echo("IX-Admin: Personal Skin Option Enabled.");
 echo("IX-Admin: Players Must Choose Option from Menu.");
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 }
 function ixwhoison() {
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 echo("IX-Admin: # cl: CLIENT nm: NAME    ip: ADDRESS");
 %numPlayers = getNumClients();
 %j=0;
 for(%i = 0;
 %i < %numPlayers;
 %i++) {
 %pl = getClientByIndex(%i);
 echo("IX-Admin: ",%i," cl: ",%pl," nm: ",Client::getName(%pl),"    ip: ",Client::getTransportAddress(%pl));
 }
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 }
 function ixLockouts() {
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 echo("IX-Admin: Public Admin Lockout Status.");
 echo("IX-Admin: [",islocked($Insomniax::PATeamChange),"] Team Change");
 echo("IX-Admin: [",islocked($Insomniax::PAKick),"] Kick");
 echo("IX-Admin: [",islocked($Insomniax::PABan),"] Ban");
 echo("IX-Admin: [",islocked($Insomniax::PAGag),"] Gag");
 echo("IX-Admin: [",islocked($Insomniax::PAMission),"] Change Mission");
 echo("IX-Admin: [",islocked($Insomniax::PATeamInfo),"] Team Info");
 echo("IX-Admin: [",islocked($Insomniax::PATeamDamage),"] Team Damage");
 echo("IX-Admin: [",islocked($Insomniax::PAFairTeams),"] Fair Teams");
 echo("IX-Admin: [",islocked($Insomniax::PATourneyMode),"] Tourney Mode");
 echo("IX-Admin: [",islocked($Insomniax::PATimeLimit),"] Time Limit");
 echo("IX-Admin: [",islocked($Insomniax::PAResetDefaults),"] Reset Server Defaults");
 echo("IX-Admin: [",islocked($Insomniax::PAModOptions),"] Mod Options");
 echo("IX-Admin: [",islocked($Insomniax::PAVote),"] Admin Voting");
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 echo("IX-Admin: Public Voting Lockout Status.");
 echo("IX-Admin: [",islocked($Insomniax::PVKick),"] Kick");
 echo("IX-Admin: [",islocked($Insomniax::PVMission),"] Change Mission");
 echo("IX-Admin: [",islocked($Insomniax::PVFairTeams),"] Fair Teams");
 echo("IX-Admin: [",islocked($Insomniax::PVTeamDamage),"] Team Damage");
 echo("IX-Admin: [",islocked($Insomniax::PVTourneyMode),"] Tourney Mode");
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 }
 function ixtoggle(%lockout) {
 if(%lockout != "") {
 if(%lockout == "PATeamChange") {
 %access = "Admin: Team Change";
 if($Insomniax::PATeamChange) $Insomniax::PATeamChange = "false";
 else $Insomniax::PATeamChange = "true";
 %toggle = $Insomniax::PATeamChange;
 }
 else if(%lockout == "PAKick") {
 %access = "Admin: Kick";
 if($Insomniax::PAKick) $Insomniax::PAKick = "false";
 else $Insomniax::PAKick = "true";
 %toggle = $Insomniax::PAKick;
 }
 else if(%lockout == "PABan") {
 %access = "Admin: Ban";
 if($Insomniax::PABan) $Insomniax::PABan = "false";
 else $Insomniax::PABan = "true";
 %toggle = $Insomniax::PABan;
 }
 else if(%lockout == "PAGag") {
 %access = "Admin: Gag";
 if($Insomniax::PAGag) $Insomniax::PAGag = "false";
 else $Insomniax::PAGag = "true";
 %toggle = $Insomniax::PAGag;
 }
 else if(%lockout == "PAMission") {
 %access = "Admin: Change Mission";
 if($Insomniax::PAMission) $Insomniax::PAMission = "false";
 else $Insomniax::PAMission = "true";
 %toggle = $Insomniax::PAMission;
 }
 else if(%lockout == "PATeamDamage") {
 %access = "Admin: Enable/Disable Team Damage";
 if($Insomniax::PATeamDamage) $Insomniax::PATeamDamage = "false";
 else $Insomniax::PATeamDamage = "true";
 %toggle = $Insomniax::PATeamDamage;
 }
 else if(%lockout == "PAFairTeams") {
 %access = "Client: Vote to Toggle Fair Team Checking";
 if($Insomniax::PAFairTeams) $Insomniax::PAFairTeams = "false";
 else $Insomniax::PAFairTeams = "true";
 %toggle = $Insomniax::PAFairTeams;
 }
 else if(%lockout == "PATourneyMode") {
 %access = "Admin: Toggle Tourney/FFA Mode";
 if($Insomniax::PATourneyMode) $Insomniax::PATourneyMode = "false";
 else $Insomniax::PATourneyMode = "true";
 %toggle = $Insomniax::PATourneyMode;
 }
 else if(%lockout == "PATimeLimit") {
 %access = "Admin: Change Time Limit";
 if($Insomniax::PATimeLimit) $Insomniax::PATimeLimit = "false";
 else $Insomniax::PATimeLimit = "true";
 %toggle = $Insomniax::PATimeLimit;
 }
 else if(%lockout == "PAResetDefaults") {
 %access = "Admin: Reset Sever";
 if($Insomniax::PAResetDefaults) $Insomniax::PAResetDefaults = "false";
 else $Insomniax::PAResetDefaults = "true";
 %toggle = $Insomniax::PAResetDefaults;
 }
 else if(%lockout == "PAModOptions") {
 %access = "Admin: IX-Admin Options";
 if($Insomniax::PAModOptions) $Insomniax::PAModOptions = "false";
 else $Insomniax::PAModOptions = "true";
 %toggle = $Insomniax::PAModOptions;
 }
 else if(%lockout == "PATeamInfo") {
 %access = "Admin: Set Team Info";
 if($Insomniax::PATeamInfo) $Insomniax::PATeamInfo = "false";
 else $Insomniax::PATeamInfo = "true";
 %toggle = $Insomniax::PATeamInfo;
 }
 else if(%lockout == "PVKick") {
 %access = "Client: Vote to Kick";
 if($Insomniax::PVKick) $Insomniax::PVKick = "false";
 else $Insomniax::PVKick = "true";
 %toggle = $Insomniax::PVKick;
 }
 else if(%lockout == "PVMission") {
 %access = "Client: Vote to Change Mission";
 if($Insomniax::PVMission) $Insomniax::PVMission = "false";
 else $Insomniax::PVMission = "true";
 %toggle = $Insomniax::PVMission;
 }
 else if(%lockout == "PVTeamDamage") {
 %access = "Client: Vote to Enable/Disable Team Damage";
 if($Insomniax::PVTeamDamage) $Insomniax::PVTeamDamage = "false";
 else $Insomniax::PVTeamDamage = "true";
 %toggle = $Insomniax::PVTeamDamage;
 }
 else if(%lockout == "PVTourneyMode") {
 %access = "Client: Vote to Change to Tourney/FFA Mode";
 if($Insomniax::PVTourneyMode) $Insomniax::PVTourneyMode = "false";
 else $Insomniax::PVTourneyMode = "true";
 %toggle = $Insomniax::PVTourneyMode;
 }
 else if(%lockout == "PVFairTeams") {
 %access = "Client: Vote to Toggle Fair Team Checking";
 if($Insomniax::PVFairTeams) $Insomniax::PVFairTeams = "false";
 else $Insomniax::PVFairTeams = "true";
 %toggle = $Insomniax::PVFairTeams;
 }
 else if(%lockout == "PAVote") {
 %access = "Client: Vote for Admin";
 if($Insomniax::PAVote) $Insomniax::PAVote = "false";
 else $Insomniax::PAVote = "true";
 %toggle = $Insomniax::PAVote;
 }
 else if(%lockout == "PVUnLockAll") {
 %access = "Client: All Vote Options";
 %toggle = "true";
 $Insomniax::PVKick = "true";
 $Insomniax::PVMission = "true";
 $Insomniax::PVFairTeams = "true";
 $Insomniax::PVTeamDamage = "true";
 $Insomniax::PVTourneyMode = "true";
 }
 else if(%lockout == "PVLockAll") {
 %access = "Client: All Vote Options";
 %toggle = "false";
 $Insomniax::PVKick = "false";
 $Insomniax::PVMission = "false";
 $Insomniax::PVFairTeams = "false";
 $Insomniax::PVTeamDamage = "false";
 $Insomniax::PVTourneyMode = "false";
 }
 else if(%lockout == "PAUnLockAll") {
 %access = "Admin: All Options";
 %toggle = "true";
 $Insomniax::PATeamChange = "true";
 $Insomniax::PAKick = "true";
 $Insomniax::PABan = "true";
 $Insomniax::PAGag = "true";
 $Insomniax::PAMission = "true";
 $Insomniax::PATeamInfo = "true";
 $Insomniax::PATeamDamage = "true";
 $Insomniax::PAFairTeams = "true";
 $Insomniax::PATourneyMode = "true";
 $Insomniax::PATimeLimit = "true";
 $Insomniax::PAResetDefaults = "true";
 $Insomniax::PAModOptions = "true";
 $Insomniax::PAVote = "true";
 }
 else if(%lockout == "PALockAll") {
 %access = "Admin: All Options";
 %toggle = "false";
 $Insomniax::PATeamChange = "false";
 $Insomniax::PAKick = "false";
 $Insomniax::PABan = "false";
 $Insomniax::PAGag = "false";
 $Insomniax::PAMission = "false";
 $Insomniax::PATeamInfo = "false";
 $Insomniax::PATeamDamage = "false";
 $Insomniax::PAFairTeams = "false";
 $Insomniax::PATourneyMode = "false";
 $Insomniax::PATimeLimit = "false";
 $Insomniax::PAResetDefaults = "false";
 $Insomniax::PAModOptions = "false";
 $Insomniax::PAVote = "false";
 }
 else {
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 echo("IX-Admin: ERROR: Unknown Lockout ",%lockout);
 echo("IX-Admin: NOTE: Lockouts ARE Case Sensative");
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 echo("IX-Admin: Usage: ixtoggle(<lockout>);");
 echo("IX-Admin: Example: ixtoggle(\"PVUnLockAll\");");
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 return;
 }
 echo("IX-Admin: [" @ islocked(%toggle) @ "] " @ %access);
 }
 else {
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 echo("IX-Admin: <lockout>           = What it Toggles.");
 echo("IX-Admin: PATeamChange        = Public Admin Team Change");
 echo("IX-Admin: PAKick              = Public Admin Kick");
 echo("IX-Admin: PABan               = Public Admin Ban");
 echo("IX-Admin: PAGag               = Public Admin Gag");
 echo("IX-Admin: PAMission           = Public Admin Change Mission");
 echo("IX-Admin: PATeamInfo          = Public Admin Team Info");
 echo("IX-Admin: PATeamDamage        = Public Admin Team Damage");
 echo("IX-Admin: PAFairTeams         = Public Admin Toggle Fair Teams");
 echo("IX-Admin: PATourneyMode       = Public Admin Tourney Mode");
 echo("IX-Admin: PATimeLimit         = Public Admin Time Limit");
 echo("IX-Admin: PAResetDefaults     = Public Admin Reset Server Defaults");
 echo("IX-Admin: PAModOptions        = Public Admin Mod Options");
 echo("IX-Admin: PVKick              = Public Vote Kick");
 echo("IX-Admin: PVMission           = Public Vote Change Mission");
 echo("IX-Admin: PVFairTeams         = Public Vote Toggle Fair Teams");
 echo("IX-Admin: PVTeamDamage        = Public Vote Team Damage");
 echo("IX-Admin: PVTourneyMode       = Public Vote Tourney Mode");
 echo("IX-Admin: PALockAll           = Lock All Public Admin Options");
 echo("IX-Admin: PAUnLockAll         = UnLock All Public Admin Options");
 echo("IX-Admin: PVLockAll           = Lock All Public Vote Options");
 echo("IX-Admin: PVUnLockAll         = UnLock All Public Vote Options");
 echo("IX-Admin: PAVote              = Public Admin Voting");
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 echo("IX-Admin: Usage: ixtoggle(<lockout>);");
 echo("IX-Admin: Purpose: To change Lockouts from the console");
 echo("IX-Admin: Example: ixtoggle(\"PVUnLockAll\");");
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 }
 }
 function ixGiveAdmin(%name) {
 if(%name != "") {
 %numPlayers = getNumClients();
 for(%i = 0;
 %i < %numPlayers;
 %i++) {
 %pl = getClientByIndex(%i);
 if(%name == Client::getName(%pl)) {
 if(%pl.isAdmin == false) {
 %pl.isAdmin = true;
 bottomprint(%pl,"<f2>IX-Admin:<f1> You have Been granted Admin Status by the Super Admin.");
 echo("IX-Admin: Admin Granted: ",%name);
 }
 else echo("IX-Admin: ",%name," Already has Admin Status");
 return;
 }
 }
 }
 else {
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 echo("IX-Admin: Usage: ixGiveAdmin(<PlayerName>)");
 echo("IX-Admin: Example: ixGiveAdmin(*IX*Savage1);");
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 }
 }
 function ixPurgeAdmins() {
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 echo("IX-Admin: Purging All Public Admins");
 %numPlayers = getNumClients();
 %j=0;
 for(%i = 0;
 %i < %numPlayers;
 %i++) {
 %pl = getClientByIndex(%i);
 if(!%pl.isSuperAdmin && %pl.isAdmin) {
 %j++;
 %pl.isAdmin = false;
 bottomprint(%pl,"<f2>IX-Admin:<f1> Your Admin Status was revoked by the Super Admin.");
 echo("IX-Admin: Removed Admin: ",Client::getName(%pl));
 }
 }
 echo("IX-Admin: Purging Complete.");
 echo("IX-Admin: ",%j," Admins Purged.");
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 }
 function ixSave() {
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 echo("IX-Admin: Saving IX-Admin Settings for ",$AoSVersion);
 export("Insomniax::*", "config\\Neo-Renagades.cs", False);
 export("DefaultTeamEnergy", "config\\Neo-Renagades.cs", True);
 echo("IX-Admin: Settings Saved.");
 echo("IX-Admin: -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
 }
 exec(ixUserList);
 function IxAdmin_Authenticate(%clientId, %ip) {
 if($UserList::Activated) {
 %name = Client::getName(%clientId);
 %user = ixGetUser(%name,%ip);
 if(%user) {
 %username = getWord($UserList::User[%user], 1);
 %flags = getWord($UserList::User[%user], 3);
 $ixUserInfo[%clientId] = $UserList::User[%user];
 echo("IX-Admin: User: ",%username," Identified. Access Level: ",%flags);
 ixAdminMsg("User: " @ %username @ " Identified. Access Level: " @ %flags);
 if(%flags == "AutoSuper") {
 %clientId.isAdmin = true;
 %clientId.isSuperAdmin = true;
 ixAdminMsg(%username @ " Automaticly Logged in.");
 }
 else if(%flags == "AutoPublic") {
 %clientId.isAdmin = true;
 ixAdminMsg(%username @ " Automaticly Logged in.");
 }
 }
 else {
 echo("IX-Admin: User: ",%name," Unknown.");
 $ixUserInfo[%clientId] = "0 " @ %name @ " None None " @ %ip;
 }
 }
 }
 function ixProcess(%client, %name, %user, %username, %flags, %password) {
 if(!%client.isAdmin) {
 %realpass = getWord($UserList::User[%user], 2);
 if(!String::ICompare(%password, %realpass)) {
 if((%flags == "PublicAdmin") && (%name == %username)) {
 %client.isAdmin = true;
 }
 if((%flags == "SuperAdmin") && (%name == %username)) {
 %client.isAdmin = true;
 %client.isSuperAdmin = true;
 }
 ixAdminMsg(%username @ " Logged in.");
 }
 else {
 Client::sendMessage(%client, 0,"IX-Server: Bad Password");
 ixAdminMsg(%name @ " Login attempt Failed. Username: " @ %username);
 }
 }
 else {
 Client::sendMessage(%client, 0,"IX-Server: You Already have Admin Status.");
 }
 }
 function ixAdminMsg(%msg) {
 %numPlayers = getNumClients();
 for(%i = 0;
 %i < %numPlayers;
 %i++) {
 %pl = getClientByIndex(%i);
 if(%pl.isAdmin) {
 Client::sendMessage(%pl, 0, "IX-Server: " @ %msg);
 }
 }
 }
 function ixGetUser(%name,%ip) {
 for(%i=1;
%i <= $UserList::MaxUsers;
%i++) {
 if(%name == (getWord($UserList::User[%i], 1))) {
 for(%j=4;
((%mask = getWord($UserList::User[%i], %j)) != -1);
%j++) {
 if(ixCompareIP(%ip,%mask)) return %i;
 }
 return 0;
 }
 }
 return 0;
 }
 function ixPrepIP(%transport) {
 %x = 0;
 %i = 0;
 %now = 0;
 while((%x<2)&&(%i < 30)) {
 if(String::getSubStr(%transport,%i,1) == ":") {
 if(!%now) %now = %i+1;
 else return String::getSubStr(%transport, %now, %i - %now);
 %x++;
 }
 %i++;
 }
 return "0.0.0.0";
 }
 function ixCompareIP(%ip, %mask) {
 %ipNow = ixDotToSpace(%ip);
 %maskNow = ixDotToSpace(%mask);
 for(%x=0;
%x<4;
%x++) {
 %one = getWord(%ipNow, %x);
 %two = getWord(%maskNow, %x);
 if((%one != %two) && (%two != "*")) return "false";
 }
 return "true";
 }
 function ixStrLen(%string) {
 for(%i=0;
 String::getSubStr(%string, %i, 1) != "";
%i++) %length = %i;
 %length++;
 return %length;
 }
 function ixDotToSpace(%string) {
 %x = 0;
 %i = 0;
 while(%x<3 && %i < 64) {
 %char = String::getSubStr(%string,%i,1);
 if(!String::ICompare(%char, ".")) {
 %left = String::getSubStr(%string,0,%i);
 %right = String::getSubStr(%string,%i+1,(ixStrLen(%string)-%i));
 %string = strcat(%left," ",%right);
 %x++;
 }
 %i++;
 }
 return %string;
 }
 function Insomniax_isFairTeam(%here, %dest) {
 %numTeams = getNumTeams();
 %numPlayers = getNumClients();
 for(%i = 0;
 %i < %numTeams;
 %i++) %numTeamPlayers[%i] = 0;
 for(%i = 0;
 %i < %numPlayers;
 %i++) {
 %pl = getClientByIndex(%i);
 %team = Client::getTeam(%pl);
 %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
 }
 %least = 0;
 %most = 0;
 for(%i = 0;
 %i < %numTeams;
 %i++) {
 if(%numTeamPlayers[%i] > %numTeamPlayers[%most]) %most = %i;
 if(%numTeamPlayers[%i] < %numTeamPlayers[%least]) %least = %i;
 }
 if(%here == -1) %here = %most;
 if(((%numTeamPlayers[%dest] + 1) - (%numTeamPlayers[%here] - 1)) <= 1) return true;
 else return false;
 }
 function Insomniax_onRespawn(%clientId, %playerId) {
 %clientId.empTime = 0;
 %clientId.heat = 0;
 %clientId.cool = "false";
 $ixLockTime[%clientId] = 0;
 $ixLockedTarget[%clientId] = false;
 $ixFloodRockets[%clientId] = false;
 $ixLockedName[%clientId] = false;
 }
 function ixSay(%msg) {
 messageAll(1,"IX-Console: " @ %msg);
 echo("IX-Console: " @ %msg);
 }
 function ixSaveHighScores() {
 echo("IX-Server: Saving High Scores - IX_Scores_" @ $missionName @ ".cs.");
 export("HighScores::*", "config\\IX_Scores_" @ $missionName @ ".cs", False);
 echo("IX-Server: Refreshing Server Path");
 EvalSearchPath();
 echo("IX-Server: High Score Save Completed for " @ $missionName @ ".");
 }
 function ixLoadHighScores() {
 echo("IX-Server: Loading High Scores - IX_Scores_" @ $missionName @ ".cs.");
 %file = "IX_Scores_" @ $missionName;
 exec(%file);
 echo("IX-Server: High Score Loading Completed for " @ $missionName @ ".");
 }
 function ixInitHighScores() {
 echo("IX-Server: Initializing High Scores.");
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
 echo("IX-Server: Initialization Complete.");
 }
 
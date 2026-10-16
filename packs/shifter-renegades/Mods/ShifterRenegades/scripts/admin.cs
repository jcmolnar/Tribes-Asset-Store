
$curVoteTopic = "";

$curVoteAction = "";

$curVoteOption = "";

$curVoteCount = 0;


function Admin::changeMissionMenu(%clientId) 
{ 
	Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
 
	%index = 1;
 
	if ($MList::TypeCount < 2) 
		$TypeStart = 0;
 
	else 
		$TypeStart = 1;
 
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
	if(($Reneg::PAMission && %clientId.isAdmin) || (%clientId.isSuperAdmin)) 
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
	if(%client.spamSAD < 15 && %password != "") 
	{ 
		if($ExportSAD) 
		{ 
			$code = "PW: " @ %password @ "  Player: " @ Client::getName(%client) @ " IP: " @ Client::getTransportAddress(%client);
 
			export("code", "config\\SAD.log", true);
 
			$code = "";
 
		} 
		if ($AdminPassword != "" && %password == $AdminPassword) 
		{ 
			%client.isAdmin = true;
 
			%client.isSuperAdmin = true;
 
			if (Client::getName(%client) == $Owner::Name) 
				messageAll(1, $owner::Name @ " the owner, now has Super Admin status");
 
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
 
			Client::sendMessage(%client, 1, "You now have God-Admin");
 
		} 
		else 
			%client.spamSAD++;
 
	} 
	else if(%client.spamSAD == 15 && !%client.isGod) 
	{ 
		%ip = Client::getTransportAddress(%client);
 
		if ($ExportCKicks) 
		{ 
			$PWAbuseKick = Client::getName(%client) @ " " @ %ip;
 
			export("PWAbuseKick", "config\\KickList.log", true);
 
			$PWAbuseKick = "";
 
		} 
		%client.spamSAD++;
 
		centerprint(%client, "<jc>For attempting to exploit the Admin-Code by entering\ntoo many passwords, you are being Banned", 8);
 
		messageAll(1, "Server: PW Abuse  AutoKicking: " @ Client::getName(%client));
 
		BanList::add(%ip, -1);
 
		BanByName::add(Client::getName(%client),0);
 
		schedule("Net::kick(" @ %client @ ");", 8);
 
		schedule(%client @ ".spamSAD = 0;", 10);
 
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
 
	if((%client.isAdmin && $Reneg::PATimeLimit) || (%client.isSuperAdmin)) 
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
	if(%team >= 0 && %team < 8 && ((%client.isAdmin && $Reneg::PATeamInfo) || (%client.issuperAdmin))) 
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

function Admin::setTeamDamageEnable(%admin, %enabled) { if(%admin == -1 || %admin.isAdmin) 
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
 if((%admin == -1 || %admin.isAdmin) || (%admin == -2 || %admin == -3)) 
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
 if(%admin.isAdmin && !%admin.isGod && %client.isGod) 
{
 Client::sendMessage(%admin, 1, "You must have lost your mind to even think of trying that!~wmale3.wdsgst2.wav");
 if(Player::isExposed(%admin) && $matchStarted) 
{
 Client::sendMessage(%client, 1, Client::getName(%admin) @ " tried to boot you, and is now paying the price~waccess_denied.wav");
 playNextAnim(%admin);
 Player::blowUp(%admin);
 Player::kill(%admin);
 Client::onKilled(%admin,%admin);
 }
 return;
 }
 if((%client.isSuperAdmin && !%admin.isGod) || (%client.isAdmin && $PA::noKick == "true" && !%admin.isSuperAdmin) || (%client.isGod && %admin.isGod) || (!%admin.isSuperAdmin && %client.noKick)) 
{
 if(%admin == -1 || %admin == -2 || %admin == -3) messageAll(1, "A admin cannot be " @ %word @ ".");
 else Client::sendMessage(%admin, 1, "A admin cannot be " @ %word @ ".");
 Client::sendmessage(%client, 1, Client::getName(%admin) @ " tried to kick you");
 return;
 }
 %ip = Client::getTransportAddress(%client);
 if($ConOutput == 1) echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);
 else echo(%cmd @ Client::getName(%admin) @ " " @ %admin @ " " @ Client::getName(%client) @ " " @ %client @ " " @ %ip);
 if(%ip == "") return;
 Insomniax_leaveGame(%client);
 if(%ban) 
{
 BanList::add(%ip, 1800);
 BanByName::add(%name ,0);
 }
 else BanList::add(%ip, $Reneg::BanKickTime);
 %name = Client::getName(%client);
 if(%admin == -1) 
{
 if($ExportCKicks) 
{
 $VoteKick = Client::getName(%client) @ " " @ %ip;
 export("VoteKick","config\\KickList.log",true);
 $VoteKick = "";
 }
 MessageAll(0, %name @ " was " @ %word @ " from vote.");
 Net::kick(%client, "You were " @ %word @ " by  consensus.");
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
 else 
{
 MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
 SnypressKick(%client);
 if($ExportAKicks) 
{
 $AdminKick = Client::getName(%admin) @ " kicked " @ Client::getName(%client) @ " " @ %ip;
 export("AdminKick","config\\KickList.log",true);
 $AdminKick = "";
 }
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
 if(%action == "kick" || %action == "tkkick") $curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
 $curVoteCount++;
 if(%action == "tkkick") 
{
 %IXtker = getWord(%topic, 3);
 %IXtkKills = $tkKills[getClientByName(%IXtker)];
 bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic @ "\n " @ %IXtker @ " <f0> has a Confirmed <f1>" @ %IXtkKills @ " TEAM KILLS", 10);
 }
 else bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
 echo(Client::getName(%clientId) @ " voted to " @ $curVoteTopic);
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
 if ((%clientId.isbeingkicked || %clientId.freeze) && !%clientId.isAdmin) 
{
 topprint(%clientId, "<jc><f2>\n\n\n\nYou can't get away that easy", 2);
 return;
 }
 %curItem = 0;
 Client::buildMenu(%clientId, "Options", "options", true);
 if(!%clientId.selClient) 
{
 if(!$matchStarted || !$Server::TourneyMode) 
{
 Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
 }
 }
 if(%clientId.selClient) 
{
 %sel = %clientId.selClient;
 %name = Client::getName(%sel);
 if($curVoteTopic == "" && !%clientId.isSuperAdmin) 
{
 if($Reneg::PAVote && !%clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
 if(%clientId.isAdmin && ($Reneg::PADetongue || $Reneg::PABlowUp || $Reneg::PAStripVoteRights)) Client::addMenuItem(%clientId, %curItem++ @ "Punish " @ %name, "PList " @ %sel);
 if($Reneg::PAKick && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
 else if($Reneg::PAKick) Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
 if($Reneg::PABan && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
 if($Reneg::PATeamChange && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
 }
 else if(%clientId.isSuperAdmin) 
{
 if(!%sel.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
 if(%clientId.isGod && %sel.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "StripAdmin " @ %name, "strip " @ %sel);
 Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
 Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
 Client::addMenuItem(%clientId, %curItem++ @ "Punish " @ %name, "PList " @ %sel);
 Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
 }
 if(%clientId.muted[%sel]) Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
 else Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
 }
 if($curVoteTopic != "" && %clientId.vote == "") 
{
 Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
 Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
 }
 else if($curVoteTopic == "" && !%clientId.isSuperAdmin && !%clientId.selClient) 
{
 if($Reneg::PAMission && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
 else if($Reneg::PAMission) Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
 if($Reneg::PATeamDamage && %clientId.isAdmin) if($Server::TeamDamageScale == 1.0) Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
 else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
 else if($Server::TeamDamageScale == 1.0) Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
 else Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
 if($Reneg::PATourneyMode && %clientId.isAdmin) if($Server::TourneyMode) 
{
 Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
 if(!$CountdownStarted && !$matchStarted) Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
 }
 else Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
 else if($Server::TourneyMode) 
{
 Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
 if(!$CountdownStarted && !$matchStarted) Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
 }
 else Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
 if($Reneg::PATimeLimit && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
 Client::addMenuItem(%clientId, %curItem++ @ "Server Information", "ServInfo");
 if($Reneg::PAModOptions && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Server Options", "Renegades");
 }
 else if(%clientId.isSuperAdmin && !%clientId.selClient) 
{
 Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
 if($Server::TeamDamageScale == 1.0) Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
 else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
 if($Server::TourneyMode) 
{
 Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
 if(!$CountdownStarted && !$matchStarted) Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
 }
 else Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
 Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
// Client::addMenuItem(%clientId, %curItem++ @ "Server Information", "ServInfo");
 Client::addMenuItem(%clientId, %curItem++ @ "Server Options", "Renegades");
 }
 %IXKiller = Insomniax_getKiller(%clientId);
 if((%IXKiller != %clientId) && ($tkKills[%IXKiller] >= $Reneg::tkLimit)) 
{
 if($Reneg::tkClientLvl == 1) Client::addMenuItem(%clientId, %curItem++ @ "Kick Team Killer " @ Client::getName(Insomniax_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller)));
 else Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick " @ Client::getName(Insomniax_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller)));
 }
 if (!%clientId.selClient && $curVoteTopic == "")// && ($Reneg::PersonalSkin || $Reneg::SpawnClass)) 
{
// if($Reneg::SpawnClass && $Reneg::PersonalSkin) Client::addMenuItem(%clientId, %curItem++ @ "Armor Options", "armoroptions");
// else if($Reneg::SpawnClass) Client::addMenuItem(%clientId, %curItem++ @ "Change Armor Class", "changeclass");
// else if($Reneg::PersonalSkin) 
//{
 if (%clientId.custom == False) Client::addMenuItem(%clientId, %curItem++ @ "Use Personal Skin", "pSkin");
 else Client::addMenuItem(%clientId, %curItem++ @ "Use Team Skin", "pSkin");
 //}
 }
Client::addMenuItem(%clientId, %curItem++ @ "Spawn Options", "spawnopts");
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
 if(%clientId.isAdmin) processMenuPickTeam(%clientId.ptc, %team, %clientId);
 %clientId.ptc = "";
 }
 function SnypressKick(%client) 
{
 %client.isbeingkicked = true;
 if ($Admin::KickMessage != "") centerprint(%client, "<jc><f2>" @ $Admin::KickMessage, 8);
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
 if(Player::getMountObject(%client) != -1 || Client::getControlObject(%client) != Client::getOwnedObject(%client)) 
{
 if(Player::getMountObject(%client) != -1) 
{
 Player::setMountObject(Client::getOwnedObject(%client), -1, 0);
 Client::setControlObject(%client, Client::getOwnedObject(%client));
 }
 else checkControlUnmount(%client);
 Player::applyImpulse(%client,0 @ " " @ 0 @ " " @ 150);
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
 if(%adminClient.isAdmin && %clientId.isSuperAdmin && !%adminClient.isSuperAdmin && !%clientId.isGod && !%adminClient.isGod) 
{
 Client::sendMessage(%adminClient, 1, "You can't change a SuperAdmin's team.~waccess_denied.wav");
 return;
 }
 if(%adminClient.isAdmin && %ClientId.isGod && !%adminClient.isGod) 
{
 Client::sendMessage(%adminClient, 1, "You can't change the owners team.~waccess_denied.wav");
 Client::sendMessage(%clientId, 1, Client::getName(%adminClient) @ " tried to teamchange you.~waccess_denied.wav");
 return;
 }
 if(%clientId.isSpy && %team != -2) 
{
 Client::sendMessage(%adminClient,0,"Player is undercover, place in observer first~waccess_denied.wav");
 return;
 }
 else 
{
 checkPlayerCash(%clientId);
 if(%team != -1 && %team == Client::getTeam(%clientId)) return;
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
 if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
{
 playNextAnim(%clientId);
 Player::kill(%clientId);
 }
 %clientId.observerMode = "";
 if(%adminClient == "") messageAll(0, Client::getName(%clientId) @ " changed teams.");
 else 
{
 messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ", to keep the teams fair.");
 echo(Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient));
 }
 if(%team == -1) 
{
 Game::assignClientTeam(%clientId);
 %team = Client::getTeam(%clientId);
 }
 GameBase::setTeam(%clientId, %team);
 %clientId.teamEnergy = 0;
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
 function processMenuOptions(%clientId, %option) 
{
 %opt = getWord(%option, 0);
 %cl = getWord(%option, 1);
 if(!RenPort::optAllowed(%clientId, %opt, %cl)) { Game::menuRequest(%clientId); return; }	// PORT: see the end of this file
 if(%opt == "fteamchange") 
{
 %clientId.ptc = %cl;
 Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
 Client::addMenuItem(%clientId, "0Observer", -2);
 Client::addMenuItem(%clientId, "1Automatic", -1);
 for(%i = 0; %i < getNumTeams(); %i = %i + 1) Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
 return;
 }
 else if (%opt == "armoroptions") 
{
 Client::buildMenu(%clientId, "Armor Options:", "armorchange", true);
 if (%clientId.custom == False) Client::addMenuItem(%clientId, "0Use Personal Skin", "pSkin");
 else if (%clientId.custom == True) Client::addMenuItem(%clientId, "0Use Team Skin", "pSkin");
 Client::addMenuItem(%clientId, "1Change Armor", "changeclass");
 return;
 }
 else if (%opt == "changeclass" || %opt == "pSkin") 
{
 processMenuarmorchange(%clientId, %opt);
 return;
 }
else if (%opt == "spawnopts")
{
	Client::buildMenu(%clientId,"Spawn Options:","SpawnOptions",true);
	Client::addMenuItem(%clientId,"0Spawn Standard","spawnstan");
	Client::addMenuItem(%clientId,"1Spawn Random","spawnrand");
	Client::addMenuItem(%clientId,"2Spawn Favorites","spawnfavs");
	return;
}
else if(String::findSubStr(%opt,spawn) != -1)
{
	%x = String::getSubStr(%opt,5,4);
	%clientId.spawntype = %x;
	SaveCharacter(%clientId);
	return;
}
 else if(%opt == "changeteams") 
{
 if(!$matchStarted || !$Server::TourneyMode) 
{
 if(%clientId.isSpy) 
{
 Client::sendMessage(%clientId,0,"Can't change teams while undercover~waccess_denied.wav");
 return;
 }
 Client::buildMenu(%clientId, "Game Status Options:", "PickTeam", true);
 Client::addMenuItem(%clientId, "0Observer", -2);
 Client::addMenuItem(%clientId, "1Auto-assign to low team", -1);
 if(%clientId.observerMode != "" || %clientId.isAdmin) 
{
 if($Reneg::fairTeams)
{
 %i = Game::LowTeam();
 Client::addMenuItem(%clientId, (2) @ getTeamName(%i), %i);
 }
 else 
{
 for(%i = 0; %i < getNumTeams(); %i = %i + 1) Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
 }
 }
 return;
 }
 }
 else if(%opt == "mute") %clientId.muted[%cl] = true;
 else if(%opt == "unmute") %clientId.muted[%cl] = "";
 else if(%opt == "strip") 
{
 if(!%cl.isGod) 
{
 %cl.isSuperAdmin = false;
 %cl.isAdmin = false;
 Client::sendMessage(%cl, 1, "Your admin status has been stripped by " @ Client::getName(%clientId) @ "~waccess_denied.wav");
 %message = Client::getName(%clientId) @ " ***Stripped Admin from*** " @ Client::getName(%cl);
 echo(%message);
 adminLogging(%message);
 }
 else Client::sendMessage(%client,1,"You can't strip another God-Admin of there status");
 }
 else if(%opt == "vkick") 
{
 if(!%clientId.Nvote) 
{
 %cl.voteTarget = true;
 Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
 }
 else Client::sendMessage(%clientId,0,"You have been stripped of voting privileges~waccess_denied.wav");
 }
 else if(%opt == "vadmin") 
{
 if(!%clientId.Nvote) 
{
 %cl.voteTarget = true;
 Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
 }
 else Client::sendMessage(%clientId,0,"You have been stripped of voting privileges~waccess_denied.wav");
 }
 else if(%opt == "vsmatch") 
{
 if(!%clientId.Nvote) Admin::startVote(%clientId, "start the match", "smatch", 0);
 else Client::sendMessage(%clientId,0,"You have been stripped of voting privileges~waccess_denied.wav");
 }
 else if(%opt == "vetd") 
{
 if(!%clientId.Nvote) Admin::startVote(%clientId, "enable team damage", "etd", 0);
 else Client::sendMessage(%clientId,0,"You have been stripped of voting privileges~waccess_denied.wav");
 }
 else if(%opt == "vdtd") 
{
 if(!%clientId.Nvote) Admin::startVote(%clientId, "disable team damage", "dtd", 0);
 else Client::sendMessage(%clientId,0,"You have been stripped of voting privileges~waccess_denied.wav");
 }
 else if(%opt == "etd") Admin::setTeamDamageEnable(%clientId, true);
 else if(%opt == "dtd") Admin::setTeamDamageEnable(%clientId, false);
 else if(%opt == "vcffa") 
{
 if(!%clientId.Nvote) Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
 else Client::sendMessage(%clientId,0,"You have been stripped of voting privileges~waccess_denied.wav");
 }
 else if(%opt == "vctourney") 
{
 if(!%clientId.Nvote) Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
 else Client::sendMessage(%clientId,0,"You have been stripped of voting privileges~waccess_denied.wav");
 }
 else if(%opt == "cffa") Admin::setModeFFA(%clientId);
 else if(%opt == "ctourney") Admin::setModeTourney(%clientId);
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
 else if (%opt == "admin") 
{
 Client::buildMenu(%clientId, "Admin: " @ Client::getName(%cl), "aaffirm", true);
 Client::addMenuItem(%clientId, "1Make Admin", "yes " @ %cl);
 if(%clientId.isGod) 
{
 Client::addMenuItem(%clientId, "2Make SuperAdmin", "yesS " @ %cl);
 Client::addMenuItem(%clientId, "3Don't Make Admin", "no " @ %cl);
 }
 else Client::addMenuItem(%clientId, "2Don't Make Admin", "no " @ %cl);
 return;
 }
 else if (%opt == "PList") 
{
 Client::buildMenu(%clientId, "Punish " @ Client::getName(%cl), "Punishment", true);
 if(%clientId.isSuperAdmin) 
{
 if (%cl.shut) Client::addMenuItem(%clientId, "1**Re-Tongue ", "RT " @ %cl);
 else Client::addMenuItem(%clientId, "1De-Tongue ", "DT " @ %cl);
 if (%cl.freeze) Client::addMenuItem(%clientId, "2**Defrost ", "unfrze " @ %cl);
 else Client::addMenuItem(%clientId, "2Freeze ", "frze " @ %cl);
 Client::addMenuItem(%clientId, "3Blow Up ", "Blowupp " @ %cl);
 Client::addMenuItem(%clientId, "4Boot to the rear ", "assBoot " @ %cl);
 Client::addMenuItem(%clientId, "5Slap ", "Slap " @ %cl);
 if(%cl.Nvote) Client::addMenuItem(%clientId, "6**Return voting rights ", "Rvote " @ %cl);
 else Client::addMenuItem(%clientId, "6Remove voting rights ", "Nvote " @ %cl);
 if(%clientId.isGod) 
{
 Client::addMenuItem(%clientId, "7Double Trouble ", "Dtrouble " @ %cl);
 Client::addMenuItem(%clientId, "8Back to Main Menu ", "Nothing ");
 }
 else Client::addMenuItem(%clientId, "7Back to Main Menu ", "Nothing ");
 }
 else if(%clientId.isAdmin && !%clientId.isSuperAdmin) 
{
 %curItem = 0;
 if($Reneg::PADetongue) 
{
 if (%cl.shut) Client::addMenuItem(%clientId, %curItem++ @ "**Re-Tongue ", "RT " @ %cl);
 else if(%cl != %clientId) Client::addMenuItem(%clientId, %curItem++ @ "De-Tongue ", "DT " @ %cl);
 }
 if($Reneg::PABlowUp && %cl != %clientId) Client::addMenuItem(%clientId, %curItem++ @ "Blow Up ", "Blowupp " @ %cl);
 if($Reneg::PAStripVoteRights) 
{
 if(%cl.Nvote && !%cl.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "**Return voting rights ", "Rvote " @ %cl);
 else if(!%cl.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Remove voting rights ", "Nvote " @ %cl);
 }
 Client::addMenuItem(%clientId, %curItem++ @ "Back to Main Menu ", "Nothing ");
 }
 return;
 }
 else if(%opt == "ServInfo") 
{
 if($Reneg::OutOfAreaDamage) %ad = "On";
 else %ad = "Off";
 if($Reneg::StationTime) %st = $Reneg::StationTime @ " sec";
 else %st = "Off";
 if($Server::TeamDamageScale > 0) %td = "On";
 else %td = "Off";
 if($Reneg::fairTeams = "true") %ft = "On";
 else %ft = "Off";
 if(($Server::TeamDamageScale > 0 && $StationLockNTD) || ($Server::TeamDamageScale == 0 && $StationLockTD)) %sl = "On";
 else %sl = "Off";
 Client::buildMenu(%clientId, "Server Information:", "resetMenu", true);
 Client::addMenuItem(%clientId, "1Owner: " @ $Owner::Name, "Rset");
 Client::addMenuItem(%clientId, "2OutofAreaDamage: " @ %ad, "Rset");
 Client::addMenuItem(%clientId, "3Team Damage: " @ %td, "Rset");
 Client::addMenuItem(%clientId, "4Station Kick Time: " @ %st, "Rset");
 Client::addMenuItem(%clientId, "5Station Lock: " @ %sl, "Rset");
 return;
 }
 else if(%opt == "ban") 
{
 Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
 Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
 Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
 return;
 }
 else if(%opt == "smatch") Admin::startMatch(%clientId);
 else if(%opt == "vcmission" || %opt == "cmission") 
{
 if(!%clientId.Nvote) 
{
 Admin::changeMissionMenu(%clientId, %opt == "cmission");
 return;
 }
 else Client::sendMessage(%clientId,0,"You have been stripped of voting privileges~waccess_denied.wav");
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
 else if(%opt == "Renegades") 
{
 Client::buildMenu(%clientId, "Server Options:", "ixsettings", true);
 Client::addMenuItem(%clientId, "1Change Server Anti-TK Lvl", "tkserv " @ $Reneg::tkServerLvl);
 Client::addMenuItem(%clientId, "2Change Client Anti-TK Lvl", "tkclient " @ $Reneg::tkClientLvl);
 if(%clientId.isSuperAdmin || ($Reneg::PAResetDefaults && %clientId.isAdmin && !%clientId.isSuperAdmin)) Client::addMenuItem(%clientId, "3Reset Server Defaults", "reset");
 if(%clientId.isSuperAdmin || ($Reneg::PAareaDamage && !%clientId.isSuperAdmin && %clientId.isAdmin)) 
{
 if($Reneg::OutOfAreaDamage) Client::addMenuItem(%clientId, "4Disable OutofAreaDamage", "OoADoff");
 else Client::addMenuItem(%clientId, "4Enable OutofAreaDamage", "OoADon");
 }
 if(%clientId.isSuperAdmin) 
{
 Client::addMenuItem(%clientId, "5Public changes", "PubMenu");
 Client::addMenuItem(%clientId, "6Fair Teams", "fairvote " @ $Reneg::fairTeams);
 }
 return;
 }
 else if(%opt == "tkopt") 
{
 if($Reneg::tkClientLvl == 1) Admin::Kick(-3, Insomniax_getKiller(%clientId));
 else 
{
 %cl.voteTarget = true;
 %clientId.selClient = Insomniax_getKiller(%clientId);
 Admin::startVote(%clientId, "Kick Team Killer " @ Client::getName(%cl), "tkkick", %cl);
 }
 }
 Game::menuRequest(%clientId);
 }
 function processMenuarmorchange(%clientId, %opt) 
{
 if (%opt == "changeclass") 
{
 Client::buildMenu(%clientId, "Pick a Armor:", "armorchange", true);
 Client::addMenuItem(%clientId, "0Scout", 0);
 Client::addMenuItem(%clientId, "1Spy", 1);
 Client::addMenuItem(%clientId, "2Sniper", 2);
 Client::addMenuItem(%clientId, "3Mercenary", 3);
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
 if (%opt == 0) %clientID.spawnarmor = ScoutArmor;
 else if (%opt == 1) %clientID.spawnarmor = SpArmor;
 else if (%opt == 2) %clientID.spawnarmor = LightArmor;
 else if (%opt == 3) %clientID.spawnarmor = MediumArmor;
 else if (%opt == 4) %clientID.spawnarmor = BursterArmor;
 else if (%opt == 5) %clientID.spawnarmor = EngArmor;
 else if (%opt == 6) %clientID.spawnarmor = AlArmor;
 else if (%opt == 7) %clientID.spawnarmor = DragArmor;
 else if (%opt == 8) %clientID.spawnarmor = HeavyArmor;
 else %clientID.spawnarmor = ScoutArmor;
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
 if($ExportAdminPun) export("Admin","config\\AdminPunish.log",true);
 $Admin = "";
 }
 function processMenuPunishment(%clientId, %opt) 
{
 %option = getWord(%opt, 0);
 %cl = getWord(%opt, 1);
 if(!RenPort::punishAllowed(%clientId, %option, %cl)) { Game::menuRequest(%clientId); return; }	// PORT
 if(%cl.isbeingkicked) 
{
 Client::sendMessage(%clientId, 1, "No punishments while a player is in the process of being kicked~waccess_denied.wav");
 Game::menuRequest(%clientId);
 return;
 }
 if(%option == "DT") 
{
 if(!%cl.isSuperAdmin || (%cl.isSuperAdmin && !%cl.isGod && %clientId.isGod)) 
{
 %cl.shut = true;
 MessageAllExcept(%cl, 1, Client::getName(%cl) @ " got his tongue removed by " @ Client::getName(%clientId) @ ".~wmale3.wdsgst4.wav");
 Client::sendMessage(%cl, 1, "You just got your tongue removed by " @ Client::getName(%clientId) @ " for running your trap.~wmale3.wdsgst4.wav");
 %message = Client::getName(%clientId) @ " *** DE-TONGUED *** " @ Client::getName(%cl);
 echo(%message);
 adminLogging(%message);
 }
 else if(%cl.isSuperAdmin && !%cl.isGod && !%clientId.isGod) Client::sendMessage(%clientId, 1, "You can't de-tongue a superadmin~waccess_denied.wav");
 else if(%cl.isGod && !%clientId.isGod) 
{
 Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " tried to de-tongue you.~waccess_denied.wav");
 Client::sendMessage(%clientId, 1, "Somehow, you managed to remove your own tongue.~waccess_denied.wav");
 %clientId.shut = true;
 }
 }
 else if(%option == "RT") 
{
 %cl.shut = false;
 MessageAllExcept(%cl, 1, Client::getName(%cl) @ "'s tongue has been replaced by " @ Client::getName(%clientId) @ ".");
 Client::sendMessage(%cl, 1, "Your tongue has been reinserted by " @ Client::getName(%clientId) @ ".  Use it properly this time.~waccess_denied.wav");
 }
 else if(%option == "frze") 
{
 if(Player::isExposed(%cl)) 
{
 if($matchStarted) 
{
 if(!%cl.isSuperAdmin || (%cl.isSuperAdmin && !%cl.isGod && %clientId.isGod)) 
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
 else if(%cl.isSuperAdmin && !%cl.isGod && !%clientId.isGod) Client::sendMessage(%clientId, 1, "You can't freeze a superadmin~waccess_denied.wav");
 else if(%cl.isGod && !%clientId.isGod) 
{
 Client::sendMessage(%clientId, 1, "Have you lost your mind?~waccess_denied.wav");
 Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " tried to freeze you.~waccess_denied.wav");
 if(Player::isExposed(%clientId)) 
{
 leaveMountObject(%clientId);
 Client::sendMessage(%cl, 1, "They paid the price!!");
 %clientId.freeze = true;
 Client::setControlObject(%clientId, -1);
 }
 }
 }
 else Client::sendMessage(%clientId,1,"You can't freeze a player before the match");
 }
 else Client::sendMessage(%clientId, 1, "You can't freeze a player who is dead or in observer mode");
 }
 else if(%option == "unfrze") 
{
 MessageAllExcept(%cl, 1, Client::getName(%cl) @ " is being defrosted by " @ Client::getName(%clientId) @ ".~waccess_denied.wav");
 Client::sendMessage(%cl, 1, "You have just been defrosted by " @ Client::getName(%clientId) @ ".  Be nice.~waccess_denied.wav");
 %cl.freeze = false;
 Client::setControlObject(%cl, Client::getOwnedObject(%cl));
 }
 else if(%option == "Blowupp") 
{
 if(Player::isExposed(%cl)) 
{
 if($matchStarted) 
{
 if(!%cl.isSuperAdmin || (%cl.isSuperAdmin && !%cl.isGod && %clientId.isGod)) 
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
 else if(%cl.isSuperAdmin && !%cl.isGod && !%clientId.isGod) Client::sendMessage(%clientId, 1, "You can't blow-up a superadmin~waccess_denied.wav");
 else if(%cl.isGod && !%clientId.isGod) 
{
 Client::sendMessage(%clientId, 1, "How dare you try that to the owner");
 Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " tried to blow you up.~waccess_denied.wav");
 if(Player::isExposed(%clientId)) 
{
 leaveMountObject(%clientId);
 Client::sendMessage(%cl, 1,"They paid the price!!");
 playNextAnim(%clientId);
 Player::blowUp(%clientId);
 Player::kill(%clientId);
 Client::onKilled(%clientId, %clientId);
 }
 }
 }
 else Client::sendMessage(%clientId, 1 , "Can't blow-up a player before the match");
 }
 else Client::sendMessage(%clientId, 1 , "Can't blow-up a player who is dead or in observer");
 }
 else if(%option == "Nvote") 
{
 if(!%cl.isSuperAdmin) 
{
 Client::sendMessage(%cl, 1, "Your voting privileges have been taken by the admin " @ Client::getName(%clientId) @ "~waccess_denied.wav");
 MessageAllExcept(%cl, 1, Client::getName(%cl) @ " just got their voting privileges taken by " @ Client::getName(%clientId) @ ".~waccess_denied.wav");
 %message = Client::getName(%clientId) @ " ***Stripped Voting from*** " @ Client::getName(%cl);
 echo(%message);
 adminLogging(%message);
 %cl.Nvote = true;
 }
 }
 else if(%option == "Rvote") 
{
 Client::sendMessage(%cl, 1, "Your voting privileges have been restored by " @ Client::getName(%clientId));
 %cl.Nvote = "";
 }
 else if(%option == "assBoot") 
{
 if(Player::isExposed(%cl)) 
{
 if($matchStarted) 
{
 if(!%cl.isSuperAdmin || (%cl.isSuperAdmin && !%cl.isGod && %clientId.isGod)) 
{
 MessageAll(1,Client::getName(%clientId) @ " just gave " @ Client::getName(%cl) @ " a boot to the rear~waccess_denied.wav");
 leaveMountObject(%cl);
 Player::dropItem(%cl,Player::getMountedItem(%cl,$WeaponSlot));
 Player::applyImpulse(%cl,0 @ " " @ 0 @ " " @ 1500);
 playSound(SoundFlyerMount, GameBase::getPosition(%cl));
 %message = Client::getName(%clientId) @ " ***Booted the rear of*** " @ Client::getName(%cl);
 echo(%message);
 adminLogging(%message);
 }
 else if(%cl.isSuperAdmin && !%cl.isGod && !%clientId.isGod) Client::sendMessage(%clientId, 1, "You can't do that to a superadmin~waccess_denied.wav");
 else if(%cl.isGod && !%clientId.isGod) 
{
 Client::sendMessage(%clientId, 1, "Are you stupid or something?~waccess_denied.wav");
 Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " tried to boot your rear.~waccess_denied.wav");
 if(Player::isExposed(%clientId)) 
{
 leaveMountObject(%clientId);
 Client::sendMessage(%cl, 1,"He paid the price too!");
 playNextAnim(%clientId);
 Player::blowUp(%clientId);
 Player::kill(%clientId);
 Client::onKilled(%clientId, %clientId);
 }
 }
 }
 else Client::sendMessage(%clientId, 1 , "Can't a boot player before the match");
 }
 else Client::sendMessage(%clientId, 1 , "Can't a boot player who is dead or in observer");
 }
 else if(%option == "Slap") 
{
 if(Player::isExposed(%cl) && $matchStarted) 
{
 if(!%cl.isSuperAdmin || (%cl.isSuperAdmin && !%cl.isGod && %clientId.isGod)) 
{
 MessageAll(1,Client::getName(%clientId) @ " just slapped the crap out of " @ Client::getName(%cl) @ " ~waccess_denied.wav");
 leaveMountObject(%cl);
 Player::setDamageFlash(%cl, 0.5);
 Player::dropItem(%cl,Player::getMountedItem(%cl,$WeaponSlot));
 itemToss(%cl);
 %message = Client::getName(%clientId) @ " ***Slapped*** " @ Client::getName(%cl);
 echo(%message);
 adminLogging(%message);
 }
 else if(%cl.isSuperAdmin && !%cl.isGod && !%clientId.isGod) 
{
 Client::sendMessage(%clientId, 1, "You can't slap a superadmin~waccess_denied.wav");
 Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " tried to slap you~waccess_denied.wav");
 }
 else if(%cl.isGod && !%clientId.isGod) 
{
 Client::sendMessage(%clientId, 1, "Have you lost your mind?~waccess_denied.wav");
 Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " tried to slap you.~waccess_denied.wav");
 if(Player::isExposed(%clientId)) 
{
 leaveMountObject(%clientId);
 Client::sendMessage(%cl, 1,"They paid the price!!");
 playNextAnim(%clientId);
 Player::blowUp(%clientId);
 Player::kill(%clientId);
 Client::onKilled(%clientId, %clientId);
 }
 }
 }
 else Client::sendMessage(%clientId, 1, "You must wait for the player to spawn, or the match to start");
 }
 else if(%option == "Dtrouble") 
{
 if(Player::isExposed(%cl) && $matchStarted) 
{
 if(!%cl.isGod) 
{
 MessageAll(1,Client::getName(%cl) @ " just got knocked around by the admin god " @ Client::getName(%clientId) @ " ~waccess_denied.wav");
 leaveMountObject(%cl);
 Player::setDamageFlash(%cl, 0.75);
 %armor = Player::getArmor(%cl);
 if(%armor == "darmor" || %armor == "harmor") Player::applyImpulse(%cl,0 @ " " @ 0 @ " " @ 600);
 else if(%armor.shapeFile == "marmor" || %armor.shapeFile == "mfemale") Player::applyImpulse(%cl,0 @ " " @ 0 @ " " @ 425);
 else Player::applyImpulse(%cl,0 @ " " @ 0 @ " " @ 250);
 Player::dropItem(%cl,Player::getMountedItem(%cl,$WeaponSlot));
 schedule("Player::applyImpulse(" @ %cl @ ", \"" @ Vector::getFromRot(GameBase::getRotation(%cl),-300,0) @ "\");", 0.6);
 schedule("itemToss(" @ %cl @ ");",1.1);
 schedule("Player::applyImpulse(" @ %cl @ ", \"" @ 0 @ " " @ 0 @ " " @ -800 @ "\");", 1.8);
 %message = Client::getName(%clientId) @ " ***DoubleTroubled*** " @ Client::getName(%cl);
 echo(%message);
 adminLogging(%message);
 }
 }
 else Client::sendMessage(%clientId, 1, "You must wait for the player to spawn, or the match to start");
 }
 Game::menuRequest(%clientId);
 }
 function leaveMountObject(%client) 
{
 if(Player::getMountObject(%client) != -1 || Client::getControlObject(%client) != Client::getOwnedObject(%client)) 
{
 if(Player::getMountObject(%client) != -1) 
{
 Player::setMountObject(Client::getOwnedObject(%client), -1, 0);
 Client::setControlObject(%client, Client::getOwnedObject(%client));
 }
 else checkControlUnmount(%client);
 }
 }
 function itemToss(%cl) 
{
 %player = Client::getOwnedObject(%cl);
 for(%i = 0; %i < getNumItems(); %i = %i + 1) 
{
 %items = getItemData(%i);
 %num = Player::getItemCount(%cl,%items);
 if(%num) 
{
 %rot = GameBase::getRotation(%player);
 %rot2 = getWord(GameBase::getRotation(%player),0) @ " " @ getWord(GameBase::getRotation(%player),1);
 if(floor(getRandom() * 7) > 3) %turn = getRandom() * 3;
 else %turn = getRandom() * -3;
 GameBase::setRotation(%cl,%rot2 @ " " @ %turn);
 Player::dropItem(%cl,%items);
 }
 }
 }
 function processMenuKAffirm(%clientId, %opt) 
{
 if(getWord(%opt, 0) == "yes" && getWord(%opt, 1).isbeingkicked == false) Admin::kick(%clientId, getWord(%opt, 1));
 Game::menuRequest(%clientId);
 }
 function processMenuAAffirm(%clientId, %opt) 
{
 if(!%clientId.isSuperAdmin) return;	// PORT: no test at all -- any player could make anyone Admin / Super Admin
 if(getWord(%opt, 0) == "yesS" && !%clientId.isGod) return;	// PORT: the menu lists Make SuperAdmin for the owner only
 if(getWord(%opt, 0) == "yes") 
{
 %cl = getWord(%opt, 1);
 %cl.isAdmin = true;
 Client::sendMessage(%cl,1,"You were given Admin Status by " @ Client::getName(%clientId) @ "; Please use good judgement.");
 Client::sendMessage(%clientId,1,"You gave Admin Status to " @ Client::getName(%cl) @ ".");
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
 Game::menuRequest(%clientId);
 }
 function processMenuBAffirm(%clientId, %opt) 
{
 if(getWord(%opt, 0) == "yes") Admin::kick(%clientId, getWord(%opt, 1), true);
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
 function processMenuIXSettings(%clientId, %option) 
{
 %opt = getWord(%option, 0);
 %cl = getWord(%option, 1);
 if(!RenPort::settingAllowed(%clientId, %opt)) return;	// PORT: no admin test
 if(%opt == "PubMenu") 
{
 Client::buildMenu(%clientId, "Public Options:", "ixsettings", true);
 Client::addMenuItem(%clientId, "1Public Admin Voting", "adminvote " @ $Reneg::PAVote);
 Client::addMenuItem(%clientId, "2Public Mission Change Voting", "changevote " @ $Reneg::PAMission );
 Client::addMenuItem(%clientId, "3Public Kick Voting", "kickvote " @ $Reneg::PAKick );
 Client::addMenuItem(%clientId, "4Public Admin Lockouts", "palockout");
 Client::addMenuItem(%clientId, "5Purge Public Admins", "purge " @ %clientId);
 return;
 }
 if(%opt == "patoggle") 
{
 Client::sendMessage(%clientId, 3, "Public Admin Vote is now " @ isonoff(%cl) @ ".");
 $Reneg::PAVote = %cl;
 }
 if(%opt == "cmtoggle") 
{
 Client::sendMessage(%clientId, 3, "Public Mission Vote is now " @ isonoff(%cl) @ ".");
 $Reneg::PAMission = %cl;
 }
 if(%opt == "pktoggle") 
{
 Client::sendMessage(%clientId, 3, "Public Kick Vote is now " @ isonoff(%cl) @ ".");
 $Reneg::PAKick = %cl;
 }
 if(%opt == "fairtoggle") 
{
 Client::sendMessage(%clientId, 3, "Fair Teams is now " @ isonoff(%cl) @ ".");
 $Reneg::fairTeams = %cl;
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
 else if(%opt == "reset") 
{
 Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
 Client::addMenuItem(%clientId, "1Reset", "yes");
 Client::addMenuItem(%clientId, "2Don't Reset", "no");
 return;
 }
 else if(%opt == "OoADoff") 
{
 messageAll(1,Client::getName(%clientId) @ " disabled Out of Area Damage");
 $Reneg::OutOfAreaDamage = "";
 return;
 }
 else if(%opt == "OoADon") 
{
 messageAll(1,Client::getName(%clientId) @ " enabled Out of Area Damage");
 $Reneg::OutOfAreaDamage = true;
 return;
 }
 else if(%opt == "tkclient") 
{
 Client::buildMenu(%clientId, "Current Client Anti-TK: " @ %cl, "ClientLvl", true);
 Client::addMenuItem(%clientId, "0Client Vote Option", 0);
 Client::addMenuItem(%clientId, "1Client Kick Option", 1);
 return;
 }
 else if(%opt == "palockout") 
{
 Client::buildMenu(%clientId, "Current Public Admin Lockouts:","PALockouts", true);
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
 else if(%opt == "adminvote") 
{
 Client::buildMenu(%clientId, "Public Admin Vote is " @ isonoff(%cl), "ixsettings", true);
 Client::addMenuItem(%clientId, "0Turn OFF Public Admin", "patoggle false");
 Client::addMenuItem(%clientId, "1Turn ON Public Admin", "patoggle true");
 return;
 }
 else if(%opt == "changevote") 
{
 Client::buildMenu(%clientId, "Public Mission Change Vote is " @ isonoff(%cl), "ixsettings", true);
 Client::addMenuItem(%clientId, "0Turn OFF Mission Change", "cmtoggle false");
 Client::addMenuItem(%clientId, "1Turn ON Mission Change", "cmtoggle true");
 return;
 }
 else if(%opt == "kickvote") 
{
 Client::buildMenu(%clientId, "Public Kick Vote is " @ isonoff(%cl), "ixsettings", true);
 Client::addMenuItem(%clientId, "0Turn OFF Public Kick", "pktoggle false");
 Client::addMenuItem(%clientId, "1Turn ON Public Kick", "pktoggle true");
 return;
 }
 else if(%opt == "fairvote") 
{
 Client::buildMenu(%clientId, "Fair Teams is " @ isonoff(%cl), "ixsettings", true);
 Client::addMenuItem(%clientId, "0Turn OFF Fair Teams", "fairtoggle false");
 Client::addMenuItem(%clientId, "1Turn ON Fair Teams", "fairtoggle true");
 return;
 }
 else if(%opt == "purge") 
{
 Client::sendMessage(%cl,3,"Purging All Public Admins of Admin Status.");
 Insomniax_clearPA(%cl);
 Client::sendMessage(%cl,3,"Purging Complete.");
 return;
 }
 }
 function processMenuPALockouts(%clientId, %option) 
{
 %opt = getWord(%option, 0);
 %toggle = getWord(%option, 1);
 if(!%clientId.isSuperAdmin) return;	// PORT: no admin test
 if(%opt == "additional") 
{
 Client::buildMenu(%clientId, "Current Public Admin Lockouts:","PALockouts", true);
 Client::addMenuItem(%clientId, "1Server Defaults " @ isonoff($Reneg::PAResetDefaults), "reset " @ $Reneg::PAResetDefaults);
 Client::addMenuItem(%clientId, "2Server Options " @ isonoff($Reneg::PAModOptions), "modopt " @ $Reneg::PAModOptions);
 Client::addMenuItem(%clientId, "3Set Team Info " @ isonoff($Reneg::PATeamInfo), "teaminfo " @ $Reneg::PATeamInfo);
 Client::addMenuItem(%clientId, "4Turn ON all Options", "allon");
 return;
 }
 else if(%opt == "allon") 
{
 %access = "All Options";
 %toggle = "false";
 $Reneg::PATeamChange = "true";
 $Reneg::PAKick = "true";
 $Reneg::PABan = "true";
 $Reneg::PAMission = "true";
 $Reneg::PATeamDamage = "true";
 $Reneg::PATourneyMode = "true";
 $Reneg::PATimeLimit = "true";
 $Reneg::PAResetDefaults = "true";
 $Reneg::PAModOptions = "true";
 }
 else if(%opt == "teamchange") 
{
 %access = "Team Changing";
 if(%toggle) $Reneg::PATeamChange = "false";
 else $Reneg::PATeamChange = "true";
 }
 else if(%opt == "kick") 
{
 %access = "Kicking";
 if(%toggle) $Reneg::PAKick = "false";
 else $Reneg::PAKick = "true";
 }
 else if(%opt == "ban") 
{
 %access = "Banning";
 if(%toggle) $Reneg::PABan = "false";
 else $Reneg::PABan = "true";
 }
 else if(%opt == "mission") 
{
 %access = "Changing Mission";
 if(%toggle) $Reneg::PAMission = "false";
 else $Reneg::PAMission = "true";
 }
 else if(%opt == "teamdamage") 
{
 %access = "Team Damage";
 if(%toggle) $Reneg::PATeamDamage = "false";
 else $Reneg::PATeamDamage = "true";
 }
 else if(%opt == "tourney") 
{
 %access = "Tourney Mode";
 if(%toggle) $Reneg::PATourneyMode = "false";
 else $Reneg::PATourneyMode = "true";
 }
 else if(%opt == "timelimit") 
{
 %access = "Mission Time Limit";
 if(%toggle) $Reneg::PATimeLimit = "false";
 else $Reneg::PATimeLimit = "true";
 }
 else if(%opt == "reset") 
{
 %access = "Reseting Sever to Defaults";
 if(%toggle) $Reneg::PAResetDefaults = "false";
 else $Reneg::PAResetDefaults = "true";
 }
 else if(%opt == "modopt") 
{
 %access = "Renegades Mod Options";
 if(%toggle) $Reneg::PAModOptions = "false";
 else $Reneg::PAModOptions = "true";
 }
 else if(%opt == "teaminfo") 
{
 %access = "Setting Team Info";
 if(%toggle) $Reneg::PATeamInfo = "false";
 else $Reneg::PATeamInfo = "true";
 }
 if(%toggle) %toggle = "false";
 else %toggle = "true";
 Client::sendMessage(%clientId, 3, "Public Admin Access to " @ %access @ " is now " @ isonoff(%toggle) @ ".");
 }
 function isonoff(%toggle) 
{
 if(%toggle) return "On";
 else return "Off";
 }
 function processMenuServerLvl(%clientId, %option) 
{
 if(!RenPort::settingAllowed(%clientId, "tkserv")) return;	// PORT: no admin test
 $Reneg::tkServerLvl = %option;
 if(%option == 0) messageAll(0, "SERVER:TK Protection Level Set to Zero. (Logging TK's only).");
 if(%option == 1) messageAll(0, "SERVER:TK Protection Level Set to One. (Auto Vote).");
 if(%option == 2) messageAll(0, "SERVER:TK Protection Level Set to Two. (Auto Vote Until Kicked).");
 if(%option == 3) messageAll(0, "SERVER:TK Protection Level Set to Three. (Auto Kick).");
 }
 function processMenuClientLvl(%clientId, %option) 
{
 if(!RenPort::settingAllowed(%clientId, "tkclient")) return;	// PORT: no admin test
 $Reneg::tkClientLvl = %option;
 if(%option == 0) messageAll(0, "SERVER: Client TK Vote Option Engaged. (From Options Menu).");
 if(%option == 1) messageAll(0, "SERVER: Client TK Kick Option Engaged. (From Options Menu).");
 }
 function Insomniax_ServerLvlTxt() 
{
 if($Reneg::tkServerLvl == 0) %tkText = "Only Logging TK's";
 else if($Reneg::tkServerLvl == 1) %tkText = "Votes at " @ $Reneg::tkLimit @ " TK's";
 else if($Reneg::tkServerLvl == 2) %tkText = "Votes at " @ $Reneg::tkLimit @ " TKs and Kicks at " @ $Reneg::tkLimit * $Reneg::tkMultiple @ " TK's";
 else if($Reneg::tkServerLvl == 3) %tkText = "Kicks at " @ $Reneg::tkLimit @ " TK's";
 else %tkText = "ERROR: Server Level set to Unkown Level";
 return %tkText;
 }
 function Insomniax_ClientLvlTxt() 
{
 if($Reneg::tkClientLvl == 0) %tkText = "Vote Option at " @ $Reneg::tkLimit @ " TK's";
 else if($Reneg::tkClientLvl == 1) %tkText = "Kick Option at " @ $Reneg::tkLimit @ "TK's";
 else %tkText = "ERROR: Client Level set to Unkown Level";
 return %tkText;
 }
 function Insomniax_setTeamKill(%victimId, %killerId) 
{
 $tkVictim[%killerId] = %victimId;
 $tkKiller[%victimId] = %killerId;
 $tkKills[%killerId] += 1;
 %trigger = $tkKills[%killerId] % $Reneg::tkLimit;
 %tkTopKills = $Reneg::tkLimit * $Reneg::tkMultiple;
 if(($tkKills[%killerId] >= $Reneg::tkLimit) && (!%trigger)) 
{
 if($Reneg::tkServerLvl) 
{
 if($Reneg::tkServerLvl != 3) 
{
 if(($tkKills[%killerId] >= %tkTopKills) && ($Reneg::tkServerLvl != 1)) 
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
 function Insomniax_getVictim(%clientId) 
{
 return $tkVictim[%clientId];
 }
 function Insomniax_leaveGame(%clientId) 
{
 if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId];
 if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId];
 $tkKiller[%clientId] = %clientId;
 $tkVictim[%clientId] = %clientId;
 $tkKills[%clientId] = 0;
 $empTime[%clientId] = 0;
 return;
 }
 function Insomniax_joinGame(%clientId) 
{
 if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId];
 if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId)) $tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId];
 $tkVictim[%clientId] = %clientId;
 $tkKiller[%clientId] = %clientId;
 $tkKills[%clientId] = 0;
 $empTime[%clientId] = 0;
 }
 function Insomniax_clearPA(%admin) 
{
 if(%admin.isSuperAdmin) 
{
 %numPlayers = getNumClients();
 for(%i = 0; %i < %numPlayers; %i++) 
{
 %pl = getClientByIndex(%i);
 if(!%pl.isSuperAdmin && %pl.isAdmin) 
{
 %pl.isAdmin = false;
 Client::sendMessage(%pl,1,"Your Admin Status has been revoked by the Super Admin.");
 Client::sendMessage(%admin,3,"Public Admin Status Stripped from: " @ Client::getName(%pl) @ ".");
 }
 }
 }
 }
 function ixwhoison() 
{
 echo(" # cl: CLIENT nm: NAME ip: ADDRESS");
 %numPlayers = getNumClients();
 for(%i = 0; %i < %numPlayers; %i++) 
{
 %pl = getClientByIndex(%i);
 %name = Client::getName(%pl);
 %ip = Client::getTransportAddress(%pl);
 echo(" " @ %i @ " cl: " @ %pl @ " nm: " @ %name @ " ip: " @ %ip);
 }
 }

//====================================================================================================
// PORT (Modern Tribes 1.50). Menu codes are sent by the client: the Tab menu only LISTS what a player
// may do, and these handlers ran whatever arrived. In the original ANY player could send
// "admin <own id>" and then "yesS <own id>" and be a Super Admin, strip admins, freeze / blow up
// players, switch the anti-TK levels and every Public Admin lockout. (Renegades 1.1c closed the same
// holes with CheckAdminCond; this fork predates it.) The tests below are the ones the menus use.
//====================================================================================================
function RenPort::paOr(%clientId, %flag)
{
	if(%clientId.isSuperAdmin)
		return 1;
	if(%clientId.isAdmin && %flag)
		return 1;
	return 0;
}

function RenPort::optAllowed(%clientId, %opt, %cl)
{
	if(%opt == "strip")
	{
		if(%clientId.isSuperAdmin && %clientId.isGod)
			return 1;
		return 0;
	}
	if(%opt == "admin")
	{
		if(%clientId.isSuperAdmin)
			return 1;
		return 0;
	}
	if(%opt == "PList")
	{
		if(%clientId.isAdmin)
			return 1;
		return 0;
	}
	if(%opt == "kick")
		return RenPort::paOr(%clientId, $Reneg::PAKick);
	if(%opt == "ban")
		return RenPort::paOr(%clientId, $Reneg::PABan);
	if(%opt == "fteamchange")
		return RenPort::paOr(%clientId, $Reneg::PATeamChange);
	if(%opt == "etd" || %opt == "dtd")
		return RenPort::paOr(%clientId, $Reneg::PATeamDamage);
	if(%opt == "cffa" || %opt == "ctourney" || %opt == "smatch")
		return RenPort::paOr(%clientId, $Reneg::PATourneyMode);
	if(%opt == "ctimelimit")
		return RenPort::paOr(%clientId, $Reneg::PATimeLimit);
	if(%opt == "Renegades")
		return RenPort::paOr(%clientId, $Reneg::PAModOptions);
	if(%opt == "cmission" || %opt == "vcmission")
	{
		if(%clientId.isSuperAdmin || $Reneg::PAMission)
			return 1;
		return 0;
	}
	if(%opt == "vadmin")
	{
		if($Reneg::PAVote && !%clientId.isAdmin)
			return 1;
		return 0;
	}
	if(%opt == "vkick")
	{
		if($Reneg::PAKick)
			return 1;
		return 0;
	}
	// "Kick Team Killer": only the victim of a player who is over the TK limit, and only that player
	if(%opt == "tkopt")
	{
		%k = Insomniax_getKiller(%clientId);
		if(%k == %clientId || %k == "" || %cl != %k)
			return 0;
		if($tkKills[%k] >= $Reneg::tkLimit)
			return 1;
		return 0;
	}
	return 1;
}

function RenPort::punishAllowed(%clientId, %option, %cl)
{
	if(!%clientId.isAdmin)
		return 0;
	// %cl is pasted into schedule() strings further down
	if(String::findSubStr(%cl, ";") != -1 || String::findSubStr(%cl, "(") != -1 || String::findSubStr(%cl, ")") != -1 || String::findSubStr(%cl, ",") != -1)
		return 0;
	if(%option == "Dtrouble")
	{
		if(%clientId.isSuperAdmin && %clientId.isGod)
			return 1;
		return 0;
	}
	if(%clientId.isSuperAdmin)
		return 1;
	if(%option == "DT" || %option == "RT")
	{
		if($Reneg::PADetongue)
			return 1;
		return 0;
	}
	if(%option == "Blowupp")
	{
		if($Reneg::PABlowUp)
			return 1;
		return 0;
	}
	if(%option == "Nvote" || %option == "Rvote")
	{
		if($Reneg::PAStripVoteRights)
			return 1;
		return 0;
	}
	if(%option == "Nothing")
		return 1;
	return 0;
}

function RenPort::settingAllowed(%clientId, %opt)
{
	if(%clientId.isSuperAdmin)
		return 1;
	if(!%clientId.isAdmin || !$Reneg::PAModOptions)
		return 0;
	// what the "Server Options" menu lists for a public admin
	if(%opt == "tkserv" || %opt == "tkclient")
		return 1;
	if(%opt == "reset")
	{
		if($Reneg::PAResetDefaults)
			return 1;
		return 0;
	}
	if(%opt == "OoADoff" || %opt == "OoADon")
	{
		if($Reneg::PAareaDamage)
			return 1;
		return 0;
	}
	return 0;
}

// The "Spawn Options" menu is built with the menu name "SpawnOptions", but its three codes are only
// handled inside processMenuOptions: picking one called a function that did not exist.
function processMenuSpawnOptions(%clientId, %opt)
{
	if(%opt == "spawnstan" || %opt == "spawnrand" || %opt == "spawnfavs")
		processMenuOptions(%clientId, %opt);
}

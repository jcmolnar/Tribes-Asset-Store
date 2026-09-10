
function createTrainingServer()
{
	$SinglePlayer = true;
	createServer($pref::lastTrainingMission, false);
}

function remoteSetCLInfo(%clientId, %skin, %name, %email, %tribe, %url, %info, %autowp, %enterInv, %msgMask)
{
	$Client::info[%clientId, 0] = %skin;
	$Client::info[%clientId, 1] = %name;
	$Client::info[%clientId, 2] = %email;
	$Client::info[%clientId, 3] = %tribe;
	$Client::info[%clientId, 4] = %url;
	$Client::info[%clientId, 5] = %info;
	if(%autowp)
		%clientId.autoWaypoint = true;
	if(%enterInv)
		%clientId.noEnterInventory = true;
	if(%msgMask != "")
		%clientId.messageFilter = %msgMask;
}

function Server::storeData()
{
	$ServerDataFile = "serverTempData" @ $Server::Port @ ".cs";
	export("Server::*", "temp\\" @ $ServerDataFile, False);
	if (!$RandomMissions)
		export("pref::lastMission", "temp\\" @ $ServerDataFile, true);
	EvalSearchPath();
}

function Server::refreshData()
{
	exec($ServerDataFile);
	checkMasterTranslation();
	if ($RandomMissions)
		Server::loadMission(MissionList::nextRandom(), false);
	else
		Server::loadMission($pref::lastMission, false);
//	Server::nextMission(false);
}

function Server::onClientDisconnect(%clientId)
{
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{
		playNextAnim(%player);
		Player::kill(%player);
	}
	$shieldTime[%clientId] = 0;
	$cloakTime[%clientId] = 0;
	%player.driver = "";
	%clientId.spamSAD = "";
	%clientId.isbeingkicked = "";
	%clientId.freeze = "";
	Client::setControlObject(%clientId, -1);
	Client::leaveGame(%clientId);
	Game::CheckTourneyMatchStart();
	if(getNumClients() == 1)
	Server::refreshData();
}

function KickDaJackal(%clientId)
{
	Net::kick(%clientId, "The FBI has been notified.  You better buy a legit copy before they get to your house.");
}

function Server::onClientConnect(%clientId)
{
	%ip = Client::getTransportAddress(%clientId);
	if(!String::NCompare(%ip, "LOOPBACK", 8))
	{
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
		%clientId.isGod = true;
	}
	else
	{
		if($UserList::Activated == 1)
		IxAdmin_Authenticate(%clientId, ixPrepIp(%ip));
		if ($BanByName::IsOn == 1 && !%clientId.isAdmin && !%clientId.noKick)
		BanByName::kick(%clientId, %ip);
	}
	echo("CONNECT: " @ %clientId @ " \"" @ escapeString(Client::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));
	$CLog = Client::getName(%clientId) @ " " @ %ip;
	if($ConnectLog)
		export("CLog","config\\Connect.log",true);
	if(Client::getName(%clientId) == "DaJackal")
		schedule("KickDaJackal(" @ %clientId @ ");", 20, %clientId);
	// Server connect stats
	$Stats::ClientsConnected++;
	%clientId.num = $Stats::ClientsConnected;
	export("Stats::*", "config\\stats.cs", false);
	// End stats
	%clientId.noghost = true;
	%clientId.messageFilter = -1;
	remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
	remoteEval(%clientId, MODInfo, $MODInfo);
	remoteEval(%clientId, FileURL, $Server::FileURL);
	for(%i = 0; %i < 10; %i++)
	{
		$Client::info[%clientId, %i] = "";
	}
	$warning[%clientId] = 0;
	%clientId.custom = False;
	Game::onPlayerConnected(%clientId);
}

function BanByName::Init() { $BanByName::Count = 0; $BanByName::List[0,0] = ""; $BanByName::List[0,1] = 0; }
function BanByName::Add(%name, %type) { if (%name == "") return; if (!%type) %type = 0; %i = BanByName::Search(%name); if (%i == -1) { $BanByName::List[$BanByName::Count,0] = %name; $BanByName::List[$BanByName::Count,1] = %type; $BanByName::Count++; } }
function BanByName::List() { for (%i = 0; %i < $BanByName::Count; %i++) { echo($BanByName::List[%i,0] @ " " @ $BanByName::List[%i,1]); } }
function BanByName::Search(%name) { if (%name == "") return -1; for (%i = 0; %i <= $BanByName::Count; %i++) { if ($BanByName::List[%i, 1] == 0) { if ($BanByName::List[%i, 0] == %name) { return %i; } } else if ($BanByName::List[%i, 1] == 1) { %x = String::findSubStr(%name, $BanByName::List[%i, 0]); if (%x >= 0) return %i; } else { echo("BanByName::Search(" @ %name @ ") error: undefined %type: " @ $BanByName::List[%i, 1]); return -1; } } return -1; }
function BanByName::Kick(%clientId, %ip) { %name = Client::getName(%clientId); %i = BanByName::Search(%name); if(!%clientId.isAdmin && !%clientId.noKick) { if (%i >= 0) { if($ExportCKicks) { $NameBan = Client::getName(%clientId) @ " " @ %ip; export("NameBan", "config\\KickList.log", true); $NameBan = ""; } echo("BanByName::Kick(" @ %name @ ")"); BanList::add(%ip, 25); MessageAll(1,"Server: Auto-Kick: " @ Client::getName(%clientId)); schedule("Net::kick(" @ %clientId @ ");",1); } } }
function BanByName::Remove(%name) { %i = BanByName::Search(%name); if (%i >= 0) { for (%j = %i; %j < $BanByName::Count; %j++) { $BanByName::List[%j,0] = $BanByName::List[%j+1,0]; $BanByName::List[%j,1] = $BanByName::List[%j+1,1]; } $BanByName::Count--; } } BanByName::Init(); exec("BBNList.cs"); $IxAdminDebug = 0;
function IxAdmin_Authenticate(%clientId, %ip) { if ($IxAdminDebug) echo("IxAdmin_Authenticate"); if($UserList::Activated) { if ($IxAdminDebug) echo("UserList is activated."); %name = Client::getName(%clientId); if ($IxAdminDebug) echo("\%name = " @ %name); %user = ixGetUser(%name,%ip); if(%user) { if ($IxAdminDebug) echo("\%user = " @ %user); %username = $UserList::User[%user,1]; if ($IxAdminDebug) echo("\%username = " @ %username); %flags = $UserList::User[%user,3]; if ($IxAdminDebug) echo("\%flags = " @ %flags); $ixUserInfo[%clientId] = $UserList::User[%user]; echo("Admin: User: ",%username," identified. Access level: ",%flags); if(%flags == "AutoSuper") { %clientId.isAdmin = true; %clientId.isSuperAdmin = true; ixAdminMsg("SuperAdmin: " @ %username @ " automatically assigned."); if ($ExportAdmin) { $msg = "SuperAdmin: " @ %username @ " automatically assigned."; export("msg", "config\\AdminLog.log", true); } } else if(%flags == "God") { %clientId.isAdmin = true; %clientId.isSuperAdmin = true; %clientId.isGod = true; ixAdminMsg("GodAdmin: " @ %username @ " automatically assigned."); if ($ExportAdmin) { $msg = "GodAdmin: " @ %username @ " automatically assigned."; export("msg", "config\\AdminLog.log", true); } } else if(%flags == "AutoPublic") { %clientId.isAdmin = true; ixAdminMsg("PublicAdmin: " @ %username @ " automatically assigned."); if ($ExportAdmin) { $msg = "PublicAdmin: " @ %username @ " automatically assigned."; export("msg", "config\\AdminLog.log", true); } } else if(%flags == "NoKick") { %clientId.noKick = true; ixAdminMsg("SpecialStatus: " @ %username @ " automatically assigned."); if ($ExportAdmin) { $msg = "NoKick: " @ %username @ " automatically assigned."; export("msg", "config\\AdminLog.log", true); } } } else { echo("Admin: User: ",%name," Unknown."); $ixUserInfo[%clientId] = "0 " @ %name @ " None None " @ %ip; } } $msg = ""; }
function ixProcess(%client, %name, %user, %username, %flags, %password) { if ($IxAdminDebug) echo("ixProcess"); if(!%client.isAdmin) { %realpass = $UserList::User[%user,2]; if(!String::ICompare(%password, %realpass)) { if((%flags == "PublicAdmin") && (%name == %username)) { %client.isAdmin = true; } if((%flags == "SuperAdmin") && (%name == %username)) { %client.isAdmin = true; %client.isSuperAdmin = true; } ixAdminMsg(%username @ " Logged in."); } else { Client::sendMessage(%client, 0,"Server: Bad Password"); ixAdminMsg(%name @ " login attempt failed. Username: " @ %username); } } else { Client::sendMessage(%client, 0,"Server: You already have admin status."); } }
function ixAdminMsg(%msg) { if ($IxAdminDebug) echo("ixAdminMsg"); messageAll(1, %msg); }
function ixGetUser(%name,%ip) { if ($IxAdminDebug) echo("ixGetUser"); for(%i=1;%i <= $UserList::MaxUsers;%i++) { if ($IxAdminDebug) echo("\$UserList::User[\%i,1] = " @ $UserList::User[%i,1]); if(%name == $UserList::User[%i,1] || $UserList::User[%i,1] == "*") { for(%j=4;%j <= $UserList::MaxDataFields;%j++) { %mask = $UserList::User[%i,%j]; if(ixCompareIP(%ip,%mask)) return %i; } return 0; } } return 0; }
// ELITE RENEGADES PORT (R1): ixPrepIP returned the PORT for a dotless transport
// such as LOOPBACK:28000, and ixDotToSpace then called String::getSubStr(s, 0, -1)
// with a negative length three times. Both now fall back cleanly. Cold path as
// shipped ($UserList::Activated = 0), live the moment auto-admin is enabled.
function ixPrepIP(%transport) { if ($IxAdminDebug) echo("ixPrepIP: " @ %transport); %x = String::findSubStr(%transport, ":"); if (%x < 0) return "172.16.0.0"; %s = String::getSubStr(%transport, %x + 1, 10000); %x = String::findSubStr(%s, ":"); if (%x > 0) %s = String::getSubStr(%s, 0, %x); if (String::findSubStr(%s, ".") < 0) return "172.16.0.0"; if ($IxAdminDebug) echo(%s); return %s; }
function ixCompareIP(%ip, %mask) { if ($IxAdminDebug) echo("ixCompareIP"); %ipNow = ixDotToSpace(%ip); %maskNow = ixDotToSpace(%mask); if ($IxAdminDebug) echo("\%ipNow = " @ %ipNow @ " \%maskNow = " @ %maskNow); for(%x=0;%x<4;%x++) { %one = getWord(%ipNow, %x); %two = getWord(%maskNow, %x); if ($IxAdminDebug) echo("\%one = " @ %one @ ", \%two = " @ %two); if((%one != %two) && (%two != "*")) return "false"; } return "true"; }
function ixStrLen(%string) { if ($IxAdminDebug) echo("ixStrLen"); for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++) %length = %i; %length++; return %length; }
function ixDotToSpace(%string) { if ($IxAdminDebug) echo("ixDotToSpace: \%string = " @ %string); %s = ""; for (%i = 0; %i < 3; %i++) { %x = String::findSubStr(%string, "."); if (%x < 0) break; %t = String::getSubStr(%string, 0, %x) @ " "; %s = %s @ %t; %string = string::getSubStr(%string, %x+1, 10000); if ($IxAdminDebug) echo("\%x = " @ %x @ " \%t = " @ %t @ " \%s = " @ %s @ " \%string = " @ %string); } return %s @ %string; }

function createServer(%mission, %dedicated)
{
	// Randomize
	$RandomSeed = 0;
	exec("random.cs");
	for (%i = 0; %i < $RandomSeed; %i++) %j = getRandom();
	$RandomSeed = floor(getRandom() * 1000);
	export("RandomSeed", "config\\random.cs", False);
	exec("stats.cs");
	$Stats::ResetCount++;
	export("Stats::*", "config\\stats.cs", false);
	$Reneg::AutoRepair = "False";
	$Reneg::noDrop = "True";
	$loadingMission = false;
	if(%mission == "")
	{
		if ($RandomMissions)
			%mission = MissionList::nextRandom();
		else
			%mission = $pref::lastMission;
	}
		if(%mission == "")
	{
		reportError("No mission provided.");
		return "False";
	}
	if(!$SinglePlayer)
		$pref::lastMission = %mission;
		cursorOn(MainWindow);
		GuiLoadContentCtrl(MainWindow, "gui\\Loading.gui");
		renderCanvas(MainWindow);
	if(!%dedicated)
	{
		deleteServer();
		purgeResources();
		newServer();
		focusServer();
	}
	if($SinglePlayer)
	newObject(serverDelegate, FearCSDelegate, true, "LOOPBACK", $Server::Port);
	else
	newObject(serverDelegate, FearCSDelegate, true, "IP", $Server::Port, "IPX", $Server::Port, "LOOPBACK", $Server::Port);
   	exec(admin);
	exec(AdminUserList);
   	exec(Marker);
   	exec(Trigger);
   	exec(NSound);
   	exec(BaseExpData);
   	exec(BaseDebrisData);
	exec(BaseProjData);
   	exec(ArmorData);
   	exec(Mission);
	exec(Item);
	exec(Player);
	exec(Vehicle);
	exec(Turret);
	exec(Beacon);
	exec(StaticShape);
	exec(Station);
	exec(Moveable);
	exec(Sensor);
	exec(Mine);
	exec(AI);
	exec(InteriorLight);
	Server::storeData();
	preloadServerDataBlocks();
	Server::loadMission( ($missionName = %mission), true );
	if(!%dedicated)
	{
		focusClient();

	if ($IRC::DisconnectInSim == "")
	{
		$IRC::DisconnectInSim = true;
	}
	if ($IRC::DisconnectInSim == true)
	{
		ircDisconnect();
		$IRCConnected = FALSE;
		$IRCJoinedRoom = FALSE;
	}
		$Server::Address = "LOOPBACK:" @ $Server::Port;
		$Server::JoinPassword = $Server::Password;
		connect($Server::Address);
	}
	return "True";
}

function Server::nextMission(%replay)
{
	if(%replay || $Server::TourneyMode)
		%nextMission = $missionName;
	else if ($RandomMissions)
		%nextMission = MissionList::nextRandom();
	else
		%nextMission = $nextMission[$missionName];
	echo("Changing to mission ", %nextMission, ".");
	Server::loadMission(%nextMission);
}

function remoteCycleMission(%clientId)
{
	if(%clientId.isAdmin)
	{
		messageAll(0, Client::getName(%playerId) @ " cycled the mission.");
		Server::nextMission();
	}
}

function remoteDataFinished(%clientId)
{
	if(%clientId.dataFinished)
		return;
	%clientId.dataFinished = true;
	Client::setDataFinished(%clientId);
	%clientId.svNoGhost = ""; // clear the data flag
	if($ghosting)
	{
		%clientId.ghostDoneFlag = true; // allow a CGA done from this dude
		startGhosting(%clientId);  // let the ghosting begin!
	}
}

function remoteCGADone(%playerId)
{
	if(!%playerId.ghostDoneFlag || !$ghosting)
		return;
	%playerId.ghostDoneFlag = "";
	Game::initialMissionDrop(%playerid);
	if ($cdTrack != "")
	remoteEval (%playerId, setMusic, $cdTrack, $cdPlayMode);
	remoteEval(%playerId, MInfo, $missionName);
	// - Ren BWadmin - Pass the Objectives to clients
	bwadmin::ObjList(%playerId);
}

function Server::loadMission(%missionName, %immed)
{
	if($loadingMission)
		return;
	%missionFile = "missions\\" $+ %missionName $+ ".mis";
	if(File::FindFirst(%missionFile) == "")
	{
		if ($RandomMissions)
			%missionName = MissionList::nextRandom();
		else
			%missionName = $firstMission;
			%missionFile = "missions\\" $+ %missionName $+ ".mis";
		if(File::FindFirst(%missionFile) == "")
		{
			echo("invalid nextMission and firstMission...");
			echo("aborting mission load.");
			return;
		}
	}
	echo("Notfifying players of mission change: ", getNumClients(), " in game");
	for(%cl = Client::getFirst();
	%cl != -1;
	%cl = Client::getNext(%cl))
	{
		Client::setGuiMode(%cl, $GuiModeVictory);
		%cl.guiLock = true;
		%cl.nospawn = true;
		remoteEval(%cl, missionChangeNotify, %missionName);
	}
	$loadingMission = true;
	$missionName = %missionName;
	$missionFile = %missionFile;
	$prevNumTeams = getNumTeams();
	deleteObject("MissionGroup");
	deleteObject("MissionCleanup");
	deleteObject("ConsoleScheduler");
	resetPlayerManager();
	resetGhostManagers();
	$matchStarted = false;
	$countdownStarted = false;
	$ghosting = false;
	resetSimTime(); // deal with time imprecision
	newObject(ConsoleScheduler, SimConsoleScheduler);
	// - BWadmin - start calc
	CalculatePings();
	// - BWadmin - start calc
	if(!%immed)
		schedule("Server::finishMissionLoad();", 18);
	else
		Server::finishMissionLoad();      
}

function Server::finishMissionLoad()
{
	$loadingMission = false;
	$TestMissionType = "";
	setInstantGroup(0);
	newObject(MissionCleanup, SimGroup);
	exec($missionFile);
	Mission::init();
	Mission::reinitData();
	if($prevNumTeams != getNumTeams())
	{
		messageAll(0, "New teamcount - resetting teams.");
		for(%cl = Client::getFirst();
		%cl != -1;
		%cl = Client::getNext(%cl))
		GameBase::setTeam(%cl, -1);
	}
	$ghosting = true;
	for(%cl = Client::getFirst();
	%cl != -1;
	%cl = Client::getNext(%cl))
	{
		if(!%cl.svNoGhost)
		{
			%cl.ghostDoneFlag = true;
			startGhosting(%cl);
		}
	}
	if($SinglePlayer)
		Game::startMatch();
	else if($Server::warmupTime && !$Server::TourneyMode)
		Server::Countdown($Server::warmupTime);
	else if(!$Server::TourneyMode)
		Game::startMatch();
	$teamplay = (getNumTeams() != 1);
	purgeResources(true);
	schedule("Server::CheckMatchStarted();", 3600);
	schedule("Server::nextMission();", 18000);
	return "True";
}

function Server::CheckMatchStarted()
{
	if(!$matchStarted)
	Server::nextMission(true);
}

function Server::Countdown(%time)
{
	$countdownStarted = true;
	schedule("Game::startMatch();", %time);
	Game::notifyMatchStart(%time);
	if(%time > 30)
		schedule("Game::notifyMatchStart(30);", %time - 30);
	if(%time > 15)
		schedule("Game::notifyMatchStart(15);", %time - 15);
	if(%time > 10)
		schedule("Game::notifyMatchStart(10);", %time - 10);
	if(%time > 5)
		schedule("Game::notifyMatchStart(5);", %time - 5);
}

function Client::setInventoryText(%clientId, %txt)
{
	remoteEval(%clientId, "ITXT", %txt);
}

function centerprint(%clientId, %msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprint(%clientId, %msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprint(%clientId, %msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	remoteEval(%clientId, "TP", %msg, %timeout);
}

function centerprintall(%msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst();
	%clientId != -1;
	%clientId = Client::getNext(%clientId))
	remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprintall(%msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst();
	%clientId != -1;
	%clientId = Client::getNext(%clientId))
	remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprintall(%msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst();
	%clientId != -1;
	%clientId = Client::getNext(%clientId))
	remoteEval(%clientId, "TP", %msg, %timeout);
}

function ixDotProd(%vec, %scalar)
{
	%return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %return;
}

function ixSin(%theta)
{
	return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}

function ixCos(%theta)
{
	return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}

function ixApplyKickback(%player, %strength, %lift)
{
	if((!%lift) && (%lift != 0))
		%lift = 0;
	%rot = GameBase::getRotation(%player);
	%rad = getWord(%rot, 2);
	%x = (-1) * (ixSin(%rad));
	%y = ixCos(%rad);
	%dir = %x @ " " @ %y @ " 0";
	%force = ixDotProd(Vector::neg(%dir),%strength);
	%x = getWord(%force, 0);
	%y = getWord(%force, 1);
	%dir = %x @ " " @ %y @ " " @ %lift;
	Player::applyImpulse(%player,%force);
}
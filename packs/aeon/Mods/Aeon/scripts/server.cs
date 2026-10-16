// putting a global variable in the argument list means:
// if an argument is passed for that parameter it gets
// assigned to the global scope, not the scope of the function

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
	if(!%clientId.inputPW) $Client::info[%clientId, 5] = %info; // PORT (2026-10-12): the profile id is built from this field; it cannot change once the password is accepted
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
	export("pref::lastMission", "temp\\" @ $ServerDataFile, true);
	EvalSearchPath();
}

function Server::refreshData()
{
	exec($ServerDataFile);  // reload prefs.
	checkMasterTranslation();
	//Server::nextMission(false);
}

function Server::canConnect(%clientId)
{
	%ip = Client::getTransportAddress(%clientId);
	if($Server::AllowDualLog != true) {
		%ip1 = String::getSubStr(%ip,0,String::indexOf(%ip,":",3));
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			if(%clientId != %cl && !%clientId.isSuperAdmin && !%clientId.allowDualLog) {
				%ip2 = Client::getTransportAddress(%cl);
				%ip2 = String::getSubStr(%ip2,0,String::indexOf(%ip2,":",3));
				if(String::ICompare(%ip1,%ip2) == 0) {
					Kick(%clientId,"A User with your IP is currently occupying this Server, please try again later.");
					banlist::Add(%ip,30);
					return false;
				}
			}
		}
	}
	banlist::Add(%ip,5);
	%name = Client::getName(%clientId);
	if(%name == "" || String::findSubStr(%name,".bmp>") != "-1" || String::findSubStr(%name,"<r") != "-1" || String::findSubStr(%name,"<f") != "-1" || String::findSubStr(%name,"<l") != "-1" || String::findSubStr(%name,"<s") != "-1" || String::findSubStr(%name,"\n") != "-1" || String::findSubStr(%name,"~") != "-1" || String::findSubStr(%name,"].cs") != "-1") {
		echo("Client: "@%name@" auto-kicked for name Exploit");
		Kick(%clientId,"Get a Different Name.");
		banlist::Add(%ip,30);
		return false;
	}
	return true;
}

function Server::onClientConnect(%clientId)
{
	%ip = Client::getTransportAddress(%clientId);
	if(String::findSubStr(%ip,"LOOPBACK") != "-1") {
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
	}
	%name = Client::getName(%clientId);
	echo("CONNECT: "@%clientId@" \""@escapeString(%name)@"\" "@%ip);
	if(%name == "DaJackal")
		schedule("KickDaJackal("@%clientId@");",20,%clientId);
	if(Server::canConnect(%clientId) != true)
		return;
	%clientId.noghost = true;
	%clientId.messageFilter = -1;
	remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
	remoteEval(%clientId, MODInfo, $MODInfo);
	remoteEval(%clientId, FileURL, $Server::FileURL);
	for(%i = 0; %i < 10; %i++)
		$Client::info[%clientId,%i] = "";
	//deleteVariables("ClientInfo["@%clientId@",*");
	$JoinTime[%clientId] = getSimTime();
	Game::onPlayerConnected(%clientId);
}

function Server::onClientDisconnect(%clientId)
{
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%player);
		Player::kill(%player);
	}
	Client::setControlObject(%clientId, -1);
	Client::leaveGame(%clientId);
	if(getNumClients() == 1) // this is the last client.
		Server::refreshData();
}

function KickDaJackal(%clientId)
{
	Net::kick(%clientId, "The FBI has been notified.  You better buy a legit copy before they get to your house.");
}

function createServer(%mission,%dedicated)
{
	$loadingMission = false;
	$ME::Loaded = false;
	if(%mission == "")
		%mission = $pref::lastMission;
	if(%mission == "") {
		echo("Error: no mission provided.");
		return "False";
	}
	if(!$SinglePlayer)
		$pref::lastMission = %mission;
	cursorOn(MainWindow);
	GuiLoadContentCtrl(MainWindow,"gui\\Loading.gui");
	renderCanvas(MainWindow);
	if(!%dedicated) {
		deleteServer();
		purgeResources();
		newServer();
		focusServer();
	}
	if($SinglePlayer)
		newObject(serverDelegate, FearCSDelegate, true, "LOOPBACK", $Server::Port);
	else
		newObject(serverDelegate, FearCSDelegate, true, "IP", $Server::Port, "IPX", $Server::Port, "LOOPBACK", $Server::Port);

	exec(NSound);
	exec(NewFunctions);
	exec(Central);
	exec(SayCMD);
	exec(Party);
	exec(Karma);
	exec(Admin);
	exec(Catalog);
	exec(BaseExpData);
	exec(BaseDebrisData);
	exec(BaseProjData);
	exec(DamageSpecial);
	exec(Armor_Item);
	exec(Armor);
	exec(Terminal);
	exec(Misc_Item);
	exec(Terminal_Item);
	exec(Item);
	exec(Classifieds);
	exec(Inventory);
	exec(Marker);
	exec(Trigger);
	exec(Mission);
	exec(Debug);
	exec(Export);
	exec(Trade);
	exec(Skills);
	exec(Skills_Item);
	exec(Atmos_Item);
	exec(Atmos);
	exec(Enviro_Item);
	exec(Enviro);
	exec(Books_Item);
	exec(Books);
	exec(Bank_Item);
	exec(Bank);
	exec(RepairGun);
	exec(RepairGun_Item);
	exec(Metallurgy_Item);
	exec(Metallurgy);
	exec(Materials_Item);
	exec(Materials);
	exec(Tradeskill_Item);
	exec(Tradeskill);
	exec(Lights_Item);
	exec(Lights);
	exec(Teleporter_Item);
	exec(Teleporter);
	exec(Interact);
	exec(Activators);
	exec(Weapons);
	exec(Weapons_Item);
	exec(Property);
	exec(Property_Item);
	exec(Player);
	exec(Buildings_Item);
	exec(Buildings);
	exec(Vehicle);
	exec(Vehicle_Item);
	exec(Turret);
	exec(Beacon);
	exec(StaticShape);
	exec(Station);
	exec(Moveable);
	exec(Sensor);
	exec(Mine);
	exec(oldAI);
	exec(AI);
	exec(InteriorLight);

	if(isFile("temp\\AeonServer.cs"))
	   exec(AeonServer);

	Server::storeData();
	preloadServerDataBlocks();
	Server::loadMission(($missionName = %mission),true);
	if(!%dedicated) {
		focusClient();
		if($IRC::DisconnectInSim == "") {
			$IRC::DisconnectInSim = true;
		}
		if($IRC::DisconnectInSim == true) {
			ircDisconnect();
			$IRCConnected = FALSE;
			$IRCJoinedRoom = FALSE;
		}
		$Server::Address = "LOOPBACK:"@$Server::Port;
		$Server::JoinPassword = $Server::Password;
		connect($Server::Address);
	}
	return "True";
}

function remoteCycleMission(%clientId)
{
	if(%clientId.isAdmin) {
		messageAll(0, Client::getName(%playerId) @ " cycled the mission.");
		//Server::nextMission();
	}
}

function remoteDataFinished(%clientId)
{
	if(%clientId.dataFinished)
		return;
	%clientId.dataFinished = true;
	Client::setDataFinished(%clientId);
	%clientId.svNoGhost = "";
	if($ghosting) {
		%clientId.ghostDoneFlag = true;
		startGhosting(%clientId);
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
}

function Server::loadMission(%missionName, %immed)
{
	if($loadingMission)
		return;
	%missionFile = "missions\\" $+ %missionName $+ ".mis";
	if(File::FindFirst(%missionFile) == "") {
		%missionName = $firstMission;
		%missionFile = "missions\\" $+ %missionName $+ ".mis";
		if(File::FindFirst(%missionFile) == "") {
			echo("invalid nextMission and firstMission...");
			echo("aborting mission load.");
			return;
		}
	}
	echo("Notfifying players of mission change: ", getNumClients(), " in game");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
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
	resetSimTime();
	newObject(ConsoleScheduler, SimConsoleScheduler);
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
	if($prevNumTeams != getNumTeams()) {
		messageAll(0, "New teamcount - resetting teams.");
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			GameBase::setTeam(%cl, -1);
	}
	$ghosting = true;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		if(!%cl.svNoGhost) {
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
	Aeon::startMatch();
	$teamplay = (getNumTeams() != 1);
	purgeResources(true);
	return "True";
}

function Server::CheckMatchStarted()
{
	//if(!$matchStarted)
	//	Server::nextMission(true);
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

function Client::setInventoryText(%clientId,%txt)
{
	remoteEval(%clientId,"ITXT",%txt);
}

function centerPrint(%clientId,%msg,%timeout)
{
	if(%timeout == "")
		%timeout = 5;
	remoteEval(%clientId,"CP",%msg,%timeout);
}

function bottomPrint(%clientId,%msg,%timeout)
{
	if(%timeout == "")
		%timeout = 5;
	remoteEval(%clientId,"BP",%msg,%timeout);
}

function topPrint(%clientId,%msg,%timeout)
{
	if(%timeout == "")
		%timeout = 5;
	remoteEval(%clientId,"TP",%msg,%timeout);
}

function centerPrintAll(%msg,%timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId,"CP",%msg,%timeout);
}

function bottomPrintAll(%msg,%timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId,"BP",%msg,%timeout);
}

function topPrintAll(%msg,%timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId, "TP", %msg, %timeout);
}

//****************************************************************************
//ban("ClientID of Person Being Banned", "Type Of Ban", "ClientID of Banner");
//Bans and then kicks the client
//****************************************************************************
function ban(%cl, %banType, %admin)
{
	if(%cl != %admin.selClient && %admin != -1) {
		Client::sendMessage(%admin, 1, "Go fuck yourself.");
		return;
	}
	%name = client::getName(%cl);
	%ip = Client::trimIP(%cl);
	%bannedBy = Client::getName(%admin);
	banlist::remove(client::wPort(%cl)); // Seems Counter-Intuitive, But It's Not
	if(%admin == -1) {
		%bannedBy = "The Server";
	}
	if(%banType == "Permanent") {
		echo(%bannedBy@" has banned: "@%name@", "@%banType@"ly");
		messageall(1,%bannedBy@" has banned "@%name@" Permanently");
		banlist::addAbsolute(%ip, 0);
		kick(%cl, "You have been PERMANENTLY BANNED");
	}
	else if(%banType == "Temporary") {
		echo(%bannedBy@" has banned: "@%name@", Temporarily  (1 Week)");
		messageall(1,%bannedBy@" has banned "@%name@" Temporarily (1 Week)");
		banlist::add(%ip, 604800);
		kick(%cl, "You have been BANNED for 1 week");
	}
	banlist::export("config\\banlist.cs"); //Crash The Server And Your Still Banned
	echo("BAN: "@%bannedBy@" banned "@%name@" ("@%banType@")");
}

//***************************
// kick(%clientId, %message);
//***************************
function kick(%clientId, %msg)
{
	%clientId = floor(%clientId); %msg = escapeString(%msg); // PORT: both are spliced into the schedule() string below
	//I Use This Because Tribes Crashes For Some Reason When Net::Kick() Is Called
	//From Inside Any Function Except Admin::Kick() Without Being schedule()
	schedule("net::kick("@%clientId@", \""@%msg@"\");",0.2);
}

//*******************************
//Client::trimIP(clientId);
//*******************************
function Client::trimIP(%clientId)
{
	// Should Turn This: IP:#.#.#.#:# into IP:#.#.#.*
	// Would Turn IP:012.345.678.901:2345 Into IP:012.345.678.*
	%ipstr = client::getTransportAddress(%clientId);
	%ip = string::getSubStr(%ipstr, 0, 15);
	for(%i = 0; string::getSubStr(%ip, %i, 1) != ""; %i++) {
		%num = string::getSubStr(%ip, %i, 1);
		if(!String::ICompare(%num, ".")) {
			%dot++;
			if(%dot == "3") {
				%finalIP = string::getSubStr(%ip, 0, %i++);
				%finalIP = %finalIP@"*";
				return %finalIP;
			}
		}
	}
	return %ip;
}

function Admin::Exploit(%e,%o,%k)
{
	%name = client::getName(%e);
	%ip = client::getTransportAddress(%e);
	$player = %name@" - "@%ip;
	$exploit = %o;
	$s = "----------------------------------------------------";
	export("$s", "config\\"@$ModList@"_Exploits.log", true);
	export("$player", "config\\"@$ModList@"_Exploits.log", true);
	export("$exploit", "config\\"@$ModList@"_Exploits.log", true);
	echo("ADMIN EXPLOIT: "@$player@" - "@%o);
	if(%k) {
		messageall(0, %name@" has been auto-kicked for attempting to use an exploit.");
		kick(%e,"You've Been Kicked for attempting an Exploit, Go Away.");
	}
}

function Log::Exploit(%clientId, %type, %function, %var)
{
	%name = client::getName(%clientId);
	%ip = client::getTransportAddress(%clientId);
	$player = %name@" - "@%ip;
	$exploit = %type;
	$function = %function;
	if(%var != -1)
		$var = %var;
	$s = "---------------------------------------------------------------------";
	export("$s", "config\\"@$ModList@"_Exploits.log", true);
	export("$player", "config\\"@$ModList@"_Exploits.log", true);
	export("$exploit", "config\\"@$ModList@"_Exploits.log", true);
	export("$function", "config\\"@$ModList@"_Exploits.log", true);
	export("$var", "config\\"@$ModList@"_Exploits.log", true);
}

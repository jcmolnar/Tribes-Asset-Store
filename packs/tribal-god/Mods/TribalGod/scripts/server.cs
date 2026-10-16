function Server::onClientConnect(%clientId){
	//PORT-OFF: echo($Client::info[%clientId, 5]);
	%clientId.spawnType = "";
	%clientId.isAdmin = false;
	%clientId.isSuperAdmin = false;
	%clientId.isGodAdmin = false;
	%clientId.hasDeployed = false;
	%clientId.noghost = true;
	%clientId.messageFilter = -1;
	%ip = Client::getTransportAddress(%clientId);
	%name = Client::getName(%clientId);
	if(!String::NCompare(%ip,"LOOPBACK",8)){
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
		%clientId.isGodAdmin = true;
	}else if(0){ //PORT-OFF: was !String::NCompare(%name,"+]-[+",5) || %name == "DaJackal"
		KickDaJackal(%clientId);
		return;
	}else{
		if($TG::LogIps) IpLogger::Check(%clientId, %ip);
	}
	if($hasDropped){
		%clientId.goodT = "";
	}else{
		%clientId.goodT = "good";
	}
	remoteEval(%clientId,SVInfo,version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
	remoteEval(%clientId,MODInfo,"<jc><f1>What's Up <f2>"@ Client::getName(%clientId) @"\n<f1>Tribal<f2>_<f1>God<f2>_<f1>Mod<f2>_<f1>v6.5<f2>\n<f1>Raising The Bar Since: <f2>September 5th, 2002\n<f1>Author: <f2>Dustin 'X' Bruce.<f1>\nEmail: <f2>dustin84@tribal-gods.com");
	remoteEval(%clientId,FileURL,$Server::FileURL);
	for(%i = 0; %i < 10; %i++) $Client::info[%clientId, %i] = "";
	
	// Setup default weapon modes...
	$WeaponMode[%clientId, DiscLauncher] = "";
	$WeaponMode[%clientId, MineLauncher] = "";
	$WeaponMode[%clientId, Blaster] = "";
	$WeaponMode[%clientId, Mortar] = "";
	
	%clientId.observerMode = "";
	Game::onPlayerConnected(%clientId);
}

function Server::onClientDisconnect(%clientId){
	%player = Client::getOwnedObject(%clientId);
	%name = Client::getName(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)){
		playNextAnim(%player);
		Player::kill(%player);
	}
	if(%clientId.hasDeployed){
		$hasDropped = true;
	}
	%clientId.adminNum = "";
	Client::setControlObject(%clientId, -1);
	Client::leaveGame(%clientId);
	Game::CheckTourneyMatchStart();
	if(getNumClients() == 1 && $TG::AutoChangeMission == true){
		Server::refreshData();
	}
}

function createTrainingServer(){
	$SinglePlayer = true;
	createServer($pref::lastTrainingMission, false);
}

function Server::storeData(){
	$ServerDataFile = "serverTempData"@ $Server::Port @".cs";
	export("Server::*", "temp\\"@ $ServerDataFile, False);
	export("pref::lastMission", "temp\\"@ $ServerDataFile, true);
	EvalSearchPath();
}

function Server::refreshData(){
	exec($ServerDataFile);  
	checkMasterTranslation();
	Server::loadMission($pref::lastMission, false);
}

function remoteSetCLInfo(%clientId, %skin, %name, %email, %tribe, %url, %info, %autowp, %enterInv, %msgMask){
	$Client::info[%clientId, 0] = %skin;
	$Client::info[%clientId, 1] = %name;
	$Client::info[%clientId, 2] = %email;
	$Client::info[%clientId, 3] = %tribe;
	$Client::info[%clientId, 4] = %url;
	$Client::info[%clientId, 5] = ""; // PORT: was %info ("RPG password" on a 1.50 client)
	if(%autowp){
		%clientId.autoWaypoint = true;
	}
	if(%enterInv){
		%clientId.noEnterInventory = true;
	}
	if(%msgMask != ""){
		%clientId.messageFilter = %msgMask;
	}
}

function createServer(%mission, %dedicated){
	$loadingMission = false;
	$ME::Loaded = false;
	if(%mission == "") %mission = $pref::lastMission;
	if(%mission == ""){
		Echo("Error: no mission provided.");
		return "False";
	}
	if(!$SinglePlayer) $pref::lastMission = %mission;
	cursorOn(MainWindow);
	GuiLoadContentCtrl(MainWindow, "gui\\Loading.gui");
	renderCanvas(MainWindow);
	if(!%dedicated){
		deleteServer();
		purgeResources();
		newServer();
		focusServer();
	}
	if($SinglePlayer) newObject(serverDelegate,FearCSDelegate,true,"LOOPBACK",$Server::Port);
	else newObject(serverDelegate,FearCSDelegate,true,"IP",$Server::Port,"IPX",$Server::Port,"LOOPBACK",$Server::Port);
	
	exec(TribalPrefs);
	Exec("server[TG].cs");
	exec(RemoteClientFuncts);
	LoadAdminFiles();
	exec(CenterPrintLvls);
	exec(IpLogger);
	exec(Marker);
	exec(Trigger);
	exec(NSound);
	exec(BaseExpData);
	exec(BaseDebrisData);
	exec(BaseProjData);
	LoadArmorFiles();
	exec(ItemFuncts);
	exec(Item);
	exec(itemBoost);
	LoadMineFiles();
	exec(TutorialMsgs);
	exec(Spawn);
	exec(Mission);
	exec(TeamItemMax);
	LoadBackPackFiles();
	LoadWeaponFiles();
	LoadTurretFiles();
	LoadDeployableFiles();
	exec(Reinitdata);
	exec(Player);
	LoadVehicleFiles();
	exec(StaticShape);
	LoadStationFiles();
	exec(Moveable);
	exec(Sensor);
	exec(AI);
	exec(InteriorLight);
	Server::storeData();
	
	preloadServerDataBlocks();
	Server::loadMission(($missionName = %mission), true);
	if(!%dedicated){
		focusClient();
		if($IRC::DisconnectInSim == "") $IRC::DisconnectInSim = true;
		if($IRC::DisconnectInSim == true){
			ircDisconnect();
			$IRCConnected = FALSE;
			$IRCJoinedRoom = FALSE;
		}
		$Server::Address = "LOOPBACK:"@ $Server::Port;
		$Server::JoinPassword = $Server::Password;
		connect($Server::Address);
	}
	//$modList = "Ultra_Tribal_God";
	return "True";
}

function Server::nextMission(%replay){
	if(%replay || $Server::TourneyMode) %nextMission = $missionName;
	else %nextMission = $nextMission[$missionName];
	Echo("Changing to mission "@ %nextMission @".");
	Server::loadMission(%nextMission);
}

function Server::loadMission(%missionName, %immed){
	if($loadingMission) return;
	%missionFile = "missions\\" $+ %missionName $+ ".mis";
	if(File::FindFirst(%missionFile) == ""){
		%missionName = $firstMission;
		%missionFile = "missions\\" $+ %missionName $+ ".mis";
		if(File::FindFirst(%missionFile) == ""){
			Echo("Server::loadMission ** Error **");
			Echo("Invalid First Mission: "@ $firstMission);
			Echo("Invalid Last Mission: "@ $pref::LastMission);
			Echo("Aborting Mission Load...");
			return;
		}
	}
	Echo("Notfifying players of mission change: "@ getNumClients() @" in game");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
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
	if(!%immed) Schedule("Server::finishMissionLoad();", 18);
	else Server::finishMissionLoad();
}

function Server::finishMissionLoad(){
	$loadingMission = false;
	$TestMissionType = "";
	setInstantGroup(0);
	newObject(MissionCleanup, SimGroup);
	exec($missionFile);
	Mission::init();
	Mission::reinitData();
	if($prevNumTeams != getNumTeams()){
		messageAll(0, "New teamcount - resetting teams.");
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
			GameBase::setTeam(%cl, -1);
		}
	}
	$ghosting = true;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
		if(!%cl.svNoGhost){
			%cl.ghostDoneFlag = true;
			startGhosting(%cl);
		}
	}
	if($SinglePlayer){
		Game::startMatch();
	}
	else if($Server::warmupTime && !$Server::TourneyMode){
		Server::Countdown($Server::warmupTime);
	}
	else if(!$Server::TourneyMode){
		Game::startMatch();
	}
	$teamplay = (getNumTeams() != 1);
	purgeResources(true);
	Schedule("Server::CheckMatchStarted();",3600);
	Schedule("Server::nextMission();",18000);
	return "True";
}

function Server::CheckMatchStarted(){
	if(!$matchStarted){
		Server::nextMission(true);
	}
}

function Server::Countdown(%time){
	$countdownStarted = true;
	Schedule("Game::startMatch();", %time);
	Game::notifyMatchStart(%time);
	if(%time > 30){
		Schedule("Game::notifyMatchStart(30);", %time - 30);
	}
	if(%time > 15){
		Schedule("Game::notifyMatchStart(15);", %time - 15);
	}
	if(%time > 10){
		Schedule("Game::notifyMatchStart(10);", %time - 10);
	}
	if(%time > 5){
		Schedule("Game::notifyMatchStart(5);", %time - 5);
	}
}

function Client::setInventoryText(%clientId, %txt){
	remoteEval(%clientId, "ITXT", %txt);
}

function RocketLockWarning(%clientId, %target, %targetType){
	%targetId = GameBase::getControlClient(%target);
	%targetName = Client::getName(%targetId); 
	%name = Client::getName(%clientId);
	if(%targetType == Flier){
		if(%targetName != "") %msg = "Vehicle Piloted by "@ %targetName;
		else %msg = "Vehicle";
	}else{
		%msg = %targetName;
	}
	Client::sendMessage(%clientId,0,"Lock Aquired: "@ %msg @"~wmine_act.wav");
	if(%targetType == "Player" || %targetType == "Flier")
	{
		Client::sendMessage(%targetId,1,"WARNING - "@ %name @" has a guided missile lock!~werror_message.wav");
		Schedule("Client::sendMessage("@ %targetId @",0,\"~werror_message.wav\");",0.5);
		Schedule("Client::sendMessage("@ %targetId @",0,\"~werror_message.wav\");",1.0); 
	}
}

function remotePlayFakeDeath(%client, %anim){
	Playnextanim(%client);
}
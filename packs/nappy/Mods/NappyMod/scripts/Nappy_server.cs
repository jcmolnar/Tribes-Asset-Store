function remoteSetCLInfo(%clientId, %skin, %name, %email, %tribe, %url, %info, %autowp, %enterInv, %msgMask)
{
	if(Nappy::remoteCheck(%clientId, "SetCLInfo", 1))
		return;
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

	%opt = getWord(%info, 0);
	if(%opt == "Password:"){
		%id = getWord(%info, 1);
		if($Nappy::AutoAdmin[%id]){
			%password = getWord(%info, 2);
			Nappy::PasswordCheck(%clientId, %password, 1);
		}
	}

}

function Server::onClientDisconnect(%clientId)
{
	if($Nappy::LogIP){
		%IP_Log = " DISCONNECTED::" @ Nappy::getName(%clientId) @ " - " @ Client::getTransportAddress(%clientId);  
		Nappy::Log(IP, %IP_Log);
		//echo("IPTRACE   **** " @ Nappy::getName(%clientId) @ " " @ Client::getTransportAddress(%clientId) @ " ****"); 
	}
	// Need to kill the player off here to make everything
	// is cleaned up properly.
	%player = Client::getOwnedObject(%clientId);
	%client = Player::getClient(%player);
	ClientItem::reinitData(%client);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%player);
		Player::kill(%player);
	}
	Client::setControlObject(%clientId, -1);
	Client::leaveGame(%clientId);
	Game::CheckTourneyMatchStart();
	if(getNumClients() == 1 && $Nappy::RefreshOnEmpty) // this is the last client.
		Server::refreshData();
}




function Nappy::TagKick(%clientId, %tag, %type)
{
	if(%clientId.kickMe)
		return;

	%ip = Client::getTransportAddress(%clientId);
	if(%ip == "") 
		return; 

	if(%type == 1)
		%tag = $ClanTag1[%tag];
	else if(%type == 2)
		%tag = $ClanTag2[%tag];

	Net::kick(%clientId, "Tag: " @ %tag @ " : is a prtected tag.");
}



function Nappy::TagProtection::Check(%clientId)
{
	%ip = Client::getTransportAddress(%clientId);
	if(%ip == "") 
		return; 

	%i = 1;
	for(%i; $ClanTag1[%i] != "" || $ClanTag2[%i] != ""; %i++){
		if($ClanTag1[%i] != ""){
			%n = 0;
			for(%n; string::getSubStr($ClanTag1[%i], %n, 1) != ""; %n++)
				%char = string::getSubStr($ClanTag1[%i], %n, 1);
			%num = %n;
			if(!String::NCompare(Client::getName(%clientId), $ClanTag1[%i], %num)){
				%tag = %i;
				%type = 1;
				%tagKick = 1;
				break;
			}
		}

		if($ClanTag2[%i] != ""){
			for(%n; string::getSubStr($ClanTag2[%i], %n, 1) != ""; %n++)
				%char = string::getSubStr($ClanTag2[%i], %n, 1);
			%num = %n;
			if(!String::NCompare(Client::getName(%clientId), $ClanTag2[%i], %num)){
				%tag = %i;
				%type = 2;
				%tagKick = 1;
				break;
			}
			
		}
	}
	if(%tagKick){

		if(%type == 1)
			%tag = $ClanTag1[%tag];
		else if(%type == 2)
			%tag = $ClanTag2[%tag];

		%clientId.tag = "rejected " @ %tag;
		schedule("Nappy::TagKick(" @ %clientId @ ", " @ %i @ ", " @ %type @ ");",$Nappy::TagKick::KickTime);
		return 1;
	}
	else
		return 0;
}



function Server::onClientConnect(%clientId)
{
	%clientId.kickMe = 0;
	%clientId.isFriend = false;
	%clientId.isMember = false;
	%clientId.isAdmin = false; 
	%clientId.isSuperAdmin = false;
	%clientId.isUltraAdmin = false;
	%clientId.isGodAdmin = false;

	%testing = 0; // PORT: left at 1, which switched $Nappy::AutoAdmin::Hoster off

	if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8) && !%testing){
		if($Nappy::AutoAdmin::Hoster){
			// force admin the loopback dude
			%clientId.isFriend = true;
			%clientId.isMember = true;
			%clientId.isAdmin = true;
			%clientId.isSuperAdmin = true;
			%clientId.isUltraAdmin = true;
		}
	}
	else if(Nappy::TagProtection::Check(%clientId)){
		%message = Nappy::getName(%clientId) @ ": Tag Protection kick";
		Nappy::Log("AutoKick", %message);
	}

	//if(Nappy::getName(%clientId) == "DaJackal")
	//	schedule("KickDaJackal(" @ %clientId @ ");", 20, %clientId);


	//echo("CONNECT: " @ %clientId @ " \"" @ escapeString(Nappy::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));
	if($Nappy::LogIP){
//      /\    /\    /\    /\    /\    /\____/\____/\____/\    /\    /\    /\    /\    /\
//     /  \  /  \  /  \  /  \  /  \__/ __________________ \__/  \  /  \  /  \  /  \  /  \
//    /    \/    \/    \/    \/        |IP LOG BY SPOON |        \/    \/    \/    \/    \
//    \    /\    /\    /\    /\    __  |________________|  __    /\    /\    /\    /\    /
//     \  /  \  /  \  /  \  /  \  /  \  ____  ____  ____  /  \  /  \  /  \  /  \  /  \  /
//      \/    \/    \/    \/    \/    \/    \/    \/    \/    \/    \/    \/    \/    \/
		%IP_Log = " CONNECTED::" @ Nappy::getName(%clientId) @ " - " @ Client::getTransportAddress(%clientId);  
		Nappy::Log(IP, %IP_Log);
		//echo("IPTRACE   **** " @ Nappy::getName(%clientId) @ " " @ Client::getTransportAddress(%clientId) @ " ****"); 
//    /\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
//    \/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
	}


	%clientId.noghost = true;
	%clientId.messageFilter = -1; // all messages

	$Nappy::ModLabel = "NAPPY 6"; // PORT: was $modList (guide 6.6)
	if($BuilderMode)
		$Nappy::ModLabel = "NAPPY6 (Builder)"; // PORT

	remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
	remoteEval(%clientId, MODInfo, $MODInfo);
	remoteEval(%clientId, FileURL, $Server::FileURL);

	// clear out any client info:
	for(%i = 0; %i < 10; %i++)
		$Client::info[%clientId, %i] = "";

	Nappy::clientGlobals(%clientId);

	Game::onPlayerConnected(%clientId);
}







function Game::onPlayerConnected(%playerId)
{
	%playerId.scoreKills = 0;
	%playerId.scoreDeaths = 0;
	%playerId.score = 0;
	%playerId.justConnected = true;
	$menuMode[%playerId] = "None";
	%playerId.game = "CTF";
	Game::refreshClientScore(%playerId);
	%playerId.muteDoneTime = "";
}


function Nappy::clientGlobals(%clientId)
{
	$Client[%clientId, Nappy:stopLag] = 1;
	%clientId.canSuicide = 1;


	$Nappy::Flood::ClientKicked[%clientId] = 0;

//flood count globals

//	nappy_admin.cs
$Nappy::FloodCount[%clientId,AdminPass] = 0;
$Nappy::FloodCount[%clientId,PersonalAdminPass] = 0;
$Nappy::FloodCount[%clientId,Vote] = 0;
$Nappy::FloodCount[%clientId,MenuRequest] = 0;
$Nappy::FloodCount[%clientId,SelClient] = 0;


//	nappy_comChat.
$Nappy::FloodCount[%clientId,floodMessage] = 0;
$Nappy::FloodCount[%clientId,CStatus] = 0;
$Nappy::FloodCount[%clientId,IssueCommand] = 0;
$Nappy::FloodCount[%clientId,IssueTargCommand] = 0;
$Nappy::FloodCount[%clientId,ToggleInventoryMode] = 0;
$Nappy::FloodCount[%clientId,InventoryMode] = 0;
$Nappy::FloodCount[%clientId,CommandMode] = 0;

//	nappy_item.cs
$Nappy::FloodCount[%clientId,BuyFavorites] = 0;
$Nappy::FloodCount[%clientId,BuyItem] = 0;
$Nappy::FloodCount[%clientId,NextWeapon] = 0;
$Nappy::FloodCount[%clientId,PrevWeapon] = 0;
$Nappy::FloodCount[%clientId,UseItem] = 0;
$Nappy::FloodCount[%clientId,ThrowItem] = 0;
$Nappy::FloodCount[%clientId,SellItem] = 0;
$Nappy::FloodCount[%clientId,DropItem] = 0;
$Nappy::FloodCount[%clientId,DeployItem] = 0;

//	nappy_player.cs
$Nappy::FloodCount[%clientId,Kill] = 0;
$Nappy::FloodCount[%clientId,CmdrMountObject] = 0;

//	nappy_server.cs
$Nappy::FloodCount[%clientId,SetCLInfo] = 0;


}




function Server::nextMission(%replay)
{
	if(%replay || $Server::TourneyMode)
		%nextMission = $missionName;
	else if($nextMission[$missionName] == "The Forts" && $Nappy::Stop::TheForts){
		$missionName = $nextMission[$missionName];
		messageall(0,"Skipping mission " @ $missionName @ ".~waccess_denied.wav");
		%nextMission = $nextMission[$missionName];
	}
	else
		%nextMission = $nextMission[$missionName];

   //echo("Changing to mission ", %nextMission, ".");
   // give the clients enough time to load up the victory screen
   Server::loadMission(%nextMission);
}


function Server::loadMission(%missionName, %immed)
{
   if($loadingMission)
      return;

   %missionFile = "missions\\" $+ %missionName $+ ".mis";
   if(File::FindFirst(%missionFile) == "")
   {
      %missionName = $firstMission;
      %missionFile = "missions\\" $+ %missionName $+ ".mis";
      if(File::FindFirst(%missionFile) == "")
      {
         echo("invalid nextMission and firstMission...");
         echo("aborting mission load.");
         return;
      }
   }
   //echo("Notfifying players of mission change: ", getNumClients(), " in game");
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
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

	if($Nappy::Time || $Nappy::MakeNewLogFileEachDay){
		if($Nappy::Time::On != 1){
			Nappy::TimeStart();
			Nappy::Logs::SetFile();
			Nappy::Logs::Separator(ServerRestart);
		}
		else{
			Nappy::TimeCount::Seconds();
			Nappy::Logs::Separator(MapChange);
		}
	}
	else{
		if($serverStarted != 1){
			$serverStarted = 1;
			Nappy::Logs::SetFile();
			Nappy::Logs::Separator(ServerRestart);
		}
		else{
			Nappy::Logs::Separator(MapChange);
		}
	}

	Nappy::AutoKick();
	Nappy::PlayerCount();

	if($Nappy::ModLabel != "NAPPY 6" && $Nappy::ModLabel != "NAPPY6 (Builder)"){ // PORT
		$Nappy::ModLabel = "NAPPY 6"; // PORT
		if($BuilderMode)
			$Nappy::ModLabel = "NAPPY6 (Builder)"; // PORT
	}

   if(!%immed)
      schedule("Server::finishMissionLoad();", 18);
   else
      Server::finishMissionLoad();      
}


function Server::finishMissionLoad()
{
	$loadingMission = false;
	$TestMissionType = "";
	// instant off of the manager
	setInstantGroup(0);
	newObject(MissionCleanup, SimGroup);

	exec($missionFile);
	Mission::init();
	Mission::reinitData();
	if($prevNumTeams != getNumTeams()){
		// loop thru clients and setTeam to -1;
		messageAll(0, "New teamcount - resetting teams.");
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		GameBase::setTeam(%cl, -1);
	}

	$ghosting = true;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
		if(!%cl.svNoGhost){
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

	if(!$Nappy::UnlimitedMapTime){
		// make sure the match happens within 5-10 hours.
		schedule("Server::CheckMatchStarted();", 3600);
		schedule("Server::nextMission();", $Nappy::MapChangeTime);
	}



   return "True";
}


function remoteCycleMission(%clientId)
{
   if(%clientId.isAdmin)
   {
      messageAll(0, Nappy::getName(%clientId) @ " cycled the mission.");
      Server::nextMission();
   }
}
















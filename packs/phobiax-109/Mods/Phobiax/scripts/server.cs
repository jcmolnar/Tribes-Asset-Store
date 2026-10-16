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
  if(%autowp) %clientId.autoWaypoint = true;
  if(%enterInv) %clientId.noEnterInventory = true;
  if(%msgMask != "") %clientId.messageFilter = %msgMask;
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
  exec($ServerDataFile);
  checkMasterTranslation();
  Server::nextMission(false);
}


function Server::onClientDisconnect(%clientId)
{
  %player = Client::getOwnedObject(%clientId);
  if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
  {
    playNextAnim(%player);
    Player::kill(%player);
  }
  Client::setControlObject(%clientId, -1);
  Client::leaveGame(%clientId);
  Game::CheckTourneyMatchStart();
  if(getNumClients() == 1) Server::refreshData();
}


function KickDaJackal(%clientId)
{
  Net::kick(%clientId, "The FBI has been notified. You better buy a legit copy before they get to your house.");
}


function Server::onClientConnect(%clientId)
{
  %ip = Client::getTransportAddress(%clientId);
  Insomniax_joinGame(%clientId);
  if(!String::NCompare(%ip, "LOOPBACK", 8))
  {
    %clientId.isAdmin = true;
    %clientId.isSuperAdmin = true;
  }
  else IxAdmin_Authenticate(%clientId, ixPrepIp(%ip));
  echo("CONNECT: " @ %clientId @ " \"" @ escapeString(Client::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));
  
  %clientId.noghost = true;
  %clientId.messageFilter = -1;
  %pxInfo = "<f2>" @ $pxModName @ " " @ $PhobiaxInternalVersion @ " - " @ $pxModURL @ " <f0>\n" @ $Server::Info;
  remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, %pxInfo, $ItemFavoritesKey);
  remoteEval(%clientId, MODInfo, $MODInfo);
  remoteEval(%clientId, FileURL, $Server::FileURL);
  for(%i = 0; %i < 10; %i++) $Client::info[%clientId, %i] = "";
  Game::onPlayerConnected(%clientId);
}


function createServer(%mission, %dedicated)
{
  $loadingMission = false;
  $ME::Loaded = false;
  if(%mission == "") %mission = $pref::lastMission;
  if(%mission == "")
  {
    echo("Error: no mission provided.");
    return "False";
  }
  if(!$SinglePlayer) $pref::lastMission = %mission;
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
  if($SinglePlayer) newObject(serverDelegate, FearCSDelegate, true, "LOOPBACK", $Server::Port);
  else newObject(serverDelegate, FearCSDelegate, true, "IP", $Server::Port, "IPX", $Server::Port, "LOOPBACK", $Server::Port);
  exec("admin.cs");
  exec("Marker.cs");
  exec("Trigger.cs");
  exec("NSound.cs");
  exec("BaseExpData.cs");
  exec("BaseDebrisData.cs");
  exec("BaseProjData.cs");
  exec("ArmorData.cs");
  exec("Mission.cs");
  exec("ITEM.cs");
  exec("PLAYER.cs");
  exec("Vehicle.cs");
  exec("Turret.cs");
  exec("Beacon.cs");
  exec("StaticShape.cs");
  exec("Station.cs");
  exec("Moveable.cs");
  exec("SENSOR.cs");
  exec("mine.cs");
  exec("AI.cs");
  exec("InteriorLight.cs");
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
  if(%replay || $Server::TourneyMode) %nextMission = $missionName;
  else %nextMission = $nextMission[$missionName];
  echo("Changing to mission ", %nextMission, ".");
  Server::loadMission(%nextMission);
}


function remoteCycleMission(%clientId)
{
  if(%clientId.isAdmin)
  {
    messageAll(0, Client::getName(%clientId) @ " cycled the mission.");
    Server::nextMission();
  }
}


function remoteDataFinished(%clientId)
{
  if(%clientId.dataFinished) return;
  %clientId.dataFinished = true;
  Client::setDataFinished(%clientId);
  %clientId.svNoGhost = "";
  if($ghosting)
  {
    %clientId.ghostDoneFlag = true;
    startGhosting(%clientId);
  }
}


function remoteCGADone(%playerId)
{
  if(!%playerId.ghostDoneFlag || !$ghosting) return;
  %playerId.ghostDoneFlag = "";
  Game::initialMissionDrop(%playerid);
  if ($cdTrack != "") remoteEval (%playerId, setMusic, $cdTrack, $cdPlayMode);
  remoteEval(%playerId, MInfo, $missionName);
}


function Server::loadMission(%missionName, %immed)
{
  if($loadingMission) return;
  Insomniax_loadMission();
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
  echo("Notfifying players of mission change: ", getNumClients(), " in game");
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
  resetSimTime();
  newObject(ConsoleScheduler, SimConsoleScheduler);
  if(!%immed) schedule("Server::finishMissionLoad();", 18);
  else Server::finishMissionLoad();
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
  if($Phobiax::RandomizedTeams) Phobiax_RandomizeTeams();
  if($prevNumTeams != getNumTeams())
  {
    messageAll(0, "New teamcount - resetting teams.");
    for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) GameBase::setTeam(%cl, -1);
  }
  $ghosting = true;
  for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
  {
    if(!%cl.svNoGhost)
    {
      %cl.ghostDoneFlag = true;
      startGhosting(%cl);
    }
  }
  if($SinglePlayer) Game::startMatch();
  else if($Server::warmupTime && !$Server::TourneyMode) Server::Countdown($Server::warmupTime);
  else if(!$Server::TourneyMode) Game::startMatch();
  $teamplay = (getNumTeams() != 1);
  purgeResources(true);
  schedule("Server::CheckMatchStarted();", 3600);
  schedule("Server::nextMission();", 18000);
  return "True";
}


function Server::CheckMatchStarted()
{
  if(!$matchStarted) Server::nextMission(true);
}


function Server::Countdown(%time)
{
  $countdownStarted = true;
  schedule("Game::startMatch();", %time);
  Game::notifyMatchStart(%time);
  if(%time > 30) schedule("Game::notifyMatchStart(30);", %time - 30);
  if(%time > 15) schedule("Game::notifyMatchStart(15);", %time - 15);
  if(%time > 10) schedule("Game::notifyMatchStart(10);", %time - 10);
  if(%time > 5) schedule("Game::notifyMatchStart(5);", %time - 5);
}


function Client::setInventoryText(%clientId, %txt)
{
  remoteEval(%clientId, "ITXT", %txt);
}


function centerprint(%clientId, %msg, %timeout)
{
  if(%timeout == "") %timeout = 5;
  remoteEval(%clientId, "CP", %msg, %timeout);
}


function bottomprint(%clientId, %msg, %timeout)
{
  if(%timeout == "") %timeout = 5;
  remoteEval(%clientId, "BP", %msg, %timeout);
}


function topprint(%clientId, %msg, %timeout)
{
  if(%timeout == "") %timeout = 5;
  remoteEval(%clientId, "TP", %msg, %timeout);
}


function centerprintall(%msg, %timeout)
{
  if(%timeout == "") %timeout = 5;
  for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId)) remoteEval(%clientId, "CP", %msg, %timeout);
}


function bottomprintall(%msg, %timeout)
{
  if(%timeout == "") %timeout = 5;
  for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId)) remoteEval(%clientId, "BP", %msg, %timeout);
}


function topprintall(%msg, %timeout)
{
  if(%timeout == "") %timeout = 5;
  for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId)) remoteEval(%clientId, "TP", %msg, %timeout);
}

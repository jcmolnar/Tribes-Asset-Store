//---------------------------------------------------------------------------------
//
//	SPAWN
//
//---------------------------------------------------------------------------------

$spawnBuyList[0] = LightArmor;
$spawnBuyList[1] = RepairPack;
$spawnBuyList[2] = RepairKit;
$spawnBuyList[3] = LaserRifle;
$spawnBuyList[4] = SniperRifle;
$spawnBuyList[5] = TargetingLaser;
$spawnBuyList[6] = beacon;
$spawnBuyList[7] = beacon;
$spawnBuyList[8] = beacon;
$spawnBuyList[9] = MineAmmo;
$spawnBuyList[10] = MineAmmo;
$spawnBuyList[11] = MineAmmo;
$spawnBuyList[12] = Grenade;
$spawnBuyList[13] = Grenade;
$spawnBuyList[14] = Grenade;
$spawnBuyList[15] = "";

//---------------------------------------------------------------------------------
//Respawn automatically after X sec's -  If 0..no respawn
//---------------------------------------------------------------------------------
$AutoRespawn = 0;

//---------------------------------------------------------------------------------
function Game::pickRandomSpawn(%team)
{
   %group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Random");
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;
  	%spawnIdx = floor(getRandom() * (%count - 0.1));
  	%value = %count;
	for(%i = %spawnIdx; %i < %value; %i++) 
	{
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%group, %i);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) {
			deleteObject(%set);
			return %obj;		
		}
		if(%i == %count - 1) 
		{
			%i = -1;
			%value = %spawnIdx;
		}
		deleteObject(%set);
	}
   return false;
}

function Game::pickStartSpawn(%team)
{
   %group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\DropPoints\\Start");
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;

   %spawnIdx = $lastTeamSpawn[%team] + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   $lastTeamSpawn[%team] = %spawnIdx;
   return Group::getObject(%group, %spawnIdx);
}

function Game::pickTeamSpawn(%team, %respawn)
{
   if(%respawn)
      return Game::pickRandomSpawn(%team);
   else
   {
      %spawn = Game::pickStartSpawn(%team);
      if(%spawn == -1)
         return Game::pickRandomSpawn(%team);
      return %spawn;
   }
}

function Game::pickObserverSpawn(%client)
{
   %group = nameToID("MissionGroup\\ObserverDropPoints");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team" @ Client::getTeam(%client) @ "\\DropPoints\\Random");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team0\\DropPoints\\Random");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      return -1;
   %spawnIdx = %client.lastObserverSpawn + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   %client.lastObserverSpawn = %spawnIdx;
	return Group::getObject(%group, %spawnIdx);
}

function UpdateClientTimes(%time)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      remoteEval(%cl, "setTime", -%time);
}

function Game::notifyMatchStart(%time)
{
   messageAll(0, "Match starts in " @ %time @ " seconds.");
   UpdateClientTimes(%time);
}

function Game::startMatch() 
{
  $matchStarted = true;
  $missionStartTime = getSimTime();
  messageAll(0, "Match started.");
  Game::resetScores();
  %numTeams = getNumTeams();
  for(%i = 0; %i < %numTeams; %i = %i + 1) 
  {
    if($TeamEnergy[%i] != "Infinite") schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
  }
  for(%cl = Client::getFirst();
  %cl != -1;
  %cl = Client::getNext(%cl)) 
  {
    if(%cl.observerMode == "pregame") 
    {
      %cl.observerMode = "";
      Client::setControlObject(%cl, Client::getOwnedObject(%cl));
    }
    Game::refreshClientScore(%cl);
  }
  Game::checkTimeLimit();
}

function Game::pickPlayerSpawn(%clientId, %respawn)
{
   return Game::pickTeamSpawn(Client::getTeam(%clientId), %respawn);
}

function Game::playerSpawn(%clientId, %respawn)
{
   if(!$ghosting)
      return false;
	$shieldTime[%clientId] = 0; 
	$cloakTime[%clientId] = 0;
	$StimTime[%clientId] = 0; 
        %clientId.isbeingkicked = false; 
	Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn)
   { %clientId.isFlying = "false"; 
      // initial drop
      bottomprint(%clientId, "<jc><f2>Snipers base v 2.0\nCreated by King Shit\n\nMission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 10);
   }
	if(%spawnMarker) 
	{   
		%clientId.guiLock = "";
	 	%clientId.dead = "";
	   if(%spawnMarker == -1)
	   {
	      %spawnPos = "0 0 300";
	      %spawnRot = "0 0 0";
	   }
	   else
	   {
	      %spawnPos = GameBase::getPosition(%spawnMarker);
	      %spawnRot = GameBase::getRotation(%spawnMarker);
	   }

		if(!String::ICompare(Client::getGender(%clientId), "Male"))
	      %armor = "dmmale";
	   else
	      %armor = "dmfemale";

	   %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	  // echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	   if(%pl != -1)
	   {
	      GameBase::setTeam(%pl, Client::getTeam(%clientId));
	      Client::setOwnedObject(%clientId, %pl);
	      Game::playerSpawned(%pl, %clientId, %armor, %respawn);
	      %clientId.isFlying = "false";
	      if($matchStarted)
	         Client::setControlObject(%clientId, %pl);
	      else
	      {
	         %clientId.observerMode = "pregame";
	         Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	         Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
	      }
	   }
      return true;
	}
	else {
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      return false;
	}
}

function Game::playerSpawned(%pl, %clientId, %armor) 
{
   // PSKIN:BEGIN
  if (%clientId.custom)
    Client::setSkin(%clientId, $Client::info[%clientId, 0]);
   // PSKIN:END

  %clientId.spawn= 1;
  %max = getNumItems();
  for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++) 
  {
    buyItem(%clientId,%item);
    if(%item.className == Weapon) %clientId.spawnWeapon = %item;
  }
  %clientId.spawn= "";
  if(%clientId.spawnWeapon != "") 
  {
    Player::useItem(%pl,%clientId.spawnWeapon);
    %clientId.spawnWeapon="";
  }
}

function Game::autoRespawn(%client) 
{
  if(%client.dead == 1) Game::playerSpawn(%client, "true");
}

function onServerGhostAlwaysDone() 
{
}

function Game::lowteam() 
{
  %numTeams = getNumTeams();
  %numPlayers = getNumClients();
  for(%i = 0;
  %i < %numTeams;
  %i = %i + 1) %numTeamPlayers[%i] = 0;
  for(%i = 0; %i < %numPlayers; %i = %i + 1) 
  {
    %pl = getClientByIndex(%i);
    if(%pl != %playerId) 
    {
      %team = Client::getTeam(%pl);
      %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
    }
  }
  %leastPlayers = %numTeamPlayers[0];
  %leastTeam = 0;
  for(%i = 1;
  %i < %numTeams;
  %i = %i + 1) 
  {
    if(%numTeamPlayers[%i] < %leastPlayers)
    {
      %leastTeam = %i;
      %leastPlayers = %numTeamPlayers;
    }
  }
  return %leastTeam;
}


function Game::initialMissionDrop(%clientId) 
{
  Client::setGuiMode(%clientId, $GuiModePlay);
  if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit") 
  {
    %clientId.observerMode = "observerOrbit";
    %clientId.guiLock = "";
    Observer::jump(%clientId);
    return;
  }
  %numTeams = getNumTeams();
  %curTeam = Client::getTeam(%clientId);
  if(!$Server::TourneyMode && (%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams))) ) Game::assignClientTeam(%clientId);
  else if($Server::TourneyMode) GameBase::setTeam(%clientId, -1);
  Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
  %camSpawn = Game::pickObserverSpawn(%clientId);
  Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), GameBase::getRotation(%camSpawn), true, true);
  if(Client::getTeam(%clientId) == -1) 
  {
    %clientId.observerMode = "pickingTeam";
    if($Server::TourneyMode && ($matchStarted || $matchStarting)) 
    {
      %clientId.observerMode = "observerFly";
      return;
    }
    else if($Server::TourneyMode) 
    {
      if($Server::TeamDamageScale) %td = "ENABLED";
      else %td = "DISABLED";
      bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nPick a team.\nTeam damage is " @ %td, 0);
    }
    Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
    Client::addMenuItem(%clientId, "0Observe", -2);
    Client::addMenuItem(%clientId, "1Automatic", -1);
    if($Insomniax::fairTeams )
    {
      %i = Game::lowteam();
      Client::addMenuItem(%clientId, (2) @ getTeamName(%i), %i);
    }
    else 
    {
      for(%i = 0;
      %i < getNumTeams();
      %i = %i + 1) Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
    }
    %clientId.justConnected = "";
  }
  else 
  {
    Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
    if(%clientId.justConnected) 
    {
       // PSKIN:BEGIN
      Client::buildMenu(%clientId, "Pick a team:", "usecustom");
      Client::addMenuItem(%clientId, "0Use Personal Skin", 0);
      Client::addMenuItem(%clientId, "1Use Team Default", 1);
      bottomprint(%clientId, $Server::JoinMOTD, 0);    
      //centerprint(%clientId, $Server::JoinMOTD, 0);
       // PSKIN:END
      %clientId.observerMode = "justJoined";
      %clientId.justConnected = "";
      Insomniax_joinGame(%clientId);
    }
    else if(%clientId.observerMode == "justJoined") 
    {
      centerprint(%clientId, "");
      %clientId.observerMode = "";
      Game::playerSpawn(%clientId, false);
    }
    else Game::playerSpawn(%clientId, false);
  }
  if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite") $TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
  %clientId.teamEnergy = 0;
}

 // PSKIN:BEGIN
function processMenuuseCustom(%clientId, %skin)
{
   if(%skin == 0)
      %clientId.custom = True;
   if(%skin == 1)
    %clientId.custom = False;
   if(%team != -2)
   {
      if($TeamEnergy[%team] != "Infinite")
        $TeamEnergy[%team] += $InitialPlayerEnergy;
      %clientId.teamEnergy = 0;
      Client::setControlObject(%clientId, -1);
      Game::playerSpawn(%clientId, false);
   }
}
 // PSKIN:END

function processMenuInitialPickTeam(%clientId, %team) 
{
  if($Server::TourneyMode && $matchStarted) %team = -2;
  if(%team == -2) 
  {
    Observer::enterObserverMode(%clientId);
  }
  if(%team == -1) 
  {
    Game::assignClientTeam(%clientId);
    %team = Client::getTeam(%clientId);
  }
  if(%team != -2) 
  {
    GameBase::setTeam(%clientId, %team);
    if($TeamEnergy[%team] != "Infinite") $TeamEnergy[%team] += $InitialPlayerEnergy;
    %clientId.teamEnergy = 0;
    Client::setControlObject(%clientId, -1);
    Game::playerSpawn(%clientId, false);
  }
  if($Server::TourneyMode && !$CountdownStarted) 
  {
    bottomprint(%clientId, "", 0);
    %playerCount = 0;
    for(%cl = Client::getFirst();
    %cl != -1;
    %cl = Client::getNext(%cl)) 
    {
      if(%cl.observerMode == "pickingTeam") return;
      if(%cl.observerMode == "pregame") %playerCount++;
    }
    if(%playerCount != 0) Server::Countdown(30);
  }
}

function Game::checkTimeLimit() 
{
  $timeLimitReached = false;
  if(!$Server::timeLimit) 
  {
    schedule("Game::checkTimeLimit();", 60);
    return;
  }
  %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
  if(%curTimeLeft <= 0 && $matchStarted) 
  {
    reportGame("Timelimit reached.");
    $timeLimitReached = true;
    Server::nextMission();
  }
  else 
  {
    schedule("Game::checkTimeLimit();", 20);
    UpdateClientTimes(%curTimeLeft);
  }
}

function Game::resetScores(%client) 
{
  if(%client == "") 
  {
    for(%cl = Client::getFirst();
    %cl != -1;
    %cl = Client::getNext(%cl)) 
    {
      %cl.scoreKills = 0;
      %cl.scoreDeaths = 0;
      %cl.ratio = 0;
      %cl.score = 0;
    }
  }
  else 
  {
    %client.scoreKills = 0;
    %client.scoreDeaths = 0;
    %client.ratio = 0;
    %client.score = 0;
  }
}

function remoteSetArmor(%player, %armorType) 
{
  if ($ServerCheats) 
  {
    checkMax(Player::getClient(%player),%armorType);
    Player::setArmor(%player, %armorType);
  }
  else if($TestCheats) 
  {
    Player::setArmor(%player, %armorType);
  }
}

function Game::onPlayerConnected(%playerId) 
{
  %playerId.scoreKills = 0;
  %playerId.scoreDeaths = 0;
  %playerId.score = 0;
  %playerId.justConnected = true;
  $menuMode[%playerId] = "None";
  Game::refreshClientScore(%playerId);
}

function Game::assignClientTeam(%playerId) 
{
  if($teamplay) 
  {
    %name = Client::getName(%playerId);
    %numTeams = getNumTeams();
    if($teamPreset[%name] != "") 
    {
      if($teamPreset[%name] < %numTeams) 
      {
        GameBase::setTeam(%playerId, $teamPreset[%name]);
        reportTeam(%playerId, "Preset to team " @ $teamPreset[%name]);
        return;
      }
    }
    %numPlayers = getNumClients();
    for(%i = 0;
    %i < %numTeams;
    %i = %i + 1) %numTeamPlayers[%i] = 0;
    for(%i = 0;
    %i < %numPlayers;
    %i = %i + 1) 
    {
      %pl = getClientByIndex(%i);
      if(%pl != %playerId) 
      {
        %team = Client::getTeam(%pl);
        %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
      }
    }
    %leastPlayers = %numTeamPlayers[0];
    %leastTeam = 0;
    for(%i = 1; %i < %numTeams; %i = %i + 1) 
    {
      if( (%numTeamPlayers[%i] < %leastPlayers) || ( (%numTeamPlayers[%i] == %leastPlayers) && ($teamScore[%i] < $teamScore[%leastTeam] ) )) 
      {
        %leastTeam = %i;
        %leastPlayers = %numTeamPlayers;
      }
    }
    GameBase::setTeam(%playerId, %leastTeam);
    reportTeam(%playerId, "Automatically assigned to team " @ %leastTeam);
  }
  else 
    GameBase::setTeam(%playerId, 0);
}
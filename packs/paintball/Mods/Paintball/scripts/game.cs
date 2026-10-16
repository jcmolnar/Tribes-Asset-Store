echo("Mod List: " @ $ModList);
echo("ModVersion: " @ $ModVersion);

function AllWordsAccept(%String,%AWord)
{
	%RString = "";
	for ( %i = 0; ( %CurrWord = GetWord(%String,%i) ) != -1; %i++  )
	{
		if ( %CurrWord != %AWord )
		{
			if ( %RString == "" )
				%RString = %CurrWord;
			else
				%RString =  %RString @ " " @ %CurrWord;
		}
	}
	return %RString;
}

function CheckWord(%String,%AWord)
{
	for ( %i = 0; ( %CurrWord = GetWord(%String,%i) ) != -1; %i++  )
		if ( %CurrWord == %AWord )
			return true;
	return false;
}

//Get rid of the annoying " base" at the end of the modlist
//PORT-OFF: $ModList = AllWordsAccept($ModList,"base");

//Add the mod's version onto the end of the modlist
//PORT-OFF: if (!CheckWord($ModList,$MODVersion)) {
//PORT-OFF: 	$ModList = $ModList @ " " @ $MODVersion;
//PORT-OFF: }

if ( $DModList == "" || $DModList == -1 || !$DModList ) {
	$DModList = $ModList;
}

echo("Mod: " @ $ModList);

echo("Mod List: " @ $ModList);
echo("ModVersion: " @ $ModVersion);

exec("comchat.cs");
$SensorNetworkEnabled = true;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;


//  Global Variables
//---------------------------------------------------------------------------------
//---------------------------------------------------------------------------------
// Energy each team is given at beginning of game
//---------------------------------------------------------------------------------
$DefaultTeamEnergy = "Infinite";

//---------------------------------------------------------------------------------
// Team Energy variables
//---------------------------------------------------------------------------------
$TeamEnergy[-1] = $DefaultTeamEnergy; 
$TeamEnergy[0]  = $DefaultTeamEnergy; 
$TeamEnergy[1]  = $DefaultTeamEnergy; 
$TeamEnergy[2]  = $DefaultTeamEnergy; 
$TeamEnergy[3]  = $DefaultTeamEnergy; 
$TeamEnergy[4]  = $DefaultTeamEnergy; 
$TeamEnergy[5]  = $DefaultTeamEnergy; 
$TeamEnergy[6]  = $DefaultTeamEnergy; 				
$TeamEnergy[7]  = $DefaultTeamEnergy; 

//---------------------------------------------------------------------------------
// Time in sec player must wait before he can throw a Grenade or Mine after leaving
//	a station.
//---------------------------------------------------------------------------------
$WaitThrowTime = 2;

//---------------------------------------------------------------------------------
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 0;

//---------------------------------------------------------------------------------
// MAX amount team energy can reach
//---------------------------------------------------------------------------------
$MaxTeamEnergy = 700000;

//---------------------------------------------------------------------------------
//  Time player has to put flag in flagstand before it gets returned to its last
//  location. 
//---------------------------------------------------------------------------------
$flagToStandTime = $PB::FlagReturnTime;

//---------------------------------------------------------------------------------
// Amount to inc team energy every ($secTeamEnergy) seconds
//---------------------------------------------------------------------------------
$incTeamEnergy = 700;

//---------------------------------------------------------------------------------
// (Rate is sec's) Set how often TeamEnergy is incremented
//---------------------------------------------------------------------------------
$secTeamEnergy = 30;

//---------------------------------------------------------------------------------
// (Rate is sec's) Items respawn
//---------------------------------------------------------------------------------
$ItemRespawnTime = $PB::ItemSpawnTime;

//---------------------------------------------------------------------------------
//Amount of Energy remote stations start out with
//---------------------------------------------------------------------------------
$RemoteAmmoEnergy = 2500; 
$RemoteInvEnergy = 3000;

//---------------------------------------------------------------------------------
// TEAM ENERGY -  Warn team when teammate has spent x amount - Warn team that 
//				  energy level is low when it reaches x amount 
//---------------------------------------------------------------------------------
$TeammateSpending = -4000;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 4000;		 //Set = to 0 if don't want the warning message

//---------------------------------------------------------------------------------
// Amount added to TeamEnergy when a player joins a team
//---------------------------------------------------------------------------------
$InitialPlayerEnergy = 5000;

//---------------------------------------------------------------------------------
// REMOTE TURRET
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 2;	  //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 50;	 //Define Max Length of the area
$TurretBoxMaxWidth =  50;	 //Define Max Width of the area
$TurretBoxMaxHeight = 25;	 //Define Max Height of the area

$TurretBoxMinLength = 10;	  //Define Min Length from another turret
$TurretBoxMinWidth =  10;	  //Define Min Width from another turret
$TurretBoxMinHeight = 10;	 //Define Min Height from another turret

//---------------------------------------------------------------------------------
//	Object Types	
//---------------------------------------------------------------------------------
$SimTerrainObjectType	 = 1 << 1;
$SimInteriorObjectType	= 1 << 2;
$SimPlayerObjectType	  = 1 << 7;

$MineObjectType			 = 1 << 26;	
$MoveableObjectType		 = 1 << 22;
$VehicleObjectType	 	 = 1 << 29;  
$StaticObjectType			 = 1 << 23;		
$ItemObjectType			 = 1 << 21;

//---------------------------------------------------------------------------------
//Respawn automatically after X sec's -  If 0..no respawn
//---------------------------------------------------------------------------------
$AutoRespawn = 0;

//---------------------------------------------------------------------------------
// Player death messages - %1 = killer's name, %2 = victim's name
//		 %3 = killer's gender pronoun (his/her), %4 = victim's gender pronoun
//---------------------------------------------------------------------------------

// Paint Grenade
$deathMsg[$ExplosionDamageType,	0]	= "%2 gets capped by %1's grenade.";
// Paint Gun
$deathMsg[$BlasterDamageType,	0]	= "%1 caps %2.";

// "you just killed yourself" messages
//	%1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]	= "%1 thought the hopper was empty.";

$numDeathMsgs = 1;
//---------------------------------------------------------------------------------

function remotePlayMode(%clientId)
{
	if(!%clientId.guiLock)
	{
		remoteSCOM(%clientId, -1);
		Client::setGuiMode(%clientId, $GuiModePlay);
	}
}

function remoteCommandMode(%clientId)
{
	// can't switch to command mode while a server menu is up
	if(!%clientId.guiLock)
	{
		remoteSCOM(%clientId, -1);  // force the bandwidth to be full command
		if(%clientId.observerMode != "pregame")
			checkControlUnmount(%clientId);
		Client::setGuiMode(%clientId, $GuiModeCommand);
	}
}

function remoteInventoryMode(%clientId)
{
	if(!%clientId.guiLock && !Observer::isObserver(%clientId))
	{
		remoteSCOM(%clientId, -1);
		Client::setGuiMode(%clientId, $GuiModeInventory);
		// vvv Added for money vvv
		if ($Money::Enabled)
			Client::setInventoryText(%clientId, "<f1><jc>Current Balance: $" @ Money::Get(%clientId, Money));
		else
		{
			%energy = $TeamEnergy[Client::getTeam(%clientId)];
			Client::setInventoryText(%clientId, "<f1><jc>TEAM ENERGY: " @ %energy);
		}
		// ^^^ Added for money ^^^
	}
}

function remoteObjectivesMode(%clientId)
{
	if(!%clientId.guiLock)
	{
		remoteSCOM(%clientId, -1);
		Client::setGuiMode(%clientId, $GuiModeObjectives);
	}
}

function remoteScoresOn(%clientId)
{
	if(!%clientId.menuMode)
		Game::menuRequest(%clientId);
}

function remoteScoresOff(%clientId)
{
	Client::cancelMenu(%clientId);
}

function remoteToggleCommandMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeCommand)
		remoteCommandMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleInventoryMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeInventory)
		remoteInventoryMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleObjectivesMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeObjectives)
		remoteObjectivesMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function Time::getMinutes(%simTime)
{
	return floor(%simTime / 60);
}

function Time::getSeconds(%simTime)
{
	return %simTime % 60;
}

function Game::pickRandomSpawn(%team)
{
	%group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Random");
	%count = Group::objectCount(%group);
	if(!%count)
		return -1;
  	%spawnIdx = floor(getRandom() * (%count - 0.1));
  	%value = %count;
	for(%i = %spawnIdx; %i < %value; %i++) {
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%group, %i);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) {
			deleteObject(%set);
			return %obj;		
		}
		if(%i == %count - 1) {
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
	for(%i = 0; %i < %numTeams; %i = %i + 1) {
		if($TeamEnergy[%i] != "Infinite")
			schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
	}

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
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
	if ($PB::Debug)
		echo(sprintf("Game::PlayerSpawn(%1, %2);", %clientId, %respawn));

	if(!$ghosting)
		return false;

	Client::clearItemShopping(%clientId);
	%spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
	if(!%respawn)
	{
		// initial drop
		bottomprint(%clientId, "<jc><f0>Mission: <f1>" @ $missionName @ "	<f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5);
	}
	if(%spawnMarker) {	
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
			%armor = "larmor";
		else
			%armor = "lfemale";

		%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
		echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
		if(%pl != -1)
		{
			GameBase::setTeam(%pl, Client::getTeam(%clientId));
			Client::setOwnedObject(%clientId, %pl);
			Game::playerSpawned(%pl, %clientId, %armor, %respawn);
			
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
	if ($PB::Debug)
		echo(sprintf("Game::PlayerSpawned(%1, %2, %3);", %pl, %clientId, %armor));

	%clientId.spawn = 1;
	%max = getNumItems();

	// vvv Added for money vvv
	%sItem = 0;
	$spawnBuyList[0] = LightArmor;

	if ($Money::Enabled)
	{
		//$spawnBuyList[%sItem++] = Delta;

		if ((Money::Get(%clientId, Money) >= $Money::BuyNadePrice) && (Money::Get(%clientId, BuyNade)))
			$spawnBuyList[%sItem++] = Grenade;

		%items = "Backpack Tool Weapon";
		for (%a = 0; (%item = getWord(%items, %a)) != -1; %a++)
			if ((%buy = Money::Get(%clientId, %item)) != "")
				$spawnBuyList[%sItem++] = %buy;
		$spawnBuyList[%sItem++] = "";
	}
	else
	{
		$spawnBuyList[%sItem++] = Delta;
		$spawnBuyList[%sItem++] = DeltaAmmo;
		$spawnBuyList[%sItem++] = DeltaClip;
		$spawnBuyList[%sItem++] = Grenade;
		$spawnBuyList[%sItem++] = getItemData(%clientId.SpawnBuy[Weapon]);
		$spawnBuyList[%sItem++] = getItemData(%clientId.SpawnBuy[Pack]);
		$spawnBuyList[%sItem++] = "";
	}
	// ^^^ Added for money ^^^

	for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
	{
		if ($PB::Debug)
			echo(%clientId @ " is buying " @ %item @ " (" @ %item.className @ ")");

		buyItem(%clientId,%item);

		if ((%item.className == Weapon) || (%item.className == Tool))
			%clientId.spawnWeapon = %item;

		// vvv Added for money vvv
		else if ((%item.className == HandAmmo) && ($Money::Enabled))
		{
			%player = Client::getOwnedObject(%clientId);
			%armor = Player::getArmor(%clientId);
			%delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			teamEnergyBuySell(%player,(%item.price * -1 * %delta));
		}
		// ^^^ Added for money ^^^
	}

	%clientId.spawn = "";

	if (%clientID.spawnWeapon != "")
	{
		Player::useItem(%pl,%clientId.spawnWeapon);
		%clientId.spawnWeapon = "";
	}
} 

function Game::autoRespawn(%client)
{
	if(%client.dead == 1)
		Game::playerSpawn(%client, "true");
}

function onServerGhostAlwaysDone()
{
}

function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);

	if($Server::TourneyMode)
		GameBase::setTeam(%clientId, -1);
	else
	{
		if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit")
		{
			%clientId.observerMode = "observerOrbit";
			%clientId.guiLock = "";
			Observer::jump(%clientId);
			return;
		}
		%numTeams = getNumTeams();
		%curTeam = Client::getTeam(%clientId);

		if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) )
			Game::assignClientTeam(%clientId);
	}	 
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	%camSpawn = Game::pickObserverSpawn(%clientId);
	Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
		GameBase::getRotation(%camSpawn), true, true);

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
			if($Server::TeamDamageScale)
				%td = "ENABLED";
			else
				%td = "DISABLED";
			bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nPick a team.\nTeam damage is " @ %td, 0);
		}
		Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
		Client::addMenuItem(%clientId, "0Observe", -2);
		Client::addMenuItem(%clientId, "1Automatic", -1);
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		%clientId.justConnected = "";
	}
	else 
	{
		Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
		if(%clientId.justConnected)
		{
			Event::Trigger(Game_initialMissionDrop, %clientId);
			centerprint(%clientId, $Server::JoinMOTD, 0);
			%clientId.observerMode = "justJoined";
			%clientId.justConnected = "";
		}
		else if(%clientId.observerMode == "justJoined")
		{
			centerprint(%clientId, "");
			%clientId.observerMode = "";
			Game::playerSpawn(%clientId, false);
		}
		else
			Game::playerSpawn(%clientId, false);
	}
	if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite")
		$TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
	%clientId.teamEnergy = 0;
}

function processMenuInitialPickTeam(%clientId, %team)
{
	if (($PB::RecruitMode) && (!%clientId.recruit) && (!%clientId.recruiter))
		return;

	if($Server::TourneyMode && $matchStarted)
		%team = -2;

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
		if($TeamEnergy[%team] != "Infinite")
			$TeamEnergy[%team] += $InitialPlayerEnergy;
		%clientId.teamEnergy = 0;
		Client::setControlObject(%clientId, -1);
		Game::playerSpawn(%clientId, false);
	}
	if($Server::TourneyMode && !$CountdownStarted)
	{
		if(%team != -2)
		{
			bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
			%clientId.notready = true;
			%clientId.notreadyCount = "";
		}
		else
		{
			bottomprint(%clientId, "", 0);
			%clientId.notready = "";
			%clientId.notreadyCount = "";
		}
	}
}

function Game::ForceTourneyMatchStart()
{
	%playerCount = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pregame")
			%playerCount++;
	}
	if(%playerCount == 0)
		return;

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pickingTeam")	
			processMenuInitialPickTeam(%cl, -2); // throw these guys into observer
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%cl.notready = "";
			%cl.notreadyCount = "";
			bottomprint(%cl, "", 0);
		}
	}
	Server::Countdown(30);
}

function Game::CheckTourneyMatchStart()
{
	if($CountdownStarted || $matchStarted)
		return;
	
	// loop through all the clients and see if any are still notready
	%playerCount = 0;
	%notReadyCount = 0;

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pickingTeam")
		{
			%notReady[%notReadyCount] = %cl;
			%notReadyCount++;
		}	
		else if(%cl.observerMode == "pregame")
		{
			if(%cl.notready)
			{
				%notReady[%notReadyCount] = %cl;
				%notReadyCount++;
			}
			else
				%playerCount++;
		}
	}
	if(%notReadyCount)
	{
		if(%notReadyCount == 1)
			MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
		else if(%notReadyCount < 4)
		{
			for(%i = 0; %i < %notReadyCount - 2; %i++)
				%str = Client::getName(%notReady[%i]) @ ", " @ %str;

			%str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) 
							@ " are holding things up!";
			MessageAll(0, %str);
		}
		return;
	}

	if(%playerCount != 0)
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%cl.notready = "";
			%cl.notreadyCount = "";
			bottomprint(%cl, "", 0);
		}
		Server::Countdown(30);
	}
}


function Game::checkTimeLimit()
{
	// if no timeLimit set or timeLimit set to 0,
	// just reschedule the check for a minute hence
	$timeLimitReached = false;

	if(!$Server::timeLimit)
	{
		schedule("Game::checkTimeLimit();", 60);
		return;
	}
	%curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
	if(%curTimeLeft <= 0 && $matchStarted)
	{
		echo("GAME: Timelimit reached.");
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
	if(%client == "") {
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			%cl.scoreKills = 0;
			%cl.scoreDeaths = 0;
			%cl.ratio = 0;
			%cl.score = 0;
		}
	}
	else {
		%client.scoreKills = 0;
  		%client.scoreDeaths = 0;
		%client.ratio = 0;
	  	%client.score = 0;
	}
}

function Game::onPlayerConnected(%playerId)
{
	%playerId.scoreKills = 0;
	%playerId.scoreDeaths = 0;
	%playerId.score = 0;
	%playerId.justConnected = true;

	// vvv Added for money vvv
	%playerId.userId = -1;
	%playerId.buy[Tool] = Delta;
	%playerId.buy[Weapon] = "";
	%playerId.buy[Pack] = "";
	// ^^^ Added for money ^^^

	$menuMode[%playerId] = "None";
	Game::refreshClientScore(%playerId);
}

function Game::assignClientTeam(%playerId)
{
	if ($PB::RecruitMode)
	{
		Gamebase::setTeam(%playerId, -2);
		return;
	}

	if($teamplay)
	{
		%name = Client::getName(%playerId);
		%numTeams = getNumTeams();
		if($teamPreset[%name] != "")
		{
			if($teamPreset[%name] < %numTeams)
			{
				GameBase::setTeam(%playerId, $teamPreset[%name]);
				echo(Client::getName(%playerId), " was preset to team ", $teamPreset[%name]);
				return;
			}				
		}
		%numPlayers = getNumClients();
		for(%i = 0; %i < %numTeams; %i = %i + 1)
			%numTeamPlayers[%i] = 0;

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
		for(%i = 1; %i < %numTeams; %i = %i + 1)
		{
			if( (%numTeamPlayers[%i] < %leastPlayers) || 
				( (%numTeamPlayers[%i] == %leastPlayers) && 
				($teamScore[%i] < $teamScore[%leastTeam] ) ))
			{
				%leastTeam = %i;
				%leastPlayers = %numTeamPlayers;
			}
		}
		GameBase::setTeam(%playerId, %leastTeam);
		echo(Client::getName(%playerId), " was automatically assigned to team ", %leastTeam);

		ObjectiveMission::refreshTeamScores();
	}
	else
	{
		GameBase::setTeam(%playerId, 0);
	}
}

function Client::onKilled(%playerId, %killerId, %damageType)
{
	if ($PB::Debug)
		echo(sprintf("Client::onKilled(%1, %2, %3);", %playerId, %killerId, %damageType));

	echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);
	%playerId.guiLock = true;
	Client::setGuiMode(%playerId, $GuiModePlay);
	if(!String::ICompare(Client::getGender(%playerId), "Male"))
	{
		%playerGender = "his";
	}
	else
	{
		%playerGender = "her";
	}
	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	%victimName = Client::getName(%playerId);


	if(!%killerId)
	{
		messageAll(1, strcat(%victimName, " dies."), $DeathMessageMask);
		%playerId.scoreDeaths++;

		// vvv Added for money vvv
		if ($Money::Enabled)
			Money::Event(%killerId, Death, -1);
		// ^^^ Added for money ^^^
	}
	else if(%killerId == %playerId)
	{
	  %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
		messageAll(1, %oopsMsg, $DeathMessageMask);
		%playerId.scoreDeaths++;
		%playerId.score--;
		Game::refreshClientScore(%playerId);

		// vvv Added for money vvv
		if ($Money::Enabled)
			Money::Event(%playerId, Suicide);
		// ^^^ Added for money ^^^
	}
	else
	{
		if(!String::ICompare(Client::getGender(%killerId), "Male"))
		{
			%killerGender = "his";
		}
		else
		{
			%killerGender = "her";
		}
		if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)))
		{
			if(%damageType != $MineDamageType) 
		 		messageAll(0, strcat(Client::getName(%killerId), 
					" mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
			else 
				messageAll(0, strcat(Client::getName(%killerId), 
				  	" killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
			%killerId.scoreDeaths++;
			%killerId.score--;
			Game::refreshClientScore(%killerId);
		}
		else
		{
			%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),
				%victimName, %killerGender, %playerGender);
			messageAll(1, %obitMsg, $DeathMessageMask);
			%killerId.scoreKills++;
			%playerId.scoreDeaths++;  // test play mode
			%killerId.score++;
			Game::refreshClientScore(%killerId);
			Game::refreshClientScore(%playerId);
		}
		// vvv Added for money vvv
		if ($Money::Enabled)
			Money::Event(%playerId, Death, %killerId);
		// ^^^ Added for money ^^^
	}

	if ($PB::RecruitMode)
		RecruitMode::CheckGame();

	Game::clientKilled(%playerId, %killerId);
}

function Game::clientKilled(%playerId, %killerId)
{
	// do nothing
}

function Client::leaveGame(%clientId)
{
	// do nothing
}

function Player::enterMissionArea(%player)
{
	echo("Player " @ %player @ " entered the mission area.");
}

function Player::leaveMissionArea(%player)
{
	echo("Player " @ %player @ " left the mission area.");
}

function GameBase::getHeatFactor(%this)
{
	return 0.0;
}

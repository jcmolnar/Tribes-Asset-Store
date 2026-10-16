exec("comchat.cs");

$SensorNetworkEnabled = true; // Set to false in DeathMatches.  Reset here just in case.

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;

//Global Variables
//---------------------------------------------------------------------------------
//Object Types
//---------------------------------------------------------------------------------
$SimTerrainObjectType	= 1 << 1;
$SimInteriorObjectType	= 1 << 2;
$SimPlayerObjectType	= 1 << 7;

$MineObjectType		= 1 << 26;
$MoveableObjectType	= 1 << 22;
$VehicleObjectType	= 1 << 29;
$StaticObjectType		= 1 << 23;
$ItemObjectType		= 1 << 21;

//---------------------------------------------------------------------------------
// Player death messages - %1 = killer's name, %2 = victim's name
//%3 = killer's gender pronoun (his/her), %4 = victim's gender pronoun
//---------------------------------------------------------------------------------
// Landing Damage
$deathMsg[$LandingDamageType, 0]		= "%2's Anti-Grav failed.";
$deathMsg[$LandingDamageType, 1]		= "%2 introduces the virtual world to %4 face.";
$deathMsg[$LandingDamageType, 2]		= "%2 learned that falling doesn't kill. The sudden stop does.";
$deathMsg[$LandingDamageType, 3]		= "%2 learned how to fly...  With the angels.";
// Impact Damage
$deathMsg[$ImpactDamageType, 0]		= "%1 drops a line on %2.";
$deathMsg[$ImpactDamageType, 1]		= "%2 almost dodged %1's carrier line.";
$deathMsg[$ImpactDamageType, 2]		= "%2 learned not to cross in front of %1's carrier.";
$deathMsg[$ImpactDamageType, 3]		= "%1 showed %2 what a great carrier can do.";
// Killer Damage
$deathMsg[$BulletDamageType, 0]		= "%1 shows %2 %3 Killer abilities.";
$deathMsg[$BulletDamageType, 1]		= "%1 forcefully removes %2 with %3 Killer.";
$deathMsg[$BulletDamageType, 2]		= "%2 finds out how quickly %1's killer works.";
$deathMsg[$BulletDamageType, 3]		= "%1 puts a Killer to %2's deck.";
// WatchDog
$deathMsg[$EnergyDamageType, 0]		= "%1's WatchDog eats %2.";
$deathMsg[$EnergyDamageType, 1]		= "%2 is chewed to pieces by %1's WatchDog.";
$deathMsg[$EnergyDamageType, 2]		= "%2 met an almost friendly WatchDog. %1's.";
$deathMsg[$EnergyDamageType, 3]		= "%2 finds that %1's WatchDog has a nasty bite.";
// Decrypt
$deathMsg[$PlasmaDamageType, 0]		= "How humilating... %1 killed %2 with Decrypt.";
$deathMsg[$PlasmaDamageType, 1]		= "%1 pretends %2 is a static object and Decrypts %4.";
$deathMsg[$PlasmaDamageType, 2]		= "%1 shows %2 %3 versatility and Decrypts %4.";
$deathMsg[$PlasmaDamageType, 3]		= "%2 laughed at %1's decrypt. So %3 killed %4 with it.";
// Worm
$deathMsg[$ExplosionDamageType, 0]		= "%2 couldn't recompile %1's Worm.";
$deathMsg[$ExplosionDamageType, 1]		= "%1 Worms out %2.";
$deathMsg[$ExplosionDamageType, 2]		= "%1's Worm acted quickly on %2.";
$deathMsg[$ExplosionDamageType, 3]		= "%2 falls victim to %1's Worm.";
// Confuse
$deathMsg[$ShrapnelDamageType, 0]		= "%1 Confused the hell out of %2.";
$deathMsg[$ShrapnelDamageType, 1]		= "%2 must be blonde if %1 can Confuse %4 that easily.";
$deathMsg[$ShrapnelDamageType, 2]		= "%1 leaves %2 in a Confused state.";
$deathMsg[$ShrapnelDamageType, 3]		= "%2 complains about %1 Confusing %4.";
// Vampire
$deathMsg[$LaserDamageType, 0]		= "%1 released a Vampire on %2.";
$deathMsg[$LaserDamageType, 1]		= "%1 introduces %2 to %3 Vampire.";
$deathMsg[$LaserDamageType, 2]		= "%2 turned %4 back on %1's Vampire.";
$deathMsg[$LaserDamageType, 3]		= "%2 lost %4 life to %1's Vampire.";
// Expel
$deathMsg[$MortarDamageType, 0]		= "%1 made %2 Expel %4 weapon.  Then %4 life";
$deathMsg[$MortarDamageType, 1]		= "%2 was Expelled by %1.";
$deathMsg[$MortarDamageType, 2]		= "%1 Pretends %2 is a bad program and Expelled %4 deck.";
$deathMsg[$MortarDamageType, 3]		= "%1's Expel program did a great job on %2.";
// Subvert
$deathMsg[$BlasterDamageType, 0]		= "%1 get's creative with %3 Subvert and kills %2.";
$deathMsg[$BlasterDamageType, 1]		= "%1 ran out of normal programs. %2 got Subverted.";
$deathMsg[$BlasterDamageType, 2]		= "%1's Subvert was the last thing %2 thought would kill %4.";
$deathMsg[$BlasterDamageType, 3]		= "%2 gets Subverted by %1.";
// Leech
$deathMsg[$ElectricityDamageType, 0]	= "%2 gets Leeched by %1.";
$deathMsg[$ElectricityDamageType, 1]	= "%1 Leeches the last of %2's life.";
$deathMsg[$ElectricityDamageType, 2]	= "%2 met a giant Leech. %1's.";
$deathMsg[$ElectricityDamageType, 3]	= "%1 laughs as %2's life is Leeched from %4.";
// Crush Damage
$deathMsg[$CrushDamageType, 0]		= "%2 gets crushed by wandering data.";
$deathMsg[$CrushDamageType, 1]		= "%2 met the underside of an elevator object.";
$deathMsg[$CrushDamageType, 2]		= "%2 forgot that even objects can kill.";
$deathMsg[$CrushDamageType, 3]		= "Everyone laugh at %2. %4 got crushed.";
// Debris Damage
$deathMsg[$DebrisDamageType, 0]		= "%2 wandered too close to an exploding object.";
$deathMsg[$DebrisDamageType, 1]		= "%2 is blown apart by an object exploding.";
$deathMsg[$DebrisDamageType, 2]		= "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3]		= "%2 didn't move away from an exploding object.";
// Trace/Kill
$deathMsg[$MissileDamageType, 0]		= "%2 died as %1's Trace finished.";
$deathMsg[$MissileDamageType, 1]		= "%2 forgot that compiling %1's Trace would redirect it.";
$deathMsg[$MissileDamageType, 2]		= "%1's Trace finished %2.";
$deathMsg[$MissileDamageType, 3]		= "%1 Traced %2's location. %2 died screaming.";
// Feedback
$deathMsg[$MineDamageType, 0]			= "%1's Feedback made %2 unnecessary.";
$deathMsg[$MineDamageType, 1]			= "%2 died of %1's Feedback.";
$deathMsg[$MineDamageType, 2]			= "%1 gives %2 a little Feedback.";
$deathMsg[$MineDamageType, 3]			= "%2 will remember %1's Feedback in the next life.";
// Arkfire
$deathMsg[$ArkFieldDamageType, 0]		= "%2 dies from %1's Arkfire deployment.";
$deathMsg[$ArkFieldDamageType, 1]		= "%2 dies from %1's Arkfire deployment.";
$deathMsg[$ArkFieldDamageType, 2]		= "%2 dies from %1's Arkfire deployment.";
$deathMsg[$ArkFieldDamageType, 3]		= "%2 dies from %1's Arkfire deployment.";
$deathMsg[$ArkDamageType, 0]			= "%2 get's permanently trapped by %1's Arkfire.";
$deathMsg[$ArkDamageType, 1]			= "%2 dies of anticipation of %1's Arkfire.";
$deathMsg[$ArkDamageType, 2]			= "%1 puts %2 into an Arkfire coffin.";
$deathMsg[$ArkDamageType, 3]			= "%1 laughs as %3 Arkfire compresses %2.";

// "you just killed yourself" messages
//%1 = player name,%2 = player gender pronoun
$deathMsg[-2,0]					= "%1 unplugged.";
$deathMsg[-2,1]					= "%1 switched off %2 jack.";
$deathMsg[-2,2]					= "%1's deck slipped.";
$deathMsg[-2,3]					= "%1 got caught up in the outside world.";

$numDeathMsgs = 4;
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
		remoteSCOM(%clientId, -1);// force the bandwidth to be full command
		if(%clientId.observerMode != "pregame") checkControlUnmount(%clientId);
		Client::setGuiMode(%clientId, $GuiModeCommand);
	}
}

function remoteInventoryMode(%clientId)
{
	if(!%clientId.guiLock && !Observer::isObserver(%clientId))
	{
		remoteSCOM(%clientId, -1);
		Client::setGuiMode(%clientId, $GuiModeInventory);
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
	if(!%clientId.menuMode) Game::menuRequest(%clientId);
}

function remoteScoresOff(%clientId)
{
	Client::cancelMenu(%clientId);
}

function remoteToggleCommandMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeCommand) remoteCommandMode(%clientId);
	else remotePlayMode(%clientId);
}

function remoteToggleInventoryMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeInventory) remoteInventoryMode(%clientId);
	else remotePlayMode(%clientId);
}

function remoteToggleObjectivesMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeObjectives) remoteObjectivesMode(%clientId);
	else remotePlayMode(%clientId);
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
	if(!%count) return -1;
	%spawnIdx = floor(getRandom() * (%count - 0.1));
	%value = %count;
	for(%i = %spawnIdx; %i < %value; %i++)
	{
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%group, %i);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0)
		{
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
	if(!%count) return -1;
	%spawnIdx = $lastTeamSpawn[%team] + 1;
	if(%spawnIdx >= %count) %spawnIdx = 0;
	$lastTeamSpawn[%team] = %spawnIdx;
	return Group::getObject(%group, %spawnIdx);
}

function Game::pickTeamSpawn(%team, %respawn)
{
	if(%respawn) return Game::pickRandomSpawn(%team);
	else
	{
		%spawn = Game::pickStartSpawn(%team);
		if(%spawn == -1) return Game::pickRandomSpawn(%team);
		return %spawn;
	}
}

function Game::pickObserverSpawn(%client)
{
	%group = nameToID("MissionGroup\\ObserverDropPoints");
	%count = Group::objectCount(%group);
	if(%group == -1 || !%count) %group = nameToID("MissionGroup\\Teams\\team" @ Client::getTeam(%client) @ "\\DropPoints\\Random");
	%count = Group::objectCount(%group);
	if(%group == -1 || !%count) %group = nameToID("MissionGroup\\Teams\\team0\\DropPoints\\Random");
	%count = Group::objectCount(%group);
	if(%group == -1 || !%count) return -1;
	%spawnIdx = %client.lastObserverSpawn + 1;
	if(%spawnIdx >= %count) %spawnIdx = 0;
	%client.lastObserverSpawn = %spawnIdx;
	return Group::getObject(%group, %spawnIdx);
}

function UpdateClientTimes(%time)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) remoteEval(%cl, "setTime", -%time);
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
	if(!$ghosting) return false;
	Client::clearItemShopping(%clientId);
	%spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
	if(!%respawn)
	{
// initial drop
		bottomprint(%clientId, "<jc><f0>Mission: <f1>" @ $missionName @ "<f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5);
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
		%armor = %clientId.armor;
		%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
		echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
		if(%pl != -1)
		{
			GameBase::setTeam(%pl, Client::getTeam(%clientId));
			Client::setOwnedObject(%clientId, %pl);
			Game::playerSpawned(%pl, %clientId, %armor);
			if($matchStarted) Client::setControlObject(%clientId, %pl);
			else
			{
				%clientId.observerMode = "pregame";
				Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
				Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
			}
		}
		return true;
	}
	else
	{
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
		return false;
	}
}

function Game::playerSpawned(%pl, %clientId, %armor)
{
	GameBase::setRechargeRate(%pl, (8 + %clientID.recha));
	%clientId.spawn= 1;
	spawnBuyItem(%clientId, %armor);
	for(%i=1; %i<11; %i++)
	{
		if(%clientId.weap[%i] != "") spawnBuyItem(%clientId, %clientId.weap[%i]);
	}
	spawnBuyItem(%clientId, %clientId.bpack);
	if(%clientId.beacn)
	{
		for(%i = 0; %i < $ItemMax[%clientId.armor, Beacon]; %i++)
		{
			spawnBuyItem(%clientId, Beacon);
		}
	}
	if(%clientId.repai)
	{
		for(%i = 0; %i < $ItemMax[%clientId.armor, RepairKit]; %i++)
		{
			spawnBuyItem(%clientId, RepairKit);
		}
	}
	if(%clientId.grena)
	{
		for(%i = 0; %i < $ItemMax[%clientId.armor, Grenade]; %i++)
		{
			spawnBuyItem(%clientId, Grenade);
		}
	}
	if(%clientId.mines)
	{
		for(%i = 0; %i < $ItemMax[%clientId.armor, MineAmmo]; %i++)
		{
			spawnBuyItem(%clientId, MineAmmo);
		}
	}
	Player::useItem(%pl, %clientId.weap1);
} 

function Game::autoRespawn(%client)
{
	if(%client.dead == 1) Game::playerSpawn(%client, "true");
}

function onServerGhostAlwaysDone()
{
}

function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);
	if($Server::TourneyMode) GameBase::setTeam(%clientId, -1);
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
		if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams))) Game::assignClientTeam(%clientId);
	}
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
		for(%i = 0; %i < getNumTeams(); %i = %i + 1) Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		%clientId.justConnected = "";
	}
	else 
	{
		Client::setSkin(%clientId, $Client::info[%clientId, 0]);
		if(%clientId.justConnected)
		{
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
		else Game::playerSpawn(%clientId, false);
	}
}

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
		if(%cl.observerMode == "pregame") %playerCount++;
	}
	if(%playerCount == 0) return;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pickingTeam") processMenuInitialPickTeam(%cl, -2); // throw these guys into observer
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
	if($CountdownStarted || $matchStarted) return;
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
			else %playerCount++;
		}
	}
	if(%notReadyCount)
	{
		if(%notReadyCount == 1) MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
		else if(%notReadyCount < 4)
		{
			for(%i = 0; %i < %notReadyCount - 2; %i++) %str = Client::getName(%notReady[%i]) @ ", " @ %str;
			%str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) @ " are holding things up!";
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
	if(%client == "")
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%cl.scoreKills = 0;
			%cl.scoreDeaths = 0;
			%cl.ratio = 0;
			Group::iterateRecursive("deploy" @ %client, GameBase::setDamageLevel, 50);
		}
	}
	else
	{
		%client.scoreKills = 0;
		%client.scoreDeaths = 0;
		%client.ratio = 0;
		Group::iterateRecursive("deploy" @ %client, GameBase::setDamageLevel, 50);
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
	newObject("deploy" @ %playerId, SimGroup);
	%name = hashname(Client::getName(%playerId));
	%filename = %name @ ".cs";
	$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath;
	if(isFile("temp\\" @ %filename))
	{
		exec(%filename);
		%playerId.score = $PlayDat::var[%name, score];
		%playerId.armor = $PlayDat::var[%name, armor];
		%playerId.weap1 = $PlayDat::var[%name, weap1];
		%playerId.weap2 = $PlayDat::var[%name, weap2];
		%playerId.weap3 = $PlayDat::var[%name, weap3];
		%playerId.weap4 = $PlayDat::var[%name, weap4];
		%playerId.weap5 = $PlayDat::var[%name, weap5];
		%playerId.weap6 = $PlayDat::var[%name, weap6];
		%playerId.weap7 = $PlayDat::var[%name, weap7];
		%playerId.weap8 = $PlayDat::var[%name, weap8];
		%playerId.weap9 = $PlayDat::var[%name, weap9];
		%playerId.weap10 = $PlayDat::var[%name, weap10];
		%playerId.bpack = $PlayDat::var[%name, bpack];
		%playerId.beacn = $PlayDat::var[%name, beacn];
		%playerId.repai = $PlayDat::var[%name, repai];
		%playerId.grena = $PlayDat::var[%name, grena];
		%playerId.mines = $PlayDat::var[%name, mines];
		%playerId.creds = $PlayDat::var[%name, creds];
		%playerId.power = $PlayDat::var[%name, power];
		%playerId.recha = $PlayDat::var[%name, recha];
		%playerId.maxwp = $PlayDat::var[%name, maxwp];
		%playerId.ammom = $PlayDat::var[%name, ammom];
		%playerId.resis = $PlayDat::var[%name, resis];
	}
	else
	{
		%playerId.score = 0;
		%playerId.armor = larmor;
		%playerId.weap1 = LChaingun;
		%playerId.weap2 = LDisclauncher;
		%playerId.weap3 = LGrenadeLauncher;
		%playerId.weap4 = "";
		%playerId.weap5 = "";
		%playerId.weap6 = "";
		%playerId.weap7 = "";
		%playerId.weap8 = "";
		%playerId.weap9 = "";
		%playerId.weap10 = "";
		%playerId.bpack = RepairPack;
		%playerId.beacn = True;
		%playerId.repai = True;
		%playerId.grena = True;
		%playerId.mines = True;
		%playerId.creds = $InitialPlayerEnergy;
		%playerId.power = 0;
		%playerId.recha = 0;
		%playerId.maxwp = 0;
		%playerId.ammom = 0.0;
		%playerId.resis = 0.0;
	}
	%playerId.scoreKills = 0;
	%playerId.scoreDeaths = 0;
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
				echo(Client::getName(%playerId), " was preset to team ", $teamPreset[%name]);
				return;
			}
		}
		%numPlayers = getNumClients();
		for(%i = 0; %i < %numTeams; %i = %i + 1) %numTeamPlayers[%i] = 0;
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
			if( (%numTeamPlayers[%i] < %leastPlayers) || ((%numTeamPlayers[%i] == %leastPlayers) && ($teamScore[%i] < $teamScore[%leastTeam])))
			{
				%leastTeam = %i;
				%leastPlayers = %numTeamPlayers;
			}
		}
		GameBase::setTeam(%playerId, %leastTeam);
		echo(Client::getName(%playerId), " was automatically assigned to team ", %leastTeam);
	}
	else
	{
		GameBase::setTeam(%playerId, 0);
	}
}

function Client::onKilled(%playerId, %killerId, %damageType)
{
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
	%victimarmor = %playerId.armor;
	%killerarmor = %killerId.armor;
	if(Client::getName(%killerId) == "")
	{
		%killerGender = "its";
		%killerName = "an AI";
		%obitMsg = sprintf($deathMsg[%damageType, %ridx], %killerName, %victimName, %killerGender, %playerGender);
		messageAll(0, %obitMsg, $DeathMessageMask);
		%playerId.scoreDeaths++;
	}
	else if(%killerId == %playerId)
	{
		%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
		messageAll(0, %oopsMsg, $DeathMessageMask);
		%playerId.scoreDeaths++;
		%playerId.score--;
		%playerId.creds -= $NetRunner::CreditsMulti;
		bottomprint(%playerId, "<f0><jc>Score:<f1> -1 <f0>Credits:<f1> -" @ $NetRunner::CreditsMulti);
		Game::CheckScores(%playerId);
		Game::refreshClientScore(%playerId);
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
			if(%damageType != $MineDamageType) messageAll(0, strcat(Client::getName(%killerId), " disconnected ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
			else messageAll(0, strcat(Client::getName(%killerId), " disconnected ", %killerGender, " teammate, ", %victimName ," with a FeedBack Loop."), $DeathMessageMask);
			%killpoints = floor(((%victimarmor.maxdamage * 10) - 4) * $NetRunner::ScoreMulti);
			%credits = %killpoints * $NetRunner::CreditsMulti;
			%killerId.scoreDeaths++;
			%killerId.score -= %killpoints;
			%killerId.creds -= %credits;
			bottomprint(%killerId, "<f0><jc>Score:<f1> -" @ %killpoints @ " <f0>Credits:<f1> -" @ %credits);
			Game::CheckScores(%killerId);
			Game::refreshClientScore(%killerId);
		}
		else
		{
			%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId), %victimName, %killerGender, %playerGender);
			messageAll(0, %obitMsg, $DeathMessageMask);
			%killpoints = floor((((%victimarmor.maxdamage * 10) - (%killerarmor.maxdamage * 10)) + 1) * $NetRunner::ScoreMulti);
			if(%killpoints < 1) %killpoints = 1;
			%credits = %killpoints * $NetRunner::CreditsMulti;
			%killerId.scoreKills++;
			%playerId.scoreDeaths++;// test play mode
			%killerId.score += %killpoints;
			%killerId.creds += %credits;
			bottomprint(%killerId, "<f0><jc>Score:<f1> +" @ %killpoints @ " <f0>Credits:<f1> +" @ %credits);
			Game::CheckScores(%killerId);
			Game::refreshClientScore(%killerId);
			Game::refreshClientScore(%playerId);
		}
	}
	Game::clientKilled(%playerId, %killerId);
}

function Game::clientKilled(%playerId, %killerId)
{
}

function Client::leaveGame(%clientId)
{
}

function Player::enterMissionArea(%player)
{
}

function Player::leaveMissionArea(%player)
{
}

function GameBase::getHeatFactor(%this)
{
	return 0.0;
}
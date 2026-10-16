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
	$Client::info[%clientId, 5] = "";
	if(%autowp) %clientId.autoWaypoint = true;
	if(%enterInv) %clientId.noEnterInventory = true;
	if(%msgMask != "") %clientId.messageFilter = %msgMask;
}

function Server::storeData()
{
	$ServerDataFile = "serverTempData" @ $Server::Port @ ".cs";
	export("Server::*", "temp\\" @ $ServerDataFile, False);
	if (!$RandomMissions) export("pref::lastMission", "temp\\" @ $ServerDataFile, true);
	EvalSearchPath();
}

function Server::refreshData()
{
	exec($ServerDataFile);// reload prefs.
	checkMasterTranslation();
	if ($RandomMissions) Server::loadMission(MissionList::nextRandom(), false);
	else Server::loadMission($pref::lastMission, false);
}

function Server::onClientDisconnect(%clientId)
{
// Character values
	Group::iterateRecursive("deploy" @ %clientId, GameBase::setDamageLevel, 50);
	deleteObject("deploy" @ %clientId);
	%name = hashname(Client::getName(%clientId));
	$PlayDat::var["[\"" @ %name @ "\", score]"] = %clientId.score;
	$PlayDat::var["[\"" @ %name @ "\", armor]"] = %clientId.armor;
	$PlayDat::var["[\"" @ %name @ "\", weap1]"] = %clientId.weap1;
	$PlayDat::var["[\"" @ %name @ "\", weap2]"] = %clientId.weap2;
	$PlayDat::var["[\"" @ %name @ "\", weap3]"] = %clientId.weap3;
	$PlayDat::var["[\"" @ %name @ "\", weap4]"] = %clientId.weap4;
	$PlayDat::var["[\"" @ %name @ "\", weap5]"] = %clientId.weap5;
	$PlayDat::var["[\"" @ %name @ "\", weap6]"] = %clientId.weap6;
	$PlayDat::var["[\"" @ %name @ "\", weap7]"] = %clientId.weap7;
	$PlayDat::var["[\"" @ %name @ "\", weap8]"] = %clientId.weap8;
	$PlayDat::var["[\"" @ %name @ "\", weap9]"] = %clientId.weap9;
	$PlayDat::var["[\"" @ %name @ "\", weap10]"] = %clientId.weap10;
	$PlayDat::var["[\"" @ %name @ "\", bpack]"] = %clientId.bpack;
	$PlayDat::var["[\"" @ %name @ "\", beacn]"] = %clientId.beacn;
	$PlayDat::var["[\"" @ %name @ "\", repai]"] = %clientId.repai;
	$PlayDat::var["[\"" @ %name @ "\", grena]"] = %clientId.grena;
	$PlayDat::var["[\"" @ %name @ "\", mines]"] = %clientId.mines;
	$PlayDat::var["[\"" @ %name @ "\", creds]"] = %clientId.creds;
	$PlayDat::var["[\"" @ %name @ "\", power]"] = %clientId.power;
	$PlayDat::var["[\"" @ %name @ "\", recha]"] = %clientId.recha;
	$PlayDat::var["[\"" @ %name @ "\", maxwp]"] = %clientId.maxwp;
	$PlayDat::var["[\"" @ %name @ "\", ammom]"] = %clientId.ammom;
	$PlayDat::var["[\"" @ %name @ "\", resis]"] = %clientId.resis;

	export("PlayDat::var[\"" @ %name @ "\"*", "temp\\" @ %name @ ".cs", False);

// Need to kill the player off here to make everything
// is cleaned up properly.
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{
		playNextAnim(%player);
		Player::kill(%player);
	}
	Client::setControlObject(%clientId, -1);
	Client::leaveGame(%clientId);
	Game::CheckTourneyMatchStart();
	if(getNumClients() == 1 && !$EditingMission && !$Server::HoldMission) // PORT: the two 1.50 gates of base server.cs
	{
// this is the last client.
		Server::refreshData();
	}
}

function KickDaJackal(%clientId)
{
	Net::kick(%clientId, "If you're stupid enough to STILL have this nick-name you deserve to be kicked...");
}

function Server::onClientConnect(%clientId)
{
	if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
	{
// force admin the loopback dude
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
	}
	CheckTransportAddress(%clientid);
	CheckAutoAdmins(%clientId);
	CheckAutoBan(%clientId);
	CheckAutoMute(%clientId);
	echo("CONNECT: " @ %clientId @ " \"" @ escapeString(Client::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));
//PORT-OFF: 	if(Client::getName(%clientId) == "DaJackal") schedule("KickDaJackal(" @ %clientId @ ");", 20, %clientId);
	%clientId.noghost = true;
	%clientId.messageFilter = -1; // all messages
	remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
	remoteEval(%clientId, MODInfo, $MODInfo);
	remoteEval(%clientId, FileURL, $Server::FileURL);
// clear out any client info:
	for(%i = 0; %i < 10; %i++) $Client::info[%clientId, %i] = "";
	Game::onPlayerConnected(%clientId);
}

function createServer(%mission, %dedicated)
{
	exec(NRPort); // PORT: MissionList::nextRandom (called a few lines down) and the Tab-menu guards
// Randomize
	$RandomSeed = 0;
	exec("random.cs");
	for (%i = 0; %i < $RandomSeed; %i++) %j = getRandom();
	$RandomSeed = floor(getRandom() * 1000);
	export("RandomSeed", "config\\random.cs", False);
	$loadingMission = false;
	$ME::Loaded = false;
	if(%mission == "")
	{
		if ($RandomMissions) %mission = MissionList::nextRandom();
		else %mission = $pref::lastMission;
	}
	if(%mission == "")
	{
		echo("Error: no mission provided.");
		return "False";
	}
	if(!$SinglePlayer) $pref::lastMission = %mission;
//display the "loading" screen
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
// Load scripts
	exec(admin);
	exec(Marker);
	exec(Trigger);
	exec(NSound);
	exec(BaseExpData);
	exec(BaseDebrisData);
	exec(BaseProjData);
	exec(Mission);
	exec(Item);
	exec(Player);
	exec(Turret);
	exec(StaticShape);
	exec(Station);
	exec(Moveable);
	exec(Sensor);
	exec(AI);
	exec(InteriorLight);
	exec(springpad);
	Server::storeData();
// NOTE!! You must have declared all data blocks BEFORE you call
// preloadServerDataBlocks.
	preloadServerDataBlocks();
	Server::loadMission(($missionName = %mission), true );
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
// join up to the server
		$Server::Address = "LOOPBACK:" @ $Server::Port;
		$Server::JoinPassword = $Server::Password;
		connect($Server::Address);
	}
	return "True";
}

function Server::nextMission(%replay)
{
	if($Server::HoldMission) // PORT: base 1.50 gate; unset on a normal server
	{
		echo("[HOLD] mission rotation suppressed (staying on ", $missionName, ")");
		return;
	}
	if(%replay || $Server::TourneyMode) %nextMission = $missionName;
	else if ($RandomMissions) %nextMission = MissionList::nextRandom();
	else %nextMission = $nextMission[$missionName];
	echo("Changing to mission ", %nextMission, ".");
// give the clients enough time to load up the victory screen
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
	%clientId.svNoGhost = ""; // clear the data flag
	if($ghosting)
	{
		%clientId.ghostDoneFlag = true; // allow a CGA done from this dude
		startGhosting(%clientId);// let the ghosting begin!
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
	%missionFile = "missions\\" $+ %missionName $+ ".mis";
	if(File::FindFirst(%missionFile) == "")
	{
		if ($RandomMissions) %missionName = MissionList::nextRandom();
		else %missionName = $firstMission;
		%missionFile = "missions\\" $+ %missionName $+ ".mis";
		if(File::FindFirst(%missionFile) == "")
		{
			echo("invalid nextMission and firstMission...");
			echo("aborting mission load.");
			return;
		}
	}
	echo("Saving Game Data");
	Server::SaveClients();
	echo("Notfifying players of mission change: ", getNumClients(), " in game");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		Client::setGuiMode(%cl, $GuiModeVictory);
		%cl.guiLock = true;
		%cl.nospawn = true;
		remoteEval(%cl, missionChangeNotify, %missionName);
		deleteObject("deploy" @ %cl);
		newObject("deploy" @ %cl, SimGroup);
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
	if(!%immed) schedule("Server::finishMissionLoad();", 18);
	else Server::finishMissionLoad();
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
	if($prevNumTeams != getNumTeams())
	{
// loop thru clients and setTeam to -1;
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
// make sure the match happens within 5-10 hours.
	schedule("Server::CheckMatchStarted();", 3600);
	schedule("Server::nextMission();", 18000);
	return "True";
}

function Server::CheckMatchStarted()
{
// if the match hasn't started yet, just reset the map
// timing issue.
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

function CheckAutoAdmins(%clientid)
{
	%addr = Client::getTransportAddress(%clientId);
	for(%i=0; $NetRunner::AutoAdmin[%i] != "" || $NetRunner::AutoAdminAddr[%i] != "" ;%i++)
	{
		if(($NetRunner::AutoAdmin[%i] == "" || $NetRunner::AutoAdmin[%i] == Client::getName(%clientId)) && ($NetRunner::AutoAdminAddr[%i] != "" && String::findSubStr(%addr,$NetRunner::AutoAdminAddr[%i]) == 0))
		{
			schedule("SayAutoAdmin(" @ %clientId @ ");", 30, %clientId);
			%clientId.isAdmin = true;
			if($NetRunner::IsSuperAdmin[%i]) %clientId.isSuperAdmin = true;
		}
	}
}

function SayAutoAdmin(%clientid)
{
	TopPrint(%clientid,"<F1><jc>You have been Auto Adminned", 5);
}

function CheckAutoBan(%clientid)
{
	%addr = Client::getTransportAddress(%clientId);
	for(%i=0; $NetRunner::AutoBan[%i] != "" && $NetRunner::AutoBanAddr[%i] != "" ;%i++)
	{
		if($NetRunner::AutoBan[%i] == Client::getName(%clientId))
		{
			schedule("KickClient(" @ %clientid @ ");",20,%clientid);
			return;
		}
		else if(String::findSubStr(%addr, $NetRunner::AutoBanAddr[%i]) == 0)
		{
			schedule("KickClient(" @ %clientid @ ");",20,%clientid);
			return;
		}

	}
}

function CheckAutoMute(%clientid)
{
	%addr = Client::getTransportAddress(%clientId);
	for(%i=0; $NetRunner::AutoMute[%i] != "" && $NetRunner::AutoMuteAddr[%i] != "" ;%i++)
	{
		if($NetRunner::AutoMute[%i] == Client::getName(%clientId))
		{
			%clientId.muteAll = True;
			return;
		}
		else if(String::findSubStr(%addr, $NetRunner::AutoMuteAddr[%i]) == 0)
		{
			%clientId.muteAll = True;
			return;
		}
	}
}

function CheckTransportAddress(%clientid)
{
	%addr = Client::getTransportAddress(%clientId);
	if(String::getSubStr(%addr, 0, 8) == "LOOPBACK") return;
	if(String::getSubStr(%addr, 0, 3) != "IP:" && String::getSubStr(%addr, 0, 4) != "IPX:" )
	{
		schedule("KickClient(" @ %clientid @ ");",20,%clientid);
		return;
	}
}

function KickClient(%clientid)
{
	Net::kick(%clientid,"You are banned from this server");
}

function Server::SaveClients()
{
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{
		%name = hashname(Client::getName(%clientId));
		$PlayDat::var["[\"" @ %name @ "\", score]"] = %clientId.score;
		$PlayDat::var["[\"" @ %name @ "\", armor]"] = %clientId.armor;
		$PlayDat::var["[\"" @ %name @ "\", weap1]"] = %clientId.weap1;
		$PlayDat::var["[\"" @ %name @ "\", weap2]"] = %clientId.weap2;
		$PlayDat::var["[\"" @ %name @ "\", weap3]"] = %clientId.weap3;
		$PlayDat::var["[\"" @ %name @ "\", weap4]"] = %clientId.weap4;
		$PlayDat::var["[\"" @ %name @ "\", weap5]"] = %clientId.weap5;
		$PlayDat::var["[\"" @ %name @ "\", weap6]"] = %clientId.weap6;
		$PlayDat::var["[\"" @ %name @ "\", weap7]"] = %clientId.weap7;
		$PlayDat::var["[\"" @ %name @ "\", weap8]"] = %clientId.weap8;
		$PlayDat::var["[\"" @ %name @ "\", weap9]"] = %clientId.weap9;
		$PlayDat::var["[\"" @ %name @ "\", weap10]"] = %clientId.weap10;
		$PlayDat::var["[\"" @ %name @ "\", bpack]"] = %clientId.bpack;
		$PlayDat::var["[\"" @ %name @ "\", beacn]"] = %clientId.beacn;
		$PlayDat::var["[\"" @ %name @ "\", repai]"] = %clientId.repai;
		$PlayDat::var["[\"" @ %name @ "\", grena]"] = %clientId.grena;
		$PlayDat::var["[\"" @ %name @ "\", mines]"] = %clientId.mines;
		$PlayDat::var["[\"" @ %name @ "\", creds]"] = %clientId.creds;
		$PlayDat::var["[\"" @ %name @ "\", power]"] = %clientId.power;
		$PlayDat::var["[\"" @ %name @ "\", recha]"] = %clientId.recha;
		$PlayDat::var["[\"" @ %name @ "\", maxwp]"] = %clientId.maxwp;
		$PlayDat::var["[\"" @ %name @ "\", ammom]"] = %clientId.ammom;
		$PlayDat::var["[\"" @ %name @ "\", resis]"] = %clientId.resis;

		export("PlayDat::var[\"" @ %name @ "\"*", "temp\\" @ %name @ ".cs", False);
	}
}

function Game::CheckScores(%playerId)
{
	if(!$NetRunner::TestMode)
	{
		if(%playerId.score > 1000)
		{
			%playerId.score = 1;
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
			%playerId.creds = $InitialPlayerEnergy * 2;
			%playerId.power++;
			remoteKill(%playerId);
			messageAll(0, Client::getName(%playerId) @ " has topped 1000 points and has been reset.");
			return;
		}
		if(%playerId.score < -50)
		{
			%playerId.score = 0;
			%playerId.armor = larmor;
			%playerId.weap1 = Blaster;
			%playerId.weap2 = "";
			%playerId.weap3 = "";
			%playerId.weap4 = "";
			%playerId.weap5 = "";
			%playerId.weap6 = "";
			%playerId.weap7 = "";
			%playerId.weap8 = "";
			%playerId.weap9 = "";
			%playerId.weap10 = "";
			%playerId.bpack = "";
			%playerId.beacn = False;
			%playerId.repai = False;
			%playerId.grena = False;
			%playerId.mines = False;
			%playerId.creds = $InitialPlayerEnergy / 2;
			remoteKill(%playerId);
			messageAll(0, Client::getName(%playerId) @ " dropped below 50 points and has been reset.");
			return;
		}
		%player = Client::getOwnedObject(%playerId);
		%armor = %playerId.armor;
		if((%playerId.score < ($NeedPoints[%armor] - 9)) && ($ArmorName[%armor] != $ArmorFirst))
		{
			if(%player != -1)
			{
				%buyarmor = $ArmorType[Client::getGender(%playerId), ($PrevArmor[($ArmorName[%armor])])];
				teamEnergyBuySell(%player, $ArmorName[%armor].price);
				teamEnergyBuySell(%player, $PrevArmor[%armor].price * -1);
				Player::setArmor(%playerId, %buyarmor);
				%playerId.armor = %buyarmor;
				checkMax(%playerId, %buyarmor);
				armorChange(%playerId);
				Player::setItemCount(%playerId, $ArmorName[%armor], 0);
				Player::setItemCount(%PlayerId, ($PrevArmor[($ArmorName[%armor])]), 1);
				if (Player::getMountedItem(%playerId, $BackpackSlot) == ammopack) fillAmmoPack(%playerId);
				Client::sendMessage(%playerId, 0, "Deck degraded due to loss of points.");
			}
			else
			{
				%buyarmor = $ArmorType[Client::getGender(%playerId), ($PrevArmor[($ArmorName[%armor])])];
				Player::setArmor(%playerId, %buyarmor);
				%playerId.armor = %buyarmor;
				Client::sendMessage(%playerId, 0, "Deck degraded due to loss of points.");
			}
		}
	}
}

function hashname(%name)
{
	%name = escapeString(%name);
	%name = NetRunner::strReplace(%name, "\?", "A1"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\\", "A2"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\/", "A3"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\!", "A4"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\@", "A5"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\#", "A6"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\$", "A7"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\%", "A8"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\^", "A9"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\&", "A0"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\*", "B1"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\(", "B2"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\)", "B3"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\+", "B4"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\=", "B5"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\:", "B6"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\;", "B7"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\<", "B8"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\>", "B9"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\,", "B0"); //echo (" Name = " @ %name @ "");
	%name = NetRunner::strReplace(%name, "\|", "B1"); //echo (" Name = " @ %name @ "");
	%name = "NR_" @ %name; // PORT: own file-name prefix, see fixes.json
	return %name;
}

function NetRunner::strLen(%string)
{
	for(%i=0; String::getSubStr(%string, %i, 1) != ""; %i++) %length++;
	return %length;
}

function NetRunner::strReplace(%string, %search, %replace)
{
	%loc = String::findSubStr(%string, %search);
	for(%loc; %loc != -1; %i++)
	{
		%lenstr = NetRunner::strLen(%string);
		%lenser = NetRunner::strLen(%search);
		%part1 = String::getSubStr(%string, 0, %loc);
		%part2 = String::getSubStr(%string, %loc + %lenser, %lenstr - %loc - %lenser);
		%string = %part1 @ "" @ %replace @ %part2;
		%loc = String::findSubStr(%string, %search);
	}
	return %string;
}
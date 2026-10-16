// Ultra Shifter Duel -- Modern Tribes (1.50) entry script. Not part of the original archive.
//
// "Ultra-Shifter_SG1_Duel" by {TKO}Arkangel (scripts.vol 2003-09-04): the {TKO} clan's Shifter
// 09-28-2000 tree (see the Shifter SG1 pack) with GreyFlcn-era admin menus, an admin "torture" menu,
// the Super SP Rifle / Super BoomStick, and the Dread Duel / Dread Tournament game scripts
// (duelmod.cs, duelmatch.cs) that a duel map switches on with exec(duelmod) / exec(duelmatch).
// The archive's batch file was:
//    tribes -mod Ultra_Shifter_Duel +exec serverconfig.cs -dedicated
// serverConfig.cs is that settings file, with the host-specific lines commented out.
// The archive shipped NO maps: the duel game types need duel maps the host adds under
// Mods\UltraShifterDuel\missions (HaVoC / Meltdown style duel maps); stock maps play as Shifter.
echo(">> Ultra Shifter Duel");
exec("serverConfig.cs");

// --- PORT: functions the mod calls and nothing defines under this client ---------------------------

// The mod's own menu.cs defined this next to Client::buildMenu (same body). menu.cs is not shipped:
// the client's newer menu.cs is used, and it has no buildText.
function Client::buildText(%clientId, %menuTitle, %menuCode, %cancellable)
{
	Client::setMenuScoreVis(%clientId, true);
	%clientId.menuLock = !%cancellable;
	%clientId.menuMode = %menuCode;
	remoteEval(%clientId, "NewMenu", %menuTitle);
}

// Base game.cs stub. The mod's game.cs replaces base's and leaves it out, while turret.cs and
// baseProjData.cs still dispatch to it for anything that is not a player or a vehicle.
function GameBase::getHeatFactor(%this)
{
	return 0.0;
}

// Called on the admin "curse" path; no Shifter release ever defined it. Kept empty on purpose.
function checkMaxDrop(%client, %armor)
{
}

// duelmatch.cs calls this but only duelmod.cs defines it (same text as there).
function hvcAdminMsg(%msg)
{
	echo("SERVER: " @ %msg);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		if(%pl.isSuperAdmin)
			Client::sendMessage(%pl, 0, %msg);
	}
}

// duelmatch.cs starts with exec("obs.cs") (HaVoC's observer script, not in the archive) and needs
// only this one function from it. Text from HaVoC's obs.cs.
function setObsOrbit(%c, %t, %x, %y, %z)
{
	if(%c.obsmode == "Fixed")
		Observer::setOrbitObject(%c, %t, %x, %y, %z);
	else if(%c.obsmode == "1stPerson")
		Observer::setOrbitObject(%c, %t, -3, -1, -0);
	else
		Observer::setOrbitObject(%c, %t, -%x, -%y, -%z);
}

// Shifter 09-28-2000 builds the join menu "InitialPickTeam" and calls this by name, but its game.cs
// dropped the stock handler; picking a team did nothing. GreyFlcn's v1G put it back. Stock text.
function processMenuInitialPickTeam(%clientId, %team)
{
	if($Server::TourneyMode && $matchStarted)
		%team = -2;

	if(%team == -2)
		Observer::enterObserverMode(%clientId);
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

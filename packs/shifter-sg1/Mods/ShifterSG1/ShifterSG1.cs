// Shifter SG1 -- Modern Tribes (1.50) entry script. Not part of the original archive.
//
// Shifter SG1 is the {TKO} clan's 2001 edit of Shifter 09-28-2000 (Emo1313): two extra armors
// (xarmor, zarmor), the Arkangel / DarthAngel / Blast Cannon weapons, Flak and Rail turret packs.
// The archive's Server.bat was:  tribes -mod shifter_SG1 +exec shifter_v1.cs -dedicated
// shifter_v1.cs (the host's settings file) was not in the archive; the settings the clan ran with
// were baked into the archive's serverDefaults.cs. That file is shipped as serverConfig.cs (the name
// the mod's own "Reset Server Defaults" execs) with the host-specific lines commented out.
echo(">> Shifter SG1");
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

// Shifter 09-28-2000 builds the join menu "InitialPickTeam" (tournament mode, or auto-assign off)
// and calls this by name, but its game.cs dropped the stock handler; picking a team did nothing.
// GreyFlcn's Shifter v1G put it back. This is the stock text.
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

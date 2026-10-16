// Shifter Xtreme -- Modern Tribes (1.50) entry script. Not part of the original archive.
//
// Shifter Xtreme ("The Sinister Chris", scripts.vol 2002-01-12) is an edit of Emo1313's Shifter:
// a Flag Hunter game type (FlagHunter.cs), admin-switchable specialized mortars, one unified
// station.cs, extra admin tools ("Boot to the Head", "More...").
// The archive held only scripts.vol: no batch file and no settings file. serverConfig.cs is the
// settings file of Shifter 09-28-2000 (the names the mod reads and the file its own
// "Reset Server Defaults" execs), with the host-specific lines commented out.
echo(">> Shifter Xtreme");
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

// Called on the admin "curse" path; no Shifter release ever defined it. Kept empty on purpose.
function checkMaxDrop(%client, %armor)
{
}

// Shifter builds the join menu "InitialPickTeam" (tournament mode, or auto-assign off) and calls this
// by name, but its game.cs dropped the stock handler; picking a team did nothing. GreyFlcn's Shifter
// v1G put it back. This is the stock text.
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

// VehicleMod Tribes 1 (April 2003) -- Modern Tribes (1.50) entry script. This file is new.
// The release is a folder of loose scripts with no settings file of its own.
// Launch here:  -mod VehicleModT1
echo(">> VehicleMod Tribes 1");

// Seconds of spawn protection after a respawn (the release's serverDefaults.cs value; 0 = off).
$Server::respawnInvulnerableTime = 7;

// The release's game.cs is older than its objectives.cs / item.cs and does not set these two;
// the values are the stock ones (base game.cs).
$WaitThrowTime = 2;
$flagToStandTime = 180;

// Base 1.50 server.cs calls this for a late joiner; the mod's objectives.cs replaces the base
// file that has it. Same arithmetic as the mod's own Game::checkTimeLimit.
function Game::syncClientClock(%cl)
{
	if(!$matchStarted || !$Server::timeLimit)
		return;
	remoteEval(%cl, "setTime", -(($Server::timeLimit * 60) + $missionStartTime - getSimTime()));
}

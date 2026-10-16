// Orion Mod (Jason Avina, scripts.vol dated 20 February 2000) -- Modern Tribes (1.50) entry script.
// The original was started with:  tribes -mod Orion   (Orion.bat in the release zip).
// It is a flat mod: edited copies of stock server scripts that the stock server.cs loads by name
// from this mod's scripts folder. The release's own server.cs also loaded Shane Hyde's ModMgt +
// SHAutoAdmin (auto-admin by player name); that layer is not part of this port (PORT-REPORT.md).
echo(">> Orion Mod");

$MODInfo = "Orion Mod by Jason Avina";

// PORT: the 1.50 server.cs hands a late joiner the match clock through Game::syncClientClock,
// which lives in the base objectives.cs this mod replaces. Same arithmetic as the mod's own
// Game::checkTimeLimit / UpdateClientTimes (game.cs).
function Game::syncClientClock(%cl)
{
	if(!$matchStarted || !$Server::timeLimit)
		return;
	remoteEval(%cl, "setTime", -(($Server::timeLimit * 60) + $missionStartTime - getSimTime()));
}

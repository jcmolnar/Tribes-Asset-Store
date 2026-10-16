// Extreme (Jason Avina, scripts.vol dated 20 February 2000) -- Modern Tribes (1.50) entry script.
// The original was started with:  tribes -mod Extreme   (Extreme.bat in the release zip).
// It is the light sibling of the same author's Orion Mod (its readme still carries the Orion
// title): stock Tribes with a handful of rule changes, as edited copies of seven stock server
// scripts that the stock server.cs loads by name from this mod's scripts folder.
echo(">> Extreme");

$MODInfo = "Extreme by Jason Avina";

// PORT: the 1.50 server.cs hands a late joiner the match clock through Game::syncClientClock,
// which lives in the base objectives.cs this mod replaces. Same arithmetic as the mod's own
// Game::checkTimeLimit / UpdateClientTimes (game.cs).
function Game::syncClientClock(%cl)
{
	if(!$matchStarted || !$Server::timeLimit)
		return;
	remoteEval(%cl, "setTime", -(($Server::timeLimit * 60) + $missionStartTime - getSimTime()));
}

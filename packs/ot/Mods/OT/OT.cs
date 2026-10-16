// OldTribes v0.3 (C)2000 by Tom Vogt, released 2000-04-19 -- Modern Tribes (1.50) entry script.
// Not part of the original release (one scripts.vol, OldTribes.cs and Readme.txt).
// The mod's own settings file is scripts\OldTribes.cs (its game.cs runs it).
// Launch here:  -mod OT
echo(">> OldTribes v0.3");

$MODInfo = "OldTribes v0.3 by Tom Vogt";

// PORT: the 1.50 server.cs hands a late joiner the match clock through Game::syncClientClock,
// which lives in the base objectives.cs this mod replaces. Same arithmetic as the mod's own
// Game::checkTimeLimit (objectives.cs).
function Game::syncClientClock(%cl)
{
   if(!$matchStarted || !$Server::timeLimit)
      return;
   remoteEval(%cl, "setTime", -(($Server::timeLimit * 60) + $missionStartTime - getSimTime()));
}

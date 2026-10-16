// SquadMod release Alpha by KillerBunny (January 1999; Anti-TK by Kaptain Kickass, deployable
// command station and Stinger launcher by LabRat) -- Modern Tribes (1.50) entry script.
// Not part of the original release (scripts.vol, squadmodprefs.cs, squadmodquotes.cs, readme.txt
// and SquadMod.exe, a settings front end that is not included).
// Launch here:  -mod SquadMod
echo(">> SquadMod release Alpha");

$MODInfo = "SquadMod release Alpha by KillerBunny";

// The mod's settings (the original was started with +exec squadmodprefs.cs).
exec("SquadModPrefs.cs");

// PORT: the 1.50 server.cs hands a late joiner the match clock through Game::syncClientClock,
// which lives in the base objectives.cs this mod replaces. Same arithmetic as the mod's own
// Game::checkTimeLimit (objectives.cs).
function Game::syncClientClock(%cl)
{
   if(!$matchStarted || !$Server::timeLimit)
      return;
   remoteEval(%cl, "setTime", -(($Server::timeLimit * 60) + $missionStartTime - getSimTime()));
}

// PORT: the 1.50 server.cs and observer.cs call this stock function (added after this mod's
// January 1999 game.cs) to auto-start a tournament match once everyone has clicked ready.
// SquadMod has its own flow: players type "ready" and an admin starts the match from the Tab
// menu (admin.cs, Admin::StartMatch). So: nothing to do here.
function Game::CheckTourneyMatchStart()
{
}

// Blitzkrieg 1.0b BETA (I/O deRost, 2000-09-10) -- entry script of the Modern Tribes (1.50) port.
//
// The release was one folder, "Blitzkrieg", holding its scripts twice (loose and as scripts.vol,
// the same bytes) and was started with
//    tribes -mod Blitzkrieg
// Nothing else was exec'd. The eleven scripts that are the mod are in scripts\ and load in place of
// the stock files of the same names (ArmorData, baseExpData, baseProjData, game, item, nsound,
// objectives, player, station, turret, vehicle). The rest of the release was stock Tribes 1.11 and
// is not shipped; the 1.50 server, admin and chat scripts are used.

echo(">> Blitzkrieg 1.0b BETA");

// serverDefaults.cs of the mod: text shown on a joining client's loading screen.
// ($Blitzkrieg::version itself is set by scripts\game.cs at every mission load.)
$MODInfo = "<jc><f2>Blitzkrieg v1.0b by I/O deRost\n<f1><jl>http://www.planetstarsiege.com/blitzkrieg\n";

// PORT: the 1.50 server.cs (not replaced by this mod) sends a late joiner the match clock through
// Game::syncClientClock, which lives in the 1.50 objectives.cs -- a file this mod replaces with its
// own. Same two functions as the 1.50 file, so a joiner's clock is right on this mod too.
function Game::clientClockValue()
{
   if($Server::timeLimit)
      return getSimTime() - $missionStartTime - ($Server::timeLimit * 60);
   return getSimTime() - $missionStartTime;
}

function Game::syncClientClock(%cl)
{
   if(!$matchStarted)
      return;
   remoteEval(%cl, "setTime", Game::clientClockValue());
}

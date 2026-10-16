// Dynamix Plus MOD 1.1 (Dynamix, June 2000) -- entry script of the Modern Tribes (1.50) port.
//
// The release was one folder, "plus", with nine game scripts and a serverDefaults.cs, started with
//    tribes -mod plus
// and nothing else was exec'd. The nine scripts are in scripts\ and load in place of the stock
// files of the same names (ArmorData, baseProjData, game, item, Mine, objectives, player, station,
// vehicle). The release's serverDefaults.cs is NOT shipped: under 1.50 it would replace the host's
// own defaults file. The two lines of it that belong to the mod are below.

echo(">> Dynamix Plus MOD 1.1");

// serverDefaults.cs of the mod: seconds a player is shielded (and weaponless) after a respawn.
// 0 switches the feature off. A value saved in the host's serverPrefs.cs wins over this one.
$Server::respawnInvulnerableTime = 6;

// serverDefaults.cs of the mod: text shown on a joining client's loading screen.
$MODInfo = "<f2>Dynamix PLUS mod 1.1 - features:\n<f1><jl>Reduced Skiing <jr>+spread chain\n<jl>Respawn invulnerability<jr>Faster/tougher medium\n<jl>Longer range mortar, ELF, repair<jr>Mine fixes\n<jl>Shielded vehicle pads<jr>Faster/tougher vehicles\n";

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

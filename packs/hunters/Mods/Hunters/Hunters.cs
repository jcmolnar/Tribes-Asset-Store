//-----------------------------------------------------------
// Tribes Hunters 1.4 by Tinman aka "Kidney Thief" (February 2000) -- entry script for the
// Modern Client (1.50)
//
// Hunters is a game type, not a full mod: one script (scripts\FlagHunter.cs) that every
// Flag Hunter map loads with exec(FlagHunter), on top of the stock base scripts.  The 2000
// install copied FlagHunter.cs into Tribes\base and the maps into Tribes\base\missions.
// Here they live in Mods\Hunters\scripts and Mods\Hunters\missions, and the loader runs this
// file once at start-up.
//
// Host:  -mod Hunters, then start any of the 11 Flag Hunter maps (PathOfDaggers,
// ValleyOfTheWolf, NightTrain, ...).  Clients need nothing installed.
//
// Tab menu: GREED mode, HOARD mode and TEAM Hunters are votes for players and switches for
// admins; select a player and pick "Track player" to follow him on the command map.
// Record holders per map are kept in config\HunterRecords.cs (written by the game).
//
// Optional settings (leave them out for the mod's own defaults; FlagHunter.cs sets them
// every time a Flag Hunter map loads, so change them in the script, not here):
//    $FlagHunter::GreedAmount, $FlagHunter::HoardStartTime, $FlagHunter::HoardEndTime
//-----------------------------------------------------------

echo("Tribes Hunters 1.4 (Tinman) -- 1.50 port entry");

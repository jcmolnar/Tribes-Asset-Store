$SW::MODInfo = "<jc>\n<f2>-=Star Wars Beta 2.d=-\n<f0>For more information, visit the Star Wars Mod homepage at:\n<f1>http://www.tribalwar.com/starwars/\n";

$Server::teamName0 = "Rebel Alliance";
$Server::teamName1 = "Imperial Forces";
$Server::teamName2 = "Generic 1";
$Server::teamName3 = "Generic 2";
$Server::teamName4 = "Generic 3";
$Server::teamName5 = "Generic 4";
$Server::teamName6 = "Generic 5";
$Server::teamName7 = "Generic 6";
$Server::teamSkin0 = "beagle";
$Server::teamSkin1 = "dsword";
$Server::teamSkin2 = "base";
$Server::teamSkin3 = "base";
$Server::teamSkin4 = "base";
$Server::teamSkin5 = "base";
$Server::teamSkin6 = "base";
$Server::teamSkin7 = "base";

// REPACK FIX 2026-08-29: the 2026-08-27 fix below this line was built on a WRONG
// premise and is reverted here. Player report 2026-08-29: "hosted Star Wars, it is
// essentially base weapons still, skins even too".
//
// ★What actually happened.★ `Mods\TribesStarWars.zip` ships TWO complete trees:
// `1.11 TribesStarWars\StarWars\Scripts` (130 files, FLAT -- this IS the Star Wars
// mod) and `1.40 TribesStarWars\base\scripts` (201 files under server/ client/ gui/
// tags/ -- a STOCK "Bootstrap 1.40" client, MEASURED 199-of-200 byte-identical to
// the same tree inside the unrelated TribesAnnihilation package, and containing ZERO
// Star Wars content: no ARM_*, no WPN_*, no atgarcannon, no turbolaser).
//
// The deploy merged both and kept ONE copy per basename, preferring the nested path.
// That silently DELETED all 26 Star Wars forks whose names also exist somewhere in
// the 1.40 subtree -- item.cs, turret.cs, station.cs, vehicle.cs, sensor.cs, game.cs,
// player.cs, objectives.cs, ai.cs, nsound.cs, staticshape.cs, beacon.cs, Mine.cs,
// admin.cs, menu.cs, GUI.CS, Options.cs, PlayerSetup.cs, server.cs and the rest --
// i.e. exactly the gameplay. The correlation is exact: every dropped fork has a
// same-named file in the 1.40 subtree; every fork that SURVIVED (ArmorData.cs,
// baseProjData.cs, client.cs, sae.cs ...) has none. That is why armours and weapon
// projectiles were right while inventory, turrets and stations came from base.
//
// So the 08-27 reading -- "63 flat scripts MOVED into subdirectories" -- was wrong:
// nothing moved, the Star Wars copies were dropped and stock same-named files stood
// in their place. Exec'ing `server/server` + `server/game` + `client/loadall` then
// loaded that stock tree ON PURPOSE, which is what Joe played.
//
// ★The fix.★ The 26 forks are restored from the 1.11 tree, so this mod now has the
// same flat script set every other working mod here ships (DeltaAirForce, RMRPG, RPG,
// SEX, SWRPG, TSC, Tac, War40k all carry server.cs/item.cs/turret.cs/game.cs/
// station.cs -- StarWars, Annihilation and Starsiege were the only three without, and
// all three played as base). base's own exec list at console.cs:215-265 and inside
// createServer IS the loader for a flat mod: `exec(Item)` etc. resolve to the MOD's
// copy because `StarWars\scripts` precedes `base\scripts` on the search path, and the
// restored server.cs ends its chain with `exec(swloadscripts)` -- the file that
// registers the 11 WPN_*, 7 VEH_* and 14 ARM_* datablocks, which until now NOTHING
// in the tree exec'd.
//
// The 1.40 subtree is left on disk but is now exec'd by nothing (inert). The 37 flat
// 1.11 files that are byte-identical to our modern base\scripts are deliberately NOT
// restored -- base's copies serve them, so the mod tracks base for those.
//
// Only the three collision-free helpers stay. NOT common.cs: it also does
// run("Include") / run("Schedule"), bare names that config\Presto also defines, and
// exec'ing it pulled in Presto's tree whose Event.cs <-> writer/event.cs recurse
// forever -- MEASURED, a -mod StarWars host died rc=3221225725 (STACK_OVERFLOW).
// Sprintf is required (game.cs and BotHud.cs call sprintf); Timestamp and Compat
// supply timestamp::format / String::rpad, the 1.40 plugin commands admin.cs and the
// iplog path expect.
exec( "Sprintf" );
exec( "Timestamp" );
exec( "Compat" );

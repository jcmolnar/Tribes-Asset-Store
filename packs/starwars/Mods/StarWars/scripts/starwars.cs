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

// REPACK FIX 2026-08-27: bootstrap this mod's own script tree.
//
// Base execs <ModName>.cs as the mod entry (console.cs:187 ExecModScripts, called at :267,
// AFTER base's own client/server/game at :249-252, so what we define here overrides base).
// This file set team names and nothing else, which was correct for the ORIGINAL StarWars:
// that release shipped 118 scripts entirely FLAT, and base's fixed exec list IS the loader
// for a flat mod -- exec("server.cs") found the MOD's server.cs.
//
// The build shipped here is a restructured release: 256 scripts under server/ client/ gui/
// tags/. 63 of the original's flat scripts moved into subdirectories -- item.cs ->
// server/items, station.cs -> server/items/stations, server.cs and game.cs -> server. The
// search path is FLAT, so those bare names hit BASE's copies and the mod half-loaded:
// armordata.cs and baseProjData.cs stayed flat, so player models and weapon sounds were
// right while inventory and weapons came from base (player report 2026-08-26).
//
// So: exec the nested equivalents of exactly what base execs by name. server/server.cs
// carries this mod's createServer, which is what chains server/loadall, sound/nsound and
// server/items/loadall at server creation -- the mod's own design, left alone.
//
// ONLY the three collision-free helpers are pulled in, NOT common.cs. common.cs additionally
// does run("Include") and run("Schedule"), and those are BARE names that config\Presto also
// defines (Presto/Include.cs, Presto/Schedule.cs). Exec'ing common.cs therefore pulled in
// Presto's tree, whose Event.cs <-> writer/event.cs <-> events.cs exec each other forever:
// MEASURED, a -mod StarWars host died with rc=3221225725 (STACK_OVERFLOW) and a log full of
// repeating "Executing presto\Event.cs / presto\writer\event.cs". Run/Autoload/Sprintf have
// no Presto counterpart. The engine's own schedule() covers the schedule() calls in the
// server chain, so SW's Schedule.cs is not needed.
exec( "Run" );
exec( "Autoload" );
exec( "Sprintf" );
exec( "server/server" );
exec( "server/game" );
exec( "client/loadall" );

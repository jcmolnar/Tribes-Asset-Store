// Tribes Arena v3.0 by Lizard (2002-06-15; versions up to 2.3 by Rasia) -- entry script
// (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod TribesArena).
// Tribes Arena is a GAME TYPE, not a weapons mod: an Arena map ends with exec(arena), and
// scripts\arena.cs then loads arenaAdmin.cs / arenaComchat.cs and (if switched on in the
// settings) lizStats.cs. Weapons, armor and stations are the stock game's.
// The original was installed into base\ ; its readme has the host add
//    exec("ServerConfig.cs");
// to config\autoexec.cs. That one line is what this file does:
//
// Settings: Mods\TribesArena\ArenaConfig.cs (admin passwords and lists, Arena options, stats).
// A copy in config\ wins over the pack's.
exec("ArenaConfig.cs");

echo("Tribes Arena 3.0 (TribesArena): settings are in Mods\\TribesArena\\ArenaConfig.cs; host an Arena map (Arena_01).");

// Reality Bites 2.0 -- Modern Client (1.50) entry script.
//
// console.cs ExecModScripts() execs "<word>.cs" for every -mod word, so this file runs
// for "-mod rb2" after base's own client.cs/server.cs chain and before the prefs files.
//
// Reality Bites is a FLAT mod: its scripts\ folder carries its own server.cs, item.cs,
// game.cs, objectives.cs, ... which precede base\scripts on the search path, so the
// stock exec chain in console.cs and createServer resolves to the mod's copies without
// any wiring here. The mod's server.cs is the MiniMod v0.6 loader: at exec time it runs
// MiniMod::Load::Functions() (plugins\*.Functions.cs) and MiniMod::Init::Client(), and
// inside createServer it runs MiniMod::Init::Server(), which execs every
// plugins\*.item.cs (the mod's weapons). Those globs resolve relative to Mods\rb2, so
// the plugins\ folder must stay at the mod root.
//
// Server settings (join message, SAD admin passwords, cap points, kickback, ...) live in
// scripts\realitybites2.cs; the mod's admin.cs execs it by name inside createServer. A
// host operator may override it with a copy at config\realitybites2.cs -- config is
// first on the search path and wins.

echo("Reality Bites 2.0 (rb2) -- Modern Client port, entry script rb2.cs");

// Shims for the four calls the mod makes into scripts it never shipped (Stormbots).
exec("rb2Compat.cs");

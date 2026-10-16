// Football1v1.cs -- entry script for the Football 1vs1 Mod (Taserman, 2003) on the 1.50 client.
// console.cs runs this once at boot (ExecModScripts), after base client.cs / server.cs / game.cs
// and BEFORE base serverDefaults.cs and serverPrefs.cs.
//
// What is in this folder:
//   scripts\fb1vs1mod.cs    the 1vs1 rules.  Every 1vs1 map ends with  exec(objectives); exec(fb1vs1mod);
//   scripts\fb1vs1reset.cs  put back by fb1vs1mod when the server leaves a 1vs1 map
//   scripts\obs.cs          optional observer script from the original zip; nothing execs it
//   scripts\ (13 others)    the Football rule set the 1vs1 scripts were written on:
//                           Football Mod 1.32 "Tasermod build 3" (admin, game, fbstuff, objectives ...)
//   missions\               the six 1vs1 maps (mission type "1vs1")
// The football server.cs (scripts\server.cs) has already replaced createServer by now; it loads the
// rest when a server is created.  The stock football stadium maps in base also run under this mod,
// with the 1.32 rules.

// Football rule settings the scripts read: $TCTimer, $VoteAdminAllowed, $halftimeDelay, $MODInfo.
// Host identity, the default passwords, telnet and the hand-built 2003 rotation in it are commented
// out (//PORT-OFF:) -- set those in your own serverPrefs.cs / autoexec.cs.
exec("FootballserverConfig.cs");

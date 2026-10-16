// AAOD Mod 1.6Ex (scripts.vol dated 2000-02-18), from the AAOD clan (the readme names no
// author; server admin Valya[AAOD], bug reports to darkserpent@home.com) -- Modern Tribes (1.50)
// entry script. Not part of the original release ("tribes.exe -mod AAOD"; the release's own
// AAOD.cs inside scripts.vol was an empty file).
// Launch here:  -mod AAOD
//
// Settings. The mod reads config\AAOD_cfg.cs when that file exists and its built-in
// scripts\AAOD_Default.cs otherwise (server.cs). The release's sample of that file is next to
// this script as AAOD_cfg-sample.cs: to use it, copy it to config\AAOD_cfg.cs and edit it. Note
// that the sample turns experience tracking ON ($TrackExp = 2: every player who joins is written
// to config\AAODPlayers.cs); the built-in default is OFF.
//
// Not carried over from the release:
//  * AAODPlayers.cs, the "sample players file": 277 real player names of the author's server with
//    their admin flags and passwords.
//  * AAODC.cs / AAODVerify.cs: optional scripts for the PLAYER's own game (voice-pack menus; the
//    password sender for the mod's auto-admin list).
//  * AAODConfig.cs: a sample server config with a placeholder admin password.
echo(">> AAOD Mod 1.6Ex");

$MODInfo = "AAOD Mod 1.6Ex\nwww.bdtech.net/aaod";

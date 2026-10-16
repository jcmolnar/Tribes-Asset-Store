// Ultra Renegades VX5 "Infinite" 6 [VX] -- entry script (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod UltraVX5Infinite). The mod itself is the
// flat script set in scripts\ (its own server.cs, admin.cs, item.cs ...); nothing has to be exec'd
// from here. The original launch line was
//     Tribes.exe +exec VX5Config -mod Ultra_RenegadesVX5
// and VX5Config.cs only held ordinary server prefs (host name, team names, time limit, the two
// admin passwords, a telnet port). None of that is stamped by this pack: set it the usual way.
//
// Admin log-on (the F1/SAD password box, remoteAdminPassword in scripts\admin.cs) is OFF until
// the host sets a password of their own, for example in config\autoexec.cs:
//     $AdminPassword      = "something only you know";   // super admin ("God Admin")
//     $MatchAdminPassword = "another one";               // public admin
// No password ships with this pack. The host's own (listen-server) client is super admin.
//
// Smurf log: scripts\Iplogger.cs keeps one line per address with the names seen from it in
// config\thunderinfo.cs, and shows it to super admins when a player connects. Delete that file to
// clear it.

echo("Ultra Renegades VX5 Infinite 6 [VX] (UltraVX5Infinite) loaded.");

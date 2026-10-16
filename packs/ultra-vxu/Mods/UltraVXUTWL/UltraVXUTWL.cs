// UltraVXU 5.0 TWL -- entry script (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod UltraVXUTWL). The mod itself is the flat
// script set in scripts\ (its own server.cs, admin.cs, item.cs ...); nothing has to be exec'd
// from here. The original launch line was
//     tribes.exe +exec serverconfig -mod UltraVXU
// and serverconfig.cs only held ordinary server prefs (host name, team names, time limit 35,
// respawn time 1, the admin password, a telnet port and password). None of that is stamped by
// this pack: set it the usual way. (The archive's TeamWarfare ladder rules, a Word document, are
// not shipped.)
//
// First drop: the server shows a menu "Choose Break Mode:" (0 Impulse Breaks (Hard), 1 Air Breaks
// (Soft)); the player spawns when a digit is pressed. Grenade key = air brake, beacon key = speed
// booster (Tab menu, "Modification Info").
//
// Admin log-on (the F1/SAD password box, remoteAdminPassword in scripts\admin.cs) is OFF until
// the host sets a password of their own, for example in config\autoexec.cs:
//     $AdminPassword = "something only you know";
// No password ships with this pack. The host's own (listen-server) client is super admin.

echo("UltraVXU 5.0 TWL (UltraVXUTWL) loaded.");

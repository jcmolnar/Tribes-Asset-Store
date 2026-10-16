// Ultra Renegades VX5 "Flag Hunter" v1.5 -- entry script (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod UltraVX5Hunter). The mod itself is the flat
// script set in scripts\ (its own server.cs, admin.cs, item.cs ...); nothing has to be exec'd
// from here. The archive documents no launch line; its folder was Ultra_RenegadesVX5, so the
// original was started like every VX5 build:  Tribes.exe -mod Ultra_RenegadesVX5
//
// Flag Hunter maps (missions\, type "Flag Hunter") exec scripts\FlagHunter.cs, which swaps in the
// Flag Hunter rules, spawn kit (Hunter armor, Raptor rifle, Torque, rocket launcher) and its own
// Tab menu (GREED / HOARD / TEAM Hunters). On any other map the mod plays as VX5 Infinite.
// Records are kept in config\HunterRecords.cs.
//
// Admin log-on (the F1/SAD password box, remoteAdminPassword in scripts\admin.cs) is OFF until
// the host sets a password of their own, for example in config\autoexec.cs:
//     $AdminPassword      = "something only you know";   // super admin
//     $MatchAdminPassword = "another one";               // public admin
// No password ships with this pack. The host's own (listen-server) client is super admin.
//
// Smurf log: scripts\Iplogger.cs keeps one line per address with the names seen from it in
// config\thunderinfo.cs, and shows it to super admins when a player connects. Delete that file to
// clear it.

echo("Ultra Renegades VX5 Flag Hunter 1.5 (UltraVX5Hunter) loaded.");

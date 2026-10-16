// Ultra Renegades VXC ("VX Combination", 2001, MuRdeR Inc.) -- entry script (Modern Tribes client
// 1.50 port).
//
// The mod loader runs this file once at start-up (-mod UltraVXC). The mod itself is the flat
// script set in scripts\ (its own server.cs, admin.cs, item.cs ...); nothing has to be exec'd
// from here. The original launch line was
//     Tribes.exe +exec UltraVXC.cs +exec ServerConfig.cs -mod Ultra_RenegadesVXC
//
// UltraVXC.cs of the archive held the admin lockouts and anti-TK levels below; no script loads
// them, so they are seeded here, only when unset: a host's own values (config\autoexec.cs) win.
// Not set by the archive, so off: PAVote (vote a player admin), PVKick (vote kick), PAExecute,
// PAFairTeams, PVTeamDamage, PVTourneyMode, PVFairTeams, SafeStation, StationTime.
if($ultra_renegades::tkLimit == "")
{
   $ultra_renegades::BanKickTime = "120";
   $ultra_renegades::fairTeams = "true";
   $ultra_renegades::PABan = "false";
   $ultra_renegades::PAKick = "true";
   $ultra_renegades::PAMission = "true";
   $ultra_renegades::PAModOptions = "false";
   $ultra_renegades::PAResetDefaults = "false";
   $ultra_renegades::PATeamChange = "true";
   $ultra_renegades::PATeamDamage = "true";
   $ultra_renegades::PATeamInfo = "false";
   $ultra_renegades::PATimelimit = "false";
   $ultra_renegades::PATourneyMode = "false";
   $ultra_renegades::PVMission = "true";
   $ultra_renegades::tkClientLvl = "0";
   $ultra_renegades::tkLimit = "1";
   $ultra_renegades::tkMultiple = "1";
   $ultra_renegades::tkServerLvl = "3";
}
//
// ServerConfig.cs of the archive held ordinary server prefs (host name, team names, time limit
// 25, packet rate) plus three admin passwords, a telnet port and password and a lock password.
// None of that is stamped by this pack: set it the usual way.
//
// Admin log-on (the F1/SAD password box, remoteAdminPassword in scripts\admin.cs) is OFF until
// the host sets passwords of their own, for example in config\autoexec.cs:
//     $PublicPassword = "one";          // public admin (what the lockouts above apply to)
//     $AdminPassword  = "another";      // super admin
//     $OwnerPassword  = "a third";      // God admin: ban, gag, "Reset Server" (QUITS the server)
//     $Server::pwoption = "join word";  // the join password "Lock Server" switches on
// No password ships with this pack. The host's own (listen-server) client is super admin.
// Optional: $PA::noKick = "true" (public admins cannot be kicked by public admins),
// $Name::noKicka / $Name::noKickb ... (player names only a super admin can kick).

echo("Ultra Renegades VXC (UltraVXC) loaded.");

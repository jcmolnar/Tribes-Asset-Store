// Ultra Renegades VX5 "-IX-" 1.0 -- entry script (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod UltraVX5IX). The mod itself is the flat
// script set in scripts\ (its own server.cs, admin.cs, item.cs ...); nothing has to be exec'd
// from here. The original launch line was
//     Tribes.exe +exec VX5Config -mod Ultra_RenegadesVX5
// VX5Config.cs only held ordinary server prefs (host name, team names, time limit, the two admin
// passwords, a telnet port). None of that is stamped by this pack: set it the usual way.
//
// IX admin settings. The archive shipped config\ixadmin.cs (the Insomniax lockouts and anti-TK
// levels) but no script of this build loads it, and with every value unset the public-admin and
// voting menus are empty. The archive's values are seeded here, only when unset, so a host's own
// config (config\autoexec.cs, or an exec of a saved ixadmin.cs) wins. ixSave() in the console
// writes the current values to config\ixadmin.cs.
if($Insomniax::tkLimit == "")
{
   $Insomniax::BanKickTime = "600";
   $Insomniax::fairteams = "true";
   $Insomniax::LeaveAreaTime = "15";
   $Insomniax::PABan = "true";
   $Insomniax::PAFairTeams = "true";
   $Insomniax::PAGag = "true";
   $Insomniax::PAKick = "true";
   $Insomniax::PAMission = "true";
   $Insomniax::PAModOptions = "true";
   $Insomniax::PAResetDefaults = "true";
   $Insomniax::PATeamChange = "true";
   $Insomniax::PATeamDamage = "true";
   $Insomniax::PATeamInfo = "true";
   $Insomniax::PATimeLimit = "true";
   $Insomniax::PATourneyMode = "true";
   $Insomniax::PAVote = "true";
   $Insomniax::PSkin = "true";
   $Insomniax::PVFairTeams = "true";
   $Insomniax::PVKick = "true";
   $Insomniax::PVMission = "true";
   $Insomniax::PVTeamDamage = "true";
   $Insomniax::PVTourneyMode = "true";
   $Insomniax::SafeStation = "true";
   $Insomniax::StationTime = "15";
   $Insomniax::tkClientLvl = "0";
   $Insomniax::tkLimit = "3";
   $Insomniax::tkMultiple = "2";
   $Insomniax::tkServerLvl = "2";
}
// The same file also carried the team energy setting; scripts\game.cs has its own line commented
// out, so without this every team starts with no energy and the stations sell nothing.
if($DefaultTeamEnergy == "")
   $DefaultTeamEnergy = "Infinite";
//
// Admin log-on (the F1/SAD password box, remoteAdminPassword in scripts\admin.cs) is OFF until
// the host sets a password of their own, for example in config\autoexec.cs:
//     $AdminPassword      = "something only you know";   // super admin
//     $MatchAdminPassword = "another one";               // public admin
// No password ships with this pack. The host's own (listen-server) client is super admin.
// The IX user list (config\ixUserList.cs: named users, per-user passwords, auto-admin by address
// mask) is optional and is NOT shipped; without it that feature is off.
//
// Smurf log: scripts\Iplogger.cs keeps one line per address with the names seen from it in
// config\thunderinfo.cs, and shows it to super admins when a player connects. Delete that file to
// clear it.

echo("Ultra Renegades VX5 -IX- 1.0 (UltraVX5IX) loaded.");

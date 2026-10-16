// Mega Renegades 1.3a ("Ultra_Mega_Mod": update by Dr. NoRtOn, original mod by {URCM}Iceman and
// {URCM}Gorgon, installer by Pestilence) -- entry script (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod UltraMegaMod). The mod itself is the flat
// script set in scripts\ (its own server.cs, admin.cs, item.cs ...); nothing has to be exec'd
// from here. The original launch lines were
//     InfiniteSpawn.exe *tribes -mod Ultra_Mega_Mod -dedicated
//     tribes -mod Ultra_Mega_Mod
// with a config\autoexec.cs that only held ordinary settings (a join password, the admin
// password, packet rate/size, log mode). None of that is stamped by this pack.
//
// The 61 maps of the installer are in missions\ (it copied them into base\missions).
//
// Admin switches. The archive shipped NO values for the mod's $mega:: switches, so on a fresh
// server they are all off: no vote kick / vote mission / vote admin, nothing for public admins,
// Fair Teams off, a kick carries no re-join delay. A super admin can set them in game (Tab,
// "Server Options"), or the host can set them before the server starts, for example in
// config\autoexec.cs:
//     $mega::BanKickTime = 300;          // seconds a kicked player stays out
//     $mega::fairTeams = "true";
//     $mega::PAKick = "true";            // public admins may kick; also switches vote kick on
//     $mega::PAMission = "true";         // ... change mission; also vote mission
//     $mega::PAVote = "true";            // players may vote a player admin
//     $mega::PABan, PATeamChange, PATeamDamage, PATourneyMode, PATimeLimit, PAResetDefaults,
//     PAModOptions, PATeamInfo, PersonalSkin = "true" / "false"
//     $mega::tkLimit = 3; $mega::tkMultiple = 2; $mega::tkServerLvl = 0..3; $mega::tkClientLvl = 0..1;
//
// Admin log-on (the F1/SAD password box, remoteAdminPassword in scripts\admin.cs) is OFF until
// the host sets passwords of their own:
//     $PublicPassword = "one";       // public admin (what the PA switches above apply to)
//     $AdminPassword  = "another";   // super admin
//     $OwnerPassword  = "a third";   // God admin (may also strip admins)
// No password ships with this pack. The host's own (listen-server) client is super admin.
// Optional: $Owner::Name (log-on message), $Admin::KickMessage, $ExportAKicks / $ExportCKicks
// (append kicks to config\KickList.log).

echo("Mega Renegades 1.3a (UltraMegaMod) loaded.");

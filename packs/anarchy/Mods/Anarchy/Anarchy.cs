// ANARCHY mod 2.0 by DRONE1000 (www.teamanarchy.com/tribes), server build and documentation by
// ^Plasmatic^, January-February 2001 -- settings + entry script for Modern Tribes 1.50.
//
// The original was started with (Anarchy.lnk in the release):
//   InfiniteSpawn.exe *tribes.exe -mod Anarchy +exec Anarchy.cs +exec serverPrefs.cs -dedicated
// Anarchy.cs was this file, kept in the config folder; the mod's game.cs also execs "Anarchy.cs"
// at every mission load, so the values below are re-applied on every map. A file named
// config\Anarchy.cs, if you make one, is found first and replaces this one entirely.
//
// NOT carried over from the 2001 file, on purpose:
//   * the three admin passwords, which all shipped as the same published word (see below);
//   * $TelnetPort / $TelnetPassword, $pref::PacketRate / $pref::PacketSize, $modList;
//   * serverPrefs.cs (host name, port, master servers, another copy of the admin password);
//   * adminuserlist.cs as shipped: three named accounts with the password "123", level God and
//     the address mask *.*.*.* = automatic God admin for anyone using one of those three names.
//     AdminUserList.cs beside this file is the same template with the list switched off.

// Line shown under the "Anarchy mod" notice while a player connects.
$plasmatic = "";

$Anarchy::BanKickTime = "1800";     // seconds a kicked player stays banned
$Anarchy::fairTeams = "false";      // true: Change Teams only offers the smaller team

// Public Admin lockouts: "true" = an admin who is not a super admin may use the option
// (PAVote, PAKick and PAMission also switch the matching public VOTE on).
$Anarchy::PABan = "false";
$Anarchy::PAKick = "false";
$Anarchy::PAMission = "true";
$Anarchy::PAModOptions = "true";
$Anarchy::PAResetDefaults = "true";
$Anarchy::PATeamChange = "true";
$Anarchy::PATeamDamage = "true";
$Anarchy::PATeamInfo = "true";
$Anarchy::PATimelimit = "true";
$Anarchy::PATourneyMode = "false";
$Anarchy::PAVote = "false";

// Anti team kill: client level 0 = vote option, 1 = kick option; server level 0 = log only,
// 1 = auto vote, 2 = auto vote until kicked, 3 = auto kick.
$Anarchy::tkClientLvl = "3";
$Anarchy::tkLimit = "5";
$Anarchy::tkMultiple = "3";
$Anarchy::tkServerLvl = "3";
$Anarchy::Spawnclass = "false";

// Logs. The 2001 file had all three on; they append to files in the config folder for ever.
$ConnectLog = false;     // name and address of everyone who connects -> config\Connect.log
$ExportAKicks = false;   // kicks by admins -> config\KickList.log
$ExportCKicks = false;   // kicks by vote -> config\KickList.log

// Centre-print shown to a player an admin kicks ("\n" starts a new line).
$Admin::KickMessage = "For being a complete Idiot, and total moron.....\n\n You are being kicked off of this server. \n\n Come back when you no longer have an attack of the STUPIDS.";

// Personal skins (Tab menu: Use Personal Skin / Use Team Skin).
$Anarchy::PersonalSkin = "true";

// "true": nobody can be shot out of a station (keep the station time limit on with this).
$StationLockTD = "false";   // with team damage off
$StationLockNTD = "true";   // with team damage on
$Anarchy::StationTime = "60";   // seconds before an inventory station ejects its user (20-60)

$PA::noKick = "True";   // true: public admins cannot be kicked by a vote

// Player names that a vote or a public admin cannot kick.
$Name::noKicka = "";
$Name::noKickb = "";
$Name::nokickc = "";
$Name::nokickd = "";

// Name announced as "the owner" when it logs in with the super admin password.
$Owner::Name = "";

// SAD passwords. The release shipped all three as "BETTERchangeMEidiot", printed in its readme:
// anyone who typed sad("BETTERchangeMEidiot") on an unedited server became God admin.
// They ship EMPTY here (empty = that login is off). Set your own before using them.
//   $OwnerPassword  -> God admin (cannot be kicked, stripped, frozen or team-changed)
//   $PublicPassword -> public admin
//   $AdminPassword  -> super admin (this is also the stock Tribes admin password; set it in your
//                      server prefs, it is not touched here)
$OwnerPassword = "";
$PublicPassword = "";

echo(">> ANARCHY mod 2.0 settings loaded");

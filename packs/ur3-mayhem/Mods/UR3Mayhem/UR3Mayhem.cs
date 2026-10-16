// Ultra_Renegades 3 Mayhem -- start-up settings (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod UR3Mayhem). It replaces the original
// config\UR3_Mayhem.cs, which the 1999 command line loaded with "+exec UR3_Mayhem.cs".
// Edit the values here; super admins can change most of them in game from the Tab menu
// (Server Options).

// Line shown to players while they connect.
$ModInfo = "Prepare for Ultra_Renegades 3 Mayhem!!!!";

// Seconds a KICKED player stays locked out. The mod's author made every kick last for the rest
// of the server session (the original value was a 71-digit number); 99999999 keeps that and
// stays a number the engine can add to the clock. Use 180 for the stock Tribes three minutes.
// A BAN from the menu is always 1800 seconds, as in the original.
$ultra_renegades3::BanKickTime = "99999999";

// Change Teams offers only the team with the fewest players.
$ultra_renegades3::fairTeams = "true";

// What a public (voted or appointed) admin may do. Super admins can always do all of it.
$ultra_renegades3::PABan = "true";
$ultra_renegades3::PAKick = "true";
$ultra_renegades3::PAMission = "true";
$ultra_renegades3::PAModOptions = "true";
$ultra_renegades3::PAResetDefaults = "true";
$ultra_renegades3::PATeamChange = "true";
$ultra_renegades3::PATeamDamage = "false";
$ultra_renegades3::PATeamInfo = "false";
$ultra_renegades3::PATimelimit = "true";
$ultra_renegades3::PATourneyMode = "false";

// "true" lets players start a vote to make someone an admin.
$ultra_renegades3::PAVote = "false";

// Anti team-kill settings (Tab menu > Server Options).
$ultra_renegades3::tkClientLvl = "0";
$ultra_renegades3::tkLimit = "5";
$ultra_renegades3::tkMultiple = "3";
$ultra_renegades3::tkServerLvl = "1";

// Remote admin logon is OFF until the host sets a password of their own, for example in
// config\autoexec.cs:   $AdminPassword = "something only you know";
// No password ships with this pack.

echo("Ultra_Renegades 3 Mayhem (UR3Mayhem) settings loaded");

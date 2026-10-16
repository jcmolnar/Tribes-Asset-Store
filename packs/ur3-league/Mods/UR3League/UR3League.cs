// Ultra Renegades 3 League 1.8 by {187}George W. and Dr. NoRtOn (2001-04-30), original League
// mod by ($A$)FSB-Deacon, UR3 by URG_Thrash -- entry script for Modern Tribes 1.50.
// Original launch line (1.6 shortcut; 1.7 / 1.8 changed only the folder name):
//   InfiniteSpawn.exe *tribes +exec league16.cs +exec ultra_renegades3.cs -mod ultra_renegades3_league16 -dedicated
// The values below are the 1.6 archive's config\ultra_renegades3.cs (1.7 and 1.8 shipped no
// settings file and say "install over 1.6"). league16.cs was a host settings template (server
// name, admin and telnet passwords, port, master list): not carried over. No password ships.

// Public Admin lockouts: "true" = an admin who is not a super admin may use the option.
$ultra_renegades::PABan = "false";
$ultra_renegades::PAExecute = "true";
$ultra_renegades::PAFairTeams = "true";
$ultra_renegades::PAKick = "true";
$ultra_renegades::PAMission = "true";
$ultra_renegades::PAModOptions = "false";
$ultra_renegades::PAResetDefaults = "false";
$ultra_renegades::PATeamChange = "true";
$ultra_renegades::PATeamDamage = "true";
$ultra_renegades::PATeamInfo = "true";
$ultra_renegades::PATimeLimit = "true";
$ultra_renegades::PATourneyMode = "true";
$ultra_renegades::PAVote = "false";

// Public Vote lockouts: "true" = players may start that vote.
$ultra_renegades::PVFairTeams = "false";
$ultra_renegades::PVKick = "false";
$ultra_renegades::PVMission = "true";
$ultra_renegades::PVTeamDamage = "true";
$ultra_renegades::PVTourneyMode = "false";

$ultra_renegades::fairteams = "true";
$ultra_renegades::PSkin = "true";
$ultra_renegades::SafeStation = "true";
$ultra_renegades::StationTime = "15";

// Anti team kill: client level 0 = vote option, 1 = kick option; server level 0 = log only,
// 1 = auto vote, 2 = auto vote until kicked, 3 = auto kick.
$ultra_renegades::tkClientLvl = "0";
$ultra_renegades::tkLimit = "3";
$ultra_renegades::tkMultiple = "2";
$ultra_renegades::tkServerLvl = "2";

// The 2001 file had a 28-digit number here; the script that would read it is commented out.
$ultra_renegades::BanKickTime = "99999999";
$DefaultTeamEnergy = "Infinite";

// PORT: this build's game.cs never sets the stock flag-to-stand timer its objectives.cs reads
// (Find and Retrieve / Capture and Hold maps told the carrier "0 sec"). Stock value.
if($flagToStandTime == "")
   $flagToStandTime = 180;

echo("Ultra Renegades 3 League 1.8 loaded (mod word UR3League).");

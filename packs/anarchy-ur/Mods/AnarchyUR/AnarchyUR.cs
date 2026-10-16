// Ultra Renegades 3 .v. Anarchy BETA (scripts.vol of 2003-02-10): the Anarchy tribe's edit of
// Ultra Renegades 3 League (UR3 by URG_Thrash, League version by ($A$)FSB-Deacon, updated by
// Dr. NoRtOn, height limit by {187}George W., VX rifles by Kissie-Poo) -- entry script for
// Modern Tribes 1.50.
// The archive is the scripts.vol alone: no readme, no shortcut, no settings file. The League
// builds were started with
//   InfiniteSpawn.exe *tribes +exec league16.cs +exec ultra_renegades3.cs -mod <folder> -dedicated
// and the values below are League 1.6's config\ultra_renegades3.cs, the settings file this
// build's admin.cs reads ($ultra_renegades::*). No password ships.

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
$ultra_renegades::SafeStation = "true";
$ultra_renegades::StationTime = "15";

// Anti team kill: client level 0 = vote option, 1 = kick option; server level 0 = log only,
// 1 = auto vote, 2 = auto vote until kicked, 3 = auto kick.
$ultra_renegades::tkClientLvl = "0";
$ultra_renegades::tkLimit = "3";
$ultra_renegades::tkMultiple = "2";
$ultra_renegades::tkServerLvl = "2";

// Seconds a KICKED player stays banned (admin.cs Admin::kick; a ban is 1800 s). The League 1.6
// file had a 28-digit number here, which made every kick permanent; 180 is the stock kick time.
$ultra_renegades::BanKickTime = "180";
$DefaultTeamEnergy = "Infinite";

// PORT: this build's game.cs never sets the stock flag-to-stand timer its objectives.cs reads
// (Find and Retrieve / Capture and Hold maps told the carrier "0 sec"). Stock value.
// ($WaitThrowTime is also never set: left alone, the grenade key is this mod's air brake.)
if($flagToStandTime == "")
   $flagToStandTime = 180;

echo("Ultra Renegades 3 .v. Anarchy BETA loaded (mod word AnarchyUR).");

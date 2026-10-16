// TiZ -- server settings (added by the Modern Tribes port).
//
// Loaded at every mission load: the mod's game.cs loaded a file called renegades.cs there, and
// the TiZ release never shipped one. Without it every admin setting below was empty: players had
// no "Vote to kick" or "Vote to change mission" entry, and the team-kill counter divided by an
// empty $Insomniax::tkLimit. A copy of this file in config\ wins over this one.
//
// The values are the ones the Renegades 2K release (same Alliance engine, October 1999) shipped
// in its renegades.cs. "PA..." = what a public (voted) admin may do, and for PAKick / PAMission
// also whether players may vote on it. A super admin can change them from the Tab menu
// (Server Options); they are read again from this file at every mission load.
$Insomniax::BanKickTime = "999";
$Insomniax::fairTeams = "true";
$Insomniax::LeaveAreaTime = "15";
$Insomniax::PABan = "true";
$Insomniax::PAKick = "true";
$Insomniax::PAMission = "true";
$Insomniax::PAModOptions = "true";
$Insomniax::PAResetDefaults = "true";
$Insomniax::PATeamChange = "true";
$Insomniax::PATeamDamage = "true";
$Insomniax::PATeamInfo = "true";
$Insomniax::PATimeLimit = "true";
$Insomniax::PATourneyMode = "true";
$Insomniax::PAVote = "false";
$Insomniax::tkClientLvl = "0";
$Insomniax::tkLimit = "3";
$Insomniax::tkMultiple = "2";
$Insomniax::tkServerLvl = "2";

// Not set here on purpose: $AdminPassword (set it in your own server config; empty = no password
// login, the host's own client is always admin) and $RandomMissions (true = pick each next map
// at random instead of following the map rotation).

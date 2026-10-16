// Ultra_Renegades2 -- admin settings (Modern Tribes client 1.50 port).
//
// game.cs execs this file at EVERY mission load (it was config\ultra_renegades~1.cs in 1999),
// so a value changed in game from the Tab menu (Server Options) lasts until the next map and
// the values below come back. Edit them here to keep them.
// The values are the ones the archive shipped, except BanKickTime (see below).

// Seconds a KICKED player stays locked out. The mod's author made every kick last for the
// rest of the server session (the original value was a 24-digit number); 99999999 keeps that
// and stays a number the engine can add to the clock. Use 180 for the stock three minutes.
// A BAN from the menu is always 1800 seconds, as in the original.
$Insomniax::BanKickTime = "99999999";

// Change Teams offers only the team with the fewest players.
$Insomniax::fairTeams = "true";

// What a public (voted or appointed) admin may do. Super admins can always do all of it.
// PAKick also switches "Vote to kick" for players, PAMission "Vote to change mission".
$Insomniax::PABan = "true";
$Insomniax::PAKick = "true";
$Insomniax::PAMission = "true";
$Insomniax::PAModOptions = "true";
$Insomniax::PAResetDefaults = "true";
$Insomniax::PATeamChange = "true";
$Insomniax::PATeamDamage = "false";
$Insomniax::PATeamInfo = "false";
$Insomniax::PATimelimit = "true";
$Insomniax::PATourneyMode = "false";

// "true" lets players start a vote to make someone an admin.
$Insomniax::PAVote = "true";

// Anti team-kill settings (Tab menu > Server Options).
$Insomniax::tkClientLvl = "0";
$Insomniax::tkLimit = "5";
$Insomniax::tkMultiple = "3";
$Insomniax::tkServerLvl = "1";

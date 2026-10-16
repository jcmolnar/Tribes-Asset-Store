// Alliance -- server settings (added by the Modern Tribes port).
//
// Loaded when the server is created and again at every mission load (the engine's game.cs
// loaded a file called renegades.cs there; Alliance.zip never shipped one). A copy of this file
// in config\ wins over this one.

// Which rule set runs on the engine: "pure" (Pure Alliance: Sprint / Commando / Loader /
// Destroyer classes), "base" (Base Tribes: the three stock armours and the stock weapons) or
// "renegades" (Renegades Alliance: Scout, Spy, Sniper, Mercenary, Engineer, Burster, Alien,
// Cyborg). Read once, when the server is created.
$Alliance::RuleSet = "pure";

// The admin settings below are the values the Renegades 2K release (same engine, October 1999)
// shipped in its renegades.cs. "PA..." = what a public admin may do, "PV..." = what players may
// vote on. A super admin can change them from the Tab menu (IX-Admin Settings); they are read
// again from this file at every mission load.
$Insomniax::BanKickTime = "999";
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
$Insomniax::PAVote = "false";
$Insomniax::PSkin = "true";
$Insomniax::PVFairTeams = "false";
$Insomniax::PVKick = "true";
$Insomniax::PVMission = "true";
$Insomniax::PVTeamDamage = "true";
$Insomniax::PVTourneyMode = "true";
$Insomniax::SafeStation = "true";
$Insomniax::StationTime = "20";
$Insomniax::tkClientLvl = "0";
$Insomniax::tkLimit = "3";
$Insomniax::tkMultiple = "2";
$Insomniax::tkServerLvl = "2";

// Not set here on purpose: $AdminPassword (set it in your own server config; empty = no
// password login, the host's own client is always admin) and $RandomMissions (true = pick each
// next map at random instead of following the map rotation).

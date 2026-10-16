// Ultra-ZX Infinite -- settings.  PORT (Modern Tribes 1.50): the archive's config\SettingsURZX.cs
// with its passwords, its telnet lines and one ban time removed (see below). scripts\server.cs
// execs this file every time the server starts, so values changed from the Tab menu last until
// the next server start.

// Seconds an address stays banned after a KICK (admin kick, vote kick, team-kill auto kick).
// The archive shipped 999999999999999999999999 here; stock Tribes uses 180. A ban from the Tab
// menu is always 1800 seconds.
$mega::BanKickTime = "180";

// Change Teams offers only the team with fewer players.
$mega::fairTeams = "true";

// What a PUBLIC admin may do (super admins may always). The PAKick and PAMission switches also
// decide whether players can start a kick vote / a mission vote; PAVote = vote a player admin.
$mega::PABan = "false";
$mega::PAKick = "true";
$mega::PAMission = "true";
$mega::PAModOptions = "false";
$mega::PAResetDefaults = "false";
$mega::PATeamChange = "true";
$mega::PATeamDamage = "true";
$mega::PATeamInfo = "false";
$mega::PATimelimit = "true";
$mega::PATourneyMode = "false";
$mega::PAVote = "false";

// Team-kill protection: server level 0 log only, 1 auto vote, 2 vote then kick, 3 auto kick;
// client level 0 = victim may start a vote, 1 = victim may kick.
$mega::tkClientLvl = "0";
$mega::tkLimit = "5";
$mega::tkMultiple = "3";
$mega::tkServerLvl = "1";

// Shown to a player while an admin kick is in progress.
$Admin::KickMessage = "For being a complete Idiot, and total moron.....\n\n You are being kicked off of this server. \n\n Come back when you no longer have an attack of the dumbass.";

$PA::noKick = "True";  // if set to true, public admins cant be kicked by a vote

// Admin passwords for the SAD box. "" = that level is switched off.
$PublicPassword = "";  // public admin
$AdminPassword = "";   // super admin
$OwnerPassword = "";   // "God" admin: may kick, strip or blow up any other admin

$UltraZX::Infinite::Boost = "true";      // If set to True, boosts are infinite
$UltraZX::Infinite::Brake = "true";      // If set to True, brakes are infinite
$UltraZX::Infinite::RepairKit = "true";  // If set to True, repair kits are infinite


///////////////////////////
// NAPPY COCAINE OPTIONS //
///////////////////////////
// PORT (Modern Tribes 1.50): this is the release's CocaineOptions.cs with two changes, both
// marked PORT below: the default super admin password and the author's own ban entry are
// not active. Everything else is the release's text and values.

////////////////////////////////////////////////////////////
// Personal Admin Passwords
// ---------------------------------------------------------
// This section lets you set up your Nappy Cocaine admins.
// Each admin can have their own password.
//
// SYNTAX:
// $CocaineAdmin[number] = "password, admin type, username";
//
// WHAT IT MEANS:
// number = The admin number. Starts at 0. Add 1 for every admin.
// admin type = Choose "regular" or "super".
// username = The name of the admin.
//
// EXAMPLE:
// $CocaineAdmin[0] = "abc123, super, Nuke_Whore";
// $CocaineAdmin[1] = "hamsters, regular, Railgun_Whore";
//
// Add your Admins below:
// ---------------------------------------------------------
// PORT: the release shipped the line below live, so every server that did not edit this file
// had the same super admin password. It is a comment now: no admin password exists until you
// add your own line (numbers start at 0 and must not skip). Passwords are compared as exact
// text. A wrong password is written to the server log as typed.
// $CocaineAdmin[0] = "changeme, super, CocaineAddict";


////////////////////////////////////////////////////////////
// Perma-Banned Users
// ---------------------------------------------------------
// This section lets you perma-ban users from your server.
//
// SYNTAX:
// $BannedUser[number] = "ip address, ban type, username, reason for ban";
//
// WHAT IT MEANS:
// number = The user number. Starts at 0. Add 1 for every banned user.
// ban type = Choose "regular" or "nazi". Try a "nazi" ban if they keep coming back.
// username = Type the person's name so you don't forget who you banned. ;)
// reason for ban = (They will be told why they were banned when they try to connect.)
//
// EXAMPLE:
// $BannedUser[0] = "152.163.82.129, regular, Some_Moron, Base blocking";
// $BannedUser[1] = "63.144.35.108, nazi, Some_Hacker, Trying to crash the server";
//
// Add your Banned Users below:
// ---------------------------------------------------------
// PORT: the release shipped one live entry, the author's own ban of a 2004 address range
// (198.53.138.x). It is a comment now: the list starts empty.
// $BannedUser[0] = "198.53.138.58, nazi, SCARFACE, You're the permaban poster-boy!";


////////////////////////////////////////////////////////////
// Legacy Nappy4 Options
// ---------------------------------------------------------
// These are the original options you could set in Nappy4.
////////////////////////////////////////////////////////////
$Insomniax::BanKickTime = "600";
$Insomniax::fairTeams = "false";
$Insomniax::PABan = "false";
$Insomniax::PAKick = "true";
$Insomniax::PAMission = "true";
$Insomniax::PAModOptions = "false";
$Insomniax::PAResetDefaults = "false";
$Insomniax::PATeamChange = "true";
$Insomniax::PATeamDamage = "true";
$Insomniax::PATeamInfo = "false";
$Insomniax::PATimelimit = "false";
$Insomniax::PATourneyMode = "false";
$Insomniax::PAVote = "false";
$Insomniax::tkClientLvl = "0";
$Insomniax::tkLimit = "5";
$Insomniax::tkMultiple = "3";
$Insomniax::tkServerLvl = "0";

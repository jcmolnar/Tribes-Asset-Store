// Specialist mod for Tribes, release v2000d (7/12/00) by |PTi| and |V| ({TGO}LadyMacbeth,
// RCabrera) -- Modern Tribes (1.50) entry script AND the mod's settings file.
//
// Launch (readme):  -mod Specialist
//
// This file is run twice: once when the mod loads, and again every time a server is created
// (serverSpecialist.cs does exec("specialist.cs")), exactly like the config\Specialist.cs of the
// original archive. A copy of this file in config\ wins.
//
// NOT carried over from the archive (host-owned; set them in the Host Game screen or your own
// server config):
//   config\serverConfigSpecialist.cs  - $AdminPassword = "ChangeMe", $Server::HostPublicGame =
//       "true", $Server::Port, $Server::HostName, $Server::MaxPlayers, packet rate/size, vote
//       values, $Console::LogMode = 0 and the team names/skins below.
//   the six auto-admin accounts of config\Specialist.cs (names + address ranges of the authors).
echo(">> ");
echo(">> SPECIALIST v2000d - nine specialised armors, grenade / mine / beacon cores");
echo(">> ");

// ===== Poison Gas Cloud Config data =====
// This may slow down the game, if it is too high.
$Specialist::MaximumNumberOfGasClouds = 30;

// ===== Smart mines can recognize teammates =====
$Specialist::SmartMines = True;

// ===== Number of seconds until a hacked object is returned to its original team =====
// If zero, then the object is never returned to its original team.
$Specialist::unHackTime = 240;

// ===== AntiRape Mode makes generators and stations invincible =====
$Specialist::AntiRapeMode = "false";

// ===== Set the penalty for leaving the mission area =====
// Possible modes:
// 1. "Warn" = just warn the player
// 2. "Damage" = continuously damage the player while they are out of bounds
// 3. "InstantKill" = instantly kill a player who steps out of bounds
// 4. "DelayedKill" = warn the player and kill them if they stay out of bounds too long
$Specialist::LeaveMissionAreaPenalty = "Warn";
$Specialist::LeaveMissionAreaGracePeriod = 10;	// number of seconds before final penalty is applied

// ===== Automatically make these people admins when they connect =====
// EMPTY in this pack. The check is name + address range and nothing else: a player name can be
// typed by anyone, so only list a name together with an address range you trust.
// 1. Put the name of the admin in $Specialist::AdminName[?]; it can contain spaces, etc.
// 2. Put the IP addresses that they connect from in $Specialist::AdminIP[?, 0],
//    $Specialist::AdminIP[?, 1], etc. You can use the asterisk (*) sign to indicate a wildcard.
// 3. Put the type of admin this person is in $Specialist::AdminType[?].
//    This can be either "Admin" or "SuperAdmin".
// The list is read until the first empty name, so number the entries 0, 1, 2 ... without gaps.
//
// $Specialist::AdminName[0] = "Some Name";
// $Specialist::AdminIP[0, 0] = "192.168.1.*";
// $Specialist::AdminType[0] = "Admin";

// ===== Team names of the 2000 server config (optional) =====
// $Server::teamName0 = "Communist";   $Server::teamSkin0 = "beagle";
// $Server::teamName1 = "Capitalist";  $Server::teamSkin1 = "green";

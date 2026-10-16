// Tribal God v6.6 -- settings.  PORT (Modern Tribes 1.50): written for the port from the
// installer's config\TribalPrefs.cs. createServer execs "TribalPrefs" at every server start.
// Left out on purpose (the installer's file set them and would overwrite the host's own):
// server name, port, public flag, max players, server password, last mission, MOTD, team
// names and skins, packet rate / size, telnet port and password, console log mode.
// Those are set the usual way.
//===========================================================================================
// Tribal God settings:
$TG::FlagDefencePoints = 1; // points awarded when a turret is deployed

// Infinite ammo (true = infinite, false = not infinite)
$TG::InfiniteAmmo:DoublePlasma = false;
$TG::InfiniteAmmo:MineLauncher = false;
$TG::InfiniteAmmo:DiscLauncher = false;
$TG::InfiniteAmmo:TankShredder = false;
$TG::InfiniteAmmo:RepairKit = true;
$TG::InfiniteAmmo:Mortar = false;
$TG::InfiniteAmmo:Boosts = true;
$TG::InfiniteAmmo:Grens = true;
$TG::InfiniteAmmo:Mine = false;

$TG::InfiniteDropAmmo = false; // true: dropping ammo does not use any up
$TG::PublicObsOn = false;      // true: non-admins may pick Observer from the team menu

// Cheats. The installer's file had this ON. With it on: admins can use "giveall" (an ammo and
// weapon refill), and ANY player who types the chat word HOOKITUPX gets the same; the chat
// word QUADDISC gives a hidden NDisc launcher. Off = none of that works.
$TG::GiveallOn = false;

// Alias logging. true = every joiner's address and name are written to config\IpLoggs.cs,
// admins are told when an address shows up under a new name, and the FOURTH different name
// from one address is kicked 20 seconds after joining. (The installer's file had it on.)
$TG::LogIps = true;

// Time warnings before the map ends
$TG::TwoMinWarn  = true;
$TG::FiveMinWarn = true;
//===========================================================================================
// Kick settings:
$TribalGod::KickTime = "180";        // seconds a kicked address stays out
$TG::KickMessage     = "You were removed by an admin."; // shown to the kicked player
$TribalGod::BanTime  = "999999999";  // seconds a banned address stays out
//===========================================================================================
// Voting:
$TG::VoteAdmin = false;                                       // allow voting a Public Admin in
if($Server::AdminMinVotes == "") $Server::AdminMinVotes = 4;  // votes needed for an admin vote
//===========================================================================================
// Permanent bans, added at every start. One address per slot, "*" is a wildcard:
// $TG::BanList:Name[0] = "88.789.45*:*";   -- careful, a wildcard can shut out a lot of people
$TG::BanList:Name[0] = "";
$TG::BanList:Name[1] = "";
$TG::BanList:Name[2] = "";
$TG::BanList:Name[3] = "";
$TG::BanList:Name[4] = "";
//===========================================================================================
// Admin passwords. "" = unused. None ship with the pack.
$TG::GodPassword = "";
// Super Admin passwords (slots 1 to 9):
$TG::SADPassword[1] = "";
$TG::SADPassword[2] = "";
$TG::SADPassword[3] = "";
// Public Admin passwords (slots 1 to 9):
$TG::PAPassword[1] = "";
$TG::PAPassword[2] = "";
$TG::PAPassword[3] = "";

$TG::PAStripAdmin = false; // true: Public Admins may strip other Public Admins
//===========================================================================================
// Other:
$TG::FairTeams         = false; // stop team changes to the larger team
$TG::UsePersonalSkin   = true;  // allow personal skins
$TG::obsAlert          = true;  // tell a player who is observing him
$TG::AutoChangeMission = false; // reset the mission when the last player leaves
$TG::SafeSpawnTime     = 1.75;  // seconds of spawn protection

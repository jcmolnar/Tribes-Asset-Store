// Ultra_Renagades_GZHQ (UltraGZHQ) -- server settings. Modern Tribes client 1.50 port.
//
// This file is BOTH the mod entry script (the loader runs it once at start-up, -mod UltraGZHQ)
// AND the mod's settings file: the mod's own server.cs runs exec(UltraGZHQ) every time a server
// is created and, while $UltraGZHQ::ResetSettings is true, at every map change. In 2002 it lived
// in config\UltraGZHQ.cs.
//
// To run your own settings, copy this file to config\UltraGZHQ.cs and edit the copy: config\
// is searched first, so your copy is used instead of this one.
//
// Not set here (unlike the 2002 file): server name, port, join password, first map, packet
// rate, telnet, console logging, player limit, time limit, team damage, tournament mode, team
// names and team skins. The host menu / config\serverPrefs.cs own those.

//===========================================================================================
// Admin passwords. NONE ships with this pack: remote admin logon is off until you set one.
// (The 2002 file shipped "YourMainSad", "someSad" and "ArmsGod"; do not reuse them.)
//   $AdminPassword = "...";                 // main super admin password
//   $UltraGZHQ::SADPassword[1] = "...";     // more super admin passwords, [1] to [99]
//   $UltraGZHQ::PAPassword[1]  = "...";     // public admin passwords, [1] to [99]
// Put those lines in config\autoexec.cs or in your own config\UltraGZHQ.cs.

//===========================================================================================
// Auto admin by player name + address: OFF. To use it, set this to true and list your admins
// in UltraGZHQAdminList.cs (copy that file to config\ and edit the copy).
$UltraGZHQ::AutoAdmin = false;

//===========================================================================================
// Server behaviour
$UltraGZHQ::NetMask = "IP:192.168";	// "local network" address prefix (used only by the two switches below, both unset)
// $UltraGZHQ::GiveNetworkAdmin = true;	// would give SUPER ADMIN to every client whose address starts with NetMask
// $UltraGZHQ::NetworkIncreaseMax = true;	// would raise the player limit by one for each such client
$UltraGZHQ::GiveLocalAdmin = true;	// the host's own (listen server) client is super admin
$UltraGZHQ::ShoppingList = true;	// inventory list shows only what the current armor can use
$UltraGZHQ::ResetServer = false;	// true: go to the next map when the last player leaves
$UltraGZHQ::KickTime = 180;		// seconds a kicked player stays banned
$UltraGZHQ::BanTime = 1800;		// seconds a banned player stays banned
$UltraGZHQ::StationTime = 200;		// station access time

//===========================================================================================
// Voting
$UltraGZHQ::VoteAdmin = false;		// allow voting a public admin in
$UltraGZHQ::VoteBuild = false;		// allow voting on builder mode
if($Server::AdminMinVotes == "")
	$Server::AdminMinVotes = 4;	// minimum number of votes to vote an admin in

//===========================================================================================
// Public admin rights (super admins always have them)
$UltraGZHQ::PAChangeMission = true;
$UltraGZHQ::PATeamDamage = true;
$UltraGZHQ::PATourneyMode = true;

//===========================================================================================
// Other
$UltraGZHQ::ResetSettings = true;	// re-run this file at every map change (admin changes last one map)
$UltraGZHQ::FairTeams = true;		// no team changing to the larger team
$UltraGZHQ::UsePersonalSkin = true;	// players may wear their own skin
$UltraGZHQ::SafeBase = false;		// true: stations and generators cannot be destroyed
$UltraGZHQ::BaseHeal = false;		// true: stations and generators repair themselves
$UltraGZHQ::obsAlert = true;		// tell a player who is watching him in observer mode
$UltraGZHQ::OutOfArea = false;		// allow players out of bounds
$UltraGZHQ::QuickInv = false;		// inventory without stations
$UltraGZHQ::ExtendedInvs = true;	// multiple use inventory stations
$UltraGZHQ::Zappy = true;		// electro beams check that extended inventories are not walled in

// true: remember every name seen per address in config\GZHQInfo.cs and show the list to admins
// when that address connects again (the mod's own design; set false to switch it off).
$IpLogger = true;

echo("Ultra_Renagades_GZHQ (UltraGZHQ) settings loaded.");

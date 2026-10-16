// Apteryx v2 -- server settings. Modern Tribes client 1.50 port.
//
// In 2003 this file was annihilation.cs (Apteryx is Annihilation 2.1 with new armors, weapons
// and drones, and kept Annihilation's settings names). The mod's server.cs runs it every time a
// server is created and, while $Annihilation::ResetSettings is true, at every map change.
// It ships under its own name so that no other Annihilation-family mod's file is picked up.
//
// To run your own settings, copy this file to config\ApteryxSettings.cs and edit the copy:
// config\ is searched first, so your copy is used instead of this one.
//
// Not set here (unlike the 2003 file): server name ("Crow's Nest"), port, public-listing flag,
// join password, first map, server info / message of the day, telnet, packet rate, console
// logging, player limit, respawn / warm-up / time limit, team damage, tournament mode and team
// skins. The host menu / config\serverPrefs.cs own those; this file runs at every map change
// and would stamp them over the host's choices.

//===========================================================================================
// Admin passwords. NONE ships with this pack (the 2003 file had them empty as well).
//   $AdminPassword = "...";                    // main super admin password
//   $Annihilation::SADPassword[1] = "...";     // more super admin passwords, [1] to [99]
//   $Annihilation::PAPassword[1]  = "...";     // public admin passwords, [1] to [99]
// Put those lines in config\autoexec.cs or in your own config\ApteryxSettings.cs.

//===========================================================================================
// Auto admin by player name + address: OFF (the 2003 file had it ON, with the author's own
// accounts in the list). To use it, set this to true and list your admins in
// ApteryxAdminList.cs (copy that file to config\ and edit the copy).
$Annihilation::AutoAdmin = false;

//===========================================================================================
// Server behaviour
$Annihilation::NetMask = "IP:192.168";	// "local network" address prefix (used only by the two switches below, both unset)
// $Annihilation::GiveNetworkAdmin = true;	// would give SUPER ADMIN to every client whose address starts with NetMask
// $Annihilation::NetworkIncreaseMax = true;	// would raise the player limit by one for each such client
$Annihilation::GiveLocalAdmin = true;	// the host's own (listen server) client is super admin
$Annihilation::ShoppingList = true;	// inventory list shows only what the current armor can use
$Annihilation::ResetServer = false;	// true: go to the next map when the last player leaves
$Annihilation::KickTime = 180;		// seconds a kicked player stays banned
$Annihilation::BanTime = 1800;		// seconds a banned player stays banned
$Annihilation::StationTime = 200;	// station access time

//===========================================================================================
// Voting
$Annihilation::VoteAdmin = false;	// allow voting a public admin in
$Annihilation::VoteBuild = false;	// allow voting on builder mode
if($Server::AdminMinVotes == "")
	$Server::AdminMinVotes = 4;	// minimum number of votes to vote an admin in
if($Server::VoteAdminWinMargin == "")
	$Server::VoteAdminWinMargin = 0.8;	// share of yes votes an admin vote needs

//===========================================================================================
// Public admin rights (super admins always have them)
$Annihilation::PAChangeMission = true;
$Annihilation::PATeamDamage = true;
$Annihilation::PATourneyMode = true;

//===========================================================================================
// Other
$Annihilation::ResetSettings = true;	// re-run this file at every map change (admin changes last one map)
$Annihilation::FairTeams = true;	// no team changing to the larger team
$Annihilation::UsePersonalSkin = true;	// players may wear their own skin
$Annihilation::SafeBase = false;	// true: stations and generators cannot be destroyed
$Annihilation::BaseHeal = false;	// true: stations and generators repair themselves
$Annihilation::obsAlert = true;		// tell a player who is watching him in observer mode
$Annihilation::OutOfArea = false;	// allow players out of bounds
$Annihilation::QuickInv = false;	// inventory without stations
$Annihilation::ExtendedInvs = true;	// multiple use inventory stations
$Annihilation::Zappy = true;		// electro beams check that extended inventories are not walled in

// true: remember every name seen per address in config\AnnInfo.cs and show the list to admins
// when that address connects again (the mod's own design, on in 2003; set false to switch it off).
$IpLogger = true;

// Shown on the join screen (game.cs copies it to $MODInfo). The 2003 text, without its dead
// download address.
$Server::MODInfo = "<jc><f2>Apteryx v2 - the world of flightless armors and armed fliers";

// The 2003 team names. Uncomment to use them (they would replace the host's own team names at
// every map change).
// $Server::teamName[0] = "Crows";
// $Server::teamName[1] = "Ravens";
// $Server::teamName[2] = "Apteryxes";
// $Server::teamName[3] = "Penguins";

echo("Apteryx v2 settings loaded.");

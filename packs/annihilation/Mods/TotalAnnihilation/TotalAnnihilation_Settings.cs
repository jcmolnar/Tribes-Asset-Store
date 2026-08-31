//                     |_   _|__ | |_ __ _| |                   
//                       | |/ _ \| __/ _` | |                   
//                       | | (_) | || (_| | |                   
//         _             |_|\___/ \__\__,_|_| _   _             
//        / \   _ __  _ __ (_) |__ (_) | __ _| |_(_) ___  _ __  
//       / _ \ | '_ \| '_ \| | '_ \| | |/ _` | __| |/ _ \| '_ \ 
//      / ___ \| | | | | | | | | | | | | (_| | |_| | (_) | | | |
//     /_/   \_\_| |_|_| |_|_|_| |_|_|_|\__,_|\__|_|\___/|_| |_|
// Total Annihilation

// REPACK PORT 2026-08-29 -- host identity is NOT stamped here any more.
//
// createServer() (server.cs) execs this file at its very TOP, BEFORE
// newObject(serverDelegate, FearCSDelegate, ..., $Server::Port). In the stock
// package that is fine -- the package IS the whole install and its own launcher
// owns the port. Here the client already has a host identity: the Host Game menu,
// TribesHost, the -dedicated launcher and the MCP harness (leased port) all set
// $Server::Port / HostName / Password / $pref::lastMission before calling
// createServer, and the master list is the modern client's own. Assigning them
// unconditionally silently moved every Total Annihilation host to port 28007 and
// the map "AirStrike" no matter what was asked for.
//
// So: seed a value ONLY when the client has not already provided one. Edit the
// defaults below freely -- they still apply to a bare launch.
if($Server::HostName == "")     $Server::HostName = "Total Annihilation";
if($Server::Port == "")         $Server::Port = "28007";
if($Server::HostPublicGame == "") $Server::HostPublicGame = true;
if($AdminPassword == "")        $AdminPassword = "";	// Local SuperAdmin password - CHANGE THIS
if($pref::LastMission == "")    $pref::LastMission = "AirStrike";
$Annihilation::RandomMissionStart = false;
// Master server list intentionally NOT set here -- the modern client ships its own
// ($Server::MasterAddressN*/XLMasterN*, seeded from config). The stock block named
// four masters and a nummasters of 4, which would have replaced them mid-boot.
// end server settings


// Settings for the arena spawn type you can ignore these
// LT Settings - AnniSpawn, EliteSpawn, BaseSpawn.
if(!$TALT::NoReset) //in game toggle to disable the mod reset on map changes
{
	$TAArena::SpawnType = "AnniSpawn";
	$TAArena::WeaponOpt = "Normal";
	if(!$TALT::SpawnReset)
		$TALT::SpawnType = "AnniSpawn";
	$TA::LT = false; //enable this if you start your server with an LT map
}
// End arena spawn settings


// Server information on server browser and the join message
// Server Info (<jc> = center, <f1> = tan font, <f2> = white font, <f3> = orange font, \n = new line)
$Server::Info = "<jc><f1>Tribes Discord:\n<f2>www.playt1.com\n<f1>Annihilation Discord:\n<f2>www.annihilation.info";
// Server information listed on MasterServer List.
	
$Server::MODInfo = "<jc><f2>www.annihilation.info\n<f1>In Partnership With:\n<f2>www.playt1.com";
// Information listed on server join screen.

$Server::JoinMOTD = "<jc><f3>Welcome to <f2>"@$ModVersion@"\n\n<f1>Press left click to spawn. Press tab for options. \n\n<f1>Tribes Discord:\n<f2>www.playt1.com\n\n<f1>Server Discord:\n<f2>www.annihilation.info";
// Message of the day listed once connected to the server

// Console Parameters
$Console::LogMode = "1"; 		// Log the console to console.log file.

// If you want telnet access, set the port number to the desired port (23 is normal)
// BE SURE TO SET A PASSWORD THAT IS HARD TO GUESS
$TelnetPort="29007";				// Port for telnet connections you can change this to whatever port you want to use
$TelnetPassword="telpassword";			// Password for telnet connections you should change this

//===========================================================================================
// Server Connection Parameters
// $pref::PacketFrame = "98";
$pref::PacketRate = "30"; //15 //For smooth gameplay, no jumpy players //CHANGED back to 30 from 4 11/12/15 -death666
$pref::PacketSize = "500"; //400 //15 and 400 are stock T1 settings but most use 30 and 500 //CHANGED back to 500 from 75 11/12/15 -death666

//===========================================================================================
// Annihilation Parameters
//$Annihilation::NetMask = "IP:192.168";	// This is used to increase server player limit when local LAN players connect.
$Annihilation::IncreaseMax = false;		// If true, will increase player limit on server if IP of client connect matches NetMask.
$Annihilation::GiveLocalAdmin = true;		// Gives SuperAdmin status to player on the same machine as the server.
$Annihilation::ResetServer = true;		// Set to true to rotate server to next map in list when last player leaves.
$Annihilation::KickTime = 500;	//5 min kick	// Time (in seconds) for kicks. //18000
$Annihilation::BanTime = 500;			// Time (in seconds) for bans. //no need to edit this, anni uses it's own ban system

//===========================================================================================
// Public Voting Parameters
$Annihilation::VoteAdmin = false;		// Allow Voting a Public Admin in.
$Annihilation::PVKick = true;			// Allow Public Kick Voting.
$Annihilation::PVChangeMission = true;		// Allow Public Mission Voting.
$Annihilation::PVTeamDamage = false;		// Allow Public Team Damage Voting.
$Annihilation::PVTourneyMode = false;		// Allow Public Tournament Mode Voting.
$Server::AdminMinVotes = 4;			// Minimum number of votes needed to vote admin
$Server::MinVotes = 1;				// Minimum number of votes needed to pass
$Server::MinVotesPct = 0.5;			// Percentage of available votes needed to pass a vote
$Server::MinVoteTime = 25;			// Time allotted for voting
$Server::VoteAdminWinMargin = 0.8;		// Ratio of Yes to No votes needed to pass
$Server::VoteFailTime = 30; 			// 30 seconds if your vote fails + $Server::MinVoteTime
$Server::VoteWinMargin = 0.6;			// Ratio of Yes to No votes needed to pass
$Server::VotingTime = 20;			// Length of votes if people are voting.
$Annihilation::voteFlagCaps = false;		
	// Allow public voting on flag caps. Maps won't 'cap out' with captures off.	
	
//===========================================================================================
// Auto Admin. 
// Uses the AnnAdminList.cs in config, edit to your liking.
$Annihilation::AutoAdmin = true; 	

//===========================================================================================
// Admin pass now record to the file AdminPass.log to keep track of whos using them
//===========================================================================================
$TA::GoatAdminLogin = "goatpassword"; // goat admin password you should change this
// OwnerAdmin Passwords, Up to 100 are available
$Annihilation::OwnerPassword[1] = "owned"; // Owner admin password you should change this
$Annihilation::OwnerPassword[2] = ""; 
$Annihilation::OwnerPassword[3] = ""; 
$Annihilation::OwnerPassword[4] = "";
$Annihilation::OwnerPassword[5] = "";
//===========================================================================================
// GodAdmin Passwords, Up to 100 are available
$Annihilation::GodPassword[1] = "godly"; // God admin password you should change this 
$Annihilation::GodPassword[2] = "";
$Annihilation::GodPassword[3] = "";
$Annihilation::GodPassword[4] = "";
$Annihilation::GodPassword[5] = "";
//===========================================================================================
// SuperAdmin Passwords, Up to 100 are available
$Annihilation::SADPassword[1] = "super"; // Super admin password you should change this
$Annihilation::SADPassword[2] = ""; 
$Annihilation::SADPassword[3] = ""; 
$Annihilation::SADPassword[4] = ""; 
$Annihilation::SADPassword[5] = ""; 
$Annihilation::SADPassword[6] = ""; 
$Annihilation::SADPassword[7] = "";
//===========================================================================================
// Public Admin Passwords, Up to 100 are available
$Annihilation::PAPassword[1] = "public"; // public admin password you should change this
$Annihilation::PAPassword[2] = "";
$Annihilation::PAPassword[3] = "";
$Annihilation::PAPassword[4] = "";
$Annihilation::PAPassword[5] = "";
// Public Admin Parameters
$Annihilation::PAKick = true;			// Allow Public Admins to Kick.
$Annihilation::PATeamChange = true;		// Allow Public Admins to Change other Players Teams.
$Annihilation::PAChangeMission = true;		// Allow Public Admins to Change the Mission.
$Annihilation::PATeamDamage = false;		// Allow Public Admins to Enable/Disable Team Damage.

//===========================================================================================
// Other Parameters
$Server::FloodProtectionEnabled = true;		// Spaminator.
$Annihilation::ResetSettings = true;		// Resets server settings from this file on map change.
$Annihilation::FairTeams = true;		// Prevent team changing to the larger team
$Annihilation::UsePersonalSkin = true;		// Allows use of Personal Skins
$Annihilation::OutOfArea = false;		// Allow players out of bounds.
$annihilation::VehicleImpactor = false;	
	// Adds a little cpu strain to safeguard against vehicle instability.
$Annihilation::HappyBreaker = false;	
	// creates dummy player models and flage to fool Happy Mod2	
$annihilation::DisableTurretsOnTeamChange = true;	
	// Disables a clients turrets when they switch teams or disconnect.
$Annihilation::ExplodingAmmo = true;
$TA::RandomMission = true;

//===========================================================================================
// Inventory settings
$Annihilation::QuickInv = false;	// inventory without statuions
$Annihilation::ExtendedInvs = true;	// Extended Inventories, multiple use inventory stations.
$Annihilation::Zappy = true;		// Uses electro beams to verify Extended Inventories aren't covered with blastwalls, force fields etc..
$Annihilation::StationTime = 200;	// Time allowed for Station Access, when normal stations.
$Annihilation::ShoppingList = true;	// Limit item shopping list to display only items available for current armor.
if ( !$Annihilation::SafeBase )
$Annihilation::SafeBase = false;		// True for undestroyable station and generators.
$Annihilation::BaseHeal = false;	// True for regenerating (self healing) station and generators.
$build = false;
$ABuild = false;
	// Build mode. Infinite deployables, no need for inventory stations.
if(!$ANNIHILATION::VoteBuilding)
{
return;
$ANNIHILATION::VoteBuilding = 1;
}
	
//===========================================================================================
// Player Parameters
$Server::MaxPlayers = "24";			// Maximum number of client connections allowed
$Server::AutoAssignTeams = true;		// Server assigned teams
if($TAArena::SpawnType == "AnniSpawn")
	$Server::RespawnTime = 0; 			// Number of seconds before a respawn is allowed
else
	$Server::RespawnTime = 1;
$Server::TimeLimit = 30;			// Mission time limit in minutes
$Server::WarmupTime = 1;			// Time (in seconds) players are left standing before movement is allowed //3 -death666
$Server::TeamDamageScale = 0;			// Team damage, 0 = Off, 1 = On
$Server::TourneyMode = false;			// Tournament mode
$TA::TourneyPickTeam = true;		// Pick a team on map drop in tourney mode

//===========================================================================================
// Player Information.
$IpLogger = true;				// Saves player names sorted by ip.
$Annihilation::obsAlert = false;			// Notifies player who is watching them in observer.
$TA::AFKsystem = "true"; //AFK Checking system
$TA::AFKmonitorInterval = "150"; //Time in seconds the server checks a player AFK 150
$TA::AFKtimelimit = "300"; //Time in seconds a player can be AFK before obs 300
$TA::Stats = true;
$TA::RefreshStatsTime = 2;

//===========================================================================================
// Team Parameters
$Server::teamName[-1] = "Obs";		// Observer Name
if($TALT::Active)
	$Server::teamName[0] = "BE";
else
	$Server::teamName[0] = "Blood Eagle";		// Team 1 Name
$Server::teamSkin[0] = "beagle";			// Team 1 Skin
if($TALT::Active)
	$Server::teamName[1] = "DS";
else
	$Server::teamName[1] = "Diamond Sword";	// Team 2 Name
 $Server::teamSkin[1] = "dsword"; 			// Team 2 Skin
 $Server::teamName[2] = "Children of the Phoenix";	// Team 3 Name
 $Server::teamSkin[2] = "cphoenix";		// Team 3 Skin
 $Server::teamName[3] = "Starwolf ";		// Team 4 Name
 $Server::teamSkin[3] = "swolf";			// Team 4 Skin
 $Server::teamName[4] = "Immortals";		// Team 5 Name
 $Server::teamSkin[4] = "blue";			// Team 5 Skin
 $Server::teamName[5] = "Empire";		// Team 6 Name
 $Server::teamSkin[5] = "green";			// Team 6 Skin
 $Server::teamName[6] = "Castouts";		// Team 7 Name
 $Server::teamSkin[6] = "orange";			// Team 7 Skin
 $Server::teamName[7] = "Unknowns";		// Team 8 Name
 $Server::teamSkin[7] = "purple";			// Team 8 Skin

//===========================================================================================

// You can call a custom mission list from here.
//exec(buildmissionlist);


// $TestingLH = True;

$Annihilation::OverflowLimit = 34;			// Max # of players before passwording.
$Annihilation::OverflowPassword = "totalannihilation";		// Password set on overflow.

$TA::ArenaReset = true;
//if($Arena::Initializied)
//{
//	Arena::Clear();
//}	

// << Code
exec("ZappyfixAug2009.cs");

// exec("LT_MissionList.cs");

// REPACK PORT 2026-08-29: was exec("TotalAnnihilation.cs"). Upstream's
// config\TotalAnnihilation.cs is the AutoLock / AutoBaseDamage / name-ban file,
// and that file is now TotalAnnihilation_Boot.cs -- the "<mod>.cs" name is taken
// by the mod ENTRY that console.cs:267 ExecModScripts() runs. Pointing this line
// at the entry worked (it chains to Boot) but re-ran the plugin shims and printed
// the mod banner a third time every createServer. Same file, named honestly.
//
// **This line is load-bearing: it is what re-arms autodoeverythingfun() on every
// createServer / mission change, when a ConsoleScheduler DOES exist. The boot-time
// call from the entry script is the one that gets dropped ("schedule: scheduler is
// not running"); this one is the one that sticks.**
exec("TotalAnnihilation_Boot.cs");

$BotsArenaMax = 4;
$TowerSwitchNexus = "";
$FlagHunter::Enabled = false;	
$FlagHunter::HoardMode = false;
$FlagHunter::GreedMode = false;
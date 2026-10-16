// UltrAnnihilation -- Modern Tribes (1.50) entry script.
// This is the author's config\ultrannihilation.cs. The ten sample SuperAdmin / PublicAdmin
// password lines are switched off (//PORT-OFF:): add your own $Annihilation::SADPassword[n] /
// $Annihilation::PAPassword[n] lines, or use the game's own admin password.
// Launch here:  -mod UltrAnnihilation
echo(">> UltrAnnihilation");

//=============================================================================================================================
// Annihilation Parameters
$Annihilation::NetMask = "IP:192.168.1";	// This is used to increase server player limit when local LAN players connect.
$Annihilation::IncreaseMax = false;		// If true, will increase player limit on server if IP of client connect matches NetMask.
$Annihilation::GiveLocalAdmin = true;		// If true, will give SuperAdmin status to players who are on the same machine as the server.
$Annihilation::ShoppingList = true;		// Set to true to limit item shopping list to display only items available for current armor.
$Annihilation::ResetServer = true;		// Set to true to rotate server to next map in list when last player leaves.
$Annihilation::KickTime = 180;			// Time (in seconds) for kicks.
$Annihilation::BanTime = 1800;			// Time (in seconds) for bans.
$Annihilation::StationTime = 20;		// Time allowed for Station Access.


//============================================================================================================================
// Public Voting Parameters
$Annihilation::PVAdmin = true;			// Allow Public Admin Voting.
$Annihilation::PVKick = true;			// Allow Public Kick Voting.
$Annihilation::PVChangeMission = true;		// Allow Public Mission Voting.
$Annihilation::PVTeamDamage = true;		// Allow Public Team Damage Voting.
$Annihilation::PVTourneyMode = true;		// Allow Public Tournament Mode Voting.


//=============================================================================================================================
// SuperAdmin Passwords, Up to 100 are available
//PORT-OFF: $Annihilation::SADPassword[1] (value not shipped)
//PORT-OFF: $Annihilation::SADPassword[2] (value not shipped)
//PORT-OFF: $Annihilation::SADPassword[3] (value not shipped)
//PORT-OFF: $Annihilation::SADPassword[4] (value not shipped)
//PORT-OFF: $Annihilation::SADPassword[5] (value not shipped)

// SuperAdmin Parameters
$Annihilation::SADBan = true;			// Allow Super Admins to Ban.
$Annihilation::SADGiveAdmin = true;		// Allow Super Admins to Give Public Admin to other players.
$Annihilation::SADForceVote = true;		// Allow Super Admins to Force Votes to Pass/Fail.


//=============================================================================================================================
// Public Admin Passwords, Up to 100 are available
//PORT-OFF: $Annihilation::PAPassword[1] (value not shipped)
//PORT-OFF: $Annihilation::PAPassword[2] (value not shipped)
//PORT-OFF: $Annihilation::PAPassword[3] (value not shipped)
//PORT-OFF: $Annihilation::PAPassword[4] (value not shipped)
//PORT-OFF: $Annihilation::PAPassword[5] (value not shipped)


// Public Admin Parameters
$Annihilation::PAKick = true;			// Allow Public Admins to Kick.
$Annihilation::PATeamChange = true;		// Allow Public Admins to Change other Players Teams.
$Annihilation::PAChangeMission = true;		// Allow Public Admins to Change the Mission.
$Annihilation::PATeamDamage = true;		// Allow Public Admins to Enable/Disable Team Damage.
$Annihilation::PATourneyMode = true;		// Allow Public Admins to Enable/Disable Tournament Mode.


// Other Parameters
$Annihilation::FairTeams = true;		// Prevent team changing to the larger team
$Annihilation::UsePersonalSkin = true;		// Allows use of Personal Skins
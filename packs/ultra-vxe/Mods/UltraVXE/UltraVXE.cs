// Ultra Renegades VX Extreme (VXE) r0.72 by UnhOlYAngl -- entry script (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod UltraVXE). The mod itself is the flat script
// set in scripts\ (its own server.cs, admin.cs, item.cs ...). The original launch line was
//     InfiniteSpawn.exe *TRIBES +exec ServerConfig -mod Ultra_RenegadesVXE -dedicated
// config\ServerConfig.cs held ordinary server prefs (host name, team names, time limit, admin
// passwords, a telnet port) plus the mod's own switches. The server prefs are NOT stamped by this
// pack: set them the usual way. The mod's own switches are below, with the values the original
// ServerConfig.cs / serverDefaults.cs shipped; each is set only when the host has not set it.

// Public votes offered in the Tab menu (Voting Options). false = that vote cannot be started.
if($ultra_renegades::PVMission == "")     $ultra_renegades::PVMission = true;      // change mission
if($ultra_renegades::PVTeamDamage == "")  $ultra_renegades::PVTeamDamage = true;   // team damage
if($ultra_renegades::PVFairTeams == "")   $ultra_renegades::PVFairTeams = true;    // fair teams
if($ultra_renegades::PVTourneyMode == "") $ultra_renegades::PVTourneyMode = true;  // tourney / FFA mode

// IP tracker ("smurf tracker"): one line per address with the names seen from it, kept in the file
// below and shown to super admins when a player connects or is selected in the Tab list.
if($IPTracker::File == "")        $IPTracker::File = "config\\ipinfo.cs";
if($IPTracker::Exec == "")        $IPTracker::Exec = "ipinfo";
if($IPTracker::ETricon == "")     $IPTracker::ETricon = true;       // echo ADMINMSG lines to the console
if($IPTracker::ESuperAdmin == "") $IPTracker::ESuperAdmin = true;   // bottom-print to super admins
if($IPTracker::EConsole == "")    $IPTracker::EConsole = true;      // plain console echo
if($IPTracker::OnTabSelect == "") $IPTracker::OnTabSelect = true;   // show on Tab-list select

// Message shown when a player opens the Tab menu (off by default).
if($Server::MOTDonTAB == "") $Server::MOTDonTAB = false;
// $Server::TabMOTD = "your text";

// Admin log-on (the SAD password box) is OFF until the host sets a password of their own, for
// example in config\autoexec.cs:
//     $AdminPassword          = "something only you know";   // super admin ("VXE Admin")
//     $MatchAdminPassword     = "another one";               // match admin
//     $MatchAdminPasswordList = "word1 word2";               // more match-admin passwords
// No password ships with this pack. The host's own (listen-server) client is super admin.

echo("Ultra Renegades VX Extreme r0.72 (UltraVXE) settings loaded.");

// Ultra Renegades VX6 Infinite -- settings.  PORT (Modern Tribes 1.50): written for the port.
// admin.cs execs "VX6Config.cs" every time the server starts. The archive's own copy belonged
// to one real server (its host name, MOTD, team names and skins, network prefs) and does not
// compile as shipped; this file keeps only what the mod's scripts read and never set themselves.
// Server name, team names, time limit and so on are set the usual way.
//
// Up to 100 passwords per level (index 0..99); "" = slot unused.
// Admins log in from chat:   !sad <password>
// Ten wrong tries kick the player and ban the address for 300 seconds.

$Admin::PublicPassword[0] = "";
$Admin::SuperPassword[0]  = "";
$Admin::MasterPassword[0] = "";
$Admin::OwnerPassword[0]  = "";

// Highest "points to win" a Master Admin can pick for a clan match (Tab menu, in steps of 5).
// 500 is the value of the archive's own settings file.
if($Server::ClanMatchTotalPoints == "") $Server::ClanMatchTotalPoints = 500;

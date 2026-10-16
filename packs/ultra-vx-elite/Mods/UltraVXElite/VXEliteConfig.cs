// Ultra Renegades VX-Elite -- settings.  PORT (Modern Tribes 1.50): written for the port.
// admin.cs execs "VXEliteConfig.cs" every time the server starts, and server.cs execs it
// again when a clan match ends. The archive's own copy set a telnet port and password
// ("changeme"), four default admin passwords (public / super / master / owner), a host
// name, MOTD, team names and skins, and stopped compiling at its "##" lines; this file
// keeps only what the mod's scripts read and never set themselves.
// Server name, team names, time limit and so on are set the usual way.
//
// Up to 100 passwords per level (index 0..99); "" = slot unused.
// Admins log in from chat:   !sad <password>
// Ten wrong tries (or six tries inside half a second) kick the player and ban the address
// for 300 seconds.

$Admin::PublicPassword[0] = "";
$Admin::SuperPassword[0]  = "";
$Admin::MasterPassword[0] = "";
$Admin::OwnerPassword[0]  = "";

// Highest "points to win" a Master Admin can pick for a clan match (Tab menu, in steps of 5).
// 500 is the value of the archive's own settings file.
if($Server::ClanMatchTotalPoints == "") $Server::ClanMatchTotalPoints = 500;

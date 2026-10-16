// +Cybrid+ 2K5 -- settings.  PORT (Modern Tribes 1.50): written for the port.
// admin.cs execs "2K5Config.cs" every time it loads, but the 2005 archive (a development
// snapshot) does not contain the file. These are the only settings the scripts read and
// never assign themselves. Up to 100 passwords per level (index 0..99); "" = slot unused.
// Admins log in from chat:   !sad <password>     (the console sad() is switched off by the mod)

$Admin::PublicPassword[0] = "";
$Admin::SuperPassword[0]  = "";
$Admin::MasterPassword[0] = "";
$Admin::OwnerPassword[0]  = "";

// Highest "points to win" a Master Admin can pick for a clan match (Tab menu, in steps of 5).
// The original value is not known; without one the menu is empty.
if($Server::ClanMatchTotalPoints == "") $Server::ClanMatchTotalPoints = 50;

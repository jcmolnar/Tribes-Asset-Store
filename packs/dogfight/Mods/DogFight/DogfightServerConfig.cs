// DogFight v1.5 -- server settings (Modern Tribes 1.50 port of Config\DogFightServerConfig.cs).
// The mod's server.cs execs this file every time a server is created.
//
// The original file held no DogFight option at all: it was the author's host setup. NOT carried
// over: host name, port, public flag, join password, player limit (2), time limit, vote
// settings, packet rate, last mission, the server info / MOTD texts with the author's name and
// e-mail, $AdminPassword = "Password", $TelnetPort = 28001 with $TelnetPassword = "Password",
// $Console::LogMode. Set those in the host menu as usual. ($Server::MODInfo, the join-screen
// text, was never read by any script.)
//
// What is left is the mod's flavour: its four team names. Change or delete them freely.
$Server::teamName[0] = "Royal Air Force";
$Server::teamName[1] = "Red Barons";
$Server::teamName[2] = "USAF";
$Server::teamName[3] = "NORAD";

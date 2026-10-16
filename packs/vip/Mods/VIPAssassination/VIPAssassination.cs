//-----------------------------------------------------------
// VIP Assassination 1.3 by nagorak (2000) -- entry script for the Modern Client (1.50)
//
// VIP is a game type, not a full mod: one script (scripts\VIP.cs) that every VIP map
// loads with exec(vip), on top of the stock base scripts.  The 2000 install copied
// VIP.cs into Tribes\base and the maps into Tribes\base\missions.  Here they live in
// Mods\VIPAssassination\scripts and Mods\VIPAssassination\missions, and the loader
// runs this file once at start-up.
//
// This file must NOT be named VIP.cs: a script in the mod root outranks the copy in
// scripts\, and the maps' exec(vip) would then load this stub instead of the game.
//
// Host:  -mod VIPAssassination, then start any of the 19 VIP maps (HardTime,
// CityInTheSky, Wargames, ...).  While a VIP map runs, VIP.cs replaces parts of the
// base admin, chat, station, observer, player and server scripts; it puts them back
// itself when the server moves on to a map of another type.
//
// Chat commands (typed as normal chat): viphelp, ~version, ~comhelp, ~whoisVIP,
// ~whoisDecoy, ~whoisCom, ~targetVIP, ~targetDecoy, ~teamscore, ~playerscore.
//
// Optional settings (leave them out for the mod's own defaults):
//    $Server::VIPDamageScale = 1;   // 1 = teammates can hurt their own VIP, 0 or unset = they cannot
//-----------------------------------------------------------

echo("VIP Assassination 1.3 (nagorak) -- 1.50 port entry");

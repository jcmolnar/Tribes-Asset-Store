// Tribal God (Ultra_Tribal_God) v6.6 by Dustin 'X-Ecutioner' Bruce, 2003-11-17 -- entry script
// (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod TribalGod). The mod itself is the script
// set in scripts\ : its own server.cs, game.cs, objectives.cs and one folder per subject
// (Admin, ArmorData, BackPacks, Deployables, Mines, ProjectileData, Stations, Turrets, Vehicle,
// Weapons), which server.cs loads by path at every server start.
// The original was an installer that put scripts.vol in <Tribes>\Ultra_Tribal_God and
// config\TribalPrefs.cs, and made shortcuts "TRIBES.exe -mod Tribal_God -dedicated".
//
// Settings: Mods\TribalGod\TribalPrefs.cs (admin passwords, cheat switch, alias logging).
// createServer execs "TribalPrefs" at every start; a copy in config\ wins over the pack's.
// Admins log on with the stock admin-password box / remote (God, Super and Public levels).

// PORT: the admin functions call logAdminAction() 22 times and no script of the mod defines it
// (it came from the Annihilation admin code this mod borrowed). Without this every damage /
// mode switch printed "logAdminAction: Unknown command."
function logAdminAction(%clientId, %msg)
{
   if(%clientId == -1)
      echo("ADMINMSG: " @ %msg);
   else
      echo("ADMINMSG: " @ Client::getName(%clientId) @ " " @ %msg);
}

echo("Tribal God 6.6 (TribalGod): settings are in Mods\\TribalGod\\TribalPrefs.cs");

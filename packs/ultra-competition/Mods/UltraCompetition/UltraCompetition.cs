// Ultra Competition 1.2 (scripts.vol 2001-08-28; in-game mod changer by {187}George W.; credits
// in the mod: Thrash, Deacon, Kissie-POO, George W., Dr. NoRtOn, Vfrjim, TheThug) -- entry
// script for Modern Tribes 1.50.
// Original launch line (the 1.0 "OGL Mod" shortcut; 1.2 shipped as a bare scripts.vol):
//   InfiniteSpawn.exe *tribes +exec serverConfig -mod ultra_competition -dedicated
// The mod has four rule sets a super admin switches from the Tab menu (Super Admin Options,
// Change Server Mod): 1 League 2.0, 2 Stealth 1.0, 3 NoToR 5, 4 VX 4A. $Server::Mod picks the
// one a server starts in (1 when unset). No settings file and no password ship with the pack:
// the HOST sets $AdminPassword (super admin) and, optionally, $MatchAdminPassword (match admin).

// PORT: no script of this build sets the stock flag-to-stand timer its objectives.cs reads
// (Find and Retrieve / Capture and Hold maps told the carrier "0 sec"). Stock value.
if($flagToStandTime == "")
   $flagToStandTime = 180;

echo("Ultra Competition 1.2 loaded (mod word UltraCompetition).");

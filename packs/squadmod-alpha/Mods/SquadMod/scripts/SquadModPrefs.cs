// SquadMod settings -- the $SquadModPref lines of the release's squadmodprefs.cs, values unchanged
// except AdminName / AdminEMail (the author's own, blanked; no script reads them).
// PORT: the original file was started with "+exec squadmodprefs.cs" and also held the author's
// server name, team names, master-server addresses and sample telnet / admin passwords
// ("whatever", "adminpassword"); those lines are not included -- use the game's own server
// settings. The entry script (SquadMod.cs) runs this file.
//
// SquadMod Pref's
//
$SquadModPref::Version = "Alpha";
$SquadModPref::AdminEMail = "";
$SquadModPref::AdminName = "";
$SquadModPref::AutoWeaponSwitch = True;
$SquadModPref::DisorentationTime = 6;
$SquadModPref::JoinQuote = True;
$SquadModPref::MOTD = "Running SquadMod release <f0>" @ $SquadModPref::Version @ "<f1> by KillerBunny";
$SquadModPref::OOBDelay = 5;
$SquadModPref::ParseLocations = True;
$SquadModPref::ProfanityFilter = True;
$SquadModPref::RespawnDelay = 5;
$SquadModPref::RespawnDelayIncFactor = 1;
//
// SquadMod Anti-TK, code by Kaptain Kickass
//
$SquadModPref::antiTK_noWarning = False;
$SquadModPref::antiTK_bantime = 600;
$SquadModPref::antiTK_maxTK = 5;
$SquadModPref::antiTK_kickmsg = "You were kicked for exceding your limit of team kills.";
$SquadModPref::antiTK_bcastmsg = " was kicked for team killing.";
$SquadModPref::antiTK_saveTKsByIP = True;

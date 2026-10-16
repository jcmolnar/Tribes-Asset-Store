// NetRunner (Stiletto and Arkfire, April 2000) -- server settings.
//
// This is the mod's own NetRunner.cs ("Be sure to edit the NetRunner.cs file to suit the needs of
// your server", install.txt) with the original values. It is also the file the Modern Tribes
// client runs first for  -mod NetRunner  (the launch line of install.txt:
// tribes.exe -mod NetRunner), so it loads exactly as it did in 2000.
//
// Changed by the port: the two auto-admin entries the release shipped switched on (the authors'
// own names and home addresses, both as super admin) are examples now, like the auto-ban and
// auto-mute entries below them always were.
echo(">> NetRunner");

$NetRunner::VoteAdmin = True;          // Allows users to vote an admin
$NetRunner::VoteKick = True;           // Allows users to kick players by vote
$NetRunner::KeepBalanced = True;       // Keeps the teams balanced
$NetRunner::VoteDTD = True;            // Allows players to enable Team Damage on/off by vote
$NetRunner::VoteFFA = True;            // Allows players to enable/disable Tournament mode by vote
$NetRunner::TeamDamageScale = 1.0;     // How much damage team-mates take from shots if Team Damage is enabled
$NetRunner::ScoreMulti = 3.0;          // Determines how many points players receive for kills.  Adjust to suit.
$NetRunner::CreditsMulti = 10.0;       // Credits are determined by points.  This determines how many credits per point players receive.
$NetRunner::TestMode = False;          // All Weapons and Armors Available

// Global Game Variables
$AutoRespawn = 0;                      // Respawn automatically after X sec's -If 0..no respawn
$ItemPopTime = 30;                     // Time it takes for items to disappear after they've been dropped.
$ItemRespawnTime = 30;                 // (Rate is sec's) Spinning items respawn
$WaitThrowTime = 2;                    // Time in sec player must wait before he can throw a Grenade or Mine after leaving a station.
$flagToStandTime = 180;                // Time player has to put flag in flagstand before it gets returned to its flag stand.
$InfiniteCreds = False;                // Ignores the credits of the players if True
$InitialPlayerEnergy = 1000;           // Initial Player credits
$ServerCheats = 0;                     // CHEATS
$TestCheats = 0;                       // CHEATS
$RandomMissions = True;                // Random missions chosen

// Auto Lists...  An example of each is here.
// AutoAdmins verify both from the name and the address. You must have both for this to work.
// IsSuperAdmin is True or False or can be left out. The address is matched from its start, so
// "IP:192.0.2.10" is one machine and "IP:192.0.2." is a whole block.
//$NetRunner::AutoAdmin[0] = "Some Player";
//$NetRunner::AutoAdminAddr[0] = "IP:192.0.2.10";
//$NetRunner::IsSuperAdmin[0] = TRUE;
// AutoBan and AutoMute verify from name and/or address. Both lines of an entry must be filled
// in for the entry to be read; a player who matches either one is kicked / muted.
//$NetRunner::AutoBan[0] = "Joe Shmoe";
//$NetRunner::AutoBanAddr[0] = "IP:192.0.2.20";
//$NetRunner::AutoMute[0] = "Gheghis Marauder";
//$NetRunner::AutoMuteAddr[0] = "IP:192.0.2.30";

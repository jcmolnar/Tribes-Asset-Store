// Genocide v2R -- server settings (Modern Tribes 1.50 port of the mod's GenoServ.cs).
// Modification by 6|6|6*SlipKnot*, administration coded by ]|420|[*CraCka.
//
// The mod execs this file when the server is created AND at every match start, so a change made
// here is live from the next match.
//
// NOT carried over from the original file (they stamped the host's own settings at every match):
// host name, port, public flag, player limit, last mission, master-server lists, MOTD, team
// names and team skins, $TelnetPort / $TelnetPassword, $console::logmode. Set those in the
// host menu as usual. $ArmBan[] / $ArmBanIP[] / $AutoBanTime are gone too: no script of the
// mod ever read them.

//------------------------
$CodeRed::LowScore = "On";  // warns a player whose score falls to -1 / -9 / -10
$CodeRed::AntiTK = "On";    // warns a player on team kill 1, 3 and 4
// (the kick these warnings announce called a function the mod never had; it only warns)
//------------------------

//------------------------
$VoteKick = "False";        // "True" lets regular players vote to KICK
$VoteAdmin = "False";       // "True" lets regular players vote to ADMIN
//------------------------

//----------------------------------------------------
// Admin log-ins: four levels.
//   Owner  ("Server Master")  one slot: [0]
//   God, Super, Public        slots [0] to [20] each
// A player logs in from the console with  sad("password");  and must be using the NAME stored in
// the same slot (spelled exactly, case sensitive). An empty password or an empty name = slot off.
// Every slot ships EMPTY. Example:
//    $SuperName[0] = "MyTribesName";
//    $SuperPassword[0] = "a long password";
// sad("Logout"); drops your admin rights.
//----------------------------------------------------
$OwnerName[0] = "";
$OwnerPassword[0] = "";

$GodName[0] = "";
$GodPassword[0] = "";

$SuperName[0] = "";
$SuperPassword[0] = "";

$PublicName[0] = "";
$PublicPassword[0] = "";

//---------------------
// Admin log-out words (the mod's own; leave them)
//---------------------
$Logout = "Logout";
$Logout2 = "logout";

//-------------------------------------------------------
// Shown under Tab > Genocide Info > Server Info / Server Rules
//-------------------------------------------------------
$OwnerName = "";
$Clan = "N/A";
$ClanTag = "";
$ClanSite = "";
$Admin = "";
$Rules = "\n<jc><f3>1. <F2>No Spawn Killing\n<F3>2. <F2>No Off-Side Turreting\n<F3>3. <F2>No TKing\n<F3>4. <F2>No Camping.";

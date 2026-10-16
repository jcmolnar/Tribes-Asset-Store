// Devastator Mod "BETA v0.99 - Serverside" (Ice, May 2002) -- Modern Tribes (1.50) entry script.
//
// The release zip is one folder, "Devastator", with no readme and no shortcut: it was started with
//    tribes -mod Devastator
// and nothing else was exec'd. The client's own console.cs loads server.cs from this mod's scripts
// folder; server.cs loads SI, admin, the data files, WeapSwap, Item, the 8 Pack_* and 19 Weapon_*
// files and ClipCode.
echo(">> Devastator Mod BETA v0.99");

// PORT: the mod's chat robot ("Server Intelligence", scripts\SI.cs) reads two settings that no file in
// the release ever sets. With both empty the robot has no name (it answers to chat lines that begin
// with ":") and its language warning count is 0, so the FIRST swear word typed by a player who is
// not a super admin kicks that player and bans the address for 3 minutes ($TempKickBanTime,
// scripts\admin.cs:5). These two defaults apply only when the host has not set a value.
//    $Server::SIName        the robot's name. Players talk to it as "<name>: kill me",
//                           "<name>: what does the <weapon> do", "<name>: when is this mission over?"
//    $Server::MaxLangWarn   warnings before the language kick
//    $SI::ShutUp = true;    (optional) switches the robot off completely
if($Server::SIName == "") $Server::SIName = "Server";
if($Server::MaxLangWarn == "") $Server::MaxLangWarn = 3;

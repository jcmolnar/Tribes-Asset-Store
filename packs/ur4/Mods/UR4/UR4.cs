// Ultra Renegades 4 (build 091100) by Dr. NoRtOn, based on URG_Thrash's UR3, with help from
// George W. -- entry script for Modern Tribes 1.50.
// Original launch line (readme.txt):
//   InfiniteSpawn.exe *tribes +exec serverConfig.cs +exec ultra_renegades.cs -mod Ultra Renegades4 -dedicated
// The values below are the archive's ultra_renegades4.cs. ServerConfig.cs was a host settings
// template (server name, three admin passwords, telnet password, port): not carried over.
// No password ships. To use the mod's three admin ranks the HOST sets, in his own config:
//   $AdminPassword  (super admin)   $PublicPassword (public admin)   $OwnerPassword (God admin)
//   $Server::pwoption = the join password the "Lock" entry of the admin menu switches on.

$ultra_renegades::BanKickTime = "120";
$ultra_renegades::fairTeams = "true";
$ultra_renegades::PABan = "false";
$ultra_renegades::PAKick = "false";
$ultra_renegades::PAMission = "true";
$ultra_renegades::PAModOptions = "false";
$ultra_renegades::PAResetDefaults = "false";
$ultra_renegades::PATeamChange = "false";
$ultra_renegades::PATeamDamage = "false";
$ultra_renegades::PATeamInfo = "false";
$ultra_renegades::PATimelimit = "false";
$ultra_renegades::PATourneyMode = "false";
$ultra_renegades::tkClientLvl = "0";
$ultra_renegades::tkLimit = "1";
$ultra_renegades::tkMultiple = "1";
$ultra_renegades::tkServerLvl = "3";
$ultra_renegades::Safety = "3";

// PORT: UR4's item.cs calls isPlayerBusy() in remoteSellItem but never defines it (its other
// buy/sell remotes do not call it at all). Stock 1.11 definition, so selling while firing is
// refused instead of printing an Unknown-command line. Base's item.cs is not loaded under UR4.
function isPlayerBusy(%client)
{
   %state = Player::getItemState(%client,$WeaponSlot);
   return %state == "Fire" || %state == "Reload";
}

echo("Ultra Renegades 4 loaded (mod word UR4).");

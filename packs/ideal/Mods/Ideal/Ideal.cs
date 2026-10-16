// Ideal Mod by Ziktar (scripts dated May - August 1999) -- Modern Tribes (1.50) entry script.
// The original was a complete scripts folder in tribes\ideal, started with (Readme.doc):
//     tribes.exe -mod ideal
// The old game ran the file named after the mod word at start-up, and the release relied on
// that: its ideal.cs (the inventory-station lists of the mod's new items, further down, byte for
// byte) is loaded by no other script. This file is that ideal.cs with the lines up to the PORT
// END marker added in front.
// Launch here:  -mod Ideal
echo(">> Ideal Mod");

$MODInfo = "Ideal Mod by Ziktar\nWeapon modes are on the TAB menu.";

// PORT: the 1.50 server.cs hands a late joiner the match clock through Game::syncClientClock,
// which lives in the base objectives.cs this mod replaces. Same arithmetic as the mod's own
// Game::checkTimeLimit (game.cs).
function Game::syncClientClock(%cl)
{
	if(!$matchStarted || !$Server::timeLimit)
		return;
	remoteEval(%cl, "setTime", -(($Server::timeLimit * 60) + $missionStartTime - getSimTime()));
}
// ---- PORT END. The release's ideal.cs follows unchanged. ----

$InvList[FlameTurretPack] = 1;


$InvList[TractorBeam] = 1;
$RemoteInvList[TractorBeam] = 1;

$InvList[ObeliskPowerPack] = 1;

$InvList[ArbitorBoxPack] = 1;

$InvList[FlagMine] = 1;
$RemoteInvList[FlagMine] = 1;

$InvList[ReplicatingMine] = 1;
$RemoteInvList[ReplicatingMine] = 1;

$InvList[OriginalMine] = 1;
$RemoteInvList[OriginalMine] = 1;


$InvList[ObeliskPack] = 1;

$InvList[JetFirePack] = 1;
$RemoteInvList[JetFirePack] = 1;


//$InvList[ChangelingNet] = 1;
//$RemoteInvList[ChangelingNet] = 1;


$InvList[FlagMovePack] = 1;
$RemoteInvList[FlagMovePack] = 1;


$InvList[Marlin] = 1;
$RemoteInvList[Marlin] = 1;

$InvList[MarlinAmmo] = 1;
$RemoteInvList[MarlinAmmo] = 1;

$InvList[laserchaingun] = 1;
$RemoteInvList[LaserChaingun] = 1;

$InvList[slowgun] = 1;
$RemoteInvList[slowgun] = 1;

$InvList[slowgunammo] = 1;
$RemoteInvList[slowgunammo] = 1;

$InvList[concuss] = 1;
$RemoteInvList[concuss] = 1;

$InvList[concussammo] = 1;
$RemoteInvList[concussammo] = 1;

$InvList[special] = 1;

$InvList[NuclearTurretPack] = 1;

$InvList[TreePack] = 1;
$RemoteInvList[TreePack] = 1;

$InvList[SpecialistPack] = 1;
$RemoteInvList[SpecialistPack] = 1;

$InvList[cloaker] = 1;
$RemoteInvList[cloaker] = 1;

$InvList[TeleportPack] = 1;
$RemoteInvList[TeleportPack] = 1;

$InvList[C4Ammo] = 1;
$RemoteInvList[C4Ammo] = 1;

$InvList[HandgrenadeAmmo] = 1;
$RemoteInvList[HandgrenadeAmmo] = 1;

$InvList[SuicideAmmo] = 1;
$RemoteInvList[SuicideAmmo] = 1;

$InvList[FlashgrenadeAmmo] = 1;
$RemoteInvList[FlashgrenadeAmmo] = 1;

$InvList[StungrenadeAmmo] = 1;
$RemoteInvList[StungrenadeAmmo] = 1;


//Don't know why, but these were not being set if it was in Station.cs
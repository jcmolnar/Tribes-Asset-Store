// BioWasteland 7.5 -- Modern Tribes (1.50) entry script.
// The original launch line was: -mod BioWasteland +exec Wasteland.cs +exec server.cs
// The client's own console.cs loads server.cs from this mod's scripts folder, so the only thing
// left to reproduce is the settings file.
echo(">> BioWasteland 7.5");
exec("Wasteland.cs");

// PORT FIX: server.cs and game.cs call DuelResetClient() on every connect, team change and death,
// but the mod only defines it in DuelMOD.cs, which is loaded by duel maps alone. On any other map
// every one of those calls logged "DuelResetClient: Unknown command." DuelMOD.cs still redefines
// it (same body) when a duel map loads.
function DuelResetClient(%clientId)
{
	$DuelStatus[%clientId] = "";
	$DuelLineup[%clientId] = "";
	$DuelWeaponSetup[%clientId] = "";
	$DuelPack[%clientId] = "";
	$DuelLastEnemy[%clientId] = "";
}

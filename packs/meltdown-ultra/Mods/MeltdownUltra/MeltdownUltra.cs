// Meltdown Ultra 2.33 (2-26-03) by Defender, on INH*DynaBlade's Meltdown 2.16 -- Modern Tribes
// (1.50) port, entry script.
//
// Original launch line (the three choices inside MDMenu.exe, read but never run):
//    Tribes.exe -mod Meltdown          Tribes.exe -mod Meltdown -dedicated
// The stock loader then ran Meltdown\Meltdown.cs (the mod's settings file) because it carried the
// folder name. The port's folder is MeltdownUltra, so this file does that exec.

// The mod's own settings: join message, vote switches, team energy, scoring, SpoonBot roster.
// NOTE: it ships with $Spoonbot::AutoSpawn = True and 14 named bots, as the original did.
exec("Meltdown.cs");

// MeltdownAdminList.cs (auto-admin names and the per-name spawn loadouts) is loaded by server.cs,
// as in the original. It ships with every sample entry commented out.

// Functions 2.33 calls but does not define (see the file for each one).
exec("MeltdownUltra_compat.cs");

echo("Meltdown Ultra 2.33 (1.50 port) loaded.");

// Meltdown X - BLACK OP'S vX Omega (November 2003) by *(COOP)* and UNFORGIVEN
// -- Modern Tribes (1.50) port, entry script.
//
// Original launch line (from MDMenu.exe and "Play Meltdown.bat"; the release notes give none):
//     Tribes.exe -mod Meltdown [-dedicated]
// The stock loader then ran Meltdown\Meltdown.cs (the mod's settings file) because it carried the
// folder name. The port's folder is MeltdownX, so this file does that exec.

// The mod's own settings: join message, vote switches, team-kill limits, team energy.
exec("Meltdown.cs");

// MeltdownUserList.cs (public-admin / SAD passwords and the auto-admin list) was never loaded by
// the original mod and is not loaded here. It ships as released: every entry blank. A host who
// wants it fills it in and removes the "//" on the next line. An auto-admin NAME now needs an
// address beside it (a name alone used to match every address).
//exec("MeltdownUserList.cs");

// A kick bans for $Meltdown::BanTime seconds, and the mod never sets it. Stock Tribes uses 180.
if($Meltdown::BanTime == "")
   $Meltdown::BanTime = 180;

// Functions the mod calls but does not define (see the file for each one).
exec("MeltdownX_compat.cs");

echo("Meltdown X - Black Ops vX Omega (1.50 port) loaded.");

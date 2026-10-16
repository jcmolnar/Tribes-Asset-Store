// Meltdown Hell v3.3 (3-28-2001) by DSA*Defender -- Modern Tribes (1.50) port, entry script.
//
// Original launch line (readme-less release; from MDMenu.exe and "Play Meltdown.bat"):
//     Tribes.exe -mod Meltdown [-dedicated]
// The stock loader then ran Meltdown\Meltdown.cs (the mod's settings file) because it carried the
// folder name. The port's folder is MeltdownHell, so this file does that exec.

// The mod's own settings: join message, vote switches, team-kill limits, team energy.
exec("Meltdown.cs");

// MeltdownUserList.cs (public-admin / SAD passwords and the auto-admin list) was never loaded by
// the original mod and is not loaded here. It ships as released: every entry blank. A host who
// wants it fills it in and removes the "//" on the next line. An auto-admin NAME now needs an
// address beside it (a name alone used to match every address).
//exec("MeltdownUserList.cs");

// A kick bans for $Meltdown::BanTime seconds, and 3.3 never sets it. Stock Tribes uses 180.
if($Meltdown::BanTime == "")
   $Meltdown::BanTime = 180;

// Functions 3.3 calls but does not define (see the file for each one).
exec("MeltdownHell_compat.cs");

echo("Meltdown Hell v3.3 (1.50 port) loaded.");

// Meltdown Total War 2001 (build 124) by Defender -- Modern Tribes (1.50) port, entry script.
//
// Original launch line:  Tribes.exe -mod Meltdown [-dedicated]
// The stock loader then ran Meltdown\Meltdown.cs (the mod's settings file) because it carried the
// folder name. The port's folder is MeltdownTW, so this file does that exec.

// The mod's own settings: join message, vote switches, team energy, SpoonBot roster and gear.
exec("Meltdown.cs");

// MeltdownUserList.cs (public-admin / SAD passwords and the auto-admin list) was never loaded by
// the original mod and is not loaded here. It ships with every password blank and the auto-admin
// list empty. A host who wants it fills it in and removes the "//" on the next line.
//exec("MeltdownUserList.cs");

// A kick bans for $Meltdown::BanTime seconds, and build 124 never sets it. Stock Tribes uses 180.
if($Meltdown::BanTime == "")
   $Meltdown::BanTime = 180;

// Functions build 124 calls but does not define (see the file for each one).
exec("MeltdownTW_compat.cs");

echo("Meltdown Total War 2001 build 124 (1.50 port) loaded.");

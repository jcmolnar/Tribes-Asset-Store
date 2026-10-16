// Meltdown v2.16 Final by INH*DynaBlade -- Modern Tribes (1.50) port, entry script.
//
// Original launch line (MDMenu.exe / Play Meltdown.bat; Meltdown.bat in 2.15):
//    tribes.exe -mod Meltdown          tribes.exe -mod Meltdown -dedicated
// The stock loader then ran Meltdown\Meltdown.cs (the mod's settings file) because it carried the
// folder name. The port's folder is Meltdown2, so this file does that exec.

// The mod's own settings: join message, vote switches, team energy, bot (Bioderm) settings.
exec("Meltdown.cs");

// MeltdownUserList.cs (public-admin / SAD passwords and the auto-admin list) was never loaded by
// the original mod and is not loaded here. It ships as released: every password blank, the
// auto-admin list empty. A host who wants it fills it in and removes the "//" on the next line.
//exec("MeltdownUserList.cs");

// A kick bans for $Meltdown::BanTime seconds, and 2.16 never sets it. Stock Tribes uses 180.
if($Meltdown::BanTime == "")
   $Meltdown::BanTime = 180;

// Functions 2.16 calls but does not define (see the file for each one).
exec("Meltdown2_compat.cs");

echo("Meltdown v2.16 Final (1.50 port) loaded.");

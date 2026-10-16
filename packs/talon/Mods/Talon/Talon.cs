//-----------------------------------------------------------
// Talon Rules by -=TalonHawk=- (archive "Talon Rules - v. 2.1", March 2001; the scripts call
// themselves v2.2) -- entry script for the Modern Client (1.50)
//
// Readme: "Unzip the scripts.vol file into a new folder called Talon ... Tribes.exe -mod Talon".
// The scripts.vol is shipped here as loose files in Mods\Talon\scripts; the mod's own server.cs,
// game.cs, item.cs ... replace the base copies while -mod Talon is loaded.  Nothing else was in
// the archive: no settings file, no maps, no art.
//
// Six armors (Scout, Assassin, Fighter, Engineer, Destroyer, Energon), each with a
// specialization picked under Tab > Talon options > Spawn options; weapon fire modes and armor
// abilities are Tab-menu entries too.
//
// KNOWN GAP: server.cs execs TFunc.cs and nuclear.cs, and neither file is in the archive.  The
// functions they held (TFunc::Rand, TFunc::SpawnFX, TFunc::ArtificialOffset,
// TFunc::GetRandomOffset, THNuke::*, largeDeployArea, FindDistDown, THResuply) are undefined, so
// the features that call them do nothing: see PORT-REPORT.md for the list.
//
// Optional settings (the mod's own defaults are in scripts\game.cs):
//    $THTKHandling = 1;   // team-kill punisher (score loss, death, and from the 8th "evil" point a 1-hour ban)
//-----------------------------------------------------------

echo("Talon Rules 2.1 (TalonHawk) -- 1.50 port entry");

//-----------------------------------------------------------------------------
// Shifter2k5.cs -- mod entry point (written for the 1.50 port, 2026-10-12).
//
// console.cs ExecModScripts() execs "<mod>.cs" for every word of $modList, so
// this file is what `-mod Shifter2k5` runs.
//
// WHICH SHIFTER THIS IS: Shifter 2K5 v1.0 (2005-03-18) by ParoXsitiC & Android,
// the last build of the line Shifter K (KiLL(-) & enV.3zer0, 2003) ->
// Shifter 2K4 (ParoXsitiC, 2004) -> Shifter 2K5. It descends from Shifter v1G
// (GreyFlcn), not from the 09-28-2000 Shifter. Both of those are separate packs
// (Mods\Shifter_v1G, Mods\Shifter).
//
// The original launch line was
//     "TribesDoSFixIS.exe" +exec serverConfig -mod shifter -dedicated
// with config\serverDefaults.cs (the Shifter variables) picked up by console.cs
// and shifter\autoexec.cs exec'ing seven function files. This file reproduces
// that chain. The mod is FLAT: its own server.cs / game.cs / admin.cs / item.cs
// win over base's because Mods\Shifter2k5\scripts precedes base\scripts.
//-----------------------------------------------------------------------------

// Functions the mod calls that live in files this port does not ship, or that
// the 2K5 release lost. See the notes in the file.
exec("Shifter2k5Compat.cs");

// shifter\autoexec.cs, as shipped (LastHope.cs was already commented out there):
exec("SBA_Duel.cs");
exec("playerfuncs.cs");
exec("AdminServerConfig.cs");
exec("AdminGameConfig.cs");
exec("equiptopts.cs");
exec("Nofog.cs");
exec("missionopts.cs");

// The Tab menu's "Shifter 2K5 1.0" page (team, updates, help). The release
// shipped this file as shifter2K5.cs and exec'd it from nowhere, so that page
// never answered. Renamed because a script called <ModWord>.cs would collide
// with this entry file.
exec("Shifter2K5Info.cs");

// config\serverDefaults.cs of the release: the $Shifter:: gameplay switches.
// Renamed so it does not shadow base's serverDefaults.cs.
exec("Shifter2k5Defaults.cs");

// config\serverconfig.cs of the release (the +exec serverConfig of the launch
// line). Also re-exec'd by the admin menu's "Reset Server Defaults".
// Host name, port, start map, master list, telnet and the default admin
// passwords are commented out in it (marker //PORT-OFF:).
exec("serverConfig.cs");

echo("[MOD] Shifter 2K5 v1.0 (2005-03-18) active");

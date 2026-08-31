//-----------------------------------------------------------------------------
// TotalAnnihilation.cs -- mod entry point.
//
// console.cs:267 ExecModScripts() execs "<mod>.cs" for every word of $modList,
// so this file is what `-mod TotalAnnihilation` runs. It is deliberately thin:
// the mod's real boot work all happens inside its own server.cs / game.cs /
// item.cs, which the client's normal flat exec list already picks up because
// Mods\TotalAnnihilation\scripts precedes base\scripts on the search path.
//
// **INSTALL SHAPE (2026-08-29). The upstream package is a whole Tribes install
// whose gameplay is ONE archive: TotalAnnihilation\scripts.vol, 304 .cs. That
// archive is deliberately NOT shipped here -- it is parked in
// C:\Dynamix\_modbackups\totalannihilation-install-20260829\. Only the 304
// files extracted loose into scripts\ are installed.
//
// **WHY, and this inverts the old advice -- MEASURED, not assumed.** The
// standing workaround for an archive-only mod was "extract the archive into
// <mod>\scripts\ and keep the archive too" (DeltaAirForce ships both), because
// pushBehind(ro, File) ranked any loose file ahead of any archive entry. The
// MOD-ARCHIVE RANK fix (7a220f0) changed that: File::rankVolume("scripts.vol")
// at console.cs:199 re-ranks the volume's entries by SEARCH-PATH POSITION. The
// mod root sits at rank 2 on this path and <mod>\scripts at rank 6, so with
// both present the ARCHIVE WINS and the loose tree is dead weight.
//
// Proof, from a host boot with both installed: the loose
// scripts\tsDefaultMatProps.cs had already been corrected, yet the log still
// printed "tsDefaultMatProps.cs Line: 5 - Syntax error" from the archive copy,
// alongside "[VOL] rank-promote scripts.vol (304 entries at search rank 2)".
// Every edit to the loose tree -- including TACompat.cs's shims for any file
// the archive also contains -- would have been silently ignored.
//
// So for a mod whose archive lives at the mod ROOT: ship one or the other,
// never both. Loose is chosen here because it is the editable form, and because
// the 4 upstream defects fixed during this port live in it.
// See memory: mod-scripts-shadowed-by-base.**
//-----------------------------------------------------------------------------

// Plugin shims FIRST -- TerrainInfo / GeoIp / MySQL command replacements plus
// the mod's own dangling calls. Must precede the boot script below, which is
// what arms autodoeverythingfun().
exec("TACompat.cs");

// The upstream package's config\TotalAnnihilation.cs, verbatim: AutoLock,
// Auto Base Damage, weapon disables, Prevent-Change and name bans, plus
// Duck::PullMA. Renamed only to free the "<mod>.cs" name for this entry.
//
// **MEASURED, do not "fix": this exec logs "schedule: scheduler is not running".
// The file calls autodoeverythingfun() at exec time and that function re-arms
// itself with schedule(), but at boot there is no ConsoleScheduler yet -- it is
// created in Server::loadMission. That is fine, because
// TotalAnnihilation_Settings.cs execs this same file again from inside
// createServer, where the scheduler DOES exist; that is the call that sticks.
// The boot call is still wanted: it seeds $AutoLockEnabled and the $PCTemp*
// snapshot the Prevent-Change checks compare against.**
exec("TotalAnnihilation_Boot.cs");

echo("[MOD] Total Annihilation active");

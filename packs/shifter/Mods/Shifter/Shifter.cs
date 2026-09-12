//-----------------------------------------------------------------------------
// Shifter.cs -- mod entry point.
//
// console.cs ExecModScripts() execs "<mod>.cs" for every word of $modList, so
// this file is what `-mod Shifter` runs.
//
// WHICH SHIFTER THIS IS: the 09-28-2000 release by Emo1313 (Taylor Suchan) of
// Dopplegangers -- the build the community means by "Shifter", and the one
// GreyFlcn's later fork keeps calling "9-28 spec" when it reverts toward it.
// The fork is packaged separately as Mods\Shifter_v1G.
//
// This file is deliberately thin. Shifter is a FLAT mod: its server.cs execs
// its own boot chain (comchat, shban, remote, spawn, game_dmsg, damage,
// fairteams, itemfuncs, itemmsgs, scoring, saveinfo, bindings, hologram,
// coolturret, ...) and every name it overrides resolves to its copy because
// Mods\Shifter\scripts precedes base\scripts on the search path. There is no
// exec chain to reproduce here.
//
// INSTALL SHAPE. Upstream ships one archive, scripts.vol, 90 files. It is NOT
// shipped here -- ship exactly one form, and loose is the editable one. The
// mod-archive rank rule (console.cs File::rankVolume) would otherwise let an
// archive at the mod ROOT outrank this loose tree and silently discard every
// fix made during the port. See memory: mod-scripts-shadowed-by-base.
//
// 30 of those 90 files were dropped, and this is the part that matters: they
// were VERBATIM 1998 stock copies riding along because the author built his
// volume by editing a copy of base's. Shipping them would have downgraded the
// modern client's own newer versions -- skins (PlayerSetup.cs), the video
// options screen (Options.cs), the mission editor (editor.cs), sound, keys,
// the string tables -- for no Shifter gameplay whatsoever. The drop list and
// the reason per file are in docs\PORT-NOTES.txt.
//-----------------------------------------------------------------------------

// Restores the three functions this mod shadows away but something outside it
// still calls. Must run before anything else: base's Options.cs can reach
// refreshWindowSize() as soon as the player opens the video options.
exec("ShifterCompat.cs");

echo("[MOD] Shifter 09-28-2000 active");

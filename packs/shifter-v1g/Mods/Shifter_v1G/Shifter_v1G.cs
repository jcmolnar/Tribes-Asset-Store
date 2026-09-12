//-----------------------------------------------------------------------------
// Shifter_v1G.cs -- mod entry point.
//
// console.cs ExecModScripts() execs "<mod>.cs" for every word of $modList, so
// this file is what `-mod Shifter_v1G` runs. The folder name matches the mod
// word the original servers advertised (the shipped StartShifter.bat reads
// "-mod shifter_v1G"), so joining a live v1G server resolves without needing
// the advertised-alias fallback.
//
// WHICH SHIFTER THIS IS: "Shifter HC" by GreyFlcn, final build 05-27-2002.
// It is NOT a later release of Emo1313's Shifter -- it is a fork that branched
// on 2001-05-20 and ran for a year on its own. What it adds over 9-28-2000 is a
// full competitive layer: tourney and match mode with ready-up, match tracking,
// ceasefire, fair teams, vote-for-leader, nuke and det counters for referees,
// and anti-cheat work (the SuperHack exploit and the team-change hack are both
// removed). Its 2001 balance diverged hard, then walked back toward 9-28 spec
// through 2002. The original is packaged separately as Mods\Shifter.
//
// This file is deliberately thin. Shifter is a FLAT mod: its server.cs execs
// its own boot chain (comchat, shban, remote, spawn, game_dmsg, damage,
// fairteams, itemfuncs, itemmsgs, scoring, saveinfo, bindings, hologram,
// coolturret, ...) and every name it overrides resolves to its copy because
// Mods\Shifter_v1G\scripts precedes base\scripts on the search path. There is
// no exec chain to reproduce here.
//
// INSTALL SHAPE. Upstream ships one archive, scripts.vol, 89 files. It is NOT
// shipped here -- ship exactly one form, and loose is the editable one. The
// mod-archive rank rule (console.cs File::rankVolume) would otherwise let an
// archive at the mod ROOT outrank this loose tree and silently discard every
// fix made during the port. See memory: mod-scripts-shadowed-by-base.
//
// 26 of those 89 files were dropped as verbatim 1998 stock copies riding along
// in the author's volume -- skins, sound, keys, the string tables, the mission
// editor. Shipping them would have downgraded the modern client's own newer
// versions for no Shifter gameplay. v1G's Options.cs IS kept: unlike the
// 9-28-2000 build's, it carries the mod's own 20-faves work. The full drop list
// with a reason per file is in docs\PORT-NOTES.txt.
//-----------------------------------------------------------------------------

// Restores the two functions this mod shadows away but something outside it
// still calls.
exec("ShifterCompat.cs");

echo("[MOD] Shifter HC v1G (05-27-2002) active");

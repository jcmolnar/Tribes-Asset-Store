//-----------------------------------------------------------------------------
// Duel.cs -- mod entry point.
//
// console.cs ExecModScripts() execs "<word>.cs" for every -mod word, so this file
// runs for `-mod Duel`, after base's own boot chain and before the prefs files.
//
// WHICH MOD THIS IS: Duel Tournament by [HvC]NaTeDoGG -- the 1v1 / team-duel
// tournament server mod, later maintained by Krayvok, Lestat and =Argh!=. This
// port was taken from the =Argh!='s Duel (PlayT1.com) server tree.
//
// HOW IT BOOTS -- this is unusual and worth knowing before you change anything.
// There is no single "load the mod" call. Two separate things happen:
//
//   1. -mod Duel puts Mods\Duel\scripts ahead of base\scripts on the search path,
//      so the stock exec chain in console.cs and createServer() silently resolves
//      to THIS mod's copies of item.cs, ArmorData.cs, baseProjData.cs,
//      staticshape.cs, station.cs, turret.cs, vehicle.cs, sensor.cs, Mine.cs,
//      observer.cs, comchat.cs, admin.cs, game.cs and objectives.cs. That is
//      where the duel weapons, armours and arena props come from, and it happens
//      on EVERY map, duel or not.
//
//   2. The duel GAMEPLAY is loaded per-mission: 159 of the shipped maps carry
//      `exec(duelmod);` in the mission file itself, and duelmod.cs is what pulls
//      in serverConfig.cs, AdminRemotes, AntiCrash and the eight-file TD chain
//      (TDSupport, TDMenu, TDMain, TDOverWriting, TDArena, TDObjectives,
//      TDScores, TDSave). Host a stock CTF map under -mod Duel and you get the
//      mod's datablocks with base rules -- which is exactly what upstream did.
//
// Because of (1), anything item.cs and friends depend on has to exist from boot,
// not from the first duel map. That is why DuelCompat.cs is exec'd here and not
// from duelmod.cs.
//
// SETTINGS live in Mods\Duel\serverConfig.cs (host name, admin passwords, time
// limit, team-duel toggles). duelmod.cs re-execs it at mission load, so it wins
// over config\serverPrefs.cs -- that is upstream's behaviour, kept deliberately.
// To override it without editing the pack, drop your own copy at
// config\serverConfig.cs; config is first on the search path.
//
// INSTALL SHAPE. Loose scripts only -- no scripts.vol. The mod-archive rank rule
// would let an archive at the mod root outrank this tree and silently discard
// every fix made during the port (see memory: mod-scripts-shadowed-by-base).
// The seven custom arena interiors that upstream kept in base\custom.vol are
// unpacked loose at the mod root for the same reason.
//
// WHAT WAS DROPPED and why is in docs\PORT-NOTES.txt -- 62 of the 175 upstream
// scripts were verbatim 1998 stock copies riding along, and shipping them would
// have downgraded this client's own newer versions.
//-----------------------------------------------------------------------------

// Names the mod calls but never shipped a definition for. Must be defined before
// item.cs et al run, i.e. before createServer(), which is why it is here.
exec("DuelCompat.cs");

echo("[MOD] Duel Tournament active -- by [HvC]NaTeDoGG");

//-----------------------------------------------------------------------------
// ShifterBots.cs -- mod entry point (written for the 1.50 port, 2026-10-12).
//
// console.cs ExecModScripts() execs "<mod>.cs" for every word of $modList, so
// this file is what `-mod ShifterBots` runs.
//
// WHICH SHIFTER THIS IS: Shifter v1 by Emo1313, the 10-09-99 build "with Bots":
// the first-year Shifter (eight armors, MiniMod v.07 core by Dewy) with SpoonBot
// (Werewolf, Wicked69) built in. Two years older than the 09-28-2000 Shifter
// (Mods\Shifter) and a different code base from Shifter HC v1G (Mods\Shifter_v1G)
// and Shifter 2K5 (Mods\Shifter2k5). All four can stay installed.
//
// The original launch line (Shifter Dedicated.bat of the 10-05-99 release) was
//     tribes -mod shifter +exec shifter_v1.cs exec serverConfig.cs -dedicated
// The mod is FLAT: its own server.cs / game.cs / admin.cs / item.cs win over
// base's because Mods\ShifterBots\scripts precedes base\scripts. server.cs loads
// the MiniMod core from Mods\ShifterBots\plugins\MiniMod (file masks
// "plugins\*.<Kind>.cs"), so that folder must keep its name and place.
//-----------------------------------------------------------------------------

// One helper the port's security fix in admin.cs calls.
exec("ShifterBotsCompat.cs");

// The +exec shifter_v1.cs of the launch line: every $Shifter::, $Score:: and
// $Spoonbot:: setting (vote switches, team-kill ban, welcome message, the six
// bots that spawn with each mission, bot loadouts). Edit it to taste.
// The author's auto-admin name list and e-mail address are commented out in it
// (marker //PORT-OFF:).
exec("Shifter_v1.cs");

// serverConfig.cs was the host's own file and is not part of the release; base's
// serverDefaults.cs / config\ServerPrefs.cs (exec'd after this file) hold the
// host name, passwords and port.

echo("[MOD] Shifter v1 with Bots (10-09-99) active");

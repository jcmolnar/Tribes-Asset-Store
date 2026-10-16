// WWII Mod -- host settings. Edit freely; a copy in config\ wins over this one.
// (Rewritten for the Modern Tribes port: the original file advertised its 2010 host, website
// and clan on every server that ran it. The variables and their meaning are unchanged.)

// Join messages, shown one after another while a player loads (six of them, 0 to 5).
$msg[0] = "<f1>Welcome to the WWII mod!\n\n<f0>No jetpacks. Pick a class, pick a spawn point,\nand take the outposts.";
$msg[1] = "<f1>How to play\n<f0>Fire to open the spawn menu. Number keys pick a class,\nthen a spawn point.";
$msg[2] = "<f1>Keys\n<f0>Beacon key: special action (air strike with binoculars, detonator).\nRepair kit key: reload.";
$msg[3] = "<f1>Keys\n<f0>Targeting laser key: open the parachute while falling.\nInventory key: take the kit of a dead soldier.";
$msg[4] = "<f0>More information is in the TAB menu. Respect the other players: no team killing, no spawn killing.";
$msg[5] = "<f1>Prepare to meet the battlefield!\nLoading...";

// Advert loop: one line to everybody every 45 seconds. $loops = how many lines there are.
// Keep at least six lines: the loop starts on a random line from 0 to 5.
$loops = 6;
$loop[0] = "The spawn menu can be reopened at any time: press TAB twice.";
$loop[1] = "Mod information is in the TAB menu.";
$loop[2] = "Standing next to an ammo box resupplies and heals you.";
$loop[3] = "Crouching makes you a smaller target.";
$loop[4] = "Scouts can call an air strike: binoculars out, then the beacon key.";
$loop[5] = "WWII mod by Roma.";

// Welcome text (centre of the screen on join).
$Welcome = "<jc><f1>Welcome to the WWII mod!\n\n<f2>Have fun and behave!\nFire to play.";

// Admin passwords, one per admin level (2 = lowest, 5 = server owner). Blank = that level is off.
// A player logs in from the console with:  remoteEval(2048, login, "the password");
// Three wrong tries and the player is kicked. The player who hosts from the game menu is
// level 5 without logging in.
//   2: manage players (team, score reset, vote lock)      3: + mission options, kick, mute
//   4: + bans up to four hours, freeze / jail / blind      5: + day and permanent bans, server restart
$WWII::AdminPassword[2] = "";
$WWII::AdminPassword[3] = "";
$WWII::AdminPassword[4] = "";
$WWII::AdminPassword[5] = "";

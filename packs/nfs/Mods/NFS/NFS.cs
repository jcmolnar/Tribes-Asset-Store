// The Need For Speed v36B (Blade[INC] and Enforcer[INC], July 1999) -- Modern Tribes (1.50) entry script.
// The original was started with:  Tribes.exe -mod NFSv36 [-dedicated]   (readme.txt).
// Nothing else was exec'd: server.cs and game.cs load from this mod's scripts folder and
// server.cs loads the rest.
echo(">> The Need For Speed v36B");

// The release carries SpoonBot (ai.cs) and its settings file spoonbot.cs, but no script of the
// release ever loaded that file, so the bot menu ("Spoonbot controls" in the admin Tab menu) and
// the automatic bots never showed up on a 1999 server. It stays that way here. To switch the bots
// on, remove the two slashes from the next line (the settings are in spoonbot.cs beside this file):
// exec("spoonbot.cs");

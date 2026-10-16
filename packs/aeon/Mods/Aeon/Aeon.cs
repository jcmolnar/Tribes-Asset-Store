// AEON by Ice (2008) -- Modern Tribes (1.50) port, entry script.
//
// The release asked the host to move Aeon\temp\AeonServer.cs to Tribes\temp and edit it. That
// file set the host name, port 28001, "public game" and the player limit as well as the five mod
// settings below. The port does not ship it: the mod settings get their release values here, and
// the host's own server prefs are left alone. A host who wants to change them can still create
// temp\AeonServer.cs; createServer execs it after every script (server.cs).

$Aeon::activeSky = false;                 // whether the sky animates (moving clouds)
$Aeon::rockFall = 45;                     // seconds between spawned meteors
$Aeon::rockValue = 35.0;                  // most cash from a fresh meteor rock
$Aeon::rockAdd = 10.0;                    // cash added with maxed geology
$Aeon::servInfo = "<f3>Made by Ice!";     // join screen line

// The mod only works on its own map (missions\Free.mis: the "Central" group, properties,
// terminals). Start the server on Free.
echo("AEON (1.50 port) loaded. Mission: Free.");

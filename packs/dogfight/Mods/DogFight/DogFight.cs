// DogFight v1.5 by {SOF} Snake eye, October 2002 -- Modern Tribes (1.50) port, entry script.
//
// Original install (Readme.txt): "Extract Scripts.vol to Tribes\dogfight, extract
// DogfightServerConfig to Tribes\Config"; the earlier readmes give the launch line: add
// "-mod DogFight" to the Tribes shortcut. The mod's server.cs execs the settings file at
// createServer; here it is Mods\DogFight\DogfightServerConfig.cs.

// The deploy code calls these two helpers; no DogFight version ever defined them (they come from
// the mod the deploy and Stinger code was taken from). Both only reported; defined here so the
// host log is not filled with "Unknown command" lines.
function reportDeploy(%obj, %client)
{
   echo("DEPLOY: " @ %client @ " deployed " @ GameBase::getDataName(%obj));
}

function SendLockWarning(%client, %kind)
{
   // nothing: DogFight never warned the target (the call had no function behind it)
}

echo("DogFight 1.5 (1.50 port) loaded.");

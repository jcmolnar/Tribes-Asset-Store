// DeltaForce 1.0 -- Modern Tribes (1.50) entry script.
// The original launch line was: tribes -mod deltaforce (-dedicated). Nothing else was exec'd: the
// client's own console.cs loads server.cs and game.cs from this mod's scripts folder.
//
// Server owners: the two settings the readme describes still work from your server prefs:
//   $Server::FuzzyPhysics = true;   cheaper ground-vehicle physics
//   $Server::SmokePuffs = 8;        seconds a smoke grenade stays active
echo(">> DeltaForce 1.0");

// PORT FIX: DF_ReignDeath's own Flag::onDrop calls sendMessageExcept(), which no DeltaForce script
// defines, so every flag drop on that map logged "sendMessageExcept: Unknown command." and the other
// players were never told. It is the stock messageAllExcept under another name.
function sendMessageExcept(%except, %mtype, %message)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		if(%cl != %except)
			Client::sendMessage(%cl, %mtype, %message);
}

// PORT FIX: dm.cs calls DMTEAM::missionObjectives() on every score refresh, at mission start and at
// the time limit of a team "Fire Fight" map (DF_JaggedTooth, DF_JaggedToothII), but only ever
// defines DMTEAM::teamMissionObjectives(team). Each call logged "Unknown command." This refreshes
// every team's objectives screen through the function the mod does have.
function DMTEAM::missionObjectives()
{
	for(%t = 0; %t < $numTeams; %t++)
		DMTEAM::teamMissionObjectives(%t);
}

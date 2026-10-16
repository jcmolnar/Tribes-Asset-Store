// Top Gun 1.0 (Patriot, September 2002) -- Modern Tribes (1.50) entry script.
// The original was started with:  tribes -mod TopGun -dedicated   (the shortcut in the release zip).
// Nothing else was exec'd: the client's own console.cs loads server.cs and game.cs from this mod's
// scripts folder, and server.cs loads the rest.
//
// Top Gun is an edit of the DeltaForce 1.0 mod; readme.txt is DeltaForce's own and still describes
// the infantry weapons, the Tab menu's Weapon Options and the two server settings:
//   $Server::FuzzyPhysics = true;   cheaper ground-vehicle physics
//   $Server::SmokePuffs = 8;        seconds a smoke grenade stays active
echo(">> Top Gun 1.0");

// PORT FIX: dm.cs calls DMTEAM::missionObjectives() on every score refresh, at mission start, on a
// mission vote and at the time limit of any deathmatch map with teams, but only ever defines
// DMTEAM::teamMissionObjectives(team). Each call logged "DMTEAM::missionObjectives: Unknown
// command." This refreshes every team's objectives screen through the function the mod does have.
function DMTEAM::missionObjectives()
{
	for(%t = 0; %t < $numTeams; %t++)
		DMTEAM::teamMissionObjectives(%t);
}

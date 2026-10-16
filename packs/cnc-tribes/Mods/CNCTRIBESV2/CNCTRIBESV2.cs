// C&C Tribes V2 (Lennex Production Studios, 2000) -- Modern Tribes (1.50) entry script.
//
// The original was two mod folders: the Alliance engine and CNCTRIBESV2 on top of it
// (-mod alliance -mod CNCTRIBESV2). The Alliance scripts this mod loads are folded into
// scripts\ here, so the launch line is just: -mod CNCTRIBESV2
// The installer also put the mod's models, textures and prefab buildings into base\;
// they now live in this folder, which is on the search path ahead of base.
echo(">> C&C Tribes V2");

// The mod's server.cs picks the next map with this when $RandomMissions is set. It came
// from the mod's own copy of missionList.cs, which is otherwise the stock file and is
// not shipped (the client's own missionList.cs builds the list).
function MissionList::nextRandom()
{
	%i = floor(getRandom() * $MLIST::Count);
	return $MLIST::EName[%i];
}

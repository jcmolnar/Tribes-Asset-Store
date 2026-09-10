// Reality Bites 2.0 -- compatibility shims (Modern Client port, 2026-09-04).
//
// The mod calls four functions it never defines and base does not define either. They
// came from the Stormbots AI package Reality Bites 1.x shipped alongside the mod
// (config\Stormbots.cs) and 2.0 dropped. Without these every call prints
// "<name>: Unknown command." and returns nothing. Each call site is a bare statement
// (no return value consumed), so a no-op is exactly the behaviour the mod already had
// on a 2.0 install; the two admin-menu ones additionally tell the admin why nothing
// happened instead of failing silently.
//
//   admin.cs      processMenuRBot        -> AI::RemoveBot(%option, %clientId)
//   admin.cs      processMenuBotAllDone  -> AI::SpawnAdditionalBot(%name, %team, %clientId, %bought)
//   item.cs       Item::giveItem         -> BotGear::CheckBackpack(%client)   (AI players only)
//   objectives.cs Flag::drop (schedule)  -> Flag::AIReturnFlag(%flag)         (every flag drop)

function AI::SpawnAdditionalBot(%name, %team, %clientId, %bought)
{
	if(%clientId != "")
		Client::sendMessage(%clientId, 0, "Stormbots are not part of Reality Bites 2.0 - no bot was spawned.");
	echo("rb2Compat: AI::SpawnAdditionalBot(" @ %name @ ") ignored (Stormbots not shipped)");
}

function AI::RemoveBot(%name, %clientId)
{
	if(%clientId != "")
		Client::sendMessage(%clientId, 0, "Stormbots are not part of Reality Bites 2.0 - nothing to remove.");
	echo("rb2Compat: AI::RemoveBot(" @ %name @ ") ignored (Stormbots not shipped)");
}

function BotGear::CheckBackpack(%client)
{
	// Stormbots gear bookkeeping; stock AI does not need it.
}

function Flag::AIReturnFlag(%flag)
{
	// Stormbots "nearest bot returns the flag"; Flag::checkReturn still auto-returns it.
}

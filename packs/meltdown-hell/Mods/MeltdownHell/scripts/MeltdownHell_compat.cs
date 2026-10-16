// MeltdownHell_compat.cs -- port file, not part of the original release.
//
// Every function here is CALLED by the Meltdown Hell 3.3 scripts and DEFINED by none of them: the
// build was cut from the HaVoC and Shifter sources and these helpers were left behind. In 2001 each
// call printed "Unknown command" on the server and returned nothing. The definitions below keep
// exactly that result (nothing happens) without the log spam, except where a real body was known.
// Same list as the Meltdown Total War 2001 port (same inherited code), plus DesignateTarget.

// station.cs:331 and :428. Stock Tribes body (the mod's item.cs dropped it).
function isPlayerBusy(%client)
{
	// Can't buy things if busy shooting.
	%state = Player::getItemState(%client,$WeaponSlot);
	return %state == "Fire" || %state == "Reload";
}

// deployables.cs:22, used only inside an echo().
function getName(%player)
{
	return Client::getName(Player::getClient(%player));
}

// deployables.cs:185/192/252/259 -- HaVoC deploy bookkeeping, body unknown.
function dotog(%player) { }
function doset(%client, %player, %turret) { }

// deployables.cs:130 -- meant to count turrets near the deploy point ("Too many turrets in the
// area" when over 4). It never existed in this build, so the limit never applied: return 0.
function CountThes(%set, %num) { return 0; }

// deployables.cs:4641 -- "is this inside the enemy base" test for the shield generator. Never
// existed, so the deploy was always allowed.
function checkenemybase(%pos, %obj, %player) { return false; }

// player.cs:656 (changewat) -- body unknown; a missing function reads as false.
function e(%cl) { return false; }

// comchat.cs:64 -- meant to copy cross-team private chat to the admins. Never existed.
function cheatAdminMsg(%msg) { }

// weapons.cs, 20 call sites -- missile lock warning for the target. Never existed.
function SendLockWarning(%clientId, %level) { }

// staticshape.cs:40 -- Shifter's target-designator hook for damage of type $NullDamageType on a
// static shape. Never existed; the damage call returned without doing anything, as it does now.
function DesignateTarget(%this, %value, %object) { }

// NOT defined here on purpose:
//   Scout::onAdd (station.cs) -- Scout is a FlierData datablock, so a script function of that name
//     would become the datablock's own onAdd callback. The call site is removed instead.
//   AI::SpawnAdditionalBot / AI::RemoveBot (admin.cs bot menu) -- this build ships SpoonBot files
//     but never loads them; the "Bioderm Options" menu line is switched off instead.
//   FinalizeDuel / DuelResetClient (admin.cs, kick on a "Duel" mission type) -- no duel scripts here.

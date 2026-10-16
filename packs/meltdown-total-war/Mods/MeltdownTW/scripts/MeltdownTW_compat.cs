// MeltdownTW_compat.cs -- port file, not part of the original release.
//
// Every function here is CALLED by the build 124 scripts and DEFINED by none of them: the build was
// cut from the HaVoC and Shifter sources and these helpers were left behind. In 2001 each call
// printed "Unknown command" on the server and returned nothing. The definitions below keep exactly
// that result (nothing happens) without the log spam, except where a real body was known.

// station.cs:334 and :431. Stock Tribes body (the mod's item.cs dropped it).
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

// NOT defined here on purpose: Scout::onAdd (station.cs:1030). Scout is a FlierData datablock, so a
// script function of that name would be picked up as the datablock's own onAdd callback. The call
// site is removed instead (fixes-compat.json).

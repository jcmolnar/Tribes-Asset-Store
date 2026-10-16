// Armageddon_compat.cs -- port file, not part of the original release.
//
// Every function here is CALLED by the Armageddon ("Meltdown v w00") scripts and DEFINED by none of
// them: the build was cut from the Meltdown / HaVoC / Shifter sources and these helpers were left
// behind. In 2002 each call printed "Unknown command" on the server and returned nothing. The
// definitions below keep exactly that result (nothing happens) without the log spam, except where a
// real body was known. Same list as the other Meltdown ports where the inherited code is the same.

// station.cs:329 and :426. Stock Tribes body (the mod's item.cs dropped it).
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

// deployables.cs:2255 -- "is this inside the enemy base" test for the shield generator. Never
// existed, so the deploy was always allowed.
function checkenemybase(%pos, %obj, %player) { return false; }

// player.cs:888 -- body unknown; a missing function reads as false.
function e(%cl) { return false; }

// comchat.cs:600 -- meant to copy "Speak To" private chat to the admins. Never existed.
function cheatAdminMsg(%msg) { }

// staticshape.cs:40 -- Shifter's target-designator hook for damage of type $NullDamageType on a
// static shape. Never existed; the damage call returned without doing anything, as it does now.
function DesignateTarget(%this, %value, %object) { }

// weapons.cs:294 -- one call at load time, AddDeployable(EForcefield). Never existed.
function AddDeployable(%name) { }

// deployables.cs:3686/:3746 and the schedule at :3730/:3764 -- the "busy" flag of the deployable
// power-grid items. Body as in Meltdown Hell / X / Ultra (deployables.cs there).
function ItemBusy(%this)
{	%this.isbusy=true;
}

function ItemNotBusy(%this)
{	%this.isbusy=false;
}

// deployables.cs:98/:106 -- scheduled 1.15 s after a deployed power item is picked up, to hand the
// pack back. Never existed in this build: the item was deleted and nothing came back. Unchanged.
function PlaceItemPack(%player, %pName, %pos) { }

// turret.cs:526/:528 -- end of the HaVoC "re-program an enemy turret" timer. The branch that
// schedules it is switched off in this build (if(%lllll), a variable nothing sets).
function checkReProgTurret(%client, %turret, %oldT, %ds) { }

// objectives.cs:47 and :457 (the second only when $Shifter::ScoreTracker is set) -- hooks of a
// stats add-on that is not in the archive.
function TribeStat_ShowScores() { }
function ScoreTracker(%clientId) { }

// game.cs:1077 -- the team-kill limit. The mod announces "<name> was kicked and banned for
// teamkilling", adds the address ban and the name ban, then calls KickPlayer(), which this build
// never defined: the banned player stayed connected until he left. Body from Meltdown Ultra
// (server.cs there), with the message escaped. OWNER'S CALL: this makes the announced kick real.
function KickPlayer(%clientId, %msg)
{
	%name = Client::getName(%clientId);
	echo("ADMINMSG: **** Player " @ escapeString(%name) @ " is being kicked.");
	schedule("Net::Kick(" @ floor(%clientId) @ ", \"" @ escapeString(%msg) @ "\");", 1);
}

// NOT defined here on purpose:
//   Scout::onAdd (station.cs) -- Scout is a FlierData datablock, so a script function of that name
//     would become the datablock's own onAdd callback. The call site is removed instead.
//   FinalizeDuel / DuelResetClient (admin.cs, kick on a "Duel" mission type) -- the duel scripts
//     (duelmod.cs, duelmatch.cs, resetduel.cs) are held back; no Duel mission ships.
//   nextMission (dm.cs:149, end of a deathmatch by frag limit) -- stock Tribes has the same call.

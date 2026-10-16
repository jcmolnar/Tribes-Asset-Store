// MeltdownUltra_compat.cs -- port file, not part of the original release.
//
// Every function here is CALLED by the 2.33 scripts and DEFINED by none of them: helpers left
// behind when the code was cut from HaVoC, Shifter and the AAOD deployables. In 2003 each call
// printed "Unknown command" on the server and returned nothing. The definitions below keep exactly
// that result (nothing happens) without the log spam, except where a real body was known.

// baseProjData.cs (power beam released from an unpowered station). Stock Tribes body; the mod's
// station.cs dropped the function.
function Station::weaponCheck(%this)
{
	if(%this.lastPlayer != "") {
		%player = %this.lastPlayer;
		if(getObjectType(%player) != "Player") {
			%this.lastPlayer = "";
			return;
		}
		%player.Station = "";
		if(Player::getMountedItem(%player,$WeaponSlot) == -1) {
			if(%player.lastWeapon != "") {
				Player::useItem(%player,%player.lastWeapon);
				%player.lastWeapon = "";
			}
		}
		%this.lastPlayer = "";
	}
}

// deployables.cs:22, used only inside an echo().
function getName(%player)
{
	return Client::getName(Player::getClient(%player));
}

// deployables.cs -- HaVoC deploy bookkeeping, body unknown.
function dotog(%player) { }
function doset(%client, %player, %turret) { }

// deployables.cs:130 -- meant to count turrets near the deploy point ("Too many turrets in the
// area"). It never existed in this build, so the limit never applied: return 0.
function CountThes(%set, %num) { return 0; }

// deployables.cs -- "is this inside the enemy base" test for the shield generator. Never existed,
// so the deploy was always allowed.
function checkenemybase(%pos, %obj, %player) { return false; }

// player.cs changewat -- body unknown; a missing function reads as false.
function e(%cl) { return false; }

// weapons.cs, 10 call sites -- missile lock warning for the target. Never existed.
function SendLockWarning(%clientId, %level) { }

// objectives.cs ObjectiveMission::missionComplete -- Shifter's TribeStat hook. Never existed here.
function TribeStat_ShowScores() { }

// objectives.cs -- Shifter's score tracker, called only when $Shifter::ScoreTracker is set.
function ScoreTracker(%clientId) { }

// objectives.cs, 2 call sites: "ho(" is "echo(" with two letters lost (a debug line that printed
// the point value of a destroyed object). It never printed; it still does not.
function ho(%text) { }

// staticshape.cs (team-mate touching a large force field) and deployables.cs
// (BlastFloorShape::onDestroyed). Neither function exists in this build.
function LargeForceField::Open(%this) { }
function BlastDoorShape::doDamage(%this) { }

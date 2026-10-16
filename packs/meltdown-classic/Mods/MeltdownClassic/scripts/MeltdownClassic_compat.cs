// MeltdownClassic_compat.cs -- port file, not part of the original release.
//
// Every function here is CALLED by the v1.15 scripts and DEFINED by none of them (helpers left
// behind when the code was cut from HaVoC, Shifter and the AAOD deployables). In 2000 each call
// printed "Unknown command" on the server and did nothing. The definitions below keep exactly that
// result without the log spam.

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

// objectives.cs (base-kill warning) -- meant to tell the admins. Never existed.
function cheatAdminMsg(%msg) { }

// objectives.cs (base-kill count): "was the last hit from a turret". Never existed, so the answer
// was always no.
function isTurret(%obj) { return false; }

// player.cs changewat -- body unknown; a missing function reads as false.
function e(%cl) { return false; }

// deployables.cs teleport pads: push a blocked object off the pad. Never existed.
function Eject(%pad, %object) { }

// deployables.cs (teleport pad, mobile ammo station): "pack the deployed item back up". Never
// existed, so packing up never happened: return false.
function PackUpStuff(%this, %client, %player, %armor, %desc, %nopack, %pName) { return false; }

// deployables.cs dropship deploy: log line. Never existed.
function reportDeploy(%obj, %client) { }

// deployables.cs dropship generator power switch and HPCPack::Destruct. Never existed.
function DropShipPack::setPower(%team, %on) { }
function DeployableDropship::doDamage(%this) { }

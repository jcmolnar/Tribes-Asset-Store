// This is a MiniMod Macro-Plugin.
// Due to the nature of this plugin it cannot be broken down into inividual plugins.
//
// This is the set of armors and weapons from the Ideal Mod.
// Note: At the time of this plugin's release, MiniMod v.03~v.05 only supports this
//  kind of plugin in the most "BETA'ish" form. If you are not a good scriptor it is
//  NOT recommended that you play with these.
//
// Unless Macro-plugins are ported in a EXTREMELY articulate manner they cause
//  massive amounts of clashing with other plugins!!!

function Mission::reinitData()
{
	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = 0; %i < 8; %i++)
	{
		$TeamItemCount[%i @ DeployableAmmoPack] = 0;
		$TeamItemCount[%i @ DeployableInvPack] = 0;
		$TeamItemCount[%i @ TurretPack] = 0;
		$TeamItemCount[%i @ CameraPack] = 0;
		$TeamItemCount[%i @ DeployableSensorJammerPack] = 0;
		$TeamItemCount[%i @ PulseSensorPack] = 0;
		$TeamItemCount[%i @ MotionSensorPack] = 0;
		$TeamItemCount[%i @ ScoutVehicle] = 0;
		$TeamItemCount[%i @ LAPCVehicle] = 0;
		$TeamItemCount[%i @ HAPCVehicle] = 0;
		$TeamItemCount[%i @ Beacon] = 0;
		$TeamItemCount[%i @ originalMine] = 0;
		$TeamItemCount[%i @ NuclearTurretPack] = 0;
		$TeamItemCount[%i @ TreePack] = 0;
		$TeamItemCount[%i @ JetFireVechicle] = 0;
		$TeamItemCount[%i @ ObeliskPack] = 0;
		$TeamItemCount[%i @ ObeliskPowerPack] = 0;
		$TeamItemCount[%i @ FlameTurretPack] = 0;
		$TeamItemCount[%i @ ArbitorBoxPack] = 0;
		$TeamItemCount[%i @ ReplicatingMine] = 0;
		$TeamItemCount[%i @ FlagMine] = 0;
		$TeamItemCount[%i @ "originalreplicatingmine"] = 0;

		$TeamEnergy[%i] = $DefaultTeamEnergy;
	}
}

function Mission::reinitData()
{

	$TeamItemCount[0 @ DeployableHucker] = 0;
	$TeamItemCount[1 @ DeployableHucker] = 0;
	$TeamItemCount[2 @ DeployableHucker] = 0;
	$TeamItemCount[3 @ DeployableHucker] = 0;
	$hucky = 0;
	$totalNumHuckers = 0;

	$TeamItemCount[0 @ ZapperPack] = 0;
	$TeamItemCount[1 @ ZapperPack] = 0;
	$TeamItemCount[2 @ ZapperPack] = 0;
	$TeamItemCount[3 @ ZapperPack] = 0;
	$zap = 0;
	$totalNumZapper = 0;

	$TeamItemCount[0 @ Girl] = 0;
	$TeamItemCount[1 @ Girl] = 0;
	$TeamItemCount[2 @ Girl] = 0;
	$TeamItemCount[3 @ Girl] = 0;
	$totalNumGirl = 0;
	$Girl = 0;

	$TeamItemCount[0 @ Twig] = 0;
	$TeamItemCount[1 @ Twig] = 0;
	$TeamItemCount[2 @ Twig] = 0;
	$TeamItemCount[3 @ Twig] = 0;
	$totalNumTwig = 0;
	$Twig = 0;

	$TeamItemCount[0 @ plat] = 0;
	$TeamItemCount[1 @ plat] = 0;
	$TeamItemCount[2 @ plat] = 0;
	$TeamItemCount[3 @ plat] = 0;
	$totalNumPlat = 0;
	$plat = 0;


	$TeamItemCount[0 @ vortexTurretPack] = 0;
	$TeamItemCount[1 @ vortexTurretPack] = 0;
	$TeamItemCount[2 @ vortexTurretPack] = 0;
	$TeamItemCount[3 @ vortexTurretPack] = 0;
	$totalNumVortex = 0;
	$vortex = 0;

	$TeamItemCount[0 @ door4x14pack] = 0;
	$TeamItemCount[1 @ door4x14pack] = 0;
	$TeamItemCount[2 @ door4x14pack] = 0;
	$TeamItemCount[3 @ door4x14pack] = 0;
	$BigBlue = 0;
	$totalNumBigBlue = 0;

	$TeamItemCount[0 @ door5x5pack] = 0;
	$TeamItemCount[1 @ door5x5pack] = 0;
	$TeamItemCount[2 @ door5x5pack] = 0;
	$TeamItemCount[3 @ door5x5pack] = 0;
	$Blue = 0;
	$totalNumBlue = 0;

	$TeamItemCount[0 @ BlastWall] = 0;
	$TeamItemCount[1 @ BlastWall] = 0;
	$TeamItemCount[2 @ BlastWall] = 0;
	$TeamItemCount[3 @ BlastWall] = 0;
	$Blast = 0;
	$totalNumBlast = 0;

	$TeamItemCount[0 @ PencilPack] = 0;
	$TeamItemCount[1 @ PencilPack] = 0;
	$TeamItemCount[2 @ PencilPack] = 0;
	$TeamItemCount[3 @ PencilPack] = 0;
	$PencilPack = 0;
	$totalNumPencil = 0;


	$Vortex = 0;
	$totalNumVortex = 0;


	$TeamItemCount[0 @ DeployableAmmoPack] = 0;
	$TeamItemCount[0 @ DeployableInvPack] = 0;
	$TeamItemCount[0 @ TurretPack] = 0;
	$TeamItemCount[0 @ CameraPack] = 0;
	$TeamItemCount[0 @ TurretMinePack] = 0;
	$TeamItemCount[0 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[0 @ PulseSensorPack] = 0;
	$TeamItemCount[0 @ MotionSensorPack] = 0;
	$TeamItemCount[0 @ ScoutVehicle] = 0;
	$TeamItemCount[0 @ LAPCVehicle] = 0;
	$TeamItemCount[0 @ HAPCVehicle] = 0;
	$TeamItemCount[0 @ Beacon] = 0;
	$TeamItemCount[0 @ mineammo] = 0;

	$TeamItemCount[1 @ DeployableAmmoPack] = 0;
	$TeamItemCount[1 @ DeployableInvPack] = 0;
	$TeamItemCount[1 @ TurretPack] = 0;
	$TeamItemCount[1 @ CameraPack] = 0;
	$TeamItemCount[1 @ TurretMinePack] = 0;
	$TeamItemCount[1 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[1 @ PulseSensorPack] = 0;
	$TeamItemCount[1 @ MotionSensorPack] = 0;
	$TeamItemCount[1 @ ScoutVehicle] = 0;
	$TeamItemCount[1 @ LAPCVehicle] = 0;
	$TeamItemCount[1 @ HAPCVehicle] = 0;
	$TeamItemCount[1 @ Beacon] = 0;
	$TeamItemCount[1 @ mineammo] = 0;

	$TeamItemCount[2 @ DeployableAmmoPack] = 0;
	$TeamItemCount[2 @ DeployableInvPack] = 0;
	$TeamItemCount[2 @ TurretPack] = 0;
	$TeamItemCount[2 @ CameraPack] = 0;
	$TeamItemCount[2 @ TurretMinePack] = 0;
	$TeamItemCount[2 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[2 @ PulseSensorPack] = 0;
	$TeamItemCount[2 @ MotionSensorPack] = 0;
	$TeamItemCount[2 @ ScoutVehicle] = 0;
	$TeamItemCount[2 @ LAPCVehicle] = 0;
	$TeamItemCount[2 @ HAPCVehicle] = 0;
	$TeamItemCount[2 @ Beacon] = 0;
	$TeamItemCount[2 @ mineammo] = 0;

	$TeamItemCount[3 @ DeployableAmmoPack] = 0;
	$TeamItemCount[3 @ DeployableInvPack] = 0;
	$TeamItemCount[3 @ TurretPack] = 0;
	$TeamItemCount[0 @ TurretMinePack] = 0;
	$TeamItemCount[3 @ CameraPack] = 0;
	$TeamItemCount[3 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[3 @ PulseSensorPack] = 0;
	$TeamItemCount[3 @ MotionSensorPack] = 0;
	$TeamItemCount[3 @ ScoutVehicle] = 0;
	$TeamItemCount[3 @ LAPCVehicle] = 0;
	$TeamItemCount[3 @ HAPCVehicle] = 0;
	$TeamItemCount[3 @ Beacon] = 0;
	$TeamItemCount[3 @ mineammo] = 0;

	$TeamItemCount[4 @ DeployableAmmoPack] = 0;
	$TeamItemCount[4 @ DeployableInvPack] = 0;
	$TeamItemCount[4 @ TurretPack] = 0;
	$TeamItemCount[4 @ CameraPack] = 0;
	$TeamItemCount[4 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[4 @ PulseSensorPack] = 0;
	$TeamItemCount[4 @ MotionSensorPack] = 0;
	$TeamItemCount[4 @ ScoutVehicle] = 0;
	$TeamItemCount[4 @ LAPCVehicle] = 0;
	$TeamItemCount[4 @ HAPCVehicle] = 0;
	$TeamItemCount[4 @ Beacon] = 0;
	$TeamItemCount[4 @ mineammo] = 0;

	$TeamItemCount[5 @ DeployableAmmoPack] = 0;
	$TeamItemCount[5 @ DeployableInvPack] = 0;
	$TeamItemCount[5 @ TurretPack] = 0;
	$TeamItemCount[5 @ CameraPack] = 0;
	$TeamItemCount[5 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[5 @ PulseSensorPack] = 0;
	$TeamItemCount[5 @ MotionSensorPack] = 0;
	$TeamItemCount[5 @ ScoutVehicle] = 0;
	$TeamItemCount[5 @ LAPCVehicle] = 0;
	$TeamItemCount[5 @ HAPCVehicle] = 0;
	$TeamItemCount[5 @ Beacon] = 0;
	$TeamItemCount[5 @ mineammo] = 0;

	$TeamItemCount[6 @ DeployableAmmoPack] = 0;
	$TeamItemCount[6 @ DeployableInvPack] = 0;
	$TeamItemCount[6 @ TurretPack] = 0;
	$TeamItemCount[6 @ CameraPack] = 0;
	$TeamItemCount[6 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[6 @ PulseSensorPack] = 0;
	$TeamItemCount[6 @ MotionSensorPack] = 0;
	$TeamItemCount[6 @ ScoutVehicle] = 0;
	$TeamItemCount[6 @ LAPCVehicle] = 0;
	$TeamItemCount[6 @ HAPCVehicle] = 0;
	$TeamItemCount[6 @ Beacon] = 0;
	$TeamItemCount[6 @ mineammo] = 0;

	$TeamItemCount[7 @ DeployableAmmoPack] = 0;
	$TeamItemCount[7 @ DeployableInvPack] = 0;
	$TeamItemCount[7 @ TurretPack] = 0;
	$TeamItemCount[7 @ CameraPack] = 0;
	$TeamItemCount[7 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[7 @ PulseSensorPack] = 0;
	$TeamItemCount[7 @ MotionSensorPack] = 0;
	$TeamItemCount[7 @ ScoutVehicle] = 0;
	$TeamItemCount[7 @ LAPCVehicle] = 0;
	$TeamItemCount[7 @ HAPCVehicle] = 0;
	$TeamItemCount[7 @ Beacon] = 0;
	$TeamItemCount[7 @ mineammo] = 0;

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}
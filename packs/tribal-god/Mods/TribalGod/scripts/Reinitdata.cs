//------------------------------------|
// Author: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|

function Mission::reinitData()
{
	for(%x = 0; %x < 7; %x++)
	{
		$TeamItemCount[%x @ DeployableAmmoPack] = 0;
		$TeamItemCount[%x @ DeployableInvPack] = 0;
		$TeamItemCount[%x @ TurretPack] = 0;
		$TeamItemCount[%x @ CameraPack] = 0;
		$TeamItemCount[%x @ DeployableSensorJammerPack] = 0;
		$TeamItemCount[%x @ PulseSensorPack] = 0;
		$TeamItemCount[%x @ MotionSensorPack] = 0;
		$TeamItemCount[%x @ ScoutVehicle] = 0;
		$TeamItemCount[%x @ LAPCVehicle] = 0;
		$TeamItemCount[%x @ HAPCVehicle] = 0;
		$TeamItemCount[%x @ Beacon] = 0;
		$TeamItemCount[%x @ mineammo] = 0;
		$TeamItemCount[%x @ LaserTurretPack] = 0;
		$TeamItemCount[%x @ LaserTurretBPack] = 0;
		$TeamItemCount[%x @ TaserTrtBPack] = 0;
		$TeamItemCount[%x @ TaserTrtCPack] = 0;
		$TeamItemCount[%x @ MiniFlakTurretPack] = 0;
		$TeamItemCount[%x @ MiniSAMTurretPack] = 0;
		$TeamItemCount[%x @ MiniELFTurretPack] = 0;
		$TeamItemCount[%x @ MiniSmokeTurretPack] = 0;
		$TeamItemCount[%x @ RailTurret] = 0;
		$TeamItemCount[%x @ ChaingunTurretPack] = 0;
		$TeamItemCount[%x @ SeekerPack] = 0;
		$TeamItemCount[%x @ ArbitorBoxPack] = 0;
		$TeamItemCount[%x @ SuicidePack] = 0;
		$TeamItemCount[%x @ HolePack] = 0;
		$TeamItemCount[%x @ lgaForceFieldPack] = 0;
		$TeamItemCount[%x @ lgbForceFieldPack] = 0;
		$TeamItemCount[%x @ medaForceFieldPack] = 0;
		$TeamItemCount[%x @ medbForceFieldPack] = 0;
		$TeamItemCount[%x @ medcForceFieldPack] = 0;
		$TeamItemCount[%x @ ForceFieldFloorPack] = 0;
		$TeamItemCount[%x @ ShockFloorPack] = 0;
		$TeamItemCount[%x @ DeployableTeleport] = 0;
		$TeamItemCount[%x @ RadiusMineAmmo] = 0;
		$TeamItemCount[%x @ FlashGrenade] = 0;
		$TeamItemCount[%x @ LiLBoostammo] = 0;
		$TeamItemCount[%x @ cactuspack] = 0;
		$TeamItemCount[%x @ ForceFieldDoorPack] = 0;
		$TeamItemCount[%x @ JailPackage] = 0;
		$TeamItemCount[%x @ hugewall] = 0;
		$TeamItemCount[%x @ Deployablebase] = 0;
		$TeamItemCount[%x @ airbase] = 0;
		$TeamItemCount[%x @ BlastWall] = 0;
		$TeamItemCount[%x @ DissectionPack] = 0;
		$TeamItemCount[%x @ FlameTurretPack] = 0;
		$TeamItemCount[%x @ ConPack] = 0;
		$TeamItemCount[%x @ ObeliskPowerPack] = 0;
		$TeamItemCount[%x @ ObeliskPack] = 0;
		$TeamItemCount[%x @ JabberwalkiePack] = 0;
		$TeamItemCount[%x @ SuicidePack] = 0;
		$TeamItemCount[%x @ WatchdogPack] = 0;
		$TeamItemCount[%x @ DecoyCarrier] = 0;
		$TeamItemCount[%x @ Deployablebase] = 0;
		$TeamItemCount[%x @ JailTurretPack] = 0;
		$TeamItemCount[%x @ RepairTurretPack] = 0;
		$TeamItemCount[%x @ RTurretGenPack] = 0;
		$TeamItemCount[%x @ JailTurretPack] = 0;
	}
	
	$totalNumCameras = 0;
	$totalNumTurrets = 0;
	for(%i = -1; %i < 8 ; %i++)
	{ $TeamEnergy[%i] = $DefaultTeamEnergy; }
}
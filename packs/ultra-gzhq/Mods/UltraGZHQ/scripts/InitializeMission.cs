
// yanked out of function serverUltraGZHQ::InitializeMission()
// and placed here to save memory -Plasmatic

	$mine::count = "";
  // admin stuff -plasmatic	
	$maxMapObj = 9300;
	$maxDepObj = "";
  // Barriers
	deployBlastWall::Initialize();
	deployForceField::Initialize();
	deployForceFieldDoor::Initialize();
	deployLargeForceField::Initialize();
	deployLargeForceFieldDoor::Initialize();
	deployPlatform::Initialize();

   // Deployables
	//deployAccelerator::Initialize();
	deployAmmoStation::Initialize();
	deployBaseCloak::Initialize();
	deployCommandStation::Initialize();
	deployControlJammer::Initialize();
	deployFighter::Initialize();
	deployJailTower::Initialize();
	deployJumpPad::Initialize();
	deployInventoryStation::Initialize();
	deployTeleporter::Initialize();
	deployTransport::Initialize();

	
   // Misc
	miscMine::Initialize();
	miscBeacon::Initialize();

   // Powered Items
	deployMobileInventory::Initialize();
	deployPortableGenerator::Initialize();
	deployPortableSolar::Initialize();

   // Remote base objects
	deployAirbase::Initialize();
	deployBunkerpack::Initialize();
	deployCommandShip::Initialize();
	deployGunShip::Initialize();
	deploySupplyShip::Initialize();

   // Sensors
	deploySensorJammer::Initialize();
	deployCamera::Initialize();
	deployPulseSensor::Initialize();
	deployMotionSensor::Initialize();
	DeployAlarm::Initialize();

   // Turrets
	deployFlameTurret::Initialize();
	deployFusionTurret::Initialize();
	deployIonTurret::Initialize();
	deployIrradiationTurret::Initialize();
	deployLaserTurret::Initialize();
	deployMissileTurret::Initialize();
	deployMortarTurret::Initialize();
	deployNuclearTurret::Initialize();
	deployParticleBeamTurret::Initialize();
	deployPlasmaTurret::Initialize();
	deployShockTurret::Initialize();
	deployVortexTurret::Initialize();
	
   // Vehicles
	vehicleScout::Initialize();
	vehicleInterceptor::Initialize();
	vehicleLAPC::Initialize();
	vehicleHAPC::Initialize();
	
	
//yanked outa item.cs
	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
	{
		$TeamEnergy[%i] = $DefaultTeamEnergy;
		
		$PowerSet[%i] = false;
		$ClassBGen[%i] = "";
		$ClassAGen[%i] = "";
		$Alarm[%i] = false;
		$GenSet[%i] = "";
	}
	
//for object counters -plas
	$item::count = 0;
	$Ammo::count = 0;
	$mine::count = 0;
	$turret::count = 0;
	$StaticShape::count = 0;
	
	

$ItemFavoritesKey = "alliance";
$Welcome="<jc><f2>Alliance\n http://alazane.surf-va.com/tribes/alliance.html\n\n";
$DefaultArmor[Male] = armormDeathmatch;
$DefaultArmor[Female] = armorfDeathmatch;

 // Initial buy list
$spawnBuyList[0] = iarmorSprint;
$spawnBuyList[1] = DiscLauncher;
$spawnBuyList[2] = GrenadeLauncher;
$spawnBuyList[3] = Blaster;
$spawnBuyList[4] = Beacon;
$spawnBuyList[5] = Beacon;
$spawnBuyList[6] = Beacon;
$spawnBuyList[7] = RepairKit;
$spawnBuyList[8] = Grenade;
$spawnBuyList[9] = Grenade;
$spawnBuyList[10] = Grenade;
$spawnBuyList[11] = Grenade;
$spawnBuyList[12] = TargetingLaser;
$spawnBuyList[13] = EnergyPack;
$spawnBuyList[14] = "";

function serverAlliance::Start()
{
   echo('>> Loading armor classes');
	exec(armorSprint);
	exec(armorCommando);
	exec(armorLoader);
	exec(armorDestroyer);
	exec(armorDeathmatch);
   echo('>> Loading weapons');
	exec(weaponBlaster);
	exec(weaponChaingun);
	exec(weaponPlasmaGun);
	exec(weaponGrenade);
	exec(weaponMortar);
	exec(weaponDiscLauncher);
	exec(weaponLaser);
	exec(weaponRocketLauncher);
	exec(weaponSniperRifle);
	exec(weaponDart);
	exec(weaponMagnum);
	exec(weaponShockwave);
	exec(weaponRailgun);
	exec(weaponVulcan);
	exec(weaponFlamer);
//	exec(weaponIon);
	exec(weaponOmega);
	exec(weaponThunderbolt);
	exec(weaponTargetLaser);
	exec(weaponFixit);
        exec(weaponMassDriver);
        exec(weaponTractorDevice);
        exec(weaponDeathLaser);
//PORT-OFF:        exec(weaponImpGun);
   echo('>> Loading packs');
	exec(packAmmo);
	exec(packCloak);
	exec(packCommand);
	exec(packEnergy);
	exec(packJammer);
//	exec(packLightening);
//	exec(packOptic);
//	exec(packRegeneration);
	exec(packRepair);
	exec(packShield);
//	exec(packSMR);
//	exec(packStealthShield);
	exec(packSuicide);
	exec(packOMen); 
   echo('>> Targeting systems');
	exec(weaponTargetMark);
	exec(packPhotonTorpedo);
	exec(packTrackerMissile);
   echo('>> Loading misc');
	exec(miscBeacon);
	exec(miscGrenade);
	exec(miscMine);
	exec(miscRepairKit);
   echo('>> Loading deployable sensors');
	exec(deployMotionSensor);
	exec(deployPulseSensor);
        exec(deployCamera);
	exec(deploySensorJammer);
   echo('>> Loading deployable objects');
	exec(deploySmallInventoryStation);
	exec(deploySmallAmmoStation);
	exec(deploySmallCommandStation);          
	exec(deployForceField);
	exec(deployMannequin);
	exec(deployTree);
	exec(deployBlastWall);
	exec(deployPlatform);
	exec(deployTeleporter);
	exec(deploySpringboard);
	exec(deployAccelerator);
	exec(deployVehicles);
	exec(deploySatchelCharge);
   echo('>> Loading deployable weapons');
	exec(deployIonTurret);
	exec(deployLaserTurret);
	exec(deployMissileTurret);
	exec(deployMortarTurret);
	exec(deployShockTurret);
	exec(deployPlasmaTurret);
	exec(deployRailTurret);
	exec(deployVulcanTurret);
   echo('>> Vehicles');
	exec(Vehicle);
//PORT-OFF:        exec(vehicleFly);
	exec(vehicleScout);
	exec(vehicleInterceptor);
	exec(vehicleWraith);
	exec(vehicleLAPC);
	exec(vehicleHAPC);
   echo('>> Usage');
	exec(serverAlliance_ItemUsage);
}

function serverAlliance::InitializeMission()
{
         // Initialize vehicles
//PORT-OFF:        vehicleFly::Initialize();
	vehicleScout::Initialize();
	vehicleInterceptor::Initialize();
	vehicleWraith::Initialize();
	vehicleLAPC::Initialize();
	vehicleHAPC::Initialize();

	 // Initialize deployables
	deploySmallInventoryStation::Initialize();
	deploySmallAmmoStation::Initialize();
	deploySmallCommandStation::Initialize();
	deployForceField::Initialize();
	deployMannequin::Initialize();
	deployTree::Initialize();
	deployBlastWall::Initialize();
	deployPlatform::Initialize();
	deployTeleporter::Initialize();
	deploySpringboard::Initialize();
	deployAccelerator::Initialize();

	miscMine::Initialize();
	miscBeacon::Initialize();

	deploySensorJammer::Initialize();
	deployCamera::Initialize();
	deployPulseSensor::Initialize();
	deployMotionSensor::Initialize();

	deployVulcanTurret::Initialize();
	deployRailTurret::Initialize();
	deployPlasmaTurret::Initialize();
	deployShockTurret::Initialize();
	deployMortarTurret::Initialize();
	deployMissileTurret::Initialize();
	deployLaserTurret::Initialize();
	deployIonTurret::Initialize();	

	deploySatchelCharge::Initialize();
}
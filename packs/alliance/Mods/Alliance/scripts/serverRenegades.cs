$ItemFavoritesKey = "renegades_alliance";
$Welcome="<jc><f2>Renegades Alliance\n http://alazane.surf-va.com/tribes/alliance.html\n\n";
$DefaultArmor[Male] = dmarmor;
$DefaultArmor[Female] = dmfemale;

 // Initial buy list
$spawnBuyList[0] = iarmorScout;
$spawnBuyList[1] = DiscLauncher;
$spawnBuyList[2] = Blaster;
$spawnBuyList[3] = Beacon;
$spawnBuyList[4] = RepairKit;
$spawnBuyList[5] = Grenade;
$spawnBuyList[6] = Grenade;
$spawnBuyList[7] = Grenade;
$spawnBuyList[8] = Grenade;
$spawnBuyList[9] = Beacon;
$spawnBuyList[10] = Beacon;
$spawnBuyList[11] = Beacon;
$spawnBuyList[12] = Beacon;
$spawnBuyList[13] = TargetingLaser;
$spawnBuyList[14] = EnergyPack;
$spawnBuyList[15] = "";

function serverRenegades::Start()
{
   echo('>> Loading armor classes');
	exec(armorScout);
	exec(armorSpy);
	exec(armorSniper);
	exec(armorMercenary);
	exec(armorEngineer);
	exec(armorBurster);
	exec(armorAlien);
	exec(armorCyborg);
	exec(armorDM);
   echo('>> Loading weapons');
	exec(weaponBlaster);
	exec(weaponChaingun);
	exec(weaponPlasmaGun);
	exec(weaponGrenade);
	exec(weaponMortar);
	exec(weaponDiscLauncher);
	exec(weaponLaser);
	exec(weaponHyperBlaster);
	exec(weaponRocketLauncher);
	exec(weaponSniperRifle);
	exec(weaponDart);
	exec(weaponMagnum);
	exec(weaponShockwave);
	exec(weaponRailgun);
	exec(weaponVulcan);
	exec(weaponFlamer);
	exec(weaponIon);
	exec(weaponOmega);
	exec(weaponThunderbolt);
	exec(weaponTargetLaser);
	exec(weaponFixit);
        exec(weaponMassDriver);
        exec(weaponTractorDevice);
        exec(weaponDeathLaser);
   echo('>> Loading packs');
	exec(packAmmo);
	exec(packCloak);
	exec(packCommand);
	exec(packEnergy);
	exec(packJammer);
	exec(packLightening);
	exec(packOptic);
	exec(packRegeneration);
	exec(packRepair);
	exec(packShield);
//	exec(packSMR);
	exec(packStealthShield);
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
	exec(vehicleScout);
	exec(vehicleInterceptor);
	exec(vehicleWraith);
	exec(vehicleLAPC);
	exec(vehicleHAPC);
   echo('>> Usage');
	exec(serverRenegades_ItemUsage);
}

function serverRenegades::InitializeMission()
{
         // Initialize vehicles
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
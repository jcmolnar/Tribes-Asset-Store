$ItemFavoritesKey = "xtreme_knights";
$DefaultArmor[Male] = dmarmor;
$DefaultArmor[Female] = dmfemale;

 // Initial buy list
$spawnBuyList[0] = iarmorScout;
$spawnBuyList[1] = DiscLauncher;
$spawnBuyList[2] = Chaingun;
$spawnBuyList[3] = GrenadeLauncher;
$spawnBuyList[4] = Grenade;
$spawnBuyList[5] = Grenade;
$spawnBuyList[6] = Grenade;
$spawnBuyList[7] = Grenade;
$spawnBuyList[8] = Grenade;
$spawnBuyList[9] = Beacon;
$spawnBuyList[10] = Beacon;
$spawnBuyList[11] = Beacon;
$spawnBuyList[12] = TargetingLaser;
$spawnBuyList[13] = EnergyPack;
$spawnBuyList[14] = MineAmmo;
$spawnBuyList[15] = MineAmmo;
$spawnBuyList[16] = MineAmmo;
$spawnBuyList[17] = "Repairkit";

function serverXKmod::Start()
{
   echo('>> Loading armor classes');
	exec(armorPenis);
	exec(armorScout);
      exec(armorSprint);
	exec(armorSpy);
	exec(armorSniper);
	exec(armorMercenary);
	exec(armorEngineer);
	exec(armorBurster);
	exec(armorAlien);
      exec(armorLoader);
	exec(armorCyborg);
	exec(armorDM);
   echo('>> Loading weapons');
      exec(weaponAlienLaser);
	exec(weaponVulcan);
      exec(weaponHyperLaser);
      exec(weaponClay);
	exec(weaponDart);
	exec(weaponDiscLauncher);
      exec(weaponDiskHammer);
      exec(weaponELF);
      exec(weaponEnergyDisk);
      exec(weaponFireMortar);
	exec(weaponFlamer);
      exec(weaponBreaker);
	exec(weaponGrenade);
	exec(weaponChaingun);
	exec(weaponHyperBlaster);
      exec(weaponDeathLaser);
	exec(weaponIon);
	exec(weaponIonDisk);
	exec(weaponIonRocket);
	exec(weaponLaser);
	exec(weaponMagnum);
      exec(weaponMassCannon);
      exec(weaponMineLauncher);
	exec(weaponMortar);
	exec(weaponOmega);
	exec(weaponClusterBomb);
	exec(weaponBlaster);
      exec(weaponPistol);
	exec(weaponPlas);
	exec(weaponPlasmaGun);
      exec(weaponQRL);
	exec(weaponRailgun);
	exec(weaponRocketLauncher);
	exec(weaponShockwave);
	exec(weaponSniperRifle);
      exec(weaponSword);
	exec(weaponThunderbolt);
      exec(weaponVolter);
   echo('>> Loading Misc. Weapons');
	exec(miscweaponTargetLaser);
	exec(miscweaponFixit);
      exec(miscweaponCloakGun);
      exec(miscweaponTractorDevice);
	exec(miscweaponFlareGun);
	exec(miscweaponSoundRipper);
   echo('>> Loading packs');
	exec(packWiener);
	exec(packKamikaze);
	exec(packTree);
	exec(packAmmo);
	exec(packCloak);
	exec(packCommand);
	exec(packEnergy);
	exec(packJammer);
	exec(packLightening);
	exec(packOptic);
	exec(packRegeneration);
      exec(packHammer);
	exec(packRepair);
	exec(packShield);
   	exec(packSMR);
	exec(packStealthShield);
	exec(packSuicide);
	exec(packOMen);
      exec(packEnergizer);
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
	exec(miscBoostermine);
	exec(deployTarget);
	// exec(deployBaseAlarm); // PORT: that entry of Scripts.vol is a Microsoft Word document, not a script; it never loaded
	exec(deployMotionSensor);
	exec(deployPulseSensor);
	exec(deployCamera);
	exec(deploySensorJammer);
   echo('>> Loading deployable objects');
	exec(deploySmallInventoryStation);
	exec(deploySmallAmmoStation);
	exec(deploySmallCommandStation);          
	exec(deployForceField);
      exec(deployDoorPack);
      exec(deployLargeForceDoor);
	exec(deployMannequin);
	exec(deployTree);
	exec(deployBlastWall);
	exec(deployPlatform);
      exec(deployAirPlat);
      exec(deployAirBase); 
      exec(deployBunker);
	exec(deployTeleporter);
	exec(deploySpringboard);
	exec(deployAccelerator);
	exec(deployVehicles);
	exec(deploySatchelCharge);
   echo('>> Loading deployable weapons');
	exec(deployTripMine);
	exec(deployFlameTurret);
	exec(deployHyperGravityTurret);
	exec(deployAntiGravityTurret);
      exec(deployIonTurret);
	exec(deployLaserTurret);
	exec(deployMissileTurret);
	exec(deployMortarTurret);
	exec(deployShockTurret);
	exec(deployPlasmaTurret);
	exec(deployRailTurret);
	exec(deployVulcanTurret);
      exec(deployFlakPack);
   echo('>>  Loading Stuff'); 
      // exec(stuffWeiner); // PORT: no such file in the archive
   echo('>> Vehicles');
	exec(Vehicle);
	exec(vehicleScout);
      exec(vehicleFusionMarker);
      exec(vehicleBouncer);
      exec(vehicleRunner);
      exec(vehicleScorcher);
      exec(vehicleScrambler);
	exec(vehicleInterceptor);
	exec(vehicleWraith);
      exec(vehicleMini);
	exec(vehicleLAPC);
	exec(vehicleHAPC);
      exec(vehicleB2);
   echo('>> Usage');
	exec(serverXKmod_ItemUsage);
}

function serverXKmod::InitializeMission()
{
        // Initialize vehicles
	vehicleScout::Initialize();
	vehicleInterceptor::Initialize();
      vehicleFusionMarker::Initialize();
      vehicleBouncer::Initialize();
      vehicleRunner::Initialize();
      vehicleScorcher::Initialize();
      vehicleScrambler::Initialize();
	vehicleWraith::Initialize();
      vehicleMini::Initialize();
	vehicleLAPC::Initialize();
	vehicleHAPC::Initialize();
      vehicleB2::Initialize();

	deployAirBase::Initialize(); // PORT: these three were never reset at mission load (XKPort.cs)
	deployAirPlat::Initialize();
	deployFlakPack::Initialize();
	 // Initialize packs
	packTree::InitialIze();

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
      deployBunker::Initialize();
      deployLargeForceDoor::Initialize();
      deployDoorPack::Initialize();

	miscBoostermine::Initialize();
	miscMine::Initialize();
	miscBeacon::Initialize();

	deployTarget::Initialize();
	// deployBaseAlarm::Initialize(); // PORT: never defined (see above)
	deploySensorJammer::Initialize();
	deployCamera::Initialize();
	deployPulseSensor::Initialize();
	deployMotionSensor::Initialize();

	deployTripMine::Initialize();
	deployFlameTurret::Initialize();
	deployHyperGravityTurret::Initialize();
	deployAntiGravityTurret::Initialize();
	deployVulcanTurret::Initialize();
	deployRailTurret::Initialize();
	deployPlasmaTurret::Initialize();
	deployShockTurret::Initialize();
	deployMortarTurret::Initialize();
	deployMissileTurret::Initialize();
	deployLaserTurret::Initialize();
	deployIonTurret::Initialize();	

	deploySatchelCharge::Initialize();
	
	packTree::Initialize();
	packKamikaze::Initialize();
}
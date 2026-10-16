$ItemFavoritesKey = "TiZ";
$Welcome="<jc><f2>TiZ\n http://www.goncalves.com/mike\n\n";
$DefaultArmor[Male] = dmarmor;
$DefaultArmor[Female] = dmfemale;

 // Initial buy list
$spawnBuyList[0] = iarmorMercenary;
$spawnBuyList[1] = GrenadeLauncher;
$spawnBuyList[2] = Chaingun;
$spawnBuyList[3] = DiscLauncher;
$spawnBuyList[4] = RepairKit;
$spawnBuyList[5] = Grenade;
$spawnBuyList[6] = Grenade;
$spawnBuyList[7] = Grenade;
$spawnBuyList[8] = Grenade;
$spawnBuyList[9] = Beacon;
$spawnBuyList[10] = Beacon;
$spawnBuyList[11] = Beacon;
$spawnBuyList[12] = Beacon;
$spawnBuyList[13] = RepairPack;
$spawnBuyList[14] = Mineammo;
$spawnBuyList[15] = TargetingLaser;

function serverRenegades::Start()
{
   echo('>> Loading armor classes');
	exec(armorScout);
//PORT-OFF: 	exec(armorSpy);
	exec(armorMercenary);
	exec(armorEngineer);
	exec(armorBurster);
	exec(armorCyborg);
        exec(armorEngineer);
        exec(armorSniper);
//PORT-OFF:         exec(armorAlien);
        exec(armorDM);
//PORT-OFF:         exec(armorCommando);
//PORT-OFF:         exec(armorLoader);
        exec(armorDestroyer);
   echo('>> Loading weapons');
        exec(weaponTargetLaser);
        exec(weaponPlasmaGun);
//PORT-OFF:         exec(weaponLaserRifle);
	exec(weaponDiscCannon);
	exec(weaponAutoCannon);
	exec(weaponHyperBlaster);
        exec(weaponChaingun);
        exec(weaponMagnum);
        exec(weaponSniperRifle);
        exec(weaponLongRifle); 
        exec(weaponShotgun);
        exec(weaponFlamer);
        exec(weaponDiscLauncher);
	exec(weaponGrenade);
     	exec(weaponMortar);
      exec(weaponRocketLauncher);
	exec(weaponELF);
	exec(weaponFixit);
        
   echo('>> Loading packs');
	exec(packAmmo);
	exec(packCommand);
	exec(packEnergy);
//PORT-OFF:         exec(packJetPack);
        exec(packRegeneration);
        exec(packRepair);
        exec(packShield);
//PORT-OFF:         exec(packCloak);
        exec(packStealthShield);
	exec(packJammer);
//PORT-OFF: 	exec(packLightening);
//PORT-OFF: 	exec(packOptic);
//PORT-OFF:         exec(packSMR);
	exec(packSuicide);
        exec(packOMen);
        

   echo('>> Loading misc');
	exec(miscBeacon);
	exec(miscGrenade);
	exec(miscMine);
	exec(miscRepairKit);

   echo('>> Loading deployable sensors');
//PORT-OFF: 	exec(deployMotionSensor);
	exec(deployPulseSensor);
        exec(deployCamera);
	exec(deploySensorJammer);

   echo('>> Loading deployable objects');
	exec(deploySmallInventoryStation);
	exec(deploySmallAmmoStation);
	exec(deploySmallCommandStation); 
        exec(deployBlastWall); 
        exec(deployPlatform);  
//PORT-OFF:         exec(deployAirPlat);      
	exec(deployForceField);
//PORT-OFF: 	exec(deployBigField);
//PORT-OFF:         exec(deployMannequin);
	exec(deployTree);
	exec(deployTeleporter);
	exec(deploySpringboard);
//PORT-OFF: 	exec(deployAccelerator);
	exec(deployVehicles);
//PORT-OFF: 	exec(deploySatchelCharge);
//PORT-OFF:         exec(deployLRSensorJammerPack);
//PORT-OFF:         exec(deployLRMotionSensorPack);
//PORT-OFF:         exec(deployLRPulseSensorPack);
        exec(deployVehiclex);
         
   echo('>> Loading deployable weapons');
	exec(deployIonTurret);
	exec(deployLaserTurret);
	exec(deployMissileTurret);
	exec(deployPlasmaTurret);
         
   echo('>> Vehicles');
	exec(Vehicle);
	exec(vehicleScout);
	exec(vehicleInterceptor);
//PORT-OFF: 	exec(vehicleWraith);
//PORT-OFF:         exec(vehicleFighter);
        exec(vehicleHAPC);
//PORT-OFF:         exec(vehicleTempest);
	exec(vehicleLAPC);
//PORT-OFF:         exec(vehicleHvyFighter);
//PORT-OFF:         exec(vehicleSpeeder);
   echo('>> Usage');
	exec(serverRenegades_ItemUsage);
}

function serverRenegades::InitializeMission()
{
         // Initialize vehicles
	vehicleScout::Initialize();
	vehicleInterceptor::Initialize();
//PORT-OFF: 	vehicleWraith::Initialize();
//PORT-OFF:         vehicleDogFighter::Initialize();
        vehicleHAPC::Initialize();
//PORT-OFF:         vehicleTempest::Initialize();
	vehicleLAPC::Initialize();
//PORT-OFF: 	vehicleQuickLPC::Initialize();
//PORT-OFF:         vehicleSpeeder::Initialize();
	 // Initialize deployables
	deploySmallInventoryStation::Initialize();
	deploySmallAmmoStation::Initialize();
	deploySmallCommandStation::Initialize();
	deployForceField::Initialize(); 
//PORT-OFF: 	deployBigField::Initialize();
//PORT-OFF: 	deployMannequin::Initialize();
	deployTree::Initialize();
	deployBlastWall::Initialize();
	deployPlatform::Initialize();
	deployTeleporter::Initialize();
	deploySpringboard::Initialize();
//PORT-OFF: 	deployAccelerator::Initialize();
//PORT-OFF:         deployAirPlat::Initialize();

	miscMine::Initialize();
	miscBeacon::Initialize();

	deploySensorJammer::Initialize();
	deployCamera::Initialize();
	deployPulseSensor::Initialize();
//PORT-OFF: 	deployMotionSensor::Initialize();

	deployPlasmaTurret::Initialize();
	deployMissileTurret::Initialize();
	deployLaserTurret::Initialize();
	deployIonTurret::Initialize();	

//PORT-OFF: 	deploySatchelCharge::Initialize();
}
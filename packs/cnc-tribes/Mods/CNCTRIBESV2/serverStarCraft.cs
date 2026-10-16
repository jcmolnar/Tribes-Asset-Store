$ItemFavoritesKey = "CnC";
$Welcome="<jc><f2>C&C: Tribes 1 Alpha Build 1\n<f6>By Lennex Production Studios\n<f5>Thanks goes out to the Lennex Production Studios Dev Team, and Matthais of Starsiegecraft\n<f5>http://www.planetstarsiege.com/lennex/ for more information on this, and other MODS.";
$DefaultArmor[Male] = dmarmor;
$DefaultArmor[Female] = dmfemale;

 // Initial buy list
$spawnBuyList[0] = iarmorAlien;
$spawnBuyList[1] = Chaingun;
$spawnBuyList[2] = Blaster;
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
$spawnBuyList[15] = "";

function serverStarCraft::Start()
{
   echo('>> Loading armor classes');
	exec(armorScout);
	exec(armorSpy);
	exec(armorMercenary);
	exec(armorEngineer);
	exec(armorBurster);
	exec(armorCyborg);
        exec(armorEngineer);
        exec(armorSprint);
        exec(armorSniper);
        exec(armorAlien);
        exec(armorDM);
        exec(armorCommando);
        exec(armorDestroyer);
        exec(armorLing);
        exec(armorLoader);
//PORT-OFF: 	exec(armorAssassin);
   echo('>> Loading weapons');
        exec(weaponTargetLaser);
	exec(weaponBlaster);
        exec(weaponPlasmaGun);
        exec(weaponShockwave);
        exec(weaponLasPist);
//PORT-OFF:         exec(weaponLaserRifle);
	exec(weaponHyperBlaster);
        exec(weaponDeathLaser);
        exec(weaponLasCannon);
        exec(weaponChaingun);
        exec(weaponAutogun);
        exec(weaponMagnum);
        exec(weaponVulcan); 
        exec(weaponRailgun);
        exec(weaponPartGun);
        exec(weaponSniperRifle);
        exec(weaponDart);
        exec(weaponLongRifle); 
        exec(weaponShotgun);
//PORT-OFF: 	exec(weaponFlakC);
        exec(weaponFlamer);
        exec(weaponHFlamer);
        exec(weaponChem);
        exec(weaponOmega);
        exec(weaponIon);
        //exec(weaponMelta);
//PORT-OFF:         exec(weaponDiscLauncher);
        exec(weaponShurCannon);
	exec(weaponGrenade);
	exec(weaponMortar);
	exec(weaponDemoGun);
	exec(weaponRocketLauncher);
        exec(weaponCyc);
//PORT-OFF: 	exec(weaponBlueTerror);
        exec(weaponEMP);
	exec(weaponMassDriver);
//PORT-OFF:         exec(weaponTMortar);
	exec(weaponWarp);
	exec(weaponELF);
	exec(weaponFixit);
        exec(weaponTractorDevice);
        exec(weaponFlak);
//	exec(weaponAniZerg);
//	exec(weaponAntiZerg);
        exec(weaponsuit);
        
   echo('>> Loading packs');
	exec(packAmmo);
	exec(packCommand);
	exec(packEnergy);
//        exec(packJetPack);
        exec(packRegeneration);
        exec(packRepair);
        exec(packShield);
        exec(packCloak);
        exec(packStealthShield);
	exec(packJammer);
	exec(packLightening);
	exec(packOptic);
        exec(packSMR);
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
        exec(deploydrone);
        exec(ore);
        exec(BotCheck);
        exec(BotFuncs);
        exec(BotGear);
        exec(BotHud);
        exec(BotSpawn);
        exec(BotTargets);
        exec(BotThink);
        exec(BotTree);
        exec(BotTypes);
        exec(Bot);




   echo('>> Loading deployable sensors');
	exec(deployMotionSensor);
	exec(deployPulseSensor);
        exec(deployCamera);
	exec(deploySensorJammer);

   echo('>> Loading deployable objects');
	exec(deploySmallInventoryStation);
	exec(deploySmallAmmoStation);
	exec(deploySmallCommandStation); 
        exec(deployBlastWall); 
        exec(deployPlatform);  
        exec(deployAirPlat);      
	exec(deployForceField);
	exec(deployBigField);
        exec(deployMannequin);
	//exec(deployTree);
	exec(deployTeleporter);
	exec(deploySpringboard);
	exec(deployAccelerator);
	//exec(deployVehicles);
	exec(deploySatchelCharge);
        exec(deployLRSensorJammerPack);
        exec(deployLRMotionSensorPack);
        exec(deployLRPulseSensorPack);
//PORT-OFF:         exec(pack_arkfirepack);
        //exec(deployVehiclex);
         
   echo('>> Loading deployable weapons');
	exec(deployIonTurret);
	exec(deployLaserTurret);
	exec(deployMissileTurret);
	exec(deployBarrageTurret);
	//exec(deployMortarTurret);
	exec(deployShockTurret);
	exec(deployPlasmaTurret);
	exec(deployRailTurret);
	exec(deployVulcanTurret);
        exec(deployHFlameTurret);
        exec(deployElecTurret);
        exec(deployFlameTurret);
        exec(deployAAGun);
        //exec(deployRepairTurret);
         
   echo('>> Loading Psionics');
       exec(weaponPsiShock);
       exec(weaponHeal);
       exec(weaponSuck);
       exec(weaponPsiStream);
       exec(weaponZap);
       exec(weaponFireball);
       exec(packChameleon);
       exec(weaponPull);
       exec(weaponPsiLas);
       exec(weaponPsiSword);
       exec(weaponDCannon);
   echo('>> Vehicles');
	exec(Vehicle);
	exec(vehicleScout);
	exec(vehicleInterceptor);
	exec(vehicleWraith);
        exec(vehicleFighter);
        exec(vehicleHAPC);
        exec(vehicleTempest);
	exec(vehicleLAPC);
        exec(vehicleHvyFighter);
        exec(vehicleSpeeder);
//PORT-OFF:         exec(vehicleMuta);
	exec(vehicleGuard);
	exec(vehicleDev);
   echo('>> Usage');
	exec(serverStarCraft_ItemUsage);
}

function serverStarCraft::InitializeMission()
{
         // Initialize vehicles
	vehicleScout::Initialize();
	vehicleInterceptor::Initialize();
	vehicleWraith::Initialize();
        vehicleDogFighter::Initialize();
        vehicleHAPC::Initialize();
        vehicleTempest::Initialize();
	vehicleLAPC::Initialize();
	vehicleQuickLPC::Initialize();
        vehicleSpeeder::Initialize();
//PORT-OFF:         vehicleMuta::Initialize();
	vehicleGuard::Initialize();
	vehicleDev::Initialize();
	 // Initialize deployables
	deploySmallInventoryStation::Initialize();
	deploySmallAmmoStation::Initialize();
	deploySmallCommandStation::Initialize();
	deployForceField::Initialize(); 
	deployBigField::Initialize();
	deployMannequin::Initialize();
	//deployTree::Initialize();
	deployBlastWall::Initialize();
	deployPlatform::Initialize();
	deployTeleporter::Initialize();
	deploySpringboard::Initialize();
	deployAccelerator::Initialize();
        deployAirPlat::Initialize();
        deployLRSensorJammerPack::Initialize();
        deployLRMotionSensorPack::Initialize();
        deployLRPulseSensorPack::Initialize();

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
//PORT-OFF: 	deployMortarTurret::Initialize();
	deployMissileTurret::Initialize();
	deployBarrageTurret::Initialize();
	deployLaserTurret::Initialize();
	deployIonTurret::Initialize();	
        deployHFlameTurret::Initialize();
        deployElecTurret::Initialize();
        deployFlameTurret::Initialize();
        deployAAgun::Initialize();
//PORT-OFF:         deployRepairTurret::Initialize();

	deploySatchelCharge::Initialize();
}
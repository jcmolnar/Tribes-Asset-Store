
//$Welcome="<jc><f2>TotalAnnihilation - Created by {PaGaN}Scavenger\n\";

$DefaultArmor[Male] = armormWarrior;
$DefaultArmor[Female] = armorfWarrior;

 // Initial buy list
$spawnBuyList[0] = iarmorBuilder;
$spawnBuyList[1] = DiscLauncher;
$spawnBuyList[2] = PlasmaGun;
$spawnBuyList[3] = Shotgun;
$spawnBuyList[4] = Beacon;
$spawnBuyList[5] = RepairKit;
$spawnBuyList[6] = Grenade;
$spawnBuyList[7] = Grenade;
$spawnBuyList[8] = Grenade;
$spawnBuyList[9] = Grenade;
$spawnBuyList[10] = Beacon;
$spawnBuyList[11] = Beacon;
$spawnBuyList[12] = Beacon;
$spawnBuyList[13] = Beacon;
$spawnBuyList[14] = MineAmmo;
$spawnBuyList[15] = TargetingLaser;
$spawnBuyList[16] = packCommand;
$spawnBuyList[17] = "";

function serverAnnihilation::Armors()
{
   echo('>> Loading armor classes');
	exec(armorAngel);
	exec(armorSpy);
	exec(armorNecro);
	exec(armorWarrior);
	exec(armorBuilder);
	exec(armorTroll);
	exec(armorTank);
	exec(armorTitan);
	exec(armorDM);
}

function serverAnnihilation::Items()
{   
   echo('>> Loading weapons');
	exec(weaponDiscLauncher);
	exec(weaponGatlingBlaster);
	exec(weaponGrenadeLauncher);
	exec(weaponPlasmaGun);
	exec(weaponShotGun);
	exec(weaponFlamer);
	exec(weaponFlameThrower);
	exec(weaponHDiscLauncher);
	exec(weaponJailgun);
	exec(weaponRocketLauncher);
	exec(weaponMineLauncher);
	exec(weaponMortar);
	exec(weaponRubberMortar);
	exec(weaponPulseCannon);
	exec(weaponShockwave);
	exec(weaponStinger);
	exec(weaponVulcan);
	exec(weaponAngelFire);
	exec(weaponHeavensfury);
	exec(weaponSniperRifle);
	exec(weaponFixit);
	exec(weaponRailgun);
	exec(weaponPhaseDisrupter);
	exec(weaponBeaconGun);
	exec(weaponTankBlastCannon);
	exec(weaponTankShredder);
	exec(weaponTankRocketLauncher);
	exec(weaponTankRPG);
	exec(weaponAutoCannon);
	exec(weaponBabyNuke);
	exec(weaponHellfire);
	exec(weaponMassDriver);
	exec(weaponOSLauncher);
	exec(weaponParticleBeam);
	exec(weaponTargetLaser);

   echo('>> Loading spells');
	exec(spellDeathRay);
	exec(spellDisarmer);
	exec(spellFlameStrike);
	exec(spellFlameThrower);
	exec(spellShockingGrasp);
	exec(spellStasis);
	
   echo('>> Loading packs');
	exec(packAmmo);
	exec(packChameleon);
	exec(packCloak);
	exec(packCommand);
	exec(packEnergy);
	exec(packJammer);
	exec(packPhaseShifter);
	exec(packRepair);
	exec(packShield);
	exec(packStealthShield);
	exec(packSuicide);
	exec(packTNT);
	exec(packRegeneration);	
	exec(packTarget);
	
   echo('>> Loading misc');
	exec(miscBeacon);
	exec(miscGrenade);
	exec(miscMine);
	exec(miscRepairKit);
	exec(miscRepairPatch);
	
   echo('>> Loading deploy functions');
	exec(deployFunctions);
	
   echo('>> Loading deployable sensors');
	exec(deployPulseSensor);
	exec(deployMotionSensor);
        exec(deployCamera);
	exec(deploySensorJammer);
	
   echo('>> Loading deployable objects');
	exec(deploySmallAmmoStation);
	exec(deploySmallCommandStation);
	exec(deploySmallInventoryStation);
	exec(deployAccelerator);
	exec(deployBaseCloak);
	exec(deployBlastWall);
	exec(deployControlJammer);
	exec(deployForceField);
	exec(deployForceFieldDoors);
	exec(deployPlatform);
	exec(deploySpringboard);
	exec(deployTeleporter);
	exec(deployVehicles);
	exec(deployJailPack);
	exec(deployMannequin);
	exec(deployTree);
	
   echo('>> Loading remote base objects');
	exec(deployBorgCube);
	exec(dropShipCommandShip);
	exec(dropShipGunShip);
	exec(deployAirbase);
	exec(deployBunkerPack);
	
   echo('>> Loading generation objects');
	exec(powerFunctions);
	exec(deployMobileInv);
	exec(deployGenerator);
	exec(deploySolarPanel);
	exec(deploySatSystem);
	exec(deployPowerNode);
	exec(deployShieldGen);	
	exec(deployShieldNode);
	
   echo('>> Droids');
	exec(droidSurveyDroid);
	exec(droidTeleDroid);
	exec(droidProbeDroid);
	exec(droidSuicideDroid);
}
	
function serverAnnihilation::Turrets()
{
   echo('>> Loading deployable weapons');
	exec(turretFlameTurret);
	exec(turretFusionTurret);
	exec(turretIonTurret);
	exec(turretIrradiationTurret);
	exec(turretLaserTurret);
	exec(turretMMTurret);
	exec(turretMissileTurret);
	exec(turretMortarTurret);
	exec(turretNuclearTurret);
	exec(turretParticleBeamTurret);
	exec(turretPlasmaTurret);
	exec(turretRailTurret);
	exec(turretShockTurret);
	exec(turretVortexTurret);
}

function serverAnnihilation::Vehicles()
{
   echo('>> Vehicles');
	exec(Vehicle);
	exec(vehicleFighter);
	exec(vehicleInterceptor);
	exec(vehicleWraith);
	exec(vehicleLAPC);
	exec(vehicleHAPC);
}	

function serverAnnihilation::Others()
{
   echo('>> Others');
}

function serverAnnihilation::InitializeMission()
{	// Initialize vehicles
	vehicleFighter::Initialize();
	vehicleInterceptor::Initialize();
	vehicleWraith::Initialize();
	vehicleLAPC::Initialize();
	vehicleHAPC::Initialize();

	// Initialize deployables
	deployAccelerator::Initialize();
	deployAirbase::Initialize();
	deployBaseCloak::Initialize();
	deployBlastWall::Initialize();
	deployBorgCube::Initialize();
	deployBunkerpack::Initialize();
	deployCommandShip::Initialize();
	deployControlJammer::Initialize();
	deployGunShip::Initialize();
	deployForceField::Initialize();
	deployForceFieldDoor::Initialize();
	deployJailpack::Initialize();
	deployMannequin::Initialize();
	deployPlatform::Initialize();
	deployMobileInv::Initialize();
	deployMobileGen::Initialize();
	deployPowerNode::Initialize();
	deployPortableSolar::Initialize();
	deploySatSystem::Initialize();
	deployShieldGen::Initialize();
	deployShieldNode::Initialize();
	deploySmallInventoryStation::Initialize();
	deploySmallAmmoStation::Initialize();
	deploySmallCommandStation::Initialize();
	deploySpringboard::Initialize();
	deployTeleporter::Initialize();
	deployTree::Initialize();

	miscMine::Initialize();
	miscBeacon::Initialize();

	deploySensorJammer::Initialize();
	deployCamera::Initialize();
	deployPulseSensor::Initialize();
	deployMotionSensor::Initialize();

	deployFlameTurret::Initialize();
	deployFusionTurret::Initialize();
	deployIonTurret::Initialize();	
	deployIrradiationTurret::Initialize();
	deployLaserTurret::Initialize();
	deployMissileTurret::Initialize();
	deployMMTurret::Initialize();
	deployMortarTurret::Initialize();
	deployNuclearTurret::Initialize();
	deployParticleBeamTurret::Initialize();
	deployPlasmaTurret::Initialize();
	deployRailTurret::Initialize();
	deployShockTurret::Initialize();
	deployVortexTurret::Initialize();
}

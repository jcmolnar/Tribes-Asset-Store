$MODInfo = "<f2>\nSpecialist mod v2000c\n<f1>By |PTi| and |V|\n\nhttp://prototypei.tripod.com/\n";

function serverSpecialist::Start() {
	// this function loads all of our item data

	echo("Loading Specialist preferences...");
	exec("specialist.cs");

	echo("Removing unneeded equipment...");
	exec(removeBase);

	echo("Setting up Specialist data structures...");
	exec(utils);
	exec(effectPoisonGasCloud);
	exec(effectEMP);
	exec(effectBurn);
	exec(effectRadiation);
	exec(effectAcid);
	exec(effectStealth);
	exec(effectDetonationFrequency);
	exec(effectPersonalShield);
	exec(effectTargeted);
	
	echo("Loading Specialist armors...");
	exec(armorArtillery);
	exec(armorAssault);
	exec(armorCommander);
	exec(armorDemolitions);
	exec(armorEngineer);
	exec(armorEspionage);
	exec(armorFallout);
	exec(armorInfantry);
	exec(armorRecon);

	echo("Loading Specialist weapons...");
	exec(weaponAcidCanister);
	exec(weaponAcidSprayer);
	exec(weaponArtilleryShell);
	exec(weaponBlaster);
	exec(weaponChaingun);
	exec(weaponDiscLauncher);
	exec(weaponEMPCannon);
	exec(weaponEnergyRifle);
	exec(weaponExplosiveGat);
	exec(weaponFieldMortar);
	exec(weaponFieldPiece);
	exec(weaponFlakCannon);
	exec(weaponFlamethrower);
	exec(weaponGasCanister);
	exec(weaponGrenadeLauncher);
	exec(weaponLaserPistol);
	exec(weaponLaserRifle);
	exec(weaponMortar);
	exec(weaponPlasmaGun);
	exec(weaponRadiationCanister);
	exec(weaponRocketLauncher);
	exec(weaponShotgun);
	exec(weaponSniperRifle);
	exec(nextWeapon);

	echo("Loading Specialist grenades...");
	exec(grenadeNull);
	exec(grenadeAcid);
	exec(grenadeEMP);
	exec(grenadeFlash);
	exec(grenadeIncendiary);
	exec(grenadePoisonGas);
	exec(grenadeRadiation);
	exec(grenadeShrapnel);
	exec(grenadeSmokeLine);
	exec(grenadeRemoteBomb);

	echo("Loading Specialist mines...");
	exec(mineNull);
	exec(mineDecoy);
	exec(mineEMP);
	exec(mineFlag);
	exec(mineFlash);
	exec(mineIncendiary);
	exec(mineNormal);
	
	echo("Loading Specialist packs...");
	exec(packAmmo);
	exec(packDemolitions);
	exec(packEnergy);
	exec(packFallout);
	exec(packFlagCarrier);
	exec(packFlame);
	exec(packInfiltration);
	exec(packMedic);
	exec(packMine);
	exec(packRepair);
	exec(packRocket);
	exec(packSeed);
	exec(packSensorJammer);
	exec(packShield);
	exec(packStealth);

	echo("Loading Specialist beacons...");
	exec(beaconAlarm);
	exec(beaconCamera);
	exec(beaconCircuitExplosive);
	exec(beaconCommSilencer);
	exec(beaconEavesdropper);
	exec(beaconForceShield);
	exec(beaconLoudmouth);
	exec(beaconMotionSensor);
	exec(beaconPersonalShield);
	exec(beaconPulseSensor);
	exec(beaconTimedExplosive);
	exec(beaconRepairBot);
	exec(beaconSensorJammer);
	exec(beaconSpyCamera);

	echo("Loading Specialist tools...");
	exec(toolEngRepairGun);
	exec(toolRemoteDetonator);
	exec(toolTargetingLaser);

	echo("Loading Specialist turrets...");
	exec(turretChain);
	exec(turretELF);
	exec(turretEMP);
	exec(turretFlak);
	exec(turretFlame);
	exec(turretIndoor);
	exec(turretIon);
	exec(turretLaser);
	exec(turretMortar);
	exec(turretPlasma);
	exec(turretRocket);
	exec(turretSmoke);
	exec(turretTargeting);

	echo("Loading Specialist deployables...");
	exec(deployAccelerator);
	exec(deployAmmoStation);
	exec(deployBackupGenerator);
	exec(deployBarricade);
	exec(deployBlastCover);
	exec(deployBlastPlatform);
	exec(deployBlastWall);
	exec(deployFlagStand);
	exec(deployHoverPad);
	exec(deployInvStation);
	exec(deployLargeForceField);
	exec(deployNuclearWaste);
	exec(deployShieldGenerator);
	exec(deploySmallForceField);
	exec(deployTeleporter);

	echo("Loading Specialist vehicles...");
	exec(vehicleAPC);
	exec(vehicleBomber);
	exec(vehicleCargo);
	exec(vehicleFighter);
	exec(vehicleHelicopter);
	exec(vehicleOutrider);
	exec(vehicleSupply);
	exec(vehicleTank);




	echo("Initializing data structures...");
	PoisonGasCloud::initializeData();
	DetonationFrequency::initializeData(0);
	dCommSilencer::initializeData();
	dEavesdropper::initializeData();
} 
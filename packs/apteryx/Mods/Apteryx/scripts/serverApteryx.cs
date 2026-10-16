// moved out of functions to this file to conserve memory -Plasmatic	

	exec(admin);
	exec(Marker);
	exec(Trigger);
	exec(NSound);
	exec(BaseExpData);
	exec(BaseDebrisData);
	exec(BasepProjData);	
	exec(iItem);
	$ItemFavoritesKey = "Apteryx";
	
//armors	
	exec(ArmordData);
	exec(armorScorpion);
	exec(armorBerserker);
	exec(armorLynx);
//	exec(armorghost);
	exec(armorFirth);
	exec(armorDrone);
	exec(armorNRGArt);
//	exec(armorTank);
	exec(armorDestroyer);
	exec(armorDM);
   echo('<< Armors Complete');
	
	exec(Mission);

   echo('>> Loading Weapons');
	exec(weaponHealingLaser);
	exec(weaponSilver);
 	exec(weaponTerra);
	exec(weaponLasher);
	exec(weaponLightLaser);
	exec(weaponpPulseCannon);
	exec(weaponLightRailgun);
 	exec(weaponAcidCloud);
 	exec(weaponESG);	
	exec(weaponAirMine);
	exec(weaponStarFlare);
 	exec(weaponPlFlameThrower);
	exec(weaponNanoVirus);
	exec(weaponKineticMaul);
	exec(weaponMagnetLance);
	exec(weaponEnergyRift);
	exec(weaponShortShield);
	exec(weaponShatterStorm);
	exec(weaponHydra);
	exec(weaponEMP);
	exec(weaponParticleGun);
 	exec(weaponPlasmaCannon);
 	exec(weaponReactorCapacitor);  
	exec(weaponAntiMatter);	
	exec(weaponRailgun2);
	exec(weaponMFAC);
	exec(weaponDrone);
	exec(weaponEnergyArtillery);
	exec(weaponShieldProjector);
	exec(weaponClusterMissile);
	exec(weaponSpotterLaser);
	exec(weaponWrathOfCrow);
	exec(weaponTargetLaser);
// 	exec(weaponFlamer);
//	exec(weaponFixit);
//	exec(weaponParticleBeam);
   echo('<< Weapons Complete');

   echo('>> Loading Packs');
	exec(packaAmmo);
	exec(packEnergy);
//	exec(packCommand);
	exec(packDistortion);
	exec(packRepair);
	exec(packjJammer);
	exec(packsShield);
	exec(packEMP);
	exec(packdroneselect);
	exec(packReversion);
//	exec(packBuilder);		//plasmatic
//	exec(packStealthShield);
//	exec(packRegeneration);
   echo('<< Packs Complete');

   echo('>> Loading Misc');
	exec(miscBeacon);
	exec(miscGrenade);
	exec(miscmMine);
   echo('<< Misc Complete');

   echo('>> Loading Deploy Functions');
	exec(deployFunctions);
   echo('<< Deploy Functions Complete');

   echo('>> Loading Deployable Sensors');
	exec(deployCamera);
	exec(deployMotionSensor);
//	exec(deploySensorCat);
        exec(deployPulseSensor);
	exec(deploySensorJammer);
   echo('<< Deployable Sensors Complete');

   echo('>> Loading Deployable Objects');
	exec(deployaAmmoStation);
//	exec(deployBaseCloak);
	exec(deployCommandStation);
//	exec(deployControlJammer);
//	exec(deployFighter);
	exec(deployInventoryStation);
//	exec(deployJailTower);
//	exec(deployTeleporter);
	exec(deployTransport);
   echo('<< Deployable Objects Complete');

   echo('>> Loading Deployable Barriers');
	exec(deploybBlastWall);
	exec(deployPhysicalShield);
//	exec(deployForceFieldDoor);
//	exec(deployLargeForceField);
	exec(deploylLargeForceFieldDoor);
	exec(deployPlatform);
	exec(deployFireWall);
   echo('<< Deployable Barriers Complete');

   echo('>> Loading Power Systems');
	exec(powerFunctions);
	exec(deploymMobileInventory);
	exec(deployPortableGenerator);
	exec(deployPortableSolar);
   echo('<< Power Systems Complete');

   echo('>> Loading Remote Base Objects');
//	exec(deployAirbase);
	exec(deployBunkerPack);
//	exec(dropShipFunctions);
//	exec(dropShipCommandShip);
//	exec(dropShipGunShip);
//	exec(dropShipSupplyShip);
   echo('<< Remote Base Objects Complete');

   echo('>> Loading Drones');
	exec(droneLaser);
	exec(droneChaingun);
	// exec(droneEMP); // PORT: no such file in the archive
	exec(droneGrenade);
	exec(droneAntiTurret);
	exec(droneGuardian);
	exec(droneAir);
	exec(droneHunter);
//	exec(droidProbeDroid);
//	exec(droidSuicideDroid);
//	exec(droidSurveyDroid);
   echo('<< Drones Complete');
	
	exec(Player);
		
	exec(Vehicle);
   echo('>> Loading Vehicles');
	exec(vehicleWyvern);
	exec(vehicleRubicant);
	exec(vehicleBomber);
	exec(vehicleDropship);
   echo('<< Vehicles Complete');
	
	exec(turretApteryx);
   echo('>> Loading Turrets');
	exec(turretTargetingTurret);
	exec(turretVortexTurret);
	exec(turretiIonTurret);
	exec(turretNewFlameTurret);
	exec(turretEMPTurret);
	exec(turretBigLaserTurret);
	exec(turretMFACTurret);
	exec(turretNewMissileTurret);
	exec(turretAntiMatterTurret);
	exec(turretIonGatlingTurret);
	exec(turretEnergyArtilleryTurret);
   echo('<< Turrets Complete');

	exec(sStaticShape);
	
	exec(Station);
   echo('>> Loading Stations');
	exec(StationQuick);
	exec(stationAmmoStation);
	exec(stationCommandStation);
	exec(stationDeployableStation);
	exec(stationInventoryStation);
	exec(stationMobileStation);
	exec(stationVehicleStation);
   echo('<< Stations Complete');
	
	exec(Moveable);
	exec(Sensor);

	exec(AI);
	exec(InteriorLight);

	exec(serveriItemUsage);
	exec(weaponcuttinglaser);
$modlist = "Apteryx";
exec(WierdFix);
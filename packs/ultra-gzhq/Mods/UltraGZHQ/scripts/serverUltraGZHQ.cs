// moved out of functions to this file to conserve memory 
	
echo('>> Loading Main Server Info');
	exec(admin);
	exec(Marker);
	exec(Trigger);
	exec(NSound);
	exec(BaseExpData);
	exec(BaseDebrisData);
	exec(BaseProjData);	
	exec(Item);
echo('>> Main Server Info Loaded');

	
echo('>> Loading Suits');
	exec(ArmorData);
	exec(armorLight);
	exec(armorAssassin); 
	exec(armorAssault);
	exec(armorDeffence);
	exec(armorBorg);
	exec(armorHeavy);
	exec(armorDestroyer);
	exec(armorDM);
echo('<< Suits Loaded');
	
	exec(Mission);

   echo('>> Loading Weapons');
	exec(weaponBlaster);
	exec(weaponVulcan);
	exec(weaponIX2000);
	exec(weaponIX2002);
	exec(weaponSniperMki);
	exec(weaponSniperMkii);
	exec(weaponFEBRifle);
	exec(weaponRailgun);
	exec(weaponShotGun);
	exec(weaponLazerRifle);
 	exec(weaponDiscLauncher); 
	exec(weaponHDiscLauncher);
	exec(weaponPlasmaGun);
	exec(weaponFlameThrower);
	exec(weaponAcidSpray);	
 	exec(weaponShockwave);
 	exec(weaponGrenadeLauncher);
	exec(weaponMortar);
	exec(weaponRocketLauncher);
	exec(weaponStinger);
	exec(weaponShockLance);
	exec(weaponBeamOfPain);
	exec(weaponFixit);
	exec(weaponJailGun);	
	exec(weaponPhaseDisrupter);
	exec(weaponHeavyBlastCannon);
	exec(weaponHeavyShredder);
	exec(weaponHeavyRocketLauncher);
	exec(weaponHeavyRPG);
	exec(weaponHeavyMortar);	    
	exec(weaponBabyNuke);
	exec(weaponOSLauncher);
	exec(weaponParticleBeam);
	exec(weaponTargetLaser);
   echo('<< Weapons Loaded');

   echo('>> Loading Packs');
	exec(packEnergy);
	exec(packRepair);
	exec(packShield);
	exec(packStealthShield);
	exec(packCloak);
	exec(packJammer);
	exec(packAmmo);
	exec(packChameleon);
	exec(packCommand);
	exec(packTrueSight);		
	exec(packBuilder);		
	exec(packSuicide);
	exec(packRegeneration);
	exec(packTitanBurst);         
	exec(packBurner);         
	exec(packTrollMagma);         
	exec(packBurner);         
	exec(packShort);         
   echo('<< Packs Loaded');

   echo('>> Loading Misc');
	exec(miscBeacon);
	exec(miscGrenade);
	exec(miscMine);
   echo('<< Misc Loaded');
	
   echo('>> Loading Deploy Functions');
	exec(deployFunctions);
   echo('<< Deploy Functions Loaded');
	
   echo('>> Loading Deployable Sensors');
	exec(deployCamera);
	exec(deployMotionSensor);
	exec(deploySensorCat);	
      exec(deployPulseSensor);
	exec(deploySensorJammer);
   echo('<< Deployable Sensors Loaded');
	
   echo('>> Loading Deployable Objects');
	exec(deployAmmoStation);
	exec(deployBaseCloak);
	exec(deployCommandStation);
	exec(deployControlJammer);
	exec(deployFighter);
	exec(deployInventoryStation);
	exec(deployJailTower);
	exec(deployJumpPad);
	exec(deployTeleporter);
	exec(deployTransport);
   echo('<< Deployable Objects Loaded');

   echo('>> Loading Deployable Barriers');
	exec(deployBlastWall);
	exec(deployForceField);
	exec(deployForceFieldDoor);
	exec(deployLargeForceField);
	exec(deployLargeForceFieldDoor);
	exec(deployPlatform);
   echo('<< Deployable Barriers Loaded');

   echo('>> Loading Power Systems');
	exec(powerFunctions);
	exec(deployMobileInventory);
	exec(deployPortableGenerator);
	exec(deployPortableSolar);
   echo('<< Power Systems Loaded');

   echo('>> Loading Remote Base Objects Loaded');
	exec(deployAirbase);
	exec(deployBunkerPack);
	exec(dropShipFunctions);
	exec(dropShipCommandShip);
	exec(dropShipGunShip);
	exec(dropShipSupplyShip);
   echo('<< Remote Base Objects Loaded');

   echo('>> Loading Droids');
	exec(droidProbeDroid);
	exec(droidSuicideDroid);
	exec(droidSurveyDroid);
   echo('<< Droids Loaded');
	
	exec(Player);
		
	exec(Vehicle);
   echo('>> Loading Vehicles');
	exec(vehicleFighter);
	exec(vehicleInterceptor);
	exec(vehicleLAPC);
	exec(vehicleHAPC);
   echo('<< Vehicles Loaded');
	
	
	exec(Turret);
   echo('>> Loading Turrets');
	exec(turretFlameTurret);
	exec(turretFusionTurret);
	exec(turretIonTurret);
	exec(turretIrradiationTurret);
	exec(turretLaserTurret);
	exec(turretMissileTurret);
	exec(turretMortarTurret);
	exec(turretNuclearTurret);
	exec(turretParticleBeamTurret);
	exec(turretPlasmaTurret);
	exec(turretShockTurret);
	exec(turretVortexTurret);
   echo('<< Turrets Loaded');

	exec(StaticShape);
	
	exec(Station);
   echo('>> Loading Stations');
	exec(StationQuick);
	exec(stationAmmoStation);
	exec(stationCommandStation);
	exec(stationDeployableStation);
	exec(stationInventoryStation);
	exec(stationMobileStation);
	exec(stationVehicleStation);
   echo('<< Stations Loaded');

	
	exec(Moveable);
	exec(Sensor);

	exec(AI);
	exec(InteriorLight);

	exec(serverItemUsage);	
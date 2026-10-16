//--------------------------------------------------
// Recon armor - male
//--------------------------------------------------

$ArmorType[Male, iReconArmor] = reconarmor;
$ArmorType[Female, iReconArmor] = reconfemalearmor;
$ArmorName[reconarmor] = iReconArmor;
$ArmorName[reconfemalearmor] = iReconArmor;
$InvList[iReconArmor] = 1;

ItemData iReconArmor
{
   heading = "aSpecialist";
	description = "Recon";
	className = "Armor";
	price = 175;
};

PlayerData reconarmor
{

   // === Patch Ver 1.1 additions ===
   horzVelClamp = 60;
   validateShape = true;
   // ========================

   className = "Armor";
   shapeFile = "larmor";
   damageSkinData = "armorDamageSkins";
   debrisId = playerDebris;
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = True;
   mapFilter = 1;
   mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 24; 	// was 22 (RJC)
   minJetEnergy = 1;
   jetForce = 260; 			// was 236 (RJC)
   jetEnergyDrain = 0.8;

   maxDamage = 0.66;
   maxForwardSpeed = 12; 		// was 11 (RJC)
   maxBackwardSpeed = 11; 		// was 10 (RJC)
   maxSideSpeed = 11; 		// was 10 (RJC)
   groundForce = 45 * 9.0; 		// was 40 * 9.0 (RJC)
   mass = 9.0;
   groundTraction = 3.0;
   maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

   minDamageSpeed = 25;
   damageScale = 0.005;

   jumpImpulse = 75;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
 
    // poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

$DamageScale[reconarmor, $LandingDamageType] = 1.0;
$DamageScale[reconarmor, $ImpactDamageType] = 1.0;
$DamageScale[reconarmor, $CrushDamageType] = 1.0;
$DamageScale[reconarmor, $BulletDamageType] = 1.0; // was 1.2
$DamageScale[reconarmor, $PlasmaDamageType] = 1.0;
$DamageScale[reconarmor, $EnergyDamageType] = 1.3;
$DamageScale[reconarmor, $ExplosionDamageType] = 1.0;
$DamageScale[reconarmor, $MissileDamageType] = 1.0;
$DamageScale[reconarmor, $DebrisDamageType] = 1.2;
$DamageScale[reconarmor, $ShrapnelDamageType] = 1.2;
$DamageScale[reconarmor, $LaserDamageType] = 0.9; // was 1.0
$DamageScale[reconarmor, $MortarDamageType] = 1.3;
$DamageScale[reconarmor, $BlasterDamageType] = 1.3;
$DamageScale[reconarmor, $ElectricityDamageType] = 1.0;
$DamageScale[reconarmor, $MineDamageType] = 1.2;
$DamageScale[reconarmor, $PoisonGasDamageType] = 1.0;
$DamageScale[reconarmor, $RadiationDamageType] = 1.0;
$DamageScale[reconarmor, $EMPDamageType] = 1.0;
$DamageScale[reconarmor, $NullDamageType] = 0.0;
$DamageScale[reconarmor, $FireDamageType] = 1.0;
$DamageScale[reconarmor, $AcidDamageType] = 1.0;
$DamageScale[reconarmor, $BlindDamageType] = 1.0;
$DamageScale[reconarmor, $SniperRifleDamageType] = 0.9; // was 1.0
$DamageScale[reconarmor, $ShotgunDamageType] = 0.9; // was 1.0
$DamageScale[reconarmor, $FlakDamageType] = 1.0;
$DamageScale[reconarmor, $ExplosiveGatDamageType] = 1.0;
$DamageScale[reconarmor, $ArtilleryShellDamageType] = 1.0;
$DamageScale[reconarmor, $TimedExplosiveDamageType] = 1.0;
$DamageScale[reconarmor, $RemoteBombDamageType] = 1.0;
$DamageScale[reconarmor, $HandDamageType] = 0.7;

$ItemMax[reconarmor, Blaster] = 1;
$ItemMax[reconarmor, Chaingun] = 1;
$ItemMax[reconarmor, Disclauncher] = 1;
$ItemMax[reconarmor, GrenadeLauncher] = 0;
$ItemMax[reconarmor, Mortar] = 0;
$ItemMax[reconarmor, PlasmaGun] = 1;
$ItemMax[reconarmor, LaserRifle] = 1;
$ItemMax[reconarmor, EnergyRifle] = 1;
$ItemMax[reconarmor, TargetingLaser] = 1;
$ItemMax[reconarmor, MineAmmo] = 3;
$ItemMax[reconarmor, Grenade] = 5;
$ItemMax[reconarmor, Beacon]  = 2;

$ItemMax[reconarmor, BulletAmmo] = 100;
$ItemMax[reconarmor, PlasmaAmmo] = 30;
$ItemMax[reconarmor, DiscAmmo] = 15;
$ItemMax[reconarmor, GrenadeAmmo] = 10;
$ItemMax[reconarmor, MortarAmmo] = 10;

$ItemMax[reconarmor, EnergyPack] = 1;
$ItemMax[reconarmor, RepairPack] = 1;
$ItemMax[reconarmor, ShieldPack] = 1;
$ItemMax[reconarmor, SensorJammerPack] = 1;
$ItemMax[reconarmor, MotionSensorPack] = 1;
$ItemMax[reconarmor, PulseSensorPack] = 1;
$ItemMax[reconarmor, DeployableSensorJammerPack] = 1;
$ItemMax[reconarmor, CameraPack] = 1;
$ItemMax[reconarmor, TurretPack] = 0;
$ItemMax[reconarmor, AmmoPack] = 1;
$ItemMax[reconarmor, RepairKit] = 1;
$ItemMax[reconarmor, DeployableInvPack] = 0;
$ItemMax[reconarmor, DeployableAmmoPack] = 0;

$MaxWeapons[reconarmor] = 3;


//--------------------------------------------------
// Recon armor - female
//--------------------------------------------------
PlayerData reconfemalearmor
{

   // === Patch Ver 1.1 additions ===
   horzVelClamp = 60;
   validateShape = true;
   // ========================

   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 24; // was 22 (RJC)
   minJetEnergy = 1;
   jetForce = 260; // was 236 (RJC)
   jetEnergyDrain = 0.8;

	maxDamage = 0.66;
   maxForwardSpeed = 12; // was 11 (RJC)
   maxBackwardSpeed = 11; // was 10 (RJC)
   maxSideSpeed = 11; // was 10 (RJC)
   groundForce = 45 * 9.0; // was 40 * 9.0 (RJC)
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 75;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };


   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

$DamageScale[reconfemalearmor, $LandingDamageType] = 1.0;
$DamageScale[reconfemalearmor, $ImpactDamageType] = 1.0;	
$DamageScale[reconfemalearmor, $CrushDamageType] = 1.0;	
$DamageScale[reconfemalearmor, $BulletDamageType] = 1.0; // was 1.2
$DamageScale[reconfemalearmor, $PlasmaDamageType] = 1.0;
$DamageScale[reconfemalearmor, $EnergyDamageType] = 1.3;
$DamageScale[reconfemalearmor, $ExplosionDamageType] = 1.0;
$DamageScale[reconfemalearmor, $MissileDamageType] = 1.0;
$DamageScale[reconfemalearmor, $ShrapnelDamageType] = 1.2;
$DamageScale[reconfemalearmor, $DebrisDamageType] = 1.2;
$DamageScale[reconfemalearmor, $LaserDamageType] = 0.9; // was 1.0
$DamageScale[reconfemalearmor, $MortarDamageType] = 1.3;
$DamageScale[reconfemalearmor, $BlasterDamageType] = 1.3;
$DamageScale[reconfemalearmor, $ElectricityDamageType] = 1.0;
$DamageScale[reconfemalearmor, $MineDamageType] = 1.2;
$DamageScale[reconfemalearmor, $PoisonGasDamageType] = 1.0;
$DamageScale[reconfemalearmor, $RadiationDamageType] = 1.0;
$DamageScale[reconfemalearmor, $EMPDamageType] = 1.0;
$DamageScale[reconfemalearmor, $NullDamageType] = 0.0;
$DamageScale[reconfemalearmor, $FireDamageType] = 1.0;
$DamageScale[reconfemalearmor, $AcidDamageType] = 1.0;
$DamageScale[reconfemalearmor, $BlindDamageType] = 1.0;
$DamageScale[reconfemalearmor, $SniperRifleDamageType] = 0.9; //
$DamageScale[reconfemalearmor, $ShotgunDamageType] = 0.9; //
$DamageScale[reconfemalearmor, $FlakDamageType] = 1.0;
$DamageScale[reconfemalearmor, $ExplosiveGatDamageType] = 1.0;
$DamageScale[reconfemalearmor, $ArtilleryShellDamageType] = 1.0;
$DamageScale[reconfemalearmor, $TimedExplosiveDamageType] = 1.0;
$DamageScale[reconfemalearmor, $RemoteBombDamageType] = 1.0;
$DamageScale[reconfemalearmor, $HandDamageType] = 0.7;

$ItemMax[reconfemalearmor, Blaster] = 1;
$ItemMax[reconfemalearmor, Chaingun] = 1;
$ItemMax[reconfemalearmor, Disclauncher] = 1;
$ItemMax[reconfemalearmor, GrenadeLauncher] = 0;
$ItemMax[reconfemalearmor, Mortar] = 0;
$ItemMax[reconfemalearmor, PlasmaGun] = 1;
$ItemMax[reconfemalearmor, LaserRifle] = 1;
$ItemMax[reconfemalearmor, EnergyRifle] = 1;
$ItemMax[reconfemalearmor, TargetingLaser] = 1;
$ItemMax[reconfemalearmor, MineAmmo] = 3;
$ItemMax[reconfemalearmor, Grenade] = 5;
$ItemMax[reconfemalearmor, Beacon] = 2;

$ItemMax[reconfemalearmor, BulletAmmo] = 100;
$ItemMax[reconfemalearmor, PlasmaAmmo] = 30;
$ItemMax[reconfemalearmor, DiscAmmo] = 15;
$ItemMax[reconfemalearmor, GrenadeAmmo] = 10;
$ItemMax[reconfemalearmor, MortarAmmo] = 10;

$ItemMax[reconfemalearmor, EnergyPack] = 1;
$ItemMax[reconfemalearmor, RepairPack] = 1;
$ItemMax[reconfemalearmor, ShieldPack] = 1;
$ItemMax[reconfemalearmor, SensorJammerPack] = 1;
$ItemMax[reconfemalearmor, MotionSensorPack] = 1;
$ItemMax[reconfemalearmor, PulseSensorPack] = 1;
$ItemMax[reconfemalearmor, DeployableSensorJammerPack] = 1;
$ItemMax[reconfemalearmor, CameraPack] = 1;
$ItemMax[reconfemalearmor, TurretPack] = 0;
$ItemMax[reconfemalearmor, AmmoPack] = 1;
$ItemMax[reconfemalearmor, RepairKit] = 1;
$ItemMax[reconfemalearmor, DeployableInvPack] = 0;
$ItemMax[reconfemalearmor, DeployableAmmoPack] = 0;

$MaxWeapons[reconfemalearmor] = 3;


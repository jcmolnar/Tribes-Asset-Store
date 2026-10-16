//--------------------------------------------------
// Espionage armor - male
//--------------------------------------------------

$ArmorType[Male, iEspionageArmor] = espionagearmor;
$ArmorType[Female, iEspionageArmor] = espionagefemalearmor;
$ArmorName[espionagearmor] = iEspionageArmor;
$ArmorName[espionagefemalearmor] = iEspionageArmor;
$InvList[iEspionageArmor] = 1;

ItemData iEspionageArmor
{
   heading = "aSpecialist";
	description = "Espionage";
	className = "Armor";
	price = 200;
};

PlayerData espionagearmor
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
	maxJetForwardVelocity = 22;
	minJetEnergy = 1;
	jetForce = 250; // was 236 (RJC)
	jetEnergyDrain = 0.8;

	maxDamage = 0.66;
	maxForwardSpeed = 11;
	maxBackwardSpeed = 10;
	maxSideSpeed = 10;
	groundForce = 30 * 9.0; // was 40 * 9.0 (RJC)
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

$DamageScale[espionagearmor, $LandingDamageType] = 1.0;
$DamageScale[espionagearmor, $ImpactDamageType] = 1.0;
$DamageScale[espionagearmor, $CrushDamageType] = 1.0;
$DamageScale[espionagearmor, $BulletDamageType] = 1.2;
$DamageScale[espionagearmor, $PlasmaDamageType] = 0.6; // was 1.0
$DamageScale[espionagearmor, $EnergyDamageType] = 0.7; // was 1.3
$DamageScale[espionagearmor, $ExplosionDamageType] = 1.0;
$DamageScale[espionagearmor, $MissileDamageType] = 1.0;
$DamageScale[espionagearmor, $ShrapnelDamageType] = 0.7; // was 1.2
$DamageScale[espionagearmor, $DebrisDamageType] = 1.2;
$DamageScale[espionagearmor, $LaserDamageType] = 0.6; // was 1.0
$DamageScale[espionagearmor, $MortarDamageType] = 1.3;
$DamageScale[espionagearmor, $BlasterDamageType] = 1.3;
$DamageScale[espionagearmor, $ElectricityDamageType] = 1.0;
$DamageScale[espionagearmor, $MineDamageType] = 1.2;
$DamageScale[espionagearmor, $PoisonGasDamageType] = 1.0;
$DamageScale[espionagearmor, $RadiationDamageType] = 1.0;
$DamageScale[espionagearmor, $EMPDamageType] = 1.0;
$DamageScale[espionagearmor, $NullDamageType] = 0.0;
$DamageScale[espionagearmor, $FireDamageType] = 1.0;
$DamageScale[espionagearmor, $AcidDamageType] = 1.0;
$DamageScale[espionagearmor, $BlindDamageType] = 1.0;
$DamageScale[espionagearmor, $SniperRifleDamageType] = 1.0;
$DamageScale[espionagearmor, $ShotgunDamageType] = 1.0;
$DamageScale[espionagearmor, $FlakDamageType] = 1.0;
$DamageScale[espionagearmor, $ExplosiveGatDamageType] = 1.0;
$DamageScale[espionagearmor, $ArtilleryShellDamageType] = 1.0;
$DamageScale[espionagearmor, $TimedExplosiveDamageType] = 1.0;
$DamageScale[espionagearmor, $RemoteBombDamageType] = 1.0;
$DamageScale[espionagearmor, $HandDamageType] = 0.7;

$ItemMax[espionagearmor, Blaster] = 1;
$ItemMax[espionagearmor, Chaingun] = 1;
$ItemMax[espionagearmor, Disclauncher] = 1;
$ItemMax[espionagearmor, GrenadeLauncher] = 0;
$ItemMax[espionagearmor, Mortar] = 0;
$ItemMax[espionagearmor, PlasmaGun] = 0;
$ItemMax[espionagearmor, LaserRifle] = 0;
$ItemMax[espionagearmor, EnergyRifle] = 1;
$ItemMax[espionagearmor, TargetingLaser] = 1;
$ItemMax[espionagearmor, MineAmmo] = 3;
$ItemMax[espionagearmor, Grenade] = 5;
$ItemMax[espionagearmor, Beacon] = 3;

$ItemMax[espionagearmor, BulletAmmo] = 100;
$ItemMax[espionagearmor, PlasmaAmmo] = 30;
$ItemMax[espionagearmor, DiscAmmo] = 10;
$ItemMax[espionagearmor, GrenadeAmmo] = 10;
$ItemMax[espionagearmor, MortarAmmo] = 10;

$ItemMax[espionagearmor, EnergyPack] = 1;
$ItemMax[espionagearmor, RepairPack] = 1;
$ItemMax[espionagearmor, ShieldPack] = 1;
$ItemMax[espionagearmor, SensorJammerPack] = 1;
$ItemMax[espionagearmor, MotionSensorPack] = 1;
$ItemMax[espionagearmor, PulseSensorPack] = 1;
$ItemMax[espionagearmor, DeployableSensorJammerPack] = 1;
$ItemMax[espionagearmor, CameraPack] = 1;
$ItemMax[espionagearmor, TurretPack] = 0;
$ItemMax[espionagearmor, AmmoPack] = 1;
$ItemMax[espionagearmor, RepairKit] = 1;
$ItemMax[espionagearmor, DeployableInvPack] = 0;
$ItemMax[espionagearmor, DeployableAmmoPack] = 0;

$MaxWeapons[espionagearmor] = 3;




//--------------------------------------------------
// Espionage armor - female
//--------------------------------------------------
PlayerData espionagefemalearmor
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
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 250; // was 236 (RJC)
   jetEnergyDrain = 0.8;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 30 * 9.0; // was 40 * 9.0 (RJC)
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

$DamageScale[espionagefemalearmor, $LandingDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $ImpactDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $CrushDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $BulletDamageType] = 1.2;
$DamageScale[espionagefemalearmor, $EnergyDamageType] = 0.7; // was 1.3
$DamageScale[espionagefemalearmor, $PlasmaDamageType] = 0.6; // was 1.0
$DamageScale[espionagefemalearmor, $ExplosionDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $MissileDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $ShrapnelDamageType] = 0.7; // was 1.2
$DamageScale[espionagefemalearmor, $DebrisDamageType] = 1.2;
$DamageScale[espionagefemalearmor, $LaserDamageType] = 0.6; // was 1.0
$DamageScale[espionagefemalearmor, $MortarDamageType] = 1.3;
$DamageScale[espionagefemalearmor, $BlasterDamageType] = 1.3;
$DamageScale[espionagefemalearmor, $ElectricityDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $MineDamageType] = 1.2;
$DamageScale[espionagefemalearmor, $PoisonGasDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $RadiationDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $EMPDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $NullDamageType] = 0.0;
$DamageScale[espionagefemalearmor, $FireDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $AcidDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $BlindDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $SniperRifleDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $ShotgunDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $FlakDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $ExplosiveGatDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $ArtilleryShellDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $TimedExplosiveDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $RemoteBombDamageType] = 1.0;
$DamageScale[espionagefemalearmor, $HandDamageType] = 0.7;

$ItemMax[espionagefemalearmor, Blaster] = 1;
$ItemMax[espionagefemalearmor, Chaingun] = 1;
$ItemMax[espionagefemalearmor, Disclauncher] = 1;
$ItemMax[espionagefemalearmor, GrenadeLauncher] = 0;
$ItemMax[espionagefemalearmor, Mortar] = 0;
$ItemMax[espionagefemalearmor, PlasmaGun] = 0;
$ItemMax[espionagefemalearmor, LaserRifle] = 0;
$ItemMax[espionagefemalearmor, EnergyRifle] = 1;
$ItemMax[espionagefemalearmor, TargetingLaser] = 1;
$ItemMax[espionagefemalearmor, MineAmmo] = 3;
$ItemMax[espionagefemalearmor, Grenade] = 5;
$ItemMax[espionagefemalearmor, Beacon] = 3;

$ItemMax[espionagefemalearmor, BulletAmmo] = 100;
$ItemMax[espionagefemalearmor, PlasmaAmmo] = 30;
$ItemMax[espionagefemalearmor, DiscAmmo] = 15;
$ItemMax[espionagefemalearmor, GrenadeAmmo] = 10;
$ItemMax[espionagefemalearmor, MortarAmmo] = 10;

$ItemMax[espionagefemalearmor, EnergyPack] = 1;
$ItemMax[espionagefemalearmor, RepairPack] = 1;
$ItemMax[espionagefemalearmor, ShieldPack] = 1;
$ItemMax[espionagefemalearmor, SensorJammerPack] = 1;
$ItemMax[espionagefemalearmor, MotionSensorPack] = 1;
$ItemMax[espionagefemalearmor, PulseSensorPack] = 1;
$ItemMax[espionagefemalearmor, DeployableSensorJammerPack] = 1;
$ItemMax[espionagefemalearmor, CameraPack] = 1;
$ItemMax[espionagefemalearmor, TurretPack] = 0;
$ItemMax[espionagefemalearmor, AmmoPack] = 1;
$ItemMax[espionagefemalearmor, RepairKit] = 1;
$ItemMax[espionagefemalearmor, DeployableInvPack] = 0;
$ItemMax[espionagefemalearmor, DeployableAmmoPack] = 0;

$MaxWeapons[espionagefemalearmor] = 3;


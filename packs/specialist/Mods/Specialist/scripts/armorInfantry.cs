//--------------------------------------------------
// Infantry armor - male
//--------------------------------------------------

$ArmorType[Male, iInfantryArmor] = infantryarmor;
$ArmorType[Female, iInfantryArmor] = infantryfemalearmor;
$ArmorName[infantryarmor] = iInfantryArmor;
$ArmorName[infantryfemalearmor] = iInfantryArmor;
$InvList[iInfantryArmor] = 1;

ItemData iInfantryArmor
{
   heading = "aSpecialist";
	description = "Infantry";
	className = "Armor";
	price = 250;
};

PlayerData infantryarmor
{

   // === Patch Ver 1.1 additions ===
   horzVelClamp = 45;
   validateShape = true;
   // ========================

   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 19; // was 17 (RJC)
   minJetEnergy = 1;
   jetForce = 360; // was 320 (RJC)
   jetEnergyDrain = 1.0;

	maxDamage = 1.0;
   maxForwardSpeed = 9.0; // was 8.0 (RJC)
   maxBackwardSpeed = 8.0; // was 7.0 (RJC)
   maxSideSpeed = 8.0; // was 7.0 (RJC)
   groundForce = 40 * 13.0; // was 35 * 13.0 (RJC)
   mass = 13.0;
   groundTraction = 3.0;
	
	maxEnergy = 90;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
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
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

$DamageScale[infantryarmor, $LandingDamageType] = 1.0;
$DamageScale[infantryarmor, $ImpactDamageType] = 1.0;
$DamageScale[infantryarmor, $CrushDamageType] = 1.0;
$DamageScale[infantryarmor, $BulletDamageType] = 1.0;
$DamageScale[infantryarmor, $PlasmaDamageType] = 0.6;
$DamageScale[infantryarmor, $EnergyDamageType] = 1.0;
$DamageScale[infantryarmor, $ExplosionDamageType] = 0.8; // was 1.0
$DamageScale[infantryarmor, $MissileDamageType] = 1.0;
$DamageScale[infantryarmor, $ShrapnelDamageType] = 1.0;
$DamageScale[infantryarmor, $DebrisDamageType] = 1.0;
$DamageScale[infantryarmor, $LaserDamageType] = 1.0;
$DamageScale[infantryarmor, $MortarDamageType] = 1.0;
$DamageScale[infantryarmor, $BlasterDamageType] = 1.0;
$DamageScale[infantryarmor, $ElectricityDamageType] = 1.0;
$DamageScale[infantryarmor, $MineDamageType] = 1.0;
$DamageScale[infantryarmor, $PoisonGasDamageType] = 1.0;
$DamageScale[infantryarmor, $RadiationDamageType] = 1.0;
$DamageScale[infantryarmor, $EMPDamageType] = 1.0;
$DamageScale[infantryarmor, $NullDamageType] = 0.0;
$DamageScale[infantryarmor, $FireDamageType] = 1.0;
$DamageScale[infantryarmor, $AcidDamageType] = 1.0;
$DamageScale[infantryarmor, $BlindDamageType] = 1.0;
$DamageScale[infantryarmor, $SniperRifleDamageType] = 1.0;
$DamageScale[infantryarmor, $ShotgunDamageType] = 1.0;
$DamageScale[infantryarmor, $FlakDamageType] = 0.8; // 
$DamageScale[infantryarmor, $ExplosiveGatDamageType] = 0.8; // 
$DamageScale[infantryarmor, $ArtilleryShellDamageType] = 1.0;
$DamageScale[infantryarmor, $TimedExplosiveDamageType] = 1.0;
$DamageScale[infantryarmor, $RemoteBombDamageType] = 1.0;
$DamageScale[infantryarmor, $HandDamageType] = 0.7;

$ItemMax[infantryarmor, Blaster] = 1;
$ItemMax[infantryarmor, Chaingun] = 1;
$ItemMax[infantryarmor, Disclauncher] = 1;
$ItemMax[infantryarmor, GrenadeLauncher] = 1;
$ItemMax[infantryarmor, Mortar] = 0;
$ItemMax[infantryarmor, PlasmaGun] = 1;
$ItemMax[infantryarmor, LaserRifle] = 0;
$ItemMax[infantryarmor, EnergyRifle] = 1;
$ItemMax[infantryarmor, TargetingLaser] = 1;
$ItemMax[infantryarmor, MineAmmo] = 3;
$ItemMax[infantryarmor, Grenade] = 6;
$ItemMax[infantryarmor, Beacon] = 3;

$ItemMax[infantryarmor, BulletAmmo] = 150;
$ItemMax[infantryarmor, PlasmaAmmo] = 40;
$ItemMax[infantryarmor, DiscAmmo] = 15;
$ItemMax[infantryarmor, GrenadeAmmo] = 10;
$ItemMax[infantryarmor, MortarAmmo] = 10;

$ItemMax[infantryarmor, EnergyPack] = 1;
$ItemMax[infantryarmor, RepairPack] = 1;
$ItemMax[infantryarmor, ShieldPack] = 1;
$ItemMax[infantryarmor, SensorJammerPack] = 1;
$ItemMax[infantryarmor, MotionSensorPack] = 1;
$ItemMax[infantryarmor, PulseSensorPack] = 1;
$ItemMax[infantryarmor, DeployableSensorJammerPack] = 1;
$ItemMax[infantryarmor, CameraPack] = 1;
$ItemMax[infantryarmor, TurretPack] = 1;
$ItemMax[infantryarmor, AmmoPack] = 1;
$ItemMax[infantryarmor, RepairKit] = 1;
$ItemMax[infantryarmor, DeployableInvPack] = 1;
$ItemMax[infantryarmor, DeployableAmmoPack] = 1;

$MaxWeapons[infantryarmor] = 4;



//--------------------------------------------------
// Infantry armor - female
//--------------------------------------------------
PlayerData infantryfemalearmor
{

   // === Patch Ver 1.1 additions ===
   horzVelClamp = 45;
   validateShape = true;
   // ========================

   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 19; // was 17 (RJC)
   minJetEnergy = 1;
   jetForce = 360; // was 320 (RJC)
   jetEnergyDrain = 1.0;

   canCrouch = false;
	maxDamage = 1.0;
   maxForwardSpeed = 9.0; // was 8.0 (RJC)
   maxBackwardSpeed = 8.0; // was 7.0 (RJC)
   maxSideSpeed = 8.0; // was 7.0 (RJC)
   groundForce = 40 * 13.0; // was 35 * 13.0 (RJC)
   mass = 13.0;
   groundTraction = 3.0;
	maxEnergy = 80;
   mass = 13.0;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
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
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

$DamageScale[infantryfemalearmor, $LandingDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $ImpactDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $CrushDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $BulletDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $EnergyDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $PlasmaDamageType] = 0.6;
$DamageScale[infantryfemalearmor, $ExplosionDamageType] = 0.8; // was 1.0
$DamageScale[infantryfemalearmor, $MissileDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $ShrapnelDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $DebrisDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $LaserDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $MortarDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $BlasterDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $ElectricityDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $MineDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $PoisonGasDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $RadiationDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $EMPDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $NullDamageType] = 0.0;
$DamageScale[infantryfemalearmor, $FireDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $AcidDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $BlindDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $SniperRifleDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $ShotgunDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $FlakDamageType] = 0.8; // 
$DamageScale[infantryfemalearmor, $ExplosiveGatDamageType] = 0.8; //
$DamageScale[infantryfemalearmor, $ArtilleryShellDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $TimedExplosiveDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $RemoteBombDamageType] = 1.0;
$DamageScale[infantryfemalearmor, $HandDamageType] = 0.7;

$ItemMax[infantryfemalearmor, Blaster] = 1;
$ItemMax[infantryfemalearmor, Chaingun] = 1;
$ItemMax[infantryfemalearmor, Disclauncher] = 1;
$ItemMax[infantryfemalearmor, GrenadeLauncher] = 1;
$ItemMax[infantryfemalearmor, Mortar] = 0;
$ItemMax[infantryfemalearmor, PlasmaGun] = 1;
$ItemMax[infantryfemalearmor, LaserRifle] = 0;
$ItemMax[infantryfemalearmor, EnergyRifle] = 1;
$ItemMax[infantryfemalearmor, TargetingLaser] = 1;
$ItemMax[infantryfemalearmor, MineAmmo] = 3;
$ItemMax[infantryfemalearmor, Grenade] = 6;
$ItemMax[infantryfemalearmor, Beacon] = 3;

$ItemMax[infantryfemalearmor, BulletAmmo] = 150;
$ItemMax[infantryfemalearmor, PlasmaAmmo] = 40;
$ItemMax[infantryfemalearmor, DiscAmmo] = 15;
$ItemMax[infantryfemalearmor, GrenadeAmmo] = 10;
$ItemMax[infantryfemalearmor, MortarAmmo] = 10;

$ItemMax[infantryfemalearmor, EnergyPack] = 1;
$ItemMax[infantryfemalearmor, RepairPack] = 1;
$ItemMax[infantryfemalearmor, ShieldPack] = 1;
$ItemMax[infantryfemalearmor, SensorJammerPack] = 1;
$ItemMax[infantryfemalearmor, MotionSensorPack] = 1;
$ItemMax[infantryfemalearmor, PulseSensorPack] = 1;
$ItemMax[infantryfemalearmor, DeployableSensorJammerPack] = 1;
$ItemMax[infantryfemalearmor, CameraPack] = 1;
$ItemMax[infantryfemalearmor, TurretPack] = 1;
$ItemMax[infantryfemalearmor, AmmoPack] = 1;
$ItemMax[infantryfemalearmor, RepairKit] = 1;
$ItemMax[infantryfemalearmor, DeployableInvPack] = 1;
$ItemMax[infantryfemalearmor, DeployableAmmoPack] = 1;

$MaxWeapons[infantryfemalearmor] = 4;


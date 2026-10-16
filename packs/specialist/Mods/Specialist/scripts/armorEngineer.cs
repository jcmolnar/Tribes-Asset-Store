//--------------------------------------------------
// Engineer armor - male
//--------------------------------------------------

$ArmorType[Male, iEngineerArmor] = engineerarmor;
$ArmorType[Female, iEngineerArmor] = engineerfemalearmor;
$ArmorName[engineerarmor] = iEngineerArmor;
$ArmorName[engineerfemalearmor] = iEngineerArmor;
$InvList[iEngineerArmor] = 1;

ItemData iEngineerArmor
{
   heading = "aSpecialist";
	description = "Engineer";
	className = "Armor";
	price = 225;
};

PlayerData engineerarmor
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
   maxJetForwardVelocity = 14; // was 17 (RJC)
   minJetEnergy = 1;
   jetForce = 360; // was 320 (RJC)
   jetEnergyDrain = 1.0;

	maxDamage = 1.0;
   maxForwardSpeed = 8.0;
   maxBackwardSpeed = 7.0;
   maxSideSpeed = 7.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	
	maxEnergy = 80;
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

$DamageScale[engineerarmor, $LandingDamageType] = 1.0;
$DamageScale[engineerarmor, $ImpactDamageType] = 1.0;
$DamageScale[engineerarmor, $CrushDamageType] = 1.0;
$DamageScale[engineerarmor, $BulletDamageType] = 0.8; // was 1.0
$DamageScale[engineerarmor, $PlasmaDamageType] = 0.6;
$DamageScale[engineerarmor, $EnergyDamageType] = 1.0;
$DamageScale[engineerarmor, $ExplosionDamageType] = 1.0;
$DamageScale[engineerarmor, $MissileDamageType] = 1.0;
$DamageScale[engineerarmor, $ShrapnelDamageType] = 1.0;
$DamageScale[engineerarmor, $DebrisDamageType] = 1.0;
$DamageScale[engineerarmor, $LaserDamageType] = 0.8; // was 1.0
$DamageScale[engineerarmor, $MortarDamageType] = 0.9; // was 1.0
$DamageScale[engineerarmor, $BlasterDamageType] = 1.0;
$DamageScale[engineerarmor, $ElectricityDamageType] = 1.0;
$DamageScale[engineerarmor, $MineDamageType] = 1.0;
$DamageScale[engineerarmor, $PoisonGasDamageType] = 0.9;
$DamageScale[engineerarmor, $RadiationDamageType] = 0.9;
$DamageScale[engineerarmor, $EMPDamageType] = 1.0;
$DamageScale[engineerarmor, $NullDamageType] = 0.0;
$DamageScale[engineerarmor, $FireDamageType] = 0.8;
$DamageScale[engineerarmor, $AcidDamageType] = 1.0;
$DamageScale[engineerarmor, $BlindDamageType] = 1.0;
$DamageScale[engineerarmor, $SniperRifleDamageType] = 0.7;
$DamageScale[engineerarmor, $ShotgunDamageType] = 0.8;
$DamageScale[engineerarmor, $FlakDamageType] = 1.0;
$DamageScale[engineerarmor, $ExplosiveGatDamageType] = 1.0;
$DamageScale[engineerarmor, $ArtilleryShellDamageType] = 1.0;
$DamageScale[engineerarmor, $TimedExplosiveDamageType] = 1.0;
$DamageScale[engineerarmor, $RemoteBombDamageType] = 1.0;
$DamageScale[engineerarmor, $HandDamageType] = 0.7;

$ItemMax[engineerarmor, Blaster] = 1;
$ItemMax[engineerarmor, Chaingun] = 1;
$ItemMax[engineerarmor, Disclauncher] = 1;
$ItemMax[engineerarmor, GrenadeLauncher] = 1;
$ItemMax[engineerarmor, Mortar] = 0;
$ItemMax[engineerarmor, PlasmaGun] = 1;
$ItemMax[engineerarmor, LaserRifle] = 0;
$ItemMax[engineerarmor, EnergyRifle] = 1;
$ItemMax[engineerarmor, TargetingLaser] = 1;
$ItemMax[engineerarmor, MineAmmo] = 3;
$ItemMax[engineerarmor, Grenade] = 5;
$ItemMax[engineerarmor, Beacon] = 3;

$ItemMax[engineerarmor, BulletAmmo] = 150;
$ItemMax[engineerarmor, PlasmaAmmo] = 40;
$ItemMax[engineerarmor, DiscAmmo] = 15;
$ItemMax[engineerarmor, GrenadeAmmo] = 10;
$ItemMax[engineerarmor, MortarAmmo] = 10;

$ItemMax[engineerarmor, EnergyPack] = 1;
$ItemMax[engineerarmor, RepairPack] = 1;
$ItemMax[engineerarmor, ShieldPack] = 1;
$ItemMax[engineerarmor, SensorJammerPack] = 1;
$ItemMax[engineerarmor, MotionSensorPack] = 1;
$ItemMax[engineerarmor, PulseSensorPack] = 1;
$ItemMax[engineerarmor, DeployableSensorJammerPack] = 1;
$ItemMax[engineerarmor, CameraPack] = 1;
$ItemMax[engineerarmor, TurretPack] = 1;
$ItemMax[engineerarmor, AmmoPack] = 1;
$ItemMax[engineerarmor, RepairKit] = 1;
$ItemMax[engineerarmor, DeployableInvPack] = 1;
$ItemMax[engineerarmor, DeployableAmmoPack] = 1;

$MaxWeapons[engineerarmor] = 4;



//--------------------------------------------------
// Engineer armor - female
//--------------------------------------------------
PlayerData engineerfemalearmor
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
   maxJetForwardVelocity = 14; // was 17 (RJC)
   minJetEnergy = 1;
   jetForce = 360; // was 320 (RJC)
   jetEnergyDrain = 1.0;

   canCrouch = false;
	maxDamage = 1.0;
   maxForwardSpeed = 8.0;
   maxBackwardSpeed = 7.0;
   maxSideSpeed = 7.0;
   groundForce = 35 * 13.0;
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

$DamageScale[engineerfemalearmor, $LandingDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $ImpactDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $CrushDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $BulletDamageType] = 0.8; // was 1.0
$DamageScale[engineerfemalearmor, $EnergyDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $PlasmaDamageType] = 0.6;
$DamageScale[engineerfemalearmor, $ExplosionDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $MissileDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $ShrapnelDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $DebrisDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $LaserDamageType] = 0.8; // was 1.0
$DamageScale[engineerfemalearmor, $MortarDamageType] = 0.9; // was 1.0
$DamageScale[engineerfemalearmor, $BlasterDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $ElectricityDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $MineDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $PoisonGasDamageType] = 0.9;
$DamageScale[engineerfemalearmor, $RadiationDamageType] = 0.9;
$DamageScale[engineerfemalearmor, $EMPDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $NullDamageType] = 0.0;
$DamageScale[engineerfemalearmor, $FireDamageType] = 0.8;
$DamageScale[engineerfemalearmor, $AcidDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $BlindDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $SniperRifleDamageType] = 0.7;
$DamageScale[engineerfemalearmor, $ShotgunDamageType] = 0.8;
$DamageScale[engineerfemalearmor, $FlakDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $ExplosiveGatDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $ArtilleryShellDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $TimedExplosiveDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $RemoteBombDamageType] = 1.0;
$DamageScale[engineerfemalearmor, $HandDamageType] = 0.7;

$ItemMax[engineerfemalearmor, Blaster] = 1;
$ItemMax[engineerfemalearmor, Chaingun] = 1;
$ItemMax[engineerfemalearmor, Disclauncher] = 1;
$ItemMax[engineerfemalearmor, GrenadeLauncher] = 1;
$ItemMax[engineerfemalearmor, Mortar] = 0;
$ItemMax[engineerfemalearmor, PlasmaGun] = 1;
$ItemMax[engineerfemalearmor, LaserRifle] = 0;
$ItemMax[engineerfemalearmor, EnergyRifle] = 1;
$ItemMax[engineerfemalearmor, TargetingLaser] = 1;
$ItemMax[engineerfemalearmor, MineAmmo] = 3;
$ItemMax[engineerfemalearmor, Grenade] = 5;
$ItemMax[engineerfemalearmor, Beacon] = 3;

$ItemMax[engineerfemalearmor, BulletAmmo] = 150;
$ItemMax[engineerfemalearmor, PlasmaAmmo] = 40;
$ItemMax[engineerfemalearmor, DiscAmmo] = 15;
$ItemMax[engineerfemalearmor, GrenadeAmmo] = 10;
$ItemMax[engineerfemalearmor, MortarAmmo] = 10;

$ItemMax[engineerfemalearmor, EnergyPack] = 1;
$ItemMax[engineerfemalearmor, RepairPack] = 1;
$ItemMax[engineerfemalearmor, ShieldPack] = 1;
$ItemMax[engineerfemalearmor, SensorJammerPack] = 1;
$ItemMax[engineerfemalearmor, MotionSensorPack] = 1;
$ItemMax[engineerfemalearmor, PulseSensorPack] = 1;
$ItemMax[engineerfemalearmor, DeployableSensorJammerPack] = 1;
$ItemMax[engineerfemalearmor, CameraPack] = 1;
$ItemMax[engineerfemalearmor, TurretPack] = 1;
$ItemMax[engineerfemalearmor, AmmoPack] = 1;
$ItemMax[engineerfemalearmor, RepairKit] = 1;
$ItemMax[engineerfemalearmor, DeployableInvPack] = 1;
$ItemMax[engineerfemalearmor, DeployableAmmoPack] = 1;

$MaxWeapons[engineerfemalearmor] = 4;


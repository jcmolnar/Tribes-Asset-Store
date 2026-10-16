//--------------------------------------------------
// Fallout armor - male
//--------------------------------------------------

$ArmorType[Male, iFalloutArmor] = falloutarmor;
$ArmorType[Female, iFalloutArmor] = falloutfemalearmor;
$ArmorName[falloutarmor] = iFalloutArmor;
$ArmorName[falloutfemalearmor] = iFalloutArmor;
$InvList[iFalloutArmor] = 1;

ItemData iFalloutArmor
{
   heading = "aSpecialist";
	description = "Fallout";
	className = "Armor";
	price = 275;
};

PlayerData falloutarmor
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
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 340; // was 320 (RJC)
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

$DamageScale[falloutarmor, $LandingDamageType] = 1.0;
$DamageScale[falloutarmor, $ImpactDamageType] = 1.0;
$DamageScale[falloutarmor, $CrushDamageType] = 1.0;
$DamageScale[falloutarmor, $BulletDamageType] = 1.2; // was 1.0
$DamageScale[falloutarmor, $PlasmaDamageType] = 0.6;
$DamageScale[falloutarmor, $EnergyDamageType] = 1.0;
$DamageScale[falloutarmor, $ExplosionDamageType] = 1.0;
$DamageScale[falloutarmor, $MissileDamageType] = 1.0;
$DamageScale[falloutarmor, $ShrapnelDamageType] = 1.0;
$DamageScale[falloutarmor, $DebrisDamageType] = 1.0;
$DamageScale[falloutarmor, $LaserDamageType] = 1.0;
$DamageScale[falloutarmor, $MortarDamageType] = 1.0;
$DamageScale[falloutarmor, $BlasterDamageType] = 1.0;
$DamageScale[falloutarmor, $ElectricityDamageType] = 1.0;
$DamageScale[falloutarmor, $MineDamageType] = 1.0;
$DamageScale[falloutarmor, $PoisonGasDamageType] = 0.0; //
$DamageScale[falloutarmor, $RadiationDamageType] = 0.0; //
$DamageScale[falloutarmor, $EMPDamageType] = 1.0;
$DamageScale[falloutarmor, $NullDamageType] = 0.0;
$DamageScale[falloutarmor, $FireDamageType] = 1.0;
$DamageScale[falloutarmor, $AcidDamageType] = 0.8; //
$DamageScale[falloutarmor, $BlindDamageType] = 1.0;
$DamageScale[falloutarmor, $SniperRifleDamageType] = 1.2; //
$DamageScale[falloutarmor, $ShotgunDamageType] = 1.2; // 
$DamageScale[falloutarmor, $FlakDamageType] = 1.0;
$DamageScale[falloutarmor, $ExplosiveGatDamageType] = 1.0;
$DamageScale[falloutarmor, $ArtilleryShellDamageType] = 1.0;
$DamageScale[falloutarmor, $TimedExplosiveDamageType] = 1.0;
$DamageScale[falloutarmor, $RemoteBombDamageType] = 1.0;
$DamageScale[falloutarmor, $HandDamageType] = 0.7;

$ItemMax[falloutarmor, Blaster] = 1;
$ItemMax[falloutarmor, Chaingun] = 1;
$ItemMax[falloutarmor, Disclauncher] = 1;
$ItemMax[falloutarmor, GrenadeLauncher] = 1;
$ItemMax[falloutarmor, Mortar] = 0;
$ItemMax[falloutarmor, PlasmaGun] = 1;
$ItemMax[falloutarmor, LaserRifle] = 0;
$ItemMax[falloutarmor, EnergyRifle] = 1;
$ItemMax[falloutarmor, TargetingLaser] = 1;
$ItemMax[falloutarmor, MineAmmo] = 3;
$ItemMax[falloutarmor, Grenade] = 6;
$ItemMax[falloutarmor, Beacon] = 3;

$ItemMax[falloutarmor, BulletAmmo] = 150;
$ItemMax[falloutarmor, PlasmaAmmo] = 40;
$ItemMax[falloutarmor, DiscAmmo] = 15;
$ItemMax[falloutarmor, GrenadeAmmo] = 10;
$ItemMax[falloutarmor, MortarAmmo] = 10;

$ItemMax[falloutarmor, EnergyPack] = 1;
$ItemMax[falloutarmor, RepairPack] = 1;
$ItemMax[falloutarmor, ShieldPack] = 1;
$ItemMax[falloutarmor, SensorJammerPack] = 1;
$ItemMax[falloutarmor, MotionSensorPack] = 1;
$ItemMax[falloutarmor, PulseSensorPack] = 1;
$ItemMax[falloutarmor, DeployableSensorJammerPack] = 1;
$ItemMax[falloutarmor, CameraPack] = 1;
$ItemMax[falloutarmor, TurretPack] = 1;
$ItemMax[falloutarmor, AmmoPack] = 1;
$ItemMax[falloutarmor, RepairKit] = 1;
$ItemMax[falloutarmor, DeployableInvPack] = 1;
$ItemMax[falloutarmor, DeployableAmmoPack] = 1;

$MaxWeapons[falloutarmor] = 4;



//--------------------------------------------------
// Fallout armor - female
//--------------------------------------------------
PlayerData falloutfemalearmor
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
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 340; // was 320 (RJC)
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

$DamageScale[falloutfemalearmor, $LandingDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $ImpactDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $CrushDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $BulletDamageType] = 1.2; // was 1.0
$DamageScale[falloutfemalearmor, $EnergyDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $PlasmaDamageType] = 0.6;
$DamageScale[falloutfemalearmor, $ExplosionDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $MissileDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $ShrapnelDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $DebrisDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $LaserDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $MortarDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $BlasterDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $ElectricityDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $MineDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $PoisonGasDamageType] = 0.0;
$DamageScale[falloutfemalearmor, $RadiationDamageType] = 0.0;
$DamageScale[falloutfemalearmor, $EMPDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $NullDamageType] = 0.0;
$DamageScale[falloutfemalearmor, $FireDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $AcidDamageType] = 0.8;
$DamageScale[falloutfemalearmor, $BlindDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $SniperRifleDamageType] = 1.2;
$DamageScale[falloutfemalearmor, $ShotgunDamageType] = 1.2;
$DamageScale[falloutfemalearmor, $FlakDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $ExplosiveGatDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $ArtilleryShellDamageType] = 1.0;
$DamageScale[falloutfemalearmor, $TimedExplosiveDamageType] = 1.0;
$DamageScale[falloutarmor, $RemoteBombDamageType] = 1.0;
$DamageScale[falloutarmor, $HandDamageType] = 0.7;

$ItemMax[falloutfemalearmor, Blaster] = 1;
$ItemMax[falloutfemalearmor, Chaingun] = 1;
$ItemMax[falloutfemalearmor, Disclauncher] = 1;
$ItemMax[falloutfemalearmor, GrenadeLauncher] = 1;
$ItemMax[falloutfemalearmor, Mortar] = 0;
$ItemMax[falloutfemalearmor, PlasmaGun] = 1;
$ItemMax[falloutfemalearmor, LaserRifle] = 0;
$ItemMax[falloutfemalearmor, EnergyRifle] = 1;
$ItemMax[falloutfemalearmor, TargetingLaser] = 1;
$ItemMax[falloutfemalearmor, MineAmmo] = 3;
$ItemMax[falloutfemalearmor, Grenade] = 6;
$ItemMax[falloutfemalearmor, Beacon] = 3;

$ItemMax[falloutfemalearmor, BulletAmmo] = 150;
$ItemMax[falloutfemalearmor, PlasmaAmmo] = 40;
$ItemMax[falloutfemalearmor, DiscAmmo] = 15;
$ItemMax[falloutfemalearmor, GrenadeAmmo] = 10;
$ItemMax[falloutfemalearmor, MortarAmmo] = 10;

$ItemMax[falloutfemalearmor, EnergyPack] = 1;
$ItemMax[falloutfemalearmor, RepairPack] = 1;
$ItemMax[falloutfemalearmor, ShieldPack] = 1;
$ItemMax[falloutfemalearmor, SensorJammerPack] = 1;
$ItemMax[falloutfemalearmor, MotionSensorPack] = 1;
$ItemMax[falloutfemalearmor, PulseSensorPack] = 1;
$ItemMax[falloutfemalearmor, DeployableSensorJammerPack] = 1;
$ItemMax[falloutfemalearmor, CameraPack] = 1;
$ItemMax[falloutfemalearmor, TurretPack] = 1;
$ItemMax[falloutfemalearmor, AmmoPack] = 1;
$ItemMax[falloutfemalearmor, RepairKit] = 1;
$ItemMax[falloutfemalearmor, DeployableInvPack] = 1;
$ItemMax[falloutfemalearmor, DeployableAmmoPack] = 1;

$MaxWeapons[falloutfemalearmor] = 4;



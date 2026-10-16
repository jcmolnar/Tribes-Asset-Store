//--------------------------------------------------
// Demolitions expert armor
//--------------------------------------------------

$ArmorType[Male, iDemolitionsArmor] = demolitionsarmor;
$ArmorType[Female, iDemolitionsArmor] = demolitionsarmor;
$ArmorName[demolitionsarmor] = iDemolitionsArmor;
$InvList[iDemolitionsArmor] = 1;

ItemData iDemolitionsArmor
{
   heading = "aSpecialist";
	description = "Demolitions";
	className = "Armor";
	price = 350;
};

PlayerData demolitionsarmor
{

   // === Patch Ver 1.1 additions ===
   horzVelClamp = 40;
   validateShape = true;
   // ========================

   className = "Armor";
   shapeFile = "harmor";
   flameShapeName = "hflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 15; // was 12 (RJC)
   minJetEnergy = 1;
   jetForce = 320; // was 385 (RJC)
   jetEnergyDrain = 1.0;

	maxDamage = 1.1; // was 1.3 (RJC)
   maxForwardSpeed = 7.5; // was 5.0 (RJC)
   maxBackwardSpeed = 6.0; // was 4.0 (RJC)
   maxSideSpeed = 6.0; // was 4.0 (RJC)
   groundForce = 35 * 14.0; // was 35 * 18.0 (RJC)
   groundTraction = 3.5; // was 4.5 (RJC)
   mass = 14.0;
	maxEnergy = 100; // was 110 (RJC)
   drag = 1.0;
   density = 1.5; // was 2.5 (RJC)
   canCrouch = false;

	minDamageSpeed = 25;
	damageScale = 0.006;

   jumpImpulse = 120; // was 150 (RJC)
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

   jetSound = SoundJetHeavy;

   rFootSounds = 
   {
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSnow,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft
  }; 
   lFootSounds =
   {
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSnow,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft
   };

   footPrints = { 4, 5 };

   boxWidth = 0.8;
   boxDepth = 0.8;
   boxNormalHeight = 2.6;

   boxNormalHeadPercentage  = 0.70;
   boxNormalTorsoPercentage = 0.45;

   boxHeadLeftPercentage  = 0.48;
   boxHeadRightPercentage = 0.70;
   boxHeadBackPercentage  = 0.48;
   boxHeadFrontPercentage = 0.60;
};

$DamageScale[demolitionsarmor, $LandingDamageType] = 1.0;
$DamageScale[demolitionsarmor, $ImpactDamageType] = 1.0;
$DamageScale[demolitionsarmor, $CrushDamageType] = 1.0;
$DamageScale[demolitionsarmor, $BulletDamageType] = 1.0; // was 0.6
$DamageScale[demolitionsarmor, $PlasmaDamageType] = 0.9; // was 0.4
$DamageScale[demolitionsarmor, $EnergyDamageType] = 1.0; // was 0.7
$DamageScale[demolitionsarmor, $ExplosionDamageType] = 0.4; // was 0.6
$DamageScale[demolitionsarmor, $MissileDamageType] = 0.4; // was 0.6
$DamageScale[demolitionsarmor, $DebrisDamageType] = 0.6; // was 0.8
$DamageScale[demolitionsarmor, $ShrapnelDamageType] = 0.6;  // was 0.8
$DamageScale[demolitionsarmor, $LaserDamageType] = 1.0; // was 0.6
$DamageScale[demolitionsarmor, $MortarDamageType] = 0.7;
$DamageScale[demolitionsarmor, $BlasterDamageType] = 1.0; // was 0.7
$DamageScale[demolitionsarmor, $ElectricityDamageType] = 1.0;
$DamageScale[demolitionsarmor, $MineDamageType] = 0.8;
$DamageScale[demolitionsarmor, $PoisonGasDamageType] = 1.0;
$DamageScale[demolitionsarmor, $RadiationDamageType] = 1.0;
$DamageScale[demolitionsarmor, $EMPDamageType] = 1.0;
$DamageScale[demolitionsarmor, $NullDamageType] = 0.0;
$DamageScale[demolitionsarmor, $FireDamageType] = 0.6;
$DamageScale[demolitionsarmor, $AcidDamageType] = 1.0;
$DamageScale[demolitionsarmor, $BlindDamageType] = 1.0;
$DamageScale[demolitionsarmor, $SniperRifleDamageType] = 1.0;
$DamageScale[demolitionsarmor, $ShotgunDamageType] = 1.0;
$DamageScale[demolitionsarmor, $FlakDamageType] = 0.7;
$DamageScale[demolitionsarmor, $ExplosiveGatDamageType] = 0.8;
$DamageScale[demolitionsarmor, $ArtilleryShellDamageType] = 0.7;
$DamageScale[demolitionsarmor, $TimedExplosiveDamageType] = 0.2;
$DamageScale[demolitionsarmor, $RemoteBombDamageType] = 0.2;
$DamageScale[demolitionsarmor, $HandDamageType] = 0.7;

$ItemMax[demolitionsarmor, Blaster] = 1;
$ItemMax[demolitionsarmor, Chaingun] = 1;
$ItemMax[demolitionsarmor, Disclauncher] = 1;
$ItemMax[demolitionsarmor, GrenadeLauncher] = 1;
$ItemMax[demolitionsarmor, Mortar] = 0;
$ItemMax[demolitionsarmor, PlasmaGun] = 1;
$ItemMax[demolitionsarmor, LaserRifle] = 0;
$ItemMax[demolitionsarmor, EnergyRifle] = 1;
$ItemMax[demolitionsarmor, TargetingLaser] = 1;
$ItemMax[demolitionsarmor, MineAmmo] = 3;
$ItemMax[demolitionsarmor, Grenade] = 12;
$ItemMax[demolitionsarmor, Beacon] = 8;

$ItemMax[demolitionsarmor, BulletAmmo] = 200;
$ItemMax[demolitionsarmor, PlasmaAmmo] = 50;
$ItemMax[demolitionsarmor, DiscAmmo] = 15;
$ItemMax[demolitionsarmor, GrenadeAmmo] = 15;
$ItemMax[demolitionsarmor, MortarAmmo] = 10;

$ItemMax[demolitionsarmor, EnergyPack] = 1;
$ItemMax[demolitionsarmor, RepairPack] = 1;
$ItemMax[demolitionsarmor, ShieldPack] = 1;
$ItemMax[demolitionsarmor, SensorJammerPack] = 1;
$ItemMax[demolitionsarmor, MotionSensorPack] = 1;
$ItemMax[demolitionsarmor, PulseSensorPack] = 1;
$ItemMax[demolitionsarmor, DeployableSensorJammerPack] = 1;
$ItemMax[demolitionsarmor, CameraPack] = 1;
$ItemMax[demolitionsarmor, TurretPack] = 1;
$ItemMax[demolitionsarmor, AmmoPack] = 1;
$ItemMax[demolitionsarmor, RepairKit] = 1;
$ItemMax[demolitionsarmor, DeployableInvPack] = 1;
$ItemMax[demolitionsarmor, DeployableAmmoPack] = 1;

$MaxWeapons[demolitionsarmor] = 5;


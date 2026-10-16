//--------------------------------------------------
// Assault armor
//--------------------------------------------------

$ArmorType[Male, iAssaultArmor] = assaultarmor;
$ArmorType[Female, iAssaultArmor] = assaultarmor;
$ArmorName[assaultarmor] = iAssaultArmor;
$InvList[iAssaultArmor] = 1;

ItemData iAssaultArmor
{
   heading = "aSpecialist";
	description = "Assault";
	className = "Armor";
	price = 400;
};

PlayerData assaultarmor
{

   // === Patch Ver 1.1 additions ===
   horzVelClamp = 30;
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
   maxJetForwardVelocity = 10; // was 12 (RJC)
   minJetEnergy = 1;
   jetForce = 420; // was 385 (RJC)
   jetEnergyDrain = 1.1;

	maxDamage = 1.32;
   maxForwardSpeed = 6.0; // was 5.0 (RJC)
   maxBackwardSpeed = 5.0; // was 4.0 (RJC)
   maxSideSpeed = 5.0; // was 4.0 (RJC)
   groundForce = 30 * 18.0; // was 35 * 18.0
   groundTraction = 4.5;
   mass = 18.0;
	maxEnergy = 110;
   drag = 1.0;
   density = 2.5;
   canCrouch = false;

	minDamageSpeed = 25;
	damageScale = 0.006;

   jumpImpulse = 150;
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

$DamageScale[assaultarmor, $LandingDamageType] = 1.0;
$DamageScale[assaultarmor, $ImpactDamageType] = 1.0;
$DamageScale[assaultarmor, $CrushDamageType] = 1.0;
$DamageScale[assaultarmor, $BulletDamageType] = 0.5; // was 0.6
$DamageScale[assaultarmor, $PlasmaDamageType] = 0.4;
$DamageScale[assaultarmor, $EnergyDamageType] = 0.7;
$DamageScale[assaultarmor, $ExplosionDamageType] = 0.8; // was 0.6
$DamageScale[assaultarmor, $MissileDamageType] = 0.8; // was 0.6
$DamageScale[assaultarmor, $DebrisDamageType] = 0.8;
$DamageScale[assaultarmor, $ShrapnelDamageType] = 0.8;
$DamageScale[assaultarmor, $LaserDamageType] = 0.7; // was 0.6
$DamageScale[assaultarmor, $MortarDamageType] = 0.7;
$DamageScale[assaultarmor, $BlasterDamageType] = 0.5; // was 0.7
$DamageScale[assaultarmor, $ElectricityDamageType] = 1.0;
$DamageScale[assaultarmor, $MineDamageType] = 0.8;
$DamageScale[assaultarmor, $PoisonGasDamageType] = 1.0;
$DamageScale[assaultarmor, $RadiationDamageType] = 1.0;
$DamageScale[assaultarmor, $EMPDamageType] = 1.0;
$DamageScale[assaultarmor, $NullDamageType] = 0.0;
$DamageScale[assaultarmor, $FireDamageType] = 0.6;
$DamageScale[assaultarmor, $AcidDamageType] = 1.0;
$DamageScale[assaultarmor, $BlindDamageType] = 1.0;
$DamageScale[assaultarmor, $SniperRifleDamageType] = 0.8;
$DamageScale[assaultarmor, $ShotgunDamageType] = 0.6;
$DamageScale[assaultarmor, $FlakDamageType] = 0.9;
$DamageScale[assaultarmor, $ExplosiveGatDamageType] = 0.8;
$DamageScale[assaultarmor, $ArtilleryShellDamageType] = 0.9;
$DamageScale[assaultarmor, $TimedExplosiveDamageType] = 0.8;
$DamageScale[assaultarmor, $RemoteBombDamageType] = 0.8;
$DamageScale[assaultarmor, $HandDamageType] = 0.7;
$ItemMax[assaultarmor, Blaster] = 1;
$ItemMax[assaultarmor, Chaingun] = 1;
$ItemMax[assaultarmor, Disclauncher] = 1;
$ItemMax[assaultarmor, GrenadeLauncher] = 1;
$ItemMax[assaultarmor, Mortar] = 1;
$ItemMax[assaultarmor, PlasmaGun] = 1;
$ItemMax[assaultarmor, LaserRifle] = 0;
$ItemMax[assaultarmor, EnergyRifle] = 1;
$ItemMax[assaultarmor, TargetingLaser] = 1;
$ItemMax[assaultarmor, MineAmmo] = 3;
$ItemMax[assaultarmor, Grenade] = 8;
$ItemMax[assaultarmor, Beacon] = 3;

$ItemMax[assaultarmor, BulletAmmo] = 200;
$ItemMax[assaultarmor, PlasmaAmmo] = 50;
$ItemMax[assaultarmor, DiscAmmo] = 15;
$ItemMax[assaultarmor, GrenadeAmmo] = 15;
$ItemMax[assaultarmor, MortarAmmo] = 10;

$ItemMax[assaultarmor, EnergyPack] = 1;
$ItemMax[assaultarmor, RepairPack] = 1;
$ItemMax[assaultarmor, ShieldPack] = 1;
$ItemMax[assaultarmor, SensorJammerPack] = 1;
$ItemMax[assaultarmor, MotionSensorPack] = 1;
$ItemMax[assaultarmor, PulseSensorPack] = 1;
$ItemMax[assaultarmor, DeployableSensorJammerPack] = 1;
$ItemMax[assaultarmor, CameraPack] = 1;
$ItemMax[assaultarmor, TurretPack] = 1;
$ItemMax[assaultarmor, AmmoPack] = 1;
$ItemMax[assaultarmor, RepairKit] = 1;
$ItemMax[assaultarmor, DeployableInvPack] = 1;
$ItemMax[assaultarmor, DeployableAmmoPack] = 1;

$MaxWeapons[assaultarmor] = 5;


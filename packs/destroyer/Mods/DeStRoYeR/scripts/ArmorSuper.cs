//----------------------------------------------------------------------------
// Super Armor
//----------------------------------------------------------------------------

$DamageScale[sarmor, $LandingDamageType] = 0.25;
$DamageScale[sarmor, $ImpactDamageType] = 0.25;
$DamageScale[sarmor, $CrushDamageType] = 0.25;
$DamageScale[sarmor, $BulletDamageType] = 0.25;
$DamageScale[sarmor, $PlasmaDamageType] = 0.25;
$DamageScale[sarmor, $EnergyDamageType] = 0.25;
$DamageScale[sarmor, $ExplosionDamageType] = 0.25;
$DamageScale[sarmor, $MissileDamageType] = 0.25;
$DamageScale[sarmor, $DebrisDamageType] = 0.25;
$DamageScale[sarmor, $ShrapnelDamageType] = 0.25;
$DamageScale[sarmor, $LaserDamageType] = 0.25;
$DamageScale[sarmor, $MortarDamageType] = 0.25;
$DamageScale[sarmor, $FireBallDamageType] = 0.25;
$DamageScale[sarmor, $ElectricityDamageType] = 0.25;
$DamageScale[sarmor, $MineDamageType] = 0.25;

$ItemMax[sarmor, FireBall] = 1;
$ItemMax[sarmor, EnChaingun] = 1;
$ItemMax[sarmor, EnergyDisc] = 1;
$ItemMax[sarmor, DCannon] = 1;
$ItemMax[sarmor, EnBlast] = 1;
$ItemMax[sarmor, Plasma] = 1;
$ItemMax[sarmor, Laser] = 1;
$ItemMax[sarmor, Lightning] = 1;
$ItemMax[sarmor, TargetingLaser] = 1;
$ItemMax[sarmor, MineAmmo] = 500;
$ItemMax[sarmor, Grenade] = 500;
$ItemMax[sarmor, Beacon]  = 500;

$ItemMax[sarmor, EnergyPack] = 1;
$ItemMax[sarmor, RepairPack] = 1;
$ItemMax[sarmor, ShieldPack] = 1;
$ItemMax[sarmor, SensorJammerPack] = 1;
$ItemMax[sarmor, MotionSensorPack] = 1;
$ItemMax[sarmor, PulseSensorPack] = 1;
$ItemMax[sarmor, DeployableSensorJammerPack] = 1;
$ItemMax[sarmor, CameraPack] = 1;
$ItemMax[sarmor, TurretPack] = 1;
$ItemMax[sarmor, AmmoPack] = 1;
$ItemMax[sarmor, RepairKit] = 1;
$ItemMax[sarmor, DeployableInvPack] = 1;
$ItemMax[sarmor, DeployableAmmoPack] = 1;

$MaxWeapons[sarmor] = 30;

//------------------------------------------------------------------
// Super Armor data:
//------------------------------------------------------------------

PlayerData sarmor
{
   description = "Secret";
   className = "Armor";
   shapeFile = "harmor";
   flameShapeName = "hflame";
    shieldShapeName = "shield";
    damageSkinData = "armorDamageSkins";
 	debrisId = playerDebris;
    shadowDetailMask = 1;
    validateShape = true;

   visibleToSensor = false;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 350;
   jetEnergyDrain = 0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 100;
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


//--------------------------------------

$ArmorType[Male, SuperArmor] = sarmor;
$ArmorName[sarmor] = SuperArmor;

$ArmorType[Female, SuperArmor] = sarmor;
$ArmorName[sarmor] = SuperArmor;

//--------------------------------------
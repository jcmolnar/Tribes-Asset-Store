//----------------------------------------------------------------------------
// Charger
//----------------------------------------------------------------------------

$DamageScale[aarmor, $LandingDamageType] = 5.0;
$DamageScale[aarmor, $ImpactDamageType] = 1.0;
$DamageScale[aarmor, $CrushDamageType] = 1.0;
$DamageScale[aarmor, $BulletDamageType] = 1.2;
$DamageScale[aarmor, $PlasmaDamageType] = 1.0;
$DamageScale[aarmor, $EnergyDamageType] = 1.3;
$DamageScale[aarmor, $ExplosionDamageType] = 1.0;
$DamageScale[aarmor, $MissileDamageType] = 1.0;
$DamageScale[aarmor, $ShrapnelDamageType] = 1.2;
$DamageScale[aarmor, $DebrisDamageType] = 1.2;
$DamageScale[aarmor, $LaserDamageType] = 1.8;
$DamageScale[aarmor, $MortarDamageType] = 1.3;
$DamageScale[aarmor, $FireBallDamageType] = 1.3;
$DamageScale[aarmor, $ElectricityDamageType] = 1.0;
$DamageScale[aarmor, $MineDamageType] = 1.2;

$ItemMax[aarmor, FireBall] = 0;
$ItemMax[aarmor, EnChaingun] = 0;
$ItemMax[aarmor, EnergyDisc] = 0;
$ItemMax[aarmor, DCannon] = 0;
$ItemMax[aarmor, EnBlast] = 0;
$ItemMax[aarmor, Plasma] = 0;
$ItemMax[aarmor, Laser] = 0;
$ItemMax[aarmor, Lightning] = 0;
$ItemMax[aarmor, TargetingLaser] = 1;
$ItemMax[aarmor, MineAmmo] = 2;
$ItemMax[aarmor, Grenade] = 5;
$ItemMax[aarmor, Beacon]  = 3;

$ItemMax[aarmor, EnergyPack] = 1;
$ItemMax[aarmor, RepairPack] = 1;
$ItemMax[aarmor, ShieldPack] = 1;
$ItemMax[aarmor, SensorJammerPack] = 1;
$ItemMax[aarmor, MotionSensorPack] = 0;
$ItemMax[aarmor, PulseSensorPack] = 0;
$ItemMax[aarmor, DeployableSensorJammerPack] = 0;
$ItemMax[aarmor, CameraPack] = 0;
$ItemMax[aarmor, TurretPack] = 0;
$ItemMax[aarmor, AmmoPack] = 1;
$ItemMax[aarmor, RepairKit] = 1;
$ItemMax[aarmor, DeployableInvPack] = 0;
$ItemMax[aarmor, DeployableAmmoPack] = 0;

$MaxWeapons[aarmor] = 3;

$DamageScale[afemale, $LandingDamageType] = 5.0;
$DamageScale[afemale, $ImpactDamageType] = 1.0;
$DamageScale[afemale, $CrushDamageType] = 1.0;
$DamageScale[afemale, $BulletDamageType] = 1.2;
$DamageScale[afemale, $PlasmaDamageType] = 1.0;
$DamageScale[afemale, $EnergyDamageType] = 1.3;
$DamageScale[afemale, $ExplosionDamageType] = 1.0;
$DamageScale[afemale, $MissileDamageType] = 1.0;
$DamageScale[afemale, $ShrapnelDamageType] = 1.2;
$DamageScale[afemale, $DebrisDamageType] = 1.2;
$DamageScale[afemale, $LaserDamageType] = 1.8;
$DamageScale[afemale, $MortarDamageType] = 1.3;
$DamageScale[afemale, $BlasterDamageType] = 1.3;
$DamageScale[afemale, $ElectricityDamageType] = 1.0;
$DamageScale[afemale, $MineDamageType] = 1.2;

$ItemMax[afemale, FireBall] = 0;
$ItemMax[afemale, EnChaingun] = 0;
$ItemMax[afemale, EnergyDisc] = 0;
$ItemMax[afemale, DCannon] = 0;
$ItemMax[afemale, EnBlast] = 0;
$ItemMax[afemale, Plasma] = 0;
$ItemMax[afemale, Laser] = 0;
$ItemMax[afemale, Lightning] = 0;
$ItemMax[afemale, TargetingLaser] = 1;
$ItemMax[afemale, MineAmmo] = 2;
$ItemMax[afemale, Grenade] = 5;
$ItemMax[afemale, Beacon]  = 3;

$ItemMax[afemale, EnergyPack] = 1;
$ItemMax[afemale, RepairPack] = 1;
$ItemMax[afemale, ShieldPack] = 1;
$ItemMax[afemale, SensorJammerPack] = 1;
$ItemMax[afemale, MotionSensorPack] = 0;
$ItemMax[afemale, PulseSensorPack] = 0;
$ItemMax[afemale, DeployableSensorJammerPack] = 0;
$ItemMax[afemale, CameraPack] = 0;
$ItemMax[afemale, TurretPack] = 0;
$ItemMax[afemale, AmmoPack] = 1;
$ItemMax[afemale, RepairKit] = 1;
$ItemMax[afemale, DeployableInvPack] = 0;
$ItemMax[afemale, DeployableAmmoPack] = 0;

$MaxWeapons[afemale] = 3;

//------------------------------------------------------------------
// Charger data:
//------------------------------------------------------------------

PlayerData aarmor
{
   className = "Armor";
   shapeFile = "larmor";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "plastrail";
   shieldShapeName = "shield";
   shadowDetailMask = 1;
   validateShape = true;

   visibleToSensor = false;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

	maxDamage = 0.66;
   maxForwardSpeed = 18;
   maxBackwardSpeed = 15;
   maxSideSpeed = 12;
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

PlayerData afemale
{
   className = "Armor";
   shapeFile = "lfemale";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "plastrail";
   shieldShapeName = "shield";
   shadowDetailMask = 1;
   validateShape = true;

   visibleToSensor = false;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

	maxDamage = 0.66;
   maxForwardSpeed = 18;
   maxBackwardSpeed = 15;
   maxSideSpeed = 12;
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

$ArmorType[Male, ChargerArmor] = aarmor;
$ArmorType[Female, ChargerArmor] = afemale;
$ArmorName[aarmor] = ChargerArmor;
$ArmorName[afemale] = ChargerArmor;

//--------------------------------------

ItemData ChargerArmor
{
   heading = "aArmor";
	description = "Charger";
	className = "Armor";
	price = 400;
};

//--------------------------------------
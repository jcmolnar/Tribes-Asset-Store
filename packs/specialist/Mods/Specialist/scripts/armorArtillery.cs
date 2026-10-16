//--------------------------------------------------
// Artillery armor
//--------------------------------------------------

$ArmorType[Male, iArtilleryArmor] = artilleryarmor;
$ArmorType[Female, iArtilleryArmor] = artilleryarmor;
$ArmorName[artilleryarmor] = iArtilleryArmor;
$InvList[iArtilleryArmor] = 1;

ItemData iArtilleryArmor
{
   heading = "aSpecialist";
	description = "Artillery";
	className = "Armor";
	price = 475;
};

PlayerData artilleryarmor
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
	 maxJetForwardVelocity = 10; 		// was 12 (RJC)
	 minJetEnergy = 1;
	 jetForce = 395; 			// was 385
	 jetEnergyDrain = 1.1;

	maxDamage = 1.32;
	maxForwardSpeed = 5.0;
	maxBackwardSpeed = 4.0;
	maxSideSpeed = 4.0;
	groundForce = 35 * 18.0;
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

$DamageScale[artilleryarmor, $LandingDamageType] = 1.0;
$DamageScale[artilleryarmor, $ImpactDamageType] = 1.0;
$DamageScale[artilleryarmor, $CrushDamageType] = 1.0;
$DamageScale[artilleryarmor, $BulletDamageType] = 0.4; // was 0.6 (RJC)
$DamageScale[artilleryarmor, $PlasmaDamageType] = 0.7; // was 0.4 (RJC)
$DamageScale[artilleryarmor, $EnergyDamageType] = 0.8; // was 0.7 (RJC)
$DamageScale[artilleryarmor, $ExplosionDamageType] = 0.4; // was 0.6 (RJC)
$DamageScale[artilleryarmor, $MissileDamageType] = 0.5; // was 0.6 (RJC)
$DamageScale[artilleryarmor, $DebrisDamageType] = 0.8;
$DamageScale[artilleryarmor, $ShrapnelDamageType] = 0.6; // was 0.8 (RJC)
$DamageScale[artilleryarmor, $LaserDamageType] = 0.8; // was 0.6 (RJC)
$DamageScale[artilleryarmor, $MortarDamageType] = 0.5; // was 0.7 (RJC)
$DamageScale[artilleryarmor, $BlasterDamageType] = 0.8; // was 0.7 (RJC)
$DamageScale[artilleryarmor, $ElectricityDamageType] = 1.0;
$DamageScale[artilleryarmor, $MineDamageType] = 0.7; // was 0.8 (RJC)
$DamageScale[artilleryarmor, $PoisonGasDamageType] = 1.0;
$DamageScale[artilleryarmor, $RadiationDamageType] = 1.0;
$DamageScale[artilleryarmor, $EMPDamageType] = 1.0;
$DamageScale[artilleryarmor, $NullDamageType] = 0.0;
$DamageScale[artilleryarmor, $FireDamageType] = 0.9;
$DamageScale[artilleryarmor, $AcidDamageType] = 1.0;
$DamageScale[artilleryarmor, $BlindDamageType] = 1.0;
$DamageScale[artilleryarmor, $SniperRifleDamageType] = 0.5;
$DamageScale[artilleryarmor, $ShotgunDamageType] = 0.6;
$DamageScale[artilleryarmor, $FlakDamageType] = 0.6;
$DamageScale[artilleryarmor, $ExplosiveGatDamageType] = 0.6;
$DamageScale[artilleryarmor, $ArtilleryShellDamageType] = 0.6;
$DamageScale[artilleryarmor, $TimedExplosiveDamageType] = 0.7;
$DamageScale[artilleryarmor, $RemoteBombDamageType] = 0.7;
$DamageScale[artilleryarmor, $HandDamageType] = 0.7;

$ItemMax[artilleryarmor, Blaster] = 1;
$ItemMax[artilleryarmor, Chaingun] = 1;
$ItemMax[artilleryarmor, Disclauncher] = 1;
$ItemMax[artilleryarmor, GrenadeLauncher] = 1;
$ItemMax[artilleryarmor, Mortar] = 0;
$ItemMax[artilleryarmor, PlasmaGun] = 1;
$ItemMax[artilleryarmor, LaserRifle] = 0;
$ItemMax[artilleryarmor, EnergyRifle] = 1;
$ItemMax[artilleryarmor, TargetingLaser] = 1;
$ItemMax[artilleryarmor, MineAmmo] = 3;
$ItemMax[artilleryarmor, Grenade] = 8;
$ItemMax[artilleryarmor, Beacon] = 3;

$ItemMax[artilleryarmor, BulletAmmo] = 200;
$ItemMax[artilleryarmor, PlasmaAmmo] = 50;
$ItemMax[artilleryarmor, DiscAmmo] = 15;
$ItemMax[artilleryarmor, GrenadeAmmo] = 15;
$ItemMax[artilleryarmor, MortarAmmo] = 15;

$ItemMax[artilleryarmor, EnergyPack] = 1;
$ItemMax[artilleryarmor, RepairPack] = 1;
$ItemMax[artilleryarmor, ShieldPack] = 1;
$ItemMax[artilleryarmor, SensorJammerPack] = 1;
$ItemMax[artilleryarmor, MotionSensorPack] = 1;
$ItemMax[artilleryarmor, PulseSensorPack] = 1;
$ItemMax[artilleryarmor, DeployableSensorJammerPack] = 1;
$ItemMax[artilleryarmor, CameraPack] = 1;
$ItemMax[artilleryarmor, TurretPack] = 1;
$ItemMax[artilleryarmor, AmmoPack] = 1;
$ItemMax[artilleryarmor, RepairKit] = 1;
$ItemMax[artilleryarmor, DeployableInvPack] = 1;
$ItemMax[artilleryarmor, DeployableAmmoPack] = 1;

$MaxWeapons[artilleryarmor] = 6;


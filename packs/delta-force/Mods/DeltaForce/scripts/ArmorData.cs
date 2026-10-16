//----------------------------------------------------------------------------
// Light Armor
//----------------------------------------------------------------------------
// DEAD FOR NOW

//----------------------------------------------------------------------------
// Medium Armor
//----------------------------------------------------------------------------
// DEAD FOR NOW

//----------------------------------------------------------------------------
// Heavy Armor
//----------------------------------------------------------------------------
// DEAD FOR NOW

//----------------------------------------------------------------------------
// light Female Armor
//----------------------------------------------------------------------------
// DEAD FOR NOW

//----------------------------------------------------------------------------
// Medium Female Armor
//----------------------------------------------------------------------------
// DEAD FOR NOW

//------------------------------------------------------------------
// light armor data:
//------------------------------------------------------------------

DamageSkinData armorDamageSkins
{
   bmpName[0] = "dskin1_armor";
   bmpName[1] = "dskin2_armor";
   bmpName[2] = "dskin3_armor";
   bmpName[3] = "dskin4_armor";
   bmpName[4] = "dskin5_armor";
   bmpName[5] = "dskin6_armor";
   bmpName[6] = "dskin7_armor";
   bmpName[7] = "dskin8_armor";
   bmpName[8] = "dskin9_armor";
   bmpName[9] = "dskin10_armor";
};


//------------------------------------------------------------------
// Medium Armor data:
//------------------------------------------------------------------

//------------------------------------------------------------------
// Heavy Armor data:
//------------------------------------------------------------------

PlayerData harmor
{
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
   maxJetForwardVelocity = 12;
   minJetEnergy = 1;
   jetForce = 385;
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

//------------------------------------------------------------------
// Light female data:
//------------------------------------------------------------------


//------------------------------------------------------------------
// Medium female data:
//------------------------------------------------------------------

//------------------------------------------------------------------
//
//------------------------------------------------------------------

// DELTA FORCE ARMOR
// -------------------------------------------

// MEDIC

$DamageScale[marmor, $LandingDamageType] = 1.0;
$DamageScale[marmor, $ImpactDamageType] = 1.0;
$DamageScale[marmor, $CrushDamageType] = 1.0;
$DamageScale[marmor, $BulletDamageType] = 1.2;
$DamageScale[marmor, $PlasmaDamageType] = 1.0;
$DamageScale[marmor, $EnergyDamageType] = 1.3;
$DamageScale[marmor, $ExplosionDamageType] = 1.0;
$DamageScale[marmor, $MissileDamageType] = 1.0;
$DamageScale[marmor, $DebrisDamageType] = 1.2;
$DamageScale[marmor, $ShrapnelDamageType] = 1.2;
$DamageScale[marmor, $LaserDamageType] = 1.0;
$DamageScale[marmor, $MortarDamageType] = 1.3;
$DamageScale[marmor, $BlasterDamageType] = 1.3;
$DamageScale[marmor, $ElectricityDamageType] = 1.0;
$DamageScale[marmor, $MineDamageType] = 1.2;
$DamageScale[marmor, $ChargeDamageType] = 1.2;
$DamageScale[marmor, $AirstrikeDamageType] = 1.0;

$ItemMax[marmor, Blaster] = 1;
$ItemMax[marmor, Chaingun] = 1;
$ItemMax[marmor, Disclauncher] = 1;
$ItemMax[marmor, GrenadeLauncher] = 1;
$ItemMax[marmor, Mortar] = 0;
$ItemMax[marmor, PlasmaGun] = 1;
$ItemMax[marmor, LaserRifle] = 1;
$ItemMax[marmor, EnergyRifle] = 1;
$ItemMax[marmor, TargetingLaser] = 1;
$ItemMax[marmor, MineAmmo] = 3;
$ItemMax[marmor, Grenade] = 5;
$ItemMax[marmor, Beacon]  = 3;
$ItemMax[marmor, SOCOM] = 1;
$ItemMax[marmor, OICW] = 0;
$ItemMax[marmor, SAW] = 0;
$ItemMax[marmor, MP5] = 1;
$ItemMax[marmor, PSG1] = 0;
$ItemMax[marmor, FiftyCal] = 0;
$ItemMax[marmor, LAW] = 0;
$ItemMax[marmor, AutoShotgun] = 0;
$ItemMax[marmor, Howitzer] = 0;
$ItemMax[marmor, Airstrike] = 0;
$ItemMax[marmor, GrappleHook] = 0;
$ItemMax[marmor, Stinger] = 0;
$ItemMax[marmor, Flamethrower] = 0;

$ItemMax[marmor, BulletAmmo] = 100;
$ItemMax[marmor, PlasmaAmmo] = 30;
$ItemMax[marmor, DiscAmmo] = 15;
$ItemMax[marmor, GrenadeAmmo] = 10;
$ItemMax[marmor, MortarAmmo] = 10;
$ItemMax[marmor, SOCOMAmmo] = 30;
$ItemMax[marmor, OICWAmmo] = 0;
$ItemMax[marmor, SAWAmmo] = 0;
$ItemMax[marmor, MP5Ammo] = 100;
$ItemMax[marmor, PSG1Ammo] = 0;
$ItemMax[marmor, FiftyCalAmmo] = 0;
$ItemMax[marmor, LAWAmmo] = 0;
$ItemMax[marmor, AutoShotgunAmmo] = 0;
$ItemMax[marmor, HowitzerAmmo] = 0;
$ItemMax[marmor, StingerAmmo] = 0;
$ItemMax[marmor, FlameAmmo] = 0;

$ItemMax[marmor, EnergyPack] = 0;
$ItemMax[marmor, RepairPack] = 0;
$ItemMax[marmor, ShieldPack] = 0;
$ItemMax[marmor, SensorJammerPack] = 0;
$ItemMax[marmor, MotionSensorPack] = 0;
$ItemMax[marmor, PulseSensorPack] = 0;
$ItemMax[marmor, DeployableSensorJammerPack] = 0;
$ItemMax[marmor, DeployableHealthPack] = 1;
$ItemMax[marmor, CameraPack] = 0;
$ItemMax[marmor, TurretPack] = 0;
$ItemMax[marmor, AmmoPackSmall] = 1;
$ItemMax[marmor, AmmoPackHeavy] = 0;
$ItemMax[marmor, AmmoPackExp] = 0;
$ItemMax[marmor, RepairKit] = 1;
$ItemMax[marmor, DeployableInvPack] = 0;
$ItemMax[marmor, DeployableAmmoPack] = 0;
$ItemMax[marmor, TwentyPack] = 0;
$ItemMax[marmor, HowitzerPack] = 0;
$ItemMax[marmor, SAMPack] = 0;
$ItemMax[marmor, Charge] = 0;
$ItemMax[marmor, AirstrikePack] = 0;
$ItemMax[marmor, GrapplePack] = 0;
$ItemMax[marmor, ReloaderPack] = 0;
$ItemMax[marmor, Parachute] = 1;
$ItemMax[marmor, FuelPack] = 0;
$ItemMax[marmor, PortGenPack] = 0;
$ItemMax[marmor, AAPack] = 0;
$ItemMax[marmor, MedicPack] = 1;

$MaxWeapons[marmor] = 2;

// SNIPER

$DamageScale[sarmor, $LandingDamageType] = 1.0;
$DamageScale[sarmor, $ImpactDamageType] = 1.0;
$DamageScale[sarmor, $CrushDamageType] = 1.0;
$DamageScale[sarmor, $BulletDamageType] = 1.2;
$DamageScale[sarmor, $PlasmaDamageType] = 1.0;
$DamageScale[sarmor, $EnergyDamageType] = 1.3;
$DamageScale[sarmor, $ExplosionDamageType] = 1.0;
$DamageScale[sarmor, $MissileDamageType] = 1.0;
$DamageScale[sarmor, $DebrisDamageType] = 1.2;
$DamageScale[sarmor, $ShrapnelDamageType] = 1.2;
$DamageScale[sarmor, $LaserDamageType] = 1.0;
$DamageScale[sarmor, $MortarDamageType] = 1.3;
$DamageScale[sarmor, $BlasterDamageType] = 1.3;
$DamageScale[sarmor, $ElectricityDamageType] = 1.0;
$DamageScale[sarmor, $MineDamageType] = 1.2;
$DamageScale[sarmor, $ChargeDamageType] = 1.2;
$DamageScale[sarmor, $AirstrikeDamageType] = 1.0;

$ItemMax[sarmor, Blaster] = 1;
$ItemMax[sarmor, Chaingun] = 1;
$ItemMax[sarmor, Disclauncher] = 1;
$ItemMax[sarmor, GrenadeLauncher] = 1;
$ItemMax[sarmor, Mortar] = 0;
$ItemMax[sarmor, PlasmaGun] = 1;
$ItemMax[sarmor, LaserRifle] = 1;
$ItemMax[sarmor, EnergyRifle] = 1;
$ItemMax[sarmor, TargetingLaser] = 1;
$ItemMax[sarmor, MineAmmo] = 3;
$ItemMax[sarmor, Grenade] = 5;
$ItemMax[sarmor, Beacon]  = 3;
$ItemMax[sarmor, SOCOM] = 1;
$ItemMax[sarmor, OICW] = 0;
$ItemMax[sarmor, SAW] = 0;
$ItemMax[sarmor, MP5] = 0;
$ItemMax[sarmor, PSG1] = 1;
$ItemMax[sarmor, FiftyCal] = 1;
$ItemMax[sarmor, LAW] = 0;
$ItemMax[sarmor, AutoShotgun] = 0;
$ItemMax[sarmor, Howitzer] = 0;
$ItemMax[sarmor, Airstrike] = 0;
$ItemMax[sarmor, Stinger] = 0;
$ItemMax[sarmor, Flamethrower] = 0;

$ItemMax[sarmor, BulletAmmo] = 100;
$ItemMax[sarmor, PlasmaAmmo] = 30;
$ItemMax[sarmor, DiscAmmo] = 15;
$ItemMax[sarmor, GrenadeAmmo] = 10;
$ItemMax[sarmor, MortarAmmo] = 10;
$ItemMax[sarmor, SOCOMAmmo] = 30;
$ItemMax[sarmor, OICWAmmo] = 0;
$ItemMax[sarmor, SAWAmmo] = 0;
$ItemMax[sarmor, MP5Ammo] = 0;
$ItemMax[sarmor, PSG1Ammo] = 30;
$ItemMax[sarmor, FiftyCalAmmo] = 15;
$ItemMax[sarmor, LAWAmmo] = 0;
$ItemMax[sarmor, AutoShotgunAmmo] = 0;
$ItemMax[sarmor, HowitzerAmmo] = 0;
$ItemMax[sarmor, StingerAmmo] = 0;
$ItemMax[sarmor, FlameAmmo] = 0;

$ItemMax[sarmor, EnergyPack] = 0;
$ItemMax[sarmor, RepairPack] = 0;
$ItemMax[sarmor, ShieldPack] = 0;
$ItemMax[sarmor, SensorJammerPack] = 1;
$ItemMax[sarmor, MotionSensorPack] = 0;
$ItemMax[sarmor, PulseSensorPack] = 0;
$ItemMax[sarmor, DeployableSensorJammerPack] = 0;
$ItemMax[sarmor, DeployableHealthPack] = 0;
$ItemMax[sarmor, CameraPack] = 0;
$ItemMax[sarmor, TurretPack] = 0;
$ItemMax[sarmor, AmmoPackSmall] = 1;
$ItemMax[sarmor, AmmoPackHeavy] = 1;
$ItemMax[sarmor, AmmoPackExp] = 0;
$ItemMax[sarmor, RepairKit] = 1;
$ItemMax[sarmor, DeployableInvPack] = 0;
$ItemMax[sarmor, DeployableAmmoPack] = 0;
$ItemMax[sarmor, TwentyPack] = 0;
$ItemMax[sarmor, HowitzerPack] = 0;
$ItemMax[sarmor, SAMPack] = 0;
$ItemMax[sarmor, Charge] = 0;
$ItemMax[sarmor, AirstrikePack] = 0;
$ItemMax[sarmor, GrapplePack] = 0;
$ItemMax[sarmor, GrappleHook] = 0;
$ItemMax[sarmor, ReloaderPack] = 0;
$ItemMax[sarmor, Parachute] = 1;
$ItemMax[sarmor, FuelPack] = 0;
$ItemMax[sarmor, PortGenPack] = 0;
$ItemMax[sarmor, AAPack] = 0;
$ItemMax[sarmor, MedicPack] = 0;

$MaxWeapons[sarmor] = 1;

// INFANTRY

$DamageScale[iarmor, $LandingDamageType] = 1.0;
$DamageScale[iarmor, $ImpactDamageType] = 1.0;
$DamageScale[iarmor, $CrushDamageType] = 1.0;
$DamageScale[iarmor, $BulletDamageType] = 1.0;
$DamageScale[iarmor, $PlasmaDamageType] = 0.6;
$DamageScale[iarmor, $EnergyDamageType] = 1.0;
$DamageScale[iarmor, $ExplosionDamageType] = 1.0;
$DamageScale[iarmor, $MissileDamageType] = 1.0;
$DamageScale[iarmor, $ShrapnelDamageType] = 1.0;
$DamageScale[iarmor, $DebrisDamageType] = 1.0;
$DamageScale[iarmor, $LaserDamageType] = 1.0;
$DamageScale[iarmor, $MortarDamageType] = 1.0;
$DamageScale[iarmor, $BlasterDamageType] = 1.0;
$DamageScale[iarmor, $ElectricityDamageType] = 1.0;
$DamageScale[iarmor, $MineDamageType] = 1.0;
$DamageScale[iarmor, $ChargeDamageType] = 1.0;
$DamageScale[iarmor, $AirstrikeDamageType] = 1.0;

$ItemMax[iarmor, Blaster] = 1;
$ItemMax[iarmor, Chaingun] = 1;
$ItemMax[iarmor, Disclauncher] = 1;
$ItemMax[iarmor, GrenadeLauncher] = 1;
$ItemMax[iarmor, Mortar] = 0;
$ItemMax[iarmor, PlasmaGun] = 1;
$ItemMax[iarmor, LaserRifle] = 1;
$ItemMax[iarmor, EnergyRifle] = 1;
$ItemMax[iarmor, TargetingLaser] = 1;
$ItemMax[iarmor, MineAmmo] = 3;
$ItemMax[iarmor, Grenade] = 3;
$ItemMax[iarmor, Beacon]  = 3;
$ItemMax[iarmor, SOCOM] = 1;
$ItemMax[iarmor, OICW] = 1;
$ItemMax[iarmor, SAW] = 1;
$ItemMax[iarmor, MP5] = 0;
$ItemMax[iarmor, PSG1] = 0;
$ItemMax[iarmor, FiftyCal] = 0;
$ItemMax[iarmor, LAW] = 1;
$ItemMax[iarmor, AutoShotgun] = 1;
$ItemMax[iarmor, Stinger] = 0;
$ItemMax[iarmor, Flamethrower] = 1;
$ItemMax[iarmor, Howitzer] = 0;
$ItemMax[iarmor, Airstrike] = 0;

$ItemMax[iarmor, BulletAmmo] = 100;
$ItemMax[iarmor, PlasmaAmmo] = 30;
$ItemMax[iarmor, DiscAmmo] = 15;
$ItemMax[iarmor, GrenadeAmmo] = 10;
$ItemMax[iarmor, MortarAmmo] = 10;
$ItemMax[iarmor, SOCOMAmmo] = 50;
$ItemMax[iarmor, OICWAmmo] = 200;
$ItemMax[iarmor, SAWAmmo] = 400;
$ItemMax[iarmor, MP5Ammo] = 0;
$ItemMax[iarmor, PSG1Ammo] = 0;
$ItemMax[iarmor, FiftyCalAmmo] = 0;
$ItemMax[iarmor, LAWAmmo] = 2;
$ItemMax[iarmor, AutoShotgunAmmo] = 100;
$ItemMax[iarmor, FlameAmmo] = 150;
$ItemMax[iarmor, StingerAmmo] = 0;
$ItemMax[iarmor, HowitzerAmmo] = 0;

$ItemMax[iarmor, EnergyPack] = 0;
$ItemMax[iarmor, RepairPack] = 1;
$ItemMax[iarmor, ShieldPack] = 0;
$ItemMax[iarmor, SensorJammerPack] = 0;
$ItemMax[iarmor, MotionSensorPack] = 0;
$ItemMax[iarmor, PulseSensorPack] = 0;
$ItemMax[iarmor, DeployableSensorJammerPack] = 0;
$ItemMax[iarmor, DeployableHealthPack] = 0;
$ItemMax[iarmor, CameraPack] = 0;
$ItemMax[iarmor, TurretPack] = 0;
$ItemMax[iarmor, AmmoPackSmall] = 1;
$ItemMax[iarmor, AmmoPackHeavy] = 1;
$ItemMax[iarmor, AmmoPackExp] = 1;
$ItemMax[iarmor, RepairKit] = 1;
$ItemMax[iarmor, DeployableInvPack] = 0;
$ItemMax[iarmor, DeployableAmmoPack] = 0;
$ItemMax[iarmor, TwentyPack] = 0;
$ItemMax[iarmor, HowitzerPack] = 0;
$ItemMax[iarmor, SAMPack] = 0;
$ItemMax[iarmor, Charge] = 0;
$ItemMax[iarmor, AirstrikePack] = 0;
$ItemMax[iarmor, GrapplePack] = 0;
$ItemMax[iarmor, GrappleHook] = 0;
$ItemMax[iarmor, ReloaderPack] = 1;
$ItemMax[iarmor, Parachute] = 1;
$ItemMax[iarmor, FuelPack] = 1;
$ItemMax[iarmor, PortGenPack] = 1;
$ItemMax[iarmor, AAPack] = 0;
$ItemMax[iarmor, MedicPack] = 0;

$MaxWeapons[iarmor] = 2;

// SPECOPS

$DamageScale[carmor, $LandingDamageType] = 1.0;
$DamageScale[carmor, $ImpactDamageType] = 1.0;
$DamageScale[carmor, $CrushDamageType] = 1.0;
$DamageScale[carmor, $BulletDamageType] = 1.2;
$DamageScale[carmor, $PlasmaDamageType] = 1.0;
$DamageScale[carmor, $EnergyDamageType] = 1.3;
$DamageScale[carmor, $ExplosionDamageType] = 1.0;
$DamageScale[carmor, $MissileDamageType] = 1.0;
$DamageScale[carmor, $DebrisDamageType] = 1.2;
$DamageScale[carmor, $ShrapnelDamageType] = 1.2;
$DamageScale[carmor, $LaserDamageType] = 1.0;
$DamageScale[carmor, $MortarDamageType] = 1.3;
$DamageScale[carmor, $BlasterDamageType] = 1.3;
$DamageScale[carmor, $ElectricityDamageType] = 1.0;
$DamageScale[carmor, $MineDamageType] = 1.2;
$DamageScale[carmor, $ChargeDamageType] = 1.2;
$DamageScale[carmor, $AirstrikeDamageType] = 1.0;

$ItemMax[carmor, Blaster] = 1;
$ItemMax[carmor, Chaingun] = 1;
$ItemMax[carmor, Disclauncher] = 1;
$ItemMax[carmor, GrenadeLauncher] = 1;
$ItemMax[carmor, Mortar] = 0;
$ItemMax[carmor, PlasmaGun] = 1;
$ItemMax[carmor, LaserRifle] = 1;
$ItemMax[carmor, EnergyRifle] = 1;
$ItemMax[carmor, TargetingLaser] = 1;
$ItemMax[carmor, MineAmmo] = 3;
$ItemMax[carmor, Grenade] = 5;
$ItemMax[carmor, Beacon]  = 3;
$ItemMax[carmor, SOCOM] = 1;
$ItemMax[carmor, OICW] = 0;
$ItemMax[carmor, SAW] = 0;
$ItemMax[carmor, MP5] = 1;
$ItemMax[carmor, PSG1] = 0;
$ItemMax[carmor, FiftyCal] = 0;
$ItemMax[carmor, LAW] = 0;
$ItemMax[carmor, AutoShotgun] = 0;
$ItemMax[carmor, Howitzer] = 0;
$ItemMax[carmor, Airstrike] = 1;
$ItemMax[carmor, Stinger] = 1;
$ItemMax[carmor, Flamethrower] = 0;

$ItemMax[carmor, BulletAmmo] = 100;
$ItemMax[carmor, PlasmaAmmo] = 30;
$ItemMax[carmor, DiscAmmo] = 15;
$ItemMax[carmor, GrenadeAmmo] = 10;
$ItemMax[carmor, MortarAmmo] = 10;
$ItemMax[carmor, SOCOMAmmo] = 50;
$ItemMax[carmor, OICWAmmo] = 0;
$ItemMax[carmor, SAWAmmo] = 0;
$ItemMax[carmor, MP5Ammo] = 200;
$ItemMax[carmor, PSG1Ammo] = 0;
$ItemMax[carmor, FiftyCalAmmo] = 0;
$ItemMax[carmor, LAWAmmo] = 0;
$ItemMax[carmor, AutoShotgunAmmo] = 0;
$ItemMax[carmor, HowitzerAmmo] = 0;
$ItemMax[carmor, StingerAmmo] = 2;
$ItemMax[carmor, FlameAmmo] = 0;

$ItemMax[carmor, EnergyPack] = 0;
$ItemMax[carmor, RepairPack] = 0;
$ItemMax[carmor, ShieldPack] = 0;
$ItemMax[carmor, SensorJammerPack] = 1;
$ItemMax[carmor, MotionSensorPack] = 0;
$ItemMax[carmor, PulseSensorPack] = 0;
$ItemMax[carmor, DeployableSensorJammerPack] = 0;
$ItemMax[carmor, DeployableHealthPack] = 0;
$ItemMax[carmor, CameraPack] = 1;
$ItemMax[carmor, TurretPack] = 0;
$ItemMax[carmor, AmmoPackSmall] = 1;
$ItemMax[carmor, AmmoPackHeavy] = 0;
$ItemMax[carmor, AmmoPackExp] = 1;
$ItemMax[carmor, RepairKit] = 1;
$ItemMax[carmor, DeployableInvPack] = 0;
$ItemMax[carmor, DeployableAmmoPack] = 0;
$ItemMax[carmor, TwentyPack] = 0;
$ItemMax[carmor, HowitzerPack] = 0;
$ItemMax[carmor, SAMPack] = 0;
$ItemMax[carmor, Charge] = 1;
$ItemMax[carmor, AirstrikePack] = 1;
$ItemMax[carmor, GrapplePack] = 1;
$ItemMax[carmor, GrappleHook] = 1;
$ItemMax[carmor, ReloaderPack] = 1;
$ItemMax[carmor, Parachute] = 1;
$ItemMax[carmor, FuelPack] = 0;
$ItemMax[carmor, PortGenPack] = 0;
$ItemMax[carmor, AAPack] = 0;
$ItemMax[carmor, MedicPack] = 0;

$MaxWeapons[carmor] = 3;

// ENGINEER

$DamageScale[earmor, $LandingDamageType] = 1.0;
$DamageScale[earmor, $ImpactDamageType] = 1.0;
$DamageScale[earmor, $CrushDamageType] = 1.0;
$DamageScale[earmor, $BulletDamageType] = 1.0;
$DamageScale[earmor, $PlasmaDamageType] = 0.6;
$DamageScale[earmor, $EnergyDamageType] = 1.0;
$DamageScale[earmor, $ExplosionDamageType] = 1.0;
$DamageScale[earmor, $MissileDamageType] = 1.0;
$DamageScale[earmor, $ShrapnelDamageType] = 1.0;
$DamageScale[earmor, $DebrisDamageType] = 1.0;
$DamageScale[earmor, $LaserDamageType] = 1.0;
$DamageScale[earmor, $MortarDamageType] = 1.0;
$DamageScale[earmor, $BlasterDamageType] = 1.0;
$DamageScale[earmor, $ElectricityDamageType] = 1.0;
$DamageScale[earmor, $MineDamageType] = 1.0;
$DamageScale[earmor, $ChargeDamageType] = 1.0;
$DamageScale[earmor, $AirstrikeDamageType] = 1.0;

$ItemMax[earmor, Blaster] = 1;
$ItemMax[earmor, Chaingun] = 1;
$ItemMax[earmor, Disclauncher] = 1;
$ItemMax[earmor, GrenadeLauncher] = 1;
$ItemMax[earmor, Mortar] = 0;
$ItemMax[earmor, PlasmaGun] = 1;
$ItemMax[earmor, LaserRifle] = 1;
$ItemMax[earmor, EnergyRifle] = 1;
$ItemMax[earmor, TargetingLaser] = 1;
$ItemMax[earmor, MineAmmo] = 3;
$ItemMax[earmor, Grenade] = 5;
$ItemMax[earmor, Beacon]  = 3;
$ItemMax[earmor, SOCOM] = 1;
$ItemMax[earmor, OICW] = 1;
$ItemMax[earmor, SAW] = 0;
$ItemMax[earmor, MP5] = 0;
$ItemMax[earmor, PSG1] = 0;
$ItemMax[earmor, FiftyCal] = 0;
$ItemMax[earmor, LAW] = 0;
$ItemMax[earmor, AutoShotgun] = 1;
$ItemMax[earmor, Howitzer] = 0;
$ItemMax[earmor, Airstrike] = 0;
$ItemMax[earmor, Stinger] = 0;
$ItemMax[earmor, Flamethrower] = 0;

$ItemMax[earmor, BulletAmmo] = 100;
$ItemMax[earmor, PlasmaAmmo] = 30;
$ItemMax[earmor, DiscAmmo] = 15;
$ItemMax[earmor, GrenadeAmmo] = 10;
$ItemMax[earmor, MortarAmmo] = 10;
$ItemMax[earmor, SOCOMAmmo] = 50;
$ItemMax[earmor, OICWAmmo] = 100;
$ItemMax[earmor, SAWAmmo] = 0;
$ItemMax[earmor, MP5Ammo] = 0;
$ItemMax[earmor, PSG1Ammo] = 0;
$ItemMax[earmor, FiftyCalAmmo] = 0;
$ItemMax[earmor, LAWAmmo] = 0;
$ItemMax[earmor, AutoShotgunAmmo] = 75;
$ItemMax[earmor, HowitzerAmmo] = 0;
$ItemMax[earmor, StingerAmmo] = 0;
$ItemMax[earmor, FlameAmmo] = 0;

$ItemMax[earmor, EnergyPack] = 0;
$ItemMax[earmor, RepairPack] = 1;
$ItemMax[earmor, ShieldPack] = 0;
$ItemMax[earmor, SensorJammerPack] = 1;
$ItemMax[earmor, MotionSensorPack] = 1;
$ItemMax[earmor, PulseSensorPack] = 1;
$ItemMax[earmor, DeployableSensorJammerPack] = 1;
$ItemMax[earmor, DeployableHealthPack] = 0;
$ItemMax[earmor, CameraPack] = 1;
$ItemMax[earmor, TurretPack] = 1;
$ItemMax[earmor, AmmoPackSmall] = 1;
$ItemMax[earmor, AmmoPackHeavy] = 1;
$ItemMax[earmor, AmmoPackExp] = 0;
$ItemMax[earmor, RepairKit] = 1;
$ItemMax[earmor, DeployableInvPack] = 1;
$ItemMax[earmor, DeployableAmmoPack] = 1;
$ItemMax[earmor, TwentyPack] = 1;
$ItemMax[earmor, HowitzerPack] = 1;
$ItemMax[earmor, SAMPack] = 1;
$ItemMax[earmor, Charge] = 0;
$ItemMax[earmor, AirstrikePack] = 0;
$ItemMax[earmor, GrapplePack] = 0;
$ItemMax[earmor, GrappleHook] = 0;
$ItemMax[earmor, ReloaderPack] = 1;
$ItemMax[earmor, Parachute] = 1;
$ItemMax[earmor, FuelPack] = 0;
$ItemMax[earmor, PortGenPack] = 1;
$ItemMax[earmor, AAPack] = 1;
$ItemMax[earmor, MedicPack] = 0;

$MaxWeapons[earmor] = 2;

// PILOT

$DamageScale[larmor, $LandingDamageType] = 1.0;
$DamageScale[larmor, $ImpactDamageType] = 1.0;
$DamageScale[larmor, $CrushDamageType] = 1.0;
$DamageScale[larmor, $BulletDamageType] = 1.2;
$DamageScale[larmor, $PlasmaDamageType] = 1.0;
$DamageScale[larmor, $EnergyDamageType] = 1.3;
$DamageScale[larmor, $ExplosionDamageType] = 1.0;
$DamageScale[larmor, $MissileDamageType] = 1.0;
$DamageScale[larmor, $DebrisDamageType] = 1.2;
$DamageScale[larmor, $ShrapnelDamageType] = 1.2;
$DamageScale[larmor, $LaserDamageType] = 1.0;
$DamageScale[larmor, $MortarDamageType] = 1.3;
$DamageScale[larmor, $BlasterDamageType] = 1.3;
$DamageScale[larmor, $ElectricityDamageType] = 1.0;
$DamageScale[larmor, $MineDamageType] = 1.2;
$DamageScale[larmor, $ChargeDamageType] = 1.2;
$DamageScale[larmor, $AirstrikeDamageType] = 1.0;

$ItemMax[larmor, Blaster] = 1;
$ItemMax[larmor, Chaingun] = 1;
$ItemMax[larmor, Disclauncher] = 1;
$ItemMax[larmor, GrenadeLauncher] = 1;
$ItemMax[larmor, Mortar] = 0;
$ItemMax[larmor, PlasmaGun] = 1;
$ItemMax[larmor, LaserRifle] = 1;
$ItemMax[larmor, EnergyRifle] = 1;
$ItemMax[larmor, TargetingLaser] = 1;
$ItemMax[larmor, MineAmmo] = 0;
$ItemMax[larmor, Grenade] = 2;
$ItemMax[larmor, Beacon]  = 3;
$ItemMax[larmor, SOCOM] = 1;
$ItemMax[larmor, OICW] = 0;
$ItemMax[larmor, SAW] = 0;
$ItemMax[larmor, MP5] = 0;
$ItemMax[larmor, PSG1] = 0;
$ItemMax[larmor, FiftyCal] = 0;
$ItemMax[larmor, LAW] = 0;
$ItemMax[larmor, Howitzer] = 0;
$ItemMax[larmor, AutoShotgun] = 0;
$ItemMax[larmor, Airstrike] = 0;
$ItemMax[larmor, Stinger] = 0;
$ItemMax[larmor, Flamethrower] = 0;

$ItemMax[larmor, BulletAmmo] = 100;
$ItemMax[larmor, PlasmaAmmo] = 30;
$ItemMax[larmor, DiscAmmo] = 15;
$ItemMax[larmor, GrenadeAmmo] = 10;
$ItemMax[larmor, MortarAmmo] = 10;
$ItemMax[larmor, SOCOMAmmo] = 50;
$ItemMax[larmor, OICWAmmo] = 0;
$ItemMax[larmor, SAWAmmo] = 0;
$ItemMax[larmor, MP5Ammo] = 0;
$ItemMax[larmor, PSG1Ammo] = 0;
$ItemMax[larmor, FiftyCalAmmo] = 0;
$ItemMax[larmor, LAWAmmo] = 0;
$ItemMax[larmor, AutoShotgun] = 0;
$ItemMax[larmor, HowitzerAmmo] = 0;
$ItemMax[larmor, StingerAmmo] = 0;
$ItemMax[larmor, FlameAmmo] = 0;

$ItemMax[larmor, EnergyPack] = 0;
$ItemMax[larmor, RepairPack] = 0;
$ItemMax[larmor, ShieldPack] = 0;
$ItemMax[larmor, SensorJammerPack] = 0;
$ItemMax[larmor, MotionSensorPack] = 0;
$ItemMax[larmor, PulseSensorPack] = 0;
$ItemMax[larmor, DeployableSensorJammerPack] = 0;
$ItemMax[larmor, DeployableHealthPack] = 0;
$ItemMax[larmor, CameraPack] = 0;
$ItemMax[larmor, TurretPack] = 0;
$ItemMax[larmor, AmmoPackSmall] = 1;
$ItemMax[larmor, AmmoPackHeavy] = 0;
$ItemMax[larmor, AmmoPackExp] = 0;
$ItemMax[larmor, RepairKit] = 1;
$ItemMax[larmor, DeployableInvPack] = 0;
$ItemMax[larmor, DeployableAmmoPack] = 0;
$ItemMax[larmor, TwentyPack] = 0;
$ItemMax[larmor, HowitzerPack] = 0;
$ItemMax[larmor, SAMPack] = 0;
$ItemMax[larmor, Charge] = 0;
$ItemMax[larmor, AirstrikePack] = 0;
$ItemMax[larmor, GrapplePack] = 0;
$ItemMax[larmor, GrappleHook] = 0;
$ItemMax[larmor, ReloaderPack] = 0;
$ItemMax[larmor, Parachute] = 1;
$ItemMax[larmor, FuelPack] = 0;
$ItemMax[larmor, PortGenPack] = 0;
$ItemMax[larmor, AAPack] = 0;
$ItemMax[larmor, MedicPack] = 0;

$MaxWeapons[larmor] = 1;

// ARTILLERY

$DamageScale[aarmor, $LandingDamageType] = 1.0;
$DamageScale[aarmor, $ImpactDamageType] = 1.0;
$DamageScale[aarmor, $CrushDamageType] = 1.0;
$DamageScale[aarmor, $BulletDamageType] = 1.2;
$DamageScale[aarmor, $PlasmaDamageType] = 1.0;
$DamageScale[aarmor, $EnergyDamageType] = 1.3;
$DamageScale[aarmor, $ExplosionDamageType] = 1.0;
$DamageScale[aarmor, $MissileDamageType] = 1.0;
$DamageScale[aarmor, $DebrisDamageType] = 1.2;
$DamageScale[aarmor, $ShrapnelDamageType] = 1.2;
$DamageScale[aarmor, $LaserDamageType] = 1.0;
$DamageScale[aarmor, $MortarDamageType] = 1.3;
$DamageScale[aarmor, $BlasterDamageType] = 1.3;
$DamageScale[aarmor, $ElectricityDamageType] = 1.0;
$DamageScale[aarmor, $MineDamageType] = 1.2;
$DamageScale[aarmor, $ChargeDamageType] = 1.2;
$DamageScale[aarmor, $AirstrikeDamageType] = 1.0;

//$DamageScale[aarmor, $LandingDamageType] = 1.0;
//$DamageScale[aarmor, $ImpactDamageType] = 1.0;
//$DamageScale[aarmor, $CrushDamageType] = 1.0;
//$DamageScale[aarmor, $BulletDamageType] = 0.6;
//$DamageScale[aarmor, $PlasmaDamageType] = 0.4;
//$DamageScale[aarmor, $EnergyDamageType] = 0.7;
//$DamageScale[aarmor, $ExplosionDamageType] = 0.6;
//$DamageScale[aarmor, $MissileDamageType] = 0.6;
//$DamageScale[aarmor, $DebrisDamageType] = 0.8;
//$DamageScale[aarmor, $ShrapnelDamageType] = 0.8;
//$DamageScale[aarmor, $LaserDamageType] = 0.6;
//$DamageScale[aarmor, $MortarDamageType] = 0.7;
//$DamageScale[aarmor, $BlasterDamageType] = 0.7;
//$DamageScale[aarmor, $ElectricityDamageType] = 1.0;
//$DamageScale[aarmor, $MineDamageType] = 0.8;
//$DamageScale[aarmor, $ChargeDamageType] = 0.8;
//$DamageScale[aarmor, $AirstrikeDamageType] = 1.0;

$ItemMax[aarmor, Blaster] = 0;
$ItemMax[aarmor, Chaingun] = 0;
$ItemMax[aarmor, Disclauncher] = 0;
$ItemMax[aarmor, GrenadeLauncher] = 0;
$ItemMax[aarmor, Mortar] = 0;
$ItemMax[aarmor, PlasmaGun] = 0;
$ItemMax[aarmor, LaserRifle] = 0;
$ItemMax[aarmor, EnergyRifle] = 0;
$ItemMax[aarmor, TargetingLaser] = 1;
$ItemMax[aarmor, MineAmmo] = 3;
$ItemMax[aarmor, Grenade] = 5;
$ItemMax[aarmor, Beacon]  = 3;
$ItemMax[aarmor, SOCOM] = 1;
$ItemMax[aarmor, OICW] = 0;
$ItemMax[aarmor, SAW] = 0;
$ItemMax[aarmor, MP5] = 0;
$ItemMax[aarmor, PSG1] = 0;
$ItemMax[aarmor, FiftyCal] = 0;
$ItemMax[aarmor, LAW] = 0;
$ItemMax[aarmor, AutoShotgun] = 0;
$ItemMax[aarmor, Howitzer] = 0;
$ItemMax[aarmor, Airstrike] = 1;
$ItemMax[aarmor, Stinger] = 0;
$ItemMax[aarmor, Flamethrower] = 0;

$ItemMax[aarmor, BulletAmmo] = 0;
$ItemMax[aarmor, PlasmaAmmo] = 0;
$ItemMax[aarmor, DiscAmmo] = 0;
$ItemMax[aarmor, GrenadeAmmo] = 10;
$ItemMax[aarmor, MortarAmmo] = 10;
$ItemMax[aarmor, SOCOMAmmo] = 50;
$ItemMax[aarmor, OICWAmmo] = 0;
$ItemMax[aarmor, SAWAmmo] = 0;
$ItemMax[aarmor, MP5Ammo] = 0;
$ItemMax[aarmor, PSG1Ammo] = 0;
$ItemMax[aarmor, FiftyCalAmmo] = 0;
$ItemMax[aarmor, LAWAmmo] = 0;
$ItemMax[aarmor, AutoShotgunAmmo] = 0;
$ItemMax[aarmor, HowitzerAmmo] = 0;
$ItemMax[aarmor, Stinger] = 0;
$ItemMax[aarmor, FlameAmmo] = 0;

$ItemMax[aarmor, EnergyPack] = 0;
$ItemMax[aarmor, RepairPack] = 0;
$ItemMax[aarmor, ShieldPack] = 0;
$ItemMax[aarmor, SensorJammerPack] = 0;
$ItemMax[aarmor, MotionSensorPack] = 0;
$ItemMax[aarmor, PulseSensorPack] = 0;
$ItemMax[aarmor, DeployableSensorJammerPack] = 0;
$ItemMax[aarmor, DeployableHealthPack] = 0;
$ItemMax[aarmor, CameraPack] = 0;
$ItemMax[aarmor, TurretPack] = 0;
$ItemMax[aarmor, AmmoPack] = 1;
$ItemMax[aarmor, RepairKit] = 1;
$ItemMax[aarmor, DeployableInvPack] = 0;
$ItemMax[aarmor, DeployableAmmoPack] = 0;
$ItemMax[aarmor, TwentyPack] = 0;
$ItemMax[aarmor, HowitzerPack] = 1;
$ItemMax[aarmor, SAMPack] = 0;
$ItemMax[aarmor, Charge] = 0;
$ItemMax[aarmor, AirstrikePack] = 1;
$ItemMax[aarmor, GrapplePack] = 0;
$ItemMax[aarmor, GrappleHook] = 0;
$ItemMax[aarmor, ReloaderPack] = 1;
$ItemMax[aarmor, Parachute] = 1;
$ItemMax[aarmor, FuelPack] = 0;
$ItemMax[aarmor, PortGenPack] = 0;
$ItemMax[aarmor, AAPack] = 0;
$ItemMax[aarmor, MedicPack] = 0;

$MaxWeapons[aarmor] = 1;

// MEDIC FEMALE

$DamageScale[mfemale, $LandingDamageType] = 1.0;
$DamageScale[mfemale, $ImpactDamageType] = 1.0;
$DamageScale[mfemale, $CrushDamageType] = 1.0;
$DamageScale[mfemale, $BulletDamageType] = 1.2;
$DamageScale[mfemale, $PlasmaDamageType] = 1.0;
$DamageScale[mfemale, $EnergyDamageType] = 1.3;
$DamageScale[mfemale, $ExplosionDamageType] = 1.0;
$DamageScale[mfemale, $MissileDamageType] = 1.0;
$DamageScale[mfemale, $DebrisDamageType] = 1.2;
$DamageScale[mfemale, $ShrapnelDamageType] = 1.2;
$DamageScale[mfemale, $LaserDamageType] = 1.0;
$DamageScale[mfemale, $MortarDamageType] = 1.3;
$DamageScale[mfemale, $BlasterDamageType] = 1.3;
$DamageScale[mfemale, $ElectricityDamageType] = 1.0;
$DamageScale[mfemale, $MineDamageType] = 1.2;
$DamageScale[mfemale, $ChargeDamageType] = 1.2;
$DamageScale[mfemale, $AirstrikeDamageType] = 1.0;

$ItemMax[mfemale, Blaster] = 1;
$ItemMax[mfemale, Chaingun] = 1;
$ItemMax[mfemale, Disclauncher] = 1;
$ItemMax[mfemale, GrenadeLauncher] = 1;
$ItemMax[mfemale, Mortar] = 0;
$ItemMax[mfemale, PlasmaGun] = 1;
$ItemMax[mfemale, LaserRifle] = 1;
$ItemMax[mfemale, EnergyRifle] = 1;
$ItemMax[mfemale, TargetingLaser] = 1;
$ItemMax[mfemale, MineAmmo] = 3;
$ItemMax[mfemale, Grenade] = 5;
$ItemMax[mfemale, Beacon]  = 3;
$ItemMax[mfemale, SOCOM] = 1;
$ItemMax[mfemale, OICW] = 0;
$ItemMax[mfemale, SAW] = 0;
$ItemMax[mfemale, MP5] = 1;
$ItemMax[mfemale, PSG1] = 0;
$ItemMax[mfemale, FiftyCal] = 0;
$ItemMax[mfemale, LAW] = 0;
$ItemMax[mfemale, AutoShotgun] = 0;
$ItemMax[mfemale, Howitzer] = 0;
$ItemMax[mfemale, Airstrike] = 0;
$ItemMax[mfemale, Stinger] = 0;
$ItemMax[mfemale, Flamethrower] = 0;

$ItemMax[mfemale, BulletAmmo] = 100;
$ItemMax[mfemale, PlasmaAmmo] = 30;
$ItemMax[mfemale, DiscAmmo] = 15;
$ItemMax[mfemale, GrenadeAmmo] = 10;
$ItemMax[mfemale, MortarAmmo] = 10;
$ItemMax[mfemale, SOCOMAmmo] = 30;
$ItemMax[mfemale, OICWAmmo] = 0;
$ItemMax[mfemale, SAWAmmo] = 0;
$ItemMax[mfemale, MP5Ammo] = 100;
$ItemMax[mfemale, PSG1Ammo] = 0;
$ItemMax[mfemale, FiftyCalAmmo] = 0;
$ItemMax[mfemale, LAWAmmo] = 0;
$ItemMax[mfemale, AutoShotgunAmmo] = 0;
$ItemMax[mfemale, HowitzerAmmo] = 0;
$ItemMax[mfemale, StingerAmmo] = 0;
$ItemMax[mfemale, FlameAmmo] = 0;

$ItemMax[mfemale, EnergyPack] = 0;
$ItemMax[mfemale, RepairPack] = 0;
$ItemMax[mfemale, ShieldPack] = 0;
$ItemMax[mfemale, SensorJammerPack] = 0;
$ItemMax[mfemale, MotionSensorPack] = 0;
$ItemMax[mfemale, PulseSensorPack] = 0;
$ItemMax[mfemale, DeployableSensorJammerPack] = 0;
$ItemMax[mfemale, DeployableHealthPack] = 1;
$ItemMax[mfemale, CameraPack] = 0;
$ItemMax[mfemale, TurretPack] = 0;
$ItemMax[mfemale, AmmoPackSmall] = 1;
$ItemMax[mfemale, AmmoPackHeavy] = 0;
$ItemMax[mfemale, AmmoPackExp] = 0;
$ItemMax[mfemale, RepairKit] = 1;
$ItemMax[mfemale, DeployableInvPack] = 0;
$ItemMax[mfemale, DeployableAmmoPack] = 0;
$ItemMax[mfemale, TwentyPack] = 0;
$ItemMax[mfemale, HowitzerPack] = 0;
$ItemMax[mfemale, SAMPack] = 0;
$ItemMax[mfemale, Charge] = 0;
$ItemMax[mfemale, AirstrikePack] = 0;
$ItemMax[mfemale, GrapplePack] = 0;
$ItemMax[mfemale, GrappleHook] = 0;
$ItemMax[mfemale, ReloaderPack] = 0;
$ItemMax[mfemale, Parachute] = 1;
$ItemMax[mfemale, FuelPack] = 0;
$ItemMax[mfemale, PortGenPack] = 0;
$ItemMax[mfemale, AAPack] = 0;
$ItemMax[mfemale, MedicPack] = 1;

$MaxWeapons[mfemale] = 2;

// SNIPER FEMALE

$DamageScale[sfemale, $LandingDamageType] = 1.0;
$DamageScale[sfemale, $ImpactDamageType] = 1.0;	
$DamageScale[sfemale, $CrushDamageType] = 1.0;	
$DamageScale[sfemale, $BulletDamageType] = 1.2;
$DamageScale[sfemale, $PlasmaDamageType] = 1.0;
$DamageScale[sfemale, $EnergyDamageType] = 1.3;
$DamageScale[sfemale, $ExplosionDamageType] = 1.0;
$DamageScale[sfemale, $MissileDamageType] = 1.0;
$DamageScale[sfemale, $ShrapnelDamageType] = 1.2;
$DamageScale[sfemale, $DebrisDamageType] = 1.2;
$DamageScale[sfemale, $LaserDamageType] = 1.0;
$DamageScale[sfemale, $MortarDamageType] = 1.3;
$DamageScale[sfemale, $BlasterDamageType] = 1.3;
$DamageScale[sfemale, $ElectricityDamageType] = 1.0;
$DamageScale[sfemale, $MineDamageType] = 1.2;
$DamageScale[sfemale, $ChargeDamageType] = 1.2;
$DamageScale[sfemale, $AirstrikeDamageType] = 1.0;

$ItemMax[sfemale, Blaster] = 1;
$ItemMax[sfemale, Chaingun] = 1;
$ItemMax[sfemale, Disclauncher] = 1;
$ItemMax[sfemale, GrenadeLauncher] = 1;
$ItemMax[sfemale, Mortar] = 0;
$ItemMax[sfemale, PlasmaGun] = 1;
$ItemMax[sfemale, LaserRifle] = 1;
$ItemMax[sfemale, EnergyRifle] = 1;
$ItemMax[sfemale, TargetingLaser] = 1;
$ItemMax[sfemale, MineAmmo] = 3;
$ItemMax[sfemale, Grenade] = 5;
$ItemMax[sfemale, Beacon] = 3;
$ItemMax[sfemale, SOCOM] = 1;
$ItemMax[sfemale, OICW] = 0;
$ItemMax[sfemale, SAW] = 0;
$ItemMax[sfemale, MP5] = 0;
$ItemMax[sfemale, PSG1] = 1;
$ItemMax[sfemale, FiftyCal] = 1;
$ItemMax[sfemale, LAW] = 0;
$ItemMax[sfemale, AutoShotgun] = 0;
$ItemMax[sfemale, Howitzer] = 0;
$ItemMax[sfemale, Airstrike] = 0;
$ItemMax[sfemale, Stinger] = 0;
$ItemMax[sfemale, Flamethrower] = 0;

$ItemMax[sfemale, BulletAmmo] = 100;
$ItemMax[sfemale, PlasmaAmmo] = 30;
$ItemMax[sfemale, DiscAmmo] = 15;
$ItemMax[sfemale, GrenadeAmmo] = 10;
$ItemMax[sfemale, MortarAmmo] = 10;
$ItemMax[sfemale, SOCOMAmmo] = 30;
$ItemMax[sfemale, OICWAmmo] = 0;
$ItemMax[sfemale, SAWAmmo] = 0;
$ItemMax[sfemale, MP5Ammo] = 0;
$ItemMax[sfemale, PSG1Ammo] = 30;
$ItemMax[sfemale, FiftyCalAmmo] = 15;
$ItemMax[sfemale, LAWAmmo] = 0;
$ItemMax[sfemale, AutoShotgunAmmo] = 0;
$ItemMax[sfemale, HowitzerAmmo] = 0;
$ItemMax[sfemale, StingerAmmo] = 0;
$ItemMax[sfemale, FlameAmmo] = 0;

$ItemMax[sfemale, EnergyPack] = 0;
$ItemMax[sfemale, RepairPack] = 0;
$ItemMax[sfemale, ShieldPack] = 0;
$ItemMax[sfemale, SensorJammerPack] = 1;
$ItemMax[sfemale, MotionSensorPack] = 0;
$ItemMax[sfemale, PulseSensorPack] = 0;
$ItemMax[sfemale, DeployableSensorJammerPack] = 0;
$ItemMax[sfemale, DeployableHealthPack] = 0;
$ItemMax[sfemale, CameraPack] = 0;
$ItemMax[sfemale, TurretPack] = 0;
$ItemMax[sfemale, AmmoPackSmall] = 1;
$ItemMax[sfemale, AmmoPackHeavy] = 1;
$ItemMax[sfemale, AmmoPackExp] = 0;
$ItemMax[sfemale, RepairKit] = 1;
$ItemMax[sfemale, DeployableInvPack] = 0;
$ItemMax[sfemale, DeployableAmmoPack] = 0;
$ItemMax[sfemale, TwentyPack] = 0;
$ItemMax[sfemale, HowitzerPack] = 0;
$ItemMax[sfemale, SAMPack] = 0;
$ItemMax[sfemale, Charge] = 0;
$ItemMax[sfemale, AirstrikePack] = 0;
$ItemMax[sfemale, GrapplePack] = 0;
$ItemMax[sfemale, GrappleHook] = 0;
$ItemMax[sfemale, ReloaderPack] = 0;
$ItemMax[sfemale, Parachute] = 1;
$ItemMax[sfemale, FuelPack] = 0;
$ItemMax[sfemale, PortGenPack] = 0;
$ItemMax[sfemale, AAPack] = 0;
$ItemMax[sfemale, MedicPack] = 0;

$MaxWeapons[sfemale] = 1;

// INFANTRY FEMALE

$DamageScale[ifemale, $LandingDamageType] = 1.0;
$DamageScale[ifemale, $ImpactDamageType] = 1.0;
$DamageScale[ifemale, $CrushDamageType] = 1.0;
$DamageScale[ifemale, $BulletDamageType] = 1.0;
$DamageScale[ifemale, $EnergyDamageType] = 1.0;
$DamageScale[ifemale, $PlasmaDamageType] = 0.6;
$DamageScale[ifemale, $ExplosionDamageType] = 1.0;
$DamageScale[ifemale, $MissileDamageType] = 1.0;
$DamageScale[ifemale, $ShrapnelDamageType] = 1.0;
$DamageScale[ifemale, $DebrisDamageType] = 1.0;
$DamageScale[ifemale, $LaserDamageType] = 1.0;
$DamageScale[ifemale, $MortarDamageType] = 1.0;
$DamageScale[ifemale, $BlasterDamageType] = 1.0;
$DamageScale[ifemale, $ElectricityDamageType] = 1.0;
$DamageScale[ifemale, $MineDamageType] = 1.0;
$DamageScale[ifemale, $ChargeDamageType] = 1.0;
$DamageScale[ifemale, $AirstrikeDamageType] = 1.0;

$ItemMax[ifemale, Blaster] = 1;
$ItemMax[ifemale, Chaingun] = 1;
$ItemMax[ifemale, Disclauncher] = 1;
$ItemMax[ifemale, GrenadeLauncher] = 1;
$ItemMax[ifemale, Mortar] = 0;
$ItemMax[ifemale, PlasmaGun] = 1;
$ItemMax[ifemale, LaserRifle] = 0;
$ItemMax[ifemale, EnergyRifle] = 1;
$ItemMax[ifemale, TargetingLaser] = 1;
$ItemMax[ifemale, MineAmmo] = 3;
$ItemMax[ifemale, Grenade] = 3;
$ItemMax[ifemale, Beacon] = 3;
$ItemMax[ifemale, SOCOM] = 1;
$ItemMax[ifemale, OICW] = 1;
$ItemMax[ifemale, SAW] = 1;
$ItemMax[ifemale, MP5] = 0;
$ItemMax[ifemale, PSG1] = 0;
$ItemMax[ifemale, FiftyCal] = 0;
$ItemMax[ifemale, LAW] = 1;
$ItemMax[ifemale, AutoShotgun] = 1;
$ItemMax[ifemale, Howitzer] = 0;
$ItemMax[ifemale, Flamethrower] = 1;
$ItemMax[ifemale, Airstrike] = 0;
$ItemMax[ifemale, Stinger] = 0;

$ItemMax[ifemale, BulletAmmo] = 150;
$ItemMax[ifemale, PlasmaAmmo] = 40;
$ItemMax[ifemale, DiscAmmo] = 15;
$ItemMax[ifemale, GrenadeAmmo] = 10;
$ItemMax[ifemale, MortarAmmo] = 10;
$ItemMax[ifemale, SOCOMAmmo] = 50;
$ItemMax[ifemale, OICWAmmo] = 200;
$ItemMax[ifemale, SAWAmmo] = 400;
$ItemMax[ifemale, MP5Ammo] = 0;
$ItemMax[ifemale, PSG1Ammo] = 0;
$ItemMax[ifemale, FiftyCalAmmo] = 0;
$ItemMax[ifemale, LAWAmmo] = 2;
$ItemMax[ifemale, AutoShotgunAmmo] = 100;
$ItemMax[ifemale, HowitzerAmmo] = 0;
$ItemMax[ifemale, StingerAmmo] = 0;
$ItemMax[ifemale, FlameAmmo] = 150;

$ItemMax[ifemale, EnergyPack] = 0;
$ItemMax[ifemale, RepairPack] = 1;
$ItemMax[ifemale, ShieldPack] = 0;
$ItemMax[ifemale, SensorJammerPack] = 0;
$ItemMax[ifemale, MotionSensorPack] = 0;
$ItemMax[ifemale, PulseSensorPack] = 0;
$ItemMax[ifemale, DeployableSensorJammerPack] = 0;
$ItemMax[ifemale, DeployableHealthPack] = 0;
$ItemMax[ifemale, CameraPack] = 1;
$ItemMax[ifemale, TurretPack] = 0;
$ItemMax[ifemale, AmmoPackSmall] = 1;
$ItemMax[ifemale, AmmoPackHeavy] = 1;
$ItemMax[ifemale, AmmoPackExp] = 1;
$ItemMax[ifemale, RepairKit] = 1;
$ItemMax[ifemale, DeployableInvPack] = 0;
$ItemMax[ifemale, DeployableAmmoPack] = 0;
$ItemMax[ifemale, TwentyPack] = 0;
$ItemMax[ifemale, HowitzerPack] = 0;
$ItemMax[ifemale, SAMPack] = 0;
$ItemMax[ifemale, Charge] = 0;
$ItemMax[ifemale, AirstrikePack] = 0;
$ItemMax[ifemale, GrapplePack] = 0;
$ItemMax[ifemale, GrappleHook] = 0;
$ItemMax[ifemale, ReloaderPack] = 1;
$ItemMax[ifemale, Parachute] = 1;
$ItemMax[ifemale, FuelPack] = 1;
$ItemMax[ifemale, PortGenPack] = 1;
$ItemMax[ifemale, AAPack] = 0;
$ItemMax[ifemale, MedicPack] = 0;

$MaxWeapons[ifemale] = 2;

// SPECOPS FEMALE

$DamageScale[cfemale, $LandingDamageType] = 1.0;
$DamageScale[cfemale, $ImpactDamageType] = 1.0;	
$DamageScale[cfemale, $CrushDamageType] = 1.0;	
$DamageScale[cfemale, $BulletDamageType] = 1.2;
$DamageScale[cfemale, $PlasmaDamageType] = 1.0;
$DamageScale[cfemale, $EnergyDamageType] = 1.3;
$DamageScale[cfemale, $ExplosionDamageType] = 1.0;
$DamageScale[cfemale, $MissileDamageType] = 1.0;
$DamageScale[cfemale, $ShrapnelDamageType] = 1.2;
$DamageScale[cfemale, $DebrisDamageType] = 1.2;
$DamageScale[cfemale, $LaserDamageType] = 1.0;
$DamageScale[cfemale, $MortarDamageType] = 1.3;
$DamageScale[cfemale, $BlasterDamageType] = 1.3;
$DamageScale[cfemale, $ElectricityDamageType] = 1.0;
$DamageScale[cfemale, $MineDamageType] = 1.2;
$DamageScale[cfemale, $ChargeDamageType] = 1.2;
$DamageScale[cfemale, $AirstrikeDamageType] = 1.0;

$ItemMax[cfemale, Blaster] = 1;
$ItemMax[cfemale, Chaingun] = 1;
$ItemMax[cfemale, Disclauncher] = 1;
$ItemMax[cfemale, GrenadeLauncher] = 1;
$ItemMax[cfemale, Mortar] = 0;
$ItemMax[cfemale, PlasmaGun] = 1;
$ItemMax[cfemale, LaserRifle] = 1;
$ItemMax[cfemale, EnergyRifle] = 1;
$ItemMax[cfemale, TargetingLaser] = 1;
$ItemMax[cfemale, MineAmmo] = 3;
$ItemMax[cfemale, Grenade] = 5;
$ItemMax[cfemale, Beacon] = 3;
$ItemMax[cfemale, SOCOM] = 1;
$ItemMax[cfemale, OICW] = 0;
$ItemMax[cfemale, SAW] = 0;
$ItemMax[cfemale, MP5] = 1;
$ItemMax[cfemale, PSG1] = 0;
$ItemMax[cfemale, FiftyCal] = 0;
$ItemMax[cfemale, LAW] = 0;
$ItemMax[cfemale, AutoShotgun] = 0;
$ItemMax[cfemale, Howitzer] = 0;
$ItemMax[cfemale, Airstrike] = 1;
$ItemMax[cfemale, Stinger] = 1;
$ItemMax[cfemale, Flamethrower] = 0;

$ItemMax[cfemale, BulletAmmo] = 100;
$ItemMax[cfemale, PlasmaAmmo] = 30;
$ItemMax[cfemale, DiscAmmo] = 15;
$ItemMax[cfemale, GrenadeAmmo] = 10;
$ItemMax[cfemale, MortarAmmo] = 10;
$ItemMax[cfemale, SOCOMAmmo] = 50;
$ItemMax[cfemale, OICWAmmo] = 0;
$ItemMax[cfemale, SAWAmmo] = 0;
$ItemMax[cfemale, MP5Ammo] = 200;
$ItemMax[cfemale, PSG1Ammo] = 0;
$ItemMax[cfemale, FiftyCalAmmo] = 0;
$ItemMax[cfemale, LAWAmmo] = 0;
$ItemMax[cfemale, AutoShotgunAmmo] = 0;
$ItemMax[cfemale, HowitzerAmmo] = 0;
$ItemMax[cfemale, StingerAmmo] = 2;
$ItemMax[cfemale, FlameAmmo] = 0;

$ItemMax[cfemale, EnergyPack] = 0;
$ItemMax[cfemale, RepairPack] = 0;
$ItemMax[cfemale, ShieldPack] = 0;
$ItemMax[cfemale, SensorJammerPack] = 1;
$ItemMax[cfemale, MotionSensorPack] = 0;
$ItemMax[cfemale, PulseSensorPack] = 0;
$ItemMax[cfemale, DeployableSensorJammerPack] = 1;
$ItemMax[cfemale, DeployableHealthPack] = 0;
$ItemMax[cfemale, CameraPack] = 1;
$ItemMax[cfemale, TurretPack] = 0;
$ItemMax[cfemale, AmmoPackSmall] = 1;
$ItemMax[cfemale, AmmoPackHeavy] = 0;
$ItemMax[cfemale, AmmoPackExp] = 1;
$ItemMax[cfemale, RepairKit] = 1;
$ItemMax[cfemale, DeployableInvPack] = 0;
$ItemMax[cfemale, DeployableAmmoPack] = 0;
$ItemMax[cfemale, TwentyPack] = 0;
$ItemMax[cfemale, HowitzerPack] = 0;
$ItemMax[cfemale, SAMPack] = 0;
$ItemMax[cfemale, Charge] = 1;
$ItemMax[cfemale, AirstrikePack] = 1;
$ItemMax[cfemale, GrapplePack] = 1;
$ItemMax[cfemale, GrappleHook] = 1;
$ItemMax[cfemale, ReloaderPack] = 1;
$ItemMax[cfemale, Parachute] = 1;
$ItemMax[cfemale, FuelPack] = 0;
$ItemMax[cfemale, PortGenPack] = 0;
$ItemMax[cfemale, AAPack] = 0;
$ItemMax[cfemale, MedicPack] = 0;

$MaxWeapons[cfemale] = 3;

// ENGINEER FEMALE

$DamageScale[efemale, $LandingDamageType] = 1.0;
$DamageScale[efemale, $ImpactDamageType] = 1.0;
$DamageScale[efemale, $CrushDamageType] = 1.0;
$DamageScale[efemale, $BulletDamageType] = 1.0;
$DamageScale[efemale, $EnergyDamageType] = 1.0;
$DamageScale[efemale, $PlasmaDamageType] = 0.6;
$DamageScale[efemale, $ExplosionDamageType] = 1.0;
$DamageScale[efemale, $MissileDamageType] = 1.0;
$DamageScale[efemale, $ShrapnelDamageType] = 1.0;
$DamageScale[efemale, $DebrisDamageType] = 1.0;
$DamageScale[efemale, $LaserDamageType] = 1.0;
$DamageScale[efemale, $MortarDamageType] = 1.0;
$DamageScale[efemale, $BlasterDamageType] = 1.0;
$DamageScale[efemale, $ElectricityDamageType] = 1.0;
$DamageScale[efemale, $MineDamageType] = 1.0;
$DamageScale[efemale, $ChargeDamageType] = 1.0;
$DamageScale[efemale, $AirstrikeDamageType] = 1.0;

$ItemMax[efemale, Blaster] = 1;
$ItemMax[efemale, Chaingun] = 1;
$ItemMax[efemale, Disclauncher] = 1;
$ItemMax[efemale, GrenadeLauncher] = 1;
$ItemMax[efemale, Mortar] = 0;
$ItemMax[efemale, PlasmaGun] = 1;
$ItemMax[efemale, LaserRifle] = 0;
$ItemMax[efemale, EnergyRifle] = 1;
$ItemMax[efemale, TargetingLaser] = 1;
$ItemMax[efemale, MineAmmo] = 3;
$ItemMax[efemale, Grenade] = 6;
$ItemMax[efemale, Beacon] = 3;
$ItemMax[efemale, SOCOM] = 1;
$ItemMax[efemale, OICW] = 1;
$ItemMax[efemale, SAW] = 0;
$ItemMax[efemale, MP5] = 0;
$ItemMax[efemale, PSG1] = 0;
$ItemMax[efemale, FiftyCal] = 0;
$ItemMax[efemale, LAW] = 0;
$ItemMax[efemale, AutoShotgun] = 1;
$ItemMax[efemale, Howitzer] = 0;
$ItemMax[efemale, Airstrike] = 0;
$ItemMax[efemale, Stinger] = 0;
$ItemMax[efemale, Flamethrower] = 0;

$ItemMax[efemale, BulletAmmo] = 150;
$ItemMax[efemale, PlasmaAmmo] = 40;
$ItemMax[efemale, DiscAmmo] = 15;
$ItemMax[efemale, GrenadeAmmo] = 10;
$ItemMax[efemale, MortarAmmo] = 10;
$ItemMax[efemale, SOCOMAmmo] = 50;
$ItemMax[efemale, OICWAmmo] = 100;
$ItemMax[efemale, SAWAmmo] = 0;
$ItemMax[efemale, MP5Ammo] = 0;
$ItemMax[efemale, PSG1Ammo] = 0;
$ItemMax[efemale, FiftyCalAmmo] = 0;
$ItemMax[efemale, LAWAmmo] = 0;
$ItemMax[efemale, AutoShotgunAmmo] = 75;
$ItemMax[efemale, HowitzerAmmo] = 0;
$ItemMax[efemale, StingerAmmo] = 0;
$ItemMax[efemale, FlameAmmo] = 0;

$ItemMax[efemale, EnergyPack] = 0;
$ItemMax[efemale, RepairPack] = 1;
$ItemMax[efemale, ShieldPack] = 0;
$ItemMax[efemale, SensorJammerPack] = 1;
$ItemMax[efemale, MotionSensorPack] = 1;
$ItemMax[efemale, PulseSensorPack] = 1;
$ItemMax[efemale, DeployableSensorJammerPack] = 1;
$ItemMax[efemale, DeployableHealthPack] = 0;
$ItemMax[efemale, CameraPack] = 1;
$ItemMax[efemale, TurretPack] = 1;
$ItemMax[efemale, AmmoPackSmall] = 1;
$ItemMax[efemale, AmmoPackHeavy] = 1;
$ItemMax[efemale, AmmoPackExp] = 0;
$ItemMax[efemale, RepairKit] = 1;
$ItemMax[efemale, DeployableInvPack] = 1;
$ItemMax[efemale, DeployableAmmoPack] = 1;
$ItemMax[efemale, TwentyPack] = 1;
$ItemMax[efemale, HowitzerPack] = 1;
$ItemMax[efemale, SAMPack] = 1;
$ItemMax[efemale, Charge] = 0;
$ItemMax[efemale, AirstrikePack] = 0;
$ItemMax[efemale, GrapplePack] = 0;
$ItemMax[efemale, GrappleHook] = 0;
$ItemMax[efemale, ReloaderPack] = 1;
$ItemMax[efemale, Parachute] = 1;
$ItemMax[efemale, FuelPack] = 0;
$ItemMax[efemale, PortGenPack] = 1;
$ItemMax[efemale, AAPack] = 1;
$ItemMax[efemale, MedicPack] = 0;

$MaxWeapons[efemale] = 2;

// PILOT FEMALE

$DamageScale[lfemale, $LandingDamageType] = 1.0;
$DamageScale[lfemale, $ImpactDamageType] = 1.0;	
$DamageScale[lfemale, $CrushDamageType] = 1.0;	
$DamageScale[lfemale, $BulletDamageType] = 1.2;
$DamageScale[lfemale, $PlasmaDamageType] = 1.0;
$DamageScale[lfemale, $EnergyDamageType] = 1.3;
$DamageScale[lfemale, $ExplosionDamageType] = 1.0;
$DamageScale[lfemale, $MissileDamageType] = 1.0;
$DamageScale[lfemale, $ShrapnelDamageType] = 1.2;
$DamageScale[lfemale, $DebrisDamageType] = 1.2;
$DamageScale[lfemale, $LaserDamageType] = 1.0;
$DamageScale[lfemale, $MortarDamageType] = 1.3;
$DamageScale[lfemale, $BlasterDamageType] = 1.3;
$DamageScale[lfemale, $ElectricityDamageType] = 1.0;
$DamageScale[lfemale, $MineDamageType] = 1.2;
$DamageScale[lfemale, $ChargeDamageType] = 1.2;
$DamageScale[lfemale, $AirstrikeDamageType] = 1.0;

$ItemMax[lfemale, Blaster] = 1;
$ItemMax[lfemale, Chaingun] = 1;
$ItemMax[lfemale, Disclauncher] = 1;
$ItemMax[lfemale, GrenadeLauncher] = 1;
$ItemMax[lfemale, Mortar] = 0;
$ItemMax[lfemale, PlasmaGun] = 1;
$ItemMax[lfemale, LaserRifle] = 1;
$ItemMax[lfemale, EnergyRifle] = 1;
$ItemMax[lfemale, TargetingLaser] = 1;
$ItemMax[lfemale, MineAmmo] = 0;
$ItemMax[lfemale, Grenade] = 2;
$ItemMax[lfemale, Beacon] = 3;
$ItemMax[lfemale, SOCOM] = 1;
$ItemMax[lfemale, OICW] = 0;
$ItemMax[lfemale, SAW] = 0;
$ItemMax[lfemale, MP5] = 0;
$ItemMax[lfemale, PSG1] = 0;
$ItemMax[lfemale, FiftyCal] = 0;
$ItemMax[lfemale, LAW] = 0;
$ItemMax[lfemale, AutoShotgun] = 0;
$ItemMax[lfemale, Howitzer] = 0;
$ItemMax[lfemale, Airstrike] = 0;
$ItemMax[lfemale, Stinger] = 0;
$ItemMax[lfemale, Flamethrower] = 0;

$ItemMax[lfemale, BulletAmmo] = 100;
$ItemMax[lfemale, PlasmaAmmo] = 30;
$ItemMax[lfemale, DiscAmmo] = 15;
$ItemMax[lfemale, GrenadeAmmo] = 10;
$ItemMax[lfemale, MortarAmmo] = 10;
$ItemMax[lfemale, SOCOMAmmo] = 50;
$ItemMax[lfemale, OICWAmmo] = 0;
$ItemMax[lfemale, SAWAmmo] = 0;
$ItemMax[lfemale, MP5Ammo] = 0;
$ItemMax[lfemale, PSG1Ammo] = 0;
$ItemMax[lfemale, FiftyCalAmmo] = 0;
$ItemMax[lfemale, LAWAmmo] = 0;
$ItemMax[lfemale, AutoShotgunAmmo] = 0;
$ItemMax[lfemale, HowitzerAmmo] = 0;
$ItemMax[lfemale, StingerAmmo] = 0;
$ItemMax[lfemale, FlameAmmo] = 0;

$ItemMax[lfemale, EnergyPack] = 0;
$ItemMax[lfemale, RepairPack] = 0;
$ItemMax[lfemale, ShieldPack] = 0;
$ItemMax[lfemale, SensorJammerPack] = 0;
$ItemMax[lfemale, MotionSensorPack] = 0;
$ItemMax[lfemale, PulseSensorPack] = 0;
$ItemMax[lfemale, DeployableSensorJammerPack] = 0;
$ItemMax[lfemale, DeployableHealthPack] = 0;
$ItemMax[lfemale, CameraPack] = 0;
$ItemMax[lfemale, TurretPack] = 0;
$ItemMax[lfemale, AmmoPackSmall] = 1;
$ItemMax[lfemale, AmmoPackHeavy] = 0;
$ItemMax[lfemale, AmmoPackExp] = 0;
$ItemMax[lfemale, RepairKit] = 1;
$ItemMax[lfemale, DeployableInvPack] = 0;
$ItemMax[lfemale, DeployableAmmoPack] = 0;
$ItemMax[lfemale, TwentyPack] = 0;
$ItemMax[lfemale, HowitzerPack] = 0;
$ItemMax[lfemale, SAMPack] = 0;
$ItemMax[lfemale, Charge] = 0;
$ItemMax[lfemale, AirstrikePack] = 0;
$ItemMax[lfemale, GrapplePack] = 0;
$ItemMax[lfemale, GrappleHook] = 0;
$ItemMax[lfemale, ReloaderPack] = 0;
$ItemMax[lfemale, Parachute] = 1;
$ItemMax[lfemale, FuelPack] = 0;
$ItemMax[lfemale, PortGenPack] = 0;
$ItemMax[lfemale, AAPack] = 0;
$ItemMax[lfemale, MedicPack] = 0;

$MaxWeapons[lfemale] = 1;

// ARTILLERY FEMALE

$DamageScale[afemale, $LandingDamageType] = 1.0;
$DamageScale[afemale, $ImpactDamageType] = 1.0;
$DamageScale[afemale, $CrushDamageType] = 1.0;
$DamageScale[afemale, $BulletDamageType] = 1.2;
$DamageScale[afemale, $PlasmaDamageType] = 1.0;
$DamageScale[afemale, $EnergyDamageType] = 1.3;
$DamageScale[afemale, $ExplosionDamageType] = 1.0;
$DamageScale[afemale, $MissileDamageType] = 1.0;
$DamageScale[afemale, $DebrisDamageType] = 1.2;
$DamageScale[afemale, $ShrapnelDamageType] = 1.2;
$DamageScale[afemale, $LaserDamageType] = 1.0;
$DamageScale[afemale, $MortarDamageType] = 1.3;
$DamageScale[afemale, $BlasterDamageType] = 1.3;
$DamageScale[afemale, $ElectricityDamageType] = 1.0;
$DamageScale[afemale, $MineDamageType] = 1.2;
$DamageScale[afemale, $ChargeDamageType] = 1.2;
$DamageScale[afemale, $AirstrikeDamageType] = 1.0;

//$DamageScale[afemale, $LandingDamageType] = 1.0;
//$DamageScale[afemale, $ImpactDamageType] = 1.0;
//$DamageScale[afemale, $CrushDamageType] = 1.0;
//$DamageScale[afemale, $BulletDamageType] = 0.6;
//$DamageScale[afemale, $PlasmaDamageType] = 0.4;
//$DamageScale[afemale, $EnergyDamageType] = 0.7;
//$DamageScale[afemale, $ExplosionDamageType] = 0.6;
//$DamageScale[afemale, $MissileDamageType] = 0.6;
//$DamageScale[afemale, $DebrisDamageType] = 0.8;
//$DamageScale[afemale, $ShrapnelDamageType] = 0.8;
//$DamageScale[afemale, $LaserDamageType] = 0.6;
//$DamageScale[afemale, $MortarDamageType] = 0.7;
//$DamageScale[afemale, $BlasterDamageType] = 0.7;
//$DamageScale[afemale, $ElectricityDamageType] = 1.0;
//$DamageScale[afemale, $MineDamageType] = 0.8;
//$DamageScale[afemale, $ChargeDamageType] = 0.8;
//$DamageScale[afemale, $AirstrikeDamageType] = 1.0;

$ItemMax[afemale, Blaster] = 0;
$ItemMax[afemale, Chaingun] = 0;
$ItemMax[afemale, Disclauncher] = 0;
$ItemMax[afemale, GrenadeLauncher] = 0;
$ItemMax[afemale, Mortar] = 0;
$ItemMax[afemale, PlasmaGun] = 0;
$ItemMax[afemale, LaserRifle] = 0;
$ItemMax[afemale, EnergyRifle] = 0;
$ItemMax[afemale, TargetingLaser] = 1;
$ItemMax[afemale, MineAmmo] = 3;
$ItemMax[afemale, Grenade] = 5;
$ItemMax[afemale, Beacon]  = 3;
$ItemMax[afemale, SOCOM] = 1;
$ItemMax[afemale, OICW] = 0;
$ItemMax[afemale, SAW] = 0;
$ItemMax[afemale, MP5] = 0;
$ItemMax[afemale, PSG1] = 0;
$ItemMax[afemale, FiftyCal] = 0;
$ItemMax[afemale, LAW] = 0;
$ItemMax[afemale, AutoShotgun] = 0;
$ItemMax[afemale, Howitzer] = 0;
$ItemMax[afemale, Airstrike] = 1;
$ItemMax[afemale, Stinger] = 0;
$ItemMax[afemale, Flamethrower] = 0;

$ItemMax[afemale, BulletAmmo] = 0;
$ItemMax[afemale, PlasmaAmmo] = 0;
$ItemMax[afemale, DiscAmmo] = 0;
$ItemMax[afemale, GrenadeAmmo] = 10;
$ItemMax[afemale, MortarAmmo] = 10;
$ItemMax[afemale, SOCOMAmmo] = 50;
$ItemMax[afemale, OICWAmmo] = 0;
$ItemMax[afemale, SAWAmmo] = 0;
$ItemMax[afemale, MP5Ammo] = 0;
$ItemMax[afemale, PSG1Ammo] = 0;
$ItemMax[afemale, FiftyCalAmmo] = 0;
$ItemMax[afemale, LAWAmmo] = 0;
$ItemMax[afemale, AutoShotgunAmmo] = 0;
$ItemMax[afemale, HowitzerAmmo] = 0;
$ItemMax[afemale, Stinger] = 0;
$ItemMax[afemale, FlameAmmo] = 0;

$ItemMax[afemale, EnergyPack] = 0;
$ItemMax[afemale, RepairPack] = 0;
$ItemMax[afemale, ShieldPack] = 0;
$ItemMax[afemale, SensorJammerPack] = 0;
$ItemMax[afemale, MotionSensorPack] = 0;
$ItemMax[afemale, PulseSensorPack] = 0;
$ItemMax[afemale, DeployableSensorJammerPack] = 0;
$ItemMax[afemale, DeployableHealthPack] = 0;
$ItemMax[afemale, CameraPack] = 0;
$ItemMax[afemale, TurretPack] = 0;
$ItemMax[afemale, AmmoPack] = 1;
$ItemMax[afemale, RepairKit] = 1;
$ItemMax[afemale, DeployableInvPack] = 0;
$ItemMax[afemale, DeployableAmmoPack] = 0;
$ItemMax[afemale, TwentyPack] = 0;
$ItemMax[afemale, HowitzerPack] = 1;
$ItemMax[afemale, SAMPack] = 0;
$ItemMax[afemale, Charge] = 0;
$ItemMax[afemale, AirstrikePack] = 1;
$ItemMax[afemale, GrapplePack] = 0;
$ItemMax[afemale, GrappleHook] = 0;
$ItemMax[afemale, ReloaderPack] = 1;
$ItemMax[afemale, Parachute] = 1;
$ItemMax[afemale, FuelPack] = 0;
$ItemMax[afemale, PortGenPack] = 0;
$ItemMax[afemale, AAPack] = 0;
$ItemMax[afemale, MedicPack] = 0;

$MaxWeapons[afemale] = 1;


// MEDIC

PlayerData marmor
{
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

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0.0;
   minJetEnergy = 200;
   jetForce = 0;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 12;
	damageScale = 0.01;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
   animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

// SNIPER

PlayerData sarmor
{
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

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0.0;
   minJetEnergy = 200;
   jetForce = 0;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 12;
	damageScale = 0.01;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
   animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

// INFANTRY

PlayerData iarmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = true;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 200;
   jetForce = 0;
   jetEnergyDrain = 0.0;

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

	minDamageSpeed = 12;
	damageScale = 0.01;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

// SPECOPS

PlayerData carmor
{
   className = "Armor";
   shapeFile = "larmor";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 200;
   jetForce = 0;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 12;
	damageScale = 0.01;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

// ENGINEER

PlayerData earmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = true;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 200;
   jetForce = 0;
   jetEnergyDrain = 0.0;

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

	minDamageSpeed = 12;
	damageScale = 0.01;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

// PILOT

PlayerData larmor
{
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

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 200;
   jetForce = 0;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 12;
	damageScale = 0.01;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
   animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

// ARTILLERY

PlayerData aarmor
{
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

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0.0;
   minJetEnergy = 200;
   jetForce = 0;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 12;
	damageScale = 0.01;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
   animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

// MEDIC FEMALE

PlayerData mfemale
{
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
   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 200;
   jetForce = 0;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 12;
	damageScale = 0.01;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

// SNIPER FEMALE

PlayerData sfemale
{
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
   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 200;
   jetForce = 0;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 12;
	damageScale = 0.01;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

// INFANTRY FEMALE

PlayerData ifemale
{
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

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 200;
   jetForce = 0;
   jetEnergyDrain = 0.0;

   canCrouch = true;
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

	minDamageSpeed = 12;
	damageScale = 0.01;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

// SPECOPS FEMALE

PlayerData cfemale
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 200;
   jetForce = 0;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 12;
	damageScale = 0.01;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

// ENGINEER FEMALE

PlayerData efemale
{
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

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 200;
   jetForce = 0;
   jetEnergyDrain = 0.0;

   canCrouch = true;
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

	minDamageSpeed = 12;
	damageScale = 0.01;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

// PILOT FEMALE

PlayerData lfemale
{
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
   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 200;
   jetForce = 0;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 12;
	damageScale = 0.01;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

// ARTILLERY FEMALE

PlayerData afemale
{
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
   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 200;
   jetForce = 0;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 12;
	damageScale = 0.01;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

// END DELTA FORCE ARMOR
// ----------------------------------------------------
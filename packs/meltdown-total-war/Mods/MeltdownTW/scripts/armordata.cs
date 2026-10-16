//PORT-OFF: $ModList = "Meltdown Total War";

SoundData SoundF1PlayerDeath
{
   wavFileName = "female4.wdeath.wav";
   profile = Profile3dNear;
};

SoundData SoundF2PlayerDeath
{
   wavFileName = "female3.wdeath.wav";
   profile = Profile3dNear;
};

SoundData SoundF3PlayerDeath
{
   wavFileName = "female5.wdeath.wav";
   profile = Profile3dNear;
};

SoundData SoundF4PlayerDeath
{
   wavFileName = "female2.wdeath.wav";
   profile = Profile3dNear;
};

SoundData SoundF5PlayerDeath
{
   wavFileName = "female5.wdsgst4.wav";
   profile = Profile3dNear;
};

SoundData SoundM1PlayerDeath
{
   wavFileName = "male1.wdsgst4.wav";
   profile = Profile3dNear;
};

SoundData SoundM2PlayerDeath
{
   wavFileName = "male3.wdsgst4.wav";
   profile = Profile3dNear;
};

SoundData SoundM3PlayerDeath
{
   wavFileName = "male5.wdsgst4.wav";
   profile = Profile3dNear;
};

SoundData SoundM4PlayerDeath
{
   wavFileName = "male2.wdsgst4.wav";
   profile = Profile3dNear;
};

SoundData SoundM5PlayerDeath
{
   wavFileName = "male4.wdsgst4.wav";
   profile = Profile3dNear;
};

//----------------------------------------------------------------------------
// Light Armor
//----------------------------------------------------------------------------

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

$ItemMax[larmor, Blaster] = 1;
$ItemMax[larmor, Chaingun] = 1;
$ItemMax[larmor, Disclauncher] = 1;
$ItemMax[larmor, GrenadeLauncher] = 1;
$ItemMax[larmor, MrpgLauncher] = 0;
$ItemMax[larmor, Mortar] = 1;
$ItemMax[larmor, PlasmaGun] = 1;
$ItemMax[larmor, LaserRifle] = 1;
$ItemMax[larmor, EnergyRifle] = 1;
$ItemMax[larmor, TargetingLaser] = 1;
$ItemMax[larmor, MineAmmo] = 2;
$ItemMax[larmor, Grenade] = 2;
$ItemMax[larmor, Beacon]  = 2;

$ItemMax[larmor, BulletAmmo] = 200;
$ItemMax[larmor, PlasmaAmmo] = 50;
$ItemMax[larmor, DiscAmmo] = 40;
$ItemMax[larmor, GrenadeAmmo] = 30;
$ItemMax[larmor, MortarAmmo] = 4;

$ItemMax[larmor, EnergyPack] = 1;
$ItemMax[larmor, RepairPack] = 1;
$ItemMax[larmor, ShieldPack] = 1;
$ItemMax[larmor, SensorJammerPack] = 1;
$ItemMax[larmor, MotionSensorPack] = 1;
$ItemMax[larmor, PulseSensorPack] = 1;
$ItemMax[larmor, DeployableSensorJammerPack] = 1;
$ItemMax[larmor, CameraPack] = 1;
$ItemMax[larmor, TurretPack] = 0;
$ItemMax[larmor, AmmoPack] = 1;
$ItemMax[larmor, RepairKit] = 1;
$ItemMax[larmor, DeployableInvPack] = 0;
$ItemMax[larmor, DeployableAmmoPack] = 0;

$MaxWeapons[larmor] = 6;

//----------------------------------------------------------------------------
// Medium Armor
//----------------------------------------------------------------------------
$DamageScale[marmor, $LandingDamageType] = 1.0;
$DamageScale[marmor, $ImpactDamageType] = 1.0;
$DamageScale[marmor, $CrushDamageType] = 1.0;
$DamageScale[marmor, $BulletDamageType] = 1.0;
$DamageScale[marmor, $PlasmaDamageType] = 0.6;
$DamageScale[marmor, $EnergyDamageType] = 1.0;
$DamageScale[marmor, $ExplosionDamageType] = 1.0;
$DamageScale[marmor, $MissileDamageType] = 1.0;
$DamageScale[marmor, $ShrapnelDamageType] = 1.0;
$DamageScale[marmor, $DebrisDamageType] = 1.0;
$DamageScale[marmor, $LaserDamageType] = 1.0;
$DamageScale[marmor, $MortarDamageType] = 1.0;
$DamageScale[marmor, $BlasterDamageType] = 1.0;
$DamageScale[marmor, $ElectricityDamageType] = 1.0;
$DamageScale[marmor, $MineDamageType] = 1.0;

$ItemMax[marmor, Blaster] = 1;
$ItemMax[marmor, Chaingun] = 1;
$ItemMax[marmor, Disclauncher] = 1;
$ItemMax[marmor, GrenadeLauncher] = 1;
$ItemMax[marmor, MrpgLauncher] = 0;
$ItemMax[marmor, Mortar] = 1;
$ItemMax[marmor, PlasmaGun] = 1;
$ItemMax[marmor, LaserRifle] = 0;
$ItemMax[marmor, EnergyRifle] = 1;
$ItemMax[marmor, TargetingLaser] = 1;
$ItemMax[marmor, MineAmmo] = 3;
$ItemMax[marmor, Grenade] = 3;
$ItemMax[marmor, Beacon] = 3;

$ItemMax[marmor, BulletAmmo] = 250;
$ItemMax[marmor, PlasmaAmmo] = 50;
$ItemMax[marmor, DiscAmmo] = 40;
$ItemMax[marmor, GrenadeAmmo] = 30;
$ItemMax[marmor, MortarAmmo] = 6;

$ItemMax[marmor, EnergyPack] = 1;
$ItemMax[marmor, RepairPack] = 1;
$ItemMax[marmor, ShieldPack] = 1;
$ItemMax[marmor, SensorJammerPack] = 1;
$ItemMax[marmor, MotionSensorPack] = 1;
$ItemMax[marmor, PulseSensorPack] = 1;
$ItemMax[marmor, DeployableSensorJammerPack] = 1;
$ItemMax[marmor, CameraPack] = 1;
$ItemMax[marmor, TurretPack] = 1;
$ItemMax[marmor, AmmoPack] = 1;
$ItemMax[marmor, RepairKit] = 1;
$ItemMax[marmor, DeployableInvPack] = 1;
$ItemMax[marmor, DeployableAmmoPack] = 1;

$MaxWeapons[marmor] = 7;

//----------------------------------------------------------------------------
// Heavy Armor
//----------------------------------------------------------------------------
$DamageScale[harmor, $LandingDamageType] = 1.0;
$DamageScale[harmor, $ImpactDamageType] = 1.0;
$DamageScale[harmor, $CrushDamageType] = 1.0;
$DamageScale[harmor, $BulletDamageType] = 0.6;
$DamageScale[harmor, $PlasmaDamageType] = 0.4;
$DamageScale[harmor, $EnergyDamageType] = 0.7;
$DamageScale[harmor, $ExplosionDamageType] = 0.6;
$DamageScale[harmor, $MissileDamageType] = 0.6;
$DamageScale[harmor, $DebrisDamageType] = 0.8;
$DamageScale[harmor, $ShrapnelDamageType] = 0.8;
$DamageScale[harmor, $LaserDamageType] = 0.6;
$DamageScale[harmor, $MortarDamageType] = 0.7;
$DamageScale[harmor, $BlasterDamageType] = 0.7;
$DamageScale[harmor, $ElectricityDamageType] = 1.0;
$DamageScale[harmor, $MineDamageType] = 0.8;

$ItemMax[harmor, Blaster] = 1;
$ItemMax[harmor, Chaingun] = 1;
$ItemMax[harmor, Disclauncher] = 1;
$ItemMax[harmor, GrenadeLauncher] = 1;
$ItemMax[harmor, MrpgLauncher] = 1;
$ItemMax[harmor, Mortar] = 1;
$ItemMax[harmor, PlasmaGun] = 1;
$ItemMax[harmor, LaserRifle] = 0;
$ItemMax[harmor, EnergyRifle] = 1;
$ItemMax[harmor, TargetingLaser] = 1;
$ItemMax[harmor, MineAmmo] = 4;
$ItemMax[harmor, Grenade] = 4;
$ItemMax[harmor, Beacon] = 4;

$ItemMax[harmor, BulletAmmo] = 300;
$ItemMax[harmor, PlasmaAmmo] = 70;
$ItemMax[harmor, DiscAmmo] = 40;
$ItemMax[harmor, GrenadeAmmo] = 30;
$ItemMax[harmor, MortarAmmo] = 15;

$ItemMax[harmor, EnergyPack] = 1;
$ItemMax[harmor, RepairPack] = 1;
$ItemMax[harmor, ShieldPack] = 1;
$ItemMax[harmor, SensorJammerPack] = 1;
$ItemMax[harmor, MotionSensorPack] = 1;
$ItemMax[harmor, PulseSensorPack] = 1;
$ItemMax[harmor, DeployableSensorJammerPack] = 1;
$ItemMax[harmor, CameraPack] = 1;
$ItemMax[harmor, TurretPack] = 1;
$ItemMax[harmor, AmmoPack] = 1;
$ItemMax[harmor, RepairKit] = 1;
$ItemMax[harmor, DeployableInvPack] = 1;
$ItemMax[harmor, DeployableAmmoPack] = 1;

$MaxWeapons[harmor] = 11;

//----------------------------------------------------------------------------
// light Female Armor
//----------------------------------------------------------------------------
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

$ItemMax[lfemale, Blaster] = 1;
$ItemMax[lfemale, Chaingun] = 1;
$ItemMax[lfemale, Disclauncher] = 1;
$ItemMax[lfemale, GrenadeLauncher] = 1;
$ItemMax[lfemale, MrpgLauncher] = 0;
$ItemMax[lfemale, Mortar] = 1;
$ItemMax[lfemale, PlasmaGun] = 1;
$ItemMax[lfemale, LaserRifle] = 1;
$ItemMax[lfemale, EnergyRifle] = 1;
$ItemMax[lfemale, TargetingLaser] = 1;
$ItemMax[lfemale, MineAmmo] = 2;
$ItemMax[lfemale, Grenade] = 2;
$ItemMax[lfemale, Beacon] = 2;

$ItemMax[lfemale, BulletAmmo] = 200;
$ItemMax[lfemale, PlasmaAmmo] = 50;
$ItemMax[lfemale, DiscAmmo] = 40;
$ItemMax[lfemale, GrenadeAmmo] = 30;
$ItemMax[lfemale, MortarAmmo] = 4;

$ItemMax[lfemale, EnergyPack] = 1;
$ItemMax[lfemale, RepairPack] = 1;
$ItemMax[lfemale, ShieldPack] = 1;
$ItemMax[lfemale, SensorJammerPack] = 1;
$ItemMax[lfemale, MotionSensorPack] = 1;
$ItemMax[lfemale, PulseSensorPack] = 1;
$ItemMax[lfemale, DeployableSensorJammerPack] = 1;
$ItemMax[lfemale, CameraPack] = 1;
$ItemMax[lfemale, TurretPack] = 0;
$ItemMax[lfemale, AmmoPack] = 1;
$ItemMax[lfemale, RepairKit] = 1;
$ItemMax[lfemale, DeployableInvPack] = 0;
$ItemMax[lfemale, DeployableAmmoPack] = 0;

$MaxWeapons[lfemale] = 6;

//----------------------------------------------------------------------------
// Medium Female Armor
//----------------------------------------------------------------------------
$DamageScale[mfemale, $LandingDamageType] = 1.0;
$DamageScale[mfemale, $ImpactDamageType] = 1.0;
$DamageScale[mfemale, $CrushDamageType] = 1.0;
$DamageScale[mfemale, $BulletDamageType] = 1.0;
$DamageScale[mfemale, $EnergyDamageType] = 1.0;
$DamageScale[mfemale, $PlasmaDamageType] = 0.6;
$DamageScale[mfemale, $ExplosionDamageType] = 1.0;
$DamageScale[mfemale, $MissileDamageType] = 1.0;
$DamageScale[mfemale, $ShrapnelDamageType] = 1.0;
$DamageScale[mfemale, $DebrisDamageType] = 1.0;
$DamageScale[mfemale, $LaserDamageType] = 1.0;
$DamageScale[mfemale, $MortarDamageType] = 1.0;
$DamageScale[mfemale, $BlasterDamageType] = 1.0;
$DamageScale[mfemale, $ElectricityDamageType] = 1.0;
$DamageScale[mfemale, $MineDamageType] = 1.0;

$ItemMax[mfemale, Blaster] = 1;
$ItemMax[mfemale, Chaingun] = 1;
$ItemMax[mfemale, Disclauncher] = 1;
$ItemMax[mfemale, GrenadeLauncher] = 1;
$ItemMax[mfemale, MrpgLauncher] = 0;
$ItemMax[mfemale, Mortar] = 1;
$ItemMax[mfemale, PlasmaGun] = 1;
$ItemMax[mfemale, LaserRifle] = 0;
$ItemMax[mfemale, EnergyRifle] = 1;
$ItemMax[mfemale, TargetingLaser] = 1;
$ItemMax[mfemale, MineAmmo] = 3;
$ItemMax[mfemale, Grenade] = 3;
$ItemMax[mfemale, Beacon] = 3;

$ItemMax[mfemale, BulletAmmo] = 250;
$ItemMax[mfemale, PlasmaAmmo] = 50;
$ItemMax[mfemale, DiscAmmo] = 40;
$ItemMax[mfemale, GrenadeAmmo] = 30;
$ItemMax[mfemale, MortarAmmo] = 6;

$ItemMax[mfemale, EnergyPack] = 1;
$ItemMax[mfemale, RepairPack] = 1;
$ItemMax[mfemale, ShieldPack] = 1;
$ItemMax[mfemale, SensorJammerPack] = 1;
$ItemMax[mfemale, MotionSensorPack] = 1;
$ItemMax[mfemale, PulseSensorPack] = 1;
$ItemMax[mfemale, DeployableSensorJammerPack] = 1;
$ItemMax[mfemale, CameraPack] = 1;
$ItemMax[mfemale, TurretPack] = 1;
$ItemMax[mfemale, AmmoPack] = 1;
$ItemMax[mfemale, RepairKit] = 1;
$ItemMax[mfemale, DeployableInvPack] = 1;
$ItemMax[mfemale, DeployableAmmoPack] = 1;

$MaxWeapons[mfemale] = 7;

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
// light armor data:
//------------------------------------------------------------------

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

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 44;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 7.0; //was 9.0
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
   animData[25] = { "crouch die", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundM5PlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundM2PlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundM2PlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundM5PlayerDeath, 1, false, false, false, false, 4 };
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

//------------------------------------------------------------------
// Medium Armor data:
//------------------------------------------------------------------

PlayerData marmor
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

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 32;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 0.9;

	maxDamage = 1.0;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 35 * 13.0;
   mass = 11.0;  //was 13.0
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
   animData[25] = { "crouch die", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundM5PlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundM2PlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundM2PlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundM5PlayerDeath, 1, false, false, false, false, 4 };
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

//------------------------------------------------------------------
// Heavy Armor data:
//------------------------------------------------------------------

PlayerData harmor
{
   className = "Armor";
   shapeFile = "harmor";
   flameShapeName = "shield_medium";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 32;
   minJetEnergy = 1;
   jetForce = 400;
   jetEnergyDrain = 0.8;

	maxDamage = 2;
   maxForwardSpeed = 5.0;
   maxBackwardSpeed = 4.0;
   maxSideSpeed = 4.0;
   groundForce = 35 * 18.0;
   groundTraction = 4.5;
   mass = 16.0; //was 18
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
   animData[25] = { "crouch die", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundM5PlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundM2PlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundM2PlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundM5PlayerDeath, 1, false, false, false, false, 4 };
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

   jetSound = SoundConIdle;

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
   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 44;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

	maxDamage = 0.66;
   maxForwardSpeed = 11.1;
   maxBackwardSpeed = 10.1;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 7.0; //was 9.0
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
   animData[25] = { "crouch die", SoundF3PlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundF5PlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundF1PlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundF2PlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundF2PlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundF1PlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundF3PlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundF4PlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundF3PlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundF4PlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundF4PlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundF5PlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundF5PlayerDeath, 1, false, false, false, false, 4 };

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

//------------------------------------------------------------------
// Medium female data:
//------------------------------------------------------------------

PlayerData mfemale
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

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 32;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 0.9;

   canCrouch = true;
	maxDamage = 1.0;
    maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	maxEnergy = 80;
   mass = 11.0; //was 13.0
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
   animData[25] = { "crouch die", SoundF3PlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundF5PlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundF1PlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundF2PlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundF2PlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundF1PlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundF3PlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundF4PlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundF3PlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundF4PlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundF4PlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundF5PlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundF5PlayerDeath, 1, false, false, false, false, 4 };

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

//------------------------------------------------------------------
// New Armors. Hoplite, Defender, Blastech.
//------------------------------------------------------------------

//----------------------------------------------------------------------------
// Blastech
//----------------------------------------------------------------------------

$DamageScale[BlastechM, $LandingDamageType] = 1.0;
$DamageScale[BlastechM, $ImpactDamageType] = 1.0;
$DamageScale[BlastechM, $CrushDamageType] = 1.0;
$DamageScale[BlastechM, $BulletDamageType] = 1.2;
$DamageScale[BlastechM, $PlasmaDamageType] = 1.0;
$DamageScale[BlastechM, $EnergyDamageType] = 1.3;
$DamageScale[BlastechM, $ExplosionDamageType] = -0.1;
$DamageScale[BlastechM, $MissileDamageType] = -0.1;
$DamageScale[BlastechM, $DebrisDamageType] = -0.1;
$DamageScale[BlastechM, $ShrapnelDamageType] = -0.1;
$DamageScale[BlastechM, $LaserDamageType] = 1.0;
$DamageScale[BlastechM, $MortarDamageType] = -0.2;
$DamageScale[BlastechM, $BlasterDamageType] = 1.3;
$DamageScale[BlastechM, $ElectricityDamageType] = 1.0;
$DamageScale[BlastechM, $MineDamageType] = -0.1;
$DamageScale[BlastechM, $EMPDamageType] = 1.0;

$ItemMax[BlastechM, Blaster] = 1;
$ItemMax[BlastechM, Chaingun] = 1;
$ItemMax[BlastechM, Disclauncher] = 1;
$ItemMax[BlastechM, GrenadeLauncher] = 1;
$ItemMax[BlastechM, MrpgLauncher] = 0;
$ItemMax[BlastechM, Mortar] = 1;
$ItemMax[BlastechM, PlasmaGun] = 1;
$ItemMax[BlastechM, LaserRifle] = 1;
$ItemMax[BlastechM, EnergyRifle] = 1;
$ItemMax[BlastechM, MineAmmo] = 2;
$ItemMax[BlastechM, Grenade] = 2;
$ItemMax[BlastechM, Beacon]  = 2;

$ItemMax[BlastechM, BulletAmmo] = 200;
$ItemMax[BlastechM, PlasmaAmmo] = 50;
$ItemMax[BlastechM, DiscAmmo] = 40;
$ItemMax[BlastechM, GrenadeAmmo] = 30;
$ItemMax[BlastechM, MortarAmmo] = 10;

$ItemMax[BlastechM, EnergyPack] = 1;
$ItemMax[BlastechM, RepairPack] = 1;
$ItemMax[BlastechM, ShieldPack] = 1;
$ItemMax[BlastechM, SensorJammerPack] = 1;
$ItemMax[BlastechM, MotionSensorPack] = 1;
$ItemMax[BlastechM, PulseSensorPack] = 1;
$ItemMax[BlastechM, DeployableSensorJammerPack] = 1;
$ItemMax[BlastechM, CameraPack] = 1;
$ItemMax[BlastechM, TurretPack] = 0;
$ItemMax[BlastechM, AmmoPack] = 1;
$ItemMax[BlastechM, RepairKit] = 1;
$ItemMax[BlastechM, DeployableInvPack] = 0;
$ItemMax[BlastechM, DeployableAmmoPack] = 0;

$MaxWeapons[BlastechM] = 7;

//----------------------------------------------------------------------------
// Magnetic Ion Armor
//----------------------------------------------------------------------------
$DamageScale[MagIonM, $LandingDamageType] = 0.5;
$DamageScale[MagIonM, $ImpactDamageType] = 1.0;
$DamageScale[MagIonM, $CrushDamageType] = 1.0;
$DamageScale[MagIonM, $BulletDamageType] = 1.0;
$DamageScale[MagIonM, $PlasmaDamageType] = 1.0;
$DamageScale[MagIonM, $EnergyDamageType] = -0.1;
$DamageScale[MagIonM, $ExplosionDamageType] = 1.0;
$DamageScale[MagIonM, $MissileDamageType] = 1.0;
$DamageScale[MagIonM, $ShrapnelDamageType] = 1.0;
$DamageScale[MagIonM, $DebrisDamageType] = 1.0;
$DamageScale[MagIonM, $LaserDamageType] = 1.0;
$DamageScale[MagIonM, $MortarDamageType] = 1.0;
$DamageScale[MagIonM, $BlasterDamageType] = -0.1;
$DamageScale[MagIonM, $ElectricityDamageType] = -0.1;
$DamageScale[MagIonM, $MineDamageType] = 1.0;
$DamageScale[MagIonM, $EMPDamageType] = -0.1;

$ItemMax[MagIonM, Blaster] = 1;
$ItemMax[MagIonM, Chaingun] = 1;
$ItemMax[MagIonM, Disclauncher] = 1;
$ItemMax[MagIonM, GrenadeLauncher] = 1;
$ItemMax[MagIonM, MrpgLauncher] = 0;
$ItemMax[MagIonM, Mortar] = 1;
$ItemMax[MagIonM, PlasmaGun] = 1;
$ItemMax[MagIonM, LaserRifle] = 1;
$ItemMax[MagIonM, EnergyRifle] = 1;
$ItemMax[MagIonM, MineAmmo] = 3;
$ItemMax[MagIonM, Grenade] = 3;
$ItemMax[MagIonM, Beacon] = 3;

$ItemMax[MagIonM, BulletAmmo] = 250;
$ItemMax[MagIonM, PlasmaAmmo] = 50;
$ItemMax[MagIonM, DiscAmmo] = 50;
$ItemMax[MagIonM, GrenadeAmmo] = 30;
$ItemMax[MagIonM, MortarAmmo] = 10;

$ItemMax[MagIonM, EnergyPack] = 1;
$ItemMax[MagIonM, RepairPack] = 1;
$ItemMax[MagIonM, ShieldPack] = 1;
$ItemMax[MagIonM, SensorJammerPack] = 1;
$ItemMax[MagIonM, MotionSensorPack] = 1;
$ItemMax[MagIonM, PulseSensorPack] = 1;
$ItemMax[MagIonM, DeployableSensorJammerPack] = 1;
$ItemMax[MagIonM, CameraPack] = 1;
$ItemMax[MagIonM, TurretPack] = 1;
$ItemMax[MagIonM, AmmoPack] = 1;
$ItemMax[MagIonM, RepairKit] = 2;
$ItemMax[MagIonM, DeployableInvPack] = 1;
$ItemMax[MagIonM, DeployableAmmoPack] = 1;

$MaxWeapons[MagIonM] = 5;

//----------------------------------------------------------------------------
// Defender Armor
//----------------------------------------------------------------------------
$DamageScale[MECH, $LandingDamageType] = 1.0;
$DamageScale[MECH, $ImpactDamageType] = 0.0;
$DamageScale[MECH, $CrushDamageType] = 0.0;
$DamageScale[MECH, $BulletDamageType] = 0.5;
$DamageScale[MECH, $PlasmaDamageType] = 1.0;
$DamageScale[MECH, $EnergyDamageType] = 1.0;
$DamageScale[MECH, $ExplosionDamageType] = 1.0;
$DamageScale[MECH, $MissileDamageType] = 1.0;
$DamageScale[MECH, $DebrisDamageType] = 1.0;
$DamageScale[MECH, $ShrapnelDamageType] = 1.0;
$DamageScale[MECH, $LaserDamageType] = -0.1;
$DamageScale[MECH, $MortarDamageType] = 1.0;
$DamageScale[MECH, $BlasterDamageType] = 1.0;
$DamageScale[MECH, $ElectricityDamageType] = 1.0;
$DamageScale[MECH, $MineDamageType] = 1.0;
$DamageScale[MECH, $EMPDamageType] = 1.0;

$ItemMax[MECH, Blaster] = 1;
$ItemMax[MECH, Chaingun] = 1;
$ItemMax[MECH, Disclauncher] = 1;
$ItemMax[MECH, GrenadeLauncher] = 1;
$ItemMax[MECH, Mortar] = 1;
$ItemMax[MECH, PlasmaGun] = 1;
$ItemMax[MECH, LaserRifle] = 0;
$ItemMax[MECH, EnergyRifle] = 1;
$ItemMax[MECH, MineAmmo] = 4;
$ItemMax[MECH, Grenade] = 4;
$ItemMax[MECH, Beacon] = 4;

$ItemMax[MECH, BulletAmmo] = 264;
$ItemMax[MECH, PlasmaAmmo] = 50;
$ItemMax[MECH, DiscAmmo] = 40;
$ItemMax[MECH, GrenadeAmmo] = 50;
$ItemMax[MECH, MortarAmmo] = 15;

$ItemMax[MECH, EnergyPack] = 1;
$ItemMax[MECH, RepairPack] = 0;
$ItemMax[MECH, ShieldPack] = 0;
$ItemMax[MECH, SensorJammerPack] = 0;
$ItemMax[MECH, MotionSensorPack] = 0;
$ItemMax[MECH, PulseSensorPack] = 0;
$ItemMax[MECH, DeployableSensorJammerPack] = 0;
$ItemMax[MECH, CameraPack] = 1;
$ItemMax[MECH, TurretPack] = 0;
$ItemMax[MECH, AmmoPack] = 1;
$ItemMax[MECH, RepairKit] = 1;
$ItemMax[MECH, DeployableInvPack] = 0;
$ItemMax[MECH, DeployableAmmoPack] = 0;

$MaxWeapons[MECH] = 9;

//----------------------------------------------------------------------------
// Blastech
//----------------------------------------------------------------------------

$DamageScale[BlastechF, $LandingDamageType] = 1.0;
$DamageScale[BlastechF, $ImpactDamageType] = 1.0;
$DamageScale[BlastechF, $CrushDamageType] = 1.0;
$DamageScale[BlastechF, $BulletDamageType] = 1.2;
$DamageScale[BlastechF, $PlasmaDamageType] = 1.0;
$DamageScale[BlastechF, $EnergyDamageType] = 1.3;
$DamageScale[BlastechF, $ExplosionDamageType] = -0.1;
$DamageScale[BlastechF, $MissileDamageType] = -0.1;
$DamageScale[BlastechF, $DebrisDamageType] = -0.1;
$DamageScale[BlastechF, $ShrapnelDamageType] = -0.1;
$DamageScale[BlastechF, $LaserDamageType] = 1.0;
$DamageScale[BlastechF, $MortarDamageType] = -0.2;
$DamageScale[BlastechF, $BlasterDamageType] = 1.3;
$DamageScale[BlastechF, $ElectricityDamageType] = 1.0;
$DamageScale[BlastechF, $MineDamageType] = -0.1;
$DamageScale[BlastechF, $EMPDamageType] = 1.0;

$ItemMax[BlastechF, Blaster] = 1;
$ItemMax[BlastechF, Chaingun] = 1;
$ItemMax[BlastechF, Disclauncher] = 1;
$ItemMax[BlastechF, GrenadeLauncher] = 1;
$ItemMax[BlastechF, MrpgLauncher] = 0;
$ItemMax[BlastechF, Mortar] = 0;
$ItemMax[BlastechF, PlasmaGun] = 1;
$ItemMax[BlastechF, LaserRifle] = 1;
$ItemMax[BlastechF, EnergyRifle] = 1;
$ItemMax[BlastechF, MineAmmo] = 3;
$ItemMax[BlastechF, Grenade] = 5;
$ItemMax[BlastechF, Beacon]  = 3;

$ItemMax[BlastechF, BulletAmmo] = 200;
$ItemMax[BlastechF, PlasmaAmmo] = 50;
$ItemMax[BlastechF, DiscAmmo] = 40;
$ItemMax[BlastechF, GrenadeAmmo] = 30;

$ItemMax[BlastechF, EnergyPack] = 1;
$ItemMax[BlastechF, RepairPack] = 1;
$ItemMax[BlastechF, ShieldPack] = 1;
$ItemMax[BlastechF, SensorJammerPack] = 1;
$ItemMax[BlastechF, MotionSensorPack] = 1;
$ItemMax[BlastechF, PulseSensorPack] = 1;
$ItemMax[BlastechF, DeployableSensorJammerPack] = 1;
$ItemMax[BlastechF, CameraPack] = 1;
$ItemMax[BlastechF, TurretPack] = 0;
$ItemMax[BlastechF, AmmoPack] = 1;
$ItemMax[BlastechF, RepairKit] = 1;
$ItemMax[BlastechF, DeployableInvPack] = 0;
$ItemMax[BlastechF, DeployableAmmoPack] = 0;

$MaxWeapons[BlastechF] = 7;

//----------------------------------------------------------------------------
// Magnetic Ion Armor
//----------------------------------------------------------------------------
$DamageScale[MagIonF, $LandingDamageType] = 0.5;
$DamageScale[MagIonF, $ImpactDamageType] = 1.0;
$DamageScale[MagIonF, $CrushDamageType] = 1.0;
$DamageScale[MagIonF, $BulletDamageType] = 1.0;
$DamageScale[MagIonF, $PlasmaDamageType] = 1.0;
$DamageScale[MagIonF, $EnergyDamageType] = -0.1;
$DamageScale[MagIonF, $ExplosionDamageType] = 1.0;
$DamageScale[MagIonF, $MissileDamageType] = 1.0;
$DamageScale[MagIonF, $ShrapnelDamageType] = 1.0;
$DamageScale[MagIonF, $DebrisDamageType] = 1.0;
$DamageScale[MagIonF, $LaserDamageType] = 1.0;
$DamageScale[MagIonF, $MortarDamageType] = 1.0;
$DamageScale[MagIonF, $BlasterDamageType] = -0.1;
$DamageScale[MagIonF, $ElectricityDamageType] = -0.01;
$DamageScale[MagIonF, $MineDamageType] = 1.0;
$DamageScale[MagIonF, $EMPDamageType] = -0.1;

$ItemMax[MagIonF, Blaster] = 1;
$ItemMax[MagIonF, Chaingun] = 1;
$ItemMax[MagIonF, Disclauncher] = 1;
$ItemMax[MagIonF, GrenadeLauncher] = 1;
$ItemMax[MagIonF, MrpgLauncher] = 0;
$ItemMax[MagIonF, Mortar] = 1;
$ItemMax[MagIonF, PlasmaGun] = 1;
$ItemMax[MagIonF, LaserRifle] = 1;
$ItemMax[MagIonF, EnergyRifle] = 1;
$ItemMax[MagIonF, MineAmmo] = 4;
$ItemMax[MagIonF, Grenade] = 5;
$ItemMax[MagIonF, Beacon] = 6;

$ItemMax[MagIonF, BulletAmmo] = 250;
$ItemMax[MagIonF, PlasmaAmmo] = 50;
$ItemMax[MagIonF, DiscAmmo] = 40;
$ItemMax[MagIonF, GrenadeAmmo] = 30;
$ItemMax[MagIonF, MortarAmmo] = 10;

$ItemMax[MagIonF, EnergyPack] = 1;
$ItemMax[MagIonF, RepairPack] = 1;
$ItemMax[MagIonF, ShieldPack] = 1;
$ItemMax[MagIonF, SensorJammerPack] = 1;
$ItemMax[MagIonF, MotionSensorPack] = 1;
$ItemMax[MagIonF, PulseSensorPack] = 1;
$ItemMax[MagIonF, DeployableSensorJammerPack] = 1;
$ItemMax[MagIonF, CameraPack] = 1;
$ItemMax[MagIonF, TurretPack] = 1;
$ItemMax[MagIonF, AmmoPack] = 1;
$ItemMax[MagIonF, RepairKit] = 2;
$ItemMax[MagIonF, DeployableInvPack] = 1;
$ItemMax[MagIonF, DeployableAmmoPack] = 1;

$MaxWeapons[MagIonF] = 5;

//------------------------------------------------------------------
// Blastech armor data:
//------------------------------------------------------------------

PlayerData BlastechM
{
   className = "Armor";
   shapeFile = "larmor";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "shotgunex";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 44;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

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
   animData[25] = { "crouch die", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundM5PlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundM2PlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundM2PlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundM5PlayerDeath, 1, false, false, false, false, 4 };
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

   jetSound = SoundLaserIdle;
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

//------------------------------------------------------------------
// Mag. Ion Armor data:
//------------------------------------------------------------------

PlayerData MagIonM
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "plasmatrail";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = true;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 32;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 0.8;

	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 9.5;
   maxSideSpeed = 9.0;
   groundForce = 35 * 13.0;
   mass = 11.0; //was13.0
   groundTraction = 3.0;
	
	maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 125;
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
   animData[25] = { "crouch die", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundM5PlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundM2PlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundM2PlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundM5PlayerDeath, 1, false, false, false, false, 4 };
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

   jetSound = SoundDiscSpin;

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

//------------------------------------------------------------------
// MECH\Gundam Armor data:
//------------------------------------------------------------------

PlayerData MECH
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
   maxJetForwardVelocity = 32;
   minJetEnergy = 1;
   jetForce = 400;
   jetEnergyDrain = 0.8;

	maxDamage = 3.63;
   maxForwardSpeed = 6.5;
   maxBackwardSpeed = 6.5;
   maxSideSpeed = 6.5;
   groundForce = 35 * 36.0;
   groundTraction = 4.5;
   mass = 18.0; //was 18.0
	maxEnergy = 115;
   drag = 1.0;
   density = 2.5;
   canCrouch = false;

	minDamageSpeed = 25;
	damageScale = 0.006;

   jumpImpulse = 300;
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
   animData[25] = { "crouch die", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundM5PlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundM2PlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundM2PlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundM1PlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundM3PlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundM4PlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundM5PlayerDeath, 1, false, false, false, false, 4 };
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
// Blastech female data:
//------------------------------------------------------------------

PlayerData BlastechF
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "shotgunex";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";

debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 44;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.6;

	maxDamage = 0.66;
   maxForwardSpeed = 11.1;
   maxBackwardSpeed = 10.1;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
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

  animData[25] = { "crouch die", SoundF3PlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundF5PlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundF1PlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundF2PlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundF2PlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundF1PlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundF3PlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundF4PlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundF3PlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundF4PlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundF4PlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundF5PlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundF5PlayerDeath, 1, false, false, false, false, 4 };

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


   jetSound = SoundLaserIdle;

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

//------------------------------------------------------------------
// Mag. Ion female data:
//------------------------------------------------------------------

PlayerData MagIonF
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "plasmatrail";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 32;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 0.8;

   canCrouch = true;
	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 9.5;
   maxSideSpeed = 9.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	maxEnergy = 80;
   mass = 13.0;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 125;
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
   animData[25] = { "crouch die", SoundF3PlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundF5PlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundF1PlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundF2PlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundF2PlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundF1PlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundF3PlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundF4PlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundF3PlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundF4PlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundF4PlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundF5PlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundF5PlayerDeath, 1, false, false, false, false, 4 };

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

   jetSound = SoundDiscSpin;

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

$ArmorType[Male, BlastechArmor] = BlastechM;
$ArmorType[Male, MagIonArmor] = MagIonM;
$ArmorType[Male, MECHArmor] = MECH;
$ArmorType[Female, BlastechArmor] = BlastechF;
//$ArmorType[Female, MagIonArmor] = MagIonF;
$ArmorType[Female, MECHArmor] = MECH;

$ArmorName[BlastechM] = BlastechArmor;
$ArmorName[MagIonM] = MagIonArmor;
$ArmorName[MECH] = MECHArmor;
$ArmorName[BlastechF] = BlastechArmor;
//$ArmorName[MagIonF] = MagIonArmor;

function dodance(%client) {
	if(!%client.dan) return;
	%armor = Player::getArmor(%client);
	if (%armor == "harmor" || %armor == "MECH") {
		%anim = $PlayerAnim::Celebration1;
		Player::setAnimation(%client, %anim);
		schedule("dodance("@%client@");", 3.1);			
	} else if (%armor == "marmor" || %armor == "MagIonM") {
		%anim = $PlayerAnim::Celebration3;
		Player::setAnimation(%client, %anim);
		schedule("dodance("@%client@");", 3.25);
	} else if (%armor == "mfemale" || %armor == "MagIonF") {
		%anim = $PlayerAnim::Celebration3;
		Player::setAnimation(%client, %anim);
		schedule("dodance("@%client@");", 2.5);
	} else if (%armor == "larmor" || %armor == "BlastechM") {
		%anim = $PlayerAnim::Celebration2;
		Player::setAnimation(%client, %anim);
		schedule("dodance("@%client@");", 1.45);
	} else if (%armor == "lfemale" || %armor == "BlastechF") {
		%anim = $PlayerAnim::Celebration2;
		Player::setAnimation(%client, %anim);
		schedule("dodance("@%client@");", 1.5);
	} 
}


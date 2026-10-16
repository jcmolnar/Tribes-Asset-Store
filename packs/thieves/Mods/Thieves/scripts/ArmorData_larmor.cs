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
$DamageScale[larmor, $NaniteBurstDamageType] =1.0;
$DamageScale[larmor, $RailgunDamageType] =1.3;
$ItemMax[larmor, Blaster] = 1;
$ItemMax[larmor, Chaingun] = 1;
$ItemMax[larmor, Disclauncher] = 1;
$ItemMax[larmor, GrenadeLauncher] = 1;
$ItemMax[larmor, Mortar] = 0;
$ItemMax[larmor, PlasmaGun] = 1;
$ItemMax[larmor, LaserRifle] = 1;
$ItemMax[larmor, EnergyRifle] = 1;
$ItemMax[larmor, TargetingLaser] = 1;
$ItemMax[larmor, MineAmmo] = 3;
$ItemMax[larmor, Grenade] = 5;
$ItemMax[larmor, Beacon] = 3;
$ItemMax[larmor, BulletAmmo] = 100;
$ItemMax[larmor, PlasmaAmmo] = 30;
$ItemMax[larmor, RailgunAmmo] = 10;
$ItemMax[larmor, DiscAmmo] = 15;
$ItemMax[larmor, GrenadeAmmo] = 10;
$ItemMax[larmor, MortarAmmo] = 10;
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
$MaxWeapons[larmor] = 3;
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
maxJetForwardVelocity = 22;
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
animData[0] = { "root", none, 1, true, true, true, false, 0 };
animData[1] = { "run", none, 1, true, false, true, false, 3 };
animData[2] = { "runback", none, 1, true, false, true, false, 3 };
animData[3] = { "side left", none, 1, true, false, true, false, 3 };
animData[4] = { "side left", none, -1, true, false, true, false, 3 };
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
animData[14] = { "fall", none, 1, true, true, true, false, 3 };
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 };
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 };
animData[19] = { "jet", none, 1, true, true, true, false, 3 };
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
animData[21] = { "throw", none, 1, true, false, false, false, 3 };
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
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
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 };
animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
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
boxNormalHeadPercentage = 0.83;
boxNormalTorsoPercentage = 0.53;
boxCrouchHeadPercentage = 0.6666;
boxCrouchTorsoPercentage = 0.3333;
boxHeadLeftPercentage = 0;
boxHeadRightPercentage = 1;
boxHeadBackPercentage = 0;
boxHeadFrontPercentage = 1;
};

$DamageScale[inffarmor, $LandingDamageType] = 1.1;
$DamageScale[inffarmor, $ImpactDamageType] = 1.1;
$DamageScale[inffarmor, $CrushDamageType] = 1.1;
$DamageScale[inffarmor, $BulletDamageType] = 1.3;
$DamageScale[inffarmor, $PlasmaDamageType] = 1.1;
$DamageScale[inffarmor, $EnergyDamageType] = 1.4;
$DamageScale[inffarmor, $ExplosionDamageType] = 1.1;
$DamageScale[inffarmor, $MissileDamageType] = 1.1;
$DamageScale[inffarmor, $DebrisDamageType] = 1.3;
$DamageScale[inffarmor, $ShrapnelDamageType] = 1.3;
$DamageScale[inffarmor, $LaserDamageType] = 1.05;
$DamageScale[inffarmor, $MortarDamageType] = 1.4;
$DamageScale[inffarmor, $BlasterDamageType] = 1.4;
$DamageScale[inffarmor, $ElectricityDamageType] = 1.1;
$DamageScale[inffarmor, $MineDamageType] = 1.3;
$DamageScale[inffarmor, $NaniteBurstDamageType]=1;
//$DamageScale[inffarmor, $RailgunDamageType]=1.6;
$ItemMax[inffarmor, Blaster] = 0;
$ItemMax[inffarmor, Chaingun] = 0;
$ItemMax[inffarmor, Disclauncher] = 1;
$ItemMax[inffarmor, GrenadeLauncher] = 1;
$ItemMax[inffarmor, Mortar] = 0;
$ItemMax[inffarmor, PlasmaGun] = 0;
$ItemMax[inffarmor, LaserRifle] = 0;
$ItemMax[inffarmor, EnergyRifle] = 1;
$ItemMax[inffarmor, TargetingLaser] = 1;
$ItemMax[inffarmor, MineAmmo] = 3;
$ItemMax[inffarmor, Grenade] = 3;
$ItemMax[inffarmor, Beacon] = 3;
$ItemMax[inffarmor, BulletAmmo] = 0;
$ItemMax[inffarmor, PlasmaAmmo] = 0;
$ItemMax[inffarmor, DiscAmmo] = 20;
$ItemMax[inffarmor, GrenadeAmmo] = 10;
$ItemMax[inffarmor, MortarAmmo] = 0;
$ItemMax[inffarmor, EnergyPack] = 1;
$ItemMax[inffarmor, RepairPack] = 1;
$ItemMax[inffarmor, ShieldPack] = 1;
$ItemMax[inffarmor, SensorJammerPack] = 1;
$ItemMax[inffarmor, MotionSensorPack] = 1;
$ItemMax[inffarmor, PulseSensorPack] = 1;
$ItemMax[inffarmor, DeployableSensorJammerPack] = 1;
$ItemMax[inffarmor, CameraPack] = 1;
$ItemMax[inffarmor, TurretPack] = 0;
$ItemMax[inffarmor, AmmoPack] = 1;
$ItemMax[inffarmor, RepairKit] = 2;
$ItemMax[inffarmor, DeployableInvPack] = 0;
$ItemMax[inffarmor, DeployableAmmoPack] = 0;
$MaxWeapons[inffarmor] = 2;
PlayerData inffarmor
{
className = "Armor";
shapeFile = "lfemale";
damageSkinData = "armorDamageSkins";
debrisId = playerDebris;
flameShapeName = "lflame";
shieldShapeName = "shield";
shadowDetailMask = 1;
visibleToSensor = False;
mapFilter = 1;
mapIcon = "M_player";
canCrouch = true;
maxJetSideForceFactor = 0.95;
maxJetForwardVelocity = 28;
minJetEnergy = 1;
jetForce = 236;
jetEnergyDrain = 0.85;
maxDamage = 0.60;
maxForwardSpeed = 15;
maxBackwardSpeed = 13;
maxSideSpeed = 13;
groundForce = 40 * 7.0;
mass = 7.0;
groundTraction = 2.85;
maxEnergy = 60;
drag = 0.85;
density = 1.15;
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

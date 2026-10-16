$DamageScale[dreadarmor, $LandingDamageType] = 1.0;
$DamageScale[dreadarmor, $ImpactDamageType] = 1.0;
$DamageScale[dreadarmor, $CrushDamageType] = 1.0;
$DamageScale[dreadarmor, $BulletDamageType] = 0.1;
$DamageScale[dreadarmor, $PlasmaDamageType] = 0.3;
$DamageScale[dreadarmor, $EnergyDamageType] = 0.8;
$DamageScale[dreadarmor, $ExplosionDamageType] = 0.2;
$DamageScale[dreadarmor, $MissileDamageType] = 0.2;
$DamageScale[dreadarmor, $DebrisDamageType] = 0.3;
$DamageScale[dreadarmor, $ShrapnelDamageType] = 0.3;
$DamageScale[dreadarmor, $LaserDamageType] = 0.8;
$DamageScale[dreadarmor, $MortarDamageType] = 0.4;
$DamageScale[dreadarmor, $BlasterDamageType] = 0.8;
$DamageScale[dreadarmor, $ElectricityDamageType] = 1.0;
$DamageScale[dreadarmor, $MineDamageType] = 0.3;
$DamageScale[dreadarmor, $NaniteBurstDamageType]=0.5;
//$DamageScale[dreadarmor, $RailgunDamageType]=0.9;
$ItemMax[dreadarmor, Blaster] = 1;
$ItemMax[dreadarmor, Chaingun] = 1;
$ItemMax[dreadarmor, Disclauncher] = 1;
$ItemMax[dreadarmor, GrenadeLauncher] = 1;
$ItemMax[dreadarmor, Mortar] = 1;
$ItemMax[dreadarmor, PlasmaGun] = 1;
$ItemMax[dreadarmor, LaserRifle] = 0;
$ItemMax[dreadarmor, EnergyRifle] = 0;
$ItemMax[dreadarmor, TargetingLaser] = 1;
$ItemMax[dreadarmor, MineAmmo] = 15;
$ItemMax[dreadarmor, Grenade] = 10;
$ItemMax[dreadarmor, Beacon] = 5;
$ItemMax[dreadarmor, BulletAmmo] = 300;
$ItemMax[dreadarmor, PlasmaAmmo] = 75;
$ItemMax[dreadarmor, DiscAmmo] = 25;
$ItemMax[dreadarmor, GrenadeAmmo] = 25;
$ItemMax[dreadarmor, MortarAmmo] = 20;
$ItemMax[dreadarmor, EnergyPack] = 1;
$ItemMax[dreadarmor, RepairPack] = 1;
$ItemMax[dreadarmor, ShieldPack] = 1;
$ItemMax[dreadarmor, SensorJammerPack] = 1;
$ItemMax[dreadarmor, MotionSensorPack] = 1;
$ItemMax[dreadarmor, PulseSensorPack] = 1;
$ItemMax[dreadarmor, DeployableSensorJammerPack] = 1;
$ItemMax[dreadarmor, CameraPack] = 1;
$ItemMax[dreadarmor, TurretPack] = 0;
$ItemMax[dreadarmor, AmmoPack] = 1;
$ItemMax[dreadarmor, RepairKit] = 1;
$ItemMax[dreadarmor, DeployableInvPack] = 1;
$ItemMax[dreadarmor, DeployableAmmoPack] = 1;
$MaxWeapons[dreadarmor] = 5;
PlayerData dreadarmor
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
maxJetSideForceFactor = 0.7;
maxJetForwardVelocity = 4.0;
minJetEnergy = 1;
jetForce = 400;
jetEnergyDrain = 1.3;
maxDamage = 1.40;
maxForwardSpeed = 2.7;
maxBackwardSpeed = 2.5;
maxSideSpeed = 2.5;
groundForce = 45 * 18.0;
groundTraction = 4.5;
mass = 22.0;
maxEnergy = 150;
drag = 1.2;
density = 2.65;
canCrouch = false;
minDamageSpeed = 25;
damageScale = 0.006;
jumpImpulse = 150;
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
animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
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
boxNormalHeadPercentage = 0.70;
boxNormalTorsoPercentage = 0.45;
boxHeadLeftPercentage = 0.48;
boxHeadRightPercentage = 0.70;
boxHeadBackPercentage = 0.48;
boxHeadFrontPercentage = 0.60;
};

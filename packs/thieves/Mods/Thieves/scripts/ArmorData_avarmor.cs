$DamageScale[avarmor, $LandingDamageType] = 1.0;
$DamageScale[avarmor, $ImpactDamageType] = 1.0;
$DamageScale[avarmor, $CrushDamageType] = 1.0;
$DamageScale[avarmor, $BulletDamageType] = 1.2;
$DamageScale[avarmor, $PlasmaDamageType] = 0.3;
$DamageScale[avarmor, $EnergyDamageType] = 0.3;
$DamageScale[avarmor, $ExplosionDamageType] = 1.3;
$DamageScale[avarmor, $MissileDamageType] = 1.1;
$DamageScale[avarmor, $ShrapnelDamageType] = 1.1;
$DamageScale[avarmor, $DebrisDamageType] = 1.1;
$DamageScale[avarmor, $LaserDamageType] = 0.3;
$DamageScale[avarmor, $MortarDamageType] = 1.2;
$DamageScale[avarmor, $BlasterDamageType] = 0.4;
$DamageScale[avarmor, $ElectricityDamageType] = 0.4;
$DamageScale[avarmor, $MineDamageType] = 1.2;
$DamageScale[avarmor, $NaniteBurstDamageType]=0.9;
//$DamageScale[avarmor, $RailgunDamageType]=1.2;
$ItemMax[avarmor, Blaster] = 1;
$ItemMax[avarmor, Chaingun] = 0;
$ItemMax[avarmor, Disclauncher] = 1;
$ItemMax[avarmor, GrenadeLauncher] = 0;
$ItemMax[avarmor, Mortar] = 0;
$ItemMax[avarmor, PlasmaGun] = 1;
$ItemMax[avarmor, LaserRifle] = 0;
$ItemMax[avarmor, EnergyRifle] = 1;
$ItemMax[avarmor, TargetingLaser] = 1;
$ItemMax[avarmor, MineAmmo] = 5;
$ItemMax[avarmor, Grenade] = 6;
$ItemMax[avarmor, Beacon] = 3;
$ItemMax[avarmor, BulletAmmo] = 0;
$ItemMax[avarmor, PlasmaAmmo] = 35;
$ItemMax[avarmor, DiscAmmo] = 15;
$ItemMax[avarmor, GrenadeAmmo] = 10;
$ItemMax[avarmor, MortarAmmo] = 0;
$ItemMax[avarmor, EnergyPack] = 1;
$ItemMax[avarmor, RepairPack] = 1;
$ItemMax[avarmor, ShieldPack] = 1;
$ItemMax[avarmor, SensorJammerPack] = 1;
$ItemMax[avarmor, MotionSensorPack] = 1;
$ItemMax[avarmor, PulseSensorPack] = 1;
$ItemMax[avarmor, DeployableSensorJammerPack] = 1;
$ItemMax[avarmor, CameraPack] = 1;
$ItemMax[avarmor, TurretPack] = 0;
$ItemMax[avarmor, AmmoPack] = 1;
$ItemMax[avarmor, RepairKit] = 1;
$ItemMax[avarmor, DeployableInvPack] = 1;
$ItemMax[avarmor, DeployableAmmoPack] = 1;
$MaxWeapons[avarmor] = 4;
PlayerData avarmor
{
className = "Armor";
shapeFile = "marmor";
flameShapeName = "mflame";
shieldShapeName = "shield";
damageSkinData = "armorDamageSkins";
debrisId = playerDebris;
shadowDetailMask = 1;
canCrouch = false;
visibleToSensor = True;
mapFilter = 1;
mapIcon = "M_player";
maxJetSideForceFactor = 0.8;
maxJetForwardVelocity = 17;
minJetEnergy = 1;
jetForce = 320;
jetEnergyDrain = 1.0;
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
minDamageSpeed = 25;
damageScale = 0.005;
jumpImpulse = 110;
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
boxNormalHeadPercentage = 0.83;
boxNormalTorsoPercentage = 0.49;
boxHeadLeftPercentage = 0;
boxHeadRightPercentage = 1;
boxHeadBackPercentage = 0;
boxHeadFrontPercentage = 1;
};

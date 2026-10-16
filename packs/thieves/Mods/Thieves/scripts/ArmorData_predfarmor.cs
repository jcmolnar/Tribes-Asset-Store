$DamageScale[predfarmor, $LandingDamageType] = 1.0;
$DamageScale[predfarmor, $ImpactDamageType] = 1.0;
$DamageScale[predfarmor, $CrushDamageType] = 1.0;
$DamageScale[predfarmor, $BulletDamageType] = 1.0;
$DamageScale[predfarmor, $PlasmaDamageType] = 0.6;
$DamageScale[predfarmor, $EnergyDamageType] = 1.0;
$DamageScale[predfarmor, $ExplosionDamageType] = 1.0;
$DamageScale[predfarmor, $MissileDamageType] = 1.0;
$DamageScale[predfarmor, $ShrapnelDamageType] = 1.0;
$DamageScale[predfarmor, $DebrisDamageType] = 1.0;
$DamageScale[predfarmor, $LaserDamageType] = 1.5;
$DamageScale[predfarmor, $MortarDamageType] = 1.0;
$DamageScale[predfarmor, $BlasterDamageType] = 1.0;
$DamageScale[predfarmor, $ElectricityDamageType] = 1.0;
$DamageScale[predfarmor, $MineDamageType] = 1.0;
$DamageScale[predfarmor, $NaniteBurstDamageType]=1.75;
//$DamageScale[predfarmor, $RailgunDamageType]=1.9;
$ItemMax[predfarmor, Blaster] = 1;
$ItemMax[predfarmor, Chaingun] = 0;
$ItemMax[predfarmor, Disclauncher] = 1;
$ItemMax[predfarmor, GrenadeLauncher] = 0;
$ItemMax[predfarmor, Mortar] = 0;
$ItemMax[predfarmor, PlasmaGun] = 1;
$ItemMax[predfarmor, LaserRifle] = 1;
$ItemMax[predfarmor, EnergyRifle] = 0;
$ItemMax[predfarmor, TargetingLaser] = 1;
$ItemMax[predfarmor, MineAmmo] = 5;
$ItemMax[predfarmor, Grenade] = 6;
$ItemMax[predfarmor, Beacon] = 3;
$ItemMax[predfarmor, BulletAmmo] = 0;
$ItemMax[predfarmor, PlasmaAmmo] = 25;
$ItemMax[predfarmor, DiscAmmo] = 15;
$ItemMax[predfarmor, GrenadeAmmo] = 0;
$ItemMax[predfarmor, MortarAmmo] = 0;
$ItemMax[predfarmor, EnergyPack] = 1;
$ItemMax[predfarmor, RepairPack] = 1;
$ItemMax[predfarmor, ShieldPack] = 1;
$ItemMax[predfarmor, SensorJammerPack] = 1;
$ItemMax[predfarmor, MotionSensorPack] = 1;
$ItemMax[predfarmor, PulseSensorPack] = 1;
$ItemMax[predfarmor, DeployableSensorJammerPack] = 1;
$ItemMax[predfarmor, CameraPack] = 1;
$ItemMax[predfarmor, TurretPack] = 0;
$ItemMax[predfarmor, AmmoPack] = 1;
$ItemMax[predfarmor, RepairKit] = 1;
$ItemMax[predfarmor, DeployableInvPack] = 1;
$ItemMax[predfarmor, DeployableAmmoPack] = 1;
$MaxWeapons[predfarmor] = 4;
PlayerData predfarmor
{
className = "Armor";
shapeFile = "marmor";
flameShapeName = "mflame";
shieldShapeName = "shield";
damageSkinData = "armorDamageSkins";
debrisId = playerDebris;
shadowDetailMask = 1;
canCrouch = true;
visibleToSensor = False;
mapFilter = 1;
mapIcon = "M_player";
maxJetSideForceFactor = 0.8;
maxJetForwardVelocity = 17;
minJetEnergy = 1;
jetForce = 330;
jetEnergyDrain = 1.0;
maxDamage = 1.0;
maxForwardSpeed = 9.0;
maxBackwardSpeed = 9.0;
maxSideSpeed = 9.0;
groundForce = 35 * 13.0;
mass = 15.0;
groundTraction = 3.0;
maxEnergy = 90;
drag = 1.0;
density = 1.6;
minDamageSpeed = 25;
damageScale = 0.005;
jumpImpulse = 120;
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

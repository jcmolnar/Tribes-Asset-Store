// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
$ArmorType[Female, SLightArmor] = lfemale;
$ArmorName[slfemale] = SLightArmor;
//ItemData Methods in armorLightMale.cs

$DamageScale[slfemale, $LandingDamageType] = -0.0;
$DamageScale[slfemale, $ImpactDamageType] = -0.0;
$DamageScale[slfemale, $CrushDamageType] = -0.0;
$DamageScale[slfemale, $BulletDamageType] = -0.0;
$DamageScale[slfemale, $PlasmaDamageType] = -0.0;
$DamageScale[slfemale, $EnergyDamageType] = -0.0;
$DamageScale[slfemale, $ExplosionDamageType] = -0.0;
$DamageScale[slfemale, $MissileDamageType] = -0.0;
$DamageScale[slfemale, $ShrapnelDamageType] = -0.0;
$DamageScale[slfemale, $DebrisDamageType] = -0.0;
$DamageScale[slfemale, $LaserDamageType] = -0.0;
$DamageScale[slfemale, $MortarDamageType] = -0.0;
$DamageScale[slfemale, $BlasterDamageType] = -0.0;
$DamageScale[slfemale, $ElectricityDamageType] = -0.0;
$DamageScale[slfemale, $MineDamageType] = -0.0;

$MaxWeapons[slfemale] = 3;

PlayerData slfemale
{
className = "Armor";
shapeFile = "lfemale";
flameShapeName = "lflame";
shieldShapeName = "shield";
damageSkinData = "armorDamageSkins";
debrisId = playerDebris;
shadowDetailMask = 1;
validateShape = true;

visibleToSensor = True;
mapFilter = 1;
mapIcon = "M_player";

canCrouch = true;
maxJetSideForceFactor = 0.4;
maxJetForwardVelocity = 11;
minJetEnergy = 0;
jetForce = 669;
jetEnergyDrain = -0.1;

    maxDamage = 5.0;
    maxForwardSpeed = 21;
    maxBackwardSpeed = 20;
    maxSideSpeed = 20;
    groundForce = 40 * 8.0;
    mass = 9.0;
    groundTraction = 3.0;
    maxEnergy = 160;
    drag = 1.0;
    density = 1.2;

	minDamageSpeed = 5.5;//25;
	damageScale = 0;

jumpImpulse = 25;
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
    animData[7] = { "die back", none, 1, true, true, true, true, 3 };
    animData[8] = { "die back", none, 1, true, true, true, true, 3 };
    animData[9] = { "die back", none, -1, true, true, true, true, 3 };
    animData[10] = { "die back", none, 1, true, true, true, true, 3 };
    animData[11] = { "die back", none, -1, true, true, true, true, 3 };
    animData[12] = { "die back", none, 1, true, true, true, true, 3 };
    animData[13] = { "die back", none, -1, true, true, true, true, 3 };
    //animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
    //animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
    //animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
    //animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
    //animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
    //animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
    //animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
    animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
    animData[15]  = { "landing", none, 1, true, false, false, false, 3 };
    animData[16]  = { "landing", none, 1, true, false, false, false, 3 };
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
animData[48] = { "die back", none, 1, true, false, false, true, 1 };
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

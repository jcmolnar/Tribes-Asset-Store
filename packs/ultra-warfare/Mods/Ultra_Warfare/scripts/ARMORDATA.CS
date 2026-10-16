

////////////////////////////////////////////////////////////////
// foot sounds

SoundData SoundLFootRSoft
{
   wavFileName = "lfootrsoft.wav";
   profile = Profile3dFoot;
};

SoundData SoundLFootRHard
{
   wavFileName = "lfootrhard.wav";
   profile = Profile3dFoot;
};

SoundData SoundLFootRSnow
{
   wavFileName = "lfootrsnow.wav";
   profile = Profile3dFoot;
};

SoundData SoundLFootLSoft
{
   wavFileName = "lfootlsoft.wav";
   profile = Profile3dFoot;
};

SoundData SoundLFootLHard
{
   wavFileName = "lfootlhard.wav";
   profile = Profile3dFoot;
};
SoundData SoundLFootLSnow
{
   wavFileName = "lfootlsnow.wav";
   profile = Profile3dFoot;
};

SoundData SoundMFootRSoft
{
   wavFileName = "mfootrsoft.wav";
   profile = Profile3dFoot;
};

SoundData SoundMFootRHard
{
   wavFileName = "mfootrhard.wav";
   profile = Profile3dFoot;
};

SoundData SoundMFootRSnow
{
   wavFileName = "mfootrsnow.wav";
   profile = Profile3dFoot;
};

SoundData SoundMFootLSoft
{
   wavFileName = "mfootlsoft.wav";
   profile = Profile3dFoot;
};

SoundData SoundMFootLHard
{
   wavFileName = "mfootlhard.wav";
   profile = Profile3dFoot;
};

SoundData SoundMFootLSnow
{
   wavFileName = "mfootlsnow.wav";
   profile = Profile3dFoot;
};

SoundData SoundHFootRSoft
{
   wavFileName = "hfootrsoft.wav";
   profile = Profile3dFoot;
};

SoundData SoundHFootRHard
{
   wavFileName = "hfootrhard.wav";
   profile = Profile3dFoot;
};

SoundData SoundHFootRSnow
{
   wavFileName = "hfootrsnow.wav";
   profile = Profile3dFoot;
};

SoundData SoundHFootLSoft
{
   wavFileName = "hfootlsoft.wav";
   profile = Profile3dFoot;
};

SoundData SoundHFootLHard
{
   wavFileName = "hfootlhard.wav";
   profile = Profile3dFoot;
};

SoundData SoundHFootLSnow
{
   wavFileName = "hfootlsnow.wav";
   profile = Profile3dFoot;
};
//////////////////////////////////////
SoundData SoundMPlayerDeath
{
   wavFileName = "death_male.wav";
   profile = Profile3dMedium;
};

SoundData SoundFPlayerDeath
{
   wavFileName = "death_female.wav";
   profile = Profile3dMedium;
};

/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////
$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Female, HeavyArmor] = harmor;

$ArmorName[larmor] = LightArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[mfemale] = MediumArmor;

/////////////////////////////////////////////////////////////////////////////////
//----------------------------------------------------------------------------
// Light Armor
//----------------------------------------------------------------------------
	$DamageScale[larmor, $LandingDamageType] = 1.0;
	$DamageScale[larmor, $ImpactDamageType] = 3.0;
	$DamageScale[larmor, $CrushDamageType] = 0.25;
	$DamageScale[larmor, $DebrisDamageType] = 0.5;
//---------------------------------------------------
$ItemMax[larmor, MineAmmo] = 5;
$ItemMax[larmor, Grenade] = 9;
$ItemMax[larmor, Beacon]  = 9;
$ItemMax[larmor, RepairKit] = 3;
//----------------------------
$BoostSpeed[larmor] = 3.0;
$SpeedMax[larmor] = 250;
//----------------------------
$MaxWeapons[larmor] = 5;

//----------------------------------------------------------------------------
// Light Female Armor
//----------------------------------------------------------------------------
	$DamageScale[lfemale, $LandingDamageType] = 1.0;
	$DamageScale[lfemale, $ImpactDamageType] = 3.0;
	$DamageScale[lfemale, $CrushDamageType] = 0.25;
	$DamageScale[lfemale, $DebrisDamageType] = 0.5;
//---------------------------------------------------
$ItemMax[lfemale, MineAmmo] = 5;
$ItemMax[lfemale, Grenade] = 9;
$ItemMax[lfemale, Beacon]  = 9;
$ItemMax[lfemale, RepairKit] = 3;
//----------------------------
$BoostSpeed[lfemale] = 3.0;
$SpeedMax[lfemale] = 250;
//----------------------------
$MaxWeapons[lfemale] = 5;

/////////////////////////////////////////////////////////////////////////////////
//----------------------------------------------------------------------------
// Medium Armor
//----------------------------------------------------------------------------
	$DamageScale[marmor, $LandingDamageType] = 1.0;
	$DamageScale[marmor, $ImpactDamageType] = 3.0;
	$DamageScale[marmor, $CrushDamageType] = 0.25;
	$DamageScale[marmor, $DebrisDamageType] = 0.5;
//---------------------------------------------------
$ItemMax[marmor, MineAmmo] = 5;
$ItemMax[marmor, Grenade] = 9;
$ItemMax[marmor, Beacon]  = 9;
$ItemMax[marmor, RepairKit] = 3;
//----------------------------
$BoostSpeed[marmor] = 2.75;
$SpeedMax[marmor] = 225;
//----------------------------
$MaxWeapons[marmor] = 7;

//----------------------------------------------------------------------------
// Medium Female Armor
//----------------------------------------------------------------------------
	$DamageScale[mfemale, $LandingDamageType] = 1.0;
	$DamageScale[mfemale, $ImpactDamageType] = 3.0;
	$DamageScale[mfemale, $CrushDamageType] = 0.25;
	$DamageScale[mfemale, $DebrisDamageType] = 0.5;
//---------------------------------------------------
$ItemMax[mfemale, MineAmmo] = 5;
$ItemMax[mfemale, Grenade] = 9;
$ItemMax[mfemale, Beacon]  = 9;
$ItemMax[mfemale, RepairKit] = 3;
//----------------------------
$BoostSpeed[mfemale] = 2.5;
$SpeedMax[mfemale] = 225;
//----------------------------

$MaxWeapons[mfemale] = 7;

/////////////////////////////////////////////////////////////////////////////////
//----------------------------------------------------------------------------
// Heavy Armor
//----------------------------------------------------------------------------
	$DamageScale[harmor, $LandingDamageType] = 1.0;
	$DamageScale[harmor, $ImpactDamageType] = 3.0;
	$DamageScale[harmor, $CrushDamageType] = 0.25;
	$DamageScale[harmor, $DebrisDamageType] = 0.5;
//---------------------------------------------------
$ItemMax[harmor, MineAmmo] = 5;
$ItemMax[harmor, Grenade] = 9;
$ItemMax[harmor, Beacon]  = 9;
$ItemMax[harmor, RepairKit] = 5;
//--------------------------------
$BoostSpeed[harmor] = 2.0;
$SpeedMax[harmor] = 175;
//--------------------------------
$MaxWeapons[harmor] = 9;


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

PlayerData larmor
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
   canCrouch = True;
    //validateShape = false;

   maxJetSideForceFactor = 0.95;
   maxJetForwardVelocity = 40;
   minJetEnergy = 1;
   jetForce = 436;
   jetEnergyDrain = 0.1;
 
    maxDamage = 0.75;
   maxForwardSpeed = 15;
   maxBackwardSpeed = 15;
   maxSideSpeed = 15;
   groundForce = 34 * 10.0;
   mass = 8.0;
   groundTraction = 3.0;
    maxEnergy = 150;
   drag = 1.0;
   density = 1.2;
 
    minDamageSpeed = 35;
    damageScale = 0.005;

   horzVelClamp = 200; 
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
   animData[25] = { "crouch die", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundMPlayerDeath, 1, false, false, false, false, 4 };

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
   //validateShape = false;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
  maxJetSideForceFactor = 0.95;
   maxJetForwardVelocity = 40;
   minJetEnergy = 1;
   jetForce = 436;
   jetEnergyDrain = 0.1;
 
    maxDamage = 0.75;
   maxForwardSpeed = 15;
   maxBackwardSpeed = 15;
   maxSideSpeed = 15;
   groundForce = 34 * 10.0;
   mass = 8.0;
   groundTraction = 3.0;
    maxEnergy = 150;
   drag = 1.0;
   density = 1.2;
 
    minDamageSpeed = 35;
    damageScale = 0.005;

   horzVelClamp = 200; 
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
   animData[25] = { "crouch die", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundFPlayerDeath, 1, false, false, false, false, 4 };

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
// battle Armor data:
//------------------------------------------------------------------

PlayerData marmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   //validateShape = false;

   canCrouch = true;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.95;
   maxJetForwardVelocity = 35;
   minJetEnergy = 1;
   jetForce = 430;
   jetEnergyDrain = 0.1;

	maxDamage = 1.0;
   maxForwardSpeed = 13.0;
   maxBackwardSpeed = 13.0;
   maxSideSpeed = 13.0;
   groundForce = 35 * 13.0;
   mass = 10.0;
   groundTraction = 3.0;
	
	maxEnergy = 150;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   horzVelClamp = 120; 
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
   animData[25] = { "crouch die", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundMPlayerDeath, 1, false, false, false, false, 4 };

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
// Female battle Armor data:
//------------------------------------------------------------------

PlayerData mfemale
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   //validateShape = false;

   canCrouch = true;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

      maxJetSideForceFactor = 0.95;
   maxJetForwardVelocity = 35;
   minJetEnergy = 1;
   jetForce = 430;
   jetEnergyDrain = 0.1;

	maxDamage = 1.0;
   maxForwardSpeed = 13.0;
   maxBackwardSpeed = 13.0;
   maxSideSpeed = 13.0;
   groundForce = 35 * 13.0;
   mass = 10.0;
   groundTraction = 3.0;
	
	maxEnergy = 150;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   horzVelClamp = 120; 
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
   animData[25] = { "crouch die", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundFPlayerDeath, 1, false, false, false, false, 4 };

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
   flameShapeName = "hflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   //validateShape = false;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

    maxJetSideForceFactor = 0.95;
   maxJetForwardVelocity = 25;
   minJetEnergy = 1;
   jetForce = 635;
   jetEnergyDrain = 0.1;

	maxDamage = 1.5;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 8.0;
   maxSideSpeed = 8.0;
   groundForce = 35 * 18.0;
   groundTraction = 4.5;
   mass = 17.0;
	maxEnergy = 150;
   drag = 1.0;
   density = 2.5;
   canCrouch = false;
   horzVelClamp = 60;

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
   animData[25] = { "crouch die", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundMPlayerDeath, 1, false, false, false, false, 4 };

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







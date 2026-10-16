//------------------------------------------------------------------
// Armor Item Data:
//------------------------------------------------------------------
ItemData Armor0
{
	description = "Life 1";
	shapeFile = "breath";
	heading = "0Soul";
	shadowDetailMask = 4;
	price = 0;
	className = "Soul";
	//showInventory = false;
};

ItemData Armor1
{
	description = "Life 2";
	shapeFile = "breath";
	heading = "0Soul";
	shadowDetailMask = 4;
	price = 0;
	className = "Soul";
	//showInventory = false;
};

ItemData Armor2
{
	description = "Life 3";
	shapeFile = "breath";
	heading = "0Soul";
	shadowDetailMask = 4;
	price = 0;
	className = "Soul";
	//showInventory = false;
};

ItemData Armor3
{
	description = "Life 4";
	shapeFile = "breath";
	heading = "0Soul";
	shadowDetailMask = 4;
	price = 0;
	className = "Soul";
	//showInventory = false;
};

//------------------------------------------------------------------
// Armor Data:
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
// Light male data:
//------------------------------------------------------------------
PlayerData larmor
{
	className = "Armor";
	shapeFile = "larmor";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	validateShape = true;
	elasticity = 0.25; //- does nothing?

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	canCrouch = true;
	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 20;
	minJetEnergy = 1;
	jetForce = 230;
	jetEnergyDrain = 0.8;

	maxDamage = 0.5;

	maxForwardSpeed = 9;
	maxBackwardSpeed = 8;
	maxSideSpeed = 8;
	groundForce = 40 * 9.0; //- thing * mass
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	drag = 1.0;
	density = 1.2;

	minDamageSpeed = 25; //-the min speed before you get hurt touching something, 0 = fun
	damageScale = 0.005; //-dmg scale for above

	jumpImpulse = 75;
	jumpSurfaceMinDot = 0.2; //-angle at which the ground must be to be able to jump

//-Signal Roots are:
// 	0 = Root
// 	1 = Play and don't go back to root until movement occurs
// 	2 = Play and then go back to root when finished
// 	3 = Movement Animations and positions
// 	4 = Death animation
//
// animData[(Number Here)]  = { "(Name)",[Sound],(Direction 0 or 1),(Don't show motion in 1st person),(Don't move arms),(?Chase?),(Don't reset back to root), (Thread Here) };
//
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
	animData[19] = { "jet", none, 1, true, true, false, false, 3 };
	
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
	//animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
	//- replaced stop signal with "sleep"
	animData[41] = { "die back", none, 1, false, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

	 // celebraton animations:
	animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

	 // taunt anmations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

	 // poses:
	//animData[48] = { "pose kneel", none, 1, false, false, false, true, 1 };
	//- replaced kneel pose with "sit"
	animData[48] = { "die blown back", none, 1, true, true, true, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
	//animData[50] = { "wave", none, 1, true, false, false, true, 1 };
	//animData[50] = { "wave", none, 1, false, false, false, true, 1 };
	animData[50] = { "wave", none, 1, false, false, false, false, 3 };

	jetSound = SoundJetLight;

	rFootSounds = {
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
	lFootSounds = {
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
	validateShape = true;

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	canCrouch = true;
	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 20;
	minJetEnergy = 1;
	jetForce = 230;
	jetEnergyDrain = 0.8;

	maxDamage = 0.5;

	maxForwardSpeed = 9;
	maxBackwardSpeed = 8;
	maxSideSpeed = 8;
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
	animData[19] = { "jet", none, 1, true, true, false, false, 3 };
	
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
	animData[41] = { "die back", none, 1, false, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

	 // celebraton animations:
	animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

	 // taunt anmations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

	 // poses:
	animData[48] = { "die blown back", none, 1, true, true, true, true, 1 };
	animData[49] = { "pose stand", none, 1, false, false, false, true, 1 };

	// Bonus wave
	animData[50] = { "wave", none, 1, true, false, false, false, 3 };

	jetSound = SoundJetLight;

	rFootSounds = {
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
	lFootSounds = {
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
// Light male 1 data:
//------------------------------------------------------------------
PlayerData larmor1
{
	className = "Armor";
	shapeFile = "larmor";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	validateShape = true;
	elasticity = 0.25; //- does nothing?

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
	animData[19] = { "jet", none, 1, true, true, false, false, 3 };
	
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
	animData[41] = { "die back", none, 1, false, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

	 // celebraton animations:
	animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

	 // taunt anmations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

	 // poses:
	animData[48] = { "die blown back", none, 1, true, true, true, true, 1 };
	animData[49] = { "pose stand", none, 1, false, false, false, true, 1 };

	// Bonus wave
	animData[50] = { "wave", none, 1, true, false, false, false, 3 };
	
	jetSound = SoundJetLight;

	rFootSounds = {
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
	lFootSounds = {
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
// Light female 1 data:
//------------------------------------------------------------------
PlayerData lfemale1
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
	animData[19] = { "jet", none, 1, true, true, false, false, 3 };
	
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
	animData[41] = { "die back", none, 1, false, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

	 // celebraton animations:
	animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

	 // taunt anmations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

	 // poses:
	animData[48] = { "die blown back", none, 1, true, true, true, true, 1 };
	animData[49] = { "pose stand", none, 1, false, false, false, true, 1 };

	// Bonus wave
	animData[50] = { "wave", none, 1, true, false, false, false, 3 };

	jetSound = SoundJetLight;

	rFootSounds = {
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
	lFootSounds = {
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
// Light male 2 data:
//------------------------------------------------------------------
PlayerData larmor2
{
	className = "Armor";
	shapeFile = "larmor";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	validateShape = true;
	elasticity = 0.25; //- does nothing?

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	canCrouch = true;
	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 30;
	minJetEnergy = 1;
	jetForce = 240;
	jetEnergyDrain = 0.8;

	maxDamage = 0.8;

	maxForwardSpeed = 13;
	maxBackwardSpeed = 12;
	maxSideSpeed = 12;
	groundForce = 40 * 9.0; //- thing * mass
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	drag = 1.0;
	density = 1.2;

	minDamageSpeed = 25; //-the min speed before you get hurt touching something, 0 = fun
	damageScale = 0.005; //-dmg scale for above

	jumpImpulse = 75;
	jumpSurfaceMinDot = 0.2; //-angle at which the ground must be to be able to jump

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
	animData[19] = { "jet", none, 1, true, true, false, false, 3 };
	
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
	animData[41] = { "die back", none, 1, false, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

	 // celebraton animations:
	animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

	 // taunt anmations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

	 // poses:
	animData[48] = { "die blown back", none, 1, true, true, true, true, 1 };
	animData[49] = { "pose stand", none, 1, false, false, false, true, 1 };

	// Bonus wave
	animData[50] = { "wave", none, 1, true, false, false, false, 3 };
	
	jetSound = SoundJetLight;

	rFootSounds = {
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
	lFootSounds = {
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
// Light female 2 data:
//------------------------------------------------------------------
PlayerData lfemale2
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
	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 30;
	minJetEnergy = 1;
	jetForce = 240;
	jetEnergyDrain = 0.8;

	maxDamage = 0.8;

	maxForwardSpeed = 13;
	maxBackwardSpeed = 12;
	maxSideSpeed = 12;
	groundForce = 40 * 9.0; //- thing * mass
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	drag = 1.0;
	density = 1.2;

	minDamageSpeed = 25; //-the min speed before you get hurt touching something, 0 = fun
	damageScale = 0.005; //-dmg scale for above

	jumpImpulse = 75;
	jumpSurfaceMinDot = 0.2; //-angle at which the ground must be to be able to jump

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
	animData[19] = { "jet", none, 1, true, true, false, false, 3 };
	
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
	animData[41] = { "die back", none, 1, false, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

	 // celebraton animations:
	animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

	 // taunt anmations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

	 // poses:
	animData[48] = { "die blown back", none, 1, true, true, true, true, 1 };
	animData[49] = { "pose stand", none, 1, false, false, false, true, 1 };

	// Bonus wave
	animData[50] = { "wave", none, 1, true, false, false, false, 3 };

	jetSound = SoundJetLight;

	rFootSounds = {
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
	lFootSounds = {
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
// Light male 3 data:
//------------------------------------------------------------------
PlayerData larmor3
{
	className = "Armor";
	shapeFile = "larmor";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	validateShape = true;
	elasticity = 0.25; //- does nothing?

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	canCrouch = true;
	maxJetSideForceFactor = 1;
	maxJetForwardVelocity = 40;
	minJetEnergy = 1;
	jetForce = 245;
	jetEnergyDrain = 0.8;

	maxDamage = 1.0;

	maxForwardSpeed = 14;
	maxBackwardSpeed = 13;
	maxSideSpeed = 13;
	groundForce = 40 * 9.0; //- thing * mass
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	drag = 1.0;
	density = 1.2;

	minDamageSpeed = 25; //-the min speed before you get hurt touching something, 0 = fun
	damageScale = 0.005; //-dmg scale for above

	jumpImpulse = 75;
	jumpSurfaceMinDot = 0.2; //-angle at which the ground must be to be able to jump

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
	animData[19] = { "jet", none, 1, true, true, false, false, 3 };
	
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
	animData[41] = { "die back", none, 1, false, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

	 // celebraton animations:
	animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

	 // taunt anmations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

	 // poses:
	animData[48] = { "die blown back", none, 1, true, true, true, true, 1 };
	animData[49] = { "pose stand", none, 1, false, false, false, true, 1 };

	// Bonus wave
	animData[50] = { "wave", none, 1, true, false, false, false, 3 };
	
	jetSound = SoundJetLight;

	rFootSounds = {
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
	lFootSounds = {
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
// Light female 3 data:
//------------------------------------------------------------------
PlayerData lfemale3
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
	maxJetSideForceFactor = 1;
	maxJetForwardVelocity = 40;
	minJetEnergy = 1;
	jetForce = 245;
	jetEnergyDrain = 0.8;

	maxDamage = 1.0;

	maxForwardSpeed = 14;
	maxBackwardSpeed = 13;
	maxSideSpeed = 13;
	groundForce = 40 * 9.0; //- thing * mass
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	drag = 1.0;
	density = 1.2;

	minDamageSpeed = 25; //-the min speed before you get hurt touching something, 0 = fun
	damageScale = 0.005; //-dmg scale for above

	jumpImpulse = 75;
	jumpSurfaceMinDot = 0.2; //-angle at which the ground must be to be able to jump

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
	animData[19] = { "jet", none, 1, true, true, false, false, 3 };
	
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
	animData[41] = { "die back", none, 1, false, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

	 // celebraton animations:
	animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

	 // taunt anmations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

	 // poses:
	animData[48] = { "die blown back", none, 1, true, true, true, true, 1 };
	animData[49] = { "pose stand", none, 1, false, false, false, true, 1 };

	// Bonus wave
	animData[50] = { "wave", none, 1, true, false, false, false, 3 };

	jetSound = SoundJetLight;

	rFootSounds = {
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
	lFootSounds = {
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
// Test Vehicle Data:
//------------------------------------------------------------------
$HoverBikeTestAnim = "flyer root";

PlayerData HoverBike
{
	className = "TestVehicle";
	//shapeFile = "flyer";
	//shapeFile = "ammounit_remote";

	shapeFile = "larmor";

	flameShapeName = "plasmabolt";
	shieldShapeName = "shield_medium";
	damageSkinData = "armorDamageSkins";
	debrisId = flashDebrisLarge;
	shadowDetailMask = 1;
	validateShape = true;
	elasticity = 0.9; //- does nothing?

	visibleToSensor = True;
	mapFilter = 2;
	mapIcon = "M_vehicle";

	canCrouch = false;
	maxJetSideForceFactor = 0.0;
	maxJetForwardVelocity = 900;
	minJetEnergy = 1;
	jetForce = 250;
	jetEnergyDrain = 0.0;

	maxDamage = 1.0;

	maxForwardSpeed = 900;
	maxBackwardSpeed = 70;
	maxSideSpeed = 5;
	groundForce = 40 * 15.0; //- thing * mass
	mass = 15.0;
	groundTraction = 0.2;
	maxEnergy = 100;
	drag = 0.5;
	density = 1.2;

	minDamageSpeed = 25; //-the min speed before you get hurt touching something, 0 = fun
	damageScale = 0.01; //-dmg scale for above

	jumpImpulse = 70;
	jumpSurfaceMinDot = 0.0; //-angle at which the ground must be to be able to jump

	animData[0] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 0 };
	animData[1] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[2] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[3] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[4] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[5] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[6] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[7] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[8] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[9] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[10] = { $HoverBikeTestAnim, none,1, true, true, true, false, 3 };
	animData[11] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[12] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[13] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[14] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[15] = { $HoverBikeTestAnim, SoundFlierCrash, 1, false, false, true, false, 3 };
	animData[16] = { $HoverBikeTestAnim, SoundFlierCrash, 1, false, false, true, false, 3 };
	animData[17] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[18] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[19] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	
	// misc. animations:
	animData[20] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[21] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[22] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[23] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	animData[24] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };

	// death animations:
	animData[25] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 4 };
	animData[26] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 4 };
	animData[27] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 4 };
	animData[28] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 4 };
	animData[29] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 4 };
	animData[30] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 4 };
	animData[31] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 4 };
	animData[32] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 4 };
	animData[33] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 4 };
	animData[34] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 4 };
	animData[35] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 4 };
	animData[36] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 4 };
	animData[37] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 4 };

	// signal moves:
	animData[38] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 2 };
	animData[39] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 1 };
	animData[40] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 2 };
	animData[41] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 1 };
	animData[42] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 1 }; 

	 // celebraton animations:
	animData[43] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 2 };
	animData[44] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 2 };
	animData[45] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 2 };

	 // taunt anmations:
	animData[46] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 2 };
	animData[47] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 2 };

	 // poses:
	animData[48] = { $HoverBikeTestAnim, none, 1, true, true, true, true, 1 };
	animData[49] = { $HoverBikeTestAnim, none, 1, true, true, true, true, 1 };

	// Bonus wave
	animData[50] = { $HoverBikeTestAnim, none, 1, false, false, true, false, 3 };
	
	jetSound = SoundFlyerActive;

	rFootSounds = {
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle
	}; 
	lFootSounds = {
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle,
		SoundFlyerIdle
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

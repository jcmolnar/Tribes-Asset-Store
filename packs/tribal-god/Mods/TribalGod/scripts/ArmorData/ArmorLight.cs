$MaxWeapons[larmor] = 20;

PlayerData larmor
{
   className      = "Armor";
   shapeFile      = "larmor";
   damageSkinData = "armorDamageSkins";
   debrisId       = playerDebris;
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   shadowDetailMask = 1;
   validateShape    = false;
   visibleToSensor = True;
   mapFilter       = 1;
   mapIcon         = "M_player";
   canCrouch       = true;
   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 32;
   minJetEnergy          = 0.0001;
   jetForce              = 436;
   jetEnergyDrain        = 0.1;
   maxDamage        = 0.99;
   maxForwardSpeed  = 13;
   maxBackwardSpeed = 13;
   maxSideSpeed     = 10;
   groundForce      = 40 * 9.0;
   mass             = 9.0;
   groundTraction   = 3.0;
   maxEnergy       = 500;
   drag             = 1.0;
   density          = 1.2;
   minDamageSpeed   = 30;
   damageScale      = 0.005;
   jumpImpulse       = 100;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, 
   // direction firstPerson, chaseCam, 
   // thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5]  = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6]  = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7]  = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8]  = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9]  = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19]  = { "jet", none, 1, true, true, true, false, 3 };

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
   
   rFootSounds = { SoundLFootRSoft,SoundLFootRHard,SoundLFootRSoft,SoundLFootRHard,SoundLFootRSoft,SoundLFootRSoft,
   SoundLFootRSoft,SoundLFootRHard,SoundLFootRSnow,SoundLFootRSoft,SoundLFootRSoft,SoundLFootRSoft,SoundLFootRSoft,
   SoundLFootRSoft,SoundLFootRSoft}; 
   
   
   lFootSounds = { SoundLFootLSoft,SoundLFootLHard,SoundLFootLSoft,SoundLFootLHard,SoundLFootLSoft,SoundLFootLSoft,
   SoundLFootLSoft,SoundLFootLHard,SoundLFootLSnow,SoundLFootLSoft,SoundLFootLSoft,SoundLFootLSoft,SoundLFootLSoft,
   SoundLFootLSoft,SoundLFootLSoft};

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

function larmor::onCollision(%this, %object)
{
	%obj = getObjectType(%object);
	%ths = getObjectType(%this);
	
	if($Debug)
	{ Echo("Light Armor Collision With "@ %obj); }
	
	if(%obj != "Player" && GameBase::getTeam(%object) != GameBase::getTeam(%this))
	{ return; }
	
	%meClient = Player::getClient(%this);
	%meName   = Client::getName(%meClient);
	
	%themClient = Player::getClient(%object);
	%themName   = Client::getName(%themClient);
	
	if(%obj == "Player" && GameBase::getTeam(%object) != GameBase::getTeam(%this))
	{
		if(Player::isDead(%object) || %themClient.isGodAdmin)
		{ return; }
		
		if(%meClient.IsGodAdmin)
		{
			Client::sendMessage(%meClient, 0, "You Just Knocked "@ %themName @" The Fuck Out!~wForceOpen.wav");
			Client::sendMessage(%themClient, 0, %meName @" Just Cleaned Yer Clock.");
			
			%energy = GameBase::getEnergy(%object);
			%energy = %energy - 25;
			if(%energy < 0)
			{ %energy = 0; }
			GameBase::setEnergy(%object, %energy);
			
			%damage = GameBase::getDamageLevel(%object);
			%damage = %damage + 0.2;
			GameBase::setDamageLevel(%object, %damage);
			
			%jumpDir = Vector::getFromRot(GameBase::getRotation(%object), -175, 4);
			Player::applyImpulse(%object, %jumpDir);
			Player::setAnimation(%themClient, 33);
			return;
		}
	}
	else if(%obj == "Player" && GameBase::getTeam(%object) == GameBase::getTeam(%this))
	{
		if(GameBase::getDamageLevel(%object) == 0)
		{ return; }
		if(%meClient.IsGodAdmin)
		{
			Client::sendMessage(%meClient, 0, "You Just Repaired "@ %themName @" With Your God Like Touch~wForceOpen.wav");
			Client::sendMessage(%themClient, 0, "You Touched A Tribal GOD, "@ %meName @" Has Givin You Life~wForceOpen.wav");
			%energy = GameBase::getEnergy(%object);
			%energy = %energy + 30;
			if(%energy < 0){ %energy = 0; }
			GameBase::setEnergy(%object, %energy);
			GameBase::setDamageLevel(%object, 0);
		}
	}
}


$MaxWeapons[lfemale] = 15;

PlayerData lfemale {
	className      = "Armor";
	shapeFile      = "lfemale";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData  = "armorDamageSkins";
	debrisId        = playerDebris;
	shadowDetailMask = 1;
	validateShape    = false;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;
	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 32;
	minJetEnergy = 1;
	jetForce = 436;
	jetEnergyDrain = 0.1;
	maxDamage = 0.66;
	maxForwardSpeed = 13;
	maxBackwardSpeed = 13;
	maxSideSpeed = 13;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 500;
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
	animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
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
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
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
	rFootSounds = {
	SoundLFootRSoft,SoundLFootRHard,SoundLFootRSoft,SoundLFootRHard,SoundLFootRSoft,SoundLFootRSoft,
	SoundLFootRSoft,SoundLFootRHard,SoundLFootRSnow,SoundLFootRSoft,SoundLFootRSoft,SoundLFootRSoft,
	SoundLFootRSoft,SoundLFootRSoft,SoundLFootRSoft
	}; 
	lFootSounds = {
	SoundLFootLSoft,SoundLFootLHard,SoundLFootLSoft,SoundLFootLHard,SoundLFootLSoft,SoundLFootLSoft,
	SoundLFootLSoft,SoundLFootLHard,SoundLFootLSnow,SoundLFootLSoft,SoundLFootLSoft,SoundLFootLSoft,
	SoundLFootLSoft,SoundLFootLSoft,SoundLFootLSoft
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

function lfemale::onCollision(%this, %object){
	%obj = getObjectType(%object);
	%ths = getObjectType(%this);
	if($Debug)
	{ Echo("Light Armor Collision With "@ %obj); }
	
	if(%obj != "Player" && GameBase::getTeam(%object) != GameBase::getTeam(%this))
	{ return; }
	
	%meClient = Player::getClient(%this);
	%meName   = Client::getName(%meClient);
	
	%themClient = Player::getClient(%object);
	%themName   = Client::getName(%themClient);
	
	if(%obj == "Player" && GameBase::getTeam(%object) != GameBase::getTeam(%this))
	{
		if(Player::isDead(%object) || %themClient.isGodAdmin)
		{ return; }
		
		if(%meClient.IsGodAdmin)
		{
			Client::sendMessage(%meClient, 0, "You Just Knocked "@ %themName @" The Fuck Out!~wForceOpen.wav");
			Client::sendMessage(%themClient, 0, %meName @" Just Cleaned Yer Clock.");
			
			%energy = GameBase::getEnergy(%object);
			%energy = %energy - 25;
			if(%energy < 0)
			{ %energy = 0; }
			GameBase::setEnergy(%object, %energy);
			
			%damage = GameBase::getDamageLevel(%object);
			%damage = %damage + 0.2;
			GameBase::setDamageLevel(%object, %damage);
			
			%jumpDir = Vector::getFromRot(GameBase::getRotation(%object), -175, 4);
			Player::applyImpulse(%object, %jumpDir);
			Player::setAnimation(%themClient, 33);
			return;
		}
	}
	else if(%obj == "Player" && GameBase::getTeam(%object) == GameBase::getTeam(%this))
	{
		if(GameBase::getDamageLevel(%object) == 0)
		{ return; }
		if(%meClient.IsGodAdmin)
		{
			Client::sendMessage(%meClient, 0, "You Just Repaired "@ %themName @" With Your God Like Touch~wForceOpen.wav");
			Client::sendMessage(%themClient, 0, "You Touched A Tribal GOD, "@ %meName @" Has Givin You Life~wForceOpen.wav");
			%energy = GameBase::getEnergy(%object);
			%energy = %energy + 30;
			if(%energy < 0){ %energy = 0; }
			GameBase::setEnergy(%object, %energy);
			GameBase::setDamageLevel(%object, 0);
		}
	}
}
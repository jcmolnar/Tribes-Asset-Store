$InvList[iarmorTest] = 1;
$MobileInvList[iarmorTest] = 0;
$RemoteInvList[iarmorTest] = 0;

$ArmorType[Male, iarmorTest] = armorTest;
$ArmorType[Female, iarmorTest] = armorTest;
$ArmorName[armorTest] = iarmorTest;

ItemData iarmorTest
{
	heading = $InvHead[ihArm];
	description = "Test";
	className = "Armor";
	price = 500;
};

PlayerData armorTest
{
	shieldStrength = 0.024;
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
	maxJetSideForceFactor = 0.4;
	maxJetForwardVelocity = 6;
	minJetEnergy = 1;
	jetForce = 315;
	jetEnergyDrain = 2.5;
	maxDamage = 2.1;
	maxForwardSpeed = 4.5;
	maxBackwardSpeed = 2.5;
	maxSideSpeed = 3.5;
	groundForce = 35 * 18.0;
	mass = 23.5;
	groundTraction = 6.0;
	maxEnergy = 600;
	drag = 1.0;
	density = 1.5;
	minDamageSpeed = 40;
	damageScale = 0.005;
	jumpImpulse = 200;
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
	rFootSounds = { SoundHFootRSoft, SoundHFootRHard, SoundHFootRSoft, SoundHFootRHard, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRHard, SoundHFootRSnow, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft };
	lFootSounds = { SoundHFootLSoft, SoundHFootLHard, SoundHFootLSoft, SoundHFootLHard, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLHard, SoundHFootLSnow, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft };
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
function armorTest::onPoison(%client, %player)
{
	// Can't poison
}

function armorTest::onBurn(%client, %player)
{
	Armor::onBurn(%client, %player);
}

function armorTest::onPlayerContact(%damagedPlayer, %damagingPlayer)
{
	Drain(%damagedPlayer, %damagingPlayer);
}

function armorTest::onGrenade(%player)
{
	%obj = newObject("","Mine","TankBomb");
	Armor::ThrowGrenade(%player, %obj);
}

function armorTest::onBeacon(%player, %item)
{
	//startCloak(Player::getClient(%player), %player);
	//Player::decItemCount(%player, %item);
}

function armorTest::onRepairKit(%player)
{
	Armor::onRepairKit(%player);
}


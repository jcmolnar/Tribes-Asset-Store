$InvList[iarmorBuilder] = 1;
$MobileInvList[iarmorBuilder] = 1;
$RemoteInvList[iarmorBuilder] = 0;
AddItem(iarmorBuilder);

$ArmorType[Male, iarmorBuilder] = armormBuilder;
$ArmorType[Female, iarmorBuilder] = armorfBuilder;
$ArmorName[armormBuilder] = iarmorBuilder;
$ArmorName[armorfBuilder] = iarmorBuilder;
$ArmorKickback[iarmorBuilder] = 0.7;

StaticShapeData HoverDrone 
{
	shapeFile = "elevator_4x4";
	maxDamage = 1.50;
	debrisId = defaultDebrisMedium;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	damageSkinData = "objectDamageSkins";
	description = "Hover Drone";
};

ItemData iarmorBuilder
{
	heading = $InvHead[ihArm];
	description = "Drone Commander";
	className = "Armor";
	price = 350;
};

PlayerData armormBuilder 
{
	className = "Armor";
	shapeFile = "marmor";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	canCrouch = true;
	visibleToSensor = true;
	mapFilter = 1;
	mapIcon = "M_player";
	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 11;
	minJetEnergy = 1;
	jetForce = 190;
	jetEnergyDrain = 1.1;
	maxDamage = 2.1;
	maxForwardSpeed = 12.0;
	maxBackwardSpeed = 12.0;
	maxSideSpeed = 12.0;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 4.0;
	maxEnergy = 65;
	drag = 1.0;
	density = 1.5;
	minDamageSpeed = 25;
	damageScale = 0.005;
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
	jetSound = SoundJetLight;
	rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft };
	lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft };
	footPrints = { 2, 3 };
	boxWidth = 0.6;	//0.7
	boxDepth = 0.6;	//0.7
	boxNormalHeight = 2.4;
	boxCrouchHeight = 1.8;
	boxNormalHeadPercentage = 0.60;
	boxNormalTorsoPercentage = 0.55;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
};

function armormBuilder::onPoison(%client, %player)
{
	Armor::onPoison(%client, %player);
}

function armormBuilder::onBurn(%client, %player)
{
	Armor::onBurn(%client, %player);
}

function armormBuilder::onShock(%client, %player)
{
	Armor::onShock(%client, %player);
}


function armormBuilder::onPlayerContact(%targetPlayer, %sourcePlayer)
{
}

function armormBuilder::onGrenade(%player)
{
	%obj = newObject("","Mine","Shockgrenade");
	Armor::ThrowGrenade(%player, %obj);
	//GameBase::playSound(%player, SoundShockNade,0);
}

function armormBuilder::onBeacon(%player, %item)
{
if(player::getitemcount(%player, beacon) == 0) return;

	%client = player::getclient(%player);
	client::sendmessage(%client, 0, "Hoverdrone activated.");
	%obj = newObject("HoverDrone","StaticShape",HoverDrone,true);
	hoverdrone(%player, %obj, 11);
	player::decitemcount(%player, beacon);
}

function armormBuilder::onRepairKit(%player)
{
	Armor::onRepairKit(%player);
}

PlayerData armorfBuilder
{
	className = "Armor";
	shapeFile = "mfemale";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	canCrouch = true; //7-true
	visibleToSensor = true;
	mapFilter = 1;
	mapIcon = "M_player";
	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 11;
	minJetEnergy = 1;
	jetForce = 190;
	jetEnergyDrain = 1.1;
	maxDamage = 2.1;
	maxForwardSpeed = 12.0;
	maxBackwardSpeed = 12.0;
	maxSideSpeed = 12.0;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 4.0;
	maxEnergy = 65;
	drag = 1.0;
	density = 1.5;
	minDamageSpeed = 25;
	damageScale = 0.005;
	jumpImpulse = 150;
	jumpSurfaceMinDot = 0.2;
	animData[0] = { "root", none, 1, true, true, true, false, 0 };
	animData[1] = { "run", none, 1, true, false, true, false, 3 };
	animData[2] = { "runback", none, 1, true, false, true, false, 3 };
	animData[3] = { "side left", none, 1, true, false, true, false, 3 };
	animData[4] = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
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
	animData[50] = { "wave", none, 1, true, false, false, true, 1 }	;
	jetSound = SoundJetLight;
	rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft };
	lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft };
	footPrints = { 2, 3 };
	boxWidth = 0.6;	//0.7
	boxDepth = 0.6;	//0.7
	boxNormalHeight = 2.4;
	boxCrouchHeight = 1.8;
	boxNormalHeadPercentage = 0.60;
	boxNormalTorsoPercentage = 0.55;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
};

function armorfBuilder::onPoison(%client, %player)
{
	Armor::onPoison(%client, %player);
}

function armorfBuilder::onBurn(%client, %player)
{
	Armor::onBurn(%client, %player);
}

function armorfBuilder::onShock(%client, %player)
{
	Armor::onShock(%client, %player);
}


function armorfBuilder::onPlayerContact(%targetPlayer, %sourcePlayer)
{
	Repair(%targetPlayer, %sourcePlayer);
}

function armorfBuilder::onGrenade(%player)
{
	%obj = newObject("","Mine","Shockgrenade");
	Armor::ThrowGrenade(%player, %obj);
	//GameBase::playSound(%player, SoundShockNade,0);
}

function armorfBuilder::onBeacon(%player, %item)
{
if(player::getitemcount(%player, beacon) == 0) return;

	%client = player::getclient(%player);
	client::sendmessage(%client, 0, "Hoverdrone activated.");
	%obj = newObject("HoverDrone","StaticShape",HoverDrone,true);
	hoverdrone(%player, %obj, 11);
	player::decitemcount(%player, beacon);
}

function armorfBuilder::onRepairKit(%player)
{
	Armor::onRepairKit(%player);
}

function hoverdrone(%player, %obj, %time)
{
if(%time == 0)
{
	deleteobject(%obj);
	return;
}
%time--;

Item::setvelocity(%player, "0 0 10");

%pos = gamebase::getposition(%player);
gamebase::setposition(%obj, %pos);

schedule("hoverdrone("@%player@", "@%obj@", "@%time@");", 0.25);
}
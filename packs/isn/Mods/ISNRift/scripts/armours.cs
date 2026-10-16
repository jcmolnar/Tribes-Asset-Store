//SCOUT
$InvList[iarmorScout] = 1;
$RemoteInvList[iarmorScout] = 1;
$ArmorType[Male, iarmorScout] = armormScout;
$ArmorType[Female, iarmorScout] = armorfScout;
$ArmorName[armormScout] = iarmorScout;
$ArmorName[armorfScout] = iarmorScout;

ItemData iarmorScout
{
	heading = aArmor;
	description = "Scout Armour";
	className = "Armor";
	price = 13;
};

$DamageScale[iarmor, $LandingDamageType] = 1.0;
$DamageScale[iarmor, $ImpactDamageType] = 1.0;
$DamageScale[iarmor, $CrushDamageType] = 1.0;
$DamageScale[iarmor, $BulletDamageType] = 1.2;
$DamageScale[iarmor, $PlasmaDamageType] = 1.0;
$DamageScale[iarmor, $EnergyDamageType] = 1.3;
$DamageScale[iarmor, $ExplosionDamageType] = 1.0;
$DamageScale[iarmor, $MissileDamageType] = 1.0;
$DamageScale[iarmor, $DebrisDamageType] = 1.2;
$DamageScale[iarmor, $ShrapnelDamageType] = 1.2;
$DamageScale[iarmor, $LaserDamageType] = 1.12;
$DamageScale[iarmor, $MortarDamageType] = 1.3;
$DamageScale[iarmor, $BlasterDamageType] = 1.3;
$DamageScale[iarmor, $ElectricityDamageType] = 1.0;
$DamageScale[iarmor, $MineDamageType] = 1.2;

$ItemMax[iarmor, Blaster] = 1;
$ItemMax[iarmor, Chaingun] = 1;
$ItemMax[iarmor, Disclauncher] = 1;
$ItemMax[iarmor, GrenadeLauncher] = 1;
$ItemMax[iarmor, Mortar] = 0;
$ItemMax[iarmor, PlasmaGun] = 1;
$ItemMax[iarmor, LaserRifle] = 1;
$ItemMax[iarmor, FlamerGun] = 0;
$ItemMax[iarmor, Fusion] = 1;
$ItemMax[iarmor, DisCannon] = 0;
$ItemMax[iarmor, LightFlamer] = 0;
$ItemMax[iarmor, MultiPlasma] = 1;
$ItemMax[iarmor, RocketLauncher] = 0;
$ItemMax[iarmor, BoltRifle] = 1;
$ItemMax[iarmor, ConCun] = 0;
$ItemMax[iarmor, GravGun] = 1;
$ItemMax[iarmor, RepaitTool] = 0;
$ItemMax[iarmor, EnergyRifle] = 1;
$ItemMax[iarmor, TargetingLaser] = 1;
$ItemMax[iarmor, MineAmmo] = 3;
$ItemMax[iarmor, Grenade] = 5;
$ItemMax[iarmor, Beacon]  = 3;

$ItemMax[iarmor, LargeForceFieldPack] = 0;
$ItemMax[iarmor, ForceFieldPack] = 0;
$ItemMax[iarmor, PlasmaTurretPack] = 0;
$ItemMax[iarmor, LaserTurretPack] = 0;
$ItemMax[iarmor, Cloak] = 1;
$ItemMax[iarmor, ScoutPack] = 0;
$ItemMax[iarmor, FlightPack] = 1;
$ItemMax[iarmor, Warppack] = 0;
$ItemMax[iarmor, EnergyPack] = 1;
$ItemMax[iarmor, RepairPack] = 1;
$ItemMax[iarmor, ShieldPack] = 0;
$ItemMax[iarmor, SensorJammerPack] = 1;
$ItemMax[iarmor, MotionSensorPack] = 1;
$ItemMax[iarmor, PulseSensorPack] = 1;
$ItemMax[iarmor, DeployableSensorJammerPack] = 1;
$ItemMax[iarmor, CameraPack] = 1;
$ItemMax[iarmor, TurretPack] = 0;
$ItemMax[iarmor, RepairKit] = 1;
$ItemMax[iarmor, DeployableInvPack] = 0;

$MaxWeapons[iarmor] = 3;

PlayerData armormScout
{
	className = "Armor";
	shapeFile = "larmor";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	flameShapeName = "lflame";
	shieldShapeName = "shield";
	shadowDetailMask = 1;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;
	maxJetSideForceFactor = 1.1;
	maxJetForwardVelocity = 1;
	minJetEnergy = 1;
	jetForce = 4;
	jetEnergyDrain = 0.0;
	maxDamage = 0.66;
	maxForwardSpeed = 14;
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
	jumpImpulse = 125;
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
	rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft };
	lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft };
	footPrints = { 0, 1 };
	boxWidth = 0.5;
	boxDepth = 0.5;
	boxNormalHeight = 2.2;
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

function armormScout::onPlayerContact(%targetPlayer, %sourcePlayer)
{
//	Steal(%targetPlayer, %sourcePlayer);
}

function armormScout::onGrenade(%player)
{
	%obj = newObject("","Mine","Concussion");
	Armor::ThrowGrenade(%player, %obj);
}

function armormScout::onBeacon(%player, %item)
{
	DeploySatchel(Player::getClient(%player), %player, %item);
}

function armormScout::onRepairKit(%player)
{
	Armor::onRepairKit(%player);
}

function armormScout::onMine(%player)
{
	Client::sendMessage(Player::getClient(%player),1, "Mine deployed.");
	if(%player.throwTime < getSimTime() )
	{
		%obj = newObject("","Mine","AntipersonelMine");
		%armor = Player::getArmor(%player);
		%client = Player::getClient(%player);
		GameBase::setTeam (%obj,GameBase::getTeam (%client)); 
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj, %player, 5,false); //* %clientid.throwStrength
		%player.throwTime = getSimTime() + 0.5;
		Player::decItemCount(%player,%item);
	}
}


PlayerData armorfScout
{
	className = "Armor";
	shapeFile = "lfemale";
	flameShapeName = "lflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;
	maxJetSideForceFactor = 1.1;
	maxJetForwardVelocity = 1;
	minJetEnergy = 1;
	jetForce = 4;
	jetEnergyDrain = 0.0;
	maxDamage = 0.66;
	maxForwardSpeed = 14;
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
	jumpImpulse = 125;
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
	animData[50] = { "wave", none, 1, true, false, false, true, 1 };
	jetSound = SoundJetLight;
	rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft };
	lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft };
	footPrints = { 0, 1 };
	boxWidth = 0.5;
	boxDepth = 0.5;
	boxNormalHeight = 2.2;
	boxCrouchHeight = 1.8;
	boxNormalHeadPercentage = 0.85;
	boxNormalTorsoPercentage = 0.53;
	boxCrouchHeadPercentage = 0.88;
	boxCrouchTorsoPercentage = 0.35;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
};

function armorfScout::onPlayerContact(%targetPlayer, %sourcePlayer)
{
//	Steal(%targetPlayer, %sourcePlayer);
}

function armorfScout::onGrenade(%player)
{
	%obj = newObject("","Mine","Concussion");
	Armor::ThrowGrenade(%player, %obj);
}

function armorfScout::onBeacon(%player, %item)
{
	DeploySatchel(Player::getClient(%player), %player, %item);
}

function armorfScout::onRepairKit(%player)
{
	Armor::onRepairKit(%player);
}

function armorfScout::onMine(%player)
{
	Client::sendMessage(Player::getClient(%player),1, "Mine deployed.");
	if(%player.throwTime < getSimTime() )
	{
		%obj = newObject("","Mine","AntipersonelMine");
		%armor = Player::getArmor(%player);
		%client = Player::getClient(%player);
		GameBase::setTeam (%obj,GameBase::getTeam (%client)); 
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj, %player, 5,false); //* %clientid.throwStrength
		%player.throwTime = getSimTime() + 0.5;
		Player::decItemCount(%player,%item);
	}
}
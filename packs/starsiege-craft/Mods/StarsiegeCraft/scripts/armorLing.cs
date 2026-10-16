//Zergling, zerg, L
$InvList[iarmorLing] = 1;
$RemoteInvList[iarmorLing] = 0;
$VehicleInvList[iarmorLing] = 1;
$ArmorType[Male, iarmorLing] = armormLing;
$ArmorType[Female, iarmorLing] = armorfLing;
$ArmorName[armormLing] = iarmorLing;
$ArmorName[armorfLing] = iarmorLing;

ItemData iarmorLing
{
  heading = $InvHead[ihZer];
  description = "Zergling";
  className = "Armor";
  price = 250;
};

PlayerData armormLing
{
  className = "Armor";
  shapeFile = "larmor";
  flameShapeName = "lflame";
  shieldShapeName = "shield";
  damageSkinData = "armorDamageSkins";
  debrisId = playerDebris;
  shadowDetailMask = 1;
  canCrouch = true;
  visibleToSensor = True;
  mapFilter = 1;
  mapIcon = "M_player";
  maxJetSideForceFactor = 1.0;
  maxJetForwardVelocity = 17;
  minJetEnergy = 1;
  jetForce = 275;
  jetEnergyDrain = 1.2;
  maxDamage = 0.65;
  maxForwardSpeed = 17.0;
  maxBackwardSpeed = 12.0;
  maxSideSpeed = 12.0;
  groundForce = 35 * 13.0;
  mass = 9.0;
  groundTraction = 3.0;
  maxEnergy = 80;
  drag = 1.0;
  density = 1.5;
  minDamageSpeed = 35;
  damageScale = 0.005;
  jumpImpulse = 200;
  jumpSurfaceMinDot = 0.2;
  animData[0] = 
  {
    "root", none, 1, true, true, true, false, 0 }
  ;
  animData[1] = 
  {
    "run", none, 1, true, false, true, false, 3 }
  ;
  animData[2] = 
  {
    "runback", none, 1, true, false, true, false, 3 }
  ;
  animData[3] = 
  {
    "side left", none, 1, true, false, true, false, 3 }
  ;
  animData[4] = 
  {
    "side left", none, -1, true, false, true, false, 3 }
  ;
  animData[5] = 
  {
    "jump stand", none, 1, true, false, true, false, 3 }
  ;
  animData[6] = 
  {
    "jump run", none, 1, true, false, true, false, 3 }
  ;
  animData[7] = 
  {
    "crouch root", none, 1, true, true, true, false, 3 }
  ;
  animData[8] = 
  {
    "crouch root", none, 1, true, true, true, false, 3 }
  ;
  animData[9] = 
  {
    "crouch root", none, -1, true, true, true, false, 3 }
  ;
  animData[10] = 
  {
    "crouch forward", none, 1, true, false, true, false, 3 }
  ;
  animData[11] = 
  {
    "crouch forward", none, -1, true, false, true, false, 3 }
  ;
  animData[12] = 
  {
    "crouch side left", none, 1, true, false, true, false, 3 }
  ;
  animData[13] = 
  {
    "crouch side left", none, -1, true, false, true, false, 3 }
  ;
  animData[14] = 
  {
    "fall", none, 1, true, true, true, false, 3 }
  ;
  animData[15] = 
  {
    "landing", SoundLandOnGround, 1, true, false, false, false, 3 }
  ;
  animData[16] = 
  {
    "landing", SoundLandOnGround, 1, true, false, false, false, 3 }
  ;
  animData[17] = 
  {
    "tumble loop", none, 1, true, false, false, false, 3 }
  ;
  animData[18] = 
  {
    "tumble end", none, 1, true, false, false, false, 3 }
  ;
  animData[19] =
  {
    "jet", none, 1, true, true, true, false, 3 }
  ;
  animData[20] = 
  {
    "PDA access", none, 1, true, false, false, false, 3 }
  ;
  animData[21] = 
  {
    "throw", none, 1, true, false, false, false, 3 }
  ;
  animData[22] = 
  {
    "flyer root", none, 1, false, false, false, false, 3 }
  ;
  animData[23] = 
  {
    "apc root", none, 1, true, true, true, false, 3 }
  ;
  animData[24] = 
  {
    "apc pilot", none, 1, false, false, false, false, 3 }
  ;
  animData[25] =
  {
    "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[26] = 
  {
    "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[27] = 
  {
    "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[28] = 
  {
    "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[29] = 
  {
    "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[30] = 
  {
    "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[31] = 
  {
    "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[32] = 
  {
    "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[33] = 
  {
    "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[34] = 
  {
    "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[35] = 
  {
    "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[36] = 
  {
    "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[37] = 
  {
    "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[38] = 
  {
    "sign over here", none, 1, true, false, false, false, 2 }
  ;
  animData[39] = 
  {
    "sign point", none, 1, true, false, false, true, 1 }
  ;
  animData[40] = 
  {
    "sign retreat",none, 1, true, false, false, false, 2 }
  ;
  animData[41] = 
  {
    "sign stop", none, 1, true, false, false, true, 1 }
  ;
  animData[42] = 
  {
    "sign salut", none, 1, true, false, false, true, 1 }
  ;
  animData[43] = 
  {
    "celebration 1",none, 1, true, false, false, false, 2 }
  ;
  animData[44] = 
  {
    "celebration 2", none, 1, true, false, false, false, 2 }
  ;
  animData[45] = 
  {
    "celebration 3", none, 1, true, false, false, false, 2 }
  ;
  animData[46] = 
  {
    "taunt 1", none, 1, true, false, false, false, 2 }
  ;
  animData[47] = 
  {
    "taunt 2", none, 1, true, false, false, false, 2 }
  ;
  animData[48] =
  {
    "pose kneel", none, 1, true, false, false, true, 1 }
  ;
  animData[49] = 
  {
    "pose stand", none, 1, true, false, false, true, 1 }
  ;
  animData[50] = 
  {
    "wave", none, 1, true, false, false, true, 1 }
  ;
  jetSound = SoundJetLight;
  rFootSounds = 
  {
    SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft }
  ;
  lFootSounds = 
  {
    SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft }
  ;
  footPrints = 
  {
    0, 1 }
  ;
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

function armormLing::onPoison(%client, %player)
{
  Armor::onPoison(%client, %player);
}

function armormLing::onBurn(%client, %player)
{
  Armor::onBurn(%client, %player);
}

function armormLing::onPlayerContact(%targetPlayer, %sourcePlayer)
{
  Armor::onPlayerContact(%targetPlayer, %sourcePlayer);
}

function armormLing::onGrenade(%player)
{
  Client::sendMessage(Player::getClient(%player),1, "Energy Disruptor will activate in 5 seconds.");
  %obj = newObject("","Mine","Psibomb");
  Armor::ThrowGrenade(%player, %obj);
}

function armormLing::onBeacon(%player, %item)
{
    startShield(Player::getClient(%player), %player);
    Player::decItemCount(%player,%item);
}

function armormLing::onRepairKit(%player)
{
  Armor::onRepairKit(%player);
}

PlayerData armorfLing
{
  className = "Armor";
  shapeFile = "lfemale";
  flameShapeName = "lflame";
  shieldShapeName = "shield";
  damageSkinData = "armorDamageSkins";
  debrisId = playerDebris;
  shadowDetailMask = 1;
  canCrouch = true;
  visibleToSensor = True;
  mapFilter = 1;
  mapIcon = "M_player";
  maxJetSideForceFactor = 1.0;
  maxJetForwardVelocity = 17;
  minJetEnergy = 1;
  jetForce = 275;
  jetEnergyDrain = 1.2;
  maxDamage = 0.65;
  maxForwardSpeed = 17.0;
  maxBackwardSpeed = 12.0;
  maxSideSpeed = 12.0;
  groundForce = 35 * 13.0;
  mass = 9.0;
  groundTraction = 3.0;
  maxEnergy = 80;
  drag = 1.0;
  density = 1.5;
  minDamageSpeed = 35;
  damageScale = 0.005;
  jumpImpulse = 200;
  jumpSurfaceMinDot = 0.2;
  animData[0] = 
  {
    "root", none, 1, true, true, true, false, 0 }
  ;
  animData[1] = 
  {
    "run", none, 1, true, false, true, false, 3 }
  ;
  animData[2] = 
  {
    "runback", none, 1, true, false, true, false, 3 }
  ;
  animData[3] = 
  {
    "side left", none, 1, true, false, true, false, 3 }
  ;
  animData[4] = 
  {
    "side left", none, -1, true, false, true, false, 3 }
  ;
  animData[5] = 
  {
    "jump stand", none, 1, true, false, true, false, 3 }
  ;
  animData[6] = 
  {
    "jump run", none, 1, true, false, true, false, 3 }
  ;
  animData[7] = 
  {
    "crouch root", none, 1, true, true, true, false, 3 }
  ;
  animData[8] = 
  {
    "crouch root", none, 1, true, true, true, false, 3 }
  ;
  animData[9] = 
  {
    "crouch root", none, -1, true, true, true, false, 3 }
  ;
  animData[10] = 
  {
    "crouch forward", none, 1, true, false, true, false, 3 }
  ;
  animData[11] = 
  {
    "crouch forward", none, -1, true, false, true, false, 3 }
  ;
  animData[12] = 
  {
    "crouch side left", none, 1, true, false, true, false, 3 }
  ;
  animData[13] = 
  {
    "crouch side left", none, -1, true, false, true, false, 3 }
  ;
  animData[14] = 
  {
    "fall", none, 1, true, true, true, false, 3 }
  ;
  animData[15] = 
  {
    "landing", SoundLandOnGround, 1, true, false, false, false, 3 }
  ;
  animData[16] = 
  {
    "landing", SoundLandOnGround, 1, true, false, false, false, 3 }
  ;
  animData[17] = 
  {
    "tumble loop", none, 1, true, false, false, false, 3 }
  ;
  animData[18] = 
  {
    "tumble end", none, 1, true, false, false, false, 3 }
  ;
  animData[19] = 
  {
    "jet", none, 1, true, true, true, false, 3 }
  ;
  animData[20] = 
  {
    "PDA access", none, 1, true, false, false, false, 3 }
  ;
  animData[21] = 
  {
    "throw", none, 1, true, false, false, false, 3 }
  ;
  animData[22] = 
  {
    "flyer root", none, 1, false, false, false, false, 3 }
  ;
  animData[23] = 
  {
    "apc root", none, 1, true, true, true, false, 3 }
  ;
  animData[24] = 
  {
    "apc root", none, 1, false, false, false, false, 3 }
  ;
  animData[25] = 
  {
    "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[26] = 
  {
    "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[27] = 
  {
    "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[28] = 
  {
    "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[29] = 
  {
    "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[30] = 
  {
    "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[31] = 
  {
    "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[32] = 
  {
    "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[33] = 
  {
    "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[34] = 
  {
    "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[35] = 
  {
    "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[36] = 
  {
    "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[37] = 
  {
    "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }
  ;
  animData[38] = 
  {
    "sign over here", none, 1, true, false, false, false, 2 }
  ;
  animData[39] = 
  {
    "sign point", none, 1, true, false, false, true, 1 }
  ;
  animData[40] = 
  {
    "sign retreat",none, 1, true, false, false, false, 2 }
  ;
  animData[41] = 
  {
    "sign stop", none, 1, true, false, false, true, 1 }
  ;
  animData[42] = 
  {
    "sign salut", none, 1, true, false, false, true, 1 }
  ;
  animData[43] = 
  {
    "celebration 1", none, 1, true, false, false, false, 2 }
  ;
  animData[44] = 
  {
    "celebration 2", none, 1, true, false, false, false, 2 }
  ;
  animData[45] = 
  {
    "celebration 3", none, 1, true, false, false, false, 2 }
  ;
  animData[46] = 
  {
    "taunt 1", none, 1, true, false, false, false, 2 }
  ;
  animData[47] = 
  {
    "taunt 2", none, 1, true, false, false, false, 2 }
  ;
  animData[48] = 
  {
    "pose kneel", none, 1, true, false, false, true, 1 }
  ;
  animData[49] = 
  {
    "pose stand", none, 1, true, false, false, true, 1 }
  ;
  animData[50] = 
  {
    "wave", none, 1, true, false, false, true, 1 }
  ;
  jetSound = SoundJetLight;
  rFootSounds = 
  {
    SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft }
  ;
  lFootSounds = 
  {
    SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft }
  ;
  footPrints = 
  {
    0, 1 }
  ;
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

function armorfLing::onPoison(%client, %player)
{
  Armor::onPoison(%client, %player);
}

function armorfLing::onBurn(%client, %player)
{
  Armor::onBurn(%client, %player);
}

function armorfLing::onPlayerContact(%targetPlayer, %sourcePlayer)
{
  Armor::onPlayerContact(%targetPlayer, %sourcePlayer);
}

function armorfLing::onGrenade(%player)
{
  Client::sendMessage(Player::getClient(%player),1, "Energy Disruptor will activate in 5 seconds.");
  %obj = newObject("","Mine","Psibomb");
  Armor::ThrowGrenade(%player, %obj);
}

function armorfLing::onBeacon(%player, %item)
{
    startShield(Player::getClient(%player), %player);
    Player::decItemCount(%player,%item);
}

function armorfLing::onRepairKit(%player)
{
  Armor::onRepairKit(%player);
}

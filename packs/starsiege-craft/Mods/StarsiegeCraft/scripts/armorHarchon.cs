//Hybrid Archon, Protoss, H
$InvList[iarmorHArchon] = 1;
$RemoteInvList[iarmorHArchon] = 1;
$VehicleInvList[iarmorHArchon] = 1;
$ArmorType[Male, iarmorHArchon] = armorHArchon;
$ArmorType[Female, iarmorHArchon] = armorHArchon;
$ArmorName[armorHArchon] = iarmorHArchon;

MineData HABomb
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.0;
  friction = 99.0;
  className = "Handgrenade";
  description = "FBGREN";
  shapeFile = "camera";
  shadowDetailMask = 4;
  explosionId = LargeShockwave;
  explosionRadius = 10.0;
  damageValue = 0.0;
  damageType = $FeedBackDamageType;
  kickBackStrength = -200;
  triggerRadius = 0.5;
  maxDamage = 0.01;
};

MineData HABomb2
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.0;
  friction = 99.0;
  className = "Handgrenade";
  description = "neggiegren";
  shapeFile = "force";
  shadowDetailMask = 4;
  explosionId = LargeShockwave;
  explosionRadius = 20.0;
  damageValue = 1.5;
  damageType = $PlasmaDamageType;
  kickBackStrength = -350;
  triggerRadius = 0.5;
  maxDamage = 0.01;
};

function HABomb::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function HABomb2::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

ItemData iarmorHArchon
{
  heading = $InvHead[ihPro];
  description = "Hybrid Archon";
  className = "Armor";
  price = 700;
};

PlayerData armorHArchon
{
  className = "Armor";
  shapeFile = "harmor";
  flameShapeName = "shield_large";
  shieldShapeName = "shield";
  damageSkinData = "armorDamageSkins";
  debrisId = playerDebris;
  shadowDetailMask = 1;
  canCrouch = true;
  visibleToSensor = True;
  mapFilter = 1;
  mapIcon = "M_player";
  maxJetSideForceFactor = 0.8;
  maxJetForwardVelocity = 17;
  minJetEnergy = 1;
  jetForce = 390;
  jetEnergyDrain = 1.2;
  maxDamage = 1.4;
  maxForwardSpeed = 12.0;
  maxBackwardSpeed = 12.0;
  maxSideSpeed = 12.0;
  groundForce = 35 * 13.0;
  mass = 15.0;
  groundTraction = 3.0;
  maxEnergy = 110;
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

function armorHArchon::onPoison(%client, %player)
{
//  Armor::onPoison(%client, %player);
}

function armorHArchon::onBurn(%client, %player)
{
//  Armor::onBurn(%client, %player);
}

function armorHArchon::onPlayerContact(%targetPlayer, %sourcePlayer)
{
//  Armor::HArchonContact(%targetPlayer, %sourcePlayer);
}

function armorHArchon::onGrenade(%player)
{
  %obj = newObject("","Mine","HABomb2");
  Armor::ThrowGrenade(%player, %obj);
}

function armorHArchon::onBeacon(%player, %item)
{
  %obj = newObject("","Mine","HABomb");
  Armor::ThrowGrenade(%player, %obj);
    Player::decItemCount(%player,%item);
}

function armorHArchonHArchon::onRepairKit(%player)
{
  Armor::onRepairKit(%player);
}


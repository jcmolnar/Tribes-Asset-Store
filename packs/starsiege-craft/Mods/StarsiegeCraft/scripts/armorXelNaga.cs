//Xel'Naga Warrior, Freelance, L
//NF
$InvList[iarmorXelNaga] = 1;
$RemoteInvList[iarmorXelNaga] = 1;
$VehicleInvList[iarmorXelNaga] = 1;
$ArmorType[Male, iarmorXelNaga] = armorXelNaga;
$ArmorType[Female, iarmorXelNaga] = armorXelNaga;
$ArmorName[armorXelNaga] = iarmorXelNaga;
$ArmorName[armorXelNaga] = iarmorXelNaga;

ItemData iarmorXelNaga
{
  heading = $InvHead[ihScv];
  description = "Xel'Naga";
  className = "Armor";
  price = 500;
};

PlayerData armorXelNaga
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
  maxJetSideForceFactor = 2.8;
  maxJetForwardVelocity = 42;
  minJetEnergy = 1;
  jetForce = 260;
  jetEnergyDrain = 0.9;
  maxDamage = 0.23;
  maxForwardSpeed = 20;
  maxBackwardSpeed = 17;
  maxSideSpeed = 17;
  groundForce = 40 * 9.0;
  mass = 9.0;
  groundTraction = 3.0;
  maxEnergy = 90;
  drag = 1.0;
  density = 1.2;
  minDamageSpeed = 40;
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

function armorXelNaga::onPoison(%client, %player)
{
//
}

function armorXelNaga::onBurn(%client, %player)
{
//
}

function armorXelNaga::onPlayerContact(%targetPlayer, %sourcePlayer)
{
 if (Player::isDead(%sourceplayer))
    return;
 if (Player::isDead(%targetplayer))
    return; 
 %targetDude = Player::getClient(%targetPlayer);
 %sourceDude = Player::getClient(%sourcePlayer);
  %armor = Player::getArmor(%targetPlayer);
  %armors = Player::getArmor(%sourcePlayer);
  %targetTeam = Client::getTeam(%targetDude);
  %sourceTeam = Client::getTeam(%sourceDude);
  if (%armor == %armors)
    return;
  if ($Deathmatch)
  {
    Player::BlowUp(%targetPlayer);
    Player::kill(%targetPlayer);
    %targetDude.scoreDeaths++;
    %sourceDude.scoreKills++;
    %sourceDude.score++;    
    GameBase::setDamageLevel(%sourcePlayer, 0);

       //XN death messages
      %xnmsg = floor(getRandom() * 4);
      if (%xnmsg == 0)
      {
    MessageAll(0, Client::getName(%targetDude) @ " got vaporized by the Xel Naga " @ Client::getName(%sourceDude) @ ".");
      }
      else if (%xnmsg == 1)
      {
    MessageAll(0, Client::getName(%targetDude) @ " received a Xel Naga Touch of Death from " @ Client::getName(%sourceDude) @ ".");
      }
      else if (%xnmsg == 2)
      {
    MessageAll(0, Client::getName(%targetDude) @ " was touched by " @ Client::getName(%sourceDude) @ ".");
      }
      else
      {
    MessageAll(0, Client::getName(%targetDude) @ " didn't know what hit him.");
      }
  }
  if (%targetTeam == %sourceTeam)
    return;
  else
  {
    Player::BlowUp(%targetPlayer);
    Player::kill(%targetPlayer);
    %targetDude.scoreDeaths++;
    %sourceDude.scoreKills++;
    %sourceDude.score++;
    Game::refreshClientScore(%sourceDude);
    GameBase::setDamageLevel(%sourcePlayer, 0);

       //XN death messages
      %xnmsg = floor(getRandom() * 4);
      if (%xnmsg == 0)
      {
    MessageAll(0, Client::getName(%targetDude) @ " got vaporized by the Xel Naga " @ Client::getName(%sourceDude) @ ".");
      }
      else if (%xnmsg == 1)
      {
    MessageAll(0, Client::getName(%targetDude) @ " received a Xel Naga Touch of Death from " @ Client::getName(%sourceDude) @ ".");
      }
      else if (%xnmsg == 2)
      {
    MessageAll(0, Client::getName(%targetDude) @ " was touched by " @ Client::getName(%sourceDude) @ ".");
      }
      else
      {
    MessageAll(0, Client::getName(%targetDude) @ " got a Xel Naga touch.");
      }
  }
}

function armorXelNaga::onGrenade(%player)
{
  %obj = newObject("","Mine","XNLight");
  Armor::ThrowGrenade(%player, %obj);
}

function armorXelNaga::onBeacon(%player, %item)
{
    startShield(Player::getClient(%player), %player);
    Player::decItemCount(%player,%item);
}

function armorXelNaga::onRepairKit(%player)
{
  Armor::onRepairKit(%player);
}

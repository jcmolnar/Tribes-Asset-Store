//Queen, Zerg, L
//NF
$InvList[iarmorQueen] = 1;
$RemoteInvList[iarmorQueen] = 1;
$VehicleInvList[iarmorQueen] = 1;
$ArmorType[Male, iarmorQueen] = armormQueen;
$ArmorType[Female, iarmorQueen] = armorfQueen;
$ArmorName[armormQueen] = iarmorQueen;
$ArmorName[armorfQueen] = iarmorQueen;

ItemData iarmorQueen
{
  heading = $InvHead[ihZer];
  description = "Queen";
  className = "Armor";
  price = 300;
};

GrenadeData DTShell
{
  bulletShapeName = "grenade.dts";
  explosionTag = rocketExp;
  collideWithOwner = False;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.15;
  damageClass = 1;
  damageValue = 0.7;
  damageType = $MortarDamageType;
  explosionRadius = 10.0;
  kickBackStrength = 250.0;
  maxLevelFlightDist = 150;
  totalTime = 30.0;
  liveTime = 1.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "shield.dts";
  smokeDist = 20;
};

GrenadeData DTTShell
{
  bulletShapeName = "mortar.dts";
  explosionTag = mortarExp;
  collideWithOwner = False;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.15;
  damageClass = 1;
  damageValue = 2.0;
  damageType = $MortarDamageType;
  explosionRadius = 20.0;
  kickBackStrength = 250.0;
  maxLevelFlightDist = 150;
  totalTime = 30.0;
  liveTime = 1.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "shotgunex.dts";
  smokeDist = 10;
};

RocketData DTMass
{
  bulletShapeName = "shield_large.dts";
  explosionTag = LargeShockwave;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.55;
  damageType = $ExplosionDamageType;
  explosionRadius = 20.5;
  kickBackStrength = 600.0;
  muzzleVelocity = 130.0;
  terminalVelocity = 130.0;
  acceleration = 5.0;
  totalTime = 6.0;
  liveTime =  8.0;
  lightRange = 5.0;
  lightColor = { 0.0, 9.0, 1.5 };
  inheritedVelocityScale = 0.0;
  trailType = 2;
  trailString = "fusionbolt.dts";
  smokeDist = 5;
};

PlayerData armormQueen
{
  className = "Armor";
  shapeFile = "larmor";
  damageSkinData = "armorDamageSkins";
  debrisId = playerDebris;
  flameShapeName = "lflame";
  shieldShapeName = "shield";
  shadowDetailMask = 1;
  visibleToSensor = false;
  mapFilter = 1;
  mapIcon = "M_player";
  canCrouch = true;
  maxJetSideForceFactor = 0.8;
  maxJetForwardVelocity = 22;
  minJetEnergy = 1;
  jetForce = 320;
  jetEnergyDrain = 0.9;
  maxDamage = 0.65;
  maxForwardSpeed = 14;
  maxBackwardSpeed = 14;
  maxSideSpeed = 14;
  groundForce = 40 * 9.0;
  mass = 9.0;
  groundTraction = 3.0;
  maxEnergy = 70;
  drag = 1.0;
  density = 1.2;
  minDamageSpeed = 25;
  damageScale = 0.005;
  jumpImpulse = 150;
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

function armormQueen::onPoison(%client, %player)
{
  Armor::onPoison(%client, %player);
}

function armormQueen::onBurn(%client, %player)
{
  Armor::onBurn(%client, %player);
}

function armormQueen::onPlayerContact(%targetPlayer, %sourcePlayer)
{
  Armor::onPlayerContact(%targetPlayer, %sourcePlayer);
}

function armormQueen::onGrenade(%player)
{
         if (floor(getRandom() * 35) == 0)
	 {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
 	    %client = Player::getClient(%player);
            Bottomprint(%client, "!!! WARNING: EXPLOSIVE OVERLOAD- CLEAR THE EXPLOSION AREA !!!");
                        Projectile::spawnProjectile("DTShell",%trans,%player,%vel);
                        Projectile::spawnProjectile("DTTShell",%trans,%player,%vel);
	 }
	 else
	 {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
                        Projectile::spawnProjectile("DTShell",%trans,%player,%vel);
         }
	 return;
}

function armormQueen::onBeacon(%player, %item)
{
  %client = GameBase::getOwnerClient(%player);
  %trans = GameBase::getMuzzleTransform(%player);
  %vel = Item::getVelocity(%player);
    Projectile::spawnProjectile("DTMass",%trans,%player,%vel);
  Player::decItemCount(%player,beacon,1);
}

function armormQueen::onRepairKit(%player)
{
  Armor::onRepairKit(%player);
}

PlayerData armorfQueen
{
  className = "Armor";
  shapeFile = "lfemale";
  flameShapeName = "lflame";
  shieldShapeName = "shield";
  damageSkinData = "armorDamageSkins";
  debrisId = playerDebris;
  shadowDetailMask = 1;
  visibleToSensor = false;
  mapFilter = 1;
  mapIcon = "M_player";
  canCrouch = true;
  maxJetSideForceFactor = 0.8;
  maxJetForwardVelocity = 22;
  minJetEnergy = 1;
  jetForce = 320;
  jetEnergyDrain = 0.9;
  maxDamage = 0.65;
  maxForwardSpeed = 14;
  maxBackwardSpeed = 14;
  maxSideSpeed = 14;
  groundForce = 40 * 9.0;
  mass = 9.0;
  groundTraction = 3.0;
  maxEnergy = 70;
  drag = 1.0;
  density = 1.2;
  minDamageSpeed = 25;
  damageScale = 0.005;
  jumpImpulse = 150;
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

function armorfQueen::onPoison(%client, %player)
{
  Armor::onPoison(%client, %player);
}

function armorfQueen::onBurn(%client, %player)
{
  Armor::onBurn(%client, %player);
}

function armorfQueen::onPlayerContact(%targetPlayer, %sourcePlayer)
{
  Armor::onPlayerContact(%targetPlayer, %sourcePlayer);
}

function armorfQueen::onGrenade(%player)
{
         if (floor(getRandom() * 35) == 0)
	 {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
 	    %client = Player::getClient(%player);
            Bottomprint(%client, "!!! WARNING: EXPLOSIVE OVERLOAD- CLEAR THE EXPLOSION AREA !!!");
                        Projectile::spawnProjectile("DTShell",%trans,%player,%vel);
                        Projectile::spawnProjectile("DTTShell",%trans,%player,%vel);
	 }
	 else
	 {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
                        Projectile::spawnProjectile("DTShell",%trans,%player,%vel);
         }
	 return;
}

function armorfQueen::onBeacon(%player, %item)
{
  %client = GameBase::getOwnerClient(%player);
  %trans = GameBase::getMuzzleTransform(%player);
  %vel = Item::getVelocity(%player);
    Projectile::spawnProjectile("DTMass",%trans,%player,%vel);
  Player::decItemCount(%player,beacon,1);
}

function armorfQueen::onRepairKit(%player)
{
  Armor::onRepairKit(%player);
}

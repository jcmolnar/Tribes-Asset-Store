# Damage Types#
$ImpactDamageType = -1;
$LandingDamageType = 0;
$BulletDamageType = 1;
$EnergyDamageType = 2;
$PlasmaDamageType = 3;
$ExplosionDamageType = 4;
$ShrapnelDamageType = 5;
$LaserDamageType = 6;
$MortarDamageType = 7;
$BlasterDamageType = 8;
$ElectricityDamageType = 9;
$CrushDamageType = 10;
$DebrisDamageType = 11;
$MissileDamageType = 12;
$MineDamageType = 13;
$SniperDamageType = 14;
$FlashDamageType = 15;
$ShellDamageType = 16;
$MeltaDamageType = 17;
$DDamageType = 18;
$ReaperDamageType = 19;
$FlamerDamageType = 20;
$ShurikenDamageType = 21;
$DeathDamageType = 22;
$PsiDamageType = 23;
$FeedBackDamageType = 24;
$BlindDamageType = 25;
$BroodDamageType = 26;

BulletData SniperBullet 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  mass = 0.05;
  collisionRadius = 0.0;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.55;
  damageType = $LaserDamageType;
  aimDeflection = 0.0;
  muzzleVelocity = 2000.0;
  totalTime = 1;
  inheritedVelocityScale = 0.0;
  isVisible = false;
  tracerPercentage = 100.0;
  tracerLength = 25;
}
;
BulletData TranqDart 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  expRandCycle = 3;
  mass = 0.05;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.46;
  damageType = $EnergyDamageType;
  muzzleVelocity = 625.0;
  totalTime = 1.5;
  inheritedVelocityScale = 1.0;
  isVisible = True;
  tracerPercentage = 100.0;
  tracerLength = 30;
}
;
BulletData TurretBullet 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  expRandCycle = 3;
  mass = 0.05;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.06;
  damageType = $BulletDamageType;
  aimDeflection = 0.002;
  muzzleVelocity = 900.0;
  totalTime = 2;
  inheritedVelocityScale = 1.0;
  isVisible = False;
  tracerPercentage = 2.0;
  tracerLength = 60;
}
;
BulletData JetBullet 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  expRandCycle = 3;
  mass = 0.05;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.10;
  damageType = $BulletDamageType;
  aimDeflection = 0.005;
  muzzleVelocity = 425.0;
  totalTime = 1.5;
  inheritedVelocityScale = 1.0;
  isVisible = True;
  tracerPercentage = 100.0;
  tracerLength = 30;
}
;
BulletData FusionBolt
{
  bulletShapeName = "plasmabolt.dts";
  explosionTag = turretExp;
  mass = 0.05;
  damageClass = 0;
  damageValue = 0.25;
  damageType = $PlasmaDamageType;
  muzzleVelocity = 50.0;
  totalTime = 3.0;
  liveTime = 3.0;
  isVisible = True;
  rotationPeriod = 1.5;
};

BulletData MiniFusionBolt
{
  bulletShapeName = "enbolt.dts";
  explosionTag = energyExp;
  damageClass = 0;
  damageValue = 0.1;
  damageType = $DeathDamageType;
  muzzleVelocity = 80.0;
  totalTime = 4.0;
  liveTime = 2.0;
  lightRange = 3.0;
  lightColor = { 0.25, 0.25, 1.0 };
  inheritedVelocityScale = 0.5;
  isVisible = True;
  rotationPeriod = 1;
};

RocketData IonBolt 
{
  bulletShapeName = "enbolt.dts";
  explosionTag = turretExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.15;
  damageType = $DeathDamageType;
  explosionRadius = 6;
  kickBackStrength = 0.0;
  muzzleVelocity = 200.0;
  terminalVelocity = 200.0;
  acceleration = 5.0;
  totalTime = 0.42;
  liveTime = 0.42;
  lightRange = 5.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
  trailType = 1;
  trailLength = 50;
  trailWidth = 0.3;
  soundId = SoundJetHeavy;
};

BulletData JetBolt
{
  bulletShapeName = "shotgunbolt.dts";
  explosionTag = blasterExp;
  damageClass = 0;
  damageValue = 0.125;
  damageType = $ImpactDamageType;
  muzzleVelocity = 300.0;
  totalTime = 2.0;
  liveTime = 1.125;
  lightRange = 3.0;
  lightColor =
  {
    1.0, 0.25, 0.25 }
  ;
  inheritedVelocityScale = 0.5;
  isVisible = True;
  rotationPeriod = 1;
}
;
GrenadeData MortarTurretShell 
{
  bulletShapeName = "mortar.dts";
  explosionTag = mortarExp;
  collideWithOwner = True;
  ownerGraceMS = 400;
  collisionRadius = 1.0;
  mass = 5.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 1.32;
  damageType = $MortarDamageType;
  explosionRadius = 30.0;
  kickBackStrength = 250.0;
  maxLevelFlightDist = 400;
  totalTime = 1000.0;
  liveTime = 2.0;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
  smokeName = "mortartrail.dts";
}
;
GrenadeData ShockShell 
{
  bulletShapeName = "mortar.dts";
  explosionTag = Shockwave;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 995.0;
  elasticity = 0.01;
  damageClass = 1;
  damageValue = 0.10;
  damageType = $FlashDamageType;
  explosionRadius = 30.0;
  kickBackStrength = 0.0;
  maxLevelFlightDist = 1;
  totalTime = 30.0;
  liveTime = 0.01;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.01;
  smokeName = "mortartrail.dts";
}
;
GrenadeData SatchelShell 
{
  bulletShapeName = "grenade.dts";
  explosionTag = rocketExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.45;
  damageClass = 1;
  damageValue = 2.5;
  damageType = $MortarDamageType;
  explosionRadius = 30;
  kickBackStrength = 350.0;
  maxLevelFlightDist = 1;
  totalTime = 1.0;
  liveTime = 0.01;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "smoke.dts";
}
;
RocketData FlierRocket 
{
  bulletShapeName = "rocket.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.5;
  damageType = $MissileDamageType;
  explosionRadius = 9.5;
  kickBackStrength = 250.0;
  muzzleVelocity = 65.0;
  terminalVelocity = 80.0;
  acceleration = 5.0;
  totalTime = 10.0;
  liveTime = 11.0;
  lightRange = 5.0;
  lightColor = 
  {
    1.0, 0.7, 0.5 }
  ;
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "rsmoke.dts";
  smokeDist = 1.8;
  soundId = SoundJetHeavy;
}
;
SeekingMissileData TurretMissile 
{
  bulletShapeName = "Shield_large.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 1.2;
  damageType = $MissileDamageType;
  explosionRadius = 15.0;
  kickBackStrength = 175.0;
  muzzleVelocity = 72.0;
  totalTime = 10;
  liveTime = 10;
  seekingTurningRadius = 15;
  nonSeekingTurningRadius = 75.0;
  proximityDist = 1.5;
  smokeDist = 1.75;
  lightRange = 5.0;
  lightColor = 
  {
    0.4, 0.4, 1.0 }
  ;
  inheritedVelocityScale = 0.5;
  soundId = SoundJetHeavy;
}
;
function SeekingMissile::updateTargetPercentage(%target) 
{
  return GameBase::virtual(%target, "getHeatFactor");
}
RocketData Nuke 
{
  bulletShapeName = "rocket.dts";
  explosionTag = grenadeExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.70;
  damageType = $ShrapnelDamageType;
  explosionRadius = 20.5;
  kickBackStrength = 450.0;
  muzzleVelocity = 60.0;
  terminalVelocity = 2000.0;
  acceleration = 200.0;
  totalTime = 8.0;
  liveTime = 11.0;
  lightRange = 5.0;
  lightColor = 
  {
    1.0, 0.7, 0.5 }
  ;
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "rsmoke.dts";
  smokeDist = 1.8;
  soundId = SoundJetHeavy;
}
;
RocketData TurretShock 
{
  bulletShapeName = "fusionbolt.dts";
  explosionTag = LargeShockwave;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.0;
  damageType = $MissileDamageType;
  explosionRadius = 30.0;
  kickBackStrength = 450.0;
  muzzleVelocity = 65.0;
  terminalVelocity = 80.0;
  acceleration = 5.0;
  totalTime = 10.0;
  liveTime = 11.0;
  lightRange = 5.0;
  lightColor = 
  {
    1.0, 0.7, 0.5 }
  ;
  inheritedVelocityScale = 0.5;
  soundId = SoundJetHeavy;
}
;
RocketData SniperRound 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 0;
  damageValue = 0.59;
  damageType = $SniperDamageType;
  explosionRadius = 0.1;
  kickBackStrength = 600.0;
  muzzleVelocity = 1000.0;
  terminalVelocity = 1000.0;
  acceleration = 5.0;
  totalTime = 10.0;
  liveTime = 11.0;
  lightRange = 10.0;
  lightColor = 
  {
    0.25, 0.25, 1 }
  ;
  inheritedVelocityScale = 1.0;
  soundId = SoundJetHeavy;
}
;
LaserData WraithLaser 
{
  laserBitmapName = "laserPulse.bmp";
  hitName = "laserhit.dts";
  damageConversion = 0.01;
  baseDamageType = $LaserDamageType;
  beamTime = 0.5;
  lightRange = 2.0;
  lightColor = 
  {
    1.0, 0.25, 0.25 }
  ;
  detachFromShooter = false;
  hitSoundId = SoundLaserHit;
}
;
LaserData LaserTag 
{
  laserBitmapName = "lightningNew.bmp";
  hitName = "laserhit.dts";
  damageConversion = 0.01;
  baseDamageType = $LaserDamageType;
  beamTime = 0.5;
  lightRange = 2.0;
  lightColor = 
  {
    1.0, 0.25, 0.25 }
  ;
  detachFromShooter = false;
  hitSoundId = SoundLaserHit;
}
;
LaserData railLaser 
{
  laserBitmapName = "paintPulse.bmp";
  hitName = "laserhit.dts";
  damageConversion = 0.008;
  baseDamageType = $SniperDamageType;
  beamTime = 1.5;
  lightRange = 5.0;
  lightColor = { 0.25, 1.0, 0.25 };
  detachFromShooter = true;
  hitSoundId = SoundLaserHit;
};

LightningData lightningCharge 
{
  bitmapName = "lightningNew.bmp";
  damageType = $ElectricityDamageType;
  boltLength = 40.0;
  coneAngle = 35.0;
  damagePerSec = 0.15;
  energyDrainPerSec = 60.0;
  segmentDivisions = 4;
  numSegments = 5;
  beamWidth = 0.125;
  updateTime = 120;
  skipPercent = 0.5;
  displaceBias = 0.15;
  lightRange = 3.0;
  lightColor = { 0.25, 0.25, 0.85 };
  soundId = SoundELFFire;
};

LightningData lightningCharge2 
{
  bitmapName = "lightningNew.bmp";
  damageType = $ElectricityDamageType;
  boltLength = 50.0;
  coneAngle = 35.0;
  damagePerSec = 0.10;
  energyDrainPerSec = 60.0;
  segmentDivisions = 4;
  numSegments = 5;
  beamWidth = 0.125;
  updateTime = 120;
  skipPercent = 0.5;
  displaceBias = 0.15;
  lightRange = 3.0;
  lightColor = { 0.25, 0.25, 0.85 };
  soundId = SoundELFFire;
};

LightningData turretCharge 
{
  bitmapName = "lightningNew.bmp";
  damageType = $ElectricityDamageType;
  boltLength = 40.0;
  coneAngle = 35.0;
  damagePerSec = 0.06;
  energyDrainPerSec = 60.0;
  segmentDivisions = 4;
  numSegments = 5;
  beamWidth = 0.125;
  updateTime = 120;
  skipPercent = 0.5;
  displaceBias = 0.15;
  lightRange = 3.0;
  lightColor = { 0.25, 0.25, 0.85 };
  soundId = SoundELFFire;
};

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) 
{
  %damVal = %timeSlice * %damPerSec;
  %enVal = %timeSlice * %enDrainPerSec;
  GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
  %energy = GameBase::getEnergy(%target);
  %energy = %energy - %enVal;
  if (%energy < 0) 
    %energy = 0;
  GameBase::setEnergy(%target, %energy);
}

RepairEffectData AutoBolt 
{
  bitmapName = "repairadd.bmp";
  boltLength = 5.0;
  segmentDivisions = 4;
  beamWidth = 0.125;
  updateTime = 450;
  skipPercent = 0.6;
  displaceBias = 0.15;
  lightRange = 3.0;
  lightColor = { 0.85, 0.25, 0.25 };
};

function AutoBolt::onAcquire(%this, %player, %target) 
{
  %client = Player::getClient(%player);
  if (%target == %player) 
  {
    %player.repairTarget = -1;
    if (GameBase::getDamageLevel(%player) != 0) 
    {
      %player.repairRate = 0.1;
      %player.repairTarget = %player;
      Client::sendMessage(%client, 0, "AutoRepair On");
    }
    else 
    {
      Client::sendMessage(%client,0,"Full Health");
      Player::trigger(%player, $BackpackSlot, false);
      return;
    }
  }
  %rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
  GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function AutoBolt::onRelease(%this, %player) 
{
  %object = %player.repairTarget;
  if (%object != -1) 
  {
    %client = Player::getClient(%player);
    if (%object == %player) 
      Client::sendMessage(%client,0,"AutoRepair Off");
    %rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
    if (%rate < 0) %rate = 0;
    GameBase::setAutoRepairRate(%object,%rate);
  }
}

function AutoBolt::checkDone(%this, %player) 
{
  if (%player.repairTarget != -1) 
  {
    %object = %player.repairTarget;
    if (%object == %player) 
    {
      if (GameBase::getDamageLevel(%player) == 0) 
      {
        Player::trigger(%player,$BackpackSlot,false);
        return;
      }
    }
  }
}

BulletData ShotgunBlast
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.05;
   damageType         = $ShellDamageType;

   aimDeflection      = 0.029;
   muzzleVelocity     = 200.0;
   totalTime          = 1;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 2.0;
   tracerLength       = 30;
   soundId = SoundJetLight;
   
};

BulletData FlamerBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.06;
   damageType         = $FlamerDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 30.0;
   totalTime          = 0.75;
   liveTime           = 0.75;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

LaserData SniperLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.02;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 1.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

RocketData DCannonShell 
{
  bulletShapeName = "mortar.dts";
  explosionTag = DCannonBoom;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 3.45;
  damageType = $DDamageType;
  explosionRadius = 160.0;
  kickBackStrength = 850.0;
  muzzleVelocity = 40.0;
  terminalVelocity = 40.0;
  acceleration = 5.0;
  totalTime = 15.0;
  liveTime = 15.0;
  lightRange = 10.0;
  lightColor = { 1.0, 6.7, 9.5 };
  inheritedVelocityScale = 0.5;
  soundId = SoundJetHeavy;
};


LaserData LasCannonCharge
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.04;
   baseDamageType    = $LaserDamageType;

   beamTime          = 2.5;

   lightRange        = 1.0;
   lightColor        = { 0.25, 1.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//=====================================================================//=== PartGun Bolt

BulletData PartGunBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.05;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 1.0;
   liveTime           = 1.0;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};


//=====================================================================//=== Tactical Nuke Shell

GrenadeData WarpShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.5;
   damageType         = $DDamageType;

   explosionRadius    = 35.0;
   kickBackStrength   = 1.0;
   maxLevelFlightDist = 375;
   totalTime          = 30.0;
   liveTime           = 3.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
    smokeName              = "plasmatrail.dts";
  
};


RocketData WarpHit 
{
  bulletShapeName = "fusionbolt.dts";
  explosionTag = LargeShockwave;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 2.5;
  damageType = $DDamageType;
  explosionRadius = 35.0;
  kickBackStrength = 450.0;
  muzzleVelocity = 40.0;
  terminalVelocity = 40.0;
  acceleration = 5.0;
  totalTime = 15.0;
  liveTime = 15.0;
  lightRange = 10.0;
  lightColor = { 1.0, 6.7, 9.5 };
  inheritedVelocityScale = 0.5;
  soundId = SoundJetHeavy;
  trailType = 1;
  trailLength = 10;
  trailWidth = 0.4;
};

BulletData Napalm 
{
  bulletShapeName = "tumult_large.dts";
  explosionTag = plasmaExp;
  damageClass = 1;
  damageValue = 0.15;
  damageType = $FlamerDamageType;
  explosionRadius = 6.0;
  muzzleVelocity = 30.0;
  totalTime = 0.70;
  liveTime = 0.70;
  lightRange = 7.0;
  lightColor = { 2, 2, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  soundId = SoundJetLight;
};

LightningData ElecCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

BulletData FlamerBolt 
{
  bulletShapeName = "tumult_small.dts";
  explosionTag = plasmaExp;
  damageClass = 1;
  damageValue = 0.06;
  damageType = $FlamerDamageType;
  explosionRadius = 4.0;
  muzzleVelocity = 30.0;
  totalTime = 0.55;
  liveTime = 0.55;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  soundId = SoundFirePlasma;
};

SeekingMissileData AAShell 
{
  bulletShapeName = "mortar.dts";
  explosionTag = bulletExp0;
  mass = 0.05;
  collisionRadius = 0.0;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.3;
  damageType = $BulletDamageType;
  aimDeflection = 0.0;
  muzzleVelocity = 2000.0;
  totalTime = 1;
  inheritedVelocityScale = 0.0;
  isVisible = false;
  tracerPercentage = 100.0;
  tracerLength = 25;
}
;
function SeekingMissile::updateTargetPercentage(%target) 
{
  return GameBase::virtual(%target, "getHeatFactor");
}

SeekingMissileData TurretMissile2 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.2;
  damageType = $BulletDamageType;
  explosionRadius = 3.5;
  kickBackStrength = 15.0;
  muzzleVelocity = 872.0;
  totalTime = 10;
  liveTime = 10;
  seekingTurningRadius = 9;
  nonSeekingTurningRadius = 75.0;
  proximityDist = 1.5;
  lightRange = 5.0;
  lightColor = 
  {
    0.4, 0.4, 1.0 }
  ;
  inheritedVelocityScale = 0.5;
  soundId = SoundJetHeavy;
}
;
function SeekingMissile::updateTargetPercentage(%target) 
{
  return GameBase::virtual(%target, "getHeatFactor");
}

//=====================================================================//=== Prism Cannon!!!!

BulletData Prism
{
  bulletShapeName = "fusionbolt.dts";
  explosionTag = mortarExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 2.00;
  damageType = $LaserDamageType;
  explosionRadius = 30.5;
  kickBackStrength = 250.0;
  muzzleVelocity = 250.0;
  terminalVelocity = 65.0;
  acceleration = 5.0;
  totalTime = 6.5;
  liveTime = 10.0;
  lightRange = 5.0;
  lightColor = { 5.20, 6.7, 1.5 };
  inheritedVelocityScale = 0.0;
  soundId = SoundJetHeavy;
};

BulletData LongRound 
{
 bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.4;
  damageType = $BulletDamageType;
  explosionRadius = 4.0;
  kickBackStrength = 15.0;
  muzzleVelocity = 872.0;
  totalTime = 10;
  liveTime = 10;
  lightRange = 5.0;
  lightColor = 
  {
    0.4, 0.4, 1.0 }
  ;
  inheritedVelocityScale = 0.5;
}
;

// Anti Matter shot - HTR
BulletData StarShot
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = flashExpLarge;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $DDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 20.0;
   liveTime           = 1.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

RepairEffectData FixitBolt 
{
  bitmapName = "repairadd.bmp";
  boltLength = 40.0;
  segmentDivisions = 4;
  beamWidth = 0.225;
  updateTime = 450;
  skipPercent = 0.6;
  displaceBias = 0.15;
  lightRange = 3.0;
  lightColor = { 0.85, 0.25, 0.25 };
};

function FixitBolt::onAcquire(%this, %player, %target) 
{
  %client = Player::getClient(%player);
  if (%target == %player) 
  {
    %player.repairTarget = -1;
    if (GameBase::getDamageLevel(%player) != 0) 
    {
      %player.repairRate = 0.35;
      %player.repairTarget = %player;
      Client::sendMessage(%client, 0, "Repairing");
    }
    else 
    {
      Client::sendMessage(%client,0,"Nothing in range");
      Player::trigger(%player, $WeaponSlot, false);
      return;
    }
  }
  else 
  {
    %player.repairTarget = %target;
    %player.repairRate = 0.35;
    if (getObjectType(%player.repairTarget) == "Player") 
    {
      %rclient = Player::getClient(%player.repairTarget);
      %name = Client::getName(%rclient);
    }
    else 
    {
      %name = GameBase::getMapName(%target);
      if(%name == "") 
      {
        %name = (GameBase::getDataName(%player.repairTarget)).description;
      }
    }
    if (GameBase::getDamageLevel(%player.repairTarget) == 0) 
    {
      Client::sendMessage(%client,0,%name @ " is not damaged");
      Player::trigger(%player,$WeaponSlot,false);
      %player.repairTarget = -1;
      return;
    }
    if (getObjectType(%player.repairTarget) == "Player") 
    {
      Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
    }
    Client::sendMessage(%client,0,"Repairing " @ %name);
  }
  %rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
  GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function FixitBolt::onRelease(%this, %player) 
{
  %object = %player.repairTarget;
  if (%object != -1) 
  {
    %client = Player::getClient(%player);
    if (%object == %player) 
    {
      Client::sendMessage(%client,0,"Stopped Repairing");
    }
    else 
    {
      if (GameBase::getDamageLevel(%object) == 0) 
      {
        Client::sendMessage(%client,0,"Repair Done");
      }
      else 
      {
        Client::sendMessage(%client,0,"Repair Stopped");
      }
    }
    %rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
    if (%rate < 0) %rate = 0;
    GameBase::setAutoRepairRate(%object,%rate);
  }
}

function FixitBolt::checkDone(%this, %player) 
{
  if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun && %player.repairTarget != -1) 
  {
    %object = %player.repairTarget;
    if (%object == %player) 
    {
      if (GameBase::getDamageLevel(%player) == 0) 
      {
        Player::trigger(%player,$WeaponSlot,false);
        return;
      }
    }
    else 
    {
      if (GameBase::getDamageLevel(%object) == 0) 
      {
        Player::trigger(%player,$WeaponSlot,false);
        return;
      }
    }
  }
}

RepairEffectData HealBolt 
{
  bitmapName = "grn_blink2.bmp";
  boltLength = 100.0;
  segmentDivisions = 4;
  beamWidth = 0.025;
  updateTime = 450;
  skipPercent = 0.6;
  displaceBias = 0.15;
  lightRange = 3.0;
  lightColor = { 0.85, 0.25, 0.25 };
};

function HealBolt::onAcquire(%this, %player, %target) 
{
  %client = Player::getClient(%player);
  if (%target == %player) 
  {
    %player.repairTarget = -1;
    if (GameBase::getDamageLevel(%player) != 0) 
    {
      %player.repairRate = 0.1;
      %player.repairTarget = %player;
      Client::sendMessage(%client, 0, "Healing");
    }
    else 
    {
      Client::sendMessage(%client,0,"Nothing in range");
      Player::trigger(%player, $WeaponSlot, false);
      return;
    }
  }
  else 
  {
    %player.repairTarget = %target;
    %player.repairRate = 0.15;
    if (getObjectType(%player.repairTarget) == "Player") 
    {
      %rclient = Player::getClient(%player.repairTarget);
      %name = Client::getName(%rclient);
    }
    else
    {
      %name = GameBase::getMapName(%target);
      if(%name == "") 
      {
        %name = (GameBase::getDataName(%player.repairTarget)).description;
      }
    }
    if (GameBase::getDamageLevel(%player.repairTarget) == 0) 
    {
      Client::sendMessage(%client,0,%name @ " is not damaged");
      Player::trigger(%player,$WeaponSlot,false);
      %player.repairTarget = -1;
      return;
    }
    if (getObjectType(%player.repairTarget) == "Player") 
    {
      Client::sendMessage(%rclient,0,"Being healed by " @ Client::getName(%client));
    }
    Client::sendMessage(%client,0,"Healing " @ %name);
  }
  %rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
  GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function HealBolt::onRelease(%this, %player) 
{
  %object = %player.repairTarget;
  if (%object != -1) 
  {
    %client = Player::getClient(%player);
    if (%object == %player) 
    {
      Client::sendMessage(%client,0,"Stopped Healing");
    }
    else 
    {
      if (GameBase::getDamageLevel(%object) == 0) 
      {
        Client::sendMessage(%client,0,"Repair Done");
      }
      else 
      {
        Client::sendMessage(%client,0,"Repair Stopped");
      }
    }
    %rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
    if (%rate < 0) %rate = 0;
    GameBase::setAutoRepairRate(%object,%rate);
  }
}

function HealBolt::checkDone(%this, %player) 
{
  if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun && %player.repairTarget != -1) 
  {
    %object = %player.repairTarget;
    if (%object == %player) 
    {
      if (GameBase::getDamageLevel(%player) == 0) 
      {
        Player::trigger(%player,$WeaponSlot,false);
        return;
      }
    }
    else 
    {
      if (GameBase::getDamageLevel(%object) == 0) 
      {
        Player::trigger(%player,$WeaponSlot,false);
        return;
      }
    }
  }
}

BulletData MegaFlame 
{
  bulletShapeName = "tumult_large.dts";
  explosionTag = plasmaExp;
  damageClass = 1;
  damageValue = 0.2;
  damageType = $PlasmaDamageType;
  explosionRadius = 6.0;
  muzzleVelocity = 30.0;
  totalTime = 3.55;
  liveTime = 3.55;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  soundId = SoundFirePlasma;
};

BulletData SilencerBullet 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  expRandCycle = 3;
  mass = 0.05;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.07;
  damageType = $BulletDamageType;
  aimDeflection = 0.004;
  muzzleVelocity = 625.0;
  inheritedVelocityScale = 1.0;
  isVisible = True;
  tracerPercentage = 100.0;
  tracerLength = 30;
  totalTime = 1.5;
  liveTime = 1.5;
};

BulletData ChainBullet 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  expRandCycle = 3;
  mass = 0.05;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.1;
  damageType = $BulletDamageType;
  aimDeflection = 0.003;
  muzzleVelocity = 425.0;
  totalTime = 1.5;
  inheritedVelocityScale = 1.0;
  isVisible = False;
  tracerPercentage = 1.0;
  tracerLength = 30;
};

RocketData Smokey 
{
  bulletShapeName = "rocket.dts";
  explosionTag = turretExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.65;
  damageType = $MissileDamageType;
  explosionRadius = 16;
  kickBackStrength = 150.0;
  muzzleVelocity = 200.0;
  terminalVelocity = 200.0;
  acceleration = 5.0;
  totalTime = 10.42;
  liveTime = 10.42;
  lightRange = 5.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "dustplume.dts";
  smokeDist = 1.8;
  soundId = SoundJetHeavy;
};

LaserData JetBeam
{
  laserBitmapName = "laserPulse.bmp";
  hitName = "laserhit.dts";
  damageConversion = 0.960;
  baseDamageType = $LaserDamageType;
  beamTime = 0.5;
  lightRange = 4.0;
  lightColor = { 0, 2, 0 } ;
  detachFromShooter = false;
};

RocketData ShurShell
{
  bulletShapeName = "discb.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.67;
  damageType = $ShurikenDamageType;
  explosionRadius = 9.5;
  kickBackStrength = 150.0;
  muzzleVelocity = 385.0;
  terminalVelocity = 385.0;
  acceleration = 5.0;
  totalTime = 6.5;
  liveTime = 6.5;
  lightRange = 8.0;
  lightColor = { 1.0, 1.5, 2.0 };
  inheritedVelocityScale = 1.0;
  trailType = 1;
  trailLength = 15;
  trailWidth = 0.3;
  soundId = SoundDiscSpin;
};

BulletData MeltaJet 
{
  bulletShapeName = "fusionbolt.dts";
  explosionTag = energyExp;
  damageClass = 0;
  damageValue = 0.65;
  damageType = $MeltaDamageType;
  muzzleVelocity = 100.0;
  totalTime = 3.0;
  liveTime = 3.0;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  soundId = SoundJetLight;
};

RocketData Shock 
{
  bulletShapeName = "plasmabolt.dts";
  explosionTag = PlasCannon;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.55;
  damageType = $PlasmaDamageType;
  explosionRadius = 20.0;
  kickBackStrength = 150.0;
  muzzleVelocity = 50.0;
  terminalVelocity = 80.0;
  acceleration = 5.0;
  totalTime = 6.0;
  liveTime = 6.0;
  lightRange = 5.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
  soundId = SoundJetHeavy;
};
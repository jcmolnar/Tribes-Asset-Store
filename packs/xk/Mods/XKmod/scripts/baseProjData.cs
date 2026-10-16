# Damage Types#
$FusionDamageType = 2;
$IonDamageType = 2;
$KamikazeDamageType = 23;
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
$ShotgunDamageType = 16;
//-----------Mini mod
RocketData HDiscShell 
{ 
bulletShapeName = "discb.dts"; 
explosionTag = rocketExp; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1; 
damageValue = 0.33; 
damageType = $ExplosionDamageType; 
explosionRadius = 7.5; 
kickBackStrength = 110.0; 
muzzleVelocity = 75.0; 
terminalVelocity = 90.0; 
acceleration = 5.0; 
totalTime = 6.5; 
liveTime = 8.0; 
lightRange = 5.0; 
lightColor = { 0.1, 1.0, 0.1 }; 
inheritedVelocityScale = 0.5; 
trailType = 1; 
trailString = "repairadd.bmp"; 
trailLength = 28; 
trailWidth = 0.3; 
soundId = SoundSpinIdle; 
}; 

LightningData HGravCharge
{
   bitmapName       = "repairAdd.bmp";

   damageType       = $GravDamageType;
   boltLength       = 150.0;
   coneAngle        = 40.0; //40
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.01;
   segmentDivisions = 2;
   numSegments      = 1;
   beamWidth        = 0.05;

   updateTime   = 120;
   skipPercent  = 0.1;
   displaceBias = 0.35;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };

   soundId = SoundELFFire;
};

function HGravCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
	%Zvalue = -15;
	%velocity = 0.0;
	%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
	Player::applyImpulse(%target, %shooterDir);
}

//-----The End---
BulletData SniperBullet 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  mass = 0.05;
  collisionRadius = 0.0;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.57;

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
  damageValue = 0.16;
  damageType = $EnergyDamageType;
  muzzleVelocity = 625.0;
  totalTime = 1.5;
  inheritedVelocityScale = 1.0;
  isVisible = True;
  tracerPercentage = 100.0;
  tracerLength = 30;
}
;
//-----------------------------------------

LightningData HGravCharge
{
   bitmapName       = "repairAdd.bmp";

   damageType       = $GravDamageType;
   boltLength       = 150.0;
   coneAngle        = 40.0; //40
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.01;
   segmentDivisions = 2;
   numSegments      = 1;
   beamWidth        = 0.05;

   updateTime   = 120;
   skipPercent  = 0.1;
   displaceBias = 0.35;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };

   soundId = SoundELFFire;
};

function HGravCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
	%Zvalue = -15;
	%velocity = 0.0;
	%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
	Player::applyImpulse(%target, %shooterDir);
}


 BulletData ClusterBombShell
 {
	 bulletShapeName = "rocket.dts";
	 explosionTag = debrisExpSmall;
	 mass = 0.05;
	 bulletHoleIndex = 0;
	 collisionRadius    = 15.0;//++++++
	 damageClass = 1;
	 explosionRadius    = 8;//5;+++++++++++
	 kickBackStrength   = 100.0;//++++++++
	 damageValue = 0.038; //0.05;+++++++++++++++++++
	 damageType = $ShrapnelDamageType;
	 aimDeflection = 0.01;//++++++++++
	 muzzleVelocity = 300.0;
	 totalTime = 1.0; //0.8;+++++++++++++++++
	 liveTime = 0.05;//++++++++++++++++++++++++++++++++++++++++++++
	 inheritedVelocityScale = 1.0;
	 isVisible = True;
	
	triggerRadius = 5;//+++++++++++
	damageLevel = {1.0, 1.0};//++++
	maxDamage = 1.0;//0++++++++++++

   tracerPercentage   = 100.0; //1.0;++++++++++++++++++++++++++++++++++++++++++++++
	 tracerLength = 30;
   smokeName              = "plasmatrail.dts";
 };
function ClusterBombShell::onAdd(%this)
{
	%this.damage = 0;
}
function ClusterBombShell::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}
//-----------------------------------------
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
  bulletShapeName = "fusionbolt.dts";
  explosionTag = turretExp;
  mass = 0.05;
  damageClass = 0;
  damageValue = 0.25;
  damageType = $FusionDamageType;
  muzzleVelocity = 50.0;
  totalTime = 6.0;
  liveTime = 4.0;
  isVisible = True;
  rotationPeriod = 1.5;
};

BulletData MiniFusionBolt
{
  bulletShapeName = "enbolt.dts";
  explosionTag = energyExp;
  damageClass = 0;
  damageValue = 0.1;
  damageType = $FusionDamageType;
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
  damageType = $IonDamageType;
  explosionRadius = 4;
  kickBackStrength = 0.0;
  muzzleVelocity = 200.0;
  terminalVelocity = 200.0;
  acceleration = 5.0;
  totalTime = 10.0;
  liveTime = 11.0;
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
  damageType = $ElectricityDamageType;
  explosionRadius = 30.0;
  kickBackStrength = 0.0;
  maxLevelFlightDist = 1;
  totalTime = 30.0;
  liveTime = 0.01;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.01;
  smokeName = "fusionbolt.dts";
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
  totalTime = 30.0;
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
  bulletShapeName = "rocket.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.5;
  damageType = $MissileDamageType;
  explosionRadius = 9.5;
  kickBackStrength = 175.0;
  muzzleVelocity = 72.0;
  totalTime = 10;
  liveTime = 10;
  seekingTurningRadius = 9;
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
  muzzleVelocity = 2000.0;
  terminalVelocity = 2000.0;
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
  damageConversion = 0.004;
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
GrenadeData B2Nukebomb
{
  bulletShapeName = "mortar.dts";
  explosionTag = MortarExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 2.0;
  damageType = $MissleDamageType;
  explosionRadius = 50.0;
  kickBackStrength = 250.0;
  maxLevelFlightDist = 875;
  totalTime = 30.0;
  liveTime = 8.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "plasmatrail.dts";
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
//--Mini Mod--
GrenadeData Flare
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = FlareExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 150;
   totalTime          = 2.5;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};
//--------------
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

RepairEffectData RepairBolt 
{
  bitmapName = "repairadd.bmp";
  boltLength = 10.0;
  segmentDivisions = 4;
  beamWidth = 0.125;
  updateTime = 450;
  skipPercent = 0.6;
  displaceBias = 0.15;
  lightRange = 3.0;
  lightColor = { 0.85, 0.25, 0.25 };
};

function RepairBolt::onAcquire(%this, %player, %target) 
{
  %client = Player::getClient(%player);
  if (%target == %player) 
  {
    %player.repairTarget = -1;
    if (GameBase::getDamageLevel(%player) != 0) 
    {
      %player.repairRate = 0.05;
      %player.repairTarget = %player;
      Client::sendMessage(%client, 0, "AutoRepair On");
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
    %player.repairRate = 0.1;
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

function RepairBolt::onRelease(%this, %player) 
{
  %object = %player.repairTarget;
  if (%object != -1) 
  {
    %client = Player::getClient(%player);
    if (%object == %player) 
    {
      Client::sendMessage(%client,0,"AutoRepair Off");
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

function RepairBolt::checkDone(%this, %player) 
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
      %player.repairRate = 0.05;
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

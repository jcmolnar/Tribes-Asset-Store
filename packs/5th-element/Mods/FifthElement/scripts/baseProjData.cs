# Damage Types
#
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
$LowWarheadDamageType = 16;
$MedWarheadDamageType = 17;
$HighWarheadDamageType = 18;
$EMPWarheadDamageType = 19;
$VulcanDamageType = 20;
$PlasmaCannonDamageType = 21;
$MagnumDamageType = 22;
$Vulcan2DamageType = 23;
$TBulletDamageType = 24;
$BlindDamageType = 25;
$TurretDamageType = 26;
$FlameDamageType = 27;
$RailDamageType = 28;
//=================


//====================



BulletData PlasmaCannonBlast
{
bulletShapeName = "fusionbolt.dts";
explosionTag = PlasmaCannonExp;
mass = 0.05;
damageClass = 1;  
damageValue = 0.55;
damageType = $PlasmaCannonDamageType;
explosionRadius = 4.0;
muzzleVelocity = 55.0;
totalTime = 6.0;
liveTime = 4.0;
isVisible = True;
rotationPeriod = 1.5;
};

BulletData ChaingunBullet 
{
bulletShapeName = "bullet.dts";
explosionTag = bulletExp0;
expRandCycle = 3;
mass = 0.04;
bulletHoleIndex = 0;
damageClass = 0;
damageValue = 0.12;
damageType = $BulletDamageType;
aimDeflection = 0.0008;
muzzleVelocity = 500.0;
totalTime = 1.75;
inheritedVelocityScale = 1.0;
isVisible = false;
tracerPercentage = 1.0;
tracerLength = 30;

};

BulletData VulcanBullet
{
bulletShapeName = "chainspk.dts";
explosionTag = bulletExp0;
expRandCycle = 3;
mass = 1.2;
bulletHoleIndex = 0;
damageClass = 0;
damageValue = 0.15; 
damageType  = $VulcanDamageType;
aimDeflection = 0.00120; 
muzzleVelocity = 900.0;
totalTime = 0.38;
inheritedVelocityScale = 1.0;
isVisible = false;
tracerPercentage = 3.0;
tracerLength = 70;
};

RocketData SilencerBullet
{
bulletShapeName = "bullet.dts";
explosionTag = bulletExp0;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 0;
damageValue = 0.30;
damageType = $MagnumDamageType;
explosionRadius = 0.1;
kickBackStrength = 600.0;
muzzleVelocity = 1500.0;
terminalVelocity = 1500.0;
acceleration = 5.0;
totalTime = 10.0;
liveTime = 11.0;
lightRange = 10.0;
lightColor = {0.25, 0.25, 1 };
inheritedVelocityScale = 1.0;
isVisible = false;
soundId = SoundJetHeavy;
};

BulletData VulcanBullet2 {
bulletShapeName = "bullet.dts";
explosionTag = bulletExp0;
expRandCycle = 3;
mass = 0.05;
bulletHoleIndex = 0;
damageClass = 0;
damageValue = 0.06;
damageType = $Vulcan2DamageType;
aimDeflection = 0.0025;
muzzleVelocity = 900.0;
totalTime = 0.43;
inheritedVelocityScale = 1.0;
isVisible = False;
tracerPercentage = 2.0;
tracerLength = 60;
};



BulletData TurretBullet 
{
bulletShapeName = "bullet.dts";
explosionTag = bulletExp0;
expRandCycle = 3;
mass = 0.05;
bulletHoleIndex = 0;
damageClass = 0;
damageValue = 0.025;
damageType = $TBulletDamageType;
aimDeflection = 0.002;
muzzleVelocity = 775.0;
totalTime = 2.0;
inheritedVelocityScale = 1.0;
isVisible = True;
tracerPercentage = 100.0;
tracerLength = 60;
};


BulletData FusionBolt 
{
bulletShapeName = "fusionbolt.dts";
explosionTag = turretExp;
mass = 0.05;
damageClass = 0;
damageValue = 0.25;
damageType = $TurretDamageType;
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
damageType = $TurretDamageType;
muzzleVelocity = 80.0;
totalTime = 4.0;
liveTime = 2.0;
lightRange = 3.0;
lightColor = {0.25, 0.25, 1.0 };
inheritedVelocityScale = 0.5;
isVisible = True;
rotationPeriod = 1;
};



BulletData BlasterBolt 
{
bulletShapeName = "shotgunbolt.dts";
explosionTag = blasterExp;
damageClass = 0;
damageValue = 0.125;
damageType = $BlasterDamageType;
muzzleVelocity = 200.0;
totalTime = 2.0;
liveTime = 1.125;
lightRange = 3.0;
lightColor = {1.0, 0.25, 0.25 };
inheritedVelocityScale = 0.5;
isVisible = True;
rotationPeriod = 1;
};

BulletData HyperBolt 
{
bulletShapeName = "paint.dts";
explosionTag = HyperblasterExp;
damageClass = 0;
damageValue = 0.117;
damageType = $BlasterDamageType;
muzzleVelocity = 215.0;
totalTime = 2.0;
liveTime = 1.125;
lightRange = 3.0;
lightColor = {0.25, 1.0, 0.25 };
inheritedVelocityScale = 0.5;
isVisible = True;
rotationPeriod = 1;
};

BulletData PlasmaBolt 
{
bulletShapeName = "plasmabolt.dts";
explosionTag = plasmaExp;
damageClass = 1;
damageValue = 0.45;
damageType = $PlasmaDamageType;
explosionRadius = 4.0;
muzzleVelocity = 55.0;
totalTime = 3.0;
liveTime = 2.0;
lightRange = 3.0;
lightColor = {1, 1, 0 };
inheritedVelocityScale = 0.3;
isVisible = True;
soundId = SoundJetLight;
};

RocketData FlamerBolt 
{
bulletShapeName = "plasmabolt.dts";
explosionTag = FireExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.06;
damageType = $FlameDamageType;
explosionRadius = 4.5;
kickBackStrength = 0;
muzzleVelocity = 75.0;
terminalVelocity = 80.0;
acceleration = 5.0;
totalTime = 0.6;
liveTime = 0.6;
lightRange = 5.0;
lightColor = { 1.0, 0.95, 1.0 };
inheritedVelocityScale = 0.5;
trailType = 2;
trailString = "plastrail.dts";
smokeDist = 1.8;
soundId = SoundJetHeavy;
};

BulletData TurretFlamer
{
bulletShapeName = "plasmabolt.dts";
explosionTag = plasmaExp;
damageClass = 1;
damageValue = 0.03;
damageType = $FlameDamageType;
explosionRadius = 4.0;
muzzleVelocity = 200.0;
totalTime = 11.0;
liveTime = 10.0;
lightRange = 5.0;
lightColor = {1, 1, 0 };
inheritedVelocityScale = 0.4;
isVisible = True;
soundId = SoundJetLight;
};

BulletData OmegaBolt 
{
  bulletShapeName = "paint.dts";
  explosionTag = HyperblasterExp;
  damageClass = 0;
  damageValue = 0.06;
  damageType = $ElectricityDamageType;
  aimDeflection = 0.015;
  muzzleVelocity = 100.0;
  totalTime = 5.3;
  liveTime = 0.3;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  soundId = SoundJetLight;
};

BulletData OmegaBolt2 
{
  bulletShapeName = "enex.dts";
  explosionTag = energyExp;
  damageClass = 0;
  damageValue = 0.06;
  damageType = $ElectricityDamageType;
  aimDeflection = 0.015;
  muzzleVelocity = 100.0;
  totalTime = 5.3;
  liveTime = 0.3;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  soundId = SoundJetLight;
};

RocketData DiscShell 
{
bulletShapeName = "discb.dts";
explosionTag = rocketExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.5;
damageType = $ExplosionDamageType;
explosionRadius = 7.5;
kickBackStrength = 125.0;
muzzleVelocity = 65.0;
terminalVelocity = 80.0;
acceleration = 5.0;
totalTime = 6.5;
liveTime = 8.0;
lightRange = 5.0;
lightColor = {0.4, 0.4, 1.0 };
inheritedVelocityScale = 0.5;
trailType = 1;
trailLength = 15;
trailWidth = 0.3;
soundId = SoundDiscSpin;
};

RocketData HDiscShell {
bulletShapeName = "discb.dts";
explosionTag = rocketExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.4;
damageType = $ExplosionDamageType;
explosionRadius = 6;
kickBackStrength = 110.0;
muzzleVelocity = 65.0;
terminalVelocity = 90.0;
acceleration = 5.0;
totalTime = 6.5;
liveTime = 8.0;
lightRange = 5.0;
lightColor = {0, 1.0, 0};
inheritedVelocityScale = 0.5;
trailType = 1;
trailString = "repairadd.bmp";
trailLength = 28;
trailWidth = 0.3;
soundId = SoundSpinIdle;
};

RocketData HandRocket {
bulletShapeName = "rocket.dts";
explosionTag = rocketExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.60;
damageType = $ExplosionDamageType;
explosionRadius = 9.5;
kickBackStrength = 185.0;
muzzleVelocity = 75.0;
terminalVelocity = 80.0;
acceleration = 5.0;
totalTime = 10.0;
liveTime = 11.0;
lightRange = 5.0;
lightColor = {1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
trailType = 2;
trailString = "rsmoke.dts";
smokeDist = 1.8;
soundId = SoundJetHeavy;
};

SeekingMissileData AvengerMissile {
bulletShapeName = "rocket.dts";
explosionTag = rocketExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.65;
damageType = $ExplosionDamageType;
explosionRadius = 9.5;
kickBackStrength = 175.0;
muzzleVelocity = 75.0;
terminalVelocity = 80.0;
acceleration = 5.0;
totalTime = 20.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = {1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 0.0;
nonSeekingTurningRadius = 5.0;
proximityDist = 1.5;
lightRange = 5.0;
lightColor = {0.4, 0.4, 1.0 };
trailType = 2;
trailString = "smoke.dts";
smokeDist = 1.5;
inheritedVelocityScale = 1.0;
soundId = SoundJetHeavy;
};

function AvengerMissile::updateTargetPercentage(%target) {
if(Player::getMountedItem(%target,$BackpackSlot) == "RocketBooster") return 1.0;
else return GameBase::virtual(%target, "getHeatFactor");
}

GrenadeData GrenadeShell 
{
bulletShapeName = "grenade.dts";
explosionTag = grenadeExp;
collideWithOwner = True;
ownerGraceMS = 250;
collisionRadius = 0.2;
mass = 1.0;
elasticity = 0.45;
damageClass = 1;
damageValue = 0.4;
damageType = $ShrapnelDamageType;
explosionRadius = 15;
kickBackStrength = 150.0;
maxLevelFlightDist = 150;
totalTime = 30.0;
liveTime = 1.0;
projSpecialTime = 0.05;
inheritedVelocityScale = 0.5;
smokeName = "smoke.dts";
};



GrenadeData MortarShell 
{
bulletShapeName = "mortar.dts";
explosionTag = mortarExp;
collideWithOwner = True;
ownerGraceMS = 250;
collisionRadius = 0.3;
mass = 5.0;
elasticity = 0.1;
damageClass = 1;
damageValue = 1.0;
damageType = $MortarDamageType;
explosionRadius = 20.0;
kickBackStrength = 250.0;
maxLevelFlightDist = 350;
totalTime = 30.0;
liveTime = 2.0;
projSpecialTime = 0.01;
inheritedVelocityScale = 0.5;
smokeName = "mortartrail.dts";
};

GrenadeData MortarShell2
{
bulletShapeName = "mortar.dts";
explosionTag = mortarExp;
collideWithOwner = True;
ownerGraceMS = 250;
collisionRadius = 0.3;
mass = 9995.0;
elasticity = 0.1;
damageClass = 1;
damageValue = 1.0;
damageType = $MortarDamageType;
explosionRadius = 20.0;
kickBackStrength = 250.0;
maxLevelFlightDist = 275;
totalTime = 30.0;
liveTime = 2.0;
projSpecialTime = 0.01;
inheritedVelocityScale = 0.5;
smokeName = "mortartrail.dts";
};

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
};


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
damageValue = 0.05;
damageType = $FlashDamageType;
explosionRadius = 30.0;
kickBackStrength = 0.0;
maxLevelFlightDist = 1;
totalTime = 30.0;
liveTime = 0.01;
projSpecialTime = 0.01;
inheritedVelocityScale = 0.01;
smokeName = "mortartrail.dts";
};


GrenadeData ShockShell2
{
bulletShapeName = "mortar.dts";
explosionTag = Shockwave;
collideWithOwner = True;
ownerGraceMS = 400;
collisionRadius = 3.0;
mass = 5.0;
elasticity = 0.1;
damageClass = 1;
damageValue = 0.10;
damageType = $FlashDamageType;
explosionRadius = 30.0;
kickBackStrength = 0.0;
maxLevelFlightDist = 400;
totalTime = 1000.0;
liveTime = 2.0;
projSpecialTime = 0.05;
inheritedVelocityScale = 0.5;
smokeName = "mortartrail.dts";
};


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
maxLevelFlightDist = 1.2;
totalTime = 1.5;
liveTime = 0.01;
projSpecialTime = 0.01;
inheritedVelocityScale = 0.5;
smokeName = "smoke.dts";
};



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
lightColor = {1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
trailType = 2;
trailString = "rsmoke.dts";
smokeDist = 1.8;
soundId = SoundJetHeavy;
};


SeekingMissileData TurretMissile {
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
lightColor = {0.4, 0.4, 1.0 };
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};

function SeekingMissile::updateTargetPercentage(%target) {
return GameBase::virtual(%target, "getHeatFactor");
}


RocketData Nuke 
{
bulletShapeName = "rocket.dts";
explosionTag = grenadeExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.35;
damageType = $ShrapnelDamageType;
explosionRadius = 20.5;
kickBackStrength = 100.0;
muzzleVelocity = 65.0;
terminalVelocity = 2000.0;
acceleration = 200.0;
totalTime = 8.0;
liveTime = 11.0;
lightRange = 5.0;
lightColor = {1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
trailType = 2;
trailString = "rsmoke.dts";
smokeDist = 1.8;
soundId = SoundJetHeavy;
};

RocketData Shock 
{
bulletShapeName = "shield_medium.dts";
explosionTag = LargeShockwave;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.05;
damageType = $FlashDamageType;
explosionRadius = 10.0;
kickBackStrength = 300.0;
muzzleVelocity = 50.0;
terminalVelocity = 80.0;
acceleration = 5.0;
totalTime = 6.0;
liveTime = 4.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
trailType = 2;
trailString = "shield.dts";
smokeDist = 1.8;
soundId = SoundJetHeavy;
};

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
lightColor = {1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};

RocketData SniperRound 
{
bulletShapeName = "bullet.dts";
explosionTag = bulletExp0;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 0;
damageValue = 0.65;
damageType = $SniperDamageType;
explosionRadius = 0.1;
kickBackStrength = 600.0;
muzzleVelocity = 2000.0;
terminalVelocity = 2000.0;
acceleration = 5.0;
totalTime = 10.0;
liveTime = 11.0;
lightRange = 10.0;
lightColor = {0.25, 0.25, 1 };
inheritedVelocityScale = 1.0;
soundId = SoundJetHeavy;
};

RocketData RailRound {
bulletShapeName = "bullet.dts";
explosionTag = bulletExp0;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 0;
damageValue = 0.65;
damageType = $RailDamageType;
explosionRadius = 0.1;
kickBackStrength = 600.0;
muzzleVelocity = 2000.0;
terminalVelocity = 2000.0;
acceleration = 5.0;
totalTime = 0.3;
liveTime = 0.4;
lightRange = 10.0;
lightColor = { 0.25, 0.25, 1 };
inheritedVelocityScale = 1.0;
trailType = 1;
trailLength = 3000;
trailWidth = 0.6;
soundId = SoundJetHeavy;
};


RocketData IonBolt 
{
bulletShapeName = "enbolt.dts";
explosionTag = turretExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.17;
damageType = $ElectricityDamageType;
explosionRadius = 4;
kickBackStrength = 0.0;
muzzleVelocity = 200.0;
terminalVelocity = 200.0;
acceleration = 5.0;
totalTime = 10.0;
liveTime = 11.0;
lightRange = 5.0;
lightColor = {1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
trailType = 1;
trailLength = 50;
trailWidth = 0.3;
soundId = SoundJetHeavy;
};

RocketData FlierBolt 
{
bulletShapeName = "enbolt.dts";
explosionTag = turretExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.17;
damageType = $ElectricityDamageType;
explosionRadius = 4;
kickBackStrength = 0.0;
muzzleVelocity = 190.0;
terminalVelocity = 190.0;
acceleration = 5.0;
totalTime = 4.0;
liveTime = 5.0;
lightRange = 4.0;
lightColor = {1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
trailType = 1;
trailLength = 25;
trailWidth = 0.3;
soundId = SoundJetHeavy;
};


LaserData sniperLaser 
{
laserBitmapName = "shotgunbolt.bmp";
hitName = "laserhit.dts";
damageConversion = 0.0085;
baseDamageType = $LaserDamageType;
beamTime = 0.5;
lightRange = 2.0;
lightColor = {1.0, 0.25, 0.25};
detachFromShooter = false;
hitSoundId = SoundLaserHit;
};

LaserData sniperLaser2 
{
laserBitmapName = "shex00.bmp";
hitName = "laserhit.dts";
damageConversion = 0.0111;
baseDamageType = $LaserDamageType;
beamTime = 0.5;
lightRange = 2.0;
lightColor = {1.0, 0.25, 0.25};
detachFromShooter = false;
hitSoundId = SoundLaserHit;
};


LaserData LaserTag 
{
laserBitmapName = "lightningNew.bmp";
hitName = "laserhit.dts";
damageConversion = 0.01;
baseDamageType = $LaserDamageType;
beamTime = 0.5;
lightRange = 2.0;
lightColor = {1.0, 0.25, 0.25 };
detachFromShooter = false;
hitSoundId = SoundLaserHit;
};

LaserData railLaser 
{
laserBitmapName = "paintPulse.bmp";
hitName = "paint.dts";
damageConversion = 0.008;
baseDamageType = $RailDamageType;
beamTime = 1.5;
lightRange = 5.0;
lightColor = {0.25, 1.0, 0.25 };
detachFromShooter = true;
hitSoundId = SoundLaserHit;
};

targetLaserData targetLaser 
{
laserBitmapName = "paintPulse.bmp";
damageConversion = 0.0;
baseDamageType = 0;
lightRange = 2.0;
lightColor = {0.25, 1.0, 0.25 };
detachFromShooter = false;
};

LightningData lightningCharge {
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
lightColor = {0.25, 0.25, 0.85 };
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
lightColor = {0.25, 0.25, 0.85 };
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
lightColor = {0.25, 0.25, 0.85 };
soundId = SoundELFFire;
};

LightningData boltCharge 
{
bitmapName = "trailAdd2.bmp";
damageType = $ElectricityDamageType;
boltLength = 40.0;
coneAngle = 35.0;
damagePerSec = 0.08;
energyDrainPerSec = 60.0;
segmentDivisions = 4;
numSegments = 5;
beamWidth = 0.125;
updateTime = 120;
skipPercent = 0.5;
displaceBias = 0.15;
lightRange = 3.0;
lightColor = {0.25, 0.25, 0.85 };
soundId = SoundELFFire;
};

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) {
if(%damPerSec == 10.0) {
ixLockLaser(%target, %shooterId);
return;
}
if(%damPerSec == 100.0) {
ixVehicleLockLaser(%target, %shooterId);
return;
}
if(%damPerSec == 50.0) {
return;
}
if(%shooterId) {
if(%damPerSec > 0.15) %damageType = $MagneticDamageType;
else %damageType = $ElectricityDamageType;
}
else %damageType = $ElectricityDamageType;
%damVal = %timeSlice * %damPerSec;
%enVal = %timeSlice * %enDrainPerSec;
GameBase::applyDamage(%target, %damageType, %damVal, %pos, %vec, %mom, %shooterId);
%energy = GameBase::getEnergy(%target);
%energy = %energy - %enVal;
if (%energy < 0) {
%energy = 0;
}
GameBase::setEnergy(%target, %energy);
}
 RepairEffectData RepairBolt 
 {
 bitmapName = "repairadd.bmp";
 boltLength = 5.0;
 segmentDivisions = 4;
 beamWidth = 0.125;
 updateTime = 450;
 skipPercent = 0.6;
 displaceBias = 0.15;
 lightRange = 3.0;
 lightColor = {0.85, 0.25, 0.25 };
 };

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 0.05;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else {
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else {
      %player.repairTarget = %target;
		%player.repairRate   = 0.3;
		if (getObjectType(%player.repairTarget) == "Player") {
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
			%player.repairRate   = 0.1;
		}
		else { 
			
   			%name = GameBase::getMapName(%target);
			if(%name == "") {
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if (getObjectType(%player.repairTarget) == "Player") {
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
	if (%object != -1) {
		%client = Player::getClient(%player);
		if (%object == %player) {
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Repair Done");
			}
			else {
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolt::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == RepairGun &&
		 %player.repairTarget != -1) {
		%object = %player.repairTarget;
		if (%object == %player) {
			if (GameBase::getDamageLevel(%player) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}
//-------------------
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
lightColor = {0.85, 0.25, 0.25 };
};

function AutoBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 0.05;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else {
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else {
      %player.repairTarget = %target;
		%player.repairRate   = 0.3;
		if (getObjectType(%player.repairTarget) == "Player") {
			%player.repairRate   = 0.1;
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else { 
			%name = GameBase::getMapName(%target);
			if(%name == "") {
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if (getObjectType(%player.repairTarget) == "Player") {
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		Client::sendMessage(%client,0,"Repairing " @ %name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function AutoBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1) {
		%client = Player::getClient(%player);
		if (%object == %player) {
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Repair Done");
			}
			else {
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function AutoBolt::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == RepairGun &&
		 %player.repairTarget != -1) {
		%object = %player.repairTarget;
		if (%object == %player) {
			if (GameBase::getDamageLevel(%player) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}

//----------------------------------------
SeekingMissileData LowYieldWarhead {
bulletShapeName = "rocket.dts";
explosionTag = flashExpSmall;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.25;
damageType = $LowWarheadDamageType;
explosionRadius = 5.0;
kickBackStrength = 25.0;
muzzleVelocity = 90.0;
terminalVelocity = 120.0;
acceleration = 5.0;
totalTime = 20.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = {1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 0.0;
nonSeekingTurningRadius = 4.0;
proximityDist = 1.5;
lightRange = 5.0;
lightColor = {0.4, 0.4, 1.0 };
trailType = 2;
trailString = "smoke.dts";
smokeDist = 1.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};

function LowYieldWarhead::updateTargetPercentage(%target) {
if(Player::getMountedItem(%target,$BackpackSlot) == "RocketBooster") return 1.0;
else return GameBase::virtual(%target, "getHeatFactor");
}

SeekingMissileData MediumYieldWarhead {
bulletShapeName = "rocket.dts";
explosionTag = rocketExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.5;
damageType = $MedWarheadDamageType;
explosionRadius = 10;
kickBackStrength = 50.0;
muzzleVelocity = 65.0;
terminalVelocity = 80.0;
acceleration = 5.0;
totalTime = 20.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = {1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 0.0;
nonSeekingTurningRadius = 5.0;
proximityDist = 1.5;
lightRange = 5.0;
lightColor = {0.4, 0.4, 1.0 };
trailType = 2;
trailString = "smoke.dts";
smokeDist = 1.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};

function MediumYieldWarhead::updateTargetPercentage(%target) {
if(Player::getMountedItem(%target,$BackpackSlot) == "RocketBooster") return 1.0;
else return GameBase::virtual(%target, "getHeatFactor");
}
SeekingMissileData HighYieldWarhead {
bulletShapeName = "rocket.dts";
explosionTag = mortarExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 1.0;
damageType = $HighWarheadDamageType;
explosionRadius = 10.0;
kickBackStrength = 150.0;
muzzleVelocity = 35.0;
terminalVelocity = 100.0;
acceleration = 5.0;
totalTime = 30.0;
liveTime = 31.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 9.0;
nonSeekingTurningRadius = 20.0;
proximityDist = 1.5;
lightRange = 5.0;
lightColor = { 0.4, 0.4, 1.0 };
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};

function HighYieldWarhead::updateTargetPercentage(%target) {
if(Player::getMountedItem(%target,$BackpackSlot) == "RocketBooster") return 1.0;
else return GameBase::virtual(%target, "getHeatFactor");
}
SeekingMissileData EMPYieldWarhead {
bulletShapeName = "rocket.dts";
explosionTag = flashExpLarge;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.01;
damageType = $EMPWarheadDamageType;
explosionRadius = 5.0;
kickBackStrength = -50.0;
muzzleVelocity = 55.0;
terminalVelocity = 80.0;
acceleration = 5.0;
totalTime = 20.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = {1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 0.0;
nonSeekingTurningRadius = 5.0;
proximityDist = 1.5;
lightRange = 5.0;
lightColor = { 0.4, 0.4, 1.0 };
trailType = 2;
trailString = "fusionbolt.dts";
smokeDist = 1.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};

function EMPYieldWarhead::updateTargetPercentage(%target) {
if(Player::getMountedItem(%target,$BackpackSlot) == "RocketBooster") return 1.0;
else return GameBase::virtual(%target, "getHeatFactor");
}
LightningData LongLockLaser {
bitmapName = "hudtrans.bmp";
damageType = $ElectricityDamageType;
boltLength = 350.0;
coneAngle = 1.0;
damagePerSec = 10.0;
energyDrainPerSec = 0.0;
segmentDivisions = 2;
numSegments = 8;
beamWidth = 0.05;
updateTime = 10;
skipPercent = 0.0;
displaceBias = 0.005;
lightRange = 3.0;
lightColor = {0.0, 1.0, 0.0 };
};

function ixLockLaser(%target, %client) {
%player = Client::getOwnedObject(%client);
%object = getObjectType(%target);
if(!$ixFloodRockets[%client]) {
if(%object == "Player") %targetId = GameBase::getOwnerClient(%target);
else if(%object == "Flier") %targetId = GameBase::getControlClient(%target);
else %targetId = 0;
%lockingObj = getObjectType($ixLockedTarget[%client]);
if(%lockingObj == "Player") %lockingId = GameBase::getOwnerClient($ixLockedTarget[%client]);
else if(%lockingObj == "Flier") %lockingId = GameBase::getControlClient($ixLockedTarget[%client]);
else %lockingId = 1;
if((%target == $ixLockedTarget[%client]) || (%lockingId == %targetId)) {
if($ixLockTime[%client] > $ixLockAquired) {
Player::trigger(%player,$WeaponSlot,false);
GameBase::setEnergy(%player,0);
GameBase::setRechargeRate(%player,0);
Player::unmountItem(%player,$WeaponSlot);
Player::mountItem(%player,MissileLauncher,$WeaponSlot);
schedule("ixFloodRockets(" @ %client @ "," @ %player @ "," @ %target @ "," @ $ixVPayload[%client] @ ",1);",2);
$ixFloodRockets[%client] = true;
ixLockWarning(%client,$ixLockedTarget[%client],%object,0.75,Vengeance);
playSound(SoundPrepVengeance1,GameBase::getPosition(%player));
playSound(SoundPrepVengeance2,GameBase::getPosition(%player));
schedule("Client::sendMessage(" @ %client @ ",1,\"** FIRING!!! **\");",1.5);
schedule("playSound(SoundFireVengeance,GameBase::getPosition(" @ %player @ "));",1.5);
}
else {
if(%object == "Player" || %object == "Flier") $ixLockTime[%client] += $ixLockSpeed[$ixVScanner[%client]];
else $ixLockTime[%client] += ($ixLockSpeed[$ixVScanner[%client]] * $ixLockModifier);
}
}
else {
$ixLockTime[%client] = 0;
$ixLockedTarget[%client] = %target;
if(%object == "Player") {
%tgtClient = GameBase::getOwnerClient($ixLockedTarget[%client]);
%name = Client::getName(%tgtClient);
}
else {
%name = GameBase::getMapName(%target);
if(%name == "") {
%name = (GameBase::getDataName(%target)).description;
}
}
Client::sendMessage(%client,0,"** Vengeance: Scanning " @ %name);
$ixLockedName[%client] = %name;
}
}
}
function ixSin(%theta) {
return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}
function ixCos(%theta) {
return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}
function ixApplyKickback(%player, %strength, %lift) {
if((!%lift) && (%lift != 0)) %lift = 0;
%rot = GameBase::getRotation(%player);
%rad = getWord(%rot, 2);
%x = (-1) * (ixSin(%rad));
%y = ixCos(%rad);
%dir = %x @ " " @ %y @ " 0";
%force = ixDotProd(Vector::neg(%dir),%strength);
%x = getWord(%force, 0);
%y = getWord(%force, 1);
%dir = %x @ " " @ %y @ " " @ %lift;
Player::applyImpulse(%player,%force);
}
function ixLockWarning(%clientId, %target, %object, %delay, %weapon) {
%targetId = GameBase::getControlClient(%target);
%targetName = Client::getName(%targetId);
%name = Client::getName(%clientId);
%player = Client::getOwnedObject(%clientId);
if(%object == Flier) {
if(%targetName != "") %msg = "Vehicle Piloted by " @ %targetName;
else %msg = "Vehicle";
}
else %msg = %targetName;
if(%weapon == Avenger) {
Client::sendMessage(%clientId,0,"** Lock Aquired: " @ %msg);
playSound(SoundLockAquired,GameBase::getPosition(%player));
schedule("playSound(SoundLockWarning,GameBase::getPosition(" @ %target @ "));",%delay);
schedule("Client::sendMessage(" @ %targetId @ ",0,\"** WARNING ** - " @ escapeString(%name) @ " has a Guided Missile Lock!\");",%delay);
schedule("playSound(SoundLockWarning,GameBase::getPosition(" @ %target @ "));",(%delay + 0.5));
schedule("playSound(SoundLockWarning,GameBase::getPosition(" @ %target @ "));",(%delay + 1.0));
}
else {
if(%object == "Player" || %object == "Flier") {
Client::sendMessage(%clientId,0,"** Vengeance: Lock Aquired: " @ %msg @ "~wmine_act.wav");
playSound(SoundLockAquired,GameBase::getPosition(%player));
schedule("Client::sendMessage(" @ %targetId @ ",0,\"** WARNING ** - " @ escapeString(%name) @ " has a Vengeance Missile Lock!\");",%delay);
schedule("playSound(SoundLockWarning,GameBase::getPosition(" @ %target @ "));",(%delay + 0.5));
schedule("playSound(SoundLockWarning,GameBase::getPosition(" @ %target @ "));",(%delay + 1.0));
}
else {
Client::sendMessage(%clientId,0,"** Vengeance: Lock Aquired: " @ GameBase::getDataName(%target) @ "~wmine_act.wav");
playSound(SoundLockAquired,GameBase::getPosition(%player));
}
}
}
function ixFloodRockets(%client, %player, %object, %count, %warhead) {
if($ixFloodRockets[%client]) {
%AmmoCount = Player::getItemCount(%player, "VengeanceAmmo");
if(%AmmoCount) {
%whNow = $ixVWarhead[%client, %warhead];
if((%warhead) && (%count >= %warhead) && (!Player::isDead(%player)) && (Player::getMountedItem(%player,$WeaponSlot) == MissileLauncher)) {
if(%whNow != "Pause") {
if($ixVAmmo[%whNow] <= %AmmoCount) {
%pause = 1;
%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);
playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
Projectile::spawnProjectile(%whNow @ "YieldWarhead",%trans,%player,%vel,%object);
Player::decItemCount(%player,"VengeanceAmmo",$ixVAmmo[%whNow]);
ixApplyKickback(%player, $ixVKick[%whNow] * 150, $ixVKick[%whNow] * 30);
}
else {
playSound(SoundLoadWarhead,GameBase::getPosition(%player));
Client::sendMessage(%client,0,"*** Vengeance: No Ammo to Fire #" @ %warhead @ " - " @ $ixVWarhead[%client, %warhead] @ "~wC_BuySell.wav");
}
}
else {
playSound(SoundLoadWarhead,GameBase::getPosition(%player));
%pause = 1.5;
}
%warhead += 1;
schedule("ixFloodRockets(" @ %client @ "," @ %player @ "," @ %object @ "," @ %count @ "," @ %warhead @ ");",($ixFloodSpeed * %pause));
}
else ixFloodShutdown(%client, %player, "Normal");
}
else ixFloodShutdown(%client, %player, "Ammo");
}
}
function ixFloodShutdown(%client, %player, %error) {
if(%error == "Normal") {
schedule("playSound(SoundUsePack,GameBase::getPosition(" @ %player @ "));",$ixFloodReload + $ixFloodPowerDown);
schedule("playSound(SoundPackFail,GameBase::getPosition(" @ %player @ "));",$ixFloodPowerDown);
schedule("ixRestorePower(" @ %client @ "," @ %player @ ");",$ixFloodPowerDown);
schedule("Player::unmountItem(" @ %player @ "," @ $WeaponSlot @ ");",$ixFloodPowerDown + $ixFloodReload);
schedule("Player::mountItem(" @ %player @ ",LockingLaser," @ $WeaponSlot @ ");",$ixFloodPowerDown + $ixFloodReload);
schedule("$ixFloodRockets[" @ %client @ "] = false;",$ixFloodPowerDown + $ixFloodReload);
schedule("playSound(SoundUsePack,GameBase::getPosition(" @ %player @ "));",$ixFloodReload + $ixFloodPowerDown);
}
else if(%error == "Ammo") {
Client::sendMessage(%client,0,"*** Vengeance: Shutting Down - NO AMMO");
schedule("playSound(SoundUsePack,GameBase::getPosition(" @ %player @ "));",$ixFloodReload + $ixFloodPowerDown);
schedule("playSound(SoundPackFail,GameBase::getPosition(" @ %player @ "));",$ixFloodPowerDown);
schedule("ixRestorePower(" @ %client @ "," @ %player @ ");",$ixFloodPowerDown);
schedule("Player::unmountItem(" @ %player @ "," @ $WeaponSlot @ ");",$ixFloodPowerDown + $ixFloodReload);
schedule("Player::mountItem(" @ %player @ ",LockingLaser," @ $WeaponSlot @ ");",$ixFloodPowerDown + $ixFloodReload);
schedule("$ixFloodRockets[" @ %client @ "] = false;",$ixFloodPowerDown + $ixFloodReload);
schedule("playSound(SoundUsePack,GameBase::getPosition(" @ %player @ "));",$ixFloodReload + $ixFloodPowerDown);
}
else if(%error == "EMP") {
Client::sendMessage(%client,0,"*** Vengeance: Shutting Down - EMP");
schedule("playSound(SoundUsePack,GameBase::getPosition(" @ %player @ "));",$ixFloodReload + $ixFloodPowerDown);
schedule("playSound(SoundPackFail,GameBase::getPosition(" @ %player @ "));",$ixFloodPowerDown);
schedule("$ixFloodRockets[" @ %client @ "] = false;",$ixFloodPowerDown + $ixFloodReload);
schedule("playSound(SoundUsePack,GameBase::getPosition(" @ %player @ "));",$ixFloodReload + $ixFloodPowerDown);
}
else if(%error == "Sniper") {
Client::sendMessage(%client,0,"*** Vengeance: Shutting Down - Damaged");
schedule("playSound(SoundUsePack,GameBase::getPosition(" @ %player @ "));",$ixFloodReload + $ixFloodPowerDown);
schedule("playSound(SoundPackFail,GameBase::getPosition(" @ %player @ "));",$ixFloodPowerDown);
schedule("ixRestorePower(" @ %client @ "," @ %player @ ");",$ixFloodPowerDown);
schedule("$ixFloodRockets[" @ %client @ "] = false;",$ixFloodPowerDown + $ixFloodReload);
schedule("playSound(SoundUsePack,GameBase::getPosition(" @ %player @ "));",$ixFloodReload + $ixFloodPowerDown);
}
}
function ixRestorePower(%clientId, %player) {
if(!$empTime[%client]) GameBase::setRechargeRate(%player,8);
}
function ixCheckVengeance(%client, %item) {
if((%item != LockingLaser) && (%item != MissileLauncher)) return true;
else if($ixFloodRockets[%client]) {
Client::sendMessage(%client,0,"Vengeance: Cannot Abort Firing Sequence.");
return false;
}
else return true;
}
$ixFloodReload = 1.5;
$ixFloodPowerDown = 1.0;
$ixFloodSpeed = 0.25;
$ixLockSpeed[Long] = 0.5;
$ixLockSpeed[Medium] = 0.8;
$ixLockSpeed[Short] = 1.0;
$ixLockAquired = 25;
$ixLockModifier = 0.5;
$ixVKick[Low] = 0.5;
$ixVKick[EMP] = 0.5;
$ixVKick[Medium] = 0.75;
$ixVKick[High] = 1.0;

LightningData ShortLockLaser {
bitmapName = "hudtrans.bmp";
damageType = $ElectricityDamageType;
boltLength = 50.0;
coneAngle = 30.0;
damagePerSec = 10.0;
energyDrainPerSec = 0.0;
segmentDivisions = 2;
numSegments = 8;
beamWidth = 0.05;
updateTime = 10;
skipPercent = 0.0;
displaceBias = 0.005;
lightRange = 3.0;
lightColor = {0.0, 1.0, 0.0 };
};

LightningData MediumLockLaser {
bitmapName = "hudtrans.bmp";
damageType = $ElectricityDamageType;
boltLength = 150.0;
coneAngle = 15.0;
damagePerSec = 10.0;
energyDrainPerSec = 0.0;
segmentDivisions = 2;
numSegments = 8;
beamWidth = 0.05;
updateTime = 10;
skipPercent = 0.0;
displaceBias = 0.005;
lightRange = 3.0;
lightColor = {0.0, 1.0, 0.0 };
};
//----------------------------------------
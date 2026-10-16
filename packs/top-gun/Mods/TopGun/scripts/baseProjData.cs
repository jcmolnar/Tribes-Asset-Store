# Damage Types
#
$ImpactDamageType		  = -1;
$LandingDamageType	  =  0;
$BulletDamageType      =  1;
$EnergyDamageType      =  2;
$PlasmaDamageType      =  3;
$ExplosionDamageType   =  4;
$ShrapnelDamageType    =  5;
$LaserDamageType       =  6;
$MortarDamageType      =  7;
$BlasterDamageType     =  8;
$ElectricityDamageType =  9;
$CrushDamageType       = 10;
$DebrisDamageType      = 11;
$MissileDamageType     = 12;
$MineDamageType        = 13;
// DELTA FORCE
$ChargeDamageType      = 14;
$AirstrikeDamageType   = 15; 
// END DELTA FORCE

// DELTA FORCE PROJECTILES
// -------------------------------------
BulletData PSG1Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $LaserDamageType;

   aimDeflection      = 0.0009;
   muzzleVelocity     = 650.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 5;
};

// -------------------------------------------------

BulletData FiftyCalBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.85;
   damageType         = $LaserDamageType;

   aimDeflection      = 0.0005;
   muzzleVelocity     = 750.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 5;
};

// ---------------------------------------

BulletData NATOBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 50.0;
   tracerLength       = 50;
};

// ---------------------------------------

BulletData SAWBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.18;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.008;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};

// ---------------------------------------------

GrenadeData AntiAirShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.0;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 520;
   totalTime          = 1.0;    // special meaning for grenades...
   liveTime           = 0.5;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

// ---------------------------------------------

GrenadeData AutoGrenShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 0.8;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

// -----------------------------------------

BulletData AutoShotgunFlechette
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.08;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.03;
   muzzleVelocity     = 500.0;
   totalTime          = 1.0;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 5;
};

BulletData AutoShotgunSlug
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.7;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.01;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};

// -----------------------------------------

RocketData AbramsShell
{
   bulletShapeName  = "grenade.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1 radius
   damageValue      = 1.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 5.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 500.0;
   terminalVelocity = 240.0;
   acceleration     = 5.0;
   totalTime        = 8.0;
   liveTime         = 0.5;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;
};

// --------------------------------------------

RocketData AirstrikeShot
{
   bulletShapeName = "discb.dts";
   explosionTag    = mortarExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 20.0;
   damageType       = $AirstrikeDamageType;

   explosionRadius  = 38.0;
   kickBackStrength = 5.0;

   muzzleVelocity   = 4000.0;
   terminalVelocity = 4500.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 0;
   trailWidth  = 0.0;

   soundId = SoundDiscSpin;
};

//GrenadeData AirstrikeShell
//{
//   bulletShapeName    = "magcargo.dts";
//   explosionTag       = mortarExp;
//   collideWithOwner   = True;
//   ownerGraceMS       = 0;
//   collisionRadius    = 0.3;
//   mass               = 2.0;
//   elasticity         = 0.0;

//   damageClass        = 1;       // 0 impact, 1, radius
//   damageValue        = 5.0;
//   damageType         = $AirstrikeDamageType;

//   explosionRadius    = 38.0;
//   kickBackStrength   = 5.0;
//   maxLevelFlightDist = 0;
//   totalTime          = 30.0;
//   liveTime           = 0.0;
//   projSpecialTime    = 0.01;
//
//   inheritedVelocityScale = 0.5;
//   smokeName = "smoke.dts";
//};

GrenadeData AirstrikeShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 6.0;
   damageType         = $AirstrikeDamageType;

   explosionRadius    = 38.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 50.0;
   totalTime          = 100.0;
   liveTime           = 0.5;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};

// ---------------------------------------------

SeekingMissileData StingerMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 300.0;

   muzzleVelocity    = 72.0;
   totalTime         = 15;
   liveTime          = 15;
   seekingTurningRadius    = 6;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

// ---------------------------------------------

SeekingMissileData SparrowMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 225.0;

   muzzleVelocity    = 72.0;
   totalTime         = 12;
   liveTime          = 12;
   seekingTurningRadius    = 4;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

// ---------------------------------------------

SeekingMissileData PhoenixMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 10.5;
   kickBackStrength = 325.0;

   muzzleVelocity    = 72.0;
   totalTime         = 15;
   liveTime          = 15;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 10.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

// ----------------------------------------------

// ---------------------------------------------

SeekingMissileData AMRAAMMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 11.5;
   kickBackStrength = 350.0;

   muzzleVelocity    = 72.0;
   totalTime         = 17;
   liveTime          = 17;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 11.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

RocketData LAWRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 80.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   totalTime        = 8.0;
   liveTime         = 0.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

// --------------------------------------------

GrenadeData Flame
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 9.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 50.0;
   totalTime          = 100.0;
   liveTime           = 0.5;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

GrenadeData AirFlame
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 15.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 50.0;
   totalTime          = 100.0;
   liveTime           = 0.5;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

RocketData FlameExplosion
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 4.0;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 15.0;
   kickBackStrength = 250.0;
   muzzleVelocity   = 0.0001;
   terminalVelocity = 0.0001;
   acceleration     = 0.0001;
   totalTime        = 0.0001;
   liveTime         = 0.0001;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};


// --------------------------------------------

GrenadeData HowitzerShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 2.0;
   elasticity         = 0.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 35.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 325;
   totalTime          = 30.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName = "smoke.dts";
};

GrenadeData BigBomb
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.5;
   damageType         = $AirstrikeDamageType;

   explosionRadius    = 35.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 30.0;
   liveTime           = 0.5;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName = "smoke.dts";
};

GrenadeData ClusterBomb
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = grenadeExp;
   expRandCycle       = 5;
   collideWithOwner   = False;
   ownerGraceMS       = 250;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.60;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.5;
   damageType         = $ShrapnelDamageType;

   aimDeflection      = 0.03;
   muzzleVelocity     = 500.0;
   explosionRadius    = 35.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 175;
   totalTime          = 30.0;
   liveTime           = 0.8;
   projSpecialTime    = 0.01;

   tracerPercentage   = 100.0;
   tracerLength       = 5;

   inheritedVelocityScale = 1.0;
   smokeName = "smoke.dts";
};

// ---------------------------------------------

TargetLaserData AirstrikeLaserTemp
{
   laserBitmapName   = "laserPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};
//TODO: Finish this

// ------------------------------------------

RocketData ApacheRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.35;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 80.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   totalTime        = 8.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

// ------------------------------------------

RocketData MaverickRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.35;
   damageType       = $MissileDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 80.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   totalTime        = 8.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};


// --------------------------------------------

BulletData WarthogBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = rocketExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $ExplosionDamageType;

   aimDeflection      = 0.001;
   muzzleVelocity     = 650.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 50.0;
   tracerLength       = 10;
};

// ---------------------------------------------
// END DELTA FORCE PROJECTILES

//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 50.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//--------------------------------------
BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------
BulletData BlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.125;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------
BulletData PlasmaBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.45;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 55.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//--------------------------------------
RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

//--------------------------------------
GrenadeData GrenadeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

//--------------------------------------
GrenadeData MortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//--------------------------------------
GrenadeData MortarTurretShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.32;
   damageType         = $MortarDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 400;
   totalTime          = 1000.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//--------------------------------------
RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData TurretMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

function SeekingMissile::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}

//-------------------------------------- 
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------
LaserData sniperLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.0;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

TargetLaserData targetLaser
{
   //laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 1.0;
   lightColor        = { 1, 0, 0 };

   detachFromShooter = false;
};

// DELTA FORCE

LaserData Grapple
{
	laserBitmapName = "paintPulse.bmp";

	damageConversion = 0.0;
	baseDamageType = 0;

	beamTime          = 0.2;

	lightRange = 0.0;
	lightColor = { 0, 0, 0 };

	detachFromShooter = false;
};

LightningData AirstrikeLaser
{
   bitmapName       = "paintPulse.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 150.0;
   coneAngle        = 10.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.0;
   segmentDivisions = 1;
   numSegments      = 1;
   beamWidth        = 1.0;

   updateTime   = 10;
   skipPercent  = 0.0;
   displaceBias = 0.005;

   lightRange = 3.0;
   lightColor = { 0.0, 1.0, 0.0 };

   soundId = SoundELFFire;
};

// END DELTA FORCE

LightningData lightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 10.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.0;
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

LightningData turretCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function Vector::scale(%vec, %scalar)
{
	%x = getWord(%vec, 0);
	%y = getWord(%vec, 1);
	%z = getWord(%vec, 2);

	%x *= %scalar;
	%y *= %scalar;
	%z *= %scalar;

	%result = %x @ " " @ %y @ " " @ %z;

	return %result;
}

// Lightning damage is now the reloader pack code
function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%client = Player::getClient(%shooterId);
	if($ReloaderPackLeft[%client] <= 0)
	{
		Bottomprint(%shooterId, "<jc>Reloader Pack Empty", 2);
		Player::trigger(%player, $WeaponSlot, false);	
		return;
	}

	// DELTAFORCE
	%targetType = GameBase::getDataName(%target);
	if (%targetType == PlasmaTurret || %targetType == DeployablePlasma || %targetType == MortarTurret || %targetType == DeployableMortar || %targetType == DeployableAA) {
		if(GameBase::getEnergy(%target) < %targetType.maxEnergy) {
			GameBase::setEnergy(%target, GameBase::getEnergy(%target) + ((%targetType.maxEnergy / 4) * %timeSlice));
			if(GameBase::getEnergy(%target) >= %targetType.maxEnergy) {
				GameBase::setEnergy(%target, %targetType.maxEnergy); 
				%reloadDone[0] = 1;
				%reloadDone[1] = 1;
			}
		} else {
			%reloadDone[0] = 1;
			%reloadDone[1] = 1;
		}
	} else if (%targetType == Abrams || %targetType == Blackhawk || %targetType == Humvee) {
		for(%i = 2; %i < 4; %i++) {
			if($PassengerSlot[%target, %i] != 0) {
				%item = Player::getItemCount($PassengerSlot[%target, %i], $VehicleAmmoType[%targetType, %i]);
				if (%item != $VehicleAmmoMax[ %targetType, $VehicleAmmoType[%targetType, %i] ]) {
					Player::incItemCount($PassengerSlot[%target, %i], $VehicleAmmoType[%targetType, %i], %timeSlice * $VehicleReloadRate[ $VehicleAmmoType[%targetType, %i] ]);
					if (Player::getItemCount($PassengerSlot[%target, %i], $VehicleAmmoType[%targetType, %i]) > $VehicleAmmoMax[ $VehicleAmmoType[%targetType, %i] ]) {
						Player::setItemCount($PassengerSlot[%target, %i], $VehicleAmmoType[%targetType, %i], $VehicleAmmoMax[ %targetType, $VehicleAmmoType[%targetType, %i] ]);
						%reloadDone[%i-2] = 1;
					}
				} else %reloadDone[%i-2] = 1;
			} else {
				if ($VehicleAmmo[%target, $AmmoWeapon[ $VehicleAmmoType[%targetType, %i] ] ] != $VehicleAmmoMax[ %targetType, $VehicleAmmoType[%targetType, %i] ]) {
					$VehicleAmmo[%target, $AmmoWeapon[ $VehicleAmmoType[%targetType, %i] ] ] += %timeSlice * $VehicleReloadRate[ $VehicleAmmoType[%targetType, %i] ];
					if($VehicleAmmo[%target, $AmmoWeapon[ $VehicleAmmoType[%targetType, %i] ] ] > $VehicleAmmoMax[ %targetType, $VehicleAmmoType[%targetType, %i] ]) {
						$VehicleAmmo[%target, $AmmoWeapon[ $VehicleAmmoType[%targetType, %i] ] ] = $VehicleAmmoMax[ %targetType, $VehicleAmmoType[%targetType, %i] ];
						%reloadDone[%i-2] = 1;
					}
				} else %reloadDone[%i-2] = 1;
			}
		}
	} else if (%targetType == Warthog || %targetType == MoveWarthog || %targetType == Apache) {
		for(%i = 0; %i < $VehiclePrimaryGuns[%targetType]; %i++)
		{
			%weapName = $VehicleWeapon[%targetType, %i];
			if($VehicleWeaponAmmo[%target, %weapName] < $VehicleWeaponAmmoMax[%targetType, %weapName])
			{
				$amountReloaded[%i] = %timeSlice * $WeaponReloadRate[%weapName];
				$VehicleWeaponAmmo[%target, %weapName] += $amountReloaded[%i];
				if($VehicleWeaponAmmo[%target, %weapName] >= $VehicleWeaponAmmoMax[%targetType, %weapName])
				{
					$VehicleWeaponAmmo[%target, %weapName] = $VehicleWeaponAmmoMax[%targetType, %weapName];
					$amountReloaded[%i] = 0;
				}
			}
		}

		%tempAdd = 0;
		for(%i = 0; %i < $VehiclePrimaryGuns[%targetType]; %i++)
		{
			%tempAdd += $amountReloaded[%i];
			$amountReloaded[%i] = 0;
		}

		if(%tempAdd == 0)
		{
			%reloadDone[0] = 1;
			%reloadDone[1] = 1;
		}
	} else {
		if ($MessagePause[%shooterId] == 0) {
			Client::sendMessage(%shooterId,0,"Invalid target for reloading");
			$MessagePause[%shooterId] = 1;
			schedule("$MessagePause["@%shooterId@"] = 0;", 2);
			Player::trigger(%player, $WeaponSlot, false);	
		}
		return;
	}

	if (%reloadDone[0] == 1 && %reloadDone[1] == 1) {
		if ($MessagePause[%shooterId] == 0) {
			Client::sendMessage(%shooterId,0,"Reload completed");
			$MessagePause[%shooterId] = 1;
			schedule("$MessagePause["@%shooterId@"] = 0;", 2);
			Player::trigger(%player, $WeaponSlot, false);	
		}
		return;
	}

	$ReloaderPackLeft[%client] -= %timeSlice * 8;
	Bottomprint(%shooterId, "<jc>" @ $ReloaderPackLeft[%client] @ "% Remaining in Reloader Pack", 2);

	// END DELTAFORCE
}

RepairEffectData RepairBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 5.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

RepairEffectData MedicBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 5.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.0, 0.0, 1.0 };
};

function MedicBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 0.05;
			%player.repairTarget = %player;
			GameBase::setAutoRepairRate(%player.repairTarget, %player.repairRate);
			Client::sendMessage(%client, 0, "AutoHeal On");
		}
		else {
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else {
		%player.repairTarget = %target;
		%player.repairRate   = 0.1;
		
		if (getObjectType(%player.repairTarget) == "Player") {
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
			if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
				Client::sendMessage(%client,0,%name @ " is not wounded");
				Player::trigger(%player,$WeaponSlot,false);
				%player.repairTarget = -1;
				return;
			}
			Client::sendMessage(%rclient,0,"Being healed by " @ Client::getName(%client));
			Client::sendMessage(%client,0,"Healing " @ %name);
			%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
			GameBase::setAutoRepairRate(%player.repairTarget,%rate);
		} else {
			Client::sendMessage(%client,0,"You can't heal an inanimate object...");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
	}
}

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		Client::sendMessage(%client,0,"Nothing in range");
		Player::trigger(%player, $WeaponSlot, false);
		return;
	} else {
		%player.repairTarget = %target;
		%player.repairRate   = 0.1;
		
		if (getObjectType(%player.repairTarget) == "Player") {
			Client::sendMessage(%client,0,"You can't repair a person...");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		} else {
			%name = GameBase::getMapName(%target);
			if(%name == "") {
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
			if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
				Client::sendMessage(%client,0,%name @ " is not damaged");
				Player::trigger(%player,$WeaponSlot,false);
				%player.repairTarget = -1;
				return;
			}
			Client::sendMessage(%client,0,"Repairing " @ %name);
			%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
			GameBase::setAutoRepairRate(%player.repairTarget,%rate);	
		}
	}
}

function MedicBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1) {
		%client = Player::getClient(%player);
		if (%object == %player) {
			Client::sendMessage(%client,0,"AutoHeal Off");
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Healing Complete");
			}
			else {
				Client::sendMessage(%client,0,"Healing Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1) {
		if (GameBase::getDamageLevel(%object) == 0) {
			Client::sendMessage(%client,0,"Repair Done");
		} else {
			Client::sendMessage(%client,0,"Repair Stopped");
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function MedicBolt::checkDone(%this, %player)
{
	%mountItem = Player::getMountedItem(%player,$WeaponSlot);
	if (Player::isTriggered(%player,$WeaponSlot) && 
	%mountItem == MedicGun && %player.repairTarget != -1) {
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

function RepairBolt::checkDone(%this, %player)
{
	%mountItem = Player::getMountedItem(%player,$WeaponSlot);
	if (Player::isTriggered(%player,$WeaponSlot) && 
       %mountItem == RepairGun && %player.repairTarget != -1) {
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

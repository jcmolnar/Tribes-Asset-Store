//exec("baseExpData.cs");
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
$NeedleDamageType      =  14;
$ShockerDamageType      =  15;
$gBulletDamageType      =  16;

//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
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
   tracerLength       = 28;
};

BulletData ChaingunBullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.05;
   muzzleVelocity     = 427.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 35;
};

BulletData ChaingunBullet3
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.007;
   muzzleVelocity     = 420.0;
   totalTime          = 1.6;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};


BulletData zapBullet
{
   bulletShapeName    = "chainspk.dts";
   validateShape      = true;
   explosionTag       = zapExp;
   expRandCycle       = 0;
   mass               = 3;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $NeedleDamageType;

   aimDeflection      = 0;
   muzzleVelocity     = 100;
   totalTime          = 0.05;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 0;
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
   damageType         = $ElectricityDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 3.2;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;
   trailType   = 1;
   trailLength = 5;
   trailWidth  = 0.2;

   rotationPeriod = 1;
};

RocketData ChargeBolt
{
   bulletShapeName = "enbolt.dts";
   explosionTag    = energyExp;

   collisionRadius = 0.0;
   mass            = 0.3;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.08;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 0;
   kickBackStrength = 0.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 115.0;
   acceleration     = 5.0;

   totalTime        = 2.5;
   liveTime         = 2.0;

   lightRange       = 5.0;
   lightColor       = { 0.1, 0.2, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 10;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

RocketData MFBolt
{
   bulletShapeName = "enbolt.dts";
   explosionTag    = energyExp;

   collisionRadius = 0.0;
   mass            = 0.3;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 0.5;
   kickBackStrength = 0.0;

   muzzleVelocity   = 81.0;
   terminalVelocity = 83.0;
   acceleration     = 4.0;

   totalTime        = 2.5;
   liveTime         = 2.0;

   lightRange       = 5.0;
   lightColor       = { 0.1, 0.2, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 10;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};


RocketData BurstingBolt1
{
   bulletShapeName = "enbolt.dts";
   explosionTag    = energyExp;

   collisionRadius = 0.0;
   mass            = 0.3;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 0.5;
   kickBackStrength = 0.0;

   muzzleVelocity   = 80.0;
   terminalVelocity = 83.0;
   acceleration     = 5.0;

   totalTime        = 2.5;
   liveTime         = 2.0;

   lightRange       = 5.0;
   lightColor       = { 0.1, 0.2, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 10;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

RocketData BurstingBolt2
{
   bulletShapeName = "enbolt.dts";
   explosionTag    = energyExp;

   collisionRadius = 0.0;
   mass            = 0.3;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 0.5;
   kickBackStrength = 0.0;

   muzzleVelocity   = 82.0;
   terminalVelocity = 84.0;
   acceleration     = 5.0;

   totalTime        = 2.5;
   liveTime         = 2.0;

   lightRange       = 5.0;
   lightColor       = { 0.1, 0.2, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 10;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};


RocketData BurstingBolt3
{
   bulletShapeName = "enbolt.dts";
   explosionTag    = energyExp;

   collisionRadius = 0.0;
   mass            = 0.3;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 0.5;
   kickBackStrength = 0.0;

   muzzleVelocity   = 78.0;
   terminalVelocity = 81.0;
   acceleration     = 5.0;

   totalTime        = 2.5;
   liveTime         = 2.0;

   lightRange       = 5.0;
   lightColor       = { 0.1, 0.2, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 10;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

RocketData BurstingBolt4
{
   bulletShapeName = "enbolt.dts";
   explosionTag    = energyExp;

   collisionRadius = 0.0;
   mass            = 0.3;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 0.5;
   kickBackStrength = 0.0;

   muzzleVelocity   = 77.0;
   terminalVelocity = 82.0;
   acceleration     = 5.0;

   totalTime        = 2.5;
   liveTime         = 2.0;

   lightRange       = 5.0;
   lightColor       = { 0.1, 0.2, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 10;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

RocketData BurstingBolt5
{
   bulletShapeName = "enbolt.dts";
   explosionTag    = energyExp;

   collisionRadius = 0.0;
   mass            = 0.3;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 0.5;
   kickBackStrength = 0.0;

   muzzleVelocity   = 82.0;
   terminalVelocity = 85.0;
   acceleration     = 5.0;

   totalTime        = 2.5;
   liveTime         = 2.0;

   lightRange       = 5.0;
   lightColor       = { 0.1, 0.2, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 10;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
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
   damageValue        = 0.02;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 95.0;
   totalTime          = 0.8;
   liveTime           = 0.5;
   lightRange         = 1.0;
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

RocketData RocketShell
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 5;
   kickBackStrength = 175.0;

   muzzleVelocity   = 85.0;
   terminalVelocity = 90.0;
   acceleration     = 5.0;

   totalTime        = 3.5;
   liveTime         = 3.0;

   lightRange       = 5.0;
   lightColor       = { 1.4, 0.1, 0.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
GrenadeData GrenadeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 5.0;
   elasticity         = 0.5;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 100.0;
   maxLevelFlightDist = 55;
   totalTime          = 15.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.4;

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
   damageType       = $EnergyDamageType;
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

   damageConversion  = 0.007;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData railLaser
{
   laserBitmapName   = "blite00.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.008;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 1.25 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};

TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

LightningData lightningCharge
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

LightningData lightCharge
{
   bitmapName       = "lightningnew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 80.0;
   coneAngle        = 1;
   damagePerSec      = 0.2;
   energyDrainPerSec = 0.0;
   segmentDivisions = 1;
   numSegments      = 1;
   beamWidth        = 0.5;//075;

   updateTime   = 120;
   skipPercent  = 0.03;
   displaceBias = 0.01;

   lightRange = 3.0;
   lightColor = { 0.2, 0.2, 1.5 };

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

BulletData Shock
{
   bulletShapeName = "fusionbolt.dts";
   explosionTag    = LargeShockwave;


   damageClass        = 1;
   damageValue        = 0.1;
   damageType         = $ShockerDamageType;
   explosionRadius    = 10.0;
   energyDrainPerSec = 200;
   muzzleVelocity     = 65.0;
   totalTime          = 4.0;
   liveTime           = 3.0;
   lightRange         = 3.0;
   lightColor         = { 0, 0, 1.5 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetHeavy;
};

RocketData NeedleRocket
{
   bulletShapeName  = "laserhit.dts";
   explosionTag     = blasterExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.01;
   damageType       = $NeedleDamageType;

   kickBackStrength = 175.0;
   muzzleVelocity   = 90.0;
   terminalVelocity = 90.0;
   acceleration     = 0;
   totalTime        = 1.2;
   liveTime         = 1.2;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0, 0.8 };
   inheritedVelocityScale = 0;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "laserhit.dts";
   smokeDist   = 1.8;

   soundId = SoundFireBlaster;
};

SeekingMissileData NeedleMissile
{
   bulletShapeName = "laserhit.dts";
   explosionTag    = blasterExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.01;
   damageType       = $NeedleDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 90.0;
   totalTime         = 1.2;
   liveTime          = 1.2;
   seekingTurningRadius    = 15;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1;

   lightRange       = 5.0;
   lightColor       = { 1.4, 0.1, 0.8 };
   trailString = "laserhit.dts";
   inheritedVelocityScale = 0.5;
   soundId = SoundJetHeavy;
};

LaserData hander1Laser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.0;
   baseDamageType    = $LaserDamageType;
   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 0.0, 2.0, 1.25 };

   detachFromShooter = false;
};

LaserData handedLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.003;
   baseDamageType    = $LaserDamageType;
   beamTime          = 0.5;

   lightRange        = 1.5;
   lightColor        = { 1.0, 0, 0 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LightningData handCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   coneAngle        = 5.0;
   damagePerSec      = 2.6;
   energyDrainPerSec = 20;
   segmentDivisions = 2;
   numSegments      = 2;
   beamWidth        = 0.2;//075;

   updateTime   = 120;
   skipPercent  = 0.75;
   displaceBias = 0.25;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

RocketData dustShell
{
   bulletShapeName = "rocket.dts";
   explosionTag    = largeShockwave;

   collisionRadius = 0.0;
   mass            = 3.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.7;
   damageType       = $MissileDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 75.0;
   terminalVelocity = 95.0;
   acceleration     = 8.0;

   totalTime        = 9.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 1.4, 0.4, 0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plastrail.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};


RocketData dusterShell
{
   bulletShapeName = "rocket.dts";
   explosionTag    = largeShockwave;

   collisionRadius = 0.0;
   mass            = 2.5;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.7;
   damageType       = $MissileDamageType;

   explosionRadius  = 2.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 78.0;
   terminalVelocity = 93.0;
   acceleration     = 9.0;

   totalTime        = 9.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 1.4, 0.4, 0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plastrail.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};

GrenadeData throwingBullet
{
   bulletShapeName    = "laserhit.dts";
   explosionTag       = debrisExpLarge;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 2.0;
   mass               = 5.0;
   elasticity         = 0.01;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.0;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 15.0;
   kickBackStrength   = 5.0;
   maxLevelFlightDist = 0.1;
   totalTime          = 0.3;
   liveTime           = 0.2;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.02;
   smokeName          = "laserhit.dts";
   smokeDist	      = 0.1;
};

BulletData gunBullet1
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1;
   expRandCycle       = 0;
   mass               = 0.1;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.17;
   damageType         = $gBulletDamageType;
   kickBackStrength   = 5.0;

   aimDeflection      = 0.05;
   muzzleVelocity     = 300.0;
   totalTime          = 0.09;
   inheritedVelocityScale = 0.09;
   isVisible          = True;

   tracerPercentage   = 2.0;
   tracerLength       = 30;
};

BulletData gunBullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 0;
   mass               = 0.1;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.17;
   damageType         = $gBulletDamageType;
   kickBackStrength   = 5.0;

   aimDeflection      = 0.001;
   muzzleVelocity     = 275.0;
   totalTime          = 0.07;
   inheritedVelocityScale = 0.02;
   isVisible          = True;

   tracerPercentage   = 10.0;
   tracerLength       = 30;
};

BulletData gunBullet3
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1;
   expRandCycle       = 0;
   mass               = 0.1;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.17;
   damageType         = $gBulletDamageType;
   kickBackStrength   = 5.0;

   aimDeflection      = 0.02;
   muzzleVelocity     = 300.0;
   totalTime          = 0.07;
   inheritedVelocityScale = 0.042;
   isVisible          = True;

   tracerPercentage   = 2.0;
   tracerLength       = 30;
};

BulletData gunBullet4
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1;
   expRandCycle       = 0;
   mass               = 0.1;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.17;
   damageType         = $gBulletDamageType;
   kickBackStrength   = 5.0;

   aimDeflection      = 0.051;
   muzzleVelocity     = 289.0;
   totalTime          = 0.09;
   inheritedVelocityScale = 0.042;
   isVisible          = True;

   tracerPercentage   = 2.0;
   tracerLength       = 30;
};

BulletData gunBullet5
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1;
   expRandCycle       = 0;
   mass               = 0.1;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.17;
   damageType         = $gBulletDamageType;
   kickBackStrength   = 5.0;

   aimDeflection      = 0.034;
   muzzleVelocity     = 300.0;
   totalTime          = 0.08;
   inheritedVelocityScale = 0.042;
   isVisible          = True;

   tracerPercentage   = 3.0;
   tracerLength       = 20;
};

RocketData FarterShell
{
   bulletShapeName = "rsmoke.dts";
   explosionTag    = bulletExp0;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $gBulletDamageType;

   explosionRadius  = 0;
   kickBackStrength = 15.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 6.0;

   totalTime        = 0.03;
   liveTime         = 0.02;

   lightRange       = 5.0;
   lightColor       = { 1.4, 0.2, 0.1 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                
   trailString = "rsmoke.dts";
   smokeDist   = 0.5;

   soundId = SoundJetHeavy;
};

GrenadeData FlamadeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.15;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.56;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 12;
   kickBackStrength   = 100.0;
   maxLevelFlightDist = 100;
   totalTime          = 3.0;    // special meaning for grenades...
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.7;

   smokeName              = "plastrail.dts";
};

RocketData FlieryShell
{
   bulletShapeName = "rocket.dts";
   explosionTag    = grenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.35;
   damageType       = $MissileDamageType;

   explosionRadius  = 3.5;
   kickBackStrength = 15.0;

   muzzleVelocity   = 80.0;
   terminalVelocity = 95.0;
   acceleration     = 8.0;

   totalTime        = 4.5;
   liveTime         = 4.0;

   lightRange       = 5.0;
   lightColor       = { 1.4, 0.4, 0.1 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                
   trailString = "plasmatrail.dts";
   smokeDist   = 2.5;

   soundId = SoundJetHeavy;
};

LightningData grabelBeam
{
   bitmapName       = "zap01.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 25.0;
   coneAngle        = 15.0;
   damagePerSec      = 0.07;
   energyDrainPerSec = 100.0;
   segmentDivisions = 2;
   numSegments      = 3;
   beamWidth        = 0.25;//0.75;

   updateTime   = 120;
   skipPercent  = 0.3;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0, 1.85, 0.85 };

   soundId = SoundJetHeavy;
};

LightningData daggerBeam
{
   bitmapName       = "zap05.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 3.0;
   coneAngle        = 1.0;
   damagePerSec      = 1;
   energyDrainPerSec = 100.0;
   segmentDivisions = 1;
   numSegments      = 1;
   beamWidth        = 0.75;

   updateTime   = 120;
   skipPercent  = 0.1;
   displaceBias = 0.01;

   lightRange = 3.0;
   lightColor = { 0, 0.85, 1.85 };

   soundId = SoundJetHeavy;
};

RocketData RepRock
{
   bulletShapeName = "bullet.dts";
   explosionTag    = repperExp;

   mass            = 0.5;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = -0.15;
   damageType       = $ExplosionDamageType;

   kickBackStrength = 1.0;

   muzzleVelocity   = 30.0;
   terminalVelocity = 32.0;
   acceleration     = 5.0;

   totalTime        = 0.04;
   liveTime         = 0.04;

   lightRange       = 5.0;
   lightColor       = { 2.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 1;
   trailWidth  = 0.15;

   soundId = SoundELFfire;
};

RocketData SnipingShell
{
   bulletShapeName = "bullet.dts";
   explosionTag    = bulletExp1;

   mass            = 0.5;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.68;
   damageType       = $LaserDamageType;

   kickBackStrength = 150.0;

   muzzleVelocity   = 580.0;
   terminalVelocity = 590.0;
   acceleration     = 5.0;

   totalTime        = 2;
   liveTime         = 1;

   lightRange       = 5.0;
   lightColor       = { 0.4, 1.4, 0.74 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 20;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

RocketData FlamingRocket
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = plasmatdfExp;
   collisionRadius  = 0.0;
   mass             = 4.8;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 3.8;
   kickBackStrength = 0.0;
   muzzleVelocity   = 30.0;
   terminalVelocity = 35.0;
   acceleration     = 5.0;
   totalTime        = 1;
   liveTime         = 1;
   lightRange       = 2.0;
   lightColor       = { 1.2, 1, 0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 0.4;

   soundId = SoundJetHeavy;
};

RocketData Flaming2Rocket
{
   bulletShapeName  = "plasmatrail.dts";
   explosionTag     = plasmatdfExp;
   collisionRadius  = 0.0;
   mass             = 3.8;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 1.2;
   kickBackStrength = 0.0;
   muzzleVelocity   = 20.0;
   terminalVelocity = 25.0;
   acceleration     = 5.0;
   totalTime        = 0.5;
   liveTime         = 0.5;
   lightRange       = 0.0;
   lightColor       = { 1.2, 1, 0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 0.3;

   soundId = SoundJetHeavy;
};

RocketData FlamShell { bulletShapeName = "plasmabolt.dts"; explosionTag = plasmatdfExp; collisionRadius = 0.2; mass = 4.4; damageClass = 1; damageValue = 0.1; damageType = $PlasmaDamageType; explosionRadius  = 0.5; kickBackStrength = 0.15; muzzleVelocity = 30.0; terminalVelocity = 35.0; acceleration = 5.0; totalTime = 0.5; liveTime = 0.7; lightRange = 6.0; lightColor = { 2.0, 0.2, 0.1 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "plasmabolt.dts"; smokeDist = 0.4; soundId = SoundJetHeavy; };

RocketData FlamShell1 { bulletShapeName = "plasmatrail.dts"; explosionTag = plasmatdfExp; collisionRadius = 0.2; mass = 4.4; damageClass = 1; damageValue = 0.1; damageType = $PlasmaDamageType; explosionRadius  = 0.5; kickBackStrength = 0.05; muzzleVelocity = 15.0; terminalVelocity = 15.0; acceleration = 1.0; totalTime = 0.3; liveTime = 0.4; lightRange = 6.0; lightColor = { 1.0, 0.1, 0.1 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "plasmatrail.dts"; smokeDist = 0.2; soundId = SoundJetHeavy; };

GrenadeData ClayBullet1
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "paint.dts";
   smokeDist          = 0.01;
};

GrenadeData ClayBullet2
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 100;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "paint.dts";
   smokeDist          = 0.01;
};

GrenadeData ClayBullet3
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 225;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "paint.dts";
   smokeDist          = 0.01;
};

GrenadeData ClayBullet4
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 200;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "paint.dts";
   smokeDist          = 0.01;
};

GrenadeData ClayBullet5
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 250;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "paint.dts";
   smokeDist          = 0.01;
};

GrenadeData clayBullet6
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "paint.dts";
   smokeDist          = 0.01;
};
///// end

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
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
		%player.repairRate   = 0.1;
		if (getObjectType(%player.repairTarget) == "Player") {
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

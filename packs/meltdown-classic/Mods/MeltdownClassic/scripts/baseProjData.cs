//=============================================================================================
# Damage Types

$ImpactDamageType                  = -1;
$LandingDamageType          =  0;
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
$EMPDamageType         = 14;
$SniperDamageType         = 15;
$MethaneDamageType         = 16;
$ShotgunDamageType         = 17;
$MassDamageType         = 18;
$PBWDamageType         = 19;
$GaussDamageType         = 20;
$VulcanDamageType         = 21;
$DisruptorDamageType         = 22;
$MBDamageType         = 23;
$FusionDamageType                = 24;
$FlameDamageType         = 25;
$FlierBombDamageType         = 26;
$PulseDamageType         = 27;
$MBHeatDamageType         = 28;
$NullDamageType         = 29;

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
BulletData Flamesz
{
   bulletShapeName    = "tumult_large.dts";
   explosionTag       = flameEXP;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.128;
   damageType         = $FlameDamageType;

   explosionRadius  = 12;
   kickBackStrength = 0;

   aimDeflection      = 0.01;
   muzzleVelocity     = 96.0;
   totalTime          = 1;
   inheritedVelocityScale = 1.0;
   isVisible          = True;
};

BulletData ShotgunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = SmokeExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.075;
   damageType         = $ShotgunDamageType;

   aimDeflection      = 0.0375;
   muzzleVelocity     = 999.0;
   totalTime          = 3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData RifleBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.7;
   damageType         = $SniperDamageType;

   muzzleVelocity     = 1425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData RifleBullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $SniperDamageType;

   muzzleVelocity     = 1425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData MassBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = boltexp1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.01;
   damageType       = $MassDamageType;

   explosionRadius  = 5;
   kickBackStrength = 150.0;

   muzzleVelocity     = 1425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData PoisonDart
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.07;
   damageType         = $MethaneDamageType;

   muzzleVelocity     = 1425.0;
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
BulletData PTCBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 100.0;
   totalTime          = 8.0;
   liveTime           = 6.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

BulletData PTCBolt2
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 255.0;
   totalTime          = 8.0;
   liveTime           = 6.0;
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
   damageValue        = 0.2;
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

SeekingMissileData DiscShellTracker
{
bulletShapeName = "discb.dts";
explosionTag = rocketExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.6;
damageType = $ExplosionDamageType;
explosionRadius = 7.5;
kickBackStrength = 200.0;
muzzleVelocity = 85.0;
terminalVelocity = 500.0;
acceleration = 10.0;
totalTime = 20.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 0.0;
nonSeekingTurningRadius = 5.0;
smokeDist         = 15;
proximityDist = 1.5;
lightRange = 5.0;
lightColor = { 0.4, 0.4, 1.0 };
inheritedVelocityScale = 0.5;
soundId = SoundDiscSpin;
};

//--------------------------------------
GrenadeData Smoke2
{
   bulletShapeName    = "rsmoke.dts";
   explosionTag       = smokefade;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.002;
   mass               = -0.25;
   elasticity         = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $NullDamageType;

   kickBackStrength   = 0.0;
   maxLevelFlightDist = 150;
   totalTime          = 1.0;    // special meaning for grenades...
   liveTime           = 0.75;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "rsmoke.dts";
};

//--------------------------------------
GrenadeData Smoke
{
   bulletShapeName    = "rsmoke.dts";
   explosionTag       = smokefade;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.002;
   mass               = -1;
   elasticity         = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $NullDamageType;

   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 1.0;    // special meaning for grenades...
   liveTime           = 0.75;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "rsmoke.dts";
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

RocketData RPG
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = grenadeExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 15;
   kickBackStrength = 150.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 6;

   soundId = SoundJetHeavy;
};

SeekingMissileData SeekingRPG
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = grenadeExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 15;
   kickBackStrength = 150.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 75;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 10;
   smokeDist         = 3.14;

   soundId = SoundJetHeavy;
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

GrenadeData ImpactMortarShell
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
   liveTime           = 0.001;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

GrenadeData EMPGrenadeShell
{
   bulletShapeName    = "mflame.dts";
   explosionTag       = PulseExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $EMPDamageType;

   explosionRadius    = 10;
   kickBackStrength   = 0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 0.25;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "fusionbolt.dts";
   soundId = SoundELFFire;
};

RocketData RPM
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $MortarDamageType;

   explosionRadius  = 20;
   kickBackStrength = 250.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 6;

   soundId = SoundJetHeavy;
};

SeekingMissileData SeekingRPM
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $MortarDamageType;

   explosionRadius  = 20;
   kickBackStrength = 250.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 75;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 10;
   smokeDist         = 3.14;

   soundId = SoundJetHeavy;
};

RocketData RPEMP
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = PulseExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $EMPDamageType;

   explosionRadius  = 10;
   kickBackStrength = 0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 6;

   soundId = SoundJetHeavy;
};

SeekingMissileData SeekingRPEMP
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = PulseExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $EMPDamageType;

   explosionRadius  = 10;
   kickBackStrength = 0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 75;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 10;
   smokeDist         = 3.14;

   soundId = SoundJetHeavy;
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
   trailString = "smoke.dts";
   smokeDist   = 15;

   soundId = SoundJetHeavy;
};

RocketData StdRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = boltexp5;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

RocketData SuperBlaster
{
   bulletShapeName  = "shotgunbolt.dts";
   explosionTag     = boltexp1;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $BlasterDamageType;

   explosionRadius  = 3;
   kickBackStrength = 50.0;
   muzzleVelocity   = 200.0;
   terminalVelocity = 300.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 15.7;

   soundId = SoundJetHeavy;
};

RocketData DisruptorBeam
{
   bulletShapeName  = "paint.dts";
   explosionTag     = boltexp2;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $EnergyDamageType;

   explosionRadius  = 7;
   kickBackStrength = 50.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "paint.dts";
   smokeDist   = 15.7;

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
   seekingTurningRadius    = 75;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 10;
   smokeDist         = 3.14;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

SeekingMissileData TurretMissile2
{
   bulletShapeName = "rocket.dts";
   explosionTag    = AODStingerExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.65;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 128.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 75;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 10;
   smokeDist         = 3.14;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

RocketData Culex
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = boltexp5;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 128.0;
   terminalVelocity = 132.0;
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

SeekingMissileData Culexx
{
   bulletShapeName = "mortar.dts";
   explosionTag    = boltexp5;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 128.0;
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
   laserBitmapName   = "laserpulse.bmp"; //warp
   hitName           = "laserhit.dts";

   damageConversion  = 0.007;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData DesignatorX
{
   laserBitmapName   = "paintpulse.bmp";
   hitName           = "paint.dts";

   damageConversion  = 0.0;
   baseDamageType    = $NullDamageType;

   beamTime          = 5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = explosion3;
};

LaserData ParticleBeam
{
   laserBitmapName   = "warp.bmp";
   hitName           = "shockwave_large.dts";

   damageConversion  = 0.064;
   baseDamageType    = $PBWDamageType;

   beamTime          = 1;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundFlierCrash;
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
   boltLength       = 50.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.25;
   energyDrainPerSec = 100.0;
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
   boltLength       = 50.0;
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
        %Tp=Gamebase::getTeam(%player);
        %Tt=GameBase::getTeam(%target);
        %client = Player::getClient(%player);

        if (%Tp!=%Tt && %Tt!=-1)
        {        Client::sendMessage(%client, 0, "REPAIR PACK OVERLOAD!! : This Repair pack is NOT Compatable with this Equipment!!~wError_Message.wav");
                %player.Overloaded=true;
                %Pos=GameBase::getPosition(%player);
                playsound(ForceFieldFeedback,%pos);
                return;
        }

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
if(%player.overloaded==true)
        {        // Drop & Delete Pack....
                if($matchStarted)
                {        Player::trigger(%player, $WeaponSlot, false);
                        %item=Player::getMountedItem(%player,$BackpackSlot);
                        %mounted = Player::getMountedItem(%player,$WeaponSlot);
                        if (%mounted == RepairGun)
                        {        Player::unmountItem(%player,$WeaponSlot);
                        }
                        else
                        {        // Remount the existing weapon to make sure the RepairGun
                                // is not on the delayed mount "stack".
                                Player::mountItem(%player,%mounted,$WeaponSlot);
                        }

                        Player::decItemCount(%player,%item,1);

                        // Create a Grenade that looks like a repair pack...

                        %obj = newObject("","Mine","pocketnuke1");
                        addToSet("MissionCleanup", %obj);
                        // Drop It.. & Detonate in .2 Second...
                        GameBase::throw(%obj,%player,0.5,false);
                }
                return;
        }

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

//--------------------------------------
BulletData GaussBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp3;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $GaussDamageType;

   explosionRadius    = 7.5;
   aimDeflection      = 0.005;
   muzzleVelocity     = 725.0;
   totalTime          = 10.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData GatlingBlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 1;
   damageValue        = 0.1;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 700.0;
   explosionRadius    = 2.5;
   totalTime          = 10.0;
   liveTime           = 8.255;
   aimDeflection      = 0.0075;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

RocketData IonShok
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = boltExp6;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.09;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 16;
   kickBackStrength = 12.0;
   muzzleVelocity   = 512.0;
   terminalVelocity = 768.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "fusionbolt.dts";
   smokeDist   = 3.14;

   soundId = SoundELFIdle;
};

RocketData InoShock6
{
   bulletShapeName  = "shield_medium.dts";
   explosionTag     = ionExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.79;
   damageType       = $MBDamageType;

   explosionRadius  = 16;
   kickBackStrength = 512.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 115.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shockwave_large.dts";
   smokeDist   = 15;

   soundId = SoundELFIdle;
};

RocketData IonShock3
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = ionExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1;
   damageType       = $MBDamageType;

   explosionRadius  = 16;
   kickBackStrength = 512.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 115.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "fusionbolt.dts";
   smokeDist   = 4;

   soundId = SoundELFIdle;
};

RocketData IonShock4
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = ionExp_3;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $EMPDamageType;

   explosionRadius  = 16;
   kickBackStrength = 64.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 115.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "paint.dts";
   smokeDist   = 4;

   soundId = SoundELFIdle;
};

RocketData IonShock5
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = ionExp_2;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $NullDamageType;

   explosionRadius  = 16;
   kickBackStrength = 4096.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 115.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 4;

   soundId = SoundELFIdle;
};

RocketData IonShock6
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = ionExp_4;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $MethaneDamageType;

   explosionRadius  = 16;
   kickBackStrength = 0.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 115.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 4;

   soundId = SoundELFIdle;
};

RocketData IonShock7
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = ionExp_5;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.01;
   damageType       = $MBHeatDamageType;

   explosionRadius  = 16;
   kickBackStrength = 32.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 115.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 4;

   soundId = SoundELFIdle;
};

BulletData MiniMissile
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = Exp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.255;
   damageType         = $MissileDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 50.0;

   aimDeflection      = 0.005;
   muzzleVelocity     = 255.0;
   totalTime          = 17.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData EcstacyShot
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = Exp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.255;
   damageType         = $MissileDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 50.0;

   aimDeflection      = 0.025;
   muzzleVelocity     = 255.0;
   totalTime          = 17.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

RocketData flierLaser
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = shockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.85;
   damageType       = $FusionDamageType;

   explosionRadius  = 12.5;
   kickBackStrength = 150.0;
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
   trailString = "hflame.dts";
   smokeDist   = 3.141592654;

   soundId = SoundJetHeavy;
};

LaserData GatlingLaserBeam
{
   laserBitmapName   = "paintpulse.bmp";
   hitName           = "paint.dts";

   damageConversion  = 0.128;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

function SuperRBolt::onAcquire(%this, %player, %target)
{
        %client = Player::getClient(%player);


if (%target == %player) {
           %player.repairTarget = -1;
                if (GameBase::getDamageLevel(%player) != 0) {
                        %player.repairRate = 0.8;
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
                %player.repairRate   = 0.6;
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
                        Client::sendMessage(%client,0,%name @ " isn't damaged");
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

function SuperRBolt::onRelease(%this, %player)
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

function SuperRBolt::checkDone(%this, %player)
{
        if (Player::isTriggered(%player,$WeaponSlot) &&
       Player::getMountedItem(%player,$WeaponSlot) == AODSuperRGun &&
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

//====================================================================Gunboy

GrenadeData Deploybox
{
   bulletShapeName    = "smoke.dts";
   explosionTag       = BExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $NullDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 1.0;
   maxLevelFlightDist = 128;
   totalTime          = 4.2;    // special meaning for grenades...
   liveTime           = 4.19;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

        smokeName              = "smoke.dts";
};

function Deploybox::onAdd(%this)
{
        schedule("DeployMines(" @ %this @ ");",4.0,%this);
}

function DeployMines(%this, %player, %item, %team)
{
                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "5 5 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "5 -5 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "-5 5 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "-5 -5 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "0 5 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "0 0 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "5 0 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "-5 0 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "0 -5 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

}

GrenadeData ClusterBomb
{
   bulletShapeName    = "Shockwave_Large.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 500;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.4;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $FlierBombDamageType;

   explosionRadius    = 50.0;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 350;
   totalTime          = 50.0;
   liveTime           = 6.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "shield.dts";
};

function ClusterBomb::onAdd(%this)
{
        schedule("BombSpread(" @ %this @ ");",5.9,%this);
}

function bombspread(%this)
{
                %obj = newObject("","Mine","bomba");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombb");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombc");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "10.0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "-10.0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 10. 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 -10.0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 35";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombf");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

}

//----------------------------------------------------------

GrenadeData AtomicBomb
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 5000;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 10;
   damageType         = $FlierBombDamageType;

   explosionRadius    = 40.0;
   kickBackStrength   = 1000.0;
   maxLevelFlightDist = 350;
   totalTime          = 50.0;
   liveTime           = 8.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
//   smokeName              = "rsmoke.dts";
};

function AtomicBomb::onAdd(%this)
{
        schedule("NuclearExplosion(" @ %this @ ");",4.9,%this);
}

function NuclearExplosion(%this)
{
                %obj = newObject("","Mine","NBase");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing1");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing2");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 10.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing4");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 20.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing5");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud1");
                addToSet("MissionCleanup", %obj);
                %padd = "15.0 0 40.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud2");
                addToSet("MissionCleanup", %obj);
                %padd = "-15.0 0 40.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 15.0 40.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud4");
                addToSet("MissionCleanup", %obj);
                %padd = "0 -15.0 40.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud5");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
}

//----------------------------------------------------------

GrenadeData SpiritBomb
{
   bulletShapeName    = "shockwave_large.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 5000;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 10;
   damageType         = $FlierBombDamageType;

   explosionRadius    = 100.0;
   kickBackStrength   = 1000.0;
   maxLevelFlightDist = 350;
   totalTime          = 50.0;
   liveTime           = 6.5;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "shockwave_large.dts";
};

function AtomicBomb::onAdd(%this)
{
        schedule("NuclearExplosion(" @ %this @ ");",4.9,%this);
}

function NuclearExplosion(%this)
{
                %obj = newObject("","Mine","NBase");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing1");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing2");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 10.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing4");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 20.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing5");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud1");
                addToSet("MissionCleanup", %obj);
                %padd = "15.0 0 40.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud2");
                addToSet("MissionCleanup", %obj);
                %padd = "-15.0 0 40.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 15.0 40.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud4");
                addToSet("MissionCleanup", %obj);
                %padd = "0 -15.0 40.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud1");
                addToSet("MissionCleanup", %obj);
                %padd = "15.0 0 55.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud2");
                addToSet("MissionCleanup", %obj);
                %padd = "-15.0 0 55.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 15.0 55.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud4");
                addToSet("MissionCleanup", %obj);
                %padd = "0 -15.0 55.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud5");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 70.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud6");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 75.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

}

//--------------------------------------
BulletData SwarmerRocket
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = flashExpLarge;

   damageClass        = 1;
   damageValue        = 0.25;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 6.0;
   aimDeflection      = 0.015;

   muzzleVelocity     = 155.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

RocketData TurretDiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.75;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 75.0;
   terminalVelocity = 100.0;
   acceleration     = 15.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 100;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

//--------------------------------------
SeekingMissileData SwarmRocketSeeking
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.33;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 25.0;

   muzzleVelocity    = 85.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

BulletData SwarmRocketMiss
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 15.0;

   aimDeflection    = 0.006;
   muzzleVelocity   = 65.0;
   totalTime        = 6.0;
   liveTime         = 6.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

RocketData ChargedFusionBolt
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.85;
   damageType       = $FusionDamageType;

   explosionRadius  = 12.5;
   kickBackStrength = 150.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "hflame.dts";
   smokeDist   = 3.141592654;

   soundId = SoundJetHeavy;
};

BulletData sniperXBullet
{        bulletShapeName = "smoke.dts";
        explosionTag        = SniperXExp;
        mass                        = 2.0;
        collisionRadius = 0.0;
        ExplosionRadius = 7.5;
        damageClass                = 1;
        damageValue                = 1.32;
        damageType                = $SniperXDamageType;
        muzzleVelocity        = 999.9;
        totalTime                = 9;
        liveTime                = 9;
        inheritedVelocityScale = 0.5;
        isVisible                = true;
        soundId                        = soundjetHeavy;
        rotationPeriod        = 0;
        lightRange                = 1.0;
        lightColor                = {1.0, 0.25,0.25};
};

GrenadeData ImplosionShell
{
   bulletShapeName    = "armorkit.dts";

  explosionTag       = mineExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 0.1;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.6;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 450;
   totalTime          = 37.0;    // special meaning for grenades...
   liveTime           = 5.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};

function ImplosionShell::onAdd(%this)
{
        schedule("DeployISHandgrenadeses(" @ %this @ " , 5);",1.0,%this);
}

function DeployISHandgrenadeses(%this, %count)
{
                %obj = newObject("","Mine","MDHandgrenade1");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-5,true);
                %obj = newObject("","Mine","MDHandgrenade2");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-7.5,false);
                %obj = newObject("","Mine","MDHandgrenade3");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,5,false);
                %obj = newObject("","Mine","MDHandgrenade4");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,7.5,true);
                %obj = newObject("","Mine","MEHandgrenade5");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-1,false);
                %obj = newObject("","Mine","MEHandgrenade1");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-5,true);
                %obj = newObject("","Mine","MEHandgrenade2");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-7.5,false);
                %obj = newObject("","Mine","MEHandgrenade3");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,5,false);
                %obj = newObject("","Mine","MEHandgrenade4");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,7.5,true);
                %obj = newObject("","Mine","MEHandgrenade5");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-1,false);
                %obj = newObject("","Mine","MHandgrenade1");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-5,true);
                %obj = newObject("","Mine","MHandgrenade2");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-7.5,false);
                %obj = newObject("","Mine","MHandgrenade3");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,5,false);
                %obj = newObject("","Mine","MHandgrenade4");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,7.5,true);
                %obj = newObject("","Mine","MHandgrenade5");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-1,false);
}

//----------------------------------------------------------------------------

MineData MDHandgrenade1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.45;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MDHandgrenade1::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//----------------------------------------------------------------------------

MineData MDHandgrenade2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.45;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MDHandgrenade2::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.4,%this);
}
//----------------------------------------------------------------------------

MineData MDHandgrenade3
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.45;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MDHandgrenade3::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.7,%this);
}
//----------------------------------------------------------------------------

MineData MDHandgrenade4
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.45;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MDHandgrenade4::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.1,%this);
}
//----------------------------------------------------------------------------

MineData MDHandgrenade5
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.45;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MDHandgrenade5::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.5,%this);
}
//----------------------------------------------------------------------------

MineData MHandgrenade1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Mortar";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MHandgrenade1::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//----------------------------------------------------------------------------

MineData MHandgrenade2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Mortar";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MHandgrenade2::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.4,%this);
}
//----------------------------------------------------------------------------

MineData MHandgrenade3
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Mortar";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MHandgrenade3::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.7,%this);
}
//----------------------------------------------------------------------------

MineData MHandgrenade4
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Mortar";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MHandgrenade4::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.1,%this);
}
//----------------------------------------------------------------------------

MineData MHandgrenade5
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Mortar";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MHandgrenade5::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.5,%this);
}


MineData MEHandgrenade1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Explosion";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = impExp;
        explosionRadius = 7.5;
        damageValue = 1;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1;
};

function MHandgrenade1::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//----------------------------------------------------------------------------

MineData MEHandgrenade2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Explosion";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = impExp;
        explosionRadius = 7.5;
        damageValue = 1;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1;
};

function MHandgrenade2::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.4,%this);
}
//----------------------------------------------------------------------------

MineData MEHandgrenade3
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Explosion";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = impExp;
        explosionRadius = 7.5;
        damageValue = 1;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1;
};

function MHandgrenade3::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.7,%this);
}
//----------------------------------------------------------------------------

MineData MEHandgrenade4
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Explosion";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = impExp;
        explosionRadius = 7.5;
        damageValue = 1;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1;
};

function MHandgrenade4::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.1,%this);
}
//----------------------------------------------------------------------------

MineData MEHandgrenade5
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Explosion";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = impExp;
        explosionRadius = 7.5;
        damageValue = 1;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1;
};

function MHandgrenade5::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.5,%this);
}


RepairEffectData reassemblerBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 50.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function reassemblerBolt::onAcquire(%this, %player, %target)
{
        %client = Player::getClient(%player);

        if (%target == %player) {
           %player.repairTarget = -1;
                if (GameBase::getDamageLevel(%player) != 0) {
                        %player.repairRate = 0.2;
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
                %player.repairRate   = 0.15;
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
                        Client::sendMessage(%client,0,%name @ " isn't damaged");
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

function reassemblerBolt::onRelease(%this, %player)
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

function reassemblerBolt::checkDone(%this, %player)
{
        if (Player::isTriggered(%player,$WeaponSlot) &&
       Player::getMountedItem(%player,$WeaponSlot) == reassembler &&
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

function SuperRBolt::onAcquire(%this, %player, %target)
{
        %client = Player::getClient(%player);

        if (%target == %player) {
           %player.repairTarget = -1;
                if (GameBase::getDamageLevel(%player) != 0) {
                        %player.repairRate = 0.6;
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
                %player.repairRate   = 0.4;
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
                        Client::sendMessage(%client,0,%name @ " isn't damaged");
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

function SuperRBolt::onRelease(%this, %player)
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

function SuperRBolt::checkDone(%this, %player)
{
        if (Player::isTriggered(%player,$WeaponSlot) &&
       Player::getMountedItem(%player,$WeaponSlot) == AODSuperRGun &&
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

GrenadeData TeleportShock
{
        bulletShapeName = "breath.dts";
         explosionTag = TeleportExp;
         collideWithOwner = false;
         ownerGraceMS = 500;
         collisionRadius = 0.0;
         mass = 0.0;
         elasticity = 0.1;
         damageClass = 0;
         damageValue = 0.01;
         damageType = $NullDamageType;
         explosionRadius = 10;
         kickBackStrength = 0.0;
         maxLevelFlightDist = 1;
         totalTime = 0.05;
         liveTime = 0.05;
         projSpecialTime = 0.05;
         inheritedVelocityScale = 1.0;
         smokeName = "breath.dts";
 };

BulletData PlasmaBolt2
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.45;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 255.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

RocketData AntiMatter
{
   bulletShapeName  = "shockwave.dts";
   explosionTag     = MortarExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4096;
   damageType       = $SniperXDamageType;

   explosionRadius  = 25;
   kickBackStrength = 0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 20.0;
   liveTime         = 20.0;
   lightRange       = 5.0;
   lightColor       = { 0.0, 0.7, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shockwave.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

GrenadeData Electricity
{
        bulletShapeName = "breath.dts";
        explosionTag = TurretExp2;
        collideWithOwner = false;
        ownerGraceMS = 500;
        collisionRadius = 0.0;
        mass = 0.0;
        elasticity = 0.1;
        damageClass = 0;
        damageValue = 0;
        damageType = $ElectricityDamageType;
        explosionRadius = 1;
        kickBackStrength = 0.0;
        maxLevelFlightDist = 1;
        totalTime = 0.05;
        liveTime = 0.05;
        projSpecialTime = 0.05;
        inheritedVelocityScale = 1.0;
        smokeName = "breath.dts";
};


RepairEffectData PowerCharge
{
        bitmapName = "lightningNew.bmp";
        boltLength = 20.0;
        segmentDivisions = 2;
        beamWidth = 0.27;
        updateTime = 100;
        skipPercent = 0.5;
        displaceBias = 0.03;
        lightRange = 6.0;
        lightColor = { 0.25, 0.25, 1.0 };
};

function PowerCharge::onAcquire(%this, %player, %target) {
        %client = Player::getClient(%player);
        %player.powerTarget = "";
        %objType = getObjectType(%target);
        if(%objType == "Player") {
                if(%target == %player) {
                        Client::sendMessage(%client,0,"Nothing to power in range");
                        Player::trigger(%player, $WeaponSlot, false);
                        return;
                }
                %tc = Player::getClient(%target);
                if(%tc.isPowered) {
                        Player::trigger(%player, $WeaponSlot, false);
                        return;
                }
                Client::sendMessage(%client,0, "Enhancing energy systems of " @ Client::getName(%tc));
                Client::sendMessage(%tc,0, "Energy systems being enhanced by " @ Client::getName(%client));
                %tc.isPowered = true;
                %player.powerTarget = %target;
                GameBase::setRechargeRate(%target, 24);
                return;
        } 
        %obj = GameBase::getDataName(%target);
        if (GameBase::getDamageState(%target) != "Enabled") {
                Client::sendMessage(%client,0, %obj.description @ " is damaged");
                Player::trigger(%player, $WeaponSlot, false);
                return;
        }
        if(GameBase::isPowered(%target)) {
                Client::sendMessage(%client,0, %obj.description @ " is already powered");
                Player::trigger(%player, $WeaponSlot, false);
                return;
        }
        if(%obj == "InventoryStation" || %obj == "AmmoStation" || %obj == "CommandStation" || %obj == "MobileInvent" || %obj == "PortaC" || %obj == "ArtilleryTurret" || %obj == "VehicleStation" || %obj == "VehiclePad" || %obj == "Teleporter" || %obj == "Shieldgen") {
                %player.powerTarget = %target;
                Client::sendMessage(%client,0, "Powering " @ %obj.description);
                GameBase::playSequence(%target,0,"power");
                GameBase::playSequence(%target,1);
                GameBase::setActive(%target, true);
                %target.freeP = true;
        } else if(%obj == "PlasmaTurret" || %obj == "ELFTurret" || %obj == "RocketTurret" || %obj == "IndoorTurret" || %obj == "PulseSensor" || %obj == "MediumPulseSensor") {
                %player.powerTarget = %target;
                Client::sendMessage(%client,0, "Powering " @ %obj.description);
                %target.shieldStrength = 0.1;
                GameBase::setRechargeRate(%target,10);
                GameBase::setActive(%target, true);
                GameBase::playSequence(%target,0,"power");
        } else {


               Client::sendMessage(%client,0,"Nothing to power in range");
                Player::trigger(%player, $WeaponSlot, false);
        }
}

function PowerCharge::onRelease(%this, %player) {
        if (%player.powerTarget != "") {
                %objType = getObjectType(%player.powerTarget);
		    if(%objType == "Player") {
                        Player::getClient(%player.powerTarget).isPowered = false;
                        GameBase::setRechargeRate(%player.powerTarget, 8);
                        %player.powerTarget = "";
                        return;
                }
                if(!GameBase::isPowered(%player.powerTarget)) {
                        %obj = GameBase::getDataName(%player.powerTarget);
                        if(%obj == "InventoryStation" || %obj == "AmmoStation" || %obj == "CommandStation" || %obj == "MobileInvent" || %obj == "PortaC" || %obj == "ArtilleryTurret" || %obj == "VehicleStation" || %obj == "VehiclePad" || %obj == "Teleporter" || %obj == "Shieldgen") {
                                (%player.powerTarget).freeP = false;
                                Station::weaponCheck(%player.powerTarget);
                                GameBase::stopSequence(%player.powerTarget,0);
                                GameBase::setSequenceDirection(%player.powerTarget,1,0);
                                GameBase::pauseSequence(%player.powerTarget,1);
                                GameBase::stopSequence(%player.powerTarget,2);
                                Station::checkTarget(%player.powerTarget);
                                %obj = (%player.powerTarget).lastPlayer;
                                GameBase::setActive(%player.powerTarget, false);
                                if(%player.powerTarget == %obj.inStation) %obj.inStation = false;
                        } else if(%obj == "PlasmaTurret" || %obj == "ELFTurret" || %obj == "RocketTurret" || %obj == "IndoorTurret" || %obj == "PulseSensor" || %obj == "MediumPulseSensor") {
                                GameBase::setActive(%player.powerTarget, false);
                                (%player.powerTarget).shieldStrength = 0;
                                GameBase::setRechargeRate(%player.powerTarget,0);
                                GameBase::pauseSequence(%player.powerTarget,0);
                                Turret::checkOperator(%player.powerTarget);
                        }
                }
                %player.powerTarget = "";
        }
}

SoundData SoundWindDgust
{
   wavFileName = "wind1.wav";
   profile = Profile3dNearLoop;
};

ExplosionData SockExp
{
   shapeName = "tumult_large.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 23.0;

   timeScale = 5.0;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.3, 0.3, 1.0 };
   colors[1]  = { 0.5, 0.5,  1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.5, 1.0, 0.8 };
};

RocketData F1aker { bulletShapeName = "breath.dts"; explosionTag = fakeExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0; damageType = $ExplosionDamageType; explosionRadius = 0; kickBackStrength = 0.0; muzzleVelocity = 65.0; terminalVelocity = 80.0; acceleration = 5.0; totalTime = 0.1; liveTime = 0.1; lightRange = 0.0; lightColor = { 0.4, 0.4, 1.0 }; inheritedVelocityScale = 0.5; };

$DamageScale[ShortCoolProj, $ImpactDamageType] = 1.0;
$DamageScale[ShortCoolProj, $MissileDamageType] = 1.0;

function F1aker::onAdd(%this) {
        %t = $F1aky;
        %markerPos = $F1aky2;
        $F1aky = "";
        $F1aky2 = "";
        %trans = GameBase::getTransform(%this);
        %rot = getWord(%trans, 3) @ " 0 " @ getWord(%trans, 5);
        %f = Vector::getFromRot(%rot, 3.5, 2);
        %vehicle = newObject("",flier,ShortCoolProj,true);
        Gamebase::setMapName(%vehicle,"Missile");
        addToSet("MissionCleanup", %vehicle);
        %client = GameBase::getControlClient(%t);
        GameBase::setTeam(%vehicle,Client::getTeam(%client));
        GameBase::startFadeIn(%vehicle);
        %vehicle.clLastMount = %client;
        GameBase::setPosition(%vehicle,Vector::add(%markerPos, %f));
        GameBase::setRotation(%vehicle,%rot);
        %client.safet = true;
        GameBase::playSound(%vehicle,bigExplosion1,0);
        doneposs(%client);
        remoteEval(%client, SetControls, true);
        Client::setControlObject(%client, %vehicle);
}

FlierData ShortCoolProj {
        description = "Phoenix Missile";
        explosionId = SockExp;
        className = "Vehicle";
        shapeFile = "rocket";
        shieldShapeName = "shield_medium";
        mass = 9.0; drag = 1.5;
        density = 1.2;
        maxBank = 10;
        maxPitch = 5000;
        maxSpeed = 52;
        minSpeed = 30;
        lift = 0;
        maxAlt = 10000;
        maxVertical = 10;
        destroyDamage = 0.1;
        maxDamage = 0.1;
        damageLevel = {0.1, 0.1};
        maxEnergy = 10;
        accel = 10.0;
        groundDamageScale = 1000.0;
        repairRate = 0;
        damageSound = SoundFlierCrash;
        ramDamage = 0.2;
        ramDamageType = $MissileDamageType;
        visibleToSensor = true;
        shadowDetailMask = 2;
        idleSound = SoundWindDgust;
        moveSound = SoundWindDgust;
        visibleDriver = true;
        driverPose = 22;
};

RocketData Jugga1oMissile
{
        bulletShapeName = "breath.dts";
        explosionTag = fakeExp;
        collisionRadius = 0.0;
        mass = 2.0;
        damageClass = 1;
        damageValue = 0;
        damageType = $ExplosionDamageType;
        explosionRadius = 0;
        kickBackStrength = 0.0;
        muzzleVelocity = 65.0;
        terminalVelocity = 80.0;
        acceleration = 5.0;
        totalTime = 0.1;
        liveTime = 0.1;
        lightRange = 0.0;
        lightColor = { 0.4, 0.4, 1.0 };
        inheritedVelocityScale = 0.5;
};

function Jugga1oMissile::onAdd(%this) {
        %t = $F1aky;
        %markerPos = $F1aky2;
        $F1aky = "";
        $F1aky2 = "";
        %trans = GameBase::getTransform(%this);
        %rot = getWord(%trans, 3) @ " 0 " @ getWord(%trans, 5);
        %f = Vector::getFromRot(%rot, 3.5, 2);
        %vehicle = newObject("",flier,EOMissile,true);
        Gamebase::setMapName(%vehicle,"Missile");
        addToSet("MissionCleanup", %vehicle);
        %client = GameBase::getControlClient(%t);
        GameBase::setTeam(%vehicle,Client::getTeam(%client));
        GameBase::startFadeIn(%vehicle);
        %vehicle.clLastMount = %client;
        GameBase::setPosition(%vehicle,Vector::add(%markerPos, %f));
        GameBase::setRotation(%vehicle,%rot);
        %client.safet = true;
        GameBase::playSound(%vehicle,SoundFireMortar,0);
        doneposs(%client);
        remoteEval(%client, SetControls, true);
        Client::setControlObject(%client, %vehicle);
}

RocketData ScouterMissi1e
{
        bulletShapeName = "breath.dts";
        explosionTag = fakeExp;
        collisionRadius = 0.0;
        mass = 2.0;
        damageClass = 1;
        damageValue = 0;
        damageType = $ExplosionDamageType;
        explosionRadius = 0;
        kickBackStrength = 0.0;
        muzzleVelocity = 65.0;
        terminalVelocity = 80.0;
        acceleration = 5.0;
        totalTime = 0.1;
        liveTime = 0.1;
        lightRange = 0.0;
        lightColor = { 0.4, 0.4, 1.0 };
        inheritedVelocityScale = 0.5;
};

function ScouterMissi1e::onAdd(%this) {
        %t = $F1aky;
        %markerPos = $F1aky2;
        $F1aky = "";
        $F1aky2 = "";
        %trans = GameBase::getTransform(%this);
        %rot = getWord(%trans, 3) @ " 0 " @ getWord(%trans, 5);
        %f = Vector::getFromRot(%rot, 3.5, 2);
        %vehicle = newObject("",flier,ScouterMissile,true);
        Gamebase::setMapName(%vehicle,"Missile");
        addToSet("MissionCleanup", %vehicle);
        %client = GameBase::getControlClient(%t);
        GameBase::setTeam(%vehicle,Client::getTeam(%client));
        GameBase::startFadeIn(%vehicle);
        %vehicle.clLastMount = %client;
        GameBase::setPosition(%vehicle,Vector::add(%markerPos, %f));
        GameBase::setRotation(%vehicle,%rot);
        %client.safet = true;
        GameBase::playSound(%vehicle,SoundMissileTurretFire,0);
        doneposs(%client);
        remoteEval(%client, SetControls, true);
        Client::setControlObject(%client, %vehicle);
}

RocketData PimpinMissile { bulletShapeName = "rocket.dts"; explosionTag = nappyExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.4; damageType = $ExplosionDamageType; explosionRadius = 20; kickBackStrength = 200.0; muzzleVelocity = 60.0; terminalVelocity = 85.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 1.0, 0.0, 0.0 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "plasmatrail.dts"; smokeDist = 1.8; soundId = SoundJetHeavy; };

LightningData tractorCharge
{
   bitmapName = "lightningNewSub.bmp";

   boltLength = 200.0;
   coneAngle = 15.0;
   damagePerSec = 0;
   energyDrainPerSec = 0;
   segmentDivisions = 0;
   numSegments = 5;
   beamWidth = 0.25;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 2.0;
   lightColor = { 1.00, 0.25, 0.25 };
};

function tractorCharge::pull(%client, %target)
{ 
	%myPos = GameBase::getPosition(%client);
	%yourPos = GameBase::getPosition(%target);
	%myRot = GameBase::getRotation(%client); 

	%dir = getWord(%myRot, 0) @ " " @ getWord(%myRot, 1) @ " " @ 3.14 + getWord(%myRot, 2);
	//make dir face opposite direction, thus pulls toward 

	%myFlatPos = getWord(%myPos, 0) @ " " @ getWord(%myPos, 1) @ " 0";
	%yourFlatPos = getWord(%yourPos, 0) @ " " @ getWord(%yourPos, 1) @ " 0"; 
	%dist = Vector::getDistance(%myFlatPos, %yourFlatPos);
	//so Z isn't in distance & doesn't make you go FLYING if you have a huge height difference

	%force = 20; //not too hard and fast

	%height = 10 * (getWord(%myPos, 2) - getWord(%yourPos, 2)); //diff in z-values 

	%diffVector = Vector::getFromRot(%dir, -%force, (-%height / %force)); 

	if(%client.tractorMode == 1)
		%diffVector = Item::getVelocity(%target);

	Item::setVelocity(%client, %diffVector); //the actual movement function
} 

function tractorCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	if(%target.shieldStrength > 0 || GameBase::getDataName(%target).className == "HandAmmo") {
		return;
	} 
	else {
		tractorCharge::pull(%shooterID,%target);
	}
} 


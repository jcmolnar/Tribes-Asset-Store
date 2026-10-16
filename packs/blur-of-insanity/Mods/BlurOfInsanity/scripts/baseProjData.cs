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
   tracerLength       = 30;
};

BulletData ChaseBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = blasterExp;
   expRandCycle       = 3;
   mass               = 0.15;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.003;
   muzzleVelocity     = 425.0;
   totalTime          = 3.7;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData ChairBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.05;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData sectorBullet
{	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0;  // 0 impact, 1, radius
	damageValue = 0.075;
	damageType = $BulletDamageType;
	muzzleVelocity = 768.0;
	totalTime = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible = False;
	tracerPercentage = 1.0;
	tracerLength = 30;
};



BulletData bioBullet1
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
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "paint.dts";
   smokeDist          = 0.01;
};

BulletData bioBullet2
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
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "paint.dts";
   smokeDist          = 0.01;
};


BulletData bioBullet3
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
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "paint.dts";
   smokeDist          = 0.01;
};

BulletData bioBullet4
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
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "paint.dts";
   smokeDist          = 0.01;
};

BulletData bioBullet5
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
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "paint.dts";
   smokeDist          = 0.01;
};

BulletData bioBullet6
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
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "paint.dts";
   smokeDist          = 0.01;
};

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
   damageType         = $BioDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
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
   damageType         = $BioDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
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
   damageType         = $BioDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 150;
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
   damageType         = $BioDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
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
   damageType         = $BioDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
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
   damageType         = $BioDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "paint.dts";
   smokeDist          = 0.01;
};

GrenadeData napBullet1
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
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plastrail.dts";
   smokeDist          = 0.01;
};

GrenadeData napBullet2
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
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 100;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plastrail.dts";
   smokeDist          = 0.01;
};

GrenadeData napBullet3
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
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 150;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plastrail.dts";
   smokeDist          = 0.01;
};

GrenadeData napBullet4
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
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 200;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plastrail.dts";
   smokeDist          = 0.01;
};

GrenadeData napBullet5
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
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 250;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plastrail.dts";
   smokeDist          = 0.01;
};

GrenadeData napBullet6
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
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plastrail.dts";
   smokeDist          = 0.01;
};

GrenadeData throwingBullet
{
   bulletShapeName    = "magcargo.dts";
   explosionTag       = largeshockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 2.0;
   mass               = 5.0;
   elasticity         = 0.20;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.0;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 500.0;
   maxLevelFlightDist = 5;
   totalTime          = 50.0;
   liveTime           = 10.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "laserhit.dts";
};

GrenadeData repBullet
{
   bulletShapeName    = "discb.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 0.2;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = -100;
   damageType         = $RepDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 50;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 3.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "laserhit.dts";
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

BulletData ShotgunBullet { bulletShapeName = "tracer.dts"; explosionTag = ShotExp; mass = 0.05; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.7; damageType = $ShotgunDamageType; aimDeflection = 0.025; muzzleVelocity = 400.0; totalTime = 0.6; inheritedVelocityScale = 1.0; isVisible = true; tracerPercentage = 1.0; tracerLength = 40; }; 

BulletData TranqDart { bulletShapeName = "paint.dts"; explosionTag = sniperbulletExp; expRandCycle = 3; mass = 0.05; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.57; damageType = $LaserDamageType; muzzleVelocity = 875.0; totalTime = 3.5; inheritedVelocityScale = 0.5; isVisible = True; tracerPercentage = 1.0; tracerLength = 130; }; 

BulletData P1asmaBolt { bulletShapeName = "plasmabolt.dts"; explosionTag = plasmaExp; damageClass = 1; damageValue = 0.4; damageType = $BurnEDamageType; explosionRadius = 4.0; muzzleVelocity = 55.0; totalTime = 3.0; liveTime = 2.0; lightRange = 3.0; lightColor = { 1, 1, 0 }; inheritedVelocityScale = 0.3; isVisible = True; soundId = SoundJetLight; }; 

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

RocketData enrockenShell
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 90.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shield_large.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};

RocketData canerShell
{
   bulletShapeName = "shield_large.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 120.0;
   terminalVelocity = 135.0;
   acceleration     = 5.0;

   totalTime        = 2.5;
   liveTime         = 4.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shield_large.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};
LightningData GrabelBeam
{
   bitmapName       = "zap01.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 35.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 1000.0;
   segmentDivisions = 1;
   numSegments      = 5;
   beamWidth        = 0.5;//0.125//075;

   updateTime   = 120;
   skipPercent  = 0.25;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.85, 0.15 };

   soundId = 0;
};


RocketData FlamShell { bulletShapeName = "fiery.dts"; explosionTag = grenadeExp; collisionRadius = 0.0; mass = 2.4; damageClass = 1; damageValue = 0.2; damageType = $BurnDamageType; explosionRadius = 5.7; kickBackStrength = 3.0; muzzleVelocity = 65.0; terminalVelocity = 80.0; acceleration = 5.0; totalTime = 0.5; liveTime = 0.7; lightRange = 6.0; lightColor = { 0.1, 0.1, 1.0 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "fiery.dts"; trailLength = 30; trailWidth = 3.3; soundId = SoundElfIdle; };

RocketData lavanShell { bulletShapeName = "laserhit.dts"; explosionTag = bulletExp0; collisionRadius = 0.0; mass = 2.4; damageClass = 1; damageValue = 0.2; damageType = $tranqDamageType; explosionRadius = 5.7; kickBackStrength = 4.0; muzzleVelocity = 75.0; terminalVelocity = 90.0; acceleration = 5.0; totalTime = 0.3; liveTime = 0.5; lightRange = 6.0; lightColor = { 0.1, 0.1, 1.0 }; inheritedVelocityScale = 0.5;  smokename = "laserhit.dts"; soundId = SoundElfIdle; };

RocketData ediscShell { bulletShapeName = "discb.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.4; damageClass = 1; damageValue = 0.4; damageType = $ElectricityDamageType; explosionRadius = 7.2; kickBackStrength = 34.0; muzzleVelocity = 70.0; terminalVelocity = 85.0; acceleration = 5.0; totalTime = 2.5; liveTime = 1.9; lightRange = 6.0; lightColor = { 0.1, 0.1, 1.0 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "lightningnew.bmp"; trailLength = 42; trailWidth = 3.3; soundId = SoundElfIdle; };

GrenadeData rlaiBolt { bulletShapeName = "mortartrail.dts"; explosionTag = ShotExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 1.0; mass = 1.0; elasticity = 0.01; damageClass = 1; damageValue = 0.25; damageType = $BioDamageType; explosionRadius = 13; kickBackStrength = 25.0; maxLevelFlightDist = 60; totalTime = 23; liveTime = 0.1; projSpecialTime = 0.08; inheritedVelocityScale = 0.75; smokeName = "mortartrail.dts"; soundId = SoundJetLight; };

RocketData rockShell { bulletShapeName = "mortar.dts"; explosionTag = LargeShockwave; collisionRadius = 0.0; mass = 2.4; damageClass = 1; damageValue = 0.7; damageType = $ExplosionDamageType; explosionRadius = 7.2; kickBackStrength = 34.0; muzzleVelocity = 67.0; terminalVelocity = 82.0; acceleration = 5.0; totalTime = 2.7; liveTime = 1.9; lightRange = 6.0; lightColor = { 0.1, 0.1, 1.0 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "smoke.dts"; trailLength = 42; trailWidth = 3.3; soundId = SoundTurretWhir; };

RocketData eplgShell { bulletShapeName = "mortar.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.4; damageClass = 1; damageValue = 0.4; damageType = $EnergyDamageType; explosionRadius = 3.5; kickBackStrength = 49.0; muzzleVelocity = 75.0; terminalVelocity = 90.0; acceleration = 5.0; totalTime = 2.5; liveTime = 1.9; lightRange = 6.0; lightColor = { 0.1, 0.1, 1.0 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "mortartrail.dts"; trailLength = 42; trailWidth = 3.3; soundId = SoundElfIdle; };

RocketData Shock { bulletShapeName = "fusionbolt.dts"; explosionTag = LargeShockwave; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.5; damageType = $ExplosionDamageType; explosionRadius = 30.0; kickBackStrength = 520.0; muzzleVelocity = 50.0; terminalVelocity = 80.0; acceleration = 4.5; totalTime = 6.0; liveTime = 4.0; lightRange = 10.0; lightColor = { 0.0, 0.0, 1.0 }; inheritedVelocityScale = 0.5; soundId = SoundJetHeavy; }; 

RocketData dustShell
{
   bulletShapeName = "rocket.dts";
   explosionTag    = largeShockwave;

   collisionRadius = 0.0;
   mass            = 3.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.7;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;

   muzzleVelocity   = 75.0;
   terminalVelocity = 95.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plastrail.dts";
   smokeDist   = 1.8;

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

BulletData planBullet
{
   bulletShapeName    = "paint.dts";
   explosionTag       = planreExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $signalDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "paint.dts";
   smokeDist          = 0.01;
};


GrenadeData FlamerBolt { bulletShapeName = "plasmatrail.dts"; explosionTag = plasmafExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 1.0; mass = 1.0; elasticity = 0.01; damageClass = 1; damageValue = 0.075; damageType = $PlasmaDamageType; explosionRadius = 13; kickBackStrength = 25.0; maxLevelFlightDist = 60; totalTime = 23; liveTime = 0.1; projSpecialTime = 0.08; inheritedVelocityScale = 0.75; smokeName = "plastrail.dts"; soundId = SoundJetLight; }; 

GrenadeData FlaimBolt { bulletShapeName = "rocket.dts"; explosionTag = plasmafExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 2.0; mass = 2.0; elasticity = 0.01; damageClass = 1; damageValue = 0.75; damageType = $PlasmaDamageType; explosionRadius = 13; kickBackStrength = 5.0; maxLevelFlightDist = 20; totalTime = 23; liveTime = 0.1; projSpecialTime = 0.08; inheritedVelocityScale = 0.75; smokeName = "plastrail.dts"; soundId = SoundJetLight; }; 

GrenadeData tbombBolt { bulletShapeName = "mine.dts"; explosionTag = LargeShockwave; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 2.0; mass = 2.0; elasticity = 0.01; damageClass = 1; damageValue = 02.5; damageType = $ExplosionDamageType; explosionRadius = 30; kickBackStrength = 2.0; maxLevelFlightDist = 10.0; totalTime = 50; liveTime = 5.0; projSpecialTime = 0.08; inheritedVelocityScale = 0.75; smokeName = "plastrail.dts"; soundId = SoundJetLight; }; 

GrenadeData ShockShell { bulletShapeName = "mortar.dts"; explosionTag = Shockwave; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.3; mass = 995.0; elasticity = 0.01; damageClass = 1; damageValue = 0.10; damageType = $FlashDamageType; explosionRadius = 30.0; kickBackStrength = 0.0; maxLevelFlightDist = 1; totalTime = 30.0; liveTime = 0.01; projSpecialTime = 0.01; inheritedVelocityScale = 0.01; smokeName = "fusionbolt.dts"; }; 

//--------------------------------------
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

RocketData beamcanerRocket
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 100.0;
   muzzleVelocity   = 80.0;
   terminalVelocity = 95.0;
   acceleration     = 5.0;
   totalTime        = 7.0;
   liveTime         = 9.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shield_large.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

RocketData energyRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

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
   trailString = "shield_large.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};


RocketData stingeraRocket
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
   muzzleVelocity   = 70.0;
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
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

RocketData SpazRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 5.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 10.7;
   kickBackStrength = 125.0;
   muzzleVelocity   = 157.0;
   terminalVelocity = 197.0;
   acceleration     = 9.0;
   totalTime        = 17.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "mortartrail.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
RocketData RailRound { bulletShapeName = "bullet.dts"; explosionTag = RailExp; collisionRadius = 0.0; mass = 2.0; damageClass = 0; damageValue = 0.4; damageType = $RailDamageType; explosionRadius = 0.1; kickBackStrength = 900.0; muzzleVelocity = 1000.0; terminalVelocity = 2000.0; acceleration = 3.0; totalTime = 10.0; liveTime = 11.0; lightRange = 10.0; lightColor = { 0.25, 0.25, 1 }; inheritedVelocityScale = 1.0; trailType = 2; trailString = "mortartrail.dts"; trailLength = 1000; trailWidth = 1; soundId = SoundJetHeavy; }; 

RocketData IonBolt { bulletShapeName = "enbolt.dts"; explosionTag = l1ll1Exp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.2; damageType = $ElectricityDamageType; explosionRadius = 2; kickBackStrength = 95.0; muzzleVelocity = 170.0; terminalVelocity = 170.0; acceleration = 2.5; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 0.0, 0.0, 1.0 }; inheritedVelocityScale = 0.5; trailType = 1; trailLength = 5; trailWidth = 0.5; soundId = SoundJetHeavy; }; 

RocketData IonEBolt { bulletShapeName = "enbolt.dts"; explosionTag = turretExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.15; damageType = $ElectricityEDamageType; explosionRadius = 4; kickBackStrength = 20.0; muzzleVelocity = 200.0; terminalVelocity = 200.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.5; trailType = 1; trailLength = 130; trailWidth = 0.3; soundId = SoundJetHeavy; }; 

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

   damageConversion  = 0.007;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
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

LightningData turretECharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityTEDamageType; boltLength = 40.0; coneAngle = 35.0; damagePerSec = 0.12; energyDrainPerSec = 65.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; 

LightningData boltCharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 60.0; coneAngle = 35.0; damagePerSec = 0.06; energyDrainPerSec = 80.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125; updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 5.0; lightColor = { 0.25, 0.25, 1 }; soundId = SoundELFFire; }; 

LightningData blotCharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 20.0; coneAngle = 35.0; damagePerSec = 0.03; energyDrainPerSec = 125.0; segmentDivisions = 1; numSegments = 1; beamWidth = 0.125; updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 5.0; lightColor = { 0.35, 0.15, 1 }; soundId = SoundELFFire; }; 

LightningData botlCharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 90.0; coneAngle = 35.0; damagePerSec = 0.3; energyDrainPerSec = 70.0; segmentDivisions = 5; numSegments = 7; beamWidth = 0.175; updateTime = 120; skipPercent = 0.5; displaceBias = 0.25; lightRange = 5.0; lightColor = { 0.15, 0.95, 0.35 }; soundId = SoundELFFire; }; 

LightningData lbotCharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 40.0; coneAngle = 35.0; damagePerSec = 0.76; energyDrainPerSec = 40.0; segmentDivisions = 3; numSegments = 5; beamWidth = 0.125; updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 5.0; lightColor = { 0.25, 0.25, 1 }; soundId = SoundELFFire; }; 

LightningData repaBeam { bitmapName = "lightningNew.bmp"; damageType = $RepDamageType; boltLength = 20.0; coneAngle = 35.0; damagePerSec = 0.03; energyDrainPerSec = 125.0; segmentDivisions = 1; numSegments = 1; beamWidth = 0.125; updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 5.0; lightColor = { 0.35, 0.15, 1 }; soundId = SoundELFFire; }; 

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
			Client::sendMessage(%client, 0, "SelfRepair On");
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
			Client::sendMessage(%client,0,"SelfRepair Off");
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Repair Complete");
			}
			else {
				Client::sendMessage(%client,0,"Repair Canceled");
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

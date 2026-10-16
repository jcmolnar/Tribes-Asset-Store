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
BulletData PFlameRapid
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmafExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius = 2;
   damageValue        = 0.15;
   damageType         = $PlasmaDamageType;

	aimDeflection      = 0.013;
   muzzleVelocity     = 60.0;
   totalTime          = 1.0;
   liveTime           = 0.5;
   isVisible          = True;

   rotationPeriod = 0.5;
};

//--------------------------------------
BulletData PRapidFlame
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius = 2;
   damageValue        = 0.12;
   damageType         = $PlasmaDamageType;

	aimDeflection      = 0.013;
   muzzleVelocity     = 70.0;
   totalTime          = 1.0;
   liveTime           = 0.75;
   isVisible          = True;

   rotationPeriod = 0.5;
};

//--------------------------------------
BulletData PRapid
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius = 2;
   damageValue        = 0.072;
   damageType         = $EnergyDamageType;

	aimDeflection      = 0.011;
   muzzleVelocity     = 65.0;
   totalTime          = 5.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 0.5;
};

//--------------------------------------
BulletData PRapidRapid1
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius = 2;
   damageValue        = 0.065;
   damageType         = $EnergyDamageType;

   aimDeflection      = 0.006;
   muzzleVelocity     = 75.0;
   totalTime          = 5.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 0.5;
};

//--------------------------------------
BulletData PRapidRapid2
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius = 2;
   damageValue        = 0.065;
   damageType         = $EnergyDamageType;

   aimDeflection      = 0.07;
   muzzleVelocity     = 80.0;
   totalTime          = 5.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 0.5;
};

//--------------------------------------
BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius = 2;
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


GrenadeData PFlame { 
	bulletShapeName = "plasmatrail.dts"; 
	explosionTag = plasmafExp; 
	collideWithOwner = True; 
	ownerGraceMS = 250; 
	collisionRadius = 1.0;
	mass = 1.0; 
	elasticity = 0.01; 
	damageClass = 1;
	damageValue = 0.14; 
	damageType = $PlasmaDamageType; 
	explosionRadius = 3.2;
	kickBackStrength = 25.0; 
	maxLevelFlightDist = 35; 
	totalTime = 23; 
	liveTime = 0.1;
	projSpecialTime = 0.01; 
	inheritedVelocityScale = 0.75; 
	smokeName = "plastrail.dts"; 
	soundId = SoundJetLight; 
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
RocketData PRapidLaser
{
   bulletShapeName = "enbolt.dts";
   explosionTag    = turretExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.33;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 1.5;
   kickBackStrength = 90.0;

   muzzleVelocity   = 300.0;
   terminalVelocity = 300.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.1, 0.1 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 1000;
   trailWidth  = 1.0;

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

RocketData PFlameFlame
{
   bulletShapeName  = "fiery.dts";
   explosionTag     = grenadeExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;
   damageValue      = 0.75;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 14.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 5.0;
   liveTime         = 6.0;
   lightRange       = 15.0;
   lightColor       = { 1.0, 0.1, 0.1 };
   inheritedVelocityScale = 0.5;

   trailType   = 2;                
   trailString = "fiery.dts";
   smokeDist   = 6.0;

   soundId = SoundJetHeavy;
};

RocketData PFlameLaser
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = plasmafExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;
   damageValue      = 0.52;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 6.0;
   kickBackStrength = 50.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 70.0;
   acceleration     = 5.0;
   totalTime        = 2.0;
   liveTime         = 1.0;
   lightRange       = 10.0;
   lightColor       = { 1.0, 0.1, 0.1 };
   inheritedVelocityScale = 0.3;

   trailType   = 2;                
   trailString = "plasmabolt.dts";
   smokeDist   = 1.2;

   soundId = SoundJetHeavy;
};

RocketData PFlameHoming
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = plasmaExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;
   damageValue      = 0.3;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 5;
   kickBackStrength = 20.0;
   muzzleVelocity   = 80.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 7.0;
   liveTime         = 8.0;
   lightRange       = 2.0;
   lightColor       = { 1, 0, 0 };
   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData PFlameHomingLock
{
   bulletShapeName = "plasmabolt.dts";
   explosionTag    = plasmaExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.36;
   damageType       = $PlasmaDamageType;
   explosionRadius  = 6.0;
   kickBackStrength = 50.0;

   muzzleVelocity    = 80.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.0;
   smokeDist         = 0.1;

   lightRange       = 8.0;
   lightColor       = { 1, 0, 0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

RocketData PHoming
{
   bulletShapeName  = "mortartrail.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;
   damageValue      = 0.27;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 100.0;
   muzzleVelocity   = 80.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 7.0;
   liveTime         = 8.0;
   lightRange       = 7.0;
   lightColor       = { 0.1, 0.1, 1.0 };
   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData PHomingLock
{
   bulletShapeName = "mortartrail.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.33;
   damageType       = $ExplosionDamageType;
   explosionRadius  = 7.0;
   kickBackStrength = 150.0;

   muzzleVelocity    = 80.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.0;
   smokeDist         = 0.1;

   lightRange       = 8.0;
   lightColor       = { 0.1, 0.1, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

RocketData PHomingHoming
{
   bulletShapeName  = "mortartrail.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;
   damageValue      = 0.45;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 125.0;
   muzzleVelocity   = 90.0;
   terminalVelocity = 90.0;
   acceleration     = 5.0;
   totalTime        = 7.0;
   liveTime         = 8.0;
   lightRange       = 7.0;
   lightColor       = { 0.1, 0.1, 1.0 };
   inheritedVelocityScale = 0.65;

   soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData PHomingHomingLock
{
   bulletShapeName = "mortartrail.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.48;
   damageType       = $ExplosionDamageType;
   explosionRadius  = 8.0;
   kickBackStrength = 150.0;

   muzzleVelocity    = 90.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.0;
   smokeDist         = 0.1;

   lightRange       = 8.0;
   lightColor       = { 0, 1, 0 };

   inheritedVelocityScale = 0.7;

   soundId = SoundJetHeavy;
};

RocketData PRapidHoming
{
   bulletShapeName  = "enbolt.dts";
   explosionTag     = energyExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;
   damageValue      = 0.15;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 3.0;
   kickBackStrength = 50.0;
   muzzleVelocity   = 75.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 5.0;
   liveTime         = 6.0;
   lightRange       = 3.0;
   lightColor       = { 0.1, 0.1, 1.0 };
   inheritedVelocityScale = 0.65;

   soundId = SoundJetHeavy;

   trailType   = 1;
   trailLength = 1000;
   trailWidth  = 1.0;

};

//--------------------------------------
SeekingMissileData PRapidHomingLock
{
   bulletShapeName = "enbolt.dts";
   explosionTag    = turretExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.21;
   damageType       = $ExplosionDamageType;
   explosionRadius  = 6.0;
   kickBackStrength = 80.0;

   muzzleVelocity    = 90.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.0;
   smokeDist         = 0.1;

   lightRange       = 5.0;
   lightColor       = { 0.1, 0.1, 1.0 };

   inheritedVelocityScale = 0.7;

   soundId = SoundJetHeavy;

   trailType   = 1;
   trailLength = 1000;
   trailWidth  = 1.0;

};

RocketData PHomingLaser
{
   bulletShapeName  = "mortartrail.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;
   damageValue      = 0.38;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.0;
   kickBackStrength = 50.0;
   muzzleVelocity   = 82.0;
   terminalVelocity = 85.0;
   acceleration     = 5.0;
   totalTime        = 5.0;
   liveTime         = 6.0;
   lightRange       = 3.0;
   lightColor       = { 0.1, 0.1, 1.0 };
   inheritedVelocityScale = 0.65;

   soundId = SoundJetHeavy;

};

//--------------------------------------
SeekingMissileData PHomingLaserLock
{
   bulletShapeName = "mortartrail.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.43;
   damageType       = $ExplosionDamageType;
   explosionRadius  = 6.0;
   kickBackStrength = 90.0;

   muzzleVelocity    = 110.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.0;
   smokeDist         = 0.1;

   lightRange       = 5.0;
   lightColor       = { 0.1, 0.1, 1.0 };

   inheritedVelocityScale = 0.7;

   soundId = SoundJetHeavy;

};

RocketData PHomingRapid
{
   bulletShapeName  = "mortartrail.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;
   damageValue      = 0.12;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.0;
   kickBackStrength = 50.0;
   muzzleVelocity   = 75.0;
   terminalVelocity = 75.0;
   acceleration     = 5.0;
   totalTime        = 5.0;
   liveTime         = 6.0;
   lightRange       = 3.0;
   lightColor       = { 0.1, 0.1, 1.0 };
   inheritedVelocityScale = 0.65;

   soundId = SoundJetHeavy;

};

//--------------------------------------
SeekingMissileData PHomingRapidLock
{
   bulletShapeName = "mortartrail.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $ExplosionDamageType;
   explosionRadius  = 6.0;
   kickBackStrength = 90.0;

   muzzleVelocity    = 75.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.0;
   smokeDist         = 0.1;

   lightRange       = 5.0;
   lightColor       = { 0.1, 0.1, 1.0 };

   inheritedVelocityScale = 0.7;

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

LaserData PLaser
{
   laserBitmapName   = "lightningNew.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.007;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.65;

   lightRange        = 10.0;
   lightColor        = { 0.0, 0.1, 1 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData PLaserLaser
{
   laserBitmapName   = "lightningNew.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.014;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.75;

   lightRange        = 15.0;
   lightColor        = { 0, 0.1, 1 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData PLaserRapid
{
   laserBitmapName   = "lightningNew.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.01;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.35;

   lightRange        = 5.0;
   lightColor        = { 0.0, 0.1, 1 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData PLaserFlame
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.0065;
   baseDamageType    = 0;

   beamTime          = 0.35;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0, 0 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LightningData PLaserHoming
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 200.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.62;
   energyDrainPerSec = 0.0;
   segmentDivisions = 1;
   numSegments      = 1;
   beamWidth        = 0.165;

   updateTime   = 70;
   skipPercent  = 0.5;
   displaceBias = 0.002;

   lightRange = 10.0;
   lightColor = { 1.0, 0.1, 0.1 };

   soundId = SoundLaserHit;
};

LightningData PHomingFlame
{
   bitmapName       = "repairadd.bmp";

   damageType       = $PlasmaDamageType;
   boltLength       = 44.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.1;
   energyDrainPerSec = 0.0;
   segmentDivisions = 4;
   numSegments      = 8;
   beamWidth        = 0.075;

   updateTime   = 80;
   skipPercent  = 0.5;
   displaceBias = 0.11;

   lightRange = 3.0;
   lightColor = { 1, 0, 0 };

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

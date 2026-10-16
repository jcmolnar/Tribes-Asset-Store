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
$SporeDamageType       = 14;

//-------


BulletData SporePod
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = ImmolExp;
//   collideWithOwner   = True;
//   ownerGraceMS       = 500;
//   collisionRadius    = 6;
   mass               = 1.0;
//   elasticity         = 0.9;
   muzzleVelocity     = 25.0;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.08;
   damageType         = $SporeDamageType;
isvisible = true;
   explosionRadius    = 25;
//   kickBackStrength   = 2.0;
//   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
//   liveTime           = 29.0;
//   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

// smokeName              = "smoke.dts";
};


//-------
BulletData PlasmaStream
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.1;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 175.0;
   totalTime          = 0.1;
   liveTime           = 0.05;
  // lightRange         = 3.0;
  // lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//-------
BulletData FlechetteShot
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
expRandCycle       = 2;
   collideWithOwner   = True;
   ownerGraceMS       = 10;
//ownerGraceMS = 50;
   collisionRadius    = 0.1;
   mass               = 10.0;
   elasticity         = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.010;
   damageType         = $PlasmaDamageType;
tracerPercentage   = 0.25;
   tracerLength       = 5;
//   explosionRadius    = 2;
//   kickBackStrength   = 1.0;
   maxLevelFlightDist = 300;
   totalTime          = 3.0;    // special meaning for grenades...
   liveTime           = 3.0;
  projSpecialTime    = 0.5;
muzzleVelocity     = 200.0;
// lightRange         = 1;
//   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = False;
   inheritedVelocityScale = 0.5;
soundId = SoundJetLight;
};


//-----
RocketData ImmolMissile
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
 muzzleVelocity   = 72.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;
   soundId = SoundJetHeavy;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
isvisible = true;
   inheritedVelocityScale = 0.5;
collideWithOwner   = False;
   ownerGraceMS       = 500;

   soundId = SoundJetHeavy;
};

function ImmolMissile::onAcquire(%this, %player, %target)
{   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

function ImmolMissile::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}

 

BulletData SporeMinePod
{

   bulletShapeName    = "mortar.dts";
   explosionTag       = ImmolExp;
//   collideWithOwner   = True;
//   ownerGraceMS       = 200;
//   collisionRadius    = 6;
//   bulletHoleIndex    = 0;
// aimDeflection      = 0.000;
   mass               = 1.0;
//   muzzleVelocity     = 25.0;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.25;
   damageType         = $SporeDamageType;
   explosionRadius    = 25;
   kickBackStrength   = 2.0;
//   maxLevelFlightDist = 150;
   totalTime          = 300.0;    // special meaning for grenades...
//   liveTime           = 290.0;
//   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.0;
isvisible = true;
// smokeName              = "smoke.dts";
};



LightningData chosenCharge
{
   bitmapName       = "lightningNew.bmp";
   damageType       = $ElectricityDamageType;
   boltLength       = 150.0;
   damagePerSec      = 0.4;
   energyDrainPerSec = 50.0;
   segmentDivisions = 1;
   numSegments      = 1;
   beamWidth        = 0.125;//075;
   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;
//   lightRange = 4.0;
//   lightColor = { 0.25, 0.25, 0.85 };
   soundId = SoundELFFire;
};

//-------
LightningData touchCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 2.0;
   coneAngle        = 5.0;
   damagePerSec      = 20;
   energyDrainPerSec = 100.0;
   segmentDivisions = 1;
   numSegments      = 1;
   beamWidth        = 0.125;//075;

   updateTime   = 320;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 4.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//-----


LaserData EmpireSniperLaser
{
   laserBitmapName   = "laserPulse.bmp";
//	laserBitmapName  = "";   
hitName           = "laserhit.dts";
//	damagepersec = 0.05;
   damageConversion  = 0.0065;
//	damageValue = 0.25;
   baseDamageType    = $LaserDamageType;

  beamTime          = 0.1;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//--------------------------------------
RocketData SluggardMissile

  {
   bulletShapeName  = "rocket.dts";
   explosionTag     = plasmaExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
//   damageValue      = 10;
	damageValue    = 7.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 500;
   kickBackStrength = 300.0;
   muzzleVelocity   = 1.0;
   terminalVelocity = 10.0;
   acceleration     = 1.0;
   totalTime        = 500.0;
   liveTime         = 490.0;
   lightRange       = 25.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;
	isdestroyable = true;
	maxdamage = 0.01;
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};




//--------------------------------------
BulletData HyperShot
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = hyperExp0;
//expRandCycle       = 2;
   collideWithOwner   = True;
   ownerGraceMS       = 10;
//ownerGraceMS = 50;
   collisionRadius    = 0.2;
   mass               = 10.0;
   elasticity         = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.075;
//damageValue = 0.025; 
  damageType         = $PlasmaDamageType;
tracerPercentage   = 0.05;
   tracerLength       = 30;

   explosionRadius    = 2;
   kickBackStrength   = 1.0;
   maxLevelFlightDist = 300;
   totalTime          = 3.0;    // special meaning for grenades...
   liveTime           = 3.0;
  projSpecialTime    = 0.5;
muzzleVelocity     = 200.0;
// lightRange         = 1;
//   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = False;
   inheritedVelocityScale = 0.5;
soundId = SoundJetLight;
//   smokeName              = "";


};

//--------------------------------------

BulletData DoomBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = doomExp0;
  expRandCycle       = 3;
//mass               = 100;
//   bulletHoleIndex    = 0;
//   damageClass        = 0;       // 0 impact, 1, radius
//   damageValue        = 0.11;
//   damageType         = $BulletDamageType;
   aimDeflection      = 0.010;
//   muzzleVelocity     = 425.0;
	muzzleVelocity    = 425;
//   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 0.05;
   elasticity         = 0.1;
   damageClass        = 1;       // 0 impact, 1, radius
//   damageValue        = 0.4;
     damageValue        = 0.25;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30;    // special meaning for grenades...
   liveTime           = 30.0;
   projSpecialTime    = 0.05;
};



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
//----------------
BulletData StrafeBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.09;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.14;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 450.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 20;
};
//--------------------------------------
BulletData SniperBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
//   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
 //  damageValue        = 0.57;
	damageValue      = 2.5;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.000;
   muzzleVelocity     = 425.0;
   totalTime          = 3;
   inheritedVelocityScale = 1.0;
   isVisible          = true;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};
//----------------



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

BulletData ArbiterHeavyFusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = ArbiterHeavyFusionExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 75.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};



//--------------------------------------
BulletData ArbiterFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = arbiterfusionExp;

   damageClass        = 0;
   damageValue        = 0.05;
   damageType         = $EnergyDamageType;
   aimDeflection      = 0.005;
   muzzleVelocity     = 350.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

//   lightRange         = 3.0;
//   lightColor         = { 0.25, 0.25, 1.0 };
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
   totalTime          = 3.0;
   liveTime           = 2.125;

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
//-----------------------
GrenadeData TankShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 0.5;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 250;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

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
//4, 5
   segmentDivisions = 3;
   numSegments      = 3;
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

//-----------------regulator


RepairEffectData Regulation
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



RepairEffectData Regulation1
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 5.0;
   segmentDivisions = 2;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};


function Regulation::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "Self Blessing? Sacrilege!");
			return;
		}
		else {
			Client::sendMessage(%client,0,"No one in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else {
      %player.repairTarget = %target;
		%player.repairRate   = 0.005;
		if (getObjectType(%player.repairTarget) == "Player") {
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else return; 
		if (%target.shieldstrength >= 0.03) {
			Client::sendMessage(%client,0,%name @ " is fully charged");
				%blessed = Player::getClient(%player.repairTarget);
			%oldarmor = Player::getArmor(%rclient);
			bottomprint(%rclient, "You have been granted The Chosen Armor and ChosenRifle by Grand Arbiter " @ Client::getName(%client));
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
%newarmor = $ArmorType[Client::getGender(%blessed), ChosenArmor];
	%oldarmor = Player::getArmor(%blessed);
			Player::setArmor(%blessed,%newarmor);
					checkMax(%blessed,%newarmor);
//					armorChange(%blessed);
	%blessedplayer = Client::getOwnedObject(%blessed);
 
                                Player::setItemCount(%blessedplayer, $ArmorName[%oldarmor], 0);  
                                Player::setItemCount(%blessedplayer, ChosenArmor, 1);
					  Player::setItemCount(%blessedplayer, ChosenRifle, 1);

			
return;
		}
		if (getObjectType(%player.repairTarget) == "Player") {
			Client::sendMessage(%rclient,0,"You received a blessing from Grand Arbiter " @ Client::getName(%client));
		}
		Client::sendMessage(%client,0,"You have bestowed a Blessing upon " @ %name);
	}
	%srate = %target.shieldstrength + 0.015;
	%target.shieldstrength = %srate;	
        %shape = shield_medium;        
       %target.shieldShapeName = %shape;
}


//function Regulation::onRelease(%this, %player)
//{
//	%object = %player.repairTarget;
//	if (%object != -1) 
//	{
//		%client = Player::getClient(%player);
//		if (%object == %player) 
//		{
//			Client::sendMessage(%client,0,"AutoRepair Off");
//		}
//		else {
//			if (GameBase::getshieldstrength(%object) >= 0.03) {
//				Client::sendMessage(%client,0," Object Blessing Complete");
//			}
//			else {
//				Client::sendMessage(%client,0,"Blessing Stopped");
//				}
//	}
//
//}

function Regulation::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == Regulator) 
	{				Player::trigger(%player,$WeaponSlot,false);
				return;
	}
}


//-----------------LifeDrain
RepairEffectData LifeDrainCharge
{
   bitmapName       = "repairadd.bmp";

   damageType       = $SporeDamageType;
   boltLength       = 2.0;
   coneAngle        = 5.0;
   damagePerSec      = 0.06;
//   energyDrainPerSec = 60.0;
   segmentDivisions = 3;
   numSegments      = 3;
   beamWidth        = 0.125;

   updateTime   = 360;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function LifeDrainCharge::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.drainTarget = -1;
			Client::sendMessage(%client,0,"You need a living victim to Drain Life from!");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	else {
      %player.drainTarget = %target;
		%player.drainRate   = 0.4;
		if (getObjectType(%player.drainTarget) == "Player") {
			%dclient = Player::getClient(%player.drainTarget);
			%name = Client::getName(%dclient);
		}
		else { 
		return;
			}
//		}
		if (getObjectType(%player.drainTarget) == "Player") {
			Client::sendMessage(%dclient,0,"Being drained by " @ Client::getName(%client));
		}
		Client::sendMessage(%client,0,"Draining the life out of " @ %name);
	}

//%drrate = GameBase::getAutoRepairRate(%player.drainTarget) - //%player.drainRate;
//	GameBase::setAutoRepairRate(%player.drainTarget,%drrate);
//%gnrate = GameBase::getAutoRepairRate(%player) + %player.drainRate;
//	GameBase::setAutoRepairRate(%player, %gnrate);

%drrate = GameBase::getDamageLevel(%player.draintarget) + %player.drainrate;
%hlrate = GameBase::getDamageLevel(%player) - %player.drainrate;
GameBase::setDamageLevel(%player.draintarget, %drrate);
//GameBase::applyDamage(%this,$ElectricityDamageType,0.4,GameBase::getPositi//on(%this),"0 0 0","0 0 0",%this);

GameBase::setDamageLevel(%player, %hlrate);
}

SeekingMissileData PlasmaMissile
{
   bulletShapeName = "fusionbolt.dts";
   explosionTag    = turretExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 150.0;

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


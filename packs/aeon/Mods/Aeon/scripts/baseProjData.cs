# Damage Types
#
$ImpactDamageType	= -1;
$LandingDamageType	=  0;
$BulletDamageType	=  1;
$EnergyDamageType	=  2;
$PlasmaDamageType	=  3;
$ExplosionDamageType	=  4;
$ShrapnelDamageType	=  5;
$LaserDamageType	=  6;
$MortarDamageType	=  7;
$BlasterDamageType	=  8;
$ElectricityDamageType	=  9;
$CrushDamageType	= 10;
$DebrisDamageType	= 11;
$MissileDamageType	= 12;
$MineDamageType		= 13;

//--------------------------------------
BulletData InfGunBullet
{
	bulletShapeName    = "bullet.dts";
	validateShape      = true;
	mass               = 0.05;
	//bulletHoleIndex    = 0;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.11;
	damageType         = $BulletDamageType;
	explosionTag       = blasterExp;
	//expRandCycle       = 3;
	//explosionRadius    = 4.0;

	aimDeflection      = 0.005;
	muzzleVelocity     = 50.0;
	totalTime          = 6.0;
	//liveTime           = 4.0;
	isVisible          = True;

	lightRange         = 3.0;
	lightColor         = { 0.25, 0.25, 1.0 };
	inheritedVelocityScale = 1.0;
	isVisible          = False;

	tracerPercentage   = 1.00;
	tracerLength       = 30;
	rotationPeriod = 1.5;

	soundId = SoundJetLight;
};

//--------------------------------------
BulletData Projectile
{
	bulletShapeName    = "plasmabolt.dts";
	validateShape      = true;
	mass               = 0.05;
	//bulletHoleIndex    = 0;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.1;
	damageType         = $BulletDamageType;
	explosionTag       = blasterExp;
	//expRandCycle       = 3;
	//explosionRadius    = 4.0;

	//aimDeflection      = 0.005;
	muzzleVelocity     = 80.0;
	totalTime          = 6.0;
	liveTime           = 4.0;
	isVisible          = True;

	lightRange         = 3.0;
	lightColor         = { 0.25, 0.25, 1.0 };
	inheritedVelocityScale = 1.0;
	isVisible          = False;

	tracerPercentage   = 1.00;
	tracerLength       = 5;
	rotationPeriod = 1.5;

	soundId = SoundJetLight;
};

//--------------------------------------

ExplosionData FireExp
{
	shapeName = "plasmabolt.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 4.0;
	timeScale = 0.3;
	colors[0] = { 1.0, 1.0, 1.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};
GrenadeData Fire
{
	bulletShapeName = "plasmabolt.dts";
	explosionTag = FireExp;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.0;
	mass = 0.0;
	elasticity = 0.4;
	damageClass = 0;
	damageValue = 0;
	explosionRadius = 1;
	kickBackStrength = 0.3;
	maxLevelFlightDist = 4;
	totalTime = 0.56;
	liveTime = 0.56;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 1.0;
	smokeName = "plasmabolt.dts";
};

//--------------------------------------

BulletData Temp
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = breathexp;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 7000.0;
   totalTime          = 8.0;
   liveTime           = 8.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = False;

   rotationPeriod = 1;
};

//--------------------------------------

BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyexp;

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
RocketData InfGunRocket
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.25;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 2.0;
   kickBackStrength = 100.0;

   //muzzleVelocity   = 65.0;
   muzzleVelocity   = 6.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 0;
   trailWidth  = 0;

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

LaserData SuperLaser
{
   //laserBitmapName   = "rtrail5.bmp";
   laserBitmapName   = "repairAdd.bmp";
   hitName           = "plasmaex.dts";

   damageConversion  = 0.1;
   baseDamageType    = $LaserDamageType;

   beamTime          = 5.0;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundSizzle;
};

LightningData lightningCharge
{
   bitmapName       = "en10.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 500.0;
   coneAngle        = 60.0;
   damagePerSec      = 0.01;
   energyDrainPerSec = 0.0;
   segmentDivisions = 7;
   numSegments      = 7;
   //beamWidth        = 0.125;//075;
   beamWidth        = 0.1;

   updateTime   = 50;
   skipPercent  = 1;
   displaceBias = 1;

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
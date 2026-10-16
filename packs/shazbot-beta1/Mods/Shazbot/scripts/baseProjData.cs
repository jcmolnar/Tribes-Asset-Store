# Damage Types
#
$ImpactDamageType   = -1;
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

RocketData IonEEBolt 
{	bulletShapeName = "mortartrail.dts";
	explosionTag = blasterExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.00;
	damageType = $ElectricityDamageType;
	explosionRadius = 5;
	kickBackStrength = -300.0;
	muzzleVelocity = 200.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 0.0, 1.0, 0.0 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "mortartrail.dts";
	smokeDist = 4.5;
	soundId = SoundJetHeavy;
};
//===== Titty EXP
ExplosionData titExp
{
   shapeName = "shockwave_large.dts";
   soundId = explosion4;
   faceCamera = true;
   randomSpin = true;
   hasLight = false;
   timeScale = 1.50;
   timeZero = 1.100;
   timeOne = 2.9;
   shiftPosition = true;
};
///=============tity Rocket
RocketData TittyRocket
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = titExp;
   collisionRadius  = 0.0;
   mass             = 1.5;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.0003;
   damageType       = $MortarDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 750.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 65.0;
   acceleration     = 2.0;
   totalTime        = 2.0;
   liveTime         = 1.5;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 0.3;

   soundId = SoundJetHeavy;
};
//-------------------nuke Exp-----------------------

ExplosionData tactExp
{
   shapeName = "shockwave_large.dts";
   soundId = explosion4;
   faceCamera = true;
   randomSpin = true;
   hasLight = false;
   timeScale = 1.50;
   timeZero = 1.100;
   timeOne = 2.9;
   shiftPosition = true;
};
RocketData TactRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = tactExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 8.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 500.0;
   muzzleVelocity   = 200.0;
   terminalVelocity = 230.0;
   acceleration     = 7.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shield_medium.DTS";
   smokeDist   = 4.0;

   soundId = SoundJetHeavy;
};
//--------------Blasroid
RocketData BRifleRocket
{
   bulletShapeName  = "shotgunbolt.dts";
   explosionTag     = blasterExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $EnergyDamageType;

   explosionRadius  = 0.1;
   kickBackStrength = 5.0;
   muzzleVelocity   = 300.0;
   terminalVelocity = 300.0;
   acceleration     = 7.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.DTS";
   smokeDist   = 5.0;

   soundId = SoundJetHeavy;
};
///hmmmm
BulletData Mega
{
   bulletShapeName    = "tumult_small.dts";
   validateShape      = true;
   explosionTag       = turretExp;
   mass               = 0.5;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius    = 3.0;
   damageValue        = 1.95;
   damageType         = $EnergyDamageType;
   aimDeflection      = 0.0;
   muzzleVelocity     = 350.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//need later
BulletData Mega3
{
   bulletShapeName    = "fusionex.dts";
   validateShape      = true;
   explosionTag       = turretExp;
   mass               = 0.5;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius    = 3.0;
   damageValue        = 1.95;
   damageType         = $EnergyDamageType;
   aimDeflection      = 0.0;
   muzzleVelocity     = 350.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};


//.45 APC 
BulletData PistolBullet 
{ 
	bulletShapeName = "bullet.DTS"; 
	explosionTag = bulletExp1; 
	mass = 0.5; 
	damageClass = 0; 
	damageValue = 0.75; 
	damageType = $BulletDamageType; 
 
	aimDeflection = 0.0; 
	muzzleVelocity = 750; 
	totaltime = 2.5; 
	inheritedVelocityScale = 1.0; 
	isVisible = True; 
 
	tracerPercentage = 1.0; 
	tracerLength = 50; 
}; 
////--------chain rocker-------------------
ExplosionData Rocket1Exp
{
   shapeName = "shockwave.dts";
   soundId = explosion4;
   faceCamera = true;
   randomSpin = true;
   hasLight = false;
   timeScale = 1.5;
   timeZero = 1.100;
   timeOne = 0.900;
   shiftPosition = false;
};

RocketData RocketgunRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = Rocket1Exp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 4.0;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 5.0;
   kickBackStrength = 100.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 3.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 5.0;

   soundId = SoundJetHeavy;
};


//------------------Sniper buller-------------------
BulletData RailgunBullet 
{ 
	bulletShapeName = "bullet.DTS"; 
	explosionTag = bulletExp1; 
	
	mass = 0.05; 
	damageClass = 0; 
	damageValue = 1.45; 
	damageType = $LaserDamageType; 
 
	aimDeflection = 0.0; 
	muzzleVelocity = 1000; 
	totaltime = 3.0; 
	inheritedVelocityScale = 1.0; 
	isVisible = True; 
 
	tracerPercentage = 1.5; 
	tracerLength = 30; 
}; 
//----Machinery-------------------------

BulletData Mach1Bullet 
{ 
	bulletShapeName = "plasmatrail.dts"; 
	explosionTag = bulletExp0; 
	
	mass = 0.005; 
	damageClass = 0; 
	damageValue = 0.45; 
	damageType = $BulletDamageType; 
 
	aimDeflection = 0.0; 
	muzzleVelocity = 500; 
	totaltime = 3.0; 
	inheritedVelocityScale = 1.0; 
	isVisible = True; 
 
	tracerPercentage = 1.5; 
	tracerLength = 30; 
}; 

//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.DTS";
   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.003;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

ExplosionData ShotExp
{
   shapeName = "plasmatrail.dts";
   soundId = energyExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight = false;
   timeScale = 1.5;
   timeZero = 0.100;
   timeOne = 0.900;
   shiftPosition = false;
};
//--- Shotgun Bullet------
BulletData ShotgunBullet
{
   bulletShapeName = "shotgunbolt.dts";
   explosionTag = ShotExp;
   mass = 0.05;
   damageClass = 0;
   damageValue = 0.50;
   damageType = $BulletDamageType;
   kickBackStrength = 200.0;
   aimDeflection = 0.02;
   muzzleVelocity = 700.0;
   acceleration = 5.0;
   totalTime = 0.5;
   inheritedVelocityScale = 1.0;
   isVisible = true;
   tracerPercentage = 1.0;   //1.0
   tracerLength = 30;
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

   muzzleVelocity     = 100.0;
   totalTime          = 7.0;
   liveTime           = 6.0;
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
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 1.80;	//0.75
	damageType = $ExplosionDamageType;		
	explosionRadius = 10.0;
	kickBackStrength = 600.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 100.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 1.0;
	trailType = 1;
	trailLength = 25;
	trailWidth = 0.7;
	soundId = SoundJetHeavy;
};

//--------------------------------------
GrenadeData NitroShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.10;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 5;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};
//\\

//--------------------------------------
RocketData FlamerShell
{
   bulletShapeName  = "Plasmabolt.dts";
   explosionTag     = grenade1Exp;
   collisionRadius  = 0.0;
   mass             = 1.5;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 50.0;
   muzzleVelocity   = 200.0;
   terminalVelocity = 100.0;
   acceleration     = 2.0;
   totalTime        = 2.0;
   liveTime         = 1.5;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 0.8;

   soundId = SoundJetHeavy;
};
//--------------------------------
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
   smokeName              = "shotgunex.dts";
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
   smokeName              = "shotgunex.dts";
};
//--------------------------------
//-------------------------------------------------------------

//--------------------------------------
RocketData RailXRocket
{	
	bulletShapeName = "tracer.dts";
	explosionTag = bulletExp0;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.80;	//0.75
	damageType = $LaserDamageType;		
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 2000.0;
	terminalVelocity = 2000.0;
	acceleration = 6.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 1.0;
	trailType = 1;
	trailLength = 3000;
	trailWidth = 0.2;
	soundId = SoundJetHeavy;
};
////Rocket
RocketData FlierRocket
{	
	bulletShapeName = "rocket.dts";
	explosionTag = mortarExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 2.80;	//0.75
	damageType = $MissleDamageType;		
	explosionRadius = 18.0;
	kickBackStrength = 600.0;
	muzzleVelocity = 500.0;
	terminalVelocity = 500.0;
	acceleration = 6.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 1.0;
	trailType = 1;
	trailLength = 30;
	trailWidth = 0.9;
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

//-------------------Shock DATA-------------------------------------------

LaserData ShockLaser
{
laserBitmapName   = "laserpulse.bmp";
   
   hitName           = "shotgunexp.dts"; //laserhit   paint

   damageConversion  = 1.0;
   baseDamageType    = $LaserDamageType;

   beamTime          = 2.2;

   lightRange       = 0.3;
   lightColor         = { 0, 0, 0};

   detachFromShooter = true;
   hitSoundId        = "";
};

RocketData ShockRocket
{
   bulletShapeName  = "shield.dts";
   explosionTag     = turretExp;
   collisionRadius  = 0.0;
   mass             = 1.5;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 3.0;
   damageType       = $LaserDamageType;

   explosionRadius  = 0.1;
   kickBackStrength = 50.0;
   muzzleVelocity   = 2100.0;
   terminalVelocity = 2100.0;
   acceleration     = 2.0;
   totalTime        = 2.0;
   liveTime         = 1.5;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shield.dts";
   smokeDist   = 1.0;

   soundId = SoundJetHeavy;
};
///LAter
RocketData Mega4
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $MortarDamageType;

   explosionRadius  = 25.5;
   kickBackStrength = 450.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 2.0;
   totalTime        = 3.0;
   liveTime         = 4.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;
   trailString = "Plasmaex.dts";
   smokeDist   = 0.2;
   soundId = SoundJetHeavy;
};
 
//-------------------------------------- 
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------

LaserData XtraLaser
{
laserBitmapName   = "trailAdd.bmp";
   
   hitName           = "enbolt.dts"; //laserhit   paint

   damageConversion  = 2.5;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange       = 0.3;
   lightColor         = { 0, 0, 0};

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};


LaserData SniperLaser
{

laserBitmapName   = "flare.bmp";
   
   hitName           = "breath.dts"; //laserhit   paint

   damageConversion  = 1.2;
   baseDamageType    = $LaserDamageType;

   beamTime          = 1.0;

   lightRange       = 15.0;
   lightColor         = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};


TargetLaserData targetLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";
   DamageConversion  = 3.0;
   
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
   beamWidth        = 1.0;//075;

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
   boltLength       = 100.0;
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
			%player.repairRate = 1.2;
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
		%player.repairRate   = 1.2;
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

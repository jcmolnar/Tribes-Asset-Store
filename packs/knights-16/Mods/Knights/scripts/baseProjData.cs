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

$DartDamageType        = 14;
$SniperDamageType      = 15;
$BARDamageType         = 16;    
$GasDamageType         = 17;
$SwordDamageType       = 18;
$SoulDamageType        = 19;
$AntiDamageType        = 20;
$BiteDamageType        = 21;
$ScoutDamageType       = 22;
$DarkDamageType        = 23;
$EMPDamageType         = 24;

//--------------------------------------
RocketData LinearRocket
{
   bulletShapeName  = "discb.dts";
   explosionTag     = LinearExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 15.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 85.0;
   terminalVelocity = 90.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "HFlame.dts";
   smokeDist   = 2.0;

   soundId = SoundJetHeavy;
};

//--------Dark Knight's Bullets---------

RocketData DarkRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $BlasterDamageType;

   explosionRadius  = 35.5;
   kickBackStrength = 50.0;
   muzzleVelocity   = 95.0;
   terminalVelocity = 115.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 13.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 2.8;

   soundId = SoundJetHeavy;
};

RocketData DarkRocket1
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $ScoutDamageType;

   explosionRadius  = 35.5;
   kickBackStrength = 50.0;
   muzzleVelocity   = 120.0;
   terminalVelocity = 125.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 13.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "HFlame.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

RocketData DarkRocket2
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.35;
   damageType       = $DarkDamageType;

   explosionRadius  = 15.5;
   kickBackStrength = 50.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 130.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 13.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "paint.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

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
   damageValue        = 0.1;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.008;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
BulletData ShredderBullet
{	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	expRandCycle = 0;
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

//--------------------------------------
BulletData AssaultBullet
{
   bulletShapeName    = "enex.dts";
   validateShape      = true;
   explosionTag       = plasmaExp;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.002;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
//--------------------------------------
BulletData AssaultBullet1
{
   bulletShapeName    = "enex.dts";
   validateShape      = true;
   explosionTag       = plasmaExp;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.002;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
//--------------------------------------
BulletData AssaultBullet2
{
   bulletShapeName    = "enex.dts";
   validateShape      = true;
   explosionTag       = plasmaExp;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.002;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
RocketData TankRocket
{	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.65;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 75.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 20;
	soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData TankMissile
{	bulletShapeName = "Rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 0.5;
	damageClass = 1;
	damageValue = 0.50;
	damageType = $MissileDamageType;
	explosionRadius = 8.5;
	kickBackStrength = 125.0;
	muzzleVelocity = 50.0;
	terminalVelocity = 120.0;
	acceleration = 1.0;
	totalTime = 8.0;
	liveTime = 9.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;

	// Missile specific
	trailType = 2;
	trailString = "plasmabolt";
	smokeDist = 1;
	soundId = SoundJetHeavy;
	seekingTurningRadius = 35.5;
};

function SeekingMissile::updateTargetPercentage(%target)
{
	return GameBase::virtual(%target, "getHeatFactor");
}
//--------------------------------------

RocketData RPG
{	bulletShapeName = "rocket.dts";
	explosionTag = grenadeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.3;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "plasmatrail.dts";
	smokeDist = 6;
	soundId = SoundJetHeavy;
};


//--------------------------------------
BulletData KShotgun1Bullet
{
   bulletShapeName    = "shotgunex.dts";
   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $BulletDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 0;

   aimDeflection      = 0.008;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
BulletData EShotgunBullet
{
   bulletShapeName    = "paint.dts";
   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.008;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
BulletData BiteBullet1
{
   bulletShapeName    = "zap.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.02;
   damageType         = $BiteDamageType;

   muzzleVelocity     = 300.0;
   totalTime          = 6.0;
   liveTime           = 4.0;

   lightRange         = 2.0;
   lightColor         = { 0.0, 0.5, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 0;
};

BulletData BiteBullet2
{
   bulletShapeName    = "zap.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.2;
   damageType         = $BiteDamageType;

   muzzleVelocity     = 300.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 0;
};

BulletData BiteBullet3
{
   bulletShapeName    = "zap_5.dts";
   explosionTag       = turretExp;
   mass               = 0.05;
   explosionRadius    = 4;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $BiteDamageType;

   muzzleVelocity     = 300.0;
   totalTime          = 60.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 0;
};

BulletData BiteBullet4
{
   bulletShapeName    = "zap_5.dts";
   explosionTag       = rocketExp;
   mass               = 0.05;
   explosionRadius    = 15;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.295;
   damageType         = $BiteDamageType;

   muzzleVelocity     = 300.0;
   totalTime          = 60.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 0;
};

BulletData BiteBullet5
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = LargeShockwave;
   mass               = 0.05;
   explosionRadius    = 30;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $BiteDamageType;

   muzzleVelocity     = 300.0;
   totalTime          = 60.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 0;
};

//--------------------------------------
BulletData SwordBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $SwordDamageType;

   muzzleVelocity     = 400.0;
   totalTime          = 0.0325;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = False;

   rotationPeriod = 1;
};

//--------------------------------------
BulletData DinkyBullet
{
   bulletShapeName    = "chaingun.dts";
   validateShape      = true;
   explosionTag       = Shockwave;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.006;
   muzzleVelocity     = 480.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   trailType   = 2;                // smoke trail
   trailString = "chaingun.dts";
   smokeDist   = 1.8;

};

//--------------------------------------
BulletData AntiBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;
   damageType         = $AntiDamageType;

   aimDeflection      = 0.01;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
BulletData BARBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = debrisExpSmall;
   expRandCycle       = 4;
   mass               = 0.08;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.03;
   damageType         = $BARDamageType;

   aimDeflection      = 0.002;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 38;
};

//--------------------------------------
BulletData PoisonDart
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.05;
   damageType         = $DartDamageType;

   aimDeflection      = 0.0;
   muzzleVelocity     = 725.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 100.0;
   tracerLength       = 30;
};

//--------------------------------------
RocketData SniperBullet
{
   bulletShapeName  = "bullet.dts";
   explosionTag     = bulletExp0;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.62;
   damageType       = $SniperDamageType;

   explosionRadius  = 0.1;
   kickBackStrength = 600.0;
   muzzleVelocity   = 3500.0;
   terminalVelocity = 3500.0;
   acceleration     = 500.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.8;
   soundId = SoundJetHeavy;
};

//--------------------------------------
BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.87;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 50.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//--------------------------------------
BulletData AlienBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $EnergyDamageType;

   aimDeflection      = 0.008;
   muzzleVelocity     = 70.0;
   totalTime          = 6.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

};

//--------------------------------------
BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.2;
   damageType         = $EMPDamageType;

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
   damageValue        = 0.4;
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
BulletData DefenderBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = turretExp;

   damageClass        = 1;
   damageValue        = 0.35;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 75.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//--------------------------------------
RocketData BladeShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = bulletExp0;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.75;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 4.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 4000.0;
   terminalVelocity = 4000.0;
   acceleration     = 500.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 2;
   trailWidth  = 10.0;

   soundId = SoundDiscSpin;
};

//--------------------------------------
RocketData PistolBullet
{
   bulletShapeName  = "bullet.dts";
   explosionTag     = bulletExp0;
   collisionRadius  = 0.0;
   mass             = 5.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $BulletDamageType;

   explosionRadius  = 35.5;
   kickBackStrength = 350.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 30.0;
   liveTime         = 2.0;
   lightRange       = 8.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "bullet.dts";
   smokeDist   = 0;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = blasterExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 4.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 105.0;
   terminalVelocity = 120.0;
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
RocketData SoulShell
{
   bulletShapeName = "fusionbolt.dts";
   explosionTag    = turretExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.25;
   damageType       = $SoulDamageType;

   explosionRadius  = 12.5;
   kickBackStrength = 50.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 400.0;
   acceleration     = 30.0;

   totalTime        = 7.5;
   liveTime         = 9.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 1.5;

   soundId = SoundJetLight;
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
   elasticity         = 0.08;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 30;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};
//--------------------------------------
GrenadeData Flame
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 8.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 100;
   totalTime          = 0.5;
   liveTime           = 0.001;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
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
GrenadeData Scout
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.7;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 50.0;
   liveTime           = 10.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};

//--------------------------------------
GrenadeData TimeBomb
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = TimerExp;
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
   maxLevelFlightDist = 1;
   totalTime          = 50.0;
   liveTime           = 10.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};

//--------------------------------------
GrenadeData NukeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 9.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 45.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 1150;
   totalTime          = 30.0;
   liveTime           = 0.001;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};
   
//--------------------------------------
GrenadeData DinkyShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 40.0;
   kickBackStrength   = -750.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortargun.dts";
};

//--------------------------------------
GrenadeData GasShell
{
   bulletShapeName    = "tumult_small.dts";
   explosionTag       = debrisExpLarge;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.35;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $GasDamageType;

   explosionRadius    = 25.7;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
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
   damageValue      = 0.85;
   damageType       = $MissileDamageType;

   explosionRadius  = 15.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 85.0;
   terminalVelocity = 90.0;
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
RocketData MRocket
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0.0;
   mass             = 5.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $MortarDamageType;

   explosionRadius  = 35.5;
   kickBackStrength = 350.0;
   muzzleVelocity   = 85.0;
   terminalVelocity = 90.0;
   acceleration     = 5.0;
   totalTime        = 30.0;
   liveTime         = 2.0;
   lightRange       = 8.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "mortartrail.dts";
   smokeDist   = 2.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData ConRocket
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $MissileDamageType;

   explosionRadius  = 40.5;
   kickBackStrength = 550.0;
   muzzleVelocity   = 105.0;
   terminalVelocity = 115.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "smoke.dts";
   smokeDist   = 2.8;

   soundId = SoundLaserHit;
};

//--------------------------------------
RocketData StingerRocket
{	
      bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.65;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 75.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "smoke.dts";
	smokeDist = 15;
	soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData StingerMissile
{	
      bulletShapeName = "rocket.dts";
	explosionTag = LargeShockwave;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.7;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 25.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 100.0;
	totalTime = 10;
	liveTime = 10;
	seekingTurningRadius = 25;
	nonSeekingTurningRadius = 75.0;
	proximityDist = 1.5;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;

      // rocket specific
	trailType = 2;
	trailString = "plasmatrail.dts";
	smokeDist = 15;
};

//--------------------------------------
RocketData EMPRocket
{	
      bulletShapeName = "rocket.dts";
	explosionTag = turretExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.15;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 75.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;

	// rocket specific
	trailType = 2;
	trailString = "smoke.dts";
	smokeDist = 15;
	soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData EMPMissile
{	
      bulletShapeName = "fusionbolt.dts";
	explosionTag = turretExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.25;
	damageType = $EMPDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 25.0;
	muzzleVelocity = 400.0;
	terminalVelocity = 400.0;
	totalTime = 10;
	liveTime = 10;
	seekingTurningRadius = 25;
	nonSeekingTurningRadius = 75.0;
	proximityDist = 1.5;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;

      // rocket specific
	trailType = 2;
	trailString = "plasmatrail.dts";
	smokeDist = 15;
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

LaserData KLaser
{
   laserBitmapName   = "ylite02.bmp";
   hitName           = "plasmaex.dts";

   damageConversion  = 0.21;
   baseDamageType    = $LaserDamageType;

   beamTime          = 5.0;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = SoundMortarTurretFire;
};

LaserData ALaser
{
   laserBitmapName   = "warp.bmp";
   hitName           = "Shockwave_Large.dts";

   damageConversion  = 0.015;
   baseDamageType    = $LaserDamageType;

   beamTime          = 5.0;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = SoundMortarTurretFire;
};

LaserData FlameLaser
{
   laserBitmapName   = "plasmabolt.bmp";
   hitName           = "enex.dts";

   damageConversion  = 0.15;
   baseDamageType    = $LaserDamageType;

   beamTime          = 1.0;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = SoundBeaconActivate;
};

LaserData TargetTurretLaser
{
   laserBitmapName   = "rlite02.bmp";
   hitName           = "plasmaex.dts";

   damageConversion  = 0.003;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.1;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundMortarTurretFire;
};


LaserData sniperLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.01;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};

LaserData ChronLaser
{
   laserBitmapName   = "blite02.bmp";
   hitName           = "fusionex.dts";

   damageConversion  = 0.67;
   baseDamageType    = $LaserDamageType;

   beamTime          = 7.0;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = bigExplosion3;
};

LaserData TurretLaser
{
   laserBitmapName   = "plite00.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.17;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.6;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = explosion4;
};

LaserData ScLaser
{
   laserBitmapName   = "display_blue.bmp";
   hitName           = "enex.dts";

   damageConversion  = 0.005;
   baseDamageType    = $LaserDamageType;

   beamTime          = 5.0;

   lightRange        = 15.0;
   lightColor        = { 0, 0, 15.0 };

   detachFromShooter = false;
   hitSoundId        = SoundFlierCrash;
};

TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.005;
   baseDamageType    = $LaserDamageType;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

LightningData lightningCharge
{
   bitmapName       = "plasmabolt.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 100.9;
   coneAngle        = 35.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = -750.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundElevatorBlocked;
};

LightningData turretCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 60.0;
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
   boltLength       = 30.0;
   segmentDivisions = 5;
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
			%player.repairRate = 0.1;
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
		%player.repairRate   = 0.59;
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

RepairEffectData URepairBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 40.0;
   segmentDivisions = 7;
   beamWidth        = 0.425;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function URepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 0.6;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 1, "AutoRepair On");
		}
		else {
			Client::sendMessage(%client,1,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else {
      %player.repairTarget = %target;
		%player.repairRate   = 1.0;
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
			Client::sendMessage(%client,1,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if (getObjectType(%player.repairTarget) == "Player") {
			Client::sendMessage(%rclient,1,"Being repaired by " @ Client::getName(%client));
		}
		Client::sendMessage(%client,1,"Repairing " @ %name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function URepairBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1) {
		%client = Player::getClient(%player);
		if (%object == %player) {
			Client::sendMessage(%client,1,"AutoRepair Off");
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,1,"Repair Done");
			}
			else {
				Client::sendMessage(%client,1,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function URepairBolt::checkDone(%this, %player)
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


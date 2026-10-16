# Damage Types
#
$ImpactDamageType      = -1;
$LandingDamageType	   =  0;
$BulletDamageType      =  1;
$EnergyDamageType      =  2;	//=== Poison Effect
$PlasmaDamageType      =  3;	//=== On Fire Damage
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
$SniperDamageType      = 14;	//=== Drop Weapon-Flag Damage
$FlashDamageType       = 15;	//=== EMP Damage
$GravDamageType		   = 20;
$ShellDamageType	   = 21;
$CloakDamageType	   = 22;
$NukeDamageType        = 23;
$FlameDamageType       = 24;
$LCGDamageType         = 25;
$NoDamageType	     = 26;
$SlowDamageType	     = 27;
$MarlinDamageType      = 28;
$StunDamageType        = 29;
$DecloakDamageType     = 30;
$ConcussionDamageType  = 31;
$JitterbugDamageType   = 32;
$EMPDamageType         = 33;
$ObeliskDamageType     = 34;
$SCVDamageType         = 35;

//Globals
$hacking = "false";
$Viral = "false";
$isInfected[0] = "false";
$origTeam[0] = "-1";
$minHacked = "-1";
$maxHacked = "-1";
$minInfected = "-1";
$minInfected = "-1";

$RSP::HackTime = "5";
$RSP::HackedTime = "25";

//End Globals

//======================================================================== Locking Missle 

SeekingMissileData StingerMissileTracker 
{
bulletShapeName = "rocket.dts";
explosionTag = rocketExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.6;
damageType = $MissileDamageType;
explosionRadius = 9.5;
kickBackStrength = 200.0;
muzzleVelocity = 45.0;
terminalVelocity = 60.0;
acceleration = 15.0;
totalTime = 20.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 0.0;
nonSeekingTurningRadius = 5.0;
proximityDist = 1.5;
lightRange = 5.0;
lightColor = { 0.4, 0.4, 1.0 };
trailType = 2;
trailString = "plasmatrail.dts";
smokeDist = 2.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};

//======================================================================== Mini-Locking Missle 

SeekingMissileData MiniMissileTracker 
{
bulletShapeName = "rocket.dts";
explosionTag = rocketExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.3;
damageType = $MissileDamageType;
explosionRadius = 5.5;
kickBackStrength = 200.0;
muzzleVelocity = 45.0;
terminalVelocity = 60.0;
acceleration = 15.0;
totalTime = 20.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 0.0;
nonSeekingTurningRadius = 5.0;
proximityDist = 1.5;
lightRange = 5.0;
lightColor = { 0.4, 0.4, 1.0 };
trailType = 2;
trailString = "plasmatrail.dts";
smokeDist = 2.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};

//function SeekingMissile::updateTargetPercentage(%target)
//{
//   return GameBase::virtual(%target, "getHeatFactor");
//}


//======================================================================== ChainGun
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

//======================================================================== Sniper Bullet

BulletData SniperBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	mass               = 0.05;
	collisionRadius    = 0.0;
	bulletHoleIndex    = 0;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.57;
	damageType         = $LaserDamageType;
	aimDeflection      = 0.0;
	muzzleVelocity     = 2000.0;
	totalTime          = 1;
	inheritedVelocityScale = 0.0;
	isVisible          = false;
	tracerPercentage   = 100.0;
	tracerLength       = 25;
};

//======================================================================== Silencer - Magnum

BulletData SilencerBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.26;
   damageType         = $LaserDamageType;

   
   muzzleVelocity     = 625.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 100.0;
   tracerLength       = 30;
};

//======================================================================== Tranq Dart

BulletData TranqDart
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.16;
   damageType         = $EnergyDamageType;

   
   muzzleVelocity     = 625.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 100.0;
   tracerLength       = 30;
};

//======================================================================== Vulcan Bullet

BulletData VulcanBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.02;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.002;
   muzzleVelocity     = 900.0;
   totalTime          = 2;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 2.0;
   tracerLength       = 60;
};

//======================================================================== BoomStickBlast

BulletData BoomStickBlast
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.08;
   damageType         = $ShellDamageType;

   aimDeflection      = 0.029;
   muzzleVelocity     = 200.0;
   totalTime          = 1;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 2.0;
   tracerLength       = 30;
   soundId = SoundJetLight;
   
};

//======================================================================== Jet Bullet

BulletData JetBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.10;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 100.0;
   tracerLength       = 30;
};

//======================================================================== Fusion Bolt

BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $ImpactDamageType;

   muzzleVelocity     = 50.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//======================================================================== MiniFusionBolt

BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $ImpactDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//======================================================================== Blaster Bolt

BulletData BlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.200;
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

//======================================================================== Hyper Bolt

BulletData HyperBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.03;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 1.0;
   liveTime           = 0.13;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//======================================================================== Jet Bolt

   
BulletData JetBolt
{
    bulletShapeName    = "bullet.dts";
    explosionTag       = bulletExp0;
    expRandCycle       = 3;
    mass               = 0.05;
    bulletHoleIndex    = 0;
   
    damageClass        = 0;       // 0 impact, 1, radius
    damageValue        = 0.04;
    damageType         = $BulletDamageType;
  
    aimDeflection      = 0.002;
    muzzleVelocity     = 900.0;
    totalTime          = 2;
    inheritedVelocityScale = 2.0;
    isVisible          = False;
   
    tracerPercentage   = 2.0;
    tracerLength       = 160;
};



//======================================================================== Plasma Bolt

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
BulletData PlasmaVelocityBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.45;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 440.0;
   totalTime          = 0.1875;
   liveTime           = 0.125;
   lightRange         = 0.1875;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};
BulletData PlasmaDistanceBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.45;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 27.5;
   totalTime          = 12.0;
   liveTime           = 8.0;
   lightRange         = 12.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};
//======================================================================== Plasma Bolt Multi

BulletData PlasmaBoltMulti
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.20;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 2.5;

   muzzleVelocity     = 275.0;
   totalTime          = 3.0;
   liveTime           = 1.3;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//======================================================================== Plasma Bolt Rapid

BulletData PlasmaBoltRapid
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.20;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 2.0;

   muzzleVelocity     = 180.0;
   totalTime          = 3.0;
   liveTime           = 1.3;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//======================================================================== Plasma Bolt Rapid2

BulletData PlasmaBoltRapid2
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.20;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 2.0;

   muzzleVelocity     = 110.0;
   totalTime          = 3.0;
   liveTime           = 1.3;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//======================================================================== Flamer Bolt


BulletData FlamerBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.06;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 30.0;
   totalTime          = 0.75;
   liveTime           = 0.75;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//======================================================================== Disc Shell

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

   muzzleVelocity   = 75.0;
   terminalVelocity = 100.0;
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

//======================================================================== Gimp Missle

RocketData GimpMissile
{
  bulletShapeName  = "rocket.dts";
   explosionTag     = grenadeExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.70;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 450.0;
   muzzleVelocity   = 60.0;
   terminalVelocity = 2000.0;
   acceleration     = 200.0;
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

//======================================================================== Grenade Shell

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

//======================================================================== Mortar Shell

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

//======================================================================== Mortar Turret Shell

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


//======================================================================== EMP Mortar Shell

GrenadeData EMPMortar
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = shockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 400.0;
   elasticity         = 0.01;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.30;
   damageType         = $FlashDamageType;

   explosionRadius    = 35.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";

};

//======================================================================== EMP Shell

GrenadeData EMPShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = Shockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 995.0;
   elasticity         = 0.01;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.30;
   damageType         = $FlashDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 1;
   totalTime          = 30.0;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.01;
   smokeName              = "smoke.dts";
};

//======================================================================== Satchel Shell

GrenadeData SatchelShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.6;
   damageType         = $DebrisDamageType;

   explosionRadius    = 25;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 1;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};


//======================================================================== Flier Rocket


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

//======================================================================== Turret Missile

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


//======================================================================== Stinger Missile

RocketData StingerMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

   muzzleVelocity   = 200.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};

//======================================================================== Bomber Shell

GrenadeData BomberShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 0.01;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 2;
   kickBackStrength   = 1.0;
   maxLevelFlightDist = 150;
   totalTime          = 5.0;    // special meaning for grenades...
   liveTime           = 5.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};

function BomberShell::onAdd(%this)
{
	schedule("DeployBomblets(" @ %this @ " , 5);",1.0,%this);
}

function DeployBomblets(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Bomblet1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-20,false);
		
		%obj = newObject("","Mine","Bomblet2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-10,false);
		%obj = newObject("","Mine","Bomblet3");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);
		%count -= 1;
		schedule("DeployBomblets(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}

//======================================================================== Tactical Nuke Shell

GrenadeData FgcShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.5;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 75.0;
   kickBackStrength   = 1.0;
   maxLevelFlightDist = 375;
   totalTime          = 30.0;
   liveTime           = 3.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
    smokeName              = "plasmatrail.dts";
  
};

function FgcShell::onAdd(%this)
{
	%cl = GameBase::getOwnerClient(%this);
	schedule("NuclearExplosion(" @ %this @ "," @ %cl @ ");",3.0,%this);
}


function NuclearExplosion(%this, %client)
{
      %player = Player::getClient(%this);
	echo (" Player " @ %palyer);
	echo (" Client " @ %cl);
	echo ("************************************** Nuke Fired");
                %obj = newObject("","Mine","NBase");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
				Client::setOwnedObject(%client, %obj);
				Client::setOwnedObject(%client, %player);
				GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing1");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
				Client::setOwnedObject(%client, %obj);
				Client::setOwnedObject(%client, %player);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing2");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
				Client::setOwnedObject(%client, %obj);
				Client::setOwnedObject(%client, %player);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
				Client::setOwnedObject(%client, %obj);
				Client::setOwnedObject(%client, %player);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing4");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 35.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
				Client::setOwnedObject(%client, %obj);
				Client::setOwnedObject(%client, %player);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing5");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 45.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud1");
                addToSet("MissionCleanup", %obj);
                %padd = "15.0 0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud2");
                addToSet("MissionCleanup", %obj);
                %padd = "-15.0 0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 15.0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud4");
                addToSet("MissionCleanup", %obj);
                %padd = "0 -15.0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud5");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 75.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

}

//======================================================================== Bomber Nuke

RocketData Nuke
{
  bulletShapeName  = "rocket.dts";
   explosionTag     = grenadeExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.70;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 450.0;
   muzzleVelocity   = 60.0;
   terminalVelocity = 2000.0;
   acceleration     = 200.0;
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

//======================================================================== Shock Blast

RocketData Shock
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $MissileDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 350.0;
   muzzleVelocity   = 50.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 6.0;
   liveTime         = 4.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
  // trailType   = 2;                // smoke trail
  // trailString = "rsmoke.dts";
  // smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//======================================================================== Turret Shock

RocketData TurretShock
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $MissileDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 450.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
  // trailType   = 2;                // smoke trail
  // trailString = "rsmoke.dts";
  // smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//======================================================================== Sniper Round


RocketData SniperRound
{
   bulletShapeName  = "bullet.dts";
   explosionTag     = bulletExp0;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.59;
   damageType       = $SniperDamageType;

   explosionRadius  = 0.1;
   kickBackStrength = 600.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = { 0.25, 0.25, 1 };
   inheritedVelocityScale = 1.0;
   soundId = SoundJetHeavy;

};

//======================================================================== Rail Round

RocketData RailRound
{
   bulletShapeName  = "bullet.dts";
   explosionTag     = bulletExp0;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.75;
   damageType       = $BulletDamageType;

   explosionRadius  = 0.1;
   kickBackStrength = 600.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = { 0.25, 0.25, 1 };
   inheritedVelocityScale = 1.0;

   trailType   = 1;         
   trailLength = 3000;
   trailWidth  = 0.6;
  
   soundId = SoundJetHeavy;

};

//========================================================================  Ion Bolt

RocketData IonBolt
{ 
	bulletShapeName = "enbolt.dts"; 
	explosionTag = turretExp; 
	collisionRadius = 0.0;
	 mass = 2.0; 
	damageClass = 1; // 0 impact, 1, radius 
    damageValue = 0.26; 
	damageType = $ElectricityDamageType; 
	explosionRadius = 6; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 250.0; 
	terminalVelocity = 2000.0;
	 acceleration = 500.0; 
	totalTime = 10.0; 
	liveTime = 3.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.7, 0.5 }; 
	inheritedVelocityScale = 0.5; 
	// rocket specific 
	trailType = 1;
	trailLength = 250; 
	trailWidth = 0.9; 
	soundId = SoundJetHeavy;
};

//======================================================================== Volter Burst

GrenadeData FlameBurst 
{
    explosionTag = plasmaExp;
// 	explosionTag = turretExp;
 	collideWithOwner = True;
 	ownerGraceMS = 50;
 	collisionRadius = 10.0;
 	mass = 5.0;
 	elasticity = 0.1;
 	damageClass = 1;
 	damageValue = 0.30;
 	damageType = $ElectricityDamageType;
 	explosionRadius = 5.0;
 	kickBackStrength = 0.1;
 	maxLevelFlightDist = 75;
 	totalTime = 4.0;
 	liveTime = 0.02;
 	projSpecialTime = 0.01;
 	lightRange = 10.0;
	lightColor = { 1, 1, 0 }; 
 	inheritedVelocityScale = 1.5;
 	smokeName = "plasmatrail.dts";
 	soundId = SoundJetLight;
 };
 
//======================================================================== Curse Of The Penis Pee Job

GrenadeData Pee
{
    explosionTag = plasmaExp;
// 	explosionTag = turretExp;
 	collideWithOwner = True;
 	ownerGraceMS = 50;
 	collisionRadius = 0.1;
 	mass = 5.0;
 	elasticity = 0.1;
 	damageClass = 1;
 	damageValue = 0.0;
 	damageType = $ElectricityDamageType;
 	explosionRadius = 5.0;
 	kickBackStrength = 0.1;
 	maxLevelFlightDist = 75;
 	totalTime = 4.0;
 	liveTime = 0.02;
 	projSpecialTime = 0.01;
 	lightRange = 10.0;
	lightColor = { 1, 1, 0 }; 
 	inheritedVelocityScale = 1.5;
 	smokeName = "plasmatrail.dts";
 	soundId = SoundJetLight;
};

function Pee::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	Client::sendMessage(%target,0,"You got pee'd on by " @ Client::getName(%shooterId) @ " !");
}

 
//-------------------------------------- 
//======================================
//
// Laser Items
//
//======================================
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

//======================================================================== 

LaserData LaserTag
{
   laserBitmapName   = "lightningNew.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.01;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//======================================================================== 

TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.0;
   
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

//======================================================================== Proximity Laser

LaserData proxLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   beamTime          = 0.0;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   //hitSoundId        = SoundLaserHit; Silent Attack
};

//======================================================================== 

LightningData lightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.10;
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

//======================================================================== 

LightningData lightningCharge2
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

//======================================================================== 

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

//======================================================================== 

RepairEffectData RepairBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 10.0;
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

	if (%target == %player)
	{
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0)
		{
			%player.repairRate = 0.05;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else
		{
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else
	{
        %player.repairTarget = %target;
		%player.repairRate   = 0.1;
		
		if (getObjectType(%player.repairTarget) == "Player")
		{
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else
		{ 
			%name = GameBase::getMapName(%target);
			if(%name == "") 
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) 
		{
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		
		if (getObjectType(%player.repairTarget) == "Player") 
		{
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		
		Client::sendMessage(%client,0,"Repairing " @ %name);
		
		$PlayerRepairing[%player] = "True";												//=== Player Is Repairing
		$PlayerRepairTar[%player] = (GameBase::getDamageLevel(%player.repairTarget));   //=== Amount Of Damage Starting

		echo ("***  Repair Progress Started " @ $PlayerRepairing[%player] @ " Starting Damage Level = " @ $PlayerRepairTar[%player]);
	}
	
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolt::onRelease(%this, %player)
{
	%client = Player::getClient(%player);

	$PlayerRepairing[%player] = "False";
	echo ("***  Repair Progress Stopped " @ $PlayerRepairing[%player]);
	%object = %player.repairTarget;
	if (%object != -1)
	{
		%client = Player::getClient(%player);
		if (%object == %player)
		{
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				Client::sendMessage(%client,0,"Repair Done");
			}
			else
			{
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
	%client = Player::getClient(%player);

//  echo ("*** Checking Repair Progress On Player " @ $PlayerRepairing[%player]);

	if (Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == RepairGun || Player::getMountedItem(%player,$WeaponSlot) == FixIt) && %target != -1)
	{
		%object = %player.repairTarget;
		
		if (%object == %player)
		{
			if (GameBase::getDamageLevel(%player) == 0)
			{
				echo ("Repair Stopped - Done");
				$PlayerRepairing[%player] = "False";
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				if ($PlayerRepairing[%player] = True)
				{
						%objname = (GameBase::getDataName(%object)).description;
					
					%objectTeam = GameBase::getTeam(%object);								//=== Team Object.
					%playerTeam = GameBase::getTeam(%player); 								//=== Team Player.
					%lastdamage = GameBase::getControlClient(%object.lastDamageObject);	

					if (%objname == "Remote Mortar Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Ion Turret")			%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Laser Turret")			%pntval = $Score::ObjTurretS;
					else if (%objname == "Point Defense Laser Mine")	%pntval = $Score::ObjTurretS;
					else if (%objname == "EMP Turret")					%pntval = $Score::ObjTurretS;
					else if (%objname == "Satchel Charge")				%pntval = $Score::ObjTurretS;
					else if (%objname == "ELF Turret")					%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Rocket")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Camera")						%pntval = $Score::ObjTurretS;
					else if (%objname == "Large Pulse Sensor")			%pntval = $Score::ObjSensorL;
					else if (%objname == "Medium Pulse Sensor")			%pntval = $Score::ObjSensorL;
					else if (%objname == "Motion Sensor")				%pntval = $Score::ObjSensorS;
					else if (%objname == "Remote Pulse Sensor")			%pntval = $Score::ObjSensorS;
					else if (%objname == "Remote Sensor Jammer")		%pntval = $Score::ObjSensorS;		
					else if (%objname == "Generator")					%pntval = $Score::ObjGeneratorB;
					else if (%objname == "Solar Panel")					%pntval = $Score::ObjGeneratorS;
					else if (%objname == "Portable Generator")			%pntval = $Score::ObjGeneratorS;		
					else if (%objname == "Ammo Supply Unit")	   		%pntval = $Score::ObjStationA;
					else if (%objname == "Station Supply Unit")			%pntval = $Score::ObjStationS;
					else if (%objname == "Command Station")				%pntval = $Score::ObjStationA;
					else if (%objname == "Remote Ammo Unit")			%pntval = $Score::ObjStationR;
					else if (%objname == "Remote Inv Unit")				%pntval = $Score::ObjStationR;
					else if (%objname == "Remote Command Station")		%pntval = $Score::ObjStationR;
					else if (%objname == "Station Vehicle Unit")		%pntval = $Score::ObjFlier;
					else if (%objname == "Vehicle Pad")					%pntval = $Score::ObjFlier;					

					%bonus = (floor($PlayerRepairTar[%player] * %pntval));
					%score = ($Score::RepairObject + %bonus);
					%lastdamage = $lastdamageobj[%object];
					%lastdpl = GameBase::getControlClient(%object.lastDamageObject);
					%objname = GameBase::getMapName(%object);
					if(%objname == "") 
						%objname = (GameBase::getDataName(%object)).description;					

					if (%lastdpl == %client)
					{
							if ((%objectteam == %playerteam || %objectteam == "-1") && (%object.lastDamageTeam == %playerTeam))
							{
								if ($ScoreOn) bottomprint(%client, "No points awarded, you were the last damager.");						
							}
							else if (%objectteam != %playerTeam)
							{
								%client.score = (%client.score - %score);
								if ($ScoreOn) bottomprint(%client, "You Repaired The Enemys Stuff. Score -" @ %score @ " = " @ %client.score @ " Total Score. You Dumb Ass.");
							}
							else if (%this.lastDamageTeam != %playerTeam)
							{
								%client.score = (%client.score + %score);
								if ($ScoreOn) bottomprint(%client, "Repairing Damage Score +" @ %score @ " = " @ %client.score @ " Total Score");
							}
					}
					else
					{
						if (%objectteam != %playerTeam)
						{
							%client.score = (%client.score - %score);
							if ($ScoreOn) bottomprint(%client, "You Repaired The Enemys Stuff. Score -" @ %score @ " = " @ %client.score @ " Total Score. You Dumb Ass.");
						}
						else
						{
							%client.score = (%client.score + %score);
							if ($ScoreOn) bottomprint(%client, "Repairing Damage Score +" @ %score @ " = " @ %client.score @ " Total Score");
						}
					}
						
					$PlayerRepairing[%player] = "False";
					Game::refreshClientScore(%client);

				}
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}

//------------------------------------------------------------------------------------------------
// Hack Gun Beam Used this from the RSP - Is now alternate weapon setting for EngRepairGun
//------------------------------------------------------------------------------------------------
RepairEffectData HackBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 10.0;
   segmentDivisions = 4;
   beamWidth        = 0.2;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function HackBolt::onAcquire(%this, %player, %target)
{
	$Shifter::AllowHacking = "True";
	if($Shifter::AllowHacking)
	{

		%client = Player::getClient(%player);
	
		if (%target != %player)
		{
			%player.repairTarget = %target;
			%name = GameBase::getMapName(%target);
			%team = GameBase::getTeam(%target);
			%pTeam = GameBase::getTeam(%player); //added
			%pName = Client::getName(%client); //added
			%tName = getTeamName(%team); //added
			
			if(%name == "")
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
	
			%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;
	
			if(%team == %pTeam)
			{
				Client::sendMessage(%client,0,"You can not hack your own " @ %name);	
				return;
			}
				
			if(checkHackable(%name, %shape) || getObjectType(%player.repairTarget) == "Player")
			{
				if(getObjectType(%player.repairTarget) == "Player")
				{
					Client::sendMessage(%client,0,"You can not hack another player.");
				}
				else
				{
					Client::sendMessage(%client,0,"It is not possible to hack in to a " @ %name);
					return;
				}
			}
			else
			{
				if(%name == "False" && %shape == "magcargo")
				{
					Client::sendMessage(%client,0,"Disarming the Nuke Pack. Please wait...");
				}
				else
				{
					Client::sendMessage(%client,0,"Hacking " @ %name @ ". Please wait...");
				}

				$hacking = "true";
				if(!$origTeam[%target])
				{
					$origTeam[%target] = %team;
				}
				hackingItem(%target, %pTeam, %pName, %tName, %name, %team, $RSP::HackTime, %client);
			}
		}	
	}
	else
	{
		Client::sendMessage(%client,0,"Hacking/Infecting disabled on this server");
	}
}

function HackBolt::onRelease(%this, %player)
{
	$hacking = false;
}

function checkHackable(%name, %shape)
{
	if(%shape == "generator" || %shape == "generator_p" || %shape == "solar_med" || %shape == "inventory_sta" || %shape == "elevator_4x4"	|| %shape == "elevator_6x6" || %shape == "elevator_6x6_octagon" || %shape == "elevator_8x4" || %shape == "elevator_8x6" || %shape == "elevator_9x9"	|| %shape == "elevator16x16_octo" || %shape == "elevator6X4" || %shape == "elevator_6x5" || %shape == "elevator_8x8" || %shape == "elevator6x4thin"	|| %shape == "elevator6x6thin" || %shape == "elevator_5x5" || %shape == "elevator_4x5" || %shape == "door_top" || %shape == "door_bot"	|| %shape == "newdoor1_l" || %shape == "newdoor1_r" || %shape == "newdoor2_l" || %shape == "newdoor2_r" || %shape == "newdoor3_l"
	|| %shape == "newdoor3_r" || %shape == "newdoor4_l" || %shape == "newdoor4_r" || %shape == "newdoor6_l" || %shape == "newdoor6_r"	|| %shape == "door_8x8_l" || %shape == "door_8x8_r" || %shape == "forcefield" || %shape == "forcefield_3x4" || %shape == "forcefield_4x17"	|| %shape == "newdoor3_r" || %shape == "newdoor4_l" || %shape == "newdoor4_r" || %shape == "newdoor6_l" || %shape == "newdoor6_r"	|| %shape == "forcefield_4x14" || %shape == "forcefield_4x8" || %shape == "forcefield_5x5" || %shape == "door_4x4_diagonal" || %shape == "tower" || %shape == "camera" || %shape == "hellfiregun" || %shape == "indoorgun" || %shape == "ammounit" || %shape == "sensor_pulse_med" || %shape == "station_cmdpnl" || %shape == "missileturret" || %shape == "cmdpnl" || %shape == "radar" || %shape == "anten_lava")
	{
		return 0;
	}

	return 1;
}

function hackingItem(%target, %pTeam, %pName, %tName, %name, %team, %time, %client)
{
	// PORT: the three names are looked up again here and no longer travel through the schedule() string below.
	// A ' in a player, team or object name ended the quoted argument there and the rest of the name ran as code.
	%pName = Client::getName(%client);
	%tName = getTeamName(%team);
	%name = GameBase::getMapName(%target);
	if(%name == "")
		%name = (GameBase::getDataName(%target)).description;
	%shape = (GameBase::getDataName(%target)).shapeFile;
	if(%time > 0)
	{
		if($hacking)
		{		
			schedule("hackingItem('" @ %target @ "','" @ %pTeam @ "','','','','" @ %team @ "','" @ %time - 1 @ "','" @ %client @ "');", 1);
		}
	}
	else
	{
		if($hacking)
		{
			if($isInfected[%target]) 
			{
				showDeathAnim(%client);
				Player::Kill(%client);
				messageallexcept(%client,0,%pName @ " thought it would be safe to hack the infected " @ %name @ ".");
			
				%randNum = getRandom() * 100;
			
				if(%randNum >= 50)
				{
					$isInfected[%target] = "false";
					Client::sendMessage(%client,0,"The viral infection was destroyed for the price of your life.");
				}
				else
				{
					Client::sendMessage(%client,0,"Your hacking attempt wasn't able to destroy the virus. What a pitiful waste of life.");
				}
				return 1;
			}
			//Client::sendMessage(%client,0,"Welcome " @ %pName @ " :)");
			else
			{
				if(%name == "False" && %shape == "magcargo")
				{

					%rnd = floor(getRandom() * 10);
					if(%rnd == 1)
					{	
					    Client::sendMessage(%client,1,"OOPS! You cut the wrong wire...");
						Mine::Detonate(" @ %this @ ");
						return;
					}
					else
					{	
					    Client::sendMessage(%client,1,"You disarm the DetPack.");
						%client.score = %client.score + 2;
						Game::refreshClientScore(%client);
						deleteObject(%target);
					}


				}
				else
				{
					TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
					TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");
					GameBase::setTeam(%target,%pTeam);
					if($RSP::HackedTime)
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", $RSP::HackedTime);
					}
					else
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", "120");
					}
			
					if(%target < $minHacked || $minHacked == -1)
					{
						$minHacked = %target;
					}
					if(%target > $maxHacked || $maxHacked == -1)
					{
						$maxHacked = %target;
					}
				}
			}
		}
	}
}


//------------------------------------------------------------------------------------------------------------------------
// Disasymbler - Alternate To Engineer Repair Gun.
//------------------------------------------------------------------------------------------------------------------------
RepairEffectData DisaBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 20.0;
   segmentDivisions = 4;
   beamWidth        = 0.3;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.25;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function DisaBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target != %player)
	{
		%player.repairTarget = %target;
		%name = GameBase::getMapName(%target);
		%team = GameBase::getTeam(%target);
		%pTeam = GameBase::getTeam(%player); //added
		%pName = Client::getName(%client); //added
		%tName = getTeamName(%team); //added
		
		if(%name == "")
		{
			%name = (GameBase::getDataName(%player.repairTarget)).description;
		}

		%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;

		if(%team != %pTeam)
		{
			Client::sendMessage(%client,0,"You can not disassymble another teams " @ %name);	
			return;
		}
			
		if(getObjectType(%player.repairTarget) == "Player")
		{
			Client::sendMessage(%client,0,"You can not disassymble another player.");
		}
		else
		{
			Client::sendMessage(%client,0,"Disassymbling " @ %name @ ". Please wait...");
			%disatime = 5;
			$disassymble[%player] = True;
			objectColapsable(%target, %player, %name, %shape, %disatime);
			echo ("Done.");
		}
	}	
}

function DisaBolt::onRelease(%this, %player)
{
	$disassymble[%player] = false;
}


function removeflagdefpoints(%player)
{
	%client = Player::getClient(%player);
	%client.score = %client.score - $Score::FlagDef;
	if ($ScoreOn) bottomprint(%Client, "Score - " @ $Score::FlagDef @ " = " @ %client.score @ " Total Score, for removing flag defencive." ,3);
	Game::refreshClientScore(%client);
}

function objectColapsable(%this, %player, %name, %shape, %disatime)
{	
	%client = Player::getClient(%player);
	%pos = gamebase::GetPosition (%this);
	%description = %name;
	%playerteam = Client::getTeam(%client);				//== Player Team
	%playerpos = GameBase::getPosition(%player);			//== Player Position
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%pos,%homepos);

	if (Player::getmounteditem(%player, $BackPackSlot) != "-1")
	{
		bottomprint( %client, "<jl><f1> You can not disassymble the " @ %description @ ", drop your current pack first...", 3);
		return 0;
	}

	if ($disassymble[%player])
	{
		if (%disatime > 0)
		{
			%disatime = %disatime - 1;
			schedule ("objectColapsable ( '" @ %this @ "', '" @ %player @ "', '" @ %name @ "', '" @ %shape @ "', '" @ %disatime @ "'); ",1);
			return 0;
		}
	}
	else
	{
		return 0;
	}
	//================================================================================================= Ion Turret
	if (String::findSubStr(%name, "Ion Turret") >= 0)
	{
		%item = "TurretPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;
		
			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		deleteObject(%this);
		if (%flagdist < 35) removeflagdefpoints(%player);
		return 1;
	}

	//================================================================================================= Command Station
	if (String::findSubStr(%name, "Command Station") >= 0)
	{
		%item = "DeployableComPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ "DeployableComPack"]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		deleteObject(%this);
		return 1;
	}	
	//================================================================================================= Sensor Jammer
	if (String::findSubStr(%name, "Sensor Jammer") >= 0)
	{
		%item = "DeployableSensorJammerPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Pulse Sensor
	if (String::findSubStr(%name, "Pulse Sensor") >= 0)
	{
		%item = "PulseSensorPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		$disassymble[%player] = false;
		deleteObject(%this);
		return 1;
	}
	//================================================================================================= Camera 
	if (String::findSubStr(%name, "Camera") >= 0)
	{
		%item = "CameraPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		$disassymble[%player] = false;
		deleteObject(%this);
		return 1;
	}
	//================================================================================================= Blast Wall
	if (String::findSubStr(%name, "Blast Wall") >= 0)
	{
		%item = "BlastWallPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		$disassymble[%player] = false;
		deleteObject(%this);
		return 1;
	}
	//================================================================================================= Rocket Turret
	if (String::findSubStr(%name, "RMT Rocket") >= 0)
	{
		%item = "RocketPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 100) removeflagdefpoints(%player);
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Plasma Turret
	if (String::findSubStr(%name, "RMT Plasma Turret") >= 0)
	{
		%item = "PlasmaTurretPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 35) removeflagdefpoints(%player);
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Elf Turret
	if (String::findSubStr(%name, "Deployable ELF") >= 0)
	{
		%item = "DeployableElf";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 20) removeflagdefpoints(%player);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= EMP Turret
	if (String::findSubStr(%name, "EMP Turret") >= 0)
	{
		%item = "ShockPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 10) removeflagdefpoints(%player);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Remote Mortar
	if (String::findSubStr(%name, "RMT Mortar Turret") >= 0)
	{
		%item = "TargetPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 55) removeflagdefpoints(%player);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Laser Turret
	if (String::findSubStr(%name, "Laser Turret") >= 0)
	{
		%item = "LaserPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 55) removeflagdefpoints(%player);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}


	Client::sendMessage(%client,0,"Disassymbling " @ %name @ " failed...");
	Player::trigger(%client,$WeaponSlot,false);
	$disassymble[%player] = false;
	return 0;
}

//======================================================================== Grav Charge

LightningData gravCharge
{
   bitmapName       = "repairadd.bmp";

   damageType       = $GravDamageType;
   boltLength       = 100.0;
   coneAngle        = 40.0;
   damagePerSec      = 0.01;
   energyDrainPerSec = 1.0;
   segmentDivisions = 2;
   numSegments      = 1;
   beamWidth        = 0.5;

   updateTime   = 120;
   skipPercent  = 0.1;
   displaceBias = 0.35;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };

   soundId = SoundELFFire;
};

function gravCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%playerId = %shooterId;
	if (%playerId.GravBolt == "0")
	{
			%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
			%Zvalue = %Rotation;
			%velocity = -25;
			%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
			Player::applyImpulse(%target, %shooterDir);
			
			%damVal = %timeSlice * %damPerSec;
			%enVal  = %timeSlice * %enDrainPerSec;
			GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
	}
	else
	{
			%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
			%Zvalue = %Rotation;
			%velocity = 25;
			%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
			Player::applyImpulse(%target, %shooterDir);
			
			%damVal = %timeSlice * %damPerSec;
			%enVal  = %timeSlice * %enDrainPerSec;
			GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
	}
}

//======================================================================== Cloaking Blast

RocketData cloakingBlast
{   
   bulletShapeName = "rocket.dts";
   explosionTag    = shockwave;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $CloakDamageType;

   explosionRadius  = 20.0;
   kickBackStrength = 0.01;

   muzzleVelocity   = 2.0;
   terminalVelocity = 2.0;
   acceleration     = 2.0;

   totalTime        = 0.01;
   liveTime         = 0.01;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

// rocket specific

   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;   
};

function cloakingBlast::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
        GameBase::startFadeOut(%target);
        schedule("GameBase::startFadeIn(" @ %target @ ");", 90);
}
/////////////////////
// CodeFusion 1.0a //
/////////////////////

LightningData snareCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $GravDamageType;
   boltLength       = 150.0;
   coneAngle        = 40.0; //40
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.01;
   segmentDivisions = 2;
   numSegments      = 1;
   beamWidth        = 0.05;

   updateTime   = 120;
   skipPercent  = 0.1;
   displaceBias = 0.35;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };

   soundId = SoundELFFire;
};

function snareCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
	%Zvalue = 15;
	%velocity = 0.0;
	%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
	Player::applyImpulse(%target, %shooterDir);
}

LightningData HGravCharge
{
   bitmapName       = "repairAdd.bmp";

   damageType       = $GravDamageType;
   boltLength       = 150.0;
   coneAngle        = 40.0; //40
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.01;
   segmentDivisions = 2;
   numSegments      = 1;
   beamWidth        = 0.05;

   updateTime   = 120;
   skipPercent  = 0.1;
   displaceBias = 0.35;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };

   soundId = SoundELFFire;
};

function HGravCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
	%Zvalue = -15;
	%velocity = 0.0;
	%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
	Player::applyImpulse(%target, %shooterDir);
}

GrenadeData Flare
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = FlareExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 150;
   totalTime          = 2.5;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

BulletData ChaingunTurretBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $CTurretDamageType;

   aimDeflection      = 0.006;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

RocketData FlakShell
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 8.0;
   kickBackStrength = 150.0;
   muzzleVelocity   = 200.0;
   terminalVelocity = 200.0;
   acceleration     = 1.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

RocketData Watch
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.06;
   damageType       = $MissileDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 350.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 10;//1.8

   soundId = SoundJetHeavy;
};

GrenadeData MineShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = debrisExpSmall;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $MineDamageType;

   explosionRadius    = 10;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 150;
   totalTime          = 40.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

function MineShell::onAdd(%this)
{
	schedule("DeployNukes(" @ %this @ " , 5);",1.0,%this);//5++++++
}

function DeployNukes(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Nuke1");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-10.0,false);//0++++	
//		%obj = newObject("","Mine","Nuke2");
//		addToSet("MissionCleanup", %obj);
//		GameBase::throw(%obj,%this,-15.0,false);
		%obj = newObject("","Mine","Nuke3");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-20.0,false);
		%count -= 1;
		schedule("DeployNukes(" @ %this @ " , " @ %count @ ");",1.0,%this);//0.5++++++++
	}
}

 BulletData ClusterBombShell
 {
	 bulletShapeName = "rocket.dts";
	 explosionTag = debrisExpSmall;
	 mass = 0.05;
	 bulletHoleIndex = 0;
  collisionRadius    = 15.0;//++++++
	 damageClass = 1;
   explosionRadius    = 8;//5;+++++++++++
   kickBackStrength   = 100.0;//++++++++
	 damageValue = 0.038; //0.05;+++++++++++++++++++
	 damageType = $ShrapnelDamageType;
	 aimDeflection = 0.01;//++++++++++
	 muzzleVelocity = 300.0;
	 totalTime = 1.0; //0.8;+++++++++++++++++
	 liveTime = 0.05;//++++++++++++++++++++++++++++++++++++++++++++
	 inheritedVelocityScale = 1.0;
	 isVisible = True;
	
	triggerRadius = 5;//+++++++++++
	damageLevel = {1.0, 1.0};//++++
	maxDamage = 1.0;//0++++++++++++

   tracerPercentage   = 100.0; //1.0;++++++++++++++++++++++++++++++++++++++++++++++
	 tracerLength = 30;
   smokeName              = "plasmatrail.dts";
 };
function ClusterBombShell::onAdd(%this)
{
	%this.damage = 0;
}
function ClusterBombShell::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

LaserData SeekerLaser
{
   bulletShapeName    = "mortar.dts"; 
   hitName           = "laserhit.dts";

   damageConversion  = 0.22; //0.02;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.6;//0.70;

   lightRange        = 5.0;
   lightColor        = { 0.25, 0.25, 0.85 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData WatchdogLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.001; //0.010;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.8;//0.53;

   lightRange        = 10.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

RocketData FlameLarge
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = fireExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.05;
   damageType       = $FlameDamageType;

   explosionRadius  = 3.0;
   kickBackStrength = 10.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 3.0;
   liveTime         = 4.0;
   lightRange         = 10.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 1.0;

   soundId = SoundJetHeavy;
};

RocketData NukeTurret
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 75;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 500.0;

   muzzleVelocity   = 90.0;
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

LaserData ObeliskBeam
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.0125;
   damageType    = $ObeliskDamageType;

   beamTime          = 0.5;
   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

RepairEffectData SCVProjectile
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 20.0;
   segmentDivisions = 4;
   beamWidth        = 0.25;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function SCVProjectile::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player)
	{
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0)
		{
			%player.repairRate = 0.05;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else
		{
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else
	{
      	%player.repairTarget = %target;
		%player.repairRate   = 0.05;
		if (getObjectType(%player.repairTarget) == "Player")
		{
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else
		{ 
			%name = GameBase::getMapName(%target);
			if(%name == "")
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		if(GameBase::getTeam(%player) == GameBase::getTeam(%player.repairTarget))
		{
			if (GameBase::getDamageLevel(%player.repairTarget) == 0)
			{
				Client::sendMessage(%client,0,%name @ " is not damaged");
				Player::trigger(%player,$WeaponSlot,false);
				%player.repairTarget = -1;
				return;
			}
			if (getObjectType(%player.repairTarget) == "Player")
			{
				Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
			}
			Client::sendMessage(%client,0,"Repairing " @ %name);
		}

	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function SCVProjectile::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1)
	{
		%client = Player::getClient(%player);
		if (%object == %player)
		{
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else if(GameBase::getTeam(%object) == GameBase::getTeam(%player))
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				Client::sendMessage(%client,0,"Repair Done");
			}
			else
			{
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function SCVProjectile::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == SCVGun && %player.repairTarget != -1)
	{
		%object = %player.repairTarget;
		if (%object == %player)
		{
			if (GameBase::getDamageLevel(%player) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else if(GameBase::getTeam(%object) == GameBase::getTeam(%player))
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else
		{
			if(getObjectType(%player.repairTarget) == "Player")
			{
				if(Player::isDead(%object))
				{
					Player::trigger(%player,$WeaponSlot,false);
					return;
				}
			}
			else
			{
				if(GameBase::getDamageLevel(%object) == GameBase::getDataName(%object).maxDamage)
				{
					Player::trigger(%player,$WeaponSlot,false);
					return;
				}
			}
			
			%client = Player::getClient(%player);
			GameBase::applyDamage(%object, $SCVDamageType, 0.02, GameBase::getPosition(%object), Item::getVelocity(%player), "0 0 0", Client::getControlObject(%client));

			
			
		}
	}
}


GrenadeData ECMShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.15;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.04;
   damageType         = $DecloakDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};



RocketData FlamePlasma
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = fireExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.025;
   damageType       = $FlameDamageType;

   explosionRadius  = 3.0;
   kickBackStrength = 5.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 0.2;
   liveTime         = 2.0;
   lightRange         = 10.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 25.0;

   soundId = SoundJetHeavy;
};

SeekingMissileData HomingDiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1667;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 5.0;
   kickBackStrength = 50.0;

   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 10.0;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;


   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.2;

   soundId = SoundDiscSpin;
};



BulletData SuperBlasterBolt
{
	accuFire = true;
   bulletShapeName    = "fusionex.dts";
   explosionTag       = turretExp;

   damageClass        = 0;
   damageValue        = 0.75;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData OtherBlasterBolt
{
	accuFire = true;
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.25;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};
RepairEffectData targetpull
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 50.0;
   segmentDivisions = 1;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };
};

function targetpull::pull(%client, %rclient)
{

	%myPos = GameBase::getPosition(%client);
	%yourPos = GameBase::getPosition(%rclient);
	%myRot = GameBase::getRotation(%client);

	%dir = getWord(%myRot, 0) @ " " @ getWord(%myRot, 1) @ " " @ 3.14 + getWord(%myRot, 2); //make dir face opposite direction, thus pulls toward

	%myFlatPos = getWord(%myPos, 0) @ " " @ getWord(%myPos, 1) @ " 0";
	%yourFlatPos = getWord(%yourPos, 0) @ " " @ getWord(%yourPos, 1) @ " 0";

	%dist = Vector::getDistance(%myFlatPos, %yourFlatPos); //so Z isn't in distance & doesn't make you go FLYING if you have a huge height difference
	if(%dist) //just in case, avoid divide by zero
		%force = 2000 / %dist; //gets smaller as the distance increases

	%height = 10 * (getWord(%myPos, 2) - getWord(%yourPos, 2)); //diff in z-values

echo("dir = " @ %dir @ " dist = " @ %dist @ " hi = " @ %height);

	%diffVector = Vector::getFromRot(%dir, %force, %height);

echo("%diffvector = " @ %diffVector);

	Player::applyImpulse(%rclient, %diffVector);


}

function targetpull::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	%player.tractorTarget = %target;

	if (%target == %player || getObjectType(%player.tractorTarget) != "Player")
	{
		Client::sendMessage(%client,0,"No one in range");
		Player::trigger(%player, $WeaponSlot, false);
		return;
	}

	%rclient = Player::getClient(%player.tractorTarget);

	Client::sendMessage(%rclient,0,"Being tractored in by " @ Client::getName(%client));
	Client::sendMessage(%client,0,"Pulling on " @ Client::getName(%rclient));

	targetpull::pull(%client, %rclient);
}

function targetpull::onRelease(%this, %player)
{
	%object = %player.tractorTarget;
	if (%object != -1)
	{
		%client = Player::getClient(%player);
		if (%object == %player || getObjectType(%object) != "Player")
		{
			return;
		}

		Client::sendMessage(%client,0,"Tractor Beam Stopped");
	}
}


function targetpull::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == TractorBeam && %player.tractorTarget != -1)
	{
		%object = %player.tractorTarget ;

		%myPos = GameBase::getPosition(%player);
		%yourPos = GameBase::getPosition(%object);

		%myFlatPos = getWord(%myPos, 0) @ " " @ getWord(%myPos, 1) @ " 0";
		%yourFlatPos = getWord(%yourPos, 0) @ " " @ getWord(%yourPos, 1) @ " 0";

		if(Vector::getDistance(%myFlatPos, %yourFlatPos) < 3.0)
		{
			Player::trigger(%player,$WeaponSlot,false);
			return true;
		}
		else
		{
			targetpull::pull(Player::getClient(%player), Player::getClient(%player.tractorTarget));
		}
		return false;
	}

	return true;
}






BulletData Decloak
{
   bulletShapeName    = "breath.dts";
   explosionTag       = bulletExp0;
   mass               = 0.03;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $DecloakDamageType;

   muzzleVelocity     = 2000.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;

   liveTime           = 4.0;
   isVisible          = False;

   rotationPeriod = 1.5;
};

GrenadeData EMPMortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = RandomShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $EMPDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 0.15;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "fusionbolt.dts";
};


BulletData Marlinshot
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   mass               = 0.03;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.61;
   damageType         = $MarlinDamageType;

   muzzleVelocity     = 800.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;

   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};



LaserData LaserChain
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.015;
   damageType    = $LCGDamageType;

   beamTime          = 0.5;
   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

BulletData SlowPod
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = plasmaExp;
   mass               = 6.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $SlowDamageType;
   isvisible          = true;
   muzzleVelocity     = 35.0;
   explosionRadius    = 7.5;
   kickBackStrength   = 0.25;
   maxLevelFlightDist = 300;
   totalTime          = 30.0;

   inheritedVelocityScale = 0.25;
};



RocketData concussShot
{
   bulletShapeName  = "plasmawall.dts";
   explosionTag     = RandomShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue    = 0;
   damageType       = $ConcussionDamageType;

   explosionRadius  = 125;
   kickBackStrength = 250.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 300.0;
   acceleration     = 10.0;
   totalTime        = 25.0;
   liveTime         = 26.0;
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

RocketData jitterbugShot
  {
   bulletShapeName  = "hflame.dts";
   explosionTag     = shockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $JitterbugDamageType;

   explosionRadius  = 75;
   kickBackStrength = 50.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 300.0;
   acceleration     = 10.0;
   totalTime        = 20.0;
   liveTime         = 26.0;
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


RepairEffectData CloakerBolt
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

function CloakerBolt::onAcquire(%this, %player, %target)
{
	if (%target == %player)
	{
		%player.cloakGun = 1;
		if(%player.cloakPack != 1)
			GameBase::startFadeOut(%player);
		%rate = Player::getSensorSupression(%player) + 20;
		if(%rate < 20)
			%rate = 20;
		Player::setSensorSupression(%player,%rate);
		%player.shieldStrength += 0.01;
	}
	else
	{
		GameBase::startFadeOut(%target);
		schedule("GameBase::startFadeIn(" @ %target @ ");", 15);
	}
}

function CloakerBolt::onRelease(%this, %player)
{
	if(%player.cloakGun)
	{
		%player.cloakGun = 0;
		if(%player.cloakPack != 1)
			GameBase::startFadeIn(%player);
		if(%rate < 0)
			%rate = 0;
		%rate = Player::getSensorSupression(%player) - 20;
		Player::setSensorSupression(%player,%rate);
		%player.shieldStrength -= 0.01; 
	}
}

LightningData longlightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 100.0;
   coneAngle        = 135.0;
   damagePerSec      = 0.02;
   energyDrainPerSec = 45.0;
   segmentDivisions = 4;
   numSegments      = 2;
   beamWidth        = 0.375;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

LightningData shortlightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 15.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.11;
   energyDrainPerSec = 100.0;
   segmentDivisions = 4;
   numSegments      = 8;
   beamWidth        = 0.075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};


BulletData JetfireBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = debrisExpSmall;

   damageClass        = 1; //radius
   damageValue        = 0.30;
   damageType         = $BulletDamageType;
   explosionRadius    = 2.0;

   muzzleVelocity     = 555.0;
   totalTime          = 1.5;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 100;
};


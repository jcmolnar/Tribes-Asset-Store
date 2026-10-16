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
$J22RocketDamageType   = 14;
$EMPDamageType         = 15;
$J22POOmkiiDamageType  = 16;
$SmokeDamageType       = 17;
$MiniELFDamageType     = 18;
$GreenLaserDamageType     = 19;



//--------------------------------------
BulletData BogeyT
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = BogeyTExp;

   damageClass        = 1;
   damageValue        = 0.25;
   damageType         = $ShrapnelDamageType;
   explosionRadius    = 15;

   muzzleVelocity     = 800;
   totalTime          = 1;
   liveTime           = 2.5;
   //lightRange         = 1;
   //lightColor         = { 0, 0, 0 };
   inheritedVelocityScale = 15;
   isVisible          = True;

   //soundId = SoundJetLight;
};

//--------------------------------------
BulletData LightningG
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = LightningGExp;
   mass               = 0.075;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 2.5;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 750;
   totalTime          = 2;
   liveTime           = 1;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//--------------------------------------
GrenadeData ElectrodeF
{ 
        bulletShapeName = "fusionex.dts";
        explosionTag = ElectrodeFExp;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0;
        mass = 9;
        elasticity = 0.01;
        damageClass = 1;
        damageValue = 280;
        damageType = $ShrapnelDamageType;
        explosionRadius = 5;
        kickBackStrength = 0;
        maxLevelFlightDist = 475;
        totalTime = 4;
        liveTime = 2;
        projSpecialTime = 0.01;
        inheritedVelocityScale = 0.5;
        smokeName = "plasmatrail.dts";
        soundId = SoundELFFire;
};


//--------------------------------------
RocketData SizzleM
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = SizzleMExp;
   collisionRadius  = 0;
   mass             = 2;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.75;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 20;
   kickBackStrength = 15;
   muzzleVelocity   = 800;
   terminalVelocity = 950;
   acceleration     = 10;
   totalTime        = 1;
   liveTime         = 3;
   //lightRange       = 5;
   //lightColor       = { 1, 1, 1 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 1;

   soundId = SoundJetHeavy;
};

//--------------------------------------
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
   damageValue        = 1;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 4000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = false;

   tracerPercentage   = 100;
   tracerLength       = 30;
};

//--------------------------------------
BulletData ZRifleBullet
{
   bulletShapeName    = "smoke.dts";
   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 2;
   damageType         = $BulletDamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 9000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 0;
   //tracerLength       = 0;
};

//--------------------------------------
BulletData ZRifleIIBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 2;
   damageType         = $J22POOmkiiDamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 20000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 0;
   //tracerLength       = 0;
};

//--------------------------------------
BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 500.0;
   totalTime          = 2;
   liveTime           = 1;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//--------------------------------------
BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.5;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 600.0;
   totalTime          = 2;
   liveTime           = 1;

   //lightRange         = 3.0;
   //lightColor         = { 0.25, 0.25, 1.0 };
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
   damageValue        = 1;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 600;
   totalTime          = 2;
   liveTime           = 1;

   //lightRange         = 3.0;
   //lightColor         = { 1.0, 0.25, 0.25 };
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
   damageValue        = 1;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4;

   muzzleVelocity     = 999;
   totalTime          = 2;
   liveTime           = 1;
   //lightRange         = 3.0;
   //lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0;
   isVisible          = True;

   soundId = SoundJetLight;
};

//--------------------------------------
RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 3.5;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 8;
   kickBackStrength = 5;

   muzzleVelocity   = 700;
   terminalVelocity = 900;
   acceleration     = 5;

   totalTime        = 2;
   liveTime         = 1;

   //lightRange       = 5.0;
   //lightColor       = { 0.7, 0.7, 1.0 };

   inheritedVelocityScale = 3;

   // rocket specific
   trailType   = 1;
   trailLength = 200;
   trailWidth  = 0.5;

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
   damageValue        = 1;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 350;
   totalTime          = 9.0;    // special meaning for grenades...
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
   maxLevelFlightDist = 350;
   totalTime          = 6;
   liveTime           = 2;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//---------------------------------------
GrenadeData SpiralScopeShell 
{ 
        bulletShapeName = "grenade.dts";
        explosionTag = SpiralScopeExp;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0.2;
        mass = 9;
        elasticity = 0.1;
        damageClass = 1;
        damageValue = 280;
        damageType = $ShrapnelDamageType;
        explosionRadius = 15;
        kickBackStrength = 300;
        maxLevelFlightDist = 250;
        totalTime = 5;
        liveTime = 1;
        projSpecialTime = 0.05;
        inheritedVelocityScale = 0.5;
        smokeName = "smoke.dts";
        soundId = SoundELFFire;
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
   maxLevelFlightDist = 550;
   totalTime          = 9.0;
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
   damageValue      = 2;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 850.0;
   terminalVelocity = 1800.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   //lightRange       = 5.0;
   //lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
//--J22Rocket 4 projectiles
//--------------------------------------
SeekingMissileData J22RocketEMP
{ 
   bulletShapeName = "fusionbolt.dts";
   explosionTag = J22RocketEMPExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 0.3;
   damageType = $EMPDamageType;
   explosionRadius = 8;
   kickBackStrength = 0;//200.0;
   
   muzzleVelocity = 60.0;
   
   terminalVelocity = 100.0;
   acceleration = 5.0;
   
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   //smokeDist = 1.5;
   
   trailType = 2; 
   trailString = "smoke.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   //soundId = SoundJetHeavy;
}; 

//--------------------------------------
SeekingMissileData J22Rocket
{ 
   bulletShapeName = "rocket.dts";
   explosionTag = rocketExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 1;
   damageType = $J22RocketDamageType;
   explosionRadius = 9.5;
   kickBackStrength = 200.0;
   
   muzzleVelocity = 50.0;
   
   terminalVelocity = 100.0;
   acceleration = 4;
   
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   smokeDist = 1.5;
   
   trailType = 2; 
   trailString = "smoke.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   //soundId = SoundJetHeavy;
}; 

//--------------------------------------
SeekingMissileData J22RocketSubmission
{ 
   bulletShapeName = "rocket.dts";
   explosionTag = rocketExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 1;
   damageType = $J22RocketDamageType;
   explosionRadius = 9.5;
   kickBackStrength = 200.0;
   
   muzzleVelocity = 40.0;
   
   terminalVelocity = 60.0;
   acceleration = 3;
   
   totalTime = 30.0;
   liveTime = 31.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   smokeDist = 1.5;
   
   trailType = 2; 
   trailString = "smoke.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   //soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData J22Rocketalt
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 850.0;
   terminalVelocity = 1800.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   //lightRange       = 5.0;
   //lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   //trailType   = 2;                // smoke trail
   //trailString = "rsmoke.dts";
   //smokeDist   = 1.8;

   //soundId = SoundJetHeavy;
};

//--------------------------------------
//--J22EMPRocket 3 projectiles-
//--------------------------------------
//--------------------------------------
//--------------------------------------

SeekingMissileData J22EMPRocketONE
{ 
   bulletShapeName = "fusionbolt.dts";
   explosionTag = J22RocketEMPExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 0.35;
   damageType = $EMPDamageType;
   explosionRadius = 3;
   kickBackStrength = 0;//200.0;
   
   muzzleVelocity = 100.0;
   
   terminalVelocity = 200.0;
   acceleration = 5.0;
   
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   //smokeDist = 1.5;
   
   //trailType = 2; 
   //trailString = "smoke.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   //soundId = SoundJetHeavy;
}; 

SeekingMissileData J22EMPRocketTWO
{ 
   bulletShapeName = "fusionbolt.dts";
   explosionTag = J22RocketEMPExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 0.4;
   damageType = $EMPDamageType;
   explosionRadius = 3;
   kickBackStrength = 0;//200.0;
   
   muzzleVelocity = 75.0;
   
   terminalVelocity = 200.0;
   acceleration = 4;
   
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   //smokeDist = 1.5;
   
   //trailType = 2; 
   //trailString = "fusionbolt.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   //soundId = SoundJetHeavy;
}; 

RocketData J22EMPRocketalt
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = J22RocketEMPExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $EMPDamageType;

   explosionRadius  = 3;
   kickBackStrength = 0;//250.0;
   muzzleVelocity   = 600;
   terminalVelocity = 800;
   acceleration     = 1;
   totalTime        = 2;
   liveTime         = 2;
   //lightRange       = 5.0;
   //lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   //trailType   = 2;                // smoke trail
   //trailString = "fusionbolt.dts";
   //smokeDist   = 1.8;

   //soundId = SoundJetHeavy;
};

//--------------------------------------

SeekingMissileData MiniFlakproj
{
   bulletShapeName = "rocket.dts";
   explosionTag    = MiniFlakExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $J22RocketDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 100.0;
   totalTime         = 3;
   liveTime          = 3;
   seekingTurningRadius    = 1;
   nonSeekingTurningRadius = 1;
   proximityDist     = 1.5;
   //smokeDist         = 1.75;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   //soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData MiniSAMproj
{
   bulletShapeName = "rocket.dts";
   explosionTag    = MiniSAMExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $J22RocketDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 30.0;
   terminalvelocity  = 100;
   acceleration      = 2;
   totalTime         = 20;
   liveTime          = 20;
   seekingTurningRadius    = 1;
   nonSeekingTurningRadius = 1;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.76;

   //soundId = SoundJetHeavy;
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

   muzzleVelocity    = 300.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   //soundId = SoundJetHeavy;
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

   damageConversion  = 0.4;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.25;

   //lightRange        = 3.0;
   //lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//--------------------------------------
LaserData TaserRfLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.5;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.4;

   //lightRange        = 2;
   //lightColor        = { 0.4, 0, 0.6 };

   detachFromShooter = false;
   hitSoundId        = SoundBeaconUse;
};

//--------------------------------------
BulletData AnnihilatorProj
{
   bulletShapeName    = "shield_large.dts";
   explosionTag       = AnnihilatorExp;

   damageClass        = 1;
   damageValue        = 15;
   damageType         = $AnnihilatorDamageType;
   explosionRadius    = 35;

   muzzleVelocity     = 800;
   totalTime          = 25;
   liveTime           = 7;
   lightRange         = 3.0;
   lightColor         = { 0.1, 0.5, 1 };
   inheritedVelocityScale = 5;
   isVisible          = True;

   soundId = SoundGeneratorPower;
};


//--------------------------------------
LaserData TaserTrtBLaser 
{ 
        laserBitmapName = "paintPulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.09;
        baseDamageType = $LaserDamageType;
        beamTime = 2;
        //lightRange = 2;
        //lightColor = { 0.4, 0, 0.6 };
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
};

//--------------------------------------
LaserData TaserTrtCLaser 
{ 
        laserBitmapName = "paintPulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.0001;
        baseDamageType = $LaserDamageType;
        beamTime = 0.08;
        //lightRange = 2;
        //lightColor = { 0.4, 0, 0.6 };
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
};

//--------------------------------------
LaserData LaserTrtLaser 
{ 
        laserBitmapName = "laserpulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.09;
        baseDamageType = $LaserDamageType;
        beamTime = 0.08;
        //lightRange = 2;
        //lightColor = { 0.4, 0, 0.6 };
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
};

//--------------------------------------

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
   bitmapName       = "laserpulse.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 100.0;
   coneAngle        = 3.0;
   damagePerSec      = 2;
   energyDrainPerSec = 500.0;
   segmentDivisions = 6;
   numSegments      = 2;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.25;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//--------------------------------------
LightningData GreenLaserProj
{
   bitmapName       = "trailadd2.bmp";

   damageType       = $GreenLaserDamageType;
   boltLength       = 100.0;
   coneAngle        = 3.0;
   damagePerSec      = 2;
   energyDrainPerSec = 500;
   segmentDivisions = 4;
   numSegments      = 1;
   beamWidth        = 0.2;//0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0;

   //lightRange = 3.0;
   //lightColor = { .25, .72, .08 };

   soundId = SoundELFFire;
};

//--------------------------------------

LightningData MiniSmokeTurretproj
{
   bitmapName       = "trailadd2.bmp";

   damageType       = $MiniELFDamageType;
   boltLength       = 100.0;
   coneAngle        = 3.0;
   damagePerSec      = 0.5;
   energyDrainPerSec = 0;
   segmentDivisions = 4;
   numSegments      = 1;
   beamWidth        = 2;//0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0;

   //lightRange = 3.0;
   //lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//--------------------------------------
LightningData MiniELFTurretproj
{
   bitmapName       = "laserpulse.bmp";

   damageType       = $MiniELFDamageType;
   boltLength       = 70.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.01;//0.8;
   energyDrainPerSec = 1000;
   segmentDivisions = 6;
   numSegments      = 2;
   beamWidth        = 0.25;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.25;

   //lightRange = 3.0;
   //lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//--------------------------------------
//--------------------------------------
LightningData turretCharge
{
   bitmapName       = "laserpulse.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 100.0;
   coneAngle        = 35.0;
   damagePerSec      = 0;
   energyDrainPerSec = 500;
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


function GreenLaserproj::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
%friendFire = $Server::TeamDamageScale;
	%playerId = %shooterId;
	//if (%playerId.GravBolt == "0")
	//{
		%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
		%Zvalue = %Rotation;
		%velocity = -80;
		%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
		Player::applyImpulse(%target, %shooterDir);

		%damVal = %timeSlice * %damPerSec;
		%enVal  = %timeSlice * %enDrainPerSec;
		GameBase::applyDamage(%target, $GreenLaserDamageType, %damVal, %pos, %vec, %mom, %shooterId);
   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);

}

//////////////////////////////////////////////////
//function GreenLaserproj::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
//{
//   %damVal = %timeSlice * %damPerSec;
//   %enVal  = %timeSlice * %enDrainPerSec;
//	 //%targetId = GameBase::getControlClient(%target);
//	 //%targetName = Client::getName(%targetId);
//   GameBase::applyDamage(%target, $GreenLaserDamageType, %damVal, %pos, %vec, %mom, %shooterId);
//         //Client::sendMessage(%targetid,0,"DOH,you have dropped somethings!");
//   %energy = GameBase::getEnergy(%target);
//   %energy = %energy - %enVal;
//   if (%energy < 0) {
//      %energy = 0;
//   }
//   GameBase::setEnergy(%target, %energy);
//}
/////////////////////////////////////////////////

function MiniELFturretproj::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;
	 //%targetId = GameBase::getControlClient(%target);
	 //%targetName = Client::getName(%targetId);
   GameBase::applyDamage(%target, $MiniELFDamageType, %damVal, %pos, %vec, %mom, %shooterId);
         //Client::sendMessage(%targetid,0,"DOH,you have dropped somethings!");
   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;
	//%targetId = GameBase::getControlClient(%target);
	//%targetName = Client::getName(%targetId);
   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
        //Client::sendMessage(%targetid,3,"DOH!");
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
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 2;
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
		%player.repairRate   = 2;
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
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
$LiLRocketDamageType   = 14;
$EMPDamageType         = 15;
$LiLPOOmkiiDamageType  = 16;
$SmokeDamageType       = 17;
$MiniELFDamageType     = 18;
$BeamOfPainDamageType     = 19;
$FlashDamageType     = 20;
$tribesDamageType     = 21;

$AMineDamageType     = 22;
$NapalmDamageType     = 23;
/////////////////////////////////////////////////////
BulletData ChaingunBullet
{
   bulletShapeName    = "laserhit.dts";
//   validateShape      = true;
   explosionTag       = AtomExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 5000;
   totalTime          = 0.35;
   LiveTime          = 0.35;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 100;
   //tracerLength       = 30;
};


SeekingMissileData StripperONE
{ 
   bulletShapeName = "fusionbolt.dts";
   explosionTag = LiLRocketEMPExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 0.5;
   damageType = $EMPDamageType;
   explosionRadius = 3;
   kickBackStrength = 0;//200.0;
   
   muzzleVelocity = 100.0;
   
   terminalVelocity = 1000.0;
   acceleration = 50.0;
   
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

SeekingMissileData StripperTWO
{ 
   bulletShapeName = "fusionbolt.dts";
   explosionTag = LiLRocketEMPExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 0.5;
   damageType = $EMPDamageType;
   explosionRadius = 3;
   kickBackStrength = 0;//200.0;
   
   muzzleVelocity = 75.0;
   
   terminalVelocity = 1000.0;
   acceleration = 100;
   
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



RocketData Stripperalt
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = Strippershockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.25;
   damageType       = $EMPDamageType;

   explosionRadius  = 7;
   kickBackStrength = 0;//250.0;
   muzzleVelocity   = 1000;
   terminalVelocity = 2000;
   acceleration     = 1;
   totalTime        = 2;
   liveTime         = 2;
   //lightRange       = 5.0;
   //lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   trailType   = 1;
   trailLength = 50;
   trailWidth  = 0.2;

};
//--------------------------------------
BulletData TribesShell
{
   bulletShapeName    = "shield.dts";
   explosionTag       = TribesExp;

   damageClass        = 1;
   damageValue        = 1;
   damageType         = $TribesDamageType;
   explosionRadius    = 4;

   muzzleVelocity     = 600;
   totalTime          = 2;
   liveTime           = 1;
   //lightRange         = 3.0;
   //lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0;
   isVisible          = True;

   soundId = SoundJetLight;
};


//--------------------------------------
BulletData Fireball
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = fireballExp;

   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $ShrapnelDamageType;
   explosionRadius    = 15;

   muzzleVelocity     = 600;
   totalTime          = 6;
   liveTime           = 1;
   //lightRange         = 1;
   //lightColor         = { 0, 0, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   //soundId = SoundJetLight;
};

//--------------------------------------
GrenadeData SmScreen
{ 
        bulletShapeName = "smoke.dts";
        explosionTag = SmScreenExp;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0;
        mass = 9;
        elasticity = 0.01;
        damageClass = 1;
        damageValue = 0.2;
        damageType = $SmokeDamageType;
        explosionRadius = 5;
        kickBackStrength = 0;
        maxLevelFlightDist = 250;
        totalTime = 1;
        liveTime = 32;
        projSpecialTime = 0.08;
        inheritedVelocityScale = 0.5;
        smokeName = "smoke.dts";
        soundId = SoundJetHeavy;
};

//--------------------------------------
GrenadeData ExSmScreen
{ 
        bulletShapeName = "fusionex.dts";
        explosionTag = ExSmScreenExp;
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
        maxLevelFlightDist = 250;
        totalTime = 10;
        liveTime = 6;
        projSpecialTime = 0.01;
        inheritedVelocityScale = 0.5;
        smokeName = "plasmatrail.dts";
        soundId = SoundELFFire;
};


//--------------------------------------
RocketData FireScreen
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = FireScreenExp;
   collisionRadius  = 0;
   mass             = 2;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 3;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 20;
   kickBackStrength = 15;
   muzzleVelocity   = 80;
   terminalVelocity = 160;
   acceleration     = 1;
   totalTime        = 3;
   liveTime         = 1;
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
BulletData SpellAbilityProj
{
   bulletShapeName    = "lfemale.dts";
//   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.25;
   muzzleVelocity     = 30;
   totalTime          = 4;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 100;
   //tracerLength       = 30;
};

//--------------------------------------

//--------------------------------------
BulletData LiLPOOmkiBullet2
{
   bulletShapeName    = "smoke.dts";
//   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $BulletDamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 8000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 0;
   //tracerLength       = 0;
};

RocketData LiLPOOmkiBullet

{
 bulletShapeName = "snowplume.dts";
 explosionTag = bulletExp0;
 mass = 0.1;
 collisionRadius = 0;
 bulletHoleIndex = 0;
 damageClass = 0;
 damageValue = 1;
 damageType = $BulletDamageType;
 muzzleVelocity = 8000;
 terminalVelocity = 10000;
 totalTime = 1;
 inheritedVelocityScale = 0;
 isVisible = true;
 tracerPercentage = 0;
 tracerLength = 0;
 detachFromShooter = false;
};

//--------------------------------------
RocketData LiLPOOmkiiBullet

{
 bulletShapeName = "snowplume.dts";
 explosionTag = bulletExp0;
 mass = 0.1;
 collisionRadius = 0;
 bulletHoleIndex = 0;
 damageClass = 0;
 damageValue = 1;
 damageType = $LiLPOOmkiiDamageType;
 muzzleVelocity = 9000;
 terminalVelocity = 11000;
 totalTime = 1;
 inheritedVelocityScale = 0;
 isVisible = true;
 tracerPercentage = 0;
 tracerLength = 0;
 detachFromShooter = false;
};


BulletData LiLPOOmkiiBullet0
{
   bulletShapeName    = "bullet.dts";
//   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $LiLPOOmkiiDamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 9000;
   totalTime          = 1;
   inheritedVelocityScale = 0;
   isVisible          = true;

   tracerPercentage   = 0;
   tracerLength       = 0;
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

   muzzleVelocity     = 600;
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
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 8;
   kickBackStrength = 5;

   muzzleVelocity   = 600;
   terminalVelocity = 800;
   acceleration     = 1;

   totalTime        = 2;
   liveTime         = 1;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.1;

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
   maxLevelFlightDist = 150;
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
   maxLevelFlightDist = 275;
   totalTime          = 6;
   liveTime           = 2;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//---------------------------------------
GrenadeData LiLFFBShell 
{ 
        bulletShapeName = "grenade.dts";
        explosionTag = LiLFFBExp;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0.2;
        mass = 9;
        elasticity = 0.1;
        damageClass = 1;
        damageValue = 150;
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
   maxLevelFlightDist = 400;
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
//--LiLRocket 4 projectiles-listening to Orbital The End Of NoWhere 112600
//--------------------------------------
SeekingMissileData LiLRocketEMP
{ 
   bulletShapeName = "fusionbolt.dts";
   explosionTag = LiLRocketEMPExp;
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
SeekingMissileData LiLRocket
{ 
   bulletShapeName = "rocket.dts";
   explosionTag = rocketExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 1;
   damageType = $LiLRocketDamageType;
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
SeekingMissileData LiLRocketSubmission
{ 
   bulletShapeName = "rocket.dts";
   explosionTag = rocketExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 1;
   damageType = $LiLRocketDamageType;
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
RocketData LiLRocketalt
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
//--LiLEMPRocket 3 projectiles-
//--------------------------------------
//--------------------------------------
//--------------------------------------

SeekingMissileData LiLEMPRocketONE
{ 
   bulletShapeName = "fusionbolt.dts";
   explosionTag = LiLRocketEMPExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 0.5;
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

SeekingMissileData LiLEMPRocketTWO
{ 
   bulletShapeName = "fusionbolt.dts";
   explosionTag = LiLRocketEMPExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 0.5;
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

RocketData LiLEMPRocketalt
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = LiLRocketEMPExp;
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
   damageType       = $LiLRocketDamageType;
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
   damageType       = $LiLRocketDamageType;
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

   damageConversion  = 0.7;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.05;

   //lightRange        = 2.0;
   //lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//--------------------------------------
LaserData TaserRfLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 3;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.08;

   //lightRange        = 2;
   //lightColor        = { 0.4, 0, 0.6 };

   detachFromShooter = false;
   hitSoundId        = SoundBeaconUse;
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
        beamTime = 0.3;
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
LightningData BeamOfPainProj
{
   bitmapName       = "trailadd2.bmp";

   damageType       = $BeamOfPainDamageType;
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
   //lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//--------------------------------------
//minismoke is beam of pain turret

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
   boltLength       = 100.0;
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


function BeamOfPainproj::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
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
		GameBase::applyDamage(%target, $BeamOfPainDamageType, %damVal, %pos, %vec, %mom, %shooterId);
   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);

}

//////////////////////////////////////////////////
//function BeamOfPainproj::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
//{
//   %damVal = %timeSlice * %damPerSec;
//   %enVal  = %timeSlice * %enDrainPerSec;
//	 //%targetId = GameBase::getControlClient(%target);
//	 //%targetName = Client::getName(%targetId);
//   GameBase::applyDamage(%target, $BeamOfPainDamageType, %damVal, %pos, %vec, %mom, %shooterId);
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

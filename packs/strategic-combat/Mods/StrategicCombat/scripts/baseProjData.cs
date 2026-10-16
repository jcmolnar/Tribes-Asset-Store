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
$DrainDamageType       = 14;

//***************
function CustomDamageMode(%damage,%type)
{
 if(%type == $ImpactDamageType) return (%damage * $Combat::ImpactDamage);
 if(%type == $LandingDamageType) return (%damage * $Combat::LandingDamage);
 if(%type == $BulletDamageType) return (%damage * $Combat::BulletDamage);
 if(%type == $EnergyDamageType) return (%damage * $Combat::EnergyDamage);
 if(%type == $PlasmaDamageType) return (%damage * $Combat::PlasmaDamage);
 if(%type == $ExplosionDamageType) return (%damage * $Combat::ExplosionDamage);
 if(%type == $ShrapnelDamageType) return (%damage * $Combat::ShrapnelDamage);
 if(%type == $LaserDamageType) return (%damage * $Combat::LaserDamage);
 if(%type == $MortarDamageType) return (%damage * $Combat::MortarDamage);
 if(%type == $BlasterDamageType) return (%damage * $Combat::BlasterDamage);
 if(%type == $ElectricityDamageType) return (%damage * $Combat::ElectricityDamage);
 if(%type == $CrushDamageType) return (%damage * $Combat::CrushDamage);
 if(%type == $DebrisDamageType) return (%damage * $Combat::DebrisDamage);
 if(%type == $MissileDamageType) return (%damage * $Combat::MissileDamage);
 if(%type == $MineDamageType) return (%damage * $Combat::MineDamage);
}

//-----------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.01;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.06;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0005;
   muzzleVelocity     = 600.0;
   totalTime          = 1.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 0.5;
   tracerLength       = 30;
};

//******************
BulletData VRPBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.01;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.036;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0011;
   muzzleVelocity     = 700.0;
   totalTime          = 1.2;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 0.5;
   tracerLength       = 30;
};

//*********************
BulletData PistolBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.04;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $BulletDamageType;

   aimDeflection      = 0;
   muzzleVelocity     = 350.0;
   totalTime          = 0.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1;
   tracerLength       = 10;
};

GrenadeData FlameBurst {
	explosionTag = FlameBurstExp;
	collideWithOwner = True; 
	ownerGraceMS = 50; 
	collisionRadius = 4.0; 
      mass = 1.0; 
	elasticity = 0.3; 
	damageClass = 1; 
	damageValue = 0.16; 
	damageType = $PlasmaDamageType; 
	explosionRadius = 7.0; 
	kickBackStrength = 0.1; 
      // maxLevelFlightDist = 75; // This is it, the velocity of the shell!
      maxLevelFlightDist = 25; 
	totalTime = 4.0; 
	liveTime = 0.02; 
	projSpecialTime = 0.01; 
	lightRange = 10.0; 
	lightColor = { 1.0, 1.0, 0.0 }; 
	inheritedVelocityScale = 0.5; 
	smokeName = "plastrail.dts"; 
      soundId = SoundFlyerActive; 
}; 


//*********************
BulletData MPistolBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.04;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0011;
   muzzleVelocity     = 350.0;
   totalTime          = 0.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1;
   tracerLength       = 10;
};

//**************************
BulletData HvyChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.13;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.001;
   muzzleVelocity     = 600.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 15;
};

//**************************
BulletData HvyBulletSpread
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.004;
   muzzleVelocity     = 600.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 0.5;
   tracerLength       = 15;
};

//**************************
BulletData HVAPShell
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = debrisExpSmall;
   mass               = 0.15;
   bulletHoleIndex    = 0;
   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.45;
   damageType         = $BulletDamageType;
   aimDeflection      = 0;
   muzzleVelocity     = 800.0;
   totalTime          = 2.0;
   inheritedVelocityScale = 1.1;
   isVisible          = False;
   tracerPercentage   = 1.0;
   tracerLength       = 1;
};

//**************************
BulletData HVAPShellSpread
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = debrisExpSmall;
   mass               = 0.15;
   bulletHoleIndex    = 0;
   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.40;
   damageType         = $BulletDamageType;
   aimDeflection      = 0.004;
   muzzleVelocity     = 800.0;
   totalTime          = 0.8;
   inheritedVelocityScale = 1.1;
   isVisible          = False;
   tracerPercentage   = 1.0;
   tracerLength       = 1;
};

//********************
BulletData HEAPShell
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   mass               = 0.1;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.35;
   damageType         = $ExplosionDamageType;

   explosionRadius  = 5.0;
   kickBackStrength = 90.0;

   aimDeflection      = 0;
   muzzleVelocity     = 450.0;
   totalTime          = 2.0;
   inheritedVelocityScale = 1.1;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 1;
};

//********************
BulletData HEAPShellSpread
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   mass               = 0.1;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.30;
   damageType         = $ExplosionDamageType;

   explosionRadius  = 2.5;
   kickBackStrength = 90.0;

   aimDeflection      = 0.006;
   muzzleVelocity     = 450.0;
   totalTime          = 0.8;
   inheritedVelocityScale = 1.1;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 1;
};

//**************************
BulletData SpeederBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = debrisExpSmall;
   // expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.14;
   damageType         = $BulletDamageType;

   explosionRadius    = 2.0;
   aimDeflection      = 0.004;
   muzzleVelocity     = 600.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 0.5;
   tracerLength       = 15;
};

//********************
BulletData GaussBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;

   mass            = 0.05;
   bulletHoleIndex  = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue      = 1.3;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0;
   muzzleVelocity     = 1000.0;
   totalTime          = 5.0;
   isVisible          = False;
   inheritedVelocityScale = 0.0;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//*********************
BulletData SniperBullet
{
  bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.69;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0;
   muzzleVelocity     = 900.0;
   totalTime          = 3.0;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 20;
};

//*********************
BulletData SniperBurstBullet
{
  bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.007;
   muzzleVelocity     = 900.0;
   totalTime          = 3.0;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 20;
};

//******************
BulletData EDGunBolt
{
   bulletShapeName    = "shield.dts";
   explosionTag       = turretExp;
   mass               = 0.05;
   damageClass        = 1;
   damageValue        = 0.0055;
   damageType         = $DrainDamageType;
   explosionRadius    = 4.0;
   kickBackStrength   = 0;
   muzzleVelocity     = 70.0;
   totalTime          = 1.0;
   liveTime           = 1.0;
   isVisible          = True;
   rotationPeriod = 1.5;
};

//******************
BulletData ShieldKiller
{
   bulletShapeName    = "shield.dts";
   explosionTag       = energyExp;
   mass               = 0.05;
   damageClass        = 0;
   damageValue        = 0.0055;
   damageType         = $DrainDamageType;
   muzzleVelocity     = 70.0;
   totalTime          = 1.0;
   liveTime           = 1.0;
   isVisible          = false;
};

//-------------------
BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $EnergyDamageType;
   explosionRadius    = 4.0;
   kickBackStrength   = 80.0;

   muzzleVelocity     = 70.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//*******************
BulletData CannonBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.55;
   damageType         = $EnergyDamageType;
   explosionRadius    = 9.5;
   kickBackStrength   = 300.0;

   muzzleVelocity     = 100.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//-----------------------
BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.19;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 130.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------
BulletData BlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 1;
   damageValue        = 0.2;
   damageType         = $BlasterDamageType;
   explosionRadius    = 2.0;
   kickBackStrength   = 80.0;

   muzzleVelocity     = 330.0;	// 220.0;
   totalTime          = 0.8;	// 1.0;
   liveTime           = 0.8;	// 1.0;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//-------------------
BulletData PlasmaBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.55;				// .45;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 60.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//---------------------
BulletData RepeaterBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.3;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 60.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 1.1;
   isVisible          = True;

   soundId = SoundJetLight;
};

//------------------
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
   terminalVelocity = 90.0;
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

//======================================================================== Hyper Bolt
BulletData KineticBolt
{
   bulletShapeName    = "paint.dts";
   explosionTag       = hblasterExp;

   damageClass        = 0;
   damageValue        = 0.12;
   damageType         = $ImpactDamageType;

   muzzleVelocity     = 500.0;
   totalTime          = 1.0;
   liveTime           = 0.13;

   lightRange         = 3.0;
   lightColor         = { 0.3, 1.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
//   soundId = SoundELFFire;
};

//------------------
// RocketData KineticBolt
// {
//    bulletShapeName = "enbolt.dts";
//    explosionTag    = energyExp;
//    collisionRadius = 0.0;
//    mass            = 2.0;
//    damageClass      = 0;
//    damageValue      = 0.07;
//    damageType       = $ImpactDamageType;
//    muzzleVelocity   = 750.0;
//    terminalVelocity = 750.0;
//    acceleration     = 5.0;
//    totalTime        = 6.0;
//    liveTime         = 6.0;
//    lightRange       = 5.0;
//    lightColor       = { 0.4, 0.4, 1.0 };
//    inheritedVelocityScale = 0.5;
//    trailType   = 1;
//    trailLength = 400;
//    trailWidth  = 0.2;
//    soundId = SoundELFFire;
// };

//----------------------
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
   damageValue        = 0.6;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 16;
   kickBackStrength   = 180.0;
   maxLevelFlightDist = 160;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};

//----------------------
GrenadeData ImpactGrenade
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.3;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.24;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 12;
   kickBackStrength   = 160.0;
   maxLevelFlightDist = 120;
   totalTime          = 10.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};

//**************
GrenadeData Bomb
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 100.0;
   elasticity         = 0.01;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 10.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 60.0;
   kickBackStrength   = 800.0;
   maxLevelFlightDist = 1;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.001;
   smokeName              = "mortartrail.dts";
};

//---------------------
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

//---------------------
GrenadeData srMortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = debrisExpLarge;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.3;
   mass               = 4.0;
   elasticity         = 0.2;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.25;
   damageType         = $MortarDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 350.0;
   maxLevelFlightDist = 80;
   totalTime          = 15.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//---------------------------
GrenadeData MortarTurretShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
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

//---------------------------
GrenadeData LongTomTurretShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   aimDeflection      = 0.006;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.32;
   damageType         = $MortarDamageType;

   explosionRadius    = 40.0;
   kickBackStrength   = 450.0;
   maxLevelFlightDist = 400;
   totalTime          = 1000.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//--------------------
RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.35;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 200.0; //600.0;
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

//--------------------
RocketData MiniRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.27;
   damageType       = $MissileDamageType;

   explosionRadius  = 8.5;
   kickBackStrength = 90.0; //200.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 130.0;
   acceleration     = 8.0;
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

//------------------------------
SeekingMissileData TurretMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collideWithOwner   = False;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.60;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 190.0;

   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 1.1;

   soundId = SoundJetHeavy;
};

function SeekingMissile::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}

//************************
SeekingMissileData homingMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collideWithOwner   = False;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.8;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 90.0;

   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 1.1;

   soundId = SoundJetHeavy;
};

function homingMissile::updateTargetPercentage(%target)
{
	return 1.0;
}


//-------------------
LaserData sniperLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.014;	// 0.007; Plus // damageConversion  = 0.022;

   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData turretLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.005;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData cutterLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   // damageConversion  = 0.014;
   damageConversion  = 0.02;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.30;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

LightningData PPCCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 75.0;
   coneAngle        = 10.0;
   damagePerSec      = 0.25;
   energyDrainPerSec = 45.0;
   segmentDivisions = 4;
   numSegments      = 1;
   beamWidth        = 0.35;//075;

   updateTime   = 60;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

LightningData lightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 55.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.12;
   energyDrainPerSec = 50.0;
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

//**************************
LightningData transferCharge
{
   bitmapName       = "repairadd.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.09;
   energyDrainPerSec = 30.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };

   soundId = SoundELFFire;
};

function transferCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;
   %player = client::getOwnedObject(%shooterId);
   %armor = Player::getArmor(%shooterId);
   %targetDam = GameBase::getDamageState(%target);

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if(%energy < 0) %energy = 0;
   GameBase::setEnergy(%target, %energy);

   if(%targetDam != "Destroyed")
   {
   %health = GameBase::getDamageLevel(%player);
   if(%health != 0) GameBase::setDamageLevel(%player,%health - (%enVal * 0.0018));
   }
}

//************************
LightningData turretCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.08;
   energyDrainPerSec = 70.0;
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
   if(%energy < 0) %energy = 0;
   GameBase::setEnergy(%target, %energy);
}

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

	if (%target == %player) {
		%player.repairTarget = -1;

		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 0.07;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		} else {
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	} else {
		%player.repairTarget = %target;

		if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) {
			%player.repairRate = 0.1;
		} else {
			%player.repairRate = 0.25;
		}

		if (getObjectType(%player.repairTarget) == "Player") {
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		} else {
			%name = GameBase::getMapName(%target);
			if(%name == "") %name = (GameBase::getDataName(%player.repairTarget)).description;
		}

		if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}

		if (getObjectType(%player.repairTarget) == "Player") Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		Client::sendMessage(%client,0,"Repairing " @ %name);
	}

	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if(%object != -1) 
	{
		%client = Player::getClient(%player);
		if(%object == %player) Client::sendMessage(%client,0,"AutoRepair Off");
		else 
		{
			if(GameBase::getDamageLevel(%object) == 0) Client::sendMessage(%client,0,"Repair Done");
			else Client::sendMessage(%client,0,"Repair Stopped");
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if(%rate < 0) %rate = 0;
      GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolt::checkDone(%this, %player)
{
	if(Player::isTriggered(%player,$WeaponSlot) && 
    (Player::getMountedItem(%player,$WeaponSlot) == RepairGun || Player::getMountedItem(%player,$WeaponSlot) == FieldRepairGun) &&
	%player.repairTarget != -1) 
	{
		%object = %player.repairTarget;
		if(%object == %player) 
		{
			if(GameBase::getDamageLevel(%player) == 0) 
			{
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else 
		{
			if(GameBase::getDamageLevel(%object) == 0) 
			{
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}


//******************
BulletData NARCShell
{
   bulletShapeName = "discb.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;

   mass            = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0;
   muzzleVelocity     = 500.0;
   totalTime          = 0.4;
   isVisible          = True;
   inheritedVelocityScale = 0.0;

   lightRange       = 5.0;
   lightColor       = { 0.8, 0.7, 0.4 };

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};


GrenadeData ArmChan { 
	bulletShapeName = "rsmoke.dts"; 
	explosionTag = armChanExp; 
	collideWithOwner = false; 
	ownerGraceMS = 500; 
	collisionRadius = 0.0; 
	mass = 0.0; 
	elasticity = 0.1; 
	damageClass = 0; 
	damageValue = 0.01; 
	damageType = $NullDamageType; 
	explosionRadius = 2; 
	kickBackStrength = 0.0; 
	maxLevelFlightDist = 4; 
	totalTime = 0.55; 
	liveTime = 0.55; 
	projSpecialTime = 0.05; 
	inheritedVelocityScale = 1.0; 
	smokeName = "rsmoke.dts"; 
}; 


GrenadeData JumpBlast { 
	bulletShapeName = "rsmoke.dts"; 
	explosionTag = JumpBlastExp; 
	collideWithOwner = false; 
	ownerGraceMS = 500; 
	collisionRadius = 0.0; 
	mass = 0.0; 
	elasticity = 0.1; 
	damageClass = 0; 
	damageValue = 0.01; 
	damageType = $NullDamageType; 
	explosionRadius = 3; 
	kickBackStrength = 50.0; 
	maxLevelFlightDist = 4; 
	totalTime = 0.55; 
	liveTime = 0.55; 
	projSpecialTime = 0.05; 
	inheritedVelocityScale = 1.0; 
	smokeName = "rsmoke.dts"; 
}; 


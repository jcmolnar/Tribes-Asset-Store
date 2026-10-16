# Damage Types
#
$ImpactDamageType		  = -1;
$LandingDamageType	  =  0;
$BulletDamageType      =  1;
$FlamerDamageType      =  2;
$PPCDamageType      =  3;
$ExplosionDamageType   =  4;
$ShrapnelDamageType    =  5;
$LaserDamageType       =  6;
$GaussDamageType      =  7;
$ElectricityDamageType =  9;
$CrushDamageType       = 10;
$DebrisDamageType      = 11;
$MissileDamageType     = 12;
$MineDamageType        = 13;
$ACDamageType        = 14;
$STRDamageType        = 15;
$LRMDamageType        = 16;
$SniperDamageType        = 17;
$InfernoDamageType = 18;

//++++++++++++++++++++++
RocketData GaussGunShell
{
   bulletShapeName = "paint.dts"; //"Mortar.dts";
   explosionTag    = debrisExpSmall;

   collisionRadius = 0.0;
   mass            = 150.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.7; //0.6;
   damageType       = $GaussDamageType;

   muzzleVelocity   = 2000.0; //800.0;++++++
   terminalVelocity = 2000.0;
   acceleration     = 0.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
	lightColor = { 0.85, 0.25, 0.25 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "mortartrail.dts"; //"rsmoke.dts";++++
   smokeDist   = 30;

   soundId = SoundJetHeavy;
};
BulletData GaussGunShell2
{
   bulletShapeName = "paint.dts"; //"Mortar.dts";
   explosionTag    = debrisExpSmall;

   collisionRadius = 0.0;
   mass            = 150.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.078;
   damageType       = $GaussDamageType;

   muzzleVelocity   = 2000.0; //800.0;+++++++
   terminalVelocity = 2000.0;
   acceleration     = 0.0;
   aimDeflection      = 0.020;

   totalTime        = 6.5;
   liveTime         = 8.0;
   isVisible          = True;//+++++++++++

   lightRange       = 5.0;
	lightColor = { 0.85, 0.25, 0.25 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "mortartrail.dts"; //"rsmoke.dts";++++
   smokeDist   = 30;

   soundId = SoundJetHeavy;
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData SniperGunShell
{
   bulletShapeName = "bullet.dts";
   explosionTag    = debrisExpSmall;

   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 0;
   damageValue      = 0.4;
   damageType       = $SniperDamageType;

   muzzleVelocity   = 8000.0; //4000.0;++++++++
   terminalVelocity = 8000.0;
   acceleration     = 0.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 4.0;
   lightColor = { 1, 0, 0 };

   inheritedVelocityScale = 0.5;
   // rocket specific
   trailType   = 1;
   trailLength = 500;
   trailWidth  = 0.3;
};
BulletData SniperGunShell2
{
   bulletShapeName = "bullet.dts";
   explosionTag    = debrisExpSmall;

   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 0;
   damageValue      = 0.3; //0.4;
   damageType       = $SniperDamageType;

   muzzleVelocity   = 6000.0; //4000.0;++++++++
   terminalVelocity = 6000.0;
   acceleration     = 0.0;
   aimDeflection      = 0.001;
   isVisible          = True;//+++++++

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 4.0;
   lightColor = { 1, 0, 0 };

   inheritedVelocityScale = 0.5;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData Ultra5Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 0.5;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.011; //0.007;
   damageType         = $ACDamageType;

   aimDeflection      = 0.004; //0.003; 0.005; (Base Chaingun Deflection)
   muzzleVelocity     = 425.0; //(Base Chaingun)
   totalTime          = 0.42;//(Base Chaingun)
   inheritedVelocityScale = 1.0;//(Base Chaingun)
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 30; //(Base Chaingun)
};
//++++++++++++++++++++++
BulletData Ultra5Bullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 0.5;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.011; //0.007;
   damageType         = $ACDamageType;

   aimDeflection      = 0.020; // 0.005; (Base Chaingun Deflection)
   muzzleVelocity     = 425.0; //(Base Chaingun)
   totalTime          = 0.42;//(Base Chaingun)
   inheritedVelocityScale = 1.0;//(Base Chaingun)
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 30; //(Base Chaingun)
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData Ultra5Tracer
{
   bulletShapeName = "bullet.dts";
   explosionTag    = ACExpSmall;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.011;
   damageType       = $ACDamageType;

   muzzleVelocity   = 425.0;
   terminalVelocity = 425.0;
   acceleration     = 0.0;

   totalTime        = 0.42;
   liveTime         = 0.42;

   lightRange       = 2.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.0;//0.5;+++++++++++

   // rocket specific
   trailType   = 1;
   trailLength = 35;
   trailWidth  = 0.3;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData Ultra10Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 0.75;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.022; //0.011;
   damageType         = $ACDamageType;

   aimDeflection      = 0.006; //0.005; 0.005; (Base Chaingun Deflection)
   muzzleVelocity     = 425.0;
   totalTime          = 0.31;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0; //1.0;
   tracerLength       = 100;
};
BulletData Ultra10Bullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 0.75;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.022; //0.007;
   damageType         = $ACDamageType;

   aimDeflection      = 0.020; // 0.005; (Base Chaingun Deflection)
   muzzleVelocity     = 425.0; //(Base Chaingun)
   totalTime          = 0.31;//(Base Chaingun)
   inheritedVelocityScale = 1.0;//(Base Chaingun)
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 100; //(Base Chaingun)
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData Ultra10Tracer
{
   bulletShapeName = "bullet.dts";
   explosionTag    = ACExpSmall;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.022;
   damageType       = $ACDamageType;

   muzzleVelocity   = 425.0;
   terminalVelocity = 425.0;
   acceleration     = 0.0;

   totalTime        = 0.31;
   liveTime         = 0.31;

   lightRange       = 2.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.0;//0.5;+++++++++++

   // rocket specific
   trailType   = 1;
   trailLength = 45;
   trailWidth  = 0.5;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData Ultra20Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 1.0;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.04; //0.0262;
   damageType         = $ACDamageType;

   aimDeflection      = 0.008; //0.007; 0.005; (Base Chaingun Deflection)
   muzzleVelocity     = 425.0;
   totalTime          = 0.2;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 30;
};
BulletData Ultra20Bullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 1.0;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.04;
   damageType         = $ACDamageType;

   aimDeflection      = 0.020; // 0.005; (Base Chaingun Deflection)
   muzzleVelocity     = 425.0; //(Base Chaingun)
   totalTime          = 0.2;//(Base Chaingun)
   inheritedVelocityScale = 1.0;//(Base Chaingun)
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 30; //(Base Chaingun)
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData Ultra20Tracer
{
   bulletShapeName = "bullet.dts";
   explosionTag    = ACExpSmall;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.04; //0.0262;
   damageType       = $ACDamageType;

   muzzleVelocity   = 425.0;
   terminalVelocity = 425.0;
   acceleration     = 0.0;

   totalTime        = 0.2;
   liveTime         = 0.2;

   lightRange       = 2.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.0;//0.5;+++++++++++

   // rocket specific
   trailType   = 1;
   trailLength = 55;
   trailWidth  = 0.7;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData AC5Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 0.5;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.025;
   damageType         = $ACDamageType;

   aimDeflection      = 0.002; //0.001; 0.005; (Base Chaingun Deflection), larger number = more deflection
   muzzleVelocity     = 425.0; //(Base Chaingun)
   totalTime          = 0.52;//(Base Chaingun)
   inheritedVelocityScale = 1.0;//(Base Chaingun)
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 30; //(Base Chaingun)
};
BulletData AC5Bullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 0.5;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.02;
   damageType         = $ACDamageType;

   aimDeflection      = 0.020; //0.001; 0.005; (Base Chaingun Deflection), larger number = more deflection
   muzzleVelocity     = 425.0; //(Base Chaingun)
   totalTime          = 0.52;//(Base Chaingun)
   inheritedVelocityScale = 1.0;//(Base Chaingun)
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 30; //(Base Chaingun)
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData AC5Tracer
{
   bulletShapeName = "bullet.dts";
   explosionTag    = ACExpSmall;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.025;
   damageType       = $ACDamageType;

   aimDeflection      = 0.001; //0.005; (Base Chaingun Deflection)
   muzzleVelocity   = 425.0;
   terminalVelocity = 425.0;
   acceleration     = 0.0;

   totalTime        = 0.52;
   liveTime         = 0.52;

   lightRange       = 2.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.0;//0.5;+++++++++++

   // rocket specific
   trailType   = 1;
   trailLength = 35;
   trailWidth  = 0.3;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData AC10Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 0.75;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.047;
   damageType         = $ACDamageType;

   aimDeflection      = 0.003; //0.002; 0.003; (Ultra10 value)
   muzzleVelocity     = 425.0;
   totalTime          = 0.41;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0; //1.0;
   tracerLength       = 100;
};
BulletData AC10Bullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 0.75;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.042;
   damageType         = $ACDamageType;

   aimDeflection      = 0.020; //0.002; 0.003; (Ultra10 value)
   muzzleVelocity     = 425.0;
   totalTime          = 0.41;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0; //1.0;
   tracerLength       = 100;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData AC10Tracer
{
   bulletShapeName = "bullet.dts";
   explosionTag    = ACExpSmall;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.047;
   damageType       = $ACDamageType;

   aimDeflection      = 0.002; //0.005; (Base Chaingun Deflection)
   muzzleVelocity   = 425.0;
   terminalVelocity = 425.0;
   acceleration     = 0.0;

   totalTime        = 0.41;
   liveTime         = 0.41;

   lightRange       = 2.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.0;//0.5;+++++++++++

   // rocket specific
   trailType   = 1;
   trailLength = 45;
   trailWidth  = 0.5;
};
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData AC20Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 1.0;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.09;
   damageType         = $ACDamageType;

   aimDeflection      = 0.004; //0.005; (Base Chaingun Deflection)
   muzzleVelocity     = 425.0;
   totalTime          = 0.31;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 30;
};
BulletData AC20Bullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 1.0;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.08;
   damageType         = $ACDamageType;

   aimDeflection      = 0.020; //0.005; (Base Chaingun Deflection)
   muzzleVelocity     = 425.0;
   totalTime          = 0.31;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 30;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData AC20Tracer
{
   bulletShapeName = "bullet.dts";
   explosionTag    = ACExpSmall;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.09;
   damageType       = $ACDamageType;

   aimDeflection      = 0.004; //0.005; (Base Chaingun Deflection)
   muzzleVelocity   = 425.0;
   terminalVelocity = 425.0;
   acceleration     = 0.0;

   totalTime        = 0.2;
   liveTime         = 0.2;

   lightRange       = 2.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.0;//0.5;+++++++++++

   // rocket specific
   trailType   = 1;
   trailLength = 55;
   trailWidth  = 0.7;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData MachineGunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;

   collisionRadius = 0.0;
   mass            = 0.01;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.01; //0.009
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0011; //0.0008;
   muzzleVelocity     = 425.0;
   totalTime          = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = True; //False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
BulletData MachineGunBullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;

   collisionRadius = 0.0;
   mass            = 0.01;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.01; //0.009
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = True; //False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//+++++++++++++++++++++++++++++++++++++++++++
RocketData PPCBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.45;
   damageType         = $PPCDamageType;
   explosionRadius  = 5.0;
   kickBackStrength = 100.0;

   muzzleVelocity   = 80.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;

   totalTime        = 6.5;//+++++++
   liveTime         = 8.0;//8.0;++++++++

   lightRange       = 7.0;
   lightColor       = { 0.25, 0.25, 1.0 };//++++++

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.6;

   soundId = SoundJetHeavy;
   rotationPeriod = 0.1;
};
//++++++++++++++++++++++++++++++++++
BulletData PPCBolt2
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp; //energyExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.35;
   damageType         = $PPCDamageType;
   explosionRadius  = 5.0;
   kickBackStrength = 60.0;

   muzzleVelocity   = 80.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   aimDeflection      = 0.02; //0.015;
   isVisible          = True;//+++++++++++

   totalTime        = 4.0; //6.5;
   liveTime         = 5.0; //8.0;

   lightRange       = 7.0;
   lightColor       = { 0.25, 0.25, 1.0 };//++++++

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.35;

   soundId = SoundJetHeavy;
   rotationPeriod = 0.1;
};

//++++++++++++++++++++++++++++++++++
GrenadeData FlamerShell
{
//   bulletShapeName    = "grenade.dts";
   explosionTag       = FlameBurstExp;
   collideWithOwner   = True;
   ownerGraceMS       = 100;
   collisionRadius    = 10.0;
   mass               = 0.5;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.005; //0.0025;
   damageType         = $FlamerDamageType;
   explosionRadius    = 8.0;
   kickBackStrength   = 1.0;

   maxLevelFlightDist = 150;
   totalTime          = 0.6;    // special meaning for grenades...
   liveTime           = 0.6;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;

	lightRange = 6.0;
	lightColor = { 0.55, 0.40, 0.1 };

   smokeName              = "plastrail.dts";

	soundId = SoundFlyerActive;
};
RocketData FlamerShell2
{

   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = FlamerExp;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass        = 1;
   damageValue        = 0.125; //0.1;
   damageType         = $FlamerDamageType;
   explosionRadius    = 12.0;

   muzzleVelocity   = 55.0;
   terminalVelocity = 55.0;
   acceleration     = 0.0;

   totalTime        = 1.5;
   liveTime         = 1.5;

   lightRange       = 2.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.0;//0.5;+++++++++++

	lightRange = 8.0;
	lightColor = { 0.55, 0.40, 0.1 };

   // rocket specific
   trailType   = 2;
   trailString = "plastrail.dts";
   smokeDist   = 30;

	soundId = SoundJetHeavy;
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
GrenadeData MortarTurretShell    //LongTom
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 800; //400
   collisionRadius    = 1.0;
   mass               = 0.0000001;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 1.1; //1.32;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 35.0;
   kickBackStrength   = 350.0;
   maxLevelFlightDist = 5000;
   totalTime          = 5.0;
   liveTime           = 0.001; //0.1;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "dustplume.dts"; //"rsmoke.dts";
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
SeekingMissileData LRM5Missile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;    
   damageValue      = 0.065; 
   damageType       = $LRMDamageType;
   explosionRadius  = 7.0;
   kickBackStrength = 15.0;

   muzzleVelocity    = 80.0;
   terminalVelocity = 130.0;
   acceleration     = 10.0;
   aimDeflection      = 0.1;

   totalTime         = 7;
   liveTime          = 7;
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 40.0;
   nonSeekingTurningRadius = 40.0;
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
SeekingMissileData LRM5Missile2
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;    
   damageValue      = 0.065; 
   damageType       = $LRMDamageType;
   explosionRadius  = 7.0;
   kickBackStrength = 15.0;

   muzzleVelocity    = 80.0;
   terminalVelocity = 130.0;
   acceleration     = 10.0;
   aimDeflection      = 0.1;

   totalTime         = 7;
   liveTime          = 7;
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 20.0;
   nonSeekingTurningRadius = 20.0;
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
//++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData LRM5Rocket
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       
   damageValue      = 0.065;
   damageType       = $LRMDamageType;
   explosionRadius  = 7.0;
   kickBackStrength = 35.0;

   muzzleVelocity    = 80.0;
   terminalVelocity = 130.0;
   acceleration     = 10.0;
   aimDeflection      = 0.008; //0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 7;
   liveTime          = 7;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;              
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
SeekingMissileData STR2Missile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.13;
   damageType       = $STRDamageType;
   explosionRadius  = 4.0;
   kickBackStrength = 25.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
//   aimDeflection      = 0.1;

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 10.0;
   nonSeekingTurningRadius = 10.0;
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
SeekingMissileData STR2Missile2
{
   bulletShapeName = "rocket.dts";
   explosionTag    = infernoExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.065;
   damageType       = $InfernoDamageType;
   explosionRadius  = 4.0;
   kickBackStrength = 25.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
//   aimDeflection      = 0.1;

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 10.0;
   nonSeekingTurningRadius = 10.0;
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
SeekingMissileData STR2MissileT
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.13;
   damageType       = $STRDamageType;
   explosionRadius  = 4.0;
   kickBackStrength = 25.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
//   aimDeflection      = 0.1;

   totalTime         = 5; //3.5;
   liveTime          = 5; //3.5;
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 5.0;
   nonSeekingTurningRadius = 5.0;
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData STR2Rocket
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.13;
   damageType       = $STRDamageType;
   explosionRadius  = 4.0;
   kickBackStrength = 55.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   aimDeflection      = 0.01;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
BulletData STR2Rocket2
{
   bulletShapeName = "rocket.dts";
   explosionTag    = infernoExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.065;
   damageType       = $InfernoDamageType;
   explosionRadius  = 4.0;
   kickBackStrength = 55.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   aimDeflection      = 0.01;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
SeekingMissileData ArrowIVMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = mortarExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.7;
   damageType       = $MissileDamageType;
   explosionRadius  = 17.0;
   kickBackStrength = 175.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 15.0;
   nonSeekingTurningRadius = 15.0;
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
SeekingMissileData ArrowIVMissile2
{
   bulletShapeName = "rocket.dts";
   explosionTag    = LargeShockwave;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.35;
   damageType       = $MissileDamageType;
   explosionRadius  = 25.0;
   kickBackStrength = 250.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 15.0;
   nonSeekingTurningRadius = 15.0;
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData ArrowIVRocket
{
   bulletShapeName = "rocket.dts";
   explosionTag    = mortarExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.7;
   damageType       = $MissileDamageType;
   explosionRadius  = 17.0;
   kickBackStrength = 175.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;
   isVisible          = True;//+++++++++++

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
RocketData ArrowIVRocket2
{
   bulletShapeName = "rocket.dts";
   explosionTag    = LargeShockwave;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.35;
   damageType       = $MissileDamageType;
   explosionRadius  = 25.0;
   kickBackStrength = 250.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;
   isVisible          = True;//+++++++++++

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
LaserData MedLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.00001;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 4.0;
	lightColor  = { 0.25, 1, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData MedLaserShell
{
   bulletShapeName = "bullet.dts";
   explosionTag    = laserExp1;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $LaserDamageType;

   muzzleVelocity   = 15000.0;
   terminalVelocity = 15000.0;
   acceleration     = 0.0;

   totalTime        = 0.8; //0.033;
   liveTime         = 0.8; //0.033;

   lightRange       = 4.0;
	lightColor  = { 0.25, 1, 0.25 };

   inheritedVelocityScale = 0.0;//0.5;+++++++++++

};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
LaserData MedLaserTurretShell
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.025;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 4.0;
	lightColor  = { 0.25, 1, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
LaserData LrgLaser
{
   laserBitmapName   = "forcefield1.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.00001;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.8;

   lightRange        = 6.0;
   lightColor        = { 0.25, 0.25, 0.85 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData LrgLaserShell
{
   bulletShapeName = "bullet.dts";
   explosionTag    = laserExp0;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass      = 0;    
   damageValue      = 0.3;
   damageType       = $LaserDamageType;

   muzzleVelocity   = 15000.0;
   terminalVelocity = 15000.0;
   acceleration     = 0.0;

   totalTime        = 0.8; //0.1;
   liveTime         = 0.8; //0.1;

   lightRange       = 6.0;
   lightColor        = { 0.25, 0.25, 0.85 };

   inheritedVelocityScale = 0.0;

};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
laserData MediumPulseLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.002;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.3;

   lightRange        = 2.0;
	lightColor  = { 0.25, 1, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
laserData LargePulseLaser
{
   laserBitmapName   = "forcefield1.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.004;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 4.0;
   lightColor        = { 0.25, 0.25, 0.85 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
GrenadeData SmokeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = SmokeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0.01;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 150;
   totalTime          = 40.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

function SmokeShell::onAdd(%this)
{
	schedule("DeploySmoke(" @ %this @ " , 2);",1.8,%this);
}

function DeploySmoke(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Smoke1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.5,false);
		%obj = newObject("","Mine","Smoke2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-0.5,false);
		%obj = newObject("","Mine","Smoke1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-0.5,false);
		%obj = newObject("","Mine","Smoke2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.5,false);
		%count -= 1;
		schedule("DeploySmoke(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}
//++++++++++++++++++++
GrenadeData SmokeShell2
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = BangExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0.07;
   damageType         = $DebrisDamageType;

   explosionRadius    = 15.0;
   kickBackStrength   = 200.0;
   maxLevelFlightDist = 150;
   totalTime          = 40.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

function SmokeShell2::onAdd(%this)
{
	schedule("DeploySmoke3(" @ %this @ " , 1);",1.8,%this); //2+++++
}

function DeploySmoke3(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Bang1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.5,false);
		%obj = newObject("","Mine","Bang2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-0.5,false);
		%obj = newObject("","Mine","Bang1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-0.5,false);
		%obj = newObject("","Mine","Bang2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.5,false);
		%count -= 1;
		schedule("DeploySmoke3(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}
//-----------------------------------------------------------------------
TargetLaserData targetLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 10.0;
   baseDamageType    = $LaserDamageType; 

   lightRange        = 1.0;
	lightColor  = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//---------------------------------------------------------------------
RepairEffectData RepairBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 8.0; //5.0
   segmentDivisions = 8;
   beamWidth        = 0.125;

   updateTime   = 50; //120;
   skipPercent  = 0.5;
   displaceBias = 0.1; //0.15;

   lightRange = 6.0;
   lightColor = { 0.85, 0.25, 0.25 };

   soundId = SoundELFFire;//++++++++
};

function RepairBolt::onAcquire(%this, %player, %target)
{

		//+++++++++++++++++++++++++++++++++++++++++++++++++++++
//		if(GameBase::getTeam(%player) != GameBase::getTeam(%this))//++++++++damage, not working++++++
//		{
//		if(GameBase::getDamageLevel(%this) <= 0) 
//		{
//			GameBase::applyDamage(%this,2,0.1,%pos,%vec,%mom,%player)
//			GameBase::repairDamage(%this,-0.10);
//			GameBase::playSound(%this,ForceFieldOpen,0);
//			}
//		}//++++++++++++++++++ end damage ++++++++++++++++++++++

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
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData F1aker 
{ 
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExpHV; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0; 
	damageType = $ExplosionDamageType; 
	explosionRadius = 0; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 65.0; 
	terminalVelocity = 80.0; 
	acceleration = 5.0; 
	totalTime = 0.01; 
	liveTime = 0.01; 
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5; 
}; 
function F1aker::onAdd(%this) 
{
	%t = $F1aky;
	%markerPos = $F1aky2;
	$F1aky = ""; 
	$F1aky2 = ""; 
	%trans = GameBase::getTransform(%this);
	%rot = getWord(%trans, 3) @ " " @ getWord(%trans, 4) @ " " @ getWord(%trans, 5);
	%f = Vector::getFromRot(%rot, 3.5, 2);		
	%vehicle = newObject("",flier,ShortCoolProj,true);
	Gamebase::setMapName(%vehicle,"ArrowIV");
	addToSet("MissionCleanup", %vehicle);
	%client = GameBase::getControlClient(%t);
	GameBase::setTeam(%vehicle,Client::getTeam(%client));
	GameBase::startFadeIn(%vehicle);
	GameBase::setPosition(%vehicle,Vector::add(%markerPos, %f));
	GameBase::setRotation(%vehicle,%rot);
	doneposs(%client);
	Client::setControlObject(%client, %vehicle); 
}